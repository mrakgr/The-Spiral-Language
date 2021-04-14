import numpy
cimport numpy
cimport libc.math
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise
    def __init__(self): self.tag = 2
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # jack
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # king
    def __init__(self): self.tag = 1
cdef class US1_2(US1): # queen
    def __init__(self): self.tag = 2
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # action_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 0; self.v0 = v0
cdef class US2_1(US2): # observation_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US2 v0
    cdef readonly UH0 v1
    def __init__(self, US2 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef void method2(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US1 v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1 <= v4
        if v7:
            v8 = v6
        else:
            v8 = v4
        v9 = v2[v8]
        v3[v4] = v9
        del v9
        method2(v0, v1, v2, v3, v6)
    else:
        pass
cdef numpy.ndarray[object,ndim=1] method8(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = 0 < v6
    if v7:
        return v0.v2
    else:
        v9 = 0 == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[object,ndim=1] method15(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = 0 < v7
    if v8:
        v10 = v6 == v3
    else:
        v10 = 0
    if v10:
        return v0.v2
    else:
        if v8:
            return v0.v1
        else:
            v13 = 0 == v7
            if v13:
                v15 = v6 == v3
            else:
                v15 = 0
            if v15:
                return v0.v0
            else:
                if v13:
                    return v0.v3
                else:
                    raise Exception("invalid action state")
cdef signed long method18(US1 v0) except *:
    if v0.tag == 0: # jack
        return 0
    elif v0.tag == 1: # king
        return 2
    elif v0.tag == 2: # queen
        return 1
cdef double method19(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, signed long v7, US1 v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19) except *:
    cdef bint v20
    cdef unsigned long long v21
    cdef US0 v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        v23 = v16 + v2
        v24 = US2_0(v22)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v22)
        v27 = UH0_0(v26, v1)
        del v26
        v28 = method17(v6, v7, v8, v9, v10, v11, v12, v13, v14, v22, v5, v25, v4, v27, v23)
        del v22; del v25; del v27
        v29 = v28 * v15
        v30 = v19 + v29
        return method19(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v30)
    else:
        return v19
cdef double method17(Heap0 v0, signed long v1, US1 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14) except *:
    cdef signed long v15
    cdef signed long v16
    cdef signed long v17
    cdef bint v18
    cdef bint v20
    cdef signed long v44
    cdef bint v21
    cdef bint v22
    cdef bint v25
    cdef bint v26
    cdef signed long v27
    cdef signed long v28
    cdef bint v29
    cdef signed long v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v35
    cdef bint v33
    cdef bint v36
    cdef bint v37
    cdef bint v38
    cdef bint v45
    cdef unsigned char v49
    cdef signed long v50
    cdef bint v46
    cdef bint v51
    cdef signed long v53
    cdef bint v54
    cdef signed long v56
    cdef signed long v57
    cdef bint v58
    cdef signed long v60
    cdef signed long v61
    cdef US1 v62
    cdef unsigned char v63
    cdef signed long v64
    cdef US1 v65
    cdef unsigned char v66
    cdef signed long v67
    cdef double v68
    cdef bint v69
    cdef signed long v71
    cdef bint v72
    cdef signed long v74
    cdef signed long v75
    cdef signed long v77
    cdef signed long v78
    cdef US1 v79
    cdef unsigned char v80
    cdef signed long v81
    cdef US1 v82
    cdef unsigned char v83
    cdef signed long v84
    cdef double v85
    cdef signed long v86
    cdef signed long v87
    cdef numpy.ndarray[object,ndim=1] v88
    cdef bint v89
    cdef unsigned long long v90
    cdef double v91
    cdef double v92
    cdef double v93
    cdef unsigned long long v94
    cdef double v95
    cdef unsigned long long v97
    cdef double v98
    cdef double v99
    cdef double v100
    cdef unsigned long long v101
    cdef double v102
    if v9.tag == 0: # call
        v15 = method18(v2)
        v16 = method18(v6)
        v17 = method18(v3)
        v18 = v16 == v15
        if v18:
            v20 = v17 == v15
        else:
            v20 = 0
        if v20:
            v21 = v16 < v17
            if v21:
                v44 = -1
            else:
                v22 = v16 > v17
                if v22:
                    v44 = 1
                else:
                    v44 = 0
        else:
            if v18:
                v44 = 1
            else:
                v25 = v17 == v15
                if v25:
                    v44 = -1
                else:
                    v26 = v16 > v15
                    if v26:
                        v27, v28 = v16, v15
                    else:
                        v27, v28 = v15, v16
                    v29 = v17 > v15
                    if v29:
                        v30, v31 = v17, v15
                    else:
                        v30, v31 = v15, v17
                    v32 = v27 < v30
                    if v32:
                        v35 = -1
                    else:
                        v33 = v27 > v30
                        if v33:
                            v35 = 1
                        else:
                            v35 = 0
                    v36 = v35 == 0
                    if v36:
                        v37 = v28 < v31
                        if v37:
                            v44 = -1
                        else:
                            v38 = v28 > v31
                            if v38:
                                v44 = 1
                            else:
                                v44 = 0
                    else:
                        v44 = v35
        v45 = v44 == 1
        if v45:
            v49, v50 = v7, v5
        else:
            v46 = v44 == -1
            if v46:
                v49, v50 = v4, v5
            else:
                v49, v50 = v7, 0
        v51 = v49 == 0
        if v51:
            v53 = v50
        else:
            v53 =  -v50
        v54 = v7 == 0
        if v54:
            v56 = v53
        else:
            v56 =  -v53
        v57 = v56 + v5
        v58 = v4 == 0
        if v58:
            v60 = v53
        else:
            v60 =  -v53
        v61 = v60 + v5
        if v54:
            v62, v63, v64, v65, v66, v67 = v6, v7, v57, v3, v4, v61
        else:
            v62, v63, v64, v65, v66, v67 = v3, v4, v61, v6, v7, v57
        del v62; del v65
        v68 = <double>v53
        return v68
    elif v9.tag == 1: # fold
        v69 = v4 == 0
        if v69:
            v71 = v8
        else:
            v71 =  -v8
        v72 = v7 == 0
        if v72:
            v74 = v71
        else:
            v74 =  -v71
        v75 = v74 + v8
        if v69:
            v77 = v71
        else:
            v77 =  -v71
        v78 = v77 + v5
        if v72:
            v79, v80, v81, v82, v83, v84 = v6, v7, v75, v3, v4, v78
        else:
            v79, v80, v81, v82, v83, v84 = v3, v4, v78, v6, v7, v75
        del v79; del v82
        v85 = <double>v71
        return v85
    elif v9.tag == 2: # raise
        v86 = v1 - 1
        v87 = v5 + 4
        v88 = method15(v0, v6, v7, v87, v3, v4, v5, v86)
        v89 = v4 == 0
        if v89:
            v90 = len(v88)
            v91 = <double>v90
            v92 = 1.000000 / v91
            v93 = libc.math.log(v92)
            v94 = 0
            v95 = 0.000000
            return method16(v90, v13, v14, v11, v12, v10, v0, v86, v2, v6, v7, v87, v3, v4, v5, v92, v93, v88, v94, v95)
        else:
            v97 = len(v88)
            v98 = <double>v97
            v99 = 1.000000 / v98
            v100 = libc.math.log(v99)
            v101 = 0
            v102 = 0.000000
            return method19(v97, v13, v14, v11, v12, v10, v0, v86, v2, v6, v7, v87, v3, v4, v5, v99, v100, v88, v101, v102)
cdef double method16(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, signed long v7, US1 v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19) except *:
    cdef bint v20
    cdef unsigned long long v21
    cdef US0 v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        v23 = v16 + v4
        v24 = US2_0(v22)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v22)
        v27 = UH0_0(v26, v1)
        del v26
        v28 = method17(v6, v7, v8, v9, v10, v11, v12, v13, v14, v22, v5, v25, v23, v27, v2)
        del v22; del v25; del v27
        v29 = v28 * v15
        v30 = v19 + v29
        return method16(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v30)
    else:
        return v19
cdef double method14(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, US0 v8, double v9, UH0 v10, double v11, UH0 v12, double v13) except *:
    cdef signed long v14
    cdef numpy.ndarray[object,ndim=1] v15
    cdef bint v16
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef unsigned long long v21
    cdef double v22
    cdef unsigned long long v24
    cdef double v25
    cdef double v26
    cdef double v27
    cdef unsigned long long v28
    cdef double v29
    cdef object v32
    cdef signed long v34
    cdef signed long v35
    cdef numpy.ndarray[object,ndim=1] v36
    cdef bint v37
    cdef unsigned long long v38
    cdef double v39
    cdef double v40
    cdef double v41
    cdef unsigned long long v42
    cdef double v43
    cdef unsigned long long v45
    cdef double v46
    cdef double v47
    cdef double v48
    cdef unsigned long long v49
    cdef double v50
    if v8.tag == 0: # call
        v14 = 2
        v15 = method15(v0, v4, v5, v6, v1, v2, v3, v14)
        v16 = v2 == 0
        if v16:
            v17 = len(v15)
            v18 = <double>v17
            v19 = 1.000000 / v18
            v20 = libc.math.log(v19)
            v21 = 0
            v22 = 0.000000
            return method16(v17, v12, v13, v10, v11, v9, v0, v14, v7, v4, v5, v6, v1, v2, v3, v19, v20, v15, v21, v22)
        else:
            v24 = len(v15)
            v25 = <double>v24
            v26 = 1.000000 / v25
            v27 = libc.math.log(v26)
            v28 = 0
            v29 = 0.000000
            return method19(v24, v12, v13, v10, v11, v9, v0, v14, v7, v4, v5, v6, v1, v2, v3, v26, v27, v15, v28, v29)
    elif v8.tag == 1: # fold
        raise Exception("impossible")
    elif v8.tag == 2: # raise
        v34 = 1
        v35 = v3 + 4
        v36 = method15(v0, v4, v5, v35, v1, v2, v3, v34)
        v37 = v2 == 0
        if v37:
            v38 = len(v36)
            v39 = <double>v38
            v40 = 1.000000 / v39
            v41 = libc.math.log(v40)
            v42 = 0
            v43 = 0.000000
            return method16(v38, v12, v13, v10, v11, v9, v0, v34, v7, v4, v5, v35, v1, v2, v3, v40, v41, v36, v42, v43)
        else:
            v45 = len(v36)
            v46 = <double>v45
            v47 = 1.000000 / v46
            v48 = libc.math.log(v47)
            v49 = 0
            v50 = 0.000000
            return method19(v45, v12, v13, v10, v11, v9, v0, v34, v7, v4, v5, v35, v1, v2, v3, v47, v48, v36, v49, v50)
cdef double method13(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, double v14, double v15, numpy.ndarray[object,ndim=1] v16, unsigned long long v17, double v18) except *:
    cdef bint v19
    cdef unsigned long long v20
    cdef US0 v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef double v28
    cdef double v29
    v19 = v17 < v0
    if v19:
        v20 = v17 + 1
        v21 = v16[v17]
        v22 = v15 + v4
        v23 = US2_0(v21)
        v24 = UH0_0(v23, v3)
        del v23
        v25 = US2_0(v21)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = method14(v6, v7, v8, v9, v10, v11, v12, v13, v21, v5, v24, v22, v26, v2)
        del v21; del v24; del v26
        v28 = v27 * v14
        v29 = v18 + v28
        return method13(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v29)
    else:
        return v18
cdef double method20(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, double v14, double v15, numpy.ndarray[object,ndim=1] v16, unsigned long long v17, double v18) except *:
    cdef bint v19
    cdef unsigned long long v20
    cdef US0 v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef double v28
    cdef double v29
    v19 = v17 < v0
    if v19:
        v20 = v17 + 1
        v21 = v16[v17]
        v22 = v15 + v2
        v23 = US2_0(v21)
        v24 = UH0_0(v23, v3)
        del v23
        v25 = US2_0(v21)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = method14(v6, v7, v8, v9, v10, v11, v12, v13, v21, v5, v24, v4, v26, v22)
        del v21; del v24; del v26
        v28 = v27 * v14
        v29 = v18 + v28
        return method20(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v29)
    else:
        return v18
cdef double method12(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, double v8, UH0 v9, double v10, UH0 v11, double v12) except *:
    cdef numpy.ndarray[object,ndim=1] v13
    cdef bint v14
    cdef unsigned long long v15
    cdef double v16
    cdef double v17
    cdef double v18
    cdef unsigned long long v19
    cdef double v20
    cdef unsigned long long v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef unsigned long long v26
    cdef double v27
    v13 = v0.v2
    v14 = v5 == 0
    if v14:
        v15 = len(v13)
        v16 = <double>v15
        v17 = 1.000000 / v16
        v18 = libc.math.log(v17)
        v19 = 0
        v20 = 0.000000
        return method13(v15, v11, v12, v9, v10, v8, v0, v1, v2, v3, v4, v5, v6, v7, v17, v18, v13, v19, v20)
    else:
        v22 = len(v13)
        v23 = <double>v22
        v24 = 1.000000 / v23
        v25 = libc.math.log(v24)
        v26 = 0
        v27 = 0.000000
        return method20(v22, v11, v12, v9, v10, v8, v0, v1, v2, v3, v4, v5, v6, v7, v24, v25, v13, v26, v27)
cdef double method11(numpy.ndarray[object,ndim=1] v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, double v8, UH0 v9, double v10, UH0 v11, double v12, unsigned long long v13, double v14) except *:
    cdef unsigned long long v15
    cdef double v16
    cdef double v17
    cdef bint v18
    cdef US1 v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef unsigned long long v29
    cdef double v30
    cdef double v32
    v15 = len(v0)
    v16 = <double>v15
    v17 = 1.000000 / v16
    v18 = v13 < v15
    if v18:
        v19 = v0[v13]
        v20 = <double>v15
        v21 = 1.000000 / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v8
        v24 = US2_1(v19)
        v25 = UH0_0(v24, v9)
        del v24
        v26 = US2_1(v19)
        v27 = UH0_0(v26, v11)
        del v26
        v28 = method12(v1, v2, v3, v4, v5, v6, v7, v19, v23, v25, v10, v27, v12)
        del v19; del v25; del v27
        v29 = v13 + 1
        v30 = v14 + v28
        return method11(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v29, v30)
    else:
        v32 = v14 * v17
        return v32
cdef double method23(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19) except *:
    cdef bint v20
    cdef unsigned long long v21
    cdef US0 v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        v23 = v16 + v2
        v24 = US2_0(v22)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v22)
        v27 = UH0_0(v26, v1)
        del v26
        v28 = method22(v6, v7, v8, v9, v10, v11, v12, v13, v14, v22, v5, v25, v4, v27, v23)
        del v22; del v25; del v27
        v29 = v28 * v15
        v30 = v19 + v29
        return method23(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v30)
    else:
        return v19
cdef double method22(Heap0 v0, numpy.ndarray[object,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14) except *:
    cdef bint v15
    cdef US1 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef unsigned long long v22
    cdef double v23
    cdef bint v25
    cdef signed long v27
    cdef bint v28
    cdef signed long v30
    cdef signed long v31
    cdef signed long v33
    cdef signed long v34
    cdef US1 v35
    cdef unsigned char v36
    cdef signed long v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef double v41
    cdef signed long v42
    cdef signed long v43
    cdef numpy.ndarray[object,ndim=1] v44
    cdef bint v45
    cdef unsigned long long v46
    cdef double v47
    cdef double v48
    cdef double v49
    cdef unsigned long long v50
    cdef double v51
    cdef unsigned long long v53
    cdef double v54
    cdef double v55
    cdef double v56
    cdef unsigned long long v57
    cdef double v58
    if v9.tag == 0: # call
        v15 = v7 == 0
        if v15:
            v16, v17, v18, v19, v20, v21 = v6, v7, v5, v3, v4, v5
        else:
            v16, v17, v18, v19, v20, v21 = v3, v4, v5, v6, v7, v5
        v22 = 0
        v23 = 0.000000
        return method11(v1, v0, v19, v20, v21, v16, v17, v18, v10, v11, v12, v13, v14, v22, v23)
    elif v9.tag == 1: # fold
        v25 = v4 == 0
        if v25:
            v27 = v8
        else:
            v27 =  -v8
        v28 = v7 == 0
        if v28:
            v30 = v27
        else:
            v30 =  -v27
        v31 = v30 + v8
        if v25:
            v33 = v27
        else:
            v33 =  -v27
        v34 = v33 + v5
        if v28:
            v35, v36, v37, v38, v39, v40 = v6, v7, v31, v3, v4, v34
        else:
            v35, v36, v37, v38, v39, v40 = v3, v4, v34, v6, v7, v31
        del v35; del v38
        v41 = <double>v27
        return v41
    elif v9.tag == 2: # raise
        v42 = v2 - 1
        v43 = v5 + 2
        v44 = method15(v0, v6, v7, v43, v3, v4, v5, v42)
        v45 = v4 == 0
        if v45:
            v46 = len(v44)
            v47 = <double>v46
            v48 = 1.000000 / v47
            v49 = libc.math.log(v48)
            v50 = 0
            v51 = 0.000000
            return method21(v46, v13, v14, v11, v12, v10, v0, v1, v42, v6, v7, v43, v3, v4, v5, v48, v49, v44, v50, v51)
        else:
            v53 = len(v44)
            v54 = <double>v53
            v55 = 1.000000 / v54
            v56 = libc.math.log(v55)
            v57 = 0
            v58 = 0.000000
            return method23(v53, v13, v14, v11, v12, v10, v0, v1, v42, v6, v7, v43, v3, v4, v5, v55, v56, v44, v57, v58)
cdef double method21(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19) except *:
    cdef bint v20
    cdef unsigned long long v21
    cdef US0 v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        v23 = v16 + v4
        v24 = US2_0(v22)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v22)
        v27 = UH0_0(v26, v1)
        del v26
        v28 = method22(v6, v7, v8, v9, v10, v11, v12, v13, v14, v22, v5, v25, v23, v27, v2)
        del v22; del v25; del v27
        v29 = v28 * v15
        v30 = v19 + v29
        return method21(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v30)
    else:
        return v19
cdef double method10(Heap0 v0, numpy.ndarray[object,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US0 v8, double v9, UH0 v10, double v11, UH0 v12, double v13) except *:
    cdef bint v14
    cdef US1 v15
    cdef unsigned char v16
    cdef signed long v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef unsigned long long v21
    cdef double v22
    cdef bint v24
    cdef signed long v26
    cdef bint v27
    cdef signed long v29
    cdef signed long v30
    cdef signed long v32
    cdef signed long v33
    cdef US1 v34
    cdef unsigned char v35
    cdef signed long v36
    cdef US1 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef double v40
    cdef signed long v41
    cdef signed long v42
    cdef numpy.ndarray[object,ndim=1] v43
    cdef bint v44
    cdef unsigned long long v45
    cdef double v46
    cdef double v47
    cdef double v48
    cdef unsigned long long v49
    cdef double v50
    cdef unsigned long long v52
    cdef double v53
    cdef double v54
    cdef double v55
    cdef unsigned long long v56
    cdef double v57
    if v8.tag == 0: # call
        v14 = v7 == 0
        if v14:
            v15, v16, v17, v18, v19, v20 = v6, v7, v5, v3, v4, v5
        else:
            v15, v16, v17, v18, v19, v20 = v3, v4, v5, v6, v7, v5
        v21 = 0
        v22 = 0.000000
        return method11(v1, v0, v18, v19, v20, v15, v16, v17, v9, v10, v11, v12, v13, v21, v22)
    elif v8.tag == 1: # fold
        v24 = v4 == 0
        if v24:
            v26 = v5
        else:
            v26 =  -v5
        v27 = v7 == 0
        if v27:
            v29 = v26
        else:
            v29 =  -v26
        v30 = v29 + v5
        if v24:
            v32 = v26
        else:
            v32 =  -v26
        v33 = v32 + v5
        if v27:
            v34, v35, v36, v37, v38, v39 = v6, v7, v30, v3, v4, v33
        else:
            v34, v35, v36, v37, v38, v39 = v3, v4, v33, v6, v7, v30
        del v34; del v37
        v40 = <double>v26
        return v40
    elif v8.tag == 2: # raise
        v41 = v2 - 1
        v42 = v5 + 2
        v43 = method15(v0, v6, v7, v42, v3, v4, v5, v41)
        v44 = v4 == 0
        if v44:
            v45 = len(v43)
            v46 = <double>v45
            v47 = 1.000000 / v46
            v48 = libc.math.log(v47)
            v49 = 0
            v50 = 0.000000
            return method21(v45, v12, v13, v10, v11, v9, v0, v1, v41, v6, v7, v42, v3, v4, v5, v47, v48, v43, v49, v50)
        else:
            v52 = len(v43)
            v53 = <double>v52
            v54 = 1.000000 / v53
            v55 = libc.math.log(v54)
            v56 = 0
            v57 = 0.000000
            return method23(v52, v12, v13, v10, v11, v9, v0, v1, v41, v6, v7, v42, v3, v4, v5, v54, v55, v43, v56, v57)
cdef double method9(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, double v14, double v15, numpy.ndarray[object,ndim=1] v16, unsigned long long v17, double v18) except *:
    cdef bint v19
    cdef unsigned long long v20
    cdef US0 v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef double v28
    cdef double v29
    v19 = v17 < v0
    if v19:
        v20 = v17 + 1
        v21 = v16[v17]
        v22 = v15 + v4
        v23 = US2_0(v21)
        v24 = UH0_0(v23, v3)
        del v23
        v25 = US2_0(v21)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = method10(v6, v7, v8, v9, v10, v11, v12, v13, v21, v5, v24, v22, v26, v2)
        del v21; del v24; del v26
        v28 = v27 * v14
        v29 = v18 + v28
        return method9(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v29)
    else:
        return v18
cdef double method24(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Heap0 v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, double v14, double v15, numpy.ndarray[object,ndim=1] v16, unsigned long long v17, double v18) except *:
    cdef bint v19
    cdef unsigned long long v20
    cdef US0 v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef double v28
    cdef double v29
    v19 = v17 < v0
    if v19:
        v20 = v17 + 1
        v21 = v16[v17]
        v22 = v15 + v2
        v23 = US2_0(v21)
        v24 = UH0_0(v23, v3)
        del v23
        v25 = US2_0(v21)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = method10(v6, v7, v8, v9, v10, v11, v12, v13, v21, v5, v24, v4, v26, v22)
        del v21; del v24; del v26
        v28 = v27 * v14
        v29 = v18 + v28
        return method24(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v29)
    else:
        return v18
cdef double method7(US1 v0, US1 v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, US0 v4, double v5, UH0 v6, double v7, UH0 v8, double v9) except *:
    cdef signed long v10
    cdef unsigned char v11
    cdef signed long v12
    cdef unsigned char v13
    cdef numpy.ndarray[object,ndim=1] v14
    cdef bint v15
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef unsigned long long v20
    cdef double v21
    cdef unsigned long long v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef unsigned long long v27
    cdef double v28
    cdef object v31
    cdef signed long v33
    cdef unsigned char v34
    cdef signed long v35
    cdef unsigned char v36
    cdef signed long v37
    cdef numpy.ndarray[object,ndim=1] v38
    cdef bint v39
    cdef unsigned long long v40
    cdef double v41
    cdef double v42
    cdef double v43
    cdef unsigned long long v44
    cdef double v45
    cdef unsigned long long v47
    cdef double v48
    cdef double v49
    cdef double v50
    cdef unsigned long long v51
    cdef double v52
    if v4.tag == 0: # call
        v10 = 2
        v11 = 1
        v12 = 1
        v13 = 0
        v14 = method8(v2, v0, v13, v12, v1, v11, v10)
        v15 = v11 == 0
        if v15:
            v16 = len(v14)
            v17 = <double>v16
            v18 = 1.000000 / v17
            v19 = libc.math.log(v18)
            v20 = 0
            v21 = 0.000000
            return method9(v16, v8, v9, v6, v7, v5, v2, v3, v10, v0, v13, v12, v1, v11, v18, v19, v14, v20, v21)
        else:
            v23 = len(v14)
            v24 = <double>v23
            v25 = 1.000000 / v24
            v26 = libc.math.log(v25)
            v27 = 0
            v28 = 0.000000
            return method24(v23, v8, v9, v6, v7, v5, v2, v3, v10, v0, v13, v12, v1, v11, v25, v26, v14, v27, v28)
    elif v4.tag == 1: # fold
        raise Exception("impossible")
    elif v4.tag == 2: # raise
        v33 = 1
        v34 = 1
        v35 = 1
        v36 = 0
        v37 = 3
        v38 = method15(v2, v0, v36, v37, v1, v34, v35, v33)
        v39 = v34 == 0
        if v39:
            v40 = len(v38)
            v41 = <double>v40
            v42 = 1.000000 / v41
            v43 = libc.math.log(v42)
            v44 = 0
            v45 = 0.000000
            return method21(v40, v8, v9, v6, v7, v5, v2, v3, v33, v0, v36, v37, v1, v34, v35, v42, v43, v38, v44, v45)
        else:
            v47 = len(v38)
            v48 = <double>v47
            v49 = 1.000000 / v48
            v50 = libc.math.log(v49)
            v51 = 0
            v52 = 0.000000
            return method23(v47, v8, v9, v6, v7, v5, v2, v3, v33, v0, v36, v37, v1, v34, v35, v49, v50, v38, v51, v52)
cdef double method6(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, US1 v6, US1 v7, Heap0 v8, numpy.ndarray[object,ndim=1] v9, double v10, double v11, numpy.ndarray[object,ndim=1] v12, unsigned long long v13, double v14) except *:
    cdef bint v15
    cdef unsigned long long v16
    cdef US0 v17
    cdef double v18
    cdef US2 v19
    cdef UH0 v20
    cdef US2 v21
    cdef UH0 v22
    cdef double v23
    cdef double v24
    cdef double v25
    v15 = v13 < v0
    if v15:
        v16 = v13 + 1
        v17 = v12[v13]
        v18 = v11 + v4
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v3)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v1)
        del v21
        v23 = method7(v6, v7, v8, v9, v17, v5, v20, v18, v22, v2)
        del v17; del v20; del v22
        v24 = v23 * v10
        v25 = v14 + v24
        return method6(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v16, v25)
    else:
        return v14
