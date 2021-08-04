import torch

q = torch.rand(1,2).expand(1,3,2)
w = torch.rand(1,3,4)
torch.cat([w,q],-1)