cdef str method0(bint v0):
    cdef bint v1
    v1 = 1 == v0
    if v1:
        return "asd"
    else:
        return "qwe"
cpdef str main() except *:
    cdef bint v0
    v0 = 1
    return method0(v0)
