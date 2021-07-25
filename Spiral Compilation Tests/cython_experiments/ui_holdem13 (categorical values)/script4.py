from math import exp, trunc
import torch
from torch.functional import Tensor

def is_prob_dist(x : Tensor,dim=-1) -> bool: 
    return torch.all(x >= 0).logical_and(torch.all(torch.abs(1.0 - x.sum(dim)) <= 1e-6)).item()

class GeoCatTensor:
    def __init__(self,min_max : float,probs : Tensor):
        assert 3 <= probs.shape[-1], "The number of supports should at least be 3."
        assert probs.shape[-1] % 2 == 1, "The number of supports should be odd so as to go through 0."
        assert 0 < min_max, "The min_max should be positive."
        assert is_prob_dist(probs), "The input tensor should be a probability vector for all the inputs in the last dimension."
        self.max = min_max
        self.probs = probs
        self.half_dim = (self.probs.shape[-1] - 1) // 2

    @property
    def support(self):
        """
        The support for the probability vector.
        """
        x = torch.linspace(-1,1,self.probs.shape[-1],dtype=self.probs.dtype,device=self.probs.device)
        db,da = self.probs.shape
        x = x.sign().mul_(torch.exp_(x.abs()) - 1).mul_(self.max / (exp(1.0) - 1.0))
        return x.repeat(db,1)

    def bins(self,tz : Tensor):
        b = tz.mul((exp(1.0) - 1.0) / self.max).abs_().add_(1.0).log_().mul_(self.half_dim)
        b[:,:self.half_dim].neg_()
        b += self.half_dim

        l,u = torch.floor(b).long(), torch.ceil(b).long()
        sup = self.support
        tzl, tzu = sup.gather(-1,l), sup.gather(-1,u)
        return l, torch.nan_to_num_((tzu - tz) / (tzu - tzl),0.0,0.0,0.0), u

    def add_mult(self,y : Tensor or float,r : Tensor or float):
        """
        Calculates `probs*y+r` indirectly by distributing the probabilities along the support.
        """
        l,credit,u = self.bins((self.support*y + r).clamp_(-self.max,self.max))
        m = torch.zeros_like(credit)
        m.scatter_add_(-1,l,self.probs*credit)
        m.scatter_add_(-1,u,self.probs*(1-credit))
        return m

q = torch.rand(1,5)
q /= q.sum(-1,keepdim=True)
x = GeoCatTensor(10,q)

print(x.probs)
print(x.add_mult(1.0,0.5))