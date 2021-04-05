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
    cdef public object v2
    cdef public object v3
    cdef public unsigned long long v4
    def __init__(self, unsigned long long v0, v1, v2, v3, unsigned long long v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
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
    cdef public object v2
    cdef public unsigned long long v3
    def __init__(self, unsigned long long v0, v1, v2, unsigned long long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
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
    cdef public object v2
    cdef public unsigned long long v3
    def __init__(self, unsigned long long v0, v1, v2, unsigned long long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
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
cdef void method1(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method1(v0, v3)
    else:
        pass
cdef void method2(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method2(v0, v3)
    else:
        pass
cdef void method3(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method3(v0, v3)
    else:
        pass
cdef void method8(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method8(v0, v1, v4)
    else:
        pass
cdef void method9(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method9(v0, v1, v4)
    else:
        pass
cdef void method10(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method10(v0, v1, v4)
    else:
        pass
cdef void method12(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, list v5, list v6, list v7, unsigned long long v8):
    cdef bint v9
    cdef unsigned long long v10
    cdef str v11
    cdef unsigned long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef list v15
    cdef list v16
    cdef list v17
    v9 = v8 < v0
    if v9:
        v10 = v8 + 1
        v11 = v5[v8]
        v12 = v6[v8]
        v13 = v7[v8]
        v14 = v13 % v1
        v15 = v2[v14]
        v16 = v3[v14]
        v17 = v4[v14]
        v15.append(v11)
        del v11; del v15
        v16.append(v12)
        del v16
        v17.append(v13)
        del v17
        method12(v0, v1, v2, v3, v4, v5, v6, v7, v10)
    else:
        pass
cdef void method11(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, unsigned long long v8):
    cdef bint v9
    cdef unsigned long long v10
    cdef list v11
    cdef list v12
    cdef list v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    v9 = v8 < v0
    if v9:
        v10 = v8 + 1
        v11 = v1[v8]
        v12 = v2[v8]
        v13 = v3[v8]
        v14 = len(v1)
        v15 = 0
        method12(v14, v4, v5, v6, v7, v11, v12, v13, v15)
        del v11; del v12; del v13
        method11(v0, v1, v2, v3, v4, v5, v6, v7, v10)
    else:
        pass
cdef void method7(Mut0 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef bint v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef unsigned long long v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef unsigned long long v12
    cdef numpy.ndarray[object,ndim=1] v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    v1, v2, v3 = v0.v1, v0.v2, v0.v3
    v4 = len(v1)
    v5 = v4 * 3
    v6 = v5 // 2
    v7 = v6 + 3
    v8 = v7 <= v4
    if v8:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v9 = numpy.empty(v7,dtype=object)
    v10 = 0
    method8(v7, v9, v10)
    v11 = numpy.empty(v7,dtype=object)
    v12 = 0
    method9(v7, v11, v12)
    v13 = numpy.empty(v7,dtype=object)
    v14 = 0
    method10(v7, v13, v14)
    v15 = 0
    method11(v4, v1, v2, v3, v7, v9, v11, v13, v15)
    del v1; del v2; del v3
    v0.v1 = v9
    v0.v2 = v11
    v0.v3 = v13
    del v9; del v11; del v13
    v16 = v0.v0
    v17 = v16 + 2
    v0.v0 = v17
cdef unsigned long method6(Mut0 v0, str v1, unsigned long v2, unsigned long long v3, list v4, list v5, list v6, unsigned long long v7):
    cdef unsigned long long v8
    cdef bint v9
    cdef str v10
    cdef unsigned long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v17
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef numpy.ndarray[object,ndim=1] v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef bint v29
    v8 = len(v4)
    v9 = v7 < v8
    if v9:
        v10 = v4[v7]
        v11 = v5[v7]
        v12 = v6[v7]
        v13 = v3 == v12
        if v13:
            v15 = v1 == v10
        else:
            v15 = 0
        del v10
        if v15:
            raise Exception("The key already exists in the dictionary.")
        else:
            v17 = v7 + 1
            return method6(v0, v1, v2, v3, v4, v5, v6, v17)
    else:
        v4.append(v1)
        v5.append(v2)
        v6.append(v3)
        v20 = v0.v4
        v21 = v20 + 1
        v0.v4 = v21
        v22 = v0.v4
        v23 = v0.v0
        v24, v25, v26 = v0.v1, v0.v2, v0.v3
        del v25; del v26
        v27 = len(v24)
        del v24
        v28 = v23 * v27
        v29 = v22 >= v28
        if v29:
            method7(v0)
        else:
            pass
        return v2
cdef void method5(Mut0 v0, str v1, unsigned long v2):
    cdef unsigned long long v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef list v12
    cdef list v13
    cdef list v14
    cdef unsigned long long v15
    cdef unsigned long v16
    v6 = hash(v1)
    v7, v8, v9 = v0.v1, v0.v2, v0.v3
    v10 = len(v7)
    v11 = v6 % v10
    v12 = v7[v11]
    del v7
    v13 = v8[v11]
    del v8
    v14 = v9[v11]
    del v9
    v15 = 0
    v16 = method6(v0, v1, v2, v6, v12, v13, v14, v15)
    del v12; del v13; del v14
cdef void method4(Mut0 v0, UH0 v1):
    cdef str v2
    cdef unsigned long v3
    cdef UH0 v4
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v1).v2
        method5(v0, v2, v3)
        del v2
        method4(v0, v4)
    elif v1.tag == 1: # nil
        pass
cdef unsigned long method15(Mut0 v0, str v1, unsigned long long v2, list v3, list v4, list v5, unsigned long long v6):
    cdef unsigned long long v7
    cdef bint v8
    cdef str v9
    cdef unsigned long v10
    cdef unsigned long long v11
    cdef bint v12
    cdef bint v14
    cdef unsigned long long v15
    v7 = len(v3)
    v8 = v6 < v7
    if v8:
        v9 = v3[v6]
        v10 = v4[v6]
        v11 = v5[v6]
        v12 = v2 == v11
        if v12:
            v14 = v1 == v9
        else:
            v14 = 0
        del v9
        if v14:
            return v10
        else:
            v15 = v6 + 1
            return method15(v0, v1, v2, v3, v4, v5, v15)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef unsigned long method14(Mut0 v0, str v1):
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef list v11
    cdef list v12
    cdef list v13
    cdef unsigned long long v14
    v5 = hash(v1)
    v6, v7, v8 = v0.v1, v0.v2, v0.v3
    v9 = len(v6)
    v10 = v5 % v9
    v11 = v6[v10]
    del v6
    v12 = v7[v10]
    del v7
    v13 = v8[v10]
    del v8
    v14 = 0
    return method15(v0, v1, v5, v11, v12, v13, v14)
cdef UH1 method13(Mut0 v0, UH0 v1, UH1 v2):
    cdef str v3
    cdef unsigned long v4
    cdef UH0 v5
    cdef UH1 v6
    cdef unsigned long v7
    cdef str v8
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1; v5 = (<UH0_0>v1).v2
        v6 = method13(v0, v5, v2)
        del v5
        v7 = method14(v0, v3)
        del v3
        v8 = str(v7)
        return UH1_0(v8, v6)
    elif v1.tag == 1: # nil
        return v2
cdef unsigned long long method17(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method17(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method18(list v0, UH1 v1, unsigned long long v2):
    cdef str v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method18(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef list method16(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef list v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method17(v0, v1)
    v3 = [None]*v2
    v4 = 0
    v5 = method18(v3, v0, v4)
    return v3
cdef void method0(UH0 v0):
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef unsigned long long v9
    cdef Mut0 v10
    cdef UH1 v11
    cdef UH1 v12
    cdef list v13
    cdef str v14
    v4 = numpy.empty(7,dtype=object)
    v5 = 0
    method1(v4, v5)
    v6 = numpy.empty(7,dtype=object)
    v7 = 0
    method2(v6, v7)
    v8 = numpy.empty(7,dtype=object)
    v9 = 0
    method3(v8, v9)
    v10 = Mut0(3, v4, v6, v8, 0)
    del v4; del v6; del v8
    method4(v10, v0)
    v11 = UH1_1()
    v12 = method13(v10, v0, v11)
    del v10; del v11
    v13 = method16(v12)
    del v12
    v14 = ", ".join(v13)
    del v13
    print(v14)
cdef void method20(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method20(v0, v3)
    else:
        pass
cdef void method21(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method21(v0, v3)
    else:
        pass
cdef void method26(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method26(v0, v1, v4)
    else:
        pass
cdef void method27(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method27(v0, v1, v4)
    else:
        pass
cdef void method29(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, list v4, list v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef unsigned long v9
    cdef str v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef list v13
    cdef list v14
    v7 = v6 < v0
    if v7:
        v8 = v6 + 1
        v9 = v4[v6]
        v10 = v5[v6]
        v11 = hash(v9)
        v12 = v11 % v1
        v13 = v2[v12]
        v14 = v3[v12]
        v13.append(v9)
        del v13
        v14.append(v10)
        del v10; del v14
        method29(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method28(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    v7 = v6 < v0
    if v7:
        v8 = v6 + 1
        v9 = v1[v6]
        v10 = v2[v6]
        v11 = len(v1)
        v12 = 0
        method29(v11, v3, v4, v5, v9, v10, v12)
        del v9; del v10
        method28(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method25(Mut1 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef bint v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef unsigned long long v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    v1, v2 = v0.v1, v0.v2
    v3 = len(v1)
    v4 = v3 * 3
    v5 = v4 // 2
    v6 = v5 + 3
    v7 = v6 <= v3
    if v7:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v8 = numpy.empty(v6,dtype=object)
    v9 = 0
    method26(v6, v8, v9)
    v10 = numpy.empty(v6,dtype=object)
    v11 = 0
    method27(v6, v10, v11)
    v12 = 0
    method28(v3, v1, v2, v6, v8, v10, v12)
    del v1; del v2
    v0.v1 = v8
    v0.v2 = v10
    del v8; del v10
    v13 = v0.v0
    v14 = v13 + 2
    v0.v0 = v14
cdef str method24(Mut1 v0, unsigned long v1, str v2, unsigned long long v3, list v4, list v5, unsigned long long v6):
    cdef unsigned long long v7
    cdef bint v8
    cdef unsigned long v9
    cdef str v10
    cdef unsigned long long v11
    cdef bint v12
    cdef bint v14
    cdef unsigned long long v16
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef numpy.ndarray[object,ndim=1] v23
    cdef numpy.ndarray[object,ndim=1] v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef bint v27
    v7 = len(v4)
    v8 = v6 < v7
    if v8:
        v9 = v4[v6]
        v10 = v5[v6]
        del v10
        v11 = hash(v9)
        v12 = v3 == v11
        if v12:
            v14 = v1 == v9
        else:
            v14 = 0
        if v14:
            raise Exception("The key already exists in the dictionary.")
        else:
            v16 = v6 + 1
            return method24(v0, v1, v2, v3, v4, v5, v16)
    else:
        v4.append(v1)
        v5.append(v2)
        v19 = v0.v3
        v20 = v19 + 1
        v0.v3 = v20
        v21 = v0.v3
        v22 = v0.v0
        v23, v24 = v0.v1, v0.v2
        del v24
        v25 = len(v23)
        del v23
        v26 = v22 * v25
        v27 = v21 >= v26
        if v27:
            method25(v0)
        else:
            pass
        return v2
cdef void method23(Mut1 v0, unsigned long v1, str v2):
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef list v10
    cdef list v11
    cdef unsigned long long v12
    cdef str v13
    v5 = hash(v1)
    v6, v7 = v0.v1, v0.v2
    v8 = len(v6)
    v9 = v5 % v8
    v10 = v6[v9]
    del v6
    v11 = v7[v9]
    del v7
    v12 = 0
    v13 = method24(v0, v1, v2, v5, v10, v11, v12)
    del v10; del v11; del v13
cdef void method22(Mut1 v0, UH2 v1):
    cdef unsigned long v2
    cdef str v3
    cdef UH2 v4
    if v1.tag == 0: # cons_
        v2 = (<UH2_0>v1).v0; v3 = (<UH2_0>v1).v1; v4 = (<UH2_0>v1).v2
        method23(v0, v2, v3)
        del v3
        method22(v0, v4)
    elif v1.tag == 1: # nil
        pass
cdef str method32(Mut1 v0, unsigned long v1, unsigned long long v2, list v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long v8
    cdef str v9
    cdef unsigned long long v10
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v14
    v6 = len(v3)
    v7 = v5 < v6
    if v7:
        v8 = v3[v5]
        v9 = v4[v5]
        v10 = hash(v8)
        v11 = v2 == v10
        if v11:
            v13 = v1 == v8
        else:
            v13 = 0
        if v13:
            return v9
        else:
            del v9
            v14 = v5 + 1
            return method32(v0, v1, v2, v3, v4, v14)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef str method31(Mut1 v0, unsigned long v1):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    v4 = hash(v1)
    v5, v6 = v0.v1, v0.v2
    v7 = len(v5)
    v8 = v4 % v7
    v9 = v5[v8]
    del v5
    v10 = v6[v8]
    del v6
    v11 = 0
    return method32(v0, v1, v4, v9, v10, v11)
cdef UH1 method30(Mut1 v0, UH2 v1, UH1 v2):
    cdef unsigned long v3
    cdef UH2 v5
    cdef UH1 v6
    cdef str v7
    cdef str v8
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v5 = (<UH2_0>v1).v2
        v6 = method30(v0, v5, v2)
        del v5
        v7 = method31(v0, v3)
        v8 = str(v7)
        del v7
        return UH1_0(v8, v6)
    elif v1.tag == 1: # nil
        return v2
cdef void method19(UH2 v0):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef Mut1 v7
    cdef UH1 v8
    cdef UH1 v9
    cdef list v10
    cdef str v11
    v3 = numpy.empty(7,dtype=object)
    v4 = 0
    method20(v3, v4)
    v5 = numpy.empty(7,dtype=object)
    v6 = 0
    method21(v5, v6)
    v7 = Mut1(3, v3, v5, 0)
    del v3; del v5
    method22(v7, v0)
    v8 = UH1_1()
    v9 = method30(v7, v0, v8)
    del v7; del v8
    v10 = method16(v9)
    del v9
    v11 = ", ".join(v10)
    del v10
    print(v11)
cdef void method34(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method34(v0, v3)
    else:
        pass
cdef void method35(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method35(v0, v3)
    else:
        pass
cdef void method40(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method40(v0, v1, v4)
    else:
        pass
cdef void method41(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method41(v0, v1, v4)
    else:
        pass
cdef void method43(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, list v4, list v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef str v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef list v12
    cdef list v13
    v7 = v6 < v0
    if v7:
        v8 = v6 + 1
        v9 = v4[v6]
        v10 = v5[v6]
        v11 = v10 % v1
        v12 = v2[v11]
        v13 = v3[v11]
        v12.append(v9)
        del v9; del v12
        v13.append(v10)
        del v13
        method43(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method42(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    v7 = v6 < v0
    if v7:
        v8 = v6 + 1
        v9 = v1[v6]
        v10 = v2[v6]
        v11 = len(v1)
        v12 = 0
        method43(v11, v3, v4, v5, v9, v10, v12)
        del v9; del v10
        method42(v0, v1, v2, v3, v4, v5, v8)
    else:
        pass
cdef void method39(Mut2 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef bint v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef unsigned long long v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    v1, v2 = v0.v1, v0.v2
    v3 = len(v1)
    v4 = v3 * 3
    v5 = v4 // 2
    v6 = v5 + 3
    v7 = v6 <= v3
    if v7:
        raise Exception("The table cannot be grown anymore.")
    else:
        pass
    v8 = numpy.empty(v6,dtype=object)
    v9 = 0
    method40(v6, v8, v9)
    v10 = numpy.empty(v6,dtype=object)
    v11 = 0
    method41(v6, v10, v11)
    v12 = 0
    method42(v3, v1, v2, v6, v8, v10, v12)
    del v1; del v2
    v0.v1 = v8
    v0.v2 = v10
    del v8; del v10
    v13 = v0.v0
    v14 = v13 + 2
    v0.v0 = v14
cdef void method38(Mut2 v0, str v1, unsigned long long v2, list v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef str v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef numpy.ndarray[object,ndim=1] v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef bint v22
    v6 = len(v3)
    v7 = v5 < v6
    if v7:
        v8 = v3[v5]
        v9 = v4[v5]
        v10 = v2 == v9
        if v10:
            v12 = v1 == v8
        else:
            v12 = 0
        del v8
        if v12:
            raise Exception("The key already exists in the dictionary.")
        else:
            v13 = v5 + 1
            method38(v0, v1, v2, v3, v4, v13)
    else:
        v3.append(v1)
        v4.append(v2)
        v14 = v0.v3
        v15 = v14 + 1
        v0.v3 = v15
        v16 = v0.v3
        v17 = v0.v0
        v18, v19 = v0.v1, v0.v2
        del v19
        v20 = len(v18)
        del v18
        v21 = v17 * v20
        v22 = v16 >= v21
        if v22:
            method39(v0)
        else:
            pass
cdef void method37(Mut2 v0, str v1):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    v4 = hash(v1)
    v5, v6 = v0.v1, v0.v2
    v7 = len(v5)
    v8 = v4 % v7
    v9 = v5[v8]
    del v5
    v10 = v6[v8]
    del v6
    v11 = 0
    method38(v0, v1, v4, v9, v10, v11)
cdef void method36(Mut2 v0, UH3 v1):
    cdef str v2
    cdef UH3 v3
    if v1.tag == 0: # cons_
        v2 = (<UH3_0>v1).v0; v3 = (<UH3_0>v1).v1
        method37(v0, v2)
        del v2
        method36(v0, v3)
    elif v1.tag == 1: # nil
        pass
cdef void method46(Mut2 v0, str v1, unsigned long long v2, list v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef str v8
    cdef unsigned long long v9
    cdef bint v10
    cdef bint v12
    cdef unsigned long long v13
    v6 = len(v3)
    v7 = v5 < v6
    if v7:
        v8 = v3[v5]
        v9 = v4[v5]
        v10 = v2 == v9
        if v10:
            v12 = v1 == v8
        else:
            v12 = 0
        del v8
        if v12:
            pass
        else:
            v13 = v5 + 1
            method46(v0, v1, v2, v3, v4, v13)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef void method45(Mut2 v0, str v1):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef list v9
    cdef list v10
    cdef unsigned long long v11
    v4 = hash(v1)
    v5, v6 = v0.v1, v0.v2
    v7 = len(v5)
    v8 = v4 % v7
    v9 = v5[v8]
    del v5
    v10 = v6[v8]
    del v6
    v11 = 0
    method46(v0, v1, v4, v9, v10, v11)
cdef UH1 method44(Mut2 v0, UH3 v1, UH1 v2):
    cdef str v3
    cdef UH3 v4
    cdef UH1 v5
    if v1.tag == 0: # cons_
        v3 = (<UH3_0>v1).v0; v4 = (<UH3_0>v1).v1
        v5 = method44(v0, v4, v2)
        del v4
        method45(v0, v3)
        del v3
        return UH1_0("()", v5)
    elif v1.tag == 1: # nil
        return v2
cdef void method33(UH3 v0):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef Mut2 v7
    cdef UH1 v8
    cdef UH1 v9
    cdef list v10
    cdef str v11
    v3 = numpy.empty(7,dtype=object)
    v4 = 0
    method34(v3, v4)
    v5 = numpy.empty(7,dtype=object)
    v6 = 0
    method35(v5, v6)
    v7 = Mut2(3, v3, v5, 0)
    del v3; del v5
    method36(v7, v0)
    v8 = UH1_1()
    v9 = method44(v7, v0, v8)
    del v7; del v8
    v10 = method16(v9)
    del v9
    v11 = ", ".join(v10)
    del v10
    print(v11)
cdef void method48(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef list v4
    v2 = v1 < 7
    if v2:
        v3 = v1 + 1
        v4 = [None]*0
        v0[v1] = v4
        del v4
        method48(v0, v3)
    else:
        pass
cdef void method53(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method53(v0, v1, v4)
    else:
        pass
cdef void method55(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
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
        method55(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method54(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method55(v8, v2, v3, v7, v9)
        del v7
        method54(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method52(Mut3 v0):
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
    method53(v5, v7, v8)
    v9 = 0
    method54(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef void method51(Mut3 v0, unsigned long v1, unsigned long long v2, list v3, unsigned long long v4):
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
            method51(v0, v1, v2, v3, v12)
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
            method52(v0)
        else:
            pass
cdef void method50(Mut3 v0, unsigned long v1):
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
    method51(v0, v1, v3, v7, v8)
cdef void method49(Mut3 v0, UH4 v1):
    cdef unsigned long v2
    cdef UH4 v3
    if v1.tag == 0: # cons_
        v2 = (<UH4_0>v1).v0; v3 = (<UH4_0>v1).v1
        method50(v0, v2)
        method49(v0, v3)
    elif v1.tag == 1: # nil
        pass
cdef void method58(Mut3 v0, unsigned long v1, unsigned long long v2, list v3, unsigned long long v4):
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
            method58(v0, v1, v2, v3, v12)
    else:
        raise Exception("The key is not present in the dictionary.")
cdef void method57(Mut3 v0, unsigned long v1):
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
    method58(v0, v1, v3, v7, v8)
cdef UH1 method56(Mut3 v0, UH4 v1, UH1 v2):
    cdef unsigned long v3
    cdef UH4 v4
    cdef UH1 v5
    if v1.tag == 0: # cons_
        v3 = (<UH4_0>v1).v0; v4 = (<UH4_0>v1).v1
        v5 = method56(v0, v4, v2)
        del v4
        method57(v0, v3)
        return UH1_0("()", v5)
    elif v1.tag == 1: # nil
        return v2
cdef void method47(UH4 v0):
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    cdef Mut3 v4
    cdef UH1 v5
    cdef UH1 v6
    cdef list v7
    cdef str v8
    v2 = numpy.empty(7,dtype=object)
    v3 = 0
    method48(v2, v3)
    v4 = Mut3(3, v2, 0)
    del v2
    method49(v4, v0)
    v5 = UH1_1()
    v6 = method56(v4, v0, v5)
    del v4; del v5
    v7 = method16(v6)
    del v6
    v8 = ", ".join(v7)
    del v7
    print(v8)
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
    method19(v19)
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
    method33(v26)
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
    method47(v33)
