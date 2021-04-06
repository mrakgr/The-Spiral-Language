import numpy
cimport numpy
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly unsigned long v0
    cdef readonly str v1
    cdef readonly UH0 v2
    def __init__(self, unsigned long v0, str v1, UH0 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly unsigned long v0
    cdef readonly str v1
    def __init__(self, unsigned long v0, str v1): self.v0 = v0; self.v1 = v1
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    def __init__(self, unsigned long long v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef unsigned long long method1(UH0 v0, unsigned long long v1):
    cdef unsigned long v2
    cdef UH0 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v4 = (<UH0_0>v0).v2
        v5 = v1 + 1
        return method1(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method2(numpy.ndarray[object,ndim=1] v0, UH0 v1, unsigned long long v2):
    cdef unsigned long v3
    cdef str v4
    cdef UH0 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1; v5 = (<UH0_0>v1).v2
        v0[v2] = Tuple0(v3, v4)
        del v4
        v6 = v2 + 1
        return method2(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method0(UH0 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method1(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method2(v3, v0, v4)
    return v3
cdef Tuple1 method5(unsigned long long v0, unsigned long long v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef bint v8
    cdef unsigned long long v9
    v3 = v1 * v2
    v4 = v0 >= v3
    if v4:
        v5 = v2 * 3
        v6 = v5 // 2
        v7 = v6 + 3
        v8 = v7 <= v2
        if v8:
            raise Exception("The table length cannot be increased.")
        else:
            pass
        v9 = v1 + 2
        return method5(v0, v9, v7)
    else:
        return Tuple1(v1, v2)
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
cdef Mut0 method6(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0
    method7(v1, v3, v4)
    v5 = Mut0(v0, v3, 0)
    del v3
    return v5
cdef Mut0 method4(unsigned long long v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef Tuple1 tmp0
    v1 = 3
    v2 = 7
    tmp0 = method5(v0, v1, v2)
    v3, v4 = tmp0.v0, tmp0.v1
    del tmp0
    return method6(v3, v4)
cdef void method12(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method12(v0, v1, v4)
    else:
        pass
cdef void method14(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long v7
    cdef str v8
    cdef Tuple0 tmp3
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        tmp3 = v3[v4]
        v7, v8 = tmp3.v0, tmp3.v1
        del tmp3
        v9 = hash(v7)
        v10 = v9 % v1
        v11 = v2[v10]
        v11.append(Tuple0(v7, v8))
        del v8; del v11
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method13(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
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
        method14(v8, v2, v3, v7, v9)
        del v7
        method13(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method11(Mut0 v0):
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
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0
    method12(v5, v7, v8)
    v9 = 0
    method13(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef void method10(Mut0 v0, unsigned long v1, str v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long v8
    cdef str v9
    cdef Tuple0 tmp2
    cdef bint v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef bint v19
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp2 = v4[v5]
        v8, v9 = tmp2.v0, tmp2.v1
        del tmp2
        del v9
        v10 = v1 == v8
        if v10:
            raise Exception("The key already exists in the dictionary.")
        else:
            v11 = v5 + 1
            method10(v0, v1, v2, v3, v4, v11)
    else:
        v4.append(Tuple0(v1, v2))
        v12 = v0.v2
        v13 = v12 + 1
        v0.v2 = v13
        v14 = v0.v2
        v15 = v0.v0
        v16 = v0.v1
        v17 = len(v16)
        del v16
        v18 = v15 * v17
        v19 = v14 >= v18
        if v19:
            method11(v0)
        else:
            pass
cdef void method9(Mut0 v0, unsigned long v1, str v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = hash(v1)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = 0
    method10(v0, v1, v2, v4, v8, v9)
cdef void method8(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, Mut0 v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long v6
    cdef str v7
    cdef Tuple0 tmp1
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        tmp1 = v1[v3]
        v6, v7 = tmp1.v0, tmp1.v1
        del tmp1
        method9(v2, v6, v7)
        del v7
        method8(v0, v1, v2, v5)
    else:
        pass
cdef Mut0 method3(numpy.ndarray[object,ndim=1] v0):
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef unsigned long long v3
    v1 = len(v0)
    v2 = method4(v1)
    v3 = 0
    method8(v1, v0, v2, v3)
    return v2
cdef unsigned long long method18(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long v7
    cdef str v8
    cdef Tuple0 tmp4
    cdef unsigned long long v9
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1
        tmp4 = v2[v3]
        v7, v8 = tmp4.v0, tmp4.v1
        del tmp4
        v9 = v4 - 1
        v1[v9] = Tuple0(v7, v8)
        del v8
        return method18(v0, v1, v2, v6, v9)
    else:
        return v4
cdef unsigned long long method17(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1
        v7 = v2[v3]
        v8 = len(v7)
        v9 = 0
        v10 = method18(v8, v1, v7, v9, v4)
        del v7
        return method17(v0, v1, v2, v6, v10)
    else:
        return v4
cdef unsigned long long method16(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, Mut0 v2):
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v4 = v2.v1
    v5 = len(v4)
    v6 = 0
    return method17(v5, v0, v4, v6, v1)
cdef numpy.ndarray[object,ndim=1] method15(Mut0 v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    v1 = v0.v2
    v2 = numpy.empty(v1,dtype=object)
    v3 = method16(v2, v1, v0)
    return v2
cdef void method19(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef unsigned long v5
    cdef str v6
    cdef Tuple0 tmp5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        tmp5 = v1[v2]
        v5, v6 = tmp5.v0, tmp5.v1
        del tmp5
        print(v5,v6)
        del v6
        method19(v0, v1, v4)
    else:
        pass
cpdef void main():
    cdef unsigned long v0
    cdef str v1
    cdef unsigned long v2
    cdef str v3
    cdef unsigned long v4
    cdef str v5
    cdef UH0 v6
    cdef UH0 v7
    cdef UH0 v8
    cdef UH0 v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef Mut0 v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    v0 = 1
    v1 = "zxc"
    v2 = 2
    v3 = "asd"
    v4 = 3
    v5 = "qwe"
    v6 = UH0_1()
    v7 = UH0_0(v4, v5, v6)
    del v5; del v6
    v8 = UH0_0(v2, v3, v7)
    del v3; del v7
    v9 = UH0_0(v0, v1, v8)
    del v1; del v8
    v10 = method0(v9)
    del v9
    v11 = method3(v10)
    del v10
    v12 = method15(v11)
    del v11
    v13 = len(v12)
    v14 = 0
    method19(v13, v12, v14)
