import torch
import torch.optim
import torch.functional
import torch.nn
import torch.nn.functional
import torch.distributions
import numpy as np

import nets

net = nets.small(4,5,6)

opt = torch.optim.SGD([{'params' : net.parameters()}],lr=2 ** -8)
opt.zero_grad()
opt.step()

