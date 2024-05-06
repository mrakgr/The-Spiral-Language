kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v1 = [None] * 10 # ignore
    v2 = v1
    v2[0] = 234 # type: ignore
    v4 = v2[0]
    v5 = v4
    del v2
    return v5

if __name__ == '__main__': print(main())
