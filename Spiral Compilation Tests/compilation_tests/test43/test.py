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
class UH0_0(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
def method0(v0 : UH0, v1 : i32) -> i32:
    match v0:
        case UH0_0(v2, v3): # Cons
            del v0
            v4 = v1 + v2
            del v1, v2
            return method0(v3, v4)
        case UH0_1(): # Nil
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = UH0_1()
    v4 = UH0_0(v2, v3)
    del v2, v3
    v5 = UH0_0(v1, v4)
    del v1, v4
    v6 = UH0_0(v0, v5)
    del v0, v5
    v7 = 0
    return method0(v6, v7)

if __name__ == '__main__': print(main())
