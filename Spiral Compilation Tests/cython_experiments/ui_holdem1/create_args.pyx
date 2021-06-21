import collections
import torch
import numpy
cimport numpy
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
cdef class Tuple1:
    cdef readonly UH1 v0
    cdef readonly bint v1
    def __init__(self, UH1 v0, bint v1): self.v0 = v0; self.v1 = v1
cdef class Mut1:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Tuple2:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US1 v2
    def __init__(self, float v0, float v1, US1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure2():
    cdef list v0
    cdef unsigned long long v1
    cdef object v2
    def __init__(self, list v0, unsigned long long v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, numpy.ndarray[float,ndim=1] v3):
        cdef list v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef object v2 = self.v2
        cdef numpy.ndarray[float,ndim=1] v4
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
        cdef Tuple0 tmp5
        cdef bint v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v47
        cdef unsigned long long v48
        cdef object v49
        cdef object v50
        cdef object v51
        cdef numpy.ndarray[float,ndim=1] v52
        cdef unsigned long long v53
        cdef unsigned long long v54
        cdef bint v55
        cdef bint v56
        cdef numpy.ndarray[float,ndim=1] v57
        cdef Mut0 v58
        cdef unsigned long long v60
        cdef float v61
        cdef float v62
        cdef float v63
        cdef UH0 v64
        cdef float v65
        cdef float v66
        cdef UH0 v67
        cdef float v68
        cdef float v69
        cdef signed char v70
        cdef signed char v71
        cdef unsigned char v72
        cdef signed short v73
        cdef signed char v74
        cdef signed char v75
        cdef unsigned char v76
        cdef signed short v77
        cdef numpy.ndarray[signed char,ndim=1] v78
        cdef signed short v79
        cdef bint v80
        cdef unsigned char v81
        cdef numpy.ndarray[object,ndim=1] v82
        cdef Tuple0 tmp6
        cdef bint v83
        cdef float v85
        cdef float v84
        cdef unsigned long long v86
        v4 = numpy.empty(v1,dtype=numpy.float32)
        v5 = numpy.empty(v1,dtype=numpy.float32)
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
            tmp5 = v0[v12]
            v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4, tmp5.v5, tmp5.v6, tmp5.v7, tmp5.v8, tmp5.v9, tmp5.v10, tmp5.v11, tmp5.v12, tmp5.v13, tmp5.v14, tmp5.v15, tmp5.v16, tmp5.v17, tmp5.v18, tmp5.v19, tmp5.v20
            del tmp5
            del v16; del v19; del v30; del v34
            v35 = v33 == (<unsigned char>0)
            if v35:
                v36, v37, v38, v39 = v17, v18, v20, v21
            else:
                v36, v37, v38, v39 = v20, v21, v17, v18
            v40 = v15 + v39
            v41 = v14 + v38
            v42 = -v37
            v43 = v41 - v40
            v44 = v42 + v43
            v45 = libc.math.exp(v44)
            v5[v12] = v45
            if v35:
                v47 = v13
            else:
                v47 = -v13
            v4[v12] = v47
            v48 = v12 + (<unsigned long long>1)
            v10.v0 = v48
        del v10
        v49 = torch.from_numpy(numpy.expand_dims(v4,-1))
        del v4
        v50 = torch.from_numpy(numpy.expand_dims(v5,-1))
        del v5
        v51 = v2(v49, v50)
        del v49; del v50
        v52 = v51.squeeze(-1).numpy()
        del v51
        v53 = len(v52)
        v54 = len(v0)
        v55 = v53 == v54
        v56 = v55 == 0
        if v56:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v57 = numpy.empty(v53,dtype=numpy.float32)
        v58 = Mut0((<unsigned long long>0))
        while method0(v53, v58):
            v60 = v58.v0
            v61 = v52[v60]
            tmp6 = v0[v60]
            v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4, tmp6.v5, tmp6.v6, tmp6.v7, tmp6.v8, tmp6.v9, tmp6.v10, tmp6.v11, tmp6.v12, tmp6.v13, tmp6.v14, tmp6.v15, tmp6.v16, tmp6.v17, tmp6.v18, tmp6.v19, tmp6.v20
            del tmp6
            del v64; del v67; del v78; del v82
            v83 = v81 == (<unsigned char>0)
            if v83:
                v85 = v61
            else:
                v84 = -v61
                v85 = v84
            v57[v60] = v85
            v86 = v60 + (<unsigned long long>1)
            v58.v0 = v86
        del v52
        del v58
        return v57
cdef class Tuple3:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure1():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, list v1):
        cdef object v0 = self.v0
        cdef unsigned long long v2
        cdef numpy.ndarray[float,ndim=2] v3
        cdef numpy.ndarray[float,ndim=2] v4
        cdef numpy.ndarray[signed char,ndim=2] v5
        cdef unsigned long long v6
        cdef Mut0 v7
        cdef unsigned long long v9
        cdef float v10
        cdef float v11
        cdef UH0 v12
        cdef float v13
        cdef float v14
        cdef UH0 v15
        cdef float v16
        cdef float v17
        cdef signed char v18
        cdef signed char v19
        cdef unsigned char v20
        cdef signed short v21
        cdef signed char v22
        cdef signed char v23
        cdef unsigned char v24
        cdef signed short v25
        cdef numpy.ndarray[signed char,ndim=1] v26
        cdef signed short v27
        cdef bint v28
        cdef unsigned char v29
        cdef numpy.ndarray[object,ndim=1] v30
        cdef Tuple0 tmp0
        cdef bint v31
        cdef UH0 v32
        cdef UH1 v33
        cdef bint v34
        cdef UH1 v35
        cdef bint v36
        cdef Tuple1 tmp1
        cdef numpy.ndarray[object,ndim=1] v37
        cdef numpy.ndarray[float,ndim=1] v38
        cdef signed short v39
        cdef signed short v40
        cdef signed short v41
        cdef signed char v42
        cdef signed char v43
        cdef bint v44
        cdef bint v47
        cdef signed short v45
        cdef signed short v48
        cdef signed short v49
        cdef bint v50
        cdef bint v53
        cdef signed short v51
        cdef signed short v54
        cdef signed short v55
        cdef signed char v56
        cdef signed char v57
        cdef bint v58
        cdef bint v61
        cdef signed short v59
        cdef signed short v62
        cdef signed short v63
        cdef bint v64
        cdef bint v67
        cdef signed short v65
        cdef signed short v68
        cdef signed short v69
        cdef signed short v70
        cdef unsigned long long tmp2
        cdef bint v71
        cdef Mut1 v72
        cdef signed short v74
        cdef signed char v75
        cdef signed short v76
        cdef signed short v77
        cdef signed char v78
        cdef signed char v79
        cdef bint v80
        cdef bint v83
        cdef signed short v81
        cdef signed short v84
        cdef signed short v85
        cdef signed short v86
        cdef bint v87
        cdef bint v90
        cdef signed short v88
        cdef signed short v91
        cdef signed short v92
        cdef signed short v93
        cdef signed short v94
        cdef unsigned long long tmp3
        cdef bint v95
        cdef Mut1 v96
        cdef signed short v98
        cdef US2 v99
        cdef signed short v100
        cdef signed short v101
        cdef signed short v102
        cdef signed short v103
        cdef signed short v104
        cdef signed short v105
        cdef signed short v106
        cdef signed char v107
        cdef signed char v108
        cdef bint v109
        cdef bint v112
        cdef signed short v110
        cdef signed short v113
        cdef signed short v114
        cdef bint v115
        cdef bint v118
        cdef signed short v116
        cdef signed short v119
        cdef signed short v120
        cdef signed char v121
        cdef signed char v122
        cdef bint v123
        cdef bint v126
        cdef signed short v124
        cdef signed short v127
        cdef signed short v128
        cdef bint v129
        cdef bint v132
        cdef signed short v130
        cdef signed short v133
        cdef signed short v134
        cdef signed short v135
        cdef unsigned long long tmp4
        cdef Mut1 v136
        cdef signed short v138
        cdef US1 v139
        cdef signed short v146
        cdef signed short v140
        cdef bint v141
        cdef bint v143
        cdef bint v144
        cdef signed short v147
        cdef unsigned long long v148
        cdef object v149
        cdef object v150
        cdef object v151
        cdef object v152
        cdef object v153
        cdef object v154
        cdef object v155
        cdef object v156
        cdef numpy.ndarray[object,ndim=1] v157
        cdef Mut0 v158
        cdef unsigned long long v160
        cdef signed short v161
        cdef float v162
        cdef float v163
        cdef float v164
        cdef float v165
        cdef bint v166
        cdef US1 v185
        cdef bint v167
        cdef bint v168
        cdef bint v170
        cdef signed short v171
        cdef bint v172
        cdef bint v173
        cdef bint v175
        cdef signed short v176
        cdef bint v177
        cdef bint v179
        cdef bint v180
        cdef unsigned long long v186
        cdef object v187
        pass # import torch
        v2 = len(v1)
        v3 = numpy.zeros((v2,(<signed short>693)),dtype=numpy.float32)
        v4 = v3[:,:(<signed short>659)]
        v5 = numpy.ones((v2,(<signed short>102)),dtype=numpy.int8)
        v6 = len(v1)
        v7 = Mut0((<unsigned long long>0))
        while method0(v6, v7):
            v9 = v7.v0
            tmp0 = v1[v9]
            v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17, tmp0.v18, tmp0.v19, tmp0.v20
            del tmp0
            v31 = v29 == (<unsigned char>0)
            if v31:
                v32 = v12
            else:
                v32 = v15
            del v12; del v15
            v33 = UH1_1()
            v34 = 0
            tmp1 = method1(v32, v33, v34)
            v35, v36 = tmp1.v0, tmp1.v1
            del tmp1
            del v32; del v33
            v37 = method2(v35)
            del v35
            v38 = v3[v9,:]
            v39 = (<signed short>0)
            method5(v27, v38, v39)
            v40 = (<signed short>6)
            method5(v21, v38, v40)
            v41 = (<signed short>12)
            method5(v25, v38, v41)
            v42 = v18 // (<signed char>13)
            v43 = v18 % (<signed char>13)
            v44 = (<signed char>0) <= v42
            if v44:
                v45 = <signed short>v42
                v47 = v45 < (<signed short>4)
            else:
                v47 = 0
            if v47:
                v48 = <signed short>v42
                v49 = (<signed short>18) + v48
                v38[v49] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v50 = (<signed char>0) <= v43
            if v50:
                v51 = <signed short>v43
                v53 = v51 < (<signed short>13)
            else:
                v53 = 0
            if v53:
                v54 = <signed short>v43
                v55 = (<signed short>22) + v54
                v38[v55] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v56 = v19 // (<signed char>13)
            v57 = v19 % (<signed char>13)
            v58 = (<signed char>0) <= v56
            if v58:
                v59 = <signed short>v56
                v61 = v59 < (<signed short>4)
            else:
                v61 = 0
            if v61:
                v62 = <signed short>v56
                v63 = (<signed short>35) + v62
                v38[v63] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v64 = (<signed char>0) <= v57
            if v64:
                v65 = <signed short>v57
                v67 = v65 < (<signed short>13)
            else:
                v67 = 0
            if v67:
                v68 = <signed short>v57
                v69 = (<signed short>39) + v68
                v38[v69] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            tmp2 = len(v26)
            if <signed short>tmp2 != tmp2: raise Exception("The conversion to signed short failed.")
            v70 = <signed short>tmp2
            v71 = (<signed short>5) < v70
            if v71:
                raise Exception("The given array is too large.")
            else:
                pass
            v72 = Mut1((<signed short>0))
            while method7(v70, v72):
                v74 = v72.v0
                v75 = v26[v74]
                v76 = v74 * (<signed short>17)
                v77 = (<signed short>52) + v76
                v78 = v75 // (<signed char>13)
                v79 = v75 % (<signed char>13)
                v80 = (<signed char>0) <= v78
                if v80:
                    v81 = <signed short>v78
                    v83 = v81 < (<signed short>4)
                else:
                    v83 = 0
                if v83:
                    v84 = <signed short>v78
                    v85 = v77 + v84
                    v38[v85] = (<float>1.000000)
                else:
                    raise Exception("Value out of bounds.")
                v86 = v77 + (<signed short>4)
                v87 = (<signed char>0) <= v79
                if v87:
                    v88 = <signed short>v79
                    v90 = v88 < (<signed short>13)
                else:
                    v90 = 0
                if v90:
                    v91 = <signed short>v79
                    v92 = v86 + v91
                    v38[v92] = (<float>1.000000)
                else:
                    raise Exception("Value out of bounds.")
                v93 = v74 + (<signed short>1)
                v72.v0 = v93
            del v26
            del v72
            tmp3 = len(v37)
            if <signed short>tmp3 != tmp3: raise Exception("The conversion to signed short failed.")
            v94 = <signed short>tmp3
            v95 = (<signed short>58) < v94
            if v95:
                raise Exception("The given array is too large.")
            else:
                pass
            v96 = Mut1((<signed short>0))
            while method7(v94, v96):
                v98 = v96.v0
                v99 = v37[v98]
                v100 = v98 * (<signed short>9)
                v101 = (<signed short>137) + v100
                if v99.tag == 0: # oCall
                    v38[v101] = (<float>1.000000)
                elif v99.tag == 1: # oFold
                    v102 = v101 + (<signed short>1)
                    v38[v102] = (<float>1.000000)
                elif v99.tag == 2: # oRaiseTo_
                    v103 = (<US2_2>v99).v0
                    v104 = v101 + (<signed short>2)
                    method5(v103, v38, v104)
                elif v99.tag == 3: # oStreetOver
                    v105 = v101 + (<signed short>8)
                    v38[v105] = (<float>1.000000)
                del v99
                v106 = v98 + (<signed short>1)
                v96.v0 = v106
            del v37
            del v96
            v107 = v22 // (<signed char>13)
            v108 = v22 % (<signed char>13)
            v109 = (<signed char>0) <= v107
            if v109:
                v110 = <signed short>v107
                v112 = v110 < (<signed short>4)
            else:
                v112 = 0
            if v112:
                v113 = <signed short>v107
                v114 = (<signed short>659) + v113
                v38[v114] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v115 = (<signed char>0) <= v108
            if v115:
                v116 = <signed short>v108
                v118 = v116 < (<signed short>13)
            else:
                v118 = 0
            if v118:
                v119 = <signed short>v108
                v120 = (<signed short>663) + v119
                v38[v120] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v121 = v23 // (<signed char>13)
            v122 = v23 % (<signed char>13)
            v123 = (<signed char>0) <= v121
            if v123:
                v124 = <signed short>v121
                v126 = v124 < (<signed short>4)
            else:
                v126 = 0
            if v126:
                v127 = <signed short>v121
                v128 = (<signed short>676) + v127
                v38[v128] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            v129 = (<signed char>0) <= v122
            if v129:
                v130 = <signed short>v122
                v132 = v130 < (<signed short>13)
            else:
                v132 = 0
            if v132:
                v133 = <signed short>v122
                v134 = (<signed short>680) + v133
                v38[v134] = (<float>1.000000)
            else:
                raise Exception("Value out of bounds.")
            del v38
            tmp4 = len(v30)
            if <signed short>tmp4 != tmp4: raise Exception("The conversion to signed short failed.")
            v135 = <signed short>tmp4
            v136 = Mut1((<signed short>0))
            while method7(v135, v136):
                v138 = v136.v0
                v139 = v30[v138]
                if v139.tag == 0: # call
                    v146 = (<signed short>0)
                elif v139.tag == 1: # fold
                    v146 = (<signed short>1)
                elif v139.tag == 2: # raiseTo_
                    v140 = (<US1_2>v139).v0
                    v141 = (<signed short>0) <= v140
                    if v141:
                        v143 = v140 < (<signed short>100)
                    else:
                        v143 = 0
                    v144 = v143 == 0
                    if v144:
                        raise Exception("Value out of bounds.")
                    else:
                        pass
                    v146 = (<signed short>2) + v140
                del v139
                v5[v9,v146] = 0
                v147 = v138 + (<signed short>1)
                v136.v0 = v147
            del v30
            del v136
            v148 = v9 + (<unsigned long long>1)
            v7.v0 = v148
        del v7
        v149 = torch.from_numpy(v4)
        del v4
        v150 = torch.from_numpy(v3)
        del v3
        v151 = torch.from_numpy(v5)
        del v5
        v152 = v0(v149, v150, v151)
        del v149; del v150; del v151
        v153 = v152[0]
        v154 = v152[1]
        v155 = v152[2]
        v156 = v152[3]
        del v152
        v157 = numpy.empty(v2,dtype=object)
        v158 = Mut0((<unsigned long long>0))
        while method0(v2, v158):
            v160 = v158.v0
            v161 = v155[v160]
            v162 = v153[v160,v161]
            v163 = v154[v160,v161]
            v164 = libc.math.log(v163)
            v165 = libc.math.log(v162)
            v166 = v161 < (<signed short>1)
            if v166:
                v167 = v161 == (<signed short>0)
                v168 = v167 == 0
                if v168:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v185 = US1_0()
            else:
                v170 = v161 < (<signed short>2)
                if v170:
                    v171 = v161 - (<signed short>1)
                    v172 = v171 == (<signed short>0)
                    v173 = v172 == 0
                    if v173:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v185 = US1_1()
                else:
                    v175 = v161 < (<signed short>102)
                    if v175:
                        v176 = v161 - (<signed short>2)
                        v177 = (<signed short>0) <= v176
                        if v177:
                            v179 = v176 < (<signed short>100)
                        else:
                            v179 = 0
                        v180 = v179 == 0
                        if v180:
                            raise Exception("The index should be less than size.")
                        else:
                            pass
                        v185 = US1_2(v176)
                    else:
                        raise Exception("Unpickling of an union failed.")
            v157[v160] = Tuple2(v165, v164, v185)
            del v185
            v186 = v160 + (<unsigned long long>1)
            v158.v0 = v186
        del v153; del v154; del v155
        del v158
        v187 = Closure2(v1, v2, v156)
        del v156
        return Tuple3(v157, v187)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure1(v0)
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, numpy.ndarray[float,ndim=1] v0):
        return v0
