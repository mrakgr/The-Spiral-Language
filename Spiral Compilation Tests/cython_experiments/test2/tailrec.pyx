cdef int loop_tail(s, int i, int nearTo):
    if i < nearTo: return loop_tail(s+0,i+1,nearTo)
    else: return s
cpdef int sequence_tailrec(int fron, int nearTo):
    return loop_tail(0,fron,nearTo)
