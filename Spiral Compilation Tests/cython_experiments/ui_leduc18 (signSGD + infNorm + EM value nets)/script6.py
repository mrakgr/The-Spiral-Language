import torch
import torch.functional
import torch.nn
import torch.nn.functional
import torch.linalg

a = torch.tensor([1,-2,3],requires_grad=True,dtype=torch.float32)
torch.linalg.norm(a,float('inf'))
