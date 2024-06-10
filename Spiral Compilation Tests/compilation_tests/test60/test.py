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

class US0_0(NamedTuple): # A
    v0 : string
    v1 : string
    v2 : string
    tag = 0
US0 = US0_0
def main():
    v0 = "qwe"
    v1 = "asd"
    v2 = "zxc"
    v3 = US0_0(v0, v1, v2)
    del v0, v1, v2
    match v3:
        case US0_0(v4, _, _): # A
            del v3
            v7 = 5
            del v7
            v8 = len(v4)
            del v4
            return v8
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': print(main())
