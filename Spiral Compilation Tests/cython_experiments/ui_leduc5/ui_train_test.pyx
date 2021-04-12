import numpy
cimport numpy
cimport libc.math
import ui_train
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # jack
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # king
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # queen
    def __init__(self): self.tag = 2
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # call
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # fold
    def __init__(self): self.tag = 1
cdef class US3_2(US3): # raise
    def __init__(self): self.tag = 2
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # action_
    cdef readonly US3 v0
    def __init__(self, US3 v0): self.tag = 0; self.v0 = v0
cdef class US2_1(US2): # observation_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US2 v0
    cdef readonly UH0 v1
    def __init__(self, US2 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly double v1
    cdef readonly US0 v2
    cdef readonly unsigned char v3
    cdef readonly signed long v4
    cdef readonly US0 v5
    cdef readonly unsigned char v6
    cdef readonly signed long v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly object v10
    cdef readonly UH0 v11
    cdef readonly double v12
    cdef readonly double v13
    def __init__(self, v0, double v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, v10, UH0 v11, double v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
cdef class Tuple1:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly object v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, unsigned long long v0, UH0 v1, v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple3:
    cdef readonly double v0
    cdef readonly US3 v1
    def __init__(self, double v0, US3 v1): self.v0 = v0; self.v1 = v1
cdef class Closure0():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef US0 v3 = args.v2
        cdef unsigned char v4 = args.v3
        cdef signed long v5 = args.v4
        cdef US0 v6 = args.v5
        cdef unsigned char v7 = args.v6
        cdef signed long v8 = args.v7
        cdef US1 v9 = args.v8
        cdef unsigned char v10 = args.v9
        cdef object v11 = args.v10
        cdef UH0 v12 = args.v11
        cdef double v13 = args.v12
        cdef double v14 = args.v13
        cdef numpy.ndarray[object,ndim=1] v15
        cdef numpy.ndarray[double,ndim=1] v16
        cdef numpy.ndarray[double,ndim=1] v17
        cdef Tuple1 tmp2
        cdef double v18
        cdef double v19
        cdef numpy.ndarray[double,ndim=1] v20
        tmp2 = method2(v0, v1, v12)
        v15, v16, v17 = tmp2.v0, tmp2.v1, tmp2.v2
        del tmp2
        del v15; del v17
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method11(v16)
        del v16
        return method15(v1, v11, v19, v20)
cdef class Closure1():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef US0 v3 = args.v2
        cdef unsigned char v4 = args.v3
        cdef signed long v5 = args.v4
        cdef US0 v6 = args.v5
        cdef unsigned char v7 = args.v6
        cdef signed long v8 = args.v7
        cdef US1 v9 = args.v8
        cdef unsigned char v10 = args.v9
        cdef object v11 = args.v10
        cdef UH0 v12 = args.v11
        cdef double v13 = args.v12
        cdef double v14 = args.v13
        cdef numpy.ndarray[object,ndim=1] v15
        cdef numpy.ndarray[double,ndim=1] v16
        cdef numpy.ndarray[double,ndim=1] v17
        cdef Tuple1 tmp3
        cdef double v18
        cdef double v19
        cdef numpy.ndarray[double,ndim=1] v20
        tmp3 = method2(v0, v1, v12)
        v15, v16, v17 = tmp3.v0, tmp3.v1, tmp3.v2
        del tmp3
        del v15; del v16
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method17(v17)
        del v17
        return method15(v1, v11, v19, v20)
cdef class Closure2():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef US0 v3 = args.v2
        cdef unsigned char v4 = args.v3
        cdef signed long v5 = args.v4
        cdef US0 v6 = args.v5
        cdef unsigned char v7 = args.v6
        cdef signed long v8 = args.v7
        cdef US1 v9 = args.v8
        cdef unsigned char v10 = args.v9
        cdef object v11 = args.v10
        cdef UH0 v12 = args.v11
        cdef double v13 = args.v12
        cdef double v14 = args.v13
        cdef numpy.ndarray[object,ndim=1] v15
        cdef numpy.ndarray[double,ndim=1] v16
        cdef numpy.ndarray[double,ndim=1] v17
        cdef Tuple1 tmp4
        cdef double v18
        cdef double v19
        cdef numpy.ndarray[double,ndim=1] v20
        cdef unsigned long long v21
        cdef unsigned long long v22
        cdef bint v23
        cdef bint v24
        cdef numpy.ndarray[double,ndim=1] v25
        cdef unsigned long long v26
        cdef unsigned long long v27
        cdef unsigned long long v28
        cdef numpy.ndarray[double,ndim=1] v29
        cdef double v30
        cdef unsigned long long v31
        cdef unsigned long long v32
        tmp4 = method2(v0, v1, v12)
        v15, v16, v17 = tmp4.v0, tmp4.v1, tmp4.v2
        del tmp4
        del v15
        v18 = v2 + v14
        v19 = libc.math.exp(v18)
        v20 = method17(v17)
        v21 = len(v20)
        v22 = len(v1)
        v23 = v21 == v22
        v24 = v23 != 1
        if v24:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v25 = numpy.empty(v21,dtype=numpy.float64)
        v26 = 0
        method21(v21, v10, v11, v19, v20, v1, v25, v26)
        del v20
        v27 = len(v17)
        v28 = 0
        method22(v27, v19, v25, v17, v28)
        del v25
        v29 = method17(v17)
        del v17
        v30 = libc.math.exp(v13)
        v31 = len(v16)
        v32 = 0
        method23(v31, v29, v30, v16, v32)
        del v16
        return method15(v1, v11, v19, v29)
cdef class Tuple4:
    cdef readonly double v0
    cdef readonly US0 v1
    cdef readonly unsigned char v2
    cdef readonly signed long v3
    cdef readonly US0 v4
    cdef readonly unsigned char v5
    cdef readonly signed long v6
    cdef readonly US1 v7
    cdef readonly unsigned char v8
    cdef readonly UH0 v9
    cdef readonly double v10
    cdef readonly double v11
    def __init__(self, double v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, US1 v7, unsigned char v8, UH0 v9, double v10, double v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, Tuple4 args):
        cdef double v0 = args.v0
        cdef US0 v1 = args.v1
        cdef unsigned char v2 = args.v2
        cdef signed long v3 = args.v3
        cdef US0 v4 = args.v4
        cdef unsigned char v5 = args.v5
        cdef signed long v6 = args.v6
        cdef US1 v7 = args.v7
        cdef unsigned char v8 = args.v8
        cdef UH0 v9 = args.v9
        cdef double v10 = args.v10
        cdef double v11 = args.v11
        pass
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple5:
    cdef readonly UH0 v0
    cdef readonly double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
cdef class Tuple6:
    cdef readonly double v0
    cdef readonly UH0 v1
    cdef readonly double v2
    cdef readonly UH0 v3
    cdef readonly double v4
    def __init__(self, double v0, UH0 v1, double v2, UH0 v3, double v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple7:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure12():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US1 v9
    cdef double v10
    def __init__(self, v0, v1, v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US1 v9, double v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US1 v9 = self.v9
        cdef double v10 = self.v10
        cdef double v11 = args.v0
        cdef UH0 v12 = args.v1
        cdef double v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        v1(Tuple4(v11, v6, v7, v8, v3, v4, v5, v9, 0, v12, v13, v10))
        v1(Tuple4(v11, v3, v4, v5, v6, v7, v8, v9, 1, v14, v15, v10))
        return v10
cdef class Closure11():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef signed long v4
    cdef US0 v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef UH0 v12
    cdef double v13
    cdef UH0 v14
    cdef double v15
    cdef double v16
    def __init__(self, v0, v1, v2, Heap0 v3, signed long v4, US0 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, double v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef object v65
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef signed long v22
        cdef bint v23
        cdef bint v25
        cdef signed long v48
        cdef bint v26
        cdef bint v27
        cdef bint v30
        cdef bint v31
        cdef signed long v32
        cdef signed long v33
        cdef Tuple7 tmp9
        cdef signed long v34
        cdef signed long v35
        cdef Tuple7 tmp10
        cdef bint v36
        cdef signed long v39
        cdef bint v37
        cdef bint v40
        cdef bint v41
        cdef bint v42
        cdef bint v49
        cdef US1 v50
        cdef bint v52
        cdef US1 v53
        cdef US1 v55
        cdef signed long v56
        cdef US1 v60
        cdef signed long v62
        cdef signed long v63
        cdef double v66
        cdef US2 v67
        cdef UH0 v68
        cdef US2 v69
        cdef UH0 v70
        if v18.tag == 0: # call
            if v9.tag == 0: # jack
                v19 = 0
            elif v9.tag == 1: # king
                v19 = 2
            elif v9.tag == 2: # queen
                v19 = 1
            if v5.tag == 0: # jack
                v20 = 0
            elif v5.tag == 1: # king
                v20 = 2
            elif v5.tag == 2: # queen
                v20 = 1
            if v6.tag == 0: # jack
                v21 = 0
            elif v6.tag == 1: # king
                v21 = 2
            elif v6.tag == 2: # queen
                v21 = 1
            if v5.tag == 0: # jack
                v22 = 0
            elif v5.tag == 1: # king
                v22 = 2
            elif v5.tag == 2: # queen
                v22 = 1
            v23 = method36(v20, v19)
            if v23:
                v25 = method36(v22, v21)
            else:
                v25 = 0
            if v25:
                v26 = v19 < v21
                if v26:
                    v48 = -1
                else:
                    v27 = v19 > v21
                    if v27:
                        v48 = 1
                    else:
                        v48 = 0
            else:
                v30 = method36(v20, v19)
                if v30:
                    v48 = 1
                else:
                    v31 = method36(v22, v21)
                    if v31:
                        v48 = -1
                    else:
                        tmp9 = method37(v20, v19)
                        v32, v33 = tmp9.v0, tmp9.v1
                        del tmp9
                        tmp10 = method37(v22, v21)
                        v34, v35 = tmp10.v0, tmp10.v1
                        del tmp10
                        v36 = v32 < v34
                        if v36:
                            v39 = -1
                        else:
                            v37 = v32 > v34
                            if v37:
                                v39 = 1
                            else:
                                v39 = 0
                        v40 = v39 == 0
                        if v40:
                            v41 = v33 < v35
                            if v41:
                                v48 = -1
                            else:
                                v42 = v33 > v35
                                if v42:
                                    v48 = 1
                                else:
                                    v48 = 0
                        else:
                            v48 = v39
            v49 = v48 == 1
            if v49:
                v50 = US1_1(v5)
                v65 = method38(v0, v1, v2, v50, v6, v7, v8, v9, v10)
                del v50
            else:
                v52 = v48 == -1
                if v52:
                    v53 = US1_1(v5)
                    v65 = method39(v0, v1, v2, v53, v6, v7, v8, v9, v10)
                    del v53
                else:
                    v55 = US1_1(v5)
                    v56 = 0
                    v65 = method40(v0, v1, v2, v55, v6, v7, v8, v9, v10, v56)
                    del v55
        elif v18.tag == 1: # fold
            v60 = US1_1(v5)
            v65 = method41(v0, v1, v2, v60, v6, v7, v8, v9, v10, v11)
            del v60
        elif v18.tag == 2: # raise
            v62 = v4 - 1
            v63 = v8 + 4
            v65 = method34(v0, v1, v2, v3, v62, v5, v9, v10, v63, v6, v7, v8)
        v66 = v17 + v15
        v67 = US2_0(v18)
        v68 = UH0_0(v67, v14)
        del v67
        v69 = US2_0(v18)
        v70 = UH0_0(v69, v12)
        del v69
        return v65(Tuple6(v16, v68, v66, v70, v13))
cdef class Closure13():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef signed long v4
    cdef US0 v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef UH0 v12
    cdef double v13
    cdef UH0 v14
    cdef double v15
    cdef double v16
    def __init__(self, v0, v1, v2, Heap0 v3, signed long v4, US0 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, double v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef object v65
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef signed long v22
        cdef bint v23
        cdef bint v25
        cdef signed long v48
        cdef bint v26
        cdef bint v27
        cdef bint v30
        cdef bint v31
        cdef signed long v32
        cdef signed long v33
        cdef Tuple7 tmp11
        cdef signed long v34
        cdef signed long v35
        cdef Tuple7 tmp12
        cdef bint v36
        cdef signed long v39
        cdef bint v37
        cdef bint v40
        cdef bint v41
        cdef bint v42
        cdef bint v49
        cdef US1 v50
        cdef bint v52
        cdef US1 v53
        cdef US1 v55
        cdef signed long v56
        cdef US1 v60
        cdef signed long v62
        cdef signed long v63
        cdef double v66
        cdef US2 v67
        cdef UH0 v68
        cdef US2 v69
        cdef UH0 v70
        if v18.tag == 0: # call
            if v9.tag == 0: # jack
                v19 = 0
            elif v9.tag == 1: # king
                v19 = 2
            elif v9.tag == 2: # queen
                v19 = 1
            if v5.tag == 0: # jack
                v20 = 0
            elif v5.tag == 1: # king
                v20 = 2
            elif v5.tag == 2: # queen
                v20 = 1
            if v6.tag == 0: # jack
                v21 = 0
            elif v6.tag == 1: # king
                v21 = 2
            elif v6.tag == 2: # queen
                v21 = 1
            if v5.tag == 0: # jack
                v22 = 0
            elif v5.tag == 1: # king
                v22 = 2
            elif v5.tag == 2: # queen
                v22 = 1
            v23 = method36(v20, v19)
            if v23:
                v25 = method36(v22, v21)
            else:
                v25 = 0
            if v25:
                v26 = v19 < v21
                if v26:
                    v48 = -1
                else:
                    v27 = v19 > v21
                    if v27:
                        v48 = 1
                    else:
                        v48 = 0
            else:
                v30 = method36(v20, v19)
                if v30:
                    v48 = 1
                else:
                    v31 = method36(v22, v21)
                    if v31:
                        v48 = -1
                    else:
                        tmp11 = method37(v20, v19)
                        v32, v33 = tmp11.v0, tmp11.v1
                        del tmp11
                        tmp12 = method37(v22, v21)
                        v34, v35 = tmp12.v0, tmp12.v1
                        del tmp12
                        v36 = v32 < v34
                        if v36:
                            v39 = -1
                        else:
                            v37 = v32 > v34
                            if v37:
                                v39 = 1
                            else:
                                v39 = 0
                        v40 = v39 == 0
                        if v40:
                            v41 = v33 < v35
                            if v41:
                                v48 = -1
                            else:
                                v42 = v33 > v35
                                if v42:
                                    v48 = 1
                                else:
                                    v48 = 0
                        else:
                            v48 = v39
            v49 = v48 == 1
            if v49:
                v50 = US1_1(v5)
                v65 = method38(v0, v1, v2, v50, v6, v7, v8, v9, v10)
                del v50
            else:
                v52 = v48 == -1
                if v52:
                    v53 = US1_1(v5)
                    v65 = method39(v0, v1, v2, v53, v6, v7, v8, v9, v10)
                    del v53
                else:
                    v55 = US1_1(v5)
                    v56 = 0
                    v65 = method40(v0, v1, v2, v55, v6, v7, v8, v9, v10, v56)
                    del v55
        elif v18.tag == 1: # fold
            v60 = US1_1(v5)
            v65 = method41(v0, v1, v2, v60, v6, v7, v8, v9, v10, v11)
            del v60
        elif v18.tag == 2: # raise
            v62 = v4 - 1
            v63 = v8 + 4
            v65 = method34(v0, v1, v2, v3, v62, v5, v9, v10, v63, v6, v7, v8)
        v66 = v17 + v13
        v67 = US2_0(v18)
        v68 = UH0_0(v67, v14)
        del v67
        v69 = US2_0(v18)
        v70 = UH0_0(v69, v12)
        del v69
        return v65(Tuple6(v16, v68, v15, v70, v66))
cdef class Closure10():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef object v10
    cdef Heap0 v11
    cdef signed long v12
    def __init__(self, v0, v1, v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, numpy.ndarray[object,ndim=1] v10, Heap0 v11, signed long v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef Heap0 v11 = self.v11
        cdef signed long v12 = self.v12
        cdef double v13 = args.v0
        cdef UH0 v14 = args.v1
        cdef double v15 = args.v2
        cdef UH0 v16 = args.v3
        cdef double v17 = args.v4
        cdef bint v18
        cdef US1 v19
        cdef object v20
        cdef US1 v22
        cdef object v23
        v18 = v4 == 0
        if v18:
            v19 = US1_1(v9)
            v20 = Closure11(v0, v1, v2, v11, v12, v9, v6, v7, v8, v3, v4, v5, v16, v17, v14, v15, v13)
            return v2(Tuple0(v10, v13, v3, v4, v5, v6, v7, v8, v19, 0, v20, v14, v15, v17))
        else:
            v22 = US1_1(v9)
            v23 = Closure13(v0, v1, v2, v11, v12, v9, v6, v7, v8, v3, v4, v5, v16, v17, v14, v15, v13)
            return v0(Tuple0(v10, v13, v3, v4, v5, v6, v7, v8, v22, 1, v23, v16, v17, v15))
cdef class Closure9():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US0 v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v24
        cdef signed long v18
        cdef signed long v21
        cdef signed long v22
        cdef double v25
        cdef US2 v26
        cdef US2 v27
        cdef UH0 v28
        cdef UH0 v29
        cdef US2 v30
        cdef US2 v31
        cdef UH0 v32
        cdef UH0 v33
        if v17.tag == 0: # call
            v18 = 2
            v24 = method34(v0, v1, v2, v3, v18, v10, v7, v8, v9, v4, v5, v6)
        elif v17.tag == 1: # fold
            raise Exception("impossible")
        elif v17.tag == 2: # raise
            v21 = 1
            v22 = v6 + 4
            v24 = method34(v0, v1, v2, v3, v21, v10, v7, v8, v22, v4, v5, v6)
        v25 = v16 + v14
        v26 = US2_0(v17)
        v27 = US2_1(v10)
        v28 = UH0_0(v27, v13)
        del v27
        v29 = UH0_0(v26, v28)
        del v26; del v28
        v30 = US2_0(v17)
        v31 = US2_1(v10)
        v32 = UH0_0(v31, v11)
        del v31
        v33 = UH0_0(v30, v32)
        del v30; del v32
        return v24(Tuple6(v15, v29, v25, v33, v12))
cdef class Closure14():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US0 v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v24
        cdef signed long v18
        cdef signed long v21
        cdef signed long v22
        cdef double v25
        cdef US2 v26
        cdef US2 v27
        cdef UH0 v28
        cdef UH0 v29
        cdef US2 v30
        cdef US2 v31
        cdef UH0 v32
        cdef UH0 v33
        if v17.tag == 0: # call
            v18 = 2
            v24 = method34(v0, v1, v2, v3, v18, v10, v7, v8, v9, v4, v5, v6)
        elif v17.tag == 1: # fold
            raise Exception("impossible")
        elif v17.tag == 2: # raise
            v21 = 1
            v22 = v6 + 4
            v24 = method34(v0, v1, v2, v3, v21, v10, v7, v8, v22, v4, v5, v6)
        v25 = v16 + v12
        v26 = US2_0(v17)
        v27 = US2_1(v10)
        v28 = UH0_0(v27, v13)
        del v27
        v29 = UH0_0(v26, v28)
        del v26; del v28
        v30 = US2_0(v17)
        v31 = US2_1(v10)
        v32 = UH0_0(v31, v11)
        del v31
        v33 = UH0_0(v30, v32)
        del v30; del v32
        return v24(Tuple6(v15, v29, v14, v33, v25))
cdef class Closure8():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    def __init__(self, numpy.ndarray[object,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple6 args):
        cdef numpy.ndarray[object,ndim=1] v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef double v11 = args.v0
        cdef UH0 v12 = args.v1
        cdef double v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef unsigned long long v16
        cdef double v17
        v16 = 0
        v17 = 0.000000
        return method33(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17)
cdef class Closure16():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef object v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef UH0 v12
    cdef double v13
    cdef UH0 v14
    cdef double v15
    cdef double v16
    def __init__(self, v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, double v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef object v32
        cdef bint v19
        cdef US0 v20
        cdef unsigned char v21
        cdef signed long v22
        cdef US0 v23
        cdef unsigned char v24
        cdef signed long v25
        cdef US1 v27
        cdef signed long v29
        cdef signed long v30
        cdef double v33
        cdef US2 v34
        cdef UH0 v35
        cdef US2 v36
        cdef UH0 v37
        if v18.tag == 0: # call
            v19 = v10 == 0
            if v19:
                v20, v21, v22, v23, v24, v25 = v9, v10, v8, v6, v7, v8
            else:
                v20, v21, v22, v23, v24, v25 = v6, v7, v8, v9, v10, v8
            v32 = method32(v0, v1, v2, v3, v4, v23, v24, v25, v20, v21, v22)
            del v20; del v23
        elif v18.tag == 1: # fold
            v27 = US1_0()
            v32 = method41(v0, v1, v2, v27, v6, v7, v8, v9, v10, v11)
            del v27
        elif v18.tag == 2: # raise
            v29 = v5 - 1
            v30 = v8 + 2
            v32 = method42(v0, v1, v2, v3, v4, v29, v9, v10, v30, v6, v7, v8)
        v33 = v17 + v15
        v34 = US2_0(v18)
        v35 = UH0_0(v34, v14)
        del v34
        v36 = US2_0(v18)
        v37 = UH0_0(v36, v12)
        del v36
        return v32(Tuple6(v16, v35, v33, v37, v13))
cdef class Closure17():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef object v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef signed long v11
    cdef UH0 v12
    cdef double v13
    cdef UH0 v14
    cdef double v15
    cdef double v16
    def __init__(self, v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, UH0 v12, double v13, UH0 v14, double v15, double v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef signed long v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = self.v16
        cdef double v17 = args.v0
        cdef US3 v18 = args.v1
        cdef object v32
        cdef bint v19
        cdef US0 v20
        cdef unsigned char v21
        cdef signed long v22
        cdef US0 v23
        cdef unsigned char v24
        cdef signed long v25
        cdef US1 v27
        cdef signed long v29
        cdef signed long v30
        cdef double v33
        cdef US2 v34
        cdef UH0 v35
        cdef US2 v36
        cdef UH0 v37
        if v18.tag == 0: # call
            v19 = v10 == 0
            if v19:
                v20, v21, v22, v23, v24, v25 = v9, v10, v8, v6, v7, v8
            else:
                v20, v21, v22, v23, v24, v25 = v6, v7, v8, v9, v10, v8
            v32 = method32(v0, v1, v2, v3, v4, v23, v24, v25, v20, v21, v22)
            del v20; del v23
        elif v18.tag == 1: # fold
            v27 = US1_0()
            v32 = method41(v0, v1, v2, v27, v6, v7, v8, v9, v10, v11)
            del v27
        elif v18.tag == 2: # raise
            v29 = v5 - 1
            v30 = v8 + 2
            v32 = method42(v0, v1, v2, v3, v4, v29, v9, v10, v30, v6, v7, v8)
        v33 = v17 + v13
        v34 = US2_0(v18)
        v35 = UH0_0(v34, v14)
        del v34
        v36 = US2_0(v18)
        v37 = UH0_0(v36, v12)
        del v36
        return v32(Tuple6(v16, v35, v15, v37, v33))
cdef class Closure15():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef object v9
    cdef Heap0 v10
    cdef object v11
    cdef signed long v12
    def __init__(self, v0, v1, v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, numpy.ndarray[object,ndim=1] v9, Heap0 v10, numpy.ndarray[object,ndim=1] v11, signed long v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef numpy.ndarray[object,ndim=1] v11 = self.v11
        cdef signed long v12 = self.v12
        cdef double v13 = args.v0
        cdef UH0 v14 = args.v1
        cdef double v15 = args.v2
        cdef UH0 v16 = args.v3
        cdef double v17 = args.v4
        cdef bint v18
        cdef US1 v19
        cdef object v20
        cdef US1 v22
        cdef object v23
        v18 = v4 == 0
        if v18:
            v19 = US1_0()
            v20 = Closure16(v0, v1, v2, v10, v11, v12, v6, v7, v8, v3, v4, v5, v16, v17, v14, v15, v13)
            return v2(Tuple0(v9, v13, v3, v4, v5, v6, v7, v8, v19, 0, v20, v14, v15, v17))
        else:
            v22 = US1_0()
            v23 = Closure17(v0, v1, v2, v10, v11, v12, v6, v7, v8, v3, v4, v5, v16, v17, v14, v15, v13)
            return v0(Tuple0(v9, v13, v3, v4, v5, v6, v7, v8, v22, 1, v23, v16, v17, v15))
cdef class Closure7():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef object v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v31
        cdef bint v18
        cdef US0 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US0 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef US1 v26
        cdef signed long v28
        cdef signed long v29
        cdef double v32
        cdef US2 v33
        cdef UH0 v34
        cdef US2 v35
        cdef UH0 v36
        if v17.tag == 0: # call
            v18 = v10 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v9, v10, v8, v6, v7, v8
            else:
                v19, v20, v21, v22, v23, v24 = v6, v7, v8, v9, v10, v8
            v31 = method32(v0, v1, v2, v3, v4, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = US1_0()
            v31 = method39(v0, v1, v2, v26, v6, v7, v8, v9, v10)
            del v26
        elif v17.tag == 2: # raise
            v28 = v5 - 1
            v29 = v8 + 2
            v31 = method42(v0, v1, v2, v3, v4, v28, v9, v10, v29, v6, v7, v8)
        v32 = v16 + v14
        v33 = US2_0(v17)
        v34 = UH0_0(v33, v13)
        del v33
        v35 = US2_0(v17)
        v36 = UH0_0(v35, v11)
        del v35
        return v31(Tuple6(v15, v34, v32, v36, v12))
cdef class Closure18():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef object v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef unsigned char v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v31
        cdef bint v18
        cdef US0 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US0 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef US1 v26
        cdef signed long v28
        cdef signed long v29
        cdef double v32
        cdef US2 v33
        cdef UH0 v34
        cdef US2 v35
        cdef UH0 v36
        if v17.tag == 0: # call
            v18 = v10 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v9, v10, v8, v6, v7, v8
            else:
                v19, v20, v21, v22, v23, v24 = v6, v7, v8, v9, v10, v8
            v31 = method32(v0, v1, v2, v3, v4, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = US1_0()
            v31 = method39(v0, v1, v2, v26, v6, v7, v8, v9, v10)
            del v26
        elif v17.tag == 2: # raise
            v28 = v5 - 1
            v29 = v8 + 2
            v31 = method42(v0, v1, v2, v3, v4, v28, v9, v10, v29, v6, v7, v8)
        v32 = v16 + v12
        v33 = US2_0(v17)
        v34 = UH0_0(v33, v13)
        del v33
        v35 = US2_0(v17)
        v36 = UH0_0(v35, v11)
        del v35
        return v31(Tuple6(v15, v34, v14, v36, v32))
cdef class Closure6():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef object v8
    cdef Heap0 v9
    cdef object v10
    cdef signed long v11
    def __init__(self, v0, v1, v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, numpy.ndarray[object,ndim=1] v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed long v11 = self.v11
        cdef double v12 = args.v0
        cdef UH0 v13 = args.v1
        cdef double v14 = args.v2
        cdef UH0 v15 = args.v3
        cdef double v16 = args.v4
        cdef bint v17
        cdef US1 v18
        cdef object v19
        cdef US1 v21
        cdef object v22
        v17 = v4 == 0
        if v17:
            v18 = US1_0()
            v19 = Closure7(v0, v1, v2, v9, v10, v11, v6, v7, v5, v3, v4, v15, v16, v13, v14, v12)
            return v2(Tuple0(v8, v12, v3, v4, v5, v6, v7, v5, v18, 0, v19, v13, v14, v16))
        else:
            v21 = US1_0()
            v22 = Closure18(v0, v1, v2, v9, v10, v11, v6, v7, v5, v3, v4, v15, v16, v13, v14, v12)
            return v0(Tuple0(v8, v12, v3, v4, v5, v6, v7, v5, v21, 1, v22, v15, v16, v14))
cdef class Closure5():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef US0 v3
    cdef US0 v4
    cdef Heap0 v5
    cdef object v6
    cdef UH0 v7
    cdef double v8
    cdef UH0 v9
    cdef double v10
    cdef double v11
    def __init__(self, v0, v1, v2, US0 v3, US0 v4, Heap0 v5, numpy.ndarray[object,ndim=1] v6, UH0 v7, double v8, UH0 v9, double v10, double v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef US0 v3 = self.v3
        cdef US0 v4 = self.v4
        cdef Heap0 v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef UH0 v7 = self.v7
        cdef double v8 = self.v8
        cdef UH0 v9 = self.v9
        cdef double v10 = self.v10
        cdef double v11 = self.v11
        cdef double v12 = args.v0
        cdef US3 v13 = args.v1
        cdef object v26
        cdef signed long v14
        cdef unsigned char v15
        cdef signed long v16
        cdef unsigned char v17
        cdef signed long v20
        cdef unsigned char v21
        cdef signed long v22
        cdef unsigned char v23
        cdef signed long v24
        cdef double v27
        cdef US2 v28
        cdef UH0 v29
        cdef US2 v30
        cdef UH0 v31
        if v13.tag == 0: # call
            v14 = 2
            v15 = 1
            v16 = 1
            v17 = 0
            v26 = method30(v0, v1, v2, v5, v6, v14, v3, v17, v16, v4, v15)
        elif v13.tag == 1: # fold
            raise Exception("impossible")
        elif v13.tag == 2: # raise
            v20 = 1
            v21 = 1
            v22 = 1
            v23 = 0
            v24 = 3
            v26 = method42(v0, v1, v2, v5, v6, v20, v3, v23, v24, v4, v21, v22)
        v27 = v12 + v10
        v28 = US2_0(v13)
        v29 = UH0_0(v28, v9)
        del v28
        v30 = US2_0(v13)
        v31 = UH0_0(v30, v7)
        del v30
        return v26(Tuple6(v11, v29, v27, v31, v8))
cdef class Closure26():
    cdef object v0
    cdef object v1
    cdef US0 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US1 v8
    cdef double v9
    def __init__(self, v0, v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US1 v8, double v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US1 v8 = self.v8
        cdef double v9 = self.v9
        cdef double v10 = args.v0
        cdef UH0 v11 = args.v1
        cdef double v12 = args.v2
        cdef UH0 v13 = args.v3
        cdef double v14 = args.v4
        v1(Tuple4(v10, v5, v6, v7, v2, v3, v4, v8, 0, v11, v12, v9))
        v1(Tuple4(v10, v2, v3, v4, v5, v6, v7, v8, 1, v13, v14, v9))
        return v9
cdef class Closure25():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US0 v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v64
        cdef signed long v18
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef bint v22
        cdef bint v24
        cdef signed long v47
        cdef bint v25
        cdef bint v26
        cdef bint v29
        cdef bint v30
        cdef signed long v31
        cdef signed long v32
        cdef Tuple7 tmp17
        cdef signed long v33
        cdef signed long v34
        cdef Tuple7 tmp18
        cdef bint v35
        cdef signed long v38
        cdef bint v36
        cdef bint v39
        cdef bint v40
        cdef bint v41
        cdef bint v48
        cdef US1 v49
        cdef bint v51
        cdef US1 v52
        cdef US1 v54
        cdef signed long v55
        cdef US1 v59
        cdef signed long v61
        cdef signed long v62
        cdef double v65
        cdef US2 v66
        cdef UH0 v67
        cdef US2 v68
        cdef UH0 v69
        if v17.tag == 0: # call
            if v8.tag == 0: # jack
                v18 = 0
            elif v8.tag == 1: # king
                v18 = 2
            elif v8.tag == 2: # queen
                v18 = 1
            if v4.tag == 0: # jack
                v19 = 0
            elif v4.tag == 1: # king
                v19 = 2
            elif v4.tag == 2: # queen
                v19 = 1
            if v5.tag == 0: # jack
                v20 = 0
            elif v5.tag == 1: # king
                v20 = 2
            elif v5.tag == 2: # queen
                v20 = 1
            if v4.tag == 0: # jack
                v21 = 0
            elif v4.tag == 1: # king
                v21 = 2
            elif v4.tag == 2: # queen
                v21 = 1
            v22 = method36(v19, v18)
            if v22:
                v24 = method36(v21, v20)
            else:
                v24 = 0
            if v24:
                v25 = v18 < v20
                if v25:
                    v47 = -1
                else:
                    v26 = v18 > v20
                    if v26:
                        v47 = 1
                    else:
                        v47 = 0
            else:
                v29 = method36(v19, v18)
                if v29:
                    v47 = 1
                else:
                    v30 = method36(v21, v20)
                    if v30:
                        v47 = -1
                    else:
                        tmp17 = method37(v19, v18)
                        v31, v32 = tmp17.v0, tmp17.v1
                        del tmp17
                        tmp18 = method37(v21, v20)
                        v33, v34 = tmp18.v0, tmp18.v1
                        del tmp18
                        v35 = v31 < v33
                        if v35:
                            v38 = -1
                        else:
                            v36 = v31 > v33
                            if v36:
                                v38 = 1
                            else:
                                v38 = 0
                        v39 = v38 == 0
                        if v39:
                            v40 = v32 < v34
                            if v40:
                                v47 = -1
                            else:
                                v41 = v32 > v34
                                if v41:
                                    v47 = 1
                                else:
                                    v47 = 0
                        else:
                            v47 = v38
            v48 = v47 == 1
            if v48:
                v49 = US1_1(v4)
                v64 = method50(v0, v1, v49, v5, v6, v7, v8, v9)
                del v49
            else:
                v51 = v47 == -1
                if v51:
                    v52 = US1_1(v4)
                    v64 = method51(v0, v1, v52, v5, v6, v7, v8, v9)
                    del v52
                else:
                    v54 = US1_1(v4)
                    v55 = 0
                    v64 = method52(v0, v1, v54, v5, v6, v7, v8, v9, v55)
                    del v54
        elif v17.tag == 1: # fold
            v59 = US1_1(v4)
            v64 = method53(v0, v1, v59, v5, v6, v7, v8, v9, v10)
            del v59
        elif v17.tag == 2: # raise
            v61 = v3 - 1
            v62 = v7 + 4
            v64 = method49(v0, v1, v2, v61, v4, v8, v9, v62, v5, v6, v7)
        v65 = v16 + v14
        v66 = US2_0(v17)
        v67 = UH0_0(v66, v13)
        del v66
        v68 = US2_0(v17)
        v69 = UH0_0(v68, v11)
        del v68
        return v64(Tuple6(v15, v67, v65, v69, v12))
cdef class Closure27():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef signed long v3
    cdef US0 v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef signed long v3 = self.v3
        cdef US0 v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v64
        cdef signed long v18
        cdef signed long v19
        cdef signed long v20
        cdef signed long v21
        cdef bint v22
        cdef bint v24
        cdef signed long v47
        cdef bint v25
        cdef bint v26
        cdef bint v29
        cdef bint v30
        cdef signed long v31
        cdef signed long v32
        cdef Tuple7 tmp19
        cdef signed long v33
        cdef signed long v34
        cdef Tuple7 tmp20
        cdef bint v35
        cdef signed long v38
        cdef bint v36
        cdef bint v39
        cdef bint v40
        cdef bint v41
        cdef bint v48
        cdef US1 v49
        cdef bint v51
        cdef US1 v52
        cdef US1 v54
        cdef signed long v55
        cdef US1 v59
        cdef signed long v61
        cdef signed long v62
        cdef double v65
        cdef US2 v66
        cdef UH0 v67
        cdef US2 v68
        cdef UH0 v69
        if v17.tag == 0: # call
            if v8.tag == 0: # jack
                v18 = 0
            elif v8.tag == 1: # king
                v18 = 2
            elif v8.tag == 2: # queen
                v18 = 1
            if v4.tag == 0: # jack
                v19 = 0
            elif v4.tag == 1: # king
                v19 = 2
            elif v4.tag == 2: # queen
                v19 = 1
            if v5.tag == 0: # jack
                v20 = 0
            elif v5.tag == 1: # king
                v20 = 2
            elif v5.tag == 2: # queen
                v20 = 1
            if v4.tag == 0: # jack
                v21 = 0
            elif v4.tag == 1: # king
                v21 = 2
            elif v4.tag == 2: # queen
                v21 = 1
            v22 = method36(v19, v18)
            if v22:
                v24 = method36(v21, v20)
            else:
                v24 = 0
            if v24:
                v25 = v18 < v20
                if v25:
                    v47 = -1
                else:
                    v26 = v18 > v20
                    if v26:
                        v47 = 1
                    else:
                        v47 = 0
            else:
                v29 = method36(v19, v18)
                if v29:
                    v47 = 1
                else:
                    v30 = method36(v21, v20)
                    if v30:
                        v47 = -1
                    else:
                        tmp19 = method37(v19, v18)
                        v31, v32 = tmp19.v0, tmp19.v1
                        del tmp19
                        tmp20 = method37(v21, v20)
                        v33, v34 = tmp20.v0, tmp20.v1
                        del tmp20
                        v35 = v31 < v33
                        if v35:
                            v38 = -1
                        else:
                            v36 = v31 > v33
                            if v36:
                                v38 = 1
                            else:
                                v38 = 0
                        v39 = v38 == 0
                        if v39:
                            v40 = v32 < v34
                            if v40:
                                v47 = -1
                            else:
                                v41 = v32 > v34
                                if v41:
                                    v47 = 1
                                else:
                                    v47 = 0
                        else:
                            v47 = v38
            v48 = v47 == 1
            if v48:
                v49 = US1_1(v4)
                v64 = method50(v0, v1, v49, v5, v6, v7, v8, v9)
                del v49
            else:
                v51 = v47 == -1
                if v51:
                    v52 = US1_1(v4)
                    v64 = method51(v0, v1, v52, v5, v6, v7, v8, v9)
                    del v52
                else:
                    v54 = US1_1(v4)
                    v55 = 0
                    v64 = method52(v0, v1, v54, v5, v6, v7, v8, v9, v55)
                    del v54
        elif v17.tag == 1: # fold
            v59 = US1_1(v4)
            v64 = method53(v0, v1, v59, v5, v6, v7, v8, v9, v10)
            del v59
        elif v17.tag == 2: # raise
            v61 = v3 - 1
            v62 = v7 + 4
            v64 = method49(v0, v1, v2, v61, v4, v8, v9, v62, v5, v6, v7)
        v65 = v16 + v12
        v66 = US2_0(v17)
        v67 = UH0_0(v66, v13)
        del v66
        v68 = US2_0(v17)
        v69 = UH0_0(v68, v11)
        del v68
        return v64(Tuple6(v15, v67, v14, v69, v65))
cdef class Closure24():
    cdef object v0
    cdef object v1
    cdef US0 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef object v9
    cdef Heap0 v10
    cdef signed long v11
    def __init__(self, v0, v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, numpy.ndarray[object,ndim=1] v9, Heap0 v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef signed long v11 = self.v11
        cdef double v12 = args.v0
        cdef UH0 v13 = args.v1
        cdef double v14 = args.v2
        cdef UH0 v15 = args.v3
        cdef double v16 = args.v4
        cdef bint v17
        cdef US1 v18
        cdef object v19
        cdef US1 v21
        cdef object v22
        v17 = v3 == 0
        if v17:
            v18 = US1_1(v8)
            v19 = Closure25(v0, v1, v10, v11, v8, v5, v6, v7, v2, v3, v4, v15, v16, v13, v14, v12)
            return v0(Tuple0(v9, v12, v2, v3, v4, v5, v6, v7, v18, 0, v19, v13, v14, v16))
        else:
            v21 = US1_1(v8)
            v22 = Closure27(v0, v1, v10, v11, v8, v5, v6, v7, v2, v3, v4, v15, v16, v13, v14, v12)
            return v0(Tuple0(v9, v12, v2, v3, v4, v5, v6, v7, v21, 1, v22, v15, v16, v14))
cdef class Closure23():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef UH0 v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    def __init__(self, v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, UH0 v10, double v11, UH0 v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef object v23
        cdef signed long v17
        cdef signed long v20
        cdef signed long v21
        cdef double v24
        cdef US2 v25
        cdef US2 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef US2 v29
        cdef US2 v30
        cdef UH0 v31
        cdef UH0 v32
        if v16.tag == 0: # call
            v17 = 2
            v23 = method49(v0, v1, v2, v17, v9, v6, v7, v8, v3, v4, v5)
        elif v16.tag == 1: # fold
            raise Exception("impossible")
        elif v16.tag == 2: # raise
            v20 = 1
            v21 = v5 + 4
            v23 = method49(v0, v1, v2, v20, v9, v6, v7, v21, v3, v4, v5)
        v24 = v15 + v13
        v25 = US2_0(v16)
        v26 = US2_1(v9)
        v27 = UH0_0(v26, v12)
        del v26
        v28 = UH0_0(v25, v27)
        del v25; del v27
        v29 = US2_0(v16)
        v30 = US2_1(v9)
        v31 = UH0_0(v30, v10)
        del v30
        v32 = UH0_0(v29, v31)
        del v29; del v31
        return v23(Tuple6(v14, v28, v24, v32, v11))
cdef class Closure28():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    cdef US0 v9
    cdef UH0 v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    def __init__(self, v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, UH0 v10, double v11, UH0 v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US0 v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef object v23
        cdef signed long v17
        cdef signed long v20
        cdef signed long v21
        cdef double v24
        cdef US2 v25
        cdef US2 v26
        cdef UH0 v27
        cdef UH0 v28
        cdef US2 v29
        cdef US2 v30
        cdef UH0 v31
        cdef UH0 v32
        if v16.tag == 0: # call
            v17 = 2
            v23 = method49(v0, v1, v2, v17, v9, v6, v7, v8, v3, v4, v5)
        elif v16.tag == 1: # fold
            raise Exception("impossible")
        elif v16.tag == 2: # raise
            v20 = 1
            v21 = v5 + 4
            v23 = method49(v0, v1, v2, v20, v9, v6, v7, v21, v3, v4, v5)
        v24 = v15 + v11
        v25 = US2_0(v16)
        v26 = US2_1(v9)
        v27 = UH0_0(v26, v12)
        del v26
        v28 = UH0_0(v25, v27)
        del v25; del v27
        v29 = US2_0(v16)
        v30 = US2_1(v9)
        v31 = UH0_0(v30, v10)
        del v30
        v32 = UH0_0(v29, v31)
        del v29; del v31
        return v23(Tuple6(v14, v28, v13, v32, v24))
cdef class Closure22():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    def __init__(self, numpy.ndarray[object,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple6 args):
        cdef numpy.ndarray[object,ndim=1] v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef double v10 = args.v0
        cdef UH0 v11 = args.v1
        cdef double v12 = args.v2
        cdef UH0 v13 = args.v3
        cdef double v14 = args.v4
        cdef unsigned long long v15
        cdef double v16
        v15 = 0
        v16 = 0.000000
        return method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16)
cdef class Closure30():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef object v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v31
        cdef bint v18
        cdef US0 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US0 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef US1 v26
        cdef signed long v28
        cdef signed long v29
        cdef double v32
        cdef US2 v33
        cdef UH0 v34
        cdef US2 v35
        cdef UH0 v36
        if v17.tag == 0: # call
            v18 = v9 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v8, v9, v7, v5, v6, v7
            else:
                v19, v20, v21, v22, v23, v24 = v5, v6, v7, v8, v9, v7
            v31 = method47(v0, v1, v2, v3, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = US1_0()
            v31 = method53(v0, v1, v26, v5, v6, v7, v8, v9, v10)
            del v26
        elif v17.tag == 2: # raise
            v28 = v4 - 1
            v29 = v7 + 2
            v31 = method54(v0, v1, v2, v3, v28, v8, v9, v29, v5, v6, v7)
        v32 = v16 + v14
        v33 = US2_0(v17)
        v34 = UH0_0(v33, v13)
        del v33
        v35 = US2_0(v17)
        v36 = UH0_0(v35, v11)
        del v35
        return v31(Tuple6(v15, v34, v32, v36, v12))
cdef class Closure31():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef object v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef signed long v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    cdef double v15
    def __init__(self, v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, UH0 v11, double v12, UH0 v13, double v14, double v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef signed long v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = self.v15
        cdef double v16 = args.v0
        cdef US3 v17 = args.v1
        cdef object v31
        cdef bint v18
        cdef US0 v19
        cdef unsigned char v20
        cdef signed long v21
        cdef US0 v22
        cdef unsigned char v23
        cdef signed long v24
        cdef US1 v26
        cdef signed long v28
        cdef signed long v29
        cdef double v32
        cdef US2 v33
        cdef UH0 v34
        cdef US2 v35
        cdef UH0 v36
        if v17.tag == 0: # call
            v18 = v9 == 0
            if v18:
                v19, v20, v21, v22, v23, v24 = v8, v9, v7, v5, v6, v7
            else:
                v19, v20, v21, v22, v23, v24 = v5, v6, v7, v8, v9, v7
            v31 = method47(v0, v1, v2, v3, v22, v23, v24, v19, v20, v21)
            del v19; del v22
        elif v17.tag == 1: # fold
            v26 = US1_0()
            v31 = method53(v0, v1, v26, v5, v6, v7, v8, v9, v10)
            del v26
        elif v17.tag == 2: # raise
            v28 = v4 - 1
            v29 = v7 + 2
            v31 = method54(v0, v1, v2, v3, v28, v8, v9, v29, v5, v6, v7)
        v32 = v16 + v12
        v33 = US2_0(v17)
        v34 = UH0_0(v33, v13)
        del v33
        v35 = US2_0(v17)
        v36 = UH0_0(v35, v11)
        del v35
        return v31(Tuple6(v15, v34, v14, v36, v32))
cdef class Closure29():
    cdef object v0
    cdef object v1
    cdef US0 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef object v8
    cdef Heap0 v9
    cdef object v10
    cdef signed long v11
    def __init__(self, v0, v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, numpy.ndarray[object,ndim=1] v8, Heap0 v9, numpy.ndarray[object,ndim=1] v10, signed long v11): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef Heap0 v9 = self.v9
        cdef numpy.ndarray[object,ndim=1] v10 = self.v10
        cdef signed long v11 = self.v11
        cdef double v12 = args.v0
        cdef UH0 v13 = args.v1
        cdef double v14 = args.v2
        cdef UH0 v15 = args.v3
        cdef double v16 = args.v4
        cdef bint v17
        cdef US1 v18
        cdef object v19
        cdef US1 v21
        cdef object v22
        v17 = v3 == 0
        if v17:
            v18 = US1_0()
            v19 = Closure30(v0, v1, v9, v10, v11, v5, v6, v7, v2, v3, v4, v15, v16, v13, v14, v12)
            return v0(Tuple0(v8, v12, v2, v3, v4, v5, v6, v7, v18, 0, v19, v13, v14, v16))
        else:
            v21 = US1_0()
            v22 = Closure31(v0, v1, v9, v10, v11, v5, v6, v7, v2, v3, v4, v15, v16, v13, v14, v12)
            return v0(Tuple0(v8, v12, v2, v3, v4, v5, v6, v7, v21, 1, v22, v15, v16, v14))
cdef class Closure21():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef object v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef UH0 v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    def __init__(self, v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, UH0 v10, double v11, UH0 v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef object v30
        cdef bint v17
        cdef US0 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US0 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US1 v25
        cdef signed long v27
        cdef signed long v28
        cdef double v31
        cdef US2 v32
        cdef UH0 v33
        cdef US2 v34
        cdef UH0 v35
        if v16.tag == 0: # call
            v17 = v9 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v8, v9, v7, v5, v6, v7
            else:
                v18, v19, v20, v21, v22, v23 = v5, v6, v7, v8, v9, v7
            v30 = method47(v0, v1, v2, v3, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = US1_0()
            v30 = method51(v0, v1, v25, v5, v6, v7, v8, v9)
            del v25
        elif v16.tag == 2: # raise
            v27 = v4 - 1
            v28 = v7 + 2
            v30 = method54(v0, v1, v2, v3, v27, v8, v9, v28, v5, v6, v7)
        v31 = v15 + v13
        v32 = US2_0(v16)
        v33 = UH0_0(v32, v12)
        del v32
        v34 = US2_0(v16)
        v35 = UH0_0(v34, v10)
        del v34
        return v30(Tuple6(v14, v33, v31, v35, v11))
cdef class Closure32():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef object v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef signed long v7
    cdef US0 v8
    cdef unsigned char v9
    cdef UH0 v10
    cdef double v11
    cdef UH0 v12
    cdef double v13
    cdef double v14
    def __init__(self, v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, UH0 v10, double v11, UH0 v12, double v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef signed long v7 = self.v7
        cdef US0 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef UH0 v10 = self.v10
        cdef double v11 = self.v11
        cdef UH0 v12 = self.v12
        cdef double v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US3 v16 = args.v1
        cdef object v30
        cdef bint v17
        cdef US0 v18
        cdef unsigned char v19
        cdef signed long v20
        cdef US0 v21
        cdef unsigned char v22
        cdef signed long v23
        cdef US1 v25
        cdef signed long v27
        cdef signed long v28
        cdef double v31
        cdef US2 v32
        cdef UH0 v33
        cdef US2 v34
        cdef UH0 v35
        if v16.tag == 0: # call
            v17 = v9 == 0
            if v17:
                v18, v19, v20, v21, v22, v23 = v8, v9, v7, v5, v6, v7
            else:
                v18, v19, v20, v21, v22, v23 = v5, v6, v7, v8, v9, v7
            v30 = method47(v0, v1, v2, v3, v21, v22, v23, v18, v19, v20)
            del v18; del v21
        elif v16.tag == 1: # fold
            v25 = US1_0()
            v30 = method51(v0, v1, v25, v5, v6, v7, v8, v9)
            del v25
        elif v16.tag == 2: # raise
            v27 = v4 - 1
            v28 = v7 + 2
            v30 = method54(v0, v1, v2, v3, v27, v8, v9, v28, v5, v6, v7)
        v31 = v15 + v11
        v32 = US2_0(v16)
        v33 = UH0_0(v32, v12)
        del v32
        v34 = US2_0(v16)
        v35 = UH0_0(v34, v10)
        del v34
        return v30(Tuple6(v14, v33, v13, v35, v31))
cdef class Closure20():
    cdef object v0
    cdef object v1
    cdef US0 v2
    cdef unsigned char v3
    cdef signed long v4
    cdef US0 v5
    cdef unsigned char v6
    cdef object v7
    cdef Heap0 v8
    cdef object v9
    cdef signed long v10
    def __init__(self, v0, v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, numpy.ndarray[object,ndim=1] v7, Heap0 v8, numpy.ndarray[object,ndim=1] v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2 = self.v2
        cdef unsigned char v3 = self.v3
        cdef signed long v4 = self.v4
        cdef US0 v5 = self.v5
        cdef unsigned char v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef Heap0 v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef double v11 = args.v0
        cdef UH0 v12 = args.v1
        cdef double v13 = args.v2
        cdef UH0 v14 = args.v3
        cdef double v15 = args.v4
        cdef bint v16
        cdef US1 v17
        cdef object v18
        cdef US1 v20
        cdef object v21
        v16 = v3 == 0
        if v16:
            v17 = US1_0()
            v18 = Closure21(v0, v1, v8, v9, v10, v5, v6, v4, v2, v3, v14, v15, v12, v13, v11)
            return v0(Tuple0(v7, v11, v2, v3, v4, v5, v6, v4, v17, 0, v18, v12, v13, v15))
        else:
            v20 = US1_0()
            v21 = Closure32(v0, v1, v8, v9, v10, v5, v6, v4, v2, v3, v14, v15, v12, v13, v11)
            return v0(Tuple0(v7, v11, v2, v3, v4, v5, v6, v4, v20, 1, v21, v14, v15, v13))
cdef class Closure19():
    cdef object v0
    cdef object v1
    cdef US0 v2
    cdef US0 v3
    cdef Heap0 v4
    cdef object v5
    cdef UH0 v6
    cdef double v7
    cdef UH0 v8
    cdef double v9
    cdef double v10
    def __init__(self, v0, v1, US0 v2, US0 v3, Heap0 v4, numpy.ndarray[object,ndim=1] v5, UH0 v6, double v7, UH0 v8, double v9, double v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, Tuple3 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2 = self.v2
        cdef US0 v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef UH0 v6 = self.v6
        cdef double v7 = self.v7
        cdef UH0 v8 = self.v8
        cdef double v9 = self.v9
        cdef double v10 = self.v10
        cdef double v11 = args.v0
        cdef US3 v12 = args.v1
        cdef object v25
        cdef signed long v13
        cdef unsigned char v14
        cdef signed long v15
        cdef unsigned char v16
        cdef signed long v19
        cdef unsigned char v20
        cdef signed long v21
        cdef unsigned char v22
        cdef signed long v23
        cdef double v26
        cdef US2 v27
        cdef UH0 v28
        cdef US2 v29
        cdef UH0 v30
        if v12.tag == 0: # call
            v13 = 2
            v14 = 1
            v15 = 1
            v16 = 0
            v25 = method46(v0, v1, v4, v5, v13, v2, v16, v15, v3, v14)
        elif v12.tag == 1: # fold
            raise Exception("impossible")
        elif v12.tag == 2: # raise
            v19 = 1
            v20 = 1
            v21 = 1
            v22 = 0
            v23 = 3
            v25 = method54(v0, v1, v4, v5, v19, v2, v22, v23, v3, v20, v21)
        v26 = v11 + v9
        v27 = US2_0(v12)
        v28 = UH0_0(v27, v8)
        del v27
        v29 = US2_0(v12)
        v30 = UH0_0(v29, v6)
        del v29
        return v25(Tuple6(v10, v28, v26, v30, v7))
cdef class Closure3():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3
        cdef double v4
        cdef double v5
        v3 = Closure4()
        v4 = method24(v1, v3, v0)
        v5 = method24(v0, v3, v1)
        return method43(v2, v3)
cdef class Tuple8:
    cdef readonly UH0 v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, UH0 v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure33():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1
        cdef unsigned long long v2
        cdef list v3
        cdef unsigned long long v4
        v1 = method55(v0)
        v2 = len(v1)
        v3 = [None]*v2
        v4 = 0
        method59(v2, v1, v3, v4)
        del v1
        return v3
cdef void method1(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method1(v0, v1, v4)
    else:
        pass
cdef Mut0 method0(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut0 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = 0
    method1(v1, v3, v4)
    v5 = Mut0(v0, v3, 0)
    del v3
    return v5
cdef unsigned long long method3(UH0 v0):
    cdef US2 v1
    cdef UH0 v2
    cdef unsigned long long v25
    cdef US3 v3
    cdef unsigned long long v10
    cdef unsigned long long v4
    cdef unsigned long long v6
    cdef unsigned long long v8
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef US0 v14
    cdef unsigned long long v21
    cdef unsigned long long v15
    cdef unsigned long long v17
    cdef unsigned long long v19
    cdef unsigned long long v22
    cdef unsigned long long v23
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v32
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # action_
            v3 = (<US2_0>v1).v0
            if v3.tag == 0: # call
                v4 = 0
                v10 = 9973 * v4
            elif v3.tag == 1: # fold
                v6 = 1
                v10 = 9973 * v6
            elif v3.tag == 2: # raise
                v8 = 2
                v10 = 9973 * v8
            del v3
            v11 = 0
            v12 = 9973 * v11
            v25 = v10 + v12
        elif v1.tag == 1: # observation_
            v14 = (<US2_1>v1).v0
            if v14.tag == 0: # jack
                v15 = 0
                v21 = 9973 * v15
            elif v14.tag == 1: # king
                v17 = 1
                v21 = 9973 * v17
            elif v14.tag == 2: # queen
                v19 = 2
                v21 = 9973 * v19
            del v14
            v22 = 1
            v23 = 9973 * v22
            v25 = v21 + v23
        del v1
        v26 = v25 * 9973
        v27 = method3(v2)
        del v2
        v28 = v26 + v27
        v29 = 0
        v30 = 9973 * v29
        return v28 + v30
    elif v0.tag == 1: # nil
        v32 = 1
        return 9973 * v32
cdef bint method5(UH0 v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef US2 v4
    cdef UH0 v5
    cdef bint v12
    cdef US3 v6
    cdef US3 v7
    cdef US0 v9
    cdef US0 v10
    if v1.tag == 0 and v0.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1; v4 = (<UH0_0>v0).v0; v5 = (<UH0_0>v0).v1
        if v2.tag == 0 and v4.tag == 0: # action_
            v6 = (<US2_0>v2).v0; v7 = (<US2_0>v4).v0
            if v6.tag == 0 and v7.tag == 0: # call
                v12 = 1
            elif v6.tag == 1 and v7.tag == 1: # fold
                v12 = 1
            elif v6.tag == 2 and v7.tag == 2: # raise
                v12 = 1
            else:
                v12 = 0
            del v6; del v7
        elif v2.tag == 1 and v4.tag == 1: # observation_
            v9 = (<US2_1>v2).v0; v10 = (<US2_1>v4).v0
            if v9.tag == 0 and v10.tag == 0: # jack
                v12 = 1
            elif v9.tag == 1 and v10.tag == 1: # king
                v12 = 1
            elif v9.tag == 2 and v10.tag == 2: # queen
                v12 = 1
            else:
                v12 = 0
            del v9; del v10
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method5(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method6(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method6(v0, v1, v4)
    else:
        pass
cdef void method8(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v5 = [None]*0
        v1[v2] = v5
        del v5
        method8(v0, v1, v4)
    else:
        pass
cdef void method10(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef Tuple2 tmp1
    cdef unsigned long long v12
    cdef list v13
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        tmp1 = v3[v4]
        v7, v8, v9, v10, v11 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4
        del tmp1
        v12 = v7 % v1
        v13 = v2[v12]
        v13.append(Tuple2(v7, v8, v9, v10, v11))
        del v8; del v9; del v10; del v11; del v13
        method10(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method9(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = len(v7)
        v9 = 0
        method10(v8, v2, v3, v7, v9)
        del v7
        method9(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method7(Mut0 v0):
    cdef numpy.ndarray[object,ndim=1] v1
    cdef unsigned long long v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v1 = v0.v1
    v2 = len(v1)
    v3 = v2 * 3
    v4 = v3 // 2
    v5 = v4 + 3
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = 0
    method8(v5, v7, v8)
    v9 = 0
    method9(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + 2
    v0.v0 = v11
cdef Tuple1 method4(Mut0 v0, UH0 v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef numpy.ndarray[object,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef Tuple2 tmp0
    cdef bint v13
    cdef bint v15
    cdef unsigned long long v16
    cdef unsigned long long v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef unsigned long long v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef numpy.ndarray[object,ndim=1] v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef bint v35
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp0 = v4[v5]
        v8, v9, v10, v11, v12 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4
        del tmp0
        v13 = v3 == v8
        if v13:
            v15 = method5(v9, v1)
        else:
            v15 = 0
        del v9
        if v15:
            return Tuple1(v10, v11, v12)
        else:
            del v10; del v11; del v12
            v16 = v5 + 1
            return method4(v0, v1, v2, v3, v4, v16)
    else:
        v23 = len(v2)
        v24 = numpy.empty(v23,dtype=numpy.float64)
        v25 = 0
        method6(v23, v24, v25)
        v26 = numpy.empty(v23,dtype=numpy.float64)
        v27 = 0
        method6(v23, v26, v27)
        v4.append(Tuple2(v3, v1, v2, v26, v24))
        v28 = v0.v2
        v29 = v28 + 1
        v0.v2 = v29
        v30 = v0.v2
        v31 = v0.v0
        v32 = v0.v1
        v33 = len(v32)
        del v32
        v34 = v31 * v33
        v35 = v30 >= v34
        if v35:
            method7(v0)
        else:
            pass
        return Tuple1(v2, v26, v24)
cdef Tuple1 method2(Mut0 v0, numpy.ndarray[object,ndim=1] v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method3(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = 0
    return method4(v0, v2, v1, v4, v8, v9)
cdef double method12(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2, double v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    v4 = v2 < v0
    if v4:
        v5 = v2 + 1
        v6 = v1[v2]
        v7 = v3 + v6
        return method12(v0, v1, v5, v7)
    else:
        return v3
cdef void method13(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v2[v3] = v1
        method13(v0, v1, v2, v5)
    else:
        pass
cdef void method14(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v2[v4]
        v8 = v7 / v1
        v3[v4] = v8
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method11(numpy.ndarray[double,ndim=1] v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef double v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef bint v7
    cdef numpy.ndarray[double,ndim=1] v8
    cdef unsigned long long v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef unsigned long long v11
    v1 = len(v0)
    v2 = 0
    v3 = 0.000000
    v4 = method12(v1, v0, v2, v3)
    v5 = <double>v1
    v6 = 1.000000 / v5
    v7 = v4 == 0.000000
    if v7:
        v8 = numpy.empty(v1,dtype=numpy.float64)
        v9 = 0
        method13(v1, v6, v8, v9)
        return v8
    else:
        v10 = numpy.empty(v1,dtype=numpy.float64)
        v11 = 0
        method14(v1, v4, v0, v10, v11)
        return v10
cdef double method16(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[object,ndim=1] v4, unsigned long long v5, double v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    cdef US3 v10
    cdef bint v11
    cdef bint v13
    cdef double v16
    cdef double v14
    cdef double v17
    cdef double v18
    v7 = v5 < v0
    if v7:
        v8 = v5 + 1
        v9 = v3[v5]
        v10 = v4[v5]
        v11 = v9 == 0.000000
        if v11:
            v13 = v2 == 0.000000
        else:
            v13 = 0
        if v13:
            v16 = 0.000000
        else:
            v14 = libc.math.log(v9)
            v16 = v1(Tuple3(v14, v10))
        del v10
        v17 = v16 * v9
        v18 = v6 + v17
        return method16(v0, v1, v2, v3, v4, v8, v18)
    else:
        return v6
cdef double method15(numpy.ndarray[object,ndim=1] v0, v1, double v2, numpy.ndarray[double,ndim=1] v3):
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef bint v6
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    v4 = len(v3)
    v5 = len(v0)
    v6 = v4 == v5
    v7 = v6 == 0
    if v7:
        raise Exception("The length of the two arrays has to the same.")
    else:
        pass
    v8 = 0
    v9 = 0.000000
    return method16(v4, v1, v2, v3, v0, v8, v9)
cdef double method18(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4, double v5):
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef bint v10
    cdef double v11
    cdef double v12
    v6 = v4 < v0
    if v6:
        v7 = v4 + 1
        v8 = v2[v4]
        v9 = v8 - v1
        v10 = 0.000000 >= v9
        if v10:
            v11 = 0.000000
        else:
            v11 = v9
        v12 = v5 + v11
        v3[v4] = v11
        return method18(v0, v1, v2, v3, v7, v12)
    else:
        return v5
cdef void method19(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v2[v3]
        v2[v3] = v1
        method19(v0, v1, v2, v5)
    else:
        pass
cdef void method20(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v2[v3]
        v7 = v6 / v1
        v2[v3] = v7
        method20(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method17(numpy.ndarray[double,ndim=1] v0):
    cdef unsigned long long v1
    cdef double v2
    cdef double v3
    cdef unsigned long long v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef numpy.ndarray[double,ndim=1] v8
    cdef unsigned long long v9
    cdef double v10
    cdef double v11
    cdef bint v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    v1 = len(v0)
    v2 = <double>v1
    v3 = 1.000000 / v2
    v4 = 0
    v5 = 0.000000
    v6 = method12(v1, v0, v4, v5)
    v7 = v6 * v3
    v8 = numpy.empty(v1,dtype=numpy.float64)
    v9 = 0
    v10 = 0.000000
    v11 = method18(v1, v7, v0, v8, v9, v10)
    v12 = v11 == 0.000000
    if v12:
        v13 = len(v8)
        v14 = 0
        method19(v13, v3, v8, v14)
    else:
        v15 = len(v8)
        v16 = 0
        method20(v15, v11, v8, v16)
    return v8
cdef void method21(unsigned long long v0, unsigned char v1, v2, double v3, numpy.ndarray[double,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[double,ndim=1] v6, unsigned long long v7):
    cdef bint v8
    cdef unsigned long long v9
    cdef double v10
    cdef US3 v11
    cdef bint v12
    cdef bint v14
    cdef double v17
    cdef double v15
    cdef bint v18
    cdef double v20
    v8 = v7 < v0
    if v8:
        v9 = v7 + 1
        v10 = v4[v7]
        v11 = v5[v7]
        v12 = v10 == 0.000000
        if v12:
            v14 = v3 == 0.000000
        else:
            v14 = 0
        if v14:
            v17 = 0.000000
        else:
            v15 = libc.math.log(v10)
            v17 = v2(Tuple3(v15, v11))
        del v11
        v18 = v1 == 0
        if v18:
            v20 = v17
        else:
            v20 =  -v17
        v6[v7] = v20
        method21(v0, v1, v2, v3, v4, v5, v6, v9)
    else:
        pass
cdef void method22(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v3[v4]
        v8 = v2[v4]
        v9 = v1 * v8
        v10 = v7 + v9
        v3[v4] = v10
        method22(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method23(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v3[v4]
        v8 = v1[v4]
        v9 = v2 * v8
        v10 = v7 + v9
        v3[v4] = v10
        method23(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method26(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US0 v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1 <= v4
        if v7:
            v8 = v6
        else:
            v8 = v4
        v9 = v2[v8]
        v3[v4] = v9
        del v9
        method26(v0, v1, v2, v3, v6)
    else:
        pass
cdef Tuple5 method27(US0 v0, unsigned char v1, UH0 v2, double v3):
    cdef bint v4
    cdef US2 v5
    cdef UH0 v6
    v4 = 0 == v1
    if v4:
        v5 = US2_1(v0)
        v6 = UH0_0(v5, v2)
        del v5
        return Tuple5(v6, v3)
    else:
        return Tuple5(v2, v3)
cdef Tuple5 method29(US0 v0, unsigned char v1, UH0 v2, double v3):
    cdef bint v4
    cdef US2 v5
    cdef UH0 v6
    v4 = 1 == v1
    if v4:
        v5 = US2_1(v0)
        v6 = UH0_0(v5, v2)
        del v5
        return Tuple5(v6, v3)
    else:
        return Tuple5(v2, v3)
cdef numpy.ndarray[object,ndim=1] method31(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = 0 < v6
    if v7:
        return v0.v2
    else:
        v9 = 0 == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[object,ndim=1] method35(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = 0 < v7
    if v8:
        v10 = v6 == v3
    else:
        v10 = 0
    if v10:
        return v0.v2
    else:
        if v8:
            return v0.v1
        else:
            v13 = 0 == v7
            if v13:
                v15 = v6 == v3
            else:
                v15 = 0
            if v15:
                return v0.v0
            else:
                if v13:
                    return v0.v3
                else:
                    raise Exception("invalid action state")
cdef bint method36(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple7 method37(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple7(v1, v0)
    else:
        return Tuple7(v0, v1)
cdef object method38(v0, v1, v2, US1 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8):
    cdef bint v9
    cdef signed long v11
    cdef signed long v13
    cdef signed long v14
    cdef bint v15
    cdef signed long v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US0 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef double v25
    v9 = v8 == 0
    if v9:
        v11 = v6
    else:
        v11 =  -v6
    if v9:
        v13 = v11
    else:
        v13 =  -v11
    v14 = v13 + v6
    v15 = v5 == 0
    if v15:
        v17 = v11
    else:
        v17 =  -v11
    v18 = v17 + v6
    if v9:
        v19, v20, v21, v22, v23, v24 = v7, v8, v14, v4, v5, v18
    else:
        v19, v20, v21, v22, v23, v24 = v4, v5, v18, v7, v8, v14
    v25 = <double>v11
    return Closure12(v0, v1, v2, v22, v23, v24, v19, v20, v21, v3, v25)
cdef object method39(v0, v1, v2, US1 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8):
    cdef bint v9
    cdef signed long v11
    cdef bint v12
    cdef signed long v14
    cdef signed long v15
    cdef signed long v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US0 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef double v25
    v9 = v5 == 0
    if v9:
        v11 = v6
    else:
        v11 =  -v6
    v12 = v8 == 0
    if v12:
        v14 = v11
    else:
        v14 =  -v11
    v15 = v14 + v6
    if v9:
        v17 = v11
    else:
        v17 =  -v11
    v18 = v17 + v6
    if v12:
        v19, v20, v21, v22, v23, v24 = v7, v8, v15, v4, v5, v18
    else:
        v19, v20, v21, v22, v23, v24 = v4, v5, v18, v7, v8, v15
    v25 = <double>v11
    return Closure12(v0, v1, v2, v22, v23, v24, v19, v20, v21, v3, v25)
cdef object method40(v0, v1, v2, US1 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9):
    cdef bint v10
    cdef signed long v12
    cdef signed long v14
    cdef signed long v15
    cdef bint v16
    cdef signed long v18
    cdef signed long v19
    cdef US0 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef US0 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef double v26
    v10 = v8 == 0
    if v10:
        v12 = v9
    else:
        v12 =  -v9
    if v10:
        v14 = v12
    else:
        v14 =  -v12
    v15 = v14 + v6
    v16 = v5 == 0
    if v16:
        v18 = v12
    else:
        v18 =  -v12
    v19 = v18 + v6
    if v10:
        v20, v21, v22, v23, v24, v25 = v7, v8, v15, v4, v5, v19
    else:
        v20, v21, v22, v23, v24, v25 = v4, v5, v19, v7, v8, v15
    v26 = <double>v12
    return Closure12(v0, v1, v2, v23, v24, v25, v20, v21, v22, v3, v26)
cdef object method41(v0, v1, v2, US1 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9):
    cdef bint v10
    cdef signed long v12
    cdef bint v13
    cdef signed long v15
    cdef signed long v16
    cdef signed long v18
    cdef signed long v19
    cdef US0 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef US0 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef double v26
    v10 = v5 == 0
    if v10:
        v12 = v9
    else:
        v12 =  -v9
    v13 = v8 == 0
    if v13:
        v15 = v12
    else:
        v15 =  -v12
    v16 = v15 + v9
    if v10:
        v18 = v12
    else:
        v18 =  -v12
    v19 = v18 + v6
    if v13:
        v20, v21, v22, v23, v24, v25 = v7, v8, v16, v4, v5, v19
    else:
        v20, v21, v22, v23, v24, v25 = v4, v5, v19, v7, v8, v16
    v26 = <double>v12
    return Closure12(v0, v1, v2, v23, v24, v25, v20, v21, v22, v3, v26)
cdef object method34(v0, v1, v2, Heap0 v3, signed long v4, US0 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11):
    cdef numpy.ndarray[object,ndim=1] v12
    v12 = method35(v3, v6, v7, v8, v9, v10, v11, v4)
    return Closure10(v0, v1, v2, v9, v10, v11, v6, v7, v8, v5, v12, v3, v4)
cdef double method33(numpy.ndarray[object,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, double v11, UH0 v12, double v13, UH0 v14, double v15, unsigned long long v16, double v17):
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef bint v21
    cdef US0 v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef bint v28
    cdef double v39
    cdef US1 v29
    cdef object v30
    cdef US2 v31
    cdef UH0 v32
    cdef US1 v34
    cdef object v35
    cdef US2 v36
    cdef UH0 v37
    cdef unsigned long long v40
    cdef double v41
    cdef double v43
    v18 = len(v0)
    v19 = <double>v18
    v20 = 1.000000 / v19
    v21 = v16 < v18
    if v21:
        v22 = v0[v16]
        v23 = <double>v18
        v24 = 1.000000 / v23
        v25 = libc.math.log(v24)
        v26 = v25 + v11
        v27 = v4.v2
        v28 = v9 == 0
        if v28:
            v29 = US1_1(v22)
            v30 = Closure9(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v22, v14, v15, v12, v13, v26)
            v31 = US2_1(v22)
            v32 = UH0_0(v31, v12)
            del v31
            v39 = v3(Tuple0(v27, v26, v8, v9, v10, v5, v6, v7, v29, 0, v30, v32, v13, v15))
            del v29; del v30; del v32
        else:
            v34 = US1_1(v22)
            v35 = Closure14(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v22, v14, v15, v12, v13, v26)
            v36 = US2_1(v22)
            v37 = UH0_0(v36, v14)
            del v36
            v39 = v1(Tuple0(v27, v26, v8, v9, v10, v5, v6, v7, v34, 1, v35, v37, v15, v13))
            del v34; del v35; del v37
        del v22; del v27
        v40 = v16 + 1
        v41 = v17 + v39
        return method33(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v40, v41)
    else:
        v43 = v17 * v20
        return v43
cdef object method32(v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10):
    return Closure8(v4, v0, v1, v2, v3, v5, v6, v7, v8, v9, v10)
cdef object method42(v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11):
    cdef numpy.ndarray[object,ndim=1] v12
    v12 = method35(v3, v6, v7, v8, v9, v10, v11, v5)
    return Closure15(v0, v1, v2, v9, v10, v11, v6, v7, v8, v12, v3, v4, v5)
cdef object method30(v0, v1, v2, Heap0 v3, numpy.ndarray[object,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method31(v3, v6, v7, v8, v9, v10, v5)
    return Closure6(v0, v1, v2, v9, v10, v8, v6, v7, v11, v3, v4, v5)
cdef double method28(numpy.ndarray[object,ndim=1] v0, v1, v2, v3, Heap0 v4, US0 v5, double v6, UH0 v7, double v8, UH0 v9, double v10, unsigned long long v11, double v12):
    cdef unsigned long long v13
    cdef double v14
    cdef double v15
    cdef bint v16
    cdef US0 v17
    cdef unsigned long long v18
    cdef numpy.ndarray[object,ndim=1] v19
    cdef unsigned long long v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef unsigned char v25
    cdef UH0 v26
    cdef double v27
    cdef Tuple5 tmp7
    cdef unsigned char v28
    cdef UH0 v29
    cdef double v30
    cdef Tuple5 tmp8
    cdef numpy.ndarray[object,ndim=1] v31
    cdef US1 v32
    cdef object v33
    cdef double v34
    cdef unsigned long long v35
    cdef double v36
    cdef double v38
    v13 = len(v0)
    v14 = <double>v13
    v15 = 1.000000 / v14
    v16 = v11 < v13
    if v16:
        v17 = v0[v11]
        v18 = v13 - 1
        v19 = numpy.empty(v18,dtype=object)
        v20 = 0
        method26(v18, v11, v0, v19, v20)
        v21 = <double>v13
        v22 = 1.000000 / v21
        v23 = libc.math.log(v22)
        v24 = v23 + v6
        v25 = 0
        tmp7 = method29(v17, v25, v7, v8)
        v26, v27 = tmp7.v0, tmp7.v1
        del tmp7
        v28 = 1
        tmp8 = method29(v17, v28, v9, v10)
        v29, v30 = tmp8.v0, tmp8.v1
        del tmp8
        v31 = v4.v2
        v32 = US1_0()
        v33 = Closure5(v1, v2, v3, v5, v17, v4, v19, v29, v30, v26, v27, v24)
        del v19; del v29
        v34 = v3(Tuple0(v31, v24, v5, 0, 1, v17, 1, 1, v32, 0, v33, v26, v27, v30))
        del v17; del v26; del v31; del v32; del v33
        v35 = v11 + 1
        v36 = v12 + v34
        return method28(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v35, v36)
    else:
        v38 = v12 * v15
        return v38
cdef double method25(numpy.ndarray[object,ndim=1] v0, v1, v2, v3, Heap0 v4, UH0 v5, double v6, UH0 v7, double v8, unsigned long long v9, double v10):
    cdef unsigned long long v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef US0 v15
    cdef unsigned long long v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef unsigned char v22
    cdef UH0 v23
    cdef double v24
    cdef Tuple5 tmp5
    cdef unsigned char v25
    cdef UH0 v26
    cdef double v27
    cdef Tuple5 tmp6
    cdef unsigned long long v28
    cdef double v29
    cdef double v30
    cdef unsigned long long v31
    cdef double v32
    cdef double v34
    v11 = len(v0)
    v12 = <double>v11
    v13 = 1.000000 / v12
    v14 = v9 < v11
    if v14:
        v15 = v0[v9]
        v16 = v11 - 1
        v17 = numpy.empty(v16,dtype=object)
        v18 = 0
        method26(v16, v9, v0, v17, v18)
        v19 = <double>v11
        v20 = 1.000000 / v19
        v21 = libc.math.log(v20)
        v22 = 0
        tmp5 = method27(v15, v22, v5, v6)
        v23, v24 = tmp5.v0, tmp5.v1
        del tmp5
        v25 = 1
        tmp6 = method27(v15, v25, v7, v8)
        v26, v27 = tmp6.v0, tmp6.v1
        del tmp6
        v28 = 0
        v29 = 0.000000
        v30 = method28(v17, v1, v2, v3, v4, v15, v21, v23, v24, v26, v27, v28, v29)
        del v15; del v17; del v23; del v26
        v31 = v9 + 1
        v32 = v10 + v30
        return method25(v0, v1, v2, v3, v4, v5, v6, v7, v8, v31, v32)
    else:
        v34 = v10 * v13
        return v34
cdef double method24(v0, v1, v2):
    cdef UH0 v3
    cdef double v4
    cdef UH0 v5
    cdef double v6
    cdef US3 v7
    cdef US3 v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef US3 v10
    cdef US3 v11
    cdef US3 v12
    cdef numpy.ndarray[object,ndim=1] v13
    cdef US3 v14
    cdef US3 v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef US3 v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef Heap0 v19
    cdef US0 v20
    cdef US0 v21
    cdef US0 v22
    cdef US0 v23
    cdef US0 v24
    cdef US0 v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef unsigned long long v27
    cdef double v28
    v3 = UH0_1()
    v4 = 0.000000
    v5 = UH0_1()
    v6 = 0.000000
    v7 = US3_0()
    v8 = US3_2()
    v9 = numpy.empty(2,dtype=object)
    v9[0] = v7; v9[1] = v8
    del v7; del v8
    v10 = US3_1()
    v11 = US3_0()
    v12 = US3_2()
    v13 = numpy.empty(3,dtype=object)
    v13[0] = v10; v13[1] = v11; v13[2] = v12
    del v10; del v11; del v12
    v14 = US3_1()
    v15 = US3_0()
    v16 = numpy.empty(2,dtype=object)
    v16[0] = v14; v16[1] = v15
    del v14; del v15
    v17 = US3_0()
    v18 = numpy.empty(1,dtype=object)
    v18[0] = v17
    del v17
    v19 = Heap0(v18, v13, v9, v16)
    del v9; del v13; del v16; del v18
    v20 = US0_1()
    v21 = US0_2()
    v22 = US0_0()
    v23 = US0_1()
    v24 = US0_2()
    v25 = US0_0()
    v26 = numpy.empty(6,dtype=object)
    v26[0] = v20; v26[1] = v21; v26[2] = v22; v26[3] = v23; v26[4] = v24; v26[5] = v25
    del v20; del v21; del v22; del v23; del v24; del v25
    v27 = 0
    v28 = 0.000000
    return method25(v26, v0, v1, v2, v19, v3, v4, v5, v6, v27, v28)
cdef object method50(v0, v1, US1 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7):
    cdef bint v8
    cdef signed long v10
    cdef signed long v12
    cdef signed long v13
    cdef bint v14
    cdef signed long v16
    cdef signed long v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef double v24
    v8 = v7 == 0
    if v8:
        v10 = v5
    else:
        v10 =  -v5
    if v8:
        v12 = v10
    else:
        v12 =  -v10
    v13 = v12 + v5
    v14 = v4 == 0
    if v14:
        v16 = v10
    else:
        v16 =  -v10
    v17 = v16 + v5
    if v8:
        v18, v19, v20, v21, v22, v23 = v6, v7, v13, v3, v4, v17
    else:
        v18, v19, v20, v21, v22, v23 = v3, v4, v17, v6, v7, v13
    v24 = <double>v10
    return Closure26(v0, v1, v21, v22, v23, v18, v19, v20, v2, v24)
cdef object method51(v0, v1, US1 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7):
    cdef bint v8
    cdef signed long v10
    cdef bint v11
    cdef signed long v13
    cdef signed long v14
    cdef signed long v16
    cdef signed long v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef double v24
    v8 = v4 == 0
    if v8:
        v10 = v5
    else:
        v10 =  -v5
    v11 = v7 == 0
    if v11:
        v13 = v10
    else:
        v13 =  -v10
    v14 = v13 + v5
    if v8:
        v16 = v10
    else:
        v16 =  -v10
    v17 = v16 + v5
    if v11:
        v18, v19, v20, v21, v22, v23 = v6, v7, v14, v3, v4, v17
    else:
        v18, v19, v20, v21, v22, v23 = v3, v4, v17, v6, v7, v14
    v24 = <double>v10
    return Closure26(v0, v1, v21, v22, v23, v18, v19, v20, v2, v24)
cdef object method52(v0, v1, US1 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8):
    cdef bint v9
    cdef signed long v11
    cdef signed long v13
    cdef signed long v14
    cdef bint v15
    cdef signed long v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US0 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef double v25
    v9 = v7 == 0
    if v9:
        v11 = v8
    else:
        v11 =  -v8
    if v9:
        v13 = v11
    else:
        v13 =  -v11
    v14 = v13 + v5
    v15 = v4 == 0
    if v15:
        v17 = v11
    else:
        v17 =  -v11
    v18 = v17 + v5
    if v9:
        v19, v20, v21, v22, v23, v24 = v6, v7, v14, v3, v4, v18
    else:
        v19, v20, v21, v22, v23, v24 = v3, v4, v18, v6, v7, v14
    v25 = <double>v11
    return Closure26(v0, v1, v22, v23, v24, v19, v20, v21, v2, v25)
cdef object method53(v0, v1, US1 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8):
    cdef bint v9
    cdef signed long v11
    cdef bint v12
    cdef signed long v14
    cdef signed long v15
    cdef signed long v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    cdef US0 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef double v25
    v9 = v4 == 0
    if v9:
        v11 = v8
    else:
        v11 =  -v8
    v12 = v7 == 0
    if v12:
        v14 = v11
    else:
        v14 =  -v11
    v15 = v14 + v8
    if v9:
        v17 = v11
    else:
        v17 =  -v11
    v18 = v17 + v5
    if v12:
        v19, v20, v21, v22, v23, v24 = v6, v7, v15, v3, v4, v18
    else:
        v19, v20, v21, v22, v23, v24 = v3, v4, v18, v6, v7, v15
    v25 = <double>v11
    return Closure26(v0, v1, v22, v23, v24, v19, v20, v21, v2, v25)
cdef object method49(v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method35(v2, v5, v6, v7, v8, v9, v10, v3)
    return Closure24(v0, v1, v8, v9, v10, v5, v6, v7, v4, v11, v2, v3)
cdef double method48(numpy.ndarray[object,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, double v10, UH0 v11, double v12, UH0 v13, double v14, unsigned long long v15, double v16):
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef bint v20
    cdef US0 v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef double v25
    cdef numpy.ndarray[object,ndim=1] v26
    cdef bint v27
    cdef double v38
    cdef US1 v28
    cdef object v29
    cdef US2 v30
    cdef UH0 v31
    cdef US1 v33
    cdef object v34
    cdef US2 v35
    cdef UH0 v36
    cdef unsigned long long v39
    cdef double v40
    cdef double v42
    v17 = len(v0)
    v18 = <double>v17
    v19 = 1.000000 / v18
    v20 = v15 < v17
    if v20:
        v21 = v0[v15]
        v22 = <double>v17
        v23 = 1.000000 / v22
        v24 = libc.math.log(v23)
        v25 = v24 + v10
        v26 = v3.v2
        v27 = v8 == 0
        if v27:
            v28 = US1_1(v21)
            v29 = Closure23(v1, v2, v3, v4, v5, v6, v7, v8, v9, v21, v13, v14, v11, v12, v25)
            v30 = US2_1(v21)
            v31 = UH0_0(v30, v11)
            del v30
            v38 = v1(Tuple0(v26, v25, v7, v8, v9, v4, v5, v6, v28, 0, v29, v31, v12, v14))
            del v28; del v29; del v31
        else:
            v33 = US1_1(v21)
            v34 = Closure28(v1, v2, v3, v4, v5, v6, v7, v8, v9, v21, v13, v14, v11, v12, v25)
            v35 = US2_1(v21)
            v36 = UH0_0(v35, v13)
            del v35
            v38 = v1(Tuple0(v26, v25, v7, v8, v9, v4, v5, v6, v33, 1, v34, v36, v14, v12))
            del v33; del v34; del v36
        del v21; del v26
        v39 = v15 + 1
        v40 = v16 + v38
        return method48(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v39, v40)
    else:
        v42 = v16 * v19
        return v42
cdef object method47(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9):
    return Closure22(v3, v0, v1, v2, v4, v5, v6, v7, v8, v9)
cdef object method54(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10):
    cdef numpy.ndarray[object,ndim=1] v11
    v11 = method35(v2, v5, v6, v7, v8, v9, v10, v4)
    return Closure29(v0, v1, v8, v9, v10, v5, v6, v7, v11, v2, v3, v4)
cdef object method46(v0, v1, Heap0 v2, numpy.ndarray[object,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9):
    cdef numpy.ndarray[object,ndim=1] v10
    v10 = method31(v2, v5, v6, v7, v8, v9, v4)
    return Closure20(v0, v1, v8, v9, v7, v5, v6, v10, v2, v3, v4)
cdef double method45(numpy.ndarray[object,ndim=1] v0, v1, v2, Heap0 v3, US0 v4, double v5, UH0 v6, double v7, UH0 v8, double v9, unsigned long long v10, double v11):
    cdef unsigned long long v12
    cdef double v13
    cdef double v14
    cdef bint v15
    cdef US0 v16
    cdef unsigned long long v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef unsigned long long v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef unsigned char v24
    cdef UH0 v25
    cdef double v26
    cdef Tuple5 tmp15
    cdef unsigned char v27
    cdef UH0 v28
    cdef double v29
    cdef Tuple5 tmp16
    cdef numpy.ndarray[object,ndim=1] v30
    cdef US1 v31
    cdef object v32
    cdef double v33
    cdef unsigned long long v34
    cdef double v35
    cdef double v37
    v12 = len(v0)
    v13 = <double>v12
    v14 = 1.000000 / v13
    v15 = v10 < v12
    if v15:
        v16 = v0[v10]
        v17 = v12 - 1
        v18 = numpy.empty(v17,dtype=object)
        v19 = 0
        method26(v17, v10, v0, v18, v19)
        v20 = <double>v12
        v21 = 1.000000 / v20
        v22 = libc.math.log(v21)
        v23 = v22 + v5
        v24 = 0
        tmp15 = method29(v16, v24, v6, v7)
        v25, v26 = tmp15.v0, tmp15.v1
        del tmp15
        v27 = 1
        tmp16 = method29(v16, v27, v8, v9)
        v28, v29 = tmp16.v0, tmp16.v1
        del tmp16
        v30 = v3.v2
        v31 = US1_0()
        v32 = Closure19(v1, v2, v4, v16, v3, v18, v28, v29, v25, v26, v23)
        del v18; del v28
        v33 = v1(Tuple0(v30, v23, v4, 0, 1, v16, 1, 1, v31, 0, v32, v25, v26, v29))
        del v16; del v25; del v30; del v31; del v32
        v34 = v10 + 1
        v35 = v11 + v33
        return method45(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v34, v35)
    else:
        v37 = v11 * v14
        return v37
cdef double method44(numpy.ndarray[object,ndim=1] v0, v1, v2, Heap0 v3, UH0 v4, double v5, UH0 v6, double v7, unsigned long long v8, double v9):
    cdef unsigned long long v10
    cdef double v11
    cdef double v12
    cdef bint v13
    cdef US0 v14
    cdef unsigned long long v15
    cdef numpy.ndarray[object,ndim=1] v16
    cdef unsigned long long v17
    cdef double v18
    cdef double v19
    cdef double v20
    cdef unsigned char v21
    cdef UH0 v22
    cdef double v23
    cdef Tuple5 tmp13
    cdef unsigned char v24
    cdef UH0 v25
    cdef double v26
    cdef Tuple5 tmp14
    cdef unsigned long long v27
    cdef double v28
    cdef double v29
    cdef unsigned long long v30
    cdef double v31
    cdef double v33
    v10 = len(v0)
    v11 = <double>v10
    v12 = 1.000000 / v11
    v13 = v8 < v10
    if v13:
        v14 = v0[v8]
        v15 = v10 - 1
        v16 = numpy.empty(v15,dtype=object)
        v17 = 0
        method26(v15, v8, v0, v16, v17)
        v18 = <double>v10
        v19 = 1.000000 / v18
        v20 = libc.math.log(v19)
        v21 = 0
        tmp13 = method27(v14, v21, v4, v5)
        v22, v23 = tmp13.v0, tmp13.v1
        del tmp13
        v24 = 1
        tmp14 = method27(v14, v24, v6, v7)
        v25, v26 = tmp14.v0, tmp14.v1
        del tmp14
        v27 = 0
        v28 = 0.000000
        v29 = method45(v16, v1, v2, v3, v14, v20, v22, v23, v25, v26, v27, v28)
        del v14; del v16; del v22; del v25
        v30 = v8 + 1
        v31 = v9 + v29
        return method44(v0, v1, v2, v3, v4, v5, v6, v7, v30, v31)
    else:
        v33 = v9 * v12
        return v33
cdef double method43(v0, v1):
    cdef UH0 v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef US3 v6
    cdef US3 v7
    cdef numpy.ndarray[object,ndim=1] v8
    cdef US3 v9
    cdef US3 v10
    cdef US3 v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef US3 v13
    cdef US3 v14
    cdef numpy.ndarray[object,ndim=1] v15
    cdef US3 v16
    cdef numpy.ndarray[object,ndim=1] v17
    cdef Heap0 v18
    cdef US0 v19
    cdef US0 v20
    cdef US0 v21
    cdef US0 v22
    cdef US0 v23
    cdef US0 v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef unsigned long long v26
    cdef double v27
    v2 = UH0_1()
    v3 = 0.000000
    v4 = UH0_1()
    v5 = 0.000000
    v6 = US3_0()
    v7 = US3_2()
    v8 = numpy.empty(2,dtype=object)
    v8[0] = v6; v8[1] = v7
    del v6; del v7
    v9 = US3_1()
    v10 = US3_0()
    v11 = US3_2()
    v12 = numpy.empty(3,dtype=object)
    v12[0] = v9; v12[1] = v10; v12[2] = v11
    del v9; del v10; del v11
    v13 = US3_1()
    v14 = US3_0()
    v15 = numpy.empty(2,dtype=object)
    v15[0] = v13; v15[1] = v14
    del v13; del v14
    v16 = US3_0()
    v17 = numpy.empty(1,dtype=object)
    v17[0] = v16
    del v16
    v18 = Heap0(v17, v12, v8, v15)
    del v8; del v12; del v15; del v17
    v19 = US0_1()
    v20 = US0_2()
    v21 = US0_0()
    v22 = US0_1()
    v23 = US0_2()
    v24 = US0_0()
    v25 = numpy.empty(6,dtype=object)
    v25[0] = v19; v25[1] = v20; v25[2] = v21; v25[3] = v22; v25[4] = v23; v25[5] = v24
    del v19; del v20; del v21; del v22; del v23; del v24
    v26 = 0
    v27 = 0.000000
    return method44(v25, v0, v1, v18, v2, v3, v4, v5, v26, v27)
cdef unsigned long long method58(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef Tuple2 tmp21
    cdef unsigned long long v12
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1
        tmp21 = v2[v3]
        v7, v8, v9, v10, v11 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3, tmp21.v4
        del tmp21
        v12 = v4 - 1
        v1[v12] = Tuple8(v8, v9, v10, v11)
        del v8; del v9; del v10; del v11
        return method58(v0, v1, v2, v6, v12)
    else:
        return v4
cdef unsigned long long method57(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + 1
        v7 = v2[v3]
        v8 = len(v7)
        v9 = 0
        v10 = method58(v8, v1, v7, v9, v4)
        del v7
        return method57(v0, v1, v2, v6, v10)
    else:
        return v4
cdef unsigned long long method56(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, Mut0 v2):
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v4 = v2.v1
    v5 = len(v4)
    v6 = 0
    return method57(v5, v0, v4, v6, v1)
cdef numpy.ndarray[object,ndim=1] method55(Mut0 v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    v1 = v0.v2
    v2 = numpy.empty(v1,dtype=object)
    v3 = method56(v2, v1, v0)
    return v2
cdef void method60(list v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef str v8
    cdef US3 v4
    cdef US0 v6
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1
        method60(v0, v3)
        del v3
        if v2.tag == 0: # action_
            v4 = (<US2_0>v2).v0
            if v4.tag == 0: # call
                v8 = "C"
            elif v4.tag == 1: # fold
                v8 = "F"
            elif v4.tag == 2: # raise
                v8 = "R"
            del v4
        elif v2.tag == 1: # observation_
            v6 = (<US2_1>v2).v0
            if v6.tag == 0: # jack
                v8 = "[color=ff0000]J[/color]"
            elif v6.tag == 1: # king
                v8 = "[color=ff0000]K[/color]"
            elif v6.tag == 2: # queen
                v8 = "[color=ff0000]Q[/color]"
            del v6
        del v2
        v0.append(v8)
    elif v1.tag == 1: # nil
        pass
cdef void method61(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef str v9
    cdef str v10
    cdef str v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = v2[v4]
        if v7.tag == 0: # call
            v9 = "C"
        elif v7.tag == 1: # fold
            v9 = "F"
        elif v7.tag == 2: # raise
            v9 = "R"
        del v7
        v10 = '{:.5f}'.format(v8)
        v11 = f'{v9}: {v10}'
        del v9; del v10
        v3[v4] = v11
        del v11
        method61(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method62(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef str v9
    cdef str v10
    cdef str v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v1[v4]
        v8 = v2[v4]
        if v7.tag == 0: # call
            v9 = "C"
        elif v7.tag == 1: # fold
            v9 = "F"
        elif v7.tag == 2: # raise
            v9 = "R"
        del v7
        v10 = '{:.5f}'.format(v8)
        v11 = f'{v9}: {v10}'
        del v9; del v10
        v3[v4] = v11
        del v11
        method62(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method59(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef UH0 v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef numpy.ndarray[double,ndim=1] v8
    cdef numpy.ndarray[double,ndim=1] v9
    cdef Tuple8 tmp22
    cdef list v10
    cdef str v11
    cdef unsigned long long v12
    cdef unsigned long long v13
    cdef bint v14
    cdef bint v15
    cdef list v16
    cdef unsigned long long v17
    cdef str v18
    cdef unsigned long long v19
    cdef bint v20
    cdef bint v21
    cdef list v22
    cdef unsigned long long v23
    cdef str v24
    cdef object v25
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        tmp22 = v1[v3]
        v6, v7, v8, v9 = tmp22.v0, tmp22.v1, tmp22.v2, tmp22.v3
        del tmp22
        v10 = [None]*0
        method60(v10, v6)
        del v6
        v11 = "".join(v10)
        del v10
        v12 = len(v7)
        v13 = len(v8)
        v14 = v12 == v13
        v15 = v14 != 1
        if v15:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v16 = [None]*v12
        v17 = 0
        method61(v12, v7, v8, v16, v17)
        del v8
        v18 = "\n".join(v16)
        del v16
        v19 = len(v9)
        v20 = v12 == v19
        v21 = v20 != 1
        if v21:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v22 = [None]*v12
        v23 = 0
        method62(v12, v7, v9, v22, v23)
        del v7; del v9
        v24 = "\n".join(v22)
        del v22
        v25 = {'avg_policy': v18, 'regret': v24, 'trace': v11}
        del v11; del v18; del v24
        v2[v3] = v25
        del v25
        method59(v0, v1, v2, v5)
    else:
        pass
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    v0 = 3
    v1 = 7
    v2 = method0(v0, v1)
    v3 = Closure0(v2)
    v4 = Closure1(v2)
    v5 = Closure2(v2)
    pass # import ui_train
    v6 = Closure3(v5, v4, v3)
    del v3; del v4; del v5
    v7 = Closure33(v2)
    del v2
    ui_train.run(v6,v7)