cdef double method5(Heap0 v0, US1 v1, US1 v2, numpy.ndarray[object,ndim=1] v3, double v4, UH0 v5, double v6, UH0 v7, double v8) except *:
    cdef numpy.ndarray[object,ndim=1] v9
    cdef unsigned long long v10
    cdef double v11
    cdef double v12
    cdef double v13
    cdef unsigned long long v14
    cdef double v15
    v9 = v0.v2
    v10 = len(v9)
    v11 = <double>v10
    v12 = 1.000000 / v11
    v13 = libc.math.log(v12)
    v14 = 0
    v15 = 0.000000
    return method6(v10, v7, v8, v5, v6, v4, v1, v2, v0, v3, v12, v13, v9, v14, v15)
cdef double method4(numpy.ndarray[object,ndim=1] v0, Heap0 v1, US1 v2, double v3, UH0 v4, double v5, UH0 v6, double v7, unsigned long long v8, double v9) except *:
    cdef unsigned long long v10
    cdef double v11
    cdef double v12
    cdef bint v13
    cdef US1 v14
    cdef unsigned long long v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef US2 v22
    cdef UH0 v23
    cdef double v24
    cdef unsigned long long v25
    cdef double v26
    cdef double v28
    v10 = len(v0)
    v11 = <double>v10
    v12 = 1.000000 / v11
    v13 = v8 < v10
    if v13:
        v14 = v0[v8]
        v15 = v10 - 1
        v16 = numpy.empty(v15,dtype=object)
        v17 = 0
        method2(v15, v8, v0, v16, v17)
        v18 = <double>v10
        v19 = 1.000000 / v18
        v20 = libc.math.log(v19)
        v21 = v20 + v3
        v22 = US2_1(v14)
        v23 = UH0_0(v22, v6)
        del v22
        v24 = method5(v1, v2, v14, v16, v21, v4, v5, v23, v7)
        del v14; del v16; del v23
        v25 = v8 + 1
        v26 = v9 + v24
        return method4(v0, v1, v2, v3, v4, v5, v6, v7, v25, v26)
    else:
        v28 = v9 * v12
        return v28
