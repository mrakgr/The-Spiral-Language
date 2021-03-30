import ui_leduc
import numpy
cimport numpy
cimport libc.math
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
cdef class Tuple0:
    cdef readonly UH0 v0
    cdef readonly double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class Mut0:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple1:
    cdef readonly UH0 v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    cdef readonly object v4
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple2:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure9():
    cdef US0 v0
    def __init__(self, US0 v0): self.v0 = v0
    def __call__(self):
        cdef US0 v0 = self.v0
        pass
cdef class Closure10():
    cdef US0 v0
    def __init__(self, US0 v0): self.v0 = v0
    def __call__(self):
        cdef US0 v0 = self.v0
        pass
cdef class Closure11():
    cdef US0 v0
    def __init__(self, US0 v0): self.v0 = v0
    def __call__(self):
        cdef US0 v0 = self.v0
        pass
cdef class Closure8():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef double v8
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, double v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef double v8 = self.v8
        cdef UH0 v9 = args.v0
        cdef double v10 = args.v1
        cdef UH0 v11 = args.v2
        cdef double v12 = args.v3
        cdef object v13 = args.v4
        cdef numpy.ndarray[object,ndim=1] v14
        cdef US3 v15
        cdef str v16
        cdef object v17
        cdef object v18
        cdef object v19
        cdef Mut0 v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef object v23
        cdef object v24
        cdef object v25
        cdef object v26
        cdef str v27
        cdef str v28
        cdef str v29
        cdef double v30
        v14 = numpy.empty(0,dtype=object)
        
        v15 = US3_1(v8)
        v16 = method3(v15, v9)
        del v15
        v0.trace = v16
        del v16
        v17 = False
        v18 = False
        v19 = False
        v20 = Mut0(v18, v17, v19)
        del v17; del v18; del v19
        v21 = len(v14)
        v22 = 0
        method14(v21, v14, v20, v22)
        del v14
        v23 = v20.v1
        v24 = v20.v0
        v25 = v20.v2
        del v20
        v26 = {'fold': v23, 'call': v24, 'raise': v25}
        del v26
        v0.actions = {'fold': v23, 'call': v24, 'raise': v25}
        del v23; del v24; del v25
        if v1.tag == 0: # jack
            v27 = 'J'
        elif v1.tag == 1: # king
            v27 = 'K'
        elif v1.tag == 2: # queen
            v27 = 'Q'
        if v4.tag == 0: # jack
            v28 = 'J'
        elif v4.tag == 1: # king
            v28 = 'K'
        elif v4.tag == 2: # queen
            v28 = 'Q'
        if v7.tag == 0: # jack
            v29 = 'J'
        elif v7.tag == 1: # king
            v29 = 'K'
        elif v7.tag == 2: # queen
            v29 = 'Q'
        v0.table_data = {'my_card': v27, 'my_pot': v3, 'op_card': v28, 'op_pot': v6, 'community_card': v29}
        del v27; del v28; del v29
        v30 =  -v8
        v13(v8)
cdef class Closure7():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef US0 v17 = self.v17
        cdef object v108
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
        cdef Tuple2 tmp4
        cdef signed long v33
        cdef signed long v34
        cdef Tuple2 tmp5
        cdef bint v35
        cdef signed long v38
        cdef bint v36
        cdef bint v39
        cdef bint v40
        cdef bint v41
        cdef bint v48
        cdef bint v49
        cdef signed long v51
        cdef US1 v52
        cdef unsigned char v53
        cdef signed long v54
        cdef US1 v55
        cdef unsigned char v56
        cdef signed long v57
        cdef signed long v58
        cdef signed long v59
        cdef signed long v60
        cdef double v61
        cdef bint v63
        cdef bint v64
        cdef signed long v66
        cdef bint v67
        cdef US1 v68
        cdef unsigned char v69
        cdef signed long v70
        cdef US1 v71
        cdef unsigned char v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef signed long v76
        cdef double v77
        cdef bint v79
        cdef US1 v80
        cdef unsigned char v81
        cdef signed long v82
        cdef US1 v83
        cdef unsigned char v84
        cdef signed long v85
        cdef double v86
        cdef bint v90
        cdef signed long v92
        cdef bint v93
        cdef US1 v94
        cdef unsigned char v95
        cdef signed long v96
        cdef US1 v97
        cdef unsigned char v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef signed long v102
        cdef double v103
        cdef signed long v105
        cdef signed long v106
        cdef US2 v109
        cdef UH0 v110
        cdef US2 v111
        cdef UH0 v112
        if v17.tag == 0: # call
            if v11.tag == 0: # jack
                v18 = 0
            elif v11.tag == 1: # king
                v18 = 2
            elif v11.tag == 2: # queen
                v18 = 1
            if v7.tag == 0: # jack
                v19 = 0
            elif v7.tag == 1: # king
                v19 = 2
            elif v7.tag == 2: # queen
                v19 = 1
            if v8.tag == 0: # jack
                v20 = 0
            elif v8.tag == 1: # king
                v20 = 2
            elif v8.tag == 2: # queen
                v20 = 1
            if v7.tag == 0: # jack
                v21 = 0
            elif v7.tag == 1: # king
                v21 = 2
            elif v7.tag == 2: # queen
                v21 = 1
            v22 = method12(v19, v18)
            if v22:
                v24 = method12(v21, v20)
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
                v29 = method12(v19, v18)
                if v29:
                    v47 = 1
                else:
                    v30 = method12(v21, v20)
                    if v30:
                        v47 = -1
                    else:
                        tmp4 = method13(v19, v18)
                        v31, v32 = tmp4.v0, tmp4.v1
                        del tmp4
                        tmp5 = method13(v21, v20)
                        v33, v34 = tmp5.v0, tmp5.v1
                        del tmp5
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
                v49 = v12 == 0
                if v49:
                    v51 = v10
                else:
                    v51 =  -v10
                if v49:
                    v52, v53, v54, v55, v56, v57 = v11, v12, v10, v8, v9, v10
                else:
                    v52, v53, v54, v55, v56, v57 = v8, v9, v10, v11, v12, v10
                v58 = v51 + v54
                v59 =  -v51
                v60 = v59 + v57
                v61 = <double>v51
                v108 = Closure8(v2, v52, v53, v58, v55, v56, v60, v7, v61)
                del v52; del v55
            else:
                v63 = v47 == -1
                if v63:
                    v64 = v9 == 0
                    if v64:
                        v66 = v10
                    else:
                        v66 =  -v10
                    v67 = v12 == 0
                    if v67:
                        v68, v69, v70, v71, v72, v73 = v11, v12, v10, v8, v9, v10
                    else:
                        v68, v69, v70, v71, v72, v73 = v8, v9, v10, v11, v12, v10
                    v74 = v66 + v70
                    v75 =  -v66
                    v76 = v75 + v73
                    v77 = <double>v66
                    v108 = Closure8(v2, v68, v69, v74, v71, v72, v76, v7, v77)
                    del v68; del v71
                else:
                    v79 = v12 == 0
                    if v79:
                        v80, v81, v82, v83, v84, v85 = v11, v12, v10, v8, v9, v10
                    else:
                        v80, v81, v82, v83, v84, v85 = v8, v9, v10, v11, v12, v10
                    v86 = <double>0
                    v108 = Closure8(v2, v80, v81, v82, v83, v84, v85, v7, v86)
                    del v80; del v83
        elif v17.tag == 1: # fold
            v90 = v9 == 0
            if v90:
                v92 = v13
            else:
                v92 =  -v13
            v93 = v12 == 0
            if v93:
                v94, v95, v96, v97, v98, v99 = v11, v12, v13, v8, v9, v10
            else:
                v94, v95, v96, v97, v98, v99 = v8, v9, v10, v11, v12, v13
            v100 = v92 + v96
            v101 =  -v92
            v102 = v101 + v99
            v103 = <double>v92
            v108 = Closure8(v2, v94, v95, v100, v97, v98, v102, v7, v103)
            del v94; del v97
        elif v17.tag == 2: # raise
            v105 = v6 - 1
            v106 = v10 + 4
            v108 = method10(v2, v3, v4, v5, v105, v7, v11, v12, v106, v8, v9, v10)
        v109 = US2_0(v17)
        v110 = UH0_0(v109, v0)
        del v109
        v111 = US2_0(v17)
        v112 = UH0_0(v111, v15)
        del v111
        v108(Tuple1(v110, v1, v112, v16, v14))
cdef class Closure12():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef US0 v17 = self.v17
        cdef object v108
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
        cdef Tuple2 tmp6
        cdef signed long v33
        cdef signed long v34
        cdef Tuple2 tmp7
        cdef bint v35
        cdef signed long v38
        cdef bint v36
        cdef bint v39
        cdef bint v40
        cdef bint v41
        cdef bint v48
        cdef bint v49
        cdef signed long v51
        cdef US1 v52
        cdef unsigned char v53
        cdef signed long v54
        cdef US1 v55
        cdef unsigned char v56
        cdef signed long v57
        cdef signed long v58
        cdef signed long v59
        cdef signed long v60
        cdef double v61
        cdef bint v63
        cdef bint v64
        cdef signed long v66
        cdef bint v67
        cdef US1 v68
        cdef unsigned char v69
        cdef signed long v70
        cdef US1 v71
        cdef unsigned char v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef signed long v76
        cdef double v77
        cdef bint v79
        cdef US1 v80
        cdef unsigned char v81
        cdef signed long v82
        cdef US1 v83
        cdef unsigned char v84
        cdef signed long v85
        cdef double v86
        cdef bint v90
        cdef signed long v92
        cdef bint v93
        cdef US1 v94
        cdef unsigned char v95
        cdef signed long v96
        cdef US1 v97
        cdef unsigned char v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef signed long v102
        cdef double v103
        cdef signed long v105
        cdef signed long v106
        cdef US2 v109
        cdef UH0 v110
        cdef US2 v111
        cdef UH0 v112
        if v17.tag == 0: # call
            if v11.tag == 0: # jack
                v18 = 0
            elif v11.tag == 1: # king
                v18 = 2
            elif v11.tag == 2: # queen
                v18 = 1
            if v7.tag == 0: # jack
                v19 = 0
            elif v7.tag == 1: # king
                v19 = 2
            elif v7.tag == 2: # queen
                v19 = 1
            if v8.tag == 0: # jack
                v20 = 0
            elif v8.tag == 1: # king
                v20 = 2
            elif v8.tag == 2: # queen
                v20 = 1
            if v7.tag == 0: # jack
                v21 = 0
            elif v7.tag == 1: # king
                v21 = 2
            elif v7.tag == 2: # queen
                v21 = 1
            v22 = method12(v19, v18)
            if v22:
                v24 = method12(v21, v20)
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
                v29 = method12(v19, v18)
                if v29:
                    v47 = 1
                else:
                    v30 = method12(v21, v20)
                    if v30:
                        v47 = -1
                    else:
                        tmp6 = method13(v19, v18)
                        v31, v32 = tmp6.v0, tmp6.v1
                        del tmp6
                        tmp7 = method13(v21, v20)
                        v33, v34 = tmp7.v0, tmp7.v1
                        del tmp7
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
                v49 = v12 == 0
                if v49:
                    v51 = v10
                else:
                    v51 =  -v10
                if v49:
                    v52, v53, v54, v55, v56, v57 = v11, v12, v10, v8, v9, v10
                else:
                    v52, v53, v54, v55, v56, v57 = v8, v9, v10, v11, v12, v10
                v58 = v51 + v54
                v59 =  -v51
                v60 = v59 + v57
                v61 = <double>v51
                v108 = Closure8(v2, v52, v53, v58, v55, v56, v60, v7, v61)
                del v52; del v55
            else:
                v63 = v47 == -1
                if v63:
                    v64 = v9 == 0
                    if v64:
                        v66 = v10
                    else:
                        v66 =  -v10
                    v67 = v12 == 0
                    if v67:
                        v68, v69, v70, v71, v72, v73 = v11, v12, v10, v8, v9, v10
                    else:
                        v68, v69, v70, v71, v72, v73 = v8, v9, v10, v11, v12, v10
                    v74 = v66 + v70
                    v75 =  -v66
                    v76 = v75 + v73
                    v77 = <double>v66
                    v108 = Closure8(v2, v68, v69, v74, v71, v72, v76, v7, v77)
                    del v68; del v71
                else:
                    v79 = v12 == 0
                    if v79:
                        v80, v81, v82, v83, v84, v85 = v11, v12, v10, v8, v9, v10
                    else:
                        v80, v81, v82, v83, v84, v85 = v8, v9, v10, v11, v12, v10
                    v86 = <double>0
                    v108 = Closure8(v2, v80, v81, v82, v83, v84, v85, v7, v86)
                    del v80; del v83
        elif v17.tag == 1: # fold
            v90 = v9 == 0
            if v90:
                v92 = v13
            else:
                v92 =  -v13
            v93 = v12 == 0
            if v93:
                v94, v95, v96, v97, v98, v99 = v11, v12, v13, v8, v9, v10
            else:
                v94, v95, v96, v97, v98, v99 = v8, v9, v10, v11, v12, v13
            v100 = v92 + v96
            v101 =  -v92
            v102 = v101 + v99
            v103 = <double>v92
            v108 = Closure8(v2, v94, v95, v100, v97, v98, v102, v7, v103)
            del v94; del v97
        elif v17.tag == 2: # raise
            v105 = v6 - 1
            v106 = v10 + 4
            v108 = method10(v2, v3, v4, v5, v105, v7, v11, v12, v106, v8, v9, v10)
        v109 = US2_0(v17)
        v110 = UH0_0(v109, v0)
        del v109
        v111 = US2_0(v17)
        v112 = UH0_0(v111, v15)
        del v111
        v108(Tuple1(v110, v1, v112, v16, v14))
