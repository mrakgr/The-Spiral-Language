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
def Closure0(v0 : i32):
    def inner(v1 : US0) -> i32:
        match v1:
            case US0_0(): # None
                return v0
            case US0_1(v2): # Some
                del v0
                return v2
    return inner
def main():
    v0 = 0
    v1 = Closure0(v0)
    del v0, v1
    return 0

if __name__ == '__main__': print(main())
