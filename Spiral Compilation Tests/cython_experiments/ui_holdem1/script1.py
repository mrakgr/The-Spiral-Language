import torch
x = torch.tensor([100,10,0],dtype=torch.float,requires_grad=True)
b = torch.tensor([0,10,100],dtype=torch.float)
o = torch.softmax(x*1,-1)
o.backward(b)
torch.sign(x.grad)