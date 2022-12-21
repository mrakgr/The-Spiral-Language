import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def Closure0(v0 : char, v1 : f32, v2 : i64):
    def inner() -> Tuple[char, f32, i64]:
        return v0, v1, v2
    return inner
class Heap0(NamedTuple):
    v0 : char
    v1 : f32
    v2 : i64
def method0() -> Tuple[char, f32, i64]:
    return 'a', 2.0, 3
def main():
    v0, v1, v2 = method0()
    v3 = Closure0(v0, v1, v2)
    del v3
    v4 = Heap0(v0, v1, v2)
    del v0, v1, v2, v4
    return 0

if __name__ == '__main__': print(main())
