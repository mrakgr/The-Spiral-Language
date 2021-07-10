import torch
from torch.nn import TransformerDecoderLayer, TransformerEncoderLayer

dec = TransformerDecoderLayer(16,1,16,dropout=0,batch_first=True)
q = torch.rand(1,1,3)
m = torch.rand(1,1) < 0

dec.forward()
