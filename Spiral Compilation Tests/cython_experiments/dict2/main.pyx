import numpy
cimport numpy
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly str v0
    cdef readonly unsigned long v1
    cdef readonly UH0 v2
    def __init__(self, str v0, unsigned long v1, UH0 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly str v1
    cdef readonly unsigned long v2
    def __init__(self, unsigned long long v0, str v1, unsigned long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly str v0
    cdef readonly UH1 v1
    def __init__(self, str v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly unsigned long v0
    cdef readonly str v1
    cdef readonly UH2 v2
    def __init__(self, unsigned long v0, str v1, UH2 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Mut1:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple1:
    cdef readonly unsigned long v0
    cdef readonly str v1
    def __init__(self, unsigned long v0, str v1): self.v0 = v0; self.v1 = v1
cdef class UH3:
    cdef readonly signed long tag
cdef class UH3_0(UH3): # cons_
    cdef readonly str v0
    cdef readonly UH3 v1
    def __init__(self, str v0, UH3 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH3_1(UH3): # nil
    def __init__(self): self.tag = 1
cdef class Mut2:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly str v1
    def __init__(self, unsigned long long v0, str v1): self.v0 = v0; self.v1 = v1
cdef class UH4:
    cdef readonly signed long tag
cdef class UH4_0(UH4): # cons_
    cdef readonly unsigned long v0
    cdef readonly UH4 v1
    def __init__(self, unsigned long v0, UH4 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH4_1(UH4): # nil
    def __init__(self): self.tag = 1
cdef class Mut3:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef void method2(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method2(v0, v1, v4)
    else:
        pass
cdef Mut0 method1(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0
    method2(v1, v3, v4)
    v5 = Mut0(v0, v3, 0)
    del v3
    return v5
cdef void method7(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method7(v0, v1, v4)
    else:
        pass
cdef void method9(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef str v8
    cdef unsigned long v9
    cdef Tuple0 tmp1
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        tmp1 = v3[v4]
        v7, v8, v9 = tmp1.v0, tmp1.v1, tmp1.v2
        del tmp1
        v10 = v7 % v1
        v11 = v2[v10]
        v11.append(Tuple0(v7, v8, v9))
        del v8; del v11
        method9(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method8(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = len(v1)
        v9 = 0
        method9(v8, v2, v3, v7, v9)
        del v7
        method8(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method6(Mut0 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * 3
    v4 = v3 // 2
    v5 = v4 + 3
    v6 = v5 <= v2
    if v6:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0
    method7(v5, v7, v8)
    v9 = 0
    method8(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef unsigned long method5(Mut0 v0, str v1, unsigned long v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef str v9
    cdef unsigned long v10
    cdef Tuple0 tmp0
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v15
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef numpy.ndarray[object,ndim=1] v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp0 = v4[v5]
        v8, v9, v10 = tmp0.v0, tmp0.v1, tmp0.v2
        del tmp0
        v11 = v3 == v8
        if v11:
            v13 = v1 == v9
        else:
            v13 = 0
        del v9
        if v13:
            raise Exception("The key already exists in the dictionary.")
        else:
            v15 = v5 + 1
            return method5(v0, v1, v2, v3, v4, v15)
    else:
        v4.append(Tuple0(v3, v1, v2))
        v18 = v0.v2
        v19 = v18 + 1
        v0.v2 = v19
        v20 = v0.v2
        v21 = v0.v0
        v22 = v0.v1
        v23 = len(v22)
        del v22
        v24 = v21 * v23
        v25 = v20 >= v24
        if v25:
            method6(v0)
        else:
            pass
        return v2
cdef void method4(Mut0 v0, str v1, unsigned long v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef unsigned long v10
    v4 = hash(v1)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = 0
    v10 = method5(v0, v1, v2, v4, v8, v9)
    del v8
cdef void method3(Mut0 v0, UH0 v1):
    cdef str v2
    cdef unsigned long v3
    cdef UH0 v4
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v1).v2
        method4(v0, v2, v3)
        del v2
        method3(v0, v4)
    elif v1.tag == 1: # nil
        pass
cdef unsigned long method12(Mut0 v0, str v1, unsigned long long v2, list v3, unsigned long long v4):
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long long v7
    cdef str v8
    cdef unsigned long v9
    cdef Tuple0 tmp2
    cdef bint v10
    cdef bint v12
    cdef unsigned long long v13
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        tmp2 = v3[v4]
        v7, v8, v9 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        v10 = v2 == v7
        if v10:
            v12 = v1 == v8
        else:
            v12 = 0
        del v8
        if v12:
            return v9
        else:
            v13 = v4 + 1
            return method12(v0, v1, v2, v3, v13)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef unsigned long method11(Mut0 v0, str v1):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = 0
    return method12(v0, v1, v3, v7, v8)
cdef UH1 method10(Mut0 v0, UH0 v1, UH1 v2):
    cdef str v3
    cdef unsigned long v4
    cdef UH0 v5
    cdef UH1 v6
    cdef unsigned long v7
    cdef str v8
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1; v5 = (<UH0_0>v1).v2
        v6 = method10(v0, v5, v2)
        del v5
        v7 = method11(v0, v3)
        del v3
        v8 = str(v7)
        return UH1_0(v8, v6)
    elif v1.tag == 1: # nil
        return v2
cdef unsigned long long method14(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method14(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method15(list v0, UH1 v1, unsigned long long v2):
    cdef str v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method15(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef list method13(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef list v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method14(v0, v1)
    v3 = [None]*v2
    v4 = 0
    v5 = method15(v3, v0, v4)
    return v3
cdef void method0(UH0 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef Mut0 v3
    cdef UH1 v4
    cdef UH1 v5
    cdef list v6
    cdef str v7
    v1 = 3
    v2 = 7
    v3 = method1(v1, v2)
    method3(v3, v0)
    v4 = UH1_1()
    v5 = method10(v3, v0, v4)
    del v3; del v4
    v6 = method13(v5)
    del v5
    v7 = ", ".join(v6)
    del v6
    print(v7)
cdef void method18(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method18(v0, v1, v4)
    else:
        pass
cdef Mut1 method17(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0
    method18(v1, v3, v4)
    v5 = Mut1(v0, v3, 0)
    del v3
    return v5
cdef void method23(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method23(v0, v1, v4)
    else:
        pass
cdef void method25(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long v7
    cdef str v8
    cdef Tuple1 tmp4
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        tmp4 = v3[v4]
        v7, v8 = tmp4.v0, tmp4.v1
        del tmp4
        v9 = hash(v7)
        v10 = v9 % v1
        v11 = v2[v10]
        v11.append(Tuple1(v7, v8))
        del v8; del v11
        method25(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method24(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = len(v1)
        v9 = 0
        method25(v8, v2, v3, v7, v9)
        del v7
        method24(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method22(Mut1 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * 3
    v4 = v3 // 2
    v5 = v4 + 3
    v6 = v5 <= v2
    if v6:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0
    method23(v5, v7, v8)
    v9 = 0
    method24(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef str method21(Mut1 v0, unsigned long v1, str v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long v8
    cdef str v9
    cdef Tuple1 tmp3
    cdef unsigned long long v10
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v15
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef numpy.ndarray[object,ndim=1] v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef bint v25
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp3 = v4[v5]
        v8, v9 = tmp3.v0, tmp3.v1
        del tmp3
        del v9
        v10 = hash(v8)
        v11 = v3 == v10
        if v11:
            v13 = v1 == v8
        else:
            v13 = 0
        if v13:
            raise Exception("The key already exists in the dictionary.")
        else:
            v15 = v5 + 1
            return method21(v0, v1, v2, v3, v4, v15)
    else:
        v4.append(Tuple1(v1, v2))
        v18 = v0.v2
        v19 = v18 + 1
        v0.v2 = v19
        v20 = v0.v2
        v21 = v0.v0
        v22 = v0.v1
        v23 = len(v22)
        del v22
        v24 = v21 * v23
        v25 = v20 >= v24
        if v25:
            method22(v0)
        else:
            pass
        return v2
cdef void method20(Mut1 v0, unsigned long v1, str v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    cdef str v10
    v4 = hash(v1)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = 0
    v10 = method21(v0, v1, v2, v4, v8, v9)
    del v8; del v10
cdef void method19(Mut1 v0, UH2 v1):
    cdef unsigned long v2
    cdef str v3
    cdef UH2 v4
    if v1.tag == 0: # cons_
        v2 = (<UH2_0>v1).v0; v3 = (<UH2_0>v1).v1; v4 = (<UH2_0>v1).v2
        method20(v0, v2, v3)
        del v3
        method19(v0, v4)
    elif v1.tag == 1: # nil
        pass
cdef str method28(Mut1 v0, unsigned long v1, unsigned long long v2, list v3, unsigned long long v4):
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long v7
    cdef str v8
    cdef Tuple1 tmp5
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v12
    cdef unsigned long long v13
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        tmp5 = v3[v4]
        v7, v8 = tmp5.v0, tmp5.v1
        del tmp5
        v9 = hash(v7)
        v10 = v2 == v9
        if v10:
            v12 = v1 == v7
        else:
            v12 = 0
        if v12:
            return v8
        else:
            del v8
            v13 = v4 + 1
            return method28(v0, v1, v2, v3, v13)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef str method27(Mut1 v0, unsigned long v1):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = 0
    return method28(v0, v1, v3, v7, v8)
cdef UH1 method26(Mut1 v0, UH2 v1, UH1 v2):
    cdef unsigned long v3
    cdef UH2 v5
    cdef UH1 v6
    cdef str v7
    cdef str v8
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v5 = (<UH2_0>v1).v2
        v6 = method26(v0, v5, v2)
        del v5
        v7 = method27(v0, v3)
        v8 = str(v7)
        del v7
        return UH1_0(v8, v6)
    elif v1.tag == 1: # nil
        return v2
cdef void method16(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef Mut1 v3
    cdef UH1 v4
    cdef UH1 v5
    cdef list v6
    cdef str v7
    v1 = 3
    v2 = 7
    v3 = method17(v1, v2)
    method19(v3, v0)
    v4 = UH1_1()
    v5 = method26(v3, v0, v4)
    del v3; del v4
    v6 = method13(v5)
    del v5
    v7 = ", ".join(v6)
    del v6
    print(v7)
cdef void method31(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method31(v0, v1, v4)
    else:
        pass
cdef Mut2 method30(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut2 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0
    method31(v1, v3, v4)
    v5 = Mut2(v0, v3, 0)
    del v3
    return v5
cdef void method36(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method36(v0, v1, v4)
    else:
        pass
cdef void method38(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef str v8
    cdef Tuple2 tmp7
    cdef unsigned long long v9
    cdef list v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        tmp7 = v3[v4]
        v7, v8 = tmp7.v0, tmp7.v1
        del tmp7
        v9 = v7 % v1
        v10 = v2[v9]
        v10.append(Tuple2(v7, v8))
        del v8; del v10
        method38(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method37(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = len(v1)
        v9 = 0
        method38(v8, v2, v3, v7, v9)
        del v7
        method37(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method35(Mut2 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * 3
    v4 = v3 // 2
    v5 = v4 + 3
    v6 = v5 <= v2
    if v6:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0
    method36(v5, v7, v8)
    v9 = 0
    method37(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef void method34(Mut2 v0, str v1, unsigned long long v2, list v3, unsigned long long v4):
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long long v7
    cdef str v8
    cdef Tuple2 tmp6
    cdef bint v9
    cdef bint v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef bint v20
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        tmp6 = v3[v4]
        v7, v8 = tmp6.v0, tmp6.v1
        del tmp6
        v9 = v2 == v7
        if v9:
            v11 = v1 == v8
        else:
            v11 = 0
        del v8
        if v11:
            raise Exception("The key already exists in the dictionary.")
        else:
            v12 = v4 + 1
            method34(v0, v1, v2, v3, v12)
    else:
        v3.append(Tuple2(v2, v1))
        v13 = v0.v2
        v14 = v13 + 1
        v0.v2 = v14
        v15 = v0.v2
        v16 = v0.v0
        v17 = v0.v1
        v18 = len(v17)
        del v17
        v19 = v16 * v18
        v20 = v15 >= v19
        if v20:
            method35(v0)
        else:
            pass
cdef void method33(Mut2 v0, str v1):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = 0
    method34(v0, v1, v3, v7, v8)
cdef void method32(Mut2 v0, UH3 v1):
    cdef str v2
    cdef UH3 v3
    if v1.tag == 0: # cons_
        v2 = (<UH3_0>v1).v0; v3 = (<UH3_0>v1).v1
        method33(v0, v2)
        del v2
        method32(v0, v3)
    elif v1.tag == 1: # nil
        pass
cdef void method41(Mut2 v0, str v1, unsigned long long v2, list v3, unsigned long long v4):
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long long v7
    cdef str v8
    cdef Tuple2 tmp8
    cdef bint v9
    cdef bint v11
    cdef unsigned long long v12
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        tmp8 = v3[v4]
        v7, v8 = tmp8.v0, tmp8.v1
        del tmp8
        v9 = v2 == v7
        if v9:
            v11 = v1 == v8
        else:
            v11 = 0
        del v8
        if v11:
            pass
        else:
            v12 = v4 + 1
            method41(v0, v1, v2, v3, v12)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef void method40(Mut2 v0, str v1):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = 0
    method41(v0, v1, v3, v7, v8)
cdef UH1 method39(Mut2 v0, UH3 v1, UH1 v2):
    cdef str v3
    cdef UH3 v4
    cdef UH1 v5
    if v1.tag == 0: # cons_
        v3 = (<UH3_0>v1).v0; v4 = (<UH3_0>v1).v1
        v5 = method39(v0, v4, v2)
        del v4
        method40(v0, v3)
        del v3
        return UH1_0("()", v5)
    elif v1.tag == 1: # nil
        return v2
cdef void method29(UH3 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef Mut2 v3
    cdef UH1 v4
    cdef UH1 v5
    cdef list v6
    cdef str v7
    v1 = 3
    v2 = 7
    v3 = method30(v1, v2)
    method32(v3, v0)
    v4 = UH1_1()
    v5 = method39(v3, v0, v4)
    del v3; del v4
    v6 = method13(v5)
    del v5
    v7 = ", ".join(v6)
    del v6
    print(v7)
cdef void method44(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method44(v0, v1, v4)
    else:
        pass
cdef Mut3 method43(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut3 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0
    method44(v1, v3, v4)
    v5 = Mut3(v0, v3, 0)
    del v3
    return v5
cdef void method49(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method49(v0, v1, v4)
    else:
        pass
cdef void method51(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef list v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v3[v4]
        v8 = hash(v7)
        v9 = v8 % v1
        v10 = v2[v9]
        v10.append(v7)
        del v10
        method51(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method50(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = len(v1)
        v9 = 0
        method51(v8, v2, v3, v7, v9)
        del v7
        method50(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method48(Mut3 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * 3
    v4 = v3 // 2
    v5 = v4 + 3
    v6 = v5 <= v2
    if v6:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0
    method49(v5, v7, v8)
    v9 = 0
    method50(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef void method47(Mut3 v0, unsigned long v1, unsigned long long v2, list v3, unsigned long long v4):
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long v7
    cdef unsigned long long v8
    cdef bint v9
    cdef bint v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef bint v20
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        v7 = v3[v4]
        v8 = hash(v7)
        v9 = v2 == v8
        if v9:
            v11 = v1 == v7
        else:
            v11 = 0
        if v11:
            raise Exception("The key already exists in the dictionary.")
        else:
            v12 = v4 + 1
            method47(v0, v1, v2, v3, v12)
    else:
        v3.append(v1)
        v13 = v0.v2
        v14 = v13 + 1
        v0.v2 = v14
        v15 = v0.v2
        v16 = v0.v0
        v17 = v0.v1
        v18 = len(v17)
        del v17
        v19 = v16 * v18
        v20 = v15 >= v19
        if v20:
            method48(v0)
        else:
            pass
cdef void method46(Mut3 v0, unsigned long v1):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = 0
    method47(v0, v1, v3, v7, v8)
cdef void method45(Mut3 v0, UH4 v1):
    cdef unsigned long v2
    cdef UH4 v3
    if v1.tag == 0: # cons_
        v2 = (<UH4_0>v1).v0; v3 = (<UH4_0>v1).v1
        method46(v0, v2)
        method45(v0, v3)
    elif v1.tag == 1: # nil
        pass
cdef void method54(Mut3 v0, unsigned long v1, unsigned long long v2, list v3, unsigned long long v4):
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long v7
    cdef unsigned long long v8
    cdef bint v9
    cdef bint v11
    cdef unsigned long long v12
    v5 = len(v3)
    v6 = v4 < v5
    if v6:
        v7 = v3[v4]
        v8 = hash(v7)
        v9 = v2 == v8
        if v9:
            v11 = v1 == v7
        else:
            v11 = 0
        if v11:
            pass
        else:
            v12 = v4 + 1
            method54(v0, v1, v2, v3, v12)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef void method53(Mut3 v0, unsigned long v1):
    cdef unsigned long long v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    v3 = hash(v1)
    v4 = v0.v1
    v5 = len(v4)
    v6 = v3 % v5
    v7 = v4[v6]
    del v4
    v8 = 0
    method54(v0, v1, v3, v7, v8)
cdef UH1 method52(Mut3 v0, UH4 v1, UH1 v2):
    cdef unsigned long v3
    cdef UH4 v4
    cdef UH1 v5
    if v1.tag == 0: # cons_
        v3 = (<UH4_0>v1).v0; v4 = (<UH4_0>v1).v1
        v5 = method52(v0, v4, v2)
        del v4
        method53(v0, v3)
        return UH1_0("()", v5)
    elif v1.tag == 1: # nil
        return v2
cdef void method42(UH4 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef Mut3 v3
    cdef UH1 v4
    cdef UH1 v5
    cdef list v6
    cdef str v7
    v1 = 3
    v2 = 7
    v3 = method43(v1, v2)
    method45(v3, v0)
    v4 = UH1_1()
    v5 = method52(v3, v0, v4)
    del v3; del v4
    v6 = method13(v5)
    del v5
    v7 = ", ".join(v6)
    del v6
    print(v7)
cpdef void main():
    cdef str v0
    cdef unsigned long v1
    cdef str v2
    cdef unsigned long v3
    cdef str v4
    cdef unsigned long v5
    cdef UH0 v6
    cdef UH0 v7
    cdef UH0 v8
    cdef UH0 v9
    cdef unsigned long v10
    cdef str v11
    cdef unsigned long v12
    cdef str v13
    cdef unsigned long v14
    cdef str v15
    cdef UH2 v16
    cdef UH2 v17
    cdef UH2 v18
    cdef UH2 v19
    cdef str v20
    cdef str v21
    cdef str v22
    cdef UH3 v23
    cdef UH3 v24
    cdef UH3 v25
    cdef UH3 v26
    cdef unsigned long v27
    cdef unsigned long v28
    cdef unsigned long v29
    cdef UH4 v30
    cdef UH4 v31
    cdef UH4 v32
    cdef UH4 v33
    v0 = "asd"
    v1 = 4
    v2 = "qwe"
    v3 = 6
    v4 = "zxc"
    v5 = 9
    v6 = UH0_1()
    v7 = UH0_0(v4, v5, v6)
    del v4; del v6
    v8 = UH0_0(v2, v3, v7)
    del v2; del v7
    v9 = UH0_0(v0, v1, v8)
    del v0; del v8
    method0(v9)
    del v9
    v10 = 9
    v11 = "zxc"
    v12 = 6
    v13 = "qwe"
    v14 = 4
    v15 = "asd"
    v16 = UH2_1()
    v17 = UH2_0(v14, v15, v16)
    del v15; del v16
    v18 = UH2_0(v12, v13, v17)
    del v13; del v17
    v19 = UH2_0(v10, v11, v18)
    del v11; del v18
    method16(v19)
    del v19
    v20 = "asd"
    v21 = "qwe"
    v22 = "zxc"
    v23 = UH3_1()
    v24 = UH3_0(v22, v23)
    del v22; del v23
    v25 = UH3_0(v21, v24)
    del v21; del v24
    v26 = UH3_0(v20, v25)
    del v20; del v25
    method29(v26)
    del v26
    v27 = 4
    v28 = 6
    v29 = 9
    v30 = UH4_1()
    v31 = UH4_0(v29, v30)
    del v30
    v32 = UH4_0(v28, v31)
    del v31
    v33 = UH4_0(v27, v32)
    del v32
    method42(v33)
