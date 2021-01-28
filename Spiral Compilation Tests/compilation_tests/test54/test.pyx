cdef class Heap0:
    cdef public signed long v0
    cdef public signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cpdef signed long main():
    cdef Heap0 v0
    cdef signed long v1
    cdef signed long v2
    v0 = Heap0(1, 2)
    v1 = v0.v0
    v2 = v0.v1
    return v1 + v2
