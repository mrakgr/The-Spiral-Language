kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
__device__ inline bool while_method_0(int64_t v0, int64_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, int64_t v4, float * v5) {
    int64_t v6;
    v6 = threadIdx.x + blockIdx.x * blockDim.x;
    int64_t v7;
    v7 = gridDim.x * blockDim.x;
    int64_t v8;
    v8 = v6;
    while (while_method_0(v4, v8)){
        float v10;
        v10 = v0[v8];
        float v11;
        v11 = v1[v8];
        float v12;
        v12 = v2[v8];
        float v13;
        v13 = v3[v8];
        float v14;
        v14 = v10 * v11;
        float v15;
        v15 = v12 * v13;
        float v16;
        v16 = v14 + v15;
        v5[v8] = v16;
        v8 += v7 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = cp.array([1.0, 3.0, 5.0],dtype=cp.float32)
    v1 = len(v0)
    v2 = cp.array([2.0, 4.0, 6.0],dtype=cp.float32)
    v3 = len(v2)
    v4 = cp.array([3.0, 5.0, 7.0],dtype=cp.float32)
    v5 = len(v4)
    v6 = cp.array([4.0, 6.0, 8.0],dtype=cp.float32)
    v7 = len(v6)
    v8 = v5 == v7
    del v7
    v9 = v8 == False
    del v8
    if v9:
        raise Exception("The two arrays have to be that same length for zipping to work.")
    else:
        pass
    del v9
    v10 = v3 == v5
    del v5
    v11 = v10 == False
    del v10
    if v11:
        raise Exception("The two arrays have to be that same length for zipping to work.")
    else:
        pass
    del v11
    v12 = v1 == v3
    del v3
    v13 = v12 == False
    del v12
    if v13:
        raise Exception("The two arrays have to be that same length for zipping to work.")
    else:
        pass
    del v13
    v14 = cp.empty(v1,dtype=cp.float32)
    v15 = 0
    v16 = cp.RawModule(code=kernel, backend="nvcc")
    v16.get_function(f"entry{v15}")((4,),(128,),(v0, v2, v4, v6, v1, v14))
    del v0, v2, v4, v6, v15, v16
    return v14, v1

if __name__ == '__main__': print(main())
