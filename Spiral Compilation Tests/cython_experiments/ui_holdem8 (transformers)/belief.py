from functools import reduce
from math import sqrt
import torch
from torch.distributions import Categorical
from torch.nn.modules.container import ModuleList
from torch.nn.modules.linear import Identity, Linear
import torch.optim
import torch.nn
from torch.functional import Tensor
from torch.nn import Module
from torch.optim import Optimizer
from torch.nn.parameter import Parameter
from torch.nn.init import xavier_normal_
from torch.nn.functional import pad

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

class Head(Module):
    def __init__(self,size_state,size_action):
        super(Head, self).__init__()
        self.weighted_values = Parameter(torch.zeros(size_action,size_state),requires_grad=False)
        self.weights = Parameter(torch.zeros(size_action,size_state),requires_grad=False)

    @property
    def values(self): return torch.nan_to_num_(self.weighted_values / self.weights)

def inf_cube(x : Tensor,dim=-1) -> Tensor: 
    o = x ** 3
    return o / o.norm(p=float('inf'),dim=dim,keepdim=True).clamp_min(1e-38)
def normed_abs_cube(x : Tensor,dim=-1) -> Tensor:
    o = (x ** 3).abs()
    return o / o.sum(dim=dim,keepdim=True).clamp_min(1e-38)
def normed_square(x : Tensor,dim=-1) -> Tensor:
    o = x.square()
    return o / o.sum(dim=dim,keepdim=True).clamp_min(1e-38)

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

    def pos_emb(self,dim_seq):
        i = torch.arange(dim_seq, dtype=self.freq.dtype, device=self.freq.device)
        return (i.view(-1,1) * self.freq.view(1,-1)).view(1,dim_seq,1,self.dim_in)

    def rotate_half(self,x : Tensor):
        x1, x2 = x.chunk(2,-1)
        return torch.cat((-x2, x1), dim = -1)

    def forward(self,x):
        assert x.dim() == 4, f"Expected the number of tensor dimensions to be 4: batch, seq, head, el. Got: {x.shape}"
        emb = self.pos_emb(x.shape[1])
        return x * emb.cos() + self.rotate_half(x) * emb.sin()

class Attention(Module):
    def __init__(self,dim_in,dim_out,num_heads=1,dim_qk=128):
        super().__init__()
        self.dim_in, self.dim_qk, self.num_heads, self.dim_out = dim_in, dim_qk, num_heads, dim_out
        self.proj_in = Parameter(torch.empty((dim_in,num_heads,dim_qk*2+dim_out)))
        for x in torch.split(self.proj_in,[self.dim_qk,self.dim_qk,self.dim_out],-1): xavier_normal_(x)
        self.v_bias = Parameter(torch.zeros(num_heads,dim_out))
        self.proj_out = Parameter(xavier_normal_(torch.empty((num_heads,dim_out,dim_out))))
        self.proj_out_bias = Parameter(torch.zeros(dim_out))
        self.rotary = Rotary(dim_qk)

    def forward(self,x,mask=None):
        q,k,v = torch.split(torch.einsum('zki,iho->zkho',x,self.proj_in),[self.dim_qk,self.dim_qk,self.dim_out],-1)
        dz, dk, dh, da = k.shape
        q,k = self.rotary(q), self.rotary(k)
        seq_weights : Tensor = torch.einsum('zqha,zkha->zqkh',q,k) / sqrt(da)
        # if mask is not None:
        #     seq_weights = seq_weights.masked_fill(torch.logical_or(mask.view(dz,dk,1,1),mask.view(dz,1,dk,1)),float('-inf'))
        # o = torch.einsum('zqkh,zkhx->zqhx',seq_weights.softmax(-2).nan_to_num(),v + self.v_bias.view(1,1,dh,self.dim_out))
        if mask is not None:
            seq_weights = seq_weights.masked_fill(torch.logical_or(mask.view(dz,dk,1,1),mask.view(dz,1,dk,1)),0.0)
        o = torch.einsum('zqkh,zkhx->zqhx',normed_square(seq_weights,-2),v + self.v_bias.view(1,1,dh,self.dim_out))
        return inf_cube(torch.einsum('zqhx,hxy->zqy',inf_cube(o),self.proj_out) + self.proj_out_bias.view(1,1,self.dim_out))

class ResAttention(Attention):
    def __init__(self,dim_out,num_heads=1,dim_qk=128):
        super().__init__(dim_out,dim_out,num_heads,dim_qk)

    def forward(self,x,mask=None):
        y = super().forward(x,mask)
        return (x + y) / 2

class AttentionList(Module):
    def __init__(self,dim_out,depth=1,num_heads=1,dim_qk=128,initial=Identity()):
        super().__init__()
        self.initial = initial
        self.layers = ModuleList([ResAttention(dim_out,num_heads,dim_qk) for _ in range(depth)])

    def forward(self,x,mask=None):
        return reduce(lambda x,lay:lay(x,mask),self.layers,self.initial(x))

