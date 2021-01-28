cdef class US0:
    cdef public int tag
cdef class US0_0(US0): # a
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # b
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef public US0 v0
    cdef public US0 v1
    cdef public US0 v2
    cdef public US0 v3
    def __init__(self, US0 v0, US0 v1, US0 v2, US0 v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef Tuple0 method0():
    cdef US0 v0
    v0 = US0_0()
    return Tuple0(v0, v0, v0, v0)
cdef signed long method1():
    return 1
cdef signed long method2():
    return 2
cdef signed long method3():
    return 3
cdef signed long method4():
    return 4
cpdef main():
    cdef US0 v0
    cdef US0 v1
    cdef US0 v2
    cdef US0 v3
    cdef Tuple0 tmp0
    tmp0 = method0()
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2; v3 = tmp0.v3
    if v0 == 0: # a
        if v1 == 0: # a
            return method1()
        elif v1 == 1: # b
            if v2 == 0: # a
                if v3 == 0: # a
                    return method2()
                elif v3 == 1: # b
                    return method3()
            elif v2 == 1: # b
                return method4()
    elif v0 == 1: # b
        if v2 == 0: # a
            if v3 == 0: # a
                return method2()
            elif v3 == 1: # b
                return method4()
        elif v2 == 1: # b
            return method4()
