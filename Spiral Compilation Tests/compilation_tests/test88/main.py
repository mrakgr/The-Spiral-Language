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
class UH0_0(NamedTuple): # A
    v0 : f32
    tag = 0
class UH0_1(NamedTuple): # B
    v0 : f32
    tag = 1
def main():
    v0 = 1.0
    v1 = UH0_1(v0)
    del v0
    match v1:
        case UH0_0(_): # A
            del v1
            return 
        case UH0_1(_): # B
            del v1
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')

if __name__ == '__main__': print(main())
