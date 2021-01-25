cdef int loop_tail(int s, int i, int nearTo):
    if i < nearTo: return loop_tail(s+i,i+1,nearTo)
    else: return s
cpdef int sequence_tailrec(int fron, int nearTo):
    return loop_tail(0,fron,nearTo)

cdef int loop(int i, int nearTo):
    if i < nearTo: return i + loop(i+1,nearTo)
    else: return 0
cpdef int sequence(int fron, int nearTo):
    return loop(fron,nearTo) 