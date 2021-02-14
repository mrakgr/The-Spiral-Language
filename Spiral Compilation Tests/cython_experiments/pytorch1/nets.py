import torch
import torch.nn
import torch.nn.functional
def small(intro,mid): return torch.nn.Sequential(
    torch.nn.Linear(intro,mid),
    torch.nn.ReLU(),
    torch.nn.LayerNorm(mid),
    torch.nn.Linear(mid,mid),
    torch.nn.Tanh(),
    torch.nn.Linear(mid,mid),
    torch.nn.Softmax(-1)
    )

