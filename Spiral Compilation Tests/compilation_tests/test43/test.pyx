cdef class UH0:
    cdef public int tag
cdef class UH0_0(UH0): # cons_
    cdef public signed long v0
    cdef public UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef signed long method0(signed long v0, UH0 v1):
    cdef signed long v2
    cdef UH0 v3
    cdef signed long v4
    if v1 == 0: # cons_
        v2 = (<UH0_0>v1).v0
        v3 = (<UH0_0>v1).v1
        v4 = v0 + v2
        return method0(v4, v3)
    elif v1 == 1: # nil
        return v0
cpdef main():
    cdef UH0 v0
    cdef signed long v1
    v0 = UH0_1()
    v1 = 0
    return method0(v1, v0)
