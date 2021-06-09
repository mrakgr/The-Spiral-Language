import pickle
import torch
import torch.distributions
import torch.optim
import torch.nn
import torch.linalg
from torch.functional import Tensor
from torch.nn import Module
from functools import partial
from collections import namedtuple
import numpy as np
from copy import deepcopy

# TODO: Take Adam and replace variance tracking with infinity norm tracking.
def optimize(moduleList : list,learning_rate : float = 2 ** -7,signSGDfactor : float = 1):
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

        def action_fun(action_probs : Tensor, sample_probs : Tensor): # Implements the VR MC-CFR update. Could be easily adapted to train an ensemble of actors.
            # policy_probs[batch_dim,action_dim]
            # sample_probs[batch_dim,action_dim]
            prediction_values_for_action = state_probs.mm(values.t()) # [batch_dim,action_dim]
            at_action_sample_probs = torch.gather(sample_probs,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_value = torch.gather(prediction_values_for_action,-1,action_indices.unsqueeze(-1)) # [batch_dim,1]
            at_action_prediction_adjustment = (at_action_value - at_action_prediction_value) / at_action_sample_probs # [batch_dim,1]
            prediction_values_for_action.scatter_add_(-1,action_indices.unsqueeze(-1),at_action_prediction_adjustment)
            reward = (action_probs * prediction_values_for_action).sum(-1,keepdim=True) # [batch_dim,1]
            # No need to center the gradients being passed into a probability vector's backward pass. Softmax for example, centers them on its own.
            def probs_grad(): return -at_action_weight * prediction_values_for_action # [batch_dim,action_dim]
            return reward, probs_grad
        return state_probs_grad, action_fun
    return update_head, calculate

def model_evaluate(value : Module,head : Tensor,policy : Module,is_update_head : bool,is_update_value : bool,
        is_update_policy : bool,epsilon : float,policy_data : Tensor,value_data : Tensor,action_mask : Tensor):
    action_raw = torch.masked_fill(policy(policy_data),action_mask,float('-inf'))
    action_probs : Tensor = torch.softmax(action_raw,-1)
    action_mask_inv = torch.logical_not(action_mask)
    # Interpolates action probs with an uniform noise distribution for actions that aren't masked out.
    sample_probs = action_probs.detach() * (1 - epsilon)
    if 0 < epsilon: sample_probs += action_mask_inv / (action_mask_inv.sum(-1,keepdim=True) * (1 / epsilon)) 
    sample_indices = torch.distributions.Categorical(sample_probs).sample()
    def update(rewards : Tensor, regret_probs : Tensor):
        state_probs : Tensor = torch.softmax(value(value_data),-1)
        update_head, calculate = belief_tabulate(state_probs.detach(),head,sample_indices,rewards,regret_probs)
        state_probs_grad, action_fun = calculate()
        reward, action_probs_grad = action_fun(action_probs.detach(),sample_probs)
        if is_update_head: update_head()
        if is_update_value: 
            x = state_probs_grad()
            # value.l2 += (state_probs.detach() * (x.square() / regret_probs)).sum() / x.numel()
            # value.l1 += (state_probs.detach() * x).sum() / x.numel()
            # value.count += 1
            state_probs.backward(x)
        if is_update_policy: action_probs.backward(action_probs_grad())
        return reward
    return action_probs, sample_probs, sample_indices, update

def neural_create_agent(size,mid=64):
    # value = torch.nn.Linear(neural.size.value,mid)
    # policy = torch.nn.Linear(neural.size.policy,neural.size.action)
    value = torch.nn.Sequential(
        torch.nn.Linear(size.value,mid),
        torch.nn.ReLU(),
        torch.nn.LayerNorm(mid),
        torch.nn.Linear(mid,mid)
        )
    # value.l2 = torch.zeros(())
    # value.l1 = torch.zeros(())
    # value.count = torch.zeros(())
    policy = torch.nn.Sequential(
        torch.nn.Linear(size.policy,mid),
        torch.nn.ReLU(),
        torch.nn.LayerNorm(mid),
        torch.nn.Linear(mid,size.action)
        )
    head = torch.zeros(size.action*2,mid)
    head[size.action:,:] = 2 ** -149 # Smallest 32-bit float.
    return value, policy, head

def run(vs_self,vs_one,neural,uniform_player,tabular):
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    # value, policy, head = neural_create_agent(neural.size)
    # def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=2 ** -2): 
    #     return neural.handler(partial(model_evaluate,value,head,policy,is_update_head,is_update_value,is_update_policy,epsilon))

    tabular_agent = tabular.create_agent()
    tabular_avg_agent = tabular.create_agent()
    def tabular_player(is_update_head=False,is_update_policy=False,epsilon=2 ** -2,tabular_agent=tabular_agent): 
        return tabular.create_policy(tabular_agent,is_update_head,is_update_policy,epsilon)

    def run(tabular_agent,tabular_avg_agent=None):
        for a in range(3):
            vs_self(batch_size,tabular_player(True,tabular_agent=tabular_agent))
        vs_self(batch_size,tabular_player(False,True,tabular_agent=tabular_agent))
        tabular.optimize(tabular_agent)
        if tabular_avg_agent is not None: tabular.average(tabular_avg_agent,tabular_agent)
        tabular.head_multiply_(tabular_agent,head_decay)

    n = 300
    m = 10
    print('Training.')
    for a in range(n): 
        run(tabular_agent)
        if a % 10 == 0: print(a)
    for b in range(m):
        print('Averaging.')
        for a in range(n // (2 * m)): run(tabular_agent,tabular_avg_agent)
        with open(f"dump/agent_{n + b * n // (2 * m)}.obj",'wb') as f:
            pickle.dump({'average': tabular_avg_agent, 'current': tabular_agent},f)
        r : np.ndarray = vs_self(batch_size * 2 ** 5,tabular_player(tabular_agent=tabular_avg_agent,epsilon=0.0))
        print(f'The mean reward vs_self is {r.mean()}')

    # for b in range(30):
    #     for a in range(3):
    #         vs_one(batch_size,uniform_player,tabular_player(True))
    #     vs_one(batch_size,uniform_player,tabular_player(False,True))
    #     tabular.optimize(tabular_agent)
    #     tabular.head_multiply_(tabular_agent,head_decay)

    #     r : np.ndarray = vs_one(batch_size,uniform_player,tabular_player(epsilon=0.0))
    #     print(f'The mean reward vs_one is {r.mean()}')

    # for b in range(30):
    #     for a in range(3):
    #         vs_self(batch_size,tabular_player(True))
    #     vs_self(batch_size,tabular_player(False,True))
    #     tabular.head_multiply_(tabular_agent,head_decay)

    #     r : np.ndarray = vs_one(batch_size,uniform_player,tabular_player(epsilon=0.0))
    #     print(f'The mean reward vs_one is {r.mean()}')

    # for c in range(10):
    #     for b in range(50):
    #         for a in range(3):
    #             vs_self(batch_size,tabular_player(True))
    #             vs_self(batch_size,neural_player(True))
    #             # vs_one(batch_size,uniform_player,neural_player(True,False,False))
    #         vs_self(batch_size,tabular_player(False,True))
    #         tabular.head_multiply_(tabular_agent,head_decay)

    #         # vs_one(batch_size,uniform_player,neural_player(False,True,True))
    #         vs_self(batch_size,neural_player(False,True,True))
    #         optimize([value],learning_rate=2 ** -6)
    #         optimize([policy],learning_rate=2 ** -8)
    #         head *= head_decay

    #     # r : np.ndarray = vs_one(batch_size * 32,uniform_player,neural_player(epsilon=0.0))
    #     # r : np.ndarray = vs_one(batch_size * 32,neural_player(epsilon=0.0),uniform_player)
    #     r : np.ndarray = vs_one(batch_size * 32,neural_player(epsilon=0.0),tabular_player(epsilon=0.0))
    #     print(f'The mean reward vs_one is {r.mean()}')

    # valuet, policyt, headt = neural_create_agent(neural.size)
    # for c in range(5):
    #     value, policy, head = deepcopy(valuet), deepcopy(policyt), deepcopy(headt)
    #     def neural_player(is_update_head,is_update_value,is_update_policy): 
    #         return neural.handler(partial(model_evaluate,value,head,policy,is_update_head,is_update_value,is_update_policy,epsilon))
    #     for b in range(30):
    #         for a in range(3):
    #             q : np.ndarray = vs_self(batch_size,neural_player(True,False,False))
    #         # print(f'Standard deviation of rewards is {q.std()}')
    #         vs_self(batch_size,neural_player(False,True,True))
    #         optimize([value],learning_rate=2 ** -6)
    #         optimize([policy],learning_rate=2 ** -9)
    #         head *= head_decay
    #         print(f'The value errors l2 and l1 are {value.l2 / value.count} and {value.l1 / value.count}')

    #         # r : Tensor = vs_self(batch_size,neural_player(False,False,False))
    #         # print(f'The mean reward vs self is {r.mean()}')

    #         # r = vs_one(batch_size,uniform_player,neural_player(False,False,False))
    #         # print(f'The mean reward vs uniform {-r.mean()}')
    #     print('---')
    # print('***')

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args import main
    run(**main())