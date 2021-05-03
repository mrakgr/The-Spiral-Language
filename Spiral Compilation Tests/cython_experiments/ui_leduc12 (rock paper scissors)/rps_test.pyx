import numpy
cimport numpy
cimport libc.math
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut1:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut2:
    cdef public signed long v0
    def __init__(self, signed long v0): self.v0 = v0
ctypedef signed long US0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # action_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 0; self.v0 = v0
cdef class US1_1(US1): # observation_
    cdef readonly unsigned char v0
    def __init__(self, unsigned char v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US1 v0
    cdef readonly UH0 v1
    def __init__(self, US1 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, unsigned long long v0, UH0 v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Mut3:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    cdef public unsigned long long v3
    def __init__(self, v0, v1, v2, unsigned long long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple2:
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
cdef void method3(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method3(v0, v1, v4)
    else:
        pass
cdef Mut1 method2(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = (<unsigned long long>0)
    method3(v1, v3, v4)
    v5 = Mut1(v0, v3, (<unsigned long long>0))
    del v3
    return v5
cdef bint method4(Mut2 v0):
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>20)
cdef bint method5(Mut2 v0):
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>1000)
cdef unsigned long long method9(UH0 v0):
    cdef US1 v1
    cdef UH0 v2
    cdef unsigned long long v26
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
    cdef unsigned char v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v35
    cdef unsigned long long v36
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # action_
            v3 = (<US1_0>v1).v0
            if v3 == 0: # paper
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # rock
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # scissors
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v26 = v15 * v17
        elif v1.tag == 1: # observation_
            v19 = (<US1_1>v1).v0
            v20 = hash(v19)
            v21 = (<unsigned long long>9223372036854775807) + v20
            v22 = v21 * (<unsigned long long>9973)
            v23 = (<signed long>1)
            v24 = (<unsigned long long>1) + v23
            v26 = v22 * v24
        del v1
        v27 = v26 * (<unsigned long long>9973)
        v28 = method9(v2)
        del v2
        v29 = v27 + v28
        v30 = (<unsigned long long>9223372036854775807) + v29
        v31 = v30 * (<unsigned long long>9973)
        v32 = (<signed long>0)
        v33 = (<unsigned long long>1) + v32
        return v31 * v33
    elif v0.tag == 1: # nil
        v35 = (<signed long>1)
        v36 = (<unsigned long long>1) + v35
        return (<unsigned long long>9223372036854765835) * v36
cdef bint method11(UH0 v0, UH0 v1):
    cdef US1 v2
    cdef UH0 v3
    cdef US1 v4
    cdef UH0 v5
    cdef bint v12
    cdef US0 v6
    cdef US0 v7
    cdef unsigned char v9
    cdef unsigned char v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # action_
            v6 = (<US1_0>v2).v0; v7 = (<US1_0>v4).v0
            if v6 == 0 and v7 == 0: # paper
                v12 = 1
            elif v6 == 1 and v7 == 1: # rock
                v12 = 1
            elif v6 == 2 and v7 == 2: # scissors
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # observation_
            v9 = (<US1_1>v2).v0; v10 = (<US1_1>v4).v0
            v12 = v9 == v10
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
cdef void method13(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method13(v0, v1, v4)
    else:
        pass
cdef void method15(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef object v10
    cdef Tuple1 tmp1
    cdef unsigned long long v11
    cdef list v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp1 = v3[v4]
        v7, v8, v9, v10 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3
        del tmp1
        v11 = v7 % v1
        v12 = v2[v11]
        v12.append(Tuple1(v7, v8, v9, v10))
        del v8; del v9; del v10; del v12
        method15(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method15(v8, v2, v3, v7, v9)
        del v7
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method12(Mut0 v0):
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
    method13(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method14(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Tuple0 method10(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef object v11
    cdef Tuple1 tmp0
    cdef bint v12
    cdef bint v14
    cdef unsigned long long v15
    cdef unsigned long long v20
    cdef object v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp0 = v4[v5]
        v8, v9, v10, v11 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3
        del tmp0
        v12 = v3 == v8
        if v12:
            v14 = method11(v9, v1)
        else:
            v14 = 0
        del v9
        if v14:
            return Tuple0(v10, v11)
        else:
            del v10; del v11
            v15 = v5 + (<unsigned long long>1)
            return method10(v0, v1, v2, v3, v4, v15)
    else:
        v20 = len(v2)
        v21 = numpy.zeros((v20,(<unsigned long long>64)),dtype=numpy.float64)
        v4.append(Tuple1(v3, v1, v2, v21))
        v22 = v0.v2
        v23 = v22 + (<unsigned long long>1)
        v0.v2 = v23
        v24 = v0.v2
        v25 = v0.v0
        v26 = v0.v1
        v27 = len(v26)
        del v26
        v28 = v25 * v27
        v29 = v24 >= v28
        if v29:
            method12(v0)
        else:
            pass
        return Tuple0(v2, v21)
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
    v9 = (<unsigned long long>0)
    return method10(v0, v2, v1, v4, v8, v9)
cdef double method17(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
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
        return method17(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method18(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method18(v0, v1, v2, v5)
    else:
        pass
cdef void method19(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
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
        method19(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method16(numpy.ndarray[double,ndim=1] v0):
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
    v5 = method17(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method18(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method19(v11, v5, v2, v12)
    return v2
cdef void method24(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method24(v0, v1, v4)
    else:
        pass
cdef void method26(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method26(v0, v1, v4)
    else:
        pass
cdef void method28(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut3 v9
    cdef Tuple2 tmp4
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp4 = v3[v4]
        v7, v8, v9 = tmp4.v0, tmp4.v1, tmp4.v2
        del tmp4
        v10 = v7 % v1
        v11 = v2[v10]
        v11.append(Tuple2(v7, v8, v9))
        del v8; del v9; del v11
        method28(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method27(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method28(v8, v2, v3, v7, v9)
        del v7
        method27(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method25(Mut1 v0):
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
    method26(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method27(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Mut3 method23(Mut1 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut3 v10
    cdef Tuple2 tmp3
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v14
    cdef unsigned long long v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef Mut3 v22
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
        tmp3 = v4[v5]
        v8, v9, v10 = tmp3.v0, tmp3.v1, tmp3.v2
        del tmp3
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
            return method23(v0, v1, v2, v3, v4, v14)
    else:
        v17 = len(v2)
        v18 = numpy.empty(v17,dtype=numpy.float64)
        v19 = (<unsigned long long>0)
        method24(v17, v18, v19)
        v20 = numpy.empty(v17,dtype=numpy.float64)
        v21 = (<unsigned long long>0)
        method24(v17, v20, v21)
        v22 = Mut3(v2, v20, v18, (<unsigned long long>1))
        del v18; del v20
        v4.append(Tuple2(v3, v1, v22))
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
            method25(v0)
        else:
            pass
        return v22
cdef Mut3 method22(Mut1 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
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
    return method23(v0, v2, v1, v4, v8, v9)
cdef double method30(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
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
        return method30(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method31(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method31(v0, v1, v2, v5)
    else:
        pass
cdef void method32(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
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
        method32(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method29(numpy.ndarray[double,ndim=1] v0):
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
    v5 = method30(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method31(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method32(v11, v5, v2, v12)
    return v2
cdef double method34(Mut1 v0, Mut0 v1, US0 v2, US0 v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef double v12
    cdef double v13
    cdef double v14
    if v3 == 0: # paper
        if v2 == 0: # paper
            v12 = (<double>0.000000)
        elif v2 == 1: # rock
            v12 = (<double>-1.000000)
        elif v2 == 2: # scissors
            v12 = (<double>1.000000)
        return v12
    elif v3 == 1: # rock
        if v2 == 0: # paper
            v13 = (<double>1.000000)
        elif v2 == 1: # rock
            v13 = (<double>0.000000)
        elif v2 == 2: # scissors
            v13 = (<double>-1.000000)
        return v13
    elif v3 == 2: # scissors
        if v2 == 0: # paper
            v14 = (<double>-1.000000)
        elif v2 == 1: # rock
            v14 = (<double>1.000000)
        elif v2 == 2: # scissors
            v14 = (<double>0.000000)
        return v14
cdef double method33(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, double v8, Mut1 v9, Mut0 v10, US0 v11, double v12, numpy.ndarray[double,ndim=1] v13, numpy.ndarray[signed long,ndim=1] v14, unsigned long long v15, double v16):
    cdef bint v17
    cdef unsigned long long v18
    cdef double v19
    cdef US0 v20
    cdef bint v21
    cdef bint v23
    cdef double v29
    cdef double v24
    cdef double v25
    cdef US1 v26
    cdef UH0 v27
    cdef double v30
    cdef double v31
    v17 = v15 < v0
    if v17:
        v18 = v15 + (<unsigned long long>1)
        v19 = v13[v15]
        v20 = v14[v15]
        v21 = v19 == (<double>0.000000)
        if v21:
            v23 = v12 == (<double>0.000000)
        else:
            v23 = 0
        if v23:
            v29 = (<double>0.000000)
        else:
            v24 = libc.math.log(v19)
            v25 = v24 + v2
            v26 = US1_0(v20)
            v27 = UH0_0(v26, v1)
            del v26
            v29 = method34(v9, v10, v11, v20, v7, v8, v4, v5, v6, v27, v25, v3)
            del v27
        v30 = v29 * v19
        v31 = v16 + v30
        return method33(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v18, v31)
    else:
        return v16
cdef double method21(Mut1 v0, Mut0 v1, numpy.ndarray[signed long,ndim=1] v2, US0 v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef Mut3 v12
    cdef double v13
    cdef double v14
    cdef double v15
    cdef double v16
    cdef numpy.ndarray[double,ndim=1] v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef Mut3 v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef numpy.ndarray[double,ndim=1] v31
    cdef numpy.ndarray[double,ndim=1] v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef bint v35
    cdef bint v36
    cdef unsigned long long v37
    cdef double v38
    cdef Mut3 v40
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
    if v3 == 0: # paper
        v12 = method22(v0, v2, v9)
        v13 = v5 + v8
        v14 = v4 + v7
        v15 = v14 - v13
        v16 = libc.math.exp(v15)
        v17 = v12.v2
        del v12
        v18 = method29(v17)
        del v17
        v19 = len(v18)
        v20 = len(v2)
        v21 = v19 == v20
        v22 = v21 == 0
        if v22:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v23 = (<unsigned long long>0)
        v24 = (<double>0.000000)
        return method33(v19, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v16, v18, v2, v23, v24)
    elif v3 == 1: # rock
        v26 = method22(v0, v2, v9)
        v27 = v5 + v8
        v28 = v4 + v7
        v29 = v28 - v27
        v30 = libc.math.exp(v29)
        v31 = v26.v2
        del v26
        v32 = method29(v31)
        del v31
        v33 = len(v32)
        v34 = len(v2)
        v35 = v33 == v34
        v36 = v35 == 0
        if v36:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v37 = (<unsigned long long>0)
        v38 = (<double>0.000000)
        return method33(v33, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v30, v32, v2, v37, v38)
    elif v3 == 2: # scissors
        v40 = method22(v0, v2, v9)
        v41 = v5 + v8
        v42 = v4 + v7
        v43 = v42 - v41
        v44 = libc.math.exp(v43)
        v45 = v40.v2
        del v40
        v46 = method29(v45)
        del v45
        v47 = len(v46)
        v48 = len(v2)
        v49 = v47 == v48
        v50 = v49 == 0
        if v50:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v51 = (<unsigned long long>0)
        v52 = (<double>0.000000)
        return method33(v47, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v44, v46, v2, v51, v52)
cdef double method20(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, double v8, Mut1 v9, Mut0 v10, numpy.ndarray[signed long,ndim=1] v11, double v12, numpy.ndarray[double,ndim=1] v13, numpy.ndarray[double,ndim=1] v14, unsigned long long v15, double v16):
    cdef bint v17
    cdef unsigned long long v18
    cdef double v19
    cdef US0 v20
    cdef bint v21
    cdef bint v23
    cdef double v29
    cdef double v24
    cdef double v25
    cdef US1 v26
    cdef UH0 v27
    cdef double v30
    cdef double v31
    v17 = v15 < v0
    if v17:
        v18 = v15 + (<unsigned long long>1)
        v19 = v13[v15]
        v20 = v11[v15]
        v21 = v19 == (<double>0.000000)
        if v21:
            v23 = v12 == (<double>0.000000)
        else:
            v23 = 0
        if v23:
            v29 = (<double>0.000000)
        else:
            v24 = libc.math.log(v19)
            v25 = v24 + v5
            v26 = US1_0(v20)
            v27 = UH0_0(v26, v4)
            del v26
            v29 = method21(v9, v10, v11, v20, v7, v8, v27, v25, v6, v1, v2, v3)
            del v27
        v30 = v29 * v19
        v31 = v16 + v30
        v14[v15] = v29
        return method20(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v18, v31)
    else:
        return v16
cdef double method7(Mut1 v0, Mut0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned char v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef object v13
    cdef Tuple0 tmp2
    cdef double v14
    cdef double v15
    cdef double v16
    cdef double v17
    cdef unsigned long long v18
    cdef object v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef numpy.ndarray[double,ndim=1] v21
    cdef unsigned long long v22
    cdef bint v23
    cdef bint v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef double v27
    cdef double v28
    tmp2 = method8(v1, v2, v6)
    v12, v13 = tmp2.v0, tmp2.v1
    del tmp2
    del v12
    v14 = v5 + v11
    v15 = v4 + v10
    v16 = v15 - v14
    v17 = libc.math.exp(v16)
    v18 = len(v2)
    v19 = (numpy.random.binomial(1,0.5,(<unsigned long long>64)) - 0.5) * 2
    v19[0] = 1
    v20 = numpy.matmul(v13,v19.T)
    v21 = method16(v20)
    del v20
    v22 = len(v21)
    v23 = v22 == v18
    v24 = v23 != 1
    if v24:
        raise Exception("The two arrays have to have the same size.")
    else:
        pass
    v25 = numpy.empty(v22,dtype=numpy.float64)
    v26 = (<unsigned long long>0)
    v27 = (<double>0.000000)
    v28 = method20(v22, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v2, v17, v21, v25, v26, v27)
    del v21
    v13 += numpy.outer(v17 * (v25 - v28), v19)
    del v13; del v19; del v25
    return v28
cdef double method6(numpy.ndarray[unsigned char,ndim=1] v0, Mut1 v1, Mut0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, double v5, double v6, UH0 v7, double v8, double v9, unsigned long long v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef unsigned char v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef US1 v21
    cdef UH0 v22
    cdef US1 v23
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
        v17 = <double>v12
        v18 = (<double>1.000000) / v17
        v19 = libc.math.log(v18)
        v20 = (<double>0.000000)
        v21 = US1_1(v16)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = US1_1(v16)
        v24 = UH0_0(v23, v7)
        del v23
        v25 = method7(v1, v2, v3, v16, v19, v20, v22, v5, v6, v24, v8, v9)
        del v22; del v24
        v26 = v10 + (<unsigned long long>1)
        v27 = v11 + v25
        return method6(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v26, v27)
    else:
        v29 = v11 * v14
        return v29
cdef double method40(Mut1 v0, Mut0 v1, US0 v2, US0 v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef double v12
    cdef double v13
    cdef double v14
    if v3 == 0: # paper
        if v2 == 0: # paper
            v12 = (<double>0.000000)
        elif v2 == 1: # rock
            v12 = (<double>-1.000000)
        elif v2 == 2: # scissors
            v12 = (<double>1.000000)
        return v12
    elif v3 == 1: # rock
        if v2 == 0: # paper
            v13 = (<double>1.000000)
        elif v2 == 1: # rock
            v13 = (<double>0.000000)
        elif v2 == 2: # scissors
            v13 = (<double>-1.000000)
        return v13
    elif v3 == 2: # scissors
        if v2 == 0: # paper
            v14 = (<double>-1.000000)
        elif v2 == 1: # rock
            v14 = (<double>1.000000)
        elif v2 == 2: # scissors
            v14 = (<double>0.000000)
        return v14
cdef double method39(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, double v8, Mut1 v9, Mut0 v10, US0 v11, double v12, numpy.ndarray[double,ndim=1] v13, numpy.ndarray[signed long,ndim=1] v14, numpy.ndarray[double,ndim=1] v15, unsigned long long v16, double v17):
    cdef bint v18
    cdef unsigned long long v19
    cdef double v20
    cdef US0 v21
    cdef bint v22
    cdef bint v24
    cdef double v30
    cdef double v25
    cdef double v26
    cdef US1 v27
    cdef UH0 v28
    cdef double v31
    cdef double v32
    v18 = v16 < v0
    if v18:
        v19 = v16 + (<unsigned long long>1)
        v20 = v13[v16]
        v21 = v14[v16]
        v22 = v20 == (<double>0.000000)
        if v22:
            v24 = v12 == (<double>0.000000)
        else:
            v24 = 0
        if v24:
            v30 = (<double>0.000000)
        else:
            v25 = libc.math.log(v20)
            v26 = v25 + v2
            v27 = US1_0(v21)
            v28 = UH0_0(v27, v1)
            del v27
            v30 = method40(v9, v10, v11, v21, v7, v8, v4, v5, v6, v28, v26, v3)
            del v28
        v31 = v30 * v20
        v32 = v17 + v31
        v15[v16] = v30
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v19, v32)
    else:
        return v17
cdef void method42(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned char v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    cdef double v10
    cdef double v11
    cdef bint v12
    cdef double v14
    cdef double v15
    cdef double v16
    v7 = v6 < v0
    if v7:
        v8 = v6 + (<unsigned long long>1)
        v9 = v5[v6]
        v10 = v3[v6]
        v11 = v10 - v2
        v12 = v4 == (<unsigned char>0)
        if v12:
            v14 = v11
        else:
            v14 = -v11
        v15 = v1 * v14
        v16 = v9 + v15
        v5[v6] = v16
        method42(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method43(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, double v3, numpy.ndarray[double,ndim=1] v4, unsigned long long v5):
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
        method43(v0, v1, v2, v3, v4, v7)
    else:
        pass
cdef double method41(UH0 v0, double v1, double v2, Mut3 v3, double v4, double v5, numpy.ndarray[double,ndim=1] v6, unsigned char v7):
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
    v8 = v3.v3
    v9 = <double>v8
    v10 = v3.v2
    v11 = len(v10)
    v12 = (<unsigned long long>0)
    method42(v11, v4, v5, v6, v7, v10, v12)
    del v10
    v13 = v3.v2
    v14 = method29(v13)
    del v13
    v15 = v1 - v2
    v16 = libc.math.exp(v15)
    v17 = v3.v1
    v18 = len(v17)
    v19 = (<unsigned long long>0)
    method43(v18, v9, v14, v16, v17, v19)
    del v14; del v17
    v20 = v3.v3
    v21 = v20 + (<unsigned long long>1)
    v3.v3 = v21
    return v5
cdef double method38(Mut1 v0, Mut0 v1, numpy.ndarray[signed long,ndim=1] v2, US0 v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef Mut3 v12
    cdef double v13
    cdef double v14
    cdef double v15
    cdef double v16
    cdef numpy.ndarray[double,ndim=1] v17
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
    cdef Mut3 v30
    cdef double v31
    cdef double v32
    cdef double v33
    cdef double v34
    cdef numpy.ndarray[double,ndim=1] v35
    cdef numpy.ndarray[double,ndim=1] v36
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
    cdef Mut3 v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef numpy.ndarray[double,ndim=1] v53
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
    if v3 == 0: # paper
        v12 = method22(v0, v2, v9)
        v13 = v5 + v8
        v14 = v4 + v7
        v15 = v14 - v13
        v16 = libc.math.exp(v15)
        v17 = v12.v2
        del v17
        v18 = v12.v2
        v19 = method29(v18)
        del v18
        v20 = len(v19)
        v21 = len(v2)
        v22 = v20 == v21
        v23 = v22 != 1
        if v23:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v24 = numpy.empty(v20,dtype=numpy.float64)
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        v27 = method39(v20, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v16, v19, v2, v24, v25, v26)
        del v19
        v28 = (<unsigned char>1)
        return method41(v9, v10, v11, v12, v16, v27, v24, v28)
    elif v3 == 1: # rock
        v30 = method22(v0, v2, v9)
        v31 = v5 + v8
        v32 = v4 + v7
        v33 = v32 - v31
        v34 = libc.math.exp(v33)
        v35 = v30.v2
        del v35
        v36 = v30.v2
        v37 = method29(v36)
        del v36
        v38 = len(v37)
        v39 = len(v2)
        v40 = v38 == v39
        v41 = v40 != 1
        if v41:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v42 = numpy.empty(v38,dtype=numpy.float64)
        v43 = (<unsigned long long>0)
        v44 = (<double>0.000000)
        v45 = method39(v38, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v34, v37, v2, v42, v43, v44)
        del v37
        v46 = (<unsigned char>1)
        return method41(v9, v10, v11, v30, v34, v45, v42, v46)
    elif v3 == 2: # scissors
        v48 = method22(v0, v2, v9)
        v49 = v5 + v8
        v50 = v4 + v7
        v51 = v50 - v49
        v52 = libc.math.exp(v51)
        v53 = v48.v2
        del v53
        v54 = v48.v2
        v55 = method29(v54)
        del v54
        v56 = len(v55)
        v57 = len(v2)
        v58 = v56 == v57
        v59 = v58 != 1
        if v59:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v60 = numpy.empty(v56,dtype=numpy.float64)
        v61 = (<unsigned long long>0)
        v62 = (<double>0.000000)
        v63 = method39(v56, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v52, v55, v2, v60, v61, v62)
        del v55
        v64 = (<unsigned char>1)
        return method41(v9, v10, v11, v48, v52, v63, v60, v64)
cdef double method37(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, double v8, Mut1 v9, Mut0 v10, numpy.ndarray[signed long,ndim=1] v11, double v12, numpy.ndarray[double,ndim=1] v13, unsigned long long v14, double v15):
    cdef bint v16
    cdef unsigned long long v17
    cdef double v18
    cdef US0 v19
    cdef bint v20
    cdef bint v22
    cdef double v28
    cdef double v23
    cdef double v24
    cdef US1 v25
    cdef UH0 v26
    cdef double v29
    cdef double v30
    v16 = v14 < v0
    if v16:
        v17 = v14 + (<unsigned long long>1)
        v18 = v13[v14]
        v19 = v11[v14]
        v20 = v18 == (<double>0.000000)
        if v20:
            v22 = v12 == (<double>0.000000)
        else:
            v22 = 0
        if v22:
            v28 = (<double>0.000000)
        else:
            v23 = libc.math.log(v18)
            v24 = v23 + v5
            v25 = US1_0(v19)
            v26 = UH0_0(v25, v4)
            del v25
            v28 = method38(v9, v10, v11, v19, v7, v8, v26, v24, v6, v1, v2, v3)
            del v26
        v29 = v28 * v18
        v30 = v15 + v29
        return method37(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v17, v30)
    else:
        return v15
cdef double method36(Mut1 v0, Mut0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned char v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef object v13
    cdef Tuple0 tmp5
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
    tmp5 = method8(v1, v2, v6)
    v12, v13 = tmp5.v0, tmp5.v1
    del tmp5
    del v12
    v14 = v5 + v11
    v15 = v4 + v10
    v16 = v15 - v14
    v17 = libc.math.exp(v16)
    v18 = v13[:,0]
    del v13
    v19 = method16(v18)
    del v18
    v20 = len(v19)
    v21 = len(v2)
    v22 = v20 == v21
    v23 = v22 == 0
    if v23:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v24 = (<unsigned long long>0)
    v25 = (<double>0.000000)
    return method37(v20, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v2, v17, v19, v24, v25)
cdef double method35(numpy.ndarray[unsigned char,ndim=1] v0, Mut1 v1, Mut0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, double v5, double v6, UH0 v7, double v8, double v9, unsigned long long v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef unsigned char v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef US1 v21
    cdef UH0 v22
    cdef US1 v23
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
        v17 = <double>v12
        v18 = (<double>1.000000) / v17
        v19 = libc.math.log(v18)
        v20 = (<double>0.000000)
        v21 = US1_1(v16)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = US1_1(v16)
        v24 = UH0_0(v23, v7)
        del v23
        v25 = method36(v1, v2, v3, v16, v19, v20, v22, v5, v6, v24, v8, v9)
        del v22; del v24
        v26 = v10 + (<unsigned long long>1)
        v27 = v11 + v25
        return method35(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v26, v27)
    else:
        v29 = v11 * v14
        return v29
cdef bint method44(Mut2 v0):
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>500)
cdef double method50(Mut1 v0, Mut0 v1, US0 v2, US0 v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef double v12
    cdef double v13
    cdef double v14
    if v3 == 0: # paper
        if v2 == 0: # paper
            v12 = (<double>0.000000)
        elif v2 == 1: # rock
            v12 = (<double>-1.000000)
        elif v2 == 2: # scissors
            v12 = (<double>1.000000)
        return v12
    elif v3 == 1: # rock
        if v2 == 0: # paper
            v13 = (<double>1.000000)
        elif v2 == 1: # rock
            v13 = (<double>0.000000)
        elif v2 == 2: # scissors
            v13 = (<double>-1.000000)
        return v13
    elif v3 == 2: # scissors
        if v2 == 0: # paper
            v14 = (<double>-1.000000)
        elif v2 == 1: # rock
            v14 = (<double>1.000000)
        elif v2 == 2: # scissors
            v14 = (<double>0.000000)
        return v14
cdef double method49(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, double v8, Mut1 v9, Mut0 v10, US0 v11, double v12, numpy.ndarray[double,ndim=1] v13, numpy.ndarray[signed long,ndim=1] v14, unsigned long long v15, double v16):
    cdef bint v17
    cdef unsigned long long v18
    cdef double v19
    cdef US0 v20
    cdef bint v21
    cdef bint v23
    cdef double v29
    cdef double v24
    cdef double v25
    cdef US1 v26
    cdef UH0 v27
    cdef double v30
    cdef double v31
    v17 = v15 < v0
    if v17:
        v18 = v15 + (<unsigned long long>1)
        v19 = v13[v15]
        v20 = v14[v15]
        v21 = v19 == (<double>0.000000)
        if v21:
            v23 = v12 == (<double>0.000000)
        else:
            v23 = 0
        if v23:
            v29 = (<double>0.000000)
        else:
            v24 = libc.math.log(v19)
            v25 = v24 + v2
            v26 = US1_0(v20)
            v27 = UH0_0(v26, v1)
            del v26
            v29 = method50(v9, v10, v11, v20, v7, v8, v4, v5, v6, v27, v25, v3)
            del v27
        v30 = v29 * v19
        v31 = v16 + v30
        return method49(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v18, v31)
    else:
        return v16
cdef double method48(Mut1 v0, Mut0 v1, numpy.ndarray[signed long,ndim=1] v2, US0 v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef Mut3 v12
    cdef double v13
    cdef double v14
    cdef double v15
    cdef double v16
    cdef numpy.ndarray[double,ndim=1] v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned long long v23
    cdef double v24
    cdef Mut3 v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef numpy.ndarray[double,ndim=1] v31
    cdef numpy.ndarray[double,ndim=1] v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef bint v35
    cdef bint v36
    cdef unsigned long long v37
    cdef double v38
    cdef Mut3 v40
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
    if v3 == 0: # paper
        v12 = method22(v0, v2, v9)
        v13 = v5 + v8
        v14 = v4 + v7
        v15 = v14 - v13
        v16 = libc.math.exp(v15)
        v17 = v12.v2
        del v12
        v18 = method29(v17)
        del v17
        v19 = len(v18)
        v20 = len(v2)
        v21 = v19 == v20
        v22 = v21 == 0
        if v22:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v23 = (<unsigned long long>0)
        v24 = (<double>0.000000)
        return method49(v19, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v16, v18, v2, v23, v24)
    elif v3 == 1: # rock
        v26 = method22(v0, v2, v9)
        v27 = v5 + v8
        v28 = v4 + v7
        v29 = v28 - v27
        v30 = libc.math.exp(v29)
        v31 = v26.v2
        del v26
        v32 = method29(v31)
        del v31
        v33 = len(v32)
        v34 = len(v2)
        v35 = v33 == v34
        v36 = v35 == 0
        if v36:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v37 = (<unsigned long long>0)
        v38 = (<double>0.000000)
        return method49(v33, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v30, v32, v2, v37, v38)
    elif v3 == 2: # scissors
        v40 = method22(v0, v2, v9)
        v41 = v5 + v8
        v42 = v4 + v7
        v43 = v42 - v41
        v44 = libc.math.exp(v43)
        v45 = v40.v2
        del v40
        v46 = method29(v45)
        del v45
        v47 = len(v46)
        v48 = len(v2)
        v49 = v47 == v48
        v50 = v49 == 0
        if v50:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v51 = (<unsigned long long>0)
        v52 = (<double>0.000000)
        return method49(v47, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v3, v44, v46, v2, v51, v52)
cdef double method47(unsigned long long v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, double v8, Mut1 v9, Mut0 v10, numpy.ndarray[signed long,ndim=1] v11, double v12, numpy.ndarray[double,ndim=1] v13, unsigned long long v14, double v15):
    cdef bint v16
    cdef unsigned long long v17
    cdef double v18
    cdef US0 v19
    cdef bint v20
    cdef bint v22
    cdef double v28
    cdef double v23
    cdef double v24
    cdef US1 v25
    cdef UH0 v26
    cdef double v29
    cdef double v30
    v16 = v14 < v0
    if v16:
        v17 = v14 + (<unsigned long long>1)
        v18 = v13[v14]
        v19 = v11[v14]
        v20 = v18 == (<double>0.000000)
        if v20:
            v22 = v12 == (<double>0.000000)
        else:
            v22 = 0
        if v22:
            v28 = (<double>0.000000)
        else:
            v23 = libc.math.log(v18)
            v24 = v23 + v5
            v25 = US1_0(v19)
            v26 = UH0_0(v25, v4)
            del v25
            v28 = method48(v9, v10, v11, v19, v7, v8, v26, v24, v6, v1, v2, v3)
            del v26
        v29 = v28 * v18
        v30 = v15 + v29
        return method47(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v17, v30)
    else:
        return v15
cdef double method46(Mut1 v0, Mut0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned char v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef object v13
    cdef Tuple0 tmp6
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
    tmp6 = method8(v1, v2, v6)
    v12, v13 = tmp6.v0, tmp6.v1
    del tmp6
    del v12
    v14 = v5 + v11
    v15 = v4 + v10
    v16 = v15 - v14
    v17 = libc.math.exp(v16)
    v18 = v13[:,0]
    del v13
    v19 = method16(v18)
    del v18
    v20 = len(v19)
    v21 = len(v2)
    v22 = v20 == v21
    v23 = v22 == 0
    if v23:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v24 = (<unsigned long long>0)
    v25 = (<double>0.000000)
    return method47(v20, v9, v10, v11, v6, v7, v8, v4, v5, v0, v1, v2, v17, v19, v24, v25)
cdef double method45(numpy.ndarray[unsigned char,ndim=1] v0, Mut1 v1, Mut0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, double v5, double v6, UH0 v7, double v8, double v9, unsigned long long v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef unsigned char v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef US1 v21
    cdef UH0 v22
    cdef US1 v23
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
        v17 = <double>v12
        v18 = (<double>1.000000) / v17
        v19 = libc.math.log(v18)
        v20 = (<double>0.000000)
        v21 = US1_1(v16)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = US1_1(v16)
        v24 = UH0_0(v23, v7)
        del v23
        v25 = method46(v1, v2, v3, v16, v19, v20, v22, v5, v6, v24, v8, v9)
        del v22; del v24
        v26 = v10 + (<unsigned long long>1)
        v27 = v11 + v25
        return method45(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v26, v27)
    else:
        v29 = v11 * v14
        return v29
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef Mut1 v5
    cdef Mut2 v6
    cdef signed long v8
    cdef Mut2 v9
    cdef signed long v11
    cdef US0 v12
    cdef US0 v13
    cdef US0 v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef numpy.ndarray[unsigned char,ndim=1] v16
    cdef UH0 v17
    cdef double v18
    cdef double v19
    cdef UH0 v20
    cdef double v21
    cdef double v22
    cdef unsigned long long v23
    cdef double v24
    cdef double v25
    cdef US0 v26
    cdef US0 v27
    cdef US0 v28
    cdef numpy.ndarray[signed long,ndim=1] v29
    cdef numpy.ndarray[unsigned char,ndim=1] v30
    cdef UH0 v31
    cdef double v32
    cdef double v33
    cdef UH0 v34
    cdef double v35
    cdef double v36
    cdef unsigned long long v37
    cdef double v38
    cdef double v39
    cdef signed long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef Mut1 v43
    cdef Mut2 v44
    cdef signed long v46
    cdef US0 v47
    cdef US0 v48
    cdef US0 v49
    cdef numpy.ndarray[signed long,ndim=1] v50
    cdef numpy.ndarray[unsigned char,ndim=1] v51
    cdef UH0 v52
    cdef double v53
    cdef double v54
    cdef UH0 v55
    cdef double v56
    cdef double v57
    cdef unsigned long long v58
    cdef double v59
    cdef double v60
    cdef signed long v61
    cdef US0 v62
    cdef US0 v63
    cdef US0 v64
    cdef numpy.ndarray[signed long,ndim=1] v65
    cdef numpy.ndarray[unsigned char,ndim=1] v66
    cdef UH0 v67
    cdef double v68
    cdef double v69
    cdef UH0 v70
    cdef double v71
    cdef double v72
    cdef unsigned long long v73
    cdef double v74
    cdef double v75
    cdef signed long v76
    v0 = (<unsigned long long>3)
    v1 = (<unsigned long long>7)
    v2 = method0(v0, v1)
    v3 = (<unsigned long long>3)
    v4 = (<unsigned long long>7)
    v5 = method2(v3, v4)
    v6 = Mut2((<signed long>0))
    while method4(v6):
        v8 = v6.v0
        v9 = Mut2((<signed long>0))
        while method5(v9):
            v11 = v9.v0
            v12 = 1
            v13 = 0
            v14 = 2
            v15 = numpy.empty(3,dtype=numpy.int32)
            v15[0] = v12; v15[1] = v13; v15[2] = v14
            v16 = numpy.empty(1,dtype=numpy.uint8)
            v16[0] = (<unsigned char>0)
            v17 = UH0_1()
            v18 = (<double>0.000000)
            v19 = (<double>0.000000)
            v20 = UH0_1()
            v21 = (<double>0.000000)
            v22 = (<double>0.000000)
            v23 = (<unsigned long long>0)
            v24 = (<double>0.000000)
            v25 = method6(v16, v5, v2, v15, v17, v18, v19, v20, v21, v22, v23, v24)
            del v15; del v16; del v17; del v20
            v26 = 1
            v27 = 0
            v28 = 2
            v29 = numpy.empty(3,dtype=numpy.int32)
            v29[0] = v26; v29[1] = v27; v29[2] = v28
            v30 = numpy.empty(1,dtype=numpy.uint8)
            v30[0] = (<unsigned char>0)
            v31 = UH0_1()
            v32 = (<double>0.000000)
            v33 = (<double>0.000000)
            v34 = UH0_1()
            v35 = (<double>0.000000)
            v36 = (<double>0.000000)
            v37 = (<unsigned long long>0)
            v38 = (<double>0.000000)
            v39 = method35(v30, v5, v2, v29, v31, v32, v33, v34, v35, v36, v37, v38)
            del v29; del v30; del v31; del v34
            v40 = v11 + (<signed long>1)
            v9.v0 = v40
        del v9
        v41 = (<unsigned long long>3)
        v42 = (<unsigned long long>7)
        v43 = method2(v41, v42)
        v44 = Mut2((<signed long>0))
        while method44(v44):
            v46 = v44.v0
            v47 = 1
            v48 = 0
            v49 = 2
            v50 = numpy.empty(3,dtype=numpy.int32)
            v50[0] = v47; v50[1] = v48; v50[2] = v49
            v51 = numpy.empty(1,dtype=numpy.uint8)
            v51[0] = (<unsigned char>0)
            v52 = UH0_1()
            v53 = (<double>0.000000)
            v54 = (<double>0.000000)
            v55 = UH0_1()
            v56 = (<double>0.000000)
            v57 = (<double>0.000000)
            v58 = (<unsigned long long>0)
            v59 = (<double>0.000000)
            v60 = method35(v51, v43, v2, v50, v52, v53, v54, v55, v56, v57, v58, v59)
            del v50; del v51; del v52; del v55
            v61 = v46 + (<signed long>1)
            v44.v0 = v61
        del v44
        v62 = 1
        v63 = 0
        v64 = 2
        v65 = numpy.empty(3,dtype=numpy.int32)
        v65[0] = v62; v65[1] = v63; v65[2] = v64
        v66 = numpy.empty(1,dtype=numpy.uint8)
        v66[0] = (<unsigned char>0)
        v67 = UH0_1()
        v68 = (<double>0.000000)
        v69 = (<double>0.000000)
        v70 = UH0_1()
        v71 = (<double>0.000000)
        v72 = (<double>0.000000)
        v73 = (<unsigned long long>0)
        v74 = (<double>0.000000)
        v75 = method45(v66, v43, v2, v65, v67, v68, v69, v70, v71, v72, v73, v74)
        del v43; del v65; del v66; del v67; del v70
        print('summary -',v8,v75)
        v76 = v8 + (<signed long>1)
        v6.v0 = v76
    del v2; del v5
