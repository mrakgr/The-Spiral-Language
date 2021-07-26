import torch

torch.set_printoptions(sci_mode=False)

q = (torch.rand(10,8) * 3).exp()
q /= q.sum(-1,keepdim=True)

print(q.topk(3).values)
