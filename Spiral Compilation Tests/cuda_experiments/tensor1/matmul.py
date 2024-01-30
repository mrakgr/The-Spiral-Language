kernel = r"""
#include <mma.h>
extern "C" __global__ void entry0(float * v0, float * v1, float * v2) {
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend='nvcc')
def main():
    v0 = cp.random.normal(0,1,128,cp.float32)
    v1 = v0.size
    v2 = 128 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,128,cp.float32)
    v7 = v6.size
    v8 = 128 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.matmul(v6.reshape((16, 8)),cp.transpose(v0.reshape((16, 8)))).flatten()
    v13 = v12.size
    v14 = 256 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = cp.empty(256,dtype=cp.float32)
    v19 = 0
    raw_module.get_function(f"entry{v19}")((24, 1, 1),(256, 1, 1),(v6, v0, v18))
    del v0, v6, v19
    v20 = cp.max(cp.abs(v18-v12))
    del v12, v18
    return v20

if __name__ == '__main__': print(main())
