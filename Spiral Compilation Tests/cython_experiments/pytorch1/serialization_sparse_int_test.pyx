import numpy
cimport numpy
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # noAction
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise_
    cdef readonly unsigned long long v0
    def __init__(self, unsigned long long v0): self.tag = 2; self.v0 = v0
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    cdef readonly unsigned long long v2
    cdef readonly unsigned long long v3
    cdef readonly unsigned long long v4
    cdef readonly US0 v5
    cdef readonly unsigned long long v6
    cdef readonly unsigned long long v7
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, unsigned long long v4, US0 v5, unsigned long long v6, unsigned long long v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    def __init__(self, unsigned long long v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef unsigned long long method1(unsigned long long v0, unsigned long long v1):
    cdef char v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    v2 = v0 < 1
    if v2:
        v3 = v0 + 1
        v4 = v1 * 21594144
        return method1(v3, v4)
    else:
        return v1
cdef Tuple1 method3(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, unsigned long long v3, unsigned long long v4):
    cdef char v5
    cdef char v7
    cdef unsigned long long v51
    cdef unsigned long long v52
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef US0 v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef Tuple0 tmp0
    cdef char v16
    cdef char v17
    cdef unsigned long long v18
    cdef char v19
    cdef char v20
    cdef unsigned long long v21
    cdef char v22
    cdef char v23
    cdef unsigned long long v24
    cdef char v25
    cdef char v26
    cdef unsigned long long v27
    cdef char v28
    cdef char v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef char v32
    cdef char v33
    cdef unsigned long long v34
    cdef char v35
    cdef char v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef unsigned long long v44
    cdef unsigned long long v40
    cdef char v41
    cdef char v42
    cdef unsigned long long v45
    cdef unsigned long long v46
    cdef unsigned long long v47
    cdef unsigned long long v48
    cdef unsigned long long v49
    cdef unsigned long long v50
    cdef char v53
    cdef unsigned long long v54
    v5 = 0 <= v2
    if v5:
        v7 = v2 < v0
    else:
        v7 = 0
    if v7:
        tmp0 = v1[v2]
        v8, v9, v10, v11, v12, v13, v14, v15 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7
        del tmp0
        v16 = v15 < 11
        v17 = v16 == 0
        if v17:
            raise Exception("Value out of bounds.")
        else:
            pass
        v18 = v15 * 1963104
        v19 = v14 < 11
        v20 = v19 == 0
        if v20:
            raise Exception("Value out of bounds.")
        else:
            pass
        v21 = v14 * 178464
        v22 = v12 < 11
        v23 = v22 == 0
        if v23:
            raise Exception("Value out of bounds.")
        else:
            pass
        v24 = v12 * 16224
        v25 = v8 < 13
        v26 = v25 == 0
        if v26:
            raise Exception("Value out of bounds.")
        else:
            pass
        v27 = v8 * 4
        v28 = v9 < 4
        v29 = v28 == 0
        if v29:
            raise Exception("Value out of bounds.")
        else:
            pass
        v30 = v27 + v9
        v31 = v30 * 52
        v32 = v10 < 13
        v33 = v32 == 0
        if v33:
            raise Exception("Value out of bounds.")
        else:
            pass
        v34 = v10 * 4
        v35 = v11 < 4
        v36 = v35 == 0
        if v36:
            raise Exception("Value out of bounds.")
        else:
            pass
        v37 = v34 + v11
        v38 = v31 + v37
        v39 = v38 * 6
        if v13.tag == 0: # call
            v44 = 0
        elif v13.tag == 1: # noAction
            v44 = 1
        elif v13.tag == 2: # raise_
            v40 = (<US0_2>v13).v0
            v41 = v40 < 4
            v42 = v41 == 0
            if v42:
                raise Exception("Value out of bounds.")
            else:
                pass
            v44 = 2 + v40
        del v13
        v45 = v39 + v44
        v46 = v24 + v45
        v47 = v21 + v46
        v48 = v18 + v47
        v49 = v48 * v4
        v50 = v3 * v4
        v51, v52 = v49, v50
    else:
        v51, v52 = v3, v4
    v53 = 0 < v2
    if v53:
        v54 = v2 - 1
        return method3(v0, v1, v54, v51, v52)
    else:
        return Tuple1(v51, v52)
cdef unsigned long long method2(unsigned long long v0, numpy.ndarray[object,ndim=1] v1):
    cdef unsigned long long v2
    cdef char v3
    cdef char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef Tuple1 tmp1
    v2 = len(v1)
    v3 = 1 == v2
    v4 = v3 == 0
    if v4:
        raise Exception("The array must match the given size.")
    else:
        pass
    v5 = v2
    v6 = 0
    v7 = 1
    tmp1 = method3(v2, v1, v5, v6, v7)
    v8, v9 = tmp1.v0, tmp1.v1
    del tmp1
    return v8
cdef Tuple1 method5(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, unsigned long long v2, unsigned long long v3):
    cdef char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef char v9
    cdef char v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef char v13
    cdef char v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef char v17
    cdef char v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v22
    cdef char v23
    cdef char v24
    cdef unsigned long long v25
    cdef char v26
    cdef char v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef char v30
    cdef char v31
    cdef unsigned long long v32
    cdef char v33
    cdef char v34
    cdef unsigned long long v35
    cdef char v36
    cdef US0 v53
    cdef char v37
    cdef char v38
    cdef char v40
    cdef unsigned long long v41
    cdef char v42
    cdef char v43
    cdef char v45
    cdef unsigned long long v46
    cdef char v47
    cdef char v48
    cdef unsigned long long v54
    v4 = v1 < 1
    if v4:
        v5 = v1 + 1
        v6 = v2 // 21594144
        v7 = v3 // v6
        v8 = v7 // 1963104
        v9 = v8 < 11
        v10 = v9 == 0
        if v10:
            raise Exception("The index should be less than size.")
        else:
            pass
        v11 = v7 % 1963104
        v12 = v11 // 178464
        v13 = v12 < 11
        v14 = v13 == 0
        if v14:
            raise Exception("The index should be less than size.")
        else:
            pass
        v15 = v11 % 178464
        v16 = v15 // 16224
        v17 = v16 < 11
        v18 = v17 == 0
        if v18:
            raise Exception("The index should be less than size.")
        else:
            pass
        v19 = v15 % 16224
        v20 = v19 // 6
        v21 = v20 // 52
        v22 = v21 // 4
        v23 = v22 < 13
        v24 = v23 == 0
        if v24:
            raise Exception("The index should be less than size.")
        else:
            pass
        v25 = v21 % 4
        v26 = v25 < 4
        v27 = v26 == 0
        if v27:
            raise Exception("The index should be less than size.")
        else:
            pass
        v28 = v20 % 52
        v29 = v28 // 4
        v30 = v29 < 13
        v31 = v30 == 0
        if v31:
            raise Exception("The index should be less than size.")
        else:
            pass
        v32 = v28 % 4
        v33 = v32 < 4
        v34 = v33 == 0
        if v34:
            raise Exception("The index should be less than size.")
        else:
            pass
        v35 = v19 % 6
        v36 = v35 < 1
        if v36:
            v37 = v35 == 0
            v38 = v37 == 0
            if v38:
                raise Exception("The unit index should be 0.")
            else:
                pass
            v53 = US0_0()
        else:
            v40 = v35 < 2
            if v40:
                v41 = v35 - 1
                v42 = v41 == 0
                v43 = v42 == 0
                if v43:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                v53 = US0_1()
            else:
                v45 = v35 < 6
                if v45:
                    v46 = v35 - 2
                    v47 = v46 < 4
                    v48 = v47 == 0
                    if v48:
                        raise Exception("The index should be less than size.")
                    else:
                        pass
                    v53 = US0_2(v46)
                else:
                    raise Exception("Unpickling of an union failed.")
        v0[v1] = Tuple0(v22, v25, v29, v32, v16, v53, v12, v8)
        del v53
        v54 = v3 % v6
        return method5(v0, v5, v6, v54)
    else:
        return Tuple1(v2, v3)
cdef numpy.ndarray[object,ndim=1] method4(unsigned long long v0, unsigned long long v1):
    cdef char v2
    cdef char v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef Tuple1 tmp2
    v2 = v1 < v0
    v3 = v2 == 0
    if v3:
        raise Exception("The size of the argument is too large.")
    else:
        pass
    v4 = numpy.empty(1,dtype=object)
    v5 = 0
    tmp2 = method5(v4, v5, v0, v1)
    v6, v7 = tmp2.v0, tmp2.v1
    del tmp2
    return v4
cdef char method6(numpy.ndarray[object,ndim=1] v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef char v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef US0 v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef Tuple0 tmp3
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef US0 v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef Tuple0 tmp4
    cdef char v21
    cdef char v23
    cdef char v27
    cdef char v24
    cdef char v38
    cdef char v28
    cdef char v32
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef char v33
    cdef unsigned long long v39
    v3 = len(v0)
    v4 = v2 < v3
    if v4:
        tmp3 = v0[v2]
        v5, v6, v7, v8, v9, v10, v11, v12 = tmp3.v0, tmp3.v1, tmp3.v2, tmp3.v3, tmp3.v4, tmp3.v5, tmp3.v6, tmp3.v7
        del tmp3
        tmp4 = v1[v2]
        v13, v14, v15, v16, v17, v18, v19, v20 = tmp4.v0, tmp4.v1, tmp4.v2, tmp4.v3, tmp4.v4, tmp4.v5, tmp4.v6, tmp4.v7
        del tmp4
        v21 = v5 == v13
        if v21:
            v23 = v6 == v14
        else:
            v23 = 0
        if v23:
            v24 = v7 == v15
            if v24:
                v27 = v8 == v16
            else:
                v27 = 0
        else:
            v27 = 0
        if v27:
            v28 = v9 == v17
            if v28:
                if v10.tag == 0 and v18.tag == 0: # call
                    v32 = 1
                elif v10.tag == 1 and v18.tag == 1: # noAction
                    v32 = 1
                elif v10.tag == 2 and v18.tag == 2: # raise_
                    v29 = (<US0_2>v10).v0; v30 = (<US0_2>v18).v0
                    v32 = v29 == v30
                else:
                    v32 = 0
                if v32:
                    v33 = v11 == v19
                    if v33:
                        v38 = v12 == v20
                    else:
                        v38 = 0
                else:
                    v38 = 0
            else:
                v38 = 0
        else:
            v38 = 0
        del v10; del v18
        if v38:
            v39 = v2 + 1
            return method6(v0, v1, v39)
        else:
            return 0
    else:
        return 1
cdef void method0():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef US0 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef numpy.ndarray[object,ndim=1] v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef char v9
    cdef char v10
    cdef char v13
    cdef unsigned long long v11
    cdef char v14
    v0 = 0
    v1 = 1
    v2 = method1(v0, v1)
    v3 = US0_1()
    v4 = numpy.empty(1,dtype=object)
    v4[0] = Tuple0(0, 1, 12, 3, 10, v3, 5, 5)
    del v3
    v5 = method2(v2, v4)
    v6 = method4(v2, v5)
    v7 = len(v4)
    v8 = len(v6)
    v9 = v7 == v8
    v10 = v9 != 1
    if v10:
        v13 = 0
    else:
        v11 = 0
        v13 = method6(v4, v6, v11)
    del v4; del v6
    v14 = v13 == 0
    if v14:
        raise Exception("Serialization and deserialization should result in the same result.")
    else:
        pass
cpdef void main():
    method0()
