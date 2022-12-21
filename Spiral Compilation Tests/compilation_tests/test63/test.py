import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

UH0 = Union["UH0_0", "UH0_1"]
class UH0_0(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
def method0(v0 : UH0, v1 : i32) -> i32:
    match v0:
        case UH0_0(v2, v3): # Cons
            del v0
            v4 = v1 + v2
            del v1, v2
            return method0(v3, v4)
        case UH0_1(): # Nil
            del v0
            return v1
def main():
    v0 = 4
    v1 = 5
    v2 = 6
    v3 = UH0_1()
    v4 = UH0_0(v2, v3)
    del v2, v3
    v5 = UH0_0(v1, v4)
    del v1, v4
    v6 = UH0_0(v0, v5)
    del v0, v5
    v7 = 6
    return method0(v6, v7)

if __name__ == '__main__': print(main())
