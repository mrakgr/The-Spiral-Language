import numpy
cimport numpy
import random
cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly double v1
    def __init__(self, signed long v0, double v1): self.v0 = v0; self.v1 = v1
cpdef void main():
    cdef numpy.ndarray[object,ndim=1] v0
    if random.randint(0,1): v0 = None
    
