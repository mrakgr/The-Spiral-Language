import torch
y = torch.scalar_tensor(0.0)
x = torch.scalar_tensor(1.0,requires_grad=True)
r = torch.square (y - x) * -0.5 if y > x else
r.backward(torch.scalar_tensor(1.0))
x.grad