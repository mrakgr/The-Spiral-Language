kernels = [
]
from dpu import DpuSet
import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = np.empty(1,dtype=np.float32)
    v1 = v0[0]
    v0[0] = v1
    del v0, v1
    return 

if __name__ == '__main__': print(main())
