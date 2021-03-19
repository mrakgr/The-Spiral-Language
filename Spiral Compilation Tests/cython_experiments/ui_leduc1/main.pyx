import kivy.app
import rx.subject
import rx
import kivy.uix.label
import rx.disposable
import kivy.uix.button
import kivy.clock
import kivy.uix.boxlayout
import numpy
cimport numpy
cdef class Closure1():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, unsigned long v1):
        cdef object v0 = self.v0
        cdef bint v2
        cdef str v4
        v2 = v1 == 0
        if v2:
            v4 = "Press the button."
        else:
            v4 = f"The button has been clicked {v1} times."
        v0.text = v4
cdef class Closure0():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, * v1):
        cdef object v0 = self.v0
        cdef object v2
        cdef object v3
        cdef object v4
        cdef object v5
        cdef object v6
        v2 = v1[0]
        pass # import kivy.uix.label
        v3 = kivy.uix.label.Label()
        pass # import rx.disposable
        v4 = rx.disposable.compositedisposable.CompositeDisposable()
        v5 = Closure1(v3)
        v6 = v0.subscribe(v5)
        del v5
        v4.add(v6)
        del v6
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class Closure4():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        cdef unsigned long v2
        cdef unsigned long v3
        v2 = v0.value
        v3 = 1 + v2
        v0.on_next(v3)
cdef class Closure3():
    cdef object v0
    def __init__(self, v0): self.v0 = v0
    def __call__(self, object v1):
        cdef object v0 = self.v0
        cdef object v2
        pass # import kivy.clock
        v2 = Closure4(v0)
        kivy.clock.Clock.schedule_once(v2)
cdef class Closure5():
    cdef object v0
    cdef object v1
    def __init__(self, v0, v1): self.v0 = v0; self.v1 = v1
    def __call__(self):
        cdef object v0 = self.v0
        cdef object v1 = self.v1
        v0.unbind_uid("on_press",v1)
cdef class Closure2():
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
        v3.text = "Click me."
        v5 = Closure3(v0)
        v6 = v3.fbind("on_press",v5)
        del v5
        pass # import rx.disposable
        v7 = Closure5(v3, v6)
        del v6
        v8 = rx.disposable.disposable.Disposable(v7)
        del v7
        v4.add(v8)
        del v8
        v2.on_next(v3)
        del v2; del v3
        return v4
cdef class US0:
    cdef readonly signed long tag
cdef class US0_0(US0): # none
    def __init__(self): self.tag = 0
cdef class US0_1(US0): # some_
    cdef readonly object v0
    def __init__(self, v0): self.tag = 1; self.v0 = v0
cdef class Closure7():
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
        method0(v5, v6)
        v7 = numpy.empty(1,dtype=object)
        v8 = 0
        method1(v7, v8)
        pass # import rx.disposable
        v9 = rx.disposable.compositedisposable.CompositeDisposable()
        v10 = Closure7(v3, v5, v7)
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
cdef class Closure9():
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
            v5 = 0
            method5(v1, v5)
        elif v4.tag == 1: # some_
            v6 = (<US0_1>v4).v0
            v0.remove_widget(v6)
            del v6
        del v4
        v7 = v1[1]
        v0.add_widget(v3,v7)
        v8 = US0_1(v3)
        v2[1] = v8
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
        method3(v6, v7)
        v8 = numpy.empty(2,dtype=object)
        v9 = 0
        method4(v8, v9)
        pass # import rx.disposable
        v10 = rx.disposable.compositedisposable.CompositeDisposable()
        v11 = Closure7(v4, v6, v8)
        v12 = v0.subscribe(v11)
        del v11
        v10.add(v12)
        del v12
        v13 = Closure9(v4, v6, v8)
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
cdef class Closure10():
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
    cdef US0 v4
    v2 = v1 < 1
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
cdef void method3(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    v2 = v1 < 2
    if v2:
        v3 = v1 + 1
        v0[v1] = 0
        method3(v0, v3)
    else:
        pass
cdef void method4(numpy.ndarray[object,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef US0 v4
    v2 = v1 < 2
    if v2:
        v3 = v1 + 1
        v4 = US0_0()
        v0[v1] = v4
        del v4
        method4(v0, v3)
    else:
        pass
cdef void method5(numpy.ndarray[unsigned long long,ndim=1] v0, unsigned long long v1):
    cdef bint v2
    cdef unsigned long long v3
    cdef unsigned long long v4
    cdef unsigned long long v5
    cdef unsigned long long v6
    v2 = v1 < 1
    if v2:
        v3 = v1 + 1
        v4 =  -v1
        v5 = v0[v4]
        v6 = v5 + 1
        v0[v4] = v6
        method5(v0, v3)
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
    pass # import kivy.app
    v0 = kivy.app.App()
    pass # import rx.subject
    v1 = rx.subject.behaviorsubject.BehaviorSubject(0)
    pass # import rx
    v2 = Closure0(v1)
    v3 = rx.create(v2)
    del v2
    pass # import rx
    v4 = Closure2(v1)
    del v1
    v5 = rx.create(v4)
    del v4
    pass # import rx
    v6 = Closure6(v5)
    del v5
    v7 = rx.create(v6)
    del v6
    pass # import rx
    v8 = Closure8(v3, v7)
    del v3; del v7
    v9 = rx.create(v8)
    del v8
    v10 = Closure10(v0)
    v11 = v9.subscribe(v10)
    del v9; del v10; del v11
    v0.run()
