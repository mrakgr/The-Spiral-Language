from numpy import ndarray
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    // let v0 = false
    v0 = False
    // let v1 = true
    v1 = True
    del v1
    // let v2 = false
    v2 = False
    del v2
    // v0  = false
    v3 = v0 == False
    del v0, v3
    return 0

if __name__ == '__main__': print(main())
