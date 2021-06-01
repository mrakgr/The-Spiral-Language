import torch
import torch.distributions
import torch.optim
import torch.nn
from torch.functional import Tensor

o = torch.optim.SGD()
y = torch.nn.Sequential(torch.nn.Linear(4,6),torch.nn.Linear(6,2))
list(y)
list(y.parameters())

def updates(state_probs : Tensor,head : Tensor,action_indices : Tensor,at_action_value : Tensor,at_action_weights : Tensor):
    # state_probs[batch_dim,state_dim]
    # head[action_dim*2,state_dim]
    # action_indices[batch_dim] : map (action_dim -> batch_dim)
    # at_action_value[batch_dim,1] : map (action_dim -> batch_dim)
    # at_action_weight[batch_dim,1] : map (action_dim -> batch_dim)
    num_actions = head.shape[0]//2
    head_weighted_values = head[:num_actions,:] # [action_dim,state_dim]
    head_value_weights = head[num_actions:,:] # [action_dim,state_dim]

    def update_head(): # Weighted moving average update. Works well with probabilistic vectors and weighted updates that CFR requires.
        state_weights = at_action_weights * state_probs # [batch_dim,state_dim]
        head_weighted_values[action_indices,:] += at_action_value * state_weights
        head_value_weights[action_indices,:] += state_weights

    def grads():
        values = head_weighted_values / head_value_weights # [action_dim,state_dim]
        def of_state_probs(): # Prediction errors modulate the state probabilities. The cool part is the centering.
            prediction_values_for_state = values[action_indices,:] # [batch_dim,state_dim]
            prediction_errors = torch.abs(at_action_value - prediction_values_for_state) # [batch_dim,state_dim]
            prediction_error_mean = (state_probs * prediction_errors).sum(-1,keepdim=True) # [batch_dim,1]
            at_action_weights * (prediction_errors - prediction_error_mean) # [batch_dim,state_dim]

        def of_action_probs(action_probs, sample_probs): # Implements the VR MC-CFR update.
            # action_probs[batch_dim,action_dim]
            # sample_probs[batch_dim,action_dim]
            prediction_values_for_action = state_probs.mm(values.t()) # [batch_dim,action_dim]
            at_action_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_value = torch.gather(prediction_values_for_action,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_adjustmnet = (at_action_value - at_action_prediction_value) / at_action_sample_probs # [batch_dim,1]
            torch.scatter_add(prediction_values_for_action,-1,action_indices.unsqueeze(-1),at_action_prediction_adjustmnet)
            -at_action_weights * action_probs * prediction_values_for_action # [batch_dim,action_dim]
        return of_state_probs, of_action_probs
    return update_head, grads