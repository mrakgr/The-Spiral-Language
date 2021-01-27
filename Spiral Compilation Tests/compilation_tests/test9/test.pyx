cdef class Tuple0:
    cdef public signed long v0
    cdef public signed long v1
    cdef public double v2
    cdef public float v3
    cdef public double v4
    def __init__(self, signed long v0, signed long v1, double v2, float v3, double v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class ClosureTy0:
    cpdef Tuple0 apply(self, v0): raise NotImplementedError()
cdef class ClosureTy2:
    cpdef ClosureTy0 apply(self, double v0, float v1, double v2): raise NotImplementedError()
cdef class ClosureTy1:
    cpdef ClosureTy2 apply(self, signed long v0): raise NotImplementedError()
cdef class Closure2(ClosureTy0):
    cdef signed long v0
    cdef double v1
    cdef float v2
    cdef double v3
    def __init__(self, signed long v0, double v1, float v2, double v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    cpdef Tuple0 apply(self, v4):
        cdef signed long v0 = self.v0
        cdef double v1 = self.v1
        cdef float v2 = self.v2
        cdef double v3 = self.v3
        return method4(v0, v1, v2, v3)
cdef class Closure1(ClosureTy2):
    cdef signed long v0
    def __init__(self, signed long v0): self.v0 = v0
    cpdef ClosureTy0 apply(self, double v1, float v2, double v3):
        cdef signed long v0 = self.v0
        return method3(v0, v1, v2, v3)
cdef class Closure0(ClosureTy1):
    def __init__(self): pass
    cpdef ClosureTy2 apply(self, signed long v0):
        return method2(v0)
cdef Tuple0 method4(signed long v0, double v1, float v2, double v3):
    return Tuple0(1, v0, v1, v2, v3)
cdef ClosureTy0 method3(signed long v0, double v1, float v2, double v3):
    return Closure2(v0, v1, v2, v3)
cdef ClosureTy2 method2(signed long v0):
    return Closure1(v0)
cdef ClosureTy1 method1():
    return Closure0()
cdef ClosureTy0 method0():
    cdef ClosureTy1 v0
    v0 = method1()
    cdef ClosureTy2 v1
    v1 = v0.apply(2)
    return v1.apply(2.200000, 3.000000, 4.500000)
cpdef main():
    cdef ClosureTy0 v0
    v0 = method0()
    return v0.apply("qwe")
