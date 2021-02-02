import numpy
cimport numpy
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # empty
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # princess
    def __init__(self): self.tag = 1
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly str v0
    cdef readonly UH0 v1
    def __init__(self, str v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    cdef readonly UH0 v2
    def __init__(self, unsigned long long v0, unsigned long long v1, UH0 v2): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut0:
    cdef public US1 v0
    def __init__(self, US1 v0): self.v0 = v0
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    cdef readonly UH0 v2
    def __init__(self, unsigned long long v0, unsigned long long v1, UH0 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef void method1(unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, numpy.ndarray[object,ndim=1] v4, unsigned long long v5):
    cdef char v6
    cdef unsigned long long v7
    cdef char v8
    cdef char v10
    cdef US0 v13
    v6 = v5 < v0
    if v6:
        v7 = v5 + 1
        v8 = v3 == v1
        if v8:
            v10 = v5 == v2
        else:
            v10 = 0
        if v10:
            v13 = US0_1()
        else:
            v13 = US0_0()
        v4[v5] = v13
        method1(v0, v1, v2, v3, v4, v7)
cdef void method0(unsigned long long v0, unsigned long long v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = numpy.empty(v0,dtype=object)
        v8 = 0
        method1(v0, v1, v2, v4, v7, v8)
        v3[v4] = v7
        method0(v0, v1, v2, v3, v6)
cdef void method4(unsigned long long v0, numpy.ndarray[char,ndim=1] v1, unsigned long long v2):
    cdef char v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0
        method4(v0, v1, v4)
cdef void method3(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef numpy.ndarray[char,ndim=1] v8
    cdef unsigned long long v9
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        v7 = len(v6)
        print("v7 - ",v7)
        v8 = numpy.empty(v7,dtype=object)
        print("qqq")
        v9 = 0
        method4(v7, v8, v9)
        v2[v3] = v8
        method3(v0, v1, v2, v5)
cdef void method6(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, Mut0 v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, unsigned long long v6):
    cdef char v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef UH0 v11
    cdef Tuple0 tmp0
    cdef unsigned long long v12
    cdef char v13
    cdef char v22
    cdef unsigned long long v14
    cdef char v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef char v17
    cdef unsigned long long v18
    cdef char v26
    cdef numpy.ndarray[char,ndim=1] v23
    cdef char v24
    cdef char v33
    cdef numpy.ndarray[object,ndim=1] v27
    cdef US0 v28
    cdef char v29
    cdef UH0 v30
    cdef US1 v31
    cdef numpy.ndarray[char,ndim=1] v32
    cdef unsigned long long v34
    cdef char v35
    cdef char v44
    cdef unsigned long long v36
    cdef char v37
    cdef numpy.ndarray[object,ndim=1] v38
    cdef char v39
    cdef unsigned long long v40
    cdef char v48
    cdef numpy.ndarray[char,ndim=1] v45
    cdef char v46
    cdef char v55
    cdef numpy.ndarray[object,ndim=1] v49
    cdef US0 v50
    cdef char v51
    cdef UH0 v52
    cdef US1 v53
    cdef numpy.ndarray[char,ndim=1] v54
    cdef unsigned long long v56
    cdef char v57
    cdef char v66
    cdef unsigned long long v58
    cdef char v59
    cdef numpy.ndarray[object,ndim=1] v60
    cdef char v61
    cdef unsigned long long v62
    cdef char v70
    cdef numpy.ndarray[char,ndim=1] v67
    cdef char v68
    cdef char v77
    cdef numpy.ndarray[object,ndim=1] v71
    cdef US0 v72
    cdef char v73
    cdef UH0 v74
    cdef US1 v75
    cdef numpy.ndarray[char,ndim=1] v76
    cdef unsigned long long v78
    cdef char v87
    cdef unsigned long long v79
    cdef char v80
    cdef numpy.ndarray[object,ndim=1] v81
    cdef char v82
    cdef unsigned long long v83
    cdef char v91
    cdef numpy.ndarray[char,ndim=1] v88
    cdef char v89
    cdef char v98
    cdef numpy.ndarray[object,ndim=1] v92
    cdef US0 v93
    cdef char v94
    cdef UH0 v95
    cdef US1 v96
    cdef numpy.ndarray[char,ndim=1] v97
    cdef unsigned long long v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef numpy.ndarray[object,ndim=1] v106
    cdef unsigned long long v108
    cdef UH0 v107
    cdef unsigned long long v111
    cdef UH0 v109
    cdef unsigned long long v114
    cdef UH0 v112
    cdef unsigned long long v117
    cdef UH0 v115
    v7 = v6 < v0
    if v7:
        v8 = v6 + 1
        tmp0 = v4[v6]
        v9, v10, v11 = tmp0.v0, tmp0.v1, tmp0.v2
        v12 = v9 - 1
        v13 = 0 <= v12
        if v13:
            v14 = len(v2)
            v15 = v12 < v14
            if v15:
                v16 = v2[v12]
                v17 = 0 <= v10
                if v17:
                    v18 = len(v16)
                    v22 = v10 < v18
                else:
                    v22 = 0
            else:
                v22 = 0
        else:
            v22 = 0
        if v22:
            v23 = v1[v12]
            v24 = v23[v10]
            v26 = v24 == 0
        else:
            v26 = 0
        if v26:
            v27 = v2[v12]
            v28 = v27[v10]
            if v28.tag == 0: # empty
                v29 = 0
            elif v28.tag == 1: # princess
                v29 = 1
            if v29:
                v30 = UH0_0("UP", v11)
                v31 = US1_1(v12, v10, v30)
                v3.v0 = v31
            v32 = v1[v12]
            v32[v10] = 1
            v33 = 1
        else:
            v33 = 0
        v34 = v9 + 1
        v35 = 0 <= v34
        if v35:
            v36 = len(v2)
            v37 = v34 < v36
            if v37:
                v38 = v2[v34]
                v39 = 0 <= v10
                if v39:
                    v40 = len(v38)
                    v44 = v10 < v40
                else:
                    v44 = 0
            else:
                v44 = 0
        else:
            v44 = 0
        if v44:
            v45 = v1[v34]
            v46 = v45[v10]
            v48 = v46 == 0
        else:
            v48 = 0
        if v48:
            v49 = v2[v34]
            v50 = v49[v10]
            if v50.tag == 0: # empty
                v51 = 0
            elif v50.tag == 1: # princess
                v51 = 1
            if v51:
                v52 = UH0_0("DOWN", v11)
                v53 = US1_1(v34, v10, v52)
                v3.v0 = v53
            v54 = v1[v34]
            v54[v10] = 1
            v55 = 1
        else:
            v55 = 0
        v56 = v10 - 1
        v57 = 0 <= v9
        if v57:
            v58 = len(v2)
            v59 = v9 < v58
            if v59:
                v60 = v2[v9]
                v61 = 0 <= v56
                if v61:
                    v62 = len(v60)
                    v66 = v56 < v62
                else:
                    v66 = 0
            else:
                v66 = 0
        else:
            v66 = 0
        if v66:
            v67 = v1[v9]
            v68 = v67[v56]
            v70 = v68 == 0
        else:
            v70 = 0
        if v70:
            v71 = v2[v9]
            v72 = v71[v56]
            if v72.tag == 0: # empty
                v73 = 0
            elif v72.tag == 1: # princess
                v73 = 1
            if v73:
                v74 = UH0_0("LEFT", v11)
                v75 = US1_1(v9, v56, v74)
                v3.v0 = v75
            v76 = v1[v9]
            v76[v56] = 1
            v77 = 1
        else:
            v77 = 0
        v78 = v10 + 1
        if v57:
            v79 = len(v2)
            v80 = v9 < v79
            if v80:
                v81 = v2[v9]
                v82 = 0 <= v78
                if v82:
                    v83 = len(v81)
                    v87 = v78 < v83
                else:
                    v87 = 0
            else:
                v87 = 0
        else:
            v87 = 0
        if v87:
            v88 = v1[v9]
            v89 = v88[v78]
            v91 = v89 == 0
        else:
            v91 = 0
        if v91:
            v92 = v2[v9]
            v93 = v92[v78]
            if v93.tag == 0: # empty
                v94 = 0
            elif v93.tag == 1: # princess
                v94 = 1
            if v94:
                v95 = UH0_0("RIGHT", v11)
                v96 = US1_1(v9, v78, v95)
                v3.v0 = v96
            v97 = v1[v9]
            v97[v78] = 1
            v98 = 1
        else:
            v98 = 0
        if v33:
            v99 = 1
        else:
            v99 = 0
        if v55:
            v100 = 1
        else:
            v100 = 0
        v101 = v99 + v100
        if v77:
            v102 = 1
        else:
            v102 = 0
        v103 = v101 + v102
        if v98:
            v104 = 1
        else:
            v104 = 0
        v105 = v103 + v104
        v106 = numpy.empty(v105,dtype=object)
        if v33:
            v107 = UH0_0("UP", v11)
            v106[0] = Tuple0(v12, v10, v107)
            v108 = 1
        else:
            v108 = 0
        if v55:
            v109 = UH0_0("DOWN", v11)
            v106[v108] = Tuple0(v34, v10, v109)
            v111 = v108 + 1
        else:
            v111 = v108
        if v77:
            v112 = UH0_0("LEFT", v11)
            v106[v111] = Tuple0(v9, v56, v112)
            v114 = v111 + 1
        else:
            v114 = v111
        if v98:
            v115 = UH0_0("RIGHT", v11)
            v106[v114] = Tuple0(v9, v78, v115)
            v117 = v114 + 1
        else:
            v117 = v114
        v5[v6] = v106
        method6(v0, v1, v2, v3, v4, v5, v8)
cdef unsigned long long method7(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    v4 = v2 < v0
    if v4:
        v5 = v2 + 1
        v6 = v1[v2]
        v7 = len(v6)
        v8 = v3 + v7
        return method7(v0, v1, v5, v8)
    else:
        return v3
cdef unsigned long long method9(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Tuple0 tmp1
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1
        tmp1 = v2[v3]
        v7, v8, v9 = tmp1.v0, tmp1.v1, tmp1.v2
        v1[v4] = Tuple0(v7, v8, v9)
        v10 = v4 + 1
        return method9(v0, v1, v2, v6, v10)
    else:
        return v4
cdef unsigned long long method8(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1
        v7 = v2[v3]
        v8 = len(v7)
        v9 = 0
        v10 = method9(v8, v1, v7, v9, v4)
        return method8(v0, v1, v2, v6, v10)
    else:
        return v4
cdef UH0 method10(UH0 v0, UH0 v1):
    cdef str v2
    cdef UH0 v3
    cdef UH0 v4
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0
        v3 = (<UH0_0>v1).v1
        v4 = UH0_0(v2, v0)
        return method10(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cdef UH0 method5(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, Mut0 v2, numpy.ndarray[object,ndim=1] v3):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef US1 v15
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef UH0 v19
    cdef UH0 v20
    v4 = len(v3)
    v5 = numpy.empty(v4,dtype=object)
    v6 = 0
    method6(v4, v0, v1, v2, v3, v5, v6)
    v7 = len(v5)
    v8 = 0
    v9 = 0
    v10 = method7(v7, v5, v8, v9)
    v11 = numpy.empty(v10,dtype=object)
    v12 = 0
    v13 = 0
    v14 = method8(v7, v11, v5, v12, v13)
    v15 = v2.v0
    if v15.tag == 0: # none
        return method5(v0, v1, v2, v11)
    elif v15.tag == 1: # some_
        v17 = (<US1_1>v15).v0
        v18 = (<US1_1>v15).v1
        v19 = (<US1_1>v15).v2
        v20 = UH0_1()
        return method10(v20, v19)
cdef UH0 method2(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef Mut0 v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef UH0 v9
    v3 = len(v0)
    v4 = numpy.empty(v3,dtype=object)
    v5 = 0
    print("asd")
    method3(v3, v0, v4, v5)
    print("qwe")
    v6 = US1_0()
    v7 = Mut0(v6)
    v8 = numpy.empty(1,dtype=object)
    v9 = UH0_1()
    v8[0] = Tuple0(v1, v2, v9)
    return method5(v4, v0, v7, v8)
cdef void method11(UH0 v0):
    cdef str v1
    cdef UH0 v2
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0
        v2 = (<UH0_0>v0).v1
        print(v1)
        method11(v2)
    elif v0.tag == 1: # nil
        pass
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef UH0 v7
    v0 = 4
    v1 = 2
    v2 = 3
    print("Initing")
    v3 = numpy.empty(v0,dtype=object)
    v4 = 0
    method0(v0, v1, v2, v3, v4)
    print("Starting")
    v5 = 0
    v6 = 0
    v7 = method2(v3, v5, v6)
    print("Printing")
    method11(v7)
