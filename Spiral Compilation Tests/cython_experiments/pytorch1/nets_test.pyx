import torch
import torch.nn
import torch.distributions
import nets
import numpy
cimport numpy
cdef class ClosureTy1:
    cpdef void apply(self, unsigned long long v0, numpy.ndarray[float,ndim=1] v1): raise NotImplementedError()
cdef class ClosureTy0:
    cpdef ClosureTy1 apply(self, unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, unsigned long long v4, unsigned long long v5, unsigned long long v6): raise NotImplementedError()
cdef class Closure1(ClosureTy1):
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, unsigned long long v4, unsigned long long v5, unsigned long long v6): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6
    cpdef void apply(self, unsigned long long v7, numpy.ndarray[float,ndim=1] v8):
        cdef unsigned long long v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef unsigned long long v2 = self.v2
        cdef unsigned long long v3 = self.v3
        cdef unsigned long long v4 = self.v4
        cdef unsigned long long v5 = self.v5
        cdef unsigned long long v6 = self.v6
        cdef char v9
        cdef char v11
        cdef unsigned long long v12
        cdef unsigned long long v13
        cdef char v14
        cdef char v16
        cdef unsigned long long v17
        cdef unsigned long long v18
        cdef char v19
        cdef char v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef char v24
        cdef char v26
        cdef unsigned long long v27
        cdef unsigned long long v28
        cdef char v29
        cdef char v31
        cdef unsigned long long v32
        cdef unsigned long long v33
        cdef char v34
        cdef char v36
        cdef unsigned long long v37
        cdef unsigned long long v38
        cdef char v39
        cdef char v41
        cdef unsigned long long v42
        v9 = 0 <= v6
        if v9:
            v11 = v6 < 10
        else:
            v11 = 0
        if v11:
            v12 = v7 + v6
            v8[v12] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v13 = v7 + 10
        v14 = 0 <= v5
        if v14:
            v16 = v5 < 10
        else:
            v16 = 0
        if v16:
            v17 = v13 + v5
            v8[v17] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v18 = v13 + 10
        v19 = 0 <= v4
        if v19:
            v21 = v4 < 10
        else:
            v21 = 0
        if v21:
            v22 = v18 + v4
            v8[v22] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v23 = v18 + 10
        v24 = 0 <= v0
        if v24:
            v26 = v0 < 13
        else:
            v26 = 0
        if v26:
            v27 = v23 + v0
            v8[v27] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v28 = v23 + 13
        v29 = 0 <= v1
        if v29:
            v31 = v1 < 4
        else:
            v31 = 0
        if v31:
            v32 = v28 + v1
            v8[v32] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v33 = v23 + 17
        v34 = 0 <= v2
        if v34:
            v36 = v2 < 13
        else:
            v36 = 0
        if v36:
            v37 = v33 + v2
            v8[v37] = 1.000000
        else:
            raise Exception("Value out of bounds.")
        v38 = v33 + 13
        v39 = 0 <= v3
        if v39:
            v41 = v3 < 4
        else:
            v41 = 0
        if v41:
            v42 = v38 + v3
            v8[v42] = 1.000000
        else:
            raise Exception("Value out of bounds.")
cdef class Closure0(ClosureTy0):
    def __init__(self): pass
    cpdef ClosureTy1 apply(self, unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, unsigned long long v4, unsigned long long v5, unsigned long long v6):
        return Closure1(v0, v1, v2, v3, v4, v5, v6)
