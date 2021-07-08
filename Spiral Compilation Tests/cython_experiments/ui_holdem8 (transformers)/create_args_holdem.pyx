import numpy
cimport numpy
import math
import collections
import torch
cimport libc.math
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
cdef class Tuple0:
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
cdef class Tuple1:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US1 v2
    def __init__(self, float v0, float v1, US1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure1():
    def __init__(self): pass
    def __call__(self, numpy.ndarray[float,ndim=1] v0):
        return v0
cdef class Tuple2:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure0():
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
        cdef Tuple0 tmp0
        cdef US1 v27
        cdef unsigned long long v28
        cdef object v29
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp0 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17, tmp0.v18, tmp0.v19, tmp0.v20
            del tmp0
            del v8; del v11; del v22; del v26
            v27 = US1_0()
            v2[v5] = Tuple1((<float>0), (<float>0), v27)
            del v27
            v28 = v5 + (<unsigned long long>1)
            v3.v0 = v28
        del v3
        v29 = Closure1()
        return Tuple2(v2, v29)
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
cdef class Tuple3:
    cdef readonly UH1 v0
    cdef readonly bint v1
    def __init__(self, UH1 v0, bint v1): self.v0 = v0; self.v1 = v1
cdef class Mut1:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Closure5():
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
        cdef Tuple0 tmp8
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
        cdef object v50
        cdef numpy.ndarray[float,ndim=1] v51
        cdef unsigned long long v52
        cdef unsigned long long v53
        cdef bint v54
        cdef bint v55
        cdef numpy.ndarray[float,ndim=1] v56
        cdef Mut0 v57
        cdef unsigned long long v59
        cdef float v60
        cdef float v61
        cdef float v62
        cdef UH0 v63
        cdef float v64
        cdef float v65
        cdef UH0 v66
        cdef float v67
        cdef float v68
        cdef signed char v69
        cdef signed char v70
        cdef unsigned char v71
        cdef signed short v72
        cdef signed char v73
        cdef signed char v74
        cdef unsigned char v75
        cdef signed short v76
        cdef numpy.ndarray[signed char,ndim=1] v77
        cdef signed short v78
        cdef bint v79
        cdef unsigned char v80
        cdef numpy.ndarray[object,ndim=1] v81
        cdef Tuple0 tmp9
        cdef bint v82
        cdef float v84
        cdef float v83
        cdef unsigned long long v85
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
            tmp8 = v0[v12]
            v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3, tmp8.v4, tmp8.v5, tmp8.v6, tmp8.v7, tmp8.v8, tmp8.v9, tmp8.v10, tmp8.v11, tmp8.v12, tmp8.v13, tmp8.v14, tmp8.v15, tmp8.v16, tmp8.v17, tmp8.v18, tmp8.v19, tmp8.v20
            del tmp8
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
        v50 = torch.from_numpy(v5)
        del v5
        v51 = v2(v50)
        del v50
        v52 = len(v51)
        v53 = len(v0)
        v54 = v52 == v53
        v55 = v54 == 0
        if v55:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v56 = numpy.empty(v52,dtype=numpy.float32)
        v57 = Mut0((<unsigned long long>0))
        while method0(v52, v57):
            v59 = v57.v0
            v60 = v51[v59]
            tmp9 = v0[v59]
            v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3, tmp9.v4, tmp9.v5, tmp9.v6, tmp9.v7, tmp9.v8, tmp9.v9, tmp9.v10, tmp9.v11, tmp9.v12, tmp9.v13, tmp9.v14, tmp9.v15, tmp9.v16, tmp9.v17, tmp9.v18, tmp9.v19, tmp9.v20
            del tmp9
            del v63; del v66; del v77; del v81
            v82 = v80 == (<unsigned char>0)
            if v82:
                v84 = v60
            else:
                v83 = -v60
                v84 = v83
            v56[v59] = v84
            v85 = v59 + (<unsigned long long>1)
            v57.v0 = v85
        del v51
        del v57
        return v56
cdef class Closure4():
    cdef signed short v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    cdef signed short v4
    cdef signed short v5
    cdef signed short v6
    cdef signed short v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef signed short v11
    cdef object v12
    def __init__(self, signed short v0, signed short v1, signed short v2, signed short v3, signed short v4, signed short v5, signed short v6, signed short v7, signed short v8, signed short v9, signed short v10, signed short v11, v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, list v13):
        cdef signed short v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed short v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed short v6 = self.v6
        cdef signed short v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef signed short v11 = self.v11
        cdef object v12 = self.v12
        cdef unsigned long long v14
        cdef bint v15
        cdef numpy.ndarray[object,ndim=1] v16
        cdef object v17
        cdef unsigned long long v18
        cdef numpy.ndarray[float,ndim=2] v19
        cdef numpy.ndarray[signed char,ndim=2] v20
        cdef unsigned long long v21
        cdef Mut0 v22
        cdef unsigned long long v24
        cdef float v25
        cdef float v26
        cdef UH0 v27
        cdef float v28
        cdef float v29
        cdef UH0 v30
        cdef float v31
        cdef float v32
        cdef signed char v33
        cdef signed char v34
        cdef unsigned char v35
        cdef signed short v36
        cdef signed char v37
        cdef signed char v38
        cdef unsigned char v39
        cdef signed short v40
        cdef numpy.ndarray[signed char,ndim=1] v41
        cdef signed short v42
        cdef bint v43
        cdef unsigned char v44
        cdef numpy.ndarray[object,ndim=1] v45
        cdef Tuple0 tmp1
        cdef bint v46
        cdef UH0 v47
        cdef UH1 v48
        cdef bint v49
        cdef UH1 v50
        cdef bint v51
        cdef Tuple3 tmp2
        cdef numpy.ndarray[object,ndim=1] v52
        cdef numpy.ndarray[float,ndim=1] v53
        cdef signed short v54
        cdef signed short v55
        cdef signed short v56
        cdef signed char v57
        cdef signed char v58
        cdef bint v59
        cdef bint v62
        cdef signed short v60
        cdef signed short v63
        cdef signed short v64
        cdef str v65
        cdef signed short v66
        cdef bint v67
        cdef bint v70
        cdef signed short v68
        cdef signed short v71
        cdef signed short v72
        cdef str v73
        cdef signed short v74
        cdef signed char v75
        cdef signed char v76
        cdef bint v77
        cdef bint v80
        cdef signed short v78
        cdef signed short v81
        cdef signed short v82
        cdef str v83
        cdef signed short v84
        cdef bint v85
        cdef bint v88
        cdef signed short v86
        cdef signed short v89
        cdef signed short v90
        cdef str v91
        cdef signed short v92
        cdef signed short v93
        cdef unsigned long long tmp3
        cdef bint v94
        cdef bint v95
        cdef signed short v96
        cdef Mut1 v97
        cdef signed short v99
        cdef signed char v100
        cdef signed short v101
        cdef signed short v102
        cdef signed char v103
        cdef signed char v104
        cdef bint v105
        cdef bint v108
        cdef signed short v106
        cdef signed short v109
        cdef signed short v110
        cdef str v111
        cdef signed short v112
        cdef bint v113
        cdef bint v116
        cdef signed short v114
        cdef signed short v117
        cdef signed short v118
        cdef str v119
        cdef signed short v120
        cdef signed short v121
        cdef unsigned long long tmp4
        cdef bint v122
        cdef bint v123
        cdef signed short v124
        cdef Mut1 v125
        cdef signed short v127
        cdef US2 v128
        cdef signed short v129
        cdef signed short v130
        cdef signed short v131
        cdef signed short v132
        cdef signed short v133
        cdef signed short v134
        cdef signed short v135
        cdef signed char v136
        cdef signed char v137
        cdef bint v138
        cdef bint v141
        cdef signed short v139
        cdef signed short v142
        cdef signed short v143
        cdef str v144
        cdef signed short v145
        cdef bint v146
        cdef bint v149
        cdef signed short v147
        cdef signed short v150
        cdef signed short v151
        cdef str v152
        cdef signed short v153
        cdef signed char v154
        cdef signed char v155
        cdef bint v156
        cdef bint v159
        cdef signed short v157
        cdef signed short v160
        cdef signed short v161
        cdef str v162
        cdef signed short v163
        cdef bint v164
        cdef bint v167
        cdef signed short v165
        cdef signed short v168
        cdef signed short v169
        cdef str v170
        cdef signed short v171
        cdef unsigned long long tmp5
        cdef Mut1 v172
        cdef signed short v174
        cdef US1 v175
        cdef signed short v184
        cdef signed short v176
        cdef signed short v177
        cdef bint v178
        cdef bint v180
        cdef bint v181
        cdef str v182
        cdef signed short v185
        cdef unsigned long long v186
        cdef object v187
        cdef object v188
        cdef object v189
        cdef object v190
        cdef numpy.ndarray[float,ndim=2] v191
        cdef float v192
        cdef numpy.ndarray[signed long long,ndim=1] v193
        cdef object v194
        cdef numpy.ndarray[object,ndim=1] v195
        cdef Mut0 v196
        cdef unsigned long long v198
        cdef signed long long v199
        cdef float v200
        cdef float v201
        cdef float v202
        cdef UH0 v203
        cdef float v204
        cdef float v205
        cdef UH0 v206
        cdef float v207
        cdef float v208
        cdef signed char v209
        cdef signed char v210
        cdef unsigned char v211
        cdef signed short v212
        cdef signed char v213
        cdef signed char v214
        cdef unsigned char v215
        cdef signed short v216
        cdef numpy.ndarray[signed char,ndim=1] v217
        cdef signed short v218
        cdef bint v219
        cdef unsigned char v220
        cdef numpy.ndarray[object,ndim=1] v221
        cdef Tuple0 tmp6
        cdef signed short v222
        cdef unsigned long long tmp7
        cdef float v223
        cdef float v224
        cdef float v225
        cdef float v226
        cdef float v227
        cdef float v228
        cdef float v229
        cdef signed short v230
        cdef bint v231
        cdef US1 v251
        cdef bint v232
        cdef bint v233
        cdef bint v235
        cdef signed short v236
        cdef bint v237
        cdef bint v238
        cdef bint v240
        cdef signed short v241
        cdef bint v242
        cdef bint v244
        cdef bint v245
        cdef signed short v246
        cdef unsigned long long v252
        cdef object v253
        v14 = len(v13)
        v15 = v14 == (<unsigned long long>0)
        if v15:
            v16 = numpy.empty((<unsigned long long>0),dtype=object)
            v17 = Closure1()
            return Tuple2(v16, v17)
        else:
            pass # import torch
            v18 = len(v13)
            v19 = numpy.zeros((v18,v11),dtype=numpy.float32)
            v20 = numpy.ones((v18,v1),dtype=numpy.int8)
            v21 = len(v13)
            v22 = Mut0((<unsigned long long>0))
            while method0(v21, v22):
                v24 = v22.v0
                tmp1 = v13[v24]
                v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4, tmp1.v5, tmp1.v6, tmp1.v7, tmp1.v8, tmp1.v9, tmp1.v10, tmp1.v11, tmp1.v12, tmp1.v13, tmp1.v14, tmp1.v15, tmp1.v16, tmp1.v17, tmp1.v18, tmp1.v19, tmp1.v20
                del tmp1
                v46 = v44 == (<unsigned char>0)
                if v46:
                    v47 = v27
                else:
                    v47 = v30
                del v27; del v30
                v48 = UH1_1()
                v49 = 0
                tmp2 = method1(v47, v48, v49)
                v50, v51 = tmp2.v0, tmp2.v1
                del tmp2
                del v47; del v48
                v52 = method2(v50)
                del v50
                v53 = v19[v24,:]
                v54 = (<signed short>0)
                method5(v2, v42, v53, v54)
                method7(v2, v36, v53)
                v55 = v2 + v2
                method5(v2, v40, v53, v55)
                v56 = v55 + v2
                v57 = v33 // (<signed char>13)
                v58 = v33 % (<signed char>13)
                v59 = (<signed char>0) <= v57
                if v59:
                    v60 = <signed short>v57
                    v62 = v60 < (<signed short>4)
                else:
                    v62 = 0
                if v62:
                    v63 = <signed short>v57
                    v64 = v56 + v63
                    v53[v64] = (<float>1)
                else:
                    v65 = f'Pickle failure. Int value out of bounds. Got: {v57} Size: {(<signed short>4)}'
                    raise Exception(v65)
                v66 = v56 + (<signed short>4)
                v67 = (<signed char>0) <= v58
                if v67:
                    v68 = <signed short>v58
                    v70 = v68 < (<signed short>13)
                else:
                    v70 = 0
                if v70:
                    v71 = <signed short>v58
                    v72 = v66 + v71
                    v53[v72] = (<float>1)
                else:
                    v73 = f'Pickle failure. Int value out of bounds. Got: {v58} Size: {(<signed short>13)}'
                    raise Exception(v73)
                v74 = v56 + (<signed short>17)
                v75 = v34 // (<signed char>13)
                v76 = v34 % (<signed char>13)
                v77 = (<signed char>0) <= v75
                if v77:
                    v78 = <signed short>v75
                    v80 = v78 < (<signed short>4)
                else:
                    v80 = 0
                if v80:
                    v81 = <signed short>v75
                    v82 = v74 + v81
                    v53[v82] = (<float>1)
                else:
                    v83 = f'Pickle failure. Int value out of bounds. Got: {v75} Size: {(<signed short>4)}'
                    raise Exception(v83)
                v84 = v74 + (<signed short>4)
                v85 = (<signed char>0) <= v76
                if v85:
                    v86 = <signed short>v76
                    v88 = v86 < (<signed short>13)
                else:
                    v88 = 0
                if v88:
                    v89 = <signed short>v76
                    v90 = v84 + v89
                    v53[v90] = (<float>1)
                else:
                    v91 = f'Pickle failure. Int value out of bounds. Got: {v76} Size: {(<signed short>13)}'
                    raise Exception(v91)
                v92 = v56 + (<signed short>34)
                tmp3 = len(v41)
                if <signed short>tmp3 != tmp3: raise Exception("The conversion to signed short failed.")
                v93 = <signed short>tmp3
                v94 = (<signed short>5) < v93
                if v94:
                    raise Exception("Pickle failure. The given array is too large.")
                else:
                    pass
                v95 = v93 == (<signed short>0)
                if v95:
                    v53[v92] = (<float>1)
                else:
                    pass
                v96 = v92 + (<signed short>1)
                v97 = Mut1((<signed short>0))
                while method9(v93, v97):
                    v99 = v97.v0
                    v100 = v41[v99]
                    v101 = v99 * (<signed short>17)
                    v102 = v96 + v101
                    v103 = v100 // (<signed char>13)
                    v104 = v100 % (<signed char>13)
                    v105 = (<signed char>0) <= v103
                    if v105:
                        v106 = <signed short>v103
                        v108 = v106 < (<signed short>4)
                    else:
                        v108 = 0
                    if v108:
                        v109 = <signed short>v103
                        v110 = v102 + v109
                        v53[v110] = (<float>1)
                    else:
                        v111 = f'Pickle failure. Int value out of bounds. Got: {v103} Size: {(<signed short>4)}'
                        raise Exception(v111)
                    v112 = v102 + (<signed short>4)
                    v113 = (<signed char>0) <= v104
                    if v113:
                        v114 = <signed short>v104
                        v116 = v114 < (<signed short>13)
                    else:
                        v116 = 0
                    if v116:
                        v117 = <signed short>v104
                        v118 = v112 + v117
                        v53[v118] = (<float>1)
                    else:
                        v119 = f'Pickle failure. Int value out of bounds. Got: {v104} Size: {(<signed short>13)}'
                        raise Exception(v119)
                    v120 = v99 + (<signed short>1)
                    v97.v0 = v120
                del v41
                del v97
                tmp4 = len(v52)
                if <signed short>tmp4 != tmp4: raise Exception("The conversion to signed short failed.")
                v121 = <signed short>tmp4
                v122 = v6 < v121
                if v122:
                    raise Exception("Pickle failure. The given array is too large.")
                else:
                    pass
                v123 = v121 == (<signed short>0)
                if v123:
                    v53[v5] = (<float>1)
                else:
                    pass
                v124 = v5 + (<signed short>1)
                v125 = Mut1((<signed short>0))
                while method9(v121, v125):
                    v127 = v125.v0
                    v128 = v52[v127]
                    v129 = v127 * v8
                    v130 = v124 + v129
                    if v128.tag == 0: # oCall
                        v53[v130] = (<float>1)
                    elif v128.tag == 1: # oFold
                        v131 = v130 + (<signed short>1)
                        v53[v131] = (<float>1)
                    elif v128.tag == 2: # oRaiseTo_
                        v132 = (<US2_2>v128).v0
                        v133 = v130 + (<signed short>2)
                        method5(v2, v132, v53, v133)
                    elif v128.tag == 3: # oStreetOver
                        v134 = v130 + v7
                        v53[v134] = (<float>1)
                    del v128
                    v135 = v127 + (<signed short>1)
                    v125.v0 = v135
                del v52
                del v125
                v136 = v37 // (<signed char>13)
                v137 = v37 % (<signed char>13)
                v138 = (<signed char>0) <= v136
                if v138:
                    v139 = <signed short>v136
                    v141 = v139 < (<signed short>4)
                else:
                    v141 = 0
                if v141:
                    v142 = <signed short>v136
                    v143 = v10 + v142
                    v53[v143] = (<float>1)
                else:
                    v144 = f'Pickle failure. Int value out of bounds. Got: {v136} Size: {(<signed short>4)}'
                    raise Exception(v144)
                v145 = v10 + (<signed short>4)
                v146 = (<signed char>0) <= v137
                if v146:
                    v147 = <signed short>v137
                    v149 = v147 < (<signed short>13)
                else:
                    v149 = 0
                if v149:
                    v150 = <signed short>v137
                    v151 = v145 + v150
                    v53[v151] = (<float>1)
                else:
                    v152 = f'Pickle failure. Int value out of bounds. Got: {v137} Size: {(<signed short>13)}'
                    raise Exception(v152)
                v153 = v10 + (<signed short>17)
                v154 = v38 // (<signed char>13)
                v155 = v38 % (<signed char>13)
                v156 = (<signed char>0) <= v154
                if v156:
                    v157 = <signed short>v154
                    v159 = v157 < (<signed short>4)
                else:
                    v159 = 0
                if v159:
                    v160 = <signed short>v154
                    v161 = v153 + v160
                    v53[v161] = (<float>1)
                else:
                    v162 = f'Pickle failure. Int value out of bounds. Got: {v154} Size: {(<signed short>4)}'
                    raise Exception(v162)
                v163 = v153 + (<signed short>4)
                v164 = (<signed char>0) <= v155
                if v164:
                    v165 = <signed short>v155
                    v167 = v165 < (<signed short>13)
                else:
                    v167 = 0
                if v167:
                    v168 = <signed short>v155
                    v169 = v163 + v168
                    v53[v169] = (<float>1)
                else:
                    v170 = f'Pickle failure. Int value out of bounds. Got: {v155} Size: {(<signed short>13)}'
                    raise Exception(v170)
                del v53
                tmp5 = len(v45)
                if <signed short>tmp5 != tmp5: raise Exception("The conversion to signed short failed.")
                v171 = <signed short>tmp5
                v172 = Mut1((<signed short>0))
                while method9(v171, v172):
                    v174 = v172.v0
                    v175 = v45[v174]
                    if v175.tag == 0: # call
                        v184 = (<signed short>0)
                    elif v175.tag == 1: # fold
                        v184 = (<signed short>1)
                    elif v175.tag == 2: # raiseTo_
                        v176 = (<US1_2>v175).v0
                        v177 = (<signed short>-2) + v176
                        v178 = (<signed short>0) <= v177
                        if v178:
                            v180 = v177 < v0
                        else:
                            v180 = 0
                        v181 = v180 == 0
                        if v181:
                            v182 = f'Pickle failure. Int value out of bounds. Got: {v177} Size: {v0}'
                            raise Exception(v182)
                        else:
                            pass
                        v184 = (<signed short>2) + v177
                    del v175
                    v20[v24,v184] = 0
                    v185 = v174 + (<signed short>1)
                    v172.v0 = v185
                del v45
                del v172
                v186 = v24 + (<unsigned long long>1)
                v22.v0 = v186
            del v22
            v187 = torch.from_numpy(v19)
            del v19
            v188 = v20.view('bool')
            del v20
            v189 = torch.from_numpy(v188)
            del v188
            v190 = v12(v10, v187, v189)
            del v187; del v189
            v191 = v190[0]
            v192 = v190[1]
            v193 = v190[2]
            v194 = v190[3]
            del v190
            v195 = numpy.empty(v18,dtype=object)
            v196 = Mut0((<unsigned long long>0))
            while method0(v18, v196):
                v198 = v196.v0
                v199 = v193[v198]
                v200 = v191[v198,v199]
                tmp6 = v13[v198]
                v201, v202, v203, v204, v205, v206, v207, v208, v209, v210, v211, v212, v213, v214, v215, v216, v217, v218, v219, v220, v221 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4, tmp6.v5, tmp6.v6, tmp6.v7, tmp6.v8, tmp6.v9, tmp6.v10, tmp6.v11, tmp6.v12, tmp6.v13, tmp6.v14, tmp6.v15, tmp6.v16, tmp6.v17, tmp6.v18, tmp6.v19, tmp6.v20
                del tmp6
                del v203; del v206; del v217
                tmp7 = len(v221)
                if <signed short>tmp7 != tmp7: raise Exception("The conversion to signed short failed.")
                v222 = <signed short>tmp7
                del v221
                v223 = <float>v222
                v224 = v192 / v223
                v225 = (<float>1) - v192
                v226 = v225 * v200
                v227 = v224 + v226
                v228 = libc.math.log(v227)
                v229 = libc.math.log(v200)
                v230 = <signed short>v199
                v231 = v230 < (<signed short>1)
                if v231:
                    v232 = v230 == (<signed short>0)
                    v233 = v232 == 0
                    if v233:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v251 = US1_0()
                else:
                    v235 = v230 < (<signed short>2)
                    if v235:
                        v236 = v230 - (<signed short>1)
                        v237 = v236 == (<signed short>0)
                        v238 = v237 == 0
                        if v238:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v251 = US1_1()
                    else:
                        v240 = v230 < v1
                        if v240:
                            v241 = v230 - (<signed short>2)
                            v242 = (<signed short>0) <= v241
                            if v242:
                                v244 = v241 < v0
                            else:
                                v244 = 0
                            v245 = v244 == 0
                            if v245:
                                raise Exception("Unpickle failure. The index should be less than size.")
                            else:
                                pass
                            v246 = (<signed short>2) + v241
                            v251 = US1_2(v246)
                        else:
                            raise Exception("Unpickle failure. Unpickling of an union failed.")
                v195[v198] = Tuple1(v229, v228, v251)
                del v251
                v252 = v198 + (<unsigned long long>1)
                v196.v0 = v252
            del v191; del v193
            del v196
            v253 = Closure5(v13, v18, v194)
            del v194
            return Tuple2(v195, v253)
cdef class Closure3():
    cdef signed short v0
    cdef signed short v1
    cdef signed short v2
    cdef signed short v3
    cdef signed short v4
    cdef signed short v5
    cdef signed short v6
    cdef signed short v7
    cdef signed short v8
    cdef signed short v9
    cdef signed short v10
    cdef signed short v11
    def __init__(self, signed short v0, signed short v1, signed short v2, signed short v3, signed short v4, signed short v5, signed short v6, signed short v7, signed short v8, signed short v9, signed short v10, signed short v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, v12):
        cdef signed short v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed short v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed short v6 = self.v6
        cdef signed short v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef signed short v11 = self.v11
        return Closure4(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12)
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, signed short v0, signed short v1):
        cdef signed short v2
        cdef signed short v3
        cdef bint v4
        cdef signed short v5
        cdef signed short v6
        cdef signed short v7
        cdef signed short v8
        cdef signed short v9
        cdef signed short v10
        cdef signed short v11
        cdef signed short v12
        cdef bint v13
        cdef bint v15
        cdef bint v16
        cdef signed short v17
        cdef signed short v18
        cdef signed short v19
        cdef signed short v20
        cdef signed short v21
        cdef signed short v22
        cdef signed short v23
        cdef signed short v24
        cdef signed short v25
        cdef signed short v26
        cdef signed short v27
        cdef object v28
        cdef object v29
        v2 = v1 // v0
        v3 = v1 % v0
        v4 = v3 == (<signed short>0)
        if v4:
            v5 = (<signed short>0)
        else:
            v5 = (<signed short>1)
        v6 = v2 + v5
        v7 = v6 - (<signed short>1)
        v8 = v7 + (<signed short>3)
        v9 = v8 + (<signed short>4)
        v10 = v9 + (<signed short>4)
        v11 = v1 + (<signed short>1)
        pass # import math
        v12 = math.ceil(math.log2(v11))
        v13 = (<signed short>1) <= v12
        if v13:
            v15 = v12 <= (<signed short>64)
        else:
            v15 = 0
        v16 = v15 == 0
        if v16:
            raise Exception("The field size has to be in the [1,64] range.")
        else:
            pass
        v17 = (<signed short>2) + v12
        v18 = v17 + (<signed short>1)
        v19 = v12 + (<signed short>120)
        v20 = v12 + v19
        v21 = v12 + v20
        v22 = v10 * v18
        v23 = v22 + (<signed short>1)
        v24 = v21 + v23
        v25 = v24 + (<signed short>34)
        v26 = v11 - (<signed short>1)
        v27 = (<signed short>2) + v26
        v28 = collections.namedtuple("Size",['action', 'policy', 'value'])(v27, v24, v25)
        v29 = Closure3(v26, v27, v12, v19, v20, v21, v10, v17, v18, v23, v24, v25)
        return collections.namedtuple("Neural",['handler', 'size'])(v29, v28)
