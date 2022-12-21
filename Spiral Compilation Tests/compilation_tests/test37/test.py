from numpy import ndarray
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class US0_0(NamedTuple): # None
    pass
    tag = 0
class US0_1(NamedTuple): # Some
    v0 : i32
    tag = 1
def main():
    v0 = 3
    v1 = US0_1(v0)
    del v0
    match v1:
        case US0_0(): # None
            del v1
            return 0
        case US0_1(v2): # Some
            del v1
            return v2

if __name__ == '__main__': print(main())
