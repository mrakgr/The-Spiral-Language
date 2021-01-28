cdef class US0:
    cdef public int tag
cdef class US0_0(US0): # a_
    cdef public signed long v0
    def __init__(self, signed long v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # b_
    cdef public double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef public int tag
cdef class UH0_0(UH0): # cons_
    cdef public signed long v0
    cdef public UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef char method0(UH0 v0, UH0 v1):
    cdef signed long v2
    cdef UH0 v3
    cdef signed long v4
    cdef UH0 v5
    cdef char v6
    if v1 == 0 and v0 == 0: # cons_
        v2 = (<UH0_0>v1).v0
        v3 = (<UH0_0>v1).v1
        v4 = (<UH0_0>v0).v0
        v5 = (<UH0_0>v0).v1
        v6 = v2 == v4
        if v6:
            return method0(v5, v3)
        else:
            return 0
    elif v1 == 1 and v0 == 1: # nil
        return 1
    else:
        return 0
cpdef void main():
    cdef char v3
    cdef signed long v4
    cdef US0 v5
    cdef char v9
    cdef double v7
    cdef double v10
    cdef US0 v11
    cdef char v16
    cdef signed long v14
    cdef signed long v17
    cdef US0 v18
    cdef double v19
    cdef US0 v20
    cdef char v27
    cdef signed long v21
    cdef signed long v22
    cdef double v24
    cdef double v25
    cdef signed long v28
    cdef UH0 v29
    cdef UH0 v30
    cdef signed long v31
    cdef signed long v32
    cdef UH0 v33
    cdef UH0 v34
    cdef char v46
    cdef signed long v41
    cdef UH0 v42
    cdef char v43
    # // Union test
    # // Static, Static
    v3 = 0
    # // Dyn, Static
    v4 = 1
    v5 = US0_0(v4)
    if v5 == 1: # b_
        v7 = (<US0_1>v5).v0
        v9 = v7 == 3.000000
    else:
        v9 = 0
    # // Static, Dyn
    v10 = 3.000000
    v11 = US0_1(v10)
    if v11 == 0: # a_
        v14 = (<US0_0>v11).v0
        v16 = 1 == v14
    else:
        v16 = 0
    # // Dyn, Dyn
    v17 = 1
    v18 = US0_0(v17)
    v19 = 3.000000
    v20 = US0_1(v19)
    if v18 == 0 and v20 == 0: # a_
        v21 = (<US0_0>v18).v0
        v22 = (<US0_0>v20).v0
        v27 = v21 == v22
    elif v18 == 1 and v20 == 1: # b_
        v24 = (<US0_1>v18).v0
        v25 = (<US0_1>v20).v0
        v27 = v24 == v25
    else:
        v27 = 0
    # // Union rec test
    v28 = 3
    v29 = UH0_1()
    v30 = UH0_0(v28, v29)
    v31 = 2
    v32 = 3
    v33 = UH0_0(v32, v29)
    v34 = UH0_0(v31, v33)
    if v34 == 0: # cons_
        v41 = (<UH0_0>v34).v0
        v42 = (<UH0_0>v34).v1
        v43 = 2 == v41
        if v43:
            v46 = method0(v42, v30)
        else:
            v46 = 0
    else:
        v46 = 0
