import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

@dataclass
class Mut0:
    v0 : u64
def method0(v0 : Mut0) -> bool:
    v1 = v0.v0
    del v0
    v2 = v1 < 1
    del v1
    return v2
def main():
    v0 = np.empty(1,dtype=object)
    v1 = Mut0(0)
    while method0(v1):
        v3 = v1.v0
        pass # void array set
        v4 = v3 + 1
        del v3
        v1.v0 = v4
        del v4
    del v0
    del v1
    return 0

if __name__ == '__main__': print(main())
