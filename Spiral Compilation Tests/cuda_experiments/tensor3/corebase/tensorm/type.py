kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = cp.array([1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0],dtype=cp.float32)
    v1 = v0.size
    v2 = 12 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = v0[6].item()
    v7 = v0[3].item()
    del v0
    return v6, v7

if __name__ == '__main__': print(main())
