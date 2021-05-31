import torch
import torch.functional
import torch.nn
import torch.nn.functional

s1 = torch.tensor([1,1],dtype=torch.float32)
s2 = torch.tensor([2,2],dtype=torch.float32)
w = torch.scalar_tensor(2,dtype=torch.float32,requires_grad=True)
def E(s): return -w * s[0] * s[1]

r = E(s1) - E(s2)
r.backward()
print(w.grad)