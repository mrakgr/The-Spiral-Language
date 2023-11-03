kernel = """
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
extern "C" __global__ void entry0(int32_t v0, int32_t v1) {
    int32_t v2;
    v2 = v0 + v1;
    return ;
}
extern "C" __global__ void entry1(uint64_t v0, uint64_t v1) {
    uint64_t v2;
    v2 = v0 + v1;
    return ;
}
extern "C" __global__ void entry2(float v0, float v1) {
    float v2;
    v2 = v0 + v1;
    return ;
}
"""
import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 2
    del v0
    v1 = 1
    del v1
    v2 = 0
    del v2
    v3 = 2
    del v3
    v4 = 5
    del v4
    v5 = 1
    del v5
    v6 = 2.5
    del v6
    v7 = 4.4
    del v7
    v8 = 2
    del v8
    return 

if __name__ == '__main__': print(main())
