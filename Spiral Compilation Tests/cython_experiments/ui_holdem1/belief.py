from functools import partial
import torch
import torch.distributions
import torch.optim
import torch.nn
from torch.functional import Tensor
from torch.nn import Module
from torch.optim import Optimizer

class Head(torch.nn.Module):
    def __init__(self,size_action,size_state):
        super(Head, self).__init__()
        self.head = torch.nn.parameter.Parameter(torch.zeros(size_action*2,size_state),requires_grad=False)
    
    def decay(self,factor): 
        if factor != 1.0: self.head *= factor

class SignSGD(Optimizer):
    @torch.no_grad()
    def step(self):
        for gr in self.param_groups:
            for x in gr['params']:
                if not x.grad is None:
                    x -= gr['lr'] * torch.sign(x.grad)

def belief_tabulate(state_probs : Tensor,head : Tensor,action_indices : Tensor,at_action_value : Tensor,at_action_weight : Tensor):
    # state_probs[batch_dim,state_dim]
    # head[action_dim*2,state_dim]
    # action_indices[batch_dim] : map (action_dim -> batch_dim)
    # at_action_value[batch_dim,1] : map (action_dim -> batch_dim)
    # at_action_weight[batch_dim,1] : map (action_dim -> batch_dim)
    num_actions = head.shape[0]//2
    head_weighted_values = head[:num_actions,:] # [action_dim,state_dim]
    head_value_weights = head[num_actions:,:] # [action_dim,state_dim]

    def update_head(): # Weighted moving average update. Works well with probabilistic vectors and weighted updates that CFR requires.
        state_weights = at_action_weight * state_probs # [batch_dim,state_dim]
        head_weighted_values.index_add_(0,action_indices,at_action_value * state_weights)
        head_value_weights.index_add_(0,action_indices,state_weights)

    def calculate():
        values = torch.nan_to_num_(head_weighted_values / head_value_weights) # [action_dim,state_dim]
        def state_probs_grad(): # Prediction errors modulate the state probabilities.
            prediction_values_for_state = values[action_indices,:] # [batch_dim,state_dim]
            prediction_errors = torch.abs_(at_action_value - prediction_values_for_state) # [batch_dim,state_dim]
            return prediction_errors.mul_(at_action_weight) # [batch_dim,state_dim]

        def action_fun(action_probs : Tensor, sample_probs : Tensor): # Implements the VR MC-CFR update. Could be easily adapted to train an ensemble of actors.
            # policy_probs[batch_dim,action_dim]
            # sample_probs[batch_dim,action_dim]
            prediction_values_for_action = state_probs.mm(values.t()) # [batch_dim,action_dim]
            at_action_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_value = torch.gather(prediction_values_for_action,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_adjustment = (at_action_value - at_action_prediction_value).div_(at_action_sample_probs) # [batch_dim,1]
            prediction_values_for_action.scatter_add_(-1,action_indices.unsqueeze(-1),at_action_prediction_adjustment)
            reward = (action_probs * prediction_values_for_action).sum(-1,keepdim=True) # [batch_dim,1]
            # No need to center the gradients being passed into a probability vector's backward pass. Softmax for example, centers them on its own.
            def probs_grad(): return torch.neg_(prediction_values_for_action.mul_(at_action_weight)) # [batch_dim,action_dim]
            return reward, probs_grad
        return state_probs_grad, action_fun
    return update_head, calculate

def model_evaluate(value : Module,policy : Module,head : Head,is_update_head : bool,is_update_value : bool,
        is_update_policy : bool,epsilon : float,policy_data_size : Tensor,value_data : Tensor,action_mask : Tensor):
    value_data, action_mask = value_data.cuda(), action_mask.cuda()
    policy_data = value_data[:,:policy_data_size]
    action_raw = torch.masked_fill(policy(policy_data),action_mask,float('-inf'))
    action_probs : Tensor = torch.softmax(action_raw,-1)
    if 0 < epsilon: 
        # Interpolates action probs with an uniform noise distribution for actions that aren't masked out.
        sample_probs = action_probs.detach() * (1 - epsilon)
        action_mask_inv = torch.logical_not(action_mask)
        sample_probs += action_mask_inv / (action_mask_inv.sum(-1,keepdim=True) * (1 / epsilon)) 
    else:
        sample_probs = action_probs.detach()
    sample_indices = torch.distributions.Categorical(sample_probs).sample()
    def update(rewards_and_regret_probs : Tensor):
        rewards_and_regret_probs = torch.from_numpy(rewards_and_regret_probs).cuda().view(2,-1,1)
        rewards, regret_probs = rewards_and_regret_probs[0,:,:], rewards_and_regret_probs[1,:,:]
        state_probs : Tensor = torch.softmax(value(value_data),-1)
        update_head, calculate = belief_tabulate(state_probs.detach(),head.head.data,sample_indices,rewards,regret_probs)
        state_probs_grad, action_fun = calculate()
        reward, action_probs_grad = action_fun(action_probs.detach(),sample_probs)
        if is_update_head: update_head()
        if is_update_value: state_probs.backward(state_probs_grad())
        if is_update_policy: action_probs.backward(action_probs_grad())
        return reward.squeeze(-1).cpu().numpy()
    return action_probs.detach().cpu().numpy(), epsilon, sample_indices.cpu().numpy(), update