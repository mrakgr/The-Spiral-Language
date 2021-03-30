import kivy.app
import numpy
cimport numpy
import rx.subject
import rx
import kivy.uix.label
import rx.disposable
import kivy.metrics
import kivy.clock
import kivy.uix.floatlayout
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # call
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # fold
    def __init__(self): self.tag = 1
cdef class US0_2(US0): # raise
    def __init__(self): self.tag = 2
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, US0 v0):
        pass
cdef class Tuple0:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly double v2
    cdef readonly double v3
    cdef readonly double v4
    cdef readonly double v5
    cdef readonly double v6
    cdef readonly double v7
    cdef readonly double v8
    cdef readonly double v9
    cdef readonly str v10
    cdef readonly double v11
    cdef readonly double v12
    cdef readonly signed long v13
    cdef readonly double v14
    cdef readonly double v15
    cdef readonly double v16
    cdef readonly double v17
    cdef readonly double v18
    cdef readonly double v19
    cdef readonly signed long v20
    cdef readonly double v21
    cdef readonly double v22
    cdef readonly double v23
    cdef readonly double v24
    cdef readonly double v25
    cdef readonly double v26
    cdef readonly double v27
    cdef readonly double v28
    cdef readonly double v29
    cdef readonly double v30
    cdef readonly str v31
    cdef readonly double v32
    cdef readonly double v33
    cdef readonly signed long v34
    cdef readonly double v35
    cdef readonly double v36
    cdef readonly double v37
    cdef readonly double v38
    cdef readonly double v39
    cdef readonly double v40
    cdef readonly signed long v41
    cdef readonly double v42
    cdef readonly double v43
    cdef readonly double v44
    cdef readonly double v45
    cdef readonly double v46
    cdef readonly double v47
    cdef readonly str v48
    def __init__(self, v0, v1, double v2, double v3, double v4, double v5, double v6, double v7, double v8, double v9, str v10, double v11, double v12, signed long v13, double v14, double v15, double v16, double v17, double v18, double v19, signed long v20, double v21, double v22, double v23, double v24, double v25, double v26, double v27, double v28, double v29, double v30, str v31, double v32, double v33, signed long v34, double v35, double v36, double v37, double v38, double v39, double v40, signed long v41, double v42, double v43, double v44, double v45, double v46, double v47, str v48): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19; self.v20 = v20; self.v21 = v21; self.v22 = v22; self.v23 = v23; self.v24 = v24; self.v25 = v25; self.v26 = v26; self.v27 = v27; self.v28 = v28; self.v29 = v29; self.v30 = v30; self.v31 = v31; self.v32 = v32; self.v33 = v33; self.v34 = v34; self.v35 = v35; self.v36 = v36; self.v37 = v37; self.v38 = v38; self.v39 = v39; self.v40 = v40; self.v41 = v41; self.v42 = v42; self.v43 = v43; self.v44 = v44; self.v45 = v45; self.v46 = v46; self.v47 = v47; self.v48 = v48
cdef class Closure2():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef object v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = args.v0
        cdef object v2 = args.v1
        cdef double v3 = args.v2
        cdef double v4 = args.v3
        cdef double v5 = args.v4
        cdef double v6 = args.v5
        cdef double v7 = args.v6
        cdef double v8 = args.v7
        cdef double v9 = args.v8
        cdef double v10 = args.v9
        cdef str v11 = args.v10
        cdef double v12 = args.v11
        cdef double v13 = args.v12
        cdef signed long v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        cdef double v18 = args.v17
        cdef double v19 = args.v18
        cdef double v20 = args.v19
        cdef signed long v21 = args.v20
        cdef double v22 = args.v21
        cdef double v23 = args.v22
        cdef double v24 = args.v23
        cdef double v25 = args.v24
        cdef double v26 = args.v25
        cdef double v27 = args.v26
        cdef double v28 = args.v27
        cdef double v29 = args.v28
        cdef double v30 = args.v29
        cdef double v31 = args.v30
        cdef str v32 = args.v31
        cdef double v33 = args.v32
        cdef double v34 = args.v33
        cdef signed long v35 = args.v34
        cdef double v36 = args.v35
        cdef double v37 = args.v36
        cdef double v38 = args.v37
        cdef double v39 = args.v38
        cdef double v40 = args.v39
        cdef double v41 = args.v40
        cdef signed long v42 = args.v41
        cdef double v43 = args.v42
        cdef double v44 = args.v43
        cdef double v45 = args.v44
        cdef double v46 = args.v45
        cdef double v47 = args.v46
        cdef double v48 = args.v47
        cdef str v49 = args.v48
        cdef double v50
        cdef double v51
        cdef double v52
        cdef double v53
        v50 = v4 * 0.075000
        v51 = v5 + v50
        v52 = v3 * 0.075000
        v53 = v6 + v52
        v0.pos = v51,v53
