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
cdef class Mut1:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    cdef public unsigned long long v3
    def __init__(self, v0, v1, v2, unsigned long long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut1 v2
    def __init__(self, unsigned long long v0, UH0 v1, Mut1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut3:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    cdef public unsigned long long v3
    cdef public object v4
    def __init__(self, v0, v1, v2, unsigned long long v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut3 v2
    def __init__(self, unsigned long long v0, UH0 v1, Mut3 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef void method1(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
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
    v4 = (<unsigned long long>0)
    method1(v1, v3, v4)
    v5 = Mut0(v0, v3, (<unsigned long long>0))
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
        v6 = v4 + (<unsigned long long>1)
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
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # fold
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # raise
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # observation_
            v19 = (<US2_1>v1).v0
            if v19 == 0: # jack
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # king
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # queen
                v26 = (<signed long>2)
                v27 = (<unsigned long long>1) + v26
                v29 = (<unsigned long long>9223372036854765835) * v27
            v30 = (<unsigned long long>9223372036854775807) + v29
            v31 = v30 * (<unsigned long long>9973)
            v32 = (<signed long>1)
            v33 = (<unsigned long long>1) + v32
            v35 = v31 * v33
        del v1
        v36 = v35 * (<unsigned long long>9973)
        v37 = method9(v2)
        del v2
        v38 = v36 + v37
        v39 = (<unsigned long long>9223372036854775807) + v38
        v40 = v39 * (<unsigned long long>9973)
        v41 = (<signed long>0)
        v42 = (<unsigned long long>1) + v41
        return v40 * v42
    elif v0.tag == 1: # nil
        v44 = (<signed long>1)
        v45 = (<unsigned long long>1) + v44
        return (<unsigned long long>9223372036854765835) * v45
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
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method12(v0, v1, v4)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
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
    cdef Mut1 v9
    cdef Tuple0 tmp1
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp1 = v3[v4]
        v7, v8, v9 = tmp1.v0, tmp1.v1, tmp1.v2
        del tmp1
        v10 = v7 % v1
        v11 = v2[v10]
        v11.append(Tuple0(v7, v8, v9))
        del v8; del v9; del v11
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
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
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
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = (<unsigned long long>0)
    method14(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method15(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Mut1 method10(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut1 v10
    cdef Tuple0 tmp0
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v14
    cdef unsigned long long v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef Mut1 v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef bint v30
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp0 = v4[v5]
        v8, v9, v10 = tmp0.v0, tmp0.v1, tmp0.v2
        del tmp0
        v11 = v3 == v8
        if v11:
            v13 = method11(v9, v1)
        else:
            v13 = 0
        del v9
        if v13:
            return v10
        else:
            del v10
            v14 = v5 + (<unsigned long long>1)
            return method10(v0, v1, v2, v3, v4, v14)
    else:
        v17 = len(v2)
        v18 = numpy.empty(v17,dtype=numpy.float64)
        v19 = (<unsigned long long>0)
        method12(v17, v18, v19)
        v20 = numpy.empty(v17,dtype=numpy.float64)
        v21 = (<unsigned long long>0)
        method12(v17, v20, v21)
        v22 = Mut1(v2, v20, v18, (<unsigned long long>1))
        del v18; del v20
        v4.append(Tuple0(v3, v1, v22))
        v23 = v0.v2
        v24 = v23 + (<unsigned long long>1)
        v0.v2 = v24
        v25 = v0.v2
        v26 = v0.v0
        v27 = v0.v1
        v28 = len(v27)
        del v27
        v29 = v26 * v28
        v30 = v25 >= v29
        if v30:
            method13(v0)
        else:
            pass
        return v22
cdef Mut1 method8(Mut0 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
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
    v9 = (<unsigned long long>0)
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
        v6 = v3 + (<unsigned long long>1)
        v7 = v1[v3]
        v8 = (<double>0.000000) >= v7
        if v8:
            v9 = (<double>0.000000)
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
        v5 = v3 + (<unsigned long long>1)
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
        v5 = v3 + (<unsigned long long>1)
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
    v3 = (<unsigned long long>0)
    v4 = (<double>0.000000)
    v5 = method18(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method19(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method20(v11, v5, v2, v12)
    return v2
cdef numpy.ndarray[signed long,ndim=1] method23(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = (<signed long>0) < v6
    if v7:
        return v0.v2
    else:
        v9 = (<signed long>0) == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[signed long,ndim=1] method30(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = (<signed long>0) < v7
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
            v13 = (<signed long>0) == v7
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
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef void method35(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned char v4, double v5, numpy.ndarray[double,ndim=1] v6, unsigned long long v7):
    cdef bint v8
    cdef unsigned long long v9
    cdef double v10
    cdef double v11
    cdef double v12
    cdef bint v13
    cdef double v15
    cdef double v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef bint v21
    cdef double v22
    v8 = v7 < v0
    if v8:
        v9 = v7 + (<unsigned long long>1)
        v10 = v6[v7]
        v11 = v5 * v1
        v12 = v3[v7]
        v13 = v4 == (<unsigned char>0)
        if v13:
            v15 = v12
        else:
            v15 = -v12
        if v13:
            v17 = v2
        else:
            v17 = -v2
        v18 = v15 - v17
        v19 = v11 * v18
        v20 = v10 + v19
        v21 = (<double>0.000000) >= v20
        if v21:
            v22 = (<double>0.000000)
        else:
            v22 = v20
        v6[v7] = v22
        method35(v0, v1, v2, v3, v4, v5, v6, v9)
    else:
        pass
cdef void method36(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, double v3, numpy.ndarray[double,ndim=1] v4, unsigned long long v5):
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef double v10
    cdef double v11
    cdef double v12
    v6 = v5 < v0
    if v6:
        v7 = v5 + (<unsigned long long>1)
        v8 = v4[v5]
        v9 = v1 * v3
        v10 = v2[v5]
        v11 = v9 * v10
        v12 = v8 + v11
        v4[v5] = v12
        method36(v0, v1, v2, v3, v4, v7)
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
        v6 = v3 + (<unsigned long long>1)
        v7 = v1[v3]
        v8 = v2[v3]
        v9 = v8 * v7
        v10 = v4 + v9
        return method37(v0, v1, v2, v6, v10)
    else:
        return v4
cdef double method34(UH0 v0, double v1, double v2, Mut1 v3, double v4, double v5, numpy.ndarray[double,ndim=1] v6, unsigned char v7):
    cdef unsigned long long v8
    cdef double v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef numpy.ndarray[double,ndim=1] v13
    cdef numpy.ndarray[double,ndim=1] v14
    cdef double v15
    cdef double v16
    cdef numpy.ndarray[double,ndim=1] v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned long long v26
    cdef double v27
    v8 = v3.v3
    v9 = <double>v8
    v10 = v3.v2
    v11 = len(v10)
    v12 = (<unsigned long long>0)
    method35(v11, v4, v5, v6, v7, v9, v10, v12)
    del v10
    v13 = v3.v2
    v14 = method17(v13)
    del v13
    v15 = libc.math.exp(v2)
    v16 = libc.math.exp(v1)
    v17 = v3.v1
    v18 = len(v17)
    v19 = (<unsigned long long>0)
    method36(v18, v9, v14, v16, v17, v19)
    del v17
    v20 = v3.v3
    v21 = v20 + (<unsigned long long>1)
    v3.v3 = v21
    v22 = len(v14)
    v23 = len(v6)
    v24 = v22 == v23
    v25 = v24 == 0
    if v25:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v26 = (<unsigned long long>0)
    v27 = (<double>0.000000)
    return method37(v22, v14, v6, v26, v27)
cdef double method38(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, signed long v10, US1 v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method32(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method38(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method32(Mut0 v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef signed long v18
    cdef signed long v19
    cdef signed long v20
    cdef bint v21
    cdef bint v23
    cdef signed long v47
    cdef bint v24
    cdef bint v25
    cdef bint v28
    cdef bint v29
    cdef signed long v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v33
    cdef signed long v34
    cdef bint v35
    cdef signed long v38
    cdef bint v36
    cdef bint v39
    cdef bint v40
    cdef bint v41
    cdef bint v48
    cdef unsigned char v52
    cdef signed long v53
    cdef bint v49
    cdef bint v54
    cdef signed long v56
    cdef bint v57
    cdef signed long v59
    cdef signed long v60
    cdef bint v61
    cdef signed long v63
    cdef signed long v64
    cdef US1 v65
    cdef unsigned char v66
    cdef signed long v67
    cdef US1 v68
    cdef unsigned char v69
    cdef signed long v70
    cdef double v71
    cdef bint v72
    cdef signed long v74
    cdef bint v75
    cdef signed long v77
    cdef signed long v78
    cdef signed long v80
    cdef signed long v81
    cdef US1 v82
    cdef unsigned char v83
    cdef signed long v84
    cdef US1 v85
    cdef unsigned char v86
    cdef signed long v87
    cdef double v88
    cdef signed long v89
    cdef signed long v90
    cdef numpy.ndarray[signed long,ndim=1] v91
    cdef bint v92
    cdef Mut1 v93
    cdef double v94
    cdef double v95
    cdef double v96
    cdef double v97
    cdef numpy.ndarray[double,ndim=1] v98
    cdef numpy.ndarray[double,ndim=1] v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef bint v102
    cdef bint v103
    cdef numpy.ndarray[double,ndim=1] v104
    cdef unsigned long long v105
    cdef double v106
    cdef double v107
    cdef unsigned char v108
    cdef Mut1 v110
    cdef double v111
    cdef double v112
    cdef double v113
    cdef double v114
    cdef numpy.ndarray[double,ndim=1] v115
    cdef numpy.ndarray[double,ndim=1] v116
    cdef unsigned long long v117
    cdef unsigned long long v118
    cdef bint v119
    cdef bint v120
    cdef unsigned long long v121
    cdef double v122
    if v10 == 0: # call
        v18 = method33(v3)
        v19 = method33(v7)
        v20 = method33(v4)
        v21 = v19 == v18
        if v21:
            v23 = v20 == v18
        else:
            v23 = 0
        if v23:
            v24 = v19 < v20
            if v24:
                v47 = (<signed long>-1)
            else:
                v25 = v19 > v20
                if v25:
                    v47 = (<signed long>1)
                else:
                    v47 = (<signed long>0)
        else:
            if v21:
                v47 = (<signed long>1)
            else:
                v28 = v20 == v18
                if v28:
                    v47 = (<signed long>-1)
                else:
                    v29 = v19 > v18
                    if v29:
                        v30, v31 = v19, v18
                    else:
                        v30, v31 = v18, v19
                    v32 = v20 > v18
                    if v32:
                        v33, v34 = v20, v18
                    else:
                        v33, v34 = v18, v20
                    v35 = v30 < v33
                    if v35:
                        v38 = (<signed long>-1)
                    else:
                        v36 = v30 > v33
                        if v36:
                            v38 = (<signed long>1)
                        else:
                            v38 = (<signed long>0)
                    v39 = v38 == (<signed long>0)
                    if v39:
                        v40 = v31 < v34
                        if v40:
                            v47 = (<signed long>-1)
                        else:
                            v41 = v31 > v34
                            if v41:
                                v47 = (<signed long>1)
                            else:
                                v47 = (<signed long>0)
                    else:
                        v47 = v38
        v48 = v47 == (<signed long>1)
        if v48:
            v52, v53 = v8, v6
        else:
            v49 = v47 == (<signed long>-1)
            if v49:
                v52, v53 = v5, v6
            else:
                v52, v53 = v8, (<signed long>0)
        v54 = v52 == (<unsigned char>0)
        if v54:
            v56 = v53
        else:
            v56 = -v53
        v57 = v8 == (<unsigned char>0)
        if v57:
            v59 = v56
        else:
            v59 = -v56
        v60 = v59 + v6
        v61 = v5 == (<unsigned char>0)
        if v61:
            v63 = v56
        else:
            v63 = -v56
        v64 = v63 + v6
        if v57:
            v65, v66, v67, v68, v69, v70 = v7, v8, v60, v4, v5, v64
        else:
            v65, v66, v67, v68, v69, v70 = v4, v5, v64, v7, v8, v60
        v71 = <double>v56
        return v71
    elif v10 == 1: # fold
        v72 = v5 == (<unsigned char>0)
        if v72:
            v74 = v9
        else:
            v74 = -v9
        v75 = v8 == (<unsigned char>0)
        if v75:
            v77 = v74
        else:
            v77 = -v74
        v78 = v77 + v9
        if v72:
            v80 = v74
        else:
            v80 = -v74
        v81 = v80 + v6
        if v75:
            v82, v83, v84, v85, v86, v87 = v7, v8, v78, v4, v5, v81
        else:
            v82, v83, v84, v85, v86, v87 = v4, v5, v81, v7, v8, v78
        v88 = <double>v74
        return v88
    elif v10 == 2: # raise
        v89 = v2 - (<signed long>1)
        v90 = v6 + (<signed long>4)
        v91 = method30(v1, v7, v8, v90, v4, v5, v6, v89)
        v92 = v5 == (<unsigned char>0)
        if v92:
            v93 = method8(v0, v91, v12)
            v94 = v11 + v17
            v95 = v11 + v16
            v96 = libc.math.exp(v94)
            v97 = libc.math.exp(v95)
            v98 = v93.v2
            v99 = method17(v98)
            del v98
            v100 = len(v99)
            v101 = len(v91)
            v102 = v100 == v101
            v103 = v102 != 1
            if v103:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v104 = numpy.empty(v100,dtype=numpy.float64)
            v105 = (<unsigned long long>0)
            v106 = (<double>0.000000)
            v107 = method31(v100, v15, v16, v17, v12, v13, v14, v11, v0, v1, v89, v3, v7, v8, v90, v4, v5, v6, v97, v99, v91, v104, v105, v106)
            del v91; del v99
            v108 = (<unsigned char>0)
            return method34(v12, v13, v14, v93, v97, v107, v104, v108)
        else:
            v110 = method8(v0, v91, v15)
            v111 = v11 + v14
            v112 = v11 + v13
            v113 = libc.math.exp(v111)
            v114 = libc.math.exp(v112)
            v115 = v110.v2
            del v110
            v116 = method17(v115)
            del v115
            v117 = len(v116)
            v118 = len(v91)
            v119 = v117 == v118
            v120 = v119 == 0
            if v120:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v121 = (<unsigned long long>0)
            v122 = (<double>0.000000)
            return method38(v117, v15, v16, v17, v12, v13, v14, v11, v0, v1, v89, v3, v7, v8, v90, v4, v5, v6, v114, v116, v91, v121, v122)
cdef double method31(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, signed long v10, US1 v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, numpy.ndarray[double,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v19[v22]
        v27 = v20[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v18 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v6
            v33 = v31 + v5
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method32(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v27, v7, v35, v33, v32, v37, v2, v3)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        v21[v22] = v39
        return method31(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method29(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef Mut1 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef numpy.ndarray[double,ndim=1] v31
    cdef unsigned long long v32
    cdef double v33
    cdef double v34
    cdef unsigned char v35
    cdef Mut1 v37
    cdef double v38
    cdef double v39
    cdef double v40
    cdef double v41
    cdef numpy.ndarray[double,ndim=1] v42
    cdef numpy.ndarray[double,ndim=1] v43
    cdef unsigned long long v44
    cdef unsigned long long v45
    cdef bint v46
    cdef bint v47
    cdef unsigned long long v48
    cdef double v49
    cdef object v52
    cdef signed long v54
    cdef signed long v55
    cdef numpy.ndarray[signed long,ndim=1] v56
    cdef bint v57
    cdef Mut1 v58
    cdef double v59
    cdef double v60
    cdef double v61
    cdef double v62
    cdef numpy.ndarray[double,ndim=1] v63
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
    cdef Mut1 v75
    cdef double v76
    cdef double v77
    cdef double v78
    cdef double v79
    cdef numpy.ndarray[double,ndim=1] v80
    cdef numpy.ndarray[double,ndim=1] v81
    cdef unsigned long long v82
    cdef unsigned long long v83
    cdef bint v84
    cdef bint v85
    cdef unsigned long long v86
    cdef double v87
    if v9 == 0: # call
        v17 = (<signed long>2)
        v18 = method30(v1, v5, v6, v7, v2, v3, v4, v17)
        v19 = v3 == (<unsigned char>0)
        if v19:
            v20 = method8(v0, v18, v11)
            v21 = v10 + v16
            v22 = v10 + v15
            v23 = libc.math.exp(v21)
            v24 = libc.math.exp(v22)
            v25 = v20.v2
            v26 = method17(v25)
            del v25
            v27 = len(v26)
            v28 = len(v18)
            v29 = v27 == v28
            v30 = v29 != 1
            if v30:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v31 = numpy.empty(v27,dtype=numpy.float64)
            v32 = (<unsigned long long>0)
            v33 = (<double>0.000000)
            v34 = method31(v27, v14, v15, v16, v11, v12, v13, v10, v0, v1, v17, v8, v5, v6, v7, v2, v3, v4, v24, v26, v18, v31, v32, v33)
            del v18; del v26
            v35 = (<unsigned char>0)
            return method34(v11, v12, v13, v20, v24, v34, v31, v35)
        else:
            v37 = method8(v0, v18, v14)
            v38 = v10 + v13
            v39 = v10 + v12
            v40 = libc.math.exp(v38)
            v41 = libc.math.exp(v39)
            v42 = v37.v2
            del v37
            v43 = method17(v42)
            del v42
            v44 = len(v43)
            v45 = len(v18)
            v46 = v44 == v45
            v47 = v46 == 0
            if v47:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v48 = (<unsigned long long>0)
            v49 = (<double>0.000000)
            return method38(v44, v14, v15, v16, v11, v12, v13, v10, v0, v1, v17, v8, v5, v6, v7, v2, v3, v4, v41, v43, v18, v48, v49)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v54 = (<signed long>1)
        v55 = v4 + (<signed long>4)
        v56 = method30(v1, v5, v6, v55, v2, v3, v4, v54)
        v57 = v3 == (<unsigned char>0)
        if v57:
            v58 = method8(v0, v56, v11)
            v59 = v10 + v16
            v60 = v10 + v15
            v61 = libc.math.exp(v59)
            v62 = libc.math.exp(v60)
            v63 = v58.v2
            v64 = method17(v63)
            del v63
            v65 = len(v64)
            v66 = len(v56)
            v67 = v65 == v66
            v68 = v67 != 1
            if v68:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v69 = numpy.empty(v65,dtype=numpy.float64)
            v70 = (<unsigned long long>0)
            v71 = (<double>0.000000)
            v72 = method31(v65, v14, v15, v16, v11, v12, v13, v10, v0, v1, v54, v8, v5, v6, v55, v2, v3, v4, v62, v64, v56, v69, v70, v71)
            del v56; del v64
            v73 = (<unsigned char>0)
            return method34(v11, v12, v13, v58, v62, v72, v69, v73)
        else:
            v75 = method8(v0, v56, v14)
            v76 = v10 + v13
            v77 = v10 + v12
            v78 = libc.math.exp(v76)
            v79 = libc.math.exp(v77)
            v80 = v75.v2
            del v75
            v81 = method17(v80)
            del v80
            v82 = len(v81)
            v83 = len(v56)
            v84 = v82 == v83
            v85 = v84 == 0
            if v85:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v86 = (<unsigned long long>0)
            v87 = (<double>0.000000)
            return method38(v82, v14, v15, v16, v11, v12, v13, v10, v0, v1, v54, v8, v5, v6, v55, v2, v3, v4, v79, v81, v56, v86, v87)
cdef double method28(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, numpy.ndarray[double,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v18[v21]
        v26 = v19[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v17 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v6
            v32 = v30 + v5
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method29(v8, v9, v10, v11, v12, v13, v14, v15, v16, v26, v7, v34, v32, v31, v36, v2, v3)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        v20[v21] = v38
        return method28(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method39(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v3
            v31 = v29 + v2
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method29(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v5, v6, v35, v31, v30)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method27(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15):
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef Mut1 v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef bint v27
    cdef bint v28
    cdef numpy.ndarray[double,ndim=1] v29
    cdef unsigned long long v30
    cdef double v31
    cdef double v32
    cdef unsigned char v33
    cdef Mut1 v35
    cdef double v36
    cdef double v37
    cdef double v38
    cdef double v39
    cdef numpy.ndarray[double,ndim=1] v40
    cdef numpy.ndarray[double,ndim=1] v41
    cdef unsigned long long v42
    cdef unsigned long long v43
    cdef bint v44
    cdef bint v45
    cdef unsigned long long v46
    cdef double v47
    v16 = v1.v2
    v17 = v6 == (<unsigned char>0)
    if v17:
        v18 = method8(v0, v16, v10)
        v19 = v9 + v15
        v20 = v9 + v14
        v21 = libc.math.exp(v19)
        v22 = libc.math.exp(v20)
        v23 = v18.v2
        v24 = method17(v23)
        del v23
        v25 = len(v24)
        v26 = len(v16)
        v27 = v25 == v26
        v28 = v27 != 1
        if v28:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v29 = numpy.empty(v25,dtype=numpy.float64)
        v30 = (<unsigned long long>0)
        v31 = (<double>0.000000)
        v32 = method28(v25, v13, v14, v15, v10, v11, v12, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v22, v24, v16, v29, v30, v31)
        del v16; del v24
        v33 = (<unsigned char>0)
        return method34(v10, v11, v12, v18, v22, v32, v29, v33)
    else:
        v35 = method8(v0, v16, v13)
        v36 = v9 + v12
        v37 = v9 + v11
        v38 = libc.math.exp(v36)
        v39 = libc.math.exp(v37)
        v40 = v35.v2
        del v35
        v41 = method17(v40)
        del v40
        v42 = len(v41)
        v43 = len(v16)
        v44 = v42 == v43
        v45 = v44 == 0
        if v45:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v46 = (<unsigned long long>0)
        v47 = (<double>0.000000)
        return method39(v42, v13, v14, v15, v10, v11, v12, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v39, v41, v16, v46, v47)
cdef double method26(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15, unsigned long long v16, double v17):
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef bint v21
    cdef US1 v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef US2 v27
    cdef UH0 v28
    cdef US2 v29
    cdef UH0 v30
    cdef double v31
    cdef unsigned long long v32
    cdef double v33
    cdef double v35
    v18 = len(v0)
    v19 = <double>v18
    v20 = (<double>1.000000) / v19
    v21 = v16 < v18
    if v21:
        v22 = v0[v16]
        v23 = <double>v18
        v24 = (<double>1.000000) / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v9
        v27 = US2_1(v22)
        v28 = UH0_0(v27, v10)
        del v27
        v29 = US2_1(v22)
        v30 = UH0_0(v29, v13)
        del v29
        v31 = method27(v1, v2, v3, v4, v5, v6, v7, v8, v22, v26, v28, v11, v12, v30, v14, v15)
        del v28; del v30
        v32 = v16 + (<unsigned long long>1)
        v33 = v17 + v31
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v32, v33)
    else:
        v35 = v17 * v20
        return v35
cdef double method42(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method41(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method42(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method41(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef bint v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned long long v25
    cdef double v26
    cdef bint v28
    cdef signed long v30
    cdef bint v31
    cdef signed long v33
    cdef signed long v34
    cdef signed long v36
    cdef signed long v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef double v44
    cdef signed long v45
    cdef signed long v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef bint v48
    cdef Mut1 v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef numpy.ndarray[double,ndim=1] v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef bint v59
    cdef numpy.ndarray[double,ndim=1] v60
    cdef unsigned long long v61
    cdef double v62
    cdef double v63
    cdef unsigned char v64
    cdef Mut1 v66
    cdef double v67
    cdef double v68
    cdef double v69
    cdef double v70
    cdef numpy.ndarray[double,ndim=1] v71
    cdef numpy.ndarray[double,ndim=1] v72
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef bint v75
    cdef bint v76
    cdef unsigned long long v77
    cdef double v78
    if v10 == 0: # call
        v18 = v8 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v7, v8, v6, v4, v5, v6
        else:
            v19, v20, v21, v22, v23, v24 = v4, v5, v6, v7, v8, v6
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        return method26(v2, v0, v1, v22, v23, v24, v19, v20, v21, v11, v12, v13, v14, v15, v16, v17, v25, v26)
    elif v10 == 1: # fold
        v28 = v5 == (<unsigned char>0)
        if v28:
            v30 = v9
        else:
            v30 = -v9
        v31 = v8 == (<unsigned char>0)
        if v31:
            v33 = v30
        else:
            v33 = -v30
        v34 = v33 + v9
        if v28:
            v36 = v30
        else:
            v36 = -v30
        v37 = v36 + v6
        if v31:
            v38, v39, v40, v41, v42, v43 = v7, v8, v34, v4, v5, v37
        else:
            v38, v39, v40, v41, v42, v43 = v4, v5, v37, v7, v8, v34
        v44 = <double>v30
        return v44
    elif v10 == 2: # raise
        v45 = v3 - (<signed long>1)
        v46 = v6 + (<signed long>2)
        v47 = method30(v1, v7, v8, v46, v4, v5, v6, v45)
        v48 = v5 == (<unsigned char>0)
        if v48:
            v49 = method8(v0, v47, v12)
            v50 = v11 + v17
            v51 = v11 + v16
            v52 = libc.math.exp(v50)
            v53 = libc.math.exp(v51)
            v54 = v49.v2
            v55 = method17(v54)
            del v54
            v56 = len(v55)
            v57 = len(v47)
            v58 = v56 == v57
            v59 = v58 != 1
            if v59:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v60 = numpy.empty(v56,dtype=numpy.float64)
            v61 = (<unsigned long long>0)
            v62 = (<double>0.000000)
            v63 = method40(v56, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v45, v7, v8, v46, v4, v5, v6, v53, v55, v47, v60, v61, v62)
            del v47; del v55
            v64 = (<unsigned char>0)
            return method34(v12, v13, v14, v49, v53, v63, v60, v64)
        else:
            v66 = method8(v0, v47, v15)
            v67 = v11 + v14
            v68 = v11 + v13
            v69 = libc.math.exp(v67)
            v70 = libc.math.exp(v68)
            v71 = v66.v2
            del v66
            v72 = method17(v71)
            del v71
            v73 = len(v72)
            v74 = len(v47)
            v75 = v73 == v74
            v76 = v75 == 0
            if v76:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v77 = (<unsigned long long>0)
            v78 = (<double>0.000000)
            return method42(v73, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v45, v7, v8, v46, v4, v5, v6, v70, v72, v47, v77, v78)
cdef double method40(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, numpy.ndarray[double,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v19[v22]
        v27 = v20[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v18 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v6
            v33 = v31 + v5
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method41(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v27, v7, v35, v33, v32, v37, v2, v3)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        v21[v22] = v39
        return method40(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method25(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef double v25
    cdef bint v27
    cdef signed long v29
    cdef bint v30
    cdef signed long v32
    cdef signed long v33
    cdef signed long v35
    cdef signed long v36
    cdef US1 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef US1 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef double v43
    cdef signed long v44
    cdef signed long v45
    cdef numpy.ndarray[signed long,ndim=1] v46
    cdef bint v47
    cdef Mut1 v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef numpy.ndarray[double,ndim=1] v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef bint v57
    cdef bint v58
    cdef numpy.ndarray[double,ndim=1] v59
    cdef unsigned long long v60
    cdef double v61
    cdef double v62
    cdef unsigned char v63
    cdef Mut1 v65
    cdef double v66
    cdef double v67
    cdef double v68
    cdef double v69
    cdef numpy.ndarray[double,ndim=1] v70
    cdef numpy.ndarray[double,ndim=1] v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef bint v74
    cdef bint v75
    cdef unsigned long long v76
    cdef double v77
    if v9 == 0: # call
        v17 = v8 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v7, v8, v6, v4, v5, v6
        else:
            v18, v19, v20, v21, v22, v23 = v4, v5, v6, v7, v8, v6
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method26(v2, v0, v1, v21, v22, v23, v18, v19, v20, v10, v11, v12, v13, v14, v15, v16, v24, v25)
    elif v9 == 1: # fold
        v27 = v5 == (<unsigned char>0)
        if v27:
            v29 = v6
        else:
            v29 = -v6
        v30 = v8 == (<unsigned char>0)
        if v30:
            v32 = v29
        else:
            v32 = -v29
        v33 = v32 + v6
        if v27:
            v35 = v29
        else:
            v35 = -v29
        v36 = v35 + v6
        if v30:
            v37, v38, v39, v40, v41, v42 = v7, v8, v33, v4, v5, v36
        else:
            v37, v38, v39, v40, v41, v42 = v4, v5, v36, v7, v8, v33
        v43 = <double>v29
        return v43
    elif v9 == 2: # raise
        v44 = v3 - (<signed long>1)
        v45 = v6 + (<signed long>2)
        v46 = method30(v1, v7, v8, v45, v4, v5, v6, v44)
        v47 = v5 == (<unsigned char>0)
        if v47:
            v48 = method8(v0, v46, v11)
            v49 = v10 + v16
            v50 = v10 + v15
            v51 = libc.math.exp(v49)
            v52 = libc.math.exp(v50)
            v53 = v48.v2
            v54 = method17(v53)
            del v53
            v55 = len(v54)
            v56 = len(v46)
            v57 = v55 == v56
            v58 = v57 != 1
            if v58:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v59 = numpy.empty(v55,dtype=numpy.float64)
            v60 = (<unsigned long long>0)
            v61 = (<double>0.000000)
            v62 = method40(v55, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v44, v7, v8, v45, v4, v5, v6, v52, v54, v46, v59, v60, v61)
            del v46; del v54
            v63 = (<unsigned char>0)
            return method34(v11, v12, v13, v48, v52, v62, v59, v63)
        else:
            v65 = method8(v0, v46, v14)
            v66 = v10 + v13
            v67 = v10 + v12
            v68 = libc.math.exp(v66)
            v69 = libc.math.exp(v67)
            v70 = v65.v2
            del v65
            v71 = method17(v70)
            del v70
            v72 = len(v71)
            v73 = len(v46)
            v74 = v72 == v73
            v75 = v74 == 0
            if v75:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v76 = (<unsigned long long>0)
            v77 = (<double>0.000000)
            return method42(v72, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v44, v7, v8, v45, v4, v5, v6, v69, v71, v46, v76, v77)
cdef double method24(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, numpy.ndarray[double,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v18[v21]
        v26 = v19[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v17 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v6
            v32 = v30 + v5
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method25(v8, v9, v10, v11, v12, v13, v14, v15, v16, v26, v7, v34, v32, v31, v36, v2, v3)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        v20[v21] = v38
        return method24(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method43(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v3
            v31 = v29 + v2
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method25(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v5, v6, v35, v31, v30)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method43(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method22(Mut0 v0, US1 v1, US1 v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, US0 v5, double v6, UH0 v7, double v8, double v9, UH0 v10, double v11, double v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef Mut1 v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v29
    cdef numpy.ndarray[double,ndim=1] v30
    cdef unsigned long long v31
    cdef double v32
    cdef double v33
    cdef unsigned char v34
    cdef Mut1 v36
    cdef double v37
    cdef double v38
    cdef double v39
    cdef double v40
    cdef numpy.ndarray[double,ndim=1] v41
    cdef numpy.ndarray[double,ndim=1] v42
    cdef unsigned long long v43
    cdef unsigned long long v44
    cdef bint v45
    cdef bint v46
    cdef unsigned long long v47
    cdef double v48
    cdef object v51
    cdef signed long v53
    cdef unsigned char v54
    cdef signed long v55
    cdef unsigned char v56
    cdef signed long v57
    cdef numpy.ndarray[signed long,ndim=1] v58
    cdef bint v59
    cdef Mut1 v60
    cdef double v61
    cdef double v62
    cdef double v63
    cdef double v64
    cdef numpy.ndarray[double,ndim=1] v65
    cdef numpy.ndarray[double,ndim=1] v66
    cdef unsigned long long v67
    cdef unsigned long long v68
    cdef bint v69
    cdef bint v70
    cdef numpy.ndarray[double,ndim=1] v71
    cdef unsigned long long v72
    cdef double v73
    cdef double v74
    cdef unsigned char v75
    cdef Mut1 v77
    cdef double v78
    cdef double v79
    cdef double v80
    cdef double v81
    cdef numpy.ndarray[double,ndim=1] v82
    cdef numpy.ndarray[double,ndim=1] v83
    cdef unsigned long long v84
    cdef unsigned long long v85
    cdef bint v86
    cdef bint v87
    cdef unsigned long long v88
    cdef double v89
    if v5 == 0: # call
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method23(v3, v1, v16, v15, v2, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = method8(v0, v17, v7)
            v20 = v6 + v12
            v21 = v6 + v11
            v22 = libc.math.exp(v20)
            v23 = libc.math.exp(v21)
            v24 = v19.v2
            v25 = method17(v24)
            del v24
            v26 = len(v25)
            v27 = len(v17)
            v28 = v26 == v27
            v29 = v28 != 1
            if v29:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v30 = numpy.empty(v26,dtype=numpy.float64)
            v31 = (<unsigned long long>0)
            v32 = (<double>0.000000)
            v33 = method24(v26, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v13, v1, v16, v15, v2, v14, v23, v25, v17, v30, v31, v32)
            del v17; del v25
            v34 = (<unsigned char>0)
            return method34(v7, v8, v9, v19, v23, v33, v30, v34)
        else:
            v36 = method8(v0, v17, v10)
            v37 = v6 + v9
            v38 = v6 + v8
            v39 = libc.math.exp(v37)
            v40 = libc.math.exp(v38)
            v41 = v36.v2
            del v36
            v42 = method17(v41)
            del v41
            v43 = len(v42)
            v44 = len(v17)
            v45 = v43 == v44
            v46 = v45 == 0
            if v46:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v47 = (<unsigned long long>0)
            v48 = (<double>0.000000)
            return method43(v43, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v13, v1, v16, v15, v2, v14, v40, v42, v17, v47, v48)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v53 = (<signed long>1)
        v54 = (<unsigned char>1)
        v55 = (<signed long>1)
        v56 = (<unsigned char>0)
        v57 = (<signed long>3)
        v58 = method30(v3, v1, v56, v57, v2, v54, v55, v53)
        v59 = v54 == (<unsigned char>0)
        if v59:
            v60 = method8(v0, v58, v7)
            v61 = v6 + v12
            v62 = v6 + v11
            v63 = libc.math.exp(v61)
            v64 = libc.math.exp(v62)
            v65 = v60.v2
            v66 = method17(v65)
            del v65
            v67 = len(v66)
            v68 = len(v58)
            v69 = v67 == v68
            v70 = v69 != 1
            if v70:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v71 = numpy.empty(v67,dtype=numpy.float64)
            v72 = (<unsigned long long>0)
            v73 = (<double>0.000000)
            v74 = method40(v67, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v53, v1, v56, v57, v2, v54, v55, v64, v66, v58, v71, v72, v73)
            del v58; del v66
            v75 = (<unsigned char>0)
            return method34(v7, v8, v9, v60, v64, v74, v71, v75)
        else:
            v77 = method8(v0, v58, v10)
            v78 = v6 + v9
            v79 = v6 + v8
            v80 = libc.math.exp(v78)
            v81 = libc.math.exp(v79)
            v82 = v77.v2
            del v77
            v83 = method17(v82)
            del v82
            v84 = len(v83)
            v85 = len(v58)
            v86 = v84 == v85
            v87 = v86 == 0
            if v87:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v88 = (<unsigned long long>0)
            v89 = (<double>0.000000)
            return method42(v84, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v53, v1, v56, v57, v2, v54, v55, v81, v83, v58, v88, v89)
cdef double method21(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, US1 v9, US1 v10, Heap0 v11, numpy.ndarray[signed long,ndim=1] v12, double v13, numpy.ndarray[double,ndim=1] v14, numpy.ndarray[signed long,ndim=1] v15, numpy.ndarray[double,ndim=1] v16, unsigned long long v17, double v18):
    cdef bint v19
    cdef unsigned long long v20
    cdef double v21
    cdef US0 v22
    cdef bint v23
    cdef bint v25
    cdef double v34
    cdef double v26
    cdef double v27
    cdef double v28
    cdef US2 v29
    cdef UH0 v30
    cdef US2 v31
    cdef UH0 v32
    cdef double v35
    cdef double v36
    v19 = v17 < v0
    if v19:
        v20 = v17 + (<unsigned long long>1)
        v21 = v14[v17]
        v22 = v15[v17]
        v23 = v21 == (<double>0.000000)
        if v23:
            v25 = v13 == (<double>0.000000)
        else:
            v25 = 0
        if v25:
            v34 = (<double>0.000000)
        else:
            v26 = libc.math.log(v21)
            v27 = v26 + v6
            v28 = v26 + v5
            v29 = US2_0(v22)
            v30 = UH0_0(v29, v4)
            del v29
            v31 = US2_0(v22)
            v32 = UH0_0(v31, v1)
            del v31
            v34 = method22(v8, v9, v10, v11, v12, v22, v7, v30, v28, v27, v32, v2, v3)
            del v30; del v32
        v35 = v34 * v21
        v36 = v18 + v35
        v16[v17] = v34
        return method21(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v36)
    else:
        return v18
cdef double method7(Mut0 v0, Heap0 v1, US1 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef Mut1 v13
    cdef double v14
    cdef double v15
    cdef double v16
    cdef double v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef unsigned long long v25
    cdef double v26
    cdef double v27
    cdef unsigned char v28
    v12 = v1.v2
    v13 = method8(v0, v12, v6)
    v14 = v5 + v11
    v15 = v5 + v10
    v16 = libc.math.exp(v14)
    v17 = libc.math.exp(v15)
    v18 = v13.v2
    v19 = method17(v18)
    del v18
    v20 = len(v19)
    v21 = len(v12)
    v22 = v20 == v21
    v23 = v22 != 1
    if v23:
        raise Exception("The two arrays have to have the same size.")
    else:
        pass
    v24 = numpy.empty(v20,dtype=numpy.float64)
    v25 = (<unsigned long long>0)
    v26 = (<double>0.000000)
    v27 = method21(v20, v9, v10, v11, v6, v7, v8, v5, v0, v2, v3, v1, v4, v17, v19, v12, v24, v25, v26)
    del v12; del v19
    v28 = (<unsigned char>0)
    return method34(v6, v7, v8, v13, v17, v27, v24, v28)
cdef double method6(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10, unsigned long long v11, double v12):
    cdef unsigned long long v13
    cdef double v14
    cdef double v15
    cdef bint v16
    cdef US1 v17
    cdef unsigned long long v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef unsigned long long v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef unsigned long long v28
    cdef double v29
    cdef double v31
    v13 = len(v0)
    v14 = <double>v13
    v15 = (<double>1.000000) / v14
    v16 = v11 < v13
    if v16:
        v17 = v0[v11]
        v18 = v13 - (<unsigned long long>1)
        v19 = numpy.empty(v18,dtype=numpy.int32)
        v20 = (<unsigned long long>0)
        method4(v18, v11, v0, v19, v20)
        v21 = <double>v13
        v22 = (<double>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v4
        v25 = US2_1(v17)
        v26 = UH0_0(v25, v8)
        del v25
        v27 = method7(v1, v2, v3, v17, v19, v24, v5, v6, v7, v26, v9, v10)
        del v19; del v26
        v28 = v11 + (<unsigned long long>1)
        v29 = v12 + v27
        return method6(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v28, v29)
    else:
        v31 = v12 * v15
        return v31
cdef double method5(Mut0 v0, Heap0 v1, US1 v2, numpy.ndarray[signed long,ndim=1] v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    v11 = (<unsigned long long>0)
    v12 = (<double>0.000000)
    return method6(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9, v10, v11, v12)
cdef double method3(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, UH0 v3, double v4, double v5, UH0 v6, double v7, double v8, unsigned long long v9, double v10):
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
    cdef US2 v22
    cdef UH0 v23
    cdef double v24
    cdef unsigned long long v25
    cdef double v26
    cdef double v28
    v11 = len(v0)
    v12 = <double>v11
    v13 = (<double>1.000000) / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - (<unsigned long long>1)
        v17 = numpy.empty(v16,dtype=numpy.int32)
        v18 = (<unsigned long long>0)
        method4(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = (<double>1.000000) / v19
        v21 = libc.math.log(v20)
        v22 = US2_1(v15)
        v23 = UH0_0(v22, v3)
        del v22
        v24 = method5(v1, v2, v15, v17, v21, v23, v4, v5, v6, v7, v8)
        del v17; del v23
        v25 = v9 + (<unsigned long long>1)
        v26 = v10 + v24
        return method3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v25, v26)
    else:
        v28 = v10 * v13
        return v28
cdef double method58(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, signed long v10, US1 v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, numpy.ndarray[double,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v19[v22]
        v27 = v20[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v18 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v3
            v33 = v31 + v2
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method57(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v27, v7, v35, v5, v6, v37, v33, v32)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        v21[v22] = v39
        return method58(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method57(Mut0 v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef signed long v18
    cdef signed long v19
    cdef signed long v20
    cdef bint v21
    cdef bint v23
    cdef signed long v47
    cdef bint v24
    cdef bint v25
    cdef bint v28
    cdef bint v29
    cdef signed long v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v33
    cdef signed long v34
    cdef bint v35
    cdef signed long v38
    cdef bint v36
    cdef bint v39
    cdef bint v40
    cdef bint v41
    cdef bint v48
    cdef unsigned char v52
    cdef signed long v53
    cdef bint v49
    cdef bint v54
    cdef signed long v56
    cdef bint v57
    cdef signed long v59
    cdef signed long v60
    cdef bint v61
    cdef signed long v63
    cdef signed long v64
    cdef US1 v65
    cdef unsigned char v66
    cdef signed long v67
    cdef US1 v68
    cdef unsigned char v69
    cdef signed long v70
    cdef double v71
    cdef bint v72
    cdef signed long v74
    cdef bint v75
    cdef signed long v77
    cdef signed long v78
    cdef signed long v80
    cdef signed long v81
    cdef US1 v82
    cdef unsigned char v83
    cdef signed long v84
    cdef US1 v85
    cdef unsigned char v86
    cdef signed long v87
    cdef double v88
    cdef signed long v89
    cdef signed long v90
    cdef numpy.ndarray[signed long,ndim=1] v91
    cdef bint v92
    cdef Mut1 v93
    cdef double v94
    cdef double v95
    cdef double v96
    cdef double v97
    cdef numpy.ndarray[double,ndim=1] v98
    cdef numpy.ndarray[double,ndim=1] v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef bint v102
    cdef bint v103
    cdef unsigned long long v104
    cdef double v105
    cdef Mut1 v107
    cdef double v108
    cdef double v109
    cdef double v110
    cdef double v111
    cdef numpy.ndarray[double,ndim=1] v112
    cdef numpy.ndarray[double,ndim=1] v113
    cdef unsigned long long v114
    cdef unsigned long long v115
    cdef bint v116
    cdef bint v117
    cdef numpy.ndarray[double,ndim=1] v118
    cdef unsigned long long v119
    cdef double v120
    cdef double v121
    cdef unsigned char v122
    if v10 == 0: # call
        v18 = method33(v3)
        v19 = method33(v7)
        v20 = method33(v4)
        v21 = v19 == v18
        if v21:
            v23 = v20 == v18
        else:
            v23 = 0
        if v23:
            v24 = v19 < v20
            if v24:
                v47 = (<signed long>-1)
            else:
                v25 = v19 > v20
                if v25:
                    v47 = (<signed long>1)
                else:
                    v47 = (<signed long>0)
        else:
            if v21:
                v47 = (<signed long>1)
            else:
                v28 = v20 == v18
                if v28:
                    v47 = (<signed long>-1)
                else:
                    v29 = v19 > v18
                    if v29:
                        v30, v31 = v19, v18
                    else:
                        v30, v31 = v18, v19
                    v32 = v20 > v18
                    if v32:
                        v33, v34 = v20, v18
                    else:
                        v33, v34 = v18, v20
                    v35 = v30 < v33
                    if v35:
                        v38 = (<signed long>-1)
                    else:
                        v36 = v30 > v33
                        if v36:
                            v38 = (<signed long>1)
                        else:
                            v38 = (<signed long>0)
                    v39 = v38 == (<signed long>0)
                    if v39:
                        v40 = v31 < v34
                        if v40:
                            v47 = (<signed long>-1)
                        else:
                            v41 = v31 > v34
                            if v41:
                                v47 = (<signed long>1)
                            else:
                                v47 = (<signed long>0)
                    else:
                        v47 = v38
        v48 = v47 == (<signed long>1)
        if v48:
            v52, v53 = v8, v6
        else:
            v49 = v47 == (<signed long>-1)
            if v49:
                v52, v53 = v5, v6
            else:
                v52, v53 = v8, (<signed long>0)
        v54 = v52 == (<unsigned char>0)
        if v54:
            v56 = v53
        else:
            v56 = -v53
        v57 = v8 == (<unsigned char>0)
        if v57:
            v59 = v56
        else:
            v59 = -v56
        v60 = v59 + v6
        v61 = v5 == (<unsigned char>0)
        if v61:
            v63 = v56
        else:
            v63 = -v56
        v64 = v63 + v6
        if v57:
            v65, v66, v67, v68, v69, v70 = v7, v8, v60, v4, v5, v64
        else:
            v65, v66, v67, v68, v69, v70 = v4, v5, v64, v7, v8, v60
        v71 = <double>v56
        return v71
    elif v10 == 1: # fold
        v72 = v5 == (<unsigned char>0)
        if v72:
            v74 = v9
        else:
            v74 = -v9
        v75 = v8 == (<unsigned char>0)
        if v75:
            v77 = v74
        else:
            v77 = -v74
        v78 = v77 + v9
        if v72:
            v80 = v74
        else:
            v80 = -v74
        v81 = v80 + v6
        if v75:
            v82, v83, v84, v85, v86, v87 = v7, v8, v78, v4, v5, v81
        else:
            v82, v83, v84, v85, v86, v87 = v4, v5, v81, v7, v8, v78
        v88 = <double>v74
        return v88
    elif v10 == 2: # raise
        v89 = v2 - (<signed long>1)
        v90 = v6 + (<signed long>4)
        v91 = method30(v1, v7, v8, v90, v4, v5, v6, v89)
        v92 = v5 == (<unsigned char>0)
        if v92:
            v93 = method8(v0, v91, v12)
            v94 = v11 + v17
            v95 = v11 + v16
            v96 = libc.math.exp(v94)
            v97 = libc.math.exp(v95)
            v98 = v93.v2
            del v93
            v99 = method17(v98)
            del v98
            v100 = len(v99)
            v101 = len(v91)
            v102 = v100 == v101
            v103 = v102 == 0
            if v103:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v104 = (<unsigned long long>0)
            v105 = (<double>0.000000)
            return method56(v100, v15, v16, v17, v12, v13, v14, v11, v0, v1, v89, v3, v7, v8, v90, v4, v5, v6, v97, v99, v91, v104, v105)
        else:
            v107 = method8(v0, v91, v15)
            v108 = v11 + v14
            v109 = v11 + v13
            v110 = libc.math.exp(v108)
            v111 = libc.math.exp(v109)
            v112 = v107.v2
            v113 = method17(v112)
            del v112
            v114 = len(v113)
            v115 = len(v91)
            v116 = v114 == v115
            v117 = v116 != 1
            if v117:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v118 = numpy.empty(v114,dtype=numpy.float64)
            v119 = (<unsigned long long>0)
            v120 = (<double>0.000000)
            v121 = method58(v114, v15, v16, v17, v12, v13, v14, v11, v0, v1, v89, v3, v7, v8, v90, v4, v5, v6, v111, v113, v91, v118, v119, v120)
            del v91; del v113
            v122 = (<unsigned char>1)
            return method34(v15, v16, v17, v107, v111, v121, v118, v122)
cdef double method56(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, signed long v10, US1 v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v6
            v32 = v30 + v5
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method57(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v32, v31, v36, v2, v3)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method56(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method55(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef Mut1 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned long long v31
    cdef double v32
    cdef Mut1 v34
    cdef double v35
    cdef double v36
    cdef double v37
    cdef double v38
    cdef numpy.ndarray[double,ndim=1] v39
    cdef numpy.ndarray[double,ndim=1] v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef bint v43
    cdef bint v44
    cdef numpy.ndarray[double,ndim=1] v45
    cdef unsigned long long v46
    cdef double v47
    cdef double v48
    cdef unsigned char v49
    cdef object v52
    cdef signed long v54
    cdef signed long v55
    cdef numpy.ndarray[signed long,ndim=1] v56
    cdef bint v57
    cdef Mut1 v58
    cdef double v59
    cdef double v60
    cdef double v61
    cdef double v62
    cdef numpy.ndarray[double,ndim=1] v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef bint v67
    cdef bint v68
    cdef unsigned long long v69
    cdef double v70
    cdef Mut1 v72
    cdef double v73
    cdef double v74
    cdef double v75
    cdef double v76
    cdef numpy.ndarray[double,ndim=1] v77
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
        v17 = (<signed long>2)
        v18 = method30(v1, v5, v6, v7, v2, v3, v4, v17)
        v19 = v3 == (<unsigned char>0)
        if v19:
            v20 = method8(v0, v18, v11)
            v21 = v10 + v16
            v22 = v10 + v15
            v23 = libc.math.exp(v21)
            v24 = libc.math.exp(v22)
            v25 = v20.v2
            del v20
            v26 = method17(v25)
            del v25
            v27 = len(v26)
            v28 = len(v18)
            v29 = v27 == v28
            v30 = v29 == 0
            if v30:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v31 = (<unsigned long long>0)
            v32 = (<double>0.000000)
            return method56(v27, v14, v15, v16, v11, v12, v13, v10, v0, v1, v17, v8, v5, v6, v7, v2, v3, v4, v24, v26, v18, v31, v32)
        else:
            v34 = method8(v0, v18, v14)
            v35 = v10 + v13
            v36 = v10 + v12
            v37 = libc.math.exp(v35)
            v38 = libc.math.exp(v36)
            v39 = v34.v2
            v40 = method17(v39)
            del v39
            v41 = len(v40)
            v42 = len(v18)
            v43 = v41 == v42
            v44 = v43 != 1
            if v44:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v45 = numpy.empty(v41,dtype=numpy.float64)
            v46 = (<unsigned long long>0)
            v47 = (<double>0.000000)
            v48 = method58(v41, v14, v15, v16, v11, v12, v13, v10, v0, v1, v17, v8, v5, v6, v7, v2, v3, v4, v38, v40, v18, v45, v46, v47)
            del v18; del v40
            v49 = (<unsigned char>1)
            return method34(v14, v15, v16, v34, v38, v48, v45, v49)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v54 = (<signed long>1)
        v55 = v4 + (<signed long>4)
        v56 = method30(v1, v5, v6, v55, v2, v3, v4, v54)
        v57 = v3 == (<unsigned char>0)
        if v57:
            v58 = method8(v0, v56, v11)
            v59 = v10 + v16
            v60 = v10 + v15
            v61 = libc.math.exp(v59)
            v62 = libc.math.exp(v60)
            v63 = v58.v2
            del v58
            v64 = method17(v63)
            del v63
            v65 = len(v64)
            v66 = len(v56)
            v67 = v65 == v66
            v68 = v67 == 0
            if v68:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v69 = (<unsigned long long>0)
            v70 = (<double>0.000000)
            return method56(v65, v14, v15, v16, v11, v12, v13, v10, v0, v1, v54, v8, v5, v6, v55, v2, v3, v4, v62, v64, v56, v69, v70)
        else:
            v72 = method8(v0, v56, v14)
            v73 = v10 + v13
            v74 = v10 + v12
            v75 = libc.math.exp(v73)
            v76 = libc.math.exp(v74)
            v77 = v72.v2
            v78 = method17(v77)
            del v77
            v79 = len(v78)
            v80 = len(v56)
            v81 = v79 == v80
            v82 = v81 != 1
            if v82:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v83 = numpy.empty(v79,dtype=numpy.float64)
            v84 = (<unsigned long long>0)
            v85 = (<double>0.000000)
            v86 = method58(v79, v14, v15, v16, v11, v12, v13, v10, v0, v1, v54, v8, v5, v6, v55, v2, v3, v4, v76, v78, v56, v83, v84, v85)
            del v56; del v78
            v87 = (<unsigned char>1)
            return method34(v14, v15, v16, v72, v76, v86, v83, v87)
cdef double method54(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v6
            v31 = v29 + v5
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method55(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v31, v30, v35, v2, v3)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method54(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method59(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, numpy.ndarray[double,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v18[v21]
        v26 = v19[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v17 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method55(v8, v9, v10, v11, v12, v13, v14, v15, v16, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        v20[v21] = v38
        return method59(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method53(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15):
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef Mut1 v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef bint v27
    cdef bint v28
    cdef unsigned long long v29
    cdef double v30
    cdef Mut1 v32
    cdef double v33
    cdef double v34
    cdef double v35
    cdef double v36
    cdef numpy.ndarray[double,ndim=1] v37
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
    v16 = v1.v2
    v17 = v6 == (<unsigned char>0)
    if v17:
        v18 = method8(v0, v16, v10)
        v19 = v9 + v15
        v20 = v9 + v14
        v21 = libc.math.exp(v19)
        v22 = libc.math.exp(v20)
        v23 = v18.v2
        del v18
        v24 = method17(v23)
        del v23
        v25 = len(v24)
        v26 = len(v16)
        v27 = v25 == v26
        v28 = v27 == 0
        if v28:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v29 = (<unsigned long long>0)
        v30 = (<double>0.000000)
        return method54(v25, v13, v14, v15, v10, v11, v12, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v22, v24, v16, v29, v30)
    else:
        v32 = method8(v0, v16, v13)
        v33 = v9 + v12
        v34 = v9 + v11
        v35 = libc.math.exp(v33)
        v36 = libc.math.exp(v34)
        v37 = v32.v2
        v38 = method17(v37)
        del v37
        v39 = len(v38)
        v40 = len(v16)
        v41 = v39 == v40
        v42 = v41 != 1
        if v42:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v43 = numpy.empty(v39,dtype=numpy.float64)
        v44 = (<unsigned long long>0)
        v45 = (<double>0.000000)
        v46 = method59(v39, v13, v14, v15, v10, v11, v12, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v36, v38, v16, v43, v44, v45)
        del v16; del v38
        v47 = (<unsigned char>1)
        return method34(v13, v14, v15, v32, v36, v46, v43, v47)
cdef double method52(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15, unsigned long long v16, double v17):
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef bint v21
    cdef US1 v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef US2 v27
    cdef UH0 v28
    cdef US2 v29
    cdef UH0 v30
    cdef double v31
    cdef unsigned long long v32
    cdef double v33
    cdef double v35
    v18 = len(v0)
    v19 = <double>v18
    v20 = (<double>1.000000) / v19
    v21 = v16 < v18
    if v21:
        v22 = v0[v16]
        v23 = <double>v18
        v24 = (<double>1.000000) / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v9
        v27 = US2_1(v22)
        v28 = UH0_0(v27, v10)
        del v27
        v29 = US2_1(v22)
        v30 = UH0_0(v29, v13)
        del v29
        v31 = method53(v1, v2, v3, v4, v5, v6, v7, v8, v22, v26, v28, v11, v12, v30, v14, v15)
        del v28; del v30
        v32 = v16 + (<unsigned long long>1)
        v33 = v17 + v31
        return method52(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v32, v33)
    else:
        v35 = v17 * v20
        return v35
cdef double method62(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, numpy.ndarray[double,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v19[v22]
        v27 = v20[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v18 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v3
            v33 = v31 + v2
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method61(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v27, v7, v35, v5, v6, v37, v33, v32)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        v21[v22] = v39
        return method62(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method61(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef bint v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned long long v25
    cdef double v26
    cdef bint v28
    cdef signed long v30
    cdef bint v31
    cdef signed long v33
    cdef signed long v34
    cdef signed long v36
    cdef signed long v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef double v44
    cdef signed long v45
    cdef signed long v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef bint v48
    cdef Mut1 v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef numpy.ndarray[double,ndim=1] v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef bint v59
    cdef unsigned long long v60
    cdef double v61
    cdef Mut1 v63
    cdef double v64
    cdef double v65
    cdef double v66
    cdef double v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef numpy.ndarray[double,ndim=1] v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef bint v72
    cdef bint v73
    cdef numpy.ndarray[double,ndim=1] v74
    cdef unsigned long long v75
    cdef double v76
    cdef double v77
    cdef unsigned char v78
    if v10 == 0: # call
        v18 = v8 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v7, v8, v6, v4, v5, v6
        else:
            v19, v20, v21, v22, v23, v24 = v4, v5, v6, v7, v8, v6
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        return method52(v2, v0, v1, v22, v23, v24, v19, v20, v21, v11, v12, v13, v14, v15, v16, v17, v25, v26)
    elif v10 == 1: # fold
        v28 = v5 == (<unsigned char>0)
        if v28:
            v30 = v9
        else:
            v30 = -v9
        v31 = v8 == (<unsigned char>0)
        if v31:
            v33 = v30
        else:
            v33 = -v30
        v34 = v33 + v9
        if v28:
            v36 = v30
        else:
            v36 = -v30
        v37 = v36 + v6
        if v31:
            v38, v39, v40, v41, v42, v43 = v7, v8, v34, v4, v5, v37
        else:
            v38, v39, v40, v41, v42, v43 = v4, v5, v37, v7, v8, v34
        v44 = <double>v30
        return v44
    elif v10 == 2: # raise
        v45 = v3 - (<signed long>1)
        v46 = v6 + (<signed long>2)
        v47 = method30(v1, v7, v8, v46, v4, v5, v6, v45)
        v48 = v5 == (<unsigned char>0)
        if v48:
            v49 = method8(v0, v47, v12)
            v50 = v11 + v17
            v51 = v11 + v16
            v52 = libc.math.exp(v50)
            v53 = libc.math.exp(v51)
            v54 = v49.v2
            del v49
            v55 = method17(v54)
            del v54
            v56 = len(v55)
            v57 = len(v47)
            v58 = v56 == v57
            v59 = v58 == 0
            if v59:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v60 = (<unsigned long long>0)
            v61 = (<double>0.000000)
            return method60(v56, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v45, v7, v8, v46, v4, v5, v6, v53, v55, v47, v60, v61)
        else:
            v63 = method8(v0, v47, v15)
            v64 = v11 + v14
            v65 = v11 + v13
            v66 = libc.math.exp(v64)
            v67 = libc.math.exp(v65)
            v68 = v63.v2
            v69 = method17(v68)
            del v68
            v70 = len(v69)
            v71 = len(v47)
            v72 = v70 == v71
            v73 = v72 != 1
            if v73:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v74 = numpy.empty(v70,dtype=numpy.float64)
            v75 = (<unsigned long long>0)
            v76 = (<double>0.000000)
            v77 = method62(v70, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v45, v7, v8, v46, v4, v5, v6, v67, v69, v47, v74, v75, v76)
            del v47; del v69
            v78 = (<unsigned char>1)
            return method34(v15, v16, v17, v63, v67, v77, v74, v78)
cdef double method60(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v6
            v32 = v30 + v5
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method61(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v32, v31, v36, v2, v3)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method60(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method51(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef double v25
    cdef bint v27
    cdef signed long v29
    cdef bint v30
    cdef signed long v32
    cdef signed long v33
    cdef signed long v35
    cdef signed long v36
    cdef US1 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef US1 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef double v43
    cdef signed long v44
    cdef signed long v45
    cdef numpy.ndarray[signed long,ndim=1] v46
    cdef bint v47
    cdef Mut1 v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef numpy.ndarray[double,ndim=1] v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef bint v57
    cdef bint v58
    cdef unsigned long long v59
    cdef double v60
    cdef Mut1 v62
    cdef double v63
    cdef double v64
    cdef double v65
    cdef double v66
    cdef numpy.ndarray[double,ndim=1] v67
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
    if v9 == 0: # call
        v17 = v8 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v7, v8, v6, v4, v5, v6
        else:
            v18, v19, v20, v21, v22, v23 = v4, v5, v6, v7, v8, v6
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method52(v2, v0, v1, v21, v22, v23, v18, v19, v20, v10, v11, v12, v13, v14, v15, v16, v24, v25)
    elif v9 == 1: # fold
        v27 = v5 == (<unsigned char>0)
        if v27:
            v29 = v6
        else:
            v29 = -v6
        v30 = v8 == (<unsigned char>0)
        if v30:
            v32 = v29
        else:
            v32 = -v29
        v33 = v32 + v6
        if v27:
            v35 = v29
        else:
            v35 = -v29
        v36 = v35 + v6
        if v30:
            v37, v38, v39, v40, v41, v42 = v7, v8, v33, v4, v5, v36
        else:
            v37, v38, v39, v40, v41, v42 = v4, v5, v36, v7, v8, v33
        v43 = <double>v29
        return v43
    elif v9 == 2: # raise
        v44 = v3 - (<signed long>1)
        v45 = v6 + (<signed long>2)
        v46 = method30(v1, v7, v8, v45, v4, v5, v6, v44)
        v47 = v5 == (<unsigned char>0)
        if v47:
            v48 = method8(v0, v46, v11)
            v49 = v10 + v16
            v50 = v10 + v15
            v51 = libc.math.exp(v49)
            v52 = libc.math.exp(v50)
            v53 = v48.v2
            del v48
            v54 = method17(v53)
            del v53
            v55 = len(v54)
            v56 = len(v46)
            v57 = v55 == v56
            v58 = v57 == 0
            if v58:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v59 = (<unsigned long long>0)
            v60 = (<double>0.000000)
            return method60(v55, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v44, v7, v8, v45, v4, v5, v6, v52, v54, v46, v59, v60)
        else:
            v62 = method8(v0, v46, v14)
            v63 = v10 + v13
            v64 = v10 + v12
            v65 = libc.math.exp(v63)
            v66 = libc.math.exp(v64)
            v67 = v62.v2
            v68 = method17(v67)
            del v67
            v69 = len(v68)
            v70 = len(v46)
            v71 = v69 == v70
            v72 = v71 != 1
            if v72:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v73 = numpy.empty(v69,dtype=numpy.float64)
            v74 = (<unsigned long long>0)
            v75 = (<double>0.000000)
            v76 = method62(v69, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v44, v7, v8, v45, v4, v5, v6, v66, v68, v46, v73, v74, v75)
            del v46; del v68
            v77 = (<unsigned char>1)
            return method34(v14, v15, v16, v62, v66, v76, v73, v77)
cdef double method50(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v6
            v31 = v29 + v5
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method51(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v31, v30, v35, v2, v3)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method50(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method63(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, numpy.ndarray[double,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v18[v21]
        v26 = v19[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v17 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method51(v8, v9, v10, v11, v12, v13, v14, v15, v16, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        v20[v21] = v38
        return method63(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method49(Mut0 v0, US1 v1, US1 v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, US0 v5, double v6, UH0 v7, double v8, double v9, UH0 v10, double v11, double v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef Mut1 v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v29
    cdef unsigned long long v30
    cdef double v31
    cdef Mut1 v33
    cdef double v34
    cdef double v35
    cdef double v36
    cdef double v37
    cdef numpy.ndarray[double,ndim=1] v38
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
    cdef unsigned char v54
    cdef signed long v55
    cdef unsigned char v56
    cdef signed long v57
    cdef numpy.ndarray[signed long,ndim=1] v58
    cdef bint v59
    cdef Mut1 v60
    cdef double v61
    cdef double v62
    cdef double v63
    cdef double v64
    cdef numpy.ndarray[double,ndim=1] v65
    cdef numpy.ndarray[double,ndim=1] v66
    cdef unsigned long long v67
    cdef unsigned long long v68
    cdef bint v69
    cdef bint v70
    cdef unsigned long long v71
    cdef double v72
    cdef Mut1 v74
    cdef double v75
    cdef double v76
    cdef double v77
    cdef double v78
    cdef numpy.ndarray[double,ndim=1] v79
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
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method23(v3, v1, v16, v15, v2, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = method8(v0, v17, v7)
            v20 = v6 + v12
            v21 = v6 + v11
            v22 = libc.math.exp(v20)
            v23 = libc.math.exp(v21)
            v24 = v19.v2
            del v19
            v25 = method17(v24)
            del v24
            v26 = len(v25)
            v27 = len(v17)
            v28 = v26 == v27
            v29 = v28 == 0
            if v29:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v30 = (<unsigned long long>0)
            v31 = (<double>0.000000)
            return method50(v26, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v13, v1, v16, v15, v2, v14, v23, v25, v17, v30, v31)
        else:
            v33 = method8(v0, v17, v10)
            v34 = v6 + v9
            v35 = v6 + v8
            v36 = libc.math.exp(v34)
            v37 = libc.math.exp(v35)
            v38 = v33.v2
            v39 = method17(v38)
            del v38
            v40 = len(v39)
            v41 = len(v17)
            v42 = v40 == v41
            v43 = v42 != 1
            if v43:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v44 = numpy.empty(v40,dtype=numpy.float64)
            v45 = (<unsigned long long>0)
            v46 = (<double>0.000000)
            v47 = method63(v40, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v13, v1, v16, v15, v2, v14, v37, v39, v17, v44, v45, v46)
            del v17; del v39
            v48 = (<unsigned char>1)
            return method34(v10, v11, v12, v33, v37, v47, v44, v48)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v53 = (<signed long>1)
        v54 = (<unsigned char>1)
        v55 = (<signed long>1)
        v56 = (<unsigned char>0)
        v57 = (<signed long>3)
        v58 = method30(v3, v1, v56, v57, v2, v54, v55, v53)
        v59 = v54 == (<unsigned char>0)
        if v59:
            v60 = method8(v0, v58, v7)
            v61 = v6 + v12
            v62 = v6 + v11
            v63 = libc.math.exp(v61)
            v64 = libc.math.exp(v62)
            v65 = v60.v2
            del v60
            v66 = method17(v65)
            del v65
            v67 = len(v66)
            v68 = len(v58)
            v69 = v67 == v68
            v70 = v69 == 0
            if v70:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v71 = (<unsigned long long>0)
            v72 = (<double>0.000000)
            return method60(v67, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v53, v1, v56, v57, v2, v54, v55, v64, v66, v58, v71, v72)
        else:
            v74 = method8(v0, v58, v10)
            v75 = v6 + v9
            v76 = v6 + v8
            v77 = libc.math.exp(v75)
            v78 = libc.math.exp(v76)
            v79 = v74.v2
            v80 = method17(v79)
            del v79
            v81 = len(v80)
            v82 = len(v58)
            v83 = v81 == v82
            v84 = v83 != 1
            if v84:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v85 = numpy.empty(v81,dtype=numpy.float64)
            v86 = (<unsigned long long>0)
            v87 = (<double>0.000000)
            v88 = method62(v81, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v53, v1, v56, v57, v2, v54, v55, v78, v80, v58, v85, v86, v87)
            del v58; del v80
            v89 = (<unsigned char>1)
            return method34(v10, v11, v12, v74, v78, v88, v85, v89)
cdef double method48(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, US1 v9, US1 v10, Heap0 v11, numpy.ndarray[signed long,ndim=1] v12, double v13, numpy.ndarray[double,ndim=1] v14, numpy.ndarray[signed long,ndim=1] v15, unsigned long long v16, double v17):
    cdef bint v18
    cdef unsigned long long v19
    cdef double v20
    cdef US0 v21
    cdef bint v22
    cdef bint v24
    cdef double v33
    cdef double v25
    cdef double v26
    cdef double v27
    cdef US2 v28
    cdef UH0 v29
    cdef US2 v30
    cdef UH0 v31
    cdef double v34
    cdef double v35
    v18 = v16 < v0
    if v18:
        v19 = v16 + (<unsigned long long>1)
        v20 = v14[v16]
        v21 = v15[v16]
        v22 = v20 == (<double>0.000000)
        if v22:
            v24 = v13 == (<double>0.000000)
        else:
            v24 = 0
        if v24:
            v33 = (<double>0.000000)
        else:
            v25 = libc.math.log(v20)
            v26 = v25 + v6
            v27 = v25 + v5
            v28 = US2_0(v21)
            v29 = UH0_0(v28, v4)
            del v28
            v30 = US2_0(v21)
            v31 = UH0_0(v30, v1)
            del v30
            v33 = method49(v8, v9, v10, v11, v12, v21, v7, v29, v27, v26, v31, v2, v3)
            del v29; del v31
        v34 = v33 * v20
        v35 = v17 + v34
        return method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v19, v35)
    else:
        return v17
cdef double method47(Mut0 v0, Heap0 v1, US1 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef Mut1 v13
    cdef double v14
    cdef double v15
    cdef double v16
    cdef double v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    v12 = v1.v2
    v13 = method8(v0, v12, v6)
    v14 = v5 + v11
    v15 = v5 + v10
    v16 = libc.math.exp(v14)
    v17 = libc.math.exp(v15)
    v18 = v13.v2
    del v13
    v19 = method17(v18)
    del v18
    v20 = len(v19)
    v21 = len(v12)
    v22 = v20 == v21
    v23 = v22 == 0
    if v23:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v24 = (<unsigned long long>0)
    v25 = (<double>0.000000)
    return method48(v20, v9, v10, v11, v6, v7, v8, v5, v0, v2, v3, v1, v4, v17, v19, v12, v24, v25)
cdef double method46(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10, unsigned long long v11, double v12):
    cdef unsigned long long v13
    cdef double v14
    cdef double v15
    cdef bint v16
    cdef US1 v17
    cdef unsigned long long v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef unsigned long long v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef unsigned long long v28
    cdef double v29
    cdef double v31
    v13 = len(v0)
    v14 = <double>v13
    v15 = (<double>1.000000) / v14
    v16 = v11 < v13
    if v16:
        v17 = v0[v11]
        v18 = v13 - (<unsigned long long>1)
        v19 = numpy.empty(v18,dtype=numpy.int32)
        v20 = (<unsigned long long>0)
        method4(v18, v11, v0, v19, v20)
        v21 = <double>v13
        v22 = (<double>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v4
        v25 = US2_1(v17)
        v26 = UH0_0(v25, v8)
        del v25
        v27 = method47(v1, v2, v3, v17, v19, v24, v5, v6, v7, v26, v9, v10)
        del v19; del v26
        v28 = v11 + (<unsigned long long>1)
        v29 = v12 + v27
        return method46(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v28, v29)
    else:
        v31 = v12 * v15
        return v31
cdef double method45(Mut0 v0, Heap0 v1, US1 v2, numpy.ndarray[signed long,ndim=1] v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    v11 = (<unsigned long long>0)
    v12 = (<double>0.000000)
    return method46(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9, v10, v11, v12)
cdef double method44(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, UH0 v3, double v4, double v5, UH0 v6, double v7, double v8, unsigned long long v9, double v10):
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
    cdef US2 v22
    cdef UH0 v23
    cdef double v24
    cdef unsigned long long v25
    cdef double v26
    cdef double v28
    v11 = len(v0)
    v12 = <double>v11
    v13 = (<double>1.000000) / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - (<unsigned long long>1)
        v17 = numpy.empty(v16,dtype=numpy.int32)
        v18 = (<unsigned long long>0)
        method4(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = (<double>1.000000) / v19
        v21 = libc.math.log(v20)
        v22 = US2_1(v15)
        v23 = UH0_0(v22, v3)
        del v22
        v24 = method45(v1, v2, v15, v17, v21, v23, v4, v5, v6, v7, v8)
        del v17; del v23
        v25 = v9 + (<unsigned long long>1)
        v26 = v10 + v24
        return method44(v0, v1, v2, v3, v4, v5, v6, v7, v8, v25, v26)
    else:
        v28 = v10 * v13
        return v28
cdef double method78(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, signed long v10, US1 v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method77(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method78(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method77(Mut0 v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef signed long v18
    cdef signed long v19
    cdef signed long v20
    cdef bint v21
    cdef bint v23
    cdef signed long v47
    cdef bint v24
    cdef bint v25
    cdef bint v28
    cdef bint v29
    cdef signed long v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v33
    cdef signed long v34
    cdef bint v35
    cdef signed long v38
    cdef bint v36
    cdef bint v39
    cdef bint v40
    cdef bint v41
    cdef bint v48
    cdef unsigned char v52
    cdef signed long v53
    cdef bint v49
    cdef bint v54
    cdef signed long v56
    cdef bint v57
    cdef signed long v59
    cdef signed long v60
    cdef bint v61
    cdef signed long v63
    cdef signed long v64
    cdef US1 v65
    cdef unsigned char v66
    cdef signed long v67
    cdef US1 v68
    cdef unsigned char v69
    cdef signed long v70
    cdef double v71
    cdef bint v72
    cdef signed long v74
    cdef bint v75
    cdef signed long v77
    cdef signed long v78
    cdef signed long v80
    cdef signed long v81
    cdef US1 v82
    cdef unsigned char v83
    cdef signed long v84
    cdef US1 v85
    cdef unsigned char v86
    cdef signed long v87
    cdef double v88
    cdef signed long v89
    cdef signed long v90
    cdef numpy.ndarray[signed long,ndim=1] v91
    cdef bint v92
    cdef Mut1 v93
    cdef double v94
    cdef double v95
    cdef double v96
    cdef double v97
    cdef numpy.ndarray[double,ndim=1] v98
    cdef numpy.ndarray[double,ndim=1] v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef bint v102
    cdef bint v103
    cdef unsigned long long v104
    cdef double v105
    cdef Mut1 v107
    cdef double v108
    cdef double v109
    cdef double v110
    cdef double v111
    cdef numpy.ndarray[double,ndim=1] v112
    cdef numpy.ndarray[double,ndim=1] v113
    cdef unsigned long long v114
    cdef unsigned long long v115
    cdef bint v116
    cdef bint v117
    cdef unsigned long long v118
    cdef double v119
    if v10 == 0: # call
        v18 = method33(v3)
        v19 = method33(v7)
        v20 = method33(v4)
        v21 = v19 == v18
        if v21:
            v23 = v20 == v18
        else:
            v23 = 0
        if v23:
            v24 = v19 < v20
            if v24:
                v47 = (<signed long>-1)
            else:
                v25 = v19 > v20
                if v25:
                    v47 = (<signed long>1)
                else:
                    v47 = (<signed long>0)
        else:
            if v21:
                v47 = (<signed long>1)
            else:
                v28 = v20 == v18
                if v28:
                    v47 = (<signed long>-1)
                else:
                    v29 = v19 > v18
                    if v29:
                        v30, v31 = v19, v18
                    else:
                        v30, v31 = v18, v19
                    v32 = v20 > v18
                    if v32:
                        v33, v34 = v20, v18
                    else:
                        v33, v34 = v18, v20
                    v35 = v30 < v33
                    if v35:
                        v38 = (<signed long>-1)
                    else:
                        v36 = v30 > v33
                        if v36:
                            v38 = (<signed long>1)
                        else:
                            v38 = (<signed long>0)
                    v39 = v38 == (<signed long>0)
                    if v39:
                        v40 = v31 < v34
                        if v40:
                            v47 = (<signed long>-1)
                        else:
                            v41 = v31 > v34
                            if v41:
                                v47 = (<signed long>1)
                            else:
                                v47 = (<signed long>0)
                    else:
                        v47 = v38
        v48 = v47 == (<signed long>1)
        if v48:
            v52, v53 = v8, v6
        else:
            v49 = v47 == (<signed long>-1)
            if v49:
                v52, v53 = v5, v6
            else:
                v52, v53 = v8, (<signed long>0)
        v54 = v52 == (<unsigned char>0)
        if v54:
            v56 = v53
        else:
            v56 = -v53
        v57 = v8 == (<unsigned char>0)
        if v57:
            v59 = v56
        else:
            v59 = -v56
        v60 = v59 + v6
        v61 = v5 == (<unsigned char>0)
        if v61:
            v63 = v56
        else:
            v63 = -v56
        v64 = v63 + v6
        if v57:
            v65, v66, v67, v68, v69, v70 = v7, v8, v60, v4, v5, v64
        else:
            v65, v66, v67, v68, v69, v70 = v4, v5, v64, v7, v8, v60
        v71 = <double>v56
        return v71
    elif v10 == 1: # fold
        v72 = v5 == (<unsigned char>0)
        if v72:
            v74 = v9
        else:
            v74 = -v9
        v75 = v8 == (<unsigned char>0)
        if v75:
            v77 = v74
        else:
            v77 = -v74
        v78 = v77 + v9
        if v72:
            v80 = v74
        else:
            v80 = -v74
        v81 = v80 + v6
        if v75:
            v82, v83, v84, v85, v86, v87 = v7, v8, v78, v4, v5, v81
        else:
            v82, v83, v84, v85, v86, v87 = v4, v5, v81, v7, v8, v78
        v88 = <double>v74
        return v88
    elif v10 == 2: # raise
        v89 = v2 - (<signed long>1)
        v90 = v6 + (<signed long>4)
        v91 = method30(v1, v7, v8, v90, v4, v5, v6, v89)
        v92 = v5 == (<unsigned char>0)
        if v92:
            v93 = method8(v0, v91, v12)
            v94 = v11 + v17
            v95 = v11 + v16
            v96 = libc.math.exp(v94)
            v97 = libc.math.exp(v95)
            v98 = v93.v1
            del v93
            v99 = method17(v98)
            del v98
            v100 = len(v99)
            v101 = len(v91)
            v102 = v100 == v101
            v103 = v102 == 0
            if v103:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v104 = (<unsigned long long>0)
            v105 = (<double>0.000000)
            return method76(v100, v15, v16, v17, v12, v13, v14, v11, v0, v1, v89, v3, v7, v8, v90, v4, v5, v6, v97, v99, v91, v104, v105)
        else:
            v107 = method8(v0, v91, v15)
            v108 = v11 + v14
            v109 = v11 + v13
            v110 = libc.math.exp(v108)
            v111 = libc.math.exp(v109)
            v112 = v107.v1
            del v107
            v113 = method17(v112)
            del v112
            v114 = len(v113)
            v115 = len(v91)
            v116 = v114 == v115
            v117 = v116 == 0
            if v117:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v118 = (<unsigned long long>0)
            v119 = (<double>0.000000)
            return method78(v114, v15, v16, v17, v12, v13, v14, v11, v0, v1, v89, v3, v7, v8, v90, v4, v5, v6, v111, v113, v91, v118, v119)
cdef double method76(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, signed long v10, US1 v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v6
            v32 = v30 + v5
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method77(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v32, v31, v36, v2, v3)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method76(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method75(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef Mut1 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned long long v31
    cdef double v32
    cdef Mut1 v34
    cdef double v35
    cdef double v36
    cdef double v37
    cdef double v38
    cdef numpy.ndarray[double,ndim=1] v39
    cdef numpy.ndarray[double,ndim=1] v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef bint v43
    cdef bint v44
    cdef unsigned long long v45
    cdef double v46
    cdef object v49
    cdef signed long v51
    cdef signed long v52
    cdef numpy.ndarray[signed long,ndim=1] v53
    cdef bint v54
    cdef Mut1 v55
    cdef double v56
    cdef double v57
    cdef double v58
    cdef double v59
    cdef numpy.ndarray[double,ndim=1] v60
    cdef numpy.ndarray[double,ndim=1] v61
    cdef unsigned long long v62
    cdef unsigned long long v63
    cdef bint v64
    cdef bint v65
    cdef unsigned long long v66
    cdef double v67
    cdef Mut1 v69
    cdef double v70
    cdef double v71
    cdef double v72
    cdef double v73
    cdef numpy.ndarray[double,ndim=1] v74
    cdef numpy.ndarray[double,ndim=1] v75
    cdef unsigned long long v76
    cdef unsigned long long v77
    cdef bint v78
    cdef bint v79
    cdef unsigned long long v80
    cdef double v81
    if v9 == 0: # call
        v17 = (<signed long>2)
        v18 = method30(v1, v5, v6, v7, v2, v3, v4, v17)
        v19 = v3 == (<unsigned char>0)
        if v19:
            v20 = method8(v0, v18, v11)
            v21 = v10 + v16
            v22 = v10 + v15
            v23 = libc.math.exp(v21)
            v24 = libc.math.exp(v22)
            v25 = v20.v1
            del v20
            v26 = method17(v25)
            del v25
            v27 = len(v26)
            v28 = len(v18)
            v29 = v27 == v28
            v30 = v29 == 0
            if v30:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v31 = (<unsigned long long>0)
            v32 = (<double>0.000000)
            return method76(v27, v14, v15, v16, v11, v12, v13, v10, v0, v1, v17, v8, v5, v6, v7, v2, v3, v4, v24, v26, v18, v31, v32)
        else:
            v34 = method8(v0, v18, v14)
            v35 = v10 + v13
            v36 = v10 + v12
            v37 = libc.math.exp(v35)
            v38 = libc.math.exp(v36)
            v39 = v34.v1
            del v34
            v40 = method17(v39)
            del v39
            v41 = len(v40)
            v42 = len(v18)
            v43 = v41 == v42
            v44 = v43 == 0
            if v44:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v45 = (<unsigned long long>0)
            v46 = (<double>0.000000)
            return method78(v41, v14, v15, v16, v11, v12, v13, v10, v0, v1, v17, v8, v5, v6, v7, v2, v3, v4, v38, v40, v18, v45, v46)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v51 = (<signed long>1)
        v52 = v4 + (<signed long>4)
        v53 = method30(v1, v5, v6, v52, v2, v3, v4, v51)
        v54 = v3 == (<unsigned char>0)
        if v54:
            v55 = method8(v0, v53, v11)
            v56 = v10 + v16
            v57 = v10 + v15
            v58 = libc.math.exp(v56)
            v59 = libc.math.exp(v57)
            v60 = v55.v1
            del v55
            v61 = method17(v60)
            del v60
            v62 = len(v61)
            v63 = len(v53)
            v64 = v62 == v63
            v65 = v64 == 0
            if v65:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v66 = (<unsigned long long>0)
            v67 = (<double>0.000000)
            return method76(v62, v14, v15, v16, v11, v12, v13, v10, v0, v1, v51, v8, v5, v6, v52, v2, v3, v4, v59, v61, v53, v66, v67)
        else:
            v69 = method8(v0, v53, v14)
            v70 = v10 + v13
            v71 = v10 + v12
            v72 = libc.math.exp(v70)
            v73 = libc.math.exp(v71)
            v74 = v69.v1
            del v69
            v75 = method17(v74)
            del v74
            v76 = len(v75)
            v77 = len(v53)
            v78 = v76 == v77
            v79 = v78 == 0
            if v79:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v80 = (<unsigned long long>0)
            v81 = (<double>0.000000)
            return method78(v76, v14, v15, v16, v11, v12, v13, v10, v0, v1, v51, v8, v5, v6, v52, v2, v3, v4, v73, v75, v53, v80, v81)
cdef double method74(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v6
            v31 = v29 + v5
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method75(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v31, v30, v35, v2, v3)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method74(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method79(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v3
            v31 = v29 + v2
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method75(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v5, v6, v35, v31, v30)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method79(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method73(Mut0 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15):
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef Mut1 v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef bint v27
    cdef bint v28
    cdef unsigned long long v29
    cdef double v30
    cdef Mut1 v32
    cdef double v33
    cdef double v34
    cdef double v35
    cdef double v36
    cdef numpy.ndarray[double,ndim=1] v37
    cdef numpy.ndarray[double,ndim=1] v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef bint v41
    cdef bint v42
    cdef unsigned long long v43
    cdef double v44
    v16 = v1.v2
    v17 = v6 == (<unsigned char>0)
    if v17:
        v18 = method8(v0, v16, v10)
        v19 = v9 + v15
        v20 = v9 + v14
        v21 = libc.math.exp(v19)
        v22 = libc.math.exp(v20)
        v23 = v18.v1
        del v18
        v24 = method17(v23)
        del v23
        v25 = len(v24)
        v26 = len(v16)
        v27 = v25 == v26
        v28 = v27 == 0
        if v28:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v29 = (<unsigned long long>0)
        v30 = (<double>0.000000)
        return method74(v25, v13, v14, v15, v10, v11, v12, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v22, v24, v16, v29, v30)
    else:
        v32 = method8(v0, v16, v13)
        v33 = v9 + v12
        v34 = v9 + v11
        v35 = libc.math.exp(v33)
        v36 = libc.math.exp(v34)
        v37 = v32.v1
        del v32
        v38 = method17(v37)
        del v37
        v39 = len(v38)
        v40 = len(v16)
        v41 = v39 == v40
        v42 = v41 == 0
        if v42:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v43 = (<unsigned long long>0)
        v44 = (<double>0.000000)
        return method79(v39, v13, v14, v15, v10, v11, v12, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v36, v38, v16, v43, v44)
cdef double method72(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15, unsigned long long v16, double v17):
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef bint v21
    cdef US1 v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef US2 v27
    cdef UH0 v28
    cdef US2 v29
    cdef UH0 v30
    cdef double v31
    cdef unsigned long long v32
    cdef double v33
    cdef double v35
    v18 = len(v0)
    v19 = <double>v18
    v20 = (<double>1.000000) / v19
    v21 = v16 < v18
    if v21:
        v22 = v0[v16]
        v23 = <double>v18
        v24 = (<double>1.000000) / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v9
        v27 = US2_1(v22)
        v28 = UH0_0(v27, v10)
        del v27
        v29 = US2_1(v22)
        v30 = UH0_0(v29, v13)
        del v29
        v31 = method73(v1, v2, v3, v4, v5, v6, v7, v8, v22, v26, v28, v11, v12, v30, v14, v15)
        del v28; del v30
        v32 = v16 + (<unsigned long long>1)
        v33 = v17 + v31
        return method72(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v32, v33)
    else:
        v35 = v17 * v20
        return v35
cdef double method82(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method81(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method82(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method81(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef bint v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned long long v25
    cdef double v26
    cdef bint v28
    cdef signed long v30
    cdef bint v31
    cdef signed long v33
    cdef signed long v34
    cdef signed long v36
    cdef signed long v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef double v44
    cdef signed long v45
    cdef signed long v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef bint v48
    cdef Mut1 v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef numpy.ndarray[double,ndim=1] v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef bint v59
    cdef unsigned long long v60
    cdef double v61
    cdef Mut1 v63
    cdef double v64
    cdef double v65
    cdef double v66
    cdef double v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef numpy.ndarray[double,ndim=1] v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef bint v72
    cdef bint v73
    cdef unsigned long long v74
    cdef double v75
    if v10 == 0: # call
        v18 = v8 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v7, v8, v6, v4, v5, v6
        else:
            v19, v20, v21, v22, v23, v24 = v4, v5, v6, v7, v8, v6
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        return method72(v2, v0, v1, v22, v23, v24, v19, v20, v21, v11, v12, v13, v14, v15, v16, v17, v25, v26)
    elif v10 == 1: # fold
        v28 = v5 == (<unsigned char>0)
        if v28:
            v30 = v9
        else:
            v30 = -v9
        v31 = v8 == (<unsigned char>0)
        if v31:
            v33 = v30
        else:
            v33 = -v30
        v34 = v33 + v9
        if v28:
            v36 = v30
        else:
            v36 = -v30
        v37 = v36 + v6
        if v31:
            v38, v39, v40, v41, v42, v43 = v7, v8, v34, v4, v5, v37
        else:
            v38, v39, v40, v41, v42, v43 = v4, v5, v37, v7, v8, v34
        v44 = <double>v30
        return v44
    elif v10 == 2: # raise
        v45 = v3 - (<signed long>1)
        v46 = v6 + (<signed long>2)
        v47 = method30(v1, v7, v8, v46, v4, v5, v6, v45)
        v48 = v5 == (<unsigned char>0)
        if v48:
            v49 = method8(v0, v47, v12)
            v50 = v11 + v17
            v51 = v11 + v16
            v52 = libc.math.exp(v50)
            v53 = libc.math.exp(v51)
            v54 = v49.v1
            del v49
            v55 = method17(v54)
            del v54
            v56 = len(v55)
            v57 = len(v47)
            v58 = v56 == v57
            v59 = v58 == 0
            if v59:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v60 = (<unsigned long long>0)
            v61 = (<double>0.000000)
            return method80(v56, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v45, v7, v8, v46, v4, v5, v6, v53, v55, v47, v60, v61)
        else:
            v63 = method8(v0, v47, v15)
            v64 = v11 + v14
            v65 = v11 + v13
            v66 = libc.math.exp(v64)
            v67 = libc.math.exp(v65)
            v68 = v63.v1
            del v63
            v69 = method17(v68)
            del v68
            v70 = len(v69)
            v71 = len(v47)
            v72 = v70 == v71
            v73 = v72 == 0
            if v73:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v74 = (<unsigned long long>0)
            v75 = (<double>0.000000)
            return method82(v70, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v45, v7, v8, v46, v4, v5, v6, v67, v69, v47, v74, v75)
cdef double method80(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, signed long v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v6
            v32 = v30 + v5
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method81(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v32, v31, v36, v2, v3)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method80(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method71(Mut0 v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef double v25
    cdef bint v27
    cdef signed long v29
    cdef bint v30
    cdef signed long v32
    cdef signed long v33
    cdef signed long v35
    cdef signed long v36
    cdef US1 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef US1 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef double v43
    cdef signed long v44
    cdef signed long v45
    cdef numpy.ndarray[signed long,ndim=1] v46
    cdef bint v47
    cdef Mut1 v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef numpy.ndarray[double,ndim=1] v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef bint v57
    cdef bint v58
    cdef unsigned long long v59
    cdef double v60
    cdef Mut1 v62
    cdef double v63
    cdef double v64
    cdef double v65
    cdef double v66
    cdef numpy.ndarray[double,ndim=1] v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef bint v71
    cdef bint v72
    cdef unsigned long long v73
    cdef double v74
    if v9 == 0: # call
        v17 = v8 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v7, v8, v6, v4, v5, v6
        else:
            v18, v19, v20, v21, v22, v23 = v4, v5, v6, v7, v8, v6
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method72(v2, v0, v1, v21, v22, v23, v18, v19, v20, v10, v11, v12, v13, v14, v15, v16, v24, v25)
    elif v9 == 1: # fold
        v27 = v5 == (<unsigned char>0)
        if v27:
            v29 = v6
        else:
            v29 = -v6
        v30 = v8 == (<unsigned char>0)
        if v30:
            v32 = v29
        else:
            v32 = -v29
        v33 = v32 + v6
        if v27:
            v35 = v29
        else:
            v35 = -v29
        v36 = v35 + v6
        if v30:
            v37, v38, v39, v40, v41, v42 = v7, v8, v33, v4, v5, v36
        else:
            v37, v38, v39, v40, v41, v42 = v4, v5, v36, v7, v8, v33
        v43 = <double>v29
        return v43
    elif v9 == 2: # raise
        v44 = v3 - (<signed long>1)
        v45 = v6 + (<signed long>2)
        v46 = method30(v1, v7, v8, v45, v4, v5, v6, v44)
        v47 = v5 == (<unsigned char>0)
        if v47:
            v48 = method8(v0, v46, v11)
            v49 = v10 + v16
            v50 = v10 + v15
            v51 = libc.math.exp(v49)
            v52 = libc.math.exp(v50)
            v53 = v48.v1
            del v48
            v54 = method17(v53)
            del v53
            v55 = len(v54)
            v56 = len(v46)
            v57 = v55 == v56
            v58 = v57 == 0
            if v58:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v59 = (<unsigned long long>0)
            v60 = (<double>0.000000)
            return method80(v55, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v44, v7, v8, v45, v4, v5, v6, v52, v54, v46, v59, v60)
        else:
            v62 = method8(v0, v46, v14)
            v63 = v10 + v13
            v64 = v10 + v12
            v65 = libc.math.exp(v63)
            v66 = libc.math.exp(v64)
            v67 = v62.v1
            del v62
            v68 = method17(v67)
            del v67
            v69 = len(v68)
            v70 = len(v46)
            v71 = v69 == v70
            v72 = v71 == 0
            if v72:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v73 = (<unsigned long long>0)
            v74 = (<double>0.000000)
            return method82(v69, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v44, v7, v8, v45, v4, v5, v6, v66, v68, v46, v73, v74)
cdef double method70(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v6
            v31 = v29 + v5
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method71(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v31, v30, v35, v2, v3)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method70(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method83(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15, unsigned char v16, double v17, numpy.ndarray[double,ndim=1] v18, numpy.ndarray[signed long,ndim=1] v19, unsigned long long v20, double v21):
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef US0 v25
    cdef bint v26
    cdef bint v28
    cdef double v37
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef double v38
    cdef double v39
    v22 = v20 < v0
    if v22:
        v23 = v20 + (<unsigned long long>1)
        v24 = v18[v20]
        v25 = v19[v20]
        v26 = v24 == (<double>0.000000)
        if v26:
            v28 = v17 == (<double>0.000000)
        else:
            v28 = 0
        if v28:
            v37 = (<double>0.000000)
        else:
            v29 = libc.math.log(v24)
            v30 = v29 + v3
            v31 = v29 + v2
            v32 = US2_0(v25)
            v33 = UH0_0(v32, v4)
            del v32
            v34 = US2_0(v25)
            v35 = UH0_0(v34, v1)
            del v34
            v37 = method71(v8, v9, v10, v11, v12, v13, v14, v15, v16, v25, v7, v33, v5, v6, v35, v31, v30)
            del v33; del v35
        v38 = v37 * v24
        v39 = v21 + v38
        return method83(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v23, v39)
    else:
        return v21
cdef double method69(Mut0 v0, US1 v1, US1 v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, US0 v5, double v6, UH0 v7, double v8, double v9, UH0 v10, double v11, double v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef Mut1 v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v29
    cdef unsigned long long v30
    cdef double v31
    cdef Mut1 v33
    cdef double v34
    cdef double v35
    cdef double v36
    cdef double v37
    cdef numpy.ndarray[double,ndim=1] v38
    cdef numpy.ndarray[double,ndim=1] v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef bint v42
    cdef bint v43
    cdef unsigned long long v44
    cdef double v45
    cdef object v48
    cdef signed long v50
    cdef unsigned char v51
    cdef signed long v52
    cdef unsigned char v53
    cdef signed long v54
    cdef numpy.ndarray[signed long,ndim=1] v55
    cdef bint v56
    cdef Mut1 v57
    cdef double v58
    cdef double v59
    cdef double v60
    cdef double v61
    cdef numpy.ndarray[double,ndim=1] v62
    cdef numpy.ndarray[double,ndim=1] v63
    cdef unsigned long long v64
    cdef unsigned long long v65
    cdef bint v66
    cdef bint v67
    cdef unsigned long long v68
    cdef double v69
    cdef Mut1 v71
    cdef double v72
    cdef double v73
    cdef double v74
    cdef double v75
    cdef numpy.ndarray[double,ndim=1] v76
    cdef numpy.ndarray[double,ndim=1] v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef bint v80
    cdef bint v81
    cdef unsigned long long v82
    cdef double v83
    if v5 == 0: # call
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method23(v3, v1, v16, v15, v2, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = method8(v0, v17, v7)
            v20 = v6 + v12
            v21 = v6 + v11
            v22 = libc.math.exp(v20)
            v23 = libc.math.exp(v21)
            v24 = v19.v1
            del v19
            v25 = method17(v24)
            del v24
            v26 = len(v25)
            v27 = len(v17)
            v28 = v26 == v27
            v29 = v28 == 0
            if v29:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v30 = (<unsigned long long>0)
            v31 = (<double>0.000000)
            return method70(v26, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v13, v1, v16, v15, v2, v14, v23, v25, v17, v30, v31)
        else:
            v33 = method8(v0, v17, v10)
            v34 = v6 + v9
            v35 = v6 + v8
            v36 = libc.math.exp(v34)
            v37 = libc.math.exp(v35)
            v38 = v33.v1
            del v33
            v39 = method17(v38)
            del v38
            v40 = len(v39)
            v41 = len(v17)
            v42 = v40 == v41
            v43 = v42 == 0
            if v43:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v44 = (<unsigned long long>0)
            v45 = (<double>0.000000)
            return method83(v40, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v13, v1, v16, v15, v2, v14, v37, v39, v17, v44, v45)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v50 = (<signed long>1)
        v51 = (<unsigned char>1)
        v52 = (<signed long>1)
        v53 = (<unsigned char>0)
        v54 = (<signed long>3)
        v55 = method30(v3, v1, v53, v54, v2, v51, v52, v50)
        v56 = v51 == (<unsigned char>0)
        if v56:
            v57 = method8(v0, v55, v7)
            v58 = v6 + v12
            v59 = v6 + v11
            v60 = libc.math.exp(v58)
            v61 = libc.math.exp(v59)
            v62 = v57.v1
            del v57
            v63 = method17(v62)
            del v62
            v64 = len(v63)
            v65 = len(v55)
            v66 = v64 == v65
            v67 = v66 == 0
            if v67:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v68 = (<unsigned long long>0)
            v69 = (<double>0.000000)
            return method80(v64, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v50, v1, v53, v54, v2, v51, v52, v61, v63, v55, v68, v69)
        else:
            v71 = method8(v0, v55, v10)
            v72 = v6 + v9
            v73 = v6 + v8
            v74 = libc.math.exp(v72)
            v75 = libc.math.exp(v73)
            v76 = v71.v1
            del v71
            v77 = method17(v76)
            del v76
            v78 = len(v77)
            v79 = len(v55)
            v80 = v78 == v79
            v81 = v80 == 0
            if v81:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v82 = (<unsigned long long>0)
            v83 = (<double>0.000000)
            return method82(v78, v10, v11, v12, v7, v8, v9, v6, v0, v3, v4, v50, v1, v53, v54, v2, v51, v52, v75, v77, v55, v82, v83)
cdef double method68(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, US1 v9, US1 v10, Heap0 v11, numpy.ndarray[signed long,ndim=1] v12, double v13, numpy.ndarray[double,ndim=1] v14, numpy.ndarray[signed long,ndim=1] v15, unsigned long long v16, double v17):
    cdef bint v18
    cdef unsigned long long v19
    cdef double v20
    cdef US0 v21
    cdef bint v22
    cdef bint v24
    cdef double v33
    cdef double v25
    cdef double v26
    cdef double v27
    cdef US2 v28
    cdef UH0 v29
    cdef US2 v30
    cdef UH0 v31
    cdef double v34
    cdef double v35
    v18 = v16 < v0
    if v18:
        v19 = v16 + (<unsigned long long>1)
        v20 = v14[v16]
        v21 = v15[v16]
        v22 = v20 == (<double>0.000000)
        if v22:
            v24 = v13 == (<double>0.000000)
        else:
            v24 = 0
        if v24:
            v33 = (<double>0.000000)
        else:
            v25 = libc.math.log(v20)
            v26 = v25 + v6
            v27 = v25 + v5
            v28 = US2_0(v21)
            v29 = UH0_0(v28, v4)
            del v28
            v30 = US2_0(v21)
            v31 = UH0_0(v30, v1)
            del v30
            v33 = method69(v8, v9, v10, v11, v12, v21, v7, v29, v27, v26, v31, v2, v3)
            del v29; del v31
        v34 = v33 * v20
        v35 = v17 + v34
        return method68(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v19, v35)
    else:
        return v17
cdef double method67(Mut0 v0, Heap0 v1, US1 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef Mut1 v13
    cdef double v14
    cdef double v15
    cdef double v16
    cdef double v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    v12 = v1.v2
    v13 = method8(v0, v12, v6)
    v14 = v5 + v11
    v15 = v5 + v10
    v16 = libc.math.exp(v14)
    v17 = libc.math.exp(v15)
    v18 = v13.v1
    del v13
    v19 = method17(v18)
    del v18
    v20 = len(v19)
    v21 = len(v12)
    v22 = v20 == v21
    v23 = v22 == 0
    if v23:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v24 = (<unsigned long long>0)
    v25 = (<double>0.000000)
    return method68(v20, v9, v10, v11, v6, v7, v8, v5, v0, v2, v3, v1, v4, v17, v19, v12, v24, v25)
cdef double method66(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, US1 v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10, unsigned long long v11, double v12):
    cdef unsigned long long v13
    cdef double v14
    cdef double v15
    cdef bint v16
    cdef US1 v17
    cdef unsigned long long v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef unsigned long long v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef double v27
    cdef unsigned long long v28
    cdef double v29
    cdef double v31
    v13 = len(v0)
    v14 = <double>v13
    v15 = (<double>1.000000) / v14
    v16 = v11 < v13
    if v16:
        v17 = v0[v11]
        v18 = v13 - (<unsigned long long>1)
        v19 = numpy.empty(v18,dtype=numpy.int32)
        v20 = (<unsigned long long>0)
        method4(v18, v11, v0, v19, v20)
        v21 = <double>v13
        v22 = (<double>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v4
        v25 = US2_1(v17)
        v26 = UH0_0(v25, v8)
        del v25
        v27 = method67(v1, v2, v3, v17, v19, v24, v5, v6, v7, v26, v9, v10)
        del v19; del v26
        v28 = v11 + (<unsigned long long>1)
        v29 = v12 + v27
        return method66(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v28, v29)
    else:
        v31 = v12 * v15
        return v31
cdef double method65(Mut0 v0, Heap0 v1, US1 v2, numpy.ndarray[signed long,ndim=1] v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    v11 = (<unsigned long long>0)
    v12 = (<double>0.000000)
    return method66(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9, v10, v11, v12)
cdef double method64(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Heap0 v2, UH0 v3, double v4, double v5, UH0 v6, double v7, double v8, unsigned long long v9, double v10):
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
    cdef US2 v22
    cdef UH0 v23
    cdef double v24
    cdef unsigned long long v25
    cdef double v26
    cdef double v28
    v11 = len(v0)
    v12 = <double>v11
    v13 = (<double>1.000000) / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - (<unsigned long long>1)
        v17 = numpy.empty(v16,dtype=numpy.int32)
        v18 = (<unsigned long long>0)
        method4(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = (<double>1.000000) / v19
        v21 = libc.math.log(v20)
        v22 = US2_1(v15)
        v23 = UH0_0(v22, v3)
        del v22
        v24 = method65(v1, v2, v15, v17, v21, v23, v4, v5, v6, v7, v8)
        del v17; del v23
        v25 = v9 + (<unsigned long long>1)
        v26 = v10 + v24
        return method64(v0, v1, v2, v3, v4, v5, v6, v7, v8, v25, v26)
    else:
        v28 = v10 * v13
        return v28
cdef void method85(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method85(v0, v1, v4)
    else:
        pass
cdef Mut2 method84(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut2 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = (<unsigned long long>0)
    method85(v1, v3, v4)
    v5 = Mut2(v0, v3, (<unsigned long long>0))
    del v3
    return v5
cdef void method93(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method93(v0, v1, v4)
    else:
        pass
cdef void method95(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method95(v0, v1, v4)
    else:
        pass
cdef void method97(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut3 v9
    cdef Tuple1 tmp3
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp3 = v3[v4]
        v7, v8, v9 = tmp3.v0, tmp3.v1, tmp3.v2
        del tmp3
        v10 = v7 % v1
        v11 = v2[v10]
        v11.append(Tuple1(v7, v8, v9))
        del v8; del v9; del v11
        method97(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method96(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        method97(v8, v2, v3, v7, v9)
        del v7
        method96(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method94(Mut2 v0):
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
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = (<unsigned long long>0)
    method95(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method96(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Mut3 method92(Mut2 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut3 v10
    cdef Tuple1 tmp2
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v14
    cdef unsigned long long v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef numpy.ndarray[double,ndim=1] v22
    cdef unsigned long long v23
    cdef Mut3 v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef numpy.ndarray[object,ndim=1] v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef bint v32
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp2 = v4[v5]
        v8, v9, v10 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        v11 = v3 == v8
        if v11:
            v13 = method11(v9, v1)
        else:
            v13 = 0
        del v9
        if v13:
            return v10
        else:
            del v10
            v14 = v5 + (<unsigned long long>1)
            return method92(v0, v1, v2, v3, v4, v14)
    else:
        v17 = len(v2)
        v18 = numpy.empty(v17,dtype=numpy.float64)
        v19 = (<unsigned long long>0)
        method93(v17, v18, v19)
        v20 = numpy.empty(v17,dtype=numpy.float64)
        v21 = (<unsigned long long>0)
        method93(v17, v20, v21)
        v22 = numpy.empty(v17,dtype=numpy.float64)
        v23 = (<unsigned long long>0)
        method93(v17, v22, v23)
        v24 = Mut3(v2, v22, v18, (<unsigned long long>1), v20)
        del v18; del v20; del v22
        v4.append(Tuple1(v3, v1, v24))
        v25 = v0.v2
        v26 = v25 + (<unsigned long long>1)
        v0.v2 = v26
        v27 = v0.v2
        v28 = v0.v0
        v29 = v0.v1
        v30 = len(v29)
        del v29
        v31 = v28 * v30
        v32 = v27 >= v31
        if v32:
            method94(v0)
        else:
            pass
        return v24
cdef Mut3 method91(Mut2 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
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
    v9 = (<unsigned long long>0)
    return method92(v0, v2, v1, v4, v8, v9)
cdef double method99(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef bint v8
    cdef double v9
    cdef double v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        v7 = v1[v3]
        v8 = (<double>0.000000) >= v7
        if v8:
            v9 = (<double>0.000000)
        else:
            v9 = v7
        v10 = v9 + v4
        v2[v3] = v9
        return method99(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method100(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method100(v0, v1, v2, v5)
    else:
        pass
cdef void method101(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v7 = v6 / v1
        v2[v3] = v7
        method101(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method98(numpy.ndarray[double,ndim=1] v0):
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
    v3 = (<unsigned long long>0)
    v4 = (<double>0.000000)
    v5 = method99(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method100(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method101(v11, v5, v2, v12)
    return v2
cdef void method112(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned char v3, numpy.ndarray[double,ndim=1] v4, unsigned long long v5):
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef bint v10
    cdef double v12
    cdef double v13
    cdef double v14
    v6 = v5 < v0
    if v6:
        v7 = v5 + (<unsigned long long>1)
        v8 = v4[v5]
        v9 = v2[v5]
        v10 = v3 == (<unsigned char>0)
        if v10:
            v12 = v9
        else:
            v12 = -v9
        v13 = v1 * v12
        v14 = v8 + v13
        v4[v5] = v14
        method112(v0, v1, v2, v3, v4, v7)
    else:
        pass
cdef double method113(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, signed long v11, US1 v12, US1 v13, unsigned char v14, signed long v15, US1 v16, unsigned char v17, signed long v18, double v19, numpy.ndarray[double,ndim=1] v20, numpy.ndarray[signed long,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v20[v22]
        v27 = v21[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v19 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v3
            v33 = v31 + v2
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method111(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v27, v7, v35, v5, v6, v37, v33, v32)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        return method113(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method111(Mut0 v0, Mut2 v1, Heap0 v2, signed long v3, US1 v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US0 v11, double v12, UH0 v13, double v14, double v15, UH0 v16, double v17, double v18):
    cdef signed long v19
    cdef signed long v20
    cdef signed long v21
    cdef bint v22
    cdef bint v24
    cdef signed long v48
    cdef bint v25
    cdef bint v26
    cdef bint v29
    cdef bint v30
    cdef signed long v31
    cdef signed long v32
    cdef bint v33
    cdef signed long v34
    cdef signed long v35
    cdef bint v36
    cdef signed long v39
    cdef bint v37
    cdef bint v40
    cdef bint v41
    cdef bint v42
    cdef bint v49
    cdef unsigned char v53
    cdef signed long v54
    cdef bint v50
    cdef bint v55
    cdef signed long v57
    cdef bint v58
    cdef signed long v60
    cdef signed long v61
    cdef bint v62
    cdef signed long v64
    cdef signed long v65
    cdef US1 v66
    cdef unsigned char v67
    cdef signed long v68
    cdef US1 v69
    cdef unsigned char v70
    cdef signed long v71
    cdef double v72
    cdef bint v73
    cdef signed long v75
    cdef bint v76
    cdef signed long v78
    cdef signed long v79
    cdef signed long v81
    cdef signed long v82
    cdef US1 v83
    cdef unsigned char v84
    cdef signed long v85
    cdef US1 v86
    cdef unsigned char v87
    cdef signed long v88
    cdef double v89
    cdef signed long v90
    cdef signed long v91
    cdef numpy.ndarray[signed long,ndim=1] v92
    cdef bint v93
    cdef Mut3 v94
    cdef double v95
    cdef double v96
    cdef double v97
    cdef double v98
    cdef numpy.ndarray[double,ndim=1] v99
    cdef numpy.ndarray[double,ndim=1] v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef bint v103
    cdef bint v104
    cdef numpy.ndarray[double,ndim=1] v105
    cdef unsigned long long v106
    cdef double v107
    cdef double v108
    cdef unsigned char v109
    cdef unsigned long long v110
    cdef double v111
    cdef numpy.ndarray[double,ndim=1] v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef Mut1 v115
    cdef double v116
    cdef double v117
    cdef double v118
    cdef double v119
    cdef numpy.ndarray[double,ndim=1] v120
    cdef numpy.ndarray[double,ndim=1] v121
    cdef unsigned long long v122
    cdef unsigned long long v123
    cdef bint v124
    cdef bint v125
    cdef unsigned long long v126
    cdef double v127
    if v11 == 0: # call
        v19 = method33(v4)
        v20 = method33(v8)
        v21 = method33(v5)
        v22 = v20 == v19
        if v22:
            v24 = v21 == v19
        else:
            v24 = 0
        if v24:
            v25 = v20 < v21
            if v25:
                v48 = (<signed long>-1)
            else:
                v26 = v20 > v21
                if v26:
                    v48 = (<signed long>1)
                else:
                    v48 = (<signed long>0)
        else:
            if v22:
                v48 = (<signed long>1)
            else:
                v29 = v21 == v19
                if v29:
                    v48 = (<signed long>-1)
                else:
                    v30 = v20 > v19
                    if v30:
                        v31, v32 = v20, v19
                    else:
                        v31, v32 = v19, v20
                    v33 = v21 > v19
                    if v33:
                        v34, v35 = v21, v19
                    else:
                        v34, v35 = v19, v21
                    v36 = v31 < v34
                    if v36:
                        v39 = (<signed long>-1)
                    else:
                        v37 = v31 > v34
                        if v37:
                            v39 = (<signed long>1)
                        else:
                            v39 = (<signed long>0)
                    v40 = v39 == (<signed long>0)
                    if v40:
                        v41 = v32 < v35
                        if v41:
                            v48 = (<signed long>-1)
                        else:
                            v42 = v32 > v35
                            if v42:
                                v48 = (<signed long>1)
                            else:
                                v48 = (<signed long>0)
                    else:
                        v48 = v39
        v49 = v48 == (<signed long>1)
        if v49:
            v53, v54 = v9, v7
        else:
            v50 = v48 == (<signed long>-1)
            if v50:
                v53, v54 = v6, v7
            else:
                v53, v54 = v9, (<signed long>0)
        v55 = v53 == (<unsigned char>0)
        if v55:
            v57 = v54
        else:
            v57 = -v54
        v58 = v9 == (<unsigned char>0)
        if v58:
            v60 = v57
        else:
            v60 = -v57
        v61 = v60 + v7
        v62 = v6 == (<unsigned char>0)
        if v62:
            v64 = v57
        else:
            v64 = -v57
        v65 = v64 + v7
        if v58:
            v66, v67, v68, v69, v70, v71 = v8, v9, v61, v5, v6, v65
        else:
            v66, v67, v68, v69, v70, v71 = v5, v6, v65, v8, v9, v61
        v72 = <double>v57
        return v72
    elif v11 == 1: # fold
        v73 = v6 == (<unsigned char>0)
        if v73:
            v75 = v10
        else:
            v75 = -v10
        v76 = v9 == (<unsigned char>0)
        if v76:
            v78 = v75
        else:
            v78 = -v75
        v79 = v78 + v10
        if v73:
            v81 = v75
        else:
            v81 = -v75
        v82 = v81 + v7
        if v76:
            v83, v84, v85, v86, v87, v88 = v8, v9, v79, v5, v6, v82
        else:
            v83, v84, v85, v86, v87, v88 = v5, v6, v82, v8, v9, v79
        v89 = <double>v75
        return v89
    elif v11 == 2: # raise
        v90 = v3 - (<signed long>1)
        v91 = v7 + (<signed long>4)
        v92 = method30(v2, v8, v9, v91, v5, v6, v7, v90)
        v93 = v6 == (<unsigned char>0)
        if v93:
            v94 = method91(v1, v92, v13)
            v95 = v12 + v18
            v96 = v12 + v17
            v97 = libc.math.exp(v95)
            v98 = libc.math.exp(v96)
            v99 = v94.v2
            v100 = method98(v99)
            del v99
            v101 = len(v100)
            v102 = len(v92)
            v103 = v101 == v102
            v104 = v103 != 1
            if v104:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v105 = numpy.empty(v101,dtype=numpy.float64)
            v106 = (<unsigned long long>0)
            v107 = (<double>0.000000)
            v108 = method110(v101, v16, v17, v18, v13, v14, v15, v12, v0, v1, v2, v90, v4, v8, v9, v91, v5, v6, v7, v98, v100, v92, v105, v106, v107)
            del v92; del v100
            v109 = (<unsigned char>0)
            v110 = v94.v3
            v111 = <double>v110
            v112 = v94.v4
            del v94
            v113 = len(v112)
            v114 = (<unsigned long long>0)
            method112(v113, v98, v105, v109, v112, v114)
            del v105; del v112
            return v108
        else:
            v115 = method8(v0, v92, v16)
            v116 = v12 + v15
            v117 = v12 + v14
            v118 = libc.math.exp(v116)
            v119 = libc.math.exp(v117)
            v120 = v115.v1
            del v115
            v121 = method17(v120)
            del v120
            v122 = len(v121)
            v123 = len(v92)
            v124 = v122 == v123
            v125 = v124 == 0
            if v125:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v126 = (<unsigned long long>0)
            v127 = (<double>0.000000)
            return method113(v122, v16, v17, v18, v13, v14, v15, v12, v0, v1, v2, v90, v4, v8, v9, v91, v5, v6, v7, v119, v121, v92, v126, v127)
cdef double method110(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, signed long v11, US1 v12, US1 v13, unsigned char v14, signed long v15, US1 v16, unsigned char v17, signed long v18, double v19, numpy.ndarray[double,ndim=1] v20, numpy.ndarray[signed long,ndim=1] v21, numpy.ndarray[double,ndim=1] v22, unsigned long long v23, double v24):
    cdef bint v25
    cdef unsigned long long v26
    cdef double v27
    cdef US0 v28
    cdef bint v29
    cdef bint v31
    cdef double v40
    cdef double v32
    cdef double v33
    cdef double v34
    cdef US2 v35
    cdef UH0 v36
    cdef US2 v37
    cdef UH0 v38
    cdef double v41
    cdef double v42
    v25 = v23 < v0
    if v25:
        v26 = v23 + (<unsigned long long>1)
        v27 = v20[v23]
        v28 = v21[v23]
        v29 = v27 == (<double>0.000000)
        if v29:
            v31 = v19 == (<double>0.000000)
        else:
            v31 = 0
        if v31:
            v40 = (<double>0.000000)
        else:
            v32 = libc.math.log(v27)
            v33 = v32 + v6
            v34 = v32 + v5
            v35 = US2_0(v28)
            v36 = UH0_0(v35, v4)
            del v35
            v37 = US2_0(v28)
            v38 = UH0_0(v37, v1)
            del v37
            v40 = method111(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v28, v7, v36, v34, v33, v38, v2, v3)
            del v36; del v38
        v41 = v40 * v27
        v42 = v24 + v41
        v22[v23] = v40
        return method110(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v26, v42)
    else:
        return v24
cdef double method109(Mut0 v0, Mut2 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US1 v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef signed long v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef bint v20
    cdef Mut3 v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef numpy.ndarray[double,ndim=1] v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef bint v30
    cdef bint v31
    cdef numpy.ndarray[double,ndim=1] v32
    cdef unsigned long long v33
    cdef double v34
    cdef double v35
    cdef unsigned char v36
    cdef unsigned long long v37
    cdef double v38
    cdef numpy.ndarray[double,ndim=1] v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef Mut1 v42
    cdef double v43
    cdef double v44
    cdef double v45
    cdef double v46
    cdef numpy.ndarray[double,ndim=1] v47
    cdef numpy.ndarray[double,ndim=1] v48
    cdef unsigned long long v49
    cdef unsigned long long v50
    cdef bint v51
    cdef bint v52
    cdef unsigned long long v53
    cdef double v54
    cdef object v57
    cdef signed long v59
    cdef signed long v60
    cdef numpy.ndarray[signed long,ndim=1] v61
    cdef bint v62
    cdef Mut3 v63
    cdef double v64
    cdef double v65
    cdef double v66
    cdef double v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef numpy.ndarray[double,ndim=1] v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef bint v72
    cdef bint v73
    cdef numpy.ndarray[double,ndim=1] v74
    cdef unsigned long long v75
    cdef double v76
    cdef double v77
    cdef unsigned char v78
    cdef unsigned long long v79
    cdef double v80
    cdef numpy.ndarray[double,ndim=1] v81
    cdef unsigned long long v82
    cdef unsigned long long v83
    cdef Mut1 v84
    cdef double v85
    cdef double v86
    cdef double v87
    cdef double v88
    cdef numpy.ndarray[double,ndim=1] v89
    cdef numpy.ndarray[double,ndim=1] v90
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef bint v93
    cdef bint v94
    cdef unsigned long long v95
    cdef double v96
    if v10 == 0: # call
        v18 = (<signed long>2)
        v19 = method30(v2, v6, v7, v8, v3, v4, v5, v18)
        v20 = v4 == (<unsigned char>0)
        if v20:
            v21 = method91(v1, v19, v12)
            v22 = v11 + v17
            v23 = v11 + v16
            v24 = libc.math.exp(v22)
            v25 = libc.math.exp(v23)
            v26 = v21.v2
            v27 = method98(v26)
            del v26
            v28 = len(v27)
            v29 = len(v19)
            v30 = v28 == v29
            v31 = v30 != 1
            if v31:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v32 = numpy.empty(v28,dtype=numpy.float64)
            v33 = (<unsigned long long>0)
            v34 = (<double>0.000000)
            v35 = method110(v28, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v18, v9, v6, v7, v8, v3, v4, v5, v25, v27, v19, v32, v33, v34)
            del v19; del v27
            v36 = (<unsigned char>0)
            v37 = v21.v3
            v38 = <double>v37
            v39 = v21.v4
            del v21
            v40 = len(v39)
            v41 = (<unsigned long long>0)
            method112(v40, v25, v32, v36, v39, v41)
            del v32; del v39
            return v35
        else:
            v42 = method8(v0, v19, v15)
            v43 = v11 + v14
            v44 = v11 + v13
            v45 = libc.math.exp(v43)
            v46 = libc.math.exp(v44)
            v47 = v42.v1
            del v42
            v48 = method17(v47)
            del v47
            v49 = len(v48)
            v50 = len(v19)
            v51 = v49 == v50
            v52 = v51 == 0
            if v52:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v53 = (<unsigned long long>0)
            v54 = (<double>0.000000)
            return method113(v49, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v18, v9, v6, v7, v8, v3, v4, v5, v46, v48, v19, v53, v54)
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v59 = (<signed long>1)
        v60 = v5 + (<signed long>4)
        v61 = method30(v2, v6, v7, v60, v3, v4, v5, v59)
        v62 = v4 == (<unsigned char>0)
        if v62:
            v63 = method91(v1, v61, v12)
            v64 = v11 + v17
            v65 = v11 + v16
            v66 = libc.math.exp(v64)
            v67 = libc.math.exp(v65)
            v68 = v63.v2
            v69 = method98(v68)
            del v68
            v70 = len(v69)
            v71 = len(v61)
            v72 = v70 == v71
            v73 = v72 != 1
            if v73:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v74 = numpy.empty(v70,dtype=numpy.float64)
            v75 = (<unsigned long long>0)
            v76 = (<double>0.000000)
            v77 = method110(v70, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v59, v9, v6, v7, v60, v3, v4, v5, v67, v69, v61, v74, v75, v76)
            del v61; del v69
            v78 = (<unsigned char>0)
            v79 = v63.v3
            v80 = <double>v79
            v81 = v63.v4
            del v63
            v82 = len(v81)
            v83 = (<unsigned long long>0)
            method112(v82, v67, v74, v78, v81, v83)
            del v74; del v81
            return v77
        else:
            v84 = method8(v0, v61, v15)
            v85 = v11 + v14
            v86 = v11 + v13
            v87 = libc.math.exp(v85)
            v88 = libc.math.exp(v86)
            v89 = v84.v1
            del v84
            v90 = method17(v89)
            del v89
            v91 = len(v90)
            v92 = len(v61)
            v93 = v91 == v92
            v94 = v93 == 0
            if v94:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v95 = (<unsigned long long>0)
            v96 = (<double>0.000000)
            return method113(v91, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v59, v9, v6, v7, v60, v3, v4, v5, v88, v90, v61, v95, v96)
cdef double method108(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, US1 v11, unsigned char v12, signed long v13, US1 v14, unsigned char v15, signed long v16, US1 v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, numpy.ndarray[double,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v19[v22]
        v27 = v20[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v18 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v6
            v33 = v31 + v5
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method109(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v27, v7, v35, v33, v32, v37, v2, v3)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        v21[v22] = v39
        return method108(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method114(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, US1 v11, unsigned char v12, signed long v13, US1 v14, unsigned char v15, signed long v16, US1 v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method109(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method114(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method107(Mut0 v0, Mut2 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US1 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef Mut3 v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v29
    cdef numpy.ndarray[double,ndim=1] v30
    cdef unsigned long long v31
    cdef double v32
    cdef double v33
    cdef unsigned char v34
    cdef unsigned long long v35
    cdef double v36
    cdef numpy.ndarray[double,ndim=1] v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef Mut1 v40
    cdef double v41
    cdef double v42
    cdef double v43
    cdef double v44
    cdef numpy.ndarray[double,ndim=1] v45
    cdef numpy.ndarray[double,ndim=1] v46
    cdef unsigned long long v47
    cdef unsigned long long v48
    cdef bint v49
    cdef bint v50
    cdef unsigned long long v51
    cdef double v52
    v17 = v2.v2
    v18 = v7 == (<unsigned char>0)
    if v18:
        v19 = method91(v1, v17, v11)
        v20 = v10 + v16
        v21 = v10 + v15
        v22 = libc.math.exp(v20)
        v23 = libc.math.exp(v21)
        v24 = v19.v2
        v25 = method98(v24)
        del v24
        v26 = len(v25)
        v27 = len(v17)
        v28 = v26 == v27
        v29 = v28 != 1
        if v29:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v30 = numpy.empty(v26,dtype=numpy.float64)
        v31 = (<unsigned long long>0)
        v32 = (<double>0.000000)
        v33 = method108(v26, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v23, v25, v17, v30, v31, v32)
        del v17; del v25
        v34 = (<unsigned char>0)
        v35 = v19.v3
        v36 = <double>v35
        v37 = v19.v4
        del v19
        v38 = len(v37)
        v39 = (<unsigned long long>0)
        method112(v38, v23, v30, v34, v37, v39)
        del v30; del v37
        return v33
    else:
        v40 = method8(v0, v17, v14)
        v41 = v10 + v13
        v42 = v10 + v12
        v43 = libc.math.exp(v41)
        v44 = libc.math.exp(v42)
        v45 = v40.v1
        del v40
        v46 = method17(v45)
        del v45
        v47 = len(v46)
        v48 = len(v17)
        v49 = v47 == v48
        v50 = v49 == 0
        if v50:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v51 = (<unsigned long long>0)
        v52 = (<double>0.000000)
        return method114(v47, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v44, v46, v17, v51, v52)
cdef double method106(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Mut2 v2, Heap0 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16, unsigned long long v17, double v18):
    cdef unsigned long long v19
    cdef double v20
    cdef double v21
    cdef bint v22
    cdef US1 v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef double v27
    cdef US2 v28
    cdef UH0 v29
    cdef US2 v30
    cdef UH0 v31
    cdef double v32
    cdef unsigned long long v33
    cdef double v34
    cdef double v36
    v19 = len(v0)
    v20 = <double>v19
    v21 = (<double>1.000000) / v20
    v22 = v17 < v19
    if v22:
        v23 = v0[v17]
        v24 = <double>v19
        v25 = (<double>1.000000) / v24
        v26 = libc.math.log(v25)
        v27 = v26 + v10
        v28 = US2_1(v23)
        v29 = UH0_0(v28, v11)
        del v28
        v30 = US2_1(v23)
        v31 = UH0_0(v30, v14)
        del v30
        v32 = method107(v1, v2, v3, v4, v5, v6, v7, v8, v9, v23, v27, v29, v12, v13, v31, v15, v16)
        del v29; del v31
        v33 = v17 + (<unsigned long long>1)
        v34 = v18 + v32
        return method106(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v33, v34)
    else:
        v36 = v18 * v21
        return v36
cdef double method117(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, unsigned char v17, signed long v18, double v19, numpy.ndarray[double,ndim=1] v20, numpy.ndarray[signed long,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v20[v22]
        v27 = v21[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v19 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v3
            v33 = v31 + v2
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method116(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v27, v7, v35, v5, v6, v37, v33, v32)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        return method117(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method116(Mut0 v0, Mut2 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US0 v11, double v12, UH0 v13, double v14, double v15, UH0 v16, double v17, double v18):
    cdef bint v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef US1 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef double v27
    cdef bint v29
    cdef signed long v31
    cdef bint v32
    cdef signed long v34
    cdef signed long v35
    cdef signed long v37
    cdef signed long v38
    cdef US1 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef double v45
    cdef signed long v46
    cdef signed long v47
    cdef numpy.ndarray[signed long,ndim=1] v48
    cdef bint v49
    cdef Mut3 v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef double v54
    cdef numpy.ndarray[double,ndim=1] v55
    cdef numpy.ndarray[double,ndim=1] v56
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef bint v59
    cdef bint v60
    cdef numpy.ndarray[double,ndim=1] v61
    cdef unsigned long long v62
    cdef double v63
    cdef double v64
    cdef unsigned char v65
    cdef unsigned long long v66
    cdef double v67
    cdef numpy.ndarray[double,ndim=1] v68
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef Mut1 v71
    cdef double v72
    cdef double v73
    cdef double v74
    cdef double v75
    cdef numpy.ndarray[double,ndim=1] v76
    cdef numpy.ndarray[double,ndim=1] v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef bint v80
    cdef bint v81
    cdef unsigned long long v82
    cdef double v83
    if v11 == 0: # call
        v19 = v9 == (<unsigned char>0)
        if v19:
            v20, v21, v22, v23, v24, v25 = v8, v9, v7, v5, v6, v7
        else:
            v20, v21, v22, v23, v24, v25 = v5, v6, v7, v8, v9, v7
        v26 = (<unsigned long long>0)
        v27 = (<double>0.000000)
        return method106(v3, v0, v1, v2, v23, v24, v25, v20, v21, v22, v12, v13, v14, v15, v16, v17, v18, v26, v27)
    elif v11 == 1: # fold
        v29 = v6 == (<unsigned char>0)
        if v29:
            v31 = v10
        else:
            v31 = -v10
        v32 = v9 == (<unsigned char>0)
        if v32:
            v34 = v31
        else:
            v34 = -v31
        v35 = v34 + v10
        if v29:
            v37 = v31
        else:
            v37 = -v31
        v38 = v37 + v7
        if v32:
            v39, v40, v41, v42, v43, v44 = v8, v9, v35, v5, v6, v38
        else:
            v39, v40, v41, v42, v43, v44 = v5, v6, v38, v8, v9, v35
        v45 = <double>v31
        return v45
    elif v11 == 2: # raise
        v46 = v4 - (<signed long>1)
        v47 = v7 + (<signed long>2)
        v48 = method30(v2, v8, v9, v47, v5, v6, v7, v46)
        v49 = v6 == (<unsigned char>0)
        if v49:
            v50 = method91(v1, v48, v13)
            v51 = v12 + v18
            v52 = v12 + v17
            v53 = libc.math.exp(v51)
            v54 = libc.math.exp(v52)
            v55 = v50.v2
            v56 = method98(v55)
            del v55
            v57 = len(v56)
            v58 = len(v48)
            v59 = v57 == v58
            v60 = v59 != 1
            if v60:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v61 = numpy.empty(v57,dtype=numpy.float64)
            v62 = (<unsigned long long>0)
            v63 = (<double>0.000000)
            v64 = method115(v57, v16, v17, v18, v13, v14, v15, v12, v0, v1, v2, v3, v46, v8, v9, v47, v5, v6, v7, v54, v56, v48, v61, v62, v63)
            del v48; del v56
            v65 = (<unsigned char>0)
            v66 = v50.v3
            v67 = <double>v66
            v68 = v50.v4
            del v50
            v69 = len(v68)
            v70 = (<unsigned long long>0)
            method112(v69, v54, v61, v65, v68, v70)
            del v61; del v68
            return v64
        else:
            v71 = method8(v0, v48, v16)
            v72 = v12 + v15
            v73 = v12 + v14
            v74 = libc.math.exp(v72)
            v75 = libc.math.exp(v73)
            v76 = v71.v1
            del v71
            v77 = method17(v76)
            del v76
            v78 = len(v77)
            v79 = len(v48)
            v80 = v78 == v79
            v81 = v80 == 0
            if v81:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v82 = (<unsigned long long>0)
            v83 = (<double>0.000000)
            return method117(v78, v16, v17, v18, v13, v14, v15, v12, v0, v1, v2, v3, v46, v8, v9, v47, v5, v6, v7, v75, v77, v48, v82, v83)
cdef double method115(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, unsigned char v17, signed long v18, double v19, numpy.ndarray[double,ndim=1] v20, numpy.ndarray[signed long,ndim=1] v21, numpy.ndarray[double,ndim=1] v22, unsigned long long v23, double v24):
    cdef bint v25
    cdef unsigned long long v26
    cdef double v27
    cdef US0 v28
    cdef bint v29
    cdef bint v31
    cdef double v40
    cdef double v32
    cdef double v33
    cdef double v34
    cdef US2 v35
    cdef UH0 v36
    cdef US2 v37
    cdef UH0 v38
    cdef double v41
    cdef double v42
    v25 = v23 < v0
    if v25:
        v26 = v23 + (<unsigned long long>1)
        v27 = v20[v23]
        v28 = v21[v23]
        v29 = v27 == (<double>0.000000)
        if v29:
            v31 = v19 == (<double>0.000000)
        else:
            v31 = 0
        if v31:
            v40 = (<double>0.000000)
        else:
            v32 = libc.math.log(v27)
            v33 = v32 + v6
            v34 = v32 + v5
            v35 = US2_0(v28)
            v36 = UH0_0(v35, v4)
            del v35
            v37 = US2_0(v28)
            v38 = UH0_0(v37, v1)
            del v37
            v40 = method116(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v28, v7, v36, v34, v33, v38, v2, v3)
            del v36; del v38
        v41 = v40 * v27
        v42 = v24 + v41
        v22[v23] = v40
        return method115(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v26, v42)
    else:
        return v24
cdef double method105(Mut0 v0, Mut2 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, US0 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef bint v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned long long v25
    cdef double v26
    cdef bint v28
    cdef signed long v30
    cdef bint v31
    cdef signed long v33
    cdef signed long v34
    cdef signed long v36
    cdef signed long v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef double v44
    cdef signed long v45
    cdef signed long v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef bint v48
    cdef Mut3 v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef numpy.ndarray[double,ndim=1] v54
    cdef numpy.ndarray[double,ndim=1] v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef bint v59
    cdef numpy.ndarray[double,ndim=1] v60
    cdef unsigned long long v61
    cdef double v62
    cdef double v63
    cdef unsigned char v64
    cdef unsigned long long v65
    cdef double v66
    cdef numpy.ndarray[double,ndim=1] v67
    cdef unsigned long long v68
    cdef unsigned long long v69
    cdef Mut1 v70
    cdef double v71
    cdef double v72
    cdef double v73
    cdef double v74
    cdef numpy.ndarray[double,ndim=1] v75
    cdef numpy.ndarray[double,ndim=1] v76
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef bint v79
    cdef bint v80
    cdef unsigned long long v81
    cdef double v82
    if v10 == 0: # call
        v18 = v9 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v8, v9, v7, v5, v6, v7
        else:
            v19, v20, v21, v22, v23, v24 = v5, v6, v7, v8, v9, v7
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        return method106(v3, v0, v1, v2, v22, v23, v24, v19, v20, v21, v11, v12, v13, v14, v15, v16, v17, v25, v26)
    elif v10 == 1: # fold
        v28 = v6 == (<unsigned char>0)
        if v28:
            v30 = v7
        else:
            v30 = -v7
        v31 = v9 == (<unsigned char>0)
        if v31:
            v33 = v30
        else:
            v33 = -v30
        v34 = v33 + v7
        if v28:
            v36 = v30
        else:
            v36 = -v30
        v37 = v36 + v7
        if v31:
            v38, v39, v40, v41, v42, v43 = v8, v9, v34, v5, v6, v37
        else:
            v38, v39, v40, v41, v42, v43 = v5, v6, v37, v8, v9, v34
        v44 = <double>v30
        return v44
    elif v10 == 2: # raise
        v45 = v4 - (<signed long>1)
        v46 = v7 + (<signed long>2)
        v47 = method30(v2, v8, v9, v46, v5, v6, v7, v45)
        v48 = v6 == (<unsigned char>0)
        if v48:
            v49 = method91(v1, v47, v12)
            v50 = v11 + v17
            v51 = v11 + v16
            v52 = libc.math.exp(v50)
            v53 = libc.math.exp(v51)
            v54 = v49.v2
            v55 = method98(v54)
            del v54
            v56 = len(v55)
            v57 = len(v47)
            v58 = v56 == v57
            v59 = v58 != 1
            if v59:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v60 = numpy.empty(v56,dtype=numpy.float64)
            v61 = (<unsigned long long>0)
            v62 = (<double>0.000000)
            v63 = method115(v56, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v3, v45, v8, v9, v46, v5, v6, v7, v53, v55, v47, v60, v61, v62)
            del v47; del v55
            v64 = (<unsigned char>0)
            v65 = v49.v3
            v66 = <double>v65
            v67 = v49.v4
            del v49
            v68 = len(v67)
            v69 = (<unsigned long long>0)
            method112(v68, v53, v60, v64, v67, v69)
            del v60; del v67
            return v63
        else:
            v70 = method8(v0, v47, v15)
            v71 = v11 + v14
            v72 = v11 + v13
            v73 = libc.math.exp(v71)
            v74 = libc.math.exp(v72)
            v75 = v70.v1
            del v70
            v76 = method17(v75)
            del v75
            v77 = len(v76)
            v78 = len(v47)
            v79 = v77 == v78
            v80 = v79 == 0
            if v80:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v81 = (<unsigned long long>0)
            v82 = (<double>0.000000)
            return method117(v77, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v3, v45, v8, v9, v46, v5, v6, v7, v74, v76, v47, v81, v82)
cdef double method104(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, unsigned char v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, numpy.ndarray[double,ndim=1] v21, unsigned long long v22, double v23):
    cdef bint v24
    cdef unsigned long long v25
    cdef double v26
    cdef US0 v27
    cdef bint v28
    cdef bint v30
    cdef double v39
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef double v40
    cdef double v41
    v24 = v22 < v0
    if v24:
        v25 = v22 + (<unsigned long long>1)
        v26 = v19[v22]
        v27 = v20[v22]
        v28 = v26 == (<double>0.000000)
        if v28:
            v30 = v18 == (<double>0.000000)
        else:
            v30 = 0
        if v30:
            v39 = (<double>0.000000)
        else:
            v31 = libc.math.log(v26)
            v32 = v31 + v6
            v33 = v31 + v5
            v34 = US2_0(v27)
            v35 = UH0_0(v34, v4)
            del v34
            v36 = US2_0(v27)
            v37 = UH0_0(v36, v1)
            del v36
            v39 = method105(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v27, v7, v35, v33, v32, v37, v2, v3)
            del v35; del v37
        v40 = v39 * v26
        v41 = v23 + v40
        v21[v22] = v39
        return method104(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v25, v41)
    else:
        return v23
cdef double method118(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11, signed long v12, US1 v13, unsigned char v14, signed long v15, US1 v16, unsigned char v17, double v18, numpy.ndarray[double,ndim=1] v19, numpy.ndarray[signed long,ndim=1] v20, unsigned long long v21, double v22):
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    cdef US0 v26
    cdef bint v27
    cdef bint v29
    cdef double v38
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef double v39
    cdef double v40
    v23 = v21 < v0
    if v23:
        v24 = v21 + (<unsigned long long>1)
        v25 = v19[v21]
        v26 = v20[v21]
        v27 = v25 == (<double>0.000000)
        if v27:
            v29 = v18 == (<double>0.000000)
        else:
            v29 = 0
        if v29:
            v38 = (<double>0.000000)
        else:
            v30 = libc.math.log(v25)
            v31 = v30 + v3
            v32 = v30 + v2
            v33 = US2_0(v26)
            v34 = UH0_0(v33, v4)
            del v33
            v35 = US2_0(v26)
            v36 = UH0_0(v35, v1)
            del v35
            v38 = method105(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v26, v7, v34, v5, v6, v36, v32, v31)
            del v34; del v36
        v39 = v38 * v25
        v40 = v22 + v39
        return method118(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v24, v40)
    else:
        return v22
cdef double method103(Mut0 v0, Mut2 v1, US1 v2, US1 v3, Heap0 v4, numpy.ndarray[signed long,ndim=1] v5, US0 v6, double v7, UH0 v8, double v9, double v10, UH0 v11, double v12, double v13):
    cdef signed long v14
    cdef unsigned char v15
    cdef signed long v16
    cdef unsigned char v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef Mut3 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef numpy.ndarray[double,ndim=1] v31
    cdef unsigned long long v32
    cdef double v33
    cdef double v34
    cdef unsigned char v35
    cdef unsigned long long v36
    cdef double v37
    cdef numpy.ndarray[double,ndim=1] v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef Mut1 v41
    cdef double v42
    cdef double v43
    cdef double v44
    cdef double v45
    cdef numpy.ndarray[double,ndim=1] v46
    cdef numpy.ndarray[double,ndim=1] v47
    cdef unsigned long long v48
    cdef unsigned long long v49
    cdef bint v50
    cdef bint v51
    cdef unsigned long long v52
    cdef double v53
    cdef object v56
    cdef signed long v58
    cdef unsigned char v59
    cdef signed long v60
    cdef unsigned char v61
    cdef signed long v62
    cdef numpy.ndarray[signed long,ndim=1] v63
    cdef bint v64
    cdef Mut3 v65
    cdef double v66
    cdef double v67
    cdef double v68
    cdef double v69
    cdef numpy.ndarray[double,ndim=1] v70
    cdef numpy.ndarray[double,ndim=1] v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef bint v74
    cdef bint v75
    cdef numpy.ndarray[double,ndim=1] v76
    cdef unsigned long long v77
    cdef double v78
    cdef double v79
    cdef unsigned char v80
    cdef unsigned long long v81
    cdef double v82
    cdef numpy.ndarray[double,ndim=1] v83
    cdef unsigned long long v84
    cdef unsigned long long v85
    cdef Mut1 v86
    cdef double v87
    cdef double v88
    cdef double v89
    cdef double v90
    cdef numpy.ndarray[double,ndim=1] v91
    cdef numpy.ndarray[double,ndim=1] v92
    cdef unsigned long long v93
    cdef unsigned long long v94
    cdef bint v95
    cdef bint v96
    cdef unsigned long long v97
    cdef double v98
    if v6 == 0: # call
        v14 = (<signed long>2)
        v15 = (<unsigned char>1)
        v16 = (<signed long>1)
        v17 = (<unsigned char>0)
        v18 = method23(v4, v2, v17, v16, v3, v15, v14)
        v19 = v15 == (<unsigned char>0)
        if v19:
            v20 = method91(v1, v18, v8)
            v21 = v7 + v13
            v22 = v7 + v12
            v23 = libc.math.exp(v21)
            v24 = libc.math.exp(v22)
            v25 = v20.v2
            v26 = method98(v25)
            del v25
            v27 = len(v26)
            v28 = len(v18)
            v29 = v27 == v28
            v30 = v29 != 1
            if v30:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v31 = numpy.empty(v27,dtype=numpy.float64)
            v32 = (<unsigned long long>0)
            v33 = (<double>0.000000)
            v34 = method104(v27, v11, v12, v13, v8, v9, v10, v7, v0, v1, v4, v5, v14, v2, v17, v16, v3, v15, v24, v26, v18, v31, v32, v33)
            del v18; del v26
            v35 = (<unsigned char>0)
            v36 = v20.v3
            v37 = <double>v36
            v38 = v20.v4
            del v20
            v39 = len(v38)
            v40 = (<unsigned long long>0)
            method112(v39, v24, v31, v35, v38, v40)
            del v31; del v38
            return v34
        else:
            v41 = method8(v0, v18, v11)
            v42 = v7 + v10
            v43 = v7 + v9
            v44 = libc.math.exp(v42)
            v45 = libc.math.exp(v43)
            v46 = v41.v1
            del v41
            v47 = method17(v46)
            del v46
            v48 = len(v47)
            v49 = len(v18)
            v50 = v48 == v49
            v51 = v50 == 0
            if v51:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v52 = (<unsigned long long>0)
            v53 = (<double>0.000000)
            return method118(v48, v11, v12, v13, v8, v9, v10, v7, v0, v1, v4, v5, v14, v2, v17, v16, v3, v15, v45, v47, v18, v52, v53)
    elif v6 == 1: # fold
        raise Exception("impossible")
    elif v6 == 2: # raise
        v58 = (<signed long>1)
        v59 = (<unsigned char>1)
        v60 = (<signed long>1)
        v61 = (<unsigned char>0)
        v62 = (<signed long>3)
        v63 = method30(v4, v2, v61, v62, v3, v59, v60, v58)
        v64 = v59 == (<unsigned char>0)
        if v64:
            v65 = method91(v1, v63, v8)
            v66 = v7 + v13
            v67 = v7 + v12
            v68 = libc.math.exp(v66)
            v69 = libc.math.exp(v67)
            v70 = v65.v2
            v71 = method98(v70)
            del v70
            v72 = len(v71)
            v73 = len(v63)
            v74 = v72 == v73
            v75 = v74 != 1
            if v75:
                raise Exception("The two arrays have to have the same size.")
            else:
                pass
            v76 = numpy.empty(v72,dtype=numpy.float64)
            v77 = (<unsigned long long>0)
            v78 = (<double>0.000000)
            v79 = method115(v72, v11, v12, v13, v8, v9, v10, v7, v0, v1, v4, v5, v58, v2, v61, v62, v3, v59, v60, v69, v71, v63, v76, v77, v78)
            del v63; del v71
            v80 = (<unsigned char>0)
            v81 = v65.v3
            v82 = <double>v81
            v83 = v65.v4
            del v65
            v84 = len(v83)
            v85 = (<unsigned long long>0)
            method112(v84, v69, v76, v80, v83, v85)
            del v76; del v83
            return v79
        else:
            v86 = method8(v0, v63, v11)
            v87 = v7 + v10
            v88 = v7 + v9
            v89 = libc.math.exp(v87)
            v90 = libc.math.exp(v88)
            v91 = v86.v1
            del v86
            v92 = method17(v91)
            del v91
            v93 = len(v92)
            v94 = len(v63)
            v95 = v93 == v94
            v96 = v95 == 0
            if v96:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v97 = (<unsigned long long>0)
            v98 = (<double>0.000000)
            return method117(v93, v11, v12, v13, v8, v9, v10, v7, v0, v1, v4, v5, v58, v2, v61, v62, v3, v59, v60, v90, v92, v63, v97, v98)
cdef double method102(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, Mut0 v8, Mut2 v9, US1 v10, US1 v11, Heap0 v12, numpy.ndarray[signed long,ndim=1] v13, double v14, numpy.ndarray[double,ndim=1] v15, numpy.ndarray[signed long,ndim=1] v16, numpy.ndarray[double,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef double v22
    cdef US0 v23
    cdef bint v24
    cdef bint v26
    cdef double v35
    cdef double v27
    cdef double v28
    cdef double v29
    cdef US2 v30
    cdef UH0 v31
    cdef US2 v32
    cdef UH0 v33
    cdef double v36
    cdef double v37
    v20 = v18 < v0
    if v20:
        v21 = v18 + (<unsigned long long>1)
        v22 = v15[v18]
        v23 = v16[v18]
        v24 = v22 == (<double>0.000000)
        if v24:
            v26 = v14 == (<double>0.000000)
        else:
            v26 = 0
        if v26:
            v35 = (<double>0.000000)
        else:
            v27 = libc.math.log(v22)
            v28 = v27 + v6
            v29 = v27 + v5
            v30 = US2_0(v23)
            v31 = UH0_0(v30, v4)
            del v30
            v32 = US2_0(v23)
            v33 = UH0_0(v32, v1)
            del v32
            v35 = method103(v8, v9, v10, v11, v12, v13, v23, v7, v31, v29, v28, v33, v2, v3)
            del v31; del v33
        v36 = v35 * v22
        v37 = v19 + v36
        v17[v18] = v35
        return method102(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v37)
    else:
        return v19
cdef double method90(Mut0 v0, Mut2 v1, Heap0 v2, US1 v3, US1 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, double v9, UH0 v10, double v11, double v12):
    cdef numpy.ndarray[signed long,ndim=1] v13
    cdef Mut3 v14
    cdef double v15
    cdef double v16
    cdef double v17
    cdef double v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef bint v23
    cdef bint v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef double v27
    cdef double v28
    cdef unsigned char v29
    cdef unsigned long long v30
    cdef double v31
    cdef numpy.ndarray[double,ndim=1] v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    v13 = v2.v2
    v14 = method91(v1, v13, v7)
    v15 = v6 + v12
    v16 = v6 + v11
    v17 = libc.math.exp(v15)
    v18 = libc.math.exp(v16)
    v19 = v14.v2
    v20 = method98(v19)
    del v19
    v21 = len(v20)
    v22 = len(v13)
    v23 = v21 == v22
    v24 = v23 != 1
    if v24:
        raise Exception("The two arrays have to have the same size.")
    else:
        pass
    v25 = numpy.empty(v21,dtype=numpy.float64)
    v26 = (<unsigned long long>0)
    v27 = (<double>0.000000)
    v28 = method102(v21, v10, v11, v12, v7, v8, v9, v6, v0, v1, v3, v4, v2, v5, v18, v20, v13, v25, v26, v27)
    del v13; del v20
    v29 = (<unsigned char>0)
    v30 = v14.v3
    v31 = <double>v30
    v32 = v14.v4
    del v14
    v33 = len(v32)
    v34 = (<unsigned long long>0)
    method112(v33, v18, v25, v29, v32, v34)
    del v25; del v32
    return v28
cdef double method89(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Mut2 v2, Heap0 v3, US1 v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11, unsigned long long v12, double v13):
    cdef unsigned long long v14
    cdef double v15
    cdef double v16
    cdef bint v17
    cdef US1 v18
    cdef unsigned long long v19
    cdef numpy.ndarray[signed long,ndim=1] v20
    cdef unsigned long long v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef unsigned long long v29
    cdef double v30
    cdef double v32
    v14 = len(v0)
    v15 = <double>v14
    v16 = (<double>1.000000) / v15
    v17 = v12 < v14
    if v17:
        v18 = v0[v12]
        v19 = v14 - (<unsigned long long>1)
        v20 = numpy.empty(v19,dtype=numpy.int32)
        v21 = (<unsigned long long>0)
        method4(v19, v12, v0, v20, v21)
        v22 = <double>v14
        v23 = (<double>1.000000) / v22
        v24 = libc.math.log(v23)
        v25 = v24 + v5
        v26 = US2_1(v18)
        v27 = UH0_0(v26, v9)
        del v26
        v28 = method90(v1, v2, v3, v4, v18, v20, v25, v6, v7, v8, v27, v10, v11)
        del v20; del v27
        v29 = v12 + (<unsigned long long>1)
        v30 = v13 + v28
        return method89(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v29, v30)
    else:
        v32 = v13 * v16
        return v32
cdef double method88(Mut0 v0, Mut2 v1, Heap0 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    v12 = (<unsigned long long>0)
    v13 = (<double>0.000000)
    return method89(v4, v0, v1, v2, v3, v5, v6, v7, v8, v9, v10, v11, v12, v13)
cdef double method87(numpy.ndarray[signed long,ndim=1] v0, Mut0 v1, Mut2 v2, Heap0 v3, UH0 v4, double v5, double v6, UH0 v7, double v8, double v9, unsigned long long v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef US1 v16
    cdef unsigned long long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef unsigned long long v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef double v25
    cdef unsigned long long v26
    cdef double v27
    cdef double v29
    v12 = len(v0)
    v13 = <double>v12
    v14 = (<double>1.000000) / v13
    v15 = v10 < v12
    if v15:
        v16 = v0[v10]
        v17 = v12 - (<unsigned long long>1)
        v18 = numpy.empty(v17,dtype=numpy.int32)
        v19 = (<unsigned long long>0)
        method4(v17, v10, v0, v18, v19)
        v20 = <double>v12
        v21 = (<double>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = US2_1(v16)
        v24 = UH0_0(v23, v4)
        del v23
        v25 = method88(v1, v2, v3, v16, v18, v22, v24, v5, v6, v7, v8, v9)
        del v18; del v24
        v26 = v10 + (<unsigned long long>1)
        v27 = v11 + v25
        return method87(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v26, v27)
    else:
        v29 = v11 * v14
        return v29
cdef double method122(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        v7 = v1[v3]
        v8 = v2[v3]
        v9 = v7 * v8
        v10 = v4 + v9
        return method122(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method123(unsigned long long v0, Mut3 v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef unsigned long long v8
    cdef double v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef double v11
    cdef double v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef double v16
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = v1.v3
        v9 = <double>v8
        v10 = v1.v4
        v11 = v10[v4]
        del v10
        v12 = v11 - v2
        v13 = v9 * v12
        v14 = v7 + v13
        v15 = (<double>0.000000) >= v14
        if v15:
            v16 = (<double>0.000000)
        else:
            v16 = v14
        v3[v4] = v16
        method123(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method124(unsigned long long v0, Mut3 v1, numpy.ndarray[double,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef unsigned long long v8
    cdef double v9
    cdef double v10
    cdef double v11
    cdef double v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = v1.v3
        v9 = <double>v8
        v10 = v2[v4]
        v11 = v9 * v10
        v12 = v7 + v11
        v3[v4] = v12
        method124(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method121(unsigned long long v0, list v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef UH0 v6
    cdef Mut3 v7
    cdef Tuple1 tmp4
    cdef numpy.ndarray[double,ndim=1] v8
    cdef numpy.ndarray[double,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned long long v15
    cdef double v16
    cdef double v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef numpy.ndarray[double,ndim=1] v21
    cdef numpy.ndarray[double,ndim=1] v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        tmp4 = v1[v2]
        v5, v6, v7 = tmp4.v0, tmp4.v1, tmp4.v2
        del tmp4
        del v6
        v8 = v7.v2
        v9 = method98(v8)
        del v8
        v10 = v7.v4
        v11 = len(v9)
        v12 = len(v10)
        v13 = v11 == v12
        v14 = v13 == 0
        if v14:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v15 = (<unsigned long long>0)
        v16 = (<double>0.000000)
        v17 = method122(v11, v9, v10, v15, v16)
        del v9; del v10
        v18 = v7.v2
        v19 = len(v18)
        v20 = (<unsigned long long>0)
        method123(v19, v7, v17, v18, v20)
        del v18
        v21 = v7.v2
        v22 = method98(v21)
        del v21
        v23 = v7.v1
        v24 = len(v23)
        v25 = (<unsigned long long>0)
        method124(v24, v7, v22, v23, v25)
        del v22; del v23
        v26 = v7.v3
        v27 = v26 + (<unsigned long long>1)
        v7.v3 = v27
        del v7
        method121(v0, v1, v4)
    else:
        pass
cdef void method120(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = v1[v2]
        v6 = len(v5)
        v7 = (<unsigned long long>0)
        method121(v6, v5, v7)
        del v5
        method120(v0, v1, v4)
    else:
        pass
cdef void method119(Mut2 v0):
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    v2 = v0.v1
    v3 = len(v2)
    v4 = (<unsigned long long>0)
    method120(v3, v2, v4)
cdef void method86(Mut0 v0, Mut2 v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US0 v6
    cdef US0 v7
    cdef numpy.ndarray[signed long,ndim=1] v8
    cdef US0 v9
    cdef US0 v10
    cdef US0 v11
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef US0 v13
    cdef US0 v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef US0 v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef Heap0 v18
    cdef US1 v19
    cdef US1 v20
    cdef US1 v21
    cdef US1 v22
    cdef US1 v23
    cdef US1 v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef UH0 v26
    cdef double v27
    cdef double v28
    cdef UH0 v29
    cdef double v30
    cdef double v31
    cdef unsigned long long v32
    cdef double v33
    cdef double v34
    v4 = v3 < (<unsigned long long>30)
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = 0
        v7 = 2
        v8 = numpy.empty(2,dtype=numpy.int32)
        v8[0] = v6; v8[1] = v7
        v9 = 1
        v10 = 0
        v11 = 2
        v12 = numpy.empty(3,dtype=numpy.int32)
        v12[0] = v9; v12[1] = v10; v12[2] = v11
        v13 = 1
        v14 = 0
        v15 = numpy.empty(2,dtype=numpy.int32)
        v15[0] = v13; v15[1] = v14
        v16 = 0
        v17 = numpy.empty(1,dtype=numpy.int32)
        v17[0] = v16
        v18 = Heap0(v17, v12, v8, v15)
        del v8; del v12; del v15; del v17
        v19 = 1
        v20 = 2
        v21 = 0
        v22 = 1
        v23 = 2
        v24 = 0
        v25 = numpy.empty(6,dtype=numpy.int32)
        v25[0] = v19; v25[1] = v20; v25[2] = v21; v25[3] = v22; v25[4] = v23; v25[5] = v24
        v26 = UH0_1()
        v27 = (<double>0.000000)
        v28 = (<double>0.000000)
        v29 = UH0_1()
        v30 = (<double>0.000000)
        v31 = (<double>0.000000)
        v32 = (<unsigned long long>0)
        v33 = (<double>0.000000)
        v34 = method87(v25, v0, v1, v18, v26, v27, v28, v29, v30, v31, v32, v33)
        del v18; del v25; del v26; del v29
        method119(v1)
        v2[v3] = v34
        method86(v0, v1, v2, v5)
    else:
        pass
cdef void method2(Mut0 v0, signed long v1):
    cdef bint v2
    cdef signed long v3
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
    cdef double v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef unsigned long long v30
    cdef double v31
    cdef double v32
    cdef US0 v33
    cdef US0 v34
    cdef numpy.ndarray[signed long,ndim=1] v35
    cdef US0 v36
    cdef US0 v37
    cdef US0 v38
    cdef numpy.ndarray[signed long,ndim=1] v39
    cdef US0 v40
    cdef US0 v41
    cdef numpy.ndarray[signed long,ndim=1] v42
    cdef US0 v43
    cdef numpy.ndarray[signed long,ndim=1] v44
    cdef Heap0 v45
    cdef US1 v46
    cdef US1 v47
    cdef US1 v48
    cdef US1 v49
    cdef US1 v50
    cdef US1 v51
    cdef numpy.ndarray[signed long,ndim=1] v52
    cdef UH0 v53
    cdef double v54
    cdef double v55
    cdef UH0 v56
    cdef double v57
    cdef double v58
    cdef unsigned long long v59
    cdef double v60
    cdef double v61
    cdef US0 v62
    cdef US0 v63
    cdef numpy.ndarray[signed long,ndim=1] v64
    cdef US0 v65
    cdef US0 v66
    cdef US0 v67
    cdef numpy.ndarray[signed long,ndim=1] v68
    cdef US0 v69
    cdef US0 v70
    cdef numpy.ndarray[signed long,ndim=1] v71
    cdef US0 v72
    cdef numpy.ndarray[signed long,ndim=1] v73
    cdef Heap0 v74
    cdef US1 v75
    cdef US1 v76
    cdef US1 v77
    cdef US1 v78
    cdef US1 v79
    cdef US1 v80
    cdef numpy.ndarray[signed long,ndim=1] v81
    cdef UH0 v82
    cdef double v83
    cdef double v84
    cdef UH0 v85
    cdef double v86
    cdef double v87
    cdef unsigned long long v88
    cdef double v89
    cdef double v90
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef Mut2 v93
    cdef numpy.ndarray[double,ndim=1] v94
    cdef unsigned long long v95
    v2 = v1 < (<signed long>10)
    if v2:
        v3 = v1 + (<signed long>1)
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
        v25 = (<double>0.000000)
        v26 = (<double>0.000000)
        v27 = UH0_1()
        v28 = (<double>0.000000)
        v29 = (<double>0.000000)
        v30 = (<unsigned long long>0)
        v31 = (<double>0.000000)
        v32 = method3(v23, v0, v16, v24, v25, v26, v27, v28, v29, v30, v31)
        del v16; del v23; del v24; del v27
        v33 = 0
        v34 = 2
        v35 = numpy.empty(2,dtype=numpy.int32)
        v35[0] = v33; v35[1] = v34
        v36 = 1
        v37 = 0
        v38 = 2
        v39 = numpy.empty(3,dtype=numpy.int32)
        v39[0] = v36; v39[1] = v37; v39[2] = v38
        v40 = 1
        v41 = 0
        v42 = numpy.empty(2,dtype=numpy.int32)
        v42[0] = v40; v42[1] = v41
        v43 = 0
        v44 = numpy.empty(1,dtype=numpy.int32)
        v44[0] = v43
        v45 = Heap0(v44, v39, v35, v42)
        del v35; del v39; del v42; del v44
        v46 = 1
        v47 = 2
        v48 = 0
        v49 = 1
        v50 = 2
        v51 = 0
        v52 = numpy.empty(6,dtype=numpy.int32)
        v52[0] = v46; v52[1] = v47; v52[2] = v48; v52[3] = v49; v52[4] = v50; v52[5] = v51
        v53 = UH0_1()
        v54 = (<double>0.000000)
        v55 = (<double>0.000000)
        v56 = UH0_1()
        v57 = (<double>0.000000)
        v58 = (<double>0.000000)
        v59 = (<unsigned long long>0)
        v60 = (<double>0.000000)
        v61 = method44(v52, v0, v45, v53, v54, v55, v56, v57, v58, v59, v60)
        del v45; del v52; del v53; del v56
        v62 = 0
        v63 = 2
        v64 = numpy.empty(2,dtype=numpy.int32)
        v64[0] = v62; v64[1] = v63
        v65 = 1
        v66 = 0
        v67 = 2
        v68 = numpy.empty(3,dtype=numpy.int32)
        v68[0] = v65; v68[1] = v66; v68[2] = v67
        v69 = 1
        v70 = 0
        v71 = numpy.empty(2,dtype=numpy.int32)
        v71[0] = v69; v71[1] = v70
        v72 = 0
        v73 = numpy.empty(1,dtype=numpy.int32)
        v73[0] = v72
        v74 = Heap0(v73, v68, v64, v71)
        del v64; del v68; del v71; del v73
        v75 = 1
        v76 = 2
        v77 = 0
        v78 = 1
        v79 = 2
        v80 = 0
        v81 = numpy.empty(6,dtype=numpy.int32)
        v81[0] = v75; v81[1] = v76; v81[2] = v77; v81[3] = v78; v81[4] = v79; v81[5] = v80
        v82 = UH0_1()
        v83 = (<double>0.000000)
        v84 = (<double>0.000000)
        v85 = UH0_1()
        v86 = (<double>0.000000)
        v87 = (<double>0.000000)
        v88 = (<unsigned long long>0)
        v89 = (<double>0.000000)
        v90 = method64(v81, v0, v74, v82, v83, v84, v85, v86, v87, v88, v89)
        del v74; del v81; del v82; del v85
        print(v1, v32, v61, v90)
        v91 = (<unsigned long long>3)
        v92 = (<unsigned long long>7)
        v93 = method84(v91, v92)
        v94 = numpy.empty((<unsigned long long>30),dtype=numpy.float64)
        v95 = (<unsigned long long>0)
        method86(v0, v93, v94, v95)
        del v93
        print(v94)
        del v94
        method2(v0, v3)
    else:
        pass
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef signed long v3
    v0 = (<unsigned long long>3)
    v1 = (<unsigned long long>7)
    v2 = method0(v0, v1)
    v3 = (<signed long>0)
    method2(v2, v3)
