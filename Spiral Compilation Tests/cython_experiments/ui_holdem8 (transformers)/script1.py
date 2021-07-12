# import torch
# from x_transformers import ContinuousTransformerWrapper, Encoder

# model = ContinuousTransformerWrapper(
#     max_seq_len=128, dim_in=10,
#     attn_layers=Encoder(dim=32, depth=1, heads=1, gate_residual=True)
#     )
# avg_model = torch.optim.swa_utils.AveragedModel(model)
# with open("asd.nnavg",'wb') as f: torch.save(map(lambda x: x.module,[avg_model]),f)

def f(x):
    print(x)
    return x+x

q = map(f,[1,2,3])
def g(a,b,c): print(a,b,c)
g(*q)