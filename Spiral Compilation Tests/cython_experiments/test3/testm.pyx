cdef char qwe(x):
    cdef unsigned long long q = len(x)
    if <char>q != q: raise Exception("The conversion to char failed.")
    return q

def main():
    q = "a" * 200
    return qwe(q)