cdef class Tuple0:
    cdef public signed long v0
    cdef public signed long v1
    cdef public signed long v2
    def __init__(self, signed long v0, signed long v1, signed long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef signed long method0():
    3
cdef signed long method1():
    -1
cdef signed long method2():
    2
cpdef main():
    cdef signed long v0
    v0 = method0()
    cdef signed long v1
    v1 = method1()
    cdef signed long v2
    v2 = method2()
    Tuple0(v0, v1, v2)
