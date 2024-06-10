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

UH0 = Union["UH0_0", "UH0_1"]
UH1 = Union["UH1_0", "UH1_1"]
class UH1_0(NamedTuple): # AQ
    tag = 0
class UH1_1(NamedTuple): # AW
    v0 : UH0
    tag = 1
class UH0_0(NamedTuple): # BQ
    tag = 0
class UH0_1(NamedTuple): # BW
    v0 : UH1
    tag = 1
def main():
    v0 = UH0_0()
    v1 = UH1_1(v0)
    del v0
    v2 = UH0_1(v1)
    del v1
    v3 = UH1_1(v2)
    del v2, v3
    return 0

if __name__ == '__main__': print(main())
