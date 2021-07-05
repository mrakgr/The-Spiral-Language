import torch
q = torch.rand(2)
q.grad = torch.rand_like(q)
