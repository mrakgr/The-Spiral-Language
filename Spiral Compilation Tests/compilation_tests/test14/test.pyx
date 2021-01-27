cdef class Tuple0:
    cdef public object v0
    cdef public signed long v1
    cdef public object v2
    cdef public signed long v3
    cdef public object v4
    cdef public char v5
    cdef public object v6
    cdef public char v7
    cdef public object v8
    cdef public object v9
    cdef public object v10
    cdef public signed char v11
    cdef public object v12
    cdef public double v13
    cdef public object v14
    cdef public double v15
    def __init__(self, v0, signed long v1, v2, signed long v3, v4, char v5, v6, char v7, v8, v9, v10, signed char v11, v12, double v13, v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
cpdef main():
    cdef object v0
    v0 = "0"
    cdef signed long v1
    v1 = 0
    cdef object v2
    v2 = "1"
    cdef signed long v3
    v3 = 1
    cdef object v4
    v4 = "false"
    cdef char v5
    v5 = 0
    cdef object v6
    v6 = "true"
    cdef char v7
    v7 = 1
    cdef object v8
    v8 = "asd"
    cdef object v9
    v9 = "asd"
    cdef object v10
    v10 = "1i8"
    cdef signed char v11
    v11 = 1
    cdef object v12
    v12 = "5.5"
    cdef double v13
    v13 = 5.500000
    cdef object v14
    v14 = "unknown"
    cdef double v15
    v15 = 5.000000
    return Tuple0(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15)
