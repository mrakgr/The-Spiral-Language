import numpy
cimport numpy
cpdef signed long main():
    cdef numpy.ndarray[signed long,ndim=1] v0
    cdef unsigned long long v1
    cdef char v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    cdef signed long v6
    cdef char v8
    cdef signed long v9
    cdef signed long v10
    cdef char v12
    v0 = numpy.empty(3,dtype=numpy.int32)
    v0[0] = 1; v0[1] = 2; v0[2] = 3
    v1 = len(v0)
    v2 = v1 == 3
    if v2:
        v3 = v0[0]
        v4 = v0[1]
        v5 = v0[2]
        v6 = v3 + v4
        return v6 + v5
    else:
        v8 = v1 == 2
        if v8:
            v9 = v0[0]
            v10 = v0[1]
            return v9 + v10
        else:
            v12 = v1 == 1
            if v12:
                return v0[0]
            else:
                return 0
