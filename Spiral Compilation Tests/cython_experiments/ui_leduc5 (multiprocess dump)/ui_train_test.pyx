import numpy
cimport numpy
cimport libc.math
import multiprocessing
import ui_train
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
ctypedef signed long US0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
ctypedef signed long US3
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # action_
    cdef readonly US3 v0
    def __init__(self, US3 v0): self.tag = 0; self.v0 = v0
cdef class US2_1(US2): # observation_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
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
    cdef readonly double v1
    cdef readonly US0 v2
    cdef readonly unsigned char v3
    cdef readonly signed long v4
    cdef readonly US0 v5
    cdef readonly unsigned char v6
    cdef readonly signed long v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly object v10
    cdef readonly UH0 v11
    cdef readonly double v12
    cdef readonly double v13
    def __init__(self, v0, double v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, v10, UH0 v11, double v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
cdef class Tuple1:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly object v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple3:
    cdef readonly double v0
    cdef readonly US3 v1
    def __init__(self, double v0, US3 v1): self.v0 = v0; self.v1 = v1
cdef class Closure0():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef US0 v3 = args.v2
        cdef unsigned char v4 = args.v3
        cdef signed long v5 = args.v4
        cdef US0 v6 = args.v5
        cdef unsigned char v7 = args.v6
        cdef signed long v8 = args.v7
        cdef US1 v9 = args.v8
        cdef unsigned char v10 = args.v9
        cdef object v11 = args.v10
        cdef UH0 v12 = args.v11
        cdef double v13 = args.v12
        cdef double v14 = args.v13
        cdef numpy.ndarray[signed long,ndim=1] v15
        cdef numpy.ndarray[double,ndim=1] v16
        cdef numpy.ndarray[double,ndim=1] v17
        cdef Tuple1 tmp2
        cdef double v18
        cdef double v19
        cdef numpy.ndarray[double,ndim=1] v20
        tmp2 = method2(v0, v1, v12)
        v15, v16, v17 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        del v15; del v17
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method11(v16)
        del v16
        return method15(v1, v11, v19, v20)
cdef class Closure1():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef US0 v3 = args.v2
        cdef unsigned char v4 = args.v3
        cdef signed long v5 = args.v4
        cdef US0 v6 = args.v5
        cdef unsigned char v7 = args.v6
        cdef signed long v8 = args.v7
        cdef US1 v9 = args.v8
        cdef unsigned char v10 = args.v9
        cdef object v11 = args.v10
        cdef UH0 v12 = args.v11
        cdef double v13 = args.v12
        cdef double v14 = args.v13
        cdef numpy.ndarray[signed long,ndim=1] v15
        cdef numpy.ndarray[double,ndim=1] v16
        cdef numpy.ndarray[double,ndim=1] v17
        cdef Tuple1 tmp3
        cdef double v18
        cdef double v19
        cdef numpy.ndarray[double,ndim=1] v20
        tmp3 = method2(v0, v1, v12)
        v15, v16, v17 = tmp3.v0, tmp3.v1, tmp3.v2
        del tmp3
        del v15; del v16
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method11(v17)
        del v17
        return method15(v1, v11, v19, v20)
cdef class Closure2():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef US0 v3 = args.v2
        cdef unsigned char v4 = args.v3
        cdef signed long v5 = args.v4
        cdef US0 v6 = args.v5
        cdef unsigned char v7 = args.v6
        cdef signed long v8 = args.v7
        cdef US1 v9 = args.v8
        cdef unsigned char v10 = args.v9
        cdef object v11 = args.v10
        cdef UH0 v12 = args.v11
        cdef double v13 = args.v12
        cdef double v14 = args.v13
        cdef numpy.ndarray[signed long,ndim=1] v15
        cdef numpy.ndarray[double,ndim=1] v16
        cdef numpy.ndarray[double,ndim=1] v17
        cdef Tuple1 tmp4
        cdef double v18
        cdef double v19
        cdef numpy.ndarray[double,ndim=1] v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef bint v23
        cdef bint v24
        cdef numpy.ndarray[double,ndim=1] v25
        cdef unsigned long long v26
        cdef double v27
        cdef double v28
        cdef unsigned long long v29
        cdef unsigned long long v30
        cdef numpy.ndarray[double,ndim=1] v31
        cdef double v32
        cdef unsigned long long v33
        cdef unsigned long long v34
        tmp4 = method2(v0, v1, v12)
        v15, v16, v17 = tmp4.v0, tmp4.v1, tmp4.v2
        del tmp4
        del v15
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method11(v17)
        v21 = len(v20)
        v22 = len(v1)
        v23 = v21 == v22
        v24 = v23 != 1
        if v24:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v25 = numpy.empty(v21,dtype=numpy.float64)
        v26 = (<unsigned long long>0)
        v27 = (<double>0.000000)
        v28 = method17(v21, v10, v11, v19, v20, v1, v25, v26, v27)
        del v20
        v29 = len(v17)
        v30 = (<unsigned long long>0)
        method18(v29, v19, v28, v25, v17, v30)
        del v25
        v31 = method11(v17)
        del v17
        v32 = libc.math.exp(v13)
        v33 = len(v16)
        v34 = (<unsigned long long>0)
        method19(v33, v31, v32, v16, v34)
        del v16
        return method15(v1, v11, v19, v31)
cdef class US4:
    cdef readonly signed long tag
cdef class US4_0(US4): # stop
    def __init__(self): self.tag = 0
cdef class US4_1(US4): # train_
    cdef readonly unsigned long long v0
    def __init__(self, unsigned long long v0): self.tag = 1; self.v0 = v0
cdef class Closure3():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, unsigned long long v1):
        cdef object v0 = self.v0
        cdef US4 v2
        v2 = US4_1(v1)
        v0.put(v2)
