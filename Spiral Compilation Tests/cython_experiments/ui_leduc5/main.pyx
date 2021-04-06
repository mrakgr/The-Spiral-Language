import ui_replay
import nets
import numpy
cimport numpy
cimport libc.math
import torch
import torch.nn.functional
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # call
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # fold
    def __init__(self): self.tag = 1
cdef class US1_2(US1): # raise
    def __init__(self): self.tag = 2
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # jack
    def __init__(self): self.tag = 0
cdef class US2_1(US2): # king
    def __init__(self): self.tag = 1
cdef class US2_2(US2): # queen
    def __init__(self): self.tag = 2
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # action_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # observation_
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
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple0:
    cdef readonly UH0 v0
    cdef readonly double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US1 v0
    cdef readonly UH1 v1
    def __init__(self, US1 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US2 v0
    cdef readonly object v1
    cdef readonly UH2 v2
    def __init__(self, US2 v0, v1, UH2 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Tuple1:
    cdef readonly US2 v0
    cdef readonly object v1
    def __init__(self, US2 v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple2:
    cdef readonly UH0 v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple3:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 1; self.v0 = v0
cdef class Closure4():
    cdef object v0
    cdef list v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US3 v8
    cdef double v9
    def __init__(self, v0, list v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US3 v8, double v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef list v1 = self.v1
        cdef US2 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US3 v8 = self.v8
        cdef double v9 = self.v9
        cdef UH0 v10 = args.v0
        cdef double v11 = args.v1
        cdef UH0 v12 = args.v2
        cdef double v13 = args.v3
        cdef double v14
        v14 =  -v9
        return v9
cdef class Closure3():
    cdef object v0
    cdef list v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US2 v8
    cdef object v9
    cdef Heap0 v10
    cdef signed long v11
    def __init__(self, v0, list v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US2 v8, numpy.ndarray[object,ndim=1] v9, Heap0 v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef list v1 = self.v1
        cdef US2 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US2 v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = args.v0
        cdef double v13 = args.v1
        cdef UH0 v14 = args.v2
        cdef double v15 = args.v3
        cdef bint v16
        cdef numpy.ndarray[object,ndim=1] v17
        cdef unsigned long long v18
        cdef numpy.ndarray[signed long long,ndim=1] v19
        cdef unsigned long long v20
        cdef numpy.ndarray[float,ndim=1] v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef unsigned long long v24
        cdef bint v25
        cdef unsigned long long v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef object v30
        cdef numpy.ndarray[float,ndim=1] v31
        cdef unsigned long long v32
        cdef bint v33
        cdef bint v34
        cdef unsigned long long v35
        cdef double v36
        cdef double v37
        cdef list v38
        cdef str v39
        cdef str v40
        cdef str v41
        cdef str v42
        cdef double v43
        cdef str v44
        cdef double v45
        cdef str v46
        cdef list v47
        cdef unsigned long long v48
        cdef str v49
        cdef object v50
        cdef unsigned long long v51
        cdef double v52
        cdef double v53
        cdef double v54
        cdef unsigned long long v55
        cdef double v56
        v16 = v3 == 0
        if v16:
            v17 = method5(v12)
            v18 = len(v9)
            v19 = numpy.empty(v18,dtype=numpy.int64)
            v20 = 0
            method15(v18, v9, v19, v20)
            v21 = numpy.empty(30,dtype=numpy.float32)
            v22 = len(v21)
            v23 = 0
            method17(v22, v21, v23)
            v24 = len(v17)
            v25 = 2 < v24
            if v25:
                raise Exception("The given array is too large.")
            else:
                pass
            v26 = 0
            method18(v24, v21, v17, v26)
            del v17
            pass # import torch
            v27 = torch.from_numpy(v21)
            del v21
            v28 = v0.forward(v27)
            del v27
            v29 = v28[v19]
            del v19; del v28
            pass # import torch.nn.functional
            v30 = torch.nn.functional.softmax(v29,-1)
            del v29
            v31 = v30.cpu().detach().numpy()
            del v30
            v32 = len(v31)
            v33 = v32 == v18
            v34 = v33 == 0
            if v34:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v35 = 0
            v36 = 0.000000
            v37 = method29(v32, v0, v1, v10, v11, v8, v5, v6, v7, v2, v3, v4, v14, v15, v12, v13, v31, v9, v35, v36)
            del v31
            v38 = [None]*0
            method36(v38, v12)
            v39 = "".join(v38)
            del v38
            if v5.tag == 0: # jack
                v40 = "[color=ff0000]J[/color]"
            elif v5.tag == 1: # king
                v40 = "[color=ff0000]K[/color]"
            elif v5.tag == 2: # queen
                v40 = "[color=ff0000]Q[/color]"
            v41 = f'{v39} (vs. {v40})'
            del v39; del v40
            v42 = '{:.5f}'.format(v37)
            v43 = libc.math.exp(v13)
            v44 = '{:.5f}'.format(v43)
            v45 = libc.math.exp(v15)
            v46 = '{:.5f}'.format(v45)
            v47 = [None]*0
            v48 = 0
            method37(v18, v9, v47, v48)
            v49 = "".join(v47)
            del v47
            v50 = {'trace': v41, 'reward': v42, 'prob_self': v44, 'prob_op': v46, 'actions': v49}
            del v41; del v42; del v44; del v46; del v49
            v1.append(v50)
            del v50
            return v37
        else:
            v51 = len(v9)
            v52 = <double>v51
            v53 = 1.000000 / v52
            v54 = libc.math.log(v53)
            v55 = 0
            v56 = 0.000000
            return method38(v51, v0, v1, v10, v11, v8, v5, v6, v7, v2, v3, v4, v14, v15, v12, v13, v53, v54, v9, v55, v56)
cdef class Closure2():
    cdef object v0
    cdef object v1
    cdef list v2
    cdef Heap0 v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US2 v7
    cdef unsigned char v8
    cdef signed long v9
    def __init__(self, numpy.ndarray[object,ndim=1] v0, v1, list v2, Heap0 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef numpy.ndarray[object,ndim=1] v0 = self.v0
        cdef object v1 = self.v1
        cdef list v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef UH0 v10 = args.v0
        cdef double v11 = args.v1
        cdef UH0 v12 = args.v2
        cdef double v13 = args.v3
        cdef unsigned long long v14
        cdef double v15
        v14 = 0
        v15 = 0.000000
        return method25(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15)
cdef class Closure5():
    cdef object v0
    cdef list v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef Heap0 v9
    cdef object v10
    cdef signed long v11
    def __init__(self, v0, list v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, numpy.ndarray[object,ndim=1] v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef list v1 = self.v1
        cdef US2 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = args.v0
        cdef double v13 = args.v1
        cdef UH0 v14 = args.v2
        cdef double v15 = args.v3
        cdef bint v16
        cdef numpy.ndarray[object,ndim=1] v17
        cdef unsigned long long v18
        cdef numpy.ndarray[signed long long,ndim=1] v19
        cdef unsigned long long v20
        cdef numpy.ndarray[float,ndim=1] v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef unsigned long long v24
        cdef bint v25
        cdef unsigned long long v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef object v30
        cdef numpy.ndarray[float,ndim=1] v31
        cdef unsigned long long v32
        cdef bint v33
        cdef bint v34
        cdef unsigned long long v35
        cdef double v36
        cdef double v37
        cdef list v38
        cdef str v39
        cdef str v40
        cdef str v41
        cdef str v42
        cdef double v43
        cdef str v44
        cdef double v45
        cdef str v46
        cdef list v47
        cdef unsigned long long v48
        cdef str v49
        cdef object v50
        cdef unsigned long long v51
        cdef double v52
        cdef double v53
        cdef double v54
        cdef unsigned long long v55
        cdef double v56
        v16 = v3 == 0
        if v16:
            v17 = method5(v12)
            v18 = len(v8)
            v19 = numpy.empty(v18,dtype=numpy.int64)
            v20 = 0
            method15(v18, v8, v19, v20)
            v21 = numpy.empty(30,dtype=numpy.float32)
            v22 = len(v21)
            v23 = 0
            method17(v22, v21, v23)
            v24 = len(v17)
            v25 = 2 < v24
            if v25:
                raise Exception("The given array is too large.")
            else:
                pass
            v26 = 0
            method18(v24, v21, v17, v26)
            del v17
            pass # import torch
            v27 = torch.from_numpy(v21)
            del v21
            v28 = v0.forward(v27)
            del v27
            v29 = v28[v19]
            del v19; del v28
            pass # import torch.nn.functional
            v30 = torch.nn.functional.softmax(v29,-1)
            del v29
            v31 = v30.cpu().detach().numpy()
            del v30
            v32 = len(v31)
            v33 = v32 == v18
            v34 = v33 == 0
            if v34:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v35 = 0
            v36 = 0.000000
            v37 = method41(v32, v0, v1, v9, v10, v11, v5, v6, v7, v2, v3, v4, v14, v15, v12, v13, v31, v8, v35, v36)
            del v31
            v38 = [None]*0
            method36(v38, v12)
            v39 = "".join(v38)
            del v38
            if v5.tag == 0: # jack
                v40 = "[color=ff0000]J[/color]"
            elif v5.tag == 1: # king
                v40 = "[color=ff0000]K[/color]"
            elif v5.tag == 2: # queen
                v40 = "[color=ff0000]Q[/color]"
            v41 = f'{v39} (vs. {v40})'
            del v39; del v40
            v42 = '{:.5f}'.format(v37)
            v43 = libc.math.exp(v13)
            v44 = '{:.5f}'.format(v43)
            v45 = libc.math.exp(v15)
            v46 = '{:.5f}'.format(v45)
            v47 = [None]*0
            v48 = 0
            method37(v18, v8, v47, v48)
            v49 = "".join(v47)
            del v47
            v50 = {'trace': v41, 'reward': v42, 'prob_self': v44, 'prob_op': v46, 'actions': v49}
            del v41; del v42; del v44; del v46; del v49
            v1.append(v50)
            del v50
            return v37
        else:
            v51 = len(v8)
            v52 = <double>v51
            v53 = 1.000000 / v52
            v54 = libc.math.log(v53)
            v55 = 0
            v56 = 0.000000
            return method42(v51, v0, v1, v9, v10, v11, v5, v6, v7, v2, v3, v4, v14, v15, v12, v13, v53, v54, v8, v55, v56)
cdef class Closure1():
    cdef object v0
    cdef list v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    def __init__(self, v0, list v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, numpy.ndarray[object,ndim=1] v7, Heap0 v8, numpy.ndarray[object,ndim=1] v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef list v1 = self.v1
        cdef US2 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = args.v0
        cdef double v12 = args.v1
        cdef UH0 v13 = args.v2
        cdef double v14 = args.v3
        cdef bint v15
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
        cdef str v41
        cdef double v42
        cdef str v43
        cdef double v44
        cdef str v45
        cdef list v46
        cdef unsigned long long v47
        cdef str v48
        cdef object v49
        cdef unsigned long long v50
        cdef double v51
        cdef double v52
        cdef double v53
        cdef unsigned long long v54
        cdef double v55
        v15 = v3 == 0
        if v15:
            v16 = method5(v11)
            v17 = len(v7)
            v18 = numpy.empty(v17,dtype=numpy.int64)
            v19 = 0
            method15(v17, v7, v18, v19)
            v20 = numpy.empty(30,dtype=numpy.float32)
            v21 = len(v20)
            v22 = 0
            method17(v21, v20, v22)
            v23 = len(v16)
            v24 = 2 < v23
            if v24:
                raise Exception("The given array is too large.")
            else:
                pass
            v25 = 0
            method18(v23, v20, v16, v25)
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
            v34 = 0
            v35 = 0.000000
            v36 = method23(v31, v0, v1, v8, v9, v10, v5, v6, v4, v2, v3, v13, v14, v11, v12, v30, v7, v34, v35)
            del v30
            v37 = [None]*0
            method36(v37, v11)
            v38 = "".join(v37)
            del v37
            if v5.tag == 0: # jack
                v39 = "[color=ff0000]J[/color]"
            elif v5.tag == 1: # king
                v39 = "[color=ff0000]K[/color]"
            elif v5.tag == 2: # queen
                v39 = "[color=ff0000]Q[/color]"
            v40 = f'{v38} (vs. {v39})'
            del v38; del v39
            v41 = '{:.5f}'.format(v36)
            v42 = libc.math.exp(v12)
            v43 = '{:.5f}'.format(v42)
            v44 = libc.math.exp(v14)
            v45 = '{:.5f}'.format(v44)
            v46 = [None]*0
            v47 = 0
            method37(v17, v7, v46, v47)
            v48 = "".join(v46)
            del v46
            v49 = {'trace': v40, 'reward': v41, 'prob_self': v43, 'prob_op': v45, 'actions': v48}
            del v40; del v41; del v43; del v45; del v48
            v1.append(v49)
            del v49
            return v36
        else:
            v50 = len(v7)
            v51 = <double>v50
            v52 = 1.000000 / v51
            v53 = libc.math.log(v52)
            v54 = 0
            v55 = 0.000000
            return method43(v50, v0, v1, v8, v9, v10, v5, v6, v4, v2, v3, v13, v14, v11, v12, v52, v53, v7, v54, v55)
cdef class Closure0():
    cdef list v0
    cdef object v1
    cdef UH0 v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    def __init__(self, list v0, v1, UH0 v2, double v3, UH0 v4, double v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
    def __call__(self):
        cdef list v0 = self.v0
        cdef object v1 = self.v1
        cdef UH0 v2 = self.v2
        cdef double v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef double v5 = self.v5
        cdef US1 v6
        cdef US1 v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef US1 v9
        cdef US1 v10
        cdef US1 v11
        cdef numpy.ndarray[object,ndim=1] v12
        cdef US1 v13
        cdef US1 v14
        cdef numpy.ndarray[object,ndim=1] v15
        cdef US1 v16
        cdef numpy.ndarray[object,ndim=1] v17
        cdef Heap0 v18
        cdef US2 v19
        cdef US2 v20
        cdef US2 v21
        cdef US2 v22
        cdef US2 v23
        cdef US2 v24
        cdef numpy.ndarray[object,ndim=1] v25
        cdef unsigned long long v26
        cdef double v27
        cdef double v28
        v6 = US1_0()
        v7 = US1_2()
        v8 = numpy.empty(2,dtype=object)
        v8[0] = v6; v8[1] = v7
        del v6; del v7
        v9 = US1_1()
        v10 = US1_0()
        v11 = US1_2()
        v12 = numpy.empty(3,dtype=object)
        v12[0] = v9; v12[1] = v10; v12[2] = v11
        del v9; del v10; del v11
        v13 = US1_1()
        v14 = US1_0()
        v15 = numpy.empty(2,dtype=object)
        v15[0] = v13; v15[1] = v14
        del v13; del v14
        v16 = US1_0()
        v17 = numpy.empty(1,dtype=object)
        v17[0] = v16
        del v16
        v18 = Heap0(v17, v12, v8, v15)
        del v8; del v12; del v15; del v17
        v19 = US2_1()
        v20 = US2_2()
        v21 = US2_0()
        v22 = US2_1()
        v23 = US2_2()
        v24 = US2_0()
        v25 = numpy.empty(6,dtype=object)
        v25[0] = v19; v25[1] = v20; v25[2] = v21; v25[3] = v22; v25[4] = v23; v25[5] = v24
        del v19; del v20; del v21; del v22; del v23; del v24
        v26 = 0
        v27 = 0.000000
        v28 = method0(v25, v1, v0, v18, v2, v3, v4, v5, v26, v27)
        del v18; del v25
        return v0
cdef void method1(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US2 v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1 <= v4
        if v7:
            v8 = v6
        else:
            v8 = v4
        v9 = v2[v8]
        v3[v4] = v9
        del v9
        method1(v0, v1, v2, v3, v6)
    else:
        pass
cdef Tuple0 method2(US2 v0, double v1, unsigned char v2, UH0 v3, double v4):
    cdef bint v5
    cdef double v6
    cdef US0 v7
    cdef UH0 v8
    v5 = 0 == v2
    if v5:
        v6 = v1 + v4
        v7 = US0_1(v0)
        v8 = UH0_0(v7, v3)
        del v7
        return Tuple0(v8, v6)
    else:
        return Tuple0(v3, v4)
cdef Tuple0 method4(US2 v0, double v1, unsigned char v2, UH0 v3, double v4):
    cdef bint v5
    cdef double v6
    cdef US0 v7
    cdef UH0 v8
    v5 = 1 == v2
    if v5:
        v6 = v1 + v4
        v7 = US0_1(v0)
        v8 = UH0_0(v7, v3)
        del v7
        return Tuple0(v8, v6)
    else:
        return Tuple0(v3, v4)
cdef UH0 method6(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method6(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method8(UH1 v0, UH1 v1):
    cdef US1 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        del v2
        return method8(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method10(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method10(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method11(numpy.ndarray[object,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US1 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method11(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method9(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method10(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method11(v3, v0, v4)
    return v3
cdef UH2 method7(UH1 v0, US2 v1, UH0 v2):
    cdef US0 v3
    cdef UH0 v4
    cdef US1 v5
    cdef UH1 v6
    cdef US2 v8
    cdef UH1 v9
    cdef UH1 v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef UH1 v12
    cdef UH2 v13
    cdef UH1 v16
    cdef UH1 v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef UH2 v19
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US0_0>v3).v0
            v6 = UH1_0(v5, v0)
            del v5
            return method7(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US0_1>v3).v0
            v9 = UH1_1()
            v10 = method8(v0, v9)
            del v9
            v11 = method9(v10)
            del v10
            v12 = UH1_1()
            v13 = method7(v12, v8, v4)
            del v4; del v8; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method8(v0, v16)
        del v16
        v18 = method9(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method13(UH2 v0, unsigned long long v1):
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v4 = (<UH2_0>v0).v2
        v5 = v1 + 1
        return method13(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method14(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US2 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v3; del v4
        v6 = v2 + 1
        return method14(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method12(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method13(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method14(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method5(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US0 v3
    cdef UH0 v4
    cdef US2 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method6(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US0_1>v3).v0
            v8 = UH1_1()
            v9 = method7(v8, v7, v4)
            del v4; del v7; del v8
            return method12(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef signed long long method16(US1 v0):
    cdef signed long long v1
    if v0.tag == 0: # call
        v1 = 0
    elif v0.tag == 1: # fold
        v1 = 1
    elif v0.tag == 2: # raise
        v1 = 2
    return v1
cdef void method15(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        v7 = method16(v6)
        del v6
        v2[v3] = v7
        method15(v0, v1, v2, v5)
    else:
        pass
cdef void method17(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method17(v0, v1, v4)
    else:
        pass
cdef void method19(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US1 v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v3[v4]
        v8 = v4 * 3
        v9 = v2 + v8
        if v7.tag == 0: # call
            v1[v9] = 1.000000
        elif v7.tag == 1: # fold
            v10 = v9 + 1
            v1[v10] = 1.000000
        elif v7.tag == 2: # raise
            v11 = v9 + 2
            v1[v11] = 1.000000
        del v7
        method19(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method18(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US2 v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Tuple1 tmp4
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef unsigned long long v14
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        tmp4 = v2[v3]
        v6, v7 = tmp4.v0, tmp4.v1
        del tmp4
        v8 = v3 * 15
        if v6.tag == 0: # jack
            v1[v8] = 1.000000
        elif v6.tag == 1: # king
            v9 = v8 + 1
            v1[v9] = 1.000000
        elif v6.tag == 2: # queen
            v10 = v8 + 2
            v1[v10] = 1.000000
        del v6
        v11 = v8 + 3
        v12 = len(v7)
        v13 = 4 < v12
        if v13:
            raise Exception("The given array is too large.")
        else:
            pass
        v14 = 0
        method19(v12, v1, v11, v7, v14)
        del v7
        method18(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[object,ndim=1] method22(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = 0 < v6
    if v7:
        return v0.v2
    else:
        v9 = 0 == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[object,ndim=1] method28(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = 0 < v7
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
            v13 = 0 == v7
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
cdef bint method30(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple3 method31(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple3(v1, v0)
    else:
        return Tuple3(v0, v1)
cdef object method32(v0, list v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7):
    cdef bint v8
    cdef signed long v10
    cdef signed long v12
    cdef signed long v13
    cdef bint v14
    cdef signed long v16
    cdef signed long v17
    cdef US2 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US2 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef double v24
    v8 = v7 == 0
    if v8:
        v10 = v5
    else:
        v10 =  -v5
    if v8:
        v12 = v10
    else:
        v12 =  -v10
    v13 = v12 + v5
    v14 = v4 == 0
    if v14:
        v16 = v10
    else:
        v16 =  -v10
    v17 = v16 + v5
    if v8:
        v18, v19, v20, v21, v22, v23 = v6, v7, v13, v3, v4, v17
    else:
        v18, v19, v20, v21, v22, v23 = v3, v4, v17, v6, v7, v13
    v24 = <double>v10
    return Closure4(v0, v1, v21, v22, v23, v18, v19, v20, v2, v24)
cdef object method33(v0, list v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7):
    cdef bint v8
    cdef signed long v10
    cdef bint v11
    cdef signed long v13
    cdef signed long v14
    cdef signed long v16
    cdef signed long v17
    cdef US2 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US2 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef double v24
    v8 = v4 == 0
    if v8:
        v10 = v5
    else:
        v10 =  -v5
    v11 = v7 == 0
    if v11:
        v13 = v10
    else:
        v13 =  -v10
    v14 = v13 + v5
    if v8:
        v16 = v10
    else:
        v16 =  -v10
    v17 = v16 + v5
    if v11:
        v18, v19, v20, v21, v22, v23 = v6, v7, v14, v3, v4, v17
    else:
        v18, v19, v20, v21, v22, v23 = v3, v4, v17, v6, v7, v14
    v24 = <double>v10
    return Closure4(v0, v1, v21, v22, v23, v18, v19, v20, v2, v24)
cdef object method34(v0, list v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, signed long v8):
    cdef bint v9
    cdef signed long v11
    cdef signed long v13
    cdef signed long v14
    cdef bint v15
    cdef signed long v17
    cdef signed long v18
    cdef US2 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US2 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef double v25
    v9 = v7 == 0
    if v9:
        v11 = v8
    else:
        v11 =  -v8
    if v9:
        v13 = v11
    else:
        v13 =  -v11
    v14 = v13 + v5
    v15 = v4 == 0
    if v15:
        v17 = v11
    else:
        v17 =  -v11
    v18 = v17 + v5
    if v9:
        v19, v20, v21, v22, v23, v24 = v6, v7, v14, v3, v4, v18
    else:
        v19, v20, v21, v22, v23, v24 = v3, v4, v18, v6, v7, v14
    v25 = <double>v11
    return Closure4(v0, v1, v22, v23, v24, v19, v20, v21, v2, v25)
cdef object method35(v0, list v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, signed long v8):
    cdef bint v9
    cdef signed long v11
    cdef bint v12
    cdef signed long v14
    cdef signed long v15
    cdef signed long v17
    cdef signed long v18
    cdef US2 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US2 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef double v25
    v9 = v4 == 0
    if v9:
        v11 = v8
    else:
        v11 =  -v8
    v12 = v7 == 0
    if v12:
        v14 = v11
    else:
        v14 =  -v11
    v15 = v14 + v8
    if v9:
        v17 = v11
    else:
        v17 =  -v11
    v18 = v17 + v5
    if v12:
        v19, v20, v21, v22, v23, v24 = v6, v7, v15, v3, v4, v18
    else:
        v19, v20, v21, v22, v23, v24 = v3, v4, v18, v6, v7, v15
    v25 = <double>v11
    return Closure4(v0, v1, v22, v23, v24, v19, v20, v21, v2, v25)
cdef double method29(unsigned long long v0, v1, list v2, Heap0 v3, signed long v4, US2 v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, numpy.ndarray[float,ndim=1] v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef float v22
    cdef US1 v23
    cdef double v24
    cdef double v25
    cdef object v72
    cdef signed long v26
    cdef signed long v27
    cdef signed long v28
    cdef signed long v29
    cdef bint v30
    cdef bint v32
    cdef signed long v55
    cdef bint v33
    cdef bint v34
    cdef bint v37
    cdef bint v38
    cdef signed long v39
    cdef signed long v40
    cdef Tuple3 tmp5
    cdef signed long v41
    cdef signed long v42
    cdef Tuple3 tmp6
    cdef bint v43
    cdef signed long v46
    cdef bint v44
    cdef bint v47
    cdef bint v48
    cdef bint v49
    cdef bint v56
    cdef US3 v57
    cdef bint v59
    cdef US3 v60
    cdef US3 v62
    cdef signed long v63
    cdef US3 v67
    cdef signed long v69
    cdef signed long v70
    cdef double v73
    cdef US0 v74
    cdef UH0 v75
    cdef US0 v76
    cdef UH0 v77
    cdef double v78
    cdef double v79
    cdef double v80
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v16[v18]
        v23 = v17[v18]
        v24 = <double>v22
        v25 = libc.math.log(v24)
        if v23.tag == 0: # call
            if v9.tag == 0: # jack
                v26 = 0
            elif v9.tag == 1: # king
                v26 = 2
            elif v9.tag == 2: # queen
                v26 = 1
            if v5.tag == 0: # jack
                v27 = 0
            elif v5.tag == 1: # king
                v27 = 2
            elif v5.tag == 2: # queen
                v27 = 1
            if v6.tag == 0: # jack
                v28 = 0
            elif v6.tag == 1: # king
                v28 = 2
            elif v6.tag == 2: # queen
                v28 = 1
            if v5.tag == 0: # jack
                v29 = 0
            elif v5.tag == 1: # king
                v29 = 2
            elif v5.tag == 2: # queen
                v29 = 1
            v30 = method30(v27, v26)
            if v30:
                v32 = method30(v29, v28)
            else:
                v32 = 0
            if v32:
                v33 = v26 < v28
                if v33:
                    v55 = -1
                else:
                    v34 = v26 > v28
                    if v34:
                        v55 = 1
                    else:
                        v55 = 0
            else:
                v37 = method30(v27, v26)
                if v37:
                    v55 = 1
                else:
                    v38 = method30(v29, v28)
                    if v38:
                        v55 = -1
                    else:
                        tmp5 = method31(v27, v26)
                        v39, v40 = tmp5.v0, tmp5.v1
                        del tmp5
                        tmp6 = method31(v29, v28)
                        v41, v42 = tmp6.v0, tmp6.v1
                        del tmp6
                        v43 = v39 < v41
                        if v43:
                            v46 = -1
                        else:
                            v44 = v39 > v41
                            if v44:
                                v46 = 1
                            else:
                                v46 = 0
                        v47 = v46 == 0
                        if v47:
                            v48 = v40 < v42
                            if v48:
                                v55 = -1
                            else:
                                v49 = v40 > v42
                                if v49:
                                    v55 = 1
                                else:
                                    v55 = 0
                        else:
                            v55 = v46
            v56 = v55 == 1
            if v56:
                v57 = US3_1(v5)
                v72 = method32(v1, v2, v57, v6, v7, v8, v9, v10)
                del v57
            else:
                v59 = v55 == -1
                if v59:
                    v60 = US3_1(v5)
                    v72 = method33(v1, v2, v60, v6, v7, v8, v9, v10)
                    del v60
                else:
                    v62 = US3_1(v5)
                    v63 = 0
                    v72 = method34(v1, v2, v62, v6, v7, v8, v9, v10, v63)
                    del v62
        elif v23.tag == 1: # fold
            v67 = US3_1(v5)
            v72 = method35(v1, v2, v67, v6, v7, v8, v9, v10, v11)
            del v67
        elif v23.tag == 2: # raise
            v69 = v4 - 1
            v70 = v8 + 4
            v72 = method27(v1, v2, v3, v69, v5, v9, v10, v70, v6, v7, v8)
        v73 = v25 + v15
        v74 = US0_0(v23)
        v75 = UH0_0(v74, v14)
        del v74
        v76 = US0_0(v23)
        del v23
        v77 = UH0_0(v76, v12)
        del v76
        v78 = v72(Tuple2(v75, v73, v77, v13))
        del v72; del v75; del v77
        v79 = v24 * v78
        v80 = v19 + v79
        return method29(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v80)
    else:
        return v19
cdef void method36(list v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef str v8
    cdef US1 v4
    cdef US2 v6
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1
        method36(v0, v3)
        del v3
        if v2.tag == 0: # action_
            v4 = (<US0_0>v2).v0
            if v4.tag == 0: # call
                v8 = "C"
            elif v4.tag == 1: # fold
                v8 = "F"
            elif v4.tag == 2: # raise
                v8 = "R"
            del v4
        elif v2.tag == 1: # observation_
            v6 = (<US0_1>v2).v0
            if v6.tag == 0: # jack
                v8 = "[color=ff0000]J[/color]"
            elif v6.tag == 1: # king
                v8 = "[color=ff0000]K[/color]"
            elif v6.tag == 2: # queen
                v8 = "[color=ff0000]Q[/color]"
            del v6
        del v2
        v0.append(v8)
    elif v1.tag == 1: # nil
        pass
cdef void method37(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef str v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        if v6.tag == 0: # call
            v7 = "C"
        elif v6.tag == 1: # fold
            v7 = "F"
        elif v6.tag == 2: # raise
            v7 = "R"
        del v6
        v2.append(v7)
        del v7
        method37(v0, v1, v2, v5)
    else:
        pass
cdef double method38(unsigned long long v0, v1, list v2, Heap0 v3, signed long v4, US2 v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, double v16, double v17, numpy.ndarray[object,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US1 v23
    cdef object v70
    cdef signed long v24
    cdef signed long v25
    cdef signed long v26
    cdef signed long v27
    cdef bint v28
    cdef bint v30
    cdef signed long v53
    cdef bint v31
    cdef bint v32
    cdef bint v35
    cdef bint v36
    cdef signed long v37
    cdef signed long v38
    cdef Tuple3 tmp7
    cdef signed long v39
    cdef signed long v40
    cdef Tuple3 tmp8
    cdef bint v41
    cdef signed long v44
    cdef bint v42
    cdef bint v45
    cdef bint v46
    cdef bint v47
    cdef bint v54
    cdef US3 v55
    cdef bint v57
    cdef US3 v58
    cdef US3 v60
    cdef signed long v61
    cdef US3 v65
    cdef signed long v67
    cdef signed long v68
    cdef double v71
    cdef US0 v72
    cdef UH0 v73
    cdef US0 v74
    cdef UH0 v75
    cdef double v76
    cdef double v77
    cdef double v78
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1
        v23 = v18[v19]
        if v23.tag == 0: # call
            if v9.tag == 0: # jack
                v24 = 0
            elif v9.tag == 1: # king
                v24 = 2
            elif v9.tag == 2: # queen
                v24 = 1
            if v5.tag == 0: # jack
                v25 = 0
            elif v5.tag == 1: # king
                v25 = 2
            elif v5.tag == 2: # queen
                v25 = 1
            if v6.tag == 0: # jack
                v26 = 0
            elif v6.tag == 1: # king
                v26 = 2
            elif v6.tag == 2: # queen
                v26 = 1
            if v5.tag == 0: # jack
                v27 = 0
            elif v5.tag == 1: # king
                v27 = 2
            elif v5.tag == 2: # queen
                v27 = 1
            v28 = method30(v25, v24)
            if v28:
                v30 = method30(v27, v26)
            else:
                v30 = 0
            if v30:
                v31 = v24 < v26
                if v31:
                    v53 = -1
                else:
                    v32 = v24 > v26
                    if v32:
                        v53 = 1
                    else:
                        v53 = 0
            else:
                v35 = method30(v25, v24)
                if v35:
                    v53 = 1
                else:
                    v36 = method30(v27, v26)
                    if v36:
                        v53 = -1
                    else:
                        tmp7 = method31(v25, v24)
                        v37, v38 = tmp7.v0, tmp7.v1
                        del tmp7
                        tmp8 = method31(v27, v26)
                        v39, v40 = tmp8.v0, tmp8.v1
                        del tmp8
                        v41 = v37 < v39
                        if v41:
                            v44 = -1
                        else:
                            v42 = v37 > v39
                            if v42:
                                v44 = 1
                            else:
                                v44 = 0
                        v45 = v44 == 0
                        if v45:
                            v46 = v38 < v40
                            if v46:
                                v53 = -1
                            else:
                                v47 = v38 > v40
                                if v47:
                                    v53 = 1
                                else:
                                    v53 = 0
                        else:
                            v53 = v44
            v54 = v53 == 1
            if v54:
                v55 = US3_1(v5)
                v70 = method32(v1, v2, v55, v6, v7, v8, v9, v10)
                del v55
            else:
                v57 = v53 == -1
                if v57:
                    v58 = US3_1(v5)
                    v70 = method33(v1, v2, v58, v6, v7, v8, v9, v10)
                    del v58
                else:
                    v60 = US3_1(v5)
                    v61 = 0
                    v70 = method34(v1, v2, v60, v6, v7, v8, v9, v10, v61)
                    del v60
        elif v23.tag == 1: # fold
            v65 = US3_1(v5)
            v70 = method35(v1, v2, v65, v6, v7, v8, v9, v10, v11)
            del v65
        elif v23.tag == 2: # raise
            v67 = v4 - 1
            v68 = v8 + 4
            v70 = method27(v1, v2, v3, v67, v5, v9, v10, v68, v6, v7, v8)
        v71 = v17 + v13
        v72 = US0_0(v23)
        v73 = UH0_0(v72, v14)
        del v72
        v74 = US0_0(v23)
        del v23
        v75 = UH0_0(v74, v12)
        del v74
        v76 = v70(Tuple2(v73, v15, v75, v71))
        del v70; del v73; del v75
        v77 = v16 * v76
        v78 = v20 + v77
        return method38(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v78)
    else:
        return v20
cdef object method27(v0, list v1, Heap0 v2, signed long v3, US2 v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9, signed long v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method28(v2, v5, v6, v7, v8, v9, v10, v3)
    return Closure3(v0, v1, v8, v9, v10, v5, v6, v7, v4, v11, v2, v3)
cdef double method26(unsigned long long v0, v1, list v2, Heap0 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9, US2 v10, UH0 v11, double v12, UH0 v13, double v14, numpy.ndarray[float,ndim=1] v15, numpy.ndarray[object,ndim=1] v16, unsigned long long v17, double v18):
    cdef bint v19
    cdef unsigned long long v20
    cdef float v21
    cdef US1 v22
    cdef double v23
    cdef double v24
    cdef object v31
    cdef signed long v25
    cdef signed long v28
    cdef signed long v29
    cdef double v32
    cdef US0 v33
    cdef US0 v34
    cdef UH0 v35
    cdef UH0 v36
    cdef US0 v37
    cdef US0 v38
    cdef UH0 v39
    cdef UH0 v40
    cdef double v41
    cdef double v42
    cdef double v43
    v19 = v17 < v0
    if v19:
        v20 = v17 + 1
        v21 = v15[v17]
        v22 = v16[v17]
        v23 = <double>v21
        v24 = libc.math.log(v23)
        if v22.tag == 0: # call
            v25 = 2
            v31 = method27(v1, v2, v3, v25, v10, v7, v8, v9, v4, v5, v6)
        elif v22.tag == 1: # fold
            raise Exception("impossible")
        elif v22.tag == 2: # raise
            v28 = 1
            v29 = v6 + 4
            v31 = method27(v1, v2, v3, v28, v10, v7, v8, v29, v4, v5, v6)
        v32 = v24 + v14
        v33 = US0_0(v22)
        v34 = US0_1(v10)
        v35 = UH0_0(v34, v13)
        del v34
        v36 = UH0_0(v33, v35)
        del v33; del v35
        v37 = US0_0(v22)
        del v22
        v38 = US0_1(v10)
        v39 = UH0_0(v38, v11)
        del v38
        v40 = UH0_0(v37, v39)
        del v37; del v39
        v41 = v31(Tuple2(v36, v32, v40, v12))
        del v31; del v36; del v40
        v42 = v23 * v41
        v43 = v18 + v42
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v43)
    else:
        return v18
cdef double method39(unsigned long long v0, v1, list v2, Heap0 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9, US2 v10, UH0 v11, double v12, UH0 v13, double v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US1 v22
    cdef object v29
    cdef signed long v23
    cdef signed long v26
    cdef signed long v27
    cdef double v30
    cdef US0 v31
    cdef US0 v32
    cdef UH0 v33
    cdef UH0 v34
    cdef US0 v35
    cdef US0 v36
    cdef UH0 v37
    cdef UH0 v38
    cdef double v39
    cdef double v40
    cdef double v41
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        if v22.tag == 0: # call
            v23 = 2
            v29 = method27(v1, v2, v3, v23, v10, v7, v8, v9, v4, v5, v6)
        elif v22.tag == 1: # fold
            raise Exception("impossible")
        elif v22.tag == 2: # raise
            v26 = 1
            v27 = v6 + 4
            v29 = method27(v1, v2, v3, v26, v10, v7, v8, v27, v4, v5, v6)
        v30 = v16 + v12
        v31 = US0_0(v22)
        v32 = US0_1(v10)
        v33 = UH0_0(v32, v13)
        del v32
        v34 = UH0_0(v31, v33)
        del v31; del v33
        v35 = US0_0(v22)
        del v22
        v36 = US0_1(v10)
        v37 = UH0_0(v36, v11)
        del v36
        v38 = UH0_0(v35, v37)
        del v35; del v37
        v39 = v29(Tuple2(v34, v14, v38, v30))
        del v29; del v34; del v38
        v40 = v15 * v39
        v41 = v19 + v40
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v41)
    else:
        return v19
cdef double method25(numpy.ndarray[object,ndim=1] v0, v1, list v2, Heap0 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9, UH0 v10, double v11, UH0 v12, double v13, unsigned long long v14, double v15):
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef bint v19
    cdef US2 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef bint v27
    cdef double v72
    cdef US0 v28
    cdef UH0 v29
    cdef numpy.ndarray[object,ndim=1] v30
    cdef unsigned long long v31
    cdef numpy.ndarray[signed long long,ndim=1] v32
    cdef unsigned long long v33
    cdef numpy.ndarray[float,ndim=1] v34
    cdef unsigned long long v35
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef bint v38
    cdef unsigned long long v39
    cdef object v40
    cdef object v41
    cdef object v42
    cdef object v43
    cdef numpy.ndarray[float,ndim=1] v44
    cdef unsigned long long v45
    cdef bint v46
    cdef bint v47
    cdef unsigned long long v48
    cdef double v49
    cdef double v50
    cdef list v51
    cdef str v52
    cdef str v53
    cdef str v54
    cdef str v55
    cdef str v56
    cdef double v57
    cdef str v58
    cdef double v59
    cdef str v60
    cdef list v61
    cdef unsigned long long v62
    cdef str v63
    cdef object v64
    cdef unsigned long long v65
    cdef double v66
    cdef double v67
    cdef double v68
    cdef unsigned long long v69
    cdef double v70
    cdef unsigned long long v73
    cdef double v74
    v16 = len(v0)
    v17 = <double>v16
    v18 = 1.000000 / v17
    v19 = v14 < v16
    if v19:
        v20 = v0[v14]
        v21 = <double>v16
        v22 = 1.000000 / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v11
        v25 = v23 + v13
        v26 = v3.v2
        v27 = v8 == 0
        if v27:
            v28 = US0_1(v20)
            v29 = UH0_0(v28, v10)
            del v28
            v30 = method5(v29)
            del v29
            v31 = len(v26)
            v32 = numpy.empty(v31,dtype=numpy.int64)
            v33 = 0
            method15(v31, v26, v32, v33)
            v34 = numpy.empty(30,dtype=numpy.float32)
            v35 = len(v34)
            v36 = 0
            method17(v35, v34, v36)
            v37 = len(v30)
            v38 = 2 < v37
            if v38:
                raise Exception("The given array is too large.")
            else:
                pass
            v39 = 0
            method18(v37, v34, v30, v39)
            del v30
            pass # import torch
            v40 = torch.from_numpy(v34)
            del v34
            v41 = v1.forward(v40)
            del v40
            v42 = v41[v32]
            del v32; del v41
            pass # import torch.nn.functional
            v43 = torch.nn.functional.softmax(v42,-1)
            del v42
            v44 = v43.cpu().detach().numpy()
            del v43
            v45 = len(v44)
            v46 = v45 == v31
            v47 = v46 == 0
            if v47:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v48 = 0
            v49 = 0.000000
            v50 = method26(v45, v1, v2, v3, v4, v5, v6, v7, v8, v9, v20, v12, v25, v10, v24, v44, v26, v48, v49)
            del v44
            v51 = [None]*0
            method36(v51, v10)
            if v20.tag == 0: # jack
                v52 = "[color=ff0000]J[/color]"
            elif v20.tag == 1: # king
                v52 = "[color=ff0000]K[/color]"
            elif v20.tag == 2: # queen
                v52 = "[color=ff0000]Q[/color]"
            v51.append(v52)
            del v52
            v53 = "".join(v51)
            del v51
            if v4.tag == 0: # jack
                v54 = "[color=ff0000]J[/color]"
            elif v4.tag == 1: # king
                v54 = "[color=ff0000]K[/color]"
            elif v4.tag == 2: # queen
                v54 = "[color=ff0000]Q[/color]"
            v55 = f'{v53} (vs. {v54})'
            del v53; del v54
            v56 = '{:.5f}'.format(v50)
            v57 = libc.math.exp(v24)
            v58 = '{:.5f}'.format(v57)
            v59 = libc.math.exp(v25)
            v60 = '{:.5f}'.format(v59)
            v61 = [None]*0
            v62 = 0
            method37(v31, v26, v61, v62)
            v63 = "".join(v61)
            del v61
            v64 = {'trace': v55, 'reward': v56, 'prob_self': v58, 'prob_op': v60, 'actions': v63}
            del v55; del v56; del v58; del v60; del v63
            v2.append(v64)
            del v64
            v72 = v50
        else:
            v65 = len(v26)
            v66 = <double>v65
            v67 = 1.000000 / v66
            v68 = libc.math.log(v67)
            v69 = 0
            v70 = 0.000000
            v72 = method39(v65, v1, v2, v3, v4, v5, v6, v7, v8, v9, v20, v12, v25, v10, v24, v67, v68, v26, v69, v70)
        del v20; del v26
        v73 = v14 + 1
        v74 = v15 + v72
        return method25(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v73, v74)
    else:
        return v18 * v15
cdef object method24(v0, list v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9):
    return Closure2(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9)
cdef double method41(unsigned long long v0, v1, list v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, numpy.ndarray[float,ndim=1] v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef float v22
    cdef US1 v23
    cdef double v24
    cdef double v25
    cdef object v39
    cdef bint v26
    cdef US2 v27
    cdef unsigned char v28
    cdef signed long v29
    cdef US2 v30
    cdef unsigned char v31
    cdef signed long v32
    cdef US3 v34
    cdef signed long v36
    cdef signed long v37
    cdef double v40
    cdef US0 v41
    cdef UH0 v42
    cdef US0 v43
    cdef UH0 v44
    cdef double v45
    cdef double v46
    cdef double v47
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v16[v18]
        v23 = v17[v18]
        v24 = <double>v22
        v25 = libc.math.log(v24)
        if v23.tag == 0: # call
            v26 = v10 == 0
            if v26:
                v27, v28, v29, v30, v31, v32 = v9, v10, v8, v6, v7, v8
            else:
                v27, v28, v29, v30, v31, v32 = v6, v7, v8, v9, v10, v8
            v39 = method24(v1, v2, v3, v4, v30, v31, v32, v27, v28, v29)
            del v27; del v30
        elif v23.tag == 1: # fold
            v34 = US3_0()
            v39 = method35(v1, v2, v34, v6, v7, v8, v9, v10, v11)
            del v34
        elif v23.tag == 2: # raise
            v36 = v5 - 1
            v37 = v8 + 2
            v39 = method40(v1, v2, v3, v4, v36, v9, v10, v37, v6, v7, v8)
        v40 = v25 + v15
        v41 = US0_0(v23)
        v42 = UH0_0(v41, v14)
        del v41
        v43 = US0_0(v23)
        del v23
        v44 = UH0_0(v43, v12)
        del v43
        v45 = v39(Tuple2(v42, v40, v44, v13))
        del v39; del v42; del v44
        v46 = v24 * v45
        v47 = v19 + v46
        return method41(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v47)
    else:
        return v19
cdef double method42(unsigned long long v0, v1, list v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, double v16, double v17, numpy.ndarray[object,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US1 v23
    cdef object v37
    cdef bint v24
    cdef US2 v25
    cdef unsigned char v26
    cdef signed long v27
    cdef US2 v28
    cdef unsigned char v29
    cdef signed long v30
    cdef US3 v32
    cdef signed long v34
    cdef signed long v35
    cdef double v38
    cdef US0 v39
    cdef UH0 v40
    cdef US0 v41
    cdef UH0 v42
    cdef double v43
    cdef double v44
    cdef double v45
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1
        v23 = v18[v19]
        if v23.tag == 0: # call
            v24 = v10 == 0
            if v24:
                v25, v26, v27, v28, v29, v30 = v9, v10, v8, v6, v7, v8
            else:
                v25, v26, v27, v28, v29, v30 = v6, v7, v8, v9, v10, v8
            v37 = method24(v1, v2, v3, v4, v28, v29, v30, v25, v26, v27)
            del v25; del v28
        elif v23.tag == 1: # fold
            v32 = US3_0()
            v37 = method35(v1, v2, v32, v6, v7, v8, v9, v10, v11)
            del v32
        elif v23.tag == 2: # raise
            v34 = v5 - 1
            v35 = v8 + 2
            v37 = method40(v1, v2, v3, v4, v34, v9, v10, v35, v6, v7, v8)
        v38 = v17 + v13
        v39 = US0_0(v23)
        v40 = UH0_0(v39, v14)
        del v39
        v41 = US0_0(v23)
        del v23
        v42 = UH0_0(v41, v12)
        del v41
        v43 = v37(Tuple2(v40, v15, v42, v38))
        del v37; del v40; del v42
        v44 = v16 * v43
        v45 = v20 + v44
        return method42(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v45)
    else:
        return v20
cdef object method40(v0, list v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9, signed long v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method28(v2, v5, v6, v7, v8, v9, v10, v4)
    return Closure5(v0, v1, v8, v9, v10, v5, v6, v7, v11, v2, v3, v4)
cdef double method23(unsigned long long v0, v1, list v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, UH0 v11, double v12, UH0 v13, double v14, numpy.ndarray[float,ndim=1] v15, numpy.ndarray[object,ndim=1] v16, unsigned long long v17, double v18):
    cdef bint v19
    cdef unsigned long long v20
    cdef float v21
    cdef US1 v22
    cdef double v23
    cdef double v24
    cdef object v38
    cdef bint v25
    cdef US2 v26
    cdef unsigned char v27
    cdef signed long v28
    cdef US2 v29
    cdef unsigned char v30
    cdef signed long v31
    cdef US3 v33
    cdef signed long v35
    cdef signed long v36
    cdef double v39
    cdef US0 v40
    cdef UH0 v41
    cdef US0 v42
    cdef UH0 v43
    cdef double v44
    cdef double v45
    cdef double v46
    v19 = v17 < v0
    if v19:
        v20 = v17 + 1
        v21 = v15[v17]
        v22 = v16[v17]
        v23 = <double>v21
        v24 = libc.math.log(v23)
        if v22.tag == 0: # call
            v25 = v10 == 0
            if v25:
                v26, v27, v28, v29, v30, v31 = v9, v10, v8, v6, v7, v8
            else:
                v26, v27, v28, v29, v30, v31 = v6, v7, v8, v9, v10, v8
            v38 = method24(v1, v2, v3, v4, v29, v30, v31, v26, v27, v28)
            del v26; del v29
        elif v22.tag == 1: # fold
            v33 = US3_0()
            v38 = method33(v1, v2, v33, v6, v7, v8, v9, v10)
            del v33
        elif v22.tag == 2: # raise
            v35 = v5 - 1
            v36 = v8 + 2
            v38 = method40(v1, v2, v3, v4, v35, v9, v10, v36, v6, v7, v8)
        v39 = v24 + v14
        v40 = US0_0(v22)
        v41 = UH0_0(v40, v13)
        del v40
        v42 = US0_0(v22)
        del v22
        v43 = UH0_0(v42, v11)
        del v42
        v44 = v38(Tuple2(v41, v39, v43, v12))
        del v38; del v41; del v43
        v45 = v23 * v44
        v46 = v18 + v45
        return method23(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v20, v46)
    else:
        return v18
cdef double method43(unsigned long long v0, v1, list v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, UH0 v11, double v12, UH0 v13, double v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US1 v22
    cdef object v36
    cdef bint v23
    cdef US2 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef US2 v27
    cdef unsigned char v28
    cdef signed long v29
    cdef US3 v31
    cdef signed long v33
    cdef signed long v34
    cdef double v37
    cdef US0 v38
    cdef UH0 v39
    cdef US0 v40
    cdef UH0 v41
    cdef double v42
    cdef double v43
    cdef double v44
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        if v22.tag == 0: # call
            v23 = v10 == 0
            if v23:
                v24, v25, v26, v27, v28, v29 = v9, v10, v8, v6, v7, v8
            else:
                v24, v25, v26, v27, v28, v29 = v6, v7, v8, v9, v10, v8
            v36 = method24(v1, v2, v3, v4, v27, v28, v29, v24, v25, v26)
            del v24; del v27
        elif v22.tag == 1: # fold
            v31 = US3_0()
            v36 = method33(v1, v2, v31, v6, v7, v8, v9, v10)
            del v31
        elif v22.tag == 2: # raise
            v33 = v5 - 1
            v34 = v8 + 2
            v36 = method40(v1, v2, v3, v4, v33, v9, v10, v34, v6, v7, v8)
        v37 = v16 + v12
        v38 = US0_0(v22)
        v39 = UH0_0(v38, v13)
        del v38
        v40 = US0_0(v22)
        del v22
        v41 = UH0_0(v40, v11)
        del v40
        v42 = v36(Tuple2(v39, v14, v41, v37))
        del v36; del v39; del v41
        v43 = v15 * v42
        v44 = v19 + v43
        return method43(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v44)
    else:
        return v19
cdef object method21(v0, list v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method22(v2, v5, v6, v7, v8, v9, v4)
    return Closure1(v0, v1, v8, v9, v7, v5, v6, v10, v2, v3, v4)
cdef double method20(unsigned long long v0, v1, list v2, US2 v3, US2 v4, Heap0 v5, numpy.ndarray[object,ndim=1] v6, UH0 v7, double v8, UH0 v9, double v10, numpy.ndarray[float,ndim=1] v11, numpy.ndarray[object,ndim=1] v12, unsigned long long v13, double v14):
    cdef bint v15
    cdef unsigned long long v16
    cdef float v17
    cdef US1 v18
    cdef double v19
    cdef double v20
    cdef object v33
    cdef signed long v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned char v24
    cdef signed long v27
    cdef unsigned char v28
    cdef signed long v29
    cdef unsigned char v30
    cdef signed long v31
    cdef double v34
    cdef US0 v35
    cdef UH0 v36
    cdef US0 v37
    cdef UH0 v38
    cdef double v39
    cdef double v40
    cdef double v41
    v15 = v13 < v0
    if v15:
        v16 = v13 + 1
        v17 = v11[v13]
        v18 = v12[v13]
        v19 = <double>v17
        v20 = libc.math.log(v19)
        if v18.tag == 0: # call
            v21 = 2
            v22 = 1
            v23 = 1
            v24 = 0
            v33 = method21(v1, v2, v5, v6, v21, v3, v24, v23, v4, v22)
        elif v18.tag == 1: # fold
            raise Exception("impossible")
        elif v18.tag == 2: # raise
            v27 = 1
            v28 = 1
            v29 = 1
            v30 = 0
            v31 = 3
            v33 = method40(v1, v2, v5, v6, v27, v3, v30, v31, v4, v28, v29)
        v34 = v20 + v10
        v35 = US0_0(v18)
        v36 = UH0_0(v35, v9)
        del v35
        v37 = US0_0(v18)
        del v18
        v38 = UH0_0(v37, v7)
        del v37
        v39 = v33(Tuple2(v36, v34, v38, v8))
        del v33; del v36; del v38
        v40 = v19 * v39
        v41 = v14 + v40
        return method20(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v16, v41)
    else:
        return v14
cdef double method3(numpy.ndarray[object,ndim=1] v0, v1, list v2, Heap0 v3, US2 v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef US2 v15
    cdef unsigned long long v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef unsigned char v22
    cdef UH0 v23
    cdef double v24
    cdef Tuple0 tmp2
    cdef unsigned char v25
    cdef UH0 v26
    cdef double v27
    cdef Tuple0 tmp3
    cdef numpy.ndarray[object,ndim=1] v28
    cdef numpy.ndarray[object,ndim=1] v29
    cdef unsigned long long v30
    cdef numpy.ndarray[signed long long,ndim=1] v31
    cdef unsigned long long v32
    cdef numpy.ndarray[float,ndim=1] v33
    cdef unsigned long long v34
    cdef unsigned long long v35
    cdef unsigned long long v36
    cdef bint v37
    cdef unsigned long long v38
    cdef object v39
    cdef object v40
    cdef object v41
    cdef object v42
    cdef numpy.ndarray[float,ndim=1] v43
    cdef unsigned long long v44
    cdef bint v45
    cdef bint v46
    cdef unsigned long long v47
    cdef double v48
    cdef double v49
    cdef list v50
    cdef str v51
    cdef str v52
    cdef str v53
    cdef str v54
    cdef double v55
    cdef str v56
    cdef double v57
    cdef str v58
    cdef list v59
    cdef unsigned long long v60
    cdef str v61
    cdef object v62
    cdef unsigned long long v63
    cdef double v64
    v11 = len(v0)
    v12 = <double>v11
    v13 = 1.000000 / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - 1
        v17 = numpy.empty(v16,dtype=object)
        v18 = 0
        method1(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = 1.000000 / v19
        v21 = libc.math.log(v20)
        v22 = 0
        tmp2 = method4(v15, v21, v22, v5, v6)
        v23, v24 = tmp2.v0, tmp2.v1
        del tmp2
        v25 = 1
        tmp3 = method4(v15, v21, v25, v7, v8)
        v26, v27 = tmp3.v0, tmp3.v1
        del tmp3
        v28 = v3.v2
        v29 = method5(v23)
        v30 = len(v28)
        v31 = numpy.empty(v30,dtype=numpy.int64)
        v32 = 0
        method15(v30, v28, v31, v32)
        v33 = numpy.empty(30,dtype=numpy.float32)
        v34 = len(v33)
        v35 = 0
        method17(v34, v33, v35)
        v36 = len(v29)
        v37 = 2 < v36
        if v37:
            raise Exception("The given array is too large.")
        else:
            pass
        v38 = 0
        method18(v36, v33, v29, v38)
        del v29
        pass # import torch
        v39 = torch.from_numpy(v33)
        del v33
        v40 = v1.forward(v39)
        del v39
        v41 = v40[v31]
        del v31; del v40
        pass # import torch.nn.functional
        v42 = torch.nn.functional.softmax(v41,-1)
        del v41
        v43 = v42.cpu().detach().numpy()
        del v42
        v44 = len(v43)
        v45 = v44 == v30
        v46 = v45 == 0
        if v46:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v47 = 0
        v48 = 0.000000
        v49 = method20(v44, v1, v2, v4, v15, v3, v17, v26, v27, v23, v24, v43, v28, v47, v48)
        del v17; del v26; del v43
        v50 = [None]*0
        method36(v50, v23)
        del v23
        v51 = "".join(v50)
        del v50
        if v15.tag == 0: # jack
            v52 = "[color=ff0000]J[/color]"
        elif v15.tag == 1: # king
            v52 = "[color=ff0000]K[/color]"
        elif v15.tag == 2: # queen
            v52 = "[color=ff0000]Q[/color]"
        del v15
        v53 = f'{v51} (vs. {v52})'
        del v51; del v52
        v54 = '{:.5f}'.format(v49)
        v55 = libc.math.exp(v24)
        v56 = '{:.5f}'.format(v55)
        v57 = libc.math.exp(v27)
        v58 = '{:.5f}'.format(v57)
        v59 = [None]*0
        v60 = 0
        method37(v30, v28, v59, v60)
        del v28
        v61 = "".join(v59)
        del v59
        v62 = {'trace': v53, 'reward': v54, 'prob_self': v56, 'prob_op': v58, 'actions': v61}
        del v53; del v54; del v56; del v58; del v61
        v2.append(v62)
        del v62
        v63 = v9 + 1
        v64 = v10 + v49
        return method3(v0, v1, v2, v3, v4, v5, v6, v7, v8, v63, v64)
    else:
        return v13 * v10
cdef double method0(numpy.ndarray[object,ndim=1] v0, v1, list v2, Heap0 v3, UH0 v4, double v5, UH0 v6, double v7, unsigned long long v8, double v9):
    cdef unsigned long long v10
    cdef double v11
    cdef double v12
    cdef bint v13
    cdef US2 v14
    cdef unsigned long long v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef unsigned char v21
    cdef UH0 v22
    cdef double v23
    cdef Tuple0 tmp0
    cdef unsigned char v24
    cdef UH0 v25
    cdef double v26
    cdef Tuple0 tmp1
    cdef unsigned long long v27
    cdef double v28
    cdef double v29
    cdef unsigned long long v30
    cdef double v31
    v10 = len(v0)
    v11 = <double>v10
    v12 = 1.000000 / v11
    v13 = v8 < v10
    if v13:
        v14 = v0[v8]
        v15 = v10 - 1
        v16 = numpy.empty(v15,dtype=object)
        v17 = 0
        method1(v15, v8, v0, v16, v17)
        v18 = <double>v10
        v19 = 1.000000 / v18
        v20 = libc.math.log(v19)
        v21 = 0
        tmp0 = method2(v14, v20, v21, v4, v5)
        v22, v23 = tmp0.v0, tmp0.v1
        del tmp0
        v24 = 1
        tmp1 = method2(v14, v20, v24, v6, v7)
        v25, v26 = tmp1.v0, tmp1.v1
        del tmp1
        v27 = 0
        v28 = 0.000000
        v29 = method3(v16, v1, v2, v3, v14, v22, v23, v25, v26, v27, v28)
        del v14; del v16; del v22; del v25
        v30 = v8 + 1
        v31 = v9 + v29
        return method0(v0, v1, v2, v3, v4, v5, v6, v7, v30, v31)
    else:
        return v12 * v9
cpdef void main():
    cdef list v0
    cdef object v1
    cdef UH0 v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef object v6
    pass # import ui_replay
    v0 = [None]*0
    pass # import nets
    v1 = nets.small(30,64,3)
    v2 = UH0_1()
    v3 = 0.000000
    v4 = UH0_1()
    v5 = 0.000000
    v6 = Closure0(v0, v1, v2, v3, v4, v5)
    del v0; del v1; del v2; del v4
    ui_replay.run(v6)
