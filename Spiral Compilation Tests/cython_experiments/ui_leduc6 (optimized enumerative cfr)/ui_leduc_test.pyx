import ui_leduc
import nets
import numpy
cimport numpy
cimport libc.math
import torch
import torch.nn.functional
import torch.distributions
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
cdef class Closure1():
    def __init__(self): pass
    def __call__(self, double v0):
        pass
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US0 v0
    cdef readonly UH1 v1
    def __init__(self, US0 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US1 v0
    cdef readonly object v1
    cdef readonly UH2 v2
    def __init__(self, US1 v0, v1, UH2 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly US1 v0
    cdef readonly object v1
    def __init__(self, US1 v0, v1): self.v0 = v0; self.v1 = v1
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class US4:
    cdef readonly signed long tag
cdef class US4_0(US4): # none
    def __init__(self): self.tag = 0
cdef class US4_1(US4): # some_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, US0 v0):
        pass
cdef class Mut0:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure3():
    cdef object v0
    cdef US0 v1
    def __init__(self, v0, US0 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        v0(v1)
cdef class Closure4():
    cdef object v0
    cdef US0 v1
    def __init__(self, v0, US0 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        v0(v1)
cdef class Closure5():
    cdef object v0
    cdef US0 v1
    def __init__(self, v0, US0 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        v0(v1)
cdef class Closure6():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef signed long v9
    cdef US1 v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US1 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, v7, Heap0 v8, signed long v9, US1 v10, US1 v11, unsigned char v12, signed long v13, US1 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, US0 v17):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US1 v14 = self.v14
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
        method25(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v5, v19, v4, v21, v2, v0)
cdef class Closure7():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef US1 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US1 v12
    cdef unsigned char v13
    cdef signed long v14
    cdef US1 v15
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, v7, Heap0 v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US1 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, US0 v16):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef US1 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US1 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef US1 v15 = self.v15
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
        method23(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v5, v18, v4, v20, v2, v0)
cdef class Closure8():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US1 v14
    cdef unsigned char v15
    cdef signed long v16
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US1 v14, unsigned char v15, signed long v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, US0 v17):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US1 v14 = self.v14
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
        method32(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v5, v19, v4, v21, v2, v0)
cdef class Closure9():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef object v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US1 v14
    cdef unsigned char v15
    def __init__(self, v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US1 v14, unsigned char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, US0 v16):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef object v6 = self.v6
        cdef object v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US1 v14 = self.v14
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
        method21(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v5, v18, v4, v20, v2, v0)
cdef class Closure0():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2
        cdef US0 v3
        cdef numpy.ndarray[signed long,ndim=1] v4
        cdef US0 v5
        cdef US0 v6
        cdef US0 v7
        cdef numpy.ndarray[signed long,ndim=1] v8
        cdef US0 v9
        cdef US0 v10
        cdef numpy.ndarray[signed long,ndim=1] v11
        cdef US0 v12
        cdef numpy.ndarray[signed long,ndim=1] v13
        cdef Heap0 v14
        cdef US1 v15
        cdef US1 v16
        cdef US1 v17
        cdef US1 v18
        cdef US1 v19
        cdef US1 v20
        cdef numpy.ndarray[signed long,ndim=1] v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef UH0 v24
        cdef double v25
        cdef UH0 v26
        cdef double v27
        cdef US1 v28
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
        method0(v29, v23, v21, v30, v31)
        del v21
        v32 = <double>v22
        v33 = (<double>1.000000) / v32
        v34 = libc.math.log(v33)
        v35 = US2_1(v28)
        v36 = UH0_0(v35, v24)
        del v24; del v35
        v37 = Closure1()
        method1(v1, v0, v14, v28, v30, v34, v36, v25, v26, v27, v37)
cdef void method0(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
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
        method0(v0, v1, v2, v3, v6)
    else:
        pass
cdef UH0 method4(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method4(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method6(UH1 v0, UH1 v1):
    cdef US0 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        return method6(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method8(UH1 v0, unsigned long long v1):
    cdef US0 v2
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method8(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(numpy.ndarray[signed long,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US0 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        v5 = v2 + (<unsigned long long>1)
        return method9(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[signed long,ndim=1] method7(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[signed long,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method8(v0, v1)
    v3 = numpy.empty(v2,dtype=numpy.int32)
    v4 = (<unsigned long long>0)
    v5 = method9(v3, v0, v4)
    return v3
cdef UH2 method5(UH1 v0, US1 v1, UH0 v2):
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef UH1 v6
    cdef US1 v8
    cdef UH1 v9
    cdef UH1 v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef UH1 v12
    cdef UH2 v13
    cdef UH1 v16
    cdef UH1 v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef UH2 v19
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US2_0>v3).v0
            v6 = UH1_0(v5, v0)
            return method5(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH1_1()
            v10 = method6(v0, v9)
            del v9
            v11 = method7(v10)
            del v10
            v12 = UH1_1()
            v13 = method5(v12, v8, v4)
            del v4; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method6(v0, v16)
        del v16
        v18 = method7(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method11(UH2 v0, unsigned long long v1):
    cdef US1 v2
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v4 = (<UH2_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method11(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method12(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US1 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple0(v3, v4)
        del v4
        v6 = v2 + (<unsigned long long>1)
        return method12(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method10(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method11(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<unsigned long long>0)
    v5 = method12(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method3(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef US1 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method4(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US2_0>v3).v0
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US2_1>v3).v0
            v8 = UH1_1()
            v9 = method5(v8, v7, v4)
            del v4; del v8
            return method10(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef signed long long method14(US0 v0):
    cdef signed long long v1
    if v0 == 0: # call
        v1 = (<signed long long>0)
    elif v0 == 1: # fold
        v1 = (<signed long long>1)
    elif v0 == 2: # raise
        v1 = (<signed long long>2)
    return v1
cdef void method13(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US0 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v1[v3]
        v7 = method14(v6)
        v2[v3] = v7
        method13(v0, v1, v2, v5)
    else:
        pass
cdef void method15(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<float>0.000000)
        method15(v0, v1, v4)
    else:
        pass
cdef void method17(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US0 v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = v4 * (<unsigned long long>3)
        v9 = v2 + v8
        if v7 == 0: # call
            v1[v9] = (<float>1.000000)
        elif v7 == 1: # fold
            v10 = v9 + (<unsigned long long>1)
            v1[v10] = (<float>1.000000)
        elif v7 == 2: # raise
            v11 = v9 + (<unsigned long long>2)
            v1[v11] = (<float>1.000000)
        method17(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method16(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef numpy.ndarray[signed long,ndim=1] v7
    cdef Tuple0 tmp0
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef unsigned long long v14
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        tmp0 = v2[v3]
        v6, v7 = tmp0.v0, tmp0.v1
        del tmp0
        v8 = v3 * (<unsigned long long>15)
        if v6 == 0: # jack
            v1[v8] = (<float>1.000000)
        elif v6 == 1: # king
            v9 = v8 + (<unsigned long long>1)
            v1[v9] = (<float>1.000000)
        elif v6 == 2: # queen
            v10 = v8 + (<unsigned long long>2)
            v1[v10] = (<float>1.000000)
        v11 = v8 + (<unsigned long long>3)
        v12 = len(v7)
        v13 = (<unsigned long long>4) < v12
        if v13:
            raise Exception("The given array is too large.")
        else:
            pass
        v14 = (<unsigned long long>0)
        method17(v12, v1, v11, v7, v14)
        del v7
        method16(v0, v1, v2, v5)
    else:
        pass
cdef US0 method18(signed long long v0):
    cdef bint v1
    cdef bint v2
    cdef bint v3
    cdef bint v4
    cdef bint v5
    cdef bint v7
    cdef signed long long v8
    cdef bint v9
    cdef bint v10
    cdef signed long long v12
    cdef bint v13
    cdef bint v14
    v1 = v0 < (<signed long long>3)
    v2 = v1 == 0
    if v2:
        raise Exception("The size of the argument is too large.")
    else:
        pass
    v3 = v0 < (<signed long long>1)
    if v3:
        v4 = v0 == (<signed long long>0)
        v5 = v4 == 0
        if v5:
            raise Exception("The unit index should be 0.")
        else:
            pass
        return 0
    else:
        v7 = v0 < (<signed long long>2)
        if v7:
            v8 = v0 - (<signed long long>1)
            v9 = v8 == (<signed long long>0)
            v10 = v9 == 0
            if v10:
                raise Exception("The unit index should be 0.")
            else:
                pass
            return 1
        else:
            if v1:
                v12 = v0 - (<signed long long>2)
                v13 = v12 == (<signed long long>0)
                v14 = v13 == 0
                if v14:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                return 2
            else:
                raise Exception("Unpickling of an union failed.")
cdef numpy.ndarray[signed long,ndim=1] method20(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method24(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method26(US1 v0):
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef str method30(US1 v0):
    if v0 == 0: # jack
        return "Jack"
    elif v0 == 1: # king
        return "King"
    elif v0 == 2: # queen
        return "Queen"
cdef bint method29(list v0, UH0 v1, bint v2):
    cdef US2 v3
    cdef UH0 v4
    cdef bint v5
    cdef US0 v6
    cdef str v7
    cdef str v8
    cdef str v9
    cdef US1 v11
    cdef str v12
    cdef str v13
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1
        v5 = method29(v0, v4, v2)
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
            v12 = method30(v11)
            v13 = f'Observed {v12}.'
            del v12
            v0.append(v13)
            del v13
            return 1
    elif v1.tag == 1: # nil
        return v2
cdef str method28(unsigned char v0, US4 v1, UH0 v2):
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
    v5 = method29(v3, v2, v4)
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
cdef void method31(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, v2, Mut0 v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US0 v7
    cdef object v8
    cdef object v9
    cdef object v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        if v7 == 0: # call
            v8 = Closure3(v2, v7)
            v3.v0 = v8
            del v8
        elif v7 == 1: # fold
            v9 = Closure4(v2, v7)
            v3.v1 = v9
            del v9
        elif v7 == 2: # raise
            v10 = Closure5(v2, v7)
            v3.v2 = v10
            del v10
        method31(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method27(v0, v1, numpy.ndarray[signed long,ndim=1] v2, UH0 v3, US4 v4, US3 v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10, signed long v11):
    cdef str v12
    cdef object v13
    cdef object v14
    cdef object v15
    cdef Mut0 v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef object v22
    cdef str v23
    cdef str v24
    cdef str v27
    cdef US1 v25
    cdef object v28
    cdef object v29
    v12 = method28(v10, v4, v3)
    v13 = False
    v14 = False
    v15 = False
    v16 = Mut0(v14, v13, v15)
    del v13; del v14; del v15
    v17 = len(v2)
    v18 = (<unsigned long long>0)
    method31(v17, v2, v1, v16, v18)
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
        v25 = (<US3_1>v5).v0
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
cdef void method25(v0, v1, Heap0 v2, signed long v3, US1 v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US0 v11, double v12, UH0 v13, double v14, UH0 v15, double v16, v17):
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
    cdef double v71
    cdef numpy.ndarray[signed long,ndim=1] v72
    cdef US3 v73
    cdef US4 v74
    cdef object v75
    cdef bint v76
    cdef signed long v78
    cdef bint v79
    cdef signed long v81
    cdef signed long v82
    cdef signed long v84
    cdef signed long v85
    cdef US1 v86
    cdef unsigned char v87
    cdef signed long v88
    cdef US1 v89
    cdef unsigned char v90
    cdef signed long v91
    cdef double v92
    cdef numpy.ndarray[signed long,ndim=1] v93
    cdef US3 v94
    cdef US4 v95
    cdef object v96
    cdef signed long v97
    cdef signed long v98
    cdef numpy.ndarray[signed long,ndim=1] v99
    cdef bint v100
    cdef numpy.ndarray[object,ndim=1] v101
    cdef unsigned long long v102
    cdef numpy.ndarray[signed long long,ndim=1] v103
    cdef unsigned long long v104
    cdef numpy.ndarray[float,ndim=1] v105
    cdef unsigned long long v106
    cdef unsigned long long v107
    cdef unsigned long long v108
    cdef bint v109
    cdef unsigned long long v110
    cdef object v111
    cdef object v112
    cdef object v113
    cdef object v114
    cdef object v115
    cdef object v116
    cdef object v117
    cdef double v118
    cdef signed long long v119
    cdef unsigned long long v120
    cdef signed long long v121
    cdef US0 v122
    cdef double v123
    cdef US2 v124
    cdef UH0 v125
    cdef US2 v126
    cdef UH0 v127
    cdef US3 v128
    cdef US4 v129
    cdef object v130
    if v11 == 0: # call
        v18 = method26(v4)
        v19 = method26(v8)
        v20 = method26(v5)
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
        
        v73 = US3_1(v4)
        v74 = US4_1(v71)
        v75 = Closure2()
        method27(v0, v75, v72, v15, v74, v73, v65, v66, v67, v68, v69, v70)
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
        
        v94 = US3_1(v4)
        v95 = US4_1(v92)
        v96 = Closure2()
        method27(v0, v96, v93, v15, v95, v94, v86, v87, v88, v89, v90, v91)
        del v93; del v94; del v95; del v96
        v17(v92)
    elif v11 == 2: # raise
        v97 = v3 - (<signed long>1)
        v98 = v7 + (<signed long>4)
        v99 = method24(v2, v8, v9, v98, v5, v6, v7, v97)
        v100 = v6 == (<unsigned char>0)
        if v100:
            v101 = method3(v13)
            v102 = len(v99)
            v103 = numpy.empty(v102,dtype=numpy.int64)
            v104 = (<unsigned long long>0)
            method13(v102, v99, v103, v104)
            del v99
            v105 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v106 = len(v105)
            v107 = (<unsigned long long>0)
            method15(v106, v105, v107)
            v108 = len(v101)
            v109 = (<unsigned long long>2) < v108
            if v109:
                raise Exception("The given array is too large.")
            else:
                pass
            v110 = (<unsigned long long>0)
            method16(v108, v105, v101, v110)
            del v101
            pass # import torch
            v111 = torch.from_numpy(v105)
            del v105
            v112 = v1.forward(v111)
            del v111
            v113 = v112[v103]
            del v112
            pass # import torch.nn.functional
            v114 = torch.nn.functional.softmax(v113,-1)
            del v113
            pass # import torch.distributions
            v115 = torch.distributions.Categorical(probs=v114)
            del v114
            v116 = v115.sample()
            v117 = v115.log_prob(v116)
            del v115
            v118 = v117.item()
            del v117
            v119 = v116.item()
            del v116
            v120 = v119
            v121 = v103[v120]
            del v103
            v122 = method18(v121)
            v123 = v118 + v14
            v124 = US2_0(v122)
            v125 = UH0_0(v124, v13)
            del v124
            v126 = US2_0(v122)
            v127 = UH0_0(v126, v15)
            del v126
            method25(v0, v1, v2, v97, v4, v8, v9, v98, v5, v6, v7, v122, v12, v125, v123, v127, v16, v17)
        else:
            v128 = US3_1(v4)
            v129 = US4_0()
            v130 = Closure6(v17, v15, v16, v13, v14, v12, v0, v1, v2, v97, v4, v8, v9, v98, v5, v6, v7)
            method27(v0, v130, v99, v15, v129, v128, v8, v9, v98, v5, v6, v7)
cdef void method23(v0, v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US1 v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15, v16):
    cdef signed long v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef numpy.ndarray[object,ndim=1] v20
    cdef unsigned long long v21
    cdef numpy.ndarray[signed long long,ndim=1] v22
    cdef unsigned long long v23
    cdef numpy.ndarray[float,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef unsigned long long v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef object v34
    cdef object v35
    cdef object v36
    cdef double v37
    cdef signed long long v38
    cdef unsigned long long v39
    cdef signed long long v40
    cdef US0 v41
    cdef double v42
    cdef US2 v43
    cdef UH0 v44
    cdef US2 v45
    cdef UH0 v46
    cdef US3 v47
    cdef US4 v48
    cdef object v49
    cdef object v50
    cdef signed long v51
    cdef signed long v52
    cdef numpy.ndarray[signed long,ndim=1] v53
    cdef bint v54
    cdef numpy.ndarray[object,ndim=1] v55
    cdef unsigned long long v56
    cdef numpy.ndarray[signed long long,ndim=1] v57
    cdef unsigned long long v58
    cdef numpy.ndarray[float,ndim=1] v59
    cdef unsigned long long v60
    cdef unsigned long long v61
    cdef unsigned long long v62
    cdef bint v63
    cdef unsigned long long v64
    cdef object v65
    cdef object v66
    cdef object v67
    cdef object v68
    cdef object v69
    cdef object v70
    cdef object v71
    cdef double v72
    cdef signed long long v73
    cdef unsigned long long v74
    cdef signed long long v75
    cdef US0 v76
    cdef double v77
    cdef US2 v78
    cdef UH0 v79
    cdef US2 v80
    cdef UH0 v81
    cdef US3 v82
    cdef US4 v83
    cdef object v84
    if v10 == 0: # call
        v17 = (<signed long>2)
        v18 = method24(v2, v6, v7, v8, v3, v4, v5, v17)
        v19 = v4 == (<unsigned char>0)
        if v19:
            v20 = method3(v12)
            v21 = len(v18)
            v22 = numpy.empty(v21,dtype=numpy.int64)
            v23 = (<unsigned long long>0)
            method13(v21, v18, v22, v23)
            del v18
            v24 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v25 = len(v24)
            v26 = (<unsigned long long>0)
            method15(v25, v24, v26)
            v27 = len(v20)
            v28 = (<unsigned long long>2) < v27
            if v28:
                raise Exception("The given array is too large.")
            else:
                pass
            v29 = (<unsigned long long>0)
            method16(v27, v24, v20, v29)
            del v20
            pass # import torch
            v30 = torch.from_numpy(v24)
            del v24
            v31 = v1.forward(v30)
            del v30
            v32 = v31[v22]
            del v31
            pass # import torch.nn.functional
            v33 = torch.nn.functional.softmax(v32,-1)
            del v32
            pass # import torch.distributions
            v34 = torch.distributions.Categorical(probs=v33)
            del v33
            v35 = v34.sample()
            v36 = v34.log_prob(v35)
            del v34
            v37 = v36.item()
            del v36
            v38 = v35.item()
            del v35
            v39 = v38
            v40 = v22[v39]
            del v22
            v41 = method18(v40)
            v42 = v37 + v13
            v43 = US2_0(v41)
            v44 = UH0_0(v43, v12)
            del v43
            v45 = US2_0(v41)
            v46 = UH0_0(v45, v14)
            del v45
            method25(v0, v1, v2, v17, v9, v6, v7, v8, v3, v4, v5, v41, v11, v44, v42, v46, v15, v16)
        else:
            v47 = US3_1(v9)
            v48 = US4_0()
            v49 = Closure6(v16, v14, v15, v12, v13, v11, v0, v1, v2, v17, v9, v6, v7, v8, v3, v4, v5)
            method27(v0, v49, v18, v14, v48, v47, v6, v7, v8, v3, v4, v5)
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v51 = (<signed long>1)
        v52 = v5 + (<signed long>4)
        v53 = method24(v2, v6, v7, v52, v3, v4, v5, v51)
        v54 = v4 == (<unsigned char>0)
        if v54:
            v55 = method3(v12)
            v56 = len(v53)
            v57 = numpy.empty(v56,dtype=numpy.int64)
            v58 = (<unsigned long long>0)
            method13(v56, v53, v57, v58)
            del v53
            v59 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v60 = len(v59)
            v61 = (<unsigned long long>0)
            method15(v60, v59, v61)
            v62 = len(v55)
            v63 = (<unsigned long long>2) < v62
            if v63:
                raise Exception("The given array is too large.")
            else:
                pass
            v64 = (<unsigned long long>0)
            method16(v62, v59, v55, v64)
            del v55
            pass # import torch
            v65 = torch.from_numpy(v59)
            del v59
            v66 = v1.forward(v65)
            del v65
            v67 = v66[v57]
            del v66
            pass # import torch.nn.functional
            v68 = torch.nn.functional.softmax(v67,-1)
            del v67
            pass # import torch.distributions
            v69 = torch.distributions.Categorical(probs=v68)
            del v68
            v70 = v69.sample()
            v71 = v69.log_prob(v70)
            del v69
            v72 = v71.item()
            del v71
            v73 = v70.item()
            del v70
            v74 = v73
            v75 = v57[v74]
            del v57
            v76 = method18(v75)
            v77 = v72 + v13
            v78 = US2_0(v76)
            v79 = UH0_0(v78, v12)
            del v78
            v80 = US2_0(v76)
            v81 = UH0_0(v80, v14)
            del v80
            method25(v0, v1, v2, v51, v9, v6, v7, v52, v3, v4, v5, v76, v11, v79, v77, v81, v15, v16)
        else:
            v82 = US3_1(v9)
            v83 = US4_0()
            v84 = Closure6(v16, v14, v15, v12, v13, v11, v0, v1, v2, v51, v9, v6, v7, v52, v3, v4, v5)
            method27(v0, v84, v53, v14, v83, v82, v6, v7, v52, v3, v4, v5)
cdef void method22(v0, v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US1 v9, double v10, UH0 v11, double v12, UH0 v13, double v14, v15):
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef unsigned long long v19
    cdef numpy.ndarray[signed long long,ndim=1] v20
    cdef unsigned long long v21
    cdef numpy.ndarray[float,ndim=1] v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef bint v26
    cdef unsigned long long v27
    cdef object v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef object v34
    cdef double v35
    cdef signed long long v36
    cdef unsigned long long v37
    cdef signed long long v38
    cdef US0 v39
    cdef double v40
    cdef US2 v41
    cdef UH0 v42
    cdef US2 v43
    cdef UH0 v44
    cdef US3 v45
    cdef US4 v46
    cdef object v47
    v16 = v2.v2
    v17 = v7 == (<unsigned char>0)
    if v17:
        v18 = method3(v11)
        v19 = len(v16)
        v20 = numpy.empty(v19,dtype=numpy.int64)
        v21 = (<unsigned long long>0)
        method13(v19, v16, v20, v21)
        del v16
        v22 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
        v23 = len(v22)
        v24 = (<unsigned long long>0)
        method15(v23, v22, v24)
        v25 = len(v18)
        v26 = (<unsigned long long>2) < v25
        if v26:
            raise Exception("The given array is too large.")
        else:
            pass
        v27 = (<unsigned long long>0)
        method16(v25, v22, v18, v27)
        del v18
        pass # import torch
        v28 = torch.from_numpy(v22)
        del v22
        v29 = v1.forward(v28)
        del v28
        v30 = v29[v20]
        del v29
        pass # import torch.nn.functional
        v31 = torch.nn.functional.softmax(v30,-1)
        del v30
        pass # import torch.distributions
        v32 = torch.distributions.Categorical(probs=v31)
        del v31
        v33 = v32.sample()
        v34 = v32.log_prob(v33)
        del v32
        v35 = v34.item()
        del v34
        v36 = v33.item()
        del v33
        v37 = v36
        v38 = v20[v37]
        del v20
        v39 = method18(v38)
        v40 = v35 + v12
        v41 = US2_0(v39)
        v42 = UH0_0(v41, v11)
        del v41
        v43 = US2_0(v39)
        v44 = UH0_0(v43, v13)
        del v43
        method23(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v39, v10, v42, v40, v44, v14, v15)
    else:
        v45 = US3_1(v9)
        v46 = US4_0()
        v47 = Closure7(v15, v13, v14, v11, v12, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        method27(v0, v47, v16, v13, v46, v45, v3, v4, v5, v6, v7, v8)
cdef void method32(v0, v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US0 v11, double v12, UH0 v13, double v14, UH0 v15, double v16, v17):
    cdef bint v18
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef US1 v27
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
    cdef US1 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef US1 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef double v52
    cdef numpy.ndarray[signed long,ndim=1] v53
    cdef US3 v54
    cdef US4 v55
    cdef object v56
    cdef signed long v57
    cdef signed long v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef bint v60
    cdef numpy.ndarray[object,ndim=1] v61
    cdef unsigned long long v62
    cdef numpy.ndarray[signed long long,ndim=1] v63
    cdef unsigned long long v64
    cdef numpy.ndarray[float,ndim=1] v65
    cdef unsigned long long v66
    cdef unsigned long long v67
    cdef unsigned long long v68
    cdef bint v69
    cdef unsigned long long v70
    cdef object v71
    cdef object v72
    cdef object v73
    cdef object v74
    cdef object v75
    cdef object v76
    cdef object v77
    cdef double v78
    cdef signed long long v79
    cdef unsigned long long v80
    cdef signed long long v81
    cdef US0 v82
    cdef double v83
    cdef US2 v84
    cdef UH0 v85
    cdef US2 v86
    cdef UH0 v87
    cdef US3 v88
    cdef US4 v89
    cdef object v90
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
        method22(v0, v1, v2, v22, v23, v24, v19, v20, v21, v27, v31, v33, v14, v35, v16, v17)
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
        
        v54 = US3_0()
        v55 = US4_1(v52)
        v56 = Closure2()
        method27(v0, v56, v53, v15, v55, v54, v46, v47, v48, v49, v50, v51)
        del v53; del v54; del v55; del v56
        v17(v52)
    elif v11 == 2: # raise
        v57 = v4 - (<signed long>1)
        v58 = v7 + (<signed long>2)
        v59 = method24(v2, v8, v9, v58, v5, v6, v7, v57)
        v60 = v6 == (<unsigned char>0)
        if v60:
            v61 = method3(v13)
            v62 = len(v59)
            v63 = numpy.empty(v62,dtype=numpy.int64)
            v64 = (<unsigned long long>0)
            method13(v62, v59, v63, v64)
            del v59
            v65 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v66 = len(v65)
            v67 = (<unsigned long long>0)
            method15(v66, v65, v67)
            v68 = len(v61)
            v69 = (<unsigned long long>2) < v68
            if v69:
                raise Exception("The given array is too large.")
            else:
                pass
            v70 = (<unsigned long long>0)
            method16(v68, v65, v61, v70)
            del v61
            pass # import torch
            v71 = torch.from_numpy(v65)
            del v65
            v72 = v1.forward(v71)
            del v71
            v73 = v72[v63]
            del v72
            pass # import torch.nn.functional
            v74 = torch.nn.functional.softmax(v73,-1)
            del v73
            pass # import torch.distributions
            v75 = torch.distributions.Categorical(probs=v74)
            del v74
            v76 = v75.sample()
            v77 = v75.log_prob(v76)
            del v75
            v78 = v77.item()
            del v77
            v79 = v76.item()
            del v76
            v80 = v79
            v81 = v63[v80]
            del v63
            v82 = method18(v81)
            v83 = v78 + v14
            v84 = US2_0(v82)
            v85 = UH0_0(v84, v13)
            del v84
            v86 = US2_0(v82)
            v87 = UH0_0(v86, v15)
            del v86
            method32(v0, v1, v2, v3, v57, v8, v9, v58, v5, v6, v7, v82, v12, v85, v83, v87, v16, v17)
        else:
            v88 = US3_0()
            v89 = US4_0()
            v90 = Closure8(v17, v15, v16, v13, v14, v12, v0, v1, v2, v3, v57, v8, v9, v58, v5, v6, v7)
            method27(v0, v90, v59, v15, v89, v88, v8, v9, v58, v5, v6, v7)
cdef void method21(v0, v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15, v16):
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
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US1 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef double v51
    cdef numpy.ndarray[signed long,ndim=1] v52
    cdef US3 v53
    cdef US4 v54
    cdef object v55
    cdef signed long v56
    cdef signed long v57
    cdef numpy.ndarray[signed long,ndim=1] v58
    cdef bint v59
    cdef numpy.ndarray[object,ndim=1] v60
    cdef unsigned long long v61
    cdef numpy.ndarray[signed long long,ndim=1] v62
    cdef unsigned long long v63
    cdef numpy.ndarray[float,ndim=1] v64
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef unsigned long long v67
    cdef bint v68
    cdef unsigned long long v69
    cdef object v70
    cdef object v71
    cdef object v72
    cdef object v73
    cdef object v74
    cdef object v75
    cdef object v76
    cdef double v77
    cdef signed long long v78
    cdef unsigned long long v79
    cdef signed long long v80
    cdef US0 v81
    cdef double v82
    cdef US2 v83
    cdef UH0 v84
    cdef US2 v85
    cdef UH0 v86
    cdef US3 v87
    cdef US4 v88
    cdef object v89
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
        method22(v0, v1, v2, v21, v22, v23, v18, v19, v20, v26, v30, v32, v13, v34, v15, v16)
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
        
        v53 = US3_0()
        v54 = US4_1(v51)
        v55 = Closure2()
        method27(v0, v55, v52, v14, v54, v53, v45, v46, v47, v48, v49, v50)
        del v52; del v53; del v54; del v55
        v16(v51)
    elif v10 == 2: # raise
        v56 = v4 - (<signed long>1)
        v57 = v7 + (<signed long>2)
        v58 = method24(v2, v8, v9, v57, v5, v6, v7, v56)
        v59 = v6 == (<unsigned char>0)
        if v59:
            v60 = method3(v12)
            v61 = len(v58)
            v62 = numpy.empty(v61,dtype=numpy.int64)
            v63 = (<unsigned long long>0)
            method13(v61, v58, v62, v63)
            del v58
            v64 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v65 = len(v64)
            v66 = (<unsigned long long>0)
            method15(v65, v64, v66)
            v67 = len(v60)
            v68 = (<unsigned long long>2) < v67
            if v68:
                raise Exception("The given array is too large.")
            else:
                pass
            v69 = (<unsigned long long>0)
            method16(v67, v64, v60, v69)
            del v60
            pass # import torch
            v70 = torch.from_numpy(v64)
            del v64
            v71 = v1.forward(v70)
            del v70
            v72 = v71[v62]
            del v71
            pass # import torch.nn.functional
            v73 = torch.nn.functional.softmax(v72,-1)
            del v72
            pass # import torch.distributions
            v74 = torch.distributions.Categorical(probs=v73)
            del v73
            v75 = v74.sample()
            v76 = v74.log_prob(v75)
            del v74
            v77 = v76.item()
            del v76
            v78 = v75.item()
            del v75
            v79 = v78
            v80 = v62[v79]
            del v62
            v81 = method18(v80)
            v82 = v77 + v13
            v83 = US2_0(v81)
            v84 = UH0_0(v83, v12)
            del v83
            v85 = US2_0(v81)
            v86 = UH0_0(v85, v14)
            del v85
            method32(v0, v1, v2, v3, v56, v8, v9, v57, v5, v6, v7, v81, v11, v84, v82, v86, v15, v16)
        else:
            v87 = US3_0()
            v88 = US4_0()
            v89 = Closure8(v16, v14, v15, v12, v13, v11, v0, v1, v2, v3, v56, v8, v9, v57, v5, v6, v7)
            method27(v0, v89, v58, v14, v88, v87, v8, v9, v57, v5, v6, v7)
cdef void method33(v0, v1, numpy.ndarray[signed long,ndim=1] v2, UH0 v3, US4 v4, US3 v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10):
    cdef str v11
    cdef object v12
    cdef object v13
    cdef object v14
    cdef Mut0 v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef object v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef str v22
    cdef str v23
    cdef str v26
    cdef US1 v24
    cdef object v27
    cdef object v28
    v11 = method28(v10, v4, v3)
    v12 = False
    v13 = False
    v14 = False
    v15 = Mut0(v13, v12, v14)
    del v12; del v13; del v14
    v16 = len(v2)
    v17 = (<unsigned long long>0)
    method31(v16, v2, v1, v15, v17)
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
        v24 = (<US3_1>v5).v0
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
cdef void method19(v0, v1, US1 v2, US1 v3, Heap0 v4, numpy.ndarray[signed long,ndim=1] v5, US0 v6, double v7, UH0 v8, double v9, UH0 v10, double v11, v12):
    cdef signed long v13
    cdef unsigned char v14
    cdef signed long v15
    cdef unsigned char v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef numpy.ndarray[object,ndim=1] v19
    cdef unsigned long long v20
    cdef numpy.ndarray[signed long long,ndim=1] v21
    cdef unsigned long long v22
    cdef numpy.ndarray[float,ndim=1] v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef bint v27
    cdef unsigned long long v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef object v34
    cdef object v35
    cdef double v36
    cdef signed long long v37
    cdef unsigned long long v38
    cdef signed long long v39
    cdef US0 v40
    cdef double v41
    cdef US2 v42
    cdef UH0 v43
    cdef US2 v44
    cdef UH0 v45
    cdef US3 v46
    cdef US4 v47
    cdef object v48
    cdef object v49
    cdef signed long v50
    cdef unsigned char v51
    cdef signed long v52
    cdef unsigned char v53
    cdef signed long v54
    cdef numpy.ndarray[signed long,ndim=1] v55
    cdef bint v56
    cdef numpy.ndarray[object,ndim=1] v57
    cdef unsigned long long v58
    cdef numpy.ndarray[signed long long,ndim=1] v59
    cdef unsigned long long v60
    cdef numpy.ndarray[float,ndim=1] v61
    cdef unsigned long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    cdef bint v65
    cdef unsigned long long v66
    cdef object v67
    cdef object v68
    cdef object v69
    cdef object v70
    cdef object v71
    cdef object v72
    cdef object v73
    cdef double v74
    cdef signed long long v75
    cdef unsigned long long v76
    cdef signed long long v77
    cdef US0 v78
    cdef double v79
    cdef US2 v80
    cdef UH0 v81
    cdef US2 v82
    cdef UH0 v83
    cdef US3 v84
    cdef US4 v85
    cdef object v86
    if v6 == 0: # call
        v13 = (<signed long>2)
        v14 = (<unsigned char>1)
        v15 = (<signed long>1)
        v16 = (<unsigned char>0)
        v17 = method20(v4, v2, v16, v15, v3, v14, v13)
        v18 = v14 == (<unsigned char>0)
        if v18:
            v19 = method3(v8)
            v20 = len(v17)
            v21 = numpy.empty(v20,dtype=numpy.int64)
            v22 = (<unsigned long long>0)
            method13(v20, v17, v21, v22)
            del v17
            v23 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v24 = len(v23)
            v25 = (<unsigned long long>0)
            method15(v24, v23, v25)
            v26 = len(v19)
            v27 = (<unsigned long long>2) < v26
            if v27:
                raise Exception("The given array is too large.")
            else:
                pass
            v28 = (<unsigned long long>0)
            method16(v26, v23, v19, v28)
            del v19
            pass # import torch
            v29 = torch.from_numpy(v23)
            del v23
            v30 = v1.forward(v29)
            del v29
            v31 = v30[v21]
            del v30
            pass # import torch.nn.functional
            v32 = torch.nn.functional.softmax(v31,-1)
            del v31
            pass # import torch.distributions
            v33 = torch.distributions.Categorical(probs=v32)
            del v32
            v34 = v33.sample()
            v35 = v33.log_prob(v34)
            del v33
            v36 = v35.item()
            del v35
            v37 = v34.item()
            del v34
            v38 = v37
            v39 = v21[v38]
            del v21
            v40 = method18(v39)
            v41 = v36 + v9
            v42 = US2_0(v40)
            v43 = UH0_0(v42, v8)
            del v42
            v44 = US2_0(v40)
            v45 = UH0_0(v44, v10)
            del v44
            method21(v0, v1, v4, v5, v13, v2, v16, v15, v3, v14, v40, v7, v43, v41, v45, v11, v12)
        else:
            v46 = US3_0()
            v47 = US4_0()
            v48 = Closure9(v12, v10, v11, v8, v9, v7, v0, v1, v4, v5, v13, v2, v16, v15, v3, v14)
            method33(v0, v48, v17, v10, v47, v46, v2, v16, v15, v3, v14)
    elif v6 == 1: # fold
        raise Exception("impossible")
    elif v6 == 2: # raise
        v50 = (<signed long>1)
        v51 = (<unsigned char>1)
        v52 = (<signed long>1)
        v53 = (<unsigned char>0)
        v54 = (<signed long>3)
        v55 = method24(v4, v2, v53, v54, v3, v51, v52, v50)
        v56 = v51 == (<unsigned char>0)
        if v56:
            v57 = method3(v8)
            v58 = len(v55)
            v59 = numpy.empty(v58,dtype=numpy.int64)
            v60 = (<unsigned long long>0)
            method13(v58, v55, v59, v60)
            del v55
            v61 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v62 = len(v61)
            v63 = (<unsigned long long>0)
            method15(v62, v61, v63)
            v64 = len(v57)
            v65 = (<unsigned long long>2) < v64
            if v65:
                raise Exception("The given array is too large.")
            else:
                pass
            v66 = (<unsigned long long>0)
            method16(v64, v61, v57, v66)
            del v57
            pass # import torch
            v67 = torch.from_numpy(v61)
            del v61
            v68 = v1.forward(v67)
            del v67
            v69 = v68[v59]
            del v68
            pass # import torch.nn.functional
            v70 = torch.nn.functional.softmax(v69,-1)
            del v69
            pass # import torch.distributions
            v71 = torch.distributions.Categorical(probs=v70)
            del v70
            v72 = v71.sample()
            v73 = v71.log_prob(v72)
            del v71
            v74 = v73.item()
            del v73
            v75 = v72.item()
            del v72
            v76 = v75
            v77 = v59[v76]
            del v59
            v78 = method18(v77)
            v79 = v74 + v9
            v80 = US2_0(v78)
            v81 = UH0_0(v80, v8)
            del v80
            v82 = US2_0(v78)
            v83 = UH0_0(v82, v10)
            del v82
            method32(v0, v1, v4, v5, v50, v2, v53, v54, v3, v51, v52, v78, v7, v81, v79, v83, v11, v12)
        else:
            v84 = US3_0()
            v85 = US4_0()
            v86 = Closure8(v12, v10, v11, v8, v9, v7, v0, v1, v4, v5, v50, v2, v53, v54, v3, v51, v52)
            method27(v0, v86, v55, v10, v85, v84, v2, v53, v54, v3, v51, v52)
cdef void method2(v0, v1, Heap0 v2, US1 v3, US1 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, UH0 v9, double v10, v11):
    cdef numpy.ndarray[signed long,ndim=1] v12
    cdef numpy.ndarray[object,ndim=1] v13
    cdef unsigned long long v14
    cdef numpy.ndarray[signed long long,ndim=1] v15
    cdef unsigned long long v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef unsigned long long v22
    cdef object v23
    cdef object v24
    cdef object v25
    cdef object v26
    cdef object v27
    cdef object v28
    cdef object v29
    cdef double v30
    cdef signed long long v31
    cdef unsigned long long v32
    cdef signed long long v33
    cdef US0 v34
    cdef double v35
    cdef US2 v36
    cdef UH0 v37
    cdef US2 v38
    cdef UH0 v39
    v12 = v2.v2
    v13 = method3(v7)
    v14 = len(v12)
    v15 = numpy.empty(v14,dtype=numpy.int64)
    v16 = (<unsigned long long>0)
    method13(v14, v12, v15, v16)
    del v12
    v17 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
    v18 = len(v17)
    v19 = (<unsigned long long>0)
    method15(v18, v17, v19)
    v20 = len(v13)
    v21 = (<unsigned long long>2) < v20
    if v21:
        raise Exception("The given array is too large.")
    else:
        pass
    v22 = (<unsigned long long>0)
    method16(v20, v17, v13, v22)
    del v13
    pass # import torch
    v23 = torch.from_numpy(v17)
    del v17
    v24 = v1.forward(v23)
    del v23
    v25 = v24[v15]
    del v24
    pass # import torch.nn.functional
    v26 = torch.nn.functional.softmax(v25,-1)
    del v25
    pass # import torch.distributions
    v27 = torch.distributions.Categorical(probs=v26)
    del v26
    v28 = v27.sample()
    v29 = v27.log_prob(v28)
    del v27
    v30 = v29.item()
    del v29
    v31 = v28.item()
    del v28
    v32 = v31
    v33 = v15[v32]
    del v15
    v34 = method18(v33)
    v35 = v30 + v8
    v36 = US2_0(v34)
    v37 = UH0_0(v36, v7)
    del v36
    v38 = US2_0(v34)
    v39 = UH0_0(v38, v9)
    del v38
    method19(v0, v1, v3, v4, v2, v5, v34, v6, v37, v35, v39, v10, v11)
cdef void method1(v0, v1, Heap0 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9, v10):
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef US1 v13
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
    method0(v14, v12, v4, v15, v16)
    v17 = <double>v11
    v18 = (<double>1.000000) / v17
    v19 = libc.math.log(v18)
    v20 = v19 + v5
    v21 = US2_1(v13)
    v22 = UH0_0(v21, v8)
    del v21
    method2(v0, v1, v2, v3, v13, v15, v20, v6, v7, v22, v9, v10)
cpdef void main():
    cdef object v0
    cdef object v1
    cdef object v2
    pass # import ui_leduc
    v0 = ui_leduc.Top()
    pass # import nets
    v1 = nets.small((<unsigned long long>30),(<unsigned long long>64),(<signed long long>3))
    v2 = Closure0(v1, v0)
    del v1
    ui_leduc.start_game(v0,v2)
