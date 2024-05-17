kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
typedef long (* Fun0)(long);
__device__ long ClosureMethod0(long tup0){
    long v0 = tup0;
    return v0;
}
extern "C" __global__ void entry0() {
    Fun0 v0;
    v0 = ClosureMethod0;
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--define-macro=NDEBUG')
options.append('--diag-suppress=550,20012')
options.append('--dopt=on')
options.append('--restrict')
options.append('--maxrregcount=128')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def main():
    v0 = 0
    v1 = raw_module.get_function(f"entry{v0}")
    del v0
    v1.max_dynamic_shared_size_bytes = 0 
    v1((1,),(512,),(),shared_mem=0)
    del v1
    return 

if __name__ == '__main__': print(main())
