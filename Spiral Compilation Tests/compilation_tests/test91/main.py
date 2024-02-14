kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
extern "C" __global__ void entry0() {
    long v0;
    v0 = 1;
    long v1[] = {v0};
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 0
    del v0
    return 0

if __name__ == '__main__': print(main())
