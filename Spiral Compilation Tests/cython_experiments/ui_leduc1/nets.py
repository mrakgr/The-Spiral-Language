import torch
import torch.distributions
import torch.nn
import torch.nn.functional

def small(intro,mid,out): return torch.nn.Sequential(
    torch.nn.Linear(intro,mid),
    torch.nn.LayerNorm(mid),
    torch.nn.Tanh(),
    torch.nn.Linear(mid,mid),
    torch.nn.LayerNorm(mid),
    torch.nn.Tanh(),
    torch.nn.Linear(mid,out)
    )