import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = 4
    v4 = v0 + v2
    del v0, v2
    v5 = v1 + v3
    del v1, v3
    v6 = v4 + v5
    del v4, v5
    return v6

if __name__ == '__main__': print(main())
