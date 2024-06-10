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
    v0 = [None] * 10 # type: ignore
    v1 = [None] * 10 # type: ignore
    v2 = [None] * 10 # type: ignore
    v3 = [None] * 10 # type: ignore
    v4 = [None] * 10 # type: ignore
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
