import numpy
cimport numpy
import collections
import torch
cimport libc.math
ctypedef signed long US0
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
ctypedef signed long US1
cdef class Mut0:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
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
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 1; self.v0 = v0
cdef class Tuple0:
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
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
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
cdef class Tuple1:
    cdef readonly US1 v0
    cdef readonly object v1
    def __init__(self, US1 v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple2:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US0 v2
    def __init__(self, float v0, float v1, US0 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
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
        cdef US1 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef US1 v25
        cdef unsigned char v26
        cdef signed long v27
        cdef US3 v28
        cdef unsigned char v29
        cdef numpy.ndarray[signed long,ndim=1] v30
        cdef Tuple0 tmp2
        cdef bint v31
        cdef float v32
        cdef float v33
        cdef float v34
        cdef float v35
        cdef float v36
        cdef float v37
        cdef float v38
        cdef float v39
        cdef float v40
        cdef float v41
        cdef float v43
        cdef unsigned long long v44
        cdef object v45
        cdef object v46
        cdef object v47
        cdef numpy.ndarray[float,ndim=1] v48
        cdef unsigned long long v49
        cdef unsigned long long v50
        cdef bint v51
        cdef bint v52
        cdef numpy.ndarray[float,ndim=1] v53
        cdef Mut0 v54
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
        cdef US3 v72
        cdef unsigned char v73
        cdef numpy.ndarray[signed long,ndim=1] v74
        cdef Tuple0 tmp3
        cdef bint v75
        cdef float v77
        cdef float v76
        cdef unsigned long long v78
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
            tmp2 = v0[v12]
            v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16
            del tmp2
            del v16; del v19; del v28; del v30
            v31 = v29 == (<unsigned char>0)
            if v31:
                v32, v33, v34, v35 = v17, v18, v20, v21
            else:
                v32, v33, v34, v35 = v20, v21, v17, v18
            v36 = v15 + v35
            v37 = v14 + v34
            v38 = -v33
            v39 = v37 - v36
            v40 = v38 + v39
            v41 = libc.math.exp(v40)
            v5[v12] = v41
            if v31:
                v43 = v13
            else:
                v43 = -v13
            v4[v12] = v43
            v44 = v12 + (<unsigned long long>1)
            v10.v0 = v44
        del v10
        v45 = torch.from_numpy(numpy.expand_dims(v4,-1))
        del v4
        v46 = torch.from_numpy(numpy.expand_dims(v5,-1))
        del v5
        v47 = v2(v45, v46)
        del v45; del v46
        v48 = v47.squeeze(-1).numpy()
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
        v54 = Mut0((<unsigned long long>0))
        while method0(v49, v54):
            v56 = v54.v0
            v57 = v48[v56]
            tmp3 = v0[v56]
            v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4, tmp3.v5, tmp3.v6, tmp3.v7, tmp3.v8, tmp3.v9, tmp3.v10, tmp3.v11, tmp3.v12, tmp3.v13, tmp3.v14, tmp3.v15, tmp3.v16
            del tmp3
            del v60; del v63; del v72; del v74
            v75 = v73 == (<unsigned char>0)
            if v75:
                v77 = v57
            else:
                v76 = -v57
                v77 = v76
            v53[v56] = v77
            v78 = v56 + (<unsigned long long>1)
            v54.v0 = v78
        del v48
        del v54
        return v53
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
        cdef US1 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US1 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US3 v24
        cdef unsigned char v25
        cdef numpy.ndarray[signed long,ndim=1] v26
        cdef Tuple0 tmp0
        cdef bint v27
        cdef UH0 v28
        cdef bint v29
        cdef US1 v30
        cdef numpy.ndarray[object,ndim=1] v31
        cdef numpy.ndarray[float,ndim=1] v32
        cdef unsigned long long v33
        cdef bint v34
        cdef Mut0 v35
        cdef unsigned long long v37
        cdef US1 v38
        cdef numpy.ndarray[signed long,ndim=1] v39
        cdef Tuple1 tmp1
        cdef unsigned long long v40
        cdef unsigned long long v41
        cdef unsigned long long v42
        cdef unsigned long long v43
        cdef unsigned long long v44
        cdef bint v45
        cdef Mut0 v46
        cdef unsigned long long v48
        cdef US0 v49
        cdef unsigned long long v50
        cdef unsigned long long v51
        cdef unsigned long long v52
        cdef unsigned long long v53
        cdef unsigned long long v54
        cdef unsigned long long v55
        cdef unsigned long long v56
        cdef Mut0 v57
        cdef unsigned long long v59
        cdef US0 v60
        cdef signed long long v61
        cdef unsigned long long v62
        cdef unsigned long long v63
        cdef object v64
        cdef object v65
        cdef object v66
        cdef object v67
        cdef object v68
        cdef object v69
        cdef object v70
        cdef object v71
        cdef numpy.ndarray[object,ndim=1] v72
        cdef Mut0 v73
        cdef unsigned long long v75
        cdef signed long long v76
        cdef float v77
        cdef float v78
        cdef float v79
        cdef float v80
        cdef bint v81
        cdef US0 v98
        cdef bint v82
        cdef bint v83
        cdef bint v85
        cdef signed long long v86
        cdef bint v87
        cdef bint v88
        cdef bint v90
        cdef signed long long v91
        cdef bint v92
        cdef bint v93
        cdef unsigned long long v99
        cdef object v100
        pass # import torch
        v2 = len(v1)
        v3 = numpy.zeros((v2,(<unsigned long long>33)),dtype=numpy.float32)
        v4 = v3[:,:(<unsigned long long>30)]
        v5 = numpy.ones((v2,(<signed long long>3)),dtype=numpy.int8)
        v6 = len(v1)
        v7 = Mut0((<unsigned long long>0))
        while method0(v6, v7):
            v9 = v7.v0
            tmp0 = v1[v9]
            v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
            del tmp0
            del v24
            v27 = v25 == (<unsigned char>0)
            if v27:
                v28 = v12
            else:
                v28 = v15
            del v12; del v15
            v29 = v19 == v25
            if v29:
                v30 = v21
            else:
                v30 = v18
            v31 = method1(v28)
            del v28
            v32 = v3[v9,:]
            v33 = len(v31)
            v34 = (<unsigned long long>2) < v33
            if v34:
                raise Exception("The given array is too large.")
            else:
                pass
            v35 = Mut0((<unsigned long long>0))
            while method0(v33, v35):
                v37 = v35.v0
                tmp1 = v31[v37]
                v38, v39 = tmp1.v0, tmp1.v1
                del tmp1
                v40 = v37 * (<unsigned long long>15)
                if v38 == 0: # jack
                    v32[v40] = (<float>1.000000)
                elif v38 == 1: # king
                    v41 = v40 + (<unsigned long long>1)
                    v32[v41] = (<float>1.000000)
                elif v38 == 2: # queen
                    v42 = v40 + (<unsigned long long>2)
                    v32[v42] = (<float>1.000000)
                v43 = v40 + (<unsigned long long>3)
                v44 = len(v39)
                v45 = (<unsigned long long>4) < v44
                if v45:
                    raise Exception("The given array is too large.")
                else:
                    pass
                v46 = Mut0((<unsigned long long>0))
                while method0(v44, v46):
                    v48 = v46.v0
                    v49 = v39[v48]
                    v50 = v48 * (<unsigned long long>3)
                    v51 = v43 + v50
                    if v49 == 0: # call
                        v32[v51] = (<float>1.000000)
                    elif v49 == 1: # fold
                        v52 = v51 + (<unsigned long long>1)
                        v32[v52] = (<float>1.000000)
                    elif v49 == 2: # raise
                        v53 = v51 + (<unsigned long long>2)
                        v32[v53] = (<float>1.000000)
                    v54 = v48 + (<unsigned long long>1)
                    v46.v0 = v54
                del v39
                del v46
                v55 = v37 + (<unsigned long long>1)
                v35.v0 = v55
            del v31
            del v35
            if v30 == 0: # jack
                v32[(<unsigned long long>30)] = (<float>1.000000)
            elif v30 == 1: # king
                v32[(<unsigned long long>31)] = (<float>1.000000)
            elif v30 == 2: # queen
                v32[(<unsigned long long>32)] = (<float>1.000000)
            del v32
            v56 = len(v26)
            v57 = Mut0((<unsigned long long>0))
            while method0(v56, v57):
                v59 = v57.v0
                v60 = v26[v59]
                if v60 == 0: # call
                    v61 = (<signed long long>0)
                elif v60 == 1: # fold
                    v61 = (<signed long long>1)
                elif v60 == 2: # raise
                    v61 = (<signed long long>2)
                v5[v9,v61] = 0
                v62 = v59 + (<unsigned long long>1)
                v57.v0 = v62
            del v26
            del v57
            v63 = v9 + (<unsigned long long>1)
            v7.v0 = v63
        del v7
        v64 = torch.from_numpy(v4)
        del v4
        v65 = torch.from_numpy(v3)
        del v3
        v66 = torch.from_numpy(v5)
        del v5
        v67 = v0(v64, v65, v66)
        del v64; del v65; del v66
        v68 = v67[0]
        v69 = v67[1]
        v70 = v67[2]
        v71 = v67[3]
        del v67
        v72 = numpy.empty(v2,dtype=object)
        v73 = Mut0((<unsigned long long>0))
        while method0(v2, v73):
            v75 = v73.v0
            v76 = v70[v75]
            v77 = v68[v75,v76]
            v78 = v69[v75,v76]
            v79 = libc.math.log(v78)
            v80 = libc.math.log(v77)
            v81 = v76 < (<signed long long>1)
            if v81:
                v82 = v76 == (<signed long long>0)
                v83 = v82 == 0
                if v83:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v98 = 0
            else:
                v85 = v76 < (<signed long long>2)
                if v85:
                    v86 = v76 - (<signed long long>1)
                    v87 = v86 == (<signed long long>0)
                    v88 = v87 == 0
                    if v88:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v98 = 1
                else:
                    v90 = v76 < (<signed long long>3)
                    if v90:
                        v91 = v76 - (<signed long long>2)
                        v92 = v91 == (<signed long long>0)
                        v93 = v92 == 0
                        if v93:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v98 = 2
                    else:
                        raise Exception("Unpickling of an union failed.")
            v72[v75] = Tuple2(v80, v79, v98)
            v99 = v75 + (<unsigned long long>1)
            v73.v0 = v99
        del v68; del v69; del v70
        del v73
        v100 = Closure2(v1, v2, v71)
        del v71
        return Tuple3(v72, v100)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure1(v0)
cdef class Mut1:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple4:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut2 v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, Mut2 v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple5:
    cdef readonly Mut2 v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, Mut2 v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut3:
    cdef public signed long long v0
    cdef public float v1
    def __init__(self, signed long long v0, float v1): self.v0 = v0; self.v1 = v1
cdef class Mut4:
    cdef public signed long long v0
    def __init__(self, signed long long v0): self.v0 = v0
cdef class Tuple6:
    cdef readonly unsigned long long v0
    cdef readonly US1 v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, unsigned long long v0, US1 v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple7:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure3():
    def __init__(self): pass
    def __call__(self, Mut1 v0, Mut1 v1):
        method11(v0, v1)
cdef class Closure4():
    def __init__(self): pass
    def __call__(self):
        cdef unsigned long long v0
        cdef unsigned long long v1
        v0 = (<unsigned long long>3)
        v1 = (<unsigned long long>7)
        return method28(v0, v1)
cdef class Tuple8:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure7():
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
        cdef Mut0 v14
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
        cdef Mut0 v34
        cdef unsigned long long v36
        cdef numpy.ndarray[float,ndim=1] v37
        cdef numpy.ndarray[float,ndim=1] v38
        cdef numpy.ndarray[float,ndim=1] v39
        cdef numpy.ndarray[float,ndim=1] v40
        cdef Tuple8 tmp15
        cdef signed long long v41
        cdef numpy.ndarray[float,ndim=1] v42
        cdef float v43
        cdef signed long long v44
        cdef signed long long v45
        cdef bint v46
        cdef bint v47
        cdef numpy.ndarray[float,ndim=1] v48
        cdef Mut4 v49
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
        cdef Mut0 v71
        cdef unsigned long long v73
        cdef numpy.ndarray[float,ndim=1] v74
        cdef numpy.ndarray[float,ndim=1] v75
        cdef signed long long v76
        cdef signed long long v77
        cdef bint v78
        cdef bint v79
        cdef Mut3 v80
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
        cdef Mut0 v98
        cdef unsigned long long v100
        cdef numpy.ndarray[float,ndim=1] v101
        cdef numpy.ndarray[float,ndim=1] v102
        cdef numpy.ndarray[float,ndim=1] v103
        cdef numpy.ndarray[float,ndim=1] v104
        cdef Tuple8 tmp16
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
        cdef Mut0 v122
        cdef unsigned long long v124
        cdef numpy.ndarray[float,ndim=1] v125
        cdef numpy.ndarray[float,ndim=1] v126
        cdef numpy.ndarray[float,ndim=1] v127
        cdef numpy.ndarray[float,ndim=1] v128
        cdef Tuple8 tmp17
        cdef numpy.ndarray[float,ndim=1] v129
        cdef float v130
        cdef float v131
        cdef signed long long v132
        cdef Mut4 v133
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
        cdef Mut0 v147
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
        v14 = Mut0((<unsigned long long>0))
        while method0(v9, v14):
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
        v34 = Mut0((<unsigned long long>0))
        while method0(v23, v34):
            v36 = v34.v0
            tmp15 = v3[v36]
            v37, v38, v39, v40 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3
            del tmp15
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
            v49 = Mut4((<signed long long>0))
            while method21(v44, v49):
                v51 = v49.v0
                v52 = v38[v51]
                v53 = v37[v51]
                v54 = v53 == (<float>0.000000)
                v55 = v54 != 1
                if v55:
                    v57 = v52 / v53
                else:
                    v57 = (<float>0.000000)
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
        v71 = Mut0((<unsigned long long>0))
        while method0(v66, v71):
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
            v80 = Mut3((<signed long long>0), (<float>0.000000))
            while method20(v76, v80):
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
            v98 = Mut0((<unsigned long long>0))
            while method0(v23, v98):
                v100 = v98.v0
                tmp16 = v3[v100]
                v101, v102, v103, v104 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3
                del tmp16
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
            v122 = Mut0((<unsigned long long>0))
            while method0(v23, v122):
                v124 = v122.v0
                tmp17 = v3[v124]
                v125, v126, v127, v128 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3
                del tmp17
                del v125; del v126; del v127
                v129 = v33[v124]
                v130 = v70[v124]
                v131 = v2[v124]
                v132 = len(v128)
                v133 = Mut4((<signed long long>0))
                while method21(v132, v133):
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
        v147 = Mut0((<unsigned long long>0))
        while method0(v143, v147):
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
cdef class Closure6():
    cdef float v0
    cdef bint v1
    cdef bint v2
    cdef Mut1 v3
    def __init__(self, float v0, bint v1, bint v2, Mut1 v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, list v4):
        cdef float v0 = self.v0
        cdef bint v1 = self.v1
        cdef bint v2 = self.v2
        cdef Mut1 v3 = self.v3
        cdef unsigned long long v5
        cdef numpy.ndarray[float,ndim=1] v6
        cdef numpy.ndarray[object,ndim=1] v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef numpy.ndarray[object,ndim=1] v9
        cdef numpy.ndarray[signed long long,ndim=1] v10
        cdef numpy.ndarray[unsigned char,ndim=1] v11
        cdef unsigned long long v12
        cdef numpy.ndarray[object,ndim=1] v13
        cdef Mut0 v14
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
        cdef US3 v31
        cdef unsigned char v32
        cdef numpy.ndarray[signed long,ndim=1] v33
        cdef Tuple0 tmp12
        cdef bint v34
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
        cdef UH0 v45
        cdef bint v46
        cdef US1 v47
        cdef unsigned long long v48
        cdef Mut2 v49
        cdef numpy.ndarray[float,ndim=1] v50
        cdef numpy.ndarray[float,ndim=1] v51
        cdef Tuple5 tmp13
        cdef numpy.ndarray[float,ndim=1] v52
        cdef numpy.ndarray[float,ndim=1] v53
        cdef Tuple7 tmp14
        cdef signed long long v54
        cdef bint v55
        cdef float v56
        cdef Mut3 v57
        cdef signed long long v59
        cdef float v60
        cdef float v61
        cdef float v62
        cdef signed long long v63
        cdef float v64
        cdef bint v65
        cdef float v69
        cdef float v70
        cdef float v66
        cdef float v67
        cdef float v68
        cdef numpy.ndarray[float,ndim=1] v71
        cdef Mut4 v72
        cdef signed long long v74
        cdef float v75
        cdef float v76
        cdef float v77
        cdef signed long long v78
        cdef signed long long v79
        cdef numpy.ndarray[float,ndim=1] v80
        cdef Mut4 v81
        cdef signed long long v83
        cdef float v84
        cdef float v85
        cdef float v86
        cdef float v87
        cdef float v88
        cdef float v89
        cdef signed long long v90
        cdef signed long long v91
        cdef float v92
        cdef float v93
        cdef float v94
        cdef float v95
        cdef unsigned long long v96
        cdef US0 v97
        cdef unsigned long long v98
        cdef object v99
        v5 = len(v4)
        v6 = numpy.empty(v5,dtype=numpy.float32)
        v7 = numpy.empty(v5,dtype=object)
        v8 = numpy.empty(v5,dtype=object)
        v9 = numpy.empty(v5,dtype=object)
        v10 = numpy.empty(v5,dtype=numpy.int64)
        v11 = numpy.empty(v5,dtype=numpy.uint8)
        v12 = len(v4)
        v13 = numpy.empty(v12,dtype=object)
        v14 = Mut0((<unsigned long long>0))
        while method0(v12, v14):
            v16 = v14.v0
            tmp12 = v4[v16]
            v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33 = tmp12.v0, tmp12.v1, tmp12.v2, tmp12.v3, tmp12.v4, tmp12.v5, tmp12.v6, tmp12.v7, tmp12.v8, tmp12.v9, tmp12.v10, tmp12.v11, tmp12.v12, tmp12.v13, tmp12.v14, tmp12.v15, tmp12.v16
            del tmp12
            del v31
            v34 = v32 == (<unsigned char>0)
            if v34:
                v35, v36, v37, v38 = v20, v21, v23, v24
            else:
                v35, v36, v37, v38 = v23, v24, v20, v21
            v39 = v18 + v38
            v40 = v17 + v37
            v41 = -v36
            v42 = v40 - v39
            v43 = v41 + v42
            v44 = libc.math.exp(v43)
            v6[v16] = v44
            if v34:
                v45 = v19
            else:
                v45 = v22
            del v19; del v22
            v46 = v26 == v32
            if v46:
                v47 = v28
            else:
                v47 = v25
            v48 = len(v33)
            tmp13 = method12(v3, v48, v45)
            v49, v50, v51 = tmp13.v0, tmp13.v1, tmp13.v2
            del tmp13
            del v45
            tmp14 = method23(v49, v48, v47)
            v52, v53 = tmp14.v0, tmp14.v1
            del tmp14
            del v49
            v7[v16] = Tuple8(v52, v53, v50, v51)
            del v51; del v52; del v53
            v54 = len(v50)
            v55 = v54 == (<signed long long>0)
            if v55:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v56 = v50[(<signed long long>0)]
            v57 = Mut3((<signed long long>1), v56)
            while method20(v54, v57):
                v59 = v57.v0
                v60 = v57.v1
                v61 = v50[v59]
                v62 = v60 + v61
                v63 = v59 + (<signed long long>1)
                v57.v0 = v63
                v57.v1 = v62
            v64 = v57.v1
            del v57
            v65 = v64 == (<float>0.000000)
            if v65:
                v66 = <float>v54
                v67 = (<float>1.000000) / v66
                v69, v70 = v67, (<float>0.000000)
            else:
                v68 = (<float>1.000000) / v64
                v69, v70 = (<float>0.000000), v68
            v71 = numpy.empty(v54,dtype=numpy.float32)
            v72 = Mut4((<signed long long>0))
            while method21(v54, v72):
                v74 = v72.v0
                v75 = v50[v74]
                v76 = v75 * v70
                v77 = v69 + v76
                v71[v74] = v77
                v78 = v74 + (<signed long long>1)
                v72.v0 = v78
            del v50
            del v72
            v8[v16] = v71
            v79 = len(v71)
            v80 = numpy.empty(v79,dtype=numpy.float32)
            v81 = Mut4((<signed long long>0))
            while method21(v79, v81):
                v83 = v81.v0
                v84 = v71[v83]
                v85 = <float>v48
                v86 = v0 / v85
                v87 = (<float>1.000000) - v0
                v88 = v87 * v84
                v89 = v86 + v88
                v80[v83] = v89
                v90 = v83 + (<signed long long>1)
                v81.v0 = v90
            del v81
            v9[v16] = v80
            v91 = numpy.random.choice(v48,p=v80)
            v10[v16] = v91
            v11[v16] = v32
            v92 = v71[v91]
            del v71
            v93 = v80[v91]
            del v80
            v94 = libc.math.log(v93)
            v95 = libc.math.log(v92)
            v96 = <unsigned long long>v91
            v97 = v33[v96]
            del v33
            v13[v16] = Tuple2(v95, v94, v97)
            v98 = v16 + (<unsigned long long>1)
            v14.v0 = v98
        del v14
        v99 = Closure7(v1, v2, v6, v7, v8, v9, v10, v11)
        del v6; del v7; del v8; del v9; del v10; del v11
        return Tuple3(v13, v99)
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, Mut1 v0, bint v1, bint v2, float v3):
        return Closure6(v3, v2, v1, v0)
cdef class Closure8():
    def __init__(self): pass
    def __call__(self, Mut1 v0, float v1):
        method29(v1, v0)
cdef class Closure9():
    def __init__(self): pass
    def __call__(self, Mut1 v0):
        method31(v0)
cdef class Closure11():
    def __init__(self): pass
    def __call__(self, numpy.ndarray[float,ndim=1] v0):
        return v0
cdef class Closure10():
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
        cdef US1 v14
        cdef unsigned char v15
        cdef signed long v16
        cdef US1 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef US3 v20
        cdef unsigned char v21
        cdef numpy.ndarray[signed long,ndim=1] v22
        cdef Tuple0 tmp21
        cdef unsigned long long v23
        cdef float v24
        cdef float v25
        cdef float v26
        cdef US0 v27
        cdef unsigned long long v28
        cdef object v29
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp21 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4, tmp21.v5, tmp21.v6, tmp21.v7, tmp21.v8, tmp21.v9, tmp21.v10, tmp21.v11, tmp21.v12, tmp21.v13, tmp21.v14, tmp21.v15, tmp21.v16
            del tmp21
            del v8; del v11; del v20
            v23 = len(v22)
            v24 = <float>v23
            v25 = (<float>1.000000) / v24
            v26 = libc.math.log(v25)
            v27 = numpy.random.choice(v22)
            del v22
            v2[v5] = Tuple2(v26, v26, v27)
            v28 = v5 + (<unsigned long long>1)
            v3.v0 = v28
        del v3
        v29 = Closure11()
        return Tuple3(v2, v29)
cdef class UH3:
    cdef readonly signed long tag
cdef class UH3_0(UH3): # action_
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
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    cdef readonly object v17
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16, v17): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class UH3_1(UH3): # terminal_
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
    cdef readonly US3 v14
    cdef readonly float v15
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US1 v8, unsigned char v9, signed long v10, US1 v11, unsigned char v12, signed long v13, US3 v14, float v15): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
cdef class Closure16():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef signed long v2
    cdef US1 v3
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
    def __init__(self, unsigned char v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US0 v18):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef signed long v2 = self.v2
        cdef US1 v3 = self.v3
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
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
        cdef US2 v29
        cdef UH0 v30
        cdef US2 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v14
            v21 = v16 + v13
            v22 = US2_0(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US2_0(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure15():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef US1 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US1 v5
    cdef signed long v6
    cdef US1 v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, signed long v6, US1 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US0 v17):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef US1 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US1 v5 = self.v5
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
        cdef US2 v21
        cdef US2 v22
        cdef UH0 v23
        cdef UH0 v24
        cdef US2 v25
        cdef US2 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef float v30
        cdef float v31
        cdef US2 v32
        cdef US2 v33
        cdef UH0 v34
        cdef UH0 v35
        cdef US2 v36
        cdef US2 v37
        cdef UH0 v38
        cdef UH0 v39
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v13
            v20 = v15 + v12
            v21 = US2_0(v17)
            v22 = US2_1(v7)
            v23 = UH0_0(v22, v11)
            del v22
            v24 = UH0_0(v21, v23)
            del v21; del v23
            v25 = US2_0(v17)
            v26 = US2_1(v7)
            v27 = UH0_0(v26, v8)
            del v26
            v28 = UH0_0(v25, v27)
            del v25; del v27
            return method35(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v24, v20, v19, v28, v9, v10)
        else:
            v30 = v16 + v10
            v31 = v15 + v9
            v32 = US2_0(v17)
            v33 = US2_1(v7)
            v34 = UH0_0(v33, v11)
            del v33
            v35 = UH0_0(v32, v34)
            del v32; del v34
            v36 = US2_0(v17)
            v37 = US2_1(v7)
            v38 = UH0_0(v37, v8)
            del v37
            v39 = UH0_0(v36, v38)
            del v36; del v38
            return method35(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v35, v12, v13, v39, v31, v30)
cdef class Closure17():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef object v2
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
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US0 v18):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
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
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        cdef float v27
        cdef float v28
        cdef US2 v29
        cdef UH0 v30
        cdef US2 v31
        cdef UH0 v32
        v19 = v0 == (<unsigned char>0)
        if v19:
            v20 = v17 + v14
            v21 = v16 + v13
            v22 = US2_0(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US2_0(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US2_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US2_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method39(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure14():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef object v2
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
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US0 v17):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
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
        cdef US2 v21
        cdef UH0 v22
        cdef US2 v23
        cdef UH0 v24
        cdef float v26
        cdef float v27
        cdef US2 v28
        cdef UH0 v29
        cdef US2 v30
        cdef UH0 v31
        v18 = v0 == (<unsigned char>0)
        if v18:
            v19 = v16 + v13
            v20 = v15 + v12
            v21 = US2_0(v17)
            v22 = UH0_0(v21, v11)
            del v21
            v23 = US2_0(v17)
            v24 = UH0_0(v23, v8)
            del v23
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v22, v20, v19, v24, v9, v10)
        else:
            v26 = v16 + v10
            v27 = v15 + v9
            v28 = US2_0(v17)
            v29 = UH0_0(v28, v11)
            del v28
            v30 = US2_0(v17)
            v31 = UH0_0(v30, v8)
            del v30
            return method34(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v29, v12, v13, v31, v27, v26)
cdef class Closure13():
    cdef US1 v0
    cdef US1 v1
    cdef Heap0 v2
    cdef object v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef float v10
    def __init__(self, US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, float v5, float v6, UH0 v7, float v8, float v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, US0 v13):
        cdef US1 v0 = self.v0
        cdef US1 v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef float v5 = self.v5
        cdef float v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef float v8 = self.v8
        cdef float v9 = self.v9
        cdef float v10 = self.v10
        cdef float v14
        cdef float v15
        cdef US2 v16
        cdef US2 v17
        cdef UH0 v18
        cdef UH0 v19
        cdef US2 v20
        cdef US2 v21
        cdef UH0 v22
        cdef UH0 v23
        v14 = v12 + v9
        v15 = v11 + v8
        v16 = US2_0(v13)
        v17 = US2_1(v0)
        v18 = UH0_0(v17, v7)
        del v17
        v19 = UH0_0(v16, v18)
        del v16; del v18
        v20 = US2_0(v13)
        v21 = US2_1(v1)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = UH0_0(v20, v22)
        del v20; del v22
        return method32(v0, v1, v2, v3, v13, v10, v19, v15, v14, v23, v5, v6)
cdef class Tuple9:
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
    cdef readonly US3 v15
    cdef readonly float v16
    def __init__(self, unsigned long long v0, float v1, float v2, UH0 v3, float v4, float v5, UH0 v6, float v7, float v8, US1 v9, unsigned char v10, signed long v11, US1 v12, unsigned char v13, signed long v14, US3 v15, float v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class Mut5:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure12():
    cdef object v0
    cdef Heap0 v1
    def __init__(self, numpy.ndarray[signed long,ndim=1] v0, Heap0 v1): self.v0 = v0; self.v1 = v1
    def __call__(self, unsigned long long v2, v3, v4):
        cdef numpy.ndarray[signed long,ndim=1] v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v5
        cdef Mut0 v6
        cdef unsigned long long v8
        cdef UH0 v9
        cdef float v10
        cdef float v11
        cdef UH0 v12
        cdef float v13
        cdef float v14
        cdef unsigned long long v15
        cdef unsigned long long v16
        cdef US1 v17
        cdef unsigned long long v18
        cdef numpy.ndarray[signed long,ndim=1] v19
        cdef Mut0 v20
        cdef unsigned long long v22
        cdef bint v23
        cdef unsigned long long v25
        cdef US1 v26
        cdef unsigned long long v27
        cdef float v28
        cdef float v29
        cdef float v30
        cdef unsigned long long v31
        cdef unsigned long long v32
        cdef US1 v33
        cdef unsigned long long v34
        cdef numpy.ndarray[signed long,ndim=1] v35
        cdef Mut0 v36
        cdef unsigned long long v38
        cdef bint v39
        cdef unsigned long long v41
        cdef US1 v42
        cdef unsigned long long v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef float v47
        cdef numpy.ndarray[signed long,ndim=1] v48
        cdef US2 v49
        cdef UH0 v50
        cdef US2 v51
        cdef UH0 v52
        cdef US3 v53
        cdef object v54
        cdef UH3 v55
        cdef unsigned long long v56
        v5 = numpy.empty(v2,dtype=object)
        v6 = Mut0((<unsigned long long>0))
        while method0(v2, v6):
            v8 = v6.v0
            v9 = UH0_1()
            v10 = (<float>0.000000)
            v11 = (<float>0.000000)
            v12 = UH0_1()
            v13 = (<float>0.000000)
            v14 = (<float>0.000000)
            v15 = len(v0)
            v16 = numpy.random.randint(0,v15)
            v17 = v0[v16]
            v18 = v15 - (<unsigned long long>1)
            v19 = numpy.empty(v18,dtype=numpy.int32)
            v20 = Mut0((<unsigned long long>0))
            while method0(v18, v20):
                v22 = v20.v0
                v23 = v16 <= v22
                if v23:
                    v25 = v22 + (<unsigned long long>1)
                else:
                    v25 = v22
                v26 = v0[v25]
                v19[v22] = v26
                v27 = v22 + (<unsigned long long>1)
                v20.v0 = v27
            del v20
            v28 = <float>v15
            v29 = (<float>1.000000) / v28
            v30 = libc.math.log(v29)
            v31 = len(v19)
            v32 = numpy.random.randint(0,v31)
            v33 = v19[v32]
            v34 = v31 - (<unsigned long long>1)
            v35 = numpy.empty(v34,dtype=numpy.int32)
            v36 = Mut0((<unsigned long long>0))
            while method0(v34, v36):
                v38 = v36.v0
                v39 = v32 <= v38
                if v39:
                    v41 = v38 + (<unsigned long long>1)
                else:
                    v41 = v38
                v42 = v19[v41]
                v35[v38] = v42
                v43 = v38 + (<unsigned long long>1)
                v36.v0 = v43
            del v19
            del v36
            v44 = <float>v31
            v45 = (<float>1.000000) / v44
            v46 = libc.math.log(v45)
            v47 = v46 + v30
            v48 = v1.v2
            v49 = US2_1(v17)
            v50 = UH0_0(v49, v9)
            del v49
            v51 = US2_1(v33)
            v52 = UH0_0(v51, v12)
            del v51
            v53 = US3_0()
            v54 = Closure13(v17, v33, v1, v35, v12, v13, v14, v9, v10, v11, v47)
            del v9; del v12; del v35
            v55 = UH3_0(v47, v47, v50, v10, v11, v52, v13, v14, v17, (<unsigned char>0), (<signed long>1), v33, (<unsigned char>1), (<signed long>1), v53, (<unsigned char>0), v48, v54)
            del v48; del v50; del v52; del v53; del v54
            v5[v8] = v55
            del v55
            v56 = v8 + (<unsigned long long>1)
            v6.v0 = v56
        del v6
        return method40(v4, v3, v5)
cdef class Closure18():
    cdef object v0
    cdef Heap0 v1
    def __init__(self, numpy.ndarray[signed long,ndim=1] v0, Heap0 v1): self.v0 = v0; self.v1 = v1
    def __call__(self, unsigned long long v2, v3):
        cdef numpy.ndarray[signed long,ndim=1] v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v4
        cdef Mut0 v5
        cdef unsigned long long v7
        cdef UH0 v8
        cdef float v9
        cdef float v10
        cdef UH0 v11
        cdef float v12
        cdef float v13
        cdef unsigned long long v14
        cdef unsigned long long v15
        cdef US1 v16
        cdef unsigned long long v17
        cdef numpy.ndarray[signed long,ndim=1] v18
        cdef Mut0 v19
        cdef unsigned long long v21
        cdef bint v22
        cdef unsigned long long v24
        cdef US1 v25
        cdef unsigned long long v26
        cdef float v27
        cdef float v28
        cdef float v29
        cdef unsigned long long v30
        cdef unsigned long long v31
        cdef US1 v32
        cdef unsigned long long v33
        cdef numpy.ndarray[signed long,ndim=1] v34
        cdef Mut0 v35
        cdef unsigned long long v37
        cdef bint v38
        cdef unsigned long long v40
        cdef US1 v41
        cdef unsigned long long v42
        cdef float v43
        cdef float v44
        cdef float v45
        cdef float v46
        cdef numpy.ndarray[signed long,ndim=1] v47
        cdef US2 v48
        cdef UH0 v49
        cdef US2 v50
        cdef UH0 v51
        cdef US3 v52
        cdef object v53
        cdef UH3 v54
        cdef unsigned long long v55
        v4 = numpy.empty(v2,dtype=object)
        v5 = Mut0((<unsigned long long>0))
        while method0(v2, v5):
            v7 = v5.v0
            v8 = UH0_1()
            v9 = (<float>0.000000)
            v10 = (<float>0.000000)
            v11 = UH0_1()
            v12 = (<float>0.000000)
            v13 = (<float>0.000000)
            v14 = len(v0)
            v15 = numpy.random.randint(0,v14)
            v16 = v0[v15]
            v17 = v14 - (<unsigned long long>1)
            v18 = numpy.empty(v17,dtype=numpy.int32)
            v19 = Mut0((<unsigned long long>0))
            while method0(v17, v19):
                v21 = v19.v0
                v22 = v15 <= v21
                if v22:
                    v24 = v21 + (<unsigned long long>1)
                else:
                    v24 = v21
                v25 = v0[v24]
                v18[v21] = v25
                v26 = v21 + (<unsigned long long>1)
                v19.v0 = v26
            del v19
            v27 = <float>v14
            v28 = (<float>1.000000) / v27
            v29 = libc.math.log(v28)
            v30 = len(v18)
            v31 = numpy.random.randint(0,v30)
            v32 = v18[v31]
            v33 = v30 - (<unsigned long long>1)
            v34 = numpy.empty(v33,dtype=numpy.int32)
            v35 = Mut0((<unsigned long long>0))
            while method0(v33, v35):
                v37 = v35.v0
                v38 = v31 <= v37
                if v38:
                    v40 = v37 + (<unsigned long long>1)
                else:
                    v40 = v37
                v41 = v18[v40]
                v34[v37] = v41
                v42 = v37 + (<unsigned long long>1)
                v35.v0 = v42
            del v18
            del v35
            v43 = <float>v30
            v44 = (<float>1.000000) / v43
            v45 = libc.math.log(v44)
            v46 = v45 + v29
            v47 = v1.v2
            v48 = US2_1(v16)
            v49 = UH0_0(v48, v8)
            del v48
            v50 = US2_1(v32)
            v51 = UH0_0(v50, v11)
            del v50
            v52 = US3_0()
            v53 = Closure13(v16, v32, v1, v34, v11, v12, v13, v8, v9, v10, v46)
            del v8; del v11; del v34
            v54 = UH3_0(v46, v46, v49, v9, v10, v51, v12, v13, v16, (<unsigned char>0), (<signed long>1), v32, (<unsigned char>1), (<signed long>1), v52, (<unsigned char>0), v47, v53)
            del v47; del v49; del v51; del v52; del v53
            v4[v7] = v54
            del v54
            v55 = v7 + (<unsigned long long>1)
            v5.v0 = v55
        del v5
        return method42(v3, v4)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef UH0 method2(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method2(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method4(UH1 v0, UH1 v1):
    cdef US0 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        return method4(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method6(UH1 v0, unsigned long long v1) except *:
    cdef US0 v2
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method6(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method7(numpy.ndarray[signed long,ndim=1] v0, UH1 v1, unsigned long long v2) except *:
    cdef US0 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        v5 = v2 + (<unsigned long long>1)
        return method7(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[signed long,ndim=1] method5(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[signed long,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method6(v0, v1)
    v3 = numpy.empty(v2,dtype=numpy.int32)
    v4 = (<unsigned long long>0)
    v5 = method7(v3, v0, v4)
    return v3
cdef UH2 method3(UH1 v0, US1 v1, UH0 v2):
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef UH1 v6
    cdef US1 v8
    cdef UH1 v9
    cdef UH1 v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef UH1 v12
    cdef UH2 v13
    cdef UH1 v16
    cdef UH1 v17
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef UH2 v19
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US2_0>v3).v0
            v6 = UH1_0(v5, v0)
            return method3(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH1_1()
            v10 = method4(v0, v9)
            del v9
            v11 = method5(v10)
            del v10
            v12 = UH1_1()
            v13 = method3(v12, v8, v4)
            del v4; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method4(v0, v16)
        del v16
        v18 = method5(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method9(UH2 v0, unsigned long long v1) except *:
    cdef US1 v2
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v4 = (<UH2_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method9(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method10(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2) except *:
    cdef US1 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v4
        v6 = v2 + (<unsigned long long>1)
        return method10(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method8(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method9(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<unsigned long long>0)
    v5 = method10(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method1(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef US1 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method2(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US2_0>v3).v0
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US2_1>v3).v0
            v8 = UH1_1()
            v9 = method3(v8, v7, v4)
            del v4; del v8
            return method8(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef unsigned long long method13(UH0 v0) except *:
    cdef US2 v1
    cdef UH0 v2
    cdef unsigned long long v35
    cdef US0 v3
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
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # action_
            v3 = (<US2_0>v1).v0
            if v3 == 0: # call
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # fold
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # raise
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # observation_
            v19 = (<US2_1>v1).v0
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
        v37 = method13(v2)
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
cdef bint method15(UH0 v0, UH0 v1) except *:
    cdef US2 v2
    cdef UH0 v3
    cdef US2 v4
    cdef UH0 v5
    cdef bint v12
    cdef US0 v6
    cdef US0 v7
    cdef US1 v9
    cdef US1 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # action_
            v6 = (<US2_0>v2).v0; v7 = (<US2_0>v4).v0
            if v6 == 0 and v7 == 0: # call
                v12 = 1
            elif v6 == 1 and v7 == 1: # fold
                v12 = 1
            elif v6 == 2 and v7 == 2: # raise
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # observation_
            v9 = (<US2_1>v2).v0; v10 = (<US2_1>v4).v0
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
            return method15(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef Mut2 method16(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut2 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut0((<unsigned long long>0))
    while method0(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut2(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method19(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut2 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple4 tmp6
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp6 = v3[v4]
        v7, v8, v9, v10, v11 = tmp6.v0, tmp6.v1, tmp6.v2, tmp6.v3, tmp6.v4
        del tmp6
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple4(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method19(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method18(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
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
        method19(v8, v2, v3, v7, v9)
        del v7
        method18(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method17(Mut1 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut0 v8
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
    v8 = Mut0((<unsigned long long>0))
    while method0(v5, v8):
        v10 = v8.v0
        v11 = [None]*(<unsigned long long>0)
        v7[v10] = v11
        del v11
        v12 = v10 + (<unsigned long long>1)
        v8.v0 = v12
    del v8
    v13 = (<unsigned long long>0)
    method18(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple5 method14(Mut1 v0, UH0 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut2 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef numpy.ndarray[float,ndim=1] v12
    cdef Tuple4 tmp5
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v16
    cdef numpy.ndarray[float,ndim=1] v23
    cdef numpy.ndarray[float,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef Mut2 v27
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
        tmp5 = v4[v5]
        v8, v9, v10, v11, v12 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4
        del tmp5
        v13 = v3 == v8
        if v13:
            v15 = method15(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple5(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method14(v0, v1, v2, v3, v4, v16)
    else:
        v23 = numpy.zeros(v2,dtype=numpy.float32)
        v24 = numpy.zeros(v2,dtype=numpy.float32)
        v25 = (<unsigned long long>3)
        v26 = (<unsigned long long>7)
        v27 = method16(v25, v26)
        v4.append(Tuple4(v3, v1, v27, v23, v24))
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
            method17(v0)
        else:
            pass
        return Tuple5(v27, v23, v24)
cdef Tuple5 method12(Mut1 v0, unsigned long long v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method13(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method14(v0, v2, v1, v4, v8, v9)
cdef bint method20(signed long long v0, Mut3 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method21(signed long long v0, Mut4 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef void method27(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef US1 v8
    cdef numpy.ndarray[float,ndim=1] v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef Tuple6 tmp10
    cdef unsigned long long v11
    cdef list v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp10 = v3[v4]
        v7, v8, v9, v10 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3
        del tmp10
        v11 = v7 % v1
        v12 = v2[v11]
        v12.append(Tuple6(v7, v8, v9, v10))
        del v9; del v10; del v12
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
cdef void method25(Mut2 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Mut0 v8
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
    v8 = Mut0((<unsigned long long>0))
    while method0(v5, v8):
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
cdef Tuple7 method24(Mut2 v0, US1 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US1 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple6 tmp9
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
        tmp9 = v4[v5]
        v8, v9, v10, v11 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3
        del tmp9
        v12 = v3 == v8
        if v12:
            if v1 == 0 and v9 == 0: # jack
                v14 = 1
            elif v1 == 1 and v9 == 1: # king
                v14 = 1
            elif v1 == 2 and v9 == 2: # queen
                v14 = 1
            else:
                v14 = 0
        else:
            v14 = 0
        if v14:
            return Tuple7(v10, v11)
        else:
            del v10; del v11
            v15 = v5 + (<unsigned long long>1)
            return method24(v0, v1, v2, v3, v4, v15)
    else:
        v20 = numpy.zeros(v2,dtype=numpy.float32)
        v21 = numpy.zeros(v2,dtype=numpy.float32)
        v4.append(Tuple6(v3, v1, v21, v20))
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
        return Tuple7(v21, v20)
cdef Tuple7 method23(Mut2 v0, unsigned long long v1, US1 v2):
    cdef unsigned long long v13
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef numpy.ndarray[object,ndim=1] v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef list v17
    cdef unsigned long long v18
    if v2 == 0: # jack
        v4 = (<signed long>0)
        v5 = (<unsigned long long>1) + v4
        v13 = (<unsigned long long>9223372036854765835) * v5
    elif v2 == 1: # king
        v7 = (<signed long>1)
        v8 = (<unsigned long long>1) + v7
        v13 = (<unsigned long long>9223372036854765835) * v8
    elif v2 == 2: # queen
        v10 = (<signed long>2)
        v11 = (<unsigned long long>1) + v10
        v13 = (<unsigned long long>9223372036854765835) * v11
    v14 = v0.v1
    v15 = len(v14)
    v16 = v13 % v15
    v17 = v14[v16]
    del v14
    v18 = (<unsigned long long>0)
    return method24(v0, v2, v1, v13, v17, v18)
cdef void method22(Mut2 v0, Mut2 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef US1 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple6 tmp8
    cdef signed long long v17
    cdef unsigned long long v18
    cdef numpy.ndarray[float,ndim=1] v19
    cdef numpy.ndarray[float,ndim=1] v20
    cdef Tuple7 tmp11
    cdef signed long long v21
    cdef Mut4 v22
    cdef signed long long v24
    cdef float v25
    cdef float v26
    cdef float v27
    cdef signed long long v28
    cdef signed long long v29
    cdef Mut4 v30
    cdef signed long long v32
    cdef float v33
    cdef float v34
    cdef float v35
    cdef signed long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp8 = v8[v12]
            v13, v14, v15, v16 = tmp8.v0, tmp8.v1, tmp8.v2, tmp8.v3
            del tmp8
            v17 = len(v16)
            v18 = <unsigned long long>v17
            tmp11 = method23(v0, v18, v14)
            v19, v20 = tmp11.v0, tmp11.v1
            del tmp11
            v21 = len(v20)
            v22 = Mut4((<signed long long>0))
            while method21(v21, v22):
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
            v30 = Mut4((<signed long long>0))
            while method21(v29, v30):
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
cdef void method11(Mut1 v0, Mut1 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH0 v14
    cdef Mut2 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple4 tmp4
    cdef signed long long v18
    cdef unsigned long long v19
    cdef Mut2 v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef numpy.ndarray[float,ndim=1] v22
    cdef Tuple5 tmp7
    cdef bint v23
    cdef float v24
    cdef Mut3 v25
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
    cdef Mut4 v40
    cdef signed long long v42
    cdef float v43
    cdef float v44
    cdef float v45
    cdef signed long long v46
    cdef signed long long v47
    cdef Mut4 v48
    cdef signed long long v50
    cdef float v51
    cdef float v52
    cdef float v53
    cdef signed long long v54
    cdef signed long long v55
    cdef Mut4 v56
    cdef signed long long v58
    cdef float v59
    cdef float v60
    cdef float v61
    cdef signed long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp4 = v8[v12]
            v13, v14, v15, v16, v17 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3, tmp4.v4
            del tmp4
            v18 = len(v16)
            v19 = <unsigned long long>v18
            tmp7 = method12(v0, v19, v14)
            v20, v21, v22 = tmp7.v0, tmp7.v1, tmp7.v2
            del tmp7
            del v14
            v23 = v18 == (<signed long long>0)
            if v23:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v24 = v16[(<signed long long>0)]
            v25 = Mut3((<signed long long>1), v24)
            while method20(v18, v25):
                v27 = v25.v0
                v28 = v25.v1
                v29 = v16[v27]
                v30 = v28 + v29
                v31 = v27 + (<signed long long>1)
                v25.v0 = v31
                v25.v1 = v30
            v32 = v25.v1
            del v25
            v33 = v32 == (<float>0.000000)
            if v33:
                v34 = <float>v18
                v35 = (<float>1.000000) / v34
                v37, v38 = v35, (<float>0.000000)
            else:
                v36 = (<float>1.000000) / v32
                v37, v38 = (<float>0.000000), v36
            v39 = numpy.empty(v18,dtype=numpy.float32)
            v40 = Mut4((<signed long long>0))
            while method21(v18, v40):
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
            v48 = Mut4((<signed long long>0))
            while method21(v47, v48):
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
            v56 = Mut4((<signed long long>0))
            while method21(v55, v56):
                v58 = v56.v0
                v59 = v22[v58]
                v60 = v17[v58]
                v61 = v59 + v60
                v22[v58] = v61
                v62 = v58 + (<signed long long>1)
                v56.v0 = v62
            del v17; del v22
            del v56
            method22(v20, v15)
            del v15; del v20
            v63 = v12 + (<unsigned long long>1)
            v10.v0 = v63
        del v8
        del v10
        v64 = v7 + (<unsigned long long>1)
        v5.v0 = v64
    del v3
cdef Mut1 method28(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut1 v9
    v3 = numpy.empty(v1,dtype=object)
    v4 = Mut0((<unsigned long long>0))
    while method0(v1, v4):
        v6 = v4.v0
        v7 = [None]*(<unsigned long long>0)
        v3[v6] = v7
        del v7
        v8 = v6 + (<unsigned long long>1)
        v4.v0 = v8
    del v4
    v9 = Mut1(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method30(float v0, Mut2 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef US1 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple6 tmp19
    cdef signed long long v17
    cdef Mut4 v18
    cdef signed long long v20
    cdef float v21
    cdef float v22
    cdef signed long long v23
    cdef signed long long v24
    cdef Mut4 v25
    cdef signed long long v27
    cdef float v28
    cdef float v29
    cdef signed long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp19 = v8[v12]
            v13, v14, v15, v16 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3
            del tmp19
            v17 = len(v15)
            v18 = Mut4((<signed long long>0))
            while method21(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v21 * v0
                v15[v20] = v22
                v23 = v20 + (<signed long long>1)
                v18.v0 = v23
            del v15
            del v18
            v24 = len(v16)
            v25 = Mut4((<signed long long>0))
            while method21(v24, v25):
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
cdef void method29(float v0, Mut1 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef UH0 v14
    cdef Mut2 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple4 tmp18
    cdef unsigned long long v18
    cdef unsigned long long v19
    v3 = v1.v1
    v4 = len(v3)
    v5 = Mut0((<unsigned long long>0))
    while method0(v4, v5):
        v7 = v5.v0
        v8 = v3[v7]
        v9 = len(v8)
        v10 = Mut0((<unsigned long long>0))
        while method0(v9, v10):
            v12 = v10.v0
            tmp18 = v8[v12]
            v13, v14, v15, v16, v17 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3, tmp18.v4
            del tmp18
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
cdef void method31(Mut1 v0) except *:
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut0 v9
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef UH0 v13
    cdef Mut2 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple4 tmp20
    cdef signed long long v17
    cdef Mut4 v18
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
    v4 = Mut0((<unsigned long long>0))
    while method0(v3, v4):
        v6 = v4.v0
        v7 = v2[v6]
        v8 = len(v7)
        v9 = Mut0((<unsigned long long>0))
        while method0(v8, v9):
            v11 = v9.v0
            tmp20 = v7[v11]
            v12, v13, v14, v15, v16 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3, tmp20.v4
            del tmp20
            del v13; del v14
            v17 = len(v15)
            v18 = Mut4((<signed long long>0))
            while method21(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v16[v20]
                v23 = v21 + v22
                v24 = (<float>0.000000) >= v23
                if v24:
                    v25 = (<float>0.000000)
                else:
                    v25 = v23
                v16[v20] = (<float>0.000000)
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
cdef UH3 method37(Heap0 v0, signed long v1, US1 v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
    cdef US3 v71
    cdef bint v73
    cdef signed long v75
    cdef bint v76
    cdef signed long v78
    cdef signed long v79
    cdef signed long v81
    cdef signed long v82
    cdef US1 v83
    cdef unsigned char v84
    cdef signed long v85
    cdef US1 v86
    cdef unsigned char v87
    cdef signed long v88
    cdef float v89
    cdef US3 v90
    cdef signed long v92
    cdef signed long v93
    cdef numpy.ndarray[signed long,ndim=1] v94
    cdef US3 v95
    cdef object v96
    if v9 == 0: # call
        v17 = method38(v2)
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
        v71 = US3_1(v2)
        return UH3_1(v10, v10, v11, v12, v13, v14, v15, v16, v64, v65, v66, v67, v68, v69, v71, v70)
    elif v9 == 1: # fold
        v73 = v4 == (<unsigned char>0)
        if v73:
            v75 = v8
        else:
            v75 = -v8
        v76 = v7 == (<unsigned char>0)
        if v76:
            v78 = v75
        else:
            v78 = -v75
        v79 = v78 + v8
        if v73:
            v81 = v75
        else:
            v81 = -v75
        v82 = v81 + v5
        if v76:
            v83, v84, v85, v86, v87, v88 = v6, v7, v79, v3, v4, v82
        else:
            v83, v84, v85, v86, v87, v88 = v3, v4, v82, v6, v7, v79
        v89 = <float>v75
        v90 = US3_1(v2)
        return UH3_1(v10, v10, v11, v12, v13, v14, v15, v16, v83, v84, v85, v86, v87, v88, v90, v89)
    elif v9 == 2: # raise
        v92 = v1 - (<signed long>1)
        v93 = v5 + (<signed long>4)
        v94 = method36(v0, v6, v7, v93, v3, v4, v5, v92)
        v95 = US3_1(v2)
        v96 = Closure16(v4, v0, v92, v2, v6, v7, v93, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH3_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v93, v95, v4, v94, v96)
cdef UH3 method35(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, US0 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef signed long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef US3 v18
    cdef object v19
    cdef object v21
    cdef signed long v23
    cdef signed long v24
    cdef numpy.ndarray[signed long,ndim=1] v25
    cdef US3 v26
    cdef object v27
    if v8 == 0: # call
        v16 = (<signed long>2)
        v17 = method36(v0, v4, v5, v6, v1, v2, v3, v16)
        v18 = US3_1(v7)
        v19 = Closure16(v2, v0, v16, v7, v4, v5, v6, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH3_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v18, v2, v17, v19)
    elif v8 == 1: # fold
        raise Exception("impossible 2")
    elif v8 == 2: # raise
        v23 = (<signed long>1)
        v24 = v3 + (<signed long>4)
        v25 = method36(v0, v4, v5, v24, v1, v2, v3, v23)
        v26 = US3_1(v7)
        v27 = Closure16(v2, v0, v23, v7, v4, v5, v24, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH3_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v24, v26, v2, v25, v27)
cdef UH3 method39(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, signed long v8, US0 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef bint v17
    cdef US1 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US1 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef US1 v26
    cdef float v27
    cdef float v28
    cdef float v29
    cdef float v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef US3 v36
    cdef object v37
    cdef bint v39
    cdef signed long v41
    cdef bint v42
    cdef signed long v44
    cdef signed long v45
    cdef signed long v47
    cdef signed long v48
    cdef US1 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef US1 v52
    cdef unsigned char v53
    cdef signed long v54
    cdef float v55
    cdef US3 v56
    cdef signed long v58
    cdef signed long v59
    cdef numpy.ndarray[signed long,ndim=1] v60
    cdef US3 v61
    cdef object v62
    if v9 == 0: # call
        v17 = v7 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v6, v7, v5, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23 = v3, v4, v5, v6, v7, v5
        v24 = len(v1)
        v25 = numpy.random.randint(0,v24)
        v26 = v1[v25]
        v27 = <float>v24
        v28 = (<float>1.000000) / v27
        v29 = libc.math.log(v28)
        v30 = v29 + v10
        v31 = v0.v2
        v32 = US2_1(v26)
        v33 = UH0_0(v32, v11)
        del v32
        v34 = US2_1(v26)
        v35 = UH0_0(v34, v14)
        del v34
        v36 = US3_1(v26)
        v37 = Closure15(v19, v0, v21, v22, v23, v18, v20, v26, v14, v15, v16, v11, v12, v13, v30)
        return UH3_0(v30, v30, v33, v12, v13, v35, v15, v16, v18, v19, v20, v21, v22, v23, v36, v19, v31, v37)
    elif v9 == 1: # fold
        v39 = v4 == (<unsigned char>0)
        if v39:
            v41 = v8
        else:
            v41 = -v8
        v42 = v7 == (<unsigned char>0)
        if v42:
            v44 = v41
        else:
            v44 = -v41
        v45 = v44 + v8
        if v39:
            v47 = v41
        else:
            v47 = -v41
        v48 = v47 + v5
        if v42:
            v49, v50, v51, v52, v53, v54 = v6, v7, v45, v3, v4, v48
        else:
            v49, v50, v51, v52, v53, v54 = v3, v4, v48, v6, v7, v45
        v55 = <float>v41
        v56 = US3_0()
        return UH3_1(v10, v10, v11, v12, v13, v14, v15, v16, v49, v50, v51, v52, v53, v54, v56, v55)
    elif v9 == 2: # raise
        v58 = v2 - (<signed long>1)
        v59 = v5 + (<signed long>2)
        v60 = method36(v0, v6, v7, v59, v3, v4, v5, v58)
        v61 = US3_0()
        v62 = Closure17(v4, v0, v1, v58, v6, v7, v59, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH3_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v59, v61, v4, v60, v62)
cdef UH3 method34(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US1 v3, unsigned char v4, signed long v5, US1 v6, unsigned char v7, US0 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef bint v16
    cdef US1 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US1 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef US1 v25
    cdef float v26
    cdef float v27
    cdef float v28
    cdef float v29
    cdef numpy.ndarray[signed long,ndim=1] v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef US3 v35
    cdef object v36
    cdef bint v38
    cdef signed long v40
    cdef bint v41
    cdef signed long v43
    cdef signed long v44
    cdef signed long v46
    cdef signed long v47
    cdef US1 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef US1 v51
    cdef unsigned char v52
    cdef signed long v53
    cdef float v54
    cdef US3 v55
    cdef signed long v57
    cdef signed long v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef US3 v60
    cdef object v61
    if v8 == 0: # call
        v16 = v7 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v6, v7, v5, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22 = v3, v4, v5, v6, v7, v5
        v23 = len(v1)
        v24 = numpy.random.randint(0,v23)
        v25 = v1[v24]
        v26 = <float>v23
        v27 = (<float>1.000000) / v26
        v28 = libc.math.log(v27)
        v29 = v28 + v9
        v30 = v0.v2
        v31 = US2_1(v25)
        v32 = UH0_0(v31, v10)
        del v31
        v33 = US2_1(v25)
        v34 = UH0_0(v33, v13)
        del v33
        v35 = US3_1(v25)
        v36 = Closure15(v18, v0, v20, v21, v22, v17, v19, v25, v13, v14, v15, v10, v11, v12, v29)
        return UH3_0(v29, v29, v32, v11, v12, v34, v14, v15, v17, v18, v19, v20, v21, v22, v35, v18, v30, v36)
    elif v8 == 1: # fold
        v38 = v4 == (<unsigned char>0)
        if v38:
            v40 = v5
        else:
            v40 = -v5
        v41 = v7 == (<unsigned char>0)
        if v41:
            v43 = v40
        else:
            v43 = -v40
        v44 = v43 + v5
        if v38:
            v46 = v40
        else:
            v46 = -v40
        v47 = v46 + v5
        if v41:
            v48, v49, v50, v51, v52, v53 = v6, v7, v44, v3, v4, v47
        else:
            v48, v49, v50, v51, v52, v53 = v3, v4, v47, v6, v7, v44
        v54 = <float>v40
        v55 = US3_0()
        return UH3_1(v9, v9, v10, v11, v12, v13, v14, v15, v48, v49, v50, v51, v52, v53, v55, v54)
    elif v8 == 2: # raise
        v57 = v2 - (<signed long>1)
        v58 = v5 + (<signed long>2)
        v59 = method36(v0, v6, v7, v58, v3, v4, v5, v57)
        v60 = US3_0()
        v61 = Closure17(v4, v0, v1, v57, v6, v7, v58, v3, v5, v13, v14, v15, v10, v11, v12, v9)
        return UH3_0(v9, v9, v10, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v58, v60, v4, v59, v61)
cdef UH3 method32(US1 v0, US1 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, US0 v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
    cdef signed long v12
    cdef unsigned char v13
    cdef signed long v14
    cdef unsigned char v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef US3 v17
    cdef object v18
    cdef object v20
    cdef signed long v22
    cdef unsigned char v23
    cdef signed long v24
    cdef unsigned char v25
    cdef signed long v26
    cdef numpy.ndarray[signed long,ndim=1] v27
    cdef US3 v28
    cdef object v29
    if v4 == 0: # call
        v12 = (<signed long>2)
        v13 = (<unsigned char>1)
        v14 = (<signed long>1)
        v15 = (<unsigned char>0)
        v16 = method33(v2, v0, v15, v14, v1, v13, v12)
        v17 = US3_0()
        v18 = Closure14(v13, v2, v3, v12, v0, v15, v14, v1, v9, v10, v11, v6, v7, v8, v5)
        return UH3_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v13, v14, v0, v15, v14, v17, v13, v16, v18)
    elif v4 == 1: # fold
        raise Exception("impossible 1")
    elif v4 == 2: # raise
        v22 = (<signed long>1)
        v23 = (<unsigned char>1)
        v24 = (<signed long>1)
        v25 = (<unsigned char>0)
        v26 = (<signed long>3)
        v27 = method36(v2, v0, v25, v26, v1, v23, v24, v22)
        v28 = US3_0()
        v29 = Closure17(v23, v2, v3, v22, v0, v25, v26, v1, v24, v9, v10, v11, v6, v7, v8, v5)
        return UH3_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v23, v24, v0, v25, v26, v28, v23, v27, v29)
cdef bint method41(unsigned long long v0, Mut5 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef numpy.ndarray[float,ndim=1] method40(v0, v1, numpy.ndarray[object,ndim=1] v2):
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
    cdef UH3 v14
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
    cdef US3 v29
    cdef unsigned char v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef object v32
    cdef bint v33
    cdef float v34
    cdef float v35
    cdef UH0 v36
    cdef float v37
    cdef float v38
    cdef UH0 v39
    cdef float v40
    cdef float v41
    cdef US1 v42
    cdef unsigned char v43
    cdef signed long v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US3 v48
    cdef float v49
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef list v136
    cdef numpy.ndarray[object,ndim=1] v53
    cdef object v54
    cdef Tuple3 tmp22
    cdef numpy.ndarray[object,ndim=1] v55
    cdef object v56
    cdef Tuple3 tmp23
    cdef unsigned long long v57
    cdef unsigned long long v58
    cdef bint v59
    cdef bint v60
    cdef numpy.ndarray[object,ndim=1] v61
    cdef Mut0 v62
    cdef unsigned long long v64
    cdef object v65
    cdef float v66
    cdef float v67
    cdef US0 v68
    cdef Tuple2 tmp24
    cdef UH3 v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef bint v73
    cdef bint v74
    cdef numpy.ndarray[object,ndim=1] v75
    cdef Mut0 v76
    cdef unsigned long long v78
    cdef object v79
    cdef float v80
    cdef float v81
    cdef US0 v82
    cdef Tuple2 tmp25
    cdef UH3 v83
    cdef unsigned long long v84
    cdef unsigned long long v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef numpy.ndarray[object,ndim=1] v88
    cdef Mut0 v89
    cdef unsigned long long v91
    cdef bint v92
    cdef UH3 v96
    cdef unsigned long long v94
    cdef unsigned long long v97
    cdef numpy.ndarray[float,ndim=1] v98
    cdef numpy.ndarray[float,ndim=1] v99
    cdef Mut0 v100
    cdef unsigned long long v102
    cdef float v103
    cdef unsigned long long v104
    cdef numpy.ndarray[float,ndim=1] v105
    cdef unsigned long long v106
    cdef unsigned long long v107
    cdef numpy.ndarray[float,ndim=1] v108
    cdef Mut0 v109
    cdef unsigned long long v111
    cdef unsigned long long v112
    cdef float v113
    cdef unsigned long long v114
    cdef numpy.ndarray[float,ndim=1] v115
    cdef unsigned long long v116
    cdef list v117
    cdef Mut5 v118
    cdef unsigned long long v120
    cdef unsigned long long v121
    cdef unsigned long long v122
    cdef unsigned char v123
    cdef bint v124
    cdef float v129
    cdef unsigned long long v130
    cdef unsigned long long v131
    cdef float v125
    cdef unsigned long long v126
    cdef float v127
    cdef unsigned long long v128
    cdef unsigned long long v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef numpy.ndarray[float,ndim=1] v137
    cdef unsigned long long v138
    cdef unsigned long long v139
    cdef bint v140
    cdef bint v141
    cdef Mut0 v142
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef float v146
    cdef unsigned long long v147
    cdef unsigned long long v148
    cdef Mut0 v149
    cdef unsigned long long v151
    cdef unsigned long long v152
    cdef float v153
    cdef float v154
    cdef UH0 v155
    cdef float v156
    cdef float v157
    cdef UH0 v158
    cdef float v159
    cdef float v160
    cdef US1 v161
    cdef unsigned char v162
    cdef signed long v163
    cdef US1 v164
    cdef unsigned char v165
    cdef signed long v166
    cdef US3 v167
    cdef float v168
    cdef Tuple9 tmp26
    cdef unsigned long long v169
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
            v15 = (<UH3_0>v14).v0; v16 = (<UH3_0>v14).v1; v17 = (<UH3_0>v14).v2; v18 = (<UH3_0>v14).v3; v19 = (<UH3_0>v14).v4; v20 = (<UH3_0>v14).v5; v21 = (<UH3_0>v14).v6; v22 = (<UH3_0>v14).v7; v23 = (<UH3_0>v14).v8; v24 = (<UH3_0>v14).v9; v25 = (<UH3_0>v14).v10; v26 = (<UH3_0>v14).v11; v27 = (<UH3_0>v14).v12; v28 = (<UH3_0>v14).v13; v29 = (<UH3_0>v14).v14; v30 = (<UH3_0>v14).v15; v31 = (<UH3_0>v14).v16; v32 = (<UH3_0>v14).v17
            v4.append(v13)
            v33 = v30 == (<unsigned char>0)
            if v33:
                v5.append(Tuple0(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
                v7.append(v32)
            else:
                v6.append(Tuple0(v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31))
                v8.append(v32)
            del v17; del v20; del v29; del v31; del v32
            v9.append(v30)
        elif v14.tag == 1: # terminal_
            v34 = (<UH3_1>v14).v0; v35 = (<UH3_1>v14).v1; v36 = (<UH3_1>v14).v2; v37 = (<UH3_1>v14).v3; v38 = (<UH3_1>v14).v4; v39 = (<UH3_1>v14).v5; v40 = (<UH3_1>v14).v6; v41 = (<UH3_1>v14).v7; v42 = (<UH3_1>v14).v8; v43 = (<UH3_1>v14).v9; v44 = (<UH3_1>v14).v10; v45 = (<UH3_1>v14).v11; v46 = (<UH3_1>v14).v12; v47 = (<UH3_1>v14).v13; v48 = (<UH3_1>v14).v14; v49 = (<UH3_1>v14).v15
            v3.append(Tuple9(v13, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49))
            del v36; del v39; del v48
        del v14
        v50 = v13 + (<unsigned long long>1)
        v11.v0 = v50
    del v11
    v51 = len(v9)
    v52 = (<unsigned long long>0) < v51
    if v52:
        tmp22 = v1(v5)
        v53, v54 = tmp22.v0, tmp22.v1
        del tmp22
        tmp23 = v0(v6)
        v55, v56 = tmp23.v0, tmp23.v1
        del tmp23
        v57 = len(v7)
        v58 = len(v53)
        v59 = v57 == v58
        v60 = v59 == 0
        if v60:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v61 = numpy.empty(v57,dtype=object)
        v62 = Mut0((<unsigned long long>0))
        while method0(v57, v62):
            v64 = v62.v0
            v65 = v7[v64]
            tmp24 = v53[v64]
            v66, v67, v68 = tmp24.v0, tmp24.v1, tmp24.v2
            del tmp24
            v69 = v65(v66, v67, v68)
            del v65
            v61[v64] = v69
            del v69
            v70 = v64 + (<unsigned long long>1)
            v62.v0 = v70
        del v53
        del v62
        v71 = len(v8)
        v72 = len(v55)
        v73 = v71 == v72
        v74 = v73 == 0
        if v74:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v75 = numpy.empty(v71,dtype=object)
        v76 = Mut0((<unsigned long long>0))
        while method0(v71, v76):
            v78 = v76.v0
            v79 = v8[v78]
            tmp25 = v55[v78]
            v80, v81, v82 = tmp25.v0, tmp25.v1, tmp25.v2
            del tmp25
            v83 = v79(v80, v81, v82)
            del v79
            v75[v78] = v83
            del v83
            v84 = v78 + (<unsigned long long>1)
            v76.v0 = v84
        del v55
        del v76
        v85 = len(v61)
        v86 = len(v75)
        v87 = v85 + v86
        v88 = numpy.empty(v87,dtype=object)
        v89 = Mut0((<unsigned long long>0))
        while method0(v87, v89):
            v91 = v89.v0
            v92 = v91 < v85
            if v92:
                v96 = v61[v91]
            else:
                v94 = v91 - v85
                v96 = v75[v94]
            v88[v91] = v96
            del v96
            v97 = v91 + (<unsigned long long>1)
            v89.v0 = v97
        del v61; del v75
        del v89
        v98 = method40(v0, v1, v88)
        del v88
        v99 = numpy.empty(v58,dtype=numpy.float32)
        v100 = Mut0((<unsigned long long>0))
        while method0(v58, v100):
            v102 = v100.v0
            v103 = v98[v102]
            v99[v102] = v103
            v104 = v102 + (<unsigned long long>1)
            v100.v0 = v104
        del v100
        v105 = v54(v99)
        del v54; del v99
        v106 = len(v98)
        v107 = v106 - v58
        v108 = numpy.empty(v107,dtype=numpy.float32)
        v109 = Mut0((<unsigned long long>0))
        while method0(v107, v109):
            v111 = v109.v0
            v112 = v111 + v58
            v113 = v98[v112]
            v108[v111] = v113
            v114 = v111 + (<unsigned long long>1)
            v109.v0 = v114
        del v98
        del v109
        v115 = v56(v108)
        del v56; del v108
        v116 = len(v9)
        v117 = [None]*v116
        v118 = Mut5((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method41(v116, v118):
            v120 = v118.v0
            v121, v122 = v118.v1, v118.v2
            v123 = v9[v120]
            v124 = v123 == (<unsigned char>0)
            if v124:
                v125 = v105[v121]
                v126 = v121 + (<unsigned long long>1)
                v129, v130, v131 = v125, v126, v122
            else:
                v127 = v115[v122]
                v128 = v122 + (<unsigned long long>1)
                v129, v130, v131 = v127, v121, v128
            v117[v120] = v129
            v132 = v120 + (<unsigned long long>1)
            v118.v0 = v132
            v118.v1 = v130
            v118.v2 = v131
        del v105; del v115
        v133, v134 = v118.v1, v118.v2
        del v118
        v136 = v117
        del v117
    else:
        v136 = [None]*(<unsigned long long>0)
    del v5; del v6; del v7; del v8; del v9
    v137 = numpy.empty(v10,dtype=numpy.float32)
    v138 = len(v4)
    v139 = len(v136)
    v140 = v138 == v139
    v141 = v140 == 0
    if v141:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v142 = Mut0((<unsigned long long>0))
    while method0(v138, v142):
        v144 = v142.v0
        v145 = v4[v144]
        v146 = v136[v144]
        v137[v145] = v146
        v147 = v144 + (<unsigned long long>1)
        v142.v0 = v147
    del v4; del v136
    del v142
    v148 = len(v3)
    v149 = Mut0((<unsigned long long>0))
    while method0(v148, v149):
        v151 = v149.v0
        tmp26 = v3[v151]
        v152, v153, v154, v155, v156, v157, v158, v159, v160, v161, v162, v163, v164, v165, v166, v167, v168 = tmp26.v0, tmp26.v1, tmp26.v2, tmp26.v3, tmp26.v4, tmp26.v5, tmp26.v6, tmp26.v7, tmp26.v8, tmp26.v9, tmp26.v10, tmp26.v11, tmp26.v12, tmp26.v13, tmp26.v14, tmp26.v15, tmp26.v16
        del tmp26
        del v155; del v158; del v167
        v137[v152] = v168
        v169 = v151 + (<unsigned long long>1)
        v149.v0 = v169
    del v3
    del v149
    return v137
cdef numpy.ndarray[float,ndim=1] method42(v0, numpy.ndarray[object,ndim=1] v1):
    cdef list v2
    cdef list v3
    cdef list v4
    cdef list v5
    cdef unsigned long long v6
    cdef Mut0 v7
    cdef unsigned long long v9
    cdef UH3 v10
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
    cdef US3 v25
    cdef unsigned char v26
    cdef numpy.ndarray[signed long,ndim=1] v27
    cdef object v28
    cdef float v29
    cdef float v30
    cdef UH0 v31
    cdef float v32
    cdef float v33
    cdef UH0 v34
    cdef float v35
    cdef float v36
    cdef US1 v37
    cdef unsigned char v38
    cdef signed long v39
    cdef US1 v40
    cdef unsigned char v41
    cdef signed long v42
    cdef US3 v43
    cdef float v44
    cdef unsigned long long v45
    cdef unsigned long long v46
    cdef bint v47
    cdef numpy.ndarray[float,ndim=1] v67
    cdef numpy.ndarray[object,ndim=1] v48
    cdef object v49
    cdef Tuple3 tmp27
    cdef unsigned long long v50
    cdef unsigned long long v51
    cdef bint v52
    cdef bint v53
    cdef numpy.ndarray[object,ndim=1] v54
    cdef Mut0 v55
    cdef unsigned long long v57
    cdef object v58
    cdef float v59
    cdef float v60
    cdef US0 v61
    cdef Tuple2 tmp28
    cdef UH3 v62
    cdef unsigned long long v63
    cdef numpy.ndarray[float,ndim=1] v64
    cdef numpy.ndarray[float,ndim=1] v66
    cdef numpy.ndarray[float,ndim=1] v68
    cdef unsigned long long v69
    cdef unsigned long long v70
    cdef bint v71
    cdef bint v72
    cdef Mut0 v73
    cdef unsigned long long v75
    cdef unsigned long long v76
    cdef float v77
    cdef unsigned long long v78
    cdef unsigned long long v79
    cdef Mut0 v80
    cdef unsigned long long v82
    cdef unsigned long long v83
    cdef float v84
    cdef float v85
    cdef UH0 v86
    cdef float v87
    cdef float v88
    cdef UH0 v89
    cdef float v90
    cdef float v91
    cdef US1 v92
    cdef unsigned char v93
    cdef signed long v94
    cdef US1 v95
    cdef unsigned char v96
    cdef signed long v97
    cdef US3 v98
    cdef float v99
    cdef Tuple9 tmp29
    cdef unsigned long long v100
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
            v11 = (<UH3_0>v10).v0; v12 = (<UH3_0>v10).v1; v13 = (<UH3_0>v10).v2; v14 = (<UH3_0>v10).v3; v15 = (<UH3_0>v10).v4; v16 = (<UH3_0>v10).v5; v17 = (<UH3_0>v10).v6; v18 = (<UH3_0>v10).v7; v19 = (<UH3_0>v10).v8; v20 = (<UH3_0>v10).v9; v21 = (<UH3_0>v10).v10; v22 = (<UH3_0>v10).v11; v23 = (<UH3_0>v10).v12; v24 = (<UH3_0>v10).v13; v25 = (<UH3_0>v10).v14; v26 = (<UH3_0>v10).v15; v27 = (<UH3_0>v10).v16; v28 = (<UH3_0>v10).v17
            v3.append(v9)
            v4.append(Tuple0(v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27))
            del v13; del v16; del v25; del v27
            v5.append(v28)
            del v28
        elif v10.tag == 1: # terminal_
            v29 = (<UH3_1>v10).v0; v30 = (<UH3_1>v10).v1; v31 = (<UH3_1>v10).v2; v32 = (<UH3_1>v10).v3; v33 = (<UH3_1>v10).v4; v34 = (<UH3_1>v10).v5; v35 = (<UH3_1>v10).v6; v36 = (<UH3_1>v10).v7; v37 = (<UH3_1>v10).v8; v38 = (<UH3_1>v10).v9; v39 = (<UH3_1>v10).v10; v40 = (<UH3_1>v10).v11; v41 = (<UH3_1>v10).v12; v42 = (<UH3_1>v10).v13; v43 = (<UH3_1>v10).v14; v44 = (<UH3_1>v10).v15
            v2.append(Tuple9(v9, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44))
            del v31; del v34; del v43
        del v10
        v45 = v9 + (<unsigned long long>1)
        v7.v0 = v45
    del v7
    v46 = len(v4)
    v47 = (<unsigned long long>0) < v46
    if v47:
        tmp27 = v0(v4)
        v48, v49 = tmp27.v0, tmp27.v1
        del tmp27
        v50 = len(v5)
        v51 = len(v48)
        v52 = v50 == v51
        v53 = v52 == 0
        if v53:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v54 = numpy.empty(v50,dtype=object)
        v55 = Mut0((<unsigned long long>0))
        while method0(v50, v55):
            v57 = v55.v0
            v58 = v5[v57]
            tmp28 = v48[v57]
            v59, v60, v61 = tmp28.v0, tmp28.v1, tmp28.v2
            del tmp28
            v62 = v58(v59, v60, v61)
            del v58
            v54[v57] = v62
            del v62
            v63 = v57 + (<unsigned long long>1)
            v55.v0 = v63
        del v48
        del v55
        v64 = method42(v0, v54)
        del v54
        v67 = v49(v64)
        del v49; del v64
    else:
        v66 = numpy.empty((<unsigned long long>0),dtype=numpy.float32)
        v67 = v66
        del v66
    del v4; del v5
    v68 = numpy.empty(v6,dtype=numpy.float32)
    v69 = len(v3)
    v70 = len(v67)
    v71 = v69 == v70
    v72 = v71 == 0
    if v72:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v73 = Mut0((<unsigned long long>0))
    while method0(v69, v73):
        v75 = v73.v0
        v76 = v3[v75]
        v77 = v67[v75]
        v68[v76] = v77
        v78 = v75 + (<unsigned long long>1)
        v73.v0 = v78
    del v3; del v67
    del v73
    v79 = len(v2)
    v80 = Mut0((<unsigned long long>0))
    while method0(v79, v80):
        v82 = v80.v0
        tmp29 = v2[v82]
        v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99 = tmp29.v0, tmp29.v1, tmp29.v2, tmp29.v3, tmp29.v4, tmp29.v5, tmp29.v6, tmp29.v7, tmp29.v8, tmp29.v9, tmp29.v10, tmp29.v11, tmp29.v12, tmp29.v13, tmp29.v14, tmp29.v15, tmp29.v16
        del tmp29
        del v86; del v89; del v98
        v68[v83] = v99
        v100 = v82 + (<unsigned long long>1)
        v80.v0 = v100
    del v2
    del v80
    return v68
cpdef object main():
    cdef US0 v0
    cdef US0 v1
    cdef numpy.ndarray[signed long,ndim=1] v2
    cdef US0 v3
    cdef US0 v4
    cdef US0 v5
    cdef numpy.ndarray[signed long,ndim=1] v6
    cdef US0 v7
    cdef US0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef US0 v10
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef Heap0 v12
    cdef US1 v13
    cdef US1 v14
    cdef US1 v15
    cdef US1 v16
    cdef US1 v17
    cdef US1 v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef US0 v20
    cdef US0 v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef US0 v23
    cdef US0 v24
    cdef US0 v25
    cdef numpy.ndarray[signed long,ndim=1] v26
    cdef US0 v27
    cdef US0 v28
    cdef numpy.ndarray[signed long,ndim=1] v29
    cdef US0 v30
    cdef numpy.ndarray[signed long,ndim=1] v31
    cdef Heap0 v32
    cdef US1 v33
    cdef US1 v34
    cdef US1 v35
    cdef US1 v36
    cdef US1 v37
    cdef US1 v38
    cdef numpy.ndarray[signed long,ndim=1] v39
    cdef object v40
    cdef object v41
    cdef object v42
    cdef object v43
    cdef object v44
    cdef object v45
    cdef object v46
    cdef object v47
    cdef object v48
    cdef object v49
    cdef object v50
    cdef object v51
    v0 = 0
    v1 = 2
    v2 = numpy.empty(2,dtype=numpy.int32)
    v2[0] = v0; v2[1] = v1
    v3 = 1
    v4 = 0
    v5 = 2
    v6 = numpy.empty(3,dtype=numpy.int32)
    v6[0] = v3; v6[1] = v4; v6[2] = v5
    v7 = 1
    v8 = 0
    v9 = numpy.empty(2,dtype=numpy.int32)
    v9[0] = v7; v9[1] = v8
    v10 = 0
    v11 = numpy.empty(1,dtype=numpy.int32)
    v11[0] = v10
    v12 = Heap0(v11, v6, v2, v9)
    del v2; del v6; del v9; del v11
    v13 = 1
    v14 = 2
    v15 = 0
    v16 = 1
    v17 = 2
    v18 = 0
    v19 = numpy.empty(6,dtype=numpy.int32)
    v19[0] = v13; v19[1] = v14; v19[2] = v15; v19[3] = v16; v19[4] = v17; v19[5] = v18
    v20 = 0
    v21 = 2
    v22 = numpy.empty(2,dtype=numpy.int32)
    v22[0] = v20; v22[1] = v21
    v23 = 1
    v24 = 0
    v25 = 2
    v26 = numpy.empty(3,dtype=numpy.int32)
    v26[0] = v23; v26[1] = v24; v26[2] = v25
    v27 = 1
    v28 = 0
    v29 = numpy.empty(2,dtype=numpy.int32)
    v29[0] = v27; v29[1] = v28
    v30 = 0
    v31 = numpy.empty(1,dtype=numpy.int32)
    v31[0] = v30
    v32 = Heap0(v31, v26, v22, v29)
    del v22; del v26; del v29; del v31
    v33 = 1
    v34 = 2
    v35 = 0
    v36 = 1
    v37 = 2
    v38 = 0
    v39 = numpy.empty(6,dtype=numpy.int32)
    v39[0] = v33; v39[1] = v34; v39[2] = v35; v39[3] = v36; v39[4] = v37; v39[5] = v38
    v40 = collections.namedtuple("Size",['action', 'policy', 'value'])((<signed long long>3), (<unsigned long long>30), (<unsigned long long>33))
    v41 = Closure0()
    v42 = collections.namedtuple("Neural",['handler', 'size'])(v41, v40)
    del v40; del v41
    v43 = Closure3()
    v44 = Closure4()
    v45 = Closure5()
    v46 = Closure8()
    v47 = Closure9()
    v48 = collections.namedtuple("Tabular",['average', 'create_agent', 'create_policy', 'head_multiply_', 'optimize'])(v43, v44, v45, v46, v47)
    del v43; del v44; del v45; del v46; del v47
    v49 = Closure10()
    v50 = Closure12(v39, v32)
    del v32; del v39
    v51 = Closure18(v19, v12)
    del v12; del v19
    return {'neural': v42, 'tabular': v48, 'uniform_player': v49, 'vs_one': v50, 'vs_self': v51}
