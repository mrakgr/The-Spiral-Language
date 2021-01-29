cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly signed long v1
    cdef readonly signed long v2
    cdef readonly signed long v3
    cdef readonly signed long v4
    def __init__(self, signed long v0, signed long v1, signed long v2, signed long v3, signed long v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cpdef Tuple0 main():
    return Tuple0(1, 2, 3, 4, 5)
