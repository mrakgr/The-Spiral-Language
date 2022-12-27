import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method2(v0 : bool) -> bool:
    return method0(v0)
def method1(v0 : bool) -> bool:
    return method2(v0)
def method0(v0 : bool) -> bool:
    v1 = method1(v0)
    if v1:
        del v0, v1
        return True
    else:
        del v1
        return method2(v0)
def method5(v0 : bool) -> bool:
    return method0(v0)
def method4(v0 : bool) -> bool:
    return method5(v0)
def method3(v0 : bool) -> bool:
    v1 = method4(v0)
    if v1:
        del v0, v1
        return True
    else:
        del v1
        return method5(v0)
def main():
    v0 = False
    v1 = method0(v0)
    del v0
    if v1:
        del v1
        v2 = True
        return method3(v2)
    else:
        del v1
        return False

if __name__ == '__main__': print(main())
