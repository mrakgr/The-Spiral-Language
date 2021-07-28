import torch
import torch.nn
from torch.nn.functional import linear

x = torch.zeros(5, 3)
t = torch.tensor([[1, 2, 3], [4, 5, 6], [7, 8, 9]], dtype=torch.float)
index = torch.tensor([0, 4, 2])
x[index] = t