cdef class US0:
    cdef readonly unsigned long tag
cdef class US0_0(US0): # none
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # some_
    cdef readonly signed long long v0
    def __init__(self, signed long long v0): self.tag = 1; self.v0 = v0
cpdef signed long long main():
    cdef signed long long v0
    cdef US0 v1
    cdef signed long long v2
    v0 = 3
    v1 = US0_1(v0)
    if v1.tag == 0: # none
        return 0
    elif v1.tag == 1: # some_
        v2 = (<US0_1>v1).v0
        return v2
