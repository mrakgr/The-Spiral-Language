cimport libc.math
cpdef float main():
    cdef float v0
    cdef float v1
    cdef float v2
    v0 = 1.000000
    v1 = libc.math.tanh(v0)
    v2 = libc.math.exp(v1)
    return libc.math.log(v2)
