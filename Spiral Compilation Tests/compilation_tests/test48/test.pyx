cpdef void main():
    cdef signed long v0
    cdef object v1
    cdef signed long v2
    cdef object v3
    cdef char v4
    cdef signed long v5
    cdef double v6
    cdef char v7
    cdef char v9
    v0 = 1
    v1 = "qwe"
    v2 = 2
    v3 = "asd"
    v4 = v0 == v2
    v5 = 1
    v6 = 2.000000
    v7 = v5 == 3
    if v7:
        v9 = v6 == 4.000000
    else:
        v9 = 0
