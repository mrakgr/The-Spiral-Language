import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0(v0 : bool) -> string:
    if v0:
        del v0
        v1 = "asd"
        return v1
    else:
        del v0
        v2 = "qwe"
        return v2
def main():
    v0 = True
    v1 = method0(v0)
    del v0, v1
    return 0

if __name__ == '__main__': print(main())
