import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = np.empty(10,dtype=np.int8)
    v1 = np.empty(10,dtype=object)
    v2 = np.empty(10,dtype=np.int32)
    v3 = np.empty(10,dtype=np.int8)
    v4 = np.empty(10,dtype=np.int8)
    v0[0] = True
    v5 = "qwe"
    v1[0] = v5
    del v5
    v2[0] = 2
    v3[0] = False
    v4[0] = True
    v0[1] = False
    v6 = "zxc"
    v1[1] = v6
    del v6
    v2[1] = -2
    v4[1] = False
    v7 = v0[0]
    del v0, v7
    v8 = v1[0]
    del v1, v8
    v9 = v2[0]
    del v2, v9
    v10 = v3[0]
    del v3, v10
    v11 = v4[0]
    del v4, v11
    return 0

if __name__ == '__main__': print(main())
