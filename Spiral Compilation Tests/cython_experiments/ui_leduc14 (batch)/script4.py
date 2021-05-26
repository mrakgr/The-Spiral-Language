import torch
import torch.nn
import torch.nn.functional
w = torch.nn.Linear(3,4)
q = torch.rand((3,3),requires_grad=True)
x = torch.softmax(q,dim=-1)
print(torch.nn.functional.softmax.forward)