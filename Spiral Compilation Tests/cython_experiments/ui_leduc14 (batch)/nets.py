import torch
import torch.distributions
import torch.nn
import torch.nn.functional

# def small(intro,mid,out): return torch.nn.Sequential(
#     torch.nn.Linear(intro,mid),
#     torch.nn.ReLU(),
#     torch.nn.LayerNorm(mid),
#     torch.nn.Linear(mid,out)
#     )

def small(intro,mid,out): return torch.nn.Sequential(
    torch.nn.Linear(intro,out)
    )