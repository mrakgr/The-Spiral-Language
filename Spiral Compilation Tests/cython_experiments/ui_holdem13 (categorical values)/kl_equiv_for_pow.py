from math import sqrt,pow
import torch

e = 3.0
for i in range(100):
    qinit = torch.randn(5,requires_grad=True)
    q = qinit.abs()
    qp = q.pow(e)
    qpsum = qp.sum(-1)
    qpsuminv = qpsum.pow(-1)
    qpn = qp * qpsuminv
    qn = qpn.pow(1/e)

    g_qn = torch.rand(5,requires_grad=False)
    qn.backward(g_qn)

    z1 = qinit.sign() * ((g_qn - q.pow(e-1) * ((g_qn * q).sum(-1) / qpsum)) / qpsum.pow(1/e))
    z2 = qinit.grad
    t = (z1 - z2).abs() <= 1e-6
    if t.all().item() == False:
        raise Exception("has error")
