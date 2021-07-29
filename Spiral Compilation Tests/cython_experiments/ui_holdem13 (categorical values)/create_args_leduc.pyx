import numpy
cimport numpy
cimport libc.math
import collections
import torch
cdef class Mut0:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
ctypedef signed long US1
ctypedef signed long US2
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # c1of2_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # c2of2_
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US0 v0
    cdef readonly UH0 v1
    def __init__(self, US0 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
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
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly bint v14
    cdef readonly US1 v15
    cdef readonly unsigned char v16
    cdef readonly object v17
    cdef readonly object v18
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, unsigned char v16, v17, v18): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
cdef class UH1_1(UH1): # terminal_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly bint v14
    cdef readonly US1 v15
    cdef readonly float v16
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, float v16): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure5():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef signed long v8
    cdef UH0 v9
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    cdef float v16
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15, float v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, US2 v19):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef bint v20
        cdef float v21
        cdef float v22
        cdef US0 v23
        cdef UH0 v24
        cdef US0 v25
        cdef UH0 v26
        cdef float v28
        cdef float v29
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        v20 = v0 == (<unsigned char>0)
        if v20:
            v21 = v18 + v14
            v22 = v17 + v13
            v23 = US0_1(v19)
            v24 = UH0_0(v23, v12)
            del v23
            v25 = US0_1(v19)
            v26 = UH0_0(v25, v9)
            del v25
            return method7(v1, v2, v3, v4, v5, v6, v7, v0, v8, v19, v15, v16, v24, v22, v21, v26, v10, v11)
        else:
            v28 = v18 + v11
            v29 = v17 + v10
            v30 = US0_1(v19)
            v31 = UH0_0(v30, v12)
            del v30
            v32 = US0_1(v19)
            v33 = UH0_0(v32, v9)
            del v32
            return method7(v1, v2, v3, v4, v5, v6, v7, v0, v8, v19, v15, v16, v31, v13, v14, v33, v29, v28)
cdef class Closure4():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef US1 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US1 v6
    cdef signed long v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, signed long v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US2 v18):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef US1 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US1 v6 = self.v6
        cdef signed long v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef bint v19
        cdef float v20
        cdef float v21
        cdef US0 v22
        cdef US0 v23
        cdef UH0 v24
        cdef UH0 v25
        cdef US0 v26
        cdef US0 v27
        cdef UH0 v28
        cdef UH0 v29
        cdef float v31
        cdef float v32
        cdef US0 v33
        cdef US0 v34
        cdef UH0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef US0 v38
        cdef UH0 v39
        cdef UH0 v40
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v13
            v21 = v16 + v12
            v22 = US0_1(v18)
            v23 = US0_0(v1)
            v24 = UH0_0(v23, v11)
            del v23
            v25 = UH0_0(v22, v24)
            del v22; del v24
            v26 = US0_1(v18)
            v27 = US0_0(v1)
            v28 = UH0_0(v27, v8)
            del v27
            v29 = UH0_0(v26, v28)
            del v26; del v28
            return method5(v1, v2, v3, v4, v5, v6, v0, v7, v18, v14, v15, v25, v21, v20, v29, v9, v10)
        else:
            v31 = v17 + v10
            v32 = v16 + v9
            v33 = US0_1(v18)
            v34 = US0_0(v1)
            v35 = UH0_0(v34, v11)
            del v34
            v36 = UH0_0(v33, v35)
            del v33; del v35
            v37 = US0_1(v18)
            v38 = US0_0(v1)
            v39 = UH0_0(v38, v8)
            del v38
            v40 = UH0_0(v37, v39)
            del v37; del v39
            return method5(v1, v2, v3, v4, v5, v6, v0, v7, v18, v14, v15, v36, v12, v13, v40, v32, v31)
cdef class Closure6():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef signed long v8
    cdef UH0 v9
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    cdef float v16
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15, float v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, US2 v19):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef bint v20
        cdef float v21
        cdef float v22
        cdef US0 v23
        cdef UH0 v24
        cdef US0 v25
        cdef UH0 v26
        cdef float v28
        cdef float v29
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        v20 = v0 == (<unsigned char>0)
        if v20:
            v21 = v18 + v14
            v22 = v17 + v13
            v23 = US0_1(v19)
            v24 = UH0_0(v23, v12)
            del v23
            v25 = US0_1(v19)
            v26 = UH0_0(v25, v9)
            del v25
            return method9(v1, v2, v3, v4, v5, v6, v7, v0, v8, v19, v15, v16, v24, v22, v21, v26, v10, v11)
        else:
            v28 = v18 + v11
            v29 = v17 + v10
            v30 = US0_1(v19)
            v31 = UH0_0(v30, v12)
            del v30
            v32 = US0_1(v19)
            v33 = UH0_0(v32, v9)
            del v32
            return method9(v1, v2, v3, v4, v5, v6, v7, v0, v8, v19, v15, v16, v31, v13, v14, v33, v29, v28)
cdef class Closure3():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US2 v18):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef bint v19
        cdef float v20
        cdef float v21
        cdef US0 v22
        cdef UH0 v23
        cdef US0 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
        cdef US0 v29
        cdef UH0 v30
        cdef US0 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v13
            v21 = v16 + v12
            v22 = US0_1(v18)
            v23 = UH0_0(v22, v11)
            del v22
            v24 = US0_1(v18)
            v25 = UH0_0(v24, v8)
            del v24
            return method4(v1, v2, v3, v4, v5, v6, v7, v0, v18, v14, v15, v23, v21, v20, v25, v9, v10)
        else:
            v27 = v17 + v10
            v28 = v16 + v9
            v29 = US0_1(v18)
            v30 = UH0_0(v29, v11)
            del v29
            v31 = US0_1(v18)
            v32 = UH0_0(v31, v8)
            del v31
            return method4(v1, v2, v3, v4, v5, v6, v7, v0, v18, v14, v15, v30, v12, v13, v32, v28, v27)
cdef class Closure2():
    cdef US1 v0
    cdef US1 v1
    cdef US1 v2
    cdef Heap0 v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef float v10
    cdef float v11
    def __init__(self, US1 v0, US1 v1, US1 v2, Heap0 v3, UH0 v4, float v5, float v6, UH0 v7, float v8, float v9, float v10, float v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, float v12, float v13, US2 v14):
        cdef US1 v0 = self.v0
        cdef US1 v1 = self.v1
        cdef US1 v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef float v5 = self.v5
        cdef float v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef float v15
        cdef float v16
        cdef US0 v17
        cdef US0 v18
        cdef UH0 v19
        cdef UH0 v20
        cdef US0 v21
        cdef US0 v22
        cdef UH0 v23
        cdef UH0 v24
        v15 = v13 + v9
        v16 = v12 + v8
        v17 = US0_1(v14)
        v18 = US0_0(v0)
        v19 = UH0_0(v18, v7)
        del v18
        v20 = UH0_0(v17, v19)
        del v17; del v19
        v21 = US0_1(v14)
        v22 = US0_0(v1)
        v23 = UH0_0(v22, v4)
        del v22
        v24 = UH0_0(v21, v23)
        del v21; del v23
        return method2(v0, v1, v2, v3, v14, v10, v11, v20, v16, v15, v24, v5, v6)
cdef class Tuple0:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly bint v14
    cdef readonly US1 v15
    cdef readonly unsigned char v16
    cdef readonly object v17
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, unsigned char v16, v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class Tuple1:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple2:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US2 v2
    def __init__(self, float v0, float v1, US2 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure1():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, unsigned long long v3, v4):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v5
        cdef Mut0 v6
        cdef unsigned long long v8
        cdef UH0 v9
        cdef float v10
        cdef float v11
        cdef UH0 v12
        cdef float v13
        cdef float v14
        cdef float v15
        cdef float v16
        cdef UH1 v17
        cdef unsigned long long v18
        v5 = numpy.empty(v3,dtype=object)
        v6 = Mut0((<unsigned long long>0))
        while method0(v3, v6):
            v8 = v6.v0
            v9 = UH0_1()
            v10 = (<float>0)
            v11 = (<float>0)
            v12 = UH0_1()
            v13 = (<float>0)
            v14 = (<float>0)
            v15 = (<float>0)
            v16 = (<float>0)
            v17 = method1(v15, v16, v9, v10, v11, v12, v13, v14)
            del v9; del v12
            v5[v8] = v17
            del v17
            v18 = v8 + (<unsigned long long>1)
            v6.v0 = v18
        del v6
        return method10(v0, v1, v2, v4, v5)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0, v1, v2):
        return Closure1(v2, v1, v0)
cdef class Closure7():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1):
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut0 v3
        cdef unsigned long long v5
        cdef UH0 v6
        cdef float v7
        cdef float v8
        cdef UH0 v9
        cdef float v10
        cdef float v11
        cdef float v12
        cdef float v13
        cdef UH1 v14
        cdef unsigned long long v15
        v2 = numpy.empty(v0,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v0, v3):
            v5 = v3.v0
            v6 = UH0_1()
            v7 = (<float>0)
            v8 = (<float>0)
            v9 = UH0_1()
            v10 = (<float>0)
            v11 = (<float>0)
            v12 = (<float>0)
            v13 = (<float>0)
            v14 = method1(v12, v13, v6, v7, v8, v9, v10, v11)
            del v6; del v9
            v2[v5] = v14
            del v14
            v15 = v5 + (<unsigned long long>1)
            v3.v0 = v15
        del v3
        return method11(v1, v2)
cdef class Closure9():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, unsigned long long v3, v4, v5):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v6
        cdef Mut0 v7
        cdef unsigned long long v9
        cdef UH0 v10
        cdef float v11
        cdef float v12
        cdef UH0 v13
        cdef float v14
        cdef float v15
        cdef float v16
        cdef float v17
        cdef UH1 v18
        cdef unsigned long long v19
        v6 = numpy.empty(v3,dtype=object)
        v7 = Mut0((<unsigned long long>0))
        while method0(v3, v7):
            v9 = v7.v0
            v10 = UH0_1()
            v11 = (<float>0)
            v12 = (<float>0)
            v13 = UH0_1()
            v14 = (<float>0)
            v15 = (<float>0)
            v16 = (<float>0)
            v17 = (<float>0)
            v18 = method1(v16, v17, v10, v11, v12, v13, v14, v15)
            del v10; del v13
            v6[v9] = v18
            del v18
            v19 = v9 + (<unsigned long long>1)
            v7.v0 = v19
        del v7
        return method12(v0, v1, v2, v5, v4, v6)
cdef class Closure8():
    def __init__(self): pass
    def __call__(self, v0, v1, v2):
        return Closure9(v2, v1, v0)
cdef class Mut1:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure10():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1, v2):
        cdef numpy.ndarray[object,ndim=1] v3
        cdef Mut0 v4
        cdef unsigned long long v6
        cdef UH0 v7
        cdef float v8
        cdef float v9
        cdef UH0 v10
        cdef float v11
        cdef float v12
        cdef float v13
        cdef float v14
        cdef UH1 v15
        cdef unsigned long long v16
        v3 = numpy.empty(v0,dtype=object)
        v4 = Mut0((<unsigned long long>0))
        while method0(v0, v4):
            v6 = v4.v0
            v7 = UH0_1()
            v8 = (<float>0)
            v9 = (<float>0)
            v10 = UH0_1()
            v11 = (<float>0)
            v12 = (<float>0)
            v13 = (<float>0)
            v14 = (<float>0)
            v15 = method1(v13, v14, v7, v8, v9, v10, v11, v12)
            del v7; del v10
            v3[v6] = v15
            del v15
            v16 = v6 + (<unsigned long long>1)
            v4.v0 = v16
        del v4
        return method13(v2, v1, v3)
