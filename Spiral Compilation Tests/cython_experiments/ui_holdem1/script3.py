import torch
import torch.nn
from torch.optim.swa_utils import AveragedModel

a = torch.nn.Linear(2,2,False)
b = AveragedModel(a)
b.requires_grad_(False)
a.weight.requires_grad
b.module.weight.requires_grad