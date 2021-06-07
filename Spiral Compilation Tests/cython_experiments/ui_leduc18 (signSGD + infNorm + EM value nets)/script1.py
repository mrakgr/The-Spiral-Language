import torch
import torch.nn
import torch.nn.functional
x = torch.scalar_tensor(-20.0,requires_grad=True)
o = torch.scalar_tensor(0.0)
torch.nn.functional.binary_cross_entropy(torch.sigmoid(x),o).backward()
x, x.grad