cdef class Closure4():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self):
        cdef object v0 = self.v0
        cdef US4 v1
        v1 = US4_0()
        v0.put(v1)
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
cdef unsigned long long method3(UH0 v0):
    cdef US2 v1
    cdef UH0 v2
    cdef unsigned long long v35
    cdef US3 v3
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
    cdef US0 v19
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
        v37 = method3(v2)
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
cdef bint method5(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef US2 v4
    cdef UH0 v5
    cdef bint v12
    cdef US3 v6
    cdef US3 v7
    cdef US0 v9
    cdef US0 v10
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
            return method5(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method6(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method6(v0, v1, v4)
    else:
        pass
cdef void method8(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method8(v0, v1, v4)
    else:
        pass
cdef void method10(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef Tuple2 tmp1
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp1 = v3[v4]
        v7, v8, v9, v10, v11 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4
        del tmp1
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple2(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method10(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method9(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method10(v8, v2, v3, v7, v9)
        del v7
        method9(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method7(Mut0 v0):
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
    method8(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method9(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Tuple1 method4(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef Tuple2 tmp0
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
            v15 = method5(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple1(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method4(v0, v1, v2, v3, v4, v16)
    else:
        v23 = len(v2)
        v24 = numpy.empty(v23,dtype=numpy.float64)
        v25 = (<unsigned long long>0)
        method6(v23, v24, v25)
        v26 = numpy.empty(v23,dtype=numpy.float64)
        v27 = (<unsigned long long>0)
        method6(v23, v26, v27)
        v4.append(Tuple2(v3, v1, v2, v26, v24))
        v28 = v0.v2
        v29 = v28 + (<unsigned long long>1)
        v0.v2 = v29
        v30 = v0.v2
        v31 = v0.v0
        v32 = v0.v1
        v33 = len(v32)
        del v32
        v34 = v31 * v33
        v35 = v30 >= v34
        if v35:
            method7(v0)
        else:
            pass
        return Tuple1(v2, v26, v24)
cdef Tuple1 method2(Mut0 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method3(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method4(v0, v2, v1, v4, v8, v9)
cdef double method12(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
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
        return method12(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method13(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method13(v0, v1, v2, v5)
    else:
        pass
cdef void method14(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
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
        method14(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method11(numpy.ndarray[double,ndim=1] v0):
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
    v5 = method12(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method13(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method14(v11, v5, v2, v12)
    return v2
cdef double method16(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[signed long,ndim=1] v4, unsigned long long v5, double v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    cdef US3 v10
    cdef bint v11
    cdef bint v13
    cdef double v16
    cdef double v14
    cdef double v17
    cdef double v18
    v7 = v5 < v0
    if v7:
        v8 = v5 + (<unsigned long long>1)
        v9 = v3[v5]
        v10 = v4[v5]
        v11 = v9 == (<double>0.000000)
        if v11:
            v13 = v2 == (<double>0.000000)
        else:
            v13 = 0
        if v13:
            v16 = (<double>0.000000)
        else:
            v14 = libc.math.log(v9)
            v16 = v1(Tuple3(v14, v10))
        v17 = v16 * v9
        v18 = v6 + v17
        return method16(v0, v1, v2, v3, v4, v8, v18)
    else:
        return v6
cdef double method15(numpy.ndarray[signed long,ndim=1] v0, v1, double v2, numpy.ndarray[double,ndim=1] v3):
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    v4 = len(v3)
    v5 = len(v0)
    v6 = v4 == v5
    v7 = v6 == 0
    if v7:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v8 = (<unsigned long long>0)
    v9 = (<double>0.000000)
    return method16(v4, v1, v2, v3, v0, v8, v9)
cdef double method17(unsigned long long v0, unsigned char v1, v2, double v3, numpy.ndarray[double,ndim=1] v4, numpy.ndarray[signed long,ndim=1] v5, numpy.ndarray[double,ndim=1] v6, unsigned long long v7, double v8):
    cdef bint v9
    cdef unsigned long long v10
    cdef double v11
    cdef US3 v12
    cdef bint v13
    cdef bint v15
    cdef double v18
    cdef double v16
    cdef bint v19
    cdef double v21
    cdef double v22
    cdef double v23
    v9 = v7 < v0
    if v9:
        v10 = v7 + (<unsigned long long>1)
        v11 = v4[v7]
        v12 = v5[v7]
        v13 = v11 == (<double>0.000000)
        if v13:
            v15 = v3 == (<double>0.000000)
        else:
            v15 = 0
        if v15:
            v18 = (<double>0.000000)
        else:
            v16 = libc.math.log(v11)
            v18 = v2(Tuple3(v16, v12))
        v19 = v1 == (<unsigned char>0)
        if v19:
            v21 = v18
        else:
            v21 = -v18
        v22 = v11 * v21
        v23 = v8 + v22
        v6[v7] = v21
        return method17(v0, v1, v2, v3, v4, v5, v6, v10, v23)
    else:
        return v8
cdef void method18(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[double,ndim=1] v4, unsigned long long v5):
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
        v9 = v3[v5]
        v10 = v9 - v2
        v11 = v1 * v10
        v12 = v8 + v11
        v4[v5] = v12
        method18(v0, v1, v2, v3, v4, v7)
    else:
        pass
cdef void method19(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = v1[v4]
        v9 = v2 * v8
        v10 = v7 + v9
        v3[v4] = v10
        method19(v0, v1, v2, v3, v6)
    else:
        pass
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    v0 = (<unsigned long long>3)
    v1 = (<unsigned long long>7)
    v2 = method0(v0, v1)
    v3 = Closure0(v2)
    del v3
    v4 = Closure1(v2)
    del v4
    v5 = Closure2(v2)
    del v2; del v5
    pass # import multiprocessing
    pass # import ui_train
    v6 = multiprocessing.Queue()
    v7 = Closure3(v6)
    v8 = Closure4(v6)
    del v6
    ui_train.run(v7,v8)
