import torch
import torch.distributions
import torch.optim
import torch.nn
import torch.linalg
from torch.functional import Tensor
from torch.nn import Module
from functools import partial
import numpy as np

def optimize(moduleList : list,learning_rate : float = 2 ** -7,signSGDfactor : float = 2 ** -3):
    """
    Interpolates between signSGD and infinity norm normalization.

    signSGDfactor - The interpolation factor for signSGD. 0 is pure infinity norm normalization, while 1 is pure signSGD.
    """
    assert (0 <= signSGDfactor <= 1)
    assert (0 <= learning_rate)
    with torch.no_grad():
        for module in moduleList:
            infNorm = torch.scalar_tensor(0)
            paramGroup = [x for x in module.parameters() if x.grad is not None]
            for x in paramGroup: infNorm = torch.max(infNorm,torch.linalg.norm(x.grad.flatten(),ord=float('inf')))
            for x in paramGroup: # The scalars operations are grouped for efficiency.
                if torch.is_nonzero(infNorm):
                    if 0 < signSGDfactor: x -= learning_rate * signSGDfactor * torch.sign(x.grad)
                    if signSGDfactor < 1: x -= learning_rate * (1 - signSGDfactor) / infNorm * x.grad
                    x.grad = None

def belief_tabulate(state_probs : Tensor,head : Tensor,action_indices : Tensor,at_action_value : Tensor,at_action_weight : Tensor):
    # state_probs[batch_dim,state_dim]
    # head[action_dim*2,state_dim]
    # action_indices[batch_dim] : map (action_dim -> batch_dim)
    # at_action_value[batch_dim,1] : map (action_dim -> batch_dim)
    # at_action_weight[batch_dim,1] : map (action_dim -> batch_dim)
    num_actions = head.shape[0]//2
    head_weighted_values = head[:num_actions,:] # [action_dim,state_dim]
    head_value_weights = head[num_actions:,:] # [action_dim,state_dim]

    # print(state_probs)
    # print(-torch.sum(state_probs * torch.log(state_probs)) / state_probs.shape[0])

    def update_head(): # Weighted moving average update. Works well with probabilistic vectors and weighted updates that CFR requires.
        state_weights = at_action_weight * state_probs # [batch_dim,state_dim]
        head_weighted_values.index_add_(0,action_indices,at_action_value * state_weights)
        head_value_weights.index_add_(0,action_indices,state_weights)

    def calculate():
        values = head_weighted_values / head_value_weights # [action_dim,state_dim]
        def state_probs_grad(): # Prediction errors modulate the state probabilities. The cool part is the centering.
            prediction_values_for_state = values[action_indices,:] # [batch_dim,state_dim]
            prediction_errors = torch.abs(at_action_value - prediction_values_for_state) # [batch_dim,state_dim]
            return at_action_weight * prediction_errors # [batch_dim,state_dim]

        def action_probs(policy_probs : Tensor, sample_probs : Tensor): # Implements the VR MC-CFR update. Could be easily adapted to train an ensemble of actors.
            # policy_probs[batch_dim,action_dim]
            # sample_probs[batch_dim,action_dim]
            prediction_values_for_action = state_probs.mm(values.t()) # [batch_dim,action_dim]
            at_action_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_value = torch.gather(prediction_values_for_action,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_adjustment = (at_action_value - at_action_prediction_value) / at_action_sample_probs # [batch_dim,1]
            prediction_values_for_action.scatter_add_(-1,action_indices.unsqueeze(-1),at_action_prediction_adjustment)
            reward = (policy_probs * prediction_values_for_action).sum(-1,keepdim=True) # [batch_dim,1]
            def grad(): return -at_action_weight * (prediction_values_for_action - reward) # [batch_dim,action_dim]
            return reward, grad
        return state_probs_grad, action_probs
    return update_head, calculate

def model_evaluate(value : Module,head : Tensor,policy : Module,is_update_head : bool,is_update_value : bool,
        is_update_policy : bool,epsilon : float,policy_data : Tensor,value_data : Tensor,action_mask : Tensor):
    action_raw = torch.masked_fill(policy(policy_data),action_mask,float('-inf'))
    action_log_probs : Tensor = torch.log_softmax(action_raw,-1)
    policy_probs = torch.exp(action_log_probs.detach())
    action_mask_inv = torch.logical_not(action_mask)
    # Interpolates action probs with an uniform noise distribution for actions that aren't masked out.
    sample_probs = policy_probs * (1 - epsilon)
    if 0 < epsilon: sample_probs += action_mask_inv / (action_mask_inv.sum(-1,keepdim=True) * (1 / epsilon)) 
    sample_indices = torch.distributions.Categorical(sample_probs).sample()
    def update(rewards : Tensor, regret_probs : Tensor):
        value_probs_ : Tensor = torch.softmax(value(value_data),-1)
        value_probs = value_probs_.detach()
        update_head, calculate = belief_tabulate(value_probs,head,sample_indices,rewards,regret_probs)
        state_probs_grad, action_probs = calculate()
        reward, action_probs_grad = action_probs(policy_probs,sample_probs)
        if is_update_head: update_head()
        if is_update_value: value_probs_.backward(state_probs_grad())
        if is_update_policy: action_log_probs.backward(action_probs_grad())
        return reward,value_probs
    return policy_probs, sample_probs, sample_indices, update

def run(vs_self,vs_one,neural,uniform_player):
    mid = 4
    batch_size = 2 ** 10
    head_decay = 0.51
    epsilon = 2 ** -2

    value = torch.nn.Linear(neural.size.value,mid)
    # with torch.no_grad():
    #     for x in value.parameters():
    #         x *= 100
    head = torch.zeros(neural.size.action*2,mid)
    head[neural.size.action:,:] = 2 ** -149 # Smallest 32-bit float.
    policy = torch.nn.Linear(neural.size.policy,neural.size.action)

    for b in range(30):
        for a in range(2):
            r : np.ndarray = vs_self(batch_size,neural.handler(partial(model_evaluate,value,head,policy,True,False,False,epsilon)))
            # if a == 2: print(r.std())
        vs_self(batch_size,neural.handler(partial(model_evaluate,value,head,policy,False,True,False,epsilon)))
        optimize([value],learning_rate=0.01,signSGDfactor=0)
        head *= head_decay
        # print(value.weight)
        # optimize([value,policy])
        # head *= head_decay
        # r : Tensor = vs_self(batch_size,neural.handler(partial(run,value,head,policy,False,False,False,epsilon)))
        # print('Value predictions for every state:')
        # print(head[:neural.size.action,:]/head[neural.size.action:,:])
        # print('The mean reward vs self is',r.mean())

        # r = vs_one(batch_size,uniform_player,neural.handler(partial(run,value,head,policy,False,False,False,epsilon)))
        # print('The mean reward vs self is',-r.mean())

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args import main
    run(**main())