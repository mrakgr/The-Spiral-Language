cdef class Tuple0:
    cdef public signed long v0
    cdef public signed long v1
    cdef public signed long v2
    cdef public signed long v3
    cdef public signed long v4
    cdef public signed long v5
    cdef public signed long v6
    cdef public signed long v7
    cdef public signed long v8
    cdef public signed long v9
    cdef public signed long v10
    cdef public signed long v11
    def __init__(self, signed long v0, signed long v1, signed long v2, signed long v3, signed long v4, signed long v5, signed long v6, signed long v7, signed long v8, signed long v9, signed long v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
cdef Tuple0 method0():
    return Tuple0(3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2)
cdef Tuple0 method1(signed long v0, signed long v1, signed long v2, signed long v3, signed long v4, signed long v5, signed long v6, signed long v7, signed long v8, signed long v9, signed long v10, signed long v11):
    return Tuple0(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11)
cpdef main():
    cdef signed long v0
    cdef signed long v1
    cdef signed long v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    cdef signed long v6
    cdef signed long v7
    cdef signed long v8
    cdef signed long v9
    cdef signed long v10
    cdef signed long v11
    cdef Tuple0 tmp0
    cdef signed long v12
    cdef signed long v13
    cdef signed long v14
    cdef signed long v15
    cdef signed long v16
    cdef signed long v17
    cdef signed long v18
    cdef signed long v19
    cdef signed long v20
    cdef signed long v21
    cdef signed long v22
    cdef signed long v23
    cdef Tuple0 tmp1
    tmp0 = method0()
    v0 = tmp0.v0; v1 = tmp0.v1; v2 = tmp0.v2; v3 = tmp0.v3; v4 = tmp0.v4; v5 = tmp0.v5; v6 = tmp0.v6; v7 = tmp0.v7; v8 = tmp0.v8; v9 = tmp0.v9; v10 = tmp0.v10; v11 = tmp0.v11
    tmp1 = method1(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11)
    v12 = tmp1.v0; v13 = tmp1.v1; v14 = tmp1.v2; v15 = tmp1.v3; v16 = tmp1.v4; v17 = tmp1.v5; v18 = tmp1.v6; v19 = tmp1.v7; v20 = tmp1.v8; v21 = tmp1.v9; v22 = tmp1.v10; v23 = tmp1.v11
