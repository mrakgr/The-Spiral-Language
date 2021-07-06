import torch
from torch.distributions import Categorical
from torch.nn.parameter import Parameter
import torch.optim
import torch.nn
from torch.functional import Tensor
from torch.nn import Module
from torch.optim import Optimizer

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

class Head(torch.nn.Module):
    def __init__(self,size_state,size_action):
        super(Head, self).__init__()
        self.weighted_values = Parameter(torch.zeros(size_action,size_state),requires_grad=False)
        self.weights = Parameter(torch.zeros(size_action,size_state),requires_grad=False)

    def values(self): return torch.nan_to_num_(self.weighted_values / self.weights)

def inf_cube(x : Tensor): 
    o = x ** 3
    return o / o.norm(p=float('inf'),dim=-1,keepdim=True)
def normed_abs_cube(x : Tensor):
    o = (x ** 3).abs()
    return o / o.sum(dim=-1,keepdim=True)
def normed_square(x : Tensor):
    o = x.square()
    return o / o.sum(dim=-1,keepdim=True)
def normed_square_(x : Tensor):
    x.square_()
    return x.div_(x.sum(dim=-1,keepdim=True))

class InfCube(torch.nn.Linear):
    def forward(self,x): return inf_cube(super().forward(x))

class ResInfCube(InfCube):
    def __init__(self,size): super().__init__(size,size)
    def forward(self,x): return super().forward(x) + x

class DenseInfCube(torch.nn.Linear):
    def forward(self,x): return torch.cat((inf_cube(x),x),1)

def belief_tabulate(state_probs : Tensor,head : Head,action_indices : Tensor,rewards : Tensor,regret_probs : Tensor):
    # state_probs[batch_dim,state_dim]
    # head[action_dim*2,state_dim]
    # action_indices[batch_dim] : map (action_dim -> batch_dim)
    # rewards[batch_dim,1]
    # regret_probs[batch_dim,1]
    
    def update_head(): # Weighted moving average update. Works well with probabilistic vectors and weighted updates that CFR requires.
        state_weights = regret_probs * state_probs # [batch_dim,state_dim]
        head.weighted_values.index_add_(0,action_indices,rewards * state_weights)
        head.weights.index_add_(0,action_indices,state_weights)

    def calculate(action_probs : Tensor, sample_probs : Tensor): # Implements the VR MC-CFR update.
        # action_probs[batch_dim,action_dim]
        # sample_probs[batch_dim,action_dim]
        prediction_values_for_action = state_probs.mm(head.values.t()) # [batch_dim,action_dim]
        at_action_prediction_value = torch.gather(prediction_values_for_action,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
        
        at_action_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
        at_action_prediction_adjustment = (rewards - at_action_prediction_value).div_(at_action_sample_probs) # [batch_dim,1]
        prediction_values_for_action.scatter_add_(-1,action_indices.unsqueeze(-1),at_action_prediction_adjustment)
        reward = (action_probs * prediction_values_for_action).sum(-1,keepdim=True) # [batch_dim,1]
        # `x / x.sum()` centers the gradients on its own, so there is no need to do so here before passing them into the actor.
        def probs_grad(): return torch.neg_(prediction_values_for_action.mul_(regret_probs)) # [batch_dim,action_dim]
        return reward, probs_grad
    return update_head, calculate

def model_evaluate(
        present_rep : Module,future_rep : Module,action_pred : Module,actor : Module,critic : Head,avg_actor : Module or None,
        is_update_pred : bool, is_update_critic : bool,is_update_actor : bool,
        present_data : Tensor,action_mask : Tensor):
    present_basis, action_mask = present_rep(present_data.cuda()), action_mask.cuda()
    action_probs : Tensor = normed_square(actor(present_basis.detach()).masked_fill(action_mask,0.0))
    sample_probs : Tensor = action_probs if avg_actor is None else normed_square_(avg_actor(present_basis.detach()).masked_fill_(action_mask,0.0))
    sample_indices = Categorical(sample_probs).sample()
    def update(data : Tensor):
        data = data.cuda()
        l = present_basis.shape[0]
        rewards, regret_probs, future_data = data[:l].unsqueeze(-1), data[l:l+l].unsqueeze(-1), data[l+l:].view(l,-1)

        update_head, calculate = belief_tabulate(present_basis.detach(),critic,sample_indices,rewards,regret_probs)
        reward, action_probs_grad = calculate(action_probs.detach(),sample_probs.detach())
        if is_update_critic: update_head()
        if is_update_actor: action_probs.backward(action_probs_grad())
        if is_update_pred: 
            future_basis = future_rep(torch.cat((present_basis,future_data),-1))
            predicted_actions = normed_square(action_pred(present_basis + future_basis).masked_fill(action_mask,0.0))
            Categorical(predicted_actions).log_prob(sample_indices).backward()
        return reward.squeeze(-1).cpu().numpy()
    return action_probs.detach().cpu().numpy(), (None if avg_actor is None else sample_probs.detach().cpu().numpy()), sample_indices.cpu().numpy(), update