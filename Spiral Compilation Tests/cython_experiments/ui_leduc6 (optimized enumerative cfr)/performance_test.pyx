import numpy
cimport numpy
cimport libc.math
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
ctypedef signed long US0
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
ctypedef signed long US1
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
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly object v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef void method1(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1ull
        v5 = [None]*0ull
        v1[v2] = v5
        del v5
        method1(v0, v1, v4)
    else:
        pass
cdef Mut0 method0(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0ull
    method1(v1, v3, v4)
    v5 = Mut0(v0, v3, 0ull)
    del v3
    return v5
cdef void method4(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US1 v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1ull
        v7 = v1 <= v4
        if v7:
            v8 = v6
        else:
            v8 = v4
        v9 = v2[v8]
        v3[v4] = v9
        method4(v0, v1, v2, v3, v6)
    else:
        pass
cdef unsigned long long method9(UH0 v0):
    cdef US2 v1
    cdef UH0 v2
    cdef unsigned long long v35
    cdef US0 v3
    cdef unsigned long long v13
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef US1 v19
    cdef unsigned long long v29
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef unsigned long long v44
    cdef unsigned long long v45
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # action_
            v3 = (<US2_0>v1).v0
            if v3 == 0: # call
                v4 = 0l
                v5 = 1ull + v4
                v13 = 9223372036854765835ull * v5
            elif v3 == 1: # fold
                v7 = 1l
                v8 = 1ull + v7
                v13 = 9223372036854765835ull * v8
            elif v3 == 2: # raise
                v10 = 2l
                v11 = 1ull + v10
                v13 = 9223372036854765835ull * v11
            v14 = 9223372036854775807ull + v13
            v15 = v14 * 9973ull
            v16 = 0l
            v17 = 1ull + v16
            v35 = v15 * v17
        elif v1.tag == 1: # observation_
            v19 = (<US2_1>v1).v0
            if v19 == 0: # jack
                v20 = 0l
                v21 = 1ull + v20
                v29 = 9223372036854765835ull * v21
            elif v19 == 1: # king
                v23 = 1l
                v24 = 1ull + v23
                v29 = 9223372036854765835ull * v24
            elif v19 == 2: # queen
                v26 = 2l
                v27 = 1ull + v26
                v29 = 9223372036854765835ull * v27
            v30 = 9223372036854775807ull + v29
            v31 = v30 * 9973ull
            v32 = 1l
            v33 = 1ull + v32
            v35 = v31 * v33
        del v1
        v36 = v35 * 9973ull
        v37 = method9(v2)
        del v2
        v38 = v36 + v37
        v39 = 9223372036854775807ull + v38
        v40 = v39 * 9973ull
        v41 = 0l
        v42 = 1ull + v41
        return v40 * v42
    elif v0.tag == 1: # nil
        v44 = 1l
        v45 = 1ull + v44
        return 9223372036854765835ull * v45
cdef bint method11(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef US2 v4
    cdef UH0 v5
    cdef bint v12
    cdef US0 v6
    cdef US0 v7
    cdef US1 v9
    cdef US1 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # action_
            v6 = (<US2_0>v2).v0; v7 = (<US2_0>v4).v0
            if v6 == 0 and v7 == 0: # call
                v12 = 1
            elif v6 == 1 and v7 == 1: # fold
                v12 = 1
            elif v6 == 2 and v7 == 2: # raise
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # observation_
            v9 = (<US2_1>v2).v0; v10 = (<US2_1>v4).v0
            if v9 == 0 and v10 == 0: # jack
                v12 = 1
            elif v9 == 1 and v10 == 1: # king
                v12 = 1
            elif v9 == 2 and v10 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method11(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method12(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1ull
        v1[v2] = 0.000000
        method12(v0, v1, v4)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1ull
        v5 = [None]*0ull
        v1[v2] = v5
        del v5
        method14(v0, v1, v4)
    else:
        pass
cdef void method16(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef Tuple1 tmp1
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1ull
        tmp1 = v3[v4]
        v7, v8, v9, v10, v11 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4
        del tmp1
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple1(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method16(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method15(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1ull
        v7 = v1[v4]
        v8 = len(v7)
        v9 = 0ull
        method16(v8, v2, v3, v7, v9)
        del v7
        method15(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method13(Mut0 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * 3ull
    v4 = v3 // 2ull
    v5 = v4 + 3ull
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0ull
    method14(v5, v7, v8)
    v9 = 0ull
    method15(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2ull
    v0.v0 = v11
cdef Tuple0 method10(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef Tuple1 tmp0
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v16
    cdef unsigned long long v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef unsigned long long v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef numpy.ndarray[object,ndim=1] v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef bint v35
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp0 = v4[v5]
        v8, v9, v10, v11, v12 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4
        del tmp0
        v13 = v3 == v8
        if v13:
            v15 = method11(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple0(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + 1ull
            return method10(v0, v1, v2, v3, v4, v16)
    else:
        v23 = len(v2)
        v24 = numpy.empty(v23,dtype=numpy.float64)
        v25 = 0ull
        method12(v23, v24, v25)
        v26 = numpy.empty(v23,dtype=numpy.float64)
        v27 = 0ull
        method12(v23, v26, v27)
        v4.append(Tuple1(v3, v1, v2, v26, v24))
        v28 = v0.v2
        v29 = v28 + 1ull
        v0.v2 = v29
        v30 = v0.v2
        v31 = v0.v0
        v32 = v0.v1
        v33 = len(v32)
        del v32
        v34 = v31 * v33
        v35 = v30 >= v34
        if v35:
            method13(v0)
        else:
            pass
        return Tuple0(v2, v26, v24)
cdef Tuple0 method8(Mut0 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method9(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = 0ull
    return method10(v0, v2, v1, v4, v8, v9)
cdef double method18(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef bint v8
    cdef double v9
    cdef double v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1ull
        v7 = v1[v3]
        v8 = 0.000000 >= v7
        if v8:
            v9 = 0.000000
        else:
            v9 = v7
        v10 = v9 + v4
        v2[v3] = v9
        return method18(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method19(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1ull
        v6 = v2[v3]
        v2[v3] = v1
        method19(v0, v1, v2, v5)
    else:
        pass
cdef void method20(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1ull
        v6 = v2[v3]
        v7 = v6 / v1
        v2[v3] = v7
        method20(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method17(numpy.ndarray[double,ndim=1] v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[double,ndim=1] v2
    cdef unsigned long long v3
    cdef double v4
    cdef double v5
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    v1 = len(v0)
    v2 = numpy.empty(v1,dtype=numpy.float64)
    v3 = 0ull
    v4 = 0.000000
    v5 = method18(v1, v0, v2, v3, v4)
    v6 = v5 == 0.000000
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = 1.000000 / v8
        v10 = 0ull
        method19(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = 0ull
        method20(v11, v5, v2, v12)
    return v2
cdef numpy.ndarray[signed long,ndim=1] method23(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = 0l < v6
    if v7:
        return v0.v2
    else:
        v9 = 0l == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[signed long,ndim=1] method30(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = 0l < v7
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
            v13 = 0l == v7
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
cdef signed long method33(US1 v0):
    if v0 == 0: # jack
        return 0l
    elif v0 == 1: # king
        return 2l
    elif v0 == 2: # queen
        return 1l
cdef double method34(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, signed long v8, US1 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef double v23
    cdef US0 v24
    cdef bint v25
    cdef bint v27
    cdef double v35
    cdef double v28
    cdef double v29
    cdef US2 v30
    cdef UH0 v31
    cdef US2 v32
    cdef UH0 v33
    cdef double v36
    cdef double v37
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1ull
        v23 = v17[v19]
        v24 = v18[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v16 == 0.000000
        else:
            v27 = 0
        if v27:
            v35 = 0.000000
        else:
            v28 = libc.math.log(v23)
            v29 = v28 + v2
            v30 = US2_0(v24)
            v31 = UH0_0(v30, v3)
            del v30
            v32 = US2_0(v24)
            v33 = UH0_0(v32, v1)
            del v32
            v35 = method32(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v24, v5, v31, v4, v33, v29)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        return method34(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
cdef double method32(Mut0 v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef signed long v16
    cdef signed long v17
    cdef signed long v18
    cdef bint v19
    cdef bint v21
    cdef signed long v45
    cdef bint v22
    cdef bint v23
    cdef bint v26
    cdef bint v27
    cdef signed long v28
    cdef signed long v29
    cdef bint v30
    cdef signed long v31
    cdef signed long v32
    cdef bint v33
    cdef signed long v36
    cdef bint v34
    cdef bint v37
    cdef bint v38
    cdef bint v39
    cdef bint v46
    cdef unsigned char v50
    cdef signed long v51
    cdef bint v47
    cdef bint v52
    cdef signed long v54
    cdef bint v55
    cdef signed long v57
    cdef signed long v58
    cdef bint v59
    cdef signed long v61
    cdef signed long v62
    cdef US1 v63
    cdef unsigned char v64
    cdef signed long v65
    cdef US1 v66
    cdef unsigned char v67
    cdef signed long v68
    cdef double v69
    cdef bint v70
    cdef signed long v72
    cdef bint v73
    cdef signed long v75
    cdef signed long v76
    cdef signed long v78
    cdef signed long v79
    cdef US1 v80
    cdef unsigned char v81
    cdef signed long v82
    cdef US1 v83
    cdef unsigned char v84
    cdef signed long v85
    cdef double v86
    cdef signed long v87
    cdef signed long v88
    cdef numpy.ndarray[signed long,ndim=1] v89
    cdef bint v90
    cdef numpy.ndarray[signed long,ndim=1] v91
    cdef numpy.ndarray[double,ndim=1] v92
    cdef numpy.ndarray[double,ndim=1] v93
    cdef Tuple0 tmp6
    cdef double v94
    cdef double v95
    cdef numpy.ndarray[double,ndim=1] v96
    cdef unsigned long long v97
    cdef unsigned long long v98
    cdef bint v99
    cdef bint v100
    cdef unsigned long long v101
    cdef double v102
    cdef numpy.ndarray[signed long,ndim=1] v104
    cdef numpy.ndarray[double,ndim=1] v105
    cdef numpy.ndarray[double,ndim=1] v106
    cdef Tuple0 tmp7
    cdef double v107
    cdef double v108
    cdef numpy.ndarray[double,ndim=1] v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef bint v112
    cdef bint v113
    cdef unsigned long long v114
    cdef double v115
    if v10 == 0: # call
        v16 = method33(v3)
        v17 = method33(v7)
        v18 = method33(v4)
        v19 = v17 == v16
        if v19:
            v21 = v18 == v16
        else:
            v21 = 0
        if v21:
            v22 = v17 < v18
            if v22:
                v45 = -1l
            else:
                v23 = v17 > v18
                if v23:
                    v45 = 1l
                else:
                    v45 = 0l
        else:
            if v19:
                v45 = 1l
            else:
                v26 = v18 == v16
                if v26:
                    v45 = -1l
                else:
                    v27 = v17 > v16
                    if v27:
                        v28, v29 = v17, v16
                    else:
                        v28, v29 = v16, v17
                    v30 = v18 > v16
                    if v30:
                        v31, v32 = v18, v16
                    else:
                        v31, v32 = v16, v18
                    v33 = v28 < v31
                    if v33:
                        v36 = -1l
                    else:
                        v34 = v28 > v31
                        if v34:
                            v36 = 1l
                        else:
                            v36 = 0l
                    v37 = v36 == 0l
                    if v37:
                        v38 = v29 < v32
                        if v38:
                            v45 = -1l
                        else:
                            v39 = v29 > v32
                            if v39:
                                v45 = 1l
                            else:
                                v45 = 0l
                    else:
                        v45 = v36
        v46 = v45 == 1l
        if v46:
            v50, v51 = v8, v6
        else:
            v47 = v45 == -1l
            if v47:
                v50, v51 = v5, v6
            else:
                v50, v51 = v8, 0l
        v52 = v50 == <unsigned char>(0)
        if v52:
            v54 = v51
        else:
            v54 = -v51
        v55 = v8 == <unsigned char>(0)
        if v55:
            v57 = v54
        else:
            v57 = -v54
        v58 = v57 + v6
        v59 = v5 == <unsigned char>(0)
        if v59:
            v61 = v54
        else:
            v61 = -v54
        v62 = v61 + v6
        if v55:
            v63, v64, v65, v66, v67, v68 = v7, v8, v58, v4, v5, v62
        else:
            v63, v64, v65, v66, v67, v68 = v4, v5, v62, v7, v8, v58
        v69 = <double>v54
        return v69
    elif v10 == 1: # fold
        v70 = v5 == <unsigned char>(0)
        if v70:
            v72 = v9
        else:
            v72 = -v9
        v73 = v8 == <unsigned char>(0)
        if v73:
            v75 = v72
        else:
            v75 = -v72
        v76 = v75 + v9
        if v70:
            v78 = v72
        else:
            v78 = -v72
        v79 = v78 + v6
        if v73:
            v80, v81, v82, v83, v84, v85 = v7, v8, v76, v4, v5, v79
        else:
            v80, v81, v82, v83, v84, v85 = v4, v5, v79, v7, v8, v76
        v86 = <double>v72
        return v86
    elif v10 == 2: # raise
        v87 = v2 - 1l
        v88 = v6 + 4l
        v89 = method30(v1, v7, v8, v88, v4, v5, v6, v87)
        v90 = v5 == <unsigned char>(0)
        if v90:
            tmp6 = method8(v0, v89, v12)
            v91, v92, v93 = tmp6.v0, tmp6.v1, tmp6.v2
            del tmp6
            del v91; del v92
            v94 = v11 + v15
            v95 = libc.math.exp(v94)
            v96 = method17(v93)
            del v93
            v97 = len(v96)
            v98 = len(v89)
            v99 = v97 == v98
            v100 = v99 == 0
            if v100:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v101 = 0ull
            v102 = 0.000000
            return method31(v97, v14, v15, v12, v13, v11, v0, v1, v87, v3, v7, v8, v88, v4, v5, v6, v95, v96, v89, v101, v102)
        else:
            tmp7 = method8(v0, v89, v14)
            v104, v105, v106 = tmp7.v0, tmp7.v1, tmp7.v2
            del tmp7
            del v104; del v105
            v107 = v11 + v13
            v108 = libc.math.exp(v107)
            v109 = method17(v106)
            del v106
            v110 = len(v109)
            v111 = len(v89)
            v112 = v110 == v111
            v113 = v112 == 0
            if v113:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v114 = 0ull
            v115 = 0.000000
            return method34(v110, v14, v15, v12, v13, v11, v0, v1, v87, v3, v7, v8, v88, v4, v5, v6, v108, v109, v89, v114, v115)
cdef double method31(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, signed long v8, US1 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef double v23
    cdef US0 v24
    cdef bint v25
    cdef bint v27
    cdef double v35
    cdef double v28
    cdef double v29
    cdef US2 v30
    cdef UH0 v31
    cdef US2 v32
    cdef UH0 v33
    cdef double v36
    cdef double v37
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1ull
        v23 = v17[v19]
        v24 = v18[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v16 == 0.000000
        else:
            v27 = 0
        if v27:
            v35 = 0.000000
        else:
            v28 = libc.math.log(v23)
            v29 = v28 + v4
            v30 = US2_0(v24)
            v31 = UH0_0(v30, v3)
            del v30
            v32 = US2_0(v24)
            v33 = UH0_0(v32, v1)
            del v32
            v35 = method32(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v24, v5, v31, v29, v33, v2)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        return method31(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
cdef double method29(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14):
    cdef signed long v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef Tuple0 tmp5
    cdef double v21
    cdef double v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef bint v26
    cdef bint v27
    cdef unsigned long long v28
    cdef double v29
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef numpy.ndarray[double,ndim=1] v32
    cdef numpy.ndarray[double,ndim=1] v33
    cdef Tuple0 tmp8
    cdef double v34
    cdef double v35
    cdef numpy.ndarray[double,ndim=1] v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef bint v39
    cdef bint v40
    cdef unsigned long long v41
    cdef double v42
    cdef object v45
    cdef signed long v47
    cdef signed long v48
    cdef numpy.ndarray[signed long,ndim=1] v49
    cdef bint v50
    cdef numpy.ndarray[signed long,ndim=1] v51
    cdef numpy.ndarray[double,ndim=1] v52
    cdef numpy.ndarray[double,ndim=1] v53
    cdef Tuple0 tmp9
    cdef double v54
    cdef double v55
    cdef numpy.ndarray[double,ndim=1] v56
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef bint v59
    cdef bint v60
    cdef unsigned long long v61
    cdef double v62
    cdef numpy.ndarray[signed long,ndim=1] v64
    cdef numpy.ndarray[double,ndim=1] v65
    cdef numpy.ndarray[double,ndim=1] v66
    cdef Tuple0 tmp10
    cdef double v67
    cdef double v68
    cdef numpy.ndarray[double,ndim=1] v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef bint v72
    cdef bint v73
    cdef unsigned long long v74
    cdef double v75
    if v9 == 0: # call
        v15 = 2l
        v16 = method30(v1, v5, v6, v7, v2, v3, v4, v15)
        v17 = v3 == <unsigned char>(0)
        if v17:
            tmp5 = method8(v0, v16, v11)
            v18, v19, v20 = tmp5.v0, tmp5.v1, tmp5.v2
            del tmp5
            del v18; del v19
            v21 = v10 + v14
            v22 = libc.math.exp(v21)
            v23 = method17(v20)
            del v20
            v24 = len(v23)
            v25 = len(v16)
            v26 = v24 == v25
            v27 = v26 == 0
            if v27:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v28 = 0ull
            v29 = 0.000000
            return method31(v24, v13, v14, v11, v12, v10, v0, v1, v15, v8, v5, v6, v7, v2, v3, v4, v22, v23, v16, v28, v29)
        else:
            tmp8 = method8(v0, v16, v13)
            v31, v32, v33 = tmp8.v0, tmp8.v1, tmp8.v2
            del tmp8
            del v31; del v32
            v34 = v10 + v12
            v35 = libc.math.exp(v34)
            v36 = method17(v33)
            del v33
            v37 = len(v36)
            v38 = len(v16)
            v39 = v37 == v38
            v40 = v39 == 0
            if v40:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v41 = 0ull
            v42 = 0.000000
            return method34(v37, v13, v14, v11, v12, v10, v0, v1, v15, v8, v5, v6, v7, v2, v3, v4, v35, v36, v16, v41, v42)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v47 = 1l
        v48 = v4 + 4l
        v49 = method30(v1, v5, v6, v48, v2, v3, v4, v47)
        v50 = v3 == <unsigned char>(0)
        if v50:
            tmp9 = method8(v0, v49, v11)
            v51, v52, v53 = tmp9.v0, tmp9.v1, tmp9.v2
            del tmp9
            del v51; del v52
            v54 = v10 + v14
            v55 = libc.math.exp(v54)
            v56 = method17(v53)
            del v53
            v57 = len(v56)
            v58 = len(v49)
            v59 = v57 == v58
            v60 = v59 == 0
            if v60:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v61 = 0ull
            v62 = 0.000000
            return method31(v57, v13, v14, v11, v12, v10, v0, v1, v47, v8, v5, v6, v48, v2, v3, v4, v55, v56, v49, v61, v62)
        else:
            tmp10 = method8(v0, v49, v13)
            v64, v65, v66 = tmp10.v0, tmp10.v1, tmp10.v2
            del tmp10
            del v64; del v65
            v67 = v10 + v12
            v68 = libc.math.exp(v67)
            v69 = method17(v66)
            del v66
            v70 = len(v69)
            v71 = len(v49)
            v72 = v70 == v71
            v73 = v72 == 0
            if v73:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v74 = 0ull
            v75 = 0.000000
            return method34(v70, v13, v14, v11, v12, v10, v0, v1, v47, v8, v5, v6, v48, v2, v3, v4, v68, v69, v49, v74, v75)
cdef double method28(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US1 v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef double v22
    cdef US0 v23
    cdef bint v24
    cdef bint v26
    cdef double v34
    cdef double v27
    cdef double v28
    cdef US2 v29
    cdef UH0 v30
    cdef US2 v31
    cdef UH0 v32
    cdef double v35
    cdef double v36
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1ull
        v22 = v16[v18]
        v23 = v17[v18]
        v24 = v22 == 0.000000
        if v24:
            v26 = v15 == 0.000000
        else:
            v26 = 0
        if v26:
            v34 = 0.000000
        else:
            v27 = libc.math.log(v22)
            v28 = v27 + v4
            v29 = US2_0(v23)
            v30 = UH0_0(v29, v3)
            del v29
            v31 = US2_0(v23)
            v32 = UH0_0(v31, v1)
            del v31
            v34 = method29(v6, v7, v8, v9, v10, v11, v12, v13, v14, v23, v5, v30, v28, v32, v2)
            del v30; del v32
        v35 = v34 * v22
        v36 = v19 + v35
        return method28(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v36)
    else:
        return v19
cdef double method35(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US1 v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef double v22
    cdef US0 v23
    cdef bint v24
    cdef bint v26
    cdef double v34
    cdef double v27
    cdef double v28
    cdef US2 v29
    cdef UH0 v30
    cdef US2 v31
    cdef UH0 v32
    cdef double v35
    cdef double v36
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1ull
        v22 = v16[v18]
        v23 = v17[v18]
        v24 = v22 == 0.000000
        if v24:
            v26 = v15 == 0.000000
        else:
            v26 = 0
        if v26:
            v34 = 0.000000
        else:
            v27 = libc.math.log(v22)
            v28 = v27 + v2
            v29 = US2_0(v23)
            v30 = UH0_0(v29, v3)
            del v29
            v31 = US2_0(v23)
            v32 = UH0_0(v31, v1)
            del v31
            v34 = method29(v6, v7, v8, v9, v10, v11, v12, v13, v14, v23, v5, v30, v4, v32, v28)
            del v30; del v32
        v35 = v34 * v22
        v36 = v19 + v35
        return method35(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v36)
    else:
        return v19
cdef double method27(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, double v9, UH0 v10, double v11, UH0 v12, double v13):
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef bint v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef numpy.ndarray[double,ndim=1] v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef Tuple0 tmp4
    cdef double v19
    cdef double v20
    cdef numpy.ndarray[double,ndim=1] v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned long long v26
    cdef double v27
    cdef numpy.ndarray[signed long,ndim=1] v29
    cdef numpy.ndarray[double,ndim=1] v30
    cdef numpy.ndarray[double,ndim=1] v31
    cdef Tuple0 tmp11
    cdef double v32
    cdef double v33
    cdef numpy.ndarray[double,ndim=1] v34
    cdef unsigned long long v35
    cdef unsigned long long v36
    cdef bint v37
    cdef bint v38
    cdef unsigned long long v39
    cdef double v40
    v14 = v1.v2
    v15 = v6 == <unsigned char>(0)
    if v15:
        tmp4 = method8(v0, v14, v10)
        v16, v17, v18 = tmp4.v0, tmp4.v1, tmp4.v2
        del tmp4
        del v16; del v17
        v19 = v9 + v13
        v20 = libc.math.exp(v19)
        v21 = method17(v18)
        del v18
        v22 = len(v21)
        v23 = len(v14)
        v24 = v22 == v23
        v25 = v24 == 0
        if v25:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v26 = 0ull
        v27 = 0.000000
        return method28(v22, v12, v13, v10, v11, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v20, v21, v14, v26, v27)
    else:
        tmp11 = method8(v0, v14, v12)
        v29, v30, v31 = tmp11.v0, tmp11.v1, tmp11.v2
        del tmp11
        del v29; del v30
        v32 = v9 + v11
        v33 = libc.math.exp(v32)
        v34 = method17(v31)
        del v31
        v35 = len(v34)
        v36 = len(v14)
        v37 = v35 == v36
        v38 = v37 == 0
        if v38:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v39 = 0ull
        v40 = 0.000000
        return method35(v35, v12, v13, v10, v11, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v33, v34, v14, v39, v40)
cdef double method26(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, double v9, UH0 v10, double v11, UH0 v12, double v13, unsigned long long v14, double v15):
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef bint v19
    cdef US1 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef US2 v27
    cdef UH0 v28
    cdef double v29
    cdef unsigned long long v30
    cdef double v31
    cdef double v33
    v16 = len(v0)
    v17 = <double>v16
    v18 = 1.000000 / v17
    v19 = v14 < v16
    if v19:
        v20 = v0[v14]
        v21 = <double>v16
        v22 = 1.000000 / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v9
        v25 = US2_1(v20)
        v26 = UH0_0(v25, v10)
        del v25
        v27 = US2_1(v20)
        v28 = UH0_0(v27, v12)
        del v27
        v29 = method27(v1, v2, v3, v4, v5, v6, v7, v8, v20, v24, v26, v11, v28, v13)
        del v26; del v28
        v30 = v14 + 1ull
        v31 = v15 + v29
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v30, v31)
    else:
        v33 = v15 * v18
        return v33
cdef double method38(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef double v23
    cdef US0 v24
    cdef bint v25
    cdef bint v27
    cdef double v35
    cdef double v28
    cdef double v29
    cdef US2 v30
    cdef UH0 v31
    cdef US2 v32
    cdef UH0 v33
    cdef double v36
    cdef double v37
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1ull
        v23 = v17[v19]
        v24 = v18[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v16 == 0.000000
        else:
            v27 = 0
        if v27:
            v35 = 0.000000
        else:
            v28 = libc.math.log(v23)
            v29 = v28 + v2
            v30 = US2_0(v24)
            v31 = UH0_0(v30, v3)
            del v30
            v32 = US2_0(v24)
            v33 = UH0_0(v32, v1)
            del v32
            v35 = method37(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v24, v5, v31, v4, v33, v29)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        return method38(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
cdef double method37(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef bint v16
    cdef US1 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef double v24
    cdef bint v26
    cdef signed long v28
    cdef bint v29
    cdef signed long v31
    cdef signed long v32
    cdef signed long v34
    cdef signed long v35
    cdef US1 v36
    cdef unsigned char v37
    cdef signed long v38
    cdef US1 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef double v42
    cdef signed long v43
    cdef signed long v44
    cdef numpy.ndarray[signed long,ndim=1] v45
    cdef bint v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef numpy.ndarray[double,ndim=1] v48
    cdef numpy.ndarray[double,ndim=1] v49
    cdef Tuple0 tmp13
    cdef double v50
    cdef double v51
    cdef numpy.ndarray[double,ndim=1] v52
    cdef unsigned long long v53
    cdef unsigned long long v54
    cdef bint v55
    cdef bint v56
    cdef unsigned long long v57
    cdef double v58
    cdef numpy.ndarray[signed long,ndim=1] v60
    cdef numpy.ndarray[double,ndim=1] v61
    cdef numpy.ndarray[double,ndim=1] v62
    cdef Tuple0 tmp14
    cdef double v63
    cdef double v64
    cdef numpy.ndarray[double,ndim=1] v65
    cdef unsigned long long v66
    cdef unsigned long long v67
    cdef bint v68
    cdef bint v69
    cdef unsigned long long v70
    cdef double v71
    if v10 == 0: # call
        v16 = v8 == <unsigned char>(0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v7, v8, v6, v4, v5, v6
        else:
            v17, v18, v19, v20, v21, v22 = v4, v5, v6, v7, v8, v6
        v23 = 0ull
        v24 = 0.000000
        return method26(v2, v0, v1, v20, v21, v22, v17, v18, v19, v11, v12, v13, v14, v15, v23, v24)
    elif v10 == 1: # fold
        v26 = v5 == <unsigned char>(0)
        if v26:
            v28 = v9
        else:
            v28 = -v9
        v29 = v8 == <unsigned char>(0)
        if v29:
            v31 = v28
        else:
            v31 = -v28
        v32 = v31 + v9
        if v26:
            v34 = v28
        else:
            v34 = -v28
        v35 = v34 + v6
        if v29:
            v36, v37, v38, v39, v40, v41 = v7, v8, v32, v4, v5, v35
        else:
            v36, v37, v38, v39, v40, v41 = v4, v5, v35, v7, v8, v32
        v42 = <double>v28
        return v42
    elif v10 == 2: # raise
        v43 = v3 - 1l
        v44 = v6 + 2l
        v45 = method30(v1, v7, v8, v44, v4, v5, v6, v43)
        v46 = v5 == <unsigned char>(0)
        if v46:
            tmp13 = method8(v0, v45, v12)
            v47, v48, v49 = tmp13.v0, tmp13.v1, tmp13.v2
            del tmp13
            del v47; del v48
            v50 = v11 + v15
            v51 = libc.math.exp(v50)
            v52 = method17(v49)
            del v49
            v53 = len(v52)
            v54 = len(v45)
            v55 = v53 == v54
            v56 = v55 == 0
            if v56:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v57 = 0ull
            v58 = 0.000000
            return method36(v53, v14, v15, v12, v13, v11, v0, v1, v2, v43, v7, v8, v44, v4, v5, v6, v51, v52, v45, v57, v58)
        else:
            tmp14 = method8(v0, v45, v14)
            v60, v61, v62 = tmp14.v0, tmp14.v1, tmp14.v2
            del tmp14
            del v60; del v61
            v63 = v11 + v13
            v64 = libc.math.exp(v63)
            v65 = method17(v62)
            del v62
            v66 = len(v65)
            v67 = len(v45)
            v68 = v66 == v67
            v69 = v68 == 0
            if v69:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v70 = 0ull
            v71 = 0.000000
            return method38(v66, v14, v15, v12, v13, v11, v0, v1, v2, v43, v7, v8, v44, v4, v5, v6, v64, v65, v45, v70, v71)
cdef double method36(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef double v23
    cdef US0 v24
    cdef bint v25
    cdef bint v27
    cdef double v35
    cdef double v28
    cdef double v29
    cdef US2 v30
    cdef UH0 v31
    cdef US2 v32
    cdef UH0 v33
    cdef double v36
    cdef double v37
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1ull
        v23 = v17[v19]
        v24 = v18[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v16 == 0.000000
        else:
            v27 = 0
        if v27:
            v35 = 0.000000
        else:
            v28 = libc.math.log(v23)
            v29 = v28 + v4
            v30 = US2_0(v24)
            v31 = UH0_0(v30, v3)
            del v30
            v32 = US2_0(v24)
            v33 = UH0_0(v32, v1)
            del v32
            v35 = method37(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v24, v5, v31, v29, v33, v2)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        return method36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
cdef double method25(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14):
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
    cdef numpy.ndarray[signed long,ndim=1] v44
    cdef bint v45
    cdef numpy.ndarray[signed long,ndim=1] v46
    cdef numpy.ndarray[double,ndim=1] v47
    cdef numpy.ndarray[double,ndim=1] v48
    cdef Tuple0 tmp12
    cdef double v49
    cdef double v50
    cdef numpy.ndarray[double,ndim=1] v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef bint v54
    cdef bint v55
    cdef unsigned long long v56
    cdef double v57
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef numpy.ndarray[double,ndim=1] v60
    cdef numpy.ndarray[double,ndim=1] v61
    cdef Tuple0 tmp15
    cdef double v62
    cdef double v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef bint v67
    cdef bint v68
    cdef unsigned long long v69
    cdef double v70
    if v9 == 0: # call
        v15 = v8 == <unsigned char>(0)
        if v15:
            v16, v17, v18, v19, v20, v21 = v7, v8, v6, v4, v5, v6
        else:
            v16, v17, v18, v19, v20, v21 = v4, v5, v6, v7, v8, v6
        v22 = 0ull
        v23 = 0.000000
        return method26(v2, v0, v1, v19, v20, v21, v16, v17, v18, v10, v11, v12, v13, v14, v22, v23)
    elif v9 == 1: # fold
        v25 = v5 == <unsigned char>(0)
        if v25:
            v27 = v6
        else:
            v27 = -v6
        v28 = v8 == <unsigned char>(0)
        if v28:
            v30 = v27
        else:
            v30 = -v27
        v31 = v30 + v6
        if v25:
            v33 = v27
        else:
            v33 = -v27
        v34 = v33 + v6
        if v28:
            v35, v36, v37, v38, v39, v40 = v7, v8, v31, v4, v5, v34
        else:
            v35, v36, v37, v38, v39, v40 = v4, v5, v34, v7, v8, v31
        v41 = <double>v27
        return v41
    elif v9 == 2: # raise
        v42 = v3 - 1l
        v43 = v6 + 2l
        v44 = method30(v1, v7, v8, v43, v4, v5, v6, v42)
        v45 = v5 == <unsigned char>(0)
        if v45:
            tmp12 = method8(v0, v44, v11)
            v46, v47, v48 = tmp12.v0, tmp12.v1, tmp12.v2
            del tmp12
            del v46; del v47
            v49 = v10 + v14
            v50 = libc.math.exp(v49)
            v51 = method17(v48)
            del v48
            v52 = len(v51)
            v53 = len(v44)
            v54 = v52 == v53
            v55 = v54 == 0
            if v55:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v56 = 0ull
            v57 = 0.000000
            return method36(v52, v13, v14, v11, v12, v10, v0, v1, v2, v42, v7, v8, v43, v4, v5, v6, v50, v51, v44, v56, v57)
        else:
            tmp15 = method8(v0, v44, v13)
            v59, v60, v61 = tmp15.v0, tmp15.v1, tmp15.v2
            del tmp15
            del v59; del v60
            v62 = v10 + v12
            v63 = libc.math.exp(v62)
            v64 = method17(v61)
            del v61
            v65 = len(v64)
            v66 = len(v44)
            v67 = v65 == v66
            v68 = v67 == 0
            if v68:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v69 = 0ull
            v70 = 0.000000
            return method38(v65, v13, v14, v11, v12, v10, v0, v1, v2, v42, v7, v8, v43, v4, v5, v6, v63, v64, v44, v69, v70)
cdef double method24(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef double v22
    cdef US0 v23
    cdef bint v24
    cdef bint v26
    cdef double v34
    cdef double v27
    cdef double v28
    cdef US2 v29
    cdef UH0 v30
    cdef US2 v31
    cdef UH0 v32
    cdef double v35
    cdef double v36
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1ull
        v22 = v16[v18]
        v23 = v17[v18]
        v24 = v22 == 0.000000
        if v24:
            v26 = v15 == 0.000000
        else:
            v26 = 0
        if v26:
            v34 = 0.000000
        else:
            v27 = libc.math.log(v22)
            v28 = v27 + v4
            v29 = US2_0(v23)
            v30 = UH0_0(v29, v3)
            del v29
            v31 = US2_0(v23)
            v32 = UH0_0(v31, v1)
            del v31
            v34 = method25(v6, v7, v8, v9, v10, v11, v12, v13, v14, v23, v5, v30, v28, v32, v2)
            del v30; del v32
        v35 = v34 * v22
        v36 = v19 + v35
        return method24(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v36)
    else:
        return v19
cdef double method39(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef double v22
    cdef US0 v23
    cdef bint v24
    cdef bint v26
    cdef double v34
    cdef double v27
    cdef double v28
    cdef US2 v29
    cdef UH0 v30
    cdef US2 v31
    cdef UH0 v32
    cdef double v35
    cdef double v36
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1ull
        v22 = v16[v18]
        v23 = v17[v18]
        v24 = v22 == 0.000000
        if v24:
            v26 = v15 == 0.000000
        else:
            v26 = 0
        if v26:
            v34 = 0.000000
        else:
            v27 = libc.math.log(v22)
            v28 = v27 + v2
            v29 = US2_0(v23)
            v30 = UH0_0(v29, v3)
            del v29
            v31 = US2_0(v23)
            v32 = UH0_0(v31, v1)
            del v31
            v34 = method25(v6, v7, v8, v9, v10, v11, v12, v13, v14, v23, v5, v30, v4, v32, v28)
            del v30; del v32
        v35 = v34 * v22
        v36 = v19 + v35
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v36)
    else:
        return v19
cdef double method22(Mut0 v0, US1 v1, US1 v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, US0 v5, double v6, UH0 v7, double v8, UH0 v9, double v10):
    cdef signed long v11
    cdef unsigned char v12
    cdef signed long v13
    cdef unsigned char v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef bint v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef Tuple0 tmp3
    cdef double v20
    cdef double v21
    cdef numpy.ndarray[double,ndim=1] v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    cdef bint v26
    cdef unsigned long long v27
    cdef double v28
    cdef numpy.ndarray[signed long,ndim=1] v30
    cdef numpy.ndarray[double,ndim=1] v31
    cdef numpy.ndarray[double,ndim=1] v32
    cdef Tuple0 tmp16
    cdef double v33
    cdef double v34
    cdef numpy.ndarray[double,ndim=1] v35
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef bint v38
    cdef bint v39
    cdef unsigned long long v40
    cdef double v41
    cdef object v44
    cdef signed long v46
    cdef unsigned char v47
    cdef signed long v48
    cdef unsigned char v49
    cdef signed long v50
    cdef numpy.ndarray[signed long,ndim=1] v51
    cdef bint v52
    cdef numpy.ndarray[signed long,ndim=1] v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef numpy.ndarray[double,ndim=1] v55
    cdef Tuple0 tmp17
    cdef double v56
    cdef double v57
    cdef numpy.ndarray[double,ndim=1] v58
    cdef unsigned long long v59
    cdef unsigned long long v60
    cdef bint v61
    cdef bint v62
    cdef unsigned long long v63
    cdef double v64
    cdef numpy.ndarray[signed long,ndim=1] v66
    cdef numpy.ndarray[double,ndim=1] v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef Tuple0 tmp18
    cdef double v69
    cdef double v70
    cdef numpy.ndarray[double,ndim=1] v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef bint v74
    cdef bint v75
    cdef unsigned long long v76
    cdef double v77
    if v5 == 0: # call
        v11 = 2l
        v12 = <unsigned char>(1)
        v13 = 1l
        v14 = <unsigned char>(0)
        v15 = method23(v3, v1, v14, v13, v2, v12, v11)
        v16 = v12 == <unsigned char>(0)
        if v16:
            tmp3 = method8(v0, v15, v7)
            v17, v18, v19 = tmp3.v0, tmp3.v1, tmp3.v2
            del tmp3
            del v17; del v18
            v20 = v6 + v10
            v21 = libc.math.exp(v20)
            v22 = method17(v19)
            del v19
            v23 = len(v22)
            v24 = len(v15)
            v25 = v23 == v24
            v26 = v25 == 0
            if v26:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v27 = 0ull
            v28 = 0.000000
            return method24(v23, v9, v10, v7, v8, v6, v0, v3, v4, v11, v1, v14, v13, v2, v12, v21, v22, v15, v27, v28)
        else:
            tmp16 = method8(v0, v15, v9)
            v30, v31, v32 = tmp16.v0, tmp16.v1, tmp16.v2
            del tmp16
            del v30; del v31
            v33 = v6 + v8
            v34 = libc.math.exp(v33)
            v35 = method17(v32)
            del v32
            v36 = len(v35)
            v37 = len(v15)
            v38 = v36 == v37
            v39 = v38 == 0
            if v39:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v40 = 0ull
            v41 = 0.000000
            return method39(v36, v9, v10, v7, v8, v6, v0, v3, v4, v11, v1, v14, v13, v2, v12, v34, v35, v15, v40, v41)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v46 = 1l
        v47 = <unsigned char>(1)
        v48 = 1l
        v49 = <unsigned char>(0)
        v50 = 3l
        v51 = method30(v3, v1, v49, v50, v2, v47, v48, v46)
        v52 = v47 == <unsigned char>(0)
        if v52:
            tmp17 = method8(v0, v51, v7)
            v53, v54, v55 = tmp17.v0, tmp17.v1, tmp17.v2
            del tmp17
            del v53; del v54
            v56 = v6 + v10
            v57 = libc.math.exp(v56)
            v58 = method17(v55)
            del v55
            v59 = len(v58)
            v60 = len(v51)
            v61 = v59 == v60
            v62 = v61 == 0
            if v62:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v63 = 0ull
            v64 = 0.000000
            return method36(v59, v9, v10, v7, v8, v6, v0, v3, v4, v46, v1, v49, v50, v2, v47, v48, v57, v58, v51, v63, v64)
        else:
            tmp18 = method8(v0, v51, v9)
            v66, v67, v68 = tmp18.v0, tmp18.v1, tmp18.v2
            del tmp18
            del v66; del v67
            v69 = v6 + v8
            v70 = libc.math.exp(v69)
            v71 = method17(v68)
            del v68
            v72 = len(v71)
            v73 = len(v51)
            v74 = v72 == v73
            v75 = v74 == 0
            if v75:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v76 = 0ull
            v77 = 0.000000
            return method38(v72, v9, v10, v7, v8, v6, v0, v3, v4, v46, v1, v49, v50, v2, v47, v48, v70, v71, v51, v76, v77)
cdef double method21(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, US1 v7, US1 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, double v11, numpy.ndarray[double,ndim=1] v12, numpy.ndarray[signed long,ndim=1] v13, unsigned long long v14, double v15):
    cdef bint v16
    cdef unsigned long long v17
    cdef double v18
    cdef US0 v19
    cdef bint v20
    cdef bint v22
    cdef double v30
    cdef double v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef US2 v27
    cdef UH0 v28
    cdef double v31
    cdef double v32
    v16 = v14 < v0
    if v16:
        v17 = v14 + 1ull
        v18 = v12[v14]
        v19 = v13[v14]
        v20 = v18 == 0.000000
        if v20:
            v22 = v11 == 0.000000
        else:
            v22 = 0
        if v22:
            v30 = 0.000000
        else:
            v23 = libc.math.log(v18)
            v24 = v23 + v4
            v25 = US2_0(v19)
            v26 = UH0_0(v25, v3)
            del v25
            v27 = US2_0(v19)
            v28 = UH0_0(v27, v1)
            del v27
            v30 = method22(v6, v7, v8, v9, v10, v19, v5, v26, v24, v28, v2)
            del v26; del v28
        v31 = v30 * v18
        v32 = v15 + v31
        return method21(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v17, v32)
    else:
        return v15
cdef double method7(Mut0 v0, Heap0 v1, US1 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9):
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef numpy.ndarray[double,ndim=1] v13
    cdef Tuple0 tmp2
    cdef double v14
    cdef double v15
    cdef numpy.ndarray[double,ndim=1] v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef bint v19
    cdef bint v20
    cdef unsigned long long v21
    cdef double v22
    v10 = v1.v2
    tmp2 = method8(v0, v10, v6)
    v11, v12, v13 = tmp2.v0, tmp2.v1, tmp2.v2
    del tmp2
    del v11; del v12
    v14 = v5 + v9
    v15 = libc.math.exp(v14)
    v16 = method17(v13)
    del v13
    v17 = len(v16)
    v18 = len(v10)
    v19 = v17 == v18
    v20 = v19 == 0
    if v20:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v21 = 0ull
    v22 = 0.000000
    return method21(v17, v8, v9, v6, v7, v5, v0, v2, v3, v1, v4, v15, v16, v10, v21, v22)
cdef double method6(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, double v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef US1 v15
    cdef unsigned long long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef double v25
    cdef unsigned long long v26
    cdef double v27
    cdef double v29
    v11 = len(v0)
    v12 = <double>v11
    v13 = 1.000000 / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - 1ull
        v17 = numpy.empty(v16,dtype=numpy.int32)
        v18 = 0ull
        method4(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = 1.000000 / v19
        v21 = libc.math.log(v20)
        v22 = v21 + v4
        v23 = US2_1(v15)
        v24 = UH0_0(v23, v7)
        del v23
        v25 = method7(v1, v2, v3, v15, v17, v22, v5, v6, v24, v8)
        del v17; del v24
        v26 = v9 + 1ull
        v27 = v10 + v25
        return method6(v0, v1, v2, v3, v4, v5, v6, v7, v8, v26, v27)
    else:
        v29 = v10 * v13
        return v29
cdef double method5(Mut0 v0, Heap0 v1, US1 v2, numpy.ndarray[signed long,ndim=1] v3, double v4, UH0 v5, double v6, UH0 v7, double v8):
    cdef unsigned long long v9
    cdef double v10
    v9 = 0ull
    v10 = 0.000000
    return method6(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9, v10)
cdef double method3(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, UH0 v3, double v4, UH0 v5, double v6, unsigned long long v7, double v8):
    cdef unsigned long long v9
    cdef double v10
    cdef double v11
    cdef bint v12
    cdef US1 v13
    cdef unsigned long long v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef US2 v20
    cdef UH0 v21
    cdef double v22
    cdef unsigned long long v23
    cdef double v24
    cdef double v26
    v9 = len(v0)
    v10 = <double>v9
    v11 = 1.000000 / v10
    v12 = v7 < v9
    if v12:
        v13 = v0[v7]
        v14 = v9 - 1ull
        v15 = numpy.empty(v14,dtype=numpy.int32)
        v16 = 0ull
        method4(v14, v7, v0, v15, v16)
        v17 = <double>v9
        v18 = 1.000000 / v17
        v19 = libc.math.log(v18)
        v20 = US2_1(v13)
        v21 = UH0_0(v20, v3)
        del v20
        v22 = method5(v1, v2, v13, v15, v19, v21, v4, v5, v6)
        del v15; del v21
        v23 = v7 + 1ull
        v24 = v8 + v22
        return method3(v0, v1, v2, v3, v4, v5, v6, v23, v24)
    else:
        v26 = v8 * v11
        return v26
cdef void method2(Mut0 v0, unsigned long v1):
    cdef bint v2
    cdef unsigned long v3
    cdef US0 v4
    cdef US0 v5
    cdef numpy.ndarray[signed long,ndim=1] v6
    cdef US0 v7
    cdef US0 v8
    cdef US0 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef US0 v11
    cdef US0 v12
    cdef numpy.ndarray[signed long,ndim=1] v13
    cdef US0 v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef Heap0 v16
    cdef US1 v17
    cdef US1 v18
    cdef US1 v19
    cdef US1 v20
    cdef US1 v21
    cdef US1 v22
    cdef numpy.ndarray[signed long,ndim=1] v23
    cdef UH0 v24
    cdef double v25
    cdef UH0 v26
    cdef double v27
    cdef unsigned long long v28
    cdef double v29
    cdef double v30
    v2 = v1 < 100ul
    if v2:
        v3 = v1 + 1ul
        v4 = 0
        v5 = 2
        v6 = numpy.empty(2,dtype=numpy.int32)
        v6[0] = v4; v6[1] = v5
        v7 = 1
        v8 = 0
        v9 = 2
        v10 = numpy.empty(3,dtype=numpy.int32)
        v10[0] = v7; v10[1] = v8; v10[2] = v9
        v11 = 1
        v12 = 0
        v13 = numpy.empty(2,dtype=numpy.int32)
        v13[0] = v11; v13[1] = v12
        v14 = 0
        v15 = numpy.empty(1,dtype=numpy.int32)
        v15[0] = v14
        v16 = Heap0(v15, v10, v6, v13)
        del v6; del v10; del v13; del v15
        v17 = 1
        v18 = 2
        v19 = 0
        v20 = 1
        v21 = 2
        v22 = 0
        v23 = numpy.empty(6,dtype=numpy.int32)
        v23[0] = v17; v23[1] = v18; v23[2] = v19; v23[3] = v20; v23[4] = v21; v23[5] = v22
        v24 = UH0_1()
        v25 = 0.000000
        v26 = UH0_1()
        v27 = 0.000000
        v28 = 0ull
        v29 = 0.000000
        v30 = method3(v23, v0, v16, v24, v25, v26, v27, v28, v29)
        del v16; del v23; del v24; del v26
        method2(v0, v3)
    else:
        pass
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef unsigned long v3
    v0 = 3ull
    v1 = 7ull
    v2 = method0(v0, v1)
    v3 = 0ul
    method2(v2, v3)
