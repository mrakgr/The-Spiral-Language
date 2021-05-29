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
cdef float method22(unsigned char v0, float v1, float v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8) except *:
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
cdef numpy.ndarray[float,ndim=1] method11(float v0, v1, v2, numpy.ndarray[object,ndim=1] v3):
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut1 v9
    cdef unsigned long long v11
    cdef UH1 v12
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
    cdef US3 v27
    cdef unsigned char v28
    cdef numpy.ndarray[signed long,ndim=1] v29
    cdef object v30
    cdef float v31
    cdef float v32
    cdef UH0 v33
    cdef float v34
    cdef float v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef US1 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef US3 v45
    cdef float v46
    cdef unsigned long long v47
    cdef unsigned long long v48
    cdef bint v49
    cdef numpy.ndarray[float,ndim=1] v277
    cdef unsigned long long v50
    cdef object v51
    cdef unsigned long long v52
    cdef Mut1 v53
    cdef unsigned long long v55
    cdef float v56
    cdef float v57
    cdef UH0 v58
    cdef float v59
    cdef float v60
    cdef UH0 v61
    cdef float v62
    cdef float v63
    cdef US1 v64
    cdef unsigned char v65
    cdef signed long v66
    cdef US1 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef US3 v70
    cdef unsigned char v71
    cdef numpy.ndarray[signed long,ndim=1] v72
    cdef Tuple1 tmp0
    cdef bint v73
    cdef UH0 v74
    cdef numpy.ndarray[object,ndim=1] v75
    cdef bint v76
    cdef signed long v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef US1 v80
    cdef numpy.ndarray[float,ndim=1] v81
    cdef bint v82
    cdef bint v84
    cdef unsigned long long v85
    cdef bint v86
    cdef bint v88
    cdef unsigned long long v89
    cdef unsigned long long v90
    cdef bint v91
    cdef Mut1 v92
    cdef unsigned long long v94
    cdef US1 v95
    cdef numpy.ndarray[signed long,ndim=1] v96
    cdef Tuple3 tmp1
    cdef unsigned long long v97
    cdef unsigned long long v98
    cdef unsigned long long v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef bint v103
    cdef Mut1 v104
    cdef unsigned long long v106
    cdef US0 v107
    cdef unsigned long long v108
    cdef unsigned long long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef unsigned long long v115
    cdef numpy.ndarray[object,ndim=1] v116
    cdef Mut1 v117
    cdef unsigned long long v119
    cdef float v120
    cdef float v121
    cdef UH0 v122
    cdef float v123
    cdef float v124
    cdef UH0 v125
    cdef float v126
    cdef float v127
    cdef US1 v128
    cdef unsigned char v129
    cdef signed long v130
    cdef US1 v131
    cdef unsigned char v132
    cdef signed long v133
    cdef US3 v134
    cdef unsigned char v135
    cdef numpy.ndarray[signed long,ndim=1] v136
    cdef Tuple1 tmp2
    cdef unsigned long long v137
    cdef numpy.ndarray[signed long long,ndim=1] v138
    cdef Mut1 v139
    cdef unsigned long long v141
    cdef US0 v142
    cdef signed long long v143
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef object v146
    cdef object v147
    cdef object v148
    cdef object v149
    cdef unsigned long long v150
    cdef Mut1 v151
    cdef unsigned long long v153
    cdef numpy.ndarray[signed long long,ndim=1] v154
    cdef unsigned long long v155
    cdef Mut1 v156
    cdef unsigned long long v158
    cdef signed long long v159
    cdef unsigned long long v160
    cdef unsigned long long v161
    cdef object v162
    cdef object v163
    cdef numpy.ndarray[signed long long,ndim=1] v164
    cdef unsigned long long v165
    cdef numpy.ndarray[object,ndim=1] v166
    cdef Mut1 v167
    cdef unsigned long long v169
    cdef signed long long v170
    cdef float v171
    cdef float v172
    cdef float v173
    cdef float v174
    cdef bint v175
    cdef US0 v192
    cdef bint v176
    cdef bint v177
    cdef bint v179
    cdef signed long long v180
    cdef bint v181
    cdef bint v182
    cdef bint v184
    cdef signed long long v185
    cdef bint v186
    cdef bint v187
    cdef unsigned long long v193
    cdef unsigned long long v194
    cdef unsigned long long v195
    cdef bint v196
    cdef bint v197
    cdef numpy.ndarray[object,ndim=1] v198
    cdef Mut1 v199
    cdef unsigned long long v201
    cdef object v202
    cdef float v203
    cdef float v204
    cdef US0 v205
    cdef Tuple0 tmp3
    cdef UH1 v206
    cdef unsigned long long v207
    cdef numpy.ndarray[float,ndim=1] v208
    cdef unsigned long long v209
    cdef bint v210
    cdef object v211
    cdef object v212
    cdef object v213
    cdef object v214
    cdef bint v215
    cdef bint v216
    cdef Mut1 v217
    cdef unsigned long long v219
    cdef signed long long v220
    cdef float v221
    cdef float v222
    cdef float v223
    cdef bint v224
    cdef float v225
    cdef float v226
    cdef float v227
    cdef UH0 v228
    cdef float v229
    cdef float v230
    cdef UH0 v231
    cdef float v232
    cdef float v233
    cdef US1 v234
    cdef unsigned char v235
    cdef signed long v236
    cdef US1 v237
    cdef unsigned char v238
    cdef signed long v239
    cdef US3 v240
    cdef unsigned char v241
    cdef numpy.ndarray[signed long,ndim=1] v242
    cdef Tuple1 tmp4
    cdef float v243
    cdef unsigned long long v244
    cdef object v245
    cdef unsigned long long v246
    cdef numpy.ndarray[float,ndim=1] v247
    cdef Mut1 v248
    cdef unsigned long long v250
    cdef float v251
    cdef float v252
    cdef UH0 v253
    cdef float v254
    cdef float v255
    cdef UH0 v256
    cdef float v257
    cdef float v258
    cdef US1 v259
    cdef unsigned char v260
    cdef signed long v261
    cdef US1 v262
    cdef unsigned char v263
    cdef signed long v264
    cdef US3 v265
    cdef unsigned char v266
    cdef numpy.ndarray[signed long,ndim=1] v267
    cdef Tuple1 tmp5
    cdef float v268
    cdef bint v269
    cdef float v270
    cdef float v271
    cdef unsigned long long v272
    cdef object v273
    cdef numpy.ndarray[float,ndim=1] v276
    cdef numpy.ndarray[float,ndim=1] v278
    cdef unsigned long long v279
    cdef unsigned long long v280
    cdef bint v281
    cdef bint v282
    cdef Mut1 v283
    cdef unsigned long long v285
    cdef unsigned long long v286
    cdef float v287
    cdef unsigned long long v288
    cdef unsigned long long v289
    cdef Mut1 v290
    cdef unsigned long long v292
    cdef unsigned long long v293
    cdef float v294
    cdef float v295
    cdef UH0 v296
    cdef float v297
    cdef float v298
    cdef UH0 v299
    cdef float v300
    cdef float v301
    cdef US1 v302
    cdef unsigned char v303
    cdef signed long v304
    cdef US1 v305
    cdef unsigned char v306
    cdef signed long v307
    cdef US3 v308
    cdef float v309
    cdef Tuple2 tmp6
    cdef unsigned long long v310
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = len(v3)
    v9 = Mut1((<unsigned long long>0))
    while method2(v8, v9):
        v11 = v9.v0
        v12 = v3[v11]
        if v12.tag == 0: # action_
            v13 = (<UH1_0>v12).v0; v14 = (<UH1_0>v12).v1; v15 = (<UH1_0>v12).v2; v16 = (<UH1_0>v12).v3; v17 = (<UH1_0>v12).v4; v18 = (<UH1_0>v12).v5; v19 = (<UH1_0>v12).v6; v20 = (<UH1_0>v12).v7; v21 = (<UH1_0>v12).v8; v22 = (<UH1_0>v12).v9; v23 = (<UH1_0>v12).v10; v24 = (<UH1_0>v12).v11; v25 = (<UH1_0>v12).v12; v26 = (<UH1_0>v12).v13; v27 = (<UH1_0>v12).v14; v28 = (<UH1_0>v12).v15; v29 = (<UH1_0>v12).v16; v30 = (<UH1_0>v12).v17
            v5.append(v11)
            v6.append(Tuple1(v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29))
            del v15; del v18; del v27; del v29
            v7.append(v30)
            del v30
        elif v12.tag == 1: # terminal_
            v31 = (<UH1_1>v12).v0; v32 = (<UH1_1>v12).v1; v33 = (<UH1_1>v12).v2; v34 = (<UH1_1>v12).v3; v35 = (<UH1_1>v12).v4; v36 = (<UH1_1>v12).v5; v37 = (<UH1_1>v12).v6; v38 = (<UH1_1>v12).v7; v39 = (<UH1_1>v12).v8; v40 = (<UH1_1>v12).v9; v41 = (<UH1_1>v12).v10; v42 = (<UH1_1>v12).v11; v43 = (<UH1_1>v12).v12; v44 = (<UH1_1>v12).v13; v45 = (<UH1_1>v12).v14; v46 = (<UH1_1>v12).v15
            v4.append(Tuple2(v11, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46))
            del v33; del v36; del v45
        del v12
        v47 = v11 + (<unsigned long long>1)
        v9.v0 = v47
    del v9
    v48 = len(v6)
    v49 = (<unsigned long long>0) < v48
    if v49:
        v50 = len(v6)
        v51 = torch.zeros(v50,(<unsigned long long>48))
        v52 = len(v6)
        v53 = Mut1((<unsigned long long>0))
        while method2(v52, v53):
            v55 = v53.v0
            tmp0 = v6[v55]
            v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
            del tmp0
            del v70; del v72
            v73 = v71 == (<unsigned char>0)
            if v73:
                v74 = v58
            else:
                v74 = v61
            del v58; del v61
            v75 = method12(v74)
            del v74
            v76 = v71 == v65
            if v76:
                v77 = v66
            else:
                v77 = v69
            v78 = v71
            v79 = v77
            if v76:
                v80 = v67
            else:
                v80 = v64
            v81 = v51[v55,:].numpy()
            v82 = (<unsigned long long>0) <= v78
            if v82:
                v84 = v78 < (<unsigned long long>2)
            else:
                v84 = 0
            if v84:
                v81[v78] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v85 = v79 - (<unsigned long long>1)
            v86 = (<unsigned long long>0) <= v85
            if v86:
                v88 = v85 < (<unsigned long long>13)
            else:
                v88 = 0
            if v88:
                v89 = (<unsigned long long>2) + v85
                v81[v89] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v90 = len(v75)
            v91 = (<unsigned long long>2) < v90
            if v91:
                raise Exception("The given array is too large.")
            else:
                pass
            v92 = Mut1((<unsigned long long>0))
            while method2(v90, v92):
                v94 = v92.v0
                tmp1 = v75[v94]
                v95, v96 = tmp1.v0, tmp1.v1
                del tmp1
                v97 = v94 * (<unsigned long long>15)
                v98 = (<unsigned long long>15) + v97
                if v95 == 0: # jack
                    v81[v98] = (<float>1.000000)
                elif v95 == 1: # king
                    v99 = v98 + (<unsigned long long>1)
                    v81[v99] = (<float>1.000000)
                elif v95 == 2: # queen
                    v100 = v98 + (<unsigned long long>2)
                    v81[v100] = (<float>1.000000)
                v101 = v98 + (<unsigned long long>3)
                v102 = len(v96)
                v103 = (<unsigned long long>4) < v102
                if v103:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v104 = Mut1((<unsigned long long>0))
                while method2(v102, v104):
                    v106 = v104.v0
                    v107 = v96[v106]
                    v108 = v106 * (<unsigned long long>3)
                    v109 = v101 + v108
                    if v107 == 0: # call
                        v81[v109] = (<float>1.000000)
                    elif v107 == 1: # fold
                        v110 = v109 + (<unsigned long long>1)
                        v81[v110] = (<float>1.000000)
                    elif v107 == 2: # raise
                        v111 = v109 + (<unsigned long long>2)
                        v81[v111] = (<float>1.000000)
                    v112 = v106 + (<unsigned long long>1)
                    v104.v0 = v112
                del v96
                del v104
                v113 = v94 + (<unsigned long long>1)
                v92.v0 = v113
            del v75
            del v92
            if v80 == 0: # jack
                v81[(<unsigned long long>45)] = (<float>1.000000)
            elif v80 == 1: # king
                v81[(<unsigned long long>46)] = (<float>1.000000)
            elif v80 == 2: # queen
                v81[(<unsigned long long>47)] = (<float>1.000000)
            del v81
            v114 = v55 + (<unsigned long long>1)
            v53.v0 = v114
        del v53
        v115 = len(v6)
        v116 = numpy.empty(v115,dtype=object)
        v117 = Mut1((<unsigned long long>0))
        while method2(v115, v117):
            v119 = v117.v0
            tmp2 = v6[v119]
            v120, v121, v122, v123, v124, v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135, v136 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16
            del tmp2
            del v122; del v125; del v134
            v137 = len(v136)
            v138 = numpy.empty(v137,dtype=numpy.int64)
            v139 = Mut1((<unsigned long long>0))
            while method2(v137, v139):
                v141 = v139.v0
                v142 = v136[v141]
                if v142 == 0: # call
                    v143 = (<signed long long>0)
                elif v142 == 1: # fold
                    v143 = (<signed long long>1)
                elif v142 == 2: # raise
                    v143 = (<signed long long>2)
                v138[v141] = v143
                v144 = v141 + (<unsigned long long>1)
                v139.v0 = v144
            del v136
            del v139
            v116[v119] = v138
            del v138
            v145 = v119 + (<unsigned long long>1)
            v117.v0 = v145
        del v117
        v146 = v2[0].forward(v51[:,:(<unsigned long long>45)])
        v147 = torch.empty_like(v146).bernoulli_(v0) / v0
        v148 = v2[1].forward(v146 * v147 if v0 < 1 else v146)
        del v146
        v149 = torch.full((v50,(<signed long long>3)),float('-inf'))
        v150 = len(v116)
        v151 = Mut1((<unsigned long long>0))
        while method2(v150, v151):
            v153 = v151.v0
            v154 = v116[v153]
            v155 = len(v154)
            v156 = Mut1((<unsigned long long>0))
            while method2(v155, v156):
                v158 = v156.v0
                v159 = v154[v158]
                v149[v153,v159] = 0
                v160 = v158 + (<unsigned long long>1)
                v156.v0 = v160
            del v154
            del v156
            v161 = v153 + (<unsigned long long>1)
            v151.v0 = v161
        del v116
        del v151
        v162 = torch.log_softmax(v149 + v148.cpu(),dim=-1)
        del v148; del v149
        v163 = torch.exp(v162.detach())
        v164 = torch.distributions.Categorical(v163).sample().numpy()
        v165 = len(v164)
        v166 = numpy.empty(v165,dtype=object)
        v167 = Mut1((<unsigned long long>0))
        while method2(v165, v167):
            v169 = v167.v0
            v170 = v164[v169]
            v171 = v163[v169,v170]
            v172 = v163[v169,v170]
            v173 = libc.math.log(v172)
            v174 = libc.math.log(v171)
            v175 = v170 < (<signed long long>1)
            if v175:
                v176 = v170 == (<signed long long>0)
                v177 = v176 == 0
                if v177:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v192 = 0
            else:
                v179 = v170 < (<signed long long>2)
                if v179:
                    v180 = v170 - (<signed long long>1)
                    v181 = v180 == (<signed long long>0)
                    v182 = v181 == 0
                    if v182:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v192 = 1
                else:
                    v184 = v170 < (<signed long long>3)
                    if v184:
                        v185 = v170 - (<signed long long>2)
                        v186 = v185 == (<signed long long>0)
                        v187 = v186 == 0
                        if v187:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v192 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v166[v169] = Tuple0(v174, v173, v192)
            v193 = v169 + (<unsigned long long>1)
            v167.v0 = v193
        del v167
        v194 = len(v7)
        v195 = len(v166)
        v196 = v194 == v195
        v197 = v196 == 0
        if v197:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v198 = numpy.empty(v194,dtype=object)
        v199 = Mut1((<unsigned long long>0))
        while method2(v194, v199):
            v201 = v199.v0
            v202 = v7[v201]
            tmp3 = v166[v201]
            v203, v204, v205 = tmp3.v0, tmp3.v1, tmp3.v2
            del tmp3
            v206 = v202(Tuple0(v203, v204, v205))
            del v202
            v198[v201] = v206
            del v206
            v207 = v201 + (<unsigned long long>1)
            v199.v0 = v207
        del v166
        del v199
        v208 = method11(v0, v1, v2, v198)
        del v198
        v209 = len(v208)
        v210 = v209 == (<unsigned long long>0)
        if v210:
            v277 = v208
        else:
            v211 = v1[0].forward(v51)
            v212 = v1[1](v211 * v147 if v0 < 1 else v211).cpu()
            del v211
            v213 = v212.detach().clone()
            v214 = torch.zeros_like(v212)
            v215 = v165 == v209
            v216 = v215 == 0
            if v216:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v217 = Mut1((<unsigned long long>0))
            while method2(v165, v217):
                v219 = v217.v0
                v220 = v164[v219]
                v221 = v208[v219]
                v222 = v163[v219,v220]
                v223 = v213[v219,v220]
                v224 = libc.math.isnan(v223)
                if v224:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v225 = v221 - v223
                tmp4 = v6[v219]
                v226, v227, v228, v229, v230, v231, v232, v233, v234, v235, v236, v237, v238, v239, v240, v241, v242 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3, tmp4.v4, tmp4.v5, tmp4.v6, tmp4.v7, tmp4.v8, tmp4.v9, tmp4.v10, tmp4.v11, tmp4.v12, tmp4.v13, tmp4.v14, tmp4.v15, tmp4.v16
                del tmp4
                del v240; del v242
                v243 = method22(v241, v226, v227, v228, v229, v230, v231, v232, v233)
                del v228; del v231
                v214[v219,v220] -= v225 * v243
                v213[v219,v220] += v225 / v222
                v244 = v219 + (<unsigned long long>1)
                v217.v0 = v244
            del v217
            v212.backward(v214)
            del v212; del v214
            v245 = torch.einsum('ab,ab->a',v213,v163)
            v246 = len(v6)
            v247 = numpy.empty(v246,dtype=numpy.float32)
            v248 = Mut1((<unsigned long long>0))
            while method2(v246, v248):
                v250 = v248.v0
                tmp5 = v6[v250]
                v251, v252, v253, v254, v255, v256, v257, v258, v259, v260, v261, v262, v263, v264, v265, v266, v267 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4, tmp5.v5, tmp5.v6, tmp5.v7, tmp5.v8, tmp5.v9, tmp5.v10, tmp5.v11, tmp5.v12, tmp5.v13, tmp5.v14, tmp5.v15, tmp5.v16
                del tmp5
                del v265; del v267
                v268 = method22(v266, v251, v252, v253, v254, v255, v256, v257, v258)
                del v253; del v256
                v269 = v266 == (<unsigned char>0)
                if v269:
                    v270 = (<float>1.000000)
                else:
                    v270 = (<float>-1.000000)
                v271 = v268 * v270
                v247[v250] = v271
                v272 = v250 + (<unsigned long long>1)
                v248.v0 = v272
            del v248
            v273 = torch.from_numpy(v247)
            del v247
            v162.backward(v273.unsqueeze(-1) * (v245.unsqueeze(-1) - v213))
            del v213; del v273
            v277 = v245.numpy()
            del v245
        del v51; del v147; del v162; del v163; del v164; del v208
    else:
        v276 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v277 = v276
        del v276
    del v6; del v7
    v278 = numpy.empty(v8,dtype=numpy.float32)
    v279 = len(v5)
    v280 = len(v277)
    v281 = v279 == v280
    v282 = v281 == 0
    if v282:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v283 = Mut1((<unsigned long long>0))
    while method2(v279, v283):
        v285 = v283.v0
        v286 = v5[v285]
        v287 = v277[v285]
        v278[v286] = v287
        v288 = v285 + (<unsigned long long>1)
        v283.v0 = v288
    del v5; del v277
    del v283
    v289 = len(v4)
    v290 = Mut1((<unsigned long long>0))
    while method2(v289, v290):
        v292 = v290.v0
        tmp6 = v4[v292]
        v293, v294, v295, v296, v297, v298, v299, v300, v301, v302, v303, v304, v305, v306, v307, v308, v309 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4, tmp6.v5, tmp6.v6, tmp6.v7, tmp6.v8, tmp6.v9, tmp6.v10, tmp6.v11, tmp6.v12, tmp6.v13, tmp6.v14, tmp6.v15, tmp6.v16
        del tmp6
        del v296; del v299; del v308
        v278[v293] = v309
        v310 = v292 + (<unsigned long long>1)
        v290.v0 = v310
    del v4
    del v290
    return v278
