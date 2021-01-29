cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly signed long v1
    cdef readonly str v2
    def __init__(self, signed long v0, signed long v1, str v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cpdef Tuple0 main():
    cdef signed long v0
    cdef signed long v1
    v0 = 123
    v1 = 456
    return Tuple0(v0, v1, "qwe")
