cdef class Mut0:
    cdef public signed long v0
    cdef public signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cpdef void main():
    cdef Mut0 v0
    v0 = Mut0(1, 2)
    v0.v0 = 3
    v0.v1 = 4