cdef bint method23(Mut1 v0) except *:
    cdef unsigned long long v1
    v1 = v0.v0
    return v1 < (<unsigned long long>10240)
cdef bint method25(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method24(float v0, v1, v2, numpy.ndarray[object,ndim=1] v3):
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef Mut1 v12
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
    cdef US3 v30
    cdef unsigned char v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef object v33
    cdef bint v34
    cdef float v35
    cdef float v36
    cdef UH0 v37
    cdef float v38
    cdef float v39
    cdef UH0 v40
    cdef float v41
    cdef float v42
    cdef US1 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef US1 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef US3 v49
    cdef float v50
    cdef unsigned long long v51
    cdef unsigned long long v52
    cdef bint v53
    cdef list v372
    cdef unsigned long long v54
    cdef list v55
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
    cdef Tuple1 tmp7
    cdef unsigned long long v76
    cdef float v77
    cdef float v78
    cdef float v79
    cdef US0 v80
    cdef unsigned long long v81
    cdef unsigned long long v82
    cdef object v83
    cdef unsigned long long v84
    cdef Mut1 v85
    cdef unsigned long long v87
    cdef float v88
    cdef float v89
    cdef UH0 v90
    cdef float v91
    cdef float v92
    cdef UH0 v93
    cdef float v94
    cdef float v95
    cdef US1 v96
    cdef unsigned char v97
    cdef signed long v98
    cdef US1 v99
    cdef unsigned char v100
    cdef signed long v101
    cdef US3 v102
    cdef unsigned char v103
    cdef numpy.ndarray[signed long,ndim=1] v104
    cdef Tuple1 tmp8
    cdef bint v105
    cdef UH0 v106
    cdef numpy.ndarray[object,ndim=1] v107
    cdef bint v108
    cdef signed long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef US1 v112
    cdef numpy.ndarray[float,ndim=1] v113
    cdef bint v114
    cdef bint v116
    cdef unsigned long long v117
    cdef bint v118
    cdef bint v120
    cdef unsigned long long v121
    cdef unsigned long long v122
    cdef bint v123
    cdef Mut1 v124
    cdef unsigned long long v126
    cdef US1 v127
    cdef numpy.ndarray[signed long,ndim=1] v128
    cdef Tuple3 tmp9
    cdef unsigned long long v129
    cdef unsigned long long v130
    cdef unsigned long long v131
    cdef unsigned long long v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef bint v135
    cdef Mut1 v136
    cdef unsigned long long v138
    cdef US0 v139
    cdef unsigned long long v140
    cdef unsigned long long v141
    cdef unsigned long long v142
    cdef unsigned long long v143
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef unsigned long long v147
    cdef numpy.ndarray[object,ndim=1] v148
    cdef Mut1 v149
    cdef unsigned long long v151
    cdef float v152
    cdef float v153
    cdef UH0 v154
    cdef float v155
    cdef float v156
    cdef UH0 v157
    cdef float v158
    cdef float v159
    cdef US1 v160
    cdef unsigned char v161
    cdef signed long v162
    cdef US1 v163
    cdef unsigned char v164
    cdef signed long v165
    cdef US3 v166
    cdef unsigned char v167
    cdef numpy.ndarray[signed long,ndim=1] v168
    cdef Tuple1 tmp10
    cdef unsigned long long v169
    cdef numpy.ndarray[signed long long,ndim=1] v170
    cdef Mut1 v171
    cdef unsigned long long v173
    cdef US0 v174
    cdef signed long long v175
    cdef unsigned long long v176
    cdef unsigned long long v177
    cdef object v178
    cdef object v179
    cdef object v180
    cdef object v181
    cdef unsigned long long v182
    cdef Mut1 v183
    cdef unsigned long long v185
    cdef numpy.ndarray[signed long long,ndim=1] v186
    cdef unsigned long long v187
    cdef Mut1 v188
    cdef unsigned long long v190
    cdef signed long long v191
    cdef unsigned long long v192
    cdef unsigned long long v193
    cdef object v194
    cdef object v195
    cdef numpy.ndarray[signed long long,ndim=1] v196
    cdef unsigned long long v197
    cdef numpy.ndarray[object,ndim=1] v198
    cdef Mut1 v199
    cdef unsigned long long v201
    cdef signed long long v202
    cdef float v203
    cdef float v204
    cdef float v205
    cdef float v206
    cdef bint v207
    cdef US0 v224
    cdef bint v208
    cdef bint v209
    cdef bint v211
    cdef signed long long v212
    cdef bint v213
    cdef bint v214
    cdef bint v216
    cdef signed long long v217
    cdef bint v218
    cdef bint v219
    cdef unsigned long long v225
    cdef unsigned long long v226
    cdef unsigned long long v227
    cdef bint v228
    cdef bint v229
    cdef numpy.ndarray[object,ndim=1] v230
    cdef Mut1 v231
    cdef unsigned long long v233
    cdef object v234
    cdef float v235
    cdef float v236
    cdef US0 v237
    cdef Tuple0 tmp11
    cdef UH1 v238
    cdef unsigned long long v239
    cdef unsigned long long v240
    cdef unsigned long long v241
    cdef bint v242
    cdef bint v243
    cdef numpy.ndarray[object,ndim=1] v244
    cdef Mut1 v245
    cdef unsigned long long v247
    cdef object v248
    cdef float v249
    cdef float v250
    cdef US0 v251
    cdef Tuple0 tmp12
    cdef UH1 v252
    cdef unsigned long long v253
    cdef unsigned long long v254
    cdef unsigned long long v255
    cdef unsigned long long v256
    cdef numpy.ndarray[object,ndim=1] v257
    cdef Mut1 v258
    cdef unsigned long long v260
    cdef bint v261
    cdef UH1 v265
    cdef unsigned long long v263
    cdef unsigned long long v266
    cdef numpy.ndarray[float,ndim=1] v267
    cdef unsigned long long v268
    cdef numpy.ndarray[float,ndim=1] v269
    cdef Mut1 v270
    cdef unsigned long long v272
    cdef float v273
    cdef unsigned long long v274
    cdef unsigned long long v275
    cdef unsigned long long v276
    cdef unsigned long long v277
    cdef numpy.ndarray[float,ndim=1] v278
    cdef Mut1 v279
    cdef unsigned long long v281
    cdef unsigned long long v282
    cdef float v283
    cdef unsigned long long v284
    cdef unsigned long long v285
    cdef bint v286
    cdef numpy.ndarray[float,ndim=1] v351
    cdef object v287
    cdef object v288
    cdef object v289
    cdef object v290
    cdef bint v291
    cdef bint v292
    cdef Mut1 v293
    cdef unsigned long long v295
    cdef signed long long v296
    cdef float v297
    cdef float v298
    cdef float v299
    cdef bint v300
    cdef float v301
    cdef float v302
    cdef float v303
    cdef UH0 v304
    cdef float v305
    cdef float v306
    cdef UH0 v307
    cdef float v308
    cdef float v309
    cdef US1 v310
    cdef unsigned char v311
    cdef signed long v312
    cdef US1 v313
    cdef unsigned char v314
    cdef signed long v315
    cdef US3 v316
    cdef unsigned char v317
    cdef numpy.ndarray[signed long,ndim=1] v318
    cdef Tuple1 tmp13
    cdef float v319
    cdef unsigned long long v320
    cdef object v321
    cdef unsigned long long v322
    cdef numpy.ndarray[float,ndim=1] v323
    cdef Mut1 v324
    cdef unsigned long long v326
    cdef float v327
    cdef float v328
    cdef UH0 v329
    cdef float v330
    cdef float v331
    cdef UH0 v332
    cdef float v333
    cdef float v334
    cdef US1 v335
    cdef unsigned char v336
    cdef signed long v337
    cdef US1 v338
    cdef unsigned char v339
    cdef signed long v340
    cdef US3 v341
    cdef unsigned char v342
    cdef numpy.ndarray[signed long,ndim=1] v343
    cdef Tuple1 tmp14
    cdef float v344
    cdef bint v345
    cdef float v346
    cdef float v347
    cdef unsigned long long v348
    cdef object v349
    cdef unsigned long long v352
    cdef list v353
    cdef Mut2 v354
    cdef unsigned long long v356
    cdef unsigned long long v357
    cdef unsigned long long v358
    cdef unsigned char v359
    cdef bint v360
    cdef float v365
    cdef unsigned long long v366
    cdef unsigned long long v367
    cdef float v361
    cdef unsigned long long v362
    cdef float v363
    cdef unsigned long long v364
    cdef unsigned long long v368
    cdef unsigned long long v369
    cdef unsigned long long v370
    cdef numpy.ndarray[float,ndim=1] v373
    cdef unsigned long long v374
    cdef unsigned long long v375
    cdef bint v376
    cdef bint v377
    cdef Mut1 v378
    cdef unsigned long long v380
    cdef unsigned long long v381
    cdef float v382
    cdef unsigned long long v383
    cdef unsigned long long v384
    cdef Mut1 v385
    cdef unsigned long long v387
    cdef unsigned long long v388
    cdef float v389
    cdef float v390
    cdef UH0 v391
    cdef float v392
    cdef float v393
    cdef UH0 v394
    cdef float v395
    cdef float v396
    cdef US1 v397
    cdef unsigned char v398
    cdef signed long v399
    cdef US1 v400
    cdef unsigned char v401
    cdef signed long v402
    cdef US3 v403
    cdef float v404
    cdef Tuple2 tmp15
    cdef unsigned long long v405
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = len(v3)
    v12 = Mut1((<unsigned long long>0))
    while method2(v11, v12):
        v14 = v12.v0
        v15 = v3[v14]
        if v15.tag == 0: # action_
            v16 = (<UH1_0>v15).v0; v17 = (<UH1_0>v15).v1; v18 = (<UH1_0>v15).v2; v19 = (<UH1_0>v15).v3; v20 = (<UH1_0>v15).v4; v21 = (<UH1_0>v15).v5; v22 = (<UH1_0>v15).v6; v23 = (<UH1_0>v15).v7; v24 = (<UH1_0>v15).v8; v25 = (<UH1_0>v15).v9; v26 = (<UH1_0>v15).v10; v27 = (<UH1_0>v15).v11; v28 = (<UH1_0>v15).v12; v29 = (<UH1_0>v15).v13; v30 = (<UH1_0>v15).v14; v31 = (<UH1_0>v15).v15; v32 = (<UH1_0>v15).v16; v33 = (<UH1_0>v15).v17
            v5.append(v14)
            v34 = v31 == (<unsigned char>0)
            if v34:
                v6.append(Tuple1(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
                v8.append(v33)
            else:
                v7.append(Tuple1(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
                v9.append(v33)
            del v18; del v21; del v30; del v32; del v33
            v10.append(v31)
        elif v15.tag == 1: # terminal_
            v35 = (<UH1_1>v15).v0; v36 = (<UH1_1>v15).v1; v37 = (<UH1_1>v15).v2; v38 = (<UH1_1>v15).v3; v39 = (<UH1_1>v15).v4; v40 = (<UH1_1>v15).v5; v41 = (<UH1_1>v15).v6; v42 = (<UH1_1>v15).v7; v43 = (<UH1_1>v15).v8; v44 = (<UH1_1>v15).v9; v45 = (<UH1_1>v15).v10; v46 = (<UH1_1>v15).v11; v47 = (<UH1_1>v15).v12; v48 = (<UH1_1>v15).v13; v49 = (<UH1_1>v15).v14; v50 = (<UH1_1>v15).v15
            v4.append(Tuple2(v14, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50))
            del v37; del v40; del v49
        del v15
        v51 = v14 + (<unsigned long long>1)
        v12.v0 = v51
    del v12
    v52 = len(v10)
    v53 = (<unsigned long long>0) < v52
    if v53:
        v54 = len(v6)
        v55 = [None]*v54
        v56 = Mut1((<unsigned long long>0))
        while method2(v54, v56):
            v58 = v56.v0
            tmp7 = v6[v58]
            v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3, tmp7.v4, tmp7.v5, tmp7.v6, tmp7.v7, tmp7.v8, tmp7.v9, tmp7.v10, tmp7.v11, tmp7.v12, tmp7.v13, tmp7.v14, tmp7.v15, tmp7.v16
            del tmp7
            del v61; del v64; del v73
            v76 = len(v75)
            v77 = <float>v76
            v78 = (<float>1.000000) / v77
            v79 = libc.math.log(v78)
            v80 = numpy.random.choice(v75)
            del v75
            v55[v58] = Tuple0(v79, v79, v80)
            v81 = v58 + (<unsigned long long>1)
            v56.v0 = v81
        del v56
        v82 = len(v7)
        v83 = torch.zeros(v82,(<unsigned long long>48))
        v84 = len(v7)
        v85 = Mut1((<unsigned long long>0))
        while method2(v84, v85):
            v87 = v85.v0
            tmp8 = v7[v87]
            v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3, tmp8.v4, tmp8.v5, tmp8.v6, tmp8.v7, tmp8.v8, tmp8.v9, tmp8.v10, tmp8.v11, tmp8.v12, tmp8.v13, tmp8.v14, tmp8.v15, tmp8.v16
            del tmp8
            del v102; del v104
            v105 = v103 == (<unsigned char>0)
            if v105:
                v106 = v90
            else:
                v106 = v93
            del v90; del v93
            v107 = method12(v106)
            del v106
            v108 = v103 == v97
            if v108:
                v109 = v98
            else:
                v109 = v101
            v110 = v103
            v111 = v109
            if v108:
                v112 = v99
            else:
                v112 = v96
            v113 = v83[v87,:].numpy()
            v114 = (<unsigned long long>0) <= v110
            if v114:
                v116 = v110 < (<unsigned long long>2)
            else:
                v116 = 0
            if v116:
                v113[v110] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v117 = v111 - (<unsigned long long>1)
            v118 = (<unsigned long long>0) <= v117
            if v118:
                v120 = v117 < (<unsigned long long>13)
            else:
                v120 = 0
            if v120:
                v121 = (<unsigned long long>2) + v117
                v113[v121] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v122 = len(v107)
            v123 = (<unsigned long long>2) < v122
            if v123:
                raise Exception("The given array is too large.")
            else:
                pass
            v124 = Mut1((<unsigned long long>0))
            while method2(v122, v124):
                v126 = v124.v0
                tmp9 = v107[v126]
                v127, v128 = tmp9.v0, tmp9.v1
                del tmp9
                v129 = v126 * (<unsigned long long>15)
                v130 = (<unsigned long long>15) + v129
                if v127 == 0: # jack
                    v113[v130] = (<float>1.000000)
                elif v127 == 1: # king
                    v131 = v130 + (<unsigned long long>1)
                    v113[v131] = (<float>1.000000)
                elif v127 == 2: # queen
                    v132 = v130 + (<unsigned long long>2)
                    v113[v132] = (<float>1.000000)
                v133 = v130 + (<unsigned long long>3)
                v134 = len(v128)
                v135 = (<unsigned long long>4) < v134
                if v135:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v136 = Mut1((<unsigned long long>0))
                while method2(v134, v136):
                    v138 = v136.v0
                    v139 = v128[v138]
                    v140 = v138 * (<unsigned long long>3)
                    v141 = v133 + v140
                    if v139 == 0: # call
                        v113[v141] = (<float>1.000000)
                    elif v139 == 1: # fold
                        v142 = v141 + (<unsigned long long>1)
                        v113[v142] = (<float>1.000000)
                    elif v139 == 2: # raise
                        v143 = v141 + (<unsigned long long>2)
                        v113[v143] = (<float>1.000000)
                    v144 = v138 + (<unsigned long long>1)
                    v136.v0 = v144
                del v128
                del v136
                v145 = v126 + (<unsigned long long>1)
                v124.v0 = v145
            del v107
            del v124
            if v112 == 0: # jack
                v113[(<unsigned long long>45)] = (<float>1.000000)
            elif v112 == 1: # king
                v113[(<unsigned long long>46)] = (<float>1.000000)
            elif v112 == 2: # queen
                v113[(<unsigned long long>47)] = (<float>1.000000)
            del v113
            v146 = v87 + (<unsigned long long>1)
            v85.v0 = v146
        del v85
        v147 = len(v7)
        v148 = numpy.empty(v147,dtype=object)
        v149 = Mut1((<unsigned long long>0))
        while method2(v147, v149):
            v151 = v149.v0
            tmp10 = v7[v151]
            v152, v153, v154, v155, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3, tmp10.v4, tmp10.v5, tmp10.v6, tmp10.v7, tmp10.v8, tmp10.v9, tmp10.v10, tmp10.v11, tmp10.v12, tmp10.v13, tmp10.v14, tmp10.v15, tmp10.v16
            del tmp10
            del v154; del v157; del v166
            v169 = len(v168)
            v170 = numpy.empty(v169,dtype=numpy.int64)
            v171 = Mut1((<unsigned long long>0))
            while method2(v169, v171):
                v173 = v171.v0
                v174 = v168[v173]
                if v174 == 0: # call
                    v175 = (<signed long long>0)
                elif v174 == 1: # fold
                    v175 = (<signed long long>1)
                elif v174 == 2: # raise
                    v175 = (<signed long long>2)
                v170[v173] = v175
                v176 = v173 + (<unsigned long long>1)
                v171.v0 = v176
            del v168
            del v171
            v148[v151] = v170
            del v170
            v177 = v151 + (<unsigned long long>1)
            v149.v0 = v177
        del v149
        v178 = v2[0].forward(v83[:,:(<unsigned long long>45)])
        v179 = torch.empty_like(v178).bernoulli_(v0) / v0
        v180 = v2[1].forward(v178 * v179 if v0 < 1 else v178)
        del v178
        v181 = torch.full((v82,(<signed long long>3)),float('-inf'))
        v182 = len(v148)
        v183 = Mut1((<unsigned long long>0))
        while method2(v182, v183):
            v185 = v183.v0
            v186 = v148[v185]
            v187 = len(v186)
            v188 = Mut1((<unsigned long long>0))
            while method2(v187, v188):
                v190 = v188.v0
                v191 = v186[v190]
                v181[v185,v191] = 0
                v192 = v190 + (<unsigned long long>1)
                v188.v0 = v192
            del v186
            del v188
            v193 = v185 + (<unsigned long long>1)
            v183.v0 = v193
        del v148
        del v183
        v194 = torch.log_softmax(v181 + v180.cpu(),dim=-1)
        del v180; del v181
        v195 = torch.exp(v194.detach())
        v196 = torch.distributions.Categorical(v195).sample().numpy()
        v197 = len(v196)
        v198 = numpy.empty(v197,dtype=object)
        v199 = Mut1((<unsigned long long>0))
        while method2(v197, v199):
            v201 = v199.v0
            v202 = v196[v201]
            v203 = v195[v201,v202]
            v204 = v195[v201,v202]
            v205 = libc.math.log(v204)
            v206 = libc.math.log(v203)
            v207 = v202 < (<signed long long>1)
            if v207:
                v208 = v202 == (<signed long long>0)
                v209 = v208 == 0
                if v209:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v224 = 0
            else:
                v211 = v202 < (<signed long long>2)
                if v211:
                    v212 = v202 - (<signed long long>1)
                    v213 = v212 == (<signed long long>0)
                    v214 = v213 == 0
                    if v214:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v224 = 1
                else:
                    v216 = v202 < (<signed long long>3)
                    if v216:
                        v217 = v202 - (<signed long long>2)
                        v218 = v217 == (<signed long long>0)
                        v219 = v218 == 0
                        if v219:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v224 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v198[v201] = Tuple0(v206, v205, v224)
            v225 = v201 + (<unsigned long long>1)
            v199.v0 = v225
        del v199
        v226 = len(v8)
        v227 = len(v55)
        v228 = v226 == v227
        v229 = v228 == 0
        if v229:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v230 = numpy.empty(v226,dtype=object)
        v231 = Mut1((<unsigned long long>0))
        while method2(v226, v231):
            v233 = v231.v0
            v234 = v8[v233]
            tmp11 = v55[v233]
            v235, v236, v237 = tmp11.v0, tmp11.v1, tmp11.v2
            del tmp11
            v238 = v234(Tuple0(v235, v236, v237))
            del v234
            v230[v233] = v238
            del v238
            v239 = v233 + (<unsigned long long>1)
            v231.v0 = v239
        del v231
        v240 = len(v9)
        v241 = len(v198)
        v242 = v240 == v241
        v243 = v242 == 0
        if v243:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v244 = numpy.empty(v240,dtype=object)
        v245 = Mut1((<unsigned long long>0))
        while method2(v240, v245):
            v247 = v245.v0
            v248 = v9[v247]
            tmp12 = v198[v247]
            v249, v250, v251 = tmp12.v0, tmp12.v1, tmp12.v2
            del tmp12
            v252 = v248(Tuple0(v249, v250, v251))
            del v248
            v244[v247] = v252
            del v252
            v253 = v247 + (<unsigned long long>1)
            v245.v0 = v253
        del v198
        del v245
        v254 = len(v230)
        v255 = len(v244)
        v256 = v254 + v255
        v257 = numpy.empty(v256,dtype=object)
        v258 = Mut1((<unsigned long long>0))
        while method2(v256, v258):
            v260 = v258.v0
            v261 = v260 < v254
            if v261:
                v265 = v230[v260]
            else:
                v263 = v260 - v254
                v265 = v244[v263]
            v257[v260] = v265
            del v265
            v266 = v260 + (<unsigned long long>1)
            v258.v0 = v266
        del v230; del v244
        del v258
        v267 = method24(v0, v1, v2, v257)
        del v257
        v268 = len(v55)
        v269 = numpy.empty(v268,dtype=numpy.float32)
        v270 = Mut1((<unsigned long long>0))
        while method2(v268, v270):
            v272 = v270.v0
            v273 = v267[v272]
            v269[v272] = v273
            v274 = v272 + (<unsigned long long>1)
            v270.v0 = v274
        del v270
        v275 = len(v55)
        del v55
        v276 = len(v267)
        v277 = v276 - v275
        v278 = numpy.empty(v277,dtype=numpy.float32)
        v279 = Mut1((<unsigned long long>0))
        while method2(v277, v279):
            v281 = v279.v0
            v282 = v281 + v275
            v283 = v267[v282]
            v278[v281] = v283
            v284 = v281 + (<unsigned long long>1)
            v279.v0 = v284
        del v267
        del v279
        v285 = len(v278)
        v286 = v285 == (<unsigned long long>0)
        if v286:
            v351 = v278
        else:
            v287 = v1[0].forward(v83)
            v288 = v1[1](v287 * v179 if v0 < 1 else v287).cpu()
            del v287
            v289 = v288.detach().clone()
            v290 = torch.zeros_like(v288)
            v291 = v197 == v285
            v292 = v291 == 0
            if v292:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v293 = Mut1((<unsigned long long>0))
            while method2(v197, v293):
                v295 = v293.v0
                v296 = v196[v295]
                v297 = v278[v295]
                v298 = v195[v295,v296]
                v299 = v289[v295,v296]
                v300 = libc.math.isnan(v299)
                if v300:
                    raise Exception("The value prediction is nan.")
                else:
                    pass
                v301 = v297 - v299
                tmp13 = v7[v295]
                v302, v303, v304, v305, v306, v307, v308, v309, v310, v311, v312, v313, v314, v315, v316, v317, v318 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3, tmp13.v4, tmp13.v5, tmp13.v6, tmp13.v7, tmp13.v8, tmp13.v9, tmp13.v10, tmp13.v11, tmp13.v12, tmp13.v13, tmp13.v14, tmp13.v15, tmp13.v16
                del tmp13
                del v316; del v318
                v319 = method22(v317, v302, v303, v304, v305, v306, v307, v308, v309)
                del v304; del v307
                v290[v295,v296] -= v301 * v319
                v289[v295,v296] += v301 / v298
                v320 = v295 + (<unsigned long long>1)
                v293.v0 = v320
            del v293
            v288.backward(v290)
            del v288; del v290
            v321 = torch.einsum('ab,ab->a',v289,v195)
            v322 = len(v7)
            v323 = numpy.empty(v322,dtype=numpy.float32)
            v324 = Mut1((<unsigned long long>0))
            while method2(v322, v324):
                v326 = v324.v0
                tmp14 = v7[v326]
                v327, v328, v329, v330, v331, v332, v333, v334, v335, v336, v337, v338, v339, v340, v341, v342, v343 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3, tmp14.v4, tmp14.v5, tmp14.v6, tmp14.v7, tmp14.v8, tmp14.v9, tmp14.v10, tmp14.v11, tmp14.v12, tmp14.v13, tmp14.v14, tmp14.v15, tmp14.v16
                del tmp14
                del v341; del v343
                v344 = method22(v342, v327, v328, v329, v330, v331, v332, v333, v334)
                del v329; del v332
                v345 = v342 == (<unsigned char>0)
                if v345:
                    v346 = (<float>1.000000)
                else:
                    v346 = (<float>-1.000000)
                v347 = v344 * v346
                v323[v326] = v347
                v348 = v326 + (<unsigned long long>1)
                v324.v0 = v348
            del v324
            v349 = torch.from_numpy(v323)
            del v323
            v194.backward(v349.unsqueeze(-1) * (v321.unsqueeze(-1) - v289))
            del v289; del v349
            v351 = v321.numpy()
            del v321
        del v83; del v179; del v194; del v195; del v196; del v278
        v352 = len(v10)
        v353 = [None]*v352
        v354 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method25(v352, v354):
            v356 = v354.v0
            v357, v358 = v354.v1, v354.v2
            v359 = v10[v356]
            v360 = v359 == (<unsigned char>0)
            if v360:
                v361 = v269[v357]
                v362 = v357 + (<unsigned long long>1)
                v365, v366, v367 = v361, v362, v358
            else:
                v363 = v351[v358]
                v364 = v358 + (<unsigned long long>1)
                v365, v366, v367 = v363, v357, v364
            v353[v356] = v365
            v368 = v356 + (<unsigned long long>1)
            v354.v0 = v368
            v354.v1 = v366
            v354.v2 = v367
        del v269; del v351
        v369, v370 = v354.v1, v354.v2
        del v354
        v372 = v353
        del v353
    else:
        v372 = [None]*(<unsigned long long>0)
    del v6; del v7; del v8; del v9; del v10
    v373 = numpy.empty(v11,dtype=numpy.float32)
    v374 = len(v5)
    v375 = len(v372)
    v376 = v374 == v375
    v377 = v376 == 0
    if v377:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v378 = Mut1((<unsigned long long>0))
    while method2(v374, v378):
        v380 = v378.v0
        v381 = v5[v380]
        v382 = v372[v380]
        v373[v381] = v382
        v383 = v380 + (<unsigned long long>1)
        v378.v0 = v383
    del v5; del v372
    del v378
    v384 = len(v4)
    v385 = Mut1((<unsigned long long>0))
    while method2(v384, v385):
        v387 = v385.v0
        tmp15 = v4[v387]
        v388, v389, v390, v391, v392, v393, v394, v395, v396, v397, v398, v399, v400, v401, v402, v403, v404 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3, tmp15.v4, tmp15.v5, tmp15.v6, tmp15.v7, tmp15.v8, tmp15.v9, tmp15.v10, tmp15.v11, tmp15.v12, tmp15.v13, tmp15.v14, tmp15.v15, tmp15.v16
        del tmp15
        del v391; del v394; del v403
        v373[v388] = v404
        v405 = v387 + (<unsigned long long>1)
        v385.v0 = v405
    del v4
    del v385
    return v373
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
    cdef float v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef Mut1 v28
    cdef unsigned long long v30
    cdef UH0 v31
    cdef float v32
    cdef float v33
    cdef UH0 v34
    cdef float v35
    cdef float v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef US1 v39
    cdef unsigned long long v40
    cdef numpy.ndarray[signed long,ndim=1] v41
    cdef Mut1 v42
    cdef unsigned long long v44
    cdef bint v45
    cdef unsigned long long v47
    cdef US1 v48
    cdef unsigned long long v49
    cdef float v50
    cdef float v51
    cdef float v52
    cdef unsigned long long v53
    cdef unsigned long long v54
    cdef US1 v55
    cdef unsigned long long v56
    cdef numpy.ndarray[signed long,ndim=1] v57
    cdef Mut1 v58
    cdef unsigned long long v60
    cdef bint v61
    cdef unsigned long long v63
    cdef US1 v64
    cdef unsigned long long v65
    cdef float v66
    cdef float v67
    cdef float v68
    cdef float v69
    cdef numpy.ndarray[signed long,ndim=1] v70
    cdef US2 v71
    cdef UH0 v72
    cdef US2 v73
    cdef UH0 v74
    cdef US3 v75
    cdef object v76
    cdef UH1 v77
    cdef unsigned long long v78
    cdef numpy.ndarray[float,ndim=1] v79
    cdef signed long v80
    cdef float v81
    cdef numpy.ndarray[object,ndim=1] v82
    cdef Mut1 v83
    cdef unsigned long long v85
    cdef UH0 v86
    cdef float v87
    cdef float v88
    cdef UH0 v89
    cdef float v90
    cdef float v91
    cdef unsigned long long v92
    cdef unsigned long long v93
    cdef US1 v94
    cdef unsigned long long v95
    cdef numpy.ndarray[signed long,ndim=1] v96
    cdef Mut1 v97
    cdef unsigned long long v99
    cdef bint v100
    cdef unsigned long long v102
    cdef US1 v103
    cdef unsigned long long v104
    cdef float v105
    cdef float v106
    cdef float v107
    cdef unsigned long long v108
    cdef unsigned long long v109
    cdef US1 v110
    cdef unsigned long long v111
    cdef numpy.ndarray[signed long,ndim=1] v112
    cdef Mut1 v113
    cdef unsigned long long v115
    cdef bint v116
    cdef unsigned long long v118
    cdef US1 v119
    cdef unsigned long long v120
    cdef float v121
    cdef float v122
    cdef float v123
    cdef float v124
    cdef numpy.ndarray[signed long,ndim=1] v125
    cdef US2 v126
    cdef UH0 v127
    cdef US2 v128
    cdef UH0 v129
    cdef US3 v130
    cdef object v131
    cdef UH1 v132
    cdef unsigned long long v133
    cdef numpy.ndarray[float,ndim=1] v134
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
    v22 = torch.optim.SGD([{'params':v20[0].parameters()},{'params':v21[0].parameters()},{'params':v20[1].parameters()},{'params':v21[1].parameters()}],lr=(<float>0.000031))
    v23 = Mut0((<signed long>0))
    while method0(v23):
        v25 = v23.v0
        v22.zero_grad()
        v26 = (<float>0.500000)
        v27 = numpy.empty((<unsigned long long>1024),dtype=object)
        v28 = Mut1((<unsigned long long>0))
        while method1(v28):
            v30 = v28.v0
            v31 = UH0_1()
            v32 = (<float>0.000000)
            v33 = (<float>0.000000)
            v34 = UH0_1()
            v35 = (<float>0.000000)
            v36 = (<float>0.000000)
            v37 = len(v19)
            v38 = numpy.random.randint(0,v37)
            v39 = v19[v38]
            v40 = v37 - (<unsigned long long>1)
            v41 = numpy.empty(v40,dtype=numpy.int32)
            v42 = Mut1((<unsigned long long>0))
            while method2(v40, v42):
                v44 = v42.v0
                v45 = v38 <= v44
                if v45:
                    v47 = v44 + (<unsigned long long>1)
                else:
                    v47 = v44
                v48 = v19[v47]
                v41[v44] = v48
                v49 = v44 + (<unsigned long long>1)
                v42.v0 = v49
            del v42
            v50 = <float>v37
            v51 = (<float>1.000000) / v50
            v52 = libc.math.log(v51)
            v53 = len(v41)
            v54 = numpy.random.randint(0,v53)
            v55 = v41[v54]
            v56 = v53 - (<unsigned long long>1)
            v57 = numpy.empty(v56,dtype=numpy.int32)
            v58 = Mut1((<unsigned long long>0))
            while method2(v56, v58):
                v60 = v58.v0
                v61 = v54 <= v60
                if v61:
                    v63 = v60 + (<unsigned long long>1)
                else:
                    v63 = v60
                v64 = v41[v63]
                v57[v60] = v64
                v65 = v60 + (<unsigned long long>1)
                v58.v0 = v65
            del v41
            del v58
            v66 = <float>v53
            v67 = (<float>1.000000) / v66
            v68 = libc.math.log(v67)
            v69 = v68 + v52
            v70 = v12.v2
            v71 = US2_1(v39)
            v72 = UH0_0(v71, v31)
            del v71
            v73 = US2_1(v55)
            v74 = UH0_0(v73, v34)
            del v73
            v75 = US3_0()
            v76 = Closure0(v39, v55, v12, v57, v34, v35, v36, v31, v32, v33, v69)
            del v31; del v34; del v57
            v77 = UH1_0(v69, v69, v72, v32, v33, v74, v35, v36, v39, (<unsigned char>0), (<signed long>1), v55, (<unsigned char>1), (<signed long>1), v75, (<unsigned char>0), v70, v76)
            del v70; del v72; del v74; del v75; del v76
            v27[v30] = v77
            del v77
            v78 = v30 + (<unsigned long long>1)
            v28.v0 = v78
        del v28
        v79 = method11(v26, v21, v20, v27)
        del v27
        v22.step()
        print(numpy.mean(v79))
        del v79
        v80 = v25 + (<signed long>1)
        v23.v0 = v80
    del v22
    del v23
    print('---')
    v81 = (<float>1.000000)
    v82 = numpy.empty((<unsigned long long>10240),dtype=object)
    v83 = Mut1((<unsigned long long>0))
    while method23(v83):
        v85 = v83.v0
        v86 = UH0_1()
        v87 = (<float>0.000000)
        v88 = (<float>0.000000)
        v89 = UH0_1()
        v90 = (<float>0.000000)
        v91 = (<float>0.000000)
        v92 = len(v19)
        v93 = numpy.random.randint(0,v92)
        v94 = v19[v93]
        v95 = v92 - (<unsigned long long>1)
        v96 = numpy.empty(v95,dtype=numpy.int32)
        v97 = Mut1((<unsigned long long>0))
        while method2(v95, v97):
            v99 = v97.v0
            v100 = v93 <= v99
            if v100:
                v102 = v99 + (<unsigned long long>1)
            else:
                v102 = v99
            v103 = v19[v102]
            v96[v99] = v103
            v104 = v99 + (<unsigned long long>1)
            v97.v0 = v104
        del v97
        v105 = <float>v92
        v106 = (<float>1.000000) / v105
        v107 = libc.math.log(v106)
        v108 = len(v96)
        v109 = numpy.random.randint(0,v108)
        v110 = v96[v109]
        v111 = v108 - (<unsigned long long>1)
        v112 = numpy.empty(v111,dtype=numpy.int32)
        v113 = Mut1((<unsigned long long>0))
        while method2(v111, v113):
            v115 = v113.v0
            v116 = v109 <= v115
            if v116:
                v118 = v115 + (<unsigned long long>1)
            else:
                v118 = v115
            v119 = v96[v118]
            v112[v115] = v119
            v120 = v115 + (<unsigned long long>1)
            v113.v0 = v120
        del v96
        del v113
        v121 = <float>v108
        v122 = (<float>1.000000) / v121
        v123 = libc.math.log(v122)
        v124 = v123 + v107
        v125 = v12.v2
        v126 = US2_1(v94)
        v127 = UH0_0(v126, v86)
        del v126
        v128 = US2_1(v110)
        v129 = UH0_0(v128, v89)
        del v128
        v130 = US3_0()
        v131 = Closure0(v94, v110, v12, v112, v89, v90, v91, v86, v87, v88, v124)
        del v86; del v89; del v112
        v132 = UH1_0(v124, v124, v127, v87, v88, v129, v90, v91, v94, (<unsigned char>0), (<signed long>1), v110, (<unsigned char>1), (<signed long>1), v130, (<unsigned char>0), v125, v131)
        del v125; del v127; del v129; del v130; del v131
        v82[v85] = v132
        del v132
        v133 = v85 + (<unsigned long long>1)
        v83.v0 = v133
    del v12; del v19
    del v83
    v134 = method24(v81, v21, v20, v82)
    del v20; del v21; del v82
    print(numpy.mean(v134))
