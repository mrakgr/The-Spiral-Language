import rx
import rx.operators
import rx.disposable
import kivy.app
import kivy.uix.label
import kivy.uix.button
import kivy.uix.boxlayout
import numpy
cimport numpy
cdef class Closure0():
    def __init__(self): pass
    def __call__(self, * v0):
        cdef object v1
        cdef object v2
        cdef object v3
        v1 = v0[0]
        pass # import kivy.uix.label
        v2 = kivy.uix.label.Label()
        v3 = rx.disposable.compositedisposable.CompositeDisposable()
        v2.text = "Press the button."
        v1.on_next(v2)
        del v1; del v2
        return v3
cdef class Closure2():
    def __init__(self): pass
    def __call__(self, object v0):
        print("The button has been pressed.")
cdef class Closure3():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("on_press",v1)
cdef class Closure1():
    def __init__(self): pass
    def __call__(self, * v0):
        cdef object v1
        cdef object v2
        cdef object v3
        cdef object v4
        cdef object v5
        cdef object v6
        cdef object v7
        v1 = v0[0]
        pass # import kivy.uix.button
        v2 = kivy.uix.button.Button()
        v3 = rx.disposable.compositedisposable.CompositeDisposable()
        v2.text = "Press me."
        v4 = Closure2()
        v5 = v2.fbind("on_press",v4)
        del v4
        v6 = Closure3(v2, v5)
        del v5
        v7 = rx.disposable.disposable.Disposable(v6)
        del v6
        v3.add(v7)
        del v7
        v1.on_next(v2)
        del v1; del v2
        return v3
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # none
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # some_
    cdef readonly object v0
    def __init__(self, v0): self.tag = 1; self.v0 = v0
cdef class Closure5():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, numpy.ndarray[unsigned long long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[unsigned long long,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US0 v4
        cdef unsigned long long v5
        cdef object v6
        cdef unsigned long long v7
        cdef US0 v8
        v4 = v2[0]
        if v4.tag == 0: # none
            v5 = 0
            method2(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US0_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[0]
        v0.add_widget(v3,v7)
        v8 = US0_1(v3)
        v2[0] = v8
cdef class Closure6():
    cdef object v0
    cdef object v1
    cdef object v2
    def __init__(self, v0, numpy.ndarray[unsigned long long,ndim=1] v1, numpy.ndarray[object,ndim=1] v2): self.v0 = v0; self.v1 = v1; self.v2 = v2
    def __call__(self, object v3):
        cdef object v0 = self.v0
        cdef numpy.ndarray[unsigned long long,ndim=1] v1 = self.v1
        cdef numpy.ndarray[object,ndim=1] v2 = self.v2
        cdef US0 v4
        cdef unsigned long long v5
        cdef object v6
        cdef unsigned long long v7
        cdef US0 v8
        v4 = v2[1]
        if v4.tag == 0: # none
            v5 = 1
            method3(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US0_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[1]
        v0.add_widget(v3,v7)
        v8 = US0_1(v3)
        v2[1] = v8
cdef class Closure4():
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
        v5 = rx.disposable.compositedisposable.CompositeDisposable()
        v4.orientation = 'vertical'
        v6 = numpy.empty(2,dtype=numpy.uint64)
        v7 = 0
        method0(v6, v7)
        v8 = numpy.empty(2,dtype=object)
        v9 = 0
        method1(v8, v9)
        v10 = rx.disposable.compositedisposable.CompositeDisposable()
        v11 = Closure5(v4, v6, v8)
        v12 = v0.subscribe(v11)
        del v11
        v10.add(v12)
        del v12
        v13 = Closure6(v4, v6, v8)
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
cdef class Closure7():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        v0.root = v1
cdef void method0(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    v2 = v1 < 2
    if v2:
        v3 = v1 + 1
        v0[v1] = 0
        method0(v0, v3)
    else:
        pass
cdef void method1(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef US0 v4
    v2 = v1 < 2
    if v2:
        v3 = v1 + 1
        v4 = US0_0()
        v0[v1] = v4
        del v4
        method1(v0, v3)
    else:
        pass
cdef void method2(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    v2 = 0 <= v1
    if v2:
        v4 = v1 < 0
    else:
        v4 = 0
    if v4:
        v5 = v0[v1]
        v6 = v5 + 1
        v0[v1] = v6
    else:
        pass
    v7 = 0 < v1
    if v7:
        v8 = v1 - 1
        method2(v0, v8)
    else:
        pass
cdef void method3(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef bint v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    cdef bint v7
    cdef unsigned long long v8
    v2 = 0 <= v1
    if v2:
        v4 = v1 < 1
    else:
        v4 = 0
    if v4:
        v5 = v0[v1]
        v6 = v5 + 1
        v0[v1] = v6
    else:
        pass
    v7 = 0 < v1
    if v7:
        v8 = v1 - 1
        method3(v0, v8)
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
    pass # import rx
    pass # import rx.operators
    pass # import rx.disposable
    pass # import kivy.app
    v0 = kivy.app.App()
    v1 = Closure0()
    v2 = rx.create(v1)
    del v1
    v3 = Closure1()
    v4 = rx.create(v3)
    del v3
    v5 = Closure4(v2, v4)
    del v2; del v4
    v6 = rx.create(v5)
    del v5
    v7 = Closure7(v0)
    v8 = v6.subscribe(v7)
    del v6; del v7; del v8
    v0.run()
