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
        raise Exception("The table length cannot be increased.")
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
cdef unsigned long method12(unsigned long long v0, list v1, unsigned long long v2, unsigned long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef str v7
    cdef unsigned long v8
    cdef Tuple0 tmp2
    cdef unsigned long v9
    v4 = v2 < v0
    if v4:
        v5 = v2 + 1
        tmp2 = v1[v2]
        v6, v7, v8 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        del v7
        v9 = v3 + v8
        return method12(v0, v1, v5, v9)
    else:
        return v3
cdef unsigned long method11(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, unsigned long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef list v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long v9
    v4 = v2 < v0
    if v4:
        v5 = v2 + 1
        v6 = v1[v2]
        v7 = len(v6)
        v8 = 0
        v9 = method12(v7, v6, v8, v3)
        del v6
        return method11(v0, v1, v5, v9)
    else:
        return v3
cdef unsigned long method10(unsigned long v0, Mut0 v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v3 = v1.v1
    v4 = len(v3)
    v5 = 0
    return method11(v4, v3, v5, v0)
cdef unsigned long method0(UH0 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef Mut0 v3
    cdef unsigned long v4
    v1 = 3
    v2 = 7
    v3 = method1(v1, v2)
    method3(v3, v0)
    v4 = 0
    return method10(v4, v3)
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
    v10 = method0(v9)
    del v9
    print(v10)
