from math import sqrt
import torch
from torch import Tensor
from torch.nn import Module,Linear
from torch.nn.init import xavier_normal_
from torch.nn.parameter import Parameter
from belief import inf_cube

class Rotary(Module):
    def __init__(self,dim_in):
        super().__init__()
        self.dim_in = dim_in
        self.freq = Parameter(10000 ** torch.arange(0, -1, -2 / dim_in, dtype=torch.float),requires_grad=False)

    def pos_emb(self,dim_seq):
        i = torch.arange(dim_seq, dtype=self.freq.dtype, device=self.freq.device)
        i_freq = i.view(-1,1) * self.freq.view(1,-1)
        return torch.cat((i_freq, i_freq[:,:i_freq.shape[1] - self.dim_in % 2]), dim=-1).view(1,dim_seq,1,self.dim_in)

    def rotate_half(self,x : Tensor):
        x1, x2 = x.chunk(2,-1)
        return torch.cat((-x2, x1), dim = -1)

    def forward(self,x):
        assert x.dim() == 4, f"Expected the number of tensor dimensions to be 4: batch, seq, head, el. Got: {x.shape}"
        emb = self.pos_emb(x.shape[1])
        return x * emb.cos() + self.rotate_half(x) * emb.sin()

class Attention(Module):
    def __init__(self,dim_in,dim_out,num_heads=1,dim_qk=None):
        super().__init__()
        dim_proj = dim_out if dim_qk is None else dim_qk
        self.dim_in, self.dim_proj, self.num_heads, self.dim_out = dim_in, dim_proj, num_heads, dim_out
        self.proj_in = Parameter(torch.empty((dim_in,num_heads,dim_proj*2+dim_out)))
        for x in torch.split(self.proj_in,[self.dim_proj,self.dim_proj,self.dim_out],-1): xavier_normal_(x)
        self.v_bias = Parameter(torch.zeros(num_heads,dim_out))
        self.proj_out = Parameter(xavier_normal_(torch.empty((dim_out,num_heads,dim_out))))
        self.proj_out_bias = Parameter(torch.zeros(dim_out))
        self.rotary = Rotary(dim_proj)

    def forward(self,x,mask=None):
        q,k,v = torch.split(torch.einsum('iho,zki->zkho',self.proj_in,x),[self.dim_proj,self.dim_proj,self.dim_out],-1)
        dz, dk, dh, da = k.shape
        q,k = self.rotary(q), self.rotary(k)
        seq_weights : Tensor = torch.einsum('zqha,zkha->zqkh',q,k) / sqrt(da)
        if mask is not None:
            seq_weights = seq_weights.masked_fill(torch.logical_or(mask.view(dz,dk,1,1),mask.view(dz,1,dk,1)),float('-inf'))
        o = torch.einsum('zqkh,zkhx->zqhx',seq_weights.softmax(-2).nan_to_num(),v + self.v_bias.view(1,1,dh,self.dim_out))
        return inf_cube(torch.einsum('zqhx,xhy->zqy',inf_cube(o),self.proj_out) + self.proj_out_bias.view(1,1,self.dim_out))

q = Attention(3,4)
w = torch.rand(1,3,3)
r = q.forward(w,torch.tensor([False,False,True]))
print(r)