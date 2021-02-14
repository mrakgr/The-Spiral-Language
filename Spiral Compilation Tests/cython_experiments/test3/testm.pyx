from cpython.ref cimport PyObject, Py_DECREF, Py_INCREF

cdef inline PyObject* getPyObject(object o):
    Py_INCREF(o)  # Cython will always put a decref in on "o" so need to counteract it
    return <PyObject*>o

# In a separate function to keep all Python temp cleanup code out of loop_tail
cdef PyObject* splus0(PyObject* s) except NULL:
    return getPyObject(<object>s+0)

cdef PyObject* loop_tail(PyObject* s, int i, int nearTo):
    cdef PyObject *n
    if i < nearTo:
        n = splus0(s)
        Py_DECREF(<object>s)
        return loop_tail(n, i+1, nearTo)
    else:
        return s

def run_loop_tail(s, i, nearTo):
    # When in tail-end position, s should not be incref'd.
    return <object>loop_tail(<PyObject*>s, i, nearTo)

def main(): return run_loop_tail(0,0,1_000_000_000)