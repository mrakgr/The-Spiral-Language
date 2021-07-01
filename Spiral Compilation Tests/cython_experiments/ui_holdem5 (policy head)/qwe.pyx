cpdef bint main() except *:
    cdef float v0
    cdef float v1
    cdef float v2
    v0 = (<float>2)
    v1 = (<float>-149)
    v2 = pow(v0,v1)
    return (<float>1E-45) == v2
