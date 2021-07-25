import torch
from torch.functional import Tensor

def is_prob_dist(x : Tensor,dim=-1) -> bool: 
    return torch.all(x >= 0).logical_and(torch.all(torch.abs(1.0 - x.sum(dim)) <= 1e-6)).item()

class ArithCatTensor:
    def __init__(self,min,max,probs : Tensor):
        assert 2 <= probs.shape[-1], "The number of supports should at least be 2."
        assert min < max, "Min should be less than max."
        assert is_prob_dist(probs), "The input tensor should be a probability vector for all the inputs in the last dimension."
        self.min = min
        self.max = max
        self.probs = probs

    @property
    def support(self):
        """
        The support for the probability vector.
        """
        x = torch.linspace(self.min,self.max,self.n,dtype=self.probs.dtype,device=self.probs.device)
        db,da = self.probs.shape
        return x.repeat(db,1)

    def bins(self,tz : Tensor):
        gap = (self.max - self.min) / (self.probs.shape[-1] - 1)
        b : Tensor = (tz - self.min) / gap
        return torch.floor(b), b, torch.ceil(b)

    def add_mult(self,y : Tensor or float,r : Tensor or float):
        """
        Calculates `probs*y+r` indirectly by distributing the probabilities along the support.
        """
        l,b,u = self.bins((self.support*y + r).clamp(self.min,self.max))
        m = torch.zeros_like(b)
        credit = b - l # Behaves properly when l == b == u
        m.scatter_add_(-1,l.long(),self.probs*(1-credit))
        m.scatter_add_(-1,u.long(),self.probs*credit)
        return m

q = torch.rand(2,21)
q /= q.sum(-1,keepdim=True)
x = ArithCatTensor(-10,10,q)

print(x.probs)
print(x.add_mult(1.0,2.0))