cdef class Closure6():
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
        cdef Tuple0 tmp10
        cdef signed short v27
        cdef unsigned long long tmp11
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
            tmp10 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3, tmp10.v4, tmp10.v5, tmp10.v6, tmp10.v7, tmp10.v8, tmp10.v9, tmp10.v10, tmp10.v11, tmp10.v12, tmp10.v13, tmp10.v14, tmp10.v15, tmp10.v16, tmp10.v17, tmp10.v18, tmp10.v19, tmp10.v20
            del tmp10
            del v8; del v11; del v22
            tmp11 = len(v26)
            if <signed short>tmp11 != tmp11: raise Exception("The conversion to signed short failed.")
            v27 = <signed short>tmp11
            v28 = <float>v27
            v29 = (<float>1) / v28
            v30 = libc.math.log(v29)
            v31 = numpy.random.choice(v26)
            del v26
            v2[v5] = Tuple1(v30, v30, v31)
            del v31
            v32 = v5 + (<unsigned long long>1)
            v3.v0 = v32
        del v3
        v33 = Closure1()
        return Tuple2(v2, v33)
cdef class Tuple4:
    cdef readonly signed char v0
    cdef readonly signed char v1
    cdef readonly signed char v2
    cdef readonly signed char v3
    cdef readonly signed char v4
    cdef readonly signed char v5
    def __init__(self, signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
cdef class Mut2:
    cdef public signed short v0
    cdef public unsigned long long v1
    def __init__(self, signed short v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
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
cdef class Mut3:
    cdef public signed short v0
    cdef public signed short v1
    def __init__(self, signed short v0, signed short v1): self.v0 = v0; self.v1 = v1
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
    cdef signed short v9
    cdef unsigned char v10
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
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18, float v19, float v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
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
        cdef unsigned char v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
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
            return method38(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_0(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_0(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method38(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
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
    cdef signed short v11
    cdef unsigned char v12
    cdef object v13
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed short v11, unsigned char v12, numpy.ndarray[object,ndim=1] v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
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
        cdef signed short v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef numpy.ndarray[object,ndim=1] v13 = self.v13
        cdef object v22
        v22 = Closure14(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v12, v13, v7, v19, v20, v21, v16, v17, v18, v14, v15)
        return UH2_0(v14, v15, v16, v17, v18, v19, v20, v21, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v22)
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
    cdef signed short v10
    cdef unsigned char v11
    cdef object v12
    cdef object v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19, float v20, float v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, float v22, float v23, US1 v24):
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
        cdef signed short v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef bint v25
        cdef float v26
        cdef float v27
        cdef US0 v28
        cdef UH0 v29
        cdef US0 v30
        cdef UH0 v31
        cdef float v33
        cdef float v34
        cdef US0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef UH0 v38
        v25 = v0 == (<unsigned char>0)
        if v25:
            v26 = v23 + v19
            v27 = v22 + v18
            v28 = US0_0(v24)
            v29 = UH0_0(v28, v17)
            del v28
            v30 = US0_0(v24)
            v31 = UH0_0(v30, v14)
            del v30
            return method35(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v29, v27, v26, v31, v15, v16)
        else:
            v33 = v23 + v16
            v34 = v22 + v15
            v35 = US0_0(v24)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = US0_0(v24)
            v38 = UH0_0(v37, v14)
            del v37
            return method35(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v36, v18, v19, v38, v34, v33)
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
    cdef signed short v12
    cdef unsigned char v13
    cdef object v14
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, signed short v12, unsigned char v13, numpy.ndarray[object,ndim=1] v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
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
        cdef signed short v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef numpy.ndarray[object,ndim=1] v14 = self.v14
        cdef object v23
        v23 = Closure12(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v13, v14, v8, v20, v21, v22, v17, v18, v19, v15, v16)
        return UH2_0(v15, v16, v17, v18, v19, v20, v21, v22, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v23)
cdef class Closure9():
    cdef object v0
    cdef signed short v1
    cdef signed short v2
    cdef unsigned char v3
    cdef object v4
    cdef signed char v5
    cdef signed char v6
    cdef signed short v7
    cdef signed char v8
    cdef signed char v9
    cdef signed short v10
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, signed short v2, unsigned char v3, numpy.ndarray[object,ndim=1] v4, signed char v5, signed char v6, signed short v7, signed char v8, signed char v9, signed short v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, UH0 v13, float v14, float v15, UH0 v16, float v17, float v18):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef signed char v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed short v10 = self.v10
        cdef signed char v19
        cdef signed short v20
        cdef unsigned long long tmp16
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef float v25
        cdef numpy.ndarray[signed char,ndim=1] v26
        cdef signed char v27
        cdef signed short v28
        cdef unsigned long long tmp17
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef float v33
        cdef numpy.ndarray[signed char,ndim=1] v34
        cdef signed char v35
        cdef signed short v36
        cdef unsigned long long tmp18
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef numpy.ndarray[signed char,ndim=1] v42
        cdef numpy.ndarray[signed char,ndim=1] v43
        cdef bint v44
        cdef unsigned char v45
        cdef unsigned char v46
        cdef object v47
        cdef US0 v48
        cdef US0 v49
        cdef US0 v50
        cdef UH0 v51
        cdef UH0 v52
        cdef UH0 v53
        cdef US0 v54
        cdef US0 v55
        cdef US0 v56
        cdef UH0 v57
        cdef UH0 v58
        cdef UH0 v59
        v19 = v0[(<signed short>0)]
        tmp16 = len(v0)
        if <signed short>tmp16 != tmp16: raise Exception("The conversion to signed short failed.")
        v20 = <signed short>tmp16
        v21 = <float>v20
        v22 = (<float>1) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v12
        v25 = v23 + v11
        v26 = v0[1:]
        v27 = v26[(<signed short>0)]
        tmp17 = len(v26)
        if <signed short>tmp17 != tmp17: raise Exception("The conversion to signed short failed.")
        v28 = <signed short>tmp17
        v29 = <float>v28
        v30 = (<float>1) / v29
        v31 = libc.math.log(v30)
        v32 = v31 + v24
        v33 = v31 + v25
        v34 = v26[1:]
        del v26
        v35 = v34[(<signed short>0)]
        tmp18 = len(v34)
        if <signed short>tmp18 != tmp18: raise Exception("The conversion to signed short failed.")
        v36 = <signed short>tmp18
        v37 = <float>v36
        v38 = (<float>1) / v37
        v39 = libc.math.log(v38)
        v40 = v39 + v32
        v41 = v39 + v33
        v42 = v34[1:]
        del v34; del v42
        v43 = numpy.empty(3,dtype=numpy.int8)
        v43[0] = v19; v43[1] = v27; v43[2] = v35
        v44 = 1
        v45 = (<unsigned char>0)
        v46 = (<unsigned char>1)
        v47 = method10(v1, v2, v3, v4, v44, v8, v9, v46, v10, v5, v6, v45, v7, v43)
        del v43
        v48 = US0_1(v35)
        v49 = US0_1(v27)
        v50 = US0_1(v19)
        v51 = UH0_0(v50, v13)
        del v50
        v52 = UH0_0(v49, v51)
        del v49; del v51
        v53 = UH0_0(v48, v52)
        del v48; del v52
        v54 = US0_1(v35)
        v55 = US0_1(v27)
        v56 = US0_1(v19)
        v57 = UH0_0(v56, v16)
        del v56
        v58 = UH0_0(v55, v57)
        del v55; del v57
        v59 = UH0_0(v54, v58)
        del v54; del v58
        return v47(v41, v40, v53, v14, v15, v59, v17, v18)
cdef class Closure17():
    cdef object v0
    cdef signed short v1
    cdef signed short v2
    cdef unsigned char v3
    cdef object v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed char v10
    cdef unsigned char v11
    cdef signed short v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, signed short v2, unsigned char v3, numpy.ndarray[object,ndim=1] v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9, signed char v10, unsigned char v11, signed short v12, signed char v13, signed char v14, unsigned char v15, signed short v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed char v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed char v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed short v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed short v16 = self.v16
        cdef signed char v25
        cdef signed short v26
        cdef unsigned long long tmp46
        cdef float v27
        cdef float v28
        cdef float v29
        cdef float v30
        cdef float v31
        cdef numpy.ndarray[signed char,ndim=1] v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef bint v34
        cdef object v35
        cdef US0 v36
        cdef UH0 v37
        cdef US0 v38
        cdef UH0 v39
        v25 = v0[(<signed short>0)]
        tmp46 = len(v0)
        if <signed short>tmp46 != tmp46: raise Exception("The conversion to signed short failed.")
        v26 = <signed short>tmp46
        v27 = <float>v26
        v28 = (<float>1) / v27
        v29 = libc.math.log(v28)
        v30 = v29 + v18
        v31 = v29 + v17
        v32 = v0[1:]
        del v32
        v33 = numpy.empty(5,dtype=numpy.int8)
        v33[0] = v5; v33[1] = v6; v33[2] = v7; v33[3] = v8; v33[4] = v25
        v34 = 1
        v35 = method10(v1, v2, v3, v4, v34, v9, v10, v11, v12, v13, v14, v15, v16, v33)
        del v33
        v36 = US0_1(v25)
        v37 = UH0_0(v36, v19)
        del v36
        v38 = US0_1(v25)
        v39 = UH0_0(v38, v22)
        del v38
        return v35(v31, v30, v37, v20, v21, v39, v23, v24)
cdef class Closure21():
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
    cdef unsigned char v10
    cdef object v11
    cdef object v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef object v16
    cdef signed char v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef UH0 v21
    cdef float v22
    cdef float v23
    cdef float v24
    cdef float v25
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23, float v24, float v25): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24; self.v25 = v25
    def __call__(self, float v26, float v27, US1 v28):
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
        cdef unsigned char v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef numpy.ndarray[signed char,ndim=1] v16 = self.v16
        cdef signed char v17 = self.v17
        cdef UH0 v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef UH0 v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef float v25 = self.v25
        cdef bint v29
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef UH0 v33
        cdef US0 v34
        cdef UH0 v35
        cdef float v37
        cdef float v38
        cdef US0 v39
        cdef UH0 v40
        cdef US0 v41
        cdef UH0 v42
        v29 = v0 == (<unsigned char>0)
        if v29:
            v30 = v27 + v23
            v31 = v26 + v22
            v32 = US0_0(v28)
            v33 = UH0_0(v32, v21)
            del v32
            v34 = US0_0(v28)
            v35 = UH0_0(v34, v18)
            del v34
            return method48(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v28, v24, v25, v33, v31, v30, v35, v19, v20)
        else:
            v37 = v27 + v20
            v38 = v26 + v19
            v39 = US0_0(v28)
            v40 = UH0_0(v39, v21)
            del v39
            v41 = US0_0(v28)
            v42 = UH0_0(v41, v18)
            del v41
            return method48(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v28, v24, v25, v40, v22, v23, v42, v38, v37)
cdef class Closure20():
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
    cdef signed short v11
    cdef unsigned char v12
    cdef object v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef object v17
    cdef signed char v18
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed short v11, unsigned char v12, numpy.ndarray[object,ndim=1] v13, signed char v14, signed char v15, signed char v16, numpy.ndarray[signed char,ndim=1] v17, signed char v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, float v19, float v20, UH0 v21, float v22, float v23, UH0 v24, float v25, float v26):
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
        cdef signed short v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef numpy.ndarray[object,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef numpy.ndarray[signed char,ndim=1] v17 = self.v17
        cdef signed char v18 = self.v18
        cdef object v27
        v27 = Closure21(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v12, v13, v7, v14, v15, v16, v17, v18, v24, v25, v26, v21, v22, v23, v19, v20)
        return UH2_0(v19, v20, v21, v22, v23, v24, v25, v26, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v27)
cdef class Closure19():
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
    cdef signed short v10
    cdef unsigned char v11
    cdef object v12
    cdef object v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    cdef object v17
    cdef signed char v18
    cdef UH0 v19
    cdef float v20
    cdef float v21
    cdef UH0 v22
    cdef float v23
    cdef float v24
    cdef float v25
    cdef float v26
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, signed char v15, signed char v16, numpy.ndarray[signed char,ndim=1] v17, signed char v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24, float v25, float v26): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24; self.v25 = v25; self.v26 = v26
    def __call__(self, float v27, float v28, US1 v29):
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
        cdef signed short v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef numpy.ndarray[signed char,ndim=1] v17 = self.v17
        cdef signed char v18 = self.v18
        cdef UH0 v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef UH0 v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef float v25 = self.v25
        cdef float v26 = self.v26
        cdef bint v30
        cdef float v31
        cdef float v32
        cdef US0 v33
        cdef UH0 v34
        cdef US0 v35
        cdef UH0 v36
        cdef float v38
        cdef float v39
        cdef US0 v40
        cdef UH0 v41
        cdef US0 v42
        cdef UH0 v43
        v30 = v0 == (<unsigned char>0)
        if v30:
            v31 = v28 + v24
            v32 = v27 + v23
            v33 = US0_0(v29)
            v34 = UH0_0(v33, v22)
            del v33
            v35 = US0_0(v29)
            v36 = UH0_0(v35, v19)
            del v35
            return method45(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v29, v25, v26, v34, v32, v31, v36, v20, v21)
        else:
            v38 = v28 + v21
            v39 = v27 + v20
            v40 = US0_0(v29)
            v41 = UH0_0(v40, v22)
            del v40
            v42 = US0_0(v29)
            v43 = UH0_0(v42, v19)
            del v42
            return method45(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v29, v25, v26, v41, v23, v24, v43, v39, v38)
cdef class Closure18():
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
    cdef signed short v12
    cdef unsigned char v13
    cdef object v14
    cdef signed char v15
    cdef signed char v16
    cdef signed char v17
    cdef object v18
    cdef signed char v19
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, signed short v12, unsigned char v13, numpy.ndarray[object,ndim=1] v14, signed char v15, signed char v16, signed char v17, numpy.ndarray[signed char,ndim=1] v18, signed char v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, float v20, float v21, UH0 v22, float v23, float v24, UH0 v25, float v26, float v27):
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
        cdef signed short v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef numpy.ndarray[object,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef signed char v17 = self.v17
        cdef numpy.ndarray[signed char,ndim=1] v18 = self.v18
        cdef signed char v19 = self.v19
        cdef object v28
        v28 = Closure19(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v13, v14, v8, v15, v16, v17, v18, v19, v25, v26, v27, v22, v23, v24, v20, v21)
        return UH2_0(v20, v21, v22, v23, v24, v25, v26, v27, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v28)
cdef class Closure16():
    cdef object v0
    cdef signed short v1
    cdef signed short v2
    cdef unsigned char v3
    cdef object v4
    cdef signed char v5
    cdef signed char v6
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef unsigned char v10
    cdef signed short v11
    cdef signed char v12
    cdef signed char v13
    cdef unsigned char v14
    cdef signed short v15
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, signed short v2, unsigned char v3, numpy.ndarray[object,ndim=1] v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef signed char v8 = self.v8
        cdef signed char v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed short v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed short v15 = self.v15
        cdef signed char v24
        cdef signed short v25
        cdef unsigned long long tmp45
        cdef float v26
        cdef float v27
        cdef float v28
        cdef float v29
        cdef float v30
        cdef numpy.ndarray[signed char,ndim=1] v31
        cdef bint v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef object v34
        cdef US0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef UH0 v38
        v24 = v0[(<signed short>0)]
        tmp45 = len(v0)
        if <signed short>tmp45 != tmp45: raise Exception("The conversion to signed short failed.")
        v25 = <signed short>tmp45
        v26 = <float>v25
        v27 = (<float>1) / v26
        v28 = libc.math.log(v27)
        v29 = v28 + v17
        v30 = v28 + v16
        v31 = v0[1:]
        v32 = 1
        v33 = numpy.empty(4,dtype=numpy.int8)
        v33[0] = v5; v33[1] = v6; v33[2] = v7; v33[3] = v24
        v34 = method43(v1, v2, v3, v4, v32, v8, v9, v10, v11, v12, v13, v14, v15, v33, v5, v6, v7, v31, v24)
        del v31; del v33
        v35 = US0_1(v24)
        v36 = UH0_0(v35, v18)
        del v35
        v37 = US0_1(v24)
        v38 = UH0_0(v37, v21)
        del v37
        return v34(v30, v29, v36, v19, v20, v38, v22, v23)
cdef class Closure25():
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
    cdef unsigned char v10
    cdef object v11
    cdef object v12
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
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22, float v23, float v24): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24
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
        cdef unsigned char v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
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
            return method52(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method52(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure24():
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
    cdef signed short v11
    cdef unsigned char v12
    cdef object v13
    cdef signed char v14
    cdef signed char v15
    cdef object v16
    cdef signed char v17
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed short v11, unsigned char v12, numpy.ndarray[object,ndim=1] v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
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
        cdef signed short v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef numpy.ndarray[object,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef numpy.ndarray[signed char,ndim=1] v16 = self.v16
        cdef signed char v17 = self.v17
        cdef object v26
        v26 = Closure25(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v12, v13, v7, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH2_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v26)
cdef class Closure23():
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
    cdef signed short v10
    cdef unsigned char v11
    cdef object v12
    cdef object v13
    cdef signed char v14
    cdef signed char v15
    cdef object v16
    cdef signed char v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef UH0 v21
    cdef float v22
    cdef float v23
    cdef float v24
    cdef float v25
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23, float v24, float v25): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24; self.v25 = v25
    def __call__(self, float v26, float v27, US1 v28):
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
        cdef signed short v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef numpy.ndarray[signed char,ndim=1] v16 = self.v16
        cdef signed char v17 = self.v17
        cdef UH0 v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef UH0 v21 = self.v21
        cdef float v22 = self.v22
        cdef float v23 = self.v23
        cdef float v24 = self.v24
        cdef float v25 = self.v25
        cdef bint v29
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef UH0 v33
        cdef US0 v34
        cdef UH0 v35
        cdef float v37
        cdef float v38
        cdef US0 v39
        cdef UH0 v40
        cdef US0 v41
        cdef UH0 v42
        v29 = v0 == (<unsigned char>0)
        if v29:
            v30 = v27 + v23
            v31 = v26 + v22
            v32 = US0_0(v28)
            v33 = UH0_0(v32, v21)
            del v32
            v34 = US0_0(v28)
            v35 = UH0_0(v34, v18)
            del v34
            return method49(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v28, v24, v25, v33, v31, v30, v35, v19, v20)
        else:
            v37 = v27 + v20
            v38 = v26 + v19
            v39 = US0_0(v28)
            v40 = UH0_0(v39, v21)
            del v39
            v41 = US0_0(v28)
            v42 = UH0_0(v41, v18)
            del v41
            return method49(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v28, v24, v25, v40, v22, v23, v42, v38, v37)
cdef class Closure22():
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
    cdef signed short v12
    cdef unsigned char v13
    cdef object v14
    cdef signed char v15
    cdef signed char v16
    cdef object v17
    cdef signed char v18
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, signed short v12, unsigned char v13, numpy.ndarray[object,ndim=1] v14, signed char v15, signed char v16, numpy.ndarray[signed char,ndim=1] v17, signed char v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, float v19, float v20, UH0 v21, float v22, float v23, UH0 v24, float v25, float v26):
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
        cdef signed short v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef numpy.ndarray[object,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef numpy.ndarray[signed char,ndim=1] v17 = self.v17
        cdef signed char v18 = self.v18
        cdef object v27
        v27 = Closure23(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v13, v14, v8, v15, v16, v17, v18, v24, v25, v26, v21, v22, v23, v19, v20)
        return UH2_0(v19, v20, v21, v22, v23, v24, v25, v26, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v27)
cdef class Closure15():
    cdef object v0
    cdef signed short v1
    cdef signed short v2
    cdef unsigned char v3
    cdef object v4
    cdef signed char v5
    cdef signed char v6
    cdef unsigned char v7
    cdef signed short v8
    cdef signed char v9
    cdef signed char v10
    cdef unsigned char v11
    cdef signed short v12
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, signed short v1, signed short v2, unsigned char v3, numpy.ndarray[object,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed char v5 = self.v5
        cdef signed char v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed short v8 = self.v8
        cdef signed char v9 = self.v9
        cdef signed char v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef signed short v12 = self.v12
        cdef signed char v21
        cdef signed short v22
        cdef unsigned long long tmp42
        cdef float v23
        cdef float v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef numpy.ndarray[signed char,ndim=1] v28
        cdef signed char v29
        cdef signed short v30
        cdef unsigned long long tmp43
        cdef float v31
        cdef float v32
        cdef float v33
        cdef float v34
        cdef float v35
        cdef numpy.ndarray[signed char,ndim=1] v36
        cdef signed char v37
        cdef signed short v38
        cdef unsigned long long tmp44
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef numpy.ndarray[signed char,ndim=1] v44
        cdef bint v45
        cdef numpy.ndarray[signed char,ndim=1] v46
        cdef object v47
        cdef US0 v48
        cdef US0 v49
        cdef US0 v50
        cdef UH0 v51
        cdef UH0 v52
        cdef UH0 v53
        cdef US0 v54
        cdef US0 v55
        cdef US0 v56
        cdef UH0 v57
        cdef UH0 v58
        cdef UH0 v59
        v21 = v0[(<signed short>0)]
        tmp42 = len(v0)
        if <signed short>tmp42 != tmp42: raise Exception("The conversion to signed short failed.")
        v22 = <signed short>tmp42
        v23 = <float>v22
        v24 = (<float>1) / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v14
        v27 = v25 + v13
        v28 = v0[1:]
        v29 = v28[(<signed short>0)]
        tmp43 = len(v28)
        if <signed short>tmp43 != tmp43: raise Exception("The conversion to signed short failed.")
        v30 = <signed short>tmp43
        v31 = <float>v30
        v32 = (<float>1) / v31
        v33 = libc.math.log(v32)
        v34 = v33 + v26
        v35 = v33 + v27
        v36 = v28[1:]
        del v28
        v37 = v36[(<signed short>0)]
        tmp44 = len(v36)
        if <signed short>tmp44 != tmp44: raise Exception("The conversion to signed short failed.")
        v38 = <signed short>tmp44
        v39 = <float>v38
        v40 = (<float>1) / v39
        v41 = libc.math.log(v40)
        v42 = v41 + v34
        v43 = v41 + v35
        v44 = v36[1:]
        del v36
        v45 = 1
        v46 = numpy.empty(3,dtype=numpy.int8)
        v46[0] = v21; v46[1] = v29; v46[2] = v37
        v47 = method41(v1, v2, v3, v4, v45, v5, v6, v7, v8, v9, v10, v11, v12, v46, v21, v29, v44, v37)
        del v44; del v46
        v48 = US0_1(v37)
        v49 = US0_1(v29)
        v50 = US0_1(v21)
        v51 = UH0_0(v50, v15)
        del v50
        v52 = UH0_0(v49, v51)
        del v49; del v51
        v53 = UH0_0(v48, v52)
        del v48; del v52
        v54 = US0_1(v37)
        v55 = US0_1(v29)
        v56 = US0_1(v21)
        v57 = UH0_0(v56, v18)
        del v56
        v58 = UH0_0(v55, v57)
        del v55; del v57
        v59 = UH0_0(v54, v58)
        del v54; del v58
        return v47(v43, v42, v53, v16, v17, v59, v19, v20)
cdef class Closure29():
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
    cdef unsigned char v10
    cdef object v11
    cdef object v12
    cdef object v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19, float v20, float v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, float v22, float v23, US1 v24):
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
        cdef unsigned char v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef float v18 = self.v18
        cdef float v19 = self.v19
        cdef float v20 = self.v20
        cdef float v21 = self.v21
        cdef bint v25
        cdef float v26
        cdef float v27
        cdef US0 v28
        cdef UH0 v29
        cdef US0 v30
        cdef UH0 v31
        cdef float v33
        cdef float v34
        cdef US0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef UH0 v38
        v25 = v0 == (<unsigned char>0)
        if v25:
            v26 = v23 + v19
            v27 = v22 + v18
            v28 = US0_0(v24)
            v29 = UH0_0(v28, v17)
            del v28
            v30 = US0_0(v24)
            v31 = UH0_0(v30, v14)
            del v30
            return method56(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v29, v27, v26, v31, v15, v16)
        else:
            v33 = v23 + v16
            v34 = v22 + v15
            v35 = US0_0(v24)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = US0_0(v24)
            v38 = UH0_0(v37, v14)
            del v37
            return method56(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v36, v18, v19, v38, v34, v33)
cdef class Closure28():
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
    cdef signed short v11
    cdef unsigned char v12
    cdef object v13
    cdef object v14
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, signed short v8, numpy.ndarray[object,ndim=1] v9, bint v10, signed short v11, unsigned char v12, numpy.ndarray[object,ndim=1] v13, numpy.ndarray[signed char,ndim=1] v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
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
        cdef signed short v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef numpy.ndarray[object,ndim=1] v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef object v23
        v23 = Closure29(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v12, v13, v7, v14, v20, v21, v22, v17, v18, v19, v15, v16)
        return UH2_0(v15, v16, v17, v18, v19, v20, v21, v22, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v23)
cdef class Closure27():
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
    cdef signed short v10
    cdef unsigned char v11
    cdef object v12
    cdef object v13
    cdef object v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef float v22
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, numpy.ndarray[signed char,ndim=1] v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
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
        cdef signed short v9 = self.v9
        cdef signed short v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef numpy.ndarray[object,ndim=1] v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
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
            return method53(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US0_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US0_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method53(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
cdef class Closure26():
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
    cdef signed short v12
    cdef unsigned char v13
    cdef object v14
    cdef object v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, signed short v9, numpy.ndarray[object,ndim=1] v10, bint v11, signed short v12, unsigned char v13, numpy.ndarray[object,ndim=1] v14, numpy.ndarray[signed char,ndim=1] v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
        cdef signed short v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef numpy.ndarray[object,ndim=1] v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef object v24
        v24 = Closure27(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v13, v14, v8, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH2_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v24)
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
cdef class Mut4:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure8():
    cdef signed short v0
    cdef signed short v1
    cdef signed short v2
    cdef bint v3
    cdef unsigned char v4
    def __init__(self, signed short v0, signed short v1, signed short v2, bint v3, unsigned char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, unsigned long long v5, v6, v7):
        cdef signed short v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef bint v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v8
        cdef Mut0 v9
        cdef unsigned long long v11
        cdef numpy.ndarray[signed char,ndim=1] v12
        cdef numpy.ndarray[object,ndim=1] v13
        cdef Mut1 v14
        cdef signed short v16
        cdef bint v17
        cdef US1 v25
        cdef bint v19
        cdef signed short v21
        cdef signed short v22
        cdef signed short v26
        cdef bint v27
        cdef signed short v28
        cdef UH0 v29
        cdef float v30
        cdef float v31
        cdef UH0 v32
        cdef float v33
        cdef float v34
        cdef signed char v35
        cdef signed short v36
        cdef unsigned long long tmp12
        cdef float v37
        cdef float v38
        cdef float v39
        cdef numpy.ndarray[signed char,ndim=1] v40
        cdef signed char v41
        cdef signed short v42
        cdef unsigned long long tmp13
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef numpy.ndarray[signed char,ndim=1] v47
        cdef bint v48
        cdef signed short v49
        cdef signed char v50
        cdef signed short v51
        cdef unsigned long long tmp14
        cdef float v52
        cdef float v53
        cdef float v54
        cdef float v55
        cdef numpy.ndarray[signed char,ndim=1] v56
        cdef signed char v57
        cdef signed short v58
        cdef unsigned long long tmp15
        cdef float v59
        cdef float v60
        cdef float v61
        cdef float v62
        cdef numpy.ndarray[signed char,ndim=1] v63
        cdef object v70
        cdef bint v65
        cdef unsigned char v66
        cdef unsigned char v67
        cdef numpy.ndarray[signed char,ndim=1] v68
        cdef US0 v71
        cdef US0 v72
        cdef UH0 v73
        cdef UH0 v74
        cdef US0 v75
        cdef US0 v76
        cdef UH0 v77
        cdef UH0 v78
        cdef UH2 v79
        cdef unsigned long long v80
        v8 = numpy.empty(v5,dtype=object)
        v9 = Mut0((<unsigned long long>0))
        while method0(v5, v9):
            v11 = v9.v0
            v12 = numpy.arange(0,52,dtype=numpy.int8)
            numpy.random.shuffle(v12)
            v13 = numpy.empty(v0,dtype=object)
            v14 = Mut1((<signed short>0))
            while method9(v0, v14):
                v16 = v14.v0
                v17 = v16 == (<signed short>0)
                if v17:
                    v25 = US1_1()
                else:
                    v19 = v16 == (<signed short>1)
                    if v19:
                        v25 = US1_0()
                    else:
                        v21 = v0 - v16
                        v22 = v21 + (<signed short>2)
                        v25 = US1_2(v22)
                v13[v16] = v25
                del v25
                v26 = v16 + (<signed short>1)
                v14.v0 = v26
            del v14
            v27 = v2 < v0
            if v27:
                v28 = v2
            else:
                v28 = v0
            v29 = UH0_1()
            v30 = (<float>0)
            v31 = (<float>0)
            v32 = UH0_1()
            v33 = (<float>0)
            v34 = (<float>0)
            v35 = v12[(<signed short>0)]
            tmp12 = len(v12)
            if <signed short>tmp12 != tmp12: raise Exception("The conversion to signed short failed.")
            v36 = <signed short>tmp12
            v37 = <float>v36
            v38 = (<float>1) / v37
            v39 = libc.math.log(v38)
            v40 = v12[1:]
            del v12
            v41 = v40[(<signed short>0)]
            tmp13 = len(v40)
            if <signed short>tmp13 != tmp13: raise Exception("The conversion to signed short failed.")
            v42 = <signed short>tmp13
            v43 = <float>v42
            v44 = (<float>1) / v43
            v45 = libc.math.log(v44)
            v46 = v45 + v39
            v47 = v40[1:]
            del v40
            v48 = v1 < v0
            if v48:
                v49 = v1
            else:
                v49 = v0
            v50 = v47[(<signed short>0)]
            tmp14 = len(v47)
            if <signed short>tmp14 != tmp14: raise Exception("The conversion to signed short failed.")
            v51 = <signed short>tmp14
            v52 = <float>v51
            v53 = (<float>1) / v52
            v54 = libc.math.log(v53)
            v55 = v54 + v46
            v56 = v47[1:]
            del v47
            v57 = v56[(<signed short>0)]
            tmp15 = len(v56)
            if <signed short>tmp15 != tmp15: raise Exception("The conversion to signed short failed.")
            v58 = <signed short>tmp15
            v59 = <float>v58
            v60 = (<float>1) / v59
            v61 = libc.math.log(v60)
            v62 = v61 + v55
            v63 = v56[1:]
            del v56
            if v3:
                v70 = Closure9(v63, v0, v1, v4, v13, v35, v41, v28, v50, v57, v49)
            else:
                v65 = 1
                v66 = (<unsigned char>0)
                v67 = (<unsigned char>1)
                v68 = numpy.empty(0,dtype=numpy.int8)
                
                v70 = method39(v0, v1, v4, v13, v65, v50, v57, v67, v49, v35, v41, v66, v28, v68, v63)
                del v68
            del v13; del v63
            v71 = US0_1(v41)
            v72 = US0_1(v35)
            v73 = UH0_0(v72, v29)
            del v29; del v72
            v74 = UH0_0(v71, v73)
            del v71; del v73
            v75 = US0_1(v57)
            v76 = US0_1(v50)
            v77 = UH0_0(v76, v32)
            del v32; del v76
            v78 = UH0_0(v75, v77)
            del v75; del v77
            v79 = v70(v62, v62, v74, v30, v31, v78, v33, v34)
            del v70; del v74; del v78
            v8[v11] = v79
            del v79
            v80 = v11 + (<unsigned long long>1)
            v9.v0 = v80
        del v9
        return method57(v7, v6, v8)
cdef class Closure7():
    def __init__(self): pass
    def __call__(self, unsigned char v0, bint v1, signed short v2, signed short v3, signed short v4):
        return Closure8(v4, v3, v2, v1, v0)
cdef class Closure31():
    cdef signed short v0
    cdef signed short v1
    cdef signed short v2
    cdef bint v3
    cdef unsigned char v4
    def __init__(self, signed short v0, signed short v1, signed short v2, bint v3, unsigned char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, unsigned long long v5, v6):
        cdef signed short v0 = self.v0
        cdef signed short v1 = self.v1
        cdef signed short v2 = self.v2
        cdef bint v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v7
        cdef Mut0 v8
        cdef unsigned long long v10
        cdef numpy.ndarray[signed char,ndim=1] v11
        cdef numpy.ndarray[object,ndim=1] v12
        cdef Mut1 v13
        cdef signed short v15
        cdef bint v16
        cdef US1 v24
        cdef bint v18
        cdef signed short v20
        cdef signed short v21
        cdef signed short v25
        cdef bint v26
        cdef signed short v27
        cdef UH0 v28
        cdef float v29
        cdef float v30
        cdef UH0 v31
        cdef float v32
        cdef float v33
        cdef signed char v34
        cdef signed short v35
        cdef unsigned long long tmp64
        cdef float v36
        cdef float v37
        cdef float v38
        cdef numpy.ndarray[signed char,ndim=1] v39
        cdef signed char v40
        cdef signed short v41
        cdef unsigned long long tmp65
        cdef float v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef numpy.ndarray[signed char,ndim=1] v46
        cdef bint v47
        cdef signed short v48
        cdef signed char v49
        cdef signed short v50
        cdef unsigned long long tmp66
        cdef float v51
        cdef float v52
        cdef float v53
        cdef float v54
        cdef numpy.ndarray[signed char,ndim=1] v55
        cdef signed char v56
        cdef signed short v57
        cdef unsigned long long tmp67
        cdef float v58
        cdef float v59
        cdef float v60
        cdef float v61
        cdef numpy.ndarray[signed char,ndim=1] v62
        cdef object v69
        cdef bint v64
        cdef unsigned char v65
        cdef unsigned char v66
        cdef numpy.ndarray[signed char,ndim=1] v67
        cdef US0 v70
        cdef US0 v71
        cdef UH0 v72
        cdef UH0 v73
        cdef US0 v74
        cdef US0 v75
        cdef UH0 v76
        cdef UH0 v77
        cdef UH2 v78
        cdef unsigned long long v79
        v7 = numpy.empty(v5,dtype=object)
        v8 = Mut0((<unsigned long long>0))
        while method0(v5, v8):
            v10 = v8.v0
            v11 = numpy.arange(0,52,dtype=numpy.int8)
            numpy.random.shuffle(v11)
            v12 = numpy.empty(v0,dtype=object)
            v13 = Mut1((<signed short>0))
            while method9(v0, v13):
                v15 = v13.v0
                v16 = v15 == (<signed short>0)
                if v16:
                    v24 = US1_1()
                else:
                    v18 = v15 == (<signed short>1)
                    if v18:
                        v24 = US1_0()
                    else:
                        v20 = v0 - v15
                        v21 = v20 + (<signed short>2)
                        v24 = US1_2(v21)
                v12[v15] = v24
                del v24
                v25 = v15 + (<signed short>1)
                v13.v0 = v25
            del v13
            v26 = v2 < v0
            if v26:
                v27 = v2
            else:
                v27 = v0
            v28 = UH0_1()
            v29 = (<float>0)
            v30 = (<float>0)
            v31 = UH0_1()
            v32 = (<float>0)
            v33 = (<float>0)
            v34 = v11[(<signed short>0)]
            tmp64 = len(v11)
            if <signed short>tmp64 != tmp64: raise Exception("The conversion to signed short failed.")
            v35 = <signed short>tmp64
            v36 = <float>v35
            v37 = (<float>1) / v36
            v38 = libc.math.log(v37)
            v39 = v11[1:]
            del v11
            v40 = v39[(<signed short>0)]
            tmp65 = len(v39)
            if <signed short>tmp65 != tmp65: raise Exception("The conversion to signed short failed.")
            v41 = <signed short>tmp65
            v42 = <float>v41
            v43 = (<float>1) / v42
            v44 = libc.math.log(v43)
            v45 = v44 + v38
            v46 = v39[1:]
            del v39
            v47 = v1 < v0
            if v47:
                v48 = v1
            else:
                v48 = v0
            v49 = v46[(<signed short>0)]
            tmp66 = len(v46)
            if <signed short>tmp66 != tmp66: raise Exception("The conversion to signed short failed.")
            v50 = <signed short>tmp66
            v51 = <float>v50
            v52 = (<float>1) / v51
            v53 = libc.math.log(v52)
            v54 = v53 + v45
            v55 = v46[1:]
            del v46
            v56 = v55[(<signed short>0)]
            tmp67 = len(v55)
            if <signed short>tmp67 != tmp67: raise Exception("The conversion to signed short failed.")
            v57 = <signed short>tmp67
            v58 = <float>v57
            v59 = (<float>1) / v58
            v60 = libc.math.log(v59)
            v61 = v60 + v54
            v62 = v55[1:]
            del v55
            if v3:
                v69 = Closure9(v62, v0, v1, v4, v12, v34, v40, v27, v49, v56, v48)
            else:
                v64 = 1
                v65 = (<unsigned char>0)
                v66 = (<unsigned char>1)
                v67 = numpy.empty(0,dtype=numpy.int8)
                
                v69 = method39(v0, v1, v4, v12, v64, v49, v56, v66, v48, v34, v40, v65, v27, v67, v62)
                del v67
            del v12; del v62
            v70 = US0_1(v40)
            v71 = US0_1(v34)
            v72 = UH0_0(v71, v28)
            del v28; del v71
            v73 = UH0_0(v70, v72)
            del v70; del v72
            v74 = US0_1(v56)
            v75 = US0_1(v49)
            v76 = UH0_0(v75, v31)
            del v31; del v75
            v77 = UH0_0(v74, v76)
            del v74; del v76
            v78 = v69(v61, v61, v73, v29, v30, v77, v32, v33)
            del v69; del v73; del v77
            v7[v10] = v78
            del v78
            v79 = v10 + (<unsigned long long>1)
            v8.v0 = v79
        del v8
        return method59(v6, v7)
cdef class Closure30():
    def __init__(self): pass
    def __call__(self, unsigned char v0, bint v1, signed short v2, signed short v3, signed short v4):
        return Closure31(v4, v3, v2, v1, v0)
cdef class Closure34():
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
        v7 = v4((<float>0), (<float>0), v6)
        del v6
        method60(v0, v1, v2, v3, v7)
cdef class Closure35():
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
        v6 = v4((<float>0), (<float>0), v5)
        del v5
        method60(v0, v1, v2, v3, v6)
cdef class Closure36():
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
        v6 = v4((<float>0), (<float>0), v5)
        del v5
        method60(v0, v1, v2, v3, v6)
cdef class Closure33():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, unsigned char v1, bint v2, signed short v3, signed short v4, signed short v5, unsigned char v6, v7):
        cdef object v0 = self.v0
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
        cdef bint v23
        cdef signed short v24
        cdef UH0 v25
        cdef float v26
        cdef float v27
        cdef UH0 v28
        cdef float v29
        cdef float v30
        cdef signed char v31
        cdef signed short v32
        cdef unsigned long long tmp71
        cdef float v33
        cdef float v34
        cdef float v35
        cdef numpy.ndarray[signed char,ndim=1] v36
        cdef signed char v37
        cdef signed short v38
        cdef unsigned long long tmp72
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef numpy.ndarray[signed char,ndim=1] v43
        cdef bint v44
        cdef signed short v45
        cdef signed char v46
        cdef signed short v47
        cdef unsigned long long tmp73
        cdef float v48
        cdef float v49
        cdef float v50
        cdef float v51
        cdef numpy.ndarray[signed char,ndim=1] v52
        cdef signed char v53
        cdef signed short v54
        cdef unsigned long long tmp74
        cdef float v55
        cdef float v56
        cdef float v57
        cdef float v58
        cdef numpy.ndarray[signed char,ndim=1] v59
        cdef object v66
        cdef bint v61
        cdef unsigned char v62
        cdef unsigned char v63
        cdef numpy.ndarray[signed char,ndim=1] v64
        cdef US0 v67
        cdef US0 v68
        cdef UH0 v69
        cdef UH0 v70
        cdef US0 v71
        cdef US0 v72
        cdef UH0 v73
        cdef UH0 v74
        cdef UH2 v75
        v8 = numpy.arange(0,52,dtype=numpy.int8)
        numpy.random.shuffle(v8)
        v9 = numpy.empty(v5,dtype=object)
        v10 = Mut1((<signed short>0))
        while method9(v5, v10):
            v12 = v10.v0
            v13 = v12 == (<signed short>0)
            if v13:
                v21 = US1_1()
            else:
                v15 = v12 == (<signed short>1)
                if v15:
                    v21 = US1_0()
                else:
                    v17 = v5 - v12
                    v18 = v17 + (<signed short>2)
                    v21 = US1_2(v18)
            v9[v12] = v21
            del v21
            v22 = v12 + (<signed short>1)
            v10.v0 = v22
        del v10
        v23 = v3 < v5
        if v23:
            v24 = v3
        else:
            v24 = v5
        v25 = UH0_1()
        v26 = (<float>0)
        v27 = (<float>0)
        v28 = UH0_1()
        v29 = (<float>0)
        v30 = (<float>0)
        v31 = v8[(<signed short>0)]
        tmp71 = len(v8)
        if <signed short>tmp71 != tmp71: raise Exception("The conversion to signed short failed.")
        v32 = <signed short>tmp71
        v33 = <float>v32
        v34 = (<float>1) / v33
        v35 = libc.math.log(v34)
        v36 = v8[1:]
        del v8
        v37 = v36[(<signed short>0)]
        tmp72 = len(v36)
        if <signed short>tmp72 != tmp72: raise Exception("The conversion to signed short failed.")
        v38 = <signed short>tmp72
        v39 = <float>v38
        v40 = (<float>1) / v39
        v41 = libc.math.log(v40)
        v42 = v41 + v35
        v43 = v36[1:]
        del v36
        v44 = v4 < v5
        if v44:
            v45 = v4
        else:
            v45 = v5
        v46 = v43[(<signed short>0)]
        tmp73 = len(v43)
        if <signed short>tmp73 != tmp73: raise Exception("The conversion to signed short failed.")
        v47 = <signed short>tmp73
        v48 = <float>v47
        v49 = (<float>1) / v48
        v50 = libc.math.log(v49)
        v51 = v50 + v42
        v52 = v43[1:]
        del v43
        v53 = v52[(<signed short>0)]
        tmp74 = len(v52)
        if <signed short>tmp74 != tmp74: raise Exception("The conversion to signed short failed.")
        v54 = <signed short>tmp74
        v55 = <float>v54
        v56 = (<float>1) / v55
        v57 = libc.math.log(v56)
        v58 = v57 + v51
        v59 = v52[1:]
        del v52
        if v2:
            v66 = Closure9(v59, v5, v4, v1, v9, v31, v37, v24, v46, v53, v45)
        else:
            v61 = 1
            v62 = (<unsigned char>0)
            v63 = (<unsigned char>1)
            v64 = numpy.empty(0,dtype=numpy.int8)
            
            v66 = method39(v5, v4, v1, v9, v61, v46, v53, v63, v45, v31, v37, v62, v24, v64, v59)
            del v64
        del v9; del v59
        v67 = US0_1(v37)
        v68 = US0_1(v31)
        v69 = UH0_0(v68, v25)
        del v25; del v68
        v70 = UH0_0(v67, v69)
        del v67; del v69
        v71 = US0_1(v53)
        v72 = US0_1(v46)
        v73 = UH0_0(v72, v28)
        del v28; del v72
        v74 = UH0_0(v71, v73)
        del v71; del v73
        v75 = v66(v58, v58, v70, v26, v27, v74, v29, v30)
        del v66; del v70; del v74
        method60(v0, v7, v6, v5, v75)
cdef class Closure32():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure33(v0)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple3 method1(UH0 v0, UH1 v1, bint v2):
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
        return Tuple3(v1, v2)
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
cdef signed short method6(signed short v0, numpy.ndarray[float,ndim=1] v1, signed short v2, signed short v3, signed short v4) except *:
    cdef bint v5
    cdef signed short v6
    cdef signed short v7
    cdef signed short v8
    cdef signed long v9
    cdef signed short v10
    cdef signed short v11
    cdef signed short v12
    cdef signed short v13
    cdef float v14
    cdef signed short v15
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<signed short>1)
        v7 = v0 - v3
        v8 = v7 - (<signed short>1)
        v9 = <signed long>v8
        v10 = (<signed short>1) << v9
        v11 = <signed short>v3
        v12 = v2 + v11
        v13 = v4 // v10
        v14 = <float>v13
        v1[v12] = v14
        v15 = v4 % v10
        return method6(v0, v1, v2, v6, v15)
    else:
        return v4
cdef void method5(signed short v0, signed short v1, numpy.ndarray[float,ndim=1] v2, signed short v3) except *:
    cdef signed long v4
    cdef signed long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef bint v9
    cdef bint v12
    cdef unsigned long long v10
    cdef signed short v13
    cdef signed short v14
    cdef signed short v15
    cdef str v16
    v4 = <signed long>v0
    v5 = v4 - (<signed long>1)
    v6 = (<unsigned long long>1) << v5
    v7 = v6 - (<unsigned long long>1)
    v8 = v6 + v7
    v9 = (<signed short>0) <= v1
    if v9:
        v10 = <unsigned long long>v1
        v12 = v10 < v8
    else:
        v12 = 0
    if v12:
        v13 = v1 + (<signed short>1)
        v14 = (<signed short>0)
        v15 = method6(v0, v2, v3, v14, v13)
    else:
        v16 = f'Pickle failure. Bin int value out of bounds. Got: {v1} Size: {v0}'
        raise Exception(v16)
cdef signed short method8(signed short v0, numpy.ndarray[float,ndim=1] v1, signed short v2, signed short v3) except *:
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
    v4 = v2 < v0
    if v4:
        v5 = v2 + (<signed short>1)
        v6 = v0 - v2
        v7 = v6 - (<signed short>1)
        v8 = <signed long>v7
        v9 = (<signed short>1) << v8
        v10 = <signed short>v2
        v11 = v0 + v10
        v12 = v3 // v9
        v13 = <float>v12
        v1[v11] = v13
        v14 = v3 % v9
        return method8(v0, v1, v5, v14)
    else:
        return v3
cdef void method7(signed short v0, signed short v1, numpy.ndarray[float,ndim=1] v2) except *:
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
    v3 = <signed long>v0
    v4 = v3 - (<signed long>1)
    v5 = (<unsigned long long>1) << v4
    v6 = v5 - (<unsigned long long>1)
    v7 = v5 + v6
    v8 = (<signed short>0) <= v1
    if v8:
        v9 = <unsigned long long>v1
        v11 = v9 < v7
    else:
        v11 = 0
    if v11:
        v12 = v1 + (<signed short>1)
        v13 = (<signed short>0)
        v14 = method8(v0, v2, v13, v12)
    else:
        v15 = f'Pickle failure. Bin int value out of bounds. Got: {v1} Size: {v0}'
        raise Exception(v15)
cdef bint method9(signed short v0, Mut1 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef bint method14(signed short v0, Mut2 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple4 method16(unsigned long long v0, signed char v1, signed char v2):
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
            return method16(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method15(v0, v93)
cdef Tuple5 method19(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned char v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9):
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
                return method19(v0, v1, v2, v44, v42, v37, v38, v39, v40, v41)
            else:
                return Tuple5(v37, v38, v39, v40, v41)
        else:
            v55 = v3 + (<signed char>1)
            return method19(v0, v1, v2, v55, v4, v5, v6, v7, v8, v9)
    else:
        v66 = v2 - (<signed char>1)
        return method18(v0, v1, v66, v5, v6, v7, v8, v9, v4)
cdef Tuple5 method18(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method18(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method19(v0, v1, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple5(v3, v4, v5, v6, v7)
cdef Tuple6 method21(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
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
        return method21(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple6(v3, v4, v5, v6)
cdef Tuple4 method24(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
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
        return method24(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple5 method30(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned char v5, signed char v6, signed char v7, signed char v8, signed char v9, signed char v10):
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
                return method30(v0, v1, v2, v3, v45, v43, v38, v39, v40, v41, v42)
            else:
                return Tuple5(v38, v39, v40, v41, v42)
        else:
            v56 = v4 + (<signed char>1)
            return method30(v0, v1, v2, v3, v56, v5, v6, v7, v8, v9, v10)
    else:
        v67 = v3 - (<signed char>1)
        return method29(v0, v1, v2, v67, v6, v7, v8, v9, v10, v5)
cdef Tuple5 method29(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
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
        return method29(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method30(v0, v1, v2, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple5(v4, v5, v6, v7, v8)
cdef Tuple5 method33(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
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
                return method33(v0, v1, v43, v41, v36, v37, v38, v39, v40)
            else:
                return Tuple5(v36, v37, v38, v39, v40)
        else:
            v54 = v2 + (<signed char>1)
            return method33(v0, v1, v54, v3, v4, v5, v6, v7, v8)
    else:
        v65 = v1 - (<signed char>1)
        return method32(v0, v65, v4, v5, v6, v7, v8, v3)
cdef Tuple5 method32(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method33(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple5(v2, v3, v4, v5, v6)
cdef Tuple4 method31(unsigned long long v0, signed char v1):
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
            tmp33 = method21(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp33.v0, tmp33.v1, tmp33.v2, tmp33.v3
            del tmp33
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp34 = method18(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp34.v0, tmp34.v1, tmp34.v2, tmp34.v3, tmp34.v4
            del tmp34
            return Tuple4(v40, v41, v51, v52, v53, (<signed char>2))
        else:
            v56 = v1 - (<signed char>1)
            return method31(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp35 = method32(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp35.v0, tmp35.v1, tmp35.v2, tmp35.v3, tmp35.v4
        del tmp35
        return Tuple4(v76, v77, v78, v79, v80, (<signed char>1))
cdef Tuple4 method28(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
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
        return method28(v0, v1, v2, v3, v6)
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
                tmp31 = method21(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp31.v0, tmp31.v1, tmp31.v2, tmp31.v3
                del tmp31
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp32 = method29(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3, tmp32.v4
                del tmp32
                return Tuple4(v3, v2, v51, v52, v62, (<signed char>3))
            else:
                v67 = v4 - (<signed char>1)
                return method28(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method31(v0, v80)
cdef Tuple4 method27(unsigned long long v0, signed char v1):
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
            tmp30 = method21(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3
            del tmp30
            v44 = (<signed char>12)
            return method28(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method27(v0, v51)
    else:
        v64 = (<signed char>12)
        return method31(v0, v64)
cdef Tuple4 method26(unsigned long long v0, signed char v1):
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
            tmp28 = method21(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3
            del tmp28
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp29 = method18(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3, tmp29.v4
            del tmp29
            return Tuple4(v40, v41, v42, v51, v52, (<signed char>4))
        else:
            v56 = v1 - (<signed char>1)
            return method26(v0, v56)
    else:
        v69 = (<signed char>12)
        return method27(v0, v69)
cdef Tuple4 method25(unsigned long long v0, signed char v1):
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
            tmp23 = method21(v0, v157, v162, v158, v159, v160, v161, v163)
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
            tmp24 = method21(v0, v171, v176, v172, v173, v174, v175, v177)
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
            tmp25 = method21(v0, v185, v190, v186, v187, v188, v189, v191)
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
            tmp26 = method21(v0, v199, v204, v200, v201, v202, v203, v205)
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
            tmp27 = method21(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3
            del tmp27
            return Tuple4(v164, v178, v192, v206, v219, (<signed char>5))
        else:
            v223 = v1 - (<signed char>1)
            return method25(v0, v223)
    else:
        v236 = (<signed char>12)
        return method26(v0, v236)
cdef Tuple4 method23(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
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
            return method24(v0, v39, v40, v41, v42, v43, v44, v45, v46)
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
                return method24(v0, v54, v55, v56, v57, v58, v59, v60, v61)
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
                    return method24(v0, v69, v70, v71, v72, v73, v74, v75, v76)
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
                        return method24(v0, v84, v85, v86, v87, v88, v89, v90, v91)
                    else:
                        v98 = v1 - (<signed char>1)
                        return method23(v0, v98, v37, v29, v21, v13)
    else:
        v129 = (<signed char>8)
        return method25(v0, v129)
cdef Tuple4 method22(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
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
        return method22(v0, v1, v2, v3, v4, v7)
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
                tmp22 = method21(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3
                del tmp22
                return Tuple4(v4, v3, v2, v52, v53, (<signed char>7))
            else:
                v56 = v5 - (<signed char>1)
                return method22(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method23(v0, v69, v73, v72, v71, v70)
cdef Tuple4 method20(unsigned long long v0, signed char v1):
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
            tmp21 = method21(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3
            del tmp21
            v44 = (<signed char>12)
            return method22(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method20(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method23(v0, v64, v68, v67, v66, v65)
cdef Tuple4 method17(unsigned long long v0, signed char v1):
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
            tmp20 = method18(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4
            del tmp20
            return Tuple4(v1, v9, v17, v25, v41, (<signed char>8))
        else:
            v46 = v1 - (<signed char>1)
            return method17(v0, v46)
    else:
        v59 = (<signed char>12)
        return method20(v0, v59)
cdef Tuple4 method15(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method16(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method17(v0, v10)
cdef Tuple4 method13(signed char v0, signed char v1, numpy.ndarray[signed char,ndim=1] v2):
    cdef signed long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef signed long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef signed short v9
    cdef unsigned long long tmp19
    cdef Mut2 v10
    cdef signed short v12
    cdef signed short v13
    cdef signed short v14
    cdef signed short v15
    cdef unsigned long long v16
    cdef signed char v17
    cdef signed long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef signed short v21
    cdef unsigned long long v22
    cdef signed char v23
    v3 = <signed long>v1
    v4 = (<unsigned long long>1) << v3
    v5 = (<unsigned long long>0) | v4
    v6 = <signed long>v0
    v7 = (<unsigned long long>1) << v6
    v8 = v5 | v7
    tmp19 = len(v2)
    if <signed short>tmp19 != tmp19: raise Exception("The conversion to signed short failed.")
    v9 = <signed short>tmp19
    v10 = Mut2((<signed short>0), v8)
    while method14(v9, v10):
        v12 = v10.v0
        v13 = -v12
        v14 = v13 + v9
        v15 = v14 - (<signed short>1)
        v16 = v10.v1
        v17 = v2[v15]
        v18 = <signed long>v17
        v19 = (<unsigned long long>1) << v18
        v20 = v16 | v19
        v21 = v12 + (<signed short>1)
        v10.v0 = v21
        v10.v1 = v20
    v22 = v10.v1
    del v10
    v23 = (<signed char>8)
    return method15(v22, v23)
cdef object method12(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9):
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef Tuple4 tmp36
    cdef signed char v16
    cdef signed char v17
    cdef signed char v18
    cdef signed char v19
    cdef signed char v20
    cdef signed char v21
    cdef Tuple4 tmp37
    cdef signed char v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef bint v32
    cdef signed long v35
    cdef bint v33
    cdef bint v36
    cdef signed long v65
    cdef bint v37
    cdef signed long v40
    cdef bint v38
    cdef bint v41
    cdef bint v42
    cdef signed long v45
    cdef bint v43
    cdef bint v46
    cdef bint v47
    cdef signed long v50
    cdef bint v48
    cdef bint v51
    cdef bint v52
    cdef signed long v55
    cdef bint v53
    cdef bint v56
    cdef bint v57
    cdef bint v58
    cdef bint v66
    cdef float v67
    cdef bint v69
    cdef float v70
    cdef signed short v72
    cdef float v73
    tmp36 = method13(v7, v6, v1)
    v10, v11, v12, v13, v14, v15 = tmp36.v0, tmp36.v1, tmp36.v2, tmp36.v3, tmp36.v4, tmp36.v5
    del tmp36
    tmp37 = method13(v3, v2, v1)
    v16, v17, v18, v19, v20, v21 = tmp37.v0, tmp37.v1, tmp37.v2, tmp37.v3, tmp37.v4, tmp37.v5
    del tmp37
    v22 = v10 % (<signed char>13)
    v23 = v11 % (<signed char>13)
    v24 = v12 % (<signed char>13)
    v25 = v13 % (<signed char>13)
    v26 = v14 % (<signed char>13)
    v27 = v16 % (<signed char>13)
    v28 = v17 % (<signed char>13)
    v29 = v18 % (<signed char>13)
    v30 = v19 % (<signed char>13)
    v31 = v20 % (<signed char>13)
    v32 = v15 < v21
    if v32:
        v35 = (<signed long>-1)
    else:
        v33 = v15 > v21
        if v33:
            v35 = (<signed long>1)
        else:
            v35 = (<signed long>0)
    v36 = v35 == (<signed long>0)
    if v36:
        v37 = v22 < v27
        if v37:
            v40 = (<signed long>-1)
        else:
            v38 = v22 > v27
            if v38:
                v40 = (<signed long>1)
            else:
                v40 = (<signed long>0)
        v41 = v40 == (<signed long>0)
        if v41:
            v42 = v23 < v28
            if v42:
                v45 = (<signed long>-1)
            else:
                v43 = v23 > v28
                if v43:
                    v45 = (<signed long>1)
                else:
                    v45 = (<signed long>0)
            v46 = v45 == (<signed long>0)
            if v46:
                v47 = v24 < v29
                if v47:
                    v50 = (<signed long>-1)
                else:
                    v48 = v24 > v29
                    if v48:
                        v50 = (<signed long>1)
                    else:
                        v50 = (<signed long>0)
                v51 = v50 == (<signed long>0)
                if v51:
                    v52 = v25 < v30
                    if v52:
                        v55 = (<signed long>-1)
                    else:
                        v53 = v25 > v30
                        if v53:
                            v55 = (<signed long>1)
                        else:
                            v55 = (<signed long>0)
                    v56 = v55 == (<signed long>0)
                    if v56:
                        v57 = v26 < v31
                        if v57:
                            v65 = (<signed long>-1)
                        else:
                            v58 = v26 > v31
                            if v58:
                                v65 = (<signed long>1)
                            else:
                                v65 = (<signed long>0)
                    else:
                        v65 = v55
                else:
                    v65 = v50
            else:
                v65 = v45
        else:
            v65 = v40
    else:
        v65 = v35
    v66 = v65 == (<signed long>0)
    if v66:
        v67 = <float>(<signed short>0)
        return Closure10(v6, v7, v8, v9, v2, v3, v4, v5, v1, v0, v67)
    else:
        v69 = v65 == (<signed long>1)
        if v69:
            v70 = <float>v9
            return Closure10(v6, v7, v8, v9, v2, v3, v4, v5, v1, v0, v70)
        else:
            v72 = -v9
            v73 = <float>v72
            return Closure10(v6, v7, v8, v9, v2, v3, v4, v5, v1, v0, v73)
cdef object method11(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9):
    cdef bint v10
    cdef signed char v11
    cdef signed char v12
    cdef unsigned char v13
    cdef signed short v14
    cdef signed char v15
    cdef signed char v16
    cdef unsigned char v17
    cdef signed short v18
    v10 = v8 == (<unsigned char>0)
    if v10:
        v11, v12, v13, v14, v15, v16, v17, v18 = v6, v7, v8, v9, v2, v3, v4, v5
    else:
        v11, v12, v13, v14, v15, v16, v17, v18 = v2, v3, v4, v5, v6, v7, v8, v9
    return method12(v0, v1, v15, v16, v17, v18, v11, v12, v13, v14)
cdef bint method34(signed short v0, Mut3 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef object method37(signed short v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned char v12
    cdef signed short v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    v9 = v8 == (<unsigned char>0)
    if v9:
        v10, v11, v12, v13, v14, v15, v16, v17 = v6, v7, v8, v5, v2, v3, v4, v5
    else:
        v10, v11, v12, v13, v14, v15, v16, v17 = v2, v3, v4, v5, v6, v7, v8, v5
    return method12(v0, v1, v14, v15, v16, v17, v10, v11, v12, v13)
cdef UH2 method38(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
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
            v25 = method36(v8, v9, v10, v11, v22, v5, v6, v7, v4, v1, v2, v3, v12)
        else:
            v25 = method37(v8, v12, v1, v2, v3, v4, v5, v6, v7)
        return v25(v14, v15, v16, v17, v18, v19, v20, v21)
    elif v13.tag == 1: # fold
        v27 = v7 == (<unsigned char>0)
        if v27:
            v29 = -v4
        else:
            v29 = v4
        v30 = <float>v29
        return UH2_1(v14, v15, v16, v17, v18, v19, v20, v21, v5, v6, v7, v4, v1, v2, v3, v4, v12, v8, 0, v30)
    elif v13.tag == 2: # raiseTo_
        v32 = (<US1_2>v13).v0
        v33 = 0
        v34 = method10(v8, v9, v10, v11, v33, v5, v6, v7, v32, v1, v2, v3, v4, v12)
        return v34(v14, v15, v16, v17, v18, v19, v20, v21)
cdef object method36(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, numpy.ndarray[signed char,ndim=1] v12):
    cdef bint v13
    cdef bint v15
    cdef bint v16
    cdef bint v17
    cdef signed short v18
    cdef signed short v19
    cdef bint v20
    cdef signed short v21
    cdef bint v22
    cdef signed short v23
    cdef signed short v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef bint v26
    cdef numpy.ndarray[object,ndim=1] v124
    cdef bint v27
    cdef signed short v28
    cdef unsigned long long tmp40
    cdef numpy.ndarray[object,ndim=1] v29
    cdef Mut3 v30
    cdef signed short v32
    cdef signed short v33
    cdef US1 v34
    cdef bint v63
    cdef signed short v35
    cdef bint v36
    cdef bint v37
    cdef bint v38
    cdef signed short v39
    cdef signed short v41
    cdef signed short v42
    cdef signed short v43
    cdef bint v44
    cdef signed short v45
    cdef bint v46
    cdef signed short v47
    cdef signed short v48
    cdef bint v49
    cdef bint v50
    cdef signed short v51
    cdef bint v52
    cdef signed short v53
    cdef signed short v65
    cdef signed short v66
    cdef signed short v67
    cdef numpy.ndarray[object,ndim=1] v68
    cdef Mut1 v69
    cdef signed short v71
    cdef US1 v72
    cdef signed short v73
    cdef bint v74
    cdef signed short v75
    cdef unsigned long long tmp41
    cdef numpy.ndarray[object,ndim=1] v76
    cdef Mut3 v77
    cdef signed short v79
    cdef signed short v80
    cdef US1 v81
    cdef bint v110
    cdef signed short v82
    cdef bint v83
    cdef bint v84
    cdef bint v85
    cdef signed short v86
    cdef signed short v88
    cdef signed short v89
    cdef signed short v90
    cdef bint v91
    cdef signed short v92
    cdef bint v93
    cdef signed short v94
    cdef signed short v95
    cdef bint v96
    cdef bint v97
    cdef signed short v98
    cdef bint v99
    cdef signed short v100
    cdef signed short v112
    cdef signed short v113
    cdef signed short v114
    cdef numpy.ndarray[object,ndim=1] v115
    cdef Mut1 v116
    cdef signed short v118
    cdef US1 v119
    cdef signed short v120
    v13 = v8 == v0
    if v13:
        return method37(v0, v12, v5, v6, v7, v8, v9, v10, v11)
    else:
        v15 = v8 >= v8
        v16 = v8 < v8
        v17 = v1 >= (<signed short>0)
        if v17:
            v18 = v1
        else:
            v18 = (<signed short>0)
        v19 = v8 + v18
        v20 = v0 < v19
        if v20:
            v21 = v0
        else:
            v21 = v19
        v22 = v0 == v8
        if v22:
            v23 = (<signed short>1)
        else:
            v23 = (<signed short>0)
        v24 = v21 + v23
        v25 = v3[(<signed short>1):3+v0-v24]
        v26 = (<unsigned char>0) == v2
        if v26:
            v124 = v25
        else:
            v27 = (<unsigned char>1) == v2
            if v27:
                tmp40 = len(v25)
                if <signed short>tmp40 != tmp40: raise Exception("The conversion to signed short failed.")
                v28 = <signed short>tmp40
                v29 = numpy.empty(v28,dtype=object)
                v30 = Mut3((<signed short>0), (<signed short>0))
                while method34(v28, v30):
                    v32 = v30.v0
                    v33 = v30.v1
                    v34 = v25[v32]
                    if v34.tag == 0: # call
                        v63 = 1
                    elif v34.tag == 1: # fold
                        v63 = 1
                    elif v34.tag == 2: # raiseTo_
                        v35 = (<US1_2>v34).v0
                        v36 = v2 == (<unsigned char>1)
                        v37 = v35 == v0
                        if v37:
                            v63 = 1
                        else:
                            v38 = v35 == v19
                            if v38:
                                v63 = 1
                            else:
                                if v36:
                                    v39 = v35 % v1
                                    v63 = v39 == (<signed short>0)
                                else:
                                    v41 = (<signed short>2) * v8
                                    v42 = v35 - v8
                                    v43 = v41 // (<signed short>4)
                                    v44 = v42 == v43
                                    if v44:
                                        v63 = 1
                                    else:
                                        v45 = v41 // (<signed short>2)
                                        v46 = v42 == v45
                                        if v46:
                                            v63 = 1
                                        else:
                                            v47 = v41 * (<signed short>3)
                                            v48 = v47 // (<signed short>4)
                                            v49 = v42 == v48
                                            if v49:
                                                v63 = 1
                                            else:
                                                v50 = v42 == v41
                                                if v50:
                                                    v63 = 1
                                                else:
                                                    v51 = v47 // (<signed short>2)
                                                    v52 = v42 == v51
                                                    if v52:
                                                        v63 = 1
                                                    else:
                                                        v53 = v41 * (<signed short>2)
                                                        v63 = v42 == v53
                    if v63:
                        v29[v33] = v34
                        v65 = v33 + (<signed short>1)
                    else:
                        v65 = v33
                    del v34
                    v66 = v32 + (<signed short>1)
                    v30.v0 = v66
                    v30.v1 = v65
                v67 = v30.v1
                del v30
                v68 = numpy.empty(v67,dtype=object)
                v69 = Mut1((<signed short>0))
                while method9(v67, v69):
                    v71 = v69.v0
                    v72 = v29[v71]
                    v68[v71] = v72
                    del v72
                    v73 = v71 + (<signed short>1)
                    v69.v0 = v73
                del v29
                del v69
                v124 = v68
                del v68
            else:
                v74 = (<unsigned char>2) == v2
                if v74:
                    tmp41 = len(v25)
                    if <signed short>tmp41 != tmp41: raise Exception("The conversion to signed short failed.")
                    v75 = <signed short>tmp41
                    v76 = numpy.empty(v75,dtype=object)
                    v77 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v75, v77):
                        v79 = v77.v0
                        v80 = v77.v1
                        v81 = v25[v79]
                        if v81.tag == 0: # call
                            v110 = 1
                        elif v81.tag == 1: # fold
                            v110 = 1
                        elif v81.tag == 2: # raiseTo_
                            v82 = (<US1_2>v81).v0
                            v83 = v2 == (<unsigned char>1)
                            v84 = v82 == v0
                            if v84:
                                v110 = 1
                            else:
                                v85 = v82 == v19
                                if v85:
                                    v110 = 1
                                else:
                                    if v83:
                                        v86 = v82 % v1
                                        v110 = v86 == (<signed short>0)
                                    else:
                                        v88 = (<signed short>2) * v8
                                        v89 = v82 - v8
                                        v90 = v88 // (<signed short>4)
                                        v91 = v89 == v90
                                        if v91:
                                            v110 = 1
                                        else:
                                            v92 = v88 // (<signed short>2)
                                            v93 = v89 == v92
                                            if v93:
                                                v110 = 1
                                            else:
                                                v94 = v88 * (<signed short>3)
                                                v95 = v94 // (<signed short>4)
                                                v96 = v89 == v95
                                                if v96:
                                                    v110 = 1
                                                else:
                                                    v97 = v89 == v88
                                                    if v97:
                                                        v110 = 1
                                                    else:
                                                        v98 = v94 // (<signed short>2)
                                                        v99 = v89 == v98
                                                        if v99:
                                                            v110 = 1
                                                        else:
                                                            v100 = v88 * (<signed short>2)
                                                            v110 = v89 == v100
                        if v110:
                            v76[v80] = v81
                            v112 = v80 + (<signed short>1)
                        else:
                            v112 = v80
                        del v81
                        v113 = v79 + (<signed short>1)
                        v77.v0 = v113
                        v77.v1 = v112
                    v114 = v77.v1
                    del v77
                    v115 = numpy.empty(v114,dtype=object)
                    v116 = Mut1((<signed short>0))
                    while method9(v114, v116):
                        v118 = v116.v0
                        v119 = v76[v118]
                        v115[v118] = v119
                        del v119
                        v120 = v118 + (<signed short>1)
                        v116.v0 = v120
                    del v76
                    del v116
                    v124 = v115
                    del v115
                else:
                    raise Exception("Invalid action restriction level.")
        del v25
        return Closure13(v9, v10, v11, v8, v5, v6, v7, v12, v0, v124, v4, v1, v2, v3)
cdef UH2 method35(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, US1 v14, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
    cdef object v26
    cdef bint v23
    cdef bint v28
    cdef signed short v30
    cdef float v31
    cdef signed short v33
    cdef bint v34
    cdef object v35
    if v14.tag == 0: # call
        if v0:
            v23 = 0
            v26 = method36(v9, v10, v11, v12, v23, v5, v6, v7, v4, v1, v2, v3, v13)
        else:
            v26 = method37(v9, v13, v1, v2, v3, v4, v5, v6, v7)
        return v26(v15, v16, v17, v18, v19, v20, v21, v22)
    elif v14.tag == 1: # fold
        v28 = v7 == (<unsigned char>0)
        if v28:
            v30 = -v8
        else:
            v30 = v8
        v31 = <float>v30
        return UH2_1(v15, v16, v17, v18, v19, v20, v21, v22, v5, v6, v7, v8, v1, v2, v3, v4, v13, v9, 0, v31)
    elif v14.tag == 2: # raiseTo_
        v33 = (<US1_2>v14).v0
        v34 = 0
        v35 = method10(v9, v10, v11, v12, v34, v5, v6, v7, v33, v1, v2, v3, v4, v13)
        return v35(v15, v16, v17, v18, v19, v20, v21, v22)
cdef object method10(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12, numpy.ndarray[signed char,ndim=1] v13):
    cdef bint v14
    cdef bint v16
    cdef bint v17
    cdef bint v18
    cdef signed short v19
    cdef bint v20
    cdef signed short v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef signed short v26
    cdef bint v27
    cdef signed short v28
    cdef bint v29
    cdef signed short v30
    cdef signed short v31
    cdef numpy.ndarray[object,ndim=1] v32
    cdef bint v33
    cdef numpy.ndarray[object,ndim=1] v131
    cdef bint v34
    cdef signed short v35
    cdef unsigned long long tmp38
    cdef numpy.ndarray[object,ndim=1] v36
    cdef Mut3 v37
    cdef signed short v39
    cdef signed short v40
    cdef US1 v41
    cdef bint v70
    cdef signed short v42
    cdef bint v43
    cdef bint v44
    cdef bint v45
    cdef signed short v46
    cdef signed short v48
    cdef signed short v49
    cdef signed short v50
    cdef bint v51
    cdef signed short v52
    cdef bint v53
    cdef signed short v54
    cdef signed short v55
    cdef bint v56
    cdef bint v57
    cdef signed short v58
    cdef bint v59
    cdef signed short v60
    cdef signed short v72
    cdef signed short v73
    cdef signed short v74
    cdef numpy.ndarray[object,ndim=1] v75
    cdef Mut1 v76
    cdef signed short v78
    cdef US1 v79
    cdef signed short v80
    cdef bint v81
    cdef signed short v82
    cdef unsigned long long tmp39
    cdef numpy.ndarray[object,ndim=1] v83
    cdef Mut3 v84
    cdef signed short v86
    cdef signed short v87
    cdef US1 v88
    cdef bint v117
    cdef signed short v89
    cdef bint v90
    cdef bint v91
    cdef bint v92
    cdef signed short v93
    cdef signed short v95
    cdef signed short v96
    cdef signed short v97
    cdef bint v98
    cdef signed short v99
    cdef bint v100
    cdef signed short v101
    cdef signed short v102
    cdef bint v103
    cdef bint v104
    cdef signed short v105
    cdef bint v106
    cdef signed short v107
    cdef signed short v119
    cdef signed short v120
    cdef signed short v121
    cdef numpy.ndarray[object,ndim=1] v122
    cdef Mut1 v123
    cdef signed short v125
    cdef US1 v126
    cdef signed short v127
    v14 = v12 == v0
    if v14:
        return method11(v0, v13, v5, v6, v7, v8, v9, v10, v11, v12)
    else:
        v16 = v12 == v8
        v17 = v16 != 1
        v18 = v12 >= v8
        if v18:
            v19 = v12
        else:
            v19 = v8
        v20 = v12 < v8
        if v20:
            v21 = v12
        else:
            v21 = v8
        v22 = v19 - v21
        v23 = v1 >= v22
        if v23:
            v24 = v1
        else:
            v24 = v22
        v25 = v19 + v24
        if v17:
            v26 = (<signed short>0)
        else:
            v26 = (<signed short>1)
        v27 = v0 < v25
        if v27:
            v28 = v0
        else:
            v28 = v25
        v29 = v0 == v19
        if v29:
            v30 = (<signed short>1)
        else:
            v30 = (<signed short>0)
        v31 = v28 + v30
        v32 = v3[v26:3+v0-v31]
        v33 = (<unsigned char>0) == v2
        if v33:
            v131 = v32
        else:
            v34 = (<unsigned char>1) == v2
            if v34:
                tmp38 = len(v32)
                if <signed short>tmp38 != tmp38: raise Exception("The conversion to signed short failed.")
                v35 = <signed short>tmp38
                v36 = numpy.empty(v35,dtype=object)
                v37 = Mut3((<signed short>0), (<signed short>0))
                while method34(v35, v37):
                    v39 = v37.v0
                    v40 = v37.v1
                    v41 = v32[v39]
                    if v41.tag == 0: # call
                        v70 = 1
                    elif v41.tag == 1: # fold
                        v70 = 1
                    elif v41.tag == 2: # raiseTo_
                        v42 = (<US1_2>v41).v0
                        v43 = v2 == (<unsigned char>1)
                        v44 = v42 == v0
                        if v44:
                            v70 = 1
                        else:
                            v45 = v42 == v25
                            if v45:
                                v70 = 1
                            else:
                                if v43:
                                    v46 = v42 % v1
                                    v70 = v46 == (<signed short>0)
                                else:
                                    v48 = (<signed short>2) * v19
                                    v49 = v42 - v19
                                    v50 = v48 // (<signed short>4)
                                    v51 = v49 == v50
                                    if v51:
                                        v70 = 1
                                    else:
                                        v52 = v48 // (<signed short>2)
                                        v53 = v49 == v52
                                        if v53:
                                            v70 = 1
                                        else:
                                            v54 = v48 * (<signed short>3)
                                            v55 = v54 // (<signed short>4)
                                            v56 = v49 == v55
                                            if v56:
                                                v70 = 1
                                            else:
                                                v57 = v49 == v48
                                                if v57:
                                                    v70 = 1
                                                else:
                                                    v58 = v54 // (<signed short>2)
                                                    v59 = v49 == v58
                                                    if v59:
                                                        v70 = 1
                                                    else:
                                                        v60 = v48 * (<signed short>2)
                                                        v70 = v49 == v60
                    if v70:
                        v36[v40] = v41
                        v72 = v40 + (<signed short>1)
                    else:
                        v72 = v40
                    del v41
                    v73 = v39 + (<signed short>1)
                    v37.v0 = v73
                    v37.v1 = v72
                v74 = v37.v1
                del v37
                v75 = numpy.empty(v74,dtype=object)
                v76 = Mut1((<signed short>0))
                while method9(v74, v76):
                    v78 = v76.v0
                    v79 = v36[v78]
                    v75[v78] = v79
                    del v79
                    v80 = v78 + (<signed short>1)
                    v76.v0 = v80
                del v36
                del v76
                v131 = v75
                del v75
            else:
                v81 = (<unsigned char>2) == v2
                if v81:
                    tmp39 = len(v32)
                    if <signed short>tmp39 != tmp39: raise Exception("The conversion to signed short failed.")
                    v82 = <signed short>tmp39
                    v83 = numpy.empty(v82,dtype=object)
                    v84 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v82, v84):
                        v86 = v84.v0
                        v87 = v84.v1
                        v88 = v32[v86]
                        if v88.tag == 0: # call
                            v117 = 1
                        elif v88.tag == 1: # fold
                            v117 = 1
                        elif v88.tag == 2: # raiseTo_
                            v89 = (<US1_2>v88).v0
                            v90 = v2 == (<unsigned char>1)
                            v91 = v89 == v0
                            if v91:
                                v117 = 1
                            else:
                                v92 = v89 == v25
                                if v92:
                                    v117 = 1
                                else:
                                    if v90:
                                        v93 = v89 % v1
                                        v117 = v93 == (<signed short>0)
                                    else:
                                        v95 = (<signed short>2) * v19
                                        v96 = v89 - v19
                                        v97 = v95 // (<signed short>4)
                                        v98 = v96 == v97
                                        if v98:
                                            v117 = 1
                                        else:
                                            v99 = v95 // (<signed short>2)
                                            v100 = v96 == v99
                                            if v100:
                                                v117 = 1
                                            else:
                                                v101 = v95 * (<signed short>3)
                                                v102 = v101 // (<signed short>4)
                                                v103 = v96 == v102
                                                if v103:
                                                    v117 = 1
                                                else:
                                                    v104 = v96 == v95
                                                    if v104:
                                                        v117 = 1
                                                    else:
                                                        v105 = v101 // (<signed short>2)
                                                        v106 = v96 == v105
                                                        if v106:
                                                            v117 = 1
                                                        else:
                                                            v107 = v95 * (<signed short>2)
                                                            v117 = v96 == v107
                        if v117:
                            v83[v87] = v88
                            v119 = v87 + (<signed short>1)
                        else:
                            v119 = v87
                        del v88
                        v120 = v86 + (<signed short>1)
                        v84.v0 = v120
                        v84.v1 = v119
                    v121 = v84.v1
                    del v84
                    v122 = numpy.empty(v121,dtype=object)
                    v123 = Mut1((<signed short>0))
                    while method9(v121, v123):
                        v125 = v123.v0
                        v126 = v83[v125]
                        v122[v125] = v126
                        del v126
                        v127 = v125 + (<signed short>1)
                        v123.v0 = v127
                    del v83
                    del v123
                    v131 = v122
                    del v122
                else:
                    raise Exception("Invalid action restriction level.")
        del v32
        return Closure11(v9, v10, v11, v12, v5, v6, v7, v8, v13, v0, v131, v4, v1, v2, v3)
cdef object method44(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, signed char v4, signed char v5, signed char v6, numpy.ndarray[signed char,ndim=1] v7, signed char v8, signed char v9, signed char v10, unsigned char v11, signed short v12, signed char v13, signed char v14, unsigned char v15, signed short v16):
    cdef bint v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    cdef signed char v22
    cdef signed char v23
    cdef unsigned char v24
    cdef signed short v25
    v17 = v15 == (<unsigned char>0)
    if v17:
        v18, v19, v20, v21, v22, v23, v24, v25 = v13, v14, v15, v16, v9, v10, v11, v12
    else:
        v18, v19, v20, v21, v22, v23, v24, v25 = v9, v10, v11, v12, v13, v14, v15, v16
    return Closure17(v7, v0, v1, v2, v3, v4, v5, v6, v8, v22, v23, v24, v25, v18, v19, v20, v21)
cdef object method47(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, signed char v4, signed char v5, signed char v6, numpy.ndarray[signed char,ndim=1] v7, signed char v8, signed char v9, signed char v10, unsigned char v11, signed short v12, signed char v13, signed char v14, unsigned char v15):
    cdef bint v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef signed char v21
    cdef signed char v22
    cdef unsigned char v23
    cdef signed short v24
    v16 = v15 == (<unsigned char>0)
    if v16:
        v17, v18, v19, v20, v21, v22, v23, v24 = v13, v14, v15, v12, v9, v10, v11, v12
    else:
        v17, v18, v19, v20, v21, v22, v23, v24 = v9, v10, v11, v12, v13, v14, v15, v12
    return Closure17(v7, v0, v1, v2, v3, v4, v5, v6, v8, v21, v22, v23, v24, v17, v18, v19, v20)
cdef UH2 method48(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17, US1 v18, float v19, float v20, UH0 v21, float v22, float v23, UH0 v24, float v25, float v26):
    cdef object v30
    cdef bint v27
    cdef bint v32
    cdef signed short v34
    cdef float v35
    cdef signed short v37
    cdef bint v38
    cdef object v39
    if v18.tag == 0: # call
        if v0:
            v27 = 0
            v30 = method46(v8, v9, v10, v11, v27, v5, v6, v7, v4, v1, v2, v3, v12, v13, v14, v15, v16, v17)
        else:
            v30 = method47(v8, v9, v10, v11, v13, v14, v15, v16, v17, v1, v2, v3, v4, v5, v6, v7)
        return v30(v19, v20, v21, v22, v23, v24, v25, v26)
    elif v18.tag == 1: # fold
        v32 = v7 == (<unsigned char>0)
        if v32:
            v34 = -v4
        else:
            v34 = v4
        v35 = <float>v34
        return UH2_1(v19, v20, v21, v22, v23, v24, v25, v26, v5, v6, v7, v4, v1, v2, v3, v4, v12, v8, 0, v35)
    elif v18.tag == 2: # raiseTo_
        v37 = (<US1_2>v18).v0
        v38 = 0
        v39 = method43(v8, v9, v10, v11, v38, v5, v6, v7, v37, v1, v2, v3, v4, v12, v13, v14, v15, v16, v17)
        return v39(v19, v20, v21, v22, v23, v24, v25, v26)
cdef object method46(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17):
    cdef bint v18
    cdef bint v20
    cdef bint v21
    cdef bint v22
    cdef signed short v23
    cdef signed short v24
    cdef bint v25
    cdef signed short v26
    cdef bint v27
    cdef signed short v28
    cdef signed short v29
    cdef numpy.ndarray[object,ndim=1] v30
    cdef bint v31
    cdef numpy.ndarray[object,ndim=1] v129
    cdef bint v32
    cdef signed short v33
    cdef unsigned long long tmp49
    cdef numpy.ndarray[object,ndim=1] v34
    cdef Mut3 v35
    cdef signed short v37
    cdef signed short v38
    cdef US1 v39
    cdef bint v68
    cdef signed short v40
    cdef bint v41
    cdef bint v42
    cdef bint v43
    cdef signed short v44
    cdef signed short v46
    cdef signed short v47
    cdef signed short v48
    cdef bint v49
    cdef signed short v50
    cdef bint v51
    cdef signed short v52
    cdef signed short v53
    cdef bint v54
    cdef bint v55
    cdef signed short v56
    cdef bint v57
    cdef signed short v58
    cdef signed short v70
    cdef signed short v71
    cdef signed short v72
    cdef numpy.ndarray[object,ndim=1] v73
    cdef Mut1 v74
    cdef signed short v76
    cdef US1 v77
    cdef signed short v78
    cdef bint v79
    cdef signed short v80
    cdef unsigned long long tmp50
    cdef numpy.ndarray[object,ndim=1] v81
    cdef Mut3 v82
    cdef signed short v84
    cdef signed short v85
    cdef US1 v86
    cdef bint v115
    cdef signed short v87
    cdef bint v88
    cdef bint v89
    cdef bint v90
    cdef signed short v91
    cdef signed short v93
    cdef signed short v94
    cdef signed short v95
    cdef bint v96
    cdef signed short v97
    cdef bint v98
    cdef signed short v99
    cdef signed short v100
    cdef bint v101
    cdef bint v102
    cdef signed short v103
    cdef bint v104
    cdef signed short v105
    cdef signed short v117
    cdef signed short v118
    cdef signed short v119
    cdef numpy.ndarray[object,ndim=1] v120
    cdef Mut1 v121
    cdef signed short v123
    cdef US1 v124
    cdef signed short v125
    v18 = v8 == v0
    if v18:
        return method47(v0, v1, v2, v3, v13, v14, v15, v16, v17, v5, v6, v7, v8, v9, v10, v11)
    else:
        v20 = v8 >= v8
        v21 = v8 < v8
        v22 = v1 >= (<signed short>0)
        if v22:
            v23 = v1
        else:
            v23 = (<signed short>0)
        v24 = v8 + v23
        v25 = v0 < v24
        if v25:
            v26 = v0
        else:
            v26 = v24
        v27 = v0 == v8
        if v27:
            v28 = (<signed short>1)
        else:
            v28 = (<signed short>0)
        v29 = v26 + v28
        v30 = v3[(<signed short>1):3+v0-v29]
        v31 = (<unsigned char>0) == v2
        if v31:
            v129 = v30
        else:
            v32 = (<unsigned char>1) == v2
            if v32:
                tmp49 = len(v30)
                if <signed short>tmp49 != tmp49: raise Exception("The conversion to signed short failed.")
                v33 = <signed short>tmp49
                v34 = numpy.empty(v33,dtype=object)
                v35 = Mut3((<signed short>0), (<signed short>0))
                while method34(v33, v35):
                    v37 = v35.v0
                    v38 = v35.v1
                    v39 = v30[v37]
                    if v39.tag == 0: # call
                        v68 = 1
                    elif v39.tag == 1: # fold
                        v68 = 1
                    elif v39.tag == 2: # raiseTo_
                        v40 = (<US1_2>v39).v0
                        v41 = v2 == (<unsigned char>1)
                        v42 = v40 == v0
                        if v42:
                            v68 = 1
                        else:
                            v43 = v40 == v24
                            if v43:
                                v68 = 1
                            else:
                                if v41:
                                    v44 = v40 % v1
                                    v68 = v44 == (<signed short>0)
                                else:
                                    v46 = (<signed short>2) * v8
                                    v47 = v40 - v8
                                    v48 = v46 // (<signed short>4)
                                    v49 = v47 == v48
                                    if v49:
                                        v68 = 1
                                    else:
                                        v50 = v46 // (<signed short>2)
                                        v51 = v47 == v50
                                        if v51:
                                            v68 = 1
                                        else:
                                            v52 = v46 * (<signed short>3)
                                            v53 = v52 // (<signed short>4)
                                            v54 = v47 == v53
                                            if v54:
                                                v68 = 1
                                            else:
                                                v55 = v47 == v46
                                                if v55:
                                                    v68 = 1
                                                else:
                                                    v56 = v52 // (<signed short>2)
                                                    v57 = v47 == v56
                                                    if v57:
                                                        v68 = 1
                                                    else:
                                                        v58 = v46 * (<signed short>2)
                                                        v68 = v47 == v58
                    if v68:
                        v34[v38] = v39
                        v70 = v38 + (<signed short>1)
                    else:
                        v70 = v38
                    del v39
                    v71 = v37 + (<signed short>1)
                    v35.v0 = v71
                    v35.v1 = v70
                v72 = v35.v1
                del v35
                v73 = numpy.empty(v72,dtype=object)
                v74 = Mut1((<signed short>0))
                while method9(v72, v74):
                    v76 = v74.v0
                    v77 = v34[v76]
                    v73[v76] = v77
                    del v77
                    v78 = v76 + (<signed short>1)
                    v74.v0 = v78
                del v34
                del v74
                v129 = v73
                del v73
            else:
                v79 = (<unsigned char>2) == v2
                if v79:
                    tmp50 = len(v30)
                    if <signed short>tmp50 != tmp50: raise Exception("The conversion to signed short failed.")
                    v80 = <signed short>tmp50
                    v81 = numpy.empty(v80,dtype=object)
                    v82 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v80, v82):
                        v84 = v82.v0
                        v85 = v82.v1
                        v86 = v30[v84]
                        if v86.tag == 0: # call
                            v115 = 1
                        elif v86.tag == 1: # fold
                            v115 = 1
                        elif v86.tag == 2: # raiseTo_
                            v87 = (<US1_2>v86).v0
                            v88 = v2 == (<unsigned char>1)
                            v89 = v87 == v0
                            if v89:
                                v115 = 1
                            else:
                                v90 = v87 == v24
                                if v90:
                                    v115 = 1
                                else:
                                    if v88:
                                        v91 = v87 % v1
                                        v115 = v91 == (<signed short>0)
                                    else:
                                        v93 = (<signed short>2) * v8
                                        v94 = v87 - v8
                                        v95 = v93 // (<signed short>4)
                                        v96 = v94 == v95
                                        if v96:
                                            v115 = 1
                                        else:
                                            v97 = v93 // (<signed short>2)
                                            v98 = v94 == v97
                                            if v98:
                                                v115 = 1
                                            else:
                                                v99 = v93 * (<signed short>3)
                                                v100 = v99 // (<signed short>4)
                                                v101 = v94 == v100
                                                if v101:
                                                    v115 = 1
                                                else:
                                                    v102 = v94 == v93
                                                    if v102:
                                                        v115 = 1
                                                    else:
                                                        v103 = v99 // (<signed short>2)
                                                        v104 = v94 == v103
                                                        if v104:
                                                            v115 = 1
                                                        else:
                                                            v105 = v93 * (<signed short>2)
                                                            v115 = v94 == v105
                        if v115:
                            v81[v85] = v86
                            v117 = v85 + (<signed short>1)
                        else:
                            v117 = v85
                        del v86
                        v118 = v84 + (<signed short>1)
                        v82.v0 = v118
                        v82.v1 = v117
                    v119 = v82.v1
                    del v82
                    v120 = numpy.empty(v119,dtype=object)
                    v121 = Mut1((<signed short>0))
                    while method9(v119, v121):
                        v123 = v121.v0
                        v124 = v81[v123]
                        v120[v123] = v124
                        del v124
                        v125 = v123 + (<signed short>1)
                        v121.v0 = v125
                    del v81
                    del v121
                    v129 = v120
                    del v120
                else:
                    raise Exception("Invalid action restriction level.")
        del v30
        return Closure20(v9, v10, v11, v8, v5, v6, v7, v12, v0, v129, v4, v1, v2, v3, v13, v14, v15, v16, v17)
cdef UH2 method45(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, signed char v15, signed char v16, numpy.ndarray[signed char,ndim=1] v17, signed char v18, US1 v19, float v20, float v21, UH0 v22, float v23, float v24, UH0 v25, float v26, float v27):
    cdef object v31
    cdef bint v28
    cdef bint v33
    cdef signed short v35
    cdef float v36
    cdef signed short v38
    cdef bint v39
    cdef object v40
    if v19.tag == 0: # call
        if v0:
            v28 = 0
            v31 = method46(v9, v10, v11, v12, v28, v5, v6, v7, v4, v1, v2, v3, v13, v14, v15, v16, v17, v18)
        else:
            v31 = method47(v9, v10, v11, v12, v14, v15, v16, v17, v18, v1, v2, v3, v4, v5, v6, v7)
        return v31(v20, v21, v22, v23, v24, v25, v26, v27)
    elif v19.tag == 1: # fold
        v33 = v7 == (<unsigned char>0)
        if v33:
            v35 = -v8
        else:
            v35 = v8
        v36 = <float>v35
        return UH2_1(v20, v21, v22, v23, v24, v25, v26, v27, v5, v6, v7, v8, v1, v2, v3, v4, v13, v9, 0, v36)
    elif v19.tag == 2: # raiseTo_
        v38 = (<US1_2>v19).v0
        v39 = 0
        v40 = method43(v9, v10, v11, v12, v39, v5, v6, v7, v38, v1, v2, v3, v4, v13, v14, v15, v16, v17, v18)
        return v40(v20, v21, v22, v23, v24, v25, v26, v27)
cdef object method43(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, signed char v15, signed char v16, numpy.ndarray[signed char,ndim=1] v17, signed char v18):
    cdef bint v19
    cdef bint v21
    cdef bint v22
    cdef bint v23
    cdef signed short v24
    cdef bint v25
    cdef signed short v26
    cdef signed short v27
    cdef bint v28
    cdef signed short v29
    cdef signed short v30
    cdef signed short v31
    cdef bint v32
    cdef signed short v33
    cdef bint v34
    cdef signed short v35
    cdef signed short v36
    cdef numpy.ndarray[object,ndim=1] v37
    cdef bint v38
    cdef numpy.ndarray[object,ndim=1] v136
    cdef bint v39
    cdef signed short v40
    cdef unsigned long long tmp47
    cdef numpy.ndarray[object,ndim=1] v41
    cdef Mut3 v42
    cdef signed short v44
    cdef signed short v45
    cdef US1 v46
    cdef bint v75
    cdef signed short v47
    cdef bint v48
    cdef bint v49
    cdef bint v50
    cdef signed short v51
    cdef signed short v53
    cdef signed short v54
    cdef signed short v55
    cdef bint v56
    cdef signed short v57
    cdef bint v58
    cdef signed short v59
    cdef signed short v60
    cdef bint v61
    cdef bint v62
    cdef signed short v63
    cdef bint v64
    cdef signed short v65
    cdef signed short v77
    cdef signed short v78
    cdef signed short v79
    cdef numpy.ndarray[object,ndim=1] v80
    cdef Mut1 v81
    cdef signed short v83
    cdef US1 v84
    cdef signed short v85
    cdef bint v86
    cdef signed short v87
    cdef unsigned long long tmp48
    cdef numpy.ndarray[object,ndim=1] v88
    cdef Mut3 v89
    cdef signed short v91
    cdef signed short v92
    cdef US1 v93
    cdef bint v122
    cdef signed short v94
    cdef bint v95
    cdef bint v96
    cdef bint v97
    cdef signed short v98
    cdef signed short v100
    cdef signed short v101
    cdef signed short v102
    cdef bint v103
    cdef signed short v104
    cdef bint v105
    cdef signed short v106
    cdef signed short v107
    cdef bint v108
    cdef bint v109
    cdef signed short v110
    cdef bint v111
    cdef signed short v112
    cdef signed short v124
    cdef signed short v125
    cdef signed short v126
    cdef numpy.ndarray[object,ndim=1] v127
    cdef Mut1 v128
    cdef signed short v130
    cdef US1 v131
    cdef signed short v132
    v19 = v12 == v0
    if v19:
        return method44(v0, v1, v2, v3, v14, v15, v16, v17, v18, v5, v6, v7, v8, v9, v10, v11, v12)
    else:
        v21 = v12 == v8
        v22 = v21 != 1
        v23 = v12 >= v8
        if v23:
            v24 = v12
        else:
            v24 = v8
        v25 = v12 < v8
        if v25:
            v26 = v12
        else:
            v26 = v8
        v27 = v24 - v26
        v28 = v1 >= v27
        if v28:
            v29 = v1
        else:
            v29 = v27
        v30 = v24 + v29
        if v22:
            v31 = (<signed short>0)
        else:
            v31 = (<signed short>1)
        v32 = v0 < v30
        if v32:
            v33 = v0
        else:
            v33 = v30
        v34 = v0 == v24
        if v34:
            v35 = (<signed short>1)
        else:
            v35 = (<signed short>0)
        v36 = v33 + v35
        v37 = v3[v31:3+v0-v36]
        v38 = (<unsigned char>0) == v2
        if v38:
            v136 = v37
        else:
            v39 = (<unsigned char>1) == v2
            if v39:
                tmp47 = len(v37)
                if <signed short>tmp47 != tmp47: raise Exception("The conversion to signed short failed.")
                v40 = <signed short>tmp47
                v41 = numpy.empty(v40,dtype=object)
                v42 = Mut3((<signed short>0), (<signed short>0))
                while method34(v40, v42):
                    v44 = v42.v0
                    v45 = v42.v1
                    v46 = v37[v44]
                    if v46.tag == 0: # call
                        v75 = 1
                    elif v46.tag == 1: # fold
                        v75 = 1
                    elif v46.tag == 2: # raiseTo_
                        v47 = (<US1_2>v46).v0
                        v48 = v2 == (<unsigned char>1)
                        v49 = v47 == v0
                        if v49:
                            v75 = 1
                        else:
                            v50 = v47 == v30
                            if v50:
                                v75 = 1
                            else:
                                if v48:
                                    v51 = v47 % v1
                                    v75 = v51 == (<signed short>0)
                                else:
                                    v53 = (<signed short>2) * v24
                                    v54 = v47 - v24
                                    v55 = v53 // (<signed short>4)
                                    v56 = v54 == v55
                                    if v56:
                                        v75 = 1
                                    else:
                                        v57 = v53 // (<signed short>2)
                                        v58 = v54 == v57
                                        if v58:
                                            v75 = 1
                                        else:
                                            v59 = v53 * (<signed short>3)
                                            v60 = v59 // (<signed short>4)
                                            v61 = v54 == v60
                                            if v61:
                                                v75 = 1
                                            else:
                                                v62 = v54 == v53
                                                if v62:
                                                    v75 = 1
                                                else:
                                                    v63 = v59 // (<signed short>2)
                                                    v64 = v54 == v63
                                                    if v64:
                                                        v75 = 1
                                                    else:
                                                        v65 = v53 * (<signed short>2)
                                                        v75 = v54 == v65
                    if v75:
                        v41[v45] = v46
                        v77 = v45 + (<signed short>1)
                    else:
                        v77 = v45
                    del v46
                    v78 = v44 + (<signed short>1)
                    v42.v0 = v78
                    v42.v1 = v77
                v79 = v42.v1
                del v42
                v80 = numpy.empty(v79,dtype=object)
                v81 = Mut1((<signed short>0))
                while method9(v79, v81):
                    v83 = v81.v0
                    v84 = v41[v83]
                    v80[v83] = v84
                    del v84
                    v85 = v83 + (<signed short>1)
                    v81.v0 = v85
                del v41
                del v81
                v136 = v80
                del v80
            else:
                v86 = (<unsigned char>2) == v2
                if v86:
                    tmp48 = len(v37)
                    if <signed short>tmp48 != tmp48: raise Exception("The conversion to signed short failed.")
                    v87 = <signed short>tmp48
                    v88 = numpy.empty(v87,dtype=object)
                    v89 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v87, v89):
                        v91 = v89.v0
                        v92 = v89.v1
                        v93 = v37[v91]
                        if v93.tag == 0: # call
                            v122 = 1
                        elif v93.tag == 1: # fold
                            v122 = 1
                        elif v93.tag == 2: # raiseTo_
                            v94 = (<US1_2>v93).v0
                            v95 = v2 == (<unsigned char>1)
                            v96 = v94 == v0
                            if v96:
                                v122 = 1
                            else:
                                v97 = v94 == v30
                                if v97:
                                    v122 = 1
                                else:
                                    if v95:
                                        v98 = v94 % v1
                                        v122 = v98 == (<signed short>0)
                                    else:
                                        v100 = (<signed short>2) * v24
                                        v101 = v94 - v24
                                        v102 = v100 // (<signed short>4)
                                        v103 = v101 == v102
                                        if v103:
                                            v122 = 1
                                        else:
                                            v104 = v100 // (<signed short>2)
                                            v105 = v101 == v104
                                            if v105:
                                                v122 = 1
                                            else:
                                                v106 = v100 * (<signed short>3)
                                                v107 = v106 // (<signed short>4)
                                                v108 = v101 == v107
                                                if v108:
                                                    v122 = 1
                                                else:
                                                    v109 = v101 == v100
                                                    if v109:
                                                        v122 = 1
                                                    else:
                                                        v110 = v106 // (<signed short>2)
                                                        v111 = v101 == v110
                                                        if v111:
                                                            v122 = 1
                                                        else:
                                                            v112 = v100 * (<signed short>2)
                                                            v122 = v101 == v112
                        if v122:
                            v88[v92] = v93
                            v124 = v92 + (<signed short>1)
                        else:
                            v124 = v92
                        del v93
                        v125 = v91 + (<signed short>1)
                        v89.v0 = v125
                        v89.v1 = v124
                    v126 = v89.v1
                    del v89
                    v127 = numpy.empty(v126,dtype=object)
                    v128 = Mut1((<signed short>0))
                    while method9(v126, v128):
                        v130 = v128.v0
                        v131 = v88[v130]
                        v127[v130] = v131
                        del v131
                        v132 = v130 + (<signed short>1)
                        v128.v0 = v132
                    del v88
                    del v128
                    v136 = v127
                    del v127
                else:
                    raise Exception("Invalid action restriction level.")
        del v37
        return Closure18(v9, v10, v11, v12, v5, v6, v7, v8, v13, v0, v136, v4, v1, v2, v3, v14, v15, v16, v17, v18)
cdef object method42(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, signed char v4, signed char v5, numpy.ndarray[signed char,ndim=1] v6, signed char v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14, signed short v15):
    cdef bint v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef signed char v21
    cdef signed char v22
    cdef unsigned char v23
    cdef signed short v24
    v16 = v14 == (<unsigned char>0)
    if v16:
        v17, v18, v19, v20, v21, v22, v23, v24 = v12, v13, v14, v15, v8, v9, v10, v11
    else:
        v17, v18, v19, v20, v21, v22, v23, v24 = v8, v9, v10, v11, v12, v13, v14, v15
    return Closure16(v6, v0, v1, v2, v3, v4, v5, v7, v21, v22, v23, v24, v17, v18, v19, v20)
cdef object method51(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, signed char v4, signed char v5, numpy.ndarray[signed char,ndim=1] v6, signed char v7, signed char v8, signed char v9, unsigned char v10, signed short v11, signed char v12, signed char v13, unsigned char v14):
    cdef bint v15
    cdef signed char v16
    cdef signed char v17
    cdef unsigned char v18
    cdef signed short v19
    cdef signed char v20
    cdef signed char v21
    cdef unsigned char v22
    cdef signed short v23
    v15 = v14 == (<unsigned char>0)
    if v15:
        v16, v17, v18, v19, v20, v21, v22, v23 = v12, v13, v14, v11, v8, v9, v10, v11
    else:
        v16, v17, v18, v19, v20, v21, v22, v23 = v8, v9, v10, v11, v12, v13, v14, v11
    return Closure16(v6, v0, v1, v2, v3, v4, v5, v7, v20, v21, v22, v23, v16, v17, v18, v19)
cdef UH2 method52(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
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
            v29 = method50(v8, v9, v10, v11, v26, v5, v6, v7, v4, v1, v2, v3, v12, v13, v14, v15, v16)
        else:
            v29 = method51(v8, v9, v10, v11, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
        return v29(v18, v19, v20, v21, v22, v23, v24, v25)
    elif v17.tag == 1: # fold
        v31 = v7 == (<unsigned char>0)
        if v31:
            v33 = -v4
        else:
            v33 = v4
        v34 = <float>v33
        return UH2_1(v18, v19, v20, v21, v22, v23, v24, v25, v5, v6, v7, v4, v1, v2, v3, v4, v12, v8, 0, v34)
    elif v17.tag == 2: # raiseTo_
        v36 = (<US1_2>v17).v0
        v37 = 0
        v38 = method41(v8, v9, v10, v11, v37, v5, v6, v7, v36, v1, v2, v3, v4, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method50(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16):
    cdef bint v17
    cdef bint v19
    cdef bint v20
    cdef bint v21
    cdef signed short v22
    cdef signed short v23
    cdef bint v24
    cdef signed short v25
    cdef bint v26
    cdef signed short v27
    cdef signed short v28
    cdef numpy.ndarray[object,ndim=1] v29
    cdef bint v30
    cdef numpy.ndarray[object,ndim=1] v128
    cdef bint v31
    cdef signed short v32
    cdef unsigned long long tmp53
    cdef numpy.ndarray[object,ndim=1] v33
    cdef Mut3 v34
    cdef signed short v36
    cdef signed short v37
    cdef US1 v38
    cdef bint v67
    cdef signed short v39
    cdef bint v40
    cdef bint v41
    cdef bint v42
    cdef signed short v43
    cdef signed short v45
    cdef signed short v46
    cdef signed short v47
    cdef bint v48
    cdef signed short v49
    cdef bint v50
    cdef signed short v51
    cdef signed short v52
    cdef bint v53
    cdef bint v54
    cdef signed short v55
    cdef bint v56
    cdef signed short v57
    cdef signed short v69
    cdef signed short v70
    cdef signed short v71
    cdef numpy.ndarray[object,ndim=1] v72
    cdef Mut1 v73
    cdef signed short v75
    cdef US1 v76
    cdef signed short v77
    cdef bint v78
    cdef signed short v79
    cdef unsigned long long tmp54
    cdef numpy.ndarray[object,ndim=1] v80
    cdef Mut3 v81
    cdef signed short v83
    cdef signed short v84
    cdef US1 v85
    cdef bint v114
    cdef signed short v86
    cdef bint v87
    cdef bint v88
    cdef bint v89
    cdef signed short v90
    cdef signed short v92
    cdef signed short v93
    cdef signed short v94
    cdef bint v95
    cdef signed short v96
    cdef bint v97
    cdef signed short v98
    cdef signed short v99
    cdef bint v100
    cdef bint v101
    cdef signed short v102
    cdef bint v103
    cdef signed short v104
    cdef signed short v116
    cdef signed short v117
    cdef signed short v118
    cdef numpy.ndarray[object,ndim=1] v119
    cdef Mut1 v120
    cdef signed short v122
    cdef US1 v123
    cdef signed short v124
    v17 = v8 == v0
    if v17:
        return method51(v0, v1, v2, v3, v13, v14, v15, v16, v5, v6, v7, v8, v9, v10, v11)
    else:
        v19 = v8 >= v8
        v20 = v8 < v8
        v21 = v1 >= (<signed short>0)
        if v21:
            v22 = v1
        else:
            v22 = (<signed short>0)
        v23 = v8 + v22
        v24 = v0 < v23
        if v24:
            v25 = v0
        else:
            v25 = v23
        v26 = v0 == v8
        if v26:
            v27 = (<signed short>1)
        else:
            v27 = (<signed short>0)
        v28 = v25 + v27
        v29 = v3[(<signed short>1):3+v0-v28]
        v30 = (<unsigned char>0) == v2
        if v30:
            v128 = v29
        else:
            v31 = (<unsigned char>1) == v2
            if v31:
                tmp53 = len(v29)
                if <signed short>tmp53 != tmp53: raise Exception("The conversion to signed short failed.")
                v32 = <signed short>tmp53
                v33 = numpy.empty(v32,dtype=object)
                v34 = Mut3((<signed short>0), (<signed short>0))
                while method34(v32, v34):
                    v36 = v34.v0
                    v37 = v34.v1
                    v38 = v29[v36]
                    if v38.tag == 0: # call
                        v67 = 1
                    elif v38.tag == 1: # fold
                        v67 = 1
                    elif v38.tag == 2: # raiseTo_
                        v39 = (<US1_2>v38).v0
                        v40 = v2 == (<unsigned char>1)
                        v41 = v39 == v0
                        if v41:
                            v67 = 1
                        else:
                            v42 = v39 == v23
                            if v42:
                                v67 = 1
                            else:
                                if v40:
                                    v43 = v39 % v1
                                    v67 = v43 == (<signed short>0)
                                else:
                                    v45 = (<signed short>2) * v8
                                    v46 = v39 - v8
                                    v47 = v45 // (<signed short>4)
                                    v48 = v46 == v47
                                    if v48:
                                        v67 = 1
                                    else:
                                        v49 = v45 // (<signed short>2)
                                        v50 = v46 == v49
                                        if v50:
                                            v67 = 1
                                        else:
                                            v51 = v45 * (<signed short>3)
                                            v52 = v51 // (<signed short>4)
                                            v53 = v46 == v52
                                            if v53:
                                                v67 = 1
                                            else:
                                                v54 = v46 == v45
                                                if v54:
                                                    v67 = 1
                                                else:
                                                    v55 = v51 // (<signed short>2)
                                                    v56 = v46 == v55
                                                    if v56:
                                                        v67 = 1
                                                    else:
                                                        v57 = v45 * (<signed short>2)
                                                        v67 = v46 == v57
                    if v67:
                        v33[v37] = v38
                        v69 = v37 + (<signed short>1)
                    else:
                        v69 = v37
                    del v38
                    v70 = v36 + (<signed short>1)
                    v34.v0 = v70
                    v34.v1 = v69
                v71 = v34.v1
                del v34
                v72 = numpy.empty(v71,dtype=object)
                v73 = Mut1((<signed short>0))
                while method9(v71, v73):
                    v75 = v73.v0
                    v76 = v33[v75]
                    v72[v75] = v76
                    del v76
                    v77 = v75 + (<signed short>1)
                    v73.v0 = v77
                del v33
                del v73
                v128 = v72
                del v72
            else:
                v78 = (<unsigned char>2) == v2
                if v78:
                    tmp54 = len(v29)
                    if <signed short>tmp54 != tmp54: raise Exception("The conversion to signed short failed.")
                    v79 = <signed short>tmp54
                    v80 = numpy.empty(v79,dtype=object)
                    v81 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v79, v81):
                        v83 = v81.v0
                        v84 = v81.v1
                        v85 = v29[v83]
                        if v85.tag == 0: # call
                            v114 = 1
                        elif v85.tag == 1: # fold
                            v114 = 1
                        elif v85.tag == 2: # raiseTo_
                            v86 = (<US1_2>v85).v0
                            v87 = v2 == (<unsigned char>1)
                            v88 = v86 == v0
                            if v88:
                                v114 = 1
                            else:
                                v89 = v86 == v23
                                if v89:
                                    v114 = 1
                                else:
                                    if v87:
                                        v90 = v86 % v1
                                        v114 = v90 == (<signed short>0)
                                    else:
                                        v92 = (<signed short>2) * v8
                                        v93 = v86 - v8
                                        v94 = v92 // (<signed short>4)
                                        v95 = v93 == v94
                                        if v95:
                                            v114 = 1
                                        else:
                                            v96 = v92 // (<signed short>2)
                                            v97 = v93 == v96
                                            if v97:
                                                v114 = 1
                                            else:
                                                v98 = v92 * (<signed short>3)
                                                v99 = v98 // (<signed short>4)
                                                v100 = v93 == v99
                                                if v100:
                                                    v114 = 1
                                                else:
                                                    v101 = v93 == v92
                                                    if v101:
                                                        v114 = 1
                                                    else:
                                                        v102 = v98 // (<signed short>2)
                                                        v103 = v93 == v102
                                                        if v103:
                                                            v114 = 1
                                                        else:
                                                            v104 = v92 * (<signed short>2)
                                                            v114 = v93 == v104
                        if v114:
                            v80[v84] = v85
                            v116 = v84 + (<signed short>1)
                        else:
                            v116 = v84
                        del v85
                        v117 = v83 + (<signed short>1)
                        v81.v0 = v117
                        v81.v1 = v116
                    v118 = v81.v1
                    del v81
                    v119 = numpy.empty(v118,dtype=object)
                    v120 = Mut1((<signed short>0))
                    while method9(v118, v120):
                        v122 = v120.v0
                        v123 = v80[v122]
                        v119[v122] = v123
                        del v123
                        v124 = v122 + (<signed short>1)
                        v120.v0 = v124
                    del v80
                    del v120
                    v128 = v119
                    del v119
                else:
                    raise Exception("Invalid action restriction level.")
        del v29
        return Closure24(v9, v10, v11, v8, v5, v6, v7, v12, v0, v128, v4, v1, v2, v3, v13, v14, v15, v16)
cdef UH2 method49(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17, US1 v18, float v19, float v20, UH0 v21, float v22, float v23, UH0 v24, float v25, float v26):
    cdef object v30
    cdef bint v27
    cdef bint v32
    cdef signed short v34
    cdef float v35
    cdef signed short v37
    cdef bint v38
    cdef object v39
    if v18.tag == 0: # call
        if v0:
            v27 = 0
            v30 = method50(v9, v10, v11, v12, v27, v5, v6, v7, v4, v1, v2, v3, v13, v14, v15, v16, v17)
        else:
            v30 = method51(v9, v10, v11, v12, v14, v15, v16, v17, v1, v2, v3, v4, v5, v6, v7)
        return v30(v19, v20, v21, v22, v23, v24, v25, v26)
    elif v18.tag == 1: # fold
        v32 = v7 == (<unsigned char>0)
        if v32:
            v34 = -v8
        else:
            v34 = v8
        v35 = <float>v34
        return UH2_1(v19, v20, v21, v22, v23, v24, v25, v26, v5, v6, v7, v8, v1, v2, v3, v4, v13, v9, 0, v35)
    elif v18.tag == 2: # raiseTo_
        v37 = (<US1_2>v18).v0
        v38 = 0
        v39 = method41(v9, v10, v11, v12, v38, v5, v6, v7, v37, v1, v2, v3, v4, v13, v14, v15, v16, v17)
        return v39(v19, v20, v21, v22, v23, v24, v25, v26)
cdef object method41(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, signed char v15, numpy.ndarray[signed char,ndim=1] v16, signed char v17):
    cdef bint v18
    cdef bint v20
    cdef bint v21
    cdef bint v22
    cdef signed short v23
    cdef bint v24
    cdef signed short v25
    cdef signed short v26
    cdef bint v27
    cdef signed short v28
    cdef signed short v29
    cdef signed short v30
    cdef bint v31
    cdef signed short v32
    cdef bint v33
    cdef signed short v34
    cdef signed short v35
    cdef numpy.ndarray[object,ndim=1] v36
    cdef bint v37
    cdef numpy.ndarray[object,ndim=1] v135
    cdef bint v38
    cdef signed short v39
    cdef unsigned long long tmp51
    cdef numpy.ndarray[object,ndim=1] v40
    cdef Mut3 v41
    cdef signed short v43
    cdef signed short v44
    cdef US1 v45
    cdef bint v74
    cdef signed short v46
    cdef bint v47
    cdef bint v48
    cdef bint v49
    cdef signed short v50
    cdef signed short v52
    cdef signed short v53
    cdef signed short v54
    cdef bint v55
    cdef signed short v56
    cdef bint v57
    cdef signed short v58
    cdef signed short v59
    cdef bint v60
    cdef bint v61
    cdef signed short v62
    cdef bint v63
    cdef signed short v64
    cdef signed short v76
    cdef signed short v77
    cdef signed short v78
    cdef numpy.ndarray[object,ndim=1] v79
    cdef Mut1 v80
    cdef signed short v82
    cdef US1 v83
    cdef signed short v84
    cdef bint v85
    cdef signed short v86
    cdef unsigned long long tmp52
    cdef numpy.ndarray[object,ndim=1] v87
    cdef Mut3 v88
    cdef signed short v90
    cdef signed short v91
    cdef US1 v92
    cdef bint v121
    cdef signed short v93
    cdef bint v94
    cdef bint v95
    cdef bint v96
    cdef signed short v97
    cdef signed short v99
    cdef signed short v100
    cdef signed short v101
    cdef bint v102
    cdef signed short v103
    cdef bint v104
    cdef signed short v105
    cdef signed short v106
    cdef bint v107
    cdef bint v108
    cdef signed short v109
    cdef bint v110
    cdef signed short v111
    cdef signed short v123
    cdef signed short v124
    cdef signed short v125
    cdef numpy.ndarray[object,ndim=1] v126
    cdef Mut1 v127
    cdef signed short v129
    cdef US1 v130
    cdef signed short v131
    v18 = v12 == v0
    if v18:
        return method42(v0, v1, v2, v3, v14, v15, v16, v17, v5, v6, v7, v8, v9, v10, v11, v12)
    else:
        v20 = v12 == v8
        v21 = v20 != 1
        v22 = v12 >= v8
        if v22:
            v23 = v12
        else:
            v23 = v8
        v24 = v12 < v8
        if v24:
            v25 = v12
        else:
            v25 = v8
        v26 = v23 - v25
        v27 = v1 >= v26
        if v27:
            v28 = v1
        else:
            v28 = v26
        v29 = v23 + v28
        if v21:
            v30 = (<signed short>0)
        else:
            v30 = (<signed short>1)
        v31 = v0 < v29
        if v31:
            v32 = v0
        else:
            v32 = v29
        v33 = v0 == v23
        if v33:
            v34 = (<signed short>1)
        else:
            v34 = (<signed short>0)
        v35 = v32 + v34
        v36 = v3[v30:3+v0-v35]
        v37 = (<unsigned char>0) == v2
        if v37:
            v135 = v36
        else:
            v38 = (<unsigned char>1) == v2
            if v38:
                tmp51 = len(v36)
                if <signed short>tmp51 != tmp51: raise Exception("The conversion to signed short failed.")
                v39 = <signed short>tmp51
                v40 = numpy.empty(v39,dtype=object)
                v41 = Mut3((<signed short>0), (<signed short>0))
                while method34(v39, v41):
                    v43 = v41.v0
                    v44 = v41.v1
                    v45 = v36[v43]
                    if v45.tag == 0: # call
                        v74 = 1
                    elif v45.tag == 1: # fold
                        v74 = 1
                    elif v45.tag == 2: # raiseTo_
                        v46 = (<US1_2>v45).v0
                        v47 = v2 == (<unsigned char>1)
                        v48 = v46 == v0
                        if v48:
                            v74 = 1
                        else:
                            v49 = v46 == v29
                            if v49:
                                v74 = 1
                            else:
                                if v47:
                                    v50 = v46 % v1
                                    v74 = v50 == (<signed short>0)
                                else:
                                    v52 = (<signed short>2) * v23
                                    v53 = v46 - v23
                                    v54 = v52 // (<signed short>4)
                                    v55 = v53 == v54
                                    if v55:
                                        v74 = 1
                                    else:
                                        v56 = v52 // (<signed short>2)
                                        v57 = v53 == v56
                                        if v57:
                                            v74 = 1
                                        else:
                                            v58 = v52 * (<signed short>3)
                                            v59 = v58 // (<signed short>4)
                                            v60 = v53 == v59
                                            if v60:
                                                v74 = 1
                                            else:
                                                v61 = v53 == v52
                                                if v61:
                                                    v74 = 1
                                                else:
                                                    v62 = v58 // (<signed short>2)
                                                    v63 = v53 == v62
                                                    if v63:
                                                        v74 = 1
                                                    else:
                                                        v64 = v52 * (<signed short>2)
                                                        v74 = v53 == v64
                    if v74:
                        v40[v44] = v45
                        v76 = v44 + (<signed short>1)
                    else:
                        v76 = v44
                    del v45
                    v77 = v43 + (<signed short>1)
                    v41.v0 = v77
                    v41.v1 = v76
                v78 = v41.v1
                del v41
                v79 = numpy.empty(v78,dtype=object)
                v80 = Mut1((<signed short>0))
                while method9(v78, v80):
                    v82 = v80.v0
                    v83 = v40[v82]
                    v79[v82] = v83
                    del v83
                    v84 = v82 + (<signed short>1)
                    v80.v0 = v84
                del v40
                del v80
                v135 = v79
                del v79
            else:
                v85 = (<unsigned char>2) == v2
                if v85:
                    tmp52 = len(v36)
                    if <signed short>tmp52 != tmp52: raise Exception("The conversion to signed short failed.")
                    v86 = <signed short>tmp52
                    v87 = numpy.empty(v86,dtype=object)
                    v88 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v86, v88):
                        v90 = v88.v0
                        v91 = v88.v1
                        v92 = v36[v90]
                        if v92.tag == 0: # call
                            v121 = 1
                        elif v92.tag == 1: # fold
                            v121 = 1
                        elif v92.tag == 2: # raiseTo_
                            v93 = (<US1_2>v92).v0
                            v94 = v2 == (<unsigned char>1)
                            v95 = v93 == v0
                            if v95:
                                v121 = 1
                            else:
                                v96 = v93 == v29
                                if v96:
                                    v121 = 1
                                else:
                                    if v94:
                                        v97 = v93 % v1
                                        v121 = v97 == (<signed short>0)
                                    else:
                                        v99 = (<signed short>2) * v23
                                        v100 = v93 - v23
                                        v101 = v99 // (<signed short>4)
                                        v102 = v100 == v101
                                        if v102:
                                            v121 = 1
                                        else:
                                            v103 = v99 // (<signed short>2)
                                            v104 = v100 == v103
                                            if v104:
                                                v121 = 1
                                            else:
                                                v105 = v99 * (<signed short>3)
                                                v106 = v105 // (<signed short>4)
                                                v107 = v100 == v106
                                                if v107:
                                                    v121 = 1
                                                else:
                                                    v108 = v100 == v99
                                                    if v108:
                                                        v121 = 1
                                                    else:
                                                        v109 = v105 // (<signed short>2)
                                                        v110 = v100 == v109
                                                        if v110:
                                                            v121 = 1
                                                        else:
                                                            v111 = v99 * (<signed short>2)
                                                            v121 = v100 == v111
                        if v121:
                            v87[v91] = v92
                            v123 = v91 + (<signed short>1)
                        else:
                            v123 = v91
                        del v92
                        v124 = v90 + (<signed short>1)
                        v88.v0 = v124
                        v88.v1 = v123
                    v125 = v88.v1
                    del v88
                    v126 = numpy.empty(v125,dtype=object)
                    v127 = Mut1((<signed short>0))
                    while method9(v125, v127):
                        v129 = v127.v0
                        v130 = v87[v129]
                        v126[v129] = v130
                        del v130
                        v131 = v129 + (<signed short>1)
                        v127.v0 = v131
                    del v87
                    del v127
                    v135 = v126
                    del v126
                else:
                    raise Exception("Invalid action restriction level.")
        del v36
        return Closure22(v9, v10, v11, v12, v5, v6, v7, v8, v13, v0, v135, v4, v1, v2, v3, v14, v15, v16, v17)
cdef object method40(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12):
    cdef bint v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef signed char v18
    cdef signed char v19
    cdef unsigned char v20
    cdef signed short v21
    v13 = v11 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v9, v10, v11, v12, v5, v6, v7, v8
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v5, v6, v7, v8, v9, v10, v11, v12
    return Closure15(v4, v0, v1, v2, v3, v18, v19, v20, v21, v14, v15, v16, v17)
cdef object method55(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    v12 = v11 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v9, v10, v11, v8, v5, v6, v7, v8
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v5, v6, v7, v8, v9, v10, v11, v8
    return Closure15(v4, v0, v1, v2, v3, v17, v18, v19, v20, v13, v14, v15, v16)
cdef UH2 method56(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, unsigned char v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, US1 v14, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
    cdef object v26
    cdef bint v23
    cdef bint v28
    cdef signed short v30
    cdef float v31
    cdef signed short v33
    cdef bint v34
    cdef object v35
    if v14.tag == 0: # call
        if v0:
            v23 = 0
            v26 = method54(v8, v9, v10, v11, v23, v5, v6, v7, v4, v1, v2, v3, v12, v13)
        else:
            v26 = method55(v8, v9, v10, v11, v13, v1, v2, v3, v4, v5, v6, v7)
        return v26(v15, v16, v17, v18, v19, v20, v21, v22)
    elif v14.tag == 1: # fold
        v28 = v7 == (<unsigned char>0)
        if v28:
            v30 = -v4
        else:
            v30 = v4
        v31 = <float>v30
        return UH2_1(v15, v16, v17, v18, v19, v20, v21, v22, v5, v6, v7, v4, v1, v2, v3, v4, v12, v8, 0, v31)
    elif v14.tag == 2: # raiseTo_
        v33 = (<US1_2>v14).v0
        v34 = 0
        v35 = method39(v8, v9, v10, v11, v34, v5, v6, v7, v33, v1, v2, v3, v4, v12, v13)
        return v35(v15, v16, v17, v18, v19, v20, v21, v22)
cdef object method54(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, numpy.ndarray[signed char,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13):
    cdef bint v14
    cdef bint v16
    cdef bint v17
    cdef bint v18
    cdef signed short v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef bint v23
    cdef signed short v24
    cdef signed short v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef bint v27
    cdef numpy.ndarray[object,ndim=1] v125
    cdef bint v28
    cdef signed short v29
    cdef unsigned long long tmp57
    cdef numpy.ndarray[object,ndim=1] v30
    cdef Mut3 v31
    cdef signed short v33
    cdef signed short v34
    cdef US1 v35
    cdef bint v64
    cdef signed short v36
    cdef bint v37
    cdef bint v38
    cdef bint v39
    cdef signed short v40
    cdef signed short v42
    cdef signed short v43
    cdef signed short v44
    cdef bint v45
    cdef signed short v46
    cdef bint v47
    cdef signed short v48
    cdef signed short v49
    cdef bint v50
    cdef bint v51
    cdef signed short v52
    cdef bint v53
    cdef signed short v54
    cdef signed short v66
    cdef signed short v67
    cdef signed short v68
    cdef numpy.ndarray[object,ndim=1] v69
    cdef Mut1 v70
    cdef signed short v72
    cdef US1 v73
    cdef signed short v74
    cdef bint v75
    cdef signed short v76
    cdef unsigned long long tmp58
    cdef numpy.ndarray[object,ndim=1] v77
    cdef Mut3 v78
    cdef signed short v80
    cdef signed short v81
    cdef US1 v82
    cdef bint v111
    cdef signed short v83
    cdef bint v84
    cdef bint v85
    cdef bint v86
    cdef signed short v87
    cdef signed short v89
    cdef signed short v90
    cdef signed short v91
    cdef bint v92
    cdef signed short v93
    cdef bint v94
    cdef signed short v95
    cdef signed short v96
    cdef bint v97
    cdef bint v98
    cdef signed short v99
    cdef bint v100
    cdef signed short v101
    cdef signed short v113
    cdef signed short v114
    cdef signed short v115
    cdef numpy.ndarray[object,ndim=1] v116
    cdef Mut1 v117
    cdef signed short v119
    cdef US1 v120
    cdef signed short v121
    v14 = v8 == v0
    if v14:
        return method55(v0, v1, v2, v3, v13, v5, v6, v7, v8, v9, v10, v11)
    else:
        v16 = v8 >= v8
        v17 = v8 < v8
        v18 = v1 >= (<signed short>0)
        if v18:
            v19 = v1
        else:
            v19 = (<signed short>0)
        v20 = v8 + v19
        v21 = v0 < v20
        if v21:
            v22 = v0
        else:
            v22 = v20
        v23 = v0 == v8
        if v23:
            v24 = (<signed short>1)
        else:
            v24 = (<signed short>0)
        v25 = v22 + v24
        v26 = v3[(<signed short>1):3+v0-v25]
        v27 = (<unsigned char>0) == v2
        if v27:
            v125 = v26
        else:
            v28 = (<unsigned char>1) == v2
            if v28:
                tmp57 = len(v26)
                if <signed short>tmp57 != tmp57: raise Exception("The conversion to signed short failed.")
                v29 = <signed short>tmp57
                v30 = numpy.empty(v29,dtype=object)
                v31 = Mut3((<signed short>0), (<signed short>0))
                while method34(v29, v31):
                    v33 = v31.v0
                    v34 = v31.v1
                    v35 = v26[v33]
                    if v35.tag == 0: # call
                        v64 = 1
                    elif v35.tag == 1: # fold
                        v64 = 1
                    elif v35.tag == 2: # raiseTo_
                        v36 = (<US1_2>v35).v0
                        v37 = v2 == (<unsigned char>1)
                        v38 = v36 == v0
                        if v38:
                            v64 = 1
                        else:
                            v39 = v36 == v20
                            if v39:
                                v64 = 1
                            else:
                                if v37:
                                    v40 = v36 % v1
                                    v64 = v40 == (<signed short>0)
                                else:
                                    v42 = (<signed short>2) * v8
                                    v43 = v36 - v8
                                    v44 = v42 // (<signed short>4)
                                    v45 = v43 == v44
                                    if v45:
                                        v64 = 1
                                    else:
                                        v46 = v42 // (<signed short>2)
                                        v47 = v43 == v46
                                        if v47:
                                            v64 = 1
                                        else:
                                            v48 = v42 * (<signed short>3)
                                            v49 = v48 // (<signed short>4)
                                            v50 = v43 == v49
                                            if v50:
                                                v64 = 1
                                            else:
                                                v51 = v43 == v42
                                                if v51:
                                                    v64 = 1
                                                else:
                                                    v52 = v48 // (<signed short>2)
                                                    v53 = v43 == v52
                                                    if v53:
                                                        v64 = 1
                                                    else:
                                                        v54 = v42 * (<signed short>2)
                                                        v64 = v43 == v54
                    if v64:
                        v30[v34] = v35
                        v66 = v34 + (<signed short>1)
                    else:
                        v66 = v34
                    del v35
                    v67 = v33 + (<signed short>1)
                    v31.v0 = v67
                    v31.v1 = v66
                v68 = v31.v1
                del v31
                v69 = numpy.empty(v68,dtype=object)
                v70 = Mut1((<signed short>0))
                while method9(v68, v70):
                    v72 = v70.v0
                    v73 = v30[v72]
                    v69[v72] = v73
                    del v73
                    v74 = v72 + (<signed short>1)
                    v70.v0 = v74
                del v30
                del v70
                v125 = v69
                del v69
            else:
                v75 = (<unsigned char>2) == v2
                if v75:
                    tmp58 = len(v26)
                    if <signed short>tmp58 != tmp58: raise Exception("The conversion to signed short failed.")
                    v76 = <signed short>tmp58
                    v77 = numpy.empty(v76,dtype=object)
                    v78 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v76, v78):
                        v80 = v78.v0
                        v81 = v78.v1
                        v82 = v26[v80]
                        if v82.tag == 0: # call
                            v111 = 1
                        elif v82.tag == 1: # fold
                            v111 = 1
                        elif v82.tag == 2: # raiseTo_
                            v83 = (<US1_2>v82).v0
                            v84 = v2 == (<unsigned char>1)
                            v85 = v83 == v0
                            if v85:
                                v111 = 1
                            else:
                                v86 = v83 == v20
                                if v86:
                                    v111 = 1
                                else:
                                    if v84:
                                        v87 = v83 % v1
                                        v111 = v87 == (<signed short>0)
                                    else:
                                        v89 = (<signed short>2) * v8
                                        v90 = v83 - v8
                                        v91 = v89 // (<signed short>4)
                                        v92 = v90 == v91
                                        if v92:
                                            v111 = 1
                                        else:
                                            v93 = v89 // (<signed short>2)
                                            v94 = v90 == v93
                                            if v94:
                                                v111 = 1
                                            else:
                                                v95 = v89 * (<signed short>3)
                                                v96 = v95 // (<signed short>4)
                                                v97 = v90 == v96
                                                if v97:
                                                    v111 = 1
                                                else:
                                                    v98 = v90 == v89
                                                    if v98:
                                                        v111 = 1
                                                    else:
                                                        v99 = v95 // (<signed short>2)
                                                        v100 = v90 == v99
                                                        if v100:
                                                            v111 = 1
                                                        else:
                                                            v101 = v89 * (<signed short>2)
                                                            v111 = v90 == v101
                        if v111:
                            v77[v81] = v82
                            v113 = v81 + (<signed short>1)
                        else:
                            v113 = v81
                        del v82
                        v114 = v80 + (<signed short>1)
                        v78.v0 = v114
                        v78.v1 = v113
                    v115 = v78.v1
                    del v78
                    v116 = numpy.empty(v115,dtype=object)
                    v117 = Mut1((<signed short>0))
                    while method9(v115, v117):
                        v119 = v117.v0
                        v120 = v77[v119]
                        v116[v119] = v120
                        del v120
                        v121 = v119 + (<signed short>1)
                        v117.v0 = v121
                    del v77
                    del v117
                    v125 = v116
                    del v116
                else:
                    raise Exception("Invalid action restriction level.")
        del v26
        return Closure28(v9, v10, v11, v8, v5, v6, v7, v12, v0, v125, v4, v1, v2, v3, v13)
cdef UH2 method53(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, signed short v10, unsigned char v11, numpy.ndarray[object,ndim=1] v12, numpy.ndarray[signed char,ndim=1] v13, numpy.ndarray[signed char,ndim=1] v14, US1 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
            v27 = method54(v9, v10, v11, v12, v24, v5, v6, v7, v4, v1, v2, v3, v13, v14)
        else:
            v27 = method55(v9, v10, v11, v12, v14, v1, v2, v3, v4, v5, v6, v7)
        return v27(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v29 = v7 == (<unsigned char>0)
        if v29:
            v31 = -v8
        else:
            v31 = v8
        v32 = <float>v31
        return UH2_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v8, v1, v2, v3, v4, v13, v9, 0, v32)
    elif v15.tag == 2: # raiseTo_
        v34 = (<US1_2>v15).v0
        v35 = 0
        v36 = method39(v9, v10, v11, v12, v35, v5, v6, v7, v34, v1, v2, v3, v4, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method39(signed short v0, signed short v1, unsigned char v2, numpy.ndarray[object,ndim=1] v3, bint v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12, numpy.ndarray[signed char,ndim=1] v13, numpy.ndarray[signed char,ndim=1] v14):
    cdef bint v15
    cdef bint v17
    cdef bint v18
    cdef bint v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef signed short v23
    cdef bint v24
    cdef signed short v25
    cdef signed short v26
    cdef signed short v27
    cdef bint v28
    cdef signed short v29
    cdef bint v30
    cdef signed short v31
    cdef signed short v32
    cdef numpy.ndarray[object,ndim=1] v33
    cdef bint v34
    cdef numpy.ndarray[object,ndim=1] v132
    cdef bint v35
    cdef signed short v36
    cdef unsigned long long tmp55
    cdef numpy.ndarray[object,ndim=1] v37
    cdef Mut3 v38
    cdef signed short v40
    cdef signed short v41
    cdef US1 v42
    cdef bint v71
    cdef signed short v43
    cdef bint v44
    cdef bint v45
    cdef bint v46
    cdef signed short v47
    cdef signed short v49
    cdef signed short v50
    cdef signed short v51
    cdef bint v52
    cdef signed short v53
    cdef bint v54
    cdef signed short v55
    cdef signed short v56
    cdef bint v57
    cdef bint v58
    cdef signed short v59
    cdef bint v60
    cdef signed short v61
    cdef signed short v73
    cdef signed short v74
    cdef signed short v75
    cdef numpy.ndarray[object,ndim=1] v76
    cdef Mut1 v77
    cdef signed short v79
    cdef US1 v80
    cdef signed short v81
    cdef bint v82
    cdef signed short v83
    cdef unsigned long long tmp56
    cdef numpy.ndarray[object,ndim=1] v84
    cdef Mut3 v85
    cdef signed short v87
    cdef signed short v88
    cdef US1 v89
    cdef bint v118
    cdef signed short v90
    cdef bint v91
    cdef bint v92
    cdef bint v93
    cdef signed short v94
    cdef signed short v96
    cdef signed short v97
    cdef signed short v98
    cdef bint v99
    cdef signed short v100
    cdef bint v101
    cdef signed short v102
    cdef signed short v103
    cdef bint v104
    cdef bint v105
    cdef signed short v106
    cdef bint v107
    cdef signed short v108
    cdef signed short v120
    cdef signed short v121
    cdef signed short v122
    cdef numpy.ndarray[object,ndim=1] v123
    cdef Mut1 v124
    cdef signed short v126
    cdef US1 v127
    cdef signed short v128
    v15 = v12 == v0
    if v15:
        return method40(v0, v1, v2, v3, v14, v5, v6, v7, v8, v9, v10, v11, v12)
    else:
        v17 = v12 == v8
        v18 = v17 != 1
        v19 = v12 >= v8
        if v19:
            v20 = v12
        else:
            v20 = v8
        v21 = v12 < v8
        if v21:
            v22 = v12
        else:
            v22 = v8
        v23 = v20 - v22
        v24 = v1 >= v23
        if v24:
            v25 = v1
        else:
            v25 = v23
        v26 = v20 + v25
        if v18:
            v27 = (<signed short>0)
        else:
            v27 = (<signed short>1)
        v28 = v0 < v26
        if v28:
            v29 = v0
        else:
            v29 = v26
        v30 = v0 == v20
        if v30:
            v31 = (<signed short>1)
        else:
            v31 = (<signed short>0)
        v32 = v29 + v31
        v33 = v3[v27:3+v0-v32]
        v34 = (<unsigned char>0) == v2
        if v34:
            v132 = v33
        else:
            v35 = (<unsigned char>1) == v2
            if v35:
                tmp55 = len(v33)
                if <signed short>tmp55 != tmp55: raise Exception("The conversion to signed short failed.")
                v36 = <signed short>tmp55
                v37 = numpy.empty(v36,dtype=object)
                v38 = Mut3((<signed short>0), (<signed short>0))
                while method34(v36, v38):
                    v40 = v38.v0
                    v41 = v38.v1
                    v42 = v33[v40]
                    if v42.tag == 0: # call
                        v71 = 1
                    elif v42.tag == 1: # fold
                        v71 = 1
                    elif v42.tag == 2: # raiseTo_
                        v43 = (<US1_2>v42).v0
                        v44 = v2 == (<unsigned char>1)
                        v45 = v43 == v0
                        if v45:
                            v71 = 1
                        else:
                            v46 = v43 == v26
                            if v46:
                                v71 = 1
                            else:
                                if v44:
                                    v47 = v43 % v1
                                    v71 = v47 == (<signed short>0)
                                else:
                                    v49 = (<signed short>2) * v20
                                    v50 = v43 - v20
                                    v51 = v49 // (<signed short>4)
                                    v52 = v50 == v51
                                    if v52:
                                        v71 = 1
                                    else:
                                        v53 = v49 // (<signed short>2)
                                        v54 = v50 == v53
                                        if v54:
                                            v71 = 1
                                        else:
                                            v55 = v49 * (<signed short>3)
                                            v56 = v55 // (<signed short>4)
                                            v57 = v50 == v56
                                            if v57:
                                                v71 = 1
                                            else:
                                                v58 = v50 == v49
                                                if v58:
                                                    v71 = 1
                                                else:
                                                    v59 = v55 // (<signed short>2)
                                                    v60 = v50 == v59
                                                    if v60:
                                                        v71 = 1
                                                    else:
                                                        v61 = v49 * (<signed short>2)
                                                        v71 = v50 == v61
                    if v71:
                        v37[v41] = v42
                        v73 = v41 + (<signed short>1)
                    else:
                        v73 = v41
                    del v42
                    v74 = v40 + (<signed short>1)
                    v38.v0 = v74
                    v38.v1 = v73
                v75 = v38.v1
                del v38
                v76 = numpy.empty(v75,dtype=object)
                v77 = Mut1((<signed short>0))
                while method9(v75, v77):
                    v79 = v77.v0
                    v80 = v37[v79]
                    v76[v79] = v80
                    del v80
                    v81 = v79 + (<signed short>1)
                    v77.v0 = v81
                del v37
                del v77
                v132 = v76
                del v76
            else:
                v82 = (<unsigned char>2) == v2
                if v82:
                    tmp56 = len(v33)
                    if <signed short>tmp56 != tmp56: raise Exception("The conversion to signed short failed.")
                    v83 = <signed short>tmp56
                    v84 = numpy.empty(v83,dtype=object)
                    v85 = Mut3((<signed short>0), (<signed short>0))
                    while method34(v83, v85):
                        v87 = v85.v0
                        v88 = v85.v1
                        v89 = v33[v87]
                        if v89.tag == 0: # call
                            v118 = 1
                        elif v89.tag == 1: # fold
                            v118 = 1
                        elif v89.tag == 2: # raiseTo_
                            v90 = (<US1_2>v89).v0
                            v91 = v2 == (<unsigned char>1)
                            v92 = v90 == v0
                            if v92:
                                v118 = 1
                            else:
                                v93 = v90 == v26
                                if v93:
                                    v118 = 1
                                else:
                                    if v91:
                                        v94 = v90 % v1
                                        v118 = v94 == (<signed short>0)
                                    else:
                                        v96 = (<signed short>2) * v20
                                        v97 = v90 - v20
                                        v98 = v96 // (<signed short>4)
                                        v99 = v97 == v98
                                        if v99:
                                            v118 = 1
                                        else:
                                            v100 = v96 // (<signed short>2)
                                            v101 = v97 == v100
                                            if v101:
                                                v118 = 1
                                            else:
                                                v102 = v96 * (<signed short>3)
                                                v103 = v102 // (<signed short>4)
                                                v104 = v97 == v103
                                                if v104:
                                                    v118 = 1
                                                else:
                                                    v105 = v97 == v96
                                                    if v105:
                                                        v118 = 1
                                                    else:
                                                        v106 = v102 // (<signed short>2)
                                                        v107 = v97 == v106
                                                        if v107:
                                                            v118 = 1
                                                        else:
                                                            v108 = v96 * (<signed short>2)
                                                            v118 = v97 == v108
                        if v118:
                            v84[v88] = v89
                            v120 = v88 + (<signed short>1)
                        else:
                            v120 = v88
                        del v89
                        v121 = v87 + (<signed short>1)
                        v85.v0 = v121
                        v85.v1 = v120
                    v122 = v85.v1
                    del v85
                    v123 = numpy.empty(v122,dtype=object)
                    v124 = Mut1((<signed short>0))
                    while method9(v122, v124):
                        v126 = v124.v0
                        v127 = v84[v126]
                        v123[v126] = v127
                        del v127
                        v128 = v126 + (<signed short>1)
                        v124.v0 = v128
                    del v84
                    del v124
                    v132 = v123
                    del v123
                else:
                    raise Exception("Invalid action restriction level.")
        del v33
        return Closure26(v9, v10, v11, v12, v5, v6, v7, v8, v13, v0, v132, v4, v1, v2, v3, v14)
cdef bint method58(unsigned long long v0, Mut4 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method57(v0, v1, numpy.ndarray[object,ndim=1] v2):
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
    cdef Tuple2 tmp59
    cdef numpy.ndarray[object,ndim=1] v63
    cdef object v64
    cdef Tuple2 tmp60
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
    cdef Tuple1 tmp61
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
    cdef Tuple1 tmp62
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
    cdef Mut4 v113
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
    cdef Tuple7 tmp63
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
                v5.append(Tuple0(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35))
                v7.append(v36)
            else:
                v6.append(Tuple0(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35))
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
        tmp59 = v1(v5)
        v61, v62 = tmp59.v0, tmp59.v1
        del tmp59
        tmp60 = v0(v6)
        v63, v64 = tmp60.v0, tmp60.v1
        del tmp60
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
            tmp61 = v61[v72]
            v74, v75, v76 = tmp61.v0, tmp61.v1, tmp61.v2
            del tmp61
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
            tmp62 = v63[v86]
            v88, v89, v90 = tmp62.v0, tmp62.v1, tmp62.v2
            del tmp62
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
        v106 = method57(v0, v1, v96)
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
        v113 = Mut4((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method58(v111, v113):
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
        tmp63 = v3[v146]
        v147, v148, v149, v150, v151, v152, v153, v154, v155, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167 = tmp63.v0, tmp63.v1, tmp63.v2, tmp63.v3, tmp63.v4, tmp63.v5, tmp63.v6, tmp63.v7, tmp63.v8, tmp63.v9, tmp63.v10, tmp63.v11, tmp63.v12, tmp63.v13, tmp63.v14, tmp63.v15, tmp63.v16, tmp63.v17, tmp63.v18, tmp63.v19, tmp63.v20
        del tmp63
        del v150; del v153; del v164
        v132[v147] = v167
        v168 = v146 + (<unsigned long long>1)
        v144.v0 = v168
    del v3
    del v144
    return v132
cdef numpy.ndarray[float,ndim=1] method59(v0, numpy.ndarray[object,ndim=1] v1):
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
    cdef Tuple2 tmp68
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
    cdef Tuple1 tmp69
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
    cdef Tuple7 tmp70
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
            v4.append(Tuple0(v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
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
        tmp68 = v0(v4)
        v56, v57 = tmp68.v0, tmp68.v1
        del tmp68
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
            tmp69 = v56[v65]
            v67, v68, v69 = tmp69.v0, tmp69.v1, tmp69.v2
            del tmp69
            v70 = v66(v67, v68, v69)
            del v66; del v69
            v62[v65] = v70
            del v70
            v71 = v65 + (<unsigned long long>1)
            v63.v0 = v71
        del v56
        del v63
        v72 = method59(v0, v62)
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
        tmp70 = v2[v90]
        v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108, v109, v110, v111 = tmp70.v0, tmp70.v1, tmp70.v2, tmp70.v3, tmp70.v4, tmp70.v5, tmp70.v6, tmp70.v7, tmp70.v8, tmp70.v9, tmp70.v10, tmp70.v11, tmp70.v12, tmp70.v13, tmp70.v14, tmp70.v15, tmp70.v16, tmp70.v17, tmp70.v18, tmp70.v19, tmp70.v20
        del tmp70
        del v94; del v97; del v108
        v76[v91] = v111
        v112 = v90 + (<unsigned long long>1)
        v88.v0 = v112
    del v2
    del v88
    return v76
cdef UH2 method61(unsigned char v0, v1, UH2 v2):
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
    cdef Tuple2 tmp75
    cdef float v29
    cdef float v30
    cdef US1 v31
    cdef Tuple1 tmp76
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
            v26[(<unsigned long long>0)] = Tuple0(v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23)
            del v5; del v8; del v19; del v23
            tmp75 = v1(v26)
            v27, v28 = tmp75.v0, tmp75.v1
            del tmp75
            del v26; del v28
            tmp76 = v27[(<unsigned long long>0)]
            v29, v30, v31 = tmp76.v0, tmp76.v1, tmp76.v2
            del tmp76
            del v27
            v32 = v24(v29, v30, v31)
            del v24; del v31
            return method61(v0, v1, v32)
    elif v2.tag == 1: # terminal_
        v35 = (<UH2_1>v2).v0; v36 = (<UH2_1>v2).v1; v38 = (<UH2_1>v2).v3; v39 = (<UH2_1>v2).v4; v41 = (<UH2_1>v2).v6; v42 = (<UH2_1>v2).v7; v43 = (<UH2_1>v2).v8; v44 = (<UH2_1>v2).v9; v45 = (<UH2_1>v2).v10; v46 = (<UH2_1>v2).v11; v47 = (<UH2_1>v2).v12; v48 = (<UH2_1>v2).v13; v49 = (<UH2_1>v2).v14; v50 = (<UH2_1>v2).v15; v52 = (<UH2_1>v2).v17; v53 = (<UH2_1>v2).v18; v54 = (<UH2_1>v2).v19
        return v2
cdef UH0 method63(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method63(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef void method65(list v0, list v1) except *:
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
cdef str method66(signed char v0):
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
cdef void method64(list v0, list v1, bint v2, UH0 v3) except *:
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
            method65(v0, v1)
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
            method64(v0, v1, v13, v5)
        elif v4.tag == 1: # observation_
            v14 = (<US0_1>v4).v0
            v15 = method66(v14)
            v1.append(v15)
            del v15
            v16 = 1
            method64(v0, v1, v16, v5)
    elif v3.tag == 1: # nil
        method65(v0, v1)
cdef list method62(UH0 v0):
    cdef list v1
    cdef list v2
    cdef bint v3
    cdef UH0 v4
    cdef UH0 v5
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = 1
    v4 = UH0_1()
    v5 = method63(v0, v4)
    del v4
    method64(v1, v2, v3, v5)
    del v2; del v5
    return v1
cdef str method67(signed char v0, signed char v1):
    cdef str v2
    cdef str v3
    v2 = method66(v1)
    v3 = method66(v0)
    return f'{v2}{v3}'
cdef str method70(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
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
cdef str method71(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef str v5
    cdef str v6
    cdef str v7
    cdef str v8
    cdef str v9
    v5 = method66(v4)
    v6 = method66(v3)
    v7 = method66(v2)
    v8 = method66(v1)
    v9 = method66(v0)
    return f'{v5}{v6}{v7}{v8}{v9}'
cdef void method69(numpy.ndarray[signed char,ndim=1] v0, list v1, unsigned char v2, signed char v3, signed char v4) except *:
    cdef bint v5
    cdef str v6
    cdef signed char v7
    cdef signed char v8
    cdef signed char v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef Tuple4 tmp79
    cdef str v13
    cdef str v14
    cdef str v15
    v5 = v2 == (<unsigned char>0)
    if v5:
        v6 = "Player One"
    else:
        v6 = "Player Two"
    tmp79 = method13(v4, v3, v0)
    v7, v8, v9, v10, v11, v12 = tmp79.v0, tmp79.v1, tmp79.v2, tmp79.v3, tmp79.v4, tmp79.v5
    del tmp79
    v13 = method70(v7, v8, v9, v10, v11, v12)
    v14 = method71(v11, v10, v9, v8, v7)
    v15 = f'{v6} shows {v13} {v14}'
    del v6; del v13; del v14
    v1.append(v15)
cdef void method72(float v0, list v1, unsigned char v2) except *:
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
    v10 = v6 < (<float>0)
    if v10:
        v16 = f'{v4} losses {v9} chips.'
    else:
        v12 = v6 == (<float>0)
        if v12:
            v16 = f'{v4} ties.'
        else:
            v16 = f'{v4} gains {v9} chips.'
    del v4
    v1.append(v16)
cdef str method68(bint v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, float v10, list v11):
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
        method69(v1, v11, v21, v13, v14)
        v22 = (<unsigned char>1)
        method69(v1, v11, v22, v17, v18)
    else:
        pass
    v23 = (<unsigned char>0)
    method72(v10, v11, v23)
    v24 = (<unsigned char>1)
    method72(v10, v11, v24)
    return "\n".join(v11)
cdef void method60(v0, v1, unsigned char v2, signed short v3, UH2 v4) except *:
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
    cdef unsigned long long tmp77
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
    cdef unsigned long long tmp78
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
    cdef unsigned long long tmp80
    cdef list v131
    cdef Mut1 v132
    cdef signed short v134
    cdef signed char v135
    cdef str v136
    cdef signed short v137
    cdef str v138
    cdef object v139
    cdef object v140
    v5 = method61(v2, v0, v4)
    if v5.tag == 0: # action_
        v6 = (<UH2_0>v5).v0; v7 = (<UH2_0>v5).v1; v8 = (<UH2_0>v5).v2; v9 = (<UH2_0>v5).v3; v10 = (<UH2_0>v5).v4; v11 = (<UH2_0>v5).v5; v12 = (<UH2_0>v5).v6; v13 = (<UH2_0>v5).v7; v14 = (<UH2_0>v5).v8; v15 = (<UH2_0>v5).v9; v16 = (<UH2_0>v5).v10; v17 = (<UH2_0>v5).v11; v18 = (<UH2_0>v5).v12; v19 = (<UH2_0>v5).v13; v20 = (<UH2_0>v5).v14; v21 = (<UH2_0>v5).v15; v22 = (<UH2_0>v5).v16; v23 = (<UH2_0>v5).v17; v24 = (<UH2_0>v5).v18; v25 = (<UH2_0>v5).v19; v26 = (<UH2_0>v5).v20; v27 = (<UH2_0>v5).v21
        v28 = v2 == (<unsigned char>0)
        if v28:
            v29 = v8
        else:
            v29 = v11
        del v8; del v11
        v30 = method62(v29)
        del v29
        v31 = "\n".join(v30)
        del v30
        tmp77 = len(v26)
        if <signed short>tmp77 != tmp77: raise Exception("The conversion to signed short failed.")
        v32 = <signed short>tmp77
        v33 = Mut3((<signed short>0), (<signed short>0))
        while method34(v32, v33):
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
        while method34(v32, v44):
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
            v58 = Closure34(v0, v1, v2, v3, v27)
        v59 = Closure35(v0, v1, v2, v3, v27)
        v60 = Closure36(v0, v1, v2, v3, v27)
        del v27
        v61 = {'call': v59, 'fold': v60, 'raise_max': v43, 'raise_min': v54, 'raise_to': v58}
        del v58; del v59; del v60
        v62 = v2 == v16
        if v62:
            v63, v64, v65, v66, v67, v68, v69, v70 = v14, v15, v16, v17, v18, v19, v20, v21
        else:
            v63, v64, v65, v66, v67, v68, v69, v70 = v18, v19, v20, v21, v14, v15, v16, v17
        v71 = v3 - v66
        v72 = method67(v64, v63)
        v73 = v3 - v70
        v74 = method67(v68, v67)
        tmp78 = len(v22)
        if <signed short>tmp78 != tmp78: raise Exception("The conversion to signed short failed.")
        v75 = <signed short>tmp78
        v76 = [None]*v75
        v77 = Mut1((<signed short>0))
        while method9(v75, v77):
            v79 = v77.v0
            v80 = v22[v79]
            v81 = method66(v80)
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
        v108 = method62(v107)
        del v107
        v109 = method68(v104, v102, v98, v99, v100, v101, v94, v95, v96, v97, v105, v108)
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
        v127 = method67(v119, v118)
        v128 = v103 - v116
        v129 = method67(v123, v122)
        tmp80 = len(v102)
        if <signed short>tmp80 != tmp80: raise Exception("The conversion to signed short failed.")
        v130 = <signed short>tmp80
        v131 = [None]*v130
        v132 = Mut1((<signed short>0))
        while method9(v130, v132):
            v134 = v132.v0
            v135 = v102[v134]
            v136 = method66(v135)
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
    v0 = Closure0()
    v1 = Closure2()
    v2 = Closure6()
    v3 = Closure7()
    v4 = Closure30()
    v5 = {'callbot_player': v0, 'neural': v1, 'uniform_player': v2, 'vs_one': v3, 'vs_self': v4}
    del v0; del v1; del v2; del v3; del v4
    v6 = Closure32()
    return {'train': v5, 'ui': v6}
