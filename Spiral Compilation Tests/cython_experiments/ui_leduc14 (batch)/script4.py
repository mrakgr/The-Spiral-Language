import torch
import torch.functional
import torch.nn
import torch.nn.functional
import torch.distributions
import numpy as np



# a = torch.rand((4,5),requires_grad=True)
# b = torch.rand(4,5)
# q = torch.sum(a*b,1)
# a - q.unsqueeze(-1)
# q.unsqueeze(0).shape

# a = torch.zeros(4,5)
# b = torch.ones(4,5)
# ix = torch.tensor([[1,2],[2,3]])
# a.scatter_(1,ix,b)
# print(a)

# a = torch.rand(4,5)
# ix = torch.tensor([0,1]).unsqueeze(-1)
# print(a,torch.gather(a,1,ix))

a = torch.ones(3,4)
b = torch.full((3,4),5,dtype=torch.float32)

torch.einsum("ab,ab->a",a,b)