cimport cython
cdef class Tuple0:
    cdef readonly signed long v0
    cdef readonly double v1
    def __init__(self, signed long v0, double v1): self.v0 = v0; self.v1 = v1
cpdef void main():
    cdef Tuple0 [::1] v0
    v0 = cython.view.array(shape=(10,), itemsize=sizeof(void *), format='O')
    v0[0] = Tuple0(1, 2.000000)
