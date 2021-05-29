import numpy
cimport numpy
cimport libc.math
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
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class Tuple0:
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly US0 v2
    def __init__(self, double v0, double v1, US0 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # action_
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    cdef readonly double v4
    cdef readonly UH0 v5
    cdef readonly double v6
    cdef readonly double v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    cdef readonly object v17
    def __init__(self, double v0, double v1, UH0 v2, double v3, double v4, UH0 v5, double v6, double v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16, v17): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class UH1_1(UH1): # terminal_
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    cdef readonly double v4
    cdef readonly UH0 v5
    cdef readonly double v6
    cdef readonly double v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly US3 v14
    cdef readonly double v15
    def __init__(self, double v0, double v1, UH0 v2, double v3, double v4, UH0 v5, double v6, double v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, double v15): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
cdef class Closure3():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef signed long v2
    cdef US1 v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef signed long v8
    cdef UH0 v9
    cdef double v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    cdef double v15
    def __init__(self, unsigned char v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, double v10, double v11, UH0 v12, double v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple0 args):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef signed long v2 = self.v2
        cdef US1 v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef double v17 = args.v1
        cdef US0 v18 = args.v2
        cdef bint v19
        cdef double v20
        cdef double v21
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        cdef double v27
        cdef double v28
        cdef US2 v29
        cdef UH0 v30
        cdef US2 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v14
            v21 = v16 + v13
            v22 = US2_0(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US2_0(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method7(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method7(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure2():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef US1 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US1 v5
    cdef signed long v6
    cdef US1 v7
    cdef UH0 v8
    cdef double v9
    cdef double v10
    cdef UH0 v11
    cdef double v12
    cdef double v13
    cdef double v14
    def __init__(self, unsigned char v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, signed long v6, US1 v7, UH0 v8, double v9, double v10, UH0 v11, double v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple0 args):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef US1 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef double v9 = self.v9
        cdef double v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef double v16 = args.v1
        cdef US0 v17 = args.v2
        cdef bint v18
        cdef double v19
        cdef double v20
        cdef US2 v21
        cdef US2 v22
        cdef UH0 v23
        cdef UH0 v24
        cdef US2 v25
        cdef US2 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef double v30
        cdef double v31
        cdef US2 v32
        cdef US2 v33
        cdef UH0 v34
        cdef UH0 v35
        cdef US2 v36
        cdef US2 v37
        cdef UH0 v38
        cdef UH0 v39
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v13
            v20 = v15 + v12
            v21 = US2_0(v17)
            v22 = US2_1(v7)
            v23 = UH0_0(v22, v11)
            del v22
            v24 = UH0_0(v21, v23)
            del v21; del v23
            v25 = US2_0(v17)
            v26 = US2_1(v7)
            v27 = UH0_0(v26, v8)
            del v26
            v28 = UH0_0(v25, v27)
            del v25; del v27
            return method5(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v24, v20, v19, v28, v9, v10)
        else:
            v30 = v16 + v10
            v31 = v15 + v9
            v32 = US2_0(v17)
            v33 = US2_1(v7)
            v34 = UH0_0(v33, v11)
            del v33
            v35 = UH0_0(v32, v34)
            del v32; del v34
            v36 = US2_0(v17)
            v37 = US2_1(v7)
            v38 = UH0_0(v37, v8)
            del v37
            v39 = UH0_0(v36, v38)
            del v36; del v38
            return method5(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v35, v12, v13, v39, v31, v30)
cdef class Closure4():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef object v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef signed long v8
    cdef UH0 v9
    cdef double v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    cdef double v15
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, double v10, double v11, UH0 v12, double v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple0 args):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef double v17 = args.v1
        cdef US0 v18 = args.v2
        cdef bint v19
        cdef double v20
        cdef double v21
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        cdef double v27
        cdef double v28
        cdef US2 v29
        cdef UH0 v30
        cdef US2 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v14
            v21 = v16 + v13
            v22 = US2_0(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US2_0(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method9(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method9(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure1():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef object v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef UH0 v8
    cdef double v9
    cdef double v10
    cdef UH0 v11
    cdef double v12
    cdef double v13
    cdef double v14
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, UH0 v8, double v9, double v10, UH0 v11, double v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple0 args):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef double v9 = self.v9
        cdef double v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef double v16 = args.v1
        cdef US0 v17 = args.v2
        cdef bint v18
        cdef double v19
        cdef double v20
        cdef US2 v21
        cdef UH0 v22
        cdef US2 v23
        cdef UH0 v24
        cdef double v26
        cdef double v27
        cdef US2 v28
        cdef UH0 v29
        cdef US2 v30
        cdef UH0 v31
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v13
            v20 = v15 + v12
            v21 = US2_0(v17)
            v22 = UH0_0(v21, v11)
            del v21
            v23 = US2_0(v17)
            v24 = UH0_0(v23, v8)
            del v23
            return method4(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v22, v20, v19, v24, v9, v10)
        else:
            v26 = v16 + v10
            v27 = v15 + v9
            v28 = US2_0(v17)
            v29 = UH0_0(v28, v11)
            del v28
            v30 = US2_0(v17)
            v31 = UH0_0(v30, v8)
            del v30
            return method4(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v29, v12, v13, v31, v27, v26)
cdef class Closure0():
    cdef US1 v0
    cdef US1 v1
    cdef Heap0 v2
    cdef object v3
    cdef UH0 v4
    cdef double v5
    cdef double v6
    cdef UH0 v7
    cdef double v8
    cdef double v9
    cdef double v10
    def __init__(self, US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, double v5, double v6, UH0 v7, double v8, double v9, double v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple0 args):
        cdef US1 v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef double v8 = self.v8
        cdef double v9 = self.v9
        cdef double v10 = self.v10
        cdef double v11 = args.v0
        cdef double v12 = args.v1
        cdef US0 v13 = args.v2
        cdef double v14
        cdef double v15
        cdef US2 v16
        cdef US2 v17
        cdef UH0 v18
        cdef UH0 v19
        cdef US2 v20
        cdef US2 v21
        cdef UH0 v22
        cdef UH0 v23
        v14 = v12 + v9
        v15 = v11 + v8
        v16 = US2_0(v13)
        v17 = US2_1(v0)
        v18 = UH0_0(v17, v7)
        del v17
        v19 = UH0_0(v16, v18)
        del v16; del v18
        v20 = US2_0(v13)
        v21 = US2_1(v1)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = UH0_0(v20, v22)
        del v20; del v22
        return method2(v0, v1, v2, v3, v13, v10, v19, v15, v14, v23, v5, v6)
cdef class Tuple1:
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    cdef readonly double v4
    cdef readonly UH0 v5
    cdef readonly double v6
    cdef readonly double v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    def __init__(self, double v0, double v1, UH0 v2, double v3, double v4, UH0 v5, double v6, double v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly double v1
    cdef readonly double v2
    cdef readonly UH0 v3
    cdef readonly double v4
    cdef readonly double v5
    cdef readonly UH0 v6
    cdef readonly double v7
    cdef readonly double v8
    cdef readonly US1 v9
    cdef readonly unsigned char v10
    cdef readonly signed long v11
    cdef readonly US1 v12
    cdef readonly unsigned char v13
    cdef readonly signed long v14
    cdef readonly US3 v15
    cdef readonly double v16
    def __init__(self, unsigned long long v0, double v1, double v2, UH0 v3, double v4, double v5, UH0 v6, double v7, double v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US3 v15, double v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef void method1(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4) except *:
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
        method1(v0, v1, v2, v3, v6)
    else:
        pass
cdef numpy.ndarray[signed long,ndim=1] method3(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method6(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method8(US1 v0) except *:
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef UH1 method7(Heap0 v0, signed long v1, US1 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
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
    cdef US1 v64
    cdef unsigned char v65
    cdef signed long v66
    cdef US1 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef double v70
    cdef US3 v71
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
    cdef US3 v90
    cdef signed long v92
    cdef signed long v93
    cdef numpy.ndarray[signed long,ndim=1] v94
    cdef US3 v95
    cdef object v96
    if v9 == 0: # call
        v17 = method8(v2)
        v18 = method8(v6)
        v19 = method8(v3)
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
            v51, v52 = v7, v5
        else:
            v48 = v46 == (<signed long>-1)
            if v48:
                v51, v52 = v4, v5
            else:
                v51, v52 = v7, (<signed long>0)
        v53 = v51 == (<unsigned char>0)
        if v53:
            v55 = v52
        else:
            v55 = -v52
        v56 = v7 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v58 + v5
        v60 = v4 == (<unsigned char>0)
        if v60:
            v62 = v55
        else:
            v62 = -v55
        v63 = v62 + v5
        if v56:
            v64, v65, v66, v67, v68, v69 = v6, v7, v59, v3, v4, v63
        else:
            v64, v65, v66, v67, v68, v69 = v3, v4, v63, v6, v7, v59
        v70 = <double>v55
        v71 = US3_1(v2)
        return UH1_1(v10, v10, v11, v12, v13, v14, v15, v16, v64, v65, v66, v67, v68, v69, v71, v70)
    elif v9 == 1: # fold
        v73 = v4 == (<unsigned char>0)
        if v73:
            v75 = v8
        else:
            v75 = -v8
        v76 = v7 == (<unsigned char>0)
        if v76:
            v78 = v75
        else:
            v78 = -v75
        v79 = v78 + v8
        if v73:
            v81 = v75
        else:
            v81 = -v75
        v82 = v81 + v5
        if v76:
            v83, v84, v85, v86, v87, v88 = v6, v7, v79, v3, v4, v82
        else:
            v83, v84, v85, v86, v87, v88 = v3, v4, v82, v6, v7, v79
        v89 = <double>v75
        v90 = US3_1(v2)
        return UH1_1(v10, v10, v11, v12, v13, v14, v15, v16, v83, v84, v85, v86, v87, v88, v90, v89)
    elif v9 == 2: # raise
        v92 = v1 - (<signed long>1)
        v93 = v5 + (<signed long>4)
        v94 = method6(v0, v6, v7, v93, v3, v4, v5, v92)
        v95 = US3_1(v2)
        v96 = Closure3(v4, v0, v92, v2, v6, v7, v93, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH1_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v93, v95, v4, v94, v96)
cdef UH1 method5(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, US0 v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15):
    cdef signed long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef US3 v18
    cdef object v19
    cdef object v21
    cdef signed long v23
    cdef signed long v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef US3 v26
    cdef object v27
    if v8 == 0: # call
        v16 = (<signed long>2)
        v17 = method6(v0, v4, v5, v6, v1, v2, v3, v16)
        v18 = US3_1(v7)
        v19 = Closure3(v2, v0, v16, v7, v4, v5, v6, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v18, v2, v17, v19)
    elif v8 == 1: # fold
        raise Exception("impossible")
    elif v8 == 2: # raise
        v23 = (<signed long>1)
        v24 = v3 + (<signed long>4)
        v25 = method6(v0, v4, v5, v24, v1, v2, v3, v23)
        v26 = US3_1(v7)
        v27 = Closure3(v2, v0, v23, v7, v4, v5, v24, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v24, v26, v2, v25, v27)
cdef UH1 method9(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef US1 v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef US3 v36
    cdef object v37
    cdef bint v39
    cdef signed long v41
    cdef bint v42
    cdef signed long v44
    cdef signed long v45
    cdef signed long v47
    cdef signed long v48
    cdef US1 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef US1 v52
    cdef unsigned char v53
    cdef signed long v54
    cdef double v55
    cdef US3 v56
    cdef signed long v58
    cdef signed long v59
    cdef numpy.ndarray[signed long,ndim=1] v60
    cdef US3 v61
    cdef object v62
    if v9 == 0: # call
        v17 = v7 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v6, v7, v5, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23 = v3, v4, v5, v6, v7, v5
        v24 = len(v1)
        v25 = numpy.random.randint(0,v24)
        v26 = v1[v25]
        v27 = <double>v24
        v28 = (<double>1.000000) / v27
        v29 = libc.math.log(v28)
        v30 = v29 + v10
        v31 = v0.v2
        v32 = US2_1(v26)
        v33 = UH0_0(v32, v11)
        del v32
        v34 = US2_1(v26)
        v35 = UH0_0(v34, v14)
        del v34
        v36 = US3_1(v26)
        v37 = Closure2(v19, v0, v21, v22, v23, v18, v20, v26, v14, v15, v16, v11, v12, v13, v30)
        return UH1_0(v30, v30, v33, v12, v13, v35, v15, v16, v18, v19, v20, v21, v22, v23, v36, v19, v31, v37)
    elif v9 == 1: # fold
        v39 = v4 == (<unsigned char>0)
        if v39:
            v41 = v8
        else:
            v41 = -v8
        v42 = v7 == (<unsigned char>0)
        if v42:
            v44 = v41
        else:
            v44 = -v41
        v45 = v44 + v8
        if v39:
            v47 = v41
        else:
            v47 = -v41
        v48 = v47 + v5
        if v42:
            v49, v50, v51, v52, v53, v54 = v6, v7, v45, v3, v4, v48
        else:
            v49, v50, v51, v52, v53, v54 = v3, v4, v48, v6, v7, v45
        v55 = <double>v41
        v56 = US3_0()
        return UH1_1(v10, v10, v11, v12, v13, v14, v15, v16, v49, v50, v51, v52, v53, v54, v56, v55)
    elif v9 == 2: # raise
        v58 = v2 - (<signed long>1)
        v59 = v5 + (<signed long>2)
        v60 = method6(v0, v6, v7, v59, v3, v4, v5, v58)
        v61 = US3_0()
        v62 = Closure4(v4, v0, v1, v58, v6, v7, v59, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH1_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v59, v61, v4, v60, v62)
cdef UH1 method4(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US0 v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15):
    cdef bint v16
    cdef US1 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef US1 v25
    cdef double v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef numpy.ndarray[signed long,ndim=1] v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef US3 v35
    cdef object v36
    cdef bint v38
    cdef signed long v40
    cdef bint v41
    cdef signed long v43
    cdef signed long v44
    cdef signed long v46
    cdef signed long v47
    cdef US1 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef US1 v51
    cdef unsigned char v52
    cdef signed long v53
    cdef double v54
    cdef US3 v55
    cdef signed long v57
    cdef signed long v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef US3 v60
    cdef object v61
    if v8 == 0: # call
        v16 = v7 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v6, v7, v5, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22 = v3, v4, v5, v6, v7, v5
        v23 = len(v1)
        v24 = numpy.random.randint(0,v23)
        v25 = v1[v24]
        v26 = <double>v23
        v27 = (<double>1.000000) / v26
        v28 = libc.math.log(v27)
        v29 = v28 + v9
        v30 = v0.v2
        v31 = US2_1(v25)
        v32 = UH0_0(v31, v10)
        del v31
        v33 = US2_1(v25)
        v34 = UH0_0(v33, v13)
        del v33
        v35 = US3_1(v25)
        v36 = Closure2(v18, v0, v20, v21, v22, v17, v19, v25, v13, v14, v15, v10, v11, v12, v29)
        return UH1_0(v29, v29, v32, v11, v12, v34, v14, v15, v17, v18, v19, v20, v21, v22, v35, v18, v30, v36)
    elif v8 == 1: # fold
        v38 = v4 == (<unsigned char>0)
        if v38:
            v40 = v5
        else:
            v40 = -v5
        v41 = v7 == (<unsigned char>0)
        if v41:
            v43 = v40
        else:
            v43 = -v40
        v44 = v43 + v5
        if v38:
            v46 = v40
        else:
            v46 = -v40
        v47 = v46 + v5
        if v41:
            v48, v49, v50, v51, v52, v53 = v6, v7, v44, v3, v4, v47
        else:
            v48, v49, v50, v51, v52, v53 = v3, v4, v47, v6, v7, v44
        v54 = <double>v40
        v55 = US3_0()
        return UH1_1(v9, v9, v10, v11, v12, v13, v14, v15, v48, v49, v50, v51, v52, v53, v55, v54)
    elif v8 == 2: # raise
        v57 = v2 - (<signed long>1)
        v58 = v5 + (<signed long>2)
        v59 = method6(v0, v6, v7, v58, v3, v4, v5, v57)
        v60 = US3_0()
        v61 = Closure4(v4, v0, v1, v57, v6, v7, v58, v3, v5, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v58, v60, v4, v59, v61)
cdef UH1 method2(US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, US0 v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11):
    cdef signed long v12
    cdef unsigned char v13
    cdef signed long v14
    cdef unsigned char v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef US3 v17
    cdef object v18
    cdef object v20
    cdef signed long v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned char v25
    cdef signed long v26
    cdef numpy.ndarray[signed long,ndim=1] v27
    cdef US3 v28
    cdef object v29
    if v4 == 0: # call
        v12 = (<signed long>2)
        v13 = (<unsigned char>1)
        v14 = (<signed long>1)
        v15 = (<unsigned char>0)
        v16 = method3(v2, v0, v15, v14, v1, v13, v12)
        v17 = US3_0()
        v18 = Closure1(v13, v2, v3, v12, v0, v15, v14, v1, v9, v10, v11, v6, v7, v8, v5)
        return UH1_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v13, v14, v0, v15, v14, v17, v13, v16, v18)
    elif v4 == 1: # fold
        raise Exception("impossible")
    elif v4 == 2: # raise
        v22 = (<signed long>1)
        v23 = (<unsigned char>1)
        v24 = (<signed long>1)
        v25 = (<unsigned char>0)
        v26 = (<signed long>3)
        v27 = method6(v2, v0, v25, v26, v1, v23, v24, v22)
        v28 = US3_0()
        v29 = Closure4(v23, v2, v3, v22, v0, v25, v26, v1, v24, v9, v10, v11, v6, v7, v8, v5)
        return UH1_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v23, v24, v0, v25, v26, v28, v23, v27, v29)
cdef void method0(numpy.ndarray[signed long,ndim=1] v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    cdef UH0 v6
    cdef double v7
    cdef double v8
    cdef UH0 v9
    cdef double v10
    cdef double v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef US1 v14
    cdef unsigned long long v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef US1 v23
    cdef unsigned long long v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef unsigned long long v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef US3 v36
    cdef object v37
    cdef UH1 v38
    v4 = v3 < (<unsigned long long>64)
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = UH0_1()
        v7 = (<double>0.000000)
        v8 = (<double>0.000000)
        v9 = UH0_1()
        v10 = (<double>0.000000)
        v11 = (<double>0.000000)
        v12 = len(v0)
        v13 = numpy.random.randint(0,v12)
        v14 = v0[v13]
        v15 = v12 - (<unsigned long long>1)
        v16 = numpy.empty(v15,dtype=numpy.int32)
        v17 = (<unsigned long long>0)
        method1(v15, v13, v0, v16, v17)
        v18 = <double>v12
        v19 = (<double>1.000000) / v18
        v20 = libc.math.log(v19)
        v21 = len(v16)
        v22 = numpy.random.randint(0,v21)
        v23 = v16[v22]
        v24 = v21 - (<unsigned long long>1)
        v25 = numpy.empty(v24,dtype=numpy.int32)
        v26 = (<unsigned long long>0)
        method1(v24, v22, v16, v25, v26)
        del v16
        v27 = <double>v21
        v28 = (<double>1.000000) / v27
        v29 = libc.math.log(v28)
        v30 = v29 + v20
        v31 = v1.v2
        v32 = US2_1(v14)
        v33 = UH0_0(v32, v6)
        del v32
        v34 = US2_1(v23)
        v35 = UH0_0(v34, v9)
        del v34
        v36 = US3_0()
        v37 = Closure0(v14, v23, v1, v25, v9, v10, v11, v6, v7, v8, v30)
        del v6; del v9; del v25
        v38 = UH1_0(v30, v30, v33, v7, v8, v35, v10, v11, v14, (<unsigned char>0), (<signed long>1), v23, (<unsigned char>1), (<signed long>1), v36, (<unsigned char>0), v31, v37)
        del v31; del v33; del v35; del v36; del v37
        v2[v3] = v38
        del v38
        method0(v0, v1, v2, v5)
    else:
        pass
cdef void method11(unsigned long long v0, list v1, list v2, list v3, list v4, numpy.ndarray[object,ndim=1] v5, unsigned long long v6) except *:
    cdef bint v7
    cdef unsigned long long v8
    cdef UH1 v9
    cdef double v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    cdef UH0 v15
    cdef double v16
    cdef double v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef US3 v24
    cdef unsigned char v25
    cdef numpy.ndarray[signed long,ndim=1] v26
    cdef object v27
    cdef double v28
    cdef double v29
    cdef UH0 v30
    cdef double v31
    cdef double v32
    cdef UH0 v33
    cdef double v34
    cdef double v35
    cdef US1 v36
    cdef unsigned char v37
    cdef signed long v38
    cdef US1 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef US3 v42
    cdef double v43
    v7 = v6 < v0
    if v7:
        v8 = v6 + (<unsigned long long>1)
        v9 = v5[v6]
        if v9.tag == 0: # action_
            v10 = (<UH1_0>v9).v0; v11 = (<UH1_0>v9).v1; v12 = (<UH1_0>v9).v2; v13 = (<UH1_0>v9).v3; v14 = (<UH1_0>v9).v4; v15 = (<UH1_0>v9).v5; v16 = (<UH1_0>v9).v6; v17 = (<UH1_0>v9).v7; v18 = (<UH1_0>v9).v8; v19 = (<UH1_0>v9).v9; v20 = (<UH1_0>v9).v10; v21 = (<UH1_0>v9).v11; v22 = (<UH1_0>v9).v12; v23 = (<UH1_0>v9).v13; v24 = (<UH1_0>v9).v14; v25 = (<UH1_0>v9).v15; v26 = (<UH1_0>v9).v16; v27 = (<UH1_0>v9).v17
            v2.append(v6)
            v3.append(Tuple1(v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26))
            del v12; del v15; del v24; del v26
            v4.append(v27)
            del v27
        elif v9.tag == 1: # terminal_
            v28 = (<UH1_1>v9).v0; v29 = (<UH1_1>v9).v1; v30 = (<UH1_1>v9).v2; v31 = (<UH1_1>v9).v3; v32 = (<UH1_1>v9).v4; v33 = (<UH1_1>v9).v5; v34 = (<UH1_1>v9).v6; v35 = (<UH1_1>v9).v7; v36 = (<UH1_1>v9).v8; v37 = (<UH1_1>v9).v9; v38 = (<UH1_1>v9).v10; v39 = (<UH1_1>v9).v11; v40 = (<UH1_1>v9).v12; v41 = (<UH1_1>v9).v13; v42 = (<UH1_1>v9).v14; v43 = (<UH1_1>v9).v15
            v1.append(Tuple2(v6, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43))
            del v30; del v33; del v42
        del v9
        method11(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method12(unsigned long long v0, list v1, list v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    cdef UH0 v8
    cdef double v9
    cdef double v10
    cdef UH0 v11
    cdef double v12
    cdef double v13
    cdef US1 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US1 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US3 v20
    cdef unsigned char v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef Tuple1 tmp0
    cdef unsigned long long v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef US0 v27
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        tmp0 = v1[v3]
        v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
        del tmp0
        del v8; del v11; del v20
        v23 = len(v22)
        v24 = <double>v23
        v25 = (<double>1.000000) / v24
        v26 = libc.math.log(v25)
        v27 = numpy.random.choice(v22)
        del v22
        v2[v3] = Tuple0(v26, v26, v27)
        method12(v0, v1, v2, v5)
    else:
        pass
cdef void method13(unsigned long long v0, list v1, list v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef object v7
    cdef double v8
    cdef double v9
    cdef US0 v10
    cdef Tuple0 tmp1
    cdef UH1 v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        tmp1 = v2[v4]
        v8, v9, v10 = tmp1.v0, tmp1.v1, tmp1.v2
        del tmp1
        v11 = v7(Tuple0(v8, v9, v10))
        del v7
        v3[v4] = v11
        del v11
        method13(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, list v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef double v8
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v2[v4]
        v8 = v3[v4]
        v1[v7] = v8
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method15(unsigned long long v0, list v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef UH0 v9
    cdef double v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    cdef US1 v15
    cdef unsigned char v16
    cdef signed long v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US3 v21
    cdef double v22
    cdef Tuple2 tmp2
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        tmp2 = v1[v3]
        v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16
        del tmp2
        del v9; del v12; del v21
        v2[v6] = v22
        method15(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method10(numpy.ndarray[object,ndim=1] v0):
    cdef list v1
    cdef list v2
    cdef list v3
    cdef list v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef bint v8
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v9
    cdef list v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef unsigned long long v17
    cdef numpy.ndarray[double,ndim=1] v19
    cdef numpy.ndarray[double,ndim=1] v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = len(v0)
    v6 = (<unsigned long long>0)
    method11(v5, v1, v2, v3, v4, v0, v6)
    v7 = len(v3)
    v8 = (<unsigned long long>0) < v7
    if v8:
        v9 = len(v3)
        v10 = [None]*v9
        v11 = (<unsigned long long>0)
        method12(v9, v3, v10, v11)
        v12 = len(v4)
        v13 = len(v10)
        v14 = v12 == v13
        v15 = v14 == 0
        if v15:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v16 = numpy.empty(v12,dtype=object)
        v17 = (<unsigned long long>0)
        method13(v12, v4, v10, v16, v17)
        del v10
        v20 = method10(v16)
        del v16
    else:
        v19 = numpy.empty((<unsigned long long>0),dtype=numpy.float64)
        v20 = v19
        del v19
    del v3; del v4
    v21 = numpy.empty(v5,dtype=numpy.float64)
    v22 = len(v2)
    v23 = len(v20)
    v24 = v22 == v23
    v25 = v24 == 0
    if v25:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v26 = (<unsigned long long>0)
    method14(v22, v21, v2, v20, v26)
    del v2; del v20
    v27 = len(v1)
    v28 = (<unsigned long long>0)
    method15(v27, v1, v21, v28)
    del v1
    return v21
cpdef void main() except *:
    cdef US0 v0
    cdef US0 v1
    cdef numpy.ndarray[signed long,ndim=1] v2
    cdef US0 v3
    cdef US0 v4
    cdef US0 v5
    cdef numpy.ndarray[signed long,ndim=1] v6
    cdef US0 v7
    cdef US0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef US0 v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef Heap0 v12
    cdef US1 v13
    cdef US1 v14
    cdef US1 v15
    cdef US1 v16
    cdef US1 v17
    cdef US1 v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef numpy.ndarray[object,ndim=1] v20
    cdef unsigned long long v21
    cdef numpy.ndarray[double,ndim=1] v22
    v0 = 0
    v1 = 2
    v2 = numpy.empty(2,dtype=numpy.int32)
    v2[0] = v0; v2[1] = v1
    v3 = 1
    v4 = 0
    v5 = 2
    v6 = numpy.empty(3,dtype=numpy.int32)
    v6[0] = v3; v6[1] = v4; v6[2] = v5
    v7 = 1
    v8 = 0
    v9 = numpy.empty(2,dtype=numpy.int32)
    v9[0] = v7; v9[1] = v8
    v10 = 0
    v11 = numpy.empty(1,dtype=numpy.int32)
    v11[0] = v10
    v12 = Heap0(v11, v6, v2, v9)
    del v2; del v6; del v9; del v11
    v13 = 1
    v14 = 2
    v15 = 0
    v16 = 1
    v17 = 2
    v18 = 0
    v19 = numpy.empty(6,dtype=numpy.int32)
    v19[0] = v13; v19[1] = v14; v19[2] = v15; v19[3] = v16; v19[4] = v17; v19[5] = v18
    v20 = numpy.empty((<unsigned long long>64),dtype=object)
    v21 = (<unsigned long long>0)
    method0(v19, v12, v20, v21)
    del v12; del v19
    v22 = method10(v20)
    del v20
    print(v22)
