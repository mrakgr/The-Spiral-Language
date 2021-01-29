cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cpdef void main():
    cdef list v0
    v0 = [None] * 10
    v0[0] = Tuple0(1, 2)
