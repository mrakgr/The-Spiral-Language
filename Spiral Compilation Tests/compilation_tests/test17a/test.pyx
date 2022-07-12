cdef signed long long method0(signed long long v0, signed long long v1):
    cdef char v2
    v2 = 1
    if v2:
        return method0(v1, v0)
    else:
        return v0 + v1
cpdef signed long long main():
    cdef signed long long v0
    cdef signed long long v1
    v0 = 1
    v1 = 2
    return method0(v0, v1)
