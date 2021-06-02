import torch
import torch.distributions
import torch.optim
import torch.nn
from torch.functional import Tensor

x = torch.nn.Sequential(torch.nn.Linear(3,5),torch.nn.Linear(5,2))
