import torch
import torch.functional
import torch.nn
import torch.nn.functional

a = torch.tensor([-1,0,1],requires_grad=True,dtype=torch.float32)
zero = torch.full_like(a,float('-inf'))
idx = [1,2]
zero[idx] = a[idx]
b = torch.nn.functional.softmax(zero,dim=-1)
grad = torch.tensor([1,0,1],dtype=torch.float32)
b.backward(grad)
print(b)
print(a.grad)

