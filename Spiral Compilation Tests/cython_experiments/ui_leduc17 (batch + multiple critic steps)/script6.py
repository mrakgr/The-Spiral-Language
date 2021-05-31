import torch
import torch.functional
import torch.nn
import torch.nn.functional

a = torch.tensor([0,1],requires_grad=True,dtype=torch.float32)
x = torch.nn.functional.softmax(a,dim=-1)
torch.log(x).backward(torch.tensor([1,1],dtype=torch.float32))
# x.backward(x * torch.tensor([1,1],dtype=torch.float32))
a.grad