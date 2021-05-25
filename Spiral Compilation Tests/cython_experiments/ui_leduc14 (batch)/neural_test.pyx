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
            return method8(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method8(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
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
            return method6(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v24, v20, v19, v28, v9, v10)
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
            return method6(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v35, v12, v13, v39, v31, v30)
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
            return method10(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method10(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
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
            return method5(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v22, v20, v19, v24, v9, v10)
        else:
            v26 = v16 + v10
            v27 = v15 + v9
            v28 = US2_0(v17)
            v29 = UH0_0(v28, v11)
            del v28
            v30 = US2_0(v17)
            v31 = UH0_0(v30, v8)
            del v30
            return method5(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v29, v12, v13, v31, v27, v26)
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
        return method3(v0, v1, v2, v3, v13, v10, v19, v15, v14, v23, v5, v6)
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
    return v1 < (<signed long>100)
cdef bint method1(Mut1 v0) except *:
    cdef unsigned long long v1
    v1 = v0.v0
    return v1 < (<unsigned long long>1024)
cdef bint method2(unsigned long long v0, Mut1 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[signed long,ndim=1] method4(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method7(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method9(US1 v0) except *:
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef UH1 method8(Heap0 v0, signed long v1, US1 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
        v17 = method9(v2)
        v18 = method9(v6)
        v19 = method9(v3)
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
        v94 = method7(v0, v6, v7, v93, v3, v4, v5, v92)
        v95 = US3_1(v2)
        v96 = Closure3(v4, v0, v92, v2, v6, v7, v93, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH1_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v93, v95, v4, v94, v96)
cdef UH1 method6(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, US0 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
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
        v17 = method7(v0, v4, v5, v6, v1, v2, v3, v16)
        v18 = US3_1(v7)
        v19 = Closure3(v2, v0, v16, v7, v4, v5, v6, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v18, v2, v17, v19)
    elif v8 == 1: # fold
        raise Exception("impossible 2")
    elif v8 == 2: # raise
        v23 = (<signed long>1)
        v24 = v3 + (<signed long>4)
        v25 = method7(v0, v4, v5, v24, v1, v2, v3, v23)
        v26 = US3_1(v7)
        v27 = Closure3(v2, v0, v23, v7, v4, v5, v24, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v24, v26, v2, v25, v27)
cdef UH1 method10(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
        v60 = method7(v0, v6, v7, v59, v3, v4, v5, v58)
        v61 = US3_0()
        v62 = Closure4(v4, v0, v1, v58, v6, v7, v59, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH1_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v59, v61, v4, v60, v62)
cdef UH1 method5(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US0 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
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
        v59 = method7(v0, v6, v7, v58, v3, v4, v5, v57)
        v60 = US3_0()
        v61 = Closure4(v4, v0, v1, v57, v6, v7, v58, v3, v5, v13, v14, v15, v10, v11, v12, v9)
        return UH1_0(v9, v9, v10, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v58, v60, v4, v59, v61)
cdef UH1 method3(US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, US0 v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
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
        v16 = method4(v2, v0, v15, v14, v1, v13, v12)
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
        v27 = method7(v2, v0, v25, v26, v1, v23, v24, v22)
        v28 = US3_0()
        v29 = Closure4(v23, v2, v3, v22, v0, v25, v26, v1, v24, v9, v10, v11, v6, v7, v8, v5)
        return UH1_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v23, v24, v0, v25, v26, v28, v23, v27, v29)
cdef UH0 method13(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method13(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH2 method15(UH2 v0, UH2 v1):
    cdef US0 v2
    cdef UH2 v3
    cdef UH2 v4
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v3 = (<UH2_0>v0).v1
        v4 = UH2_0(v2, v1)
        return method15(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method17(UH2 v0, unsigned long long v1) except *:
    cdef US0 v2
    cdef UH2 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v3 = (<UH2_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method17(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method18(numpy.ndarray[signed long,ndim=1] v0, UH2 v1, unsigned long long v2) except *:
    cdef US0 v3
    cdef UH2 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1
        v0[v2] = v3
        v5 = v2 + (<unsigned long long>1)
        return method18(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[signed long,ndim=1] method16(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[signed long,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method17(v0, v1)
    v3 = numpy.empty(v2,dtype=numpy.int32)
    v4 = (<unsigned long long>0)
    v5 = method18(v3, v0, v4)
    return v3
cdef UH3 method14(UH2 v0, US1 v1, UH0 v2):
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
            return method14(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH2_1()
            v10 = method15(v0, v9)
            del v9
            v11 = method16(v10)
            del v10
            v12 = UH2_1()
            v13 = method14(v12, v8, v4)
            del v4; del v12
            return UH3_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH2_1()
        v17 = method15(v0, v16)
        del v16
        v18 = method16(v17)
        del v17
        v19 = UH3_1()
        return UH3_0(v1, v18, v19)
cdef unsigned long long method20(UH3 v0, unsigned long long v1) except *:
    cdef US1 v2
    cdef UH3 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH3_0>v0).v0; v4 = (<UH3_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method20(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method21(numpy.ndarray[object,ndim=1] v0, UH3 v1, unsigned long long v2) except *:
    cdef US1 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH3 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH3_0>v1).v0; v4 = (<UH3_0>v1).v1; v5 = (<UH3_0>v1).v2
        v0[v2] = Tuple3(v3, v4)
        del v4
        v6 = v2 + (<unsigned long long>1)
        return method21(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method19(UH3 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method20(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<unsigned long long>0)
    v5 = method21(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method12(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef US1 v7
    cdef UH2 v8
    cdef UH3 v9
    v1 = UH0_1()
    v2 = method13(v0, v1)
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
            v9 = method14(v8, v7, v4)
            del v4; del v8
            return method19(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef bint method22(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method11(v0, v1, numpy.ndarray[object,ndim=1] v2):
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
    cdef list v345
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
    cdef Tuple1 tmp0
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
    cdef Tuple3 tmp1
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
    cdef Tuple1 tmp2
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
    cdef Tuple1 tmp3
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
    cdef Tuple0 tmp4
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
    cdef Tuple0 tmp5
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
    cdef numpy.ndarray[float,ndim=1] v315
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
    cdef float v285
    cdef unsigned long long v286
    cdef unsigned long long v287
    cdef numpy.ndarray[float,ndim=1] v288
    cdef Mut1 v289
    cdef unsigned long long v291
    cdef float v292
    cdef float v293
    cdef UH0 v294
    cdef float v295
    cdef float v296
    cdef UH0 v297
    cdef float v298
    cdef float v299
    cdef US1 v300
    cdef unsigned char v301
    cdef signed long v302
    cdef US1 v303
    cdef unsigned char v304
    cdef signed long v305
    cdef US3 v306
    cdef unsigned char v307
    cdef numpy.ndarray[signed long,ndim=1] v308
    cdef Tuple1 tmp6
    cdef bint v309
    cdef float v310
    cdef unsigned long long v311
    cdef object v312
    cdef object v313
    cdef unsigned long long v316
    cdef unsigned long long v317
    cdef numpy.ndarray[float,ndim=1] v318
    cdef Mut1 v319
    cdef unsigned long long v321
    cdef unsigned long long v322
    cdef float v323
    cdef unsigned long long v324
    cdef unsigned long long v325
    cdef list v326
    cdef Mut2 v327
    cdef unsigned long long v329
    cdef unsigned long long v330
    cdef unsigned long long v331
    cdef unsigned char v332
    cdef bint v333
    cdef float v338
    cdef unsigned long long v339
    cdef unsigned long long v340
    cdef float v334
    cdef unsigned long long v335
    cdef float v336
    cdef unsigned long long v337
    cdef unsigned long long v341
    cdef unsigned long long v342
    cdef unsigned long long v343
    cdef numpy.ndarray[float,ndim=1] v346
    cdef unsigned long long v347
    cdef unsigned long long v348
    cdef bint v349
    cdef bint v350
    cdef Mut1 v351
    cdef unsigned long long v353
    cdef unsigned long long v354
    cdef float v355
    cdef unsigned long long v356
    cdef unsigned long long v357
    cdef Mut1 v358
    cdef unsigned long long v360
    cdef unsigned long long v361
    cdef float v362
    cdef float v363
    cdef UH0 v364
    cdef float v365
    cdef float v366
    cdef UH0 v367
    cdef float v368
    cdef float v369
    cdef US1 v370
    cdef unsigned char v371
    cdef signed long v372
    cdef US1 v373
    cdef unsigned char v374
    cdef signed long v375
    cdef US3 v376
    cdef float v377
    cdef Tuple2 tmp7
    cdef unsigned long long v378
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v2)
    v11 = Mut1((<unsigned long long>0))
    while method2(v10, v11):
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
        while method2(v55, v56):
            v58 = v56.v0
            tmp0 = v5[v58]
            v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
            del tmp0
            del v73; del v75
            v76 = v74 == (<unsigned char>0)
            if v76:
                v77 = v61
            else:
                v77 = v64
            del v61; del v64
            v78 = method12(v77)
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
            while method2(v93, v95):
                v97 = v95.v0
                tmp1 = v78[v97]
                v98, v99 = tmp1.v0, tmp1.v1
                del tmp1
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
                while method2(v105, v107):
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
        while method2(v118, v120):
            v122 = v120.v0
            tmp2 = v5[v122]
            v123, v124, v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135, v136, v137, v138, v139 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16
            del tmp2
            del v125; del v128; del v137
            v140 = len(v139)
            v141 = numpy.empty(v140,dtype=numpy.int64)
            v142 = Mut1((<unsigned long long>0))
            while method2(v140, v142):
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
        while method2(v151, v152):
            v154 = v152.v0
            v155 = v119[v154]
            v156 = len(v155)
            v157 = Mut1((<unsigned long long>0))
            while method2(v156, v157):
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
        while method2(v166, v168):
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
        while method2(v195, v197):
            v199 = v197.v0
            tmp3 = v6[v199]
            v200, v201, v202, v203, v204, v205, v206, v207, v208, v209, v210, v211, v212, v213, v214, v215, v216 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4, tmp3.v5, tmp3.v6, tmp3.v7, tmp3.v8, tmp3.v9, tmp3.v10, tmp3.v11, tmp3.v12, tmp3.v13, tmp3.v14, tmp3.v15, tmp3.v16
            del tmp3
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
        while method2(v223, v228):
            v230 = v228.v0
            v231 = v7[v230]
            tmp4 = v167[v230]
            v232, v233, v234 = tmp4.v0, tmp4.v1, tmp4.v2
            del tmp4
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
        while method2(v237, v242):
            v244 = v242.v0
            v245 = v8[v244]
            tmp5 = v196[v244]
            v246, v247, v248 = tmp5.v0, tmp5.v1, tmp5.v2
            del tmp5
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
        while method2(v253, v255):
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
        v264 = method11(v0, v1, v254)
        del v254
        v265 = numpy.empty(v224,dtype=numpy.float32)
        v266 = Mut1((<unsigned long long>0))
        while method2(v224, v266):
            v268 = v266.v0
            v269 = v264[v268]
            v265[v268] = v269
            v270 = v268 + (<unsigned long long>1)
            v266.v0 = v270
        del v266
        v271 = len(v265)
        v272 = v271 == (<unsigned long long>0)
        if v272:
            v315 = v265
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
            while method2(v166, v278):
                v280 = v278.v0
                v281 = v165[v280]
                v282 = v265[v280]
                v283 = v164[v280,v281]
                v284 = v274[v280,v281]
                v285 = v282 - v284
                v275[v280,v281] -= v285
                v274[v280,v281] += v285 / v283
                v286 = v280 + (<unsigned long long>1)
                v278.v0 = v286
            del v278
            print(torch.mean(v275))
            v273.backward(v275)
            del v273; del v275
            v287 = len(v5)
            v288 = numpy.empty(v287,dtype=numpy.float32)
            v289 = Mut1((<unsigned long long>0))
            while method2(v287, v289):
                v291 = v289.v0
                tmp6 = v5[v291]
                v292, v293, v294, v295, v296, v297, v298, v299, v300, v301, v302, v303, v304, v305, v306, v307, v308 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4, tmp6.v5, tmp6.v6, tmp6.v7, tmp6.v8, tmp6.v9, tmp6.v10, tmp6.v11, tmp6.v12, tmp6.v13, tmp6.v14, tmp6.v15, tmp6.v16
                del tmp6
                del v294; del v297; del v306; del v308
                v309 = v307 == (<unsigned char>0)
                if v309:
                    v310 = (<float>1.000000)
                else:
                    v310 = (<float>-1.000000)
                v288[v291] = v310
                v311 = v291 + (<unsigned long long>1)
                v289.v0 = v311
            del v289
            v312 = torch.from_numpy(v288)
            del v288
            v313 = torch.einsum('ab,ab->a',v274,v164)
            v163.backward(v312.unsqueeze(-1) * (v313.unsqueeze(-1) - v274))
            del v274; del v312
            v315 = v313.numpy()
            del v313
        del v54; del v163; del v164; del v165; del v265
        v316 = len(v264)
        v317 = v316 - v224
        v318 = numpy.empty(v317,dtype=numpy.float32)
        v319 = Mut1((<unsigned long long>0))
        while method2(v317, v319):
            v321 = v319.v0
            v322 = v321 + v224
            v323 = v264[v322]
            v318[v321] = v323
            v324 = v321 + (<unsigned long long>1)
            v319.v0 = v324
        del v264
        del v319
        v325 = len(v9)
        v326 = [None]*v325
        v327 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method22(v325, v327):
            v329 = v327.v0
            v330, v331 = v327.v1, v327.v2
            v332 = v9[v329]
            v333 = v332 == (<unsigned char>0)
            if v333:
                v334 = v315[v330]
                v335 = v330 + (<unsigned long long>1)
                v338, v339, v340 = v334, v335, v331
            else:
                v336 = v318[v331]
                v337 = v331 + (<unsigned long long>1)
                v338, v339, v340 = v336, v330, v337
            v326[v329] = v338
            v341 = v329 + (<unsigned long long>1)
            v327.v0 = v341
            v327.v1 = v339
            v327.v2 = v340
        del v315; del v318
        v342, v343 = v327.v1, v327.v2
        del v327
        v345 = v326
        del v326
    else:
        v345 = [None]*(<unsigned long long>0)
    del v5; del v6; del v7; del v8; del v9
    v346 = numpy.empty(v10,dtype=numpy.float32)
    v347 = len(v4)
    v348 = len(v345)
    v349 = v347 == v348
    v350 = v349 == 0
    if v350:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v351 = Mut1((<unsigned long long>0))
    while method2(v347, v351):
        v353 = v351.v0
        v354 = v4[v353]
        v355 = v345[v353]
        v346[v354] = v355
        v356 = v353 + (<unsigned long long>1)
        v351.v0 = v356
    del v4; del v345
    del v351
    v357 = len(v3)
    v358 = Mut1((<unsigned long long>0))
    while method2(v357, v358):
        v360 = v358.v0
        tmp7 = v3[v360]
        v361, v362, v363, v364, v365, v366, v367, v368, v369, v370, v371, v372, v373, v374, v375, v376, v377 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3, tmp7.v4, tmp7.v5, tmp7.v6, tmp7.v7, tmp7.v8, tmp7.v9, tmp7.v10, tmp7.v11, tmp7.v12, tmp7.v13, tmp7.v14, tmp7.v15, tmp7.v16
        del tmp7
        del v364; del v367; del v376
        v346[v361] = v377
        v378 = v360 + (<unsigned long long>1)
        v358.v0 = v378
    del v3
    del v358
    return v346
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
    cdef numpy.ndarray[object,ndim=1] v26
    cdef Mut1 v27
    cdef unsigned long long v29
    cdef UH0 v30
    cdef float v31
    cdef float v32
    cdef UH0 v33
    cdef float v34
    cdef float v35
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef US1 v38
    cdef unsigned long long v39
    cdef numpy.ndarray[signed long,ndim=1] v40
    cdef Mut1 v41
    cdef unsigned long long v43
    cdef bint v44
    cdef unsigned long long v46
    cdef US1 v47
    cdef unsigned long long v48
    cdef float v49
    cdef float v50
    cdef float v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef US1 v54
    cdef unsigned long long v55
    cdef numpy.ndarray[signed long,ndim=1] v56
    cdef Mut1 v57
    cdef unsigned long long v59
    cdef bint v60
    cdef unsigned long long v62
    cdef US1 v63
    cdef unsigned long long v64
    cdef float v65
    cdef float v66
    cdef float v67
    cdef float v68
    cdef numpy.ndarray[signed long,ndim=1] v69
    cdef US2 v70
    cdef UH0 v71
    cdef US2 v72
    cdef UH0 v73
    cdef US3 v74
    cdef object v75
    cdef UH1 v76
    cdef unsigned long long v77
    cdef numpy.ndarray[float,ndim=1] v78
    cdef signed long v79
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
    v22 = torch.optim.SGD([{'params':v21.parameters()}],lr=(<float>0.000015))
    v23 = Mut0((<signed long>0))
    while method0(v23):
        v25 = v23.v0
        v22.zero_grad()
        v26 = numpy.empty((<unsigned long long>1024),dtype=object)
        v27 = Mut1((<unsigned long long>0))
        while method1(v27):
            v29 = v27.v0
            v30 = UH0_1()
            v31 = (<float>0.000000)
            v32 = (<float>0.000000)
            v33 = UH0_1()
            v34 = (<float>0.000000)
            v35 = (<float>0.000000)
            v36 = len(v19)
            v37 = numpy.random.randint(0,v36)
            v38 = v19[v37]
            v39 = v36 - (<unsigned long long>1)
            v40 = numpy.empty(v39,dtype=numpy.int32)
            v41 = Mut1((<unsigned long long>0))
            while method2(v39, v41):
                v43 = v41.v0
                v44 = v37 <= v43
                if v44:
                    v46 = v43 + (<unsigned long long>1)
                else:
                    v46 = v43
                v47 = v19[v46]
                v40[v43] = v47
                v48 = v43 + (<unsigned long long>1)
                v41.v0 = v48
            del v41
            v49 = <float>v36
            v50 = (<float>1.000000) / v49
            v51 = libc.math.log(v50)
            v52 = len(v40)
            v53 = numpy.random.randint(0,v52)
            v54 = v40[v53]
            v55 = v52 - (<unsigned long long>1)
            v56 = numpy.empty(v55,dtype=numpy.int32)
            v57 = Mut1((<unsigned long long>0))
            while method2(v55, v57):
                v59 = v57.v0
                v60 = v53 <= v59
                if v60:
                    v62 = v59 + (<unsigned long long>1)
                else:
                    v62 = v59
                v63 = v40[v62]
                v56[v59] = v63
                v64 = v59 + (<unsigned long long>1)
                v57.v0 = v64
            del v40
            del v57
            v65 = <float>v52
            v66 = (<float>1.000000) / v65
            v67 = libc.math.log(v66)
            v68 = v67 + v51
            v69 = v12.v2
            v70 = US2_1(v38)
            v71 = UH0_0(v70, v30)
            del v70
            v72 = US2_1(v54)
            v73 = UH0_0(v72, v33)
            del v72
            v74 = US3_0()
            v75 = Closure0(v38, v54, v12, v56, v33, v34, v35, v30, v31, v32, v68)
            del v30; del v33; del v56
            v76 = UH1_0(v68, v68, v71, v31, v32, v73, v34, v35, v38, (<unsigned char>0), (<signed long>1), v54, (<unsigned char>1), (<signed long>1), v74, (<unsigned char>0), v69, v75)
            del v69; del v71; del v73; del v74; del v75
            v26[v29] = v76
            del v76
            v77 = v29 + (<unsigned long long>1)
            v27.v0 = v77
        del v27
        v78 = method11(v21, v20, v26)
        del v26; del v78
        v22.step()
        v79 = v25 + (<signed long>1)
        v23.v0 = v79
    del v12; del v19; del v20; del v21; del v22
