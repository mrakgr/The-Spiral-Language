cpdef main():
    cdef char v0
    v0 = 1
    cdef char v1
    v1 = 0
    cdef char v2
    v2 = 1
    cdef char v3
    v3 = 0
    cdef char v4
    v4 = 1
    cdef char v5
    v5 = v0 & v1
    if v5:
        return 1
    else:
        cdef char v6
        v6 = v2 & v3
        return v6 | v4
