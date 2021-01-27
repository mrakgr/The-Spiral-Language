cdef class Tuple0:
    cdef public object v0
    cdef public signed long v1
    cdef public signed char v2
    def __init__(self, v0, signed long v1, signed char v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cpdef main():
    cdef object v0
    v0 = "Coord"
    cdef signed long v1
    v1 = 1
    cdef signed char v2
    v2 = 2
    return Tuple0(v0, v1, v2)
