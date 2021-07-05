import torch
import torch.optim
q = torch.rand(2)
opt = torch.optim.SGD([q],lr=1.0)

q.grad = torch.tensor([1,2],dtype=torch.float)
opt.step()
q.grad
opt.zero_grad(True)

