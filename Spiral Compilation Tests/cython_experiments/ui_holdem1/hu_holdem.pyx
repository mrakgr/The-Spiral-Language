import numpy
cimport numpy
cdef class Mut0:
    cdef public signed long v0
    def __init__(self, signed long v0): self.v0 = v0
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raiseTo_
    cdef readonly signed long v0
    def __init__(self, signed long v0): self.tag = 2; self.v0 = v0
cdef bint method0(Mut0 v0) except *:
    cdef signed long v1
    v1 = v0.v0
    return v1 < (<signed long>5)
cdef bint method1(signed long v0, Mut0 v1) except *:
    cdef signed long v2
    v2 = v1.v0
    return v2 < v0
cpdef numpy.ndarray[str,ndim=1] main():
    cdef numpy.ndarray[signed char,ndim=1] v0
    cdef numpy.ndarray[object,ndim=1] v1
    cdef Mut0 v2
    cdef signed long v4
    cdef bint v5
    cdef US0 v13
    cdef bint v7
    cdef signed long v9
    cdef signed long v10
    cdef signed long v14
    cdef signed long v15
    cdef unsigned long long tmp0
    cdef numpy.ndarray[str,ndim=1] v16
    cdef Mut0 v17
    cdef signed long v19
    cdef US0 v20
    cdef str v23
    cdef signed long v21
    cdef signed long v24
    v0 = numpy.arange(0,52,dtype=numpy.int8)
    numpy.random.shuffle(v0)
    del v0
    v1 = numpy.empty((<signed long>5),dtype=object)
    v2 = Mut0((<signed long>0))
    while method0(v2):
        v4 = v2.v0
        v5 = v4 == (<signed long>0)
        if v5:
            v13 = US0_1()
        else:
            v7 = v4 == (<signed long>1)
            if v7:
                v13 = US0_0()
            else:
                v9 = (<signed long>5) - v4
                v10 = v9 + (<signed long>2)
                v13 = US0_2(v10)
        v1[v4] = v13
        del v13
        v14 = v4 + (<signed long>1)
        v2.v0 = v14
    del v2
    tmp0 = len(v1)
    if <signed long>tmp0 != tmp0: raise Exception("The conversion to signed long failed.")
    v15 = len(v1)
    v16 = numpy.empty(v15,dtype=object)
    v17 = Mut0((<signed long>0))
    while method1(v15, v17):
        v19 = v17.v0
        v20 = v1[v19]
        if v20.tag == 0: # call
            v23 = "Call"
        elif v20.tag == 1: # fold
            v23 = "Fold"
        elif v20.tag == 2: # raiseTo_
            v21 = (<US0_2>v20).v0
            v23 = f'RaiseTo: {v21}'
        del v20
        v16[v19] = v23
        del v23
        v24 = v19 + (<signed long>1)
        v17.v0 = v24
    del v1
    del v17
    return v16
