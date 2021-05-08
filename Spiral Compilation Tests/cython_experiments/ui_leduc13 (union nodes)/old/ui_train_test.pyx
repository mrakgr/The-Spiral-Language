import numpy
cimport numpy
import ui_train
cimport libc.math
import ui_leduc
cdef class Mut0:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Mut1:
    cdef public unsigned long long v0
    cdef public object v1
    cdef public unsigned long long v2
    def __init__(self, unsigned long long v0, v1, unsigned long long v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
ctypedef signed long US0
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly US0 v0
    def __init__(self, US0 v0): self.tag = 1; self.v0 = v0
ctypedef signed long US3
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
    cdef readonly double v2
    cdef readonly US0 v3
    cdef readonly unsigned char v4
    cdef readonly signed long v5
    cdef readonly US0 v6
    cdef readonly unsigned char v7
    cdef readonly signed long v8
    cdef readonly US1 v9
    cdef readonly unsigned char v10
    cdef readonly object v11
    cdef readonly UH0 v12
    cdef readonly double v13
    cdef readonly double v14
    cdef readonly double v15
    cdef readonly double v16
    def __init__(self, v0, double v1, double v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US1 v9, unsigned char v10, v11, UH0 v12, double v13, double v14, double v15, double v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
cdef class Tuple1:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple2:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly object v2
    cdef readonly object v3
    cdef readonly object v4
    cdef readonly object v5
    def __init__(self, unsigned long long v0, UH0 v1, v2, v3, v4, v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
cdef class Tuple3:
    cdef readonly double v0
    cdef readonly double v1
    def __init__(self, double v0, double v1): self.v0 = v0; self.v1 = v1
cdef class Tuple4:
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly US3 v2
    def __init__(self, double v0, double v1, US3 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure1():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef double v3 = args.v2
        cdef US0 v4 = args.v3
        cdef unsigned char v5 = args.v4
        cdef signed long v6 = args.v5
        cdef US0 v7 = args.v6
        cdef unsigned char v8 = args.v7
        cdef signed long v9 = args.v8
        cdef US1 v10 = args.v9
        cdef unsigned char v11 = args.v10
        cdef object v12 = args.v11
        cdef UH0 v13 = args.v12
        cdef double v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        return method5(v0, v12, v1, v11, v16, v17, v13, v14, v15, v2, v3)
cdef class Tuple5:
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly US0 v2
    cdef readonly unsigned char v3
    cdef readonly signed long v4
    cdef readonly US0 v5
    cdef readonly unsigned char v6
    cdef readonly signed long v7
    cdef readonly US1 v8
    cdef readonly unsigned char v9
    cdef readonly UH0 v10
    cdef readonly double v11
    cdef readonly double v12
    cdef readonly double v13
    def __init__(self, double v0, double v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US1 v8, unsigned char v9, UH0 v10, double v11, double v12, double v13): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, Tuple5 args):
        cdef double v0 = args.v0
        cdef double v1 = args.v1
        cdef US0 v2 = args.v2
        cdef unsigned char v3 = args.v3
        cdef signed long v4 = args.v4
        cdef US0 v5 = args.v5
        cdef unsigned char v6 = args.v6
        cdef signed long v7 = args.v7
        cdef US1 v8 = args.v8
        cdef unsigned char v9 = args.v9
        cdef UH0 v10 = args.v10
        cdef double v11 = args.v11
        cdef double v12 = args.v12
        cdef double v13 = args.v13
        pass
cdef class US4:
    cdef readonly signed long tag
cdef class US4_0(US4): # none
    def __init__(self): self.tag = 0
cdef class US4_1(US4): # some_
    cdef readonly unsigned char v0
    def __init__(self, unsigned char v0): self.tag = 1; self.v0 = v0
cdef class Closure5():
    cdef object v0
    cdef US4 v1
    def __init__(self, v0, US4 v1): self.v0 = v0; self.v1 = v1
    def __call__(self, numpy.ndarray[signed long,ndim=1] v2):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        cdef object v3
        cdef unsigned long long v4
        cdef unsigned long long v5
        cdef object v6
        cdef object v7
        v3 = v0(1)
        v4 = len(v2)
        v5 = numpy.random.randint(0,v4)
        v6 = v3(v5)
        del v3
        v7 = v6(v1)
        del v6
        return v7(v2)
cdef class Closure4():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, US4 v1):
        cdef object v0 = self.v0
        return Closure5(v0, v1)
cdef class Closure3():
    def __init__(self): pass
    def __call__(self, object v0):
        return Closure4(v0)
cdef class Tuple6:
    cdef readonly double v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    cdef readonly double v4
    cdef readonly UH0 v5
    cdef readonly double v6
    cdef readonly double v7
    def __init__(self, double v0, double v1, UH0 v2, double v3, double v4, UH0 v5, double v6, double v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
cdef class Closure10():
    cdef object v0
    cdef US4 v1
    cdef object v2
    cdef object v3
    def __init__(self, v0, US4 v1, numpy.ndarray[signed long,ndim=1] v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        cdef object v3 = self.v3
        cdef double v4 = args.v0
        cdef double v5 = args.v1
        cdef UH0 v6 = args.v2
        cdef double v7 = args.v3
        cdef double v8 = args.v4
        cdef UH0 v9 = args.v5
        cdef double v10 = args.v6
        cdef double v11 = args.v7
        cdef unsigned long long v12
        cdef double v13
        v12 = (<unsigned long long>0)
        v13 = (<double>0.000000)
        return method25(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13)
cdef class Closure9():
    cdef object v0
    cdef US4 v1
    cdef object v2
    def __init__(self, v0, US4 v1, numpy.ndarray[signed long,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        return Closure10(v0, v1, v2, v3)
cdef class Closure8():
    cdef object v0
    cdef US4 v1
    def __init__(self, v0, US4 v1): self.v0 = v0; self.v1 = v1
    def __call__(self, numpy.ndarray[signed long,ndim=1] v2):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        return Closure9(v0, v1, v2)
cdef class Closure7():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, US4 v1):
        cdef object v0 = self.v0
        return Closure8(v0, v1)
cdef class Closure6():
    def __init__(self): pass
    def __call__(self, object v0):
        return Closure7(v0)
cdef class Closure17():
    def __init__(self): pass
    def __call__(self, double v0):
        cdef double v1
        v1 = libc.math.log(v0)
        return Tuple3(v1, v1)
cdef class Closure18():
    def __init__(self): pass
    def __call__(self, double v0):
        cdef double v1
        v1 = libc.math.log(v0)
        return Tuple3(v1, (<double>0.000000))
cdef class Tuple7:
    cdef readonly US0 v0
    cdef readonly object v1
    def __init__(self, US0 v0, v1): self.v0 = v0; self.v1 = v1
cdef class Closure16():
    cdef bint v0
    cdef unsigned long long v1
    cdef US4 v2
    cdef object v3
    cdef object v4
    def __init__(self, bint v0, unsigned long long v1, US4 v2, numpy.ndarray[signed long,ndim=1] v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, Tuple6 args):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef US4 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        cdef object v4 = self.v4
        cdef double v5 = args.v0
        cdef double v6 = args.v1
        cdef UH0 v7 = args.v2
        cdef double v8 = args.v3
        cdef double v9 = args.v4
        cdef UH0 v10 = args.v5
        cdef double v11 = args.v6
        cdef double v12 = args.v7
        cdef US0 v13
        cdef unsigned long long v14
        cdef unsigned long long v15
        cdef numpy.ndarray[signed long,ndim=1] v16
        cdef unsigned long long v17
        cdef object v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef double v24
        cdef Tuple3 tmp5
        cdef double v25
        cdef double v26
        cdef UH0 v44
        cdef double v45
        cdef double v46
        cdef UH0 v47
        cdef double v48
        cdef double v49
        cdef US2 v27
        cdef UH0 v28
        cdef US2 v29
        cdef UH0 v30
        cdef unsigned char v31
        cdef bint v32
        cdef UH0 v35
        cdef double v36
        cdef double v37
        cdef US2 v33
        cdef UH0 v34
        cdef bint v38
        cdef UH0 v41
        cdef double v42
        cdef double v43
        cdef US2 v39
        cdef UH0 v40
        v13 = v3[v1]
        v14 = len(v3)
        v15 = v14 - (<unsigned long long>1)
        v16 = numpy.empty(v15,dtype=numpy.int32)
        v17 = (<unsigned long long>0)
        method26(v15, v1, v3, v16, v17)
        if v0:
            v20 = Closure17()
        else:
            v20 = Closure18()
        v21 = <double>v14
        v22 = (<double>1.000000) / v21
        tmp5 = v20(v22)
        v23, v24 = tmp5.v0, tmp5.v1
        del tmp5
        del v20
        v25 = v24 + v6
        v26 = v23 + v5
        if v2.tag == 0: # none
            v27 = US2_1(v13)
            v28 = UH0_0(v27, v7)
            del v27
            v29 = US2_1(v13)
            v30 = UH0_0(v29, v10)
            del v29
            v44, v45, v46, v47, v48, v49 = v28, v8, v9, v30, v11, v12
            del v28; del v30
        elif v2.tag == 1: # some_
            v31 = (<US4_1>v2).v0
            v32 = v31 == (<unsigned char>0)
            if v32:
                v33 = US2_1(v13)
                v34 = UH0_0(v33, v7)
                del v33
                v35, v36, v37 = v34, v8, v9
                del v34
            else:
                v35, v36, v37 = v7, v8, v9
            v38 = v31 == (<unsigned char>1)
            if v38:
                v39 = US2_1(v13)
                v40 = UH0_0(v39, v10)
                del v39
                v41, v42, v43 = v40, v11, v12
                del v40
            else:
                v41, v42, v43 = v10, v11, v12
            v44, v45, v46, v47, v48, v49 = v35, v36, v37, v41, v42, v43
            del v35; del v41
        return method27(v4, v13, v16, v26, v25, v44, v45, v46, v47, v48, v49)
cdef class Closure15():
    cdef bint v0
    cdef unsigned long long v1
    cdef US4 v2
    cdef object v3
    def __init__(self, bint v0, unsigned long long v1, US4 v2, numpy.ndarray[signed long,ndim=1] v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, object v4):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef US4 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        return Closure16(v0, v1, v2, v3, v4)
cdef class Closure14():
    cdef bint v0
    cdef unsigned long long v1
    cdef US4 v2
    def __init__(self, bint v0, unsigned long long v1, US4 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, numpy.ndarray[signed long,ndim=1] v3):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef US4 v2 = self.v2
        return Closure15(v0, v1, v2, v3)
cdef class Closure13():
    cdef bint v0
    cdef unsigned long long v1
    def __init__(self, bint v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
    def __call__(self, US4 v2):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        return Closure14(v0, v1, v2)
cdef class Closure12():
    cdef bint v0
    def __init__(self, bint v0): self.v0 = v0
    def __call__(self, unsigned long long v1):
        cdef bint v0 = self.v0
        return Closure13(v0, v1)
cdef class Closure11():
    def __init__(self): pass
    def __call__(self, bint v0):
        return Closure12(v0)
cdef class Closure21():
    cdef object v0
    cdef US4 v1
    def __init__(self, v0, US4 v1): self.v0 = v0; self.v1 = v1
    def __call__(self, numpy.ndarray[signed long,ndim=1] v2):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        cdef object v3
        cdef unsigned long long v4
        cdef unsigned long long v5
        cdef object v6
        cdef object v7
        v3 = v0(1)
        v4 = len(v2)
        v5 = numpy.random.randint(0,v4)
        v6 = v3(v5)
        del v3
        v7 = v6(v1)
        del v6
        return v7(v2)
cdef class Closure20():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, US4 v1):
        cdef object v0 = self.v0
        return Closure21(v0, v1)
cdef class Closure19():
    def __init__(self): pass
    def __call__(self, object v0):
        return Closure20(v0)
cdef class Closure26():
    cdef object v0
    cdef US4 v1
    cdef object v2
    cdef object v3
    def __init__(self, v0, US4 v1, numpy.ndarray[signed long,ndim=1] v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        cdef object v3 = self.v3
        cdef double v4 = args.v0
        cdef double v5 = args.v1
        cdef UH0 v6 = args.v2
        cdef double v7 = args.v3
        cdef double v8 = args.v4
        cdef UH0 v9 = args.v5
        cdef double v10 = args.v6
        cdef double v11 = args.v7
        cdef unsigned long long v12
        cdef double v13
        v12 = (<unsigned long long>0)
        v13 = (<double>0.000000)
        return method28(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13)
cdef class Closure25():
    cdef object v0
    cdef US4 v1
    cdef object v2
    def __init__(self, v0, US4 v1, numpy.ndarray[signed long,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        cdef numpy.ndarray[signed long,ndim=1] v2 = self.v2
        return Closure26(v0, v1, v2, v3)
cdef class Closure24():
    cdef object v0
    cdef US4 v1
    def __init__(self, v0, US4 v1): self.v0 = v0; self.v1 = v1
    def __call__(self, numpy.ndarray[signed long,ndim=1] v2):
        cdef object v0 = self.v0
        cdef US4 v1 = self.v1
        return Closure25(v0, v1, v2)
cdef class Closure23():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, US4 v1):
        cdef object v0 = self.v0
        return Closure24(v0, v1)
cdef class Closure22():
    def __init__(self): pass
    def __call__(self, object v0):
        return Closure23(v0)
cdef class Closure32():
    cdef bint v0
    cdef unsigned long long v1
    cdef US4 v2
    cdef object v3
    cdef object v4
    def __init__(self, bint v0, unsigned long long v1, US4 v2, numpy.ndarray[signed long,ndim=1] v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, Tuple6 args):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef US4 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        cdef object v4 = self.v4
        cdef double v5 = args.v0
        cdef double v6 = args.v1
        cdef UH0 v7 = args.v2
        cdef double v8 = args.v3
        cdef double v9 = args.v4
        cdef UH0 v10 = args.v5
        cdef double v11 = args.v6
        cdef double v12 = args.v7
        cdef US0 v13
        cdef object v16
        cdef unsigned long long v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef Tuple3 tmp6
        cdef double v22
        cdef double v23
        cdef UH0 v41
        cdef double v42
        cdef double v43
        cdef UH0 v44
        cdef double v45
        cdef double v46
        cdef US2 v24
        cdef UH0 v25
        cdef US2 v26
        cdef UH0 v27
        cdef unsigned char v28
        cdef bint v29
        cdef UH0 v32
        cdef double v33
        cdef double v34
        cdef US2 v30
        cdef UH0 v31
        cdef bint v35
        cdef UH0 v38
        cdef double v39
        cdef double v40
        cdef US2 v36
        cdef UH0 v37
        v13 = v3[v1]
        if v0:
            v16 = Closure17()
        else:
            v16 = Closure18()
        v17 = len(v3)
        v18 = <double>v17
        v19 = (<double>1.000000) / v18
        tmp6 = v16(v19)
        v20, v21 = tmp6.v0, tmp6.v1
        del tmp6
        del v16
        v22 = v21 + v6
        v23 = v20 + v5
        if v2.tag == 0: # none
            v24 = US2_1(v13)
            v25 = UH0_0(v24, v7)
            del v24
            v26 = US2_1(v13)
            v27 = UH0_0(v26, v10)
            del v26
            v41, v42, v43, v44, v45, v46 = v25, v8, v9, v27, v11, v12
            del v25; del v27
        elif v2.tag == 1: # some_
            v28 = (<US4_1>v2).v0
            v29 = v28 == (<unsigned char>0)
            if v29:
                v30 = US2_1(v13)
                v31 = UH0_0(v30, v7)
                del v30
                v32, v33, v34 = v31, v8, v9
                del v31
            else:
                v32, v33, v34 = v7, v8, v9
            v35 = v28 == (<unsigned char>1)
            if v35:
                v36 = US2_1(v13)
                v37 = UH0_0(v36, v10)
                del v36
                v38, v39, v40 = v37, v11, v12
                del v37
            else:
                v38, v39, v40 = v10, v11, v12
            v41, v42, v43, v44, v45, v46 = v32, v33, v34, v38, v39, v40
            del v32; del v38
        return method29(v4, v13, v23, v22, v41, v42, v43, v44, v45, v46)
cdef class Closure31():
    cdef bint v0
    cdef unsigned long long v1
    cdef US4 v2
    cdef object v3
    def __init__(self, bint v0, unsigned long long v1, US4 v2, numpy.ndarray[signed long,ndim=1] v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, object v4):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef US4 v2 = self.v2
        cdef numpy.ndarray[signed long,ndim=1] v3 = self.v3
        return Closure32(v0, v1, v2, v3, v4)
cdef class Closure30():
    cdef bint v0
    cdef unsigned long long v1
    cdef US4 v2
    def __init__(self, bint v0, unsigned long long v1, US4 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, numpy.ndarray[signed long,ndim=1] v3):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        cdef US4 v2 = self.v2
        return Closure31(v0, v1, v2, v3)
cdef class Closure29():
    cdef bint v0
    cdef unsigned long long v1
    def __init__(self, bint v0, unsigned long long v1): self.v0 = v0; self.v1 = v1
    def __call__(self, US4 v2):
        cdef bint v0 = self.v0
        cdef unsigned long long v1 = self.v1
        return Closure30(v0, v1, v2)
cdef class Closure28():
    cdef bint v0
    def __init__(self, bint v0): self.v0 = v0
    def __call__(self, unsigned long long v1):
        cdef bint v0 = self.v0
        return Closure29(v0, v1)
cdef class Closure27():
    def __init__(self): pass
    def __call__(self, bint v0):
        return Closure28(v0)
cdef class Heap0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    def __init__(self, v0, v1, v2, v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Closure42():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef signed long v11
    cdef US0 v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, signed long v11, US0 v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17, signed long v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef double v19 = args.v0
        cdef double v20 = args.v1
        cdef US3 v21 = args.v2
        cdef double v22
        cdef double v23
        cdef US2 v24
        cdef UH0 v25
        cdef US2 v26
        cdef UH0 v27
        v22 = v20 + v2
        v23 = v19 + v1
        v24 = US2_0(v21)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v21)
        v27 = UH0_0(v26, v0)
        del v26
        return method35(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v21, v6, v7, v25, v4, v5, v27, v23, v22)
cdef class Closure41():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef signed long v11
    cdef US0 v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, signed long v11, US0 v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17, signed long v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef double v19 = args.v0
        cdef double v20 = args.v1
        cdef US3 v21 = args.v2
        cdef double v22
        cdef double v23
        cdef US2 v24
        cdef UH0 v25
        cdef US2 v26
        cdef UH0 v27
        v22 = v20 + v5
        v23 = v19 + v4
        v24 = US2_0(v21)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v21)
        v27 = UH0_0(v26, v0)
        del v26
        return method35(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v21, v6, v7, v25, v23, v22, v27, v1, v2)
cdef class Closure40():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef double v18 = args.v0
        cdef double v19 = args.v1
        cdef US3 v20 = args.v2
        cdef double v21
        cdef double v22
        cdef US2 v23
        cdef UH0 v24
        cdef US2 v25
        cdef UH0 v26
        v21 = v19 + v5
        v22 = v18 + v4
        v23 = US2_0(v20)
        v24 = UH0_0(v23, v3)
        del v23
        v25 = US2_0(v20)
        v26 = UH0_0(v25, v0)
        del v25
        return method33(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v20, v6, v7, v24, v22, v21, v26, v1, v2)
cdef class Closure43():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef double v18 = args.v0
        cdef double v19 = args.v1
        cdef US3 v20 = args.v2
        cdef double v21
        cdef double v22
        cdef US2 v23
        cdef UH0 v24
        cdef US2 v25
        cdef UH0 v26
        v21 = v19 + v2
        v22 = v18 + v1
        v23 = US2_0(v20)
        v24 = UH0_0(v23, v3)
        del v23
        v25 = US2_0(v20)
        v26 = UH0_0(v25, v0)
        del v25
        return method33(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v20, v6, v7, v24, v4, v5, v26, v22, v21)
cdef class Closure39():
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
    def __init__(self, v0, v1, US0 v2, unsigned char v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, numpy.ndarray[signed long,ndim=1] v9, Heap0 v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
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
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef double v11 = args.v0
        cdef double v12 = args.v1
        cdef UH0 v13 = args.v2
        cdef double v14 = args.v3
        cdef double v15 = args.v4
        cdef UH0 v16 = args.v5
        cdef double v17 = args.v6
        cdef double v18 = args.v7
        cdef bint v19
        cdef US1 v20
        cdef object v21
        cdef US1 v23
        cdef object v24
        v19 = v3 == (<unsigned char>0)
        if v19:
            v20 = US1_1(v8)
            v21 = Closure40(v16, v17, v18, v13, v14, v15, v11, v12, v0, v1, v10, v5, v6, v7, v2, v3, v4, v8)
            return v0(Tuple0(v9, v11, v12, v2, v3, v4, v5, v6, v7, v20, (<unsigned char>0), v21, v13, v14, v15, v17, v18))
        else:
            v23 = US1_1(v8)
            v24 = Closure43(v16, v17, v18, v13, v14, v15, v11, v12, v0, v1, v10, v5, v6, v7, v2, v3, v4, v8)
            return v0(Tuple0(v9, v11, v12, v2, v3, v4, v5, v6, v7, v23, (<unsigned char>1), v24, v16, v17, v18, v14, v15))
cdef class Closure38():
    cdef object v0
    cdef object v1
    cdef Heap0 v2
    cdef US0 v3
    cdef unsigned char v4
    cdef signed long v5
    cdef US0 v6
    cdef unsigned char v7
    cdef signed long v8
    def __init__(self, v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8
    def __call__(self, US0 v9):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef Heap0 v2 = self.v2
        cdef US0 v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef signed long v5 = self.v5
        cdef US0 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef signed long v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v10
        v10 = v2.v2
        return Closure39(v0, v1, v6, v7, v8, v3, v4, v5, v9, v10, v2)
cdef class Closure45():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef object v11
    cdef object v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    cdef unsigned char v18
    cdef signed long v19
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, v11, numpy.ndarray[signed long,ndim=1] v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17, unsigned char v18, signed long v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef object v11 = self.v11
        cdef numpy.ndarray[signed long,ndim=1] v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef unsigned char v18 = self.v18
        cdef signed long v19 = self.v19
        cdef double v20 = args.v0
        cdef double v21 = args.v1
        cdef US3 v22 = args.v2
        cdef double v23
        cdef double v24
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        v23 = v21 + v2
        v24 = v20 + v1
        v25 = US2_0(v22)
        v26 = UH0_0(v25, v3)
        del v25
        v27 = US2_0(v22)
        v28 = UH0_0(v27, v0)
        del v27
        return method37(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v22, v6, v7, v26, v4, v5, v28, v24, v23)
cdef class Closure44():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef object v11
    cdef object v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    cdef unsigned char v18
    cdef signed long v19
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, v11, numpy.ndarray[signed long,ndim=1] v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17, unsigned char v18, signed long v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef object v11 = self.v11
        cdef numpy.ndarray[signed long,ndim=1] v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef unsigned char v18 = self.v18
        cdef signed long v19 = self.v19
        cdef double v20 = args.v0
        cdef double v21 = args.v1
        cdef US3 v22 = args.v2
        cdef double v23
        cdef double v24
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        v23 = v21 + v5
        v24 = v20 + v4
        v25 = US2_0(v22)
        v26 = UH0_0(v25, v3)
        del v25
        v27 = US2_0(v22)
        v28 = UH0_0(v27, v0)
        del v27
        return method37(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v22, v6, v7, v26, v24, v23, v28, v1, v2)
cdef class Closure37():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef object v11
    cdef object v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    cdef unsigned char v18
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, v11, numpy.ndarray[signed long,ndim=1] v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17, unsigned char v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef object v11 = self.v11
        cdef numpy.ndarray[signed long,ndim=1] v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef unsigned char v18 = self.v18
        cdef double v19 = args.v0
        cdef double v20 = args.v1
        cdef US3 v21 = args.v2
        cdef double v22
        cdef double v23
        cdef US2 v24
        cdef UH0 v25
        cdef US2 v26
        cdef UH0 v27
        v22 = v20 + v5
        v23 = v19 + v4
        v24 = US2_0(v21)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v21)
        v27 = UH0_0(v26, v0)
        del v26
        return method32(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v21, v6, v7, v25, v23, v22, v27, v1, v2)
cdef class Closure46():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef Heap0 v10
    cdef object v11
    cdef object v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    cdef unsigned char v18
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, Heap0 v10, v11, numpy.ndarray[signed long,ndim=1] v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17, unsigned char v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef object v11 = self.v11
        cdef numpy.ndarray[signed long,ndim=1] v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef unsigned char v18 = self.v18
        cdef double v19 = args.v0
        cdef double v20 = args.v1
        cdef US3 v21 = args.v2
        cdef double v22
        cdef double v23
        cdef US2 v24
        cdef UH0 v25
        cdef US2 v26
        cdef UH0 v27
        v22 = v20 + v2
        v23 = v19 + v1
        v24 = US2_0(v21)
        v25 = UH0_0(v24, v3)
        del v24
        v26 = US2_0(v21)
        v27 = UH0_0(v26, v0)
        del v26
        return method32(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v21, v6, v7, v25, v4, v5, v27, v23, v22)
cdef class Closure36():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef US0 v10
    cdef US0 v11
    cdef Heap0 v12
    cdef object v13
    cdef object v14
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, US0 v10, US0 v11, Heap0 v12, v13, numpy.ndarray[signed long,ndim=1] v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef US0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef object v13 = self.v13
        cdef numpy.ndarray[signed long,ndim=1] v14 = self.v14
        cdef double v15 = args.v0
        cdef double v16 = args.v1
        cdef US3 v17 = args.v2
        cdef double v18
        cdef double v19
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v18 = v16 + v5
        v19 = v15 + v4
        v20 = US2_0(v17)
        v21 = UH0_0(v20, v3)
        del v20
        v22 = US2_0(v17)
        v23 = UH0_0(v22, v0)
        del v22
        return method30(v8, v9, v10, v11, v12, v13, v14, v17, v6, v7, v21, v19, v18, v23, v1, v2)
cdef class Closure35():
    cdef object v0
    cdef object v1
    cdef US0 v2
    cdef US0 v3
    cdef object v4
    cdef Heap0 v5
    cdef object v6
    cdef object v7
    def __init__(self, v0, v1, US0 v2, US0 v3, numpy.ndarray[signed long,ndim=1] v4, Heap0 v5, v6, numpy.ndarray[signed long,ndim=1] v7): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef US0 v2 = self.v2
        cdef US0 v3 = self.v3
        cdef numpy.ndarray[signed long,ndim=1] v4 = self.v4
        cdef Heap0 v5 = self.v5
        cdef object v6 = self.v6
        cdef numpy.ndarray[signed long,ndim=1] v7 = self.v7
        cdef double v8 = args.v0
        cdef double v9 = args.v1
        cdef UH0 v10 = args.v2
        cdef double v11 = args.v3
        cdef double v12 = args.v4
        cdef UH0 v13 = args.v5
        cdef double v14 = args.v6
        cdef double v15 = args.v7
        cdef US1 v16
        cdef object v17
        v16 = US1_0()
        v17 = Closure36(v13, v14, v15, v10, v11, v12, v8, v9, v0, v1, v2, v3, v5, v6, v7)
        return v0(Tuple0(v4, v8, v9, v2, (<unsigned char>0), (<signed long>1), v3, (<unsigned char>1), (<signed long>1), v16, (<unsigned char>0), v17, v10, v11, v12, v14, v15))
cdef class Closure34():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef Heap0 v3
    cdef US0 v4
    def __init__(self, v0, v1, v2, Heap0 v3, US0 v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, Tuple7 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef Heap0 v3 = self.v3
        cdef US0 v4 = self.v4
        cdef US0 v5 = args.v0
        cdef numpy.ndarray[signed long,ndim=1] v6 = args.v1
        cdef numpy.ndarray[signed long,ndim=1] v7
        v7 = v3.v2
        return Closure35(v1, v2, v4, v5, v7, v3, v0, v6)
cdef class Closure33():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef Heap0 v4
    def __init__(self, v0, v1, v2, v3, Heap0 v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, Tuple7 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef Heap0 v4 = self.v4
        cdef US0 v5 = args.v0
        cdef numpy.ndarray[signed long,ndim=1] v6 = args.v1
        cdef US4 v7
        cdef object v8
        cdef object v9
        cdef object v10
        v7 = US4_1((<unsigned char>1))
        v8 = v3(v7)
        del v7
        v9 = v8(v6)
        del v8
        v10 = Closure34(v0, v1, v2, v4, v5)
        return v9(v10)
cdef class Mut2:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    cdef public unsigned long long v3
    def __init__(self, v0, v1, v2, unsigned long long v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
cdef class Tuple8:
    cdef readonly unsigned long long v0
    cdef readonly UH0 v1
    cdef readonly Mut2 v2
    def __init__(self, unsigned long long v0, UH0 v1, Mut2 v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure47():
    cdef Mut1 v0
    def __init__(self, Mut1 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut1 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef double v3 = args.v2
        cdef US0 v4 = args.v3
        cdef unsigned char v5 = args.v4
        cdef signed long v6 = args.v5
        cdef US0 v7 = args.v6
        cdef unsigned char v8 = args.v7
        cdef signed long v9 = args.v8
        cdef US1 v10 = args.v9
        cdef unsigned char v11 = args.v10
        cdef object v12 = args.v11
        cdef UH0 v13 = args.v12
        cdef double v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        cdef Mut2 v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef numpy.ndarray[double,ndim=1] v23
        cdef numpy.ndarray[double,ndim=1] v24
        cdef unsigned long long v25
        cdef unsigned long long v26
        cdef bint v27
        cdef bint v28
        cdef numpy.ndarray[double,ndim=1] v29
        cdef unsigned long long v30
        cdef double v31
        cdef double v32
        v18 = method38(v0, v1, v13)
        v19 = v3 + v17
        v20 = v2 + v16
        v21 = v20 - v19
        v22 = libc.math.exp(v21)
        v23 = v18.v2
        v24 = method45(v23)
        del v23
        v25 = len(v24)
        v26 = len(v1)
        v27 = v25 == v26
        v28 = v27 != 1
        if v28:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v29 = numpy.empty(v25,dtype=numpy.float64)
        v30 = (<unsigned long long>0)
        v31 = (<double>0.000000)
        v32 = method49(v25, v12, v22, v24, v1, v29, v30, v31)
        del v24
        return method50(v13, v14, v15, v18, v22, v32, v29, v11)
cdef class Closure48():
    def __init__(self): pass
    def __call__(self, Tuple5 args):
        cdef double v0 = args.v0
        cdef double v1 = args.v1
        cdef US0 v2 = args.v2
        cdef unsigned char v3 = args.v3
        cdef signed long v4 = args.v4
        cdef US0 v5 = args.v5
        cdef unsigned char v6 = args.v6
        cdef signed long v7 = args.v7
        cdef US1 v8 = args.v8
        cdef unsigned char v9 = args.v9
        cdef UH0 v10 = args.v10
        cdef double v11 = args.v11
        cdef double v12 = args.v12
        cdef double v13 = args.v13
        pass
cdef class Closure49():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef double v3 = args.v2
        cdef US0 v4 = args.v3
        cdef unsigned char v5 = args.v4
        cdef signed long v6 = args.v5
        cdef US0 v7 = args.v6
        cdef unsigned char v8 = args.v7
        cdef signed long v9 = args.v8
        cdef US1 v10 = args.v9
        cdef unsigned char v11 = args.v10
        cdef object v12 = args.v11
        cdef UH0 v13 = args.v12
        cdef double v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        cdef numpy.ndarray[signed long,ndim=1] v18
        cdef numpy.ndarray[double,ndim=1] v19
        cdef numpy.ndarray[object,ndim=1] v20
        cdef numpy.ndarray[double,ndim=1] v21
        cdef Tuple1 tmp9
        cdef numpy.ndarray[double,ndim=1] v22
        cdef unsigned long long v23
        cdef unsigned long long v24
        cdef bint v25
        cdef bint v26
        cdef unsigned long long v27
        cdef double v28
        tmp9 = method6(v0, v1, v13)
        v18, v19, v20, v21 = tmp9.v0, tmp9.v1, tmp9.v2, tmp9.v3
        del tmp9
        del v18; del v20; del v21
        v22 = method16(v19)
        del v19
        v23 = len(v22)
        v24 = len(v1)
        v25 = v23 == v24
        v26 = v25 == 0
        if v26:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v27 = (<unsigned long long>0)
        v28 = (<double>0.000000)
        return method53(v23, v12, v16, v17, v22, v1, v27, v28)
cdef class Closure50():
    cdef Mut1 v0
    def __init__(self, Mut1 v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef Mut1 v0 = self.v0
        cdef numpy.ndarray[signed long,ndim=1] v1 = args.v0
        cdef double v2 = args.v1
        cdef double v3 = args.v2
        cdef US0 v4 = args.v3
        cdef unsigned char v5 = args.v4
        cdef signed long v6 = args.v5
        cdef US0 v7 = args.v6
        cdef unsigned char v8 = args.v7
        cdef signed long v9 = args.v8
        cdef US1 v10 = args.v9
        cdef unsigned char v11 = args.v10
        cdef object v12 = args.v11
        cdef UH0 v13 = args.v12
        cdef double v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        cdef Mut2 v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef numpy.ndarray[double,ndim=1] v23
        cdef numpy.ndarray[double,ndim=1] v24
        cdef unsigned long long v25
        cdef unsigned long long v26
        cdef bint v27
        cdef bint v28
        cdef unsigned long long v29
        cdef double v30
        v18 = method38(v0, v1, v13)
        v19 = v3 + v17
        v20 = v2 + v16
        v21 = v20 - v19
        v22 = libc.math.exp(v21)
        v23 = v18.v1
        del v18
        v24 = method45(v23)
        del v23
        v25 = len(v24)
        v26 = len(v1)
        v27 = v25 == v26
        v28 = v27 == 0
        if v28:
            raise Exception("The length of the two arrays has to the same.")
        else:
            pass
        v29 = (<unsigned long long>0)
        v30 = (<double>0.000000)
        return method54(v25, v12, v22, v24, v1, v29, v30)
cdef class Closure60():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef signed long v13
    cdef US0 v14
    cdef US0 v15
    cdef unsigned char v16
    cdef signed long v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, signed long v13, US0 v14, US0 v15, unsigned char v16, signed long v17, US0 v18, unsigned char v19, signed long v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef US0 v15 = self.v15
        cdef unsigned char v16 = self.v16
        cdef signed long v17 = self.v17
        cdef US0 v18 = self.v18
        cdef unsigned char v19 = self.v19
        cdef signed long v20 = self.v20
        cdef double v21 = args.v0
        cdef double v22 = args.v1
        cdef US3 v23 = args.v2
        cdef double v24
        cdef double v25
        cdef US2 v26
        cdef UH0 v27
        cdef US2 v28
        cdef UH0 v29
        v24 = v22 + v2
        v25 = v21 + v1
        v26 = US2_0(v23)
        v27 = UH0_0(v26, v3)
        del v26
        v28 = US2_0(v23)
        v29 = UH0_0(v28, v0)
        del v28
        return method59(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v23, v6, v7, v27, v4, v5, v29, v25, v24)
cdef class Closure59():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef signed long v13
    cdef US0 v14
    cdef US0 v15
    cdef unsigned char v16
    cdef signed long v17
    cdef US0 v18
    cdef unsigned char v19
    cdef signed long v20
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, signed long v13, US0 v14, US0 v15, unsigned char v16, signed long v17, US0 v18, unsigned char v19, signed long v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef US0 v15 = self.v15
        cdef unsigned char v16 = self.v16
        cdef signed long v17 = self.v17
        cdef US0 v18 = self.v18
        cdef unsigned char v19 = self.v19
        cdef signed long v20 = self.v20
        cdef double v21 = args.v0
        cdef double v22 = args.v1
        cdef US3 v23 = args.v2
        cdef double v24
        cdef double v25
        cdef US2 v26
        cdef UH0 v27
        cdef US2 v28
        cdef UH0 v29
        v24 = v22 + v5
        v25 = v21 + v4
        v26 = US2_0(v23)
        v27 = UH0_0(v26, v3)
        del v26
        v28 = US2_0(v23)
        v29 = UH0_0(v28, v0)
        del v28
        return method59(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v23, v6, v7, v27, v25, v24, v29, v1, v2)
cdef class Closure58():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17, signed long v18, US0 v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US0 v19 = self.v19
        cdef double v20 = args.v0
        cdef double v21 = args.v1
        cdef US3 v22 = args.v2
        cdef double v23
        cdef double v24
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        v23 = v21 + v5
        v24 = v20 + v4
        v25 = US2_0(v22)
        v26 = UH0_0(v25, v3)
        del v25
        v27 = US2_0(v22)
        v28 = UH0_0(v27, v0)
        del v27
        return method58(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v22, v6, v7, v26, v24, v23, v28, v1, v2)
cdef class Closure61():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17, signed long v18, US0 v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US0 v19 = self.v19
        cdef double v20 = args.v0
        cdef double v21 = args.v1
        cdef US3 v22 = args.v2
        cdef double v23
        cdef double v24
        cdef US2 v25
        cdef UH0 v26
        cdef US2 v27
        cdef UH0 v28
        v23 = v21 + v2
        v24 = v20 + v1
        v25 = US2_0(v22)
        v26 = UH0_0(v25, v3)
        del v25
        v27 = US2_0(v22)
        v28 = UH0_0(v27, v0)
        del v27
        return method58(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v22, v6, v7, v26, v4, v5, v28, v24, v23)
cdef class Closure57():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef US0 v4
    cdef unsigned char v5
    cdef signed long v6
    cdef US0 v7
    cdef unsigned char v8
    cdef signed long v9
    cdef US0 v10
    cdef object v11
    cdef Heap0 v12
    def __init__(self, v0, v1, v2, v3, US0 v4, unsigned char v5, signed long v6, US0 v7, unsigned char v8, signed long v9, US0 v10, numpy.ndarray[signed long,ndim=1] v11, Heap0 v12): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef US0 v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US0 v7 = self.v7
        cdef unsigned char v8 = self.v8
        cdef signed long v9 = self.v9
        cdef US0 v10 = self.v10
        cdef numpy.ndarray[signed long,ndim=1] v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef double v13 = args.v0
        cdef double v14 = args.v1
        cdef UH0 v15 = args.v2
        cdef double v16 = args.v3
        cdef double v17 = args.v4
        cdef UH0 v18 = args.v5
        cdef double v19 = args.v6
        cdef double v20 = args.v7
        cdef bint v21
        cdef US1 v22
        cdef object v23
        cdef US1 v25
        cdef object v26
        v21 = v5 == (<unsigned char>0)
        if v21:
            v22 = US1_1(v10)
            v23 = Closure58(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v12, v7, v8, v9, v4, v5, v6, v10)
            return v2(Tuple0(v11, v13, v14, v4, v5, v6, v7, v8, v9, v22, (<unsigned char>0), v23, v15, v16, v17, v19, v20))
        else:
            v25 = US1_1(v10)
            v26 = Closure61(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v12, v7, v8, v9, v4, v5, v6, v10)
            return v0(Tuple0(v11, v13, v14, v4, v5, v6, v7, v8, v9, v25, (<unsigned char>1), v26, v18, v19, v20, v16, v17))
cdef class Closure56():
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
    def __init__(self, v0, v1, v2, v3, Heap0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10
    def __call__(self, US0 v11):
        cdef object v0 = self.v0
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
        cdef numpy.ndarray[signed long,ndim=1] v12
        v12 = v4.v2
        return Closure57(v0, v1, v2, v3, v8, v9, v10, v5, v6, v7, v11, v12, v4)
cdef class Closure63():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef object v13
    cdef object v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, v13, numpy.ndarray[signed long,ndim=1] v14, signed long v15, US0 v16, unsigned char v17, signed long v18, US0 v19, unsigned char v20, signed long v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef object v13 = self.v13
        cdef numpy.ndarray[signed long,ndim=1] v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US0 v19 = self.v19
        cdef unsigned char v20 = self.v20
        cdef signed long v21 = self.v21
        cdef double v22 = args.v0
        cdef double v23 = args.v1
        cdef US3 v24 = args.v2
        cdef double v25
        cdef double v26
        cdef US2 v27
        cdef UH0 v28
        cdef US2 v29
        cdef UH0 v30
        v25 = v23 + v2
        v26 = v22 + v1
        v27 = US2_0(v24)
        v28 = UH0_0(v27, v3)
        del v27
        v29 = US2_0(v24)
        v30 = UH0_0(v29, v0)
        del v29
        return method60(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v24, v6, v7, v28, v4, v5, v30, v26, v25)
cdef class Closure62():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef object v13
    cdef object v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    cdef signed long v21
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, v13, numpy.ndarray[signed long,ndim=1] v14, signed long v15, US0 v16, unsigned char v17, signed long v18, US0 v19, unsigned char v20, signed long v21): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef object v13 = self.v13
        cdef numpy.ndarray[signed long,ndim=1] v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US0 v19 = self.v19
        cdef unsigned char v20 = self.v20
        cdef signed long v21 = self.v21
        cdef double v22 = args.v0
        cdef double v23 = args.v1
        cdef US3 v24 = args.v2
        cdef double v25
        cdef double v26
        cdef US2 v27
        cdef UH0 v28
        cdef US2 v29
        cdef UH0 v30
        v25 = v23 + v5
        v26 = v22 + v4
        v27 = US2_0(v24)
        v28 = UH0_0(v27, v3)
        del v27
        v29 = US2_0(v24)
        v30 = UH0_0(v29, v0)
        del v29
        return method60(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v24, v6, v7, v28, v26, v25, v30, v1, v2)
cdef class Closure55():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef object v13
    cdef object v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, v13, numpy.ndarray[signed long,ndim=1] v14, signed long v15, US0 v16, unsigned char v17, signed long v18, US0 v19, unsigned char v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef object v13 = self.v13
        cdef numpy.ndarray[signed long,ndim=1] v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US0 v19 = self.v19
        cdef unsigned char v20 = self.v20
        cdef double v21 = args.v0
        cdef double v22 = args.v1
        cdef US3 v23 = args.v2
        cdef double v24
        cdef double v25
        cdef US2 v26
        cdef UH0 v27
        cdef US2 v28
        cdef UH0 v29
        v24 = v22 + v5
        v25 = v21 + v4
        v26 = US2_0(v23)
        v27 = UH0_0(v26, v3)
        del v26
        v28 = US2_0(v23)
        v29 = UH0_0(v28, v0)
        del v28
        return method57(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v23, v6, v7, v27, v25, v24, v29, v1, v2)
cdef class Closure64():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef Heap0 v12
    cdef object v13
    cdef object v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    cdef US0 v19
    cdef unsigned char v20
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, Heap0 v12, v13, numpy.ndarray[signed long,ndim=1] v14, signed long v15, US0 v16, unsigned char v17, signed long v18, US0 v19, unsigned char v20): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef Heap0 v12 = self.v12
        cdef object v13 = self.v13
        cdef numpy.ndarray[signed long,ndim=1] v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US0 v19 = self.v19
        cdef unsigned char v20 = self.v20
        cdef double v21 = args.v0
        cdef double v22 = args.v1
        cdef US3 v23 = args.v2
        cdef double v24
        cdef double v25
        cdef US2 v26
        cdef UH0 v27
        cdef US2 v28
        cdef UH0 v29
        v24 = v22 + v2
        v25 = v21 + v1
        v26 = US2_0(v23)
        v27 = UH0_0(v26, v3)
        del v26
        v28 = US2_0(v23)
        v29 = UH0_0(v28, v0)
        del v28
        return method57(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v23, v6, v7, v27, v4, v5, v29, v25, v24)
cdef class Closure54():
    cdef UH0 v0
    cdef double v1
    cdef double v2
    cdef UH0 v3
    cdef double v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef object v11
    cdef US0 v12
    cdef US0 v13
    cdef Heap0 v14
    cdef object v15
    cdef object v16
    def __init__(self, UH0 v0, double v1, double v2, UH0 v3, double v4, double v5, double v6, double v7, v8, v9, v10, v11, US0 v12, US0 v13, Heap0 v14, v15, numpy.ndarray[signed long,ndim=1] v16): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16
    def __call__(self, Tuple4 args):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef UH0 v3 = self.v3
        cdef double v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef object v9 = self.v9
        cdef object v10 = self.v10
        cdef object v11 = self.v11
        cdef US0 v12 = self.v12
        cdef US0 v13 = self.v13
        cdef Heap0 v14 = self.v14
        cdef object v15 = self.v15
        cdef numpy.ndarray[signed long,ndim=1] v16 = self.v16
        cdef double v17 = args.v0
        cdef double v18 = args.v1
        cdef US3 v19 = args.v2
        cdef double v20
        cdef double v21
        cdef US2 v22
        cdef UH0 v23
        cdef US2 v24
        cdef UH0 v25
        v20 = v18 + v5
        v21 = v17 + v4
        v22 = US2_0(v19)
        v23 = UH0_0(v22, v3)
        del v22
        v24 = US2_0(v19)
        v25 = UH0_0(v24, v0)
        del v24
        return method56(v8, v9, v10, v11, v12, v13, v14, v15, v16, v19, v6, v7, v23, v21, v20, v25, v1, v2)
cdef class Closure53():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef US0 v4
    cdef US0 v5
    cdef object v6
    cdef Heap0 v7
    cdef object v8
    cdef object v9
    def __init__(self, v0, v1, v2, v3, US0 v4, US0 v5, numpy.ndarray[signed long,ndim=1] v6, Heap0 v7, v8, numpy.ndarray[signed long,ndim=1] v9): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9
    def __call__(self, Tuple6 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef US0 v4 = self.v4
        cdef US0 v5 = self.v5
        cdef numpy.ndarray[signed long,ndim=1] v6 = self.v6
        cdef Heap0 v7 = self.v7
        cdef object v8 = self.v8
        cdef numpy.ndarray[signed long,ndim=1] v9 = self.v9
        cdef double v10 = args.v0
        cdef double v11 = args.v1
        cdef UH0 v12 = args.v2
        cdef double v13 = args.v3
        cdef double v14 = args.v4
        cdef UH0 v15 = args.v5
        cdef double v16 = args.v6
        cdef double v17 = args.v7
        cdef US1 v18
        cdef object v19
        v18 = US1_0()
        v19 = Closure54(v15, v16, v17, v12, v13, v14, v10, v11, v0, v1, v2, v3, v4, v5, v7, v8, v9)
        return v2(Tuple0(v6, v10, v11, v4, (<unsigned char>0), (<signed long>1), v5, (<unsigned char>1), (<signed long>1), v18, (<unsigned char>0), v19, v12, v13, v14, v16, v17))
cdef class Closure52():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef Heap0 v5
    cdef US0 v6
    def __init__(self, v0, v1, v2, v3, v4, Heap0 v5, US0 v6): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6
    def __call__(self, Tuple7 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef object v4 = self.v4
        cdef Heap0 v5 = self.v5
        cdef US0 v6 = self.v6
        cdef US0 v7 = args.v0
        cdef numpy.ndarray[signed long,ndim=1] v8 = args.v1
        cdef numpy.ndarray[signed long,ndim=1] v9
        v9 = v5.v2
        return Closure53(v1, v2, v3, v4, v6, v7, v9, v5, v0, v8)
cdef class Closure51():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef Heap0 v6
    def __init__(self, v0, v1, v2, v3, v4, v5, Heap0 v6): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6
    def __call__(self, Tuple7 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef object v4 = self.v4
        cdef object v5 = self.v5
        cdef Heap0 v6 = self.v6
        cdef US0 v7 = args.v0
        cdef numpy.ndarray[signed long,ndim=1] v8 = args.v1
        cdef US4 v9
        cdef object v10
        cdef object v11
        cdef object v12
        v9 = US4_1((<unsigned char>1))
        v10 = v5(v9)
        del v9
        v11 = v10(v8)
        del v10
        v12 = Closure52(v0, v1, v2, v3, v4, v6, v7)
        return v11(v12)
cdef class Closure0():
    cdef Mut0 v0
    cdef Mut1 v1
    def __init__(self, Mut0 v0, Mut1 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef Mut1 v1 = self.v1
        cdef unsigned long long v2
        cdef bint v3
        cdef object v4
        cdef object v5
        cdef double v6
        cdef bint v7
        cdef object v8
        cdef object v9
        cdef object v10
        v2 = (<unsigned long long>0)
        method4(v0, v2)
        v3 = 0
        v4 = Closure47(v1)
        v5 = Closure48()
        v6 = method24(v3, v4, v5)
        del v4
        v7 = 0
        v8 = Closure49(v0)
        v9 = Closure2()
        v10 = Closure50(v1)
        return method55(v7, v10, v5, v8, v9)
cdef class Tuple9:
    cdef readonly UH0 v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    cdef readonly object v4
    def __init__(self, UH0 v0, v1, v2, v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Closure65():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1
        cdef unsigned long long v2
        cdef list v3
        cdef unsigned long long v4
        v1 = method61(v0)
        v2 = len(v1)
        v3 = [None]*v2
        v4 = (<unsigned long long>0)
        method65(v2, v1, v3, v4)
        del v1
        return v3
cdef class Closure68():
    def __init__(self): pass
    def __call__(self, double v0):
        pass
cdef class US5:
    cdef readonly signed long tag
cdef class US5_0(US5): # none
    def __init__(self): self.tag = 0
cdef class US5_1(US5): # some_
    cdef readonly double v0
    def __init__(self, double v0): self.tag = 1; self.v0 = v0
cdef class Closure69():
    def __init__(self): pass
    def __call__(self, US3 v0):
        pass
cdef class Mut3:
    cdef public object v0
    cdef public object v1
    cdef public object v2
    def __init__(self, v0, v1, v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class Closure70():
    cdef object v0
    cdef US3 v1
    def __init__(self, v0, US3 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US3 v1 = self.v1
        v0(v1)
cdef class Closure71():
    cdef object v0
    cdef US3 v1
    def __init__(self, v0, US3 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US3 v1 = self.v1
        v0(v1)
cdef class Closure72():
    cdef object v0
    cdef US3 v1
    def __init__(self, v0, US3 v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef US3 v1 = self.v1
        v0(v1)
cdef class Closure73():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef Mut0 v9
    cdef Heap0 v10
    cdef signed long v11
    cdef US0 v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    def __init__(self, v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, v8, Mut0 v9, Heap0 v10, signed long v11, US0 v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17, signed long v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, US3 v19):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef double v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef Mut0 v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef signed long v11 = self.v11
        cdef US0 v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v20 = US2_0(v19)
        v21 = UH0_0(v20, v4)
        del v20
        v22 = US2_0(v19)
        v23 = UH0_0(v22, v1)
        del v22
        method76(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v7, v21, v5, v6, v23, v2, v3, v0)
cdef class Closure74():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef Mut0 v9
    cdef Heap0 v10
    cdef US0 v11
    cdef unsigned char v12
    cdef signed long v13
    cdef US0 v14
    cdef unsigned char v15
    cdef signed long v16
    cdef US0 v17
    def __init__(self, v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, v8, Mut0 v9, Heap0 v10, US0 v11, unsigned char v12, signed long v13, US0 v14, unsigned char v15, signed long v16, US0 v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, US3 v18):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef double v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef Mut0 v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef US0 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef signed long v13 = self.v13
        cdef US0 v14 = self.v14
        cdef unsigned char v15 = self.v15
        cdef signed long v16 = self.v16
        cdef US0 v17 = self.v17
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v19 = US2_0(v18)
        v20 = UH0_0(v19, v4)
        del v19
        v21 = US2_0(v18)
        v22 = UH0_0(v21, v1)
        del v21
        method75(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v7, v20, v5, v6, v22, v2, v3, v0)
cdef class Closure75():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef Mut0 v9
    cdef Heap0 v10
    cdef object v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    cdef signed long v18
    def __init__(self, v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, v8, Mut0 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11, signed long v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17, signed long v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, US3 v19):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef double v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef Mut0 v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef numpy.ndarray[signed long,ndim=1] v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef signed long v18 = self.v18
        cdef US2 v20
        cdef UH0 v21
        cdef US2 v22
        cdef UH0 v23
        v20 = US2_0(v19)
        v21 = UH0_0(v20, v4)
        del v20
        v22 = US2_0(v19)
        v23 = UH0_0(v22, v1)
        del v22
        method82(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v7, v21, v5, v6, v23, v2, v3, v0)
cdef class Closure76():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef double v3
    cdef UH0 v4
    cdef double v5
    cdef double v6
    cdef double v7
    cdef object v8
    cdef Mut0 v9
    cdef Heap0 v10
    cdef object v11
    cdef signed long v12
    cdef US0 v13
    cdef unsigned char v14
    cdef signed long v15
    cdef US0 v16
    cdef unsigned char v17
    def __init__(self, v0, UH0 v1, double v2, double v3, UH0 v4, double v5, double v6, double v7, v8, Mut0 v9, Heap0 v10, numpy.ndarray[signed long,ndim=1] v11, signed long v12, US0 v13, unsigned char v14, signed long v15, US0 v16, unsigned char v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, US3 v18):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef double v3 = self.v3
        cdef UH0 v4 = self.v4
        cdef double v5 = self.v5
        cdef double v6 = self.v6
        cdef double v7 = self.v7
        cdef object v8 = self.v8
        cdef Mut0 v9 = self.v9
        cdef Heap0 v10 = self.v10
        cdef numpy.ndarray[signed long,ndim=1] v11 = self.v11
        cdef signed long v12 = self.v12
        cdef US0 v13 = self.v13
        cdef unsigned char v14 = self.v14
        cdef signed long v15 = self.v15
        cdef US0 v16 = self.v16
        cdef unsigned char v17 = self.v17
        cdef US2 v19
        cdef UH0 v20
        cdef US2 v21
        cdef UH0 v22
        v19 = US2_0(v18)
        v20 = UH0_0(v19, v4)
        del v19
        v21 = US2_0(v18)
        v22 = UH0_0(v21, v1)
        del v21
        method73(v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v7, v20, v5, v6, v22, v2, v3, v0)
cdef class Closure67():
    cdef Mut0 v0
    cdef object v1
    def __init__(self, Mut0 v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef object v1 = self.v1
        cdef US3 v2
        cdef US3 v3
        cdef numpy.ndarray[signed long,ndim=1] v4
        cdef US3 v5
        cdef US3 v6
        cdef US3 v7
        cdef numpy.ndarray[signed long,ndim=1] v8
        cdef US3 v9
        cdef US3 v10
        cdef numpy.ndarray[signed long,ndim=1] v11
        cdef US3 v12
        cdef numpy.ndarray[signed long,ndim=1] v13
        cdef Heap0 v14
        cdef US0 v15
        cdef US0 v16
        cdef US0 v17
        cdef US0 v18
        cdef US0 v19
        cdef US0 v20
        cdef numpy.ndarray[signed long,ndim=1] v21
        cdef unsigned long long v22
        cdef unsigned long long v23
        cdef UH0 v24
        cdef double v25
        cdef double v26
        cdef UH0 v27
        cdef double v28
        cdef double v29
        cdef US0 v30
        cdef unsigned long long v31
        cdef numpy.ndarray[signed long,ndim=1] v32
        cdef unsigned long long v33
        cdef double v34
        cdef double v35
        cdef double v36
        cdef US2 v37
        cdef UH0 v38
        cdef object v39
        v2 = 0
        v3 = 2
        v4 = numpy.empty(2,dtype=numpy.int32)
        v4[0] = v2; v4[1] = v3
        v5 = 1
        v6 = 0
        v7 = 2
        v8 = numpy.empty(3,dtype=numpy.int32)
        v8[0] = v5; v8[1] = v6; v8[2] = v7
        v9 = 1
        v10 = 0
        v11 = numpy.empty(2,dtype=numpy.int32)
        v11[0] = v9; v11[1] = v10
        v12 = 0
        v13 = numpy.empty(1,dtype=numpy.int32)
        v13[0] = v12
        v14 = Heap0(v13, v8, v4, v11)
        del v4; del v8; del v11; del v13
        v15 = 1
        v16 = 2
        v17 = 0
        v18 = 1
        v19 = 2
        v20 = 0
        v21 = numpy.empty(6,dtype=numpy.int32)
        v21[0] = v15; v21[1] = v16; v21[2] = v17; v21[3] = v18; v21[4] = v19; v21[5] = v20
        v22 = len(v21)
        v23 = numpy.random.randint(0,v22)
        v24 = UH0_1()
        v25 = (<double>0.000000)
        v26 = (<double>0.000000)
        v27 = UH0_1()
        v28 = (<double>0.000000)
        v29 = (<double>0.000000)
        v30 = v21[v23]
        v31 = v22 - (<unsigned long long>1)
        v32 = numpy.empty(v31,dtype=numpy.int32)
        v33 = (<unsigned long long>0)
        method26(v31, v23, v21, v32, v33)
        del v21
        v34 = <double>v22
        v35 = (<double>1.000000) / v34
        v36 = libc.math.log(v35)
        v37 = US2_1(v30)
        v38 = UH0_0(v37, v24)
        del v24; del v37
        v39 = Closure68()
        method70(v1, v0, v14, v30, v32, v36, v38, v25, v26, v27, v28, v29, v39)
cdef class Closure66():
    cdef Mut0 v0
    def __init__(self, Mut0 v0): self.v0 = v0
    def __call__(self):
        cdef Mut0 v0 = self.v0
        cdef object v1
        cdef object v2
        pass # import ui_leduc
        v1 = ui_leduc.Top()
        v2 = Closure67(v0, v1)
        ui_leduc.popup_game(v1,v2)
cdef void method1(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
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
    v4 = (<unsigned long long>0)
    method1(v1, v3, v4)
    v5 = Mut0(v0, v3, (<unsigned long long>0))
    del v3
    return v5
cdef void method3(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method3(v0, v1, v4)
    else:
        pass
cdef Mut1 method2(unsigned long long v0, unsigned long long v1):
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef Mut1 v5
    v3 = numpy.empty(v1,dtype=object)
    v4 = (<unsigned long long>0)
    method3(v1, v3, v4)
    v5 = Mut1(v0, v3, (<unsigned long long>0))
    del v3
    return v5
cdef unsigned long long method7(UH0 v0):
    cdef US2 v1
    cdef UH0 v2
    cdef unsigned long long v35
    cdef US3 v3
    cdef unsigned long long v13
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v7
    cdef unsigned long long v8
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v14
    cdef unsigned long long v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef US0 v19
    cdef unsigned long long v29
    cdef unsigned long long v20
    cdef unsigned long long v21
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef unsigned long long v30
    cdef unsigned long long v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v36
    cdef unsigned long long v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef unsigned long long v40
    cdef unsigned long long v41
    cdef unsigned long long v42
    cdef unsigned long long v44
    cdef unsigned long long v45
    if v0.tag == 0: # cons_
        v1 = (<UH0_0>v0).v0; v2 = (<UH0_0>v0).v1
        if v1.tag == 0: # action_
            v3 = (<US2_0>v1).v0
            if v3 == 0: # call
                v4 = (<signed long>0)
                v5 = (<unsigned long long>1) + v4
                v13 = (<unsigned long long>9223372036854765835) * v5
            elif v3 == 1: # fold
                v7 = (<signed long>1)
                v8 = (<unsigned long long>1) + v7
                v13 = (<unsigned long long>9223372036854765835) * v8
            elif v3 == 2: # raise
                v10 = (<signed long>2)
                v11 = (<unsigned long long>1) + v10
                v13 = (<unsigned long long>9223372036854765835) * v11
            v14 = (<unsigned long long>9223372036854775807) + v13
            v15 = v14 * (<unsigned long long>9973)
            v16 = (<signed long>0)
            v17 = (<unsigned long long>1) + v16
            v35 = v15 * v17
        elif v1.tag == 1: # observation_
            v19 = (<US2_1>v1).v0
            if v19 == 0: # jack
                v20 = (<signed long>0)
                v21 = (<unsigned long long>1) + v20
                v29 = (<unsigned long long>9223372036854765835) * v21
            elif v19 == 1: # king
                v23 = (<signed long>1)
                v24 = (<unsigned long long>1) + v23
                v29 = (<unsigned long long>9223372036854765835) * v24
            elif v19 == 2: # queen
                v26 = (<signed long>2)
                v27 = (<unsigned long long>1) + v26
                v29 = (<unsigned long long>9223372036854765835) * v27
            v30 = (<unsigned long long>9223372036854775807) + v29
            v31 = v30 * (<unsigned long long>9973)
            v32 = (<signed long>1)
            v33 = (<unsigned long long>1) + v32
            v35 = v31 * v33
        del v1
        v36 = v35 * (<unsigned long long>9973)
        v37 = method7(v2)
        del v2
        v38 = v36 + v37
        v39 = (<unsigned long long>9223372036854775807) + v38
        v40 = v39 * (<unsigned long long>9973)
        v41 = (<signed long>0)
        v42 = (<unsigned long long>1) + v41
        return v40 * v42
    elif v0.tag == 1: # nil
        v44 = (<signed long>1)
        v45 = (<unsigned long long>1) + v44
        return (<unsigned long long>9223372036854765835) * v45
cdef bint method9(UH0 v0, UH0 v1):
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
            if v6 == 0 and v7 == 0: # call
                v12 = 1
            elif v6 == 1 and v7 == 1: # fold
                v12 = 1
            elif v6 == 2 and v7 == 2: # raise
                v12 = 1
            else:
                v12 = 0
        elif v2.tag == 1 and v4.tag == 1: # observation_
            v9 = (<US2_1>v2).v0; v10 = (<US2_1>v4).v0
            if v9 == 0 and v10 == 0: # jack
                v12 = 1
            elif v9 == 1 and v10 == 1: # king
                v12 = 1
            elif v9 == 2 and v10 == 2: # queen
                v12 = 1
            else:
                v12 = 0
        else:
            v12 = 0
        del v2; del v4
        if v12:
            return method9(v5, v3)
        else:
            del v3; del v5
            return 0
    elif v1.tag == 1 and v0.tag == 1: # nil
        return 1
    else:
        return 0
cdef void method10(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method10(v0, v1, v4)
    else:
        pass
cdef void method11(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = Tuple3((<double>0.000000), (<double>0.000000))
        method11(v0, v1, v4)
    else:
        pass
cdef void method13(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method13(v0, v1, v4)
    else:
        pass
cdef void method15(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef Tuple2 tmp1
    cdef unsigned long long v13
    cdef list v14
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp1 = v3[v4]
        v7, v8, v9, v10, v11, v12 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4, tmp1.v5
        del tmp1
        v13 = v7 % v1
        v14 = v2[v13]
        v14.append(Tuple2(v7, v8, v9, v10, v11, v12))
        del v8; del v9; del v10; del v11; del v12; del v14
        method15(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method14(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        method15(v8, v2, v3, v7, v9)
        del v7
        method14(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method12(Mut0 v0):
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
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = (<unsigned long long>0)
    method13(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method14(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Tuple1 method8(Mut0 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef numpy.ndarray[signed long,ndim=1] v10
    cdef numpy.ndarray[double,ndim=1] v11
    cdef numpy.ndarray[object,ndim=1] v12
    cdef numpy.ndarray[double,ndim=1] v13
    cdef Tuple2 tmp0
    cdef bint v14
    cdef bint v16
    cdef unsigned long long v17
    cdef unsigned long long v26
    cdef numpy.ndarray[double,ndim=1] v27
    cdef unsigned long long v28
    cdef numpy.ndarray[double,ndim=1] v29
    cdef unsigned long long v30
    cdef numpy.ndarray[object,ndim=1] v31
    cdef unsigned long long v32
    cdef unsigned long long v33
    cdef unsigned long long v34
    cdef unsigned long long v35
    cdef unsigned long long v36
    cdef numpy.ndarray[object,ndim=1] v37
    cdef unsigned long long v38
    cdef unsigned long long v39
    cdef bint v40
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp0 = v4[v5]
        v8, v9, v10, v11, v12, v13 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5
        del tmp0
        v14 = v3 == v8
        if v14:
            v16 = method9(v9, v1)
        else:
            v16 = 0
        del v9
        if v16:
            return Tuple1(v10, v11, v12, v13)
        else:
            del v10; del v11; del v12; del v13
            v17 = v5 + (<unsigned long long>1)
            return method8(v0, v1, v2, v3, v4, v17)
    else:
        v26 = len(v2)
        v27 = numpy.empty(v26,dtype=numpy.float64)
        v28 = (<unsigned long long>0)
        method10(v26, v27, v28)
        v29 = numpy.empty(v26,dtype=numpy.float64)
        v30 = (<unsigned long long>0)
        method10(v26, v29, v30)
        v31 = numpy.empty(v26,dtype=object)
        v32 = (<unsigned long long>0)
        method11(v26, v31, v32)
        v4.append(Tuple2(v3, v1, v2, v29, v31, v27))
        v33 = v0.v2
        v34 = v33 + (<unsigned long long>1)
        v0.v2 = v34
        v35 = v0.v2
        v36 = v0.v0
        v37 = v0.v1
        v38 = len(v37)
        del v37
        v39 = v36 * v38
        v40 = v35 >= v39
        if v40:
            method12(v0)
        else:
            pass
        return Tuple1(v2, v29, v31, v27)
cdef Tuple1 method6(Mut0 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method7(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method8(v0, v2, v1, v4, v8, v9)
cdef double method17(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef bint v8
    cdef double v9
    cdef double v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        v7 = v1[v3]
        v8 = (<double>0.000000) >= v7
        if v8:
            v9 = (<double>0.000000)
        else:
            v9 = v7
        v10 = v9 + v4
        v2[v3] = v9
        return method17(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method18(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method18(v0, v1, v2, v5)
    else:
        pass
cdef void method19(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v7 = v6 / v1
        v2[v3] = v7
        method19(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method16(numpy.ndarray[double,ndim=1] v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[double,ndim=1] v2
    cdef unsigned long long v3
    cdef double v4
    cdef double v5
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    v1 = len(v0)
    v2 = numpy.empty(v1,dtype=numpy.float64)
    v3 = (<unsigned long long>0)
    v4 = (<double>0.000000)
    v5 = method17(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method18(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method19(v11, v5, v2, v12)
    return v2
cdef void method20(unsigned long long v0, unsigned long long v1, numpy.ndarray[double,ndim=1] v2, numpy.ndarray[double,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef double v8
    cdef double v9
    cdef double v10
    cdef double v11
    cdef double v12
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v2[v4]
        v8 = <double>v1
        v9 = (<double>1.000000) / v8
        v10 = (<double>0.250000) * v9
        v11 = (<double>0.750000) * v7
        v12 = v10 + v11
        v3[v4] = v12
        method20(v0, v1, v2, v3, v6)
    else:
        pass
cdef double method21(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2, double v3, double v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[double,ndim=1] v6, unsigned long long v7, double v8):
    cdef bint v9
    cdef unsigned long long v10
    cdef double v11
    cdef double v12
    cdef Tuple3 tmp3
    cdef bint v13
    cdef double v15
    cdef double v14
    cdef bint v16
    cdef double v20
    cdef double v17
    cdef double v18
    cdef double v19
    cdef double v21
    cdef double v22
    cdef double v23
    v9 = v7 < v0
    if v9:
        v10 = v7 + (<unsigned long long>1)
        tmp3 = v5[v7]
        v11, v12 = tmp3.v0, tmp3.v1
        del tmp3
        v13 = v12 == (<double>0.000000)
        if v13:
            v15 = (<double>0.000000)
        else:
            v14 = v11 / v12
            v15 = v14
        v16 = v7 == v2
        if v16:
            v17 = v4 - v15
            v18 = v17 / v3
            v19 = v18 + v15
            v20 = v19
        else:
            v20 = v15
        v21 = v1[v7]
        v22 = v20 * v21
        v23 = v8 + v22
        v6[v7] = v20
        return method21(v0, v1, v2, v3, v4, v5, v6, v10, v23)
    else:
        return v8
cdef void method22(unsigned long long v0, unsigned char v1, double v2, numpy.ndarray[double,ndim=1] v3, double v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6):
    cdef bint v7
    cdef unsigned long long v8
    cdef double v9
    cdef double v10
    cdef double v11
    cdef bint v12
    cdef double v14
    cdef double v15
    cdef double v16
    cdef bint v17
    cdef double v18
    v7 = v6 < v0
    if v7:
        v8 = v6 + (<unsigned long long>1)
        v9 = v5[v6]
        v10 = v3[v6]
        v11 = v10 - v2
        v12 = v1 == (<unsigned char>0)
        if v12:
            v14 = v11
        else:
            v14 = -v11
        v15 = v4 * v14
        v16 = v9 + v15
        v17 = (<double>0.000000) >= v16
        if v17:
            v18 = (<double>0.000000)
        else:
            v18 = v16
        v5[v6] = v18
        method22(v0, v1, v2, v3, v4, v5, v8)
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
        v6 = v4 + (<unsigned long long>1)
        v7 = v3[v4]
        v8 = v1[v4]
        v9 = v2 * v8
        v10 = v7 + v9
        v3[v4] = v10
        method23(v0, v1, v2, v3, v6)
    else:
        pass
cdef double method5(Mut0 v0, v1, numpy.ndarray[signed long,ndim=1] v2, unsigned char v3, double v4, double v5, UH0 v6, double v7, double v8, double v9, double v10):
    cdef numpy.ndarray[signed long,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef numpy.ndarray[object,ndim=1] v13
    cdef numpy.ndarray[double,ndim=1] v14
    cdef Tuple1 tmp2
    cdef unsigned long long v15
    cdef numpy.ndarray[double,ndim=1] v16
    cdef unsigned long long v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef double v21
    cdef double v22
    cdef double v23
    cdef double v24
    cdef US3 v25
    cdef double v26
    cdef numpy.ndarray[double,ndim=1] v27
    cdef unsigned long long v28
    cdef double v29
    cdef double v30
    cdef double v31
    cdef double v32
    cdef double v33
    cdef double v34
    cdef double v35
    cdef double v36
    cdef double v37
    cdef double v38
    cdef Tuple3 tmp4
    cdef double v39
    cdef double v40
    cdef double v41
    cdef double v42
    cdef double v43
    cdef double v44
    cdef double v45
    cdef unsigned long long v46
    cdef unsigned long long v47
    cdef numpy.ndarray[double,ndim=1] v48
    cdef double v49
    cdef double v50
    cdef double v51
    cdef unsigned long long v52
    cdef unsigned long long v53
    tmp2 = method6(v0, v2, v6)
    v11, v12, v13, v14 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3
    del tmp2
    del v11
    v15 = len(v2)
    v16 = method16(v14)
    v17 = len(v16)
    v18 = numpy.empty(v17,dtype=numpy.float64)
    v19 = (<unsigned long long>0)
    method20(v17, v15, v16, v18, v19)
    v20 = numpy.random.choice(v15,p=v18)
    v21 = v18[v20]
    del v18
    v22 = v16[v20]
    v23 = libc.math.log(v21)
    v24 = libc.math.log(v22)
    v25 = v2[v20]
    v26 = v1(Tuple4(v24, v23, v25))
    v27 = numpy.empty(v15,dtype=numpy.float64)
    v28 = (<unsigned long long>0)
    v29 = (<double>0.000000)
    v30 = method21(v15, v16, v20, v21, v26, v13, v27, v28, v29)
    del v16
    v31 = v10 + v5
    v32 = v9 + v4
    v33 = -v8
    v34 = v32 - v31
    v35 = v33 + v34
    v36 = libc.math.exp(v35)
    tmp4 = v13[v20]
    v37, v38 = tmp4.v0, tmp4.v1
    del tmp4
    v39 = v37 * (<double>0.968750)
    v40 = v38 * (<double>0.968750)
    v41 = v26 * v36
    v42 = v41 * (<double>0.031250)
    v43 = v36 * (<double>0.031250)
    v44 = v39 + v42
    v45 = v40 + v43
    v13[v20] = Tuple3(v44, v45)
    del v13
    v46 = len(v14)
    v47 = (<unsigned long long>0)
    method22(v46, v3, v30, v27, v36, v14, v47)
    del v27
    v48 = method16(v14)
    del v14
    v49 = v7 - v8
    v50 = v49 - v31
    v51 = libc.math.exp(v50)
    v52 = len(v12)
    v53 = (<unsigned long long>0)
    method23(v52, v48, v51, v12, v53)
    del v12; del v48
    return v30
cdef double method25(v0, US4 v1, numpy.ndarray[signed long,ndim=1] v2, v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11, unsigned long long v12, double v13):
    cdef unsigned long long v14
    cdef double v15
    cdef double v16
    cdef bint v17
    cdef object v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef object v22
    cdef double v23
    cdef unsigned long long v24
    cdef double v25
    cdef double v27
    v14 = len(v2)
    v15 = <double>v14
    v16 = (<double>1.000000) / v15
    v17 = v12 < v14
    if v17:
        v18 = v0(0)
        v19 = v18(v12)
        del v18
        v20 = v19(v1)
        del v19
        v21 = v20(v2)
        del v20
        v22 = v21(v3)
        del v21
        v23 = v22(Tuple6(v4, v5, v6, v7, v8, v9, v10, v11))
        del v22
        v24 = v12 + (<unsigned long long>1)
        v25 = v13 + v23
        return method25(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v24, v25)
    else:
        v27 = v13 * v16
        return v27
cdef void method26(unsigned long long v0, unsigned long long v1, numpy.ndarray[signed long,ndim=1] v2, numpy.ndarray[signed long,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US0 v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1 <= v4
        if v7:
            v8 = v6
        else:
            v8 = v4
        v9 = v2[v8]
        v3[v4] = v9
        method26(v0, v1, v2, v3, v6)
    else:
        pass
cdef double method27(v0, US0 v1, numpy.ndarray[signed long,ndim=1] v2, double v3, double v4, UH0 v5, double v6, double v7, UH0 v8, double v9, double v10):
    cdef object v11
    v11 = v0(Tuple7(v1, v2))
    return v11(Tuple6(v3, v4, v5, v6, v7, v8, v9, v10))
cdef double method28(v0, US4 v1, numpy.ndarray[signed long,ndim=1] v2, v3, double v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11, unsigned long long v12, double v13):
    cdef unsigned long long v14
    cdef double v15
    cdef double v16
    cdef bint v17
    cdef object v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef object v22
    cdef double v23
    cdef unsigned long long v24
    cdef double v25
    cdef double v27
    v14 = len(v2)
    v15 = <double>v14
    v16 = (<double>1.000000) / v15
    v17 = v12 < v14
    if v17:
        v18 = v0(0)
        v19 = v18(v12)
        del v18
        v20 = v19(v1)
        del v19
        v21 = v20(v2)
        del v20
        v22 = v21(v3)
        del v21
        v23 = v22(Tuple6(v4, v5, v6, v7, v8, v9, v10, v11))
        del v22
        v24 = v12 + (<unsigned long long>1)
        v25 = v13 + v23
        return method28(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v24, v25)
    else:
        v27 = v13 * v16
        return v27
cdef double method29(v0, US0 v1, double v2, double v3, UH0 v4, double v5, double v6, UH0 v7, double v8, double v9):
    cdef object v10
    v10 = v0(v1)
    return v10(Tuple6(v2, v3, v4, v5, v6, v7, v8, v9))
cdef numpy.ndarray[signed long,ndim=1] method31(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6):
    cdef bint v7
    cdef bint v9
    v7 = (<signed long>0) < v6
    if v7:
        return v0.v2
    else:
        v9 = (<signed long>0) == v6
        if v9:
            return v0.v0
        else:
            raise Exception("invalid action state")
cdef numpy.ndarray[signed long,ndim=1] method34(Heap0 v0, US0 v1, unsigned char v2, signed long v3, US0 v4, unsigned char v5, signed long v6, signed long v7):
    cdef bint v8
    cdef bint v10
    cdef bint v13
    cdef bint v15
    v8 = (<signed long>0) < v7
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
            v13 = (<signed long>0) == v7
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
cdef signed long method36(US0 v0):
    if v0 == 0: # jack
        return (<signed long>0)
    elif v0 == 1: # king
        return (<signed long>2)
    elif v0 == 2: # queen
        return (<signed long>1)
cdef double method35(v0, v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, double v13, UH0 v14, double v15, double v16, UH0 v17, double v18, double v19):
    cdef signed long v20
    cdef signed long v21
    cdef signed long v22
    cdef bint v23
    cdef bint v25
    cdef signed long v49
    cdef bint v26
    cdef bint v27
    cdef bint v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef bint v34
    cdef signed long v35
    cdef signed long v36
    cdef bint v37
    cdef signed long v40
    cdef bint v38
    cdef bint v41
    cdef bint v42
    cdef bint v43
    cdef bint v50
    cdef unsigned char v54
    cdef signed long v55
    cdef bint v51
    cdef bint v56
    cdef signed long v58
    cdef bint v59
    cdef signed long v61
    cdef signed long v62
    cdef bint v63
    cdef signed long v65
    cdef signed long v66
    cdef US0 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef US0 v70
    cdef unsigned char v71
    cdef signed long v72
    cdef double v73
    cdef US1 v74
    cdef US1 v75
    cdef bint v76
    cdef signed long v78
    cdef bint v79
    cdef signed long v81
    cdef signed long v82
    cdef signed long v84
    cdef signed long v85
    cdef US0 v86
    cdef unsigned char v87
    cdef signed long v88
    cdef US0 v89
    cdef unsigned char v90
    cdef signed long v91
    cdef double v92
    cdef US1 v93
    cdef US1 v94
    cdef signed long v95
    cdef signed long v96
    cdef numpy.ndarray[signed long,ndim=1] v97
    cdef bint v98
    cdef US1 v99
    cdef object v100
    cdef US1 v102
    cdef object v103
    if v11 == 0: # call
        v20 = method36(v4)
        v21 = method36(v8)
        v22 = method36(v5)
        v23 = v21 == v20
        if v23:
            v25 = v22 == v20
        else:
            v25 = 0
        if v25:
            v26 = v21 < v22
            if v26:
                v49 = (<signed long>-1)
            else:
                v27 = v21 > v22
                if v27:
                    v49 = (<signed long>1)
                else:
                    v49 = (<signed long>0)
        else:
            if v23:
                v49 = (<signed long>1)
            else:
                v30 = v22 == v20
                if v30:
                    v49 = (<signed long>-1)
                else:
                    v31 = v21 > v20
                    if v31:
                        v32, v33 = v21, v20
                    else:
                        v32, v33 = v20, v21
                    v34 = v22 > v20
                    if v34:
                        v35, v36 = v22, v20
                    else:
                        v35, v36 = v20, v22
                    v37 = v32 < v35
                    if v37:
                        v40 = (<signed long>-1)
                    else:
                        v38 = v32 > v35
                        if v38:
                            v40 = (<signed long>1)
                        else:
                            v40 = (<signed long>0)
                    v41 = v40 == (<signed long>0)
                    if v41:
                        v42 = v33 < v36
                        if v42:
                            v49 = (<signed long>-1)
                        else:
                            v43 = v33 > v36
                            if v43:
                                v49 = (<signed long>1)
                            else:
                                v49 = (<signed long>0)
                    else:
                        v49 = v40
        v50 = v49 == (<signed long>1)
        if v50:
            v54, v55 = v9, v7
        else:
            v51 = v49 == (<signed long>-1)
            if v51:
                v54, v55 = v6, v7
            else:
                v54, v55 = v9, (<signed long>0)
        v56 = v54 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v9 == (<unsigned char>0)
        if v59:
            v61 = v58
        else:
            v61 = -v58
        v62 = v61 + v7
        v63 = v6 == (<unsigned char>0)
        if v63:
            v65 = v58
        else:
            v65 = -v58
        v66 = v65 + v7
        if v59:
            v67, v68, v69, v70, v71, v72 = v8, v9, v62, v5, v6, v66
        else:
            v67, v68, v69, v70, v71, v72 = v5, v6, v66, v8, v9, v62
        v73 = <double>v58
        v74 = US1_1(v4)
        v1(Tuple5(v12, v13, v67, v68, v69, v70, v71, v72, v74, (<unsigned char>0), v14, v15, v16, v73))
        del v74
        v75 = US1_1(v4)
        v1(Tuple5(v12, v13, v70, v71, v72, v67, v68, v69, v75, (<unsigned char>1), v17, v18, v19, v73))
        del v75
        return v73
    elif v11 == 1: # fold
        v76 = v6 == (<unsigned char>0)
        if v76:
            v78 = v10
        else:
            v78 = -v10
        v79 = v9 == (<unsigned char>0)
        if v79:
            v81 = v78
        else:
            v81 = -v78
        v82 = v81 + v10
        if v76:
            v84 = v78
        else:
            v84 = -v78
        v85 = v84 + v7
        if v79:
            v86, v87, v88, v89, v90, v91 = v8, v9, v82, v5, v6, v85
        else:
            v86, v87, v88, v89, v90, v91 = v5, v6, v85, v8, v9, v82
        v92 = <double>v78
        v93 = US1_1(v4)
        v1(Tuple5(v12, v13, v86, v87, v88, v89, v90, v91, v93, (<unsigned char>0), v14, v15, v16, v92))
        del v93
        v94 = US1_1(v4)
        v1(Tuple5(v12, v13, v89, v90, v91, v86, v87, v88, v94, (<unsigned char>1), v17, v18, v19, v92))
        del v94
        return v92
    elif v11 == 2: # raise
        v95 = v3 - (<signed long>1)
        v96 = v7 + (<signed long>4)
        v97 = method34(v2, v8, v9, v96, v5, v6, v7, v95)
        v98 = v6 == (<unsigned char>0)
        if v98:
            v99 = US1_1(v4)
            v100 = Closure41(v17, v18, v19, v14, v15, v16, v12, v13, v0, v1, v2, v95, v4, v8, v9, v96, v5, v6, v7)
            return v0(Tuple0(v97, v12, v13, v5, v6, v7, v8, v9, v96, v99, (<unsigned char>0), v100, v14, v15, v16, v18, v19))
        else:
            v102 = US1_1(v4)
            v103 = Closure42(v17, v18, v19, v14, v15, v16, v12, v13, v0, v1, v2, v95, v4, v8, v9, v96, v5, v6, v7)
            return v0(Tuple0(v97, v12, v13, v5, v6, v7, v8, v9, v96, v102, (<unsigned char>1), v103, v17, v18, v19, v15, v16))
cdef double method33(v0, v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, US3 v10, double v11, double v12, UH0 v13, double v14, double v15, UH0 v16, double v17, double v18):
    cdef signed long v19
    cdef numpy.ndarray[signed long,ndim=1] v20
    cdef bint v21
    cdef US1 v22
    cdef object v23
    cdef US1 v25
    cdef object v26
    cdef object v29
    cdef signed long v31
    cdef signed long v32
    cdef numpy.ndarray[signed long,ndim=1] v33
    cdef bint v34
    cdef US1 v35
    cdef object v36
    cdef US1 v38
    cdef object v39
    if v10 == 0: # call
        v19 = (<signed long>2)
        v20 = method34(v2, v6, v7, v8, v3, v4, v5, v19)
        v21 = v4 == (<unsigned char>0)
        if v21:
            v22 = US1_1(v9)
            v23 = Closure41(v16, v17, v18, v13, v14, v15, v11, v12, v0, v1, v2, v19, v9, v6, v7, v8, v3, v4, v5)
            return v0(Tuple0(v20, v11, v12, v3, v4, v5, v6, v7, v8, v22, (<unsigned char>0), v23, v13, v14, v15, v17, v18))
        else:
            v25 = US1_1(v9)
            v26 = Closure42(v16, v17, v18, v13, v14, v15, v11, v12, v0, v1, v2, v19, v9, v6, v7, v8, v3, v4, v5)
            return v0(Tuple0(v20, v11, v12, v3, v4, v5, v6, v7, v8, v25, (<unsigned char>1), v26, v16, v17, v18, v14, v15))
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v31 = (<signed long>1)
        v32 = v5 + (<signed long>4)
        v33 = method34(v2, v6, v7, v32, v3, v4, v5, v31)
        v34 = v4 == (<unsigned char>0)
        if v34:
            v35 = US1_1(v9)
            v36 = Closure41(v16, v17, v18, v13, v14, v15, v11, v12, v0, v1, v2, v31, v9, v6, v7, v32, v3, v4, v5)
            return v0(Tuple0(v33, v11, v12, v3, v4, v5, v6, v7, v32, v35, (<unsigned char>0), v36, v13, v14, v15, v17, v18))
        else:
            v38 = US1_1(v9)
            v39 = Closure42(v16, v17, v18, v13, v14, v15, v11, v12, v0, v1, v2, v31, v9, v6, v7, v32, v3, v4, v5)
            return v0(Tuple0(v33, v11, v12, v3, v4, v5, v6, v7, v32, v38, (<unsigned char>1), v39, v16, v17, v18, v14, v15))
cdef double method37(v0, v1, Heap0 v2, v3, numpy.ndarray[signed long,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11, US3 v12, double v13, double v14, UH0 v15, double v16, double v17, UH0 v18, double v19, double v20):
    cdef bint v21
    cdef US0 v22
    cdef unsigned char v23
    cdef signed long v24
    cdef US0 v25
    cdef unsigned char v26
    cdef signed long v27
    cdef US4 v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef bint v34
    cdef signed long v36
    cdef bint v37
    cdef signed long v39
    cdef signed long v40
    cdef signed long v42
    cdef signed long v43
    cdef US0 v44
    cdef unsigned char v45
    cdef signed long v46
    cdef US0 v47
    cdef unsigned char v48
    cdef signed long v49
    cdef double v50
    cdef US1 v51
    cdef US1 v52
    cdef signed long v53
    cdef signed long v54
    cdef numpy.ndarray[signed long,ndim=1] v55
    cdef bint v56
    cdef US1 v57
    cdef object v58
    cdef US1 v60
    cdef object v61
    if v12 == 0: # call
        v21 = v10 == (<unsigned char>0)
        if v21:
            v22, v23, v24, v25, v26, v27 = v9, v10, v8, v6, v7, v8
        else:
            v22, v23, v24, v25, v26, v27 = v6, v7, v8, v9, v10, v8
        v28 = US4_0()
        v29 = v3(v28)
        del v28
        v30 = v29(v4)
        del v29
        v31 = Closure38(v0, v1, v2, v25, v26, v27, v22, v23, v24)
        v32 = v30(v31)
        del v30; del v31
        return v32(Tuple6(v13, v14, v15, v16, v17, v18, v19, v20))
    elif v12 == 1: # fold
        v34 = v7 == (<unsigned char>0)
        if v34:
            v36 = v11
        else:
            v36 = -v11
        v37 = v10 == (<unsigned char>0)
        if v37:
            v39 = v36
        else:
            v39 = -v36
        v40 = v39 + v11
        if v34:
            v42 = v36
        else:
            v42 = -v36
        v43 = v42 + v8
        if v37:
            v44, v45, v46, v47, v48, v49 = v9, v10, v40, v6, v7, v43
        else:
            v44, v45, v46, v47, v48, v49 = v6, v7, v43, v9, v10, v40
        v50 = <double>v36
        v51 = US1_0()
        v1(Tuple5(v13, v14, v44, v45, v46, v47, v48, v49, v51, (<unsigned char>0), v15, v16, v17, v50))
        del v51
        v52 = US1_0()
        v1(Tuple5(v13, v14, v47, v48, v49, v44, v45, v46, v52, (<unsigned char>1), v18, v19, v20, v50))
        del v52
        return v50
    elif v12 == 2: # raise
        v53 = v5 - (<signed long>1)
        v54 = v8 + (<signed long>2)
        v55 = method34(v2, v9, v10, v54, v6, v7, v8, v53)
        v56 = v7 == (<unsigned char>0)
        if v56:
            v57 = US1_0()
            v58 = Closure44(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v4, v53, v9, v10, v54, v6, v7, v8)
            return v0(Tuple0(v55, v13, v14, v6, v7, v8, v9, v10, v54, v57, (<unsigned char>0), v58, v15, v16, v17, v19, v20))
        else:
            v60 = US1_0()
            v61 = Closure45(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v4, v53, v9, v10, v54, v6, v7, v8)
            return v0(Tuple0(v55, v13, v14, v6, v7, v8, v9, v10, v54, v60, (<unsigned char>1), v61, v18, v19, v20, v16, v17))
cdef double method32(v0, v1, Heap0 v2, v3, numpy.ndarray[signed long,ndim=1] v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, US3 v11, double v12, double v13, UH0 v14, double v15, double v16, UH0 v17, double v18, double v19):
    cdef bint v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef US0 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef US4 v27
    cdef object v28
    cdef object v29
    cdef object v30
    cdef object v31
    cdef bint v33
    cdef signed long v35
    cdef bint v36
    cdef signed long v38
    cdef signed long v39
    cdef signed long v41
    cdef signed long v42
    cdef US0 v43
    cdef unsigned char v44
    cdef signed long v45
    cdef US0 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef double v49
    cdef US1 v50
    cdef US1 v51
    cdef signed long v52
    cdef signed long v53
    cdef numpy.ndarray[signed long,ndim=1] v54
    cdef bint v55
    cdef US1 v56
    cdef object v57
    cdef US1 v59
    cdef object v60
    if v11 == 0: # call
        v20 = v10 == (<unsigned char>0)
        if v20:
            v21, v22, v23, v24, v25, v26 = v9, v10, v8, v6, v7, v8
        else:
            v21, v22, v23, v24, v25, v26 = v6, v7, v8, v9, v10, v8
        v27 = US4_0()
        v28 = v3(v27)
        del v27
        v29 = v28(v4)
        del v28
        v30 = Closure38(v0, v1, v2, v24, v25, v26, v21, v22, v23)
        v31 = v29(v30)
        del v29; del v30
        return v31(Tuple6(v12, v13, v14, v15, v16, v17, v18, v19))
    elif v11 == 1: # fold
        v33 = v7 == (<unsigned char>0)
        if v33:
            v35 = v8
        else:
            v35 = -v8
        v36 = v10 == (<unsigned char>0)
        if v36:
            v38 = v35
        else:
            v38 = -v35
        v39 = v38 + v8
        if v33:
            v41 = v35
        else:
            v41 = -v35
        v42 = v41 + v8
        if v36:
            v43, v44, v45, v46, v47, v48 = v9, v10, v39, v6, v7, v42
        else:
            v43, v44, v45, v46, v47, v48 = v6, v7, v42, v9, v10, v39
        v49 = <double>v35
        v50 = US1_0()
        v1(Tuple5(v12, v13, v43, v44, v45, v46, v47, v48, v50, (<unsigned char>0), v14, v15, v16, v49))
        del v50
        v51 = US1_0()
        v1(Tuple5(v12, v13, v46, v47, v48, v43, v44, v45, v51, (<unsigned char>1), v17, v18, v19, v49))
        del v51
        return v49
    elif v11 == 2: # raise
        v52 = v5 - (<signed long>1)
        v53 = v8 + (<signed long>2)
        v54 = method34(v2, v9, v10, v53, v6, v7, v8, v52)
        v55 = v7 == (<unsigned char>0)
        if v55:
            v56 = US1_0()
            v57 = Closure44(v17, v18, v19, v14, v15, v16, v12, v13, v0, v1, v2, v3, v4, v52, v9, v10, v53, v6, v7, v8)
            return v0(Tuple0(v54, v12, v13, v6, v7, v8, v9, v10, v53, v56, (<unsigned char>0), v57, v14, v15, v16, v18, v19))
        else:
            v59 = US1_0()
            v60 = Closure45(v17, v18, v19, v14, v15, v16, v12, v13, v0, v1, v2, v3, v4, v52, v9, v10, v53, v6, v7, v8)
            return v0(Tuple0(v54, v12, v13, v6, v7, v8, v9, v10, v53, v59, (<unsigned char>1), v60, v17, v18, v19, v15, v16))
cdef double method30(v0, v1, US0 v2, US0 v3, Heap0 v4, v5, numpy.ndarray[signed long,ndim=1] v6, US3 v7, double v8, double v9, UH0 v10, double v11, double v12, UH0 v13, double v14, double v15):
    cdef signed long v16
    cdef unsigned char v17
    cdef signed long v18
    cdef unsigned char v19
    cdef numpy.ndarray[signed long,ndim=1] v20
    cdef bint v21
    cdef US1 v22
    cdef object v23
    cdef US1 v25
    cdef object v26
    cdef object v29
    cdef signed long v31
    cdef unsigned char v32
    cdef signed long v33
    cdef unsigned char v34
    cdef signed long v35
    cdef numpy.ndarray[signed long,ndim=1] v36
    cdef bint v37
    cdef US1 v38
    cdef object v39
    cdef US1 v41
    cdef object v42
    if v7 == 0: # call
        v16 = (<signed long>2)
        v17 = (<unsigned char>1)
        v18 = (<signed long>1)
        v19 = (<unsigned char>0)
        v20 = method31(v4, v2, v19, v18, v3, v17, v16)
        v21 = v17 == (<unsigned char>0)
        if v21:
            v22 = US1_0()
            v23 = Closure37(v13, v14, v15, v10, v11, v12, v8, v9, v0, v1, v4, v5, v6, v16, v2, v19, v18, v3, v17)
            return v0(Tuple0(v20, v8, v9, v3, v17, v18, v2, v19, v18, v22, (<unsigned char>0), v23, v10, v11, v12, v14, v15))
        else:
            v25 = US1_0()
            v26 = Closure46(v13, v14, v15, v10, v11, v12, v8, v9, v0, v1, v4, v5, v6, v16, v2, v19, v18, v3, v17)
            return v0(Tuple0(v20, v8, v9, v3, v17, v18, v2, v19, v18, v25, (<unsigned char>1), v26, v13, v14, v15, v11, v12))
    elif v7 == 1: # fold
        raise Exception("impossible")
    elif v7 == 2: # raise
        v31 = (<signed long>1)
        v32 = (<unsigned char>1)
        v33 = (<signed long>1)
        v34 = (<unsigned char>0)
        v35 = (<signed long>3)
        v36 = method34(v4, v2, v34, v35, v3, v32, v33, v31)
        v37 = v32 == (<unsigned char>0)
        if v37:
            v38 = US1_0()
            v39 = Closure44(v13, v14, v15, v10, v11, v12, v8, v9, v0, v1, v4, v5, v6, v31, v2, v34, v35, v3, v32, v33)
            return v0(Tuple0(v36, v8, v9, v3, v32, v33, v2, v34, v35, v38, (<unsigned char>0), v39, v10, v11, v12, v14, v15))
        else:
            v41 = US1_0()
            v42 = Closure45(v13, v14, v15, v10, v11, v12, v8, v9, v0, v1, v4, v5, v6, v31, v2, v34, v35, v3, v32, v33)
            return v0(Tuple0(v36, v8, v9, v3, v32, v33, v2, v34, v35, v41, (<unsigned char>1), v42, v13, v14, v15, v11, v12))
cdef double method24(bint v0, v1, v2):
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v10
    cdef object v11
    cdef object v12
    cdef US3 v13
    cdef US3 v14
    cdef numpy.ndarray[signed long,ndim=1] v15
    cdef US3 v16
    cdef US3 v17
    cdef US3 v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef US3 v20
    cdef US3 v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef US3 v23
    cdef numpy.ndarray[signed long,ndim=1] v24
    cdef Heap0 v25
    cdef US0 v26
    cdef US0 v27
    cdef US0 v28
    cdef US0 v29
    cdef US0 v30
    cdef US0 v31
    cdef numpy.ndarray[signed long,ndim=1] v32
    cdef US4 v33
    cdef object v34
    cdef object v35
    cdef object v36
    cdef object v37
    cdef UH0 v38
    cdef double v39
    cdef double v40
    cdef UH0 v41
    cdef double v42
    cdef double v43
    if v0:
        v5 = Closure3()
    else:
        v5 = Closure6()
    v6 = Closure11()
    v7 = v5(v6)
    del v5; del v6
    if v0:
        v10 = Closure19()
    else:
        v10 = Closure22()
    v11 = Closure27()
    v12 = v10(v11)
    del v10; del v11
    v13 = 0
    v14 = 2
    v15 = numpy.empty(2,dtype=numpy.int32)
    v15[0] = v13; v15[1] = v14
    v16 = 1
    v17 = 0
    v18 = 2
    v19 = numpy.empty(3,dtype=numpy.int32)
    v19[0] = v16; v19[1] = v17; v19[2] = v18
    v20 = 1
    v21 = 0
    v22 = numpy.empty(2,dtype=numpy.int32)
    v22[0] = v20; v22[1] = v21
    v23 = 0
    v24 = numpy.empty(1,dtype=numpy.int32)
    v24[0] = v23
    v25 = Heap0(v24, v19, v15, v22)
    del v15; del v19; del v22; del v24
    v26 = 1
    v27 = 2
    v28 = 0
    v29 = 1
    v30 = 2
    v31 = 0
    v32 = numpy.empty(6,dtype=numpy.int32)
    v32[0] = v26; v32[1] = v27; v32[2] = v28; v32[3] = v29; v32[4] = v30; v32[5] = v31
    v33 = US4_1((<unsigned char>0))
    v34 = v7(v33)
    del v33
    v35 = v34(v32)
    del v32; del v34
    v36 = Closure33(v12, v1, v2, v7, v25)
    del v7; del v12; del v25
    v37 = v35(v36)
    del v35; del v36
    v38 = UH0_1()
    v39 = (<double>0.000000)
    v40 = (<double>0.000000)
    v41 = UH0_1()
    v42 = (<double>0.000000)
    v43 = (<double>0.000000)
    return v37(Tuple6((<double>0.000000), (<double>0.000000), v38, v39, v40, v41, v42, v43))
cdef void method4(Mut0 v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef bint v4
    cdef object v5
    cdef object v6
    cdef double v7
    v2 = v1 < (<unsigned long long>2000)
    if v2:
        v3 = v1 + (<unsigned long long>1)
        v4 = 1
        v5 = Closure1(v0)
        v6 = Closure2()
        v7 = method24(v4, v5, v6)
        del v5; del v6
        method4(v0, v3)
    else:
        pass
cdef void method40(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v1[v2] = (<double>0.000000)
        method40(v0, v1, v4)
    else:
        pass
cdef void method42(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    cdef list v5
    v3 = v2 < v0
    if v3:
        v4 = v2 + (<unsigned long long>1)
        v5 = [None]*(<unsigned long long>0)
        v1[v2] = v5
        del v5
        method42(v0, v1, v4)
    else:
        pass
cdef void method44(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef Mut2 v9
    cdef Tuple8 tmp8
    cdef unsigned long long v10
    cdef list v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        tmp8 = v3[v4]
        v7, v8, v9 = tmp8.v0, tmp8.v1, tmp8.v2
        del tmp8
        v10 = v7 % v1
        v11 = v2[v10]
        v11.append(Tuple8(v7, v8, v9))
        del v8; del v9; del v11
        method44(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method43(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        method44(v8, v2, v3, v7, v9)
        del v7
        method43(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method41(Mut1 v0):
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
    v3 = v2 * (<unsigned long long>3)
    v4 = v3 // (<unsigned long long>2)
    v5 = v4 + (<unsigned long long>3)
    v6 = v5 <= v2
    if v6:
        raise Exception("The table length cannot be increased.")
    else:
        pass
    v7 = numpy.empty(v5,dtype=object)
    v8 = (<unsigned long long>0)
    method42(v5, v7, v8)
    v9 = (<unsigned long long>0)
    method43(v2, v1, v5, v7, v9)
    del v1
    v0.v1 = v7
    del v7
    v10 = v0.v0
    v11 = v10 + (<unsigned long long>2)
    v0.v0 = v11
cdef Mut2 method39(Mut1 v0, UH0 v1, numpy.ndarray[signed long,ndim=1] v2, unsigned long long v3, list v4, unsigned long long v5):
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef UH0 v9
    cdef Mut2 v10
    cdef Tuple8 tmp7
    cdef bint v11
    cdef bint v13
    cdef unsigned long long v14
    cdef unsigned long long v17
    cdef numpy.ndarray[double,ndim=1] v18
    cdef unsigned long long v19
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef Mut2 v22
    cdef unsigned long long v23
    cdef unsigned long long v24
    cdef unsigned long long v25
    cdef unsigned long long v26
    cdef numpy.ndarray[object,ndim=1] v27
    cdef unsigned long long v28
    cdef unsigned long long v29
    cdef bint v30
    v6 = len(v4)
    v7 = v5 < v6
    if v7:
        tmp7 = v4[v5]
        v8, v9, v10 = tmp7.v0, tmp7.v1, tmp7.v2
        del tmp7
        v11 = v3 == v8
        if v11:
            v13 = method9(v9, v1)
        else:
            v13 = 0
        del v9
        if v13:
            return v10
        else:
            del v10
            v14 = v5 + (<unsigned long long>1)
            return method39(v0, v1, v2, v3, v4, v14)
    else:
        v17 = len(v2)
        v18 = numpy.empty(v17,dtype=numpy.float64)
        v19 = (<unsigned long long>0)
        method40(v17, v18, v19)
        v20 = numpy.empty(v17,dtype=numpy.float64)
        v21 = (<unsigned long long>0)
        method40(v17, v20, v21)
        v22 = Mut2(v2, v20, v18, (<unsigned long long>1))
        del v18; del v20
        v4.append(Tuple8(v3, v1, v22))
        v23 = v0.v2
        v24 = v23 + (<unsigned long long>1)
        v0.v2 = v24
        v25 = v0.v2
        v26 = v0.v0
        v27 = v0.v1
        v28 = len(v27)
        del v27
        v29 = v26 * v28
        v30 = v25 >= v29
        if v30:
            method41(v0)
        else:
            pass
        return v22
cdef Mut2 method38(Mut1 v0, numpy.ndarray[signed long,ndim=1] v1, UH0 v2):
    cdef unsigned long long v4
    cdef numpy.ndarray[object,ndim=1] v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef list v8
    cdef unsigned long long v9
    v4 = method7(v2)
    v5 = v0.v1
    v6 = len(v5)
    v7 = v4 % v6
    v8 = v5[v7]
    del v5
    v9 = (<unsigned long long>0)
    return method39(v0, v2, v1, v4, v8, v9)
cdef double method46(unsigned long long v0, numpy.ndarray[double,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3, double v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef double v7
    cdef bint v8
    cdef double v9
    cdef double v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        v7 = v1[v3]
        v8 = (<double>0.000000) >= v7
        if v8:
            v9 = (<double>0.000000)
        else:
            v9 = v7
        v10 = v9 + v4
        v2[v3] = v9
        return method46(v0, v1, v2, v6, v10)
    else:
        return v4
cdef void method47(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v2[v3] = v1
        method47(v0, v1, v2, v5)
    else:
        pass
cdef void method48(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef double v6
    cdef double v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        v6 = v2[v3]
        v7 = v6 / v1
        v2[v3] = v7
        method48(v0, v1, v2, v5)
    else:
        pass
cdef numpy.ndarray[double,ndim=1] method45(numpy.ndarray[double,ndim=1] v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[double,ndim=1] v2
    cdef unsigned long long v3
    cdef double v4
    cdef double v5
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    v1 = len(v0)
    v2 = numpy.empty(v1,dtype=numpy.float64)
    v3 = (<unsigned long long>0)
    v4 = (<double>0.000000)
    v5 = method46(v1, v0, v2, v3, v4)
    v6 = v5 == (<double>0.000000)
    if v6:
        v7 = len(v2)
        v8 = <double>v7
        v9 = (<double>1.000000) / v8
        v10 = (<unsigned long long>0)
        method47(v7, v9, v2, v10)
    else:
        v11 = len(v2)
        v12 = (<unsigned long long>0)
        method48(v11, v5, v2, v12)
    return v2
cdef double method49(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[signed long,ndim=1] v4, numpy.ndarray[double,ndim=1] v5, unsigned long long v6, double v7):
    cdef bint v8
    cdef unsigned long long v9
    cdef double v10
    cdef US3 v11
    cdef bint v12
    cdef bint v14
    cdef double v17
    cdef double v15
    cdef double v18
    cdef double v19
    v8 = v6 < v0
    if v8:
        v9 = v6 + (<unsigned long long>1)
        v10 = v3[v6]
        v11 = v4[v6]
        v12 = v10 == (<double>0.000000)
        if v12:
            v14 = v2 == (<double>0.000000)
        else:
            v14 = 0
        if v14:
            v17 = (<double>0.000000)
        else:
            v15 = libc.math.log(v10)
            v17 = v1(Tuple4(v15, (<double>0.000000), v11))
        v18 = v17 * v10
        v19 = v7 + v18
        v5[v6] = v17
        return method49(v0, v1, v2, v3, v4, v5, v9, v19)
    else:
        return v7
cdef void method51(unsigned long long v0, double v1, double v2, numpy.ndarray[double,ndim=1] v3, unsigned char v4, double v5, numpy.ndarray[double,ndim=1] v6, unsigned long long v7):
    cdef bint v8
    cdef unsigned long long v9
    cdef double v10
    cdef double v11
    cdef double v12
    cdef double v13
    cdef bint v14
    cdef double v16
    cdef double v17
    cdef double v18
    cdef bint v19
    cdef double v20
    v8 = v7 < v0
    if v8:
        v9 = v7 + (<unsigned long long>1)
        v10 = v6[v7]
        v11 = v5 * v1
        v12 = v3[v7]
        v13 = v12 - v2
        v14 = v4 == (<unsigned char>0)
        if v14:
            v16 = v13
        else:
            v16 = -v13
        v17 = v11 * v16
        v18 = v10 + v17
        v19 = (<double>0.000000) >= v18
        if v19:
            v20 = (<double>0.000000)
        else:
            v20 = v18
        v6[v7] = v20
        method51(v0, v1, v2, v3, v4, v5, v6, v9)
    else:
        pass
cdef void method52(unsigned long long v0, double v1, numpy.ndarray[double,ndim=1] v2, double v3, numpy.ndarray[double,ndim=1] v4, unsigned long long v5):
    cdef bint v6
    cdef unsigned long long v7
    cdef double v8
    cdef double v9
    cdef double v10
    cdef double v11
    cdef double v12
    v6 = v5 < v0
    if v6:
        v7 = v5 + (<unsigned long long>1)
        v8 = v4[v5]
        v9 = v1 * v3
        v10 = v2[v5]
        v11 = v9 * v10
        v12 = v8 + v11
        v4[v5] = v12
        method52(v0, v1, v2, v3, v4, v7)
    else:
        pass
cdef double method50(UH0 v0, double v1, double v2, Mut2 v3, double v4, double v5, numpy.ndarray[double,ndim=1] v6, unsigned char v7):
    cdef unsigned long long v8
    cdef double v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef numpy.ndarray[double,ndim=1] v13
    cdef numpy.ndarray[double,ndim=1] v14
    cdef double v15
    cdef double v16
    cdef numpy.ndarray[double,ndim=1] v17
    cdef unsigned long long v18
    cdef unsigned long long v19
    cdef unsigned long long v20
    cdef unsigned long long v21
    v8 = v3.v3
    v9 = <double>v8
    v10 = v3.v2
    v11 = len(v10)
    v12 = (<unsigned long long>0)
    method51(v11, v4, v5, v6, v7, v9, v10, v12)
    del v10
    v13 = v3.v2
    v14 = method45(v13)
    del v13
    v15 = v1 - v2
    v16 = libc.math.exp(v15)
    v17 = v3.v1
    v18 = len(v17)
    v19 = (<unsigned long long>0)
    method52(v18, v9, v14, v16, v17, v19)
    del v14; del v17
    v20 = v3.v3
    v21 = v20 + (<unsigned long long>1)
    v3.v3 = v21
    return v5
cdef double method53(unsigned long long v0, v1, double v2, double v3, numpy.ndarray[double,ndim=1] v4, numpy.ndarray[signed long,ndim=1] v5, unsigned long long v6, double v7):
    cdef bint v8
    cdef unsigned long long v9
    cdef double v10
    cdef US3 v11
    cdef bint v12
    cdef bint v15
    cdef double v13
    cdef double v18
    cdef double v16
    cdef double v19
    cdef double v20
    v8 = v6 < v0
    if v8:
        v9 = v6 + (<unsigned long long>1)
        v10 = v4[v6]
        v11 = v5[v6]
        v12 = v10 == (<double>0.000000)
        if v12:
            v13 = v2 - v3
            v15 = v13 == (<double>float('-inf'))
        else:
            v15 = 0
        if v15:
            v18 = (<double>0.000000)
        else:
            v16 = libc.math.log(v10)
            v18 = v1(Tuple4(v16, v16, v11))
        v19 = v18 * v10
        v20 = v7 + v19
        return method53(v0, v1, v2, v3, v4, v5, v9, v20)
    else:
        return v7
cdef double method54(unsigned long long v0, v1, double v2, numpy.ndarray[double,ndim=1] v3, numpy.ndarray[signed long,ndim=1] v4, unsigned long long v5, double v6):
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
        v8 = v5 + (<unsigned long long>1)
        v9 = v3[v5]
        v10 = v4[v5]
        v11 = v9 == (<double>0.000000)
        if v11:
            v13 = v2 == (<double>0.000000)
        else:
            v13 = 0
        if v13:
            v16 = (<double>0.000000)
        else:
            v14 = libc.math.log(v9)
            v16 = v1(Tuple4(v14, (<double>0.000000), v10))
        v17 = v16 * v9
        v18 = v6 + v17
        return method54(v0, v1, v2, v3, v4, v8, v18)
    else:
        return v6
cdef double method59(v0, v1, v2, v3, Heap0 v4, signed long v5, US0 v6, US0 v7, unsigned char v8, signed long v9, US0 v10, unsigned char v11, signed long v12, US3 v13, double v14, double v15, UH0 v16, double v17, double v18, UH0 v19, double v20, double v21):
    cdef signed long v22
    cdef signed long v23
    cdef signed long v24
    cdef bint v25
    cdef bint v27
    cdef signed long v51
    cdef bint v28
    cdef bint v29
    cdef bint v32
    cdef bint v33
    cdef signed long v34
    cdef signed long v35
    cdef bint v36
    cdef signed long v37
    cdef signed long v38
    cdef bint v39
    cdef signed long v42
    cdef bint v40
    cdef bint v43
    cdef bint v44
    cdef bint v45
    cdef bint v52
    cdef unsigned char v56
    cdef signed long v57
    cdef bint v53
    cdef bint v58
    cdef signed long v60
    cdef bint v61
    cdef signed long v63
    cdef signed long v64
    cdef bint v65
    cdef signed long v67
    cdef signed long v68
    cdef US0 v69
    cdef unsigned char v70
    cdef signed long v71
    cdef US0 v72
    cdef unsigned char v73
    cdef signed long v74
    cdef double v75
    cdef US1 v76
    cdef US1 v77
    cdef bint v78
    cdef signed long v80
    cdef bint v81
    cdef signed long v83
    cdef signed long v84
    cdef signed long v86
    cdef signed long v87
    cdef US0 v88
    cdef unsigned char v89
    cdef signed long v90
    cdef US0 v91
    cdef unsigned char v92
    cdef signed long v93
    cdef double v94
    cdef US1 v95
    cdef US1 v96
    cdef signed long v97
    cdef signed long v98
    cdef numpy.ndarray[signed long,ndim=1] v99
    cdef bint v100
    cdef US1 v101
    cdef object v102
    cdef US1 v104
    cdef object v105
    if v13 == 0: # call
        v22 = method36(v6)
        v23 = method36(v10)
        v24 = method36(v7)
        v25 = v23 == v22
        if v25:
            v27 = v24 == v22
        else:
            v27 = 0
        if v27:
            v28 = v23 < v24
            if v28:
                v51 = (<signed long>-1)
            else:
                v29 = v23 > v24
                if v29:
                    v51 = (<signed long>1)
                else:
                    v51 = (<signed long>0)
        else:
            if v25:
                v51 = (<signed long>1)
            else:
                v32 = v24 == v22
                if v32:
                    v51 = (<signed long>-1)
                else:
                    v33 = v23 > v22
                    if v33:
                        v34, v35 = v23, v22
                    else:
                        v34, v35 = v22, v23
                    v36 = v24 > v22
                    if v36:
                        v37, v38 = v24, v22
                    else:
                        v37, v38 = v22, v24
                    v39 = v34 < v37
                    if v39:
                        v42 = (<signed long>-1)
                    else:
                        v40 = v34 > v37
                        if v40:
                            v42 = (<signed long>1)
                        else:
                            v42 = (<signed long>0)
                    v43 = v42 == (<signed long>0)
                    if v43:
                        v44 = v35 < v38
                        if v44:
                            v51 = (<signed long>-1)
                        else:
                            v45 = v35 > v38
                            if v45:
                                v51 = (<signed long>1)
                            else:
                                v51 = (<signed long>0)
                    else:
                        v51 = v42
        v52 = v51 == (<signed long>1)
        if v52:
            v56, v57 = v11, v9
        else:
            v53 = v51 == (<signed long>-1)
            if v53:
                v56, v57 = v8, v9
            else:
                v56, v57 = v11, (<signed long>0)
        v58 = v56 == (<unsigned char>0)
        if v58:
            v60 = v57
        else:
            v60 = -v57
        v61 = v11 == (<unsigned char>0)
        if v61:
            v63 = v60
        else:
            v63 = -v60
        v64 = v63 + v9
        v65 = v8 == (<unsigned char>0)
        if v65:
            v67 = v60
        else:
            v67 = -v60
        v68 = v67 + v9
        if v61:
            v69, v70, v71, v72, v73, v74 = v10, v11, v64, v7, v8, v68
        else:
            v69, v70, v71, v72, v73, v74 = v7, v8, v68, v10, v11, v64
        v75 = <double>v60
        v76 = US1_1(v6)
        v3(Tuple5(v14, v15, v69, v70, v71, v72, v73, v74, v76, (<unsigned char>0), v16, v17, v18, v75))
        del v76
        v77 = US1_1(v6)
        v1(Tuple5(v14, v15, v72, v73, v74, v69, v70, v71, v77, (<unsigned char>1), v19, v20, v21, v75))
        del v77
        return v75
    elif v13 == 1: # fold
        v78 = v8 == (<unsigned char>0)
        if v78:
            v80 = v12
        else:
            v80 = -v12
        v81 = v11 == (<unsigned char>0)
        if v81:
            v83 = v80
        else:
            v83 = -v80
        v84 = v83 + v12
        if v78:
            v86 = v80
        else:
            v86 = -v80
        v87 = v86 + v9
        if v81:
            v88, v89, v90, v91, v92, v93 = v10, v11, v84, v7, v8, v87
        else:
            v88, v89, v90, v91, v92, v93 = v7, v8, v87, v10, v11, v84
        v94 = <double>v80
        v95 = US1_1(v6)
        v3(Tuple5(v14, v15, v88, v89, v90, v91, v92, v93, v95, (<unsigned char>0), v16, v17, v18, v94))
        del v95
        v96 = US1_1(v6)
        v1(Tuple5(v14, v15, v91, v92, v93, v88, v89, v90, v96, (<unsigned char>1), v19, v20, v21, v94))
        del v96
        return v94
    elif v13 == 2: # raise
        v97 = v5 - (<signed long>1)
        v98 = v9 + (<signed long>4)
        v99 = method34(v4, v10, v11, v98, v7, v8, v9, v97)
        v100 = v8 == (<unsigned char>0)
        if v100:
            v101 = US1_1(v6)
            v102 = Closure59(v19, v20, v21, v16, v17, v18, v14, v15, v0, v1, v2, v3, v4, v97, v6, v10, v11, v98, v7, v8, v9)
            return v2(Tuple0(v99, v14, v15, v7, v8, v9, v10, v11, v98, v101, (<unsigned char>0), v102, v16, v17, v18, v20, v21))
        else:
            v104 = US1_1(v6)
            v105 = Closure60(v19, v20, v21, v16, v17, v18, v14, v15, v0, v1, v2, v3, v4, v97, v6, v10, v11, v98, v7, v8, v9)
            return v0(Tuple0(v99, v14, v15, v7, v8, v9, v10, v11, v98, v104, (<unsigned char>1), v105, v19, v20, v21, v17, v18))
cdef double method58(v0, v1, v2, v3, Heap0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US0 v11, US3 v12, double v13, double v14, UH0 v15, double v16, double v17, UH0 v18, double v19, double v20):
    cdef signed long v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef bint v23
    cdef US1 v24
    cdef object v25
    cdef US1 v27
    cdef object v28
    cdef object v31
    cdef signed long v33
    cdef signed long v34
    cdef numpy.ndarray[signed long,ndim=1] v35
    cdef bint v36
    cdef US1 v37
    cdef object v38
    cdef US1 v40
    cdef object v41
    if v12 == 0: # call
        v21 = (<signed long>2)
        v22 = method34(v4, v8, v9, v10, v5, v6, v7, v21)
        v23 = v6 == (<unsigned char>0)
        if v23:
            v24 = US1_1(v11)
            v25 = Closure59(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v4, v21, v11, v8, v9, v10, v5, v6, v7)
            return v2(Tuple0(v22, v13, v14, v5, v6, v7, v8, v9, v10, v24, (<unsigned char>0), v25, v15, v16, v17, v19, v20))
        else:
            v27 = US1_1(v11)
            v28 = Closure60(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v4, v21, v11, v8, v9, v10, v5, v6, v7)
            return v0(Tuple0(v22, v13, v14, v5, v6, v7, v8, v9, v10, v27, (<unsigned char>1), v28, v18, v19, v20, v16, v17))
    elif v12 == 1: # fold
        raise Exception("impossible")
    elif v12 == 2: # raise
        v33 = (<signed long>1)
        v34 = v7 + (<signed long>4)
        v35 = method34(v4, v8, v9, v34, v5, v6, v7, v33)
        v36 = v6 == (<unsigned char>0)
        if v36:
            v37 = US1_1(v11)
            v38 = Closure59(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v4, v33, v11, v8, v9, v34, v5, v6, v7)
            return v2(Tuple0(v35, v13, v14, v5, v6, v7, v8, v9, v34, v37, (<unsigned char>0), v38, v15, v16, v17, v19, v20))
        else:
            v40 = US1_1(v11)
            v41 = Closure60(v18, v19, v20, v15, v16, v17, v13, v14, v0, v1, v2, v3, v4, v33, v11, v8, v9, v34, v5, v6, v7)
            return v0(Tuple0(v35, v13, v14, v5, v6, v7, v8, v9, v34, v40, (<unsigned char>1), v41, v18, v19, v20, v16, v17))
cdef double method60(v0, v1, v2, v3, Heap0 v4, v5, numpy.ndarray[signed long,ndim=1] v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US0 v11, unsigned char v12, signed long v13, US3 v14, double v15, double v16, UH0 v17, double v18, double v19, UH0 v20, double v21, double v22):
    cdef bint v23
    cdef US0 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef US0 v27
    cdef unsigned char v28
    cdef signed long v29
    cdef US4 v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef object v34
    cdef bint v36
    cdef signed long v38
    cdef bint v39
    cdef signed long v41
    cdef signed long v42
    cdef signed long v44
    cdef signed long v45
    cdef US0 v46
    cdef unsigned char v47
    cdef signed long v48
    cdef US0 v49
    cdef unsigned char v50
    cdef signed long v51
    cdef double v52
    cdef US1 v53
    cdef US1 v54
    cdef signed long v55
    cdef signed long v56
    cdef numpy.ndarray[signed long,ndim=1] v57
    cdef bint v58
    cdef US1 v59
    cdef object v60
    cdef US1 v62
    cdef object v63
    if v14 == 0: # call
        v23 = v12 == (<unsigned char>0)
        if v23:
            v24, v25, v26, v27, v28, v29 = v11, v12, v10, v8, v9, v10
        else:
            v24, v25, v26, v27, v28, v29 = v8, v9, v10, v11, v12, v10
        v30 = US4_0()
        v31 = v5(v30)
        del v30
        v32 = v31(v6)
        del v31
        v33 = Closure56(v0, v1, v2, v3, v4, v27, v28, v29, v24, v25, v26)
        v34 = v32(v33)
        del v32; del v33
        return v34(Tuple6(v15, v16, v17, v18, v19, v20, v21, v22))
    elif v14 == 1: # fold
        v36 = v9 == (<unsigned char>0)
        if v36:
            v38 = v13
        else:
            v38 = -v13
        v39 = v12 == (<unsigned char>0)
        if v39:
            v41 = v38
        else:
            v41 = -v38
        v42 = v41 + v13
        if v36:
            v44 = v38
        else:
            v44 = -v38
        v45 = v44 + v10
        if v39:
            v46, v47, v48, v49, v50, v51 = v11, v12, v42, v8, v9, v45
        else:
            v46, v47, v48, v49, v50, v51 = v8, v9, v45, v11, v12, v42
        v52 = <double>v38
        v53 = US1_0()
        v3(Tuple5(v15, v16, v46, v47, v48, v49, v50, v51, v53, (<unsigned char>0), v17, v18, v19, v52))
        del v53
        v54 = US1_0()
        v1(Tuple5(v15, v16, v49, v50, v51, v46, v47, v48, v54, (<unsigned char>1), v20, v21, v22, v52))
        del v54
        return v52
    elif v14 == 2: # raise
        v55 = v7 - (<signed long>1)
        v56 = v10 + (<signed long>2)
        v57 = method34(v4, v11, v12, v56, v8, v9, v10, v55)
        v58 = v9 == (<unsigned char>0)
        if v58:
            v59 = US1_0()
            v60 = Closure62(v20, v21, v22, v17, v18, v19, v15, v16, v0, v1, v2, v3, v4, v5, v6, v55, v11, v12, v56, v8, v9, v10)
            return v2(Tuple0(v57, v15, v16, v8, v9, v10, v11, v12, v56, v59, (<unsigned char>0), v60, v17, v18, v19, v21, v22))
        else:
            v62 = US1_0()
            v63 = Closure63(v20, v21, v22, v17, v18, v19, v15, v16, v0, v1, v2, v3, v4, v5, v6, v55, v11, v12, v56, v8, v9, v10)
            return v0(Tuple0(v57, v15, v16, v8, v9, v10, v11, v12, v56, v62, (<unsigned char>1), v63, v20, v21, v22, v18, v19))
cdef double method57(v0, v1, v2, v3, Heap0 v4, v5, numpy.ndarray[signed long,ndim=1] v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US0 v11, unsigned char v12, US3 v13, double v14, double v15, UH0 v16, double v17, double v18, UH0 v19, double v20, double v21):
    cdef bint v22
    cdef US0 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef US0 v26
    cdef unsigned char v27
    cdef signed long v28
    cdef US4 v29
    cdef object v30
    cdef object v31
    cdef object v32
    cdef object v33
    cdef bint v35
    cdef signed long v37
    cdef bint v38
    cdef signed long v40
    cdef signed long v41
    cdef signed long v43
    cdef signed long v44
    cdef US0 v45
    cdef unsigned char v46
    cdef signed long v47
    cdef US0 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef double v51
    cdef US1 v52
    cdef US1 v53
    cdef signed long v54
    cdef signed long v55
    cdef numpy.ndarray[signed long,ndim=1] v56
    cdef bint v57
    cdef US1 v58
    cdef object v59
    cdef US1 v61
    cdef object v62
    if v13 == 0: # call
        v22 = v12 == (<unsigned char>0)
        if v22:
            v23, v24, v25, v26, v27, v28 = v11, v12, v10, v8, v9, v10
        else:
            v23, v24, v25, v26, v27, v28 = v8, v9, v10, v11, v12, v10
        v29 = US4_0()
        v30 = v5(v29)
        del v29
        v31 = v30(v6)
        del v30
        v32 = Closure56(v0, v1, v2, v3, v4, v26, v27, v28, v23, v24, v25)
        v33 = v31(v32)
        del v31; del v32
        return v33(Tuple6(v14, v15, v16, v17, v18, v19, v20, v21))
    elif v13 == 1: # fold
        v35 = v9 == (<unsigned char>0)
        if v35:
            v37 = v10
        else:
            v37 = -v10
        v38 = v12 == (<unsigned char>0)
        if v38:
            v40 = v37
        else:
            v40 = -v37
        v41 = v40 + v10
        if v35:
            v43 = v37
        else:
            v43 = -v37
        v44 = v43 + v10
        if v38:
            v45, v46, v47, v48, v49, v50 = v11, v12, v41, v8, v9, v44
        else:
            v45, v46, v47, v48, v49, v50 = v8, v9, v44, v11, v12, v41
        v51 = <double>v37
        v52 = US1_0()
        v3(Tuple5(v14, v15, v45, v46, v47, v48, v49, v50, v52, (<unsigned char>0), v16, v17, v18, v51))
        del v52
        v53 = US1_0()
        v1(Tuple5(v14, v15, v48, v49, v50, v45, v46, v47, v53, (<unsigned char>1), v19, v20, v21, v51))
        del v53
        return v51
    elif v13 == 2: # raise
        v54 = v7 - (<signed long>1)
        v55 = v10 + (<signed long>2)
        v56 = method34(v4, v11, v12, v55, v8, v9, v10, v54)
        v57 = v9 == (<unsigned char>0)
        if v57:
            v58 = US1_0()
            v59 = Closure62(v19, v20, v21, v16, v17, v18, v14, v15, v0, v1, v2, v3, v4, v5, v6, v54, v11, v12, v55, v8, v9, v10)
            return v2(Tuple0(v56, v14, v15, v8, v9, v10, v11, v12, v55, v58, (<unsigned char>0), v59, v16, v17, v18, v20, v21))
        else:
            v61 = US1_0()
            v62 = Closure63(v19, v20, v21, v16, v17, v18, v14, v15, v0, v1, v2, v3, v4, v5, v6, v54, v11, v12, v55, v8, v9, v10)
            return v0(Tuple0(v56, v14, v15, v8, v9, v10, v11, v12, v55, v61, (<unsigned char>1), v62, v19, v20, v21, v17, v18))
cdef double method56(v0, v1, v2, v3, US0 v4, US0 v5, Heap0 v6, v7, numpy.ndarray[signed long,ndim=1] v8, US3 v9, double v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17):
    cdef signed long v18
    cdef unsigned char v19
    cdef signed long v20
    cdef unsigned char v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef bint v23
    cdef US1 v24
    cdef object v25
    cdef US1 v27
    cdef object v28
    cdef object v31
    cdef signed long v33
    cdef unsigned char v34
    cdef signed long v35
    cdef unsigned char v36
    cdef signed long v37
    cdef numpy.ndarray[signed long,ndim=1] v38
    cdef bint v39
    cdef US1 v40
    cdef object v41
    cdef US1 v43
    cdef object v44
    if v9 == 0: # call
        v18 = (<signed long>2)
        v19 = (<unsigned char>1)
        v20 = (<signed long>1)
        v21 = (<unsigned char>0)
        v22 = method31(v6, v4, v21, v20, v5, v19, v18)
        v23 = v19 == (<unsigned char>0)
        if v23:
            v24 = US1_0()
            v25 = Closure55(v15, v16, v17, v12, v13, v14, v10, v11, v0, v1, v2, v3, v6, v7, v8, v18, v4, v21, v20, v5, v19)
            return v2(Tuple0(v22, v10, v11, v5, v19, v20, v4, v21, v20, v24, (<unsigned char>0), v25, v12, v13, v14, v16, v17))
        else:
            v27 = US1_0()
            v28 = Closure64(v15, v16, v17, v12, v13, v14, v10, v11, v0, v1, v2, v3, v6, v7, v8, v18, v4, v21, v20, v5, v19)
            return v0(Tuple0(v22, v10, v11, v5, v19, v20, v4, v21, v20, v27, (<unsigned char>1), v28, v15, v16, v17, v13, v14))
    elif v9 == 1: # fold
        raise Exception("impossible")
    elif v9 == 2: # raise
        v33 = (<signed long>1)
        v34 = (<unsigned char>1)
        v35 = (<signed long>1)
        v36 = (<unsigned char>0)
        v37 = (<signed long>3)
        v38 = method34(v6, v4, v36, v37, v5, v34, v35, v33)
        v39 = v34 == (<unsigned char>0)
        if v39:
            v40 = US1_0()
            v41 = Closure62(v15, v16, v17, v12, v13, v14, v10, v11, v0, v1, v2, v3, v6, v7, v8, v33, v4, v36, v37, v5, v34, v35)
            return v2(Tuple0(v38, v10, v11, v5, v34, v35, v4, v36, v37, v40, (<unsigned char>0), v41, v12, v13, v14, v16, v17))
        else:
            v43 = US1_0()
            v44 = Closure63(v15, v16, v17, v12, v13, v14, v10, v11, v0, v1, v2, v3, v6, v7, v8, v33, v4, v36, v37, v5, v34, v35)
            return v0(Tuple0(v38, v10, v11, v5, v34, v35, v4, v36, v37, v43, (<unsigned char>1), v44, v15, v16, v17, v13, v14))
cdef double method55(bint v0, v1, v2, v3, v4):
    cdef object v7
    cdef object v8
    cdef object v9
    cdef object v12
    cdef object v13
    cdef object v14
    cdef US3 v15
    cdef US3 v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef US3 v18
    cdef US3 v19
    cdef US3 v20
    cdef numpy.ndarray[signed long,ndim=1] v21
    cdef US3 v22
    cdef US3 v23
    cdef numpy.ndarray[signed long,ndim=1] v24
    cdef US3 v25
    cdef numpy.ndarray[signed long,ndim=1] v26
    cdef Heap0 v27
    cdef US0 v28
    cdef US0 v29
    cdef US0 v30
    cdef US0 v31
    cdef US0 v32
    cdef US0 v33
    cdef numpy.ndarray[signed long,ndim=1] v34
    cdef US4 v35
    cdef object v36
    cdef object v37
    cdef object v38
    cdef object v39
    cdef UH0 v40
    cdef double v41
    cdef double v42
    cdef UH0 v43
    cdef double v44
    cdef double v45
    if v0:
        v7 = Closure3()
    else:
        v7 = Closure6()
    v8 = Closure11()
    v9 = v7(v8)
    del v7; del v8
    if v0:
        v12 = Closure19()
    else:
        v12 = Closure22()
    v13 = Closure27()
    v14 = v12(v13)
    del v12; del v13
    v15 = 0
    v16 = 2
    v17 = numpy.empty(2,dtype=numpy.int32)
    v17[0] = v15; v17[1] = v16
    v18 = 1
    v19 = 0
    v20 = 2
    v21 = numpy.empty(3,dtype=numpy.int32)
    v21[0] = v18; v21[1] = v19; v21[2] = v20
    v22 = 1
    v23 = 0
    v24 = numpy.empty(2,dtype=numpy.int32)
    v24[0] = v22; v24[1] = v23
    v25 = 0
    v26 = numpy.empty(1,dtype=numpy.int32)
    v26[0] = v25
    v27 = Heap0(v26, v21, v17, v24)
    del v17; del v21; del v24; del v26
    v28 = 1
    v29 = 2
    v30 = 0
    v31 = 1
    v32 = 2
    v33 = 0
    v34 = numpy.empty(6,dtype=numpy.int32)
    v34[0] = v28; v34[1] = v29; v34[2] = v30; v34[3] = v31; v34[4] = v32; v34[5] = v33
    v35 = US4_1((<unsigned char>0))
    v36 = v9(v35)
    del v35
    v37 = v36(v34)
    del v34; del v36
    v38 = Closure51(v14, v1, v2, v3, v4, v9, v27)
    del v9; del v14; del v27
    v39 = v37(v38)
    del v37; del v38
    v40 = UH0_1()
    v41 = (<double>0.000000)
    v42 = (<double>0.000000)
    v43 = UH0_1()
    v44 = (<double>0.000000)
    v45 = (<double>0.000000)
    return v39(Tuple6((<double>0.000000), (<double>0.000000), v40, v41, v42, v43, v44, v45))
cdef unsigned long long method64(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef unsigned long long v7
    cdef UH0 v8
    cdef numpy.ndarray[signed long,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef numpy.ndarray[double,ndim=1] v12
    cdef Tuple2 tmp10
    cdef unsigned long long v13
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        tmp10 = v2[v3]
        v7, v8, v9, v10, v11, v12 = tmp10.v0, tmp10.v1, tmp10.v2, tmp10.v3, tmp10.v4, tmp10.v5
        del tmp10
        v13 = v4 - (<unsigned long long>1)
        v1[v13] = Tuple9(v8, v9, v10, v11, v12)
        del v8; del v9; del v10; del v11; del v12
        return method64(v0, v1, v2, v6, v13)
    else:
        return v4
cdef unsigned long long method63(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef list v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    v5 = v3 < v0
    if v5:
        v6 = v3 + (<unsigned long long>1)
        v7 = v2[v3]
        v8 = len(v7)
        v9 = (<unsigned long long>0)
        v10 = method64(v8, v1, v7, v9, v4)
        del v7
        return method63(v0, v1, v2, v6, v10)
    else:
        return v4
cdef unsigned long long method62(numpy.ndarray[object,ndim=1] v0, unsigned long long v1, Mut0 v2):
    cdef numpy.ndarray[object,ndim=1] v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v4 = v2.v1
    v5 = len(v4)
    v6 = (<unsigned long long>0)
    return method63(v5, v0, v4, v6, v1)
cdef numpy.ndarray[object,ndim=1] method61(Mut0 v0):
    cdef unsigned long long v1
    cdef numpy.ndarray[object,ndim=1] v2
    cdef unsigned long long v3
    v1 = v0.v2
    v2 = numpy.empty(v1,dtype=object)
    v3 = method62(v2, v1, v0)
    return v2
cdef void method66(list v0, UH0 v1):
    cdef US2 v2
    cdef UH0 v3
    cdef str v8
    cdef US3 v4
    cdef US0 v6
    if v1.tag == 0: # cons_
        v2 = (<UH0_0>v1).v0; v3 = (<UH0_0>v1).v1
        method66(v0, v3)
        del v3
        if v2.tag == 0: # action_
            v4 = (<US2_0>v2).v0
            if v4 == 0: # call
                v8 = "C"
            elif v4 == 1: # fold
                v8 = "F"
            elif v4 == 2: # raise
                v8 = "R"
        elif v2.tag == 1: # observation_
            v6 = (<US2_1>v2).v0
            if v6 == 0: # jack
                v8 = "[color=ff0000]J[/color]"
            elif v6 == 1: # king
                v8 = "[color=ff0000]K[/color]"
            elif v6 == 2: # queen
                v8 = "[color=ff0000]Q[/color]"
        del v2
        v0.append(v8)
    elif v1.tag == 1: # nil
        pass
cdef void method67(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef str v9
    cdef str v10
    cdef str v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = v2[v4]
        if v7 == 0: # call
            v9 = "C"
        elif v7 == 1: # fold
            v9 = "F"
        elif v7 == 2: # raise
            v9 = "R"
        v10 = '{:.5f}'.format(v8)
        v11 = f'{v9}: {v10}'
        del v9; del v10
        v3[v4] = v11
        del v11
        method67(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method68(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[double,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef str v9
    cdef str v10
    cdef str v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        v8 = v2[v4]
        if v7 == 0: # call
            v9 = "C"
        elif v7 == 1: # fold
            v9 = "F"
        elif v7 == 2: # raise
            v9 = "R"
        v10 = '{:.5f}'.format(v8)
        v11 = f'{v9}: {v10}'
        del v9; del v10
        v3[v4] = v11
        del v11
        method68(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method69(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, list v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef double v8
    cdef double v9
    cdef Tuple3 tmp12
    cdef str v10
    cdef bint v11
    cdef double v13
    cdef double v12
    cdef str v14
    cdef str v15
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        tmp12 = v2[v4]
        v8, v9 = tmp12.v0, tmp12.v1
        del tmp12
        if v7 == 0: # call
            v10 = "C"
        elif v7 == 1: # fold
            v10 = "F"
        elif v7 == 2: # raise
            v10 = "R"
        v11 = v9 == (<double>0.000000)
        if v11:
            v13 = (<double>0.000000)
        else:
            v12 = v8 / v9
            v13 = v12
        v14 = '{:.5f}'.format(v13)
        v15 = f'{v10}: {v14}'
        del v10; del v14
        v3[v4] = v15
        del v15
        method69(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method65(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, list v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef UH0 v6
    cdef numpy.ndarray[signed long,ndim=1] v7
    cdef numpy.ndarray[double,ndim=1] v8
    cdef numpy.ndarray[object,ndim=1] v9
    cdef numpy.ndarray[double,ndim=1] v10
    cdef Tuple9 tmp11
    cdef list v11
    cdef str v12
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef bint v15
    cdef bint v16
    cdef list v17
    cdef unsigned long long v18
    cdef str v19
    cdef unsigned long long v20
    cdef bint v21
    cdef bint v22
    cdef list v23
    cdef unsigned long long v24
    cdef str v25
    cdef unsigned long long v26
    cdef bint v27
    cdef bint v28
    cdef list v29
    cdef unsigned long long v30
    cdef str v31
    cdef object v32
    v4 = v3 < v0
    if v4:
        v5 = v3 + (<unsigned long long>1)
        tmp11 = v1[v3]
        v6, v7, v8, v9, v10 = tmp11.v0, tmp11.v1, tmp11.v2, tmp11.v3, tmp11.v4
        del tmp11
        v11 = [None]*(<unsigned long long>0)
        method66(v11, v6)
        del v6
        v12 = "".join(v11)
        del v11
        v13 = len(v7)
        v14 = len(v8)
        v15 = v13 == v14
        v16 = v15 != 1
        if v16:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v17 = [None]*v13
        v18 = (<unsigned long long>0)
        method67(v13, v7, v8, v17, v18)
        del v8
        v19 = "\n".join(v17)
        del v17
        v20 = len(v10)
        v21 = v13 == v20
        v22 = v21 != 1
        if v22:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v23 = [None]*v13
        v24 = (<unsigned long long>0)
        method68(v13, v7, v10, v23, v24)
        del v10
        v25 = "\n".join(v23)
        del v23
        v26 = len(v9)
        v27 = v13 == v26
        v28 = v27 != 1
        if v28:
            raise Exception("The two arrays have to have the same size.")
        else:
            pass
        v29 = [None]*v13
        v30 = (<unsigned long long>0)
        method69(v13, v7, v9, v29, v30)
        del v7; del v9
        v31 = "\n".join(v29)
        del v29
        v32 = {'avg_policy': v19, 'q': v31, 'regret': v25, 'trace': v12}
        del v12; del v19; del v25; del v31
        v2[v3] = v32
        del v32
        method65(v0, v1, v2, v5)
    else:
        pass
cdef str method80(US0 v0):
    if v0 == 0: # jack
        return "Jack"
    elif v0 == 1: # king
        return "King"
    elif v0 == 2: # queen
        return "Queen"
cdef bint method79(list v0, UH0 v1, bint v2):
    cdef US2 v3
    cdef UH0 v4
    cdef bint v5
    cdef US3 v6
    cdef str v7
    cdef str v8
    cdef str v9
    cdef US0 v11
    cdef str v12
    cdef str v13
    if v1.tag == 0: # cons_
        v3 = (<UH0_0>v1).v0; v4 = (<UH0_0>v1).v1
        v5 = method79(v0, v4, v2)
        del v4
        if v3.tag == 0: # action_
            v6 = (<US2_0>v3).v0
            if v5:
                v7 = "One"
            else:
                v7 = "Two"
            if v6 == 0: # call
                v8 = "calls"
            elif v6 == 1: # fold
                v8 = "folds"
            elif v6 == 2: # raise
                v8 = "raises"
            v9 = f'Player {v7} {v8}.'
            del v7; del v8
            v0.append(v9)
            del v9
            return v5 == 0
        elif v3.tag == 1: # observation_
            v11 = (<US2_1>v3).v0
            v12 = method80(v11)
            v13 = f'Observed {v12}.'
            del v12
            v0.append(v13)
            del v13
            return 1
    elif v1.tag == 1: # nil
        return v2
cdef str method78(unsigned char v0, US5 v1, UH0 v2):
    cdef list v3
    cdef bint v4
    cdef bint v5
    cdef double v6
    cdef bint v7
    cdef str v8
    cdef double v10
    cdef bint v11
    cdef str v18
    cdef bint v13
    cdef double v15
    v3 = [None]*(<unsigned long long>0)
    v4 = 1
    v5 = method79(v3, v2, v4)
    if v1.tag == 0: # none
        pass
    elif v1.tag == 1: # some_
        v6 = (<US5_1>v1).v0
        v7 = v0 == (<unsigned char>0)
        if v7:
            v8 = "One"
        else:
            v8 = "Two"
        if v7:
            v10 = v6
        else:
            v10 = -v6
        v11 = (<double>0.000000) < v10
        if v11:
            v18 = f"Player {v8} wins {v10} chips.\n"
        else:
            v13 = (<double>0.000000) == v10
            if v13:
                v18 = f"Player {v8} draws.\n"
            else:
                v15 = -v10
                v18 = f"Player {v8} loses {v15} chips.\n"
        del v8
        v3.append(v18)
        del v18
    return "\n".join(v3)
cdef void method81(unsigned long long v0, numpy.ndarray[signed long,ndim=1] v1, v2, Mut3 v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US3 v7
    cdef object v8
    cdef object v9
    cdef object v10
    v5 = v4 < v0
    if v5:
        v6 = v4 + (<unsigned long long>1)
        v7 = v1[v4]
        if v7 == 0: # call
            v8 = Closure70(v2, v7)
            v3.v0 = v8
            del v8
        elif v7 == 1: # fold
            v9 = Closure71(v2, v7)
            v3.v1 = v9
            del v9
        elif v7 == 2: # raise
            v10 = Closure72(v2, v7)
            v3.v2 = v10
            del v10
        method81(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method77(v0, v1, numpy.ndarray[signed long,ndim=1] v2, UH0 v3, US5 v4, US1 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10, signed long v11):
    cdef str v12
    cdef object v13
    cdef object v14
    cdef object v15
    cdef Mut3 v16
    cdef unsigned long long v17
    cdef unsigned long long v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef object v22
    cdef str v23
    cdef str v24
    cdef str v27
    cdef US0 v25
    cdef object v28
    cdef object v29
    v12 = method78(v10, v4, v3)
    v13 = False
    v14 = False
    v15 = False
    v16 = Mut3(v14, v13, v15)
    del v13; del v14; del v15
    v17 = len(v2)
    v18 = (<unsigned long long>0)
    method81(v17, v2, v1, v16, v18)
    v19, v20, v21 = v16.v0, v16.v1, v16.v2
    del v16
    v22 = {'call': v19, 'fold': v20, 'raise': v21}
    del v19; del v20; del v21
    if v9 == 0: # jack
        v23 = 'J'
    elif v9 == 1: # king
        v23 = 'K'
    elif v9 == 2: # queen
        v23 = 'Q'
    if v6 == 0: # jack
        v24 = 'J'
    elif v6 == 1: # king
        v24 = 'K'
    elif v6 == 2: # queen
        v24 = 'Q'
    if v5.tag == 0: # none
        v27 = ' '
    elif v5.tag == 1: # some_
        v25 = (<US1_1>v5).v0
        if v25 == 0: # jack
            v27 = 'J'
        elif v25 == 1: # king
            v27 = 'K'
        elif v25 == 2: # queen
            v27 = 'Q'
    v28 = {'community_card': v27, 'my_card': v23, 'my_pot': v11, 'op_card': v24, 'op_pot': v8}
    del v23; del v24; del v27
    v29 = {'actions': v22, 'table_data': v28, 'trace': v12}
    del v12; del v22; del v28
    v0.data = v29
cdef void method76(v0, Mut0 v1, Heap0 v2, signed long v3, US0 v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, double v15, UH0 v16, double v17, double v18, v19):
    cdef signed long v20
    cdef signed long v21
    cdef signed long v22
    cdef bint v23
    cdef bint v25
    cdef signed long v49
    cdef bint v26
    cdef bint v27
    cdef bint v30
    cdef bint v31
    cdef signed long v32
    cdef signed long v33
    cdef bint v34
    cdef signed long v35
    cdef signed long v36
    cdef bint v37
    cdef signed long v40
    cdef bint v38
    cdef bint v41
    cdef bint v42
    cdef bint v43
    cdef bint v50
    cdef unsigned char v54
    cdef signed long v55
    cdef bint v51
    cdef bint v56
    cdef signed long v58
    cdef bint v59
    cdef signed long v61
    cdef signed long v62
    cdef bint v63
    cdef signed long v65
    cdef signed long v66
    cdef US0 v67
    cdef unsigned char v68
    cdef signed long v69
    cdef US0 v70
    cdef unsigned char v71
    cdef signed long v72
    cdef double v73
    cdef numpy.ndarray[signed long,ndim=1] v74
    cdef US1 v75
    cdef US5 v76
    cdef object v77
    cdef bint v78
    cdef signed long v80
    cdef bint v81
    cdef signed long v83
    cdef signed long v84
    cdef signed long v86
    cdef signed long v87
    cdef US0 v88
    cdef unsigned char v89
    cdef signed long v90
    cdef US0 v91
    cdef unsigned char v92
    cdef signed long v93
    cdef double v94
    cdef numpy.ndarray[signed long,ndim=1] v95
    cdef US1 v96
    cdef US5 v97
    cdef object v98
    cdef signed long v99
    cdef signed long v100
    cdef numpy.ndarray[signed long,ndim=1] v101
    cdef bint v102
    cdef unsigned long long v103
    cdef numpy.ndarray[signed long,ndim=1] v104
    cdef numpy.ndarray[double,ndim=1] v105
    cdef numpy.ndarray[object,ndim=1] v106
    cdef numpy.ndarray[double,ndim=1] v107
    cdef Tuple1 tmp17
    cdef numpy.ndarray[double,ndim=1] v108
    cdef unsigned long long v109
    cdef double v110
    cdef US3 v111
    cdef double v112
    cdef double v113
    cdef double v114
    cdef US2 v115
    cdef UH0 v116
    cdef US2 v117
    cdef UH0 v118
    cdef US1 v119
    cdef US5 v120
    cdef object v121
    if v11 == 0: # call
        v20 = method36(v4)
        v21 = method36(v8)
        v22 = method36(v5)
        v23 = v21 == v20
        if v23:
            v25 = v22 == v20
        else:
            v25 = 0
        if v25:
            v26 = v21 < v22
            if v26:
                v49 = (<signed long>-1)
            else:
                v27 = v21 > v22
                if v27:
                    v49 = (<signed long>1)
                else:
                    v49 = (<signed long>0)
        else:
            if v23:
                v49 = (<signed long>1)
            else:
                v30 = v22 == v20
                if v30:
                    v49 = (<signed long>-1)
                else:
                    v31 = v21 > v20
                    if v31:
                        v32, v33 = v21, v20
                    else:
                        v32, v33 = v20, v21
                    v34 = v22 > v20
                    if v34:
                        v35, v36 = v22, v20
                    else:
                        v35, v36 = v20, v22
                    v37 = v32 < v35
                    if v37:
                        v40 = (<signed long>-1)
                    else:
                        v38 = v32 > v35
                        if v38:
                            v40 = (<signed long>1)
                        else:
                            v40 = (<signed long>0)
                    v41 = v40 == (<signed long>0)
                    if v41:
                        v42 = v33 < v36
                        if v42:
                            v49 = (<signed long>-1)
                        else:
                            v43 = v33 > v36
                            if v43:
                                v49 = (<signed long>1)
                            else:
                                v49 = (<signed long>0)
                    else:
                        v49 = v40
        v50 = v49 == (<signed long>1)
        if v50:
            v54, v55 = v9, v7
        else:
            v51 = v49 == (<signed long>-1)
            if v51:
                v54, v55 = v6, v7
            else:
                v54, v55 = v9, (<signed long>0)
        v56 = v54 == (<unsigned char>0)
        if v56:
            v58 = v55
        else:
            v58 = -v55
        v59 = v9 == (<unsigned char>0)
        if v59:
            v61 = v58
        else:
            v61 = -v58
        v62 = v61 + v7
        v63 = v6 == (<unsigned char>0)
        if v63:
            v65 = v58
        else:
            v65 = -v58
        v66 = v65 + v7
        if v59:
            v67, v68, v69, v70, v71, v72 = v8, v9, v62, v5, v6, v66
        else:
            v67, v68, v69, v70, v71, v72 = v5, v6, v66, v8, v9, v62
        v73 = <double>v58
        v74 = numpy.empty(0,dtype=numpy.int32)
        
        v75 = US1_1(v4)
        v76 = US5_1(v73)
        v77 = Closure69()
        method77(v0, v77, v74, v16, v76, v75, v67, v68, v69, v70, v71, v72)
        del v74; del v75; del v76; del v77
        v19(v73)
    elif v11 == 1: # fold
        v78 = v6 == (<unsigned char>0)
        if v78:
            v80 = v10
        else:
            v80 = -v10
        v81 = v9 == (<unsigned char>0)
        if v81:
            v83 = v80
        else:
            v83 = -v80
        v84 = v83 + v10
        if v78:
            v86 = v80
        else:
            v86 = -v80
        v87 = v86 + v7
        if v81:
            v88, v89, v90, v91, v92, v93 = v8, v9, v84, v5, v6, v87
        else:
            v88, v89, v90, v91, v92, v93 = v5, v6, v87, v8, v9, v84
        v94 = <double>v80
        v95 = numpy.empty(0,dtype=numpy.int32)
        
        v96 = US1_1(v4)
        v97 = US5_1(v94)
        v98 = Closure69()
        method77(v0, v98, v95, v16, v97, v96, v88, v89, v90, v91, v92, v93)
        del v95; del v96; del v97; del v98
        v19(v94)
    elif v11 == 2: # raise
        v99 = v3 - (<signed long>1)
        v100 = v7 + (<signed long>4)
        v101 = method34(v2, v8, v9, v100, v5, v6, v7, v99)
        v102 = v6 == (<unsigned char>0)
        if v102:
            v103 = len(v101)
            tmp17 = method6(v1, v101, v13)
            v104, v105, v106, v107 = tmp17.v0, tmp17.v1, tmp17.v2, tmp17.v3
            del tmp17
            del v104; del v106; del v107
            v108 = method16(v105)
            del v105
            v109 = numpy.random.choice(v103,p=v108)
            v110 = v108[v109]
            del v108
            v111 = v101[v109]
            del v101
            v112 = libc.math.log(v110)
            v113 = v112 + v15
            v114 = v112 + v14
            v115 = US2_0(v111)
            v116 = UH0_0(v115, v13)
            del v115
            v117 = US2_0(v111)
            v118 = UH0_0(v117, v16)
            del v117
            method76(v0, v1, v2, v99, v4, v8, v9, v100, v5, v6, v7, v111, v12, v116, v114, v113, v118, v17, v18, v19)
        else:
            v119 = US1_1(v4)
            v120 = US5_0()
            v121 = Closure73(v19, v16, v17, v18, v13, v14, v15, v12, v0, v1, v2, v99, v4, v8, v9, v100, v5, v6, v7)
            method77(v0, v121, v101, v16, v120, v119, v8, v9, v100, v5, v6, v7)
cdef void method75(v0, Mut0 v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, US3 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17, v18):
    cdef signed long v19
    cdef numpy.ndarray[signed long,ndim=1] v20
    cdef bint v21
    cdef unsigned long long v22
    cdef numpy.ndarray[signed long,ndim=1] v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef numpy.ndarray[object,ndim=1] v25
    cdef numpy.ndarray[double,ndim=1] v26
    cdef Tuple1 tmp16
    cdef numpy.ndarray[double,ndim=1] v27
    cdef unsigned long long v28
    cdef double v29
    cdef US3 v30
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef US1 v38
    cdef US5 v39
    cdef object v40
    cdef object v41
    cdef signed long v42
    cdef signed long v43
    cdef numpy.ndarray[signed long,ndim=1] v44
    cdef bint v45
    cdef unsigned long long v46
    cdef numpy.ndarray[signed long,ndim=1] v47
    cdef numpy.ndarray[double,ndim=1] v48
    cdef numpy.ndarray[object,ndim=1] v49
    cdef numpy.ndarray[double,ndim=1] v50
    cdef Tuple1 tmp18
    cdef numpy.ndarray[double,ndim=1] v51
    cdef unsigned long long v52
    cdef double v53
    cdef US3 v54
    cdef double v55
    cdef double v56
    cdef double v57
    cdef US2 v58
    cdef UH0 v59
    cdef US2 v60
    cdef UH0 v61
    cdef US1 v62
    cdef US5 v63
    cdef object v64
    if v10 == 0: # call
        v19 = (<signed long>2)
        v20 = method34(v2, v6, v7, v8, v3, v4, v5, v19)
        v21 = v4 == (<unsigned char>0)
        if v21:
            v22 = len(v20)
            tmp16 = method6(v1, v20, v12)
            v23, v24, v25, v26 = tmp16.v0, tmp16.v1, tmp16.v2, tmp16.v3
            del tmp16
            del v23; del v25; del v26
            v27 = method16(v24)
            del v24
            v28 = numpy.random.choice(v22,p=v27)
            v29 = v27[v28]
            del v27
            v30 = v20[v28]
            del v20
            v31 = libc.math.log(v29)
            v32 = v31 + v14
            v33 = v31 + v13
            v34 = US2_0(v30)
            v35 = UH0_0(v34, v12)
            del v34
            v36 = US2_0(v30)
            v37 = UH0_0(v36, v15)
            del v36
            method76(v0, v1, v2, v19, v9, v6, v7, v8, v3, v4, v5, v30, v11, v35, v33, v32, v37, v16, v17, v18)
        else:
            v38 = US1_1(v9)
            v39 = US5_0()
            v40 = Closure73(v18, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v19, v9, v6, v7, v8, v3, v4, v5)
            method77(v0, v40, v20, v15, v39, v38, v6, v7, v8, v3, v4, v5)
    elif v10 == 1: # fold
        raise Exception("impossible")
    elif v10 == 2: # raise
        v42 = (<signed long>1)
        v43 = v5 + (<signed long>4)
        v44 = method34(v2, v6, v7, v43, v3, v4, v5, v42)
        v45 = v4 == (<unsigned char>0)
        if v45:
            v46 = len(v44)
            tmp18 = method6(v1, v44, v12)
            v47, v48, v49, v50 = tmp18.v0, tmp18.v1, tmp18.v2, tmp18.v3
            del tmp18
            del v47; del v49; del v50
            v51 = method16(v48)
            del v48
            v52 = numpy.random.choice(v46,p=v51)
            v53 = v51[v52]
            del v51
            v54 = v44[v52]
            del v44
            v55 = libc.math.log(v53)
            v56 = v55 + v14
            v57 = v55 + v13
            v58 = US2_0(v54)
            v59 = UH0_0(v58, v12)
            del v58
            v60 = US2_0(v54)
            v61 = UH0_0(v60, v15)
            del v60
            method76(v0, v1, v2, v42, v9, v6, v7, v43, v3, v4, v5, v54, v11, v59, v57, v56, v61, v16, v17, v18)
        else:
            v62 = US1_1(v9)
            v63 = US5_0()
            v64 = Closure73(v18, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v42, v9, v6, v7, v43, v3, v4, v5)
            method77(v0, v64, v44, v15, v63, v62, v6, v7, v43, v3, v4, v5)
cdef void method74(v0, Mut0 v1, Heap0 v2, US0 v3, unsigned char v4, signed long v5, US0 v6, unsigned char v7, signed long v8, US0 v9, double v10, UH0 v11, double v12, double v13, UH0 v14, double v15, double v16, v17):
    cdef numpy.ndarray[signed long,ndim=1] v18
    cdef bint v19
    cdef unsigned long long v20
    cdef numpy.ndarray[signed long,ndim=1] v21
    cdef numpy.ndarray[double,ndim=1] v22
    cdef numpy.ndarray[object,ndim=1] v23
    cdef numpy.ndarray[double,ndim=1] v24
    cdef Tuple1 tmp15
    cdef numpy.ndarray[double,ndim=1] v25
    cdef unsigned long long v26
    cdef double v27
    cdef US3 v28
    cdef double v29
    cdef double v30
    cdef double v31
    cdef US2 v32
    cdef UH0 v33
    cdef US2 v34
    cdef UH0 v35
    cdef US1 v36
    cdef US5 v37
    cdef object v38
    v18 = v2.v2
    v19 = v7 == (<unsigned char>0)
    if v19:
        v20 = len(v18)
        tmp15 = method6(v1, v18, v11)
        v21, v22, v23, v24 = tmp15.v0, tmp15.v1, tmp15.v2, tmp15.v3
        del tmp15
        del v21; del v23; del v24
        v25 = method16(v22)
        del v22
        v26 = numpy.random.choice(v20,p=v25)
        v27 = v25[v26]
        del v25
        v28 = v18[v26]
        del v18
        v29 = libc.math.log(v27)
        v30 = v29 + v13
        v31 = v29 + v12
        v32 = US2_0(v28)
        v33 = UH0_0(v32, v11)
        del v32
        v34 = US2_0(v28)
        v35 = UH0_0(v34, v14)
        del v34
        method75(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v28, v10, v33, v31, v30, v35, v15, v16, v17)
    else:
        v36 = US1_1(v9)
        v37 = US5_0()
        v38 = Closure74(v17, v14, v15, v16, v11, v12, v13, v10, v0, v1, v2, v3, v4, v5, v6, v7, v8, v9)
        method77(v0, v38, v18, v14, v37, v36, v3, v4, v5, v6, v7, v8)
cdef void method82(v0, Mut0 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, signed long v10, US3 v11, double v12, UH0 v13, double v14, double v15, UH0 v16, double v17, double v18, v19):
    cdef bint v20
    cdef US0 v21
    cdef unsigned char v22
    cdef signed long v23
    cdef US0 v24
    cdef unsigned char v25
    cdef signed long v26
    cdef unsigned long long v27
    cdef unsigned long long v28
    cdef US0 v29
    cdef double v30
    cdef double v31
    cdef double v32
    cdef double v33
    cdef US2 v34
    cdef UH0 v35
    cdef US2 v36
    cdef UH0 v37
    cdef bint v38
    cdef signed long v40
    cdef bint v41
    cdef signed long v43
    cdef signed long v44
    cdef signed long v46
    cdef signed long v47
    cdef US0 v48
    cdef unsigned char v49
    cdef signed long v50
    cdef US0 v51
    cdef unsigned char v52
    cdef signed long v53
    cdef double v54
    cdef numpy.ndarray[signed long,ndim=1] v55
    cdef US1 v56
    cdef US5 v57
    cdef object v58
    cdef signed long v59
    cdef signed long v60
    cdef numpy.ndarray[signed long,ndim=1] v61
    cdef bint v62
    cdef unsigned long long v63
    cdef numpy.ndarray[signed long,ndim=1] v64
    cdef numpy.ndarray[double,ndim=1] v65
    cdef numpy.ndarray[object,ndim=1] v66
    cdef numpy.ndarray[double,ndim=1] v67
    cdef Tuple1 tmp20
    cdef numpy.ndarray[double,ndim=1] v68
    cdef unsigned long long v69
    cdef double v70
    cdef US3 v71
    cdef double v72
    cdef double v73
    cdef double v74
    cdef US2 v75
    cdef UH0 v76
    cdef US2 v77
    cdef UH0 v78
    cdef US1 v79
    cdef US5 v80
    cdef object v81
    if v11 == 0: # call
        v20 = v9 == (<unsigned char>0)
        if v20:
            v21, v22, v23, v24, v25, v26 = v8, v9, v7, v5, v6, v7
        else:
            v21, v22, v23, v24, v25, v26 = v5, v6, v7, v8, v9, v7
        v27 = len(v3)
        v28 = numpy.random.randint(0,v27)
        v29 = v3[v28]
        v30 = <double>v27
        v31 = (<double>1.000000) / v30
        v32 = libc.math.log(v31)
        v33 = v32 + v12
        v34 = US2_1(v29)
        v35 = UH0_0(v34, v13)
        del v34
        v36 = US2_1(v29)
        v37 = UH0_0(v36, v16)
        del v36
        method74(v0, v1, v2, v24, v25, v26, v21, v22, v23, v29, v33, v35, v14, v15, v37, v17, v18, v19)
    elif v11 == 1: # fold
        v38 = v6 == (<unsigned char>0)
        if v38:
            v40 = v10
        else:
            v40 = -v10
        v41 = v9 == (<unsigned char>0)
        if v41:
            v43 = v40
        else:
            v43 = -v40
        v44 = v43 + v10
        if v38:
            v46 = v40
        else:
            v46 = -v40
        v47 = v46 + v7
        if v41:
            v48, v49, v50, v51, v52, v53 = v8, v9, v44, v5, v6, v47
        else:
            v48, v49, v50, v51, v52, v53 = v5, v6, v47, v8, v9, v44
        v54 = <double>v40
        v55 = numpy.empty(0,dtype=numpy.int32)
        
        v56 = US1_0()
        v57 = US5_1(v54)
        v58 = Closure69()
        method77(v0, v58, v55, v16, v57, v56, v48, v49, v50, v51, v52, v53)
        del v55; del v56; del v57; del v58
        v19(v54)
    elif v11 == 2: # raise
        v59 = v4 - (<signed long>1)
        v60 = v7 + (<signed long>2)
        v61 = method34(v2, v8, v9, v60, v5, v6, v7, v59)
        v62 = v6 == (<unsigned char>0)
        if v62:
            v63 = len(v61)
            tmp20 = method6(v1, v61, v13)
            v64, v65, v66, v67 = tmp20.v0, tmp20.v1, tmp20.v2, tmp20.v3
            del tmp20
            del v64; del v66; del v67
            v68 = method16(v65)
            del v65
            v69 = numpy.random.choice(v63,p=v68)
            v70 = v68[v69]
            del v68
            v71 = v61[v69]
            del v61
            v72 = libc.math.log(v70)
            v73 = v72 + v15
            v74 = v72 + v14
            v75 = US2_0(v71)
            v76 = UH0_0(v75, v13)
            del v75
            v77 = US2_0(v71)
            v78 = UH0_0(v77, v16)
            del v77
            method82(v0, v1, v2, v3, v59, v8, v9, v60, v5, v6, v7, v71, v12, v76, v74, v73, v78, v17, v18, v19)
        else:
            v79 = US1_0()
            v80 = US5_0()
            v81 = Closure75(v19, v16, v17, v18, v13, v14, v15, v12, v0, v1, v2, v3, v59, v8, v9, v60, v5, v6, v7)
            method77(v0, v81, v61, v16, v80, v79, v8, v9, v60, v5, v6, v7)
cdef void method73(v0, Mut0 v1, Heap0 v2, numpy.ndarray[signed long,ndim=1] v3, signed long v4, US0 v5, unsigned char v6, signed long v7, US0 v8, unsigned char v9, US3 v10, double v11, UH0 v12, double v13, double v14, UH0 v15, double v16, double v17, v18):
    cdef bint v19
    cdef US0 v20
    cdef unsigned char v21
    cdef signed long v22
    cdef US0 v23
    cdef unsigned char v24
    cdef signed long v25
    cdef unsigned long long v26
    cdef unsigned long long v27
    cdef US0 v28
    cdef double v29
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef bint v37
    cdef signed long v39
    cdef bint v40
    cdef signed long v42
    cdef signed long v43
    cdef signed long v45
    cdef signed long v46
    cdef US0 v47
    cdef unsigned char v48
    cdef signed long v49
    cdef US0 v50
    cdef unsigned char v51
    cdef signed long v52
    cdef double v53
    cdef numpy.ndarray[signed long,ndim=1] v54
    cdef US1 v55
    cdef US5 v56
    cdef object v57
    cdef signed long v58
    cdef signed long v59
    cdef numpy.ndarray[signed long,ndim=1] v60
    cdef bint v61
    cdef unsigned long long v62
    cdef numpy.ndarray[signed long,ndim=1] v63
    cdef numpy.ndarray[double,ndim=1] v64
    cdef numpy.ndarray[object,ndim=1] v65
    cdef numpy.ndarray[double,ndim=1] v66
    cdef Tuple1 tmp19
    cdef numpy.ndarray[double,ndim=1] v67
    cdef unsigned long long v68
    cdef double v69
    cdef US3 v70
    cdef double v71
    cdef double v72
    cdef double v73
    cdef US2 v74
    cdef UH0 v75
    cdef US2 v76
    cdef UH0 v77
    cdef US1 v78
    cdef US5 v79
    cdef object v80
    if v10 == 0: # call
        v19 = v9 == (<unsigned char>0)
        if v19:
            v20, v21, v22, v23, v24, v25 = v8, v9, v7, v5, v6, v7
        else:
            v20, v21, v22, v23, v24, v25 = v5, v6, v7, v8, v9, v7
        v26 = len(v3)
        v27 = numpy.random.randint(0,v26)
        v28 = v3[v27]
        v29 = <double>v26
        v30 = (<double>1.000000) / v29
        v31 = libc.math.log(v30)
        v32 = v31 + v11
        v33 = US2_1(v28)
        v34 = UH0_0(v33, v12)
        del v33
        v35 = US2_1(v28)
        v36 = UH0_0(v35, v15)
        del v35
        method74(v0, v1, v2, v23, v24, v25, v20, v21, v22, v28, v32, v34, v13, v14, v36, v16, v17, v18)
    elif v10 == 1: # fold
        v37 = v6 == (<unsigned char>0)
        if v37:
            v39 = v7
        else:
            v39 = -v7
        v40 = v9 == (<unsigned char>0)
        if v40:
            v42 = v39
        else:
            v42 = -v39
        v43 = v42 + v7
        if v37:
            v45 = v39
        else:
            v45 = -v39
        v46 = v45 + v7
        if v40:
            v47, v48, v49, v50, v51, v52 = v8, v9, v43, v5, v6, v46
        else:
            v47, v48, v49, v50, v51, v52 = v5, v6, v46, v8, v9, v43
        v53 = <double>v39
        v54 = numpy.empty(0,dtype=numpy.int32)
        
        v55 = US1_0()
        v56 = US5_1(v53)
        v57 = Closure69()
        method77(v0, v57, v54, v15, v56, v55, v47, v48, v49, v50, v51, v52)
        del v54; del v55; del v56; del v57
        v18(v53)
    elif v10 == 2: # raise
        v58 = v4 - (<signed long>1)
        v59 = v7 + (<signed long>2)
        v60 = method34(v2, v8, v9, v59, v5, v6, v7, v58)
        v61 = v6 == (<unsigned char>0)
        if v61:
            v62 = len(v60)
            tmp19 = method6(v1, v60, v12)
            v63, v64, v65, v66 = tmp19.v0, tmp19.v1, tmp19.v2, tmp19.v3
            del tmp19
            del v63; del v65; del v66
            v67 = method16(v64)
            del v64
            v68 = numpy.random.choice(v62,p=v67)
            v69 = v67[v68]
            del v67
            v70 = v60[v68]
            del v60
            v71 = libc.math.log(v69)
            v72 = v71 + v14
            v73 = v71 + v13
            v74 = US2_0(v70)
            v75 = UH0_0(v74, v12)
            del v74
            v76 = US2_0(v70)
            v77 = UH0_0(v76, v15)
            del v76
            method82(v0, v1, v2, v3, v58, v8, v9, v59, v5, v6, v7, v70, v11, v75, v73, v72, v77, v16, v17, v18)
        else:
            v78 = US1_0()
            v79 = US5_0()
            v80 = Closure75(v18, v15, v16, v17, v12, v13, v14, v11, v0, v1, v2, v3, v58, v8, v9, v59, v5, v6, v7)
            method77(v0, v80, v60, v15, v79, v78, v8, v9, v59, v5, v6, v7)
cdef void method83(v0, v1, numpy.ndarray[signed long,ndim=1] v2, UH0 v3, US5 v4, US1 v5, US0 v6, unsigned char v7, signed long v8, US0 v9, unsigned char v10):
    cdef str v11
    cdef object v12
    cdef object v13
    cdef object v14
    cdef Mut3 v15
    cdef unsigned long long v16
    cdef unsigned long long v17
    cdef object v18
    cdef object v19
    cdef object v20
    cdef object v21
    cdef str v22
    cdef str v23
    cdef str v26
    cdef US0 v24
    cdef object v27
    cdef object v28
    v11 = method78(v10, v4, v3)
    v12 = False
    v13 = False
    v14 = False
    v15 = Mut3(v13, v12, v14)
    del v12; del v13; del v14
    v16 = len(v2)
    v17 = (<unsigned long long>0)
    method81(v16, v2, v1, v15, v17)
    v18, v19, v20 = v15.v0, v15.v1, v15.v2
    del v15
    v21 = {'call': v18, 'fold': v19, 'raise': v20}
    del v18; del v19; del v20
    if v9 == 0: # jack
        v22 = 'J'
    elif v9 == 1: # king
        v22 = 'K'
    elif v9 == 2: # queen
        v22 = 'Q'
    if v6 == 0: # jack
        v23 = 'J'
    elif v6 == 1: # king
        v23 = 'K'
    elif v6 == 2: # queen
        v23 = 'Q'
    if v5.tag == 0: # none
        v26 = ' '
    elif v5.tag == 1: # some_
        v24 = (<US1_1>v5).v0
        if v24 == 0: # jack
            v26 = 'J'
        elif v24 == 1: # king
            v26 = 'K'
        elif v24 == 2: # queen
            v26 = 'Q'
    v27 = {'community_card': v26, 'my_card': v22, 'my_pot': v8, 'op_card': v23, 'op_pot': v8}
    del v22; del v23; del v26
    v28 = {'actions': v21, 'table_data': v27, 'trace': v11}
    del v11; del v21; del v27
    v0.data = v28
cdef void method72(v0, Mut0 v1, US0 v2, US0 v3, Heap0 v4, numpy.ndarray[signed long,ndim=1] v5, US3 v6, double v7, UH0 v8, double v9, double v10, UH0 v11, double v12, double v13, v14):
    cdef signed long v15
    cdef unsigned char v16
    cdef signed long v17
    cdef unsigned char v18
    cdef numpy.ndarray[signed long,ndim=1] v19
    cdef bint v20
    cdef unsigned long long v21
    cdef numpy.ndarray[signed long,ndim=1] v22
    cdef numpy.ndarray[double,ndim=1] v23
    cdef numpy.ndarray[object,ndim=1] v24
    cdef numpy.ndarray[double,ndim=1] v25
    cdef Tuple1 tmp14
    cdef numpy.ndarray[double,ndim=1] v26
    cdef unsigned long long v27
    cdef double v28
    cdef US3 v29
    cdef double v30
    cdef double v31
    cdef double v32
    cdef US2 v33
    cdef UH0 v34
    cdef US2 v35
    cdef UH0 v36
    cdef US1 v37
    cdef US5 v38
    cdef object v39
    cdef object v40
    cdef signed long v41
    cdef unsigned char v42
    cdef signed long v43
    cdef unsigned char v44
    cdef signed long v45
    cdef numpy.ndarray[signed long,ndim=1] v46
    cdef bint v47
    cdef unsigned long long v48
    cdef numpy.ndarray[signed long,ndim=1] v49
    cdef numpy.ndarray[double,ndim=1] v50
    cdef numpy.ndarray[object,ndim=1] v51
    cdef numpy.ndarray[double,ndim=1] v52
    cdef Tuple1 tmp21
    cdef numpy.ndarray[double,ndim=1] v53
    cdef unsigned long long v54
    cdef double v55
    cdef US3 v56
    cdef double v57
    cdef double v58
    cdef double v59
    cdef US2 v60
    cdef UH0 v61
    cdef US2 v62
    cdef UH0 v63
    cdef US1 v64
    cdef US5 v65
    cdef object v66
    if v6 == 0: # call
        v15 = (<signed long>2)
        v16 = (<unsigned char>1)
        v17 = (<signed long>1)
        v18 = (<unsigned char>0)
        v19 = method31(v4, v2, v18, v17, v3, v16, v15)
        v20 = v16 == (<unsigned char>0)
        if v20:
            v21 = len(v19)
            tmp14 = method6(v1, v19, v8)
            v22, v23, v24, v25 = tmp14.v0, tmp14.v1, tmp14.v2, tmp14.v3
            del tmp14
            del v22; del v24; del v25
            v26 = method16(v23)
            del v23
            v27 = numpy.random.choice(v21,p=v26)
            v28 = v26[v27]
            del v26
            v29 = v19[v27]
            del v19
            v30 = libc.math.log(v28)
            v31 = v30 + v10
            v32 = v30 + v9
            v33 = US2_0(v29)
            v34 = UH0_0(v33, v8)
            del v33
            v35 = US2_0(v29)
            v36 = UH0_0(v35, v11)
            del v35
            method73(v0, v1, v4, v5, v15, v2, v18, v17, v3, v16, v29, v7, v34, v32, v31, v36, v12, v13, v14)
        else:
            v37 = US1_0()
            v38 = US5_0()
            v39 = Closure76(v14, v11, v12, v13, v8, v9, v10, v7, v0, v1, v4, v5, v15, v2, v18, v17, v3, v16)
            method83(v0, v39, v19, v11, v38, v37, v2, v18, v17, v3, v16)
    elif v6 == 1: # fold
        raise Exception("impossible")
    elif v6 == 2: # raise
        v41 = (<signed long>1)
        v42 = (<unsigned char>1)
        v43 = (<signed long>1)
        v44 = (<unsigned char>0)
        v45 = (<signed long>3)
        v46 = method34(v4, v2, v44, v45, v3, v42, v43, v41)
        v47 = v42 == (<unsigned char>0)
        if v47:
            v48 = len(v46)
            tmp21 = method6(v1, v46, v8)
            v49, v50, v51, v52 = tmp21.v0, tmp21.v1, tmp21.v2, tmp21.v3
            del tmp21
            del v49; del v51; del v52
            v53 = method16(v50)
            del v50
            v54 = numpy.random.choice(v48,p=v53)
            v55 = v53[v54]
            del v53
            v56 = v46[v54]
            del v46
            v57 = libc.math.log(v55)
            v58 = v57 + v10
            v59 = v57 + v9
            v60 = US2_0(v56)
            v61 = UH0_0(v60, v8)
            del v60
            v62 = US2_0(v56)
            v63 = UH0_0(v62, v11)
            del v62
            method82(v0, v1, v4, v5, v41, v2, v44, v45, v3, v42, v43, v56, v7, v61, v59, v58, v63, v12, v13, v14)
        else:
            v64 = US1_0()
            v65 = US5_0()
            v66 = Closure75(v14, v11, v12, v13, v8, v9, v10, v7, v0, v1, v4, v5, v41, v2, v44, v45, v3, v42, v43)
            method77(v0, v66, v46, v11, v65, v64, v2, v44, v45, v3, v42, v43)
cdef void method71(v0, Mut0 v1, Heap0 v2, US0 v3, US0 v4, numpy.ndarray[signed long,ndim=1] v5, double v6, UH0 v7, double v8, double v9, UH0 v10, double v11, double v12, v13):
    cdef numpy.ndarray[signed long,ndim=1] v14
    cdef unsigned long long v15
    cdef numpy.ndarray[signed long,ndim=1] v16
    cdef numpy.ndarray[double,ndim=1] v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef numpy.ndarray[double,ndim=1] v19
    cdef Tuple1 tmp13
    cdef numpy.ndarray[double,ndim=1] v20
    cdef unsigned long long v21
    cdef double v22
    cdef US3 v23
    cdef double v24
    cdef double v25
    cdef double v26
    cdef US2 v27
    cdef UH0 v28
    cdef US2 v29
    cdef UH0 v30
    v14 = v2.v2
    v15 = len(v14)
    tmp13 = method6(v1, v14, v7)
    v16, v17, v18, v19 = tmp13.v0, tmp13.v1, tmp13.v2, tmp13.v3
    del tmp13
    del v16; del v18; del v19
    v20 = method16(v17)
    del v17
    v21 = numpy.random.choice(v15,p=v20)
    v22 = v20[v21]
    del v20
    v23 = v14[v21]
    del v14
    v24 = libc.math.log(v22)
    v25 = v24 + v9
    v26 = v24 + v8
    v27 = US2_0(v23)
    v28 = UH0_0(v27, v7)
    del v27
    v29 = US2_0(v23)
    v30 = UH0_0(v29, v10)
    del v29
    method72(v0, v1, v3, v4, v2, v5, v23, v6, v28, v26, v25, v30, v11, v12, v13)
cdef void method70(v0, Mut0 v1, Heap0 v2, US0 v3, numpy.ndarray[signed long,ndim=1] v4, double v5, UH0 v6, double v7, double v8, UH0 v9, double v10, double v11, v12):
    cdef unsigned long long v13
    cdef unsigned long long v14
    cdef US0 v15
    cdef unsigned long long v16
    cdef numpy.ndarray[signed long,ndim=1] v17
    cdef unsigned long long v18
    cdef double v19
    cdef double v20
    cdef double v21
    cdef double v22
    cdef US2 v23
    cdef UH0 v24
    v13 = len(v4)
    v14 = numpy.random.randint(0,v13)
    v15 = v4[v14]
    v16 = v13 - (<unsigned long long>1)
    v17 = numpy.empty(v16,dtype=numpy.int32)
    v18 = (<unsigned long long>0)
    method26(v16, v14, v4, v17, v18)
    v19 = <double>v13
    v20 = (<double>1.000000) / v19
    v21 = libc.math.log(v20)
    v22 = v21 + v5
    v23 = US2_1(v15)
    v24 = UH0_0(v23, v9)
    del v23
    method71(v0, v1, v2, v3, v15, v17, v22, v6, v7, v8, v24, v10, v11, v12)
cpdef void main():
    cdef unsigned long long v0
    cdef unsigned long long v1
    cdef Mut0 v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef Mut1 v5
    cdef object v6
    cdef object v7
    cdef object v8
    v0 = (<unsigned long long>3)
    v1 = (<unsigned long long>7)
    v2 = method0(v0, v1)
    v3 = (<unsigned long long>3)
    v4 = (<unsigned long long>7)
    v5 = method2(v3, v4)
    pass # import ui_train
    v6 = Closure0(v2, v5)
    del v5
    v7 = Closure65(v2)
    v8 = Closure66(v2)
    del v2
    ui_train.run(v6,v7,v8)
