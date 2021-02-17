import numpy
cimport numpy
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # noAction
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise_
    cdef readonly unsigned long long v0
    def __init__(self, unsigned long long v0): self.tag = 2; self.v0 = v0
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    cdef readonly unsigned long long v2
    cdef readonly unsigned long long v3
    cdef readonly unsigned long long v4
    cdef readonly US0 v5
    cdef readonly unsigned long long v6
    cdef readonly unsigned long long v7
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, unsigned long long v4, US0 v5, unsigned long long v6, unsigned long long v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
cdef class Tuple1:
    cdef readonly object v0
    cdef readonly unsigned long long v1
    def __init__(self, v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    def __init__(self, unsigned long long v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef void method1(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef char v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method1(v0, v1, v4)
    else:
        pass
cdef void method2(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef US0 v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef Tuple0 tmp0
    cdef unsigned long long v14
    cdef char v15
    cdef char v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef char v20
    cdef char v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef char v25
    cdef char v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef char v30
    cdef char v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef char v35
    cdef char v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef char v40
    cdef char v42
    cdef unsigned long long v43
    cdef unsigned long long v44
    cdef char v45
    cdef char v47
    cdef unsigned long long v48
    cdef unsigned long long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef unsigned long long v52
    cdef char v53
    cdef char v55
    cdef unsigned long long v56
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        tmp0 = v2[v3]
        v6, v7, v8, v9, v10, v11, v12, v13 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7
        del tmp0
        v14 = v3 * 73
        v15 = 0 <= v13
        if v15:
            v17 = v13 < 11
        else:
            v17 = 0
        if v17:
            v18 = v14 + v13
            v1[v18] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v19 = v14 + 11
        v20 = 0 <= v12
        if v20:
            v22 = v12 < 11
        else:
            v22 = 0
        if v22:
            v23 = v19 + v12
            v1[v23] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v24 = v19 + 11
        v25 = 0 <= v10
        if v25:
            v27 = v10 < 11
        else:
            v27 = 0
        if v27:
            v28 = v24 + v10
            v1[v28] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v29 = v24 + 11
        v30 = 0 <= v6
        if v30:
            v32 = v6 < 13
        else:
            v32 = 0
        if v32:
            v33 = v29 + v6
            v1[v33] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v34 = v29 + 13
        v35 = 0 <= v7
        if v35:
            v37 = v7 < 4
        else:
            v37 = 0
        if v37:
            v38 = v34 + v7
            v1[v38] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v39 = v29 + 17
        v40 = 0 <= v8
        if v40:
            v42 = v8 < 13
        else:
            v42 = 0
        if v42:
            v43 = v39 + v8
            v1[v43] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v44 = v39 + 13
        v45 = 0 <= v9
        if v45:
            v47 = v9 < 4
        else:
            v47 = 0
        if v47:
            v48 = v44 + v9
            v1[v48] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v49 = v29 + 34
        if v11.tag == 0: # call
            v1[v49] = 1.000000
        elif v11.tag == 1: # noAction
            v50 = v49 + 1
            v1[v50] = 1.000000
        elif v11.tag == 2: # raise_
            v51 = (<US0_2>v11).v0
            v52 = v49 + 2
            v53 = 0 <= v51
            if v53:
                v55 = v51 < 4
            else:
                v55 = 0
            if v55:
                v56 = v52 + v51
                v1[v56] = 1.000000
            else:
                raise Exception("Value out of bounds.")
        del v11
        method2(v0, v1, v2, v5)
    else:
        pass
cdef Tuple2 method6(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, unsigned long long v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef float v7
    cdef char v8
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef char v9
    cdef unsigned long long v10
    v5 = v2 < v0
    if v5:
        v6 = v2 + 1
        v7 = v1[v2]
        v8 = v7 == 0.000000
        if v8:
            v15, v16 = v3, v4
        else:
            v9 = v7 == 1.000000
            if v9:
                v10 = v4 + 1
                v15, v16 = v2, v10
            else:
                raise Exception("Unpickling failure. The int type must either be active or inactive.")
        return method6(v0, v1, v6, v15, v16)
    else:
        return Tuple2(v3, v4)
cdef Tuple2 method5(numpy.ndarray[float,ndim=1] v0, unsigned long long v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef Tuple2 tmp1
    cdef char v7
    cdef unsigned long long v8
    v3 = 0
    v4 = 0
    tmp1 = method6(v1, v0, v2, v3, v4)
    v5, v6 = tmp1.v0, tmp1.v1
    del tmp1
    v7 = 1 < v6
    if v7:
        raise Exception("Unpickling failure. Too many active indices in the one-hot vector.")
    else:
        pass
    v8 = v5 - v2
    return Tuple2(v8, v6)
cdef unsigned long long method4(numpy.ndarray[float,ndim=1] v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef char v9
    cdef unsigned long long v156
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef Tuple2 tmp2
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef Tuple2 tmp3
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef Tuple2 tmp4
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef Tuple2 tmp5
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef Tuple2 tmp6
    cdef unsigned long long v25
    cdef char v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef Tuple2 tmp7
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef Tuple2 tmp8
    cdef unsigned long long v35
    cdef char v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef char v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef float v42
    cdef char v43
    cdef unsigned long long v47
    cdef char v44
    cdef unsigned long long v48
    cdef float v49
    cdef char v50
    cdef unsigned long long v54
    cdef char v51
    cdef unsigned long long v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef Tuple2 tmp9
    cdef char v59
    cdef US0 v62
    cdef unsigned long long v63
    cdef char v64
    cdef US0 v66
    cdef unsigned long long v67
    cdef char v68
    cdef unsigned long long v69
    cdef char v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef char v73
    cdef unsigned long long v74
    cdef unsigned long long v75
    cdef char v76
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef char v79
    cdef unsigned long long v80
    cdef char v81
    cdef unsigned long long v83
    cdef unsigned long long v84
    cdef unsigned long long v85
    cdef Tuple2 tmp10
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef Tuple2 tmp11
    cdef unsigned long long v89
    cdef unsigned long long v90
    cdef unsigned long long v91
    cdef Tuple2 tmp12
    cdef unsigned long long v92
    cdef unsigned long long v93
    cdef unsigned long long v94
    cdef Tuple2 tmp13
    cdef unsigned long long v95
    cdef unsigned long long v96
    cdef unsigned long long v97
    cdef Tuple2 tmp14
    cdef unsigned long long v98
    cdef char v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef unsigned long long v102
    cdef unsigned long long v103
    cdef unsigned long long v104
    cdef Tuple2 tmp15
    cdef unsigned long long v105
    cdef unsigned long long v106
    cdef unsigned long long v107
    cdef Tuple2 tmp16
    cdef unsigned long long v108
    cdef char v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef char v112
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef float v115
    cdef char v116
    cdef unsigned long long v120
    cdef char v117
    cdef unsigned long long v121
    cdef float v122
    cdef char v123
    cdef unsigned long long v127
    cdef char v124
    cdef unsigned long long v128
    cdef unsigned long long v129
    cdef unsigned long long v130
    cdef unsigned long long v131
    cdef Tuple2 tmp17
    cdef char v132
    cdef US0 v135
    cdef unsigned long long v136
    cdef char v137
    cdef US0 v139
    cdef unsigned long long v140
    cdef char v141
    cdef unsigned long long v142
    cdef char v143
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef char v146
    cdef unsigned long long v147
    cdef unsigned long long v148
    cdef char v149
    cdef unsigned long long v150
    cdef unsigned long long v151
    cdef char v152
    cdef unsigned long long v153
    cdef char v154
    cdef char v155
    v5 = v3 < 3
    if v5:
        v6 = v3 + 1
        v7 = v3 * 73
        v8 = v1 + v7
        v9 = v3 == v4
        if v9:
            v10 = v8 + 11
            tmp2 = method5(v0, v10, v8)
            v11, v12 = tmp2.v0, tmp2.v1
            del tmp2
            v13 = v10 + 11
            tmp3 = method5(v0, v13, v10)
            v14, v15 = tmp3.v0, tmp3.v1
            del tmp3
            v16 = v13 + 11
            tmp4 = method5(v0, v16, v13)
            v17, v18 = tmp4.v0, tmp4.v1
            del tmp4
            v19 = v16 + 13
            tmp5 = method5(v0, v19, v16)
            v20, v21 = tmp5.v0, tmp5.v1
            del tmp5
            v22 = v19 + 4
            tmp6 = method5(v0, v22, v19)
            v23, v24 = tmp6.v0, tmp6.v1
            del tmp6
            v25 = v21 + v24
            v26 = v25 == 1
            if v26:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v27 = v25 // 2
            v28 = v16 + 17
            v29 = v28 + 13
            tmp7 = method5(v0, v29, v28)
            v30, v31 = tmp7.v0, tmp7.v1
            del tmp7
            v32 = v29 + 4
            tmp8 = method5(v0, v32, v29)
            v33, v34 = tmp8.v0, tmp8.v1
            del tmp8
            v35 = v31 + v34
            v36 = v35 == 1
            if v36:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v37 = v35 // 2
            v38 = v27 + v37
            v39 = v38 == 1
            if v39:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v40 = v38 // 2
            v41 = v16 + 34
            v42 = v0[v41]
            v43 = v42 == 1.000000
            if v43:
                v47 = 1
            else:
                v44 = v42 == 0.000000
                if v44:
                    v47 = 0
                else:
                    raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
            v48 = v41 + 1
            v49 = v0[v48]
            v50 = v49 == 1.000000
            if v50:
                v54 = 1
            else:
                v51 = v49 == 0.000000
                if v51:
                    v54 = 0
                else:
                    raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
            v55 = v41 + 2
            v56 = v55 + 4
            tmp9 = method5(v0, v56, v55)
            v57, v58 = tmp9.v0, tmp9.v1
            del tmp9
            v59 = v54 == 1
            if v59:
                v62 = US0_1()
            else:
                v62 = US0_0()
            v63 = v47 + v54
            v64 = v58 == 1
            if v64:
                v66 = US0_2(v57)
            else:
                v66 = v62
            del v62
            v67 = v63 + v58
            v68 = 1 < v67
            if v68:
                raise Exception("Unpickling failure. Only a single case of an union type should be active at most.")
            else:
                pass
            v69 = v40 + v67
            v70 = v69 == 1
            if v70:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v71 = v69 // 2
            v72 = v18 + v71
            v73 = v72 == 1
            if v73:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v74 = v72 // 2
            v75 = v15 + v74
            v76 = v75 == 1
            if v76:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v77 = v75 // 2
            v78 = v12 + v77
            v79 = v78 == 1
            if v79:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v80 = v78 // 2
            v81 = v80 == 1
            if v81:
                v2[v3] = Tuple0(v20, v23, v30, v33, v17, v66, v14, v11)
            else:
                pass
            del v66
            v156 = v4 + v80
        else:
            v83 = v8 + 11
            tmp10 = method5(v0, v83, v8)
            v84, v85 = tmp10.v0, tmp10.v1
            del tmp10
            v86 = v83 + 11
            tmp11 = method5(v0, v86, v83)
            v87, v88 = tmp11.v0, tmp11.v1
            del tmp11
            v89 = v86 + 11
            tmp12 = method5(v0, v89, v86)
            v90, v91 = tmp12.v0, tmp12.v1
            del tmp12
            v92 = v89 + 13
            tmp13 = method5(v0, v92, v89)
            v93, v94 = tmp13.v0, tmp13.v1
            del tmp13
            v95 = v92 + 4
            tmp14 = method5(v0, v95, v92)
            v96, v97 = tmp14.v0, tmp14.v1
            del tmp14
            v98 = v94 + v97
            v99 = v98 == 1
            if v99:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v100 = v98 // 2
            v101 = v89 + 17
            v102 = v101 + 13
            tmp15 = method5(v0, v102, v101)
            v103, v104 = tmp15.v0, tmp15.v1
            del tmp15
            v105 = v102 + 4
            tmp16 = method5(v0, v105, v102)
            v106, v107 = tmp16.v0, tmp16.v1
            del tmp16
            v108 = v104 + v107
            v109 = v108 == 1
            if v109:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v110 = v108 // 2
            v111 = v100 + v110
            v112 = v111 == 1
            if v112:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v113 = v111 // 2
            v114 = v89 + 34
            v115 = v0[v114]
            v116 = v115 == 1.000000
            if v116:
                v120 = 1
            else:
                v117 = v115 == 0.000000
                if v117:
                    v120 = 0
                else:
                    raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
            v121 = v114 + 1
            v122 = v0[v121]
            v123 = v122 == 1.000000
            if v123:
                v127 = 1
            else:
                v124 = v122 == 0.000000
                if v124:
                    v127 = 0
                else:
                    raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
            v128 = v114 + 2
            v129 = v128 + 4
            tmp17 = method5(v0, v129, v128)
            v130, v131 = tmp17.v0, tmp17.v1
            del tmp17
            v132 = v127 == 1
            if v132:
                v135 = US0_1()
            else:
                v135 = US0_0()
            v136 = v120 + v127
            v137 = v131 == 1
            if v137:
                v139 = US0_2(v130)
            else:
                v139 = v135
            del v135; del v139
            v140 = v136 + v131
            v141 = 1 < v140
            if v141:
                raise Exception("Unpickling failure. Only a single case of an union type should be active at most.")
            else:
                pass
            v142 = v113 + v140
            v143 = v142 == 1
            if v143:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v144 = v142 // 2
            v145 = v91 + v144
            v146 = v145 == 1
            if v146:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v147 = v145 // 2
            v148 = v88 + v147
            v149 = v148 == 1
            if v149:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v150 = v148 // 2
            v151 = v85 + v150
            v152 = v151 == 1
            if v152:
                raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
            else:
                pass
            v153 = v151 // 2
            v154 = v153 == 0
            v155 = v154 != 1
            if v155:
                raise Exception("Expected an inactive subsequence in the array unpickler.")
            else:
                pass
            v156 = v4
        return method4(v0, v1, v2, v6, v156)
    else:
        return v4
cdef void method7(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef US0 v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef Tuple0 tmp18
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        tmp18 = v1[v3]
        v6, v7, v8, v9, v10, v11, v12, v13 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4, tmp18.v5, tmp18.v6, tmp18.v7
        del tmp18
        v2[v3] = Tuple0(v6, v7, v8, v9, v10, v11, v12, v13)
        del v11
        method7(v0, v1, v2, v5)
    else:
        pass
cdef Tuple1 method3(numpy.ndarray[float,ndim=1] v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    v2 = numpy.empty(3,dtype=object)
    v3 = 0
    v4 = 0
    v5 = method4(v0, v1, v2, v3, v4)
    v6 = numpy.empty(v5,dtype=object)
    v7 = 0
    method7(v5, v2, v6, v7)
    del v2
    return Tuple1(v6, 1)
cdef char method8(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef US0 v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef Tuple0 tmp20
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef US0 v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef Tuple0 tmp21
    cdef char v21
    cdef char v23
    cdef char v27
    cdef char v24
    cdef char v38
    cdef char v28
    cdef char v32
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef char v33
    cdef unsigned long long v39
    v3 = len(v0)
    v4 = v2 < v3
    if v4:
        tmp20 = v0[v2]
        v5, v6, v7, v8, v9, v10, v11, v12 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4, tmp20.v5, tmp20.v6, tmp20.v7
        del tmp20
        tmp21 = v1[v2]
        v13, v14, v15, v16, v17, v18, v19, v20 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4, tmp21.v5, tmp21.v6, tmp21.v7
        del tmp21
        v21 = v5 == v13
        if v21:
            v23 = v6 == v14
        else:
            v23 = 0
        if v23:
            v24 = v7 == v15
            if v24:
                v27 = v8 == v16
            else:
                v27 = 0
        else:
            v27 = 0
        if v27:
            v28 = v9 == v17
            if v28:
                if v10.tag == 0 and v18.tag == 0: # call
                    v32 = 1
                elif v10.tag == 1 and v18.tag == 1: # noAction
                    v32 = 1
                elif v10.tag == 2 and v18.tag == 2: # raise_
                    v29 = (<US0_2>v10).v0; v30 = (<US0_2>v18).v0
                    v32 = v29 == v30
                else:
                    v32 = 0
                if v32:
                    v33 = v11 == v19
                    if v33:
                        v38 = v12 == v20
                    else:
                        v38 = 0
                else:
                    v38 = 0
            else:
                v38 = 0
        else:
            v38 = 0
        del v10; del v18
        if v38:
            v39 = v2 + 1
            return method8(v0, v1, v39)
        else:
            return 0
    else:
        return 1
cdef void method0():
    cdef US0 v0
    cdef numpy.ndarray[object,ndim=1] v1
    cdef numpy.ndarray[float,ndim=1] v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef char v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef unsigned long long v10
    cdef Tuple1 tmp19
    cdef char v11
    cdef char v12
    cdef unsigned long long v13
    cdef char v14
    cdef char v15
    cdef char v18
    cdef unsigned long long v16
    cdef char v19
    v0 = US0_1()
    v1 = numpy.empty(1,dtype=object)
    v1[0] = Tuple0(0, 1, 12, 3, 10, v0, 5, 5)
    del v0
    v2 = numpy.empty(219,dtype=numpy.float32)
    v3 = len(v2)
    v4 = 0
    method1(v3, v2, v4)
    v5 = len(v1)
    v6 = 3 < v5
    if v6:
        raise Exception("The given array is too large.")
    else:
        pass
    v7 = 0
    method2(v5, v2, v1, v7)
    v8 = 0
    tmp19 = method3(v2, v8)
    v9, v10 = tmp19.v0, tmp19.v1
    del tmp19
    del v2
    v11 = v10 == 1
    v12 = v11 != 1
    if v12:
        raise Exception("Invalid format.")
    else:
        pass
    v13 = len(v9)
    v14 = v5 == v13
    v15 = v14 != 1
    if v15:
        v18 = 0
    else:
        v16 = 0
        v18 = method8(v1, v9, v16)
    del v1; del v9
    v19 = v18 == 0
    if v19:
        raise Exception("Serialization and deserialization should result in the same result.")
    else:
        pass
cpdef void main():
    method0()
