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
cdef class US0_0(US0): # C1of2
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # C2of2
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # Cons
    cdef readonly US0 v0
    cdef readonly UH0 v1
    def __init__(self, US0 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # Nil
    def __init__(self): self.tag = 1
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # Action
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
    cdef readonly bint v17
    cdef readonly bint v18
    cdef readonly object v19
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, unsigned char v16, bint v17, bint v18, v19): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
cdef class UH1_1(UH1): # Terminal
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
cdef class Tuple0:
    cdef readonly bint v0
    cdef readonly bint v1
    def __init__(self, bint v0, bint v1): self.v0 = v0; self.v1 = v1
cdef class Closure5():
    cdef unsigned char v0
    cdef US1 v1
    cdef signed long v2
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
    def __init__(self, unsigned char v0, US1 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, signed long v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US2 v18):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef signed long v2 = self.v2
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
            return method7(v1, v2, v3, v4, v5, v6, v0, v7, v18, v14, v15, v23, v21, v20, v25, v9, v10)
        else:
            v27 = v17 + v10
            v28 = v16 + v9
            v29 = US0_1(v18)
            v30 = UH0_0(v29, v11)
            del v29
            v31 = US0_1(v18)
            v32 = UH0_0(v31, v8)
            del v31
            return method7(v1, v2, v3, v4, v5, v6, v0, v7, v18, v14, v15, v30, v12, v13, v32, v28, v27)
cdef class Closure4():
    cdef unsigned char v0
    cdef US1 v1
    cdef US1 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US1 v5
    cdef signed long v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef UH0 v10
    cdef float v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, US1 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, signed long v6, UH0 v7, float v8, float v9, UH0 v10, float v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US2 v17):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef US1 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
        cdef signed long v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef float v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef bint v18
        cdef float v19
        cdef float v20
        cdef US0 v21
        cdef US0 v22
        cdef UH0 v23
        cdef UH0 v24
        cdef US0 v25
        cdef US0 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef US0 v37
        cdef UH0 v38
        cdef UH0 v39
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v12
            v20 = v15 + v11
            v21 = US0_1(v17)
            v22 = US0_0(v1)
            v23 = UH0_0(v22, v10)
            del v22
            v24 = UH0_0(v21, v23)
            del v21; del v23
            v25 = US0_1(v17)
            v26 = US0_0(v1)
            v27 = UH0_0(v26, v7)
            del v26
            v28 = UH0_0(v25, v27)
            del v25; del v27
            return method6(v1, v2, v3, v4, v5, v0, v6, v17, v13, v14, v24, v20, v19, v28, v8, v9)
        else:
            v30 = v16 + v9
            v31 = v15 + v8
            v32 = US0_1(v17)
            v33 = US0_0(v1)
            v34 = UH0_0(v33, v10)
            del v33
            v35 = UH0_0(v32, v34)
            del v32; del v34
            v36 = US0_1(v17)
            v37 = US0_0(v1)
            v38 = UH0_0(v37, v7)
            del v37
            v39 = UH0_0(v36, v38)
            del v36; del v38
            return method6(v1, v2, v3, v4, v5, v0, v6, v17, v13, v14, v35, v11, v12, v39, v31, v30)
cdef class Closure6():
    cdef unsigned char v0
    cdef US1 v1
    cdef signed long v2
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
    def __init__(self, unsigned char v0, US1 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, signed long v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US2 v18):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef signed long v2 = self.v2
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
            return method9(v1, v2, v3, v4, v5, v6, v0, v7, v18, v14, v15, v23, v21, v20, v25, v9, v10)
        else:
            v27 = v17 + v10
            v28 = v16 + v9
            v29 = US0_1(v18)
            v30 = UH0_0(v29, v11)
            del v29
            v31 = US0_1(v18)
            v32 = UH0_0(v31, v8)
            del v31
            return method9(v1, v2, v3, v4, v5, v6, v0, v7, v18, v14, v15, v30, v12, v13, v32, v28, v27)
cdef class Closure3():
    cdef unsigned char v0
    cdef US1 v1
    cdef signed long v2
    cdef US1 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US1 v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef UH0 v10
    cdef float v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, US1 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, UH0 v7, float v8, float v9, UH0 v10, float v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US2 v17):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef signed long v2 = self.v2
        cdef US1 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US1 v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef float v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef bint v18
        cdef float v19
        cdef float v20
        cdef US0 v21
        cdef UH0 v22
        cdef US0 v23
        cdef UH0 v24
        cdef float v26
        cdef float v27
        cdef US0 v28
        cdef UH0 v29
        cdef US0 v30
        cdef UH0 v31
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v12
            v20 = v15 + v11
            v21 = US0_1(v17)
            v22 = UH0_0(v21, v10)
            del v21
            v23 = US0_1(v17)
            v24 = UH0_0(v23, v7)
            del v23
            return method4(v1, v2, v3, v4, v5, v6, v0, v17, v13, v14, v22, v20, v19, v24, v8, v9)
        else:
            v26 = v16 + v9
            v27 = v15 + v8
            v28 = US0_1(v17)
            v29 = UH0_0(v28, v10)
            del v28
            v30 = US0_1(v17)
            v31 = UH0_0(v30, v7)
            del v30
            return method4(v1, v2, v3, v4, v5, v6, v0, v17, v13, v14, v29, v11, v12, v31, v27, v26)
cdef class Closure2():
    cdef US1 v0
    cdef US1 v1
    cdef US1 v2
    cdef UH0 v3
    cdef float v4
    cdef float v5
    cdef UH0 v6
    cdef float v7
    cdef float v8
    cdef float v9
    cdef float v10
    def __init__(self, US1 v0, US1 v1, US1 v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8, float v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, US2 v13):
        cdef US1 v0 = self.v0
        cdef US1 v1 = self.v1
        cdef US1 v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef float v4 = self.v4
        cdef float v5 = self.v5
        cdef UH0 v6 = self.v6
        cdef float v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef float v14
        cdef float v15
        cdef US0 v16
        cdef US0 v17
        cdef UH0 v18
        cdef UH0 v19
        cdef US0 v20
        cdef US0 v21
        cdef UH0 v22
        cdef UH0 v23
        v14 = v12 + v8
        v15 = v11 + v7
        v16 = US0_1(v13)
        v17 = US0_0(v0)
        v18 = UH0_0(v17, v6)
        del v17
        v19 = UH0_0(v16, v18)
        del v16; del v18
        v20 = US0_1(v13)
        v21 = US0_0(v1)
        v22 = UH0_0(v21, v3)
        del v21
        v23 = UH0_0(v20, v22)
        del v20; del v22
        return method3(v0, v1, v2, v13, v9, v10, v19, v15, v14, v23, v4, v5)