cdef class Closure3():
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
        cdef Tuple0 tmp7
        cdef signed short v27
        cdef unsigned long long tmp8
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
            tmp7 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3, tmp7.v4, tmp7.v5, tmp7.v6, tmp7.v7, tmp7.v8, tmp7.v9, tmp7.v10, tmp7.v11, tmp7.v12, tmp7.v13, tmp7.v14, tmp7.v15, tmp7.v16, tmp7.v17, tmp7.v18, tmp7.v19, tmp7.v20
            del tmp7
            del v8; del v11; del v22
            tmp8 = len(v26)
            if <signed short>tmp8 != tmp8: raise Exception("The conversion to signed short failed.")
            v27 = <signed short>tmp8
            v28 = <float>v27
            v29 = (<float>1.000000) / v28
            v30 = libc.math.log(v29)
            v31 = numpy.random.choice(v26)
            del v26
            v2[v5] = Tuple2(v30, v30, v31)
            del v31
            v32 = v5 + (<unsigned long long>1)
            v3.v0 = v32
        del v3
        v33 = Closure4()
        return Tuple3(v2, v33)
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
cdef class Closure9():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef float v9
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, float v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, float v10, float v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef float v9 = self.v9
        return UH2_1(v10, v11, v12, v13, v14, v15, v16, v17, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>50), 1, v9)
