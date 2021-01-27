cdef signed long method0(signed long v0, signed long v1):
    return v0 + v1
cpdef main():
    cdef signed long v0
    v0 = 1
    cdef signed long v1
    v1 = 2
    return method0(v0, v1)
