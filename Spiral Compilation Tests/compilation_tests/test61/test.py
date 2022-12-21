import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = np.array([1, 2, 3],dtype=np.int32)
    v1 = len(v0)
    v2 = v1 == 3
    if v2:
        del v1, v2
        v3 = v0[0]
        v4 = v0[1]
        v5 = v0[2]
        del v0
        v6 = v3 + v4
        del v3, v4
        v7 = v6 + v5
        del v5, v6
        return v7
    else:
        del v2
        v8 = v1 == 2
        if v8:
            del v1, v8
            v9 = v0[0]
            v10 = v0[1]
            del v0
            v11 = v9 + v10
            del v9, v10
            return v11
        else:
            del v8
            v12 = v1 == 1
            del v1
            if v12:
                del v12
                v13 = v0[0]
                del v0
                return v13
            else:
                del v0, v12
                return 0

if __name__ == '__main__': print(main())
