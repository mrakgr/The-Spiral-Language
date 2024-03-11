kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = cp.empty(464,dtype=cp.uint8)
    v2 = v0[0:0+1*10].view(cp.uint8)
    v3 = v2
    v5 = v0[12:12+4*16].view(cp.float32)
    v6 = v5
    v8 = v0[0:0+4*100].view(cp.float32)
    v9 = v8
    v11 = v0[400:400+4*16].view(cp.float32)
    v12 = v11
    del v0
    return v3, 0, 1, 10, v6, 0, 4, 1, 4, 4, v9, 0, 10, 1, 10, 10, v12, 0, 4, 1, 4, 4

if __name__ == '__main__': print(main())
