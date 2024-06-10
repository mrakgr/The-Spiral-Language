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
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method2(v0 : i32, v1 : i32) -> i32:
    v2 = 0 < v1
    if v2:
        del v2
        v3 = v1 // 10
        v4 = v0 * 10
        del v0
        v5 = v1 % 10
        del v1
        v6 = v4 + v5
        del v4, v5
        return method2(v6, v3)
    else:
        del v1, v2
        return v0
def method3(v0 : i32, v1 : i32, v2 : i32) -> i32:
    v3 = v1 < 1000
    if v3:
        del v3
        v4 = v1 + 1
        v5 = v0 * v1
        del v1
        v6 = 0
        v7 = method2(v6, v5)
        del v6
        v8 = v5 == v7
        del v7
        if v8:
            v9 = v2 < v5
            v10 = v9
        else:
            v10 = False
        del v8
        if v10:
            v11 = v5
        else:
            v11 = v2
        del v2, v5, v10
        return method3(v0, v4, v11)
    else:
        del v0, v1, v3
        return v2
def method1(v0 : i32, v1 : i32) -> i32:
    v2 = v0 < 1000
    if v2:
        del v2
        v3 = v0 + 1
        v4 = v0 * v0
        v5 = 0
        v6 = method2(v5, v4)
        del v5
        v7 = v4 == v6
        del v6
        if v7:
            v8 = v1 < v4
            v9 = v8
        else:
            v9 = False
        del v7
        if v9:
            v10 = v4
        else:
            v10 = v1
        del v1, v4, v9
        return method3(v0, v3, v10)
    else:
        del v0, v2
        return v1
def method0(v0 : i32, v1 : i32) -> i32:
    v2 = v0 < 1000
    if v2:
        del v2
        v3 = v0 + 1
        v4 = method1(v0, v1)
        del v0, v1
        return method0(v3, v4)
    else:
        del v0, v2
        return v1
def main():
    v0 = 100
    v1 = 0
    return method0(v0, v1)

if __name__ == '__main__': print(main())
