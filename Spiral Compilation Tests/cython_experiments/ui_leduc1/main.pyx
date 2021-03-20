import kivy.app
import nets
import rx.subject
import numpy
cimport numpy
import torch
import torch.nn.functional
import torch.distributions
cimport libc.math
import rx
import kivy.uix.label
import rx.disposable
import kivy.uix.scrollview
import kivy.uix.button
import kivy.clock
import kivy.uix.boxlayout
cdef class US1:
    cdef readonly signed long tag
cdef class US1_0(US1): # call
    def __init__(self): self.tag = 0
cdef class US1_1(US1): # fold
    def __init__(self): self.tag = 1
cdef class US1_2(US1): # raise
    def __init__(self): self.tag = 2
cdef class US2:
    cdef readonly signed long tag
cdef class US2_0(US2): # jack
    def __init__(self): self.tag = 0
cdef class US2_1(US2): # king
    def __init__(self): self.tag = 1
cdef class US2_2(US2): # queen
    def __init__(self): self.tag = 2
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # action_
    cdef readonly US1 v0
    def __init__(self, US1 v0): self.tag = 0; self.v0 = v0
cdef class US0_1(US0): # observation_
    cdef readonly US2 v0
    def __init__(self, US2 v0): self.tag = 1; self.v0 = v0
cdef class UH0:
    cdef readonly signed long tag
cdef class UH0_0(UH0): # cons_
    cdef readonly US0 v0
    cdef readonly UH0 v1
    def __init__(self, US0 v0, UH0 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH0_1(UH0): # nil
    def __init__(self): self.tag = 1
cdef class Tuple0:
    cdef readonly UH0 v0
    cdef readonly double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
cdef class UH1:
    cdef readonly signed long tag
cdef class UH1_0(UH1): # cons_
    cdef readonly US1 v0
    cdef readonly UH1 v1
    def __init__(self, US1 v0, UH1 v1): self.tag = 0; self.v0 = v0; self.v1 = v1
cdef class UH1_1(UH1): # nil
    def __init__(self): self.tag = 1
cdef class UH2:
    cdef readonly signed long tag
cdef class UH2_0(UH2): # cons_
    cdef readonly US2 v0
    cdef readonly object v1
    cdef readonly UH2 v2
    def __init__(self, US2 v0, v1, UH2 v2): self.tag = 0; self.v0 = v0; self.v1 = v1; self.v2 = v2
cdef class UH2_1(UH2): # nil
    def __init__(self): self.tag = 1
cdef class Tuple1:
    cdef readonly US2 v0
    cdef readonly object v1
    def __init__(self, US2 v0, v1): self.v0 = v0; self.v1 = v1
cdef class Tuple2:
    cdef readonly double v0
    cdef readonly US1 v1
    def __init__(self, double v0, US1 v1): self.v0 = v0; self.v1 = v1
cdef class Closure3():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    cdef object v3
    def __init__(self, v0, UH0 v1, double v2, numpy.ndarray[object,ndim=1] v3): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3
    def __call__(self, object v4):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        cdef numpy.ndarray[object,ndim=1] v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v5
        cdef numpy.ndarray[float,ndim=1] v6
        cdef unsigned long long v7
        cdef unsigned long long v8
        cdef unsigned long long v9
        cdef bint v10
        cdef unsigned long long v11
        cdef object v12
        cdef object v13
        cdef unsigned long long v14
        cdef numpy.ndarray[signed long long,ndim=1] v15
        cdef unsigned long long v16
        cdef object v17
        cdef object v18
        cdef object v19
        cdef object v20
        cdef object v21
        cdef double v22
        cdef signed long long v23
        cdef unsigned long long v24
        cdef signed long long v25
        cdef US1 v26
        v5 = method0(v1)
        v6 = numpy.empty(30,dtype=numpy.float32)
        v7 = len(v6)
        v8 = 0
        method10(v7, v6, v8)
        v9 = len(v5)
        v10 = 2 < v9
        if v10:
            raise Exception("The given array is too large.")
        else:
            pass
        v11 = 0
        method11(v9, v6, v5, v11)
        del v5
        pass # import torch
        v12 = torch.from_numpy(v6)
        del v6
        v13 = v0.forward(v12)
        del v12
        v14 = len(v3)
        v15 = numpy.empty(v14,dtype=numpy.int64)
        v16 = 0
        method13(v14, v3, v15, v16)
        v17 = v13[v15]
        del v13
        pass # import torch.nn.functional
        v18 = torch.nn.functional.softmax(v17,-1)
        del v17
        pass # import torch.distributions
        v19 = torch.distributions.Categorical(probs=v18)
        del v18
        v20 = v19.sample()
        v21 = v19.log_prob(v20)
        del v19
        v22 = v21.item()
        del v21
        v23 = v20.item()
        del v20
        v24 = v23
        v25 = v15[v24]
        del v15
        v26 = method15(v25)
        return v4(Tuple2(v22, v26))
cdef class Closure2():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    def __init__(self, v0, UH0 v1, double v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, numpy.ndarray[object,ndim=1] v3):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        return Closure3(v0, v1, v2, v3)
cdef class Closure1():
    cdef object v0
    cdef UH0 v1
    cdef double v2
    def __init__(self, v0, UH0 v1, double v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, double v3):
        cdef object v0 = self.v0
        cdef UH0 v1 = self.v1
        cdef double v2 = self.v2
        return Closure2(v0, v1, v2)
cdef class Closure0():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, Tuple0 args):
        cdef object v0 = self.v0
        cdef UH0 v1 = args.v0
        cdef double v2 = args.v1
        return Closure1(v0, v1, v2)
cdef class Tuple3:
    cdef readonly double v0
    cdef readonly double v1
    def __init__(self, double v0, double v1): self.v0 = v0; self.v1 = v1
cdef class Closure5():
    def __init__(self): pass
    def __call__(self, Tuple3 args):
        cdef double v0 = args.v0
        cdef double v1 = args.v1
        pass
cdef class Closure4():
    def __init__(self): pass
    def __call__(self, Tuple0 args):
        cdef UH0 v0 = args.v0
        cdef double v1 = args.v1
        return Closure5()
