import nets
import numpy
cimport numpy
cimport libc.math
import torch
import torch.nn.functional
import torch.distributions
ctypedef signed long US0
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
ctypedef signed long US1
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
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, double v0):
        return v0
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
cdef void method1(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US1 v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1 <= v4
        if v7:
            v8 = v6
        else:
            v8 = v4
        v9 = v2[v8]
        v3[v4] = v9
        method1(v0, v1, v2, v3, v6)
    else:
        pass
cdef UH0 method5(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method5(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method7(UH1 v0, UH1 v1):
    cdef US0 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        return method7(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(UH1 v0, unsigned long long v1):
    cdef US0 v2
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = v1 + (<unsigned long long>1)
        return method9(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method10(numpy.ndarray[signed long,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US0 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        v5 = v2 + (<unsigned long long>1)
        return method10(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[signed long,ndim=1] method8(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[signed long,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method9(v0, v1)
    v3 = numpy.empty(v2,dtype=numpy.int32)
    v4 = (<unsigned long long>0)
    v5 = method10(v3, v0, v4)
    return v3
cdef UH2 method6(UH1 v0, US1 v1, UH0 v2):
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
            return method6(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US2_1>v3).v0
            v9 = UH1_1()
            v10 = method7(v0, v9)
            del v9
            v11 = method8(v10)
            del v10
            v12 = UH1_1()
            v13 = method6(v12, v8, v4)
            del v4; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method7(v0, v16)
        del v16
        v18 = method8(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method12(UH2 v0, unsigned long long v1):
    cdef US1 v2
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH2_0>v0).v0; v4 = (<UH2_0>v0).v2
        v5 = v1 + (<unsigned long long>1)
        return method12(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method13(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US1 v3
    cdef numpy.ndarray[signed long,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple0(v3, v4)
        del v4
        v6 = v2 + (<unsigned long long>1)
        return method13(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method11(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = (<unsigned long long>0)
    v2 = method12(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = (<unsigned long long>0)
    v5 = method13(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method4(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US2 v3
    cdef UH0 v4
    cdef US0 v5
    cdef US1 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method5(v0, v1)
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
            v9 = method6(v8, v7, v4)
            del v4; del v8
            return method11(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef signed long long method15(US0 v0):
    cdef signed long long v1
    if v0 == 0: # call
        v1 = (<signed long long>0)
    elif v0 == 1: # fold
        v1 = (<signed long long>1)
    elif v0 == 2: # raise
        v1 = (<signed long long>2)
    return v1
cdef void method14(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US0 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v1[v3]
        v7 = method15(v6)
        v2[v3] = v7
        method14(v0, v1, v2, v5)
    else:
        pass
cdef void method16(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<float>0.000000)
        method16(v0, v1, v4)
    else:
        pass
cdef void method18(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US0 v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = v4 * (<unsigned long long>3)
        v9 = v2 + v8
        if v7 == 0: # call
            v1[v9] = (<float>1.000000)
        elif v7 == 1: # fold
            v10 = v9 + (<unsigned long long>1)
            v1[v10] = (<float>1.000000)
        elif v7 == 2: # raise
            v11 = v9 + (<unsigned long long>2)
            v1[v11] = (<float>1.000000)
        method18(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method17(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef numpy.ndarray[signed long,ndim=1] v7
    cdef Tuple0 tmp0
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef unsigned long long v14
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        tmp0 = v2[v3]
        v6, v7 = tmp0.v0, tmp0.v1
        del tmp0
        v8 = v3 * (<unsigned long long>15)
        if v6 == 0: # jack
            v1[v8] = (<float>1.000000)
        elif v6 == 1: # king
            v9 = v8 + (<unsigned long long>1)
            v1[v9] = (<float>1.000000)
        elif v6 == 2: # queen
            v10 = v8 + (<unsigned long long>2)
            v1[v10] = (<float>1.000000)
        v11 = v8 + (<unsigned long long>3)
        v12 = len(v7)
        v13 = (<unsigned long long>4) < v12
        if v13:
            raise Exception("The given array is too large.")
        else:
            pass
        v14 = (<unsigned long long>0)
        method18(v12, v1, v11, v7, v14)
        del v7
        method17(v0, v1, v2, v5)
    else:
        pass
cdef US0 method19(signed long long v0):
    cdef bint v1
    cdef bint v2
    cdef bint v3
    cdef bint v4
    cdef bint v5
    cdef bint v7
    cdef signed long long v8
    cdef bint v9
    cdef bint v10
    cdef signed long long v12
    cdef bint v13
    cdef bint v14
    v1 = v0 < (<signed long long>3)
    v2 = v1 == 0
    if v2:
        raise Exception("The size of the argument is too large.")
    else:
        pass
    v3 = v0 < (<signed long long>1)
    if v3:
        v4 = v0 == (<signed long long>0)
        v5 = v4 == 0
        if v5:
            raise Exception("The unit index should be 0.")
        else:
            pass
        return 0
    else:
        v7 = v0 < (<signed long long>2)
        if v7:
            v8 = v0 - (<signed long long>1)
            v9 = v8 == (<signed long long>0)
            v10 = v9 == 0
            if v10:
                raise Exception("The unit index should be 0.")
            else:
                pass
            return 1
        else:
            if v1:
                v12 = v0 - (<signed long long>2)
                v13 = v12 == (<signed long long>0)
                v14 = v13 == 0
                if v14:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                return 2
            else:
                raise Exception("Unpickling of an union failed.")
cdef numpy.ndarray[signed long,ndim=1] method21(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6):
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
cdef numpy.ndarray[signed long,ndim=1] method25(Heap0 v0, US1 v1, unsigned char v2, signed long v3, US1 v4, unsigned char v5, signed long v6, signed long v7):
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
cdef signed long method27(US1 v0):
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef double method26(v0, Heap0 v1, signed long v2, US1 v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15, v16):
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
    cdef double v70
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
    cdef double v88
    cdef signed long v90
    cdef signed long v91
    cdef numpy.ndarray[signed long,ndim=1] v92
    cdef bint v93
    cdef numpy.ndarray[object,ndim=1] v94
    cdef unsigned long long v95
    cdef numpy.ndarray[signed long long,ndim=1] v96
    cdef unsigned long long v97
    cdef numpy.ndarray[float,ndim=1] v98
    cdef unsigned long long v99
    cdef unsigned long long v100
    cdef unsigned long long v101
    cdef bint v102
    cdef unsigned long long v103
    cdef object v104
    cdef object v105
    cdef object v106
    cdef object v107
    cdef object v108
    cdef object v109
    cdef object v110
    cdef double v111
    cdef signed long long v112
    cdef unsigned long long v113
    cdef signed long long v114
    cdef US0 v115
    cdef double v116
    cdef US2 v117
    cdef UH0 v118
    cdef US2 v119
    cdef UH0 v120
    cdef US0 v122
    cdef unsigned long long v123
    cdef double v124
    cdef double v125
    cdef double v126
    cdef double v127
    cdef US2 v128
    cdef UH0 v129
    cdef US2 v130
    cdef UH0 v131
    if v10 == 0: # call
        v17 = method27(v3)
        v18 = method27(v7)
        v19 = method27(v4)
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
            v51, v52 = v8, v6
        else:
            v48 = v46 == (<signed long>-1)
            if v48:
                v51, v52 = v5, v6
            else:
                v51, v52 = v8, (<signed long>0)
        v53 = v51 == (<unsigned char>0)
        if v53:
            v55 = v52
        else:
            v55 = -v52
        v56 = v8 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v58 + v6
        v60 = v5 == (<unsigned char>0)
        if v60:
            v62 = v55
        else:
            v62 = -v55
        v63 = v62 + v6
        if v56:
            v64, v65, v66, v67, v68, v69 = v7, v8, v59, v4, v5, v63
        else:
            v64, v65, v66, v67, v68, v69 = v4, v5, v63, v7, v8, v59
        v70 = <double>v55
        return v16(v70)
    elif v10 == 1: # fold
        v72 = v5 == (<unsigned char>0)
        if v72:
            v74 = v9
        else:
            v74 = -v9
        v75 = v8 == (<unsigned char>0)
        if v75:
            v77 = v74
        else:
            v77 = -v74
        v78 = v77 + v9
        if v72:
            v80 = v74
        else:
            v80 = -v74
        v81 = v80 + v6
        if v75:
            v82, v83, v84, v85, v86, v87 = v7, v8, v78, v4, v5, v81
        else:
            v82, v83, v84, v85, v86, v87 = v4, v5, v81, v7, v8, v78
        v88 = <double>v74
        return v16(v88)
    elif v10 == 2: # raise
        v90 = v2 - (<signed long>1)
        v91 = v6 + (<signed long>4)
        v92 = method25(v1, v7, v8, v91, v4, v5, v6, v90)
        v93 = v5 == (<unsigned char>0)
        if v93:
            v94 = method4(v12)
            v95 = len(v92)
            v96 = numpy.empty(v95,dtype=numpy.int64)
            v97 = (<unsigned long long>0)
            method14(v95, v92, v96, v97)
            del v92
            v98 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v99 = len(v98)
            v100 = (<unsigned long long>0)
            method16(v99, v98, v100)
            v101 = len(v94)
            v102 = (<unsigned long long>2) < v101
            if v102:
                raise Exception("The given array is too large.")
            else:
                pass
            v103 = (<unsigned long long>0)
            method17(v101, v98, v94, v103)
            del v94
            pass # import torch
            v104 = torch.from_numpy(v98)
            del v98
            v105 = v0.forward(v104)
            del v104
            v106 = v105[v96]
            del v105
            pass # import torch.nn.functional
            v107 = torch.nn.functional.softmax(v106,-1)
            del v106
            pass # import torch.distributions
            v108 = torch.distributions.Categorical(probs=v107)
            del v107
            v109 = v108.sample()
            v110 = v108.log_prob(v109)
            del v108
            v111 = v110.item()
            del v110
            v112 = v109.item()
            del v109
            v113 = v112
            v114 = v96[v113]
            del v96
            v115 = method19(v114)
            v116 = v111 + v13
            v117 = US2_0(v115)
            v118 = UH0_0(v117, v12)
            del v117
            v119 = US2_0(v115)
            v120 = UH0_0(v119, v14)
            del v119
            return method26(v0, v1, v90, v3, v7, v8, v91, v4, v5, v6, v115, v11, v118, v116, v120, v15, v16)
        else:
            v122 = numpy.random.choice(v92)
            v123 = len(v92)
            del v92
            v124 = <double>v123
            v125 = (<double>1.000000) / v124
            v126 = libc.math.log(v125)
            v127 = v126 + v15
            v128 = US2_0(v122)
            v129 = UH0_0(v128, v12)
            del v128
            v130 = US2_0(v122)
            v131 = UH0_0(v130, v14)
            del v130
            return method26(v0, v1, v90, v3, v7, v8, v91, v4, v5, v6, v122, v11, v129, v13, v131, v127, v16)
cdef double method24(v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14, v15):
    cdef signed long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef bint v18
    cdef numpy.ndarray[object,ndim=1] v19
    cdef unsigned long long v20
    cdef numpy.ndarray[signed long long,ndim=1] v21
    cdef unsigned long long v22
    cdef numpy.ndarray[float,ndim=1] v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef bint v27
    cdef unsigned long long v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef object v34
    cdef object v35
    cdef double v36
    cdef signed long long v37
    cdef unsigned long long v38
    cdef signed long long v39
    cdef US0 v40
    cdef double v41
    cdef US2 v42
    cdef UH0 v43
    cdef US2 v44
    cdef UH0 v45
    cdef US0 v47
    cdef unsigned long long v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef double v52
    cdef US2 v53
    cdef UH0 v54
    cdef US2 v55
    cdef UH0 v56
    cdef object v59
    cdef signed long v61
    cdef signed long v62
    cdef numpy.ndarray[signed long,ndim=1] v63
    cdef bint v64
    cdef numpy.ndarray[object,ndim=1] v65
    cdef unsigned long long v66
    cdef numpy.ndarray[signed long long,ndim=1] v67
    cdef unsigned long long v68
    cdef numpy.ndarray[float,ndim=1] v69
    cdef unsigned long long v70
    cdef unsigned long long v71
    cdef unsigned long long v72
    cdef bint v73
    cdef unsigned long long v74
    cdef object v75
    cdef object v76
    cdef object v77
    cdef object v78
    cdef object v79
    cdef object v80
    cdef object v81
    cdef double v82
    cdef signed long long v83
    cdef unsigned long long v84
    cdef signed long long v85
    cdef US0 v86
    cdef double v87
    cdef US2 v88
    cdef UH0 v89
    cdef US2 v90
    cdef UH0 v91
    cdef US0 v93
    cdef unsigned long long v94
    cdef double v95
    cdef double v96
    cdef double v97
    cdef double v98
    cdef US2 v99
    cdef UH0 v100
    cdef US2 v101
    cdef UH0 v102
    if v9 == 0: # call
        v16 = (<signed long>2)
        v17 = method25(v1, v5, v6, v7, v2, v3, v4, v16)
        v18 = v3 == (<unsigned char>0)
        if v18:
            v19 = method4(v11)
            v20 = len(v17)
            v21 = numpy.empty(v20,dtype=numpy.int64)
            v22 = (<unsigned long long>0)
            method14(v20, v17, v21, v22)
            del v17
            v23 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v24 = len(v23)
            v25 = (<unsigned long long>0)
            method16(v24, v23, v25)
            v26 = len(v19)
            v27 = (<unsigned long long>2) < v26
            if v27:
                raise Exception("The given array is too large.")
            else:
                pass
            v28 = (<unsigned long long>0)
            method17(v26, v23, v19, v28)
            del v19
            pass # import torch
            v29 = torch.from_numpy(v23)
            del v23
            v30 = v0.forward(v29)
            del v29
            v31 = v30[v21]
            del v30
            pass # import torch.nn.functional
            v32 = torch.nn.functional.softmax(v31,-1)
            del v31
            pass # import torch.distributions
            v33 = torch.distributions.Categorical(probs=v32)
            del v32
            v34 = v33.sample()
            v35 = v33.log_prob(v34)
            del v33
            v36 = v35.item()
            del v35
            v37 = v34.item()
            del v34
            v38 = v37
            v39 = v21[v38]
            del v21
            v40 = method19(v39)
            v41 = v36 + v12
            v42 = US2_0(v40)
            v43 = UH0_0(v42, v11)
            del v42
            v44 = US2_0(v40)
            v45 = UH0_0(v44, v13)
            del v44
            return method26(v0, v1, v16, v8, v5, v6, v7, v2, v3, v4, v40, v10, v43, v41, v45, v14, v15)
        else:
            v47 = numpy.random.choice(v17)
            v48 = len(v17)
            del v17
            v49 = <double>v48
            v50 = (<double>1.000000) / v49
            v51 = libc.math.log(v50)
            v52 = v51 + v14
            v53 = US2_0(v47)
            v54 = UH0_0(v53, v11)
            del v53
            v55 = US2_0(v47)
            v56 = UH0_0(v55, v13)
            del v55
            return method26(v0, v1, v16, v8, v5, v6, v7, v2, v3, v4, v47, v10, v54, v12, v56, v52, v15)
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v61 = (<signed long>1)
        v62 = v4 + (<signed long>4)
        v63 = method25(v1, v5, v6, v62, v2, v3, v4, v61)
        v64 = v3 == (<unsigned char>0)
        if v64:
            v65 = method4(v11)
            v66 = len(v63)
            v67 = numpy.empty(v66,dtype=numpy.int64)
            v68 = (<unsigned long long>0)
            method14(v66, v63, v67, v68)
            del v63
            v69 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v70 = len(v69)
            v71 = (<unsigned long long>0)
            method16(v70, v69, v71)
            v72 = len(v65)
            v73 = (<unsigned long long>2) < v72
            if v73:
                raise Exception("The given array is too large.")
            else:
                pass
            v74 = (<unsigned long long>0)
            method17(v72, v69, v65, v74)
            del v65
            pass # import torch
            v75 = torch.from_numpy(v69)
            del v69
            v76 = v0.forward(v75)
            del v75
            v77 = v76[v67]
            del v76
            pass # import torch.nn.functional
            v78 = torch.nn.functional.softmax(v77,-1)
            del v77
            pass # import torch.distributions
            v79 = torch.distributions.Categorical(probs=v78)
            del v78
            v80 = v79.sample()
            v81 = v79.log_prob(v80)
            del v79
            v82 = v81.item()
            del v81
            v83 = v80.item()
            del v80
            v84 = v83
            v85 = v67[v84]
            del v67
            v86 = method19(v85)
            v87 = v82 + v12
            v88 = US2_0(v86)
            v89 = UH0_0(v88, v11)
            del v88
            v90 = US2_0(v86)
            v91 = UH0_0(v90, v13)
            del v90
            return method26(v0, v1, v61, v8, v5, v6, v62, v2, v3, v4, v86, v10, v89, v87, v91, v14, v15)
        else:
            v93 = numpy.random.choice(v63)
            v94 = len(v63)
            del v63
            v95 = <double>v94
            v96 = (<double>1.000000) / v95
            v97 = libc.math.log(v96)
            v98 = v97 + v14
            v99 = US2_0(v93)
            v100 = UH0_0(v99, v11)
            del v99
            v101 = US2_0(v93)
            v102 = UH0_0(v101, v13)
            del v101
            return method26(v0, v1, v61, v8, v5, v6, v62, v2, v3, v4, v93, v10, v100, v12, v102, v98, v15)
cdef double method23(v0, Heap0 v1, US1 v2, unsigned char v3, signed long v4, US1 v5, unsigned char v6, signed long v7, US1 v8, double v9, UH0 v10, double v11, UH0 v12, double v13, v14):
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef bint v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef numpy.ndarray[signed long long,ndim=1] v19
    cdef unsigned long long v20
    cdef numpy.ndarray[float,ndim=1] v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    cdef unsigned long long v26
    cdef object v27
    cdef object v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef double v34
    cdef signed long long v35
    cdef unsigned long long v36
    cdef signed long long v37
    cdef US0 v38
    cdef double v39
    cdef US2 v40
    cdef UH0 v41
    cdef US2 v42
    cdef UH0 v43
    cdef US0 v45
    cdef unsigned long long v46
    cdef double v47
    cdef double v48
    cdef double v49
    cdef double v50
    cdef US2 v51
    cdef UH0 v52
    cdef US2 v53
    cdef UH0 v54
    v15 = v1.v2
    v16 = v6 == (<unsigned char>0)
    if v16:
        v17 = method4(v10)
        v18 = len(v15)
        v19 = numpy.empty(v18,dtype=numpy.int64)
        v20 = (<unsigned long long>0)
        method14(v18, v15, v19, v20)
        del v15
        v21 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
        v22 = len(v21)
        v23 = (<unsigned long long>0)
        method16(v22, v21, v23)
        v24 = len(v17)
        v25 = (<unsigned long long>2) < v24
        if v25:
            raise Exception("The given array is too large.")
        else:
            pass
        v26 = (<unsigned long long>0)
        method17(v24, v21, v17, v26)
        del v17
        pass # import torch
        v27 = torch.from_numpy(v21)
        del v21
        v28 = v0.forward(v27)
        del v27
        v29 = v28[v19]
        del v28
        pass # import torch.nn.functional
        v30 = torch.nn.functional.softmax(v29,-1)
        del v29
        pass # import torch.distributions
        v31 = torch.distributions.Categorical(probs=v30)
        del v30
        v32 = v31.sample()
        v33 = v31.log_prob(v32)
        del v31
        v34 = v33.item()
        del v33
        v35 = v32.item()
        del v32
        v36 = v35
        v37 = v19[v36]
        del v19
        v38 = method19(v37)
        v39 = v34 + v11
        v40 = US2_0(v38)
        v41 = UH0_0(v40, v10)
        del v40
        v42 = US2_0(v38)
        v43 = UH0_0(v42, v12)
        del v42
        return method24(v0, v1, v2, v3, v4, v5, v6, v7, v8, v38, v9, v41, v39, v43, v13, v14)
    else:
        v45 = numpy.random.choice(v15)
        v46 = len(v15)
        del v15
        v47 = <double>v46
        v48 = (<double>1.000000) / v47
        v49 = libc.math.log(v48)
        v50 = v49 + v13
        v51 = US2_0(v45)
        v52 = UH0_0(v51, v10)
        del v51
        v53 = US2_0(v45)
        v54 = UH0_0(v53, v12)
        del v53
        return method24(v0, v1, v2, v3, v4, v5, v6, v7, v8, v45, v9, v52, v11, v54, v50, v14)
cdef double method28(v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, signed long v9, US0 v10, double v11, UH0 v12, double v13, UH0 v14, double v15, v16):
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
    cdef double v27
    cdef double v28
    cdef double v29
    cdef double v30
    cdef US2 v31
    cdef UH0 v32
    cdef US2 v33
    cdef UH0 v34
    cdef bint v36
    cdef signed long v38
    cdef bint v39
    cdef signed long v41
    cdef signed long v42
    cdef signed long v44
    cdef signed long v45
    cdef US1 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef US1 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef double v52
    cdef signed long v54
    cdef signed long v55
    cdef numpy.ndarray[signed long,ndim=1] v56
    cdef bint v57
    cdef numpy.ndarray[object,ndim=1] v58
    cdef unsigned long long v59
    cdef numpy.ndarray[signed long long,ndim=1] v60
    cdef unsigned long long v61
    cdef numpy.ndarray[float,ndim=1] v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    cdef unsigned long long v65
    cdef bint v66
    cdef unsigned long long v67
    cdef object v68
    cdef object v69
    cdef object v70
    cdef object v71
    cdef object v72
    cdef object v73
    cdef object v74
    cdef double v75
    cdef signed long long v76
    cdef unsigned long long v77
    cdef signed long long v78
    cdef US0 v79
    cdef double v80
    cdef US2 v81
    cdef UH0 v82
    cdef US2 v83
    cdef UH0 v84
    cdef US0 v86
    cdef unsigned long long v87
    cdef double v88
    cdef double v89
    cdef double v90
    cdef double v91
    cdef US2 v92
    cdef UH0 v93
    cdef US2 v94
    cdef UH0 v95
    if v10 == 0: # call
        v17 = v8 == (<unsigned char>0)
        if v17:
            v18, v19, v20, v21, v22, v23 = v7, v8, v6, v4, v5, v6
        else:
            v18, v19, v20, v21, v22, v23 = v4, v5, v6, v7, v8, v6
        v24 = len(v2)
        v25 = numpy.random.randint(0,v24)
        v26 = v2[v25]
        v27 = <double>v24
        v28 = (<double>1.000000) / v27
        v29 = libc.math.log(v28)
        v30 = v29 + v11
        v31 = US2_1(v26)
        v32 = UH0_0(v31, v12)
        del v31
        v33 = US2_1(v26)
        v34 = UH0_0(v33, v14)
        del v33
        return method23(v0, v1, v21, v22, v23, v18, v19, v20, v26, v30, v32, v13, v34, v15, v16)
    elif v10 == 1: # fold
        v36 = v5 == (<unsigned char>0)
        if v36:
            v38 = v9
        else:
            v38 = -v9
        v39 = v8 == (<unsigned char>0)
        if v39:
            v41 = v38
        else:
            v41 = -v38
        v42 = v41 + v9
        if v36:
            v44 = v38
        else:
            v44 = -v38
        v45 = v44 + v6
        if v39:
            v46, v47, v48, v49, v50, v51 = v7, v8, v42, v4, v5, v45
        else:
            v46, v47, v48, v49, v50, v51 = v4, v5, v45, v7, v8, v42
        v52 = <double>v38
        return v16(v52)
    elif v10 == 2: # raise
        v54 = v3 - (<signed long>1)
        v55 = v6 + (<signed long>2)
        v56 = method25(v1, v7, v8, v55, v4, v5, v6, v54)
        v57 = v5 == (<unsigned char>0)
        if v57:
            v58 = method4(v12)
            v59 = len(v56)
            v60 = numpy.empty(v59,dtype=numpy.int64)
            v61 = (<unsigned long long>0)
            method14(v59, v56, v60, v61)
            del v56
            v62 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v63 = len(v62)
            v64 = (<unsigned long long>0)
            method16(v63, v62, v64)
            v65 = len(v58)
            v66 = (<unsigned long long>2) < v65
            if v66:
                raise Exception("The given array is too large.")
            else:
                pass
            v67 = (<unsigned long long>0)
            method17(v65, v62, v58, v67)
            del v58
            pass # import torch
            v68 = torch.from_numpy(v62)
            del v62
            v69 = v0.forward(v68)
            del v68
            v70 = v69[v60]
            del v69
            pass # import torch.nn.functional
            v71 = torch.nn.functional.softmax(v70,-1)
            del v70
            pass # import torch.distributions
            v72 = torch.distributions.Categorical(probs=v71)
            del v71
            v73 = v72.sample()
            v74 = v72.log_prob(v73)
            del v72
            v75 = v74.item()
            del v74
            v76 = v73.item()
            del v73
            v77 = v76
            v78 = v60[v77]
            del v60
            v79 = method19(v78)
            v80 = v75 + v13
            v81 = US2_0(v79)
            v82 = UH0_0(v81, v12)
            del v81
            v83 = US2_0(v79)
            v84 = UH0_0(v83, v14)
            del v83
            return method28(v0, v1, v2, v54, v7, v8, v55, v4, v5, v6, v79, v11, v82, v80, v84, v15, v16)
        else:
            v86 = numpy.random.choice(v56)
            v87 = len(v56)
            del v56
            v88 = <double>v87
            v89 = (<double>1.000000) / v88
            v90 = libc.math.log(v89)
            v91 = v90 + v15
            v92 = US2_0(v86)
            v93 = UH0_0(v92, v12)
            del v92
            v94 = US2_0(v86)
            v95 = UH0_0(v94, v14)
            del v94
            return method28(v0, v1, v2, v54, v7, v8, v55, v4, v5, v6, v86, v11, v93, v13, v95, v91, v16)
cdef double method22(v0, Heap0 v1, numpy.ndarray[signed long,ndim=1] v2, signed long v3, US1 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, US0 v9, double v10, UH0 v11, double v12, UH0 v13, double v14, v15):
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
    cdef double v26
    cdef double v27
    cdef double v28
    cdef double v29
    cdef US2 v30
    cdef UH0 v31
    cdef US2 v32
    cdef UH0 v33
    cdef bint v35
    cdef signed long v37
    cdef bint v38
    cdef signed long v40
    cdef signed long v41
    cdef signed long v43
    cdef signed long v44
    cdef US1 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US1 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef double v51
    cdef signed long v53
    cdef signed long v54
    cdef numpy.ndarray[signed long,ndim=1] v55
    cdef bint v56
    cdef numpy.ndarray[object,ndim=1] v57
    cdef unsigned long long v58
    cdef numpy.ndarray[signed long long,ndim=1] v59
    cdef unsigned long long v60
    cdef numpy.ndarray[float,ndim=1] v61
    cdef unsigned long long v62
    cdef unsigned long long v63
    cdef unsigned long long v64
    cdef bint v65
    cdef unsigned long long v66
    cdef object v67
    cdef object v68
    cdef object v69
    cdef object v70
    cdef object v71
    cdef object v72
    cdef object v73
    cdef double v74
    cdef signed long long v75
    cdef unsigned long long v76
    cdef signed long long v77
    cdef US0 v78
    cdef double v79
    cdef US2 v80
    cdef UH0 v81
    cdef US2 v82
    cdef UH0 v83
    cdef US0 v85
    cdef unsigned long long v86
    cdef double v87
    cdef double v88
    cdef double v89
    cdef double v90
    cdef US2 v91
    cdef UH0 v92
    cdef US2 v93
    cdef UH0 v94
    if v9 == 0: # call
        v16 = v8 == (<unsigned char>0)
        if v16:
            v17, v18, v19, v20, v21, v22 = v7, v8, v6, v4, v5, v6
        else:
            v17, v18, v19, v20, v21, v22 = v4, v5, v6, v7, v8, v6
        v23 = len(v2)
        v24 = numpy.random.randint(0,v23)
        v25 = v2[v24]
        v26 = <double>v23
        v27 = (<double>1.000000) / v26
        v28 = libc.math.log(v27)
        v29 = v28 + v10
        v30 = US2_1(v25)
        v31 = UH0_0(v30, v11)
        del v30
        v32 = US2_1(v25)
        v33 = UH0_0(v32, v13)
        del v32
        return method23(v0, v1, v20, v21, v22, v17, v18, v19, v25, v29, v31, v12, v33, v14, v15)
    elif v9 == 1: # fold
        v35 = v5 == (<unsigned char>0)
        if v35:
            v37 = v6
        else:
            v37 = -v6
        v38 = v8 == (<unsigned char>0)
        if v38:
            v40 = v37
        else:
            v40 = -v37
        v41 = v40 + v6
        if v35:
            v43 = v37
        else:
            v43 = -v37
        v44 = v43 + v6
        if v38:
            v45, v46, v47, v48, v49, v50 = v7, v8, v41, v4, v5, v44
        else:
            v45, v46, v47, v48, v49, v50 = v4, v5, v44, v7, v8, v41
        v51 = <double>v37
        return v15(v51)
    elif v9 == 2: # raise
        v53 = v3 - (<signed long>1)
        v54 = v6 + (<signed long>2)
        v55 = method25(v1, v7, v8, v54, v4, v5, v6, v53)
        v56 = v5 == (<unsigned char>0)
        if v56:
            v57 = method4(v11)
            v58 = len(v55)
            v59 = numpy.empty(v58,dtype=numpy.int64)
            v60 = (<unsigned long long>0)
            method14(v58, v55, v59, v60)
            del v55
            v61 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v62 = len(v61)
            v63 = (<unsigned long long>0)
            method16(v62, v61, v63)
            v64 = len(v57)
            v65 = (<unsigned long long>2) < v64
            if v65:
                raise Exception("The given array is too large.")
            else:
                pass
            v66 = (<unsigned long long>0)
            method17(v64, v61, v57, v66)
            del v57
            pass # import torch
            v67 = torch.from_numpy(v61)
            del v61
            v68 = v0.forward(v67)
            del v67
            v69 = v68[v59]
            del v68
            pass # import torch.nn.functional
            v70 = torch.nn.functional.softmax(v69,-1)
            del v69
            pass # import torch.distributions
            v71 = torch.distributions.Categorical(probs=v70)
            del v70
            v72 = v71.sample()
            v73 = v71.log_prob(v72)
            del v71
            v74 = v73.item()
            del v73
            v75 = v72.item()
            del v72
            v76 = v75
            v77 = v59[v76]
            del v59
            v78 = method19(v77)
            v79 = v74 + v12
            v80 = US2_0(v78)
            v81 = UH0_0(v80, v11)
            del v80
            v82 = US2_0(v78)
            v83 = UH0_0(v82, v13)
            del v82
            return method28(v0, v1, v2, v53, v7, v8, v54, v4, v5, v6, v78, v10, v81, v79, v83, v14, v15)
        else:
            v85 = numpy.random.choice(v55)
            v86 = len(v55)
            del v55
            v87 = <double>v86
            v88 = (<double>1.000000) / v87
            v89 = libc.math.log(v88)
            v90 = v89 + v14
            v91 = US2_0(v85)
            v92 = UH0_0(v91, v11)
            del v91
            v93 = US2_0(v85)
            v94 = UH0_0(v93, v13)
            del v93
            return method28(v0, v1, v2, v53, v7, v8, v54, v4, v5, v6, v85, v10, v92, v12, v94, v90, v15)
cdef double method20(v0, US1 v1, US1 v2, Heap0 v3, numpy.ndarray[signed long,ndim=1] v4, US0 v5, double v6, UH0 v7, double v8, UH0 v9, double v10, v11):
    cdef signed long v12
    cdef unsigned char v13
    cdef signed long v14
    cdef unsigned char v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef bint v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef unsigned long long v19
    cdef numpy.ndarray[signed long long,ndim=1] v20
    cdef unsigned long long v21
    cdef numpy.ndarray[float,ndim=1] v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef bint v26
    cdef unsigned long long v27
    cdef object v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef object v34
    cdef double v35
    cdef signed long long v36
    cdef unsigned long long v37
    cdef signed long long v38
    cdef US0 v39
    cdef double v40
    cdef US2 v41
    cdef UH0 v42
    cdef US2 v43
    cdef UH0 v44
    cdef US0 v46
    cdef unsigned long long v47
    cdef double v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef US2 v52
    cdef UH0 v53
    cdef US2 v54
    cdef UH0 v55
    cdef object v58
    cdef signed long v60
    cdef unsigned char v61
    cdef signed long v62
    cdef unsigned char v63
    cdef signed long v64
    cdef numpy.ndarray[signed long,ndim=1] v65
    cdef bint v66
    cdef numpy.ndarray[object,ndim=1] v67
    cdef unsigned long long v68
    cdef numpy.ndarray[signed long long,ndim=1] v69
    cdef unsigned long long v70
    cdef numpy.ndarray[float,ndim=1] v71
    cdef unsigned long long v72
    cdef unsigned long long v73
    cdef unsigned long long v74
    cdef bint v75
    cdef unsigned long long v76
    cdef object v77
    cdef object v78
    cdef object v79
    cdef object v80
    cdef object v81
    cdef object v82
    cdef object v83
    cdef double v84
    cdef signed long long v85
    cdef unsigned long long v86
    cdef signed long long v87
    cdef US0 v88
    cdef double v89
    cdef US2 v90
    cdef UH0 v91
    cdef US2 v92
    cdef UH0 v93
    cdef US0 v95
    cdef unsigned long long v96
    cdef double v97
    cdef double v98
    cdef double v99
    cdef double v100
    cdef US2 v101
    cdef UH0 v102
    cdef US2 v103
    cdef UH0 v104
    if v5 == 0: # call
        v12 = (<signed long>2)
        v13 = (<unsigned char>1)
        v14 = (<signed long>1)
        v15 = (<unsigned char>0)
        v16 = method21(v3, v1, v15, v14, v2, v13, v12)
        v17 = v13 == (<unsigned char>0)
        if v17:
            v18 = method4(v7)
            v19 = len(v16)
            v20 = numpy.empty(v19,dtype=numpy.int64)
            v21 = (<unsigned long long>0)
            method14(v19, v16, v20, v21)
            del v16
            v22 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v23 = len(v22)
            v24 = (<unsigned long long>0)
            method16(v23, v22, v24)
            v25 = len(v18)
            v26 = (<unsigned long long>2) < v25
            if v26:
                raise Exception("The given array is too large.")
            else:
                pass
            v27 = (<unsigned long long>0)
            method17(v25, v22, v18, v27)
            del v18
            pass # import torch
            v28 = torch.from_numpy(v22)
            del v22
            v29 = v0.forward(v28)
            del v28
            v30 = v29[v20]
            del v29
            pass # import torch.nn.functional
            v31 = torch.nn.functional.softmax(v30,-1)
            del v30
            pass # import torch.distributions
            v32 = torch.distributions.Categorical(probs=v31)
            del v31
            v33 = v32.sample()
            v34 = v32.log_prob(v33)
            del v32
            v35 = v34.item()
            del v34
            v36 = v33.item()
            del v33
            v37 = v36
            v38 = v20[v37]
            del v20
            v39 = method19(v38)
            v40 = v35 + v8
            v41 = US2_0(v39)
            v42 = UH0_0(v41, v7)
            del v41
            v43 = US2_0(v39)
            v44 = UH0_0(v43, v9)
            del v43
            return method22(v0, v3, v4, v12, v1, v15, v14, v2, v13, v39, v6, v42, v40, v44, v10, v11)
        else:
            v46 = numpy.random.choice(v16)
            v47 = len(v16)
            del v16
            v48 = <double>v47
            v49 = (<double>1.000000) / v48
            v50 = libc.math.log(v49)
            v51 = v50 + v10
            v52 = US2_0(v46)
            v53 = UH0_0(v52, v7)
            del v52
            v54 = US2_0(v46)
            v55 = UH0_0(v54, v9)
            del v54
            return method22(v0, v3, v4, v12, v1, v15, v14, v2, v13, v46, v6, v53, v8, v55, v51, v11)
    elif v5 == 1: # fold
        raise Exception("impossible")
    elif v5 == 2: # raise
        v60 = (<signed long>1)
        v61 = (<unsigned char>1)
        v62 = (<signed long>1)
        v63 = (<unsigned char>0)
        v64 = (<signed long>3)
        v65 = method25(v3, v1, v63, v64, v2, v61, v62, v60)
        v66 = v61 == (<unsigned char>0)
        if v66:
            v67 = method4(v7)
            v68 = len(v65)
            v69 = numpy.empty(v68,dtype=numpy.int64)
            v70 = (<unsigned long long>0)
            method14(v68, v65, v69, v70)
            del v65
            v71 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
            v72 = len(v71)
            v73 = (<unsigned long long>0)
            method16(v72, v71, v73)
            v74 = len(v67)
            v75 = (<unsigned long long>2) < v74
            if v75:
                raise Exception("The given array is too large.")
            else:
                pass
            v76 = (<unsigned long long>0)
            method17(v74, v71, v67, v76)
            del v67
            pass # import torch
            v77 = torch.from_numpy(v71)
            del v71
            v78 = v0.forward(v77)
            del v77
            v79 = v78[v69]
            del v78
            pass # import torch.nn.functional
            v80 = torch.nn.functional.softmax(v79,-1)
            del v79
            pass # import torch.distributions
            v81 = torch.distributions.Categorical(probs=v80)
            del v80
            v82 = v81.sample()
            v83 = v81.log_prob(v82)
            del v81
            v84 = v83.item()
            del v83
            v85 = v82.item()
            del v82
            v86 = v85
            v87 = v69[v86]
            del v69
            v88 = method19(v87)
            v89 = v84 + v8
            v90 = US2_0(v88)
            v91 = UH0_0(v90, v7)
            del v90
            v92 = US2_0(v88)
            v93 = UH0_0(v92, v9)
            del v92
            return method28(v0, v3, v4, v60, v1, v63, v64, v2, v61, v62, v88, v6, v91, v89, v93, v10, v11)
        else:
            v95 = numpy.random.choice(v65)
            v96 = len(v65)
            del v65
            v97 = <double>v96
            v98 = (<double>1.000000) / v97
            v99 = libc.math.log(v98)
            v100 = v99 + v10
            v101 = US2_0(v95)
            v102 = UH0_0(v101, v7)
            del v101
            v103 = US2_0(v95)
            v104 = UH0_0(v103, v9)
            del v103
            return method28(v0, v3, v4, v60, v1, v63, v64, v2, v61, v62, v95, v6, v102, v8, v104, v100, v11)
cdef double method3(v0, Heap0 v1, US1 v2, US1 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, UH0 v8, double v9, v10):
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef unsigned long long v13
    cdef numpy.ndarray[signed long long,ndim=1] v14
    cdef unsigned long long v15
    cdef numpy.ndarray[float,ndim=1] v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef bint v20
    cdef unsigned long long v21
    cdef object v22
    cdef object v23
    cdef object v24
    cdef object v25
    cdef object v26
    cdef object v27
    cdef object v28
    cdef double v29
    cdef signed long long v30
    cdef unsigned long long v31
    cdef signed long long v32
    cdef US0 v33
    cdef double v34
    cdef US2 v35
    cdef UH0 v36
    cdef US2 v37
    cdef UH0 v38
    v11 = v1.v2
    v12 = method4(v6)
    v13 = len(v11)
    v14 = numpy.empty(v13,dtype=numpy.int64)
    v15 = (<unsigned long long>0)
    method14(v13, v11, v14, v15)
    del v11
    v16 = numpy.empty((<unsigned long long>30),dtype=numpy.float32)
    v17 = len(v16)
    v18 = (<unsigned long long>0)
    method16(v17, v16, v18)
    v19 = len(v12)
    v20 = (<unsigned long long>2) < v19
    if v20:
        raise Exception("The given array is too large.")
    else:
        pass
    v21 = (<unsigned long long>0)
    method17(v19, v16, v12, v21)
    del v12
    pass # import torch
    v22 = torch.from_numpy(v16)
    del v16
    v23 = v0.forward(v22)
    del v22
    v24 = v23[v14]
    del v23
    pass # import torch.nn.functional
    v25 = torch.nn.functional.softmax(v24,-1)
    del v24
    pass # import torch.distributions
    v26 = torch.distributions.Categorical(probs=v25)
    del v25
    v27 = v26.sample()
    v28 = v26.log_prob(v27)
    del v26
    v29 = v28.item()
    del v28
    v30 = v27.item()
    del v27
    v31 = v30
    v32 = v14[v31]
    del v14
    v33 = method19(v32)
    v34 = v29 + v7
    v35 = US2_0(v33)
    v36 = UH0_0(v35, v6)
    del v35
    v37 = US2_0(v33)
    v38 = UH0_0(v37, v8)
    del v37
    return method20(v0, v2, v3, v1, v4, v33, v5, v36, v34, v38, v9, v10)
cdef double method2(v0, Heap0 v1, US1 v2, numpy.ndarray[signed long,ndim=1] v3, double v4, UH0 v5, double v6, UH0 v7, double v8, v9):
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef US1 v12
    cdef unsigned long long v13
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef unsigned long long v15
    cdef double v16
    cdef double v17
    cdef double v18
    cdef double v19
    cdef US2 v20
    cdef UH0 v21
    v10 = len(v3)
    v11 = numpy.random.randint(0,v10)
    v12 = v3[v11]
    v13 = v10 - (<unsigned long long>1)
    v14 = numpy.empty(v13,dtype=numpy.int32)
    v15 = (<unsigned long long>0)
    method1(v13, v11, v3, v14, v15)
    v16 = <double>v10
    v17 = (<double>1.000000) / v16
    v18 = libc.math.log(v17)
    v19 = v18 + v4
    v20 = US2_1(v12)
    v21 = UH0_0(v20, v7)
    del v20
    return method3(v0, v1, v2, v12, v14, v19, v5, v6, v21, v8, v9)
cdef void method0(v0, unsigned long v1):
    cdef bint v2
    cdef unsigned long v3
    cdef US0 v4
    cdef US0 v5
    cdef numpy.ndarray[signed long,ndim=1] v6
    cdef US0 v7
    cdef US0 v8
    cdef US0 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef US0 v11
    cdef US0 v12
    cdef numpy.ndarray[signed long,ndim=1] v13
    cdef US0 v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef Heap0 v16
    cdef US1 v17
    cdef US1 v18
    cdef US1 v19
    cdef US1 v20
    cdef US1 v21
    cdef US1 v22
    cdef numpy.ndarray[signed long,ndim=1] v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef UH0 v26
    cdef double v27
    cdef UH0 v28
    cdef double v29
    cdef US1 v30
    cdef unsigned long long v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef unsigned long long v33
    cdef double v34
    cdef double v35
    cdef double v36
    cdef US2 v37
    cdef UH0 v38
    cdef object v39
    cdef double v40
    v2 = v1 < (<unsigned long>100)
    if v2:
        v3 = v1 + (<unsigned long>1)
        v4 = 0
        v5 = 2
        v6 = numpy.empty(2,dtype=numpy.int32)
        v6[0] = v4; v6[1] = v5
        v7 = 1
        v8 = 0
        v9 = 2
        v10 = numpy.empty(3,dtype=numpy.int32)
        v10[0] = v7; v10[1] = v8; v10[2] = v9
        v11 = 1
        v12 = 0
        v13 = numpy.empty(2,dtype=numpy.int32)
        v13[0] = v11; v13[1] = v12
        v14 = 0
        v15 = numpy.empty(1,dtype=numpy.int32)
        v15[0] = v14
        v16 = Heap0(v15, v10, v6, v13)
        del v6; del v10; del v13; del v15
        v17 = 1
        v18 = 2
        v19 = 0
        v20 = 1
        v21 = 2
        v22 = 0
        v23 = numpy.empty(6,dtype=numpy.int32)
        v23[0] = v17; v23[1] = v18; v23[2] = v19; v23[3] = v20; v23[4] = v21; v23[5] = v22
        v24 = len(v23)
        v25 = numpy.random.randint(0,v24)
        v26 = UH0_1()
        v27 = (<double>0.000000)
        v28 = UH0_1()
        v29 = (<double>0.000000)
        v30 = v23[v25]
        v31 = v24 - (<unsigned long long>1)
        v32 = numpy.empty(v31,dtype=numpy.int32)
        v33 = (<unsigned long long>0)
        method1(v31, v25, v23, v32, v33)
        del v23
        v34 = <double>v24
        v35 = (<double>1.000000) / v34
        v36 = libc.math.log(v35)
        v37 = US2_1(v30)
        v38 = UH0_0(v37, v26)
        del v26; del v37
        v39 = Closure0()
        v40 = method2(v0, v16, v30, v32, v36, v38, v27, v28, v29, v39)
        del v16; del v28; del v32; del v38; del v39
        print("Reward for player one at iteration ", v1, " is ", v40)
        method0(v0, v3)
    else:
        pass
cpdef void main():
    cdef object v0
    cdef unsigned long v1
    pass # import nets
    v0 = nets.small((<unsigned long long>30),(<unsigned long long>64),(<signed long long>3))
    v1 = (<unsigned long>0)
    method0(v0, v1)
