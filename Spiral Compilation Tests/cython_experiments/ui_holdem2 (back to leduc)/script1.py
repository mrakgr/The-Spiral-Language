import torch
q = torch.tensor([2,3,500],dtype=torch.float,requires_grad=True)
qq = q.square()
x = qq / qq.sum()
x.backward(torch.tensor([1,2,-3]))
q.grad