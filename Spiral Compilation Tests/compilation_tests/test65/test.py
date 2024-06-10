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

def method0(v0 : bool) -> string:
    if v0:
        del v0
        v1 = "asd"
        return v1
    else:
        del v0
        v2 = "qwe"
        return v2
def main():
    v0 = True
    v1 = method0(v0)
    del v0, v1
    return 0

if __name__ == '__main__': print(main())
