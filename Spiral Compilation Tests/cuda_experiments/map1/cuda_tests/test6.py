kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
extern "C" __global__ void entry0(float * v0) {
    float v1;
    v1 = v0[0ll];
    float v2;
    v2 = 100.0f + v1;
    v0[0ll] = v2;
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = cp.array([1.0, 2.0, 3.0, 4.0, 5.0],dtype=cp.float32)
    v1 = 0
    v2 = cp.RawModule(code=kernel, backend="nvcc")
    v2.get_function(f"entry{v1}")((1,),(1,),v0)
    del v1, v2
    return v0

if __name__ == '__main__': print(main())
