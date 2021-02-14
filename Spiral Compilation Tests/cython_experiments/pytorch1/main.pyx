import torch
import torch.nn
import nets
cpdef void main():
    cdef object v0
    cdef object v1
    cdef object v2
    pass # import torch
    pass # import torch.nn
    pass # import nets
    v0 = torch.randn(2,16)
    v1 = nets.small(16,32)
    v2 = v1.forward(v0)
    del v0; del v1
    print(v2)
