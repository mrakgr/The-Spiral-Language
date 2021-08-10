cdef extern int __builtin_popcountll(unsigned long long) nogil

cpdef unsigned long long main() except *:
    cdef unsigned long long v0
    v0 = (<unsigned long long>1)
    return __builtin_popcountll(v0)
