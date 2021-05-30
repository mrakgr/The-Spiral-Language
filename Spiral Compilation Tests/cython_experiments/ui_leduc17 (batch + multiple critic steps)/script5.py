import torch
import numpy as np
x = np.array([1,2,7],dtype=np.float)
p = np.array([0.25,0.25,0.5])
mean = (x * p).sum()
xm = x - mean
q = xm - p * xm.sum()
q
