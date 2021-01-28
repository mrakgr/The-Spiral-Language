cpdef main():
    cdef signed long v0
    cdef signed long v1
    cdef char v2
    v0 = 2
    v1 = 3
    v2 = v0 == 2
    if v2:
        return v1 == 3
    else:
        return 0
