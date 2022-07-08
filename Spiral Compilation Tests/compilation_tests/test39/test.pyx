ctypedef signed long US0
cpdef signed long main() except *:
    cdef US0 v0
    cdef US0 v1
    cdef US0 v2
    v0 = 1
    v1 = 1
    v2 = 1
    if v0 == 0: # A
        return (<signed long>1)
    elif v0 == 1: # B
        if v1 == 0: # A
            return (<signed long>2)
        elif v1 == 1: # B
            if v2 == 0: # A
                return (<signed long>3)
            elif v2 == 1: # B
                return (<signed long>4)