cdef class Tuple0:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    cdef readonly unsigned long long v2
    cdef readonly unsigned long long v3
    cdef readonly unsigned long long v4
    cdef readonly unsigned long long v5
    cdef readonly unsigned long long v6
    cdef readonly unsigned long long v7
    def __init__(self, unsigned long long v0, unsigned long long v1, unsigned long long v2, unsigned long long v3, unsigned long long v4, unsigned long long v5, unsigned long long v6, unsigned long long v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
cdef class ClosureTy2:
    cpdef Tuple0 apply(self, unsigned long long v0, numpy.ndarray[float,ndim=1] v1): raise NotImplementedError()
cdef class Tuple1:
    cdef readonly unsigned long long v0
    cdef readonly unsigned long long v1
    def __init__(self, unsigned long long v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef class Closure2(ClosureTy2):
    def __init__(self): pass
    cpdef Tuple0 apply(self, unsigned long long v0, numpy.ndarray[float,ndim=1] v1):
        cdef unsigned long long v2
        cdef unsigned long long v3
        cdef unsigned long long v4
        cdef Tuple1 tmp1
        cdef unsigned long long v5
        cdef unsigned long long v6
        cdef unsigned long long v7
        cdef Tuple1 tmp2
        cdef unsigned long long v8
        cdef unsigned long long v9
        cdef unsigned long long v10
        cdef Tuple1 tmp3
        cdef unsigned long long v11
        cdef unsigned long long v12
        cdef unsigned long long v13
        cdef Tuple1 tmp4
        cdef unsigned long long v14
        cdef unsigned long long v15
        cdef unsigned long long v16
        cdef Tuple1 tmp5
        cdef unsigned long long v17
        cdef char v18
        cdef unsigned long long v19
        cdef unsigned long long v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef Tuple1 tmp6
        cdef unsigned long long v24
        cdef unsigned long long v25
        cdef unsigned long long v26
        cdef Tuple1 tmp7
        cdef unsigned long long v27
        cdef char v28
        cdef unsigned long long v29
        cdef unsigned long long v30
        cdef char v31
        cdef unsigned long long v32
        cdef unsigned long long v33
        cdef char v34
        cdef unsigned long long v35
        cdef unsigned long long v36
        cdef char v37
        cdef unsigned long long v38
        cdef unsigned long long v39
        cdef char v40
        cdef unsigned long long v41
        v2 = v0 + 10
        tmp1 = method0(v1, v2, v0)
        v3, v4 = tmp1.v0, tmp1.v1
        del tmp1
        v5 = v2 + 10
        tmp2 = method0(v1, v5, v2)
        v6, v7 = tmp2.v0, tmp2.v1
        del tmp2
        v8 = v5 + 10
        tmp3 = method0(v1, v8, v5)
        v9, v10 = tmp3.v0, tmp3.v1
        del tmp3
        v11 = v8 + 13
        tmp4 = method0(v1, v11, v8)
        v12, v13 = tmp4.v0, tmp4.v1
        del tmp4
        v14 = v11 + 4
        tmp5 = method0(v1, v14, v11)
        v15, v16 = tmp5.v0, tmp5.v1
        del tmp5
        v17 = v13 + v16
        v18 = v17 == 1
        if v18:
            raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
        else:
            pass
        v19 = v17 // 2
        v20 = v8 + 17
        v21 = v20 + 13
        tmp6 = method0(v1, v21, v20)
        v22, v23 = tmp6.v0, tmp6.v1
        del tmp6
        v24 = v21 + 4
        tmp7 = method0(v1, v24, v21)
        v25, v26 = tmp7.v0, tmp7.v1
        del tmp7
        v27 = v23 + v26
        v28 = v27 == 1
        if v28:
            raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
        else:
            pass
        v29 = v27 // 2
        v30 = v19 + v29
        v31 = v30 == 1
        if v31:
            raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
        else:
            pass
        v32 = v30 // 2
        v33 = v10 + v32
        v34 = v33 == 1
        if v34:
            raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
        else:
            pass
        v35 = v33 // 2
        v36 = v7 + v35
        v37 = v36 == 1
        if v37:
            raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
        else:
            pass
        v38 = v36 // 2
        v39 = v4 + v38
        v40 = v39 == 1
        if v40:
            raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
        else:
            pass
        v41 = v39 // 2
        return Tuple0(v12, v15, v22, v25, v9, v6, v3, v41)
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise_
    cdef readonly unsigned long long v0
    def __init__(self, unsigned long long v0): self.tag = 2; self.v0 = v0
cdef class ClosureTy3:
    cpdef ClosureTy1 apply(self, US0 v0): raise NotImplementedError()
cdef class Closure4(ClosureTy1):
    cdef US0 v0
    def __init__(self, US0 v0): self.v0 = v0
    cpdef void apply(self, unsigned long long v1, numpy.ndarray[float,ndim=1] v2):
        cdef US0 v0 = self.v0
        cdef unsigned long long v3
        cdef unsigned long long v4
        cdef unsigned long long v5
        cdef char v6
        cdef char v8
        cdef unsigned long long v9
        if v0.tag == 0: # call
            v2[v1] = 1.000000
        elif v0.tag == 1: # fold
            v3 = v1 + 1
            v2[v3] = 1.000000
        elif v0.tag == 2: # raise_
            v4 = (<US0_2>v0).v0
            v5 = v1 + 2
            v6 = 0 <= v4
            if v6:
                v8 = v4 < 4
            else:
                v8 = 0
            if v8:
                v9 = v5 + v4
                v2[v9] = 1.000000
            else:
                raise Exception("Value out of bounds.")
cdef class Closure3(ClosureTy3):
    def __init__(self): pass
    cpdef ClosureTy1 apply(self, US0 v0):
        return Closure4(v0)
cdef class Tuple2:
    cdef readonly US0 v0
    cdef readonly unsigned long long v1
    def __init__(self, US0 v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
cdef class ClosureTy4:
    cpdef Tuple2 apply(self, unsigned long long v0, numpy.ndarray[float,ndim=1] v1): raise NotImplementedError()
cdef class Closure5(ClosureTy4):
    def __init__(self): pass
    cpdef Tuple2 apply(self, unsigned long long v0, numpy.ndarray[float,ndim=1] v1):
        cdef float v2
        cdef char v3
        cdef unsigned long long v7
        cdef char v4
        cdef unsigned long long v8
        cdef float v9
        cdef char v10
        cdef unsigned long long v14
        cdef char v11
        cdef unsigned long long v15
        cdef unsigned long long v16
        cdef unsigned long long v17
        cdef unsigned long long v18
        cdef Tuple1 tmp8
        cdef char v19
        cdef US0 v22
        cdef unsigned long long v23
        cdef char v24
        cdef US0 v26
        cdef unsigned long long v27
        cdef char v28
        v2 = v1[v0]
        v3 = v2 == 1.000000
        if v3:
            v7 = 1
        else:
            v4 = v2 == 0.000000
            if v4:
                v7 = 0
            else:
                raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
        v8 = v0 + 1
        v9 = v1[v8]
        v10 = v9 == 1.000000
        if v10:
            v14 = 1
        else:
            v11 = v9 == 0.000000
            if v11:
                v14 = 0
            else:
                raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
        v15 = v0 + 2
        v16 = v15 + 4
        tmp8 = method0(v1, v16, v15)
        v17, v18 = tmp8.v0, tmp8.v1
        del tmp8
        v19 = v14 == 1
        if v19:
            v22 = US0_1()
        else:
            v22 = US0_0()
        v23 = v7 + v14
        v24 = v18 == 1
        if v24:
            v26 = US0_2(v17)
        else:
            v26 = v22
        del v22
        v27 = v23 + v18
        v28 = 1 < v27
        if v28:
            raise Exception("Unpickling failure. Only a single case of an union type should be active at most.")
        else:
            pass
        return Tuple2(v26, v27)
cdef Tuple1 method1(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, unsigned long long v3, unsigned long long v4):
    cdef char v5
    cdef unsigned long long v6
    cdef float v7
    cdef char v8
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef char v9
    cdef unsigned long long v10
    v5 = v2 < v0
    if v5:
        v6 = v2 + 1
        v7 = v1[v2]
        v8 = v7 == 0.000000
        if v8:
            v15, v16 = v3, v4
        else:
            v9 = v7 == 1.000000
            if v9:
                v10 = v4 + 1
                v15, v16 = v2, v10
            else:
                raise Exception("Unpickling failure. The int type must either be active or inactive.")
        return method1(v0, v1, v6, v15, v16)
    else:
        return Tuple1(v3, v4)
cdef Tuple1 method0(numpy.ndarray[float,ndim=1] v0, unsigned long long v1, unsigned long long v2):
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef Tuple1 tmp0
    cdef char v7
    cdef unsigned long long v8
    v3 = 0
    v4 = 0
    tmp0 = method1(v1, v0, v2, v3, v4)
    v5, v6 = tmp0.v0, tmp0.v1
    del tmp0
    v7 = 1 < v6
    if v7:
        raise Exception("Unpickling failure. Too many active indices in the one-hot vector.")
    else:
        pass
    v8 = v5 - v2
    return Tuple1(v8, v6)
cdef void method3(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef char v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method3(v0, v1, v4)
    else:
        pass
cdef numpy.ndarray[float,ndim=1] method2(ClosureTy0 v0, unsigned long long v1, ClosureTy2 v2, unsigned long long v3, unsigned long long v4, unsigned long long v5, unsigned long long v6, unsigned long long v7, unsigned long long v8, unsigned long long v9):
    cdef numpy.ndarray[float,ndim=1] v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef ClosureTy1 v13
    v10 = numpy.empty(v1,dtype=numpy.float32)
    v11 = len(v10)
    v12 = 0
    method3(v11, v10, v12)
    v13 = v0.apply(v3, v4, v5, v6, v7, v8, v9)
    v13.apply(0, v10)
    del v13
    return v10
cdef void method4(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef char v3
    cdef unsigned long long v4
    cdef char v5
    cdef float v6
    v3 = v2 < 6
    if v3:
        v4 = v2 + 1
        v5 = v2 == v0
        if v5:
            v6 = 1.000000
        else:
            v6 = 0.000000
        v1[v2] = v6
        method4(v0, v1, v4)
    else:
        pass
cdef US0 method5(ClosureTy3 v0, unsigned long long v1, ClosureTy4 v2, numpy.ndarray[float,ndim=1] v3):
    cdef US0 v4
    cdef unsigned long long v5
    cdef Tuple2 tmp9
    cdef char v6
    cdef char v7
    tmp9 = v2.apply(0, v3)
    v4, v5 = tmp9.v0, tmp9.v1
    del tmp9
    v6 = v5 == 1
    v7 = v6 != 1
    if v7:
        raise Exception("Invalid format.")
    else:
        pass
    return v4
cpdef str main():
    cdef ClosureTy0 v0
    cdef unsigned long long v1
    cdef ClosureTy2 v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef numpy.ndarray[float,ndim=1] v10
    cdef object v11
    cdef object v12
    cdef object v13
    cdef object v14
    cdef object v15
    cdef unsigned long long v16
    cdef numpy.ndarray[float,ndim=1] v17
    cdef unsigned long long v18
    cdef ClosureTy3 v19
    cdef unsigned long long v20
    cdef ClosureTy4 v21
    cdef US0 v22
    cdef unsigned long long v25
    pass # import torch
    pass # import torch.nn
    pass # import torch.distributions
    pass # import nets
    v0 = Closure0()
    v1 = 64
    v2 = Closure2()
    v3 = 0
    v4 = 1
    v5 = 12
    v6 = 3
    v7 = 9
    v8 = 4
    v9 = 4
    v10 = method2(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
    del v0; del v2
    v11 = nets.small(64,32,6)
    v12 = torch.from_numpy(v10)
    del v10
    v13 = v11.forward(v12)
    del v11; del v12
    v14 = torch.distributions.Categorical(probs=v13)
    del v13
    v15 = v14.sample()
    del v14
    v16 = v15.item()
    del v15
    v17 = numpy.empty(6,dtype=numpy.float32)
    v18 = 0
    method4(v16, v17, v18)
    v19 = Closure3()
    v20 = 6
    v21 = Closure5()
    v22 = method5(v19, v20, v21, v17)
    del v17; del v19; del v21
    if v22.tag == 0: # call
        return f"Call"
    elif v22.tag == 1: # fold
        return f"Fold"
    elif v22.tag == 2: # raise_
        v25 = (<US0_2>v22).v0
        return f"Raise: {v25}"
