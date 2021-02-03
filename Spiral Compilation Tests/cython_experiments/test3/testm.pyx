import numpy
cimport numpy
cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly double v1
    def __init__(self, signed long v0, double v1): self.v0 = v0; self.v1 = v1
cdef class Tuple1:
    cdef readonly signed long v0
    cdef readonly double v1
    cdef readonly double v2
    def __init__(self, signed long v0, double v1, double v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cpdef void main():
    cdef numpy.ndarray[object,ndim=1] v0
    cdef Tuple1 v1
    v0 = numpy.empty(10,dtype=object)
    v0[0] = Tuple0(1, 2.000000)
    v1 = <Tuple1>v0[0]
