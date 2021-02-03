import numpy
cimport numpy
cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly double v1
    def __init__(self, signed long v0, double v1): self.v0 = v0; self.v1 = v1
cpdef str main():
    cdef char v0
    cdef numpy.ndarray[object,ndim=1] v1
    cdef numpy.ndarray[object,ndim=1] v2
    v0 = 1
    if v0:
        v1 = numpy.empty(10,dtype=object)
        v1[0] = Tuple0(1, 2.000000)
        v1 = None
    else:
        v2 = numpy.empty(10,dtype=object)
        v2[0] = Tuple0(1, 2.000000)
        v2 = None
    return "ok"
