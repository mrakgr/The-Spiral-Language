import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 2.0
    v1 = v0 + 3.0
    del v0
    v2 = v1 * v1
    del v1, v2
    return 0

if __name__ == '__main__': print(main())
