cdef class FuncInt:
    cdef int apply(self, int y): raise NotImplementedError()

cdef class FuncAddInt(FuncInt):
    cdef int x
    def __init__(self, int x): self.x = x; self.x = x
    cdef int apply(self, int y): return self.x + y

cpdef int applyAdd(FuncInt a, int b):
    cdef char [1] q
    pass
    return a.apply(b)