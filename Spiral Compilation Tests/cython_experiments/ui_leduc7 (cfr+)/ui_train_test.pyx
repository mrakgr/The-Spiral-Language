import numpy
cimport numpy
import ui_train
cimport libc.math
import ui_leduc
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
cdef class Mut1:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    cdef public unsigned long long v3
    def __init__(self, v0, v1, v2, unsigned long long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut1 v2
    def __init__(self, unsigned long long v0, UH0 v1, Mut1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple2:
    cdef readonly double v0
    cdef readonly US3 v1
    def __init__(self, double v0, US3 v1): self.v0 = v0; self.v1 = v1
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
        cdef Mut1 v15
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
        v15 = method2(v0, v1, v12)
        v16 = v2 + v14
        v17 = libc.math.exp(v16)
        v18 = v15.v2
        v19 = method11(v18)
        del v18
        v20 = len(v19)
        v21 = len(v1)
        v22 = v20 == v21
        v23 = v22 != 1
        if v23:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v24 = numpy.empty(v20,dtype=numpy.float64)
        v25 = (<unsigned long long>0)
        v26 = (<double>0.000000)
        v27 = method15(v20, v11, v17, v19, v1, v24, v25, v26)
        del v19
        return method16(v12, v13, v15, v17, v27, v24, v10)
cdef class Tuple3:
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
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, Tuple3 args):
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
cdef class Closure3():
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
        cdef Mut1 v15
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
        v15 = method2(v0, v1, v12)
        v16 = v2 + v14
        v17 = libc.math.exp(v16)
        v18 = v15.v2
        del v15
        v19 = method11(v18)
        del v18
        v20 = len(v19)
        v21 = len(v1)
        v22 = v20 == v21
        v23 = v22 == 0
        if v23:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method20(v20, v11, v17, v19, v1, v24, v25)
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
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
    cdef signed long v9
    cdef US0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, signed long v9, US0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple2 args):
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
        return method34(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v3, v23, v19)
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
    def __call__(self, Tuple2 args):
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
        return method34(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v19, v23, v1)
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
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    cdef US0 v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple2 args):
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
        return method32(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
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
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    cdef US0 v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple2 args):
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
        return method32(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
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
    cdef signed long v16
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple2 args):
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
        return method36(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v3, v23, v19)
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
    def __call__(self, Tuple2 args):
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
        return method36(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v18, v4, v21, v19, v23, v1)
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
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple2 args):
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
        return method29(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure12():
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
    def __call__(self, Tuple2 args):
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
        return method29(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
cdef class Closure4():
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
    def __call__(self, Tuple2 args):
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
        return method27(v5, v6, v7, v8, v9, v10, v11, v13, v4, v16, v14, v18, v1)
cdef class Closure13():
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
        cdef Mut1 v15
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
        v15 = method2(v0, v1, v12)
        v16 = v2 + v14
        v17 = libc.math.exp(v16)
        v18 = v15.v1
        del v15
        v19 = method11(v18)
        del v18
        v20 = len(v19)
        v21 = len(v1)
        v22 = v20 == v21
        v23 = v22 == 0
        if v23:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v24 = (<unsigned long long>0)
        v25 = (<double>0.000000)
        return method20(v20, v11, v17, v19, v1, v24, v25)
cdef class Closure18():
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
    def __call__(self, Tuple2 args):
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
        return method47(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
cdef class Closure17():
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
    def __call__(self, Tuple2 args):
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
        return method47(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure16():
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
    def __call__(self, Tuple2 args):
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
        return method46(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v17, v21, v1)
cdef class Closure19():
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
    def __call__(self, Tuple2 args):
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
        return method46(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v3, v21, v17)
cdef class Closure21():
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
    def __call__(self, Tuple2 args):
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
        return method48(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v3, v22, v18)
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
    cdef signed long v15
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple2 args):
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
        return method48(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v17, v4, v20, v18, v22, v1)
cdef class Closure15():
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
    def __call__(self, Tuple2 args):
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
        return method43(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v17, v21, v1)
cdef class Closure22():
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
    def __call__(self, Tuple2 args):
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
        return method43(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v3, v21, v17)
cdef class Closure14():
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
    def __call__(self, Tuple2 args):
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
        return method42(v5, v6, v7, v8, v9, v10, v12, v4, v15, v13, v17, v1)
cdef class Closure0():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef object v1
        cdef object v2
        cdef object v3
        cdef double v4
        cdef double v5
        cdef object v6
        v1 = Closure1(v0)
        v2 = Closure2()
        v3 = Closure3(v0)
        v4 = method21(v3, v2, v1)
        v5 = method21(v1, v2, v3)
        del v1; del v3
        v6 = Closure13(v0)
        return method37(v6, v2)
cdef class Tuple4:
    cdef readonly UH0 v0
    cdef readonly Mut1 v1
    def __init__(self, UH0 v0, Mut1 v1): self.v0 = v0; self.v1 = v1
cdef class Closure23():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1
        cdef unsigned long long v2
        cdef list v3
        cdef unsigned long long v4
        v1 = method49(v0)
        v2 = len(v1)
        v3 = [None]*v2
        v4 = (<unsigned long long>0)
        method53(v2, v1, v3, v4)
        del v1
        return v3
cdef class Closure26():
    def __init__(self): pass
    def __call__(self, double v0):
        pass
cdef class US4:
    cdef readonly signed long tag
cdef class US4_0(US4): # none
    def __init__(self): self.tag = 0
cdef class US4_1(US4): # some_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class Closure27():
    def __init__(self): pass
    def __call__(self, US3 v0):
        pass
cdef class Mut2:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure28():
    cdef object v0
    cdef US3 v1
    def __init__(self, v0, US3 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US3 v1 = self.v1
        v0(v1)
cdef class Closure29():
    cdef object v0
    cdef US3 v1
    def __init__(self, v0, US3 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US3 v1 = self.v1
        v0(v1)
cdef class Closure30():
    cdef object v0
    cdef US3 v1
    def __init__(self, v0, US3 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US3 v1 = self.v1
        v0(v1)
cdef class Closure31():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef Mut0 v7
    cdef Heap0 v8
    cdef signed long v9
    cdef US0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Mut0 v7, Heap0 v8, signed long v9, US0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, US3 v17):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef Mut0 v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v18 = US2_0(v17)
        v19 = UH0_0(v18, v3)
        del v18
        v20 = US2_0(v17)
        v21 = UH0_0(v20, v1)
        del v20
        method63(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v5, v19, v4, v21, v2, v0)
cdef class Closure32():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef Mut0 v7
    cdef Heap0 v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    cdef US0 v15
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Mut0 v7, Heap0 v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, US3 v16):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef Mut0 v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef US0 v15 = self.v15
        cdef US2 v17
        cdef UH0 v18
        cdef US2 v19
        cdef UH0 v20
        v17 = US2_0(v16)
        v18 = UH0_0(v17, v3)
        del v17
        v19 = US2_0(v16)
        v20 = UH0_0(v19, v1)
        del v19
        method62(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v5, v18, v4, v20, v2, v0)
cdef class Closure33():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef Mut0 v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Mut0 v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, US3 v17):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef Mut0 v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v18 = US2_0(v17)
        v19 = UH0_0(v18, v3)
        del v18
        v20 = US2_0(v17)
        v21 = UH0_0(v20, v1)
        del v20
        method69(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v5, v19, v4, v21, v2, v0)
cdef class Closure34():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef Mut0 v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Mut0 v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, US3 v16):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef Mut0 v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef US2 v17
        cdef UH0 v18
        cdef US2 v19
        cdef UH0 v20
        v17 = US2_0(v16)
        v18 = UH0_0(v17, v3)
        del v17
        v19 = US2_0(v16)
        v20 = UH0_0(v19, v1)
        del v19
        method60(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v5, v18, v4, v20, v2, v0)
cdef class Closure25():
    cdef Mut0 v0
    cdef object v1
    def __init__(self, Mut0 v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef object v1 = self.v1
        cdef US3 v2
        cdef US3 v3
        cdef numpy.ndarray[signed long,ndim=1] v4
        cdef US3 v5
        cdef US3 v6
        cdef US3 v7
        cdef numpy.ndarray[signed long,ndim=1] v8
        cdef US3 v9
        cdef US3 v10
        cdef numpy.ndarray[signed long,ndim=1] v11
        cdef US3 v12
        cdef numpy.ndarray[signed long,ndim=1] v13
        cdef Heap0 v14
        cdef US0 v15
        cdef US0 v16
        cdef US0 v17
        cdef US0 v18
        cdef US0 v19
        cdef US0 v20
        cdef numpy.ndarray[signed long,ndim=1] v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef UH0 v24
        cdef double v25
        cdef UH0 v26
        cdef double v27
        cdef US0 v28
        cdef unsigned long long v29
        cdef numpy.ndarray[signed long,ndim=1] v30
        cdef unsigned long long v31
        cdef double v32
        cdef double v33
        cdef double v34
        cdef US2 v35
        cdef UH0 v36
        cdef object v37
        v2 = 0
        v3 = 2
        v4 = numpy.empty(2,dtype=numpy.int32)
        v4[0] = v2; v4[1] = v3
        v5 = 1
        v6 = 0
        v7 = 2
        v8 = numpy.empty(3,dtype=numpy.int32)
        v8[0] = v5; v8[1] = v6; v8[2] = v7
        v9 = 1
        v10 = 0
        v11 = numpy.empty(2,dtype=numpy.int32)
        v11[0] = v9; v11[1] = v10
        v12 = 0
        v13 = numpy.empty(1,dtype=numpy.int32)
        v13[0] = v12
        v14 = Heap0(v13, v8, v4, v11)
        del v4; del v8; del v11; del v13
        v15 = 1
        v16 = 2
        v17 = 0
        v18 = 1
        v19 = 2
        v20 = 0
        v21 = numpy.empty(6,dtype=numpy.int32)
        v21[0] = v15; v21[1] = v16; v21[2] = v17; v21[3] = v18; v21[4] = v19; v21[5] = v20
        v22 = len(v21)
        v23 = numpy.random.randint(0,v22)
        v24 = UH0_1()
        v25 = (<double>0.000000)
        v26 = UH0_1()
        v27 = (<double>0.000000)
        v28 = v21[v23]
        v29 = v22 - (<unsigned long long>1)
        v30 = numpy.empty(v29,dtype=numpy.int32)
        v31 = (<unsigned long long>0)
        method23(v29, v23, v21, v30, v31)
        del v21
        v32 = <double>v22
        v33 = (<double>1.000000) / v32
        v34 = libc.math.log(v33)
        v35 = US2_1(v28)
        v36 = UH0_0(v35, v24)
        del v24; del v35
        v37 = Closure26()
        method57(v1, v0, v14, v28, v30, v34, v36, v25, v26, v27, v37)
cdef class Closure24():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef object v1
        cdef object v2
        pass # import ui_leduc
        v1 = ui_leduc.Top()
        v2 = Closure25(v0, v1)
        ui_leduc.popup_game(v1,v2)
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
    cdef Mut1 v9
    cdef Tuple1 tmp1
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
        v11.append(Tuple1(v7, v8, v9))
        del v8; del v9; del v11
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
cdef Mut1 method4(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut1 v10
    cdef Tuple1 tmp0
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
            v13 = method5(v9, v1)
        else:
            v13 = 0
        del v9
        if v13:
            return v10
        else:
            del v10
            v14 = v5 + (<unsigned long long>1)
            return method4(v0, v1, v2, v3, v4, v14)
    else:
        v17 = len(v2)
        v18 = numpy.empty(v17,dtype=numpy.float64)
        v19 = (<unsigned long long>0)
        method6(v17, v18, v19)
        v20 = numpy.empty(v17,dtype=numpy.float64)
        v21 = (<unsigned long long>0)
        method6(v17, v20, v21)
        v22 = Mut1(v2, v20, v18, (<unsigned long long>1))
        del v18; del v20
        v4.append(Tuple1(v3, v1, v22))
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
            method7(v0)
        else:
            pass
        return v22
cdef Mut1 method2(Mut0 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
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
cdef double method15(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[signed long,ndim=1] v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6, double v7):
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
            v17 = v1(Tuple2(v15, v11))
        v18 = v17 * v10
        v19 = v7 + v18
        v5[v6] = v17
        return method15(v0, v1, v2, v3, v4, v5, v9, v19)
    else:
        return v7
cdef void method17(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned char v4, double v5, numpy.ndarray[double,ndim=1] v6, unsigned long long v7):
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
        method17(v0, v1, v2, v3, v4, v5, v6, v9)
    else:
        pass
cdef void method18(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, double v3, numpy.ndarray[double,ndim=1] v4, unsigned long long v5):
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
        method18(v0, v1, v2, v3, v4, v7)
    else:
        pass
cdef double method19(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
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
        return method19(v0, v1, v2, v6, v10)
    else:
        return v4
cdef double method16(UH0 v0, double v1, Mut1 v2, double v3, double v4, numpy.ndarray[double,ndim=1] v5, unsigned char v6):
    cdef unsigned long long v7
    cdef double v8
    cdef numpy.ndarray[double,ndim=1] v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef numpy.ndarray[double,ndim=1] v13
    cdef double v14
    cdef numpy.ndarray[double,ndim=1] v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef unsigned long long v24
    cdef double v25
    v7 = v2.v3
    v8 = <double>v7
    v9 = v2.v2
    v10 = len(v9)
    v11 = (<unsigned long long>0)
    method17(v10, v3, v4, v5, v6, v8, v9, v11)
    del v9
    v12 = v2.v2
    v13 = method11(v12)
    del v12
    v14 = libc.math.exp(v1)
    v15 = v2.v1
    v16 = len(v15)
    v17 = (<unsigned long long>0)
    method18(v16, v8, v13, v14, v15, v17)
    del v15
    v18 = v2.v3
    v19 = v18 + (<unsigned long long>1)
    v2.v3 = v19
    v20 = len(v13)
    v21 = len(v5)
    v22 = v20 == v21
    v23 = v22 == 0
    if v23:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v24 = (<unsigned long long>0)
    v25 = (<double>0.000000)
    return method19(v20, v13, v5, v24, v25)
cdef double method20(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[signed long,ndim=1] v4, unsigned long long v5, double v6):
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
            v16 = v1(Tuple2(v14, v10))
        v17 = v16 * v9
        v18 = v6 + v17
        return method20(v0, v1, v2, v3, v4, v8, v18)
    else:
        return v6
cdef void method23(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
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
        method23(v0, v1, v2, v3, v6)
    else:
        pass
cdef numpy.ndarray[signed long,ndim=1] method28(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method33(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method35(US0 v0):
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef double method34(v0, v1, v2, Heap0 v3, signed long v4, US0 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US3 v12, double v13, UH0 v14, double v15, UH0 v16, double v17):
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
        v18 = method35(v5)
        v19 = method35(v9)
        v20 = method35(v6)
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
        v1(Tuple3(v13, v65, v66, v67, v68, v69, v70, v72, (<unsigned char>0), v14, v15, v71))
        del v72
        v73 = US1_1(v5)
        v1(Tuple3(v13, v68, v69, v70, v65, v66, v67, v73, (<unsigned char>1), v16, v17, v71))
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
        v1(Tuple3(v13, v84, v85, v86, v87, v88, v89, v91, (<unsigned char>0), v14, v15, v90))
        del v91
        v92 = US1_1(v5)
        v1(Tuple3(v13, v87, v88, v89, v84, v85, v86, v92, (<unsigned char>1), v16, v17, v90))
        del v92
        return v90
    elif v12 == 2: # raise
        v93 = v4 - (<signed long>1)
        v94 = v8 + (<signed long>4)
        v95 = method33(v3, v9, v10, v94, v6, v7, v8, v93)
        v96 = v7 == (<unsigned char>0)
        if v96:
            v97 = US1_1(v5)
            v98 = Closure7(v16, v17, v14, v15, v13, v0, v1, v2, v3, v93, v5, v9, v10, v94, v6, v7, v8)
            return v2(Tuple0(v95, v13, v6, v7, v8, v9, v10, v94, v97, (<unsigned char>0), v98, v14, v15, v17))
        else:
            v100 = US1_1(v5)
            v101 = Closure8(v16, v17, v14, v15, v13, v0, v1, v2, v3, v93, v5, v9, v10, v94, v6, v7, v8)
            return v0(Tuple0(v95, v13, v6, v7, v8, v9, v10, v94, v100, (<unsigned char>1), v101, v16, v17, v15))
cdef double method32(v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
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
        v18 = method33(v3, v7, v8, v9, v4, v5, v6, v17)
        v19 = v5 == (<unsigned char>0)
        if v19:
            v20 = US1_1(v10)
            v21 = Closure7(v15, v16, v13, v14, v12, v0, v1, v2, v3, v17, v10, v7, v8, v9, v4, v5, v6)
            return v2(Tuple0(v18, v12, v4, v5, v6, v7, v8, v9, v20, (<unsigned char>0), v21, v13, v14, v16))
        else:
            v23 = US1_1(v10)
            v24 = Closure8(v15, v16, v13, v14, v12, v0, v1, v2, v3, v17, v10, v7, v8, v9, v4, v5, v6)
            return v0(Tuple0(v18, v12, v4, v5, v6, v7, v8, v9, v23, (<unsigned char>1), v24, v15, v16, v14))
    elif v11 == 1: # fold
        raise Exception("impossible")
    elif v11 == 2: # raise
        v29 = (<signed long>1)
        v30 = v6 + (<signed long>4)
        v31 = method33(v3, v7, v8, v30, v4, v5, v6, v29)
        v32 = v5 == (<unsigned char>0)
        if v32:
            v33 = US1_1(v10)
            v34 = Closure7(v15, v16, v13, v14, v12, v0, v1, v2, v3, v29, v10, v7, v8, v30, v4, v5, v6)
            return v2(Tuple0(v31, v12, v4, v5, v6, v7, v8, v30, v33, (<unsigned char>0), v34, v13, v14, v16))
        else:
            v36 = US1_1(v10)
            v37 = Closure8(v15, v16, v13, v14, v12, v0, v1, v2, v3, v29, v10, v7, v8, v30, v4, v5, v6)
            return v0(Tuple0(v31, v12, v4, v5, v6, v7, v8, v30, v36, (<unsigned char>1), v37, v15, v16, v14))
cdef double method31(v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
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
        v19 = Closure6(v14, v15, v12, v13, v11, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        return v2(Tuple0(v16, v11, v7, v8, v9, v4, v5, v6, v18, (<unsigned char>0), v19, v12, v13, v15))
    else:
        v21 = US1_1(v10)
        v22 = Closure9(v14, v15, v12, v13, v11, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10)
        return v0(Tuple0(v16, v11, v7, v8, v9, v4, v5, v6, v21, (<unsigned char>1), v22, v14, v15, v13))
cdef double method30(numpy.ndarray[signed long,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, double v11, UH0 v12, double v13, UH0 v14, double v15, unsigned long long v16, double v17):
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
        v31 = method31(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v22, v26, v28, v13, v30, v15)
        del v28; del v30
        v32 = v16 + (<unsigned long long>1)
        v33 = v17 + v31
        return method30(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v32, v33)
    else:
        v35 = v17 * v20
        return v35
cdef double method36(v0, v1, v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US3 v12, double v13, UH0 v14, double v15, UH0 v16, double v17):
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
        return method30(v4, v0, v1, v2, v3, v22, v23, v24, v19, v20, v21, v13, v14, v15, v16, v17, v25, v26)
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
        v1(Tuple3(v13, v38, v39, v40, v41, v42, v43, v45, (<unsigned char>0), v14, v15, v44))
        del v45
        v46 = US1_0()
        v1(Tuple3(v13, v41, v42, v43, v38, v39, v40, v46, (<unsigned char>1), v16, v17, v44))
        del v46
        return v44
    elif v12 == 2: # raise
        v47 = v5 - (<signed long>1)
        v48 = v8 + (<signed long>2)
        v49 = method33(v3, v9, v10, v48, v6, v7, v8, v47)
        v50 = v7 == (<unsigned char>0)
        if v50:
            v51 = US1_0()
            v52 = Closure10(v16, v17, v14, v15, v13, v0, v1, v2, v3, v4, v47, v9, v10, v48, v6, v7, v8)
            return v2(Tuple0(v49, v13, v6, v7, v8, v9, v10, v48, v51, (<unsigned char>0), v52, v14, v15, v17))
        else:
            v54 = US1_0()
            v55 = Closure11(v16, v17, v14, v15, v13, v0, v1, v2, v3, v4, v47, v9, v10, v48, v6, v7, v8)
            return v0(Tuple0(v49, v13, v6, v7, v8, v9, v10, v48, v54, (<unsigned char>1), v55, v16, v17, v15))
cdef double method29(v0, v1, v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
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
        return method30(v4, v0, v1, v2, v3, v21, v22, v23, v18, v19, v20, v12, v13, v14, v15, v16, v24, v25)
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
        v1(Tuple3(v12, v37, v38, v39, v40, v41, v42, v44, (<unsigned char>0), v13, v14, v43))
        del v44
        v45 = US1_0()
        v1(Tuple3(v12, v40, v41, v42, v37, v38, v39, v45, (<unsigned char>1), v15, v16, v43))
        del v45
        return v43
    elif v11 == 2: # raise
        v46 = v5 - (<signed long>1)
        v47 = v8 + (<signed long>2)
        v48 = method33(v3, v9, v10, v47, v6, v7, v8, v46)
        v49 = v7 == (<unsigned char>0)
        if v49:
            v50 = US1_0()
            v51 = Closure10(v15, v16, v13, v14, v12, v0, v1, v2, v3, v4, v46, v9, v10, v47, v6, v7, v8)
            return v2(Tuple0(v48, v12, v6, v7, v8, v9, v10, v47, v50, (<unsigned char>0), v51, v13, v14, v16))
        else:
            v53 = US1_0()
            v54 = Closure11(v15, v16, v13, v14, v12, v0, v1, v2, v3, v4, v46, v9, v10, v47, v6, v7, v8)
            return v0(Tuple0(v48, v12, v6, v7, v8, v9, v10, v47, v53, (<unsigned char>1), v54, v15, v16, v14))
cdef double method27(v0, v1, v2, US0 v3, US0 v4, Heap0 v5, numpy.ndarray[signed long,ndim=1] v6, US3 v7, double v8, UH0 v9, double v10, UH0 v11, double v12):
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
        v17 = method28(v5, v3, v16, v15, v4, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = US1_0()
            v20 = Closure5(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v13, v3, v16, v15, v4, v14)
            return v2(Tuple0(v17, v8, v4, v14, v15, v3, v16, v15, v19, (<unsigned char>0), v20, v9, v10, v12))
        else:
            v22 = US1_0()
            v23 = Closure12(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v13, v3, v16, v15, v4, v14)
            return v0(Tuple0(v17, v8, v4, v14, v15, v3, v16, v15, v22, (<unsigned char>1), v23, v11, v12, v10))
    elif v7 == 1: # fold
        raise Exception("impossible")
    elif v7 == 2: # raise
        v28 = (<signed long>1)
        v29 = (<unsigned char>1)
        v30 = (<signed long>1)
        v31 = (<unsigned char>0)
        v32 = (<signed long>3)
        v33 = method33(v5, v3, v31, v32, v4, v29, v30, v28)
        v34 = v29 == (<unsigned char>0)
        if v34:
            v35 = US1_0()
            v36 = Closure10(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v28, v3, v31, v32, v4, v29, v30)
            return v2(Tuple0(v33, v8, v4, v29, v30, v3, v31, v32, v35, (<unsigned char>0), v36, v9, v10, v12))
        else:
            v38 = US1_0()
            v39 = Closure11(v11, v12, v9, v10, v8, v0, v1, v2, v5, v6, v28, v3, v31, v32, v4, v29, v30)
            return v0(Tuple0(v33, v8, v4, v29, v30, v3, v31, v32, v38, (<unsigned char>1), v39, v11, v12, v10))
cdef double method26(v0, v1, v2, Heap0 v3, US0 v4, US0 v5, numpy.ndarray[signed long,ndim=1] v6, double v7, UH0 v8, double v9, UH0 v10, double v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef US1 v13
    cdef object v14
    v12 = v3.v2
    v13 = US1_0()
    v14 = Closure4(v10, v11, v8, v9, v7, v0, v1, v2, v4, v5, v3, v6)
    return v2(Tuple0(v12, v7, v4, (<unsigned char>0), (<signed long>1), v5, (<unsigned char>1), (<signed long>1), v13, (<unsigned char>0), v14, v8, v9, v11))
cdef double method25(numpy.ndarray[signed long,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, double v6, UH0 v7, double v8, UH0 v9, double v10, unsigned long long v11, double v12):
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
        method23(v18, v11, v0, v19, v20)
        v21 = <double>v13
        v22 = (<double>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v6
        v25 = US2_1(v17)
        v26 = UH0_0(v25, v9)
        del v25
        v27 = method26(v1, v2, v3, v4, v5, v17, v19, v24, v7, v8, v26, v10)
        del v19; del v26
        v28 = v11 + (<unsigned long long>1)
        v29 = v12 + v27
        return method25(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v28, v29)
    else:
        v31 = v12 * v15
        return v31
cdef double method24(v0, v1, v2, Heap0 v3, US0 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, UH0 v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    v11 = (<unsigned long long>0)
    v12 = (<double>0.000000)
    return method25(v5, v0, v1, v2, v3, v4, v6, v7, v8, v9, v10, v11, v12)
cdef double method22(numpy.ndarray[signed long,ndim=1] v0, v1, v2, v3, Heap0 v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
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
        method23(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = (<double>1.000000) / v19
        v21 = libc.math.log(v20)
        v22 = US2_1(v15)
        v23 = UH0_0(v22, v5)
        del v22
        v24 = method24(v1, v2, v3, v4, v15, v17, v21, v23, v6, v7, v8)
        del v17; del v23
        v25 = v9 + (<unsigned long long>1)
        v26 = v10 + v24
        return method22(v0, v1, v2, v3, v4, v5, v6, v7, v8, v25, v26)
    else:
        v28 = v10 * v13
        return v28
cdef double method21(v0, v1, v2):
    cdef US3 v3
    cdef US3 v4
    cdef numpy.ndarray[signed long,ndim=1] v5
    cdef US3 v6
    cdef US3 v7
    cdef US3 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef US3 v10
    cdef US3 v11
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef US3 v13
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef Heap0 v15
    cdef US0 v16
    cdef US0 v17
    cdef US0 v18
    cdef US0 v19
    cdef US0 v20
    cdef US0 v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef UH0 v23
    cdef double v24
    cdef UH0 v25
    cdef double v26
    cdef unsigned long long v27
    cdef double v28
    v3 = 0
    v4 = 2
    v5 = numpy.empty(2,dtype=numpy.int32)
    v5[0] = v3; v5[1] = v4
    v6 = 1
    v7 = 0
    v8 = 2
    v9 = numpy.empty(3,dtype=numpy.int32)
    v9[0] = v6; v9[1] = v7; v9[2] = v8
    v10 = 1
    v11 = 0
    v12 = numpy.empty(2,dtype=numpy.int32)
    v12[0] = v10; v12[1] = v11
    v13 = 0
    v14 = numpy.empty(1,dtype=numpy.int32)
    v14[0] = v13
    v15 = Heap0(v14, v9, v5, v12)
    del v5; del v9; del v12; del v14
    v16 = 1
    v17 = 2
    v18 = 0
    v19 = 1
    v20 = 2
    v21 = 0
    v22 = numpy.empty(6,dtype=numpy.int32)
    v22[0] = v16; v22[1] = v17; v22[2] = v18; v22[3] = v19; v22[4] = v20; v22[5] = v21
    v23 = UH0_1()
    v24 = (<double>0.000000)
    v25 = UH0_1()
    v26 = (<double>0.000000)
    v27 = (<unsigned long long>0)
    v28 = (<double>0.000000)
    return method22(v22, v0, v1, v2, v15, v23, v24, v25, v26, v27, v28)
cdef double method47(v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
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
        v17 = method35(v4)
        v18 = method35(v8)
        v19 = method35(v5)
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
        v1(Tuple3(v12, v64, v65, v66, v67, v68, v69, v71, (<unsigned char>0), v13, v14, v70))
        del v71
        v72 = US1_1(v4)
        v1(Tuple3(v12, v67, v68, v69, v64, v65, v66, v72, (<unsigned char>1), v15, v16, v70))
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
        v1(Tuple3(v12, v83, v84, v85, v86, v87, v88, v90, (<unsigned char>0), v13, v14, v89))
        del v90
        v91 = US1_1(v4)
        v1(Tuple3(v12, v86, v87, v88, v83, v84, v85, v91, (<unsigned char>1), v15, v16, v89))
        del v91
        return v89
    elif v11 == 2: # raise
        v92 = v3 - (<signed long>1)
        v93 = v7 + (<signed long>4)
        v94 = method33(v2, v8, v9, v93, v5, v6, v7, v92)
        v95 = v6 == (<unsigned char>0)
        if v95:
            v96 = US1_1(v4)
            v97 = Closure17(v15, v16, v13, v14, v12, v0, v1, v2, v92, v4, v8, v9, v93, v5, v6, v7)
            return v0(Tuple0(v94, v12, v5, v6, v7, v8, v9, v93, v96, (<unsigned char>0), v97, v13, v14, v16))
        else:
            v99 = US1_1(v4)
            v100 = Closure18(v15, v16, v13, v14, v12, v0, v1, v2, v92, v4, v8, v9, v93, v5, v6, v7)
            return v0(Tuple0(v94, v12, v5, v6, v7, v8, v9, v93, v99, (<unsigned char>1), v100, v15, v16, v14))
cdef double method46(v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
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
        v17 = method33(v2, v6, v7, v8, v3, v4, v5, v16)
        v18 = v4 == (<unsigned char>0)
        if v18:
            v19 = US1_1(v9)
            v20 = Closure17(v14, v15, v12, v13, v11, v0, v1, v2, v16, v9, v6, v7, v8, v3, v4, v5)
            return v0(Tuple0(v17, v11, v3, v4, v5, v6, v7, v8, v19, (<unsigned char>0), v20, v12, v13, v15))
        else:
            v22 = US1_1(v9)
            v23 = Closure18(v14, v15, v12, v13, v11, v0, v1, v2, v16, v9, v6, v7, v8, v3, v4, v5)
            return v0(Tuple0(v17, v11, v3, v4, v5, v6, v7, v8, v22, (<unsigned char>1), v23, v14, v15, v13))
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v28 = (<signed long>1)
        v29 = v5 + (<signed long>4)
        v30 = method33(v2, v6, v7, v29, v3, v4, v5, v28)
        v31 = v4 == (<unsigned char>0)
        if v31:
            v32 = US1_1(v9)
            v33 = Closure17(v14, v15, v12, v13, v11, v0, v1, v2, v28, v9, v6, v7, v29, v3, v4, v5)
            return v0(Tuple0(v30, v11, v3, v4, v5, v6, v7, v29, v32, (<unsigned char>0), v33, v12, v13, v15))
        else:
            v35 = US1_1(v9)
            v36 = Closure18(v14, v15, v12, v13, v11, v0, v1, v2, v28, v9, v6, v7, v29, v3, v4, v5)
            return v0(Tuple0(v30, v11, v3, v4, v5, v6, v7, v29, v35, (<unsigned char>1), v36, v14, v15, v13))
cdef double method45(v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14):
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
        v18 = Closure16(v13, v14, v11, v12, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        return v0(Tuple0(v15, v10, v6, v7, v8, v3, v4, v5, v17, (<unsigned char>0), v18, v11, v12, v14))
    else:
        v20 = US1_1(v9)
        v21 = Closure19(v13, v14, v11, v12, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        return v0(Tuple0(v15, v10, v6, v7, v8, v3, v4, v5, v20, (<unsigned char>1), v21, v13, v14, v12))
cdef double method44(numpy.ndarray[signed long,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, double v10, UH0 v11, double v12, UH0 v13, double v14, unsigned long long v15, double v16):
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
        v30 = method45(v1, v2, v3, v4, v5, v6, v7, v8, v9, v21, v25, v27, v12, v29, v14)
        del v27; del v29
        v31 = v15 + (<unsigned long long>1)
        v32 = v16 + v30
        return method44(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v31, v32)
    else:
        v34 = v16 * v19
        return v34
cdef double method48(v0, v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16):
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
        return method44(v3, v0, v1, v2, v21, v22, v23, v18, v19, v20, v12, v13, v14, v15, v16, v24, v25)
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
        v1(Tuple3(v12, v37, v38, v39, v40, v41, v42, v44, (<unsigned char>0), v13, v14, v43))
        del v44
        v45 = US1_0()
        v1(Tuple3(v12, v40, v41, v42, v37, v38, v39, v45, (<unsigned char>1), v15, v16, v43))
        del v45
        return v43
    elif v11 == 2: # raise
        v46 = v4 - (<signed long>1)
        v47 = v7 + (<signed long>2)
        v48 = method33(v2, v8, v9, v47, v5, v6, v7, v46)
        v49 = v6 == (<unsigned char>0)
        if v49:
            v50 = US1_0()
            v51 = Closure20(v15, v16, v13, v14, v12, v0, v1, v2, v3, v46, v8, v9, v47, v5, v6, v7)
            return v0(Tuple0(v48, v12, v5, v6, v7, v8, v9, v47, v50, (<unsigned char>0), v51, v13, v14, v16))
        else:
            v53 = US1_0()
            v54 = Closure21(v15, v16, v13, v14, v12, v0, v1, v2, v3, v46, v8, v9, v47, v5, v6, v7)
            return v0(Tuple0(v48, v12, v5, v6, v7, v8, v9, v47, v53, (<unsigned char>1), v54, v15, v16, v14))
cdef double method43(v0, v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
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
        return method44(v3, v0, v1, v2, v20, v21, v22, v17, v18, v19, v11, v12, v13, v14, v15, v23, v24)
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
        v1(Tuple3(v11, v36, v37, v38, v39, v40, v41, v43, (<unsigned char>0), v12, v13, v42))
        del v43
        v44 = US1_0()
        v1(Tuple3(v11, v39, v40, v41, v36, v37, v38, v44, (<unsigned char>1), v14, v15, v42))
        del v44
        return v42
    elif v10 == 2: # raise
        v45 = v4 - (<signed long>1)
        v46 = v7 + (<signed long>2)
        v47 = method33(v2, v8, v9, v46, v5, v6, v7, v45)
        v48 = v6 == (<unsigned char>0)
        if v48:
            v49 = US1_0()
            v50 = Closure20(v14, v15, v12, v13, v11, v0, v1, v2, v3, v45, v8, v9, v46, v5, v6, v7)
            return v0(Tuple0(v47, v11, v5, v6, v7, v8, v9, v46, v49, (<unsigned char>0), v50, v12, v13, v15))
        else:
            v52 = US1_0()
            v53 = Closure21(v14, v15, v12, v13, v11, v0, v1, v2, v3, v45, v8, v9, v46, v5, v6, v7)
            return v0(Tuple0(v47, v11, v5, v6, v7, v8, v9, v46, v52, (<unsigned char>1), v53, v14, v15, v13))
cdef double method42(v0, v1, US0 v2, US0 v3, Heap0 v4, numpy.ndarray[signed long,ndim=1] v5, US3 v6, double v7, UH0 v8, double v9, UH0 v10, double v11):
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
        v16 = method28(v4, v2, v15, v14, v3, v13, v12)
        v17 = v13 == (<unsigned char>0)
        if v17:
            v18 = US1_0()
            v19 = Closure15(v10, v11, v8, v9, v7, v0, v1, v4, v5, v12, v2, v15, v14, v3, v13)
            return v0(Tuple0(v16, v7, v3, v13, v14, v2, v15, v14, v18, (<unsigned char>0), v19, v8, v9, v11))
        else:
            v21 = US1_0()
            v22 = Closure22(v10, v11, v8, v9, v7, v0, v1, v4, v5, v12, v2, v15, v14, v3, v13)
            return v0(Tuple0(v16, v7, v3, v13, v14, v2, v15, v14, v21, (<unsigned char>1), v22, v10, v11, v9))
    elif v6 == 1: # fold
        raise Exception("impossible")
    elif v6 == 2: # raise
        v27 = (<signed long>1)
        v28 = (<unsigned char>1)
        v29 = (<signed long>1)
        v30 = (<unsigned char>0)
        v31 = (<signed long>3)
        v32 = method33(v4, v2, v30, v31, v3, v28, v29, v27)
        v33 = v28 == (<unsigned char>0)
        if v33:
            v34 = US1_0()
            v35 = Closure20(v10, v11, v8, v9, v7, v0, v1, v4, v5, v27, v2, v30, v31, v3, v28, v29)
            return v0(Tuple0(v32, v7, v3, v28, v29, v2, v30, v31, v34, (<unsigned char>0), v35, v8, v9, v11))
        else:
            v37 = US1_0()
            v38 = Closure21(v10, v11, v8, v9, v7, v0, v1, v4, v5, v27, v2, v30, v31, v3, v28, v29)
            return v0(Tuple0(v32, v7, v3, v28, v29, v2, v30, v31, v37, (<unsigned char>1), v38, v10, v11, v9))
cdef double method41(v0, v1, Heap0 v2, US0 v3, US0 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, UH0 v9, double v10):
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef US1 v12
    cdef object v13
    v11 = v2.v2
    v12 = US1_0()
    v13 = Closure14(v9, v10, v7, v8, v6, v0, v1, v3, v4, v2, v5)
    return v0(Tuple0(v11, v6, v3, (<unsigned char>0), (<signed long>1), v4, (<unsigned char>1), (<signed long>1), v12, (<unsigned char>0), v13, v7, v8, v10))
cdef double method40(numpy.ndarray[signed long,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, double v5, UH0 v6, double v7, UH0 v8, double v9, unsigned long long v10, double v11):
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
        method23(v17, v10, v0, v18, v19)
        v20 = <double>v12
        v21 = (<double>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v5
        v24 = US2_1(v16)
        v25 = UH0_0(v24, v8)
        del v24
        v26 = method41(v1, v2, v3, v4, v16, v18, v23, v6, v7, v25, v9)
        del v18; del v25
        v27 = v10 + (<unsigned long long>1)
        v28 = v11 + v26
        return method40(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v27, v28)
    else:
        v30 = v11 * v14
        return v30
cdef double method39(v0, v1, Heap0 v2, US0 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9):
    cdef unsigned long long v10
    cdef double v11
    v10 = (<unsigned long long>0)
    v11 = (<double>0.000000)
    return method40(v4, v0, v1, v2, v3, v5, v6, v7, v8, v9, v10, v11)
cdef double method38(numpy.ndarray[signed long,ndim=1] v0, v1, v2, Heap0 v3, UH0 v4, double v5, UH0 v6, double v7, unsigned long long v8, double v9):
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
        method23(v15, v8, v0, v16, v17)
        v18 = <double>v10
        v19 = (<double>1.000000) / v18
        v20 = libc.math.log(v19)
        v21 = US2_1(v14)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = method39(v1, v2, v3, v14, v16, v20, v22, v5, v6, v7)
        del v16; del v22
        v24 = v8 + (<unsigned long long>1)
        v25 = v9 + v23
        return method38(v0, v1, v2, v3, v4, v5, v6, v7, v24, v25)
    else:
        v27 = v9 * v12
        return v27
cdef double method37(v0, v1):
    cdef US3 v2
    cdef US3 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef US3 v5
    cdef US3 v6
    cdef US3 v7
    cdef numpy.ndarray[signed long,ndim=1] v8
    cdef US3 v9
    cdef US3 v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef US3 v12
    cdef numpy.ndarray[signed long,ndim=1] v13
    cdef Heap0 v14
    cdef US0 v15
    cdef US0 v16
    cdef US0 v17
    cdef US0 v18
    cdef US0 v19
    cdef US0 v20
    cdef numpy.ndarray[signed long,ndim=1] v21
    cdef UH0 v22
    cdef double v23
    cdef UH0 v24
    cdef double v25
    cdef unsigned long long v26
    cdef double v27
    v2 = 0
    v3 = 2
    v4 = numpy.empty(2,dtype=numpy.int32)
    v4[0] = v2; v4[1] = v3
    v5 = 1
    v6 = 0
    v7 = 2
    v8 = numpy.empty(3,dtype=numpy.int32)
    v8[0] = v5; v8[1] = v6; v8[2] = v7
    v9 = 1
    v10 = 0
    v11 = numpy.empty(2,dtype=numpy.int32)
    v11[0] = v9; v11[1] = v10
    v12 = 0
    v13 = numpy.empty(1,dtype=numpy.int32)
    v13[0] = v12
    v14 = Heap0(v13, v8, v4, v11)
    del v4; del v8; del v11; del v13
    v15 = 1
    v16 = 2
    v17 = 0
    v18 = 1
    v19 = 2
    v20 = 0
    v21 = numpy.empty(6,dtype=numpy.int32)
    v21[0] = v15; v21[1] = v16; v21[2] = v17; v21[3] = v18; v21[4] = v19; v21[5] = v20
    v22 = UH0_1()
    v23 = (<double>0.000000)
    v24 = UH0_1()
    v25 = (<double>0.000000)
    v26 = (<unsigned long long>0)
    v27 = (<double>0.000000)
    return method38(v21, v0, v1, v14, v22, v23, v24, v25, v26, v27)
cdef unsigned long long method52(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut1 v9
    cdef Tuple1 tmp2
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        tmp2 = v2[v3]
        v7, v8, v9 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        v10 = v4 - (<unsigned long long>1)
        v1[v10] = Tuple4(v8, v9)
        del v8; del v9
        return method52(v0, v1, v2, v6, v10)
    else:
        return v4
cdef unsigned long long method51(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        v7 = v2[v3]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        v10 = method52(v8, v1, v7, v9, v4)
        del v7
        return method51(v0, v1, v2, v6, v10)
    else:
        return v4
cdef unsigned long long method50(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, Mut0 v2):
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v4 = v2.v1
    v5 = len(v4)
    v6 = (<unsigned long long>0)
    return method51(v5, v0, v4, v6, v1)
cdef numpy.ndarray[object,ndim=1] method49(Mut0 v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    v1 = v0.v2
    v2 = numpy.empty(v1,dtype=object)
    v3 = method50(v2, v1, v0)
    return v2
cdef void method54(list v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef str v8
    cdef US3 v4
    cdef US0 v6
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1
        method54(v0, v3)
        del v3
        if v2.tag == 0: # action_
            v4 = (<US2_0>v2).v0
            if v4 == 0: # call
                v8 = "C"
            elif v4 == 1: # fold
                v8 = "F"
            elif v4 == 2: # raise
                v8 = "R"
        elif v2.tag == 1: # observation_
            v6 = (<US2_1>v2).v0
            if v6 == 0: # jack
                v8 = "[color=ff0000]J[/color]"
            elif v6 == 1: # king
                v8 = "[color=ff0000]K[/color]"
            elif v6 == 2: # queen
                v8 = "[color=ff0000]Q[/color]"
        del v2
        v0.append(v8)
    elif v1.tag == 1: # nil
        pass
cdef void method55(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef str v9
    cdef str v10
    cdef str v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = v2[v4]
        if v7 == 0: # call
            v9 = "C"
        elif v7 == 1: # fold
            v9 = "F"
        elif v7 == 2: # raise
            v9 = "R"
        v10 = '{:.5f}'.format(v8)
        v11 = f'{v9}: {v10}'
        del v9; del v10
        v3[v4] = v11
        del v11
        method55(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method56(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef str v9
    cdef str v10
    cdef str v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = v2[v4]
        if v7 == 0: # call
            v9 = "C"
        elif v7 == 1: # fold
            v9 = "F"
        elif v7 == 2: # raise
            v9 = "R"
        v10 = '{:.5f}'.format(v8)
        v11 = f'{v9}: {v10}'
        del v9; del v10
        v3[v4] = v11
        del v11
        method56(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method53(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef UH0 v6
    cdef Mut1 v7
    cdef Tuple4 tmp3
    cdef list v8
    cdef str v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef list v16
    cdef unsigned long long v17
    cdef str v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef bint v23
    cdef bint v24
    cdef list v25
    cdef unsigned long long v26
    cdef str v27
    cdef object v28
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        tmp3 = v1[v3]
        v6, v7 = tmp3.v0, tmp3.v1
        del tmp3
        v8 = [None]*(<unsigned long long>0)
        method54(v8, v6)
        del v6
        v9 = "".join(v8)
        del v8
        v10 = v7.v0
        v11 = v7.v1
        v12 = len(v10)
        v13 = len(v11)
        v14 = v12 == v13
        v15 = v14 != 1
        if v15:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v16 = [None]*v12
        v17 = (<unsigned long long>0)
        method55(v12, v10, v11, v16, v17)
        del v10; del v11
        v18 = "\n".join(v16)
        del v16
        v19 = v7.v0
        v20 = v7.v2
        del v7
        v21 = len(v19)
        v22 = len(v20)
        v23 = v21 == v22
        v24 = v23 != 1
        if v24:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v25 = [None]*v21
        v26 = (<unsigned long long>0)
        method56(v21, v19, v20, v25, v26)
        del v19; del v20
        v27 = "\n".join(v25)
        del v25
        v28 = {'avg_policy': v18, 'regret': v27, 'trace': v9}
        del v9; del v18; del v27
        v2[v3] = v28
        del v28
        method53(v0, v1, v2, v5)
    else:
        pass
cdef str method67(US0 v0):
    if v0 == 0: # jack
        return "Jack"
    elif v0 == 1: # king
        return "King"
    elif v0 == 2: # queen
        return "Queen"
cdef bint method66(list v0, UH0 v1, bint v2):
    cdef US2 v3
    cdef UH0 v4
    cdef bint v5
    cdef US3 v6
    cdef str v7
    cdef str v8
    cdef str v9
    cdef US0 v11
    cdef str v12
    cdef str v13
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1
        v5 = method66(v0, v4, v2)
        del v4
        if v3.tag == 0: # action_
            v6 = (<US2_0>v3).v0
            if v5:
                v7 = "One"
            else:
                v7 = "Two"
            if v6 == 0: # call
                v8 = "calls"
            elif v6 == 1: # fold
                v8 = "folds"
            elif v6 == 2: # raise
                v8 = "raises"
            v9 = f'Player {v7} {v8}.'
            del v7; del v8
            v0.append(v9)
            del v9
            return v5 == 0
        elif v3.tag == 1: # observation_
            v11 = (<US2_1>v3).v0
            v12 = method67(v11)
            v13 = f'Observed {v12}.'
            del v12
            v0.append(v13)
            del v13
            return 1
    elif v1.tag == 1: # nil
        return v2
cdef str method65(unsigned char v0, US4 v1, UH0 v2):
    cdef list v3
    cdef bint v4
    cdef bint v5
    cdef double v6
    cdef bint v7
    cdef str v8
    cdef double v10
    cdef bint v11
    cdef str v18
    cdef bint v13
    cdef double v15
    v3 = [None]*(<unsigned long long>0)
    v4 = 1
    v5 = method66(v3, v2, v4)
    if v1.tag == 0: # none
        pass
    elif v1.tag == 1: # some_
        v6 = (<US4_1>v1).v0
        v7 = v0 == (<unsigned char>0)
        if v7:
            v8 = "One"
        else:
            v8 = "Two"
        if v7:
            v10 = v6
        else:
            v10 = -v6
        v11 = (<double>0.000000) < v10
        if v11:
            v18 = f"Player {v8} wins {v10} chips.\n"
        else:
            v13 = (<double>0.000000) == v10
            if v13:
                v18 = f"Player {v8} draws.\n"
            else:
                v15 = -v10
                v18 = f"Player {v8} loses {v15} chips.\n"
        del v8
        v3.append(v18)
        del v18
    return "\n".join(v3)
cdef void method68(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, v2, Mut2 v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef object v8
    cdef object v9
    cdef object v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        if v7 == 0: # call
            v8 = Closure28(v2, v7)
            v3.v0 = v8
            del v8
        elif v7 == 1: # fold
            v9 = Closure29(v2, v7)
            v3.v1 = v9
            del v9
        elif v7 == 2: # raise
            v10 = Closure30(v2, v7)
            v3.v2 = v10
            del v10
        method68(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method64(v0, v1, numpy.ndarray[signed long,ndim=1] v2, UH0 v3, US4 v4, US1 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11):
    cdef str v12
    cdef object v13
    cdef object v14
    cdef object v15
    cdef Mut2 v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef object v22
    cdef str v23
    cdef str v24
    cdef str v27
    cdef US0 v25
    cdef object v28
    cdef object v29
    v12 = method65(v10, v4, v3)
    v13 = False
    v14 = False
    v15 = False
    v16 = Mut2(v14, v13, v15)
    del v13; del v14; del v15
    v17 = len(v2)
    v18 = (<unsigned long long>0)
    method68(v17, v2, v1, v16, v18)
    v19, v20, v21 = v16.v0, v16.v1, v16.v2
    del v16
    v22 = {'call': v19, 'fold': v20, 'raise': v21}
    del v19; del v20; del v21
    if v9 == 0: # jack
        v23 = 'J'
    elif v9 == 1: # king
        v23 = 'K'
    elif v9 == 2: # queen
        v23 = 'Q'
    if v6 == 0: # jack
        v24 = 'J'
    elif v6 == 1: # king
        v24 = 'K'
    elif v6 == 2: # queen
        v24 = 'Q'
    if v5.tag == 0: # none
        v27 = ' '
    elif v5.tag == 1: # some_
        v25 = (<US1_1>v5).v0
        if v25 == 0: # jack
            v27 = 'J'
        elif v25 == 1: # king
            v27 = 'K'
        elif v25 == 2: # queen
            v27 = 'Q'
    v28 = {'community_card': v27, 'my_card': v23, 'my_pot': v11, 'op_card': v24, 'op_pot': v8}
    del v23; del v24; del v27
    v29 = {'actions': v22, 'table_data': v28, 'trace': v12}
    del v12; del v22; del v28
    v0.data = v29
cdef void method63(v0, Mut0 v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16, v17):
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
    cdef numpy.ndarray[signed long,ndim=1] v72
    cdef US1 v73
    cdef US4 v74
    cdef object v75
    cdef bint v76
    cdef signed long v78
    cdef bint v79
    cdef signed long v81
    cdef signed long v82
    cdef signed long v84
    cdef signed long v85
    cdef US0 v86
    cdef unsigned char v87
    cdef signed long v88
    cdef US0 v89
    cdef unsigned char v90
    cdef signed long v91
    cdef double v92
    cdef numpy.ndarray[signed long,ndim=1] v93
    cdef US1 v94
    cdef US4 v95
    cdef object v96
    cdef signed long v97
    cdef signed long v98
    cdef numpy.ndarray[signed long,ndim=1] v99
    cdef bint v100
    cdef unsigned long long v101
    cdef Mut1 v102
    cdef numpy.ndarray[double,ndim=1] v103
    cdef numpy.ndarray[double,ndim=1] v104
    cdef unsigned long long v105
    cdef double v106
    cdef US3 v107
    cdef double v108
    cdef double v109
    cdef US2 v110
    cdef UH0 v111
    cdef US2 v112
    cdef UH0 v113
    cdef US1 v114
    cdef US4 v115
    cdef object v116
    if v11 == 0: # call
        v18 = method35(v4)
        v19 = method35(v8)
        v20 = method35(v5)
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
            v52, v53 = v9, v7
        else:
            v49 = v47 == (<signed long>-1)
            if v49:
                v52, v53 = v6, v7
            else:
                v52, v53 = v9, (<signed long>0)
        v54 = v52 == (<unsigned char>0)
        if v54:
            v56 = v53
        else:
            v56 = -v53
        v57 = v9 == (<unsigned char>0)
        if v57:
            v59 = v56
        else:
            v59 = -v56
        v60 = v59 + v7
        v61 = v6 == (<unsigned char>0)
        if v61:
            v63 = v56
        else:
            v63 = -v56
        v64 = v63 + v7
        if v57:
            v65, v66, v67, v68, v69, v70 = v8, v9, v60, v5, v6, v64
        else:
            v65, v66, v67, v68, v69, v70 = v5, v6, v64, v8, v9, v60
        v71 = <double>v56
        v72 = numpy.empty(0,dtype=numpy.int32)
        
        v73 = US1_1(v4)
        v74 = US4_1(v71)
        v75 = Closure27()
        method64(v0, v75, v72, v15, v74, v73, v65, v66, v67, v68, v69, v70)
        del v72; del v73; del v74; del v75
        v17(v71)
    elif v11 == 1: # fold
        v76 = v6 == (<unsigned char>0)
        if v76:
            v78 = v10
        else:
            v78 = -v10
        v79 = v9 == (<unsigned char>0)
        if v79:
            v81 = v78
        else:
            v81 = -v78
        v82 = v81 + v10
        if v76:
            v84 = v78
        else:
            v84 = -v78
        v85 = v84 + v7
        if v79:
            v86, v87, v88, v89, v90, v91 = v8, v9, v82, v5, v6, v85
        else:
            v86, v87, v88, v89, v90, v91 = v5, v6, v85, v8, v9, v82
        v92 = <double>v78
        v93 = numpy.empty(0,dtype=numpy.int32)
        
        v94 = US1_1(v4)
        v95 = US4_1(v92)
        v96 = Closure27()
        method64(v0, v96, v93, v15, v95, v94, v86, v87, v88, v89, v90, v91)
        del v93; del v94; del v95; del v96
        v17(v92)
    elif v11 == 2: # raise
        v97 = v3 - (<signed long>1)
        v98 = v7 + (<signed long>4)
        v99 = method33(v2, v8, v9, v98, v5, v6, v7, v97)
        v100 = v6 == (<unsigned char>0)
        if v100:
            v101 = len(v99)
            v102 = method2(v1, v99, v13)
            v103 = v102.v1
            del v102
            v104 = method11(v103)
            del v103
            v105 = numpy.random.choice(v101,p=v104)
            v106 = v104[v105]
            del v104
            v107 = v99[v105]
            del v99
            v108 = libc.math.log(v106)
            v109 = v108 + v14
            v110 = US2_0(v107)
            v111 = UH0_0(v110, v13)
            del v110
            v112 = US2_0(v107)
            v113 = UH0_0(v112, v15)
            del v112
            method63(v0, v1, v2, v97, v4, v8, v9, v98, v5, v6, v7, v107, v12, v111, v109, v113, v16, v17)
        else:
            v114 = US1_1(v4)
            v115 = US4_0()
            v116 = Closure31(v17, v15, v16, v13, v14, v12, v0, v1, v2, v97, v4, v8, v9, v98, v5, v6, v7)
            method64(v0, v116, v99, v15, v115, v114, v8, v9, v98, v5, v6, v7)
cdef void method62(v0, Mut0 v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15, v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef unsigned long long v20
    cdef Mut1 v21
    cdef numpy.ndarray[double,ndim=1] v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef unsigned long long v24
    cdef double v25
    cdef US3 v26
    cdef double v27
    cdef double v28
    cdef US2 v29
    cdef UH0 v30
    cdef US2 v31
    cdef UH0 v32
    cdef US1 v33
    cdef US4 v34
    cdef object v35
    cdef object v36
    cdef signed long v37
    cdef signed long v38
    cdef numpy.ndarray[signed long,ndim=1] v39
    cdef bint v40
    cdef unsigned long long v41
    cdef Mut1 v42
    cdef numpy.ndarray[double,ndim=1] v43
    cdef numpy.ndarray[double,ndim=1] v44
    cdef unsigned long long v45
    cdef double v46
    cdef US3 v47
    cdef double v48
    cdef double v49
    cdef US2 v50
    cdef UH0 v51
    cdef US2 v52
    cdef UH0 v53
    cdef US1 v54
    cdef US4 v55
    cdef object v56
    if v10 == 0: # call
        v17 = (<signed long>2)
        v18 = method33(v2, v6, v7, v8, v3, v4, v5, v17)
        v19 = v4 == (<unsigned char>0)
        if v19:
            v20 = len(v18)
            v21 = method2(v1, v18, v12)
            v22 = v21.v1
            del v21
            v23 = method11(v22)
            del v22
            v24 = numpy.random.choice(v20,p=v23)
            v25 = v23[v24]
            del v23
            v26 = v18[v24]
            del v18
            v27 = libc.math.log(v25)
            v28 = v27 + v13
            v29 = US2_0(v26)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v26)
            v32 = UH0_0(v31, v14)
            del v31
            method63(v0, v1, v2, v17, v9, v6, v7, v8, v3, v4, v5, v26, v11, v30, v28, v32, v15, v16)
        else:
            v33 = US1_1(v9)
            v34 = US4_0()
            v35 = Closure31(v16, v14, v15, v12, v13, v11, v0, v1, v2, v17, v9, v6, v7, v8, v3, v4, v5)
            method64(v0, v35, v18, v14, v34, v33, v6, v7, v8, v3, v4, v5)
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v37 = (<signed long>1)
        v38 = v5 + (<signed long>4)
        v39 = method33(v2, v6, v7, v38, v3, v4, v5, v37)
        v40 = v4 == (<unsigned char>0)
        if v40:
            v41 = len(v39)
            v42 = method2(v1, v39, v12)
            v43 = v42.v1
            del v42
            v44 = method11(v43)
            del v43
            v45 = numpy.random.choice(v41,p=v44)
            v46 = v44[v45]
            del v44
            v47 = v39[v45]
            del v39
            v48 = libc.math.log(v46)
            v49 = v48 + v13
            v50 = US2_0(v47)
            v51 = UH0_0(v50, v12)
            del v50
            v52 = US2_0(v47)
            v53 = UH0_0(v52, v14)
            del v52
            method63(v0, v1, v2, v37, v9, v6, v7, v38, v3, v4, v5, v47, v11, v51, v49, v53, v15, v16)
        else:
            v54 = US1_1(v9)
            v55 = US4_0()
            v56 = Closure31(v16, v14, v15, v12, v13, v11, v0, v1, v2, v37, v9, v6, v7, v38, v3, v4, v5)
            method64(v0, v56, v39, v14, v55, v54, v6, v7, v38, v3, v4, v5)
cdef void method61(v0, Mut0 v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14, v15):
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef unsigned long long v18
    cdef Mut1 v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef numpy.ndarray[double,ndim=1] v21
    cdef unsigned long long v22
    cdef double v23
    cdef US3 v24
    cdef double v25
    cdef double v26
    cdef US2 v27
    cdef UH0 v28
    cdef US2 v29
    cdef UH0 v30
    cdef US1 v31
    cdef US4 v32
    cdef object v33
    v16 = v2.v2
    v17 = v7 == (<unsigned char>0)
    if v17:
        v18 = len(v16)
        v19 = method2(v1, v16, v11)
        v20 = v19.v1
        del v19
        v21 = method11(v20)
        del v20
        v22 = numpy.random.choice(v18,p=v21)
        v23 = v21[v22]
        del v21
        v24 = v16[v22]
        del v16
        v25 = libc.math.log(v23)
        v26 = v25 + v12
        v27 = US2_0(v24)
        v28 = UH0_0(v27, v11)
        del v27
        v29 = US2_0(v24)
        v30 = UH0_0(v29, v13)
        del v29
        method62(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v24, v10, v28, v26, v30, v14, v15)
    else:
        v31 = US1_1(v9)
        v32 = US4_0()
        v33 = Closure32(v15, v13, v14, v11, v12, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        method64(v0, v33, v16, v13, v32, v31, v3, v4, v5, v6, v7, v8)
cdef void method69(v0, Mut0 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, UH0 v15, double v16, v17):
    cdef bint v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US0 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef US0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef bint v36
    cdef signed long v38
    cdef bint v39
    cdef signed long v41
    cdef signed long v42
    cdef signed long v44
    cdef signed long v45
    cdef US0 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef US0 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef double v52
    cdef numpy.ndarray[signed long,ndim=1] v53
    cdef US1 v54
    cdef US4 v55
    cdef object v56
    cdef signed long v57
    cdef signed long v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef bint v60
    cdef unsigned long long v61
    cdef Mut1 v62
    cdef numpy.ndarray[double,ndim=1] v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef unsigned long long v65
    cdef double v66
    cdef US3 v67
    cdef double v68
    cdef double v69
    cdef US2 v70
    cdef UH0 v71
    cdef US2 v72
    cdef UH0 v73
    cdef US1 v74
    cdef US4 v75
    cdef object v76
    if v11 == 0: # call
        v18 = v9 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v8, v9, v7, v5, v6, v7
        else:
            v19, v20, v21, v22, v23, v24 = v5, v6, v7, v8, v9, v7
        v25 = len(v3)
        v26 = numpy.random.randint(0,v25)
        v27 = v3[v26]
        v28 = <double>v25
        v29 = (<double>1.000000) / v28
        v30 = libc.math.log(v29)
        v31 = v30 + v12
        v32 = US2_1(v27)
        v33 = UH0_0(v32, v13)
        del v32
        v34 = US2_1(v27)
        v35 = UH0_0(v34, v15)
        del v34
        method61(v0, v1, v2, v22, v23, v24, v19, v20, v21, v27, v31, v33, v14, v35, v16, v17)
    elif v11 == 1: # fold
        v36 = v6 == (<unsigned char>0)
        if v36:
            v38 = v10
        else:
            v38 = -v10
        v39 = v9 == (<unsigned char>0)
        if v39:
            v41 = v38
        else:
            v41 = -v38
        v42 = v41 + v10
        if v36:
            v44 = v38
        else:
            v44 = -v38
        v45 = v44 + v7
        if v39:
            v46, v47, v48, v49, v50, v51 = v8, v9, v42, v5, v6, v45
        else:
            v46, v47, v48, v49, v50, v51 = v5, v6, v45, v8, v9, v42
        v52 = <double>v38
        v53 = numpy.empty(0,dtype=numpy.int32)
        
        v54 = US1_0()
        v55 = US4_1(v52)
        v56 = Closure27()
        method64(v0, v56, v53, v15, v55, v54, v46, v47, v48, v49, v50, v51)
        del v53; del v54; del v55; del v56
        v17(v52)
    elif v11 == 2: # raise
        v57 = v4 - (<signed long>1)
        v58 = v7 + (<signed long>2)
        v59 = method33(v2, v8, v9, v58, v5, v6, v7, v57)
        v60 = v6 == (<unsigned char>0)
        if v60:
            v61 = len(v59)
            v62 = method2(v1, v59, v13)
            v63 = v62.v1
            del v62
            v64 = method11(v63)
            del v63
            v65 = numpy.random.choice(v61,p=v64)
            v66 = v64[v65]
            del v64
            v67 = v59[v65]
            del v59
            v68 = libc.math.log(v66)
            v69 = v68 + v14
            v70 = US2_0(v67)
            v71 = UH0_0(v70, v13)
            del v70
            v72 = US2_0(v67)
            v73 = UH0_0(v72, v15)
            del v72
            method69(v0, v1, v2, v3, v57, v8, v9, v58, v5, v6, v7, v67, v12, v71, v69, v73, v16, v17)
        else:
            v74 = US1_0()
            v75 = US4_0()
            v76 = Closure33(v17, v15, v16, v13, v14, v12, v0, v1, v2, v3, v57, v8, v9, v58, v5, v6, v7)
            method64(v0, v76, v59, v15, v75, v74, v8, v9, v58, v5, v6, v7)
cdef void method60(v0, Mut0 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15, v16):
    cdef bint v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef US0 v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef bint v35
    cdef signed long v37
    cdef bint v38
    cdef signed long v40
    cdef signed long v41
    cdef signed long v43
    cdef signed long v44
    cdef US0 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US0 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef double v51
    cdef numpy.ndarray[signed long,ndim=1] v52
    cdef US1 v53
    cdef US4 v54
    cdef object v55
    cdef signed long v56
    cdef signed long v57
    cdef numpy.ndarray[signed long,ndim=1] v58
    cdef bint v59
    cdef unsigned long long v60
    cdef Mut1 v61
    cdef numpy.ndarray[double,ndim=1] v62
    cdef numpy.ndarray[double,ndim=1] v63
    cdef unsigned long long v64
    cdef double v65
    cdef US3 v66
    cdef double v67
    cdef double v68
    cdef US2 v69
    cdef UH0 v70
    cdef US2 v71
    cdef UH0 v72
    cdef US1 v73
    cdef US4 v74
    cdef object v75
    if v10 == 0: # call
        v17 = v9 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v8, v9, v7, v5, v6, v7
        else:
            v18, v19, v20, v21, v22, v23 = v5, v6, v7, v8, v9, v7
        v24 = len(v3)
        v25 = numpy.random.randint(0,v24)
        v26 = v3[v25]
        v27 = <double>v24
        v28 = (<double>1.000000) / v27
        v29 = libc.math.log(v28)
        v30 = v29 + v11
        v31 = US2_1(v26)
        v32 = UH0_0(v31, v12)
        del v31
        v33 = US2_1(v26)
        v34 = UH0_0(v33, v14)
        del v33
        method61(v0, v1, v2, v21, v22, v23, v18, v19, v20, v26, v30, v32, v13, v34, v15, v16)
    elif v10 == 1: # fold
        v35 = v6 == (<unsigned char>0)
        if v35:
            v37 = v7
        else:
            v37 = -v7
        v38 = v9 == (<unsigned char>0)
        if v38:
            v40 = v37
        else:
            v40 = -v37
        v41 = v40 + v7
        if v35:
            v43 = v37
        else:
            v43 = -v37
        v44 = v43 + v7
        if v38:
            v45, v46, v47, v48, v49, v50 = v8, v9, v41, v5, v6, v44
        else:
            v45, v46, v47, v48, v49, v50 = v5, v6, v44, v8, v9, v41
        v51 = <double>v37
        v52 = numpy.empty(0,dtype=numpy.int32)
        
        v53 = US1_0()
        v54 = US4_1(v51)
        v55 = Closure27()
        method64(v0, v55, v52, v14, v54, v53, v45, v46, v47, v48, v49, v50)
        del v52; del v53; del v54; del v55
        v16(v51)
    elif v10 == 2: # raise
        v56 = v4 - (<signed long>1)
        v57 = v7 + (<signed long>2)
        v58 = method33(v2, v8, v9, v57, v5, v6, v7, v56)
        v59 = v6 == (<unsigned char>0)
        if v59:
            v60 = len(v58)
            v61 = method2(v1, v58, v12)
            v62 = v61.v1
            del v61
            v63 = method11(v62)
            del v62
            v64 = numpy.random.choice(v60,p=v63)
            v65 = v63[v64]
            del v63
            v66 = v58[v64]
            del v58
            v67 = libc.math.log(v65)
            v68 = v67 + v13
            v69 = US2_0(v66)
            v70 = UH0_0(v69, v12)
            del v69
            v71 = US2_0(v66)
            v72 = UH0_0(v71, v14)
            del v71
            method69(v0, v1, v2, v3, v56, v8, v9, v57, v5, v6, v7, v66, v11, v70, v68, v72, v15, v16)
        else:
            v73 = US1_0()
            v74 = US4_0()
            v75 = Closure33(v16, v14, v15, v12, v13, v11, v0, v1, v2, v3, v56, v8, v9, v57, v5, v6, v7)
            method64(v0, v75, v58, v14, v74, v73, v8, v9, v57, v5, v6, v7)
cdef void method70(v0, v1, numpy.ndarray[signed long,ndim=1] v2, UH0 v3, US4 v4, US1 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10):
    cdef str v11
    cdef object v12
    cdef object v13
    cdef object v14
    cdef Mut2 v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef object v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef str v22
    cdef str v23
    cdef str v26
    cdef US0 v24
    cdef object v27
    cdef object v28
    v11 = method65(v10, v4, v3)
    v12 = False
    v13 = False
    v14 = False
    v15 = Mut2(v13, v12, v14)
    del v12; del v13; del v14
    v16 = len(v2)
    v17 = (<unsigned long long>0)
    method68(v16, v2, v1, v15, v17)
    v18, v19, v20 = v15.v0, v15.v1, v15.v2
    del v15
    v21 = {'call': v18, 'fold': v19, 'raise': v20}
    del v18; del v19; del v20
    if v9 == 0: # jack
        v22 = 'J'
    elif v9 == 1: # king
        v22 = 'K'
    elif v9 == 2: # queen
        v22 = 'Q'
    if v6 == 0: # jack
        v23 = 'J'
    elif v6 == 1: # king
        v23 = 'K'
    elif v6 == 2: # queen
        v23 = 'Q'
    if v5.tag == 0: # none
        v26 = ' '
    elif v5.tag == 1: # some_
        v24 = (<US1_1>v5).v0
        if v24 == 0: # jack
            v26 = 'J'
        elif v24 == 1: # king
            v26 = 'K'
        elif v24 == 2: # queen
            v26 = 'Q'
    v27 = {'community_card': v26, 'my_card': v22, 'my_pot': v8, 'op_card': v23, 'op_pot': v8}
    del v22; del v23; del v26
    v28 = {'actions': v21, 'table_data': v27, 'trace': v11}
    del v11; del v21; del v27
    v0.data = v28
cdef void method59(v0, Mut0 v1, US0 v2, US0 v3, Heap0 v4, numpy.ndarray[signed long,ndim=1] v5, US3 v6, double v7, UH0 v8, double v9, UH0 v10, double v11, v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef unsigned long long v19
    cdef Mut1 v20
    cdef numpy.ndarray[double,ndim=1] v21
    cdef numpy.ndarray[double,ndim=1] v22
    cdef unsigned long long v23
    cdef double v24
    cdef US3 v25
    cdef double v26
    cdef double v27
    cdef US2 v28
    cdef UH0 v29
    cdef US2 v30
    cdef UH0 v31
    cdef US1 v32
    cdef US4 v33
    cdef object v34
    cdef object v35
    cdef signed long v36
    cdef unsigned char v37
    cdef signed long v38
    cdef unsigned char v39
    cdef signed long v40
    cdef numpy.ndarray[signed long,ndim=1] v41
    cdef bint v42
    cdef unsigned long long v43
    cdef Mut1 v44
    cdef numpy.ndarray[double,ndim=1] v45
    cdef numpy.ndarray[double,ndim=1] v46
    cdef unsigned long long v47
    cdef double v48
    cdef US3 v49
    cdef double v50
    cdef double v51
    cdef US2 v52
    cdef UH0 v53
    cdef US2 v54
    cdef UH0 v55
    cdef US1 v56
    cdef US4 v57
    cdef object v58
    if v6 == 0: # call
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method28(v4, v2, v16, v15, v3, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = len(v17)
            v20 = method2(v1, v17, v8)
            v21 = v20.v1
            del v20
            v22 = method11(v21)
            del v21
            v23 = numpy.random.choice(v19,p=v22)
            v24 = v22[v23]
            del v22
            v25 = v17[v23]
            del v17
            v26 = libc.math.log(v24)
            v27 = v26 + v9
            v28 = US2_0(v25)
            v29 = UH0_0(v28, v8)
            del v28
            v30 = US2_0(v25)
            v31 = UH0_0(v30, v10)
            del v30
            method60(v0, v1, v4, v5, v13, v2, v16, v15, v3, v14, v25, v7, v29, v27, v31, v11, v12)
        else:
            v32 = US1_0()
            v33 = US4_0()
            v34 = Closure34(v12, v10, v11, v8, v9, v7, v0, v1, v4, v5, v13, v2, v16, v15, v3, v14)
            method70(v0, v34, v17, v10, v33, v32, v2, v16, v15, v3, v14)
    elif v6 == 1: # fold
        raise Exception("impossible")
    elif v6 == 2: # raise
        v36 = (<signed long>1)
        v37 = (<unsigned char>1)
        v38 = (<signed long>1)
        v39 = (<unsigned char>0)
        v40 = (<signed long>3)
        v41 = method33(v4, v2, v39, v40, v3, v37, v38, v36)
        v42 = v37 == (<unsigned char>0)
        if v42:
            v43 = len(v41)
            v44 = method2(v1, v41, v8)
            v45 = v44.v1
            del v44
            v46 = method11(v45)
            del v45
            v47 = numpy.random.choice(v43,p=v46)
            v48 = v46[v47]
            del v46
            v49 = v41[v47]
            del v41
            v50 = libc.math.log(v48)
            v51 = v50 + v9
            v52 = US2_0(v49)
            v53 = UH0_0(v52, v8)
            del v52
            v54 = US2_0(v49)
            v55 = UH0_0(v54, v10)
            del v54
            method69(v0, v1, v4, v5, v36, v2, v39, v40, v3, v37, v38, v49, v7, v53, v51, v55, v11, v12)
        else:
            v56 = US1_0()
            v57 = US4_0()
            v58 = Closure33(v12, v10, v11, v8, v9, v7, v0, v1, v4, v5, v36, v2, v39, v40, v3, v37, v38)
            method64(v0, v58, v41, v10, v57, v56, v2, v39, v40, v3, v37, v38)
cdef void method58(v0, Mut0 v1, Heap0 v2, US0 v3, US0 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, UH0 v9, double v10, v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef unsigned long long v13
    cdef Mut1 v14
    cdef numpy.ndarray[double,ndim=1] v15
    cdef numpy.ndarray[double,ndim=1] v16
    cdef unsigned long long v17
    cdef double v18
    cdef US3 v19
    cdef double v20
    cdef double v21
    cdef US2 v22
    cdef UH0 v23
    cdef US2 v24
    cdef UH0 v25
    v12 = v2.v2
    v13 = len(v12)
    v14 = method2(v1, v12, v7)
    v15 = v14.v1
    del v14
    v16 = method11(v15)
    del v15
    v17 = numpy.random.choice(v13,p=v16)
    v18 = v16[v17]
    del v16
    v19 = v12[v17]
    del v12
    v20 = libc.math.log(v18)
    v21 = v20 + v8
    v22 = US2_0(v19)
    v23 = UH0_0(v22, v7)
    del v22
    v24 = US2_0(v19)
    v25 = UH0_0(v24, v9)
    del v24
    method59(v0, v1, v3, v4, v2, v5, v19, v6, v23, v21, v25, v10, v11)
cdef void method57(v0, Mut0 v1, Heap0 v2, US0 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9, v10):
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef US0 v13
    cdef unsigned long long v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef US2 v21
    cdef UH0 v22
    v11 = len(v4)
    v12 = numpy.random.randint(0,v11)
    v13 = v4[v12]
    v14 = v11 - (<unsigned long long>1)
    v15 = numpy.empty(v14,dtype=numpy.int32)
    v16 = (<unsigned long long>0)
    method23(v14, v12, v4, v15, v16)
    v17 = <double>v11
    v18 = (<double>1.000000) / v17
    v19 = libc.math.log(v18)
    v20 = v19 + v5
    v21 = US2_1(v13)
    v22 = UH0_0(v21, v8)
    del v21
    method58(v0, v1, v2, v3, v13, v15, v20, v6, v7, v22, v9, v10)
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef object v3
    cdef object v4
    cdef object v5
    v0 = (<unsigned long long>3)
    v1 = (<unsigned long long>7)
    v2 = method0(v0, v1)
    pass # import ui_train
    v3 = Closure0(v2)
    v4 = Closure23(v2)
    v5 = Closure24(v2)
    del v2
    ui_train.run(v3,v4,v5)
