import torch
import torch.distributions
from torch.functional import Tensor

q = torch.rand(5,5)
torch.scatter_add(q,-1,torch.tensor([1,2,3]).unsqueeze(-1),torch.tensor([1,1,1],dtype=torch.float).unsqueeze(-1))

torch.gather(q,-1,torch.tensor([1,2,3]).unsqueeze(-1))

q
x

def updates(state_probs : Tensor,head : Tensor,action_indices : Tensor,action_values : Tensor,action_weights : Tensor):
    # state_probs[batch_dim,state_dim]
    # head[action_dim*2,state_dim]
    # action_indices[batch_dim] : map (action_dim -> batch_dim)
    # action_values[batch_dim,1] : map (action_dim -> batch_dim)
    # action_weights[batch_dim,1] : map (action_dim -> batch_dim)
    num_actions = head.shape[0]//2
    head_weighted_values = head[:num_actions,:] # [action_dim,state_dim]
    head_value_weights = head[num_actions:,:] # [action_dim,state_dim]
    def update_head(): # Weighted moving average update.
        state_action_weights = state_probs * action_weights # [batch_dim,state_dim]
        head_weighted_values[action_indices,:] += action_values * state_action_weights
        head_value_weights[action_indices,:] += state_action_weights

    def grad_state_probs(): # Prediction errors modulate the state probabilities.
        prediction_values = (head_weighted_values / head_value_weights)[action_indices,:] if head_weighted_values.shape[0] <= action_indices.shape[0] else head_weighted_values[action_indices,:] / head_value_weights[action_indices,:] # [batch_dim,state_dim]
        prediction_errors = torch.abs(action_values - prediction_values) # [batch_dim,state_dim]
        prediction_error_mean = (state_probs * prediction_errors).sum(-1,keepdim=True) # [batch_dim,1]
        state_probs.backward(prediction_errors - prediction_error_mean)

    def grad_action_probs(action_probs, sample_probs):
        # action_probs[batch_dim,action_dim]
        # sample_probs[batch_dim,action_dim]
        values = head_weighted_values / head_value_weights # [action_dim,state_dim]
        prediction_values = values[action_indices,:] # [batch_dim,state_dim]
        prediction_state_values = (state_probs * prediction_values).sum(-1,keepdim=True) # [batch_dim,1]
        prediction_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
        prediction_current_action_adjustments = (action_values - prediction_state_values) / prediction_sample_probs # [batch_dim,1]
        torch.scatter_add((),-1,action_indices.unsqueeze(-1),prediction_current_action_adjustments) # TODO
        pass

    pass