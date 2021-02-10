cdef int loop_tail(int s, int i, int nearTo) except *:
    if i < nearTo: return loop_tail(s+i,i+1,nearTo)
    else: return s
cpdef int sequence_tailrec(int fron, int nearTo) except *:
    return loop_tail(0,fron,nearTo)
