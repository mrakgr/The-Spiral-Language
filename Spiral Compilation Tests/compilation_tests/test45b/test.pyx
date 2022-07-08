import numpy
cimport numpy
cdef class Mut0:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
ctypedef signed long US0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # Cons
    cdef readonly str v0
    cdef readonly UH0 v1
    def __init__(self, str v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # Nil
    def __init__(self): self.tag = 1
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # None
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # Some
    cdef readonly UH0 v0
    def __init__(self, UH0 v0): self.tag = 1; self.v0 = v0
cdef class Mut1:
    cdef public US1 v0
    def __init__(self, US1 v0): self.v0 = v0
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    cdef readonly UH0 v2
    def __init__(self, unsigned long long v0, unsigned long long v1, UH0 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    def __init__(self, unsigned long long v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method3(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef UH0 method4(UH0 v0, UH0 v1):
    cdef str v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # Cons
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method4(v3, v4)
    elif v0.tag == 1: # Nil
        return v1
cdef UH0 method2(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, Mut1 v2, numpy.ndarray[object,ndim=1] v3):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef Mut0 v6
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef UH0 v11
    cdef Tuple0 tmp0
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v22
    cdef unsigned long long v14
    cdef bint v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef unsigned long long v18
    cdef bint v26
    cdef numpy.ndarray[bint,ndim=1] v23
    cdef bint v24
    cdef bint v33
    cdef numpy.ndarray[signed long,ndim=1] v27
    cdef US0 v28
    cdef bint v29
    cdef UH0 v30
    cdef US1 v31
    cdef numpy.ndarray[bint,ndim=1] v32
    cdef unsigned long long v34
    cdef bint v35
    cdef bint v44
    cdef unsigned long long v36
    cdef bint v37
    cdef numpy.ndarray[signed long,ndim=1] v38
    cdef bint v39
    cdef unsigned long long v40
    cdef bint v48
    cdef numpy.ndarray[bint,ndim=1] v45
    cdef bint v46
    cdef bint v55
    cdef numpy.ndarray[signed long,ndim=1] v49
    cdef US0 v50
    cdef bint v51
    cdef UH0 v52
    cdef US1 v53
    cdef numpy.ndarray[bint,ndim=1] v54
    cdef unsigned long long v56
    cdef bint v57
    cdef bint v66
    cdef unsigned long long v58
    cdef bint v59
    cdef numpy.ndarray[signed long,ndim=1] v60
    cdef bint v61
    cdef unsigned long long v62
    cdef bint v70
    cdef numpy.ndarray[bint,ndim=1] v67
    cdef bint v68
    cdef bint v77
    cdef numpy.ndarray[signed long,ndim=1] v71
    cdef US0 v72
    cdef bint v73
    cdef UH0 v74
    cdef US1 v75
    cdef numpy.ndarray[bint,ndim=1] v76
    cdef unsigned long long v78
    cdef bint v87
    cdef unsigned long long v79
    cdef bint v80
    cdef numpy.ndarray[signed long,ndim=1] v81
    cdef bint v82
    cdef unsigned long long v83
    cdef bint v91
    cdef numpy.ndarray[bint,ndim=1] v88
    cdef bint v89
    cdef bint v98
    cdef numpy.ndarray[signed long,ndim=1] v92
    cdef US0 v93
    cdef bint v94
    cdef UH0 v95
    cdef US1 v96
    cdef numpy.ndarray[bint,ndim=1] v97
    cdef unsigned long long v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef numpy.ndarray[object,ndim=1] v106
    cdef unsigned long long v108
    cdef UH0 v107
    cdef unsigned long long v111
    cdef UH0 v109
    cdef unsigned long long v114
    cdef UH0 v112
    cdef unsigned long long v117
    cdef UH0 v115
    cdef unsigned long long v118
    cdef unsigned long long v119
    cdef Mut2 v120
    cdef unsigned long long v122
    cdef unsigned long long v123
    cdef numpy.ndarray[object,ndim=1] v124
    cdef unsigned long long v125
    cdef unsigned long long v126
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef numpy.ndarray[object,ndim=1] v129
    cdef Mut2 v130
    cdef unsigned long long v132
    cdef unsigned long long v133
    cdef numpy.ndarray[object,ndim=1] v134
    cdef unsigned long long v135
    cdef Mut2 v136
    cdef unsigned long long v138
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef unsigned long long v141
    cdef UH0 v142
    cdef Tuple0 tmp1
    cdef unsigned long long v143
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef unsigned long long v147
    cdef US1 v148
    cdef UH0 v150
    cdef UH0 v151
    v4 = len(v3)
    v5 = numpy.empty(v4,dtype=object)
    v6 = Mut0((<unsigned long long>0))
    while method0(v4, v6):
        v8 = v6.v0
        tmp0 = v3[v8]
        v9, v10, v11 = tmp0.v0, tmp0.v1, tmp0.v2
        del tmp0
        v12 = v9 - (<unsigned long long>1)
        v13 = (<unsigned long long>0) <= v12
        if v13:
            v14 = len(v1)
            v15 = v12 < v14
            if v15:
                v16 = v1[v12]
                v17 = (<unsigned long long>0) <= v10
                if v17:
                    v18 = len(v16)
                    v22 = v10 < v18
                else:
                    v22 = 0
                del v16
            else:
                v22 = 0
        else:
            v22 = 0
        if v22:
            v23 = v0[v12]
            v24 = v23[v10]
            del v23
            v26 = v24 == 0
        else:
            v26 = 0
        if v26:
            v27 = v1[v12]
            v28 = v27[v10]
            del v27
            if v28 == 0: # Empty
                v29 = 0
            elif v28 == 1: # Princess
                v29 = 1
            if v29:
                v30 = UH0_0("UP", v11)
                v31 = US1_1(v30)
                del v30
                v2.v0 = v31
                del v31
            else:
                pass
            v32 = v0[v12]
            v32[v10] = 1
            del v32
            v33 = 1
        else:
            v33 = 0
        v34 = v9 + (<unsigned long long>1)
        v35 = (<unsigned long long>0) <= v34
        if v35:
            v36 = len(v1)
            v37 = v34 < v36
            if v37:
                v38 = v1[v34]
                v39 = (<unsigned long long>0) <= v10
                if v39:
                    v40 = len(v38)
                    v44 = v10 < v40
                else:
                    v44 = 0
                del v38
            else:
                v44 = 0
        else:
            v44 = 0
        if v44:
            v45 = v0[v34]
            v46 = v45[v10]
            del v45
            v48 = v46 == 0
        else:
            v48 = 0
        if v48:
            v49 = v1[v34]
            v50 = v49[v10]
            del v49
            if v50 == 0: # Empty
                v51 = 0
            elif v50 == 1: # Princess
                v51 = 1
            if v51:
                v52 = UH0_0("DOWN", v11)
                v53 = US1_1(v52)
                del v52
                v2.v0 = v53
                del v53
            else:
                pass
            v54 = v0[v34]
            v54[v10] = 1
            del v54
            v55 = 1
        else:
            v55 = 0
        v56 = v10 - (<unsigned long long>1)
        v57 = (<unsigned long long>0) <= v9
        if v57:
            v58 = len(v1)
            v59 = v9 < v58
            if v59:
                v60 = v1[v9]
                v61 = (<unsigned long long>0) <= v56
                if v61:
                    v62 = len(v60)
                    v66 = v56 < v62
                else:
                    v66 = 0
                del v60
            else:
                v66 = 0
        else:
            v66 = 0
        if v66:
            v67 = v0[v9]
            v68 = v67[v56]
            del v67
            v70 = v68 == 0
        else:
            v70 = 0
        if v70:
            v71 = v1[v9]
            v72 = v71[v56]
            del v71
            if v72 == 0: # Empty
                v73 = 0
            elif v72 == 1: # Princess
                v73 = 1
            if v73:
                v74 = UH0_0("LEFT", v11)
                v75 = US1_1(v74)
                del v74
                v2.v0 = v75
                del v75
            else:
                pass
            v76 = v0[v9]
            v76[v56] = 1
            del v76
            v77 = 1
        else:
            v77 = 0
        v78 = v10 + (<unsigned long long>1)
        if v57:
            v79 = len(v1)
            v80 = v9 < v79
            if v80:
                v81 = v1[v9]
                v82 = (<unsigned long long>0) <= v78
                if v82:
                    v83 = len(v81)
                    v87 = v78 < v83
                else:
                    v87 = 0
                del v81
            else:
                v87 = 0
        else:
            v87 = 0
        if v87:
            v88 = v0[v9]
            v89 = v88[v78]
            del v88
            v91 = v89 == 0
        else:
            v91 = 0
        if v91:
            v92 = v1[v9]
            v93 = v92[v78]
            del v92
            if v93 == 0: # Empty
                v94 = 0
            elif v93 == 1: # Princess
                v94 = 1
            if v94:
                v95 = UH0_0("RIGHT", v11)
                v96 = US1_1(v95)
                del v95
                v2.v0 = v96
                del v96
            else:
                pass
            v97 = v0[v9]
            v97[v78] = 1
            del v97
            v98 = 1
        else:
            v98 = 0
        if v33:
            v99 = (<unsigned long long>1)
        else:
            v99 = (<unsigned long long>0)
        if v55:
            v100 = (<unsigned long long>1)
        else:
            v100 = (<unsigned long long>0)
        v101 = v99 + v100
        if v77:
            v102 = (<unsigned long long>1)
        else:
            v102 = (<unsigned long long>0)
        v103 = v101 + v102
        if v98:
            v104 = (<unsigned long long>1)
        else:
            v104 = (<unsigned long long>0)
        v105 = v103 + v104
        v106 = numpy.empty(v105,dtype=object)
        if v33:
            v107 = UH0_0("UP", v11)
            v106[(<unsigned long long>0)] = Tuple0(v12, v10, v107)
            del v107
            v108 = (<unsigned long long>1)
        else:
            v108 = (<unsigned long long>0)
        if v55:
            v109 = UH0_0("DOWN", v11)
            v106[v108] = Tuple0(v34, v10, v109)
            del v109
            v111 = v108 + (<unsigned long long>1)
        else:
            v111 = v108
        if v77:
            v112 = UH0_0("LEFT", v11)
            v106[v111] = Tuple0(v9, v56, v112)
            del v112
            v114 = v111 + (<unsigned long long>1)
        else:
            v114 = v111
        if v98:
            v115 = UH0_0("RIGHT", v11)
            v106[v114] = Tuple0(v9, v78, v115)
            del v115
            v117 = v114 + (<unsigned long long>1)
        else:
            v117 = v114
        del v11
        v5[v8] = v106
        del v106
        v118 = v8 + (<unsigned long long>1)
        v6.v0 = v118
    del v6
    v119 = len(v5)
    v120 = Mut2((<unsigned long long>0), (<unsigned long long>0))
    while method3(v119, v120):
        v122 = v120.v0
        v123 = v120.v1
        v124 = v5[v122]
        v125 = len(v124)
        del v124
        v126 = v123 + v125
        v127 = v122 + (<unsigned long long>1)
        v120.v0 = v127
        v120.v1 = v126
    v128 = v120.v1
    del v120
    v129 = numpy.empty(v128,dtype=object)
    v130 = Mut2((<unsigned long long>0), (<unsigned long long>0))
    while method3(v119, v130):
        v132 = v130.v0
        v133 = v130.v1
        v134 = v5[v132]
        v135 = len(v134)
        v136 = Mut2((<unsigned long long>0), v133)
        while method3(v135, v136):
            v138 = v136.v0
            v139 = v136.v1
            tmp1 = v134[v138]
            v140, v141, v142 = tmp1.v0, tmp1.v1, tmp1.v2
            del tmp1
            v129[v139] = Tuple0(v140, v141, v142)
            del v142
            v143 = v139 + (<unsigned long long>1)
            v144 = v138 + (<unsigned long long>1)
            v136.v0 = v144
            v136.v1 = v143
        del v134
        v145 = v136.v1
        del v136
        v146 = v132 + (<unsigned long long>1)
        v130.v0 = v146
        v130.v1 = v145
    del v5
    v147 = v130.v1
    del v130
    v148 = v2.v0
    if v148.tag == 0: # None
        return method2(v0, v1, v2, v129)
    elif v148.tag == 1: # Some
        v150 = (<US1_1>v148).v0
        del v129
        v151 = UH0_1()
        return method4(v150, v151)
cdef UH0 method1(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef numpy.ndarray[signed long,ndim=1] v8
    cdef unsigned long long v9
    cdef numpy.ndarray[bint,ndim=1] v10
    cdef Mut0 v11
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef US1 v16
    cdef Mut1 v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef UH0 v19
    v3 = len(v0)
    v4 = numpy.empty(v3,dtype=object)
    v5 = Mut0((<unsigned long long>0))
    while method0(v3, v5):
        v7 = v5.v0
        v8 = v0[v7]
        v9 = len(v8)
        del v8
        v10 = numpy.empty(v9,dtype=numpy.int8)
        v11 = Mut0((<unsigned long long>0))
        while method0(v9, v11):
            v13 = v11.v0
            v10[v13] = 0
            v14 = v13 + (<unsigned long long>1)
            v11.v0 = v14
        del v11
        v4[v7] = v10
        del v10
        v15 = v7 + (<unsigned long long>1)
        v5.v0 = v15
    del v5
    v16 = US1_0()
    v17 = Mut1(v16)
    del v16
    v18 = numpy.empty((<unsigned long long>1),dtype=object)
    v19 = UH0_1()
    v18[(<unsigned long long>0)] = Tuple0(v1, v2, v19)
    del v19
    return method2(v4, v0, v17, v18)
cdef void method5(UH0 v0) except *:
    cdef str v1
    cdef UH0 v2
    if v0.tag == 0: # Cons
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        printf("%s\n",v1->ptr)
        del v1
        method5(v2)
    elif v0.tag == 1: # Nil
        pass
cpdef void main() except *:
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef numpy.ndarray[signed long,ndim=1] v7
    cdef Mut0 v8
    cdef unsigned long long v10
    cdef bint v11
    cdef bint v13
    cdef US0 v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef UH0 v21
    v0 = (<unsigned long long>4)
    v1 = (<unsigned long long>2)
    v2 = (<unsigned long long>3)
    printf("%s\n","Initing")
    v3 = numpy.empty(v0,dtype=object)
    v4 = Mut0((<unsigned long long>0))
    while method0(v0, v4):
        v6 = v4.v0
        v7 = numpy.empty(v0,dtype=numpy.int32)
        v8 = Mut0((<unsigned long long>0))
        while method0(v0, v8):
            v10 = v8.v0
            v11 = v6 == v1
            if v11:
                v13 = v10 == v2
            else:
                v13 = 0
            if v13:
                v16 = 1
            else:
                v16 = 0
            v7[v10] = v16
            v17 = v10 + (<unsigned long long>1)
            v8.v0 = v17
        del v8
        v3[v6] = v7
        del v7
        v18 = v6 + (<unsigned long long>1)
        v4.v0 = v18
    del v4
    printf("%s\n","Starting")
    v19 = (<unsigned long long>0)
    v20 = (<unsigned long long>0)
    v21 = method1(v3, v19, v20)
    del v3
    printf("%s\n","Printing")
    method5(v21)
