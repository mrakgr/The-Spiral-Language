import numpy as np

a = bytearray(16)
a2 = np.frombuffer(a,dtype=np.int32)
np.frombuffer(a,like=a2).dtype
b = np.zeros(4,dtype=np.int32)
np.copyto(b,a2)
b


bytearray(a.nbytes)
