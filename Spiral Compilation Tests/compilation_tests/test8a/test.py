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

def method0(v0 : i32, v1 : i32, v2 : i32, v3 : i32) -> i32:
    v4 = v3 + v2
    del v2, v3
    v5 = v4 * v1
    del v1, v4
    v6 = v5 // v0
    del v0, v5
    return v6
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = 4
    return method0(v3, v2, v1, v0)

if __name__ == '__main__': print(main())
