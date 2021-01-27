cdef class Tuple0:
    cdef public signed long v0
    cdef public signed long v1
    cdef public signed long v2
    cdef public signed long v3
    def __init__(self, signed long v0, signed long v1, signed long v2, signed long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cpdef main():
    cdef signed long v0
    v0 = 2
    cdef signed long v1
    v1 = 4
    cdef signed long v2
    v2 = 6
    cdef signed long v3
    v3 = 12
    return Tuple0(v0, v1, v2, v3)
