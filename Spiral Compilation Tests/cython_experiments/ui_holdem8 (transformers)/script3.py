import torch

q = torch.eye(3)
torch.einsum('ab,ab->ab',q,q)