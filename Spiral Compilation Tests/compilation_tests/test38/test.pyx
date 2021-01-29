cdef class US0:
    cdef readonly unsigned long tag
cdef class US0_0(US0): # none
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # some_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 1; self.v0 = v0
cdef class ClosureTy0:
    cpdef signed long apply(self, US0 v0): raise NotImplementedError()
cdef class Closure0(ClosureTy0):
    cdef signed long v0
    def __init__(self, signed long v0): self.v0 = v0
    cpdef signed long apply(self, US0 v1):
        cdef signed long v0 = self.v0
        cdef signed long v2
        if v1.tag == 0: # none
            return v0
        elif v1.tag == 1: # some_
            v2 = (<US0_1>v1).v0
            return v2
cpdef ClosureTy0 main():
    cdef signed long v0
    v0 = 0
    return Closure0(v0)
