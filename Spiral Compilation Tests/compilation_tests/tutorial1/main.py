import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0() -> Tuple[i32, i32, i32]:
    return 1, 2, 3
def main():
    return method0()

if __name__ == '__main__': print(main())
