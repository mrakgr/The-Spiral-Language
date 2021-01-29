cdef class UH0:
    cdef readonly unsigned long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly signed long v0
    cdef readonly UH0 v1
    def __init__(self, signed long v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class UH1:
    cdef readonly unsigned long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly str v0
    cdef readonly UH1 v1
    def __init__(self, str v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly unsigned long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly char v0
    cdef readonly UH2 v1
    def __init__(self, char v0, UH2 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class UH3:
    cdef readonly unsigned long tag
cdef class UH3_0(UH3): # cons_
    cdef readonly signed long v0
    cdef readonly str v1
    cdef readonly char v2
    cdef readonly UH3 v3
    def __init__(self, signed long v0, str v1, char v2, UH3 v3): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class UH3_1(UH3): # nil
    def __init__(self): self.tag = 1
cdef UH3 method4(UH3 v0, UH3 v1):
    cdef signed long v2
    cdef str v3
    cdef char v4
    cdef UH3 v5
    cdef UH3 v6
    if v1.tag == 0: # cons_
        v2 = (<UH3_0>v1).v0
        v3 = (<UH3_0>v1).v1
        v4 = (<UH3_0>v1).v2
        v5 = (<UH3_0>v1).v3
        v6 = method4(v0, v5)
        return UH3_0(v2, v3, v4, v6)
    elif v1.tag == 1: # nil
        return v0
cdef UH3 method3(signed long v0, str v1, UH3 v2, UH2 v3):
    cdef char v4
    cdef UH2 v5
    cdef UH3 v6
    cdef UH3 v7
    cdef UH3 v8
    if v3.tag == 0: # cons_
        v4 = (<UH2_0>v3).v0
        v5 = (<UH2_0>v3).v1
        v6 = method3(v0, v1, v2, v5)
        v7 = UH3_1()
        v8 = UH3_0(v0, v1, v4, v7)
        return method4(v6, v8)
    elif v3.tag == 1: # nil
        return v2
cdef UH3 method2(UH2 v0, signed long v1, UH3 v2, UH1 v3):
    cdef str v4
    cdef UH1 v5
    cdef UH3 v6
    cdef UH3 v7
    cdef UH3 v8
    if v3.tag == 0: # cons_
        v4 = (<UH1_0>v3).v0
        v5 = (<UH1_0>v3).v1
        v6 = method2(v0, v1, v2, v5)
        v7 = UH3_1()
        v8 = method3(v1, v4, v7, v0)
        return method4(v6, v8)
    elif v3.tag == 1: # nil
        return v2
cdef UH3 method1(UH1 v0, UH2 v1, UH3 v2, UH0 v3):
    cdef signed long v4
    cdef UH0 v5
    cdef UH3 v6
    cdef UH3 v7
    cdef UH3 v8
    if v3.tag == 0: # cons_
        v4 = (<UH0_0>v3).v0
        v5 = (<UH0_0>v3).v1
        v6 = method1(v0, v1, v2, v5)
        v7 = UH3_1()
        v8 = method2(v1, v4, v7, v0)
        return method4(v6, v8)
    elif v3.tag == 1: # nil
        return v2
cdef UH3 method0(UH0 v0, UH1 v1, UH2 v2):
    cdef UH3 v3
    v3 = UH3_1()
    return method1(v1, v2, v3, v0)
cdef void method5(UH3 v0):
    cdef signed long v1
    cdef str v2
    cdef char v3
    cdef UH3 v4
    if v0.tag == 0: # cons_
        v1 = (<UH3_0>v0).v0
        v2 = (<UH3_0>v0).v1
        v3 = (<UH3_0>v0).v2
        v4 = (<UH3_0>v0).v3
        print(v1, v2, v3)
        method5(v4)
    elif v0.tag == 1: # nil
        pass
cpdef void main():
    cdef signed long v0
    cdef signed long v1
    cdef signed long v2
    cdef UH0 v3
    cdef UH0 v4
    cdef UH0 v5
    cdef UH0 v6
    cdef str v7
    cdef str v8
    cdef UH1 v9
    cdef UH1 v10
    cdef UH1 v11
    cdef char v12
    cdef UH2 v13
    cdef UH2 v14
    cdef UH3 v15
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = UH0_1()
    v4 = UH0_0(v2, v3)
    v5 = UH0_0(v1, v4)
    v6 = UH0_0(v0, v5)
    v7 = "a"
    v8 = "b"
    v9 = UH1_1()
    v10 = UH1_0(v8, v9)
    v11 = UH1_0(v7, v10)
    v12 = 1
    v13 = UH2_1()
    v14 = UH2_0(v12, v13)
    v15 = method0(v6, v11, v14)
    method5(v15)
