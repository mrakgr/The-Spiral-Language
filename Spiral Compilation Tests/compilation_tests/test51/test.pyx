cdef class US0:
    cdef readonly int tag
cdef class US0_0(US0): # a_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # b_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly int tag
cdef class UH0_0(UH0): # cons_
    cdef readonly signed long v0
    cdef readonly UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class UH1:
    cdef readonly int tag
cdef class UH1_0(UH1): # cons_
    cdef readonly double v0
    cdef readonly UH1 v1
    def __init__(self, double v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef signed long method0(UH0 v0):
    cdef signed long v1
    cdef UH0 v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    if v0 == 0: # cons_
        v1 = (<UH0_0>v0).v0
        v2 = (<UH0_0>v0).v1
        v3 = hash(v1)
        v4 = v3 * 33
        v5 = method0(v2)
        return v4 + v5
    elif v0 == 1: # nil
        return 33
cdef signed long method1(UH1 v0):
    cdef double v1
    cdef UH1 v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    if v0 == 0: # cons_
        v1 = (<UH1_0>v0).v0
        v2 = (<UH1_0>v0).v1
        v3 = hash(v1)
        v4 = v3 * 33
        v5 = method1(v2)
        return v4 + v5
    elif v0 == 1: # nil
        return 33
cpdef void main():
    cdef signed long v1
    cdef signed long v3
    cdef signed long v4
    cdef US0 v5
    cdef signed long v11
    cdef signed long v6
    cdef double v8
    cdef signed long v9
    cdef double v12
    cdef US0 v13
    cdef signed long v19
    cdef signed long v14
    cdef double v16
    cdef signed long v17
    cdef signed long v20
    cdef UH0 v21
    cdef UH0 v22
    cdef double v23
    cdef double v24
    cdef UH1 v25
    cdef UH1 v26
    cdef UH1 v27
    cdef signed long v31
    cdef signed long v32
    cdef signed long v33
    cdef signed long v35
    cdef signed long v36
    # // Union test
    # // Static a
    v1 = 1
    # // Static b
    v3 = 1074266145
    # // Dyn a
    v4 = 1
    v5 = US0_0(v4)
    if v5 == 0: # a_
        v6 = (<US0_0>v5).v0
        v11 = hash(v6)
    elif v5 == 1: # b_
        v8 = (<US0_1>v5).v0
        v9 = hash(v8)
        v11 = v9 + 33
    # // Dyn b
    v12 = 3.000000
    v13 = US0_1(v12)
    if v13 == 0: # a_
        v14 = (<US0_0>v13).v0
        v19 = hash(v14)
    elif v13 == 1: # b_
        v16 = (<US0_1>v13).v0
        v17 = hash(v16)
        v19 = v17 + 33
    # // Union rec test
    v20 = 3
    v21 = UH0_1()
    v22 = UH0_0(v20, v21)
    v23 = 2.000000
    v24 = 3.000000
    v25 = UH1_1()
    v26 = UH1_0(v24, v25)
    v27 = UH1_0(v23, v26)
    # // a
    v31 = method0(v22)
    v32 = 66 + v31
    v33 = 33 + v32
    # // b
    v35 = method1(v27)
    v36 = 1039138816 + v35