cdef class Closure3():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef object v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = args.v0
        cdef object v2 = args.v1
        cdef double v3 = args.v2
        cdef double v4 = args.v3
        cdef double v5 = args.v4
        cdef double v6 = args.v5
        cdef double v7 = args.v6
        cdef double v8 = args.v7
        cdef double v9 = args.v8
        cdef double v10 = args.v9
        cdef str v11 = args.v10
        cdef double v12 = args.v11
        cdef double v13 = args.v12
        cdef signed long v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        cdef double v18 = args.v17
        cdef double v19 = args.v18
        cdef double v20 = args.v19
        cdef signed long v21 = args.v20
        cdef double v22 = args.v21
        cdef double v23 = args.v22
        cdef double v24 = args.v23
        cdef double v25 = args.v24
        cdef double v26 = args.v25
        cdef double v27 = args.v26
        cdef double v28 = args.v27
        cdef double v29 = args.v28
        cdef double v30 = args.v29
        cdef double v31 = args.v30
        cdef str v32 = args.v31
        cdef double v33 = args.v32
        cdef double v34 = args.v33
        cdef signed long v35 = args.v34
        cdef double v36 = args.v35
        cdef double v37 = args.v36
        cdef double v38 = args.v37
        cdef double v39 = args.v38
        cdef double v40 = args.v39
        cdef double v41 = args.v40
        cdef signed long v42 = args.v41
        cdef double v43 = args.v42
        cdef double v44 = args.v43
        cdef double v45 = args.v44
        cdef double v46 = args.v45
        cdef double v47 = args.v46
        cdef double v48 = args.v47
        cdef str v49 = args.v48
        cdef str v50
        cdef numpy.ndarray[str,ndim=1] v51
        cdef str v52
        v50 = str(v14)
        v51 = numpy.empty(2,dtype=object)
        v51[0] = "Stack: "; v51[1] = v50
        del v50
        v52 = "".join(v51)
        del v51
        v0.text = v52
cdef class Closure4():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef object v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = args.v0
        cdef object v2 = args.v1
        cdef double v3 = args.v2
        cdef double v4 = args.v3
        cdef double v5 = args.v4
        cdef double v6 = args.v5
        cdef double v7 = args.v6
        cdef double v8 = args.v7
        cdef double v9 = args.v8
        cdef double v10 = args.v9
        cdef str v11 = args.v10
        cdef double v12 = args.v11
        cdef double v13 = args.v12
        cdef signed long v14 = args.v13
        cdef double v15 = args.v14
        cdef double v16 = args.v15
        cdef double v17 = args.v16
        cdef double v18 = args.v17
        cdef double v19 = args.v18
        cdef double v20 = args.v19
        cdef signed long v21 = args.v20
        cdef double v22 = args.v21
        cdef double v23 = args.v22
        cdef double v24 = args.v23
        cdef double v25 = args.v24
        cdef double v26 = args.v25
        cdef double v27 = args.v26
        cdef double v28 = args.v27
        cdef double v29 = args.v28
        cdef double v30 = args.v29
        cdef double v31 = args.v30
        cdef str v32 = args.v31
        cdef double v33 = args.v32
        cdef double v34 = args.v33
        cdef signed long v35 = args.v34
        cdef double v36 = args.v35
        cdef double v37 = args.v36
        cdef double v38 = args.v37
        cdef double v39 = args.v38
        cdef double v40 = args.v39
        cdef double v41 = args.v40
        cdef signed long v42 = args.v41
        cdef double v43 = args.v42
        cdef double v44 = args.v43
        cdef double v45 = args.v44
        cdef double v46 = args.v45
        cdef double v47 = args.v46
        cdef double v48 = args.v47
        cdef str v49 = args.v48
        v0.size = v26,v27
