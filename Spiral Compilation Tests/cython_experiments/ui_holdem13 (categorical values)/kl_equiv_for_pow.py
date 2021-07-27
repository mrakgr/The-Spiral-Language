from math import sqrt,pow
import torch

e = 5.0
# q = torch.tensor([pow(0.2,1/e),pow(0.9,1/e)],requires_grad=True)
q = torch.rand(5,requires_grad=True)
qp = q.pow(e)
qpsum = qp.sum(-1)
qpsuminv = qpsum.pow(-1)
qpn = qp * qpsuminv
qn = qpn.pow(1/e)

g_qn = torch.rand(5,requires_grad=False)
qn.backward(g_qn)

(g_qn - q.pow(e-1) * ((g_qn * q).sum(-1) / qpsum)) / qpsum.pow(1/e) # Numerically stable eqivalent of KL for powers.
q.grad
