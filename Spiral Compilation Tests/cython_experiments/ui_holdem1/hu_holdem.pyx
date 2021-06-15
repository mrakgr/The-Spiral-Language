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
    cdef object v8
    cdef object v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef float v22
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, signed char v13, signed char v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
    def __call__(self, float v23, float v24, US0 v25):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
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
            return method25(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US1_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US1_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method25(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
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
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
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
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure8(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH1_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v24)
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
            return method23(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US1_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US1_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method23(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
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
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
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
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure6(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH1_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v25)
cdef class Closure3():
    cdef object v0
    cdef object v1
    cdef signed char v2
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
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed long v9, signed char v10, signed char v11, unsigned char v12, signed long v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v2 = self.v2
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
        del v29
        v30 = 1
        v31 = numpy.empty(5,dtype=numpy.int8)
        v31[0] = v2; v31[1] = v3; v31[2] = v4; v31[3] = v5; v31[4] = v22
        v32 = method4(v1, v30, v6, v7, v8, v9, v10, v11, v12, v13, v31, v2, v3, v4, v5, v22)
        del v31
        v33 = US1_1(v22)
        v34 = UH0_0(v33, v16)
        del v33
        v35 = US1_1(v22)
        v36 = UH0_0(v35, v19)
        del v35
        return v32(v28, v27, v34, v17, v18, v36, v20, v21)
cdef class Closure12():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef signed char v10
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
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
    def __call__(self, float v23, float v24, US0 v25):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef signed char v10 = self.v10
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
            return method28(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US1_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US1_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method28(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
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
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
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
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure12(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH1_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v24)
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
            return method26(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US1_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US1_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method26(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
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
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
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
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure10(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH1_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v25)
cdef class Closure2():
    cdef object v0
    cdef object v1
    cdef signed char v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef unsigned char v7
    cdef signed long v8
    cdef signed char v9
    cdef signed char v10
    cdef unsigned char v11
    cdef signed long v12
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed long v8, signed char v9, signed char v10, unsigned char v11, signed long v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed char v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef signed char v21
        cdef unsigned long long v22
        cdef float v23
        cdef float v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef numpy.ndarray[signed char,ndim=1] v28
        cdef bint v29
        cdef numpy.ndarray[signed char,ndim=1] v30
        cdef object v31
        cdef US1 v32
        cdef UH0 v33
        cdef US1 v34
        cdef UH0 v35
        v21 = v0[(<unsigned long long>0)]
        v22 = len(v0)
        v23 = <float>v22
        v24 = (<float>1.000000) / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v14
        v27 = v25 + v13
        v28 = v0[1:]
        v29 = 1
        v30 = numpy.empty(4,dtype=numpy.int8)
        v30[0] = v2; v30[1] = v3; v30[2] = v4; v30[3] = v21
        v31 = method3(v1, v29, v5, v6, v7, v8, v9, v10, v11, v12, v30, v2, v3, v4, v28, v21)
        del v28; del v30
        v32 = US1_1(v21)
        v33 = UH0_0(v32, v15)
        del v32
        v34 = US1_1(v21)
        v35 = UH0_0(v34, v18)
        del v34
        return v31(v27, v26, v33, v16, v17, v35, v19, v20)
cdef class Closure16():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef signed char v10
    cdef signed char v11
    cdef object v12
    cdef signed char v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19, float v20, float v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, float v22, float v23, US0 v24):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef bint v25
        cdef float v26
        cdef float v27
        cdef US1 v28
        cdef UH0 v29
        cdef US1 v30
        cdef UH0 v31
        cdef float v33
        cdef float v34
        cdef US1 v35
        cdef UH0 v36
        cdef US1 v37
        cdef UH0 v38
        v25 = v0 == (<unsigned char>0)
        if v25:
            v26 = v23 + v19
            v27 = v22 + v18
            v28 = US1_0(v24)
            v29 = UH0_0(v28, v17)
            del v28
            v30 = US1_0(v24)
            v31 = UH0_0(v30, v14)
            del v30
            return method31(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v29, v27, v26, v31, v15, v16)
        else:
            v33 = v23 + v16
            v34 = v22 + v15
            v35 = US1_0(v24)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = US1_0(v24)
            v38 = UH0_0(v37, v14)
            del v37
            return method31(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v36, v18, v19, v38, v34, v33)
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
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef object v13
    cdef signed char v14
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
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
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef object v23
        v23 = Closure16(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v12, v13, v14, v20, v21, v22, v17, v18, v19, v15, v16)
        return UH1_0(v15, v16, v17, v18, v19, v20, v21, v22, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v23)
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
            return method29(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US1_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US1_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method29(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
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
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure14(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH1_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v24)
cdef class Closure1():
    cdef object v0
    cdef object v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef unsigned char v8
    cdef signed long v9
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, signed long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, float v10, float v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef signed char v18
        cdef unsigned long long v19
        cdef float v20
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef numpy.ndarray[signed char,ndim=1] v25
        cdef signed char v26
        cdef unsigned long long v27
        cdef float v28
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef signed char v34
        cdef unsigned long long v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef numpy.ndarray[signed char,ndim=1] v41
        cdef bint v42
        cdef numpy.ndarray[signed char,ndim=1] v43
        cdef object v44
        cdef US1 v45
        cdef US1 v46
        cdef US1 v47
        cdef UH0 v48
        cdef UH0 v49
        cdef UH0 v50
        cdef US1 v51
        cdef US1 v52
        cdef US1 v53
        cdef UH0 v54
        cdef UH0 v55
        cdef UH0 v56
        v18 = v0[(<unsigned long long>0)]
        v19 = len(v0)
        v20 = <float>v19
        v21 = (<float>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v11
        v24 = v22 + v10
        v25 = v0[1:]
        v26 = v25[(<unsigned long long>0)]
        v27 = len(v25)
        v28 = <float>v27
        v29 = (<float>1.000000) / v28
        v30 = libc.math.log(v29)
        v31 = v30 + v23
        v32 = v30 + v24
        v33 = v25[1:]
        del v25
        v34 = v33[(<unsigned long long>0)]
        v35 = len(v33)
        v36 = <float>v35
        v37 = (<float>1.000000) / v36
        v38 = libc.math.log(v37)
        v39 = v38 + v31
        v40 = v38 + v32
        v41 = v33[1:]
        del v33
        v42 = 1
        v43 = numpy.empty(3,dtype=numpy.int8)
        v43[0] = v18; v43[1] = v26; v43[2] = v34
        v44 = method2(v1, v42, v2, v3, v4, v5, v6, v7, v8, v9, v43, v18, v26, v41, v34)
        del v41; del v43
        v45 = US1_1(v34)
        v46 = US1_1(v26)
        v47 = US1_1(v18)
        v48 = UH0_0(v47, v12)
        del v47
        v49 = UH0_0(v46, v48)
        del v46; del v48
        v50 = UH0_0(v45, v49)
        del v45; del v49
        v51 = US1_1(v34)
        v52 = US1_1(v26)
        v53 = US1_1(v18)
        v54 = UH0_0(v53, v15)
        del v53
        v55 = UH0_0(v52, v54)
        del v52; del v54
        v56 = UH0_0(v51, v55)
        del v51; del v55
        return v44(v40, v39, v50, v13, v14, v56, v16, v17)
cdef class Closure20():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed long v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef float v17
    cdef float v18
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16, float v17, float v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, float v19, float v20, US0 v21):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef bint v22
        cdef float v23
        cdef float v24
        cdef US1 v25
        cdef UH0 v26
        cdef US1 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US1 v32
        cdef UH0 v33
        cdef US1 v34
        cdef UH0 v35
        v22 = v0 == (<unsigned char>0)
        if v22:
            v23 = v20 + v16
            v24 = v19 + v15
            v25 = US1_0(v21)
            v26 = UH0_0(v25, v14)
            del v25
            v27 = US1_0(v21)
            v28 = UH0_0(v27, v11)
            del v27
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v26, v24, v23, v28, v12, v13)
        else:
            v30 = v20 + v13
            v31 = v19 + v12
            v32 = US1_0(v21)
            v33 = UH0_0(v32, v14)
            del v32
            v34 = US1_0(v21)
            v35 = UH0_0(v34, v11)
            del v34
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v33, v15, v16, v35, v31, v30)
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
    cdef object v10
    cdef object v11
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
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
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef object v20
        v20 = Closure20(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v17, v18, v19, v14, v15, v16, v12, v13)
        return UH1_0(v12, v13, v14, v15, v16, v17, v18, v19, v0, v1, v2, v3, v4, v5, v6, v3, v7, v2, v8, v20)
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
            return method32(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US1_0(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US1_0(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method32(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
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
    cdef object v11
    cdef object v12
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed long v3, signed char v4, signed char v5, unsigned char v6, signed long v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
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
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef object v21
        v21 = Closure18(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH1_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v7, v8, v2, v9, v21)
cdef class Closure0():
    cdef object v0
    cdef object v1
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1): self.v0 = v0; self.v1 = v1
    def __call__(self, float v2, float v3, UH0 v4, float v5, float v6, UH0 v7, float v8, float v9):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v10
        cdef unsigned long long v11
        cdef float v12
        cdef float v13
        cdef float v14
        cdef float v15
        cdef float v16
        cdef numpy.ndarray[signed char,ndim=1] v17
        cdef signed char v18
        cdef unsigned long long v19
        cdef float v20
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef numpy.ndarray[signed char,ndim=1] v25
        cdef signed char v26
        cdef unsigned long long v27
        cdef float v28
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef signed char v34
        cdef unsigned long long v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef numpy.ndarray[signed char,ndim=1] v41
        cdef bint v42
        cdef unsigned char v43
        cdef signed long v44
        cdef unsigned char v45
        cdef signed long v46
        cdef numpy.ndarray[signed char,ndim=1] v47
        cdef object v48
        cdef US1 v49
        cdef US1 v50
        cdef UH0 v51
        cdef UH0 v52
        cdef US1 v53
        cdef US1 v54
        cdef UH0 v55
        cdef UH0 v56
        v10 = v0[(<unsigned long long>0)]
        v11 = len(v0)
        v12 = <float>v11
        v13 = (<float>1.000000) / v12
        v14 = libc.math.log(v13)
        v15 = v14 + v3
        v16 = v14 + v2
        v17 = v0[1:]
        v18 = v17[(<unsigned long long>0)]
        v19 = len(v17)
        v20 = <float>v19
        v21 = (<float>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v15
        v24 = v22 + v16
        v25 = v17[1:]
        del v17
        v26 = v25[(<unsigned long long>0)]
        v27 = len(v25)
        v28 = <float>v27
        v29 = (<float>1.000000) / v28
        v30 = libc.math.log(v29)
        v31 = v30 + v23
        v32 = v30 + v24
        v33 = v25[1:]
        del v25
        v34 = v33[(<unsigned long long>0)]
        v35 = len(v33)
        v36 = <float>v35
        v37 = (<float>1.000000) / v36
        v38 = libc.math.log(v37)
        v39 = v38 + v31
        v40 = v38 + v32
        v41 = v33[1:]
        del v33
        v42 = 1
        v43 = (<unsigned char>0)
        v44 = (<signed long>1)
        v45 = (<unsigned char>1)
        v46 = (<signed long>2)
        v47 = numpy.empty(0,dtype=numpy.int8)
        
        v48 = method1(v1, v42, v26, v34, v45, v46, v10, v18, v43, v44, v47, v41)
        del v41; del v47
        v49 = US1_1(v18)
        v50 = US1_1(v10)
        v51 = UH0_0(v50, v4)
        del v50
        v52 = UH0_0(v49, v51)
        del v49; del v51
        v53 = US1_1(v34)
        v54 = US1_1(v26)
        v55 = UH0_0(v54, v7)
        del v54
        v56 = UH0_0(v53, v55)
        del v53; del v55
        return v48(v40, v39, v52, v5, v6, v56, v8, v9)
cdef bint method0(Mut0 v0) except *:
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>5)
cdef Tuple0 method7(unsigned long long v0, signed char v1, signed char v2):
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
            return method7(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method6(v0, v93)
cdef Tuple1 method10(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
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
            return method10(v0, v1, v17, v42, v37, v38, v39, v40, v41)
        else:
            v48 = v2 + (<signed char>1)
            return method10(v0, v1, v48, v3, v4, v5, v6, v7, v8)
    else:
        return Tuple1(v4, v5, v6, v7, v8)
cdef Tuple1 method9(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method9(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method10(v0, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple1(v3, v4, v5, v6, v7)
cdef Tuple2 method12(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
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
        return method12(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple2(v3, v4, v5, v6)
cdef Tuple0 method15(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
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
        return method15(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple1 method20(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
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
        return method20(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method10(v0, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple1(v4, v5, v6, v7, v8)
cdef Tuple1 method22(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method10(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple1(v2, v3, v4, v5, v6)
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
            tmp13 = method12(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3
            del tmp13
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp14 = method9(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3, tmp14.v4
            del tmp14
            return Tuple0(v40, v41, v51, v52, v53, (<signed char>2))
        else:
            v56 = v1 - (<signed char>1)
            return method21(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp15 = method22(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3, tmp15.v4
        del tmp15
        return Tuple0(v76, v77, v78, v79, v80, (<signed char>1))
cdef Tuple0 method19(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
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
        return method19(v0, v1, v2, v3, v6)
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
                tmp11 = method12(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3
                del tmp11
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp12 = method20(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3, tmp12.v4
                del tmp12
                return Tuple0(v3, v2, v51, v52, v62, (<signed char>3))
            else:
                v67 = v4 - (<signed char>1)
                return method19(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method21(v0, v80)
cdef Tuple0 method18(unsigned long long v0, signed char v1):
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
            tmp10 = method12(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3
            del tmp10
            v44 = (<signed char>12)
            return method19(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method18(v0, v51)
    else:
        v64 = (<signed char>12)
        return method21(v0, v64)
cdef Tuple0 method17(unsigned long long v0, signed char v1):
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
            tmp8 = method12(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3
            del tmp8
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp9 = method9(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3, tmp9.v4
            del tmp9
            return Tuple0(v40, v41, v42, v51, v52, (<signed char>4))
        else:
            v56 = v1 - (<signed char>1)
            return method17(v0, v56)
    else:
        v69 = (<signed char>12)
        return method18(v0, v69)
cdef Tuple0 method16(unsigned long long v0, signed char v1):
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
            tmp3 = method12(v0, v157, v162, v158, v159, v160, v161, v163)
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
            tmp4 = method12(v0, v171, v176, v172, v173, v174, v175, v177)
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
            tmp5 = method12(v0, v185, v190, v186, v187, v188, v189, v191)
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
            tmp6 = method12(v0, v199, v204, v200, v201, v202, v203, v205)
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
            tmp7 = method12(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3
            del tmp7
            return Tuple0(v164, v178, v192, v206, v219, (<signed char>5))
        else:
            v223 = v1 - (<signed char>1)
            return method16(v0, v223)
    else:
        v236 = (<signed char>12)
        return method17(v0, v236)
cdef Tuple0 method14(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
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
            return method15(v0, v51, v52, v53, v54, v55, v56, v57, v58)
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
                return method15(v0, v66, v67, v68, v69, v70, v71, v72, v73)
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
                    return method15(v0, v81, v82, v83, v84, v85, v86, v87, v88)
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
                        return method15(v0, v96, v97, v98, v99, v100, v101, v102, v103)
                    else:
                        v110 = v1 - (<signed char>1)
                        return method14(v0, v110, v46, v47, v48, v49)
    else:
        v141 = (<signed char>8)
        return method16(v0, v141)
cdef Tuple0 method13(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
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
        return method13(v0, v1, v2, v3, v4, v7)
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
                tmp2 = method12(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3
                del tmp2
                return Tuple0(v4, v3, v2, v52, v53, (<signed char>7))
            else:
                v56 = v5 - (<signed char>1)
                return method13(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method14(v0, v69, v70, v71, v72, v73)
cdef Tuple0 method11(unsigned long long v0, signed char v1):
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
            tmp1 = method12(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3
            del tmp1
            v44 = (<signed char>12)
            return method13(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method11(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method14(v0, v64, v65, v66, v67, v68)
cdef Tuple0 method8(unsigned long long v0, signed char v1):
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
            tmp0 = method9(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4
            del tmp0
            return Tuple0(v1, v9, v17, v25, v41, (<signed char>8))
        else:
            v46 = v1 - (<signed char>1)
            return method8(v0, v46)
    else:
        v59 = (<signed char>12)
        return method11(v0, v59)
cdef Tuple0 method6(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method7(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method8(v0, v10)
cdef Tuple0 method5(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6):
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
    return method6(v27, v28)
cdef UH1 method25(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, signed char v13, signed char v14, US0 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
    cdef object v103
    cdef bint v24
    cdef bint v26
    cdef signed char v27
    cdef signed char v28
    cdef unsigned char v29
    cdef signed long v30
    cdef signed char v31
    cdef signed char v32
    cdef unsigned char v33
    cdef signed long v34
    cdef numpy.ndarray[signed char,ndim=1] v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef Tuple0 tmp20
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef Tuple0 tmp21
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef bint v58
    cdef signed long v61
    cdef bint v59
    cdef bint v62
    cdef signed long v91
    cdef bint v63
    cdef signed long v66
    cdef bint v64
    cdef bint v67
    cdef bint v68
    cdef signed long v71
    cdef bint v69
    cdef bint v72
    cdef bint v73
    cdef signed long v76
    cdef bint v74
    cdef bint v77
    cdef bint v78
    cdef signed long v81
    cdef bint v79
    cdef bint v82
    cdef bint v83
    cdef bint v84
    cdef bint v92
    cdef float v93
    cdef bint v95
    cdef float v96
    cdef signed long v98
    cdef float v99
    cdef bint v105
    cdef signed long v107
    cdef float v108
    cdef signed long v110
    cdef bint v111
    cdef object v112
    if v15.tag == 0: # call
        if v0:
            v24 = 0
            v103 = method24(v8, v24, v5, v6, v7, v4, v1, v2, v3, v9, v10, v11, v12, v13, v14)
        else:
            v26 = v7 == (<unsigned char>0)
            if v26:
                v27, v28, v29, v30, v31, v32, v33, v34 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v27, v28, v29, v30, v31, v32, v33, v34 = v1, v2, v3, v4, v5, v6, v7, v4
            v35 = numpy.empty(5,dtype=numpy.int8)
            v35[0] = v10; v35[1] = v11; v35[2] = v12; v35[3] = v13; v35[4] = v14
            tmp20 = method5(v14, v13, v12, v11, v10, v28, v27)
            v36, v37, v38, v39, v40, v41 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4, tmp20.v5
            del tmp20
            tmp21 = method5(v14, v13, v12, v11, v10, v32, v31)
            v42, v43, v44, v45, v46, v47 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4, tmp21.v5
            del tmp21
            v48 = v36 % (<signed char>13)
            v49 = v37 % (<signed char>13)
            v50 = v38 % (<signed char>13)
            v51 = v39 % (<signed char>13)
            v52 = v40 % (<signed char>13)
            v53 = v42 % (<signed char>13)
            v54 = v43 % (<signed char>13)
            v55 = v44 % (<signed char>13)
            v56 = v45 % (<signed char>13)
            v57 = v46 % (<signed char>13)
            v58 = v41 < v47
            if v58:
                v61 = (<signed long>-1)
            else:
                v59 = v41 > v47
                if v59:
                    v61 = (<signed long>1)
                else:
                    v61 = (<signed long>0)
            v62 = v61 == (<signed long>0)
            if v62:
                v63 = v48 < v53
                if v63:
                    v66 = (<signed long>-1)
                else:
                    v64 = v48 > v53
                    if v64:
                        v66 = (<signed long>1)
                    else:
                        v66 = (<signed long>0)
                v67 = v66 == (<signed long>0)
                if v67:
                    v68 = v49 < v54
                    if v68:
                        v71 = (<signed long>-1)
                    else:
                        v69 = v49 > v54
                        if v69:
                            v71 = (<signed long>1)
                        else:
                            v71 = (<signed long>0)
                    v72 = v71 == (<signed long>0)
                    if v72:
                        v73 = v50 < v55
                        if v73:
                            v76 = (<signed long>-1)
                        else:
                            v74 = v50 > v55
                            if v74:
                                v76 = (<signed long>1)
                            else:
                                v76 = (<signed long>0)
                        v77 = v76 == (<signed long>0)
                        if v77:
                            v78 = v51 < v56
                            if v78:
                                v81 = (<signed long>-1)
                            else:
                                v79 = v51 > v56
                                if v79:
                                    v81 = (<signed long>1)
                                else:
                                    v81 = (<signed long>0)
                            v82 = v81 == (<signed long>0)
                            if v82:
                                v83 = v52 < v57
                                if v83:
                                    v91 = (<signed long>-1)
                                else:
                                    v84 = v52 > v57
                                    if v84:
                                        v91 = (<signed long>1)
                                    else:
                                        v91 = (<signed long>0)
                            else:
                                v91 = v81
                        else:
                            v91 = v76
                    else:
                        v91 = v71
                else:
                    v91 = v66
            else:
                v91 = v61
            v92 = v91 == (<signed long>0)
            if v92:
                v93 = <float>(<signed long>0)
                v103 = Closure4(v27, v28, v29, v30, v31, v32, v33, v34, v35, v93)
            else:
                v95 = v91 == (<signed long>1)
                if v95:
                    v96 = <float>v30
                    v103 = Closure4(v27, v28, v29, v30, v31, v32, v33, v34, v35, v96)
                else:
                    v98 = -v30
                    v99 = <float>v98
                    v103 = Closure4(v27, v28, v29, v30, v31, v32, v33, v34, v35, v99)
            del v35
        return v103(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v105 = v7 == (<unsigned char>0)
        if v105:
            v107 = -v4
        else:
            v107 = v4
        v108 = <float>v107
        return UH1_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v4, v1, v2, v3, v4, v9, v108)
    elif v15.tag == 2: # raiseTo_
        v110 = (<US0_2>v15).v0
        v111 = 0
        v112 = method4(v8, v111, v5, v6, v7, v110, v1, v2, v3, v4, v9, v10, v11, v12, v13, v14)
        return v112(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method24(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, signed char v13, signed char v14):
    cdef bint v15
    cdef bint v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed long v20
    cdef signed char v21
    cdef signed char v22
    cdef unsigned char v23
    cdef signed long v24
    cdef numpy.ndarray[signed char,ndim=1] v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef Tuple0 tmp18
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef Tuple0 tmp19
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef bint v48
    cdef signed long v51
    cdef bint v49
    cdef bint v52
    cdef signed long v81
    cdef bint v53
    cdef signed long v56
    cdef bint v54
    cdef bint v57
    cdef bint v58
    cdef signed long v61
    cdef bint v59
    cdef bint v62
    cdef bint v63
    cdef signed long v66
    cdef bint v64
    cdef bint v67
    cdef bint v68
    cdef signed long v71
    cdef bint v69
    cdef bint v72
    cdef bint v73
    cdef bint v74
    cdef bint v82
    cdef float v83
    cdef bint v85
    cdef float v86
    cdef signed long v88
    cdef float v89
    cdef bint v93
    cdef bint v94
    cdef bint v95
    cdef signed long v96
    cdef bint v97
    cdef signed long v98
    cdef signed long v99
    cdef numpy.ndarray[object,ndim=1] v100
    v15 = v5 == (<signed long>5)
    if v15:
        v16 = v8 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22, v23, v24 = v6, v7, v8, v5, v2, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22, v23, v24 = v2, v3, v4, v5, v6, v7, v8, v5
        v25 = numpy.empty(5,dtype=numpy.int8)
        v25[0] = v10; v25[1] = v11; v25[2] = v12; v25[3] = v13; v25[4] = v14
        tmp18 = method5(v14, v13, v12, v11, v10, v18, v17)
        v26, v27, v28, v29, v30, v31 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4, tmp18.v5
        del tmp18
        tmp19 = method5(v14, v13, v12, v11, v10, v22, v21)
        v32, v33, v34, v35, v36, v37 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3, tmp19.v4, tmp19.v5
        del tmp19
        v38 = v26 % (<signed char>13)
        v39 = v27 % (<signed char>13)
        v40 = v28 % (<signed char>13)
        v41 = v29 % (<signed char>13)
        v42 = v30 % (<signed char>13)
        v43 = v32 % (<signed char>13)
        v44 = v33 % (<signed char>13)
        v45 = v34 % (<signed char>13)
        v46 = v35 % (<signed char>13)
        v47 = v36 % (<signed char>13)
        v48 = v31 < v37
        if v48:
            v51 = (<signed long>-1)
        else:
            v49 = v31 > v37
            if v49:
                v51 = (<signed long>1)
            else:
                v51 = (<signed long>0)
        v52 = v51 == (<signed long>0)
        if v52:
            v53 = v38 < v43
            if v53:
                v56 = (<signed long>-1)
            else:
                v54 = v38 > v43
                if v54:
                    v56 = (<signed long>1)
                else:
                    v56 = (<signed long>0)
            v57 = v56 == (<signed long>0)
            if v57:
                v58 = v39 < v44
                if v58:
                    v61 = (<signed long>-1)
                else:
                    v59 = v39 > v44
                    if v59:
                        v61 = (<signed long>1)
                    else:
                        v61 = (<signed long>0)
                v62 = v61 == (<signed long>0)
                if v62:
                    v63 = v40 < v45
                    if v63:
                        v66 = (<signed long>-1)
                    else:
                        v64 = v40 > v45
                        if v64:
                            v66 = (<signed long>1)
                        else:
                            v66 = (<signed long>0)
                    v67 = v66 == (<signed long>0)
                    if v67:
                        v68 = v41 < v46
                        if v68:
                            v71 = (<signed long>-1)
                        else:
                            v69 = v41 > v46
                            if v69:
                                v71 = (<signed long>1)
                            else:
                                v71 = (<signed long>0)
                        v72 = v71 == (<signed long>0)
                        if v72:
                            v73 = v42 < v47
                            if v73:
                                v81 = (<signed long>-1)
                            else:
                                v74 = v42 > v47
                                if v74:
                                    v81 = (<signed long>1)
                                else:
                                    v81 = (<signed long>0)
                        else:
                            v81 = v71
                    else:
                        v81 = v66
                else:
                    v81 = v61
            else:
                v81 = v56
        else:
            v81 = v51
        v82 = v81 == (<signed long>0)
        if v82:
            v83 = <float>(<signed long>0)
            return Closure4(v17, v18, v19, v20, v21, v22, v23, v24, v25, v83)
        else:
            v85 = v81 == (<signed long>1)
            if v85:
                v86 = <float>v20
                return Closure4(v17, v18, v19, v20, v21, v22, v23, v24, v25, v86)
            else:
                v88 = -v20
                v89 = <float>v88
                return Closure4(v17, v18, v19, v20, v21, v22, v23, v24, v25, v89)
    else:
        v93 = v5 >= v5
        v94 = v5 < v5
        v95 = (<signed long>5) < v5
        if v95:
            v96 = (<signed long>5)
        else:
            v96 = v5
        v97 = (<signed long>5) == v5
        if v97:
            v98 = (<signed long>1)
        else:
            v98 = (<signed long>0)
        v99 = v96 + v98
        v100 = v0[(<signed long>1):3+(<signed long>5)-v99]
        return Closure7(v6, v7, v8, v5, v2, v3, v4, v9, v100, v1, v0, v10, v11, v12, v13, v14)
cdef UH1 method23(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US0 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v104
    cdef bint v25
    cdef bint v27
    cdef signed char v28
    cdef signed char v29
    cdef unsigned char v30
    cdef signed long v31
    cdef signed char v32
    cdef signed char v33
    cdef unsigned char v34
    cdef signed long v35
    cdef numpy.ndarray[signed char,ndim=1] v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef Tuple0 tmp22
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef Tuple0 tmp23
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef signed char v58
    cdef bint v59
    cdef signed long v62
    cdef bint v60
    cdef bint v63
    cdef signed long v92
    cdef bint v64
    cdef signed long v67
    cdef bint v65
    cdef bint v68
    cdef bint v69
    cdef signed long v72
    cdef bint v70
    cdef bint v73
    cdef bint v74
    cdef signed long v77
    cdef bint v75
    cdef bint v78
    cdef bint v79
    cdef signed long v82
    cdef bint v80
    cdef bint v83
    cdef bint v84
    cdef bint v85
    cdef bint v93
    cdef float v94
    cdef bint v96
    cdef float v97
    cdef signed long v99
    cdef float v100
    cdef bint v106
    cdef signed long v108
    cdef float v109
    cdef signed long v111
    cdef bint v112
    cdef object v113
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v104 = method24(v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v27 = v7 == (<unsigned char>0)
            if v27:
                v28, v29, v30, v31, v32, v33, v34, v35 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v28, v29, v30, v31, v32, v33, v34, v35 = v1, v2, v3, v4, v5, v6, v7, v4
            v36 = numpy.empty(5,dtype=numpy.int8)
            v36[0] = v11; v36[1] = v12; v36[2] = v13; v36[3] = v14; v36[4] = v15
            tmp22 = method5(v15, v14, v13, v12, v11, v29, v28)
            v37, v38, v39, v40, v41, v42 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5
            del tmp22
            tmp23 = method5(v15, v14, v13, v12, v11, v33, v32)
            v43, v44, v45, v46, v47, v48 = tmp23.v0, tmp23.v1, tmp23.v2, tmp23.v3, tmp23.v4, tmp23.v5
            del tmp23
            v49 = v37 % (<signed char>13)
            v50 = v38 % (<signed char>13)
            v51 = v39 % (<signed char>13)
            v52 = v40 % (<signed char>13)
            v53 = v41 % (<signed char>13)
            v54 = v43 % (<signed char>13)
            v55 = v44 % (<signed char>13)
            v56 = v45 % (<signed char>13)
            v57 = v46 % (<signed char>13)
            v58 = v47 % (<signed char>13)
            v59 = v42 < v48
            if v59:
                v62 = (<signed long>-1)
            else:
                v60 = v42 > v48
                if v60:
                    v62 = (<signed long>1)
                else:
                    v62 = (<signed long>0)
            v63 = v62 == (<signed long>0)
            if v63:
                v64 = v49 < v54
                if v64:
                    v67 = (<signed long>-1)
                else:
                    v65 = v49 > v54
                    if v65:
                        v67 = (<signed long>1)
                    else:
                        v67 = (<signed long>0)
                v68 = v67 == (<signed long>0)
                if v68:
                    v69 = v50 < v55
                    if v69:
                        v72 = (<signed long>-1)
                    else:
                        v70 = v50 > v55
                        if v70:
                            v72 = (<signed long>1)
                        else:
                            v72 = (<signed long>0)
                    v73 = v72 == (<signed long>0)
                    if v73:
                        v74 = v51 < v56
                        if v74:
                            v77 = (<signed long>-1)
                        else:
                            v75 = v51 > v56
                            if v75:
                                v77 = (<signed long>1)
                            else:
                                v77 = (<signed long>0)
                        v78 = v77 == (<signed long>0)
                        if v78:
                            v79 = v52 < v57
                            if v79:
                                v82 = (<signed long>-1)
                            else:
                                v80 = v52 > v57
                                if v80:
                                    v82 = (<signed long>1)
                                else:
                                    v82 = (<signed long>0)
                            v83 = v82 == (<signed long>0)
                            if v83:
                                v84 = v53 < v58
                                if v84:
                                    v92 = (<signed long>-1)
                                else:
                                    v85 = v53 > v58
                                    if v85:
                                        v92 = (<signed long>1)
                                    else:
                                        v92 = (<signed long>0)
                            else:
                                v92 = v82
                        else:
                            v92 = v77
                    else:
                        v92 = v72
                else:
                    v92 = v67
            else:
                v92 = v62
            v93 = v92 == (<signed long>0)
            if v93:
                v94 = <float>(<signed long>0)
                v104 = Closure4(v28, v29, v30, v31, v32, v33, v34, v35, v36, v94)
            else:
                v96 = v92 == (<signed long>1)
                if v96:
                    v97 = <float>v31
                    v104 = Closure4(v28, v29, v30, v31, v32, v33, v34, v35, v36, v97)
                else:
                    v99 = -v31
                    v100 = <float>v99
                    v104 = Closure4(v28, v29, v30, v31, v32, v33, v34, v35, v36, v100)
            del v36
        return v104(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v106 = v7 == (<unsigned char>0)
        if v106:
            v108 = -v8
        else:
            v108 = v8
        v109 = <float>v108
        return UH1_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v8, v1, v2, v3, v4, v10, v109)
    elif v16.tag == 2: # raiseTo_
        v111 = (<US0_2>v16).v0
        v112 = 0
        v113 = method4(v9, v112, v5, v6, v7, v111, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v113(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method4(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, signed long v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
    cdef bint v16
    cdef bint v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed long v21
    cdef signed char v22
    cdef signed char v23
    cdef unsigned char v24
    cdef signed long v25
    cdef numpy.ndarray[signed char,ndim=1] v26
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef Tuple0 tmp16
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef Tuple0 tmp17
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef bint v49
    cdef signed long v52
    cdef bint v50
    cdef bint v53
    cdef signed long v82
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
    cdef signed long v72
    cdef bint v70
    cdef bint v73
    cdef bint v74
    cdef bint v75
    cdef bint v83
    cdef float v84
    cdef bint v86
    cdef float v87
    cdef signed long v89
    cdef float v90
    cdef bint v95
    cdef bint v96
    cdef bint v97
    cdef signed long v98
    cdef bint v99
    cdef signed long v100
    cdef signed long v101
    cdef bint v102
    cdef signed long v103
    cdef signed long v104
    cdef signed long v105
    cdef bint v106
    cdef signed long v107
    cdef bint v108
    cdef signed long v109
    cdef signed long v110
    cdef numpy.ndarray[object,ndim=1] v111
    v16 = v9 == (<signed long>5)
    if v16:
        v17 = v8 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23, v24, v25 = v6, v7, v8, v9, v2, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23, v24, v25 = v2, v3, v4, v5, v6, v7, v8, v9
        v26 = numpy.empty(5,dtype=numpy.int8)
        v26[0] = v11; v26[1] = v12; v26[2] = v13; v26[3] = v14; v26[4] = v15
        tmp16 = method5(v15, v14, v13, v12, v11, v19, v18)
        v27, v28, v29, v30, v31, v32 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3, tmp16.v4, tmp16.v5
        del tmp16
        tmp17 = method5(v15, v14, v13, v12, v11, v23, v22)
        v33, v34, v35, v36, v37, v38 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3, tmp17.v4, tmp17.v5
        del tmp17
        v39 = v27 % (<signed char>13)
        v40 = v28 % (<signed char>13)
        v41 = v29 % (<signed char>13)
        v42 = v30 % (<signed char>13)
        v43 = v31 % (<signed char>13)
        v44 = v33 % (<signed char>13)
        v45 = v34 % (<signed char>13)
        v46 = v35 % (<signed char>13)
        v47 = v36 % (<signed char>13)
        v48 = v37 % (<signed char>13)
        v49 = v32 < v38
        if v49:
            v52 = (<signed long>-1)
        else:
            v50 = v32 > v38
            if v50:
                v52 = (<signed long>1)
            else:
                v52 = (<signed long>0)
        v53 = v52 == (<signed long>0)
        if v53:
            v54 = v39 < v44
            if v54:
                v57 = (<signed long>-1)
            else:
                v55 = v39 > v44
                if v55:
                    v57 = (<signed long>1)
                else:
                    v57 = (<signed long>0)
            v58 = v57 == (<signed long>0)
            if v58:
                v59 = v40 < v45
                if v59:
                    v62 = (<signed long>-1)
                else:
                    v60 = v40 > v45
                    if v60:
                        v62 = (<signed long>1)
                    else:
                        v62 = (<signed long>0)
                v63 = v62 == (<signed long>0)
                if v63:
                    v64 = v41 < v46
                    if v64:
                        v67 = (<signed long>-1)
                    else:
                        v65 = v41 > v46
                        if v65:
                            v67 = (<signed long>1)
                        else:
                            v67 = (<signed long>0)
                    v68 = v67 == (<signed long>0)
                    if v68:
                        v69 = v42 < v47
                        if v69:
                            v72 = (<signed long>-1)
                        else:
                            v70 = v42 > v47
                            if v70:
                                v72 = (<signed long>1)
                            else:
                                v72 = (<signed long>0)
                        v73 = v72 == (<signed long>0)
                        if v73:
                            v74 = v43 < v48
                            if v74:
                                v82 = (<signed long>-1)
                            else:
                                v75 = v43 > v48
                                if v75:
                                    v82 = (<signed long>1)
                                else:
                                    v82 = (<signed long>0)
                        else:
                            v82 = v72
                    else:
                        v82 = v67
                else:
                    v82 = v62
            else:
                v82 = v57
        else:
            v82 = v52
        v83 = v82 == (<signed long>0)
        if v83:
            v84 = <float>(<signed long>0)
            return Closure4(v18, v19, v20, v21, v22, v23, v24, v25, v26, v84)
        else:
            v86 = v82 == (<signed long>1)
            if v86:
                v87 = <float>v21
                return Closure4(v18, v19, v20, v21, v22, v23, v24, v25, v26, v87)
            else:
                v89 = -v21
                v90 = <float>v89
                return Closure4(v18, v19, v20, v21, v22, v23, v24, v25, v26, v90)
    else:
        if v1:
            v95 = 1
        else:
            v95 = v9 == v5
        v96 = v95 == 0
        v97 = v9 >= v5
        if v97:
            v98 = v9
        else:
            v98 = v5
        v99 = v9 < v5
        if v99:
            v100 = v9
        else:
            v100 = v5
        v101 = v98 - v100
        v102 = (<signed long>1) < v101
        if v102:
            v103 = (<signed long>1)
        else:
            v103 = v101
        v104 = v98 + v103
        if v96:
            v105 = (<signed long>0)
        else:
            v105 = (<signed long>1)
        v106 = (<signed long>5) < v104
        if v106:
            v107 = (<signed long>5)
        else:
            v107 = v104
        v108 = (<signed long>5) == v98
        if v108:
            v109 = (<signed long>1)
        else:
            v109 = (<signed long>0)
        v110 = v107 + v109
        v111 = v0[v105:3+(<signed long>5)-v110]
        return Closure5(v6, v7, v8, v9, v2, v3, v4, v5, v10, v111, v1, v0, v11, v12, v13, v14, v15)
cdef UH1 method28(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US0 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
    cdef object v36
    cdef bint v24
    cdef bint v26
    cdef signed char v27
    cdef signed char v28
    cdef unsigned char v29
    cdef signed long v30
    cdef signed char v31
    cdef signed char v32
    cdef unsigned char v33
    cdef signed long v34
    cdef bint v38
    cdef signed long v40
    cdef float v41
    cdef signed long v43
    cdef bint v44
    cdef object v45
    if v15.tag == 0: # call
        if v0:
            v24 = 0
            v36 = method27(v8, v24, v5, v6, v7, v4, v1, v2, v3, v9, v10, v11, v12, v13, v14)
        else:
            v26 = v7 == (<unsigned char>0)
            if v26:
                v27, v28, v29, v30, v31, v32, v33, v34 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v27, v28, v29, v30, v31, v32, v33, v34 = v1, v2, v3, v4, v5, v6, v7, v4
            v36 = Closure3(v13, v8, v10, v11, v12, v14, v31, v32, v33, v34, v27, v28, v29, v30)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v38 = v7 == (<unsigned char>0)
        if v38:
            v40 = -v4
        else:
            v40 = v4
        v41 = <float>v40
        return UH1_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v4, v1, v2, v3, v4, v9, v41)
    elif v15.tag == 2: # raiseTo_
        v43 = (<US0_2>v15).v0
        v44 = 0
        v45 = method3(v8, v44, v5, v6, v7, v43, v1, v2, v3, v4, v9, v10, v11, v12, v13, v14)
        return v45(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method27(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
    cdef bint v15
    cdef bint v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed long v20
    cdef signed char v21
    cdef signed char v22
    cdef unsigned char v23
    cdef signed long v24
    cdef bint v26
    cdef bint v27
    cdef bint v28
    cdef signed long v29
    cdef bint v30
    cdef signed long v31
    cdef signed long v32
    cdef numpy.ndarray[object,ndim=1] v33
    v15 = v5 == (<signed long>5)
    if v15:
        v16 = v8 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22, v23, v24 = v6, v7, v8, v5, v2, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22, v23, v24 = v2, v3, v4, v5, v6, v7, v8, v5
        return Closure3(v13, v0, v10, v11, v12, v14, v21, v22, v23, v24, v17, v18, v19, v20)
    else:
        v26 = v5 >= v5
        v27 = v5 < v5
        v28 = (<signed long>5) < v5
        if v28:
            v29 = (<signed long>5)
        else:
            v29 = v5
        v30 = (<signed long>5) == v5
        if v30:
            v31 = (<signed long>1)
        else:
            v31 = (<signed long>0)
        v32 = v29 + v31
        v33 = v0[(<signed long>1):3+(<signed long>5)-v32]
        return Closure11(v6, v7, v8, v5, v2, v3, v4, v9, v33, v1, v0, v10, v11, v12, v13, v14)
cdef UH1 method26(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US0 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v37
    cdef bint v25
    cdef bint v27
    cdef signed char v28
    cdef signed char v29
    cdef unsigned char v30
    cdef signed long v31
    cdef signed char v32
    cdef signed char v33
    cdef unsigned char v34
    cdef signed long v35
    cdef bint v39
    cdef signed long v41
    cdef float v42
    cdef signed long v44
    cdef bint v45
    cdef object v46
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v37 = method27(v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v27 = v7 == (<unsigned char>0)
            if v27:
                v28, v29, v30, v31, v32, v33, v34, v35 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v28, v29, v30, v31, v32, v33, v34, v35 = v1, v2, v3, v4, v5, v6, v7, v4
            v37 = Closure3(v14, v9, v11, v12, v13, v15, v32, v33, v34, v35, v28, v29, v30, v31)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v39 = v7 == (<unsigned char>0)
        if v39:
            v41 = -v8
        else:
            v41 = v8
        v42 = <float>v41
        return UH1_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v8, v1, v2, v3, v4, v10, v42)
    elif v16.tag == 2: # raiseTo_
        v44 = (<US0_2>v16).v0
        v45 = 0
        v46 = method3(v9, v45, v5, v6, v7, v44, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v46(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method3(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, signed long v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
    cdef bint v16
    cdef bint v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed long v21
    cdef signed char v22
    cdef signed char v23
    cdef unsigned char v24
    cdef signed long v25
    cdef bint v28
    cdef bint v29
    cdef bint v30
    cdef signed long v31
    cdef bint v32
    cdef signed long v33
    cdef signed long v34
    cdef bint v35
    cdef signed long v36
    cdef signed long v37
    cdef signed long v38
    cdef bint v39
    cdef signed long v40
    cdef bint v41
    cdef signed long v42
    cdef signed long v43
    cdef numpy.ndarray[object,ndim=1] v44
    v16 = v9 == (<signed long>5)
    if v16:
        v17 = v8 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23, v24, v25 = v6, v7, v8, v9, v2, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23, v24, v25 = v2, v3, v4, v5, v6, v7, v8, v9
        return Closure3(v14, v0, v11, v12, v13, v15, v22, v23, v24, v25, v18, v19, v20, v21)
    else:
        if v1:
            v28 = 1
        else:
            v28 = v9 == v5
        v29 = v28 == 0
        v30 = v9 >= v5
        if v30:
            v31 = v9
        else:
            v31 = v5
        v32 = v9 < v5
        if v32:
            v33 = v9
        else:
            v33 = v5
        v34 = v31 - v33
        v35 = (<signed long>1) < v34
        if v35:
            v36 = (<signed long>1)
        else:
            v36 = v34
        v37 = v31 + v36
        if v29:
            v38 = (<signed long>0)
        else:
            v38 = (<signed long>1)
        v39 = (<signed long>5) < v37
        if v39:
            v40 = (<signed long>5)
        else:
            v40 = v37
        v41 = (<signed long>5) == v31
        if v41:
            v42 = (<signed long>1)
        else:
            v42 = (<signed long>0)
        v43 = v40 + v42
        v44 = v0[v38:3+(<signed long>5)-v43]
        return Closure9(v6, v7, v8, v9, v2, v3, v4, v5, v10, v44, v1, v0, v11, v12, v13, v14, v15)
cdef UH1 method31(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, US0 v14, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
    cdef object v35
    cdef bint v23
    cdef bint v25
    cdef signed char v26
    cdef signed char v27
    cdef unsigned char v28
    cdef signed long v29
    cdef signed char v30
    cdef signed char v31
    cdef unsigned char v32
    cdef signed long v33
    cdef bint v37
    cdef signed long v39
    cdef float v40
    cdef signed long v42
    cdef bint v43
    cdef object v44
    if v14.tag == 0: # call
        if v0:
            v23 = 0
            v35 = method30(v8, v23, v5, v6, v7, v4, v1, v2, v3, v9, v10, v11, v12, v13)
        else:
            v25 = v7 == (<unsigned char>0)
            if v25:
                v26, v27, v28, v29, v30, v31, v32, v33 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v26, v27, v28, v29, v30, v31, v32, v33 = v1, v2, v3, v4, v5, v6, v7, v4
            v35 = Closure2(v12, v8, v10, v11, v13, v30, v31, v32, v33, v26, v27, v28, v29)
        return v35(v15, v16, v17, v18, v19, v20, v21, v22)
    elif v14.tag == 1: # fold
        v37 = v7 == (<unsigned char>0)
        if v37:
            v39 = -v4
        else:
            v39 = v4
        v40 = <float>v39
        return UH1_1(v15, v16, v17, v18, v19, v20, v21, v22, v5, v6, v7, v4, v1, v2, v3, v4, v9, v40)
    elif v14.tag == 2: # raiseTo_
        v42 = (<US0_2>v14).v0
        v43 = 0
        v44 = method2(v8, v43, v5, v6, v7, v42, v1, v2, v3, v4, v9, v10, v11, v12, v13)
        return v44(v15, v16, v17, v18, v19, v20, v21, v22)
cdef object method30(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13):
    cdef bint v14
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed long v19
    cdef signed char v20
    cdef signed char v21
    cdef unsigned char v22
    cdef signed long v23
    cdef bint v25
    cdef bint v26
    cdef bint v27
    cdef signed long v28
    cdef bint v29
    cdef signed long v30
    cdef signed long v31
    cdef numpy.ndarray[object,ndim=1] v32
    v14 = v5 == (<signed long>5)
    if v14:
        v15 = v8 == (<unsigned char>0)
        if v15:
            v16, v17, v18, v19, v20, v21, v22, v23 = v6, v7, v8, v5, v2, v3, v4, v5
        else:
            v16, v17, v18, v19, v20, v21, v22, v23 = v2, v3, v4, v5, v6, v7, v8, v5
        return Closure2(v12, v0, v10, v11, v13, v20, v21, v22, v23, v16, v17, v18, v19)
    else:
        v25 = v5 >= v5
        v26 = v5 < v5
        v27 = (<signed long>5) < v5
        if v27:
            v28 = (<signed long>5)
        else:
            v28 = v5
        v29 = (<signed long>5) == v5
        if v29:
            v30 = (<signed long>1)
        else:
            v30 = (<signed long>0)
        v31 = v28 + v30
        v32 = v0[(<signed long>1):3+(<signed long>5)-v31]
        return Closure15(v6, v7, v8, v5, v2, v3, v4, v9, v32, v1, v0, v10, v11, v12, v13)
cdef UH1 method29(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US0 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
    cdef object v36
    cdef bint v24
    cdef bint v26
    cdef signed char v27
    cdef signed char v28
    cdef unsigned char v29
    cdef signed long v30
    cdef signed char v31
    cdef signed char v32
    cdef unsigned char v33
    cdef signed long v34
    cdef bint v38
    cdef signed long v40
    cdef float v41
    cdef signed long v43
    cdef bint v44
    cdef object v45
    if v15.tag == 0: # call
        if v0:
            v24 = 0
            v36 = method30(v9, v24, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14)
        else:
            v26 = v7 == (<unsigned char>0)
            if v26:
                v27, v28, v29, v30, v31, v32, v33, v34 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v27, v28, v29, v30, v31, v32, v33, v34 = v1, v2, v3, v4, v5, v6, v7, v4
            v36 = Closure2(v13, v9, v11, v12, v14, v31, v32, v33, v34, v27, v28, v29, v30)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v38 = v7 == (<unsigned char>0)
        if v38:
            v40 = -v8
        else:
            v40 = v8
        v41 = <float>v40
        return UH1_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v8, v1, v2, v3, v4, v10, v41)
    elif v15.tag == 2: # raiseTo_
        v43 = (<US0_2>v15).v0
        v44 = 0
        v45 = method2(v9, v44, v5, v6, v7, v43, v1, v2, v3, v4, v10, v11, v12, v13, v14)
        return v45(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method2(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, signed long v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
    cdef bint v15
    cdef bint v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed long v20
    cdef signed char v21
    cdef signed char v22
    cdef unsigned char v23
    cdef signed long v24
    cdef bint v27
    cdef bint v28
    cdef bint v29
    cdef signed long v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef bint v34
    cdef signed long v35
    cdef signed long v36
    cdef signed long v37
    cdef bint v38
    cdef signed long v39
    cdef bint v40
    cdef signed long v41
    cdef signed long v42
    cdef numpy.ndarray[object,ndim=1] v43
    v15 = v9 == (<signed long>5)
    if v15:
        v16 = v8 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22, v23, v24 = v6, v7, v8, v9, v2, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22, v23, v24 = v2, v3, v4, v5, v6, v7, v8, v9
        return Closure2(v13, v0, v11, v12, v14, v21, v22, v23, v24, v17, v18, v19, v20)
    else:
        if v1:
            v27 = 1
        else:
            v27 = v9 == v5
        v28 = v27 == 0
        v29 = v9 >= v5
        if v29:
            v30 = v9
        else:
            v30 = v5
        v31 = v9 < v5
        if v31:
            v32 = v9
        else:
            v32 = v5
        v33 = v30 - v32
        v34 = (<signed long>1) < v33
        if v34:
            v35 = (<signed long>1)
        else:
            v35 = v33
        v36 = v30 + v35
        if v28:
            v37 = (<signed long>0)
        else:
            v37 = (<signed long>1)
        v38 = (<signed long>5) < v36
        if v38:
            v39 = (<signed long>5)
        else:
            v39 = v36
        v40 = (<signed long>5) == v30
        if v40:
            v41 = (<signed long>1)
        else:
            v41 = (<signed long>0)
        v42 = v39 + v41
        v43 = v0[v37:3+(<signed long>5)-v42]
        return Closure13(v6, v7, v8, v9, v2, v3, v4, v5, v10, v43, v1, v0, v11, v12, v13, v14)
cdef UH1 method34(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, US0 v11, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
    cdef object v32
    cdef bint v20
    cdef bint v22
    cdef signed char v23
    cdef signed char v24
    cdef unsigned char v25
    cdef signed long v26
    cdef signed char v27
    cdef signed char v28
    cdef unsigned char v29
    cdef signed long v30
    cdef bint v34
    cdef signed long v36
    cdef float v37
    cdef signed long v39
    cdef bint v40
    cdef object v41
    if v11.tag == 0: # call
        if v0:
            v20 = 0
            v32 = method33(v8, v20, v5, v6, v7, v4, v1, v2, v3, v9, v10)
        else:
            v22 = v7 == (<unsigned char>0)
            if v22:
                v23, v24, v25, v26, v27, v28, v29, v30 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v23, v24, v25, v26, v27, v28, v29, v30 = v1, v2, v3, v4, v5, v6, v7, v4
            v32 = Closure1(v10, v8, v27, v28, v29, v30, v23, v24, v25, v26)
        return v32(v12, v13, v14, v15, v16, v17, v18, v19)
    elif v11.tag == 1: # fold
        v34 = v7 == (<unsigned char>0)
        if v34:
            v36 = -v4
        else:
            v36 = v4
        v37 = <float>v36
        return UH1_1(v12, v13, v14, v15, v16, v17, v18, v19, v5, v6, v7, v4, v1, v2, v3, v4, v9, v37)
    elif v11.tag == 2: # raiseTo_
        v39 = (<US0_2>v11).v0
        v40 = 0
        v41 = method1(v8, v40, v5, v6, v7, v39, v1, v2, v3, v4, v9, v10)
        return v41(v12, v13, v14, v15, v16, v17, v18, v19)
cdef object method33(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10):
    cdef bint v11
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed long v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed long v20
    cdef bint v22
    cdef bint v23
    cdef bint v24
    cdef signed long v25
    cdef bint v26
    cdef signed long v27
    cdef signed long v28
    cdef numpy.ndarray[object,ndim=1] v29
    v11 = v5 == (<signed long>5)
    if v11:
        v12 = v8 == (<unsigned char>0)
        if v12:
            v13, v14, v15, v16, v17, v18, v19, v20 = v6, v7, v8, v5, v2, v3, v4, v5
        else:
            v13, v14, v15, v16, v17, v18, v19, v20 = v2, v3, v4, v5, v6, v7, v8, v5
        return Closure1(v10, v0, v17, v18, v19, v20, v13, v14, v15, v16)
    else:
        v22 = v5 >= v5
        v23 = v5 < v5
        v24 = (<signed long>5) < v5
        if v24:
            v25 = (<signed long>5)
        else:
            v25 = v5
        v26 = (<signed long>5) == v5
        if v26:
            v27 = (<signed long>1)
        else:
            v27 = (<signed long>0)
        v28 = v25 + v27
        v29 = v0[(<signed long>1):3+(<signed long>5)-v28]
        return Closure19(v6, v7, v8, v5, v2, v3, v4, v9, v29, v1, v0, v10)
cdef UH1 method32(bint v0, signed char v1, signed char v2, unsigned char v3, signed long v4, signed char v5, signed char v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, US0 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
    cdef object v33
    cdef bint v21
    cdef bint v23
    cdef signed char v24
    cdef signed char v25
    cdef unsigned char v26
    cdef signed long v27
    cdef signed char v28
    cdef signed char v29
    cdef unsigned char v30
    cdef signed long v31
    cdef bint v35
    cdef signed long v37
    cdef float v38
    cdef signed long v40
    cdef bint v41
    cdef object v42
    if v12.tag == 0: # call
        if v0:
            v21 = 0
            v33 = method33(v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v23 = v7 == (<unsigned char>0)
            if v23:
                v24, v25, v26, v27, v28, v29, v30, v31 = v5, v6, v7, v4, v1, v2, v3, v4
            else:
                v24, v25, v26, v27, v28, v29, v30, v31 = v1, v2, v3, v4, v5, v6, v7, v4
            v33 = Closure1(v11, v9, v28, v29, v30, v31, v24, v25, v26, v27)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # fold
        v35 = v7 == (<unsigned char>0)
        if v35:
            v37 = -v8
        else:
            v37 = v8
        v38 = <float>v37
        return UH1_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v8, v1, v2, v3, v4, v10, v38)
    elif v12.tag == 2: # raiseTo_
        v40 = (<US0_2>v12).v0
        v41 = 0
        v42 = method1(v9, v41, v5, v6, v7, v40, v1, v2, v3, v4, v10, v11)
        return v42(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method1(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed long v5, signed char v6, signed char v7, unsigned char v8, signed long v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11):
    cdef bint v12
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed long v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed long v21
    cdef bint v24
    cdef bint v25
    cdef bint v26
    cdef signed long v27
    cdef bint v28
    cdef signed long v29
    cdef signed long v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef signed long v34
    cdef bint v35
    cdef signed long v36
    cdef bint v37
    cdef signed long v38
    cdef signed long v39
    cdef numpy.ndarray[object,ndim=1] v40
    v12 = v9 == (<signed long>5)
    if v12:
        v13 = v8 == (<unsigned char>0)
        if v13:
            v14, v15, v16, v17, v18, v19, v20, v21 = v6, v7, v8, v9, v2, v3, v4, v5
        else:
            v14, v15, v16, v17, v18, v19, v20, v21 = v2, v3, v4, v5, v6, v7, v8, v9
        return Closure1(v11, v0, v18, v19, v20, v21, v14, v15, v16, v17)
    else:
        if v1:
            v24 = 1
        else:
            v24 = v9 == v5
        v25 = v24 == 0
        v26 = v9 >= v5
        if v26:
            v27 = v9
        else:
            v27 = v5
        v28 = v9 < v5
        if v28:
            v29 = v9
        else:
            v29 = v5
        v30 = v27 - v29
        v31 = (<signed long>1) < v30
        if v31:
            v32 = (<signed long>1)
        else:
            v32 = v30
        v33 = v27 + v32
        if v25:
            v34 = (<signed long>0)
        else:
            v34 = (<signed long>1)
        v35 = (<signed long>5) < v33
        if v35:
            v36 = (<signed long>5)
        else:
            v36 = v33
        v37 = (<signed long>5) == v27
        if v37:
            v38 = (<signed long>1)
        else:
            v38 = (<signed long>0)
        v39 = v36 + v38
        v40 = v0[v34:3+(<signed long>5)-v39]
        return Closure17(v6, v7, v8, v9, v2, v3, v4, v5, v10, v40, v1, v0, v11)
cpdef object main():
    cdef numpy.ndarray[signed char,ndim=1] v0
    cdef numpy.ndarray[object,ndim=1] v1
    cdef Mut0 v2
    cdef signed long v4
    cdef bint v5
    cdef US0 v13
    cdef bint v7
    cdef signed long v9
    cdef signed long v10
    cdef signed long v14
    v0 = numpy.arange(0,52,dtype=numpy.int8)
    numpy.random.shuffle(v0)
    v1 = numpy.empty((<signed long>5),dtype=object)
    v2 = Mut0((<signed long>0))
    while method0(v2):
        v4 = v2.v0
        v5 = v4 == (<signed long>0)
        if v5:
            v13 = US0_1()
        else:
            v7 = v4 == (<signed long>1)
            if v7:
                v13 = US0_0()
            else:
                v9 = (<signed long>5) - v4
                v10 = v9 + (<signed long>2)
                v13 = US0_2(v10)
        v1[v4] = v13
        del v13
        v14 = v4 + (<signed long>1)
        v2.v0 = v14
    del v2
    return Closure0(v0, v1)
