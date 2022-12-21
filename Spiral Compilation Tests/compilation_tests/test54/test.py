import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class Heap0(NamedTuple):
    v0 : i32
    v1 : i32
def main():
    v0 = Heap0(1, 2)
    v1 = v0.v0
    v2 = v0.v1
    del v0
    v3 = v1 + v2
    del v1, v2
    return v3

if __name__ == '__main__': print(main())
