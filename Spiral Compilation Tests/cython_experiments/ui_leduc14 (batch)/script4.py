import torch
import torch.optim
import torch.functional
import torch.nn
import torch.nn.functional
import torch.distributions
import numpy as np
import torch._C
import nets


q = torch.rand((3,3),requires_grad=True)

x = torch.softmax(q)