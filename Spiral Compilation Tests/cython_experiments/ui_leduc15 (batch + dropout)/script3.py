import torch
import torch.distributions
import torch.nn
import torch.nn.functional

def create(intro,mid,out): return torch.nn.Sequential(
    torch.nn.Linear(intro,mid),
    torch.nn.Tanh(),
    torch.nn.LayerNorm(mid),
    torch.nn.Linear(mid,out),
    )

net = create(10,20,5)
inp = torch.rand(1,10)
out = net.forward(inp)
print(out)
print(out.device)