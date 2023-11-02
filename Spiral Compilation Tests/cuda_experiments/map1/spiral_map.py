import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method1(v0 : i64, v1 : i64) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method0(v0 : np.ndarray) -> np.ndarray:
    v1 = len(v0)
    v2 = np.empty(v1,dtype=np.float64)
    v3 = 0
    while method1(v1, v3):
        v5 = v0[v3]
        v6 = 2.0 * v5
        del v5
        v2[v3] = v6
        del v6
        v3 += 1
    del v0, v1, v3
    return v2
def method2(v0 : np.ndarray) -> np.ndarray:
    v1 = len(v0)
    v2 = np.empty(v1,dtype=np.float64)
    v3 = 0
    while method1(v1, v3):
        v5 = v0[v3]
        v6 = 2.0 * v5
        del v5
        v2[v3] = v6
        del v6
        v3 += 1
    del v0, v1, v3
    return v2
def main():
    v0 = np.array([1.0, 2.0, 3.0, 4.0],dtype=np.float64)
    v1 = method0(v0)
    print(v1)
    del v1
    v2 = method2(v0)
    del v0
    print(v2)
    del v2
    return 

if __name__ == '__main__': print(main())
