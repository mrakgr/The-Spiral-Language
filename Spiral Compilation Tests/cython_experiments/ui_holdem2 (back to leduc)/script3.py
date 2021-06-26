import torch
from torch.nn.functional import softsign,tanh

q = torch.rand(3,5)
w = torch.rand(3,5)
torch.stack((q,w),1).reshape(3,-1)