import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 1
    v1 = "qwe"
    del v1
    v2 = 2
    v3 = "asd"
    del v3
    v4 = v0 == v2
    del v0, v2, v4
    v5 = 1
    v6 = 2.0
    v7 = v5 == 3
    del v5
    if v7:
        v8 = v6 == 4.0
        v9 = v8
    else:
        v9 = False
    del v6, v7, v9
    return 0

if __name__ == '__main__': print(main())
