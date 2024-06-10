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

UH0 = Union["UH0_0", "UH0_1", "UH0_2"]
class UH0_0(NamedTuple): # Add
    v0 : UH0
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Mult
    v0 : UH0
    v1 : UH0
    tag = 1
class UH0_2(NamedTuple): # V
    v0 : f32
    tag = 2
def method0(v0 : UH0) -> f32:
    match v0:
        case UH0_0(v2, v3): # Add
            del v0
            v4 = method0(v2)
            del v2
            v5 = method0(v3)
            del v3
            v6 = v4 + v5
            del v4, v5
            return v6
        case UH0_1(v7, v8): # Mult
            del v0
            v9 = method0(v7)
            del v7
            v10 = method0(v8)
            del v8
            v11 = v9 * v10
            del v9, v10
            return v11
        case UH0_2(v1): # V
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 21.0
    del v0
    v1 = 1.0
    v2 = UH0_2(v1)
    del v1
    v3 = 2.0
    v4 = UH0_2(v3)
    del v3
    v5 = UH0_0(v2, v4)
    del v2, v4
    v6 = 3.0
    v7 = UH0_2(v6)
    del v6
    v8 = 4.0
    v9 = UH0_2(v8)
    del v8
    v10 = UH0_0(v7, v9)
    del v7, v9
    v11 = UH0_1(v5, v10)
    del v5, v10
    v12 = method0(v11)
    del v11
    v13 = v12 * 2.0
    del v12, v13
    return 0

if __name__ == '__main__': print(main())
