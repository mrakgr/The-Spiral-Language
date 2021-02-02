cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # a_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # b_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly signed long v0
    cdef readonly UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly double v0
    cdef readonly UH1 v1
    def __init__(self, double v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef unsigned long long method0(UH0 v0):
    cdef signed long v1
    cdef UH0 v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0
        v2 = (<UH0_0>v0).v1
        v3 = hash(v1)
        v4 = v3 * 31
        v5 = method0(v2)
        v6 = v4 + v5
        v7 = 0
        v8 = 31 * v7
        return v6 + v8
    elif v0.tag == 1: # nil
        v10 = 1
        return 31 * v10
cdef unsigned long long method1(UH1 v0):
    cdef double v1
    cdef UH1 v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    if v0.tag == 0: # cons_
        v1 = (<UH1_0>v0).v0
        v2 = (<UH1_0>v0).v1
        v3 = hash(v1)
        v4 = v3 * 31
        v5 = method1(v2)
        v6 = v4 + v5
        v7 = 0
        v8 = 31 * v7
        return v6 + v8
    elif v0.tag == 1: # nil
        v10 = 1
        return 31 * v10
cpdef void main():
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned long long v22
    cdef signed long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef double v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef double v23
    cdef US0 v24
    cdef unsigned long long v35
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef double v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef signed long v36
    cdef UH0 v37
    cdef UH0 v38
    cdef double v39
    cdef double v40
    cdef UH1 v41
    cdef UH1 v42
    cdef UH1 v43
    cdef unsigned long long v46
    cdef unsigned long long v47
    cdef unsigned long long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef unsigned long long v54
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef unsigned long long v59
    cdef unsigned long long v61
    cdef unsigned long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef unsigned long long v67
    # // Union test
    # // Static a
    v1 = hash(1)
    v2 = 0
    v3 = 31 * v2
    v4 = v1 + v3
    # // Static b
    v6 = hash(3.000000)
    v7 = 1
    v8 = 31 * v7
    v9 = v6 + v8
    # // Dyn a
    v10 = 1
    v11 = US0_0(v10)
    if v11.tag == 0: # a_
        v12 = (<US0_0>v11).v0
        v13 = hash(v12)
        v14 = 0
        v15 = 31 * v14
        v22 = v13 + v15
    elif v11.tag == 1: # b_
        v17 = (<US0_1>v11).v0
        v18 = hash(v17)
        v19 = 1
        v20 = 31 * v19
        v22 = v18 + v20
    # // Dyn b
    v23 = 3.000000
    v24 = US0_1(v23)
    if v24.tag == 0: # a_
        v25 = (<US0_0>v24).v0
        v26 = hash(v25)
        v27 = 0
        v28 = 31 * v27
        v35 = v26 + v28
    elif v24.tag == 1: # b_
        v30 = (<US0_1>v24).v0
        v31 = hash(v30)
        v32 = 1
        v33 = 31 * v32
        v35 = v31 + v33
    # // Union rec test
    v36 = 3
    v37 = UH0_1()
    v38 = UH0_0(v36, v37)
    v39 = 2.000000
    v40 = 3.000000
    v41 = UH1_1()
    v42 = UH1_0(v40, v41)
    v43 = UH1_0(v39, v42)
    # // a
    v46 = hash(1)
    v47 = v46 * 31
    v49 = hash(2)
    v50 = v49 * 31
    v51 = method0(v38)
    v52 = v50 + v51
    v53 = 0
    v54 = 31 * v53
    v55 = v52 + v54
    v56 = v47 + v55
    v57 = 0
    v58 = 31 * v57
    v59 = v56 + v58
    # // b
    v61 = hash(1.000000)
    v62 = v61 * 31
    v63 = method1(v43)
    v64 = v62 + v63
    v65 = 0
    v66 = 31 * v65
    v67 = v64 + v66
