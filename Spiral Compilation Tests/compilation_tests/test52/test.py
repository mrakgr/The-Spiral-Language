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

def main():
    v0 = 1
    v1 = "qwe"
    del v1
    v2 = 2
    v3 = "asd"
    del v3
    v4 = hash v0
    del v0, v4
    v5 = hash v2
    del v2, v5
    v6 = 1
    v7 = 2.0
    v8 = hash v6
    del v6
    v9 = v8 * 31
    del v8
    v10 = hash v7
    del v7
    v11 = v9 + v10
    del v9, v10, v11
    v12 = hash 3
    v13 = v12 * 31
    del v12
    v14 = hash 4.0
    v15 = v13 + v14
    del v13, v14, v15
    return 0

if __name__ == '__main__': print(main())
