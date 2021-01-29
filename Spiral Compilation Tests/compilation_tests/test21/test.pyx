cdef class Tuple0:
    cdef readonly float v0
    cdef readonly float v1
    def __init__(self, float v0, float v1): self.v0 = v0; self.v1 = v1
cpdef Tuple0 main():
    cdef float v0
    cdef float v1
    v0 = 6.000000
    v1 = 4.000000
    return Tuple0(v0, v1)
