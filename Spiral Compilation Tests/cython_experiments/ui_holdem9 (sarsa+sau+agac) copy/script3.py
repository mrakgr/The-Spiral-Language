import torch
from torch.functional import Tensor

def catch_grad(x : Tensor,f):
    x = x.detach().requires_grad_()
    y : Tensor = f(x)
    def bck(b : Tensor) -> Tensor: y.backward(b); return x.grad
    return y, bck

q = torch.rand(9,requires_grad=True)
a,b,c = q.chunk(3)

y,bck = catch_grad(a,lambda x: x)
r = bck(torch.tensor([1.0,2.0,3.0]))

q.grad