cdef class Closure13():
    def __init__(self): pass
    def __call__(self, v0):
        return v0
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # c1of2_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US3_1(US3): # c2of2_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US3 v0
    cdef readonly UH2 v1
    def __init__(self, US3 v0, UH2 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Mut2:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Closure14():
    cdef list v0
    cdef unsigned long long v1
    cdef object v2
    def __init__(self, list v0, unsigned long long v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, v3):
        cdef list v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[float,ndim=1] v4
        cdef unsigned long long v5
        cdef Mut0 v6
        cdef unsigned long long v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef UH0 v14
        cdef float v15
        cdef float v16
        cdef US1 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef US1 v20
        cdef unsigned char v21
        cdef signed long v22
        cdef bint v23
        cdef US1 v24
        cdef unsigned char v25
        cdef numpy.ndarray[signed long,ndim=1] v26
        cdef Tuple0 tmp15
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef float v33
        cdef float v34
        cdef float v35
        cdef float v36
        cdef float v37
        cdef unsigned long long v38
        cdef object v39
        cdef object v40
        v4 = numpy.empty(v1,dtype=numpy.float32)
        v5 = len(v0)
        v6 = Mut0((<unsigned long long>0))
        while method0(v5, v6):
            v8 = v6.v0
            tmp15 = v0[v8]
            v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3, tmp15.v4, tmp15.v5, tmp15.v6, tmp15.v7, tmp15.v8, tmp15.v9, tmp15.v10, tmp15.v11, tmp15.v12, tmp15.v13, tmp15.v14, tmp15.v15, tmp15.v16, tmp15.v17
            del tmp15
            del v11; del v14; del v26
            v27 = v25 == (<unsigned char>0)
            if v27:
                v28, v29, v30, v31 = v12, v13, v15, v16
            else:
                v28, v29, v30, v31 = v15, v16, v12, v13
            v32 = v10 + v31
            v33 = v9 + v30
            v34 = -v29
            v35 = v33 - v32
            v36 = v34 + v35
            v37 = libc.math.exp(v36)
            v4[v8] = v37
            v38 = v8 + (<unsigned long long>1)
            v6.v0 = v38
        del v6
        v39 = torch.from_numpy(v3)
        v40 = torch.from_numpy(v4)
        del v4
        return v2(v39, v40)
cdef class Closure12():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, list v1):
        cdef object v0 = self.v0
        cdef unsigned long long v2
        cdef bint v3
        cdef numpy.ndarray[object,ndim=1] v4
        cdef object v5
        cdef unsigned long long v6
        cdef unsigned long long v7
        cdef Mut1 v8
        cdef unsigned long long v10
        cdef unsigned long long v11
        cdef unsigned long long v12
        cdef float v13
        cdef float v14
        cdef UH0 v15
        cdef float v16
        cdef float v17
        cdef UH0 v18
        cdef float v19
        cdef float v20
        cdef US1 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US1 v24
        cdef unsigned char v25
        cdef signed long v26
        cdef bint v27
        cdef US1 v28
        cdef unsigned char v29
        cdef numpy.ndarray[signed long,ndim=1] v30
        cdef Tuple0 tmp12
        cdef bint v31
        cdef UH0 v32
        cdef UH2 v37
        cdef US3 v34
        cdef UH2 v35
        cdef unsigned long long v38
        cdef unsigned long long v39
        cdef bint v40
        cdef unsigned long long v41
        cdef unsigned long long v42
        cdef unsigned long long v43
        cdef bint v44
        cdef unsigned long long v45
        cdef unsigned long long v46
        cdef unsigned long long v47
        cdef unsigned long long v48
        cdef unsigned long long v49
        cdef numpy.ndarray[float,ndim=3] v50
        cdef numpy.ndarray[signed char,ndim=2] v51
        cdef numpy.ndarray[float,ndim=3] v52
        cdef numpy.ndarray[signed char,ndim=2] v53
        cdef numpy.ndarray[signed char,ndim=2] v54
        cdef numpy.ndarray[unsigned char,ndim=1] v55
        cdef unsigned long long v56
        cdef Mut0 v57
        cdef unsigned long long v59
        cdef float v60
        cdef float v61
        cdef UH0 v62
        cdef float v63
        cdef float v64
        cdef UH0 v65
        cdef float v66
        cdef float v67
        cdef US1 v68
        cdef unsigned char v69
        cdef signed long v70
        cdef US1 v71
        cdef unsigned char v72
        cdef signed long v73
        cdef bint v74
        cdef US1 v75
        cdef unsigned char v76
        cdef numpy.ndarray[signed long,ndim=1] v77
        cdef Tuple0 tmp13
        cdef bint v78
        cdef UH0 v79
        cdef UH2 v84
        cdef US3 v81
        cdef UH2 v82
        cdef unsigned long long v85
        cdef unsigned long long v86
        cdef numpy.ndarray[float,ndim=1] v87
        cdef unsigned long long v88
        cdef unsigned long long v89
        cdef signed short v90
        cdef unsigned long long tmp14
        cdef Mut2 v91
        cdef signed short v93
        cdef US2 v94
        cdef signed short v95
        cdef signed short v96
        cdef unsigned long long v97
        cdef object v98
        cdef object v99
        cdef object v100
        cdef object v101
        cdef object v102
        cdef object v103
        cdef object v104
        cdef object v105
        cdef object v106
        cdef object v107
        cdef numpy.ndarray[float,ndim=2] v108
        cdef numpy.ndarray[signed long long,ndim=1] v109
        cdef object v110
        cdef numpy.ndarray[object,ndim=1] v111
        cdef Mut0 v112
        cdef unsigned long long v114
        cdef signed long long v115
        cdef bint v116
        cdef float v118
        cdef float v119
        cdef signed short v120
        cdef bint v121
        cdef US2 v138
        cdef bint v122
        cdef bint v123
        cdef bint v125
        cdef signed short v126
        cdef bint v127
        cdef bint v128
        cdef bint v130
        cdef signed short v131
        cdef bint v132
        cdef bint v133
        cdef unsigned long long v139
        cdef object v140
        v2 = len(v1)
        v3 = v2 == (<unsigned long long>0)
        if v3:
            v4 = numpy.empty((<unsigned long long>0),dtype=object)
            v5 = Closure13()
            return Tuple1(v4, v5)
        else:
            pass # import torch
            v6 = len(v1)
            v7 = len(v1)
            v8 = Mut1((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
            while method14(v7, v8):
                v10 = v8.v0
                v11, v12 = v8.v1, v8.v2
                tmp12 = v1[v10]
                v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3, tmp12.v4, tmp12.v5, tmp12.v6, tmp12.v7, tmp12.v8, tmp12.v9, tmp12.v10, tmp12.v11, tmp12.v12, tmp12.v13, tmp12.v14, tmp12.v15, tmp12.v16, tmp12.v17
                del tmp12
                del v30
                v31 = v29 == (<unsigned char>0)
                if v31:
                    v32 = v15
                else:
                    v32 = v18
                del v15; del v18
                if v27:
                    v37 = UH2_1()
                else:
                    v34 = US3_1(v28)
                    v35 = UH2_1()
                    v37 = UH2_0(v34, v35)
                    del v34; del v35
                v38 = (<unsigned long long>0)
                v39 = method15(v32, v38)
                del v32
                v40 = v11 >= v39
                if v40:
                    v41 = v11
                else:
                    v41 = v39
                v42 = (<unsigned long long>1)
                v43 = method16(v37, v42)
                del v37
                v44 = v12 >= v43
                if v44:
                    v45 = v12
                else:
                    v45 = v43
                v46 = v10 + (<unsigned long long>1)
                v8.v0 = v46
                v8.v1 = v41
                v8.v2 = v45
            v47, v48 = v8.v1, v8.v2
            del v8
            v49 = v47 + v48
            v50 = numpy.zeros((v6,v47,(<signed short>6)),dtype=numpy.float32)
            v51 = numpy.zeros((v6,v47),dtype=numpy.int8)
            v52 = numpy.zeros((v6,v49,(<signed short>12)),dtype=numpy.float32)
            v53 = numpy.zeros((v6,v49),dtype=numpy.int8)
            v54 = numpy.ones((v6,(<signed short>3)),dtype=numpy.int8)
            v55 = numpy.empty(v6,dtype=numpy.uint8)
            v56 = len(v1)
            v57 = Mut0((<unsigned long long>0))
            while method0(v56, v57):
                v59 = v57.v0
                tmp13 = v1[v59]
                v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3, tmp13.v4, tmp13.v5, tmp13.v6, tmp13.v7, tmp13.v8, tmp13.v9, tmp13.v10, tmp13.v11, tmp13.v12, tmp13.v13, tmp13.v14, tmp13.v15, tmp13.v16, tmp13.v17
                del tmp13
                v78 = v76 == (<unsigned char>0)
                if v78:
                    v79 = v62
                else:
                    v79 = v65
                del v62; del v65
                if v74:
                    v84 = UH2_1()
                else:
                    v81 = US3_1(v75)
                    v82 = UH2_1()
                    v84 = UH2_0(v81, v82)
                    del v81; del v82
                v85 = (<unsigned long long>0)
                v86 = method17(v50, v52, v59, v79, v85)
                del v79
                method18(v47, v51, v59, v86)
                v87 = v52[v59,v86,:]
                if v71 == 0: # jack
                    v87[(<signed short>6)] = (<float>1)
                elif v71 == 1: # king
                    v87[(<signed short>7)] = (<float>1)
                elif v71 == 2: # queen
                    v87[(<signed short>8)] = (<float>1)
                del v87
                v88 = v86 + (<unsigned long long>1)
                v89 = method19(v52, v59, v84, v88)
                del v84
                method20(v49, v53, v59, v89)
                tmp14 = len(v77)
                if <signed short>tmp14 != tmp14: raise Exception("The conversion to signed short failed.")
                v90 = <signed short>tmp14
                v91 = Mut2((<signed short>0))
                while method21(v90, v91):
                    v93 = v91.v0
                    v94 = v77[v93]
                    if v94 == 0: # call
                        v95 = (<signed short>0)
                    elif v94 == 1: # fold
                        v95 = (<signed short>1)
                    elif v94 == 2: # raise
                        v95 = (<signed short>2)
                    v54[v59,v95] = 0
                    v96 = v93 + (<signed short>1)
                    v91.v0 = v96
                del v77
                del v91
                v55[v59] = v76
                v97 = v59 + (<unsigned long long>1)
                v57.v0 = v97
            del v57
            v98 = torch.from_numpy(v50)
            del v50
            v99 = v51.view('bool')
            del v51
            v100 = torch.from_numpy(v99)
            del v99
            v101 = torch.from_numpy(v52)
            del v52
            v102 = v53.view('bool')
            del v53
            v103 = torch.from_numpy(v102)
            del v102
            v104 = v54.view('bool')
            del v54
            v105 = torch.from_numpy(v104)
            del v104
            v106 = torch.from_numpy(v55)
            del v55
            v107 = v0(v98, v100, v101, v103, v105, v106)
            del v98; del v100; del v101; del v103; del v105; del v106
            v108 = v107[0]
            v109 = v107[1]
            v110 = v107[2]
            del v107
            v111 = numpy.empty(v6,dtype=object)
            v112 = Mut0((<unsigned long long>0))
            while method0(v6, v112):
                v114 = v112.v0
                v115 = v109[v114]
                v116 = v108 is None
                if v116:
                    v118 = (<float>1)
                else:
                    v118 = v108[v114,v115]
                v119 = libc.math.log(v118)
                v120 = <signed short>v115
                v121 = v120 < (<signed short>1)
                if v121:
                    v122 = v120 == (<signed short>0)
                    v123 = v122 == 0
                    if v123:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v138 = 0
                else:
                    v125 = v120 < (<signed short>2)
                    if v125:
                        v126 = v120 - (<signed short>1)
                        v127 = v126 == (<signed short>0)
                        v128 = v127 == 0
                        if v128:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v138 = 1
                    else:
                        v130 = v120 < (<signed short>3)
                        if v130:
                            v131 = v120 - (<signed short>2)
                            v132 = v131 == (<signed short>0)
                            v133 = v132 == 0
                            if v133:
                                raise Exception("The unit index should be 0.")
                            else:
                                pass
                            v138 = 2
                        else:
                            raise Exception("Unpickle failure. Unpickling of an union failed.")
                v111[v114] = Tuple2(v119, v119, v138)
                v139 = v114 + (<unsigned long long>1)
                v112.v0 = v139
            del v108; del v109
            del v112
            v140 = Closure14(v1, v6, v110)
            del v110
            return Tuple1(v111, v140)
cdef class Closure11():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure12(v0)
cdef class Mut3:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut4:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple3:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut4 v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, Mut4 v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple4:
    cdef readonly Mut4 v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, Mut4 v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut5:
    cdef public signed long long v0
    cdef public float v1
    def __init__(self, signed long long v0, float v1): self.v0 = v0; self.v1 = v1
cdef class Mut6:
    cdef public signed long long v0
    def __init__(self, signed long long v0): self.v0 = v0
cdef class Tuple5:
    cdef readonly unsigned long long v0
    cdef readonly UH2 v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, unsigned long long v0, UH2 v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple6:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure15():
    def __init__(self): pass
    def __call__(self, Mut3 v0, Mut3 v1):
        method22(v0, v1)
cdef class Closure16():
    def __init__(self): pass
    def __call__(self):
        cdef unsigned long long v0
        cdef unsigned long long v1
        v0 = (<unsigned long long>3)
        v1 = (<unsigned long long>7)
        return method41(v0, v1)
cdef class Tuple7:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure19():
    cdef bint v0
    cdef bint v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    def __init__(self, bint v0, bint v1, numpy.ndarray[float,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[signed long long,ndim=1] v6, numpy.ndarray[unsigned char,ndim=1] v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
    def __call__(self, numpy.ndarray[float,ndim=1] v8):
        cdef bint v0 = self.v0
        cdef bint v1 = self.v1
        cdef numpy.ndarray[float,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[signed long long,ndim=1] v6 = self.v6
        cdef numpy.ndarray[unsigned char,ndim=1] v7 = self.v7
        cdef unsigned long long v9
        cdef unsigned long long v10
        cdef bint v11
        cdef bint v12
        cdef numpy.ndarray[float,ndim=1] v13
        cdef Mut0 v14
        cdef unsigned long long v16
        cdef float v17
        cdef unsigned char v18
        cdef bint v19
        cdef float v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef unsigned long long v24
        cdef bint v25
        cdef bint v31
        cdef unsigned long long v26
        cdef bint v27
        cdef unsigned long long v28
        cdef bint v32
        cdef numpy.ndarray[object,ndim=1] v33
        cdef Mut0 v34
        cdef unsigned long long v36
        cdef numpy.ndarray[float,ndim=1] v37
        cdef numpy.ndarray[float,ndim=1] v38
        cdef numpy.ndarray[float,ndim=1] v39
        cdef numpy.ndarray[float,ndim=1] v40
        cdef Tuple7 tmp27
        cdef signed long long v41
        cdef numpy.ndarray[float,ndim=1] v42
        cdef float v43
        cdef signed long long v44
        cdef signed long long v45
        cdef bint v46
        cdef bint v47
        cdef numpy.ndarray[float,ndim=1] v48
        cdef Mut6 v49
        cdef signed long long v51
        cdef float v52
        cdef float v53
        cdef bint v54
        cdef bint v55
        cdef float v57
        cdef bint v58
        cdef float v63
        cdef float v59
        cdef float v60
        cdef float v61
        cdef signed long long v64
        cdef unsigned long long v65
        cdef unsigned long long v66
        cdef unsigned long long v67
        cdef bint v68
        cdef bint v69
        cdef numpy.ndarray[float,ndim=1] v70
        cdef Mut0 v71
        cdef unsigned long long v73
        cdef numpy.ndarray[float,ndim=1] v74
        cdef numpy.ndarray[float,ndim=1] v75
        cdef signed long long v76
        cdef signed long long v77
        cdef bint v78
        cdef bint v79
        cdef Mut5 v80
        cdef signed long long v82
        cdef float v83
        cdef float v84
        cdef float v85
        cdef float v86
        cdef float v87
        cdef signed long long v88
        cdef float v89
        cdef unsigned long long v90
        cdef bint v96
        cdef unsigned long long v91
        cdef bint v92
        cdef unsigned long long v93
        cdef bint v97
        cdef Mut0 v98
        cdef unsigned long long v100
        cdef numpy.ndarray[float,ndim=1] v101
        cdef numpy.ndarray[float,ndim=1] v102
        cdef numpy.ndarray[float,ndim=1] v103
        cdef numpy.ndarray[float,ndim=1] v104
        cdef Tuple7 tmp28
        cdef signed long long v105
        cdef float v106
        cdef float v107
        cdef float v108
        cdef float v109
        cdef float v110
        cdef float v111
        cdef float v112
        cdef unsigned long long v113
        cdef bint v114
        cdef bint v120
        cdef unsigned long long v115
        cdef bint v116
        cdef unsigned long long v117
        cdef bint v121
        cdef Mut0 v122
        cdef unsigned long long v124
        cdef numpy.ndarray[float,ndim=1] v125
        cdef numpy.ndarray[float,ndim=1] v126
        cdef numpy.ndarray[float,ndim=1] v127
        cdef numpy.ndarray[float,ndim=1] v128
        cdef Tuple7 tmp29
        cdef numpy.ndarray[float,ndim=1] v129
        cdef float v130
        cdef float v131
        cdef signed long long v132
        cdef Mut6 v133
        cdef signed long long v135
        cdef float v136
        cdef float v137
        cdef float v138
        cdef float v139
        cdef float v140
        cdef signed long long v141
        cdef unsigned long long v142
        cdef unsigned long long v143
        cdef bint v144
        cdef bint v145
        cdef numpy.ndarray[float,ndim=1] v146
        cdef Mut0 v147
        cdef unsigned long long v149
        cdef float v150
        cdef unsigned char v151
        cdef bint v152
        cdef float v154
        cdef float v153
        cdef unsigned long long v155
        v9 = len(v8)
        v10 = len(v7)
        v11 = v9 == v10
        v12 = v11 == 0
        if v12:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v13 = numpy.empty(v9,dtype=numpy.float32)
        v14 = Mut0((<unsigned long long>0))
        while method0(v9, v14):
            v16 = v14.v0
            v17 = v8[v16]
            v18 = v7[v16]
            v19 = v18 == (<unsigned char>0)
            if v19:
                v21 = v17
            else:
                v21 = -v17
            v13[v16] = v21
            v22 = v16 + (<unsigned long long>1)
            v14.v0 = v22
        del v14
        v23 = len(v3)
        v24 = len(v6)
        v25 = v23 == v24
        if v25:
            v26 = len(v5)
            v27 = v23 == v26
            if v27:
                v28 = len(v13)
                v31 = v23 == v28
            else:
                v31 = 0
        else:
            v31 = 0
        v32 = v31 == 0
        if v32:
            raise Exception("The length of the four arrays has to the same.")
        else:
            pass
        v33 = numpy.empty(v23,dtype=object)
        v34 = Mut0((<unsigned long long>0))
        while method0(v23, v34):
            v36 = v34.v0
            tmp27 = v3[v36]
            v37, v38, v39, v40 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3
            del tmp27
            del v39; del v40
            v41 = v6[v36]
            v42 = v5[v36]
            v43 = v13[v36]
            v44 = len(v38)
            v45 = len(v37)
            v46 = v44 == v45
            v47 = v46 == 0
            if v47:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v48 = numpy.empty(v44,dtype=numpy.float32)
            v49 = Mut6((<signed long long>0))
            while method32(v44, v49):
                v51 = v49.v0
                v52 = v38[v51]
                v53 = v37[v51]
                v54 = v53 == (<float>0)
                v55 = v54 != 1
                if v55:
                    v57 = v52 / v53
                else:
                    v57 = (<float>0)
                v58 = v41 == v51
                if v58:
                    v59 = v43 - v57
                    v60 = v42[v41]
                    v61 = v59 / v60
                    v63 = v61 + v57
                else:
                    v63 = v57
                v48[v51] = v63
                v64 = v51 + (<signed long long>1)
                v49.v0 = v64
            del v37; del v38; del v42
            del v49
            v33[v36] = v48
            del v48
            v65 = v36 + (<unsigned long long>1)
            v34.v0 = v65
        del v34
        v66 = len(v33)
        v67 = len(v4)
        v68 = v66 == v67
        v69 = v68 == 0
        if v69:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v70 = numpy.empty(v66,dtype=numpy.float32)
        v71 = Mut0((<unsigned long long>0))
        while method0(v66, v71):
            v73 = v71.v0
            v74 = v33[v73]
            v75 = v4[v73]
            v76 = len(v74)
            v77 = len(v75)
            v78 = v76 == v77
            v79 = v78 == 0
            if v79:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v80 = Mut5((<signed long long>0), (<float>0))
            while method31(v76, v80):
                v82 = v80.v0
                v83 = v80.v1
                v84 = v74[v82]
                v85 = v75[v82]
                v86 = v84 * v85
                v87 = v83 + v86
                v88 = v82 + (<signed long long>1)
                v80.v0 = v88
                v80.v1 = v87
            del v74; del v75
            v89 = v80.v1
            del v80
            v70[v73] = v89
            v90 = v73 + (<unsigned long long>1)
            v71.v0 = v90
        del v71
        if v1:
            if v25:
                v91 = len(v13)
                v92 = v23 == v91
                if v92:
                    v93 = len(v2)
                    v96 = v23 == v93
                else:
                    v96 = 0
            else:
                v96 = 0
            v97 = v96 == 0
            if v97:
                raise Exception("The length of the four arrays has to the same.")
            else:
                pass
            v98 = Mut0((<unsigned long long>0))
            while method0(v23, v98):
                v100 = v98.v0
                tmp28 = v3[v100]
                v101, v102, v103, v104 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3
                del tmp28
                del v103; del v104
                v105 = v6[v100]
                v106 = v13[v100]
                v107 = v2[v100]
                v108 = v106 * v107
                v109 = v102[v105]
                v110 = v109 + v108
                v102[v105] = v110
                del v102
                v111 = v101[v105]
                v112 = v111 + v107
                v101[v105] = v112
                del v101
                v113 = v100 + (<unsigned long long>1)
                v98.v0 = v113
            del v98
        else:
            pass
        del v13
        if v0:
            v114 = v23 == v66
            if v114:
                v115 = len(v70)
                v116 = v23 == v115
                if v116:
                    v117 = len(v2)
                    v120 = v23 == v117
                else:
                    v120 = 0
            else:
                v120 = 0
            v121 = v120 == 0
            if v121:
                raise Exception("The length of the four arrays has to the same.")
            else:
                pass
            v122 = Mut0((<unsigned long long>0))
            while method0(v23, v122):
                v124 = v122.v0
                tmp29 = v3[v124]
                v125, v126, v127, v128 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3
                del tmp29
                del v125; del v126; del v127
                v129 = v33[v124]
                v130 = v70[v124]
                v131 = v2[v124]
                v132 = len(v128)
                v133 = Mut6((<signed long long>0))
                while method32(v132, v133):
                    v135 = v133.v0
                    v136 = v128[v135]
                    v137 = v129[v135]
                    v138 = v137 - v130
                    v139 = v131 * v138
                    v140 = v136 + v139
                    v128[v135] = v140
                    v141 = v135 + (<signed long long>1)
                    v133.v0 = v141
                del v128; del v129
                del v133
                v142 = v124 + (<unsigned long long>1)
                v122.v0 = v142
            del v122
        else:
            pass
        del v33
        v143 = len(v70)
        v144 = v143 == v10
        v145 = v144 == 0
        if v145:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v146 = numpy.empty(v143,dtype=numpy.float32)
        v147 = Mut0((<unsigned long long>0))
        while method0(v143, v147):
            v149 = v147.v0
            v150 = v70[v149]
            v151 = v7[v149]
            v152 = v151 == (<unsigned char>0)
            if v152:
                v154 = v150
            else:
                v153 = -v150
                v154 = v153
            v146[v149] = v154
            v155 = v149 + (<unsigned long long>1)
            v147.v0 = v155
        del v70
        del v147
        return v146
cdef class Closure18():
    cdef float v0
    cdef bint v1
    cdef bint v2
    cdef Mut3 v3
    def __init__(self, float v0, bint v1, bint v2, Mut3 v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, list v4):
        cdef float v0 = self.v0
        cdef bint v1 = self.v1
        cdef bint v2 = self.v2
        cdef Mut3 v3 = self.v3
        cdef unsigned long long v5
        cdef numpy.ndarray[float,ndim=1] v6
        cdef numpy.ndarray[object,ndim=1] v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef numpy.ndarray[object,ndim=1] v9
        cdef numpy.ndarray[signed long long,ndim=1] v10
        cdef numpy.ndarray[unsigned char,ndim=1] v11
        cdef unsigned long long v12
        cdef numpy.ndarray[object,ndim=1] v13
        cdef Mut0 v14
        cdef unsigned long long v16
        cdef float v17
        cdef float v18
        cdef UH0 v19
        cdef float v20
        cdef float v21
        cdef UH0 v22
        cdef float v23
        cdef float v24
        cdef US1 v25
        cdef unsigned char v26
        cdef signed long v27
        cdef US1 v28
        cdef unsigned char v29
        cdef signed long v30
        cdef bint v31
        cdef US1 v32
        cdef unsigned char v33
        cdef numpy.ndarray[signed long,ndim=1] v34
        cdef Tuple0 tmp24
        cdef bint v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef UH0 v46
        cdef UH2 v51
        cdef US3 v48
        cdef UH2 v49
        cdef unsigned long long v52
        cdef Mut4 v53
        cdef numpy.ndarray[float,ndim=1] v54
        cdef numpy.ndarray[float,ndim=1] v55
        cdef Tuple4 tmp25
        cdef US3 v56
        cdef UH2 v57
        cdef numpy.ndarray[float,ndim=1] v58
        cdef numpy.ndarray[float,ndim=1] v59
        cdef Tuple6 tmp26
        cdef signed long long v60
        cdef bint v61
        cdef float v62
        cdef Mut5 v63
        cdef signed long long v65
        cdef float v66
        cdef float v67
        cdef float v68
        cdef signed long long v69
        cdef float v70
        cdef bint v71
        cdef float v75
        cdef float v76
        cdef float v72
        cdef float v73
        cdef float v74
        cdef numpy.ndarray[float,ndim=1] v77
        cdef Mut6 v78
        cdef signed long long v80
        cdef float v81
        cdef float v82
        cdef float v83
        cdef signed long long v84
        cdef signed long long v85
        cdef numpy.ndarray[float,ndim=1] v86
        cdef Mut6 v87
        cdef signed long long v89
        cdef float v90
        cdef float v91
        cdef float v92
        cdef float v93
        cdef float v94
        cdef float v95
        cdef signed long long v96
        cdef signed long long v97
        cdef float v98
        cdef float v99
        cdef float v100
        cdef float v101
        cdef unsigned long long v102
        cdef US2 v103
        cdef unsigned long long v104
        cdef object v105
        v5 = len(v4)
        v6 = numpy.empty(v5,dtype=numpy.float32)
        v7 = numpy.empty(v5,dtype=object)
        v8 = numpy.empty(v5,dtype=object)
        v9 = numpy.empty(v5,dtype=object)
        v10 = numpy.empty(v5,dtype=numpy.int64)
        v11 = numpy.empty(v5,dtype=numpy.uint8)
        v12 = len(v4)
        v13 = numpy.empty(v12,dtype=object)
        v14 = Mut0((<unsigned long long>0))
        while method0(v12, v14):
            v16 = v14.v0
            tmp24 = v4[v16]
            v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 = tmp24.v0, tmp24.v1, tmp24.v2, tmp24.v3, tmp24.v4, tmp24.v5, tmp24.v6, tmp24.v7, tmp24.v8, tmp24.v9, tmp24.v10, tmp24.v11, tmp24.v12, tmp24.v13, tmp24.v14, tmp24.v15, tmp24.v16, tmp24.v17
            del tmp24
            v35 = v33 == (<unsigned char>0)
            if v35:
                v36, v37, v38, v39 = v20, v21, v23, v24
            else:
                v36, v37, v38, v39 = v23, v24, v20, v21
            v40 = v18 + v39
            v41 = v17 + v38
            v42 = -v37
            v43 = v41 - v40
            v44 = v42 + v43
            v45 = libc.math.exp(v44)
            v6[v16] = v45
            if v35:
                v46 = v19
            else:
                v46 = v22
            del v19; del v22
            if v31:
                v51 = UH2_1()
            else:
                v48 = US3_1(v32)
                v49 = UH2_1()
                v51 = UH2_0(v48, v49)
                del v48; del v49
            v52 = len(v34)
            tmp25 = method23(v3, v52, v46)
            v53, v54, v55 = tmp25.v0, tmp25.v1, tmp25.v2
            del tmp25
            del v46
            v56 = US3_0(v28)
            v57 = UH2_0(v56, v51)
            del v51; del v56
            tmp26 = method34(v53, v52, v57)
            v58, v59 = tmp26.v0, tmp26.v1
            del tmp26
            del v53; del v57
            v7[v16] = Tuple7(v58, v59, v54, v55)
            del v55; del v58; del v59
            v60 = len(v54)
            v61 = v60 == (<signed long long>0)
            if v61:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v62 = v54[(<signed long long>0)]
            v63 = Mut5((<signed long long>1), v62)
            while method31(v60, v63):
                v65 = v63.v0
                v66 = v63.v1
                v67 = v54[v65]
                v68 = v66 + v67
                v69 = v65 + (<signed long long>1)
                v63.v0 = v69
                v63.v1 = v68
            v70 = v63.v1
            del v63
            v71 = v70 == (<float>0)
            if v71:
                v72 = <float>v60
                v73 = (<float>1) / v72
                v75, v76 = v73, (<float>0)
            else:
                v74 = (<float>1) / v70
                v75, v76 = (<float>0), v74
            v77 = numpy.empty(v60,dtype=numpy.float32)
            v78 = Mut6((<signed long long>0))
            while method32(v60, v78):
                v80 = v78.v0
                v81 = v54[v80]
                v82 = v81 * v76
                v83 = v75 + v82
                v77[v80] = v83
                v84 = v80 + (<signed long long>1)
                v78.v0 = v84
            del v54
            del v78
            v8[v16] = v77
            v85 = len(v77)
            v86 = numpy.empty(v85,dtype=numpy.float32)
            v87 = Mut6((<signed long long>0))
            while method32(v85, v87):
                v89 = v87.v0
                v90 = v77[v89]
                v91 = <float>v52
                v92 = v0 / v91
                v93 = (<float>1) - v0
                v94 = v93 * v90
                v95 = v92 + v94
                v86[v89] = v95
                v96 = v89 + (<signed long long>1)
                v87.v0 = v96
            del v87
            v9[v16] = v86
            v97 = numpy.random.choice(v52,p=v86)
            v10[v16] = v97
            v11[v16] = v33
            v98 = v77[v97]
            del v77
            v99 = v86[v97]
            del v86
            v100 = libc.math.log(v99)
            v101 = libc.math.log(v98)
            v102 = <unsigned long long>v97
            v103 = v34[v102]
            del v34
            v13[v16] = Tuple2(v101, v100, v103)
            v104 = v16 + (<unsigned long long>1)
            v14.v0 = v104
        del v14
        v105 = Closure19(v1, v2, v6, v7, v8, v9, v10, v11)
        del v6; del v7; del v8; del v9; del v10; del v11
        return Tuple1(v13, v105)
cdef class Closure17():
    def __init__(self): pass
    def __call__(self, Mut3 v0, bint v1, bint v2, float v3):
        return Closure18(v3, v2, v1, v0)
cdef class Closure20():
    def __init__(self): pass
    def __call__(self, Mut3 v0, float v1):
        method42(v1, v0)
cdef class Closure21():
    def __init__(self): pass
    def __call__(self, Mut3 v0):
        method44(v0)
cdef class Closure23():
    def __init__(self): pass
    def __call__(self, numpy.ndarray[float,ndim=1] v0):
        return v0
cdef class Closure22():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut0 v3
        cdef unsigned long long v5
        cdef float v6
        cdef float v7
        cdef UH0 v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef US1 v14
        cdef unsigned char v15
        cdef signed long v16
        cdef US1 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef bint v20
        cdef US1 v21
        cdef unsigned char v22
        cdef numpy.ndarray[signed long,ndim=1] v23
        cdef Tuple0 tmp33
        cdef unsigned long long v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef US2 v28
        cdef unsigned long long v29
        cdef object v30
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp33 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23 = tmp33.v0, tmp33.v1, tmp33.v2, tmp33.v3, tmp33.v4, tmp33.v5, tmp33.v6, tmp33.v7, tmp33.v8, tmp33.v9, tmp33.v10, tmp33.v11, tmp33.v12, tmp33.v13, tmp33.v14, tmp33.v15, tmp33.v16, tmp33.v17
            del tmp33
            del v8; del v11
            v24 = len(v23)
            v25 = <float>v24
            v26 = (<float>1) / v25
            v27 = libc.math.log(v26)
            v28 = numpy.random.choice(v23)
            del v23
            v2[v5] = Tuple2(v27, v27, v28)
            v29 = v5 + (<unsigned long long>1)
            v3.v0 = v29
        del v3
        v30 = Closure23()
        return Tuple1(v2, v30)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
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
cdef UH1 method7(US1 v0, Heap0 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US2 v9, float v10, float v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17):
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
    cdef float v71
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
    cdef float v89
    cdef signed long v91
    cdef signed long v92
    cdef numpy.ndarray[signed long,ndim=1] v93
    cdef object v94
    if v9 == 0: # call
        v18 = method8(v0)
        v19 = method8(v6)
        v20 = method8(v3)
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
            v52, v53 = v7, v5
        else:
            v49 = v47 == (<signed long>-1)
            if v49:
                v52, v53 = v4, v5
            else:
                v52, v53 = v7, (<signed long>0)
        v54 = v52 == (<unsigned char>0)
        if v54:
            v56 = v53
        else:
            v56 = -v53
        v57 = v7 == (<unsigned char>0)
        if v57:
            v59 = v56
        else:
            v59 = -v56
        v60 = v59 + v5
        v61 = v4 == (<unsigned char>0)
        if v61:
            v63 = v56
        else:
            v63 = -v56
        v64 = v63 + v5
        if v57:
            v65, v66, v67, v68, v69, v70 = v6, v7, v60, v3, v4, v64
        else:
            v65, v66, v67, v68, v69, v70 = v3, v4, v64, v6, v7, v60
        v71 = <float>v56
        return UH1_1(v10, v11, v12, v13, v14, v15, v16, v17, v65, v66, v67, v68, v69, v70, 1, v0, v71)
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
        v89 = <float>v75
        return UH1_1(v10, v11, v12, v13, v14, v15, v16, v17, v83, v84, v85, v86, v87, v88, 1, v0, v89)
    elif v9 == 2: # raise
        v91 = v2 - (<signed long>1)
        v92 = v5 + (<signed long>4)
        v93 = method6(v1, v6, v7, v92, v3, v4, v5, v91)
        v94 = Closure5(v4, v0, v1, v91, v6, v7, v92, v3, v5, v15, v16, v17, v12, v13, v14, v10, v11)
        return UH1_0(v10, v11, v12, v13, v14, v15, v16, v17, v3, v4, v5, v6, v7, v92, 1, v0, v4, v93, v94)
cdef UH1 method5(US1 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US2 v8, float v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef object v19
    cdef object v21
    cdef signed long v23
    cdef signed long v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef object v26
    if v8 == 0: # call
        v17 = (<signed long>2)
        v18 = method6(v1, v5, v6, v7, v2, v3, v4, v17)
        v19 = Closure5(v3, v0, v1, v17, v5, v6, v7, v2, v4, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v11, v12, v13, v14, v15, v16, v2, v3, v4, v5, v6, v7, 1, v0, v3, v18, v19)
    elif v8 == 1: # fold
        raise Exception("impossible 2")
    elif v8 == 2: # raise
        v23 = (<signed long>1)
        v24 = v4 + (<signed long>4)
        v25 = method6(v1, v5, v6, v24, v2, v3, v4, v23)
        v26 = Closure5(v3, v0, v1, v23, v5, v6, v24, v2, v4, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v11, v12, v13, v14, v15, v16, v2, v3, v4, v5, v6, v24, 1, v0, v3, v25, v26)
cdef UH1 method9(US1 v0, Heap0 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US2 v9, float v10, float v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17):
    cdef bint v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef US0 v26
    cdef UH0 v27
    cdef US0 v28
    cdef UH0 v29
    cdef object v30
    cdef bint v32
    cdef signed long v34
    cdef bint v35
    cdef signed long v37
    cdef signed long v38
    cdef signed long v40
    cdef signed long v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef float v48
    cdef signed long v50
    cdef signed long v51
    cdef numpy.ndarray[signed long,ndim=1] v52
    cdef object v53
    if v9 == 0: # call
        v18 = v7 == (<unsigned char>0)
        if v18:
            v19, v20, v21, v22, v23, v24 = v6, v7, v5, v3, v4, v5
        else:
            v19, v20, v21, v22, v23, v24 = v3, v4, v5, v6, v7, v5
        v25 = v1.v2
        v26 = US0_0(v0)
        v27 = UH0_0(v26, v12)
        del v26
        v28 = US0_0(v0)
        v29 = UH0_0(v28, v15)
        del v28
        v30 = Closure4(v20, v0, v1, v22, v23, v24, v19, v21, v15, v16, v17, v12, v13, v14, v10, v11)
        return UH1_0(v10, v11, v27, v13, v14, v29, v16, v17, v19, v20, v21, v22, v23, v24, 1, v0, v20, v25, v30)
    elif v9 == 1: # fold
        v32 = v4 == (<unsigned char>0)
        if v32:
            v34 = v8
        else:
            v34 = -v8
        v35 = v7 == (<unsigned char>0)
        if v35:
            v37 = v34
        else:
            v37 = -v34
        v38 = v37 + v8
        if v32:
            v40 = v34
        else:
            v40 = -v34
        v41 = v40 + v5
        if v35:
            v42, v43, v44, v45, v46, v47 = v6, v7, v38, v3, v4, v41
        else:
            v42, v43, v44, v45, v46, v47 = v3, v4, v41, v6, v7, v38
        v48 = <float>v34
        return UH1_1(v10, v11, v12, v13, v14, v15, v16, v17, v42, v43, v44, v45, v46, v47, 0, v0, v48)
    elif v9 == 2: # raise
        v50 = v2 - (<signed long>1)
        v51 = v5 + (<signed long>2)
        v52 = method6(v1, v6, v7, v51, v3, v4, v5, v50)
        v53 = Closure6(v4, v0, v1, v50, v6, v7, v51, v3, v5, v15, v16, v17, v12, v13, v14, v10, v11)
        return UH1_0(v10, v11, v12, v13, v14, v15, v16, v17, v3, v4, v5, v6, v7, v51, 0, v0, v4, v52, v53)
cdef UH1 method4(US1 v0, Heap0 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US2 v8, float v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef numpy.ndarray[signed long,ndim=1] v24
    cdef US0 v25
    cdef UH0 v26
    cdef US0 v27
    cdef UH0 v28
    cdef object v29
    cdef bint v31
    cdef signed long v33
    cdef bint v34
    cdef signed long v36
    cdef signed long v37
    cdef signed long v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef US1 v44
    cdef unsigned char v45
    cdef signed long v46
    cdef float v47
    cdef signed long v49
    cdef signed long v50
    cdef numpy.ndarray[signed long,ndim=1] v51
    cdef object v52
    if v8 == 0: # call
        v17 = v7 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v6, v7, v5, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23 = v3, v4, v5, v6, v7, v5
        v24 = v1.v2
        v25 = US0_0(v0)
        v26 = UH0_0(v25, v11)
        del v25
        v27 = US0_0(v0)
        v28 = UH0_0(v27, v14)
        del v27
        v29 = Closure4(v19, v0, v1, v21, v22, v23, v18, v20, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v26, v12, v13, v28, v15, v16, v18, v19, v20, v21, v22, v23, 1, v0, v19, v24, v29)
    elif v8 == 1: # fold
        v31 = v4 == (<unsigned char>0)
        if v31:
            v33 = v5
        else:
            v33 = -v5
        v34 = v7 == (<unsigned char>0)
        if v34:
            v36 = v33
        else:
            v36 = -v33
        v37 = v36 + v5
        if v31:
            v39 = v33
        else:
            v39 = -v33
        v40 = v39 + v5
        if v34:
            v41, v42, v43, v44, v45, v46 = v6, v7, v37, v3, v4, v40
        else:
            v41, v42, v43, v44, v45, v46 = v3, v4, v40, v6, v7, v37
        v47 = <float>v33
        return UH1_1(v9, v10, v11, v12, v13, v14, v15, v16, v41, v42, v43, v44, v45, v46, 0, v0, v47)
    elif v8 == 2: # raise
        v49 = v2 - (<signed long>1)
        v50 = v5 + (<signed long>2)
        v51 = method6(v1, v6, v7, v50, v3, v4, v5, v49)
        v52 = Closure6(v4, v0, v1, v49, v6, v7, v50, v3, v5, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v50, 0, v0, v4, v51, v52)
cdef UH1 method2(US1 v0, US1 v1, US1 v2, Heap0 v3, US2 v4, float v5, float v6, UH0 v7, float v8, float v9, UH0 v10, float v11, float v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef object v18
    cdef object v20
    cdef signed long v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned char v25
    cdef signed long v26
    cdef numpy.ndarray[signed long,ndim=1] v27
    cdef object v28
    if v4 == 0: # call
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method3(v3, v0, v16, v15, v1, v14, v13)
        v18 = Closure3(v14, v2, v3, v13, v0, v16, v15, v1, v10, v11, v12, v7, v8, v9, v5, v6)
        return UH1_0(v5, v6, v7, v8, v9, v10, v11, v12, v1, v14, v15, v0, v16, v15, 0, v2, v14, v17, v18)
    elif v4 == 1: # fold
        raise Exception("impossible 1")
    elif v4 == 2: # raise
        v22 = (<signed long>1)
        v23 = (<unsigned char>1)
        v24 = (<signed long>1)
        v25 = (<unsigned char>0)
        v26 = (<signed long>3)
        v27 = method6(v3, v0, v25, v26, v1, v23, v24, v22)
        v28 = Closure6(v23, v2, v3, v22, v0, v25, v26, v1, v24, v10, v11, v12, v7, v8, v9, v5, v6)
        return UH1_0(v5, v6, v7, v8, v9, v10, v11, v12, v1, v23, v24, v0, v25, v26, 0, v2, v23, v27, v28)
cdef UH1 method1(float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7):
    cdef US2 v8
    cdef US2 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef US2 v11
    cdef US2 v12
    cdef US2 v13
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef US2 v15
    cdef US2 v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef US2 v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef Heap0 v20
    cdef US1 v21
    cdef US1 v22
    cdef US1 v23
    cdef US1 v24
    cdef US1 v25
    cdef US1 v26
    cdef numpy.ndarray[signed long,ndim=1] v27
    cdef US1 v28
    cdef unsigned long long v29
    cdef float v30
    cdef float v31
    cdef float v32
    cdef float v33
    cdef float v34
    cdef numpy.ndarray[signed long,ndim=1] v35
    cdef US1 v36
    cdef unsigned long long v37
    cdef float v38
    cdef float v39
    cdef float v40
    cdef float v41
    cdef float v42
    cdef numpy.ndarray[signed long,ndim=1] v43
    cdef US1 v44
    cdef unsigned long long v45
    cdef float v46
    cdef float v47
    cdef float v48
    cdef float v49
    cdef float v50
    cdef numpy.ndarray[signed long,ndim=1] v51
    cdef US0 v52
    cdef UH0 v53
    cdef US0 v54
    cdef UH0 v55
    cdef object v56
    v8 = 0
    v9 = 2
    v10 = numpy.empty(2,dtype=numpy.int32)
    v10[0] = v8; v10[1] = v9
    v11 = 1
    v12 = 0
    v13 = 2
    v14 = numpy.empty(3,dtype=numpy.int32)
    v14[0] = v11; v14[1] = v12; v14[2] = v13
    v15 = 1
    v16 = 0
    v17 = numpy.empty(2,dtype=numpy.int32)
    v17[0] = v15; v17[1] = v16
    v18 = 0
    v19 = numpy.empty(1,dtype=numpy.int32)
    v19[0] = v18
    v20 = Heap0(v19, v14, v10, v17)
    del v10; del v14; del v17; del v19
    v21 = 1
    v22 = 2
    v23 = 0
    v24 = 1
    v25 = 2
    v26 = 0
    v27 = numpy.empty(6,dtype=numpy.int32)
    v27[0] = v21; v27[1] = v22; v27[2] = v23; v27[3] = v24; v27[4] = v25; v27[5] = v26
    numpy.random.shuffle(v27)
    v28 = v27[(<unsigned long long>0)]
    v29 = len(v27)
    v30 = <float>v29
    v31 = (<float>1) / v30
    v32 = libc.math.log(v31)
    v33 = v1 + v32
    v34 = v0 + v32
    v35 = v27[1:]
    del v27
    v36 = v35[(<unsigned long long>0)]
    v37 = len(v35)
    v38 = <float>v37
    v39 = (<float>1) / v38
    v40 = libc.math.log(v39)
    v41 = v33 + v40
    v42 = v34 + v40
    v43 = v35[1:]
    del v35
    v44 = v43[(<unsigned long long>0)]
    v45 = len(v43)
    del v43
    v46 = <float>v45
    v47 = (<float>1) / v46
    v48 = libc.math.log(v47)
    v49 = v41 + v48
    v50 = v42 + v48
    v51 = v20.v2
    v52 = US0_0(v28)
    v53 = UH0_0(v52, v2)
    del v52
    v54 = US0_0(v36)
    v55 = UH0_0(v54, v5)
    del v54
    v56 = Closure2(v28, v36, v44, v20, v5, v6, v7, v2, v3, v4, v50, v49)
    del v20
    return UH1_0(v50, v49, v53, v3, v4, v55, v6, v7, v28, (<unsigned char>0), (<signed long>1), v36, (<unsigned char>1), (<signed long>1), 0, v44, (<unsigned char>0), v51, v56)
cdef object method10(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4):
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut0 v11
    cdef unsigned long long v13
    cdef UH1 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef US1 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef US1 v26
    cdef unsigned char v27
    cdef signed long v28
    cdef bint v29
    cdef US1 v30
    cdef unsigned char v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef object v33
    cdef float v34
    cdef float v35
    cdef float v37
    cdef float v38
    cdef float v40
    cdef float v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef bint v48
    cdef US1 v49
    cdef float v50
    cdef unsigned long long v51
    cdef unsigned long long v52
    cdef bint v53
    cdef object v72
    cdef numpy.ndarray[object,ndim=1] v54
    cdef object v55
    cdef Tuple1 tmp0
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef bint v59
    cdef numpy.ndarray[object,ndim=1] v60
    cdef Mut0 v61
    cdef unsigned long long v63
    cdef object v64
    cdef float v65
    cdef float v66
    cdef US2 v67
    cdef Tuple2 tmp1
    cdef UH1 v68
    cdef unsigned long long v69
    cdef object v70
    cdef object v73
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v4)
    v11 = Mut0((<unsigned long long>0))
    while method0(v10, v11):
        v13 = v11.v0
        v14 = v4[v13]
        if v14.tag == 0: # action_
            v15 = (<UH1_0>v14).v0; v16 = (<UH1_0>v14).v1; v17 = (<UH1_0>v14).v2; v18 = (<UH1_0>v14).v3; v19 = (<UH1_0>v14).v4; v20 = (<UH1_0>v14).v5; v21 = (<UH1_0>v14).v6; v22 = (<UH1_0>v14).v7; v23 = (<UH1_0>v14).v8; v24 = (<UH1_0>v14).v9; v25 = (<UH1_0>v14).v10; v26 = (<UH1_0>v14).v11; v27 = (<UH1_0>v14).v12; v28 = (<UH1_0>v14).v13; v29 = (<UH1_0>v14).v14; v30 = (<UH1_0>v14).v15; v31 = (<UH1_0>v14).v16; v32 = (<UH1_0>v14).v17; v33 = (<UH1_0>v14).v18
            v7.append(v13)
            v8.append(Tuple0(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
            del v17; del v20; del v32
            v9.append(v33)
            del v33
        elif v14.tag == 1: # terminal_
            v34 = (<UH1_1>v14).v0; v35 = (<UH1_1>v14).v1; v37 = (<UH1_1>v14).v3; v38 = (<UH1_1>v14).v4; v40 = (<UH1_1>v14).v6; v41 = (<UH1_1>v14).v7; v42 = (<UH1_1>v14).v8; v43 = (<UH1_1>v14).v9; v44 = (<UH1_1>v14).v10; v45 = (<UH1_1>v14).v11; v46 = (<UH1_1>v14).v12; v47 = (<UH1_1>v14).v13; v48 = (<UH1_1>v14).v14; v49 = (<UH1_1>v14).v15; v50 = (<UH1_1>v14).v16
            v5.append(v13)
            v6.append(v50)
        del v14
        v51 = v13 + (<unsigned long long>1)
        v11.v0 = v51
    del v11
    v52 = len(v8)
    v53 = (<unsigned long long>0) < v52
    if v53:
        tmp0 = v3(v8)
        v54, v55 = tmp0.v0, tmp0.v1
        del tmp0
        v56 = len(v9)
        v57 = len(v54)
        v58 = v56 == v57
        v59 = v58 == 0
        if v59:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v60 = numpy.empty(v56,dtype=object)
        v61 = Mut0((<unsigned long long>0))
        while method0(v56, v61):
            v63 = v61.v0
            v64 = v9[v63]
            tmp1 = v54[v63]
            v65, v66, v67 = tmp1.v0, tmp1.v1, tmp1.v2
            del tmp1
            v68 = v64(v65, v66, v67)
            del v64
            v60[v63] = v68
            del v68
            v69 = v63 + (<unsigned long long>1)
            v61.v0 = v69
        del v54
        del v61
        v70 = method10(v0, v1, v2, v3, v60)
        del v60
        v72 = v55(v70)
        del v55; del v70
    else:
        v72 = v0
    del v8; del v9
    v73 = v1(v6)
    del v6
    return v2(v7, v72, v5, v73)
cdef numpy.ndarray[float,ndim=1] method11(v0, numpy.ndarray[object,ndim=1] v1):
    cdef list v2
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef unsigned long long v7
    cdef Mut0 v8
    cdef unsigned long long v10
    cdef UH1 v11
    cdef float v12
    cdef float v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef US1 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef bint v26
    cdef US1 v27
    cdef unsigned char v28
    cdef numpy.ndarray[signed long,ndim=1] v29
    cdef object v30
    cdef float v31
    cdef float v32
    cdef float v34
    cdef float v35
    cdef float v37
    cdef float v38
    cdef US1 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef bint v45
    cdef US1 v46
    cdef float v47
    cdef unsigned long long v48
    cdef unsigned long long v49
    cdef bint v50
    cdef numpy.ndarray[float,ndim=1] v70
    cdef numpy.ndarray[object,ndim=1] v51
    cdef object v52
    cdef Tuple1 tmp2
    cdef unsigned long long v53
    cdef unsigned long long v54
    cdef bint v55
    cdef bint v56
    cdef numpy.ndarray[object,ndim=1] v57
    cdef Mut0 v58
    cdef unsigned long long v60
    cdef object v61
    cdef float v62
    cdef float v63
    cdef US2 v64
    cdef Tuple2 tmp3
    cdef UH1 v65
    cdef unsigned long long v66
    cdef numpy.ndarray[float,ndim=1] v67
    cdef numpy.ndarray[float,ndim=1] v69
    cdef numpy.ndarray[float,ndim=1] v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef bint v74
    cdef bint v75
    cdef Mut0 v76
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef float v80
    cdef unsigned long long v81
    cdef unsigned long long v82
    cdef unsigned long long v83
    cdef bint v84
    cdef bint v85
    cdef Mut0 v86
    cdef unsigned long long v88
    cdef unsigned long long v89
    cdef float v90
    cdef unsigned long long v91
    v2 = [None]*(<unsigned long long>0)
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = len(v1)
    v8 = Mut0((<unsigned long long>0))
    while method0(v7, v8):
        v10 = v8.v0
        v11 = v1[v10]
        if v11.tag == 0: # action_
            v12 = (<UH1_0>v11).v0; v13 = (<UH1_0>v11).v1; v14 = (<UH1_0>v11).v2; v15 = (<UH1_0>v11).v3; v16 = (<UH1_0>v11).v4; v17 = (<UH1_0>v11).v5; v18 = (<UH1_0>v11).v6; v19 = (<UH1_0>v11).v7; v20 = (<UH1_0>v11).v8; v21 = (<UH1_0>v11).v9; v22 = (<UH1_0>v11).v10; v23 = (<UH1_0>v11).v11; v24 = (<UH1_0>v11).v12; v25 = (<UH1_0>v11).v13; v26 = (<UH1_0>v11).v14; v27 = (<UH1_0>v11).v15; v28 = (<UH1_0>v11).v16; v29 = (<UH1_0>v11).v17; v30 = (<UH1_0>v11).v18
            v4.append(v10)
            v5.append(Tuple0(v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29))
            del v14; del v17; del v29
            v6.append(v30)
            del v30
        elif v11.tag == 1: # terminal_
            v31 = (<UH1_1>v11).v0; v32 = (<UH1_1>v11).v1; v34 = (<UH1_1>v11).v3; v35 = (<UH1_1>v11).v4; v37 = (<UH1_1>v11).v6; v38 = (<UH1_1>v11).v7; v39 = (<UH1_1>v11).v8; v40 = (<UH1_1>v11).v9; v41 = (<UH1_1>v11).v10; v42 = (<UH1_1>v11).v11; v43 = (<UH1_1>v11).v12; v44 = (<UH1_1>v11).v13; v45 = (<UH1_1>v11).v14; v46 = (<UH1_1>v11).v15; v47 = (<UH1_1>v11).v16
            v2.append(v10)
            v3.append(v47)
        del v11
        v48 = v10 + (<unsigned long long>1)
        v8.v0 = v48
    del v8
    v49 = len(v5)
    v50 = (<unsigned long long>0) < v49
    if v50:
        tmp2 = v0(v5)
        v51, v52 = tmp2.v0, tmp2.v1
        del tmp2
        v53 = len(v6)
        v54 = len(v51)
        v55 = v53 == v54
        v56 = v55 == 0
        if v56:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v57 = numpy.empty(v53,dtype=object)
        v58 = Mut0((<unsigned long long>0))
        while method0(v53, v58):
            v60 = v58.v0
            v61 = v6[v60]
            tmp3 = v51[v60]
            v62, v63, v64 = tmp3.v0, tmp3.v1, tmp3.v2
            del tmp3
            v65 = v61(v62, v63, v64)
            del v61
            v57[v60] = v65
            del v65
            v66 = v60 + (<unsigned long long>1)
            v58.v0 = v66
        del v51
        del v58
        v67 = method11(v0, v57)
        del v57
        v70 = v52(v67)
        del v52; del v67
    else:
        v69 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v70 = v69
        del v69
    del v5; del v6
    v71 = numpy.empty(v7,dtype=numpy.float32)
    v72 = len(v4)
    v73 = len(v70)
    v74 = v72 == v73
    v75 = v74 == 0
    if v75:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v76 = Mut0((<unsigned long long>0))
    while method0(v72, v76):
        v78 = v76.v0
        v79 = v4[v78]
        v80 = v70[v78]
        v71[v79] = v80
        v81 = v78 + (<unsigned long long>1)
        v76.v0 = v81
    del v4; del v70
    del v76
    v82 = len(v2)
    v83 = len(v3)
    v84 = v82 == v83
    v85 = v84 == 0
    if v85:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v86 = Mut0((<unsigned long long>0))
    while method0(v82, v86):
        v88 = v86.v0
        v89 = v2[v88]
        v90 = v3[v88]
        v71[v89] = v90
        v91 = v88 + (<unsigned long long>1)
        v86.v0 = v91
    del v2; del v3
    del v86
    return v71
cdef object method12(v0, v1, v2, v3, v4, numpy.ndarray[object,ndim=1] v5):
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef list v11
    cdef list v12
    cdef list v13
    cdef list v14
    cdef unsigned long long v15
    cdef Mut0 v16
    cdef unsigned long long v18
    cdef UH1 v19
    cdef float v20
    cdef float v21
    cdef UH0 v22
    cdef float v23
    cdef float v24
    cdef UH0 v25
    cdef float v26
    cdef float v27
    cdef US1 v28
    cdef unsigned char v29
    cdef signed long v30
    cdef US1 v31
    cdef unsigned char v32
    cdef signed long v33
    cdef bint v34
    cdef US1 v35
    cdef unsigned char v36
    cdef numpy.ndarray[signed long,ndim=1] v37
    cdef object v38
    cdef bint v39
    cdef float v40
    cdef float v41
    cdef float v43
    cdef float v44
    cdef float v46
    cdef float v47
    cdef US1 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef US1 v51
    cdef unsigned char v52
    cdef signed long v53
    cdef bint v54
    cdef US1 v55
    cdef float v56
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef bint v59
    cdef object v110
    cdef object v111
    cdef numpy.ndarray[object,ndim=1] v60
    cdef object v61
    cdef Tuple1 tmp4
    cdef numpy.ndarray[object,ndim=1] v62
    cdef object v63
    cdef Tuple1 tmp5
    cdef unsigned long long v64
    cdef unsigned long long v65
    cdef bint v66
    cdef bint v67
    cdef numpy.ndarray[object,ndim=1] v68
    cdef Mut0 v69
    cdef unsigned long long v71
    cdef object v72
    cdef float v73
    cdef float v74
    cdef US2 v75
    cdef Tuple2 tmp6
    cdef UH1 v76
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef bint v80
    cdef bint v81
    cdef numpy.ndarray[object,ndim=1] v82
    cdef Mut0 v83
    cdef unsigned long long v85
    cdef object v86
    cdef float v87
    cdef float v88
    cdef US2 v89
    cdef Tuple2 tmp7
    cdef UH1 v90
    cdef unsigned long long v91
    cdef unsigned long long v92
    cdef unsigned long long v93
    cdef unsigned long long v94
    cdef numpy.ndarray[object,ndim=1] v95
    cdef Mut0 v96
    cdef unsigned long long v98
    cdef bint v99
    cdef UH1 v103
    cdef unsigned long long v101
    cdef unsigned long long v104
    cdef object v105
    cdef object v106
    cdef object v107
    cdef object v108
    cdef object v109
    cdef object v112
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = [None]*(<unsigned long long>0)
    v12 = [None]*(<unsigned long long>0)
    v13 = [None]*(<unsigned long long>0)
    v14 = [None]*(<unsigned long long>0)
    v15 = len(v5)
    v16 = Mut0((<unsigned long long>0))
    while method0(v15, v16):
        v18 = v16.v0
        v19 = v5[v18]
        if v19.tag == 0: # action_
            v20 = (<UH1_0>v19).v0; v21 = (<UH1_0>v19).v1; v22 = (<UH1_0>v19).v2; v23 = (<UH1_0>v19).v3; v24 = (<UH1_0>v19).v4; v25 = (<UH1_0>v19).v5; v26 = (<UH1_0>v19).v6; v27 = (<UH1_0>v19).v7; v28 = (<UH1_0>v19).v8; v29 = (<UH1_0>v19).v9; v30 = (<UH1_0>v19).v10; v31 = (<UH1_0>v19).v11; v32 = (<UH1_0>v19).v12; v33 = (<UH1_0>v19).v13; v34 = (<UH1_0>v19).v14; v35 = (<UH1_0>v19).v15; v36 = (<UH1_0>v19).v16; v37 = (<UH1_0>v19).v17; v38 = (<UH1_0>v19).v18
            v39 = v36 == (<unsigned char>0)
            if v39:
                v8.append(v18)
                v10.append(Tuple0(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37))
                v12.append(v38)
            else:
                v9.append(v18)
                v11.append(Tuple0(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37))
                v13.append(v38)
            del v22; del v25; del v37; del v38
            v14.append(v36)
        elif v19.tag == 1: # terminal_
            v40 = (<UH1_1>v19).v0; v41 = (<UH1_1>v19).v1; v43 = (<UH1_1>v19).v3; v44 = (<UH1_1>v19).v4; v46 = (<UH1_1>v19).v6; v47 = (<UH1_1>v19).v7; v48 = (<UH1_1>v19).v8; v49 = (<UH1_1>v19).v9; v50 = (<UH1_1>v19).v10; v51 = (<UH1_1>v19).v11; v52 = (<UH1_1>v19).v12; v53 = (<UH1_1>v19).v13; v54 = (<UH1_1>v19).v14; v55 = (<UH1_1>v19).v15; v56 = (<UH1_1>v19).v16
            v6.append(v18)
            v7.append(v56)
        del v19
        v57 = v18 + (<unsigned long long>1)
        v16.v0 = v57
    del v16
    v58 = len(v14)
    del v14
    v59 = (<unsigned long long>0) < v58
    if v59:
        tmp4 = v4(v10)
        v60, v61 = tmp4.v0, tmp4.v1
        del tmp4
        tmp5 = v3(v11)
        v62, v63 = tmp5.v0, tmp5.v1
        del tmp5
        v64 = len(v12)
        v65 = len(v60)
        v66 = v64 == v65
        v67 = v66 == 0
        if v67:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v68 = numpy.empty(v64,dtype=object)
        v69 = Mut0((<unsigned long long>0))
        while method0(v64, v69):
            v71 = v69.v0
            v72 = v12[v71]
            tmp6 = v60[v71]
            v73, v74, v75 = tmp6.v0, tmp6.v1, tmp6.v2
            del tmp6
            v76 = v72(v73, v74, v75)
            del v72
            v68[v71] = v76
            del v76
            v77 = v71 + (<unsigned long long>1)
            v69.v0 = v77
        del v60
        del v69
        v78 = len(v13)
        v79 = len(v62)
        v80 = v78 == v79
        v81 = v80 == 0
        if v81:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v82 = numpy.empty(v78,dtype=object)
        v83 = Mut0((<unsigned long long>0))
        while method0(v78, v83):
            v85 = v83.v0
            v86 = v13[v85]
            tmp7 = v62[v85]
            v87, v88, v89 = tmp7.v0, tmp7.v1, tmp7.v2
            del tmp7
            v90 = v86(v87, v88, v89)
            del v86
            v82[v85] = v90
            del v90
            v91 = v85 + (<unsigned long long>1)
            v83.v0 = v91
        del v62
        del v83
        v92 = len(v68)
        v93 = len(v82)
        v94 = v92 + v93
        v95 = numpy.empty(v94,dtype=object)
        v96 = Mut0((<unsigned long long>0))
        while method0(v94, v96):
            v98 = v96.v0
            v99 = v98 < v92
            if v99:
                v103 = v68[v98]
            else:
                v101 = v98 - v92
                v103 = v82[v101]
            v95[v98] = v103
            del v103
            v104 = v98 + (<unsigned long long>1)
            v96.v0 = v104
        del v68; del v82
        del v96
        v105 = method12(v0, v1, v2, v3, v4, v95)
        del v95
        v106 = v105[:v65]
        v107 = v61(v106)
        del v61; del v106
        v108 = v105[v65:]
        del v105
        v109 = v63(v108)
        del v63; del v108
        v110, v111 = v107, v109
        del v107; del v109
    else:
        v110, v111 = v0, v0
    del v10; del v11; del v12; del v13
    v112 = v1(v7)
    del v7
    return v2(v8, v110, v9, v111, v6, v112)
cdef bint method14(unsigned long long v0, Mut1 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method13(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef Mut0 v12
    cdef unsigned long long v14
    cdef UH1 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef UH0 v21
    cdef float v22
    cdef float v23
    cdef US1 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef US1 v27
    cdef unsigned char v28
    cdef signed long v29
    cdef bint v30
    cdef US1 v31
    cdef unsigned char v32
    cdef numpy.ndarray[signed long,ndim=1] v33
    cdef object v34
    cdef bint v35
    cdef float v36
    cdef float v37
    cdef float v39
    cdef float v40
    cdef float v42
    cdef float v43
    cdef US1 v44
    cdef unsigned char v45
    cdef signed long v46
    cdef US1 v47
    cdef unsigned char v48
    cdef signed long v49
    cdef bint v50
    cdef US1 v51
    cdef float v52
    cdef unsigned long long v53
    cdef unsigned long long v54
    cdef bint v55
    cdef list v126
    cdef numpy.ndarray[object,ndim=1] v56
    cdef object v57
    cdef Tuple1 tmp8
    cdef numpy.ndarray[object,ndim=1] v58
    cdef object v59
    cdef Tuple1 tmp9
    cdef unsigned long long v60
    cdef unsigned long long v61
    cdef bint v62
    cdef bint v63
    cdef numpy.ndarray[object,ndim=1] v64
    cdef Mut0 v65
    cdef unsigned long long v67
    cdef object v68
    cdef float v69
    cdef float v70
    cdef US2 v71
    cdef Tuple2 tmp10
    cdef UH1 v72
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef unsigned long long v75
    cdef bint v76
    cdef bint v77
    cdef numpy.ndarray[object,ndim=1] v78
    cdef Mut0 v79
    cdef unsigned long long v81
    cdef object v82
    cdef float v83
    cdef float v84
    cdef US2 v85
    cdef Tuple2 tmp11
    cdef UH1 v86
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef unsigned long long v89
    cdef unsigned long long v90
    cdef numpy.ndarray[object,ndim=1] v91
    cdef Mut0 v92
    cdef unsigned long long v94
    cdef bint v95
    cdef UH1 v99
    cdef unsigned long long v97
    cdef unsigned long long v100
    cdef numpy.ndarray[float,ndim=1] v101
    cdef numpy.ndarray[float,ndim=1] v102
    cdef numpy.ndarray[float,ndim=1] v103
    cdef numpy.ndarray[float,ndim=1] v104
    cdef numpy.ndarray[float,ndim=1] v105
    cdef unsigned long long v106
    cdef list v107
    cdef Mut1 v108
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef unsigned char v113
    cdef bint v114
    cdef float v119
    cdef unsigned long long v120
    cdef unsigned long long v121
    cdef float v115
    cdef unsigned long long v116
    cdef float v117
    cdef unsigned long long v118
    cdef unsigned long long v122
    cdef unsigned long long v123
    cdef unsigned long long v124
    cdef numpy.ndarray[float,ndim=1] v127
    cdef unsigned long long v128
    cdef unsigned long long v129
    cdef bint v130
    cdef bint v131
    cdef Mut0 v132
    cdef unsigned long long v134
    cdef unsigned long long v135
    cdef float v136
    cdef unsigned long long v137
    cdef unsigned long long v138
    cdef unsigned long long v139
    cdef bint v140
    cdef bint v141
    cdef Mut0 v142
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef float v146
    cdef unsigned long long v147
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = len(v2)
    v12 = Mut0((<unsigned long long>0))
    while method0(v11, v12):
        v14 = v12.v0
        v15 = v2[v14]
        if v15.tag == 0: # action_
            v16 = (<UH1_0>v15).v0; v17 = (<UH1_0>v15).v1; v18 = (<UH1_0>v15).v2; v19 = (<UH1_0>v15).v3; v20 = (<UH1_0>v15).v4; v21 = (<UH1_0>v15).v5; v22 = (<UH1_0>v15).v6; v23 = (<UH1_0>v15).v7; v24 = (<UH1_0>v15).v8; v25 = (<UH1_0>v15).v9; v26 = (<UH1_0>v15).v10; v27 = (<UH1_0>v15).v11; v28 = (<UH1_0>v15).v12; v29 = (<UH1_0>v15).v13; v30 = (<UH1_0>v15).v14; v31 = (<UH1_0>v15).v15; v32 = (<UH1_0>v15).v16; v33 = (<UH1_0>v15).v17; v34 = (<UH1_0>v15).v18
            v5.append(v14)
            v35 = v32 == (<unsigned char>0)
            if v35:
                v6.append(Tuple0(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33))
                v8.append(v34)
            else:
                v7.append(Tuple0(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33))
                v9.append(v34)
            del v18; del v21; del v33; del v34
            v10.append(v32)
        elif v15.tag == 1: # terminal_
            v36 = (<UH1_1>v15).v0; v37 = (<UH1_1>v15).v1; v39 = (<UH1_1>v15).v3; v40 = (<UH1_1>v15).v4; v42 = (<UH1_1>v15).v6; v43 = (<UH1_1>v15).v7; v44 = (<UH1_1>v15).v8; v45 = (<UH1_1>v15).v9; v46 = (<UH1_1>v15).v10; v47 = (<UH1_1>v15).v11; v48 = (<UH1_1>v15).v12; v49 = (<UH1_1>v15).v13; v50 = (<UH1_1>v15).v14; v51 = (<UH1_1>v15).v15; v52 = (<UH1_1>v15).v16
            v3.append(v14)
            v4.append(v52)
        del v15
        v53 = v14 + (<unsigned long long>1)
        v12.v0 = v53
    del v12
    v54 = len(v10)
    v55 = (<unsigned long long>0) < v54
    if v55:
        tmp8 = v1(v6)
        v56, v57 = tmp8.v0, tmp8.v1
        del tmp8
        tmp9 = v0(v7)
        v58, v59 = tmp9.v0, tmp9.v1
        del tmp9
        v60 = len(v8)
        v61 = len(v56)
        v62 = v60 == v61
        v63 = v62 == 0
        if v63:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v64 = numpy.empty(v60,dtype=object)
        v65 = Mut0((<unsigned long long>0))
        while method0(v60, v65):
            v67 = v65.v0
            v68 = v8[v67]
            tmp10 = v56[v67]
            v69, v70, v71 = tmp10.v0, tmp10.v1, tmp10.v2
            del tmp10
            v72 = v68(v69, v70, v71)
            del v68
            v64[v67] = v72
            del v72
            v73 = v67 + (<unsigned long long>1)
            v65.v0 = v73
        del v56
        del v65
        v74 = len(v9)
        v75 = len(v58)
        v76 = v74 == v75
        v77 = v76 == 0
        if v77:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v78 = numpy.empty(v74,dtype=object)
        v79 = Mut0((<unsigned long long>0))
        while method0(v74, v79):
            v81 = v79.v0
            v82 = v9[v81]
            tmp11 = v58[v81]
            v83, v84, v85 = tmp11.v0, tmp11.v1, tmp11.v2
            del tmp11
            v86 = v82(v83, v84, v85)
            del v82
            v78[v81] = v86
            del v86
            v87 = v81 + (<unsigned long long>1)
            v79.v0 = v87
        del v58
        del v79
        v88 = len(v64)
        v89 = len(v78)
        v90 = v88 + v89
        v91 = numpy.empty(v90,dtype=object)
        v92 = Mut0((<unsigned long long>0))
        while method0(v90, v92):
            v94 = v92.v0
            v95 = v94 < v88
            if v95:
                v99 = v64[v94]
            else:
                v97 = v94 - v88
                v99 = v78[v97]
            v91[v94] = v99
            del v99
            v100 = v94 + (<unsigned long long>1)
            v92.v0 = v100
        del v64; del v78
        del v92
        v101 = method13(v0, v1, v91)
        del v91
        v102 = v101[:v61]
        v103 = v57(v102)
        del v57; del v102
        v104 = v101[v61:]
        del v101
        v105 = v59(v104)
        del v59; del v104
        v106 = len(v10)
        v107 = [None]*v106
        v108 = Mut1((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method14(v106, v108):
            v110 = v108.v0
            v111, v112 = v108.v1, v108.v2
            v113 = v10[v110]
            v114 = v113 == (<unsigned char>0)
            if v114:
                v115 = v103[v111]
                v116 = v111 + (<unsigned long long>1)
                v119, v120, v121 = v115, v116, v112
            else:
                v117 = v105[v112]
                v118 = v112 + (<unsigned long long>1)
                v119, v120, v121 = v117, v111, v118
            v107[v110] = v119
            v122 = v110 + (<unsigned long long>1)
            v108.v0 = v122
            v108.v1 = v120
            v108.v2 = v121
        del v103; del v105
        v123, v124 = v108.v1, v108.v2
        del v108
        v126 = v107
        del v107
    else:
        v126 = [None]*(<unsigned long long>0)
    del v6; del v7; del v8; del v9; del v10
    v127 = numpy.empty(v11,dtype=numpy.float32)
    v128 = len(v5)
    v129 = len(v126)
    v130 = v128 == v129
    v131 = v130 == 0
    if v131:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v132 = Mut0((<unsigned long long>0))
    while method0(v128, v132):
        v134 = v132.v0
        v135 = v5[v134]
        v136 = v126[v134]
        v127[v135] = v136
        v137 = v134 + (<unsigned long long>1)
        v132.v0 = v137
    del v5; del v126
    del v132
    v138 = len(v3)
    v139 = len(v4)
    v140 = v138 == v139
    v141 = v140 == 0
    if v141:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v142 = Mut0((<unsigned long long>0))
    while method0(v138, v142):
        v144 = v142.v0
        v145 = v3[v144]
        v146 = v4[v144]
        v127[v145] = v146
        v147 = v144 + (<unsigned long long>1)
        v142.v0 = v147
    del v3; del v4
    del v142
    return v127
cdef unsigned long long method15(UH0 v0, unsigned long long v1) except *:
    cdef UH0 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH0_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method15(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method16(UH2 v0, unsigned long long v1) except *:
    cdef UH2 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH2_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method16(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method17(numpy.ndarray[float,ndim=3] v0, numpy.ndarray[float,ndim=3] v1, unsigned long long v2, UH0 v3, unsigned long long v4) except *:
    cdef US0 v5
    cdef UH0 v6
    cdef unsigned long long v7
    cdef numpy.ndarray[float,ndim=1] v8
    cdef US1 v9
    cdef US2 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef US1 v12
    cdef US2 v13
    if v3.tag == 0: # cons_
        v5 = (<UH0_0>v3).v0; v6 = (<UH0_0>v3).v1
        v7 = method17(v0, v1, v2, v6, v4)
        del v6
        v8 = v0[v2,v7,:]
        if v5.tag == 0: # c1of2_
            v9 = (<US0_0>v5).v0
            if v9 == 0: # jack
                v8[(<signed short>0)] = (<float>1)
            elif v9 == 1: # king
                v8[(<signed short>1)] = (<float>1)
            elif v9 == 2: # queen
                v8[(<signed short>2)] = (<float>1)
        elif v5.tag == 1: # c2of2_
            v10 = (<US0_1>v5).v0
            if v10 == 0: # call
                v8[(<signed short>3)] = (<float>1)
            elif v10 == 1: # fold
                v8[(<signed short>4)] = (<float>1)
            elif v10 == 2: # raise
                v8[(<signed short>5)] = (<float>1)
        del v8
        v11 = v1[v2,v7,:]
        if v5.tag == 0: # c1of2_
            v12 = (<US0_0>v5).v0
            if v12 == 0: # jack
                v11[(<signed short>0)] = (<float>1)
            elif v12 == 1: # king
                v11[(<signed short>1)] = (<float>1)
            elif v12 == 2: # queen
                v11[(<signed short>2)] = (<float>1)
        elif v5.tag == 1: # c2of2_
            v13 = (<US0_1>v5).v0
            if v13 == 0: # call
                v11[(<signed short>3)] = (<float>1)
            elif v13 == 1: # fold
                v11[(<signed short>4)] = (<float>1)
            elif v13 == 2: # raise
                v11[(<signed short>5)] = (<float>1)
        del v5; del v11
        return v7 + (<unsigned long long>1)
    elif v3.tag == 1: # nil
        return v4
cdef void method18(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method18(v0, v1, v2, v5)
    else:
        pass
cdef unsigned long long method19(numpy.ndarray[float,ndim=3] v0, unsigned long long v1, UH2 v2, unsigned long long v3) except *:
    cdef US3 v4
    cdef UH2 v5
    cdef numpy.ndarray[float,ndim=1] v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned long long v9
    if v2.tag == 0: # cons_
        v4 = (<UH2_0>v2).v0; v5 = (<UH2_0>v2).v1
        v6 = v0[v1,v3,:]
        if v4.tag == 0: # c1of2_
            v7 = (<US3_0>v4).v0
            if v7 == 0: # jack
                v6[(<signed short>6)] = (<float>1)
            elif v7 == 1: # king
                v6[(<signed short>7)] = (<float>1)
            elif v7 == 2: # queen
                v6[(<signed short>8)] = (<float>1)
        elif v4.tag == 1: # c2of2_
            v8 = (<US3_1>v4).v0
            if v8 == 0: # jack
                v6[(<signed short>9)] = (<float>1)
            elif v8 == 1: # king
                v6[(<signed short>10)] = (<float>1)
            elif v8 == 2: # queen
                v6[(<signed short>11)] = (<float>1)
        del v4; del v6
        v9 = v3 + (<unsigned long long>1)
        return method19(v0, v1, v5, v9)
    elif v2.tag == 1: # nil
        return v3
cdef void method20(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method20(v0, v1, v2, v5)
    else:
        pass
cdef bint method21(signed short v0, Mut2 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method24(UH0 v0) except *:
    cdef US0 v1
    cdef UH0 v2
    cdef unsigned long long v35
    cdef US1 v3
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
    cdef US2 v19
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
        if v1.tag == 0: # c1of2_
            v3 = (<US0_0>v1).v0
            if v3 == 0: # jack
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # king
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # queen
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # c2of2_
            v19 = (<US0_1>v1).v0
            if v19 == 0: # call
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # fold
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # raise
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
        v37 = method24(v2)
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
cdef bint method26(UH0 v0, UH0 v1) except *:
    cdef US0 v2
    cdef UH0 v3
    cdef US0 v4
    cdef UH0 v5
    cdef bint v12
    cdef US1 v6
    cdef US1 v7
    cdef US2 v9
    cdef US2 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # c1of2_
            v6 = (<US0_0>v2).v0; v7 = (<US0_0>v4).v0
            if v6 == 0 and v7 == 0: # jack
                v12 = 1
            elif v6 == 1 and v7 == 1: # king
                v12 = 1
            elif v6 == 2 and v7 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # c2of2_
            v9 = (<US0_1>v2).v0; v10 = (<US0_1>v4).v0
            if v9 == 0 and v10 == 0: # call
                v12 = 1
            elif v9 == 1 and v10 == 1: # fold
                v12 = 1
            elif v9 == 2 and v10 == 2: # raise
                v12 = 1
            else:
                v12 = 0
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method26(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef Mut4 method27(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut4 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut0((<unsigned long long>0))
    while method0(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut4(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method30(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut4 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple3 tmp18
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp18 = v3[v4]
        v7, v8, v9, v10, v11 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4
        del tmp18
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple3(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method30(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method29(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
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
        method30(v8, v2, v3, v7, v9)
        del v7
        method29(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method28(Mut3 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut0 v8
    cdef unsigned long long v10
    cdef list v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
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
    v8 = Mut0((<unsigned long long>0))
    while method0(v5, v8):
        v10 = v8.v0
        v11 = [None]*(<unsigned long long>0)
        v7[v10] = v11
        del v11
        v12 = v10 + (<unsigned long long>1)
        v8.v0 = v12
    del v8
    v13 = (<unsigned long long>0)
    method29(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple4 method25(Mut3 v0, UH0 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut4 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef numpy.ndarray[float,ndim=1] v12
    cdef Tuple3 tmp17
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v16
    cdef numpy.ndarray[float,ndim=1] v23
    cdef numpy.ndarray[float,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef Mut4 v27
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
        tmp17 = v4[v5]
        v8, v9, v10, v11, v12 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3, tmp17.v4
        del tmp17
        v13 = v3 == v8
        if v13:
            v15 = method26(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple4(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method25(v0, v1, v2, v3, v4, v16)
    else:
        v23 = numpy.zeros(v2,dtype=numpy.float32)
        v24 = numpy.zeros(v2,dtype=numpy.float32)
        v25 = (<unsigned long long>3)
        v26 = (<unsigned long long>7)
        v27 = method27(v25, v26)
        v4.append(Tuple3(v3, v1, v27, v23, v24))
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
            method28(v0)
        else:
            pass
        return Tuple4(v27, v23, v24)
cdef Tuple4 method23(Mut3 v0, unsigned long long v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method24(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method25(v0, v2, v1, v4, v8, v9)
cdef bint method31(signed long long v0, Mut5 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method32(signed long long v0, Mut6 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method35(UH2 v0) except *:
    cdef US3 v1
    cdef UH2 v2
    cdef unsigned long long v35
    cdef US1 v3
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
        v1 = (<UH2_0>v0).v0; v2 = (<UH2_0>v0).v1
        if v1.tag == 0: # c1of2_
            v3 = (<US3_0>v1).v0
            if v3 == 0: # jack
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # king
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # queen
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # c2of2_
            v19 = (<US3_1>v1).v0
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
        v37 = method35(v2)
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
cdef bint method37(UH2 v0, UH2 v1) except *:
    cdef US3 v2
    cdef UH2 v3
    cdef US3 v4
    cdef UH2 v5
    cdef bint v12
    cdef US1 v6
    cdef US1 v7
    cdef US1 v9
    cdef US1 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH2_0>v1).v0; v3 = (<UH2_0>v1).v1; v4 = (<UH2_0>v0).v0; v5 = (<UH2_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # c1of2_
            v6 = (<US3_0>v2).v0; v7 = (<US3_0>v4).v0
            if v6 == 0 and v7 == 0: # jack
                v12 = 1
            elif v6 == 1 and v7 == 1: # king
                v12 = 1
            elif v6 == 2 and v7 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # c2of2_
            v9 = (<US3_1>v2).v0; v10 = (<US3_1>v4).v0
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
            return method37(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method40(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH2 v8
    cdef numpy.ndarray[float,ndim=1] v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef Tuple5 tmp22
    cdef unsigned long long v11
    cdef list v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp22 = v3[v4]
        v7, v8, v9, v10 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3
        del tmp22
        v11 = v7 % v1
        v12 = v2[v11]
        v12.append(Tuple5(v7, v8, v9, v10))
        del v8; del v9; del v10; del v12
        method40(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method39(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
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
        method40(v8, v2, v3, v7, v9)
        del v7
        method39(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method38(Mut4 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut0 v8
    cdef unsigned long long v10
    cdef list v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
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
    v8 = Mut0((<unsigned long long>0))
    while method0(v5, v8):
        v10 = v8.v0
        v11 = [None]*(<unsigned long long>0)
        v7[v10] = v11
        del v11
        v12 = v10 + (<unsigned long long>1)
        v8.v0 = v12
    del v8
    v13 = (<unsigned long long>0)
    method39(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple6 method36(Mut4 v0, UH2 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH2 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple5 tmp21
    cdef bint v12
    cdef bint v14
    cdef unsigned long long v15
    cdef numpy.ndarray[float,ndim=1] v20
    cdef numpy.ndarray[float,ndim=1] v21
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
        tmp21 = v4[v5]
        v8, v9, v10, v11 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3
        del tmp21
        v12 = v3 == v8
        if v12:
            v14 = method37(v9, v1)
        else:
            v14 = 0
        del v9
        if v14:
            return Tuple6(v10, v11)
        else:
            del v10; del v11
            v15 = v5 + (<unsigned long long>1)
            return method36(v0, v1, v2, v3, v4, v15)
    else:
        v20 = numpy.zeros(v2,dtype=numpy.float32)
        v21 = numpy.zeros(v2,dtype=numpy.float32)
        v4.append(Tuple5(v3, v1, v21, v20))
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
            method38(v0)
        else:
            pass
        return Tuple6(v21, v20)
cdef Tuple6 method34(Mut4 v0, unsigned long long v1, UH2 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method35(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method36(v0, v2, v1, v4, v8, v9)
cdef void method33(Mut4 v0, Mut4 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH2 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple5 tmp20
    cdef signed long long v17
    cdef unsigned long long v18
    cdef numpy.ndarray[float,ndim=1] v19
    cdef numpy.ndarray[float,ndim=1] v20
    cdef Tuple6 tmp23
    cdef signed long long v21
    cdef Mut6 v22
    cdef signed long long v24
    cdef float v25
    cdef float v26
    cdef float v27
    cdef signed long long v28
    cdef signed long long v29
    cdef Mut6 v30
    cdef signed long long v32
    cdef float v33
    cdef float v34
    cdef float v35
    cdef signed long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp20 = v8[v12]
            v13, v14, v15, v16 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3
            del tmp20
            v17 = len(v16)
            v18 = <unsigned long long>v17
            tmp23 = method34(v0, v18, v14)
            v19, v20 = tmp23.v0, tmp23.v1
            del tmp23
            del v14
            v21 = len(v20)
            v22 = Mut6((<signed long long>0))
            while method32(v21, v22):
                v24 = v22.v0
                v25 = v20[v24]
                v26 = v16[v24]
                v27 = v25 + v26
                v20[v24] = v27
                v28 = v24 + (<signed long long>1)
                v22.v0 = v28
            del v16; del v20
            del v22
            v29 = len(v19)
            v30 = Mut6((<signed long long>0))
            while method32(v29, v30):
                v32 = v30.v0
                v33 = v19[v32]
                v34 = v15[v32]
                v35 = v33 + v34
                v19[v32] = v35
                v36 = v32 + (<signed long long>1)
                v30.v0 = v36
            del v15; del v19
            del v30
            v37 = v12 + (<unsigned long long>1)
            v10.v0 = v37
        del v8
        del v10
        v38 = v7 + (<unsigned long long>1)
        v5.v0 = v38
    del v3
cdef void method22(Mut3 v0, Mut3 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH0 v14
    cdef Mut4 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple3 tmp16
    cdef signed long long v18
    cdef unsigned long long v19
    cdef Mut4 v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef numpy.ndarray[float,ndim=1] v22
    cdef Tuple4 tmp19
    cdef bint v23
    cdef float v24
    cdef Mut5 v25
    cdef signed long long v27
    cdef float v28
    cdef float v29
    cdef float v30
    cdef signed long long v31
    cdef float v32
    cdef bint v33
    cdef float v37
    cdef float v38
    cdef float v34
    cdef float v35
    cdef float v36
    cdef numpy.ndarray[float,ndim=1] v39
    cdef Mut6 v40
    cdef signed long long v42
    cdef float v43
    cdef float v44
    cdef float v45
    cdef signed long long v46
    cdef signed long long v47
    cdef Mut6 v48
    cdef signed long long v50
    cdef float v51
    cdef float v52
    cdef float v53
    cdef signed long long v54
    cdef signed long long v55
    cdef Mut6 v56
    cdef signed long long v58
    cdef float v59
    cdef float v60
    cdef float v61
    cdef signed long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp16 = v8[v12]
            v13, v14, v15, v16, v17 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3, tmp16.v4
            del tmp16
            v18 = len(v16)
            v19 = <unsigned long long>v18
            tmp19 = method23(v0, v19, v14)
            v20, v21, v22 = tmp19.v0, tmp19.v1, tmp19.v2
            del tmp19
            del v14
            v23 = v18 == (<signed long long>0)
            if v23:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v24 = v16[(<signed long long>0)]
            v25 = Mut5((<signed long long>1), v24)
            while method31(v18, v25):
                v27 = v25.v0
                v28 = v25.v1
                v29 = v16[v27]
                v30 = v28 + v29
                v31 = v27 + (<signed long long>1)
                v25.v0 = v31
                v25.v1 = v30
            v32 = v25.v1
            del v25
            v33 = v32 == (<float>0)
            if v33:
                v34 = <float>v18
                v35 = (<float>1) / v34
                v37, v38 = v35, (<float>0)
            else:
                v36 = (<float>1) / v32
                v37, v38 = (<float>0), v36
            v39 = numpy.empty(v18,dtype=numpy.float32)
            v40 = Mut6((<signed long long>0))
            while method32(v18, v40):
                v42 = v40.v0
                v43 = v16[v42]
                v44 = v43 * v38
                v45 = v37 + v44
                v39[v42] = v45
                v46 = v42 + (<signed long long>1)
                v40.v0 = v46
            del v16
            del v40
            v47 = len(v21)
            v48 = Mut6((<signed long long>0))
            while method32(v47, v48):
                v50 = v48.v0
                v51 = v21[v50]
                v52 = v39[v50]
                v53 = v51 + v52
                v21[v50] = v53
                v54 = v50 + (<signed long long>1)
                v48.v0 = v54
            del v21; del v39
            del v48
            v55 = len(v22)
            v56 = Mut6((<signed long long>0))
            while method32(v55, v56):
                v58 = v56.v0
                v59 = v22[v58]
                v60 = v17[v58]
                v61 = v59 + v60
                v22[v58] = v61
                v62 = v58 + (<signed long long>1)
                v56.v0 = v62
            del v17; del v22
            del v56
            method33(v20, v15)
            del v15; del v20
            v63 = v12 + (<unsigned long long>1)
            v10.v0 = v63
        del v8
        del v10
        v64 = v7 + (<unsigned long long>1)
        v5.v0 = v64
    del v3
cdef Mut3 method41(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut3 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut0((<unsigned long long>0))
    while method0(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut3(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method43(float v0, Mut4 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH2 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple5 tmp31
    cdef signed long long v17
    cdef Mut6 v18
    cdef signed long long v20
    cdef float v21
    cdef float v22
    cdef signed long long v23
    cdef signed long long v24
    cdef Mut6 v25
    cdef signed long long v27
    cdef float v28
    cdef float v29
    cdef signed long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp31 = v8[v12]
            v13, v14, v15, v16 = tmp31.v0, tmp31.v1, tmp31.v2, tmp31.v3
            del tmp31
            del v14
            v17 = len(v15)
            v18 = Mut6((<signed long long>0))
            while method32(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v21 * v0
                v15[v20] = v22
                v23 = v20 + (<signed long long>1)
                v18.v0 = v23
            del v15
            del v18
            v24 = len(v16)
            v25 = Mut6((<signed long long>0))
            while method32(v24, v25):
                v27 = v25.v0
                v28 = v16[v27]
                v29 = v28 * v0
                v16[v27] = v29
                v30 = v27 + (<signed long long>1)
                v25.v0 = v30
            del v16
            del v25
            v31 = v12 + (<unsigned long long>1)
            v10.v0 = v31
        del v8
        del v10
        v32 = v7 + (<unsigned long long>1)
        v5.v0 = v32
    del v3
cdef void method42(float v0, Mut3 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH0 v14
    cdef Mut4 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple3 tmp30
    cdef unsigned long long v18
    cdef unsigned long long v19
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp30 = v8[v12]
            v13, v14, v15, v16, v17 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3, tmp30.v4
            del tmp30
            del v14; del v16; del v17
            method43(v0, v15)
            del v15
            v18 = v12 + (<unsigned long long>1)
            v10.v0 = v18
        del v8
        del v10
        v19 = v7 + (<unsigned long long>1)
        v5.v0 = v19
    del v3
cdef void method44(Mut3 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut0 v9
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef UH0 v13
    cdef Mut4 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple3 tmp32
    cdef signed long long v17
    cdef Mut6 v18
    cdef signed long long v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef bint v24
    cdef float v25
    cdef signed long long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    v2 = v0.v1
    v3 = len(v2)
    v4 = Mut0((<unsigned long long>0))
    while method0(v3, v4):
        v6 = v4.v0
        v7 = v2[v6]
        v8 = len(v7)
        v9 = Mut0((<unsigned long long>0))
        while method0(v8, v9):
            v11 = v9.v0
            tmp32 = v7[v11]
            v12, v13, v14, v15, v16 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3, tmp32.v4
            del tmp32
            del v13; del v14
            v17 = len(v15)
            v18 = Mut6((<signed long long>0))
            while method32(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v16[v20]
                v23 = v21 + v22
                v24 = (<float>0) >= v23
                if v24:
                    v25 = (<float>0)
                else:
                    v25 = v23
                v16[v20] = (<float>0)
                v15[v20] = v25
                v26 = v20 + (<signed long long>1)
                v18.v0 = v26
            del v15; del v16
            del v18
            v27 = v11 + (<unsigned long long>1)
            v9.v0 = v27
        del v7
        del v9
        v28 = v6 + (<unsigned long long>1)
        v4.v0 = v28
    del v2
cpdef object main():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef object v12
    cdef object v13
    cdef object v14
    cdef object v15
    v0 = Closure0()
    v1 = Closure7()
    v2 = collections.namedtuple("VsSelf",['cat', 'exp'])(v0, v1)
    del v0; del v1
    v3 = Closure8()
    v4 = Closure10()
    v5 = collections.namedtuple("VsOne",['cat', 'exp'])(v3, v4)
    del v3; del v4
    v6 = collections.namedtuple("Size",['action', 'policy', 'value'])((<signed short>3), (<signed short>6), (<signed short>12))
    v7 = Closure11()
    v8 = collections.namedtuple("Neural",['handler', 'size'])(v7, v6)
    del v6; del v7
    v9 = Closure15()
    v10 = Closure16()
    v11 = Closure17()
    v12 = Closure20()
    v13 = Closure21()
    v14 = collections.namedtuple("Tabular",['average', 'create_agent', 'create_policy', 'head_multiply_', 'optimize'])(v9, v10, v11, v12, v13)
    del v9; del v10; del v11; del v12; del v13
    v15 = Closure22()
    return {'neural': v8, 'tabular': v14, 'uniform_player': v15, 'vs_one': v5, 'vs_self': v2}
