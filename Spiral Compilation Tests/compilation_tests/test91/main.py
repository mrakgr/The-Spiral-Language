kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
typedef struct {
    int refc;
    unsigned long len;
    long ptr[];
} Array0;
__device__ static inline void ArrayDecrefBody0(Array0 * x){
}
__device__ void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
__device__ Array0 * ArrayCreate0(unsigned long len, bool init_at_zero){
    unsigned long size = sizeof(Array0) + sizeof(long) * len;
    Array0 * x = (Array0 *) malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
__device__ Array0 * ArrayLit0(unsigned long len, long * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(long) * len);
    return x;
}
extern "C" __global__ void entry0() {
    long v0;
    v0 = 1;
    Array0 * v1;
    v1 = ArrayLit0(1, (long []){v0});
    ArrayDecref0(v1);
    return ;
}
"""
class static_array(list):
    def __init__(self, length):
        for _ in range(length):
            self.append(None)

class static_array_list(static_array):
    def __init__(self, length):
        super().__init__(length)
        self.length = 0
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 0
    del v0
    return 0

if __name__ == '__main__': print(main())
