import torch
bck = torch.tensor([1,2,3])
q = torch.tensor([2.2,2.8,28],dtype=torch.float,requires_grad=True)
qq = q.square()
x = qq / qq.sum()
x.backward(bck)

q3 = torch.tensor([0.0061, 0.0098, 0.9841],dtype=torch.float,requires_grad=True)
x3 = q3 / q3.sum()
x3.backward(bck)

q2 = torch.tensor([1,1.5,6],dtype=torch.float,requires_grad=True)
x2 = q2.softmax(-1)
x2.backward(bck)

q.grad
q3.grad
q2.grad

x
x3
x2