cdef class Closure13():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef US0 v17 = self.v17
        cdef object v108
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
        cdef Tuple2 tmp8
        cdef signed long v33
        cdef signed long v34
        cdef Tuple2 tmp9
        cdef bint v35
        cdef signed long v38
        cdef bint v36
        cdef bint v39
        cdef bint v40
        cdef bint v41
        cdef bint v48
        cdef bint v49
        cdef signed long v51
        cdef US1 v52
        cdef unsigned char v53
        cdef signed long v54
        cdef US1 v55
        cdef unsigned char v56
        cdef signed long v57
        cdef signed long v58
        cdef signed long v59
        cdef signed long v60
        cdef double v61
        cdef bint v63
        cdef bint v64
        cdef signed long v66
        cdef bint v67
        cdef US1 v68
        cdef unsigned char v69
        cdef signed long v70
        cdef US1 v71
        cdef unsigned char v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef signed long v76
        cdef double v77
        cdef bint v79
        cdef US1 v80
        cdef unsigned char v81
        cdef signed long v82
        cdef US1 v83
        cdef unsigned char v84
        cdef signed long v85
        cdef double v86
        cdef bint v90
        cdef signed long v92
        cdef bint v93
        cdef US1 v94
        cdef unsigned char v95
        cdef signed long v96
        cdef US1 v97
        cdef unsigned char v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef signed long v102
        cdef double v103
        cdef signed long v105
        cdef signed long v106
        cdef US2 v109
        cdef UH0 v110
        cdef US2 v111
        cdef UH0 v112
        if v17.tag == 0: # call
            if v11.tag == 0: # jack
                v18 = 0
            elif v11.tag == 1: # king
                v18 = 2
            elif v11.tag == 2: # queen
                v18 = 1
            if v7.tag == 0: # jack
                v19 = 0
            elif v7.tag == 1: # king
                v19 = 2
            elif v7.tag == 2: # queen
                v19 = 1
            if v8.tag == 0: # jack
                v20 = 0
            elif v8.tag == 1: # king
                v20 = 2
            elif v8.tag == 2: # queen
                v20 = 1
            if v7.tag == 0: # jack
                v21 = 0
            elif v7.tag == 1: # king
                v21 = 2
            elif v7.tag == 2: # queen
                v21 = 1
            v22 = method12(v19, v18)
            if v22:
                v24 = method12(v21, v20)
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
                v29 = method12(v19, v18)
                if v29:
                    v47 = 1
                else:
                    v30 = method12(v21, v20)
                    if v30:
                        v47 = -1
                    else:
                        tmp8 = method13(v19, v18)
                        v31, v32 = tmp8.v0, tmp8.v1
                        del tmp8
                        tmp9 = method13(v21, v20)
                        v33, v34 = tmp9.v0, tmp9.v1
                        del tmp9
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
                v49 = v12 == 0
                if v49:
                    v51 = v10
                else:
                    v51 =  -v10
                if v49:
                    v52, v53, v54, v55, v56, v57 = v11, v12, v10, v8, v9, v10
                else:
                    v52, v53, v54, v55, v56, v57 = v8, v9, v10, v11, v12, v10
                v58 = v51 + v54
                v59 =  -v51
                v60 = v59 + v57
                v61 = <double>v51
                v108 = Closure8(v2, v52, v53, v58, v55, v56, v60, v7, v61)
                del v52; del v55
            else:
                v63 = v47 == -1
                if v63:
                    v64 = v9 == 0
                    if v64:
                        v66 = v10
                    else:
                        v66 =  -v10
                    v67 = v12 == 0
                    if v67:
                        v68, v69, v70, v71, v72, v73 = v11, v12, v10, v8, v9, v10
                    else:
                        v68, v69, v70, v71, v72, v73 = v8, v9, v10, v11, v12, v10
                    v74 = v66 + v70
                    v75 =  -v66
                    v76 = v75 + v73
                    v77 = <double>v66
                    v108 = Closure8(v2, v68, v69, v74, v71, v72, v76, v7, v77)
                    del v68; del v71
                else:
                    v79 = v12 == 0
                    if v79:
                        v80, v81, v82, v83, v84, v85 = v11, v12, v10, v8, v9, v10
                    else:
                        v80, v81, v82, v83, v84, v85 = v8, v9, v10, v11, v12, v10
                    v86 = <double>0
                    v108 = Closure8(v2, v80, v81, v82, v83, v84, v85, v7, v86)
                    del v80; del v83
        elif v17.tag == 1: # fold
            v90 = v9 == 0
            if v90:
                v92 = v13
            else:
                v92 =  -v13
            v93 = v12 == 0
            if v93:
                v94, v95, v96, v97, v98, v99 = v11, v12, v13, v8, v9, v10
            else:
                v94, v95, v96, v97, v98, v99 = v8, v9, v10, v11, v12, v13
            v100 = v92 + v96
            v101 =  -v92
            v102 = v101 + v99
            v103 = <double>v92
            v108 = Closure8(v2, v94, v95, v100, v97, v98, v102, v7, v103)
            del v94; del v97
        elif v17.tag == 2: # raise
            v105 = v6 - 1
            v106 = v10 + 4
            v108 = method10(v2, v3, v4, v5, v105, v7, v11, v12, v106, v8, v9, v10)
        v109 = US2_0(v17)
        v110 = UH0_0(v109, v0)
        del v109
        v111 = US2_0(v17)
        v112 = UH0_0(v111, v15)
        del v111
        v108(Tuple1(v110, v1, v112, v16, v14))
cdef class Closure14():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef US1 v6
    cdef double v7
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, US1 v6, double v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef US1 v6 = self.v6
        cdef double v7 = self.v7
        cdef UH0 v8 = args.v0
        cdef double v9 = args.v1
        cdef UH0 v10 = args.v2
        cdef double v11 = args.v3
        cdef object v12 = args.v4
        cdef numpy.ndarray[object,ndim=1] v13
        cdef US3 v14
        cdef str v15
        cdef object v16
        cdef object v17
        cdef object v18
        cdef Mut0 v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef object v22
        cdef object v23
        cdef object v24
        cdef object v25
        cdef str v26
        cdef str v27
        cdef str v28
        cdef double v29
        v13 = numpy.empty(0,dtype=object)
        
        v14 = US3_1(v7)
        v15 = method3(v14, v8)
        del v14
        v0.trace = v15
        del v15
        v16 = False
        v17 = False
        v18 = False
        v19 = Mut0(v17, v16, v18)
        del v16; del v17; del v18
        v20 = len(v13)
        v21 = 0
        method14(v20, v13, v19, v21)
        del v13
        v22 = v19.v1
        v23 = v19.v0
        v24 = v19.v2
        del v19
        v25 = {'fold': v22, 'call': v23, 'raise': v24}
        del v25
        v0.actions = {'fold': v22, 'call': v23, 'raise': v24}
        del v22; del v23; del v24
        if v1.tag == 0: # jack
            v26 = 'J'
        elif v1.tag == 1: # king
            v26 = 'K'
        elif v1.tag == 2: # queen
            v26 = 'Q'
        if v4.tag == 0: # jack
            v27 = 'J'
        elif v4.tag == 1: # king
            v27 = 'K'
        elif v4.tag == 2: # queen
            v27 = 'Q'
        if v6.tag == 0: # jack
            v28 = 'J'
        elif v6.tag == 1: # king
            v28 = 'K'
        elif v6.tag == 2: # queen
            v28 = 'Q'
        v0.table_data = {'my_card': v26, 'my_pot': v3, 'op_card': v27, 'op_pot': v3, 'community_card': v28}
        del v26; del v27; del v28
        v29 =  -v7
        v12(v7)
cdef class Closure6():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef signed long v12
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[object,ndim=1] v11, signed long v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed long v12 = self.v12
        cdef UH0 v13 = args.v0
        cdef double v14 = args.v1
        cdef UH0 v15 = args.v2
        cdef double v16 = args.v3
        cdef object v17 = args.v4
        cdef bint v18
        cdef US3 v19
        cdef str v20
        cdef object v21
        cdef object v22
        cdef object v23
        cdef Mut0 v24
        cdef unsigned long long v25
        cdef unsigned long long v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef object v30
        cdef str v31
        cdef str v32
        cdef str v33
        cdef US0 v34
        cdef unsigned long long v35
        cdef double v36
        cdef double v37
        cdef double v38
        cdef object v100
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
        cdef Tuple2 tmp10
        cdef signed long v54
        cdef signed long v55
        cdef Tuple2 tmp11
        cdef bint v56
        cdef signed long v59
        cdef bint v57
        cdef bint v60
        cdef bint v61
        cdef bint v62
        cdef bint v69
        cdef signed long v70
        cdef signed long v71
        cdef signed long v72
        cdef signed long v73
        cdef double v74
        cdef bint v76
        cdef bint v77
        cdef signed long v79
        cdef signed long v80
        cdef signed long v81
        cdef signed long v82
        cdef double v83
        cdef double v85
        cdef bint v89
        cdef signed long v91
        cdef signed long v92
        cdef signed long v93
        cdef signed long v94
        cdef double v95
        cdef signed long v97
        cdef signed long v98
        cdef double v101
        cdef US2 v102
        cdef UH0 v103
        cdef US2 v104
        cdef UH0 v105
        v18 = v2 == 0
        if v18:
            v19 = US3_0()
            v20 = method3(v19, v13)
            del v19
            v0.trace = v20
            del v20
            v21 = False
            v22 = False
            v23 = False
            v24 = Mut0(v22, v21, v23)
            del v21; del v22; del v23
            v25 = len(v8)
            v26 = 0
            method11(v25, v8, v13, v14, v0, v9, v10, v11, v12, v7, v4, v5, v6, v1, v2, v3, v17, v15, v16, v24, v26)
            v27 = v24.v1
            v28 = v24.v0
            v29 = v24.v2
            del v24
            v30 = {'fold': v27, 'call': v28, 'raise': v29}
            del v30
            v0.actions = {'fold': v27, 'call': v28, 'raise': v29}
            del v27; del v28; del v29
            if v1.tag == 0: # jack
                v31 = 'J'
            elif v1.tag == 1: # king
                v31 = 'K'
            elif v1.tag == 2: # queen
                v31 = 'Q'
            if v4.tag == 0: # jack
                v32 = 'J'
            elif v4.tag == 1: # king
                v32 = 'K'
            elif v4.tag == 2: # queen
                v32 = 'Q'
            if v7.tag == 0: # jack
                v33 = 'J'
            elif v7.tag == 1: # king
                v33 = 'K'
            elif v7.tag == 2: # queen
                v33 = 'Q'
            v0.table_data = {'my_card': v31, 'my_pot': v3, 'op_card': v32, 'op_pot': v6, 'community_card': v33}
        else:
            v34 = numpy.random.choice(v8)
            v35 = len(v8)
            v36 = <double>v35
            v37 = 1.000000 / v36
            v38 = libc.math.log(v37)
            if v34.tag == 0: # call
                if v1.tag == 0: # jack
                    v39 = 0
                elif v1.tag == 1: # king
                    v39 = 2
                elif v1.tag == 2: # queen
                    v39 = 1
                if v7.tag == 0: # jack
                    v40 = 0
                elif v7.tag == 1: # king
                    v40 = 2
                elif v7.tag == 2: # queen
                    v40 = 1
                if v4.tag == 0: # jack
                    v41 = 0
                elif v4.tag == 1: # king
                    v41 = 2
                elif v4.tag == 2: # queen
                    v41 = 1
                if v7.tag == 0: # jack
                    v42 = 0
                elif v7.tag == 1: # king
                    v42 = 2
                elif v7.tag == 2: # queen
                    v42 = 1
                v43 = method12(v40, v39)
                if v43:
                    v45 = method12(v42, v41)
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
                    v50 = method12(v40, v39)
                    if v50:
                        v68 = 1
                    else:
                        v51 = method12(v42, v41)
                        if v51:
                            v68 = -1
                        else:
                            tmp10 = method13(v40, v39)
                            v52, v53 = tmp10.v0, tmp10.v1
                            del tmp10
                            tmp11 = method13(v42, v41)
                            v54, v55 = tmp11.v0, tmp11.v1
                            del tmp11
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
                    v70 =  -v6
                    v71 = v70 + v6
                    v72 =  -v70
                    v73 = v72 + v6
                    v74 = <double>v70
                    v100 = Closure8(v0, v4, v5, v71, v1, v2, v73, v7, v74)
                else:
                    v76 = v68 == -1
                    if v76:
                        v77 = v5 == 0
                        if v77:
                            v79 = v6
                        else:
                            v79 =  -v6
                        v80 = v79 + v6
                        v81 =  -v79
                        v82 = v81 + v6
                        v83 = <double>v79
                        v100 = Closure8(v0, v4, v5, v80, v1, v2, v82, v7, v83)
                    else:
                        v85 = <double>0
                        v100 = Closure14(v0, v4, v5, v6, v1, v2, v7, v85)
            elif v34.tag == 1: # fold
                v89 = v5 == 0
                if v89:
                    v91 = v3
                else:
                    v91 =  -v3
                v92 = v91 + v6
                v93 =  -v91
                v94 = v93 + v3
                v95 = <double>v91
                v100 = Closure8(v0, v4, v5, v92, v1, v2, v94, v7, v95)
            elif v34.tag == 2: # raise
                v97 = v12 - 1
                v98 = v6 + 4
                v100 = method10(v0, v9, v10, v11, v97, v7, v1, v2, v98, v4, v5, v6)
            v101 = v38 + v16
            v102 = US2_0(v34)
            v103 = UH0_0(v102, v13)
            del v102
            v104 = US2_0(v34)
            del v34
            v105 = UH0_0(v104, v15)
            del v104
            v100(Tuple1(v103, v14, v105, v101, v17))
