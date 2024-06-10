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

def method0() -> Tuple[i32, i32, i32, i32, i32, i32, i32, i32, i32, i32, i32, i32]:
    return 3, 1, 2, 3, 1, 2, 3, 1, 2, 3, 1, 2
def method1(v0 : i32, v1 : i32, v2 : i32, v3 : i32, v4 : i32, v5 : i32, v6 : i32, v7 : i32, v8 : i32, v9 : i32, v10 : i32, v11 : i32) -> Tuple[i32, i32, i32, i32, i32, i32, i32, i32, i32, i32, i32, i32]:
    return v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11
def main():
    v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 = method0()
    v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23 = method1(v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11)
    del v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23
    return 0

if __name__ == '__main__': print(main())
