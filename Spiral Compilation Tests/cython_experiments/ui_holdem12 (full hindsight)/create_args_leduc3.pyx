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
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
ctypedef signed long US1
ctypedef signed long US2
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # c1of2_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # c2of2_
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
cdef class Tuple1:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly bint v14
    cdef readonly US1 v15
    cdef readonly unsigned char v16
    cdef readonly object v17
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, unsigned char v16, v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # c1of2_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US3_1(US3): # c2of2_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US3 v0
    cdef readonly UH1 v1
    def __init__(self, US3 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class Mut1:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
cdef class Mut2:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Tuple2:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US2 v2
    def __init__(self, float v0, float v1, US2 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
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
        cdef Mut1 v10
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
        cdef US1 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef US1 v25
        cdef unsigned char v26
        cdef signed long v27
        cdef bint v28
        cdef US1 v29
        cdef unsigned char v30
        cdef numpy.ndarray[signed long,ndim=1] v31
        cdef Tuple1 tmp3
        cdef bint v32
        cdef float v34
        cdef float v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef unsigned long long v45
        cdef unsigned long long v46
        cdef object v47
        cdef numpy.ndarray[float,ndim=1] v48
        cdef unsigned long long v49
        cdef unsigned long long v50
        cdef bint v51
        cdef bint v52
        cdef numpy.ndarray[float,ndim=1] v53
        cdef Mut1 v54
        cdef unsigned long long v56
        cdef float v57
        cdef float v58
        cdef float v59
        cdef UH0 v60
        cdef float v61
        cdef float v62
        cdef UH0 v63
        cdef float v64
        cdef float v65
        cdef US1 v66
        cdef unsigned char v67
        cdef signed long v68
        cdef US1 v69
        cdef unsigned char v70
        cdef signed long v71
        cdef bint v72
        cdef US1 v73
        cdef unsigned char v74
        cdef numpy.ndarray[signed long,ndim=1] v75
        cdef Tuple1 tmp4
        cdef bint v76
        cdef float v78
        cdef float v77
        cdef unsigned long long v79
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
        v10 = Mut1((<unsigned long long>0))
        while method3(v6, v10):
            v12 = v10.v0
            v13 = v3[v12]
            tmp3 = v0[v12]
            v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4, tmp3.v5, tmp3.v6, tmp3.v7, tmp3.v8, tmp3.v9, tmp3.v10, tmp3.v11, tmp3.v12, tmp3.v13, tmp3.v14, tmp3.v15, tmp3.v16, tmp3.v17
            del tmp3
            del v16; del v19; del v31
            v32 = v30 == (<unsigned char>0)
            if v32:
                v34 = v13
            else:
                v34 = -v13
            v5[v12] = v34
            if v32:
                v35, v36, v37, v38 = v17, v18, v20, v21
            else:
                v35, v36, v37, v38 = v20, v21, v17, v18
            v39 = v15 + v38
            v40 = v14 + v37
            v41 = -v36
            v42 = v40 - v39
            v43 = v41 + v42
            v44 = libc.math.exp(v43)
            v45 = v1 + v12
            v5[v45] = v44
            v46 = v12 + (<unsigned long long>1)
            v10.v0 = v46
        del v10
        v47 = torch.from_numpy(v5)
        del v5
        v48 = v2(v47)
        del v47
        v49 = len(v48)
        v50 = len(v0)
        v51 = v49 == v50
        v52 = v51 == 0
        if v52:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v53 = numpy.empty(v49,dtype=numpy.float32)
        v54 = Mut1((<unsigned long long>0))
        while method3(v49, v54):
            v56 = v54.v0
            v57 = v48[v56]
            tmp4 = v0[v56]
            v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3, tmp4.v4, tmp4.v5, tmp4.v6, tmp4.v7, tmp4.v8, tmp4.v9, tmp4.v10, tmp4.v11, tmp4.v12, tmp4.v13, tmp4.v14, tmp4.v15, tmp4.v16, tmp4.v17
            del tmp4
            del v60; del v63; del v75
            v76 = v74 == (<unsigned char>0)
            if v76:
                v78 = v57
            else:
                v77 = -v57
                v78 = v77
            v53[v56] = v78
            v79 = v56 + (<unsigned long long>1)
            v54.v0 = v79
        del v48
        del v54
        return v53
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
        cdef unsigned long long v7
        cdef Mut0 v8
        cdef unsigned long long v10
        cdef unsigned long long v11
        cdef unsigned long long v12
        cdef float v13
        cdef float v14
        cdef UH0 v15
        cdef float v16
        cdef float v17
        cdef UH0 v18
        cdef float v19
        cdef float v20
        cdef US1 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US1 v24
        cdef unsigned char v25
        cdef signed long v26
        cdef bint v27
        cdef US1 v28
        cdef unsigned char v29
        cdef numpy.ndarray[signed long,ndim=1] v30
        cdef Tuple1 tmp0
        cdef bint v31
        cdef UH0 v32
        cdef UH1 v37
        cdef US3 v34
        cdef UH1 v35
        cdef unsigned long long v38
        cdef unsigned long long v39
        cdef bint v40
        cdef unsigned long long v41
        cdef unsigned long long v42
        cdef unsigned long long v43
        cdef bint v44
        cdef unsigned long long v45
        cdef unsigned long long v46
        cdef unsigned long long v47
        cdef unsigned long long v48
        cdef unsigned long long v49
        cdef numpy.ndarray[float,ndim=3] v50
        cdef numpy.ndarray[signed char,ndim=2] v51
        cdef numpy.ndarray[float,ndim=3] v52
        cdef numpy.ndarray[signed char,ndim=2] v53
        cdef numpy.ndarray[signed char,ndim=2] v54
        cdef unsigned long long v55
        cdef Mut1 v56
        cdef unsigned long long v58
        cdef float v59
        cdef float v60
        cdef UH0 v61
        cdef float v62
        cdef float v63
        cdef UH0 v64
        cdef float v65
        cdef float v66
        cdef US1 v67
        cdef unsigned char v68
        cdef signed long v69
        cdef US1 v70
        cdef unsigned char v71
        cdef signed long v72
        cdef bint v73
        cdef US1 v74
        cdef unsigned char v75
        cdef numpy.ndarray[signed long,ndim=1] v76
        cdef Tuple1 tmp1
        cdef bint v77
        cdef UH0 v78
        cdef UH1 v83
        cdef US3 v80
        cdef UH1 v81
        cdef unsigned long long v84
        cdef unsigned long long v85
        cdef numpy.ndarray[float,ndim=1] v86
        cdef unsigned long long v87
        cdef unsigned long long v88
        cdef signed short v89
        cdef unsigned long long tmp2
        cdef Mut2 v90
        cdef signed short v92
        cdef US2 v93
        cdef signed short v94
        cdef signed short v95
        cdef unsigned long long v96
        cdef object v97
        cdef object v98
        cdef object v99
        cdef object v100
        cdef object v101
        cdef object v102
        cdef object v103
        cdef object v104
        cdef object v105
        cdef numpy.ndarray[float,ndim=2] v106
        cdef numpy.ndarray[signed long long,ndim=1] v107
        cdef object v108
        cdef numpy.ndarray[object,ndim=1] v109
        cdef Mut1 v110
        cdef unsigned long long v112
        cdef signed long long v113
        cdef bint v114
        cdef float v116
        cdef float v117
        cdef signed short v118
        cdef bint v119
        cdef US2 v136
        cdef bint v120
        cdef bint v121
        cdef bint v123
        cdef signed short v124
        cdef bint v125
        cdef bint v126
        cdef bint v128
        cdef signed short v129
        cdef bint v130
        cdef bint v131
        cdef unsigned long long v137
        cdef object v138
        v2 = len(v1)
        v3 = v2 == (<unsigned long long>0)
        if v3:
            v4 = numpy.empty((<unsigned long long>0),dtype=object)
            v5 = Closure2()
            return Tuple0(v4, v5)
        else:
            pass # import torch
            v6 = len(v1)
            v7 = len(v1)
            v8 = Mut0((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
            while method0(v7, v8):
                v10 = v8.v0
                v11, v12 = v8.v1, v8.v2
                tmp0 = v1[v10]
                v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17
                del tmp0
                del v30
                v31 = v29 == (<unsigned char>0)
                if v31:
                    v32 = v15
                else:
                    v32 = v18
                del v15; del v18
                if v27:
                    v37 = UH1_1()
                else:
                    v34 = US3_1(v28)
                    v35 = UH1_1()
                    v37 = UH1_0(v34, v35)
                    del v34; del v35
                v38 = (<unsigned long long>0)
                v39 = method1(v32, v38)
                del v32
                v40 = v11 >= v39
                if v40:
                    v41 = v11
                else:
                    v41 = v39
                v42 = (<unsigned long long>1)
                v43 = method2(v37, v42)
                del v37
                v44 = v12 >= v43
                if v44:
                    v45 = v12
                else:
                    v45 = v43
                v46 = v10 + (<unsigned long long>1)
                v8.v0 = v46
                v8.v1 = v41
                v8.v2 = v45
            v47, v48 = v8.v1, v8.v2
            del v8
            v49 = v47 + v48
            v50 = numpy.zeros((v6,v47,(<signed short>6)),dtype=numpy.float32)
            v51 = numpy.zeros((v6,v47),dtype=numpy.int8)
            v52 = numpy.zeros((v6,v49,(<signed short>12)),dtype=numpy.float32)
            v53 = numpy.zeros((v6,v49),dtype=numpy.int8)
            v54 = numpy.ones((v6,(<signed short>3)),dtype=numpy.int8)
            v55 = len(v1)
            v56 = Mut1((<unsigned long long>0))
            while method3(v55, v56):
                v58 = v56.v0
                tmp1 = v1[v58]
                v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4, tmp1.v5, tmp1.v6, tmp1.v7, tmp1.v8, tmp1.v9, tmp1.v10, tmp1.v11, tmp1.v12, tmp1.v13, tmp1.v14, tmp1.v15, tmp1.v16, tmp1.v17
                del tmp1
                v77 = v75 == (<unsigned char>0)
                if v77:
                    v78 = v61
                else:
                    v78 = v64
                del v61; del v64
                if v73:
                    v83 = UH1_1()
                else:
                    v80 = US3_1(v74)
                    v81 = UH1_1()
                    v83 = UH1_0(v80, v81)
                    del v80; del v81
                v84 = (<unsigned long long>0)
                v85 = method4(v50, v52, v58, v78, v84)
                del v78
                method5(v47, v51, v58, v85)
                v86 = v52[v58,v85,:]
                if v70 == 0: # jack
                    v86[(<signed short>6)] = (<float>1)
                elif v70 == 1: # king
                    v86[(<signed short>7)] = (<float>1)
                elif v70 == 2: # queen
                    v86[(<signed short>8)] = (<float>1)
                del v86
                v87 = v85 + (<unsigned long long>1)
                v88 = method6(v52, v58, v83, v87)
                del v83
                method7(v49, v53, v58, v88)
                tmp2 = len(v76)
                if <signed short>tmp2 != tmp2: raise Exception("The conversion to signed short failed.")
                v89 = <signed short>tmp2
                v90 = Mut2((<signed short>0))
                while method8(v89, v90):
                    v92 = v90.v0
                    v93 = v76[v92]
                    if v93 == 0: # call
                        v94 = (<signed short>0)
                    elif v93 == 1: # fold
                        v94 = (<signed short>1)
                    elif v93 == 2: # raise
                        v94 = (<signed short>2)
                    v54[v58,v94] = 0
                    v95 = v92 + (<signed short>1)
                    v90.v0 = v95
                del v76
                del v90
                v96 = v58 + (<unsigned long long>1)
                v56.v0 = v96
            del v56
            v97 = torch.from_numpy(v50)
            del v50
            v98 = v51.view('bool')
            del v51
            v99 = torch.from_numpy(v98)
            del v98
            v100 = torch.from_numpy(v52)
            del v52
            v101 = v53.view('bool')
            del v53
            v102 = torch.from_numpy(v101)
            del v101
            v103 = v54.view('bool')
            del v54
            v104 = torch.from_numpy(v103)
            del v103
            v105 = v0(v97, v99, v100, v102, v104)
            del v97; del v99; del v100; del v102; del v104
            v106 = v105[0]
            v107 = v105[1]
            v108 = v105[2]
            del v105
            v109 = numpy.empty(v6,dtype=object)
            v110 = Mut1((<unsigned long long>0))
            while method3(v6, v110):
                v112 = v110.v0
                v113 = v107[v112]
                v114 = v106 is None
                if v114:
                    v116 = (<float>1)
                else:
                    v116 = v106[v112,v113]
                v117 = libc.math.log(v116)
                v118 = <signed short>v113
                v119 = v118 < (<signed short>1)
                if v119:
                    v120 = v118 == (<signed short>0)
                    v121 = v120 == 0
                    if v121:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v136 = 0
                else:
                    v123 = v118 < (<signed short>2)
                    if v123:
                        v124 = v118 - (<signed short>1)
                        v125 = v124 == (<signed short>0)
                        v126 = v125 == 0
                        if v126:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v136 = 1
                    else:
                        v128 = v118 < (<signed short>3)
                        if v128:
                            v129 = v118 - (<signed short>2)
                            v130 = v129 == (<signed short>0)
                            v131 = v130 == 0
                            if v131:
                                raise Exception("The unit index should be 0.")
                            else:
                                pass
                            v136 = 2
                        else:
                            raise Exception("Unpickle failure. Unpickling of an union failed.")
                v109[v112] = Tuple2(v117, v117, v136)
                v137 = v112 + (<unsigned long long>1)
                v110.v0 = v137
            del v106; del v107
            del v110
            v138 = Closure3(v1, v6, v108)
            del v108
            return Tuple0(v109, v138)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure1(v0)
cdef class Mut3:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut4:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple3:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut4 v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, Mut4 v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple4:
    cdef readonly Mut4 v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, Mut4 v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut5:
    cdef public signed long long v0
    cdef public float v1
    def __init__(self, signed long long v0, float v1): self.v0 = v0; self.v1 = v1
cdef class Mut6:
    cdef public signed long long v0
    def __init__(self, signed long long v0): self.v0 = v0
cdef class Tuple5:
    cdef readonly unsigned long long v0
    cdef readonly UH1 v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, unsigned long long v0, UH1 v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple6:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, Mut3 v0, Mut3 v1):
        method9(v0, v1)
cdef class Closure5():
    def __init__(self): pass
    def __call__(self):
        cdef unsigned long long v0
        cdef unsigned long long v1
        v0 = (<unsigned long long>3)
        v1 = (<unsigned long long>7)
        return method28(v0, v1)
cdef class Tuple7:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure8():
    cdef bint v0
    cdef bint v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    def __init__(self, bint v0, bint v1, numpy.ndarray[float,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[signed long long,ndim=1] v6, numpy.ndarray[unsigned char,ndim=1] v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
    def __call__(self, numpy.ndarray[float,ndim=1] v8):
        cdef bint v0 = self.v0
        cdef bint v1 = self.v1
        cdef numpy.ndarray[float,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[signed long long,ndim=1] v6 = self.v6
        cdef numpy.ndarray[unsigned char,ndim=1] v7 = self.v7
        cdef unsigned long long v9
        cdef unsigned long long v10
        cdef bint v11
        cdef bint v12
        cdef numpy.ndarray[float,ndim=1] v13
        cdef Mut1 v14
        cdef unsigned long long v16
        cdef float v17
        cdef unsigned char v18
        cdef bint v19
        cdef float v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef unsigned long long v24
        cdef bint v25
        cdef bint v31
        cdef unsigned long long v26
        cdef bint v27
        cdef unsigned long long v28
        cdef bint v32
        cdef numpy.ndarray[object,ndim=1] v33
        cdef Mut1 v34
        cdef unsigned long long v36
        cdef numpy.ndarray[float,ndim=1] v37
        cdef numpy.ndarray[float,ndim=1] v38
        cdef numpy.ndarray[float,ndim=1] v39
        cdef numpy.ndarray[float,ndim=1] v40
        cdef Tuple7 tmp16
        cdef signed long long v41
        cdef numpy.ndarray[float,ndim=1] v42
        cdef float v43
        cdef signed long long v44
        cdef signed long long v45
        cdef bint v46
        cdef bint v47
        cdef numpy.ndarray[float,ndim=1] v48
        cdef Mut6 v49
        cdef signed long long v51
        cdef float v52
        cdef float v53
        cdef bint v54
        cdef bint v55
        cdef float v57
        cdef bint v58
        cdef float v63
        cdef float v59
        cdef float v60
        cdef float v61
        cdef signed long long v64
        cdef unsigned long long v65
        cdef unsigned long long v66
        cdef unsigned long long v67
        cdef bint v68
        cdef bint v69
        cdef numpy.ndarray[float,ndim=1] v70
        cdef Mut1 v71
        cdef unsigned long long v73
        cdef numpy.ndarray[float,ndim=1] v74
        cdef numpy.ndarray[float,ndim=1] v75
        cdef signed long long v76
        cdef signed long long v77
        cdef bint v78
        cdef bint v79
        cdef Mut5 v80
        cdef signed long long v82
        cdef float v83
        cdef float v84
        cdef float v85
        cdef float v86
        cdef float v87
        cdef signed long long v88
        cdef float v89
        cdef unsigned long long v90
        cdef bint v96
        cdef unsigned long long v91
        cdef bint v92
        cdef unsigned long long v93
        cdef bint v97
        cdef Mut1 v98
        cdef unsigned long long v100
        cdef numpy.ndarray[float,ndim=1] v101
        cdef numpy.ndarray[float,ndim=1] v102
        cdef numpy.ndarray[float,ndim=1] v103
        cdef numpy.ndarray[float,ndim=1] v104
        cdef Tuple7 tmp17
        cdef signed long long v105
        cdef float v106
        cdef float v107
        cdef float v108
        cdef float v109
        cdef float v110
        cdef float v111
        cdef float v112
        cdef unsigned long long v113
        cdef bint v114
        cdef bint v120
        cdef unsigned long long v115
        cdef bint v116
        cdef unsigned long long v117
        cdef bint v121
        cdef Mut1 v122
        cdef unsigned long long v124
        cdef numpy.ndarray[float,ndim=1] v125
        cdef numpy.ndarray[float,ndim=1] v126
        cdef numpy.ndarray[float,ndim=1] v127
        cdef numpy.ndarray[float,ndim=1] v128
        cdef Tuple7 tmp18
        cdef numpy.ndarray[float,ndim=1] v129
        cdef float v130
        cdef float v131
        cdef signed long long v132
        cdef Mut6 v133
        cdef signed long long v135
        cdef float v136
        cdef float v137
        cdef float v138
        cdef float v139
        cdef float v140
        cdef signed long long v141
        cdef unsigned long long v142
        cdef unsigned long long v143
        cdef bint v144
        cdef bint v145
        cdef numpy.ndarray[float,ndim=1] v146
        cdef Mut1 v147
        cdef unsigned long long v149
        cdef float v150
        cdef unsigned char v151
        cdef bint v152
        cdef float v154
        cdef float v153
        cdef unsigned long long v155
        v9 = len(v8)
        v10 = len(v7)
        v11 = v9 == v10
        v12 = v11 == 0
        if v12:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v13 = numpy.empty(v9,dtype=numpy.float32)
        v14 = Mut1((<unsigned long long>0))
        while method3(v9, v14):
            v16 = v14.v0
            v17 = v8[v16]
            v18 = v7[v16]
            v19 = v18 == (<unsigned char>0)
            if v19:
                v21 = v17
            else:
                v21 = -v17
            v13[v16] = v21
            v22 = v16 + (<unsigned long long>1)
            v14.v0 = v22
        del v14
        v23 = len(v3)
        v24 = len(v6)
        v25 = v23 == v24
        if v25:
            v26 = len(v5)
            v27 = v23 == v26
            if v27:
                v28 = len(v13)
                v31 = v23 == v28
            else:
                v31 = 0
        else:
            v31 = 0
        v32 = v31 == 0
        if v32:
            raise Exception("The length of the four arrays has to the same.")
        else:
            pass
        v33 = numpy.empty(v23,dtype=object)
        v34 = Mut1((<unsigned long long>0))
        while method3(v23, v34):
            v36 = v34.v0
            tmp16 = v3[v36]
            v37, v38, v39, v40 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3
            del tmp16
            del v39; del v40
            v41 = v6[v36]
            v42 = v5[v36]
            v43 = v13[v36]
            v44 = len(v38)
            v45 = len(v37)
            v46 = v44 == v45
            v47 = v46 == 0
            if v47:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v48 = numpy.empty(v44,dtype=numpy.float32)
            v49 = Mut6((<signed long long>0))
            while method19(v44, v49):
                v51 = v49.v0
                v52 = v38[v51]
                v53 = v37[v51]
                v54 = v53 == (<float>0)
                v55 = v54 != 1
                if v55:
                    v57 = v52 / v53
                else:
                    v57 = (<float>0)
                v58 = v41 == v51
                if v58:
                    v59 = v43 - v57
                    v60 = v42[v41]
                    v61 = v59 / v60
                    v63 = v61 + v57
                else:
                    v63 = v57
                v48[v51] = v63
                v64 = v51 + (<signed long long>1)
                v49.v0 = v64
            del v37; del v38; del v42
            del v49
            v33[v36] = v48
            del v48
            v65 = v36 + (<unsigned long long>1)
            v34.v0 = v65
        del v34
        v66 = len(v33)
        v67 = len(v4)
        v68 = v66 == v67
        v69 = v68 == 0
        if v69:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v70 = numpy.empty(v66,dtype=numpy.float32)
        v71 = Mut1((<unsigned long long>0))
        while method3(v66, v71):
            v73 = v71.v0
            v74 = v33[v73]
            v75 = v4[v73]
            v76 = len(v74)
            v77 = len(v75)
            v78 = v76 == v77
            v79 = v78 == 0
            if v79:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v80 = Mut5((<signed long long>0), (<float>0))
            while method18(v76, v80):
                v82 = v80.v0
                v83 = v80.v1
                v84 = v74[v82]
                v85 = v75[v82]
                v86 = v84 * v85
                v87 = v83 + v86
                v88 = v82 + (<signed long long>1)
                v80.v0 = v88
                v80.v1 = v87
            del v74; del v75
            v89 = v80.v1
            del v80
            v70[v73] = v89
            v90 = v73 + (<unsigned long long>1)
            v71.v0 = v90
        del v71
        if v1:
            if v25:
                v91 = len(v13)
                v92 = v23 == v91
                if v92:
                    v93 = len(v2)
                    v96 = v23 == v93
                else:
                    v96 = 0
            else:
                v96 = 0
            v97 = v96 == 0
            if v97:
                raise Exception("The length of the four arrays has to the same.")
            else:
                pass
            v98 = Mut1((<unsigned long long>0))
            while method3(v23, v98):
                v100 = v98.v0
                tmp17 = v3[v100]
                v101, v102, v103, v104 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3
                del tmp17
                del v103; del v104
                v105 = v6[v100]
                v106 = v13[v100]
                v107 = v2[v100]
                v108 = v106 * v107
                v109 = v102[v105]
                v110 = v109 + v108
                v102[v105] = v110
                del v102
                v111 = v101[v105]
                v112 = v111 + v107
                v101[v105] = v112
                del v101
                v113 = v100 + (<unsigned long long>1)
                v98.v0 = v113
            del v98
        else:
            pass
        del v13
        if v0:
            v114 = v23 == v66
            if v114:
                v115 = len(v70)
                v116 = v23 == v115
                if v116:
                    v117 = len(v2)
                    v120 = v23 == v117
                else:
                    v120 = 0
            else:
                v120 = 0
            v121 = v120 == 0
            if v121:
                raise Exception("The length of the four arrays has to the same.")
            else:
                pass
            v122 = Mut1((<unsigned long long>0))
            while method3(v23, v122):
                v124 = v122.v0
                tmp18 = v3[v124]
                v125, v126, v127, v128 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3
                del tmp18
                del v125; del v126; del v127
                v129 = v33[v124]
                v130 = v70[v124]
                v131 = v2[v124]
                v132 = len(v128)
                v133 = Mut6((<signed long long>0))
                while method19(v132, v133):
                    v135 = v133.v0
                    v136 = v128[v135]
                    v137 = v129[v135]
                    v138 = v137 - v130
                    v139 = v131 * v138
                    v140 = v136 + v139
                    v128[v135] = v140
                    v141 = v135 + (<signed long long>1)
                    v133.v0 = v141
                del v128; del v129
                del v133
                v142 = v124 + (<unsigned long long>1)
                v122.v0 = v142
            del v122
        else:
            pass
        del v33
        v143 = len(v70)
        v144 = v143 == v10
        v145 = v144 == 0
        if v145:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v146 = numpy.empty(v143,dtype=numpy.float32)
        v147 = Mut1((<unsigned long long>0))
        while method3(v143, v147):
            v149 = v147.v0
            v150 = v70[v149]
            v151 = v7[v149]
            v152 = v151 == (<unsigned char>0)
            if v152:
                v154 = v150
            else:
                v153 = -v150
                v154 = v153
            v146[v149] = v154
            v155 = v149 + (<unsigned long long>1)
            v147.v0 = v155
        del v70
        del v147
        return v146
cdef class Closure7():
    cdef float v0
    cdef bint v1
    cdef bint v2
    cdef Mut3 v3
    def __init__(self, float v0, bint v1, bint v2, Mut3 v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, list v4):
        cdef float v0 = self.v0
        cdef bint v1 = self.v1
        cdef bint v2 = self.v2
        cdef Mut3 v3 = self.v3
        cdef unsigned long long v5
        cdef numpy.ndarray[float,ndim=1] v6
        cdef numpy.ndarray[object,ndim=1] v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef numpy.ndarray[object,ndim=1] v9
        cdef numpy.ndarray[signed long long,ndim=1] v10
        cdef numpy.ndarray[unsigned char,ndim=1] v11
        cdef unsigned long long v12
        cdef numpy.ndarray[object,ndim=1] v13
        cdef Mut1 v14
        cdef unsigned long long v16
        cdef float v17
        cdef float v18
        cdef UH0 v19
        cdef float v20
        cdef float v21
        cdef UH0 v22
        cdef float v23
        cdef float v24
        cdef US1 v25
        cdef unsigned char v26
        cdef signed long v27
        cdef US1 v28
        cdef unsigned char v29
        cdef signed long v30
        cdef bint v31
        cdef US1 v32
        cdef unsigned char v33
        cdef numpy.ndarray[signed long,ndim=1] v34
        cdef Tuple1 tmp13
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
        cdef UH0 v46
        cdef UH1 v51
        cdef US3 v48
        cdef UH1 v49
        cdef unsigned long long v52
        cdef Mut4 v53
        cdef numpy.ndarray[float,ndim=1] v54
        cdef numpy.ndarray[float,ndim=1] v55
        cdef Tuple4 tmp14
        cdef US3 v56
        cdef UH1 v57
        cdef numpy.ndarray[float,ndim=1] v58
        cdef numpy.ndarray[float,ndim=1] v59
        cdef Tuple6 tmp15
        cdef signed long long v60
        cdef bint v61
        cdef float v62
        cdef Mut5 v63
        cdef signed long long v65
        cdef float v66
        cdef float v67
        cdef float v68
        cdef signed long long v69
        cdef float v70
        cdef bint v71
        cdef float v75
        cdef float v76
        cdef float v72
        cdef float v73
        cdef float v74
        cdef numpy.ndarray[float,ndim=1] v77
        cdef Mut6 v78
        cdef signed long long v80
        cdef float v81
        cdef float v82
        cdef float v83
        cdef signed long long v84
        cdef signed long long v85
        cdef numpy.ndarray[float,ndim=1] v86
        cdef Mut6 v87
        cdef signed long long v89
        cdef float v90
        cdef float v91
        cdef float v92
        cdef float v93
        cdef float v94
        cdef float v95
        cdef signed long long v96
        cdef signed long long v97
        cdef float v98
        cdef float v99
        cdef float v100
        cdef float v101
        cdef unsigned long long v102
        cdef US2 v103
        cdef unsigned long long v104
        cdef object v105
        v5 = len(v4)
        v6 = numpy.empty(v5,dtype=numpy.float32)
        v7 = numpy.empty(v5,dtype=object)
        v8 = numpy.empty(v5,dtype=object)
        v9 = numpy.empty(v5,dtype=object)
        v10 = numpy.empty(v5,dtype=numpy.int64)
        v11 = numpy.empty(v5,dtype=numpy.uint8)
        v12 = len(v4)
        v13 = numpy.empty(v12,dtype=object)
        v14 = Mut1((<unsigned long long>0))
        while method3(v12, v14):
            v16 = v14.v0
            tmp13 = v4[v16]
            v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3, tmp13.v4, tmp13.v5, tmp13.v6, tmp13.v7, tmp13.v8, tmp13.v9, tmp13.v10, tmp13.v11, tmp13.v12, tmp13.v13, tmp13.v14, tmp13.v15, tmp13.v16, tmp13.v17
            del tmp13
            v35 = v33 == (<unsigned char>0)
            if v35:
                v36, v37, v38, v39 = v20, v21, v23, v24
            else:
                v36, v37, v38, v39 = v23, v24, v20, v21
            v40 = v18 + v39
            v41 = v17 + v38
            v42 = -v37
            v43 = v41 - v40
            v44 = v42 + v43
            v45 = libc.math.exp(v44)
            v6[v16] = v45
            if v35:
                v46 = v19
            else:
                v46 = v22
            del v19; del v22
            if v31:
                v51 = UH1_1()
            else:
                v48 = US3_1(v32)
                v49 = UH1_1()
                v51 = UH1_0(v48, v49)
                del v48; del v49
            v52 = len(v34)
            tmp14 = method10(v3, v52, v46)
            v53, v54, v55 = tmp14.v0, tmp14.v1, tmp14.v2
            del tmp14
            del v46
            v56 = US3_0(v28)
            v57 = UH1_0(v56, v51)
            del v51; del v56
            tmp15 = method21(v53, v52, v57)
            v58, v59 = tmp15.v0, tmp15.v1
            del tmp15
            del v53; del v57
            v7[v16] = Tuple7(v58, v59, v54, v55)
            del v55; del v58; del v59
            v60 = len(v54)
            v61 = v60 == (<signed long long>0)
            if v61:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v62 = v54[(<signed long long>0)]
            v63 = Mut5((<signed long long>1), v62)
            while method18(v60, v63):
                v65 = v63.v0
                v66 = v63.v1
                v67 = v54[v65]
                v68 = v66 + v67
                v69 = v65 + (<signed long long>1)
                v63.v0 = v69
                v63.v1 = v68
            v70 = v63.v1
            del v63
            v71 = v70 == (<float>0)
            if v71:
                v72 = <float>v60
                v73 = (<float>1) / v72
                v75, v76 = v73, (<float>0)
            else:
                v74 = (<float>1) / v70
                v75, v76 = (<float>0), v74
            v77 = numpy.empty(v60,dtype=numpy.float32)
            v78 = Mut6((<signed long long>0))
            while method19(v60, v78):
                v80 = v78.v0
                v81 = v54[v80]
                v82 = v81 * v76
                v83 = v75 + v82
                v77[v80] = v83
                v84 = v80 + (<signed long long>1)
                v78.v0 = v84
            del v54
            del v78
            v8[v16] = v77
            v85 = len(v77)
            v86 = numpy.empty(v85,dtype=numpy.float32)
            v87 = Mut6((<signed long long>0))
            while method19(v85, v87):
                v89 = v87.v0
                v90 = v77[v89]
                v91 = <float>v52
                v92 = v0 / v91
                v93 = (<float>1) - v0
                v94 = v93 * v90
                v95 = v92 + v94
                v86[v89] = v95
                v96 = v89 + (<signed long long>1)
                v87.v0 = v96
            del v87
            v9[v16] = v86
            v97 = numpy.random.choice(v52,p=v86)
            v10[v16] = v97
            v11[v16] = v33
            v98 = v77[v97]
            del v77
            v99 = v86[v97]
            del v86
            v100 = libc.math.log(v99)
            v101 = libc.math.log(v98)
            v102 = <unsigned long long>v97
            v103 = v34[v102]
            del v34
            v13[v16] = Tuple2(v101, v100, v103)
            v104 = v16 + (<unsigned long long>1)
            v14.v0 = v104
        del v14
        v105 = Closure8(v1, v2, v6, v7, v8, v9, v10, v11)
        del v6; del v7; del v8; del v9; del v10; del v11
        return Tuple0(v13, v105)
cdef class Closure6():
    def __init__(self): pass
    def __call__(self, Mut3 v0, bint v1, bint v2, float v3):
        return Closure7(v3, v2, v1, v0)
cdef class Closure9():
    def __init__(self): pass
    def __call__(self, Mut3 v0, float v1):
        method29(v1, v0)
cdef class Closure10():
    def __init__(self): pass
    def __call__(self, Mut3 v0):
        method31(v0)
cdef class Closure11():
    def __init__(self): pass
    def __call__(self, list v0):
        cdef unsigned long long v1
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut1 v3
        cdef unsigned long long v5
        cdef float v6
        cdef float v7
        cdef UH0 v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef US1 v14
        cdef unsigned char v15
        cdef signed long v16
        cdef US1 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef bint v20
        cdef US1 v21
        cdef unsigned char v22
        cdef numpy.ndarray[signed long,ndim=1] v23
        cdef Tuple1 tmp22
        cdef unsigned long long v24
        cdef float v25
        cdef float v26
        cdef float v27
        cdef US2 v28
        cdef unsigned long long v29
        cdef object v30
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut1((<unsigned long long>0))
        while method3(v1, v3):
            v5 = v3.v0
            tmp22 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5, tmp22.v6, tmp22.v7, tmp22.v8, tmp22.v9, tmp22.v10, tmp22.v11, tmp22.v12, tmp22.v13, tmp22.v14, tmp22.v15, tmp22.v16, tmp22.v17
            del tmp22
            del v8; del v11
            v24 = len(v23)
            v25 = <float>v24
            v26 = (<float>1) / v25
            v27 = libc.math.log(v26)
            v28 = numpy.random.choice(v23)
            del v23
            v2[v5] = Tuple2(v27, v27, v28)
            v29 = v5 + (<unsigned long long>1)
            v3.v0 = v29
        del v3
        v30 = Closure2()
        return Tuple0(v2, v30)
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
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
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly bint v14
    cdef readonly US1 v15
    cdef readonly unsigned char v16
    cdef readonly object v17
    cdef readonly object v18
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, unsigned char v16, v17, v18): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
cdef class UH2_1(UH2): # terminal_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US1 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly bint v14
    cdef readonly US1 v15
    cdef readonly float v16
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, bint v14, US1 v15, float v16): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class Closure16():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef signed long v8
    cdef UH0 v9
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US2 v18):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef bint v19
        cdef float v20
        cdef float v21
        cdef US0 v22
        cdef UH0 v23
        cdef US0 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
        cdef US0 v29
        cdef UH0 v30
        cdef US0 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v14
            v21 = v16 + v13
            v22 = US0_1(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US0_1(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US0_1(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US0_1(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure15():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef US1 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US1 v6
    cdef signed long v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, signed long v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US2 v17):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef US1 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US1 v6 = self.v6
        cdef signed long v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef bint v18
        cdef float v19
        cdef float v20
        cdef US0 v21
        cdef US0 v22
        cdef UH0 v23
        cdef UH0 v24
        cdef US0 v25
        cdef US0 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef UH0 v35
        cdef US0 v36
        cdef US0 v37
        cdef UH0 v38
        cdef UH0 v39
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v13
            v20 = v15 + v12
            v21 = US0_1(v17)
            v22 = US0_0(v1)
            v23 = UH0_0(v22, v11)
            del v22
            v24 = UH0_0(v21, v23)
            del v21; del v23
            v25 = US0_1(v17)
            v26 = US0_0(v1)
            v27 = UH0_0(v26, v8)
            del v26
            v28 = UH0_0(v25, v27)
            del v25; del v27
            return method35(v1, v2, v3, v4, v5, v6, v0, v7, v17, v14, v24, v20, v19, v28, v9, v10)
        else:
            v30 = v16 + v10
            v31 = v15 + v9
            v32 = US0_1(v17)
            v33 = US0_0(v1)
            v34 = UH0_0(v33, v11)
            del v33
            v35 = UH0_0(v32, v34)
            del v32; del v34
            v36 = US0_1(v17)
            v37 = US0_0(v1)
            v38 = UH0_0(v37, v8)
            del v37
            v39 = UH0_0(v36, v38)
            del v36; del v38
            return method35(v1, v2, v3, v4, v5, v6, v0, v7, v17, v14, v35, v12, v13, v39, v31, v30)
cdef class Closure17():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef signed long v8
    cdef UH0 v9
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US2 v18):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef signed long v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef float v10 = self.v10
        cdef float v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef float v15 = self.v15
        cdef bint v19
        cdef float v20
        cdef float v21
        cdef US0 v22
        cdef UH0 v23
        cdef US0 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
        cdef US0 v29
        cdef UH0 v30
        cdef US0 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v14
            v21 = v16 + v13
            v22 = US0_1(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US0_1(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US0_1(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US0_1(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure14():
    cdef unsigned char v0
    cdef US1 v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US1 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US1 v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, US1 v1, Heap0 v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US2 v17):
        cdef unsigned char v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US1 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US1 v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef float v12 = self.v12
        cdef float v13 = self.v13
        cdef float v14 = self.v14
        cdef bint v18
        cdef float v19
        cdef float v20
        cdef US0 v21
        cdef UH0 v22
        cdef US0 v23
        cdef UH0 v24
        cdef float v26
        cdef float v27
        cdef US0 v28
        cdef UH0 v29
        cdef US0 v30
        cdef UH0 v31
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v13
            v20 = v15 + v12
            v21 = US0_1(v17)
            v22 = UH0_0(v21, v11)
            del v21
            v23 = US0_1(v17)
            v24 = UH0_0(v23, v8)
            del v23
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v22, v20, v19, v24, v9, v10)
        else:
            v26 = v16 + v10
            v27 = v15 + v9
            v28 = US0_1(v17)
            v29 = UH0_0(v28, v11)
            del v28
            v30 = US0_1(v17)
            v31 = UH0_0(v30, v8)
            del v30
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v29, v12, v13, v31, v27, v26)
cdef class Closure13():
    cdef US1 v0
    cdef US1 v1
    cdef US1 v2
    cdef Heap0 v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef float v10
    def __init__(self, US1 v0, US1 v1, US1 v2, Heap0 v3, UH0 v4, float v5, float v6, UH0 v7, float v8, float v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, US2 v13):
        cdef US1 v0 = self.v0
        cdef US1 v1 = self.v1
        cdef US1 v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef float v5 = self.v5
        cdef float v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef float v14
        cdef float v15
        cdef US0 v16
        cdef US0 v17
        cdef UH0 v18
        cdef UH0 v19
        cdef US0 v20
        cdef US0 v21
        cdef UH0 v22
        cdef UH0 v23
        v14 = v12 + v9
        v15 = v11 + v8
        v16 = US0_1(v13)
        v17 = US0_0(v0)
        v18 = UH0_0(v17, v7)
        del v17
        v19 = UH0_0(v16, v18)
        del v16; del v18
        v20 = US0_1(v13)
        v21 = US0_0(v1)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = UH0_0(v20, v22)
        del v20; del v22
        return method32(v0, v1, v2, v3, v13, v10, v19, v15, v14, v23, v5, v6)
cdef class Tuple8:
    cdef readonly unsigned long long v0
    cdef readonly float v1
    cdef readonly float v2
    cdef readonly UH0 v3
    cdef readonly float v4
    cdef readonly float v5
    cdef readonly UH0 v6
    cdef readonly float v7
    cdef readonly float v8
    cdef readonly US1 v9
    cdef readonly unsigned char v10
    cdef readonly signed long v11
    cdef readonly US1 v12
    cdef readonly unsigned char v13
    cdef readonly signed long v14
    cdef readonly bint v15
    cdef readonly US1 v16
    cdef readonly float v17
    def __init__(self, unsigned long long v0, float v1, float v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, bint v15, US1 v16, float v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class Closure12():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1, v2):
        cdef numpy.ndarray[object,ndim=1] v3
        cdef Mut1 v4
        cdef unsigned long long v6
        cdef US2 v7
        cdef US2 v8
        cdef numpy.ndarray[signed long,ndim=1] v9
        cdef US2 v10
        cdef US2 v11
        cdef US2 v12
        cdef numpy.ndarray[signed long,ndim=1] v13
        cdef US2 v14
        cdef US2 v15
        cdef numpy.ndarray[signed long,ndim=1] v16
        cdef US2 v17
        cdef numpy.ndarray[signed long,ndim=1] v18
        cdef Heap0 v19
        cdef US1 v20
        cdef US1 v21
        cdef US1 v22
        cdef US1 v23
        cdef US1 v24
        cdef US1 v25
        cdef numpy.ndarray[signed long,ndim=1] v26
        cdef UH0 v27
        cdef float v28
        cdef float v29
        cdef UH0 v30
        cdef float v31
        cdef float v32
        cdef US1 v33
        cdef unsigned long long v34
        cdef float v35
        cdef float v36
        cdef float v37
        cdef numpy.ndarray[signed long,ndim=1] v38
        cdef US1 v39
        cdef unsigned long long v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef numpy.ndarray[signed long,ndim=1] v45
        cdef US1 v46
        cdef unsigned long long v47
        cdef float v48
        cdef float v49
        cdef float v50
        cdef float v51
        cdef numpy.ndarray[signed long,ndim=1] v52
        cdef US0 v53
        cdef UH0 v54
        cdef US0 v55
        cdef UH0 v56
        cdef object v57
        cdef UH2 v58
        cdef unsigned long long v59
        v3 = numpy.empty(v0,dtype=object)
        v4 = Mut1((<unsigned long long>0))
        while method3(v0, v4):
            v6 = v4.v0
            v7 = 0
            v8 = 2
            v9 = numpy.empty(2,dtype=numpy.int32)
            v9[0] = v7; v9[1] = v8
            v10 = 1
            v11 = 0
            v12 = 2
            v13 = numpy.empty(3,dtype=numpy.int32)
            v13[0] = v10; v13[1] = v11; v13[2] = v12
            v14 = 1
            v15 = 0
            v16 = numpy.empty(2,dtype=numpy.int32)
            v16[0] = v14; v16[1] = v15
            v17 = 0
            v18 = numpy.empty(1,dtype=numpy.int32)
            v18[0] = v17
            v19 = Heap0(v18, v13, v9, v16)
            del v9; del v13; del v16; del v18
            v20 = 1
            v21 = 2
            v22 = 0
            v23 = 1
            v24 = 2
            v25 = 0
            v26 = numpy.empty(6,dtype=numpy.int32)
            v26[0] = v20; v26[1] = v21; v26[2] = v22; v26[3] = v23; v26[4] = v24; v26[5] = v25
            numpy.random.shuffle(v26)
            v27 = UH0_1()
            v28 = (<float>0)
            v29 = (<float>0)
            v30 = UH0_1()
            v31 = (<float>0)
            v32 = (<float>0)
            v33 = v26[(<unsigned long long>0)]
            v34 = len(v26)
            v35 = <float>v34
            v36 = (<float>1) / v35
            v37 = libc.math.log(v36)
            v38 = v26[1:]
            del v26
            v39 = v38[(<unsigned long long>0)]
            v40 = len(v38)
            v41 = <float>v40
            v42 = (<float>1) / v41
            v43 = libc.math.log(v42)
            v44 = v37 + v43
            v45 = v38[1:]
            del v38
            v46 = v45[(<unsigned long long>0)]
            v47 = len(v45)
            del v45
            v48 = <float>v47
            v49 = (<float>1) / v48
            v50 = libc.math.log(v49)
            v51 = v44 + v50
            v52 = v19.v2
            v53 = US0_0(v33)
            v54 = UH0_0(v53, v27)
            del v53
            v55 = US0_0(v39)
            v56 = UH0_0(v55, v30)
            del v55
            v57 = Closure13(v33, v39, v46, v19, v30, v31, v32, v27, v28, v29, v51)
            del v19; del v27; del v30
            v58 = UH2_0(v51, v51, v54, v28, v29, v56, v31, v32, v33, (<unsigned char>0), (<signed long>1), v39, (<unsigned char>1), (<signed long>1), 0, v46, (<unsigned char>0), v52, v57)
            del v52; del v54; del v56; del v57
            v3[v6] = v58
            del v58
            v59 = v6 + (<unsigned long long>1)
            v4.v0 = v59
        del v4
        return method40(v2, v1, v3)
cdef class Closure18():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1):
        cdef numpy.ndarray[object,ndim=1] v2
        cdef Mut1 v3
        cdef unsigned long long v5
        cdef US2 v6
        cdef US2 v7
        cdef numpy.ndarray[signed long,ndim=1] v8
        cdef US2 v9
        cdef US2 v10
        cdef US2 v11
        cdef numpy.ndarray[signed long,ndim=1] v12
        cdef US2 v13
        cdef US2 v14
        cdef numpy.ndarray[signed long,ndim=1] v15
        cdef US2 v16
        cdef numpy.ndarray[signed long,ndim=1] v17
        cdef Heap0 v18
        cdef US1 v19
        cdef US1 v20
        cdef US1 v21
        cdef US1 v22
        cdef US1 v23
        cdef US1 v24
        cdef numpy.ndarray[signed long,ndim=1] v25
        cdef UH0 v26
        cdef float v27
        cdef float v28
        cdef UH0 v29
        cdef float v30
        cdef float v31
        cdef US1 v32
        cdef unsigned long long v33
        cdef float v34
        cdef float v35
        cdef float v36
        cdef numpy.ndarray[signed long,ndim=1] v37
        cdef US1 v38
        cdef unsigned long long v39
        cdef float v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef numpy.ndarray[signed long,ndim=1] v44
        cdef US1 v45
        cdef unsigned long long v46
        cdef float v47
        cdef float v48
        cdef float v49
        cdef float v50
        cdef numpy.ndarray[signed long,ndim=1] v51
        cdef US0 v52
        cdef UH0 v53
        cdef US0 v54
        cdef UH0 v55
        cdef object v56
        cdef UH2 v57
        cdef unsigned long long v58
        v2 = numpy.empty(v0,dtype=object)
        v3 = Mut1((<unsigned long long>0))
        while method3(v0, v3):
            v5 = v3.v0
            v6 = 0
            v7 = 2
            v8 = numpy.empty(2,dtype=numpy.int32)
            v8[0] = v6; v8[1] = v7
            v9 = 1
            v10 = 0
            v11 = 2
            v12 = numpy.empty(3,dtype=numpy.int32)
            v12[0] = v9; v12[1] = v10; v12[2] = v11
            v13 = 1
            v14 = 0
            v15 = numpy.empty(2,dtype=numpy.int32)
            v15[0] = v13; v15[1] = v14
            v16 = 0
            v17 = numpy.empty(1,dtype=numpy.int32)
            v17[0] = v16
            v18 = Heap0(v17, v12, v8, v15)
            del v8; del v12; del v15; del v17
            v19 = 1
            v20 = 2
            v21 = 0
            v22 = 1
            v23 = 2
            v24 = 0
            v25 = numpy.empty(6,dtype=numpy.int32)
            v25[0] = v19; v25[1] = v20; v25[2] = v21; v25[3] = v22; v25[4] = v23; v25[5] = v24
            numpy.random.shuffle(v25)
            v26 = UH0_1()
            v27 = (<float>0)
            v28 = (<float>0)
            v29 = UH0_1()
            v30 = (<float>0)
            v31 = (<float>0)
            v32 = v25[(<unsigned long long>0)]
            v33 = len(v25)
            v34 = <float>v33
            v35 = (<float>1) / v34
            v36 = libc.math.log(v35)
            v37 = v25[1:]
            del v25
            v38 = v37[(<unsigned long long>0)]
            v39 = len(v37)
            v40 = <float>v39
            v41 = (<float>1) / v40
            v42 = libc.math.log(v41)
            v43 = v36 + v42
            v44 = v37[1:]
            del v37
            v45 = v44[(<unsigned long long>0)]
            v46 = len(v44)
            del v44
            v47 = <float>v46
            v48 = (<float>1) / v47
            v49 = libc.math.log(v48)
            v50 = v43 + v49
            v51 = v18.v2
            v52 = US0_0(v32)
            v53 = UH0_0(v52, v26)
            del v52
            v54 = US0_0(v38)
            v55 = UH0_0(v54, v29)
            del v54
            v56 = Closure13(v32, v38, v45, v18, v29, v30, v31, v26, v27, v28, v50)
            del v18; del v26; del v29
            v57 = UH2_0(v50, v50, v53, v27, v28, v55, v30, v31, v32, (<unsigned char>0), (<signed long>1), v38, (<unsigned char>1), (<signed long>1), 0, v45, (<unsigned char>0), v51, v56)
            del v51; del v53; del v55; del v56
            v2[v5] = v57
            del v57
            v58 = v5 + (<unsigned long long>1)
            v3.v0 = v58
        del v3
        return method41(v1, v2)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method1(UH0 v0, unsigned long long v1) except *:
    cdef UH0 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH0_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method1(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method2(UH1 v0, unsigned long long v1) except *:
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method2(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef bint method3(unsigned long long v0, Mut1 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method4(numpy.ndarray[float,ndim=3] v0, numpy.ndarray[float,ndim=3] v1, unsigned long long v2, UH0 v3, unsigned long long v4) except *:
    cdef US0 v5
    cdef UH0 v6
    cdef unsigned long long v7
    cdef numpy.ndarray[float,ndim=1] v8
    cdef US1 v9
    cdef US2 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef US1 v12
    cdef US2 v13
    if v3.tag == 0: # cons_
        v5 = (<UH0_0>v3).v0; v6 = (<UH0_0>v3).v1
        v7 = method4(v0, v1, v2, v6, v4)
        del v6
        v8 = v0[v2,v7,:]
        if v5.tag == 0: # c1of2_
            v9 = (<US0_0>v5).v0
            if v9 == 0: # jack
                v8[(<signed short>0)] = (<float>1)
            elif v9 == 1: # king
                v8[(<signed short>1)] = (<float>1)
            elif v9 == 2: # queen
                v8[(<signed short>2)] = (<float>1)
        elif v5.tag == 1: # c2of2_
            v10 = (<US0_1>v5).v0
            if v10 == 0: # call
                v8[(<signed short>3)] = (<float>1)
            elif v10 == 1: # fold
                v8[(<signed short>4)] = (<float>1)
            elif v10 == 2: # raise
                v8[(<signed short>5)] = (<float>1)
        del v8
        v11 = v1[v2,v7,:]
        if v5.tag == 0: # c1of2_
            v12 = (<US0_0>v5).v0
            if v12 == 0: # jack
                v11[(<signed short>0)] = (<float>1)
            elif v12 == 1: # king
                v11[(<signed short>1)] = (<float>1)
            elif v12 == 2: # queen
                v11[(<signed short>2)] = (<float>1)
        elif v5.tag == 1: # c2of2_
            v13 = (<US0_1>v5).v0
            if v13 == 0: # call
                v11[(<signed short>3)] = (<float>1)
            elif v13 == 1: # fold
                v11[(<signed short>4)] = (<float>1)
            elif v13 == 2: # raise
                v11[(<signed short>5)] = (<float>1)
        del v5; del v11
        return v7 + (<unsigned long long>1)
    elif v3.tag == 1: # nil
        return v4
cdef void method5(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method5(v0, v1, v2, v5)
    else:
        pass
cdef unsigned long long method6(numpy.ndarray[float,ndim=3] v0, unsigned long long v1, UH1 v2, unsigned long long v3) except *:
    cdef US3 v4
    cdef UH1 v5
    cdef numpy.ndarray[float,ndim=1] v6
    cdef US1 v7
    cdef US1 v8
    cdef unsigned long long v9
    if v2.tag == 0: # cons_
        v4 = (<UH1_0>v2).v0; v5 = (<UH1_0>v2).v1
        v6 = v0[v1,v3,:]
        if v4.tag == 0: # c1of2_
            v7 = (<US3_0>v4).v0
            if v7 == 0: # jack
                v6[(<signed short>6)] = (<float>1)
            elif v7 == 1: # king
                v6[(<signed short>7)] = (<float>1)
            elif v7 == 2: # queen
                v6[(<signed short>8)] = (<float>1)
        elif v4.tag == 1: # c2of2_
            v8 = (<US3_1>v4).v0
            if v8 == 0: # jack
                v6[(<signed short>9)] = (<float>1)
            elif v8 == 1: # king
                v6[(<signed short>10)] = (<float>1)
            elif v8 == 2: # queen
                v6[(<signed short>11)] = (<float>1)
        del v4; del v6
        v9 = v3 + (<unsigned long long>1)
        return method6(v0, v1, v5, v9)
    elif v2.tag == 1: # nil
        return v3
cdef void method7(unsigned long long v0, numpy.ndarray[signed char,ndim=2] v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v1[v2,v3] = 1
        method7(v0, v1, v2, v5)
    else:
        pass
cdef bint method8(signed short v0, Mut2 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method11(UH0 v0) except *:
    cdef US0 v1
    cdef UH0 v2
    cdef unsigned long long v35
    cdef US1 v3
    cdef unsigned long long v13
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef US2 v19
    cdef unsigned long long v29
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef unsigned long long v44
    cdef unsigned long long v45
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # c1of2_
            v3 = (<US0_0>v1).v0
            if v3 == 0: # jack
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # king
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # queen
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # c2of2_
            v19 = (<US0_1>v1).v0
            if v19 == 0: # call
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # fold
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # raise
                v26 = (<signed long>2)
                v27 = (<unsigned long long>1) + v26
                v29 = (<unsigned long long>9223372036854765835) * v27
            v30 = (<unsigned long long>9223372036854775807) + v29
            v31 = v30 * (<unsigned long long>9973)
            v32 = (<signed long>1)
            v33 = (<unsigned long long>1) + v32
            v35 = v31 * v33
        del v1
        v36 = v35 * (<unsigned long long>9973)
        v37 = method11(v2)
        del v2
        v38 = v36 + v37
        v39 = (<unsigned long long>9223372036854775807) + v38
        v40 = v39 * (<unsigned long long>9973)
        v41 = (<signed long>0)
        v42 = (<unsigned long long>1) + v41
        return v40 * v42
    elif v0.tag == 1: # nil
        v44 = (<signed long>1)
        v45 = (<unsigned long long>1) + v44
        return (<unsigned long long>9223372036854765835) * v45
cdef bint method13(UH0 v0, UH0 v1) except *:
    cdef US0 v2
    cdef UH0 v3
    cdef US0 v4
    cdef UH0 v5
    cdef bint v12
    cdef US1 v6
    cdef US1 v7
    cdef US2 v9
    cdef US2 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # c1of2_
            v6 = (<US0_0>v2).v0; v7 = (<US0_0>v4).v0
            if v6 == 0 and v7 == 0: # jack
                v12 = 1
            elif v6 == 1 and v7 == 1: # king
                v12 = 1
            elif v6 == 2 and v7 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # c2of2_
            v9 = (<US0_1>v2).v0; v10 = (<US0_1>v4).v0
            if v9 == 0 and v10 == 0: # call
                v12 = 1
            elif v9 == 1 and v10 == 1: # fold
                v12 = 1
            elif v9 == 2 and v10 == 2: # raise
                v12 = 1
            else:
                v12 = 0
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method13(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef Mut4 method14(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut1 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut4 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut1((<unsigned long long>0))
    while method3(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut4(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method17(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut4 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple3 tmp7
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp7 = v3[v4]
        v7, v8, v9, v10, v11 = tmp7.v0, tmp7.v1, tmp7.v2, tmp7.v3, tmp7.v4
        del tmp7
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple3(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method17(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method16(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        method17(v8, v2, v3, v7, v9)
        del v7
        method16(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method15(Mut3 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut1 v8
    cdef unsigned long long v10
    cdef list v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = Mut1((<unsigned long long>0))
    while method3(v5, v8):
        v10 = v8.v0
        v11 = [None]*(<unsigned long long>0)
        v7[v10] = v11
        del v11
        v12 = v10 + (<unsigned long long>1)
        v8.v0 = v12
    del v8
    v13 = (<unsigned long long>0)
    method16(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple4 method12(Mut3 v0, UH0 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut4 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef numpy.ndarray[float,ndim=1] v12
    cdef Tuple3 tmp6
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v16
    cdef numpy.ndarray[float,ndim=1] v23
    cdef numpy.ndarray[float,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef Mut4 v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef numpy.ndarray[object,ndim=1] v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef bint v35
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp6 = v4[v5]
        v8, v9, v10, v11, v12 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4
        del tmp6
        v13 = v3 == v8
        if v13:
            v15 = method13(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple4(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method12(v0, v1, v2, v3, v4, v16)
    else:
        v23 = numpy.zeros(v2,dtype=numpy.float32)
        v24 = numpy.zeros(v2,dtype=numpy.float32)
        v25 = (<unsigned long long>3)
        v26 = (<unsigned long long>7)
        v27 = method14(v25, v26)
        v4.append(Tuple3(v3, v1, v27, v23, v24))
        v28 = v0.v2
        v29 = v28 + (<unsigned long long>1)
        v0.v2 = v29
        v30 = v0.v2
        v31 = v0.v0
        v32 = v0.v1
        v33 = len(v32)
        del v32
        v34 = v31 * v33
        v35 = v30 >= v34
        if v35:
            method15(v0)
        else:
            pass
        return Tuple4(v27, v23, v24)
cdef Tuple4 method10(Mut3 v0, unsigned long long v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method11(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method12(v0, v2, v1, v4, v8, v9)
cdef bint method18(signed long long v0, Mut5 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method19(signed long long v0, Mut6 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef unsigned long long method22(UH1 v0) except *:
    cdef US3 v1
    cdef UH1 v2
    cdef unsigned long long v35
    cdef US1 v3
    cdef unsigned long long v13
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef US1 v19
    cdef unsigned long long v29
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef unsigned long long v44
    cdef unsigned long long v45
    if v0.tag == 0: # cons_
        v1 = (<UH1_0>v0).v0; v2 = (<UH1_0>v0).v1
        if v1.tag == 0: # c1of2_
            v3 = (<US3_0>v1).v0
            if v3 == 0: # jack
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # king
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # queen
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # c2of2_
            v19 = (<US3_1>v1).v0
            if v19 == 0: # jack
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # king
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # queen
                v26 = (<signed long>2)
                v27 = (<unsigned long long>1) + v26
                v29 = (<unsigned long long>9223372036854765835) * v27
            v30 = (<unsigned long long>9223372036854775807) + v29
            v31 = v30 * (<unsigned long long>9973)
            v32 = (<signed long>1)
            v33 = (<unsigned long long>1) + v32
            v35 = v31 * v33
        del v1
        v36 = v35 * (<unsigned long long>9973)
        v37 = method22(v2)
        del v2
        v38 = v36 + v37
        v39 = (<unsigned long long>9223372036854775807) + v38
        v40 = v39 * (<unsigned long long>9973)
        v41 = (<signed long>0)
        v42 = (<unsigned long long>1) + v41
        return v40 * v42
    elif v0.tag == 1: # nil
        v44 = (<signed long>1)
        v45 = (<unsigned long long>1) + v44
        return (<unsigned long long>9223372036854765835) * v45
cdef bint method24(UH1 v0, UH1 v1) except *:
    cdef US3 v2
    cdef UH1 v3
    cdef US3 v4
    cdef UH1 v5
    cdef bint v12
    cdef US1 v6
    cdef US1 v7
    cdef US1 v9
    cdef US1 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH1_0>v1).v0; v3 = (<UH1_0>v1).v1; v4 = (<UH1_0>v0).v0; v5 = (<UH1_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # c1of2_
            v6 = (<US3_0>v2).v0; v7 = (<US3_0>v4).v0
            if v6 == 0 and v7 == 0: # jack
                v12 = 1
            elif v6 == 1 and v7 == 1: # king
                v12 = 1
            elif v6 == 2 and v7 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # c2of2_
            v9 = (<US3_1>v2).v0; v10 = (<US3_1>v4).v0
            if v9 == 0 and v10 == 0: # jack
                v12 = 1
            elif v9 == 1 and v10 == 1: # king
                v12 = 1
            elif v9 == 2 and v10 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method24(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method27(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH1 v8
    cdef numpy.ndarray[float,ndim=1] v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef Tuple5 tmp11
    cdef unsigned long long v11
    cdef list v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp11 = v3[v4]
        v7, v8, v9, v10 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3
        del tmp11
        v11 = v7 % v1
        v12 = v2[v11]
        v12.append(Tuple5(v7, v8, v9, v10))
        del v8; del v9; del v10; del v12
        method27(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method26(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        method27(v8, v2, v3, v7, v9)
        del v7
        method26(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method25(Mut4 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut1 v8
    cdef unsigned long long v10
    cdef list v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = Mut1((<unsigned long long>0))
    while method3(v5, v8):
        v10 = v8.v0
        v11 = [None]*(<unsigned long long>0)
        v7[v10] = v11
        del v11
        v12 = v10 + (<unsigned long long>1)
        v8.v0 = v12
    del v8
    v13 = (<unsigned long long>0)
    method26(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple6 method23(Mut4 v0, UH1 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH1 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple5 tmp10
    cdef bint v12
    cdef bint v14
    cdef unsigned long long v15
    cdef numpy.ndarray[float,ndim=1] v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp10 = v4[v5]
        v8, v9, v10, v11 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3
        del tmp10
        v12 = v3 == v8
        if v12:
            v14 = method24(v9, v1)
        else:
            v14 = 0
        del v9
        if v14:
            return Tuple6(v10, v11)
        else:
            del v10; del v11
            v15 = v5 + (<unsigned long long>1)
            return method23(v0, v1, v2, v3, v4, v15)
    else:
        v20 = numpy.zeros(v2,dtype=numpy.float32)
        v21 = numpy.zeros(v2,dtype=numpy.float32)
        v4.append(Tuple5(v3, v1, v21, v20))
        v22 = v0.v2
        v23 = v22 + (<unsigned long long>1)
        v0.v2 = v23
        v24 = v0.v2
        v25 = v0.v0
        v26 = v0.v1
        v27 = len(v26)
        del v26
        v28 = v25 * v27
        v29 = v24 >= v28
        if v29:
            method25(v0)
        else:
            pass
        return Tuple6(v21, v20)
cdef Tuple6 method21(Mut4 v0, unsigned long long v1, UH1 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method22(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method23(v0, v2, v1, v4, v8, v9)
cdef void method20(Mut4 v0, Mut4 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut1 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH1 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple5 tmp9
    cdef signed long long v17
    cdef unsigned long long v18
    cdef numpy.ndarray[float,ndim=1] v19
    cdef numpy.ndarray[float,ndim=1] v20
    cdef Tuple6 tmp12
    cdef signed long long v21
    cdef Mut6 v22
    cdef signed long long v24
    cdef float v25
    cdef float v26
    cdef float v27
    cdef signed long long v28
    cdef signed long long v29
    cdef Mut6 v30
    cdef signed long long v32
    cdef float v33
    cdef float v34
    cdef float v35
    cdef signed long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut1((<unsigned long long>0))
    while method3(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut1((<unsigned long long>0))
        while method3(v9, v10):
            v12 = v10.v0
            tmp9 = v8[v12]
            v13, v14, v15, v16 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3
            del tmp9
            v17 = len(v16)
            v18 = <unsigned long long>v17
            tmp12 = method21(v0, v18, v14)
            v19, v20 = tmp12.v0, tmp12.v1
            del tmp12
            del v14
            v21 = len(v20)
            v22 = Mut6((<signed long long>0))
            while method19(v21, v22):
                v24 = v22.v0
                v25 = v20[v24]
                v26 = v16[v24]
                v27 = v25 + v26
                v20[v24] = v27
                v28 = v24 + (<signed long long>1)
                v22.v0 = v28
            del v16; del v20
            del v22
            v29 = len(v19)
            v30 = Mut6((<signed long long>0))
            while method19(v29, v30):
                v32 = v30.v0
                v33 = v19[v32]
                v34 = v15[v32]
                v35 = v33 + v34
                v19[v32] = v35
                v36 = v32 + (<signed long long>1)
                v30.v0 = v36
            del v15; del v19
            del v30
            v37 = v12 + (<unsigned long long>1)
            v10.v0 = v37
        del v8
        del v10
        v38 = v7 + (<unsigned long long>1)
        v5.v0 = v38
    del v3
cdef void method9(Mut3 v0, Mut3 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut1 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH0 v14
    cdef Mut4 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple3 tmp5
    cdef signed long long v18
    cdef unsigned long long v19
    cdef Mut4 v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef numpy.ndarray[float,ndim=1] v22
    cdef Tuple4 tmp8
    cdef bint v23
    cdef float v24
    cdef Mut5 v25
    cdef signed long long v27
    cdef float v28
    cdef float v29
    cdef float v30
    cdef signed long long v31
    cdef float v32
    cdef bint v33
    cdef float v37
    cdef float v38
    cdef float v34
    cdef float v35
    cdef float v36
    cdef numpy.ndarray[float,ndim=1] v39
    cdef Mut6 v40
    cdef signed long long v42
    cdef float v43
    cdef float v44
    cdef float v45
    cdef signed long long v46
    cdef signed long long v47
    cdef Mut6 v48
    cdef signed long long v50
    cdef float v51
    cdef float v52
    cdef float v53
    cdef signed long long v54
    cdef signed long long v55
    cdef Mut6 v56
    cdef signed long long v58
    cdef float v59
    cdef float v60
    cdef float v61
    cdef signed long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut1((<unsigned long long>0))
    while method3(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut1((<unsigned long long>0))
        while method3(v9, v10):
            v12 = v10.v0
            tmp5 = v8[v12]
            v13, v14, v15, v16, v17 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4
            del tmp5
            v18 = len(v16)
            v19 = <unsigned long long>v18
            tmp8 = method10(v0, v19, v14)
            v20, v21, v22 = tmp8.v0, tmp8.v1, tmp8.v2
            del tmp8
            del v14
            v23 = v18 == (<signed long long>0)
            if v23:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v24 = v16[(<signed long long>0)]
            v25 = Mut5((<signed long long>1), v24)
            while method18(v18, v25):
                v27 = v25.v0
                v28 = v25.v1
                v29 = v16[v27]
                v30 = v28 + v29
                v31 = v27 + (<signed long long>1)
                v25.v0 = v31
                v25.v1 = v30
            v32 = v25.v1
            del v25
            v33 = v32 == (<float>0)
            if v33:
                v34 = <float>v18
                v35 = (<float>1) / v34
                v37, v38 = v35, (<float>0)
            else:
                v36 = (<float>1) / v32
                v37, v38 = (<float>0), v36
            v39 = numpy.empty(v18,dtype=numpy.float32)
            v40 = Mut6((<signed long long>0))
            while method19(v18, v40):
                v42 = v40.v0
                v43 = v16[v42]
                v44 = v43 * v38
                v45 = v37 + v44
                v39[v42] = v45
                v46 = v42 + (<signed long long>1)
                v40.v0 = v46
            del v16
            del v40
            v47 = len(v21)
            v48 = Mut6((<signed long long>0))
            while method19(v47, v48):
                v50 = v48.v0
                v51 = v21[v50]
                v52 = v39[v50]
                v53 = v51 + v52
                v21[v50] = v53
                v54 = v50 + (<signed long long>1)
                v48.v0 = v54
            del v21; del v39
            del v48
            v55 = len(v22)
            v56 = Mut6((<signed long long>0))
            while method19(v55, v56):
                v58 = v56.v0
                v59 = v22[v58]
                v60 = v17[v58]
                v61 = v59 + v60
                v22[v58] = v61
                v62 = v58 + (<signed long long>1)
                v56.v0 = v62
            del v17; del v22
            del v56
            method20(v20, v15)
            del v15; del v20
            v63 = v12 + (<unsigned long long>1)
            v10.v0 = v63
        del v8
        del v10
        v64 = v7 + (<unsigned long long>1)
        v5.v0 = v64
    del v3
cdef Mut3 method28(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut1 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut3 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut1((<unsigned long long>0))
    while method3(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut3(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method30(float v0, Mut4 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut1 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH1 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple5 tmp20
    cdef signed long long v17
    cdef Mut6 v18
    cdef signed long long v20
    cdef float v21
    cdef float v22
    cdef signed long long v23
    cdef signed long long v24
    cdef Mut6 v25
    cdef signed long long v27
    cdef float v28
    cdef float v29
    cdef signed long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut1((<unsigned long long>0))
    while method3(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut1((<unsigned long long>0))
        while method3(v9, v10):
            v12 = v10.v0
            tmp20 = v8[v12]
            v13, v14, v15, v16 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3
            del tmp20
            del v14
            v17 = len(v15)
            v18 = Mut6((<signed long long>0))
            while method19(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v21 * v0
                v15[v20] = v22
                v23 = v20 + (<signed long long>1)
                v18.v0 = v23
            del v15
            del v18
            v24 = len(v16)
            v25 = Mut6((<signed long long>0))
            while method19(v24, v25):
                v27 = v25.v0
                v28 = v16[v27]
                v29 = v28 * v0
                v16[v27] = v29
                v30 = v27 + (<signed long long>1)
                v25.v0 = v30
            del v16
            del v25
            v31 = v12 + (<unsigned long long>1)
            v10.v0 = v31
        del v8
        del v10
        v32 = v7 + (<unsigned long long>1)
        v5.v0 = v32
    del v3
cdef void method29(float v0, Mut3 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut1 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH0 v14
    cdef Mut4 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple3 tmp19
    cdef unsigned long long v18
    cdef unsigned long long v19
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut1((<unsigned long long>0))
    while method3(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut1((<unsigned long long>0))
        while method3(v9, v10):
            v12 = v10.v0
            tmp19 = v8[v12]
            v13, v14, v15, v16, v17 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3, tmp19.v4
            del tmp19
            del v14; del v16; del v17
            method30(v0, v15)
            del v15
            v18 = v12 + (<unsigned long long>1)
            v10.v0 = v18
        del v8
        del v10
        v19 = v7 + (<unsigned long long>1)
        v5.v0 = v19
    del v3
cdef void method31(Mut3 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef Mut1 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut1 v9
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef UH0 v13
    cdef Mut4 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple3 tmp21
    cdef signed long long v17
    cdef Mut6 v18
    cdef signed long long v20
    cdef float v21
    cdef float v22
    cdef float v23
    cdef bint v24
    cdef float v25
    cdef signed long long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    v2 = v0.v1
    v3 = len(v2)
    v4 = Mut1((<unsigned long long>0))
    while method3(v3, v4):
        v6 = v4.v0
        v7 = v2[v6]
        v8 = len(v7)
        v9 = Mut1((<unsigned long long>0))
        while method3(v8, v9):
            v11 = v9.v0
            tmp21 = v7[v11]
            v12, v13, v14, v15, v16 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4
            del tmp21
            del v13; del v14
            v17 = len(v15)
            v18 = Mut6((<signed long long>0))
            while method19(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v16[v20]
                v23 = v21 + v22
                v24 = (<float>0) >= v23
                if v24:
                    v25 = (<float>0)
                else:
                    v25 = v23
                v16[v20] = (<float>0)
                v15[v20] = v25
                v26 = v20 + (<signed long long>1)
                v18.v0 = v26
            del v15; del v16
            del v18
            v27 = v11 + (<unsigned long long>1)
            v9.v0 = v27
        del v7
        del v9
        v28 = v6 + (<unsigned long long>1)
        v4.v0 = v28
    del v2
cdef numpy.ndarray[signed long,ndim=1] method33(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = (<signed long>0) < v6
    if v7:
        return v0.v2
    else:
        v9 = (<signed long>0) == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[signed long,ndim=1] method36(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = (<signed long>0) < v7
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
            v13 = (<signed long>0) == v7
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
cdef signed long method38(US1 v0) except *:
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef UH2 method37(US1 v0, Heap0 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US2 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef signed long v17
    cdef signed long v18
    cdef signed long v19
    cdef bint v20
    cdef bint v22
    cdef signed long v46
    cdef bint v23
    cdef bint v24
    cdef bint v27
    cdef bint v28
    cdef signed long v29
    cdef signed long v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef bint v34
    cdef signed long v37
    cdef bint v35
    cdef bint v38
    cdef bint v39
    cdef bint v40
    cdef bint v47
    cdef unsigned char v51
    cdef signed long v52
    cdef bint v48
    cdef bint v53
    cdef signed long v55
    cdef bint v56
    cdef signed long v58
    cdef signed long v59
    cdef bint v60
    cdef signed long v62
    cdef signed long v63
    cdef US1 v64
    cdef unsigned char v65
    cdef signed long v66
    cdef US1 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef float v70
    cdef bint v72
    cdef signed long v74
    cdef bint v75
    cdef signed long v77
    cdef signed long v78
    cdef signed long v80
    cdef signed long v81
    cdef US1 v82
    cdef unsigned char v83
    cdef signed long v84
    cdef US1 v85
    cdef unsigned char v86
    cdef signed long v87
    cdef float v88
    cdef signed long v90
    cdef signed long v91
    cdef numpy.ndarray[signed long,ndim=1] v92
    cdef object v93
    if v9 == 0: # call
        v17 = method38(v0)
        v18 = method38(v6)
        v19 = method38(v3)
        v20 = v18 == v17
        if v20:
            v22 = v19 == v17
        else:
            v22 = 0
        if v22:
            v23 = v18 < v19
            if v23:
                v46 = (<signed long>-1)
            else:
                v24 = v18 > v19
                if v24:
                    v46 = (<signed long>1)
                else:
                    v46 = (<signed long>0)
        else:
            if v20:
                v46 = (<signed long>1)
            else:
                v27 = v19 == v17
                if v27:
                    v46 = (<signed long>-1)
                else:
                    v28 = v18 > v17
                    if v28:
                        v29, v30 = v18, v17
                    else:
                        v29, v30 = v17, v18
                    v31 = v19 > v17
                    if v31:
                        v32, v33 = v19, v17
                    else:
                        v32, v33 = v17, v19
                    v34 = v29 < v32
                    if v34:
                        v37 = (<signed long>-1)
                    else:
                        v35 = v29 > v32
                        if v35:
                            v37 = (<signed long>1)
                        else:
                            v37 = (<signed long>0)
                    v38 = v37 == (<signed long>0)
                    if v38:
                        v39 = v30 < v33
                        if v39:
                            v46 = (<signed long>-1)
                        else:
                            v40 = v30 > v33
                            if v40:
                                v46 = (<signed long>1)
                            else:
                                v46 = (<signed long>0)
                    else:
                        v46 = v37
        v47 = v46 == (<signed long>1)
        if v47:
            v51, v52 = v7, v5
        else:
            v48 = v46 == (<signed long>-1)
            if v48:
                v51, v52 = v4, v5
            else:
                v51, v52 = v7, (<signed long>0)
        v53 = v51 == (<unsigned char>0)
        if v53:
            v55 = v52
        else:
            v55 = -v52
        v56 = v7 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v58 + v5
        v60 = v4 == (<unsigned char>0)
        if v60:
            v62 = v55
        else:
            v62 = -v55
        v63 = v62 + v5
        if v56:
            v64, v65, v66, v67, v68, v69 = v6, v7, v59, v3, v4, v63
        else:
            v64, v65, v66, v67, v68, v69 = v3, v4, v63, v6, v7, v59
        v70 = <float>v55
        return UH2_1(v10, v10, v11, v12, v13, v14, v15, v16, v64, v65, v66, v67, v68, v69, 1, v0, v70)
    elif v9 == 1: # fold
        v72 = v4 == (<unsigned char>0)
        if v72:
            v74 = v8
        else:
            v74 = -v8
        v75 = v7 == (<unsigned char>0)
        if v75:
            v77 = v74
        else:
            v77 = -v74
        v78 = v77 + v8
        if v72:
            v80 = v74
        else:
            v80 = -v74
        v81 = v80 + v5
        if v75:
            v82, v83, v84, v85, v86, v87 = v6, v7, v78, v3, v4, v81
        else:
            v82, v83, v84, v85, v86, v87 = v3, v4, v81, v6, v7, v78
        v88 = <float>v74
        return UH2_1(v10, v10, v11, v12, v13, v14, v15, v16, v82, v83, v84, v85, v86, v87, 1, v0, v88)
    elif v9 == 2: # raise
        v90 = v2 - (<signed long>1)
        v91 = v5 + (<signed long>4)
        v92 = method36(v1, v6, v7, v91, v3, v4, v5, v90)
        v93 = Closure16(v4, v0, v1, v90, v6, v7, v91, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH2_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v91, 1, v0, v4, v92, v93)
cdef UH2 method35(US1 v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US2 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef signed long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef object v18
    cdef object v20
    cdef signed long v22
    cdef signed long v23
    cdef numpy.ndarray[signed long,ndim=1] v24
    cdef object v25
    if v8 == 0: # call
        v16 = (<signed long>2)
        v17 = method36(v1, v5, v6, v7, v2, v3, v4, v16)
        v18 = Closure16(v3, v0, v1, v16, v5, v6, v7, v2, v4, v13, v14, v15, v10, v11, v12, v9)
        return UH2_0(v9, v9, v10, v11, v12, v13, v14, v15, v2, v3, v4, v5, v6, v7, 1, v0, v3, v17, v18)
    elif v8 == 1: # fold
        raise Exception("impossible 2")
    elif v8 == 2: # raise
        v22 = (<signed long>1)
        v23 = v4 + (<signed long>4)
        v24 = method36(v1, v5, v6, v23, v2, v3, v4, v22)
        v25 = Closure16(v3, v0, v1, v22, v5, v6, v23, v2, v4, v13, v14, v15, v10, v11, v12, v9)
        return UH2_0(v9, v9, v10, v11, v12, v13, v14, v15, v2, v3, v4, v5, v6, v23, 1, v0, v3, v24, v25)
cdef UH2 method39(US1 v0, Heap0 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US2 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef numpy.ndarray[signed long,ndim=1] v24
    cdef US0 v25
    cdef UH0 v26
    cdef US0 v27
    cdef UH0 v28
    cdef object v29
    cdef bint v31
    cdef signed long v33
    cdef bint v34
    cdef signed long v36
    cdef signed long v37
    cdef signed long v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef US1 v44
    cdef unsigned char v45
    cdef signed long v46
    cdef float v47
    cdef signed long v49
    cdef signed long v50
    cdef numpy.ndarray[signed long,ndim=1] v51
    cdef object v52
    if v9 == 0: # call
        v17 = v7 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v6, v7, v5, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23 = v3, v4, v5, v6, v7, v5
        v24 = v1.v2
        v25 = US0_0(v0)
        v26 = UH0_0(v25, v11)
        del v25
        v27 = US0_0(v0)
        v28 = UH0_0(v27, v14)
        del v27
        v29 = Closure15(v19, v0, v1, v21, v22, v23, v18, v20, v14, v15, v16, v11, v12, v13, v10)
        return UH2_0(v10, v10, v26, v12, v13, v28, v15, v16, v18, v19, v20, v21, v22, v23, 1, v0, v19, v24, v29)
    elif v9 == 1: # fold
        v31 = v4 == (<unsigned char>0)
        if v31:
            v33 = v8
        else:
            v33 = -v8
        v34 = v7 == (<unsigned char>0)
        if v34:
            v36 = v33
        else:
            v36 = -v33
        v37 = v36 + v8
        if v31:
            v39 = v33
        else:
            v39 = -v33
        v40 = v39 + v5
        if v34:
            v41, v42, v43, v44, v45, v46 = v6, v7, v37, v3, v4, v40
        else:
            v41, v42, v43, v44, v45, v46 = v3, v4, v40, v6, v7, v37
        v47 = <float>v33
        return UH2_1(v10, v10, v11, v12, v13, v14, v15, v16, v41, v42, v43, v44, v45, v46, 0, v0, v47)
    elif v9 == 2: # raise
        v49 = v2 - (<signed long>1)
        v50 = v5 + (<signed long>2)
        v51 = method36(v1, v6, v7, v50, v3, v4, v5, v49)
        v52 = Closure17(v4, v0, v1, v49, v6, v7, v50, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH2_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v50, 0, v0, v4, v51, v52)
cdef UH2 method34(US1 v0, Heap0 v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US2 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef bint v16
    cdef US1 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef numpy.ndarray[signed long,ndim=1] v23
    cdef US0 v24
    cdef UH0 v25
    cdef US0 v26
    cdef UH0 v27
    cdef object v28
    cdef bint v30
    cdef signed long v32
    cdef bint v33
    cdef signed long v35
    cdef signed long v36
    cdef signed long v38
    cdef signed long v39
    cdef US1 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef US1 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef float v46
    cdef signed long v48
    cdef signed long v49
    cdef numpy.ndarray[signed long,ndim=1] v50
    cdef object v51
    if v8 == 0: # call
        v16 = v7 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v6, v7, v5, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22 = v3, v4, v5, v6, v7, v5
        v23 = v1.v2
        v24 = US0_0(v0)
        v25 = UH0_0(v24, v10)
        del v24
        v26 = US0_0(v0)
        v27 = UH0_0(v26, v13)
        del v26
        v28 = Closure15(v18, v0, v1, v20, v21, v22, v17, v19, v13, v14, v15, v10, v11, v12, v9)
        return UH2_0(v9, v9, v25, v11, v12, v27, v14, v15, v17, v18, v19, v20, v21, v22, 1, v0, v18, v23, v28)
    elif v8 == 1: # fold
        v30 = v4 == (<unsigned char>0)
        if v30:
            v32 = v5
        else:
            v32 = -v5
        v33 = v7 == (<unsigned char>0)
        if v33:
            v35 = v32
        else:
            v35 = -v32
        v36 = v35 + v5
        if v30:
            v38 = v32
        else:
            v38 = -v32
        v39 = v38 + v5
        if v33:
            v40, v41, v42, v43, v44, v45 = v6, v7, v36, v3, v4, v39
        else:
            v40, v41, v42, v43, v44, v45 = v3, v4, v39, v6, v7, v36
        v46 = <float>v32
        return UH2_1(v9, v9, v10, v11, v12, v13, v14, v15, v40, v41, v42, v43, v44, v45, 0, v0, v46)
    elif v8 == 2: # raise
        v48 = v2 - (<signed long>1)
        v49 = v5 + (<signed long>2)
        v50 = method36(v1, v6, v7, v49, v3, v4, v5, v48)
        v51 = Closure17(v4, v0, v1, v48, v6, v7, v49, v3, v5, v13, v14, v15, v10, v11, v12, v9)
        return UH2_0(v9, v9, v10, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v49, 0, v0, v4, v50, v51)
cdef UH2 method32(US1 v0, US1 v1, US1 v2, Heap0 v3, US2 v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
    cdef signed long v12
    cdef unsigned char v13
    cdef signed long v14
    cdef unsigned char v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef object v17
    cdef object v19
    cdef signed long v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned char v24
    cdef signed long v25
    cdef numpy.ndarray[signed long,ndim=1] v26
    cdef object v27
    if v4 == 0: # call
        v12 = (<signed long>2)
        v13 = (<unsigned char>1)
        v14 = (<signed long>1)
        v15 = (<unsigned char>0)
        v16 = method33(v3, v0, v15, v14, v1, v13, v12)
        v17 = Closure14(v13, v2, v3, v12, v0, v15, v14, v1, v9, v10, v11, v6, v7, v8, v5)
        return UH2_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v13, v14, v0, v15, v14, 0, v2, v13, v16, v17)
    elif v4 == 1: # fold
        raise Exception("impossible 1")
    elif v4 == 2: # raise
        v21 = (<signed long>1)
        v22 = (<unsigned char>1)
        v23 = (<signed long>1)
        v24 = (<unsigned char>0)
        v25 = (<signed long>3)
        v26 = method36(v3, v0, v24, v25, v1, v22, v23, v21)
        v27 = Closure17(v22, v2, v3, v21, v0, v24, v25, v1, v23, v9, v10, v11, v6, v7, v8, v5)
        return UH2_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v22, v23, v0, v24, v25, 0, v2, v22, v26, v27)
cdef numpy.ndarray[float,ndim=1] method40(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef unsigned long long v10
    cdef Mut1 v11
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
    cdef US1 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef US1 v26
    cdef unsigned char v27
    cdef signed long v28
    cdef bint v29
    cdef US1 v30
    cdef unsigned char v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef object v33
    cdef bint v34
    cdef float v35
    cdef float v36
    cdef UH0 v37
    cdef float v38
    cdef float v39
    cdef UH0 v40
    cdef float v41
    cdef float v42
    cdef US1 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef US1 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef bint v49
    cdef US1 v50
    cdef float v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef bint v54
    cdef list v125
    cdef numpy.ndarray[object,ndim=1] v55
    cdef object v56
    cdef Tuple0 tmp23
    cdef numpy.ndarray[object,ndim=1] v57
    cdef object v58
    cdef Tuple0 tmp24
    cdef unsigned long long v59
    cdef unsigned long long v60
    cdef bint v61
    cdef bint v62
    cdef numpy.ndarray[object,ndim=1] v63
    cdef Mut1 v64
    cdef unsigned long long v66
    cdef object v67
    cdef float v68
    cdef float v69
    cdef US2 v70
    cdef Tuple2 tmp25
    cdef UH2 v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef bint v75
    cdef bint v76
    cdef numpy.ndarray[object,ndim=1] v77
    cdef Mut1 v78
    cdef unsigned long long v80
    cdef object v81
    cdef float v82
    cdef float v83
    cdef US2 v84
    cdef Tuple2 tmp26
    cdef UH2 v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef unsigned long long v89
    cdef numpy.ndarray[object,ndim=1] v90
    cdef Mut1 v91
    cdef unsigned long long v93
    cdef bint v94
    cdef UH2 v98
    cdef unsigned long long v96
    cdef unsigned long long v99
    cdef numpy.ndarray[float,ndim=1] v100
    cdef numpy.ndarray[float,ndim=1] v101
    cdef numpy.ndarray[float,ndim=1] v102
    cdef numpy.ndarray[float,ndim=1] v103
    cdef numpy.ndarray[float,ndim=1] v104
    cdef unsigned long long v105
    cdef list v106
    cdef Mut0 v107
    cdef unsigned long long v109
    cdef unsigned long long v110
    cdef unsigned long long v111
    cdef unsigned char v112
    cdef bint v113
    cdef float v118
    cdef unsigned long long v119
    cdef unsigned long long v120
    cdef float v114
    cdef unsigned long long v115
    cdef float v116
    cdef unsigned long long v117
    cdef unsigned long long v121
    cdef unsigned long long v122
    cdef unsigned long long v123
    cdef numpy.ndarray[float,ndim=1] v126
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef bint v129
    cdef bint v130
    cdef Mut1 v131
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef float v135
    cdef unsigned long long v136
    cdef unsigned long long v137
    cdef Mut1 v138
    cdef unsigned long long v140
    cdef unsigned long long v141
    cdef float v142
    cdef float v143
    cdef UH0 v144
    cdef float v145
    cdef float v146
    cdef UH0 v147
    cdef float v148
    cdef float v149
    cdef US1 v150
    cdef unsigned char v151
    cdef signed long v152
    cdef US1 v153
    cdef unsigned char v154
    cdef signed long v155
    cdef bint v156
    cdef US1 v157
    cdef float v158
    cdef Tuple8 tmp27
    cdef unsigned long long v159
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = len(v2)
    v11 = Mut1((<unsigned long long>0))
    while method3(v10, v11):
        v13 = v11.v0
        v14 = v2[v13]
        if v14.tag == 0: # action_
            v15 = (<UH2_0>v14).v0; v16 = (<UH2_0>v14).v1; v17 = (<UH2_0>v14).v2; v18 = (<UH2_0>v14).v3; v19 = (<UH2_0>v14).v4; v20 = (<UH2_0>v14).v5; v21 = (<UH2_0>v14).v6; v22 = (<UH2_0>v14).v7; v23 = (<UH2_0>v14).v8; v24 = (<UH2_0>v14).v9; v25 = (<UH2_0>v14).v10; v26 = (<UH2_0>v14).v11; v27 = (<UH2_0>v14).v12; v28 = (<UH2_0>v14).v13; v29 = (<UH2_0>v14).v14; v30 = (<UH2_0>v14).v15; v31 = (<UH2_0>v14).v16; v32 = (<UH2_0>v14).v17; v33 = (<UH2_0>v14).v18
            v4.append(v13)
            v34 = v31 == (<unsigned char>0)
            if v34:
                v5.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
                v7.append(v33)
            else:
                v6.append(Tuple1(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
                v8.append(v33)
            del v17; del v20; del v32; del v33
            v9.append(v31)
        elif v14.tag == 1: # terminal_
            v35 = (<UH2_1>v14).v0; v36 = (<UH2_1>v14).v1; v37 = (<UH2_1>v14).v2; v38 = (<UH2_1>v14).v3; v39 = (<UH2_1>v14).v4; v40 = (<UH2_1>v14).v5; v41 = (<UH2_1>v14).v6; v42 = (<UH2_1>v14).v7; v43 = (<UH2_1>v14).v8; v44 = (<UH2_1>v14).v9; v45 = (<UH2_1>v14).v10; v46 = (<UH2_1>v14).v11; v47 = (<UH2_1>v14).v12; v48 = (<UH2_1>v14).v13; v49 = (<UH2_1>v14).v14; v50 = (<UH2_1>v14).v15; v51 = (<UH2_1>v14).v16
            v3.append(Tuple8(v13, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51))
            del v37; del v40
        del v14
        v52 = v13 + (<unsigned long long>1)
        v11.v0 = v52
    del v11
    v53 = len(v9)
    v54 = (<unsigned long long>0) < v53
    if v54:
        tmp23 = v1(v5)
        v55, v56 = tmp23.v0, tmp23.v1
        del tmp23
        tmp24 = v0(v6)
        v57, v58 = tmp24.v0, tmp24.v1
        del tmp24
        v59 = len(v7)
        v60 = len(v55)
        v61 = v59 == v60
        v62 = v61 == 0
        if v62:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v63 = numpy.empty(v59,dtype=object)
        v64 = Mut1((<unsigned long long>0))
        while method3(v59, v64):
            v66 = v64.v0
            v67 = v7[v66]
            tmp25 = v55[v66]
            v68, v69, v70 = tmp25.v0, tmp25.v1, tmp25.v2
            del tmp25
            v71 = v67(v68, v69, v70)
            del v67
            v63[v66] = v71
            del v71
            v72 = v66 + (<unsigned long long>1)
            v64.v0 = v72
        del v55
        del v64
        v73 = len(v8)
        v74 = len(v57)
        v75 = v73 == v74
        v76 = v75 == 0
        if v76:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v77 = numpy.empty(v73,dtype=object)
        v78 = Mut1((<unsigned long long>0))
        while method3(v73, v78):
            v80 = v78.v0
            v81 = v8[v80]
            tmp26 = v57[v80]
            v82, v83, v84 = tmp26.v0, tmp26.v1, tmp26.v2
            del tmp26
            v85 = v81(v82, v83, v84)
            del v81
            v77[v80] = v85
            del v85
            v86 = v80 + (<unsigned long long>1)
            v78.v0 = v86
        del v57
        del v78
        v87 = len(v63)
        v88 = len(v77)
        v89 = v87 + v88
        v90 = numpy.empty(v89,dtype=object)
        v91 = Mut1((<unsigned long long>0))
        while method3(v89, v91):
            v93 = v91.v0
            v94 = v93 < v87
            if v94:
                v98 = v63[v93]
            else:
                v96 = v93 - v87
                v98 = v77[v96]
            v90[v93] = v98
            del v98
            v99 = v93 + (<unsigned long long>1)
            v91.v0 = v99
        del v63; del v77
        del v91
        v100 = method40(v0, v1, v90)
        del v90
        v101 = v100[:v60]
        v102 = v56(v101)
        del v56; del v101
        v103 = v100[v60:]
        del v100
        v104 = v58(v103)
        del v58; del v103
        v105 = len(v9)
        v106 = [None]*v105
        v107 = Mut0((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method0(v105, v107):
            v109 = v107.v0
            v110, v111 = v107.v1, v107.v2
            v112 = v9[v109]
            v113 = v112 == (<unsigned char>0)
            if v113:
                v114 = v102[v110]
                v115 = v110 + (<unsigned long long>1)
                v118, v119, v120 = v114, v115, v111
            else:
                v116 = v104[v111]
                v117 = v111 + (<unsigned long long>1)
                v118, v119, v120 = v116, v110, v117
            v106[v109] = v118
            v121 = v109 + (<unsigned long long>1)
            v107.v0 = v121
            v107.v1 = v119
            v107.v2 = v120
        del v102; del v104
        v122, v123 = v107.v1, v107.v2
        del v107
        v125 = v106
        del v106
    else:
        v125 = [None]*(<unsigned long long>0)
    del v5; del v6; del v7; del v8; del v9
    v126 = numpy.empty(v10,dtype=numpy.float32)
    v127 = len(v4)
    v128 = len(v125)
    v129 = v127 == v128
    v130 = v129 == 0
    if v130:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v131 = Mut1((<unsigned long long>0))
    while method3(v127, v131):
        v133 = v131.v0
        v134 = v4[v133]
        v135 = v125[v133]
        v126[v134] = v135
        v136 = v133 + (<unsigned long long>1)
        v131.v0 = v136
    del v4; del v125
    del v131
    v137 = len(v3)
    v138 = Mut1((<unsigned long long>0))
    while method3(v137, v138):
        v140 = v138.v0
        tmp27 = v3[v140]
        v141, v142, v143, v144, v145, v146, v147, v148, v149, v150, v151, v152, v153, v154, v155, v156, v157, v158 = tmp27.v0, tmp27.v1, tmp27.v2, tmp27.v3, tmp27.v4, tmp27.v5, tmp27.v6, tmp27.v7, tmp27.v8, tmp27.v9, tmp27.v10, tmp27.v11, tmp27.v12, tmp27.v13, tmp27.v14, tmp27.v15, tmp27.v16, tmp27.v17
        del tmp27
        del v144; del v147
        v126[v141] = v158
        v159 = v140 + (<unsigned long long>1)
        v138.v0 = v159
    del v3
    del v138
    return v126
cdef numpy.ndarray[float,ndim=1] method41(v0, numpy.ndarray[object,ndim=1] v1):
    cdef list v2
    cdef list v3
    cdef list v4
    cdef list v5
    cdef unsigned long long v6
    cdef Mut1 v7
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
    cdef US1 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US1 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef bint v25
    cdef US1 v26
    cdef unsigned char v27
    cdef numpy.ndarray[signed long,ndim=1] v28
    cdef object v29
    cdef float v30
    cdef float v31
    cdef UH0 v32
    cdef float v33
    cdef float v34
    cdef UH0 v35
    cdef float v36
    cdef float v37
    cdef US1 v38
    cdef unsigned char v39
    cdef signed long v40
    cdef US1 v41
    cdef unsigned char v42
    cdef signed long v43
    cdef bint v44
    cdef US1 v45
    cdef float v46
    cdef unsigned long long v47
    cdef unsigned long long v48
    cdef bint v49
    cdef numpy.ndarray[float,ndim=1] v69
    cdef numpy.ndarray[object,ndim=1] v50
    cdef object v51
    cdef Tuple0 tmp28
    cdef unsigned long long v52
    cdef unsigned long long v53
    cdef bint v54
    cdef bint v55
    cdef numpy.ndarray[object,ndim=1] v56
    cdef Mut1 v57
    cdef unsigned long long v59
    cdef object v60
    cdef float v61
    cdef float v62
    cdef US2 v63
    cdef Tuple2 tmp29
    cdef UH2 v64
    cdef unsigned long long v65
    cdef numpy.ndarray[float,ndim=1] v66
    cdef numpy.ndarray[float,ndim=1] v68
    cdef numpy.ndarray[float,ndim=1] v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef bint v73
    cdef bint v74
    cdef Mut1 v75
    cdef unsigned long long v77
    cdef unsigned long long v78
    cdef float v79
    cdef unsigned long long v80
    cdef unsigned long long v81
    cdef Mut1 v82
    cdef unsigned long long v84
    cdef unsigned long long v85
    cdef float v86
    cdef float v87
    cdef UH0 v88
    cdef float v89
    cdef float v90
    cdef UH0 v91
    cdef float v92
    cdef float v93
    cdef US1 v94
    cdef unsigned char v95
    cdef signed long v96
    cdef US1 v97
    cdef unsigned char v98
    cdef signed long v99
    cdef bint v100
    cdef US1 v101
    cdef float v102
    cdef Tuple8 tmp30
    cdef unsigned long long v103
    v2 = [None]*(<unsigned long long>0)
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = len(v1)
    v7 = Mut1((<unsigned long long>0))
    while method3(v6, v7):
        v9 = v7.v0
        v10 = v1[v9]
        if v10.tag == 0: # action_
            v11 = (<UH2_0>v10).v0; v12 = (<UH2_0>v10).v1; v13 = (<UH2_0>v10).v2; v14 = (<UH2_0>v10).v3; v15 = (<UH2_0>v10).v4; v16 = (<UH2_0>v10).v5; v17 = (<UH2_0>v10).v6; v18 = (<UH2_0>v10).v7; v19 = (<UH2_0>v10).v8; v20 = (<UH2_0>v10).v9; v21 = (<UH2_0>v10).v10; v22 = (<UH2_0>v10).v11; v23 = (<UH2_0>v10).v12; v24 = (<UH2_0>v10).v13; v25 = (<UH2_0>v10).v14; v26 = (<UH2_0>v10).v15; v27 = (<UH2_0>v10).v16; v28 = (<UH2_0>v10).v17; v29 = (<UH2_0>v10).v18
            v3.append(v9)
            v4.append(Tuple1(v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28))
            del v13; del v16; del v28
            v5.append(v29)
            del v29
        elif v10.tag == 1: # terminal_
            v30 = (<UH2_1>v10).v0; v31 = (<UH2_1>v10).v1; v32 = (<UH2_1>v10).v2; v33 = (<UH2_1>v10).v3; v34 = (<UH2_1>v10).v4; v35 = (<UH2_1>v10).v5; v36 = (<UH2_1>v10).v6; v37 = (<UH2_1>v10).v7; v38 = (<UH2_1>v10).v8; v39 = (<UH2_1>v10).v9; v40 = (<UH2_1>v10).v10; v41 = (<UH2_1>v10).v11; v42 = (<UH2_1>v10).v12; v43 = (<UH2_1>v10).v13; v44 = (<UH2_1>v10).v14; v45 = (<UH2_1>v10).v15; v46 = (<UH2_1>v10).v16
            v2.append(Tuple8(v9, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46))
            del v32; del v35
        del v10
        v47 = v9 + (<unsigned long long>1)
        v7.v0 = v47
    del v7
    v48 = len(v4)
    v49 = (<unsigned long long>0) < v48
    if v49:
        tmp28 = v0(v4)
        v50, v51 = tmp28.v0, tmp28.v1
        del tmp28
        v52 = len(v5)
        v53 = len(v50)
        v54 = v52 == v53
        v55 = v54 == 0
        if v55:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v56 = numpy.empty(v52,dtype=object)
        v57 = Mut1((<unsigned long long>0))
        while method3(v52, v57):
            v59 = v57.v0
            v60 = v5[v59]
            tmp29 = v50[v59]
            v61, v62, v63 = tmp29.v0, tmp29.v1, tmp29.v2
            del tmp29
            v64 = v60(v61, v62, v63)
            del v60
            v56[v59] = v64
            del v64
            v65 = v59 + (<unsigned long long>1)
            v57.v0 = v65
        del v50
        del v57
        v66 = method41(v0, v56)
        del v56
        v69 = v51(v66)
        del v51; del v66
    else:
        v68 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v69 = v68
        del v68
    del v4; del v5
    v70 = numpy.empty(v6,dtype=numpy.float32)
    v71 = len(v3)
    v72 = len(v69)
    v73 = v71 == v72
    v74 = v73 == 0
    if v74:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v75 = Mut1((<unsigned long long>0))
    while method3(v71, v75):
        v77 = v75.v0
        v78 = v3[v77]
        v79 = v69[v77]
        v70[v78] = v79
        v80 = v77 + (<unsigned long long>1)
        v75.v0 = v80
    del v3; del v69
    del v75
    v81 = len(v2)
    v82 = Mut1((<unsigned long long>0))
    while method3(v81, v82):
        v84 = v82.v0
        tmp30 = v2[v84]
        v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102 = tmp30.v0, tmp30.v1, tmp30.v2, tmp30.v3, tmp30.v4, tmp30.v5, tmp30.v6, tmp30.v7, tmp30.v8, tmp30.v9, tmp30.v10, tmp30.v11, tmp30.v12, tmp30.v13, tmp30.v14, tmp30.v15, tmp30.v16, tmp30.v17
        del tmp30
        del v88; del v91
        v70[v85] = v102
        v103 = v84 + (<unsigned long long>1)
        v82.v0 = v103
    del v2
    del v82
    return v70
cpdef object main():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    v0 = collections.namedtuple("Size",['action', 'policy', 'value'])((<signed short>3), (<signed short>6), (<signed short>12))
    v1 = Closure0()
    v2 = collections.namedtuple("Neural",['handler', 'size'])(v1, v0)
    del v0; del v1
    v3 = Closure4()
    v4 = Closure5()
    v5 = Closure6()
    v6 = Closure9()
    v7 = Closure10()
    v8 = collections.namedtuple("Tabular",['average', 'create_agent', 'create_policy', 'head_multiply_', 'optimize'])(v3, v4, v5, v6, v7)
    del v3; del v4; del v5; del v6; del v7
    v9 = Closure11()
    v10 = Closure12()
    v11 = Closure18()
    return {'neural': v2, 'tabular': v8, 'uniform_player': v9, 'vs_one': v10, 'vs_self': v11}
