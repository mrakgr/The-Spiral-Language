kernel = r"""
template <typename el, int dim> struct static_array { el v[dim]; };
template <typename el, int dim, typename default_int> struct static_array_list { el v[dim]; default_int length; };
"""
class static_array(list):
    def __init__(self, length):
        for _ in range(length):
            self.append(None)

class static_array_list(static_array):
    def __init__(self, length):
        super().__init__(length)
        self.length = 0
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method2(v0 : string) -> None:
    print(v0, end="")
    del v0
    return 
def method3(v0 : i32) -> None:
    print(v0, end="")
    del v0
    return 
def method1(v0 : static_array) -> None:
    v1 = "["
    method2(v1)
    del v1
    v2 = 0
    while method0(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 3
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        method3(v9)
        del v9
        v10 = v2 + 1
        v11 = v10 < 3
        del v10
        if v11:
            v12 = "; "
            method2(v12)
        else:
            pass
        del v11
        v2 += 1 
    del v0, v2
    v13 = "]"
    return method2(v13)
def main():
    v0 = static_array(3)
    v0[0] = 1
    v0[1] = 2
    v0[2] = 3
    v1 = static_array(3)
    v2 = 0
    while method0(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 3
            v6 = v5
        else:
            v6 = False
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = 1 == v2
        if v10:
            v11 = 55
        else:
            v11 = v9
        del v9, v10
        if v4:
            v12 = v2 < 3
            v13 = v12
        else:
            v13 = False
        del v4
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v1[v2] = v11
        del v11
        v2 += 1 
    del v0, v2
    method1(v1)
    del v1
    print()
    return 

if __name__ == '__main__': print(main())
