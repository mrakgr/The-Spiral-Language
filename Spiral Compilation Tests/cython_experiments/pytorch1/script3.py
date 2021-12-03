import numpy as np

a = np.random.randn(3,1)
b = np.matmul(a,a.T)
c = b * (1 - 1e-6) + np.eye(*b.shape) * 1e-6
inv = np.linalg.inv(np.linalg.cholesky(c))
q = np.matmul(inv,a)
np.matmul(q,q.T)

