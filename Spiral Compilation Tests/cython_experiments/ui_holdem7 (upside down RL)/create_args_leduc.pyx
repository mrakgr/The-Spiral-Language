import collections
import numpy
cimport numpy
import torch
cimport libc.math
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, numpy.ndarray[float,ndim=1] v0, numpy.ndarray[float,ndim=1] v1):
        return Tuple0(v0, v1)
cdef class Tuple1:
    cdef readonly object v0
    cdef readonly object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
cdef class Mut0:
    cdef public unsigned long long v0
    def __init__(self, unsigned long long v0): self.v0 = v0
ctypedef signed long US1
ctypedef signed long US2
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # action_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # observation_
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
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 1; self.v0 = v0
cdef class Tuple2:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly US2 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US2 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US2 v8, unsigned char v9, signed long v10, US2 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US1 v0
    cdef readonly UH1 v1
    def __init__(self, US1 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US2 v0
    cdef readonly object v1
    cdef readonly UH2 v2
    def __init__(self, US2 v0, v1, UH2 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Tuple3:
    cdef readonly US2 v0
    cdef readonly object v1
    def __init__(self, US2 v0, v1): self.v0 = v0; self.v1 = v1
cdef class Mut1:
    cdef public signed short v0
    def __init__(self, signed short v0): self.v0 = v0
cdef class Tuple4:
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly US1 v2
    def __init__(self, float v0, float v1, US1 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure3():
    cdef list v0
    cdef unsigned long long v1
    cdef object v2
    def __init__(self, list v0, unsigned long long v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, numpy.ndarray[float,ndim=1] v3, numpy.ndarray[float,ndim=1] v4):
        cdef list v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef object v2 = self.v2
        cdef unsigned long long v5
        cdef unsigned long long v6
        cdef unsigned long long v7
        cdef unsigned long long v8
        cdef numpy.ndarray[float,ndim=1] v9
        cdef unsigned long long v10
        cdef unsigned long long v11
        cdef bint v12
        cdef bint v13
        cdef Mut0 v14
        cdef unsigned long long v16
        cdef float v17
        cdef float v18
        cdef float v19
        cdef UH0 v20
        cdef float v21
        cdef float v22
        cdef UH0 v23
        cdef float v24
        cdef float v25
        cdef US2 v26
        cdef unsigned char v27
        cdef signed long v28
        cdef US2 v29
        cdef unsigned char v30
        cdef signed long v31
        cdef US3 v32
        cdef unsigned char v33
        cdef numpy.ndarray[signed long,ndim=1] v34
        cdef Tuple2 tmp3
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
        cdef float v49
        cdef signed short v50
        cdef bint v51
        cdef US2 v52
        cdef unsigned long long v53
        cdef unsigned long long v54
        cdef unsigned long long v55
        cdef unsigned long long v56
        cdef unsigned long long v57
        cdef unsigned long long v58
        cdef unsigned long long v59
        cdef object v60
        cdef numpy.ndarray[float,ndim=1] v61
        cdef unsigned long long v62
        cdef unsigned long long v63
        cdef bint v64
        cdef bint v65
        cdef numpy.ndarray[float,ndim=1] v66
        cdef Mut0 v67
        cdef unsigned long long v69
        cdef float v70
        cdef float v71
        cdef float v72
        cdef UH0 v73
        cdef float v74
        cdef float v75
        cdef UH0 v76
        cdef float v77
        cdef float v78
        cdef US2 v79
        cdef unsigned char v80
        cdef signed long v81
        cdef US2 v82
        cdef unsigned char v83
        cdef signed long v84
        cdef US3 v85
        cdef unsigned char v86
        cdef numpy.ndarray[signed long,ndim=1] v87
        cdef Tuple2 tmp4
        cdef bint v88
        cdef float v90
        cdef float v89
        cdef unsigned long long v91
        v5 = (<unsigned long long>2) * v1
        v6 = <unsigned long long>(<signed short>3)
        v7 = v1 * v6
        v8 = v5 + v7
        v9 = numpy.empty(v8,dtype=numpy.float32)
        v10 = len(v3)
        v11 = len(v0)
        v12 = v10 == v11
        v13 = v12 == 0
        if v13:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v14 = Mut0((<unsigned long long>0))
        while method0(v10, v14):
            v16 = v14.v0
            v17 = v3[v16]
            tmp3 = v0[v16]
            v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4, tmp3.v5, tmp3.v6, tmp3.v7, tmp3.v8, tmp3.v9, tmp3.v10, tmp3.v11, tmp3.v12, tmp3.v13, tmp3.v14, tmp3.v15, tmp3.v16
            del tmp3
            del v20; del v23; del v32; del v34
            v35 = v33 == (<unsigned char>0)
            if v35:
                v37 = v17
            else:
                v37 = -v17
            v9[v16] = v37
            if v35:
                v38, v39, v40, v41 = v21, v22, v24, v25
            else:
                v38, v39, v40, v41 = v24, v25, v21, v22
            v42 = v19 + v41
            v43 = v18 + v40
            v44 = -v39
            v45 = v43 - v42
            v46 = v44 + v45
            v47 = libc.math.exp(v46)
            v48 = v1 + v16
            v9[v48] = v47
            v49 = v4[v16]
            v50 = round(v49)
            v51 = v27 == v33
            if v51:
                v52 = v29
            else:
                v52 = v26
            v53 = <unsigned long long>(<signed short>3)
            v54 = v53 * v16
            v55 = v5 + v54
            method12(v50, v9, v55)
            v56 = v55 + (<unsigned long long>9)
            if v52 == 0: # jack
                v9[v56] = (<float>1)
            elif v52 == 1: # king
                v57 = v56 + (<unsigned long long>1)
                v9[v57] = (<float>1)
            elif v52 == 2: # queen
                v58 = v56 + (<unsigned long long>2)
                v9[v58] = (<float>1)
            v59 = v16 + (<unsigned long long>1)
            v14.v0 = v59
        del v14
        v60 = torch.from_numpy(v9)
        del v9
        v61 = v2(v60)
        del v60
        v62 = len(v61)
        v63 = len(v0)
        v64 = v62 == v63
        v65 = v64 == 0
        if v65:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v66 = numpy.empty(v62,dtype=numpy.float32)
        v67 = Mut0((<unsigned long long>0))
        while method0(v62, v67):
            v69 = v67.v0
            v70 = v61[v69]
            tmp4 = v0[v69]
            v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3, tmp4.v4, tmp4.v5, tmp4.v6, tmp4.v7, tmp4.v8, tmp4.v9, tmp4.v10, tmp4.v11, tmp4.v12, tmp4.v13, tmp4.v14, tmp4.v15, tmp4.v16
            del tmp4
            del v73; del v76; del v85; del v87
            v88 = v86 == (<unsigned char>0)
            if v88:
                v90 = v70
            else:
                v89 = -v70
                v90 = v89
            v66[v69] = v90
            v91 = v69 + (<unsigned long long>1)
            v67.v0 = v91
        del v61
        del v67
        return Tuple0(v66, v4)
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
        cdef US2 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US2 v24
        cdef unsigned char v25
        cdef signed long v26
        cdef US3 v27
        cdef unsigned char v28
        cdef numpy.ndarray[signed long,ndim=1] v29
        cdef Tuple2 tmp0
        cdef bint v30
        cdef UH0 v31
        cdef numpy.ndarray[object,ndim=1] v32
        cdef numpy.ndarray[float,ndim=1] v33
        cdef unsigned long long v34
        cdef bint v35
        cdef bint v36
        cdef Mut0 v37
        cdef unsigned long long v39
        cdef US2 v40
        cdef numpy.ndarray[signed long,ndim=1] v41
        cdef Tuple3 tmp1
        cdef unsigned long long v42
        cdef unsigned long long v43
        cdef unsigned long long v44
        cdef unsigned long long v45
        cdef unsigned long long v46
        cdef unsigned long long v47
        cdef bint v48
        cdef bint v49
        cdef unsigned long long v50
        cdef Mut0 v51
        cdef unsigned long long v53
        cdef US1 v54
        cdef unsigned long long v55
        cdef unsigned long long v56
        cdef unsigned long long v57
        cdef unsigned long long v58
        cdef unsigned long long v59
        cdef unsigned long long v60
        cdef signed short v61
        cdef unsigned long long tmp2
        cdef Mut1 v62
        cdef signed short v64
        cdef US1 v65
        cdef signed short v66
        cdef signed short v67
        cdef unsigned long long v68
        cdef object v69
        cdef object v70
        cdef object v71
        cdef object v72
        cdef numpy.ndarray[float,ndim=2] v73
        cdef numpy.ndarray[float,ndim=2] v74
        cdef numpy.ndarray[signed long long,ndim=1] v75
        cdef object v76
        cdef numpy.ndarray[object,ndim=1] v77
        cdef Mut0 v78
        cdef unsigned long long v80
        cdef signed long long v81
        cdef float v82
        cdef float v83
        cdef float v84
        cdef float v85
        cdef signed short v86
        cdef bint v87
        cdef US1 v104
        cdef bint v88
        cdef bint v89
        cdef bint v91
        cdef signed short v92
        cdef bint v93
        cdef bint v94
        cdef bint v96
        cdef signed short v97
        cdef bint v98
        cdef bint v99
        cdef unsigned long long v105
        cdef object v106
        v2 = len(v1)
        v3 = v2 == (<unsigned long long>0)
        if v3:
            v4 = numpy.empty((<unsigned long long>0),dtype=object)
            v5 = Closure2()
            return Tuple1(v4, v5)
        else:
            pass # import torch
            v6 = len(v1)
            v7 = numpy.zeros((v6,(<unsigned long long>33)),dtype=numpy.float32)
            v8 = numpy.ones((v6,(<signed short>3)),dtype=numpy.int8)
            v9 = len(v1)
            v10 = Mut0((<unsigned long long>0))
            while method0(v9, v10):
                v12 = v10.v0
                tmp0 = v1[v12]
                v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16
                del tmp0
                del v27
                v30 = v28 == (<unsigned char>0)
                if v30:
                    v31 = v15
                else:
                    v31 = v18
                del v15; del v18
                v32 = method1(v31)
                del v31
                v33 = v7[v12,:]
                v34 = len(v32)
                v35 = (<unsigned long long>2) < v34
                if v35:
                    raise Exception("Pickle failure. The given array is too large.")
                else:
                    pass
                v36 = v34 == (<unsigned long long>0)
                if v36:
                    v33[(<unsigned long long>0)] = (<float>1)
                else:
                    pass
                v37 = Mut0((<unsigned long long>0))
                while method0(v34, v37):
                    v39 = v37.v0
                    tmp1 = v32[v39]
                    v40, v41 = tmp1.v0, tmp1.v1
                    del tmp1
                    v42 = v39 * (<unsigned long long>16)
                    v43 = (<unsigned long long>1) + v42
                    if v40 == 0: # jack
                        v33[v43] = (<float>1)
                    elif v40 == 1: # king
                        v44 = v43 + (<unsigned long long>1)
                        v33[v44] = (<float>1)
                    elif v40 == 2: # queen
                        v45 = v43 + (<unsigned long long>2)
                        v33[v45] = (<float>1)
                    v46 = v43 + (<unsigned long long>3)
                    v47 = len(v41)
                    v48 = (<unsigned long long>4) < v47
                    if v48:
                        raise Exception("Pickle failure. The given array is too large.")
                    else:
                        pass
                    v49 = v47 == (<unsigned long long>0)
                    if v49:
                        v33[v46] = (<float>1)
                    else:
                        pass
                    v50 = v46 + (<unsigned long long>1)
                    v51 = Mut0((<unsigned long long>0))
                    while method0(v47, v51):
                        v53 = v51.v0
                        v54 = v41[v53]
                        v55 = v53 * (<unsigned long long>3)
                        v56 = v50 + v55
                        if v54 == 0: # call
                            v33[v56] = (<float>1)
                        elif v54 == 1: # fold
                            v57 = v56 + (<unsigned long long>1)
                            v33[v57] = (<float>1)
                        elif v54 == 2: # raise
                            v58 = v56 + (<unsigned long long>2)
                            v33[v58] = (<float>1)
                        v59 = v53 + (<unsigned long long>1)
                        v51.v0 = v59
                    del v41
                    del v51
                    v60 = v39 + (<unsigned long long>1)
                    v37.v0 = v60
                del v32; del v33
                del v37
                tmp2 = len(v29)
                if <signed short>tmp2 != tmp2: raise Exception("The conversion to signed short failed.")
                v61 = <signed short>tmp2
                v62 = Mut1((<signed short>0))
                while method11(v61, v62):
                    v64 = v62.v0
                    v65 = v29[v64]
                    if v65 == 0: # call
                        v66 = (<signed short>0)
                    elif v65 == 1: # fold
                        v66 = (<signed short>1)
                    elif v65 == 2: # raise
                        v66 = (<signed short>2)
                    v8[v12,v66] = 0
                    v67 = v64 + (<signed short>1)
                    v62.v0 = v67
                del v29
                del v62
                v68 = v12 + (<unsigned long long>1)
                v10.v0 = v68
            del v10
            v69 = torch.from_numpy(v7)
            del v7
            v70 = v8.view('bool')
            del v8
            v71 = torch.from_numpy(v70)
            del v70
            v72 = v0(v69, v71)
            del v69; del v71
            v73 = v72[0]
            v74 = v72[1]
            v75 = v72[2]
            v76 = v72[3]
            del v72
            v77 = numpy.empty(v6,dtype=object)
            v78 = Mut0((<unsigned long long>0))
            while method0(v6, v78):
                v80 = v78.v0
                v81 = v75[v80]
                v82 = v73[v80,v81]
                v83 = v74[v80,v81]
                v84 = libc.math.log(v83)
                v85 = libc.math.log(v82)
                v86 = <signed short>v81
                v87 = v86 < (<signed short>1)
                if v87:
                    v88 = v86 == (<signed short>0)
                    v89 = v88 == 0
                    if v89:
                        raise Exception("The unit index should be 0.")
                    else:
                        pass
                    v104 = 0
                else:
                    v91 = v86 < (<signed short>2)
                    if v91:
                        v92 = v86 - (<signed short>1)
                        v93 = v92 == (<signed short>0)
                        v94 = v93 == 0
                        if v94:
                            raise Exception("The unit index should be 0.")
                        else:
                            pass
                        v104 = 1
                    else:
                        v96 = v86 < (<signed short>3)
                        if v96:
                            v97 = v86 - (<signed short>2)
                            v98 = v97 == (<signed short>0)
                            v99 = v98 == 0
                            if v99:
                                raise Exception("The unit index should be 0.")
                            else:
                                pass
                            v104 = 2
                        else:
                            raise Exception("Unpickle failure. Unpickling of an union failed.")
                v77[v80] = Tuple4(v85, v84, v104)
                v105 = v80 + (<unsigned long long>1)
                v78.v0 = v105
            del v73; del v74; del v75
            del v78
            v106 = Closure3(v1, v6, v76)
            del v76
            return Tuple1(v77, v106)
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, v0):
        return Closure1(v0)
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut3:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple5:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut3 v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, Mut3 v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple6:
    cdef readonly Mut3 v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, Mut3 v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut4:
    cdef public signed long long v0
    cdef public float v1
    def __init__(self, signed long long v0, float v1): self.v0 = v0; self.v1 = v1
cdef class Mut5:
    cdef public signed long long v0
    def __init__(self, signed long long v0): self.v0 = v0
cdef class Tuple7:
    cdef readonly unsigned long long v0
    cdef readonly US2 v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, unsigned long long v0, US2 v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, Mut2 v0, Mut2 v1):
        method14(v0, v1)
cdef class Closure5():
    def __init__(self): pass
    def __call__(self):
        cdef unsigned long long v0
        cdef unsigned long long v1
        v0 = (<unsigned long long>3)
        v1 = (<unsigned long long>7)
        return method31(v0, v1)
cdef class Tuple8:
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
    def __call__(self, numpy.ndarray[float,ndim=1] v8, numpy.ndarray[float,ndim=1] v9):
        cdef bint v0 = self.v0
        cdef bint v1 = self.v1
        cdef numpy.ndarray[float,ndim=1] v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[signed long long,ndim=1] v6 = self.v6
        cdef numpy.ndarray[unsigned char,ndim=1] v7 = self.v7
        cdef unsigned long long v10
        cdef unsigned long long v11
        cdef bint v12
        cdef bint v13
        cdef numpy.ndarray[float,ndim=1] v14
        cdef Mut0 v15
        cdef unsigned long long v17
        cdef float v18
        cdef unsigned char v19
        cdef bint v20
        cdef float v22
        cdef unsigned long long v23
        cdef unsigned long long v24
        cdef unsigned long long v25
        cdef bint v26
        cdef bint v32
        cdef unsigned long long v27
        cdef bint v28
        cdef unsigned long long v29
        cdef bint v33
        cdef numpy.ndarray[object,ndim=1] v34
        cdef Mut0 v35
        cdef unsigned long long v37
        cdef numpy.ndarray[float,ndim=1] v38
        cdef numpy.ndarray[float,ndim=1] v39
        cdef numpy.ndarray[float,ndim=1] v40
        cdef numpy.ndarray[float,ndim=1] v41
        cdef Tuple8 tmp16
        cdef signed long long v42
        cdef numpy.ndarray[float,ndim=1] v43
        cdef float v44
        cdef signed long long v45
        cdef signed long long v46
        cdef bint v47
        cdef bint v48
        cdef numpy.ndarray[float,ndim=1] v49
        cdef Mut5 v50
        cdef signed long long v52
        cdef float v53
        cdef float v54
        cdef bint v55
        cdef bint v56
        cdef float v58
        cdef bint v59
        cdef float v64
        cdef float v60
        cdef float v61
        cdef float v62
        cdef signed long long v65
        cdef unsigned long long v66
        cdef unsigned long long v67
        cdef unsigned long long v68
        cdef bint v69
        cdef bint v70
        cdef numpy.ndarray[float,ndim=1] v71
        cdef Mut0 v72
        cdef unsigned long long v74
        cdef numpy.ndarray[float,ndim=1] v75
        cdef numpy.ndarray[float,ndim=1] v76
        cdef signed long long v77
        cdef signed long long v78
        cdef bint v79
        cdef bint v80
        cdef Mut4 v81
        cdef signed long long v83
        cdef float v84
        cdef float v85
        cdef float v86
        cdef float v87
        cdef float v88
        cdef signed long long v89
        cdef float v90
        cdef unsigned long long v91
        cdef bint v97
        cdef unsigned long long v92
        cdef bint v93
        cdef unsigned long long v94
        cdef bint v98
        cdef Mut0 v99
        cdef unsigned long long v101
        cdef numpy.ndarray[float,ndim=1] v102
        cdef numpy.ndarray[float,ndim=1] v103
        cdef numpy.ndarray[float,ndim=1] v104
        cdef numpy.ndarray[float,ndim=1] v105
        cdef Tuple8 tmp17
        cdef signed long long v106
        cdef float v107
        cdef float v108
        cdef float v109
        cdef float v110
        cdef float v111
        cdef float v112
        cdef float v113
        cdef unsigned long long v114
        cdef bint v115
        cdef bint v121
        cdef unsigned long long v116
        cdef bint v117
        cdef unsigned long long v118
        cdef bint v122
        cdef Mut0 v123
        cdef unsigned long long v125
        cdef numpy.ndarray[float,ndim=1] v126
        cdef numpy.ndarray[float,ndim=1] v127
        cdef numpy.ndarray[float,ndim=1] v128
        cdef numpy.ndarray[float,ndim=1] v129
        cdef Tuple8 tmp18
        cdef numpy.ndarray[float,ndim=1] v130
        cdef float v131
        cdef float v132
        cdef signed long long v133
        cdef Mut5 v134
        cdef signed long long v136
        cdef float v137
        cdef float v138
        cdef float v139
        cdef float v140
        cdef float v141
        cdef signed long long v142
        cdef unsigned long long v143
        cdef unsigned long long v144
        cdef bint v145
        cdef bint v146
        cdef numpy.ndarray[float,ndim=1] v147
        cdef Mut0 v148
        cdef unsigned long long v150
        cdef float v151
        cdef unsigned char v152
        cdef bint v153
        cdef float v155
        cdef float v154
        cdef unsigned long long v156
        v10 = len(v8)
        v11 = len(v7)
        v12 = v10 == v11
        v13 = v12 == 0
        if v13:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v14 = numpy.empty(v10,dtype=numpy.float32)
        v15 = Mut0((<unsigned long long>0))
        while method0(v10, v15):
            v17 = v15.v0
            v18 = v8[v17]
            v19 = v7[v17]
            v20 = v19 == (<unsigned char>0)
            if v20:
                v22 = v18
            else:
                v22 = -v18
            v14[v17] = v22
            v23 = v17 + (<unsigned long long>1)
            v15.v0 = v23
        del v15
        v24 = len(v3)
        v25 = len(v6)
        v26 = v24 == v25
        if v26:
            v27 = len(v5)
            v28 = v24 == v27
            if v28:
                v29 = len(v14)
                v32 = v24 == v29
            else:
                v32 = 0
        else:
            v32 = 0
        v33 = v32 == 0
        if v33:
            raise Exception("The length of the four arrays has to the same.")
        else:
            pass
        v34 = numpy.empty(v24,dtype=object)
        v35 = Mut0((<unsigned long long>0))
        while method0(v24, v35):
            v37 = v35.v0
            tmp16 = v3[v37]
            v38, v39, v40, v41 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3
            del tmp16
            del v40; del v41
            v42 = v6[v37]
            v43 = v5[v37]
            v44 = v14[v37]
            v45 = len(v39)
            v46 = len(v38)
            v47 = v45 == v46
            v48 = v47 == 0
            if v48:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v49 = numpy.empty(v45,dtype=numpy.float32)
            v50 = Mut5((<signed long long>0))
            while method24(v45, v50):
                v52 = v50.v0
                v53 = v39[v52]
                v54 = v38[v52]
                v55 = v54 == (<float>0)
                v56 = v55 != 1
                if v56:
                    v58 = v53 / v54
                else:
                    v58 = (<float>0)
                v59 = v42 == v52
                if v59:
                    v60 = v44 - v58
                    v61 = v43[v42]
                    v62 = v60 / v61
                    v64 = v62 + v58
                else:
                    v64 = v58
                v49[v52] = v64
                v65 = v52 + (<signed long long>1)
                v50.v0 = v65
            del v38; del v39; del v43
            del v50
            v34[v37] = v49
            del v49
            v66 = v37 + (<unsigned long long>1)
            v35.v0 = v66
        del v35
        v67 = len(v34)
        v68 = len(v4)
        v69 = v67 == v68
        v70 = v69 == 0
        if v70:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v71 = numpy.empty(v67,dtype=numpy.float32)
        v72 = Mut0((<unsigned long long>0))
        while method0(v67, v72):
            v74 = v72.v0
            v75 = v34[v74]
            v76 = v4[v74]
            v77 = len(v75)
            v78 = len(v76)
            v79 = v77 == v78
            v80 = v79 == 0
            if v80:
                raise Exception("The length of the two arrays has to the same.")
            else:
                pass
            v81 = Mut4((<signed long long>0), (<float>0))
            while method23(v77, v81):
                v83 = v81.v0
                v84 = v81.v1
                v85 = v75[v83]
                v86 = v76[v83]
                v87 = v85 * v86
                v88 = v84 + v87
                v89 = v83 + (<signed long long>1)
                v81.v0 = v89
                v81.v1 = v88
            del v75; del v76
            v90 = v81.v1
            del v81
            v71[v74] = v90
            v91 = v74 + (<unsigned long long>1)
            v72.v0 = v91
        del v72
        if v1:
            if v26:
                v92 = len(v14)
                v93 = v24 == v92
                if v93:
                    v94 = len(v2)
                    v97 = v24 == v94
                else:
                    v97 = 0
            else:
                v97 = 0
            v98 = v97 == 0
            if v98:
                raise Exception("The length of the four arrays has to the same.")
            else:
                pass
            v99 = Mut0((<unsigned long long>0))
            while method0(v24, v99):
                v101 = v99.v0
                tmp17 = v3[v101]
                v102, v103, v104, v105 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3
                del tmp17
                del v104; del v105
                v106 = v6[v101]
                v107 = v14[v101]
                v108 = v2[v101]
                v109 = v107 * v108
                v110 = v103[v106]
                v111 = v110 + v109
                v103[v106] = v111
                del v103
                v112 = v102[v106]
                v113 = v112 + v108
                v102[v106] = v113
                del v102
                v114 = v101 + (<unsigned long long>1)
                v99.v0 = v114
            del v99
        else:
            pass
        del v14
        if v0:
            v115 = v24 == v67
            if v115:
                v116 = len(v71)
                v117 = v24 == v116
                if v117:
                    v118 = len(v2)
                    v121 = v24 == v118
                else:
                    v121 = 0
            else:
                v121 = 0
            v122 = v121 == 0
            if v122:
                raise Exception("The length of the four arrays has to the same.")
            else:
                pass
            v123 = Mut0((<unsigned long long>0))
            while method0(v24, v123):
                v125 = v123.v0
                tmp18 = v3[v125]
                v126, v127, v128, v129 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3
                del tmp18
                del v126; del v127; del v128
                v130 = v34[v125]
                v131 = v71[v125]
                v132 = v2[v125]
                v133 = len(v129)
                v134 = Mut5((<signed long long>0))
                while method24(v133, v134):
                    v136 = v134.v0
                    v137 = v129[v136]
                    v138 = v130[v136]
                    v139 = v138 - v131
                    v140 = v132 * v139
                    v141 = v137 + v140
                    v129[v136] = v141
                    v142 = v136 + (<signed long long>1)
                    v134.v0 = v142
                del v129; del v130
                del v134
                v143 = v125 + (<unsigned long long>1)
                v123.v0 = v143
            del v123
        else:
            pass
        del v34
        v144 = len(v71)
        v145 = v144 == v11
        v146 = v145 == 0
        if v146:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v147 = numpy.empty(v144,dtype=numpy.float32)
        v148 = Mut0((<unsigned long long>0))
        while method0(v144, v148):
            v150 = v148.v0
            v151 = v71[v150]
            v152 = v7[v150]
            v153 = v152 == (<unsigned char>0)
            if v153:
                v155 = v151
            else:
                v154 = -v151
                v155 = v154
            v147[v150] = v155
            v156 = v150 + (<unsigned long long>1)
            v148.v0 = v156
        del v71
        del v148
        return Tuple0(v147, v9)
cdef class Closure7():
    cdef float v0
    cdef bint v1
    cdef bint v2
    cdef Mut2 v3
    def __init__(self, float v0, bint v1, bint v2, Mut2 v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, list v4):
        cdef float v0 = self.v0
        cdef bint v1 = self.v1
        cdef bint v2 = self.v2
        cdef Mut2 v3 = self.v3
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
        cdef US2 v25
        cdef unsigned char v26
        cdef signed long v27
        cdef US2 v28
        cdef unsigned char v29
        cdef signed long v30
        cdef US3 v31
        cdef unsigned char v32
        cdef numpy.ndarray[signed long,ndim=1] v33
        cdef Tuple2 tmp13
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
        cdef US2 v47
        cdef unsigned long long v48
        cdef Mut3 v49
        cdef numpy.ndarray[float,ndim=1] v50
        cdef numpy.ndarray[float,ndim=1] v51
        cdef Tuple6 tmp14
        cdef numpy.ndarray[float,ndim=1] v52
        cdef numpy.ndarray[float,ndim=1] v53
        cdef Tuple0 tmp15
        cdef signed long long v54
        cdef bint v55
        cdef float v56
        cdef Mut4 v57
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
        cdef Mut5 v72
        cdef signed long long v74
        cdef float v75
        cdef float v76
        cdef float v77
        cdef signed long long v78
        cdef signed long long v79
        cdef numpy.ndarray[float,ndim=1] v80
        cdef Mut5 v81
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
        cdef US1 v97
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
            tmp13 = v4[v16]
            v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3, tmp13.v4, tmp13.v5, tmp13.v6, tmp13.v7, tmp13.v8, tmp13.v9, tmp13.v10, tmp13.v11, tmp13.v12, tmp13.v13, tmp13.v14, tmp13.v15, tmp13.v16
            del tmp13
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
            tmp14 = method15(v3, v48, v45)
            v49, v50, v51 = tmp14.v0, tmp14.v1, tmp14.v2
            del tmp14
            del v45
            tmp15 = method26(v49, v48, v47)
            v52, v53 = tmp15.v0, tmp15.v1
            del tmp15
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
            v57 = Mut4((<signed long long>1), v56)
            while method23(v54, v57):
                v59 = v57.v0
                v60 = v57.v1
                v61 = v50[v59]
                v62 = v60 + v61
                v63 = v59 + (<signed long long>1)
                v57.v0 = v63
                v57.v1 = v62
            v64 = v57.v1
            del v57
            v65 = v64 == (<float>0)
            if v65:
                v66 = <float>v54
                v67 = (<float>1) / v66
                v69, v70 = v67, (<float>0)
            else:
                v68 = (<float>1) / v64
                v69, v70 = (<float>0), v68
            v71 = numpy.empty(v54,dtype=numpy.float32)
            v72 = Mut5((<signed long long>0))
            while method24(v54, v72):
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
            v81 = Mut5((<signed long long>0))
            while method24(v79, v81):
                v83 = v81.v0
                v84 = v71[v83]
                v85 = <float>v48
                v86 = v0 / v85
                v87 = (<float>1) - v0
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
            v13[v16] = Tuple4(v95, v94, v97)
            v98 = v16 + (<unsigned long long>1)
            v14.v0 = v98
        del v14
        v99 = Closure8(v1, v2, v6, v7, v8, v9, v10, v11)
        del v6; del v7; del v8; del v9; del v10; del v11
        return Tuple1(v13, v99)
cdef class Closure6():
    def __init__(self): pass
    def __call__(self, Mut2 v0, bint v1, bint v2, float v3):
        return Closure7(v3, v2, v1, v0)
cdef class Closure9():
    def __init__(self): pass
    def __call__(self, Mut2 v0, float v1):
        method32(v1, v0)
cdef class Closure10():
    def __init__(self): pass
    def __call__(self, Mut2 v0):
        method34(v0)
cdef class Closure11():
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
        cdef US2 v14
        cdef unsigned char v15
        cdef signed long v16
        cdef US2 v17
        cdef unsigned char v18
        cdef signed long v19
        cdef US3 v20
        cdef unsigned char v21
        cdef numpy.ndarray[signed long,ndim=1] v22
        cdef Tuple2 tmp22
        cdef unsigned long long v23
        cdef float v24
        cdef float v25
        cdef float v26
        cdef US1 v27
        cdef unsigned long long v28
        cdef object v29
        v1 = len(v0)
        v2 = numpy.empty(v1,dtype=object)
        v3 = Mut0((<unsigned long long>0))
        while method0(v1, v3):
            v5 = v3.v0
            tmp22 = v0[v5]
            v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3, tmp22.v4, tmp22.v5, tmp22.v6, tmp22.v7, tmp22.v8, tmp22.v9, tmp22.v10, tmp22.v11, tmp22.v12, tmp22.v13, tmp22.v14, tmp22.v15, tmp22.v16
            del tmp22
            del v8; del v11; del v20
            v23 = len(v22)
            v24 = <float>v23
            v25 = (<float>1) / v24
            v26 = libc.math.log(v25)
            v27 = numpy.random.choice(v22)
            del v22
            v2[v5] = Tuple4(v26, v26, v27)
            v28 = v5 + (<unsigned long long>1)
            v3.v0 = v28
        del v3
        v29 = Closure2()
        return Tuple1(v2, v29)
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
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
    cdef readonly US2 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US2 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly US3 v14
    cdef readonly unsigned char v15
    cdef readonly object v16
    cdef readonly object v17
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US2 v8, unsigned char v9, signed long v10, US2 v11, unsigned char v12, signed long v13, US3 v14, unsigned char v15, v16, v17): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
cdef class UH3_1(UH3): # terminal_
    cdef readonly float v0
    cdef readonly float v1
    cdef readonly UH0 v2
    cdef readonly float v3
    cdef readonly float v4
    cdef readonly UH0 v5
    cdef readonly float v6
    cdef readonly float v7
    cdef readonly US2 v8
    cdef readonly unsigned char v9
    cdef readonly signed long v10
    cdef readonly US2 v11
    cdef readonly unsigned char v12
    cdef readonly signed long v13
    cdef readonly US3 v14
    cdef readonly float v15
    def __init__(self, float v0, float v1, UH0 v2, float v3, float v4, UH0 v5, float v6, float v7, US2 v8, unsigned char v9, signed long v10, US2 v11, unsigned char v12, signed long v13, US3 v14, float v15): self.tag = 1; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
