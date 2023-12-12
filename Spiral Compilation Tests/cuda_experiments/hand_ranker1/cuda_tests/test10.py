kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
__device__ inline bool while_method_0(uint32_t v0){
    bool v1;
    v1 = v0 < 3ul;
    return v1;
}
extern "C" __global__ void entry0(float * v0, float * v1, float * v2, float * v3, float * v4, float * v5) {
    uint32_t v6;
    v6 = threadIdx.x + blockIdx.x * blockDim.x;
    uint32_t v7;
    v7 = gridDim.x * blockDim.x;
    uint32_t v8;
    v8 = v6;
    while (while_method_0(v8)){
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
        float v17;
        v17 = v10 * v13;
        float v18;
        v18 = v11 * v12;
        float v19;
        v19 = v17 - v18;
        v4[v8] = v16;
        v5[v8] = v19;
        v8 += v7 ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend="nvcc")
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
    v14 = 3 == v1
    del v1
    v15 = v14 == False
    del v14
    if v15:
        raise Exception("Expected the length of the array to be the specified amount.")
    else:
        pass
    del v15
    v16 = cp.empty(3,dtype=cp.float32)
    v17 = cp.empty(3,dtype=cp.float32)
    v18 = 0
    raw_module.get_function(f"entry{v18}")((65, 1, 1),(128, 1, 1),(v0, v2, v4, v6, v16, v17))
    del v0, v2, v4, v6, v18
    return v16, v17, 3

if __name__ == '__main__': print(main())

