from numpy import ndarray
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = v0 + v1
    del v0, v1
    v4 = v3 + v2
    del v2, v3
    return v4

if __name__ == '__main__': print(main())
