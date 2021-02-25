import torch
import torch.nn
import torch.distributions
import torch.nn.functional
import nets
import numpy
cimport numpy
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
cdef class Tuple1:
    cdef readonly UH0 v0
    cdef readonly double v1
    cdef readonly object v2
    cdef readonly UH0 v3
    cdef readonly double v4
    def __init__(self, UH0 v0, double v1, v2, UH0 v3, double v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple2:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure3():
    cdef double v0
    def __init__(self, double v0): self.v0 = v0
    def __call__(self, Tuple1 args):
        cdef double v0 = self.v0
        cdef UH0 v1 = args.v0
        cdef double v2 = args.v1
        cdef object v3 = args.v2
        cdef UH0 v4 = args.v3
        cdef double v5 = args.v4
        return v0
cdef class Closure4():
    cdef unsigned char v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef signed long v4
    cdef US1 v5
    cdef US1 v6
    cdef unsigned char v7
    cdef unsigned long v8
    cdef US1 v9
    cdef unsigned long v10
    def __init__(self, unsigned char v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9, unsigned long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple1 args):
        cdef unsigned char v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef unsigned long v10 = self.v10
        cdef UH0 v11 = args.v0
        cdef double v12 = args.v1
        cdef object v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef bint v16
        cdef object v17
        cdef US0 v18
        cdef object v70
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef signed long v22
        cdef bint v23
        cdef bint v25
        cdef signed long v48
        cdef bint v26
        cdef bint v27
        cdef bint v30
        cdef bint v31
        cdef signed long v32
        cdef signed long v33
        cdef Tuple2 tmp3
        cdef signed long v34
        cdef signed long v35
        cdef Tuple2 tmp4
        cdef bint v36
        cdef signed long v39
        cdef bint v37
        cdef bint v40
        cdef bint v41
        cdef bint v42
        cdef bint v49
        cdef double v50
        cdef object v51
        cdef bint v52
        cdef double v53
        cdef bint v54
        cdef double v56
        cdef object v57
        cdef double v58
        cdef object v59
        cdef double v62
        cdef bint v63
        cdef double v65
        cdef object v66
        cdef signed long v67
        cdef unsigned long v68
        cdef US2 v71
        cdef UH0 v72
        cdef US0 v74
        cdef object v128
        cdef signed long v75
        cdef signed long v76
        cdef signed long v77
        cdef signed long v78
        cdef bint v79
        cdef bint v81
        cdef signed long v104
        cdef bint v82
        cdef bint v83
        cdef bint v86
        cdef bint v87
        cdef signed long v88
        cdef signed long v89
        cdef Tuple2 tmp5
        cdef signed long v90
        cdef signed long v91
        cdef Tuple2 tmp6
        cdef bint v92
        cdef signed long v95
        cdef bint v93
        cdef bint v96
        cdef bint v97
        cdef bint v98
        cdef bint v105
        cdef double v106
        cdef double v107
        cdef object v108
        cdef bint v109
        cdef double v110
        cdef bint v111
        cdef double v113
        cdef object v114
        cdef double v115
        cdef double v116
        cdef object v117
        cdef double v120
        cdef bint v121
        cdef double v123
        cdef object v124
        cdef signed long v125
        cdef unsigned long v126
        v16 = v0 == 0
        if v16:
            v17 = v13(v11)
            v18 = v17(v1)
            del v17
            if v18.tag == 0: # call
                if v9.tag == 0: # jack
                    v19 = 0
                elif v9.tag == 1: # king
                    v19 = 2
                elif v9.tag == 2: # queen
                    v19 = 1
                if v5.tag == 0: # jack
                    v20 = 0
                elif v5.tag == 1: # king
                    v20 = 2
                elif v5.tag == 2: # queen
                    v20 = 1
                if v6.tag == 0: # jack
                    v21 = 0
                elif v6.tag == 1: # king
                    v21 = 2
                elif v6.tag == 2: # queen
                    v21 = 1
                if v5.tag == 0: # jack
                    v22 = 0
                elif v5.tag == 1: # king
                    v22 = 2
                elif v5.tag == 2: # queen
                    v22 = 1
                v23 = method22(v20, v19)
                if v23:
                    v25 = method22(v22, v21)
                else:
                    v25 = 0
                if v25:
                    v26 = v19 < v21
                    if v26:
                        v48 = -1
                    else:
                        v27 = v19 > v21
                        if v27:
                            v48 = 1
                        else:
                            v48 = 0
                else:
                    v30 = method22(v20, v19)
                    if v30:
                        v48 = 1
                    else:
                        v31 = method22(v22, v21)
                        if v31:
                            v48 = -1
                        else:
                            tmp3 = method23(v20, v19)
                            v32, v33 = tmp3.v0, tmp3.v1
                            del tmp3
                            tmp4 = method23(v22, v21)
                            v34, v35 = tmp4.v0, tmp4.v1
                            del tmp4
                            v36 = v32 < v34
                            if v36:
                                v39 = -1
                            else:
                                v37 = v32 > v34
                                if v37:
                                    v39 = 1
                                else:
                                    v39 = 0
                            v40 = v39 == 0
                            if v40:
                                v41 = v33 < v35
                                if v41:
                                    v48 = -1
                                else:
                                    v42 = v33 > v35
                                    if v42:
                                        v48 = 1
                                    else:
                                        v48 = 0
                            else:
                                v48 = v39
                v49 = v48 == 1
                if v49:
                    v50 = <double>v8
                    v51 = Closure3(v50)
                    v70 = v51
                    del v51
                else:
                    v52 = v48 == -1
                    if v52:
                        v53 = <double>v8
                        v54 = v7 == 0
                        if v54:
                            v56 = v53
                        else:
                            v56 =  -v53
                        v57 = Closure3(v56)
                        v70 = v57
                        del v57
                    else:
                        v58 = <double>0
                        v59 = Closure3(v58)
                        v70 = v59
                        del v59
            elif v18.tag == 1: # fold
                v62 = <double>v10
                v63 = v7 == 0
                if v63:
                    v65 = v62
                else:
                    v65 =  -v62
                v66 = Closure3(v65)
                v70 = v66
                del v66
            elif v18.tag == 2: # raise
                v67 = v4 - 1
                v68 = v8 + 4
                v70 = method24(v2, v3, v67, v5, v9, v0, v68, v6, v7, v8)
            v71 = US2_0(v18)
            del v18
            v72 = UH0_0(v71, v11)
            del v71
            return v70(Tuple1(v72, v12, v13, v14, v15))
        else:
            v74 = numpy.random.choice(v1)
            if v74.tag == 0: # call
                if v9.tag == 0: # jack
                    v75 = 0
                elif v9.tag == 1: # king
                    v75 = 2
                elif v9.tag == 2: # queen
                    v75 = 1
                if v5.tag == 0: # jack
                    v76 = 0
                elif v5.tag == 1: # king
                    v76 = 2
                elif v5.tag == 2: # queen
                    v76 = 1
                if v6.tag == 0: # jack
                    v77 = 0
                elif v6.tag == 1: # king
                    v77 = 2
                elif v6.tag == 2: # queen
                    v77 = 1
                if v5.tag == 0: # jack
                    v78 = 0
                elif v5.tag == 1: # king
                    v78 = 2
                elif v5.tag == 2: # queen
                    v78 = 1
                v79 = method22(v76, v75)
                if v79:
                    v81 = method22(v78, v77)
                else:
                    v81 = 0
                if v81:
                    v82 = v75 < v77
                    if v82:
                        v104 = -1
                    else:
                        v83 = v75 > v77
                        if v83:
                            v104 = 1
                        else:
                            v104 = 0
                else:
                    v86 = method22(v76, v75)
                    if v86:
                        v104 = 1
                    else:
                        v87 = method22(v78, v77)
                        if v87:
                            v104 = -1
                        else:
                            tmp5 = method23(v76, v75)
                            v88, v89 = tmp5.v0, tmp5.v1
                            del tmp5
                            tmp6 = method23(v78, v77)
                            v90, v91 = tmp6.v0, tmp6.v1
                            del tmp6
                            v92 = v88 < v90
                            if v92:
                                v95 = -1
                            else:
                                v93 = v88 > v90
                                if v93:
                                    v95 = 1
                                else:
                                    v95 = 0
                            v96 = v95 == 0
                            if v96:
                                v97 = v89 < v91
                                if v97:
                                    v104 = -1
                                else:
                                    v98 = v89 > v91
                                    if v98:
                                        v104 = 1
                                    else:
                                        v104 = 0
                            else:
                                v104 = v95
                v105 = v104 == 1
                if v105:
                    v106 = <double>v8
                    v107 =  -v106
                    v108 = Closure3(v107)
                    v128 = v108
                    del v108
                else:
                    v109 = v104 == -1
                    if v109:
                        v110 = <double>v8
                        v111 = v7 == 0
                        if v111:
                            v113 = v110
                        else:
                            v113 =  -v110
                        v114 = Closure3(v113)
                        v128 = v114
                        del v114
                    else:
                        v115 = <double>0
                        v116 =  -v115
                        v117 = Closure3(v116)
                        v128 = v117
                        del v117
            elif v74.tag == 1: # fold
                v120 = <double>v10
                v121 = v7 == 0
                if v121:
                    v123 = v120
                else:
                    v123 =  -v120
                v124 = Closure3(v123)
                v128 = v124
                del v124
            elif v74.tag == 2: # raise
                v125 = v4 - 1
                v126 = v8 + 4
                v128 = method24(v2, v3, v125, v5, v9, v0, v126, v6, v7, v8)
            del v74
            return v128(Tuple1(v11, v12, v13, v14, v15))
cdef class Closure2():
    cdef unsigned char v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef signed long v4
    cdef US1 v5
    cdef US1 v6
    cdef unsigned char v7
    cdef unsigned long v8
    cdef US1 v9
    def __init__(self, unsigned char v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple1 args):
        cdef unsigned char v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef UH0 v10 = args.v0
        cdef double v11 = args.v1
        cdef object v12 = args.v2
        cdef UH0 v13 = args.v3
        cdef double v14 = args.v4
        cdef bint v15
        cdef object v16
        cdef US0 v17
        cdef object v69
        cdef signed long v18
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef bint v22
        cdef bint v24
        cdef signed long v47
        cdef bint v25
        cdef bint v26
        cdef bint v29
        cdef bint v30
        cdef signed long v31
        cdef signed long v32
        cdef Tuple2 tmp1
        cdef signed long v33
        cdef signed long v34
        cdef Tuple2 tmp2
        cdef bint v35
        cdef signed long v38
        cdef bint v36
        cdef bint v39
        cdef bint v40
        cdef bint v41
        cdef bint v48
        cdef double v49
        cdef object v50
        cdef bint v51
        cdef double v52
        cdef bint v53
        cdef double v55
        cdef object v56
        cdef double v57
        cdef object v58
        cdef double v61
        cdef bint v62
        cdef double v64
        cdef object v65
        cdef signed long v66
        cdef unsigned long v67
        cdef US2 v70
        cdef UH0 v71
        cdef US0 v73
        cdef object v127
        cdef signed long v74
        cdef signed long v75
        cdef signed long v76
        cdef signed long v77
        cdef bint v78
        cdef bint v80
        cdef signed long v103
        cdef bint v81
        cdef bint v82
        cdef bint v85
        cdef bint v86
        cdef signed long v87
        cdef signed long v88
        cdef Tuple2 tmp7
        cdef signed long v89
        cdef signed long v90
        cdef Tuple2 tmp8
        cdef bint v91
        cdef signed long v94
        cdef bint v92
        cdef bint v95
        cdef bint v96
        cdef bint v97
        cdef bint v104
        cdef double v105
        cdef double v106
        cdef object v107
        cdef bint v108
        cdef double v109
        cdef bint v110
        cdef double v112
        cdef object v113
        cdef double v114
        cdef double v115
        cdef object v116
        cdef double v119
        cdef bint v120
        cdef double v122
        cdef object v123
        cdef signed long v124
        cdef unsigned long v125
        v15 = v0 == 0
        if v15:
            v16 = v12(v10)
            v17 = v16(v1)
            del v16
            if v17.tag == 0: # call
                if v9.tag == 0: # jack
                    v18 = 0
                elif v9.tag == 1: # king
                    v18 = 2
                elif v9.tag == 2: # queen
                    v18 = 1
                if v5.tag == 0: # jack
                    v19 = 0
                elif v5.tag == 1: # king
                    v19 = 2
                elif v5.tag == 2: # queen
                    v19 = 1
                if v6.tag == 0: # jack
                    v20 = 0
                elif v6.tag == 1: # king
                    v20 = 2
                elif v6.tag == 2: # queen
                    v20 = 1
                if v5.tag == 0: # jack
                    v21 = 0
                elif v5.tag == 1: # king
                    v21 = 2
                elif v5.tag == 2: # queen
                    v21 = 1
                v22 = method22(v19, v18)
                if v22:
                    v24 = method22(v21, v20)
                else:
                    v24 = 0
                if v24:
                    v25 = v18 < v20
                    if v25:
                        v47 = -1
                    else:
                        v26 = v18 > v20
                        if v26:
                            v47 = 1
                        else:
                            v47 = 0
                else:
                    v29 = method22(v19, v18)
                    if v29:
                        v47 = 1
                    else:
                        v30 = method22(v21, v20)
                        if v30:
                            v47 = -1
                        else:
                            tmp1 = method23(v19, v18)
                            v31, v32 = tmp1.v0, tmp1.v1
                            del tmp1
                            tmp2 = method23(v21, v20)
                            v33, v34 = tmp2.v0, tmp2.v1
                            del tmp2
                            v35 = v31 < v33
                            if v35:
                                v38 = -1
                            else:
                                v36 = v31 > v33
                                if v36:
                                    v38 = 1
                                else:
                                    v38 = 0
                            v39 = v38 == 0
                            if v39:
                                v40 = v32 < v34
                                if v40:
                                    v47 = -1
                                else:
                                    v41 = v32 > v34
                                    if v41:
                                        v47 = 1
                                    else:
                                        v47 = 0
                            else:
                                v47 = v38
                v48 = v47 == 1
                if v48:
                    v49 = <double>v8
                    v50 = Closure3(v49)
                    v69 = v50
                    del v50
                else:
                    v51 = v47 == -1
                    if v51:
                        v52 = <double>v8
                        v53 = v7 == 0
                        if v53:
                            v55 = v52
                        else:
                            v55 =  -v52
                        v56 = Closure3(v55)
                        v69 = v56
                        del v56
                    else:
                        v57 = <double>0
                        v58 = Closure3(v57)
                        v69 = v58
                        del v58
            elif v17.tag == 1: # fold
                v61 = <double>v8
                v62 = v7 == 0
                if v62:
                    v64 = v61
                else:
                    v64 =  -v61
                v65 = Closure3(v64)
                v69 = v65
                del v65
            elif v17.tag == 2: # raise
                v66 = v4 - 1
                v67 = v8 + 4
                v69 = method24(v2, v3, v66, v5, v9, v0, v67, v6, v7, v8)
            v70 = US2_0(v17)
            del v17
            v71 = UH0_0(v70, v10)
            del v70
            return v69(Tuple1(v71, v11, v12, v13, v14))
        else:
            v73 = numpy.random.choice(v1)
            if v73.tag == 0: # call
                if v9.tag == 0: # jack
                    v74 = 0
                elif v9.tag == 1: # king
                    v74 = 2
                elif v9.tag == 2: # queen
                    v74 = 1
                if v5.tag == 0: # jack
                    v75 = 0
                elif v5.tag == 1: # king
                    v75 = 2
                elif v5.tag == 2: # queen
                    v75 = 1
                if v6.tag == 0: # jack
                    v76 = 0
                elif v6.tag == 1: # king
                    v76 = 2
                elif v6.tag == 2: # queen
                    v76 = 1
                if v5.tag == 0: # jack
                    v77 = 0
                elif v5.tag == 1: # king
                    v77 = 2
                elif v5.tag == 2: # queen
                    v77 = 1
                v78 = method22(v75, v74)
                if v78:
                    v80 = method22(v77, v76)
                else:
                    v80 = 0
                if v80:
                    v81 = v74 < v76
                    if v81:
                        v103 = -1
                    else:
                        v82 = v74 > v76
                        if v82:
                            v103 = 1
                        else:
                            v103 = 0
                else:
                    v85 = method22(v75, v74)
                    if v85:
                        v103 = 1
                    else:
                        v86 = method22(v77, v76)
                        if v86:
                            v103 = -1
                        else:
                            tmp7 = method23(v75, v74)
                            v87, v88 = tmp7.v0, tmp7.v1
                            del tmp7
                            tmp8 = method23(v77, v76)
                            v89, v90 = tmp8.v0, tmp8.v1
                            del tmp8
                            v91 = v87 < v89
                            if v91:
                                v94 = -1
                            else:
                                v92 = v87 > v89
                                if v92:
                                    v94 = 1
                                else:
                                    v94 = 0
                            v95 = v94 == 0
                            if v95:
                                v96 = v88 < v90
                                if v96:
                                    v103 = -1
                                else:
                                    v97 = v88 > v90
                                    if v97:
                                        v103 = 1
                                    else:
                                        v103 = 0
                            else:
                                v103 = v94
                v104 = v103 == 1
                if v104:
                    v105 = <double>v8
                    v106 =  -v105
                    v107 = Closure3(v106)
                    v127 = v107
                    del v107
                else:
                    v108 = v103 == -1
                    if v108:
                        v109 = <double>v8
                        v110 = v7 == 0
                        if v110:
                            v112 = v109
                        else:
                            v112 =  -v109
                        v113 = Closure3(v112)
                        v127 = v113
                        del v113
                    else:
                        v114 = <double>0
                        v115 =  -v114
                        v116 = Closure3(v115)
                        v127 = v116
                        del v116
            elif v73.tag == 1: # fold
                v119 = <double>v8
                v120 = v7 == 0
                if v120:
                    v122 = v119
                else:
                    v122 =  -v119
                v123 = Closure3(v122)
                v127 = v123
                del v123
            elif v73.tag == 2: # raise
                v124 = v4 - 1
                v125 = v8 + 4
                v127 = method24(v2, v3, v124, v5, v9, v0, v125, v6, v7, v8)
            del v73
            return v127(Tuple1(v10, v11, v12, v13, v14))
cdef class Closure1():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef US1 v4
    cdef unsigned char v5
    cdef unsigned long v6
    cdef US1 v7
    cdef unsigned char v8
    def __init__(self, numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, Tuple1 args):
        cdef numpy.ndarray[object,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef unsigned long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef UH0 v9 = args.v0
        cdef double v10 = args.v1
        cdef object v11 = args.v2
        cdef UH0 v12 = args.v3
        cdef double v13 = args.v4
        cdef US1 v14
        cdef bint v15
        cdef US2 v16
        cdef UH0 v17
        cdef object v18
        cdef US0 v19
        cdef object v26
        cdef signed long v20
        cdef signed long v23
        cdef unsigned long v24
        cdef US2 v27
        cdef US2 v28
        cdef UH0 v29
        cdef UH0 v30
        cdef US2 v31
        cdef UH0 v32
        cdef US0 v34
        cdef object v41
        cdef signed long v35
        cdef signed long v38
        cdef unsigned long v39
        cdef US2 v42
        cdef UH0 v43
        cdef US2 v44
        cdef UH0 v45
        v14 = numpy.random.choice(v0)
        v15 = v8 == 0
        if v15:
            v16 = US2_1(v14)
            v17 = UH0_0(v16, v9)
            del v16
            v18 = v11(v17)
            del v17
            v19 = v18(v1)
            del v18
            if v19.tag == 0: # call
                v20 = 2
                v26 = method21(v2, v3, v20, v14, v7, v8, v6, v4, v5)
            elif v19.tag == 1: # fold
                raise Exception("impossible")
            elif v19.tag == 2: # raise
                v23 = 1
                v24 = v6 + 4
                v26 = method24(v2, v3, v23, v14, v7, v8, v24, v4, v5, v6)
            v27 = US2_0(v19)
            del v19
            v28 = US2_1(v14)
            v29 = UH0_0(v28, v9)
            del v28
            v30 = UH0_0(v27, v29)
            del v27; del v29
            v31 = US2_1(v14)
            v32 = UH0_0(v31, v12)
            del v31
            return v26(Tuple1(v30, v10, v11, v32, v13))
        else:
            v34 = numpy.random.choice(v1)
            if v34.tag == 0: # call
                v35 = 2
                v41 = method21(v2, v3, v35, v14, v7, v8, v6, v4, v5)
            elif v34.tag == 1: # fold
                raise Exception("impossible")
            elif v34.tag == 2: # raise
                v38 = 1
                v39 = v6 + 4
                v41 = method24(v2, v3, v38, v14, v7, v8, v39, v4, v5, v6)
            del v34
            v42 = US2_1(v14)
            v43 = UH0_0(v42, v9)
            del v42
            v44 = US2_1(v14)
            v45 = UH0_0(v44, v12)
            del v44
            return v41(Tuple1(v43, v10, v11, v45, v13))
cdef class Closure5():
    cdef unsigned char v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef unsigned char v8
    cdef unsigned long v9
    cdef US1 v10
    cdef unsigned long v11
    def __init__(self, unsigned char v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, unsigned char v8, unsigned long v9, US1 v10, unsigned long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple1 args):
        cdef unsigned char v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef UH0 v12 = args.v0
        cdef double v13 = args.v1
        cdef object v14 = args.v2
        cdef UH0 v15 = args.v3
        cdef double v16 = args.v4
        cdef bint v17
        cdef object v18
        cdef US0 v19
        cdef object v29
        cdef double v21
        cdef bint v22
        cdef double v24
        cdef object v25
        cdef signed long v26
        cdef unsigned long v27
        cdef US2 v30
        cdef UH0 v31
        cdef US0 v33
        cdef object v43
        cdef double v35
        cdef bint v36
        cdef double v38
        cdef object v39
        cdef signed long v40
        cdef unsigned long v41
        v17 = v0 == 0
        if v17:
            v18 = v14(v12)
            v19 = v18(v1)
            del v18
            if v19.tag == 0: # call
                v29 = method20(v4, v2, v3, v5, v7, v8, v9, v10, v0)
            elif v19.tag == 1: # fold
                v21 = <double>v11
                v22 = v8 == 0
                if v22:
                    v24 = v21
                else:
                    v24 =  -v21
                v25 = Closure3(v24)
                v29 = v25
                del v25
            elif v19.tag == 2: # raise
                v26 = v6 - 1
                v27 = v9 + 2
                v29 = method25(v2, v3, v4, v5, v26, v10, v0, v27, v7, v8, v9)
            v30 = US2_0(v19)
            del v19
            v31 = UH0_0(v30, v12)
            del v30
            return v29(Tuple1(v31, v13, v14, v15, v16))
        else:
            v33 = numpy.random.choice(v1)
            if v33.tag == 0: # call
                v43 = method20(v4, v2, v3, v5, v10, v0, v9, v7, v8)
            elif v33.tag == 1: # fold
                v35 = <double>v11
                v36 = v8 == 0
                if v36:
                    v38 = v35
                else:
                    v38 =  -v35
                v39 = Closure3(v38)
                v43 = v39
                del v39
            elif v33.tag == 2: # raise
                v40 = v6 - 1
                v41 = v9 + 2
                v43 = method25(v2, v3, v4, v5, v40, v10, v0, v41, v7, v8, v9)
            del v33
            return v43(Tuple1(v12, v13, v14, v15, v16))
cdef class Closure0():
    cdef unsigned char v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef unsigned char v8
    cdef unsigned long v9
    cdef US1 v10
    def __init__(self, unsigned char v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, unsigned char v8, unsigned long v9, US1 v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple1 args):
        cdef unsigned char v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef UH0 v11 = args.v0
        cdef double v12 = args.v1
        cdef object v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef bint v16
        cdef object v17
        cdef US0 v18
        cdef object v28
        cdef double v20
        cdef bint v21
        cdef double v23
        cdef object v24
        cdef signed long v25
        cdef unsigned long v26
        cdef US2 v29
        cdef UH0 v30
        cdef US0 v32
        cdef object v42
        cdef double v34
        cdef bint v35
        cdef double v37
        cdef object v38
        cdef signed long v39
        cdef unsigned long v40
        v16 = v0 == 0
        if v16:
            v17 = v13(v11)
            v18 = v17(v1)
            del v17
            if v18.tag == 0: # call
                v28 = method20(v4, v2, v3, v5, v7, v8, v9, v10, v0)
            elif v18.tag == 1: # fold
                v20 = <double>v9
                v21 = v8 == 0
                if v21:
                    v23 = v20
                else:
                    v23 =  -v20
                v24 = Closure3(v23)
                v28 = v24
                del v24
            elif v18.tag == 2: # raise
                v25 = v6 - 1
                v26 = v9 + 2
                v28 = method25(v2, v3, v4, v5, v25, v10, v0, v26, v7, v8, v9)
            v29 = US2_0(v18)
            del v18
            v30 = UH0_0(v29, v11)
            del v29
            return v28(Tuple1(v30, v12, v13, v14, v15))
        else:
            v32 = numpy.random.choice(v1)
            if v32.tag == 0: # call
                v42 = method20(v4, v2, v3, v5, v10, v0, v9, v7, v8)
            elif v32.tag == 1: # fold
                v34 = <double>v9
                v35 = v8 == 0
                if v35:
                    v37 = v34
                else:
                    v37 =  -v34
                v38 = Closure3(v37)
                v42 = v38
                del v38
            elif v32.tag == 2: # raise
                v39 = v6 - 1
                v40 = v9 + 2
                v42 = method25(v2, v3, v4, v5, v39, v10, v0, v40, v7, v8, v9)
            del v32
            return v42(Tuple1(v11, v12, v13, v14, v15))
cdef class Closure7():
    cdef object v0
    cdef object v1
    def __init__(self, v0, numpy.ndarray[object,ndim=1] v1): self.v0 = v0; self.v1 = v1
    def __call__(self, numpy.ndarray[object,ndim=1] v2):
        cdef object v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef numpy.ndarray[float,ndim=1] v3
        cdef unsigned long long v4
        cdef unsigned long long v5
        cdef unsigned long long v6
        cdef bint v7
        cdef unsigned long long v8
        cdef object v9
        cdef object v10
        cdef unsigned long long v11
        cdef numpy.ndarray[signed long long,ndim=1] v12
        cdef unsigned long long v13
        cdef object v14
        cdef object v15
        cdef object v16
        cdef object v17
        cdef unsigned long long v18
        cdef signed long long v19
        v3 = numpy.empty(30,dtype=numpy.float32)
        v4 = len(v3)
        v5 = 0
        method13(v4, v3, v5)
        v6 = len(v1)
        v7 = 2 < v6
        if v7:
            raise Exception("The given array is too large.")
        else:
            pass
        v8 = 0
        method14(v6, v3, v1, v8)
        v9 = torch.from_numpy(v3)
        del v3
        v10 = v0.forward(v9)
        del v9
        v11 = len(v2)
        v12 = numpy.empty(v11,dtype=numpy.int64)
        v13 = 0
        method16(v11, v2, v12, v13)
        v14 = v10[v12]
        del v10
        v15 = torch.nn.functional.softmax(v14,-1)
        del v14
        v16 = torch.distributions.Categorical(probs=v15)
        del v15
        v17 = v16.sample()
        del v16
        v18 = v17.item()
        del v17
        v19 = v12[v18]
        del v12
        return method18(v19)
cdef class Closure6():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, UH0 v1):
        cdef object v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v2
        v2 = method3(v1)
        return Closure7(v0, v2)
cdef void method2(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method2(v0, v1, v2, v3, v6)
    else:
        pass
cdef UH0 method4(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1
        v4 = UH0_0(v2, v0)
        del v2
        return method4(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cdef UH1 method6(UH1 v0, UH1 v1):
    cdef US0 v2
    cdef UH1 v3
    cdef UH1 v4
    if v1.tag == 0: # cons_
        v2 = (<UH1_0>v1).v0; v3 = (<UH1_0>v1).v1
        v4 = UH1_0(v2, v0)
        del v2
        return method6(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cdef unsigned long long method8(unsigned long long v0, UH1 v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v1
        v4 = v0 + 1
        return method8(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cdef unsigned long long method9(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, UH1 v2):
    cdef US0 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v2.tag == 0: # cons_
        v3 = (<UH1_0>v2).v0; v4 = (<UH1_0>v2).v1
        v0[v1] = v3
        del v3
        v5 = v1 + 1
        return method9(v0, v5, v4)
    elif v2.tag == 1: # nil
        return v1
cdef numpy.ndarray[object,ndim=1] method7(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method8(v1, v0)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method9(v3, v4, v0)
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
            v10 = method6(v9, v0)
            del v9
            v11 = method7(v10)
            del v10
            v12 = UH1_1()
            v13 = method5(v12, v8, v4)
            del v4; del v8; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method6(v16, v0)
        del v16
        v18 = method7(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method11(unsigned long long v0, UH2 v1):
    cdef UH2 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v4 = (<UH2_0>v1).v2
        v5 = v0 + 1
        return method11(v5, v4)
    elif v1.tag == 1: # nil
        return v0
cdef unsigned long long method12(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, UH2 v2):
    cdef US1 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v2.tag == 0: # cons_
        v3 = (<UH2_0>v2).v0; v4 = (<UH2_0>v2).v1; v5 = (<UH2_0>v2).v2
        v0[v1] = Tuple0(v3, v4)
        del v3; del v4
        v6 = v1 + 1
        return method12(v0, v6, v5)
    elif v2.tag == 1: # nil
        return v1
cdef numpy.ndarray[object,ndim=1] method10(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method11(v1, v0)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method12(v3, v4, v0)
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
    v2 = method4(v1, v0)
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
cdef Tuple2 method23(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple2(v1, v0)
    else:
        return Tuple2(v0, v1)
cdef object method24(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed long v2, US1 v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8, unsigned long v9):
    cdef bint v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef object v12
    v10 = 0 < v2
    if v10:
        v11 = v0
    else:
        v11 = v1
    v12 = Closure4(v8, v11, v0, v1, v2, v3, v4, v5, v6, v7, v9)
    del v11
    return v12
cdef object method21(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed long v2, US1 v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8):
    cdef bint v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef object v11
    v9 = 0 < v2
    if v9:
        v10 = v0
    else:
        v10 = v1
    v11 = Closure2(v8, v10, v0, v1, v2, v3, v4, v5, v6, v7)
    del v10
    return v11
cdef object method20(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8):
    cdef object v9
    v9 = Closure1(v3, v0, v1, v2, v4, v5, v6, v7, v8)
    return v9
cdef object method25(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9, unsigned long v10):
    cdef bint v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef object v13
    v11 = 0 < v4
    if v11:
        v12 = v0
    else:
        v12 = v1
    v13 = Closure5(v9, v12, v0, v1, v2, v3, v4, v5, v6, v7, v8, v10)
    del v12
    return v13
cdef object method19(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9):
    cdef bint v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef object v12
    v10 = 0 < v4
    if v10:
        v11 = v0
    else:
        v11 = v1
    v12 = Closure0(v9, v11, v0, v1, v2, v3, v4, v5, v6, v7, v8)
    del v11
    return v12
cdef double method1(v0):
    cdef US0 v1
    cdef US0 v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef US0 v4
    cdef US0 v5
    cdef US0 v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef US0 v8
    cdef US0 v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef US1 v11
    cdef US1 v12
    cdef US1 v13
    cdef US1 v14
    cdef US1 v15
    cdef US1 v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef US1 v20
    cdef unsigned long long v21
    cdef numpy.ndarray[object,ndim=1] v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef US1 v26
    cdef unsigned long long v27
    cdef numpy.ndarray[object,ndim=1] v28
    cdef unsigned long long v29
    cdef US2 v30
    cdef UH0 v31
    cdef UH0 v32
    cdef numpy.ndarray[object,ndim=1] v33
    cdef numpy.ndarray[float,ndim=1] v34
    cdef unsigned long long v35
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef bint v38
    cdef unsigned long long v39
    cdef object v40
    cdef object v41
    cdef unsigned long long v42
    cdef numpy.ndarray[signed long long,ndim=1] v43
    cdef unsigned long long v44
    cdef object v45
    cdef object v46
    cdef object v47
    cdef object v48
    cdef unsigned long long v49
    cdef signed long long v50
    cdef US0 v51
    cdef object v64
    cdef signed long v52
    cdef unsigned char v53
    cdef unsigned long v54
    cdef unsigned char v55
    cdef signed long v58
    cdef unsigned char v59
    cdef unsigned long v60
    cdef unsigned char v61
    cdef unsigned long v62
    cdef US2 v65
    cdef US2 v66
    cdef UH0 v67
    cdef UH0 v68
    cdef UH0 v69
    cdef object v70
    cdef US2 v71
    cdef UH0 v72
    cdef UH0 v73
    v1 = US0_0()
    v2 = US0_2()
    v3 = numpy.empty(2,dtype=object)
    v3[0] = v1; v3[1] = v2
    del v1; del v2
    v4 = US0_1()
    v5 = US0_0()
    v6 = US0_2()
    v7 = numpy.empty(3,dtype=object)
    v7[0] = v4; v7[1] = v5; v7[2] = v6
    del v4; del v5; del v6
    v8 = US0_1()
    v9 = US0_0()
    v10 = numpy.empty(2,dtype=object)
    v10[0] = v8; v10[1] = v9
    del v8; del v9
    v11 = US1_1()
    v12 = US1_2()
    v13 = US1_0()
    v14 = US1_1()
    v15 = US1_2()
    v16 = US1_0()
    v17 = numpy.empty(6,dtype=object)
    v17[0] = v11; v17[1] = v12; v17[2] = v13; v17[3] = v14; v17[4] = v15; v17[5] = v16
    del v11; del v12; del v13; del v14; del v15; del v16
    v18 = len(v17)
    v19 = numpy.random.randint(0,v18)
    v20 = v17[v19]
    v21 = v18 - 1
    v22 = numpy.empty(v21,dtype=object)
    v23 = 0
    method2(v21, v19, v17, v22, v23)
    del v17
    v24 = len(v22)
    v25 = numpy.random.randint(0,v24)
    v26 = v22[v25]
    v27 = v24 - 1
    v28 = numpy.empty(v27,dtype=object)
    v29 = 0
    method2(v27, v25, v22, v28, v29)
    del v22
    v30 = US2_1(v20)
    v31 = UH0_1()
    v32 = UH0_0(v30, v31)
    del v30; del v31
    v33 = method3(v32)
    del v32
    v34 = numpy.empty(30,dtype=numpy.float32)
    v35 = len(v34)
    v36 = 0
    method13(v35, v34, v36)
    v37 = len(v33)
    v38 = 2 < v37
    if v38:
        raise Exception("The given array is too large.")
    else:
        pass
    v39 = 0
    method14(v37, v34, v33, v39)
    del v33
    v40 = torch.from_numpy(v34)
    del v34
    v41 = v0.forward(v40)
    del v40
    v42 = len(v3)
    v43 = numpy.empty(v42,dtype=numpy.int64)
    v44 = 0
    method16(v42, v3, v43, v44)
    v45 = v41[v43]
    del v41
    v46 = torch.nn.functional.softmax(v45,-1)
    del v45
    v47 = torch.distributions.Categorical(probs=v46)
    del v46
    v48 = v47.sample()
    del v47
    v49 = v48.item()
    del v48
    v50 = v43[v49]
    del v43
    v51 = method18(v50)
    if v51.tag == 0: # call
        v52 = 2
        v53 = 1
        v54 = 1
        v55 = 0
        v64 = method19(v7, v10, v3, v28, v52, v20, v55, v54, v26, v53)
    elif v51.tag == 1: # fold
        raise Exception("impossible")
    elif v51.tag == 2: # raise
        v58 = 1
        v59 = 1
        v60 = 1
        v61 = 0
        v62 = 3
        v64 = method25(v7, v10, v3, v28, v58, v20, v61, v62, v26, v59, v60)
    del v3; del v7; del v10; del v28
    v65 = US2_0(v51)
    del v51
    v66 = US2_1(v20)
    del v20
    v67 = UH0_1()
    v68 = UH0_0(v66, v67)
    del v66; del v67
    v69 = UH0_0(v65, v68)
    del v65; del v68
    v70 = Closure6(v0)
    v71 = US2_1(v26)
    del v26
    v72 = UH0_1()
    v73 = UH0_0(v71, v72)
    del v71; del v72
    return v64(Tuple1(v69, 1.000000, v70, v73, 1.000000))
cdef void method0(v0, unsigned long v1):
    cdef bint v2
    cdef unsigned long v3
    cdef double v4
    v2 = v1 < 100
    if v2:
        v3 = v1 + 1
        v4 = method1(v0)
        print("Reward for player one at iteration ", v1, " is ", v4)
        method0(v0, v3)
    else:
        pass
cpdef void main():
    cdef object v0
    cdef unsigned long v1
    pass # import torch
    pass # import torch.nn
    pass # import torch.distributions
    pass # import torch.nn.functional
    pass # import nets
    v0 = nets.small(30,64,3)
    v1 = 0
    method0(v0, v1)
