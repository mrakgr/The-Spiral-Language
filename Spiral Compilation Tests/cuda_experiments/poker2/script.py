import numpy as np
import cupy as cp

x_gpu = cp.array([1,2,3,4])
print(x_gpu)

device = cp.cuda.Device()
print(device)