cdef class Closure5():
    cdef US1 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef US1 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US1 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, US1 v0, UH0 v1, double v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, signed long v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef US1 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v23
        cdef signed long v17
        cdef signed long v20
        cdef signed long v21
        cdef US2 v24
        cdef US2 v25
        cdef UH0 v26
        cdef UH0 v27
        cdef US2 v28
        cdef US2 v29
        cdef UH0 v30
        cdef UH0 v31
        if v16.tag == 0: # call
            v17 = 2
            v23 = method10(v3, v4, v5, v6, v17, v0, v10, v11, v12, v7, v8, v9)
        elif v16.tag == 1: # fold
            raise Exception("impossible")
        elif v16.tag == 2: # raise
            v20 = 1
            v21 = v9 + 4
            v23 = method10(v3, v4, v5, v6, v20, v0, v10, v11, v21, v7, v8, v9)
        v24 = US2_0(v16)
        v25 = US2_1(v0)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = UH0_0(v24, v26)
        del v24; del v26
        v28 = US2_0(v16)
        v29 = US2_1(v0)
        v30 = UH0_0(v29, v14)
        del v29
        v31 = UH0_0(v28, v30)
        del v28; del v30
        v23(Tuple1(v27, v2, v31, v15, v13))
cdef class Closure15():
    cdef US1 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef US1 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US1 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, US1 v0, UH0 v1, double v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, signed long v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef US1 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v23
        cdef signed long v17
        cdef signed long v20
        cdef signed long v21
        cdef US2 v24
        cdef US2 v25
        cdef UH0 v26
        cdef UH0 v27
        cdef US2 v28
        cdef US2 v29
        cdef UH0 v30
        cdef UH0 v31
        if v16.tag == 0: # call
            v17 = 2
            v23 = method10(v3, v4, v5, v6, v17, v0, v10, v11, v12, v7, v8, v9)
        elif v16.tag == 1: # fold
            raise Exception("impossible")
        elif v16.tag == 2: # raise
            v20 = 1
            v21 = v9 + 4
            v23 = method10(v3, v4, v5, v6, v20, v0, v10, v11, v21, v7, v8, v9)
        v24 = US2_0(v16)
        v25 = US2_1(v0)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = UH0_0(v24, v26)
        del v24; del v26
        v28 = US2_0(v16)
        v29 = US2_1(v0)
        v30 = UH0_0(v29, v14)
        del v29
        v31 = UH0_0(v28, v30)
        del v28; del v30
        v23(Tuple1(v27, v2, v31, v15, v13))
cdef class Closure16():
    cdef US1 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef US1 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US1 v10
    cdef unsigned char v11
    cdef signed long v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, US1 v0, UH0 v1, double v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, signed long v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef US1 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed long v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v23
        cdef signed long v17
        cdef signed long v20
        cdef signed long v21
        cdef US2 v24
        cdef US2 v25
        cdef UH0 v26
        cdef UH0 v27
        cdef US2 v28
        cdef US2 v29
        cdef UH0 v30
        cdef UH0 v31
        if v16.tag == 0: # call
            v17 = 2
            v23 = method10(v3, v4, v5, v6, v17, v0, v10, v11, v12, v7, v8, v9)
        elif v16.tag == 1: # fold
            raise Exception("impossible")
        elif v16.tag == 2: # raise
            v20 = 1
            v21 = v9 + 4
            v23 = method10(v3, v4, v5, v6, v20, v0, v10, v11, v21, v7, v8, v9)
        v24 = US2_0(v16)
        v25 = US2_1(v0)
        v26 = UH0_0(v25, v1)
        del v25
        v27 = UH0_0(v24, v26)
        del v24; del v26
        v28 = US2_0(v16)
        v29 = US2_1(v0)
        v30 = UH0_0(v29, v14)
        del v29
        v31 = UH0_0(v28, v30)
        del v28; del v30
        v23(Tuple1(v27, v2, v31, v15, v13))
cdef class Closure4():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef US1 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US1 v9
    cdef unsigned char v10
    cdef signed long v11
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple1 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = args.v0
        cdef double v13 = args.v1
        cdef UH0 v14 = args.v2
        cdef double v15 = args.v3
        cdef object v16 = args.v4
        cdef US1 v17
        cdef unsigned long long v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef bint v24
        cdef US2 v25
        cdef UH0 v26
        cdef US3 v27
        cdef str v28
        cdef object v29
        cdef object v30
        cdef object v31
        cdef Mut0 v32
        cdef unsigned long long v33
        cdef unsigned long long v34
        cdef object v35
        cdef object v36
        cdef object v37
        cdef object v38
        cdef str v39
        cdef str v40
        cdef str v41
        cdef US0 v42
        cdef unsigned long long v43
        cdef double v44
        cdef double v45
        cdef double v46
        cdef object v53
        cdef signed long v47
        cdef signed long v50
        cdef signed long v51
        cdef double v54
        cdef US2 v55
        cdef US2 v56
        cdef UH0 v57
        cdef UH0 v58
        cdef US2 v59
        cdef US2 v60
        cdef UH0 v61
        cdef UH0 v62
        v17 = v1[v0]
        v18 = len(v1)
        v19 = <double>v18
        v20 = 1.000000 / v19
        v21 = libc.math.log(v20)
        v22 = v21 + v13
        v23 = v21 + v15
        v24 = v10 == 0
        if v24:
            v25 = US2_1(v17)
            v26 = UH0_0(v25, v12)
            del v25
            v27 = US3_0()
            v28 = method3(v27, v26)
            del v26; del v27
            v2.trace = v28
            del v28
            v29 = False
            v30 = False
            v31 = False
            v32 = Mut0(v30, v29, v31)
            del v29; del v30; del v31
            v33 = len(v3)
            v34 = 0
            method9(v33, v3, v17, v12, v22, v2, v4, v5, v6, v7, v8, v9, v10, v11, v16, v14, v23, v32, v34)
            v35 = v32.v1
            v36 = v32.v0
            v37 = v32.v2
            del v32
            v38 = {'fold': v35, 'call': v36, 'raise': v37}
            del v38
            v2.actions = {'fold': v35, 'call': v36, 'raise': v37}
            del v35; del v36; del v37
            if v9.tag == 0: # jack
                v39 = 'J'
            elif v9.tag == 1: # king
                v39 = 'K'
            elif v9.tag == 2: # queen
                v39 = 'Q'
            if v6.tag == 0: # jack
                v40 = 'J'
            elif v6.tag == 1: # king
                v40 = 'K'
            elif v6.tag == 2: # queen
                v40 = 'Q'
            if v17.tag == 0: # jack
                v41 = 'J'
            elif v17.tag == 1: # king
                v41 = 'K'
            elif v17.tag == 2: # queen
                v41 = 'Q'
            v2.table_data = {'my_card': v39, 'my_pot': v11, 'op_card': v40, 'op_pot': v8, 'community_card': v41}
        else:
            v42 = numpy.random.choice(v3)
            v43 = len(v3)
            v44 = <double>v43
            v45 = 1.000000 / v44
            v46 = libc.math.log(v45)
            if v42.tag == 0: # call
                v47 = 2
                v53 = method10(v2, v3, v4, v5, v47, v17, v9, v10, v11, v6, v7, v8)
            elif v42.tag == 1: # fold
                raise Exception("impossible")
            elif v42.tag == 2: # raise
                v50 = 1
                v51 = v8 + 4
                v53 = method10(v2, v3, v4, v5, v50, v17, v9, v10, v51, v6, v7, v8)
            v54 = v46 + v23
            v55 = US2_0(v42)
            v56 = US2_1(v17)
            v57 = UH0_0(v56, v12)
            del v56
            v58 = UH0_0(v55, v57)
            del v55; del v57
            v59 = US2_0(v42)
            del v42
            v60 = US2_1(v17)
            v61 = UH0_0(v60, v14)
            del v60
            v62 = UH0_0(v59, v61)
            del v59; del v61
            v53(Tuple1(v58, v22, v62, v54, v16))
cdef class Closure17():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef double v7
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, double v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef double v7 = self.v7
        cdef UH0 v8 = args.v0
        cdef double v9 = args.v1
        cdef UH0 v10 = args.v2
        cdef double v11 = args.v3
        cdef object v12 = args.v4
        cdef numpy.ndarray[object,ndim=1] v13
        cdef US3 v14
        cdef str v15
        cdef object v16
        cdef object v17
        cdef object v18
        cdef Mut0 v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef object v22
        cdef object v23
        cdef object v24
        cdef object v25
        cdef str v26
        cdef str v27
        cdef double v28
        v13 = numpy.empty(0,dtype=object)
        
        v14 = US3_1(v7)
        v15 = method3(v14, v8)
        del v14
        v0.trace = v15
        del v15
        v16 = False
        v17 = False
        v18 = False
        v19 = Mut0(v17, v16, v18)
        del v16; del v17; del v18
        v20 = len(v13)
        v21 = 0
        method14(v20, v13, v19, v21)
        del v13
        v22 = v19.v1
        v23 = v19.v0
        v24 = v19.v2
        del v19
        v25 = {'fold': v22, 'call': v23, 'raise': v24}
        del v25
        v0.actions = {'fold': v22, 'call': v23, 'raise': v24}
        del v22; del v23; del v24
        if v1.tag == 0: # jack
            v26 = 'J'
        elif v1.tag == 1: # king
            v26 = 'K'
        elif v1.tag == 2: # queen
            v26 = 'Q'
        if v4.tag == 0: # jack
            v27 = 'J'
        elif v4.tag == 1: # king
            v27 = 'K'
        elif v4.tag == 2: # queen
            v27 = 'Q'
        v0.table_data = {'my_card': v26, 'my_pot': v3, 'op_card': v27, 'op_pot': v6, 'community_card': ' '}
        del v26; del v27
        v28 =  -v7
        v12(v7)