cdef double method3(Heap0 v0, US1 v1, numpy.ndarray[object,ndim=1] v2, double v3, UH0 v4, double v5, UH0 v6, double v7) except *:
    cdef unsigned long long v8
    cdef double v9
    v8 = 0
    v9 = 0.000000
    return method4(v2, v0, v1, v3, v4, v5, v6, v7, v8, v9)
cdef double method1(numpy.ndarray[object,ndim=1] v0, Heap0 v1, UH0 v2, double v3, UH0 v4, double v5, unsigned long long v6, double v7) except *:
    cdef unsigned long long v8
    cdef double v9
    cdef double v10
    cdef bint v11
    cdef US1 v12
    cdef unsigned long long v13
    cdef numpy.ndarray[object,ndim=1] v14
    cdef unsigned long long v15
    cdef double v16
    cdef double v17
    cdef double v18
    cdef US2 v19
    cdef UH0 v20
    cdef double v21
    cdef unsigned long long v22
    cdef double v23
    cdef double v25
    v8 = len(v0)
    v9 = <double>v8
    v10 = 1.000000 / v9
    v11 = v6 < v8
    if v11:
        v12 = v0[v6]
        v13 = v8 - 1
        v14 = numpy.empty(v13,dtype=object)
        v15 = 0
        method2(v13, v6, v0, v14, v15)
        v16 = <double>v8
        v17 = 1.000000 / v16
        v18 = libc.math.log(v17)
        v19 = US2_1(v12)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = method3(v1, v12, v14, v18, v20, v3, v4, v5)
        del v12; del v14; del v20
        v22 = v6 + 1
        v23 = v7 + v21
        return method1(v0, v1, v2, v3, v4, v5, v22, v23)
    else:
        v25 = v7 * v10
        return v25
