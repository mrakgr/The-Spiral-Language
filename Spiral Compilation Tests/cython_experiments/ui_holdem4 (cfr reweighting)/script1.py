import torch
bck = torch.tensor([1,2,3])
q = torch.tensor([0.1,0.1,1.8],dtype=torch.float,requires_grad=True)
x = q / q.sum()
x.backward(bck)
q.grad