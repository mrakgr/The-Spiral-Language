cimport cython
cpdef void main():
    cdef object [::1] v0 = cython.view.array(shape=(0,), itemsize=sizeof(void *), format='O')
