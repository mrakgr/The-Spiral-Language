import torch
from torch.nn.functional import normalize
bck = torch.tensor([0,3,0])
q = torch.tensor([-0.3, 0.1, 2.5],dtype=torch.float,requires_grad=True)
# x1 = torch.layer_norm(q.square() * q.sign(),[3])
# x2 = torch.layer_norm(q ** 3,[3])
# x1
# x2
# x2.backward(bck)
# q.grad
def f(x,p): 
    return x / torch.norm(x,p)
x1 = f(q * q.abs(),2)
x2 = f(q ** 3,2)
x1
x2
x2.backward(bck)
q.grad