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
from torch.optim.swa_utils import AveragedModel
from belief import SignSGD,Head,model_evaluate

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
    head = Head(size.action,mid)
    return value, policy, head

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player): # self play NN
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    value, policy, head = neural_create_model(neural.size)
    opt : torch.optim.Optimizer = SignSGD([
        {'params': value.parameters(), 'lr': 2 ** -6},
        {'params': policy.parameters()}
        ],{'lr': 2 ** -8})
    valuea, policya, heada = AveragedModel(value), AveragedModel(policy), AveragedModel(head)
    t = 1
    def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=2 ** -2): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(is_avg=False):
        nonlocal head,heada,t 
        vs_self(batch_size,neural_player(True,True,True,2 ** -2))
        opt.step()
        opt.zero_grad(True)
        head *= head_decay

        if is_avg:
            valuea.update_parameters(value)
            policya.update_parameters(policy)
            heada.update_parameters(head)

    def train(n):
        print('Training the NN agent.')
        for a in range(n):
            run()
            if (a + 1) % 25 == 0: print(a+1)
    def avg(m):
        print('Averaging the NN agent.')
        for a in range(m):
            run(True)
            if (a + 1) % 25 == 0: 
                print(a+1)
                # r : np.ndarray = vs_self(batch_size * 2 ** 4,neural_player())
                # print(f'The mean reward vs_self is {r.mean()}')
    train(n)
    avg(m)
    with open(f"dump/nn_agent_{n+m}.nnreg",'wb') as f: pickle.dump((value,policy,head),f)
    with open(f"dump/nn_agent_{n+m}.nnavg",'wb') as f: pickle.dump((valuea,policya,heada),f)

if __name__ == '__main__':
    import numpy as np
    import pyximport
    pyximport.install(language_level=3,setup_args={"include_dirs":np.get_include()})
    from create_args import main
    args = main()['train']
    n,m=1,1
    create_nn_agent(n,m,**args)
    # for _ in range(5):
    #     # create_tabular_agent(n//2,m//2,**args)
    #     run(451,n+m,**args)
    #     run(451,n+2*m,**args)
    #     run(451,n+3*m,**args)
    #     print("----")