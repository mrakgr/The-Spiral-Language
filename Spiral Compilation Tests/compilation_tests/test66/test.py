import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = 0
    v1 = 0 == v0
    if v1:
        v2 = "qwe"
        v10 = v2
    else:
        v3 = 1 == v0
        if v3:
            del v3
            v4 = "asd"
            v10 = v4
        else:
            del v3
            v5 = 2 == v0
            if v5:
                del v5
                v6 = "asd"
                v10 = v6
            else:
                del v5
                v7 = "zxc"
                v10 = v7
    del v0, v1, v10
    return 0

if __name__ == '__main__': print(main())
