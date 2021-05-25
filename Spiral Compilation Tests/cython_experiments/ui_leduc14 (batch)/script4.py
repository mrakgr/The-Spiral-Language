import torch
import torch.optim
import torch.functional
import torch.nn
import torch.nn.functional
import torch.distributions
import numpy as np
import nets

net = nets.small(4,5,6)
opt = torch.optim.SGD([{'params' : net.parameters()}],lr=2 ** -3)
opt.zero_grad()
x = torch.rand((1,4),requires_grad=True)
y : torch.Tensor = net.forward(x)
signal = torch.tensor([[1,2,3,4,5,6]],dtype=torch.float32)
y.backward(signal)
print(net[0].bias.grad)

opt.step()

