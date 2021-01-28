cdef class Tuple0:
    cdef public char v0
    cdef public object v1
    cdef public signed long v2
    cdef public char v3
    cdef public char v4
    def __init__(self, char v0, v1, signed long v2, char v3, char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cpdef Tuple0 main():
    cdef list v0
    cdef list v1
    cdef list v2
    cdef list v3
    cdef list v4
    cdef char v5
    cdef object v6
    cdef signed long v7
    cdef char v8
    cdef char v9
    # // create
    v0 = [None] * 10
    v1 = [None] * 10
    v2 = [None] * 10
    v3 = [None] * 10
    v4 = [None] * 10
    # // set 0
    v0[0] = 1
    v1[0] = "qwe"
    v2[0] = 2
    v3[0] = 0
    v4[0] = 1
    # // set 1 - note how record fields can be omitted in the real segment
    v0[1] = 0
    v1[1] = "zxc"
    v2[1] = -2
    v4[1] = 0
    # // index 0
    v5 = v0[0]
    v6 = v1[0]
    v7 = v2[0]
    v8 = v3[0]
    v9 = v4[0]
    return Tuple0(v5, v6, v7, v8, v9)
