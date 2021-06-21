import torch
import torch.nn
from torch.optim import Optimizer
from torch.optim.swa_utils import AveragedModel

class Head(torch.nn.Module):
    def __init__(self,size_action,size_state):
        super(Head, self).__init__()
        self.head = torch.nn.parameter.Parameter(torch.zeros(size_action*2,size_state),requires_grad=False)

class signSGD(Optimizer):
    @torch.no_grad()
    def step(self):
        for gr in self.param_groups:
            for x in gr['params']:
                if not x.grad is None:
                    x -= gr['lr'] * torch.sign(x.grad)

q = torch.nn.Linear(1,2,bias=False)
w = torch.nn.Linear(1,2,bias=False)
opt = signSGD([
    {'params': q.parameters(), 'lr': 0.01},
    {'params': w.parameters()}
    ],{'lr': 0.1})
opt.step()

q.weight.backward(torch.tensor([1,2],dtype=torch.float).reshape(2,1))
w = AveragedModel(q)
opt.step()
w.update_parameters(q)
print(q.weight)
print(w.module.weight)
