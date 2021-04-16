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
cdef class Closure0():
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
    cdef readonly double v0
    cdef readonly UH0 v1
    cdef readonly double v2
    cdef readonly UH0 v3
    cdef readonly double v4
    cdef readonly object v5
    def __init__(self, double v0, UH0 v1, double v2, UH0 v3, double v4, v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
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
    cdef US2 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US3 v7
    cdef double v8
    def __init__(self, v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US3 v7, double v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef US2 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US3 v7 = self.v7
        cdef double v8 = self.v8
        cdef double v9 = args.v0
        cdef UH0 v10 = args.v1
        cdef double v11 = args.v2
        cdef UH0 v12 = args.v3
        cdef double v13 = args.v4
        cdef object v14 = args.v5
        cdef double v15
        v15 =  -v8
        return v14(v8)
cdef class Closure5():
    cdef object v0
    cdef US2 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US2 v7
    cdef object v8
    cdef Heap0 v9
    cdef signed long v10
    def __init__(self, v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US2 v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef US2 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef signed long v10 = self.v10
        cdef double v11 = args.v0
        cdef UH0 v12 = args.v1
        cdef double v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef object v16 = args.v5
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
        cdef US1 v93
        cdef unsigned long long v94
        cdef double v95
        cdef double v96
        cdef double v97
        cdef object v144
        cdef signed long v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef bint v102
        cdef bint v104
        cdef signed long v127
        cdef bint v105
        cdef bint v106
        cdef bint v109
        cdef bint v110
        cdef signed long v111
        cdef signed long v112
        cdef Tuple3 tmp9
        cdef signed long v113
        cdef signed long v114
        cdef Tuple3 tmp10
        cdef bint v115
        cdef signed long v118
        cdef bint v116
        cdef bint v119
        cdef bint v120
        cdef bint v121
        cdef bint v128
        cdef US3 v129
        cdef bint v131
        cdef US3 v132
        cdef US3 v134
        cdef signed long v135
        cdef US3 v139
        cdef signed long v141
        cdef signed long v142
        cdef double v145
        cdef US0 v146
        cdef UH0 v147
        cdef US0 v148
        cdef UH0 v149
        v17 = v2 == 0
        if v17:
            v18 = method4(v12)
            v19 = len(v8)
            v20 = numpy.empty(v19,dtype=numpy.int64)
            v21 = 0
            method14(v19, v8, v20, v21)
            v22 = numpy.empty(30,dtype=numpy.float32)
            v23 = len(v22)
            v24 = 0
            method16(v23, v22, v24)
            v25 = len(v18)
            v26 = 2 < v25
            if v26:
                raise Exception("The given array is too large.")
            else:
                pass
            v27 = 0
            method17(v25, v22, v18, v27)
            del v18
            pass # import torch
            v28 = torch.from_numpy(v22)
            del v22
            v29 = v0.forward(v28)
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
            v39 = method19(v38)
            if v39.tag == 0: # call
                if v1.tag == 0: # jack
                    v40 = 0
                elif v1.tag == 1: # king
                    v40 = 2
                elif v1.tag == 2: # queen
                    v40 = 1
                if v7.tag == 0: # jack
                    v41 = 0
                elif v7.tag == 1: # king
                    v41 = 2
                elif v7.tag == 2: # queen
                    v41 = 1
                if v4.tag == 0: # jack
                    v42 = 0
                elif v4.tag == 1: # king
                    v42 = 2
                elif v4.tag == 2: # queen
                    v42 = 1
                if v7.tag == 0: # jack
                    v43 = 0
                elif v7.tag == 1: # king
                    v43 = 2
                elif v7.tag == 2: # queen
                    v43 = 1
                v44 = method24(v41, v40)
                if v44:
                    v46 = method24(v43, v42)
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
                    v51 = method24(v41, v40)
                    if v51:
                        v69 = 1
                    else:
                        v52 = method24(v43, v42)
                        if v52:
                            v69 = -1
                        else:
                            tmp7 = method25(v41, v40)
                            v53, v54 = tmp7.v0, tmp7.v1
                            del tmp7
                            tmp8 = method25(v43, v42)
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
                    v71 = US3_1(v7)
                    v86 = method26(v0, v71, v4, v5, v6, v1, v2)
                    del v71
                else:
                    v73 = v69 == -1
                    if v73:
                        v74 = US3_1(v7)
                        v86 = method27(v0, v74, v4, v5, v6, v1, v2)
                        del v74
                    else:
                        v76 = US3_1(v7)
                        v77 = 0
                        v86 = method28(v0, v76, v4, v5, v6, v1, v2, v77)
                        del v76
            elif v39.tag == 1: # fold
                v81 = US3_1(v7)
                v86 = method31(v0, v81, v4, v5, v6, v1, v2, v3)
                del v81
            elif v39.tag == 2: # raise
                v83 = v10 - 1
                v84 = v6 + 4
                v86 = method29(v0, v9, v83, v7, v1, v2, v84, v4, v5, v6)
            v87 = v35 + v13
            v88 = US0_0(v39)
            v89 = UH0_0(v88, v12)
            del v88
            v90 = US0_0(v39)
            del v39
            v91 = UH0_0(v90, v14)
            del v90
            return v86(Tuple2(v11, v89, v87, v91, v15, v16))
        else:
            v93 = numpy.random.choice(v8)
            v94 = len(v8)
            v95 = <double>v94
            v96 = 1.000000 / v95
            v97 = libc.math.log(v96)
            if v93.tag == 0: # call
                if v1.tag == 0: # jack
                    v98 = 0
                elif v1.tag == 1: # king
                    v98 = 2
                elif v1.tag == 2: # queen
                    v98 = 1
                if v7.tag == 0: # jack
                    v99 = 0
                elif v7.tag == 1: # king
                    v99 = 2
                elif v7.tag == 2: # queen
                    v99 = 1
                if v4.tag == 0: # jack
                    v100 = 0
                elif v4.tag == 1: # king
                    v100 = 2
                elif v4.tag == 2: # queen
                    v100 = 1
                if v7.tag == 0: # jack
                    v101 = 0
                elif v7.tag == 1: # king
                    v101 = 2
                elif v7.tag == 2: # queen
                    v101 = 1
                v102 = method24(v99, v98)
                if v102:
                    v104 = method24(v101, v100)
                else:
                    v104 = 0
                if v104:
                    v105 = v98 < v100
                    if v105:
                        v127 = -1
                    else:
                        v106 = v98 > v100
                        if v106:
                            v127 = 1
                        else:
                            v127 = 0
                else:
                    v109 = method24(v99, v98)
                    if v109:
                        v127 = 1
                    else:
                        v110 = method24(v101, v100)
                        if v110:
                            v127 = -1
                        else:
                            tmp9 = method25(v99, v98)
                            v111, v112 = tmp9.v0, tmp9.v1
                            del tmp9
                            tmp10 = method25(v101, v100)
                            v113, v114 = tmp10.v0, tmp10.v1
                            del tmp10
                            v115 = v111 < v113
                            if v115:
                                v118 = -1
                            else:
                                v116 = v111 > v113
                                if v116:
                                    v118 = 1
                                else:
                                    v118 = 0
                            v119 = v118 == 0
                            if v119:
                                v120 = v112 < v114
                                if v120:
                                    v127 = -1
                                else:
                                    v121 = v112 > v114
                                    if v121:
                                        v127 = 1
                                    else:
                                        v127 = 0
                            else:
                                v127 = v118
                v128 = v127 == 1
                if v128:
                    v129 = US3_1(v7)
                    v144 = method26(v0, v129, v4, v5, v6, v1, v2)
                    del v129
                else:
                    v131 = v127 == -1
                    if v131:
                        v132 = US3_1(v7)
                        v144 = method27(v0, v132, v4, v5, v6, v1, v2)
                        del v132
                    else:
                        v134 = US3_1(v7)
                        v135 = 0
                        v144 = method28(v0, v134, v4, v5, v6, v1, v2, v135)
                        del v134
            elif v93.tag == 1: # fold
                v139 = US3_1(v7)
                v144 = method31(v0, v139, v4, v5, v6, v1, v2, v3)
                del v139
            elif v93.tag == 2: # raise
                v141 = v10 - 1
                v142 = v6 + 4
                v144 = method29(v0, v9, v141, v7, v1, v2, v142, v4, v5, v6)
            v145 = v97 + v15
            v146 = US0_0(v93)
            v147 = UH0_0(v146, v12)
            del v146
            v148 = US0_0(v93)
            del v93
            v149 = UH0_0(v148, v14)
            del v148
            return v144(Tuple2(v11, v147, v13, v149, v145, v16))
cdef class Closure3():
    cdef object v0
    cdef US2 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef US2 v6
    cdef object v7
    cdef Heap0 v8
    cdef signed long v9
    def __init__(self, v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, US2 v6, numpy.ndarray[object,ndim=1] v7, Heap0 v8, signed long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef US2 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef US2 v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef signed long v9 = self.v9
        cdef double v10 = args.v0
        cdef UH0 v11 = args.v1
        cdef double v12 = args.v2
        cdef UH0 v13 = args.v3
        cdef double v14 = args.v4
        cdef object v15 = args.v5
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
        cdef US1 v92
        cdef unsigned long long v93
        cdef double v94
        cdef double v95
        cdef double v96
        cdef object v143
        cdef signed long v97
        cdef signed long v98
        cdef signed long v99
        cdef signed long v100
        cdef bint v101
        cdef bint v103
        cdef signed long v126
        cdef bint v104
        cdef bint v105
        cdef bint v108
        cdef bint v109
        cdef signed long v110
        cdef signed long v111
        cdef Tuple3 tmp11
        cdef signed long v112
        cdef signed long v113
        cdef Tuple3 tmp12
        cdef bint v114
        cdef signed long v117
        cdef bint v115
        cdef bint v118
        cdef bint v119
        cdef bint v120
        cdef bint v127
        cdef US3 v128
        cdef bint v130
        cdef US3 v131
        cdef US3 v133
        cdef signed long v134
        cdef US3 v138
        cdef signed long v140
        cdef signed long v141
        cdef double v144
        cdef US0 v145
        cdef UH0 v146
        cdef US0 v147
        cdef UH0 v148
        v16 = v2 == 0
        if v16:
            v17 = method4(v11)
            v18 = len(v7)
            v19 = numpy.empty(v18,dtype=numpy.int64)
            v20 = 0
            method14(v18, v7, v19, v20)
            v21 = numpy.empty(30,dtype=numpy.float32)
            v22 = len(v21)
            v23 = 0
            method16(v22, v21, v23)
            v24 = len(v17)
            v25 = 2 < v24
            if v25:
                raise Exception("The given array is too large.")
            else:
                pass
            v26 = 0
            method17(v24, v21, v17, v26)
            del v17
            pass # import torch
            v27 = torch.from_numpy(v21)
            del v21
            v28 = v0.forward(v27)
            del v27
            v29 = v28[v19]
            del v28
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
            v37 = v19[v36]
            del v19
            v38 = method19(v37)
            if v38.tag == 0: # call
                if v1.tag == 0: # jack
                    v39 = 0
                elif v1.tag == 1: # king
                    v39 = 2
                elif v1.tag == 2: # queen
                    v39 = 1
                if v6.tag == 0: # jack
                    v40 = 0
                elif v6.tag == 1: # king
                    v40 = 2
                elif v6.tag == 2: # queen
                    v40 = 1
                if v4.tag == 0: # jack
                    v41 = 0
                elif v4.tag == 1: # king
                    v41 = 2
                elif v4.tag == 2: # queen
                    v41 = 1
                if v6.tag == 0: # jack
                    v42 = 0
                elif v6.tag == 1: # king
                    v42 = 2
                elif v6.tag == 2: # queen
                    v42 = 1
                v43 = method24(v40, v39)
                if v43:
                    v45 = method24(v42, v41)
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
                    v50 = method24(v40, v39)
                    if v50:
                        v68 = 1
                    else:
                        v51 = method24(v42, v41)
                        if v51:
                            v68 = -1
                        else:
                            tmp5 = method25(v40, v39)
                            v52, v53 = tmp5.v0, tmp5.v1
                            del tmp5
                            tmp6 = method25(v42, v41)
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
                    v70 = US3_1(v6)
                    v85 = method26(v0, v70, v4, v5, v3, v1, v2)
                    del v70
                else:
                    v72 = v68 == -1
                    if v72:
                        v73 = US3_1(v6)
                        v85 = method27(v0, v73, v4, v5, v3, v1, v2)
                        del v73
                    else:
                        v75 = US3_1(v6)
                        v76 = 0
                        v85 = method28(v0, v75, v4, v5, v3, v1, v2, v76)
                        del v75
            elif v38.tag == 1: # fold
                v80 = US3_1(v6)
                v85 = method27(v0, v80, v4, v5, v3, v1, v2)
                del v80
            elif v38.tag == 2: # raise
                v82 = v9 - 1
                v83 = v3 + 4
                v85 = method29(v0, v8, v82, v6, v1, v2, v83, v4, v5, v3)
            v86 = v34 + v12
            v87 = US0_0(v38)
            v88 = UH0_0(v87, v11)
            del v87
            v89 = US0_0(v38)
            del v38
            v90 = UH0_0(v89, v13)
            del v89
            return v85(Tuple2(v10, v88, v86, v90, v14, v15))
        else:
            v92 = numpy.random.choice(v7)
            v93 = len(v7)
            v94 = <double>v93
            v95 = 1.000000 / v94
            v96 = libc.math.log(v95)
            if v92.tag == 0: # call
                if v1.tag == 0: # jack
                    v97 = 0
                elif v1.tag == 1: # king
                    v97 = 2
                elif v1.tag == 2: # queen
                    v97 = 1
                if v6.tag == 0: # jack
                    v98 = 0
                elif v6.tag == 1: # king
                    v98 = 2
                elif v6.tag == 2: # queen
                    v98 = 1
                if v4.tag == 0: # jack
                    v99 = 0
                elif v4.tag == 1: # king
                    v99 = 2
                elif v4.tag == 2: # queen
                    v99 = 1
                if v6.tag == 0: # jack
                    v100 = 0
                elif v6.tag == 1: # king
                    v100 = 2
                elif v6.tag == 2: # queen
                    v100 = 1
                v101 = method24(v98, v97)
                if v101:
                    v103 = method24(v100, v99)
                else:
                    v103 = 0
                if v103:
                    v104 = v97 < v99
                    if v104:
                        v126 = -1
                    else:
                        v105 = v97 > v99
                        if v105:
                            v126 = 1
                        else:
                            v126 = 0
                else:
                    v108 = method24(v98, v97)
                    if v108:
                        v126 = 1
                    else:
                        v109 = method24(v100, v99)
                        if v109:
                            v126 = -1
                        else:
                            tmp11 = method25(v98, v97)
                            v110, v111 = tmp11.v0, tmp11.v1
                            del tmp11
                            tmp12 = method25(v100, v99)
                            v112, v113 = tmp12.v0, tmp12.v1
                            del tmp12
                            v114 = v110 < v112
                            if v114:
                                v117 = -1
                            else:
                                v115 = v110 > v112
                                if v115:
                                    v117 = 1
                                else:
                                    v117 = 0
                            v118 = v117 == 0
                            if v118:
                                v119 = v111 < v113
                                if v119:
                                    v126 = -1
                                else:
                                    v120 = v111 > v113
                                    if v120:
                                        v126 = 1
                                    else:
                                        v126 = 0
                            else:
                                v126 = v117
                v127 = v126 == 1
                if v127:
                    v128 = US3_1(v6)
                    v143 = method26(v0, v128, v4, v5, v3, v1, v2)
                    del v128
                else:
                    v130 = v126 == -1
                    if v130:
                        v131 = US3_1(v6)
                        v143 = method27(v0, v131, v4, v5, v3, v1, v2)
                        del v131
                    else:
                        v133 = US3_1(v6)
                        v134 = 0
                        v143 = method28(v0, v133, v4, v5, v3, v1, v2, v134)
                        del v133
            elif v92.tag == 1: # fold
                v138 = US3_1(v6)
                v143 = method27(v0, v138, v4, v5, v3, v1, v2)
                del v138
            elif v92.tag == 2: # raise
                v140 = v9 - 1
                v141 = v3 + 4
                v143 = method29(v0, v8, v140, v6, v1, v2, v141, v4, v5, v3)
            v144 = v96 + v14
            v145 = US0_0(v92)
            v146 = UH0_0(v145, v11)
            del v145
            v147 = US0_0(v92)
            del v92
            v148 = UH0_0(v147, v13)
            del v147
            return v143(Tuple2(v10, v146, v12, v148, v144, v15))
cdef class Closure2():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US2 v7
    cdef unsigned char v8
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, Heap0 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, Tuple2 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef double v9 = args.v0
        cdef UH0 v10 = args.v1
        cdef double v11 = args.v2
        cdef UH0 v12 = args.v3
        cdef double v13 = args.v4
        cdef object v14 = args.v5
        cdef US2 v15
        cdef unsigned long long v16
        cdef double v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef numpy.ndarray[object,ndim=1] v21
        cdef bint v22
        cdef US0 v23
        cdef UH0 v24
        cdef numpy.ndarray[object,ndim=1] v25
        cdef unsigned long long v26
        cdef numpy.ndarray[signed long long,ndim=1] v27
        cdef unsigned long long v28
        cdef numpy.ndarray[float,ndim=1] v29
        cdef unsigned long long v30
        cdef unsigned long long v31
        cdef unsigned long long v32
        cdef bint v33
        cdef unsigned long long v34
        cdef object v35
        cdef object v36
        cdef object v37
        cdef object v38
        cdef object v39
        cdef object v40
        cdef object v41
        cdef double v42
        cdef signed long long v43
        cdef unsigned long long v44
        cdef signed long long v45
        cdef US1 v46
        cdef object v53
        cdef signed long v47
        cdef signed long v50
        cdef signed long v51
        cdef double v54
        cdef US0 v55
        cdef US0 v56
        cdef UH0 v57
        cdef UH0 v58
        cdef US0 v59
        cdef US0 v60
        cdef UH0 v61
        cdef UH0 v62
        cdef US1 v64
        cdef unsigned long long v65
        cdef double v66
        cdef double v67
        cdef double v68
        cdef object v75
        cdef signed long v69
        cdef signed long v72
        cdef signed long v73
        cdef double v76
        cdef US0 v77
        cdef US0 v78
        cdef UH0 v79
        cdef UH0 v80
        cdef US0 v81
        cdef US0 v82
        cdef UH0 v83
        cdef UH0 v84
        v15 = v1[v0]
        v16 = len(v1)
        v17 = <double>v16
        v18 = 1.000000 / v17
        v19 = libc.math.log(v18)
        v20 = v19 + v9
        v21 = v3.v2
        v22 = v8 == 0
        if v22:
            v23 = US0_1(v15)
            v24 = UH0_0(v23, v10)
            del v23
            v25 = method4(v24)
            del v24
            v26 = len(v21)
            v27 = numpy.empty(v26,dtype=numpy.int64)
            v28 = 0
            method14(v26, v21, v27, v28)
            v29 = numpy.empty(30,dtype=numpy.float32)
            v30 = len(v29)
            v31 = 0
            method16(v30, v29, v31)
            v32 = len(v25)
            v33 = 2 < v32
            if v33:
                raise Exception("The given array is too large.")
            else:
                pass
            v34 = 0
            method17(v32, v29, v25, v34)
            del v25
            pass # import torch
            v35 = torch.from_numpy(v29)
            del v29
            v36 = v2.forward(v35)
            del v35
            v37 = v36[v27]
            del v36
            pass # import torch.nn.functional
            v38 = torch.nn.functional.softmax(v37,-1)
            del v37
            pass # import torch.distributions
            v39 = torch.distributions.Categorical(probs=v38)
            del v38
            v40 = v39.sample()
            v41 = v39.log_prob(v40)
            del v39
            v42 = v41.item()
            del v41
            v43 = v40.item()
            del v40
            v44 = v43
            v45 = v27[v44]
            del v27
            v46 = method19(v45)
            if v46.tag == 0: # call
                v47 = 2
                v53 = method23(v2, v3, v47, v15, v7, v8, v6, v4, v5)
            elif v46.tag == 1: # fold
                raise Exception("impossible")
            elif v46.tag == 2: # raise
                v50 = 1
                v51 = v6 + 4
                v53 = method29(v2, v3, v50, v15, v7, v8, v51, v4, v5, v6)
            v54 = v42 + v11
            v55 = US0_0(v46)
            v56 = US0_1(v15)
            v57 = UH0_0(v56, v10)
            del v56
            v58 = UH0_0(v55, v57)
            del v55; del v57
            v59 = US0_0(v46)
            del v46
            v60 = US0_1(v15)
            v61 = UH0_0(v60, v12)
            del v60
            v62 = UH0_0(v59, v61)
            del v59; del v61
            return v53(Tuple2(v20, v58, v54, v62, v13, v14))
        else:
            v64 = numpy.random.choice(v21)
            v65 = len(v21)
            v66 = <double>v65
            v67 = 1.000000 / v66
            v68 = libc.math.log(v67)
            if v64.tag == 0: # call
                v69 = 2
                v75 = method23(v2, v3, v69, v15, v7, v8, v6, v4, v5)
            elif v64.tag == 1: # fold
                raise Exception("impossible")
            elif v64.tag == 2: # raise
                v72 = 1
                v73 = v6 + 4
                v75 = method29(v2, v3, v72, v15, v7, v8, v73, v4, v5, v6)
            v76 = v68 + v13
            v77 = US0_0(v64)
            v78 = US0_1(v15)
            v79 = UH0_0(v78, v10)
            del v78
            v80 = UH0_0(v77, v79)
            del v77; del v79
            v81 = US0_0(v64)
            del v64
            v82 = US0_1(v15)
            v83 = UH0_0(v82, v12)
            del v82
            v84 = UH0_0(v81, v83)
            del v81; del v83
            return v75(Tuple2(v20, v80, v11, v84, v76, v14))
cdef class Closure6():
    cdef object v0
    cdef US2 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    def __init__(self, v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, numpy.ndarray[object,ndim=1] v7, Heap0 v8, numpy.ndarray[object,ndim=1] v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef US2 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
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
        cdef object v16 = args.v5
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
        cdef US1 v53
        cdef unsigned long long v54
        cdef double v55
        cdef double v56
        cdef double v57
        cdef object v64
        cdef US3 v59
        cdef signed long v61
        cdef signed long v62
        cdef double v65
        cdef US0 v66
        cdef UH0 v67
        cdef US0 v68
        cdef UH0 v69
        v17 = v2 == 0
        if v17:
            v18 = method4(v12)
            v19 = len(v7)
            v20 = numpy.empty(v19,dtype=numpy.int64)
            v21 = 0
            method14(v19, v7, v20, v21)
            v22 = numpy.empty(30,dtype=numpy.float32)
            v23 = len(v22)
            v24 = 0
            method16(v23, v22, v24)
            v25 = len(v18)
            v26 = 2 < v25
            if v26:
                raise Exception("The given array is too large.")
            else:
                pass
            v27 = 0
            method17(v25, v22, v18, v27)
            del v18
            pass # import torch
            v28 = torch.from_numpy(v22)
            del v22
            v29 = v0.forward(v28)
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
            v39 = method19(v38)
            if v39.tag == 0: # call
                v46 = method22(v0, v8, v9, v4, v5, v6, v1, v2)
            elif v39.tag == 1: # fold
                v41 = US3_0()
                v46 = method31(v0, v41, v4, v5, v6, v1, v2, v3)
                del v41
            elif v39.tag == 2: # raise
                v43 = v10 - 1
                v44 = v6 + 2
                v46 = method32(v0, v8, v9, v43, v1, v2, v44, v4, v5, v6)
            v47 = v35 + v13
            v48 = US0_0(v39)
            v49 = UH0_0(v48, v12)
            del v48
            v50 = US0_0(v39)
            del v39
            v51 = UH0_0(v50, v14)
            del v50
            return v46(Tuple2(v11, v49, v47, v51, v15, v16))
        else:
            v53 = numpy.random.choice(v7)
            v54 = len(v7)
            v55 = <double>v54
            v56 = 1.000000 / v55
            v57 = libc.math.log(v56)
            if v53.tag == 0: # call
                v64 = method22(v0, v8, v9, v1, v2, v6, v4, v5)
            elif v53.tag == 1: # fold
                v59 = US3_0()
                v64 = method31(v0, v59, v4, v5, v6, v1, v2, v3)
                del v59
            elif v53.tag == 2: # raise
                v61 = v10 - 1
                v62 = v6 + 2
                v64 = method32(v0, v8, v9, v61, v1, v2, v62, v4, v5, v6)
            v65 = v57 + v15
            v66 = US0_0(v53)
            v67 = UH0_0(v66, v12)
            del v66
            v68 = US0_0(v53)
            del v53
            v69 = UH0_0(v68, v14)
            del v68
            return v64(Tuple2(v11, v67, v13, v69, v65, v16))
cdef class Closure1():
    cdef object v0
    cdef US2 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef signed long v9
    def __init__(self, v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, numpy.ndarray[object,ndim=1] v6, Heap0 v7, numpy.ndarray[object,ndim=1] v8, signed long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef US2 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
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
        cdef object v15 = args.v5
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
        cdef US1 v52
        cdef unsigned long long v53
        cdef double v54
        cdef double v55
        cdef double v56
        cdef object v63
        cdef US3 v58
        cdef signed long v60
        cdef signed long v61
        cdef double v64
        cdef US0 v65
        cdef UH0 v66
        cdef US0 v67
        cdef UH0 v68
        v16 = v2 == 0
        if v16:
            v17 = method4(v11)
            v18 = len(v6)
            v19 = numpy.empty(v18,dtype=numpy.int64)
            v20 = 0
            method14(v18, v6, v19, v20)
            v21 = numpy.empty(30,dtype=numpy.float32)
            v22 = len(v21)
            v23 = 0
            method16(v22, v21, v23)
            v24 = len(v17)
            v25 = 2 < v24
            if v25:
                raise Exception("The given array is too large.")
            else:
                pass
            v26 = 0
            method17(v24, v21, v17, v26)
            del v17
            pass # import torch
            v27 = torch.from_numpy(v21)
            del v21
            v28 = v0.forward(v27)
            del v27
            v29 = v28[v19]
            del v28
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
            v37 = v19[v36]
            del v19
            v38 = method19(v37)
            if v38.tag == 0: # call
                v45 = method22(v0, v7, v8, v4, v5, v3, v1, v2)
            elif v38.tag == 1: # fold
                v40 = US3_0()
                v45 = method27(v0, v40, v4, v5, v3, v1, v2)
                del v40
            elif v38.tag == 2: # raise
                v42 = v9 - 1
                v43 = v3 + 2
                v45 = method32(v0, v7, v8, v42, v1, v2, v43, v4, v5, v3)
            v46 = v34 + v12
            v47 = US0_0(v38)
            v48 = UH0_0(v47, v11)
            del v47
            v49 = US0_0(v38)
            del v38
            v50 = UH0_0(v49, v13)
            del v49
            return v45(Tuple2(v10, v48, v46, v50, v14, v15))
        else:
            v52 = numpy.random.choice(v6)
            v53 = len(v6)
            v54 = <double>v53
            v55 = 1.000000 / v54
            v56 = libc.math.log(v55)
            if v52.tag == 0: # call
                v63 = method22(v0, v7, v8, v1, v2, v3, v4, v5)
            elif v52.tag == 1: # fold
                v58 = US3_0()
                v63 = method27(v0, v58, v4, v5, v3, v1, v2)
                del v58
            elif v52.tag == 2: # raise
                v60 = v9 - 1
                v61 = v3 + 2
                v63 = method32(v0, v7, v8, v60, v1, v2, v61, v4, v5, v3)
            v64 = v56 + v14
            v65 = US0_0(v52)
            v66 = UH0_0(v65, v11)
            del v65
            v67 = US0_0(v52)
            del v52
            v68 = UH0_0(v67, v13)
            del v67
            return v63(Tuple2(v10, v66, v12, v68, v64, v15))
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
cdef Tuple0 method2(US2 v0, unsigned char v1, UH0 v2, double v3):
    cdef bint v4
    cdef US0 v5
    cdef UH0 v6
    v4 = 0 == v1
    if v4:
        v5 = US0_1(v0)
        v6 = UH0_0(v5, v2)
        del v5
        return Tuple0(v6, v3)
    else:
        return Tuple0(v2, v3)
cdef Tuple0 method3(US2 v0, unsigned char v1, UH0 v2, double v3):
    cdef bint v4
    cdef US0 v5
    cdef UH0 v6
    v4 = 1 == v1
    if v4:
        v5 = US0_1(v0)
        v6 = UH0_0(v5, v2)
        del v5
        return Tuple0(v6, v3)
    else:
        return Tuple0(v2, v3)
cdef UH0 method5(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method5(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method7(UH1 v0, UH1 v1):
    cdef US1 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        del v2
        return method7(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method9(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method10(numpy.ndarray[object,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US1 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method10(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method8(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method9(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method10(v3, v0, v4)
    return v3
cdef UH2 method6(UH1 v0, US2 v1, UH0 v2):
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
            return method6(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US0_1>v3).v0
            v9 = UH1_1()
            v10 = method7(v0, v9)
            del v9
            v11 = method8(v10)
            del v10
            v12 = UH1_1()
            v13 = method6(v12, v8, v4)
            del v4; del v8; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method7(v0, v16)
        del v16
        v18 = method8(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method12(UH2 v0, unsigned long long v1):
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v4 = (<UH2_0>v0).v2
        v5 = v1 + 1
        return method12(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method13(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US2 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v3; del v4
        v6 = v2 + 1
        return method13(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method11(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method12(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method13(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method4(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US0 v3
    cdef UH0 v4
    cdef US2 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method5(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US0_1>v3).v0
            v8 = UH1_1()
            v9 = method6(v8, v7, v4)
            del v4; del v7; del v8
            return method11(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef signed long long method15(US1 v0):
    cdef signed long long v1
    if v0.tag == 0: # call
        v1 = 0
    elif v0.tag == 1: # fold
        v1 = 1
    elif v0.tag == 2: # raise
        v1 = 2
    return v1
cdef void method14(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        v7 = method15(v6)
        del v6
        v2[v3] = v7
        method14(v0, v1, v2, v5)
    else:
        pass
cdef void method16(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method16(v0, v1, v4)
    else:
        pass
cdef void method18(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method18(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method17(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
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
        method18(v12, v1, v11, v7, v14)
        del v7
        method17(v0, v1, v2, v5)
    else:
        pass
cdef US1 method19(signed long long v0):
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
cdef numpy.ndarray[object,ndim=1] method21(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6):
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
cdef bint method24(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple3 method25(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple3(v1, v0)
    else:
        return Tuple3(v0, v1)
cdef object method26(v0, US3 v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6):
    cdef bint v7
    cdef signed long v9
    cdef signed long v11
    cdef signed long v12
    cdef bint v13
    cdef signed long v15
    cdef signed long v16
    cdef US2 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US2 v20
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
    return Closure4(v0, v20, v21, v22, v17, v18, v19, v1, v23)
cdef object method27(v0, US3 v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6):
    cdef bint v7
    cdef signed long v9
    cdef bint v10
    cdef signed long v12
    cdef signed long v13
    cdef signed long v15
    cdef signed long v16
    cdef US2 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US2 v20
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
    return Closure4(v0, v20, v21, v22, v17, v18, v19, v1, v23)
cdef object method28(v0, US3 v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7):
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
    return Closure4(v0, v21, v22, v23, v18, v19, v20, v1, v24)
cdef numpy.ndarray[object,ndim=1] method30(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef object method31(v0, US3 v1, US2 v2, unsigned char v3, signed long v4, US2 v5, unsigned char v6, signed long v7):
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
    return Closure4(v0, v21, v22, v23, v18, v19, v20, v1, v24)
cdef object method29(v0, Heap0 v1, signed long v2, US2 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method30(v1, v4, v5, v6, v7, v8, v9, v2)
    return Closure5(v0, v7, v8, v9, v4, v5, v6, v3, v10, v1, v2)
cdef object method23(v0, Heap0 v1, signed long v2, US2 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8):
    cdef numpy.ndarray[object,ndim=1] v9
    v9 = method21(v1, v4, v5, v6, v7, v8, v2)
    return Closure3(v0, v7, v8, v6, v4, v5, v3, v9, v1, v2)
cdef object method22(v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7):
    cdef unsigned long long v8
    cdef unsigned long long v9
    v8 = len(v2)
    v9 = numpy.random.randint(0,v8)
    return Closure2(v9, v2, v0, v1, v3, v4, v5, v6, v7)
cdef object method32(v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8, signed long v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method30(v1, v4, v5, v6, v7, v8, v9, v3)
    return Closure6(v0, v7, v8, v9, v4, v5, v6, v10, v1, v2, v3)
cdef object method20(v0, Heap0 v1, numpy.ndarray[object,ndim=1] v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US2 v7, unsigned char v8):
    cdef numpy.ndarray[object,ndim=1] v9
    v9 = method21(v1, v4, v5, v6, v7, v8, v3)
    return Closure1(v0, v7, v8, v6, v4, v5, v9, v1, v2, v3)
cdef void method0(v0, UH0 v1, double v2, UH0 v3, double v4, unsigned long v5):
    cdef bint v6
    cdef unsigned long v7
    cdef US1 v8
    cdef US1 v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef US1 v11
    cdef US1 v12
    cdef US1 v13
    cdef numpy.ndarray[object,ndim=1] v14
    cdef US1 v15
    cdef US1 v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef US1 v18
    cdef numpy.ndarray[object,ndim=1] v19
    cdef Heap0 v20
    cdef US2 v21
    cdef US2 v22
    cdef US2 v23
    cdef US2 v24
    cdef US2 v25
    cdef US2 v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef object v30
    cdef US2 v31
    cdef unsigned long long v32
    cdef numpy.ndarray[object,ndim=1] v33
    cdef unsigned long long v34
    cdef double v35
    cdef double v36
    cdef double v37
    cdef unsigned char v38
    cdef UH0 v39
    cdef double v40
    cdef Tuple0 tmp0
    cdef unsigned char v41
    cdef UH0 v42
    cdef double v43
    cdef Tuple0 tmp1
    cdef unsigned long long v44
    cdef unsigned long long v45
    cdef US2 v46
    cdef unsigned long long v47
    cdef numpy.ndarray[object,ndim=1] v48
    cdef unsigned long long v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef double v53
    cdef unsigned char v54
    cdef UH0 v55
    cdef double v56
    cdef Tuple0 tmp2
    cdef unsigned char v57
    cdef UH0 v58
    cdef double v59
    cdef Tuple0 tmp3
    cdef numpy.ndarray[object,ndim=1] v60
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
    cdef US1 v82
    cdef object v95
    cdef signed long v83
    cdef unsigned char v84
    cdef signed long v85
    cdef unsigned char v86
    cdef signed long v89
    cdef unsigned char v90
    cdef signed long v91
    cdef unsigned char v92
    cdef signed long v93
    cdef double v96
    cdef US0 v97
    cdef UH0 v98
    cdef US0 v99
    cdef UH0 v100
    cdef double v101
    v6 = v5 < 100
    if v6:
        v7 = v5 + 1
        v8 = US1_0()
        v9 = US1_2()
        v10 = numpy.empty(2,dtype=object)
        v10[0] = v8; v10[1] = v9
        del v8; del v9
        v11 = US1_1()
        v12 = US1_0()
        v13 = US1_2()
        v14 = numpy.empty(3,dtype=object)
        v14[0] = v11; v14[1] = v12; v14[2] = v13
        del v11; del v12; del v13
        v15 = US1_1()
        v16 = US1_0()
        v17 = numpy.empty(2,dtype=object)
        v17[0] = v15; v17[1] = v16
        del v15; del v16
        v18 = US1_0()
        v19 = numpy.empty(1,dtype=object)
        v19[0] = v18
        del v18
        v20 = Heap0(v19, v14, v10, v17)
        del v10; del v14; del v17; del v19
        v21 = US2_1()
        v22 = US2_2()
        v23 = US2_0()
        v24 = US2_1()
        v25 = US2_2()
        v26 = US2_0()
        v27 = numpy.empty(6,dtype=object)
        v27[0] = v21; v27[1] = v22; v27[2] = v23; v27[3] = v24; v27[4] = v25; v27[5] = v26
        del v21; del v22; del v23; del v24; del v25; del v26
        v28 = len(v27)
        v29 = numpy.random.randint(0,v28)
        v30 = Closure0()
        v31 = v27[v29]
        v32 = v28 - 1
        v33 = numpy.empty(v32,dtype=object)
        v34 = 0
        method1(v32, v29, v27, v33, v34)
        del v27
        v35 = <double>v28
        v36 = 1.000000 / v35
        v37 = libc.math.log(v36)
        v38 = 0
        tmp0 = method2(v31, v38, v1, v2)
        v39, v40 = tmp0.v0, tmp0.v1
        del tmp0
        v41 = 1
        tmp1 = method2(v31, v41, v3, v4)
        v42, v43 = tmp1.v0, tmp1.v1
        del tmp1
        v44 = len(v33)
        v45 = numpy.random.randint(0,v44)
        v46 = v33[v45]
        v47 = v44 - 1
        v48 = numpy.empty(v47,dtype=object)
        v49 = 0
        method1(v47, v45, v33, v48, v49)
        del v33
        v50 = <double>v44
        v51 = 1.000000 / v50
        v52 = libc.math.log(v51)
        v53 = v52 + v37
        v54 = 0
        tmp2 = method3(v46, v54, v39, v40)
        v55, v56 = tmp2.v0, tmp2.v1
        del tmp2
        del v39
        v57 = 1
        tmp3 = method3(v46, v57, v42, v43)
        v58, v59 = tmp3.v0, tmp3.v1
        del tmp3
        del v42
        v60 = v20.v2
        v61 = method4(v55)
        v62 = len(v60)
        v63 = numpy.empty(v62,dtype=numpy.int64)
        v64 = 0
        method14(v62, v60, v63, v64)
        del v60
        v65 = numpy.empty(30,dtype=numpy.float32)
        v66 = len(v65)
        v67 = 0
        method16(v66, v65, v67)
        v68 = len(v61)
        v69 = 2 < v68
        if v69:
            raise Exception("The given array is too large.")
        else:
            pass
        v70 = 0
        method17(v68, v65, v61, v70)
        del v61
        pass # import torch
        v71 = torch.from_numpy(v65)
        del v65
        v72 = v0.forward(v71)
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
        v82 = method19(v81)
        if v82.tag == 0: # call
            v83 = 2
            v84 = 1
            v85 = 1
            v86 = 0
            v95 = method20(v0, v20, v48, v83, v31, v86, v85, v46, v84)
        elif v82.tag == 1: # fold
            raise Exception("impossible")
        elif v82.tag == 2: # raise
            v89 = 1
            v90 = 1
            v91 = 1
            v92 = 0
            v93 = 3
            v95 = method32(v0, v20, v48, v89, v31, v92, v93, v46, v90, v91)
        del v20; del v31; del v46; del v48
        v96 = v78 + v56
        v97 = US0_0(v82)
        v98 = UH0_0(v97, v55)
        del v55; del v97
        v99 = US0_0(v82)
        del v82
        v100 = UH0_0(v99, v58)
        del v58; del v99
        v101 = v95(Tuple2(v53, v98, v96, v100, v59, v30))
        del v30; del v95; del v98; del v100
        print("Reward for player one at iteration ", v5, " is ", v101)
        method0(v0, v1, v2, v3, v4, v7)
    else:
        pass
cpdef void main():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef unsigned long v5
    pass # import nets
    v0 = nets.small(30,64,3)
    v1 = UH0_1()
    v2 = 0.000000
    v3 = UH0_1()
    v4 = 0.000000
    v5 = 0
    method0(v0, v1, v2, v3, v4, v5)
