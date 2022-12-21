import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

@dataclass
class Mut0:
    v0 : i32
    v1 : i32
def main():
    v0 = Mut0(1, 2)
    v0.v0 = 3
    v0.v1 = 4
    del v0
    return 0

if __name__ == '__main__': print(main())
