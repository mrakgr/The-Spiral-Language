import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 2
    del v0
    v1 = 4
    del v1
    v2 = 6
    del v2
    v3 = 12
    return v3

if __name__ == '__main__': print(main())
