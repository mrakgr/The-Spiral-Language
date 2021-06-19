import torch
x = torch.tensor([0,0,1],dtype=torch.float,requires_grad=True)
b = torch.tensor([0,2,2],dtype=torch.float)
o = torch.softmax(x,-1)
o.backward(b)
x.grad