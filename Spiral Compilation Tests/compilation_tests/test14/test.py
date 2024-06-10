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
    v0 = "0"
    del v0
    v1 = 0
    del v1
    v2 = "1"
    del v2
    v3 = 1
    del v3
    v4 = "false"
    del v4
    v5 = False
    del v5
    v6 = "true"
    del v6
    v7 = True
    del v7
    v8 = "asd"
    del v8
    v9 = "1i8"
    del v9
    v10 = 1
    del v10
    v11 = "unknown"
    del v11
    v12 = 5.5
    del v12
    v13 = 5.0
    del v13
    return 0

if __name__ == '__main__': print(main())