cdef class Closure9():
    cdef UH0 v0
    cdef double v1
    cdef object v2
    def __init__(self, UH0 v0, double v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US1 v4
        cdef unsigned long long v5
        cdef double v6
        cdef double v7
        cdef double v8
        v4 = numpy.random.choice(v2)
        v5 = len(v2)
        v6 = <double>v5
        v7 = 1.000000 / v6
        v8 = libc.math.log(v7)
        return v3(Tuple2(v8, v4))
cdef class Closure8():
    cdef UH0 v0
    cdef double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
    def __call__(self, numpy.ndarray[object,ndim=1] v2):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        return Closure9(v0, v1, v2)
cdef class Closure7():
    cdef UH0 v0
    cdef double v1
    def __init__(self, UH0 v0, double v1): self.v0 = v0; self.v1 = v1
    def __call__(self, double v2):
        cdef UH0 v0 = self.v0
        cdef double v1 = self.v1
        return Closure8(v0, v1)
cdef class Closure6():
    def __init__(self): pass
    def __call__(self, Tuple0 args):
        cdef UH0 v0 = args.v0
        cdef double v1 = args.v1
        return Closure7(v0, v1)
cdef class Closure11():
    def __init__(self): pass
    def __call__(self, Tuple3 args):
        cdef double v0 = args.v0
        cdef double v1 = args.v1
        pass
cdef class Closure10():
    def __init__(self): pass
    def __call__(self, Tuple0 args):
        cdef UH0 v0 = args.v0
        cdef double v1 = args.v1
        return Closure11()
cdef class Tuple4:
    cdef readonly object v0
    cdef readonly object v1
    cdef readonly object v2
    cdef readonly object v3
    cdef readonly str v4
    def __init__(self, v0, v1, v2, v3, str v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Closure13():
    def __init__(self): pass
    def __call__(self, * v0):
        cdef object v1
        cdef object v2
        cdef double v3
        cdef double v4
        v1 = v0[0]
        v2 = v0[1]
        v3 = v2[0]
        v4 = v2[1]
        del v2
        v1.height = v4
cdef class Closure14():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("texture_size",v1)
cdef class Closure15():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, Tuple4 args):
        cdef object v0 = self.v0
        cdef object v1 = args.v0
        cdef object v2 = args.v1
        cdef object v3 = args.v2
        cdef object v4 = args.v3
        cdef str v5 = args.v4
        v0.text = v5
cdef class Closure12():
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
        v2 = v1[0]
        pass # import kivy.uix.label
        v3 = kivy.uix.label.Label()
        pass # import rx.disposable
        v4 = rx.disposable.compositedisposable.CompositeDisposable()
        v3.size_hint_y = None
        v5 = Closure13()
        v6 = v3.fbind("texture_size",v5)
        del v5
        pass # import rx.disposable
        v7 = Closure14(v3, v6)
        del v6
        v8 = rx.disposable.disposable.Disposable(v7)
        del v7
        v4.add(v8)
        del v8
        v9 = Closure15(v3)
        v10 = v0.subscribe(v9)
        del v9
        v4.add(v10)
        del v10
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class US3:
    cdef readonly signed long tag
cdef class US3_0(US3): # none
    def __init__(self): self.tag = 0
cdef class US3_1(US3): # some_
    cdef readonly object v0
    def __init__(self, v0): self.tag = 1; self.v0 = v0
cdef class Closure17():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, numpy.ndarray[unsigned long long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[unsigned long long,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US3 v4
        cdef unsigned long long v5
        cdef object v6
        cdef unsigned long long v7
        cdef US3 v8
        v4 = v2[0]
        if v4.tag == 0: # none
            v5 = 0
            method18(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US3_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[0]
        v0.add_widget(v3,v7)
        v8 = US3_1(v3)
        v2[0] = v8
cdef class Closure16():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef object v4
        cdef numpy.ndarray[unsigned long long,ndim=1] v5
        cdef unsigned long long v6
        cdef numpy.ndarray[object,ndim=1] v7
        cdef unsigned long long v8
        cdef object v9
        cdef object v10
        cdef object v11
        v2 = v1[0]
        pass # import kivy.uix.scrollview
        v3 = kivy.uix.scrollview.ScrollView()
        pass # import rx.disposable
        v4 = rx.disposable.compositedisposable.CompositeDisposable()
        v3.do_scroll_x = 0
        v3.do_scroll_y = 1
        v5 = numpy.empty(1,dtype=numpy.uint64)
        v6 = 0
        method16(v5, v6)
        v7 = numpy.empty(1,dtype=object)
        v8 = 0
        method17(v7, v8)
        pass # import rx.disposable
        v9 = rx.disposable.compositedisposable.CompositeDisposable()
        v10 = Closure17(v3, v5, v7)
        del v5; del v7
        v11 = v0.subscribe(v10)
        del v10
        v9.add(v11)
        del v11
        v4.add(v9)
        del v9
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class Closure21():
    def __init__(self): pass
    def __call__(self, double v0):
        return v0
cdef class Tuple5:
    cdef readonly UH0 v0
    cdef readonly double v1
    cdef readonly UH0 v2
    cdef readonly double v3
    cdef readonly object v4
    def __init__(self, UH0 v0, double v1, UH0 v2, double v3, v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
cdef class Tuple6:
    cdef readonly signed long v0
    cdef readonly signed long v1
    def __init__(self, signed long v0, signed long v1): self.v0 = v0; self.v1 = v1
cdef class Closure29():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef unsigned long v4
    cdef unsigned char v5
    def __init__(self, v0, v1, v2, v3, unsigned long v4, unsigned char v5): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5
    def __call__(self, Tuple5 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef unsigned long v4 = self.v4
        cdef unsigned char v5 = self.v5
        cdef UH0 v6 = args.v0
        cdef double v7 = args.v1
        cdef UH0 v8 = args.v2
        cdef double v9 = args.v3
        cdef object v10 = args.v4
        cdef double v11
        cdef bint v12
        cdef double v14
        cdef object v15
        cdef double v16
        cdef object v17
        cdef double v18
        cdef double v19
        v11 = <double>v4
        v12 = v5 == 0
        if v12:
            v14 = v11
        else:
            v14 =  -v11
        v15 = v3(Tuple0(v6, v7))
        v16 = libc.math.exp(v9)
        v15(Tuple3(v14, v16))
        del v15
        v17 = v1(Tuple0(v8, v9))
        v18 =  -v14
        v19 = libc.math.exp(v7)
        v17(Tuple3(v18, v19))
        del v17
        return v10(v14)
cdef class Closure30():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef unsigned char v4
    def __init__(self, v0, v1, v2, v3, unsigned char v4): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4
    def __call__(self, Tuple5 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef UH0 v5 = args.v0
        cdef double v6 = args.v1
        cdef UH0 v7 = args.v2
        cdef double v8 = args.v3
        cdef object v9 = args.v4
        cdef double v10
        cdef bint v11
        cdef double v13
        cdef object v14
        cdef double v15
        cdef object v16
        cdef double v17
        cdef double v18
        v10 = <double>0
        v11 = v4 == 0
        if v11:
            v13 = v10
        else:
            v13 =  -v10
        v14 = v3(Tuple0(v5, v6))
        v15 = libc.math.exp(v8)
        v14(Tuple3(v13, v15))
        del v14
        v16 = v1(Tuple0(v7, v8))
        v17 =  -v13
        v18 = libc.math.exp(v6)
        v16(Tuple3(v17, v18))
        del v16
        return v9(v13)
cdef class Closure28():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US2 v7
    cdef US2 v8
    cdef unsigned char v9
    cdef unsigned long v10
    cdef US2 v11
    cdef unsigned char v12
    cdef unsigned long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef UH0 v17
    cdef double v18
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US2 v7, US2 v8, unsigned char v9, unsigned long v10, US2 v11, unsigned char v12, unsigned long v13, v14, UH0 v15, double v16, UH0 v17, double v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef US2 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef unsigned long v10 = self.v10
        cdef US2 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef unsigned long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef double v18 = self.v18
        cdef double v19 = args.v0
        cdef US1 v20 = args.v1
        cdef object v62
        cdef signed long v21
        cdef signed long v22
        cdef signed long v23
        cdef signed long v24
        cdef bint v25
        cdef bint v27
        cdef signed long v50
        cdef bint v28
        cdef bint v29
        cdef bint v32
        cdef bint v33
        cdef signed long v34
        cdef signed long v35
        cdef Tuple6 tmp6
        cdef signed long v36
        cdef signed long v37
        cdef Tuple6 tmp7
        cdef bint v38
        cdef signed long v41
        cdef bint v39
        cdef bint v42
        cdef bint v43
        cdef bint v44
        cdef bint v51
        cdef bint v53
        cdef signed long v59
        cdef unsigned long v60
        cdef double v63
        cdef US0 v64
        cdef UH0 v65
        cdef US0 v66
        cdef UH0 v67
        if v20.tag == 0: # call
            if v11.tag == 0: # jack
                v21 = 0
            elif v11.tag == 1: # king
                v21 = 2
            elif v11.tag == 2: # queen
                v21 = 1
            if v7.tag == 0: # jack
                v22 = 0
            elif v7.tag == 1: # king
                v22 = 2
            elif v7.tag == 2: # queen
                v22 = 1
            if v8.tag == 0: # jack
                v23 = 0
            elif v8.tag == 1: # king
                v23 = 2
            elif v8.tag == 2: # queen
                v23 = 1
            if v7.tag == 0: # jack
                v24 = 0
            elif v7.tag == 1: # king
                v24 = 2
            elif v7.tag == 2: # queen
                v24 = 1
            v25 = method25(v22, v21)
            if v25:
                v27 = method25(v24, v23)
            else:
                v27 = 0
            if v27:
                v28 = v21 < v23
                if v28:
                    v50 = -1
                else:
                    v29 = v21 > v23
                    if v29:
                        v50 = 1
                    else:
                        v50 = 0
            else:
                v32 = method25(v22, v21)
                if v32:
                    v50 = 1
                else:
                    v33 = method25(v24, v23)
                    if v33:
                        v50 = -1
                    else:
                        tmp6 = method26(v22, v21)
                        v34, v35 = tmp6.v0, tmp6.v1
                        del tmp6
                        tmp7 = method26(v24, v23)
                        v36, v37 = tmp7.v0, tmp7.v1
                        del tmp7
                        v38 = v34 < v36
                        if v38:
                            v41 = -1
                        else:
                            v39 = v34 > v36
                            if v39:
                                v41 = 1
                            else:
                                v41 = 0
                        v42 = v41 == 0
                        if v42:
                            v43 = v35 < v37
                            if v43:
                                v50 = -1
                            else:
                                v44 = v35 > v37
                                if v44:
                                    v50 = 1
                                else:
                                    v50 = 0
                        else:
                            v50 = v41
            v51 = v50 == 1
            if v51:
                v62 = Closure29(v0, v1, v2, v3, v10, v12)
            else:
                v53 = v50 == -1
                if v53:
                    v62 = Closure29(v0, v1, v2, v3, v10, v9)
                else:
                    v62 = Closure30(v0, v1, v2, v3, v12)
        elif v20.tag == 1: # fold
            v62 = Closure29(v0, v1, v2, v3, v13, v9)
        elif v20.tag == 2: # raise
            v59 = v6 - 1
            v60 = v10 + 4
            v62 = method24(v0, v1, v2, v3, v4, v5, v59, v7, v11, v12, v60, v8, v9, v10)
        v63 = v19 + v18
        v64 = US0_0(v20)
        v65 = UH0_0(v64, v17)
        del v64
        v66 = US0_0(v20)
        v67 = UH0_0(v66, v15)
        del v66
        return v62(Tuple5(v65, v63, v67, v16, v14))
cdef class Closure31():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef signed long v6
    cdef US2 v7
    cdef US2 v8
    cdef unsigned char v9
    cdef unsigned long v10
    cdef US2 v11
    cdef unsigned char v12
    cdef unsigned long v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef UH0 v17
    cdef double v18
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US2 v7, US2 v8, unsigned char v9, unsigned long v10, US2 v11, unsigned char v12, unsigned long v13, v14, UH0 v15, double v16, UH0 v17, double v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef signed long v6 = self.v6
        cdef US2 v7 = self.v7
        cdef US2 v8 = self.v8
        cdef unsigned char v9 = self.v9
        cdef unsigned long v10 = self.v10
        cdef US2 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef unsigned long v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef double v18 = self.v18
        cdef double v19 = args.v0
        cdef US1 v20 = args.v1
        cdef object v62
        cdef signed long v21
        cdef signed long v22
        cdef signed long v23
        cdef signed long v24
        cdef bint v25
        cdef bint v27
        cdef signed long v50
        cdef bint v28
        cdef bint v29
        cdef bint v32
        cdef bint v33
        cdef signed long v34
        cdef signed long v35
        cdef Tuple6 tmp8
        cdef signed long v36
        cdef signed long v37
        cdef Tuple6 tmp9
        cdef bint v38
        cdef signed long v41
        cdef bint v39
        cdef bint v42
        cdef bint v43
        cdef bint v44
        cdef bint v51
        cdef bint v53
        cdef signed long v59
        cdef unsigned long v60
        cdef double v63
        cdef US0 v64
        cdef UH0 v65
        cdef US0 v66
        cdef UH0 v67
        if v20.tag == 0: # call
            if v11.tag == 0: # jack
                v21 = 0
            elif v11.tag == 1: # king
                v21 = 2
            elif v11.tag == 2: # queen
                v21 = 1
            if v7.tag == 0: # jack
                v22 = 0
            elif v7.tag == 1: # king
                v22 = 2
            elif v7.tag == 2: # queen
                v22 = 1
            if v8.tag == 0: # jack
                v23 = 0
            elif v8.tag == 1: # king
                v23 = 2
            elif v8.tag == 2: # queen
                v23 = 1
            if v7.tag == 0: # jack
                v24 = 0
            elif v7.tag == 1: # king
                v24 = 2
            elif v7.tag == 2: # queen
                v24 = 1
            v25 = method25(v22, v21)
            if v25:
                v27 = method25(v24, v23)
            else:
                v27 = 0
            if v27:
                v28 = v21 < v23
                if v28:
                    v50 = -1
                else:
                    v29 = v21 > v23
                    if v29:
                        v50 = 1
                    else:
                        v50 = 0
            else:
                v32 = method25(v22, v21)
                if v32:
                    v50 = 1
                else:
                    v33 = method25(v24, v23)
                    if v33:
                        v50 = -1
                    else:
                        tmp8 = method26(v22, v21)
                        v34, v35 = tmp8.v0, tmp8.v1
                        del tmp8
                        tmp9 = method26(v24, v23)
                        v36, v37 = tmp9.v0, tmp9.v1
                        del tmp9
                        v38 = v34 < v36
                        if v38:
                            v41 = -1
                        else:
                            v39 = v34 > v36
                            if v39:
                                v41 = 1
                            else:
                                v41 = 0
                        v42 = v41 == 0
                        if v42:
                            v43 = v35 < v37
                            if v43:
                                v50 = -1
                            else:
                                v44 = v35 > v37
                                if v44:
                                    v50 = 1
                                else:
                                    v50 = 0
                        else:
                            v50 = v41
            v51 = v50 == 1
            if v51:
                v62 = Closure29(v0, v1, v2, v3, v10, v12)
            else:
                v53 = v50 == -1
                if v53:
                    v62 = Closure29(v0, v1, v2, v3, v10, v9)
                else:
                    v62 = Closure30(v0, v1, v2, v3, v12)
        elif v20.tag == 1: # fold
            v62 = Closure29(v0, v1, v2, v3, v13, v9)
        elif v20.tag == 2: # raise
            v59 = v6 - 1
            v60 = v10 + 4
            v62 = method24(v0, v1, v2, v3, v4, v5, v59, v7, v11, v12, v60, v8, v9, v10)
        v63 = v19 + v16
        v64 = US0_0(v20)
        v65 = UH0_0(v64, v17)
        del v64
        v66 = US0_0(v20)
        v67 = UH0_0(v66, v15)
        del v66
        return v62(Tuple5(v65, v18, v67, v63, v14))
cdef class Closure27():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef unsigned char v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef signed long v8
    cdef US2 v9
    cdef US2 v10
    cdef unsigned char v11
    cdef unsigned long v12
    cdef US2 v13
    cdef unsigned long v14
    def __init__(self, v0, v1, v2, v3, unsigned char v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, US2 v10, unsigned char v11, unsigned long v12, US2 v13, unsigned long v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple5 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef US2 v10 = self.v10
        cdef unsigned char v11 = self.v11
        cdef unsigned long v12 = self.v12
        cdef US2 v13 = self.v13
        cdef unsigned long v14 = self.v14
        cdef UH0 v15 = args.v0
        cdef double v16 = args.v1
        cdef UH0 v17 = args.v2
        cdef double v18 = args.v3
        cdef object v19 = args.v4
        cdef bint v20
        cdef object v21
        cdef object v22
        cdef object v23
        cdef object v24
        cdef object v26
        cdef object v27
        cdef object v28
        cdef object v29
        v20 = v4 == 0
        if v20:
            v21 = v2(Tuple0(v15, v16))
            v22 = v21(v18)
            del v21
            v23 = v22(v5)
            del v22
            v24 = Closure28(v0, v1, v2, v3, v6, v7, v8, v9, v10, v11, v12, v13, v4, v14, v19, v17, v18, v15, v16)
            return v23(v24)
        else:
            v26 = v0(Tuple0(v17, v18))
            v27 = v26(v16)
            del v26
            v28 = v27(v5)
            del v27
            v29 = Closure31(v0, v1, v2, v3, v6, v7, v8, v9, v10, v11, v12, v13, v4, v14, v19, v17, v18, v15, v16)
            return v28(v29)
cdef class Closure26():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef US2 v6
    cdef unsigned char v7
    cdef unsigned long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef UH0 v16
    cdef double v17
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, US2 v6, unsigned char v7, unsigned long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, v13, UH0 v14, double v15, UH0 v16, double v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef US2 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef double v17 = self.v17
        cdef double v18 = args.v0
        cdef US1 v19 = args.v1
        cdef object v26
        cdef signed long v20
        cdef signed long v23
        cdef unsigned long v24
        cdef double v27
        cdef US0 v28
        cdef US0 v29
        cdef UH0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef UH0 v35
        if v19.tag == 0: # call
            v20 = 2
            v26 = method24(v0, v1, v2, v3, v4, v5, v20, v12, v9, v10, v11, v6, v7, v8)
        elif v19.tag == 1: # fold
            raise Exception("impossible")
        elif v19.tag == 2: # raise
            v23 = 1
            v24 = v8 + 4
            v26 = method24(v0, v1, v2, v3, v4, v5, v23, v12, v9, v10, v24, v6, v7, v8)
        v27 = v18 + v17
        v28 = US0_0(v19)
        v29 = US0_1(v12)
        v30 = UH0_0(v29, v16)
        del v29
        v31 = UH0_0(v28, v30)
        del v28; del v30
        v32 = US0_0(v19)
        v33 = US0_1(v12)
        v34 = UH0_0(v33, v14)
        del v33
        v35 = UH0_0(v32, v34)
        del v32; del v34
        return v26(Tuple5(v31, v27, v35, v15, v13))
cdef class Closure32():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef US2 v6
    cdef unsigned char v7
    cdef unsigned long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef object v13
    cdef UH0 v14
    cdef double v15
    cdef UH0 v16
    cdef double v17
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, US2 v6, unsigned char v7, unsigned long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, v13, UH0 v14, double v15, UH0 v16, double v17): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef US2 v6 = self.v6
        cdef unsigned char v7 = self.v7
        cdef unsigned long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef object v13 = self.v13
        cdef UH0 v14 = self.v14
        cdef double v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef double v17 = self.v17
        cdef double v18 = args.v0
        cdef US1 v19 = args.v1
        cdef object v26
        cdef signed long v20
        cdef signed long v23
        cdef unsigned long v24
        cdef double v27
        cdef US0 v28
        cdef US0 v29
        cdef UH0 v30
        cdef UH0 v31
        cdef US0 v32
        cdef US0 v33
        cdef UH0 v34
        cdef UH0 v35
        if v19.tag == 0: # call
            v20 = 2
            v26 = method24(v0, v1, v2, v3, v4, v5, v20, v12, v9, v10, v11, v6, v7, v8)
        elif v19.tag == 1: # fold
            raise Exception("impossible")
        elif v19.tag == 2: # raise
            v23 = 1
            v24 = v8 + 4
            v26 = method24(v0, v1, v2, v3, v4, v5, v23, v12, v9, v10, v24, v6, v7, v8)
        v27 = v18 + v15
        v28 = US0_0(v19)
        v29 = US0_1(v12)
        v30 = UH0_0(v29, v16)
        del v29
        v31 = UH0_0(v28, v30)
        del v28; del v30
        v32 = US0_0(v19)
        v33 = US0_1(v12)
        v34 = UH0_0(v33, v14)
        del v33
        v35 = UH0_0(v32, v34)
        del v32; del v34
        return v26(Tuple5(v31, v17, v35, v27, v13))
cdef class Closure25():
    cdef unsigned long long v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef unsigned char v13
    cdef unsigned long v14
    def __init__(self, unsigned long long v0, numpy.ndarray[object,ndim=1] v1, v2, v3, v4, v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13, unsigned long v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple5 args):
        cdef unsigned long long v0 = self.v0
        cdef numpy.ndarray[object,ndim=1] v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef object v4 = self.v4
        cdef object v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef unsigned long v14 = self.v14
        cdef UH0 v15 = args.v0
        cdef double v16 = args.v1
        cdef UH0 v17 = args.v2
        cdef double v18 = args.v3
        cdef object v19 = args.v4
        cdef US2 v20
        cdef unsigned long long v21
        cdef double v22
        cdef double v23
        cdef double v24
        cdef double v25
        cdef double v26
        cdef bint v27
        cdef US0 v28
        cdef UH0 v29
        cdef object v30
        cdef object v31
        cdef object v32
        cdef object v33
        cdef US0 v35
        cdef UH0 v36
        cdef object v37
        cdef object v38
        cdef object v39
        cdef object v40
        v20 = v1[v0]
        v21 = len(v1)
        v22 = <double>v21
        v23 = 1.000000 / v22
        v24 = libc.math.log(v23)
        v25 = v24 + v16
        v26 = v24 + v18
        v27 = v13 == 0
        if v27:
            v28 = US0_1(v20)
            v29 = UH0_0(v28, v15)
            del v28
            v30 = v4(Tuple0(v29, v25))
            del v29
            v31 = v30(v26)
            del v30
            v32 = v31(v6)
            del v31
            v33 = Closure26(v2, v3, v4, v5, v7, v8, v9, v10, v11, v12, v13, v14, v20, v19, v17, v26, v15, v25)
            return v32(v33)
        else:
            v35 = US0_1(v20)
            v36 = UH0_0(v35, v17)
            del v35
            v37 = v2(Tuple0(v36, v26))
            del v36
            v38 = v37(v25)
            del v37
            v39 = v38(v6)
            del v38
            v40 = Closure32(v2, v3, v4, v5, v7, v8, v9, v10, v11, v12, v13, v14, v20, v19, v17, v26, v15, v25)
            return v39(v40)
cdef class Closure34():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef signed long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef unsigned char v13
    cdef unsigned long v14
    cdef object v15
    cdef UH0 v16
    cdef double v17
    cdef UH0 v18
    cdef double v19
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13, unsigned long v14, v15, UH0 v16, double v17, UH0 v18, double v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef unsigned long v14 = self.v14
        cdef object v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef double v17 = self.v17
        cdef UH0 v18 = self.v18
        cdef double v19 = self.v19
        cdef double v20 = args.v0
        cdef US1 v21 = args.v1
        cdef object v34
        cdef bint v22
        cdef US2 v23
        cdef unsigned char v24
        cdef unsigned long v25
        cdef US2 v26
        cdef unsigned char v27
        cdef unsigned long v28
        cdef signed long v31
        cdef unsigned long v32
        cdef double v35
        cdef US0 v36
        cdef UH0 v37
        cdef US0 v38
        cdef UH0 v39
        if v21.tag == 0: # call
            v22 = v13 == 0
            if v22:
                v23, v24, v25, v26, v27, v28 = v12, v13, v11, v9, v10, v11
            else:
                v23, v24, v25, v26, v27, v28 = v9, v10, v11, v12, v13, v11
            v34 = method23(v0, v1, v2, v3, v6, v4, v5, v7, v26, v27, v28, v23, v24, v25)
            del v23; del v26
        elif v21.tag == 1: # fold
            v34 = Closure29(v0, v1, v2, v3, v14, v10)
        elif v21.tag == 2: # raise
            v31 = v8 - 1
            v32 = v11 + 2
            v34 = method27(v0, v1, v2, v3, v4, v5, v6, v7, v31, v12, v13, v32, v9, v10, v11)
        v35 = v20 + v19
        v36 = US0_0(v21)
        v37 = UH0_0(v36, v18)
        del v36
        v38 = US0_0(v21)
        v39 = UH0_0(v38, v16)
        del v38
        return v34(Tuple5(v37, v35, v39, v17, v15))
cdef class Closure35():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef signed long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef unsigned char v13
    cdef unsigned long v14
    cdef object v15
    cdef UH0 v16
    cdef double v17
    cdef UH0 v18
    cdef double v19
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13, unsigned long v14, v15, UH0 v16, double v17, UH0 v18, double v19): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18; self.v19 = v19
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef unsigned long v14 = self.v14
        cdef object v15 = self.v15
        cdef UH0 v16 = self.v16
        cdef double v17 = self.v17
        cdef UH0 v18 = self.v18
        cdef double v19 = self.v19
        cdef double v20 = args.v0
        cdef US1 v21 = args.v1
        cdef object v34
        cdef bint v22
        cdef US2 v23
        cdef unsigned char v24
        cdef unsigned long v25
        cdef US2 v26
        cdef unsigned char v27
        cdef unsigned long v28
        cdef signed long v31
        cdef unsigned long v32
        cdef double v35
        cdef US0 v36
        cdef UH0 v37
        cdef US0 v38
        cdef UH0 v39
        if v21.tag == 0: # call
            v22 = v13 == 0
            if v22:
                v23, v24, v25, v26, v27, v28 = v12, v13, v11, v9, v10, v11
            else:
                v23, v24, v25, v26, v27, v28 = v9, v10, v11, v12, v13, v11
            v34 = method23(v0, v1, v2, v3, v6, v4, v5, v7, v26, v27, v28, v23, v24, v25)
            del v23; del v26
        elif v21.tag == 1: # fold
            v34 = Closure29(v0, v1, v2, v3, v14, v10)
        elif v21.tag == 2: # raise
            v31 = v8 - 1
            v32 = v11 + 2
            v34 = method27(v0, v1, v2, v3, v4, v5, v6, v7, v31, v12, v13, v32, v9, v10, v11)
        v35 = v20 + v17
        v36 = US0_0(v21)
        v37 = UH0_0(v36, v18)
        del v36
        v38 = US0_0(v21)
        v39 = UH0_0(v38, v16)
        del v38
        return v34(Tuple5(v37, v19, v39, v35, v15))
cdef class Closure33():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef unsigned char v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef signed long v10
    cdef US2 v11
    cdef unsigned char v12
    cdef unsigned long v13
    cdef US2 v14
    cdef unsigned long v15
    def __init__(self, v0, v1, v2, v3, unsigned char v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, signed long v10, US2 v11, unsigned char v12, unsigned long v13, US2 v14, unsigned long v15): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15
    def __call__(self, Tuple5 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US2 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef unsigned long v13 = self.v13
        cdef US2 v14 = self.v14
        cdef unsigned long v15 = self.v15
        cdef UH0 v16 = args.v0
        cdef double v17 = args.v1
        cdef UH0 v18 = args.v2
        cdef double v19 = args.v3
        cdef object v20 = args.v4
        cdef bint v21
        cdef object v22
        cdef object v23
        cdef object v24
        cdef object v25
        cdef object v27
        cdef object v28
        cdef object v29
        cdef object v30
        v21 = v4 == 0
        if v21:
            v22 = v2(Tuple0(v16, v17))
            v23 = v22(v19)
            del v22
            v24 = v23(v5)
            del v23
            v25 = Closure34(v0, v1, v2, v3, v6, v7, v8, v9, v10, v11, v12, v13, v14, v4, v15, v20, v18, v19, v16, v17)
            return v24(v25)
        else:
            v27 = v0(Tuple0(v18, v19))
            v28 = v27(v17)
            del v27
            v29 = v28(v5)
            del v28
            v30 = Closure35(v0, v1, v2, v3, v6, v7, v8, v9, v10, v11, v12, v13, v14, v4, v15, v20, v18, v19, v16, v17)
            return v29(v30)
cdef class Closure24():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef signed long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef unsigned char v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef UH0 v17
    cdef double v18
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13, v14, UH0 v15, double v16, UH0 v17, double v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef double v18 = self.v18
        cdef double v19 = args.v0
        cdef US1 v20 = args.v1
        cdef object v33
        cdef bint v21
        cdef US2 v22
        cdef unsigned char v23
        cdef unsigned long v24
        cdef US2 v25
        cdef unsigned char v26
        cdef unsigned long v27
        cdef signed long v30
        cdef unsigned long v31
        cdef double v34
        cdef US0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef UH0 v38
        if v20.tag == 0: # call
            v21 = v13 == 0
            if v21:
                v22, v23, v24, v25, v26, v27 = v12, v13, v11, v9, v10, v11
            else:
                v22, v23, v24, v25, v26, v27 = v9, v10, v11, v12, v13, v11
            v33 = method23(v0, v1, v2, v3, v6, v4, v5, v7, v25, v26, v27, v22, v23, v24)
            del v22; del v25
        elif v20.tag == 1: # fold
            v33 = Closure29(v0, v1, v2, v3, v11, v10)
        elif v20.tag == 2: # raise
            v30 = v8 - 1
            v31 = v11 + 2
            v33 = method27(v0, v1, v2, v3, v4, v5, v6, v7, v30, v12, v13, v31, v9, v10, v11)
        v34 = v19 + v18
        v35 = US0_0(v20)
        v36 = UH0_0(v35, v17)
        del v35
        v37 = US0_0(v20)
        v38 = UH0_0(v37, v15)
        del v37
        return v33(Tuple5(v36, v34, v38, v16, v14))
cdef class Closure36():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef signed long v8
    cdef US2 v9
    cdef unsigned char v10
    cdef unsigned long v11
    cdef US2 v12
    cdef unsigned char v13
    cdef object v14
    cdef UH0 v15
    cdef double v16
    cdef UH0 v17
    cdef double v18
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13, v14, UH0 v15, double v16, UH0 v17, double v18): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14; self.v15 = v15; self.v16 = v16; self.v17 = v17; self.v18 = v18
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef signed long v8 = self.v8
        cdef US2 v9 = self.v9
        cdef unsigned char v10 = self.v10
        cdef unsigned long v11 = self.v11
        cdef US2 v12 = self.v12
        cdef unsigned char v13 = self.v13
        cdef object v14 = self.v14
        cdef UH0 v15 = self.v15
        cdef double v16 = self.v16
        cdef UH0 v17 = self.v17
        cdef double v18 = self.v18
        cdef double v19 = args.v0
        cdef US1 v20 = args.v1
        cdef object v33
        cdef bint v21
        cdef US2 v22
        cdef unsigned char v23
        cdef unsigned long v24
        cdef US2 v25
        cdef unsigned char v26
        cdef unsigned long v27
        cdef signed long v30
        cdef unsigned long v31
        cdef double v34
        cdef US0 v35
        cdef UH0 v36
        cdef US0 v37
        cdef UH0 v38
        if v20.tag == 0: # call
            v21 = v13 == 0
            if v21:
                v22, v23, v24, v25, v26, v27 = v12, v13, v11, v9, v10, v11
            else:
                v22, v23, v24, v25, v26, v27 = v9, v10, v11, v12, v13, v11
            v33 = method23(v0, v1, v2, v3, v6, v4, v5, v7, v25, v26, v27, v22, v23, v24)
            del v22; del v25
        elif v20.tag == 1: # fold
            v33 = Closure29(v0, v1, v2, v3, v11, v10)
        elif v20.tag == 2: # raise
            v30 = v8 - 1
            v31 = v11 + 2
            v33 = method27(v0, v1, v2, v3, v4, v5, v6, v7, v30, v12, v13, v31, v9, v10, v11)
        v34 = v19 + v16
        v35 = US0_0(v20)
        v36 = UH0_0(v35, v17)
        del v35
        v37 = US0_0(v20)
        v38 = UH0_0(v37, v15)
        del v37
        return v33(Tuple5(v36, v18, v38, v34, v14))
cdef class Closure23():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef unsigned char v4
    cdef object v5
    cdef object v6
    cdef object v7
    cdef object v8
    cdef object v9
    cdef signed long v10
    cdef US2 v11
    cdef unsigned char v12
    cdef unsigned long v13
    cdef US2 v14
    def __init__(self, v0, v1, v2, v3, unsigned char v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, signed long v10, US2 v11, unsigned char v12, unsigned long v13, US2 v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple5 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef unsigned char v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef numpy.ndarray[object,ndim=1] v6 = self.v6
        cdef numpy.ndarray[object,ndim=1] v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef signed long v10 = self.v10
        cdef US2 v11 = self.v11
        cdef unsigned char v12 = self.v12
        cdef unsigned long v13 = self.v13
        cdef US2 v14 = self.v14
        cdef UH0 v15 = args.v0
        cdef double v16 = args.v1
        cdef UH0 v17 = args.v2
        cdef double v18 = args.v3
        cdef object v19 = args.v4
        cdef bint v20
        cdef object v21
        cdef object v22
        cdef object v23
        cdef object v24
        cdef object v26
        cdef object v27
        cdef object v28
        cdef object v29
        v20 = v4 == 0
        if v20:
            v21 = v2(Tuple0(v15, v16))
            v22 = v21(v18)
            del v21
            v23 = v22(v5)
            del v22
            v24 = Closure24(v0, v1, v2, v3, v6, v7, v8, v9, v10, v11, v12, v13, v14, v4, v19, v17, v18, v15, v16)
            return v23(v24)
        else:
            v26 = v0(Tuple0(v17, v18))
            v27 = v26(v16)
            del v26
            v28 = v27(v5)
            del v27
            v29 = Closure36(v0, v1, v2, v3, v6, v7, v8, v9, v10, v11, v12, v13, v14, v4, v19, v17, v18, v15, v16)
            return v28(v29)
cdef class Closure22():
    cdef object v0
    cdef object v1
    cdef object v2
    cdef object v3
    cdef object v4
    cdef object v5
    cdef US2 v6
    cdef US2 v7
    cdef object v8
    cdef object v9
    cdef object v10
    cdef UH0 v11
    cdef double v12
    cdef UH0 v13
    cdef double v14
    def __init__(self, v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, US2 v6, US2 v7, numpy.ndarray[object,ndim=1] v8, numpy.ndarray[object,ndim=1] v9, v10, UH0 v11, double v12, UH0 v13, double v14): self.v0 = v0; self.v1 = v1; self.v2 = v2; self.v3 = v3; self.v4 = v4; self.v5 = v5; self.v6 = v6; self.v7 = v7; self.v8 = v8; self.v9 = v9; self.v10 = v10; self.v11 = v11; self.v12 = v12; self.v13 = v13; self.v14 = v14
    def __call__(self, Tuple2 args):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v2 = self.v2
        cdef object v3 = self.v3
        cdef numpy.ndarray[object,ndim=1] v4 = self.v4
        cdef numpy.ndarray[object,ndim=1] v5 = self.v5
        cdef US2 v6 = self.v6
        cdef US2 v7 = self.v7
        cdef numpy.ndarray[object,ndim=1] v8 = self.v8
        cdef numpy.ndarray[object,ndim=1] v9 = self.v9
        cdef object v10 = self.v10
        cdef UH0 v11 = self.v11
        cdef double v12 = self.v12
        cdef UH0 v13 = self.v13
        cdef double v14 = self.v14
        cdef double v15 = args.v0
        cdef US1 v16 = args.v1
        cdef object v29
        cdef signed long v17
        cdef unsigned char v18
        cdef unsigned long v19
        cdef unsigned char v20
        cdef signed long v23
        cdef unsigned char v24
        cdef unsigned long v25
        cdef unsigned char v26
        cdef unsigned long v27
        cdef double v30
        cdef US0 v31
        cdef UH0 v32
        cdef US0 v33
        cdef UH0 v34
        if v16.tag == 0: # call
            v17 = 2
            v18 = 1
            v19 = 1
            v20 = 0
            v29 = method22(v0, v1, v2, v3, v4, v5, v8, v9, v17, v6, v20, v19, v7, v18)
        elif v16.tag == 1: # fold
            raise Exception("impossible")
        elif v16.tag == 2: # raise
            v23 = 1
            v24 = 1
            v25 = 1
            v26 = 0
            v27 = 3
            v29 = method27(v0, v1, v2, v3, v4, v5, v8, v9, v23, v6, v26, v27, v7, v24, v25)
        v30 = v15 + v14
        v31 = US0_0(v16)
        v32 = UH0_0(v31, v13)
        del v31
        v33 = US0_0(v16)
        v34 = UH0_0(v33, v11)
        del v33
        return v29(Tuple5(v32, v30, v34, v12, v10))
cdef class Closure20():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef object v4
        cdef object v5
        cdef str v6
        cdef Tuple4 tmp1
        cdef US1 v7
        cdef US1 v8
        cdef numpy.ndarray[object,ndim=1] v9
        cdef US1 v10
        cdef US1 v11
        cdef US1 v12
        cdef numpy.ndarray[object,ndim=1] v13
        cdef US1 v14
        cdef US1 v15
        cdef numpy.ndarray[object,ndim=1] v16
        cdef US2 v17
        cdef US2 v18
        cdef US2 v19
        cdef US2 v20
        cdef US2 v21
        cdef US2 v22
        cdef numpy.ndarray[object,ndim=1] v23
        cdef unsigned long long v24
        cdef unsigned long long v25
        cdef UH0 v26
        cdef double v27
        cdef UH0 v28
        cdef double v29
        cdef object v30
        cdef US2 v31
        cdef unsigned long long v32
        cdef numpy.ndarray[object,ndim=1] v33
        cdef unsigned long long v34
        cdef double v35
        cdef double v36
        cdef double v37
        cdef unsigned char v38
        cdef UH0 v39
        cdef double v40
        cdef Tuple0 tmp2
        cdef unsigned char v41
        cdef UH0 v42
        cdef double v43
        cdef Tuple0 tmp3
        cdef unsigned long long v44
        cdef unsigned long long v45
        cdef US2 v46
        cdef unsigned long long v47
        cdef numpy.ndarray[object,ndim=1] v48
        cdef unsigned long long v49
        cdef double v50
        cdef double v51
        cdef double v52
        cdef unsigned char v53
        cdef UH0 v54
        cdef double v55
        cdef Tuple0 tmp4
        cdef unsigned char v56
        cdef UH0 v57
        cdef double v58
        cdef Tuple0 tmp5
        cdef object v59
        cdef object v60
        cdef object v61
        cdef object v62
        cdef double v63
        cdef str v64
        cdef str v65
        tmp1 = v0.value
        v2, v3, v4, v5, v6 = tmp1.v0, tmp1.v1, tmp1.v2, tmp1.v3, tmp1.v4
        del tmp1
        v7 = US1_0()
        v8 = US1_2()
        v9 = numpy.empty(2,dtype=object)
        v9[0] = v7; v9[1] = v8
        del v7; del v8
        v10 = US1_1()
        v11 = US1_0()
        v12 = US1_2()
        v13 = numpy.empty(3,dtype=object)
        v13[0] = v10; v13[1] = v11; v13[2] = v12
        del v10; del v11; del v12
        v14 = US1_1()
        v15 = US1_0()
        v16 = numpy.empty(2,dtype=object)
        v16[0] = v14; v16[1] = v15
        del v14; del v15
        v17 = US2_1()
        v18 = US2_2()
        v19 = US2_0()
        v20 = US2_1()
        v21 = US2_2()
        v22 = US2_0()
        v23 = numpy.empty(6,dtype=object)
        v23[0] = v17; v23[1] = v18; v23[2] = v19; v23[3] = v20; v23[4] = v21; v23[5] = v22
        del v17; del v18; del v19; del v20; del v21; del v22
        v24 = len(v23)
        v25 = numpy.random.randint(0,v24)
        v26 = UH0_1()
        v27 = 0.000000
        v28 = UH0_1()
        v29 = 0.000000
        v30 = Closure21()
        v31 = v23[v25]
        v32 = v24 - 1
        v33 = numpy.empty(v32,dtype=object)
        v34 = 0
        method19(v32, v25, v23, v33, v34)
        del v23
        v35 = <double>v24
        v36 = 1.000000 / v35
        v37 = libc.math.log(v36)
        v38 = 0
        tmp2 = method20(v31, v37, v38, v26, v27)
        v39, v40 = tmp2.v0, tmp2.v1
        del tmp2
        del v26
        v41 = 1
        tmp3 = method20(v31, v37, v41, v28, v29)
        v42, v43 = tmp3.v0, tmp3.v1
        del tmp3
        del v28
        v44 = len(v33)
        v45 = numpy.random.randint(0,v44)
        v46 = v33[v45]
        v47 = v44 - 1
        v48 = numpy.empty(v47,dtype=object)
        v49 = 0
        method19(v47, v45, v33, v48, v49)
        del v33
        v50 = <double>v44
        v51 = 1.000000 / v50
        v52 = libc.math.log(v51)
        v53 = 0
        tmp4 = method21(v46, v52, v53, v39, v40)
        v54, v55 = tmp4.v0, tmp4.v1
        del tmp4
        del v39
        v56 = 1
        tmp5 = method21(v46, v52, v56, v42, v43)
        v57, v58 = tmp5.v0, tmp5.v1
        del tmp5
        del v42
        v59 = v2(Tuple0(v54, v55))
        v60 = v59(v58)
        del v59
        v61 = v60(v9)
        del v60
        v62 = Closure22(v4, v5, v2, v3, v13, v16, v31, v46, v9, v48, v30, v57, v58, v54, v55)
        del v9; del v13; del v16; del v30; del v31; del v46; del v48; del v54; del v57
        v63 = v61(v62)
        del v61; del v62
        v64 = f"Reward for player one is {v63}.\n"
        v65 = v6 + v64
        del v6; del v64
        v0.on_next(Tuple4(v2, v3, v4, v5, v65))
cdef class Closure19():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        v2 = v1
        del v2
        pass # import kivy.clock
        v3 = Closure20(v0)
        kivy.clock.Clock.schedule_once(v3)
cdef class Closure37():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("on_press",v1)
cdef class Closure18():
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
        v2 = v1[0]
        pass # import kivy.uix.button
        v3 = kivy.uix.button.Button()
        pass # import rx.disposable
        v4 = rx.disposable.compositedisposable.CompositeDisposable()
        v3.text = "Start Game."
        v5 = Closure19(v0)
        v6 = v3.fbind("on_press",v5)
        del v5
        pass # import rx.disposable
        v7 = Closure37(v3, v6)
        del v6
        v8 = rx.disposable.disposable.Disposable(v7)
        del v7
        v4.add(v8)
        del v8
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class Closure39():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, numpy.ndarray[unsigned long long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[unsigned long long,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US3 v4
        cdef unsigned long long v5
        cdef object v6
        cdef unsigned long long v7
        cdef US3 v8
        v4 = v2[0]
        if v4.tag == 0: # none
            v5 = 0
            method18(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US3_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[0]
        v0.add_widget(v3,v7)
        v8 = US3_1(v3)
        v2[0] = v8
cdef class Closure38():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef object v4
        cdef numpy.ndarray[unsigned long long,ndim=1] v5
        cdef unsigned long long v6
        cdef numpy.ndarray[object,ndim=1] v7
        cdef unsigned long long v8
        cdef object v9
        cdef object v10
        cdef object v11
        v2 = v1[0]
        pass # import kivy.uix.boxlayout
        v3 = kivy.uix.boxlayout.BoxLayout()
        pass # import rx.disposable
        v4 = rx.disposable.compositedisposable.CompositeDisposable()
        v3.orientation = 'horizontal'
        v3.size_hint_y = 0.200000
        v5 = numpy.empty(1,dtype=numpy.uint64)
        v6 = 0
        method16(v5, v6)
        v7 = numpy.empty(1,dtype=object)
        v8 = 0
        method17(v7, v8)
        pass # import rx.disposable
        v9 = rx.disposable.compositedisposable.CompositeDisposable()
        v10 = Closure39(v3, v5, v7)
        del v5; del v7
        v11 = v0.subscribe(v10)
        del v10
        v9.add(v11)
        del v11
        v4.add(v9)
        del v9
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class Closure41():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, numpy.ndarray[unsigned long long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[unsigned long long,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US3 v4
        cdef unsigned long long v5
        cdef object v6
        cdef unsigned long long v7
        cdef US3 v8
        v4 = v2[1]
        if v4.tag == 0: # none
            v5 = 0
            method30(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US3_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[1]
        v0.add_widget(v3,v7)
        v8 = US3_1(v3)
        v2[1] = v8
cdef class Closure40():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self, * v2):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        cdef object v3
        cdef object v4
        cdef object v5
        cdef numpy.ndarray[unsigned long long,ndim=1] v6
        cdef unsigned long long v7
        cdef numpy.ndarray[object,ndim=1] v8
        cdef unsigned long long v9
        cdef object v10
        cdef object v11
        cdef object v12
        cdef object v13
        cdef object v14
        v3 = v2[0]
        pass # import kivy.uix.boxlayout
        v4 = kivy.uix.boxlayout.BoxLayout()
        pass # import rx.disposable
        v5 = rx.disposable.compositedisposable.CompositeDisposable()
        v4.orientation = 'vertical'
        v6 = numpy.empty(2,dtype=numpy.uint64)
        v7 = 0
        method28(v6, v7)
        v8 = numpy.empty(2,dtype=object)
        v9 = 0
        method29(v8, v9)
        pass # import rx.disposable
        v10 = rx.disposable.compositedisposable.CompositeDisposable()
        v11 = Closure39(v4, v6, v8)
        v12 = v0.subscribe(v11)
        del v11
        v10.add(v12)
        del v12
        v13 = Closure41(v4, v6, v8)
        del v6; del v8
        v14 = v1.subscribe(v13)
        del v13
        v10.add(v14)
        del v14
        v5.add(v10)
        del v10
        v3.on_next(v4)
        del v3; del v4
        return v5
cdef class Closure42():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        v0.root = v1
cdef UH0 method1(UH0 v0, UH0 v1):
    cdef US0 v2
    cdef UH0 v3
    cdef UH0 v4
    if v0.tag == 0: # cons_
        v2 = (<UH0_0>v0).v0; v3 = (<UH0_0>v0).v1
        v4 = UH0_0(v2, v1)
        del v2
        return method1(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef UH1 method3(UH1 v0, UH1 v1):
    cdef US1 v2
    cdef UH1 v3
    cdef UH1 v4
    if v0.tag == 0: # cons_
        v2 = (<UH1_0>v0).v0; v3 = (<UH1_0>v0).v1
        v4 = UH1_0(v2, v1)
        del v2
        return method3(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method5(UH1 v0, unsigned long long v1):
    cdef UH1 v3
    cdef unsigned long long v4
    if v0.tag == 0: # cons_
        v3 = (<UH1_0>v0).v1
        v4 = v1 + 1
        return method5(v3, v4)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method6(numpy.ndarray[object,ndim=1] v0, UH1 v1, unsigned long long v2):
    cdef US1 v3
    cdef UH1 v4
    cdef unsigned long long v5
    if v1.tag == 0: # cons_
        v3 = (<UH1_0>v1).v0; v4 = (<UH1_0>v1).v1
        v0[v2] = v3
        del v3
        v5 = v2 + 1
        return method6(v0, v4, v5)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method4(UH1 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method5(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method6(v3, v0, v4)
    return v3
cdef UH2 method2(UH1 v0, US2 v1, UH0 v2):
    cdef US0 v3
    cdef UH0 v4
    cdef US1 v5
    cdef UH1 v6
    cdef US2 v8
    cdef UH1 v9
    cdef UH1 v10
    cdef numpy.ndarray[object,ndim=1] v11
    cdef UH1 v12
    cdef UH2 v13
    cdef UH1 v16
    cdef UH1 v17
    cdef numpy.ndarray[object,ndim=1] v18
    cdef UH2 v19
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            v5 = (<US0_0>v3).v0
            v6 = UH1_0(v5, v0)
            del v5
            return method2(v6, v1, v4)
        elif v3.tag == 1: # observation_
            v8 = (<US0_1>v3).v0
            v9 = UH1_1()
            v10 = method3(v0, v9)
            del v9
            v11 = method4(v10)
            del v10
            v12 = UH1_1()
            v13 = method2(v12, v8, v4)
            del v4; del v8; del v12
            return UH2_0(v1, v11, v13)
    elif v2.tag == 1: # nil
        v16 = UH1_1()
        v17 = method3(v0, v16)
        del v16
        v18 = method4(v17)
        del v17
        v19 = UH2_1()
        return UH2_0(v1, v18, v19)
cdef unsigned long long method8(UH2 v0, unsigned long long v1):
    cdef UH2 v4
    cdef unsigned long long v5
    if v0.tag == 0: # cons_
        v4 = (<UH2_0>v0).v2
        v5 = v1 + 1
        return method8(v4, v5)
    elif v0.tag == 1: # nil
        return v1
cdef unsigned long long method9(numpy.ndarray[object,ndim=1] v0, UH2 v1, unsigned long long v2):
    cdef US2 v3
    cdef numpy.ndarray[object,ndim=1] v4
    cdef UH2 v5
    cdef unsigned long long v6
    if v1.tag == 0: # cons_
        v3 = (<UH2_0>v1).v0; v4 = (<UH2_0>v1).v1; v5 = (<UH2_0>v1).v2
        v0[v2] = Tuple1(v3, v4)
        del v3; del v4
        v6 = v2 + 1
        return method9(v0, v5, v6)
    elif v1.tag == 1: # nil
        return v2
cdef numpy.ndarray[object,ndim=1] method7(UH2 v0):
    cdef unsigned long long v1
    cdef unsigned long long v2
    cdef numpy.ndarray[object,ndim=1] v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    v1 = 0
    v2 = method8(v0, v1)
    v3 = numpy.empty(v2,dtype=object)
    v4 = 0
    v5 = method9(v3, v0, v4)
    return v3
cdef numpy.ndarray[object,ndim=1] method0(UH0 v0):
    cdef UH0 v1
    cdef UH0 v2
    cdef US0 v3
    cdef UH0 v4
    cdef US2 v7
    cdef UH1 v8
    cdef UH2 v9
    v1 = UH0_1()
    v2 = method1(v0, v1)
    del v1
    if v2.tag == 0: # cons_
        v3 = (<UH0_0>v2).v0; v4 = (<UH0_0>v2).v1
        if v3.tag == 0: # action_
            del v4
            raise Exception("Expected a card.")
        elif v3.tag == 1: # observation_
            v7 = (<US0_1>v3).v0
            v8 = UH1_1()
            v9 = method2(v8, v7, v4)
            del v4; del v7; del v8
            return method7(v9)
    elif v2.tag == 1: # nil
        raise Exception("Expected a card.")
cdef void method10(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2):
    cdef bint v3
    cdef unsigned long long v4
    v3 = v2 < v0
    if v3:
        v4 = v2 + 1
        v1[v2] = 0.000000
        method10(v0, v1, v4)
    else:
        pass
cdef void method12(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, unsigned long long v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef US1 v7
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    v5 = v4 < v0
    if v5:
        v6 = v4 + 1
        v7 = v3[v4]
        v8 = v4 * 3
        v9 = v2 + v8
        if v7.tag == 0: # call
            v1[v9] = 1.000000
        elif v7.tag == 1: # fold
            v10 = v9 + 1
            v1[v10] = 1.000000
        elif v7.tag == 2: # raise
            v11 = v9 + 2
            v1[v11] = 1.000000
        del v7
        method12(v0, v1, v2, v3, v6)
    else:
        pass
cdef void method11(unsigned long long v0, numpy.ndarray[float,ndim=1] v1, numpy.ndarray[object,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US2 v6
    cdef numpy.ndarray[object,ndim=1] v7
    cdef Tuple1 tmp0
    cdef unsigned long long v8
    cdef unsigned long long v9
    cdef unsigned long long v10
    cdef unsigned long long v11
    cdef unsigned long long v12
    cdef bint v13
    cdef unsigned long long v14
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        tmp0 = v2[v3]
        v6, v7 = tmp0.v0, tmp0.v1
        del tmp0
        v8 = v3 * 15
        if v6.tag == 0: # jack
            v1[v8] = 1.000000
        elif v6.tag == 1: # king
            v9 = v8 + 1
            v1[v9] = 1.000000
        elif v6.tag == 2: # queen
            v10 = v8 + 2
            v1[v10] = 1.000000
        del v6
        v11 = v8 + 3
        v12 = len(v7)
        v13 = 4 < v12
        if v13:
            raise Exception("The given array is too large.")
        else:
            pass
        v14 = 0
        method12(v12, v1, v11, v7, v14)
        del v7
        method11(v0, v1, v2, v5)
    else:
        pass
cdef signed long long method14(US1 v0):
    cdef signed long long v1
    if v0.tag == 0: # call
        v1 = 0
    elif v0.tag == 1: # fold
        v1 = 1
    elif v0.tag == 2: # raise
        v1 = 2
    return v1
cdef void method13(unsigned long long v0, numpy.ndarray[object,ndim=1] v1, numpy.ndarray[signed long long,ndim=1] v2, unsigned long long v3):
    cdef bint v4
    cdef unsigned long long v5
    cdef US1 v6
    cdef signed long long v7
    v4 = v3 < v0
    if v4:
        v5 = v3 + 1
        v6 = v1[v3]
        v7 = method14(v6)
        del v6
        v2[v3] = v7
        method13(v0, v1, v2, v5)
    else:
        pass
cdef US1 method15(signed long long v0):
    cdef bint v1
    cdef bint v2
    cdef bint v3
    cdef bint v4
    cdef bint v5
    cdef bint v7
    cdef signed long long v8
    cdef bint v9
    cdef bint v10
    cdef signed long long v12
    cdef bint v13
    cdef bint v14
    v1 = v0 < 3
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
        return US1_0()
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
            return US1_1()
        else:
            if v1:
                v12 = v0 - 2
                v13 = v12 == 0
                v14 = v13 == 0
                if v14:
                    raise Exception("The unit index should be 0.")
                else:
                    pass
                return US1_2()
            else:
                raise Exception("Unpickling of an union failed.")
cdef void method16(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    v2 = v1 < 1
    if v2:
        v3 = v1 + 1
        v0[v1] = 0
        method16(v0, v3)
    else:
        pass
cdef void method17(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef US3 v4
    v2 = v1 < 1
    if v2:
        v3 = v1 + 1
        v4 = US3_0()
        v0[v1] = v4
        del v4
        method17(v0, v3)
    else:
        pass
cdef void method18(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
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
        method18(v0, v3)
    else:
        pass
cdef void method19(unsigned long long v0, unsigned long long v1, numpy.ndarray[object,ndim=1] v2, numpy.ndarray[object,ndim=1] v3, unsigned long long v4):
    cdef bint v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    cdef US2 v9
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
        method19(v0, v1, v2, v3, v6)
    else:
        pass
cdef Tuple0 method20(US2 v0, double v1, unsigned char v2, UH0 v3, double v4):
    cdef bint v5
    cdef double v6
    cdef US0 v7
    cdef UH0 v8
    v5 = 0 == v2
    if v5:
        v6 = v1 + v4
        v7 = US0_1(v0)
        v8 = UH0_0(v7, v3)
        del v7
        return Tuple0(v8, v6)
    else:
        return Tuple0(v3, v4)
cdef Tuple0 method21(US2 v0, double v1, unsigned char v2, UH0 v3, double v4):
    cdef bint v5
    cdef double v6
    cdef US0 v7
    cdef UH0 v8
    v5 = 1 == v2
    if v5:
        v6 = v1 + v4
        v7 = US0_1(v0)
        v8 = UH0_0(v7, v3)
        del v7
        return Tuple0(v8, v6)
    else:
        return Tuple0(v3, v4)
cdef bint method25(signed long v0, signed long v1):
    return v1 == v0
cdef Tuple6 method26(signed long v0, signed long v1):
    cdef bint v2
    v2 = v1 > v0
    if v2:
        return Tuple6(v1, v0)
    else:
        return Tuple6(v0, v1)
cdef object method24(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, signed long v6, US2 v7, US2 v8, unsigned char v9, unsigned long v10, US2 v11, unsigned char v12, unsigned long v13):
    cdef bint v14
    cdef numpy.ndarray[object,ndim=1] v15
    v14 = 0 < v6
    if v14:
        v15 = v4
    else:
        v15 = v5
    return Closure27(v0, v1, v2, v3, v12, v15, v4, v5, v6, v7, v8, v9, v10, v11, v13)
cdef object method23(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, US2 v8, unsigned char v9, unsigned long v10, US2 v11, unsigned char v12, unsigned long v13):
    cdef unsigned long long v14
    cdef unsigned long long v15
    v14 = len(v7)
    v15 = numpy.random.randint(0,v14)
    return Closure25(v15, v7, v0, v1, v2, v3, v4, v5, v6, v8, v9, v10, v11, v12, v13)
cdef object method27(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13, unsigned long v14):
    cdef bint v15
    cdef numpy.ndarray[object,ndim=1] v16
    v15 = 0 < v8
    if v15:
        v16 = v4
    else:
        v16 = v5
    return Closure33(v0, v1, v2, v3, v13, v16, v4, v5, v6, v7, v8, v9, v10, v11, v12, v14)
cdef object method22(v0, v1, v2, v3, numpy.ndarray[object,ndim=1] v4, numpy.ndarray[object,ndim=1] v5, numpy.ndarray[object,ndim=1] v6, numpy.ndarray[object,ndim=1] v7, signed long v8, US2 v9, unsigned char v10, unsigned long v11, US2 v12, unsigned char v13):
    cdef bint v14
    cdef numpy.ndarray[object,ndim=1] v15
    v14 = 0 < v8
    if v14:
        v15 = v4
    else:
        v15 = v5
    return Closure23(v0, v1, v2, v3, v13, v15, v4, v5, v6, v7, v8, v9, v10, v11, v12)
cdef void method28(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    v2 = v1 < 2
    if v2:
        v3 = v1 + 1
        v0[v1] = 0
        method28(v0, v3)
    else:
        pass
cdef void method29(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef US3 v4
    v2 = v1 < 2
    if v2:
        v3 = v1 + 1
        v4 = US3_0()
        v0[v1] = v4
        del v4
        method29(v0, v3)
    else:
        pass
cdef void method30(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v2 = v1 < 1
    if v2:
        v3 = v1 + 1
        v4 = 0 - v1
        v5 = v0[v4]
        v6 = v5 + 1
        v0[v4] = v6
        method30(v0, v3)
    else:
        pass
cpdef void main():
    cdef object v0
    cdef object v1
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
    cdef object v15
    cdef object v16
    cdef object v17
    cdef object v18
    pass # import kivy.app
    v0 = kivy.app.App()
    pass # import nets
    v1 = nets.small(30,64,3)
    pass # import rx.subject
    v2 = Closure0(v1)
    del v1
    v3 = Closure4()
    v4 = Closure6()
    v5 = Closure10()
    v6 = rx.subject.behaviorsubject.BehaviorSubject(Tuple4(v2, v3, v4, v5, ""))
    del v2; del v3; del v4; del v5
    pass # import rx
    v7 = Closure12(v6)
    v8 = rx.create(v7)
    del v7
    pass # import rx
    v9 = Closure16(v8)
    del v8
    v10 = rx.create(v9)
    del v9
    pass # import rx
    v11 = Closure18(v6)
    del v6
    v12 = rx.create(v11)
    del v11
    pass # import rx
    v13 = Closure38(v12)
    del v12
    v14 = rx.create(v13)
    del v13
    pass # import rx
    v15 = Closure40(v10, v14)
    del v10; del v14
    v16 = rx.create(v15)
    del v15
    v17 = Closure42(v0)
    v18 = v16.subscribe(v17)
    del v16; del v17; del v18
    v0.run()
