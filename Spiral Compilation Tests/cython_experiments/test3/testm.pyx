import numpy
cimport numpy
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # none
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # some_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 1; self.v0 = v0
cpdef unsigned long long main():
    cdef numpy.ndarray[object,ndim=1] v0
    cdef unsigned long long v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef US0 v3
    v0 = numpy.empty(10,dtype=object)
    v1 = len(v0)
    v2 = numpy.empty(v1,dtype=object)
    v3 = US0_1(1)
    v2[0] = v3
    return v1
