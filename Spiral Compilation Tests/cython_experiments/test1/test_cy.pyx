cpdef int test(int x):
    cdef int y = 0
    cdef int i
    for i in range(x):
        y += i
    return i