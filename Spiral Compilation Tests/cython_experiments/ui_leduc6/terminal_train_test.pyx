import numpy
cimport numpy
cimport libc.math
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
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef bint v23
        cdef bint v24
        cdef unsigned long long v25
        cdef double v26
        tmp2 = method3(v0, v1, v12)
        v15, v16, v17 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        del v15; del v16
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method12(v17)
        del v17
        v21 = len(v20)
        v22 = len(v1)
        v23 = v21 == v22
        v24 = v23 == 0
        if v24:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        return method16(v21, v11, v19, v20, v1, v25, v26)
cdef class Tuple4:
    cdef readonly double v0
    cdef readonly US0 v1
    cdef readonly unsigned char v2
    cdef readonly signed long v3
    cdef readonly US0 v4
    cdef readonly unsigned char v5
    cdef readonly signed long v6
    cdef readonly US1 v7
    cdef readonly unsigned char v8
    cdef readonly UH0 v9
    cdef readonly double v10
    cdef readonly double v11
    def __init__(self, double v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, UH0 v9, double v10, double v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
cdef class Closure1():
    def __init__(self): pass
    def __call__(self, Tuple4 args):
        cdef double v0 = args.v0
        cdef US0 v1 = args.v1
        cdef unsigned char v2 = args.v2
        cdef signed long v3 = args.v3
        cdef US0 v4 = args.v4
        cdef unsigned char v5 = args.v5
        cdef signed long v6 = args.v6
        cdef US1 v7 = args.v7
        cdef unsigned char v8 = args.v8
        cdef UH0 v9 = args.v9
        cdef double v10 = args.v10
        cdef double v11 = args.v11
        pass
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
        cdef Tuple1 tmp3
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
        tmp3 = method3(v0, v1, v12)
        v15, v16, v17 = tmp3.v0, tmp3.v1, tmp3.v2
        del tmp3
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method12(v17)
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
        v28 = method17(v21, v11, v19, v20, v1, v25, v26, v27)
        del v20
        return method18(v12, v13, v15, v16, v17, v19, v28, v25, v10)
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure7():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef signed long v9
    cdef US0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, signed long v9, US0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef double v19
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v19 = v17 + v1
        v20 = US2_0(v18)
        v21 = UH0_0(v20, v2)
        del v20
        v22 = US2_0(v18)
        v23 = UH0_0(v22, v0)
        del v22
        return method35(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v3, v23, v19)
cdef class Closure6():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef signed long v9
    cdef US0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, signed long v9, US0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef double v19
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v19 = v17 + v3
        v20 = US2_0(v18)
        v21 = UH0_0(v20, v2)
        del v20
        v22 = US2_0(v18)
        v23 = UH0_0(v22, v0)
        del v22
        return method35(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v19, v23, v1)
cdef class Closure5():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    cdef US0 v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef US0 v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v3
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method33(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure8():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    cdef US0 v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef US0 v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v1
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method33(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
cdef class Closure10():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef double v19
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v19 = v17 + v1
        v20 = US2_0(v18)
        v21 = UH0_0(v20, v2)
        del v20
        v22 = US2_0(v18)
        v23 = UH0_0(v22, v0)
        del v22
        return method37(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v3, v23, v19)
cdef class Closure9():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef double v19
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v19 = v17 + v3
        v20 = US2_0(v18)
        v21 = UH0_0(v20, v2)
        del v20
        v22 = US2_0(v18)
        v23 = UH0_0(v22, v0)
        del v22
        return method37(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v19, v23, v1)
cdef class Closure4():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v3
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method30(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure11():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v1
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method30(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
cdef class Closure3():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef US0 v8
    cdef US0 v9
    cdef Heap0 v10
    cdef object v11
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, US0 v8, US0 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef US0 v8 = self.v8
        cdef US0 v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef numpy.ndarray[signed long,ndim=1] v11 = self.v11
        cdef double v12 = args.v0
        cdef US3 v13 = args.v1
        cdef double v14
        cdef US2 v15
        cdef UH0 v16
        cdef US2 v17
        cdef UH0 v18
        v14 = v12 + v3
        v15 = US2_0(v13)
        v16 = UH0_0(v15, v2)
        del v15
        v17 = US2_0(v13)
        v18 = UH0_0(v17, v0)
        del v17
        return method28(v5, v6, v7, v8, v9, v10, v11, v13, v4, v16, v14, v18, v1)
cdef class Closure16():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef signed long v8
    cdef US0 v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, signed long v8, US0 v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v1
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method48(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
cdef class Closure15():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef signed long v8
    cdef US0 v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, signed long v8, US0 v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v3
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method48(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure14():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, US0 v8, unsigned char v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef double v17
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v17 = v15 + v3
        v18 = US2_0(v16)
        v19 = UH0_0(v18, v2)
        del v18
        v20 = US2_0(v16)
        v21 = UH0_0(v20, v0)
        del v20
        return method47(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v17, v21, v1)
cdef class Closure17():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, US0 v8, unsigned char v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef double v17
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v17 = v15 + v1
        v18 = US2_0(v16)
        v19 = UH0_0(v18, v2)
        del v18
        v20 = US2_0(v16)
        v21 = UH0_0(v20, v0)
        del v20
        return method47(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v3, v21, v17)
cdef class Closure19():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef signed long v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef numpy.ndarray[signed long,ndim=1] v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v1
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method49(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
cdef class Closure18():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef signed long v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef numpy.ndarray[signed long,ndim=1] v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef double v18
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v18 = v16 + v3
        v19 = US2_0(v17)
        v20 = UH0_0(v19, v2)
        del v19
        v21 = US2_0(v17)
        v22 = UH0_0(v21, v0)
        del v21
        return method49(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure13():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef signed long v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef numpy.ndarray[signed long,ndim=1] v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef double v17
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v17 = v15 + v3
        v18 = US2_0(v16)
        v19 = UH0_0(v18, v2)
        del v18
        v20 = US2_0(v16)
        v21 = UH0_0(v20, v0)
        del v20
        return method44(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v17, v21, v1)
cdef class Closure20():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef signed long v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef numpy.ndarray[signed long,ndim=1] v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef double v17
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v17 = v15 + v1
        v18 = US2_0(v16)
        v19 = UH0_0(v18, v2)
        del v18
        v20 = US2_0(v16)
        v21 = UH0_0(v20, v0)
        del v20
        return method44(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v3, v21, v17)
cdef class Closure12():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef object v6
    cdef US0 v7
    cdef US0 v8
    cdef Heap0 v9
    cdef object v10
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, US0 v7, US0 v8, Heap0 v9, numpy.ndarray[signed long,ndim=1] v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple3 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef object v6 = self.v6
        cdef US0 v7 = self.v7
        cdef US0 v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef numpy.ndarray[signed long,ndim=1] v10 = self.v10
        cdef double v11 = args.v0
        cdef US3 v12 = args.v1
        cdef double v13
        cdef US2 v14
        cdef UH0 v15
        cdef US2 v16
        cdef UH0 v17
        v13 = v11 + v3
        v14 = US2_0(v12)
        v15 = UH0_0(v14, v2)
        del v14
        v16 = US2_0(v12)
        v17 = UH0_0(v16, v0)
        del v16
        return method43(v5, v6, v7, v8, v9, v10, v12, v4, v15, v13, v17, v1)
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
cdef unsigned long long method4(UH0 v0):
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
        v37 = method4(v2)
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
cdef bint method6(UH0 v0, UH0 v1):
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
            return method6(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method7(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method7(v0, v1, v4)
    else:
        pass
cdef void method9(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method9(v0, v1, v4)
    else:
        pass
cdef void method11(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
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
        method11(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method10(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method11(v8, v2, v3, v7, v9)
        del v7
        method10(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method8(Mut0 v0):
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
    method9(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method10(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Tuple1 method5(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
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
            v15 = method6(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple1(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method5(v0, v1, v2, v3, v4, v16)
    else:
        v23 = len(v2)
        v24 = numpy.empty(v23,dtype=numpy.float64)
        v25 = (<unsigned long long>0)
        method7(v23, v24, v25)
        v26 = numpy.empty(v23,dtype=numpy.float64)
        v27 = (<unsigned long long>0)
        method7(v23, v26, v27)
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
            method8(v0)
        else:
            pass
        return Tuple1(v2, v26, v24)
cdef Tuple1 method3(Mut0 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method4(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method5(v0, v2, v1, v4, v8, v9)
cdef double method13(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
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
        return method13(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method14(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method14(v0, v1, v2, v5)
    else:
        pass
cdef void method15(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
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
        method15(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method12(numpy.ndarray[double,ndim=1] v0):
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
    v5 = method13(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method14(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method15(v11, v5, v2, v12)
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
cdef double method17(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[signed long,ndim=1] v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6, double v7):
    cdef bint v8
    cdef unsigned long long v9
    cdef double v10
    cdef US3 v11
    cdef bint v12
    cdef bint v14
    cdef double v17
    cdef double v15
    cdef double v18
    cdef double v19
    v8 = v6 < v0
    if v8:
        v9 = v6 + (<unsigned long long>1)
        v10 = v3[v6]
        v11 = v4[v6]
        v12 = v10 == (<double>0.000000)
        if v12:
            v14 = v2 == (<double>0.000000)
        else:
            v14 = 0
        if v14:
            v17 = (<double>0.000000)
        else:
            v15 = libc.math.log(v10)
            v17 = v1(Tuple3(v15, v11))
        v18 = v17 * v10
        v19 = v7 + v18
        v5[v6] = v17
        return method17(v0, v1, v2, v3, v4, v5, v9, v19)
    else:
        return v7
cdef void method19(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned char v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6):
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
        v8 = v6 + (<unsigned long long>1)
        v9 = v5[v6]
        v10 = v3[v6]
        v11 = v4 == (<unsigned char>0)
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
        method19(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method20(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
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
        method20(v0, v1, v2, v3, v6)
    else:
        pass
cdef double method21(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
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
        return method21(v0, v1, v2, v6, v10)
    else:
        return v4
cdef double method18(UH0 v0, double v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[double,ndim=1] v4, double v5, double v6, numpy.ndarray[double,ndim=1] v7, unsigned char v8):
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
    v10 = (<unsigned long long>0)
    method19(v9, v5, v6, v7, v8, v4, v10)
    v11 = method12(v4)
    v12 = libc.math.exp(v1)
    v13 = len(v3)
    v14 = (<unsigned long long>0)
    method20(v13, v11, v12, v3, v14)
    v15 = len(v11)
    v16 = len(v7)
    v17 = v15 == v16
    v18 = v17 == 0
    if v18:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v19 = (<unsigned long long>0)
    v20 = (<double>0.000000)
    return method21(v15, v11, v7, v19, v20)
cdef void method24(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US0 v9
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
        method24(v0, v1, v2, v3, v6)
    else:
        pass
cdef numpy.ndarray[signed long,ndim=1] method29(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method34(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method36(US0 v0):
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef double method35(v0, v1, v2, Heap0 v3, signed long v4, US0 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US3 v12, double v13, UH0 v14, double v15, UH0 v16, double v17):
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
    cdef US0 v65
    cdef unsigned char v66
    cdef signed long v67
    cdef US0 v68
    cdef unsigned char v69
    cdef signed long v70
    cdef double v71
    cdef US1 v72
    cdef US1 v73
    cdef bint v74
    cdef signed long v76
    cdef bint v77
    cdef signed long v79
    cdef signed long v80
    cdef signed long v82
    cdef signed long v83
    cdef US0 v84
    cdef unsigned char v85
    cdef signed long v86
    cdef US0 v87
    cdef unsigned char v88
    cdef signed long v89
    cdef double v90
    cdef US1 v91
    cdef US1 v92
    cdef signed long v93
    cdef signed long v94
    cdef numpy.ndarray[signed long,ndim=1] v95
    cdef bint v96
    cdef US1 v97
    cdef object v98
    cdef US1 v100
    cdef object v101
    if v12 == 0: # call
        v18 = method36(v5)
        v19 = method36(v9)
        v20 = method36(v6)
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
            v52, v53 = v10, v8
        else:
            v49 = v47 == (<signed long>-1)
            if v49:
                v52, v53 = v7, v8
            else:
                v52, v53 = v10, (<signed long>0)
        v54 = v52 == (<unsigned char>0)
        if v54:
            v56 = v53
        else:
            v56 = -v53
        v57 = v10 == (<unsigned char>0)
        if v57:
            v59 = v56
        else:
            v59 = -v56
        v60 = v59 + v8
        v61 = v7 == (<unsigned char>0)
        if v61:
            v63 = v56
        else:
            v63 = -v56
        v64 = v63 + v8
        if v57:
            v65, v66, v67, v68, v69, v70 = v9, v10, v60, v6, v7, v64
        else:
            v65, v66, v67, v68, v69, v70 = v6, v7, v64, v9, v10, v60
        v71 = <double>v56
        v72 = US1_1(v5)
        v1(Tuple4(v13, v65, v66, v67, v68, v69, v70, v72, (<unsigned char>0), v14, v15, v71))
        del v72
        v73 = US1_1(v5)
        v1(Tuple4(v13, v68, v69, v70, v65, v66, v67, v73, (<unsigned char>1), v16, v17, v71))
        del v73
        return v71
    elif v12 == 1: # fold
        v74 = v7 == (<unsigned char>0)
        if v74:
            v76 = v11
        else:
            v76 = -v11
        v77 = v10 == (<unsigned char>0)
        if v77:
            v79 = v76
        else:
            v79 = -v76
        v80 = v79 + v11
        if v74:
            v82 = v76
        else:
            v82 = -v76
        v83 = v82 + v8
        if v77:
            v84, v85, v86, v87, v88, v89 = v9, v10, v80, v6, v7, v83
        else:
            v84, v85, v86, v87, v88, v89 = v6, v7, v83, v9, v10, v80
        v90 = <double>v76
        v91 = US1_1(v5)
        v1(Tuple4(v13, v84, v85, v86, v87, v88, v89, v91, (<unsigned char>0), v14, v15, v90))
        del v91
        v92 = US1_1(v5)
        v1(Tuple4(v13, v87, v88, v89, v84, v85, v86, v92, (<unsigned char>1), v16, v17, v90))
        del v92
        return v90
    elif v12 == 2: # raise
        v93 = v4 - (<signed long>1)
        v94 = v8 + (<signed long>4)
        v95 = method34(v3, v9, v10, v94, v6, v7, v8, v93)
        v96 = v7 == (<unsigned char>0)
        if v96:
            v97 = US1_1(v5)
            v98 = Closure6(v16, v17, v14, v15, v13, v0, v1, v2, v3, v93, v5, v9, v10, v94, v6, v7, v8)
            return v2(Tuple0(v95, v13, v6, v7, v8, v9, v10, v94, v97, (<unsigned char>0), v98, v14, v15, v17))
        else:
            v100 = US1_1(v5)
            v101 = Closure7(v16, v17, v14, v15, v13, v0, v1, v2, v3, v93, v5, v9, v10, v94, v6, v7, v8)
            return v0(Tuple0(v95, v13, v6, v7, v8, v9, v10, v94, v100, (<unsigned char>1), v101, v16, v17, v15))
cdef double method33(v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef US1 v20
    cdef object v21
    cdef US1 v23
    cdef object v24
    cdef object v27
    cdef signed long v29
    cdef signed long v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef bint v32
    cdef US1 v33
    cdef object v34
    cdef US1 v36
    cdef object v37
    if v11 == 0: # call
        v17 = (<signed long>2)
        v18 = method34(v3, v7, v8, v9, v4, v5, v6, v17)
        v19 = v5 == (<unsigned char>0)
        if v19:
            v20 = US1_1(v10)
            v21 = Closure6(v15, v16, v13, v14, v12, v0, v1, v2, v3, v17, v10, v7, v8, v9, v4, v5, v6)
            return v2(Tuple0(v18, v12, v4, v5, v6, v7, v8, v9, v20, (<unsigned char>0), v21, v13, v14, v16))
        else:
            v23 = US1_1(v10)
            v24 = Closure7(v15, v16, v13, v14, v12, v0, v1, v2, v3, v17, v10, v7, v8, v9, v4, v5, v6)
            return v0(Tuple0(v18, v12, v4, v5, v6, v7, v8, v9, v23, (<unsigned char>1), v24, v15, v16, v14))
    elif v11 == 1: # fold
        raise Exception("impossible")
    elif v11 == 2: # raise
        v29 = (<signed long>1)
        v30 = v6 + (<signed long>4)
        v31 = method34(v3, v7, v8, v30, v4, v5, v6, v29)
        v32 = v5 == (<unsigned char>0)
        if v32:
            v33 = US1_1(v10)
            v34 = Closure6(v15, v16, v13, v14, v12, v0, v1, v2, v3, v29, v10, v7, v8, v30, v4, v5, v6)
            return v2(Tuple0(v31, v12, v4, v5, v6, v7, v8, v30, v33, (<unsigned char>0), v34, v13, v14, v16))
        else:
            v36 = US1_1(v10)
            v37 = Closure7(v15, v16, v13, v14, v12, v0, v1, v2, v3, v29, v10, v7, v8, v30, v4, v5, v6)
            return v0(Tuple0(v31, v12, v4, v5, v6, v7, v8, v30, v36, (<unsigned char>1), v37, v15, v16, v14))
cdef double method32(v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef US1 v18
    cdef object v19
    cdef US1 v21
    cdef object v22
    v16 = v3.v2
    v17 = v8 == (<unsigned char>0)
    if v17:
        v18 = US1_1(v10)
        v19 = Closure5(v14, v15, v12, v13, v11, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        return v2(Tuple0(v16, v11, v7, v8, v9, v4, v5, v6, v18, (<unsigned char>0), v19, v12, v13, v15))
    else:
        v21 = US1_1(v10)
        v22 = Closure8(v14, v15, v12, v13, v11, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        return v0(Tuple0(v16, v11, v7, v8, v9, v4, v5, v6, v21, (<unsigned char>1), v22, v14, v15, v13))
cdef double method31(numpy.ndarray[signed long,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, double v11, UH0 v12, double v13, UH0 v14, double v15, unsigned long long v16, double v17):
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef bint v21
    cdef US0 v22
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
        v26 = v25 + v11
        v27 = US2_1(v22)
        v28 = UH0_0(v27, v12)
        del v27
        v29 = US2_1(v22)
        v30 = UH0_0(v29, v14)
        del v29
        v31 = method32(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v22, v26, v28, v13, v30, v15)
        del v28; del v30
        v32 = v16 + (<unsigned long long>1)
        v33 = v17 + v31
        return method31(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v32, v33)
    else:
        v35 = v17 * v20
        return v35
cdef double method37(v0, v1, v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US3 v12, double v13, UH0 v14, double v15, UH0 v16, double v17):
    cdef bint v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US0 v22
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
    cdef US0 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US0 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef double v44
    cdef US1 v45
    cdef US1 v46
    cdef signed long v47
    cdef signed long v48
    cdef numpy.ndarray[signed long,ndim=1] v49
    cdef bint v50
    cdef US1 v51
    cdef object v52
    cdef US1 v54
    cdef object v55
    if v12 == 0: # call
        v18 = v10 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v9, v10, v8, v6, v7, v8
        else:
            v19, v20, v21, v22, v23, v24 = v6, v7, v8, v9, v10, v8
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        return method31(v4, v0, v1, v2, v3, v22, v23, v24, v19, v20, v21, v13, v14, v15, v16, v17, v25, v26)
    elif v12 == 1: # fold
        v28 = v7 == (<unsigned char>0)
        if v28:
            v30 = v11
        else:
            v30 = -v11
        v31 = v10 == (<unsigned char>0)
        if v31:
            v33 = v30
        else:
            v33 = -v30
        v34 = v33 + v11
        if v28:
            v36 = v30
        else:
            v36 = -v30
        v37 = v36 + v8
        if v31:
            v38, v39, v40, v41, v42, v43 = v9, v10, v34, v6, v7, v37
        else:
            v38, v39, v40, v41, v42, v43 = v6, v7, v37, v9, v10, v34
        v44 = <double>v30
        v45 = US1_0()
        v1(Tuple4(v13, v38, v39, v40, v41, v42, v43, v45, (<unsigned char>0), v14, v15, v44))
        del v45
        v46 = US1_0()
        v1(Tuple4(v13, v41, v42, v43, v38, v39, v40, v46, (<unsigned char>1), v16, v17, v44))
        del v46
        return v44
    elif v12 == 2: # raise
        v47 = v5 - (<signed long>1)
        v48 = v8 + (<signed long>2)
        v49 = method34(v3, v9, v10, v48, v6, v7, v8, v47)
        v50 = v7 == (<unsigned char>0)
        if v50:
            v51 = US1_0()
            v52 = Closure9(v16, v17, v14, v15, v13, v0, v1, v2, v3, v4, v47, v9, v10, v48, v6, v7, v8)
            return v2(Tuple0(v49, v13, v6, v7, v8, v9, v10, v48, v51, (<unsigned char>0), v52, v14, v15, v17))
        else:
            v54 = US1_0()
            v55 = Closure10(v16, v17, v14, v15, v13, v0, v1, v2, v3, v4, v47, v9, v10, v48, v6, v7, v8)
            return v0(Tuple0(v49, v13, v6, v7, v8, v9, v10, v48, v54, (<unsigned char>1), v55, v16, v17, v15))
cdef double method30(v0, v1, v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
    cdef bint v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
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
    cdef US0 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef US0 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef double v43
    cdef US1 v44
    cdef US1 v45
    cdef signed long v46
    cdef signed long v47
    cdef numpy.ndarray[signed long,ndim=1] v48
    cdef bint v49
    cdef US1 v50
    cdef object v51
    cdef US1 v53
    cdef object v54
    if v11 == 0: # call
        v17 = v10 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v9, v10, v8, v6, v7, v8
        else:
            v18, v19, v20, v21, v22, v23 = v6, v7, v8, v9, v10, v8
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method31(v4, v0, v1, v2, v3, v21, v22, v23, v18, v19, v20, v12, v13, v14, v15, v16, v24, v25)
    elif v11 == 1: # fold
        v27 = v7 == (<unsigned char>0)
        if v27:
            v29 = v8
        else:
            v29 = -v8
        v30 = v10 == (<unsigned char>0)
        if v30:
            v32 = v29
        else:
            v32 = -v29
        v33 = v32 + v8
        if v27:
            v35 = v29
        else:
            v35 = -v29
        v36 = v35 + v8
        if v30:
            v37, v38, v39, v40, v41, v42 = v9, v10, v33, v6, v7, v36
        else:
            v37, v38, v39, v40, v41, v42 = v6, v7, v36, v9, v10, v33
        v43 = <double>v29
        v44 = US1_0()
        v1(Tuple4(v12, v37, v38, v39, v40, v41, v42, v44, (<unsigned char>0), v13, v14, v43))
        del v44
        v45 = US1_0()
        v1(Tuple4(v12, v40, v41, v42, v37, v38, v39, v45, (<unsigned char>1), v15, v16, v43))
        del v45
        return v43
    elif v11 == 2: # raise
        v46 = v5 - (<signed long>1)
        v47 = v8 + (<signed long>2)
        v48 = method34(v3, v9, v10, v47, v6, v7, v8, v46)
        v49 = v7 == (<unsigned char>0)
        if v49:
            v50 = US1_0()
            v51 = Closure9(v15, v16, v13, v14, v12, v0, v1, v2, v3, v4, v46, v9, v10, v47, v6, v7, v8)
            return v2(Tuple0(v48, v12, v6, v7, v8, v9, v10, v47, v50, (<unsigned char>0), v51, v13, v14, v16))
        else:
            v53 = US1_0()
            v54 = Closure10(v15, v16, v13, v14, v12, v0, v1, v2, v3, v4, v46, v9, v10, v47, v6, v7, v8)
            return v0(Tuple0(v48, v12, v6, v7, v8, v9, v10, v47, v53, (<unsigned char>1), v54, v15, v16, v14))
cdef double method28(v0, v1, v2, US0 v3, US0 v4, Heap0 v5, numpy.ndarray[signed long,ndim=1] v6, US3 v7, double v8, UH0 v9, double v10, UH0 v11, double v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef US1 v19
    cdef object v20
    cdef US1 v22
    cdef object v23
    cdef object v26
    cdef signed long v28
    cdef unsigned char v29
    cdef signed long v30
    cdef unsigned char v31
    cdef signed long v32
    cdef numpy.ndarray[signed long,ndim=1] v33
    cdef bint v34
    cdef US1 v35
    cdef object v36
    cdef US1 v38
    cdef object v39
    if v7 == 0: # call
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method29(v5, v3, v16, v15, v4, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = US1_0()
            v20 = Closure4(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v13, v3, v16, v15, v4, v14)
            return v2(Tuple0(v17, v8, v4, v14, v15, v3, v16, v15, v19, (<unsigned char>0), v20, v9, v10, v12))
        else:
            v22 = US1_0()
            v23 = Closure11(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v13, v3, v16, v15, v4, v14)
            return v0(Tuple0(v17, v8, v4, v14, v15, v3, v16, v15, v22, (<unsigned char>1), v23, v11, v12, v10))
    elif v7 == 1: # fold
        raise Exception("impossible")
    elif v7 == 2: # raise
        v28 = (<signed long>1)
        v29 = (<unsigned char>1)
        v30 = (<signed long>1)
        v31 = (<unsigned char>0)
        v32 = (<signed long>3)
        v33 = method34(v5, v3, v31, v32, v4, v29, v30, v28)
        v34 = v29 == (<unsigned char>0)
        if v34:
            v35 = US1_0()
            v36 = Closure9(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v28, v3, v31, v32, v4, v29, v30)
            return v2(Tuple0(v33, v8, v4, v29, v30, v3, v31, v32, v35, (<unsigned char>0), v36, v9, v10, v12))
        else:
            v38 = US1_0()
            v39 = Closure10(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v28, v3, v31, v32, v4, v29, v30)
            return v0(Tuple0(v33, v8, v4, v29, v30, v3, v31, v32, v38, (<unsigned char>1), v39, v11, v12, v10))
cdef double method27(v0, v1, v2, Heap0 v3, US0 v4, US0 v5, numpy.ndarray[signed long,ndim=1] v6, double v7, UH0 v8, double v9, UH0 v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef US1 v13
    cdef object v14
    v12 = v3.v2
    v13 = US1_0()
    v14 = Closure3(v10, v11, v8, v9, v7, v0, v1, v2, v4, v5, v3, v6)
    return v2(Tuple0(v12, v7, v4, (<unsigned char>0), (<signed long>1), v5, (<unsigned char>1), (<signed long>1), v13, (<unsigned char>0), v14, v8, v9, v11))
cdef double method26(numpy.ndarray[signed long,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, double v6, UH0 v7, double v8, UH0 v9, double v10, unsigned long long v11, double v12):
    cdef unsigned long long v13
    cdef double v14
    cdef double v15
    cdef bint v16
    cdef US0 v17
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
        method24(v18, v11, v0, v19, v20)
        v21 = <double>v13
        v22 = (<double>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v6
        v25 = US2_1(v17)
        v26 = UH0_0(v25, v9)
        del v25
        v27 = method27(v1, v2, v3, v4, v5, v17, v19, v24, v7, v8, v26, v10)
        del v19; del v26
        v28 = v11 + (<unsigned long long>1)
        v29 = v12 + v27
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v28, v29)
    else:
        v31 = v12 * v15
        return v31
cdef double method25(v0, v1, v2, Heap0 v3, US0 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, UH0 v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    v11 = (<unsigned long long>0)
    v12 = (<double>0.000000)
    return method26(v5, v0, v1, v2, v3, v4, v6, v7, v8, v9, v10, v11, v12)
cdef double method23(numpy.ndarray[signed long,ndim=1] v0, v1, v2, v3, Heap0 v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef US0 v15
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
        method24(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = (<double>1.000000) / v19
        v21 = libc.math.log(v20)
        v22 = US2_1(v15)
        v23 = UH0_0(v22, v5)
        del v22
        v24 = method25(v1, v2, v3, v4, v15, v17, v21, v23, v6, v7, v8)
        del v17; del v23
        v25 = v9 + (<unsigned long long>1)
        v26 = v10 + v24
        return method23(v0, v1, v2, v3, v4, v5, v6, v7, v8, v25, v26)
    else:
        v28 = v10 * v13
        return v28
cdef double method22(v0, v1, v2):
    cdef UH0 v3
    cdef double v4
    cdef UH0 v5
    cdef double v6
    cdef US3 v7
    cdef US3 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef US3 v10
    cdef US3 v11
    cdef US3 v12
    cdef numpy.ndarray[signed long,ndim=1] v13
    cdef US3 v14
    cdef US3 v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef US3 v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef Heap0 v19
    cdef US0 v20
    cdef US0 v21
    cdef US0 v22
    cdef US0 v23
    cdef US0 v24
    cdef US0 v25
    cdef numpy.ndarray[signed long,ndim=1] v26
    cdef unsigned long long v27
    cdef double v28
    v3 = UH0_1()
    v4 = (<double>0.000000)
    v5 = UH0_1()
    v6 = (<double>0.000000)
    v7 = 0
    v8 = 2
    v9 = numpy.empty(2,dtype=numpy.int32)
    v9[0] = v7; v9[1] = v8
    v10 = 1
    v11 = 0
    v12 = 2
    v13 = numpy.empty(3,dtype=numpy.int32)
    v13[0] = v10; v13[1] = v11; v13[2] = v12
    v14 = 1
    v15 = 0
    v16 = numpy.empty(2,dtype=numpy.int32)
    v16[0] = v14; v16[1] = v15
    v17 = 0
    v18 = numpy.empty(1,dtype=numpy.int32)
    v18[0] = v17
    v19 = Heap0(v18, v13, v9, v16)
    del v9; del v13; del v16; del v18
    v20 = 1
    v21 = 2
    v22 = 0
    v23 = 1
    v24 = 2
    v25 = 0
    v26 = numpy.empty(6,dtype=numpy.int32)
    v26[0] = v20; v26[1] = v21; v26[2] = v22; v26[3] = v23; v26[4] = v24; v26[5] = v25
    v27 = (<unsigned long long>0)
    v28 = (<double>0.000000)
    return method23(v26, v0, v1, v2, v19, v3, v4, v5, v6, v27, v28)
cdef double method48(v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
    cdef signed long v17
    cdef signed long v18
    cdef signed long v19
    cdef bint v20
    cdef bint v22
    cdef signed long v46
    cdef bint v23
    cdef bint v24
    cdef bint v27
    cdef bint v28
    cdef signed long v29
    cdef signed long v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef bint v34
    cdef signed long v37
    cdef bint v35
    cdef bint v38
    cdef bint v39
    cdef bint v40
    cdef bint v47
    cdef unsigned char v51
    cdef signed long v52
    cdef bint v48
    cdef bint v53
    cdef signed long v55
    cdef bint v56
    cdef signed long v58
    cdef signed long v59
    cdef bint v60
    cdef signed long v62
    cdef signed long v63
    cdef US0 v64
    cdef unsigned char v65
    cdef signed long v66
    cdef US0 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef double v70
    cdef US1 v71
    cdef US1 v72
    cdef bint v73
    cdef signed long v75
    cdef bint v76
    cdef signed long v78
    cdef signed long v79
    cdef signed long v81
    cdef signed long v82
    cdef US0 v83
    cdef unsigned char v84
    cdef signed long v85
    cdef US0 v86
    cdef unsigned char v87
    cdef signed long v88
    cdef double v89
    cdef US1 v90
    cdef US1 v91
    cdef signed long v92
    cdef signed long v93
    cdef numpy.ndarray[signed long,ndim=1] v94
    cdef bint v95
    cdef US1 v96
    cdef object v97
    cdef US1 v99
    cdef object v100
    if v11 == 0: # call
        v17 = method36(v4)
        v18 = method36(v8)
        v19 = method36(v5)
        v20 = v18 == v17
        if v20:
            v22 = v19 == v17
        else:
            v22 = 0
        if v22:
            v23 = v18 < v19
            if v23:
                v46 = (<signed long>-1)
            else:
                v24 = v18 > v19
                if v24:
                    v46 = (<signed long>1)
                else:
                    v46 = (<signed long>0)
        else:
            if v20:
                v46 = (<signed long>1)
            else:
                v27 = v19 == v17
                if v27:
                    v46 = (<signed long>-1)
                else:
                    v28 = v18 > v17
                    if v28:
                        v29, v30 = v18, v17
                    else:
                        v29, v30 = v17, v18
                    v31 = v19 > v17
                    if v31:
                        v32, v33 = v19, v17
                    else:
                        v32, v33 = v17, v19
                    v34 = v29 < v32
                    if v34:
                        v37 = (<signed long>-1)
                    else:
                        v35 = v29 > v32
                        if v35:
                            v37 = (<signed long>1)
                        else:
                            v37 = (<signed long>0)
                    v38 = v37 == (<signed long>0)
                    if v38:
                        v39 = v30 < v33
                        if v39:
                            v46 = (<signed long>-1)
                        else:
                            v40 = v30 > v33
                            if v40:
                                v46 = (<signed long>1)
                            else:
                                v46 = (<signed long>0)
                    else:
                        v46 = v37
        v47 = v46 == (<signed long>1)
        if v47:
            v51, v52 = v9, v7
        else:
            v48 = v46 == (<signed long>-1)
            if v48:
                v51, v52 = v6, v7
            else:
                v51, v52 = v9, (<signed long>0)
        v53 = v51 == (<unsigned char>0)
        if v53:
            v55 = v52
        else:
            v55 = -v52
        v56 = v9 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v58 + v7
        v60 = v6 == (<unsigned char>0)
        if v60:
            v62 = v55
        else:
            v62 = -v55
        v63 = v62 + v7
        if v56:
            v64, v65, v66, v67, v68, v69 = v8, v9, v59, v5, v6, v63
        else:
            v64, v65, v66, v67, v68, v69 = v5, v6, v63, v8, v9, v59
        v70 = <double>v55
        v71 = US1_1(v4)
        v1(Tuple4(v12, v64, v65, v66, v67, v68, v69, v71, (<unsigned char>0), v13, v14, v70))
        del v71
        v72 = US1_1(v4)
        v1(Tuple4(v12, v67, v68, v69, v64, v65, v66, v72, (<unsigned char>1), v15, v16, v70))
        del v72
        return v70
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
        v90 = US1_1(v4)
        v1(Tuple4(v12, v83, v84, v85, v86, v87, v88, v90, (<unsigned char>0), v13, v14, v89))
        del v90
        v91 = US1_1(v4)
        v1(Tuple4(v12, v86, v87, v88, v83, v84, v85, v91, (<unsigned char>1), v15, v16, v89))
        del v91
        return v89
    elif v11 == 2: # raise
        v92 = v3 - (<signed long>1)
        v93 = v7 + (<signed long>4)
        v94 = method34(v2, v8, v9, v93, v5, v6, v7, v92)
        v95 = v6 == (<unsigned char>0)
        if v95:
            v96 = US1_1(v4)
            v97 = Closure15(v15, v16, v13, v14, v12, v0, v1, v2, v92, v4, v8, v9, v93, v5, v6, v7)
            return v0(Tuple0(v94, v12, v5, v6, v7, v8, v9, v93, v96, (<unsigned char>0), v97, v13, v14, v16))
        else:
            v99 = US1_1(v4)
            v100 = Closure16(v15, v16, v13, v14, v12, v0, v1, v2, v92, v4, v8, v9, v93, v5, v6, v7)
            return v0(Tuple0(v94, v12, v5, v6, v7, v8, v9, v93, v99, (<unsigned char>1), v100, v15, v16, v14))
cdef double method47(v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef signed long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef US1 v19
    cdef object v20
    cdef US1 v22
    cdef object v23
    cdef object v26
    cdef signed long v28
    cdef signed long v29
    cdef numpy.ndarray[signed long,ndim=1] v30
    cdef bint v31
    cdef US1 v32
    cdef object v33
    cdef US1 v35
    cdef object v36
    if v10 == 0: # call
        v16 = (<signed long>2)
        v17 = method34(v2, v6, v7, v8, v3, v4, v5, v16)
        v18 = v4 == (<unsigned char>0)
        if v18:
            v19 = US1_1(v9)
            v20 = Closure15(v14, v15, v12, v13, v11, v0, v1, v2, v16, v9, v6, v7, v8, v3, v4, v5)
            return v0(Tuple0(v17, v11, v3, v4, v5, v6, v7, v8, v19, (<unsigned char>0), v20, v12, v13, v15))
        else:
            v22 = US1_1(v9)
            v23 = Closure16(v14, v15, v12, v13, v11, v0, v1, v2, v16, v9, v6, v7, v8, v3, v4, v5)
            return v0(Tuple0(v17, v11, v3, v4, v5, v6, v7, v8, v22, (<unsigned char>1), v23, v14, v15, v13))
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v28 = (<signed long>1)
        v29 = v5 + (<signed long>4)
        v30 = method34(v2, v6, v7, v29, v3, v4, v5, v28)
        v31 = v4 == (<unsigned char>0)
        if v31:
            v32 = US1_1(v9)
            v33 = Closure15(v14, v15, v12, v13, v11, v0, v1, v2, v28, v9, v6, v7, v29, v3, v4, v5)
            return v0(Tuple0(v30, v11, v3, v4, v5, v6, v7, v29, v32, (<unsigned char>0), v33, v12, v13, v15))
        else:
            v35 = US1_1(v9)
            v36 = Closure16(v14, v15, v12, v13, v11, v0, v1, v2, v28, v9, v6, v7, v29, v3, v4, v5)
            return v0(Tuple0(v30, v11, v3, v4, v5, v6, v7, v29, v35, (<unsigned char>1), v36, v14, v15, v13))
cdef double method46(v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14):
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef bint v16
    cdef US1 v17
    cdef object v18
    cdef US1 v20
    cdef object v21
    v15 = v2.v2
    v16 = v7 == (<unsigned char>0)
    if v16:
        v17 = US1_1(v9)
        v18 = Closure14(v13, v14, v11, v12, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        return v0(Tuple0(v15, v10, v6, v7, v8, v3, v4, v5, v17, (<unsigned char>0), v18, v11, v12, v14))
    else:
        v20 = US1_1(v9)
        v21 = Closure17(v13, v14, v11, v12, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        return v0(Tuple0(v15, v10, v6, v7, v8, v3, v4, v5, v20, (<unsigned char>1), v21, v13, v14, v12))
cdef double method45(numpy.ndarray[signed long,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, double v10, UH0 v11, double v12, UH0 v13, double v14, unsigned long long v15, double v16):
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef bint v20
    cdef US0 v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef US2 v26
    cdef UH0 v27
    cdef US2 v28
    cdef UH0 v29
    cdef double v30
    cdef unsigned long long v31
    cdef double v32
    cdef double v34
    v17 = len(v0)
    v18 = <double>v17
    v19 = (<double>1.000000) / v18
    v20 = v15 < v17
    if v20:
        v21 = v0[v15]
        v22 = <double>v17
        v23 = (<double>1.000000) / v22
        v24 = libc.math.log(v23)
        v25 = v24 + v10
        v26 = US2_1(v21)
        v27 = UH0_0(v26, v11)
        del v26
        v28 = US2_1(v21)
        v29 = UH0_0(v28, v13)
        del v28
        v30 = method46(v1, v2, v3, v4, v5, v6, v7, v8, v9, v21, v25, v27, v12, v29, v14)
        del v27; del v29
        v31 = v15 + (<unsigned long long>1)
        v32 = v16 + v30
        return method45(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v31, v32)
    else:
        v34 = v16 * v19
        return v34
cdef double method49(v0, v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
    cdef bint v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
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
    cdef US0 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef US0 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef double v43
    cdef US1 v44
    cdef US1 v45
    cdef signed long v46
    cdef signed long v47
    cdef numpy.ndarray[signed long,ndim=1] v48
    cdef bint v49
    cdef US1 v50
    cdef object v51
    cdef US1 v53
    cdef object v54
    if v11 == 0: # call
        v17 = v9 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v8, v9, v7, v5, v6, v7
        else:
            v18, v19, v20, v21, v22, v23 = v5, v6, v7, v8, v9, v7
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method45(v3, v0, v1, v2, v21, v22, v23, v18, v19, v20, v12, v13, v14, v15, v16, v24, v25)
    elif v11 == 1: # fold
        v27 = v6 == (<unsigned char>0)
        if v27:
            v29 = v10
        else:
            v29 = -v10
        v30 = v9 == (<unsigned char>0)
        if v30:
            v32 = v29
        else:
            v32 = -v29
        v33 = v32 + v10
        if v27:
            v35 = v29
        else:
            v35 = -v29
        v36 = v35 + v7
        if v30:
            v37, v38, v39, v40, v41, v42 = v8, v9, v33, v5, v6, v36
        else:
            v37, v38, v39, v40, v41, v42 = v5, v6, v36, v8, v9, v33
        v43 = <double>v29
        v44 = US1_0()
        v1(Tuple4(v12, v37, v38, v39, v40, v41, v42, v44, (<unsigned char>0), v13, v14, v43))
        del v44
        v45 = US1_0()
        v1(Tuple4(v12, v40, v41, v42, v37, v38, v39, v45, (<unsigned char>1), v15, v16, v43))
        del v45
        return v43
    elif v11 == 2: # raise
        v46 = v4 - (<signed long>1)
        v47 = v7 + (<signed long>2)
        v48 = method34(v2, v8, v9, v47, v5, v6, v7, v46)
        v49 = v6 == (<unsigned char>0)
        if v49:
            v50 = US1_0()
            v51 = Closure18(v15, v16, v13, v14, v12, v0, v1, v2, v3, v46, v8, v9, v47, v5, v6, v7)
            return v0(Tuple0(v48, v12, v5, v6, v7, v8, v9, v47, v50, (<unsigned char>0), v51, v13, v14, v16))
        else:
            v53 = US1_0()
            v54 = Closure19(v15, v16, v13, v14, v12, v0, v1, v2, v3, v46, v8, v9, v47, v5, v6, v7)
            return v0(Tuple0(v48, v12, v5, v6, v7, v8, v9, v47, v53, (<unsigned char>1), v54, v15, v16, v14))
cdef double method44(v0, v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef bint v16
    cdef US0 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US0 v20
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
    cdef US0 v36
    cdef unsigned char v37
    cdef signed long v38
    cdef US0 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef double v42
    cdef US1 v43
    cdef US1 v44
    cdef signed long v45
    cdef signed long v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef bint v48
    cdef US1 v49
    cdef object v50
    cdef US1 v52
    cdef object v53
    if v10 == 0: # call
        v16 = v9 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v8, v9, v7, v5, v6, v7
        else:
            v17, v18, v19, v20, v21, v22 = v5, v6, v7, v8, v9, v7
        v23 = (<unsigned long long>0)
        v24 = (<double>0.000000)
        return method45(v3, v0, v1, v2, v20, v21, v22, v17, v18, v19, v11, v12, v13, v14, v15, v23, v24)
    elif v10 == 1: # fold
        v26 = v6 == (<unsigned char>0)
        if v26:
            v28 = v7
        else:
            v28 = -v7
        v29 = v9 == (<unsigned char>0)
        if v29:
            v31 = v28
        else:
            v31 = -v28
        v32 = v31 + v7
        if v26:
            v34 = v28
        else:
            v34 = -v28
        v35 = v34 + v7
        if v29:
            v36, v37, v38, v39, v40, v41 = v8, v9, v32, v5, v6, v35
        else:
            v36, v37, v38, v39, v40, v41 = v5, v6, v35, v8, v9, v32
        v42 = <double>v28
        v43 = US1_0()
        v1(Tuple4(v11, v36, v37, v38, v39, v40, v41, v43, (<unsigned char>0), v12, v13, v42))
        del v43
        v44 = US1_0()
        v1(Tuple4(v11, v39, v40, v41, v36, v37, v38, v44, (<unsigned char>1), v14, v15, v42))
        del v44
        return v42
    elif v10 == 2: # raise
        v45 = v4 - (<signed long>1)
        v46 = v7 + (<signed long>2)
        v47 = method34(v2, v8, v9, v46, v5, v6, v7, v45)
        v48 = v6 == (<unsigned char>0)
        if v48:
            v49 = US1_0()
            v50 = Closure18(v14, v15, v12, v13, v11, v0, v1, v2, v3, v45, v8, v9, v46, v5, v6, v7)
            return v0(Tuple0(v47, v11, v5, v6, v7, v8, v9, v46, v49, (<unsigned char>0), v50, v12, v13, v15))
        else:
            v52 = US1_0()
            v53 = Closure19(v14, v15, v12, v13, v11, v0, v1, v2, v3, v45, v8, v9, v46, v5, v6, v7)
            return v0(Tuple0(v47, v11, v5, v6, v7, v8, v9, v46, v52, (<unsigned char>1), v53, v14, v15, v13))
cdef double method43(v0, v1, US0 v2, US0 v3, Heap0 v4, numpy.ndarray[signed long,ndim=1] v5, US3 v6, double v7, UH0 v8, double v9, UH0 v10, double v11):
    cdef signed long v12
    cdef unsigned char v13
    cdef signed long v14
    cdef unsigned char v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef US1 v18
    cdef object v19
    cdef US1 v21
    cdef object v22
    cdef object v25
    cdef signed long v27
    cdef unsigned char v28
    cdef signed long v29
    cdef unsigned char v30
    cdef signed long v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef bint v33
    cdef US1 v34
    cdef object v35
    cdef US1 v37
    cdef object v38
    if v6 == 0: # call
        v12 = (<signed long>2)
        v13 = (<unsigned char>1)
        v14 = (<signed long>1)
        v15 = (<unsigned char>0)
        v16 = method29(v4, v2, v15, v14, v3, v13, v12)
        v17 = v13 == (<unsigned char>0)
        if v17:
            v18 = US1_0()
            v19 = Closure13(v10, v11, v8, v9, v7, v0, v1, v4, v5, v12, v2, v15, v14, v3, v13)
            return v0(Tuple0(v16, v7, v3, v13, v14, v2, v15, v14, v18, (<unsigned char>0), v19, v8, v9, v11))
        else:
            v21 = US1_0()
            v22 = Closure20(v10, v11, v8, v9, v7, v0, v1, v4, v5, v12, v2, v15, v14, v3, v13)
            return v0(Tuple0(v16, v7, v3, v13, v14, v2, v15, v14, v21, (<unsigned char>1), v22, v10, v11, v9))
    elif v6 == 1: # fold
        raise Exception("impossible")
    elif v6 == 2: # raise
        v27 = (<signed long>1)
        v28 = (<unsigned char>1)
        v29 = (<signed long>1)
        v30 = (<unsigned char>0)
        v31 = (<signed long>3)
        v32 = method34(v4, v2, v30, v31, v3, v28, v29, v27)
        v33 = v28 == (<unsigned char>0)
        if v33:
            v34 = US1_0()
            v35 = Closure18(v10, v11, v8, v9, v7, v0, v1, v4, v5, v27, v2, v30, v31, v3, v28, v29)
            return v0(Tuple0(v32, v7, v3, v28, v29, v2, v30, v31, v34, (<unsigned char>0), v35, v8, v9, v11))
        else:
            v37 = US1_0()
            v38 = Closure19(v10, v11, v8, v9, v7, v0, v1, v4, v5, v27, v2, v30, v31, v3, v28, v29)
            return v0(Tuple0(v32, v7, v3, v28, v29, v2, v30, v31, v37, (<unsigned char>1), v38, v10, v11, v9))
cdef double method42(v0, v1, Heap0 v2, US0 v3, US0 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, UH0 v9, double v10):
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef US1 v12
    cdef object v13
    v11 = v2.v2
    v12 = US1_0()
    v13 = Closure12(v9, v10, v7, v8, v6, v0, v1, v3, v4, v2, v5)
    return v0(Tuple0(v11, v6, v3, (<unsigned char>0), (<signed long>1), v4, (<unsigned char>1), (<signed long>1), v12, (<unsigned char>0), v13, v7, v8, v10))
cdef double method41(numpy.ndarray[signed long,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, double v5, UH0 v6, double v7, UH0 v8, double v9, unsigned long long v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef US0 v16
    cdef unsigned long long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef unsigned long long v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef double v26
    cdef unsigned long long v27
    cdef double v28
    cdef double v30
    v12 = len(v0)
    v13 = <double>v12
    v14 = (<double>1.000000) / v13
    v15 = v10 < v12
    if v15:
        v16 = v0[v10]
        v17 = v12 - (<unsigned long long>1)
        v18 = numpy.empty(v17,dtype=numpy.int32)
        v19 = (<unsigned long long>0)
        method24(v17, v10, v0, v18, v19)
        v20 = <double>v12
        v21 = (<double>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v5
        v24 = US2_1(v16)
        v25 = UH0_0(v24, v8)
        del v24
        v26 = method42(v1, v2, v3, v4, v16, v18, v23, v6, v7, v25, v9)
        del v18; del v25
        v27 = v10 + (<unsigned long long>1)
        v28 = v11 + v26
        return method41(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v27, v28)
    else:
        v30 = v11 * v14
        return v30
cdef double method40(v0, v1, Heap0 v2, US0 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9):
    cdef unsigned long long v10
    cdef double v11
    v10 = (<unsigned long long>0)
    v11 = (<double>0.000000)
    return method41(v4, v0, v1, v2, v3, v5, v6, v7, v8, v9, v10, v11)
cdef double method39(numpy.ndarray[signed long,ndim=1] v0, v1, v2, Heap0 v3, UH0 v4, double v5, UH0 v6, double v7, unsigned long long v8, double v9):
    cdef unsigned long long v10
    cdef double v11
    cdef double v12
    cdef bint v13
    cdef US0 v14
    cdef unsigned long long v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef US2 v21
    cdef UH0 v22
    cdef double v23
    cdef unsigned long long v24
    cdef double v25
    cdef double v27
    v10 = len(v0)
    v11 = <double>v10
    v12 = (<double>1.000000) / v11
    v13 = v8 < v10
    if v13:
        v14 = v0[v8]
        v15 = v10 - (<unsigned long long>1)
        v16 = numpy.empty(v15,dtype=numpy.int32)
        v17 = (<unsigned long long>0)
        method24(v15, v8, v0, v16, v17)
        v18 = <double>v10
        v19 = (<double>1.000000) / v18
        v20 = libc.math.log(v19)
        v21 = US2_1(v14)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = method40(v1, v2, v3, v14, v16, v20, v22, v5, v6, v7)
        del v16; del v22
        v24 = v8 + (<unsigned long long>1)
        v25 = v9 + v23
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v24, v25)
    else:
        v27 = v9 * v12
        return v27
cdef double method38(v0, v1):
    cdef UH0 v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef US3 v6
    cdef US3 v7
    cdef numpy.ndarray[signed long,ndim=1] v8
    cdef US3 v9
    cdef US3 v10
    cdef US3 v11
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef US3 v13
    cdef US3 v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef US3 v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef Heap0 v18
    cdef US0 v19
    cdef US0 v20
    cdef US0 v21
    cdef US0 v22
    cdef US0 v23
    cdef US0 v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef unsigned long long v26
    cdef double v27
    v2 = UH0_1()
    v3 = (<double>0.000000)
    v4 = UH0_1()
    v5 = (<double>0.000000)
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
    v26 = (<unsigned long long>0)
    v27 = (<double>0.000000)
    return method39(v25, v0, v1, v18, v2, v3, v4, v5, v26, v27)
cdef void method2(Mut0 v0, unsigned long v1):
    cdef bint v2
    cdef unsigned long v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef double v7
    cdef double v8
    v2 = v1 < (<unsigned long>3)
    if v2:
        v3 = v1 + (<unsigned long>1)
        v4 = Closure0(v0)
        v5 = Closure1()
        v6 = Closure2(v0)
        v7 = method22(v6, v5, v4)
        del v6
        v8 = method38(v4, v5)
        del v4; del v5
        print(v8)
        method2(v0, v3)
    else:
        pass
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef unsigned long v3
    v0 = (<unsigned long long>3)
    v1 = (<unsigned long long>7)
    v2 = method0(v0, v1)
    v3 = (<unsigned long>0)
    method2(v2, v3)
