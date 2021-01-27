cdef class Tuple0:
    cdef public signed long v0
    cdef public signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cpdef main():
    cdef signed long v0
    v0 = 1
    cdef signed long v1
    v1 = 2
    cdef signed long v2
    v2 = 3
    cdef signed long v3
    v3 = 4
    cdef signed long v4
    v4 = v0 + v2
    cdef signed long v5
    v5 = v1 + v3
    Tuple0(v4, v5)
