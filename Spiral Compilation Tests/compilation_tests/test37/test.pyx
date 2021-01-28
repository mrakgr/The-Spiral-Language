cdef class US0:
    cdef public int tag
cdef class US0_0(US0): # none
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # some_
    cdef public signed long long v0
    def __init__(self, signed long long v0): self.tag = 1; self.v0 = v0
cpdef main():
    cdef signed long long v0
    cdef US0 v1
    cdef signed long long v2
    v0 = 3
    v1 = US0_1(v0)
    if v1 == 0: # none
        return 0
    elif v1 == 1: # some_
        v2 = (<US0_1>v1).v0
        return v2
