import torch
import torch.distributions
import torch.nn
import torch.nn.functional
import numpy as np

a = np.array([2,1,0],dtype=np.uint64)
b = torch.tensor([123,234,456])
c = b[a]
c