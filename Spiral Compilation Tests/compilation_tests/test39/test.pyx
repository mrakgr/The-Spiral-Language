cdef class US0:
    cdef public int tag
cdef class US0_0(US0): # a
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # b
    def __init__(self): self.tag = 1
cpdef main():
    cdef US0 v0
    v0 = US0_0()
    if v0 == 0: # a
        return 1
    elif v0 == 1: # b
        return 4
