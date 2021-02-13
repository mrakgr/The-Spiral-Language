import sys
from cpython.ref cimport PyObject, Py_INCREF, Py_DECREF, Py_CLEAR, Py_XDECREF, Py_XINCREF
cdef PyObject * loop_tail(PyObject * s, int i, int nearTo):
    cdef PyObject * n
    if i < nearTo: 
        n = <PyObject *>((<object> s) + 0)
        Py_DECREF(s)
        return loop_tail(n,i+1,nearTo)
    else: return s

# def test(s):
#     print(sys.getrefcount(s)) # 1
#     Py_INCREF(s)
#     t = loop_tail(s,0,0)
#     Py_DECREF(t); del t
#     print(sys.getrefcount(s)) # 1
#     Py_INCREF(s)
#     t = loop_tail(s,0,0)
#     Py_DECREF(t); del t
#     print(sys.getrefcount(s)) # 1
#     Py_INCREF(s)
#     t = loop_tail(s,0,0)
#     Py_DECREF(t); del t
#     print(sys.getrefcount(s)) # 1

# def test2(s):
#     print(sys.getrefcount(s)) # 1
#     Py_INCREF(s)
#     t = loop_tail(s,0,1)
#     Py_DECREF(t); del t
#     print(sys.getrefcount(s)) # 1
#     Py_INCREF(s)
#     t = loop_tail(s,0,1)
#     Py_DECREF(t); del t
#     print(sys.getrefcount(s)) # 1
#     Py_INCREF(s)
#     t = loop_tail(s,0,1)
#     Py_DECREF(t); del t
#     print(sys.getrefcount(s)) # 1

def main():
    # test(1234)
    pass

