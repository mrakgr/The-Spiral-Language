from functools import reduce

import torch
from torch.distributions import Categorical
from torch.nn.modules.container import ModuleList
from torch.nn.modules.linear import Linear
import torch.optim
import torch.nn
from torch.functional import Tensor
from torch.nn import Module
from torch.optim import Optimizer
from torch.nn.parameter import Parameter
from projector import Projector

class SquareErrorTracker(Module):
    def __init__(self):
        super().__init__()
        self.square_error = Parameter(torch.scalar_tensor(0.0),requires_grad=False)
        self.square_error_count = 0

    def mse_clear(self): self.square_error.fill_(0.0); self.square_error_count = 0
    @property 
    def mse(self): return (self.square_error / self.square_error_count).sqrt_()
    @property
    def mse_and_clear(self): x = self.mse; self.mse_clear(); return x

    def add(self,a : Tensor,b : Tensor):
        self.square_error += (a - b).square().sum()
        self.square_error_count += len(a)
        
class SignSGD(Optimizer):
    """
    Does a step in the direction of the sign of the gradient.
    """
    def __init__(self,params,lr=2 ** -10,momentum_decay=0.0,weight_decay=1.0):
        super().__init__(params,dict(lr=lr,momentum_decay=momentum_decay,weight_decay=weight_decay))

    @torch.no_grad()
    def step(self):
        for gr in self.param_groups:
            momentum_decay, lr, weight_decay = gr['momentum_decay'], gr['lr'], gr['weight_decay']

            for x in gr['params']:
                if weight_decay != 1.0: x *= weight_decay
                if x.grad is not None:
                    if momentum_decay == 0.0: # Self play works better without momentum.
                        x -= torch.sign(x.grad).mul_(lr)
                    else:
                        x_state = self.state.get(x)
                        if x_state is None: x_state = {}; self.state[x] = x_state
                        m = x_state.get('momentum_params')
                        if m is None: m = torch.zeros_like(x); x_state['momentum_params'] = m
                        m *= momentum_decay; m += x.grad
                        x -= torch.sign(m).mul_(lr)

def normed(o : Tensor,dim= -1): return o / o.sum(dim=dim,keepdim=True).clamp_min(1e-38)
def normed_abs(x : Tensor,dim=- 1): return normed(x.abs(),dim)
def normed_abs_cube(x : Tensor,dim= -1): return normed((x ** 3).abs(),dim)
def normed_square(x : Tensor,dim= -1): return normed(x.square(),dim)
def inf(o : Tensor,dim= -1) -> Tensor: return o / o.norm(p=float('inf'),dim=dim,keepdim=True).clamp_min(1e-38)
def inf_cube(x : Tensor,dim= -1): return inf(x ** 3,dim)

class InfCube(Linear):
    def forward(self,x): return inf_cube(super().forward(x))

class ResInfCube(InfCube):
    def __init__(self,size): super().__init__(size,size)
    def forward(self,x): return super().forward(x) + x

class DenseInfCube(Linear):
    def forward(self,x): return torch.cat((inf_cube(x),x),1)

class Rotary(Module):
    def __init__(self,dim_in):
        super().__init__()
        self.dim_in = dim_in
        self.freq = Parameter(torch.empty(dim_in),requires_grad=False)
        freq = 10000 ** torch.arange(0, -1, -2 / dim_in, dtype=torch.float)
        torch.cat((freq, freq[:freq.shape[0] - self.dim_in % 2]),out=self.freq) # Doing it like this to avoid memory fragmentation when initing the embedding.

    def make_emb(self,dim_seq):
        i = torch.arange(dim_seq, dtype=self.freq.dtype, device=self.freq.device)
        emb = (i.view(-1,1) * self.freq.view(1,-1)).view(1,dim_seq,1,self.dim_in)
        return emb.cos(), emb.sin()

    def rotate_half(self,x : Tensor):
        x1, x2 = x.chunk(2,-1)
        return torch.cat((-x2, x1), dim = -1)

    def forward(self,x,emb_cos,emb_sin):
        return x * emb_cos + self.rotate_half(x) * emb_sin

