cdef class FuncInt:
    cdef int apply(self, int y): raise NotImplementedError()

cdef class FuncAddInt(FuncInt):
    cdef int x
    def __init__(self, int x): self.x = x
    cdef int apply(self, int y): return self.x + y

cpdef int applyAdd(FuncInt a, int b):
    return a.apply(b)