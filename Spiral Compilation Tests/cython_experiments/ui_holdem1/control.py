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
from belief import signSGD,model_evaluate

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

def create_nn_agent(n,m,vs_self,vs_one,neural,uniform_player): # self play NN
    batch_size = 2 ** 10
    head_decay = 2 ** -2

    value, policy, head = neural_create_model(neural.size)
    valuea, policya, heada = deepcopy(value), deepcopy(policy), deepcopy(head)
    t = 1
    def neural_player(is_update_head=False,is_update_value=False,is_update_policy=False,epsilon=2 ** -2): 
        return neural.handler(partial(model_evaluate,value,policy,head,is_update_head,is_update_value,is_update_policy,epsilon))

    def run(policy_lr,is_avg=False):
        nonlocal head,heada,t 
        for a in range(3):
            vs_self(batch_size,neural_player(True,False,False,2 ** -2))
        vs_self(batch_size,neural_player(False,True,True,2 ** -2))
        signSGD([value],learning_rate=2 ** -6)
        signSGD([policy],learning_rate=policy_lr)
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