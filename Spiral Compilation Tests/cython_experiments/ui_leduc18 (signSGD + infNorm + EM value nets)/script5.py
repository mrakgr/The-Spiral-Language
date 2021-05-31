import numpy as np
p = np.array([1/4,1/4,1/2])
def f(xm): 
    return xm - p * xm.sum()
x = np.array([1,2,4],dtype=np.float)
q = x - (x * p).sum()
w = q - (q * p).sum()
f(x - (x * p).sum())