class TopEncoderBase(Module):
    def __init__(self,dim_in,dim_head=2 ** 3,dim_emb=2 ** 5):
        super().__init__()
        self.dim_in, self.dim_head, self.dim_emb = dim_in, dim_head, dim_emb
        self.proj_q = Linear(dim_in,dim_head*dim_emb)
        self.proj_kv = Linear(dim_in,2*dim_head*dim_emb)

    def forward(self,x,rotary,mask=None) -> Tensor:
        dz,dk,_ = x.shape; dh,de = self.dim_head,self.dim_emb
        kv : Tensor = self.proj_kv(x).view(dz,dk,2,dh,de)
        q,k,v = self.proj_q(x[:,0]).view(dz,dh,de), rotary(kv[:,:,0]), inf_cube(kv[:,:,1])
        seq_weights : Tensor = torch.einsum('zhe,zkhe->zkh',q,k)
        if mask is not None:
            seq_weights = seq_weights.masked_fill(mask.view(dz,dk,1),0.0)
        return torch.einsum('zkh,zkhe->zhe',normed_square(seq_weights,-2),v).reshape(dz,dh*de)

class TopEncoder(TopEncoderBase):
    def __init__(self,dim_in,dim_head=2 ** 3,dim_emb=2 ** 5):
        super().__init__(dim_in,dim_head,dim_emb)
        self.rotary = Rotary(dim_emb)

    def forward(self,x,mask=None):
        emb = self.rotary.make_emb(x.shape[1])
        return super().forward(x,lambda x: self.rotary(x,*emb),mask)

class EncoderBase(Module):
    def __init__(self,dim_in,dim_head=2 ** 3,dim_emb=2 ** 5):
        super().__init__()
        self.dim_in, self.dim_head, self.dim_emb = dim_in, dim_head, dim_emb
        self.proj_in = Linear(dim_in,3*dim_head*dim_emb)

    def forward(self,x,rotary,mask=None) -> Tensor:
        dz,dk,_ = x.shape; dh,de = self.dim_head,self.dim_emb
        qkv : Tensor = self.proj_in(x).view(dz,dk,3,dh,de)
        q,k,v = rotary(qkv[:,:,0]), rotary(qkv[:,:,1]), inf_cube(qkv[:,:,2])
        seq_weights : Tensor = torch.einsum('zqhe,zkhe->zqkh',q,k)
        if mask is not None:
            seq_weights = seq_weights.masked_fill(torch.logical_or(mask.view(dz,dk,1,1),mask.view(dz,1,dk,1)),0.0)
        return torch.einsum('zqkh,zkhe->zqhe',normed_square(seq_weights,-2),v).reshape(dz,dk,dh*de)

class Encoder(EncoderBase):
    def __init__(self,dim_in,dim_head=2 ** 3,dim_emb=2 ** 5):
        super().__init__(dim_in,dim_head,dim_emb)
        self.rotary = Rotary(dim_emb)

    def forward(self,x,mask=None):
        emb = self.rotary.make_emb(x.shape[1])
        return super().forward(x,lambda x: self.rotary(x,*emb),mask)

class ResEncoderBase(EncoderBase):
    def __init__(self,dim_head=2 ** 3,dim_emb=2 ** 5):
        super().__init__(dim_head*dim_emb,dim_head,dim_emb)

    def forward(self,x,rotary,mask=None):
        return x + super().forward(x,rotary,mask)

class EncoderList(Module):
    def __init__(self,depth,dim_head=2 ** 3,dim_emb=2 ** 5,dim_in=None,dim_top_head=None):
        super().__init__()
        self.rotary = Rotary(dim_emb)
        self.initial = EncoderBase(dim_in,dim_head,dim_emb) if dim_in is not None else None
        self.layers = ModuleList([ResEncoderBase(dim_head,dim_emb) for _ in range(depth)])
        self.top = TopEncoderBase(dim_head*dim_emb,dim_head if dim_top_head is None else dim_top_head,dim_emb)
        
    def forward(self,x,mask=None):
        emb = self.rotary.make_emb(x.shape[1])
        def rotary(x): return self.rotary(x,*emb)
        x = reduce(lambda x,lay: lay(x,rotary,mask), self.layers,self.initial(x,rotary,mask) if self.initial is not None else x)
        return self.top(x,rotary,mask)

def sample_value_probs(proj : Projector, value_probs : Tensor):
    sample_indices = Categorical(value_probs).sample()
    return proj.support[sample_indices.flatten()].view(sample_indices.shape)