cdef class Closure6():
    cdef object v0
    cdef double v1
    cdef double v2
    def __init__(self, v0, double v1, double v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v4
        cdef object v5
        cdef double v6
        cdef double v7
        cdef double v8
        cdef double v9
        cdef double v10
        cdef double v11
        cdef double v12
        cdef double v13
        cdef str v14
        cdef double v15
        cdef double v16
        cdef signed long v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef signed long v24
        cdef double v25
        cdef double v26
        cdef double v27
        cdef double v28
        cdef double v29
        cdef double v30
        cdef double v31
        cdef double v32
        cdef double v33
        cdef double v34
        cdef str v35
        cdef double v36
        cdef double v37
        cdef signed long v38
        cdef double v39
        cdef double v40
        cdef double v41
        cdef double v42
        cdef double v43
        cdef double v44
        cdef signed long v45
        cdef double v46
        cdef double v47
        cdef double v48
        cdef double v49
        cdef double v50
        cdef double v51
        cdef str v52
        cdef Tuple0 tmp0
        tmp0 = v0.value
        v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52 = tmp0.v0, tmp0.v1, tmp0.v2, tmp0.v3, tmp0.v4, tmp0.v5, tmp0.v6, tmp0.v7, tmp0.v8, tmp0.v9, tmp0.v10, tmp0.v11, tmp0.v12, tmp0.v13, tmp0.v14, tmp0.v15, tmp0.v16, tmp0.v17, tmp0.v18, tmp0.v19, tmp0.v20, tmp0.v21, tmp0.v22, tmp0.v23, tmp0.v24, tmp0.v25, tmp0.v26, tmp0.v27, tmp0.v28, tmp0.v29, tmp0.v30, tmp0.v31, tmp0.v32, tmp0.v33, tmp0.v34, tmp0.v35, tmp0.v36, tmp0.v37, tmp0.v38, tmp0.v39, tmp0.v40, tmp0.v41, tmp0.v42, tmp0.v43, tmp0.v44, tmp0.v45, tmp0.v46, tmp0.v47, tmp0.v48
        del tmp0
        v0.on_next(Tuple0(v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v1, v2, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52))
cdef class Closure5():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef double v4
        cdef double v5
        cdef object v6
        v2 = v1[0]
        del v2
        v3 = v1[1]
        v4 = v3[0]
        v5 = v3[1]
        del v3
        pass # import kivy.clock
        v6 = Closure6(v0, v4, v5)
        kivy.clock.Clock.schedule_once(v6)
cdef class Closure7():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("texture_size",v1)
cdef class Closure1():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef object v4
        cdef object v5
        cdef object v6
        cdef object v7
        cdef object v8
        cdef object v9
        cdef object v10
        cdef object v11
        cdef object v12
        cdef object v13
        cdef object v14
        v2 = v1[0]
        pass # import kivy.uix.label
        v3 = kivy.uix.label.Label()
        pass # import rx.disposable
        v4 = rx.disposable.compositedisposable.CompositeDisposable()
        v5 = Closure2(v3)
        v6 = v0.subscribe(v5)
        del v5
        v4.add(v6)
        del v6
        v7 = Closure3(v3)
        v8 = v0.subscribe(v7)
        del v7
        v4.add(v8)
        del v8
        v3.size_hint = None,None
        pass # import kivy.metrics
        v3.font_size = kivy.metrics.sp(30.000000)
        v9 = Closure4(v3)
        v10 = v0.subscribe(v9)
        del v9
        v4.add(v10)
        del v10
        v11 = Closure5(v0)
        v12 = v3.fbind("texture_size",v11)
        del v11
        pass # import rx.disposable
        v13 = Closure7(v3, v12)
        del v12
        v14 = rx.disposable.disposable.Disposable(v13)
        del v13
        v4.add(v14)
        del v14
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class Closure10():
    cdef object v0
    cdef double v1
    cdef double v2
    def __init__(self, v0, double v1, double v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v4
        cdef object v5
        cdef double v6
        cdef double v7
        cdef double v8
        cdef double v9
        cdef double v10
        cdef double v11
        cdef double v12
        cdef double v13
        cdef str v14
        cdef double v15
        cdef double v16
        cdef signed long v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef signed long v24
        cdef double v25
        cdef double v26
        cdef double v27
        cdef double v28
        cdef double v29
        cdef double v30
        cdef double v31
        cdef double v32
        cdef double v33
        cdef double v34
        cdef str v35
        cdef double v36
        cdef double v37
        cdef signed long v38
        cdef double v39
        cdef double v40
        cdef double v41
        cdef double v42
        cdef double v43
        cdef double v44
        cdef signed long v45
        cdef double v46
        cdef double v47
        cdef double v48
        cdef double v49
        cdef double v50
        cdef double v51
        cdef str v52
        cdef Tuple0 tmp1
        tmp1 = v0.value
        v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4, tmp1.v5, tmp1.v6, tmp1.v7, tmp1.v8, tmp1.v9, tmp1.v10, tmp1.v11, tmp1.v12, tmp1.v13, tmp1.v14, tmp1.v15, tmp1.v16, tmp1.v17, tmp1.v18, tmp1.v19, tmp1.v20, tmp1.v21, tmp1.v22, tmp1.v23, tmp1.v24, tmp1.v25, tmp1.v26, tmp1.v27, tmp1.v28, tmp1.v29, tmp1.v30, tmp1.v31, tmp1.v32, tmp1.v33, tmp1.v34, tmp1.v35, tmp1.v36, tmp1.v37, tmp1.v38, tmp1.v39, tmp1.v40, tmp1.v41, tmp1.v42, tmp1.v43, tmp1.v44, tmp1.v45, tmp1.v46, tmp1.v47, tmp1.v48
        del tmp1
        v0.on_next(Tuple0(v4, v5, v6, v7, v1, v2, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52))
cdef class Closure9():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef double v4
        cdef double v5
        cdef object v6
        v2 = v1[0]
        del v2
        v3 = v1[1]
        v4 = v3[0]
        v5 = v3[1]
        del v3
        pass # import kivy.clock
        v6 = Closure10(v0, v4, v5)
        kivy.clock.Clock.schedule_once(v6)
cdef class Closure11():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("pos",v1)
cdef class Closure13():
    cdef object v0
    cdef double v1
    cdef double v2
    def __init__(self, v0, double v1, double v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef double v1 = self.v1
        cdef double v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v4
        cdef object v5
        cdef double v6
        cdef double v7
        cdef double v8
        cdef double v9
        cdef double v10
        cdef double v11
        cdef double v12
        cdef double v13
        cdef str v14
        cdef double v15
        cdef double v16
        cdef signed long v17
        cdef double v18
        cdef double v19
        cdef double v20
        cdef double v21
        cdef double v22
        cdef double v23
        cdef signed long v24
        cdef double v25
        cdef double v26
        cdef double v27
        cdef double v28
        cdef double v29
        cdef double v30
        cdef double v31
        cdef double v32
        cdef double v33
        cdef double v34
        cdef str v35
        cdef double v36
        cdef double v37
        cdef signed long v38
        cdef double v39
        cdef double v40
        cdef double v41
        cdef double v42
        cdef double v43
        cdef double v44
        cdef signed long v45
        cdef double v46
        cdef double v47
        cdef double v48
        cdef double v49
        cdef double v50
        cdef double v51
        cdef str v52
        cdef Tuple0 tmp2
        tmp2 = v0.value
        v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52 = tmp2.v0, tmp2.v1, tmp2.v2, tmp2.v3, tmp2.v4, tmp2.v5, tmp2.v6, tmp2.v7, tmp2.v8, tmp2.v9, tmp2.v10, tmp2.v11, tmp2.v12, tmp2.v13, tmp2.v14, tmp2.v15, tmp2.v16, tmp2.v17, tmp2.v18, tmp2.v19, tmp2.v20, tmp2.v21, tmp2.v22, tmp2.v23, tmp2.v24, tmp2.v25, tmp2.v26, tmp2.v27, tmp2.v28, tmp2.v29, tmp2.v30, tmp2.v31, tmp2.v32, tmp2.v33, tmp2.v34, tmp2.v35, tmp2.v36, tmp2.v37, tmp2.v38, tmp2.v39, tmp2.v40, tmp2.v41, tmp2.v42, tmp2.v43, tmp2.v44, tmp2.v45, tmp2.v46, tmp2.v47, tmp2.v48
        del tmp2
        v0.on_next(Tuple0(v4, v5, v2, v1, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52))
cdef class Closure12():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef double v4
        cdef double v5
        cdef object v6
        v2 = v1[0]
        del v2
        v3 = v1[1]
        v4 = v3[0]
        v5 = v3[1]
        del v3
        pass # import kivy.clock
        v6 = Closure13(v0, v4, v5)
        kivy.clock.Clock.schedule_once(v6)
cdef class Closure14():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("size",v1)
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # none
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # some_
    cdef readonly object v0
    def __init__(self, v0): self.tag = 1; self.v0 = v0
cdef class Closure15():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, numpy.ndarray[unsigned long long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[unsigned long long,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US1 v4
        cdef unsigned long long v5
        cdef object v6
        cdef unsigned long long v7
        cdef US1 v8
        v4 = v2[0]
        if v4.tag == 0: # none
            v5 = 0
            method2(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US1_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[0]
        v0.add_widget(v3,v7)
        v8 = US1_1(v3)
        v2[0] = v8
cdef class Closure8():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self, * v2):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v3
        cdef object v4
        cdef object v5
        cdef object v6
        cdef object v7
        cdef object v8
        cdef object v9
        cdef object v10
        cdef object v11
        cdef object v12
        cdef object v13
        cdef numpy.ndarray[unsigned long long,ndim=1] v14
        cdef unsigned long long v15
        cdef numpy.ndarray[object,ndim=1] v16
        cdef unsigned long long v17
        cdef object v18
        cdef object v19
        cdef object v20
        v3 = v2[0]
        pass # import kivy.uix.floatlayout
        v4 = kivy.uix.floatlayout.FloatLayout()
        pass # import rx.disposable
        v5 = rx.disposable.compositedisposable.CompositeDisposable()
        v6 = Closure9(v0)
        v7 = v4.fbind("pos",v6)
        del v6
        pass # import rx.disposable
        v8 = Closure11(v4, v7)
        del v7
        v9 = rx.disposable.disposable.Disposable(v8)
        del v8
        v5.add(v9)
        del v9
        v10 = Closure12(v0)
        v11 = v4.fbind("size",v10)
        del v10
        pass # import rx.disposable
        v12 = Closure14(v4, v11)
        del v11
        v13 = rx.disposable.disposable.Disposable(v12)
        del v12
        v5.add(v13)
        del v13
        v14 = numpy.empty(1,dtype=numpy.uint64)
        v15 = 0
        method0(v14, v15)
        v16 = numpy.empty(1,dtype=object)
        v17 = 0
        method1(v16, v17)
        pass # import rx.disposable
        v18 = rx.disposable.compositedisposable.CompositeDisposable()
        v19 = Closure15(v4, v14, v16)
        del v14; del v16
        v20 = v1.subscribe(v19)
        del v19
        v18.add(v20)
        del v20
        v5.add(v18)
        del v18
        v3.on_next(v4)
        del v3; del v4
        return v5
cdef class Closure16():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        v0.root = v1
cdef void method0(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    v2 = v1 < 1
    if v2:
        v3 = v1 + 1
        v0[v1] = 0
        method0(v0, v3)
    else:
        pass
cdef void method1(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef US1 v4
    v2 = v1 < 1
    if v2:
        v3 = v1 + 1
        v4 = US1_0()
        v0[v1] = v4
        del v4
        method1(v0, v3)
    else:
        pass
cdef void method2(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v2 = v1 < 0
    if v2:
        v3 = v1 + 1
        v4 = 18446744073709551615 - v1
        v5 = v0[v4]
        v6 = v5 + 1
        v0[v4] = v6
        method2(v0, v3)
    else:
        pass
cpdef void main():
    cdef object v0
    cdef numpy.ndarray[object,ndim=1] v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef object v9
    pass # import kivy.app
    v0 = kivy.app.App()
    v1 = numpy.empty(0,dtype=object)
    
    pass # import rx.subject
    v2 = Closure0()
    v3 = rx.subject.behaviorsubject.BehaviorSubject(Tuple0(v1, v2, 490.000000, 490.000000, 90.000000, 90.000000, 490.000000, 490.000000, 90.000000, 90.000000, " ", 0.000000, 0.000000, 0, 490.000000, 490.000000, 90.000000, 90.000000, 0.000000, 0.000000, 10, 490.000000, 490.000000, 90.000000, 90.000000, 0.000000, 0.000000, 490.000000, 490.000000, 90.000000, 90.000000, " ", 0.000000, 0.000000, 0, 490.000000, 490.000000, 90.000000, 90.000000, 0.000000, 0.000000, 10, 490.000000, 490.000000, 90.000000, 90.000000, 0.000000, 0.000000, ""))
    del v1; del v2
    pass # import rx
    v4 = Closure1(v3)
    v5 = rx.create(v4)
    del v4
    pass # import rx
    v6 = Closure8(v3, v5)
    del v3; del v5
    v7 = rx.create(v6)
    del v6
    v8 = Closure16(v0)
    v9 = v7.subscribe(v8)
    del v7; del v8; del v9
    v0.run()
