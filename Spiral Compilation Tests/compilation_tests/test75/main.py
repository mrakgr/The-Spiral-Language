import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class US0_0(NamedTuple): # None
    tag = 0
class US0_1(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_0, US0_1]
def main():
    v0 = 1
    v1 = US0_1(v0)
    del v0, v1
    v2 = 1
    v3 = 2
    v4 = v2 + v3
    del v2, v3, v4
    return 

if __name__ == '__main__': print(main())
