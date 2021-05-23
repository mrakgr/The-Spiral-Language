import torch
import torch.functional
import torch.nn
import torch.nn.functional
import torch.distributions
import numpy as np

a = torch.zeros(4,5)
b = torch.ones(4,5)
ix = torch.tensor([[1,2],[2,3]])
a.scatter_(1,ix,b)
print(a)

# a = torch.rand(4,5)
# ix = torch.tensor([0,1]).unsqueeze(-1)
# print(a,torch.gather(a,1,ix))