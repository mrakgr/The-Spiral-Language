import cupy as cp
x = cp.random.random((2,4,15),cp.float32)
print(x.strides) # (240, 60, 4)

# https://stackoverflow.com/questions/58905574/how-to-allocate-pitched-2d-memory-in-cupy