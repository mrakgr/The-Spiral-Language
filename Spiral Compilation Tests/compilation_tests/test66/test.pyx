cpdef str main():
    cdef unsigned char v0
    cdef bint v1
    cdef bint v2
    cdef bint v3
    v0 = (<unsigned char>0)
    v1 = (<unsigned char>0) == v0
    if v1:
        return "qwe"
    else:
        v2 = (<unsigned char>1) == v0
        if v2:
            return "asd"
        else:
            v3 = (<unsigned char>2) == v0
            if v3:
                return "asd"
            else:
                return "zxc"
