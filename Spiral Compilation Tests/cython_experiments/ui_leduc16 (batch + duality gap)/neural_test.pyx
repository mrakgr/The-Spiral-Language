import torch
import torch.distributions
import torch.optim
import numpy
cimport numpy
import nets
import copy
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
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef bint method0(Mut0 v0) except *:
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>20)
cdef bint method1(Mut0 v0) except *:
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>10)
cdef bint method2(Mut1 v0) except *:
    cdef unsigned long long v1
    v1 = v0.v0
    return v1 < (<unsigned long long>512)
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
cdef bint method25(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method12(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4):
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef list v11
    cdef unsigned long long v12
    cdef Mut1 v13
    cdef unsigned long long v15
    cdef UH1 v16
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
    cdef US3 v31
    cdef unsigned char v32
    cdef numpy.ndarray[signed long,ndim=1] v33
    cdef object v34
    cdef bint v35
    cdef float v36
    cdef float v37
    cdef UH0 v38
    cdef float v39
    cdef float v40
    cdef UH0 v41
    cdef float v42
    cdef float v43
    cdef US1 v44
    cdef unsigned char v45
    cdef signed long v46
    cdef US1 v47
    cdef unsigned char v48
    cdef signed long v49
    cdef US3 v50
    cdef float v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef bint v54
    cdef list v566
    cdef unsigned long long v55
    cdef object v56
    cdef unsigned long long v57
    cdef Mut1 v58
    cdef unsigned long long v60
    cdef float v61
    cdef float v62
    cdef UH0 v63
    cdef float v64
    cdef float v65
    cdef UH0 v66
    cdef float v67
    cdef float v68
    cdef US1 v69
    cdef unsigned char v70
    cdef signed long v71
    cdef US1 v72
    cdef unsigned char v73
    cdef signed long v74
    cdef US3 v75
    cdef unsigned char v76
    cdef numpy.ndarray[signed long,ndim=1] v77
    cdef Tuple1 tmp0
    cdef bint v78
    cdef UH0 v79
    cdef numpy.ndarray[object,ndim=1] v80
    cdef bint v81
    cdef signed long v82
    cdef unsigned long long v83
    cdef unsigned long long v84
    cdef US1 v85
    cdef numpy.ndarray[float,ndim=1] v86
    cdef bint v87
    cdef bint v89
    cdef unsigned long long v90
    cdef bint v91
    cdef bint v93
    cdef unsigned long long v94
    cdef unsigned long long v95
    cdef bint v96
    cdef Mut1 v97
    cdef unsigned long long v99
    cdef US1 v100
    cdef numpy.ndarray[signed long,ndim=1] v101
    cdef Tuple3 tmp1
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef unsigned long long v106
    cdef unsigned long long v107
    cdef bint v108
    cdef Mut1 v109
    cdef unsigned long long v111
    cdef US0 v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef unsigned long long v115
    cdef unsigned long long v116
    cdef unsigned long long v117
    cdef unsigned long long v118
    cdef unsigned long long v119
    cdef unsigned long long v120
    cdef numpy.ndarray[object,ndim=1] v121
    cdef Mut1 v122
    cdef unsigned long long v124
    cdef float v125
    cdef float v126
    cdef UH0 v127
    cdef float v128
    cdef float v129
    cdef UH0 v130
    cdef float v131
    cdef float v132
    cdef US1 v133
    cdef unsigned char v134
    cdef signed long v135
    cdef US1 v136
    cdef unsigned char v137
    cdef signed long v138
    cdef US3 v139
    cdef unsigned char v140
    cdef numpy.ndarray[signed long,ndim=1] v141
    cdef Tuple1 tmp2
    cdef unsigned long long v142
    cdef numpy.ndarray[signed long long,ndim=1] v143
    cdef Mut1 v144
    cdef unsigned long long v146
    cdef US0 v147
    cdef signed long long v148
    cdef unsigned long long v149
    cdef unsigned long long v150
    cdef object v151
    cdef object v152
    cdef unsigned long long v153
    cdef Mut1 v154
    cdef unsigned long long v156
    cdef numpy.ndarray[signed long long,ndim=1] v157
    cdef unsigned long long v158
    cdef Mut1 v159
    cdef unsigned long long v161
    cdef signed long long v162
    cdef unsigned long long v163
    cdef unsigned long long v164
    cdef object v165
    cdef object v166
    cdef object v167
    cdef Mut1 v168
    cdef unsigned long long v170
    cdef numpy.ndarray[signed long long,ndim=1] v171
    cdef unsigned long long v172
    cdef float v173
    cdef signed long long v174
    cdef unsigned long long v175
    cdef numpy.ndarray[signed long long,ndim=1] v176
    cdef unsigned long long v177
    cdef numpy.ndarray[object,ndim=1] v178
    cdef Mut1 v179
    cdef unsigned long long v181
    cdef signed long long v182
    cdef float v183
    cdef float v184
    cdef float v185
    cdef float v186
    cdef bint v187
    cdef US0 v204
    cdef bint v188
    cdef bint v189
    cdef bint v191
    cdef signed long long v192
    cdef bint v193
    cdef bint v194
    cdef bint v196
    cdef signed long long v197
    cdef bint v198
    cdef bint v199
    cdef unsigned long long v205
    cdef unsigned long long v206
    cdef object v207
    cdef unsigned long long v208
    cdef Mut1 v209
    cdef unsigned long long v211
    cdef float v212
    cdef float v213
    cdef UH0 v214
    cdef float v215
    cdef float v216
    cdef UH0 v217
    cdef float v218
    cdef float v219
    cdef US1 v220
    cdef unsigned char v221
    cdef signed long v222
    cdef US1 v223
    cdef unsigned char v224
    cdef signed long v225
    cdef US3 v226
    cdef unsigned char v227
    cdef numpy.ndarray[signed long,ndim=1] v228
    cdef Tuple1 tmp3
    cdef bint v229
    cdef UH0 v230
    cdef numpy.ndarray[object,ndim=1] v231
    cdef bint v232
    cdef signed long v233
    cdef unsigned long long v234
    cdef unsigned long long v235
    cdef US1 v236
    cdef numpy.ndarray[float,ndim=1] v237
    cdef bint v238
    cdef bint v240
    cdef unsigned long long v241
    cdef bint v242
    cdef bint v244
    cdef unsigned long long v245
    cdef unsigned long long v246
    cdef bint v247
    cdef Mut1 v248
    cdef unsigned long long v250
    cdef US1 v251
    cdef numpy.ndarray[signed long,ndim=1] v252
    cdef Tuple3 tmp4
    cdef unsigned long long v253
    cdef unsigned long long v254
    cdef unsigned long long v255
    cdef unsigned long long v256
    cdef unsigned long long v257
    cdef unsigned long long v258
    cdef bint v259
    cdef Mut1 v260
    cdef unsigned long long v262
    cdef US0 v263
    cdef unsigned long long v264
    cdef unsigned long long v265
    cdef unsigned long long v266
    cdef unsigned long long v267
    cdef unsigned long long v268
    cdef unsigned long long v269
    cdef unsigned long long v270
    cdef unsigned long long v271
    cdef numpy.ndarray[object,ndim=1] v272
    cdef Mut1 v273
    cdef unsigned long long v275
    cdef float v276
    cdef float v277
    cdef UH0 v278
    cdef float v279
    cdef float v280
    cdef UH0 v281
    cdef float v282
    cdef float v283
    cdef US1 v284
    cdef unsigned char v285
    cdef signed long v286
    cdef US1 v287
    cdef unsigned char v288
    cdef signed long v289
    cdef US3 v290
    cdef unsigned char v291
    cdef numpy.ndarray[signed long,ndim=1] v292
    cdef Tuple1 tmp5
    cdef unsigned long long v293
    cdef numpy.ndarray[signed long long,ndim=1] v294
    cdef Mut1 v295
    cdef unsigned long long v297
    cdef US0 v298
    cdef signed long long v299
    cdef unsigned long long v300
    cdef unsigned long long v301
    cdef object v302
    cdef object v303
    cdef unsigned long long v304
    cdef Mut1 v305
    cdef unsigned long long v307
    cdef numpy.ndarray[signed long long,ndim=1] v308
    cdef unsigned long long v309
    cdef Mut1 v310
    cdef unsigned long long v312
    cdef signed long long v313
    cdef unsigned long long v314
    cdef unsigned long long v315
    cdef object v316
    cdef object v317
    cdef object v318
    cdef Mut1 v319
    cdef unsigned long long v321
    cdef numpy.ndarray[signed long long,ndim=1] v322
    cdef unsigned long long v323
    cdef float v324
    cdef signed long long v325
    cdef unsigned long long v326
    cdef numpy.ndarray[signed long long,ndim=1] v327
    cdef unsigned long long v328
    cdef numpy.ndarray[object,ndim=1] v329
    cdef Mut1 v330
    cdef unsigned long long v332
    cdef signed long long v333
    cdef float v334
    cdef float v335
    cdef float v336
    cdef float v337
    cdef bint v338
    cdef US0 v355
    cdef bint v339
    cdef bint v340
    cdef bint v342
    cdef signed long long v343
    cdef bint v344
    cdef bint v345
    cdef bint v347
    cdef signed long long v348
    cdef bint v349
    cdef bint v350
    cdef unsigned long long v356
    cdef unsigned long long v357
    cdef unsigned long long v358
    cdef bint v359
    cdef bint v360
    cdef numpy.ndarray[object,ndim=1] v361
    cdef Mut1 v362
    cdef unsigned long long v364
    cdef object v365
    cdef float v366
    cdef float v367
    cdef US0 v368
    cdef Tuple0 tmp6
    cdef UH1 v369
    cdef unsigned long long v370
    cdef unsigned long long v371
    cdef unsigned long long v372
    cdef bint v373
    cdef bint v374
    cdef numpy.ndarray[object,ndim=1] v375
    cdef Mut1 v376
    cdef unsigned long long v378
    cdef object v379
    cdef float v380
    cdef float v381
    cdef US0 v382
    cdef Tuple0 tmp7
    cdef UH1 v383
    cdef unsigned long long v384
    cdef unsigned long long v385
    cdef unsigned long long v386
    cdef unsigned long long v387
    cdef numpy.ndarray[object,ndim=1] v388
    cdef Mut1 v389
    cdef unsigned long long v391
    cdef bint v392
    cdef UH1 v396
    cdef unsigned long long v394
    cdef unsigned long long v397
    cdef numpy.ndarray[float,ndim=1] v398
    cdef numpy.ndarray[float,ndim=1] v399
    cdef Mut1 v400
    cdef unsigned long long v402
    cdef float v403
    cdef unsigned long long v404
    cdef unsigned long long v405
    cdef bint v406
    cdef numpy.ndarray[float,ndim=1] v470
    cdef object v407
    cdef object v408
    cdef object v409
    cdef bint v410
    cdef bint v411
    cdef Mut1 v412
    cdef unsigned long long v414
    cdef signed long long v415
    cdef float v416
    cdef float v417
    cdef float v418
    cdef bint v419
    cdef float v420
    cdef float v421
    cdef float v422
    cdef UH0 v423
    cdef float v424
    cdef float v425
    cdef UH0 v426
    cdef float v427
    cdef float v428
    cdef US1 v429
    cdef unsigned char v430
    cdef signed long v431
    cdef US1 v432
    cdef unsigned char v433
    cdef signed long v434
    cdef US3 v435
    cdef unsigned char v436
    cdef numpy.ndarray[signed long,ndim=1] v437
    cdef Tuple1 tmp8
    cdef float v438
    cdef unsigned long long v439
    cdef object v440
    cdef unsigned long long v441
    cdef numpy.ndarray[float,ndim=1] v442
    cdef Mut1 v443
    cdef unsigned long long v445
    cdef float v446
    cdef float v447
    cdef UH0 v448
    cdef float v449
    cdef float v450
    cdef UH0 v451
    cdef float v452
    cdef float v453
    cdef US1 v454
    cdef unsigned char v455
    cdef signed long v456
    cdef US1 v457
    cdef unsigned char v458
    cdef signed long v459
    cdef US3 v460
    cdef unsigned char v461
    cdef numpy.ndarray[signed long,ndim=1] v462
    cdef Tuple1 tmp9
    cdef float v463
    cdef bint v464
    cdef float v465
    cdef float v466
    cdef unsigned long long v467
    cdef object v468
    cdef unsigned long long v471
    cdef unsigned long long v472
    cdef numpy.ndarray[float,ndim=1] v473
    cdef Mut1 v474
    cdef unsigned long long v476
    cdef unsigned long long v477
    cdef float v478
    cdef unsigned long long v479
    cdef unsigned long long v480
    cdef bint v481
    cdef numpy.ndarray[float,ndim=1] v545
    cdef object v482
    cdef object v483
    cdef object v484
    cdef bint v485
    cdef bint v486
    cdef Mut1 v487
    cdef unsigned long long v489
    cdef signed long long v490
    cdef float v491
    cdef float v492
    cdef float v493
    cdef bint v494
    cdef float v495
    cdef float v496
    cdef float v497
    cdef UH0 v498
    cdef float v499
    cdef float v500
    cdef UH0 v501
    cdef float v502
    cdef float v503
    cdef US1 v504
    cdef unsigned char v505
    cdef signed long v506
    cdef US1 v507
    cdef unsigned char v508
    cdef signed long v509
    cdef US3 v510
    cdef unsigned char v511
    cdef numpy.ndarray[signed long,ndim=1] v512
    cdef Tuple1 tmp10
    cdef float v513
    cdef unsigned long long v514
    cdef object v515
    cdef unsigned long long v516
    cdef numpy.ndarray[float,ndim=1] v517
    cdef Mut1 v518
    cdef unsigned long long v520
    cdef float v521
    cdef float v522
    cdef UH0 v523
    cdef float v524
    cdef float v525
    cdef UH0 v526
    cdef float v527
    cdef float v528
    cdef US1 v529
    cdef unsigned char v530
    cdef signed long v531
    cdef US1 v532
    cdef unsigned char v533
    cdef signed long v534
    cdef US3 v535
    cdef unsigned char v536
    cdef numpy.ndarray[signed long,ndim=1] v537
    cdef Tuple1 tmp11
    cdef float v538
    cdef bint v539
    cdef float v540
    cdef float v541
    cdef unsigned long long v542
    cdef object v543
    cdef unsigned long long v546
    cdef list v547
    cdef Mut2 v548
    cdef unsigned long long v550
    cdef unsigned long long v551
    cdef unsigned long long v552
    cdef unsigned char v553
    cdef bint v554
    cdef float v559
    cdef unsigned long long v560
    cdef unsigned long long v561
    cdef float v555
    cdef unsigned long long v556
    cdef float v557
    cdef unsigned long long v558
    cdef unsigned long long v562
    cdef unsigned long long v563
    cdef unsigned long long v564
    cdef numpy.ndarray[float,ndim=1] v567
    cdef unsigned long long v568
    cdef unsigned long long v569
    cdef bint v570
    cdef bint v571
    cdef Mut1 v572
    cdef unsigned long long v574
    cdef unsigned long long v575
    cdef float v576
    cdef unsigned long long v577
    cdef unsigned long long v578
    cdef Mut1 v579
    cdef unsigned long long v581
    cdef unsigned long long v582
    cdef float v583
    cdef float v584
    cdef UH0 v585
    cdef float v586
    cdef float v587
    cdef UH0 v588
    cdef float v589
    cdef float v590
    cdef US1 v591
    cdef unsigned char v592
    cdef signed long v593
    cdef US1 v594
    cdef unsigned char v595
    cdef signed long v596
    cdef US3 v597
    cdef float v598
    cdef Tuple2 tmp12
    cdef unsigned long long v599
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = [None]*(<unsigned long long>0)
    v12 = len(v4)
    v13 = Mut1((<unsigned long long>0))
    while method3(v12, v13):
        v15 = v13.v0
        v16 = v4[v15]
        if v16.tag == 0: # action_
            v17 = (<UH1_0>v16).v0; v18 = (<UH1_0>v16).v1; v19 = (<UH1_0>v16).v2; v20 = (<UH1_0>v16).v3; v21 = (<UH1_0>v16).v4; v22 = (<UH1_0>v16).v5; v23 = (<UH1_0>v16).v6; v24 = (<UH1_0>v16).v7; v25 = (<UH1_0>v16).v8; v26 = (<UH1_0>v16).v9; v27 = (<UH1_0>v16).v10; v28 = (<UH1_0>v16).v11; v29 = (<UH1_0>v16).v12; v30 = (<UH1_0>v16).v13; v31 = (<UH1_0>v16).v14; v32 = (<UH1_0>v16).v15; v33 = (<UH1_0>v16).v16; v34 = (<UH1_0>v16).v17
            v6.append(v15)
            v35 = v32 == (<unsigned char>0)
            if v35:
                v7.append(Tuple1(v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33))
                v9.append(v34)
            else:
                v8.append(Tuple1(v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33))
                v10.append(v34)
            del v19; del v22; del v31; del v33; del v34
            v11.append(v32)
        elif v16.tag == 1: # terminal_
            v36 = (<UH1_1>v16).v0; v37 = (<UH1_1>v16).v1; v38 = (<UH1_1>v16).v2; v39 = (<UH1_1>v16).v3; v40 = (<UH1_1>v16).v4; v41 = (<UH1_1>v16).v5; v42 = (<UH1_1>v16).v6; v43 = (<UH1_1>v16).v7; v44 = (<UH1_1>v16).v8; v45 = (<UH1_1>v16).v9; v46 = (<UH1_1>v16).v10; v47 = (<UH1_1>v16).v11; v48 = (<UH1_1>v16).v12; v49 = (<UH1_1>v16).v13; v50 = (<UH1_1>v16).v14; v51 = (<UH1_1>v16).v15
            v5.append(Tuple2(v15, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51))
            del v38; del v41; del v50
        del v16
        v52 = v15 + (<unsigned long long>1)
        v13.v0 = v52
    del v13
    v53 = len(v11)
    v54 = (<unsigned long long>0) < v53
    if v54:
        v55 = len(v7)
        v56 = torch.zeros(v55,(<unsigned long long>48))
        v57 = len(v7)
        v58 = Mut1((<unsigned long long>0))
        while method3(v57, v58):
            v60 = v58.v0
            tmp0 = v7[v60]
            v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
            del tmp0
            del v75; del v77
            v78 = v76 == (<unsigned char>0)
            if v78:
                v79 = v63
            else:
                v79 = v66
            del v63; del v66
            v80 = method13(v79)
            del v79
            v81 = v76 == v70
            if v81:
                v82 = v71
            else:
                v82 = v74
            v83 = v76
            v84 = v82
            if v81:
                v85 = v72
            else:
                v85 = v69
            v86 = v56[v60,:].numpy()
            v87 = (<unsigned long long>0) <= v83
            if v87:
                v89 = v83 < (<unsigned long long>2)
            else:
                v89 = 0
            if v89:
                v86[v83] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v90 = v84 - (<unsigned long long>1)
            v91 = (<unsigned long long>0) <= v90
            if v91:
                v93 = v90 < (<unsigned long long>13)
            else:
                v93 = 0
            if v93:
                v94 = (<unsigned long long>2) + v90
                v86[v94] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v95 = len(v80)
            v96 = (<unsigned long long>2) < v95
            if v96:
                raise Exception("The given array is too large.")
            else:
                pass
            v97 = Mut1((<unsigned long long>0))
            while method3(v95, v97):
                v99 = v97.v0
                tmp1 = v80[v99]
                v100, v101 = tmp1.v0, tmp1.v1
                del tmp1
                v102 = v99 * (<unsigned long long>15)
                v103 = (<unsigned long long>15) + v102
                if v100 == 0: # jack
                    v86[v103] = (<float>1.000000)
                elif v100 == 1: # king
                    v104 = v103 + (<unsigned long long>1)
                    v86[v104] = (<float>1.000000)
                elif v100 == 2: # queen
                    v105 = v103 + (<unsigned long long>2)
                    v86[v105] = (<float>1.000000)
                v106 = v103 + (<unsigned long long>3)
                v107 = len(v101)
                v108 = (<unsigned long long>4) < v107
                if v108:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v109 = Mut1((<unsigned long long>0))
                while method3(v107, v109):
                    v111 = v109.v0
                    v112 = v101[v111]
                    v113 = v111 * (<unsigned long long>3)
                    v114 = v106 + v113
                    if v112 == 0: # call
                        v86[v114] = (<float>1.000000)
                    elif v112 == 1: # fold
                        v115 = v114 + (<unsigned long long>1)
                        v86[v115] = (<float>1.000000)
                    elif v112 == 2: # raise
                        v116 = v114 + (<unsigned long long>2)
                        v86[v116] = (<float>1.000000)
                    v117 = v111 + (<unsigned long long>1)
                    v109.v0 = v117
                del v101
                del v109
                v118 = v99 + (<unsigned long long>1)
                v97.v0 = v118
            del v80
            del v97
            if v85 == 0: # jack
                v86[(<unsigned long long>45)] = (<float>1.000000)
            elif v85 == 1: # king
                v86[(<unsigned long long>46)] = (<float>1.000000)
            elif v85 == 2: # queen
                v86[(<unsigned long long>47)] = (<float>1.000000)
            del v86
            v119 = v60 + (<unsigned long long>1)
            v58.v0 = v119
        del v58
        v120 = len(v7)
        v121 = numpy.empty(v120,dtype=object)
        v122 = Mut1((<unsigned long long>0))
        while method3(v120, v122):
            v124 = v122.v0
            tmp2 = v7[v124]
            v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135, v136, v137, v138, v139, v140, v141 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16
            del tmp2
            del v127; del v130; del v139
            v142 = len(v141)
            v143 = numpy.empty(v142,dtype=numpy.int64)
            v144 = Mut1((<unsigned long long>0))
            while method3(v142, v144):
                v146 = v144.v0
                v147 = v141[v146]
                if v147 == 0: # call
                    v148 = (<signed long long>0)
                elif v147 == 1: # fold
                    v148 = (<signed long long>1)
                elif v147 == 2: # raise
                    v148 = (<signed long long>2)
                v143[v146] = v148
                v149 = v146 + (<unsigned long long>1)
                v144.v0 = v149
            del v141
            del v144
            v121[v124] = v143
            del v143
            v150 = v124 + (<unsigned long long>1)
            v122.v0 = v150
        del v122
        v151 = v1.forward(v56[:,:(<unsigned long long>45)])
        v152 = torch.full((v55,(<signed long long>3)),float('-inf'))
        v153 = len(v121)
        v154 = Mut1((<unsigned long long>0))
        while method3(v153, v154):
            v156 = v154.v0
            v157 = v121[v156]
            v158 = len(v157)
            v159 = Mut1((<unsigned long long>0))
            while method3(v158, v159):
                v161 = v159.v0
                v162 = v157[v161]
                v152[v156,v162] = 0
                v163 = v161 + (<unsigned long long>1)
                v159.v0 = v163
            del v157
            del v159
            v164 = v156 + (<unsigned long long>1)
            v154.v0 = v164
        del v154
        v165 = torch.log_softmax(v152 + v151.cpu(),dim=-1)
        del v151
        v166 = torch.exp(v165.detach())
        v167 = torch.empty_like(v166)
        v168 = Mut1((<unsigned long long>0))
        while method3(v153, v168):
            v170 = v168.v0
            v171 = v121[v170]
            v172 = len(v171)
            del v171
            v173 = <float>v172
            v174 = (<signed long long>0)
            method23(v152, v166, v167, v170, v173, v174)
            v175 = v170 + (<unsigned long long>1)
            v168.v0 = v175
        del v121; del v152
        del v168
        v176 = torch.distributions.Categorical(v167).sample().numpy()
        v177 = len(v176)
        v178 = numpy.empty(v177,dtype=object)
        v179 = Mut1((<unsigned long long>0))
        while method3(v177, v179):
            v181 = v179.v0
            v182 = v176[v181]
            v183 = v166[v181,v182]
            v184 = v167[v181,v182]
            v185 = libc.math.log(v184)
            v186 = libc.math.log(v183)
            v187 = v182 < (<signed long long>1)
            if v187:
                v188 = v182 == (<signed long long>0)
                v189 = v188 == 0
                if v189:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v204 = 0
            else:
                v191 = v182 < (<signed long long>2)
                if v191:
                    v192 = v182 - (<signed long long>1)
                    v193 = v192 == (<signed long long>0)
                    v194 = v193 == 0
                    if v194:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v204 = 1
                else:
                    v196 = v182 < (<signed long long>3)
                    if v196:
                        v197 = v182 - (<signed long long>2)
                        v198 = v197 == (<signed long long>0)
                        v199 = v198 == 0
                        if v199:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v204 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v178[v181] = Tuple0(v186, v185, v204)
            v205 = v181 + (<unsigned long long>1)
            v179.v0 = v205
        del v179
        v206 = len(v8)
        v207 = torch.zeros(v206,(<unsigned long long>48))
        v208 = len(v8)
        v209 = Mut1((<unsigned long long>0))
        while method3(v208, v209):
            v211 = v209.v0
            tmp3 = v8[v211]
            v212, v213, v214, v215, v216, v217, v218, v219, v220, v221, v222, v223, v224, v225, v226, v227, v228 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4, tmp3.v5, tmp3.v6, tmp3.v7, tmp3.v8, tmp3.v9, tmp3.v10, tmp3.v11, tmp3.v12, tmp3.v13, tmp3.v14, tmp3.v15, tmp3.v16
            del tmp3
            del v226; del v228
            v229 = v227 == (<unsigned char>0)
            if v229:
                v230 = v214
            else:
                v230 = v217
            del v214; del v217
            v231 = method13(v230)
            del v230
            v232 = v227 == v221
            if v232:
                v233 = v222
            else:
                v233 = v225
            v234 = v227
            v235 = v233
            if v232:
                v236 = v223
            else:
                v236 = v220
            v237 = v207[v211,:].numpy()
            v238 = (<unsigned long long>0) <= v234
            if v238:
                v240 = v234 < (<unsigned long long>2)
            else:
                v240 = 0
            if v240:
                v237[v234] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v241 = v235 - (<unsigned long long>1)
            v242 = (<unsigned long long>0) <= v241
            if v242:
                v244 = v241 < (<unsigned long long>13)
            else:
                v244 = 0
            if v244:
                v245 = (<unsigned long long>2) + v241
                v237[v245] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v246 = len(v231)
            v247 = (<unsigned long long>2) < v246
            if v247:
                raise Exception("The given array is too large.")
            else:
                pass
            v248 = Mut1((<unsigned long long>0))
            while method3(v246, v248):
                v250 = v248.v0
                tmp4 = v231[v250]
                v251, v252 = tmp4.v0, tmp4.v1
                del tmp4
                v253 = v250 * (<unsigned long long>15)
                v254 = (<unsigned long long>15) + v253
                if v251 == 0: # jack
                    v237[v254] = (<float>1.000000)
                elif v251 == 1: # king
                    v255 = v254 + (<unsigned long long>1)
                    v237[v255] = (<float>1.000000)
                elif v251 == 2: # queen
                    v256 = v254 + (<unsigned long long>2)
                    v237[v256] = (<float>1.000000)
                v257 = v254 + (<unsigned long long>3)
                v258 = len(v252)
                v259 = (<unsigned long long>4) < v258
                if v259:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v260 = Mut1((<unsigned long long>0))
                while method3(v258, v260):
                    v262 = v260.v0
                    v263 = v252[v262]
                    v264 = v262 * (<unsigned long long>3)
                    v265 = v257 + v264
                    if v263 == 0: # call
                        v237[v265] = (<float>1.000000)
                    elif v263 == 1: # fold
                        v266 = v265 + (<unsigned long long>1)
                        v237[v266] = (<float>1.000000)
                    elif v263 == 2: # raise
                        v267 = v265 + (<unsigned long long>2)
                        v237[v267] = (<float>1.000000)
                    v268 = v262 + (<unsigned long long>1)
                    v260.v0 = v268
                del v252
                del v260
                v269 = v250 + (<unsigned long long>1)
                v248.v0 = v269
            del v231
            del v248
            if v236 == 0: # jack
                v237[(<unsigned long long>45)] = (<float>1.000000)
            elif v236 == 1: # king
                v237[(<unsigned long long>46)] = (<float>1.000000)
            elif v236 == 2: # queen
                v237[(<unsigned long long>47)] = (<float>1.000000)
            del v237
            v270 = v211 + (<unsigned long long>1)
            v209.v0 = v270
        del v209
        v271 = len(v8)
        v272 = numpy.empty(v271,dtype=object)
        v273 = Mut1((<unsigned long long>0))
        while method3(v271, v273):
            v275 = v273.v0
            tmp5 = v8[v275]
            v276, v277, v278, v279, v280, v281, v282, v283, v284, v285, v286, v287, v288, v289, v290, v291, v292 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4, tmp5.v5, tmp5.v6, tmp5.v7, tmp5.v8, tmp5.v9, tmp5.v10, tmp5.v11, tmp5.v12, tmp5.v13, tmp5.v14, tmp5.v15, tmp5.v16
            del tmp5
            del v278; del v281; del v290
            v293 = len(v292)
            v294 = numpy.empty(v293,dtype=numpy.int64)
            v295 = Mut1((<unsigned long long>0))
            while method3(v293, v295):
                v297 = v295.v0
                v298 = v292[v297]
                if v298 == 0: # call
                    v299 = (<signed long long>0)
                elif v298 == 1: # fold
                    v299 = (<signed long long>1)
                elif v298 == 2: # raise
                    v299 = (<signed long long>2)
                v294[v297] = v299
                v300 = v297 + (<unsigned long long>1)
                v295.v0 = v300
            del v292
            del v295
            v272[v275] = v294
            del v294
            v301 = v275 + (<unsigned long long>1)
            v273.v0 = v301
        del v273
        v302 = v3.forward(v207[:,:(<unsigned long long>45)])
        v303 = torch.full((v206,(<signed long long>3)),float('-inf'))
        v304 = len(v272)
        v305 = Mut1((<unsigned long long>0))
        while method3(v304, v305):
            v307 = v305.v0
            v308 = v272[v307]
            v309 = len(v308)
            v310 = Mut1((<unsigned long long>0))
            while method3(v309, v310):
                v312 = v310.v0
                v313 = v308[v312]
                v303[v307,v313] = 0
                v314 = v312 + (<unsigned long long>1)
                v310.v0 = v314
            del v308
            del v310
            v315 = v307 + (<unsigned long long>1)
            v305.v0 = v315
        del v305
        v316 = torch.log_softmax(v303 + v302.cpu(),dim=-1)
        del v302
        v317 = torch.exp(v316.detach())
        v318 = torch.empty_like(v317)
        v319 = Mut1((<unsigned long long>0))
        while method3(v304, v319):
            v321 = v319.v0
            v322 = v272[v321]
            v323 = len(v322)
            del v322
            v324 = <float>v323
            v325 = (<signed long long>0)
            method23(v303, v317, v318, v321, v324, v325)
            v326 = v321 + (<unsigned long long>1)
            v319.v0 = v326
        del v272; del v303
        del v319
        v327 = torch.distributions.Categorical(v318).sample().numpy()
        v328 = len(v327)
        v329 = numpy.empty(v328,dtype=object)
        v330 = Mut1((<unsigned long long>0))
        while method3(v328, v330):
            v332 = v330.v0
            v333 = v327[v332]
            v334 = v317[v332,v333]
            v335 = v318[v332,v333]
            v336 = libc.math.log(v335)
            v337 = libc.math.log(v334)
            v338 = v333 < (<signed long long>1)
            if v338:
                v339 = v333 == (<signed long long>0)
                v340 = v339 == 0
                if v340:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v355 = 0
            else:
                v342 = v333 < (<signed long long>2)
                if v342:
                    v343 = v333 - (<signed long long>1)
                    v344 = v343 == (<signed long long>0)
                    v345 = v344 == 0
                    if v345:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v355 = 1
                else:
                    v347 = v333 < (<signed long long>3)
                    if v347:
                        v348 = v333 - (<signed long long>2)
                        v349 = v348 == (<signed long long>0)
                        v350 = v349 == 0
                        if v350:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v355 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v329[v332] = Tuple0(v337, v336, v355)
            v356 = v332 + (<unsigned long long>1)
            v330.v0 = v356
        del v330
        v357 = len(v9)
        v358 = len(v178)
        v359 = v357 == v358
        v360 = v359 == 0
        if v360:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v361 = numpy.empty(v357,dtype=object)
        v362 = Mut1((<unsigned long long>0))
        while method3(v357, v362):
            v364 = v362.v0
            v365 = v9[v364]
            tmp6 = v178[v364]
            v366, v367, v368 = tmp6.v0, tmp6.v1, tmp6.v2
            del tmp6
            v369 = v365(Tuple0(v366, v367, v368))
            del v365
            v361[v364] = v369
            del v369
            v370 = v364 + (<unsigned long long>1)
            v362.v0 = v370
        del v178
        del v362
        v371 = len(v10)
        v372 = len(v329)
        v373 = v371 == v372
        v374 = v373 == 0
        if v374:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v375 = numpy.empty(v371,dtype=object)
        v376 = Mut1((<unsigned long long>0))
        while method3(v371, v376):
            v378 = v376.v0
            v379 = v10[v378]
            tmp7 = v329[v378]
            v380, v381, v382 = tmp7.v0, tmp7.v1, tmp7.v2
            del tmp7
            v383 = v379(Tuple0(v380, v381, v382))
            del v379
            v375[v378] = v383
            del v383
            v384 = v378 + (<unsigned long long>1)
            v376.v0 = v384
        del v329
        del v376
        v385 = len(v361)
        v386 = len(v375)
        v387 = v385 + v386
        v388 = numpy.empty(v387,dtype=object)
        v389 = Mut1((<unsigned long long>0))
        while method3(v387, v389):
            v391 = v389.v0
            v392 = v391 < v385
            if v392:
                v396 = v361[v391]
            else:
                v394 = v391 - v385
                v396 = v375[v394]
            v388[v391] = v396
            del v396
            v397 = v391 + (<unsigned long long>1)
            v389.v0 = v397
        del v361; del v375
        del v389
        v398 = method12(v0, v1, v2, v3, v388)
        del v388
        v399 = numpy.empty(v358,dtype=numpy.float32)
        v400 = Mut1((<unsigned long long>0))
        while method3(v358, v400):
            v402 = v400.v0
            v403 = v398[v402]
            v399[v402] = v403
            v404 = v402 + (<unsigned long long>1)
            v400.v0 = v404
        del v400
        v405 = len(v399)
        v406 = v405 == (<unsigned long long>0)
        if v406:
            v470 = v399
        else:
            v407 = v0.forward(v56).cpu()
            v408 = v407.detach().clone()
            v409 = torch.zeros_like(v407)
            v410 = v177 == v405
            v411 = v410 == 0
            if v411:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v412 = Mut1((<unsigned long long>0))
            while method3(v177, v412):
                v414 = v412.v0
                v415 = v176[v414]
                v416 = v399[v414]
                v417 = v167[v414,v415]
                v418 = v408[v414,v415]
                v419 = libc.math.isnan(v418)
                if v419:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v420 = v416 - v418
                tmp8 = v7[v414]
                v421, v422, v423, v424, v425, v426, v427, v428, v429, v430, v431, v432, v433, v434, v435, v436, v437 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3, tmp8.v4, tmp8.v5, tmp8.v6, tmp8.v7, tmp8.v8, tmp8.v9, tmp8.v10, tmp8.v11, tmp8.v12, tmp8.v13, tmp8.v14, tmp8.v15, tmp8.v16
                del tmp8
                del v435; del v437
                v438 = method24(v436, v421, v422, v423, v424, v425, v426, v427, v428)
                del v423; del v426
                v409[v414,v415] -= v420 * v438
                v408[v414,v415] = v416
                v439 = v414 + (<unsigned long long>1)
                v412.v0 = v439
            del v412
            v407.backward(v409)
            del v407; del v409
            v440 = torch.einsum('ab,ab->a',v408,v166)
            v441 = len(v7)
            v442 = numpy.empty(v441,dtype=numpy.float32)
            v443 = Mut1((<unsigned long long>0))
            while method3(v441, v443):
                v445 = v443.v0
                tmp9 = v7[v445]
                v446, v447, v448, v449, v450, v451, v452, v453, v454, v455, v456, v457, v458, v459, v460, v461, v462 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3, tmp9.v4, tmp9.v5, tmp9.v6, tmp9.v7, tmp9.v8, tmp9.v9, tmp9.v10, tmp9.v11, tmp9.v12, tmp9.v13, tmp9.v14, tmp9.v15, tmp9.v16
                del tmp9
                del v460; del v462
                v463 = method24(v461, v446, v447, v448, v449, v450, v451, v452, v453)
                del v448; del v451
                v464 = v461 == (<unsigned char>0)
                if v464:
                    v465 = (<float>1.000000)
                else:
                    v465 = (<float>-1.000000)
                v466 = v463 * v465
                v442[v445] = v466
                v467 = v445 + (<unsigned long long>1)
                v443.v0 = v467
            del v443
            v468 = torch.from_numpy(v442)
            del v442
            v165.backward(v468.unsqueeze(-1) * (v440.unsqueeze(-1) - v408))
            del v408; del v468
            v470 = v440.numpy()
            del v440
        del v56; del v165; del v166; del v167; del v176; del v399
        v471 = len(v398)
        v472 = v471 - v358
        v473 = numpy.empty(v472,dtype=numpy.float32)
        v474 = Mut1((<unsigned long long>0))
        while method3(v472, v474):
            v476 = v474.v0
            v477 = v476 + v358
            v478 = v398[v477]
            v473[v476] = v478
            v479 = v476 + (<unsigned long long>1)
            v474.v0 = v479
        del v398
        del v474
        v480 = len(v473)
        v481 = v480 == (<unsigned long long>0)
        if v481:
            v545 = v473
        else:
            v482 = v2.forward(v207).cpu()
            v483 = v482.detach().clone()
            v484 = torch.zeros_like(v482)
            v485 = v328 == v480
            v486 = v485 == 0
            if v486:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v487 = Mut1((<unsigned long long>0))
            while method3(v328, v487):
                v489 = v487.v0
                v490 = v327[v489]
                v491 = v473[v489]
                v492 = v318[v489,v490]
                v493 = v483[v489,v490]
                v494 = libc.math.isnan(v493)
                if v494:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v495 = v491 - v493
                tmp10 = v8[v489]
                v496, v497, v498, v499, v500, v501, v502, v503, v504, v505, v506, v507, v508, v509, v510, v511, v512 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3, tmp10.v4, tmp10.v5, tmp10.v6, tmp10.v7, tmp10.v8, tmp10.v9, tmp10.v10, tmp10.v11, tmp10.v12, tmp10.v13, tmp10.v14, tmp10.v15, tmp10.v16
                del tmp10
                del v510; del v512
                v513 = method24(v511, v496, v497, v498, v499, v500, v501, v502, v503)
                del v498; del v501
                v484[v489,v490] -= v495 * v513
                v483[v489,v490] = v491
                v514 = v489 + (<unsigned long long>1)
                v487.v0 = v514
            del v487
            v482.backward(v484)
            del v482; del v484
            v515 = torch.einsum('ab,ab->a',v483,v317)
            v516 = len(v8)
            v517 = numpy.empty(v516,dtype=numpy.float32)
            v518 = Mut1((<unsigned long long>0))
            while method3(v516, v518):
                v520 = v518.v0
                tmp11 = v8[v520]
                v521, v522, v523, v524, v525, v526, v527, v528, v529, v530, v531, v532, v533, v534, v535, v536, v537 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3, tmp11.v4, tmp11.v5, tmp11.v6, tmp11.v7, tmp11.v8, tmp11.v9, tmp11.v10, tmp11.v11, tmp11.v12, tmp11.v13, tmp11.v14, tmp11.v15, tmp11.v16
                del tmp11
                del v535; del v537
                v538 = method24(v536, v521, v522, v523, v524, v525, v526, v527, v528)
                del v523; del v526
                v539 = v536 == (<unsigned char>0)
                if v539:
                    v540 = (<float>1.000000)
                else:
                    v540 = (<float>-1.000000)
                v541 = v538 * v540
                v517[v520] = v541
                v542 = v520 + (<unsigned long long>1)
                v518.v0 = v542
            del v518
            v543 = torch.from_numpy(v517)
            del v517
            v316.backward(v543.unsqueeze(-1) * (v515.unsqueeze(-1) - v483))
            del v483; del v543
            v545 = v515.numpy()
            del v515
        del v207; del v316; del v317; del v318; del v327; del v473
        v546 = len(v11)
        v547 = [None]*v546
        v548 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method25(v546, v548):
            v550 = v548.v0
            v551, v552 = v548.v1, v548.v2
            v553 = v11[v550]
            v554 = v553 == (<unsigned char>0)
            if v554:
                v555 = v470[v551]
                v556 = v551 + (<unsigned long long>1)
                v559, v560, v561 = v555, v556, v552
            else:
                v557 = v545[v552]
                v558 = v552 + (<unsigned long long>1)
                v559, v560, v561 = v557, v551, v558
            v547[v550] = v559
            v562 = v550 + (<unsigned long long>1)
            v548.v0 = v562
            v548.v1 = v560
            v548.v2 = v561
        del v470; del v545
        v563, v564 = v548.v1, v548.v2
        del v548
        v566 = v547
        del v547
    else:
        v566 = [None]*(<unsigned long long>0)
    del v7; del v8; del v9; del v10; del v11
    v567 = numpy.empty(v12,dtype=numpy.float32)
    v568 = len(v6)
    v569 = len(v566)
    v570 = v568 == v569
    v571 = v570 == 0
    if v571:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v572 = Mut1((<unsigned long long>0))
    while method3(v568, v572):
        v574 = v572.v0
        v575 = v6[v574]
        v576 = v566[v574]
        v567[v575] = v576
        v577 = v574 + (<unsigned long long>1)
        v572.v0 = v577
    del v6; del v566
    del v572
    v578 = len(v5)
    v579 = Mut1((<unsigned long long>0))
    while method3(v578, v579):
        v581 = v579.v0
        tmp12 = v5[v581]
        v582, v583, v584, v585, v586, v587, v588, v589, v590, v591, v592, v593, v594, v595, v596, v597, v598 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3, tmp12.v4, tmp12.v5, tmp12.v6, tmp12.v7, tmp12.v8, tmp12.v9, tmp12.v10, tmp12.v11, tmp12.v12, tmp12.v13, tmp12.v14, tmp12.v15, tmp12.v16
        del tmp12
        del v585; del v588; del v597
        v567[v582] = v598
        v599 = v581 + (<unsigned long long>1)
        v579.v0 = v599
    del v5
    del v579
    return v567
cdef bint method26(Mut1 v0) except *:
    cdef unsigned long long v1
    v1 = v0.v0
    return v1 < (<unsigned long long>5120)
cdef numpy.ndarray[float,ndim=1] method27(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut1 v11
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
    cdef US3 v29
    cdef unsigned char v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef object v32
    cdef bint v33
    cdef float v34
    cdef float v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef UH0 v39
    cdef float v40
    cdef float v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US3 v48
    cdef float v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef list v368
    cdef unsigned long long v53
    cdef list v54
    cdef Mut1 v55
    cdef unsigned long long v57
    cdef float v58
    cdef float v59
    cdef UH0 v60
    cdef float v61
    cdef float v62
    cdef UH0 v63
    cdef float v64
    cdef float v65
    cdef US1 v66
    cdef unsigned char v67
    cdef signed long v68
    cdef US1 v69
    cdef unsigned char v70
    cdef signed long v71
    cdef US3 v72
    cdef unsigned char v73
    cdef numpy.ndarray[signed long,ndim=1] v74
    cdef Tuple1 tmp13
    cdef unsigned long long v75
    cdef float v76
    cdef float v77
    cdef float v78
    cdef US0 v79
    cdef unsigned long long v80
    cdef unsigned long long v81
    cdef object v82
    cdef unsigned long long v83
    cdef Mut1 v84
    cdef unsigned long long v86
    cdef float v87
    cdef float v88
    cdef UH0 v89
    cdef float v90
    cdef float v91
    cdef UH0 v92
    cdef float v93
    cdef float v94
    cdef US1 v95
    cdef unsigned char v96
    cdef signed long v97
    cdef US1 v98
    cdef unsigned char v99
    cdef signed long v100
    cdef US3 v101
    cdef unsigned char v102
    cdef numpy.ndarray[signed long,ndim=1] v103
    cdef Tuple1 tmp14
    cdef bint v104
    cdef UH0 v105
    cdef numpy.ndarray[object,ndim=1] v106
    cdef bint v107
    cdef signed long v108
    cdef unsigned long long v109
    cdef unsigned long long v110
    cdef US1 v111
    cdef numpy.ndarray[float,ndim=1] v112
    cdef bint v113
    cdef bint v115
    cdef unsigned long long v116
    cdef bint v117
    cdef bint v119
    cdef unsigned long long v120
    cdef unsigned long long v121
    cdef bint v122
    cdef Mut1 v123
    cdef unsigned long long v125
    cdef US1 v126
    cdef numpy.ndarray[signed long,ndim=1] v127
    cdef Tuple3 tmp15
    cdef unsigned long long v128
    cdef unsigned long long v129
    cdef unsigned long long v130
    cdef unsigned long long v131
    cdef unsigned long long v132
    cdef unsigned long long v133
    cdef bint v134
    cdef Mut1 v135
    cdef unsigned long long v137
    cdef US0 v138
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef unsigned long long v141
    cdef unsigned long long v142
    cdef unsigned long long v143
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef numpy.ndarray[object,ndim=1] v147
    cdef Mut1 v148
    cdef unsigned long long v150
    cdef float v151
    cdef float v152
    cdef UH0 v153
    cdef float v154
    cdef float v155
    cdef UH0 v156
    cdef float v157
    cdef float v158
    cdef US1 v159
    cdef unsigned char v160
    cdef signed long v161
    cdef US1 v162
    cdef unsigned char v163
    cdef signed long v164
    cdef US3 v165
    cdef unsigned char v166
    cdef numpy.ndarray[signed long,ndim=1] v167
    cdef Tuple1 tmp16
    cdef unsigned long long v168
    cdef numpy.ndarray[signed long long,ndim=1] v169
    cdef Mut1 v170
    cdef unsigned long long v172
    cdef US0 v173
    cdef signed long long v174
    cdef unsigned long long v175
    cdef unsigned long long v176
    cdef object v177
    cdef object v178
    cdef unsigned long long v179
    cdef Mut1 v180
    cdef unsigned long long v182
    cdef numpy.ndarray[signed long long,ndim=1] v183
    cdef unsigned long long v184
    cdef Mut1 v185
    cdef unsigned long long v187
    cdef signed long long v188
    cdef unsigned long long v189
    cdef unsigned long long v190
    cdef object v191
    cdef object v192
    cdef numpy.ndarray[signed long long,ndim=1] v193
    cdef unsigned long long v194
    cdef numpy.ndarray[object,ndim=1] v195
    cdef Mut1 v196
    cdef unsigned long long v198
    cdef signed long long v199
    cdef float v200
    cdef float v201
    cdef float v202
    cdef float v203
    cdef bint v204
    cdef US0 v221
    cdef bint v205
    cdef bint v206
    cdef bint v208
    cdef signed long long v209
    cdef bint v210
    cdef bint v211
    cdef bint v213
    cdef signed long long v214
    cdef bint v215
    cdef bint v216
    cdef unsigned long long v222
    cdef unsigned long long v223
    cdef unsigned long long v224
    cdef bint v225
    cdef bint v226
    cdef numpy.ndarray[object,ndim=1] v227
    cdef Mut1 v228
    cdef unsigned long long v230
    cdef object v231
    cdef float v232
    cdef float v233
    cdef US0 v234
    cdef Tuple0 tmp17
    cdef UH1 v235
    cdef unsigned long long v236
    cdef unsigned long long v237
    cdef unsigned long long v238
    cdef bint v239
    cdef bint v240
    cdef numpy.ndarray[object,ndim=1] v241
    cdef Mut1 v242
    cdef unsigned long long v244
    cdef object v245
    cdef float v246
    cdef float v247
    cdef US0 v248
    cdef Tuple0 tmp18
    cdef UH1 v249
    cdef unsigned long long v250
    cdef unsigned long long v251
    cdef unsigned long long v252
    cdef unsigned long long v253
    cdef numpy.ndarray[object,ndim=1] v254
    cdef Mut1 v255
    cdef unsigned long long v257
    cdef bint v258
    cdef UH1 v262
    cdef unsigned long long v260
    cdef unsigned long long v263
    cdef numpy.ndarray[float,ndim=1] v264
    cdef unsigned long long v265
    cdef numpy.ndarray[float,ndim=1] v266
    cdef Mut1 v267
    cdef unsigned long long v269
    cdef float v270
    cdef unsigned long long v271
    cdef unsigned long long v272
    cdef unsigned long long v273
    cdef unsigned long long v274
    cdef numpy.ndarray[float,ndim=1] v275
    cdef Mut1 v276
    cdef unsigned long long v278
    cdef unsigned long long v279
    cdef float v280
    cdef unsigned long long v281
    cdef unsigned long long v282
    cdef bint v283
    cdef numpy.ndarray[float,ndim=1] v347
    cdef object v284
    cdef object v285
    cdef object v286
    cdef bint v287
    cdef bint v288
    cdef Mut1 v289
    cdef unsigned long long v291
    cdef signed long long v292
    cdef float v293
    cdef float v294
    cdef float v295
    cdef bint v296
    cdef float v297
    cdef float v298
    cdef float v299
    cdef UH0 v300
    cdef float v301
    cdef float v302
    cdef UH0 v303
    cdef float v304
    cdef float v305
    cdef US1 v306
    cdef unsigned char v307
    cdef signed long v308
    cdef US1 v309
    cdef unsigned char v310
    cdef signed long v311
    cdef US3 v312
    cdef unsigned char v313
    cdef numpy.ndarray[signed long,ndim=1] v314
    cdef Tuple1 tmp19
    cdef float v315
    cdef unsigned long long v316
    cdef object v317
    cdef unsigned long long v318
    cdef numpy.ndarray[float,ndim=1] v319
    cdef Mut1 v320
    cdef unsigned long long v322
    cdef float v323
    cdef float v324
    cdef UH0 v325
    cdef float v326
    cdef float v327
    cdef UH0 v328
    cdef float v329
    cdef float v330
    cdef US1 v331
    cdef unsigned char v332
    cdef signed long v333
    cdef US1 v334
    cdef unsigned char v335
    cdef signed long v336
    cdef US3 v337
    cdef unsigned char v338
    cdef numpy.ndarray[signed long,ndim=1] v339
    cdef Tuple1 tmp20
    cdef float v340
    cdef bint v341
    cdef float v342
    cdef float v343
    cdef unsigned long long v344
    cdef object v345
    cdef unsigned long long v348
    cdef list v349
    cdef Mut2 v350
    cdef unsigned long long v352
    cdef unsigned long long v353
    cdef unsigned long long v354
    cdef unsigned char v355
    cdef bint v356
    cdef float v361
    cdef unsigned long long v362
    cdef unsigned long long v363
    cdef float v357
    cdef unsigned long long v358
    cdef float v359
    cdef unsigned long long v360
    cdef unsigned long long v364
    cdef unsigned long long v365
    cdef unsigned long long v366
    cdef numpy.ndarray[float,ndim=1] v369
    cdef unsigned long long v370
    cdef unsigned long long v371
    cdef bint v372
    cdef bint v373
    cdef Mut1 v374
    cdef unsigned long long v376
    cdef unsigned long long v377
    cdef float v378
    cdef unsigned long long v379
    cdef unsigned long long v380
    cdef Mut1 v381
    cdef unsigned long long v383
    cdef unsigned long long v384
    cdef float v385
    cdef float v386
    cdef UH0 v387
    cdef float v388
    cdef float v389
    cdef UH0 v390
    cdef float v391
    cdef float v392
    cdef US1 v393
    cdef unsigned char v394
    cdef signed long v395
    cdef US1 v396
    cdef unsigned char v397
    cdef signed long v398
    cdef US3 v399
    cdef float v400
    cdef Tuple2 tmp21
    cdef unsigned long long v401
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v2)
    v11 = Mut1((<unsigned long long>0))
    while method3(v10, v11):
        v13 = v11.v0
        v14 = v2[v13]
        if v14.tag == 0: # action_
            v15 = (<UH1_0>v14).v0; v16 = (<UH1_0>v14).v1; v17 = (<UH1_0>v14).v2; v18 = (<UH1_0>v14).v3; v19 = (<UH1_0>v14).v4; v20 = (<UH1_0>v14).v5; v21 = (<UH1_0>v14).v6; v22 = (<UH1_0>v14).v7; v23 = (<UH1_0>v14).v8; v24 = (<UH1_0>v14).v9; v25 = (<UH1_0>v14).v10; v26 = (<UH1_0>v14).v11; v27 = (<UH1_0>v14).v12; v28 = (<UH1_0>v14).v13; v29 = (<UH1_0>v14).v14; v30 = (<UH1_0>v14).v15; v31 = (<UH1_0>v14).v16; v32 = (<UH1_0>v14).v17
            v4.append(v13)
            v33 = v30 == (<unsigned char>0)
            if v33:
                v5.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
                v7.append(v32)
            else:
                v6.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
                v8.append(v32)
            del v17; del v20; del v29; del v31; del v32
            v9.append(v30)
        elif v14.tag == 1: # terminal_
            v34 = (<UH1_1>v14).v0; v35 = (<UH1_1>v14).v1; v36 = (<UH1_1>v14).v2; v37 = (<UH1_1>v14).v3; v38 = (<UH1_1>v14).v4; v39 = (<UH1_1>v14).v5; v40 = (<UH1_1>v14).v6; v41 = (<UH1_1>v14).v7; v42 = (<UH1_1>v14).v8; v43 = (<UH1_1>v14).v9; v44 = (<UH1_1>v14).v10; v45 = (<UH1_1>v14).v11; v46 = (<UH1_1>v14).v12; v47 = (<UH1_1>v14).v13; v48 = (<UH1_1>v14).v14; v49 = (<UH1_1>v14).v15
            v3.append(Tuple2(v13, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49))
            del v36; del v39; del v48
        del v14
        v50 = v13 + (<unsigned long long>1)
        v11.v0 = v50
    del v11
    v51 = len(v9)
    v52 = (<unsigned long long>0) < v51
    if v52:
        v53 = len(v5)
        v54 = [None]*v53
        v55 = Mut1((<unsigned long long>0))
        while method3(v53, v55):
            v57 = v55.v0
            tmp13 = v5[v57]
            v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3, tmp13.v4, tmp13.v5, tmp13.v6, tmp13.v7, tmp13.v8, tmp13.v9, tmp13.v10, tmp13.v11, tmp13.v12, tmp13.v13, tmp13.v14, tmp13.v15, tmp13.v16
            del tmp13
            del v60; del v63; del v72
            v75 = len(v74)
            v76 = <float>v75
            v77 = (<float>1.000000) / v76
            v78 = libc.math.log(v77)
            v79 = numpy.random.choice(v74)
            del v74
            v54[v57] = Tuple0(v78, v78, v79)
            v80 = v57 + (<unsigned long long>1)
            v55.v0 = v80
        del v55
        v81 = len(v6)
        v82 = torch.zeros(v81,(<unsigned long long>48))
        v83 = len(v6)
        v84 = Mut1((<unsigned long long>0))
        while method3(v83, v84):
            v86 = v84.v0
            tmp14 = v6[v86]
            v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3, tmp14.v4, tmp14.v5, tmp14.v6, tmp14.v7, tmp14.v8, tmp14.v9, tmp14.v10, tmp14.v11, tmp14.v12, tmp14.v13, tmp14.v14, tmp14.v15, tmp14.v16
            del tmp14
            del v101; del v103
            v104 = v102 == (<unsigned char>0)
            if v104:
                v105 = v89
            else:
                v105 = v92
            del v89; del v92
            v106 = method13(v105)
            del v105
            v107 = v102 == v96
            if v107:
                v108 = v97
            else:
                v108 = v100
            v109 = v102
            v110 = v108
            if v107:
                v111 = v98
            else:
                v111 = v95
            v112 = v82[v86,:].numpy()
            v113 = (<unsigned long long>0) <= v109
            if v113:
                v115 = v109 < (<unsigned long long>2)
            else:
                v115 = 0
            if v115:
                v112[v109] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v116 = v110 - (<unsigned long long>1)
            v117 = (<unsigned long long>0) <= v116
            if v117:
                v119 = v116 < (<unsigned long long>13)
            else:
                v119 = 0
            if v119:
                v120 = (<unsigned long long>2) + v116
                v112[v120] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v121 = len(v106)
            v122 = (<unsigned long long>2) < v121
            if v122:
                raise Exception("The given array is too large.")
            else:
                pass
            v123 = Mut1((<unsigned long long>0))
            while method3(v121, v123):
                v125 = v123.v0
                tmp15 = v106[v125]
                v126, v127 = tmp15.v0, tmp15.v1
                del tmp15
                v128 = v125 * (<unsigned long long>15)
                v129 = (<unsigned long long>15) + v128
                if v126 == 0: # jack
                    v112[v129] = (<float>1.000000)
                elif v126 == 1: # king
                    v130 = v129 + (<unsigned long long>1)
                    v112[v130] = (<float>1.000000)
                elif v126 == 2: # queen
                    v131 = v129 + (<unsigned long long>2)
                    v112[v131] = (<float>1.000000)
                v132 = v129 + (<unsigned long long>3)
                v133 = len(v127)
                v134 = (<unsigned long long>4) < v133
                if v134:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v135 = Mut1((<unsigned long long>0))
                while method3(v133, v135):
                    v137 = v135.v0
                    v138 = v127[v137]
                    v139 = v137 * (<unsigned long long>3)
                    v140 = v132 + v139
                    if v138 == 0: # call
                        v112[v140] = (<float>1.000000)
                    elif v138 == 1: # fold
                        v141 = v140 + (<unsigned long long>1)
                        v112[v141] = (<float>1.000000)
                    elif v138 == 2: # raise
                        v142 = v140 + (<unsigned long long>2)
                        v112[v142] = (<float>1.000000)
                    v143 = v137 + (<unsigned long long>1)
                    v135.v0 = v143
                del v127
                del v135
                v144 = v125 + (<unsigned long long>1)
                v123.v0 = v144
            del v106
            del v123
            if v111 == 0: # jack
                v112[(<unsigned long long>45)] = (<float>1.000000)
            elif v111 == 1: # king
                v112[(<unsigned long long>46)] = (<float>1.000000)
            elif v111 == 2: # queen
                v112[(<unsigned long long>47)] = (<float>1.000000)
            del v112
            v145 = v86 + (<unsigned long long>1)
            v84.v0 = v145
        del v84
        v146 = len(v6)
        v147 = numpy.empty(v146,dtype=object)
        v148 = Mut1((<unsigned long long>0))
        while method3(v146, v148):
            v150 = v148.v0
            tmp16 = v6[v150]
            v151, v152, v153, v154, v155, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3, tmp16.v4, tmp16.v5, tmp16.v6, tmp16.v7, tmp16.v8, tmp16.v9, tmp16.v10, tmp16.v11, tmp16.v12, tmp16.v13, tmp16.v14, tmp16.v15, tmp16.v16
            del tmp16
            del v153; del v156; del v165
            v168 = len(v167)
            v169 = numpy.empty(v168,dtype=numpy.int64)
            v170 = Mut1((<unsigned long long>0))
            while method3(v168, v170):
                v172 = v170.v0
                v173 = v167[v172]
                if v173 == 0: # call
                    v174 = (<signed long long>0)
                elif v173 == 1: # fold
                    v174 = (<signed long long>1)
                elif v173 == 2: # raise
                    v174 = (<signed long long>2)
                v169[v172] = v174
                v175 = v172 + (<unsigned long long>1)
                v170.v0 = v175
            del v167
            del v170
            v147[v150] = v169
            del v169
            v176 = v150 + (<unsigned long long>1)
            v148.v0 = v176
        del v148
        v177 = v1.forward(v82[:,:(<unsigned long long>45)])
        v178 = torch.full((v81,(<signed long long>3)),float('-inf'))
        v179 = len(v147)
        v180 = Mut1((<unsigned long long>0))
        while method3(v179, v180):
            v182 = v180.v0
            v183 = v147[v182]
            v184 = len(v183)
            v185 = Mut1((<unsigned long long>0))
            while method3(v184, v185):
                v187 = v185.v0
                v188 = v183[v187]
                v178[v182,v188] = 0
                v189 = v187 + (<unsigned long long>1)
                v185.v0 = v189
            del v183
            del v185
            v190 = v182 + (<unsigned long long>1)
            v180.v0 = v190
        del v147
        del v180
        v191 = torch.log_softmax(v178 + v177.cpu(),dim=-1)
        del v177; del v178
        v192 = torch.exp(v191.detach())
        v193 = torch.distributions.Categorical(v192).sample().numpy()
        v194 = len(v193)
        v195 = numpy.empty(v194,dtype=object)
        v196 = Mut1((<unsigned long long>0))
        while method3(v194, v196):
            v198 = v196.v0
            v199 = v193[v198]
            v200 = v192[v198,v199]
            v201 = v192[v198,v199]
            v202 = libc.math.log(v201)
            v203 = libc.math.log(v200)
            v204 = v199 < (<signed long long>1)
            if v204:
                v205 = v199 == (<signed long long>0)
                v206 = v205 == 0
                if v206:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v221 = 0
            else:
                v208 = v199 < (<signed long long>2)
                if v208:
                    v209 = v199 - (<signed long long>1)
                    v210 = v209 == (<signed long long>0)
                    v211 = v210 == 0
                    if v211:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v221 = 1
                else:
                    v213 = v199 < (<signed long long>3)
                    if v213:
                        v214 = v199 - (<signed long long>2)
                        v215 = v214 == (<signed long long>0)
                        v216 = v215 == 0
                        if v216:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v221 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v195[v198] = Tuple0(v203, v202, v221)
            v222 = v198 + (<unsigned long long>1)
            v196.v0 = v222
        del v196
        v223 = len(v7)
        v224 = len(v54)
        v225 = v223 == v224
        v226 = v225 == 0
        if v226:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v227 = numpy.empty(v223,dtype=object)
        v228 = Mut1((<unsigned long long>0))
        while method3(v223, v228):
            v230 = v228.v0
            v231 = v7[v230]
            tmp17 = v54[v230]
            v232, v233, v234 = tmp17.v0, tmp17.v1, tmp17.v2
            del tmp17
            v235 = v231(Tuple0(v232, v233, v234))
            del v231
            v227[v230] = v235
            del v235
            v236 = v230 + (<unsigned long long>1)
            v228.v0 = v236
        del v228
        v237 = len(v8)
        v238 = len(v195)
        v239 = v237 == v238
        v240 = v239 == 0
        if v240:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v241 = numpy.empty(v237,dtype=object)
        v242 = Mut1((<unsigned long long>0))
        while method3(v237, v242):
            v244 = v242.v0
            v245 = v8[v244]
            tmp18 = v195[v244]
            v246, v247, v248 = tmp18.v0, tmp18.v1, tmp18.v2
            del tmp18
            v249 = v245(Tuple0(v246, v247, v248))
            del v245
            v241[v244] = v249
            del v249
            v250 = v244 + (<unsigned long long>1)
            v242.v0 = v250
        del v195
        del v242
        v251 = len(v227)
        v252 = len(v241)
        v253 = v251 + v252
        v254 = numpy.empty(v253,dtype=object)
        v255 = Mut1((<unsigned long long>0))
        while method3(v253, v255):
            v257 = v255.v0
            v258 = v257 < v251
            if v258:
                v262 = v227[v257]
            else:
                v260 = v257 - v251
                v262 = v241[v260]
            v254[v257] = v262
            del v262
            v263 = v257 + (<unsigned long long>1)
            v255.v0 = v263
        del v227; del v241
        del v255
        v264 = method27(v0, v1, v254)
        del v254
        v265 = len(v54)
        v266 = numpy.empty(v265,dtype=numpy.float32)
        v267 = Mut1((<unsigned long long>0))
        while method3(v265, v267):
            v269 = v267.v0
            v270 = v264[v269]
            v266[v269] = v270
            v271 = v269 + (<unsigned long long>1)
            v267.v0 = v271
        del v267
        v272 = len(v54)
        del v54
        v273 = len(v264)
        v274 = v273 - v272
        v275 = numpy.empty(v274,dtype=numpy.float32)
        v276 = Mut1((<unsigned long long>0))
        while method3(v274, v276):
            v278 = v276.v0
            v279 = v278 + v272
            v280 = v264[v279]
            v275[v278] = v280
            v281 = v278 + (<unsigned long long>1)
            v276.v0 = v281
        del v264
        del v276
        v282 = len(v275)
        v283 = v282 == (<unsigned long long>0)
        if v283:
            v347 = v275
        else:
            v284 = v0.forward(v82).cpu()
            v285 = v284.detach().clone()
            v286 = torch.zeros_like(v284)
            v287 = v194 == v282
            v288 = v287 == 0
            if v288:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v289 = Mut1((<unsigned long long>0))
            while method3(v194, v289):
                v291 = v289.v0
                v292 = v193[v291]
                v293 = v275[v291]
                v294 = v192[v291,v292]
                v295 = v285[v291,v292]
                v296 = libc.math.isnan(v295)
                if v296:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v297 = v293 - v295
                tmp19 = v6[v291]
                v298, v299, v300, v301, v302, v303, v304, v305, v306, v307, v308, v309, v310, v311, v312, v313, v314 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3, tmp19.v4, tmp19.v5, tmp19.v6, tmp19.v7, tmp19.v8, tmp19.v9, tmp19.v10, tmp19.v11, tmp19.v12, tmp19.v13, tmp19.v14, tmp19.v15, tmp19.v16
                del tmp19
                del v312; del v314
                v315 = method24(v313, v298, v299, v300, v301, v302, v303, v304, v305)
                del v300; del v303
                v286[v291,v292] -= v297 * v315
                v285[v291,v292] = v293
                v316 = v291 + (<unsigned long long>1)
                v289.v0 = v316
            del v289
            v284.backward(v286)
            del v284; del v286
            v317 = torch.einsum('ab,ab->a',v285,v192)
            v318 = len(v6)
            v319 = numpy.empty(v318,dtype=numpy.float32)
            v320 = Mut1((<unsigned long long>0))
            while method3(v318, v320):
                v322 = v320.v0
                tmp20 = v6[v322]
                v323, v324, v325, v326, v327, v328, v329, v330, v331, v332, v333, v334, v335, v336, v337, v338, v339 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4, tmp20.v5, tmp20.v6, tmp20.v7, tmp20.v8, tmp20.v9, tmp20.v10, tmp20.v11, tmp20.v12, tmp20.v13, tmp20.v14, tmp20.v15, tmp20.v16
                del tmp20
                del v337; del v339
                v340 = method24(v338, v323, v324, v325, v326, v327, v328, v329, v330)
                del v325; del v328
                v341 = v338 == (<unsigned char>0)
                if v341:
                    v342 = (<float>1.000000)
                else:
                    v342 = (<float>-1.000000)
                v343 = v340 * v342
                v319[v322] = v343
                v344 = v322 + (<unsigned long long>1)
                v320.v0 = v344
            del v320
            v345 = torch.from_numpy(v319)
            del v319
            v191.backward(v345.unsqueeze(-1) * (v317.unsqueeze(-1) - v285))
            del v285; del v345
            v347 = v317.numpy()
            del v317
        del v82; del v191; del v192; del v193; del v275
        v348 = len(v9)
        v349 = [None]*v348
        v350 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method25(v348, v350):
            v352 = v350.v0
            v353, v354 = v350.v1, v350.v2
            v355 = v9[v352]
            v356 = v355 == (<unsigned char>0)
            if v356:
                v357 = v266[v353]
                v358 = v353 + (<unsigned long long>1)
                v361, v362, v363 = v357, v358, v354
            else:
                v359 = v347[v354]
                v360 = v354 + (<unsigned long long>1)
                v361, v362, v363 = v359, v353, v360
            v349[v352] = v361
            v364 = v352 + (<unsigned long long>1)
            v350.v0 = v364
            v350.v1 = v362
            v350.v2 = v363
        del v266; del v347
        v365, v366 = v350.v1, v350.v2
        del v350
        v368 = v349
        del v349
    else:
        v368 = [None]*(<unsigned long long>0)
    del v5; del v6; del v7; del v8; del v9
    v369 = numpy.empty(v10,dtype=numpy.float32)
    v370 = len(v4)
    v371 = len(v368)
    v372 = v370 == v371
    v373 = v372 == 0
    if v373:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v374 = Mut1((<unsigned long long>0))
    while method3(v370, v374):
        v376 = v374.v0
        v377 = v4[v376]
        v378 = v368[v376]
        v369[v377] = v378
        v379 = v376 + (<unsigned long long>1)
        v374.v0 = v379
    del v4; del v368
    del v374
    v380 = len(v3)
    v381 = Mut1((<unsigned long long>0))
    while method3(v380, v381):
        v383 = v381.v0
        tmp21 = v3[v383]
        v384, v385, v386, v387, v388, v389, v390, v391, v392, v393, v394, v395, v396, v397, v398, v399, v400 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4, tmp21.v5, tmp21.v6, tmp21.v7, tmp21.v8, tmp21.v9, tmp21.v10, tmp21.v11, tmp21.v12, tmp21.v13, tmp21.v14, tmp21.v15, tmp21.v16
        del tmp21
        del v387; del v390; del v399
        v369[v384] = v400
        v401 = v383 + (<unsigned long long>1)
        v381.v0 = v401
    del v3
    del v381
    return v369
cdef numpy.ndarray[float,ndim=1] method28(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut1 v11
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
    cdef US3 v29
    cdef unsigned char v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef object v32
    cdef bint v33
    cdef float v34
    cdef float v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef UH0 v39
    cdef float v40
    cdef float v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US3 v48
    cdef float v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef list v366
    cdef unsigned long long v53
    cdef object v54
    cdef unsigned long long v55
    cdef Mut1 v56
    cdef unsigned long long v58
    cdef float v59
    cdef float v60
    cdef UH0 v61
    cdef float v62
    cdef float v63
    cdef UH0 v64
    cdef float v65
    cdef float v66
    cdef US1 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef US1 v70
    cdef unsigned char v71
    cdef signed long v72
    cdef US3 v73
    cdef unsigned char v74
    cdef numpy.ndarray[signed long,ndim=1] v75
    cdef Tuple1 tmp22
    cdef bint v76
    cdef UH0 v77
    cdef numpy.ndarray[object,ndim=1] v78
    cdef bint v79
    cdef signed long v80
    cdef unsigned long long v81
    cdef unsigned long long v82
    cdef US1 v83
    cdef numpy.ndarray[float,ndim=1] v84
    cdef bint v85
    cdef bint v87
    cdef unsigned long long v88
    cdef bint v89
    cdef bint v91
    cdef unsigned long long v92
    cdef unsigned long long v93
    cdef bint v94
    cdef Mut1 v95
    cdef unsigned long long v97
    cdef US1 v98
    cdef numpy.ndarray[signed long,ndim=1] v99
    cdef Tuple3 tmp23
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef bint v106
    cdef Mut1 v107
    cdef unsigned long long v109
    cdef US0 v110
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef unsigned long long v115
    cdef unsigned long long v116
    cdef unsigned long long v117
    cdef unsigned long long v118
    cdef numpy.ndarray[object,ndim=1] v119
    cdef Mut1 v120
    cdef unsigned long long v122
    cdef float v123
    cdef float v124
    cdef UH0 v125
    cdef float v126
    cdef float v127
    cdef UH0 v128
    cdef float v129
    cdef float v130
    cdef US1 v131
    cdef unsigned char v132
    cdef signed long v133
    cdef US1 v134
    cdef unsigned char v135
    cdef signed long v136
    cdef US3 v137
    cdef unsigned char v138
    cdef numpy.ndarray[signed long,ndim=1] v139
    cdef Tuple1 tmp24
    cdef unsigned long long v140
    cdef numpy.ndarray[signed long long,ndim=1] v141
    cdef Mut1 v142
    cdef unsigned long long v144
    cdef US0 v145
    cdef signed long long v146
    cdef unsigned long long v147
    cdef unsigned long long v148
    cdef object v149
    cdef object v150
    cdef unsigned long long v151
    cdef Mut1 v152
    cdef unsigned long long v154
    cdef numpy.ndarray[signed long long,ndim=1] v155
    cdef unsigned long long v156
    cdef Mut1 v157
    cdef unsigned long long v159
    cdef signed long long v160
    cdef unsigned long long v161
    cdef unsigned long long v162
    cdef object v163
    cdef object v164
    cdef numpy.ndarray[signed long long,ndim=1] v165
    cdef unsigned long long v166
    cdef numpy.ndarray[object,ndim=1] v167
    cdef Mut1 v168
    cdef unsigned long long v170
    cdef signed long long v171
    cdef float v172
    cdef float v173
    cdef float v174
    cdef float v175
    cdef bint v176
    cdef US0 v193
    cdef bint v177
    cdef bint v178
    cdef bint v180
    cdef signed long long v181
    cdef bint v182
    cdef bint v183
    cdef bint v185
    cdef signed long long v186
    cdef bint v187
    cdef bint v188
    cdef unsigned long long v194
    cdef unsigned long long v195
    cdef list v196
    cdef Mut1 v197
    cdef unsigned long long v199
    cdef float v200
    cdef float v201
    cdef UH0 v202
    cdef float v203
    cdef float v204
    cdef UH0 v205
    cdef float v206
    cdef float v207
    cdef US1 v208
    cdef unsigned char v209
    cdef signed long v210
    cdef US1 v211
    cdef unsigned char v212
    cdef signed long v213
    cdef US3 v214
    cdef unsigned char v215
    cdef numpy.ndarray[signed long,ndim=1] v216
    cdef Tuple1 tmp25
    cdef unsigned long long v217
    cdef float v218
    cdef float v219
    cdef float v220
    cdef US0 v221
    cdef unsigned long long v222
    cdef unsigned long long v223
    cdef unsigned long long v224
    cdef bint v225
    cdef bint v226
    cdef numpy.ndarray[object,ndim=1] v227
    cdef Mut1 v228
    cdef unsigned long long v230
    cdef object v231
    cdef float v232
    cdef float v233
    cdef US0 v234
    cdef Tuple0 tmp26
    cdef UH1 v235
    cdef unsigned long long v236
    cdef unsigned long long v237
    cdef unsigned long long v238
    cdef bint v239
    cdef bint v240
    cdef numpy.ndarray[object,ndim=1] v241
    cdef Mut1 v242
    cdef unsigned long long v244
    cdef object v245
    cdef float v246
    cdef float v247
    cdef US0 v248
    cdef Tuple0 tmp27
    cdef UH1 v249
    cdef unsigned long long v250
    cdef unsigned long long v251
    cdef unsigned long long v252
    cdef unsigned long long v253
    cdef numpy.ndarray[object,ndim=1] v254
    cdef Mut1 v255
    cdef unsigned long long v257
    cdef bint v258
    cdef UH1 v262
    cdef unsigned long long v260
    cdef unsigned long long v263
    cdef numpy.ndarray[float,ndim=1] v264
    cdef numpy.ndarray[float,ndim=1] v265
    cdef Mut1 v266
    cdef unsigned long long v268
    cdef float v269
    cdef unsigned long long v270
    cdef unsigned long long v271
    cdef bint v272
    cdef numpy.ndarray[float,ndim=1] v336
    cdef object v273
    cdef object v274
    cdef object v275
    cdef bint v276
    cdef bint v277
    cdef Mut1 v278
    cdef unsigned long long v280
    cdef signed long long v281
    cdef float v282
    cdef float v283
    cdef float v284
    cdef bint v285
    cdef float v286
    cdef float v287
    cdef float v288
    cdef UH0 v289
    cdef float v290
    cdef float v291
    cdef UH0 v292
    cdef float v293
    cdef float v294
    cdef US1 v295
    cdef unsigned char v296
    cdef signed long v297
    cdef US1 v298
    cdef unsigned char v299
    cdef signed long v300
    cdef US3 v301
    cdef unsigned char v302
    cdef numpy.ndarray[signed long,ndim=1] v303
    cdef Tuple1 tmp28
    cdef float v304
    cdef unsigned long long v305
    cdef object v306
    cdef unsigned long long v307
    cdef numpy.ndarray[float,ndim=1] v308
    cdef Mut1 v309
    cdef unsigned long long v311
    cdef float v312
    cdef float v313
    cdef UH0 v314
    cdef float v315
    cdef float v316
    cdef UH0 v317
    cdef float v318
    cdef float v319
    cdef US1 v320
    cdef unsigned char v321
    cdef signed long v322
    cdef US1 v323
    cdef unsigned char v324
    cdef signed long v325
    cdef US3 v326
    cdef unsigned char v327
    cdef numpy.ndarray[signed long,ndim=1] v328
    cdef Tuple1 tmp29
    cdef float v329
    cdef bint v330
    cdef float v331
    cdef float v332
    cdef unsigned long long v333
    cdef object v334
    cdef unsigned long long v337
    cdef unsigned long long v338
    cdef numpy.ndarray[float,ndim=1] v339
    cdef Mut1 v340
    cdef unsigned long long v342
    cdef unsigned long long v343
    cdef float v344
    cdef unsigned long long v345
    cdef unsigned long long v346
    cdef list v347
    cdef Mut2 v348
    cdef unsigned long long v350
    cdef unsigned long long v351
    cdef unsigned long long v352
    cdef unsigned char v353
    cdef bint v354
    cdef float v359
    cdef unsigned long long v360
    cdef unsigned long long v361
    cdef float v355
    cdef unsigned long long v356
    cdef float v357
    cdef unsigned long long v358
    cdef unsigned long long v362
    cdef unsigned long long v363
    cdef unsigned long long v364
    cdef numpy.ndarray[float,ndim=1] v367
    cdef unsigned long long v368
    cdef unsigned long long v369
    cdef bint v370
    cdef bint v371
    cdef Mut1 v372
    cdef unsigned long long v374
    cdef unsigned long long v375
    cdef float v376
    cdef unsigned long long v377
    cdef unsigned long long v378
    cdef Mut1 v379
    cdef unsigned long long v381
    cdef unsigned long long v382
    cdef float v383
    cdef float v384
    cdef UH0 v385
    cdef float v386
    cdef float v387
    cdef UH0 v388
    cdef float v389
    cdef float v390
    cdef US1 v391
    cdef unsigned char v392
    cdef signed long v393
    cdef US1 v394
    cdef unsigned char v395
    cdef signed long v396
    cdef US3 v397
    cdef float v398
    cdef Tuple2 tmp30
    cdef unsigned long long v399
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v2)
    v11 = Mut1((<unsigned long long>0))
    while method3(v10, v11):
        v13 = v11.v0
        v14 = v2[v13]
        if v14.tag == 0: # action_
            v15 = (<UH1_0>v14).v0; v16 = (<UH1_0>v14).v1; v17 = (<UH1_0>v14).v2; v18 = (<UH1_0>v14).v3; v19 = (<UH1_0>v14).v4; v20 = (<UH1_0>v14).v5; v21 = (<UH1_0>v14).v6; v22 = (<UH1_0>v14).v7; v23 = (<UH1_0>v14).v8; v24 = (<UH1_0>v14).v9; v25 = (<UH1_0>v14).v10; v26 = (<UH1_0>v14).v11; v27 = (<UH1_0>v14).v12; v28 = (<UH1_0>v14).v13; v29 = (<UH1_0>v14).v14; v30 = (<UH1_0>v14).v15; v31 = (<UH1_0>v14).v16; v32 = (<UH1_0>v14).v17
            v4.append(v13)
            v33 = v30 == (<unsigned char>0)
            if v33:
                v5.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
                v7.append(v32)
            else:
                v6.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
                v8.append(v32)
            del v17; del v20; del v29; del v31; del v32
            v9.append(v30)
        elif v14.tag == 1: # terminal_
            v34 = (<UH1_1>v14).v0; v35 = (<UH1_1>v14).v1; v36 = (<UH1_1>v14).v2; v37 = (<UH1_1>v14).v3; v38 = (<UH1_1>v14).v4; v39 = (<UH1_1>v14).v5; v40 = (<UH1_1>v14).v6; v41 = (<UH1_1>v14).v7; v42 = (<UH1_1>v14).v8; v43 = (<UH1_1>v14).v9; v44 = (<UH1_1>v14).v10; v45 = (<UH1_1>v14).v11; v46 = (<UH1_1>v14).v12; v47 = (<UH1_1>v14).v13; v48 = (<UH1_1>v14).v14; v49 = (<UH1_1>v14).v15
            v3.append(Tuple2(v13, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49))
            del v36; del v39; del v48
        del v14
        v50 = v13 + (<unsigned long long>1)
        v11.v0 = v50
    del v11
    v51 = len(v9)
    v52 = (<unsigned long long>0) < v51
    if v52:
        v53 = len(v5)
        v54 = torch.zeros(v53,(<unsigned long long>48))
        v55 = len(v5)
        v56 = Mut1((<unsigned long long>0))
        while method3(v55, v56):
            v58 = v56.v0
            tmp22 = v5[v58]
            v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5, tmp22.v6, tmp22.v7, tmp22.v8, tmp22.v9, tmp22.v10, tmp22.v11, tmp22.v12, tmp22.v13, tmp22.v14, tmp22.v15, tmp22.v16
            del tmp22
            del v73; del v75
            v76 = v74 == (<unsigned char>0)
            if v76:
                v77 = v61
            else:
                v77 = v64
            del v61; del v64
            v78 = method13(v77)
            del v77
            v79 = v74 == v68
            if v79:
                v80 = v69
            else:
                v80 = v72
            v81 = v74
            v82 = v80
            if v79:
                v83 = v70
            else:
                v83 = v67
            v84 = v54[v58,:].numpy()
            v85 = (<unsigned long long>0) <= v81
            if v85:
                v87 = v81 < (<unsigned long long>2)
            else:
                v87 = 0
            if v87:
                v84[v81] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v88 = v82 - (<unsigned long long>1)
            v89 = (<unsigned long long>0) <= v88
            if v89:
                v91 = v88 < (<unsigned long long>13)
            else:
                v91 = 0
            if v91:
                v92 = (<unsigned long long>2) + v88
                v84[v92] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v93 = len(v78)
            v94 = (<unsigned long long>2) < v93
            if v94:
                raise Exception("The given array is too large.")
            else:
                pass
            v95 = Mut1((<unsigned long long>0))
            while method3(v93, v95):
                v97 = v95.v0
                tmp23 = v78[v97]
                v98, v99 = tmp23.v0, tmp23.v1
                del tmp23
                v100 = v97 * (<unsigned long long>15)
                v101 = (<unsigned long long>15) + v100
                if v98 == 0: # jack
                    v84[v101] = (<float>1.000000)
                elif v98 == 1: # king
                    v102 = v101 + (<unsigned long long>1)
                    v84[v102] = (<float>1.000000)
                elif v98 == 2: # queen
                    v103 = v101 + (<unsigned long long>2)
                    v84[v103] = (<float>1.000000)
                v104 = v101 + (<unsigned long long>3)
                v105 = len(v99)
                v106 = (<unsigned long long>4) < v105
                if v106:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v107 = Mut1((<unsigned long long>0))
                while method3(v105, v107):
                    v109 = v107.v0
                    v110 = v99[v109]
                    v111 = v109 * (<unsigned long long>3)
                    v112 = v104 + v111
                    if v110 == 0: # call
                        v84[v112] = (<float>1.000000)
                    elif v110 == 1: # fold
                        v113 = v112 + (<unsigned long long>1)
                        v84[v113] = (<float>1.000000)
                    elif v110 == 2: # raise
                        v114 = v112 + (<unsigned long long>2)
                        v84[v114] = (<float>1.000000)
                    v115 = v109 + (<unsigned long long>1)
                    v107.v0 = v115
                del v99
                del v107
                v116 = v97 + (<unsigned long long>1)
                v95.v0 = v116
            del v78
            del v95
            if v83 == 0: # jack
                v84[(<unsigned long long>45)] = (<float>1.000000)
            elif v83 == 1: # king
                v84[(<unsigned long long>46)] = (<float>1.000000)
            elif v83 == 2: # queen
                v84[(<unsigned long long>47)] = (<float>1.000000)
            del v84
            v117 = v58 + (<unsigned long long>1)
            v56.v0 = v117
        del v56
        v118 = len(v5)
        v119 = numpy.empty(v118,dtype=object)
        v120 = Mut1((<unsigned long long>0))
        while method3(v118, v120):
            v122 = v120.v0
            tmp24 = v5[v122]
            v123, v124, v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135, v136, v137, v138, v139 = tmp24.v0, tmp24.v1, tmp24.v2, tmp24.v3, tmp24.v4, tmp24.v5, tmp24.v6, tmp24.v7, tmp24.v8, tmp24.v9, tmp24.v10, tmp24.v11, tmp24.v12, tmp24.v13, tmp24.v14, tmp24.v15, tmp24.v16
            del tmp24
            del v125; del v128; del v137
            v140 = len(v139)
            v141 = numpy.empty(v140,dtype=numpy.int64)
            v142 = Mut1((<unsigned long long>0))
            while method3(v140, v142):
                v144 = v142.v0
                v145 = v139[v144]
                if v145 == 0: # call
                    v146 = (<signed long long>0)
                elif v145 == 1: # fold
                    v146 = (<signed long long>1)
                elif v145 == 2: # raise
                    v146 = (<signed long long>2)
                v141[v144] = v146
                v147 = v144 + (<unsigned long long>1)
                v142.v0 = v147
            del v139
            del v142
            v119[v122] = v141
            del v141
            v148 = v122 + (<unsigned long long>1)
            v120.v0 = v148
        del v120
        v149 = v1.forward(v54[:,:(<unsigned long long>45)])
        v150 = torch.full((v53,(<signed long long>3)),float('-inf'))
        v151 = len(v119)
        v152 = Mut1((<unsigned long long>0))
        while method3(v151, v152):
            v154 = v152.v0
            v155 = v119[v154]
            v156 = len(v155)
            v157 = Mut1((<unsigned long long>0))
            while method3(v156, v157):
                v159 = v157.v0
                v160 = v155[v159]
                v150[v154,v160] = 0
                v161 = v159 + (<unsigned long long>1)
                v157.v0 = v161
            del v155
            del v157
            v162 = v154 + (<unsigned long long>1)
            v152.v0 = v162
        del v119
        del v152
        v163 = torch.log_softmax(v150 + v149.cpu(),dim=-1)
        del v149; del v150
        v164 = torch.exp(v163.detach())
        v165 = torch.distributions.Categorical(v164).sample().numpy()
        v166 = len(v165)
        v167 = numpy.empty(v166,dtype=object)
        v168 = Mut1((<unsigned long long>0))
        while method3(v166, v168):
            v170 = v168.v0
            v171 = v165[v170]
            v172 = v164[v170,v171]
            v173 = v164[v170,v171]
            v174 = libc.math.log(v173)
            v175 = libc.math.log(v172)
            v176 = v171 < (<signed long long>1)
            if v176:
                v177 = v171 == (<signed long long>0)
                v178 = v177 == 0
                if v178:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v193 = 0
            else:
                v180 = v171 < (<signed long long>2)
                if v180:
                    v181 = v171 - (<signed long long>1)
                    v182 = v181 == (<signed long long>0)
                    v183 = v182 == 0
                    if v183:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v193 = 1
                else:
                    v185 = v171 < (<signed long long>3)
                    if v185:
                        v186 = v171 - (<signed long long>2)
                        v187 = v186 == (<signed long long>0)
                        v188 = v187 == 0
                        if v188:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v193 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v167[v170] = Tuple0(v175, v174, v193)
            v194 = v170 + (<unsigned long long>1)
            v168.v0 = v194
        del v168
        v195 = len(v6)
        v196 = [None]*v195
        v197 = Mut1((<unsigned long long>0))
        while method3(v195, v197):
            v199 = v197.v0
            tmp25 = v6[v199]
            v200, v201, v202, v203, v204, v205, v206, v207, v208, v209, v210, v211, v212, v213, v214, v215, v216 = tmp25.v0, tmp25.v1, tmp25.v2, tmp25.v3, tmp25.v4, tmp25.v5, tmp25.v6, tmp25.v7, tmp25.v8, tmp25.v9, tmp25.v10, tmp25.v11, tmp25.v12, tmp25.v13, tmp25.v14, tmp25.v15, tmp25.v16
            del tmp25
            del v202; del v205; del v214
            v217 = len(v216)
            v218 = <float>v217
            v219 = (<float>1.000000) / v218
            v220 = libc.math.log(v219)
            v221 = numpy.random.choice(v216)
            del v216
            v196[v199] = Tuple0(v220, v220, v221)
            v222 = v199 + (<unsigned long long>1)
            v197.v0 = v222
        del v197
        v223 = len(v7)
        v224 = len(v167)
        v225 = v223 == v224
        v226 = v225 == 0
        if v226:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v227 = numpy.empty(v223,dtype=object)
        v228 = Mut1((<unsigned long long>0))
        while method3(v223, v228):
            v230 = v228.v0
            v231 = v7[v230]
            tmp26 = v167[v230]
            v232, v233, v234 = tmp26.v0, tmp26.v1, tmp26.v2
            del tmp26
            v235 = v231(Tuple0(v232, v233, v234))
            del v231
            v227[v230] = v235
            del v235
            v236 = v230 + (<unsigned long long>1)
            v228.v0 = v236
        del v167
        del v228
        v237 = len(v8)
        v238 = len(v196)
        v239 = v237 == v238
        v240 = v239 == 0
        if v240:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v241 = numpy.empty(v237,dtype=object)
        v242 = Mut1((<unsigned long long>0))
        while method3(v237, v242):
            v244 = v242.v0
            v245 = v8[v244]
            tmp27 = v196[v244]
            v246, v247, v248 = tmp27.v0, tmp27.v1, tmp27.v2
            del tmp27
            v249 = v245(Tuple0(v246, v247, v248))
            del v245
            v241[v244] = v249
            del v249
            v250 = v244 + (<unsigned long long>1)
            v242.v0 = v250
        del v196
        del v242
        v251 = len(v227)
        v252 = len(v241)
        v253 = v251 + v252
        v254 = numpy.empty(v253,dtype=object)
        v255 = Mut1((<unsigned long long>0))
        while method3(v253, v255):
            v257 = v255.v0
            v258 = v257 < v251
            if v258:
                v262 = v227[v257]
            else:
                v260 = v257 - v251
                v262 = v241[v260]
            v254[v257] = v262
            del v262
            v263 = v257 + (<unsigned long long>1)
            v255.v0 = v263
        del v227; del v241
        del v255
        v264 = method28(v0, v1, v254)
        del v254
        v265 = numpy.empty(v224,dtype=numpy.float32)
        v266 = Mut1((<unsigned long long>0))
        while method3(v224, v266):
            v268 = v266.v0
            v269 = v264[v268]
            v265[v268] = v269
            v270 = v268 + (<unsigned long long>1)
            v266.v0 = v270
        del v266
        v271 = len(v265)
        v272 = v271 == (<unsigned long long>0)
        if v272:
            v336 = v265
        else:
            v273 = v0.forward(v54).cpu()
            v274 = v273.detach().clone()
            v275 = torch.zeros_like(v273)
            v276 = v166 == v271
            v277 = v276 == 0
            if v277:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v278 = Mut1((<unsigned long long>0))
            while method3(v166, v278):
                v280 = v278.v0
                v281 = v165[v280]
                v282 = v265[v280]
                v283 = v164[v280,v281]
                v284 = v274[v280,v281]
                v285 = libc.math.isnan(v284)
                if v285:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v286 = v282 - v284
                tmp28 = v5[v280]
                v287, v288, v289, v290, v291, v292, v293, v294, v295, v296, v297, v298, v299, v300, v301, v302, v303 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3, tmp28.v4, tmp28.v5, tmp28.v6, tmp28.v7, tmp28.v8, tmp28.v9, tmp28.v10, tmp28.v11, tmp28.v12, tmp28.v13, tmp28.v14, tmp28.v15, tmp28.v16
                del tmp28
                del v301; del v303
                v304 = method24(v302, v287, v288, v289, v290, v291, v292, v293, v294)
                del v289; del v292
                v275[v280,v281] -= v286 * v304
                v274[v280,v281] = v282
                v305 = v280 + (<unsigned long long>1)
                v278.v0 = v305
            del v278
            v273.backward(v275)
            del v273; del v275
            v306 = torch.einsum('ab,ab->a',v274,v164)
            v307 = len(v5)
            v308 = numpy.empty(v307,dtype=numpy.float32)
            v309 = Mut1((<unsigned long long>0))
            while method3(v307, v309):
                v311 = v309.v0
                tmp29 = v5[v311]
                v312, v313, v314, v315, v316, v317, v318, v319, v320, v321, v322, v323, v324, v325, v326, v327, v328 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3, tmp29.v4, tmp29.v5, tmp29.v6, tmp29.v7, tmp29.v8, tmp29.v9, tmp29.v10, tmp29.v11, tmp29.v12, tmp29.v13, tmp29.v14, tmp29.v15, tmp29.v16
                del tmp29
                del v326; del v328
                v329 = method24(v327, v312, v313, v314, v315, v316, v317, v318, v319)
                del v314; del v317
                v330 = v327 == (<unsigned char>0)
                if v330:
                    v331 = (<float>1.000000)
                else:
                    v331 = (<float>-1.000000)
                v332 = v329 * v331
                v308[v311] = v332
                v333 = v311 + (<unsigned long long>1)
                v309.v0 = v333
            del v309
            v334 = torch.from_numpy(v308)
            del v308
            v163.backward(v334.unsqueeze(-1) * (v306.unsqueeze(-1) - v274))
            del v274; del v334
            v336 = v306.numpy()
            del v306
        del v54; del v163; del v164; del v165; del v265
        v337 = len(v264)
        v338 = v337 - v224
        v339 = numpy.empty(v338,dtype=numpy.float32)
        v340 = Mut1((<unsigned long long>0))
        while method3(v338, v340):
            v342 = v340.v0
            v343 = v342 + v224
            v344 = v264[v343]
            v339[v342] = v344
            v345 = v342 + (<unsigned long long>1)
            v340.v0 = v345
        del v264
        del v340
        v346 = len(v9)
        v347 = [None]*v346
        v348 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method25(v346, v348):
            v350 = v348.v0
            v351, v352 = v348.v1, v348.v2
            v353 = v9[v350]
            v354 = v353 == (<unsigned char>0)
            if v354:
                v355 = v336[v351]
                v356 = v351 + (<unsigned long long>1)
                v359, v360, v361 = v355, v356, v352
            else:
                v357 = v339[v352]
                v358 = v352 + (<unsigned long long>1)
                v359, v360, v361 = v357, v351, v358
            v347[v350] = v359
            v362 = v350 + (<unsigned long long>1)
            v348.v0 = v362
            v348.v1 = v360
            v348.v2 = v361
        del v336; del v339
        v363, v364 = v348.v1, v348.v2
        del v348
        v366 = v347
        del v347
    else:
        v366 = [None]*(<unsigned long long>0)
    del v5; del v6; del v7; del v8; del v9
    v367 = numpy.empty(v10,dtype=numpy.float32)
    v368 = len(v4)
    v369 = len(v366)
    v370 = v368 == v369
    v371 = v370 == 0
    if v371:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v372 = Mut1((<unsigned long long>0))
    while method3(v368, v372):
        v374 = v372.v0
        v375 = v4[v374]
        v376 = v366[v374]
        v367[v375] = v376
        v377 = v374 + (<unsigned long long>1)
        v372.v0 = v377
    del v4; del v366
    del v372
    v378 = len(v3)
    v379 = Mut1((<unsigned long long>0))
    while method3(v378, v379):
        v381 = v379.v0
        tmp30 = v3[v381]
        v382, v383, v384, v385, v386, v387, v388, v389, v390, v391, v392, v393, v394, v395, v396, v397, v398 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3, tmp30.v4, tmp30.v5, tmp30.v6, tmp30.v7, tmp30.v8, tmp30.v9, tmp30.v10, tmp30.v11, tmp30.v12, tmp30.v13, tmp30.v14, tmp30.v15, tmp30.v16
        del tmp30
        del v385; del v388; del v397
        v367[v382] = v398
        v399 = v381 + (<unsigned long long>1)
        v379.v0 = v399
    del v3
    del v379
    return v367
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
    cdef object v26
    cdef object v27
    cdef object v28
    cdef Mut0 v29
    cdef signed long v31
    cdef numpy.ndarray[object,ndim=1] v32
    cdef Mut1 v33
    cdef unsigned long long v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef UH0 v39
    cdef float v40
    cdef float v41
    cdef unsigned long long v42
    cdef unsigned long long v43
    cdef US1 v44
    cdef unsigned long long v45
    cdef numpy.ndarray[signed long,ndim=1] v46
    cdef Mut1 v47
    cdef unsigned long long v49
    cdef bint v50
    cdef unsigned long long v52
    cdef US1 v53
    cdef unsigned long long v54
    cdef float v55
    cdef float v56
    cdef float v57
    cdef unsigned long long v58
    cdef unsigned long long v59
    cdef US1 v60
    cdef unsigned long long v61
    cdef numpy.ndarray[signed long,ndim=1] v62
    cdef Mut1 v63
    cdef unsigned long long v65
    cdef bint v66
    cdef unsigned long long v68
    cdef US1 v69
    cdef unsigned long long v70
    cdef float v71
    cdef float v72
    cdef float v73
    cdef float v74
    cdef numpy.ndarray[signed long,ndim=1] v75
    cdef US2 v76
    cdef UH0 v77
    cdef US2 v78
    cdef UH0 v79
    cdef US3 v80
    cdef object v81
    cdef UH1 v82
    cdef unsigned long long v83
    cdef numpy.ndarray[float,ndim=1] v84
    cdef numpy.ndarray[object,ndim=1] v85
    cdef Mut1 v86
    cdef unsigned long long v88
    cdef UH0 v89
    cdef float v90
    cdef float v91
    cdef UH0 v92
    cdef float v93
    cdef float v94
    cdef unsigned long long v95
    cdef unsigned long long v96
    cdef US1 v97
    cdef unsigned long long v98
    cdef numpy.ndarray[signed long,ndim=1] v99
    cdef Mut1 v100
    cdef unsigned long long v102
    cdef bint v103
    cdef unsigned long long v105
    cdef US1 v106
    cdef unsigned long long v107
    cdef float v108
    cdef float v109
    cdef float v110
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef US1 v113
    cdef unsigned long long v114
    cdef numpy.ndarray[signed long,ndim=1] v115
    cdef Mut1 v116
    cdef unsigned long long v118
    cdef bint v119
    cdef unsigned long long v121
    cdef US1 v122
    cdef unsigned long long v123
    cdef float v124
    cdef float v125
    cdef float v126
    cdef float v127
    cdef numpy.ndarray[signed long,ndim=1] v128
    cdef US2 v129
    cdef UH0 v130
    cdef US2 v131
    cdef UH0 v132
    cdef US3 v133
    cdef object v134
    cdef UH1 v135
    cdef unsigned long long v136
    cdef numpy.ndarray[float,ndim=1] v137
    cdef signed long v138
    cdef numpy.ndarray[object,ndim=1] v139
    cdef Mut1 v140
    cdef unsigned long long v142
    cdef UH0 v143
    cdef float v144
    cdef float v145
    cdef UH0 v146
    cdef float v147
    cdef float v148
    cdef unsigned long long v149
    cdef unsigned long long v150
    cdef US1 v151
    cdef unsigned long long v152
    cdef numpy.ndarray[signed long,ndim=1] v153
    cdef Mut1 v154
    cdef unsigned long long v156
    cdef bint v157
    cdef unsigned long long v159
    cdef US1 v160
    cdef unsigned long long v161
    cdef float v162
    cdef float v163
    cdef float v164
    cdef unsigned long long v165
    cdef unsigned long long v166
    cdef US1 v167
    cdef unsigned long long v168
    cdef numpy.ndarray[signed long,ndim=1] v169
    cdef Mut1 v170
    cdef unsigned long long v172
    cdef bint v173
    cdef unsigned long long v175
    cdef US1 v176
    cdef unsigned long long v177
    cdef float v178
    cdef float v179
    cdef float v180
    cdef float v181
    cdef numpy.ndarray[signed long,ndim=1] v182
    cdef US2 v183
    cdef UH0 v184
    cdef US2 v185
    cdef UH0 v186
    cdef US3 v187
    cdef object v188
    cdef UH1 v189
    cdef unsigned long long v190
    cdef numpy.ndarray[float,ndim=1] v191
    cdef numpy.ndarray[object,ndim=1] v192
    cdef Mut1 v193
    cdef unsigned long long v195
    cdef UH0 v196
    cdef float v197
    cdef float v198
    cdef UH0 v199
    cdef float v200
    cdef float v201
    cdef unsigned long long v202
    cdef unsigned long long v203
    cdef US1 v204
    cdef unsigned long long v205
    cdef numpy.ndarray[signed long,ndim=1] v206
    cdef Mut1 v207
    cdef unsigned long long v209
    cdef bint v210
    cdef unsigned long long v212
    cdef US1 v213
    cdef unsigned long long v214
    cdef float v215
    cdef float v216
    cdef float v217
    cdef unsigned long long v218
    cdef unsigned long long v219
    cdef US1 v220
    cdef unsigned long long v221
    cdef numpy.ndarray[signed long,ndim=1] v222
    cdef Mut1 v223
    cdef unsigned long long v225
    cdef bint v226
    cdef unsigned long long v228
    cdef US1 v229
    cdef unsigned long long v230
    cdef float v231
    cdef float v232
    cdef float v233
    cdef float v234
    cdef numpy.ndarray[signed long,ndim=1] v235
    cdef US2 v236
    cdef UH0 v237
    cdef US2 v238
    cdef UH0 v239
    cdef US3 v240
    cdef object v241
    cdef UH1 v242
    cdef unsigned long long v243
    cdef numpy.ndarray[float,ndim=1] v244
    cdef signed long v245
    cdef numpy.ndarray[object,ndim=1] v246
    cdef Mut1 v247
    cdef unsigned long long v249
    cdef UH0 v250
    cdef float v251
    cdef float v252
    cdef UH0 v253
    cdef float v254
    cdef float v255
    cdef unsigned long long v256
    cdef unsigned long long v257
    cdef US1 v258
    cdef unsigned long long v259
    cdef numpy.ndarray[signed long,ndim=1] v260
    cdef Mut1 v261
    cdef unsigned long long v263
    cdef bint v264
    cdef unsigned long long v266
    cdef US1 v267
    cdef unsigned long long v268
    cdef float v269
    cdef float v270
    cdef float v271
    cdef unsigned long long v272
    cdef unsigned long long v273
    cdef US1 v274
    cdef unsigned long long v275
    cdef numpy.ndarray[signed long,ndim=1] v276
    cdef Mut1 v277
    cdef unsigned long long v279
    cdef bint v280
    cdef unsigned long long v282
    cdef US1 v283
    cdef unsigned long long v284
    cdef float v285
    cdef float v286
    cdef float v287
    cdef float v288
    cdef numpy.ndarray[signed long,ndim=1] v289
    cdef US2 v290
    cdef UH0 v291
    cdef US2 v292
    cdef UH0 v293
    cdef US3 v294
    cdef object v295
    cdef UH1 v296
    cdef unsigned long long v297
    cdef numpy.ndarray[float,ndim=1] v298
    cdef numpy.ndarray[object,ndim=1] v299
    cdef Mut1 v300
    cdef unsigned long long v302
    cdef UH0 v303
    cdef float v304
    cdef float v305
    cdef UH0 v306
    cdef float v307
    cdef float v308
    cdef unsigned long long v309
    cdef unsigned long long v310
    cdef US1 v311
    cdef unsigned long long v312
    cdef numpy.ndarray[signed long,ndim=1] v313
    cdef Mut1 v314
    cdef unsigned long long v316
    cdef bint v317
    cdef unsigned long long v319
    cdef US1 v320
    cdef unsigned long long v321
    cdef float v322
    cdef float v323
    cdef float v324
    cdef unsigned long long v325
    cdef unsigned long long v326
    cdef US1 v327
    cdef unsigned long long v328
    cdef numpy.ndarray[signed long,ndim=1] v329
    cdef Mut1 v330
    cdef unsigned long long v332
    cdef bint v333
    cdef unsigned long long v335
    cdef US1 v336
    cdef unsigned long long v337
    cdef float v338
    cdef float v339
    cdef float v340
    cdef float v341
    cdef numpy.ndarray[signed long,ndim=1] v342
    cdef US2 v343
    cdef UH0 v344
    cdef US2 v345
    cdef UH0 v346
    cdef US3 v347
    cdef object v348
    cdef UH1 v349
    cdef unsigned long long v350
    cdef numpy.ndarray[float,ndim=1] v351
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
    print('The learning rate is 2 **',torch.log2(torch.scalar_tensor((<float>0.000031))).item())
    v22 = torch.optim.SGD([{'params':v20.parameters()},{'params':v21.parameters()}],lr=(<float>0.000031))
    v23 = Mut0((<signed long>0))
    while method0(v23):
        v25 = v23.v0
        pass # import copy
        v26 = copy.deepcopy(v20)
        pass # import copy
        v27 = copy.deepcopy(v21)
        v28 = torch.optim.SGD([{'params':v26.parameters()},{'params':v27.parameters()}],lr=(<float>0.000008))
        v26.train()
        v27.train()
        v20.eval()
        v21.eval()
        v29 = Mut0((<signed long>0))
        while method1(v29):
            v31 = v29.v0
            v28.zero_grad()
            v32 = numpy.empty((<unsigned long long>512),dtype=object)
            v33 = Mut1((<unsigned long long>0))
            while method2(v33):
                v35 = v33.v0
                v36 = UH0_1()
                v37 = (<float>0.000000)
                v38 = (<float>0.000000)
                v39 = UH0_1()
                v40 = (<float>0.000000)
                v41 = (<float>0.000000)
                v42 = len(v19)
                v43 = numpy.random.randint(0,v42)
                v44 = v19[v43]
                v45 = v42 - (<unsigned long long>1)
                v46 = numpy.empty(v45,dtype=numpy.int32)
                v47 = Mut1((<unsigned long long>0))
                while method3(v45, v47):
                    v49 = v47.v0
                    v50 = v43 <= v49
                    if v50:
                        v52 = v49 + (<unsigned long long>1)
                    else:
                        v52 = v49
                    v53 = v19[v52]
                    v46[v49] = v53
                    v54 = v49 + (<unsigned long long>1)
                    v47.v0 = v54
                del v47
                v55 = <float>v42
                v56 = (<float>1.000000) / v55
                v57 = libc.math.log(v56)
                v58 = len(v46)
                v59 = numpy.random.randint(0,v58)
                v60 = v46[v59]
                v61 = v58 - (<unsigned long long>1)
                v62 = numpy.empty(v61,dtype=numpy.int32)
                v63 = Mut1((<unsigned long long>0))
                while method3(v61, v63):
                    v65 = v63.v0
                    v66 = v59 <= v65
                    if v66:
                        v68 = v65 + (<unsigned long long>1)
                    else:
                        v68 = v65
                    v69 = v46[v68]
                    v62[v65] = v69
                    v70 = v65 + (<unsigned long long>1)
                    v63.v0 = v70
                del v46
                del v63
                v71 = <float>v58
                v72 = (<float>1.000000) / v71
                v73 = libc.math.log(v72)
                v74 = v73 + v57
                v75 = v12.v2
                v76 = US2_1(v44)
                v77 = UH0_0(v76, v36)
                del v76
                v78 = US2_1(v60)
                v79 = UH0_0(v78, v39)
                del v78
                v80 = US3_0()
                v81 = Closure0(v44, v60, v12, v62, v39, v40, v41, v36, v37, v38, v74)
                del v36; del v39; del v62
                v82 = UH1_0(v74, v74, v77, v37, v38, v79, v40, v41, v44, (<unsigned char>0), (<signed long>1), v60, (<unsigned char>1), (<signed long>1), v80, (<unsigned char>0), v75, v81)
                del v75; del v77; del v79; del v80; del v81
                v32[v35] = v82
                del v82
                v83 = v35 + (<unsigned long long>1)
                v33.v0 = v83
            del v33
            v84 = method12(v27, v26, v21, v20, v32)
            del v32; del v84
            v85 = numpy.empty((<unsigned long long>512),dtype=object)
            v86 = Mut1((<unsigned long long>0))
            while method2(v86):
                v88 = v86.v0
                v89 = UH0_1()
                v90 = (<float>0.000000)
                v91 = (<float>0.000000)
                v92 = UH0_1()
                v93 = (<float>0.000000)
                v94 = (<float>0.000000)
                v95 = len(v19)
                v96 = numpy.random.randint(0,v95)
                v97 = v19[v96]
                v98 = v95 - (<unsigned long long>1)
                v99 = numpy.empty(v98,dtype=numpy.int32)
                v100 = Mut1((<unsigned long long>0))
                while method3(v98, v100):
                    v102 = v100.v0
                    v103 = v96 <= v102
                    if v103:
                        v105 = v102 + (<unsigned long long>1)
                    else:
                        v105 = v102
                    v106 = v19[v105]
                    v99[v102] = v106
                    v107 = v102 + (<unsigned long long>1)
                    v100.v0 = v107
                del v100
                v108 = <float>v95
                v109 = (<float>1.000000) / v108
                v110 = libc.math.log(v109)
                v111 = len(v99)
                v112 = numpy.random.randint(0,v111)
                v113 = v99[v112]
                v114 = v111 - (<unsigned long long>1)
                v115 = numpy.empty(v114,dtype=numpy.int32)
                v116 = Mut1((<unsigned long long>0))
                while method3(v114, v116):
                    v118 = v116.v0
                    v119 = v112 <= v118
                    if v119:
                        v121 = v118 + (<unsigned long long>1)
                    else:
                        v121 = v118
                    v122 = v99[v121]
                    v115[v118] = v122
                    v123 = v118 + (<unsigned long long>1)
                    v116.v0 = v123
                del v99
                del v116
                v124 = <float>v111
                v125 = (<float>1.000000) / v124
                v126 = libc.math.log(v125)
                v127 = v126 + v110
                v128 = v12.v2
                v129 = US2_1(v97)
                v130 = UH0_0(v129, v89)
                del v129
                v131 = US2_1(v113)
                v132 = UH0_0(v131, v92)
                del v131
                v133 = US3_0()
                v134 = Closure0(v97, v113, v12, v115, v92, v93, v94, v89, v90, v91, v127)
                del v89; del v92; del v115
                v135 = UH1_0(v127, v127, v130, v90, v91, v132, v93, v94, v97, (<unsigned char>0), (<signed long>1), v113, (<unsigned char>1), (<signed long>1), v133, (<unsigned char>0), v128, v134)
                del v128; del v130; del v132; del v133; del v134
                v85[v88] = v135
                del v135
                v136 = v88 + (<unsigned long long>1)
                v86.v0 = v136
            del v86
            v137 = method12(v21, v20, v27, v26, v85)
            del v85; del v137
            v28.step()
            v138 = v31 + (<signed long>1)
            v29.v0 = v138
        del v28
        del v29
        v20.train()
        v21.train()
        v26.eval()
        v27.eval()
        v22.zero_grad()
        v139 = numpy.empty((<unsigned long long>512),dtype=object)
        v140 = Mut1((<unsigned long long>0))
        while method2(v140):
            v142 = v140.v0
            v143 = UH0_1()
            v144 = (<float>0.000000)
            v145 = (<float>0.000000)
            v146 = UH0_1()
            v147 = (<float>0.000000)
            v148 = (<float>0.000000)
            v149 = len(v19)
            v150 = numpy.random.randint(0,v149)
            v151 = v19[v150]
            v152 = v149 - (<unsigned long long>1)
            v153 = numpy.empty(v152,dtype=numpy.int32)
            v154 = Mut1((<unsigned long long>0))
            while method3(v152, v154):
                v156 = v154.v0
                v157 = v150 <= v156
                if v157:
                    v159 = v156 + (<unsigned long long>1)
                else:
                    v159 = v156
                v160 = v19[v159]
                v153[v156] = v160
                v161 = v156 + (<unsigned long long>1)
                v154.v0 = v161
            del v154
            v162 = <float>v149
            v163 = (<float>1.000000) / v162
            v164 = libc.math.log(v163)
            v165 = len(v153)
            v166 = numpy.random.randint(0,v165)
            v167 = v153[v166]
            v168 = v165 - (<unsigned long long>1)
            v169 = numpy.empty(v168,dtype=numpy.int32)
            v170 = Mut1((<unsigned long long>0))
            while method3(v168, v170):
                v172 = v170.v0
                v173 = v166 <= v172
                if v173:
                    v175 = v172 + (<unsigned long long>1)
                else:
                    v175 = v172
                v176 = v153[v175]
                v169[v172] = v176
                v177 = v172 + (<unsigned long long>1)
                v170.v0 = v177
            del v153
            del v170
            v178 = <float>v165
            v179 = (<float>1.000000) / v178
            v180 = libc.math.log(v179)
            v181 = v180 + v164
            v182 = v12.v2
            v183 = US2_1(v151)
            v184 = UH0_0(v183, v143)
            del v183
            v185 = US2_1(v167)
            v186 = UH0_0(v185, v146)
            del v185
            v187 = US3_0()
            v188 = Closure0(v151, v167, v12, v169, v146, v147, v148, v143, v144, v145, v181)
            del v143; del v146; del v169
            v189 = UH1_0(v181, v181, v184, v144, v145, v186, v147, v148, v151, (<unsigned char>0), (<signed long>1), v167, (<unsigned char>1), (<signed long>1), v187, (<unsigned char>0), v182, v188)
            del v182; del v184; del v186; del v187; del v188
            v139[v142] = v189
            del v189
            v190 = v142 + (<unsigned long long>1)
            v140.v0 = v190
        del v140
        v191 = method12(v27, v26, v21, v20, v139)
        del v139
        v192 = numpy.empty((<unsigned long long>512),dtype=object)
        v193 = Mut1((<unsigned long long>0))
        while method2(v193):
            v195 = v193.v0
            v196 = UH0_1()
            v197 = (<float>0.000000)
            v198 = (<float>0.000000)
            v199 = UH0_1()
            v200 = (<float>0.000000)
            v201 = (<float>0.000000)
            v202 = len(v19)
            v203 = numpy.random.randint(0,v202)
            v204 = v19[v203]
            v205 = v202 - (<unsigned long long>1)
            v206 = numpy.empty(v205,dtype=numpy.int32)
            v207 = Mut1((<unsigned long long>0))
            while method3(v205, v207):
                v209 = v207.v0
                v210 = v203 <= v209
                if v210:
                    v212 = v209 + (<unsigned long long>1)
                else:
                    v212 = v209
                v213 = v19[v212]
                v206[v209] = v213
                v214 = v209 + (<unsigned long long>1)
                v207.v0 = v214
            del v207
            v215 = <float>v202
            v216 = (<float>1.000000) / v215
            v217 = libc.math.log(v216)
            v218 = len(v206)
            v219 = numpy.random.randint(0,v218)
            v220 = v206[v219]
            v221 = v218 - (<unsigned long long>1)
            v222 = numpy.empty(v221,dtype=numpy.int32)
            v223 = Mut1((<unsigned long long>0))
            while method3(v221, v223):
                v225 = v223.v0
                v226 = v219 <= v225
                if v226:
                    v228 = v225 + (<unsigned long long>1)
                else:
                    v228 = v225
                v229 = v206[v228]
                v222[v225] = v229
                v230 = v225 + (<unsigned long long>1)
                v223.v0 = v230
            del v206
            del v223
            v231 = <float>v218
            v232 = (<float>1.000000) / v231
            v233 = libc.math.log(v232)
            v234 = v233 + v217
            v235 = v12.v2
            v236 = US2_1(v204)
            v237 = UH0_0(v236, v196)
            del v236
            v238 = US2_1(v220)
            v239 = UH0_0(v238, v199)
            del v238
            v240 = US3_0()
            v241 = Closure0(v204, v220, v12, v222, v199, v200, v201, v196, v197, v198, v234)
            del v196; del v199; del v222
            v242 = UH1_0(v234, v234, v237, v197, v198, v239, v200, v201, v204, (<unsigned char>0), (<signed long>1), v220, (<unsigned char>1), (<signed long>1), v240, (<unsigned char>0), v235, v241)
            del v235; del v237; del v239; del v240; del v241
            v192[v195] = v242
            del v242
            v243 = v195 + (<unsigned long long>1)
            v193.v0 = v243
        del v193
        v244 = method12(v21, v20, v27, v26, v192)
        del v26; del v27; del v192
        v22.step()
        print(numpy.mean(v191),numpy.mean(v244))
        del v191; del v244
        v245 = v25 + (<signed long>1)
        v23.v0 = v245
    del v22
    del v23
    print('---')
    v246 = numpy.empty((<unsigned long long>5120),dtype=object)
    v247 = Mut1((<unsigned long long>0))
    while method26(v247):
        v249 = v247.v0
        v250 = UH0_1()
        v251 = (<float>0.000000)
        v252 = (<float>0.000000)
        v253 = UH0_1()
        v254 = (<float>0.000000)
        v255 = (<float>0.000000)
        v256 = len(v19)
        v257 = numpy.random.randint(0,v256)
        v258 = v19[v257]
        v259 = v256 - (<unsigned long long>1)
        v260 = numpy.empty(v259,dtype=numpy.int32)
        v261 = Mut1((<unsigned long long>0))
        while method3(v259, v261):
            v263 = v261.v0
            v264 = v257 <= v263
            if v264:
                v266 = v263 + (<unsigned long long>1)
            else:
                v266 = v263
            v267 = v19[v266]
            v260[v263] = v267
            v268 = v263 + (<unsigned long long>1)
            v261.v0 = v268
        del v261
        v269 = <float>v256
        v270 = (<float>1.000000) / v269
        v271 = libc.math.log(v270)
        v272 = len(v260)
        v273 = numpy.random.randint(0,v272)
        v274 = v260[v273]
        v275 = v272 - (<unsigned long long>1)
        v276 = numpy.empty(v275,dtype=numpy.int32)
        v277 = Mut1((<unsigned long long>0))
        while method3(v275, v277):
            v279 = v277.v0
            v280 = v273 <= v279
            if v280:
                v282 = v279 + (<unsigned long long>1)
            else:
                v282 = v279
            v283 = v260[v282]
            v276[v279] = v283
            v284 = v279 + (<unsigned long long>1)
            v277.v0 = v284
        del v260
        del v277
        v285 = <float>v272
        v286 = (<float>1.000000) / v285
        v287 = libc.math.log(v286)
        v288 = v287 + v271
        v289 = v12.v2
        v290 = US2_1(v258)
        v291 = UH0_0(v290, v250)
        del v290
        v292 = US2_1(v274)
        v293 = UH0_0(v292, v253)
        del v292
        v294 = US3_0()
        v295 = Closure0(v258, v274, v12, v276, v253, v254, v255, v250, v251, v252, v288)
        del v250; del v253; del v276
        v296 = UH1_0(v288, v288, v291, v251, v252, v293, v254, v255, v258, (<unsigned char>0), (<signed long>1), v274, (<unsigned char>1), (<signed long>1), v294, (<unsigned char>0), v289, v295)
        del v289; del v291; del v293; del v294; del v295
        v246[v249] = v296
        del v296
        v297 = v249 + (<unsigned long long>1)
        v247.v0 = v297
    del v247
    v298 = method27(v21, v20, v246)
    del v246
    v299 = numpy.empty((<unsigned long long>5120),dtype=object)
    v300 = Mut1((<unsigned long long>0))
    while method26(v300):
        v302 = v300.v0
        v303 = UH0_1()
        v304 = (<float>0.000000)
        v305 = (<float>0.000000)
        v306 = UH0_1()
        v307 = (<float>0.000000)
        v308 = (<float>0.000000)
        v309 = len(v19)
        v310 = numpy.random.randint(0,v309)
        v311 = v19[v310]
        v312 = v309 - (<unsigned long long>1)
        v313 = numpy.empty(v312,dtype=numpy.int32)
        v314 = Mut1((<unsigned long long>0))
        while method3(v312, v314):
            v316 = v314.v0
            v317 = v310 <= v316
            if v317:
                v319 = v316 + (<unsigned long long>1)
            else:
                v319 = v316
            v320 = v19[v319]
            v313[v316] = v320
            v321 = v316 + (<unsigned long long>1)
            v314.v0 = v321
        del v314
        v322 = <float>v309
        v323 = (<float>1.000000) / v322
        v324 = libc.math.log(v323)
        v325 = len(v313)
        v326 = numpy.random.randint(0,v325)
        v327 = v313[v326]
        v328 = v325 - (<unsigned long long>1)
        v329 = numpy.empty(v328,dtype=numpy.int32)
        v330 = Mut1((<unsigned long long>0))
        while method3(v328, v330):
            v332 = v330.v0
            v333 = v326 <= v332
            if v333:
                v335 = v332 + (<unsigned long long>1)
            else:
                v335 = v332
            v336 = v313[v335]
            v329[v332] = v336
            v337 = v332 + (<unsigned long long>1)
            v330.v0 = v337
        del v313
        del v330
        v338 = <float>v325
        v339 = (<float>1.000000) / v338
        v340 = libc.math.log(v339)
        v341 = v340 + v324
        v342 = v12.v2
        v343 = US2_1(v311)
        v344 = UH0_0(v343, v303)
        del v343
        v345 = US2_1(v327)
        v346 = UH0_0(v345, v306)
        del v345
        v347 = US3_0()
        v348 = Closure0(v311, v327, v12, v329, v306, v307, v308, v303, v304, v305, v341)
        del v303; del v306; del v329
        v349 = UH1_0(v341, v341, v344, v304, v305, v346, v307, v308, v311, (<unsigned char>0), (<signed long>1), v327, (<unsigned char>1), (<signed long>1), v347, (<unsigned char>0), v342, v348)
        del v342; del v344; del v346; del v347; del v348
        v299[v302] = v349
        del v349
        v350 = v302 + (<unsigned long long>1)
        v300.v0 = v350
    del v12; del v19
    del v300
    v351 = method28(v21, v20, v299)
    del v20; del v21; del v299
    print(numpy.mean(v298),numpy.mean(v351))
