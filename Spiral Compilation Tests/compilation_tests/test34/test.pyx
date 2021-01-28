cdef class Tuple0:
    cdef public signed long v0
    cdef public signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cpdef main():
    cdef signed long v0
    cdef signed long v1
    v0 = 1
    v1 = 2
    return Tuple0(v0, v1)
