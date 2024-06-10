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

def method1(v0 : i32, v1 : u64) -> i32:
    v2 = v1 == 0
    if v2:
        del v1, v2
        return v0
    else:
        del v2
        v3 = v1 - 1
        del v1
        return method0(v0, v3)
def method0(v0 : i32, v1 : u64) -> i32:
    v2 = v1 == 0
    if v2:
        del v1, v2
        return v0
    else:
        del v2
        v3 = v1 - 1
        del v1
        return method1(v0, v3)
def main():
    v0 = 123
    v1 = 10
    return method0(v0, v1)

if __name__ == '__main__': print(main())
