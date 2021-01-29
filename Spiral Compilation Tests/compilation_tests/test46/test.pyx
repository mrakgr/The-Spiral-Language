cdef class UH0:
    cdef readonly unsigned long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly str v0
    cdef readonly UH0 v1
    def __init__(self, str v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class US0:
    cdef readonly unsigned long tag
cdef class US0_0(US0): # error_
    cdef readonly UH0 v0
    def __init__(self, UH0 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # ok_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 1; self.v0 = v0
cdef class Tuple0:
    cdef readonly US0 v0
    cdef readonly signed long v1
    def __init__(self, US0 v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class US1:
    cdef readonly unsigned long tag
cdef class US1_0(US1): # error_
    cdef readonly UH0 v0
    def __init__(self, UH0 v0): self.tag = 0; self.v0 = v0
cdef class US1_1(US1): # ok_
    def __init__(self): self.tag = 1
cdef class Tuple1:
    cdef readonly US1 v0
    cdef readonly signed long v1
    def __init__(self, US1 v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class ClosureTy1:
    cpdef Tuple1 apply(self, signed long v0): raise NotImplementedError()
cdef class ClosureTy0:
    cpdef ClosureTy1 apply(self, str v0): raise NotImplementedError()
cdef class US3:
    cdef readonly unsigned long tag
cdef class US3_0(US3): # first
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # second
    def __init__(self): self.tag = 1
cdef class US2:
    cdef readonly unsigned long tag
cdef class US2_0(US2): # none
    def __init__(self): self.tag = 0
cdef class US2_1(US2): # some_
    cdef readonly US3 v0
    def __init__(self, US3 v0): self.tag = 1; self.v0 = v0
cdef class Closure1(ClosureTy1):
    cdef signed long v0
    cdef signed long v1
    cdef str v2
    def __init__(self, signed long v0, signed long v1, str v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    cpdef Tuple1 apply(self, signed long v3):
        cdef signed long v0 = self.v0
        cdef signed long v1 = self.v1
        cdef str v2 = self.v2
        cdef char v4
        cdef signed long v5
        cdef US0 v6
        cdef signed long v7
        cdef Tuple0 tmp2
        cdef US0 v18
        cdef signed long v19
        cdef UH0 v8
        cdef US0 v9
        cdef signed long v10
        cdef US1 v11
        cdef signed long v12
        cdef Tuple1 tmp3
        cdef UH0 v13
        cdef US0 v14
        cdef US0 v15
        cdef UH0 v20
        cdef US1 v21
        cdef signed long v22
        cdef char v23
        cdef list v24
        cdef signed long v25
        cdef US3 v26
        cdef US3 v27
        cdef US3 v28
        cdef str v29
        cdef signed long v30
        cdef ClosureTy0 v31
        cdef ClosureTy1 v32
        v4 = 0
        v5 = 0
        tmp2 = method0(v2, v3, v4, v5)
        v6, v7 = tmp2.v0, tmp2.v1
        if v6 == 0: # error_
            v8 = (<US0_0>v6).v0
            v9 = US0_0(v8)
            v18, v19 = v9, v7
        elif v6 == 1: # ok_
            v10 = (<US0_1>v6).v0
            tmp3 = method1(v2, v7)
            v11, v12 = tmp3.v0, tmp3.v1
            if v11 == 0: # error_
                v13 = (<US1_0>v11).v0
                v14 = US0_0(v13)
                v18, v19 = v14, v12
            elif v11 == 1: # ok_
                v15 = US0_1(v10)
                v18, v19 = v15, v12
        if v18 == 0: # error_
            v20 = (<US0_0>v18).v0
            v21 = US1_0(v20)
            return Tuple1(v21, v19)
        elif v18 == 1: # ok_
            v22 = (<US0_1>v18).v0
            v23 = 100 < v22
            if v23:
                raise Exception("The max input has been exceeded.")
            v24 = [None] * 101
            v25 = 0
            method3(v24, v25)
            v26 = US3_0()
            v27 = US3_1()
            v28 = method4(v24, v26, v27, v22)
            if v28 == 0: # first
                v29 = "First"
            elif v28 == 1: # second
                v29 = "Second"
            System.Console.WriteLine(v29)
            v30 = v1 + 1
            v31 = method2(v0, v30)
            v32 = v31.apply(v2)
            return v32.apply(v19)
cdef class Closure0(ClosureTy0):
    cdef signed long v0
    cdef signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
    cpdef ClosureTy1 apply(self, str v2):
        cdef signed long v0 = self.v0
        cdef signed long v1 = self.v1
        return Closure1(v0, v1, v2)
cdef class Closure3(ClosureTy1):
    def __init__(self): pass
    cpdef Tuple1 apply(self, signed long v0):
        cdef US1 v1
        v1 = US1_1()
        return Tuple1(v1, v0)
cdef class Closure2(ClosureTy0):
    def __init__(self): pass
    cpdef ClosureTy1 apply(self, str v0):
        return Closure3()
cdef Tuple0 method0(str v0, signed long v1, char v2, signed long v3):
    cdef char v4
    cdef char v7
    cdef signed long v5
    cdef US0 v49
    cdef signed long v50
    cdef str v8
    cdef str v9
    cdef char v10
    cdef char v11
    cdef signed long v12
    cdef signed long v13
    cdef char v14
    cdef char v16
    cdef US0 v17
    cdef UH0 v18
    cdef UH0 v19
    cdef US0 v20
    cdef UH0 v23
    cdef UH0 v24
    cdef US0 v25
    cdef str v28
    cdef str v29
    cdef char v30
    cdef char v31
    cdef str v32
    cdef signed long v33
    cdef signed long v34
    cdef char v35
    cdef char v37
    cdef US0 v38
    cdef UH0 v39
    cdef UH0 v40
    cdef US0 v41
    cdef UH0 v44
    cdef UH0 v45
    cdef US0 v46
    cdef UH0 v51
    cdef US0 v52
    cdef UH0 v53
    cdef UH0 v54
    cdef US0 v55
    cdef signed long v58
    cdef signed long v59
    cdef signed long v60
    cdef char v61
    cdef char v63
    cdef char v64
    cdef UH0 v67
    cdef UH0 v68
    cdef US0 v69
    v4 = 0 <= v1
    if v4:
        v5 = len(v0)
        v7 = v1 < v5
    else:
        v7 = 0
    if v7:
        v8 = v0[v1]
        v9 = System.Char.MaxValue
        v10 = v8 == v9
        v11 = v10 != 1
        if v11:
            v12 = v1 + 1
            v13 = int v8 - int '0'
            v14 = 0 <= v13
            if v14:
                v16 = v13 <= 9
            else:
                v16 = 0
            if v16:
                v17 = US0_1(v13)
                v49, v50 = v17, v12
            else:
                v18 = UH0_1()
                v19 = UH0_0("digit", v18)
                v20 = US0_0(v19)
                v49, v50 = v20, v12
        else:
            v23 = UH0_1()
            v24 = UH0_0("Out of bounds.", v23)
            v25 = US0_0(v24)
            v49, v50 = v25, v1
    else:
        v28 = System.Char.MaxValue
        v29 = System.Char.MaxValue
        v30 = v28 == v29
        v31 = v30 != 1
        if v31:
            v32 = v0[v1]
            v33 = v1 + 1
            v34 = int v32 - int '0'
            v35 = 0 <= v34
            if v35:
                v37 = v34 <= 9
            else:
                v37 = 0
            if v37:
                v38 = US0_1(v34)
                v49, v50 = v38, v33
            else:
                v39 = UH0_1()
                v40 = UH0_0("digit", v39)
                v41 = US0_0(v40)
                v49, v50 = v41, v33
        else:
            v44 = UH0_1()
            v45 = UH0_0("Out of bounds.", v44)
            v46 = US0_0(v45)
            v49, v50 = v46, v1
    if v49 == 0: # error_
        v51 = (<US0_0>v49).v0
        if v2:
            v52 = US0_1(v3)
            return Tuple0(v52, v50)
        else:
            v53 = UH0_1()
            v54 = UH0_0("i32", v53)
            v55 = US0_0(v54)
            return Tuple0(v55, v50)
    elif v49 == 1: # ok_
        v58 = (<US0_1>v49).v0
        v59 = v3 * 10
        v60 = v59 + v58
        v61 = v3 <= 214748364
        if v61:
            v63 = 0 <= v60
        else:
            v63 = 0
        if v63:
            v64 = 1
            return method0(v0, v50, v64, v60)
        else:
            v67 = UH0_1()
            v68 = UH0_0("The number is too large to be parsed as 32 bit int.", v67)
            v69 = US0_0(v68)
            return Tuple0(v69, v50)
cdef Tuple1 method1(str v0, signed long v1):
    cdef char v2
    cdef char v10
    cdef signed long v3
    cdef char v4
    cdef str v5
    cdef char v6
    cdef signed long v11
    cdef US1 v14
    v2 = 0 <= v1
    if v2:
        v3 = len(v0)
        v4 = v1 < v3
        if v4:
            v5 = v0[v1]
            v6 = v5 == ' '
            if v6:
                v10 = 1
            else:
                v10 = v5 == '\n'
        else:
            v10 = 0
    else:
        v10 = 0
    if v10:
        v11 = v1 + 1
        return method1(v0, v11)
    else:
        v14 = US1_1()
        return Tuple1(v14, v1)
cdef void method3(list v0, signed long v1):
    cdef char v2
    cdef signed long v3
    cdef US2 v4
    v2 = v1 < 101
    if v2:
        v3 = v1 + 1
        v4 = US2_0()
        v0[v1] = v4
        method3(v0, v3)
cdef US3 method4(list v0, US3 v1, US3 v2, signed long v3):
    cdef US2 v4
    cdef char v5
    cdef char v9
    cdef signed long v6
    cdef US3 v7
    cdef US3 v22
    cdef char v10
    cdef char v14
    cdef signed long v11
    cdef US3 v12
    cdef char v15
    cdef char v19
    cdef signed long v16
    cdef US3 v17
    cdef US2 v23
    cdef US3 v24
    cdef char v26
    cdef char v30
    cdef signed long v27
    cdef US3 v28
    cdef char v31
    cdef char v35
    cdef signed long v32
    cdef US3 v33
    cdef char v36
    cdef char v40
    cdef signed long v37
    cdef US3 v38
    if v1 == 0: # first
        v4 = v0[v3]
        if v4 == 0: # none
            v5 = v3 >= 2
            if v5:
                v6 = v3 - 2
                v7 = method4(v0, v2, v1, v6)
                if v7 == 0: # first
                    v9 = 1
                elif v7 == 1: # second
                    v9 = 0
            else:
                v9 = 0
            if v9:
                v22 = v1
            else:
                v10 = v3 >= 3
                if v10:
                    v11 = v3 - 3
                    v12 = method4(v0, v2, v1, v11)
                    if v12 == 0: # first
                        v14 = 1
                    elif v12 == 1: # second
                        v14 = 0
                else:
                    v14 = 0
                if v14:
                    v22 = v1
                else:
                    v15 = v3 >= 5
                    if v15:
                        v16 = v3 - 5
                        v17 = method4(v0, v2, v1, v16)
                        if v17 == 0: # first
                            v19 = 1
                        elif v17 == 1: # second
                            v19 = 0
                    else:
                        v19 = 0
                    if v19:
                        v22 = v1
                    else:
                        v22 = v2
            v23 = US2_1(v22)
            v0[v3] = v23
            return v22
        elif v4 == 1: # some_
            v24 = (<US2_1>v4).v0
            return v24
    elif v1 == 1: # second
        v26 = v3 >= 2
        if v26:
            v27 = v3 - 2
            v28 = method4(v0, v2, v1, v27)
            if v28 == 0: # first
                v30 = 0
            elif v28 == 1: # second
                v30 = 1
        else:
            v30 = 0
        if v30:
            return v1
        else:
            v31 = v3 >= 3
            if v31:
                v32 = v3 - 3
                v33 = method4(v0, v2, v1, v32)
                if v33 == 0: # first
                    v35 = 0
                elif v33 == 1: # second
                    v35 = 1
            else:
                v35 = 0
            if v35:
                return v1
            else:
                v36 = v3 >= 5
                if v36:
                    v37 = v3 - 5
                    v38 = method4(v0, v2, v1, v37)
                    if v38 == 0: # first
                        v40 = 0
                    elif v38 == 1: # second
                        v40 = 1
                else:
                    v40 = 0
                if v40:
                    return v1
                else:
                    return v2
cdef ClosureTy0 method2(signed long v0, signed long v1):
    cdef char v2
    cdef ClosureTy0 v3
    cdef ClosureTy0 v4
    v2 = v1 < v0
    if v2:
        v3 = Closure0(v0, v1)
        return v3
    else:
        v4 = Closure2()
        return v4
cdef void method5(UH0 v0):
    cdef str v1
    cdef UH0 v2
    if v0 == 0: # cons_
        v1 = (<UH0_0>v0).v0
        v2 = (<UH0_0>v0).v1
        print("{}".format(v1))
        method5(v2)
    elif v0 == 1: # nil
        pass
cpdef void main():
    cdef str v0
    cdef signed long v1
    cdef char v2
    cdef signed long v3
    cdef US0 v4
    cdef signed long v5
    cdef Tuple0 tmp0
    cdef US0 v16
    cdef signed long v17
    cdef UH0 v6
    cdef US0 v7
    cdef signed long v8
    cdef US1 v9
    cdef signed long v10
    cdef Tuple1 tmp1
    cdef UH0 v11
    cdef US0 v12
    cdef US0 v13
    cdef US1 v26
    cdef signed long v27
    cdef UH0 v18
    cdef US1 v19
    cdef signed long v20
    cdef signed long v21
    cdef ClosureTy0 v22
    cdef ClosureTy1 v23
    cdef Tuple1 tmp4
    cdef UH0 v28
    v0 = "8 1 2 3 4 5 6 7 10"
    v1 = 0
    v2 = 0
    v3 = 0
    tmp0 = method0(v0, v1, v2, v3)
    v4, v5 = tmp0.v0, tmp0.v1
    if v4 == 0: # error_
        v6 = (<US0_0>v4).v0
        v7 = US0_0(v6)
        v16, v17 = v7, v5
    elif v4 == 1: # ok_
        v8 = (<US0_1>v4).v0
        tmp1 = method1(v0, v5)
        v9, v10 = tmp1.v0, tmp1.v1
        if v9 == 0: # error_
            v11 = (<US1_0>v9).v0
            v12 = US0_0(v11)
            v16, v17 = v12, v10
        elif v9 == 1: # ok_
            v13 = US0_1(v8)
            v16, v17 = v13, v10
    if v16 == 0: # error_
        v18 = (<US0_0>v16).v0
        v19 = US1_0(v18)
        v26, v27 = v19, v17
    elif v16 == 1: # ok_
        v20 = (<US0_1>v16).v0
        v21 = 0
        v22 = method2(v20, v21)
        v23 = v22.apply(v0)
        tmp4 = v23.apply(v17)
        v26, v27 = tmp4.v0, tmp4.v1
    if v26 == 0: # error_
        v28 = (<US1_0>v26).v0
        print("Parsing failed at position {}".format(v27))
        print("Errors:")
        method5(v28)
    elif v26 == 1: # ok_
        pass
