cdef class UH0:
    cdef public int tag
cdef class UH0_0(UH0): # add_
    cdef public UH0 v0
    cdef public UH0 v1
    def __init__(self, UH0 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # mult_
    cdef public UH0 v0
    cdef public UH0 v1
    def __init__(self, UH0 v0, UH0 v1): self.tag = 1; self.v0 = v0; self.v1 = v1
cdef class UH0_2(UH0): # v_
    cdef public float v0
    def __init__(self, float v0): self.tag = 2; self.v0 = v0
cdef float method0(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef float v3
    cdef float v4
    cdef UH0 v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef float v11
    if v0 == 0: # add_
        v1 = (<UH0_0>v0).v0
        v2 = (<UH0_0>v0).v1
        v3 = method0(v1)
        v4 = method0(v2)
        return v3 + v4
    elif v0 == 1: # mult_
        v6 = (<UH0_1>v0).v0
        v7 = (<UH0_1>v0).v1
        v8 = method0(v6)
        v9 = method0(v7)
        return v8 * v9
    elif v0 == 2: # v_
        v11 = (<UH0_2>v0).v0
        return v11
cpdef main():
    cdef float v0
    cdef float v1
    cdef UH0 v2
    cdef float v3
    cdef UH0 v4
    cdef UH0 v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef UH0 v9
    cdef UH0 v10
    cdef UH0 v11
    cdef float v12
    # // static
    v0 = 21.000000
    # // dynamic
    v1 = 1.000000
    v2 = UH0_2(v1)
    v3 = 2.000000
    v4 = UH0_2(v3)
    v5 = UH0_0(v2, v4)
    v6 = 3.000000
    v7 = UH0_2(v6)
    v8 = 4.000000
    v9 = UH0_2(v8)
    v10 = UH0_0(v7, v9)
    v11 = UH0_1(v5, v10)
    v12 = method0(v11)
    return v12 * 2.000000
