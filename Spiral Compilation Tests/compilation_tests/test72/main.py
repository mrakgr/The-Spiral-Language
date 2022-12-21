import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class Heap0(NamedTuple):
    v0 : bool
def method2(v0 : Heap0) -> Heap0:
    return v0
def method1(v0 : Heap0) -> Heap0:
    return method2(v0)
def method0(v0 : Heap0) -> Heap0:
    return method1(v0)
def main():
    v0 = True
    v1 = Heap0(True)
    if v0:
        v3 = method0(v1)
    else:
        v3 = v1
    del v0, v1, v3
    return 0

if __name__ == '__main__': print(main())