class FakeAttention(Module): # For testing that the attention inputs work as well as on MLPs.
    def __init__(self,dim_in,dim_out,dim_seq=20):
        super().__init__()
        self.dim_in = dim_in
        self.dim_seq = dim_seq
        self.l = InfCube(dim_in*dim_seq,dim_out)

    def forward(self,x : Tensor,mask=None):
        dz,dk,da = x.shape
        assert (dk < self.dim_seq)
        assert (da == self.dim_in)
        x = pad(x.flip(1).view(dz,dk*da),(0,(self.dim_seq-dk)*da))
        return self.l.forward(x).unsqueeze(1)

def belief_tabulate(state_probs : Tensor,head : Head,action_indices : Tensor,rewards : Tensor,regret_probs : Tensor):
    # state_probs[batch_dim,state_dim]
    # head[action_dim*2,state_dim]
    # action_indices[batch_dim] : map (action_dim -> batch_dim)
    # rewards[batch_dim,1]
    # regret_probs[batch_dim,1]

    def update_head(): # Weighted moving average update. Works well with probabilistic vectors and weighted updates that CFR requires.
        state_weights = regret_probs * state_probs # [batch_dim,state_dim]
        head.weighted_values .index_add_(0,action_indices,rewards * state_weights)
        head.weights.index_add_(0,action_indices,state_weights)

    def calculate():
        values = head.values # [action_dim,state_dim]
        def state_probs_grad(): # The backprop derived rule.
            prediction_values_for_state = values[action_indices,:] # [batch_dim,state_dim]
            at_action_prediction_value = (state_probs * prediction_values_for_state).sum(-1,keepdim=True) # [batch_dim,1]
            prediction_errors = at_action_prediction_value - rewards # [batch_dim,1]
            g = (prediction_errors * regret_probs) * prediction_values_for_state # [batch_dim,state_dim]
            return g, prediction_errors

        def action_fun(action_probs : Tensor, sample_probs : Tensor): # Implements the VR MC-CFR update. Could be easily adapted to train an ensemble of actors.
            # action_probs[batch_dim,action_dim]
            # sample_probs[batch_dim,action_dim]

            prediction_values_for_action = state_probs.mm(values.t()) # [batch_dim,action_dim]
            at_action_prediction_value = torch.gather(prediction_values_for_action,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            
            at_action_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_adjustment = (rewards - at_action_prediction_value).div_(at_action_sample_probs) # [batch_dim,1]
            prediction_values_for_action.scatter_add_(-1,action_indices.unsqueeze(-1),at_action_prediction_adjustment)
            reward = (action_probs * prediction_values_for_action).sum(-1,keepdim=True) # [batch_dim,1]
            # No need to center the gradients being passed into a probability vector's backward pass. Softmax for example, centers them on its own.
            def probs_grad(): return torch.neg_(prediction_values_for_action.mul_(regret_probs)) # [batch_dim,action_dim]
            return reward, probs_grad
        return state_probs_grad, action_fun
    return update_head, calculate

def model_evaluate(
        value : Module,value_head : Head,policy : Module,policy_head : Linear,
        is_update_head : bool,is_update_value : bool,is_update_policy : bool,epsilon : float,
        policy_data : Tensor,policy_mask : Tensor,value_data : Tensor,value_mask : Tensor,action_mask : Tensor
        ):
    policy_data, policy_mask, value_data, value_mask, action_mask = policy_data.cuda(), policy_mask.cuda(), value_data.cuda(), value_mask.cuda(), action_mask.cuda()
    action_probs : Tensor = normed_square(torch.masked_fill(policy_head(policy(policy_data,mask=policy_mask)[:,0]),action_mask,0.0))
    if 0 < epsilon: 
        # Interpolates action probs with an uniform noise distribution for actions that aren't masked out.
        sample_probs = action_probs.detach() * (1 - epsilon)
        action_mask_inv = torch.logical_not(action_mask)
        sample_probs += action_mask_inv / (action_mask_inv.sum(-1,keepdim=True) / epsilon)
    else:
        sample_probs = action_probs.detach()
    sample_indices = Categorical(sample_probs).sample()
    def update(rewards_and_regret_probs : Tensor):
        rewards_and_regret_probs = rewards_and_regret_probs.cuda().view(2,-1,1)
        rewards, regret_probs = rewards_and_regret_probs[0,:,:], rewards_and_regret_probs[1,:,:]
        state_probs : Tensor = normed_square(value(value_data,mask=value_mask)[:,0])
        update_head, calculate = belief_tabulate(state_probs.detach(),value_head,sample_indices,rewards,regret_probs)
        state_probs_grad, action_fun = calculate()
        reward, action_probs_grad = action_fun(action_probs.detach(),sample_probs)
        if is_update_head: update_head()
        if is_update_value: 
            g,pred_ers = state_probs_grad()
            if hasattr(value,'t'): 
                value.square_l2 += (pred_ers.square() * regret_probs).sum()
                value.t += regret_probs.sum()
            state_probs.backward(g)
        if is_update_policy:
            g = action_probs_grad()
            action_probs.backward(g)
        return reward.squeeze(-1).cpu().numpy()
    return action_probs.detach().cpu().numpy(), epsilon, sample_indices.cpu().numpy(), update