import torch
import torch.nn
q = torch.nn.Linear(5,5)
torch.empty((5,5)).bernoulli_(0.3) / 0.3