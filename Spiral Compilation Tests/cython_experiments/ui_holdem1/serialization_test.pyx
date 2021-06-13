import numpy
cimport numpy
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    def __init__(self, unsigned long long v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef void method0(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2) except *:
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<float>0.000000)
        method0(v0, v1, v4)
    else:
        pass
cdef unsigned long long method2(numpy.ndarray[float,ndim=1] v0, unsigned long long v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef signed long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef float v13
    cdef unsigned long long v14
    v4 = v2 < (<unsigned long long>8)
    if v4:
        v5 = v2 + (<unsigned long long>1)
        v6 = (<unsigned long long>8) - v2
        v7 = v6 - (<unsigned long long>1)
        v8 = <signed long>v7
        v9 = (<unsigned long long>1) << v8
        v10 = <unsigned long long>v2
        v11 = v1 + v10
        v12 = v3 // v9
        v13 = <float>v12
        v0[v11] = v13
        v14 = v3 % v9
        return method2(v0, v1, v5, v14)
    else:
        return v3
cdef void method1(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2) except *:
    cdef signed long v3
    cdef signed long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef bint v8
    cdef bint v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    v3 = <signed long>(<unsigned long long>8)
    v4 = v3 - (<signed long>1)
    v5 = (<unsigned long long>1) << v4
    v6 = v5 - (<unsigned long long>1)
    v7 = v5 + v6
    v8 = (<unsigned long long>0) <= v0
    if v8:
        v10 = v0 < v7
    else:
        v10 = 0
    if v10:
        v11 = v0 + (<unsigned long long>1)
        v12 = (<unsigned long long>0)
        v13 = method2(v1, v2, v12, v11)
    else:
        raise Exception("Value out of bounds.")
cdef unsigned long long method4(numpy.ndarray[float,ndim=1] v0, unsigned long long v1, unsigned long long v2, unsigned long long v3) except *:
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef float v7
    cdef bint v8
    cdef bint v10
    cdef unsigned long long v18
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef signed long v14
    cdef unsigned long long v15
    v4 = v2 < (<unsigned long long>8)
    if v4:
        v5 = v2 + (<unsigned long long>1)
        v6 = v1 + v2
        v7 = v0[v6]
        v8 = v7 == (<float>0.000000)
        if v8:
            v10 = 1
        else:
            v10 = v7 == (<float>1.000000)
        if v10:
            v11 = <unsigned long long>v7
            v12 = (<unsigned long long>8) - v2
            v13 = v12 - (<unsigned long long>1)
            v14 = <signed long>v13
            v15 = v11 << v14
            v18 = v3 + v15
        else:
            raise Exception("Unpickling failure. The int type must either be active or inactive.")
        return method4(v0, v1, v5, v18)
    else:
        return v3
cdef Tuple0 method3(numpy.ndarray[float,ndim=1] v0, unsigned long long v1):
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef unsigned long long v7
    v2 = (<unsigned long long>0)
    v3 = (<unsigned long long>0)
    v4 = method4(v0, v1, v2, v3)
    v5 = v4 - (<unsigned long long>1)
    v6 = (<unsigned long long>0) < v4
    if v6:
        v7 = (<unsigned long long>1)
    else:
        v7 = (<unsigned long long>0)
    return Tuple0(v5, v7)
cpdef void main() except *:
    cdef unsigned long long v0
    cdef numpy.ndarray[float,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef Tuple0 tmp0
    cdef bint v8
    cdef bint v9
    v0 = (<unsigned long long>123)
    v1 = numpy.empty((<unsigned long long>8),dtype=numpy.float32)
    v2 = len(v1)
    v3 = (<unsigned long long>0)
    method0(v2, v1, v3)
    v4 = (<unsigned long long>0)
    method1(v0, v1, v4)
    v5 = (<unsigned long long>0)
    tmp0 = method3(v1, v5)
    v6, v7 = tmp0.v0, tmp0.v1
    del tmp0
    del v1
    v8 = v7 == (<unsigned long long>1)
    v9 = v8 != 1
    if v9:
        raise Exception("Invalid format.")
    else:
        pass
    print(v6)
