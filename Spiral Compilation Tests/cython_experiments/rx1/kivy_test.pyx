import numpy
cimport numpy
def main():
    cdef bint x = 1
    y = numpy.empty(1,dtype=numpy.int8)
    y[0] = x
    cdef bint q = y[0]
    print(q)