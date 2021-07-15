from math import sqrt
import torch
from torch import Tensor
from torch.nn import Module,Linear
from torch.nn.init import xavier_normal_
from torch.nn.parameter import Parameter

class Attention(Module):
    def __init__(self,dim_in,dim_v,dim_qk=None):
        super().__init__()
        dim_proj = dim_v if dim_qk is None else dim_qk
        self.q, self.k, self.v = Linear(dim_in,dim_proj,bias=False), Linear(dim_in,dim_proj,bias=False), Linear(dim_in,dim_v)

    def forward(self,x,mask=None):
        q,k,v = self.q.forward(x), self.k.forward(x), self.v.forward(x)
        dz, dk, da = k.shape
        z : Tensor = torch.einsum('zqa,zka->zqk',q,k) / sqrt(da)
        if mask is not None:
            z = z.masked_fill(torch.logical_or(mask.view(dz,dk,1),mask.view(dz,1,dk)),float('-inf'))
        return torch.einsum('zqk,zka->zqa',z.softmax(-1).nan_to_num(),v)

