cdef signed long method2(signed long v0, signed long v1):
    cdef char v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    cdef signed long v6
    v2 = 0 < v1
    if v2:
        v3 = v1 // 10
        v4 = v0 * 10
        v5 = v1 % 10
        v6 = v4 + v5
        return method2(v6, v3)
    else:
        return v0
cdef signed long method3(signed long v0, signed long v1, signed long v2):
    cdef char v3
    cdef signed long v4
    cdef signed long v5
    cdef signed long v6
    cdef signed long v7
    cdef char v8
    cdef char v10
    cdef signed long v11
    v3 = v1 < 1000
    if v3:
        v4 = v1 + 1
        v5 = v0 * v1
        v6 = 0
        v7 = method2(v6, v5)
        v8 = v5 == v7
        if v8:
            v10 = v2 < v5
        else:
            v10 = 0
        if v10:
            v11 = v5
        else:
            v11 = v2
        return method3(v0, v4, v11)
    else:
        return v2
cdef signed long method1(signed long v0, signed long v1):
    cdef char v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    cdef signed long v6
    cdef char v7
    cdef char v9
    cdef signed long v10
    v2 = v0 < 1000
    if v2:
        v3 = v0 + 1
        v4 = v0 * v0
        v5 = 0
        v6 = method2(v5, v4)
        v7 = v4 == v6
        if v7:
            v9 = v1 < v4
        else:
            v9 = 0
        if v9:
            v10 = v4
        else:
            v10 = v1
        return method3(v0, v3, v10)
    else:
        return v1
cdef signed long method0(signed long v0, signed long v1):
    cdef char v2
    cdef signed long v3
    cdef signed long v4
    v2 = v0 < 1000
    if v2:
        v3 = v0 + 1
        v4 = method1(v0, v1)
        return method0(v3, v4)
    else:
        return v1
cpdef signed long main():
    cdef signed long v0
    cdef signed long v1
    v0 = 100
    v1 = 0
    return method0(v0, v1)
