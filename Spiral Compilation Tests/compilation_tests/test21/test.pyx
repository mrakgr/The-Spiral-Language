cdef class Tuple0:
    cdef public float v0
    cdef public float v1
    def __init__(self, float v0, float v1): self.v0 = v0; self.v1 = v1
cpdef main():
    cdef float v0
    v0 = 6.000000
    cdef float v1
    v1 = 4.000000
    return Tuple0(v0, v1)
