import torch
q = torch.rand(2,3,5)
ix = torch.tensor([1,2])
q[torch.arange(q.shape[0]),ix]
