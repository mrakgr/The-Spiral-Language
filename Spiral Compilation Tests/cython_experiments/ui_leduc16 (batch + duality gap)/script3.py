import torch
import torch.distributions
import torch.nn
import torch.nn.functional
import copy

def create(intro,mid,out): return torch.nn.Sequential(
    torch.nn.Linear(intro,mid),
    torch.nn.Tanh(),
    torch.nn.LayerNorm(mid),
    torch.nn.Linear(mid,out),
    )

net = create(3,3,3)
net_copy = copy.deepcopy(net)
list(net_copy.parameters())[0]
list(net.parameters())[0]
# inp = torch.rand(1,10)
# out = net.forward(inp)
# print(out)
# print(out.device)