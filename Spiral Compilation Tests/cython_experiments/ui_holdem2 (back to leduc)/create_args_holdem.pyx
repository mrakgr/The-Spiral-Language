import collections
import numpy
cimport numpy
import torch
cimport libc.math
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, numpy.ndarray[float,ndim=1] v0):
        return v0
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Mut0:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # call
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # fold
    def __init__(self): self.tag = 1
cdef class US1_2(US1): # raiseTo_
    cdef readonly signed short v0
    def __init__(self, signed short v0): self.tag = 2; self.v0 = v0
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # action_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # observation_
    cdef readonly signed char v0
    def __init__(self, signed char v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US0 v0
    cdef readonly UH0 v1
    def __init__(self, US0 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple1:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed short v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed short v15
    cdef readonly object v16
    cdef readonly signed short v17
    cdef readonly bint v18
    cdef readonly unsigned char v19
    cdef readonly object v20
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15, v16, signed short v17, bint v18, unsigned char v19, v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # oCall
    def __init__(self): self.tag = 0
cdef class US2_1(US2): # oFold
    def __init__(self): self.tag = 1
cdef class US2_2(US2): # oRaiseTo_
    cdef readonly signed short v0
    def __init__(self, signed short v0): self.tag = 2; self.v0 = v0
cdef class US2_3(US2): # oStreetOver
    def __init__(self): self.tag = 3
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US2 v0
    cdef readonly UH1 v1
    def __init__(self, US2 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class Tuple2:
    cdef readonly UH1 v0
    cdef readonly bint v1
    def __init__(self, UH1 v0, bint v1): self.v0 = v0; self.v1 = v1
cdef class Mut1:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Tuple3:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US1 v2
    def __init__(self, float v0, float v1, US1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure3():
    cdef list v0
    cdef unsigned long long v1
    cdef object v2
    def __init__(self, list v0, unsigned long long v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, numpy.ndarray[float,ndim=1] v3):
        cdef list v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef object v2 = self.v2
        cdef unsigned long long v4
        cdef numpy.ndarray[float,ndim=1] v5
        cdef unsigned long long v6
        cdef unsigned long long v7
        cdef bint v8
        cdef bint v9
        cdef Mut0 v10
        cdef unsigned long long v12
        cdef float v13
        cdef float v14
        cdef float v15
        cdef UH0 v16
        cdef float v17
        cdef float v18
        cdef UH0 v19
        cdef float v20
        cdef float v21
        cdef signed char v22
        cdef signed char v23
        cdef unsigned char v24
        cdef signed short v25
        cdef signed char v26
        cdef signed char v27
        cdef unsigned char v28
        cdef signed short v29
        cdef numpy.ndarray[signed char,ndim=1] v30
        cdef signed short v31
        cdef bint v32
        cdef unsigned char v33
        cdef numpy.ndarray[object,ndim=1] v34
        cdef Tuple1 tmp7
        cdef bint v35
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef float v47
        cdef unsigned long long v48
        cdef unsigned long long v49
        cdef numpy.ndarray[float,ndim=1] v50
        cdef unsigned long long v51
        cdef unsigned long long v52
        cdef bint v53
        cdef bint v54
        cdef numpy.ndarray[float,ndim=1] v55
        cdef Mut0 v56
        cdef unsigned long long v58
        cdef float v59
        cdef float v60
        cdef float v61
        cdef UH0 v62
        cdef float v63
        cdef float v64
        cdef UH0 v65
        cdef float v66
        cdef float v67
        cdef signed char v68
        cdef signed char v69
        cdef unsigned char v70
        cdef signed short v71
        cdef signed char v72
        cdef signed char v73
        cdef unsigned char v74
        cdef signed short v75
        cdef numpy.ndarray[signed char,ndim=1] v76
        cdef signed short v77
        cdef bint v78
        cdef unsigned char v79
        cdef numpy.ndarray[object,ndim=1] v80
        cdef Tuple1 tmp8
        cdef bint v81
        cdef float v83
        cdef float v82
        cdef unsigned long long v84
        v4 = (<unsigned long long>2) * v1
        v5 = numpy.empty(v4,dtype=numpy.float32)
        v6 = len(v3)
        v7 = len(v0)
        v8 = v6 == v7
        v9 = v8 == 0
        if v9:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v10 = Mut0((<unsigned long long>0))
        while method0(v6, v10):
            v12 = v10.v0
            v13 = v3[v12]
            tmp7 = v0[v12]
            v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3, tmp7.v4, tmp7.v5, tmp7.v6, tmp7.v7, tmp7.v8, tmp7.v9, tmp7.v10, tmp7.v11, tmp7.v12, tmp7.v13, tmp7.v14, tmp7.v15, tmp7.v16, tmp7.v17, tmp7.v18, tmp7.v19, tmp7.v20
            del tmp7
            del v16; del v19; del v30; del v34
            v35 = v33 == (<unsigned char>0)
            if v35:
                v37 = v13
            else:
                v37 = -v13
            v5[v12] = v37
            if v35:
                v38, v39, v40, v41 = v17, v18, v20, v21
            else:
                v38, v39, v40, v41 = v20, v21, v17, v18
            v42 = v15 + v41
            v43 = v14 + v40
            v44 = -v39
            v45 = v43 - v42
            v46 = v44 + v45
            v47 = libc.math.exp(v46)
            v48 = v1 + v12
            v5[v48] = v47
            v49 = v12 + (<unsigned long long>1)
            v10.v0 = v49
        del v10
        v50 = v2(v5)
        del v5
        v51 = len(v50)
        v52 = len(v0)
        v53 = v51 == v52
        v54 = v53 == 0
        if v54:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v55 = numpy.empty(v51,dtype=numpy.float32)
        v56 = Mut0((<unsigned long long>0))
        while method0(v51, v56):
            v58 = v56.v0
            v59 = v50[v58]
            tmp8 = v0[v58]
            v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3, tmp8.v4, tmp8.v5, tmp8.v6, tmp8.v7, tmp8.v8, tmp8.v9, tmp8.v10, tmp8.v11, tmp8.v12, tmp8.v13, tmp8.v14, tmp8.v15, tmp8.v16, tmp8.v17, tmp8.v18, tmp8.v19, tmp8.v20
            del tmp8
            del v62; del v65; del v76; del v80
            v81 = v79 == (<unsigned char>0)
            if v81:
                v83 = v59
            else:
                v82 = -v59
                v83 = v82
            v55[v58] = v83
            v84 = v58 + (<unsigned long long>1)
            v56.v0 = v84
        del v50
        del v56
        return v55
cdef class Closure1():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, list v1):
        cdef object v0 = self.v0
        cdef unsigned long long v2
        cdef bint v3
        cdef numpy.ndarray[object,ndim=1] v4
        cdef object v5
        cdef unsigned long long v6
        cdef numpy.ndarray[float,ndim=2] v7
        cdef numpy.ndarray[signed char,ndim=2] v8
        cdef unsigned long long v9
        cdef Mut0 v10
        cdef unsigned long long v12
        cdef float v13
        cdef float v14
        cdef UH0 v15
        cdef float v16
        cdef float v17
        cdef UH0 v18
        cdef float v19
        cdef float v20
        cdef signed char v21
        cdef signed char v22
        cdef unsigned char v23
        cdef signed short v24
        cdef signed char v25
        cdef signed char v26
        cdef unsigned char v27
        cdef signed short v28
        cdef numpy.ndarray[signed char,ndim=1] v29
        cdef signed short v30
        cdef bint v31
        cdef unsigned char v32
        cdef numpy.ndarray[object,ndim=1] v33
        cdef Tuple1 tmp0
        cdef bint v34
        cdef UH0 v35
        cdef UH1 v36
        cdef bint v37
        cdef UH1 v38
        cdef bint v39
        cdef Tuple2 tmp1
        cdef numpy.ndarray[object,ndim=1] v40
        cdef numpy.ndarray[float,ndim=1] v41
        cdef signed short v42
        cdef signed short v43
        cdef signed short v44
        cdef signed char v45
        cdef signed char v46
        cdef bint v47
        cdef bint v50
        cdef signed short v48
        cdef signed short v51
        cdef signed short v52
        cdef str v53
        cdef bint v54
        cdef bint v57
        cdef signed short v55
        cdef signed short v58
        cdef signed short v59
        cdef str v60
        cdef signed char v61
        cdef signed char v62
        cdef bint v63
        cdef bint v66
        cdef signed short v64
        cdef signed short v67
        cdef signed short v68
        cdef str v69
        cdef bint v70
        cdef bint v73
        cdef signed short v71
        cdef signed short v74
        cdef signed short v75
        cdef str v76
        cdef signed short v77
        cdef unsigned long long tmp2
        cdef bint v78
        cdef bint v79
        cdef Mut1 v80
        cdef signed short v82
        cdef signed char v83
        cdef signed short v84
        cdef signed short v85
        cdef signed char v86
        cdef signed char v87
        cdef bint v88
        cdef bint v91
        cdef signed short v89
        cdef signed short v92
        cdef signed short v93
        cdef str v94
        cdef signed short v95
        cdef bint v96
        cdef bint v99
        cdef signed short v97
        cdef signed short v100
        cdef signed short v101
        cdef str v102
        cdef signed short v103
        cdef signed short v104
        cdef unsigned long long tmp3
        cdef bint v105
        cdef bint v106
        cdef Mut1 v107
        cdef signed short v109
        cdef US2 v110
        cdef signed short v111
        cdef signed short v112
        cdef signed short v113
        cdef signed short v114
        cdef signed short v115
        cdef signed short v116
        cdef signed short v117
        cdef signed char v118
        cdef signed char v119
        cdef bint v120
        cdef bint v123
        cdef signed short v121
        cdef signed short v124
        cdef signed short v125
        cdef str v126
        cdef bint v127
        cdef bint v130
        cdef signed short v128
        cdef signed short v131
        cdef signed short v132
        cdef str v133
        cdef signed char v134
        cdef signed char v135
        cdef bint v136
        cdef bint v139
        cdef signed short v137
        cdef signed short v140
        cdef signed short v141
        cdef str v142
        cdef bint v143
        cdef bint v146
        cdef signed short v144
        cdef signed short v147
        cdef signed short v148
        cdef str v149
        cdef signed short v150
        cdef unsigned long long tmp4
        cdef Mut1 v151
        cdef signed short v153
        cdef US1 v154
        cdef signed short v163
        cdef signed short v155
        cdef signed short v156
        cdef bint v157
        cdef bint v159
        cdef bint v160
        cdef str v161
        cdef signed short v164
        cdef unsigned long long v165
        cdef object v166
        cdef object v167
        cdef object v168
        cdef object v169
        cdef numpy.ndarray[float,ndim=2] v170
        cdef float v171
        cdef numpy.ndarray[signed long long,ndim=1] v172
        cdef object v173
        cdef numpy.ndarray[object,ndim=1] v174
        cdef Mut0 v175
        cdef unsigned long long v177
        cdef signed long long v178
        cdef float v179
        cdef float v180
        cdef float v181
        cdef UH0 v182
        cdef float v183
        cdef float v184
        cdef UH0 v185
        cdef float v186
        cdef float v187
        cdef signed char v188
        cdef signed char v189
        cdef unsigned char v190
        cdef signed short v191
        cdef signed char v192
        cdef signed char v193
        cdef unsigned char v194
        cdef signed short v195
        cdef numpy.ndarray[signed char,ndim=1] v196
        cdef signed short v197
        cdef bint v198
        cdef unsigned char v199
        cdef numpy.ndarray[object,ndim=1] v200
        cdef Tuple1 tmp5
        cdef signed short v201
        cdef unsigned long long tmp6
        cdef float v202
        cdef float v203
        cdef float v204
        cdef float v205
        cdef float v206
        cdef float v207
        cdef float v208
        cdef signed short v209
        cdef bint v210
        cdef US1 v230
        cdef bint v211
        cdef bint v212
        cdef bint v214
        cdef signed short v215
        cdef bint v216
        cdef bint v217
        cdef bint v219
        cdef signed short v220
        cdef bint v221
        cdef bint v223
        cdef bint v224
        cdef signed short v225
        cdef unsigned long long v231
        cdef object v232
        v2 = len(v1)
        v3 = v2 == (<unsigned long long>0)
        if v3:
            v4 = numpy.empty((<unsigned long long>0),dtype=object)
            v5 = Closure2()
            return Tuple0(v4, v5)
        else:
            pass # import torch
            v6 = len(v1)
            v7 = numpy.zeros((v6,(<signed short>344)),dtype=numpy.float32)
            v8 = numpy.ones((v6,(<signed short>10)),dtype=numpy.int8)
            v9 = len(v1)
            v10 = Mut0((<unsigned long long>0))
            while method0(v9, v10):
                v12 = v10.v0
                tmp0 = v1[v12]
                v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17, tmp0.v18, tmp0.v19, tmp0.v20
                del tmp0
                v34 = v32 == (<unsigned char>0)
                if v34:
                    v35 = v15
                else:
                    v35 = v18
                del v15; del v18
                v36 = UH1_1()
                v37 = 0
                tmp1 = method1(v35, v36, v37)
                v38, v39 = tmp1.v0, tmp1.v1
                del tmp1
                del v35; del v36
                v40 = method2(v38)
                del v38
                v41 = v7[v12,:]
                v42 = (<signed short>0)
                method5(v30, v41, v42)
                v43 = (<signed short>6)
                method5(v24, v41, v43)
                v44 = (<signed short>12)
                method5(v28, v41, v44)
                v45 = v21 // (<signed char>13)
                v46 = v21 % (<signed char>13)
                v47 = (<signed char>0) <= v45
                if v47:
                    v48 = <signed short>v45
                    v50 = v48 < (<signed short>4)
                else:
                    v50 = 0
                if v50:
                    v51 = <signed short>v45
                    v52 = (<signed short>18) + v51
                    v41[v52] = (<float>1.000000)
                else:
                    v53 = f'Pickle failure. Int value out of bounds. Got: {v45} Size: {(<signed short>4)}'
                    raise Exception(v53)
                v54 = (<signed char>0) <= v46
                if v54:
                    v55 = <signed short>v46
                    v57 = v55 < (<signed short>13)
                else:
                    v57 = 0
                if v57:
                    v58 = <signed short>v46
                    v59 = (<signed short>22) + v58
                    v41[v59] = (<float>1.000000)
                else:
                    v60 = f'Pickle failure. Int value out of bounds. Got: {v46} Size: {(<signed short>13)}'
                    raise Exception(v60)
                v61 = v22 // (<signed char>13)
                v62 = v22 % (<signed char>13)
                v63 = (<signed char>0) <= v61
                if v63:
                    v64 = <signed short>v61
                    v66 = v64 < (<signed short>4)
                else:
                    v66 = 0
                if v66:
                    v67 = <signed short>v61
                    v68 = (<signed short>35) + v67
                    v41[v68] = (<float>1.000000)
                else:
                    v69 = f'Pickle failure. Int value out of bounds. Got: {v61} Size: {(<signed short>4)}'
                    raise Exception(v69)
                v70 = (<signed char>0) <= v62
                if v70:
                    v71 = <signed short>v62
                    v73 = v71 < (<signed short>13)
                else:
                    v73 = 0
                if v73:
                    v74 = <signed short>v62
                    v75 = (<signed short>39) + v74
                    v41[v75] = (<float>1.000000)
                else:
                    v76 = f'Pickle failure. Int value out of bounds. Got: {v62} Size: {(<signed short>13)}'
                    raise Exception(v76)
                tmp2 = len(v29)
                if <signed short>tmp2 != tmp2: raise Exception("The conversion to signed short failed.")
                v77 = <signed short>tmp2
                v78 = (<signed short>5) < v77
                if v78:
                    raise Exception("Pickle failure. The given array is too large.")
                else:
                    pass
                v79 = v77 == (<signed short>0)
                if v79:
                    v41[(<signed short>52)] = (<float>1.000000)
                else:
                    pass
                v80 = Mut1((<signed short>0))
                while method7(v77, v80):
                    v82 = v80.v0
                    v83 = v29[v82]
                    v84 = v82 * (<signed short>17)
                    v85 = (<signed short>53) + v84
                    v86 = v83 // (<signed char>13)
                    v87 = v83 % (<signed char>13)
                    v88 = (<signed char>0) <= v86
                    if v88:
                        v89 = <signed short>v86
                        v91 = v89 < (<signed short>4)
                    else:
                        v91 = 0
                    if v91:
                        v92 = <signed short>v86
                        v93 = v85 + v92
                        v41[v93] = (<float>1.000000)
                    else:
                        v94 = f'Pickle failure. Int value out of bounds. Got: {v86} Size: {(<signed short>4)}'
                        raise Exception(v94)
                    v95 = v85 + (<signed short>4)
                    v96 = (<signed char>0) <= v87
                    if v96:
                        v97 = <signed short>v87
                        v99 = v97 < (<signed short>13)
                    else:
                        v99 = 0
                    if v99:
                        v100 = <signed short>v87
                        v101 = v95 + v100
                        v41[v101] = (<float>1.000000)
                    else:
                        v102 = f'Pickle failure. Int value out of bounds. Got: {v87} Size: {(<signed short>13)}'
                        raise Exception(v102)
                    v103 = v82 + (<signed short>1)
                    v80.v0 = v103
                del v29
                del v80
                tmp3 = len(v40)
                if <signed short>tmp3 != tmp3: raise Exception("The conversion to signed short failed.")
                v104 = <signed short>tmp3
                v105 = (<signed short>19) < v104
                if v105:
                    raise Exception("Pickle failure. The given array is too large.")
                else:
                    pass
                v106 = v104 == (<signed short>0)
                if v106:
                    v41[(<signed short>138)] = (<float>1.000000)
                else:
                    pass
                v107 = Mut1((<signed short>0))
                while method7(v104, v107):
                    v109 = v107.v0
                    v110 = v40[v109]
                    v111 = v109 * (<signed short>9)
                    v112 = (<signed short>139) + v111
                    if v110.tag == 0: # oCall
                        v41[v112] = (<float>1.000000)
                    elif v110.tag == 1: # oFold
                        v113 = v112 + (<signed short>1)
                        v41[v113] = (<float>1.000000)
                    elif v110.tag == 2: # oRaiseTo_
                        v114 = (<US2_2>v110).v0
                        v115 = v112 + (<signed short>2)
                        method5(v114, v41, v115)
                    elif v110.tag == 3: # oStreetOver
                        v116 = v112 + (<signed short>8)
                        v41[v116] = (<float>1.000000)
                    del v110
                    v117 = v109 + (<signed short>1)
                    v107.v0 = v117
                del v40
                del v107
                v118 = v25 // (<signed char>13)
                v119 = v25 % (<signed char>13)
                v120 = (<signed char>0) <= v118
                if v120:
                    v121 = <signed short>v118
                    v123 = v121 < (<signed short>4)
                else:
                    v123 = 0
                if v123:
                    v124 = <signed short>v118
                    v125 = (<signed short>310) + v124
                    v41[v125] = (<float>1.000000)
                else:
                    v126 = f'Pickle failure. Int value out of bounds. Got: {v118} Size: {(<signed short>4)}'
                    raise Exception(v126)
                v127 = (<signed char>0) <= v119
                if v127:
                    v128 = <signed short>v119
                    v130 = v128 < (<signed short>13)
                else:
                    v130 = 0
                if v130:
                    v131 = <signed short>v119
                    v132 = (<signed short>314) + v131
                    v41[v132] = (<float>1.000000)
                else:
                    v133 = f'Pickle failure. Int value out of bounds. Got: {v119} Size: {(<signed short>13)}'
                    raise Exception(v133)
                v134 = v26 // (<signed char>13)
                v135 = v26 % (<signed char>13)
                v136 = (<signed char>0) <= v134
                if v136:
                    v137 = <signed short>v134
                    v139 = v137 < (<signed short>4)
                else:
                    v139 = 0
                if v139:
                    v140 = <signed short>v134
                    v141 = (<signed short>327) + v140
                    v41[v141] = (<float>1.000000)
                else:
                    v142 = f'Pickle failure. Int value out of bounds. Got: {v134} Size: {(<signed short>4)}'
                    raise Exception(v142)
                v143 = (<signed char>0) <= v135
                if v143:
                    v144 = <signed short>v135
                    v146 = v144 < (<signed short>13)
                else:
                    v146 = 0
                if v146:
                    v147 = <signed short>v135
                    v148 = (<signed short>331) + v147
                    v41[v148] = (<float>1.000000)
                else:
                    v149 = f'Pickle failure. Int value out of bounds. Got: {v135} Size: {(<signed short>13)}'
                    raise Exception(v149)
                del v41
                tmp4 = len(v33)
                if <signed short>tmp4 != tmp4: raise Exception("The conversion to signed short failed.")
                v150 = <signed short>tmp4
                v151 = Mut1((<signed short>0))
                while method7(v150, v151):
                    v153 = v151.v0
                    v154 = v33[v153]
                    if v154.tag == 0: # call
                        v163 = (<signed short>0)
                    elif v154.tag == 1: # fold
                        v163 = (<signed short>1)
                    elif v154.tag == 2: # raiseTo_
                        v155 = (<US1_2>v154).v0
                        v156 = (<signed short>-3) + v155
                        v157 = (<signed short>0) <= v156
                        if v157:
                            v159 = v156 < (<signed short>8)
                        else:
                            v159 = 0
                        v160 = v159 == 0
                        if v160:
                            v161 = f'Pickle failure. Int value out of bounds. Got: {v156} Size: {(<signed short>8)}'
                            raise Exception(v161)
                        else:
                            pass
                        v163 = (<signed short>2) + v156
                    del v154
                    v8[v12,v163] = 0
                    v164 = v153 + (<signed short>1)
                    v151.v0 = v164
                del v33
                del v151
                v165 = v12 + (<unsigned long long>1)
                v10.v0 = v165
            del v10
            v166 = torch.from_numpy(v7)
            del v7
            v167 = v8.view('bool')
            del v8
            v168 = torch.from_numpy(v167)
            del v167
            v169 = v0((<signed short>310), v166, v168)
            del v166; del v168
            v170 = v169[0]
            v171 = v169[1]
            v172 = v169[2]
            v173 = v169[3]
            del v169
            v174 = numpy.empty(v6,dtype=object)
            v175 = Mut0((<unsigned long long>0))
            while method0(v6, v175):
                v177 = v175.v0
                v178 = v172[v177]
                v179 = v170[v177,v178]
                tmp5 = v1[v177]
                v180, v181, v182, v183, v184, v185, v186, v187, v188, v189, v190, v191, v192, v193, v194, v195, v196, v197, v198, v199, v200 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4, tmp5.v5, tmp5.v6, tmp5.v7, tmp5.v8, tmp5.v9, tmp5.v10, tmp5.v11, tmp5.v12, tmp5.v13, tmp5.v14, tmp5.v15, tmp5.v16, tmp5.v17, tmp5.v18, tmp5.v19, tmp5.v20
                del tmp5
                del v182; del v185; del v196
                tmp6 = len(v200)
                if <signed short>tmp6 != tmp6: raise Exception("The conversion to signed short failed.")
                v201 = <signed short>tmp6
                del v200
                v202 = <float>v201
                v203 = v171 / v202
                v204 = (<float>1.000000) - v171
                v205 = v204 * v179
                v206 = v203 + v205
                v207 = libc.math.log(v206)
                v208 = libc.math.log(v179)
                v209 = <signed short>v178
                v210 = v209 < (<signed short>1)
                if v210:
                    v211 = v209 == (<signed short>0)
                    v212 = v211 == 0
                    if v212:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v230 = US1_0()
                else:
                    v214 = v209 < (<signed short>2)
                    if v214:
                        v215 = v209 - (<signed short>1)
                        v216 = v215 == (<signed short>0)
                        v217 = v216 == 0
                        if v217:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v230 = US1_1()
                    else:
                        v219 = v209 < (<signed short>10)
                        if v219:
                            v220 = v209 - (<signed short>2)
                            v221 = (<signed short>0) <= v220
                            if v221:
                                v223 = v220 < (<signed short>8)
                            else:
                                v223 = 0
                            v224 = v223 == 0
                            if v224:
                                raise Exception("Unpickle failure. The index should be less than size.")
                            else:
                                pass
                            v225 = (<signed short>3) + v220
                            v230 = US1_2(v225)
                        else:
                            raise Exception("Unpickle failure. Unpickling of an union failed.")
                v174[v177] = Tuple3(v208, v207, v230)
                del v230
                v231 = v177 + (<unsigned long long>1)
                v175.v0 = v231
            del v170; del v172
            del v175
            v232 = Closure3(v1, v6, v173)
            del v173
            return Tuple0(v174, v232)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure1(v0)
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut0 v3
        cdef unsigned long long v5
        cdef float v6
        cdef float v7
        cdef UH0 v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef signed char v14
        cdef signed char v15
        cdef unsigned char v16
        cdef signed short v17
        cdef signed char v18
        cdef signed char v19
        cdef unsigned char v20
        cdef signed short v21
        cdef numpy.ndarray[signed char,ndim=1] v22
        cdef signed short v23
        cdef bint v24
        cdef unsigned char v25
        cdef numpy.ndarray[object,ndim=1] v26
        cdef Tuple1 tmp9
        cdef signed short v27
        cdef unsigned long long tmp10
        cdef float v28
        cdef float v29
        cdef float v30
        cdef US1 v31
        cdef unsigned long long v32
        cdef object v33
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp9 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3, tmp9.v4, tmp9.v5, tmp9.v6, tmp9.v7, tmp9.v8, tmp9.v9, tmp9.v10, tmp9.v11, tmp9.v12, tmp9.v13, tmp9.v14, tmp9.v15, tmp9.v16, tmp9.v17, tmp9.v18, tmp9.v19, tmp9.v20
            del tmp9
            del v8; del v11; del v22
            tmp10 = len(v26)
            if <signed short>tmp10 != tmp10: raise Exception("The conversion to signed short failed.")
            v27 = <signed short>tmp10
            v28 = <float>v27
            v29 = (<float>1.000000) / v28
            v30 = libc.math.log(v29)
            v31 = numpy.random.choice(v26)
            del v26
            v2[v5] = Tuple3(v30, v30, v31)
            del v31
            v32 = v5 + (<unsigned long long>1)
            v3.v0 = v32
        del v3
        v33 = Closure2()
        return Tuple0(v2, v33)
cdef class Tuple4:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    cdef readonly signed char v5
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
cdef class Tuple5:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple6:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # action_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed short v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed short v15
    cdef readonly object v16
    cdef readonly signed short v17
    cdef readonly bint v18
    cdef readonly unsigned char v19
    cdef readonly object v20
    cdef readonly object v21
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15, v16, signed short v17, bint v18, unsigned char v19, v20, v21): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
cdef class UH2_1(UH2): # terminal_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly signed char v8
    cdef readonly signed char v9
    cdef readonly unsigned char v10
    cdef readonly signed short v11
    cdef readonly signed char v12
    cdef readonly signed char v13
    cdef readonly unsigned char v14
    cdef readonly signed short v15
    cdef readonly object v16
    cdef readonly signed short v17
    cdef readonly bint v18
    cdef readonly float v19
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15, v16, signed short v17, bint v18, float v19): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
cdef class Closure10():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef float v10
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef float v10 = self.v10
        return UH2_1(v11, v12, v13, v14, v15, v16, v17, v18, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 1, v10)
cdef class Closure14():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef object v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US1 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US0 v37
        cdef UH0 v38
        cdef US0 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US0_0(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US0_0(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure13():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure14(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v25)
cdef class Closure12():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef float v24
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22, float v23, float v24): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24
    def __call__(self, float v25, float v26, US1 v27):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef UH0 v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef bint v28
        cdef float v29
        cdef float v30
        cdef US0 v31
        cdef UH0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef float v36
        cdef float v37
        cdef US0 v38
        cdef UH0 v39
        cdef US0 v40
        cdef UH0 v41
        v28 = v0 == (<unsigned char>0)
        if v28:
            v29 = v26 + v22
            v30 = v25 + v21
            v31 = US0_0(v27)
            v32 = UH0_0(v31, v20)
            del v31
            v33 = US0_0(v27)
            v34 = UH0_0(v33, v17)
            del v33
            return method36(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method36(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure11():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef object v10
    cdef bint v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, numpy.ndarray[object,ndim=1] v12, signed char v13, signed char v14, signed char v15, signed char v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef bint v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure12(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH2_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v26)
cdef class Closure9():
    cdef object v0
    cdef signed short v1
    cdef object v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef signed char v8
    cdef unsigned char v9
    cdef signed short v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed short v14
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, numpy.ndarray[object,ndim=1] v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed short v10, signed char v11, signed char v12, unsigned char v13, signed short v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed char v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed short v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef signed short v14 = self.v14
        cdef signed char v23
        cdef signed short v24
        cdef unsigned long long tmp19
        cdef float v25
        cdef float v26
        cdef float v27
        cdef float v28
        cdef float v29
        cdef numpy.ndarray[signed char,ndim=1] v30
        cdef bint v31
        cdef numpy.ndarray[signed char,ndim=1] v32
        cdef object v33
        cdef US0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef UH0 v37
        v23 = v0[(<signed short>0)]
        tmp19 = len(v0)
        if <signed short>tmp19 != tmp19: raise Exception("The conversion to signed short failed.")
        v24 = <signed short>tmp19
        v25 = <float>v24
        v26 = (<float>1.000000) / v25
        v27 = libc.math.log(v26)
        v28 = v27 + v16
        v29 = v27 + v15
        v30 = v0[1:]
        del v30
        v31 = 1
        v32 = numpy.empty(5,dtype=numpy.int8)
        v32[0] = v3; v32[1] = v4; v32[2] = v5; v32[3] = v6; v32[4] = v23
        v33 = method14(v1, v2, v31, v7, v8, v9, v10, v11, v12, v13, v14, v32, v3, v4, v5, v6, v23)
        del v32
        v34 = US0_1(v23)
        v35 = UH0_0(v34, v17)
        del v34
        v36 = US0_1(v23)
        v37 = UH0_0(v36, v20)
        del v36
        return v33(v29, v28, v35, v18, v19, v37, v21, v22)
cdef class Closure18():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef object v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US1 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US0 v37
        cdef UH0 v38
        cdef US0 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US0_0(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US0_0(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method43(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method43(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure17():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure18(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v25)
cdef class Closure16():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef float v24
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22, float v23, float v24): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24
    def __call__(self, float v25, float v26, US1 v27):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef UH0 v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef bint v28
        cdef float v29
        cdef float v30
        cdef US0 v31
        cdef UH0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef float v36
        cdef float v37
        cdef US0 v38
        cdef UH0 v39
        cdef US0 v40
        cdef UH0 v41
        v28 = v0 == (<unsigned char>0)
        if v28:
            v29 = v26 + v22
            v30 = v25 + v21
            v31 = US0_0(v27)
            v32 = UH0_0(v31, v20)
            del v31
            v33 = US0_0(v27)
            v34 = UH0_0(v33, v17)
            del v33
            return method40(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method40(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure15():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef object v10
    cdef bint v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef object v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, numpy.ndarray[object,ndim=1] v12, signed char v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef bint v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef numpy.ndarray[signed char,ndim=1] v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure16(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH2_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v26)
cdef class Closure8():
    cdef object v0
    cdef signed short v1
    cdef object v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef unsigned char v8
    cdef signed short v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned char v12
    cdef signed short v13
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, numpy.ndarray[object,ndim=1] v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed short v13 = self.v13
        cdef signed char v22
        cdef signed short v23
        cdef unsigned long long tmp18
        cdef float v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef float v28
        cdef numpy.ndarray[signed char,ndim=1] v29
        cdef bint v30
        cdef numpy.ndarray[signed char,ndim=1] v31
        cdef object v32
        cdef US0 v33
        cdef UH0 v34
        cdef US0 v35
        cdef UH0 v36
        v22 = v0[(<signed short>0)]
        tmp18 = len(v0)
        if <signed short>tmp18 != tmp18: raise Exception("The conversion to signed short failed.")
        v23 = <signed short>tmp18
        v24 = <float>v23
        v25 = (<float>1.000000) / v24
        v26 = libc.math.log(v25)
        v27 = v26 + v15
        v28 = v26 + v14
        v29 = v0[1:]
        v30 = 1
        v31 = numpy.empty(4,dtype=numpy.int8)
        v31[0] = v3; v31[1] = v4; v31[2] = v5; v31[3] = v22
        v32 = method12(v1, v2, v30, v6, v7, v8, v9, v10, v11, v12, v13, v31, v3, v4, v5, v29, v22)
        del v29; del v31
        v33 = US0_1(v22)
        v34 = UH0_0(v33, v16)
        del v33
        v35 = US0_1(v22)
        v36 = UH0_0(v35, v19)
        del v35
        return v32(v28, v27, v34, v17, v18, v36, v20, v21)
cdef class Closure22():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef object v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef object v13
    cdef signed char v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef float v22
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
    def __call__(self, float v23, float v24, US1 v25):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef UH0 v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef bint v26
        cdef float v27
        cdef float v28
        cdef US0 v29
        cdef UH0 v30
        cdef US0 v31
        cdef UH0 v32
        cdef float v34
        cdef float v35
        cdef US0 v36
        cdef UH0 v37
        cdef US0 v38
        cdef UH0 v39
        v26 = v0 == (<unsigned char>0)
        if v26:
            v27 = v24 + v20
            v28 = v23 + v19
            v29 = US0_0(v25)
            v30 = UH0_0(v29, v18)
            del v29
            v31 = US0_0(v25)
            v32 = UH0_0(v31, v15)
            del v31
            return method47(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US0_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US0_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method47(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
cdef class Closure21():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure22(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH2_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v24)
cdef class Closure20():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef float v22
    cdef float v23
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21, float v22, float v23): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23
    def __call__(self, float v24, float v25, US1 v26):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef bint v27
        cdef float v28
        cdef float v29
        cdef US0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef UH0 v33
        cdef float v35
        cdef float v36
        cdef US0 v37
        cdef UH0 v38
        cdef US0 v39
        cdef UH0 v40
        v27 = v0 == (<unsigned char>0)
        if v27:
            v28 = v25 + v21
            v29 = v24 + v20
            v30 = US0_0(v26)
            v31 = UH0_0(v30, v19)
            del v30
            v32 = US0_0(v26)
            v33 = UH0_0(v32, v16)
            del v32
            return method44(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method44(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure19():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef object v10
    cdef bint v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, numpy.ndarray[object,ndim=1] v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef bint v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure20(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v25)
cdef class Closure7():
    cdef object v0
    cdef signed short v1
    cdef object v2
    cdef signed char v3
    cdef signed char v4
    cdef unsigned char v5
    cdef signed short v6
    cdef signed char v7
    cdef signed char v8
    cdef unsigned char v9
    cdef signed short v10
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, numpy.ndarray[object,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed short v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed char v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed short v10 = self.v10
        cdef signed char v19
        cdef signed short v20
        cdef unsigned long long tmp15
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef float v25
        cdef numpy.ndarray[signed char,ndim=1] v26
        cdef signed char v27
        cdef signed short v28
        cdef unsigned long long tmp16
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef float v33
        cdef numpy.ndarray[signed char,ndim=1] v34
        cdef signed char v35
        cdef signed short v36
        cdef unsigned long long tmp17
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef numpy.ndarray[signed char,ndim=1] v42
        cdef bint v43
        cdef numpy.ndarray[signed char,ndim=1] v44
        cdef object v45
        cdef US0 v46
        cdef US0 v47
        cdef US0 v48
        cdef UH0 v49
        cdef UH0 v50
        cdef UH0 v51
        cdef US0 v52
        cdef US0 v53
        cdef US0 v54
        cdef UH0 v55
        cdef UH0 v56
        cdef UH0 v57
        v19 = v0[(<signed short>0)]
        tmp15 = len(v0)
        if <signed short>tmp15 != tmp15: raise Exception("The conversion to signed short failed.")
        v20 = <signed short>tmp15
        v21 = <float>v20
        v22 = (<float>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v12
        v25 = v23 + v11
        v26 = v0[1:]
        v27 = v26[(<signed short>0)]
        tmp16 = len(v26)
        if <signed short>tmp16 != tmp16: raise Exception("The conversion to signed short failed.")
        v28 = <signed short>tmp16
        v29 = <float>v28
        v30 = (<float>1.000000) / v29
        v31 = libc.math.log(v30)
        v32 = v31 + v24
        v33 = v31 + v25
        v34 = v26[1:]
        del v26
        v35 = v34[(<signed short>0)]
        tmp17 = len(v34)
        if <signed short>tmp17 != tmp17: raise Exception("The conversion to signed short failed.")
        v36 = <signed short>tmp17
        v37 = <float>v36
        v38 = (<float>1.000000) / v37
        v39 = libc.math.log(v38)
        v40 = v39 + v32
        v41 = v39 + v33
        v42 = v34[1:]
        del v34
        v43 = 1
        v44 = numpy.empty(3,dtype=numpy.int8)
        v44[0] = v19; v44[1] = v27; v44[2] = v35
        v45 = method10(v1, v2, v43, v3, v4, v5, v6, v7, v8, v9, v10, v44, v19, v27, v42, v35)
        del v42; del v44
        v46 = US0_1(v35)
        v47 = US0_1(v27)
        v48 = US0_1(v19)
        v49 = UH0_0(v48, v13)
        del v48
        v50 = UH0_0(v47, v49)
        del v47; del v49
        v51 = UH0_0(v46, v50)
        del v46; del v50
        v52 = US0_1(v35)
        v53 = US0_1(v27)
        v54 = US0_1(v19)
        v55 = UH0_0(v54, v16)
        del v54
        v56 = UH0_0(v53, v55)
        del v53; del v55
        v57 = UH0_0(v52, v56)
        del v52; del v56
        return v45(v41, v40, v51, v14, v15, v57, v17, v18)
cdef class Closure26():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef float v18
    cdef float v19
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17, float v18, float v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, float v20, float v21, US1 v22):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef bint v23
        cdef float v24
        cdef float v25
        cdef US0 v26
        cdef UH0 v27
        cdef US0 v28
        cdef UH0 v29
        cdef float v31
        cdef float v32
        cdef US0 v33
        cdef UH0 v34
        cdef US0 v35
        cdef UH0 v36
        v23 = v0 == (<unsigned char>0)
        if v23:
            v24 = v21 + v17
            v25 = v20 + v16
            v26 = US0_0(v22)
            v27 = UH0_0(v26, v15)
            del v26
            v28 = US0_0(v22)
            v29 = UH0_0(v28, v12)
            del v28
            return method51(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_0(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_0(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method51(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure25():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef signed short v8
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef object v12
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef signed short v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef object v21
        v21 = Closure26(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH2_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v21)
cdef class Closure24():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef signed short v8
    cdef signed short v9
    cdef object v10
    cdef object v11
    cdef object v12
    cdef UH0 v13
    cdef float v14
    cdef float v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef float v19
    cdef float v20
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18, float v19, float v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, float v21, float v22, US1 v23):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef bint v24
        cdef float v25
        cdef float v26
        cdef US0 v27
        cdef UH0 v28
        cdef US0 v29
        cdef UH0 v30
        cdef float v32
        cdef float v33
        cdef US0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef UH0 v37
        v24 = v0 == (<unsigned char>0)
        if v24:
            v25 = v22 + v18
            v26 = v21 + v17
            v27 = US0_0(v23)
            v28 = UH0_0(v27, v16)
            del v27
            v29 = US0_0(v23)
            v30 = UH0_0(v29, v13)
            del v29
            return method48(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_0(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_0(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method48(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure23():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef signed short v9
    cdef object v10
    cdef bint v11
    cdef object v12
    cdef object v13
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef signed short v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef bint v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef object v22
        v22 = Closure24(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v19, v20, v21, v16, v17, v18, v14, v15)
        return UH2_0(v14, v15, v16, v17, v18, v19, v20, v21, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v22)
cdef class Tuple7:
    cdef readonly unsigned long long v0
    cdef readonly float v1
    cdef readonly float v2
    cdef readonly UH0 v3
    cdef readonly float v4
    cdef readonly float v5
    cdef readonly UH0 v6
    cdef readonly float v7
    cdef readonly float v8
    cdef readonly signed char v9
    cdef readonly signed char v10
    cdef readonly unsigned char v11
    cdef readonly signed short v12
    cdef readonly signed char v13
    cdef readonly signed char v14
    cdef readonly unsigned char v15
    cdef readonly signed short v16
    cdef readonly object v17
    cdef readonly signed short v18
    cdef readonly bint v19
    cdef readonly float v20
    def __init__(self, unsigned long long v0, float v1, float v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8, signed char v9, signed char v10, unsigned char v11, signed short v12, signed char v13, signed char v14, unsigned char v15, signed short v16, v17, signed short v18, bint v19, float v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure6():
    cdef signed short v0
    def __init__(self, signed short v0): self.v0 = v0
    def __call__(self, unsigned long long v1, v2, v3):
        cdef signed short v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v4
        cdef Mut0 v5
        cdef unsigned long long v7
        cdef numpy.ndarray[signed char,ndim=1] v8
        cdef numpy.ndarray[object,ndim=1] v9
        cdef Mut1 v10
        cdef signed short v12
        cdef bint v13
        cdef US1 v21
        cdef bint v15
        cdef signed short v17
        cdef signed short v18
        cdef signed short v22
        cdef UH0 v23
        cdef float v24
        cdef float v25
        cdef UH0 v26
        cdef float v27
        cdef float v28
        cdef signed char v29
        cdef signed short v30
        cdef unsigned long long tmp11
        cdef float v31
        cdef float v32
        cdef float v33
        cdef numpy.ndarray[signed char,ndim=1] v34
        cdef signed char v35
        cdef signed short v36
        cdef unsigned long long tmp12
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef numpy.ndarray[signed char,ndim=1] v41
        cdef signed char v42
        cdef signed short v43
        cdef unsigned long long tmp13
        cdef float v44
        cdef float v45
        cdef float v46
        cdef float v47
        cdef numpy.ndarray[signed char,ndim=1] v48
        cdef signed char v49
        cdef signed short v50
        cdef unsigned long long tmp14
        cdef float v51
        cdef float v52
        cdef float v53
        cdef float v54
        cdef numpy.ndarray[signed char,ndim=1] v55
        cdef bint v56
        cdef unsigned char v57
        cdef signed short v58
        cdef unsigned char v59
        cdef signed short v60
        cdef numpy.ndarray[signed char,ndim=1] v61
        cdef object v62
        cdef US0 v63
        cdef US0 v64
        cdef UH0 v65
        cdef UH0 v66
        cdef US0 v67
        cdef US0 v68
        cdef UH0 v69
        cdef UH0 v70
        cdef UH2 v71
        cdef unsigned long long v72
        v4 = numpy.empty(v1,dtype=object)
        v5 = Mut0((<unsigned long long>0))
        while method0(v1, v5):
            v7 = v5.v0
            v8 = numpy.arange(0,52,dtype=numpy.int8)
            numpy.random.shuffle(v8)
            v9 = numpy.empty(v0,dtype=object)
            v10 = Mut1((<signed short>0))
            while method7(v0, v10):
                v12 = v10.v0
                v13 = v12 == (<signed short>0)
                if v13:
                    v21 = US1_1()
                else:
                    v15 = v12 == (<signed short>1)
                    if v15:
                        v21 = US1_0()
                    else:
                        v17 = v0 - v12
                        v18 = v17 + (<signed short>2)
                        v21 = US1_2(v18)
                v9[v12] = v21
                del v21
                v22 = v12 + (<signed short>1)
                v10.v0 = v22
            del v10
            v23 = UH0_1()
            v24 = (<float>0.000000)
            v25 = (<float>0.000000)
            v26 = UH0_1()
            v27 = (<float>0.000000)
            v28 = (<float>0.000000)
            v29 = v8[(<signed short>0)]
            tmp11 = len(v8)
            if <signed short>tmp11 != tmp11: raise Exception("The conversion to signed short failed.")
            v30 = <signed short>tmp11
            v31 = <float>v30
            v32 = (<float>1.000000) / v31
            v33 = libc.math.log(v32)
            v34 = v8[1:]
            del v8
            v35 = v34[(<signed short>0)]
            tmp12 = len(v34)
            if <signed short>tmp12 != tmp12: raise Exception("The conversion to signed short failed.")
            v36 = <signed short>tmp12
            v37 = <float>v36
            v38 = (<float>1.000000) / v37
            v39 = libc.math.log(v38)
            v40 = v39 + v33
            v41 = v34[1:]
            del v34
            v42 = v41[(<signed short>0)]
            tmp13 = len(v41)
            if <signed short>tmp13 != tmp13: raise Exception("The conversion to signed short failed.")
            v43 = <signed short>tmp13
            v44 = <float>v43
            v45 = (<float>1.000000) / v44
            v46 = libc.math.log(v45)
            v47 = v46 + v40
            v48 = v41[1:]
            del v41
            v49 = v48[(<signed short>0)]
            tmp14 = len(v48)
            if <signed short>tmp14 != tmp14: raise Exception("The conversion to signed short failed.")
            v50 = <signed short>tmp14
            v51 = <float>v50
            v52 = (<float>1.000000) / v51
            v53 = libc.math.log(v52)
            v54 = v53 + v47
            v55 = v48[1:]
            del v48
            v56 = 1
            v57 = (<unsigned char>0)
            v58 = (<signed short>1)
            v59 = (<unsigned char>1)
            v60 = (<signed short>2)
            v61 = numpy.empty(0,dtype=numpy.int8)
            
            v62 = method8(v0, v9, v56, v42, v49, v59, v60, v29, v35, v57, v58, v61, v55)
            del v9; del v55; del v61
            v63 = US0_1(v35)
            v64 = US0_1(v29)
            v65 = UH0_0(v64, v23)
            del v23; del v64
            v66 = UH0_0(v63, v65)
            del v63; del v65
            v67 = US0_1(v49)
            v68 = US0_1(v42)
            v69 = UH0_0(v68, v26)
            del v26; del v68
            v70 = UH0_0(v67, v69)
            del v67; del v69
            v71 = v62(v54, v54, v66, v24, v25, v70, v27, v28)
            del v62; del v66; del v70
            v4[v7] = v71
            del v71
            v72 = v7 + (<unsigned long long>1)
            v5.v0 = v72
        del v5
        return method52(v3, v2, v4)
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, signed short v0):
        return Closure6(v0)
cdef class Closure28():
    cdef signed short v0
    def __init__(self, signed short v0): self.v0 = v0
    def __call__(self, unsigned long long v1, v2):
        cdef signed short v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v3
        cdef Mut0 v4
        cdef unsigned long long v6
        cdef numpy.ndarray[signed char,ndim=1] v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef Mut1 v9
        cdef signed short v11
        cdef bint v12
        cdef US1 v20
        cdef bint v14
        cdef signed short v16
        cdef signed short v17
        cdef signed short v21
        cdef UH0 v22
        cdef float v23
        cdef float v24
        cdef UH0 v25
        cdef float v26
        cdef float v27
        cdef signed char v28
        cdef signed short v29
        cdef unsigned long long tmp45
        cdef float v30
        cdef float v31
        cdef float v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef signed char v34
        cdef signed short v35
        cdef unsigned long long tmp46
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef numpy.ndarray[signed char,ndim=1] v40
        cdef signed char v41
        cdef signed short v42
        cdef unsigned long long tmp47
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef numpy.ndarray[signed char,ndim=1] v47
        cdef signed char v48
        cdef signed short v49
        cdef unsigned long long tmp48
        cdef float v50
        cdef float v51
        cdef float v52
        cdef float v53
        cdef numpy.ndarray[signed char,ndim=1] v54
        cdef bint v55
        cdef unsigned char v56
        cdef signed short v57
        cdef unsigned char v58
        cdef signed short v59
        cdef numpy.ndarray[signed char,ndim=1] v60
        cdef object v61
        cdef US0 v62
        cdef US0 v63
        cdef UH0 v64
        cdef UH0 v65
        cdef US0 v66
        cdef US0 v67
        cdef UH0 v68
        cdef UH0 v69
        cdef UH2 v70
        cdef unsigned long long v71
        v3 = numpy.empty(v1,dtype=object)
        v4 = Mut0((<unsigned long long>0))
        while method0(v1, v4):
            v6 = v4.v0
            v7 = numpy.arange(0,52,dtype=numpy.int8)
            numpy.random.shuffle(v7)
            v8 = numpy.empty(v0,dtype=object)
            v9 = Mut1((<signed short>0))
            while method7(v0, v9):
                v11 = v9.v0
                v12 = v11 == (<signed short>0)
                if v12:
                    v20 = US1_1()
                else:
                    v14 = v11 == (<signed short>1)
                    if v14:
                        v20 = US1_0()
                    else:
                        v16 = v0 - v11
                        v17 = v16 + (<signed short>2)
                        v20 = US1_2(v17)
                v8[v11] = v20
                del v20
                v21 = v11 + (<signed short>1)
                v9.v0 = v21
            del v9
            v22 = UH0_1()
            v23 = (<float>0.000000)
            v24 = (<float>0.000000)
            v25 = UH0_1()
            v26 = (<float>0.000000)
            v27 = (<float>0.000000)
            v28 = v7[(<signed short>0)]
            tmp45 = len(v7)
            if <signed short>tmp45 != tmp45: raise Exception("The conversion to signed short failed.")
            v29 = <signed short>tmp45
            v30 = <float>v29
            v31 = (<float>1.000000) / v30
            v32 = libc.math.log(v31)
            v33 = v7[1:]
            del v7
            v34 = v33[(<signed short>0)]
            tmp46 = len(v33)
            if <signed short>tmp46 != tmp46: raise Exception("The conversion to signed short failed.")
            v35 = <signed short>tmp46
            v36 = <float>v35
            v37 = (<float>1.000000) / v36
            v38 = libc.math.log(v37)
            v39 = v38 + v32
            v40 = v33[1:]
            del v33
            v41 = v40[(<signed short>0)]
            tmp47 = len(v40)
            if <signed short>tmp47 != tmp47: raise Exception("The conversion to signed short failed.")
            v42 = <signed short>tmp47
            v43 = <float>v42
            v44 = (<float>1.000000) / v43
            v45 = libc.math.log(v44)
            v46 = v45 + v39
            v47 = v40[1:]
            del v40
            v48 = v47[(<signed short>0)]
            tmp48 = len(v47)
            if <signed short>tmp48 != tmp48: raise Exception("The conversion to signed short failed.")
            v49 = <signed short>tmp48
            v50 = <float>v49
            v51 = (<float>1.000000) / v50
            v52 = libc.math.log(v51)
            v53 = v52 + v46
            v54 = v47[1:]
            del v47
            v55 = 1
            v56 = (<unsigned char>0)
            v57 = (<signed short>1)
            v58 = (<unsigned char>1)
            v59 = (<signed short>2)
            v60 = numpy.empty(0,dtype=numpy.int8)
            
            v61 = method8(v0, v8, v55, v41, v48, v58, v59, v28, v34, v56, v57, v60, v54)
            del v8; del v54; del v60
            v62 = US0_1(v34)
            v63 = US0_1(v28)
            v64 = UH0_0(v63, v22)
            del v22; del v63
            v65 = UH0_0(v62, v64)
            del v62; del v64
            v66 = US0_1(v48)
            v67 = US0_1(v41)
            v68 = UH0_0(v67, v25)
            del v25; del v67
            v69 = UH0_0(v66, v68)
            del v66; del v68
            v70 = v61(v53, v53, v65, v23, v24, v69, v26, v27)
            del v61; del v65; del v69
            v3[v6] = v70
            del v70
            v71 = v6 + (<unsigned long long>1)
            v4.v0 = v71
        del v4
        return method54(v2, v3)
cdef class Closure27():
    def __init__(self): pass
    def __call__(self, signed short v0):
        return Closure28(v0)
cdef class Mut3:
    cdef public signed short v0
    cdef public signed short v1
    def __init__(self, signed short v0, signed short v1): self.v0 = v0; self.v1 = v1
cdef class Closure31():
    cdef object v0
    cdef object v1
    cdef unsigned char v2
    cdef signed short v3
    cdef object v4
    def __init__(self, v0, v1, unsigned char v2, signed short v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, signed short v5):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef US1 v6
        cdef UH2 v7
        v6 = US1_2(v5)
        v7 = v4((<float>0.000000), (<float>0.000000), v6)
        del v6
        method55(v0, v1, v2, v3, v7)
cdef class Closure32():
    cdef object v0
    cdef object v1
    cdef unsigned char v2
    cdef signed short v3
    cdef object v4
    def __init__(self, v0, v1, unsigned char v2, signed short v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef US1 v5
        cdef UH2 v6
        v5 = US1_0()
        v6 = v4((<float>0.000000), (<float>0.000000), v5)
        del v5
        method55(v0, v1, v2, v3, v6)
cdef class Closure33():
    cdef object v0
    cdef object v1
    cdef unsigned char v2
    cdef signed short v3
    cdef object v4
    def __init__(self, v0, v1, unsigned char v2, signed short v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef object v4 = self.v4
        cdef US1 v5
        cdef UH2 v6
        v5 = US1_1()
        v6 = v4((<float>0.000000), (<float>0.000000), v5)
        del v5
        method55(v0, v1, v2, v3, v6)
cdef class Closure30():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, signed short v1, unsigned char v2, v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[signed char,ndim=1] v4
        cdef numpy.ndarray[object,ndim=1] v5
        cdef Mut1 v6
        cdef signed short v8
        cdef bint v9
        cdef US1 v17
        cdef bint v11
        cdef signed short v13
        cdef signed short v14
        cdef signed short v18
        cdef UH0 v19
        cdef float v20
        cdef float v21
        cdef UH0 v22
        cdef float v23
        cdef float v24
        cdef signed char v25
        cdef signed short v26
        cdef unsigned long long tmp52
        cdef float v27
        cdef float v28
        cdef float v29
        cdef numpy.ndarray[signed char,ndim=1] v30
        cdef signed char v31
        cdef signed short v32
        cdef unsigned long long tmp53
        cdef float v33
        cdef float v34
        cdef float v35
        cdef float v36
        cdef numpy.ndarray[signed char,ndim=1] v37
        cdef signed char v38
        cdef signed short v39
        cdef unsigned long long tmp54
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef numpy.ndarray[signed char,ndim=1] v44
        cdef signed char v45
        cdef signed short v46
        cdef unsigned long long tmp55
        cdef float v47
        cdef float v48
        cdef float v49
        cdef float v50
        cdef numpy.ndarray[signed char,ndim=1] v51
        cdef bint v52
        cdef unsigned char v53
        cdef signed short v54
        cdef unsigned char v55
        cdef signed short v56
        cdef numpy.ndarray[signed char,ndim=1] v57
        cdef object v58
        cdef US0 v59
        cdef US0 v60
        cdef UH0 v61
        cdef UH0 v62
        cdef US0 v63
        cdef US0 v64
        cdef UH0 v65
        cdef UH0 v66
        cdef UH2 v67
        v4 = numpy.arange(0,52,dtype=numpy.int8)
        numpy.random.shuffle(v4)
        v5 = numpy.empty(v1,dtype=object)
        v6 = Mut1((<signed short>0))
        while method7(v1, v6):
            v8 = v6.v0
            v9 = v8 == (<signed short>0)
            if v9:
                v17 = US1_1()
            else:
                v11 = v8 == (<signed short>1)
                if v11:
                    v17 = US1_0()
                else:
                    v13 = v1 - v8
                    v14 = v13 + (<signed short>2)
                    v17 = US1_2(v14)
            v5[v8] = v17
            del v17
            v18 = v8 + (<signed short>1)
            v6.v0 = v18
        del v6
        v19 = UH0_1()
        v20 = (<float>0.000000)
        v21 = (<float>0.000000)
        v22 = UH0_1()
        v23 = (<float>0.000000)
        v24 = (<float>0.000000)
        v25 = v4[(<signed short>0)]
        tmp52 = len(v4)
        if <signed short>tmp52 != tmp52: raise Exception("The conversion to signed short failed.")
        v26 = <signed short>tmp52
        v27 = <float>v26
        v28 = (<float>1.000000) / v27
        v29 = libc.math.log(v28)
        v30 = v4[1:]
        del v4
        v31 = v30[(<signed short>0)]
        tmp53 = len(v30)
        if <signed short>tmp53 != tmp53: raise Exception("The conversion to signed short failed.")
        v32 = <signed short>tmp53
        v33 = <float>v32
        v34 = (<float>1.000000) / v33
        v35 = libc.math.log(v34)
        v36 = v35 + v29
        v37 = v30[1:]
        del v30
        v38 = v37[(<signed short>0)]
        tmp54 = len(v37)
        if <signed short>tmp54 != tmp54: raise Exception("The conversion to signed short failed.")
        v39 = <signed short>tmp54
        v40 = <float>v39
        v41 = (<float>1.000000) / v40
        v42 = libc.math.log(v41)
        v43 = v42 + v36
        v44 = v37[1:]
        del v37
        v45 = v44[(<signed short>0)]
        tmp55 = len(v44)
        if <signed short>tmp55 != tmp55: raise Exception("The conversion to signed short failed.")
        v46 = <signed short>tmp55
        v47 = <float>v46
        v48 = (<float>1.000000) / v47
        v49 = libc.math.log(v48)
        v50 = v49 + v43
        v51 = v44[1:]
        del v44
        v52 = 1
        v53 = (<unsigned char>0)
        v54 = (<signed short>1)
        v55 = (<unsigned char>1)
        v56 = (<signed short>2)
        v57 = numpy.empty(0,dtype=numpy.int8)
        
        v58 = method8(v1, v5, v52, v38, v45, v55, v56, v25, v31, v53, v54, v57, v51)
        del v5; del v51; del v57
        v59 = US0_1(v31)
        v60 = US0_1(v25)
        v61 = UH0_0(v60, v19)
        del v19; del v60
        v62 = UH0_0(v59, v61)
        del v59; del v61
        v63 = US0_1(v45)
        v64 = US0_1(v38)
        v65 = UH0_0(v64, v22)
        del v22; del v64
        v66 = UH0_0(v63, v65)
        del v63; del v65
        v67 = v58(v50, v50, v62, v20, v21, v66, v23, v24)
        del v58; del v62; del v66
        method55(v0, v3, v2, v1, v67)
cdef class Closure29():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure30(v0)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple2 method1(UH0 v0, UH1 v1, bint v2):
    cdef US0 v3
    cdef UH0 v4
    cdef UH1 v18
    cdef bint v19
    cdef US1 v5
    cdef US2 v10
    cdef signed short v8
    cdef US2 v11
    cdef UH1 v12
    cdef UH1 v13
    cdef UH1 v14
    cdef signed char v17
    if v0.tag == 0: # cons_
        v3 = (<UH0_0>v0).v0; v4 = (<UH0_0>v0).v1
        if v3.tag == 0: # action_
            v5 = (<US0_0>v3).v0
            if v5.tag == 0: # call
                v10 = US2_0()
            elif v5.tag == 1: # fold
                v10 = US2_1()
            elif v5.tag == 2: # raiseTo_
                v8 = (<US1_2>v5).v0
                v10 = US2_2(v8)
            del v5
            if v2:
                v11 = US2_3()
                v12 = UH1_0(v11, v1)
                del v11
                v13 = UH1_0(v10, v12)
                del v12
                v18, v19 = v13, 0
                del v13
            else:
                v14 = UH1_0(v10, v1)
                v18, v19 = v14, 0
                del v14
            del v10
        elif v3.tag == 1: # observation_
            v17 = (<US0_1>v3).v0
            v18, v19 = v1, 1
        del v3
        return method1(v4, v18, v19)
    elif v0.tag == 1: # nil
        return Tuple2(v1, v2)
cdef signed short method3(UH1 v0, signed short v1) except *:
    cdef UH1 v3
    cdef signed short v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + (<signed short>1)
        return method3(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef signed short method4(numpy.ndarray[object,ndim=1] v0, UH1 v1, signed short v2) except *:
    cdef US2 v3
    cdef UH1 v4
    cdef signed short v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + (<signed short>1)
        return method4(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method2(UH1 v0):
    cdef signed short v1
    cdef signed short v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef signed short v4
    cdef signed short v5
    v1 = (<signed short>0)
    v2 = method3(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<signed short>0)
    v5 = method4(v3, v0, v4)
    return v3
cdef signed short method6(numpy.ndarray[float,ndim=1] v0, signed short v1, signed short v2, signed short v3) except *:
    cdef bint v4
    cdef signed short v5
    cdef signed short v6
    cdef signed short v7
    cdef signed long v8
    cdef signed short v9
    cdef signed short v10
    cdef signed short v11
    cdef signed short v12
    cdef float v13
    cdef signed short v14
    v4 = v2 < (<signed short>6)
    if v4:
        v5 = v2 + (<signed short>1)
        v6 = (<signed short>6) - v2
        v7 = v6 - (<signed short>1)
        v8 = <signed long>v7
        v9 = (<signed short>1) << v8
        v10 = <signed short>v2
        v11 = v1 + v10
        v12 = v3 // v9
        v13 = <float>v12
        v0[v11] = v13
        v14 = v3 % v9
        return method6(v0, v1, v5, v14)
    else:
        return v3
cdef void method5(signed short v0, numpy.ndarray[float,ndim=1] v1, signed short v2) except *:
    cdef signed long v3
    cdef signed long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef bint v8
    cdef bint v11
    cdef unsigned long long v9
    cdef signed short v12
    cdef signed short v13
    cdef signed short v14
    cdef str v15
    v3 = <signed long>(<signed short>6)
    v4 = v3 - (<signed long>1)
    v5 = (<unsigned long long>1) << v4
    v6 = v5 - (<unsigned long long>1)
    v7 = v5 + v6
    v8 = (<signed short>0) <= v0
    if v8:
        v9 = <unsigned long long>v0
        v11 = v9 < v7
    else:
        v11 = 0
    if v11:
        v12 = v0 + (<signed short>1)
        v13 = (<signed short>0)
        v14 = method6(v1, v2, v13, v12)
    else:
        v15 = f'Pickle failure. Bin int value out of bounds. Got: {v0} Size: {(<signed short>6)}'
        raise Exception(v15)
cdef bint method7(signed short v0, Mut1 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple4 method18(unsigned long long v0, signed char v1, signed char v2):
    cdef bint v3
    cdef signed char v4
    cdef bint v5
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef bint v57
    cdef signed char v15
    cdef bint v16
    cdef signed char v18
    cdef signed char v19
    cdef signed long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef bint v23
    cdef bint v24
    cdef signed char v25
    cdef bint v26
    cdef signed char v28
    cdef signed char v29
    cdef signed long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef bint v33
    cdef bint v34
    cdef signed char v35
    cdef bint v36
    cdef signed char v38
    cdef signed char v39
    cdef signed long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef bint v43
    cdef bint v44
    cdef bint v45
    cdef signed char v47
    cdef signed char v48
    cdef signed long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef signed char v59
    cdef signed char v60
    cdef signed char v61
    cdef bint v62
    cdef signed char v64
    cdef signed char v65
    cdef signed char v66
    cdef bint v67
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef bint v72
    cdef signed char v74
    cdef signed char v75
    cdef bint v76
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef signed char v93
    v3 = v2 < (<signed char>4)
    if v3:
        v4 = v1 + (<signed char>4)
        v5 = v4 < (<signed char>0)
        if v5:
            v7 = v4 + (<signed char>13)
        else:
            v7 = v4
        v8 = v2 * (<signed char>13)
        v9 = v8 + v7
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = v1 + (<signed char>3)
            v16 = v15 < (<signed char>0)
            if v16:
                v18 = v15 + (<signed char>13)
            else:
                v18 = v15
            v19 = v8 + v18
            v20 = <signed long>v19
            v21 = (<unsigned long long>1) << v20
            v22 = v0 & v21
            v23 = v22 == (<unsigned long long>0)
            v24 = v23 != 1
            if v24:
                v25 = v1 + (<signed char>2)
                v26 = v25 < (<signed char>0)
                if v26:
                    v28 = v25 + (<signed char>13)
                else:
                    v28 = v25
                v29 = v8 + v28
                v30 = <signed long>v29
                v31 = (<unsigned long long>1) << v30
                v32 = v0 & v31
                v33 = v32 == (<unsigned long long>0)
                v34 = v33 != 1
                if v34:
                    v35 = v1 + (<signed char>1)
                    v36 = v35 < (<signed char>0)
                    if v36:
                        v38 = v35 + (<signed char>13)
                    else:
                        v38 = v35
                    v39 = v8 + v38
                    v40 = <signed long>v39
                    v41 = (<unsigned long long>1) << v40
                    v42 = v0 & v41
                    v43 = v42 == (<unsigned long long>0)
                    v44 = v43 != 1
                    if v44:
                        v45 = v1 < (<signed char>0)
                        if v45:
                            v47 = v1 + (<signed char>13)
                        else:
                            v47 = v1
                        v48 = v8 + v47
                        v49 = <signed long>v48
                        v50 = (<unsigned long long>1) << v49
                        v51 = v0 & v50
                        v52 = v51 == (<unsigned long long>0)
                        v57 = v52 != 1
                    else:
                        v57 = 0
                else:
                    v57 = 0
            else:
                v57 = 0
        else:
            v57 = 0
        if v57:
            if v5:
                v59 = v4 + (<signed char>13)
            else:
                v59 = v4
            v60 = v8 + v59
            v61 = v1 + (<signed char>3)
            v62 = v61 < (<signed char>0)
            if v62:
                v64 = v61 + (<signed char>13)
            else:
                v64 = v61
            v65 = v8 + v64
            v66 = v1 + (<signed char>2)
            v67 = v66 < (<signed char>0)
            if v67:
                v69 = v66 + (<signed char>13)
            else:
                v69 = v66
            v70 = v8 + v69
            v71 = v1 + (<signed char>1)
            v72 = v71 < (<signed char>0)
            if v72:
                v74 = v71 + (<signed char>13)
            else:
                v74 = v71
            v75 = v8 + v74
            v76 = v1 < (<signed char>0)
            if v76:
                v78 = v1 + (<signed char>13)
            else:
                v78 = v1
            v79 = v8 + v78
            return Tuple4(v60, v65, v70, v75, v79, (<signed char>9))
        else:
            v80 = v2 + (<signed char>1)
            return method18(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method17(v0, v93)
cdef Tuple5 method21(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned char v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9):
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef bint v16
    cdef bint v17
    cdef bint v18
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef unsigned char v42
    cdef bint v43
    cdef signed char v44
    cdef signed char v55
    cdef signed char v66
    v10 = v3 < (<signed char>4)
    if v10:
        v11 = v3 * (<signed char>13)
        v12 = v11 + v2
        v13 = <signed long>v12
        v14 = (<unsigned long long>1) << v13
        v15 = v0 & v14
        v16 = v15 == (<unsigned long long>0)
        v17 = v16 != 1
        if v17:
            v18 = v4 == (<unsigned char>0)
            if v18:
                v37, v38, v39, v40, v41 = v12, v6, v7, v8, v9
            else:
                v19 = v4 == (<unsigned char>1)
                if v19:
                    v37, v38, v39, v40, v41 = v5, v12, v7, v8, v9
                else:
                    v20 = v4 == (<unsigned char>2)
                    if v20:
                        v37, v38, v39, v40, v41 = v5, v6, v12, v8, v9
                    else:
                        v21 = v4 == (<unsigned char>3)
                        if v21:
                            v37, v38, v39, v40, v41 = v5, v6, v7, v12, v9
                        else:
                            v37, v38, v39, v40, v41 = v5, v6, v7, v8, v12
            v42 = v4 + (<unsigned char>1)
            v43 = v42 < (<unsigned char>5)
            if v43:
                v44 = v3 + (<signed char>1)
                return method21(v0, v1, v2, v44, v42, v37, v38, v39, v40, v41)
            else:
                return Tuple5(v37, v38, v39, v40, v41)
        else:
            v55 = v3 + (<signed char>1)
            return method21(v0, v1, v2, v55, v4, v5, v6, v7, v8, v9)
    else:
        v66 = v2 - (<signed char>1)
        return method20(v0, v1, v66, v5, v6, v7, v8, v9, v4)
cdef Tuple5 method20(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method20(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method21(v0, v1, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple5(v3, v4, v5, v6, v7)
cdef Tuple6 method23(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
    cdef bint v8
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef bint v16
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef bint v17
    cdef bint v18
    cdef signed char v31
    cdef signed char v37
    v8 = v7 < (<signed char>4)
    if v8:
        v9 = v7 * (<signed char>13)
        v10 = v9 + v1
        v11 = <signed long>v10
        v12 = (<unsigned long long>1) << v11
        v13 = v0 & v12
        v14 = v13 == (<unsigned long long>0)
        v15 = v14 != 1
        if v15:
            v16 = v2 == (<signed char>0)
            if v16:
                v27, v28, v29, v30 = v10, v4, v5, v6
            else:
                v17 = v2 == (<signed char>1)
                if v17:
                    v27, v28, v29, v30 = v3, v10, v5, v6
                else:
                    v18 = v2 == (<signed char>2)
                    if v18:
                        v27, v28, v29, v30 = v3, v4, v10, v6
                    else:
                        v27, v28, v29, v30 = v3, v4, v5, v10
            v31 = v2 + (<signed char>1)
            v32, v33, v34, v35, v36 = v27, v28, v29, v30, v31
        else:
            v32, v33, v34, v35, v36 = v3, v4, v5, v6, v2
        v37 = v7 + (<signed char>1)
        return method23(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple6(v3, v4, v5, v6)
cdef Tuple4 method26(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef signed char v9
    cdef signed char v10
    cdef signed long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef unsigned char v46
    cdef bint v16
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v40
    cdef bint v47
    cdef signed char v48
    v9 = v1 * (<signed char>13)
    v10 = v9 + v2
    v11 = <signed long>v10
    v12 = (<unsigned long long>1) << v11
    v13 = v0 & v12
    v14 = v13 == (<unsigned long long>0)
    v15 = v14 != 1
    if v15:
        v16 = v8 == (<unsigned char>0)
        if v16:
            v35, v36, v37, v38, v39 = v10, v4, v5, v6, v7
        else:
            v17 = v8 == (<unsigned char>1)
            if v17:
                v35, v36, v37, v38, v39 = v3, v10, v5, v6, v7
            else:
                v18 = v8 == (<unsigned char>2)
                if v18:
                    v35, v36, v37, v38, v39 = v3, v4, v10, v6, v7
                else:
                    v19 = v8 == (<unsigned char>3)
                    if v19:
                        v35, v36, v37, v38, v39 = v3, v4, v5, v10, v7
                    else:
                        v35, v36, v37, v38, v39 = v3, v4, v5, v6, v10
        v40 = v8 + (<unsigned char>1)
        v41, v42, v43, v44, v45, v46 = v35, v36, v37, v38, v39, v40
    else:
        v41, v42, v43, v44, v45, v46 = v3, v4, v5, v6, v7, v8
    v47 = v46 == (<unsigned char>5)
    if v47:
        return Tuple4(v41, v42, v43, v44, v45, (<signed char>6))
    else:
        v48 = v2 - (<signed char>1)
        return method26(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple5 method32(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned char v5, signed char v6, signed char v7, signed char v8, signed char v9, signed char v10):
    cdef bint v11
    cdef signed char v12
    cdef signed char v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef bint v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v43
    cdef bint v44
    cdef signed char v45
    cdef signed char v56
    cdef signed char v67
    v11 = v4 < (<signed char>4)
    if v11:
        v12 = v4 * (<signed char>13)
        v13 = v12 + v3
        v14 = <signed long>v13
        v15 = (<unsigned long long>1) << v14
        v16 = v0 & v15
        v17 = v16 == (<unsigned long long>0)
        v18 = v17 != 1
        if v18:
            v19 = v5 == (<unsigned char>0)
            if v19:
                v38, v39, v40, v41, v42 = v13, v7, v8, v9, v10
            else:
                v20 = v5 == (<unsigned char>1)
                if v20:
                    v38, v39, v40, v41, v42 = v6, v13, v8, v9, v10
                else:
                    v21 = v5 == (<unsigned char>2)
                    if v21:
                        v38, v39, v40, v41, v42 = v6, v7, v13, v9, v10
                    else:
                        v22 = v5 == (<unsigned char>3)
                        if v22:
                            v38, v39, v40, v41, v42 = v6, v7, v8, v13, v10
                        else:
                            v38, v39, v40, v41, v42 = v6, v7, v8, v9, v13
            v43 = v5 + (<unsigned char>1)
            v44 = v43 < (<unsigned char>5)
            if v44:
                v45 = v4 + (<signed char>1)
                return method32(v0, v1, v2, v3, v45, v43, v38, v39, v40, v41, v42)
            else:
                return Tuple5(v38, v39, v40, v41, v42)
        else:
            v56 = v4 + (<signed char>1)
            return method32(v0, v1, v2, v3, v56, v5, v6, v7, v8, v9, v10)
    else:
        v67 = v3 - (<signed char>1)
        return method31(v0, v1, v2, v67, v6, v7, v8, v9, v10, v5)
cdef Tuple5 method31(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
    cdef bint v10
    cdef bint v12
    cdef signed char v13
    cdef bint v19
    cdef signed char v20
    v10 = v3 == v1
    if v10:
        v12 = 1
    else:
        v12 = v3 == v2
    if v12:
        v13 = v3 - (<signed char>1)
        return method31(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method32(v0, v1, v2, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple5(v4, v5, v6, v7, v8)
cdef Tuple5 method35(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef signed long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef bint v18
    cdef bint v19
    cdef bint v20
    cdef unsigned char v41
    cdef bint v42
    cdef signed char v43
    cdef signed char v54
    cdef signed char v65
    v9 = v2 < (<signed char>4)
    if v9:
        v10 = v2 * (<signed char>13)
        v11 = v10 + v1
        v12 = <signed long>v11
        v13 = (<unsigned long long>1) << v12
        v14 = v0 & v13
        v15 = v14 == (<unsigned long long>0)
        v16 = v15 != 1
        if v16:
            v17 = v3 == (<unsigned char>0)
            if v17:
                v36, v37, v38, v39, v40 = v11, v5, v6, v7, v8
            else:
                v18 = v3 == (<unsigned char>1)
                if v18:
                    v36, v37, v38, v39, v40 = v4, v11, v6, v7, v8
                else:
                    v19 = v3 == (<unsigned char>2)
                    if v19:
                        v36, v37, v38, v39, v40 = v4, v5, v11, v7, v8
                    else:
                        v20 = v3 == (<unsigned char>3)
                        if v20:
                            v36, v37, v38, v39, v40 = v4, v5, v6, v11, v8
                        else:
                            v36, v37, v38, v39, v40 = v4, v5, v6, v7, v11
            v41 = v3 + (<unsigned char>1)
            v42 = v41 < (<unsigned char>5)
            if v42:
                v43 = v2 + (<signed char>1)
                return method35(v0, v1, v43, v41, v36, v37, v38, v39, v40)
            else:
                return Tuple5(v36, v37, v38, v39, v40)
        else:
            v54 = v2 + (<signed char>1)
            return method35(v0, v1, v54, v3, v4, v5, v6, v7, v8)
    else:
        v65 = v1 - (<signed char>1)
        return method34(v0, v65, v4, v5, v6, v7, v8, v3)
cdef Tuple5 method34(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method35(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple5(v2, v3, v4, v5, v6)
cdef Tuple4 method33(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple6 tmp33
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple5 tmp34
    cdef signed char v56
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef signed char v72
    cdef signed char v73
    cdef signed char v74
    cdef unsigned char v75
    cdef signed char v76
    cdef signed char v77
    cdef signed char v78
    cdef signed char v79
    cdef signed char v80
    cdef Tuple5 tmp35
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>2)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp33 = method23(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp33.v0, tmp33.v1, tmp33.v2, tmp33.v3
            del tmp33
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp34 = method20(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp34.v0, tmp34.v1, tmp34.v2, tmp34.v3, tmp34.v4
            del tmp34
            return Tuple4(v40, v41, v51, v52, v53, (<signed char>2))
        else:
            v56 = v1 - (<signed char>1)
            return method33(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp35 = method34(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp35.v0, tmp35.v1, tmp35.v2, tmp35.v3, tmp35.v4
        del tmp35
        return Tuple4(v76, v77, v78, v79, v80, (<signed char>1))
cdef Tuple4 method30(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef bint v5
    cdef signed char v6
    cdef bint v13
    cdef signed long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef bint v17
    cdef bint v18
    cdef unsigned char v19
    cdef signed char v20
    cdef signed long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef bint v24
    cdef bint v25
    cdef unsigned char v26
    cdef unsigned char v27
    cdef signed char v28
    cdef signed long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef bint v32
    cdef bint v33
    cdef unsigned char v34
    cdef unsigned char v35
    cdef signed char v36
    cdef signed long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef unsigned char v42
    cdef unsigned char v43
    cdef bint v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef Tuple6 tmp31
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef signed char v58
    cdef signed char v59
    cdef signed char v60
    cdef unsigned char v61
    cdef signed char v62
    cdef signed char v63
    cdef signed char v64
    cdef signed char v65
    cdef signed char v66
    cdef Tuple5 tmp32
    cdef signed char v67
    cdef signed char v80
    v5 = v1 == v4
    if v5:
        v6 = v4 - (<signed char>1)
        return method30(v0, v1, v2, v3, v6)
    else:
        v13 = (<signed char>0) <= v4
        if v13:
            v14 = <signed long>v4
            v15 = (<unsigned long long>1) << v14
            v16 = v0 & v15
            v17 = v16 == (<unsigned long long>0)
            v18 = v17 != 1
            if v18:
                v19 = (<unsigned char>1)
            else:
                v19 = (<unsigned char>0)
            v20 = (<signed char>13) + v4
            v21 = <signed long>v20
            v22 = (<unsigned long long>1) << v21
            v23 = v0 & v22
            v24 = v23 == (<unsigned long long>0)
            v25 = v24 != 1
            if v25:
                v26 = (<unsigned char>1)
            else:
                v26 = (<unsigned char>0)
            v27 = v19 + v26
            v28 = (<signed char>26) + v4
            v29 = <signed long>v28
            v30 = (<unsigned long long>1) << v29
            v31 = v0 & v30
            v32 = v31 == (<unsigned long long>0)
            v33 = v32 != 1
            if v33:
                v34 = (<unsigned char>1)
            else:
                v34 = (<unsigned char>0)
            v35 = v27 + v34
            v36 = (<signed char>39) + v4
            v37 = <signed long>v36
            v38 = (<unsigned long long>1) << v37
            v39 = v0 & v38
            v40 = v39 == (<unsigned long long>0)
            v41 = v40 != 1
            if v41:
                v42 = (<unsigned char>1)
            else:
                v42 = (<unsigned char>0)
            v43 = v35 + v42
            v44 = v43 == (<unsigned char>2)
            if v44:
                v45 = (<signed char>-1)
                v46 = (<signed char>-1)
                v47 = (<signed char>-1)
                v48 = (<signed char>-1)
                v49 = (<signed char>0)
                v50 = (<signed char>0)
                tmp31 = method23(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp31.v0, tmp31.v1, tmp31.v2, tmp31.v3
                del tmp31
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp32 = method31(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3, tmp32.v4
                del tmp32
                return Tuple4(v3, v2, v51, v52, v62, (<signed char>3))
            else:
                v67 = v4 - (<signed char>1)
                return method30(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method33(v0, v80)
cdef Tuple4 method29(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple6 tmp30
    cdef signed char v44
    cdef signed char v51
    cdef signed char v64
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>2)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp30 = method23(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3
            del tmp30
            v44 = (<signed char>12)
            return method30(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method29(v0, v51)
    else:
        v64 = (<signed char>12)
        return method33(v0, v64)
cdef Tuple4 method28(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple6 tmp28
    cdef signed char v44
    cdef signed char v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef unsigned char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple5 tmp29
    cdef signed char v56
    cdef signed char v69
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>3)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp28 = method23(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3
            del tmp28
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp29 = method20(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3, tmp29.v4
            del tmp29
            return Tuple4(v40, v41, v42, v51, v52, (<signed char>4))
        else:
            v56 = v1 - (<signed char>1)
            return method28(v0, v56)
    else:
        v69 = (<signed char>12)
        return method29(v0, v69)
cdef Tuple4 method27(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef bint v4
    cdef signed char v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v11
    cdef bint v32
    cdef signed char v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef bint v16
    cdef bint v17
    cdef signed char v18
    cdef signed long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    cdef bint v23
    cdef signed char v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef bint v28
    cdef bint v155
    cdef signed char v33
    cdef bint v34
    cdef signed char v36
    cdef signed long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    cdef bint v41
    cdef bint v62
    cdef signed char v42
    cdef signed long v43
    cdef unsigned long long v44
    cdef unsigned long long v45
    cdef bint v46
    cdef bint v47
    cdef signed char v48
    cdef signed long v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef bint v53
    cdef signed char v54
    cdef signed long v55
    cdef unsigned long long v56
    cdef unsigned long long v57
    cdef bint v58
    cdef signed char v63
    cdef bint v64
    cdef signed char v66
    cdef signed long v67
    cdef unsigned long long v68
    cdef unsigned long long v69
    cdef bint v70
    cdef bint v71
    cdef bint v92
    cdef signed char v72
    cdef signed long v73
    cdef unsigned long long v74
    cdef unsigned long long v75
    cdef bint v76
    cdef bint v77
    cdef signed char v78
    cdef signed long v79
    cdef unsigned long long v80
    cdef unsigned long long v81
    cdef bint v82
    cdef bint v83
    cdef signed char v84
    cdef signed long v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef bint v88
    cdef signed char v93
    cdef bint v94
    cdef signed char v96
    cdef signed long v97
    cdef unsigned long long v98
    cdef unsigned long long v99
    cdef bint v100
    cdef bint v101
    cdef bint v122
    cdef signed char v102
    cdef signed long v103
    cdef unsigned long long v104
    cdef unsigned long long v105
    cdef bint v106
    cdef bint v107
    cdef signed char v108
    cdef signed long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef bint v112
    cdef bint v113
    cdef signed char v114
    cdef signed long v115
    cdef unsigned long long v116
    cdef unsigned long long v117
    cdef bint v118
    cdef bint v123
    cdef signed char v125
    cdef signed long v126
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef bint v129
    cdef bint v130
    cdef signed char v131
    cdef signed long v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef bint v135
    cdef bint v136
    cdef signed char v137
    cdef signed long v138
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef bint v141
    cdef bint v142
    cdef signed char v143
    cdef signed long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef bint v147
    cdef signed char v157
    cdef signed char v158
    cdef signed char v159
    cdef signed char v160
    cdef signed char v161
    cdef signed char v162
    cdef signed char v163
    cdef signed char v164
    cdef signed char v165
    cdef signed char v166
    cdef signed char v167
    cdef Tuple6 tmp23
    cdef signed char v168
    cdef bint v169
    cdef signed char v171
    cdef signed char v172
    cdef signed char v173
    cdef signed char v174
    cdef signed char v175
    cdef signed char v176
    cdef signed char v177
    cdef signed char v178
    cdef signed char v179
    cdef signed char v180
    cdef signed char v181
    cdef Tuple6 tmp24
    cdef signed char v182
    cdef bint v183
    cdef signed char v185
    cdef signed char v186
    cdef signed char v187
    cdef signed char v188
    cdef signed char v189
    cdef signed char v190
    cdef signed char v191
    cdef signed char v192
    cdef signed char v193
    cdef signed char v194
    cdef signed char v195
    cdef Tuple6 tmp25
    cdef signed char v196
    cdef bint v197
    cdef signed char v199
    cdef signed char v200
    cdef signed char v201
    cdef signed char v202
    cdef signed char v203
    cdef signed char v204
    cdef signed char v205
    cdef signed char v206
    cdef signed char v207
    cdef signed char v208
    cdef signed char v209
    cdef Tuple6 tmp26
    cdef bint v210
    cdef signed char v212
    cdef signed char v213
    cdef signed char v214
    cdef signed char v215
    cdef signed char v216
    cdef signed char v217
    cdef signed char v218
    cdef signed char v219
    cdef signed char v220
    cdef signed char v221
    cdef signed char v222
    cdef Tuple6 tmp27
    cdef signed char v223
    cdef signed char v236
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = v1 + (<signed char>4)
        v4 = v3 < (<signed char>0)
        if v4:
            v6 = v3 + (<signed char>13)
        else:
            v6 = v3
        v7 = <signed long>v6
        v8 = (<unsigned long long>1) << v7
        v9 = v0 & v8
        v10 = v9 == (<unsigned long long>0)
        v11 = v10 != 1
        if v11:
            v32 = 1
        else:
            v12 = (<signed char>13) + v6
            v13 = <signed long>v12
            v14 = (<unsigned long long>1) << v13
            v15 = v0 & v14
            v16 = v15 == (<unsigned long long>0)
            v17 = v16 != 1
            if v17:
                v32 = 1
            else:
                v18 = (<signed char>26) + v6
                v19 = <signed long>v18
                v20 = (<unsigned long long>1) << v19
                v21 = v0 & v20
                v22 = v21 == (<unsigned long long>0)
                v23 = v22 != 1
                if v23:
                    v32 = 1
                else:
                    v24 = (<signed char>39) + v6
                    v25 = <signed long>v24
                    v26 = (<unsigned long long>1) << v25
                    v27 = v0 & v26
                    v28 = v27 == (<unsigned long long>0)
                    v32 = v28 != 1
        if v32:
            v33 = v1 + (<signed char>3)
            v34 = v33 < (<signed char>0)
            if v34:
                v36 = v33 + (<signed char>13)
            else:
                v36 = v33
            v37 = <signed long>v36
            v38 = (<unsigned long long>1) << v37
            v39 = v0 & v38
            v40 = v39 == (<unsigned long long>0)
            v41 = v40 != 1
            if v41:
                v62 = 1
            else:
                v42 = (<signed char>13) + v36
                v43 = <signed long>v42
                v44 = (<unsigned long long>1) << v43
                v45 = v0 & v44
                v46 = v45 == (<unsigned long long>0)
                v47 = v46 != 1
                if v47:
                    v62 = 1
                else:
                    v48 = (<signed char>26) + v36
                    v49 = <signed long>v48
                    v50 = (<unsigned long long>1) << v49
                    v51 = v0 & v50
                    v52 = v51 == (<unsigned long long>0)
                    v53 = v52 != 1
                    if v53:
                        v62 = 1
                    else:
                        v54 = (<signed char>39) + v36
                        v55 = <signed long>v54
                        v56 = (<unsigned long long>1) << v55
                        v57 = v0 & v56
                        v58 = v57 == (<unsigned long long>0)
                        v62 = v58 != 1
            if v62:
                v63 = v1 + (<signed char>2)
                v64 = v63 < (<signed char>0)
                if v64:
                    v66 = v63 + (<signed char>13)
                else:
                    v66 = v63
                v67 = <signed long>v66
                v68 = (<unsigned long long>1) << v67
                v69 = v0 & v68
                v70 = v69 == (<unsigned long long>0)
                v71 = v70 != 1
                if v71:
                    v92 = 1
                else:
                    v72 = (<signed char>13) + v66
                    v73 = <signed long>v72
                    v74 = (<unsigned long long>1) << v73
                    v75 = v0 & v74
                    v76 = v75 == (<unsigned long long>0)
                    v77 = v76 != 1
                    if v77:
                        v92 = 1
                    else:
                        v78 = (<signed char>26) + v66
                        v79 = <signed long>v78
                        v80 = (<unsigned long long>1) << v79
                        v81 = v0 & v80
                        v82 = v81 == (<unsigned long long>0)
                        v83 = v82 != 1
                        if v83:
                            v92 = 1
                        else:
                            v84 = (<signed char>39) + v66
                            v85 = <signed long>v84
                            v86 = (<unsigned long long>1) << v85
                            v87 = v0 & v86
                            v88 = v87 == (<unsigned long long>0)
                            v92 = v88 != 1
                if v92:
                    v93 = v1 + (<signed char>1)
                    v94 = v93 < (<signed char>0)
                    if v94:
                        v96 = v93 + (<signed char>13)
                    else:
                        v96 = v93
                    v97 = <signed long>v96
                    v98 = (<unsigned long long>1) << v97
                    v99 = v0 & v98
                    v100 = v99 == (<unsigned long long>0)
                    v101 = v100 != 1
                    if v101:
                        v122 = 1
                    else:
                        v102 = (<signed char>13) + v96
                        v103 = <signed long>v102
                        v104 = (<unsigned long long>1) << v103
                        v105 = v0 & v104
                        v106 = v105 == (<unsigned long long>0)
                        v107 = v106 != 1
                        if v107:
                            v122 = 1
                        else:
                            v108 = (<signed char>26) + v96
                            v109 = <signed long>v108
                            v110 = (<unsigned long long>1) << v109
                            v111 = v0 & v110
                            v112 = v111 == (<unsigned long long>0)
                            v113 = v112 != 1
                            if v113:
                                v122 = 1
                            else:
                                v114 = (<signed char>39) + v96
                                v115 = <signed long>v114
                                v116 = (<unsigned long long>1) << v115
                                v117 = v0 & v116
                                v118 = v117 == (<unsigned long long>0)
                                v122 = v118 != 1
                    if v122:
                        v123 = v1 < (<signed char>0)
                        if v123:
                            v125 = v1 + (<signed char>13)
                        else:
                            v125 = v1
                        v126 = <signed long>v125
                        v127 = (<unsigned long long>1) << v126
                        v128 = v0 & v127
                        v129 = v128 == (<unsigned long long>0)
                        v130 = v129 != 1
                        if v130:
                            v155 = 1
                        else:
                            v131 = (<signed char>13) + v125
                            v132 = <signed long>v131
                            v133 = (<unsigned long long>1) << v132
                            v134 = v0 & v133
                            v135 = v134 == (<unsigned long long>0)
                            v136 = v135 != 1
                            if v136:
                                v155 = 1
                            else:
                                v137 = (<signed char>26) + v125
                                v138 = <signed long>v137
                                v139 = (<unsigned long long>1) << v138
                                v140 = v0 & v139
                                v141 = v140 == (<unsigned long long>0)
                                v142 = v141 != 1
                                if v142:
                                    v155 = 1
                                else:
                                    v143 = (<signed char>39) + v125
                                    v144 = <signed long>v143
                                    v145 = (<unsigned long long>1) << v144
                                    v146 = v0 & v145
                                    v147 = v146 == (<unsigned long long>0)
                                    v155 = v147 != 1
                    else:
                        v155 = 0
                else:
                    v155 = 0
            else:
                v155 = 0
        else:
            v155 = 0
        if v155:
            if v4:
                v157 = v3 + (<signed char>13)
            else:
                v157 = v3
            v158 = (<signed char>-1)
            v159 = (<signed char>-1)
            v160 = (<signed char>-1)
            v161 = (<signed char>-1)
            v162 = (<signed char>0)
            v163 = (<signed char>0)
            tmp23 = method23(v0, v157, v162, v158, v159, v160, v161, v163)
            v164, v165, v166, v167 = tmp23.v0, tmp23.v1, tmp23.v2, tmp23.v3
            del tmp23
            v168 = v1 + (<signed char>3)
            v169 = v168 < (<signed char>0)
            if v169:
                v171 = v168 + (<signed char>13)
            else:
                v171 = v168
            v172 = (<signed char>-1)
            v173 = (<signed char>-1)
            v174 = (<signed char>-1)
            v175 = (<signed char>-1)
            v176 = (<signed char>0)
            v177 = (<signed char>0)
            tmp24 = method23(v0, v171, v176, v172, v173, v174, v175, v177)
            v178, v179, v180, v181 = tmp24.v0, tmp24.v1, tmp24.v2, tmp24.v3
            del tmp24
            v182 = v1 + (<signed char>2)
            v183 = v182 < (<signed char>0)
            if v183:
                v185 = v182 + (<signed char>13)
            else:
                v185 = v182
            v186 = (<signed char>-1)
            v187 = (<signed char>-1)
            v188 = (<signed char>-1)
            v189 = (<signed char>-1)
            v190 = (<signed char>0)
            v191 = (<signed char>0)
            tmp25 = method23(v0, v185, v190, v186, v187, v188, v189, v191)
            v192, v193, v194, v195 = tmp25.v0, tmp25.v1, tmp25.v2, tmp25.v3
            del tmp25
            v196 = v1 + (<signed char>1)
            v197 = v196 < (<signed char>0)
            if v197:
                v199 = v196 + (<signed char>13)
            else:
                v199 = v196
            v200 = (<signed char>-1)
            v201 = (<signed char>-1)
            v202 = (<signed char>-1)
            v203 = (<signed char>-1)
            v204 = (<signed char>0)
            v205 = (<signed char>0)
            tmp26 = method23(v0, v199, v204, v200, v201, v202, v203, v205)
            v206, v207, v208, v209 = tmp26.v0, tmp26.v1, tmp26.v2, tmp26.v3
            del tmp26
            v210 = v1 < (<signed char>0)
            if v210:
                v212 = v1 + (<signed char>13)
            else:
                v212 = v1
            v213 = (<signed char>-1)
            v214 = (<signed char>-1)
            v215 = (<signed char>-1)
            v216 = (<signed char>-1)
            v217 = (<signed char>0)
            v218 = (<signed char>0)
            tmp27 = method23(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3
            del tmp27
            return Tuple4(v164, v178, v192, v206, v219, (<signed char>5))
        else:
            v223 = v1 - (<signed char>1)
            return method27(v0, v223)
    else:
        v236 = (<signed char>12)
        return method28(v0, v236)
cdef Tuple4 method25(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
    cdef bint v6
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v11
    cdef unsigned char v12
    cdef unsigned char v13
    cdef signed char v14
    cdef signed long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v20
    cdef unsigned char v21
    cdef signed char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef bint v26
    cdef bint v27
    cdef unsigned char v28
    cdef unsigned char v29
    cdef signed char v30
    cdef signed long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef bint v34
    cdef bint v35
    cdef unsigned char v36
    cdef unsigned char v37
    cdef bint v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef unsigned char v46
    cdef bint v53
    cdef signed char v54
    cdef signed char v55
    cdef signed char v56
    cdef signed char v57
    cdef signed char v58
    cdef signed char v59
    cdef signed char v60
    cdef unsigned char v61
    cdef bint v68
    cdef signed char v69
    cdef signed char v70
    cdef signed char v71
    cdef signed char v72
    cdef signed char v73
    cdef signed char v74
    cdef signed char v75
    cdef unsigned char v76
    cdef bint v83
    cdef signed char v84
    cdef signed char v85
    cdef signed char v86
    cdef signed char v87
    cdef signed char v88
    cdef signed char v89
    cdef signed char v90
    cdef unsigned char v91
    cdef signed char v98
    cdef signed char v129
    v6 = (<signed char>0) <= v1
    if v6:
        v7 = <signed long>v1
        v8 = (<unsigned long long>1) << v7
        v9 = v0 & v8
        v10 = v9 == (<unsigned long long>0)
        v11 = v10 != 1
        if v11:
            v12 = (<unsigned char>1)
        else:
            v12 = (<unsigned char>0)
        v13 = v5 + v12
        v14 = (<signed char>13) + v1
        v15 = <signed long>v14
        v16 = (<unsigned long long>1) << v15
        v17 = v0 & v16
        v18 = v17 == (<unsigned long long>0)
        v19 = v18 != 1
        if v19:
            v20 = (<unsigned char>1)
        else:
            v20 = (<unsigned char>0)
        v21 = v4 + v20
        v22 = (<signed char>26) + v1
        v23 = <signed long>v22
        v24 = (<unsigned long long>1) << v23
        v25 = v0 & v24
        v26 = v25 == (<unsigned long long>0)
        v27 = v26 != 1
        if v27:
            v28 = (<unsigned char>1)
        else:
            v28 = (<unsigned char>0)
        v29 = v3 + v28
        v30 = (<signed char>39) + v1
        v31 = <signed long>v30
        v32 = (<unsigned long long>1) << v31
        v33 = v0 & v32
        v34 = v33 == (<unsigned long long>0)
        v35 = v34 != 1
        if v35:
            v36 = (<unsigned char>1)
        else:
            v36 = (<unsigned char>0)
        v37 = v2 + v36
        v38 = (<unsigned char>5) == v13
        if v38:
            v39 = (<signed char>0)
            v40 = (<signed char>12)
            v41 = (<signed char>-1)
            v42 = (<signed char>-1)
            v43 = (<signed char>-1)
            v44 = (<signed char>-1)
            v45 = (<signed char>-1)
            v46 = (<unsigned char>0)
            return method26(v0, v39, v40, v41, v42, v43, v44, v45, v46)
        else:
            v53 = (<unsigned char>5) == v21
            if v53:
                v54 = (<signed char>1)
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                return method26(v0, v54, v55, v56, v57, v58, v59, v60, v61)
            else:
                v68 = (<unsigned char>5) == v29
                if v68:
                    v69 = (<signed char>2)
                    v70 = (<signed char>12)
                    v71 = (<signed char>-1)
                    v72 = (<signed char>-1)
                    v73 = (<signed char>-1)
                    v74 = (<signed char>-1)
                    v75 = (<signed char>-1)
                    v76 = (<unsigned char>0)
                    return method26(v0, v69, v70, v71, v72, v73, v74, v75, v76)
                else:
                    v83 = (<unsigned char>5) == v37
                    if v83:
                        v84 = (<signed char>3)
                        v85 = (<signed char>12)
                        v86 = (<signed char>-1)
                        v87 = (<signed char>-1)
                        v88 = (<signed char>-1)
                        v89 = (<signed char>-1)
                        v90 = (<signed char>-1)
                        v91 = (<unsigned char>0)
                        return method26(v0, v84, v85, v86, v87, v88, v89, v90, v91)
                    else:
                        v98 = v1 - (<signed char>1)
                        return method25(v0, v98, v37, v29, v21, v13)
    else:
        v129 = (<signed char>8)
        return method27(v0, v129)
cdef Tuple4 method24(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
    cdef bint v6
    cdef signed char v7
    cdef bint v14
    cdef signed long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef bint v18
    cdef bint v19
    cdef unsigned char v20
    cdef signed char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    cdef bint v26
    cdef unsigned char v27
    cdef unsigned char v28
    cdef signed char v29
    cdef signed long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef bint v33
    cdef bint v34
    cdef unsigned char v35
    cdef unsigned char v36
    cdef signed char v37
    cdef signed long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef bint v41
    cdef bint v42
    cdef unsigned char v43
    cdef unsigned char v44
    cdef bint v45
    cdef signed char v46
    cdef signed char v47
    cdef signed char v48
    cdef signed char v49
    cdef signed char v50
    cdef signed char v51
    cdef signed char v52
    cdef signed char v53
    cdef signed char v54
    cdef signed char v55
    cdef Tuple6 tmp22
    cdef signed char v56
    cdef signed char v69
    cdef unsigned char v70
    cdef unsigned char v71
    cdef unsigned char v72
    cdef unsigned char v73
    v6 = v1 == v5
    if v6:
        v7 = v5 - (<signed char>1)
        return method24(v0, v1, v2, v3, v4, v7)
    else:
        v14 = (<signed char>0) <= v5
        if v14:
            v15 = <signed long>v5
            v16 = (<unsigned long long>1) << v15
            v17 = v0 & v16
            v18 = v17 == (<unsigned long long>0)
            v19 = v18 != 1
            if v19:
                v20 = (<unsigned char>1)
            else:
                v20 = (<unsigned char>0)
            v21 = (<signed char>13) + v5
            v22 = <signed long>v21
            v23 = (<unsigned long long>1) << v22
            v24 = v0 & v23
            v25 = v24 == (<unsigned long long>0)
            v26 = v25 != 1
            if v26:
                v27 = (<unsigned char>1)
            else:
                v27 = (<unsigned char>0)
            v28 = v20 + v27
            v29 = (<signed char>26) + v5
            v30 = <signed long>v29
            v31 = (<unsigned long long>1) << v30
            v32 = v0 & v31
            v33 = v32 == (<unsigned long long>0)
            v34 = v33 != 1
            if v34:
                v35 = (<unsigned char>1)
            else:
                v35 = (<unsigned char>0)
            v36 = v28 + v35
            v37 = (<signed char>39) + v5
            v38 = <signed long>v37
            v39 = (<unsigned long long>1) << v38
            v40 = v0 & v39
            v41 = v40 == (<unsigned long long>0)
            v42 = v41 != 1
            if v42:
                v43 = (<unsigned char>1)
            else:
                v43 = (<unsigned char>0)
            v44 = v36 + v43
            v45 = (<unsigned char>2) <= v44
            if v45:
                v46 = (<signed char>-1)
                v47 = (<signed char>-1)
                v48 = (<signed char>-1)
                v49 = (<signed char>-1)
                v50 = (<signed char>0)
                v51 = (<signed char>0)
                tmp22 = method23(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3
                del tmp22
                return Tuple4(v4, v3, v2, v52, v53, (<signed char>7))
            else:
                v56 = v5 - (<signed char>1)
                return method24(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method25(v0, v69, v73, v72, v71, v70)
cdef Tuple4 method22(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef Tuple6 tmp21
    cdef signed char v44
    cdef signed char v51
    cdef signed char v64
    cdef unsigned char v65
    cdef unsigned char v66
    cdef unsigned char v67
    cdef unsigned char v68
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>3)
        if v33:
            v34 = (<signed char>-1)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>0)
            v39 = (<signed char>0)
            tmp21 = method23(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3
            del tmp21
            v44 = (<signed char>12)
            return method24(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method22(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method25(v0, v64, v68, v67, v66, v65)
cdef Tuple4 method19(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned char v8
    cdef signed char v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v14
    cdef unsigned char v15
    cdef unsigned char v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef unsigned char v23
    cdef unsigned char v24
    cdef signed char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    cdef bint v30
    cdef unsigned char v31
    cdef unsigned char v32
    cdef bint v33
    cdef signed char v34
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef unsigned char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef Tuple5 tmp20
    cdef signed char v46
    cdef signed char v59
    v2 = (<signed char>0) <= v1
    if v2:
        v3 = <signed long>v1
        v4 = (<unsigned long long>1) << v3
        v5 = v0 & v4
        v6 = v5 == (<unsigned long long>0)
        v7 = v6 != 1
        if v7:
            v8 = (<unsigned char>1)
        else:
            v8 = (<unsigned char>0)
        v9 = (<signed char>13) + v1
        v10 = <signed long>v9
        v11 = (<unsigned long long>1) << v10
        v12 = v0 & v11
        v13 = v12 == (<unsigned long long>0)
        v14 = v13 != 1
        if v14:
            v15 = (<unsigned char>1)
        else:
            v15 = (<unsigned char>0)
        v16 = v8 + v15
        v17 = (<signed char>26) + v1
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v0 & v19
        v21 = v20 == (<unsigned long long>0)
        v22 = v21 != 1
        if v22:
            v23 = (<unsigned char>1)
        else:
            v23 = (<unsigned char>0)
        v24 = v16 + v23
        v25 = (<signed char>39) + v1
        v26 = <signed long>v25
        v27 = (<unsigned long long>1) << v26
        v28 = v0 & v27
        v29 = v28 == (<unsigned long long>0)
        v30 = v29 != 1
        if v30:
            v31 = (<unsigned char>1)
        else:
            v31 = (<unsigned char>0)
        v32 = v24 + v31
        v33 = v32 == (<unsigned char>4)
        if v33:
            v34 = (<signed char>12)
            v35 = (<signed char>-1)
            v36 = (<signed char>-1)
            v37 = (<signed char>-1)
            v38 = (<signed char>-1)
            v39 = (<signed char>-1)
            v40 = (<unsigned char>0)
            tmp20 = method20(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4
            del tmp20
            return Tuple4(v1, v9, v17, v25, v41, (<signed char>8))
        else:
            v46 = v1 - (<signed char>1)
            return method19(v0, v46)
    else:
        v59 = (<signed char>12)
        return method22(v0, v59)
cdef Tuple4 method17(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method18(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method19(v0, v10)
cdef Tuple4 method16(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6):
    cdef signed long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef signed long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef signed long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef signed long v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef signed long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef signed char v28
    v7 = <signed long>v6
    v8 = (<unsigned long long>1) << v7
    v9 = (<unsigned long long>0) | v8
    v10 = <signed long>v5
    v11 = (<unsigned long long>1) << v10
    v12 = v9 | v11
    v13 = <signed long>v4
    v14 = (<unsigned long long>1) << v13
    v15 = v12 | v14
    v16 = <signed long>v3
    v17 = (<unsigned long long>1) << v16
    v18 = v15 | v17
    v19 = <signed long>v2
    v20 = (<unsigned long long>1) << v19
    v21 = v18 | v20
    v22 = <signed long>v1
    v23 = (<unsigned long long>1) << v22
    v24 = v21 | v23
    v25 = <signed long>v0
    v26 = (<unsigned long long>1) << v25
    v27 = v24 | v26
    v28 = (<signed char>8)
    return method17(v27, v28)
cdef object method15(signed short v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13):
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    cdef signed char v19
    cdef signed char v20
    cdef unsigned char v21
    cdef signed short v22
    cdef numpy.ndarray[signed char,ndim=1] v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef Tuple4 tmp36
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef Tuple4 tmp37
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef bint v46
    cdef signed long v49
    cdef bint v47
    cdef bint v50
    cdef signed long v79
    cdef bint v51
    cdef signed long v54
    cdef bint v52
    cdef bint v55
    cdef bint v56
    cdef signed long v59
    cdef bint v57
    cdef bint v60
    cdef bint v61
    cdef signed long v64
    cdef bint v62
    cdef bint v65
    cdef bint v66
    cdef signed long v69
    cdef bint v67
    cdef bint v70
    cdef bint v71
    cdef bint v72
    cdef bint v80
    cdef float v81
    cdef bint v83
    cdef float v84
    cdef signed short v86
    cdef float v87
    v14 = v12 == (<unsigned char>0)
    if v14:
        v15, v16, v17, v18, v19, v20, v21, v22 = v10, v11, v12, v13, v6, v7, v8, v9
    else:
        v15, v16, v17, v18, v19, v20, v21, v22 = v6, v7, v8, v9, v10, v11, v12, v13
    v23 = numpy.empty(5,dtype=numpy.int8)
    v23[0] = v1; v23[1] = v2; v23[2] = v3; v23[3] = v4; v23[4] = v5
    tmp36 = method16(v5, v4, v3, v2, v1, v16, v15)
    v24, v25, v26, v27, v28, v29 = tmp36.v0, tmp36.v1, tmp36.v2, tmp36.v3, tmp36.v4, tmp36.v5
    del tmp36
    tmp37 = method16(v5, v4, v3, v2, v1, v20, v19)
    v30, v31, v32, v33, v34, v35 = tmp37.v0, tmp37.v1, tmp37.v2, tmp37.v3, tmp37.v4, tmp37.v5
    del tmp37
    v36 = v24 % (<signed char>13)
    v37 = v25 % (<signed char>13)
    v38 = v26 % (<signed char>13)
    v39 = v27 % (<signed char>13)
    v40 = v28 % (<signed char>13)
    v41 = v30 % (<signed char>13)
    v42 = v31 % (<signed char>13)
    v43 = v32 % (<signed char>13)
    v44 = v33 % (<signed char>13)
    v45 = v34 % (<signed char>13)
    v46 = v29 < v35
    if v46:
        v49 = (<signed long>-1)
    else:
        v47 = v29 > v35
        if v47:
            v49 = (<signed long>1)
        else:
            v49 = (<signed long>0)
    v50 = v49 == (<signed long>0)
    if v50:
        v51 = v36 < v41
        if v51:
            v54 = (<signed long>-1)
        else:
            v52 = v36 > v41
            if v52:
                v54 = (<signed long>1)
            else:
                v54 = (<signed long>0)
        v55 = v54 == (<signed long>0)
        if v55:
            v56 = v37 < v42
            if v56:
                v59 = (<signed long>-1)
            else:
                v57 = v37 > v42
                if v57:
                    v59 = (<signed long>1)
                else:
                    v59 = (<signed long>0)
            v60 = v59 == (<signed long>0)
            if v60:
                v61 = v38 < v43
                if v61:
                    v64 = (<signed long>-1)
                else:
                    v62 = v38 > v43
                    if v62:
                        v64 = (<signed long>1)
                    else:
                        v64 = (<signed long>0)
                v65 = v64 == (<signed long>0)
                if v65:
                    v66 = v39 < v44
                    if v66:
                        v69 = (<signed long>-1)
                    else:
                        v67 = v39 > v44
                        if v67:
                            v69 = (<signed long>1)
                        else:
                            v69 = (<signed long>0)
                    v70 = v69 == (<signed long>0)
                    if v70:
                        v71 = v40 < v45
                        if v71:
                            v79 = (<signed long>-1)
                        else:
                            v72 = v40 > v45
                            if v72:
                                v79 = (<signed long>1)
                            else:
                                v79 = (<signed long>0)
                    else:
                        v79 = v69
                else:
                    v79 = v64
            else:
                v79 = v59
        else:
            v79 = v54
    else:
        v79 = v49
    v80 = v79 == (<signed long>0)
    if v80:
        v81 = <float>(<signed short>0)
        return Closure10(v15, v16, v17, v18, v19, v20, v21, v22, v23, v0, v81)
    else:
        v83 = v79 == (<signed long>1)
        if v83:
            v84 = <float>v18
            return Closure10(v15, v16, v17, v18, v19, v20, v21, v22, v23, v0, v84)
        else:
            v86 = -v18
            v87 = <float>v86
            return Closure10(v15, v16, v17, v18, v19, v20, v21, v22, v23, v0, v87)
cdef object method38(signed short v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12):
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    cdef numpy.ndarray[signed char,ndim=1] v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef Tuple4 tmp38
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef Tuple4 tmp39
    cdef signed char v35
    cdef signed char v36
    cdef signed char v37
    cdef signed char v38
    cdef signed char v39
    cdef signed char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef bint v45
    cdef signed long v48
    cdef bint v46
    cdef bint v49
    cdef signed long v78
    cdef bint v50
    cdef signed long v53
    cdef bint v51
    cdef bint v54
    cdef bint v55
    cdef signed long v58
    cdef bint v56
    cdef bint v59
    cdef bint v60
    cdef signed long v63
    cdef bint v61
    cdef bint v64
    cdef bint v65
    cdef signed long v68
    cdef bint v66
    cdef bint v69
    cdef bint v70
    cdef bint v71
    cdef bint v79
    cdef float v80
    cdef bint v82
    cdef float v83
    cdef signed short v85
    cdef float v86
    v13 = v12 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v10, v11, v12, v9, v6, v7, v8, v9
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v6, v7, v8, v9, v10, v11, v12, v9
    v22 = numpy.empty(5,dtype=numpy.int8)
    v22[0] = v1; v22[1] = v2; v22[2] = v3; v22[3] = v4; v22[4] = v5
    tmp38 = method16(v5, v4, v3, v2, v1, v15, v14)
    v23, v24, v25, v26, v27, v28 = tmp38.v0, tmp38.v1, tmp38.v2, tmp38.v3, tmp38.v4, tmp38.v5
    del tmp38
    tmp39 = method16(v5, v4, v3, v2, v1, v19, v18)
    v29, v30, v31, v32, v33, v34 = tmp39.v0, tmp39.v1, tmp39.v2, tmp39.v3, tmp39.v4, tmp39.v5
    del tmp39
    v35 = v23 % (<signed char>13)
    v36 = v24 % (<signed char>13)
    v37 = v25 % (<signed char>13)
    v38 = v26 % (<signed char>13)
    v39 = v27 % (<signed char>13)
    v40 = v29 % (<signed char>13)
    v41 = v30 % (<signed char>13)
    v42 = v31 % (<signed char>13)
    v43 = v32 % (<signed char>13)
    v44 = v33 % (<signed char>13)
    v45 = v28 < v34
    if v45:
        v48 = (<signed long>-1)
    else:
        v46 = v28 > v34
        if v46:
            v48 = (<signed long>1)
        else:
            v48 = (<signed long>0)
    v49 = v48 == (<signed long>0)
    if v49:
        v50 = v35 < v40
        if v50:
            v53 = (<signed long>-1)
        else:
            v51 = v35 > v40
            if v51:
                v53 = (<signed long>1)
            else:
                v53 = (<signed long>0)
        v54 = v53 == (<signed long>0)
        if v54:
            v55 = v36 < v41
            if v55:
                v58 = (<signed long>-1)
            else:
                v56 = v36 > v41
                if v56:
                    v58 = (<signed long>1)
                else:
                    v58 = (<signed long>0)
            v59 = v58 == (<signed long>0)
            if v59:
                v60 = v37 < v42
                if v60:
                    v63 = (<signed long>-1)
                else:
                    v61 = v37 > v42
                    if v61:
                        v63 = (<signed long>1)
                    else:
                        v63 = (<signed long>0)
                v64 = v63 == (<signed long>0)
                if v64:
                    v65 = v38 < v43
                    if v65:
                        v68 = (<signed long>-1)
                    else:
                        v66 = v38 > v43
                        if v66:
                            v68 = (<signed long>1)
                        else:
                            v68 = (<signed long>0)
                    v69 = v68 == (<signed long>0)
                    if v69:
                        v70 = v39 < v44
                        if v70:
                            v78 = (<signed long>-1)
                        else:
                            v71 = v39 > v44
                            if v71:
                                v78 = (<signed long>1)
                            else:
                                v78 = (<signed long>0)
                    else:
                        v78 = v68
                else:
                    v78 = v63
            else:
                v78 = v58
        else:
            v78 = v53
    else:
        v78 = v48
    v79 = v78 == (<signed long>0)
    if v79:
        v80 = <float>(<signed short>0)
        return Closure10(v14, v15, v16, v17, v18, v19, v20, v21, v22, v0, v80)
    else:
        v82 = v78 == (<signed long>1)
        if v82:
            v83 = <float>v17
            return Closure10(v14, v15, v16, v17, v18, v19, v20, v21, v22, v0, v83)
        else:
            v85 = -v17
            v86 = <float>v85
            return Closure10(v14, v15, v16, v17, v18, v19, v20, v21, v22, v0, v86)
cdef UH2 method39(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed short v32
    cdef float v33
    cdef signed short v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v28 = method37(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method38(v8, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v4
        else:
            v32 = v4
        v33 = <float>v32
        return UH2_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v4, v1, v2, v3, v4, v10, v8, 0, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US1_2>v16).v0
        v36 = 0
        v37 = method14(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method37(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef numpy.ndarray[object,ndim=1] v26
    v16 = v6 == v0
    if v16:
        return method38(v0, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v6 >= v6
        v19 = v6 < v6
        v20 = v6 + (<signed short>1)
        v21 = v0 < v20
        if v21:
            v22 = v0
        else:
            v22 = v20
        v23 = v0 == v6
        if v23:
            v24 = (<signed short>1)
        else:
            v24 = (<signed short>0)
        v25 = v22 + v24
        v26 = v1[(<signed short>1):3+v0-v25]
        return Closure13(v7, v8, v9, v6, v3, v4, v5, v10, v0, v26, v2, v1, v11, v12, v13, v14, v15)
cdef UH2 method36(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
    cdef object v29
    cdef bint v26
    cdef bint v31
    cdef signed short v33
    cdef float v34
    cdef signed short v36
    cdef bint v37
    cdef object v38
    if v17.tag == 0: # call
        if v0:
            v26 = 0
            v29 = method37(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method38(v9, v12, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
        return v29(v18, v19, v20, v21, v22, v23, v24, v25)
    elif v17.tag == 1: # fold
        v31 = v7 == (<unsigned char>0)
        if v31:
            v33 = -v8
        else:
            v33 = v8
        v34 = <float>v33
        return UH2_1(v18, v19, v20, v21, v22, v23, v24, v25, v5, v6, v7, v8, v1, v2, v3, v4, v11, v9, 0, v34)
    elif v17.tag == 2: # raiseTo_
        v36 = (<US1_2>v17).v0
        v37 = 0
        v38 = method14(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method14(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16):
    cdef bint v17
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef bint v26
    cdef signed short v27
    cdef signed short v28
    cdef signed short v29
    cdef bint v30
    cdef signed short v31
    cdef bint v32
    cdef signed short v33
    cdef signed short v34
    cdef numpy.ndarray[object,ndim=1] v35
    v17 = v10 == v0
    if v17:
        return method15(v0, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v19 = v10 == v6
        v20 = v19 != 1
        v21 = v10 >= v6
        if v21:
            v22 = v10
        else:
            v22 = v6
        v23 = v10 < v6
        if v23:
            v24 = v10
        else:
            v24 = v6
        v25 = v22 - v24
        v26 = (<signed short>1) >= v25
        if v26:
            v27 = (<signed short>1)
        else:
            v27 = v25
        v28 = v22 + v27
        if v20:
            v29 = (<signed short>0)
        else:
            v29 = (<signed short>1)
        v30 = v0 < v28
        if v30:
            v31 = v0
        else:
            v31 = v28
        v32 = v0 == v22
        if v32:
            v33 = (<signed short>1)
        else:
            v33 = (<signed short>0)
        v34 = v31 + v33
        v35 = v1[v29:3+v0-v34]
        return Closure11(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v35, v2, v1, v12, v13, v14, v15, v16)
cdef object method13(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, numpy.ndarray[signed char,ndim=1] v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed short v10, signed char v11, signed char v12, unsigned char v13, signed short v14):
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed short v19
    cdef signed char v20
    cdef signed char v21
    cdef unsigned char v22
    cdef signed short v23
    v15 = v13 == (<unsigned char>0)
    if v15:
        v16, v17, v18, v19, v20, v21, v22, v23 = v11, v12, v13, v14, v7, v8, v9, v10
    else:
        v16, v17, v18, v19, v20, v21, v22, v23 = v7, v8, v9, v10, v11, v12, v13, v14
    return Closure9(v5, v0, v1, v2, v3, v4, v6, v20, v21, v22, v23, v16, v17, v18, v19)
cdef object method42(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, numpy.ndarray[signed char,ndim=1] v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed short v10, signed char v11, signed char v12, unsigned char v13):
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    cdef signed char v19
    cdef signed char v20
    cdef unsigned char v21
    cdef signed short v22
    v14 = v13 == (<unsigned char>0)
    if v14:
        v15, v16, v17, v18, v19, v20, v21, v22 = v11, v12, v13, v10, v7, v8, v9, v10
    else:
        v15, v16, v17, v18, v19, v20, v21, v22 = v7, v8, v9, v10, v11, v12, v13, v10
    return Closure9(v5, v0, v1, v2, v3, v4, v6, v19, v20, v21, v22, v15, v16, v17, v18)
cdef UH2 method43(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed short v32
    cdef float v33
    cdef signed short v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v28 = method41(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method42(v8, v9, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v4
        else:
            v32 = v4
        v33 = <float>v32
        return UH2_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v4, v1, v2, v3, v4, v10, v8, 0, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US1_2>v16).v0
        v36 = 0
        v37 = method12(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method41(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef numpy.ndarray[object,ndim=1] v26
    v16 = v6 == v0
    if v16:
        return method42(v0, v1, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v6 >= v6
        v19 = v6 < v6
        v20 = v6 + (<signed short>1)
        v21 = v0 < v20
        if v21:
            v22 = v0
        else:
            v22 = v20
        v23 = v0 == v6
        if v23:
            v24 = (<signed short>1)
        else:
            v24 = (<signed short>0)
        v25 = v22 + v24
        v26 = v1[(<signed short>1):3+v0-v25]
        return Closure17(v7, v8, v9, v6, v3, v4, v5, v10, v0, v26, v2, v1, v11, v12, v13, v14, v15)
cdef UH2 method40(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
    cdef object v29
    cdef bint v26
    cdef bint v31
    cdef signed short v33
    cdef float v34
    cdef signed short v36
    cdef bint v37
    cdef object v38
    if v17.tag == 0: # call
        if v0:
            v26 = 0
            v29 = method41(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method42(v9, v10, v12, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
        return v29(v18, v19, v20, v21, v22, v23, v24, v25)
    elif v17.tag == 1: # fold
        v31 = v7 == (<unsigned char>0)
        if v31:
            v33 = -v8
        else:
            v33 = v8
        v34 = <float>v33
        return UH2_1(v18, v19, v20, v21, v22, v23, v24, v25, v5, v6, v7, v8, v1, v2, v3, v4, v11, v9, 0, v34)
    elif v17.tag == 2: # raiseTo_
        v36 = (<US1_2>v17).v0
        v37 = 0
        v38 = method12(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method12(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16):
    cdef bint v17
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef bint v26
    cdef signed short v27
    cdef signed short v28
    cdef signed short v29
    cdef bint v30
    cdef signed short v31
    cdef bint v32
    cdef signed short v33
    cdef signed short v34
    cdef numpy.ndarray[object,ndim=1] v35
    v17 = v10 == v0
    if v17:
        return method13(v0, v1, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v19 = v10 == v6
        v20 = v19 != 1
        v21 = v10 >= v6
        if v21:
            v22 = v10
        else:
            v22 = v6
        v23 = v10 < v6
        if v23:
            v24 = v10
        else:
            v24 = v6
        v25 = v22 - v24
        v26 = (<signed short>1) >= v25
        if v26:
            v27 = (<signed short>1)
        else:
            v27 = v25
        v28 = v22 + v27
        if v20:
            v29 = (<signed short>0)
        else:
            v29 = (<signed short>1)
        v30 = v0 < v28
        if v30:
            v31 = v0
        else:
            v31 = v28
        v32 = v0 == v22
        if v32:
            v33 = (<signed short>1)
        else:
            v33 = (<signed short>0)
        v34 = v31 + v33
        v35 = v1[v29:3+v0-v34]
        return Closure15(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v35, v2, v1, v12, v13, v14, v15, v16)
cdef object method11(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13):
    cdef bint v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    cdef signed char v19
    cdef signed char v20
    cdef unsigned char v21
    cdef signed short v22
    v14 = v12 == (<unsigned char>0)
    if v14:
        v15, v16, v17, v18, v19, v20, v21, v22 = v10, v11, v12, v13, v6, v7, v8, v9
    else:
        v15, v16, v17, v18, v19, v20, v21, v22 = v6, v7, v8, v9, v10, v11, v12, v13
    return Closure8(v4, v0, v1, v2, v3, v5, v19, v20, v21, v22, v15, v16, v17, v18)
cdef object method46(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12):
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    v13 = v12 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v10, v11, v12, v9, v6, v7, v8, v9
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v6, v7, v8, v9, v10, v11, v12, v9
    return Closure8(v4, v0, v1, v2, v3, v5, v18, v19, v20, v21, v14, v15, v16, v17)
cdef UH2 method47(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US1 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
    cdef object v27
    cdef bint v24
    cdef bint v29
    cdef signed short v31
    cdef float v32
    cdef signed short v34
    cdef bint v35
    cdef object v36
    if v15.tag == 0: # call
        if v0:
            v24 = 0
            v27 = method45(v8, v9, v24, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14)
        else:
            v27 = method46(v8, v9, v11, v12, v13, v14, v1, v2, v3, v4, v5, v6, v7)
        return v27(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v29 = v7 == (<unsigned char>0)
        if v29:
            v31 = -v4
        else:
            v31 = v4
        v32 = <float>v31
        return UH2_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v4, v1, v2, v3, v4, v10, v8, 0, v32)
    elif v15.tag == 2: # raiseTo_
        v34 = (<US1_2>v15).v0
        v35 = 0
        v36 = method10(v8, v9, v35, v5, v6, v7, v34, v1, v2, v3, v4, v10, v11, v12, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method45(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
    cdef bint v15
    cdef bint v17
    cdef bint v18
    cdef signed short v19
    cdef bint v20
    cdef signed short v21
    cdef bint v22
    cdef signed short v23
    cdef signed short v24
    cdef numpy.ndarray[object,ndim=1] v25
    v15 = v6 == v0
    if v15:
        return method46(v0, v1, v11, v12, v13, v14, v3, v4, v5, v6, v7, v8, v9)
    else:
        v17 = v6 >= v6
        v18 = v6 < v6
        v19 = v6 + (<signed short>1)
        v20 = v0 < v19
        if v20:
            v21 = v0
        else:
            v21 = v19
        v22 = v0 == v6
        if v22:
            v23 = (<signed short>1)
        else:
            v23 = (<signed short>0)
        v24 = v21 + v23
        v25 = v1[(<signed short>1):3+v0-v24]
        return Closure21(v7, v8, v9, v6, v3, v4, v5, v10, v0, v25, v2, v1, v11, v12, v13, v14)
cdef UH2 method44(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
    cdef object v28
    cdef bint v25
    cdef bint v30
    cdef signed short v32
    cdef float v33
    cdef signed short v35
    cdef bint v36
    cdef object v37
    if v16.tag == 0: # call
        if v0:
            v25 = 0
            v28 = method45(v9, v10, v25, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15)
        else:
            v28 = method46(v9, v10, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v8
        else:
            v32 = v8
        v33 = <float>v32
        return UH2_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v8, v1, v2, v3, v4, v11, v9, 0, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US1_2>v16).v0
        v36 = 0
        v37 = method10(v9, v10, v36, v5, v6, v7, v35, v1, v2, v3, v4, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method10(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
    cdef bint v16
    cdef bint v18
    cdef bint v19
    cdef bint v20
    cdef signed short v21
    cdef bint v22
    cdef signed short v23
    cdef signed short v24
    cdef bint v25
    cdef signed short v26
    cdef signed short v27
    cdef signed short v28
    cdef bint v29
    cdef signed short v30
    cdef bint v31
    cdef signed short v32
    cdef signed short v33
    cdef numpy.ndarray[object,ndim=1] v34
    v16 = v10 == v0
    if v16:
        return method11(v0, v1, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v18 = v10 == v6
        v19 = v18 != 1
        v20 = v10 >= v6
        if v20:
            v21 = v10
        else:
            v21 = v6
        v22 = v10 < v6
        if v22:
            v23 = v10
        else:
            v23 = v6
        v24 = v21 - v23
        v25 = (<signed short>1) >= v24
        if v25:
            v26 = (<signed short>1)
        else:
            v26 = v24
        v27 = v21 + v26
        if v19:
            v28 = (<signed short>0)
        else:
            v28 = (<signed short>1)
        v29 = v0 < v27
        if v29:
            v30 = v0
        else:
            v30 = v27
        v31 = v0 == v21
        if v31:
            v32 = (<signed short>1)
        else:
            v32 = (<signed short>0)
        v33 = v30 + v32
        v34 = v1[v28:3+v0-v33]
        return Closure19(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v34, v2, v1, v12, v13, v14, v15)
cdef object method9(signed short v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed char,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10):
    cdef bint v11
    cdef signed char v12
    cdef signed char v13
    cdef unsigned char v14
    cdef signed short v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed short v19
    v11 = v9 == (<unsigned char>0)
    if v11:
        v12, v13, v14, v15, v16, v17, v18, v19 = v7, v8, v9, v10, v3, v4, v5, v6
    else:
        v12, v13, v14, v15, v16, v17, v18, v19 = v3, v4, v5, v6, v7, v8, v9, v10
    return Closure7(v2, v0, v1, v16, v17, v18, v19, v12, v13, v14, v15)
cdef object method50(signed short v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed char,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9):
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed short v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    v10 = v9 == (<unsigned char>0)
    if v10:
        v11, v12, v13, v14, v15, v16, v17, v18 = v7, v8, v9, v6, v3, v4, v5, v6
    else:
        v11, v12, v13, v14, v15, v16, v17, v18 = v3, v4, v5, v6, v7, v8, v9, v6
    return Closure7(v2, v0, v1, v15, v16, v17, v18, v11, v12, v13, v14)
cdef UH2 method51(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
    cdef object v24
    cdef bint v21
    cdef bint v26
    cdef signed short v28
    cdef float v29
    cdef signed short v31
    cdef bint v32
    cdef object v33
    if v12.tag == 0: # call
        if v0:
            v21 = 0
            v24 = method49(v8, v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v24 = method50(v8, v9, v11, v1, v2, v3, v4, v5, v6, v7)
        return v24(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # fold
        v26 = v7 == (<unsigned char>0)
        if v26:
            v28 = -v4
        else:
            v28 = v4
        v29 = <float>v28
        return UH2_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v4, v1, v2, v3, v4, v10, v8, 0, v29)
    elif v12.tag == 2: # raiseTo_
        v31 = (<US1_2>v12).v0
        v32 = 0
        v33 = method8(v8, v9, v32, v5, v6, v7, v31, v1, v2, v3, v4, v10, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method49(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11):
    cdef bint v12
    cdef bint v14
    cdef bint v15
    cdef signed short v16
    cdef bint v17
    cdef signed short v18
    cdef bint v19
    cdef signed short v20
    cdef signed short v21
    cdef numpy.ndarray[object,ndim=1] v22
    v12 = v6 == v0
    if v12:
        return method50(v0, v1, v11, v3, v4, v5, v6, v7, v8, v9)
    else:
        v14 = v6 >= v6
        v15 = v6 < v6
        v16 = v6 + (<signed short>1)
        v17 = v0 < v16
        if v17:
            v18 = v0
        else:
            v18 = v16
        v19 = v0 == v6
        if v19:
            v20 = (<signed short>1)
        else:
            v20 = (<signed short>0)
        v21 = v18 + v20
        v22 = v1[(<signed short>1):3+v0-v21]
        return Closure25(v7, v8, v9, v6, v3, v4, v5, v10, v0, v22, v2, v1, v11)
cdef UH2 method48(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
    cdef object v25
    cdef bint v22
    cdef bint v27
    cdef signed short v29
    cdef float v30
    cdef signed short v32
    cdef bint v33
    cdef object v34
    if v13.tag == 0: # call
        if v0:
            v22 = 0
            v25 = method49(v9, v10, v22, v5, v6, v7, v4, v1, v2, v3, v11, v12)
        else:
            v25 = method50(v9, v10, v12, v1, v2, v3, v4, v5, v6, v7)
        return v25(v14, v15, v16, v17, v18, v19, v20, v21)
    elif v13.tag == 1: # fold
        v27 = v7 == (<unsigned char>0)
        if v27:
            v29 = -v8
        else:
            v29 = v8
        v30 = <float>v29
        return UH2_1(v14, v15, v16, v17, v18, v19, v20, v21, v5, v6, v7, v8, v1, v2, v3, v4, v11, v9, 0, v30)
    elif v13.tag == 2: # raiseTo_
        v32 = (<US1_2>v13).v0
        v33 = 0
        v34 = method8(v9, v10, v33, v5, v6, v7, v32, v1, v2, v3, v4, v11, v12)
        return v34(v14, v15, v16, v17, v18, v19, v20, v21)
cdef object method8(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12):
    cdef bint v13
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed short v18
    cdef bint v19
    cdef signed short v20
    cdef signed short v21
    cdef bint v22
    cdef signed short v23
    cdef signed short v24
    cdef signed short v25
    cdef bint v26
    cdef signed short v27
    cdef bint v28
    cdef signed short v29
    cdef signed short v30
    cdef numpy.ndarray[object,ndim=1] v31
    v13 = v10 == v0
    if v13:
        return method9(v0, v1, v12, v3, v4, v5, v6, v7, v8, v9, v10)
    else:
        v15 = v10 == v6
        v16 = v15 != 1
        v17 = v10 >= v6
        if v17:
            v18 = v10
        else:
            v18 = v6
        v19 = v10 < v6
        if v19:
            v20 = v10
        else:
            v20 = v6
        v21 = v18 - v20
        v22 = (<signed short>1) >= v21
        if v22:
            v23 = (<signed short>1)
        else:
            v23 = v21
        v24 = v18 + v23
        if v16:
            v25 = (<signed short>0)
        else:
            v25 = (<signed short>1)
        v26 = v0 < v24
        if v26:
            v27 = v0
        else:
            v27 = v24
        v28 = v0 == v18
        if v28:
            v29 = (<signed short>1)
        else:
            v29 = (<signed short>0)
        v30 = v27 + v29
        v31 = v1[v25:3+v0-v30]
        return Closure23(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v31, v2, v1, v12)
cdef bint method53(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method52(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut0 v11
    cdef unsigned long long v13
    cdef UH2 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef UH0 v20
    cdef float v21
    cdef float v22
    cdef signed char v23
    cdef signed char v24
    cdef unsigned char v25
    cdef signed short v26
    cdef signed char v27
    cdef signed char v28
    cdef unsigned char v29
    cdef signed short v30
    cdef numpy.ndarray[signed char,ndim=1] v31
    cdef signed short v32
    cdef bint v33
    cdef unsigned char v34
    cdef numpy.ndarray[object,ndim=1] v35
    cdef object v36
    cdef bint v37
    cdef float v38
    cdef float v39
    cdef UH0 v40
    cdef float v41
    cdef float v42
    cdef UH0 v43
    cdef float v44
    cdef float v45
    cdef signed char v46
    cdef signed char v47
    cdef unsigned char v48
    cdef signed short v49
    cdef signed char v50
    cdef signed char v51
    cdef unsigned char v52
    cdef signed short v53
    cdef numpy.ndarray[signed char,ndim=1] v54
    cdef signed short v55
    cdef bint v56
    cdef float v57
    cdef unsigned long long v58
    cdef unsigned long long v59
    cdef bint v60
    cdef list v131
    cdef numpy.ndarray[object,ndim=1] v61
    cdef object v62
    cdef Tuple0 tmp40
    cdef numpy.ndarray[object,ndim=1] v63
    cdef object v64
    cdef Tuple0 tmp41
    cdef unsigned long long v65
    cdef unsigned long long v66
    cdef bint v67
    cdef bint v68
    cdef numpy.ndarray[object,ndim=1] v69
    cdef Mut0 v70
    cdef unsigned long long v72
    cdef object v73
    cdef float v74
    cdef float v75
    cdef US1 v76
    cdef Tuple3 tmp42
    cdef UH2 v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef unsigned long long v80
    cdef bint v81
    cdef bint v82
    cdef numpy.ndarray[object,ndim=1] v83
    cdef Mut0 v84
    cdef unsigned long long v86
    cdef object v87
    cdef float v88
    cdef float v89
    cdef US1 v90
    cdef Tuple3 tmp43
    cdef UH2 v91
    cdef unsigned long long v92
    cdef unsigned long long v93
    cdef unsigned long long v94
    cdef unsigned long long v95
    cdef numpy.ndarray[object,ndim=1] v96
    cdef Mut0 v97
    cdef unsigned long long v99
    cdef bint v100
    cdef UH2 v104
    cdef unsigned long long v102
    cdef unsigned long long v105
    cdef numpy.ndarray[float,ndim=1] v106
    cdef numpy.ndarray[float,ndim=1] v107
    cdef numpy.ndarray[float,ndim=1] v108
    cdef numpy.ndarray[float,ndim=1] v109
    cdef numpy.ndarray[float,ndim=1] v110
    cdef unsigned long long v111
    cdef list v112
    cdef Mut2 v113
    cdef unsigned long long v115
    cdef unsigned long long v116
    cdef unsigned long long v117
    cdef unsigned char v118
    cdef bint v119
    cdef float v124
    cdef unsigned long long v125
    cdef unsigned long long v126
    cdef float v120
    cdef unsigned long long v121
    cdef float v122
    cdef unsigned long long v123
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef unsigned long long v129
    cdef numpy.ndarray[float,ndim=1] v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef bint v135
    cdef bint v136
    cdef Mut0 v137
    cdef unsigned long long v139
    cdef unsigned long long v140
    cdef float v141
    cdef unsigned long long v142
    cdef unsigned long long v143
    cdef Mut0 v144
    cdef unsigned long long v146
    cdef unsigned long long v147
    cdef float v148
    cdef float v149
    cdef UH0 v150
    cdef float v151
    cdef float v152
    cdef UH0 v153
    cdef float v154
    cdef float v155
    cdef signed char v156
    cdef signed char v157
    cdef unsigned char v158
    cdef signed short v159
    cdef signed char v160
    cdef signed char v161
    cdef unsigned char v162
    cdef signed short v163
    cdef numpy.ndarray[signed char,ndim=1] v164
    cdef signed short v165
    cdef bint v166
    cdef float v167
    cdef Tuple7 tmp44
    cdef unsigned long long v168
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v2)
    v11 = Mut0((<unsigned long long>0))
    while method0(v10, v11):
        v13 = v11.v0
        v14 = v2[v13]
        if v14.tag == 0: # action_
            v15 = (<UH2_0>v14).v0; v16 = (<UH2_0>v14).v1; v17 = (<UH2_0>v14).v2; v18 = (<UH2_0>v14).v3; v19 = (<UH2_0>v14).v4; v20 = (<UH2_0>v14).v5; v21 = (<UH2_0>v14).v6; v22 = (<UH2_0>v14).v7; v23 = (<UH2_0>v14).v8; v24 = (<UH2_0>v14).v9; v25 = (<UH2_0>v14).v10; v26 = (<UH2_0>v14).v11; v27 = (<UH2_0>v14).v12; v28 = (<UH2_0>v14).v13; v29 = (<UH2_0>v14).v14; v30 = (<UH2_0>v14).v15; v31 = (<UH2_0>v14).v16; v32 = (<UH2_0>v14).v17; v33 = (<UH2_0>v14).v18; v34 = (<UH2_0>v14).v19; v35 = (<UH2_0>v14).v20; v36 = (<UH2_0>v14).v21
            v4.append(v13)
            v37 = v34 == (<unsigned char>0)
            if v37:
                v5.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35))
                v7.append(v36)
            else:
                v6.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35))
                v8.append(v36)
            del v17; del v20; del v31; del v35; del v36
            v9.append(v34)
        elif v14.tag == 1: # terminal_
            v38 = (<UH2_1>v14).v0; v39 = (<UH2_1>v14).v1; v40 = (<UH2_1>v14).v2; v41 = (<UH2_1>v14).v3; v42 = (<UH2_1>v14).v4; v43 = (<UH2_1>v14).v5; v44 = (<UH2_1>v14).v6; v45 = (<UH2_1>v14).v7; v46 = (<UH2_1>v14).v8; v47 = (<UH2_1>v14).v9; v48 = (<UH2_1>v14).v10; v49 = (<UH2_1>v14).v11; v50 = (<UH2_1>v14).v12; v51 = (<UH2_1>v14).v13; v52 = (<UH2_1>v14).v14; v53 = (<UH2_1>v14).v15; v54 = (<UH2_1>v14).v16; v55 = (<UH2_1>v14).v17; v56 = (<UH2_1>v14).v18; v57 = (<UH2_1>v14).v19
            v3.append(Tuple7(v13, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57))
            del v40; del v43; del v54
        del v14
        v58 = v13 + (<unsigned long long>1)
        v11.v0 = v58
    del v11
    v59 = len(v9)
    v60 = (<unsigned long long>0) < v59
    if v60:
        tmp40 = v1(v5)
        v61, v62 = tmp40.v0, tmp40.v1
        del tmp40
        tmp41 = v0(v6)
        v63, v64 = tmp41.v0, tmp41.v1
        del tmp41
        v65 = len(v7)
        v66 = len(v61)
        v67 = v65 == v66
        v68 = v67 == 0
        if v68:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v69 = numpy.empty(v65,dtype=object)
        v70 = Mut0((<unsigned long long>0))
        while method0(v65, v70):
            v72 = v70.v0
            v73 = v7[v72]
            tmp42 = v61[v72]
            v74, v75, v76 = tmp42.v0, tmp42.v1, tmp42.v2
            del tmp42
            v77 = v73(v74, v75, v76)
            del v73; del v76
            v69[v72] = v77
            del v77
            v78 = v72 + (<unsigned long long>1)
            v70.v0 = v78
        del v61
        del v70
        v79 = len(v8)
        v80 = len(v63)
        v81 = v79 == v80
        v82 = v81 == 0
        if v82:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v83 = numpy.empty(v79,dtype=object)
        v84 = Mut0((<unsigned long long>0))
        while method0(v79, v84):
            v86 = v84.v0
            v87 = v8[v86]
            tmp43 = v63[v86]
            v88, v89, v90 = tmp43.v0, tmp43.v1, tmp43.v2
            del tmp43
            v91 = v87(v88, v89, v90)
            del v87; del v90
            v83[v86] = v91
            del v91
            v92 = v86 + (<unsigned long long>1)
            v84.v0 = v92
        del v63
        del v84
        v93 = len(v69)
        v94 = len(v83)
        v95 = v93 + v94
        v96 = numpy.empty(v95,dtype=object)
        v97 = Mut0((<unsigned long long>0))
        while method0(v95, v97):
            v99 = v97.v0
            v100 = v99 < v93
            if v100:
                v104 = v69[v99]
            else:
                v102 = v99 - v93
                v104 = v83[v102]
            v96[v99] = v104
            del v104
            v105 = v99 + (<unsigned long long>1)
            v97.v0 = v105
        del v69; del v83
        del v97
        v106 = method52(v0, v1, v96)
        del v96
        v107 = v106[:v66]
        v108 = v62(v107)
        del v62; del v107
        v109 = v106[v66:]
        del v106
        v110 = v64(v109)
        del v64; del v109
        v111 = len(v9)
        v112 = [None]*v111
        v113 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method53(v111, v113):
            v115 = v113.v0
            v116, v117 = v113.v1, v113.v2
            v118 = v9[v115]
            v119 = v118 == (<unsigned char>0)
            if v119:
                v120 = v108[v116]
                v121 = v116 + (<unsigned long long>1)
                v124, v125, v126 = v120, v121, v117
            else:
                v122 = v110[v117]
                v123 = v117 + (<unsigned long long>1)
                v124, v125, v126 = v122, v116, v123
            v112[v115] = v124
            v127 = v115 + (<unsigned long long>1)
            v113.v0 = v127
            v113.v1 = v125
            v113.v2 = v126
        del v108; del v110
        v128, v129 = v113.v1, v113.v2
        del v113
        v131 = v112
        del v112
    else:
        v131 = [None]*(<unsigned long long>0)
    del v5; del v6; del v7; del v8; del v9
    v132 = numpy.empty(v10,dtype=numpy.float32)
    v133 = len(v4)
    v134 = len(v131)
    v135 = v133 == v134
    v136 = v135 == 0
    if v136:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v137 = Mut0((<unsigned long long>0))
    while method0(v133, v137):
        v139 = v137.v0
        v140 = v4[v139]
        v141 = v131[v139]
        v132[v140] = v141
        v142 = v139 + (<unsigned long long>1)
        v137.v0 = v142
    del v4; del v131
    del v137
    v143 = len(v3)
    v144 = Mut0((<unsigned long long>0))
    while method0(v143, v144):
        v146 = v144.v0
        tmp44 = v3[v146]
        v147, v148, v149, v150, v151, v152, v153, v154, v155, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167 = tmp44.v0, tmp44.v1, tmp44.v2, tmp44.v3, tmp44.v4, tmp44.v5, tmp44.v6, tmp44.v7, tmp44.v8, tmp44.v9, tmp44.v10, tmp44.v11, tmp44.v12, tmp44.v13, tmp44.v14, tmp44.v15, tmp44.v16, tmp44.v17, tmp44.v18, tmp44.v19, tmp44.v20
        del tmp44
        del v150; del v153; del v164
        v132[v147] = v167
        v168 = v146 + (<unsigned long long>1)
        v144.v0 = v168
    del v3
    del v144
    return v132
cdef numpy.ndarray[float,ndim=1] method54(v0, numpy.ndarray[object,ndim=1] v1):
    cdef list v2
    cdef list v3
    cdef list v4
    cdef list v5
    cdef unsigned long long v6
    cdef Mut0 v7
    cdef unsigned long long v9
    cdef UH2 v10
    cdef float v11
    cdef float v12
    cdef UH0 v13
    cdef float v14
    cdef float v15
    cdef UH0 v16
    cdef float v17
    cdef float v18
    cdef signed char v19
    cdef signed char v20
    cdef unsigned char v21
    cdef signed short v22
    cdef signed char v23
    cdef signed char v24
    cdef unsigned char v25
    cdef signed short v26
    cdef numpy.ndarray[signed char,ndim=1] v27
    cdef signed short v28
    cdef bint v29
    cdef unsigned char v30
    cdef numpy.ndarray[object,ndim=1] v31
    cdef object v32
    cdef float v33
    cdef float v34
    cdef UH0 v35
    cdef float v36
    cdef float v37
    cdef UH0 v38
    cdef float v39
    cdef float v40
    cdef signed char v41
    cdef signed char v42
    cdef unsigned char v43
    cdef signed short v44
    cdef signed char v45
    cdef signed char v46
    cdef unsigned char v47
    cdef signed short v48
    cdef numpy.ndarray[signed char,ndim=1] v49
    cdef signed short v50
    cdef bint v51
    cdef float v52
    cdef unsigned long long v53
    cdef unsigned long long v54
    cdef bint v55
    cdef numpy.ndarray[float,ndim=1] v75
    cdef numpy.ndarray[object,ndim=1] v56
    cdef object v57
    cdef Tuple0 tmp49
    cdef unsigned long long v58
    cdef unsigned long long v59
    cdef bint v60
    cdef bint v61
    cdef numpy.ndarray[object,ndim=1] v62
    cdef Mut0 v63
    cdef unsigned long long v65
    cdef object v66
    cdef float v67
    cdef float v68
    cdef US1 v69
    cdef Tuple3 tmp50
    cdef UH2 v70
    cdef unsigned long long v71
    cdef numpy.ndarray[float,ndim=1] v72
    cdef numpy.ndarray[float,ndim=1] v74
    cdef numpy.ndarray[float,ndim=1] v76
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef bint v79
    cdef bint v80
    cdef Mut0 v81
    cdef unsigned long long v83
    cdef unsigned long long v84
    cdef float v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef Mut0 v88
    cdef unsigned long long v90
    cdef unsigned long long v91
    cdef float v92
    cdef float v93
    cdef UH0 v94
    cdef float v95
    cdef float v96
    cdef UH0 v97
    cdef float v98
    cdef float v99
    cdef signed char v100
    cdef signed char v101
    cdef unsigned char v102
    cdef signed short v103
    cdef signed char v104
    cdef signed char v105
    cdef unsigned char v106
    cdef signed short v107
    cdef numpy.ndarray[signed char,ndim=1] v108
    cdef signed short v109
    cdef bint v110
    cdef float v111
    cdef Tuple7 tmp51
    cdef unsigned long long v112
    v2 = [None]*(<unsigned long long>0)
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = len(v1)
    v7 = Mut0((<unsigned long long>0))
    while method0(v6, v7):
        v9 = v7.v0
        v10 = v1[v9]
        if v10.tag == 0: # action_
            v11 = (<UH2_0>v10).v0; v12 = (<UH2_0>v10).v1; v13 = (<UH2_0>v10).v2; v14 = (<UH2_0>v10).v3; v15 = (<UH2_0>v10).v4; v16 = (<UH2_0>v10).v5; v17 = (<UH2_0>v10).v6; v18 = (<UH2_0>v10).v7; v19 = (<UH2_0>v10).v8; v20 = (<UH2_0>v10).v9; v21 = (<UH2_0>v10).v10; v22 = (<UH2_0>v10).v11; v23 = (<UH2_0>v10).v12; v24 = (<UH2_0>v10).v13; v25 = (<UH2_0>v10).v14; v26 = (<UH2_0>v10).v15; v27 = (<UH2_0>v10).v16; v28 = (<UH2_0>v10).v17; v29 = (<UH2_0>v10).v18; v30 = (<UH2_0>v10).v19; v31 = (<UH2_0>v10).v20; v32 = (<UH2_0>v10).v21
            v3.append(v9)
            v4.append(Tuple1(v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
            del v13; del v16; del v27; del v31
            v5.append(v32)
            del v32
        elif v10.tag == 1: # terminal_
            v33 = (<UH2_1>v10).v0; v34 = (<UH2_1>v10).v1; v35 = (<UH2_1>v10).v2; v36 = (<UH2_1>v10).v3; v37 = (<UH2_1>v10).v4; v38 = (<UH2_1>v10).v5; v39 = (<UH2_1>v10).v6; v40 = (<UH2_1>v10).v7; v41 = (<UH2_1>v10).v8; v42 = (<UH2_1>v10).v9; v43 = (<UH2_1>v10).v10; v44 = (<UH2_1>v10).v11; v45 = (<UH2_1>v10).v12; v46 = (<UH2_1>v10).v13; v47 = (<UH2_1>v10).v14; v48 = (<UH2_1>v10).v15; v49 = (<UH2_1>v10).v16; v50 = (<UH2_1>v10).v17; v51 = (<UH2_1>v10).v18; v52 = (<UH2_1>v10).v19
            v2.append(Tuple7(v9, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52))
            del v35; del v38; del v49
        del v10
        v53 = v9 + (<unsigned long long>1)
        v7.v0 = v53
    del v7
    v54 = len(v4)
    v55 = (<unsigned long long>0) < v54
    if v55:
        tmp49 = v0(v4)
        v56, v57 = tmp49.v0, tmp49.v1
        del tmp49
        v58 = len(v5)
        v59 = len(v56)
        v60 = v58 == v59
        v61 = v60 == 0
        if v61:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v62 = numpy.empty(v58,dtype=object)
        v63 = Mut0((<unsigned long long>0))
        while method0(v58, v63):
            v65 = v63.v0
            v66 = v5[v65]
            tmp50 = v56[v65]
            v67, v68, v69 = tmp50.v0, tmp50.v1, tmp50.v2
            del tmp50
            v70 = v66(v67, v68, v69)
            del v66; del v69
            v62[v65] = v70
            del v70
            v71 = v65 + (<unsigned long long>1)
            v63.v0 = v71
        del v56
        del v63
        v72 = method54(v0, v62)
        del v62
        v75 = v57(v72)
        del v57; del v72
    else:
        v74 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v75 = v74
        del v74
    del v4; del v5
    v76 = numpy.empty(v6,dtype=numpy.float32)
    v77 = len(v3)
    v78 = len(v75)
    v79 = v77 == v78
    v80 = v79 == 0
    if v80:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v81 = Mut0((<unsigned long long>0))
    while method0(v77, v81):
        v83 = v81.v0
        v84 = v3[v83]
        v85 = v75[v83]
        v76[v84] = v85
        v86 = v83 + (<unsigned long long>1)
        v81.v0 = v86
    del v3; del v75
    del v81
    v87 = len(v2)
    v88 = Mut0((<unsigned long long>0))
    while method0(v87, v88):
        v90 = v88.v0
        tmp51 = v2[v90]
        v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108, v109, v110, v111 = tmp51.v0, tmp51.v1, tmp51.v2, tmp51.v3, tmp51.v4, tmp51.v5, tmp51.v6, tmp51.v7, tmp51.v8, tmp51.v9, tmp51.v10, tmp51.v11, tmp51.v12, tmp51.v13, tmp51.v14, tmp51.v15, tmp51.v16, tmp51.v17, tmp51.v18, tmp51.v19, tmp51.v20
        del tmp51
        del v94; del v97; del v108
        v76[v91] = v111
        v112 = v90 + (<unsigned long long>1)
        v88.v0 = v112
    del v2
    del v88
    return v76
cdef UH2 method56(unsigned char v0, v1, UH2 v2):
    cdef float v3
    cdef float v4
    cdef UH0 v5
    cdef float v6
    cdef float v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed short v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    cdef numpy.ndarray[signed char,ndim=1] v19
    cdef signed short v20
    cdef bint v21
    cdef unsigned char v22
    cdef numpy.ndarray[object,ndim=1] v23
    cdef object v24
    cdef bint v25
    cdef list v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef object v28
    cdef Tuple0 tmp56
    cdef float v29
    cdef float v30
    cdef US1 v31
    cdef Tuple3 tmp57
    cdef UH2 v32
    cdef float v35
    cdef float v36
    cdef float v38
    cdef float v39
    cdef float v41
    cdef float v42
    cdef signed char v43
    cdef signed char v44
    cdef unsigned char v45
    cdef signed short v46
    cdef signed char v47
    cdef signed char v48
    cdef unsigned char v49
    cdef signed short v50
    cdef signed short v52
    cdef bint v53
    cdef float v54
    if v2.tag == 0: # action_
        v3 = (<UH2_0>v2).v0; v4 = (<UH2_0>v2).v1; v5 = (<UH2_0>v2).v2; v6 = (<UH2_0>v2).v3; v7 = (<UH2_0>v2).v4; v8 = (<UH2_0>v2).v5; v9 = (<UH2_0>v2).v6; v10 = (<UH2_0>v2).v7; v11 = (<UH2_0>v2).v8; v12 = (<UH2_0>v2).v9; v13 = (<UH2_0>v2).v10; v14 = (<UH2_0>v2).v11; v15 = (<UH2_0>v2).v12; v16 = (<UH2_0>v2).v13; v17 = (<UH2_0>v2).v14; v18 = (<UH2_0>v2).v15; v19 = (<UH2_0>v2).v16; v20 = (<UH2_0>v2).v17; v21 = (<UH2_0>v2).v18; v22 = (<UH2_0>v2).v19; v23 = (<UH2_0>v2).v20; v24 = (<UH2_0>v2).v21
        v25 = v22 == v0
        if v25:
            del v5; del v8; del v19; del v23; del v24
            return v2
        else:
            v26 = [None]*(<unsigned long long>1)
            v26[(<unsigned long long>0)] = Tuple1(v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23)
            del v5; del v8; del v19; del v23
            tmp56 = v1(v26)
            v27, v28 = tmp56.v0, tmp56.v1
            del tmp56
            del v26; del v28
            tmp57 = v27[(<unsigned long long>0)]
            v29, v30, v31 = tmp57.v0, tmp57.v1, tmp57.v2
            del tmp57
            del v27
            v32 = v24(v29, v30, v31)
            del v24; del v31
            return method56(v0, v1, v32)
    elif v2.tag == 1: # terminal_
        v35 = (<UH2_1>v2).v0; v36 = (<UH2_1>v2).v1; v38 = (<UH2_1>v2).v3; v39 = (<UH2_1>v2).v4; v41 = (<UH2_1>v2).v6; v42 = (<UH2_1>v2).v7; v43 = (<UH2_1>v2).v8; v44 = (<UH2_1>v2).v9; v45 = (<UH2_1>v2).v10; v46 = (<UH2_1>v2).v11; v47 = (<UH2_1>v2).v12; v48 = (<UH2_1>v2).v13; v49 = (<UH2_1>v2).v14; v50 = (<UH2_1>v2).v15; v52 = (<UH2_1>v2).v17; v53 = (<UH2_1>v2).v18; v54 = (<UH2_1>v2).v19
        return v2
cdef UH0 method58(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method58(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef void method60(list v0, list v1) except *:
    cdef unsigned long long v2
    cdef bint v3
    cdef str v4
    v2 = len(v1)
    v3 = (<unsigned long long>0) < v2
    if v3:
        v4 = "".join(v1)
        v0.append(v4)
        del v4
        v1.clear()
    else:
        pass
cdef str method61(signed char v0):
    cdef signed char v1
    cdef signed char v2
    cdef bint v3
    cdef str v13
    cdef bint v4
    cdef bint v5
    cdef bint v6
    cdef bint v7
    cdef bint v14
    cdef str v19
    cdef bint v15
    cdef bint v16
    v1 = v0 // (<signed char>13)
    v2 = v0 % (<signed char>13)
    v3 = (<signed char>12) == v2
    if v3:
        v13 = 'A'
    else:
        v4 = (<signed char>11) == v2
        if v4:
            v13 = 'K'
        else:
            v5 = (<signed char>10) == v2
            if v5:
                v13 = 'Q'
            else:
                v6 = (<signed char>9) == v2
                if v6:
                    v13 = 'J'
                else:
                    v7 = (<signed char>8) == v2
                    if v7:
                        v13 = 'T'
                    else:
                        v13 = str(2 + v2)
    v14 = (<signed char>0) == v1
    if v14:
        v19 = "[color=ff0000]"
    else:
        v15 = (<signed char>1) == v1
        if v15:
            v19 = "[color=00ff00]"
        else:
            v16 = (<signed char>2) == v1
            if v16:
                v19 = "[color=0000ff]"
            else:
                v19 = "[color=ffff00]"
    return f'{v19}{v13}[/color]'
cdef void method59(list v0, list v1, bint v2, UH0 v3) except *:
    cdef US0 v4
    cdef UH0 v5
    cdef US1 v6
    cdef str v7
    cdef str v12
    cdef signed short v10
    cdef bint v13
    cdef signed char v14
    cdef str v15
    cdef bint v16
    if v3.tag == 0: # cons_
        v4 = (<UH0_0>v3).v0; v5 = (<UH0_0>v3).v1
        if v4.tag == 0: # action_
            v6 = (<US0_0>v4).v0
            method60(v0, v1)
            if v2:
                v7 = "Player One"
            else:
                v7 = "Player Two"
            if v6.tag == 0: # call
                v12 = f'{v7} calls.'
            elif v6.tag == 1: # fold
                v12 = f'{v7} folds.'
            elif v6.tag == 2: # raiseTo_
                v10 = (<US1_2>v6).v0
                v12 = f'{v7} raises to {v10}.'
            del v6; del v7
            v0.append(v12)
            del v12
            v13 = v2 == 0
            method59(v0, v1, v13, v5)
        elif v4.tag == 1: # observation_
            v14 = (<US0_1>v4).v0
            v15 = method61(v14)
            v1.append(v15)
            del v15
            v16 = 1
            method59(v0, v1, v16, v5)
    elif v3.tag == 1: # nil
        method60(v0, v1)
cdef list method57(UH0 v0):
    cdef list v1
    cdef list v2
    cdef bint v3
    cdef UH0 v4
    cdef UH0 v5
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = 1
    v4 = UH0_1()
    v5 = method58(v0, v4)
    del v4
    method59(v1, v2, v3, v5)
    del v2; del v5
    return v1
cdef bint method62(signed short v0, Mut3 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef str method63(signed char v0, signed char v1):
    cdef str v2
    cdef str v3
    v2 = method61(v1)
    v3 = method61(v0)
    return f'{v2}{v3}'
cdef str method66(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
    cdef bint v6
    cdef bint v7
    cdef bint v8
    cdef bint v9
    cdef bint v10
    cdef bint v11
    cdef bint v12
    cdef bint v13
    cdef bint v14
    v6 = (<signed char>1) == v5
    if v6:
        return "high card"
    else:
        v7 = (<signed char>2) == v5
        if v7:
            return "pair"
        else:
            v8 = (<signed char>3) == v5
            if v8:
                return "two pair"
            else:
                v9 = (<signed char>4) == v5
                if v9:
                    return "triple"
                else:
                    v10 = (<signed char>5) == v5
                    if v10:
                        return "straight"
                    else:
                        v11 = (<signed char>6) == v5
                        if v11:
                            return "flush"
                        else:
                            v12 = (<signed char>7) == v5
                            if v12:
                                return "full house"
                            else:
                                v13 = (<signed char>8) == v5
                                if v13:
                                    return "four of a kind"
                                else:
                                    v14 = (<signed char>9) == v5
                                    if v14:
                                        return "straight flush"
                                    else:
                                        raise Exception("Invalid card score.")
cdef str method67(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef str v5
    cdef str v6
    cdef str v7
    cdef str v8
    cdef str v9
    v5 = method61(v4)
    v6 = method61(v3)
    v7 = method61(v2)
    v8 = method61(v1)
    v9 = method61(v0)
    return f'{v5}{v6}{v7}{v8}{v9}'
cdef void method65(numpy.ndarray[signed char,ndim=1] v0, list v1, unsigned char v2, signed char v3, signed char v4) except *:
    cdef bint v5
    cdef str v6
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef signed char v17
    cdef Tuple4 tmp60
    cdef str v18
    cdef str v19
    cdef str v20
    v5 = v2 == (<unsigned char>0)
    if v5:
        v6 = "Player One"
    else:
        v6 = "Player Two"
    v7 = v0[(<signed short>0)]
    v8 = v0[(<signed short>1)]
    v9 = v0[(<signed short>2)]
    v10 = v0[(<signed short>3)]
    v11 = v0[(<signed short>4)]
    tmp60 = method16(v11, v10, v9, v8, v7, v4, v3)
    v12, v13, v14, v15, v16, v17 = tmp60.v0, tmp60.v1, tmp60.v2, tmp60.v3, tmp60.v4, tmp60.v5
    del tmp60
    v18 = method66(v12, v13, v14, v15, v16, v17)
    v19 = method67(v16, v15, v14, v13, v12)
    v20 = f'{v6} shows {v18} {v19}'
    del v6; del v18; del v19
    v1.append(v20)
cdef void method68(float v0, list v1, unsigned char v2) except *:
    cdef bint v3
    cdef str v4
    cdef float v6
    cdef float v7
    cdef bint v8
    cdef float v9
    cdef bint v10
    cdef str v16
    cdef bint v12
    v3 = v2 == (<unsigned char>0)
    if v3:
        v4 = "Player One"
    else:
        v4 = "Player Two"
    if v3:
        v6 = v0
    else:
        v6 = -v0
    v7 = -v6
    v8 = v6 >= v7
    if v8:
        v9 = v6
    else:
        v9 = v7
    v10 = v6 < (<float>0.000000)
    if v10:
        v16 = f'{v4} losses {v9} chips.'
    else:
        v12 = v6 == (<float>0.000000)
        if v12:
            v16 = f'{v4} ties.'
        else:
            v16 = f'{v4} gains {v9} chips.'
    del v4
    v1.append(v16)
cdef str method64(bint v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, float v10, list v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef unsigned char v21
    cdef unsigned char v22
    cdef unsigned char v23
    cdef unsigned char v24
    v12 = v8 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v6, v7, v8, v9, v2, v3, v4, v5
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v2, v3, v4, v5, v6, v7, v8, v9
    if v0:
        v21 = (<unsigned char>0)
        method65(v1, v11, v21, v13, v14)
        v22 = (<unsigned char>1)
        method65(v1, v11, v22, v17, v18)
    else:
        pass
    v23 = (<unsigned char>0)
    method68(v10, v11, v23)
    v24 = (<unsigned char>1)
    method68(v10, v11, v24)
    return "\n".join(v11)
cdef void method55(v0, v1, unsigned char v2, signed short v3, UH2 v4) except *:
    cdef UH2 v5
    cdef float v6
    cdef float v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    cdef numpy.ndarray[signed char,ndim=1] v22
    cdef signed short v23
    cdef bint v24
    cdef unsigned char v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef object v27
    cdef bint v28
    cdef UH0 v29
    cdef list v30
    cdef str v31
    cdef signed short v32
    cdef unsigned long long tmp58
    cdef Mut3 v33
    cdef signed short v35
    cdef signed short v36
    cdef US1 v37
    cdef signed short v41
    cdef signed short v38
    cdef bint v39
    cdef signed short v42
    cdef signed short v43
    cdef Mut3 v44
    cdef signed short v46
    cdef signed short v47
    cdef US1 v48
    cdef signed short v52
    cdef signed short v49
    cdef bint v50
    cdef signed short v53
    cdef signed short v54
    cdef bint v55
    cdef object v58
    cdef object v59
    cdef object v60
    cdef object v61
    cdef bint v62
    cdef signed char v63
    cdef signed char v64
    cdef unsigned char v65
    cdef signed short v66
    cdef signed char v67
    cdef signed char v68
    cdef unsigned char v69
    cdef signed short v70
    cdef signed short v71
    cdef str v72
    cdef signed short v73
    cdef str v74
    cdef signed short v75
    cdef unsigned long long tmp59
    cdef list v76
    cdef Mut1 v77
    cdef signed short v79
    cdef signed char v80
    cdef str v81
    cdef signed short v82
    cdef str v83
    cdef object v84
    cdef object v85
    cdef float v86
    cdef float v87
    cdef UH0 v88
    cdef float v89
    cdef float v90
    cdef UH0 v91
    cdef float v92
    cdef float v93
    cdef signed char v94
    cdef signed char v95
    cdef unsigned char v96
    cdef signed short v97
    cdef signed char v98
    cdef signed char v99
    cdef unsigned char v100
    cdef signed short v101
    cdef numpy.ndarray[signed char,ndim=1] v102
    cdef signed short v103
    cdef bint v104
    cdef float v105
    cdef bint v106
    cdef UH0 v107
    cdef list v108
    cdef str v109
    cdef object v110
    cdef object v111
    cdef object v112
    cdef object v113
    cdef float v115
    cdef signed short v116
    cdef bint v117
    cdef signed char v118
    cdef signed char v119
    cdef unsigned char v120
    cdef signed short v121
    cdef signed char v122
    cdef signed char v123
    cdef unsigned char v124
    cdef signed short v125
    cdef signed short v126
    cdef str v127
    cdef signed short v128
    cdef str v129
    cdef signed short v130
    cdef unsigned long long tmp61
    cdef list v131
    cdef Mut1 v132
    cdef signed short v134
    cdef signed char v135
    cdef str v136
    cdef signed short v137
    cdef str v138
    cdef object v139
    cdef object v140
    v5 = method56(v2, v0, v4)
    if v5.tag == 0: # action_
        v6 = (<UH2_0>v5).v0; v7 = (<UH2_0>v5).v1; v8 = (<UH2_0>v5).v2; v9 = (<UH2_0>v5).v3; v10 = (<UH2_0>v5).v4; v11 = (<UH2_0>v5).v5; v12 = (<UH2_0>v5).v6; v13 = (<UH2_0>v5).v7; v14 = (<UH2_0>v5).v8; v15 = (<UH2_0>v5).v9; v16 = (<UH2_0>v5).v10; v17 = (<UH2_0>v5).v11; v18 = (<UH2_0>v5).v12; v19 = (<UH2_0>v5).v13; v20 = (<UH2_0>v5).v14; v21 = (<UH2_0>v5).v15; v22 = (<UH2_0>v5).v16; v23 = (<UH2_0>v5).v17; v24 = (<UH2_0>v5).v18; v25 = (<UH2_0>v5).v19; v26 = (<UH2_0>v5).v20; v27 = (<UH2_0>v5).v21
        v28 = v2 == (<unsigned char>0)
        if v28:
            v29 = v8
        else:
            v29 = v11
        del v8; del v11
        v30 = method57(v29)
        del v29
        v31 = "\n".join(v30)
        del v30
        tmp58 = len(v26)
        if <signed short>tmp58 != tmp58: raise Exception("The conversion to signed short failed.")
        v32 = <signed short>tmp58
        v33 = Mut3((<signed short>0), (<signed short>0))
        while method62(v32, v33):
            v35 = v33.v0
            v36 = v33.v1
            v37 = v26[v35]
            if v37.tag == 0: # call
                v41 = v36
            elif v37.tag == 1: # fold
                v41 = v36
            elif v37.tag == 2: # raiseTo_
                v38 = (<US1_2>v37).v0
                v39 = v36 >= v38
                if v39:
                    v41 = v36
                else:
                    v41 = v38
            del v37
            v42 = v35 + (<signed short>1)
            v33.v0 = v42
            v33.v1 = v41
        v43 = v33.v1
        del v33
        v44 = Mut3((<signed short>0), v43)
        while method62(v32, v44):
            v46 = v44.v0
            v47 = v44.v1
            v48 = v26[v46]
            if v48.tag == 0: # call
                v52 = v47
            elif v48.tag == 1: # fold
                v52 = v47
            elif v48.tag == 2: # raiseTo_
                v49 = (<US1_2>v48).v0
                v50 = v47 < v49
                if v50:
                    v52 = v47
                else:
                    v52 = v49
            del v48
            v53 = v46 + (<signed short>1)
            v44.v0 = v53
            v44.v1 = v52
        del v26
        v54 = v44.v1
        del v44
        v55 = v54 == (<signed short>0)
        if v55:
            v58 = False
        else:
            v58 = Closure31(v0, v1, v2, v3, v27)
        v59 = Closure32(v0, v1, v2, v3, v27)
        v60 = Closure33(v0, v1, v2, v3, v27)
        del v27
        v61 = {'call': v59, 'fold': v60, 'raise_max': v43, 'raise_min': v54, 'raise_to': v58}
        del v58; del v59; del v60
        v62 = v2 == v16
        if v62:
            v63, v64, v65, v66, v67, v68, v69, v70 = v14, v15, v16, v17, v18, v19, v20, v21
        else:
            v63, v64, v65, v66, v67, v68, v69, v70 = v18, v19, v20, v21, v14, v15, v16, v17
        v71 = v3 - v66
        v72 = method63(v64, v63)
        v73 = v3 - v70
        v74 = method63(v68, v67)
        tmp59 = len(v22)
        if <signed short>tmp59 != tmp59: raise Exception("The conversion to signed short failed.")
        v75 = <signed short>tmp59
        v76 = [None]*v75
        v77 = Mut1((<signed short>0))
        while method7(v75, v77):
            v79 = v77.v0
            v80 = v22[v79]
            v81 = method61(v80)
            v76[v79] = v81
            del v81
            v82 = v79 + (<signed short>1)
            v77.v0 = v82
        del v22
        del v77
        v83 = "".join(v76)
        del v76
        v84 = {'community_card': v83, 'my_card': v72, 'my_pot': v66, 'my_stack': v71, 'op_card': v74, 'op_pot': v70, 'op_stack': v73}
        del v72; del v74; del v83
        v85 = {'actions': v61, 'table_data': v84, 'trace': v31}
        del v31; del v61; del v84
        v1(v85)
    elif v5.tag == 1: # terminal_
        v86 = (<UH2_1>v5).v0; v87 = (<UH2_1>v5).v1; v88 = (<UH2_1>v5).v2; v89 = (<UH2_1>v5).v3; v90 = (<UH2_1>v5).v4; v91 = (<UH2_1>v5).v5; v92 = (<UH2_1>v5).v6; v93 = (<UH2_1>v5).v7; v94 = (<UH2_1>v5).v8; v95 = (<UH2_1>v5).v9; v96 = (<UH2_1>v5).v10; v97 = (<UH2_1>v5).v11; v98 = (<UH2_1>v5).v12; v99 = (<UH2_1>v5).v13; v100 = (<UH2_1>v5).v14; v101 = (<UH2_1>v5).v15; v102 = (<UH2_1>v5).v16; v103 = (<UH2_1>v5).v17; v104 = (<UH2_1>v5).v18; v105 = (<UH2_1>v5).v19
        v106 = v2 == (<unsigned char>0)
        if v106:
            v107 = v88
        else:
            v107 = v91
        del v88; del v91
        v108 = method57(v107)
        del v107
        v109 = method64(v104, v102, v98, v99, v100, v101, v94, v95, v96, v97, v105, v108)
        del v108
        v110 = False
        v111 = False
        v112 = False
        v113 = {'call': v110, 'fold': v111, 'raise_max': (<signed short>0), 'raise_min': (<signed short>0), 'raise_to': v112}
        del v110; del v111; del v112
        if v106:
            v115 = v105
        else:
            v115 = -v105
        v116 = round(v115)
        v117 = v2 == v96
        if v117:
            v118, v119, v120, v121, v122, v123, v124, v125 = v94, v95, v96, v97, v98, v99, v100, v101
        else:
            v118, v119, v120, v121, v122, v123, v124, v125 = v98, v99, v100, v101, v94, v95, v96, v97
        v126 = v103 + v116
        v127 = method63(v119, v118)
        v128 = v103 - v116
        v129 = method63(v123, v122)
        tmp61 = len(v102)
        if <signed short>tmp61 != tmp61: raise Exception("The conversion to signed short failed.")
        v130 = <signed short>tmp61
        v131 = [None]*v130
        v132 = Mut1((<signed short>0))
        while method7(v130, v132):
            v134 = v132.v0
            v135 = v102[v134]
            v136 = method61(v135)
            v131[v134] = v136
            del v136
            v137 = v134 + (<signed short>1)
            v132.v0 = v137
        del v102
        del v132
        v138 = "".join(v131)
        del v131
        v139 = {'community_card': v138, 'my_card': v127, 'my_pot': (<signed short>0), 'my_stack': v126, 'op_card': v129, 'op_pot': (<signed short>0), 'op_stack': v128}
        del v127; del v129; del v138
        v140 = {'actions': v113, 'table_data': v139, 'trace': v109}
        del v109; del v113; del v139
        v1(v140)
cpdef object main():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    v0 = collections.namedtuple("Size",['action', 'policy', 'value'])((<signed short>10), (<signed short>310), (<signed short>344))
    v1 = Closure0()
    v2 = collections.namedtuple("Neural",['handler', 'size'])(v1, v0)
    del v0; del v1
    v3 = Closure4()
    v4 = Closure5()
    v5 = Closure27()
    v6 = {'neural': v2, 'uniform_player': v3, 'vs_one': v4, 'vs_self': v5}
    del v2; del v3; del v4; del v5
    v7 = Closure29()
    return {'train': v6, 'ui': v7}
