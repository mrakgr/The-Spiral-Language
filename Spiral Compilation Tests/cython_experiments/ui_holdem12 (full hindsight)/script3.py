import torch

q = torch.rand(2,5)
w = torch.tensor([0.2,0.8])
def norm(x): 
    return x / x.sum(-1,keepdim=True)
torch.einsum('ab,a->b',norm(q),w) == norm(torch.einsum('ab,a->b',q,w))

