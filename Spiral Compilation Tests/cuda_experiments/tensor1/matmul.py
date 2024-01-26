kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
extern "C" __global__ void entry0() {
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend='nvcc', options=("-I G:\\nvidia-mathdx-24.01.0\\nvidia\\mathdx\\24.01\\include", "-I G:\\nvidia-mathdx-24.01.0\\nvidia\\mathdx\\24.01\\include\\cublasdx\\include", "-I G:\\nvidia-mathdx-24.01.0\\nvidia\\mathdx\\24.01\\external\\cutlass\\include"))
def main():
    v0 = 0
    raw_module.get_function(f"entry{v0}")((1, 1, 1),(1, 1, 1),())
    del v0
    return 

if __name__ == '__main__': print(main())
