from math import exp, log
import torch
from torch._C import dtype
from torch.functional import Tensor
from torch.nn.parameter import Parameter
from torch.nn import Module
from typing import Tuple

def is_prob_dist(x : Tensor,dim=-1) -> bool: 
    return torch.all(x >= 0).logical_and(torch.all(torch.abs(1.0 - x.sum(dim)) <= 1e-6)).item()

class Projector(Module):
    """
    Template for the categorical projector classes.
    """
    def __init__(self,max : float,num_supports : int):
        super().__init__()
        assert 3 <= num_supports, "The number of supports should at least be 3."
        assert num_supports % 2 == 1, "The number of supports should be odd so as to go through 0."
        assert 0 < max, "The max should be positive."
        self.max = max
        self.num_supports = num_supports
        self.half_dim = (num_supports - 1) // 2

    def bins(self,tz : Tensor) -> Tuple[Tensor, Tensor, Tensor]:
        """
        Returns the lower bin indices, the relative credit for the lower bin, and the upper bin indices.
        """
        raise NotImplementedError()

    def _calc(self,probs,x : Tensor):
        return self.distribute(probs,*self.bins(x.clamp_(-self.max,self.max)))

    def add_mult(self,probs : Tensor, y : Tensor or float,r : Tensor or float):
        """
        Calculates `probs*y+r` for the categorical probability tensor by distributing the probabilities along the support.
        """
        return self._calc(probs,self.support.expand_as(probs) * y + r)

    def add(self,probs : Tensor, r : Tensor or float):
        """
        Calculates `probs+r` for the categorical probability tensor by distributing the probabilities along the support.
        """
        return self._calc(probs,self.support.expand_as(probs) + r)

    def mult(self,probs : Tensor, y : Tensor or float):
        """
        Calculates `probs*y` for the categorical probability tensor by distributing the probabilities along the support.
        """
        return self._calc(probs,self.support.expand_as(probs) * y)

    def distribute(self,probs,l,credit,u):
        m = torch.zeros_like(credit)
        m.scatter_add_(-1,l,probs*credit)
        m.scatter_add_(-1,u,probs*(1-credit))
        return m

    def to_cat(self,r):
        """
        Creates the categorical eqivalent of a scalar float Numpy vector.
        """
        x = torch.zeros(len(r),self.num_supports,device=self.support.device,dtype=self.support.dtype)
        x[:,self.half_dim] = 1.0
        return self.add(x,torch.tensor(r,device=self.support.device).view(len(r),1))

    def combine(self,*args):
        """
        Combines the args into a single tensor. Args are supposed to be index list/PyTorch tensor flattened pairs.
        """
        assert len(args) % 2 == 0, 'Expected an even number of args.'
        c = 0
        for i in range(0,len(args),2): c += len(args[i+1])
        x = torch.empty(c,self.num_supports,device=self.support.device,dtype=self.support.dtype)
        for i in range(0,len(args),2): 
            a, b = args[i], args[i+1]
            assert len(a) == len(b), 'Expected the pairs to have the same outer dimension.'
            x[a] = b
        return x

    @property
    def empty(self): 
        """
        Returns a tensor of size zero that has the number of supports the projector has.
        """
        return torch.empty(0,self.num_supports,device=self.support.device,dtype=self.support.dtype)

    def mean(self,probs : Tensor): 
        """
        Returns the mean value of the probability vector based on the projector support.
        """
        return (probs @ self.support).squeeze(-1)

class ExpProjector(Projector):
    """
    Creates a symmetric exponential basis in the [-max,max] range. On a chart of y=exp(x) imagine the right side cutting of at log(max), translated by -1 so it touches the x-axis at 0 and having an image of it rotated around the center.
    """
    def __init__(self,max : float,num_supports : int):
        super().__init__(max,num_supports)
        support = torch.linspace(-log(max + 1),log(max + 1),num_supports)
        self.support = Parameter(support.sign() * (torch.exp(support.abs()) - 1),requires_grad=False)

    def bins(self,tz : Tensor):
        assert tz.shape[-1] == self.num_supports, "Expected the last dimension of the input tensor to be same as the number of supports."
        b = tz.sign() * ((tz.abs() + 1).log() * (self.half_dim / log(self.max + 1))) + self.half_dim
        l,u = torch.floor(b).long(), torch.ceil(b).long()
        sup = self.support.expand_as(tz)
        tzl, tzu = sup.gather(-1,l), sup.gather(-1,u)
        return l, torch.nan_to_num_((tzu - tz) / (tzu - tzl),0.0,0.0,0.0), u

class LinearProjector(Projector):
    """
    Creates a linear basis in the [-max,max] range.
    """
    def __init__(self,max : float,num_supports : int):
        super().__init__(max,num_supports)
        self.support = Parameter(torch.linspace(-max,max,num_supports),requires_grad=False)

    def bins(self,tz : Tensor):
        assert tz.shape[-1] == self.num_supports, "Expected the last dimension of the input tensor to be same as the number of supports."
        b = (tz + self.max) * ((self.num_supports - 1) / (2 * self.max))
        l, u = torch.floor(b).long(), torch.ceil(b).long()
        return l, u - b, u