import torch
import torch.nn
import torch.distributions
import nets
import numpy
cimport numpy
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise_
    cdef readonly unsigned long long v0
    def __init__(self, unsigned long long v0): self.tag = 2; self.v0 = v0
cdef void method0(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef char v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method0(v0, v1, v4)
    else:
        pass
cdef US0 method1(unsigned long long v0):
    cdef char v1
    cdef char v2
    cdef char v3
    cdef char v4
    cdef char v5
    cdef char v7
    cdef unsigned long long v8
    cdef char v9
    cdef char v10
    cdef unsigned long long v12
    cdef char v13
    cdef char v14
    v1 = v0 < 6
    v2 = v1 == 0
    if v2:
        raise Exception("The size of the argument is too large.")
    else:
        pass
    v3 = v0 < 1
    if v3:
        v4 = v0 == 0
        v5 = v4 == 0
        if v5:
            raise Exception("The unit index should be 0.")
        else:
            pass
        return US0_0()
    else:
        v7 = v0 < 2
        if v7:
            v8 = v0 - 1
            v9 = v8 == 0
            v10 = v9 == 0
            if v10:
                raise Exception("The unit index should be 0.")
            else:
                pass
            return US0_1()
        else:
            if v1:
                v12 = v0 - 2
                v13 = v12 < 4
                v14 = v13 == 0
                if v14:
                    raise Exception("The index should be less than size.")
                else:
                    pass
                return US0_2(v12)
            else:
                raise Exception("Unpickling of an union failed.")
cpdef str main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef numpy.ndarray[float,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef char v10
    cdef char v12
    cdef char v13
    cdef char v15
    cdef unsigned long long v16
    cdef char v17
    cdef char v19
    cdef unsigned long long v20
    cdef char v21
    cdef char v23
    cdef unsigned long long v24
    cdef char v25
    cdef char v27
    cdef unsigned long long v28
    cdef char v29
    cdef char v31
    cdef unsigned long long v32
    cdef char v33
    cdef char v35
    cdef unsigned long long v36
    cdef object v37
    cdef object v38
    cdef object v39
    cdef object v40
    cdef object v41
    cdef unsigned long long v42
    cdef US0 v43
    cdef unsigned long long v46
    pass # import torch
    pass # import torch.nn
    pass # import torch.distributions
    pass # import nets
    v0 = 0
    v1 = 1
    v2 = 12
    v3 = 3
    v4 = 9
    v5 = 4
    v6 = 4
    v7 = numpy.empty(64,dtype=numpy.float32)
    v8 = len(v7)
    v9 = 0
    method0(v8, v7, v9)
    v10 = 0 <= v6
    if v10:
        v12 = v6 < 10
    else:
        v12 = 0
    if v12:
        v7[v6] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v13 = 0 <= v5
    if v13:
        v15 = v5 < 10
    else:
        v15 = 0
    if v15:
        v16 = 10 + v5
        v7[v16] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v17 = 0 <= v4
    if v17:
        v19 = v4 < 10
    else:
        v19 = 0
    if v19:
        v20 = 20 + v4
        v7[v20] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v21 = 0 <= v0
    if v21:
        v23 = v0 < 13
    else:
        v23 = 0
    if v23:
        v24 = 30 + v0
        v7[v24] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v25 = 0 <= v1
    if v25:
        v27 = v1 < 4
    else:
        v27 = 0
    if v27:
        v28 = 43 + v1
        v7[v28] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v29 = 0 <= v2
    if v29:
        v31 = v2 < 13
    else:
        v31 = 0
    if v31:
        v32 = 47 + v2
        v7[v32] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v33 = 0 <= v3
    if v33:
        v35 = v3 < 4
    else:
        v35 = 0
    if v35:
        v36 = 60 + v3
        v7[v36] = 1.000000
    else:
        raise Exception("Value out of bounds.")
    v37 = nets.small(64,32,6)
    v38 = torch.from_numpy(v7)
    del v7
    v39 = v37.forward(v38)
    del v37; del v38
    v40 = torch.distributions.Categorical(probs=v39)
    del v39
    v41 = v40.sample()
    del v40
    v42 = v41.item()
    del v41
    v43 = method1(v42)
    if v43.tag == 0: # call
        return f"Call"
    elif v43.tag == 1: # fold
        return f"Fold"
    elif v43.tag == 2: # raise_
        v46 = (<US0_2>v43).v0
        return f"Raise: {v46}"
