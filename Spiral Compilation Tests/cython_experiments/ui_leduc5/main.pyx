import ui_leduc
import nets
import numpy
cimport numpy
cimport libc.math
import torch
import torch.nn.functional
import torch.distributions
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
    cdef readonly object v4
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
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
cdef class US4:
    cdef readonly signed long tag
cdef class US4_0(US4): # none
    def __init__(self): self.tag = 0
cdef class US4_1(US4): # some_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, US1 v0):
        pass
cdef class Mut0:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure6():
    cdef object v0
    cdef US1 v1
    def __init__(self, v0, US1 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        v0(v1)
cdef class Closure7():
    cdef object v0
    cdef US1 v1
    def __init__(self, v0, US1 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        v0(v1)
cdef class Closure8():
    cdef object v0
    cdef US1 v1
    def __init__(self, v0, US1 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        v0(v1)
cdef class Closure4():
    cdef object v0
    cdef object v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US3 v8
    cdef double v9
    def __init__(self, v0, v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US3 v8, double v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
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
        cdef object v14 = args.v4
        cdef double v15
        cdef numpy.ndarray[object,ndim=1] v16
        cdef US4 v17
        cdef object v18
        v15 =  -v9
        v16 = numpy.empty(0,dtype=object)
        
        v17 = US4_1(v15)
        v18 = Closure5()
        method26(v0, v18, v16, v12, v17, v8, v5, v6, v7, v2, v3, v4)
        del v16; del v17; del v18
        v14(v9)
cdef class Closure10():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef signed long v5
    cdef US2 v6
    cdef US2 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US2 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    def __init__(self, UH0 v0, double v1, v2, v3, Heap0 v4, signed long v5, US2 v6, US2 v7, unsigned char v8, signed long v9, US2 v10, unsigned char v11, signed long v12, v13, UH0 v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, US1 v16):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US2 v6 = self.v6
        cdef US2 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US2 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
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
        cdef Tuple3 tmp9
        cdef signed long v32
        cdef signed long v33
        cdef Tuple3 tmp10
        cdef bint v34
        cdef signed long v37
        cdef bint v35
        cdef bint v38
        cdef bint v39
        cdef bint v40
        cdef bint v47
        cdef US3 v48
        cdef bint v50
        cdef US3 v51
        cdef US3 v53
        cdef signed long v54
        cdef US3 v58
        cdef signed long v60
        cdef signed long v61
        cdef US0 v64
        cdef UH0 v65
        cdef US0 v66
        cdef UH0 v67
        if v16.tag == 0: # call
            if v10.tag == 0: # jack
                v17 = 0
            elif v10.tag == 1: # king
                v17 = 2
            elif v10.tag == 2: # queen
                v17 = 1
            if v6.tag == 0: # jack
                v18 = 0
            elif v6.tag == 1: # king
                v18 = 2
            elif v6.tag == 2: # queen
                v18 = 1
            if v7.tag == 0: # jack
                v19 = 0
            elif v7.tag == 1: # king
                v19 = 2
            elif v7.tag == 2: # queen
                v19 = 1
            if v6.tag == 0: # jack
                v20 = 0
            elif v6.tag == 1: # king
                v20 = 2
            elif v6.tag == 2: # queen
                v20 = 1
            v21 = method23(v18, v17)
            if v21:
                v23 = method23(v20, v19)
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
                v28 = method23(v18, v17)
                if v28:
                    v46 = 1
                else:
                    v29 = method23(v20, v19)
                    if v29:
                        v46 = -1
                    else:
                        tmp9 = method24(v18, v17)
                        v30, v31 = tmp9.v0, tmp9.v1
                        del tmp9
                        tmp10 = method24(v20, v19)
                        v32, v33 = tmp10.v0, tmp10.v1
                        del tmp10
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
                v48 = US3_1(v6)
                v63 = method25(v2, v3, v48, v7, v8, v9, v10, v11)
                del v48
            else:
                v50 = v46 == -1
                if v50:
                    v51 = US3_1(v6)
                    v63 = method30(v2, v3, v51, v7, v8, v9, v10, v11)
                    del v51
                else:
                    v53 = US3_1(v6)
                    v54 = 0
                    v63 = method31(v2, v3, v53, v7, v8, v9, v10, v11, v54)
                    del v53
        elif v16.tag == 1: # fold
            v58 = US3_1(v6)
            v63 = method34(v2, v3, v58, v7, v8, v9, v10, v11, v12)
            del v58
        elif v16.tag == 2: # raise
            v60 = v5 - 1
            v61 = v9 + 4
            v63 = method32(v2, v3, v4, v60, v6, v10, v11, v61, v7, v8, v9)
        v64 = US0_0(v16)
        v65 = UH0_0(v64, v14)
        del v64
        v66 = US0_0(v16)
        v67 = UH0_0(v66, v0)
        del v66
        v63(Tuple2(v65, v15, v67, v1, v13))
cdef class Closure9():
    cdef object v0
    cdef object v1
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
    def __init__(self, v0, v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US2 v8, numpy.ndarray[object,ndim=1] v9, Heap0 v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
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
        cdef object v16 = args.v4
        cdef bint v17
        cdef numpy.ndarray[object,ndim=1] v18
        cdef numpy.ndarray[float,ndim=1] v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef bint v23
        cdef unsigned long long v24
        cdef object v25
        cdef object v26
        cdef unsigned long long v27
        cdef numpy.ndarray[signed long long,ndim=1] v28
        cdef unsigned long long v29
        cdef object v30
        cdef object v31
        cdef object v32
        cdef object v33
        cdef object v34
        cdef double v35
        cdef signed long long v36
        cdef unsigned long long v37
        cdef signed long long v38
        cdef US1 v39
        cdef object v86
        cdef signed long v40
        cdef signed long v41
        cdef signed long v42
        cdef signed long v43
        cdef bint v44
        cdef bint v46
        cdef signed long v69
        cdef bint v47
        cdef bint v48
        cdef bint v51
        cdef bint v52
        cdef signed long v53
        cdef signed long v54
        cdef Tuple3 tmp7
        cdef signed long v55
        cdef signed long v56
        cdef Tuple3 tmp8
        cdef bint v57
        cdef signed long v60
        cdef bint v58
        cdef bint v61
        cdef bint v62
        cdef bint v63
        cdef bint v70
        cdef US3 v71
        cdef bint v73
        cdef US3 v74
        cdef US3 v76
        cdef signed long v77
        cdef US3 v81
        cdef signed long v83
        cdef signed long v84
        cdef double v87
        cdef US0 v88
        cdef UH0 v89
        cdef US0 v90
        cdef UH0 v91
        cdef US3 v92
        cdef US4 v93
        cdef object v94
        v17 = v3 == 0
        if v17:
            v18 = method3(v12)
            v19 = numpy.empty(30,dtype=numpy.float32)
            v20 = len(v19)
            v21 = 0
            method13(v20, v19, v21)
            v22 = len(v18)
            v23 = 2 < v22
            if v23:
                raise Exception("The given array is too large.")
            else:
                pass
            v24 = 0
            method14(v22, v19, v18, v24)
            del v18
            pass # import torch
            v25 = torch.from_numpy(v19)
            del v19
            v26 = v1.forward(v25)
            del v25
            v27 = len(v9)
            v28 = numpy.empty(v27,dtype=numpy.int64)
            v29 = 0
            method16(v27, v9, v28, v29)
            v30 = v26[v28]
            del v26
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
            v38 = v28[v37]
            del v28
            v39 = method18(v38)
            if v39.tag == 0: # call
                if v2.tag == 0: # jack
                    v40 = 0
                elif v2.tag == 1: # king
                    v40 = 2
                elif v2.tag == 2: # queen
                    v40 = 1
                if v8.tag == 0: # jack
                    v41 = 0
                elif v8.tag == 1: # king
                    v41 = 2
                elif v8.tag == 2: # queen
                    v41 = 1
                if v5.tag == 0: # jack
                    v42 = 0
                elif v5.tag == 1: # king
                    v42 = 2
                elif v5.tag == 2: # queen
                    v42 = 1
                if v8.tag == 0: # jack
                    v43 = 0
                elif v8.tag == 1: # king
                    v43 = 2
                elif v8.tag == 2: # queen
                    v43 = 1
                v44 = method23(v41, v40)
                if v44:
                    v46 = method23(v43, v42)
                else:
                    v46 = 0
                if v46:
                    v47 = v40 < v42
                    if v47:
                        v69 = -1
                    else:
                        v48 = v40 > v42
                        if v48:
                            v69 = 1
                        else:
                            v69 = 0
                else:
                    v51 = method23(v41, v40)
                    if v51:
                        v69 = 1
                    else:
                        v52 = method23(v43, v42)
                        if v52:
                            v69 = -1
                        else:
                            tmp7 = method24(v41, v40)
                            v53, v54 = tmp7.v0, tmp7.v1
                            del tmp7
                            tmp8 = method24(v43, v42)
                            v55, v56 = tmp8.v0, tmp8.v1
                            del tmp8
                            v57 = v53 < v55
                            if v57:
                                v60 = -1
                            else:
                                v58 = v53 > v55
                                if v58:
                                    v60 = 1
                                else:
                                    v60 = 0
                            v61 = v60 == 0
                            if v61:
                                v62 = v54 < v56
                                if v62:
                                    v69 = -1
                                else:
                                    v63 = v54 > v56
                                    if v63:
                                        v69 = 1
                                    else:
                                        v69 = 0
                            else:
                                v69 = v60
                v70 = v69 == 1
                if v70:
                    v71 = US3_1(v8)
                    v86 = method25(v0, v1, v71, v5, v6, v7, v2, v3)
                    del v71
                else:
                    v73 = v69 == -1
                    if v73:
                        v74 = US3_1(v8)
                        v86 = method30(v0, v1, v74, v5, v6, v7, v2, v3)
                        del v74
                    else:
                        v76 = US3_1(v8)
                        v77 = 0
                        v86 = method31(v0, v1, v76, v5, v6, v7, v2, v3, v77)
                        del v76
            elif v39.tag == 1: # fold
                v81 = US3_1(v8)
                v86 = method34(v0, v1, v81, v5, v6, v7, v2, v3, v4)
                del v81
            elif v39.tag == 2: # raise
                v83 = v11 - 1
                v84 = v7 + 4
                v86 = method32(v0, v1, v10, v83, v8, v2, v3, v84, v5, v6, v7)
            v87 = v35 + v13
            v88 = US0_0(v39)
            v89 = UH0_0(v88, v12)
            del v88
            v90 = US0_0(v39)
            del v39
            v91 = UH0_0(v90, v14)
            del v90
            v86(Tuple2(v89, v87, v91, v15, v16))
        else:
            v92 = US3_1(v8)
            v93 = US4_0()
            v94 = Closure10(v14, v15, v0, v1, v10, v11, v8, v5, v6, v7, v2, v3, v4, v16, v12, v13)
            method26(v0, v94, v9, v14, v93, v92, v5, v6, v7, v2, v3, v4)
cdef class Closure11():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef signed long v5
    cdef US2 v6
    cdef US2 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US2 v10
    cdef unsigned char v11
    cdef object v12
    cdef UH0 v13
    cdef double v14
    def __init__(self, UH0 v0, double v1, v2, v3, Heap0 v4, signed long v5, US2 v6, US2 v7, unsigned char v8, signed long v9, US2 v10, unsigned char v11, v12, UH0 v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, US1 v15):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US2 v6 = self.v6
        cdef US2 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US2 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef object v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef object v62
        cdef signed long v16
        cdef signed long v17
        cdef signed long v18
        cdef signed long v19
        cdef bint v20
        cdef bint v22
        cdef signed long v45
        cdef bint v23
        cdef bint v24
        cdef bint v27
        cdef bint v28
        cdef signed long v29
        cdef signed long v30
        cdef Tuple3 tmp11
        cdef signed long v31
        cdef signed long v32
        cdef Tuple3 tmp12
        cdef bint v33
        cdef signed long v36
        cdef bint v34
        cdef bint v37
        cdef bint v38
        cdef bint v39
        cdef bint v46
        cdef US3 v47
        cdef bint v49
        cdef US3 v50
        cdef US3 v52
        cdef signed long v53
        cdef US3 v57
        cdef signed long v59
        cdef signed long v60
        cdef US0 v63
        cdef UH0 v64
        cdef US0 v65
        cdef UH0 v66
        if v15.tag == 0: # call
            if v10.tag == 0: # jack
                v16 = 0
            elif v10.tag == 1: # king
                v16 = 2
            elif v10.tag == 2: # queen
                v16 = 1
            if v6.tag == 0: # jack
                v17 = 0
            elif v6.tag == 1: # king
                v17 = 2
            elif v6.tag == 2: # queen
                v17 = 1
            if v7.tag == 0: # jack
                v18 = 0
            elif v7.tag == 1: # king
                v18 = 2
            elif v7.tag == 2: # queen
                v18 = 1
            if v6.tag == 0: # jack
                v19 = 0
            elif v6.tag == 1: # king
                v19 = 2
            elif v6.tag == 2: # queen
                v19 = 1
            v20 = method23(v17, v16)
            if v20:
                v22 = method23(v19, v18)
            else:
                v22 = 0
            if v22:
                v23 = v16 < v18
                if v23:
                    v45 = -1
                else:
                    v24 = v16 > v18
                    if v24:
                        v45 = 1
                    else:
                        v45 = 0
            else:
                v27 = method23(v17, v16)
                if v27:
                    v45 = 1
                else:
                    v28 = method23(v19, v18)
                    if v28:
                        v45 = -1
                    else:
                        tmp11 = method24(v17, v16)
                        v29, v30 = tmp11.v0, tmp11.v1
                        del tmp11
                        tmp12 = method24(v19, v18)
                        v31, v32 = tmp12.v0, tmp12.v1
                        del tmp12
                        v33 = v29 < v31
                        if v33:
                            v36 = -1
                        else:
                            v34 = v29 > v31
                            if v34:
                                v36 = 1
                            else:
                                v36 = 0
                        v37 = v36 == 0
                        if v37:
                            v38 = v30 < v32
                            if v38:
                                v45 = -1
                            else:
                                v39 = v30 > v32
                                if v39:
                                    v45 = 1
                                else:
                                    v45 = 0
                        else:
                            v45 = v36
            v46 = v45 == 1
            if v46:
                v47 = US3_1(v6)
                v62 = method25(v2, v3, v47, v7, v8, v9, v10, v11)
                del v47
            else:
                v49 = v45 == -1
                if v49:
                    v50 = US3_1(v6)
                    v62 = method30(v2, v3, v50, v7, v8, v9, v10, v11)
                    del v50
                else:
                    v52 = US3_1(v6)
                    v53 = 0
                    v62 = method31(v2, v3, v52, v7, v8, v9, v10, v11, v53)
                    del v52
        elif v15.tag == 1: # fold
            v57 = US3_1(v6)
            v62 = method30(v2, v3, v57, v7, v8, v9, v10, v11)
            del v57
        elif v15.tag == 2: # raise
            v59 = v5 - 1
            v60 = v9 + 4
            v62 = method32(v2, v3, v4, v59, v6, v10, v11, v60, v7, v8, v9)
        v63 = US0_0(v15)
        v64 = UH0_0(v63, v13)
        del v63
        v65 = US0_0(v15)
        v66 = UH0_0(v65, v0)
        del v65
        v62(Tuple2(v64, v14, v66, v1, v12))
cdef class Closure3():
    cdef object v0
    cdef object v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef US2 v7
    cdef object v8
    cdef Heap0 v9
    cdef signed long v10
    def __init__(self, v0, v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, US2 v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US2 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef US2 v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = args.v0
        cdef double v12 = args.v1
        cdef UH0 v13 = args.v2
        cdef double v14 = args.v3
        cdef object v15 = args.v4
        cdef bint v16
        cdef numpy.ndarray[object,ndim=1] v17
        cdef numpy.ndarray[float,ndim=1] v18
        cdef unsigned long long v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef bint v22
        cdef unsigned long long v23
        cdef object v24
        cdef object v25
        cdef unsigned long long v26
        cdef numpy.ndarray[signed long long,ndim=1] v27
        cdef unsigned long long v28
        cdef object v29
        cdef object v30
        cdef object v31
        cdef object v32
        cdef object v33
        cdef double v34
        cdef signed long long v35
        cdef unsigned long long v36
        cdef signed long long v37
        cdef US1 v38
        cdef object v85
        cdef signed long v39
        cdef signed long v40
        cdef signed long v41
        cdef signed long v42
        cdef bint v43
        cdef bint v45
        cdef signed long v68
        cdef bint v46
        cdef bint v47
        cdef bint v50
        cdef bint v51
        cdef signed long v52
        cdef signed long v53
        cdef Tuple3 tmp5
        cdef signed long v54
        cdef signed long v55
        cdef Tuple3 tmp6
        cdef bint v56
        cdef signed long v59
        cdef bint v57
        cdef bint v60
        cdef bint v61
        cdef bint v62
        cdef bint v69
        cdef US3 v70
        cdef bint v72
        cdef US3 v73
        cdef US3 v75
        cdef signed long v76
        cdef US3 v80
        cdef signed long v82
        cdef signed long v83
        cdef double v86
        cdef US0 v87
        cdef UH0 v88
        cdef US0 v89
        cdef UH0 v90
        cdef US3 v91
        cdef US4 v92
        cdef object v93
        v16 = v3 == 0
        if v16:
            v17 = method3(v11)
            v18 = numpy.empty(30,dtype=numpy.float32)
            v19 = len(v18)
            v20 = 0
            method13(v19, v18, v20)
            v21 = len(v17)
            v22 = 2 < v21
            if v22:
                raise Exception("The given array is too large.")
            else:
                pass
            v23 = 0
            method14(v21, v18, v17, v23)
            del v17
            pass # import torch
            v24 = torch.from_numpy(v18)
            del v18
            v25 = v1.forward(v24)
            del v24
            v26 = len(v8)
            v27 = numpy.empty(v26,dtype=numpy.int64)
            v28 = 0
            method16(v26, v8, v27, v28)
            v29 = v25[v27]
            del v25
            pass # import torch.nn.functional
            v30 = torch.nn.functional.softmax(v29,-1)
            del v29
            pass # import torch.distributions
            v31 = torch.distributions.Categorical(probs=v30)
            del v30
            v32 = v31.sample()
            v33 = v31.log_prob(v32)
            del v31
            v34 = v33.item()
            del v33
            v35 = v32.item()
            del v32
            v36 = v35
            v37 = v27[v36]
            del v27
            v38 = method18(v37)
            if v38.tag == 0: # call
                if v2.tag == 0: # jack
                    v39 = 0
                elif v2.tag == 1: # king
                    v39 = 2
                elif v2.tag == 2: # queen
                    v39 = 1
                if v7.tag == 0: # jack
                    v40 = 0
                elif v7.tag == 1: # king
                    v40 = 2
                elif v7.tag == 2: # queen
                    v40 = 1
                if v5.tag == 0: # jack
                    v41 = 0
                elif v5.tag == 1: # king
                    v41 = 2
                elif v5.tag == 2: # queen
                    v41 = 1
                if v7.tag == 0: # jack
                    v42 = 0
                elif v7.tag == 1: # king
                    v42 = 2
                elif v7.tag == 2: # queen
                    v42 = 1
                v43 = method23(v40, v39)
                if v43:
                    v45 = method23(v42, v41)
                else:
                    v45 = 0
                if v45:
                    v46 = v39 < v41
                    if v46:
                        v68 = -1
                    else:
                        v47 = v39 > v41
                        if v47:
                            v68 = 1
                        else:
                            v68 = 0
                else:
                    v50 = method23(v40, v39)
                    if v50:
                        v68 = 1
                    else:
                        v51 = method23(v42, v41)
                        if v51:
                            v68 = -1
                        else:
                            tmp5 = method24(v40, v39)
                            v52, v53 = tmp5.v0, tmp5.v1
                            del tmp5
                            tmp6 = method24(v42, v41)
                            v54, v55 = tmp6.v0, tmp6.v1
                            del tmp6
                            v56 = v52 < v54
                            if v56:
                                v59 = -1
                            else:
                                v57 = v52 > v54
                                if v57:
                                    v59 = 1
                                else:
                                    v59 = 0
                            v60 = v59 == 0
                            if v60:
                                v61 = v53 < v55
                                if v61:
                                    v68 = -1
                                else:
                                    v62 = v53 > v55
                                    if v62:
                                        v68 = 1
                                    else:
                                        v68 = 0
                            else:
                                v68 = v59
                v69 = v68 == 1
                if v69:
                    v70 = US3_1(v7)
                    v85 = method25(v0, v1, v70, v5, v6, v4, v2, v3)
                    del v70
                else:
                    v72 = v68 == -1
                    if v72:
                        v73 = US3_1(v7)
                        v85 = method30(v0, v1, v73, v5, v6, v4, v2, v3)
                        del v73
                    else:
                        v75 = US3_1(v7)
                        v76 = 0
                        v85 = method31(v0, v1, v75, v5, v6, v4, v2, v3, v76)
                        del v75
            elif v38.tag == 1: # fold
                v80 = US3_1(v7)
                v85 = method30(v0, v1, v80, v5, v6, v4, v2, v3)
                del v80
            elif v38.tag == 2: # raise
                v82 = v10 - 1
                v83 = v4 + 4
                v85 = method32(v0, v1, v9, v82, v7, v2, v3, v83, v5, v6, v4)
            v86 = v34 + v12
            v87 = US0_0(v38)
            v88 = UH0_0(v87, v11)
            del v87
            v89 = US0_0(v38)
            del v38
            v90 = UH0_0(v89, v13)
            del v89
            v85(Tuple2(v88, v86, v90, v14, v15))
        else:
            v91 = US3_1(v7)
            v92 = US4_0()
            v93 = Closure11(v13, v14, v0, v1, v9, v10, v7, v5, v6, v4, v2, v3, v15, v11, v12)
            method35(v0, v93, v8, v13, v92, v91, v5, v6, v4, v2, v3)
cdef class Closure12():
    cdef US2 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef Heap0 v5
    cdef US2 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef object v11
    cdef UH0 v12
    cdef double v13
    def __init__(self, US2 v0, UH0 v1, double v2, v3, v4, Heap0 v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, v11, UH0 v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, US1 v14):
        cdef US2 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef object v4 = self.v4
        cdef Heap0 v5 = self.v5
        cdef US2 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef object v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef object v21
        cdef signed long v15
        cdef signed long v18
        cdef signed long v19
        cdef US0 v22
        cdef US0 v23
        cdef UH0 v24
        cdef UH0 v25
        cdef US0 v26
        cdef US0 v27
        cdef UH0 v28
        cdef UH0 v29
        if v14.tag == 0: # call
            v15 = 2
            v21 = method22(v3, v4, v5, v15, v0, v9, v10, v8, v6, v7)
        elif v14.tag == 1: # fold
            raise Exception("impossible")
        elif v14.tag == 2: # raise
            v18 = 1
            v19 = v8 + 4
            v21 = method32(v3, v4, v5, v18, v0, v9, v10, v19, v6, v7, v8)
        v22 = US0_0(v14)
        v23 = US0_1(v0)
        v24 = UH0_0(v23, v12)
        del v23
        v25 = UH0_0(v22, v24)
        del v22; del v24
        v26 = US0_0(v14)
        v27 = US0_1(v0)
        v28 = UH0_0(v27, v1)
        del v27
        v29 = UH0_0(v26, v28)
        del v26; del v28
        v21(Tuple2(v25, v13, v29, v2, v11))
cdef class Closure2():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef US2 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US2 v8
    cdef unsigned char v9
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, v3, Heap0 v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US2 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef UH0 v10 = args.v0
        cdef double v11 = args.v1
        cdef UH0 v12 = args.v2
        cdef double v13 = args.v3
        cdef object v14 = args.v4
        cdef US2 v15
        cdef unsigned long long v16
        cdef double v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef numpy.ndarray[object,ndim=1] v22
        cdef bint v23
        cdef US0 v24
        cdef UH0 v25
        cdef numpy.ndarray[object,ndim=1] v26
        cdef numpy.ndarray[float,ndim=1] v27
        cdef unsigned long long v28
        cdef unsigned long long v29
        cdef unsigned long long v30
        cdef bint v31
        cdef unsigned long long v32
        cdef object v33
        cdef object v34
        cdef unsigned long long v35
        cdef numpy.ndarray[signed long long,ndim=1] v36
        cdef unsigned long long v37
        cdef object v38
        cdef object v39
        cdef object v40
        cdef object v41
        cdef object v42
        cdef double v43
        cdef signed long long v44
        cdef unsigned long long v45
        cdef signed long long v46
        cdef US1 v47
        cdef object v54
        cdef signed long v48
        cdef signed long v51
        cdef signed long v52
        cdef double v55
        cdef US0 v56
        cdef US0 v57
        cdef UH0 v58
        cdef UH0 v59
        cdef US0 v60
        cdef US0 v61
        cdef UH0 v62
        cdef UH0 v63
        cdef US3 v64
        cdef US0 v65
        cdef UH0 v66
        cdef US4 v67
        cdef object v68
        v15 = v1[v0]
        v16 = len(v1)
        v17 = <double>v16
        v18 = 1.000000 / v17
        v19 = libc.math.log(v18)
        v20 = v19 + v11
        v21 = v19 + v13
        v22 = v4.v2
        v23 = v9 == 0
        if v23:
            v24 = US0_1(v15)
            v25 = UH0_0(v24, v10)
            del v24
            v26 = method3(v25)
            del v25
            v27 = numpy.empty(30,dtype=numpy.float32)
            v28 = len(v27)
            v29 = 0
            method13(v28, v27, v29)
            v30 = len(v26)
            v31 = 2 < v30
            if v31:
                raise Exception("The given array is too large.")
            else:
                pass
            v32 = 0
            method14(v30, v27, v26, v32)
            del v26
            pass # import torch
            v33 = torch.from_numpy(v27)
            del v27
            v34 = v3.forward(v33)
            del v33
            v35 = len(v22)
            v36 = numpy.empty(v35,dtype=numpy.int64)
            v37 = 0
            method16(v35, v22, v36, v37)
            del v22
            v38 = v34[v36]
            del v34
            pass # import torch.nn.functional
            v39 = torch.nn.functional.softmax(v38,-1)
            del v38
            pass # import torch.distributions
            v40 = torch.distributions.Categorical(probs=v39)
            del v39
            v41 = v40.sample()
            v42 = v40.log_prob(v41)
            del v40
            v43 = v42.item()
            del v42
            v44 = v41.item()
            del v41
            v45 = v44
            v46 = v36[v45]
            del v36
            v47 = method18(v46)
            if v47.tag == 0: # call
                v48 = 2
                v54 = method22(v2, v3, v4, v48, v15, v8, v9, v7, v5, v6)
            elif v47.tag == 1: # fold
                raise Exception("impossible")
            elif v47.tag == 2: # raise
                v51 = 1
                v52 = v7 + 4
                v54 = method32(v2, v3, v4, v51, v15, v8, v9, v52, v5, v6, v7)
            v55 = v43 + v20
            v56 = US0_0(v47)
            v57 = US0_1(v15)
            v58 = UH0_0(v57, v10)
            del v57
            v59 = UH0_0(v56, v58)
            del v56; del v58
            v60 = US0_0(v47)
            del v47
            v61 = US0_1(v15)
            del v15
            v62 = UH0_0(v61, v12)
            del v61
            v63 = UH0_0(v60, v62)
            del v60; del v62
            v54(Tuple2(v59, v55, v63, v21, v14))
        else:
            v64 = US3_1(v15)
            v65 = US0_1(v15)
            v66 = UH0_0(v65, v12)
            del v65
            v67 = US4_0()
            v68 = Closure12(v15, v12, v21, v2, v3, v4, v5, v6, v7, v8, v9, v14, v10, v20)
            del v15
            method35(v2, v68, v22, v66, v67, v64, v5, v6, v7, v8, v9)
cdef class Closure16():
    cdef US2 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef Heap0 v5
    cdef US2 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef object v12
    cdef UH0 v13
    cdef double v14
    def __init__(self, US2 v0, UH0 v1, double v2, v3, v4, Heap0 v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, signed long v11, v12, UH0 v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, US1 v15):
        cdef US2 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef object v4 = self.v4
        cdef Heap0 v5 = self.v5
        cdef US2 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef object v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef object v22
        cdef signed long v16
        cdef signed long v19
        cdef signed long v20
        cdef US0 v23
        cdef US0 v24
        cdef UH0 v25
        cdef UH0 v26
        cdef US0 v27
        cdef US0 v28
        cdef UH0 v29
        cdef UH0 v30
        if v15.tag == 0: # call
            v16 = 2
            v22 = method32(v3, v4, v5, v16, v0, v9, v10, v11, v6, v7, v8)
        elif v15.tag == 1: # fold
            raise Exception("impossible")
        elif v15.tag == 2: # raise
            v19 = 1
            v20 = v8 + 4
            v22 = method32(v3, v4, v5, v19, v0, v9, v10, v20, v6, v7, v8)
        v23 = US0_0(v15)
        v24 = US0_1(v0)
        v25 = UH0_0(v24, v13)
        del v24
        v26 = UH0_0(v23, v25)
        del v23; del v25
        v27 = US0_0(v15)
        v28 = US0_1(v0)
        v29 = UH0_0(v28, v1)
        del v28
        v30 = UH0_0(v27, v29)
        del v27; del v29
        v22(Tuple2(v26, v14, v30, v2, v12))
cdef class Closure15():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef US2 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US2 v8
    cdef unsigned char v9
    cdef signed long v10
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, v3, Heap0 v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef US2 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US2 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = args.v0
        cdef double v12 = args.v1
        cdef UH0 v13 = args.v2
        cdef double v14 = args.v3
        cdef object v15 = args.v4
        cdef US2 v16
        cdef unsigned long long v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef numpy.ndarray[object,ndim=1] v23
        cdef bint v24
        cdef US0 v25
        cdef UH0 v26
        cdef numpy.ndarray[object,ndim=1] v27
        cdef numpy.ndarray[float,ndim=1] v28
        cdef unsigned long long v29
        cdef unsigned long long v30
        cdef unsigned long long v31
        cdef bint v32
        cdef unsigned long long v33
        cdef object v34
        cdef object v35
        cdef unsigned long long v36
        cdef numpy.ndarray[signed long long,ndim=1] v37
        cdef unsigned long long v38
        cdef object v39
        cdef object v40
        cdef object v41
        cdef object v42
        cdef object v43
        cdef double v44
        cdef signed long long v45
        cdef unsigned long long v46
        cdef signed long long v47
        cdef US1 v48
        cdef object v55
        cdef signed long v49
        cdef signed long v52
        cdef signed long v53
        cdef double v56
        cdef US0 v57
        cdef US0 v58
        cdef UH0 v59
        cdef UH0 v60
        cdef US0 v61
        cdef US0 v62
        cdef UH0 v63
        cdef UH0 v64
        cdef US3 v65
        cdef US0 v66
        cdef UH0 v67
        cdef US4 v68
        cdef object v69
        v16 = v1[v0]
        v17 = len(v1)
        v18 = <double>v17
        v19 = 1.000000 / v18
        v20 = libc.math.log(v19)
        v21 = v20 + v12
        v22 = v20 + v14
        v23 = v4.v2
        v24 = v9 == 0
        if v24:
            v25 = US0_1(v16)
            v26 = UH0_0(v25, v11)
            del v25
            v27 = method3(v26)
            del v26
            v28 = numpy.empty(30,dtype=numpy.float32)
            v29 = len(v28)
            v30 = 0
            method13(v29, v28, v30)
            v31 = len(v27)
            v32 = 2 < v31
            if v32:
                raise Exception("The given array is too large.")
            else:
                pass
            v33 = 0
            method14(v31, v28, v27, v33)
            del v27
            pass # import torch
            v34 = torch.from_numpy(v28)
            del v28
            v35 = v3.forward(v34)
            del v34
            v36 = len(v23)
            v37 = numpy.empty(v36,dtype=numpy.int64)
            v38 = 0
            method16(v36, v23, v37, v38)
            del v23
            v39 = v35[v37]
            del v35
            pass # import torch.nn.functional
            v40 = torch.nn.functional.softmax(v39,-1)
            del v39
            pass # import torch.distributions
            v41 = torch.distributions.Categorical(probs=v40)
            del v40
            v42 = v41.sample()
            v43 = v41.log_prob(v42)
            del v41
            v44 = v43.item()
            del v43
            v45 = v42.item()
            del v42
            v46 = v45
            v47 = v37[v46]
            del v37
            v48 = method18(v47)
            if v48.tag == 0: # call
                v49 = 2
                v55 = method32(v2, v3, v4, v49, v16, v8, v9, v10, v5, v6, v7)
            elif v48.tag == 1: # fold
                raise Exception("impossible")
            elif v48.tag == 2: # raise
                v52 = 1
                v53 = v7 + 4
                v55 = method32(v2, v3, v4, v52, v16, v8, v9, v53, v5, v6, v7)
            v56 = v44 + v21
            v57 = US0_0(v48)
            v58 = US0_1(v16)
            v59 = UH0_0(v58, v11)
            del v58
            v60 = UH0_0(v57, v59)
            del v57; del v59
            v61 = US0_0(v48)
            del v48
            v62 = US0_1(v16)
            del v16
            v63 = UH0_0(v62, v13)
            del v62
            v64 = UH0_0(v61, v63)
            del v61; del v63
            v55(Tuple2(v60, v56, v64, v22, v15))
        else:
            v65 = US3_1(v16)
            v66 = US0_1(v16)
            v67 = UH0_0(v66, v13)
            del v66
            v68 = US4_0()
            v69 = Closure16(v16, v13, v22, v2, v3, v4, v5, v6, v7, v8, v9, v10, v15, v11, v21)
            del v16
            method26(v2, v69, v23, v67, v68, v65, v5, v6, v7, v8, v9, v10)
cdef class Closure14():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef object v5
    cdef signed long v6
    cdef US2 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US2 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    def __init__(self, UH0 v0, double v1, v2, v3, Heap0 v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US2 v7, unsigned char v8, signed long v9, US2 v10, unsigned char v11, signed long v12, v13, UH0 v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, US1 v16):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US2 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef object v30
        cdef bint v17
        cdef US2 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US2 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US3 v25
        cdef signed long v27
        cdef signed long v28
        cdef US0 v31
        cdef UH0 v32
        cdef US0 v33
        cdef UH0 v34
        if v16.tag == 0: # call
            v17 = v11 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v10, v11, v9, v7, v8, v9
            else:
                v18, v19, v20, v21, v22, v23 = v7, v8, v9, v10, v11, v9
            v30 = method37(v2, v3, v4, v5, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = US3_0()
            v30 = method34(v2, v3, v25, v7, v8, v9, v10, v11, v12)
            del v25
        elif v16.tag == 2: # raise
            v27 = v6 - 1
            v28 = v9 + 2
            v30 = method36(v2, v3, v4, v5, v27, v10, v11, v28, v7, v8, v9)
        v31 = US0_0(v16)
        v32 = UH0_0(v31, v14)
        del v31
        v33 = US0_0(v16)
        v34 = UH0_0(v33, v0)
        del v33
        v30(Tuple2(v32, v15, v34, v1, v13))
cdef class Closure13():
    cdef object v0
    cdef object v1
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
    def __init__(self, v0, v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, numpy.ndarray[object,ndim=1] v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
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
        cdef object v16 = args.v4
        cdef bint v17
        cdef numpy.ndarray[object,ndim=1] v18
        cdef numpy.ndarray[float,ndim=1] v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef bint v23
        cdef unsigned long long v24
        cdef object v25
        cdef object v26
        cdef unsigned long long v27
        cdef numpy.ndarray[signed long long,ndim=1] v28
        cdef unsigned long long v29
        cdef object v30
        cdef object v31
        cdef object v32
        cdef object v33
        cdef object v34
        cdef double v35
        cdef signed long long v36
        cdef unsigned long long v37
        cdef signed long long v38
        cdef US1 v39
        cdef object v46
        cdef US3 v41
        cdef signed long v43
        cdef signed long v44
        cdef double v47
        cdef US0 v48
        cdef UH0 v49
        cdef US0 v50
        cdef UH0 v51
        cdef US3 v52
        cdef US4 v53
        cdef object v54
        v17 = v3 == 0
        if v17:
            v18 = method3(v12)
            v19 = numpy.empty(30,dtype=numpy.float32)
            v20 = len(v19)
            v21 = 0
            method13(v20, v19, v21)
            v22 = len(v18)
            v23 = 2 < v22
            if v23:
                raise Exception("The given array is too large.")
            else:
                pass
            v24 = 0
            method14(v22, v19, v18, v24)
            del v18
            pass # import torch
            v25 = torch.from_numpy(v19)
            del v19
            v26 = v1.forward(v25)
            del v25
            v27 = len(v8)
            v28 = numpy.empty(v27,dtype=numpy.int64)
            v29 = 0
            method16(v27, v8, v28, v29)
            v30 = v26[v28]
            del v26
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
            v38 = v28[v37]
            del v28
            v39 = method18(v38)
            if v39.tag == 0: # call
                v46 = method21(v0, v1, v9, v10, v5, v6, v7, v2, v3)
            elif v39.tag == 1: # fold
                v41 = US3_0()
                v46 = method34(v0, v1, v41, v5, v6, v7, v2, v3, v4)
                del v41
            elif v39.tag == 2: # raise
                v43 = v11 - 1
                v44 = v7 + 2
                v46 = method36(v0, v1, v9, v10, v43, v2, v3, v44, v5, v6, v7)
            v47 = v35 + v13
            v48 = US0_0(v39)
            v49 = UH0_0(v48, v12)
            del v48
            v50 = US0_0(v39)
            del v39
            v51 = UH0_0(v50, v14)
            del v50
            v46(Tuple2(v49, v47, v51, v15, v16))
        else:
            v52 = US3_0()
            v53 = US4_0()
            v54 = Closure14(v14, v15, v0, v1, v9, v10, v11, v5, v6, v7, v2, v3, v4, v16, v12, v13)
            method26(v0, v54, v8, v14, v53, v52, v5, v6, v7, v2, v3, v4)
cdef class Closure17():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef object v5
    cdef signed long v6
    cdef US2 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US2 v10
    cdef unsigned char v11
    cdef object v12
    cdef UH0 v13
    cdef double v14
    def __init__(self, UH0 v0, double v1, v2, v3, Heap0 v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US2 v7, unsigned char v8, signed long v9, US2 v10, unsigned char v11, v12, UH0 v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, US1 v15):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US2 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef object v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef object v29
        cdef bint v16
        cdef US2 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef US2 v20
        cdef unsigned char v21
        cdef signed long v22
        cdef US3 v24
        cdef signed long v26
        cdef signed long v27
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        if v15.tag == 0: # call
            v16 = v11 == 0
            if v16:
                v17, v18, v19, v20, v21, v22 = v10, v11, v9, v7, v8, v9
            else:
                v17, v18, v19, v20, v21, v22 = v7, v8, v9, v10, v11, v9
            v29 = method37(v2, v3, v4, v5, v20, v21, v22, v17, v18, v19)
            del v17; del v20
        elif v15.tag == 1: # fold
            v24 = US3_0()
            v29 = method30(v2, v3, v24, v7, v8, v9, v10, v11)
            del v24
        elif v15.tag == 2: # raise
            v26 = v6 - 1
            v27 = v9 + 2
            v29 = method36(v2, v3, v4, v5, v26, v10, v11, v27, v7, v8, v9)
        v30 = US0_0(v15)
        v31 = UH0_0(v30, v13)
        del v30
        v32 = US0_0(v15)
        v33 = UH0_0(v32, v0)
        del v32
        v29(Tuple2(v31, v14, v33, v1, v12))
cdef class Closure1():
    cdef object v0
    cdef object v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef unsigned char v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    def __init__(self, v0, v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, numpy.ndarray[object,ndim=1] v7, Heap0 v8, numpy.ndarray[object,ndim=1] v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
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
        cdef object v15 = args.v4
        cdef bint v16
        cdef numpy.ndarray[object,ndim=1] v17
        cdef numpy.ndarray[float,ndim=1] v18
        cdef unsigned long long v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef bint v22
        cdef unsigned long long v23
        cdef object v24
        cdef object v25
        cdef unsigned long long v26
        cdef numpy.ndarray[signed long long,ndim=1] v27
        cdef unsigned long long v28
        cdef object v29
        cdef object v30
        cdef object v31
        cdef object v32
        cdef object v33
        cdef double v34
        cdef signed long long v35
        cdef unsigned long long v36
        cdef signed long long v37
        cdef US1 v38
        cdef object v45
        cdef US3 v40
        cdef signed long v42
        cdef signed long v43
        cdef double v46
        cdef US0 v47
        cdef UH0 v48
        cdef US0 v49
        cdef UH0 v50
        cdef US3 v51
        cdef US4 v52
        cdef object v53
        v16 = v3 == 0
        if v16:
            v17 = method3(v11)
            v18 = numpy.empty(30,dtype=numpy.float32)
            v19 = len(v18)
            v20 = 0
            method13(v19, v18, v20)
            v21 = len(v17)
            v22 = 2 < v21
            if v22:
                raise Exception("The given array is too large.")
            else:
                pass
            v23 = 0
            method14(v21, v18, v17, v23)
            del v17
            pass # import torch
            v24 = torch.from_numpy(v18)
            del v18
            v25 = v1.forward(v24)
            del v24
            v26 = len(v7)
            v27 = numpy.empty(v26,dtype=numpy.int64)
            v28 = 0
            method16(v26, v7, v27, v28)
            v29 = v25[v27]
            del v25
            pass # import torch.nn.functional
            v30 = torch.nn.functional.softmax(v29,-1)
            del v29
            pass # import torch.distributions
            v31 = torch.distributions.Categorical(probs=v30)
            del v30
            v32 = v31.sample()
            v33 = v31.log_prob(v32)
            del v31
            v34 = v33.item()
            del v33
            v35 = v32.item()
            del v32
            v36 = v35
            v37 = v27[v36]
            del v27
            v38 = method18(v37)
            if v38.tag == 0: # call
                v45 = method21(v0, v1, v8, v9, v5, v6, v4, v2, v3)
            elif v38.tag == 1: # fold
                v40 = US3_0()
                v45 = method30(v0, v1, v40, v5, v6, v4, v2, v3)
                del v40
            elif v38.tag == 2: # raise
                v42 = v10 - 1
                v43 = v4 + 2
                v45 = method36(v0, v1, v8, v9, v42, v2, v3, v43, v5, v6, v4)
            v46 = v34 + v12
            v47 = US0_0(v38)
            v48 = UH0_0(v47, v11)
            del v47
            v49 = US0_0(v38)
            del v38
            v50 = UH0_0(v49, v13)
            del v49
            v45(Tuple2(v48, v46, v50, v14, v15))
        else:
            v51 = US3_0()
            v52 = US4_0()
            v53 = Closure17(v13, v14, v0, v1, v8, v9, v10, v5, v6, v4, v2, v3, v15, v11, v12)
            method35(v0, v53, v7, v13, v52, v51, v5, v6, v4, v2, v3)
cdef class Closure18():
    def __init__(self): pass
    def __call__(self, double v0):
        pass
cdef class Closure0():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef UH0 v4
    cdef double v5
    def __init__(self, v0, UH0 v1, double v2, v3, UH0 v4, double v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
    def __call__(self):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
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
        cdef unsigned long long v27
        cdef US2 v28
        cdef unsigned long long v29
        cdef numpy.ndarray[object,ndim=1] v30
        cdef unsigned long long v31
        cdef double v32
        cdef double v33
        cdef double v34
        cdef unsigned char v35
        cdef UH0 v36
        cdef double v37
        cdef Tuple0 tmp0
        cdef unsigned char v38
        cdef UH0 v39
        cdef double v40
        cdef Tuple0 tmp1
        cdef unsigned long long v41
        cdef unsigned long long v42
        cdef US2 v43
        cdef unsigned long long v44
        cdef numpy.ndarray[object,ndim=1] v45
        cdef unsigned long long v46
        cdef double v47
        cdef double v48
        cdef double v49
        cdef unsigned char v50
        cdef UH0 v51
        cdef double v52
        cdef Tuple0 tmp2
        cdef unsigned char v53
        cdef UH0 v54
        cdef double v55
        cdef Tuple0 tmp3
        cdef numpy.ndarray[object,ndim=1] v56
        cdef numpy.ndarray[object,ndim=1] v57
        cdef numpy.ndarray[float,ndim=1] v58
        cdef unsigned long long v59
        cdef unsigned long long v60
        cdef unsigned long long v61
        cdef bint v62
        cdef unsigned long long v63
        cdef object v64
        cdef object v65
        cdef unsigned long long v66
        cdef numpy.ndarray[signed long long,ndim=1] v67
        cdef unsigned long long v68
        cdef object v69
        cdef object v70
        cdef object v71
        cdef object v72
        cdef object v73
        cdef double v74
        cdef signed long long v75
        cdef unsigned long long v76
        cdef signed long long v77
        cdef US1 v78
        cdef object v91
        cdef signed long v79
        cdef unsigned char v80
        cdef signed long v81
        cdef unsigned char v82
        cdef signed long v85
        cdef unsigned char v86
        cdef signed long v87
        cdef unsigned char v88
        cdef signed long v89
        cdef double v92
        cdef US0 v93
        cdef UH0 v94
        cdef US0 v95
        cdef UH0 v96
        cdef object v97
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
        v26 = len(v25)
        v27 = numpy.random.randint(0,v26)
        v28 = v25[v27]
        v29 = v26 - 1
        v30 = numpy.empty(v29,dtype=object)
        v31 = 0
        method0(v29, v27, v25, v30, v31)
        del v25
        v32 = <double>v26
        v33 = 1.000000 / v32
        v34 = libc.math.log(v33)
        v35 = 0
        tmp0 = method1(v28, v34, v35, v1, v2)
        v36, v37 = tmp0.v0, tmp0.v1
        del tmp0
        v38 = 1
        tmp1 = method1(v28, v34, v38, v4, v5)
        v39, v40 = tmp1.v0, tmp1.v1
        del tmp1
        v41 = len(v30)
        v42 = numpy.random.randint(0,v41)
        v43 = v30[v42]
        v44 = v41 - 1
        v45 = numpy.empty(v44,dtype=object)
        v46 = 0
        method0(v44, v42, v30, v45, v46)
        del v30
        v47 = <double>v41
        v48 = 1.000000 / v47
        v49 = libc.math.log(v48)
        v50 = 0
        tmp2 = method2(v43, v49, v50, v36, v37)
        v51, v52 = tmp2.v0, tmp2.v1
        del tmp2
        del v36
        v53 = 1
        tmp3 = method2(v43, v49, v53, v39, v40)
        v54, v55 = tmp3.v0, tmp3.v1
        del tmp3
        del v39
        v56 = v18.v2
        v57 = method3(v51)
        v58 = numpy.empty(30,dtype=numpy.float32)
        v59 = len(v58)
        v60 = 0
        method13(v59, v58, v60)
        v61 = len(v57)
        v62 = 2 < v61
        if v62:
            raise Exception("The given array is too large.")
        else:
            pass
        v63 = 0
        method14(v61, v58, v57, v63)
        del v57
        pass # import torch
        v64 = torch.from_numpy(v58)
        del v58
        v65 = v0.forward(v64)
        del v64
        v66 = len(v56)
        v67 = numpy.empty(v66,dtype=numpy.int64)
        v68 = 0
        method16(v66, v56, v67, v68)
        del v56
        v69 = v65[v67]
        del v65
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
        v77 = v67[v76]
        del v67
        v78 = method18(v77)
        if v78.tag == 0: # call
            v79 = 2
            v80 = 1
            v81 = 1
            v82 = 0
            v91 = method19(v3, v0, v18, v45, v79, v28, v82, v81, v43, v80)
        elif v78.tag == 1: # fold
            raise Exception("impossible")
        elif v78.tag == 2: # raise
            v85 = 1
            v86 = 1
            v87 = 1
            v88 = 0
            v89 = 3
            v91 = method36(v3, v0, v18, v45, v85, v28, v88, v89, v43, v86, v87)
        del v18; del v28; del v43; del v45
        v92 = v74 + v52
        v93 = US0_0(v78)
        v94 = UH0_0(v93, v51)
        del v51; del v93
        v95 = US0_0(v78)
        del v78
        v96 = UH0_0(v95, v54)
        del v54; del v95
        v97 = Closure18()
        v91(Tuple2(v94, v92, v96, v55, v97))
cdef void method0(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method0(v0, v1, v2, v3, v6)
    else:
        pass
cdef Tuple0 method1(US2 v0, double v1, unsigned char v2, UH0 v3, double v4):
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
cdef Tuple0 method2(US2 v0, double v1, unsigned char v2, UH0 v3, double v4):
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
cdef UH0 method4(UH0 v0, UH0 v1):
    cdef US0 v2
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
    cdef US1 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        del v2
        return method6(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method8(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method8(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(numpy.ndarray[object,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US1 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method9(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method7(UH1 v0):
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
cdef UH2 method5(UH1 v0, US2 v1, UH0 v2):
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
            return method5(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US0_1>v3).v0
            v9 = UH1_1()
            v10 = method6(v0, v9)
            del v9
            v11 = method7(v10)
            del v10
            v12 = UH1_1()
            v13 = method5(v12, v8, v4)
            del v4; del v8; del v12
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
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v4 = (<UH2_0>v0).v2
        v5 = v1 + 1
        return method11(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method12(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US2 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v3; del v4
        v6 = v2 + 1
        return method12(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method10(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method11(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method12(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method3(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US0 v3
    cdef UH0 v4
    cdef US2 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method4(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US0_1>v3).v0
            v8 = UH1_1()
            v9 = method5(v8, v7, v4)
            del v4; del v7; del v8
            return method10(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef void method13(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method13(v0, v1, v4)
    else:
        pass
cdef void method15(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method15(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
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
        method15(v12, v1, v11, v7, v14)
        del v7
        method14(v0, v1, v2, v5)
    else:
        pass
cdef signed long long method17(US1 v0):
    cdef signed long long v1
    if v0.tag == 0: # call
        v1 = 0
    elif v0.tag == 1: # fold
        v1 = 1
    elif v0.tag == 2: # raise
        v1 = 2
    return v1
cdef void method16(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        v7 = method17(v6)
        del v6
        v2[v3] = v7
        method16(v0, v1, v2, v5)
    else:
        pass
cdef US1 method18(signed long long v0):
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
    v1 = v0 < 3
    v2 = v1 == 0
    if v2:
        raise Exception("The size of the argument is too large.")
    else:
        pass
    v3 = v0 < 1
    if v3:
        v4 = v0 == 0
        v5 = v4 == 0
        if v5:
            raise Exception("The unit index should be 0.")
        else:
            pass
        return US1_0()
    else:
        v7 = v0 < 2
        if v7:
            v8 = v0 - 1
            v9 = v8 == 0
            v10 = v9 == 0
            if v10:
                raise Exception("The unit index should be 0.")
            else:
                pass
            return US1_1()
        else:
            if v1:
                v12 = v0 - 2
                v13 = v12 == 0
                v14 = v13 == 0
                if v14:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                return US1_2()
            else:
                raise Exception("Unpickling of an union failed.")
cdef numpy.ndarray[object,ndim=1] method20(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6):
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
cdef bint method23(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple3 method24(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple3(v1, v0)
    else:
        return Tuple3(v0, v1)
cdef bint method28(list v0, UH0 v1, bint v2):
    cdef US0 v3
    cdef UH0 v4
    cdef bint v5
    cdef US1 v6
    cdef str v7
    cdef str v8
    cdef str v9
    cdef US2 v11
    cdef str v12
    cdef str v13
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1
        v5 = method28(v0, v4, v2)
        del v4
        if v3.tag == 0: # action_
            v6 = (<US0_0>v3).v0
            if v5:
                v7 = "One"
            else:
                v7 = "Two"
            if v6.tag == 0: # call
                v8 = "calls"
            elif v6.tag == 1: # fold
                v8 = "folds"
            elif v6.tag == 2: # raise
                v8 = "raises"
            del v6
            v9 = f'Player {v7} {v8}.'
            del v7; del v8
            v0.append(v9)
            del v9
            return v5 == 0
        elif v3.tag == 1: # observation_
            v11 = (<US0_1>v3).v0
            if v11.tag == 0: # jack
                v12 = "Jack"
            elif v11.tag == 1: # king
                v12 = "King"
            elif v11.tag == 2: # queen
                v12 = "Queen"
            del v11
            v13 = f'Observed {v12}.'
            del v12
            v0.append(v13)
            del v13
            return 1
    elif v1.tag == 1: # nil
        return v2
cdef str method27(unsigned char v0, US4 v1, UH0 v2):
    cdef list v3
    cdef bint v4
    cdef bint v5
    cdef double v6
    cdef bint v7
    cdef str v8
    cdef bint v9
    cdef str v16
    cdef bint v11
    cdef double v13
    v3 = []
    v4 = 1
    v5 = method28(v3, v2, v4)
    if v1.tag == 0: # none
        pass
    elif v1.tag == 1: # some_
        v6 = (<US4_1>v1).v0
        v7 = v0 == 0
        if v7:
            v8 = "One"
        else:
            v8 = "Two"
        v9 = 0.000000 < v6
        if v9:
            v16 = f"Player {v8} wins {v6} chips.\n"
        else:
            v11 = 0.000000 == v6
            if v11:
                v16 = f"Player {v8} draws.\n"
            else:
                v13 =  -v6
                v16 = f"Player {v8} loses {v13} chips.\n"
        del v8
        v3.append(v16)
        del v16
    return "\n".join(v3)
cdef void method29(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, Mut0 v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US1 v7
    cdef object v8
    cdef object v9
    cdef object v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        if v7.tag == 0: # call
            v8 = Closure6(v2, v7)
            v3.v0 = v8
            del v8
        elif v7.tag == 1: # fold
            v9 = Closure7(v2, v7)
            v3.v1 = v9
            del v9
        elif v7.tag == 2: # raise
            v10 = Closure8(v2, v7)
            v3.v2 = v10
            del v10
        del v7
        method29(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method26(v0, v1, numpy.ndarray[object,ndim=1] v2, UH0 v3, US4 v4, US3 v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10, signed long v11):
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
    cdef US2 v25
    v12 = method27(v10, v4, v3)
    v13 = False
    v14 = False
    v15 = False
    v16 = Mut0(v14, v13, v15)
    del v13; del v14; del v15
    v17 = len(v2)
    v18 = 0
    method29(v17, v2, v1, v16, v18)
    v19 = v16.v1
    v20 = v16.v0
    v21 = v16.v2
    del v16
    v22 = {'fold': v19, 'call': v20, 'raise': v21}
    del v22
    if v9.tag == 0: # jack
        v23 = 'J'
    elif v9.tag == 1: # king
        v23 = 'K'
    elif v9.tag == 2: # queen
        v23 = 'Q'
    if v6.tag == 0: # jack
        v24 = 'J'
    elif v6.tag == 1: # king
        v24 = 'K'
    elif v6.tag == 2: # queen
        v24 = 'Q'
    if v5.tag == 0: # none
        v27 = ' '
    elif v5.tag == 1: # some_
        v25 = (<US3_1>v5).v0
        if v25.tag == 0: # jack
            v27 = 'J'
        elif v25.tag == 1: # king
            v27 = 'K'
        elif v25.tag == 2: # queen
            v27 = 'Q'
        del v25
    v0.trace = v12
    del v12
    v0.actions = {'fold': v19, 'call': v20, 'raise': v21}
    del v19; del v20; del v21
    v0.table_data = {'my_card': v23, 'my_pot': v11, 'op_card': v24, 'op_pot': v8, 'community_card': v27}
cdef object method25(v0, v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7):
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
cdef object method30(v0, v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7):
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
cdef object method31(v0, v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, signed long v8):
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
cdef numpy.ndarray[object,ndim=1] method33(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef object method34(v0, v1, US3 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, signed long v8):
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
cdef object method32(v0, v1, Heap0 v2, signed long v3, US2 v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9, signed long v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method33(v2, v5, v6, v7, v8, v9, v10, v3)
    return Closure9(v0, v1, v8, v9, v10, v5, v6, v7, v4, v11, v2, v3)
cdef void method35(v0, v1, numpy.ndarray[object,ndim=1] v2, UH0 v3, US4 v4, US3 v5, US2 v6, unsigned char v7, signed long v8, US2 v9, unsigned char v10):
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
    cdef US2 v24
    v11 = method27(v10, v4, v3)
    v12 = False
    v13 = False
    v14 = False
    v15 = Mut0(v13, v12, v14)
    del v12; del v13; del v14
    v16 = len(v2)
    v17 = 0
    method29(v16, v2, v1, v15, v17)
    v18 = v15.v1
    v19 = v15.v0
    v20 = v15.v2
    del v15
    v21 = {'fold': v18, 'call': v19, 'raise': v20}
    del v21
    if v9.tag == 0: # jack
        v22 = 'J'
    elif v9.tag == 1: # king
        v22 = 'K'
    elif v9.tag == 2: # queen
        v22 = 'Q'
    if v6.tag == 0: # jack
        v23 = 'J'
    elif v6.tag == 1: # king
        v23 = 'K'
    elif v6.tag == 2: # queen
        v23 = 'Q'
    if v5.tag == 0: # none
        v26 = ' '
    elif v5.tag == 1: # some_
        v24 = (<US3_1>v5).v0
        if v24.tag == 0: # jack
            v26 = 'J'
        elif v24.tag == 1: # king
            v26 = 'K'
        elif v24.tag == 2: # queen
            v26 = 'Q'
        del v24
    v0.trace = v11
    del v11
    v0.actions = {'fold': v18, 'call': v19, 'raise': v20}
    del v18; del v19; del v20
    v0.table_data = {'my_card': v22, 'my_pot': v8, 'op_card': v23, 'op_pot': v8, 'community_card': v26}
cdef object method22(v0, v1, Heap0 v2, signed long v3, US2 v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method20(v2, v5, v6, v7, v8, v9, v3)
    return Closure3(v0, v1, v8, v9, v7, v5, v6, v4, v10, v2, v3)
cdef object method21(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8):
    cdef unsigned long long v9
    cdef unsigned long long v10
    v9 = len(v3)
    v10 = numpy.random.randint(0,v9)
    return Closure2(v10, v3, v0, v1, v2, v4, v5, v6, v7, v8)
cdef object method37(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9):
    cdef unsigned long long v10
    cdef unsigned long long v11
    v10 = len(v3)
    v11 = numpy.random.randint(0,v10)
    return Closure15(v11, v3, v0, v1, v2, v4, v5, v6, v7, v8, v9)
cdef object method36(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9, signed long v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method33(v2, v5, v6, v7, v8, v9, v10, v4)
    return Closure13(v0, v1, v8, v9, v10, v5, v6, v7, v11, v2, v3, v4)
cdef object method19(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US2 v5, unsigned char v6, signed long v7, US2 v8, unsigned char v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method20(v2, v5, v6, v7, v8, v9, v4)
    return Closure1(v0, v1, v8, v9, v7, v5, v6, v10, v2, v3, v4)
cpdef void main():
    cdef object v0
    cdef object v1
    cdef UH0 v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef object v6
    pass # import ui_leduc
    v0 = ui_leduc.root
    pass # import nets
    v1 = nets.small(30,64,3)
    v2 = UH0_1()
    v3 = 0.000000
    v4 = UH0_1()
    v5 = 0.000000
    v6 = Closure0(v1, v2, v3, v0, v4, v5)
    del v0; del v1; del v2; del v4
    ui_leduc.start_game(v6)
