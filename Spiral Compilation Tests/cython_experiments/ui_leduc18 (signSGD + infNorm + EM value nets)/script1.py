import torch
import numpy as np

q = torch.zeros(5,5)
idx = torch.tensor([4,2]).unsqueeze(-1)
w = torch.rand(5,1)
q.scatter_add_(-1,idx,w)
q
