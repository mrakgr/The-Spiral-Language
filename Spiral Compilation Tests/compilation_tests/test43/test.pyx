cdef class UH0:
    cdef readonly unsigned long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly signed long v0
    cdef readonly UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef signed long method0(signed long v0, UH0 v1):
    cdef signed long v2
    cdef UH0 v3
    cdef signed long v4
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0
        v3 = (<UH0_0>v1).v1
        v4 = v0 + v2
        return method0(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cpdef signed long main():
    cdef signed long v0
    cdef signed long v1
    cdef signed long v2
    cdef UH0 v3
    cdef UH0 v4
    cdef UH0 v5
    cdef UH0 v6
    cdef signed long v7
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = UH0_1()
    v4 = UH0_0(v2, v3)
    v5 = UH0_0(v1, v4)
    v6 = UH0_0(v0, v5)
    v7 = 0
    return method0(v7, v6)
