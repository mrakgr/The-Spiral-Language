cdef class US0:
    cdef public int tag
cdef class US0_0(US0): # eQ
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # gT
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # lT
    def __init__(self): self.tag = 2
cpdef void main():
    cdef signed long v0
    cdef object v1
    cdef signed long v2
    cdef object v3
    cdef char v4
    cdef US0 v10
    cdef char v6
    cdef signed long v11
    cdef double v12
    cdef char v13
    cdef US0 v19
    cdef char v15
    cdef char v20
    cdef US0 v28
    cdef char v21
    cdef char v23
    v0 = 1
    v1 = "qwe"
    v2 = 2
    v3 = "asd"
    v4 = v0 < v2
    if v4:
        v10 = US0_2()
    else:
        v6 = v0 > v2
        if v6:
            v10 = US0_1()
        else:
            v10 = US0_0()
    v11 = 1
    v12 = 2.000000
    v13 = v11 < 3
    if v13:
        v19 = US0_2()
    else:
        v15 = v11 > 3
        if v15:
            v19 = US0_1()
        else:
            v19 = US0_0()
    if v19 == 0: # eQ
        v20 = 1
    elif v19 == 1: # gT
        v20 = 0
    elif v19 == 2: # lT
        v20 = 0
    if v20:
        v21 = v12 < 4.000000
        if v21:
            v28 = US0_2()
        else:
            v23 = v12 > 4.000000
            if v23:
                v28 = US0_1()
            else:
                v28 = US0_0()
    else:
        v28 = v19
