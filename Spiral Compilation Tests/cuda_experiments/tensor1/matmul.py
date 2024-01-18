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
    v0 = cp.random.normal(0,1,50,cp.float32)
    v1 = v0.size
    v2 = 50 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,50,cp.float32)
    v7 = v6.size
    v8 = 50 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.matmul(v6.reshape((5, 10)),v0.reshape((10, 5))).flatten()
    v13 = v12.size
    v14 = 25 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    return v6, 0, 10, 1, 5, 10, v0, 0, 5, 1, 10, 5, v12, 0, 5, 1, 5, 5

if __name__ == '__main__': print(main())
