cdef class US0:
    cdef readonly int tag
cdef class US0_0(US0): # eQ
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # gT
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # lT
    def __init__(self): self.tag = 2
cdef class US1:
    cdef readonly int tag
cdef class US1_0(US1): # a_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 0; self.v0 = v0
cdef class US1_1(US1): # b_
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
cdef US0 method0(UH0 v0, UH0 v1):
    cdef signed long v2
    cdef UH0 v3
    cdef signed long v4
    cdef UH0 v5
    cdef char v6
    cdef US0 v12
    cdef char v8
    cdef char v13
    cdef signed long v17
    cdef signed long v18
    cdef char v19
    cdef char v21
    if v1 == 0 and v0 == 0: # cons_
        v2 = (<UH0_0>v1).v0
        v3 = (<UH0_0>v1).v1
        v4 = (<UH0_0>v0).v0
        v5 = (<UH0_0>v0).v1
        v6 = v2 < v4
        if v6:
            v12 = US0_2()
        else:
            v8 = v2 > v4
            if v8:
                v12 = US0_1()
            else:
                v12 = US0_0()
        if v12 == 0: # eQ
            v13 = 1
        elif v12 == 1: # gT
            v13 = 0
        elif v12 == 2: # lT
            v13 = 0
        if v13:
            return method0(v5, v3)
        else:
            return v12
    elif v1 == 1 and v0 == 1: # nil
        return US0_0()
    else:
        v17 = v1.tag
        v18 = v0.tag
        v19 = v17 < v18
        if v19:
            return US0_2()
        else:
            v21 = v17 > v18
            if v21:
                return US0_1()
            else:
                return US0_0()
cpdef void main():
    cdef US0 v3
    cdef signed long v4
    cdef US1 v5
    cdef US0 v21
    cdef double v7
    cdef char v8
    cdef char v9
    cdef signed long v14
    cdef char v15
    cdef char v16
    cdef double v22
    cdef US1 v23
    cdef US0 v40
    cdef signed long v26
    cdef char v27
    cdef char v28
    cdef signed long v33
    cdef char v34
    cdef char v35
    cdef signed long v41
    cdef US1 v42
    cdef double v43
    cdef US1 v44
    cdef US0 v69
    cdef signed long v45
    cdef signed long v46
    cdef char v47
    cdef char v48
    cdef double v53
    cdef double v54
    cdef char v55
    cdef char v56
    cdef signed long v61
    cdef signed long v62
    cdef char v63
    cdef char v64
    cdef signed long v70
    cdef UH0 v71
    cdef UH0 v72
    cdef signed long v73
    cdef signed long v74
    cdef UH0 v75
    cdef UH0 v76
    cdef US0 v101
    cdef signed long v83
    cdef UH0 v84
    cdef char v85
    cdef US0 v90
    cdef char v86
    cdef char v91
    cdef signed long v94
    cdef char v95
    cdef char v96
    # // Union test
    # // Static, Static
    v3 = US0_2()
    # // Dyn, Static
    v4 = 1
    v5 = US1_0(v4)
    if v5 == 1: # b_
        v7 = (<US1_1>v5).v0
        v8 = v7 < 3.000000
        if v8:
            v21 = v3
        else:
            v9 = v7 > 3.000000
            if v9:
                v21 = US0_1()
            else:
                v21 = US0_0()
    else:
        v14 = v5.tag
        v15 = v14 < 1
        if v15:
            v21 = v3
        else:
            v16 = v14 > 1
            if v16:
                v21 = US0_1()
            else:
                v21 = US0_0()
    # // Static, Dyn
    v22 = 3.000000
    v23 = US1_1(v22)
    if v23 == 0: # a_
        v26 = (<US1_0>v23).v0
        v27 = 1 < v26
        if v27:
            v40 = v3
        else:
            v28 = 1 > v26
            if v28:
                v40 = US0_1()
            else:
                v40 = US0_0()
    else:
        v33 = v23.tag
        v34 = 0 < v33
        if v34:
            v40 = v3
        else:
            v35 = 0 > v33
            if v35:
                v40 = US0_1()
            else:
                v40 = US0_0()
    # // Dyn, Dyn
    v41 = 1
    v42 = US1_0(v41)
    v43 = 3.000000
    v44 = US1_1(v43)
    if v42 == 0 and v44 == 0: # a_
        v45 = (<US1_0>v42).v0
        v46 = (<US1_0>v44).v0
        v47 = v45 < v46
        if v47:
            v69 = v3
        else:
            v48 = v45 > v46
            if v48:
                v69 = US0_1()
            else:
                v69 = US0_0()
    elif v42 == 1 and v44 == 1: # b_
        v53 = (<US1_1>v42).v0
        v54 = (<US1_1>v44).v0
        v55 = v53 < v54
        if v55:
            v69 = v3
        else:
            v56 = v53 > v54
            if v56:
                v69 = US0_1()
            else:
                v69 = US0_0()
    else:
        v61 = v42.tag
        v62 = v44.tag
        v63 = v61 < v62
        if v63:
            v69 = v3
        else:
            v64 = v61 > v62
            if v64:
                v69 = US0_1()
            else:
                v69 = US0_0()
    # // Union rec test
    v70 = 3
    v71 = UH0_1()
    v72 = UH0_0(v70, v71)
    v73 = 2
    v74 = 3
    v75 = UH0_0(v74, v71)
    v76 = UH0_0(v73, v75)
    if v76 == 0: # cons_
        v83 = (<UH0_0>v76).v0
        v84 = (<UH0_0>v76).v1
        v85 = 2 < v83
        if v85:
            v90 = v3
        else:
            v86 = 2 > v83
            if v86:
                v90 = US0_1()
            else:
                v90 = US0_0()
        if v90 == 0: # eQ
            v91 = 1
        elif v90 == 1: # gT
            v91 = 0
        elif v90 == 2: # lT
            v91 = 0
        if v91:
            v101 = method0(v84, v72)
        else:
            v101 = v90
    else:
        v94 = v76.tag
        v95 = 0 < v94
        if v95:
            v101 = v3
        else:
            v96 = 0 > v94
            if v96:
                v101 = US0_1()
            else:
                v101 = US0_0()
