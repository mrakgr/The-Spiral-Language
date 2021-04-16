import nets
import numpy
cimport numpy
import torch
import torch.nn.functional
cimport libc.math
import ui_replay
ctypedef signed long US0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
ctypedef signed long US3
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # action_
    cdef readonly US3 v0
    def __init__(self, US3 v0): self.tag = 0; self.v0 = v0
cdef class US2_1(US2): # observation_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US2 v0
    cdef readonly UH0 v1
    def __init__(self, US2 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly double v1
    cdef readonly US0 v2
    cdef readonly unsigned char v3
    cdef readonly signed long v4
    cdef readonly US0 v5
    cdef readonly unsigned char v6
    cdef readonly signed long v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly object v10
    cdef readonly UH0 v11
    cdef readonly double v12
    cdef readonly double v13
    def __init__(self, v0, double v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, v10, UH0 v11, double v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US3 v0
    cdef readonly UH1 v1
    def __init__(self, US3 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US0 v0
    cdef readonly object v1
    cdef readonly UH2 v2
    def __init__(self, US0 v0, v1, UH2 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Tuple1:
    cdef readonly US0 v0
    cdef readonly object v1
    def __init__(self, US0 v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple2:
    cdef readonly double v0
    cdef readonly US3 v1
    def __init__(self, double v0, US3 v1): self.v0 = v0; self.v1 = v1
cdef class Closure0():
    cdef object v0
    cdef list v1
    def __init__(self, v0, list v1): self.v0 = v0; self.v1 = v1
    def __call__(self, Tuple0 args):
        cdef object v0 = self.v0
        cdef list v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = args.v0
        cdef double v3 = args.v1
        cdef US0 v4 = args.v2
        cdef unsigned char v5 = args.v3
        cdef signed long v6 = args.v4
        cdef US0 v7 = args.v5
        cdef unsigned char v8 = args.v6
        cdef signed long v9 = args.v7
        cdef US1 v10 = args.v8
        cdef unsigned char v11 = args.v9
        cdef object v12 = args.v10
        cdef UH0 v13 = args.v11
        cdef double v14 = args.v12
        cdef double v15 = args.v13
        cdef numpy.ndarray[object,ndim=1] v16
        cdef unsigned long long v17
        cdef numpy.ndarray[signed long long,ndim=1] v18
        cdef unsigned long long v19
        cdef numpy.ndarray[float,ndim=1] v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef bint v24
        cdef unsigned long long v25
        cdef object v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef numpy.ndarray[float,ndim=1] v30
        cdef unsigned long long v31
        cdef bint v32
        cdef bint v33
        cdef unsigned long long v34
        cdef double v35
        cdef double v36
        cdef list v37
        cdef str v38
        cdef str v39
        cdef str v40
        cdef bint v41
        cdef double v43
        cdef str v44
        cdef double v45
        cdef str v46
        cdef double v47
        cdef str v48
        cdef list v49
        cdef unsigned long long v50
        cdef str v51
        cdef object v52
        v16 = method0(v13)
        v17 = len(v2)
        v18 = numpy.empty(v17,dtype=numpy.int64)
        v19 = (<unsigned long long>0)
        method10(v17, v2, v18, v19)
        v20 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
        v21 = len(v20)
        v22 = (<unsigned long long>0)
        method12(v21, v20, v22)
        v23 = len(v16)
        v24 = (<unsigned long long>2) < v23
        if v24:
            raise Exception("The given array is too large.")
        else:
            pass
        v25 = (<unsigned long long>0)
        method13(v23, v20, v16, v25)
        del v16
        pass # import torch
        v26 = torch.from_numpy(v20)
        del v20
        v27 = v0.forward(v26)
        del v26
        v28 = v27[v18]
        del v18; del v27
        pass # import torch.nn.functional
        v29 = torch.nn.functional.softmax(v28,-1)
        del v28
        v30 = v29.cpu().detach().numpy()
        del v29
        v31 = len(v30)
        v32 = v31 == v17
        v33 = v32 == 0
        if v33:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v34 = (<unsigned long long>0)
        v35 = (<double>0.000000)
        v36 = method15(v31, v12, v30, v2, v34, v35)
        del v30
        v37 = [None]*(<unsigned long long>0)
        method16(v37, v13)
        if v7 == 0: # jack
            v38 = "[color=ff0000]J[/color]"
        elif v7 == 1: # king
            v38 = "[color=ff0000]K[/color]"
        elif v7 == 2: # queen
            v38 = "[color=ff0000]Q[/color]"
        v39 = f' (vs. {v38})'
        del v38
        v37.append(v39)
        del v39
        v40 = "".join(v37)
        del v37
        v41 = v5 == (<unsigned char>0)
        if v41:
            v43 = v36
        else:
            v43 = -v36
        v44 = '{:.5f}'.format(v43)
        v45 = libc.math.exp(v14)
        v46 = '{:.5f}'.format(v45)
        v47 = libc.math.exp(v15)
        v48 = '{:.5f}'.format(v47)
        v49 = [None]*(<unsigned long long>0)
        v50 = (<unsigned long long>0)
        method17(v17, v2, v49, v50)
        v51 = "".join(v49)
        del v49
        v52 = {'actions': v51, 'prob_op': v48, 'prob_self': v46, 'reward': v44, 'trace': v40}
        del v40; del v44; del v46; del v48; del v51
        v1.append(v52)
        del v52
        return v36
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure5():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef Heap0 v6
    cdef signed long v7
    cdef US0 v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, Heap0 v6, signed long v7, US0 v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple2 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef Heap0 v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef double v17
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v17 = v15 + v3
        v18 = US2_0(v16)
        v19 = UH0_0(v18, v2)
        del v18
        v20 = US2_0(v16)
        v21 = UH0_0(v20, v0)
        del v20
        return method30(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v17, v21, v1)
cdef class Closure4():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef Heap0 v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US0 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef US0 v13
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, Heap0 v6, US0 v7, unsigned char v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, Tuple2 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef Heap0 v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef double v14 = args.v0
        cdef US3 v15 = args.v1
        cdef double v16
        cdef US2 v17
        cdef UH0 v18
        cdef US2 v19
        cdef UH0 v20
        v16 = v14 + v3
        v17 = US2_0(v15)
        v18 = UH0_0(v17, v2)
        del v17
        v19 = US2_0(v15)
        v20 = UH0_0(v19, v0)
        del v19
        return method28(v5, v6, v7, v8, v9, v10, v11, v12, v13, v15, v4, v18, v16, v20, v1)
cdef class Closure6():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef Heap0 v6
    cdef object v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    cdef signed long v14
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, Heap0 v6, numpy.ndarray[signed long,ndim=1] v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13, signed long v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple2 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef Heap0 v6 = self.v6
        cdef numpy.ndarray[signed long,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed long v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef double v17
        cdef US2 v18
        cdef UH0 v19
        cdef US2 v20
        cdef UH0 v21
        v17 = v15 + v3
        v18 = US2_0(v16)
        v19 = UH0_0(v18, v2)
        del v18
        v20 = US2_0(v16)
        v21 = UH0_0(v20, v0)
        del v20
        return method34(v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v16, v4, v19, v17, v21, v1)
cdef class Closure3():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef Heap0 v6
    cdef object v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef US0 v12
    cdef unsigned char v13
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, Heap0 v6, numpy.ndarray[signed long,ndim=1] v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US0 v12, unsigned char v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, Tuple2 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef Heap0 v6 = self.v6
        cdef numpy.ndarray[signed long,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef double v14 = args.v0
        cdef US3 v15 = args.v1
        cdef double v16
        cdef US2 v17
        cdef UH0 v18
        cdef US2 v19
        cdef UH0 v20
        v16 = v14 + v3
        v17 = US2_0(v15)
        v18 = UH0_0(v17, v2)
        del v17
        v19 = US2_0(v15)
        v20 = UH0_0(v19, v0)
        del v19
        return method25(v5, v6, v7, v8, v9, v10, v11, v12, v13, v15, v4, v18, v16, v20, v1)
cdef class Closure2():
    cdef UH0 v0
    cdef double v1
    cdef UH0 v2
    cdef double v3
    cdef double v4
    cdef object v5
    cdef US0 v6
    cdef US0 v7
    cdef Heap0 v8
    cdef object v9
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, double v4, v5, US0 v6, US0 v7, Heap0 v8, numpy.ndarray[signed long,ndim=1] v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef double v4 = self.v4
        cdef object v5 = self.v5
        cdef US0 v6 = self.v6
        cdef US0 v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef double v10 = args.v0
        cdef US3 v11 = args.v1
        cdef double v12
        cdef US2 v13
        cdef UH0 v14
        cdef US2 v15
        cdef UH0 v16
        v12 = v10 + v3
        v13 = US2_0(v11)
        v14 = UH0_0(v13, v2)
        del v13
        v15 = US2_0(v11)
        v16 = UH0_0(v15, v0)
        del v15
        return method23(v5, v6, v7, v8, v9, v11, v4, v14, v12, v16, v1)
cdef class Closure1():
    cdef list v0
    cdef object v1
    def __init__(self, list v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef list v0 = self.v0
        cdef object v1 = self.v1
        cdef US3 v2
        cdef US3 v3
        cdef numpy.ndarray[signed long,ndim=1] v4
        cdef US3 v5
        cdef US3 v6
        cdef US3 v7
        cdef numpy.ndarray[signed long,ndim=1] v8
        cdef US3 v9
        cdef US3 v10
        cdef numpy.ndarray[signed long,ndim=1] v11
        cdef US3 v12
        cdef numpy.ndarray[signed long,ndim=1] v13
        cdef Heap0 v14
        cdef US0 v15
        cdef US0 v16
        cdef US0 v17
        cdef US0 v18
        cdef US0 v19
        cdef US0 v20
        cdef numpy.ndarray[signed long,ndim=1] v21
        cdef UH0 v22
        cdef double v23
        cdef UH0 v24
        cdef double v25
        cdef unsigned long long v26
        cdef double v27
        cdef double v28
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
        v22 = UH0_1()
        v23 = (<double>0.000000)
        v24 = UH0_1()
        v25 = (<double>0.000000)
        v26 = (<unsigned long long>0)
        v27 = (<double>0.000000)
        v28 = method18(v21, v1, v14, v22, v23, v24, v25, v26, v27)
        del v14; del v21; del v22; del v24
        return v0
cdef UH0 method1(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method1(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method3(UH1 v0, UH1 v1):
    cdef US3 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        return method3(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method5(UH1 v0, unsigned long long v1):
    cdef US3 v2
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method5(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method6(numpy.ndarray[signed long,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US3 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        v5 = v2 + (<unsigned long long>1)
        return method6(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[signed long,ndim=1] method4(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[signed long,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method5(v0, v1)
    v3 = numpy.empty(v2,dtype=numpy.int32)
    v4 = (<unsigned long long>0)
    v5 = method6(v3, v0, v4)
    return v3
cdef UH2 method2(UH1 v0, US0 v1, UH0 v2):
    cdef US2 v3
    cdef UH0 v4
    cdef US3 v5
    cdef UH1 v6
    cdef US0 v8
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
            return method2(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH1_1()
            v10 = method3(v0, v9)
            del v9
            v11 = method4(v10)
            del v10
            v12 = UH1_1()
            v13 = method2(v12, v8, v4)
            del v4; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method3(v0, v16)
        del v16
        v18 = method4(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method8(UH2 v0, unsigned long long v1):
    cdef US0 v2
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v4 = (<UH2_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method8(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US0 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v4
        v6 = v2 + (<unsigned long long>1)
        return method9(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method7(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method8(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<unsigned long long>0)
    v5 = method9(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method0(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US3 v5
    cdef US0 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method1(v0, v1)
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
            v9 = method2(v8, v7, v4)
            del v4; del v8
            return method7(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef signed long long method11(US3 v0):
    cdef signed long long v1
    if v0 == 0: # call
        v1 = (<signed long long>0)
    elif v0 == 1: # fold
        v1 = (<signed long long>1)
    elif v0 == 2: # raise
        v1 = (<signed long long>2)
    return v1
cdef void method10(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US3 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v1[v3]
        v7 = method11(v6)
        v2[v3] = v7
        method10(v0, v1, v2, v5)
    else:
        pass
cdef void method12(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<float>0.000000)
        method12(v0, v1, v4)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
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
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method13(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US0 v6
    cdef numpy.ndarray[signed long,ndim=1] v7
    cdef Tuple1 tmp0
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
        method14(v12, v1, v11, v7, v14)
        del v7
        method13(v0, v1, v2, v5)
    else:
        pass
cdef double method15(unsigned long long v0, v1, numpy.ndarray[float,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4, double v5):
    cdef bint v6
    cdef unsigned long long v7
    cdef float v8
    cdef US3 v9
    cdef double v10
    cdef double v11
    cdef double v12
    cdef double v13
    cdef double v14
    v6 = v4 < v0
    if v6:
        v7 = v4 + (<unsigned long long>1)
        v8 = v2[v4]
        v9 = v3[v4]
        v10 = <double>v8
        v11 = libc.math.log(v10)
        v12 = v1(Tuple2(v11, v9))
        v13 = v12 * v10
        v14 = v5 + v13
        return method15(v0, v1, v2, v3, v7, v14)
    else:
        return v5
cdef void method16(list v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef str v8
    cdef US3 v4
    cdef US0 v6
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1
        method16(v0, v3)
        del v3
        if v2.tag == 0: # action_
            v4 = (<US2_0>v2).v0
            if v4 == 0: # call
                v8 = "C"
            elif v4 == 1: # fold
                v8 = "F"
            elif v4 == 2: # raise
                v8 = "R"
        elif v2.tag == 1: # observation_
            v6 = (<US2_1>v2).v0
            if v6 == 0: # jack
                v8 = "[color=ff0000]J[/color]"
            elif v6 == 1: # king
                v8 = "[color=ff0000]K[/color]"
            elif v6 == 2: # queen
                v8 = "[color=ff0000]Q[/color]"
        del v2
        v0.append(v8)
    elif v1.tag == 1: # nil
        pass
cdef void method17(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, list v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US3 v6
    cdef str v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v1[v3]
        if v6 == 0: # call
            v7 = "C"
        elif v6 == 1: # fold
            v7 = "F"
        elif v6 == 2: # raise
            v7 = "R"
        v2.append(v7)
        del v7
        method17(v0, v1, v2, v5)
    else:
        pass
cdef void method19(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US0 v9
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
        method19(v0, v1, v2, v3, v6)
    else:
        pass
cdef numpy.ndarray[signed long,ndim=1] method24(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method29(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method31(US0 v0):
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef double method32(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Heap0 v7, signed long v8, US0 v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15, double v16, double v17, numpy.ndarray[signed long,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US3 v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef US2 v27
    cdef UH0 v28
    cdef double v29
    cdef double v30
    cdef double v31
    v21 = v19 < v0
    if v21:
        v22 = v19 + (<unsigned long long>1)
        v23 = v18[v19]
        v24 = v17 + v2
        v25 = US2_0(v23)
        v26 = UH0_0(v25, v3)
        del v25
        v27 = US2_0(v23)
        v28 = UH0_0(v27, v1)
        del v27
        v29 = method30(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v23, v5, v26, v4, v28, v24)
        del v26; del v28
        v30 = v29 * v16
        v31 = v20 + v30
        return method32(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v31)
    else:
        return v20
cdef double method30(v0, Heap0 v1, signed long v2, US0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef signed long v16
    cdef signed long v17
    cdef signed long v18
    cdef bint v19
    cdef bint v21
    cdef signed long v45
    cdef bint v22
    cdef bint v23
    cdef bint v26
    cdef bint v27
    cdef signed long v28
    cdef signed long v29
    cdef bint v30
    cdef signed long v31
    cdef signed long v32
    cdef bint v33
    cdef signed long v36
    cdef bint v34
    cdef bint v37
    cdef bint v38
    cdef bint v39
    cdef bint v46
    cdef unsigned char v50
    cdef signed long v51
    cdef bint v47
    cdef bint v52
    cdef signed long v54
    cdef bint v55
    cdef signed long v57
    cdef signed long v58
    cdef bint v59
    cdef signed long v61
    cdef signed long v62
    cdef US0 v63
    cdef unsigned char v64
    cdef signed long v65
    cdef US0 v66
    cdef unsigned char v67
    cdef signed long v68
    cdef double v69
    cdef bint v70
    cdef signed long v72
    cdef bint v73
    cdef signed long v75
    cdef signed long v76
    cdef signed long v78
    cdef signed long v79
    cdef US0 v80
    cdef unsigned char v81
    cdef signed long v82
    cdef US0 v83
    cdef unsigned char v84
    cdef signed long v85
    cdef double v86
    cdef signed long v87
    cdef signed long v88
    cdef numpy.ndarray[signed long,ndim=1] v89
    cdef bint v90
    cdef US1 v91
    cdef object v92
    cdef unsigned long long v94
    cdef double v95
    cdef double v96
    cdef double v97
    cdef unsigned long long v98
    cdef double v99
    if v10 == 0: # call
        v16 = method31(v3)
        v17 = method31(v7)
        v18 = method31(v4)
        v19 = v17 == v16
        if v19:
            v21 = v18 == v16
        else:
            v21 = 0
        if v21:
            v22 = v17 < v18
            if v22:
                v45 = (<signed long>-1)
            else:
                v23 = v17 > v18
                if v23:
                    v45 = (<signed long>1)
                else:
                    v45 = (<signed long>0)
        else:
            if v19:
                v45 = (<signed long>1)
            else:
                v26 = v18 == v16
                if v26:
                    v45 = (<signed long>-1)
                else:
                    v27 = v17 > v16
                    if v27:
                        v28, v29 = v17, v16
                    else:
                        v28, v29 = v16, v17
                    v30 = v18 > v16
                    if v30:
                        v31, v32 = v18, v16
                    else:
                        v31, v32 = v16, v18
                    v33 = v28 < v31
                    if v33:
                        v36 = (<signed long>-1)
                    else:
                        v34 = v28 > v31
                        if v34:
                            v36 = (<signed long>1)
                        else:
                            v36 = (<signed long>0)
                    v37 = v36 == (<signed long>0)
                    if v37:
                        v38 = v29 < v32
                        if v38:
                            v45 = (<signed long>-1)
                        else:
                            v39 = v29 > v32
                            if v39:
                                v45 = (<signed long>1)
                            else:
                                v45 = (<signed long>0)
                    else:
                        v45 = v36
        v46 = v45 == (<signed long>1)
        if v46:
            v50, v51 = v8, v6
        else:
            v47 = v45 == (<signed long>-1)
            if v47:
                v50, v51 = v5, v6
            else:
                v50, v51 = v8, (<signed long>0)
        v52 = v50 == (<unsigned char>0)
        if v52:
            v54 = v51
        else:
            v54 = -v51
        v55 = v8 == (<unsigned char>0)
        if v55:
            v57 = v54
        else:
            v57 = -v54
        v58 = v57 + v6
        v59 = v5 == (<unsigned char>0)
        if v59:
            v61 = v54
        else:
            v61 = -v54
        v62 = v61 + v6
        if v55:
            v63, v64, v65, v66, v67, v68 = v7, v8, v58, v4, v5, v62
        else:
            v63, v64, v65, v66, v67, v68 = v4, v5, v62, v7, v8, v58
        v69 = <double>v54
        return v69
    elif v10 == 1: # fold
        v70 = v5 == (<unsigned char>0)
        if v70:
            v72 = v9
        else:
            v72 = -v9
        v73 = v8 == (<unsigned char>0)
        if v73:
            v75 = v72
        else:
            v75 = -v72
        v76 = v75 + v9
        if v70:
            v78 = v72
        else:
            v78 = -v72
        v79 = v78 + v6
        if v73:
            v80, v81, v82, v83, v84, v85 = v7, v8, v76, v4, v5, v79
        else:
            v80, v81, v82, v83, v84, v85 = v4, v5, v79, v7, v8, v76
        v86 = <double>v72
        return v86
    elif v10 == 2: # raise
        v87 = v2 - (<signed long>1)
        v88 = v6 + (<signed long>4)
        v89 = method29(v1, v7, v8, v88, v4, v5, v6, v87)
        v90 = v5 == (<unsigned char>0)
        if v90:
            v91 = US1_1(v3)
            v92 = Closure5(v14, v15, v12, v13, v11, v0, v1, v87, v3, v7, v8, v88, v4, v5, v6)
            return v0(Tuple0(v89, v11, v4, v5, v6, v7, v8, v88, v91, (<unsigned char>0), v92, v12, v13, v15))
        else:
            v94 = len(v89)
            v95 = <double>v94
            v96 = (<double>1.000000) / v95
            v97 = libc.math.log(v96)
            v98 = (<unsigned long long>0)
            v99 = (<double>0.000000)
            return method32(v94, v14, v15, v12, v13, v11, v0, v1, v87, v3, v7, v8, v88, v4, v5, v6, v96, v97, v89, v98, v99)
cdef double method28(v0, Heap0 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, US3 v9, double v10, UH0 v11, double v12, UH0 v13, double v14):
    cdef signed long v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef US1 v18
    cdef object v19
    cdef unsigned long long v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef unsigned long long v25
    cdef double v26
    cdef object v29
    cdef signed long v31
    cdef signed long v32
    cdef numpy.ndarray[signed long,ndim=1] v33
    cdef bint v34
    cdef US1 v35
    cdef object v36
    cdef unsigned long long v38
    cdef double v39
    cdef double v40
    cdef double v41
    cdef unsigned long long v42
    cdef double v43
    if v9 == 0: # call
        v15 = (<signed long>2)
        v16 = method29(v1, v5, v6, v7, v2, v3, v4, v15)
        v17 = v3 == (<unsigned char>0)
        if v17:
            v18 = US1_1(v8)
            v19 = Closure5(v13, v14, v11, v12, v10, v0, v1, v15, v8, v5, v6, v7, v2, v3, v4)
            return v0(Tuple0(v16, v10, v2, v3, v4, v5, v6, v7, v18, (<unsigned char>0), v19, v11, v12, v14))
        else:
            v21 = len(v16)
            v22 = <double>v21
            v23 = (<double>1.000000) / v22
            v24 = libc.math.log(v23)
            v25 = (<unsigned long long>0)
            v26 = (<double>0.000000)
            return method32(v21, v13, v14, v11, v12, v10, v0, v1, v15, v8, v5, v6, v7, v2, v3, v4, v23, v24, v16, v25, v26)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v31 = (<signed long>1)
        v32 = v4 + (<signed long>4)
        v33 = method29(v1, v5, v6, v32, v2, v3, v4, v31)
        v34 = v3 == (<unsigned char>0)
        if v34:
            v35 = US1_1(v8)
            v36 = Closure5(v13, v14, v11, v12, v10, v0, v1, v31, v8, v5, v6, v32, v2, v3, v4)
            return v0(Tuple0(v33, v10, v2, v3, v4, v5, v6, v32, v35, (<unsigned char>0), v36, v11, v12, v14))
        else:
            v38 = len(v33)
            v39 = <double>v38
            v40 = (<double>1.000000) / v39
            v41 = libc.math.log(v40)
            v42 = (<unsigned long long>0)
            v43 = (<double>0.000000)
            return method32(v38, v13, v14, v11, v12, v10, v0, v1, v31, v8, v5, v6, v32, v2, v3, v4, v40, v41, v33, v42, v43)
cdef double method33(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Heap0 v7, US0 v8, unsigned char v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US0 v14, double v15, double v16, numpy.ndarray[signed long,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US3 v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    v20 = v18 < v0
    if v20:
        v21 = v18 + (<unsigned long long>1)
        v22 = v17[v18]
        v23 = v16 + v2
        v24 = US2_0(v22)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v22)
        v27 = UH0_0(v26, v1)
        del v26
        v28 = method28(v6, v7, v8, v9, v10, v11, v12, v13, v14, v22, v5, v25, v4, v27, v23)
        del v25; del v27
        v29 = v28 * v15
        v30 = v19 + v29
        return method33(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v30)
    else:
        return v19
cdef double method27(v0, Heap0 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, double v9, UH0 v10, double v11, UH0 v12, double v13):
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef bint v15
    cdef US1 v16
    cdef object v17
    cdef unsigned long long v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef unsigned long long v23
    cdef double v24
    v14 = v1.v2
    v15 = v6 == (<unsigned char>0)
    if v15:
        v16 = US1_1(v8)
        v17 = Closure4(v12, v13, v10, v11, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8)
        return v0(Tuple0(v14, v9, v5, v6, v7, v2, v3, v4, v16, (<unsigned char>0), v17, v10, v11, v13))
    else:
        v19 = len(v14)
        v20 = <double>v19
        v21 = (<double>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = (<unsigned long long>0)
        v24 = (<double>0.000000)
        return method33(v19, v12, v13, v10, v11, v9, v0, v1, v2, v3, v4, v5, v6, v7, v8, v21, v22, v14, v23, v24)
cdef double method26(numpy.ndarray[signed long,ndim=1] v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, double v9, UH0 v10, double v11, UH0 v12, double v13, unsigned long long v14, double v15):
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef bint v19
    cdef US0 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef US2 v27
    cdef UH0 v28
    cdef double v29
    cdef unsigned long long v30
    cdef double v31
    cdef double v33
    v16 = len(v0)
    v17 = <double>v16
    v18 = (<double>1.000000) / v17
    v19 = v14 < v16
    if v19:
        v20 = v0[v14]
        v21 = <double>v16
        v22 = (<double>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v9
        v25 = US2_1(v20)
        v26 = UH0_0(v25, v10)
        del v25
        v27 = US2_1(v20)
        v28 = UH0_0(v27, v12)
        del v27
        v29 = method27(v1, v2, v3, v4, v5, v6, v7, v8, v20, v24, v26, v11, v28, v13)
        del v26; del v28
        v30 = v14 + (<unsigned long long>1)
        v31 = v15 + v29
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v30, v31)
    else:
        v33 = v15 * v18
        return v33
cdef double method35(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, signed long v15, double v16, double v17, numpy.ndarray[signed long,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US3 v23
    cdef double v24
    cdef US2 v25
    cdef UH0 v26
    cdef US2 v27
    cdef UH0 v28
    cdef double v29
    cdef double v30
    cdef double v31
    v21 = v19 < v0
    if v21:
        v22 = v19 + (<unsigned long long>1)
        v23 = v18[v19]
        v24 = v17 + v2
        v25 = US2_0(v23)
        v26 = UH0_0(v25, v3)
        del v25
        v27 = US2_0(v23)
        v28 = UH0_0(v27, v1)
        del v27
        v29 = method34(v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v23, v5, v26, v4, v28, v24)
        del v26; del v28
        v30 = v29 * v16
        v31 = v20 + v30
        return method35(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v31)
    else:
        return v20
cdef double method34(v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US3 v10, double v11, UH0 v12, double v13, UH0 v14, double v15):
    cdef bint v16
    cdef US0 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US0 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef double v24
    cdef bint v26
    cdef signed long v28
    cdef bint v29
    cdef signed long v31
    cdef signed long v32
    cdef signed long v34
    cdef signed long v35
    cdef US0 v36
    cdef unsigned char v37
    cdef signed long v38
    cdef US0 v39
    cdef unsigned char v40
    cdef signed long v41
    cdef double v42
    cdef signed long v43
    cdef signed long v44
    cdef numpy.ndarray[signed long,ndim=1] v45
    cdef bint v46
    cdef US1 v47
    cdef object v48
    cdef unsigned long long v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef unsigned long long v54
    cdef double v55
    if v10 == 0: # call
        v16 = v8 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v7, v8, v6, v4, v5, v6
        else:
            v17, v18, v19, v20, v21, v22 = v4, v5, v6, v7, v8, v6
        v23 = (<unsigned long long>0)
        v24 = (<double>0.000000)
        return method26(v2, v0, v1, v20, v21, v22, v17, v18, v19, v11, v12, v13, v14, v15, v23, v24)
    elif v10 == 1: # fold
        v26 = v5 == (<unsigned char>0)
        if v26:
            v28 = v9
        else:
            v28 = -v9
        v29 = v8 == (<unsigned char>0)
        if v29:
            v31 = v28
        else:
            v31 = -v28
        v32 = v31 + v9
        if v26:
            v34 = v28
        else:
            v34 = -v28
        v35 = v34 + v6
        if v29:
            v36, v37, v38, v39, v40, v41 = v7, v8, v32, v4, v5, v35
        else:
            v36, v37, v38, v39, v40, v41 = v4, v5, v35, v7, v8, v32
        v42 = <double>v28
        return v42
    elif v10 == 2: # raise
        v43 = v3 - (<signed long>1)
        v44 = v6 + (<signed long>2)
        v45 = method29(v1, v7, v8, v44, v4, v5, v6, v43)
        v46 = v5 == (<unsigned char>0)
        if v46:
            v47 = US1_0()
            v48 = Closure6(v14, v15, v12, v13, v11, v0, v1, v2, v43, v7, v8, v44, v4, v5, v6)
            return v0(Tuple0(v45, v11, v4, v5, v6, v7, v8, v44, v47, (<unsigned char>0), v48, v12, v13, v15))
        else:
            v50 = len(v45)
            v51 = <double>v50
            v52 = (<double>1.000000) / v51
            v53 = libc.math.log(v52)
            v54 = (<unsigned long long>0)
            v55 = (<double>0.000000)
            return method35(v50, v14, v15, v12, v13, v11, v0, v1, v2, v43, v7, v8, v44, v4, v5, v6, v52, v53, v45, v54, v55)
cdef double method25(v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, US3 v9, double v10, UH0 v11, double v12, UH0 v13, double v14):
    cdef bint v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef unsigned long long v22
    cdef double v23
    cdef bint v25
    cdef signed long v27
    cdef bint v28
    cdef signed long v30
    cdef signed long v31
    cdef signed long v33
    cdef signed long v34
    cdef US0 v35
    cdef unsigned char v36
    cdef signed long v37
    cdef US0 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef double v41
    cdef signed long v42
    cdef signed long v43
    cdef numpy.ndarray[signed long,ndim=1] v44
    cdef bint v45
    cdef US1 v46
    cdef object v47
    cdef unsigned long long v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef unsigned long long v53
    cdef double v54
    if v9 == 0: # call
        v15 = v8 == (<unsigned char>0)
        if v15:
            v16, v17, v18, v19, v20, v21 = v7, v8, v6, v4, v5, v6
        else:
            v16, v17, v18, v19, v20, v21 = v4, v5, v6, v7, v8, v6
        v22 = (<unsigned long long>0)
        v23 = (<double>0.000000)
        return method26(v2, v0, v1, v19, v20, v21, v16, v17, v18, v10, v11, v12, v13, v14, v22, v23)
    elif v9 == 1: # fold
        v25 = v5 == (<unsigned char>0)
        if v25:
            v27 = v6
        else:
            v27 = -v6
        v28 = v8 == (<unsigned char>0)
        if v28:
            v30 = v27
        else:
            v30 = -v27
        v31 = v30 + v6
        if v25:
            v33 = v27
        else:
            v33 = -v27
        v34 = v33 + v6
        if v28:
            v35, v36, v37, v38, v39, v40 = v7, v8, v31, v4, v5, v34
        else:
            v35, v36, v37, v38, v39, v40 = v4, v5, v34, v7, v8, v31
        v41 = <double>v27
        return v41
    elif v9 == 2: # raise
        v42 = v3 - (<signed long>1)
        v43 = v6 + (<signed long>2)
        v44 = method29(v1, v7, v8, v43, v4, v5, v6, v42)
        v45 = v5 == (<unsigned char>0)
        if v45:
            v46 = US1_0()
            v47 = Closure6(v13, v14, v11, v12, v10, v0, v1, v2, v42, v7, v8, v43, v4, v5, v6)
            return v0(Tuple0(v44, v10, v4, v5, v6, v7, v8, v43, v46, (<unsigned char>0), v47, v11, v12, v14))
        else:
            v49 = len(v44)
            v50 = <double>v49
            v51 = (<double>1.000000) / v50
            v52 = libc.math.log(v51)
            v53 = (<unsigned long long>0)
            v54 = (<double>0.000000)
            return method35(v49, v13, v14, v11, v12, v10, v0, v1, v2, v42, v7, v8, v43, v4, v5, v6, v51, v52, v44, v53, v54)
cdef double method36(unsigned long long v0, UH0 v1, double v2, UH0 v3, double v4, double v5, v6, Heap0 v7, numpy.ndarray[signed long,ndim=1] v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US0 v13, unsigned char v14, double v15, double v16, numpy.ndarray[signed long,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US3 v22
    cdef double v23
    cdef US2 v24
    cdef UH0 v25
    cdef US2 v26
    cdef UH0 v27
    cdef double v28
    cdef double v29
    cdef double v30
    v20 = v18 < v0
    if v20:
        v21 = v18 + (<unsigned long long>1)
        v22 = v17[v18]
        v23 = v16 + v2
        v24 = US2_0(v22)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v22)
        v27 = UH0_0(v26, v1)
        del v26
        v28 = method25(v6, v7, v8, v9, v10, v11, v12, v13, v14, v22, v5, v25, v4, v27, v23)
        del v25; del v27
        v29 = v28 * v15
        v30 = v19 + v29
        return method36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v30)
    else:
        return v19
cdef double method23(v0, US0 v1, US0 v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, US3 v5, double v6, UH0 v7, double v8, UH0 v9, double v10):
    cdef signed long v11
    cdef unsigned char v12
    cdef signed long v13
    cdef unsigned char v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef bint v16
    cdef US1 v17
    cdef object v18
    cdef unsigned long long v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef unsigned long long v24
    cdef double v25
    cdef object v28
    cdef signed long v30
    cdef unsigned char v31
    cdef signed long v32
    cdef unsigned char v33
    cdef signed long v34
    cdef numpy.ndarray[signed long,ndim=1] v35
    cdef bint v36
    cdef US1 v37
    cdef object v38
    cdef unsigned long long v40
    cdef double v41
    cdef double v42
    cdef double v43
    cdef unsigned long long v44
    cdef double v45
    if v5 == 0: # call
        v11 = (<signed long>2)
        v12 = (<unsigned char>1)
        v13 = (<signed long>1)
        v14 = (<unsigned char>0)
        v15 = method24(v3, v1, v14, v13, v2, v12, v11)
        v16 = v12 == (<unsigned char>0)
        if v16:
            v17 = US1_0()
            v18 = Closure3(v9, v10, v7, v8, v6, v0, v3, v4, v11, v1, v14, v13, v2, v12)
            return v0(Tuple0(v15, v6, v2, v12, v13, v1, v14, v13, v17, (<unsigned char>0), v18, v7, v8, v10))
        else:
            v20 = len(v15)
            v21 = <double>v20
            v22 = (<double>1.000000) / v21
            v23 = libc.math.log(v22)
            v24 = (<unsigned long long>0)
            v25 = (<double>0.000000)
            return method36(v20, v9, v10, v7, v8, v6, v0, v3, v4, v11, v1, v14, v13, v2, v12, v22, v23, v15, v24, v25)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v30 = (<signed long>1)
        v31 = (<unsigned char>1)
        v32 = (<signed long>1)
        v33 = (<unsigned char>0)
        v34 = (<signed long>3)
        v35 = method29(v3, v1, v33, v34, v2, v31, v32, v30)
        v36 = v31 == (<unsigned char>0)
        if v36:
            v37 = US1_0()
            v38 = Closure6(v9, v10, v7, v8, v6, v0, v3, v4, v30, v1, v33, v34, v2, v31, v32)
            return v0(Tuple0(v35, v6, v2, v31, v32, v1, v33, v34, v37, (<unsigned char>0), v38, v7, v8, v10))
        else:
            v40 = len(v35)
            v41 = <double>v40
            v42 = (<double>1.000000) / v41
            v43 = libc.math.log(v42)
            v44 = (<unsigned long long>0)
            v45 = (<double>0.000000)
            return method35(v40, v9, v10, v7, v8, v6, v0, v3, v4, v30, v1, v33, v34, v2, v31, v32, v42, v43, v35, v44, v45)
cdef double method22(v0, Heap0 v1, US0 v2, US0 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9):
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef US1 v11
    cdef object v12
    v10 = v1.v2
    v11 = US1_0()
    v12 = Closure2(v8, v9, v6, v7, v5, v0, v2, v3, v1, v4)
    return v0(Tuple0(v10, v5, v2, (<unsigned char>0), (<signed long>1), v3, (<unsigned char>1), (<signed long>1), v11, (<unsigned char>0), v12, v6, v7, v9))
cdef double method21(numpy.ndarray[signed long,ndim=1] v0, v1, Heap0 v2, US0 v3, double v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef US0 v15
    cdef unsigned long long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    cdef double v25
    cdef unsigned long long v26
    cdef double v27
    cdef double v29
    v11 = len(v0)
    v12 = <double>v11
    v13 = (<double>1.000000) / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - (<unsigned long long>1)
        v17 = numpy.empty(v16,dtype=numpy.int32)
        v18 = (<unsigned long long>0)
        method19(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = (<double>1.000000) / v19
        v21 = libc.math.log(v20)
        v22 = v21 + v4
        v23 = US2_1(v15)
        v24 = UH0_0(v23, v7)
        del v23
        v25 = method22(v1, v2, v3, v15, v17, v22, v5, v6, v24, v8)
        del v17; del v24
        v26 = v9 + (<unsigned long long>1)
        v27 = v10 + v25
        return method21(v0, v1, v2, v3, v4, v5, v6, v7, v8, v26, v27)
    else:
        v29 = v10 * v13
        return v29
cdef double method20(v0, Heap0 v1, US0 v2, numpy.ndarray[signed long,ndim=1] v3, double v4, UH0 v5, double v6, UH0 v7, double v8):
    cdef unsigned long long v9
    cdef double v10
    v9 = (<unsigned long long>0)
    v10 = (<double>0.000000)
    return method21(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9, v10)
cdef double method18(numpy.ndarray[signed long,ndim=1] v0, v1, Heap0 v2, UH0 v3, double v4, UH0 v5, double v6, unsigned long long v7, double v8):
    cdef unsigned long long v9
    cdef double v10
    cdef double v11
    cdef bint v12
    cdef US0 v13
    cdef unsigned long long v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef US2 v20
    cdef UH0 v21
    cdef double v22
    cdef unsigned long long v23
    cdef double v24
    cdef double v26
    v9 = len(v0)
    v10 = <double>v9
    v11 = (<double>1.000000) / v10
    v12 = v7 < v9
    if v12:
        v13 = v0[v7]
        v14 = v9 - (<unsigned long long>1)
        v15 = numpy.empty(v14,dtype=numpy.int32)
        v16 = (<unsigned long long>0)
        method19(v14, v7, v0, v15, v16)
        v17 = <double>v9
        v18 = (<double>1.000000) / v17
        v19 = libc.math.log(v18)
        v20 = US2_1(v13)
        v21 = UH0_0(v20, v3)
        del v20
        v22 = method20(v1, v2, v13, v15, v19, v21, v4, v5, v6)
        del v15; del v21
        v23 = v7 + (<unsigned long long>1)
        v24 = v8 + v22
        return method18(v0, v1, v2, v3, v4, v5, v6, v23, v24)
    else:
        v26 = v8 * v11
        return v26
cpdef void main():
    cdef list v0
    cdef object v1
    cdef object v2
    cdef object v3
    v0 = [None]*(<unsigned long long>0)
    pass # import nets
    v1 = nets.small((<unsigned long long>30),(<unsigned long long>64),(<signed long long>3))
    v2 = Closure0(v1, v0)
    del v1
    pass # import ui_replay
    v3 = Closure1(v0, v2)
    del v0; del v2
    ui_replay.run(v3)
