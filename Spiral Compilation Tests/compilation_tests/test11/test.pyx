cdef class Tuple0:
    cdef public signed long long v0
    cdef public double v1
    cdef public object v2
    def __init__(self, signed long long v0, double v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cpdef main():
    cdef signed long long v0
    v0 = 2
    cdef double v1
    v1 = 3.400000
    cdef object v2
    v2 = "123"
    return Tuple0(v0, v1, v2)
