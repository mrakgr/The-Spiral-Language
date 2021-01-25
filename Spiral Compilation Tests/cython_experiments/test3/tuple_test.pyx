cdef class Qwe:
    cdef object x
    cdef __init__(self, q):
        self.x = q

cpdef object test_obj(object x):
    q,w = x
    return q+w

cpdef object qwe(object a, object b):
    x = a,b
    cdef Qwe z = Qwe(x)
    return z #test_obj(x)