cdef class Closure16():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef signed long v2
    cdef US2 v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US2 v7
    cdef signed long v8
    cdef UH0 v9
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, Heap0 v1, signed long v2, US2 v3, US2 v4, unsigned char v5, signed long v6, US2 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US1 v18):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef signed long v2 = self.v2
        cdef US2 v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
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
            v22 = US0_0(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US0_0(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method40(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US0_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US0_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method40(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure15():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef US2 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US2 v5
    cdef signed long v6
    cdef US2 v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, Heap0 v1, US2 v2, unsigned char v3, signed long v4, US2 v5, signed long v6, US2 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US1 v17):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef US2 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US2 v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
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
            v21 = US0_0(v17)
            v22 = US0_1(v7)
            v23 = UH0_0(v22, v11)
            del v22
            v24 = UH0_0(v21, v23)
            del v21; del v23
            v25 = US0_0(v17)
            v26 = US0_1(v7)
            v27 = UH0_0(v26, v8)
            del v26
            v28 = UH0_0(v25, v27)
            del v25; del v27
            return method38(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v24, v20, v19, v28, v9, v10)
        else:
            v30 = v16 + v10
            v31 = v15 + v9
            v32 = US0_0(v17)
            v33 = US0_1(v7)
            v34 = UH0_0(v33, v11)
            del v33
            v35 = UH0_0(v32, v34)
            del v32; del v34
            v36 = US0_0(v17)
            v37 = US0_1(v7)
            v38 = UH0_0(v37, v8)
            del v37
            v39 = UH0_0(v36, v38)
            del v36; del v38
            return method38(v1, v2, v3, v4, v5, v0, v6, v7, v17, v14, v35, v12, v13, v39, v31, v30)
cdef class Closure17():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef object v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US2 v7
    cdef signed long v8
    cdef UH0 v9
    cdef float v10
    cdef float v11
    cdef UH0 v12
    cdef float v13
    cdef float v14
    cdef float v15
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US2 v7, signed long v8, UH0 v9, float v10, float v11, UH0 v12, float v13, float v14, float v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, float v16, float v17, US1 v18):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
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
            v22 = US0_0(v18)
            v23 = UH0_0(v22, v12)
            del v22
            v24 = US0_0(v18)
            v25 = UH0_0(v24, v9)
            del v24
            return method42(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v23, v21, v20, v25, v10, v11)
        else:
            v27 = v17 + v11
            v28 = v16 + v10
            v29 = US0_0(v18)
            v30 = UH0_0(v29, v12)
            del v29
            v31 = US0_0(v18)
            v32 = UH0_0(v31, v9)
            del v31
            return method42(v1, v2, v3, v4, v5, v6, v7, v0, v8, v18, v15, v30, v13, v14, v32, v28, v27)
cdef class Closure14():
    cdef unsigned char v0
    cdef Heap0 v1
    cdef object v2
    cdef signed long v3
    cdef US2 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US2 v7
    cdef UH0 v8
    cdef float v9
    cdef float v10
    cdef UH0 v11
    cdef float v12
    cdef float v13
    cdef float v14
    def __init__(self, unsigned char v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US2 v7, UH0 v8, float v9, float v10, UH0 v11, float v12, float v13, float v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, float v15, float v16, US1 v17):
        cdef unsigned char v0 = self.v0
        cdef Heap0 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US2 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
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
            v21 = US0_0(v17)
            v22 = UH0_0(v21, v11)
            del v21
            v23 = US0_0(v17)
            v24 = UH0_0(v23, v8)
            del v23
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v22, v20, v19, v24, v9, v10)
        else:
            v26 = v16 + v10
            v27 = v15 + v9
            v28 = US0_0(v17)
            v29 = UH0_0(v28, v11)
            del v28
            v30 = US0_0(v17)
            v31 = UH0_0(v30, v8)
            del v30
            return method37(v1, v2, v3, v4, v5, v6, v7, v0, v17, v14, v29, v12, v13, v31, v27, v26)
cdef class Closure13():
    cdef US2 v0
    cdef US2 v1
    cdef Heap0 v2
    cdef object v3
    cdef UH0 v4
    cdef float v5
    cdef float v6
    cdef UH0 v7
    cdef float v8
    cdef float v9
    cdef float v10
    def __init__(self, US2 v0, US2 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, UH0 v4, float v5, float v6, UH0 v7, float v8, float v9, float v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, float v11, float v12, US1 v13):
        cdef US2 v0 = self.v0
        cdef US2 v1 = self.v1
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
        v16 = US0_0(v13)
        v17 = US0_1(v0)
        v18 = UH0_0(v17, v7)
        del v17
        v19 = UH0_0(v16, v18)
        del v16; del v18
        v20 = US0_0(v13)
        v21 = US0_1(v1)
        v22 = UH0_0(v21, v4)
        del v21
        v23 = UH0_0(v20, v22)
        del v20; del v22
        return method35(v0, v1, v2, v3, v13, v10, v19, v15, v14, v23, v5, v6)
cdef class Tuple9:
    cdef readonly unsigned long long v0
    cdef readonly float v1
    def __init__(self, unsigned long long v0, float v1): self.v0 = v0; self.v1 = v1
cdef class Mut6:
    cdef public unsigned long long v0
    cdef public unsigned long long v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure12():
    def __init__(self): pass
    def __call__(self, unsigned long long v0, v1, v2):
        cdef numpy.ndarray[object,ndim=1] v3
        cdef Mut0 v4
        cdef unsigned long long v6
        cdef US1 v7
        cdef US1 v8
        cdef numpy.ndarray[signed long,ndim=1] v9
        cdef US1 v10
        cdef US1 v11
        cdef US1 v12
        cdef numpy.ndarray[signed long,ndim=1] v13
        cdef US1 v14
        cdef US1 v15
        cdef numpy.ndarray[signed long,ndim=1] v16
        cdef US1 v17
        cdef numpy.ndarray[signed long,ndim=1] v18
        cdef Heap0 v19
        cdef US2 v20
        cdef US2 v21
        cdef US2 v22
        cdef US2 v23
        cdef US2 v24
        cdef US2 v25
        cdef numpy.ndarray[signed long,ndim=1] v26
        cdef UH0 v27
        cdef float v28
        cdef float v29
        cdef UH0 v30
        cdef float v31
        cdef float v32
        cdef US2 v33
        cdef unsigned long long v34
        cdef float v35
        cdef float v36
        cdef float v37
        cdef numpy.ndarray[signed long,ndim=1] v38
        cdef US2 v39
        cdef unsigned long long v40
        cdef float v41
        cdef float v42
        cdef float v43
        cdef float v44
        cdef numpy.ndarray[signed long,ndim=1] v45
        cdef numpy.ndarray[signed long,ndim=1] v46
        cdef US0 v47
        cdef UH0 v48
        cdef US0 v49
        cdef UH0 v50
        cdef US3 v51
        cdef object v52
        cdef UH3 v53
        cdef unsigned long long v54
        v3 = numpy.empty(v0,dtype=object)
        v4 = Mut0((<unsigned long long>0))
        while method0(v0, v4):
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
            v44 = v43 + v37
            v45 = v38[1:]
            del v38
            v46 = v19.v2
            v47 = US0_1(v33)
            v48 = UH0_0(v47, v27)
            del v47
            v49 = US0_1(v39)
            v50 = UH0_0(v49, v30)
            del v49
            v51 = US3_0()
            v52 = Closure13(v33, v39, v19, v45, v30, v31, v32, v27, v28, v29, v44)
            del v19; del v27; del v30; del v45
            v53 = UH3_0(v44, v44, v48, v28, v29, v50, v31, v32, v33, (<unsigned char>0), (<signed long>1), v39, (<unsigned char>1), (<signed long>1), v51, (<unsigned char>0), v46, v52)
            del v46; del v48; del v50; del v51; del v52
            v3[v6] = v53
            del v53
            v54 = v6 + (<unsigned long long>1)
            v4.v0 = v54
        del v4
        return method43(v2, v1, v3)
cdef bint method0(unsigned long long v0, Mut0 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef UH0 method2(UH0 v0, UH0 v1):
    cdef US0 v2
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
    cdef US1 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        return method4(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method6(UH1 v0, unsigned long long v1) except *:
    cdef US1 v2
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method6(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method7(numpy.ndarray[signed long,ndim=1] v0, UH1 v1, unsigned long long v2) except *:
    cdef US1 v3
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
cdef UH2 method3(UH1 v0, US2 v1, UH0 v2):
    cdef US0 v3
    cdef UH0 v4
    cdef US1 v5
    cdef UH1 v6
    cdef US2 v8
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
            v5 = (<US0_0>v3).v0
            v6 = UH1_0(v5, v0)
            return method3(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US0_1>v3).v0
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
    cdef US2 v2
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v4 = (<UH2_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method9(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method10(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2) except *:
    cdef US2 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple3(v3, v4)
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
    cdef US0 v3
    cdef UH0 v4
    cdef US1 v5
    cdef US2 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method2(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US0_0>v3).v0
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US0_1>v3).v0
            v8 = UH1_1()
            v9 = method3(v8, v7, v4)
            del v4; del v8
            return method8(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef bint method11(signed short v0, Mut1 v1) except *:
    cdef signed short v2
    v2 = v1.v0
    return v2 < v0
cdef signed short method13(numpy.ndarray[float,ndim=1] v0, unsigned long long v1, unsigned long long v2, signed short v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef signed long v8
    cdef signed short v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef signed short v12
    cdef float v13
    cdef signed short v14
    v4 = v2 < (<unsigned long long>4)
    if v4:
        v5 = v2 + (<unsigned long long>1)
        v6 = (<unsigned long long>4) - v2
        v7 = v6 - (<unsigned long long>1)
        v8 = <signed long>v7
        v9 = (<signed short>1) << v8
        v10 = <unsigned long long>v2
        v11 = v1 + v10
        v12 = v3 // v9
        v13 = <float>v12
        v0[v11] = v13
        v14 = v3 % v9
        return method13(v0, v1, v5, v14)
    else:
        return v3
cdef void method12(signed short v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2) except *:
    cdef unsigned long long v3
    cdef signed long v4
    cdef signed long v5
    cdef signed short v6
    cdef signed short v7
    cdef signed short v8
    cdef bint v9
    cdef unsigned long long v12
    cdef signed short v13
    cdef unsigned long long v10
    cdef signed short v11
    cdef signed short v14
    cdef bint v15
    cdef bint v17
    cdef unsigned long long v18
    cdef signed short v19
    cdef str v20
    v1[v2] = (<float>1)
    v3 = v2 + (<unsigned long long>1)
    v4 = <signed long>(<unsigned long long>4)
    v5 = v4 - (<signed long>1)
    v6 = (<signed short>1) << v5
    v7 = v6 - (<signed short>1)
    v8 = v6 + v7
    v9 = v0 < (<signed short>0)
    if v9:
        v10 = v3 + (<unsigned long long>4)
        v11 = -v0
        v12, v13 = v10, v11
    else:
        v12, v13 = v3, v0
    v14 = -v8
    v15 = v14 <= v13
    if v15:
        v17 = v13 <= v8
    else:
        v17 = 0
    if v17:
        v18 = (<unsigned long long>0)
        v19 = method13(v1, v12, v18, v13)
    else:
        v20 = f'Pickle failure. Bin int value out of bounds. Got: {v13} Size: {(<unsigned long long>4)}'
        raise Exception(v20)
cdef unsigned long long method16(UH0 v0) except *:
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
        if v1.tag == 0: # action_
            v3 = (<US0_0>v1).v0
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
            v19 = (<US0_1>v1).v0
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
        v37 = method16(v2)
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
cdef bint method18(UH0 v0, UH0 v1) except *:
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
        if v2.tag == 0 and v4.tag == 0: # action_
            v6 = (<US0_0>v2).v0; v7 = (<US0_0>v4).v0
            if v6 == 0 and v7 == 0: # call
                v12 = 1
            elif v6 == 1 and v7 == 1: # fold
                v12 = 1
            elif v6 == 2 and v7 == 2: # raise
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # observation_
            v9 = (<US0_1>v2).v0; v10 = (<US0_1>v4).v0
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
            return method18(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef Mut3 method19(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef Mut0 v4
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef Mut3 v9
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
    v9 = Mut3(v0, v3, (<unsigned long long>0))
    del v3
    return v9
cdef void method22(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut3 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple5 tmp7
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
        v13.append(Tuple5(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method22(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method21(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
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
        method22(v8, v2, v3, v7, v9)
        del v7
        method21(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method20(Mut2 v0) except *:
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
    method21(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple6 method17(Mut2 v0, UH0 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut3 v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef numpy.ndarray[float,ndim=1] v12
    cdef Tuple5 tmp6
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v16
    cdef numpy.ndarray[float,ndim=1] v23
    cdef numpy.ndarray[float,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef Mut3 v27
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
            v15 = method18(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple6(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + (<unsigned long long>1)
            return method17(v0, v1, v2, v3, v4, v16)
    else:
        v23 = numpy.zeros(v2,dtype=numpy.float32)
        v24 = numpy.zeros(v2,dtype=numpy.float32)
        v25 = (<unsigned long long>3)
        v26 = (<unsigned long long>7)
        v27 = method19(v25, v26)
        v4.append(Tuple5(v3, v1, v27, v23, v24))
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
            method20(v0)
        else:
            pass
        return Tuple6(v27, v23, v24)
cdef Tuple6 method15(Mut2 v0, unsigned long long v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method16(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method17(v0, v2, v1, v4, v8, v9)
cdef bint method23(signed long long v0, Mut4 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef bint method24(signed long long v0, Mut5 v1) except *:
    cdef signed long long v2
    v2 = v1.v0
    return v2 < v0
cdef void method30(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4) except *:
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef US2 v8
    cdef numpy.ndarray[float,ndim=1] v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef Tuple7 tmp11
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
        v12.append(Tuple7(v7, v8, v9, v10))
        del v9; del v10; del v12
        method30(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method29(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4) except *:
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
        method30(v8, v2, v3, v7, v9)
        del v7
        method29(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method28(Mut3 v0) except *:
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
    method29(v2, v1, v5, v7, v13)
    del v1
    v0.v1 = v7
    del v7
    v14 = v0.v0
    v15 = v14 + (<unsigned long long>2)
    v0.v0 = v15
cdef Tuple0 method27(Mut3 v0, US2 v1, unsigned long long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US2 v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef numpy.ndarray[float,ndim=1] v11
    cdef Tuple7 tmp10
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
            return Tuple0(v10, v11)
        else:
            del v10; del v11
            v15 = v5 + (<unsigned long long>1)
            return method27(v0, v1, v2, v3, v4, v15)
    else:
        v20 = numpy.zeros(v2,dtype=numpy.float32)
        v21 = numpy.zeros(v2,dtype=numpy.float32)
        v4.append(Tuple7(v3, v1, v21, v20))
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
            method28(v0)
        else:
            pass
        return Tuple0(v21, v20)
cdef Tuple0 method26(Mut3 v0, unsigned long long v1, US2 v2):
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
    return method27(v0, v2, v1, v13, v17, v18)
cdef void method25(Mut3 v0, Mut3 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef US2 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple7 tmp9
    cdef signed long long v17
    cdef unsigned long long v18
    cdef numpy.ndarray[float,ndim=1] v19
    cdef numpy.ndarray[float,ndim=1] v20
    cdef Tuple0 tmp12
    cdef signed long long v21
    cdef Mut5 v22
    cdef signed long long v24
    cdef float v25
    cdef float v26
    cdef float v27
    cdef signed long long v28
    cdef signed long long v29
    cdef Mut5 v30
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
            tmp9 = v8[v12]
            v13, v14, v15, v16 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3
            del tmp9
            v17 = len(v16)
            v18 = <unsigned long long>v17
            tmp12 = method26(v0, v18, v14)
            v19, v20 = tmp12.v0, tmp12.v1
            del tmp12
            v21 = len(v20)
            v22 = Mut5((<signed long long>0))
            while method24(v21, v22):
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
            v30 = Mut5((<signed long long>0))
            while method24(v29, v30):
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
cdef void method14(Mut2 v0, Mut2 v1) except *:
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
    cdef Mut3 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple5 tmp5
    cdef signed long long v18
    cdef unsigned long long v19
    cdef Mut3 v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef numpy.ndarray[float,ndim=1] v22
    cdef Tuple6 tmp8
    cdef bint v23
    cdef float v24
    cdef Mut4 v25
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
    cdef Mut5 v40
    cdef signed long long v42
    cdef float v43
    cdef float v44
    cdef float v45
    cdef signed long long v46
    cdef signed long long v47
    cdef Mut5 v48
    cdef signed long long v50
    cdef float v51
    cdef float v52
    cdef float v53
    cdef signed long long v54
    cdef signed long long v55
    cdef Mut5 v56
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
            tmp5 = v8[v12]
            v13, v14, v15, v16, v17 = tmp5.v0, tmp5.v1, tmp5.v2, tmp5.v3, tmp5.v4
            del tmp5
            v18 = len(v16)
            v19 = <unsigned long long>v18
            tmp8 = method15(v0, v19, v14)
            v20, v21, v22 = tmp8.v0, tmp8.v1, tmp8.v2
            del tmp8
            del v14
            v23 = v18 == (<signed long long>0)
            if v23:
                raise Exception("The array must be greater than 0.")
            else:
                pass
            v24 = v16[(<signed long long>0)]
            v25 = Mut4((<signed long long>1), v24)
            while method23(v18, v25):
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
            v40 = Mut5((<signed long long>0))
            while method24(v18, v40):
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
            v48 = Mut5((<signed long long>0))
            while method24(v47, v48):
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
            v56 = Mut5((<signed long long>0))
            while method24(v55, v56):
                v58 = v56.v0
                v59 = v22[v58]
                v60 = v17[v58]
                v61 = v59 + v60
                v22[v58] = v61
                v62 = v58 + (<signed long long>1)
                v56.v0 = v62
            del v17; del v22
            del v56
            method25(v20, v15)
            del v15; del v20
            v63 = v12 + (<unsigned long long>1)
            v10.v0 = v63
        del v8
        del v10
        v64 = v7 + (<unsigned long long>1)
        v5.v0 = v64
    del v3
cdef Mut2 method31(unsigned long long v0, unsigned long long v1):
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
cdef void method33(float v0, Mut3 v1) except *:
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef US2 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple7 tmp20
    cdef signed long long v17
    cdef Mut5 v18
    cdef signed long long v20
    cdef float v21
    cdef float v22
    cdef signed long long v23
    cdef signed long long v24
    cdef Mut5 v25
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
            tmp20 = v8[v12]
            v13, v14, v15, v16 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3
            del tmp20
            v17 = len(v15)
            v18 = Mut5((<signed long long>0))
            while method24(v17, v18):
                v20 = v18.v0
                v21 = v15[v20]
                v22 = v21 * v0
                v15[v20] = v22
                v23 = v20 + (<signed long long>1)
                v18.v0 = v23
            del v15
            del v18
            v24 = len(v16)
            v25 = Mut5((<signed long long>0))
            while method24(v24, v25):
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
cdef void method32(float v0, Mut2 v1) except *:
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
    cdef Mut3 v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef Tuple5 tmp19
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
            tmp19 = v8[v12]
            v13, v14, v15, v16, v17 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3, tmp19.v4
            del tmp19
            del v14; del v16; del v17
            method33(v0, v15)
            del v15
            v18 = v12 + (<unsigned long long>1)
            v10.v0 = v18
        del v8
        del v10
        v19 = v7 + (<unsigned long long>1)
        v5.v0 = v19
    del v3
cdef void method34(Mut2 v0) except *:
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
    cdef Mut3 v14
    cdef numpy.ndarray[float,ndim=1] v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef Tuple5 tmp21
    cdef signed long long v17
    cdef Mut5 v18
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
            tmp21 = v7[v11]
            v12, v13, v14, v15, v16 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4
            del tmp21
            del v13; del v14
            v17 = len(v15)
            v18 = Mut5((<signed long long>0))
            while method24(v17, v18):
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
cdef numpy.ndarray[signed long,ndim=1] method36(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method39(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method41(US2 v0) except *:
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef UH3 method40(Heap0 v0, signed long v1, US2 v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, signed long v8, US1 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
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
    cdef US2 v64
    cdef unsigned char v65
    cdef signed long v66
    cdef US2 v67
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
    cdef US2 v83
    cdef unsigned char v84
    cdef signed long v85
    cdef US2 v86
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
        v17 = method41(v2)
        v18 = method41(v6)
        v19 = method41(v3)
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
        v94 = method39(v0, v6, v7, v93, v3, v4, v5, v92)
        v95 = US3_1(v2)
        v96 = Closure16(v4, v0, v92, v2, v6, v7, v93, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH3_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v93, v95, v4, v94, v96)
cdef UH3 method38(Heap0 v0, US2 v1, unsigned char v2, signed long v3, US2 v4, unsigned char v5, signed long v6, US2 v7, US1 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
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
        v17 = method39(v0, v4, v5, v6, v1, v2, v3, v16)
        v18 = US3_1(v7)
        v19 = Closure16(v2, v0, v16, v7, v4, v5, v6, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH3_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v6, v18, v2, v17, v19)
    elif v8 == 1: # fold
        raise Exception("impossible 2")
    elif v8 == 2: # raise
        v23 = (<signed long>1)
        v24 = v3 + (<signed long>4)
        v25 = method39(v0, v4, v5, v24, v1, v2, v3, v23)
        v26 = US3_1(v7)
        v27 = Closure16(v2, v0, v23, v7, v4, v5, v24, v1, v3, v13, v14, v15, v10, v11, v12, v9)
        return UH3_0(v9, v9, v10, v11, v12, v13, v14, v15, v1, v2, v3, v4, v5, v24, v26, v2, v25, v27)
cdef UH3 method42(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, signed long v8, US1 v9, float v10, UH0 v11, float v12, float v13, UH0 v14, float v15, float v16):
    cdef bint v17
    cdef US2 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US2 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef US2 v24
    cdef unsigned long long v25
    cdef float v26
    cdef float v27
    cdef float v28
    cdef float v29
    cdef numpy.ndarray[signed long,ndim=1] v30
    cdef US0 v31
    cdef UH0 v32
    cdef US0 v33
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
    cdef US2 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef US2 v51
    cdef unsigned char v52
    cdef signed long v53
    cdef float v54
    cdef US3 v55
    cdef signed long v57
    cdef signed long v58
    cdef numpy.ndarray[signed long,ndim=1] v59
    cdef US3 v60
    cdef object v61
    if v9 == 0: # call
        v17 = v7 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v6, v7, v5, v3, v4, v5
        else:
            v18, v19, v20, v21, v22, v23 = v3, v4, v5, v6, v7, v5
        v24 = v1[(<unsigned long long>0)]
        v25 = len(v1)
        v26 = <float>v25
        v27 = (<float>1) / v26
        v28 = libc.math.log(v27)
        v29 = v28 + v10
        v30 = v0.v2
        v31 = US0_1(v24)
        v32 = UH0_0(v31, v11)
        del v31
        v33 = US0_1(v24)
        v34 = UH0_0(v33, v14)
        del v33
        v35 = US3_1(v24)
        v36 = Closure15(v19, v0, v21, v22, v23, v18, v20, v24, v14, v15, v16, v11, v12, v13, v29)
        return UH3_0(v29, v29, v32, v12, v13, v34, v15, v16, v18, v19, v20, v21, v22, v23, v35, v19, v30, v36)
    elif v9 == 1: # fold
        v38 = v4 == (<unsigned char>0)
        if v38:
            v40 = v8
        else:
            v40 = -v8
        v41 = v7 == (<unsigned char>0)
        if v41:
            v43 = v40
        else:
            v43 = -v40
        v44 = v43 + v8
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
        return UH3_1(v10, v10, v11, v12, v13, v14, v15, v16, v48, v49, v50, v51, v52, v53, v55, v54)
    elif v9 == 2: # raise
        v57 = v2 - (<signed long>1)
        v58 = v5 + (<signed long>2)
        v59 = method39(v0, v6, v7, v58, v3, v4, v5, v57)
        v60 = US3_0()
        v61 = Closure17(v4, v0, v1, v57, v6, v7, v58, v3, v5, v14, v15, v16, v11, v12, v13, v10)
        return UH3_0(v10, v10, v11, v12, v13, v14, v15, v16, v3, v4, v5, v6, v7, v58, v60, v4, v59, v61)
cdef UH3 method37(Heap0 v0, numpy.ndarray[signed long,ndim=1] v1, signed long v2, US2 v3, unsigned char v4, signed long v5, US2 v6, unsigned char v7, US1 v8, float v9, UH0 v10, float v11, float v12, UH0 v13, float v14, float v15):
    cdef bint v16
    cdef US2 v17
    cdef unsigned char v18
    cdef signed long v19
    cdef US2 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef US2 v23
    cdef unsigned long long v24
    cdef float v25
    cdef float v26
    cdef float v27
    cdef float v28
    cdef numpy.ndarray[signed long,ndim=1] v29
    cdef US0 v30
    cdef UH0 v31
    cdef US0 v32
    cdef UH0 v33
    cdef US3 v34
    cdef object v35
    cdef bint v37
    cdef signed long v39
    cdef bint v40
    cdef signed long v42
    cdef signed long v43
    cdef signed long v45
    cdef signed long v46
    cdef US2 v47
    cdef unsigned char v48
    cdef signed long v49
    cdef US2 v50
    cdef unsigned char v51
    cdef signed long v52
    cdef float v53
    cdef US3 v54
    cdef signed long v56
    cdef signed long v57
    cdef numpy.ndarray[signed long,ndim=1] v58
    cdef US3 v59
    cdef object v60
    if v8 == 0: # call
        v16 = v7 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v6, v7, v5, v3, v4, v5
        else:
            v17, v18, v19, v20, v21, v22 = v3, v4, v5, v6, v7, v5
        v23 = v1[(<unsigned long long>0)]
        v24 = len(v1)
        v25 = <float>v24
        v26 = (<float>1) / v25
        v27 = libc.math.log(v26)
        v28 = v27 + v9
        v29 = v0.v2
        v30 = US0_1(v23)
        v31 = UH0_0(v30, v10)
        del v30
        v32 = US0_1(v23)
        v33 = UH0_0(v32, v13)
        del v32
        v34 = US3_1(v23)
        v35 = Closure15(v18, v0, v20, v21, v22, v17, v19, v23, v13, v14, v15, v10, v11, v12, v28)
        return UH3_0(v28, v28, v31, v11, v12, v33, v14, v15, v17, v18, v19, v20, v21, v22, v34, v18, v29, v35)
    elif v8 == 1: # fold
        v37 = v4 == (<unsigned char>0)
        if v37:
            v39 = v5
        else:
            v39 = -v5
        v40 = v7 == (<unsigned char>0)
        if v40:
            v42 = v39
        else:
            v42 = -v39
        v43 = v42 + v5
        if v37:
            v45 = v39
        else:
            v45 = -v39
        v46 = v45 + v5
        if v40:
            v47, v48, v49, v50, v51, v52 = v6, v7, v43, v3, v4, v46
        else:
            v47, v48, v49, v50, v51, v52 = v3, v4, v46, v6, v7, v43
        v53 = <float>v39
        v54 = US3_0()
        return UH3_1(v9, v9, v10, v11, v12, v13, v14, v15, v47, v48, v49, v50, v51, v52, v54, v53)
    elif v8 == 2: # raise
        v56 = v2 - (<signed long>1)
        v57 = v5 + (<signed long>2)
        v58 = method39(v0, v6, v7, v57, v3, v4, v5, v56)
        v59 = US3_0()
        v60 = Closure17(v4, v0, v1, v56, v6, v7, v57, v3, v5, v13, v14, v15, v10, v11, v12, v9)
        return UH3_0(v9, v9, v10, v11, v12, v13, v14, v15, v3, v4, v5, v6, v7, v57, v59, v4, v58, v60)
cdef UH3 method35(US2 v0, US2 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, US1 v4, float v5, UH0 v6, float v7, float v8, UH0 v9, float v10, float v11):
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
        v16 = method36(v2, v0, v15, v14, v1, v13, v12)
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
        v27 = method39(v2, v0, v25, v26, v1, v23, v24, v22)
        v28 = US3_0()
        v29 = Closure17(v23, v2, v3, v22, v0, v25, v26, v1, v24, v9, v10, v11, v6, v7, v8, v5)
        return UH3_0(v5, v5, v6, v7, v8, v9, v10, v11, v1, v23, v24, v0, v25, v26, v28, v23, v27, v29)
cdef bint method44(unsigned long long v0, Mut6 v1) except *:
    cdef unsigned long long v2
    v2 = v1.v0
    return v2 < v0
cdef Tuple0 method43(v0, v1, numpy.ndarray[object,ndim=1] v2):
    cdef list v3
    cdef list v4
    cdef list v5
    cdef list v6
    cdef list v7
    cdef list v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef Mut0 v12
    cdef unsigned long long v14
    cdef UH3 v15
    cdef float v16
    cdef float v17
    cdef UH0 v18
    cdef float v19
    cdef float v20
    cdef UH0 v21
    cdef float v22
    cdef float v23
    cdef US2 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef US2 v27
    cdef unsigned char v28
    cdef signed long v29
    cdef US3 v30
    cdef unsigned char v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef object v33
    cdef bint v34
    cdef float v35
    cdef float v36
    cdef float v38
    cdef float v39
    cdef float v41
    cdef float v42
    cdef US2 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef US2 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef float v50
    cdef unsigned long long v51
    cdef unsigned long long v52
    cdef bint v53
    cdef list v149
    cdef list v150
    cdef numpy.ndarray[object,ndim=1] v54
    cdef object v55
    cdef Tuple1 tmp23
    cdef numpy.ndarray[object,ndim=1] v56
    cdef object v57
    cdef Tuple1 tmp24
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
    cdef Tuple4 tmp25
    cdef UH3 v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef bint v74
    cdef bint v75
    cdef numpy.ndarray[object,ndim=1] v76
    cdef Mut0 v77
    cdef unsigned long long v79
    cdef object v80
    cdef float v81
    cdef float v82
    cdef US1 v83
    cdef Tuple4 tmp26
    cdef UH3 v84
    cdef unsigned long long v85
    cdef unsigned long long v86
    cdef unsigned long long v87
    cdef unsigned long long v88
    cdef numpy.ndarray[object,ndim=1] v89
    cdef Mut0 v90
    cdef unsigned long long v92
    cdef bint v93
    cdef UH3 v97
    cdef unsigned long long v95
    cdef unsigned long long v98
    cdef numpy.ndarray[float,ndim=1] v99
    cdef numpy.ndarray[float,ndim=1] v100
    cdef Tuple0 tmp27
    cdef numpy.ndarray[float,ndim=1] v101
    cdef numpy.ndarray[float,ndim=1] v102
    cdef numpy.ndarray[float,ndim=1] v103
    cdef numpy.ndarray[float,ndim=1] v104
    cdef Tuple0 tmp28
    cdef numpy.ndarray[float,ndim=1] v105
    cdef numpy.ndarray[float,ndim=1] v106
    cdef numpy.ndarray[float,ndim=1] v107
    cdef numpy.ndarray[float,ndim=1] v108
    cdef Tuple0 tmp29
    cdef unsigned long long v109
    cdef list v110
    cdef Mut6 v111
    cdef unsigned long long v113
    cdef unsigned long long v114
    cdef unsigned long long v115
    cdef unsigned char v116
    cdef bint v117
    cdef float v122
    cdef unsigned long long v123
    cdef unsigned long long v124
    cdef float v118
    cdef unsigned long long v119
    cdef float v120
    cdef unsigned long long v121
    cdef unsigned long long v125
    cdef unsigned long long v126
    cdef unsigned long long v127
    cdef unsigned long long v128
    cdef list v129
    cdef Mut6 v130
    cdef unsigned long long v132
    cdef unsigned long long v133
    cdef unsigned long long v134
    cdef unsigned char v135
    cdef bint v136
    cdef float v141
    cdef unsigned long long v142
    cdef unsigned long long v143
    cdef float v137
    cdef unsigned long long v138
    cdef float v139
    cdef unsigned long long v140
    cdef unsigned long long v144
    cdef unsigned long long v145
    cdef unsigned long long v146
    cdef list v147
    cdef list v148
    cdef numpy.ndarray[float,ndim=1] v151
    cdef numpy.ndarray[float,ndim=1] v152
    cdef unsigned long long v153
    cdef unsigned long long v154
    cdef bint v155
    cdef bint v156
    cdef Mut0 v157
    cdef unsigned long long v159
    cdef unsigned long long v160
    cdef float v161
    cdef unsigned long long v162
    cdef unsigned long long v163
    cdef Mut0 v164
    cdef unsigned long long v166
    cdef unsigned long long v167
    cdef float v168
    cdef Tuple9 tmp30
    cdef unsigned long long v169
    cdef unsigned long long v170
    cdef unsigned long long v171
    cdef bint v172
    cdef bint v173
    cdef Mut0 v174
    cdef unsigned long long v176
    cdef unsigned long long v177
    cdef float v178
    cdef unsigned long long v179
    cdef unsigned long long v180
    cdef Mut0 v181
    cdef unsigned long long v183
    cdef unsigned long long v184
    cdef float v185
    cdef Tuple9 tmp31
    cdef unsigned long long v186
    v3 = [None]*(<unsigned long long>0)
    v4 = [None]*(<unsigned long long>0)
    v5 = [None]*(<unsigned long long>0)
    v6 = [None]*(<unsigned long long>0)
    v7 = [None]*(<unsigned long long>0)
    v8 = [None]*(<unsigned long long>0)
    v9 = [None]*(<unsigned long long>0)
    v10 = [None]*(<unsigned long long>0)
    v11 = len(v2)
    v12 = Mut0((<unsigned long long>0))
    while method0(v11, v12):
        v14 = v12.v0
        v15 = v2[v14]
        if v15.tag == 0: # action_
            v16 = (<UH3_0>v15).v0; v17 = (<UH3_0>v15).v1; v18 = (<UH3_0>v15).v2; v19 = (<UH3_0>v15).v3; v20 = (<UH3_0>v15).v4; v21 = (<UH3_0>v15).v5; v22 = (<UH3_0>v15).v6; v23 = (<UH3_0>v15).v7; v24 = (<UH3_0>v15).v8; v25 = (<UH3_0>v15).v9; v26 = (<UH3_0>v15).v10; v27 = (<UH3_0>v15).v11; v28 = (<UH3_0>v15).v12; v29 = (<UH3_0>v15).v13; v30 = (<UH3_0>v15).v14; v31 = (<UH3_0>v15).v15; v32 = (<UH3_0>v15).v16; v33 = (<UH3_0>v15).v17
            v5.append(v14)
            v34 = v31 == (<unsigned char>0)
            if v34:
                v6.append(Tuple2(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
                v8.append(v33)
            else:
                v7.append(Tuple2(v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32))
                v9.append(v33)
            del v18; del v21; del v30; del v32; del v33
            v10.append(v31)
        elif v15.tag == 1: # terminal_
            v35 = (<UH3_1>v15).v0; v36 = (<UH3_1>v15).v1; v38 = (<UH3_1>v15).v3; v39 = (<UH3_1>v15).v4; v41 = (<UH3_1>v15).v6; v42 = (<UH3_1>v15).v7; v43 = (<UH3_1>v15).v8; v44 = (<UH3_1>v15).v9; v45 = (<UH3_1>v15).v10; v46 = (<UH3_1>v15).v11; v47 = (<UH3_1>v15).v12; v48 = (<UH3_1>v15).v13; v50 = (<UH3_1>v15).v15
            v3.append(Tuple9(v14, v50))
            v4.append(Tuple9(v14, v50))
        del v15
        v51 = v14 + (<unsigned long long>1)
        v12.v0 = v51
    del v12
    v52 = len(v10)
    v53 = (<unsigned long long>0) < v52
    if v53:
        tmp23 = v1(v6)
        v54, v55 = tmp23.v0, tmp23.v1
        del tmp23
        tmp24 = v0(v7)
        v56, v57 = tmp24.v0, tmp24.v1
        del tmp24
        v58 = len(v8)
        v59 = len(v54)
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
            v66 = v8[v65]
            tmp25 = v54[v65]
            v67, v68, v69 = tmp25.v0, tmp25.v1, tmp25.v2
            del tmp25
            v70 = v66(v67, v68, v69)
            del v66
            v62[v65] = v70
            del v70
            v71 = v65 + (<unsigned long long>1)
            v63.v0 = v71
        del v54
        del v63
        v72 = len(v9)
        v73 = len(v56)
        v74 = v72 == v73
        v75 = v74 == 0
        if v75:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v76 = numpy.empty(v72,dtype=object)
        v77 = Mut0((<unsigned long long>0))
        while method0(v72, v77):
            v79 = v77.v0
            v80 = v9[v79]
            tmp26 = v56[v79]
            v81, v82, v83 = tmp26.v0, tmp26.v1, tmp26.v2
            del tmp26
            v84 = v80(v81, v82, v83)
            del v80
            v76[v79] = v84
            del v84
            v85 = v79 + (<unsigned long long>1)
            v77.v0 = v85
        del v56
        del v77
        v86 = len(v62)
        v87 = len(v76)
        v88 = v86 + v87
        v89 = numpy.empty(v88,dtype=object)
        v90 = Mut0((<unsigned long long>0))
        while method0(v88, v90):
            v92 = v90.v0
            v93 = v92 < v86
            if v93:
                v97 = v62[v92]
            else:
                v95 = v92 - v86
                v97 = v76[v95]
            v89[v92] = v97
            del v97
            v98 = v92 + (<unsigned long long>1)
            v90.v0 = v98
        del v62; del v76
        del v90
        tmp27 = method43(v0, v1, v89)
        v99, v100 = tmp27.v0, tmp27.v1
        del tmp27
        del v89
        v101 = v99[:v59]
        v102 = v100[:v59]
        tmp28 = v55(v101, v102)
        v103, v104 = tmp28.v0, tmp28.v1
        del tmp28
        del v55; del v101; del v102
        v105 = v99[v59:]
        del v99
        v106 = v100[v59:]
        del v100
        tmp29 = v57(v105, v106)
        v107, v108 = tmp29.v0, tmp29.v1
        del tmp29
        del v57; del v105; del v106
        v109 = len(v10)
        v110 = [None]*v109
        v111 = Mut6((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method44(v109, v111):
            v113 = v111.v0
            v114, v115 = v111.v1, v111.v2
            v116 = v10[v113]
            v117 = v116 == (<unsigned char>0)
            if v117:
                v118 = v103[v114]
                v119 = v114 + (<unsigned long long>1)
                v122, v123, v124 = v118, v119, v115
            else:
                v120 = v107[v115]
                v121 = v115 + (<unsigned long long>1)
                v122, v123, v124 = v120, v114, v121
            v110[v113] = v122
            v125 = v113 + (<unsigned long long>1)
            v111.v0 = v125
            v111.v1 = v123
            v111.v2 = v124
        del v103; del v107
        v126, v127 = v111.v1, v111.v2
        del v111
        v128 = len(v10)
        v129 = [None]*v128
        v130 = Mut6((<unsigned long long>0), (<unsigned long long>0), (<unsigned long long>0))
        while method44(v128, v130):
            v132 = v130.v0
            v133, v134 = v130.v1, v130.v2
            v135 = v10[v132]
            v136 = v135 == (<unsigned char>0)
            if v136:
                v137 = v104[v133]
                v138 = v133 + (<unsigned long long>1)
                v141, v142, v143 = v137, v138, v134
            else:
                v139 = v108[v134]
                v140 = v134 + (<unsigned long long>1)
                v141, v142, v143 = v139, v133, v140
            v129[v132] = v141
            v144 = v132 + (<unsigned long long>1)
            v130.v0 = v144
            v130.v1 = v142
            v130.v2 = v143
        del v104; del v108
        v145, v146 = v130.v1, v130.v2
        del v130
        v149, v150 = v110, v129
        del v110; del v129
    else:
        v147 = [None]*(<unsigned long long>0)
        v148 = [None]*(<unsigned long long>0)
        v149, v150 = v147, v148
        del v147; del v148
    del v6; del v7; del v8; del v9; del v10
    v151 = numpy.empty(v11,dtype=numpy.float32)
    v152 = numpy.empty(v11,dtype=numpy.float32)
    v153 = len(v5)
    v154 = len(v149)
    v155 = v153 == v154
    v156 = v155 == 0
    if v156:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v157 = Mut0((<unsigned long long>0))
    while method0(v153, v157):
        v159 = v157.v0
        v160 = v5[v159]
        v161 = v149[v159]
        v151[v160] = v161
        v162 = v159 + (<unsigned long long>1)
        v157.v0 = v162
    del v149
    del v157
    v163 = len(v3)
    v164 = Mut0((<unsigned long long>0))
    while method0(v163, v164):
        v166 = v164.v0
        tmp30 = v3[v166]
        v167, v168 = tmp30.v0, tmp30.v1
        del tmp30
        v151[v167] = v168
        v169 = v166 + (<unsigned long long>1)
        v164.v0 = v169
    del v3
    del v164
    v170 = len(v5)
    v171 = len(v150)
    v172 = v170 == v171
    v173 = v172 == 0
    if v173:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v174 = Mut0((<unsigned long long>0))
    while method0(v170, v174):
        v176 = v174.v0
        v177 = v5[v176]
        v178 = v150[v176]
        v152[v177] = v178
        v179 = v176 + (<unsigned long long>1)
        v174.v0 = v179
    del v5; del v150
    del v174
    v180 = len(v4)
    v181 = Mut0((<unsigned long long>0))
    while method0(v180, v181):
        v183 = v181.v0
        tmp31 = v4[v183]
        v184, v185 = tmp31.v0, tmp31.v1
        del tmp31
        v152[v184] = v185
        v186 = v183 + (<unsigned long long>1)
        v181.v0 = v186
    del v4
    del v181
    return Tuple0(v151, v152)
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
    v0 = collections.namedtuple("Size",['action', 'future', 'present'])((<signed short>3), (<unsigned long long>12), (<unsigned long long>33))
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
    return {'neural': v2, 'tabular': v8, 'uniform_player': v9, 'vs_one': v10}
