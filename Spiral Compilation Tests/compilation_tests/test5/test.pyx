cdef signed long method0():
    1
cdef signed long method1():
    2
cpdef main():
    cdef signed long v0
    v0 = method0()
    cdef signed long v1
    v1 = method1()
    return v0 + v1
