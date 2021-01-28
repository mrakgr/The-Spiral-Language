cpdef main():
    cdef char v0
    cdef char v1
    cdef char v2
    cdef char v3
    cdef char v4
    cdef char v5
    cdef char v6
    v0 = 1
    v1 = 0
    v2 = 1
    v3 = 0
    v4 = 1
    v5 = v0 and v1
    if v5:
        return 1
    else:
        v6 = v2 and v3
        return v6 or v4