cdef void method0(unsigned long v0) except *:
    cdef bint v1
    cdef unsigned long v2
    cdef US0 v3
    cdef US0 v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef US0 v6
    cdef US0 v7
    cdef US0 v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef US0 v10
    cdef US0 v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef US0 v13
    cdef numpy.ndarray[object,ndim=1] v14
    cdef Heap0 v15
    cdef US1 v16
    cdef US1 v17
    cdef US1 v18
    cdef US1 v19
    cdef US1 v20
    cdef US1 v21
    cdef numpy.ndarray[object,ndim=1] v22
    cdef UH0 v23
    cdef double v24
    cdef UH0 v25
    cdef double v26
    cdef unsigned long long v27
    cdef double v28
    cdef double v29
    v1 = v0 < 100
    if v1:
        v2 = v0 + 1
        v3 = US0_0()
        v4 = US0_2()
        v5 = numpy.empty(2,dtype=object)
        v5[0] = v3; v5[1] = v4
        del v3; del v4
        v6 = US0_1()
        v7 = US0_0()
        v8 = US0_2()
        v9 = numpy.empty(3,dtype=object)
        v9[0] = v6; v9[1] = v7; v9[2] = v8
        del v6; del v7; del v8
        v10 = US0_1()
        v11 = US0_0()
        v12 = numpy.empty(2,dtype=object)
        v12[0] = v10; v12[1] = v11
        del v10; del v11
        v13 = US0_0()
        v14 = numpy.empty(1,dtype=object)
        v14[0] = v13
        del v13
        v15 = Heap0(v14, v9, v5, v12)
        del v5; del v9; del v12; del v14
        v16 = US1_1()
        v17 = US1_2()
        v18 = US1_0()
        v19 = US1_1()
        v20 = US1_2()
        v21 = US1_0()
        v22 = numpy.empty(6,dtype=object)
        v22[0] = v16; v22[1] = v17; v22[2] = v18; v22[3] = v19; v22[4] = v20; v22[5] = v21
        del v16; del v17; del v18; del v19; del v20; del v21
        v23 = UH0_1()
        v24 = 0.000000
        v25 = UH0_1()
        v26 = 0.000000
        v27 = 0
        v28 = 0.000000
        v29 = method1(v22, v15, v23, v24, v25, v26, v27, v28)
        del v15; del v22; del v23; del v25
        method0(v2)
    else:
        pass
cpdef void main() except *:
    cdef unsigned long v0
    v0 = 0
    method0(v0)
