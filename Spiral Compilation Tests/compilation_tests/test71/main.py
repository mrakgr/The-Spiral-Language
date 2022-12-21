import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class Heap0(NamedTuple):
    v0 : np.ndarray
def main():
    v0 = np.empty(1,dtype=object)
    v1 = Heap0(v0)
    del v0, v1
    return 0

if __name__ == '__main__': print(main())
