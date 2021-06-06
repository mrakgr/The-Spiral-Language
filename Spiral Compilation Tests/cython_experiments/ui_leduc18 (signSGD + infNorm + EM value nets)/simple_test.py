# I made this test during the initial debugging. I allowed me to figure out that I messed up the sign in the optimizer, and softmax
# works a lot better than log softmax.
# For this to work, model_evaluate's update needs to be modified so it returns the state probabilities.

import torch
import torch.nn
import torch.linalg
import numpy as np
import control

size_value = 4
size_policy = 4
size_state = 128
size_action = 1

value = torch.nn.Linear(size_value,size_state,bias=False)
# with torch.no_grad():
#     value.weight /= 2
#     for i in range(size_state): value.weight[i,i] += 1
head = torch.zeros(size_action*2,size_state)
head[size_action:,:] = 2 ** -149
policy = torch.nn.Linear(size_policy,size_action,bias=False)

input = torch.tensor([[1,0,0,0],[0,1,0,0],[0,0,1,0],[0,0,0,1]],dtype=torch.float)
action_mask = torch.tensor([[False],[False],[False],[False]])

rewards = torch.tensor([1,10,100,1000],dtype=torch.float).unsqueeze(-1)
regret_probs = torch.tensor([1000,100,10,1],dtype=torch.float).unsqueeze(-1)

def run(is_update_head : bool,is_update_value : bool,is_update_policy : bool):
    policy_probs, sample_probs, sample_indices, update = control.model_evaluate(value,head,policy,is_update_head,is_update_value,is_update_policy,0,input,input,action_mask)
    reward, state_probs = update(rewards,regret_probs)
    return state_probs

def loop(n):
    for b in range(n):
        probs = run(True,False,False)
        probs = run(True,False,False)
        # print('head:',head)
        probs = run(False,True,False)
        # print('probs',probs)
        # print('-value.weight.grad',-value.weight.grad)
        control.optimize([value],learning_rate=0.01,signSGDfactor=1) # signSGD works a lot better than infinity norm when the amount of params is large.
        head[:,:] *= 0.01
    probs = run(True,False,False)
    # print(probs.sum(0))
    print(probs.mm((head[:size_action,:] / head[size_action:,:]).t()))
torch.set_printoptions(sci_mode=False)
loop(50)
loop(100)
loop(300)
loop(1000)