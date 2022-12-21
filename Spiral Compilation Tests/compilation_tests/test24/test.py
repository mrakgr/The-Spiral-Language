from numpy import ndarray
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = True
    v1 = False
    v2 = True
    v3 = False
    v4 = True
    v5 = v0 and v1
    del v0, v1
    if v5:
        v8 = True
    else:
        v6 = v2 and v3
        v7 = v6 or v4
        del v6
        v8 = v7
    del v2, v3, v4, v5, v8
    return 0

if __name__ == '__main__': print(main())
