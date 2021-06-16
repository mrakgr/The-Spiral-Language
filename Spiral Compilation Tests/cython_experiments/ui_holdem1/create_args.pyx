import numpy
cimport numpy
cimport libc.math
cdef class Mut0:
    cdef public signed long v0
    def __init__(self, signed long v0): self.v0 = v0
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raiseTo_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 2; self.v0 = v0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # action_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 0; self.v0 = v0
cdef class US1_1(US1): # observation_
    cdef readonly signed char v0
    def __init__(self, signed char v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US1 v0
    cdef readonly UH0 v1
    def __init__(self, US1 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    cdef readonly signed char v5
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
cdef class Tuple1:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple2:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # action_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed long v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed long v15
    cdef readonly object v16
    cdef readonly unsigned char v17
    cdef readonly object v18
    cdef readonly object v19
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed long v11, signed char v12, signed char v13, unsigned char v14, signed long v15, v16, unsigned char v17, v18, v19): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
cdef class UH1_1(UH1): # terminal_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed long v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed long v15
    cdef readonly object v16
    cdef readonly float v17
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed long v11, signed char v12, signed char v13, unsigned char v14, signed long v15, v16, float v17): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class Closure4():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef float v9
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, float v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, float v10, float v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef float v9 = self.v9
        return UH1_1(v10, v11, v12, v13, v14, v15, v16, v17, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
cdef class Closure8():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef object v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US0 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US1 v30
        cdef UH0 v31
        cdef US1 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US1 v37
        cdef UH0 v38
        cdef US1 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US1_0(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US1_0(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method30(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US1_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US1_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method30(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure7():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef signed long v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, signed long v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed long v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure8(v2, v9, v4, v5, v6, v3, v0, v1, v10, v11, v7, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH1_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v25)
cdef class Closure6():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef signed long v9
    cdef object v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef float v24
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22, float v23, float v24): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24
    def __call__(self, float v25, float v26, US0 v27):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef signed long v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef UH0 v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef bint v28
        cdef float v29
        cdef float v30
        cdef US1 v31
        cdef UH0 v32
        cdef US1 v33
        cdef UH0 v34
        cdef float v36
        cdef float v37
        cdef US1 v38
        cdef UH0 v39
        cdef US1 v40
        cdef UH0 v41
        v28 = v0 == (<unsigned char>0)
        if v28:
            v29 = v26 + v22
            v30 = v25 + v21
            v31 = US1_0(v27)
            v32 = UH0_0(v31, v20)
            del v31
            v33 = US1_0(v27)
            v34 = UH0_0(v33, v17)
            del v33
            return method27(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US1_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US1_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method27(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure5():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef object v9
    cdef bint v10
    cdef signed long v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed long v11, numpy.ndarray[object,ndim=1] v12, signed char v13, signed char v14, signed char v15, signed char v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef signed long v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure6(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v12, v8, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH1_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v26)
cdef class Closure3():
    cdef object v0
    cdef signed long v1
    cdef object v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef signed char v8
    cdef unsigned char v9
    cdef signed long v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed long v14
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed long v1, numpy.ndarray[object,ndim=1] v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed long v10, signed char v11, signed char v12, unsigned char v13, signed long v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed long v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed char v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef signed char v23
        cdef unsigned long long v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef float v28
        cdef float v29
        cdef numpy.ndarray[signed char,ndim=1] v30
        cdef bint v31
        cdef numpy.ndarray[signed char,ndim=1] v32
        cdef object v33
        cdef US1 v34
        cdef UH0 v35
        cdef US1 v36
        cdef UH0 v37
        v23 = v0[(<unsigned long long>0)]
        v24 = len(v0)
        v25 = <float>v24
        v26 = (<float>1.000000) / v25
        v27 = libc.math.log(v26)
        v28 = v27 + v16
        v29 = v27 + v15
        v30 = v0[1:]
        del v30
        v31 = 1
        v32 = numpy.empty(5,dtype=numpy.int8)
        v32[0] = v3; v32[1] = v4; v32[2] = v5; v32[3] = v6; v32[4] = v23
        v33 = method7(v1, v2, v31, v7, v8, v9, v10, v11, v12, v13, v14, v32, v3, v4, v5, v6, v23)
        del v32
        v34 = US1_1(v23)
        v35 = UH0_0(v34, v17)
        del v34
        v36 = US1_1(v23)
        v37 = UH0_0(v36, v20)
        del v36
        return v33(v29, v28, v35, v18, v19, v37, v21, v22)
cdef class Closure12():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef object v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US0 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US1 v30
        cdef UH0 v31
        cdef US1 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US1 v37
        cdef UH0 v38
        cdef US1 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US1_0(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US1_0(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US1_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US1_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure11():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef signed long v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, signed long v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed long v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure12(v2, v9, v4, v5, v6, v3, v0, v1, v10, v11, v7, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH1_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v25)
cdef class Closure10():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef signed long v9
    cdef object v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef float v24
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22, float v23, float v24): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24
    def __call__(self, float v25, float v26, US0 v27):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef signed long v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef UH0 v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef bint v28
        cdef float v29
        cdef float v30
        cdef US1 v31
        cdef UH0 v32
        cdef US1 v33
        cdef UH0 v34
        cdef float v36
        cdef float v37
        cdef US1 v38
        cdef UH0 v39
        cdef US1 v40
        cdef UH0 v41
        v28 = v0 == (<unsigned char>0)
        if v28:
            v29 = v26 + v22
            v30 = v25 + v21
            v31 = US1_0(v27)
            v32 = UH0_0(v31, v20)
            del v31
            v33 = US1_0(v27)
            v34 = UH0_0(v33, v17)
            del v33
            return method31(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US1_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US1_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method31(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure9():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef object v9
    cdef bint v10
    cdef signed long v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef object v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed long v11, numpy.ndarray[object,ndim=1] v12, signed char v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef signed long v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef numpy.ndarray[signed char,ndim=1] v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure10(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v12, v8, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH1_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v26)
cdef class Closure2():
    cdef object v0
    cdef signed long v1
    cdef object v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef unsigned char v8
    cdef signed long v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned char v12
    cdef signed long v13
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed long v1, numpy.ndarray[object,ndim=1] v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed long v9, signed char v10, signed char v11, unsigned char v12, signed long v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed long v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef signed char v22
        cdef unsigned long long v23
        cdef float v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef float v28
        cdef numpy.ndarray[signed char,ndim=1] v29
        cdef bint v30
        cdef numpy.ndarray[signed char,ndim=1] v31
        cdef object v32
        cdef US1 v33
        cdef UH0 v34
        cdef US1 v35
        cdef UH0 v36
        v22 = v0[(<unsigned long long>0)]
        v23 = len(v0)
        v24 = <float>v23
        v25 = (<float>1.000000) / v24
        v26 = libc.math.log(v25)
        v27 = v26 + v15
        v28 = v26 + v14
        v29 = v0[1:]
        v30 = 1
        v31 = numpy.empty(4,dtype=numpy.int8)
        v31[0] = v3; v31[1] = v4; v31[2] = v5; v31[3] = v22
        v32 = method5(v1, v2, v30, v6, v7, v8, v9, v10, v11, v12, v13, v31, v3, v4, v5, v29, v22)
        del v29; del v31
        v33 = US1_1(v22)
        v34 = UH0_0(v33, v16)
        del v33
        v35 = US1_1(v22)
        v36 = UH0_0(v35, v19)
        del v35
        return v32(v28, v27, v34, v17, v18, v36, v20, v21)
cdef class Closure16():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef object v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef object v13
    cdef signed char v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef float v22
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
    def __call__(self, float v23, float v24, US0 v25):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef UH0 v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef bint v26
        cdef float v27
        cdef float v28
        cdef US1 v29
        cdef UH0 v30
        cdef US1 v31
        cdef UH0 v32
        cdef float v34
        cdef float v35
        cdef US1 v36
        cdef UH0 v37
        cdef US1 v38
        cdef UH0 v39
        v26 = v0 == (<unsigned char>0)
        if v26:
            v27 = v24 + v20
            v28 = v23 + v19
            v29 = US1_0(v25)
            v30 = UH0_0(v29, v18)
            del v29
            v31 = US1_0(v25)
            v32 = UH0_0(v31, v15)
            del v31
            return method38(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US1_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US1_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method38(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
cdef class Closure15():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef signed long v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, signed long v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed long v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure16(v2, v9, v4, v5, v6, v3, v0, v1, v10, v11, v7, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH1_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v24)
cdef class Closure14():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef signed long v9
    cdef object v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US0 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef signed long v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US1 v30
        cdef UH0 v31
        cdef US1 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US1 v37
        cdef UH0 v38
        cdef US1 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US1_0(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US1_0(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method35(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US1_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US1_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method35(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure13():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef object v9
    cdef bint v10
    cdef signed long v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed long v11, numpy.ndarray[object,ndim=1] v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef signed long v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure14(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v12, v8, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH1_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v25)
cdef class Closure1():
    cdef object v0
    cdef signed long v1
    cdef object v2
    cdef signed char v3
    cdef signed char v4
    cdef unsigned char v5
    cdef signed long v6
    cdef signed char v7
    cdef signed char v8
    cdef unsigned char v9
    cdef signed long v10
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed long v1, numpy.ndarray[object,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed long v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed char v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef signed char v19
        cdef unsigned long long v20
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef float v25
        cdef numpy.ndarray[signed char,ndim=1] v26
        cdef signed char v27
        cdef unsigned long long v28
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef float v33
        cdef numpy.ndarray[signed char,ndim=1] v34
        cdef signed char v35
        cdef unsigned long long v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef numpy.ndarray[signed char,ndim=1] v42
        cdef bint v43
        cdef numpy.ndarray[signed char,ndim=1] v44
        cdef object v45
        cdef US1 v46
        cdef US1 v47
        cdef US1 v48
        cdef UH0 v49
        cdef UH0 v50
        cdef UH0 v51
        cdef US1 v52
        cdef US1 v53
        cdef US1 v54
        cdef UH0 v55
        cdef UH0 v56
        cdef UH0 v57
        v19 = v0[(<unsigned long long>0)]
        v20 = len(v0)
        v21 = <float>v20
        v22 = (<float>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v12
        v25 = v23 + v11
        v26 = v0[1:]
        v27 = v26[(<unsigned long long>0)]
        v28 = len(v26)
        v29 = <float>v28
        v30 = (<float>1.000000) / v29
        v31 = libc.math.log(v30)
        v32 = v31 + v24
        v33 = v31 + v25
        v34 = v26[1:]
        del v26
        v35 = v34[(<unsigned long long>0)]
        v36 = len(v34)
        v37 = <float>v36
        v38 = (<float>1.000000) / v37
        v39 = libc.math.log(v38)
        v40 = v39 + v32
        v41 = v39 + v33
        v42 = v34[1:]
        del v34
        v43 = 1
        v44 = numpy.empty(3,dtype=numpy.int8)
        v44[0] = v19; v44[1] = v27; v44[2] = v35
        v45 = method3(v1, v2, v43, v3, v4, v5, v6, v7, v8, v9, v10, v44, v19, v27, v42, v35)
        del v42; del v44
        v46 = US1_1(v35)
        v47 = US1_1(v27)
        v48 = US1_1(v19)
        v49 = UH0_0(v48, v13)
        del v48
        v50 = UH0_0(v47, v49)
        del v47; del v49
        v51 = UH0_0(v46, v50)
        del v46; del v50
        v52 = US1_1(v35)
        v53 = US1_1(v27)
        v54 = US1_1(v19)
        v55 = UH0_0(v54, v16)
        del v54
        v56 = UH0_0(v53, v55)
        del v53; del v55
        v57 = UH0_0(v52, v56)
        del v52; del v56
        return v45(v41, v40, v51, v14, v15, v57, v17, v18)
cdef class Closure20():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef float v18
    cdef float v19
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17, float v18, float v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, float v20, float v21, US0 v22):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef bint v23
        cdef float v24
        cdef float v25
        cdef US1 v26
        cdef UH0 v27
        cdef US1 v28
        cdef UH0 v29
        cdef float v31
        cdef float v32
        cdef US1 v33
        cdef UH0 v34
        cdef US1 v35
        cdef UH0 v36
        v23 = v0 == (<unsigned char>0)
        if v23:
            v24 = v21 + v17
            v25 = v20 + v16
            v26 = US1_0(v22)
            v27 = UH0_0(v26, v15)
            del v26
            v28 = US1_0(v22)
            v29 = UH0_0(v28, v12)
            del v28
            return method42(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US1_0(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US1_0(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method42(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure19():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef signed long v10
    cdef object v11
    cdef object v12
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, signed long v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef signed long v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef object v21
        v21 = Closure20(v2, v9, v4, v5, v6, v3, v0, v1, v10, v11, v7, v12, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH1_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v21)
cdef class Closure18():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef signed long v8
    cdef signed long v9
    cdef object v10
    cdef object v11
    cdef object v12
    cdef UH0 v13
    cdef float v14
    cdef float v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef float v19
    cdef float v20
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18, float v19, float v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, float v21, float v22, US0 v23):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef signed long v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef bint v24
        cdef float v25
        cdef float v26
        cdef US1 v27
        cdef UH0 v28
        cdef US1 v29
        cdef UH0 v30
        cdef float v32
        cdef float v33
        cdef US1 v34
        cdef UH0 v35
        cdef US1 v36
        cdef UH0 v37
        v24 = v0 == (<unsigned char>0)
        if v24:
            v25 = v22 + v18
            v26 = v21 + v17
            v27 = US1_0(v23)
            v28 = UH0_0(v27, v16)
            del v27
            v29 = US1_0(v23)
            v30 = UH0_0(v29, v13)
            del v29
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US1_0(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US1_0(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure17():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed long v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef object v9
    cdef bint v10
    cdef signed long v11
    cdef object v12
    cdef object v13
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed long v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef signed long v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef object v22
        v22 = Closure18(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v12, v8, v13, v19, v20, v21, v16, v17, v18, v14, v15)
        return UH1_0(v14, v15, v16, v17, v18, v19, v20, v21, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v22)
cdef class Tuple3:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed long v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed long v15
    cdef readonly object v16
    cdef readonly unsigned char v17
    cdef readonly object v18
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed long v11, signed char v12, signed char v13, unsigned char v14, signed long v15, v16, unsigned char v17, v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
cdef class Mut1:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
cdef class Tuple4:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US0 v2
    def __init__(self, float v0, float v1, US0 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public signed long v1
    def __init__(self, unsigned long long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure21():
    cdef object v0
    cdef unsigned char v1
    cdef signed long v2
    cdef object v3
    def __init__(self, v0, unsigned char v1, signed long v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef signed long v2 = self.v2
        cdef object v3 = self.v3
        cdef US0 v4
        cdef UH1 v5
        v4 = US0_0()
        v5 = v3((<float>0.000000), (<float>0.000000), v4)
        del v4
        method43(v0, v1, v2, v5)
cdef class Closure22():
    cdef object v0
    cdef unsigned char v1
    cdef signed long v2
    cdef object v3
    def __init__(self, v0, unsigned char v1, signed long v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef signed long v2 = self.v2
        cdef object v3 = self.v3
        cdef US0 v4
        cdef UH1 v5
        v4 = US0_1()
        v5 = v3((<float>0.000000), (<float>0.000000), v4)
        del v4
        method43(v0, v1, v2, v5)
cdef class Closure23():
    cdef object v0
    cdef unsigned char v1
    cdef signed long v2
    cdef object v3
    def __init__(self, v0, unsigned char v1, signed long v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, signed long v4):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef signed long v2 = self.v2
        cdef object v3 = self.v3
        cdef US0 v5
        cdef UH1 v6
        v5 = US0_2(v4)
        v6 = v3((<float>0.000000), (<float>0.000000), v5)
        del v5
        method43(v0, v1, v2, v6)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, signed long v0, unsigned char v1, v2):
        cdef numpy.ndarray[signed char,ndim=1] v3
        cdef numpy.ndarray[object,ndim=1] v4
        cdef Mut0 v5
        cdef signed long v7
        cdef bint v8
        cdef US0 v16
        cdef bint v10
        cdef signed long v12
        cdef signed long v13
        cdef signed long v17
        cdef UH0 v18
        cdef float v19
        cdef float v20
        cdef UH0 v21
        cdef float v22
        cdef float v23
        cdef signed char v24
        cdef unsigned long long v25
        cdef float v26
        cdef float v27
        cdef float v28
        cdef numpy.ndarray[signed char,ndim=1] v29
        cdef signed char v30
        cdef unsigned long long v31
        cdef float v32
        cdef float v33
        cdef float v34
        cdef float v35
        cdef numpy.ndarray[signed char,ndim=1] v36
        cdef signed char v37
        cdef unsigned long long v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef numpy.ndarray[signed char,ndim=1] v43
        cdef signed char v44
        cdef unsigned long long v45
        cdef float v46
        cdef float v47
        cdef float v48
        cdef float v49
        cdef numpy.ndarray[signed char,ndim=1] v50
        cdef bint v51
        cdef unsigned char v52
        cdef signed long v53
        cdef unsigned char v54
        cdef signed long v55
        cdef numpy.ndarray[signed char,ndim=1] v56
        cdef object v57
        cdef US1 v58
        cdef US1 v59
        cdef UH0 v60
        cdef UH0 v61
        cdef US1 v62
        cdef US1 v63
        cdef UH0 v64
        cdef UH0 v65
        cdef UH1 v66
        v3 = numpy.arange(0,52,dtype=numpy.int8)
        numpy.random.shuffle(v3)
        v4 = numpy.empty(v0,dtype=object)
        v5 = Mut0((<signed long>0))
        while method0(v0, v5):
            v7 = v5.v0
            v8 = v7 == (<signed long>0)
            if v8:
                v16 = US0_1()
            else:
                v10 = v7 == (<signed long>1)
                if v10:
                    v16 = US0_0()
                else:
                    v12 = v0 - v7
                    v13 = v12 + (<signed long>2)
                    v16 = US0_2(v13)
            v4[v7] = v16
            del v16
            v17 = v7 + (<signed long>1)
            v5.v0 = v17
        del v5
        v18 = UH0_1()
        v19 = (<float>0.000000)
        v20 = (<float>0.000000)
        v21 = UH0_1()
        v22 = (<float>0.000000)
        v23 = (<float>0.000000)
        v24 = v3[(<unsigned long long>0)]
        v25 = len(v3)
        v26 = <float>v25
        v27 = (<float>1.000000) / v26
        v28 = libc.math.log(v27)
        v29 = v3[1:]
        del v3
        v30 = v29[(<unsigned long long>0)]
        v31 = len(v29)
        v32 = <float>v31
        v33 = (<float>1.000000) / v32
        v34 = libc.math.log(v33)
        v35 = v34 + v28
        v36 = v29[1:]
        del v29
        v37 = v36[(<unsigned long long>0)]
        v38 = len(v36)
        v39 = <float>v38
        v40 = (<float>1.000000) / v39
        v41 = libc.math.log(v40)
        v42 = v41 + v35
        v43 = v36[1:]
        del v36
        v44 = v43[(<unsigned long long>0)]
        v45 = len(v43)
        v46 = <float>v45
        v47 = (<float>1.000000) / v46
        v48 = libc.math.log(v47)
        v49 = v48 + v42
        v50 = v43[1:]
        del v43
        v51 = 1
        v52 = (<unsigned char>0)
        v53 = (<signed long>1)
        v54 = (<unsigned char>1)
        v55 = (<signed long>2)
        v56 = numpy.empty(0,dtype=numpy.int8)
        
        v57 = method1(v0, v4, v51, v37, v44, v54, v55, v24, v30, v52, v53, v56, v50)
        del v4; del v50; del v56
        v58 = US1_1(v30)
        v59 = US1_1(v24)
        v60 = UH0_0(v59, v18)
        del v18; del v59
        v61 = UH0_0(v58, v60)
        del v58; del v60
        v62 = US1_1(v44)
        v63 = US1_1(v37)
        v64 = UH0_0(v63, v21)
        del v21; del v63
        v65 = UH0_0(v62, v64)
        del v62; del v64
        v66 = v57(v49, v49, v61, v19, v20, v65, v22, v23)
        del v57; del v61; del v65
        method43(v2, v1, v0, v66)
cdef bint method0(signed long v0, Mut0 v1) except *:
    cdef signed long v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple0 method11(unsigned long long v0, signed char v1, signed char v2):
    cdef bint v3
    cdef signed char v4
    cdef bint v5
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef bint v57
    cdef signed char v15
    cdef bint v16
    cdef signed char v18
    cdef signed char v19
    cdef signed long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef bint v23
    cdef bint v24
    cdef signed char v25
    cdef bint v26
    cdef signed char v28
    cdef signed char v29
    cdef signed long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef bint v33
    cdef bint v34
    cdef signed char v35
    cdef bint v36
    cdef signed char v38
    cdef signed char v39
    cdef signed long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef bint v43
    cdef bint v44
    cdef bint v45
    cdef signed char v47
    cdef signed char v48
    cdef signed long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef signed char v59
    cdef signed char v60
    cdef signed char v61
    cdef bint v62
    cdef signed char v64
    cdef signed char v65
    cdef signed char v66
    cdef bint v67
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef bint v72
    cdef signed char v74
    cdef signed char v75
    cdef bint v76
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef signed char v93
    v3 = v2 < (<signed char>4)
    if v3:
        v4 = v1 + (<signed char>4)
        v5 = v4 < (<signed char>0)
        if v5:
            v7 = v4 + (<signed char>13)
        else:
            v7 = v4
        v8 = v2 * (<signed char>13)
        v9 = v8 + v7
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = v1 + (<signed char>3)
            v16 = v15 < (<signed char>0)
            if v16:
                v18 = v15 + (<signed char>13)
            else:
                v18 = v15
            v19 = v8 + v18
            v20 = <signed long>v19
            v21 = (<unsigned long long>1) << v20
            v22 = v0 & v21
            v23 = v22 == (<unsigned long long>0)
            v24 = v23 != 1
            if v24:
                v25 = v1 + (<signed char>2)
                v26 = v25 < (<signed char>0)
                if v26:
                    v28 = v25 + (<signed char>13)
                else:
                    v28 = v25
                v29 = v8 + v28
                v30 = <signed long>v29
                v31 = (<unsigned long long>1) << v30
                v32 = v0 & v31
                v33 = v32 == (<unsigned long long>0)
                v34 = v33 != 1
                if v34:
                    v35 = v1 + (<signed char>1)
                    v36 = v35 < (<signed char>0)
                    if v36:
                        v38 = v35 + (<signed char>13)
                    else:
                        v38 = v35
                    v39 = v8 + v38
                    v40 = <signed long>v39
                    v41 = (<unsigned long long>1) << v40
                    v42 = v0 & v41
                    v43 = v42 == (<unsigned long long>0)
                    v44 = v43 != 1
                    if v44:
                        v45 = v1 < (<signed char>0)
                        if v45:
                            v47 = v1 + (<signed char>13)
                        else:
                            v47 = v1
                        v48 = v8 + v47
                        v49 = <signed long>v48
                        v50 = (<unsigned long long>1) << v49
                        v51 = v0 & v50
                        v52 = v51 == (<unsigned long long>0)
                        v57 = v52 != 1
                    else:
                        v57 = 0
                else:
                    v57 = 0
            else:
                v57 = 0
        else:
            v57 = 0
        if v57:
            if v5:
                v59 = v4 + (<signed char>13)
            else:
                v59 = v4
            v60 = v8 + v59
            v61 = v1 + (<signed char>3)
            v62 = v61 < (<signed char>0)
            if v62:
                v64 = v61 + (<signed char>13)
            else:
                v64 = v61
            v65 = v8 + v64
            v66 = v1 + (<signed char>2)
            v67 = v66 < (<signed char>0)
            if v67:
                v69 = v66 + (<signed char>13)
            else:
                v69 = v66
            v70 = v8 + v69
            v71 = v1 + (<signed char>1)
            v72 = v71 < (<signed char>0)
            if v72:
                v74 = v71 + (<signed char>13)
            else:
                v74 = v71
            v75 = v8 + v74
            v76 = v1 < (<signed char>0)
            if v76:
                v78 = v1 + (<signed char>13)
            else:
                v78 = v1
            v79 = v8 + v78
            return Tuple0(v60, v65, v70, v75, v79, (<signed char>9))
        else:
            v80 = v2 + (<signed char>1)
            return method11(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method10(v0, v93)
cdef Tuple1 method14(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef signed long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef bint v15
    cdef bint v16
    cdef signed char v17
    cdef bint v18
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef unsigned char v42
    cdef signed char v48
    v9 = v2 < (<signed char>4)
    if v9:
        v10 = v2 * (<signed char>13)
        v11 = v10 + v1
        v12 = <signed long>v11
        v13 = (<unsigned long long>1) << v12
        v14 = v0 & v13
        v15 = v14 == (<unsigned long long>0)
        v16 = v15 != 1
        if v16:
            v17 = v2 + (<signed char>1)
            v18 = v3 == (<unsigned char>0)
            if v18:
                v37, v38, v39, v40, v41 = v11, v5, v6, v7, v8
            else:
                v19 = v3 == (<unsigned char>1)
                if v19:
                    v37, v38, v39, v40, v41 = v4, v11, v6, v7, v8
                else:
                    v20 = v3 == (<unsigned char>2)
                    if v20:
                        v37, v38, v39, v40, v41 = v4, v5, v11, v7, v8
                    else:
                        v21 = v3 == (<unsigned char>3)
                        if v21:
                            v37, v38, v39, v40, v41 = v4, v5, v6, v11, v8
                        else:
                            v37, v38, v39, v40, v41 = v4, v5, v6, v7, v11
            v42 = v3 + (<unsigned char>1)
            return method14(v0, v1, v17, v42, v37, v38, v39, v40, v41)
        else:
            v48 = v2 + (<signed char>1)
            return method14(v0, v1, v48, v3, v4, v5, v6, v7, v8)
    else:
        return Tuple1(v4, v5, v6, v7, v8)
cdef Tuple1 method13(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method13(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method14(v0, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple1(v3, v4, v5, v6, v7)
cdef Tuple2 method16(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
    cdef bint v8
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef bint v16
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef bint v17
    cdef bint v18
    cdef signed char v31
    cdef signed char v37
    v8 = v7 < (<signed char>4)
    if v8:
        v9 = v7 * (<signed char>13)
        v10 = v9 + v1
        v11 = <signed long>v10
        v12 = (<unsigned long long>1) << v11
        v13 = v0 & v12
        v14 = v13 == (<unsigned long long>0)
        v15 = v14 != 1
        if v15:
            v16 = v7 == (<signed char>0)
            if v16:
                v27, v28, v29, v30 = v10, v4, v5, v6
            else:
                v17 = v7 == (<signed char>1)
                if v17:
                    v27, v28, v29, v30 = v3, v10, v5, v6
                else:
                    v18 = v7 == (<signed char>2)
                    if v18:
                        v27, v28, v29, v30 = v3, v4, v10, v6
                    else:
                        v27, v28, v29, v30 = v3, v4, v5, v10
            v31 = v2 + (<signed char>1)
            v32, v33, v34, v35, v36 = v27, v28, v29, v30, v31
        else:
            v32, v33, v34, v35, v36 = v3, v4, v5, v6, v2
        v37 = v7 + (<signed char>1)
        return method16(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple2(v3, v4, v5, v6)
cdef Tuple0 method19(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef unsigned char v46
    cdef bint v16
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v40
    cdef bint v47
    cdef signed char v48
    v9 = v1 * (<signed char>13)
    v10 = v9 + v2
    v11 = <signed long>v10
    v12 = (<unsigned long long>1) << v11
    v13 = v0 & v12
    v14 = v13 == (<unsigned long long>0)
    v15 = v14 != 1
    if v15:
        v16 = v8 == (<unsigned char>0)
        if v16:
            v35, v36, v37, v38, v39 = v10, v4, v5, v6, v7
        else:
            v17 = v8 == (<unsigned char>1)
            if v17:
                v35, v36, v37, v38, v39 = v3, v10, v5, v6, v7
            else:
                v18 = v8 == (<unsigned char>2)
                if v18:
                    v35, v36, v37, v38, v39 = v3, v4, v10, v6, v7
                else:
                    v19 = v8 == (<unsigned char>3)
                    if v19:
                        v35, v36, v37, v38, v39 = v3, v4, v5, v10, v7
                    else:
                        v35, v36, v37, v38, v39 = v3, v4, v5, v6, v10
        v40 = v8 + (<unsigned char>1)
        v41, v42, v43, v44, v45, v46 = v35, v36, v37, v38, v39, v40
    else:
        v41, v42, v43, v44, v45, v46 = v3, v4, v5, v6, v7, v8
    v47 = v46 == (<unsigned char>5)
    if v47:
        return Tuple0(v41, v42, v43, v44, v45, (<signed char>6))
    else:
        v48 = v2 - (<signed char>1)
        return method19(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple1 method24(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
    cdef bint v10
    cdef bint v12
    cdef signed char v13
    cdef bint v19
    cdef signed char v20
    v10 = v3 == v1
    if v10:
        v12 = 1
    else:
        v12 = v3 == v2
    if v12:
        v13 = v3 - (<signed char>1)
        return method24(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method14(v0, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple1(v4, v5, v6, v7, v8)
cdef Tuple1 method26(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method14(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple1(v2, v3, v4, v5, v6)
cdef Tuple0 method25(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple2 tmp13
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple1 tmp14
    cdef signed char v56
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef signed char v72
    cdef signed char v73
    cdef signed char v74
    cdef unsigned char v75
    cdef signed char v76
    cdef signed char v77
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef Tuple1 tmp15
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>2)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp13 = method16(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3
            del tmp13
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp14 = method13(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3, tmp14.v4
            del tmp14
            return Tuple0(v40, v41, v51, v52, v53, (<signed char>2))
        else:
            v56 = v1 - (<signed char>1)
            return method25(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp15 = method26(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3, tmp15.v4
        del tmp15
        return Tuple0(v76, v77, v78, v79, v80, (<signed char>1))
cdef Tuple0 method23(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef bint v5
    cdef signed char v6
    cdef bint v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef unsigned char v19
    cdef signed char v20
    cdef signed long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned char v26
    cdef unsigned char v27
    cdef signed char v28
    cdef signed long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef bint v32
    cdef bint v33
    cdef unsigned char v34
    cdef unsigned char v35
    cdef signed char v36
    cdef signed long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef unsigned char v42
    cdef unsigned char v43
    cdef bint v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef Tuple2 tmp11
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef signed char v58
    cdef signed char v59
    cdef signed char v60
    cdef unsigned char v61
    cdef signed char v62
    cdef signed char v63
    cdef signed char v64
    cdef signed char v65
    cdef signed char v66
    cdef Tuple1 tmp12
    cdef signed char v67
    cdef signed char v80
    v5 = v1 == v4
    if v5:
        v6 = v4 - (<signed char>1)
        return method23(v0, v1, v2, v3, v6)
    else:
        v13 = (<signed char>0) <= v4
        if v13:
            v14 = <signed long>v4
            v15 = (<unsigned long long>1) << v14
            v16 = v0 & v15
            v17 = v16 == (<unsigned long long>0)
            v18 = v17 != 1
            if v18:
                v19 = (<unsigned char>1)
            else:
                v19 = (<unsigned char>0)
            v20 = (<signed char>13) + v4
            v21 = <signed long>v20
            v22 = (<unsigned long long>1) << v21
            v23 = v0 & v22
            v24 = v23 == (<unsigned long long>0)
            v25 = v24 != 1
            if v25:
                v26 = (<unsigned char>1)
            else:
                v26 = (<unsigned char>0)
            v27 = v19 + v26
            v28 = (<signed char>26) + v4
            v29 = <signed long>v28
            v30 = (<unsigned long long>1) << v29
            v31 = v0 & v30
            v32 = v31 == (<unsigned long long>0)
            v33 = v32 != 1
            if v33:
                v34 = (<unsigned char>1)
            else:
                v34 = (<unsigned char>0)
            v35 = v27 + v34
            v36 = (<signed char>39) + v4
            v37 = <signed long>v36
            v38 = (<unsigned long long>1) << v37
            v39 = v0 & v38
            v40 = v39 == (<unsigned long long>0)
            v41 = v40 != 1
            if v41:
                v42 = (<unsigned char>1)
            else:
                v42 = (<unsigned char>0)
            v43 = v35 + v42
            v44 = v43 == (<unsigned char>2)
            if v44:
                v45 = (<signed char>-1)
                v46 = (<signed char>-1)
                v47 = (<signed char>-1)
                v48 = (<signed char>-1)
                v49 = (<signed char>0)
                v50 = (<signed char>0)
                tmp11 = method16(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3
                del tmp11
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp12 = method24(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3, tmp12.v4
                del tmp12
                return Tuple0(v3, v2, v51, v52, v62, (<signed char>3))
            else:
                v67 = v4 - (<signed char>1)
                return method23(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method25(v0, v80)
cdef Tuple0 method22(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple2 tmp10
    cdef signed char v44
    cdef signed char v51
    cdef signed char v64
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>2)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp10 = method16(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3
            del tmp10
            v44 = (<signed char>12)
            return method23(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method22(v0, v51)
    else:
        v64 = (<signed char>12)
        return method25(v0, v64)
cdef Tuple0 method21(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple2 tmp8
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple1 tmp9
    cdef signed char v56
    cdef signed char v69
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>3)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp8 = method16(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3
            del tmp8
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp9 = method13(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3, tmp9.v4
            del tmp9
            return Tuple0(v40, v41, v42, v51, v52, (<signed char>4))
        else:
            v56 = v1 - (<signed char>1)
            return method21(v0, v56)
    else:
        v69 = (<signed char>12)
        return method22(v0, v69)
cdef Tuple0 method20(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef bint v4
    cdef signed char v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v11
    cdef bint v32
    cdef signed char v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef bint v16
    cdef bint v17
    cdef signed char v18
    cdef signed long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef signed char v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v155
    cdef signed char v33
    cdef bint v34
    cdef signed char v36
    cdef signed long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef bint v62
    cdef signed char v42
    cdef signed long v43
    cdef unsigned long long v44
    cdef unsigned long long v45
    cdef bint v46
    cdef bint v47
    cdef signed char v48
    cdef signed long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef bint v53
    cdef signed char v54
    cdef signed long v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef signed char v63
    cdef bint v64
    cdef signed char v66
    cdef signed long v67
    cdef unsigned long long v68
    cdef unsigned long long v69
    cdef bint v70
    cdef bint v71
    cdef bint v92
    cdef signed char v72
    cdef signed long v73
    cdef unsigned long long v74
    cdef unsigned long long v75
    cdef bint v76
    cdef bint v77
    cdef signed char v78
    cdef signed long v79
    cdef unsigned long long v80
    cdef unsigned long long v81
    cdef bint v82
    cdef bint v83
    cdef signed char v84
    cdef signed long v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef bint v88
    cdef signed char v93
    cdef bint v94
    cdef signed char v96
    cdef signed long v97
    cdef unsigned long long v98
    cdef unsigned long long v99
    cdef bint v100
    cdef bint v101
    cdef bint v122
    cdef signed char v102
    cdef signed long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef bint v106
    cdef bint v107
    cdef signed char v108
    cdef signed long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef bint v112
    cdef bint v113
    cdef signed char v114
    cdef signed long v115
    cdef unsigned long long v116
    cdef unsigned long long v117
    cdef bint v118
    cdef bint v123
    cdef signed char v125
    cdef signed long v126
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef bint v129
    cdef bint v130
    cdef signed char v131
    cdef signed long v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef bint v135
    cdef bint v136
    cdef signed char v137
    cdef signed long v138
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef bint v141
    cdef bint v142
    cdef signed char v143
    cdef signed long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef bint v147
    cdef signed char v157
    cdef signed char v158
    cdef signed char v159
    cdef signed char v160
    cdef signed char v161
    cdef signed char v162
    cdef signed char v163
    cdef signed char v164
    cdef signed char v165
    cdef signed char v166
    cdef signed char v167
    cdef Tuple2 tmp3
    cdef signed char v168
    cdef bint v169
    cdef signed char v171
    cdef signed char v172
    cdef signed char v173
    cdef signed char v174
    cdef signed char v175
    cdef signed char v176
    cdef signed char v177
    cdef signed char v178
    cdef signed char v179
    cdef signed char v180
    cdef signed char v181
    cdef Tuple2 tmp4
    cdef signed char v182
    cdef bint v183
    cdef signed char v185
    cdef signed char v186
    cdef signed char v187
    cdef signed char v188
    cdef signed char v189
    cdef signed char v190
    cdef signed char v191
    cdef signed char v192
    cdef signed char v193
    cdef signed char v194
    cdef signed char v195
    cdef Tuple2 tmp5
    cdef signed char v196
    cdef bint v197
    cdef signed char v199
    cdef signed char v200
    cdef signed char v201
    cdef signed char v202
    cdef signed char v203
    cdef signed char v204
    cdef signed char v205
    cdef signed char v206
    cdef signed char v207
    cdef signed char v208
    cdef signed char v209
    cdef Tuple2 tmp6
    cdef bint v210
    cdef signed char v212
    cdef signed char v213
    cdef signed char v214
    cdef signed char v215
    cdef signed char v216
    cdef signed char v217
    cdef signed char v218
    cdef signed char v219
    cdef signed char v220
    cdef signed char v221
    cdef signed char v222
    cdef Tuple2 tmp7
    cdef signed char v223
    cdef signed char v236
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = v1 + (<signed char>4)
        v4 = v3 < (<signed char>0)
        if v4:
            v6 = v3 + (<signed char>13)
        else:
            v6 = v3
        v7 = <signed long>v6
        v8 = (<unsigned long long>1) << v7
        v9 = v0 & v8
        v10 = v9 == (<unsigned long long>0)
        v11 = v10 != 1
        if v11:
            v12 = (<signed char>13) + v6
            v13 = <signed long>v12
            v14 = (<unsigned long long>1) << v13
            v15 = v0 & v14
            v16 = v15 == (<unsigned long long>0)
            v17 = v16 != 1
            if v17:
                v18 = (<signed char>26) + v6
                v19 = <signed long>v18
                v20 = (<unsigned long long>1) << v19
                v21 = v0 & v20
                v22 = v21 == (<unsigned long long>0)
                v23 = v22 != 1
                if v23:
                    v24 = (<signed char>39) + v6
                    v25 = <signed long>v24
                    v26 = (<unsigned long long>1) << v25
                    v27 = v0 & v26
                    v28 = v27 == (<unsigned long long>0)
                    v32 = v28 != 1
                else:
                    v32 = 0
            else:
                v32 = 0
        else:
            v32 = 0
        if v32:
            v33 = v1 + (<signed char>3)
            v34 = v33 < (<signed char>0)
            if v34:
                v36 = v33 + (<signed char>13)
            else:
                v36 = v33
            v37 = <signed long>v36
            v38 = (<unsigned long long>1) << v37
            v39 = v0 & v38
            v40 = v39 == (<unsigned long long>0)
            v41 = v40 != 1
            if v41:
                v42 = (<signed char>13) + v36
                v43 = <signed long>v42
                v44 = (<unsigned long long>1) << v43
                v45 = v0 & v44
                v46 = v45 == (<unsigned long long>0)
                v47 = v46 != 1
                if v47:
                    v48 = (<signed char>26) + v36
                    v49 = <signed long>v48
                    v50 = (<unsigned long long>1) << v49
                    v51 = v0 & v50
                    v52 = v51 == (<unsigned long long>0)
                    v53 = v52 != 1
                    if v53:
                        v54 = (<signed char>39) + v36
                        v55 = <signed long>v54
                        v56 = (<unsigned long long>1) << v55
                        v57 = v0 & v56
                        v58 = v57 == (<unsigned long long>0)
                        v62 = v58 != 1
                    else:
                        v62 = 0
                else:
                    v62 = 0
            else:
                v62 = 0
            if v62:
                v63 = v1 + (<signed char>2)
                v64 = v63 < (<signed char>0)
                if v64:
                    v66 = v63 + (<signed char>13)
                else:
                    v66 = v63
                v67 = <signed long>v66
                v68 = (<unsigned long long>1) << v67
                v69 = v0 & v68
                v70 = v69 == (<unsigned long long>0)
                v71 = v70 != 1
                if v71:
                    v72 = (<signed char>13) + v66
                    v73 = <signed long>v72
                    v74 = (<unsigned long long>1) << v73
                    v75 = v0 & v74
                    v76 = v75 == (<unsigned long long>0)
                    v77 = v76 != 1
                    if v77:
                        v78 = (<signed char>26) + v66
                        v79 = <signed long>v78
                        v80 = (<unsigned long long>1) << v79
                        v81 = v0 & v80
                        v82 = v81 == (<unsigned long long>0)
                        v83 = v82 != 1
                        if v83:
                            v84 = (<signed char>39) + v66
                            v85 = <signed long>v84
                            v86 = (<unsigned long long>1) << v85
                            v87 = v0 & v86
                            v88 = v87 == (<unsigned long long>0)
                            v92 = v88 != 1
                        else:
                            v92 = 0
                    else:
                        v92 = 0
                else:
                    v92 = 0
                if v92:
                    v93 = v1 + (<signed char>1)
                    v94 = v93 < (<signed char>0)
                    if v94:
                        v96 = v93 + (<signed char>13)
                    else:
                        v96 = v93
                    v97 = <signed long>v96
                    v98 = (<unsigned long long>1) << v97
                    v99 = v0 & v98
                    v100 = v99 == (<unsigned long long>0)
                    v101 = v100 != 1
                    if v101:
                        v102 = (<signed char>13) + v96
                        v103 = <signed long>v102
                        v104 = (<unsigned long long>1) << v103
                        v105 = v0 & v104
                        v106 = v105 == (<unsigned long long>0)
                        v107 = v106 != 1
                        if v107:
                            v108 = (<signed char>26) + v96
                            v109 = <signed long>v108
                            v110 = (<unsigned long long>1) << v109
                            v111 = v0 & v110
                            v112 = v111 == (<unsigned long long>0)
                            v113 = v112 != 1
                            if v113:
                                v114 = (<signed char>39) + v96
                                v115 = <signed long>v114
                                v116 = (<unsigned long long>1) << v115
                                v117 = v0 & v116
                                v118 = v117 == (<unsigned long long>0)
                                v122 = v118 != 1
                            else:
                                v122 = 0
                        else:
                            v122 = 0
                    else:
                        v122 = 0
                    if v122:
                        v123 = v1 < (<signed char>0)
                        if v123:
                            v125 = v1 + (<signed char>13)
                        else:
                            v125 = v1
                        v126 = <signed long>v125
                        v127 = (<unsigned long long>1) << v126
                        v128 = v0 & v127
                        v129 = v128 == (<unsigned long long>0)
                        v130 = v129 != 1
                        if v130:
                            v131 = (<signed char>13) + v125
                            v132 = <signed long>v131
                            v133 = (<unsigned long long>1) << v132
                            v134 = v0 & v133
                            v135 = v134 == (<unsigned long long>0)
                            v136 = v135 != 1
                            if v136:
                                v137 = (<signed char>26) + v125
                                v138 = <signed long>v137
                                v139 = (<unsigned long long>1) << v138
                                v140 = v0 & v139
                                v141 = v140 == (<unsigned long long>0)
                                v142 = v141 != 1
                                if v142:
                                    v143 = (<signed char>39) + v125
                                    v144 = <signed long>v143
                                    v145 = (<unsigned long long>1) << v144
                                    v146 = v0 & v145
                                    v147 = v146 == (<unsigned long long>0)
                                    v155 = v147 != 1
                                else:
                                    v155 = 0
                            else:
                                v155 = 0
                        else:
                            v155 = 0
                    else:
                        v155 = 0
                else:
                    v155 = 0
            else:
                v155 = 0
        else:
            v155 = 0
        if v155:
            if v4:
                v157 = v3 + (<signed char>13)
            else:
                v157 = v3
            v158 = (<signed char>-1)
            v159 = (<signed char>-1)
            v160 = (<signed char>-1)
            v161 = (<signed char>-1)
            v162 = (<signed char>0)
            v163 = (<signed char>0)
            tmp3 = method16(v0, v157, v162, v158, v159, v160, v161, v163)
            v164, v165, v166, v167 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3
            del tmp3
            v168 = v1 + (<signed char>3)
            v169 = v168 < (<signed char>0)
            if v169:
                v171 = v168 + (<signed char>13)
            else:
                v171 = v168
            v172 = (<signed char>-1)
            v173 = (<signed char>-1)
            v174 = (<signed char>-1)
            v175 = (<signed char>-1)
            v176 = (<signed char>0)
            v177 = (<signed char>0)
            tmp4 = method16(v0, v171, v176, v172, v173, v174, v175, v177)
            v178, v179, v180, v181 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3
            del tmp4
            v182 = v1 + (<signed char>2)
            v183 = v182 < (<signed char>0)
            if v183:
                v185 = v182 + (<signed char>13)
            else:
                v185 = v182
            v186 = (<signed char>-1)
            v187 = (<signed char>-1)
            v188 = (<signed char>-1)
            v189 = (<signed char>-1)
            v190 = (<signed char>0)
            v191 = (<signed char>0)
            tmp5 = method16(v0, v185, v190, v186, v187, v188, v189, v191)
            v192, v193, v194, v195 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3
            del tmp5
            v196 = v1 + (<signed char>1)
            v197 = v196 < (<signed char>0)
            if v197:
                v199 = v196 + (<signed char>13)
            else:
                v199 = v196
            v200 = (<signed char>-1)
            v201 = (<signed char>-1)
            v202 = (<signed char>-1)
            v203 = (<signed char>-1)
            v204 = (<signed char>0)
            v205 = (<signed char>0)
            tmp6 = method16(v0, v199, v204, v200, v201, v202, v203, v205)
            v206, v207, v208, v209 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3
            del tmp6
            v210 = v1 < (<signed char>0)
            if v210:
                v212 = v1 + (<signed char>13)
            else:
                v212 = v1
            v213 = (<signed char>-1)
            v214 = (<signed char>-1)
            v215 = (<signed char>-1)
            v216 = (<signed char>-1)
            v217 = (<signed char>0)
            v218 = (<signed char>0)
            tmp7 = method16(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3
            del tmp7
            return Tuple0(v164, v178, v192, v206, v219, (<signed char>5))
        else:
            v223 = v1 - (<signed char>1)
            return method20(v0, v223)
    else:
        v236 = (<signed char>12)
        return method21(v0, v236)
cdef Tuple0 method18(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
    cdef bint v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v11
    cdef unsigned char v46
    cdef unsigned char v47
    cdef unsigned char v48
    cdef unsigned char v49
    cdef unsigned char v12
    cdef signed char v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef unsigned char v19
    cdef signed char v20
    cdef signed long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned char v26
    cdef signed char v27
    cdef signed long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef bint v31
    cdef bint v32
    cdef unsigned char v33
    cdef bint v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef unsigned char v58
    cdef bint v65
    cdef signed char v66
    cdef signed char v67
    cdef signed char v68
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef signed char v72
    cdef unsigned char v73
    cdef bint v80
    cdef signed char v81
    cdef signed char v82
    cdef signed char v83
    cdef signed char v84
    cdef signed char v85
    cdef signed char v86
    cdef signed char v87
    cdef unsigned char v88
    cdef bint v95
    cdef signed char v96
    cdef signed char v97
    cdef signed char v98
    cdef signed char v99
    cdef signed char v100
    cdef signed char v101
    cdef signed char v102
    cdef unsigned char v103
    cdef signed char v110
    cdef signed char v141
    v6 = (<signed char>0) <= v1
    if v6:
        v7 = <signed long>v1
        v8 = (<unsigned long long>1) << v7
        v9 = v0 & v8
        v10 = v9 == (<unsigned long long>0)
        v11 = v10 != 1
        if v11:
            v12 = v2 + (<unsigned char>1)
            v46, v47, v48, v49 = v12, v3, v4, v5
        else:
            v13 = (<signed char>13) + v1
            v14 = <signed long>v13
            v15 = (<unsigned long long>1) << v14
            v16 = v0 & v15
            v17 = v16 == (<unsigned long long>0)
            v18 = v17 != 1
            if v18:
                v19 = v3 + (<unsigned char>1)
                v46, v47, v48, v49 = v2, v19, v4, v5
            else:
                v20 = (<signed char>26) + v1
                v21 = <signed long>v20
                v22 = (<unsigned long long>1) << v21
                v23 = v0 & v22
                v24 = v23 == (<unsigned long long>0)
                v25 = v24 != 1
                if v25:
                    v26 = v4 + (<unsigned char>1)
                    v46, v47, v48, v49 = v2, v3, v26, v5
                else:
                    v27 = (<signed char>39) + v1
                    v28 = <signed long>v27
                    v29 = (<unsigned long long>1) << v28
                    v30 = v0 & v29
                    v31 = v30 == (<unsigned long long>0)
                    v32 = v31 != 1
                    if v32:
                        v33 = v5 + (<unsigned char>1)
                        v46, v47, v48, v49 = v2, v3, v4, v33
                    else:
                        v46, v47, v48, v49 = v2, v3, v4, v5
        v50 = (<unsigned char>5) == v46
        if v50:
            v51 = (<signed char>0)
            v52 = (<signed char>12)
            v53 = (<signed char>-1)
            v54 = (<signed char>-1)
            v55 = (<signed char>-1)
            v56 = (<signed char>-1)
            v57 = (<signed char>-1)
            v58 = (<unsigned char>0)
            return method19(v0, v51, v52, v53, v54, v55, v56, v57, v58)
        else:
            v65 = (<unsigned char>5) == v47
            if v65:
                v66 = (<signed char>1)
                v67 = (<signed char>12)
                v68 = (<signed char>-1)
                v69 = (<signed char>-1)
                v70 = (<signed char>-1)
                v71 = (<signed char>-1)
                v72 = (<signed char>-1)
                v73 = (<unsigned char>0)
                return method19(v0, v66, v67, v68, v69, v70, v71, v72, v73)
            else:
                v80 = (<unsigned char>5) == v48
                if v80:
                    v81 = (<signed char>2)
                    v82 = (<signed char>12)
                    v83 = (<signed char>-1)
                    v84 = (<signed char>-1)
                    v85 = (<signed char>-1)
                    v86 = (<signed char>-1)
                    v87 = (<signed char>-1)
                    v88 = (<unsigned char>0)
                    return method19(v0, v81, v82, v83, v84, v85, v86, v87, v88)
                else:
                    v95 = (<unsigned char>5) == v49
                    if v95:
                        v96 = (<signed char>3)
                        v97 = (<signed char>12)
                        v98 = (<signed char>-1)
                        v99 = (<signed char>-1)
                        v100 = (<signed char>-1)
                        v101 = (<signed char>-1)
                        v102 = (<signed char>-1)
                        v103 = (<unsigned char>0)
                        return method19(v0, v96, v97, v98, v99, v100, v101, v102, v103)
                    else:
                        v110 = v1 - (<signed char>1)
                        return method18(v0, v110, v46, v47, v48, v49)
    else:
        v141 = (<signed char>8)
        return method20(v0, v141)
cdef Tuple0 method17(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
    cdef bint v6
    cdef signed char v7
    cdef bint v14
    cdef signed long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v20
    cdef signed char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    cdef bint v26
    cdef unsigned char v27
    cdef unsigned char v28
    cdef signed char v29
    cdef signed long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef bint v33
    cdef bint v34
    cdef unsigned char v35
    cdef unsigned char v36
    cdef signed char v37
    cdef signed long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef bint v41
    cdef bint v42
    cdef unsigned char v43
    cdef unsigned char v44
    cdef bint v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple2 tmp2
    cdef signed char v56
    cdef signed char v69
    cdef unsigned char v70
    cdef unsigned char v71
    cdef unsigned char v72
    cdef unsigned char v73
    v6 = v1 == v5
    if v6:
        v7 = v5 - (<signed char>1)
        return method17(v0, v1, v2, v3, v4, v7)
    else:
        v14 = (<signed char>0) <= v5
        if v14:
            v15 = <signed long>v5
            v16 = (<unsigned long long>1) << v15
            v17 = v0 & v16
            v18 = v17 == (<unsigned long long>0)
            v19 = v18 != 1
            if v19:
                v20 = (<unsigned char>1)
            else:
                v20 = (<unsigned char>0)
            v21 = (<signed char>13) + v5
            v22 = <signed long>v21
            v23 = (<unsigned long long>1) << v22
            v24 = v0 & v23
            v25 = v24 == (<unsigned long long>0)
            v26 = v25 != 1
            if v26:
                v27 = (<unsigned char>1)
            else:
                v27 = (<unsigned char>0)
            v28 = v20 + v27
            v29 = (<signed char>26) + v5
            v30 = <signed long>v29
            v31 = (<unsigned long long>1) << v30
            v32 = v0 & v31
            v33 = v32 == (<unsigned long long>0)
            v34 = v33 != 1
            if v34:
                v35 = (<unsigned char>1)
            else:
                v35 = (<unsigned char>0)
            v36 = v28 + v35
            v37 = (<signed char>39) + v5
            v38 = <signed long>v37
            v39 = (<unsigned long long>1) << v38
            v40 = v0 & v39
            v41 = v40 == (<unsigned long long>0)
            v42 = v41 != 1
            if v42:
                v43 = (<unsigned char>1)
            else:
                v43 = (<unsigned char>0)
            v44 = v36 + v43
            v45 = v44 <= (<unsigned char>2)
            if v45:
                v46 = (<signed char>-1)
                v47 = (<signed char>-1)
                v48 = (<signed char>-1)
                v49 = (<signed char>-1)
                v50 = (<signed char>0)
                v51 = (<signed char>0)
                tmp2 = method16(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3
                del tmp2
                return Tuple0(v4, v3, v2, v52, v53, (<signed char>7))
            else:
                v56 = v5 - (<signed char>1)
                return method17(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method18(v0, v69, v70, v71, v72, v73)
cdef Tuple0 method15(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple2 tmp1
    cdef signed char v44
    cdef signed char v51
    cdef signed char v64
    cdef unsigned char v65
    cdef unsigned char v66
    cdef unsigned char v67
    cdef unsigned char v68
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>3)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp1 = method16(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3
            del tmp1
            v44 = (<signed char>12)
            return method17(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method15(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method18(v0, v64, v65, v66, v67, v68)
cdef Tuple0 method12(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef unsigned char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef Tuple1 tmp0
    cdef signed char v46
    cdef signed char v59
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>4)
        if v33:
            v34 = (<signed char>12)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>-1)
            v39 = (<signed char>-1)
            v40 = (<unsigned char>0)
            tmp0 = method13(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4
            del tmp0
            return Tuple0(v1, v9, v17, v25, v41, (<signed char>8))
        else:
            v46 = v1 - (<signed char>1)
            return method12(v0, v46)
    else:
        v59 = (<signed char>12)
        return method15(v0, v59)
cdef Tuple0 method10(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method11(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method12(v0, v10)
cdef Tuple0 method9(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6):
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef signed long v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef signed long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef signed char v28
    v7 = <signed long>v6
    v8 = (<unsigned long long>1) << v7
    v9 = (<unsigned long long>0) | v8
    v10 = <signed long>v5
    v11 = (<unsigned long long>1) << v10
    v12 = v9 | v11
    v13 = <signed long>v4
    v14 = (<unsigned long long>1) << v13
    v15 = v12 | v14
    v16 = <signed long>v3
    v17 = (<unsigned long long>1) << v16
    v18 = v15 | v17
    v19 = <signed long>v2
    v20 = (<unsigned long long>1) << v19
    v21 = v18 | v20
    v22 = <signed long>v1
    v23 = (<unsigned long long>1) << v22
    v24 = v21 | v23
    v25 = <signed long>v0
    v26 = (<unsigned long long>1) << v25
    v27 = v24 | v26
    v28 = (<signed char>8)
    return method10(v27, v28)
cdef object method8(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed char v9, signed char v10, unsigned char v11, signed long v12):
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed long v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed long v21
    cdef numpy.ndarray[signed char,ndim=1] v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef Tuple0 tmp16
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef Tuple0 tmp17
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef bint v45
    cdef signed long v48
    cdef bint v46
    cdef bint v49
    cdef signed long v78
    cdef bint v50
    cdef signed long v53
    cdef bint v51
    cdef bint v54
    cdef bint v55
    cdef signed long v58
    cdef bint v56
    cdef bint v59
    cdef bint v60
    cdef signed long v63
    cdef bint v61
    cdef bint v64
    cdef bint v65
    cdef signed long v68
    cdef bint v66
    cdef bint v69
    cdef bint v70
    cdef bint v71
    cdef bint v79
    cdef float v80
    cdef bint v82
    cdef float v83
    cdef signed long v85
    cdef float v86
    v13 = v11 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v9, v10, v11, v12, v5, v6, v7, v8
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v5, v6, v7, v8, v9, v10, v11, v12
    v22 = numpy.empty(5,dtype=numpy.int8)
    v22[0] = v0; v22[1] = v1; v22[2] = v2; v22[3] = v3; v22[4] = v4
    tmp16 = method9(v4, v3, v2, v1, v0, v15, v14)
    v23, v24, v25, v26, v27, v28 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3, tmp16.v4, tmp16.v5
    del tmp16
    tmp17 = method9(v4, v3, v2, v1, v0, v19, v18)
    v29, v30, v31, v32, v33, v34 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3, tmp17.v4, tmp17.v5
    del tmp17
    v35 = v23 % (<signed char>13)
    v36 = v24 % (<signed char>13)
    v37 = v25 % (<signed char>13)
    v38 = v26 % (<signed char>13)
    v39 = v27 % (<signed char>13)
    v40 = v29 % (<signed char>13)
    v41 = v30 % (<signed char>13)
    v42 = v31 % (<signed char>13)
    v43 = v32 % (<signed char>13)
    v44 = v33 % (<signed char>13)
    v45 = v28 < v34
    if v45:
        v48 = (<signed long>-1)
    else:
        v46 = v28 > v34
        if v46:
            v48 = (<signed long>1)
        else:
            v48 = (<signed long>0)
    v49 = v48 == (<signed long>0)
    if v49:
        v50 = v35 < v40
        if v50:
            v53 = (<signed long>-1)
        else:
            v51 = v35 > v40
            if v51:
                v53 = (<signed long>1)
            else:
                v53 = (<signed long>0)
        v54 = v53 == (<signed long>0)
        if v54:
            v55 = v36 < v41
            if v55:
                v58 = (<signed long>-1)
            else:
                v56 = v36 > v41
                if v56:
                    v58 = (<signed long>1)
                else:
                    v58 = (<signed long>0)
            v59 = v58 == (<signed long>0)
            if v59:
                v60 = v37 < v42
                if v60:
                    v63 = (<signed long>-1)
                else:
                    v61 = v37 > v42
                    if v61:
                        v63 = (<signed long>1)
                    else:
                        v63 = (<signed long>0)
                v64 = v63 == (<signed long>0)
                if v64:
                    v65 = v38 < v43
                    if v65:
                        v68 = (<signed long>-1)
                    else:
                        v66 = v38 > v43
                        if v66:
                            v68 = (<signed long>1)
                        else:
                            v68 = (<signed long>0)
                    v69 = v68 == (<signed long>0)
                    if v69:
                        v70 = v39 < v44
                        if v70:
                            v78 = (<signed long>-1)
                        else:
                            v71 = v39 > v44
                            if v71:
                                v78 = (<signed long>1)
                            else:
                                v78 = (<signed long>0)
                    else:
                        v78 = v68
                else:
                    v78 = v63
            else:
                v78 = v58
        else:
            v78 = v53
    else:
        v78 = v48
    v79 = v78 == (<signed long>0)
    if v79:
        v80 = <float>(<signed long>0)
        return Closure4(v14, v15, v16, v17, v18, v19, v20, v21, v22, v80)
    else:
        v82 = v78 == (<signed long>1)
        if v82:
            v83 = <float>v17
            return Closure4(v14, v15, v16, v17, v18, v19, v20, v21, v22, v83)
        else:
            v85 = -v17
            v86 = <float>v85
            return Closure4(v14, v15, v16, v17, v18, v19, v20, v21, v22, v86)
cdef object method29(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed char v9, signed char v10, unsigned char v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed long v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed long v20
    cdef numpy.ndarray[signed char,ndim=1] v21
    cdef signed char v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef Tuple0 tmp18
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef Tuple0 tmp19
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef bint v44
    cdef signed long v47
    cdef bint v45
    cdef bint v48
    cdef signed long v77
    cdef bint v49
    cdef signed long v52
    cdef bint v50
    cdef bint v53
    cdef bint v54
    cdef signed long v57
    cdef bint v55
    cdef bint v58
    cdef bint v59
    cdef signed long v62
    cdef bint v60
    cdef bint v63
    cdef bint v64
    cdef signed long v67
    cdef bint v65
    cdef bint v68
    cdef bint v69
    cdef bint v70
    cdef bint v78
    cdef float v79
    cdef bint v81
    cdef float v82
    cdef signed long v84
    cdef float v85
    v12 = v11 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v9, v10, v11, v8, v5, v6, v7, v8
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v5, v6, v7, v8, v9, v10, v11, v8
    v21 = numpy.empty(5,dtype=numpy.int8)
    v21[0] = v0; v21[1] = v1; v21[2] = v2; v21[3] = v3; v21[4] = v4
    tmp18 = method9(v4, v3, v2, v1, v0, v14, v13)
    v22, v23, v24, v25, v26, v27 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4, tmp18.v5
    del tmp18
    tmp19 = method9(v4, v3, v2, v1, v0, v18, v17)
    v28, v29, v30, v31, v32, v33 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3, tmp19.v4, tmp19.v5
    del tmp19
    v34 = v22 % (<signed char>13)
    v35 = v23 % (<signed char>13)
    v36 = v24 % (<signed char>13)
    v37 = v25 % (<signed char>13)
    v38 = v26 % (<signed char>13)
    v39 = v28 % (<signed char>13)
    v40 = v29 % (<signed char>13)
    v41 = v30 % (<signed char>13)
    v42 = v31 % (<signed char>13)
    v43 = v32 % (<signed char>13)
    v44 = v27 < v33
    if v44:
        v47 = (<signed long>-1)
    else:
        v45 = v27 > v33
        if v45:
            v47 = (<signed long>1)
        else:
            v47 = (<signed long>0)
    v48 = v47 == (<signed long>0)
    if v48:
        v49 = v34 < v39
        if v49:
            v52 = (<signed long>-1)
        else:
            v50 = v34 > v39
            if v50:
                v52 = (<signed long>1)
            else:
                v52 = (<signed long>0)
        v53 = v52 == (<signed long>0)
        if v53:
            v54 = v35 < v40
            if v54:
                v57 = (<signed long>-1)
            else:
                v55 = v35 > v40
                if v55:
                    v57 = (<signed long>1)
                else:
                    v57 = (<signed long>0)
            v58 = v57 == (<signed long>0)
            if v58:
                v59 = v36 < v41
                if v59:
                    v62 = (<signed long>-1)
                else:
                    v60 = v36 > v41
                    if v60:
                        v62 = (<signed long>1)
                    else:
                        v62 = (<signed long>0)
                v63 = v62 == (<signed long>0)
                if v63:
                    v64 = v37 < v42
                    if v64:
                        v67 = (<signed long>-1)
                    else:
                        v65 = v37 > v42
                        if v65:
                            v67 = (<signed long>1)
                        else:
                            v67 = (<signed long>0)
                    v68 = v67 == (<signed long>0)
                    if v68:
                        v69 = v38 < v43
                        if v69:
                            v77 = (<signed long>-1)
                        else:
                            v70 = v38 > v43
                            if v70:
                                v77 = (<signed long>1)
                            else:
                                v77 = (<signed long>0)
                    else:
                        v77 = v67
                else:
                    v77 = v62
            else:
                v77 = v57
        else:
            v77 = v52
    else:
        v77 = v47
    v78 = v77 == (<signed long>0)
    if v78:
        v79 = <float>(<signed long>0)
        return Closure4(v13, v14, v15, v16, v17, v18, v19, v20, v21, v79)
    else:
        v81 = v77 == (<signed long>1)
        if v81:
            v82 = <float>v16
            return Closure4(v13, v14, v15, v16, v17, v18, v19, v20, v21, v82)
        else:
            v84 = -v16
            v85 = <float>v84
            return Closure4(v13, v14, v15, v16, v17, v18, v19, v20, v21, v85)
cdef UH1 method30(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US0 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed long v32
    cdef float v33
    cdef signed long v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v28 = method28(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method29(v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v4
        else:
            v32 = v4
        v33 = <float>v32
        return UH1_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v4, v1, v2, v3, v4, v10, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US0_2>v16).v0
        v36 = 0
        v37 = method7(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method28(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef signed long v20
    cdef bint v21
    cdef signed long v22
    cdef bint v23
    cdef signed long v24
    cdef signed long v25
    cdef numpy.ndarray[object,ndim=1] v26
    v16 = v6 == v0
    if v16:
        return method29(v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v6 >= v6
        v19 = v6 < v6
        v20 = v6 + (<signed long>1)
        v21 = v0 < v20
        if v21:
            v22 = v0
        else:
            v22 = v20
        v23 = v0 == v6
        if v23:
            v24 = (<signed long>1)
        else:
            v24 = (<signed long>0)
        v25 = v22 + v24
        v26 = v1[(<signed long>1):3+v0-v25]
        return Closure7(v7, v8, v9, v6, v3, v4, v5, v10, v26, v2, v0, v1, v11, v12, v13, v14, v15)
cdef UH1 method27(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, US0 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
    cdef object v29
    cdef bint v26
    cdef bint v31
    cdef signed long v33
    cdef float v34
    cdef signed long v36
    cdef bint v37
    cdef object v38
    if v17.tag == 0: # call
        if v0:
            v26 = 0
            v29 = method28(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method29(v12, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
        return v29(v18, v19, v20, v21, v22, v23, v24, v25)
    elif v17.tag == 1: # fold
        v31 = v7 == (<unsigned char>0)
        if v31:
            v33 = -v8
        else:
            v33 = v8
        v34 = <float>v33
        return UH1_1(v18, v19, v20, v21, v22, v23, v24, v25, v5, v6, v7, v8, v1, v2, v3, v4, v11, v34)
    elif v17.tag == 2: # raiseTo_
        v36 = (<US0_2>v17).v0
        v37 = 0
        v38 = method7(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method7(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, signed long v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16):
    cdef bint v17
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef signed long v22
    cdef bint v23
    cdef signed long v24
    cdef signed long v25
    cdef bint v26
    cdef signed long v27
    cdef signed long v28
    cdef signed long v29
    cdef bint v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v33
    cdef signed long v34
    cdef numpy.ndarray[object,ndim=1] v35
    v17 = v10 == v0
    if v17:
        return method8(v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v19 = v10 == v6
        v20 = v19 != 1
        v21 = v10 >= v6
        if v21:
            v22 = v10
        else:
            v22 = v6
        v23 = v10 < v6
        if v23:
            v24 = v10
        else:
            v24 = v6
        v25 = v22 - v24
        v26 = (<signed long>1) >= v25
        if v26:
            v27 = (<signed long>1)
        else:
            v27 = v25
        v28 = v22 + v27
        if v20:
            v29 = (<signed long>0)
        else:
            v29 = (<signed long>1)
        v30 = v0 < v28
        if v30:
            v31 = v0
        else:
            v31 = v28
        v32 = v0 == v22
        if v32:
            v33 = (<signed long>1)
        else:
            v33 = (<signed long>0)
        v34 = v31 + v33
        v35 = v1[v29:3+v0-v34]
        return Closure5(v7, v8, v9, v10, v3, v4, v5, v6, v11, v35, v2, v0, v1, v12, v13, v14, v15, v16)
cdef object method6(signed long v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, numpy.ndarray[signed char,ndim=1] v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed long v10, signed char v11, signed char v12, unsigned char v13, signed long v14):
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed long v19
    cdef signed char v20
    cdef signed char v21
    cdef unsigned char v22
    cdef signed long v23
    v15 = v13 == (<unsigned char>0)
    if v15:
        v16, v17, v18, v19, v20, v21, v22, v23 = v11, v12, v13, v14, v7, v8, v9, v10
    else:
        v16, v17, v18, v19, v20, v21, v22, v23 = v7, v8, v9, v10, v11, v12, v13, v14
    return Closure3(v5, v0, v1, v2, v3, v4, v6, v20, v21, v22, v23, v16, v17, v18, v19)
cdef object method33(signed long v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, numpy.ndarray[signed char,ndim=1] v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed long v10, signed char v11, signed char v12, unsigned char v13):
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed long v18
    cdef signed char v19
    cdef signed char v20
    cdef unsigned char v21
    cdef signed long v22
    v14 = v13 == (<unsigned char>0)
    if v14:
        v15, v16, v17, v18, v19, v20, v21, v22 = v11, v12, v13, v10, v7, v8, v9, v10
    else:
        v15, v16, v17, v18, v19, v20, v21, v22 = v7, v8, v9, v10, v11, v12, v13, v10
    return Closure3(v5, v0, v1, v2, v3, v4, v6, v19, v20, v21, v22, v15, v16, v17, v18)
cdef UH1 method34(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US0 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed long v32
    cdef float v33
    cdef signed long v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v28 = method32(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method33(v8, v9, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v4
        else:
            v32 = v4
        v33 = <float>v32
        return UH1_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v4, v1, v2, v3, v4, v10, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US0_2>v16).v0
        v36 = 0
        v37 = method5(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method32(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef signed long v20
    cdef bint v21
    cdef signed long v22
    cdef bint v23
    cdef signed long v24
    cdef signed long v25
    cdef numpy.ndarray[object,ndim=1] v26
    v16 = v6 == v0
    if v16:
        return method33(v0, v1, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v6 >= v6
        v19 = v6 < v6
        v20 = v6 + (<signed long>1)
        v21 = v0 < v20
        if v21:
            v22 = v0
        else:
            v22 = v20
        v23 = v0 == v6
        if v23:
            v24 = (<signed long>1)
        else:
            v24 = (<signed long>0)
        v25 = v22 + v24
        v26 = v1[(<signed long>1):3+v0-v25]
        return Closure11(v7, v8, v9, v6, v3, v4, v5, v10, v26, v2, v0, v1, v11, v12, v13, v14, v15)
cdef UH1 method31(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, US0 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
    cdef object v29
    cdef bint v26
    cdef bint v31
    cdef signed long v33
    cdef float v34
    cdef signed long v36
    cdef bint v37
    cdef object v38
    if v17.tag == 0: # call
        if v0:
            v26 = 0
            v29 = method32(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method33(v9, v10, v12, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
        return v29(v18, v19, v20, v21, v22, v23, v24, v25)
    elif v17.tag == 1: # fold
        v31 = v7 == (<unsigned char>0)
        if v31:
            v33 = -v8
        else:
            v33 = v8
        v34 = <float>v33
        return UH1_1(v18, v19, v20, v21, v22, v23, v24, v25, v5, v6, v7, v8, v1, v2, v3, v4, v11, v34)
    elif v17.tag == 2: # raiseTo_
        v36 = (<US0_2>v17).v0
        v37 = 0
        v38 = method5(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method5(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, signed long v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16):
    cdef bint v17
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef signed long v22
    cdef bint v23
    cdef signed long v24
    cdef signed long v25
    cdef bint v26
    cdef signed long v27
    cdef signed long v28
    cdef signed long v29
    cdef bint v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v33
    cdef signed long v34
    cdef numpy.ndarray[object,ndim=1] v35
    v17 = v10 == v0
    if v17:
        return method6(v0, v1, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v19 = v10 == v6
        v20 = v19 != 1
        v21 = v10 >= v6
        if v21:
            v22 = v10
        else:
            v22 = v6
        v23 = v10 < v6
        if v23:
            v24 = v10
        else:
            v24 = v6
        v25 = v22 - v24
        v26 = (<signed long>1) >= v25
        if v26:
            v27 = (<signed long>1)
        else:
            v27 = v25
        v28 = v22 + v27
        if v20:
            v29 = (<signed long>0)
        else:
            v29 = (<signed long>1)
        v30 = v0 < v28
        if v30:
            v31 = v0
        else:
            v31 = v28
        v32 = v0 == v22
        if v32:
            v33 = (<signed long>1)
        else:
            v33 = (<signed long>0)
        v34 = v31 + v33
        v35 = v1[v29:3+v0-v34]
        return Closure9(v7, v8, v9, v10, v3, v4, v5, v6, v11, v35, v2, v0, v1, v12, v13, v14, v15, v16)
cdef object method4(signed long v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed long v9, signed char v10, signed char v11, unsigned char v12, signed long v13):
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed long v18
    cdef signed char v19
    cdef signed char v20
    cdef unsigned char v21
    cdef signed long v22
    v14 = v12 == (<unsigned char>0)
    if v14:
        v15, v16, v17, v18, v19, v20, v21, v22 = v10, v11, v12, v13, v6, v7, v8, v9
    else:
        v15, v16, v17, v18, v19, v20, v21, v22 = v6, v7, v8, v9, v10, v11, v12, v13
    return Closure2(v4, v0, v1, v2, v3, v5, v19, v20, v21, v22, v15, v16, v17, v18)
cdef object method37(signed long v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed long v9, signed char v10, signed char v11, unsigned char v12):
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed long v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed long v21
    v13 = v12 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v10, v11, v12, v9, v6, v7, v8, v9
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v6, v7, v8, v9, v10, v11, v12, v9
    return Closure2(v4, v0, v1, v2, v3, v5, v18, v19, v20, v21, v14, v15, v16, v17)
cdef UH1 method38(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US0 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
    cdef object v27
    cdef bint v24
    cdef bint v29
    cdef signed long v31
    cdef float v32
    cdef signed long v34
    cdef bint v35
    cdef object v36
    if v15.tag == 0: # call
        if v0:
            v24 = 0
            v27 = method36(v8, v9, v24, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14)
        else:
            v27 = method37(v8, v9, v11, v12, v13, v14, v1, v2, v3, v4, v5, v6, v7)
        return v27(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v29 = v7 == (<unsigned char>0)
        if v29:
            v31 = -v4
        else:
            v31 = v4
        v32 = <float>v31
        return UH1_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v4, v1, v2, v3, v4, v10, v32)
    elif v15.tag == 2: # raiseTo_
        v34 = (<US0_2>v15).v0
        v35 = 0
        v36 = method3(v8, v9, v35, v5, v6, v7, v34, v1, v2, v3, v4, v10, v11, v12, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method36(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
    cdef bint v15
    cdef bint v17
    cdef bint v18
    cdef signed long v19
    cdef bint v20
    cdef signed long v21
    cdef bint v22
    cdef signed long v23
    cdef signed long v24
    cdef numpy.ndarray[object,ndim=1] v25
    v15 = v6 == v0
    if v15:
        return method37(v0, v1, v11, v12, v13, v14, v3, v4, v5, v6, v7, v8, v9)
    else:
        v17 = v6 >= v6
        v18 = v6 < v6
        v19 = v6 + (<signed long>1)
        v20 = v0 < v19
        if v20:
            v21 = v0
        else:
            v21 = v19
        v22 = v0 == v6
        if v22:
            v23 = (<signed long>1)
        else:
            v23 = (<signed long>0)
        v24 = v21 + v23
        v25 = v1[(<signed long>1):3+v0-v24]
        return Closure15(v7, v8, v9, v6, v3, v4, v5, v10, v25, v2, v0, v1, v11, v12, v13, v14)
cdef UH1 method35(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US0 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed long v32
    cdef float v33
    cdef signed long v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v28 = method36(v9, v10, v25, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15)
        else:
            v28 = method37(v9, v10, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v8
        else:
            v32 = v8
        v33 = <float>v32
        return UH1_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v8, v1, v2, v3, v4, v11, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US0_2>v16).v0
        v36 = 0
        v37 = method3(v9, v10, v36, v5, v6, v7, v35, v1, v2, v3, v4, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method3(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, signed long v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef bint v20
    cdef signed long v21
    cdef bint v22
    cdef signed long v23
    cdef signed long v24
    cdef bint v25
    cdef signed long v26
    cdef signed long v27
    cdef signed long v28
    cdef bint v29
    cdef signed long v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef numpy.ndarray[object,ndim=1] v34
    v16 = v10 == v0
    if v16:
        return method4(v0, v1, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v18 = v10 == v6
        v19 = v18 != 1
        v20 = v10 >= v6
        if v20:
            v21 = v10
        else:
            v21 = v6
        v22 = v10 < v6
        if v22:
            v23 = v10
        else:
            v23 = v6
        v24 = v21 - v23
        v25 = (<signed long>1) >= v24
        if v25:
            v26 = (<signed long>1)
        else:
            v26 = v24
        v27 = v21 + v26
        if v19:
            v28 = (<signed long>0)
        else:
            v28 = (<signed long>1)
        v29 = v0 < v27
        if v29:
            v30 = v0
        else:
            v30 = v27
        v31 = v0 == v21
        if v31:
            v32 = (<signed long>1)
        else:
            v32 = (<signed long>0)
        v33 = v30 + v32
        v34 = v1[v28:3+v0-v33]
        return Closure13(v7, v8, v9, v10, v3, v4, v5, v6, v11, v34, v2, v0, v1, v12, v13, v14, v15)
cdef object method2(signed long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed char,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, signed long v10):
    cdef bint v11
    cdef signed char v12
    cdef signed char v13
    cdef unsigned char v14
    cdef signed long v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed long v19
    v11 = v9 == (<unsigned char>0)
    if v11:
        v12, v13, v14, v15, v16, v17, v18, v19 = v7, v8, v9, v10, v3, v4, v5, v6
    else:
        v12, v13, v14, v15, v16, v17, v18, v19 = v3, v4, v5, v6, v7, v8, v9, v10
    return Closure1(v2, v0, v1, v16, v17, v18, v19, v12, v13, v14, v15)
cdef object method41(signed long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed char,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9):
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed long v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed long v18
    v10 = v9 == (<unsigned char>0)
    if v10:
        v11, v12, v13, v14, v15, v16, v17, v18 = v7, v8, v9, v6, v3, v4, v5, v6
    else:
        v11, v12, v13, v14, v15, v16, v17, v18 = v3, v4, v5, v6, v7, v8, v9, v6
    return Closure1(v2, v0, v1, v15, v16, v17, v18, v11, v12, v13, v14)
cdef UH1 method42(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, US0 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
    cdef object v24
    cdef bint v21
    cdef bint v26
    cdef signed long v28
    cdef float v29
    cdef signed long v31
    cdef bint v32
    cdef object v33
    if v12.tag == 0: # call
        if v0:
            v21 = 0
            v24 = method40(v8, v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v24 = method41(v8, v9, v11, v1, v2, v3, v4, v5, v6, v7)
        return v24(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # fold
        v26 = v7 == (<unsigned char>0)
        if v26:
            v28 = -v4
        else:
            v28 = v4
        v29 = <float>v28
        return UH1_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v4, v1, v2, v3, v4, v10, v29)
    elif v12.tag == 2: # raiseTo_
        v31 = (<US0_2>v12).v0
        v32 = 0
        v33 = method1(v8, v9, v32, v5, v6, v7, v31, v1, v2, v3, v4, v10, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method40(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11):
    cdef bint v12
    cdef bint v14
    cdef bint v15
    cdef signed long v16
    cdef bint v17
    cdef signed long v18
    cdef bint v19
    cdef signed long v20
    cdef signed long v21
    cdef numpy.ndarray[object,ndim=1] v22
    v12 = v6 == v0
    if v12:
        return method41(v0, v1, v11, v3, v4, v5, v6, v7, v8, v9)
    else:
        v14 = v6 >= v6
        v15 = v6 < v6
        v16 = v6 + (<signed long>1)
        v17 = v0 < v16
        if v17:
            v18 = v0
        else:
            v18 = v16
        v19 = v0 == v6
        if v19:
            v20 = (<signed long>1)
        else:
            v20 = (<signed long>0)
        v21 = v18 + v20
        v22 = v1[(<signed long>1):3+v0-v21]
        return Closure19(v7, v8, v9, v6, v3, v4, v5, v10, v22, v2, v0, v1, v11)
cdef UH1 method39(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed long v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, US0 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
    cdef object v25
    cdef bint v22
    cdef bint v27
    cdef signed long v29
    cdef float v30
    cdef signed long v32
    cdef bint v33
    cdef object v34
    if v13.tag == 0: # call
        if v0:
            v22 = 0
            v25 = method40(v9, v10, v22, v5, v6, v7, v4, v1, v2, v3, v11, v12)
        else:
            v25 = method41(v9, v10, v12, v1, v2, v3, v4, v5, v6, v7)
        return v25(v14, v15, v16, v17, v18, v19, v20, v21)
    elif v13.tag == 1: # fold
        v27 = v7 == (<unsigned char>0)
        if v27:
            v29 = -v8
        else:
            v29 = v8
        v30 = <float>v29
        return UH1_1(v14, v15, v16, v17, v18, v19, v20, v21, v5, v6, v7, v8, v1, v2, v3, v4, v11, v30)
    elif v13.tag == 2: # raiseTo_
        v32 = (<US0_2>v13).v0
        v33 = 0
        v34 = method1(v9, v10, v33, v5, v6, v7, v32, v1, v2, v3, v4, v11, v12)
        return v34(v14, v15, v16, v17, v18, v19, v20, v21)
cdef object method1(signed long v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed long v6, signed char v7, signed char v8, unsigned char v9, signed long v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12):
    cdef bint v13
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed long v18
    cdef bint v19
    cdef signed long v20
    cdef signed long v21
    cdef bint v22
    cdef signed long v23
    cdef signed long v24
    cdef signed long v25
    cdef bint v26
    cdef signed long v27
    cdef bint v28
    cdef signed long v29
    cdef signed long v30
    cdef numpy.ndarray[object,ndim=1] v31
    v13 = v10 == v0
    if v13:
        return method2(v0, v1, v12, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v15 = v10 == v6
        v16 = v15 != 1
        v17 = v10 >= v6
        if v17:
            v18 = v10
        else:
            v18 = v6
        v19 = v10 < v6
        if v19:
            v20 = v10
        else:
            v20 = v6
        v21 = v18 - v20
        v22 = (<signed long>1) >= v21
        if v22:
            v23 = (<signed long>1)
        else:
            v23 = v21
        v24 = v18 + v23
        if v16:
            v25 = (<signed long>0)
        else:
            v25 = (<signed long>1)
        v26 = v0 < v24
        if v26:
            v27 = v0
        else:
            v27 = v24
        v28 = v0 == v18
        if v28:
            v29 = (<signed long>1)
        else:
            v29 = (<signed long>0)
        v30 = v27 + v29
        v31 = v1[v25:3+v0-v30]
        return Closure17(v7, v8, v9, v10, v3, v4, v5, v6, v11, v31, v2, v0, v1, v12)
cdef bint method45(unsigned long long v0, Mut1 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef UH1 method44(unsigned char v0, UH1 v1):
    cdef float v2
    cdef float v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned char v12
    cdef signed long v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed long v17
    cdef numpy.ndarray[signed char,ndim=1] v18
    cdef unsigned char v19
    cdef numpy.ndarray[object,ndim=1] v20
    cdef object v21
    cdef bint v22
    cdef list v23
    cdef unsigned long long v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef Mut1 v26
    cdef unsigned long long v28
    cdef float v29
    cdef float v30
    cdef UH0 v31
    cdef float v32
    cdef float v33
    cdef UH0 v34
    cdef float v35
    cdef float v36
    cdef signed char v37
    cdef signed char v38
    cdef unsigned char v39
    cdef signed long v40
    cdef signed char v41
    cdef signed char v42
    cdef unsigned char v43
    cdef signed long v44
    cdef numpy.ndarray[signed char,ndim=1] v45
    cdef unsigned char v46
    cdef numpy.ndarray[object,ndim=1] v47
    cdef Tuple3 tmp20
    cdef unsigned long long v48
    cdef float v49
    cdef float v50
    cdef float v51
    cdef US0 v52
    cdef unsigned long long v53
    cdef float v54
    cdef float v55
    cdef US0 v56
    cdef Tuple4 tmp21
    cdef float v59
    cdef float v60
    cdef float v62
    cdef float v63
    cdef float v65
    cdef float v66
    cdef signed char v67
    cdef signed char v68
    cdef unsigned char v69
    cdef signed long v70
    cdef signed char v71
    cdef signed char v72
    cdef unsigned char v73
    cdef signed long v74
    cdef float v76
    if v1.tag == 0: # action_
        v2 = (<UH1_0>v1).v0; v3 = (<UH1_0>v1).v1; v4 = (<UH1_0>v1).v2; v5 = (<UH1_0>v1).v3; v6 = (<UH1_0>v1).v4; v7 = (<UH1_0>v1).v5; v8 = (<UH1_0>v1).v6; v9 = (<UH1_0>v1).v7; v10 = (<UH1_0>v1).v8; v11 = (<UH1_0>v1).v9; v12 = (<UH1_0>v1).v10; v13 = (<UH1_0>v1).v11; v14 = (<UH1_0>v1).v12; v15 = (<UH1_0>v1).v13; v16 = (<UH1_0>v1).v14; v17 = (<UH1_0>v1).v15; v18 = (<UH1_0>v1).v16; v19 = (<UH1_0>v1).v17; v20 = (<UH1_0>v1).v18; v21 = (<UH1_0>v1).v19
        v22 = v19 == v0
        if v22:
            return v1
        else:
            v23 = [None]*(<unsigned long long>1)
            v23[(<unsigned long long>0)] = Tuple3(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20)
            v24 = len(v23)
            v25 = numpy.empty(v24,dtype=object)
            v26 = Mut1((<unsigned long long>0))
            while method45(v24, v26):
                v28 = v26.v0
                tmp20 = v23[v28]
                v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4, tmp20.v5, tmp20.v6, tmp20.v7, tmp20.v8, tmp20.v9, tmp20.v10, tmp20.v11, tmp20.v12, tmp20.v13, tmp20.v14, tmp20.v15, tmp20.v16, tmp20.v17, tmp20.v18
                del tmp20
                del v31; del v34; del v45
                v48 = len(v47)
                v49 = <float>v48
                v50 = (<float>1.000000) / v49
                v51 = libc.math.log(v50)
                v52 = numpy.random.choice(v47)
                del v47
                v25[v28] = Tuple4(v51, v51, v52)
                del v52
                v53 = v28 + (<unsigned long long>1)
                v26.v0 = v53
            del v23
            del v26
            tmp21 = v25[(<unsigned long long>0)]
            v54, v55, v56 = tmp21.v0, tmp21.v1, tmp21.v2
            del tmp21
            del v25
            return v21(v54, v55, v56)
    elif v1.tag == 1: # terminal_
        v59 = (<UH1_1>v1).v0; v60 = (<UH1_1>v1).v1; v62 = (<UH1_1>v1).v3; v63 = (<UH1_1>v1).v4; v65 = (<UH1_1>v1).v6; v66 = (<UH1_1>v1).v7; v67 = (<UH1_1>v1).v8; v68 = (<UH1_1>v1).v9; v69 = (<UH1_1>v1).v10; v70 = (<UH1_1>v1).v11; v71 = (<UH1_1>v1).v12; v72 = (<UH1_1>v1).v13; v73 = (<UH1_1>v1).v14; v74 = (<UH1_1>v1).v15; v76 = (<UH1_1>v1).v17
        return v1
cdef UH0 method47(UH0 v0, UH0 v1):
    cdef US1 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method47(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef void method49(list v0, list v1) except *:
    cdef unsigned long long v2
    cdef bint v3
    cdef str v4
    v2 = len(v1)
    v3 = (<unsigned long long>0) < v2
    if v3:
        v4 = "".join(v1)
        v0.append(v4)
        del v4
        v1.clear()
    else:
        pass
cdef str method50(signed char v0):
    cdef signed char v1
    cdef signed char v2
    cdef bint v3
    cdef str v13
    cdef bint v4
    cdef bint v5
    cdef bint v6
    cdef bint v7
    cdef bint v14
    cdef str v19
    cdef bint v15
    cdef bint v16
    v1 = v0 // (<signed char>13)
    v2 = v0 % (<signed char>13)
    v3 = (<signed char>12) == v2
    if v3:
        v13 = 'A'
    else:
        v4 = (<signed char>11) == v2
        if v4:
            v13 = 'K'
        else:
            v5 = (<signed char>10) == v2
            if v5:
                v13 = 'Q'
            else:
                v6 = (<signed char>9) == v2
                if v6:
                    v13 = 'J'
                else:
                    v7 = (<signed char>8) == v2
                    if v7:
                        v13 = 'T'
                    else:
                        v13 = str(2 + v2)
    v14 = (<signed char>0) == v1
    if v14:
        v19 = "[color=ff0000]"
    else:
        v15 = (<signed char>1) == v1
        if v15:
            v19 = "[color=00ff00]"
        else:
            v16 = (<signed char>2) == v1
            if v16:
                v19 = "[color=0000ff]"
            else:
                v19 = "[color=ffff00]"
    return f'{v19}{v13}[/color]'
cdef void method48(list v0, list v1, bint v2, UH0 v3) except *:
    cdef US1 v4
    cdef UH0 v5
    cdef US0 v6
    cdef str v7
    cdef str v12
    cdef signed long v10
    cdef bint v13
    cdef signed char v14
    cdef str v15
    cdef bint v16
    if v3.tag == 0: # cons_
        v4 = (<UH0_0>v3).v0; v5 = (<UH0_0>v3).v1
        if v4.tag == 0: # action_
            v6 = (<US1_0>v4).v0
            method49(v0, v1)
            if v2:
                v7 = "Player One "
            else:
                v7 = "Player Two "
            if v6.tag == 0: # call
                v12 = f'{v7} calls.'
            elif v6.tag == 1: # fold
                v12 = f'{v7} folds.'
            elif v6.tag == 2: # raiseTo_
                v10 = (<US0_2>v6).v0
                v12 = f'{v7} raises to {v10}.'
            del v6; del v7
            v0.append(v12)
            del v12
            v13 = v2 == 0
            method48(v0, v1, v13, v5)
        elif v4.tag == 1: # observation_
            v14 = (<US1_1>v4).v0
            v15 = method50(v14)
            v1.append(v15)
            del v15
            v16 = 1
            method48(v0, v1, v16, v5)
    elif v3.tag == 1: # nil
        method49(v0, v1)
cdef str method46(UH0 v0):
    cdef list v1
    cdef list v2
    cdef bint v3
    cdef UH0 v4
    cdef UH0 v5
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = 1
    v4 = UH0_1()
    v5 = method47(v0, v4)
    del v4
    method48(v1, v2, v3, v5)
    del v2; del v5
    return "\n".join(v1)
cdef bint method51(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef str method52(signed char v0, signed char v1):
    cdef str v2
    cdef str v3
    v2 = method50(v1)
    v3 = method50(v0)
    return f'{v2}{v3}'
cdef void method43(v0, unsigned char v1, signed long v2, UH1 v3) except *:
    cdef UH1 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef UH0 v10
    cdef float v11
    cdef float v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed long v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed long v20
    cdef numpy.ndarray[signed char,ndim=1] v21
    cdef unsigned char v22
    cdef numpy.ndarray[object,ndim=1] v23
    cdef object v24
    cdef bint v25
    cdef UH0 v26
    cdef str v27
    cdef unsigned long long v28
    cdef Mut2 v29
    cdef unsigned long long v31
    cdef signed long v32
    cdef US0 v33
    cdef signed long v37
    cdef signed long v34
    cdef bint v35
    cdef unsigned long long v38
    cdef signed long v39
    cdef Mut2 v40
    cdef unsigned long long v42
    cdef signed long v43
    cdef US0 v44
    cdef signed long v48
    cdef signed long v45
    cdef bint v46
    cdef unsigned long long v49
    cdef signed long v50
    cdef object v51
    cdef object v52
    cdef object v53
    cdef object v54
    cdef bint v55
    cdef signed char v56
    cdef signed char v57
    cdef unsigned char v58
    cdef signed long v59
    cdef signed char v60
    cdef signed char v61
    cdef unsigned char v62
    cdef signed long v63
    cdef signed long v64
    cdef str v65
    cdef signed long v66
    cdef str v67
    cdef unsigned long long v68
    cdef list v69
    cdef Mut1 v70
    cdef unsigned long long v72
    cdef signed char v73
    cdef str v74
    cdef unsigned long long v75
    cdef str v76
    cdef object v77
    cdef object v78
    cdef float v79
    cdef float v80
    cdef UH0 v81
    cdef float v82
    cdef float v83
    cdef UH0 v84
    cdef float v85
    cdef float v86
    cdef signed char v87
    cdef signed char v88
    cdef unsigned char v89
    cdef signed long v90
    cdef signed char v91
    cdef signed char v92
    cdef unsigned char v93
    cdef signed long v94
    cdef numpy.ndarray[signed char,ndim=1] v95
    cdef float v96
    cdef bint v97
    cdef UH0 v98
    cdef str v99
    cdef object v100
    cdef object v101
    cdef object v102
    cdef object v103
    cdef float v105
    cdef signed long v106
    cdef bint v107
    cdef signed char v108
    cdef signed char v109
    cdef unsigned char v110
    cdef signed long v111
    cdef signed char v112
    cdef signed char v113
    cdef unsigned char v114
    cdef signed long v115
    cdef signed long v116
    cdef str v117
    cdef signed long v118
    cdef str v119
    cdef unsigned long long v120
    cdef list v121
    cdef Mut1 v122
    cdef unsigned long long v124
    cdef signed char v125
    cdef str v126
    cdef unsigned long long v127
    cdef str v128
    cdef object v129
    cdef object v130
    v4 = method44(v1, v3)
    if v4.tag == 0: # action_
        v5 = (<UH1_0>v4).v0; v6 = (<UH1_0>v4).v1; v7 = (<UH1_0>v4).v2; v8 = (<UH1_0>v4).v3; v9 = (<UH1_0>v4).v4; v10 = (<UH1_0>v4).v5; v11 = (<UH1_0>v4).v6; v12 = (<UH1_0>v4).v7; v13 = (<UH1_0>v4).v8; v14 = (<UH1_0>v4).v9; v15 = (<UH1_0>v4).v10; v16 = (<UH1_0>v4).v11; v17 = (<UH1_0>v4).v12; v18 = (<UH1_0>v4).v13; v19 = (<UH1_0>v4).v14; v20 = (<UH1_0>v4).v15; v21 = (<UH1_0>v4).v16; v22 = (<UH1_0>v4).v17; v23 = (<UH1_0>v4).v18; v24 = (<UH1_0>v4).v19
        v25 = v1 == (<unsigned char>0)
        if v25:
            v26 = v7
        else:
            v26 = v10
        del v7; del v10
        v27 = method46(v26)
        del v26
        v28 = len(v23)
        v29 = Mut2((<unsigned long long>0), (<signed long>0))
        while method51(v28, v29):
            v31 = v29.v0
            v32 = v29.v1
            v33 = v23[v31]
            if v33.tag == 0: # call
                v37 = v32
            elif v33.tag == 1: # fold
                v37 = v32
            elif v33.tag == 2: # raiseTo_
                v34 = (<US0_2>v33).v0
                v35 = v32 >= v34
                if v35:
                    v37 = v32
                else:
                    v37 = v34
            del v33
            v38 = v31 + (<unsigned long long>1)
            v29.v0 = v38
            v29.v1 = v37
        v39 = v29.v1
        del v29
        v40 = Mut2((<unsigned long long>0), v39)
        while method51(v28, v40):
            v42 = v40.v0
            v43 = v40.v1
            v44 = v23[v42]
            if v44.tag == 0: # call
                v48 = v43
            elif v44.tag == 1: # fold
                v48 = v43
            elif v44.tag == 2: # raiseTo_
                v45 = (<US0_2>v44).v0
                v46 = v43 < v45
                if v46:
                    v48 = v43
                else:
                    v48 = v45
            del v44
            v49 = v42 + (<unsigned long long>1)
            v40.v0 = v49
            v40.v1 = v48
        del v23
        v50 = v40.v1
        del v40
        v51 = Closure21(v0, v1, v2, v24)
        v52 = Closure22(v0, v1, v2, v24)
        v53 = Closure23(v0, v1, v2, v24)
        del v24
        v54 = {'call': v51, 'fold': v52, 'raise_max': v39, 'raise_min': v50, 'raise_to': v53}
        del v51; del v52; del v53
        v55 = v1 == v15
        if v55:
            v56, v57, v58, v59, v60, v61, v62, v63 = v13, v14, v15, v16, v17, v18, v19, v20
        else:
            v56, v57, v58, v59, v60, v61, v62, v63 = v17, v18, v19, v20, v13, v14, v15, v16
        v64 = v2 - v59
        v65 = method52(v57, v56)
        v66 = v2 - v63
        v67 = method52(v61, v60)
        v68 = len(v21)
        v69 = [None]*v68
        v70 = Mut1((<unsigned long long>0))
        while method45(v68, v70):
            v72 = v70.v0
            v73 = v21[v72]
            v74 = method50(v73)
            v69[v72] = v74
            del v74
            v75 = v72 + (<unsigned long long>1)
            v70.v0 = v75
        del v21
        del v70
        v76 = "".join(v69)
        del v69
        v77 = {'community_card': v76, 'my_card': v65, 'my_pot': v59, 'my_stack': v64, 'op_card': v67, 'op_pot': v63, 'op_stack': v66}
        del v65; del v67; del v76
        v78 = {'actions': v54, 'table_data': v77, 'trace': v27}
        del v27; del v54; del v77
        v0(v78)
    elif v4.tag == 1: # terminal_
        v79 = (<UH1_1>v4).v0; v80 = (<UH1_1>v4).v1; v81 = (<UH1_1>v4).v2; v82 = (<UH1_1>v4).v3; v83 = (<UH1_1>v4).v4; v84 = (<UH1_1>v4).v5; v85 = (<UH1_1>v4).v6; v86 = (<UH1_1>v4).v7; v87 = (<UH1_1>v4).v8; v88 = (<UH1_1>v4).v9; v89 = (<UH1_1>v4).v10; v90 = (<UH1_1>v4).v11; v91 = (<UH1_1>v4).v12; v92 = (<UH1_1>v4).v13; v93 = (<UH1_1>v4).v14; v94 = (<UH1_1>v4).v15; v95 = (<UH1_1>v4).v16; v96 = (<UH1_1>v4).v17
        v97 = v1 == (<unsigned char>0)
        if v97:
            v98 = v81
        else:
            v98 = v84
        del v81; del v84
        v99 = method46(v98)
        del v98
        v100 = False
        v101 = False
        v102 = False
        v103 = {'call': v100, 'fold': v101, 'raise_max': (<signed long>0), 'raise_min': (<signed long>0), 'raise_to': v102}
        del v100; del v101; del v102
        if v97:
            v105 = v96
        else:
            v105 = -v96
        v106 = round(v105)
        v107 = v1 == v89
        if v107:
            v108, v109, v110, v111, v112, v113, v114, v115 = v87, v88, v89, v90, v91, v92, v93, v94
        else:
            v108, v109, v110, v111, v112, v113, v114, v115 = v91, v92, v93, v94, v87, v88, v89, v90
        v116 = v2 + v106
        v117 = method52(v109, v108)
        v118 = v2 - v106
        v119 = method52(v113, v112)
        v120 = len(v95)
        v121 = [None]*v120
        v122 = Mut1((<unsigned long long>0))
        while method45(v120, v122):
            v124 = v122.v0
            v125 = v95[v124]
            v126 = method50(v125)
            v121[v124] = v126
            del v126
            v127 = v124 + (<unsigned long long>1)
            v122.v0 = v127
        del v95
        del v122
        v128 = "".join(v121)
        del v121
        v129 = {'community_card': v128, 'my_card': v117, 'my_pot': (<signed long>0), 'my_stack': v116, 'op_card': v119, 'op_pot': (<signed long>0), 'op_stack': v118}
        del v117; del v119; del v128
        v130 = {'actions': v103, 'table_data': v129, 'trace': v99}
        del v99; del v103; del v129
        v0(v130)
cpdef object main():
    return Closure0()
