import rx
import rx.operators
import numpy
cimport numpy
cdef class Tuple0:
    cdef readonly str v0
    cdef readonly unsigned long long v1
    def __init__(self, str v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, str v0):
        cdef unsigned long long v1
        v1 = len(v0)
        return Tuple0(v0, v1)
cdef class Closure1():
    def __init__(self): pass
    def __call__(self, Tuple0 args):
        cdef str v0 = args.v0
        cdef unsigned long long v1 = args.v1
        return 2 < v1
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, Tuple0 args):
        cdef str v0 = args.v0
        cdef unsigned long long v1 = args.v1
        print(f"Got a value: {v0}")
cpdef void main():
    cdef numpy.ndarray[str,ndim=1] v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    pass # import rx
    pass # import rx.operators
    v0 = numpy.empty(5,dtype=object)
    v0[0] = "a"; v0[1] = "ab"; v0[2] = "abc"; v0[3] = "abcd"; v0[4] = "abcde"
    v1 = rx.from_iterable(v0)
    del v0
    v2 = Closure0()
    v3 = rx.operators.map(v2)
    del v2
    v4 = v3(v1)
    del v1; del v3
    v5 = Closure1()
    v6 = rx.operators.filter(v5)
    del v5
    v7 = v6(v4)
    del v4; del v6
    v8 = Closure2()
    v7.subscribe(v8)
