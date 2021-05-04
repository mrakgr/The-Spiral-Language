import numpy as np

a = np.zeros((1,5))
b = a[0,:]
b[0] = 23
print(a)