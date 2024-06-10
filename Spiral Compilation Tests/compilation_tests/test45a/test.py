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

@dataclass
class Mut0:
    v0 : u64
def method0(v0 : Mut0) -> bool:
    v1 = v0.v0
    del v0
    v2 = v1 < 1
    del v1
    return v2
def main():
    v0 = [None] * 1 # type: ignore
    v1 = Mut0(0)
    while method0(v1):
        v3 = v1.v0
        pass # void array set
        v4 = v3 + 1
        del v3
        v1.v0 = v4
        del v4
    del v0
    del v1
    return 0

if __name__ == '__main__': print(main())
