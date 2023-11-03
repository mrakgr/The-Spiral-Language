kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
extern "C" __global__ void entry0() {
    printf("Size of a pointer is %i.\n", sizeof(int *));
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 0
    v1 = cp.RawModule(code=kernel, backend="nvcc")
    v1.get_function(f"entry{v0}")((1,),(1,),())
    del v0, v1
    v2 = "Done"
    return v2

if __name__ == '__main__': print(main())