class Head(Module):
    def __init__(self,dim_action : int,dim_in : int,dim_out : int,num_submodules : int = 2):
        super().__init__()
        self.dim_action = dim_action
        self.dim_input = dim_in
        self.dim_out = dim_out
        self.initial = Linear(dim_action+dim_in,dim_in)
        self.middle = ModuleList([Linear(dim_in,dim_in) for i in range(num_submodules)])
        self.out = Linear(dim_in,dim_out)

    def forward(self, action_data : Tensor, data : Tensor):
        dz,db,dl = action_data.shape
        dz,dr = data.shape
        assert self.dim_action == dl, f"Got: {self.dim_action} and {dl}"
        assert self.dim_input == dr, f"Got: {self.dim_input} and {dr}"
        data = data.unsqueeze(1).expand(dz,db,dr)
        def f(x : Tensor): return inf_cube(x)
        data = f(self.initial(torch.cat([action_data,data],-1))) + data
        return self.out(reduce(lambda s,x: s + f(x(s)),self.middle,data)).squeeze(-1)

def model_explore(
        ers : SquareErrorTracker or None,
        proj : Projector, value : Module, value_head : Module, policy : Module, policy_head : Module,
        is_update_value : bool, is_update_policy : bool,
        policy_data : Tensor, policy_mask : Tensor, 
        value_data : Tensor, value_mask : Tensor, pids : Tensor, 
        action_data : Tensor, action_mask : Tensor
        ):
    """
    Does critic training with categorical distributions.
    """
    sample_indices = torch.masked_fill(torch.normal(0.0,1.0,action_mask.shape),action_mask,float('-inf')).argmax(-1)
    def update(rewards : Tensor):
        nonlocal value_data, value_mask, policy_data, policy_mask, pids, action_data, action_mask, sample_indices
        sample_indices = sample_indices.cuda()
        value_data, value_mask, pids, action_data, action_mask = value_data.cuda(), value_mask.cuda(), pids.cuda().view(-1,1), action_data.cuda(), action_mask.cuda()
        value_raw : Tensor = value(value_data,mask=value_mask)
        value_head_raw : Tensor = value_head.forward(action_data,value_raw)
        value_probs = torch.softmax(value_head_raw,-1).detach()

        policy_data, policy_mask = policy_data.cuda(), policy_mask.cuda()
        action_probs = torch.masked_fill(policy_head(action_data,policy(policy_data,mask=policy_mask)),action_mask,float('-inf')).softmax(-1)

        if is_update_value or is_update_policy:
            values = proj.mean(value_probs)
            def index_selected_actions(x : Tensor): return x[torch.arange(0,len(sample_indices)),sample_indices]
            if ers: ers.add(index_selected_actions(values),proj.mean(rewards))
            if is_update_value: index_selected_actions(value_head_raw).log_softmax(-1).backward(-rewards)
            if is_update_policy: action_probs.backward(values * -pids)

        return torch.einsum('bav,ba->bv',value_probs,action_probs.detach())
    return None, sample_indices.cpu().numpy(), update

def model_exploit(
        ers : SquareErrorTracker or None,
        proj : Projector, value : Module, value_head : Module, policy : Module, policy_head : Module,
        is_update_value : bool, is_update_policy : bool,
        policy_data : Tensor, policy_mask : Tensor, 
        value_data : Tensor, value_mask : Tensor, pids : Tensor, 
        action_data : Tensor, action_mask : Tensor
        ):
    """
    Does MC value propagation. Uses the actual policy for exploration.
    """
    policy_data, policy_mask, action_data, action_mask = policy_data.cuda(), policy_mask.cuda(), action_data.cuda(), action_mask.cuda()
    def calc_action_probs(): return torch.masked_fill(policy_head(action_data,policy(policy_data,mask=policy_mask)),action_mask,float('-inf')).softmax(-1)
    action_probs = calc_action_probs()
    sample_indices = Categorical(action_probs).sample()
    def update(rewards : Tensor): # As long as training is not done, it can be used to propagate scalar reward arrays as well.
        if is_update_value or is_update_policy:
            nonlocal value_data, value_mask, pids
            value_data, value_mask, pids = value_data.cuda(), value_mask.cuda(), pids.cuda().view(-1,1)
            value_raw : Tensor = value(value_data,mask=value_mask)
            value_head_raw : Tensor = value_head.forward(action_data,value_raw)
            value_probs = torch.softmax(value_head_raw,-1).detach()
            values = proj.mean(value_probs)

            def index_selected_actions(x : Tensor): return x[torch.arange(0,len(sample_indices)),sample_indices]
            if ers: ers.add(index_selected_actions(values),proj.mean(rewards))
            if is_update_value: index_selected_actions(value_head_raw).log_softmax(-1).backward(-rewards)
            if is_update_policy: calc_action_probs().backward(values * -pids)
        return rewards
    return action_probs.detach().cpu().numpy(), sample_indices.cpu().numpy(), update