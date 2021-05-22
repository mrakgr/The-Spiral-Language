import torch
import torch.functional
import torch.nn
import torch.nn.functional
import torch.distributions
import numpy as np

a = torch.rand(4,5)
ix = torch.tensor([0,1]).unsqueeze(-1)
print(a,torch.gather(a,1,ix))
# ix = np.array([[0],[0],[0],[0]])
# a
# ix.shape
# np.take_along_axis(a,ix,1)