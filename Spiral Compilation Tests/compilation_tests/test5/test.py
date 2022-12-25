import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0() -> i32:
    return 1
def method1() -> i32:
    return 2
def main():
    v0 = method0()
    v1 = method1()
    v2 = v0 + v1
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
