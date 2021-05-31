import torch
import torch.distributions
import torch.optim
import numpy
cimport numpy
import nets
cimport libc.math
ctypedef signed long US0
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
ctypedef signed long US1
cdef class Mut0:
    cdef public signed long v0
    def __init__(self, signed long v0): self.v0 = v0
cdef class Mut1:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
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
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US0 v2
    def __init__(self, float v0, float v1, US0 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
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
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    cdef readonly object v17
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16, v17): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
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
    cdef readonly US3 v14
    cdef readonly float v15
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, float v15): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
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
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
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
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = args.v0
        cdef float v17 = args.v1
        cdef US0 v18 = args.v2
        cdef bint v19
        cdef float v20
        cdef float v21
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
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
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, signed long v6, US1 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
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
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = args.v0
        cdef float v16 = args.v1
        cdef US0 v17 = args.v2
        cdef bint v18
        cdef float v19
        cdef float v20
        cdef US2 v21
        cdef US2 v22
        cdef UH0 v23
        cdef UH0 v24
        cdef US2 v25
        cdef US2 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
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
            return method7(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v24, v20, v19, v28, v9, v10)
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
            return method7(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v35, v12, v13, v39, v31, v30)
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
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
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
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = args.v0
        cdef float v17 = args.v1
        cdef US0 v18 = args.v2
        cdef bint v19
        cdef float v20
        cdef float v21
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
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
            return method11(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method11(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
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
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
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
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = args.v0
        cdef float v16 = args.v1
        cdef US0 v17 = args.v2
        cdef bint v18
        cdef float v19
        cdef float v20
        cdef US2 v21
        cdef UH0 v22
        cdef US2 v23
        cdef UH0 v24
        cdef float v26
        cdef float v27
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
            return method6(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v22, v20, v19, v24, v9, v10)
        else:
            v26 = v16 + v10
            v27 = v15 + v9
            v28 = US2_0(v17)
            v29 = UH0_0(v28, v11)
            del v28
            v30 = US2_0(v17)
            v31 = UH0_0(v30, v8)
            del v30
            return method6(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v29, v12, v13, v31, v27, v26)
cdef class Closure0():
    cdef US1 v0
    cdef US1 v1
    cdef Heap0 v2
    cdef object v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef float v10
    def __init__(self, US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, float v5, float v6, UH0 v7, float v8, float v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple0 args):
        cdef US1 v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef float v5 = self.v5
        cdef float v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef float v11 = args.v0
        cdef float v12 = args.v1
        cdef US0 v13 = args.v2
        cdef float v14
        cdef float v15
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
        return method4(v0, v1, v2, v3, v13, v10, v19, v15, v14, v23, v5, v6)
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
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly float v1
    cdef readonly float v2
    cdef readonly UH0 v3
    cdef readonly float v4
    cdef readonly float v5
    cdef readonly UH0 v6
    cdef readonly float v7
    cdef readonly float v8
    cdef readonly US1 v9
    cdef readonly unsigned char v10
    cdef readonly signed long v11
    cdef readonly US1 v12
    cdef readonly unsigned char v13
    cdef readonly signed long v14
    cdef readonly US3 v15
    cdef readonly float v16
    def __init__(self, unsigned long long v0, float v1, float v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US3 v15, float v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US0 v0
    cdef readonly UH2 v1
    def __init__(self, US0 v0, UH2 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class UH3:
    cdef readonly signed long tag
cdef class UH3_0(UH3): # cons_
    cdef readonly US1 v0
    cdef readonly object v1
    cdef readonly UH3 v2
    def __init__(self, US1 v0, v1, UH3 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH3_1(UH3): # nil
    def __init__(self): self.tag = 1
cdef class Tuple3:
    cdef readonly US1 v0
    cdef readonly object v1
    def __init__(self, US1 v0, v1): self.v0 = v0; self.v1 = v1
cdef bint method0(Mut0 v0) except *:
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>1)
cdef bint method1(Mut0 v0) except *:
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>20)
cdef bint method2(Mut1 v0) except *:
    cdef unsigned long long v1
    v1 = v0.v0
    return v1 < (<unsigned long long>1024)
cdef bint method3(unsigned long long v0, Mut1 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[signed long,ndim=1] method5(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method8(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method10(US1 v0) except *:
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef UH1 method9(Heap0 v0, signed long v1, US1 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
    cdef float v89
    cdef US3 v90
    cdef signed long v92
    cdef signed long v93
    cdef numpy.ndarray[signed long,ndim=1] v94
    cdef US3 v95
    cdef object v96
    if v9 == 0: # call
        v17 = method10(v2)
        v18 = method10(v6)
        v19 = method10(v3)
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
        v70 = <float>v55
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
        v89 = <float>v75
        v90 = US3_1(v2)
        return UH1_1(v10, v10, v11, v12, v13, v14, v15, v16, v83, v84, v85, v86, v87, v88, v90, v89)
    elif v9 == 2: # raise
        v92 = v1 - (<signed long>1)
        v93 = v5 + (<signed long>4)
        v94 = method8(v0, v6, v7, v93, v3, v4, v5, v92)
        v95 = US3_1(v2)
        v96 = Closure3(v4, v0, v92, v2, v6, v7, v93, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH1_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v93, v95, v4, v94, v96)
cdef UH1 method7(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, US0 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
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
        v17 = method8(v0, v4, v5, v6, v1, v2, v3, v16)
        v18 = US3_1(v7)
        v19 = Closure3(v2, v0, v16, v7, v4, v5, v6, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v18, v2, v17, v19)
    elif v8 == 1: # fold
        raise Exception("impossible 2")
    elif v8 == 2: # raise
        v23 = (<signed long>1)
        v24 = v3 + (<signed long>4)
        v25 = method8(v0, v4, v5, v24, v1, v2, v3, v23)
        v26 = US3_1(v7)
        v27 = Closure3(v2, v0, v23, v7, v4, v5, v24, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v24, v26, v2, v25, v27)
cdef UH1 method11(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
    cdef float v27
    cdef float v28
    cdef float v29
    cdef float v30
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
    cdef float v55
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
        v27 = <float>v24
        v28 = (<float>1.000000) / v27
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
        v55 = <float>v41
        v56 = US3_0()
        return UH1_1(v10, v10, v11, v12, v13, v14, v15, v16, v49, v50, v51, v52, v53, v54, v56, v55)
    elif v9 == 2: # raise
        v58 = v2 - (<signed long>1)
        v59 = v5 + (<signed long>2)
        v60 = method8(v0, v6, v7, v59, v3, v4, v5, v58)
        v61 = US3_0()
        v62 = Closure4(v4, v0, v1, v58, v6, v7, v59, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH1_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v59, v61, v4, v60, v62)
cdef UH1 method6(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US0 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
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
    cdef float v26
    cdef float v27
    cdef float v28
    cdef float v29
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
    cdef float v54
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
        v26 = <float>v23
        v27 = (<float>1.000000) / v26
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
        v54 = <float>v40
        v55 = US3_0()
        return UH1_1(v9, v9, v10, v11, v12, v13, v14, v15, v48, v49, v50, v51, v52, v53, v55, v54)
    elif v8 == 2: # raise
        v57 = v2 - (<signed long>1)
        v58 = v5 + (<signed long>2)
        v59 = method8(v0, v6, v7, v58, v3, v4, v5, v57)
        v60 = US3_0()
        v61 = Closure4(v4, v0, v1, v57, v6, v7, v58, v3, v5, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v58, v60, v4, v59, v61)
cdef UH1 method4(US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, US0 v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
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
        v16 = method5(v2, v0, v15, v14, v1, v13, v12)
        v17 = US3_0()
        v18 = Closure1(v13, v2, v3, v12, v0, v15, v14, v1, v9, v10, v11, v6, v7, v8, v5)
        return UH1_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v13, v14, v0, v15, v14, v17, v13, v16, v18)
    elif v4 == 1: # fold
        raise Exception("impossible 1")
    elif v4 == 2: # raise
        v22 = (<signed long>1)
        v23 = (<unsigned char>1)
        v24 = (<signed long>1)
        v25 = (<unsigned char>0)
        v26 = (<signed long>3)
        v27 = method8(v2, v0, v25, v26, v1, v23, v24, v22)
        v28 = US3_0()
        v29 = Closure4(v23, v2, v3, v22, v0, v25, v26, v1, v24, v9, v10, v11, v6, v7, v8, v5)
        return UH1_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v23, v24, v0, v25, v26, v28, v23, v27, v29)
cdef UH0 method14(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method14(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH2 method16(UH2 v0, UH2 v1):
    cdef US0 v2
    cdef UH2 v3
    cdef UH2 v4
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v3 = (<UH2_0>v0).v1
        v4 = UH2_0(v2, v1)
        return method16(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method18(UH2 v0, unsigned long long v1) except *:
    cdef US0 v2
    cdef UH2 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v3 = (<UH2_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method18(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method19(numpy.ndarray[signed long,ndim=1] v0, UH2 v1, unsigned long long v2) except *:
    cdef US0 v3
    cdef UH2 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1
        v0[v2] = v3
        v5 = v2 + (<unsigned long long>1)
        return method19(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[signed long,ndim=1] method17(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[signed long,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method18(v0, v1)
    v3 = numpy.empty(v2,dtype=numpy.int32)
    v4 = (<unsigned long long>0)
    v5 = method19(v3, v0, v4)
    return v3
cdef UH3 method15(UH2 v0, US1 v1, UH0 v2):
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef UH2 v6
    cdef US1 v8
    cdef UH2 v9
    cdef UH2 v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef UH2 v12
    cdef UH3 v13
    cdef UH2 v16
    cdef UH2 v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef UH3 v19
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US2_0>v3).v0
            v6 = UH2_0(v5, v0)
            return method15(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH2_1()
            v10 = method16(v0, v9)
            del v9
            v11 = method17(v10)
            del v10
            v12 = UH2_1()
            v13 = method15(v12, v8, v4)
            del v4; del v12
            return UH3_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH2_1()
        v17 = method16(v0, v16)
        del v16
        v18 = method17(v17)
        del v17
        v19 = UH3_1()
        return UH3_0(v1, v18, v19)
cdef unsigned long long method21(UH3 v0, unsigned long long v1) except *:
    cdef US1 v2
    cdef UH3 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH3_0>v0).v0; v4 = (<UH3_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method21(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method22(numpy.ndarray[object,ndim=1] v0, UH3 v1, unsigned long long v2) except *:
    cdef US1 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH3 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH3_0>v1).v0; v4 = (<UH3_0>v1).v1; v5 = (<UH3_0>v1).v2
        v0[v2] = Tuple3(v3, v4)
        del v4
        v6 = v2 + (<unsigned long long>1)
        return method22(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method20(UH3 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method21(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<unsigned long long>0)
    v5 = method22(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method13(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef US1 v7
    cdef UH2 v8
    cdef UH3 v9
    v1 = UH0_1()
    v2 = method14(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US2_0>v3).v0
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US2_1>v3).v0
            v8 = UH2_1()
            v9 = method15(v8, v7, v4)
            del v4; del v8
            return method20(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef void method23(v0, v1, v2, unsigned long long v3, float v4, signed long long v5) except *:
    cdef bint v6
    cdef signed long long v7
    cdef float v8
    cdef bint v9
    cdef float v14
    cdef float v10
    cdef float v11
    cdef float v12
    v6 = v5 < (<signed long long>3)
    if v6:
        v7 = v5 + (<signed long long>1)
        v8 = v0[v3,v5]
        v9 = v8 == (<float>0.000000)
        if v9:
            v10 = (<float>0.250000) / v4
            v11 = v1[v3,v5]
            v12 = (<float>0.750000) * v11
            v14 = v10 + v12
        else:
            v14 = (<float>0.000000)
        v2[v3,v5] = v14
        method23(v0, v1, v2, v3, v4, v7)
    else:
        pass
cdef float method24(unsigned char v0, float v1, float v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8) except *:
    cdef bint v9
    cdef float v10
    cdef float v11
    cdef float v12
    cdef float v13
    cdef float v14
    cdef float v15
    cdef float v16
    cdef float v17
    cdef float v18
    v9 = v0 == (<unsigned char>0)
    if v9:
        v10, v11, v12, v13 = v4, v5, v7, v8
    else:
        v10, v11, v12, v13 = v7, v8, v4, v5
    v14 = v2 + v13
    v15 = v1 + v12
    v16 = -v11
    v17 = v15 - v14
    v18 = v16 + v17
    return libc.math.exp(v18)
cdef numpy.ndarray[float,ndim=1] method12(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef unsigned long long v7
    cdef Mut1 v8
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
    cdef US3 v26
    cdef unsigned char v27
    cdef numpy.ndarray[signed long,ndim=1] v28
    cdef object v29
    cdef float v30
    cdef float v31
    cdef UH0 v32
    cdef float v33
    cdef float v34
    cdef UH0 v35
    cdef float v36
    cdef float v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef US3 v44
    cdef float v45
    cdef unsigned long long v46
    cdef unsigned long long v47
    cdef bint v48
    cdef numpy.ndarray[float,ndim=1] v286
    cdef unsigned long long v49
    cdef object v50
    cdef unsigned long long v51
    cdef Mut1 v52
    cdef unsigned long long v54
    cdef float v55
    cdef float v56
    cdef UH0 v57
    cdef float v58
    cdef float v59
    cdef UH0 v60
    cdef float v61
    cdef float v62
    cdef US1 v63
    cdef unsigned char v64
    cdef signed long v65
    cdef US1 v66
    cdef unsigned char v67
    cdef signed long v68
    cdef US3 v69
    cdef unsigned char v70
    cdef numpy.ndarray[signed long,ndim=1] v71
    cdef Tuple1 tmp0
    cdef bint v72
    cdef UH0 v73
    cdef numpy.ndarray[object,ndim=1] v74
    cdef bint v75
    cdef signed long v76
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef US1 v79
    cdef numpy.ndarray[float,ndim=1] v80
    cdef bint v81
    cdef bint v83
    cdef unsigned long long v84
    cdef bint v85
    cdef bint v87
    cdef unsigned long long v88
    cdef unsigned long long v89
    cdef bint v90
    cdef Mut1 v91
    cdef unsigned long long v93
    cdef US1 v94
    cdef numpy.ndarray[signed long,ndim=1] v95
    cdef Tuple3 tmp1
    cdef unsigned long long v96
    cdef unsigned long long v97
    cdef unsigned long long v98
    cdef unsigned long long v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef bint v102
    cdef Mut1 v103
    cdef unsigned long long v105
    cdef US0 v106
    cdef unsigned long long v107
    cdef unsigned long long v108
    cdef unsigned long long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef numpy.ndarray[object,ndim=1] v115
    cdef Mut1 v116
    cdef unsigned long long v118
    cdef float v119
    cdef float v120
    cdef UH0 v121
    cdef float v122
    cdef float v123
    cdef UH0 v124
    cdef float v125
    cdef float v126
    cdef US1 v127
    cdef unsigned char v128
    cdef signed long v129
    cdef US1 v130
    cdef unsigned char v131
    cdef signed long v132
    cdef US3 v133
    cdef unsigned char v134
    cdef numpy.ndarray[signed long,ndim=1] v135
    cdef Tuple1 tmp2
    cdef unsigned long long v136
    cdef numpy.ndarray[signed long long,ndim=1] v137
    cdef Mut1 v138
    cdef unsigned long long v140
    cdef US0 v141
    cdef signed long long v142
    cdef unsigned long long v143
    cdef unsigned long long v144
    cdef object v145
    cdef object v146
    cdef unsigned long long v147
    cdef Mut1 v148
    cdef unsigned long long v150
    cdef numpy.ndarray[signed long long,ndim=1] v151
    cdef unsigned long long v152
    cdef Mut1 v153
    cdef unsigned long long v155
    cdef signed long long v156
    cdef unsigned long long v157
    cdef unsigned long long v158
    cdef object v159
    cdef object v160
    cdef object v161
    cdef Mut1 v162
    cdef unsigned long long v164
    cdef numpy.ndarray[signed long long,ndim=1] v165
    cdef unsigned long long v166
    cdef float v167
    cdef signed long long v168
    cdef unsigned long long v169
    cdef numpy.ndarray[signed long long,ndim=1] v170
    cdef unsigned long long v171
    cdef numpy.ndarray[object,ndim=1] v172
    cdef Mut1 v173
    cdef unsigned long long v175
    cdef signed long long v176
    cdef float v177
    cdef float v178
    cdef float v179
    cdef float v180
    cdef bint v181
    cdef US0 v198
    cdef bint v182
    cdef bint v183
    cdef bint v185
    cdef signed long long v186
    cdef bint v187
    cdef bint v188
    cdef bint v190
    cdef signed long long v191
    cdef bint v192
    cdef bint v193
    cdef unsigned long long v199
    cdef unsigned long long v200
    cdef unsigned long long v201
    cdef bint v202
    cdef bint v203
    cdef numpy.ndarray[object,ndim=1] v204
    cdef Mut1 v205
    cdef unsigned long long v207
    cdef object v208
    cdef float v209
    cdef float v210
    cdef US0 v211
    cdef Tuple0 tmp3
    cdef UH1 v212
    cdef unsigned long long v213
    cdef numpy.ndarray[float,ndim=1] v214
    cdef unsigned long long v215
    cdef bint v216
    cdef object v217
    cdef object v218
    cdef bint v219
    cdef object v222
    cdef bint v223
    cdef bint v224
    cdef Mut1 v225
    cdef unsigned long long v227
    cdef signed long long v228
    cdef float v229
    cdef float v230
    cdef float v231
    cdef bint v232
    cdef float v233
    cdef float v234
    cdef float v235
    cdef UH0 v236
    cdef float v237
    cdef float v238
    cdef UH0 v239
    cdef float v240
    cdef float v241
    cdef US1 v242
    cdef unsigned char v243
    cdef signed long v244
    cdef US1 v245
    cdef unsigned char v246
    cdef signed long v247
    cdef US3 v248
    cdef unsigned char v249
    cdef numpy.ndarray[signed long,ndim=1] v250
    cdef Tuple1 tmp4
    cdef float v251
    cdef unsigned long long v252
    cdef object v253
    cdef bint v254
    cdef unsigned long long v255
    cdef numpy.ndarray[float,ndim=1] v256
    cdef Mut1 v257
    cdef unsigned long long v259
    cdef float v260
    cdef float v261
    cdef UH0 v262
    cdef float v263
    cdef float v264
    cdef UH0 v265
    cdef float v266
    cdef float v267
    cdef US1 v268
    cdef unsigned char v269
    cdef signed long v270
    cdef US1 v271
    cdef unsigned char v272
    cdef signed long v273
    cdef US3 v274
    cdef unsigned char v275
    cdef numpy.ndarray[signed long,ndim=1] v276
    cdef Tuple1 tmp5
    cdef float v277
    cdef bint v278
    cdef float v279
    cdef float v280
    cdef unsigned long long v281
    cdef object v282
    cdef numpy.ndarray[float,ndim=1] v285
    cdef numpy.ndarray[float,ndim=1] v287
    cdef unsigned long long v288
    cdef unsigned long long v289
    cdef bint v290
    cdef bint v291
    cdef Mut1 v292
    cdef unsigned long long v294
    cdef unsigned long long v295
    cdef float v296
    cdef unsigned long long v297
    cdef unsigned long long v298
    cdef Mut1 v299
    cdef unsigned long long v301
    cdef unsigned long long v302
    cdef float v303
    cdef float v304
    cdef UH0 v305
    cdef float v306
    cdef float v307
    cdef UH0 v308
    cdef float v309
    cdef float v310
    cdef US1 v311
    cdef unsigned char v312
    cdef signed long v313
    cdef US1 v314
    cdef unsigned char v315
    cdef signed long v316
    cdef US3 v317
    cdef float v318
    cdef Tuple2 tmp6
    cdef unsigned long long v319
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = len(v2)
    v8 = Mut1((<unsigned long long>0))
    while method3(v7, v8):
        v10 = v8.v0
        v11 = v2[v10]
        if v11.tag == 0: # action_
            v12 = (<UH1_0>v11).v0; v13 = (<UH1_0>v11).v1; v14 = (<UH1_0>v11).v2; v15 = (<UH1_0>v11).v3; v16 = (<UH1_0>v11).v4; v17 = (<UH1_0>v11).v5; v18 = (<UH1_0>v11).v6; v19 = (<UH1_0>v11).v7; v20 = (<UH1_0>v11).v8; v21 = (<UH1_0>v11).v9; v22 = (<UH1_0>v11).v10; v23 = (<UH1_0>v11).v11; v24 = (<UH1_0>v11).v12; v25 = (<UH1_0>v11).v13; v26 = (<UH1_0>v11).v14; v27 = (<UH1_0>v11).v15; v28 = (<UH1_0>v11).v16; v29 = (<UH1_0>v11).v17
            v4.append(v10)
            v5.append(Tuple1(v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28))
            del v14; del v17; del v26; del v28
            v6.append(v29)
            del v29
        elif v11.tag == 1: # terminal_
            v30 = (<UH1_1>v11).v0; v31 = (<UH1_1>v11).v1; v32 = (<UH1_1>v11).v2; v33 = (<UH1_1>v11).v3; v34 = (<UH1_1>v11).v4; v35 = (<UH1_1>v11).v5; v36 = (<UH1_1>v11).v6; v37 = (<UH1_1>v11).v7; v38 = (<UH1_1>v11).v8; v39 = (<UH1_1>v11).v9; v40 = (<UH1_1>v11).v10; v41 = (<UH1_1>v11).v11; v42 = (<UH1_1>v11).v12; v43 = (<UH1_1>v11).v13; v44 = (<UH1_1>v11).v14; v45 = (<UH1_1>v11).v15
            v3.append(Tuple2(v10, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45))
            del v32; del v35; del v44
        del v11
        v46 = v10 + (<unsigned long long>1)
        v8.v0 = v46
    del v8
    v47 = len(v5)
    v48 = (<unsigned long long>0) < v47
    if v48:
        v49 = len(v5)
        v50 = torch.zeros(v49,(<unsigned long long>48))
        v51 = len(v5)
        v52 = Mut1((<unsigned long long>0))
        while method3(v51, v52):
            v54 = v52.v0
            tmp0 = v5[v54]
            v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
            del tmp0
            del v69; del v71
            v72 = v70 == (<unsigned char>0)
            if v72:
                v73 = v57
            else:
                v73 = v60
            del v57; del v60
            v74 = method13(v73)
            del v73
            v75 = v70 == v64
            if v75:
                v76 = v65
            else:
                v76 = v68
            v77 = v70
            v78 = v76
            if v75:
                v79 = v66
            else:
                v79 = v63
            v80 = v50[v54,:].numpy()
            v81 = (<unsigned long long>0) <= v77
            if v81:
                v83 = v77 < (<unsigned long long>2)
            else:
                v83 = 0
            if v83:
                v80[v77] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v84 = v78 - (<unsigned long long>1)
            v85 = (<unsigned long long>0) <= v84
            if v85:
                v87 = v84 < (<unsigned long long>13)
            else:
                v87 = 0
            if v87:
                v88 = (<unsigned long long>2) + v84
                v80[v88] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v89 = len(v74)
            v90 = (<unsigned long long>2) < v89
            if v90:
                raise Exception("The given array is too large.")
            else:
                pass
            v91 = Mut1((<unsigned long long>0))
            while method3(v89, v91):
                v93 = v91.v0
                tmp1 = v74[v93]
                v94, v95 = tmp1.v0, tmp1.v1
                del tmp1
                v96 = v93 * (<unsigned long long>15)
                v97 = (<unsigned long long>15) + v96
                if v94 == 0: # jack
                    v80[v97] = (<float>1.000000)
                elif v94 == 1: # king
                    v98 = v97 + (<unsigned long long>1)
                    v80[v98] = (<float>1.000000)
                elif v94 == 2: # queen
                    v99 = v97 + (<unsigned long long>2)
                    v80[v99] = (<float>1.000000)
                v100 = v97 + (<unsigned long long>3)
                v101 = len(v95)
                v102 = (<unsigned long long>4) < v101
                if v102:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v103 = Mut1((<unsigned long long>0))
                while method3(v101, v103):
                    v105 = v103.v0
                    v106 = v95[v105]
                    v107 = v105 * (<unsigned long long>3)
                    v108 = v100 + v107
                    if v106 == 0: # call
                        v80[v108] = (<float>1.000000)
                    elif v106 == 1: # fold
                        v109 = v108 + (<unsigned long long>1)
                        v80[v109] = (<float>1.000000)
                    elif v106 == 2: # raise
                        v110 = v108 + (<unsigned long long>2)
                        v80[v110] = (<float>1.000000)
                    v111 = v105 + (<unsigned long long>1)
                    v103.v0 = v111
                del v95
                del v103
                v112 = v93 + (<unsigned long long>1)
                v91.v0 = v112
            del v74
            del v91
            if v79 == 0: # jack
                v80[(<unsigned long long>45)] = (<float>1.000000)
            elif v79 == 1: # king
                v80[(<unsigned long long>46)] = (<float>1.000000)
            elif v79 == 2: # queen
                v80[(<unsigned long long>47)] = (<float>1.000000)
            del v80
            v113 = v54 + (<unsigned long long>1)
            v52.v0 = v113
        del v52
        v114 = len(v5)
        v115 = numpy.empty(v114,dtype=object)
        v116 = Mut1((<unsigned long long>0))
        while method3(v114, v116):
            v118 = v116.v0
            tmp2 = v5[v118]
            v119, v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16
            del tmp2
            del v121; del v124; del v133
            v136 = len(v135)
            v137 = numpy.empty(v136,dtype=numpy.int64)
            v138 = Mut1((<unsigned long long>0))
            while method3(v136, v138):
                v140 = v138.v0
                v141 = v135[v140]
                if v141 == 0: # call
                    v142 = (<signed long long>0)
                elif v141 == 1: # fold
                    v142 = (<signed long long>1)
                elif v141 == 2: # raise
                    v142 = (<signed long long>2)
                v137[v140] = v142
                v143 = v140 + (<unsigned long long>1)
                v138.v0 = v143
            del v135
            del v138
            v115[v118] = v137
            del v137
            v144 = v118 + (<unsigned long long>1)
            v116.v0 = v144
        del v116
        v145 = v1.forward(v50[:,:(<unsigned long long>45)])
        v146 = torch.full((v49,(<signed long long>3)),float('-inf'))
        v147 = len(v115)
        v148 = Mut1((<unsigned long long>0))
        while method3(v147, v148):
            v150 = v148.v0
            v151 = v115[v150]
            v152 = len(v151)
            v153 = Mut1((<unsigned long long>0))
            while method3(v152, v153):
                v155 = v153.v0
                v156 = v151[v155]
                v146[v150,v156] = 0
                v157 = v155 + (<unsigned long long>1)
                v153.v0 = v157
            del v151
            del v153
            v158 = v150 + (<unsigned long long>1)
            v148.v0 = v158
        del v148
        v159 = torch.log_softmax(v146 + v145.cpu(),dim=-1)
        del v145
        v160 = torch.exp(v159.detach())
        v161 = torch.empty_like(v160)
        v162 = Mut1((<unsigned long long>0))
        while method3(v147, v162):
            v164 = v162.v0
            v165 = v115[v164]
            v166 = len(v165)
            del v165
            v167 = <float>v166
            v168 = (<signed long long>0)
            method23(v146, v160, v161, v164, v167, v168)
            v169 = v164 + (<unsigned long long>1)
            v162.v0 = v169
        del v115; del v146
        del v162
        v170 = torch.distributions.Categorical(v161).sample().numpy()
        v171 = len(v170)
        v172 = numpy.empty(v171,dtype=object)
        v173 = Mut1((<unsigned long long>0))
        while method3(v171, v173):
            v175 = v173.v0
            v176 = v170[v175]
            v177 = v160[v175,v176]
            v178 = v161[v175,v176]
            v179 = libc.math.log(v178)
            v180 = libc.math.log(v177)
            v181 = v176 < (<signed long long>1)
            if v181:
                v182 = v176 == (<signed long long>0)
                v183 = v182 == 0
                if v183:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v198 = 0
            else:
                v185 = v176 < (<signed long long>2)
                if v185:
                    v186 = v176 - (<signed long long>1)
                    v187 = v186 == (<signed long long>0)
                    v188 = v187 == 0
                    if v188:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v198 = 1
                else:
                    v190 = v176 < (<signed long long>3)
                    if v190:
                        v191 = v176 - (<signed long long>2)
                        v192 = v191 == (<signed long long>0)
                        v193 = v192 == 0
                        if v193:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v198 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v172[v175] = Tuple0(v180, v179, v198)
            v199 = v175 + (<unsigned long long>1)
            v173.v0 = v199
        del v173
        v200 = len(v6)
        v201 = len(v172)
        v202 = v200 == v201
        v203 = v202 == 0
        if v203:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v204 = numpy.empty(v200,dtype=object)
        v205 = Mut1((<unsigned long long>0))
        while method3(v200, v205):
            v207 = v205.v0
            v208 = v6[v207]
            tmp3 = v172[v207]
            v209, v210, v211 = tmp3.v0, tmp3.v1, tmp3.v2
            del tmp3
            v212 = v208(Tuple0(v209, v210, v211))
            del v208
            v204[v207] = v212
            del v212
            v213 = v207 + (<unsigned long long>1)
            v205.v0 = v213
        del v172
        del v205
        v214 = method12(v0, v1, v204)
        del v204
        v215 = len(v214)
        v216 = v215 == (<unsigned long long>0)
        if v216:
            v286 = v214
        else:
            v217 = v0.forward(v50).cpu()
            v218 = v217.detach().clone()
            v219 = v0.training
            if v219:
                v222 = torch.zeros_like(v217)
            else:
                v222 = None
            v223 = v171 == v215
            v224 = v223 == 0
            if v224:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v225 = Mut1((<unsigned long long>0))
            while method3(v171, v225):
                v227 = v225.v0
                v228 = v170[v227]
                v229 = v214[v227]
                v230 = v161[v227,v228]
                v231 = v218[v227,v228]
                v232 = libc.math.isnan(v231)
                if v232:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v233 = v229 - v231
                tmp4 = v5[v227]
                v234, v235, v236, v237, v238, v239, v240, v241, v242, v243, v244, v245, v246, v247, v248, v249, v250 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3, tmp4.v4, tmp4.v5, tmp4.v6, tmp4.v7, tmp4.v8, tmp4.v9, tmp4.v10, tmp4.v11, tmp4.v12, tmp4.v13, tmp4.v14, tmp4.v15, tmp4.v16
                del tmp4
                del v248; del v250
                v251 = method24(v249, v234, v235, v236, v237, v238, v239, v240, v241)
                del v236; del v239
                if v219:
                    v222[v227,v228] -= v233 * v251
                else:
                    pass
                v218[v227,v228] += v233 / v230
                v252 = v227 + (<unsigned long long>1)
                v225.v0 = v252
            del v225
            if v219:
                v217.backward(v222)
            else:
                pass
            del v217; del v222
            v253 = torch.einsum('ab,ab->a',v218,v160)
            v254 = v1.training
            if v254:
                v255 = len(v5)
                v256 = numpy.empty(v255,dtype=numpy.float32)
                v257 = Mut1((<unsigned long long>0))
                while method3(v255, v257):
                    v259 = v257.v0
                    tmp5 = v5[v259]
                    v260, v261, v262, v263, v264, v265, v266, v267, v268, v269, v270, v271, v272, v273, v274, v275, v276 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4, tmp5.v5, tmp5.v6, tmp5.v7, tmp5.v8, tmp5.v9, tmp5.v10, tmp5.v11, tmp5.v12, tmp5.v13, tmp5.v14, tmp5.v15, tmp5.v16
                    del tmp5
                    del v274; del v276
                    v277 = method24(v275, v260, v261, v262, v263, v264, v265, v266, v267)
                    del v262; del v265
                    v278 = v275 == (<unsigned char>0)
                    if v278:
                        v279 = (<float>1.000000)
                    else:
                        v279 = (<float>-1.000000)
                    v280 = v277 * v279
                    v256[v259] = v280
                    v281 = v259 + (<unsigned long long>1)
                    v257.v0 = v281
                del v257
                v282 = torch.from_numpy(v256)
                del v256
                v159.backward(v282.unsqueeze(-1) * (v253.unsqueeze(-1) - v218))
                del v282
            else:
                pass
            del v218
            v286 = v253.numpy()
            del v253
        del v50; del v159; del v160; del v161; del v170; del v214
    else:
        v285 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v286 = v285
        del v285
    del v5; del v6
    v287 = numpy.empty(v7,dtype=numpy.float32)
    v288 = len(v4)
    v289 = len(v286)
    v290 = v288 == v289
    v291 = v290 == 0
    if v291:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v292 = Mut1((<unsigned long long>0))
    while method3(v288, v292):
        v294 = v292.v0
        v295 = v4[v294]
        v296 = v286[v294]
        v287[v295] = v296
        v297 = v294 + (<unsigned long long>1)
        v292.v0 = v297
    del v4; del v286
    del v292
    v298 = len(v3)
    v299 = Mut1((<unsigned long long>0))
    while method3(v298, v299):
        v301 = v299.v0
        tmp6 = v3[v301]
        v302, v303, v304, v305, v306, v307, v308, v309, v310, v311, v312, v313, v314, v315, v316, v317, v318 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4, tmp6.v5, tmp6.v6, tmp6.v7, tmp6.v8, tmp6.v9, tmp6.v10, tmp6.v11, tmp6.v12, tmp6.v13, tmp6.v14, tmp6.v15, tmp6.v16
        del tmp6
        del v305; del v308; del v317
        v287[v302] = v318
        v319 = v301 + (<unsigned long long>1)
        v299.v0 = v319
    del v3
    del v299
    return v287
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
    cdef object v20
    cdef object v21
    cdef object v22
    cdef Mut0 v23
    cdef signed long v25
    cdef Mut0 v26
    cdef signed long v28
    cdef numpy.ndarray[object,ndim=1] v29
    cdef Mut1 v30
    cdef unsigned long long v32
    cdef UH0 v33
    cdef float v34
    cdef float v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef US1 v41
    cdef unsigned long long v42
    cdef numpy.ndarray[signed long,ndim=1] v43
    cdef Mut1 v44
    cdef unsigned long long v46
    cdef bint v47
    cdef unsigned long long v49
    cdef US1 v50
    cdef unsigned long long v51
    cdef float v52
    cdef float v53
    cdef float v54
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef US1 v57
    cdef unsigned long long v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef Mut1 v60
    cdef unsigned long long v62
    cdef bint v63
    cdef unsigned long long v65
    cdef US1 v66
    cdef unsigned long long v67
    cdef float v68
    cdef float v69
    cdef float v70
    cdef float v71
    cdef numpy.ndarray[signed long,ndim=1] v72
    cdef US2 v73
    cdef UH0 v74
    cdef US2 v75
    cdef UH0 v76
    cdef US3 v77
    cdef object v78
    cdef UH1 v79
    cdef unsigned long long v80
    cdef numpy.ndarray[float,ndim=1] v81
    cdef signed long v82
    cdef signed long v83
    pass # import torch
    pass # import torch.distributions
    pass # import torch.optim
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
    pass # import nets
    v20 = nets.small((<unsigned long long>45),(<unsigned long long>64),(<signed long long>3))
    v21 = nets.small((<unsigned long long>48),(<unsigned long long>64),(<signed long long>3))
    print('The learning rate is 2 **',torch.log2(torch.scalar_tensor((<float>0.000061))).item())
    v22 = torch.optim.SGD([{'params':v20.parameters()},{'params':v21.parameters()}],lr=(<float>0.000061))
    v23 = Mut0((<signed long>0))
    while method0(v23):
        v25 = v23.v0
        v20.eval()
        v21.train()
        v26 = Mut0((<signed long>0))
        while method1(v26):
            v28 = v26.v0
            v29 = numpy.empty((<unsigned long long>1024),dtype=object)
            v30 = Mut1((<unsigned long long>0))
            while method2(v30):
                v32 = v30.v0
                v33 = UH0_1()
                v34 = (<float>0.000000)
                v35 = (<float>0.000000)
                v36 = UH0_1()
                v37 = (<float>0.000000)
                v38 = (<float>0.000000)
                v39 = len(v19)
                v40 = numpy.random.randint(0,v39)
                v41 = v19[v40]
                v42 = v39 - (<unsigned long long>1)
                v43 = numpy.empty(v42,dtype=numpy.int32)
                v44 = Mut1((<unsigned long long>0))
                while method3(v42, v44):
                    v46 = v44.v0
                    v47 = v40 <= v46
                    if v47:
                        v49 = v46 + (<unsigned long long>1)
                    else:
                        v49 = v46
                    v50 = v19[v49]
                    v43[v46] = v50
                    v51 = v46 + (<unsigned long long>1)
                    v44.v0 = v51
                del v44
                v52 = <float>v39
                v53 = (<float>1.000000) / v52
                v54 = libc.math.log(v53)
                v55 = len(v43)
                v56 = numpy.random.randint(0,v55)
                v57 = v43[v56]
                v58 = v55 - (<unsigned long long>1)
                v59 = numpy.empty(v58,dtype=numpy.int32)
                v60 = Mut1((<unsigned long long>0))
                while method3(v58, v60):
                    v62 = v60.v0
                    v63 = v56 <= v62
                    if v63:
                        v65 = v62 + (<unsigned long long>1)
                    else:
                        v65 = v62
                    v66 = v43[v65]
                    v59[v62] = v66
                    v67 = v62 + (<unsigned long long>1)
                    v60.v0 = v67
                del v43
                del v60
                v68 = <float>v55
                v69 = (<float>1.000000) / v68
                v70 = libc.math.log(v69)
                v71 = v70 + v54
                v72 = v12.v2
                v73 = US2_1(v41)
                v74 = UH0_0(v73, v33)
                del v73
                v75 = US2_1(v57)
                v76 = UH0_0(v75, v36)
                del v75
                v77 = US3_0()
                v78 = Closure0(v41, v57, v12, v59, v36, v37, v38, v33, v34, v35, v71)
                del v33; del v36; del v59
                v79 = UH1_0(v71, v71, v74, v34, v35, v76, v37, v38, v41, (<unsigned char>0), (<signed long>1), v57, (<unsigned char>1), (<signed long>1), v77, (<unsigned char>0), v72, v78)
                del v72; del v74; del v76; del v77; del v78
                v29[v32] = v79
                del v79
                v80 = v32 + (<unsigned long long>1)
                v30.v0 = v80
            del v30
            v81 = method12(v21, v20, v29)
            del v29
            print(numpy.sqrt(numpy.sum(numpy.square(v81))))
            del v81
            print(v21.weight,v21.bias,v21.weight.grad,v21.bias.grad)
            v22.step()
            v22.zero_grad(True)
            v82 = v28 + (<signed long>1)
            v26.v0 = v82
        del v26
        print('***')
        v83 = v25 + (<signed long>1)
        v23.v0 = v83
    del v12; del v19; del v20; del v21; del v22
