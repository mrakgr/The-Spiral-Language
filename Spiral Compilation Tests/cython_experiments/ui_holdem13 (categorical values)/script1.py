import torch

q = torch.rand(3,4,5)
w = torch.rand(5,1)
(q @ w).squeeze(-1)