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
cdef void method35(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned char v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    cdef double v10
    cdef bint v11
    cdef double v13
    cdef double v15
    cdef double v16
    cdef double v17
    cdef double v18
    v7 = v6 < v0
    if v7:
        v8 = v6 + 1ull
        v9 = v5[v6]
        v10 = v3[v6]
        v11 = v4 == <unsigned char>(0)
        if v11:
            v13 = v10
        else:
            v13 = -v10
        if v11:
            v15 = v2
        else:
            v15 = -v2
        v16 = v13 - v15
        v17 = v1 * v16
        v18 = v9 + v17
        v5[v6] = v18
        method35(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method36(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1ull
        v7 = v3[v4]
        v8 = v1[v4]
        v9 = v2 * v8
        v10 = v7 + v9
        v3[v4] = v10
        method36(v0, v1, v2, v3, v6)
    else:
        pass
cdef double method37(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1ull
        v7 = v1[v3]
        v8 = v2[v3]
        v9 = v8 * v7
        v10 = v4 + v9
        return method37(v0, v1, v2, v6, v10)
    else:
        return v4
cdef double method34(UH0 v0, double v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[double,ndim=1] v4, double v5, double v6, numpy.ndarray[double,ndim=1] v7, unsigned char v8):
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef double v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef unsigned long long v19
    cdef double v20
    v9 = len(v4)
    v10 = 0ull
    method35(v9, v5, v6, v7, v8, v4, v10)
    v11 = method17(v4)
    v12 = libc.math.exp(v1)
    v13 = len(v3)
    v14 = 0ull
    method36(v13, v11, v12, v3, v14)
    v15 = len(v11)
    v16 = len(v7)
    v17 = v15 == v16
    v18 = v17 == 0
    if v18:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v19 = 0ull
    v20 = 0.000000
    return method37(v15, v11, v7, v19, v20)
cdef double method38(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, signed long v8, US1 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, numpy.ndarray[double,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v36
    cdef double v29
    cdef double v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef double v37
    cdef double v38
    v22 = v20 < v0
    if v22:
        v23 = v20 + 1ull
        v24 = v17[v20]
        v25 = v18[v20]
        v26 = v24 == 0.000000
        if v26:
            v28 = v16 == 0.000000
        else:
            v28 = 0
        if v28:
            v36 = 0.000000
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v2
            v31 = US2_0(v25)
            v32 = UH0_0(v31, v3)
            del v31
            v33 = US2_0(v25)
            v34 = UH0_0(v33, v1)
            del v33
            v36 = method32(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v25, v5, v32, v4, v34, v30)
            del v32; del v34
        v37 = v36 * v24
        v38 = v21 + v37
        v19[v20] = v36
        return method38(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v38)
    else:
        return v21
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
    cdef numpy.ndarray[double,ndim=1] v101
    cdef unsigned long long v102
    cdef double v103
    cdef double v104
    cdef unsigned char v105
    cdef numpy.ndarray[signed long,ndim=1] v107
    cdef numpy.ndarray[double,ndim=1] v108
    cdef numpy.ndarray[double,ndim=1] v109
    cdef Tuple0 tmp7
    cdef double v110
    cdef double v111
    cdef numpy.ndarray[double,ndim=1] v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef bint v115
    cdef bint v116
    cdef numpy.ndarray[double,ndim=1] v117
    cdef unsigned long long v118
    cdef double v119
    cdef double v120
    cdef unsigned char v121
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
            v94 = v11 + v15
            v95 = libc.math.exp(v94)
            v96 = method17(v93)
            v97 = len(v96)
            v98 = len(v89)
            v99 = v97 == v98
            v100 = v99 != 1
            if v100:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v101 = numpy.empty(v97,dtype=numpy.float64)
            v102 = 0ull
            v103 = 0.000000
            v104 = method31(v97, v14, v15, v12, v13, v11, v0, v1, v87, v3, v7, v8, v88, v4, v5, v6, v95, v96, v89, v101, v102, v103)
            del v89; del v96
            v105 = <unsigned char>(0)
            return method34(v12, v13, v91, v92, v93, v95, v104, v101, v105)
        else:
            tmp7 = method8(v0, v89, v14)
            v107, v108, v109 = tmp7.v0, tmp7.v1, tmp7.v2
            del tmp7
            v110 = v11 + v13
            v111 = libc.math.exp(v110)
            v112 = method17(v109)
            v113 = len(v112)
            v114 = len(v89)
            v115 = v113 == v114
            v116 = v115 != 1
            if v116:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v117 = numpy.empty(v113,dtype=numpy.float64)
            v118 = 0ull
            v119 = 0.000000
            v120 = method38(v113, v14, v15, v12, v13, v11, v0, v1, v87, v3, v7, v8, v88, v4, v5, v6, v111, v112, v89, v117, v118, v119)
            del v89; del v112
            v121 = <unsigned char>(1)
            return method34(v14, v15, v107, v108, v109, v111, v120, v117, v121)
cdef double method31(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, signed long v8, US1 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, numpy.ndarray[double,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v36
    cdef double v29
    cdef double v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef double v37
    cdef double v38
    v22 = v20 < v0
    if v22:
        v23 = v20 + 1ull
        v24 = v17[v20]
        v25 = v18[v20]
        v26 = v24 == 0.000000
        if v26:
            v28 = v16 == 0.000000
        else:
            v28 = 0
        if v28:
            v36 = 0.000000
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v4
            v31 = US2_0(v25)
            v32 = UH0_0(v31, v3)
            del v31
            v33 = US2_0(v25)
            v34 = UH0_0(v33, v1)
            del v33
            v36 = method32(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v25, v5, v32, v30, v34, v2)
            del v32; del v34
        v37 = v36 * v24
        v38 = v21 + v37
        v19[v20] = v36
        return method31(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v38)
    else:
        return v21
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
    cdef numpy.ndarray[double,ndim=1] v28
    cdef unsigned long long v29
    cdef double v30
    cdef double v31
    cdef unsigned char v32
    cdef numpy.ndarray[signed long,ndim=1] v34
    cdef numpy.ndarray[double,ndim=1] v35
    cdef numpy.ndarray[double,ndim=1] v36
    cdef Tuple0 tmp8
    cdef double v37
    cdef double v38
    cdef numpy.ndarray[double,ndim=1] v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef bint v42
    cdef bint v43
    cdef numpy.ndarray[double,ndim=1] v44
    cdef unsigned long long v45
    cdef double v46
    cdef double v47
    cdef unsigned char v48
    cdef object v51
    cdef signed long v53
    cdef signed long v54
    cdef numpy.ndarray[signed long,ndim=1] v55
    cdef bint v56
    cdef numpy.ndarray[signed long,ndim=1] v57
    cdef numpy.ndarray[double,ndim=1] v58
    cdef numpy.ndarray[double,ndim=1] v59
    cdef Tuple0 tmp9
    cdef double v60
    cdef double v61
    cdef numpy.ndarray[double,ndim=1] v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    cdef bint v65
    cdef bint v66
    cdef numpy.ndarray[double,ndim=1] v67
    cdef unsigned long long v68
    cdef double v69
    cdef double v70
    cdef unsigned char v71
    cdef numpy.ndarray[signed long,ndim=1] v73
    cdef numpy.ndarray[double,ndim=1] v74
    cdef numpy.ndarray[double,ndim=1] v75
    cdef Tuple0 tmp10
    cdef double v76
    cdef double v77
    cdef numpy.ndarray[double,ndim=1] v78
    cdef unsigned long long v79
    cdef unsigned long long v80
    cdef bint v81
    cdef bint v82
    cdef numpy.ndarray[double,ndim=1] v83
    cdef unsigned long long v84
    cdef double v85
    cdef double v86
    cdef unsigned char v87
    if v9 == 0: # call
        v15 = 2l
        v16 = method30(v1, v5, v6, v7, v2, v3, v4, v15)
        v17 = v3 == <unsigned char>(0)
        if v17:
            tmp5 = method8(v0, v16, v11)
            v18, v19, v20 = tmp5.v0, tmp5.v1, tmp5.v2
            del tmp5
            v21 = v10 + v14
            v22 = libc.math.exp(v21)
            v23 = method17(v20)
            v24 = len(v23)
            v25 = len(v16)
            v26 = v24 == v25
            v27 = v26 != 1
            if v27:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v28 = numpy.empty(v24,dtype=numpy.float64)
            v29 = 0ull
            v30 = 0.000000
            v31 = method31(v24, v13, v14, v11, v12, v10, v0, v1, v15, v8, v5, v6, v7, v2, v3, v4, v22, v23, v16, v28, v29, v30)
            del v16; del v23
            v32 = <unsigned char>(0)
            return method34(v11, v12, v18, v19, v20, v22, v31, v28, v32)
        else:
            tmp8 = method8(v0, v16, v13)
            v34, v35, v36 = tmp8.v0, tmp8.v1, tmp8.v2
            del tmp8
            v37 = v10 + v12
            v38 = libc.math.exp(v37)
            v39 = method17(v36)
            v40 = len(v39)
            v41 = len(v16)
            v42 = v40 == v41
            v43 = v42 != 1
            if v43:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v44 = numpy.empty(v40,dtype=numpy.float64)
            v45 = 0ull
            v46 = 0.000000
            v47 = method38(v40, v13, v14, v11, v12, v10, v0, v1, v15, v8, v5, v6, v7, v2, v3, v4, v38, v39, v16, v44, v45, v46)
            del v16; del v39
            v48 = <unsigned char>(1)
            return method34(v13, v14, v34, v35, v36, v38, v47, v44, v48)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v53 = 1l
        v54 = v4 + 4l
        v55 = method30(v1, v5, v6, v54, v2, v3, v4, v53)
        v56 = v3 == <unsigned char>(0)
        if v56:
            tmp9 = method8(v0, v55, v11)
            v57, v58, v59 = tmp9.v0, tmp9.v1, tmp9.v2
            del tmp9
            v60 = v10 + v14
            v61 = libc.math.exp(v60)
            v62 = method17(v59)
            v63 = len(v62)
            v64 = len(v55)
            v65 = v63 == v64
            v66 = v65 != 1
            if v66:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v67 = numpy.empty(v63,dtype=numpy.float64)
            v68 = 0ull
            v69 = 0.000000
            v70 = method31(v63, v13, v14, v11, v12, v10, v0, v1, v53, v8, v5, v6, v54, v2, v3, v4, v61, v62, v55, v67, v68, v69)
            del v55; del v62
            v71 = <unsigned char>(0)
            return method34(v11, v12, v57, v58, v59, v61, v70, v67, v71)
        else:
            tmp10 = method8(v0, v55, v13)
            v73, v74, v75 = tmp10.v0, tmp10.v1, tmp10.v2
            del tmp10
            v76 = v10 + v12
            v77 = libc.math.exp(v76)
            v78 = method17(v75)
            v79 = len(v78)
            v80 = len(v55)
            v81 = v79 == v80
            v82 = v81 != 1
            if v82:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v83 = numpy.empty(v79,dtype=numpy.float64)
            v84 = 0ull
            v85 = 0.000000
            v86 = method38(v79, v13, v14, v11, v12, v10, v0, v1, v53, v8, v5, v6, v54, v2, v3, v4, v77, v78, v55, v83, v84, v85)
            del v55; del v78
            v87 = <unsigned char>(1)
            return method34(v13, v14, v73, v74, v75, v77, v86, v83, v87)
cdef double method28(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US1 v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, numpy.ndarray[double,ndim=1] v18, unsigned long long v19, double v20):
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
        v23 = v16[v19]
        v24 = v17[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v15 == 0.000000
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
            v35 = method29(v6, v7, v8, v9, v10, v11, v12, v13, v14, v24, v5, v31, v29, v33, v2)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        v18[v19] = v35
        return method28(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
cdef double method39(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US1 v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, numpy.ndarray[double,ndim=1] v18, unsigned long long v19, double v20):
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
        v23 = v16[v19]
        v24 = v17[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v15 == 0.000000
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
            v35 = method29(v6, v7, v8, v9, v10, v11, v12, v13, v14, v24, v5, v31, v4, v33, v29)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        v18[v19] = v35
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
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
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef double v28
    cdef double v29
    cdef unsigned char v30
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef numpy.ndarray[double,ndim=1] v33
    cdef numpy.ndarray[double,ndim=1] v34
    cdef Tuple0 tmp11
    cdef double v35
    cdef double v36
    cdef numpy.ndarray[double,ndim=1] v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef numpy.ndarray[double,ndim=1] v42
    cdef unsigned long long v43
    cdef double v44
    cdef double v45
    cdef unsigned char v46
    v14 = v1.v2
    v15 = v6 == <unsigned char>(0)
    if v15:
        tmp4 = method8(v0, v14, v10)
        v16, v17, v18 = tmp4.v0, tmp4.v1, tmp4.v2
        del tmp4
        v19 = v9 + v13
        v20 = libc.math.exp(v19)
        v21 = method17(v18)
        v22 = len(v21)
        v23 = len(v14)
        v24 = v22 == v23
        v25 = v24 != 1
        if v25:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v26 = numpy.empty(v22,dtype=numpy.float64)
        v27 = 0ull
        v28 = 0.000000
        v29 = method28(v22, v12, v13, v10, v11, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v20, v21, v14, v26, v27, v28)
        del v14; del v21
        v30 = <unsigned char>(0)
        return method34(v10, v11, v16, v17, v18, v20, v29, v26, v30)
    else:
        tmp11 = method8(v0, v14, v12)
        v32, v33, v34 = tmp11.v0, tmp11.v1, tmp11.v2
        del tmp11
        v35 = v9 + v11
        v36 = libc.math.exp(v35)
        v37 = method17(v34)
        v38 = len(v37)
        v39 = len(v14)
        v40 = v38 == v39
        v41 = v40 != 1
        if v41:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v42 = numpy.empty(v38,dtype=numpy.float64)
        v43 = 0ull
        v44 = 0.000000
        v45 = method39(v38, v12, v13, v10, v11, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v36, v37, v14, v42, v43, v44)
        del v14; del v37
        v46 = <unsigned char>(1)
        return method34(v12, v13, v32, v33, v34, v36, v45, v42, v46)
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
cdef double method42(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, numpy.ndarray[double,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v36
    cdef double v29
    cdef double v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef double v37
    cdef double v38
    v22 = v20 < v0
    if v22:
        v23 = v20 + 1ull
        v24 = v17[v20]
        v25 = v18[v20]
        v26 = v24 == 0.000000
        if v26:
            v28 = v16 == 0.000000
        else:
            v28 = 0
        if v28:
            v36 = 0.000000
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v2
            v31 = US2_0(v25)
            v32 = UH0_0(v31, v3)
            del v31
            v33 = US2_0(v25)
            v34 = UH0_0(v33, v1)
            del v33
            v36 = method41(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v25, v5, v32, v4, v34, v30)
            del v32; del v34
        v37 = v36 * v24
        v38 = v21 + v37
        v19[v20] = v36
        return method42(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v38)
    else:
        return v21
cdef double method41(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
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
    cdef numpy.ndarray[double,ndim=1] v57
    cdef unsigned long long v58
    cdef double v59
    cdef double v60
    cdef unsigned char v61
    cdef numpy.ndarray[signed long,ndim=1] v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef numpy.ndarray[double,ndim=1] v65
    cdef Tuple0 tmp14
    cdef double v66
    cdef double v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef bint v71
    cdef bint v72
    cdef numpy.ndarray[double,ndim=1] v73
    cdef unsigned long long v74
    cdef double v75
    cdef double v76
    cdef unsigned char v77
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
            v50 = v11 + v15
            v51 = libc.math.exp(v50)
            v52 = method17(v49)
            v53 = len(v52)
            v54 = len(v45)
            v55 = v53 == v54
            v56 = v55 != 1
            if v56:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v57 = numpy.empty(v53,dtype=numpy.float64)
            v58 = 0ull
            v59 = 0.000000
            v60 = method40(v53, v14, v15, v12, v13, v11, v0, v1, v2, v43, v7, v8, v44, v4, v5, v6, v51, v52, v45, v57, v58, v59)
            del v45; del v52
            v61 = <unsigned char>(0)
            return method34(v12, v13, v47, v48, v49, v51, v60, v57, v61)
        else:
            tmp14 = method8(v0, v45, v14)
            v63, v64, v65 = tmp14.v0, tmp14.v1, tmp14.v2
            del tmp14
            v66 = v11 + v13
            v67 = libc.math.exp(v66)
            v68 = method17(v65)
            v69 = len(v68)
            v70 = len(v45)
            v71 = v69 == v70
            v72 = v71 != 1
            if v72:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v73 = numpy.empty(v69,dtype=numpy.float64)
            v74 = 0ull
            v75 = 0.000000
            v76 = method42(v69, v14, v15, v12, v13, v11, v0, v1, v2, v43, v7, v8, v44, v4, v5, v6, v67, v68, v45, v73, v74, v75)
            del v45; del v68
            v77 = <unsigned char>(1)
            return method34(v14, v15, v63, v64, v65, v67, v76, v73, v77)
cdef double method40(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, double v16, numpy.ndarray[double,ndim=1] v17, numpy.ndarray[signed long,ndim=1] v18, numpy.ndarray[double,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v36
    cdef double v29
    cdef double v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef double v37
    cdef double v38
    v22 = v20 < v0
    if v22:
        v23 = v20 + 1ull
        v24 = v17[v20]
        v25 = v18[v20]
        v26 = v24 == 0.000000
        if v26:
            v28 = v16 == 0.000000
        else:
            v28 = 0
        if v28:
            v36 = 0.000000
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v4
            v31 = US2_0(v25)
            v32 = UH0_0(v31, v3)
            del v31
            v33 = US2_0(v25)
            v34 = UH0_0(v33, v1)
            del v33
            v36 = method41(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v25, v5, v32, v30, v34, v2)
            del v32; del v34
        v37 = v36 * v24
        v38 = v21 + v37
        v19[v20] = v36
        return method40(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v38)
    else:
        return v21
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
    cdef numpy.ndarray[double,ndim=1] v56
    cdef unsigned long long v57
    cdef double v58
    cdef double v59
    cdef unsigned char v60
    cdef numpy.ndarray[signed long,ndim=1] v62
    cdef numpy.ndarray[double,ndim=1] v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef Tuple0 tmp15
    cdef double v65
    cdef double v66
    cdef numpy.ndarray[double,ndim=1] v67
    cdef unsigned long long v68
    cdef unsigned long long v69
    cdef bint v70
    cdef bint v71
    cdef numpy.ndarray[double,ndim=1] v72
    cdef unsigned long long v73
    cdef double v74
    cdef double v75
    cdef unsigned char v76
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
            v49 = v10 + v14
            v50 = libc.math.exp(v49)
            v51 = method17(v48)
            v52 = len(v51)
            v53 = len(v44)
            v54 = v52 == v53
            v55 = v54 != 1
            if v55:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v56 = numpy.empty(v52,dtype=numpy.float64)
            v57 = 0ull
            v58 = 0.000000
            v59 = method40(v52, v13, v14, v11, v12, v10, v0, v1, v2, v42, v7, v8, v43, v4, v5, v6, v50, v51, v44, v56, v57, v58)
            del v44; del v51
            v60 = <unsigned char>(0)
            return method34(v11, v12, v46, v47, v48, v50, v59, v56, v60)
        else:
            tmp15 = method8(v0, v44, v13)
            v62, v63, v64 = tmp15.v0, tmp15.v1, tmp15.v2
            del tmp15
            v65 = v10 + v12
            v66 = libc.math.exp(v65)
            v67 = method17(v64)
            v68 = len(v67)
            v69 = len(v44)
            v70 = v68 == v69
            v71 = v70 != 1
            if v71:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v72 = numpy.empty(v68,dtype=numpy.float64)
            v73 = 0ull
            v74 = 0.000000
            v75 = method42(v68, v13, v14, v11, v12, v10, v0, v1, v2, v42, v7, v8, v43, v4, v5, v6, v66, v67, v44, v72, v73, v74)
            del v44; del v67
            v76 = <unsigned char>(1)
            return method34(v13, v14, v62, v63, v64, v66, v75, v72, v76)
cdef double method24(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, numpy.ndarray[double,ndim=1] v18, unsigned long long v19, double v20):
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
        v23 = v16[v19]
        v24 = v17[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v15 == 0.000000
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
            v35 = method25(v6, v7, v8, v9, v10, v11, v12, v13, v14, v24, v5, v31, v29, v33, v2)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        v18[v19] = v35
        return method24(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
cdef double method43(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, double v15, numpy.ndarray[double,ndim=1] v16, numpy.ndarray[signed long,ndim=1] v17, numpy.ndarray[double,ndim=1] v18, unsigned long long v19, double v20):
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
        v23 = v16[v19]
        v24 = v17[v19]
        v25 = v23 == 0.000000
        if v25:
            v27 = v15 == 0.000000
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
            v35 = method25(v6, v7, v8, v9, v10, v11, v12, v13, v14, v24, v5, v31, v4, v33, v29)
            del v31; del v33
        v36 = v35 * v23
        v37 = v20 + v36
        v18[v19] = v35
        return method43(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v37)
    else:
        return v20
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
    cdef numpy.ndarray[double,ndim=1] v27
    cdef unsigned long long v28
    cdef double v29
    cdef double v30
    cdef unsigned char v31
    cdef numpy.ndarray[signed long,ndim=1] v33
    cdef numpy.ndarray[double,ndim=1] v34
    cdef numpy.ndarray[double,ndim=1] v35
    cdef Tuple0 tmp16
    cdef double v36
    cdef double v37
    cdef numpy.ndarray[double,ndim=1] v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef bint v41
    cdef bint v42
    cdef numpy.ndarray[double,ndim=1] v43
    cdef unsigned long long v44
    cdef double v45
    cdef double v46
    cdef unsigned char v47
    cdef object v50
    cdef signed long v52
    cdef unsigned char v53
    cdef signed long v54
    cdef unsigned char v55
    cdef signed long v56
    cdef numpy.ndarray[signed long,ndim=1] v57
    cdef bint v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef numpy.ndarray[double,ndim=1] v60
    cdef numpy.ndarray[double,ndim=1] v61
    cdef Tuple0 tmp17
    cdef double v62
    cdef double v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef bint v67
    cdef bint v68
    cdef numpy.ndarray[double,ndim=1] v69
    cdef unsigned long long v70
    cdef double v71
    cdef double v72
    cdef unsigned char v73
    cdef numpy.ndarray[signed long,ndim=1] v75
    cdef numpy.ndarray[double,ndim=1] v76
    cdef numpy.ndarray[double,ndim=1] v77
    cdef Tuple0 tmp18
    cdef double v78
    cdef double v79
    cdef numpy.ndarray[double,ndim=1] v80
    cdef unsigned long long v81
    cdef unsigned long long v82
    cdef bint v83
    cdef bint v84
    cdef numpy.ndarray[double,ndim=1] v85
    cdef unsigned long long v86
    cdef double v87
    cdef double v88
    cdef unsigned char v89
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
            v20 = v6 + v10
            v21 = libc.math.exp(v20)
            v22 = method17(v19)
            v23 = len(v22)
            v24 = len(v15)
            v25 = v23 == v24
            v26 = v25 != 1
            if v26:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v27 = numpy.empty(v23,dtype=numpy.float64)
            v28 = 0ull
            v29 = 0.000000
            v30 = method24(v23, v9, v10, v7, v8, v6, v0, v3, v4, v11, v1, v14, v13, v2, v12, v21, v22, v15, v27, v28, v29)
            del v15; del v22
            v31 = <unsigned char>(0)
            return method34(v7, v8, v17, v18, v19, v21, v30, v27, v31)
        else:
            tmp16 = method8(v0, v15, v9)
            v33, v34, v35 = tmp16.v0, tmp16.v1, tmp16.v2
            del tmp16
            v36 = v6 + v8
            v37 = libc.math.exp(v36)
            v38 = method17(v35)
            v39 = len(v38)
            v40 = len(v15)
            v41 = v39 == v40
            v42 = v41 != 1
            if v42:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v43 = numpy.empty(v39,dtype=numpy.float64)
            v44 = 0ull
            v45 = 0.000000
            v46 = method43(v39, v9, v10, v7, v8, v6, v0, v3, v4, v11, v1, v14, v13, v2, v12, v37, v38, v15, v43, v44, v45)
            del v15; del v38
            v47 = <unsigned char>(1)
            return method34(v9, v10, v33, v34, v35, v37, v46, v43, v47)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v52 = 1l
        v53 = <unsigned char>(1)
        v54 = 1l
        v55 = <unsigned char>(0)
        v56 = 3l
        v57 = method30(v3, v1, v55, v56, v2, v53, v54, v52)
        v58 = v53 == <unsigned char>(0)
        if v58:
            tmp17 = method8(v0, v57, v7)
            v59, v60, v61 = tmp17.v0, tmp17.v1, tmp17.v2
            del tmp17
            v62 = v6 + v10
            v63 = libc.math.exp(v62)
            v64 = method17(v61)
            v65 = len(v64)
            v66 = len(v57)
            v67 = v65 == v66
            v68 = v67 != 1
            if v68:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v69 = numpy.empty(v65,dtype=numpy.float64)
            v70 = 0ull
            v71 = 0.000000
            v72 = method40(v65, v9, v10, v7, v8, v6, v0, v3, v4, v52, v1, v55, v56, v2, v53, v54, v63, v64, v57, v69, v70, v71)
            del v57; del v64
            v73 = <unsigned char>(0)
            return method34(v7, v8, v59, v60, v61, v63, v72, v69, v73)
        else:
            tmp18 = method8(v0, v57, v9)
            v75, v76, v77 = tmp18.v0, tmp18.v1, tmp18.v2
            del tmp18
            v78 = v6 + v8
            v79 = libc.math.exp(v78)
            v80 = method17(v77)
            v81 = len(v80)
            v82 = len(v57)
            v83 = v81 == v82
            v84 = v83 != 1
            if v84:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v85 = numpy.empty(v81,dtype=numpy.float64)
            v86 = 0ull
            v87 = 0.000000
            v88 = method42(v81, v9, v10, v7, v8, v6, v0, v3, v4, v52, v1, v55, v56, v2, v53, v54, v79, v80, v57, v85, v86, v87)
            del v57; del v80
            v89 = <unsigned char>(1)
            return method34(v9, v10, v75, v76, v77, v79, v88, v85, v89)
cdef double method21(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, Mut0 v6, US1 v7, US1 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, double v11, numpy.ndarray[double,ndim=1] v12, numpy.ndarray[signed long,ndim=1] v13, numpy.ndarray[double,ndim=1] v14, unsigned long long v15, double v16):
    cdef bint v17
    cdef unsigned long long v18
    cdef double v19
    cdef US0 v20
    cdef bint v21
    cdef bint v23
    cdef double v31
    cdef double v24
    cdef double v25
    cdef US2 v26
    cdef UH0 v27
    cdef US2 v28
    cdef UH0 v29
    cdef double v32
    cdef double v33
    v17 = v15 < v0
    if v17:
        v18 = v15 + 1ull
        v19 = v12[v15]
        v20 = v13[v15]
        v21 = v19 == 0.000000
        if v21:
            v23 = v11 == 0.000000
        else:
            v23 = 0
        if v23:
            v31 = 0.000000
        else:
            v24 = libc.math.log(v19)
            v25 = v24 + v4
            v26 = US2_0(v20)
            v27 = UH0_0(v26, v3)
            del v26
            v28 = US2_0(v20)
            v29 = UH0_0(v28, v1)
            del v28
            v31 = method22(v6, v7, v8, v9, v10, v20, v5, v27, v25, v29, v2)
            del v27; del v29
        v32 = v31 * v19
        v33 = v16 + v32
        v14[v15] = v31
        return method21(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v18, v33)
    else:
        return v16
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
    cdef numpy.ndarray[double,ndim=1] v21
    cdef unsigned long long v22
    cdef double v23
    cdef double v24
    cdef unsigned char v25
    v10 = v1.v2
    tmp2 = method8(v0, v10, v6)
    v11, v12, v13 = tmp2.v0, tmp2.v1, tmp2.v2
    del tmp2
    v14 = v5 + v9
    v15 = libc.math.exp(v14)
    v16 = method17(v13)
    v17 = len(v16)
    v18 = len(v10)
    v19 = v17 == v18
    v20 = v19 != 1
    if v20:
        raise Exception("The two arrays have to have the same size.")
    else:
        pass
    v21 = numpy.empty(v17,dtype=numpy.float64)
    v22 = 0ull
    v23 = 0.000000
    v24 = method21(v17, v8, v9, v6, v7, v5, v0, v2, v3, v1, v4, v15, v16, v10, v21, v22, v23)
    del v10; del v16
    v25 = <unsigned char>(0)
    return method34(v6, v7, v11, v12, v13, v15, v24, v21, v25)
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
