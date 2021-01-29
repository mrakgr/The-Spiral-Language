cdef class UH0:
    cdef readonly unsigned long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly signed long v0
    cdef readonly signed long v1
    cdef readonly UH0 v2
    def __init__(self, signed long v0, signed long v1, UH0 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cpdef void main():
    cdef signed long v0
    cdef signed long v1
    cdef signed long v2
    cdef signed long v3
    cdef signed long v4
    cdef signed long v5
    cdef UH0 v6
    cdef UH0 v7
    cdef UH0 v8
    cdef UH0 v9
    cdef str v32
    cdef signed long v33
    cdef signed long v10
    cdef signed long v11
    cdef UH0 v12
    cdef signed long v13
    cdef signed long v14
    cdef UH0 v15
    cdef signed long v16
    cdef signed long v17
    cdef UH0 v18
    cdef signed long v19
    cdef signed long v20
    cdef signed long v21
    cdef signed long v22
    cdef signed long v23
    cdef signed long v24
    cdef signed long v25
    cdef signed long v26
    cdef signed long v29
    v0 = 1
    v1 = 2
    v2 = 4
    v3 = 5
    v4 = 5
    v5 = 6
    v6 = UH0_1()
    v7 = UH0_0(v4, v5, v6)
    v8 = UH0_0(v2, v3, v7)
    v9 = UH0_0(v0, v1, v8)
    if v9.tag == 0: # cons_
        v10 = (<UH0_0>v9).v0
        v11 = (<UH0_0>v9).v1
        v12 = (<UH0_0>v9).v2
        if v12.tag == 0: # cons_
            v13 = (<UH0_0>v12).v0
            v14 = (<UH0_0>v12).v1
            v15 = (<UH0_0>v12).v2
            if v15.tag == 0: # cons_
                v16 = (<UH0_0>v15).v0
                v17 = (<UH0_0>v15).v1
                v18 = (<UH0_0>v15).v2
                v19 = v10 + v11
                v20 = v19 + v13
                v21 = v20 + v14
                v22 = v21 + v16
                v23 = v22 + v17
                v32, v33 = "At least three elements.", v23
            elif v15.tag == 1: # nil
                v24 = v10 + v11
                v25 = v24 + v13
                v26 = v25 + v14
                v32, v33 = "Two elements.", v26
        elif v12.tag == 1: # nil
            v29 = v10 + v11
            v32, v33 = "One element.", v29
    elif v9.tag == 1: # nil
        v32, v33 = "No elements", 0
    print(v32,v33)
