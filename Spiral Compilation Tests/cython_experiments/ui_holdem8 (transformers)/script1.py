import torch
import torch.nn.functional as F
from x_transformers import ContinuousTransformerWrapper, Decoder, Encoder, XTransformer
from einops import rearrange

model = ContinuousTransformerWrapper(
    max_seq_len=128,
    attn_layers = Decoder(
        dim = 32,
        depth = 2,
        heads = 1,
        gate_residual = True,
        rotary_pos_emb = True,
        cross_attend = True
    )
)

q = torch.rand(1,20,32)
w = torch.rand(1,10,32)
model.forward(q) == model.forward(q,context=w)

i,j = 10,9
r = torch.arange(i)
mask = rearrange(r, 'i -> () () i ()') < rearrange(r, 'j -> () () () j')
mask = F.pad(mask, (j - i, 0), value = False)