cdef class Closure19():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef US0 v17 = self.v17
        cdef object v44
        cdef bint v18
        cdef US1 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US1 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef bint v26
        cdef signed long v28
        cdef bint v29
        cdef US1 v30
        cdef unsigned char v31
        cdef signed long v32
        cdef US1 v33
        cdef unsigned char v34
        cdef signed long v35
        cdef signed long v36
        cdef signed long v37
        cdef signed long v38
        cdef double v39
        cdef signed long v41
        cdef signed long v42
        cdef US2 v45
        cdef UH0 v46
        cdef US2 v47
        cdef UH0 v48
        if v17.tag == 0: # call
            v18 = v12 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v11, v12, v10, v8, v9, v10
            else:
                v19, v20, v21, v22, v23, v24 = v8, v9, v10, v11, v12, v10
            v44 = method8(v2, v3, v6, v4, v5, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = v9 == 0
            if v26:
                v28 = v13
            else:
                v28 =  -v13
            v29 = v12 == 0
            if v29:
                v30, v31, v32, v33, v34, v35 = v11, v12, v13, v8, v9, v10
            else:
                v30, v31, v32, v33, v34, v35 = v8, v9, v10, v11, v12, v13
            v36 = v28 + v32
            v37 =  -v28
            v38 = v37 + v35
            v39 = <double>v28
            v44 = Closure17(v2, v30, v31, v36, v33, v34, v38, v39)
            del v30; del v33
        elif v17.tag == 2: # raise
            v41 = v7 - 1
            v42 = v10 + 2
            v44 = method15(v2, v3, v4, v5, v6, v41, v11, v12, v42, v8, v9, v10)
        v45 = US2_0(v17)
        v46 = UH0_0(v45, v0)
        del v45
        v47 = US2_0(v17)
        v48 = UH0_0(v47, v15)
        del v47
        v44(Tuple1(v46, v1, v48, v16, v14))
cdef class Closure20():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef US0 v17 = self.v17
        cdef object v44
        cdef bint v18
        cdef US1 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US1 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef bint v26
        cdef signed long v28
        cdef bint v29
        cdef US1 v30
        cdef unsigned char v31
        cdef signed long v32
        cdef US1 v33
        cdef unsigned char v34
        cdef signed long v35
        cdef signed long v36
        cdef signed long v37
        cdef signed long v38
        cdef double v39
        cdef signed long v41
        cdef signed long v42
        cdef US2 v45
        cdef UH0 v46
        cdef US2 v47
        cdef UH0 v48
        if v17.tag == 0: # call
            v18 = v12 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v11, v12, v10, v8, v9, v10
            else:
                v19, v20, v21, v22, v23, v24 = v8, v9, v10, v11, v12, v10
            v44 = method8(v2, v3, v6, v4, v5, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = v9 == 0
            if v26:
                v28 = v13
            else:
                v28 =  -v13
            v29 = v12 == 0
            if v29:
                v30, v31, v32, v33, v34, v35 = v11, v12, v13, v8, v9, v10
            else:
                v30, v31, v32, v33, v34, v35 = v8, v9, v10, v11, v12, v13
            v36 = v28 + v32
            v37 =  -v28
            v38 = v37 + v35
            v39 = <double>v28
            v44 = Closure17(v2, v30, v31, v36, v33, v34, v38, v39)
            del v30; del v33
        elif v17.tag == 2: # raise
            v41 = v7 - 1
            v42 = v10 + 2
            v44 = method15(v2, v3, v4, v5, v6, v41, v11, v12, v42, v8, v9, v10)
        v45 = US2_0(v17)
        v46 = UH0_0(v45, v0)
        del v45
        v47 = US2_0(v17)
        v48 = UH0_0(v47, v15)
        del v47
        v44(Tuple1(v46, v1, v48, v16, v14))
cdef class Closure21():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef US0 v17 = self.v17
        cdef object v44
        cdef bint v18
        cdef US1 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US1 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef bint v26
        cdef signed long v28
        cdef bint v29
        cdef US1 v30
        cdef unsigned char v31
        cdef signed long v32
        cdef US1 v33
        cdef unsigned char v34
        cdef signed long v35
        cdef signed long v36
        cdef signed long v37
        cdef signed long v38
        cdef double v39
        cdef signed long v41
        cdef signed long v42
        cdef US2 v45
        cdef UH0 v46
        cdef US2 v47
        cdef UH0 v48
        if v17.tag == 0: # call
            v18 = v12 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v11, v12, v10, v8, v9, v10
            else:
                v19, v20, v21, v22, v23, v24 = v8, v9, v10, v11, v12, v10
            v44 = method8(v2, v3, v6, v4, v5, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = v9 == 0
            if v26:
                v28 = v13
            else:
                v28 =  -v13
            v29 = v12 == 0
            if v29:
                v30, v31, v32, v33, v34, v35 = v11, v12, v13, v8, v9, v10
            else:
                v30, v31, v32, v33, v34, v35 = v8, v9, v10, v11, v12, v13
            v36 = v28 + v32
            v37 =  -v28
            v38 = v37 + v35
            v39 = <double>v28
            v44 = Closure17(v2, v30, v31, v36, v33, v34, v38, v39)
            del v30; del v33
        elif v17.tag == 2: # raise
            v41 = v7 - 1
            v42 = v10 + 2
            v44 = method15(v2, v3, v4, v5, v6, v41, v11, v12, v42, v8, v9, v10)
        v45 = US2_0(v17)
        v46 = UH0_0(v45, v0)
        del v45
        v47 = US2_0(v17)
        v48 = UH0_0(v47, v15)
        del v47
        v44(Tuple1(v46, v1, v48, v16, v14))
cdef class Closure25():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v107
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
        cdef Tuple2 tmp12
        cdef signed long v32
        cdef signed long v33
        cdef Tuple2 tmp13
        cdef bint v34
        cdef signed long v37
        cdef bint v35
        cdef bint v38
        cdef bint v39
        cdef bint v40
        cdef bint v47
        cdef bint v48
        cdef signed long v50
        cdef US1 v51
        cdef unsigned char v52
        cdef signed long v53
        cdef US1 v54
        cdef unsigned char v55
        cdef signed long v56
        cdef signed long v57
        cdef signed long v58
        cdef signed long v59
        cdef double v60
        cdef bint v62
        cdef bint v63
        cdef signed long v65
        cdef bint v66
        cdef US1 v67
        cdef unsigned char v68
        cdef signed long v69
        cdef US1 v70
        cdef unsigned char v71
        cdef signed long v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef double v76
        cdef bint v78
        cdef US1 v79
        cdef unsigned char v80
        cdef signed long v81
        cdef US1 v82
        cdef unsigned char v83
        cdef signed long v84
        cdef double v85
        cdef bint v89
        cdef signed long v91
        cdef bint v92
        cdef US1 v93
        cdef unsigned char v94
        cdef signed long v95
        cdef US1 v96
        cdef unsigned char v97
        cdef signed long v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef double v102
        cdef signed long v104
        cdef signed long v105
        cdef US2 v108
        cdef UH0 v109
        cdef US2 v110
        cdef UH0 v111
        if v16.tag == 0: # call
            if v11.tag == 0: # jack
                v17 = 0
            elif v11.tag == 1: # king
                v17 = 2
            elif v11.tag == 2: # queen
                v17 = 1
            if v7.tag == 0: # jack
                v18 = 0
            elif v7.tag == 1: # king
                v18 = 2
            elif v7.tag == 2: # queen
                v18 = 1
            if v8.tag == 0: # jack
                v19 = 0
            elif v8.tag == 1: # king
                v19 = 2
            elif v8.tag == 2: # queen
                v19 = 1
            if v7.tag == 0: # jack
                v20 = 0
            elif v7.tag == 1: # king
                v20 = 2
            elif v7.tag == 2: # queen
                v20 = 1
            v21 = method12(v18, v17)
            if v21:
                v23 = method12(v20, v19)
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
                v28 = method12(v18, v17)
                if v28:
                    v46 = 1
                else:
                    v29 = method12(v20, v19)
                    if v29:
                        v46 = -1
                    else:
                        tmp12 = method13(v18, v17)
                        v30, v31 = tmp12.v0, tmp12.v1
                        del tmp12
                        tmp13 = method13(v20, v19)
                        v32, v33 = tmp13.v0, tmp13.v1
                        del tmp13
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
                v48 = v12 == 0
                if v48:
                    v50 = v10
                else:
                    v50 =  -v10
                if v48:
                    v51, v52, v53, v54, v55, v56 = v11, v12, v10, v8, v9, v10
                else:
                    v51, v52, v53, v54, v55, v56 = v8, v9, v10, v11, v12, v10
                v57 = v50 + v53
                v58 =  -v50
                v59 = v58 + v56
                v60 = <double>v50
                v107 = Closure8(v2, v51, v52, v57, v54, v55, v59, v7, v60)
                del v51; del v54
            else:
                v62 = v46 == -1
                if v62:
                    v63 = v9 == 0
                    if v63:
                        v65 = v10
                    else:
                        v65 =  -v10
                    v66 = v12 == 0
                    if v66:
                        v67, v68, v69, v70, v71, v72 = v11, v12, v10, v8, v9, v10
                    else:
                        v67, v68, v69, v70, v71, v72 = v8, v9, v10, v11, v12, v10
                    v73 = v65 + v69
                    v74 =  -v65
                    v75 = v74 + v72
                    v76 = <double>v65
                    v107 = Closure8(v2, v67, v68, v73, v70, v71, v75, v7, v76)
                    del v67; del v70
                else:
                    v78 = v12 == 0
                    if v78:
                        v79, v80, v81, v82, v83, v84 = v11, v12, v10, v8, v9, v10
                    else:
                        v79, v80, v81, v82, v83, v84 = v8, v9, v10, v11, v12, v10
                    v85 = <double>0
                    v107 = Closure8(v2, v79, v80, v81, v82, v83, v84, v7, v85)
                    del v79; del v82
        elif v16.tag == 1: # fold
            v89 = v9 == 0
            if v89:
                v91 = v10
            else:
                v91 =  -v10
            v92 = v12 == 0
            if v92:
                v93, v94, v95, v96, v97, v98 = v11, v12, v10, v8, v9, v10
            else:
                v93, v94, v95, v96, v97, v98 = v8, v9, v10, v11, v12, v10
            v99 = v91 + v95
            v100 =  -v91
            v101 = v100 + v98
            v102 = <double>v91
            v107 = Closure8(v2, v93, v94, v99, v96, v97, v101, v7, v102)
            del v93; del v96
        elif v16.tag == 2: # raise
            v104 = v6 - 1
            v105 = v10 + 4
            v107 = method10(v2, v3, v4, v5, v104, v7, v11, v12, v105, v8, v9, v10)
        v108 = US2_0(v16)
        v109 = UH0_0(v108, v0)
        del v108
        v110 = US2_0(v16)
        v111 = UH0_0(v110, v14)
        del v110
        v107(Tuple1(v109, v1, v111, v15, v13))
cdef class Closure26():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v107
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
        cdef Tuple2 tmp14
        cdef signed long v32
        cdef signed long v33
        cdef Tuple2 tmp15
        cdef bint v34
        cdef signed long v37
        cdef bint v35
        cdef bint v38
        cdef bint v39
        cdef bint v40
        cdef bint v47
        cdef bint v48
        cdef signed long v50
        cdef US1 v51
        cdef unsigned char v52
        cdef signed long v53
        cdef US1 v54
        cdef unsigned char v55
        cdef signed long v56
        cdef signed long v57
        cdef signed long v58
        cdef signed long v59
        cdef double v60
        cdef bint v62
        cdef bint v63
        cdef signed long v65
        cdef bint v66
        cdef US1 v67
        cdef unsigned char v68
        cdef signed long v69
        cdef US1 v70
        cdef unsigned char v71
        cdef signed long v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef double v76
        cdef bint v78
        cdef US1 v79
        cdef unsigned char v80
        cdef signed long v81
        cdef US1 v82
        cdef unsigned char v83
        cdef signed long v84
        cdef double v85
        cdef bint v89
        cdef signed long v91
        cdef bint v92
        cdef US1 v93
        cdef unsigned char v94
        cdef signed long v95
        cdef US1 v96
        cdef unsigned char v97
        cdef signed long v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef double v102
        cdef signed long v104
        cdef signed long v105
        cdef US2 v108
        cdef UH0 v109
        cdef US2 v110
        cdef UH0 v111
        if v16.tag == 0: # call
            if v11.tag == 0: # jack
                v17 = 0
            elif v11.tag == 1: # king
                v17 = 2
            elif v11.tag == 2: # queen
                v17 = 1
            if v7.tag == 0: # jack
                v18 = 0
            elif v7.tag == 1: # king
                v18 = 2
            elif v7.tag == 2: # queen
                v18 = 1
            if v8.tag == 0: # jack
                v19 = 0
            elif v8.tag == 1: # king
                v19 = 2
            elif v8.tag == 2: # queen
                v19 = 1
            if v7.tag == 0: # jack
                v20 = 0
            elif v7.tag == 1: # king
                v20 = 2
            elif v7.tag == 2: # queen
                v20 = 1
            v21 = method12(v18, v17)
            if v21:
                v23 = method12(v20, v19)
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
                v28 = method12(v18, v17)
                if v28:
                    v46 = 1
                else:
                    v29 = method12(v20, v19)
                    if v29:
                        v46 = -1
                    else:
                        tmp14 = method13(v18, v17)
                        v30, v31 = tmp14.v0, tmp14.v1
                        del tmp14
                        tmp15 = method13(v20, v19)
                        v32, v33 = tmp15.v0, tmp15.v1
                        del tmp15
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
                v48 = v12 == 0
                if v48:
                    v50 = v10
                else:
                    v50 =  -v10
                if v48:
                    v51, v52, v53, v54, v55, v56 = v11, v12, v10, v8, v9, v10
                else:
                    v51, v52, v53, v54, v55, v56 = v8, v9, v10, v11, v12, v10
                v57 = v50 + v53
                v58 =  -v50
                v59 = v58 + v56
                v60 = <double>v50
                v107 = Closure8(v2, v51, v52, v57, v54, v55, v59, v7, v60)
                del v51; del v54
            else:
                v62 = v46 == -1
                if v62:
                    v63 = v9 == 0
                    if v63:
                        v65 = v10
                    else:
                        v65 =  -v10
                    v66 = v12 == 0
                    if v66:
                        v67, v68, v69, v70, v71, v72 = v11, v12, v10, v8, v9, v10
                    else:
                        v67, v68, v69, v70, v71, v72 = v8, v9, v10, v11, v12, v10
                    v73 = v65 + v69
                    v74 =  -v65
                    v75 = v74 + v72
                    v76 = <double>v65
                    v107 = Closure8(v2, v67, v68, v73, v70, v71, v75, v7, v76)
                    del v67; del v70
                else:
                    v78 = v12 == 0
                    if v78:
                        v79, v80, v81, v82, v83, v84 = v11, v12, v10, v8, v9, v10
                    else:
                        v79, v80, v81, v82, v83, v84 = v8, v9, v10, v11, v12, v10
                    v85 = <double>0
                    v107 = Closure8(v2, v79, v80, v81, v82, v83, v84, v7, v85)
                    del v79; del v82
        elif v16.tag == 1: # fold
            v89 = v9 == 0
            if v89:
                v91 = v10
            else:
                v91 =  -v10
            v92 = v12 == 0
            if v92:
                v93, v94, v95, v96, v97, v98 = v11, v12, v10, v8, v9, v10
            else:
                v93, v94, v95, v96, v97, v98 = v8, v9, v10, v11, v12, v10
            v99 = v91 + v95
            v100 =  -v91
            v101 = v100 + v98
            v102 = <double>v91
            v107 = Closure8(v2, v93, v94, v99, v96, v97, v101, v7, v102)
            del v93; del v96
        elif v16.tag == 2: # raise
            v104 = v6 - 1
            v105 = v10 + 4
            v107 = method10(v2, v3, v4, v5, v104, v7, v11, v12, v105, v8, v9, v10)
        v108 = US2_0(v16)
        v109 = UH0_0(v108, v0)
        del v108
        v110 = US2_0(v16)
        v111 = UH0_0(v110, v14)
        del v110
        v107(Tuple1(v109, v1, v111, v15, v13))
cdef class Closure27():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US1 v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v107
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
        cdef Tuple2 tmp16
        cdef signed long v32
        cdef signed long v33
        cdef Tuple2 tmp17
        cdef bint v34
        cdef signed long v37
        cdef bint v35
        cdef bint v38
        cdef bint v39
        cdef bint v40
        cdef bint v47
        cdef bint v48
        cdef signed long v50
        cdef US1 v51
        cdef unsigned char v52
        cdef signed long v53
        cdef US1 v54
        cdef unsigned char v55
        cdef signed long v56
        cdef signed long v57
        cdef signed long v58
        cdef signed long v59
        cdef double v60
        cdef bint v62
        cdef bint v63
        cdef signed long v65
        cdef bint v66
        cdef US1 v67
        cdef unsigned char v68
        cdef signed long v69
        cdef US1 v70
        cdef unsigned char v71
        cdef signed long v72
        cdef signed long v73
        cdef signed long v74
        cdef signed long v75
        cdef double v76
        cdef bint v78
        cdef US1 v79
        cdef unsigned char v80
        cdef signed long v81
        cdef US1 v82
        cdef unsigned char v83
        cdef signed long v84
        cdef double v85
        cdef bint v89
        cdef signed long v91
        cdef bint v92
        cdef US1 v93
        cdef unsigned char v94
        cdef signed long v95
        cdef US1 v96
        cdef unsigned char v97
        cdef signed long v98
        cdef signed long v99
        cdef signed long v100
        cdef signed long v101
        cdef double v102
        cdef signed long v104
        cdef signed long v105
        cdef US2 v108
        cdef UH0 v109
        cdef US2 v110
        cdef UH0 v111
        if v16.tag == 0: # call
            if v11.tag == 0: # jack
                v17 = 0
            elif v11.tag == 1: # king
                v17 = 2
            elif v11.tag == 2: # queen
                v17 = 1
            if v7.tag == 0: # jack
                v18 = 0
            elif v7.tag == 1: # king
                v18 = 2
            elif v7.tag == 2: # queen
                v18 = 1
            if v8.tag == 0: # jack
                v19 = 0
            elif v8.tag == 1: # king
                v19 = 2
            elif v8.tag == 2: # queen
                v19 = 1
            if v7.tag == 0: # jack
                v20 = 0
            elif v7.tag == 1: # king
                v20 = 2
            elif v7.tag == 2: # queen
                v20 = 1
            v21 = method12(v18, v17)
            if v21:
                v23 = method12(v20, v19)
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
                v28 = method12(v18, v17)
                if v28:
                    v46 = 1
                else:
                    v29 = method12(v20, v19)
                    if v29:
                        v46 = -1
                    else:
                        tmp16 = method13(v18, v17)
                        v30, v31 = tmp16.v0, tmp16.v1
                        del tmp16
                        tmp17 = method13(v20, v19)
                        v32, v33 = tmp17.v0, tmp17.v1
                        del tmp17
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
                v48 = v12 == 0
                if v48:
                    v50 = v10
                else:
                    v50 =  -v10
                if v48:
                    v51, v52, v53, v54, v55, v56 = v11, v12, v10, v8, v9, v10
                else:
                    v51, v52, v53, v54, v55, v56 = v8, v9, v10, v11, v12, v10
                v57 = v50 + v53
                v58 =  -v50
                v59 = v58 + v56
                v60 = <double>v50
                v107 = Closure8(v2, v51, v52, v57, v54, v55, v59, v7, v60)
                del v51; del v54
            else:
                v62 = v46 == -1
                if v62:
                    v63 = v9 == 0
                    if v63:
                        v65 = v10
                    else:
                        v65 =  -v10
                    v66 = v12 == 0
                    if v66:
                        v67, v68, v69, v70, v71, v72 = v11, v12, v10, v8, v9, v10
                    else:
                        v67, v68, v69, v70, v71, v72 = v8, v9, v10, v11, v12, v10
                    v73 = v65 + v69
                    v74 =  -v65
                    v75 = v74 + v72
                    v76 = <double>v65
                    v107 = Closure8(v2, v67, v68, v73, v70, v71, v75, v7, v76)
                    del v67; del v70
                else:
                    v78 = v12 == 0
                    if v78:
                        v79, v80, v81, v82, v83, v84 = v11, v12, v10, v8, v9, v10
                    else:
                        v79, v80, v81, v82, v83, v84 = v8, v9, v10, v11, v12, v10
                    v85 = <double>0
                    v107 = Closure8(v2, v79, v80, v81, v82, v83, v84, v7, v85)
                    del v79; del v82
        elif v16.tag == 1: # fold
            v89 = v9 == 0
            if v89:
                v91 = v10
            else:
                v91 =  -v10
            v92 = v12 == 0
            if v92:
                v93, v94, v95, v96, v97, v98 = v11, v12, v10, v8, v9, v10
            else:
                v93, v94, v95, v96, v97, v98 = v8, v9, v10, v11, v12, v10
            v99 = v91 + v95
            v100 =  -v91
            v101 = v100 + v98
            v102 = <double>v91
            v107 = Closure8(v2, v93, v94, v99, v96, v97, v101, v7, v102)
            del v93; del v96
        elif v16.tag == 2: # raise
            v104 = v6 - 1
            v105 = v10 + 4
            v107 = method10(v2, v3, v4, v5, v104, v7, v11, v12, v105, v8, v9, v10)
        v108 = US2_0(v16)
        v109 = UH0_0(v108, v0)
        del v108
        v110 = US2_0(v16)
        v111 = UH0_0(v110, v14)
        del v110
        v107(Tuple1(v109, v1, v111, v15, v13))
cdef class Closure24():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef US1 v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef signed long v11
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, US1 v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[object,ndim=1] v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef US1 v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = args.v0
        cdef double v13 = args.v1
        cdef UH0 v14 = args.v2
        cdef double v15 = args.v3
        cdef object v16 = args.v4
        cdef bint v17
        cdef US3 v18
        cdef str v19
        cdef object v20
        cdef object v21
        cdef object v22
        cdef Mut0 v23
        cdef unsigned long long v24
        cdef unsigned long long v25
        cdef object v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef str v30
        cdef str v31
        cdef str v32
        cdef US0 v33
        cdef unsigned long long v34
        cdef double v35
        cdef double v36
        cdef double v37
        cdef object v99
        cdef signed long v38
        cdef signed long v39
        cdef signed long v40
        cdef signed long v41
        cdef bint v42
        cdef bint v44
        cdef signed long v67
        cdef bint v45
        cdef bint v46
        cdef bint v49
        cdef bint v50
        cdef signed long v51
        cdef signed long v52
        cdef Tuple2 tmp18
        cdef signed long v53
        cdef signed long v54
        cdef Tuple2 tmp19
        cdef bint v55
        cdef signed long v58
        cdef bint v56
        cdef bint v59
        cdef bint v60
        cdef bint v61
        cdef bint v68
        cdef signed long v69
        cdef signed long v70
        cdef signed long v71
        cdef signed long v72
        cdef double v73
        cdef bint v75
        cdef bint v76
        cdef signed long v78
        cdef signed long v79
        cdef signed long v80
        cdef signed long v81
        cdef double v82
        cdef double v84
        cdef bint v88
        cdef signed long v90
        cdef signed long v91
        cdef signed long v92
        cdef signed long v93
        cdef double v94
        cdef signed long v96
        cdef signed long v97
        cdef double v100
        cdef US2 v101
        cdef UH0 v102
        cdef US2 v103
        cdef UH0 v104
        v17 = v2 == 0
        if v17:
            v18 = US3_0()
            v19 = method3(v18, v12)
            del v18
            v0.trace = v19
            del v19
            v20 = False
            v21 = False
            v22 = False
            v23 = Mut0(v21, v20, v22)
            del v20; del v21; del v22
            v24 = len(v7)
            v25 = 0
            method20(v24, v7, v12, v13, v0, v8, v9, v10, v11, v6, v4, v5, v3, v1, v2, v16, v14, v15, v23, v25)
            v26 = v23.v1
            v27 = v23.v0
            v28 = v23.v2
            del v23
            v29 = {'fold': v26, 'call': v27, 'raise': v28}
            del v29
            v0.actions = {'fold': v26, 'call': v27, 'raise': v28}
            del v26; del v27; del v28
            if v1.tag == 0: # jack
                v30 = 'J'
            elif v1.tag == 1: # king
                v30 = 'K'
            elif v1.tag == 2: # queen
                v30 = 'Q'
            if v4.tag == 0: # jack
                v31 = 'J'
            elif v4.tag == 1: # king
                v31 = 'K'
            elif v4.tag == 2: # queen
                v31 = 'Q'
            if v6.tag == 0: # jack
                v32 = 'J'
            elif v6.tag == 1: # king
                v32 = 'K'
            elif v6.tag == 2: # queen
                v32 = 'Q'
            v0.table_data = {'my_card': v30, 'my_pot': v3, 'op_card': v31, 'op_pot': v3, 'community_card': v32}
        else:
            v33 = numpy.random.choice(v7)
            v34 = len(v7)
            v35 = <double>v34
            v36 = 1.000000 / v35
            v37 = libc.math.log(v36)
            if v33.tag == 0: # call
                if v1.tag == 0: # jack
                    v38 = 0
                elif v1.tag == 1: # king
                    v38 = 2
                elif v1.tag == 2: # queen
                    v38 = 1
                if v6.tag == 0: # jack
                    v39 = 0
                elif v6.tag == 1: # king
                    v39 = 2
                elif v6.tag == 2: # queen
                    v39 = 1
                if v4.tag == 0: # jack
                    v40 = 0
                elif v4.tag == 1: # king
                    v40 = 2
                elif v4.tag == 2: # queen
                    v40 = 1
                if v6.tag == 0: # jack
                    v41 = 0
                elif v6.tag == 1: # king
                    v41 = 2
                elif v6.tag == 2: # queen
                    v41 = 1
                v42 = method12(v39, v38)
                if v42:
                    v44 = method12(v41, v40)
                else:
                    v44 = 0
                if v44:
                    v45 = v38 < v40
                    if v45:
                        v67 = -1
                    else:
                        v46 = v38 > v40
                        if v46:
                            v67 = 1
                        else:
                            v67 = 0
                else:
                    v49 = method12(v39, v38)
                    if v49:
                        v67 = 1
                    else:
                        v50 = method12(v41, v40)
                        if v50:
                            v67 = -1
                        else:
                            tmp18 = method13(v39, v38)
                            v51, v52 = tmp18.v0, tmp18.v1
                            del tmp18
                            tmp19 = method13(v41, v40)
                            v53, v54 = tmp19.v0, tmp19.v1
                            del tmp19
                            v55 = v51 < v53
                            if v55:
                                v58 = -1
                            else:
                                v56 = v51 > v53
                                if v56:
                                    v58 = 1
                                else:
                                    v58 = 0
                            v59 = v58 == 0
                            if v59:
                                v60 = v52 < v54
                                if v60:
                                    v67 = -1
                                else:
                                    v61 = v52 > v54
                                    if v61:
                                        v67 = 1
                                    else:
                                        v67 = 0
                            else:
                                v67 = v58
                v68 = v67 == 1
                if v68:
                    v69 =  -v3
                    v70 = v69 + v3
                    v71 =  -v69
                    v72 = v71 + v3
                    v73 = <double>v69
                    v99 = Closure8(v0, v4, v5, v70, v1, v2, v72, v6, v73)
                else:
                    v75 = v67 == -1
                    if v75:
                        v76 = v5 == 0
                        if v76:
                            v78 = v3
                        else:
                            v78 =  -v3
                        v79 = v78 + v3
                        v80 =  -v78
                        v81 = v80 + v3
                        v82 = <double>v78
                        v99 = Closure8(v0, v4, v5, v79, v1, v2, v81, v6, v82)
                    else:
                        v84 = <double>0
                        v99 = Closure14(v0, v4, v5, v3, v1, v2, v6, v84)
            elif v33.tag == 1: # fold
                v88 = v5 == 0
                if v88:
                    v90 = v3
                else:
                    v90 =  -v3
                v91 = v90 + v3
                v92 =  -v90
                v93 = v92 + v3
                v94 = <double>v90
                v99 = Closure8(v0, v4, v5, v91, v1, v2, v93, v6, v94)
            elif v33.tag == 2: # raise
                v96 = v11 - 1
                v97 = v3 + 4
                v99 = method10(v0, v8, v9, v10, v96, v6, v1, v2, v97, v4, v5, v3)
            v100 = v37 + v15
            v101 = US2_0(v33)
            v102 = UH0_0(v101, v12)
            del v101
            v103 = US2_0(v33)
            del v33
            v104 = UH0_0(v103, v14)
            del v103
            v99(Tuple1(v102, v13, v104, v100, v16))
cdef class Closure23():
    cdef US1 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef US1 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US1 v10
    cdef unsigned char v11
    cdef object v12
    cdef UH0 v13
    cdef double v14
    cdef US0 v15
    def __init__(self, US1 v0, UH0 v1, double v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, v12, UH0 v13, double v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self):
        cdef US1 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef object v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef US0 v15 = self.v15
        cdef object v22
        cdef signed long v16
        cdef signed long v19
        cdef signed long v20
        cdef US2 v23
        cdef US2 v24
        cdef UH0 v25
        cdef UH0 v26
        cdef US2 v27
        cdef US2 v28
        cdef UH0 v29
        cdef UH0 v30
        if v15.tag == 0: # call
            v16 = 2
            v22 = method19(v3, v4, v5, v6, v16, v0, v10, v11, v9, v7, v8)
        elif v15.tag == 1: # fold
            raise Exception("impossible")
        elif v15.tag == 2: # raise
            v19 = 1
            v20 = v9 + 4
            v22 = method10(v3, v4, v5, v6, v19, v0, v10, v11, v20, v7, v8, v9)
        v23 = US2_0(v15)
        v24 = US2_1(v0)
        v25 = UH0_0(v24, v1)
        del v24
        v26 = UH0_0(v23, v25)
        del v23; del v25
        v27 = US2_0(v15)
        v28 = US2_1(v0)
        v29 = UH0_0(v28, v13)
        del v28
        v30 = UH0_0(v27, v29)
        del v27; del v29
        v22(Tuple1(v26, v2, v30, v14, v12))
cdef class Closure28():
    cdef US1 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef US1 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US1 v10
    cdef unsigned char v11
    cdef object v12
    cdef UH0 v13
    cdef double v14
    cdef US0 v15
    def __init__(self, US1 v0, UH0 v1, double v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, v12, UH0 v13, double v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self):
        cdef US1 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef object v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef US0 v15 = self.v15
        cdef object v22
        cdef signed long v16
        cdef signed long v19
        cdef signed long v20
        cdef US2 v23
        cdef US2 v24
        cdef UH0 v25
        cdef UH0 v26
        cdef US2 v27
        cdef US2 v28
        cdef UH0 v29
        cdef UH0 v30
        if v15.tag == 0: # call
            v16 = 2
            v22 = method19(v3, v4, v5, v6, v16, v0, v10, v11, v9, v7, v8)
        elif v15.tag == 1: # fold
            raise Exception("impossible")
        elif v15.tag == 2: # raise
            v19 = 1
            v20 = v9 + 4
            v22 = method10(v3, v4, v5, v6, v19, v0, v10, v11, v20, v7, v8, v9)
        v23 = US2_0(v15)
        v24 = US2_1(v0)
        v25 = UH0_0(v24, v1)
        del v24
        v26 = UH0_0(v23, v25)
        del v23; del v25
        v27 = US2_0(v15)
        v28 = US2_1(v0)
        v29 = UH0_0(v28, v13)
        del v28
        v30 = UH0_0(v27, v29)
        del v27; del v29
        v22(Tuple1(v26, v2, v30, v14, v12))
cdef class Closure29():
    cdef US1 v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef US1 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US1 v10
    cdef unsigned char v11
    cdef object v12
    cdef UH0 v13
    cdef double v14
    cdef US0 v15
    def __init__(self, US1 v0, UH0 v1, double v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, US1 v7, unsigned char v8, signed long v9, US1 v10, unsigned char v11, v12, UH0 v13, double v14, US0 v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self):
        cdef US1 v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef US1 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US1 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef object v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef US0 v15 = self.v15
        cdef object v22
        cdef signed long v16
        cdef signed long v19
        cdef signed long v20
        cdef US2 v23
        cdef US2 v24
        cdef UH0 v25
        cdef UH0 v26
        cdef US2 v27
        cdef US2 v28
        cdef UH0 v29
        cdef UH0 v30
        if v15.tag == 0: # call
            v16 = 2
            v22 = method19(v3, v4, v5, v6, v16, v0, v10, v11, v9, v7, v8)
        elif v15.tag == 1: # fold
            raise Exception("impossible")
        elif v15.tag == 2: # raise
            v19 = 1
            v20 = v9 + 4
            v22 = method10(v3, v4, v5, v6, v19, v0, v10, v11, v20, v7, v8, v9)
        v23 = US2_0(v15)
        v24 = US2_1(v0)
        v25 = UH0_0(v24, v1)
        del v24
        v26 = UH0_0(v23, v25)
        del v23; del v25
        v27 = US2_0(v15)
        v28 = US2_1(v0)
        v29 = UH0_0(v28, v13)
        del v28
        v30 = UH0_0(v27, v29)
        del v27; del v29
        v22(Tuple1(v26, v2, v30, v14, v12))
cdef class Closure22():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef US1 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US1 v9
    cdef unsigned char v10
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple1 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef US1 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
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
        cdef US3 v26
        cdef str v27
        cdef object v28
        cdef object v29
        cdef object v30
        cdef Mut0 v31
        cdef unsigned long long v32
        cdef unsigned long long v33
        cdef object v34
        cdef object v35
        cdef object v36
        cdef object v37
        cdef str v38
        cdef str v39
        cdef str v40
        cdef US0 v41
        cdef unsigned long long v42
        cdef double v43
        cdef double v44
        cdef double v45
        cdef object v52
        cdef signed long v46
        cdef signed long v49
        cdef signed long v50
        cdef double v53
        cdef US2 v54
        cdef US2 v55
        cdef UH0 v56
        cdef UH0 v57
        cdef US2 v58
        cdef US2 v59
        cdef UH0 v60
        cdef UH0 v61
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
            v26 = US3_0()
            v27 = method3(v26, v25)
            del v25; del v26
            v2.trace = v27
            del v27
            v28 = False
            v29 = False
            v30 = False
            v31 = Mut0(v29, v28, v30)
            del v28; del v29; del v30
            v32 = len(v3)
            v33 = 0
            method18(v32, v3, v16, v11, v21, v2, v4, v5, v6, v7, v8, v9, v10, v15, v13, v22, v31, v33)
            v34 = v31.v1
            v35 = v31.v0
            v36 = v31.v2
            del v31
            v37 = {'fold': v34, 'call': v35, 'raise': v36}
            del v37
            v2.actions = {'fold': v34, 'call': v35, 'raise': v36}
            del v34; del v35; del v36
            if v9.tag == 0: # jack
                v38 = 'J'
            elif v9.tag == 1: # king
                v38 = 'K'
            elif v9.tag == 2: # queen
                v38 = 'Q'
            if v6.tag == 0: # jack
                v39 = 'J'
            elif v6.tag == 1: # king
                v39 = 'K'
            elif v6.tag == 2: # queen
                v39 = 'Q'
            if v16.tag == 0: # jack
                v40 = 'J'
            elif v16.tag == 1: # king
                v40 = 'K'
            elif v16.tag == 2: # queen
                v40 = 'Q'
            v2.table_data = {'my_card': v38, 'my_pot': v8, 'op_card': v39, 'op_pot': v8, 'community_card': v40}
        else:
            v41 = numpy.random.choice(v3)
            v42 = len(v3)
            v43 = <double>v42
            v44 = 1.000000 / v43
            v45 = libc.math.log(v44)
            if v41.tag == 0: # call
                v46 = 2
                v52 = method19(v2, v3, v4, v5, v46, v16, v9, v10, v8, v6, v7)
            elif v41.tag == 1: # fold
                raise Exception("impossible")
            elif v41.tag == 2: # raise
                v49 = 1
                v50 = v8 + 4
                v52 = method10(v2, v3, v4, v5, v49, v16, v9, v10, v50, v6, v7, v8)
            v53 = v45 + v22
            v54 = US2_0(v41)
            v55 = US2_1(v16)
            v56 = UH0_0(v55, v11)
            del v55
            v57 = UH0_0(v54, v56)
            del v54; del v56
            v58 = US2_0(v41)
            del v41
            v59 = US2_1(v16)
            v60 = UH0_0(v59, v13)
            del v59
            v61 = UH0_0(v58, v60)
            del v58; del v60
            v52(Tuple1(v57, v21, v61, v53, v15))
cdef class Closure18():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef signed long v12
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[object,ndim=1] v11, signed long v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed long v12 = self.v12
        cdef UH0 v13 = args.v0
        cdef double v14 = args.v1
        cdef UH0 v15 = args.v2
        cdef double v16 = args.v3
        cdef object v17 = args.v4
        cdef bint v18
        cdef US3 v19
        cdef str v20
        cdef object v21
        cdef object v22
        cdef object v23
        cdef Mut0 v24
        cdef unsigned long long v25
        cdef unsigned long long v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef object v30
        cdef str v31
        cdef str v32
        cdef US0 v33
        cdef unsigned long long v34
        cdef double v35
        cdef double v36
        cdef double v37
        cdef object v50
        cdef bint v39
        cdef signed long v41
        cdef signed long v42
        cdef signed long v43
        cdef signed long v44
        cdef double v45
        cdef signed long v47
        cdef signed long v48
        cdef double v51
        cdef US2 v52
        cdef UH0 v53
        cdef US2 v54
        cdef UH0 v55
        v18 = v2 == 0
        if v18:
            v19 = US3_0()
            v20 = method3(v19, v13)
            del v19
            v0.trace = v20
            del v20
            v21 = False
            v22 = False
            v23 = False
            v24 = Mut0(v22, v21, v23)
            del v21; del v22; del v23
            v25 = len(v7)
            v26 = 0
            method16(v25, v7, v13, v14, v0, v8, v9, v10, v11, v12, v4, v5, v6, v1, v2, v3, v17, v15, v16, v24, v26)
            v27 = v24.v1
            v28 = v24.v0
            v29 = v24.v2
            del v24
            v30 = {'fold': v27, 'call': v28, 'raise': v29}
            del v30
            v0.actions = {'fold': v27, 'call': v28, 'raise': v29}
            del v27; del v28; del v29
            if v1.tag == 0: # jack
                v31 = 'J'
            elif v1.tag == 1: # king
                v31 = 'K'
            elif v1.tag == 2: # queen
                v31 = 'Q'
            if v4.tag == 0: # jack
                v32 = 'J'
            elif v4.tag == 1: # king
                v32 = 'K'
            elif v4.tag == 2: # queen
                v32 = 'Q'
            v0.table_data = {'my_card': v31, 'my_pot': v3, 'op_card': v32, 'op_pot': v6, 'community_card': ' '}
        else:
            v33 = numpy.random.choice(v7)
            v34 = len(v7)
            v35 = <double>v34
            v36 = 1.000000 / v35
            v37 = libc.math.log(v36)
            if v33.tag == 0: # call
                v50 = method17(v0, v8, v11, v9, v10, v1, v2, v6, v4, v5)
            elif v33.tag == 1: # fold
                v39 = v5 == 0
                if v39:
                    v41 = v3
                else:
                    v41 =  -v3
                v42 = v41 + v6
                v43 =  -v41
                v44 = v43 + v3
                v45 = <double>v41
                v50 = Closure17(v0, v4, v5, v42, v1, v2, v44, v45)
            elif v33.tag == 2: # raise
                v47 = v12 - 1
                v48 = v6 + 2
                v50 = method15(v0, v8, v9, v10, v11, v47, v1, v2, v48, v4, v5, v6)
            v51 = v37 + v16
            v52 = US2_0(v33)
            v53 = UH0_0(v52, v13)
            del v52
            v54 = US2_0(v33)
            del v33
            v55 = UH0_0(v54, v15)
            del v54
            v50(Tuple1(v53, v14, v55, v51, v17))
cdef class Closure3():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v43
        cdef bint v17
        cdef US1 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US1 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef bint v25
        cdef signed long v27
        cdef bint v28
        cdef US1 v29
        cdef unsigned char v30
        cdef signed long v31
        cdef US1 v32
        cdef unsigned char v33
        cdef signed long v34
        cdef signed long v35
        cdef signed long v36
        cdef signed long v37
        cdef double v38
        cdef signed long v40
        cdef signed long v41
        cdef US2 v44
        cdef UH0 v45
        cdef US2 v46
        cdef UH0 v47
        if v16.tag == 0: # call
            v17 = v12 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v11, v12, v10, v8, v9, v10
            else:
                v18, v19, v20, v21, v22, v23 = v8, v9, v10, v11, v12, v10
            v43 = method8(v2, v3, v6, v4, v5, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = v9 == 0
            if v25:
                v27 = v10
            else:
                v27 =  -v10
            v28 = v12 == 0
            if v28:
                v29, v30, v31, v32, v33, v34 = v11, v12, v10, v8, v9, v10
            else:
                v29, v30, v31, v32, v33, v34 = v8, v9, v10, v11, v12, v10
            v35 = v27 + v31
            v36 =  -v27
            v37 = v36 + v34
            v38 = <double>v27
            v43 = Closure17(v2, v29, v30, v35, v32, v33, v37, v38)
            del v29; del v32
        elif v16.tag == 2: # raise
            v40 = v7 - 1
            v41 = v10 + 2
            v43 = method15(v2, v3, v4, v5, v6, v40, v11, v12, v41, v8, v9, v10)
        v44 = US2_0(v16)
        v45 = UH0_0(v44, v0)
        del v44
        v46 = US2_0(v16)
        v47 = UH0_0(v46, v14)
        del v46
        v43(Tuple1(v45, v1, v47, v15, v13))
cdef class Closure30():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v43
        cdef bint v17
        cdef US1 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US1 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef bint v25
        cdef signed long v27
        cdef bint v28
        cdef US1 v29
        cdef unsigned char v30
        cdef signed long v31
        cdef US1 v32
        cdef unsigned char v33
        cdef signed long v34
        cdef signed long v35
        cdef signed long v36
        cdef signed long v37
        cdef double v38
        cdef signed long v40
        cdef signed long v41
        cdef US2 v44
        cdef UH0 v45
        cdef US2 v46
        cdef UH0 v47
        if v16.tag == 0: # call
            v17 = v12 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v11, v12, v10, v8, v9, v10
            else:
                v18, v19, v20, v21, v22, v23 = v8, v9, v10, v11, v12, v10
            v43 = method8(v2, v3, v6, v4, v5, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = v9 == 0
            if v25:
                v27 = v10
            else:
                v27 =  -v10
            v28 = v12 == 0
            if v28:
                v29, v30, v31, v32, v33, v34 = v11, v12, v10, v8, v9, v10
            else:
                v29, v30, v31, v32, v33, v34 = v8, v9, v10, v11, v12, v10
            v35 = v27 + v31
            v36 =  -v27
            v37 = v36 + v34
            v38 = <double>v27
            v43 = Closure17(v2, v29, v30, v35, v32, v33, v37, v38)
            del v29; del v32
        elif v16.tag == 2: # raise
            v40 = v7 - 1
            v41 = v10 + 2
            v43 = method15(v2, v3, v4, v5, v6, v40, v11, v12, v41, v8, v9, v10)
        v44 = US2_0(v16)
        v45 = UH0_0(v44, v0)
        del v44
        v46 = US2_0(v16)
        v47 = UH0_0(v46, v14)
        del v46
        v43(Tuple1(v45, v1, v47, v15, v13))
cdef class Closure31():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef signed long v7
    cdef US1 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef US1 v11
    cdef unsigned char v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef US0 v16
    def __init__(self, UH0 v0, double v1, v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, signed long v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, US0 v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US1 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef US0 v16 = self.v16
        cdef object v43
        cdef bint v17
        cdef US1 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US1 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef bint v25
        cdef signed long v27
        cdef bint v28
        cdef US1 v29
        cdef unsigned char v30
        cdef signed long v31
        cdef US1 v32
        cdef unsigned char v33
        cdef signed long v34
        cdef signed long v35
        cdef signed long v36
        cdef signed long v37
        cdef double v38
        cdef signed long v40
        cdef signed long v41
        cdef US2 v44
        cdef UH0 v45
        cdef US2 v46
        cdef UH0 v47
        if v16.tag == 0: # call
            v17 = v12 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v11, v12, v10, v8, v9, v10
            else:
                v18, v19, v20, v21, v22, v23 = v8, v9, v10, v11, v12, v10
            v43 = method8(v2, v3, v6, v4, v5, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = v9 == 0
            if v25:
                v27 = v10
            else:
                v27 =  -v10
            v28 = v12 == 0
            if v28:
                v29, v30, v31, v32, v33, v34 = v11, v12, v10, v8, v9, v10
            else:
                v29, v30, v31, v32, v33, v34 = v8, v9, v10, v11, v12, v10
            v35 = v27 + v31
            v36 =  -v27
            v37 = v36 + v34
            v38 = <double>v27
            v43 = Closure17(v2, v29, v30, v35, v32, v33, v37, v38)
            del v29; del v32
        elif v16.tag == 2: # raise
            v40 = v7 - 1
            v41 = v10 + 2
            v43 = method15(v2, v3, v4, v5, v6, v40, v11, v12, v41, v8, v9, v10)
        v44 = US2_0(v16)
        v45 = UH0_0(v44, v0)
        del v44
        v46 = US2_0(v16)
        v47 = UH0_0(v46, v14)
        del v46
        v43(Tuple1(v45, v1, v47, v15, v13))
cdef class Closure2():
    cdef object v0
    cdef US1 v1
    cdef unsigned char v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef signed long v11
    def __init__(self, v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[object,ndim=1] v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple1 args):
        cdef object v0 = self.v0
        cdef US1 v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = args.v0
        cdef double v13 = args.v1
        cdef UH0 v14 = args.v2
        cdef double v15 = args.v3
        cdef object v16 = args.v4
        cdef bint v17
        cdef US3 v18
        cdef str v19
        cdef object v20
        cdef object v21
        cdef object v22
        cdef Mut0 v23
        cdef unsigned long long v24
        cdef unsigned long long v25
        cdef object v26
        cdef object v27
        cdef object v28
        cdef object v29
        cdef str v30
        cdef str v31
        cdef US0 v32
        cdef unsigned long long v33
        cdef double v34
        cdef double v35
        cdef double v36
        cdef object v49
        cdef bint v38
        cdef signed long v40
        cdef signed long v41
        cdef signed long v42
        cdef signed long v43
        cdef double v44
        cdef signed long v46
        cdef signed long v47
        cdef double v50
        cdef US2 v51
        cdef UH0 v52
        cdef US2 v53
        cdef UH0 v54
        v17 = v2 == 0
        if v17:
            v18 = US3_0()
            v19 = method3(v18, v12)
            del v18
            v0.trace = v19
            del v19
            v20 = False
            v21 = False
            v22 = False
            v23 = Mut0(v21, v20, v22)
            del v20; del v21; del v22
            v24 = len(v6)
            v25 = 0
            method7(v24, v6, v12, v13, v0, v7, v8, v9, v10, v11, v4, v5, v3, v1, v2, v16, v14, v15, v23, v25)
            v26 = v23.v1
            v27 = v23.v0
            v28 = v23.v2
            del v23
            v29 = {'fold': v26, 'call': v27, 'raise': v28}
            del v29
            v0.actions = {'fold': v26, 'call': v27, 'raise': v28}
            del v26; del v27; del v28
            if v1.tag == 0: # jack
                v30 = 'J'
            elif v1.tag == 1: # king
                v30 = 'K'
            elif v1.tag == 2: # queen
                v30 = 'Q'
            if v4.tag == 0: # jack
                v31 = 'J'
            elif v4.tag == 1: # king
                v31 = 'K'
            elif v4.tag == 2: # queen
                v31 = 'Q'
            v0.table_data = {'my_card': v30, 'my_pot': v3, 'op_card': v31, 'op_pot': v3, 'community_card': ' '}
        else:
            v32 = numpy.random.choice(v6)
            v33 = len(v6)
            v34 = <double>v33
            v35 = 1.000000 / v34
            v36 = libc.math.log(v35)
            if v32.tag == 0: # call
                v49 = method17(v0, v7, v10, v8, v9, v1, v2, v3, v4, v5)
            elif v32.tag == 1: # fold
                v38 = v5 == 0
                if v38:
                    v40 = v3
                else:
                    v40 =  -v3
                v41 = v40 + v3
                v42 =  -v40
                v43 = v42 + v3
                v44 = <double>v40
                v49 = Closure17(v0, v4, v5, v41, v1, v2, v43, v44)
            elif v32.tag == 2: # raise
                v46 = v11 - 1
                v47 = v3 + 2
                v49 = method15(v0, v7, v8, v9, v10, v46, v1, v2, v47, v4, v5, v3)
            v50 = v36 + v15
            v51 = US2_0(v32)
            v52 = UH0_0(v51, v12)
            del v51
            v53 = US2_0(v32)
            del v32
            v54 = UH0_0(v53, v14)
            del v53
            v49(Tuple1(v52, v13, v54, v50, v16))
cdef class Closure32():
    def __init__(self): pass
    def __call__(self, double v0):
        pass
cdef class Closure1():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef US1 v3
    cdef US1 v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef UH0 v9
    cdef double v10
    cdef US0 v11
    def __init__(self, UH0 v0, double v1, v2, US1 v3, US1 v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, UH0 v9, double v10, US0 v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef US1 v3 = self.v3
        cdef US1 v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef US0 v11 = self.v11
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
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        cdef object v29
        if v11.tag == 0: # call
            v12 = 2
            v13 = 1
            v14 = 1
            v15 = 0
            v24 = method6(v2, v5, v6, v7, v8, v12, v3, v15, v14, v4, v13)
        elif v11.tag == 1: # fold
            raise Exception("impossible")
        elif v11.tag == 2: # raise
            v18 = 1
            v19 = 1
            v20 = 1
            v21 = 0
            v22 = 3
            v24 = method15(v2, v5, v6, v7, v8, v18, v3, v21, v22, v4, v19, v20)
        v25 = US2_0(v11)
        v26 = UH0_0(v25, v0)
        del v25
        v27 = US2_0(v11)
        v28 = UH0_0(v27, v9)
        del v27
        v29 = Closure32()
        v24(Tuple1(v26, v1, v28, v10, v29))
cdef class Closure33():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef US1 v3
    cdef US1 v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef UH0 v9
    cdef double v10
    cdef US0 v11
    def __init__(self, UH0 v0, double v1, v2, US1 v3, US1 v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, UH0 v9, double v10, US0 v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef US1 v3 = self.v3
        cdef US1 v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef US0 v11 = self.v11
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
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        cdef object v29
        if v11.tag == 0: # call
            v12 = 2
            v13 = 1
            v14 = 1
            v15 = 0
            v24 = method6(v2, v5, v6, v7, v8, v12, v3, v15, v14, v4, v13)
        elif v11.tag == 1: # fold
            raise Exception("impossible")
        elif v11.tag == 2: # raise
            v18 = 1
            v19 = 1
            v20 = 1
            v21 = 0
            v22 = 3
            v24 = method15(v2, v5, v6, v7, v8, v18, v3, v21, v22, v4, v19, v20)
        v25 = US2_0(v11)
        v26 = UH0_0(v25, v0)
        del v25
        v27 = US2_0(v11)
        v28 = UH0_0(v27, v9)
        del v27
        v29 = Closure32()
        v24(Tuple1(v26, v1, v28, v10, v29))
cdef class Closure34():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    cdef US1 v3
    cdef US1 v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef UH0 v9
    cdef double v10
    cdef US0 v11
    def __init__(self, UH0 v0, double v1, v2, US1 v3, US1 v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, UH0 v9, double v10, US0 v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef object v2 = self.v2
        cdef US1 v3 = self.v3
        cdef US1 v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef US0 v11 = self.v11
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
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        cdef object v29
        if v11.tag == 0: # call
            v12 = 2
            v13 = 1
            v14 = 1
            v15 = 0
            v24 = method6(v2, v5, v6, v7, v8, v12, v3, v15, v14, v4, v13)
        elif v11.tag == 1: # fold
            raise Exception("impossible")
        elif v11.tag == 2: # raise
            v18 = 1
            v19 = 1
            v20 = 1
            v21 = 0
            v22 = 3
            v24 = method15(v2, v5, v6, v7, v8, v18, v3, v21, v22, v4, v19, v20)
        v25 = US2_0(v11)
        v26 = UH0_0(v25, v0)
        del v25
        v27 = US2_0(v11)
        v28 = UH0_0(v27, v9)
        del v27
        v29 = Closure32()
        v24(Tuple1(v26, v1, v28, v10, v29))
cdef class Closure0():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self):
        cdef object v0 = self.v0
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
        cdef UH0 v20
        cdef double v21
        cdef UH0 v22
        cdef double v23
        cdef US1 v24
        cdef unsigned long long v25
        cdef numpy.ndarray[object,ndim=1] v26
        cdef unsigned long long v27
        cdef double v28
        cdef double v29
        cdef double v30
        cdef unsigned char v31
        cdef UH0 v32
        cdef double v33
        cdef Tuple0 tmp0
        cdef unsigned char v34
        cdef UH0 v35
        cdef double v36
        cdef Tuple0 tmp1
        cdef unsigned long long v37
        cdef unsigned long long v38
        cdef US1 v39
        cdef unsigned long long v40
        cdef numpy.ndarray[object,ndim=1] v41
        cdef unsigned long long v42
        cdef double v43
        cdef double v44
        cdef double v45
        cdef unsigned char v46
        cdef UH0 v47
        cdef double v48
        cdef Tuple0 tmp2
        cdef unsigned char v49
        cdef UH0 v50
        cdef double v51
        cdef Tuple0 tmp3
        cdef US3 v52
        cdef str v53
        cdef object v54
        cdef object v55
        cdef object v56
        cdef Mut0 v57
        cdef unsigned long long v58
        cdef unsigned long long v59
        cdef object v60
        cdef object v61
        cdef object v62
        cdef object v63
        cdef str v64
        cdef str v65
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
        v20 = UH0_1()
        v21 = 0.000000
        v22 = UH0_1()
        v23 = 0.000000
        v24 = v17[v19]
        v25 = v18 - 1
        v26 = numpy.empty(v25,dtype=object)
        v27 = 0
        method0(v25, v19, v17, v26, v27)
        del v17
        v28 = <double>v18
        v29 = 1.000000 / v28
        v30 = libc.math.log(v29)
        v31 = 0
        tmp0 = method1(v24, v30, v31, v20, v21)
        v32, v33 = tmp0.v0, tmp0.v1
        del tmp0
        del v20
        v34 = 1
        tmp1 = method1(v24, v30, v34, v22, v23)
        v35, v36 = tmp1.v0, tmp1.v1
        del tmp1
        del v22
        v37 = len(v26)
        v38 = numpy.random.randint(0,v37)
        v39 = v26[v38]
        v40 = v37 - 1
        v41 = numpy.empty(v40,dtype=object)
        v42 = 0
        method0(v40, v38, v26, v41, v42)
        del v26
        v43 = <double>v37
        v44 = 1.000000 / v43
        v45 = libc.math.log(v44)
        v46 = 0
        tmp2 = method2(v39, v45, v46, v32, v33)
        v47, v48 = tmp2.v0, tmp2.v1
        del tmp2
        del v32
        v49 = 1
        tmp3 = method2(v39, v45, v49, v35, v36)
        v50, v51 = tmp3.v0, tmp3.v1
        del tmp3
        del v35
        v52 = US3_0()
        v53 = method3(v52, v47)
        del v52
        v0.trace = v53
        del v53
        v54 = False
        v55 = False
        v56 = False
        v57 = Mut0(v55, v54, v56)
        del v54; del v55; del v56
        v58 = len(v3)
        v59 = 0
        method5(v58, v3, v47, v48, v0, v24, v39, v7, v10, v41, v50, v51, v57, v59)
        del v3; del v7; del v10; del v41; del v47; del v50
        v60 = v57.v1
        v61 = v57.v0
        v62 = v57.v2
        del v57
        v63 = {'fold': v60, 'call': v61, 'raise': v62}
        del v63
        v0.actions = {'fold': v60, 'call': v61, 'raise': v62}
        del v60; del v61; del v62
        if v24.tag == 0: # jack
            v64 = 'J'
        elif v24.tag == 1: # king
            v64 = 'K'
        elif v24.tag == 2: # queen
            v64 = 'Q'
        del v24
        if v39.tag == 0: # jack
            v65 = 'J'
        elif v39.tag == 1: # king
            v65 = 'K'
        elif v39.tag == 2: # queen
            v65 = 'Q'
        del v39
        v0.table_data = {'my_card': v64, 'my_pot': 1, 'op_card': v65, 'op_pot': 1, 'community_card': ' '}
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
cdef bint method4(list v0, UH0 v1, bint v2):
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
        v5 = method4(v0, v4, v2)
        del v4
        if v3.tag == 0: # action_
            v6 = (<US2_0>v3).v0
            if v5:
                v7 = "Player One"
            else:
                v7 = "Player Two"
            if v6.tag == 0: # call
                v8 = "calls"
            elif v6.tag == 1: # fold
                v8 = "folds"
            elif v6.tag == 2: # raise
                v8 = "raises"
            del v6
            v9 = f'{v7} {v8}.'
            del v7; del v8
            v0.append(v9)
            del v9
            return v5 == 0
        elif v3.tag == 1: # observation_
            v11 = (<US2_1>v3).v0
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
cdef str method3(US3 v0, UH0 v1):
    cdef list v2
    cdef bint v3
    cdef bint v4
    cdef double v5
    cdef bint v6
    cdef str v11
    cdef bint v8
    v2 = []
    v3 = 1
    v4 = method4(v2, v1, v3)
    if v0.tag == 0: # none
        pass
    elif v0.tag == 1: # some_
        v5 = (<US3_1>v0).v0
        v6 = 0.000000 < v5
        if v6:
            v11 = f"Player wins {v5} chips."
        else:
            v8 = 0.000000 == v5
            if v8:
                v11 = "Player draws."
            else:
                v11 = f"Player loses {v5} chips."
        v2.append(v11)
        del v11
    return "\n".join(v2)
cdef bint method12(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple2 method13(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple2(v1, v0)
    else:
        return Tuple2(v0, v1)
cdef void method14(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, Mut0 v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US0 v6
    cdef object v7
    cdef object v8
    cdef object v9
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        if v6.tag == 0: # call
            v7 = Closure9(v6)
            v2.v0 = v7
            del v7
        elif v6.tag == 1: # fold
            v8 = Closure10(v6)
            v2.v1 = v8
            del v8
        elif v6.tag == 2: # raise
            v9 = Closure11(v6)
            v2.v2 = v9
            del v9
        del v6
        method14(v0, v1, v2, v5)
    else:
        pass
cdef void method11(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, UH0 v2, double v3, v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US1 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, v16, UH0 v17, double v18, Mut0 v19, unsigned long long v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US0 v23
    cdef object v24
    cdef object v25
    cdef object v26
    v21 = v20 < v0
    if v21:
        v22 = v20 + 1
        v23 = v1[v20]
        if v23.tag == 0: # call
            v24 = Closure7(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v23)
            v19.v0 = v24
            del v24
        elif v23.tag == 1: # fold
            v25 = Closure12(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v23)
            v19.v1 = v25
            del v25
        elif v23.tag == 2: # raise
            v26 = Closure13(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v23)
            v19.v2 = v26
            del v26
        del v23
        method11(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v22)
    else:
        pass
cdef object method10(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10, signed long v11):
    cdef bint v12
    cdef numpy.ndarray[object,ndim=1] v15
    cdef bint v13
    v12 = 0 < v4
    if v12:
        v13 = v11 == v8
        if v13:
            v15 = v1
        else:
            v15 = v2
    else:
        v15 = v3
    return Closure6(v0, v9, v10, v11, v6, v7, v8, v5, v15, v1, v2, v3, v4)
cdef void method9(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, US1 v2, UH0 v3, double v4, v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, v14, UH0 v15, double v16, Mut0 v17, unsigned long long v18):
    cdef bint v19
    cdef unsigned long long v20
    cdef US0 v21
    cdef object v22
    cdef object v23
    cdef object v24
    v19 = v18 < v0
    if v19:
        v20 = v18 + 1
        v21 = v1[v18]
        if v21.tag == 0: # call
            v22 = Closure5(v2, v3, v4, v5, v1, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v21)
            v17.v0 = v22
            del v22
        elif v21.tag == 1: # fold
            v23 = Closure15(v2, v3, v4, v5, v1, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v21)
            v17.v1 = v23
            del v23
        elif v21.tag == 2: # raise
            v24 = Closure16(v2, v3, v4, v5, v1, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v21)
            v17.v2 = v24
            del v24
        del v21
        method9(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v20)
    else:
        pass
cdef object method8(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, signed long v10):
    cdef unsigned long long v11
    cdef unsigned long long v12
    v11 = len(v2)
    v12 = numpy.random.randint(0,v11)
    return Closure4(v12, v2, v0, v1, v3, v4, v5, v6, v7, v8, v9, v10)
cdef void method16(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, UH0 v2, double v3, v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, signed long v15, v16, UH0 v17, double v18, Mut0 v19, unsigned long long v20):
    cdef bint v21
    cdef unsigned long long v22
    cdef US0 v23
    cdef object v24
    cdef object v25
    cdef object v26
    v21 = v20 < v0
    if v21:
        v22 = v20 + 1
        v23 = v1[v20]
        if v23.tag == 0: # call
            v24 = Closure19(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v23)
            v19.v0 = v24
            del v24
        elif v23.tag == 1: # fold
            v25 = Closure20(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v23)
            v19.v1 = v25
            del v25
        elif v23.tag == 2: # raise
            v26 = Closure21(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v23)
            v19.v2 = v26
            del v26
        del v23
        method16(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v22)
    else:
        pass
cdef void method20(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, UH0 v2, double v3, v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US1 v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, v15, UH0 v16, double v17, Mut0 v18, unsigned long long v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US0 v22
    cdef object v23
    cdef object v24
    cdef object v25
    v20 = v19 < v0
    if v20:
        v21 = v19 + 1
        v22 = v1[v19]
        if v22.tag == 0: # call
            v23 = Closure25(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v22)
            v18.v0 = v23
            del v23
        elif v22.tag == 1: # fold
            v24 = Closure26(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v22)
            v18.v1 = v24
            del v24
        elif v22.tag == 2: # raise
            v25 = Closure27(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v22)
            v18.v2 = v25
            del v25
        del v22
        method20(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v21)
    else:
        pass
cdef object method19(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US1 v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10):
    cdef bint v11
    cdef numpy.ndarray[object,ndim=1] v12
    v11 = 0 < v4
    if v11:
        v12 = v1
    else:
        v12 = v3
    return Closure24(v0, v9, v10, v8, v6, v7, v5, v12, v1, v2, v3, v4)
cdef void method18(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, US1 v2, UH0 v3, double v4, v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, v13, UH0 v14, double v15, Mut0 v16, unsigned long long v17):
    cdef bint v18
    cdef unsigned long long v19
    cdef US0 v20
    cdef object v21
    cdef object v22
    cdef object v23
    v18 = v17 < v0
    if v18:
        v19 = v17 + 1
        v20 = v1[v17]
        if v20.tag == 0: # call
            v21 = Closure23(v2, v3, v4, v5, v1, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v20)
            v16.v0 = v21
            del v21
        elif v20.tag == 1: # fold
            v22 = Closure28(v2, v3, v4, v5, v1, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v20)
            v16.v1 = v22
            del v22
        elif v20.tag == 2: # raise
            v23 = Closure29(v2, v3, v4, v5, v1, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v20)
            v16.v2 = v23
            del v23
        del v20
        method18(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v19)
    else:
        pass
cdef object method17(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, US1 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9):
    cdef unsigned long long v10
    cdef unsigned long long v11
    v10 = len(v2)
    v11 = numpy.random.randint(0,v10)
    return Closure22(v11, v2, v0, v1, v3, v4, v5, v6, v7, v8, v9)
cdef object method15(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10, signed long v11):
    cdef bint v12
    cdef numpy.ndarray[object,ndim=1] v15
    cdef bint v13
    v12 = 0 < v5
    if v12:
        v13 = v11 == v8
        if v13:
            v15 = v1
        else:
            v15 = v2
    else:
        v15 = v3
    return Closure18(v0, v9, v10, v11, v6, v7, v8, v15, v1, v2, v3, v4, v5)
cdef void method7(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, UH0 v2, double v3, v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, signed long v9, US1 v10, unsigned char v11, signed long v12, US1 v13, unsigned char v14, v15, UH0 v16, double v17, Mut0 v18, unsigned long long v19):
    cdef bint v20
    cdef unsigned long long v21
    cdef US0 v22
    cdef object v23
    cdef object v24
    cdef object v25
    v20 = v19 < v0
    if v20:
        v21 = v19 + 1
        v22 = v1[v19]
        if v22.tag == 0: # call
            v23 = Closure3(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v22)
            v18.v0 = v23
            del v23
        elif v22.tag == 1: # fold
            v24 = Closure30(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v22)
            v18.v1 = v24
            del v24
        elif v22.tag == 2: # raise
            v25 = Closure31(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v22)
            v18.v2 = v25
            del v25
        del v22
        method7(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v21)
    else:
        pass
cdef object method6(v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10):
    cdef bint v11
    cdef numpy.ndarray[object,ndim=1] v12
    v11 = 0 < v5
    if v11:
        v12 = v1
    else:
        v12 = v3
    return Closure2(v0, v9, v10, v8, v6, v7, v12, v1, v2, v3, v4, v5)
cdef void method5(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, UH0 v2, double v3, v4, US1 v5, US1 v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, UH0 v10, double v11, Mut0 v12, unsigned long long v13):
    cdef bint v14
    cdef unsigned long long v15
    cdef US0 v16
    cdef object v17
    cdef object v18
    cdef object v19
    v14 = v13 < v0
    if v14:
        v15 = v13 + 1
        v16 = v1[v13]
        if v16.tag == 0: # call
            v17 = Closure1(v2, v3, v4, v5, v6, v1, v7, v8, v9, v10, v11, v16)
            v12.v0 = v17
            del v17
        elif v16.tag == 1: # fold
            v18 = Closure33(v2, v3, v4, v5, v6, v1, v7, v8, v9, v10, v11, v16)
            v12.v1 = v18
            del v18
        elif v16.tag == 2: # raise
            v19 = Closure34(v2, v3, v4, v5, v6, v1, v7, v8, v9, v10, v11, v16)
            v12.v2 = v19
            del v19
        del v16
        method5(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v15)
    else:
        pass
cpdef void main():
    cdef object v0
    cdef object v1
    pass # import ui_leduc
    v0 = ui_leduc.root
    v1 = Closure0(v0)
    del v0
    ui_leduc.start_game(v1)
