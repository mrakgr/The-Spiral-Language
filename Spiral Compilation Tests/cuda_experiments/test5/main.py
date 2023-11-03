kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
extern "C" __global__ void entry0(int32_t v0, int32_t v1, int32_t v2, int32_t v3) {
    int32_t v4;
    v4 = v3 + v2;
    int32_t v5;
    v5 = v4 - v1;
    int32_t v6;
    v6 = v5 - v0;
    int32_t v7;
    v7 = v3 * v2;
    int32_t v8;
    v8 = v7 * v1;
    int32_t v9;
    v9 = v8 * v0;
    v3 = v6;
    v2 = v9;
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = 4
    v4 = 0
    v5 = cp.RawModule(code=kernel, backend="nvcc")
    v5.get_function(f"entry{v4}")((1,),(1,),(v3, v2, v1, v0))
    del v0, v1, v2, v3, v4, v5
    v6 = "Done"
    return v6

if __name__ == '__main__': print(main())
