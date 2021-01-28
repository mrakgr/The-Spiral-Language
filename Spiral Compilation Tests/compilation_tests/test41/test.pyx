cdef class UH0:
    cdef public int tag
cdef class UH0_0(UH0): # cons_
    cdef public signed long v0
    cdef public signed long v1
    cdef public UH0 v2
    def __init__(self, signed long v0, signed long v1, UH0 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef public object v0
    cdef public signed long v1
    def __init__(self, v0, signed long v1): self.v0 = v0; self.v1 = v1
cpdef main():
    cdef UH0 v0
    cdef signed long v1
    cdef signed long v2
    cdef UH0 v3
    cdef signed long v4
    cdef signed long v5
    cdef UH0 v6
    cdef signed long v7
    cdef signed long v8
    cdef UH0 v9
    cdef signed long v10
    cdef signed long v11
    cdef signed long v12
    cdef signed long v13
    cdef signed long v14
    cdef signed long v15
    cdef signed long v16
    cdef signed long v17
    cdef signed long v20
    v0 = UH0_1()
    if v0 == 0: # cons_
        v1 = (<UH0_0>v0).v0
        v2 = (<UH0_0>v0).v1
        v3 = (<UH0_0>v0).v2
        if v3 == 0: # cons_
            v4 = (<UH0_0>v3).v0
            v5 = (<UH0_0>v3).v1
            v6 = (<UH0_0>v3).v2
            if v6 == 0: # cons_
                v7 = (<UH0_0>v6).v0
                v8 = (<UH0_0>v6).v1
                v9 = (<UH0_0>v6).v2
                v10 = v1 + v2
                v11 = v10 + v4
                v12 = v11 + v5
                v13 = v12 + v7
                v14 = v13 + v8
                return Tuple0("At least three elements.", v14)
            elif v6 == 1: # nil
                v15 = v1 + v2
                v16 = v15 + v4
                v17 = v16 + v5
                return Tuple0("Two elements.", v17)
        elif v3 == 1: # nil
            v20 = v1 + v2
            return Tuple0("One element.", v20)
    elif v0 == 1: # nil
        return Tuple0("No elements", 0)
