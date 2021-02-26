import kivy.app
import kivy.uix.button
cpdef void main():
    cdef object v0
    cdef object v1
    pass # import kivy.app
    v0 = kivy.app.App()
    pass # import kivy.uix.button
    v1 = kivy.uix.button.Button()
    v1.text = "Hello World"
    v0.root = v1
    del v1
    v0.run()
