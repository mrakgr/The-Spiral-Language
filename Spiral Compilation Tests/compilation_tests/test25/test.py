import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 2
    v1 = 3
    v2 = v0 == 2
    del v0
    if v2:
        v3 = v1 == 3
        v4 = v3
    else:
        v4 = False
    del v1, v2, v4
    return 0

if __name__ == '__main__': print(main())