cdef class Tuple1:
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
    cdef readonly bint v17
    cdef readonly bint v18
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, unsigned char v16, bint v17, bint v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
cdef class Tuple2:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple3:
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
cdef class US3_0(US3): # VAction
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 0; self.v0 = v0
cdef class US3_1(US3): # VCardFuture
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class US3_2(US3): # VCardOpponent
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 2; self.v0 = v0
cdef class US3_3(US3): # VCardPresent
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 3; self.v0 = v0
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # Cons
    cdef readonly US3 v0
    cdef readonly UH2 v1
    def __init__(self, US3 v0, UH2 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH2_1(UH2): # Nil
    def __init__(self): self.tag = 1
cdef class Mut2:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
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
        cdef bint v30
        cdef bint v31
        cdef Tuple1 tmp22
        cdef bint v32
        cdef UH0 v33
        cdef UH2 v38
        cdef US3 v35
        cdef UH2 v36
        cdef US3 v39
        cdef UH2 v40
        cdef UH2 v41
        cdef unsigned long long v42
        cdef unsigned long long v43
        cdef bint v44
        cdef unsigned long long v45
        cdef unsigned long long v46
        cdef unsigned long long v47
        cdef bint v48
        cdef unsigned long long v49
        cdef unsigned long long v50
        cdef unsigned long long v51
        cdef unsigned long long v52
        cdef unsigned long long v53
        cdef numpy.ndarray[float,ndim=3] v54
        cdef numpy.ndarray[signed char,ndim=2] v55
        cdef numpy.ndarray[float,ndim=3] v56
        cdef numpy.ndarray[signed char,ndim=2] v57
        cdef numpy.ndarray[float,ndim=3] v58
        cdef numpy.ndarray[signed char,ndim=2] v59
        cdef numpy.ndarray[object,ndim=1] v60
        cdef numpy.ndarray[float,ndim=1] v61
        cdef unsigned long long v62
        cdef Mut0 v63
        cdef unsigned long long v65
        cdef float v66
        cdef float v67
        cdef UH0 v68
        cdef float v69
        cdef float v70
        cdef UH0 v71
        cdef float v72
        cdef float v73
        cdef US1 v74
        cdef unsigned char v75
        cdef signed long v76
        cdef US1 v77
        cdef unsigned char v78
        cdef signed long v79
        cdef bint v80
        cdef US1 v81
        cdef unsigned char v82
        cdef bint v83
        cdef bint v84
        cdef Tuple1 tmp23
        cdef bint v85
        cdef UH0 v86
        cdef UH2 v91
        cdef US3 v88
        cdef UH2 v89
        cdef US3 v92
        cdef UH2 v93
        cdef UH2 v94
        cdef unsigned long long v95
        cdef unsigned long long v96
        cdef unsigned long long v97
        cdef unsigned long long v98
        cdef list v99
        cdef US2 v100
        cdef US2 v101
        cdef US2 v102
        cdef numpy.ndarray[signed long,ndim=1] v103
        cdef signed short v104
        cdef unsigned long long tmp24
        cdef Mut2 v105
        cdef signed short v107
        cdef US2 v108
        cdef numpy.ndarray[float,ndim=1] v109
        cdef signed short v110
        cdef float v111
        cdef unsigned long long v112
        cdef object v113
        cdef object v114
        cdef object v115
        cdef object v116
        cdef object v117
        cdef object v118
        cdef object v119
        cdef object v120
        cdef object v121
        cdef object v122
        cdef object v123
        cdef numpy.ndarray[float,ndim=2] v124
        cdef numpy.ndarray[signed long long,ndim=1] v125
        cdef object v126
        cdef numpy.ndarray[object,ndim=1] v127
        cdef Mut0 v128
        cdef unsigned long long v130
        cdef signed long long v131
        cdef bint v132
        cdef float v134
        cdef float v135
        cdef numpy.ndarray[signed long,ndim=1] v136
        cdef signed short v137
        cdef US2 v138
        cdef unsigned long long v139
        v2 = len(v1)
        v3 = v2 == (<unsigned long long>0)
        if v3:
            v4 = numpy.empty((<unsigned long long>0),dtype=object)
            v5 = Closure13()
            return Tuple2(v4, v5)
        else:
            pass # import torch
            v6 = len(v1)
            v7 = len(v1)
            v8 = Mut1((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
            while method14(v7, v8):
                v10 = v8.v0
                v11, v12 = v8.v1, v8.v2
                tmp22 = v1[v10]
                v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5, tmp22.v6, tmp22.v7, tmp22.v8, tmp22.v9, tmp22.v10, tmp22.v11, tmp22.v12, tmp22.v13, tmp22.v14, tmp22.v15, tmp22.v16, tmp22.v17, tmp22.v18
                del tmp22
                v32 = v29 == (<unsigned char>0)
                if v32:
                    v33 = v15
                else:
                    v33 = v18
                del v15; del v18
                if v27:
                    v38 = UH2_1()
                else:
                    v35 = US3_1(v28)
                    v36 = UH2_1()
                    v38 = UH2_0(v35, v36)
                    del v35; del v36
                v39 = US3_2(v24)
                v40 = UH2_0(v39, v38)
                del v38; del v39
                v41 = method15(v33, v40)
                del v40
                v42 = (<unsigned long long>0)
                v43 = method16(v33, v42)
                del v33
                v44 = v11 >= v43
                if v44:
                    v45 = v11
                else:
                    v45 = v43
                v46 = (<unsigned long long>0)
                v47 = method17(v41, v46)
                del v41
                v48 = v12 >= v47
                if v48:
                    v49 = v12
                else:
                    v49 = v47
                v50 = v10 + (<unsigned long long>1)
                v8.v0 = v50
                v8.v1 = v45
                v8.v2 = v49
            v51, v52 = v8.v1, v8.v2
            del v8
            v53 = v51 + v52
            v54 = numpy.zeros((v6,v51,(<signed short>6)),dtype=numpy.float32)
            v55 = numpy.zeros((v6,v51),dtype=numpy.int8)
            v56 = numpy.zeros((v6,v53,(<signed short>12)),dtype=numpy.float32)
            v57 = numpy.zeros((v6,v53),dtype=numpy.int8)
            v58 = numpy.zeros((v6,(<signed short>3),(<signed short>3)),dtype=numpy.float32)
            v59 = numpy.ones((v6,(<signed short>3)),dtype=numpy.int8)
            v60 = numpy.empty(v6,dtype=object)
            v61 = numpy.empty(v6,dtype=numpy.float32)
            v62 = len(v1)
            v63 = Mut0((<unsigned long long>0))
            while method0(v62, v63):
                v65 = v63.v0
                tmp23 = v1[v65]
                v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84 = tmp23.v0, tmp23.v1, tmp23.v2, tmp23.v3, tmp23.v4, tmp23.v5, tmp23.v6, tmp23.v7, tmp23.v8, tmp23.v9, tmp23.v10, tmp23.v11, tmp23.v12, tmp23.v13, tmp23.v14, tmp23.v15, tmp23.v16, tmp23.v17, tmp23.v18
                del tmp23
                v85 = v82 == (<unsigned char>0)
                if v85:
                    v86 = v68
                else:
                    v86 = v71
                del v68; del v71
                if v80:
                    v91 = UH2_1()
                else:
                    v88 = US3_1(v81)
                    v89 = UH2_1()
                    v91 = UH2_0(v88, v89)
                    del v88; del v89
                v92 = US3_2(v77)
                v93 = UH2_0(v92, v91)
                del v91; del v92
                v94 = method15(v86, v93)
                del v93
                v95 = (<unsigned long long>0)
                v96 = method18(v54, v65, v86, v95)
                del v86
                method19(v51, v55, v65, v96)
                v97 = (<unsigned long long>0)
                v98 = method20(v56, v65, v94, v97)
                del v94
                method21(v53, v57, v65, v98)
                v99 = [None]*(<signed short>0)
                if v83:
                    v100 = 1
                    v99.append(v100)
                else:
                    pass
                v101 = 0
                v99.append(v101)
                if v84:
                    v102 = 2
                    v99.append(v102)
                else:
                    pass
                v103 = numpy.array(v99,copy=False)
                del v99
                v60[v65] = v103
                tmp24 = len(v103)
                if <signed short>tmp24 != tmp24: raise Exception("The conversion to signed short failed.")
                v104 = <signed short>tmp24
                v105 = Mut2((<signed short>0))
                while method22(v104, v105):
                    v107 = v105.v0
                    v108 = v103[v107]
                    v109 = v58[v65,v107]
                    if v108 == 0: # Call
                        v109[(<signed short>0)] = (<float>1)
                    elif v108 == 1: # Fold
                        v109[(<signed short>1)] = (<float>1)
                    elif v108 == 2: # Raise
                        v109[(<signed short>2)] = (<float>1)
                    del v109
                    v59[v65,v107] = 0
                    v110 = v107 + (<signed short>1)
                    v105.v0 = v110
                del v103
                del v105
                if v85:
                    v111 = (<float>1)
                else:
                    v111 = (<float>-1)
                v61[v65] = v111
                v112 = v65 + (<unsigned long long>1)
                v63.v0 = v112
            del v63
            v113 = torch.from_numpy(v54)
            del v54
            v114 = v55.view('bool')
            del v55
            v115 = torch.from_numpy(v114)
            del v114
            v116 = torch.from_numpy(v56)
            del v56
            v117 = v57.view('bool')
            del v57
            v118 = torch.from_numpy(v117)
            del v117
            v119 = torch.from_numpy(v61)
            del v61
            v120 = torch.from_numpy(v58)
            del v58
            v121 = v59.view('bool')
            del v59
            v122 = torch.from_numpy(v121)
            del v121
            v123 = v0(v113, v115, v116, v118, v119, v120, v122)
            del v113; del v115; del v116; del v118; del v119; del v120; del v122
            v124 = v123[0]
            v125 = v123[1]
            v126 = v123[2]
            del v123
            v127 = numpy.empty(v6,dtype=object)
            v128 = Mut0((<unsigned long long>0))
            while method0(v6, v128):
                v130 = v128.v0
                v131 = v125[v130]
                v132 = v124 is None
                if v132:
                    v134 = (<float>1)
                else:
                    v134 = v124[v130,v131]
                v135 = libc.math.log(v134)
                v136 = v60[v130]
                v137 = <signed short>v131
                v138 = v136[v137]
                del v136
                v127[v130] = Tuple3(v135, v135, v138)
                v139 = v130 + (<unsigned long long>1)
                v128.v0 = v139
            del v60; del v124; del v125
            del v128
            return Tuple2(v127, v126)
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
cdef class Tuple4:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut4 v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, Mut4 v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple5:
    cdef readonly Mut4 v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, Mut4 v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut5:
    cdef public signed short v0
    cdef public float v1
    def __init__(self, signed short v0, float v1): self.v0 = v0; self.v1 = v1
cdef class Tuple6:
    cdef readonly unsigned long long v0
    cdef readonly UH2 v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, unsigned long long v0, UH2 v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple7:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure14():
    def __init__(self): pass
    def __call__(self, Mut3 v0, Mut3 v1):
        method23(v0, v1)
cdef class Closure15():
    def __init__(self): pass
    def __call__(self):
        cdef unsigned long long v0
        cdef unsigned long long v1
        v0 = (<unsigned long long>3)
        v1 = (<unsigned long long>7)
        return method41(v0, v1)
cdef class Tuple8:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure18():
    cdef bint v0
    cdef bint v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    def __init__(self, bint v0, bint v1, numpy.ndarray[float,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[signed short,ndim=1] v6, numpy.ndarray[unsigned char,ndim=1] v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
    def __call__(self, numpy.ndarray[float,ndim=1] v8):
        cdef bint v0 = self.v0
        cdef bint v1 = self.v1
        cdef numpy.ndarray[float,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[signed short,ndim=1] v6 = self.v6
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
        cdef Tuple8 tmp45
        cdef signed short v41
        cdef numpy.ndarray[float,ndim=1] v42
        cdef float v43
        cdef signed short v44
        cdef unsigned long long tmp46
        cdef signed short v45
        cdef unsigned long long tmp47
        cdef bint v46
        cdef bint v47
        cdef numpy.ndarray[float,ndim=1] v48
        cdef Mut2 v49
        cdef signed short v51
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
        cdef signed short v64
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
        cdef signed short v76
        cdef unsigned long long tmp48
        cdef signed short v77
        cdef unsigned long long tmp49
        cdef bint v78
        cdef bint v79
        cdef Mut5 v80
        cdef signed short v82
        cdef float v83
        cdef float v84
        cdef float v85
        cdef float v86
        cdef float v87
        cdef signed short v88
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
        cdef Tuple8 tmp50
        cdef signed short v105
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
        cdef Tuple8 tmp51
        cdef numpy.ndarray[float,ndim=1] v129
        cdef float v130
        cdef float v131
        cdef signed short v132
        cdef unsigned long long tmp52
        cdef Mut2 v133
        cdef signed short v135
        cdef float v136
        cdef float v137
        cdef float v138
        cdef float v139
        cdef float v140
        cdef signed short v141
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
            tmp45 = v3[v36]
            v37, v38, v39, v40 = tmp45.v0, tmp45.v1, tmp45.v2, tmp45.v3
            del tmp45
            del v39; del v40
            v41 = v6[v36]
            v42 = v5[v36]
            v43 = v13[v36]
            tmp46 = len(v38)
            if <signed short>tmp46 != tmp46: raise Exception("The conversion to signed short failed.")
            v44 = <signed short>tmp46
            tmp47 = len(v37)
            if <signed short>tmp47 != tmp47: raise Exception("The conversion to signed short failed.")
            v45 = <signed short>tmp47
            v46 = v44 == v45
            v47 = v46 == 0
            if v47:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v48 = numpy.empty(v44,dtype=numpy.float32)
            v49 = Mut2((<signed short>0))
            while method22(v44, v49):
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
                v64 = v51 + (<signed short>1)
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
            tmp48 = len(v74)
            if <signed short>tmp48 != tmp48: raise Exception("The conversion to signed short failed.")
            v76 = <signed short>tmp48
            tmp49 = len(v75)
            if <signed short>tmp49 != tmp49: raise Exception("The conversion to signed short failed.")
            v77 = <signed short>tmp49
            v78 = v76 == v77
            v79 = v78 == 0
            if v79:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v80 = Mut5((<signed short>0), (<float>0))
            while method32(v76, v80):
                v82 = v80.v0
                v83 = v80.v1
                v84 = v74[v82]
                v85 = v75[v82]
                v86 = v84 * v85
                v87 = v83 + v86
                v88 = v82 + (<signed short>1)
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
                tmp50 = v3[v100]
                v101, v102, v103, v104 = tmp50.v0, tmp50.v1, tmp50.v2, tmp50.v3
                del tmp50
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
                tmp51 = v3[v124]
                v125, v126, v127, v128 = tmp51.v0, tmp51.v1, tmp51.v2, tmp51.v3
                del tmp51
                del v125; del v126; del v127
                v129 = v33[v124]
                v130 = v70[v124]
                v131 = v2[v124]
                tmp52 = len(v128)
                if <signed short>tmp52 != tmp52: raise Exception("The conversion to signed short failed.")
                v132 = <signed short>tmp52
                v133 = Mut2((<signed short>0))
                while method22(v132, v133):
                    v135 = v133.v0
                    v136 = v128[v135]
                    v137 = v129[v135]
                    v138 = v137 - v130
                    v139 = v131 * v138
                    v140 = v136 + v139
                    v128[v135] = v140
                    v141 = v135 + (<signed short>1)
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
cdef class Closure17():
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
        cdef numpy.ndarray[signed short,ndim=1] v10
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
        cdef bint v34
        cdef bint v35
        cdef Tuple1 tmp39
        cdef bint v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef UH0 v47
        cdef UH2 v52
        cdef US3 v49
        cdef UH2 v50
        cdef US3 v53
        cdef UH2 v54
        cdef UH2 v55
        cdef list v56
        cdef US2 v57
        cdef US2 v58
        cdef US2 v59
        cdef numpy.ndarray[signed long,ndim=1] v60
        cdef signed short v61
        cdef unsigned long long tmp40
        cdef Mut4 v62
        cdef numpy.ndarray[float,ndim=1] v63
        cdef numpy.ndarray[float,ndim=1] v64
        cdef Tuple5 tmp41
        cdef numpy.ndarray[float,ndim=1] v65
        cdef numpy.ndarray[float,ndim=1] v66
        cdef Tuple7 tmp42
        cdef signed short v67
        cdef unsigned long long tmp43
        cdef bint v68
        cdef float v69
        cdef Mut5 v70
        cdef signed short v72
        cdef float v73
        cdef float v74
        cdef float v75
        cdef signed short v76
        cdef float v77
        cdef bint v78
        cdef float v82
        cdef float v83
        cdef float v79
        cdef float v80
        cdef float v81
        cdef numpy.ndarray[float,ndim=1] v84
        cdef Mut2 v85
        cdef signed short v87
        cdef float v88
        cdef float v89
        cdef float v90
        cdef signed short v91
        cdef signed short v92
        cdef unsigned long long tmp44
        cdef numpy.ndarray[float,ndim=1] v93
        cdef Mut2 v94
        cdef signed short v96
        cdef float v97
        cdef float v98
        cdef float v99
        cdef float v100
        cdef float v101
        cdef float v102
        cdef signed short v103
        cdef signed short v104
        cdef float v105
        cdef float v106
        cdef float v107
        cdef float v108
        cdef US2 v109
        cdef unsigned long long v110
        cdef object v111
        v5 = len(v4)
        v6 = numpy.empty(v5,dtype=numpy.float32)
        v7 = numpy.empty(v5,dtype=object)
        v8 = numpy.empty(v5,dtype=object)
        v9 = numpy.empty(v5,dtype=object)
        v10 = numpy.empty(v5,dtype=numpy.int16)
        v11 = numpy.empty(v5,dtype=numpy.uint8)
        v12 = len(v4)
        v13 = numpy.empty(v12,dtype=object)
        v14 = Mut0((<unsigned long long>0))
        while method0(v12, v14):
            v16 = v14.v0
            tmp39 = v4[v16]
            v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35 = tmp39.v0, tmp39.v1, tmp39.v2, tmp39.v3, tmp39.v4, tmp39.v5, tmp39.v6, tmp39.v7, tmp39.v8, tmp39.v9, tmp39.v10, tmp39.v11, tmp39.v12, tmp39.v13, tmp39.v14, tmp39.v15, tmp39.v16, tmp39.v17, tmp39.v18
            del tmp39
            v36 = v33 == (<unsigned char>0)
            if v36:
                v37, v38, v39, v40 = v20, v21, v23, v24
            else:
                v37, v38, v39, v40 = v23, v24, v20, v21
            v41 = v18 + v40
            v42 = v17 + v39
            v43 = -v38
            v44 = v42 - v41
            v45 = v43 + v44
            v46 = libc.math.exp(v45)
            v6[v16] = v46
            if v36:
                v47 = v19
            else:
                v47 = v22
            del v19; del v22
            if v31:
                v52 = UH2_1()
            else:
                v49 = US3_1(v32)
                v50 = UH2_1()
                v52 = UH2_0(v49, v50)
                del v49; del v50
            v53 = US3_2(v28)
            v54 = UH2_0(v53, v52)
            del v52; del v53
            v55 = method15(v47, v54)
            del v54
            v56 = [None]*(<signed short>0)
            if v34:
                v57 = 1
                v56.append(v57)
            else:
                pass
            v58 = 0
            v56.append(v58)
            if v35:
                v59 = 2
                v56.append(v59)
            else:
                pass
            v60 = numpy.array(v56,copy=False)
            del v56
            tmp40 = len(v60)
            if <signed short>tmp40 != tmp40: raise Exception("The conversion to signed short failed.")
            v61 = <signed short>tmp40
            tmp41 = method24(v3, v61, v47)
            v62, v63, v64 = tmp41.v0, tmp41.v1, tmp41.v2
            del tmp41
            del v47
            tmp42 = method34(v62, v61, v55)
            v65, v66 = tmp42.v0, tmp42.v1
            del tmp42
            del v55; del v62
            v7[v16] = Tuple8(v65, v66, v63, v64)
            del v64; del v65; del v66
            tmp43 = len(v63)
            if <signed short>tmp43 != tmp43: raise Exception("The conversion to signed short failed.")
            v67 = <signed short>tmp43
            v68 = v67 == (<signed short>0)
            if v68:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v69 = v63[(<signed short>0)]
            v70 = Mut5((<signed short>1), v69)
            while method32(v67, v70):
                v72 = v70.v0
                v73 = v70.v1
                v74 = v63[v72]
                v75 = v73 + v74
                v76 = v72 + (<signed short>1)
                v70.v0 = v76
                v70.v1 = v75
            v77 = v70.v1
            del v70
            v78 = v77 == (<float>0)
            if v78:
                v79 = <float>v67
                v80 = (<float>1) / v79
                v82, v83 = v80, (<float>0)
            else:
                v81 = (<float>1) / v77
                v82, v83 = (<float>0), v81
            v84 = numpy.empty(v67,dtype=numpy.float32)
            v85 = Mut2((<signed short>0))
            while method22(v67, v85):
                v87 = v85.v0
                v88 = v63[v87]
                v89 = v88 * v83
                v90 = v82 + v89
                v84[v87] = v90
                v91 = v87 + (<signed short>1)
                v85.v0 = v91
            del v63
            del v85
            v8[v16] = v84
            tmp44 = len(v84)
            if <signed short>tmp44 != tmp44: raise Exception("The conversion to signed short failed.")
            v92 = <signed short>tmp44
            v93 = numpy.empty(v92,dtype=numpy.float32)
            v94 = Mut2((<signed short>0))
            while method22(v92, v94):
                v96 = v94.v0
                v97 = v84[v96]
                v98 = <float>v61
                v99 = v0 / v98
                v100 = (<float>1) - v0
                v101 = v100 * v97
                v102 = v99 + v101
                v93[v96] = v102
                v103 = v96 + (<signed short>1)
                v94.v0 = v103
            del v94
            v9[v16] = v93
            v104 = numpy.random.choice(v61,p=v93)
            v10[v16] = v104
            v11[v16] = v33
            v105 = v84[v104]
            del v84
            v106 = v93[v104]
            del v93
            v107 = libc.math.log(v106)
            v108 = libc.math.log(v105)
            v109 = v60[v104]
            del v60
            v13[v16] = Tuple3(v108, v107, v109)
            v110 = v16 + (<unsigned long long>1)
            v14.v0 = v110
        del v14
        v111 = Closure18(v1, v2, v6, v7, v8, v9, v10, v11)
        del v6; del v7; del v8; del v9; del v10; del v11
        return Tuple2(v13, v111)
cdef class Closure16():
    def __init__(self): pass
    def __call__(self, Mut3 v0, bint v1, bint v2, float v3):
        return Closure17(v3, v2, v1, v0)
cdef class Closure19():
    def __init__(self): pass
    def __call__(self, Mut3 v0, float v1):
        method42(v1, v0)
cdef class Closure20():
    def __init__(self): pass
    def __call__(self, Mut3 v0):
        method44(v0)
cdef class Closure21():
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
        cdef bint v23
        cdef bint v24
        cdef Tuple1 tmp59
        cdef list v25
        cdef US2 v26
        cdef US2 v27
        cdef US2 v28
        cdef numpy.ndarray[signed long,ndim=1] v29
        cdef signed short v30
        cdef unsigned long long tmp60
        cdef float v31
        cdef float v32
        cdef float v33
        cdef US2 v34
        cdef unsigned long long v35
        cdef object v36
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp59 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24 = tmp59.v0, tmp59.v1, tmp59.v2, tmp59.v3, tmp59.v4, tmp59.v5, tmp59.v6, tmp59.v7, tmp59.v8, tmp59.v9, tmp59.v10, tmp59.v11, tmp59.v12, tmp59.v13, tmp59.v14, tmp59.v15, tmp59.v16, tmp59.v17, tmp59.v18
            del tmp59
            del v8; del v11
            v25 = [None]*(<signed short>0)
            if v23:
                v26 = 1
                v25.append(v26)
            else:
                pass
            v27 = 0
            v25.append(v27)
            if v24:
                v28 = 2
                v25.append(v28)
            else:
                pass
            v29 = numpy.array(v25,copy=False)
            del v25
            tmp60 = len(v29)
            if <signed short>tmp60 != tmp60: raise Exception("The conversion to signed short failed.")
            v30 = <signed short>tmp60
            v31 = <float>v30
            v32 = (<float>1) / v31
            v33 = libc.math.log(v32)
            v34 = numpy.random.choice(v29)
            del v29
            v2[v5] = Tuple3(v33, v33, v34)
            v35 = v5 + (<unsigned long long>1)
            v3.v0 = v35
        del v3
        v36 = Closure13()
        return Tuple2(v2, v36)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple0 method2(US1 v0, unsigned char v1, signed long v2, US1 v3, unsigned char v4, signed long v5):
    cdef bint v6
    v6 = (<signed long>0) < v5
    return Tuple0(0, v6)
cdef Tuple0 method5(US1 v0, unsigned char v1, signed long v2, US1 v3, unsigned char v4, signed long v5, signed long v6):
    cdef bint v7
    cdef bint v8
    cdef bint v9
    v7 = v5 == v2
    v8 = v7 != 1
    v9 = (<signed long>0) < v6
    return Tuple0(v8, v9)
cdef signed long method8(US1 v0) except *:
    if v0 == 0: # Jack
        return (<signed long>0)
    elif v0 == 1: # King
        return (<signed long>2)
    elif v0 == 2: # Queen
        return (<signed long>1)
cdef UH1 method7(US1 v0, signed long v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US2 v8, float v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
    cdef float v70
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
    cdef float v88
    cdef signed long v90
    cdef signed long v91
    cdef bint v92
    cdef bint v93
    cdef Tuple0 tmp4
    cdef object v94
    if v8 == 0: # Call
        v17 = method8(v0)
        v18 = method8(v5)
        v19 = method8(v2)
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
            v51, v52 = v6, v4
        else:
            v48 = v46 == (<signed long>-1)
            if v48:
                v51, v52 = v3, v4
            else:
                v51, v52 = v6, (<signed long>0)
        v53 = v51 == (<unsigned char>0)
        if v53:
            v55 = v52
        else:
            v55 = -v52
        v56 = v6 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v58 + v4
        v60 = v3 == (<unsigned char>0)
        if v60:
            v62 = v55
        else:
            v62 = -v55
        v63 = v62 + v4
        if v56:
            v64, v65, v66, v67, v68, v69 = v5, v6, v59, v2, v3, v63
        else:
            v64, v65, v66, v67, v68, v69 = v2, v3, v63, v5, v6, v59
        v70 = <float>v55
        return UH1_1(v9, v10, v11, v12, v13, v14, v15, v16, v64, v65, v66, v67, v68, v69, 1, v0, v70)
    elif v8 == 1: # Fold
        v72 = v3 == (<unsigned char>0)
        if v72:
            v74 = v7
        else:
            v74 = -v7
        v75 = v6 == (<unsigned char>0)
        if v75:
            v77 = v74
        else:
            v77 = -v74
        v78 = v77 + v7
        if v72:
            v80 = v74
        else:
            v80 = -v74
        v81 = v80 + v4
        if v75:
            v82, v83, v84, v85, v86, v87 = v5, v6, v78, v2, v3, v81
        else:
            v82, v83, v84, v85, v86, v87 = v2, v3, v81, v5, v6, v78
        v88 = <float>v74
        return UH1_1(v9, v10, v11, v12, v13, v14, v15, v16, v82, v83, v84, v85, v86, v87, 1, v0, v88)
    elif v8 == 2: # Raise
        v90 = v1 - (<signed long>1)
        v91 = v4 + (<signed long>4)
        tmp4 = method5(v5, v6, v91, v2, v3, v4, v90)
        v92, v93 = tmp4.v0, tmp4.v1
        del tmp4
        v94 = Closure5(v3, v0, v90, v5, v6, v91, v2, v4, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v11, v12, v13, v14, v15, v16, v2, v3, v4, v5, v6, v91, 1, v0, v3, v92, v93, v94)
cdef UH1 method6(US1 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US2 v7, float v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef signed long v16
    cdef bint v17
    cdef bint v18
    cdef Tuple0 tmp3
    cdef object v19
    cdef object v21
    cdef signed long v23
    cdef signed long v24
    cdef bint v25
    cdef bint v26
    cdef Tuple0 tmp5
    cdef object v27
    if v7 == 0: # Call
        v16 = (<signed long>2)
        tmp3 = method5(v4, v5, v6, v1, v2, v3, v16)
        v17, v18 = tmp3.v0, tmp3.v1
        del tmp3
        v19 = Closure5(v2, v0, v16, v4, v5, v6, v1, v3, v13, v14, v15, v10, v11, v12, v8, v9)
        return UH1_0(v8, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, 1, v0, v2, v17, v18, v19)
    elif v7 == 1: # Fold
        raise Exception("impossible 2")
    elif v7 == 2: # Raise
        v23 = (<signed long>1)
        v24 = v3 + (<signed long>4)
        tmp5 = method5(v4, v5, v24, v1, v2, v3, v23)
        v25, v26 = tmp5.v0, tmp5.v1
        del tmp5
        v27 = Closure5(v2, v0, v23, v4, v5, v24, v1, v3, v13, v14, v15, v10, v11, v12, v8, v9)
        return UH1_0(v8, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v24, 1, v0, v2, v25, v26, v27)
cdef UH1 method9(US1 v0, signed long v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US2 v8, float v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef signed long v24
    cdef bint v25
    cdef bint v26
    cdef Tuple0 tmp7
    cdef US0 v27
    cdef UH0 v28
    cdef US0 v29
    cdef UH0 v30
    cdef object v31
    cdef bint v33
    cdef signed long v35
    cdef bint v36
    cdef signed long v38
    cdef signed long v39
    cdef signed long v41
    cdef signed long v42
    cdef US1 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef US1 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef float v49
    cdef signed long v51
    cdef signed long v52
    cdef bint v53
    cdef bint v54
    cdef Tuple0 tmp8
    cdef object v55
    if v8 == 0: # Call
        v17 = v6 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v5, v6, v4, v2, v3, v4
        else:
            v18, v19, v20, v21, v22, v23 = v2, v3, v4, v5, v6, v4
        v24 = (<signed long>2)
        tmp7 = method5(v21, v22, v23, v18, v19, v20, v24)
        v25, v26 = tmp7.v0, tmp7.v1
        del tmp7
        v27 = US0_0(v0)
        v28 = UH0_0(v27, v11)
        del v27
        v29 = US0_0(v0)
        v30 = UH0_0(v29, v14)
        del v29
        v31 = Closure4(v19, v0, v21, v22, v23, v18, v20, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v28, v12, v13, v30, v15, v16, v18, v19, v20, v21, v22, v23, 1, v0, v19, v25, v26, v31)
    elif v8 == 1: # Fold
        v33 = v3 == (<unsigned char>0)
        if v33:
            v35 = v7
        else:
            v35 = -v7
        v36 = v6 == (<unsigned char>0)
        if v36:
            v38 = v35
        else:
            v38 = -v35
        v39 = v38 + v7
        if v33:
            v41 = v35
        else:
            v41 = -v35
        v42 = v41 + v4
        if v36:
            v43, v44, v45, v46, v47, v48 = v5, v6, v39, v2, v3, v42
        else:
            v43, v44, v45, v46, v47, v48 = v2, v3, v42, v5, v6, v39
        v49 = <float>v35
        return UH1_1(v9, v10, v11, v12, v13, v14, v15, v16, v43, v44, v45, v46, v47, v48, 0, v0, v49)
    elif v8 == 2: # Raise
        v51 = v1 - (<signed long>1)
        v52 = v4 + (<signed long>2)
        tmp8 = method5(v5, v6, v52, v2, v3, v4, v51)
        v53, v54 = tmp8.v0, tmp8.v1
        del tmp8
        v55 = Closure6(v3, v0, v51, v5, v6, v52, v2, v4, v14, v15, v16, v11, v12, v13, v9, v10)
        return UH1_0(v9, v10, v11, v12, v13, v14, v15, v16, v2, v3, v4, v5, v6, v52, 0, v0, v3, v53, v54, v55)
cdef UH1 method4(US1 v0, signed long v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, US2 v7, float v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef bint v16
    cdef US1 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef signed long v23
    cdef bint v24
    cdef bint v25
    cdef Tuple0 tmp2
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
    cdef bint v52
    cdef bint v53
    cdef Tuple0 tmp6
    cdef object v54
    if v7 == 0: # Call
        v16 = v6 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v5, v6, v4, v2, v3, v4
        else:
            v17, v18, v19, v20, v21, v22 = v2, v3, v4, v5, v6, v4
        v23 = (<signed long>2)
        tmp2 = method5(v20, v21, v22, v17, v18, v19, v23)
        v24, v25 = tmp2.v0, tmp2.v1
        del tmp2
        v26 = US0_0(v0)
        v27 = UH0_0(v26, v10)
        del v26
        v28 = US0_0(v0)
        v29 = UH0_0(v28, v13)
        del v28
        v30 = Closure4(v18, v0, v20, v21, v22, v17, v19, v13, v14, v15, v10, v11, v12, v8, v9)
        return UH1_0(v8, v9, v27, v11, v12, v29, v14, v15, v17, v18, v19, v20, v21, v22, 1, v0, v18, v24, v25, v30)
    elif v7 == 1: # Fold
        v32 = v3 == (<unsigned char>0)
        if v32:
            v34 = v4
        else:
            v34 = -v4
        v35 = v6 == (<unsigned char>0)
        if v35:
            v37 = v34
        else:
            v37 = -v34
        v38 = v37 + v4
        if v32:
            v40 = v34
        else:
            v40 = -v34
        v41 = v40 + v4
        if v35:
            v42, v43, v44, v45, v46, v47 = v5, v6, v38, v2, v3, v41
        else:
            v42, v43, v44, v45, v46, v47 = v2, v3, v41, v5, v6, v38
        v48 = <float>v34
        return UH1_1(v8, v9, v10, v11, v12, v13, v14, v15, v42, v43, v44, v45, v46, v47, 0, v0, v48)
    elif v7 == 2: # Raise
        v50 = v1 - (<signed long>1)
        v51 = v4 + (<signed long>2)
        tmp6 = method5(v5, v6, v51, v2, v3, v4, v50)
        v52, v53 = tmp6.v0, tmp6.v1
        del tmp6
        v54 = Closure6(v3, v0, v50, v5, v6, v51, v2, v4, v13, v14, v15, v10, v11, v12, v8, v9)
        return UH1_0(v8, v9, v10, v11, v12, v13, v14, v15, v2, v3, v4, v5, v6, v51, 0, v0, v3, v52, v53, v54)
cdef UH1 method3(US1 v0, US1 v1, US1 v2, US2 v3, float v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
    cdef signed long v12
    cdef unsigned char v13
    cdef signed long v14
    cdef unsigned char v15
    cdef bint v16
    cdef bint v17
    cdef Tuple0 tmp1
    cdef object v18
    cdef object v20
    cdef signed long v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned char v25
    cdef signed long v26
    cdef bint v27
    cdef bint v28
    cdef Tuple0 tmp9
    cdef object v29
    if v3 == 0: # Call
        v12 = (<signed long>2)
        v13 = (<unsigned char>1)
        v14 = (<signed long>1)
        v15 = (<unsigned char>0)
        tmp1 = method2(v0, v15, v14, v1, v13, v12)
        v16, v17 = tmp1.v0, tmp1.v1
        del tmp1
        v18 = Closure3(v13, v2, v12, v0, v15, v14, v1, v9, v10, v11, v6, v7, v8, v4, v5)
        return UH1_0(v4, v5, v6, v7, v8, v9, v10, v11, v1, v13, v14, v0, v15, v14, 0, v2, v13, v16, v17, v18)
    elif v3 == 1: # Fold
        raise Exception("impossible 1")
    elif v3 == 2: # Raise
        v22 = (<signed long>1)
        v23 = (<unsigned char>1)
        v24 = (<signed long>1)
        v25 = (<unsigned char>0)
        v26 = (<signed long>3)
        tmp9 = method5(v0, v25, v26, v1, v23, v24, v22)
        v27, v28 = tmp9.v0, tmp9.v1
        del tmp9
        v29 = Closure6(v23, v2, v22, v0, v25, v26, v1, v24, v9, v10, v11, v6, v7, v8, v4, v5)
        return UH1_0(v4, v5, v6, v7, v8, v9, v10, v11, v1, v23, v24, v0, v25, v26, 0, v2, v23, v27, v28, v29)
cdef UH1 method1(float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7):
    cdef US1 v8
    cdef US1 v9
    cdef US1 v10
    cdef US1 v11
    cdef US1 v12
    cdef US1 v13
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef US1 v15
    cdef unsigned long long v16
    cdef float v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef US1 v23
    cdef unsigned long long v24
    cdef float v25
    cdef float v26
    cdef float v27
    cdef float v28
    cdef float v29
    cdef numpy.ndarray[signed long,ndim=1] v30
    cdef US1 v31
    cdef unsigned long long v32
    cdef float v33
    cdef float v34
    cdef float v35
    cdef float v36
    cdef float v37
    cdef unsigned char v38
    cdef signed long v39
    cdef unsigned char v40
    cdef signed long v41
    cdef bint v42
    cdef bint v43
    cdef Tuple0 tmp0
    cdef US0 v44
    cdef UH0 v45
    cdef US0 v46
    cdef UH0 v47
    cdef object v48
    v8 = 1
    v9 = 2
    v10 = 0
    v11 = 1
    v12 = 2
    v13 = 0
    v14 = numpy.empty(6,dtype=numpy.int32)
    v14[0] = v8; v14[1] = v9; v14[2] = v10; v14[3] = v11; v14[4] = v12; v14[5] = v13
    numpy.random.shuffle(v14)
    v15 = v14[(<unsigned long long>0)]
    v16 = len(v14)
    v17 = <float>v16
    v18 = (<float>1) / v17
    v19 = libc.math.log(v18)
    v20 = v1 + v19
    v21 = v0 + v19
    v22 = v14[1:]
    del v14
    v23 = v22[(<unsigned long long>0)]
    v24 = len(v22)
    v25 = <float>v24
    v26 = (<float>1) / v25
    v27 = libc.math.log(v26)
    v28 = v20 + v27
    v29 = v21 + v27
    v30 = v22[1:]
    del v22
    v31 = v30[(<unsigned long long>0)]
    v32 = len(v30)
    del v30
    v33 = <float>v32
    v34 = (<float>1) / v33
    v35 = libc.math.log(v34)
    v36 = v28 + v35
    v37 = v29 + v35
    v38 = (<unsigned char>0)
    v39 = (<signed long>1)
    v40 = (<unsigned char>1)
    v41 = (<signed long>2)
    tmp0 = method2(v23, v40, v39, v15, v38, v41)
    v42, v43 = tmp0.v0, tmp0.v1
    del tmp0
    v44 = US0_0(v15)
    v45 = UH0_0(v44, v2)
    del v44
    v46 = US0_0(v23)
    v47 = UH0_0(v46, v5)
    del v46
    v48 = Closure2(v15, v23, v31, v5, v6, v7, v2, v3, v4, v37, v36)
    return UH1_0(v37, v36, v45, v3, v4, v47, v6, v7, v15, (<unsigned char>0), (<signed long>1), v23, (<unsigned char>1), (<signed long>1), 0, v31, (<unsigned char>0), v42, v43, v48)
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
    cdef bint v32
    cdef bint v33
    cdef object v34
    cdef float v35
    cdef float v36
    cdef float v38
    cdef float v39
    cdef float v41
    cdef float v42
    cdef US1 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef US1 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef bint v49
    cdef US1 v50
    cdef float v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef bint v54
    cdef object v73
    cdef numpy.ndarray[object,ndim=1] v55
    cdef object v56
    cdef Tuple2 tmp10
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef bint v59
    cdef bint v60
    cdef numpy.ndarray[object,ndim=1] v61
    cdef Mut0 v62
    cdef unsigned long long v64
    cdef object v65
    cdef float v66
    cdef float v67
    cdef US2 v68
    cdef Tuple3 tmp11
    cdef UH1 v69
    cdef unsigned long long v70
    cdef object v71
    cdef object v74
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
        if v14.tag == 0: # Action
            v15 = (<UH1_0>v14).v0; v16 = (<UH1_0>v14).v1; v17 = (<UH1_0>v14).v2; v18 = (<UH1_0>v14).v3; v19 = (<UH1_0>v14).v4; v20 = (<UH1_0>v14).v5; v21 = (<UH1_0>v14).v6; v22 = (<UH1_0>v14).v7; v23 = (<UH1_0>v14).v8; v24 = (<UH1_0>v14).v9; v25 = (<UH1_0>v14).v10; v26 = (<UH1_0>v14).v11; v27 = (<UH1_0>v14).v12; v28 = (<UH1_0>v14).v13; v29 = (<UH1_0>v14).v14; v30 = (<UH1_0>v14).v15; v31 = (<UH1_0>v14).v16; v32 = (<UH1_0>v14).v17; v33 = (<UH1_0>v14).v18; v34 = (<UH1_0>v14).v19
            v7.append(v13)
            v8.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33))
            del v17; del v20
            v9.append(v34)
            del v34
        elif v14.tag == 1: # Terminal
            v35 = (<UH1_1>v14).v0; v36 = (<UH1_1>v14).v1; v38 = (<UH1_1>v14).v3; v39 = (<UH1_1>v14).v4; v41 = (<UH1_1>v14).v6; v42 = (<UH1_1>v14).v7; v43 = (<UH1_1>v14).v8; v44 = (<UH1_1>v14).v9; v45 = (<UH1_1>v14).v10; v46 = (<UH1_1>v14).v11; v47 = (<UH1_1>v14).v12; v48 = (<UH1_1>v14).v13; v49 = (<UH1_1>v14).v14; v50 = (<UH1_1>v14).v15; v51 = (<UH1_1>v14).v16
            v5.append(v13)
            v6.append(v51)
        del v14
        v52 = v13 + (<unsigned long long>1)
        v11.v0 = v52
    del v11
    v53 = len(v8)
    v54 = (<unsigned long long>0) < v53
    if v54:
        tmp10 = v3(v8)
        v55, v56 = tmp10.v0, tmp10.v1
        del tmp10
        v57 = len(v9)
        v58 = len(v55)
        v59 = v57 == v58
        v60 = v59 == 0
        if v60:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v61 = numpy.empty(v57,dtype=object)
        v62 = Mut0((<unsigned long long>0))
        while method0(v57, v62):
            v64 = v62.v0
            v65 = v9[v64]
            tmp11 = v55[v64]
            v66, v67, v68 = tmp11.v0, tmp11.v1, tmp11.v2
            del tmp11
            v69 = v65(v66, v67, v68)
            del v65
            v61[v64] = v69
            del v69
            v70 = v64 + (<unsigned long long>1)
            v62.v0 = v70
        del v55
        del v62
        v71 = method10(v0, v1, v2, v3, v61)
        del v61
        v73 = v56(v71)
        del v56; del v71
    else:
        v73 = v0
    del v8; del v9
    v74 = v1(v6)
    del v6
    return v2(v7, v73, v5, v74)
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
    cdef bint v29
    cdef bint v30
    cdef object v31
    cdef float v32
    cdef float v33
    cdef float v35
    cdef float v36
    cdef float v38
    cdef float v39
    cdef US1 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef US1 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef bint v46
    cdef US1 v47
    cdef float v48
    cdef unsigned long long v49
    cdef unsigned long long v50
    cdef bint v51
    cdef numpy.ndarray[float,ndim=1] v71
    cdef numpy.ndarray[object,ndim=1] v52
    cdef object v53
    cdef Tuple2 tmp12
    cdef unsigned long long v54
    cdef unsigned long long v55
    cdef bint v56
    cdef bint v57
    cdef numpy.ndarray[object,ndim=1] v58
    cdef Mut0 v59
    cdef unsigned long long v61
    cdef object v62
    cdef float v63
    cdef float v64
    cdef US2 v65
    cdef Tuple3 tmp13
    cdef UH1 v66
    cdef unsigned long long v67
    cdef numpy.ndarray[float,ndim=1] v68
    cdef numpy.ndarray[float,ndim=1] v70
    cdef numpy.ndarray[float,ndim=1] v72
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef bint v75
    cdef bint v76
    cdef Mut0 v77
    cdef unsigned long long v79
    cdef unsigned long long v80
    cdef float v81
    cdef unsigned long long v82
    cdef unsigned long long v83
    cdef unsigned long long v84
    cdef bint v85
    cdef bint v86
    cdef Mut0 v87
    cdef unsigned long long v89
    cdef unsigned long long v90
    cdef float v91
    cdef unsigned long long v92
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
        if v11.tag == 0: # Action
            v12 = (<UH1_0>v11).v0; v13 = (<UH1_0>v11).v1; v14 = (<UH1_0>v11).v2; v15 = (<UH1_0>v11).v3; v16 = (<UH1_0>v11).v4; v17 = (<UH1_0>v11).v5; v18 = (<UH1_0>v11).v6; v19 = (<UH1_0>v11).v7; v20 = (<UH1_0>v11).v8; v21 = (<UH1_0>v11).v9; v22 = (<UH1_0>v11).v10; v23 = (<UH1_0>v11).v11; v24 = (<UH1_0>v11).v12; v25 = (<UH1_0>v11).v13; v26 = (<UH1_0>v11).v14; v27 = (<UH1_0>v11).v15; v28 = (<UH1_0>v11).v16; v29 = (<UH1_0>v11).v17; v30 = (<UH1_0>v11).v18; v31 = (<UH1_0>v11).v19
            v4.append(v10)
            v5.append(Tuple1(v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30))
            del v14; del v17
            v6.append(v31)
            del v31
        elif v11.tag == 1: # Terminal
            v32 = (<UH1_1>v11).v0; v33 = (<UH1_1>v11).v1; v35 = (<UH1_1>v11).v3; v36 = (<UH1_1>v11).v4; v38 = (<UH1_1>v11).v6; v39 = (<UH1_1>v11).v7; v40 = (<UH1_1>v11).v8; v41 = (<UH1_1>v11).v9; v42 = (<UH1_1>v11).v10; v43 = (<UH1_1>v11).v11; v44 = (<UH1_1>v11).v12; v45 = (<UH1_1>v11).v13; v46 = (<UH1_1>v11).v14; v47 = (<UH1_1>v11).v15; v48 = (<UH1_1>v11).v16
            v2.append(v10)
            v3.append(v48)
        del v11
        v49 = v10 + (<unsigned long long>1)
        v8.v0 = v49
    del v8
    v50 = len(v5)
    v51 = (<unsigned long long>0) < v50
    if v51:
        tmp12 = v0(v5)
        v52, v53 = tmp12.v0, tmp12.v1
        del tmp12
        v54 = len(v6)
        v55 = len(v52)
        v56 = v54 == v55
        v57 = v56 == 0
        if v57:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v58 = numpy.empty(v54,dtype=object)
        v59 = Mut0((<unsigned long long>0))
        while method0(v54, v59):
            v61 = v59.v0
            v62 = v6[v61]
            tmp13 = v52[v61]
            v63, v64, v65 = tmp13.v0, tmp13.v1, tmp13.v2
            del tmp13
            v66 = v62(v63, v64, v65)
            del v62
            v58[v61] = v66
            del v66
            v67 = v61 + (<unsigned long long>1)
            v59.v0 = v67
        del v52
        del v59
        v68 = method11(v0, v58)
        del v58
        v71 = v53(v68)
        del v53; del v68
    else:
        v70 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v71 = v70
        del v70
    del v5; del v6
    v72 = numpy.empty(v7,dtype=numpy.float32)
    v73 = len(v4)
    v74 = len(v71)
    v75 = v73 == v74
    v76 = v75 == 0
    if v76:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v77 = Mut0((<unsigned long long>0))
    while method0(v73, v77):
        v79 = v77.v0
        v80 = v4[v79]
        v81 = v71[v79]
        v72[v80] = v81
        v82 = v79 + (<unsigned long long>1)
        v77.v0 = v82
    del v4; del v71
    del v77
    v83 = len(v2)
    v84 = len(v3)
    v85 = v83 == v84
    v86 = v85 == 0
    if v86:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v87 = Mut0((<unsigned long long>0))
    while method0(v83, v87):
        v89 = v87.v0
        v90 = v2[v89]
        v91 = v3[v89]
        v72[v90] = v91
        v92 = v89 + (<unsigned long long>1)
        v87.v0 = v92
    del v2; del v3
    del v87
    return v72
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
    cdef bint v37
    cdef bint v38
    cdef object v39
    cdef bint v40
    cdef float v41
    cdef float v42
    cdef float v44
    cdef float v45
    cdef float v47
    cdef float v48
    cdef US1 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef US1 v52
    cdef unsigned char v53
    cdef signed long v54
    cdef bint v55
    cdef US1 v56
    cdef float v57
    cdef unsigned long long v58
    cdef unsigned long long v59
    cdef bint v60
    cdef object v111
    cdef object v112
    cdef numpy.ndarray[object,ndim=1] v61
    cdef object v62
    cdef Tuple2 tmp14
    cdef numpy.ndarray[object,ndim=1] v63
    cdef object v64
    cdef Tuple2 tmp15
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef bint v67
    cdef bint v68
    cdef numpy.ndarray[object,ndim=1] v69
    cdef Mut0 v70
    cdef unsigned long long v72
    cdef object v73
    cdef float v74
    cdef float v75
    cdef US2 v76
    cdef Tuple3 tmp16
    cdef UH1 v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef unsigned long long v80
    cdef bint v81
    cdef bint v82
    cdef numpy.ndarray[object,ndim=1] v83
    cdef Mut0 v84
    cdef unsigned long long v86
    cdef object v87
    cdef float v88
    cdef float v89
    cdef US2 v90
    cdef Tuple3 tmp17
    cdef UH1 v91
    cdef unsigned long long v92
    cdef unsigned long long v93
    cdef unsigned long long v94
    cdef unsigned long long v95
    cdef numpy.ndarray[object,ndim=1] v96
    cdef Mut0 v97
    cdef unsigned long long v99
    cdef bint v100
    cdef UH1 v104
    cdef unsigned long long v102
    cdef unsigned long long v105
    cdef object v106
    cdef object v107
    cdef object v108
    cdef object v109
    cdef object v110
    cdef object v113
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
        if v19.tag == 0: # Action
            v20 = (<UH1_0>v19).v0; v21 = (<UH1_0>v19).v1; v22 = (<UH1_0>v19).v2; v23 = (<UH1_0>v19).v3; v24 = (<UH1_0>v19).v4; v25 = (<UH1_0>v19).v5; v26 = (<UH1_0>v19).v6; v27 = (<UH1_0>v19).v7; v28 = (<UH1_0>v19).v8; v29 = (<UH1_0>v19).v9; v30 = (<UH1_0>v19).v10; v31 = (<UH1_0>v19).v11; v32 = (<UH1_0>v19).v12; v33 = (<UH1_0>v19).v13; v34 = (<UH1_0>v19).v14; v35 = (<UH1_0>v19).v15; v36 = (<UH1_0>v19).v16; v37 = (<UH1_0>v19).v17; v38 = (<UH1_0>v19).v18; v39 = (<UH1_0>v19).v19
            v40 = v36 == (<unsigned char>0)
            if v40:
                v8.append(v18)
                v10.append(Tuple1(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38))
                v12.append(v39)
            else:
                v9.append(v18)
                v11.append(Tuple1(v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38))
                v13.append(v39)
            del v22; del v25; del v39
            v14.append(v36)
        elif v19.tag == 1: # Terminal
            v41 = (<UH1_1>v19).v0; v42 = (<UH1_1>v19).v1; v44 = (<UH1_1>v19).v3; v45 = (<UH1_1>v19).v4; v47 = (<UH1_1>v19).v6; v48 = (<UH1_1>v19).v7; v49 = (<UH1_1>v19).v8; v50 = (<UH1_1>v19).v9; v51 = (<UH1_1>v19).v10; v52 = (<UH1_1>v19).v11; v53 = (<UH1_1>v19).v12; v54 = (<UH1_1>v19).v13; v55 = (<UH1_1>v19).v14; v56 = (<UH1_1>v19).v15; v57 = (<UH1_1>v19).v16
            v6.append(v18)
            v7.append(v57)
        del v19
        v58 = v18 + (<unsigned long long>1)
        v16.v0 = v58
    del v16
    v59 = len(v14)
    del v14
    v60 = (<unsigned long long>0) < v59
    if v60:
        tmp14 = v4(v10)
        v61, v62 = tmp14.v0, tmp14.v1
        del tmp14
        tmp15 = v3(v11)
        v63, v64 = tmp15.v0, tmp15.v1
        del tmp15
        v65 = len(v12)
        v66 = len(v61)
        v67 = v65 == v66
        v68 = v67 == 0
        if v68:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v69 = numpy.empty(v65,dtype=object)
        v70 = Mut0((<unsigned long long>0))
        while method0(v65, v70):
            v72 = v70.v0
            v73 = v12[v72]
            tmp16 = v61[v72]
            v74, v75, v76 = tmp16.v0, tmp16.v1, tmp16.v2
            del tmp16
            v77 = v73(v74, v75, v76)
            del v73
            v69[v72] = v77
            del v77
            v78 = v72 + (<unsigned long long>1)
            v70.v0 = v78
        del v61
        del v70
        v79 = len(v13)
        v80 = len(v63)
        v81 = v79 == v80
        v82 = v81 == 0
        if v82:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v83 = numpy.empty(v79,dtype=object)
        v84 = Mut0((<unsigned long long>0))
        while method0(v79, v84):
            v86 = v84.v0
            v87 = v13[v86]
            tmp17 = v63[v86]
            v88, v89, v90 = tmp17.v0, tmp17.v1, tmp17.v2
            del tmp17
            v91 = v87(v88, v89, v90)
            del v87
            v83[v86] = v91
            del v91
            v92 = v86 + (<unsigned long long>1)
            v84.v0 = v92
        del v63
        del v84
        v93 = len(v69)
        v94 = len(v83)
        v95 = v93 + v94
        v96 = numpy.empty(v95,dtype=object)
        v97 = Mut0((<unsigned long long>0))
        while method0(v95, v97):
            v99 = v97.v0
            v100 = v99 < v93
            if v100:
                v104 = v69[v99]
            else:
                v102 = v99 - v93
                v104 = v83[v102]
            v96[v99] = v104
            del v104
            v105 = v99 + (<unsigned long long>1)
            v97.v0 = v105
        del v69; del v83
        del v97
        v106 = method12(v0, v1, v2, v3, v4, v96)
        del v96
        v107 = v106[:v66]
        v108 = v62(v107)
        del v62; del v107
        v109 = v106[v66:]
        del v106
        v110 = v64(v109)
        del v64; del v109
        v111, v112 = v108, v110
        del v108; del v110
    else:
        v111, v112 = v0, v0
    del v10; del v11; del v12; del v13
    v113 = v1(v7)
    del v7
    return v2(v8, v111, v9, v112, v6, v113)
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
    cdef bint v33
    cdef bint v34
    cdef object v35
    cdef bint v36
    cdef float v37
    cdef float v38
    cdef float v40
    cdef float v41
    cdef float v43
    cdef float v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US1 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef bint v51
    cdef US1 v52
    cdef float v53
    cdef unsigned long long v54
    cdef unsigned long long v55
    cdef bint v56
    cdef list v127
    cdef numpy.ndarray[object,ndim=1] v57
    cdef object v58
    cdef Tuple2 tmp18
    cdef numpy.ndarray[object,ndim=1] v59
    cdef object v60
    cdef Tuple2 tmp19
    cdef unsigned long long v61
    cdef unsigned long long v62
    cdef bint v63
    cdef bint v64
    cdef numpy.ndarray[object,ndim=1] v65
    cdef Mut0 v66
    cdef unsigned long long v68
    cdef object v69
    cdef float v70
    cdef float v71
    cdef US2 v72
    cdef Tuple3 tmp20
    cdef UH1 v73
    cdef unsigned long long v74
    cdef unsigned long long v75
    cdef unsigned long long v76
    cdef bint v77
    cdef bint v78
    cdef numpy.ndarray[object,ndim=1] v79
    cdef Mut0 v80
    cdef unsigned long long v82
    cdef object v83
    cdef float v84
    cdef float v85
    cdef US2 v86
    cdef Tuple3 tmp21
    cdef UH1 v87
    cdef unsigned long long v88
    cdef unsigned long long v89
    cdef unsigned long long v90
    cdef unsigned long long v91
    cdef numpy.ndarray[object,ndim=1] v92
    cdef Mut0 v93
    cdef unsigned long long v95
    cdef bint v96
    cdef UH1 v100
    cdef unsigned long long v98
    cdef unsigned long long v101
    cdef numpy.ndarray[float,ndim=1] v102
    cdef numpy.ndarray[float,ndim=1] v103
    cdef numpy.ndarray[float,ndim=1] v104
    cdef numpy.ndarray[float,ndim=1] v105
    cdef numpy.ndarray[float,ndim=1] v106
    cdef unsigned long long v107
    cdef list v108
    cdef Mut1 v109
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef unsigned long long v113
    cdef unsigned char v114
    cdef bint v115
    cdef float v120
    cdef unsigned long long v121
    cdef unsigned long long v122
    cdef float v116
    cdef unsigned long long v117
    cdef float v118
    cdef unsigned long long v119
    cdef unsigned long long v123
    cdef unsigned long long v124
    cdef unsigned long long v125
    cdef numpy.ndarray[float,ndim=1] v128
    cdef unsigned long long v129
    cdef unsigned long long v130
    cdef bint v131
    cdef bint v132
    cdef Mut0 v133
    cdef unsigned long long v135
    cdef unsigned long long v136
    cdef float v137
    cdef unsigned long long v138
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef bint v141
    cdef bint v142
    cdef Mut0 v143
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef float v147
    cdef unsigned long long v148
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
        if v15.tag == 0: # Action
            v16 = (<UH1_0>v15).v0; v17 = (<UH1_0>v15).v1; v18 = (<UH1_0>v15).v2; v19 = (<UH1_0>v15).v3; v20 = (<UH1_0>v15).v4; v21 = (<UH1_0>v15).v5; v22 = (<UH1_0>v15).v6; v23 = (<UH1_0>v15).v7; v24 = (<UH1_0>v15).v8; v25 = (<UH1_0>v15).v9; v26 = (<UH1_0>v15).v10; v27 = (<UH1_0>v15).v11; v28 = (<UH1_0>v15).v12; v29 = (<UH1_0>v15).v13; v30 = (<UH1_0>v15).v14; v31 = (<UH1_0>v15).v15; v32 = (<UH1_0>v15).v16; v33 = (<UH1_0>v15).v17; v34 = (<UH1_0>v15).v18; v35 = (<UH1_0>v15).v19
            v5.append(v14)
            v36 = v32 == (<unsigned char>0)
            if v36:
                v6.append(Tuple1(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34))
                v8.append(v35)
            else:
                v7.append(Tuple1(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34))
                v9.append(v35)
            del v18; del v21; del v35
            v10.append(v32)
        elif v15.tag == 1: # Terminal
            v37 = (<UH1_1>v15).v0; v38 = (<UH1_1>v15).v1; v40 = (<UH1_1>v15).v3; v41 = (<UH1_1>v15).v4; v43 = (<UH1_1>v15).v6; v44 = (<UH1_1>v15).v7; v45 = (<UH1_1>v15).v8; v46 = (<UH1_1>v15).v9; v47 = (<UH1_1>v15).v10; v48 = (<UH1_1>v15).v11; v49 = (<UH1_1>v15).v12; v50 = (<UH1_1>v15).v13; v51 = (<UH1_1>v15).v14; v52 = (<UH1_1>v15).v15; v53 = (<UH1_1>v15).v16
            v3.append(v14)
            v4.append(v53)
        del v15
        v54 = v14 + (<unsigned long long>1)
        v12.v0 = v54
    del v12
    v55 = len(v10)
    v56 = (<unsigned long long>0) < v55
    if v56:
        tmp18 = v1(v6)
        v57, v58 = tmp18.v0, tmp18.v1
        del tmp18
        tmp19 = v0(v7)
        v59, v60 = tmp19.v0, tmp19.v1
        del tmp19
        v61 = len(v8)
        v62 = len(v57)
        v63 = v61 == v62
        v64 = v63 == 0
        if v64:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v65 = numpy.empty(v61,dtype=object)
        v66 = Mut0((<unsigned long long>0))
        while method0(v61, v66):
            v68 = v66.v0
            v69 = v8[v68]
            tmp20 = v57[v68]
            v70, v71, v72 = tmp20.v0, tmp20.v1, tmp20.v2
            del tmp20
            v73 = v69(v70, v71, v72)
            del v69
            v65[v68] = v73
            del v73
            v74 = v68 + (<unsigned long long>1)
            v66.v0 = v74
        del v57
        del v66
        v75 = len(v9)
        v76 = len(v59)
        v77 = v75 == v76
        v78 = v77 == 0
        if v78:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v79 = numpy.empty(v75,dtype=object)
        v80 = Mut0((<unsigned long long>0))
        while method0(v75, v80):
            v82 = v80.v0
            v83 = v9[v82]
            tmp21 = v59[v82]
            v84, v85, v86 = tmp21.v0, tmp21.v1, tmp21.v2
            del tmp21
            v87 = v83(v84, v85, v86)
            del v83
            v79[v82] = v87
            del v87
            v88 = v82 + (<unsigned long long>1)
            v80.v0 = v88
        del v59
        del v80
        v89 = len(v65)
        v90 = len(v79)
        v91 = v89 + v90
        v92 = numpy.empty(v91,dtype=object)
        v93 = Mut0((<unsigned long long>0))
        while method0(v91, v93):
            v95 = v93.v0
            v96 = v95 < v89
            if v96:
                v100 = v65[v95]
            else:
                v98 = v95 - v89
                v100 = v79[v98]
            v92[v95] = v100
            del v100
            v101 = v95 + (<unsigned long long>1)
            v93.v0 = v101
        del v65; del v79
        del v93
        v102 = method13(v0, v1, v92)
        del v92
        v103 = v102[:v62]
        v104 = v58(v103)
        del v58; del v103
        v105 = v102[v62:]
        del v102
        v106 = v60(v105)
        del v60; del v105
        v107 = len(v10)
        v108 = [None]*v107
        v109 = Mut1((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method14(v107, v109):
            v111 = v109.v0
            v112, v113 = v109.v1, v109.v2
            v114 = v10[v111]
            v115 = v114 == (<unsigned char>0)
            if v115:
                v116 = v104[v112]
                v117 = v112 + (<unsigned long long>1)
                v120, v121, v122 = v116, v117, v113
            else:
                v118 = v106[v113]
                v119 = v113 + (<unsigned long long>1)
                v120, v121, v122 = v118, v112, v119
            v108[v111] = v120
            v123 = v111 + (<unsigned long long>1)
            v109.v0 = v123
            v109.v1 = v121
            v109.v2 = v122
        del v104; del v106
        v124, v125 = v109.v1, v109.v2
        del v109
        v127 = v108
        del v108
    else:
        v127 = [None]*(<unsigned long long>0)
    del v6; del v7; del v8; del v9; del v10
    v128 = numpy.empty(v11,dtype=numpy.float32)
    v129 = len(v5)
    v130 = len(v127)
    v131 = v129 == v130
    v132 = v131 == 0
    if v132:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v133 = Mut0((<unsigned long long>0))
    while method0(v129, v133):
        v135 = v133.v0
        v136 = v5[v135]
        v137 = v127[v135]
        v128[v136] = v137
        v138 = v135 + (<unsigned long long>1)
        v133.v0 = v138
    del v5; del v127
    del v133
    v139 = len(v3)
    v140 = len(v4)
    v141 = v139 == v140
    v142 = v141 == 0
    if v142:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v143 = Mut0((<unsigned long long>0))
    while method0(v139, v143):
        v145 = v143.v0
        v146 = v3[v145]
        v147 = v4[v145]
        v128[v146] = v147
        v148 = v145 + (<unsigned long long>1)
        v143.v0 = v148
    del v3; del v4
    del v143
    return v128
cdef UH2 method15(UH0 v0, UH2 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH2 v4
    cdef US3 v9
    cdef US1 v5
    cdef US2 v7
    if v0.tag == 0: # Cons
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = method15(v3, v1)
        del v3
        if v2.tag == 0: # C1of2
            v5 = (<US0_0>v2).v0
            v9 = US3_3(v5)
        elif v2.tag == 1: # C2of2
            v7 = (<US0_1>v2).v0
            v9 = US3_0(v7)
        del v2
        return UH2_0(v9, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method16(UH0 v0, unsigned long long v1) except *:
    cdef UH0 v3
    cdef unsigned long long v4
    if v0.tag == 0: # Cons
        v3 = (<UH0_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method16(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method17(UH2 v0, unsigned long long v1) except *:
    cdef UH2 v3
    cdef unsigned long long v4
    if v0.tag == 0: # Cons
        v3 = (<UH2_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method17(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef unsigned long long method18(numpy.ndarray[float,ndim=3] v0, unsigned long long v1, UH0 v2, unsigned long long v3) except *:
    cdef US0 v4
    cdef UH0 v5
    cdef numpy.ndarray[float,ndim=1] v6
    cdef US1 v7
    cdef US2 v8
    cdef unsigned long long v9
    if v2.tag == 0: # Cons
        v4 = (<UH0_0>v2).v0; v5 = (<UH0_0>v2).v1
        v6 = v0[v1,v3]
        if v4.tag == 0: # C1of2
            v7 = (<US0_0>v4).v0
            if v7 == 0: # Jack
                v6[(<signed short>0)] = (<float>1)
            elif v7 == 1: # King
                v6[(<signed short>1)] = (<float>1)
            elif v7 == 2: # Queen
                v6[(<signed short>2)] = (<float>1)
        elif v4.tag == 1: # C2of2
            v8 = (<US0_1>v4).v0
            if v8 == 0: # Call
                v6[(<signed short>3)] = (<float>1)
            elif v8 == 1: # Fold
                v6[(<signed short>4)] = (<float>1)
            elif v8 == 2: # Raise
                v6[(<signed short>5)] = (<float>1)
        del v4; del v6
        v9 = v3 + (<unsigned long long>1)
        return method18(v0, v1, v5, v9)
    elif v2.tag == 1: # Nil
        return v3
cdef void method19(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method19(v0, v1, v2, v5)
    else:
        pass
cdef unsigned long long method20(numpy.ndarray[float,ndim=3] v0, unsigned long long v1, UH2 v2, unsigned long long v3) except *:
    cdef US3 v4
    cdef UH2 v5
    cdef numpy.ndarray[float,ndim=1] v6
    cdef US2 v7
    cdef US1 v8
    cdef US1 v9
    cdef US1 v10
    cdef unsigned long long v11
    if v2.tag == 0: # Cons
        v4 = (<UH2_0>v2).v0; v5 = (<UH2_0>v2).v1
        v6 = v0[v1,v3]
        if v4.tag == 0: # VAction
            v7 = (<US3_0>v4).v0
            if v7 == 0: # Call
                v6[(<signed short>0)] = (<float>1)
            elif v7 == 1: # Fold
                v6[(<signed short>1)] = (<float>1)
            elif v7 == 2: # Raise
                v6[(<signed short>2)] = (<float>1)
        elif v4.tag == 1: # VCardFuture
            v8 = (<US3_1>v4).v0
            if v8 == 0: # Jack
                v6[(<signed short>3)] = (<float>1)
            elif v8 == 1: # King
                v6[(<signed short>4)] = (<float>1)
            elif v8 == 2: # Queen
                v6[(<signed short>5)] = (<float>1)
        elif v4.tag == 2: # VCardOpponent
            v9 = (<US3_2>v4).v0
            if v9 == 0: # Jack
                v6[(<signed short>6)] = (<float>1)
            elif v9 == 1: # King
                v6[(<signed short>7)] = (<float>1)
            elif v9 == 2: # Queen
                v6[(<signed short>8)] = (<float>1)
        elif v4.tag == 3: # VCardPresent
            v10 = (<US3_3>v4).v0
            if v10 == 0: # Jack
                v6[(<signed short>9)] = (<float>1)
            elif v10 == 1: # King
                v6[(<signed short>10)] = (<float>1)
            elif v10 == 2: # Queen
                v6[(<signed short>11)] = (<float>1)
        del v4; del v6
        v11 = v3 + (<unsigned long long>1)
        return method20(v0, v1, v5, v11)
    elif v2.tag == 1: # Nil
        return v3
cdef void method21(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method21(v0, v1, v2, v5)
    else:
        pass
cdef bint method22(signed short v0, Mut2 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method25(UH0 v0) except *:
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
    if v0.tag == 0: # Cons
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # C1of2
            v3 = (<US0_0>v1).v0
            if v3 == 0: # Jack
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # King
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # Queen
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # C2of2
            v19 = (<US0_1>v1).v0
            if v19 == 0: # Call
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # Fold
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # Raise
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
        v37 = method25(v2)
        del v2
        v38 = v36 + v37
        v39 = (<unsigned long long>9223372036854775807) + v38
        v40 = v39 * (<unsigned long long>9973)
        v41 = (<signed long>0)
        v42 = (<unsigned long long>1) + v41
        return v40 * v42
    elif v0.tag == 1: # Nil
        v44 = (<signed long>1)
        v45 = (<unsigned long long>1) + v44
        return (<unsigned long long>9223372036854765835) * v45
cdef bint method27(UH0 v0, UH0 v1) except *:
    cdef US0 v2
    cdef UH0 v3
    cdef US0 v4
    cdef UH0 v5
    cdef bint v12
    cdef US1 v6
    cdef US1 v7
    cdef US2 v9
    cdef US2 v10
    if v1.tag == 0 and v0.tag == 0: # Cons
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # C1of2
            v6 = (<US0_0>v2).v0; v7 = (<US0_0>v4).v0
            if v6 == 0 and v7 == 0: # Jack
                v12 = 1
            elif v6 == 1 and v7 == 1: # King
                v12 = 1
            elif v6 == 2 and v7 == 2: # Queen
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # C2of2
            v9 = (<US0_1>v2).v0; v10 = (<US0_1>v4).v0
            if v9 == 0 and v10 == 0: # Call
                v12 = 1
            elif v9 == 1 and v10 == 1: # Fold
                v12 = 1
            elif v9 == 2 and v10 == 2: # Raise
                v12 = 1
            else:
                v12 = 0
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method27(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # Nil
        return 1
    else:
        return 0
cdef Mut4 method28(unsigned long long v0, unsigned long long v1):
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
cdef void method31(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut4 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple4 tmp28
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp28 = v3[v4]
        v7, v8, v9, v10, v11 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3, tmp28.v4
        del tmp28
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple4(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method31(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method30(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
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
        method31(v8, v2, v3, v7, v9)
        del v7
        method30(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method29(Mut3 v0) except *:
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
    method30(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple5 method26(Mut3 v0, UH0 v1, signed short v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut4 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef numpy.ndarray[float,ndim=1] v12
    cdef Tuple4 tmp27
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
        tmp27 = v4[v5]
        v8, v9, v10, v11, v12 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3, tmp27.v4
        del tmp27
        v13 = v3 == v8
        if v13:
            v15 = method27(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple5(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method26(v0, v1, v2, v3, v4, v16)
    else:
        v23 = numpy.zeros(v2,dtype=numpy.float32)
        v24 = numpy.zeros(v2,dtype=numpy.float32)
        v25 = (<unsigned long long>3)
        v26 = (<unsigned long long>7)
        v27 = method28(v25, v26)
        v4.append(Tuple4(v3, v1, v27, v23, v24))
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
            method29(v0)
        else:
            pass
        return Tuple5(v27, v23, v24)
cdef Tuple5 method24(Mut3 v0, signed short v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method25(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method26(v0, v2, v1, v4, v8, v9)
cdef bint method32(signed short v0, Mut5 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method35(UH2 v0) except *:
    cdef US3 v1
    cdef UH2 v2
    cdef unsigned long long v67
    cdef US2 v3
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
    cdef US1 v35
    cdef unsigned long long v45
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef unsigned long long v42
    cdef unsigned long long v43
    cdef unsigned long long v46
    cdef unsigned long long v47
    cdef unsigned long long v48
    cdef unsigned long long v49
    cdef US1 v51
    cdef unsigned long long v61
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef unsigned long long v58
    cdef unsigned long long v59
    cdef unsigned long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    cdef unsigned long long v65
    cdef unsigned long long v68
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef unsigned long long v76
    cdef unsigned long long v77
    if v0.tag == 0: # Cons
        v1 = (<UH2_0>v0).v0; v2 = (<UH2_0>v0).v1
        if v1.tag == 0: # VAction
            v3 = (<US3_0>v1).v0
            if v3 == 0: # Call
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # Fold
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # Raise
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v67 = v15 * v17
        elif v1.tag == 1: # VCardFuture
            v19 = (<US3_1>v1).v0
            if v19 == 0: # Jack
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # King
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # Queen
                v26 = (<signed long>2)
                v27 = (<unsigned long long>1) + v26
                v29 = (<unsigned long long>9223372036854765835) * v27
            v30 = (<unsigned long long>9223372036854775807) + v29
            v31 = v30 * (<unsigned long long>9973)
            v32 = (<signed long>1)
            v33 = (<unsigned long long>1) + v32
            v67 = v31 * v33
        elif v1.tag == 2: # VCardOpponent
            v35 = (<US3_2>v1).v0
            if v35 == 0: # Jack
                v36 = (<signed long>0)
                v37 = (<unsigned long long>1) + v36
                v45 = (<unsigned long long>9223372036854765835) * v37
            elif v35 == 1: # King
                v39 = (<signed long>1)
                v40 = (<unsigned long long>1) + v39
                v45 = (<unsigned long long>9223372036854765835) * v40
            elif v35 == 2: # Queen
                v42 = (<signed long>2)
                v43 = (<unsigned long long>1) + v42
                v45 = (<unsigned long long>9223372036854765835) * v43
            v46 = (<unsigned long long>9223372036854775807) + v45
            v47 = v46 * (<unsigned long long>9973)
            v48 = (<signed long>2)
            v49 = (<unsigned long long>1) + v48
            v67 = v47 * v49
        elif v1.tag == 3: # VCardPresent
            v51 = (<US3_3>v1).v0
            if v51 == 0: # Jack
                v52 = (<signed long>0)
                v53 = (<unsigned long long>1) + v52
                v61 = (<unsigned long long>9223372036854765835) * v53
            elif v51 == 1: # King
                v55 = (<signed long>1)
                v56 = (<unsigned long long>1) + v55
                v61 = (<unsigned long long>9223372036854765835) * v56
            elif v51 == 2: # Queen
                v58 = (<signed long>2)
                v59 = (<unsigned long long>1) + v58
                v61 = (<unsigned long long>9223372036854765835) * v59
            v62 = (<unsigned long long>9223372036854775807) + v61
            v63 = v62 * (<unsigned long long>9973)
            v64 = (<signed long>3)
            v65 = (<unsigned long long>1) + v64
            v67 = v63 * v65
        del v1
        v68 = v67 * (<unsigned long long>9973)
        v69 = method35(v2)
        del v2
        v70 = v68 + v69
        v71 = (<unsigned long long>9223372036854775807) + v70
        v72 = v71 * (<unsigned long long>9973)
        v73 = (<signed long>0)
        v74 = (<unsigned long long>1) + v73
        return v72 * v74
    elif v0.tag == 1: # Nil
        v76 = (<signed long>1)
        v77 = (<unsigned long long>1) + v76
        return (<unsigned long long>9223372036854765835) * v77
cdef bint method37(UH2 v0, UH2 v1) except *:
    cdef US3 v2
    cdef UH2 v3
    cdef US3 v4
    cdef UH2 v5
    cdef bint v18
    cdef US2 v6
    cdef US2 v7
    cdef US1 v9
    cdef US1 v10
    cdef US1 v12
    cdef US1 v13
    cdef US1 v15
    cdef US1 v16
    if v1.tag == 0 and v0.tag == 0: # Cons
        v2 = (<UH2_0>v1).v0; v3 = (<UH2_0>v1).v1; v4 = (<UH2_0>v0).v0; v5 = (<UH2_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # VAction
            v6 = (<US3_0>v2).v0; v7 = (<US3_0>v4).v0
            if v6 == 0 and v7 == 0: # Call
                v18 = 1
            elif v6 == 1 and v7 == 1: # Fold
                v18 = 1
            elif v6 == 2 and v7 == 2: # Raise
                v18 = 1
            else:
                v18 = 0
        elif v2.tag == 1 and v4.tag == 1: # VCardFuture
            v9 = (<US3_1>v2).v0; v10 = (<US3_1>v4).v0
            if v9 == 0 and v10 == 0: # Jack
                v18 = 1
            elif v9 == 1 and v10 == 1: # King
                v18 = 1
            elif v9 == 2 and v10 == 2: # Queen
                v18 = 1
            else:
                v18 = 0
        elif v2.tag == 2 and v4.tag == 2: # VCardOpponent
            v12 = (<US3_2>v2).v0; v13 = (<US3_2>v4).v0
            if v12 == 0 and v13 == 0: # Jack
                v18 = 1
            elif v12 == 1 and v13 == 1: # King
                v18 = 1
            elif v12 == 2 and v13 == 2: # Queen
                v18 = 1
            else:
                v18 = 0
        elif v2.tag == 3 and v4.tag == 3: # VCardPresent
            v15 = (<US3_3>v2).v0; v16 = (<US3_3>v4).v0
            if v15 == 0 and v16 == 0: # Jack
                v18 = 1
            elif v15 == 1 and v16 == 1: # King
                v18 = 1
            elif v15 == 2 and v16 == 2: # Queen
                v18 = 1
            else:
                v18 = 0
        else:
            v18 = 0
        del v2; del v4
        if v18:
            return method37(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # Nil
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
    cdef Tuple6 tmp35
    cdef unsigned long long v11
    cdef list v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp35 = v3[v4]
        v7, v8, v9, v10 = tmp35.v0, tmp35.v1, tmp35.v2, tmp35.v3
        del tmp35
        v11 = v7 % v1
        v12 = v2[v11]
        v12.append(Tuple6(v7, v8, v9, v10))
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
cdef Tuple7 method36(Mut4 v0, UH2 v1, signed short v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH2 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple6 tmp34
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
        tmp34 = v4[v5]
        v8, v9, v10, v11 = tmp34.v0, tmp34.v1, tmp34.v2, tmp34.v3
        del tmp34
        v12 = v3 == v8
        if v12:
            v14 = method37(v9, v1)
        else:
            v14 = 0
        del v9
        if v14:
            return Tuple7(v10, v11)
        else:
            del v10; del v11
            v15 = v5 + (<unsigned long long>1)
            return method36(v0, v1, v2, v3, v4, v15)
    else:
        v20 = numpy.zeros(v2,dtype=numpy.float32)
        v21 = numpy.zeros(v2,dtype=numpy.float32)
        v4.append(Tuple6(v3, v1, v21, v20))
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
        return Tuple7(v21, v20)
cdef Tuple7 method34(Mut4 v0, signed short v1, UH2 v2):
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
    cdef Tuple6 tmp32
    cdef signed short v17
    cdef unsigned long long tmp33
    cdef numpy.ndarray[float,ndim=1] v18
    cdef numpy.ndarray[float,ndim=1] v19
    cdef Tuple7 tmp36
    cdef signed short v20
    cdef unsigned long long tmp37
    cdef Mut2 v21
    cdef signed short v23
    cdef float v24
    cdef float v25
    cdef float v26
    cdef signed short v27
    cdef signed short v28
    cdef unsigned long long tmp38
    cdef Mut2 v29
    cdef signed short v31
    cdef float v32
    cdef float v33
    cdef float v34
    cdef signed short v35
    cdef unsigned long long v36
    cdef unsigned long long v37
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
            tmp32 = v8[v12]
            v13, v14, v15, v16 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3
            del tmp32
            tmp33 = len(v16)
            if <signed short>tmp33 != tmp33: raise Exception("The conversion to signed short failed.")
            v17 = <signed short>tmp33
            tmp36 = method34(v0, v17, v14)
            v18, v19 = tmp36.v0, tmp36.v1
            del tmp36
            del v14
            tmp37 = len(v19)
            if <signed short>tmp37 != tmp37: raise Exception("The conversion to signed short failed.")
            v20 = <signed short>tmp37
            v21 = Mut2((<signed short>0))
            while method22(v20, v21):
                v23 = v21.v0
                v24 = v19[v23]
                v25 = v16[v23]
                v26 = v24 + v25
                v19[v23] = v26
                v27 = v23 + (<signed short>1)
                v21.v0 = v27
            del v16; del v19
            del v21
            tmp38 = len(v18)
            if <signed short>tmp38 != tmp38: raise Exception("The conversion to signed short failed.")
            v28 = <signed short>tmp38
            v29 = Mut2((<signed short>0))
            while method22(v28, v29):
                v31 = v29.v0
                v32 = v18[v31]
                v33 = v15[v31]
                v34 = v32 + v33
                v18[v31] = v34
                v35 = v31 + (<signed short>1)
                v29.v0 = v35
            del v15; del v18
            del v29
            v36 = v12 + (<unsigned long long>1)
            v10.v0 = v36
        del v8
        del v10
        v37 = v7 + (<unsigned long long>1)
        v5.v0 = v37
    del v3
cdef void method23(Mut3 v0, Mut3 v1) except *:
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
    cdef Tuple4 tmp25
    cdef signed short v18
    cdef unsigned long long tmp26
    cdef Mut4 v19
    cdef numpy.ndarray[float,ndim=1] v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef Tuple5 tmp29
    cdef bint v22
    cdef float v23
    cdef Mut5 v24
    cdef signed short v26
    cdef float v27
    cdef float v28
    cdef float v29
    cdef signed short v30
    cdef float v31
    cdef bint v32
    cdef float v36
    cdef float v37
    cdef float v33
    cdef float v34
    cdef float v35
    cdef numpy.ndarray[float,ndim=1] v38
    cdef Mut2 v39
    cdef signed short v41
    cdef float v42
    cdef float v43
    cdef float v44
    cdef signed short v45
    cdef signed short v46
    cdef unsigned long long tmp30
    cdef Mut2 v47
    cdef signed short v49
    cdef float v50
    cdef float v51
    cdef float v52
    cdef signed short v53
    cdef signed short v54
    cdef unsigned long long tmp31
    cdef Mut2 v55
    cdef signed short v57
    cdef float v58
    cdef float v59
    cdef float v60
    cdef signed short v61
    cdef unsigned long long v62
    cdef unsigned long long v63
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
            tmp25 = v8[v12]
            v13, v14, v15, v16, v17 = tmp25.v0, tmp25.v1, tmp25.v2, tmp25.v3, tmp25.v4
            del tmp25
            tmp26 = len(v16)
            if <signed short>tmp26 != tmp26: raise Exception("The conversion to signed short failed.")
            v18 = <signed short>tmp26
            tmp29 = method24(v0, v18, v14)
            v19, v20, v21 = tmp29.v0, tmp29.v1, tmp29.v2
            del tmp29
            del v14
            v22 = v18 == (<signed short>0)
            if v22:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v23 = v16[(<signed short>0)]
            v24 = Mut5((<signed short>1), v23)
            while method32(v18, v24):
                v26 = v24.v0
                v27 = v24.v1
                v28 = v16[v26]
                v29 = v27 + v28
                v30 = v26 + (<signed short>1)
                v24.v0 = v30
                v24.v1 = v29
            v31 = v24.v1
            del v24
            v32 = v31 == (<float>0)
            if v32:
                v33 = <float>v18
                v34 = (<float>1) / v33
                v36, v37 = v34, (<float>0)
            else:
                v35 = (<float>1) / v31
                v36, v37 = (<float>0), v35
            v38 = numpy.empty(v18,dtype=numpy.float32)
            v39 = Mut2((<signed short>0))
            while method22(v18, v39):
                v41 = v39.v0
                v42 = v16[v41]
                v43 = v42 * v37
                v44 = v36 + v43
                v38[v41] = v44
                v45 = v41 + (<signed short>1)
                v39.v0 = v45
            del v16
            del v39
            tmp30 = len(v20)
            if <signed short>tmp30 != tmp30: raise Exception("The conversion to signed short failed.")
            v46 = <signed short>tmp30
            v47 = Mut2((<signed short>0))
            while method22(v46, v47):
                v49 = v47.v0
                v50 = v20[v49]
                v51 = v38[v49]
                v52 = v50 + v51
                v20[v49] = v52
                v53 = v49 + (<signed short>1)
                v47.v0 = v53
            del v20; del v38
            del v47
            tmp31 = len(v21)
            if <signed short>tmp31 != tmp31: raise Exception("The conversion to signed short failed.")
            v54 = <signed short>tmp31
            v55 = Mut2((<signed short>0))
            while method22(v54, v55):
                v57 = v55.v0
                v58 = v21[v57]
                v59 = v17[v57]
                v60 = v58 + v59
                v21[v57] = v60
                v61 = v57 + (<signed short>1)
                v55.v0 = v61
            del v17; del v21
            del v55
            method33(v19, v15)
            del v15; del v19
            v62 = v12 + (<unsigned long long>1)
            v10.v0 = v62
        del v8
        del v10
        v63 = v7 + (<unsigned long long>1)
        v5.v0 = v63
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
    cdef Tuple6 tmp54
    cdef signed short v17
    cdef unsigned long long tmp55
    cdef Mut2 v18
    cdef signed short v20
    cdef float v21
    cdef float v22
    cdef signed short v23
    cdef signed short v24
    cdef unsigned long long tmp56
    cdef Mut2 v25
    cdef signed short v27
    cdef float v28
    cdef float v29
    cdef signed short v30
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
            tmp54 = v8[v12]
            v13, v14, v15, v16 = tmp54.v0, tmp54.v1, tmp54.v2, tmp54.v3
            del tmp54
            del v14
            tmp55 = len(v15)
            if <signed short>tmp55 != tmp55: raise Exception("The conversion to signed short failed.")
            v17 = <signed short>tmp55
            v18 = Mut2((<signed short>0))
            while method22(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v21 * v0
                v15[v20] = v22
                v23 = v20 + (<signed short>1)
                v18.v0 = v23
            del v15
            del v18
            tmp56 = len(v16)
            if <signed short>tmp56 != tmp56: raise Exception("The conversion to signed short failed.")
            v24 = <signed short>tmp56
            v25 = Mut2((<signed short>0))
            while method22(v24, v25):
                v27 = v25.v0
                v28 = v16[v27]
                v29 = v28 * v0
                v16[v27] = v29
                v30 = v27 + (<signed short>1)
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
    cdef Tuple4 tmp53
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
            tmp53 = v8[v12]
            v13, v14, v15, v16, v17 = tmp53.v0, tmp53.v1, tmp53.v2, tmp53.v3, tmp53.v4
            del tmp53
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
    cdef Tuple4 tmp57
    cdef signed short v17
    cdef unsigned long long tmp58
    cdef Mut2 v18
    cdef signed short v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef bint v24
    cdef float v25
    cdef signed short v26
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
            tmp57 = v7[v11]
            v12, v13, v14, v15, v16 = tmp57.v0, tmp57.v1, tmp57.v2, tmp57.v3, tmp57.v4
            del tmp57
            del v13; del v14
            tmp58 = len(v15)
            if <signed short>tmp58 != tmp58: raise Exception("The conversion to signed short failed.")
            v17 = <signed short>tmp58
            v18 = Mut2((<signed short>0))
            while method22(v17, v18):
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
                v26 = v20 + (<signed short>1)
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
    v9 = Closure14()
    v10 = Closure15()
    v11 = Closure16()
    v12 = Closure19()
    v13 = Closure20()
    v14 = collections.namedtuple("Tabular",['average', 'create_agent', 'create_policy', 'head_multiply_', 'optimize'])(v9, v10, v11, v12, v13)
    del v9; del v10; del v11; del v12; del v13
    v15 = Closure21()
    return {'neural': v8, 'tabular': v14, 'uniform_player': v15, 'vs_one': v5, 'vs_self': v2}
