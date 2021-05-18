import torch
import torch.functional
import torch.nn
import torch.nn.functional

s1 = torch.tensor([1,1],torch.float32)
s2 = torch.tensor([2,2],torch.float32)
y = torch.scalar_tensor(0,dtype=torch.float32)
w = torch.scalar_tensor(2,dtype=torch.float32)
def F(s): w * s[0] * s[1]
def E(s): -F(s)
def C(s): torch.abs(F(s) - y)

r = E(s1) + C(s2)