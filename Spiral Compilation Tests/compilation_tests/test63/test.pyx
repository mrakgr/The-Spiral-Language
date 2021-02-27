cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly signed long v0
    cdef readonly UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef signed long method0(UH0 v0, signed long v1):
    cdef signed long v2
    cdef UH0 v3
    cdef signed long v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = v1 + v2
        return method0(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cpdef signed long main():
    cdef signed long v0
    cdef signed long v1
    cdef signed long v2
    cdef UH0 v3
    cdef UH0 v4
    cdef UH0 v5
    cdef UH0 v6
    cdef signed long v7
    v0 = 4
    v1 = 5
    v2 = 6
    v3 = UH0_1()
    v4 = UH0_0(v2, v3)
    del v3
    v5 = UH0_0(v1, v4)
    del v4
    v6 = UH0_0(v0, v5)
    del v5
    v7 = 6
    return method0(v6, v7)
