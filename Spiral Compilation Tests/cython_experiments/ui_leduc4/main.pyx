import ui_leduc
import nets
import numpy
cimport numpy
cimport libc.math
import torch
import torch.nn.functional
import torch.distributions
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise
    def __init__(self): self.tag = 2
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # jack
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # king
    def __init__(self): self.tag = 1
cdef class US1_2(US1): # queen
    def __init__(self): self.tag = 2
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
        return v0
cdef class Tuple0:
    cdef readonly UH0 v0
    cdef readonly double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
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
cdef class Tuple1:
    cdef readonly US1 v0
    cdef readonly object v1
    def __init__(self, US1 v0, v1): self.v0 = v0; self.v1 = v1
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
cdef class Closure5():
    cdef object v0
    cdef unsigned long v1
    cdef unsigned char v2
    def __init__(self, v0, unsigned long v1, unsigned char v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef unsigned long v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef UH0 v3 = args.v0
        cdef double v4 = args.v1
        cdef UH0 v5 = args.v2
        cdef double v6 = args.v3
        cdef object v7 = args.v4
        cdef double v8
        cdef bint v9
        cdef double v11
        cdef double v12
        cdef double v13
        cdef double v14
        v8 = <double>v1
        v9 = v2 == 0
        if v9:
            v11 = v8
        else:
            v11 =  -v8
        v12 = libc.math.exp(v6)
        v13 =  -v11
        v14 = libc.math.exp(v4)
        return v7(v11)
cdef class Closure6():
    cdef object v0
    cdef unsigned char v1
    def __init__(self, v0, unsigned char v1): self.v0 = v0; self.v1 = v1
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef UH0 v2 = args.v0
        cdef double v3 = args.v1
        cdef UH0 v4 = args.v2
        cdef double v5 = args.v3
        cdef object v6 = args.v4
        cdef double v7
        cdef bint v8
        cdef double v10
        cdef double v11
        cdef double v12
        cdef double v13
        v7 = <double>0
        v8 = v1 == 0
        if v8:
            v10 = v7
        else:
            v10 =  -v7
        v11 = libc.math.exp(v5)
        v12 =  -v10
        v13 = libc.math.exp(v3)
        return v6(v10)
cdef class Closure7():
    cdef object v0
    cdef unsigned char v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef signed long v5
    cdef US1 v6
    cdef US1 v7
    cdef unsigned char v8
    cdef unsigned long v9
    cdef US1 v10
    cdef unsigned long v11
    def __init__(self, v0, unsigned char v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US1 v6, US1 v7, unsigned char v8, unsigned long v9, US1 v10, unsigned long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US1 v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned long v11 = self.v11
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
        cdef US0 v39
        cdef object v81
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
        cdef bint v72
        cdef signed long v78
        cdef unsigned long v79
        cdef double v82
        cdef US2 v83
        cdef UH0 v84
        cdef US2 v85
        cdef UH0 v86
        cdef US0 v88
        cdef unsigned long long v89
        cdef double v90
        cdef double v91
        cdef double v92
        cdef object v134
        cdef signed long v93
        cdef signed long v94
        cdef signed long v95
        cdef signed long v96
        cdef bint v97
        cdef bint v99
        cdef signed long v122
        cdef bint v100
        cdef bint v101
        cdef bint v104
        cdef bint v105
        cdef signed long v106
        cdef signed long v107
        cdef Tuple3 tmp9
        cdef signed long v108
        cdef signed long v109
        cdef Tuple3 tmp10
        cdef bint v110
        cdef signed long v113
        cdef bint v111
        cdef bint v114
        cdef bint v115
        cdef bint v116
        cdef bint v123
        cdef bint v125
        cdef signed long v131
        cdef unsigned long v132
        cdef double v135
        cdef US2 v136
        cdef UH0 v137
        cdef US2 v138
        cdef UH0 v139
        v17 = v1 == 0
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
            v26 = v0.forward(v25)
            del v25
            v27 = len(v2)
            v28 = numpy.empty(v27,dtype=numpy.int64)
            v29 = 0
            method16(v27, v2, v28, v29)
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
                if v10.tag == 0: # jack
                    v40 = 0
                elif v10.tag == 1: # king
                    v40 = 2
                elif v10.tag == 2: # queen
                    v40 = 1
                if v6.tag == 0: # jack
                    v41 = 0
                elif v6.tag == 1: # king
                    v41 = 2
                elif v6.tag == 2: # queen
                    v41 = 1
                if v7.tag == 0: # jack
                    v42 = 0
                elif v7.tag == 1: # king
                    v42 = 2
                elif v7.tag == 2: # queen
                    v42 = 1
                if v6.tag == 0: # jack
                    v43 = 0
                elif v6.tag == 1: # king
                    v43 = 2
                elif v6.tag == 2: # queen
                    v43 = 1
                v44 = method22(v41, v40)
                if v44:
                    v46 = method22(v43, v42)
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
                    v51 = method22(v41, v40)
                    if v51:
                        v69 = 1
                    else:
                        v52 = method22(v43, v42)
                        if v52:
                            v69 = -1
                        else:
                            tmp7 = method23(v41, v40)
                            v53, v54 = tmp7.v0, tmp7.v1
                            del tmp7
                            tmp8 = method23(v43, v42)
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
                    v81 = Closure5(v0, v9, v1)
                else:
                    v72 = v69 == -1
                    if v72:
                        v81 = Closure5(v0, v9, v8)
                    else:
                        v81 = Closure6(v0, v1)
            elif v39.tag == 1: # fold
                v81 = Closure5(v0, v11, v8)
            elif v39.tag == 2: # raise
                v78 = v5 - 1
                v79 = v9 + 4
                v81 = method24(v0, v3, v4, v78, v6, v10, v1, v79, v7, v8, v9)
            v82 = v35 + v13
            v83 = US2_0(v39)
            v84 = UH0_0(v83, v12)
            del v83
            v85 = US2_0(v39)
            del v39
            v86 = UH0_0(v85, v14)
            del v85
            return v81(Tuple2(v84, v82, v86, v15, v16))
        else:
            v88 = numpy.random.choice(v2)
            v89 = len(v2)
            v90 = <double>v89
            v91 = 1.000000 / v90
            v92 = libc.math.log(v91)
            if v88.tag == 0: # call
                if v10.tag == 0: # jack
                    v93 = 0
                elif v10.tag == 1: # king
                    v93 = 2
                elif v10.tag == 2: # queen
                    v93 = 1
                if v6.tag == 0: # jack
                    v94 = 0
                elif v6.tag == 1: # king
                    v94 = 2
                elif v6.tag == 2: # queen
                    v94 = 1
                if v7.tag == 0: # jack
                    v95 = 0
                elif v7.tag == 1: # king
                    v95 = 2
                elif v7.tag == 2: # queen
                    v95 = 1
                if v6.tag == 0: # jack
                    v96 = 0
                elif v6.tag == 1: # king
                    v96 = 2
                elif v6.tag == 2: # queen
                    v96 = 1
                v97 = method22(v94, v93)
                if v97:
                    v99 = method22(v96, v95)
                else:
                    v99 = 0
                if v99:
                    v100 = v93 < v95
                    if v100:
                        v122 = -1
                    else:
                        v101 = v93 > v95
                        if v101:
                            v122 = 1
                        else:
                            v122 = 0
                else:
                    v104 = method22(v94, v93)
                    if v104:
                        v122 = 1
                    else:
                        v105 = method22(v96, v95)
                        if v105:
                            v122 = -1
                        else:
                            tmp9 = method23(v94, v93)
                            v106, v107 = tmp9.v0, tmp9.v1
                            del tmp9
                            tmp10 = method23(v96, v95)
                            v108, v109 = tmp10.v0, tmp10.v1
                            del tmp10
                            v110 = v106 < v108
                            if v110:
                                v113 = -1
                            else:
                                v111 = v106 > v108
                                if v111:
                                    v113 = 1
                                else:
                                    v113 = 0
                            v114 = v113 == 0
                            if v114:
                                v115 = v107 < v109
                                if v115:
                                    v122 = -1
                                else:
                                    v116 = v107 > v109
                                    if v116:
                                        v122 = 1
                                    else:
                                        v122 = 0
                            else:
                                v122 = v113
                v123 = v122 == 1
                if v123:
                    v134 = Closure5(v0, v9, v1)
                else:
                    v125 = v122 == -1
                    if v125:
                        v134 = Closure5(v0, v9, v8)
                    else:
                        v134 = Closure6(v0, v1)
            elif v88.tag == 1: # fold
                v134 = Closure5(v0, v11, v8)
            elif v88.tag == 2: # raise
                v131 = v5 - 1
                v132 = v9 + 4
                v134 = method24(v0, v3, v4, v131, v6, v10, v1, v132, v7, v8, v9)
            v135 = v92 + v15
            v136 = US2_0(v88)
            v137 = UH0_0(v136, v12)
            del v136
            v138 = US2_0(v88)
            del v88
            v139 = UH0_0(v138, v14)
            del v138
            return v134(Tuple2(v137, v13, v139, v135, v16))
cdef class Closure4():
    cdef object v0
    cdef unsigned char v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef signed long v5
    cdef US1 v6
    cdef US1 v7
    cdef unsigned char v8
    cdef unsigned long v9
    cdef US1 v10
    def __init__(self, v0, unsigned char v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US1 v6, US1 v7, unsigned char v8, unsigned long v9, US1 v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US1 v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v10 = self.v10
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
        cdef US0 v38
        cdef object v80
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
        cdef bint v71
        cdef signed long v77
        cdef unsigned long v78
        cdef double v81
        cdef US2 v82
        cdef UH0 v83
        cdef US2 v84
        cdef UH0 v85
        cdef US0 v87
        cdef unsigned long long v88
        cdef double v89
        cdef double v90
        cdef double v91
        cdef object v133
        cdef signed long v92
        cdef signed long v93
        cdef signed long v94
        cdef signed long v95
        cdef bint v96
        cdef bint v98
        cdef signed long v121
        cdef bint v99
        cdef bint v100
        cdef bint v103
        cdef bint v104
        cdef signed long v105
        cdef signed long v106
        cdef Tuple3 tmp11
        cdef signed long v107
        cdef signed long v108
        cdef Tuple3 tmp12
        cdef bint v109
        cdef signed long v112
        cdef bint v110
        cdef bint v113
        cdef bint v114
        cdef bint v115
        cdef bint v122
        cdef bint v124
        cdef signed long v130
        cdef unsigned long v131
        cdef double v134
        cdef US2 v135
        cdef UH0 v136
        cdef US2 v137
        cdef UH0 v138
        v16 = v1 == 0
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
            v25 = v0.forward(v24)
            del v24
            v26 = len(v2)
            v27 = numpy.empty(v26,dtype=numpy.int64)
            v28 = 0
            method16(v26, v2, v27, v28)
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
                if v10.tag == 0: # jack
                    v39 = 0
                elif v10.tag == 1: # king
                    v39 = 2
                elif v10.tag == 2: # queen
                    v39 = 1
                if v6.tag == 0: # jack
                    v40 = 0
                elif v6.tag == 1: # king
                    v40 = 2
                elif v6.tag == 2: # queen
                    v40 = 1
                if v7.tag == 0: # jack
                    v41 = 0
                elif v7.tag == 1: # king
                    v41 = 2
                elif v7.tag == 2: # queen
                    v41 = 1
                if v6.tag == 0: # jack
                    v42 = 0
                elif v6.tag == 1: # king
                    v42 = 2
                elif v6.tag == 2: # queen
                    v42 = 1
                v43 = method22(v40, v39)
                if v43:
                    v45 = method22(v42, v41)
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
                    v50 = method22(v40, v39)
                    if v50:
                        v68 = 1
                    else:
                        v51 = method22(v42, v41)
                        if v51:
                            v68 = -1
                        else:
                            tmp5 = method23(v40, v39)
                            v52, v53 = tmp5.v0, tmp5.v1
                            del tmp5
                            tmp6 = method23(v42, v41)
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
                    v80 = Closure5(v0, v9, v1)
                else:
                    v71 = v68 == -1
                    if v71:
                        v80 = Closure5(v0, v9, v8)
                    else:
                        v80 = Closure6(v0, v1)
            elif v38.tag == 1: # fold
                v80 = Closure5(v0, v9, v8)
            elif v38.tag == 2: # raise
                v77 = v5 - 1
                v78 = v9 + 4
                v80 = method24(v0, v3, v4, v77, v6, v10, v1, v78, v7, v8, v9)
            v81 = v34 + v12
            v82 = US2_0(v38)
            v83 = UH0_0(v82, v11)
            del v82
            v84 = US2_0(v38)
            del v38
            v85 = UH0_0(v84, v13)
            del v84
            return v80(Tuple2(v83, v81, v85, v14, v15))
        else:
            v87 = numpy.random.choice(v2)
            v88 = len(v2)
            v89 = <double>v88
            v90 = 1.000000 / v89
            v91 = libc.math.log(v90)
            if v87.tag == 0: # call
                if v10.tag == 0: # jack
                    v92 = 0
                elif v10.tag == 1: # king
                    v92 = 2
                elif v10.tag == 2: # queen
                    v92 = 1
                if v6.tag == 0: # jack
                    v93 = 0
                elif v6.tag == 1: # king
                    v93 = 2
                elif v6.tag == 2: # queen
                    v93 = 1
                if v7.tag == 0: # jack
                    v94 = 0
                elif v7.tag == 1: # king
                    v94 = 2
                elif v7.tag == 2: # queen
                    v94 = 1
                if v6.tag == 0: # jack
                    v95 = 0
                elif v6.tag == 1: # king
                    v95 = 2
                elif v6.tag == 2: # queen
                    v95 = 1
                v96 = method22(v93, v92)
                if v96:
                    v98 = method22(v95, v94)
                else:
                    v98 = 0
                if v98:
                    v99 = v92 < v94
                    if v99:
                        v121 = -1
                    else:
                        v100 = v92 > v94
                        if v100:
                            v121 = 1
                        else:
                            v121 = 0
                else:
                    v103 = method22(v93, v92)
                    if v103:
                        v121 = 1
                    else:
                        v104 = method22(v95, v94)
                        if v104:
                            v121 = -1
                        else:
                            tmp11 = method23(v93, v92)
                            v105, v106 = tmp11.v0, tmp11.v1
                            del tmp11
                            tmp12 = method23(v95, v94)
                            v107, v108 = tmp12.v0, tmp12.v1
                            del tmp12
                            v109 = v105 < v107
                            if v109:
                                v112 = -1
                            else:
                                v110 = v105 > v107
                                if v110:
                                    v112 = 1
                                else:
                                    v112 = 0
                            v113 = v112 == 0
                            if v113:
                                v114 = v106 < v108
                                if v114:
                                    v121 = -1
                                else:
                                    v115 = v106 > v108
                                    if v115:
                                        v121 = 1
                                    else:
                                        v121 = 0
                            else:
                                v121 = v112
                v122 = v121 == 1
                if v122:
                    v133 = Closure5(v0, v9, v1)
                else:
                    v124 = v121 == -1
                    if v124:
                        v133 = Closure5(v0, v9, v8)
                    else:
                        v133 = Closure6(v0, v1)
            elif v87.tag == 1: # fold
                v133 = Closure5(v0, v9, v8)
            elif v87.tag == 2: # raise
                v130 = v5 - 1
                v131 = v9 + 4
                v133 = method24(v0, v3, v4, v130, v6, v10, v1, v131, v7, v8, v9)
            v134 = v91 + v14
            v135 = US2_0(v87)
            v136 = UH0_0(v135, v11)
            del v135
            v137 = US2_0(v87)
            del v87
            v138 = UH0_0(v137, v13)
            del v137
            return v133(Tuple2(v136, v12, v138, v134, v15))
cdef class Closure3():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef US1 v6
    cdef unsigned char v7
    cdef unsigned long v8
    cdef US1 v9
    cdef unsigned char v10
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9, unsigned char v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef UH0 v11 = args.v0
        cdef double v12 = args.v1
        cdef UH0 v13 = args.v2
        cdef double v14 = args.v3
        cdef object v15 = args.v4
        cdef US1 v16
        cdef unsigned long long v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef bint v23
        cdef US2 v24
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
        cdef US0 v47
        cdef object v54
        cdef signed long v48
        cdef signed long v51
        cdef unsigned long v52
        cdef double v55
        cdef US2 v56
        cdef US2 v57
        cdef UH0 v58
        cdef UH0 v59
        cdef US2 v60
        cdef US2 v61
        cdef UH0 v62
        cdef UH0 v63
        cdef US0 v65
        cdef unsigned long long v66
        cdef double v67
        cdef double v68
        cdef double v69
        cdef object v76
        cdef signed long v70
        cdef signed long v73
        cdef unsigned long v74
        cdef double v77
        cdef US2 v78
        cdef US2 v79
        cdef UH0 v80
        cdef UH0 v81
        cdef US2 v82
        cdef US2 v83
        cdef UH0 v84
        cdef UH0 v85
        v16 = v1[v0]
        v17 = len(v1)
        v18 = <double>v17
        v19 = 1.000000 / v18
        v20 = libc.math.log(v19)
        v21 = v20 + v12
        v22 = v20 + v14
        v23 = v10 == 0
        if v23:
            v24 = US2_1(v16)
            v25 = UH0_0(v24, v11)
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
            v34 = v2.forward(v33)
            del v33
            v35 = len(v3)
            v36 = numpy.empty(v35,dtype=numpy.int64)
            v37 = 0
            method16(v35, v3, v36, v37)
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
                v54 = method21(v2, v4, v5, v48, v16, v9, v10, v8, v6, v7)
            elif v47.tag == 1: # fold
                raise Exception("impossible")
            elif v47.tag == 2: # raise
                v51 = 1
                v52 = v8 + 4
                v54 = method24(v2, v4, v5, v51, v16, v9, v10, v52, v6, v7, v8)
            v55 = v43 + v21
            v56 = US2_0(v47)
            v57 = US2_1(v16)
            v58 = UH0_0(v57, v11)
            del v57
            v59 = UH0_0(v56, v58)
            del v56; del v58
            v60 = US2_0(v47)
            del v47
            v61 = US2_1(v16)
            v62 = UH0_0(v61, v13)
            del v61
            v63 = UH0_0(v60, v62)
            del v60; del v62
            return v54(Tuple2(v59, v55, v63, v22, v15))
        else:
            v65 = numpy.random.choice(v3)
            v66 = len(v3)
            v67 = <double>v66
            v68 = 1.000000 / v67
            v69 = libc.math.log(v68)
            if v65.tag == 0: # call
                v70 = 2
                v76 = method21(v2, v4, v5, v70, v16, v9, v10, v8, v6, v7)
            elif v65.tag == 1: # fold
                raise Exception("impossible")
            elif v65.tag == 2: # raise
                v73 = 1
                v74 = v8 + 4
                v76 = method24(v2, v4, v5, v73, v16, v9, v10, v74, v6, v7, v8)
            v77 = v69 + v22
            v78 = US2_0(v65)
            v79 = US2_1(v16)
            v80 = UH0_0(v79, v11)
            del v79
            v81 = UH0_0(v78, v80)
            del v78; del v80
            v82 = US2_0(v65)
            del v65
            v83 = US2_1(v16)
            v84 = UH0_0(v83, v13)
            del v83
            v85 = UH0_0(v82, v84)
            del v82; del v84
            return v76(Tuple2(v81, v21, v85, v77, v15))
cdef class Closure8():
    cdef object v0
    cdef unsigned char v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef unsigned long v10
    cdef US1 v11
    cdef unsigned long v12
    def __init__(self, v0, unsigned char v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, unsigned long v10, US1 v11, unsigned long v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef unsigned long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned long v12 = self.v12
        cdef UH0 v13 = args.v0
        cdef double v14 = args.v1
        cdef UH0 v15 = args.v2
        cdef double v16 = args.v3
        cdef object v17 = args.v4
        cdef bint v18
        cdef numpy.ndarray[object,ndim=1] v19
        cdef numpy.ndarray[float,ndim=1] v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef bint v24
        cdef unsigned long long v25
        cdef object v26
        cdef object v27
        cdef unsigned long long v28
        cdef numpy.ndarray[signed long long,ndim=1] v29
        cdef unsigned long long v30
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
        cdef object v46
        cdef signed long v43
        cdef unsigned long v44
        cdef double v47
        cdef US2 v48
        cdef UH0 v49
        cdef US2 v50
        cdef UH0 v51
        cdef US0 v53
        cdef unsigned long long v54
        cdef double v55
        cdef double v56
        cdef double v57
        cdef object v63
        cdef signed long v60
        cdef unsigned long v61
        cdef double v64
        cdef US2 v65
        cdef UH0 v66
        cdef US2 v67
        cdef UH0 v68
        v18 = v1 == 0
        if v18:
            v19 = method3(v13)
            v20 = numpy.empty(30,dtype=numpy.float32)
            v21 = len(v20)
            v22 = 0
            method13(v21, v20, v22)
            v23 = len(v19)
            v24 = 2 < v23
            if v24:
                raise Exception("The given array is too large.")
            else:
                pass
            v25 = 0
            method14(v23, v20, v19, v25)
            del v19
            pass # import torch
            v26 = torch.from_numpy(v20)
            del v20
            v27 = v0.forward(v26)
            del v26
            v28 = len(v2)
            v29 = numpy.empty(v28,dtype=numpy.int64)
            v30 = 0
            method16(v28, v2, v29, v30)
            v31 = v27[v29]
            del v27
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
            v39 = v29[v38]
            del v29
            v40 = method18(v39)
            if v40.tag == 0: # call
                v46 = method20(v0, v5, v3, v4, v6, v8, v9, v10, v11, v1)
            elif v40.tag == 1: # fold
                v46 = Closure5(v0, v12, v9)
            elif v40.tag == 2: # raise
                v43 = v7 - 1
                v44 = v10 + 2
                v46 = method25(v0, v3, v4, v5, v6, v43, v11, v1, v44, v8, v9, v10)
            v47 = v36 + v14
            v48 = US2_0(v40)
            v49 = UH0_0(v48, v13)
            del v48
            v50 = US2_0(v40)
            del v40
            v51 = UH0_0(v50, v15)
            del v50
            return v46(Tuple2(v49, v47, v51, v16, v17))
        else:
            v53 = numpy.random.choice(v2)
            v54 = len(v2)
            v55 = <double>v54
            v56 = 1.000000 / v55
            v57 = libc.math.log(v56)
            if v53.tag == 0: # call
                v63 = method20(v0, v5, v3, v4, v6, v11, v1, v10, v8, v9)
            elif v53.tag == 1: # fold
                v63 = Closure5(v0, v12, v9)
            elif v53.tag == 2: # raise
                v60 = v7 - 1
                v61 = v10 + 2
                v63 = method25(v0, v3, v4, v5, v6, v60, v11, v1, v61, v8, v9, v10)
            v64 = v57 + v16
            v65 = US2_0(v53)
            v66 = UH0_0(v65, v13)
            del v65
            v67 = US2_0(v53)
            del v53
            v68 = UH0_0(v67, v15)
            del v67
            return v63(Tuple2(v66, v14, v68, v64, v17))
cdef class Closure2():
    cdef object v0
    cdef unsigned char v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef unsigned long v10
    cdef US1 v11
    def __init__(self, v0, unsigned char v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, unsigned long v10, US1 v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef unsigned long v10 = self.v10
        cdef US1 v11 = self.v11
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
        cdef US0 v39
        cdef object v45
        cdef signed long v42
        cdef unsigned long v43
        cdef double v46
        cdef US2 v47
        cdef UH0 v48
        cdef US2 v49
        cdef UH0 v50
        cdef US0 v52
        cdef unsigned long long v53
        cdef double v54
        cdef double v55
        cdef double v56
        cdef object v62
        cdef signed long v59
        cdef unsigned long v60
        cdef double v63
        cdef US2 v64
        cdef UH0 v65
        cdef US2 v66
        cdef UH0 v67
        v17 = v1 == 0
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
            v26 = v0.forward(v25)
            del v25
            v27 = len(v2)
            v28 = numpy.empty(v27,dtype=numpy.int64)
            v29 = 0
            method16(v27, v2, v28, v29)
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
                v45 = method20(v0, v5, v3, v4, v6, v8, v9, v10, v11, v1)
            elif v39.tag == 1: # fold
                v45 = Closure5(v0, v10, v9)
            elif v39.tag == 2: # raise
                v42 = v7 - 1
                v43 = v10 + 2
                v45 = method25(v0, v3, v4, v5, v6, v42, v11, v1, v43, v8, v9, v10)
            v46 = v35 + v13
            v47 = US2_0(v39)
            v48 = UH0_0(v47, v12)
            del v47
            v49 = US2_0(v39)
            del v39
            v50 = UH0_0(v49, v14)
            del v49
            return v45(Tuple2(v48, v46, v50, v15, v16))
        else:
            v52 = numpy.random.choice(v2)
            v53 = len(v2)
            v54 = <double>v53
            v55 = 1.000000 / v54
            v56 = libc.math.log(v55)
            if v52.tag == 0: # call
                v62 = method20(v0, v5, v3, v4, v6, v11, v1, v10, v8, v9)
            elif v52.tag == 1: # fold
                v62 = Closure5(v0, v10, v9)
            elif v52.tag == 2: # raise
                v59 = v7 - 1
                v60 = v10 + 2
                v62 = method25(v0, v3, v4, v5, v6, v59, v11, v1, v60, v8, v9, v10)
            v63 = v56 + v15
            v64 = US2_0(v52)
            v65 = UH0_0(v64, v12)
            del v64
            v66 = US2_0(v52)
            del v52
            v67 = UH0_0(v66, v14)
            del v66
            return v62(Tuple2(v65, v13, v67, v63, v16))
cdef class Closure0():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2
        cdef US0 v3
        cdef numpy.ndarray[object,ndim=1] v4
        cdef US0 v5
        cdef US0 v6
        cdef US0 v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef US0 v9
        cdef US0 v10
        cdef numpy.ndarray[object,ndim=1] v11
        cdef US1 v12
        cdef US1 v13
        cdef US1 v14
        cdef US1 v15
        cdef US1 v16
        cdef US1 v17
        cdef numpy.ndarray[object,ndim=1] v18
        cdef unsigned long long v19
        cdef unsigned long long v20
        cdef UH0 v21
        cdef double v22
        cdef UH0 v23
        cdef double v24
        cdef object v25
        cdef US1 v26
        cdef unsigned long long v27
        cdef numpy.ndarray[object,ndim=1] v28
        cdef unsigned long long v29
        cdef double v30
        cdef double v31
        cdef double v32
        cdef unsigned char v33
        cdef UH0 v34
        cdef double v35
        cdef Tuple0 tmp0
        cdef unsigned char v36
        cdef UH0 v37
        cdef double v38
        cdef Tuple0 tmp1
        cdef unsigned long long v39
        cdef unsigned long long v40
        cdef US1 v41
        cdef unsigned long long v42
        cdef numpy.ndarray[object,ndim=1] v43
        cdef unsigned long long v44
        cdef double v45
        cdef double v46
        cdef double v47
        cdef unsigned char v48
        cdef UH0 v49
        cdef double v50
        cdef Tuple0 tmp2
        cdef unsigned char v51
        cdef UH0 v52
        cdef double v53
        cdef Tuple0 tmp3
        cdef numpy.ndarray[object,ndim=1] v54
        cdef numpy.ndarray[float,ndim=1] v55
        cdef unsigned long long v56
        cdef unsigned long long v57
        cdef unsigned long long v58
        cdef bint v59
        cdef unsigned long long v60
        cdef object v61
        cdef object v62
        cdef unsigned long long v63
        cdef numpy.ndarray[signed long long,ndim=1] v64
        cdef unsigned long long v65
        cdef object v66
        cdef object v67
        cdef object v68
        cdef object v69
        cdef object v70
        cdef double v71
        cdef signed long long v72
        cdef unsigned long long v73
        cdef signed long long v74
        cdef US0 v75
        cdef object v88
        cdef signed long v76
        cdef unsigned char v77
        cdef unsigned long v78
        cdef unsigned char v79
        cdef signed long v82
        cdef unsigned char v83
        cdef unsigned long v84
        cdef unsigned char v85
        cdef unsigned long v86
        cdef double v89
        cdef US2 v90
        cdef UH0 v91
        cdef US2 v92
        cdef UH0 v93
        cdef double v94
        v2 = US0_0()
        v3 = US0_2()
        v4 = numpy.empty(2,dtype=object)
        v4[0] = v2; v4[1] = v3
        del v2; del v3
        v5 = US0_1()
        v6 = US0_0()
        v7 = US0_2()
        v8 = numpy.empty(3,dtype=object)
        v8[0] = v5; v8[1] = v6; v8[2] = v7
        del v5; del v6; del v7
        v9 = US0_1()
        v10 = US0_0()
        v11 = numpy.empty(2,dtype=object)
        v11[0] = v9; v11[1] = v10
        del v9; del v10
        v12 = US1_1()
        v13 = US1_2()
        v14 = US1_0()
        v15 = US1_1()
        v16 = US1_2()
        v17 = US1_0()
        v18 = numpy.empty(6,dtype=object)
        v18[0] = v12; v18[1] = v13; v18[2] = v14; v18[3] = v15; v18[4] = v16; v18[5] = v17
        del v12; del v13; del v14; del v15; del v16; del v17
        v19 = len(v18)
        v20 = numpy.random.randint(0,v19)
        v21 = UH0_1()
        v22 = 0.000000
        v23 = UH0_1()
        v24 = 0.000000
        v25 = Closure1()
        v26 = v18[v20]
        v27 = v19 - 1
        v28 = numpy.empty(v27,dtype=object)
        v29 = 0
        method0(v27, v20, v18, v28, v29)
        del v18
        v30 = <double>v19
        v31 = 1.000000 / v30
        v32 = libc.math.log(v31)
        v33 = 0
        tmp0 = method1(v26, v32, v33, v21, v22)
        v34, v35 = tmp0.v0, tmp0.v1
        del tmp0
        del v21
        v36 = 1
        tmp1 = method1(v26, v32, v36, v23, v24)
        v37, v38 = tmp1.v0, tmp1.v1
        del tmp1
        del v23
        v39 = len(v28)
        v40 = numpy.random.randint(0,v39)
        v41 = v28[v40]
        v42 = v39 - 1
        v43 = numpy.empty(v42,dtype=object)
        v44 = 0
        method0(v42, v40, v28, v43, v44)
        del v28
        v45 = <double>v39
        v46 = 1.000000 / v45
        v47 = libc.math.log(v46)
        v48 = 0
        tmp2 = method2(v41, v47, v48, v34, v35)
        v49, v50 = tmp2.v0, tmp2.v1
        del tmp2
        del v34
        v51 = 1
        tmp3 = method2(v41, v47, v51, v37, v38)
        v52, v53 = tmp3.v0, tmp3.v1
        del tmp3
        del v37
        v54 = method3(v49)
        v55 = numpy.empty(30,dtype=numpy.float32)
        v56 = len(v55)
        v57 = 0
        method13(v56, v55, v57)
        v58 = len(v54)
        v59 = 2 < v58
        if v59:
            raise Exception("The given array is too large.")
        else:
            pass
        v60 = 0
        method14(v58, v55, v54, v60)
        del v54
        pass # import torch
        v61 = torch.from_numpy(v55)
        del v55
        v62 = v0.forward(v61)
        del v61
        v63 = len(v4)
        v64 = numpy.empty(v63,dtype=numpy.int64)
        v65 = 0
        method16(v63, v4, v64, v65)
        v66 = v62[v64]
        del v62
        pass # import torch.nn.functional
        v67 = torch.nn.functional.softmax(v66,-1)
        del v66
        pass # import torch.distributions
        v68 = torch.distributions.Categorical(probs=v67)
        del v67
        v69 = v68.sample()
        v70 = v68.log_prob(v69)
        del v68
        v71 = v70.item()
        del v70
        v72 = v69.item()
        del v69
        v73 = v72
        v74 = v64[v73]
        del v64
        v75 = method18(v74)
        if v75.tag == 0: # call
            v76 = 2
            v77 = 1
            v78 = 1
            v79 = 0
            v88 = method19(v0, v8, v11, v4, v43, v76, v26, v79, v78, v41, v77)
        elif v75.tag == 1: # fold
            raise Exception("impossible")
        elif v75.tag == 2: # raise
            v82 = 1
            v83 = 1
            v84 = 1
            v85 = 0
            v86 = 3
            v88 = method25(v0, v8, v11, v4, v43, v82, v26, v85, v86, v41, v83, v84)
        del v4; del v8; del v11; del v26; del v41; del v43
        v89 = v71 + v50
        v90 = US2_0(v75)
        v91 = UH0_0(v90, v49)
        del v49; del v90
        v92 = US2_0(v75)
        del v75
        v93 = UH0_0(v92, v52)
        del v52; del v92
        v94 = v88(Tuple2(v91, v89, v93, v53, v25))
        del v25; del v88; del v91; del v93
        v1.trace += f"Reward for player one is {v94}.\n"
cdef void method0(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US1 v9
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
cdef Tuple0 method1(US1 v0, double v1, unsigned char v2, UH0 v3, double v4):
    cdef bint v5
    cdef double v6
    cdef US2 v7
    cdef UH0 v8
    v5 = 0 == v2
    if v5:
        v6 = v1 + v4
        v7 = US2_1(v0)
        v8 = UH0_0(v7, v3)
        del v7
        return Tuple0(v8, v6)
    else:
        return Tuple0(v3, v4)
cdef Tuple0 method2(US1 v0, double v1, unsigned char v2, UH0 v3, double v4):
    cdef bint v5
    cdef double v6
    cdef US2 v7
    cdef UH0 v8
    v5 = 1 == v2
    if v5:
        v6 = v1 + v4
        v7 = US2_1(v0)
        v8 = UH0_0(v7, v3)
        del v7
        return Tuple0(v8, v6)
    else:
        return Tuple0(v3, v4)
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
    cdef US0 v3
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
cdef UH2 method5(UH1 v0, US1 v1, UH0 v2):
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef UH1 v6
    cdef US1 v8
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
    cdef US1 v3
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
    cdef US2 v3
    cdef UH0 v4
    cdef US1 v7
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
            v7 = (<US2_1>v3).v0
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
    cdef US0 v7
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
    cdef US1 v6
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
cdef signed long long method17(US0 v0):
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
    cdef US0 v6
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
        return US0_0()
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
            return US0_1()
        else:
            if v1:
                v12 = v0 - 2
                v13 = v12 == 0
                v14 = v13 == 0
                if v14:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                return US0_2()
            else:
                raise Exception("Unpickling of an union failed.")
cdef bint method22(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple3 method23(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple3(v1, v0)
    else:
        return Tuple3(v0, v1)
cdef object method24(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US1 v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9, unsigned long v10):
    cdef bint v11
    cdef numpy.ndarray[object,ndim=1] v12
    v11 = 0 < v3
    if v11:
        v12 = v1
    else:
        v12 = v2
    return Closure7(v0, v9, v12, v1, v2, v3, v4, v5, v6, v7, v8, v10)
cdef object method21(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US1 v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9):
    cdef bint v10
    cdef numpy.ndarray[object,ndim=1] v11
    v10 = 0 < v3
    if v10:
        v11 = v1
    else:
        v11 = v2
    return Closure4(v0, v9, v11, v1, v2, v3, v4, v5, v6, v7, v8)
cdef object method20(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9):
    cdef unsigned long long v10
    cdef unsigned long long v11
    v10 = len(v4)
    v11 = numpy.random.randint(0,v10)
    return Closure3(v11, v4, v0, v1, v2, v3, v5, v6, v7, v8, v9)
cdef object method25(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9, unsigned char v10, unsigned long v11):
    cdef bint v12
    cdef numpy.ndarray[object,ndim=1] v13
    v12 = 0 < v5
    if v12:
        v13 = v1
    else:
        v13 = v2
    return Closure8(v0, v10, v13, v1, v2, v3, v4, v5, v6, v7, v8, v9, v11)
cdef object method19(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9, unsigned char v10):
    cdef bint v11
    cdef numpy.ndarray[object,ndim=1] v12
    v11 = 0 < v5
    if v11:
        v12 = v1
    else:
        v12 = v2
    return Closure2(v0, v10, v12, v1, v2, v3, v4, v5, v6, v7, v8, v9)
cpdef void main():
    cdef object v0
    cdef object v1
    cdef object v2
    pass # import ui_leduc
    pass # import nets
    v0 = nets.small(30,64,3)
    v1 = ui_leduc.root
    v2 = Closure0(v0, v1)
    del v0; del v1
    ui_leduc.start_game(v2)
