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
cdef class ClosureTy2:
    cpdef US0 apply(self, numpy.ndarray[object,ndim=1] v0): raise NotImplementedError()
cdef class ClosureTy1:
    cpdef ClosureTy2 apply(self, UH0 v0): raise NotImplementedError()
cdef class ClosureTy0:
    cpdef double apply(self, UH0 v0, double v1, ClosureTy1 v2, UH0 v3, double v4): raise NotImplementedError()
cdef class Tuple1:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure3(ClosureTy0):
    cdef double v0
    def __init__(self, double v0): self.v0 = v0
    cpdef double apply(self, UH0 v1, double v2, ClosureTy1 v3, UH0 v4, double v5):
        cdef double v0 = self.v0
        return v0
cdef class Closure4(ClosureTy0):
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
    def __init__(self, unsigned char v0, v1, v2, v3, signed long v4, US1 v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9, unsigned long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    cpdef double apply(self, UH0 v11, double v12, ClosureTy1 v13, UH0 v14, double v15):
        cdef unsigned char v0 = self.v0
        v1 = self.v1
        v2 = self.v2
        v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef unsigned long v10 = self.v10
        cdef char v16
        cdef ClosureTy2 v17
        cdef US0 v18
        cdef ClosureTy0 v70
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef signed long v22
        cdef char v23
        cdef char v25
        cdef signed long v48
        cdef char v26
        cdef char v27
        cdef char v30
        cdef char v31
        cdef signed long v32
        cdef signed long v33
        cdef Tuple1 tmp3
        cdef signed long v34
        cdef signed long v35
        cdef Tuple1 tmp4
        cdef char v36
        cdef signed long v39
        cdef char v37
        cdef char v40
        cdef char v41
        cdef char v42
        cdef char v49
        cdef double v50
        cdef ClosureTy0 v51
        cdef char v52
        cdef double v53
        cdef char v54
        cdef double v56
        cdef ClosureTy0 v57
        cdef double v58
        cdef ClosureTy0 v59
        cdef double v62
        cdef char v63
        cdef double v65
        cdef ClosureTy0 v66
        cdef signed long v67
        cdef unsigned long v68
        cdef US0 v72
        cdef ClosureTy0 v126
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef signed long v76
        cdef char v77
        cdef char v79
        cdef signed long v102
        cdef char v80
        cdef char v81
        cdef char v84
        cdef char v85
        cdef signed long v86
        cdef signed long v87
        cdef Tuple1 tmp5
        cdef signed long v88
        cdef signed long v89
        cdef Tuple1 tmp6
        cdef char v90
        cdef signed long v93
        cdef char v91
        cdef char v94
        cdef char v95
        cdef char v96
        cdef char v103
        cdef double v104
        cdef double v105
        cdef ClosureTy0 v106
        cdef char v107
        cdef double v108
        cdef char v109
        cdef double v111
        cdef ClosureTy0 v112
        cdef double v113
        cdef double v114
        cdef ClosureTy0 v115
        cdef double v118
        cdef char v119
        cdef double v121
        cdef ClosureTy0 v122
        cdef signed long v123
        cdef unsigned long v124
        v16 = v0 == 0
        if v16:
            v17 = v13.apply(v11)
            v18 = v17.apply(v1)
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
                v23 = method21(v20, v19)
                if v23:
                    v25 = method21(v22, v21)
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
                    v30 = method21(v20, v19)
                    if v30:
                        v48 = 1
                    else:
                        v31 = method21(v22, v21)
                        if v31:
                            v48 = -1
                        else:
                            tmp3 = method22(v20, v19)
                            v32, v33 = tmp3.v0, tmp3.v1
                            del tmp3
                            tmp4 = method22(v22, v21)
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
                        v53 = <double>v10
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
                v70 = method23(v2, v3, v67, v5, v9, v0, v68, v6, v7, v8)
            del v18
            return v70.apply(v11, v12, v13, v14, v15)
        else:
            v72 = numpy.random.choice(v1)
            if v72.tag == 0: # call
                if v9.tag == 0: # jack
                    v73 = 0
                elif v9.tag == 1: # king
                    v73 = 2
                elif v9.tag == 2: # queen
                    v73 = 1
                if v5.tag == 0: # jack
                    v74 = 0
                elif v5.tag == 1: # king
                    v74 = 2
                elif v5.tag == 2: # queen
                    v74 = 1
                if v6.tag == 0: # jack
                    v75 = 0
                elif v6.tag == 1: # king
                    v75 = 2
                elif v6.tag == 2: # queen
                    v75 = 1
                if v5.tag == 0: # jack
                    v76 = 0
                elif v5.tag == 1: # king
                    v76 = 2
                elif v5.tag == 2: # queen
                    v76 = 1
                v77 = method21(v74, v73)
                if v77:
                    v79 = method21(v76, v75)
                else:
                    v79 = 0
                if v79:
                    v80 = v73 < v75
                    if v80:
                        v102 = -1
                    else:
                        v81 = v73 > v75
                        if v81:
                            v102 = 1
                        else:
                            v102 = 0
                else:
                    v84 = method21(v74, v73)
                    if v84:
                        v102 = 1
                    else:
                        v85 = method21(v76, v75)
                        if v85:
                            v102 = -1
                        else:
                            tmp5 = method22(v74, v73)
                            v86, v87 = tmp5.v0, tmp5.v1
                            del tmp5
                            tmp6 = method22(v76, v75)
                            v88, v89 = tmp6.v0, tmp6.v1
                            del tmp6
                            v90 = v86 < v88
                            if v90:
                                v93 = -1
                            else:
                                v91 = v86 > v88
                                if v91:
                                    v93 = 1
                                else:
                                    v93 = 0
                            v94 = v93 == 0
                            if v94:
                                v95 = v87 < v89
                                if v95:
                                    v102 = -1
                                else:
                                    v96 = v87 > v89
                                    if v96:
                                        v102 = 1
                                    else:
                                        v102 = 0
                            else:
                                v102 = v93
                v103 = v102 == 1
                if v103:
                    v104 = <double>v8
                    v105 =  -v104
                    v106 = Closure3(v105)
                    v126 = v106
                    del v106
                else:
                    v107 = v102 == -1
                    if v107:
                        v108 = <double>v10
                        v109 = v7 == 0
                        if v109:
                            v111 = v108
                        else:
                            v111 =  -v108
                        v112 = Closure3(v111)
                        v126 = v112
                        del v112
                    else:
                        v113 = <double>0
                        v114 =  -v113
                        v115 = Closure3(v114)
                        v126 = v115
                        del v115
            elif v72.tag == 1: # fold
                v118 = <double>v10
                v119 = v7 == 0
                if v119:
                    v121 = v118
                else:
                    v121 =  -v118
                v122 = Closure3(v121)
                v126 = v122
                del v122
            elif v72.tag == 2: # raise
                v123 = v4 - 1
                v124 = v8 + 4
                v126 = method23(v2, v3, v123, v5, v9, v0, v124, v6, v7, v8)
            del v72
            return v126.apply(v11, v12, v13, v14, v15)
cdef class Closure2(ClosureTy0):
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
    def __init__(self, unsigned char v0, v1, v2, v3, signed long v4, US1 v5, US1 v6, unsigned char v7, unsigned long v8, US1 v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    cpdef double apply(self, UH0 v10, double v11, ClosureTy1 v12, UH0 v13, double v14):
        cdef unsigned char v0 = self.v0
        v1 = self.v1
        v2 = self.v2
        v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef char v15
        cdef ClosureTy2 v16
        cdef US0 v17
        cdef ClosureTy0 v69
        cdef signed long v18
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef char v22
        cdef char v24
        cdef signed long v47
        cdef char v25
        cdef char v26
        cdef char v29
        cdef char v30
        cdef signed long v31
        cdef signed long v32
        cdef Tuple1 tmp1
        cdef signed long v33
        cdef signed long v34
        cdef Tuple1 tmp2
        cdef char v35
        cdef signed long v38
        cdef char v36
        cdef char v39
        cdef char v40
        cdef char v41
        cdef char v48
        cdef double v49
        cdef ClosureTy0 v50
        cdef char v51
        cdef double v52
        cdef char v53
        cdef double v55
        cdef ClosureTy0 v56
        cdef double v57
        cdef ClosureTy0 v58
        cdef double v61
        cdef char v62
        cdef double v64
        cdef ClosureTy0 v65
        cdef signed long v66
        cdef unsigned long v67
        cdef US0 v71
        cdef ClosureTy0 v125
        cdef signed long v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef char v76
        cdef char v78
        cdef signed long v101
        cdef char v79
        cdef char v80
        cdef char v83
        cdef char v84
        cdef signed long v85
        cdef signed long v86
        cdef Tuple1 tmp7
        cdef signed long v87
        cdef signed long v88
        cdef Tuple1 tmp8
        cdef char v89
        cdef signed long v92
        cdef char v90
        cdef char v93
        cdef char v94
        cdef char v95
        cdef char v102
        cdef double v103
        cdef double v104
        cdef ClosureTy0 v105
        cdef char v106
        cdef double v107
        cdef char v108
        cdef double v110
        cdef ClosureTy0 v111
        cdef double v112
        cdef double v113
        cdef ClosureTy0 v114
        cdef double v117
        cdef char v118
        cdef double v120
        cdef ClosureTy0 v121
        cdef signed long v122
        cdef unsigned long v123
        v15 = v0 == 0
        if v15:
            v16 = v12.apply(v10)
            v17 = v16.apply(v1)
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
                v22 = method21(v19, v18)
                if v22:
                    v24 = method21(v21, v20)
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
                    v29 = method21(v19, v18)
                    if v29:
                        v47 = 1
                    else:
                        v30 = method21(v21, v20)
                        if v30:
                            v47 = -1
                        else:
                            tmp1 = method22(v19, v18)
                            v31, v32 = tmp1.v0, tmp1.v1
                            del tmp1
                            tmp2 = method22(v21, v20)
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
                v69 = method23(v2, v3, v66, v5, v9, v0, v67, v6, v7, v8)
            del v17
            return v69.apply(v10, v11, v12, v13, v14)
        else:
            v71 = numpy.random.choice(v1)
            if v71.tag == 0: # call
                if v9.tag == 0: # jack
                    v72 = 0
                elif v9.tag == 1: # king
                    v72 = 2
                elif v9.tag == 2: # queen
                    v72 = 1
                if v5.tag == 0: # jack
                    v73 = 0
                elif v5.tag == 1: # king
                    v73 = 2
                elif v5.tag == 2: # queen
                    v73 = 1
                if v6.tag == 0: # jack
                    v74 = 0
                elif v6.tag == 1: # king
                    v74 = 2
                elif v6.tag == 2: # queen
                    v74 = 1
                if v5.tag == 0: # jack
                    v75 = 0
                elif v5.tag == 1: # king
                    v75 = 2
                elif v5.tag == 2: # queen
                    v75 = 1
                v76 = method21(v73, v72)
                if v76:
                    v78 = method21(v75, v74)
                else:
                    v78 = 0
                if v78:
                    v79 = v72 < v74
                    if v79:
                        v101 = -1
                    else:
                        v80 = v72 > v74
                        if v80:
                            v101 = 1
                        else:
                            v101 = 0
                else:
                    v83 = method21(v73, v72)
                    if v83:
                        v101 = 1
                    else:
                        v84 = method21(v75, v74)
                        if v84:
                            v101 = -1
                        else:
                            tmp7 = method22(v73, v72)
                            v85, v86 = tmp7.v0, tmp7.v1
                            del tmp7
                            tmp8 = method22(v75, v74)
                            v87, v88 = tmp8.v0, tmp8.v1
                            del tmp8
                            v89 = v85 < v87
                            if v89:
                                v92 = -1
                            else:
                                v90 = v85 > v87
                                if v90:
                                    v92 = 1
                                else:
                                    v92 = 0
                            v93 = v92 == 0
                            if v93:
                                v94 = v86 < v88
                                if v94:
                                    v101 = -1
                                else:
                                    v95 = v86 > v88
                                    if v95:
                                        v101 = 1
                                    else:
                                        v101 = 0
                            else:
                                v101 = v92
                v102 = v101 == 1
                if v102:
                    v103 = <double>v8
                    v104 =  -v103
                    v105 = Closure3(v104)
                    v125 = v105
                    del v105
                else:
                    v106 = v101 == -1
                    if v106:
                        v107 = <double>v8
                        v108 = v7 == 0
                        if v108:
                            v110 = v107
                        else:
                            v110 =  -v107
                        v111 = Closure3(v110)
                        v125 = v111
                        del v111
                    else:
                        v112 = <double>0
                        v113 =  -v112
                        v114 = Closure3(v113)
                        v125 = v114
                        del v114
            elif v71.tag == 1: # fold
                v117 = <double>v8
                v118 = v7 == 0
                if v118:
                    v120 = v117
                else:
                    v120 =  -v117
                v121 = Closure3(v120)
                v125 = v121
                del v121
            elif v71.tag == 2: # raise
                v122 = v4 - 1
                v123 = v8 + 4
                v125 = method23(v2, v3, v122, v5, v9, v0, v123, v6, v7, v8)
            del v71
            return v125.apply(v10, v11, v12, v13, v14)
cdef class Closure1(ClosureTy0):
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef US1 v4
    cdef unsigned char v5
    cdef unsigned long v6
    cdef US1 v7
    cdef unsigned char v8
    def __init__(self, v0, v1, v2, v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    cpdef double apply(self, UH0 v9, double v10, ClosureTy1 v11, UH0 v12, double v13):
        v0 = self.v0
        v1 = self.v1
        v2 = self.v2
        v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef unsigned long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef US1 v14
        cdef char v15
        cdef US2 v16
        cdef UH0 v17
        cdef ClosureTy2 v18
        cdef US0 v19
        cdef ClosureTy0 v26
        cdef signed long v20
        cdef signed long v23
        cdef unsigned long v24
        cdef US2 v27
        cdef UH0 v28
        cdef US2 v29
        cdef UH0 v30
        cdef US0 v32
        cdef ClosureTy0 v39
        cdef signed long v33
        cdef signed long v36
        cdef unsigned long v37
        cdef US2 v40
        cdef UH0 v41
        cdef US2 v42
        cdef UH0 v43
        v14 = numpy.random.choice(v0)
        v15 = v8 == 0
        if v15:
            v16 = US2_1(v14)
            v17 = UH0_0(v16, v9)
            del v16
            v18 = v11.apply(v17)
            del v17
            v19 = v18.apply(v1)
            del v18
            if v19.tag == 0: # call
                v20 = 2
                v26 = method20(v2, v3, v20, v14, v7, v8, v6, v4, v5)
            elif v19.tag == 1: # fold
                raise Exception("impossible")
            elif v19.tag == 2: # raise
                v23 = 1
                v24 = v6 + 4
                v26 = method23(v2, v3, v23, v14, v7, v8, v24, v4, v5, v6)
            del v19
            v27 = US2_1(v14)
            v28 = UH0_0(v27, v9)
            del v27
            v29 = US2_1(v14)
            v30 = UH0_0(v29, v12)
            del v29
            return v26.apply(v28, v10, v11, v30, v13)
        else:
            v32 = numpy.random.choice(v1)
            if v32.tag == 0: # call
                v33 = 2
                v39 = method20(v2, v3, v33, v14, v7, v8, v6, v4, v5)
            elif v32.tag == 1: # fold
                raise Exception("impossible")
            elif v32.tag == 2: # raise
                v36 = 1
                v37 = v6 + 4
                v39 = method23(v2, v3, v36, v14, v7, v8, v37, v4, v5, v6)
            del v32
            v40 = US2_1(v14)
            v41 = UH0_0(v40, v9)
            del v40
            v42 = US2_1(v14)
            v43 = UH0_0(v42, v12)
            del v42
            return v39.apply(v41, v10, v11, v43, v13)
cdef class Closure6(ClosureTy0):
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef US1 v4
    cdef unsigned char v5
    cdef unsigned long v6
    cdef US1 v7
    cdef unsigned char v8
    cdef unsigned long v9
    def __init__(self, v0, v1, v2, v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8, unsigned long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    cpdef double apply(self, UH0 v10, double v11, ClosureTy1 v12, UH0 v13, double v14):
        v0 = self.v0
        v1 = self.v1
        v2 = self.v2
        v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef unsigned long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v15
        cdef char v16
        cdef US2 v17
        cdef UH0 v18
        cdef ClosureTy2 v19
        cdef US0 v20
        cdef ClosureTy0 v27
        cdef signed long v21
        cdef signed long v24
        cdef unsigned long v25
        cdef US2 v28
        cdef UH0 v29
        cdef US2 v30
        cdef UH0 v31
        cdef US0 v33
        cdef ClosureTy0 v40
        cdef signed long v34
        cdef signed long v37
        cdef unsigned long v38
        cdef US2 v41
        cdef UH0 v42
        cdef US2 v43
        cdef UH0 v44
        v15 = numpy.random.choice(v0)
        v16 = v8 == 0
        if v16:
            v17 = US2_1(v15)
            v18 = UH0_0(v17, v10)
            del v17
            v19 = v12.apply(v18)
            del v18
            v20 = v19.apply(v1)
            del v19
            if v20.tag == 0: # call
                v21 = 2
                v27 = method23(v2, v3, v21, v15, v7, v8, v9, v4, v5, v6)
            elif v20.tag == 1: # fold
                raise Exception("impossible")
            elif v20.tag == 2: # raise
                v24 = 1
                v25 = v6 + 4
                v27 = method23(v2, v3, v24, v15, v7, v8, v25, v4, v5, v6)
            del v20
            v28 = US2_1(v15)
            v29 = UH0_0(v28, v10)
            del v28
            v30 = US2_1(v15)
            v31 = UH0_0(v30, v13)
            del v30
            return v27.apply(v29, v11, v12, v31, v14)
        else:
            v33 = numpy.random.choice(v1)
            if v33.tag == 0: # call
                v34 = 2
                v40 = method23(v2, v3, v34, v15, v7, v8, v9, v4, v5, v6)
            elif v33.tag == 1: # fold
                raise Exception("impossible")
            elif v33.tag == 2: # raise
                v37 = 1
                v38 = v6 + 4
                v40 = method23(v2, v3, v37, v15, v7, v8, v38, v4, v5, v6)
            del v33
            v41 = US2_1(v15)
            v42 = UH0_0(v41, v10)
            del v41
            v43 = US2_1(v15)
            v44 = UH0_0(v43, v13)
            del v43
            return v40.apply(v42, v11, v12, v44, v14)
cdef class Closure5(ClosureTy0):
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
    def __init__(self, unsigned char v0, v1, v2, v3, v4, v5, signed long v6, US1 v7, unsigned char v8, unsigned long v9, US1 v10, unsigned long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    cpdef double apply(self, UH0 v12, double v13, ClosureTy1 v14, UH0 v15, double v16):
        cdef unsigned char v0 = self.v0
        v1 = self.v1
        v2 = self.v2
        v3 = self.v3
        v4 = self.v4
        v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef char v17
        cdef ClosureTy2 v18
        cdef US0 v19
        cdef ClosureTy0 v29
        cdef double v21
        cdef char v22
        cdef double v24
        cdef ClosureTy0 v25
        cdef signed long v26
        cdef unsigned long v27
        cdef US0 v31
        cdef ClosureTy0 v41
        cdef double v33
        cdef char v34
        cdef double v36
        cdef ClosureTy0 v37
        cdef signed long v38
        cdef unsigned long v39
        v17 = v0 == 0
        if v17:
            v18 = v14.apply(v12)
            v19 = v18.apply(v1)
            del v18
            if v19.tag == 0: # call
                v29 = method25(v4, v2, v3, v5, v7, v8, v9, v10, v0, v11)
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
                v29 = method24(v2, v3, v4, v5, v26, v10, v0, v27, v7, v8, v9)
            del v19
            return v29.apply(v12, v13, v14, v15, v16)
        else:
            v31 = numpy.random.choice(v1)
            if v31.tag == 0: # call
                v41 = method25(v4, v2, v3, v5, v10, v0, v11, v7, v8, v9)
            elif v31.tag == 1: # fold
                v33 = <double>v11
                v34 = v8 == 0
                if v34:
                    v36 = v33
                else:
                    v36 =  -v33
                v37 = Closure3(v36)
                v41 = v37
                del v37
            elif v31.tag == 2: # raise
                v38 = v6 - 1
                v39 = v9 + 2
                v41 = method24(v2, v3, v4, v5, v38, v10, v0, v39, v7, v8, v9)
            del v31
            return v41.apply(v12, v13, v14, v15, v16)
cdef class Closure0(ClosureTy0):
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
    def __init__(self, unsigned char v0, v1, v2, v3, v4, v5, signed long v6, US1 v7, unsigned char v8, unsigned long v9, US1 v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    cpdef double apply(self, UH0 v11, double v12, ClosureTy1 v13, UH0 v14, double v15):
        cdef unsigned char v0 = self.v0
        v1 = self.v1
        v2 = self.v2
        v3 = self.v3
        v4 = self.v4
        v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef unsigned long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef char v16
        cdef ClosureTy2 v17
        cdef US0 v18
        cdef ClosureTy0 v28
        cdef double v20
        cdef char v21
        cdef double v23
        cdef ClosureTy0 v24
        cdef signed long v25
        cdef unsigned long v26
        cdef US0 v30
        cdef ClosureTy0 v40
        cdef double v32
        cdef char v33
        cdef double v35
        cdef ClosureTy0 v36
        cdef signed long v37
        cdef unsigned long v38
        v16 = v0 == 0
        if v16:
            v17 = v13.apply(v11)
            v18 = v17.apply(v1)
            del v17
            if v18.tag == 0: # call
                v28 = method19(v4, v2, v3, v5, v7, v8, v9, v10, v0)
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
                v28 = method24(v2, v3, v4, v5, v25, v10, v0, v26, v7, v8, v9)
            del v18
            return v28.apply(v11, v12, v13, v14, v15)
        else:
            v30 = numpy.random.choice(v1)
            if v30.tag == 0: # call
                v40 = method19(v4, v2, v3, v5, v10, v0, v9, v7, v8)
            elif v30.tag == 1: # fold
                v32 = <double>v9
                v33 = v8 == 0
                if v33:
                    v35 = v32
                else:
                    v35 =  -v32
                v36 = Closure3(v35)
                v40 = v36
                del v36
            elif v30.tag == 2: # raise
                v37 = v6 - 1
                v38 = v9 + 2
                v40 = method24(v2, v3, v4, v5, v37, v10, v0, v38, v7, v8, v9)
            del v30
            return v40.apply(v11, v12, v13, v14, v15)
cdef class Closure8(ClosureTy2):
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    cpdef US0 apply(self, numpy.ndarray[object,ndim=1] v2):
        v0 = self.v0
        v1 = self.v1
        cdef numpy.ndarray[float,ndim=1] v3
        cdef unsigned long long v4
        cdef unsigned long long v5
        cdef unsigned long long v6
        cdef char v7
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
        method12(v4, v3, v5)
        v6 = len(v1)
        v7 = 2 < v6
        if v7:
            raise Exception("The given array is too large.")
        else:
            pass
        v8 = 0
        method13(v6, v3, v1, v8)
        v9 = torch.from_numpy(v3)
        del v3
        v10 = v0.forward(v9)
        del v9
        v11 = len(v2)
        v12 = numpy.empty(v11,dtype=numpy.int64)
        v13 = 0
        method15(v11, v2, v12, v13)
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
        return method17(v19)
cdef class Closure7(ClosureTy1):
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    cpdef ClosureTy2 apply(self, UH0 v1):
        v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v2
        v2 = method3(v1)
        return Closure8(v0, v2)
cdef void method2(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef char v7
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
cdef UH1 method5(UH1 v0, UH1 v1):
    cdef US0 v2
    cdef UH1 v3
    cdef UH1 v4
    if v1.tag == 0: # cons_
        v2 = (<UH1_0>v1).v0; v3 = (<UH1_0>v1).v1
        v4 = UH1_0(v2, v0)
        del v2
        return method5(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cdef unsigned long long method7(unsigned long long v0, UH1 v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v1
        v4 = v0 + 1
        return method7(v4, v3)
    elif v1.tag == 1: # nil
        return v0
cdef unsigned long long method8(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, UH1 v2):
    cdef US0 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v2.tag == 0: # cons_
        v3 = (<UH1_0>v2).v0; v4 = (<UH1_0>v2).v1
        v0[v1] = v3
        del v3
        v5 = v1 + 1
        return method8(v0, v5, v4)
    elif v2.tag == 1: # nil
        return v1
cdef numpy.ndarray[object,ndim=1] method6(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method7(v1, v0)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method8(v3, v4, v0)
    return v3
cdef UH2 method4(UH1 v0, US1 v1, UH0 v2):
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
            return method4(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH1_1()
            v10 = method5(v9, v0)
            del v9
            v11 = method6(v10)
            del v10
            v12 = UH1_1()
            v13 = method4(v12, v8, v4)
            del v4; del v8; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method5(v16, v0)
        del v16
        v18 = method6(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method10(unsigned long long v0, UH2 v1):
    cdef UH2 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v4 = (<UH2_0>v1).v2
        v5 = v0 + 1
        return method10(v5, v4)
    elif v1.tag == 1: # nil
        return v0
cdef unsigned long long method11(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, UH2 v2):
    cdef US1 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v2.tag == 0: # cons_
        v3 = (<UH2_0>v2).v0; v4 = (<UH2_0>v2).v1; v5 = (<UH2_0>v2).v2
        v0[v1] = Tuple0(v3, v4)
        del v3; del v4
        v6 = v1 + 1
        return method11(v0, v6, v5)
    elif v2.tag == 1: # nil
        return v1
cdef numpy.ndarray[object,ndim=1] method9(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method10(v1, v0)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method11(v3, v4, v0)
    return v3
cdef numpy.ndarray[object,ndim=1] method3(UH0 v0):
    cdef US2 v1
    cdef UH0 v2
    cdef US1 v5
    cdef UH1 v6
    cdef UH2 v7
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # action_
            del v2
            raise Exception("Expected a card.")
        elif v1.tag == 1: # observation_
            v5 = (<US2_1>v1).v0
            v6 = UH1_1()
            v7 = method4(v6, v5, v2)
            del v2; del v5; del v6
            return method9(v7)
    elif v0.tag == 1: # nil
        raise Exception("Expected a card.")
cdef void method12(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef char v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method12(v0, v1, v4)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef char v5
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
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method13(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Tuple0 tmp0
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef char v13
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
cdef signed long long method16(US0 v0):
    cdef signed long long v1
    if v0.tag == 0: # call
        v1 = 0
    elif v0.tag == 1: # fold
        v1 = 1
    elif v0.tag == 2: # raise
        v1 = 2
    return v1
cdef void method15(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef US0 v6
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
cdef US0 method17(signed long long v0):
    cdef char v1
    cdef char v2
    cdef char v3
    cdef char v4
    cdef char v5
    cdef char v7
    cdef signed long long v8
    cdef char v9
    cdef char v10
    cdef signed long long v12
    cdef char v13
    cdef char v14
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
cdef char method21(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple1 method22(signed long v0, signed long v1):
    cdef char v2
    v2 = v1 > v0
    if v2:
        return Tuple1(v1, v0)
    else:
        return Tuple1(v0, v1)
cdef ClosureTy0 method23(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed long v2, US1 v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8, unsigned long v9):
    cdef char v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef ClosureTy0 v12
    v10 = 0 < v2
    if v10:
        v11 = v0
    else:
        v11 = v1
    v12 = Closure4(v8, v11, v0, v1, v2, v3, v4, v5, v6, v7, v9)
    del v11
    return v12
cdef ClosureTy0 method20(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed long v2, US1 v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8):
    cdef char v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef ClosureTy0 v11
    v9 = 0 < v2
    if v9:
        v10 = v0
    else:
        v10 = v1
    v11 = Closure2(v8, v10, v0, v1, v2, v3, v4, v5, v6, v7)
    del v10
    return v11
cdef ClosureTy0 method19(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8):
    cdef ClosureTy0 v9
    v9 = Closure1(v3, v0, v1, v2, v4, v5, v6, v7, v8)
    return v9
cdef ClosureTy0 method25(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, US1 v4, unsigned char v5, unsigned long v6, US1 v7, unsigned char v8, unsigned long v9):
    cdef ClosureTy0 v10
    v10 = Closure6(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9)
    return v10
cdef ClosureTy0 method24(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9, unsigned long v10):
    cdef char v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef ClosureTy0 v13
    v11 = 0 < v4
    if v11:
        v12 = v0
    else:
        v12 = v1
    v13 = Closure5(v9, v12, v0, v1, v2, v3, v4, v5, v6, v7, v8, v10)
    del v12
    return v13
cdef ClosureTy0 method18(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, unsigned char v6, unsigned long v7, US1 v8, unsigned char v9):
    cdef char v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef ClosureTy0 v12
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
    cdef char v38
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
    cdef ClosureTy0 v64
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
    cdef UH0 v66
    cdef UH0 v67
    cdef ClosureTy1 v68
    cdef US2 v69
    cdef UH0 v70
    cdef UH0 v71
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
    method12(v35, v34, v36)
    v37 = len(v33)
    v38 = 2 < v37
    if v38:
        raise Exception("The given array is too large.")
    else:
        pass
    v39 = 0
    method13(v37, v34, v33, v39)
    del v33
    v40 = torch.from_numpy(v34)
    del v34
    v41 = v0.forward(v40)
    del v40
    v42 = len(v3)
    v43 = numpy.empty(v42,dtype=numpy.int64)
    v44 = 0
    method15(v42, v3, v43, v44)
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
    v51 = method17(v50)
    if v51.tag == 0: # call
        v52 = 2
        v53 = 1
        v54 = 1
        v55 = 0
        v64 = method18(v7, v10, v3, v28, v52, v20, v55, v54, v26, v53)
    elif v51.tag == 1: # fold
        raise Exception("impossible")
    elif v51.tag == 2: # raise
        v58 = 1
        v59 = 1
        v60 = 1
        v61 = 0
        v62 = 3
        v64 = method24(v7, v10, v3, v28, v58, v20, v61, v62, v26, v59, v60)
    del v3; del v7; del v10; del v28; del v51
    v65 = US2_1(v20)
    del v20
    v66 = UH0_1()
    v67 = UH0_0(v65, v66)
    del v65; del v66
    v68 = Closure7(v0)
    v69 = US2_1(v26)
    del v26
    v70 = UH0_1()
    v71 = UH0_0(v69, v70)
    del v69; del v70
    return v64.apply(v67, 1.000000, v68, v71, 1.000000)
cdef void method0(v0, unsigned long v1):
    cdef char v2
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
