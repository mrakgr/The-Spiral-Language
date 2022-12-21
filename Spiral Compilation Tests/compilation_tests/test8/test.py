from numpy import ndarray
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0(v0 : i32, v1 : i32) -> i32:
    v2 = v0 + v1
    del v0, v1
    return v2
def main():
    v0 = 1
    v1 = 2
    return method0(v0, v1)

if __name__ == '__main__': print(main())
