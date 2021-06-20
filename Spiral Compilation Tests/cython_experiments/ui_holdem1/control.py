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
        values = torch.nan_to_num_(head_weighted_values / head_value_weights) # [action_dim,state_dim]
        def state_probs_grad(): # Prediction errors modulate the state probabilities.
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
    # Interpolates action probs with an uniform noise distribution for actions that aren't masked out.
    sample_probs = action_probs.detach() * (1 - epsilon)
    if 0 < epsilon: 
        action_mask_inv = torch.logical_not(action_mask)
        sample_probs += action_mask_inv / (action_mask_inv.sum(-1,keepdim=True) * (1 / epsilon)) 
    sample_indices = torch.distributions.Categorical(sample_probs).sample()
    def update(rewards : Tensor, regret_probs : Tensor):
        state_probs : Tensor = torch.softmax(value(value_data),-1)
        update_head, calculate = belief_tabulate(state_probs.detach(),head,sample_indices,rewards,regret_probs)
        state_probs_grad, action_fun = calculate()
        reward, action_probs_grad = action_fun(action_probs.detach(),sample_probs)
        if is_update_head: update_head()
        if is_update_value: state_probs.backward(state_probs_grad())
        if is_update_policy: action_probs.backward(action_probs_grad())
        return reward
    return action_probs, sample_probs, sample_indices, update

def neural_create_model(size,mid=64):
    value = torch.nn.Sequential(
        torch.nn.Linear(size.value,mid),
        torch.nn.ReLU(inplace=True),
        torch.nn.LayerNorm(mid,elementwise_affine=False),
        torch.nn.Linear(mid,mid)
        )
    policy = torch.nn.Sequential(
        torch.nn.Linear(size.policy,mid),
        torch.nn.ReLU(inplace=True),
        torch.nn.LayerNorm(mid,elementwise_affine=False),
        torch.nn.Linear(mid,size.action)
        )
    head = torch.zeros(size.action*2,mid)
    return value, policy, head

def run(i_tabular,i_nn,vs_self,vs_one,neural,uniform_player,tabular): # old NN vs old tabular
    batch_size = 2 ** 10
    with open(f'dump/agent_{i_tabular}_avg.obj','rb') as f: tabular_agent_old = pickle.load(f)

    def r(name,value,policy,head):
        def tabular_player(is_update_head=False,is_update_policy=False,epsilon=0,tabular_agent=tabular_agent_old): 
            return tabular.create_policy(tabular_agent,is_update_head,is_update_policy,epsilon)

        def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=0.0): 
            return neural.handler(partial(model_evaluate,value,head,policy,is_update_head,is_update_value,is_update_policy,epsilon))

        r : np.ndarray = vs_one(batch_size * 2 ** 8,neural_player(),tabular_player())
        print(f'The mean is {r.mean()} for the {name} player.')
    with open(f'dump/nn_agent_{i_nn}.obj','rb') as f: r('regular',*pickle.load(f))
    with open(f'dump/nn_agent_{i_nn}_avg.obj','rb') as f: r('average',*pickle.load(f))

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player): # self play NN
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    value, policy, head = neural_create_model(neural.size)
    valuea, policya, heada = deepcopy(value), deepcopy(policy), deepcopy(head)
    t = 1
    def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=2 ** -2): 
        return neural.handler(partial(model_evaluate,value,head,policy,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(policy_lr,is_avg=False):
        nonlocal head,heada,t 
        for a in range(3):
            vs_self(batch_size,neural_player(True,False,False,2 ** -2))
        vs_self(batch_size,neural_player(False,True,True,2 ** -2))
        optimize([value],learning_rate=2 ** -6)
        optimize([policy],learning_rate=policy_lr)
        head *= head_decay

        if is_avg:
            with torch.no_grad():
                def avg(ap,bp):
                    ap *= (t-1) / t
                    ap += 1 / t * bp
                for am,bm in zip((valuea, policya), (value, policy)):
                    for ap,bp in zip(am.parameters(),bm.parameters()):
                        avg(ap,bp)
                avg(heada,head)
                t += 1

    def train(policy_lr,n):
        print('Training the NN agent.')
        for a in range(n):
            run(policy_lr=policy_lr)
            if (a + 1) % 25 == 0: print(a+1)
    def avg(policy_lr,m):
        print('Averaging the NN agent.')
        for a in range(m):
            run(policy_lr,True)
            if (a + 1) % 25 == 0: 
                print(a+1)
                # r : np.ndarray = vs_self(batch_size * 2 ** 4,neural_player())
                # print(f'The mean reward vs_self is {r.mean()}')
    train(2 ** -8,n)
    avg(2 ** -8,m)
    with open(f"dump/nn_agent_{n+m}.obj",'wb') as f: pickle.dump((value,policy,head),f)
    with open(f"dump/nn_agent_{n+m}_avg.obj",'wb') as f: pickle.dump((valuea,policya,heada),f)
    avg(2 ** -8,m)
    with open(f"dump/nn_agent_{n+2*m}.obj",'wb') as f: pickle.dump((value,policy,head),f)
    with open(f"dump/nn_agent_{n+2*m}_avg.obj",'wb') as f: pickle.dump((valuea,policya,heada),f)
    avg(2 ** -8,m)
    with open(f"dump/nn_agent_{n+3*m}.obj",'wb') as f: pickle.dump((value,policy,head),f)
    with open(f"dump/nn_agent_{n+3*m}_avg.obj",'wb') as f: pickle.dump((valuea,policya,heada),f)

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args import main
    args = main()
    # n,m=600,303
    # for _ in range(5):
    #     # create_tabular_agent(n//2,m//2,**args)
    #     create_nn_agent(n,m,**args)
    #     run(451,n+m,**args)
    #     run(451,n+2*m,**args)
    #     run(451,n+3*m,**args)
    #     print("----")