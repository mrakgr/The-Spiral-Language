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
    v4 = v0 < v2
    if v4:
        v7 = -1
    else:
        v5 = v0 > v2
        if v5:
            del v5
            v7 = 1
        else:
            del v5
            v7 = 0
    del v0, v2, v4, v7
    v8 = 1
    v9 = 2.0
    v10 = v8 < 3
    if v10:
        v13 = -1
    else:
        v11 = v8 > 3
        if v11:
            del v11
            v13 = 1
        else:
            del v11
            v13 = 0
    del v8, v10
    v14 = v13 == 0
    if v14:
        v15 = v9 < 4.0
        if v15:
            del v15
            v19 = -1
        else:
            del v15
            v16 = v9 > 4.0
            if v16:
                del v16
                v19 = 1
            else:
                del v16
                v19 = 0
    else:
        v19 = v13
    del v9, v13, v14, v19
    return 0

if __name__ == '__main__': print(main())
