import ui_replay
import nets
import numpy
cimport numpy
import torch
import torch.nn.functional
cimport libc.math
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # jack
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # king
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # queen
    def __init__(self): self.tag = 2
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # call
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # fold
    def __init__(self): self.tag = 1
cdef class US3_2(US3): # raise
    def __init__(self): self.tag = 2
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
    cdef readonly object v9
    cdef readonly UH0 v10
    cdef readonly double v11
    cdef readonly double v12
    def __init__(self, v0, double v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US1 v8, v9, UH0 v10, double v11, double v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
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
        cdef numpy.ndarray[object,ndim=1] v2 = args.v0
        cdef double v3 = args.v1
        cdef US0 v4 = args.v2
        cdef unsigned char v5 = args.v3
        cdef signed long v6 = args.v4
        cdef US0 v7 = args.v5
        cdef unsigned char v8 = args.v6
        cdef signed long v9 = args.v7
        cdef US1 v10 = args.v8
        cdef object v11 = args.v9
        cdef UH0 v12 = args.v10
        cdef double v13 = args.v11
        cdef double v14 = args.v12
        cdef numpy.ndarray[object,ndim=1] v15
        cdef unsigned long long v16
        cdef numpy.ndarray[signed long long,ndim=1] v17
        cdef unsigned long long v18
        cdef numpy.ndarray[float,ndim=1] v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef bint v23
        cdef unsigned long long v24
        cdef object v25
        cdef object v26
        cdef object v27
        cdef object v28
        cdef numpy.ndarray[float,ndim=1] v29
        cdef unsigned long long v30
        cdef bint v31
        cdef bint v32
        cdef unsigned long long v33
        cdef double v34
        cdef double v35
        cdef list v36
        cdef str v37
        cdef str v38
        cdef str v39
        cdef bint v40
        cdef double v42
        cdef str v43
        cdef double v44
        cdef str v45
        cdef double v46
        cdef str v47
        cdef list v48
        cdef unsigned long long v49
        cdef str v50
        cdef object v51
        v15 = method0(v12)
        v16 = len(v2)
        v17 = numpy.empty(v16,dtype=numpy.int64)
        v18 = 0
        method10(v16, v2, v17, v18)
        v19 = numpy.empty(30,dtype=numpy.float32)
        v20 = len(v19)
        v21 = 0
        method12(v20, v19, v21)
        v22 = len(v15)
        v23 = 2 < v22
        if v23:
            raise Exception("The given array is too large.")
        else:
            pass
        v24 = 0
        method13(v22, v19, v15, v24)
        del v15
        pass # import torch
        v25 = torch.from_numpy(v19)
        del v19
        v26 = v0.forward(v25)
        del v25
        v27 = v26[v17]
        del v17; del v26
        pass # import torch.nn.functional
        v28 = torch.nn.functional.softmax(v27,-1)
        del v27
        v29 = v28.cpu().detach().numpy()
        del v28
        v30 = len(v29)
        v31 = v30 == v16
        v32 = v31 == 0
        if v32:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v33 = 0
        v34 = 0.000000
        v35 = method15(v30, v11, v29, v2, v33, v34)
        del v29
        v36 = [None]*0
        method16(v36, v12)
        if v7.tag == 0: # jack
            v37 = "[color=ff0000]J[/color]"
        elif v7.tag == 1: # king
            v37 = "[color=ff0000]K[/color]"
        elif v7.tag == 2: # queen
            v37 = "[color=ff0000]Q[/color]"
        v38 = f' (vs. {v37})'
        del v37
        v36.append(v38)
        del v38
        v39 = "".join(v36)
        del v36
        v40 = v5 == 0
        if v40:
            v42 = v35
        else:
            v42 =  -v35
        v43 = '{:.5f}'.format(v42)
        v44 = libc.math.exp(v13)
        v45 = '{:.5f}'.format(v44)
        v46 = libc.math.exp(v14)
        v47 = '{:.5f}'.format(v46)
        v48 = [None]*0
        v49 = 0
        method17(v16, v2, v48, v49)
        v50 = "".join(v48)
        del v48
        v51 = {'actions': v50, 'prob_op': v47, 'prob_self': v45, 'reward': v43, 'trace': v39}
        del v39; del v43; del v45; del v47; del v50
        v1.append(v51)
        del v51
        return v35
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple3:
    cdef readonly UH0 v0
    cdef readonly double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
cdef class Tuple4:
    cdef readonly double v0
    cdef readonly UH0 v1
    cdef readonly double v2
    cdef readonly UH0 v3
    cdef readonly double v4
    def __init__(self, double v0, UH0 v1, double v2, UH0 v3, double v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple5:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure9():
    cdef object v0
    cdef US0 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef double v8
    def __init__(self, v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US1 v7, double v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, Tuple4 args):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef double v8 = self.v8
        cdef double v9 = args.v0
        cdef UH0 v10 = args.v1
        cdef double v11 = args.v2
        cdef UH0 v12 = args.v3
        cdef double v13 = args.v4
        cdef double v14
        v14 =  -v8
        return v8
cdef class Closure8():
    cdef object v0
    cdef Heap0 v1
    cdef signed long v2
    cdef US0 v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef UH0 v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    def __init__(self, v0, Heap0 v1, signed long v2, US0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, UH0 v10, double v11, UH0 v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef signed long v2 = self.v2
        cdef US0 v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef object v63
        cdef signed long v17
        cdef signed long v18
        cdef signed long v19
        cdef signed long v20
        cdef bint v21
        cdef bint v23
        cdef signed long v46
        cdef bint v24
        cdef bint v25
        cdef bint v28
        cdef bint v29
        cdef signed long v30
        cdef signed long v31
        cdef Tuple5 tmp5
        cdef signed long v32
        cdef signed long v33
        cdef Tuple5 tmp6
        cdef bint v34
        cdef signed long v37
        cdef bint v35
        cdef bint v38
        cdef bint v39
        cdef bint v40
        cdef bint v47
        cdef US1 v48
        cdef bint v50
        cdef US1 v51
        cdef US1 v53
        cdef signed long v54
        cdef US1 v58
        cdef signed long v60
        cdef signed long v61
        cdef double v64
        cdef US2 v65
        cdef UH0 v66
        cdef US2 v67
        cdef UH0 v68
        if v16.tag == 0: # call
            if v7.tag == 0: # jack
                v17 = 0
            elif v7.tag == 1: # king
                v17 = 2
            elif v7.tag == 2: # queen
                v17 = 1
            if v3.tag == 0: # jack
                v18 = 0
            elif v3.tag == 1: # king
                v18 = 2
            elif v3.tag == 2: # queen
                v18 = 1
            if v4.tag == 0: # jack
                v19 = 0
            elif v4.tag == 1: # king
                v19 = 2
            elif v4.tag == 2: # queen
                v19 = 1
            if v3.tag == 0: # jack
                v20 = 0
            elif v3.tag == 1: # king
                v20 = 2
            elif v3.tag == 2: # queen
                v20 = 1
            v21 = method29(v18, v17)
            if v21:
                v23 = method29(v20, v19)
            else:
                v23 = 0
            if v23:
                v24 = v17 < v19
                if v24:
                    v46 = -1
                else:
                    v25 = v17 > v19
                    if v25:
                        v46 = 1
                    else:
                        v46 = 0
            else:
                v28 = method29(v18, v17)
                if v28:
                    v46 = 1
                else:
                    v29 = method29(v20, v19)
                    if v29:
                        v46 = -1
                    else:
                        tmp5 = method30(v18, v17)
                        v30, v31 = tmp5.v0, tmp5.v1
                        del tmp5
                        tmp6 = method30(v20, v19)
                        v32, v33 = tmp6.v0, tmp6.v1
                        del tmp6
                        v34 = v30 < v32
                        if v34:
                            v37 = -1
                        else:
                            v35 = v30 > v32
                            if v35:
                                v37 = 1
                            else:
                                v37 = 0
                        v38 = v37 == 0
                        if v38:
                            v39 = v31 < v33
                            if v39:
                                v46 = -1
                            else:
                                v40 = v31 > v33
                                if v40:
                                    v46 = 1
                                else:
                                    v46 = 0
                        else:
                            v46 = v37
            v47 = v46 == 1
            if v47:
                v48 = US1_1(v3)
                v63 = method31(v0, v48, v4, v5, v6, v7, v8)
                del v48
            else:
                v50 = v46 == -1
                if v50:
                    v51 = US1_1(v3)
                    v63 = method32(v0, v51, v4, v5, v6, v7, v8)
                    del v51
                else:
                    v53 = US1_1(v3)
                    v54 = 0
                    v63 = method33(v0, v53, v4, v5, v6, v7, v8, v54)
                    del v53
        elif v16.tag == 1: # fold
            v58 = US1_1(v3)
            v63 = method34(v0, v58, v4, v5, v6, v7, v8, v9)
            del v58
        elif v16.tag == 2: # raise
            v60 = v2 - 1
            v61 = v6 + 4
            v63 = method27(v0, v1, v60, v3, v7, v8, v61, v4, v5, v6)
        v64 = v15 + v13
        v65 = US2_0(v16)
        v66 = UH0_0(v65, v12)
        del v65
        v67 = US2_0(v16)
        v68 = UH0_0(v67, v10)
        del v67
        return v63(Tuple4(v14, v66, v64, v68, v11))
cdef class Closure7():
    cdef object v0
    cdef US0 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef object v8
    cdef Heap0 v9
    cdef signed long v10
    def __init__(self, v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple4 args):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef signed long v10 = self.v10
        cdef double v11 = args.v0
        cdef UH0 v12 = args.v1
        cdef double v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef bint v16
        cdef US1 v17
        cdef object v18
        cdef unsigned long long v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef unsigned long long v24
        cdef double v25
        v16 = v2 == 0
        if v16:
            v17 = US1_1(v7)
            v18 = Closure8(v0, v9, v10, v7, v4, v5, v6, v1, v2, v3, v14, v15, v12, v13, v11)
            return v0(Tuple0(v8, v11, v1, v2, v3, v4, v5, v6, v17, v18, v12, v13, v15))
        else:
            v20 = len(v8)
            v21 = <double>v20
            v22 = 1.000000 / v21
            v23 = libc.math.log(v22)
            v24 = 0
            v25 = 0.000000
            return method35(v20, v0, v9, v10, v7, v4, v5, v6, v1, v2, v3, v14, v15, v12, v13, v11, v22, v23, v8, v24, v25)
cdef class Closure6():
    cdef object v0
    cdef Heap0 v1
    cdef US0 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef UH0 v9
    cdef double v10
    cdef UH0 v11
    cdef double v12
    cdef double v13
    def __init__(self, v0, Heap0 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, UH0 v9, double v10, UH0 v11, double v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef US0 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = args.v0
        cdef US3 v15 = args.v1
        cdef object v22
        cdef signed long v16
        cdef signed long v19
        cdef signed long v20
        cdef double v23
        cdef US2 v24
        cdef US2 v25
        cdef UH0 v26
        cdef UH0 v27
        cdef US2 v28
        cdef US2 v29
        cdef UH0 v30
        cdef UH0 v31
        if v15.tag == 0: # call
            v16 = 2
            v22 = method27(v0, v1, v16, v8, v5, v6, v7, v2, v3, v4)
        elif v15.tag == 1: # fold
            raise Exception("impossible")
        elif v15.tag == 2: # raise
            v19 = 1
            v20 = v4 + 4
            v22 = method27(v0, v1, v19, v8, v5, v6, v20, v2, v3, v4)
        v23 = v14 + v12
        v24 = US2_0(v15)
        v25 = US2_1(v8)
        v26 = UH0_0(v25, v11)
        del v25
        v27 = UH0_0(v24, v26)
        del v24; del v26
        v28 = US2_0(v15)
        v29 = US2_1(v8)
        v30 = UH0_0(v29, v9)
        del v29
        v31 = UH0_0(v28, v30)
        del v28; del v30
        return v22(Tuple4(v13, v27, v23, v31, v10))
cdef class Closure5():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    def __init__(self, numpy.ndarray[object,ndim=1] v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, Tuple4 args):
        cdef numpy.ndarray[object,ndim=1] v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef double v9 = args.v0
        cdef UH0 v10 = args.v1
        cdef double v11 = args.v2
        cdef UH0 v12 = args.v3
        cdef double v13 = args.v4
        cdef unsigned long long v14
        cdef double v15
        v14 = 0
        v15 = 0.000000
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15)
cdef class Closure11():
    cdef object v0
    cdef Heap0 v1
    cdef object v2
    cdef signed long v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef UH0 v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    def __init__(self, v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, UH0 v10, double v11, UH0 v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef object v30
        cdef bint v17
        cdef US0 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US0 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US1 v25
        cdef signed long v27
        cdef signed long v28
        cdef double v31
        cdef US2 v32
        cdef UH0 v33
        cdef US2 v34
        cdef UH0 v35
        if v16.tag == 0: # call
            v17 = v8 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v7, v8, v6, v4, v5, v6
            else:
                v18, v19, v20, v21, v22, v23 = v4, v5, v6, v7, v8, v6
            v30 = method25(v0, v1, v2, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = US1_0()
            v30 = method34(v0, v25, v4, v5, v6, v7, v8, v9)
            del v25
        elif v16.tag == 2: # raise
            v27 = v3 - 1
            v28 = v6 + 2
            v30 = method37(v0, v1, v2, v27, v7, v8, v28, v4, v5, v6)
        v31 = v15 + v13
        v32 = US2_0(v16)
        v33 = UH0_0(v32, v12)
        del v32
        v34 = US2_0(v16)
        v35 = UH0_0(v34, v10)
        del v34
        return v30(Tuple4(v14, v33, v31, v35, v11))
cdef class Closure10():
    cdef object v0
    cdef US0 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    def __init__(self, v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, numpy.ndarray[object,ndim=1] v7, Heap0 v8, numpy.ndarray[object,ndim=1] v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple4 args):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef double v11 = args.v0
        cdef UH0 v12 = args.v1
        cdef double v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef bint v16
        cdef US1 v17
        cdef object v18
        cdef unsigned long long v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef unsigned long long v24
        cdef double v25
        v16 = v2 == 0
        if v16:
            v17 = US1_0()
            v18 = Closure11(v0, v8, v9, v10, v4, v5, v6, v1, v2, v3, v14, v15, v12, v13, v11)
            return v0(Tuple0(v7, v11, v1, v2, v3, v4, v5, v6, v17, v18, v12, v13, v15))
        else:
            v20 = len(v7)
            v21 = <double>v20
            v22 = 1.000000 / v21
            v23 = libc.math.log(v22)
            v24 = 0
            v25 = 0.000000
            return method38(v20, v0, v8, v9, v10, v4, v5, v6, v1, v2, v3, v14, v15, v12, v13, v11, v22, v23, v7, v24, v25)
cdef class Closure4():
    cdef object v0
    cdef Heap0 v1
    cdef object v2
    cdef signed long v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef UH0 v9
    cdef double v10
    cdef UH0 v11
    cdef double v12
    cdef double v13
    def __init__(self, v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, UH0 v9, double v10, UH0 v11, double v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = args.v0
        cdef US3 v15 = args.v1
        cdef object v29
        cdef bint v16
        cdef US0 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef US0 v20
        cdef unsigned char v21
        cdef signed long v22
        cdef US1 v24
        cdef signed long v26
        cdef signed long v27
        cdef double v30
        cdef US2 v31
        cdef UH0 v32
        cdef US2 v33
        cdef UH0 v34
        if v15.tag == 0: # call
            v16 = v8 == 0
            if v16:
                v17, v18, v19, v20, v21, v22 = v7, v8, v6, v4, v5, v6
            else:
                v17, v18, v19, v20, v21, v22 = v4, v5, v6, v7, v8, v6
            v29 = method25(v0, v1, v2, v20, v21, v22, v17, v18, v19)
            del v17; del v20
        elif v15.tag == 1: # fold
            v24 = US1_0()
            v29 = method32(v0, v24, v4, v5, v6, v7, v8)
            del v24
        elif v15.tag == 2: # raise
            v26 = v3 - 1
            v27 = v6 + 2
            v29 = method37(v0, v1, v2, v26, v7, v8, v27, v4, v5, v6)
        v30 = v14 + v12
        v31 = US2_0(v15)
        v32 = UH0_0(v31, v11)
        del v31
        v33 = US2_0(v15)
        v34 = UH0_0(v33, v9)
        del v33
        return v29(Tuple4(v13, v32, v30, v34, v10))
cdef class Closure3():
    cdef object v0
    cdef US0 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US0 v4
    cdef unsigned char v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef signed long v9
    def __init__(self, v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, numpy.ndarray[object,ndim=1] v6, Heap0 v7, numpy.ndarray[object,ndim=1] v8, signed long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple4 args):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef signed long v9 = self.v9
        cdef double v10 = args.v0
        cdef UH0 v11 = args.v1
        cdef double v12 = args.v2
        cdef UH0 v13 = args.v3
        cdef double v14 = args.v4
        cdef bint v15
        cdef US1 v16
        cdef object v17
        cdef unsigned long long v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef unsigned long long v23
        cdef double v24
        v15 = v2 == 0
        if v15:
            v16 = US1_0()
            v17 = Closure4(v0, v7, v8, v9, v4, v5, v3, v1, v2, v13, v14, v11, v12, v10)
            return v0(Tuple0(v6, v10, v1, v2, v3, v4, v5, v3, v16, v17, v11, v12, v14))
        else:
            v19 = len(v6)
            v20 = <double>v19
            v21 = 1.000000 / v20
            v22 = libc.math.log(v21)
            v23 = 0
            v24 = 0.000000
            return method39(v19, v0, v7, v8, v9, v4, v5, v3, v1, v2, v13, v14, v11, v12, v10, v21, v22, v6, v23, v24)
cdef class Closure2():
    cdef object v0
    cdef US0 v1
    cdef US0 v2
    cdef Heap0 v3
    cdef object v4
    cdef UH0 v5
    cdef double v6
    cdef UH0 v7
    cdef double v8
    cdef double v9
    def __init__(self, v0, US0 v1, US0 v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, UH0 v5, double v6, UH0 v7, double v8, double v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef US0 v1 = self.v1
        cdef US0 v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef UH0 v5 = self.v5
        cdef double v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef double v8 = self.v8
        cdef double v9 = self.v9
        cdef double v10 = args.v0
        cdef US3 v11 = args.v1
        cdef object v24
        cdef signed long v12
        cdef unsigned char v13
        cdef signed long v14
        cdef unsigned char v15
        cdef signed long v18
        cdef unsigned char v19
        cdef signed long v20
        cdef unsigned char v21
        cdef signed long v22
        cdef double v25
        cdef US2 v26
        cdef UH0 v27
        cdef US2 v28
        cdef UH0 v29
        if v11.tag == 0: # call
            v12 = 2
            v13 = 1
            v14 = 1
            v15 = 0
            v24 = method23(v0, v3, v4, v12, v1, v15, v14, v2, v13)
        elif v11.tag == 1: # fold
            raise Exception("impossible")
        elif v11.tag == 2: # raise
            v18 = 1
            v19 = 1
            v20 = 1
            v21 = 0
            v22 = 3
            v24 = method37(v0, v3, v4, v18, v1, v21, v22, v2, v19, v20)
        v25 = v10 + v8
        v26 = US2_0(v11)
        v27 = UH0_0(v26, v7)
        del v26
        v28 = US2_0(v11)
        v29 = UH0_0(v28, v5)
        del v28
        return v24(Tuple4(v9, v27, v25, v29, v6))
cdef class Closure1():
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
        cdef US3 v6
        cdef US3 v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef US3 v9
        cdef US3 v10
        cdef US3 v11
        cdef numpy.ndarray[object,ndim=1] v12
        cdef US3 v13
        cdef US3 v14
        cdef numpy.ndarray[object,ndim=1] v15
        cdef US3 v16
        cdef numpy.ndarray[object,ndim=1] v17
        cdef Heap0 v18
        cdef US0 v19
        cdef US0 v20
        cdef US0 v21
        cdef US0 v22
        cdef US0 v23
        cdef US0 v24
        cdef numpy.ndarray[object,ndim=1] v25
        cdef unsigned long long v26
        cdef double v27
        cdef double v28
        v6 = US3_0()
        v7 = US3_2()
        v8 = numpy.empty(2,dtype=object)
        v8[0] = v6; v8[1] = v7
        del v6; del v7
        v9 = US3_1()
        v10 = US3_0()
        v11 = US3_2()
        v12 = numpy.empty(3,dtype=object)
        v12[0] = v9; v12[1] = v10; v12[2] = v11
        del v9; del v10; del v11
        v13 = US3_1()
        v14 = US3_0()
        v15 = numpy.empty(2,dtype=object)
        v15[0] = v13; v15[1] = v14
        del v13; del v14
        v16 = US3_0()
        v17 = numpy.empty(1,dtype=object)
        v17[0] = v16
        del v16
        v18 = Heap0(v17, v12, v8, v15)
        del v8; del v12; del v15; del v17
        v19 = US0_1()
        v20 = US0_2()
        v21 = US0_0()
        v22 = US0_1()
        v23 = US0_2()
        v24 = US0_0()
        v25 = numpy.empty(6,dtype=object)
        v25[0] = v19; v25[1] = v20; v25[2] = v21; v25[3] = v22; v25[4] = v23; v25[5] = v24
        del v19; del v20; del v21; del v22; del v23; del v24
        v26 = 0
        v27 = 0.000000
        v28 = method18(v25, v1, v18, v2, v3, v4, v5, v26, v27)
        del v18; del v25
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
        del v2
        return method3(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method5(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method5(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method6(numpy.ndarray[object,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US3 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method6(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method4(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method5(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
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
            v5 = (<US2_0>v3).v0
            v6 = UH1_0(v5, v0)
            del v5
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
            del v4; del v8; del v12
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
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v4 = (<UH2_0>v0).v2
        v5 = v1 + 1
        return method8(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US0 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v3; del v4
        v6 = v2 + 1
        return method9(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method7(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method8(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method9(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method0(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method1(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US2_1>v3).v0
            v8 = UH1_1()
            v9 = method2(v8, v7, v4)
            del v4; del v7; del v8
            return method7(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef signed long long method11(US3 v0):
    cdef signed long long v1
    if v0.tag == 0: # call
        v1 = 0
    elif v0.tag == 1: # fold
        v1 = 1
    elif v0.tag == 2: # raise
        v1 = 2
    return v1
cdef void method10(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US3 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        v7 = method11(v6)
        del v6
        v2[v3] = v7
        method10(v0, v1, v2, v5)
    else:
        pass
cdef void method12(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method12(v0, v1, v4)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
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
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method13(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US0 v6
    cdef numpy.ndarray[object,ndim=1] v7
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
        v5 = v3 + 1
        tmp0 = v2[v3]
        v6, v7 = tmp0.v0, tmp0.v1
        del tmp0
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
        method14(v12, v1, v11, v7, v14)
        del v7
        method13(v0, v1, v2, v5)
    else:
        pass
cdef double method15(unsigned long long v0, v1, numpy.ndarray[float,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4, double v5):
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
        v7 = v4 + 1
        v8 = v2[v4]
        v9 = v3[v4]
        v10 = <double>v8
        v11 = libc.math.log(v10)
        v12 = v1(Tuple2(v11, v9))
        del v9
        v13 = v10 * v12
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
            if v4.tag == 0: # call
                v8 = "C"
            elif v4.tag == 1: # fold
                v8 = "F"
            elif v4.tag == 2: # raise
                v8 = "R"
            del v4
        elif v2.tag == 1: # observation_
            v6 = (<US2_1>v2).v0
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
cdef void method17(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US3 v6
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
        method17(v0, v1, v2, v5)
    else:
        pass
cdef void method19(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US0 v9
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
        method19(v0, v1, v2, v3, v6)
    else:
        pass
cdef Tuple3 method20(US0 v0, unsigned char v1, UH0 v2, double v3):
    cdef bint v4
    cdef US2 v5
    cdef UH0 v6
    v4 = 0 == v1
    if v4:
        v5 = US2_1(v0)
        v6 = UH0_0(v5, v2)
        del v5
        return Tuple3(v6, v3)
    else:
        return Tuple3(v2, v3)
cdef Tuple3 method22(US0 v0, unsigned char v1, UH0 v2, double v3):
    cdef bint v4
    cdef US2 v5
    cdef UH0 v6
    v4 = 1 == v1
    if v4:
        v5 = US2_1(v0)
        v6 = UH0_0(v5, v2)
        del v5
        return Tuple3(v6, v3)
    else:
        return Tuple3(v2, v3)
cdef numpy.ndarray[object,ndim=1] method24(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[object,ndim=1] method28(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef bint method29(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple5 method30(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple5(v1, v0)
    else:
        return Tuple5(v0, v1)
cdef object method31(v0, US1 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6):
    cdef bint v7
    cdef signed long v9
    cdef signed long v11
    cdef signed long v12
    cdef bint v13
    cdef signed long v15
    cdef signed long v16
    cdef US0 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US0 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef double v23
    v7 = v6 == 0
    if v7:
        v9 = v4
    else:
        v9 =  -v4
    if v7:
        v11 = v9
    else:
        v11 =  -v9
    v12 = v11 + v4
    v13 = v3 == 0
    if v13:
        v15 = v9
    else:
        v15 =  -v9
    v16 = v15 + v4
    if v7:
        v17, v18, v19, v20, v21, v22 = v5, v6, v12, v2, v3, v16
    else:
        v17, v18, v19, v20, v21, v22 = v2, v3, v16, v5, v6, v12
    v23 = <double>v9
    return Closure9(v0, v20, v21, v22, v17, v18, v19, v1, v23)
cdef object method32(v0, US1 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6):
    cdef bint v7
    cdef signed long v9
    cdef bint v10
    cdef signed long v12
    cdef signed long v13
    cdef signed long v15
    cdef signed long v16
    cdef US0 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US0 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef double v23
    v7 = v3 == 0
    if v7:
        v9 = v4
    else:
        v9 =  -v4
    v10 = v6 == 0
    if v10:
        v12 = v9
    else:
        v12 =  -v9
    v13 = v12 + v4
    if v7:
        v15 = v9
    else:
        v15 =  -v9
    v16 = v15 + v4
    if v10:
        v17, v18, v19, v20, v21, v22 = v5, v6, v13, v2, v3, v16
    else:
        v17, v18, v19, v20, v21, v22 = v2, v3, v16, v5, v6, v13
    v23 = <double>v9
    return Closure9(v0, v20, v21, v22, v17, v18, v19, v1, v23)
cdef object method33(v0, US1 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7):
    cdef bint v8
    cdef signed long v10
    cdef signed long v12
    cdef signed long v13
    cdef bint v14
    cdef signed long v16
    cdef signed long v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef double v24
    v8 = v6 == 0
    if v8:
        v10 = v7
    else:
        v10 =  -v7
    if v8:
        v12 = v10
    else:
        v12 =  -v10
    v13 = v12 + v4
    v14 = v3 == 0
    if v14:
        v16 = v10
    else:
        v16 =  -v10
    v17 = v16 + v4
    if v8:
        v18, v19, v20, v21, v22, v23 = v5, v6, v13, v2, v3, v17
    else:
        v18, v19, v20, v21, v22, v23 = v2, v3, v17, v5, v6, v13
    v24 = <double>v10
    return Closure9(v0, v21, v22, v23, v18, v19, v20, v1, v24)
cdef object method34(v0, US1 v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7):
    cdef bint v8
    cdef signed long v10
    cdef bint v11
    cdef signed long v13
    cdef signed long v14
    cdef signed long v16
    cdef signed long v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef double v24
    v8 = v3 == 0
    if v8:
        v10 = v7
    else:
        v10 =  -v7
    v11 = v6 == 0
    if v11:
        v13 = v10
    else:
        v13 =  -v10
    v14 = v13 + v7
    if v8:
        v16 = v10
    else:
        v16 =  -v10
    v17 = v16 + v4
    if v11:
        v18, v19, v20, v21, v22, v23 = v5, v6, v14, v2, v3, v17
    else:
        v18, v19, v20, v21, v22, v23 = v2, v3, v17, v5, v6, v14
    v24 = <double>v10
    return Closure9(v0, v21, v22, v23, v18, v19, v20, v1, v24)
cdef double method35(unsigned long long v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, UH0 v11, double v12, UH0 v13, double v14, double v15, double v16, double v17, numpy.ndarray[object,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US3 v23
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
    cdef Tuple5 tmp7
    cdef signed long v39
    cdef signed long v40
    cdef Tuple5 tmp8
    cdef bint v41
    cdef signed long v44
    cdef bint v42
    cdef bint v45
    cdef bint v46
    cdef bint v47
    cdef bint v54
    cdef US1 v55
    cdef bint v57
    cdef US1 v58
    cdef US1 v60
    cdef signed long v61
    cdef US1 v65
    cdef signed long v67
    cdef signed long v68
    cdef double v71
    cdef US2 v72
    cdef UH0 v73
    cdef US2 v74
    cdef UH0 v75
    cdef double v76
    cdef double v77
    cdef double v78
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1
        v23 = v18[v19]
        if v23.tag == 0: # call
            if v8.tag == 0: # jack
                v24 = 0
            elif v8.tag == 1: # king
                v24 = 2
            elif v8.tag == 2: # queen
                v24 = 1
            if v4.tag == 0: # jack
                v25 = 0
            elif v4.tag == 1: # king
                v25 = 2
            elif v4.tag == 2: # queen
                v25 = 1
            if v5.tag == 0: # jack
                v26 = 0
            elif v5.tag == 1: # king
                v26 = 2
            elif v5.tag == 2: # queen
                v26 = 1
            if v4.tag == 0: # jack
                v27 = 0
            elif v4.tag == 1: # king
                v27 = 2
            elif v4.tag == 2: # queen
                v27 = 1
            v28 = method29(v25, v24)
            if v28:
                v30 = method29(v27, v26)
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
                v35 = method29(v25, v24)
                if v35:
                    v53 = 1
                else:
                    v36 = method29(v27, v26)
                    if v36:
                        v53 = -1
                    else:
                        tmp7 = method30(v25, v24)
                        v37, v38 = tmp7.v0, tmp7.v1
                        del tmp7
                        tmp8 = method30(v27, v26)
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
                v55 = US1_1(v4)
                v70 = method31(v1, v55, v5, v6, v7, v8, v9)
                del v55
            else:
                v57 = v53 == -1
                if v57:
                    v58 = US1_1(v4)
                    v70 = method32(v1, v58, v5, v6, v7, v8, v9)
                    del v58
                else:
                    v60 = US1_1(v4)
                    v61 = 0
                    v70 = method33(v1, v60, v5, v6, v7, v8, v9, v61)
                    del v60
        elif v23.tag == 1: # fold
            v65 = US1_1(v4)
            v70 = method34(v1, v65, v5, v6, v7, v8, v9, v10)
            del v65
        elif v23.tag == 2: # raise
            v67 = v3 - 1
            v68 = v7 + 4
            v70 = method27(v1, v2, v67, v4, v8, v9, v68, v5, v6, v7)
        v71 = v17 + v12
        v72 = US2_0(v23)
        v73 = UH0_0(v72, v13)
        del v72
        v74 = US2_0(v23)
        del v23
        v75 = UH0_0(v74, v11)
        del v74
        v76 = v70(Tuple4(v15, v73, v14, v75, v71))
        del v70; del v73; del v75
        v77 = v16 * v76
        v78 = v20 + v77
        return method35(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v78)
    else:
        return v20
cdef object method27(v0, Heap0 v1, signed long v2, US0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method28(v1, v4, v5, v6, v7, v8, v9, v2)
    return Closure7(v0, v7, v8, v9, v4, v5, v6, v3, v10, v1, v2)
cdef double method36(unsigned long long v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, UH0 v10, double v11, UH0 v12, double v13, double v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US3 v22
    cdef object v29
    cdef signed long v23
    cdef signed long v26
    cdef signed long v27
    cdef double v30
    cdef US2 v31
    cdef US2 v32
    cdef UH0 v33
    cdef UH0 v34
    cdef US2 v35
    cdef US2 v36
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
            v29 = method27(v1, v2, v23, v9, v6, v7, v8, v3, v4, v5)
        elif v22.tag == 1: # fold
            raise Exception("impossible")
        elif v22.tag == 2: # raise
            v26 = 1
            v27 = v5 + 4
            v29 = method27(v1, v2, v26, v9, v6, v7, v27, v3, v4, v5)
        v30 = v16 + v11
        v31 = US2_0(v22)
        v32 = US2_1(v9)
        v33 = UH0_0(v32, v12)
        del v32
        v34 = UH0_0(v31, v33)
        del v31; del v33
        v35 = US2_0(v22)
        del v22
        v36 = US2_1(v9)
        v37 = UH0_0(v36, v10)
        del v36
        v38 = UH0_0(v35, v37)
        del v35; del v37
        v39 = v29(Tuple4(v14, v34, v13, v38, v30))
        del v29; del v34; del v38
        v40 = v15 * v39
        v41 = v19 + v40
        return method36(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v41)
    else:
        return v19
cdef double method26(numpy.ndarray[object,ndim=1] v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, double v9, UH0 v10, double v11, UH0 v12, double v13, unsigned long long v14, double v15):
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef bint v19
    cdef US0 v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef bint v26
    cdef double v39
    cdef US1 v27
    cdef object v28
    cdef US2 v29
    cdef UH0 v30
    cdef unsigned long long v32
    cdef double v33
    cdef double v34
    cdef double v35
    cdef unsigned long long v36
    cdef double v37
    cdef unsigned long long v40
    cdef double v41
    v16 = len(v0)
    v17 = <double>v16
    v18 = 1.000000 / v17
    v19 = v14 < v16
    if v19:
        v20 = v0[v14]
        v21 = <double>v16
        v22 = 1.000000 / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v9
        v25 = v2.v2
        v26 = v7 == 0
        if v26:
            v27 = US1_1(v20)
            v28 = Closure6(v1, v2, v3, v4, v5, v6, v7, v8, v20, v12, v13, v10, v11, v24)
            v29 = US2_1(v20)
            v30 = UH0_0(v29, v10)
            del v29
            v39 = v1(Tuple0(v25, v24, v6, v7, v8, v3, v4, v5, v27, v28, v30, v11, v13))
            del v27; del v28; del v30
        else:
            v32 = len(v25)
            v33 = <double>v32
            v34 = 1.000000 / v33
            v35 = libc.math.log(v34)
            v36 = 0
            v37 = 0.000000
            v39 = method36(v32, v1, v2, v3, v4, v5, v6, v7, v8, v20, v12, v13, v10, v11, v24, v34, v35, v25, v36, v37)
        del v20; del v25
        v40 = v14 + 1
        v41 = v15 + v39
        return method26(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v40, v41)
    else:
        return v18 * v15
cdef object method25(v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8):
    return Closure5(v2, v0, v1, v3, v4, v5, v6, v7, v8)
cdef double method38(unsigned long long v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, UH0 v11, double v12, UH0 v13, double v14, double v15, double v16, double v17, numpy.ndarray[object,ndim=1] v18, unsigned long long v19, double v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US3 v23
    cdef object v37
    cdef bint v24
    cdef US0 v25
    cdef unsigned char v26
    cdef signed long v27
    cdef US0 v28
    cdef unsigned char v29
    cdef signed long v30
    cdef US1 v32
    cdef signed long v34
    cdef signed long v35
    cdef double v38
    cdef US2 v39
    cdef UH0 v40
    cdef US2 v41
    cdef UH0 v42
    cdef double v43
    cdef double v44
    cdef double v45
    v21 = v19 < v0
    if v21:
        v22 = v19 + 1
        v23 = v18[v19]
        if v23.tag == 0: # call
            v24 = v9 == 0
            if v24:
                v25, v26, v27, v28, v29, v30 = v8, v9, v7, v5, v6, v7
            else:
                v25, v26, v27, v28, v29, v30 = v5, v6, v7, v8, v9, v7
            v37 = method25(v1, v2, v3, v28, v29, v30, v25, v26, v27)
            del v25; del v28
        elif v23.tag == 1: # fold
            v32 = US1_0()
            v37 = method34(v1, v32, v5, v6, v7, v8, v9, v10)
            del v32
        elif v23.tag == 2: # raise
            v34 = v4 - 1
            v35 = v7 + 2
            v37 = method37(v1, v2, v3, v34, v8, v9, v35, v5, v6, v7)
        v38 = v17 + v12
        v39 = US2_0(v23)
        v40 = UH0_0(v39, v13)
        del v39
        v41 = US2_0(v23)
        del v23
        v42 = UH0_0(v41, v11)
        del v41
        v43 = v37(Tuple4(v15, v40, v14, v42, v38))
        del v37; del v40; del v42
        v44 = v16 * v43
        v45 = v20 + v44
        return method38(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v22, v45)
    else:
        return v20
cdef object method37(v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method28(v1, v4, v5, v6, v7, v8, v9, v3)
    return Closure10(v0, v7, v8, v9, v4, v5, v6, v10, v1, v2, v3)
cdef double method39(unsigned long long v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, UH0 v10, double v11, UH0 v12, double v13, double v14, double v15, double v16, numpy.ndarray[object,ndim=1] v17, unsigned long long v18, double v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US3 v22
    cdef object v36
    cdef bint v23
    cdef US0 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef US0 v27
    cdef unsigned char v28
    cdef signed long v29
    cdef US1 v31
    cdef signed long v33
    cdef signed long v34
    cdef double v37
    cdef US2 v38
    cdef UH0 v39
    cdef US2 v40
    cdef UH0 v41
    cdef double v42
    cdef double v43
    cdef double v44
    v20 = v18 < v0
    if v20:
        v21 = v18 + 1
        v22 = v17[v18]
        if v22.tag == 0: # call
            v23 = v9 == 0
            if v23:
                v24, v25, v26, v27, v28, v29 = v8, v9, v7, v5, v6, v7
            else:
                v24, v25, v26, v27, v28, v29 = v5, v6, v7, v8, v9, v7
            v36 = method25(v1, v2, v3, v27, v28, v29, v24, v25, v26)
            del v24; del v27
        elif v22.tag == 1: # fold
            v31 = US1_0()
            v36 = method32(v1, v31, v5, v6, v7, v8, v9)
            del v31
        elif v22.tag == 2: # raise
            v33 = v4 - 1
            v34 = v7 + 2
            v36 = method37(v1, v2, v3, v33, v8, v9, v34, v5, v6, v7)
        v37 = v16 + v11
        v38 = US2_0(v22)
        v39 = UH0_0(v38, v12)
        del v38
        v40 = US2_0(v22)
        del v22
        v41 = UH0_0(v40, v10)
        del v40
        v42 = v36(Tuple4(v14, v39, v13, v41, v37))
        del v36; del v39; del v41
        v43 = v15 * v42
        v44 = v19 + v43
        return method39(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v21, v44)
    else:
        return v19
cdef object method23(v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8):
    cdef numpy.ndarray[object,ndim=1] v9
    v9 = method24(v1, v4, v5, v6, v7, v8, v3)
    return Closure3(v0, v7, v8, v6, v4, v5, v9, v1, v2, v3)
cdef double method21(numpy.ndarray[object,ndim=1] v0, v1, Heap0 v2, US0 v3, double v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef US0 v15
    cdef unsigned long long v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef unsigned char v23
    cdef UH0 v24
    cdef double v25
    cdef Tuple3 tmp3
    cdef unsigned char v26
    cdef UH0 v27
    cdef double v28
    cdef Tuple3 tmp4
    cdef numpy.ndarray[object,ndim=1] v29
    cdef US1 v30
    cdef object v31
    cdef double v32
    cdef unsigned long long v33
    cdef double v34
    v11 = len(v0)
    v12 = <double>v11
    v13 = 1.000000 / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - 1
        v17 = numpy.empty(v16,dtype=object)
        v18 = 0
        method19(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = 1.000000 / v19
        v21 = libc.math.log(v20)
        v22 = v21 + v4
        v23 = 0
        tmp3 = method22(v15, v23, v5, v6)
        v24, v25 = tmp3.v0, tmp3.v1
        del tmp3
        v26 = 1
        tmp4 = method22(v15, v26, v7, v8)
        v27, v28 = tmp4.v0, tmp4.v1
        del tmp4
        v29 = v2.v2
        v30 = US1_0()
        v31 = Closure2(v1, v3, v15, v2, v17, v27, v28, v24, v25, v22)
        del v17; del v27
        v32 = v1(Tuple0(v29, v22, v3, 0, 1, v15, 1, 1, v30, v31, v24, v25, v28))
        del v15; del v24; del v29; del v30; del v31
        v33 = v9 + 1
        v34 = v10 + v32
        return method21(v0, v1, v2, v3, v4, v5, v6, v7, v8, v33, v34)
    else:
        return v13 * v10
cdef double method18(numpy.ndarray[object,ndim=1] v0, v1, Heap0 v2, UH0 v3, double v4, UH0 v5, double v6, unsigned long long v7, double v8):
    cdef unsigned long long v9
    cdef double v10
    cdef double v11
    cdef bint v12
    cdef US0 v13
    cdef unsigned long long v14
    cdef numpy.ndarray[object,ndim=1] v15
    cdef unsigned long long v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef unsigned char v20
    cdef UH0 v21
    cdef double v22
    cdef Tuple3 tmp1
    cdef unsigned char v23
    cdef UH0 v24
    cdef double v25
    cdef Tuple3 tmp2
    cdef unsigned long long v26
    cdef double v27
    cdef double v28
    cdef unsigned long long v29
    cdef double v30
    v9 = len(v0)
    v10 = <double>v9
    v11 = 1.000000 / v10
    v12 = v7 < v9
    if v12:
        v13 = v0[v7]
        v14 = v9 - 1
        v15 = numpy.empty(v14,dtype=object)
        v16 = 0
        method19(v14, v7, v0, v15, v16)
        v17 = <double>v9
        v18 = 1.000000 / v17
        v19 = libc.math.log(v18)
        v20 = 0
        tmp1 = method20(v13, v20, v3, v4)
        v21, v22 = tmp1.v0, tmp1.v1
        del tmp1
        v23 = 1
        tmp2 = method20(v13, v23, v5, v6)
        v24, v25 = tmp2.v0, tmp2.v1
        del tmp2
        v26 = 0
        v27 = 0.000000
        v28 = method21(v15, v1, v2, v13, v19, v21, v22, v24, v25, v26, v27)
        del v13; del v15; del v21; del v24
        v29 = v7 + 1
        v30 = v8 + v28
        return method18(v0, v1, v2, v3, v4, v5, v6, v29, v30)
    else:
        return v11 * v8
cpdef void main():
    cdef list v0
    cdef object v1
    cdef object v2
    cdef UH0 v3
    cdef double v4
    cdef UH0 v5
    cdef double v6
    cdef object v7
    pass # import ui_replay
    v0 = [None]*0
    pass # import nets
    v1 = nets.small(30,64,3)
    v2 = Closure0(v1, v0)
    del v1
    v3 = UH0_1()
    v4 = 0.000000
    v5 = UH0_1()
    v6 = 0.000000
    v7 = Closure1(v0, v2, v3, v4, v5, v6)
    del v0; del v2; del v3; del v5
    ui_replay.run(v7)