cdef class Closure13():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef signed char v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef UH0 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef float v21
    cdef float v22
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, signed char v13, signed char v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
    def __call__(self, float v23, float v24, US1 v25):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
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
            return method40(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US0_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US0_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method40(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
cdef class Closure12():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure13(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH2_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>50), 0, v2, v8, v24)
cdef class Closure11():
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
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
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
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef signed char v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
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
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef signed char v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure11(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>50), 0, v2, v9, v25)
cdef class Closure8():
    cdef object v0
    cdef object v1
    cdef signed char v2
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
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
    def __call__(self, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v2 = self.v2
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
        cdef unsigned long long tmp17
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
        tmp17 = len(v0)
        if <signed short>tmp17 != tmp17: raise Exception("The conversion to signed short failed.")
        v23 = <signed short>tmp17
        v24 = <float>v23
        v25 = (<float>1.000000) / v24
        v26 = libc.math.log(v25)
        v27 = v26 + v15
        v28 = v26 + v14
        v29 = v0[1:]
        del v29
        v30 = 1
        v31 = numpy.empty(5,dtype=numpy.int8)
        v31[0] = v2; v31[1] = v3; v31[2] = v4; v31[3] = v5; v31[4] = v22
        v32 = method15(v1, v30, v6, v7, v8, v9, v10, v11, v12, v13, v31, v2, v3, v4, v5, v22)
        del v31
        v33 = US0_1(v22)
        v34 = UH0_0(v33, v16)
        del v33
        v35 = US0_1(v22)
        v36 = UH0_0(v35, v19)
        del v35
        return v32(v28, v27, v34, v17, v18, v36, v20, v21)
cdef class Closure17():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef signed char v10
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
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20, float v21, float v22): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22
    def __call__(self, float v23, float v24, US1 v25):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef signed char v10 = self.v10
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
            return method44(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US0_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US0_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method44(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
cdef class Closure16():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure17(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH2_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>50), 0, v2, v8, v24)
cdef class Closure15():
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
            return method41(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method41(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure14():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef signed short v7
    cdef object v8
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef signed char v14
    cdef object v15
    cdef signed char v16
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
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
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef signed char v14 = self.v14
        cdef numpy.ndarray[signed char,ndim=1] v15 = self.v15
        cdef signed char v16 = self.v16
        cdef object v25
        v25 = Closure15(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>50), 0, v2, v9, v25)
cdef class Closure7():
    cdef object v0
    cdef object v1
    cdef signed char v2
    cdef signed char v3
    cdef signed char v4
    cdef signed char v5
    cdef signed char v6
    cdef unsigned char v7
    cdef signed short v8
    cdef signed char v9
    cdef signed char v10
    cdef unsigned char v11
    cdef signed short v12
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef signed char v4 = self.v4
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
        cdef unsigned long long tmp16
        cdef float v23
        cdef float v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef numpy.ndarray[signed char,ndim=1] v28
        cdef bint v29
        cdef numpy.ndarray[signed char,ndim=1] v30
        cdef object v31
        cdef US0 v32
        cdef UH0 v33
        cdef US0 v34
        cdef UH0 v35
        v21 = v0[(<signed short>0)]
        tmp16 = len(v0)
        if <signed short>tmp16 != tmp16: raise Exception("The conversion to signed short failed.")
        v22 = <signed short>tmp16
        v23 = <float>v22
        v24 = (<float>1.000000) / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v14
        v27 = v25 + v13
        v28 = v0[1:]
        v29 = 1
        v30 = numpy.empty(4,dtype=numpy.int8)
        v30[0] = v2; v30[1] = v3; v30[2] = v4; v30[3] = v21
        v31 = method13(v1, v29, v5, v6, v7, v8, v9, v10, v11, v12, v30, v2, v3, v4, v28, v21)
        del v28; del v30
        v32 = US0_1(v21)
        v33 = UH0_0(v32, v15)
        del v32
        v34 = US0_1(v21)
        v35 = UH0_0(v34, v18)
        del v34
        return v31(v27, v26, v33, v16, v17, v35, v19, v20)
cdef class Closure21():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef signed char v10
    cdef signed char v11
    cdef object v12
    cdef signed char v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef UH0 v17
    cdef float v18
    cdef float v19
    cdef float v20
    cdef float v21
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19, float v20, float v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, float v22, float v23, US1 v24):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef signed char v10 = self.v10
        cdef signed char v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef signed char v13 = self.v13
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
            return method48(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v29, v27, v26, v31, v15, v16)
        else:
            v33 = v23 + v16
            v34 = v22 + v15
            v35 = US0_0(v24)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = US0_0(v24)
            v38 = UH0_0(v37, v14)
            del v37
            return method48(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v24, v20, v21, v36, v18, v19, v38, v34, v33)
cdef class Closure20():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef object v10
    cdef signed char v11
    cdef signed char v12
    cdef object v13
    cdef signed char v14
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed char v11 = self.v11
        cdef signed char v12 = self.v12
        cdef numpy.ndarray[signed char,ndim=1] v13 = self.v13
        cdef signed char v14 = self.v14
        cdef object v23
        v23 = Closure21(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v12, v13, v14, v20, v21, v22, v17, v18, v19, v15, v16)
        return UH2_0(v15, v16, v17, v18, v19, v20, v21, v22, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>50), 0, v2, v8, v23)
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
            return method45(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US0_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US0_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method45(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
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
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef signed char v12
    cdef signed char v13
    cdef object v14
    cdef signed char v15
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
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
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed char v12 = self.v12
        cdef signed char v13 = self.v13
        cdef numpy.ndarray[signed char,ndim=1] v14 = self.v14
        cdef signed char v15 = self.v15
        cdef object v24
        v24 = Closure19(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH2_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>50), 0, v2, v9, v24)
cdef class Closure6():
    cdef object v0
    cdef object v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef unsigned char v8
    cdef signed short v9
    def __init__(self, numpy.ndarray[signed char,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, float v10, float v11, UH0 v12, float v13, float v14, UH0 v15, float v16, float v17):
        cdef numpy.ndarray[signed char,ndim=1] v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed short v9 = self.v9
        cdef signed char v18
        cdef signed short v19
        cdef unsigned long long tmp13
        cdef float v20
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef numpy.ndarray[signed char,ndim=1] v25
        cdef signed char v26
        cdef signed short v27
        cdef unsigned long long tmp14
        cdef float v28
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef signed char v34
        cdef signed short v35
        cdef unsigned long long tmp15
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef numpy.ndarray[signed char,ndim=1] v41
        cdef bint v42
        cdef numpy.ndarray[signed char,ndim=1] v43
        cdef object v44
        cdef US0 v45
        cdef US0 v46
        cdef US0 v47
        cdef UH0 v48
        cdef UH0 v49
        cdef UH0 v50
        cdef US0 v51
        cdef US0 v52
        cdef US0 v53
        cdef UH0 v54
        cdef UH0 v55
        cdef UH0 v56
        v18 = v0[(<signed short>0)]
        tmp13 = len(v0)
        if <signed short>tmp13 != tmp13: raise Exception("The conversion to signed short failed.")
        v19 = <signed short>tmp13
        v20 = <float>v19
        v21 = (<float>1.000000) / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v11
        v24 = v22 + v10
        v25 = v0[1:]
        v26 = v25[(<signed short>0)]
        tmp14 = len(v25)
        if <signed short>tmp14 != tmp14: raise Exception("The conversion to signed short failed.")
        v27 = <signed short>tmp14
        v28 = <float>v27
        v29 = (<float>1.000000) / v28
        v30 = libc.math.log(v29)
        v31 = v30 + v23
        v32 = v30 + v24
        v33 = v25[1:]
        del v25
        v34 = v33[(<signed short>0)]
        tmp15 = len(v33)
        if <signed short>tmp15 != tmp15: raise Exception("The conversion to signed short failed.")
        v35 = <signed short>tmp15
        v36 = <float>v35
        v37 = (<float>1.000000) / v36
        v38 = libc.math.log(v37)
        v39 = v38 + v31
        v40 = v38 + v32
        v41 = v33[1:]
        del v33
        v42 = 1
        v43 = numpy.empty(3,dtype=numpy.int8)
        v43[0] = v18; v43[1] = v26; v43[2] = v34
        v44 = method11(v1, v42, v2, v3, v4, v5, v6, v7, v8, v9, v43, v18, v26, v41, v34)
        del v41; del v43
        v45 = US0_1(v34)
        v46 = US0_1(v26)
        v47 = US0_1(v18)
        v48 = UH0_0(v47, v12)
        del v47
        v49 = UH0_0(v46, v48)
        del v46; del v48
        v50 = UH0_0(v45, v49)
        del v45; del v49
        v51 = US0_1(v34)
        v52 = US0_1(v26)
        v53 = US0_1(v18)
        v54 = UH0_0(v53, v15)
        del v53
        v55 = UH0_0(v52, v54)
        del v52; del v54
        v56 = UH0_0(v51, v55)
        del v51; del v55
        return v44(v40, v39, v50, v13, v14, v56, v16, v17)
cdef class Closure25():
    cdef unsigned char v0
    cdef bint v1
    cdef signed char v2
    cdef signed char v3
    cdef unsigned char v4
    cdef signed short v5
    cdef signed char v6
    cdef signed char v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef UH0 v14
    cdef float v15
    cdef float v16
    cdef float v17
    cdef float v18
    def __init__(self, unsigned char v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16, float v17, float v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, float v19, float v20, US1 v21):
        cdef unsigned char v0 = self.v0
        cdef bint v1 = self.v1
        cdef signed char v2 = self.v2
        cdef signed char v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed short v5 = self.v5
        cdef signed char v6 = self.v6
        cdef signed char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[signed char,ndim=1] v9 = self.v9
        cdef numpy.ndarray[signed char,ndim=1] v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef float v15 = self.v15
        cdef float v16 = self.v16
        cdef float v17 = self.v17
        cdef float v18 = self.v18
        cdef bint v22
        cdef float v23
        cdef float v24
        cdef US0 v25
        cdef UH0 v26
        cdef US0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef UH0 v33
        cdef US0 v34
        cdef UH0 v35
        v22 = v0 == (<unsigned char>0)
        if v22:
            v23 = v20 + v16
            v24 = v19 + v15
            v25 = US0_0(v21)
            v26 = UH0_0(v25, v14)
            del v25
            v27 = US0_0(v21)
            v28 = UH0_0(v27, v11)
            del v27
            return method52(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v26, v24, v23, v28, v12, v13)
        else:
            v30 = v20 + v13
            v31 = v19 + v12
            v32 = US0_0(v21)
            v33 = UH0_0(v32, v14)
            del v32
            v34 = US0_0(v21)
            v35 = UH0_0(v34, v11)
            del v34
            return method52(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v21, v17, v18, v33, v15, v16, v35, v31, v30)
cdef class Closure24():
    cdef signed char v0
    cdef signed char v1
    cdef unsigned char v2
    cdef signed short v3
    cdef signed char v4
    cdef signed char v5
    cdef unsigned char v6
    cdef object v7
    cdef object v8
    cdef bint v9
    cdef object v10
    cdef object v11
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, numpy.ndarray[signed char,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, bint v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[signed char,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef bint v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef numpy.ndarray[signed char,ndim=1] v11 = self.v11
        cdef object v20
        v20 = Closure25(v2, v9, v4, v5, v6, v3, v0, v1, v10, v7, v11, v17, v18, v19, v14, v15, v16, v12, v13)
        return UH2_0(v12, v13, v14, v15, v16, v17, v18, v19, v0, v1, v2, v3, v4, v5, v6, v3, v7, (<signed short>50), 0, v2, v8, v20)
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
            return method49(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_0(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_0(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method49(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
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
    cdef object v9
    cdef bint v10
    cdef object v11
    cdef object v12
    def __init__(self, signed char v0, signed char v1, unsigned char v2, signed short v3, signed char v4, signed char v5, unsigned char v6, signed short v7, numpy.ndarray[signed char,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, bint v10, numpy.ndarray[object,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
        cdef signed char v0 = self.v0
        cdef signed char v1 = self.v1
        cdef unsigned char v2 = self.v2
        cdef signed short v3 = self.v3
        cdef signed char v4 = self.v4
        cdef signed char v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed short v7 = self.v7
        cdef numpy.ndarray[signed char,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef bint v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef numpy.ndarray[signed char,ndim=1] v12 = self.v12
        cdef object v21
        v21 = Closure23(v2, v10, v4, v5, v6, v7, v0, v1, v3, v11, v8, v12, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH2_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v7, v8, (<signed short>50), 0, v2, v9, v21)
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
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1, v2):
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
        cdef unsigned long long tmp9
        cdef float v30
        cdef float v31
        cdef float v32
        cdef numpy.ndarray[signed char,ndim=1] v33
        cdef signed char v34
        cdef signed short v35
        cdef unsigned long long tmp10
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef numpy.ndarray[signed char,ndim=1] v40
        cdef signed char v41
        cdef signed short v42
        cdef unsigned long long tmp11
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef numpy.ndarray[signed char,ndim=1] v47
        cdef signed char v48
        cdef signed short v49
        cdef unsigned long long tmp12
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
        v3 = numpy.empty(v0,dtype=object)
        v4 = Mut0((<unsigned long long>0))
        while method0(v0, v4):
            v6 = v4.v0
            v7 = numpy.arange(0,52,dtype=numpy.int8)
            numpy.random.shuffle(v7)
            v8 = numpy.empty((<signed short>50),dtype=object)
            v9 = Mut1((<signed short>0))
            while method8(v9):
                v11 = v9.v0
                v12 = v11 == (<signed short>0)
                if v12:
                    v20 = US1_1()
                else:
                    v14 = v11 == (<signed short>1)
                    if v14:
                        v20 = US1_0()
                    else:
                        v16 = (<signed short>50) - v11
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
            tmp9 = len(v7)
            if <signed short>tmp9 != tmp9: raise Exception("The conversion to signed short failed.")
            v29 = <signed short>tmp9
            v30 = <float>v29
            v31 = (<float>1.000000) / v30
            v32 = libc.math.log(v31)
            v33 = v7[1:]
            del v7
            v34 = v33[(<signed short>0)]
            tmp10 = len(v33)
            if <signed short>tmp10 != tmp10: raise Exception("The conversion to signed short failed.")
            v35 = <signed short>tmp10
            v36 = <float>v35
            v37 = (<float>1.000000) / v36
            v38 = libc.math.log(v37)
            v39 = v38 + v32
            v40 = v33[1:]
            del v33
            v41 = v40[(<signed short>0)]
            tmp11 = len(v40)
            if <signed short>tmp11 != tmp11: raise Exception("The conversion to signed short failed.")
            v42 = <signed short>tmp11
            v43 = <float>v42
            v44 = (<float>1.000000) / v43
            v45 = libc.math.log(v44)
            v46 = v45 + v39
            v47 = v40[1:]
            del v40
            v48 = v47[(<signed short>0)]
            tmp12 = len(v47)
            if <signed short>tmp12 != tmp12: raise Exception("The conversion to signed short failed.")
            v49 = <signed short>tmp12
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
            
            v61 = method9(v8, v55, v41, v48, v58, v59, v28, v34, v56, v57, v60, v54)
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
        return method53(v2, v1, v3)
cdef class Closure26():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1):
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut0 v3
        cdef unsigned long long v5
        cdef numpy.ndarray[signed char,ndim=1] v6
        cdef numpy.ndarray[object,ndim=1] v7
        cdef Mut1 v8
        cdef signed short v10
        cdef bint v11
        cdef US1 v19
        cdef bint v13
        cdef signed short v15
        cdef signed short v16
        cdef signed short v20
        cdef UH0 v21
        cdef float v22
        cdef float v23
        cdef UH0 v24
        cdef float v25
        cdef float v26
        cdef signed char v27
        cdef signed short v28
        cdef unsigned long long tmp43
        cdef float v29
        cdef float v30
        cdef float v31
        cdef numpy.ndarray[signed char,ndim=1] v32
        cdef signed char v33
        cdef signed short v34
        cdef unsigned long long tmp44
        cdef float v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef numpy.ndarray[signed char,ndim=1] v39
        cdef signed char v40
        cdef signed short v41
        cdef unsigned long long tmp45
        cdef float v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef numpy.ndarray[signed char,ndim=1] v46
        cdef signed char v47
        cdef signed short v48
        cdef unsigned long long tmp46
        cdef float v49
        cdef float v50
        cdef float v51
        cdef float v52
        cdef numpy.ndarray[signed char,ndim=1] v53
        cdef bint v54
        cdef unsigned char v55
        cdef signed short v56
        cdef unsigned char v57
        cdef signed short v58
        cdef numpy.ndarray[signed char,ndim=1] v59
        cdef object v60
        cdef US0 v61
        cdef US0 v62
        cdef UH0 v63
        cdef UH0 v64
        cdef US0 v65
        cdef US0 v66
        cdef UH0 v67
        cdef UH0 v68
        cdef UH2 v69
        cdef unsigned long long v70
        v2 = numpy.empty(v0,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v0, v3):
            v5 = v3.v0
            v6 = numpy.arange(0,52,dtype=numpy.int8)
            numpy.random.shuffle(v6)
            v7 = numpy.empty((<signed short>50),dtype=object)
            v8 = Mut1((<signed short>0))
            while method8(v8):
                v10 = v8.v0
                v11 = v10 == (<signed short>0)
                if v11:
                    v19 = US1_1()
                else:
                    v13 = v10 == (<signed short>1)
                    if v13:
                        v19 = US1_0()
                    else:
                        v15 = (<signed short>50) - v10
                        v16 = v15 + (<signed short>2)
                        v19 = US1_2(v16)
                v7[v10] = v19
                del v19
                v20 = v10 + (<signed short>1)
                v8.v0 = v20
            del v8
            v21 = UH0_1()
            v22 = (<float>0.000000)
            v23 = (<float>0.000000)
            v24 = UH0_1()
            v25 = (<float>0.000000)
            v26 = (<float>0.000000)
            v27 = v6[(<signed short>0)]
            tmp43 = len(v6)
            if <signed short>tmp43 != tmp43: raise Exception("The conversion to signed short failed.")
            v28 = <signed short>tmp43
            v29 = <float>v28
            v30 = (<float>1.000000) / v29
            v31 = libc.math.log(v30)
            v32 = v6[1:]
            del v6
            v33 = v32[(<signed short>0)]
            tmp44 = len(v32)
            if <signed short>tmp44 != tmp44: raise Exception("The conversion to signed short failed.")
            v34 = <signed short>tmp44
            v35 = <float>v34
            v36 = (<float>1.000000) / v35
            v37 = libc.math.log(v36)
            v38 = v37 + v31
            v39 = v32[1:]
            del v32
            v40 = v39[(<signed short>0)]
            tmp45 = len(v39)
            if <signed short>tmp45 != tmp45: raise Exception("The conversion to signed short failed.")
            v41 = <signed short>tmp45
            v42 = <float>v41
            v43 = (<float>1.000000) / v42
            v44 = libc.math.log(v43)
            v45 = v44 + v38
            v46 = v39[1:]
            del v39
            v47 = v46[(<signed short>0)]
            tmp46 = len(v46)
            if <signed short>tmp46 != tmp46: raise Exception("The conversion to signed short failed.")
            v48 = <signed short>tmp46
            v49 = <float>v48
            v50 = (<float>1.000000) / v49
            v51 = libc.math.log(v50)
            v52 = v51 + v45
            v53 = v46[1:]
            del v46
            v54 = 1
            v55 = (<unsigned char>0)
            v56 = (<signed short>1)
            v57 = (<unsigned char>1)
            v58 = (<signed short>2)
            v59 = numpy.empty(0,dtype=numpy.int8)
            
            v60 = method9(v7, v54, v40, v47, v57, v58, v27, v33, v55, v56, v59, v53)
            del v7; del v53; del v59
            v61 = US0_1(v33)
            v62 = US0_1(v27)
            v63 = UH0_0(v62, v21)
            del v21; del v62
            v64 = UH0_0(v61, v63)
            del v61; del v63
            v65 = US0_1(v47)
            v66 = US0_1(v40)
            v67 = UH0_0(v66, v24)
            del v24; del v66
            v68 = UH0_0(v65, v67)
            del v65; del v67
            v69 = v60(v52, v52, v64, v22, v23, v68, v25, v26)
            del v60; del v64; del v68
            v2[v5] = v69
            del v69
            v70 = v5 + (<unsigned long long>1)
            v3.v0 = v70
        del v3
        return method55(v1, v2)
cdef class Closure31():
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
cdef class Closure35():
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
            return method67(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method67(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure34():
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
        v25 = Closure35(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v25)
cdef class Closure33():
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
            return method64(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method64(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure32():
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
        v26 = Closure33(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH2_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v26)
cdef class Closure30():
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
        cdef unsigned long long tmp58
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
        tmp58 = len(v0)
        if <signed short>tmp58 != tmp58: raise Exception("The conversion to signed short failed.")
        v24 = <signed short>tmp58
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
        v33 = method62(v1, v2, v31, v7, v8, v9, v10, v11, v12, v13, v14, v32, v3, v4, v5, v6, v23)
        del v32
        v34 = US0_1(v23)
        v35 = UH0_0(v34, v17)
        del v34
        v36 = US0_1(v23)
        v37 = UH0_0(v36, v20)
        del v36
        return v33(v29, v28, v35, v18, v19, v37, v21, v22)
cdef class Closure39():
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
            return method71(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method71(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure38():
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
        v25 = Closure39(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v25)
cdef class Closure37():
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
            return method68(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v32, v30, v29, v34, v18, v19)
        else:
            v36 = v26 + v19
            v37 = v25 + v18
            v38 = US0_0(v27)
            v39 = UH0_0(v38, v20)
            del v38
            v40 = US0_0(v27)
            v41 = UH0_0(v40, v17)
            del v40
            return method68(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v16, v27, v23, v24, v39, v21, v22, v41, v37, v36)
cdef class Closure36():
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
        v26 = Closure37(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v14, v15, v16, v17, v23, v24, v25, v20, v21, v22, v18, v19)
        return UH2_0(v18, v19, v20, v21, v22, v23, v24, v25, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v26)
cdef class Closure29():
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
        cdef unsigned long long tmp57
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
        tmp57 = len(v0)
        if <signed short>tmp57 != tmp57: raise Exception("The conversion to signed short failed.")
        v23 = <signed short>tmp57
        v24 = <float>v23
        v25 = (<float>1.000000) / v24
        v26 = libc.math.log(v25)
        v27 = v26 + v15
        v28 = v26 + v14
        v29 = v0[1:]
        v30 = 1
        v31 = numpy.empty(4,dtype=numpy.int8)
        v31[0] = v3; v31[1] = v4; v31[2] = v5; v31[3] = v22
        v32 = method60(v1, v2, v30, v6, v7, v8, v9, v10, v11, v12, v13, v31, v3, v4, v5, v29, v22)
        del v29; del v31
        v33 = US0_1(v22)
        v34 = UH0_0(v33, v16)
        del v33
        v35 = US0_1(v22)
        v36 = UH0_0(v35, v19)
        del v35
        return v32(v28, v27, v34, v17, v18, v36, v20, v21)
cdef class Closure43():
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
            return method75(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v30, v28, v27, v32, v16, v17)
        else:
            v34 = v24 + v17
            v35 = v23 + v16
            v36 = US0_0(v25)
            v37 = UH0_0(v36, v18)
            del v36
            v38 = US0_0(v25)
            v39 = UH0_0(v38, v15)
            del v38
            return method75(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v25, v21, v22, v37, v19, v20, v39, v35, v34)
cdef class Closure42():
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
        v24 = Closure43(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v13, v14, v15, v21, v22, v23, v18, v19, v20, v16, v17)
        return UH2_0(v16, v17, v18, v19, v20, v21, v22, v23, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v24)
cdef class Closure41():
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
            return method72(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v31, v29, v28, v33, v17, v18)
        else:
            v35 = v25 + v18
            v36 = v24 + v17
            v37 = US0_0(v26)
            v38 = UH0_0(v37, v19)
            del v37
            v39 = US0_0(v26)
            v40 = UH0_0(v39, v16)
            del v39
            return method72(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v13, v14, v15, v26, v22, v23, v38, v20, v21, v40, v36, v35)
cdef class Closure40():
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
        v25 = Closure41(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v14, v15, v16, v22, v23, v24, v19, v20, v21, v17, v18)
        return UH2_0(v17, v18, v19, v20, v21, v22, v23, v24, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v25)
cdef class Closure28():
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
        cdef unsigned long long tmp54
        cdef float v21
        cdef float v22
        cdef float v23
        cdef float v24
        cdef float v25
        cdef numpy.ndarray[signed char,ndim=1] v26
        cdef signed char v27
        cdef signed short v28
        cdef unsigned long long tmp55
        cdef float v29
        cdef float v30
        cdef float v31
        cdef float v32
        cdef float v33
        cdef numpy.ndarray[signed char,ndim=1] v34
        cdef signed char v35
        cdef signed short v36
        cdef unsigned long long tmp56
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
        tmp54 = len(v0)
        if <signed short>tmp54 != tmp54: raise Exception("The conversion to signed short failed.")
        v20 = <signed short>tmp54
        v21 = <float>v20
        v22 = (<float>1.000000) / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v12
        v25 = v23 + v11
        v26 = v0[1:]
        v27 = v26[(<signed short>0)]
        tmp55 = len(v26)
        if <signed short>tmp55 != tmp55: raise Exception("The conversion to signed short failed.")
        v28 = <signed short>tmp55
        v29 = <float>v28
        v30 = (<float>1.000000) / v29
        v31 = libc.math.log(v30)
        v32 = v31 + v24
        v33 = v31 + v25
        v34 = v26[1:]
        del v26
        v35 = v34[(<signed short>0)]
        tmp56 = len(v34)
        if <signed short>tmp56 != tmp56: raise Exception("The conversion to signed short failed.")
        v36 = <signed short>tmp56
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
        v45 = method58(v1, v2, v43, v3, v4, v5, v6, v7, v8, v9, v10, v44, v19, v27, v42, v35)
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
cdef class Closure47():
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
            return method79(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v27, v25, v24, v29, v13, v14)
        else:
            v31 = v21 + v14
            v32 = v20 + v13
            v33 = US0_0(v22)
            v34 = UH0_0(v33, v15)
            del v33
            v35 = US0_0(v22)
            v36 = UH0_0(v35, v12)
            del v35
            return method79(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v22, v18, v19, v34, v16, v17, v36, v32, v31)
cdef class Closure46():
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
        v21 = Closure47(v2, v10, v4, v5, v6, v3, v0, v1, v8, v11, v7, v12, v18, v19, v20, v15, v16, v17, v13, v14)
        return UH2_0(v13, v14, v15, v16, v17, v18, v19, v20, v0, v1, v2, v3, v4, v5, v6, v3, v7, v8, 0, v2, v9, v21)
cdef class Closure45():
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
            return method76(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v28, v26, v25, v30, v14, v15)
        else:
            v32 = v22 + v15
            v33 = v21 + v14
            v34 = US0_0(v23)
            v35 = UH0_0(v34, v16)
            del v34
            v36 = US0_0(v23)
            v37 = UH0_0(v36, v13)
            del v36
            return method76(v1, v2, v3, v4, v5, v6, v7, v0, v8, v9, v10, v11, v12, v23, v19, v20, v35, v17, v18, v37, v33, v32)
cdef class Closure44():
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
        v22 = Closure45(v2, v11, v4, v5, v6, v7, v0, v1, v3, v9, v12, v8, v13, v19, v20, v21, v16, v17, v18, v14, v15)
        return UH2_0(v14, v15, v16, v17, v18, v19, v20, v21, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, 0, v2, v10, v22)
cdef class Mut3:
    cdef public signed short v0
    cdef public signed short v1
    def __init__(self, signed short v0, signed short v1): self.v0 = v0; self.v1 = v1
cdef class Closure48():
    cdef object v0
    cdef unsigned char v1
    cdef signed short v2
    cdef object v3
    def __init__(self, v0, unsigned char v1, signed short v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, signed short v4):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef signed short v2 = self.v2
        cdef object v3 = self.v3
        cdef US1 v5
        cdef UH2 v6
        v5 = US1_2(v4)
        v6 = v3((<float>0.000000), (<float>0.000000), v5)
        del v5
        method80(v0, v1, v2, v6)
cdef class Closure49():
    cdef object v0
    cdef unsigned char v1
    cdef signed short v2
    cdef object v3
    def __init__(self, v0, unsigned char v1, signed short v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef signed short v2 = self.v2
        cdef object v3 = self.v3
        cdef US1 v4
        cdef UH2 v5
        v4 = US1_0()
        v5 = v3((<float>0.000000), (<float>0.000000), v4)
        del v4
        method80(v0, v1, v2, v5)
cdef class Closure50():
    cdef object v0
    cdef unsigned char v1
    cdef signed short v2
    cdef object v3
    def __init__(self, v0, unsigned char v1, signed short v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self):
        cdef object v0 = self.v0
        cdef unsigned char v1 = self.v1
        cdef signed short v2 = self.v2
        cdef object v3 = self.v3
        cdef US1 v4
        cdef UH2 v5
        v4 = US1_1()
        v5 = v3((<float>0.000000), (<float>0.000000), v4)
        del v4
        method80(v0, v1, v2, v5)
cdef class Closure27():
    def __init__(self): pass
    def __call__(self, signed short v0, unsigned char v1, v2):
        cdef numpy.ndarray[signed char,ndim=1] v3
        cdef numpy.ndarray[object,ndim=1] v4
        cdef Mut1 v5
        cdef signed short v7
        cdef bint v8
        cdef US1 v16
        cdef bint v10
        cdef signed short v12
        cdef signed short v13
        cdef signed short v17
        cdef UH0 v18
        cdef float v19
        cdef float v20
        cdef UH0 v21
        cdef float v22
        cdef float v23
        cdef signed char v24
        cdef signed short v25
        cdef unsigned long long tmp50
        cdef float v26
        cdef float v27
        cdef float v28
        cdef numpy.ndarray[signed char,ndim=1] v29
        cdef signed char v30
        cdef signed short v31
        cdef unsigned long long tmp51
        cdef float v32
        cdef float v33
        cdef float v34
        cdef float v35
        cdef numpy.ndarray[signed char,ndim=1] v36
        cdef signed char v37
        cdef signed short v38
        cdef unsigned long long tmp52
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef numpy.ndarray[signed char,ndim=1] v43
        cdef signed char v44
        cdef signed short v45
        cdef unsigned long long tmp53
        cdef float v46
        cdef float v47
        cdef float v48
        cdef float v49
        cdef numpy.ndarray[signed char,ndim=1] v50
        cdef bint v51
        cdef unsigned char v52
        cdef signed short v53
        cdef unsigned char v54
        cdef signed short v55
        cdef numpy.ndarray[signed char,ndim=1] v56
        cdef object v57
        cdef US0 v58
        cdef US0 v59
        cdef UH0 v60
        cdef UH0 v61
        cdef US0 v62
        cdef US0 v63
        cdef UH0 v64
        cdef UH0 v65
        cdef UH2 v66
        v3 = numpy.arange(0,52,dtype=numpy.int8)
        numpy.random.shuffle(v3)
        v4 = numpy.empty(v0,dtype=object)
        v5 = Mut1((<signed short>0))
        while method7(v0, v5):
            v7 = v5.v0
            v8 = v7 == (<signed short>0)
            if v8:
                v16 = US1_1()
            else:
                v10 = v7 == (<signed short>1)
                if v10:
                    v16 = US1_0()
                else:
                    v12 = v0 - v7
                    v13 = v12 + (<signed short>2)
                    v16 = US1_2(v13)
            v4[v7] = v16
            del v16
            v17 = v7 + (<signed short>1)
            v5.v0 = v17
        del v5
        v18 = UH0_1()
        v19 = (<float>0.000000)
        v20 = (<float>0.000000)
        v21 = UH0_1()
        v22 = (<float>0.000000)
        v23 = (<float>0.000000)
        v24 = v3[(<signed short>0)]
        tmp50 = len(v3)
        if <signed short>tmp50 != tmp50: raise Exception("The conversion to signed short failed.")
        v25 = <signed short>tmp50
        v26 = <float>v25
        v27 = (<float>1.000000) / v26
        v28 = libc.math.log(v27)
        v29 = v3[1:]
        del v3
        v30 = v29[(<signed short>0)]
        tmp51 = len(v29)
        if <signed short>tmp51 != tmp51: raise Exception("The conversion to signed short failed.")
        v31 = <signed short>tmp51
        v32 = <float>v31
        v33 = (<float>1.000000) / v32
        v34 = libc.math.log(v33)
        v35 = v34 + v28
        v36 = v29[1:]
        del v29
        v37 = v36[(<signed short>0)]
        tmp52 = len(v36)
        if <signed short>tmp52 != tmp52: raise Exception("The conversion to signed short failed.")
        v38 = <signed short>tmp52
        v39 = <float>v38
        v40 = (<float>1.000000) / v39
        v41 = libc.math.log(v40)
        v42 = v41 + v35
        v43 = v36[1:]
        del v36
        v44 = v43[(<signed short>0)]
        tmp53 = len(v43)
        if <signed short>tmp53 != tmp53: raise Exception("The conversion to signed short failed.")
        v45 = <signed short>tmp53
        v46 = <float>v45
        v47 = (<float>1.000000) / v46
        v48 = libc.math.log(v47)
        v49 = v48 + v42
        v50 = v43[1:]
        del v43
        v51 = 1
        v52 = (<unsigned char>0)
        v53 = (<signed short>1)
        v54 = (<unsigned char>1)
        v55 = (<signed short>2)
        v56 = numpy.empty(0,dtype=numpy.int8)
        
        v57 = method56(v0, v4, v51, v37, v44, v54, v55, v24, v30, v52, v53, v56, v50)
        del v4; del v50; del v56
        v58 = US0_1(v30)
        v59 = US0_1(v24)
        v60 = UH0_0(v59, v18)
        del v18; del v59
        v61 = UH0_0(v58, v60)
        del v58; del v60
        v62 = US0_1(v44)
        v63 = US0_1(v37)
        v64 = UH0_0(v63, v21)
        del v21; del v63
        v65 = UH0_0(v62, v64)
        del v62; del v64
        v66 = v57(v49, v49, v61, v19, v20, v65, v22, v23)
        del v57; del v61; del v65
        method80(v2, v1, v0, v66)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple1 method1(UH0 v0, UH1 v1, bint v2):
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
        return Tuple1(v1, v2)
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
        raise Exception("Value out of bounds.")
cdef bint method7(signed short v0, Mut1 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef bint method8(Mut1 v0) except *:
    cdef signed short v1
    v1 = v0.v0
    return v1 < (<signed short>50)
cdef Tuple4 method19(unsigned long long v0, signed char v1, signed char v2):
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
            return method19(v0, v1, v80)
    else:
        v93 = v1 - (<signed char>1)
        return method18(v0, v93)
cdef Tuple5 method22(unsigned long long v0, signed char v1, signed char v2, signed char v3, unsigned char v4, signed char v5, signed char v6, signed char v7, signed char v8, signed char v9):
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
                return method22(v0, v1, v2, v44, v42, v37, v38, v39, v40, v41)
            else:
                return Tuple5(v37, v38, v39, v40, v41)
        else:
            v55 = v3 + (<signed char>1)
            return method22(v0, v1, v2, v55, v4, v5, v6, v7, v8, v9)
    else:
        v66 = v2 - (<signed char>1)
        return method21(v0, v1, v66, v5, v6, v7, v8, v9, v4)
cdef Tuple5 method21(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
    cdef bint v9
    cdef signed char v10
    cdef bint v16
    cdef signed char v17
    v9 = v2 == v1
    if v9:
        v10 = v2 - (<signed char>1)
        return method21(v0, v1, v10, v3, v4, v5, v6, v7, v8)
    else:
        v16 = (<signed char>0) <= v2
        if v16:
            v17 = (<signed char>0)
            return method22(v0, v1, v2, v17, v8, v3, v4, v5, v6, v7)
        else:
            return Tuple5(v3, v4, v5, v6, v7)
cdef Tuple6 method24(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7):
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
        return method24(v0, v1, v36, v32, v33, v34, v35, v37)
    else:
        return Tuple6(v3, v4, v5, v6)
cdef Tuple4 method27(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8):
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
        return method27(v0, v1, v48, v41, v42, v43, v44, v45, v46)
cdef Tuple5 method33(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, unsigned char v5, signed char v6, signed char v7, signed char v8, signed char v9, signed char v10):
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
                return method33(v0, v1, v2, v3, v45, v43, v38, v39, v40, v41, v42)
            else:
                return Tuple5(v38, v39, v40, v41, v42)
        else:
            v56 = v4 + (<signed char>1)
            return method33(v0, v1, v2, v3, v56, v5, v6, v7, v8, v9, v10)
    else:
        v67 = v3 - (<signed char>1)
        return method32(v0, v1, v2, v67, v6, v7, v8, v9, v10, v5)
cdef Tuple5 method32(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8, unsigned char v9):
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
        return method32(v0, v1, v2, v13, v4, v5, v6, v7, v8, v9)
    else:
        v19 = (<signed char>0) <= v3
        if v19:
            v20 = (<signed char>0)
            return method33(v0, v1, v2, v3, v20, v9, v4, v5, v6, v7, v8)
        else:
            return Tuple5(v4, v5, v6, v7, v8)
cdef Tuple5 method36(unsigned long long v0, signed char v1, signed char v2, unsigned char v3, signed char v4, signed char v5, signed char v6, signed char v7, signed char v8):
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
                return method36(v0, v1, v43, v41, v36, v37, v38, v39, v40)
            else:
                return Tuple5(v36, v37, v38, v39, v40)
        else:
            v54 = v2 + (<signed char>1)
            return method36(v0, v1, v54, v3, v4, v5, v6, v7, v8)
    else:
        v65 = v1 - (<signed char>1)
        return method35(v0, v65, v4, v5, v6, v7, v8, v3)
cdef Tuple5 method35(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7):
    cdef bint v8
    cdef signed char v9
    v8 = (<signed char>0) <= v1
    if v8:
        v9 = (<signed char>0)
        return method36(v0, v1, v9, v7, v2, v3, v4, v5, v6)
    else:
        return Tuple5(v2, v3, v4, v5, v6)
cdef Tuple4 method34(unsigned long long v0, signed char v1):
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
    cdef Tuple6 tmp31
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
    cdef Tuple5 tmp32
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
    cdef Tuple5 tmp33
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
            tmp31 = method24(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp31.v0, tmp31.v1, tmp31.v2, tmp31.v3
            del tmp31
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp32 = method21(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp32.v0, tmp32.v1, tmp32.v2, tmp32.v3, tmp32.v4
            del tmp32
            return Tuple4(v40, v41, v51, v52, v53, (<signed char>2))
        else:
            v56 = v1 - (<signed char>1)
            return method34(v0, v56)
    else:
        v69 = (<signed char>12)
        v70 = (<signed char>-1)
        v71 = (<signed char>-1)
        v72 = (<signed char>-1)
        v73 = (<signed char>-1)
        v74 = (<signed char>-1)
        v75 = (<unsigned char>0)
        tmp33 = method35(v0, v69, v70, v71, v72, v73, v74, v75)
        v76, v77, v78, v79, v80 = tmp33.v0, tmp33.v1, tmp33.v2, tmp33.v3, tmp33.v4
        del tmp33
        return Tuple4(v76, v77, v78, v79, v80, (<signed char>1))
cdef Tuple4 method31(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4):
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
    cdef Tuple6 tmp29
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
    cdef Tuple5 tmp30
    cdef signed char v67
    cdef signed char v80
    v5 = v1 == v4
    if v5:
        v6 = v4 - (<signed char>1)
        return method31(v0, v1, v2, v3, v6)
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
                tmp29 = method24(v0, v4, v49, v45, v46, v47, v48, v50)
                v51, v52, v53, v54 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3
                del tmp29
                v55 = (<signed char>12)
                v56 = (<signed char>-1)
                v57 = (<signed char>-1)
                v58 = (<signed char>-1)
                v59 = (<signed char>-1)
                v60 = (<signed char>-1)
                v61 = (<unsigned char>0)
                tmp30 = method32(v0, v1, v4, v55, v56, v57, v58, v59, v60, v61)
                v62, v63, v64, v65, v66 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3, tmp30.v4
                del tmp30
                return Tuple4(v3, v2, v51, v52, v62, (<signed char>3))
            else:
                v67 = v4 - (<signed char>1)
                return method31(v0, v1, v2, v3, v67)
        else:
            v80 = (<signed char>12)
            return method34(v0, v80)
cdef Tuple4 method30(unsigned long long v0, signed char v1):
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
            tmp28 = method24(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp28.v0, tmp28.v1, tmp28.v2, tmp28.v3
            del tmp28
            v44 = (<signed char>12)
            return method31(v0, v1, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method30(v0, v51)
    else:
        v64 = (<signed char>12)
        return method34(v0, v64)
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
    cdef Tuple6 tmp26
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
    cdef Tuple5 tmp27
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
            tmp26 = method24(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp26.v0, tmp26.v1, tmp26.v2, tmp26.v3
            del tmp26
            v44 = (<signed char>12)
            v45 = (<signed char>-1)
            v46 = (<signed char>-1)
            v47 = (<signed char>-1)
            v48 = (<signed char>-1)
            v49 = (<signed char>-1)
            v50 = (<unsigned char>0)
            tmp27 = method21(v0, v1, v44, v45, v46, v47, v48, v49, v50)
            v51, v52, v53, v54, v55 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3, tmp27.v4
            del tmp27
            return Tuple4(v40, v41, v42, v51, v52, (<signed char>4))
        else:
            v56 = v1 - (<signed char>1)
            return method29(v0, v56)
    else:
        v69 = (<signed char>12)
        return method30(v0, v69)
cdef Tuple4 method28(unsigned long long v0, signed char v1):
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
    cdef Tuple6 tmp21
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
    cdef Tuple6 tmp22
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
    cdef Tuple6 tmp23
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
    cdef Tuple6 tmp24
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
    cdef Tuple6 tmp25
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
            tmp21 = method24(v0, v157, v162, v158, v159, v160, v161, v163)
            v164, v165, v166, v167 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3
            del tmp21
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
            tmp22 = method24(v0, v171, v176, v172, v173, v174, v175, v177)
            v178, v179, v180, v181 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3
            del tmp22
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
            tmp23 = method24(v0, v185, v190, v186, v187, v188, v189, v191)
            v192, v193, v194, v195 = tmp23.v0, tmp23.v1, tmp23.v2, tmp23.v3
            del tmp23
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
            tmp24 = method24(v0, v199, v204, v200, v201, v202, v203, v205)
            v206, v207, v208, v209 = tmp24.v0, tmp24.v1, tmp24.v2, tmp24.v3
            del tmp24
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
            tmp25 = method24(v0, v212, v217, v213, v214, v215, v216, v218)
            v219, v220, v221, v222 = tmp25.v0, tmp25.v1, tmp25.v2, tmp25.v3
            del tmp25
            return Tuple4(v164, v178, v192, v206, v219, (<signed char>5))
        else:
            v223 = v1 - (<signed char>1)
            return method28(v0, v223)
    else:
        v236 = (<signed char>12)
        return method29(v0, v236)
cdef Tuple4 method26(unsigned long long v0, signed char v1, unsigned char v2, unsigned char v3, unsigned char v4, unsigned char v5):
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
            return method27(v0, v39, v40, v41, v42, v43, v44, v45, v46)
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
                return method27(v0, v54, v55, v56, v57, v58, v59, v60, v61)
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
                    return method27(v0, v69, v70, v71, v72, v73, v74, v75, v76)
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
                        return method27(v0, v84, v85, v86, v87, v88, v89, v90, v91)
                    else:
                        v98 = v1 - (<signed char>1)
                        return method26(v0, v98, v37, v29, v21, v13)
    else:
        v129 = (<signed char>8)
        return method28(v0, v129)
cdef Tuple4 method25(unsigned long long v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
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
    cdef Tuple6 tmp20
    cdef signed char v56
    cdef signed char v69
    cdef unsigned char v70
    cdef unsigned char v71
    cdef unsigned char v72
    cdef unsigned char v73
    v6 = v1 == v5
    if v6:
        v7 = v5 - (<signed char>1)
        return method25(v0, v1, v2, v3, v4, v7)
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
                tmp20 = method24(v0, v5, v50, v46, v47, v48, v49, v51)
                v52, v53, v54, v55 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3
                del tmp20
                return Tuple4(v4, v3, v2, v52, v53, (<signed char>7))
            else:
                v56 = v5 - (<signed char>1)
                return method25(v0, v1, v2, v3, v4, v56)
        else:
            v69 = (<signed char>12)
            v70 = (<unsigned char>0)
            v71 = (<unsigned char>0)
            v72 = (<unsigned char>0)
            v73 = (<unsigned char>0)
            return method26(v0, v69, v73, v72, v71, v70)
cdef Tuple4 method23(unsigned long long v0, signed char v1):
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
    cdef Tuple6 tmp19
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
            tmp19 = method24(v0, v1, v38, v34, v35, v36, v37, v39)
            v40, v41, v42, v43 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3
            del tmp19
            v44 = (<signed char>12)
            return method25(v0, v1, v42, v41, v40, v44)
        else:
            v51 = v1 - (<signed char>1)
            return method23(v0, v51)
    else:
        v64 = (<signed char>12)
        v65 = (<unsigned char>0)
        v66 = (<unsigned char>0)
        v67 = (<unsigned char>0)
        v68 = (<unsigned char>0)
        return method26(v0, v64, v68, v67, v66, v65)
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
    cdef unsigned char v40
    cdef signed char v41
    cdef signed char v42
    cdef signed char v43
    cdef signed char v44
    cdef signed char v45
    cdef Tuple5 tmp18
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
            tmp18 = method21(v0, v1, v34, v35, v36, v37, v38, v39, v40)
            v41, v42, v43, v44, v45 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4
            del tmp18
            return Tuple4(v1, v9, v17, v25, v41, (<signed char>8))
        else:
            v46 = v1 - (<signed char>1)
            return method20(v0, v46)
    else:
        v59 = (<signed char>12)
        return method23(v0, v59)
cdef Tuple4 method18(unsigned long long v0, signed char v1):
    cdef bint v2
    cdef signed char v3
    cdef signed char v10
    v2 = (<signed char>-1) <= v1
    if v2:
        v3 = (<signed char>0)
        return method19(v0, v1, v3)
    else:
        v10 = (<signed char>12)
        return method20(v0, v10)
cdef Tuple4 method17(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6):
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
    return method18(v27, v28)
cdef object method16(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12):
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
    cdef Tuple4 tmp34
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef Tuple4 tmp35
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
    v13 = v11 == (<unsigned char>0)
    if v13:
        v14, v15, v16, v17, v18, v19, v20, v21 = v9, v10, v11, v12, v5, v6, v7, v8
    else:
        v14, v15, v16, v17, v18, v19, v20, v21 = v5, v6, v7, v8, v9, v10, v11, v12
    v22 = numpy.empty(5,dtype=numpy.int8)
    v22[0] = v0; v22[1] = v1; v22[2] = v2; v22[3] = v3; v22[4] = v4
    tmp34 = method17(v4, v3, v2, v1, v0, v15, v14)
    v23, v24, v25, v26, v27, v28 = tmp34.v0, tmp34.v1, tmp34.v2, tmp34.v3, tmp34.v4, tmp34.v5
    del tmp34
    tmp35 = method17(v4, v3, v2, v1, v0, v19, v18)
    v29, v30, v31, v32, v33, v34 = tmp35.v0, tmp35.v1, tmp35.v2, tmp35.v3, tmp35.v4, tmp35.v5
    del tmp35
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
        return Closure9(v14, v15, v16, v17, v18, v19, v20, v21, v22, v80)
    else:
        v82 = v78 == (<signed long>1)
        if v82:
            v83 = <float>v17
            return Closure9(v14, v15, v16, v17, v18, v19, v20, v21, v22, v83)
        else:
            v85 = -v17
            v86 = <float>v85
            return Closure9(v14, v15, v16, v17, v18, v19, v20, v21, v22, v86)
cdef object method39(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11):
    cdef bint v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef numpy.ndarray[signed char,ndim=1] v21
    cdef signed char v22
    cdef signed char v23
    cdef signed char v24
    cdef signed char v25
    cdef signed char v26
    cdef signed char v27
    cdef Tuple4 tmp36
    cdef signed char v28
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef Tuple4 tmp37
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
    cdef bint v44
    cdef signed long v47
    cdef bint v45
    cdef bint v48
    cdef signed long v77
    cdef bint v49
    cdef signed long v52
    cdef bint v50
    cdef bint v53
    cdef bint v54
    cdef signed long v57
    cdef bint v55
    cdef bint v58
    cdef bint v59
    cdef signed long v62
    cdef bint v60
    cdef bint v63
    cdef bint v64
    cdef signed long v67
    cdef bint v65
    cdef bint v68
    cdef bint v69
    cdef bint v70
    cdef bint v78
    cdef float v79
    cdef bint v81
    cdef float v82
    cdef signed short v84
    cdef float v85
    v12 = v11 == (<unsigned char>0)
    if v12:
        v13, v14, v15, v16, v17, v18, v19, v20 = v9, v10, v11, v8, v5, v6, v7, v8
    else:
        v13, v14, v15, v16, v17, v18, v19, v20 = v5, v6, v7, v8, v9, v10, v11, v8
    v21 = numpy.empty(5,dtype=numpy.int8)
    v21[0] = v0; v21[1] = v1; v21[2] = v2; v21[3] = v3; v21[4] = v4
    tmp36 = method17(v4, v3, v2, v1, v0, v14, v13)
    v22, v23, v24, v25, v26, v27 = tmp36.v0, tmp36.v1, tmp36.v2, tmp36.v3, tmp36.v4, tmp36.v5
    del tmp36
    tmp37 = method17(v4, v3, v2, v1, v0, v18, v17)
    v28, v29, v30, v31, v32, v33 = tmp37.v0, tmp37.v1, tmp37.v2, tmp37.v3, tmp37.v4, tmp37.v5
    del tmp37
    v34 = v22 % (<signed char>13)
    v35 = v23 % (<signed char>13)
    v36 = v24 % (<signed char>13)
    v37 = v25 % (<signed char>13)
    v38 = v26 % (<signed char>13)
    v39 = v28 % (<signed char>13)
    v40 = v29 % (<signed char>13)
    v41 = v30 % (<signed char>13)
    v42 = v31 % (<signed char>13)
    v43 = v32 % (<signed char>13)
    v44 = v27 < v33
    if v44:
        v47 = (<signed long>-1)
    else:
        v45 = v27 > v33
        if v45:
            v47 = (<signed long>1)
        else:
            v47 = (<signed long>0)
    v48 = v47 == (<signed long>0)
    if v48:
        v49 = v34 < v39
        if v49:
            v52 = (<signed long>-1)
        else:
            v50 = v34 > v39
            if v50:
                v52 = (<signed long>1)
            else:
                v52 = (<signed long>0)
        v53 = v52 == (<signed long>0)
        if v53:
            v54 = v35 < v40
            if v54:
                v57 = (<signed long>-1)
            else:
                v55 = v35 > v40
                if v55:
                    v57 = (<signed long>1)
                else:
                    v57 = (<signed long>0)
            v58 = v57 == (<signed long>0)
            if v58:
                v59 = v36 < v41
                if v59:
                    v62 = (<signed long>-1)
                else:
                    v60 = v36 > v41
                    if v60:
                        v62 = (<signed long>1)
                    else:
                        v62 = (<signed long>0)
                v63 = v62 == (<signed long>0)
                if v63:
                    v64 = v37 < v42
                    if v64:
                        v67 = (<signed long>-1)
                    else:
                        v65 = v37 > v42
                        if v65:
                            v67 = (<signed long>1)
                        else:
                            v67 = (<signed long>0)
                    v68 = v67 == (<signed long>0)
                    if v68:
                        v69 = v38 < v43
                        if v69:
                            v77 = (<signed long>-1)
                        else:
                            v70 = v38 > v43
                            if v70:
                                v77 = (<signed long>1)
                            else:
                                v77 = (<signed long>0)
                    else:
                        v77 = v67
                else:
                    v77 = v62
            else:
                v77 = v57
        else:
            v77 = v52
    else:
        v77 = v47
    v78 = v77 == (<signed long>0)
    if v78:
        v79 = <float>(<signed short>0)
        return Closure9(v13, v14, v15, v16, v17, v18, v19, v20, v21, v79)
    else:
        v81 = v77 == (<signed long>1)
        if v81:
            v82 = <float>v16
            return Closure9(v13, v14, v15, v16, v17, v18, v19, v20, v21, v82)
        else:
            v84 = -v16
            v85 = <float>v84
            return Closure9(v13, v14, v15, v16, v17, v18, v19, v20, v21, v85)
cdef UH2 method40(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, signed char v13, signed char v14, US1 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
            v27 = method38(v8, v24, v5, v6, v7, v4, v1, v2, v3, v9, v10, v11, v12, v13, v14)
        else:
            v27 = method39(v10, v11, v12, v13, v14, v1, v2, v3, v4, v5, v6, v7)
        return v27(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v29 = v7 == (<unsigned char>0)
        if v29:
            v31 = -v4
        else:
            v31 = v4
        v32 = <float>v31
        return UH2_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v4, v1, v2, v3, v4, v9, (<signed short>50), 0, v32)
    elif v15.tag == 2: # raiseTo_
        v34 = (<US1_2>v15).v0
        v35 = 0
        v36 = method15(v8, v35, v5, v6, v7, v34, v1, v2, v3, v4, v9, v10, v11, v12, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method38(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, signed char v13, signed char v14):
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
    v15 = v5 == (<signed short>50)
    if v15:
        return method39(v10, v11, v12, v13, v14, v2, v3, v4, v5, v6, v7, v8)
    else:
        v17 = v5 >= v5
        v18 = v5 < v5
        v19 = v5 + (<signed short>1)
        v20 = (<signed short>50) < v19
        if v20:
            v21 = (<signed short>50)
        else:
            v21 = v19
        v22 = (<signed short>50) == v5
        if v22:
            v23 = (<signed short>1)
        else:
            v23 = (<signed short>0)
        v24 = v21 + v23
        v25 = v0[(<signed short>1):3+(<signed short>50)-v24]
        return Closure12(v6, v7, v8, v5, v2, v3, v4, v9, v25, v1, v0, v10, v11, v12, v13, v14)
cdef UH2 method37(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
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
            v28 = method38(v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method39(v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v8
        else:
            v32 = v8
        v33 = <float>v32
        return UH2_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v8, v1, v2, v3, v4, v10, (<signed short>50), 0, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US1_2>v16).v0
        v36 = 0
        v37 = method15(v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method15(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
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
    v16 = v9 == (<signed short>50)
    if v16:
        return method16(v11, v12, v13, v14, v15, v2, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v9 == v5
        v19 = v18 != 1
        v20 = v9 >= v5
        if v20:
            v21 = v9
        else:
            v21 = v5
        v22 = v9 < v5
        if v22:
            v23 = v9
        else:
            v23 = v5
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
        v29 = (<signed short>50) < v27
        if v29:
            v30 = (<signed short>50)
        else:
            v30 = v27
        v31 = (<signed short>50) == v21
        if v31:
            v32 = (<signed short>1)
        else:
            v32 = (<signed short>0)
        v33 = v30 + v32
        v34 = v0[v28:3+(<signed short>50)-v33]
        return Closure10(v6, v7, v8, v9, v2, v3, v4, v5, v10, v34, v1, v0, v11, v12, v13, v14, v15)
cdef object method14(numpy.ndarray[object,ndim=1] v0, signed char v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13):
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
cdef object method43(numpy.ndarray[object,ndim=1] v0, signed char v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12):
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
cdef UH2 method44(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US1 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
            v27 = method42(v8, v24, v5, v6, v7, v4, v1, v2, v3, v9, v10, v11, v12, v13, v14)
        else:
            v27 = method43(v8, v10, v11, v12, v13, v14, v1, v2, v3, v4, v5, v6, v7)
        return v27(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v29 = v7 == (<unsigned char>0)
        if v29:
            v31 = -v4
        else:
            v31 = v4
        v32 = <float>v31
        return UH2_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v4, v1, v2, v3, v4, v9, (<signed short>50), 0, v32)
    elif v15.tag == 2: # raiseTo_
        v34 = (<US1_2>v15).v0
        v35 = 0
        v36 = method13(v8, v35, v5, v6, v7, v34, v1, v2, v3, v4, v9, v10, v11, v12, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method42(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
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
    v15 = v5 == (<signed short>50)
    if v15:
        return method43(v0, v10, v11, v12, v13, v14, v2, v3, v4, v5, v6, v7, v8)
    else:
        v17 = v5 >= v5
        v18 = v5 < v5
        v19 = v5 + (<signed short>1)
        v20 = (<signed short>50) < v19
        if v20:
            v21 = (<signed short>50)
        else:
            v21 = v19
        v22 = (<signed short>50) == v5
        if v22:
            v23 = (<signed short>1)
        else:
            v23 = (<signed short>0)
        v24 = v21 + v23
        v25 = v0[(<signed short>1):3+(<signed short>50)-v24]
        return Closure16(v6, v7, v8, v5, v2, v3, v4, v9, v25, v1, v0, v10, v11, v12, v13, v14)
cdef UH2 method41(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
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
            v28 = method42(v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method43(v9, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
        return v28(v17, v18, v19, v20, v21, v22, v23, v24)
    elif v16.tag == 1: # fold
        v30 = v7 == (<unsigned char>0)
        if v30:
            v32 = -v8
        else:
            v32 = v8
        v33 = <float>v32
        return UH2_1(v17, v18, v19, v20, v21, v22, v23, v24, v5, v6, v7, v8, v1, v2, v3, v4, v10, (<signed short>50), 0, v33)
    elif v16.tag == 2: # raiseTo_
        v35 = (<US1_2>v16).v0
        v36 = 0
        v37 = method13(v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method13(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
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
    v16 = v9 == (<signed short>50)
    if v16:
        return method14(v0, v11, v12, v13, v14, v15, v2, v3, v4, v5, v6, v7, v8, v9)
    else:
        v18 = v9 == v5
        v19 = v18 != 1
        v20 = v9 >= v5
        if v20:
            v21 = v9
        else:
            v21 = v5
        v22 = v9 < v5
        if v22:
            v23 = v9
        else:
            v23 = v5
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
        v29 = (<signed short>50) < v27
        if v29:
            v30 = (<signed short>50)
        else:
            v30 = v27
        v31 = (<signed short>50) == v21
        if v31:
            v32 = (<signed short>1)
        else:
            v32 = (<signed short>0)
        v33 = v30 + v32
        v34 = v0[v28:3+(<signed short>50)-v33]
        return Closure14(v6, v7, v8, v9, v2, v3, v4, v5, v10, v34, v1, v0, v11, v12, v13, v14, v15)
cdef object method12(numpy.ndarray[object,ndim=1] v0, signed char v1, signed char v2, numpy.ndarray[signed char,ndim=1] v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11, signed short v12):
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
    return Closure7(v3, v0, v1, v2, v4, v18, v19, v20, v21, v14, v15, v16, v17)
cdef object method47(numpy.ndarray[object,ndim=1] v0, signed char v1, signed char v2, numpy.ndarray[signed char,ndim=1] v3, signed char v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed char v9, signed char v10, unsigned char v11):
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
    return Closure7(v3, v0, v1, v2, v4, v17, v18, v19, v20, v13, v14, v15, v16)
cdef UH2 method48(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13, US1 v14, float v15, float v16, UH0 v17, float v18, float v19, UH0 v20, float v21, float v22):
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
            v26 = method46(v8, v23, v5, v6, v7, v4, v1, v2, v3, v9, v10, v11, v12, v13)
        else:
            v26 = method47(v8, v10, v11, v12, v13, v1, v2, v3, v4, v5, v6, v7)
        return v26(v15, v16, v17, v18, v19, v20, v21, v22)
    elif v14.tag == 1: # fold
        v28 = v7 == (<unsigned char>0)
        if v28:
            v30 = -v4
        else:
            v30 = v4
        v31 = <float>v30
        return UH2_1(v15, v16, v17, v18, v19, v20, v21, v22, v5, v6, v7, v4, v1, v2, v3, v4, v9, (<signed short>50), 0, v31)
    elif v14.tag == 2: # raiseTo_
        v33 = (<US1_2>v14).v0
        v34 = 0
        v35 = method11(v8, v34, v5, v6, v7, v33, v1, v2, v3, v4, v9, v10, v11, v12, v13)
        return v35(v15, v16, v17, v18, v19, v20, v21, v22)
cdef object method46(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, signed char v10, signed char v11, numpy.ndarray[signed char,ndim=1] v12, signed char v13):
    cdef bint v14
    cdef bint v16
    cdef bint v17
    cdef signed short v18
    cdef bint v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef signed short v23
    cdef numpy.ndarray[object,ndim=1] v24
    v14 = v5 == (<signed short>50)
    if v14:
        return method47(v0, v10, v11, v12, v13, v2, v3, v4, v5, v6, v7, v8)
    else:
        v16 = v5 >= v5
        v17 = v5 < v5
        v18 = v5 + (<signed short>1)
        v19 = (<signed short>50) < v18
        if v19:
            v20 = (<signed short>50)
        else:
            v20 = v18
        v21 = (<signed short>50) == v5
        if v21:
            v22 = (<signed short>1)
        else:
            v22 = (<signed short>0)
        v23 = v20 + v22
        v24 = v0[(<signed short>1):3+(<signed short>50)-v23]
        return Closure20(v6, v7, v8, v5, v2, v3, v4, v9, v24, v1, v0, v10, v11, v12, v13)
cdef UH2 method45(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US1 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
            v27 = method46(v9, v24, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14)
        else:
            v27 = method47(v9, v11, v12, v13, v14, v1, v2, v3, v4, v5, v6, v7)
        return v27(v16, v17, v18, v19, v20, v21, v22, v23)
    elif v15.tag == 1: # fold
        v29 = v7 == (<unsigned char>0)
        if v29:
            v31 = -v8
        else:
            v31 = v8
        v32 = <float>v31
        return UH2_1(v16, v17, v18, v19, v20, v21, v22, v23, v5, v6, v7, v8, v1, v2, v3, v4, v10, (<signed short>50), 0, v32)
    elif v15.tag == 2: # raiseTo_
        v34 = (<US1_2>v15).v0
        v35 = 0
        v36 = method11(v9, v35, v5, v6, v7, v34, v1, v2, v3, v4, v10, v11, v12, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method11(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
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
    v15 = v9 == (<signed short>50)
    if v15:
        return method12(v0, v11, v12, v13, v14, v2, v3, v4, v5, v6, v7, v8, v9)
    else:
        v17 = v9 == v5
        v18 = v17 != 1
        v19 = v9 >= v5
        if v19:
            v20 = v9
        else:
            v20 = v5
        v21 = v9 < v5
        if v21:
            v22 = v9
        else:
            v22 = v5
        v23 = v20 - v22
        v24 = (<signed short>1) >= v23
        if v24:
            v25 = (<signed short>1)
        else:
            v25 = v23
        v26 = v20 + v25
        if v18:
            v27 = (<signed short>0)
        else:
            v27 = (<signed short>1)
        v28 = (<signed short>50) < v26
        if v28:
            v29 = (<signed short>50)
        else:
            v29 = v26
        v30 = (<signed short>50) == v20
        if v30:
            v31 = (<signed short>1)
        else:
            v31 = (<signed short>0)
        v32 = v29 + v31
        v33 = v0[v27:3+(<signed short>50)-v32]
        return Closure18(v6, v7, v8, v9, v2, v3, v4, v5, v10, v33, v1, v0, v11, v12, v13, v14)
cdef object method10(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9):
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
    return Closure6(v1, v0, v15, v16, v17, v18, v11, v12, v13, v14)
cdef object method51(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8):
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
    return Closure6(v1, v0, v14, v15, v16, v17, v10, v11, v12, v13)
cdef UH2 method52(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[signed char,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, US1 v11, float v12, float v13, UH0 v14, float v15, float v16, UH0 v17, float v18, float v19):
    cdef object v23
    cdef bint v20
    cdef bint v25
    cdef signed short v27
    cdef float v28
    cdef signed short v30
    cdef bint v31
    cdef object v32
    if v11.tag == 0: # call
        if v0:
            v20 = 0
            v23 = method50(v8, v20, v5, v6, v7, v4, v1, v2, v3, v9, v10)
        else:
            v23 = method51(v8, v10, v1, v2, v3, v4, v5, v6, v7)
        return v23(v12, v13, v14, v15, v16, v17, v18, v19)
    elif v11.tag == 1: # fold
        v25 = v7 == (<unsigned char>0)
        if v25:
            v27 = -v4
        else:
            v27 = v4
        v28 = <float>v27
        return UH2_1(v12, v13, v14, v15, v16, v17, v18, v19, v5, v6, v7, v4, v1, v2, v3, v4, v9, (<signed short>50), 0, v28)
    elif v11.tag == 2: # raiseTo_
        v30 = (<US1_2>v11).v0
        v31 = 0
        v32 = method9(v8, v31, v5, v6, v7, v30, v1, v2, v3, v4, v9, v10)
        return v32(v12, v13, v14, v15, v16, v17, v18, v19)
cdef object method50(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, numpy.ndarray[signed char,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10):
    cdef bint v11
    cdef bint v13
    cdef bint v14
    cdef signed short v15
    cdef bint v16
    cdef signed short v17
    cdef bint v18
    cdef signed short v19
    cdef signed short v20
    cdef numpy.ndarray[object,ndim=1] v21
    v11 = v5 == (<signed short>50)
    if v11:
        return method51(v0, v10, v2, v3, v4, v5, v6, v7, v8)
    else:
        v13 = v5 >= v5
        v14 = v5 < v5
        v15 = v5 + (<signed short>1)
        v16 = (<signed short>50) < v15
        if v16:
            v17 = (<signed short>50)
        else:
            v17 = v15
        v18 = (<signed short>50) == v5
        if v18:
            v19 = (<signed short>1)
        else:
            v19 = (<signed short>0)
        v20 = v17 + v19
        v21 = v0[(<signed short>1):3+(<signed short>50)-v20]
        return Closure24(v6, v7, v8, v5, v2, v3, v4, v9, v21, v1, v0, v10)
cdef UH2 method49(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
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
            v24 = method50(v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v24 = method51(v9, v11, v1, v2, v3, v4, v5, v6, v7)
        return v24(v13, v14, v15, v16, v17, v18, v19, v20)
    elif v12.tag == 1: # fold
        v26 = v7 == (<unsigned char>0)
        if v26:
            v28 = -v8
        else:
            v28 = v8
        v29 = <float>v28
        return UH2_1(v13, v14, v15, v16, v17, v18, v19, v20, v5, v6, v7, v8, v1, v2, v3, v4, v10, (<signed short>50), 0, v29)
    elif v12.tag == 2: # raiseTo_
        v31 = (<US1_2>v12).v0
        v32 = 0
        v33 = method9(v9, v32, v5, v6, v7, v31, v1, v2, v3, v4, v10, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method9(numpy.ndarray[object,ndim=1] v0, bint v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11):
    cdef bint v12
    cdef bint v14
    cdef bint v15
    cdef bint v16
    cdef signed short v17
    cdef bint v18
    cdef signed short v19
    cdef signed short v20
    cdef bint v21
    cdef signed short v22
    cdef signed short v23
    cdef signed short v24
    cdef bint v25
    cdef signed short v26
    cdef bint v27
    cdef signed short v28
    cdef signed short v29
    cdef numpy.ndarray[object,ndim=1] v30
    v12 = v9 == (<signed short>50)
    if v12:
        return method10(v0, v11, v2, v3, v4, v5, v6, v7, v8, v9)
    else:
        v14 = v9 == v5
        v15 = v14 != 1
        v16 = v9 >= v5
        if v16:
            v17 = v9
        else:
            v17 = v5
        v18 = v9 < v5
        if v18:
            v19 = v9
        else:
            v19 = v5
        v20 = v17 - v19
        v21 = (<signed short>1) >= v20
        if v21:
            v22 = (<signed short>1)
        else:
            v22 = v20
        v23 = v17 + v22
        if v15:
            v24 = (<signed short>0)
        else:
            v24 = (<signed short>1)
        v25 = (<signed short>50) < v23
        if v25:
            v26 = (<signed short>50)
        else:
            v26 = v23
        v27 = (<signed short>50) == v17
        if v27:
            v28 = (<signed short>1)
        else:
            v28 = (<signed short>0)
        v29 = v26 + v28
        v30 = v0[v24:3+(<signed short>50)-v29]
        return Closure22(v6, v7, v8, v9, v2, v3, v4, v5, v10, v30, v1, v0, v11)
cdef bint method54(unsigned long long v0, Mut2 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method53(v0, v1, numpy.ndarray[object,ndim=1] v2):
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
    cdef Tuple3 tmp38
    cdef numpy.ndarray[object,ndim=1] v63
    cdef object v64
    cdef Tuple3 tmp39
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
    cdef Tuple2 tmp40
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
    cdef Tuple2 tmp41
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
    cdef Tuple7 tmp42
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
        tmp38 = v1(v5)
        v61, v62 = tmp38.v0, tmp38.v1
        del tmp38
        tmp39 = v0(v6)
        v63, v64 = tmp39.v0, tmp39.v1
        del tmp39
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
            tmp40 = v61[v72]
            v74, v75, v76 = tmp40.v0, tmp40.v1, tmp40.v2
            del tmp40
            v77 = v73(v74, v75, v76)
            del v73; del v76
            v69[v72] = v77
            del v77
            v78 = v72 + (<unsigned long long>1)
            v70.v0 = v78
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
            tmp41 = v63[v86]
            v88, v89, v90 = tmp41.v0, tmp41.v1, tmp41.v2
            del tmp41
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
        v106 = method53(v0, v1, v96)
        del v96
        v107 = v106[:v61]
        v108 = v62(v107)
        del v62; del v107
        v109 = v106[v61:]
        del v61; del v106
        v110 = v64(v109)
        del v64; del v109
        v111 = len(v9)
        v112 = [None]*v111
        v113 = Mut2((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method54(v111, v113):
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
        tmp42 = v3[v146]
        v147, v148, v149, v150, v151, v152, v153, v154, v155, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167 = tmp42.v0, tmp42.v1, tmp42.v2, tmp42.v3, tmp42.v4, tmp42.v5, tmp42.v6, tmp42.v7, tmp42.v8, tmp42.v9, tmp42.v10, tmp42.v11, tmp42.v12, tmp42.v13, tmp42.v14, tmp42.v15, tmp42.v16, tmp42.v17, tmp42.v18, tmp42.v19, tmp42.v20
        del tmp42
        del v150; del v153; del v164
        v132[v147] = v167
        v168 = v146 + (<unsigned long long>1)
        v144.v0 = v168
    del v3
    del v144
    return v132
cdef numpy.ndarray[float,ndim=1] method55(v0, numpy.ndarray[object,ndim=1] v1):
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
    cdef Tuple3 tmp47
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
    cdef Tuple2 tmp48
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
    cdef Tuple7 tmp49
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
        tmp47 = v0(v4)
        v56, v57 = tmp47.v0, tmp47.v1
        del tmp47
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
            tmp48 = v56[v65]
            v67, v68, v69 = tmp48.v0, tmp48.v1, tmp48.v2
            del tmp48
            v70 = v66(v67, v68, v69)
            del v66; del v69
            v62[v65] = v70
            del v70
            v71 = v65 + (<unsigned long long>1)
            v63.v0 = v71
        del v56
        del v63
        v72 = method55(v0, v62)
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
        tmp49 = v2[v90]
        v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108, v109, v110, v111 = tmp49.v0, tmp49.v1, tmp49.v2, tmp49.v3, tmp49.v4, tmp49.v5, tmp49.v6, tmp49.v7, tmp49.v8, tmp49.v9, tmp49.v10, tmp49.v11, tmp49.v12, tmp49.v13, tmp49.v14, tmp49.v15, tmp49.v16, tmp49.v17, tmp49.v18, tmp49.v19, tmp49.v20
        del tmp49
        del v94; del v97; del v108
        v76[v91] = v111
        v112 = v90 + (<unsigned long long>1)
        v88.v0 = v112
    del v2
    del v88
    return v76
cdef object method63(signed short v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13):
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
    cdef Tuple4 tmp59
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef signed char v35
    cdef Tuple4 tmp60
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
    tmp59 = method17(v5, v4, v3, v2, v1, v16, v15)
    v24, v25, v26, v27, v28, v29 = tmp59.v0, tmp59.v1, tmp59.v2, tmp59.v3, tmp59.v4, tmp59.v5
    del tmp59
    tmp60 = method17(v5, v4, v3, v2, v1, v20, v19)
    v30, v31, v32, v33, v34, v35 = tmp60.v0, tmp60.v1, tmp60.v2, tmp60.v3, tmp60.v4, tmp60.v5
    del tmp60
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
        return Closure31(v15, v16, v17, v18, v19, v20, v21, v22, v23, v0, v81)
    else:
        v83 = v79 == (<signed long>1)
        if v83:
            v84 = <float>v18
            return Closure31(v15, v16, v17, v18, v19, v20, v21, v22, v23, v0, v84)
        else:
            v86 = -v18
            v87 = <float>v86
            return Closure31(v15, v16, v17, v18, v19, v20, v21, v22, v23, v0, v87)
cdef object method66(signed short v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12):
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
    cdef Tuple4 tmp61
    cdef signed char v29
    cdef signed char v30
    cdef signed char v31
    cdef signed char v32
    cdef signed char v33
    cdef signed char v34
    cdef Tuple4 tmp62
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
    tmp61 = method17(v5, v4, v3, v2, v1, v15, v14)
    v23, v24, v25, v26, v27, v28 = tmp61.v0, tmp61.v1, tmp61.v2, tmp61.v3, tmp61.v4, tmp61.v5
    del tmp61
    tmp62 = method17(v5, v4, v3, v2, v1, v19, v18)
    v29, v30, v31, v32, v33, v34 = tmp62.v0, tmp62.v1, tmp62.v2, tmp62.v3, tmp62.v4, tmp62.v5
    del tmp62
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
        return Closure31(v14, v15, v16, v17, v18, v19, v20, v21, v22, v0, v80)
    else:
        v82 = v78 == (<signed long>1)
        if v82:
            v83 = <float>v17
            return Closure31(v14, v15, v16, v17, v18, v19, v20, v21, v22, v0, v83)
        else:
            v85 = -v17
            v86 = <float>v85
            return Closure31(v14, v15, v16, v17, v18, v19, v20, v21, v22, v0, v86)
cdef UH2 method67(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
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
            v28 = method65(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method66(v8, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
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
        v37 = method62(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method65(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, signed char v14, signed char v15):
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
        return method66(v0, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure34(v7, v8, v9, v6, v3, v4, v5, v10, v0, v26, v2, v1, v11, v12, v13, v14, v15)
cdef UH2 method64(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
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
            v29 = method65(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method66(v9, v12, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
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
        v38 = method62(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method62(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, signed char v15, signed char v16):
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
        return method63(v0, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v8, v9, v10)
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
        return Closure32(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v35, v2, v1, v12, v13, v14, v15, v16)
cdef object method61(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, numpy.ndarray[signed char,ndim=1] v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed short v10, signed char v11, signed char v12, unsigned char v13, signed short v14):
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
    return Closure30(v5, v0, v1, v2, v3, v4, v6, v20, v21, v22, v23, v16, v17, v18, v19)
cdef object method70(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, signed char v4, numpy.ndarray[signed char,ndim=1] v5, signed char v6, signed char v7, signed char v8, unsigned char v9, signed short v10, signed char v11, signed char v12, unsigned char v13):
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
    return Closure30(v5, v0, v1, v2, v3, v4, v6, v19, v20, v21, v22, v15, v16, v17, v18)
cdef UH2 method71(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
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
            v28 = method69(v8, v9, v25, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14, v15)
        else:
            v28 = method70(v8, v9, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
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
        v37 = method60(v8, v9, v36, v5, v6, v7, v35, v1, v2, v3, v4, v10, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method69(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
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
        return method70(v0, v1, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure38(v7, v8, v9, v6, v3, v4, v5, v10, v0, v26, v2, v1, v11, v12, v13, v14, v15)
cdef UH2 method68(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16, US1 v17, float v18, float v19, UH0 v20, float v21, float v22, UH0 v23, float v24, float v25):
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
            v29 = method69(v9, v10, v26, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15, v16)
        else:
            v29 = method70(v9, v10, v12, v13, v14, v15, v16, v1, v2, v3, v4, v5, v6, v7)
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
        v38 = method60(v9, v10, v37, v5, v6, v7, v36, v1, v2, v3, v4, v11, v12, v13, v14, v15, v16)
        return v38(v18, v19, v20, v21, v22, v23, v24, v25)
cdef object method60(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, signed char v14, numpy.ndarray[signed char,ndim=1] v15, signed char v16):
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
        return method61(v0, v1, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v8, v9, v10)
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
        return Closure36(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v35, v2, v1, v12, v13, v14, v15, v16)
cdef object method59(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12, signed short v13):
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
    return Closure29(v4, v0, v1, v2, v3, v5, v19, v20, v21, v22, v15, v16, v17, v18)
cdef object method74(signed short v0, numpy.ndarray[object,ndim=1] v1, signed char v2, signed char v3, numpy.ndarray[signed char,ndim=1] v4, signed char v5, signed char v6, signed char v7, unsigned char v8, signed short v9, signed char v10, signed char v11, unsigned char v12):
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
    return Closure29(v4, v0, v1, v2, v3, v5, v18, v19, v20, v21, v14, v15, v16, v17)
cdef UH2 method75(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14, US1 v15, float v16, float v17, UH0 v18, float v19, float v20, UH0 v21, float v22, float v23):
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
            v27 = method73(v8, v9, v24, v5, v6, v7, v4, v1, v2, v3, v10, v11, v12, v13, v14)
        else:
            v27 = method74(v8, v9, v11, v12, v13, v14, v1, v2, v3, v4, v5, v6, v7)
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
        v36 = method58(v8, v9, v35, v5, v6, v7, v34, v1, v2, v3, v4, v10, v11, v12, v13, v14)
        return v36(v16, v17, v18, v19, v20, v21, v22, v23)
cdef object method73(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, signed char v11, signed char v12, numpy.ndarray[signed char,ndim=1] v13, signed char v14):
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
        return method74(v0, v1, v11, v12, v13, v14, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure42(v7, v8, v9, v6, v3, v4, v5, v10, v0, v25, v2, v1, v11, v12, v13, v14)
cdef UH2 method72(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15, US1 v16, float v17, float v18, UH0 v19, float v20, float v21, UH0 v22, float v23, float v24):
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
            v28 = method73(v9, v10, v25, v5, v6, v7, v4, v1, v2, v3, v11, v12, v13, v14, v15)
        else:
            v28 = method74(v9, v10, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v7)
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
        v37 = method58(v9, v10, v36, v5, v6, v7, v35, v1, v2, v3, v4, v11, v12, v13, v14, v15)
        return v37(v17, v18, v19, v20, v21, v22, v23, v24)
cdef object method58(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, signed char v12, signed char v13, numpy.ndarray[signed char,ndim=1] v14, signed char v15):
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
        return method59(v0, v1, v12, v13, v14, v15, v3, v4, v5, v6, v7, v8, v9, v10)
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
        return Closure40(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v34, v2, v1, v12, v13, v14, v15)
cdef object method57(signed short v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed char,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10):
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
    return Closure28(v2, v0, v1, v16, v17, v18, v19, v12, v13, v14, v15)
cdef object method78(signed short v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed char,ndim=1] v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9):
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
    return Closure28(v2, v0, v1, v15, v16, v17, v18, v11, v12, v13, v14)
cdef UH2 method79(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, numpy.ndarray[object,ndim=1] v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, US1 v12, float v13, float v14, UH0 v15, float v16, float v17, UH0 v18, float v19, float v20):
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
            v24 = method77(v8, v9, v21, v5, v6, v7, v4, v1, v2, v3, v10, v11)
        else:
            v24 = method78(v8, v9, v11, v1, v2, v3, v4, v5, v6, v7)
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
        v33 = method56(v8, v9, v32, v5, v6, v7, v31, v1, v2, v3, v4, v10, v11)
        return v33(v13, v14, v15, v16, v17, v18, v19, v20)
cdef object method77(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, numpy.ndarray[signed char,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11):
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
        return method78(v0, v1, v11, v3, v4, v5, v6, v7, v8, v9)
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
        return Closure46(v7, v8, v9, v6, v3, v4, v5, v10, v0, v22, v2, v1, v11)
cdef UH2 method76(bint v0, signed char v1, signed char v2, unsigned char v3, signed short v4, signed char v5, signed char v6, unsigned char v7, signed short v8, signed short v9, numpy.ndarray[object,ndim=1] v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12, US1 v13, float v14, float v15, UH0 v16, float v17, float v18, UH0 v19, float v20, float v21):
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
            v25 = method77(v9, v10, v22, v5, v6, v7, v4, v1, v2, v3, v11, v12)
        else:
            v25 = method78(v9, v10, v12, v1, v2, v3, v4, v5, v6, v7)
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
        v34 = method56(v9, v10, v33, v5, v6, v7, v32, v1, v2, v3, v4, v11, v12)
        return v34(v14, v15, v16, v17, v18, v19, v20, v21)
cdef object method56(signed short v0, numpy.ndarray[object,ndim=1] v1, bint v2, signed char v3, signed char v4, unsigned char v5, signed short v6, signed char v7, signed char v8, unsigned char v9, signed short v10, numpy.ndarray[signed char,ndim=1] v11, numpy.ndarray[signed char,ndim=1] v12):
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
        return method57(v0, v1, v12, v3, v4, v5, v6, v7, v8, v9, v10)
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
        return Closure44(v7, v8, v9, v10, v3, v4, v5, v6, v11, v0, v31, v2, v1, v12)
cdef UH2 method81(unsigned char v0, UH2 v1):
    cdef float v2
    cdef float v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef signed char v10
    cdef signed char v11
    cdef unsigned char v12
    cdef signed short v13
    cdef signed char v14
    cdef signed char v15
    cdef unsigned char v16
    cdef signed short v17
    cdef numpy.ndarray[signed char,ndim=1] v18
    cdef signed short v19
    cdef bint v20
    cdef unsigned char v21
    cdef numpy.ndarray[object,ndim=1] v22
    cdef object v23
    cdef bint v24
    cdef list v25
    cdef unsigned long long v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef Mut0 v28
    cdef unsigned long long v30
    cdef float v31
    cdef float v32
    cdef UH0 v33
    cdef float v34
    cdef float v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef signed char v39
    cdef signed char v40
    cdef unsigned char v41
    cdef signed short v42
    cdef signed char v43
    cdef signed char v44
    cdef unsigned char v45
    cdef signed short v46
    cdef numpy.ndarray[signed char,ndim=1] v47
    cdef signed short v48
    cdef bint v49
    cdef unsigned char v50
    cdef numpy.ndarray[object,ndim=1] v51
    cdef Tuple0 tmp63
    cdef signed short v52
    cdef unsigned long long tmp64
    cdef float v53
    cdef float v54
    cdef float v55
    cdef US1 v56
    cdef unsigned long long v57
    cdef float v58
    cdef float v59
    cdef US1 v60
    cdef Tuple2 tmp65
    cdef UH2 v61
    cdef float v64
    cdef float v65
    cdef float v67
    cdef float v68
    cdef float v70
    cdef float v71
    cdef signed char v72
    cdef signed char v73
    cdef unsigned char v74
    cdef signed short v75
    cdef signed char v76
    cdef signed char v77
    cdef unsigned char v78
    cdef signed short v79
    cdef signed short v81
    cdef bint v82
    cdef float v83
    if v1.tag == 0: # action_
        v2 = (<UH2_0>v1).v0; v3 = (<UH2_0>v1).v1; v4 = (<UH2_0>v1).v2; v5 = (<UH2_0>v1).v3; v6 = (<UH2_0>v1).v4; v7 = (<UH2_0>v1).v5; v8 = (<UH2_0>v1).v6; v9 = (<UH2_0>v1).v7; v10 = (<UH2_0>v1).v8; v11 = (<UH2_0>v1).v9; v12 = (<UH2_0>v1).v10; v13 = (<UH2_0>v1).v11; v14 = (<UH2_0>v1).v12; v15 = (<UH2_0>v1).v13; v16 = (<UH2_0>v1).v14; v17 = (<UH2_0>v1).v15; v18 = (<UH2_0>v1).v16; v19 = (<UH2_0>v1).v17; v20 = (<UH2_0>v1).v18; v21 = (<UH2_0>v1).v19; v22 = (<UH2_0>v1).v20; v23 = (<UH2_0>v1).v21
        v24 = v21 == v0
        if v24:
            del v4; del v7; del v18; del v22; del v23
            return v1
        else:
            v25 = [None]*(<unsigned long long>1)
            v25[(<unsigned long long>0)] = Tuple0(v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22)
            del v4; del v7; del v18; del v22
            v26 = len(v25)
            v27 = numpy.empty(v26,dtype=object)
            v28 = Mut0((<unsigned long long>0))
            while method0(v26, v28):
                v30 = v28.v0
                tmp63 = v25[v30]
                v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51 = tmp63.v0, tmp63.v1, tmp63.v2, tmp63.v3, tmp63.v4, tmp63.v5, tmp63.v6, tmp63.v7, tmp63.v8, tmp63.v9, tmp63.v10, tmp63.v11, tmp63.v12, tmp63.v13, tmp63.v14, tmp63.v15, tmp63.v16, tmp63.v17, tmp63.v18, tmp63.v19, tmp63.v20
                del tmp63
                del v33; del v36; del v47
                tmp64 = len(v51)
                if <signed short>tmp64 != tmp64: raise Exception("The conversion to signed short failed.")
                v52 = <signed short>tmp64
                v53 = <float>v52
                v54 = (<float>1.000000) / v53
                v55 = libc.math.log(v54)
                v56 = numpy.random.choice(v51)
                del v51
                v27[v30] = Tuple2(v55, v55, v56)
                del v56
                v57 = v30 + (<unsigned long long>1)
                v28.v0 = v57
            del v25
            del v28
            tmp65 = v27[(<unsigned long long>0)]
            v58, v59, v60 = tmp65.v0, tmp65.v1, tmp65.v2
            del tmp65
            del v27
            v61 = v23(v58, v59, v60)
            del v23; del v60
            return method81(v0, v61)
    elif v1.tag == 1: # terminal_
        v64 = (<UH2_1>v1).v0; v65 = (<UH2_1>v1).v1; v67 = (<UH2_1>v1).v3; v68 = (<UH2_1>v1).v4; v70 = (<UH2_1>v1).v6; v71 = (<UH2_1>v1).v7; v72 = (<UH2_1>v1).v8; v73 = (<UH2_1>v1).v9; v74 = (<UH2_1>v1).v10; v75 = (<UH2_1>v1).v11; v76 = (<UH2_1>v1).v12; v77 = (<UH2_1>v1).v13; v78 = (<UH2_1>v1).v14; v79 = (<UH2_1>v1).v15; v81 = (<UH2_1>v1).v17; v82 = (<UH2_1>v1).v18; v83 = (<UH2_1>v1).v19
        return v1
cdef UH0 method83(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method83(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef void method85(list v0, list v1) except *:
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
cdef str method86(signed char v0):
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
cdef void method84(list v0, list v1, bint v2, UH0 v3) except *:
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
            method85(v0, v1)
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
            method84(v0, v1, v13, v5)
        elif v4.tag == 1: # observation_
            v14 = (<US0_1>v4).v0
            v15 = method86(v14)
            v1.append(v15)
            del v15
            v16 = 1
            method84(v0, v1, v16, v5)
    elif v3.tag == 1: # nil
        method85(v0, v1)
cdef list method82(UH0 v0):
    cdef list v1
    cdef list v2
    cdef bint v3
    cdef UH0 v4
    cdef UH0 v5
    v1 = [None]*(<unsigned long long>0)
    v2 = [None]*(<unsigned long long>0)
    v3 = 1
    v4 = UH0_1()
    v5 = method83(v0, v4)
    del v4
    method84(v1, v2, v3, v5)
    del v2; del v5
    return v1
cdef bint method87(signed short v0, Mut3 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef str method88(signed char v0, signed char v1):
    cdef str v2
    cdef str v3
    v2 = method86(v1)
    v3 = method86(v0)
    return f'{v2}{v3}'
cdef str method91(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4, signed char v5):
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
cdef str method92(signed char v0, signed char v1, signed char v2, signed char v3, signed char v4):
    cdef str v5
    cdef str v6
    cdef str v7
    cdef str v8
    cdef str v9
    v5 = method86(v4)
    v6 = method86(v3)
    v7 = method86(v2)
    v8 = method86(v1)
    v9 = method86(v0)
    return f'{v5}{v6}{v7}{v8}{v9}'
cdef void method90(numpy.ndarray[signed char,ndim=1] v0, list v1, unsigned char v2, signed char v3, signed char v4) except *:
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
    cdef Tuple4 tmp68
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
    tmp68 = method17(v11, v10, v9, v8, v7, v4, v3)
    v12, v13, v14, v15, v16, v17 = tmp68.v0, tmp68.v1, tmp68.v2, tmp68.v3, tmp68.v4, tmp68.v5
    del tmp68
    v18 = method91(v12, v13, v14, v15, v16, v17)
    v19 = method92(v16, v15, v14, v13, v12)
    v20 = f'{v6} shows {v18} {v19}'
    del v6; del v18; del v19
    v1.append(v20)
cdef void method93(float v0, list v1, unsigned char v2) except *:
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
cdef str method89(bint v0, numpy.ndarray[signed char,ndim=1] v1, signed char v2, signed char v3, unsigned char v4, signed short v5, signed char v6, signed char v7, unsigned char v8, signed short v9, float v10, list v11):
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
        method90(v1, v11, v21, v13, v14)
        v22 = (<unsigned char>1)
        method90(v1, v11, v22, v17, v18)
    else:
        pass
    v23 = (<unsigned char>0)
    method93(v10, v11, v23)
    v24 = (<unsigned char>1)
    method93(v10, v11, v24)
    return "\n".join(v11)
cdef void method80(v0, unsigned char v1, signed short v2, UH2 v3) except *:
    cdef UH2 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef UH0 v10
    cdef float v11
    cdef float v12
    cdef signed char v13
    cdef signed char v14
    cdef unsigned char v15
    cdef signed short v16
    cdef signed char v17
    cdef signed char v18
    cdef unsigned char v19
    cdef signed short v20
    cdef numpy.ndarray[signed char,ndim=1] v21
    cdef signed short v22
    cdef bint v23
    cdef unsigned char v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef object v26
    cdef bint v27
    cdef UH0 v28
    cdef list v29
    cdef str v30
    cdef signed short v31
    cdef unsigned long long tmp66
    cdef Mut3 v32
    cdef signed short v34
    cdef signed short v35
    cdef US1 v36
    cdef signed short v40
    cdef signed short v37
    cdef bint v38
    cdef signed short v41
    cdef signed short v42
    cdef Mut3 v43
    cdef signed short v45
    cdef signed short v46
    cdef US1 v47
    cdef signed short v51
    cdef signed short v48
    cdef bint v49
    cdef signed short v52
    cdef signed short v53
    cdef bint v54
    cdef object v57
    cdef object v58
    cdef object v59
    cdef object v60
    cdef bint v61
    cdef signed char v62
    cdef signed char v63
    cdef unsigned char v64
    cdef signed short v65
    cdef signed char v66
    cdef signed char v67
    cdef unsigned char v68
    cdef signed short v69
    cdef signed short v70
    cdef str v71
    cdef signed short v72
    cdef str v73
    cdef signed short v74
    cdef unsigned long long tmp67
    cdef list v75
    cdef Mut1 v76
    cdef signed short v78
    cdef signed char v79
    cdef str v80
    cdef signed short v81
    cdef str v82
    cdef object v83
    cdef object v84
    cdef float v85
    cdef float v86
    cdef UH0 v87
    cdef float v88
    cdef float v89
    cdef UH0 v90
    cdef float v91
    cdef float v92
    cdef signed char v93
    cdef signed char v94
    cdef unsigned char v95
    cdef signed short v96
    cdef signed char v97
    cdef signed char v98
    cdef unsigned char v99
    cdef signed short v100
    cdef numpy.ndarray[signed char,ndim=1] v101
    cdef signed short v102
    cdef bint v103
    cdef float v104
    cdef bint v105
    cdef UH0 v106
    cdef list v107
    cdef str v108
    cdef object v109
    cdef object v110
    cdef object v111
    cdef object v112
    cdef float v114
    cdef signed short v115
    cdef bint v116
    cdef signed char v117
    cdef signed char v118
    cdef unsigned char v119
    cdef signed short v120
    cdef signed char v121
    cdef signed char v122
    cdef unsigned char v123
    cdef signed short v124
    cdef signed short v125
    cdef str v126
    cdef signed short v127
    cdef str v128
    cdef signed short v129
    cdef unsigned long long tmp69
    cdef list v130
    cdef Mut1 v131
    cdef signed short v133
    cdef signed char v134
    cdef str v135
    cdef signed short v136
    cdef str v137
    cdef object v138
    cdef object v139
    v4 = method81(v1, v3)
    if v4.tag == 0: # action_
        v5 = (<UH2_0>v4).v0; v6 = (<UH2_0>v4).v1; v7 = (<UH2_0>v4).v2; v8 = (<UH2_0>v4).v3; v9 = (<UH2_0>v4).v4; v10 = (<UH2_0>v4).v5; v11 = (<UH2_0>v4).v6; v12 = (<UH2_0>v4).v7; v13 = (<UH2_0>v4).v8; v14 = (<UH2_0>v4).v9; v15 = (<UH2_0>v4).v10; v16 = (<UH2_0>v4).v11; v17 = (<UH2_0>v4).v12; v18 = (<UH2_0>v4).v13; v19 = (<UH2_0>v4).v14; v20 = (<UH2_0>v4).v15; v21 = (<UH2_0>v4).v16; v22 = (<UH2_0>v4).v17; v23 = (<UH2_0>v4).v18; v24 = (<UH2_0>v4).v19; v25 = (<UH2_0>v4).v20; v26 = (<UH2_0>v4).v21
        v27 = v1 == (<unsigned char>0)
        if v27:
            v28 = v7
        else:
            v28 = v10
        del v7; del v10
        v29 = method82(v28)
        del v28
        v30 = "\n".join(v29)
        del v29
        tmp66 = len(v25)
        if <signed short>tmp66 != tmp66: raise Exception("The conversion to signed short failed.")
        v31 = <signed short>tmp66
        v32 = Mut3((<signed short>0), (<signed short>0))
        while method87(v31, v32):
            v34 = v32.v0
            v35 = v32.v1
            v36 = v25[v34]
            if v36.tag == 0: # call
                v40 = v35
            elif v36.tag == 1: # fold
                v40 = v35
            elif v36.tag == 2: # raiseTo_
                v37 = (<US1_2>v36).v0
                v38 = v35 >= v37
                if v38:
                    v40 = v35
                else:
                    v40 = v37
            del v36
            v41 = v34 + (<signed short>1)
            v32.v0 = v41
            v32.v1 = v40
        v42 = v32.v1
        del v32
        v43 = Mut3((<signed short>0), v42)
        while method87(v31, v43):
            v45 = v43.v0
            v46 = v43.v1
            v47 = v25[v45]
            if v47.tag == 0: # call
                v51 = v46
            elif v47.tag == 1: # fold
                v51 = v46
            elif v47.tag == 2: # raiseTo_
                v48 = (<US1_2>v47).v0
                v49 = v46 < v48
                if v49:
                    v51 = v46
                else:
                    v51 = v48
            del v47
            v52 = v45 + (<signed short>1)
            v43.v0 = v52
            v43.v1 = v51
        del v25
        v53 = v43.v1
        del v43
        v54 = v53 == (<signed short>0)
        if v54:
            v57 = False
        else:
            v57 = Closure48(v0, v1, v2, v26)
        v58 = Closure49(v0, v1, v2, v26)
        v59 = Closure50(v0, v1, v2, v26)
        del v26
        v60 = {'call': v58, 'fold': v59, 'raise_max': v42, 'raise_min': v53, 'raise_to': v57}
        del v57; del v58; del v59
        v61 = v1 == v15
        if v61:
            v62, v63, v64, v65, v66, v67, v68, v69 = v13, v14, v15, v16, v17, v18, v19, v20
        else:
            v62, v63, v64, v65, v66, v67, v68, v69 = v17, v18, v19, v20, v13, v14, v15, v16
        v70 = v2 - v65
        v71 = method88(v63, v62)
        v72 = v2 - v69
        v73 = method88(v67, v66)
        tmp67 = len(v21)
        if <signed short>tmp67 != tmp67: raise Exception("The conversion to signed short failed.")
        v74 = <signed short>tmp67
        v75 = [None]*v74
        v76 = Mut1((<signed short>0))
        while method7(v74, v76):
            v78 = v76.v0
            v79 = v21[v78]
            v80 = method86(v79)
            v75[v78] = v80
            del v80
            v81 = v78 + (<signed short>1)
            v76.v0 = v81
        del v21
        del v76
        v82 = "".join(v75)
        del v75
        v83 = {'community_card': v82, 'my_card': v71, 'my_pot': v65, 'my_stack': v70, 'op_card': v73, 'op_pot': v69, 'op_stack': v72}
        del v71; del v73; del v82
        v84 = {'actions': v60, 'table_data': v83, 'trace': v30}
        del v30; del v60; del v83
        v0(v84)
    elif v4.tag == 1: # terminal_
        v85 = (<UH2_1>v4).v0; v86 = (<UH2_1>v4).v1; v87 = (<UH2_1>v4).v2; v88 = (<UH2_1>v4).v3; v89 = (<UH2_1>v4).v4; v90 = (<UH2_1>v4).v5; v91 = (<UH2_1>v4).v6; v92 = (<UH2_1>v4).v7; v93 = (<UH2_1>v4).v8; v94 = (<UH2_1>v4).v9; v95 = (<UH2_1>v4).v10; v96 = (<UH2_1>v4).v11; v97 = (<UH2_1>v4).v12; v98 = (<UH2_1>v4).v13; v99 = (<UH2_1>v4).v14; v100 = (<UH2_1>v4).v15; v101 = (<UH2_1>v4).v16; v102 = (<UH2_1>v4).v17; v103 = (<UH2_1>v4).v18; v104 = (<UH2_1>v4).v19
        v105 = v1 == (<unsigned char>0)
        if v105:
            v106 = v87
        else:
            v106 = v90
        del v87; del v90
        v107 = method82(v106)
        del v106
        v108 = method89(v103, v101, v97, v98, v99, v100, v93, v94, v95, v96, v104, v107)
        del v107
        v109 = False
        v110 = False
        v111 = False
        v112 = {'call': v109, 'fold': v110, 'raise_max': (<signed short>0), 'raise_min': (<signed short>0), 'raise_to': v111}
        del v109; del v110; del v111
        if v105:
            v114 = v104
        else:
            v114 = -v104
        v115 = round(v114)
        v116 = v1 == v95
        if v116:
            v117, v118, v119, v120, v121, v122, v123, v124 = v93, v94, v95, v96, v97, v98, v99, v100
        else:
            v117, v118, v119, v120, v121, v122, v123, v124 = v97, v98, v99, v100, v93, v94, v95, v96
        v125 = v102 + v115
        v126 = method88(v118, v117)
        v127 = v102 - v115
        v128 = method88(v122, v121)
        tmp69 = len(v101)
        if <signed short>tmp69 != tmp69: raise Exception("The conversion to signed short failed.")
        v129 = <signed short>tmp69
        v130 = [None]*v129
        v131 = Mut1((<signed short>0))
        while method7(v129, v131):
            v133 = v131.v0
            v134 = v101[v133]
            v135 = method86(v134)
            v130[v133] = v135
            del v135
            v136 = v133 + (<signed short>1)
            v131.v0 = v136
        del v101
        del v131
        v137 = "".join(v130)
        del v130
        v138 = {'community_card': v137, 'my_card': v126, 'my_pot': (<signed short>0), 'my_stack': v125, 'op_card': v128, 'op_pot': (<signed short>0), 'op_stack': v127}
        del v126; del v128; del v137
        v139 = {'actions': v112, 'table_data': v138, 'trace': v108}
        del v108; del v112; del v138
        v0(v139)
cpdef object main():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    v0 = collections.namedtuple("Size",['action', 'policy', 'value'])((<signed short>102), (<signed short>659), (<signed short>693))
    v1 = Closure0()
    v2 = collections.namedtuple("Neural",['handler', 'size'])(v1, v0)
    del v0; del v1
    v3 = Closure3()
    v4 = Closure5()
    v5 = Closure26()
    v6 = {'neural': v2, 'uniform_player': v3, 'vs_one': v4, 'vs_self': v5}
    del v2; del v3; del v4; del v5
    v7 = Closure27()
    return {'train': v6, 'ui': v7}
