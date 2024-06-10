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

class Heap0(NamedTuple):
    v0 : f64
class Heap1(NamedTuple):
    v0 : i32
class Heap2(NamedTuple):
    v0 : u64
@dataclass
class Mut0:
    v0 : Heap2
class US0_0(NamedTuple): # A
    v0 : Heap1
    v1 : Mut0
    tag = 0
class US0_1(NamedTuple): # B
    v0 : Heap0
    tag = 1
US0 = Union[US0_0, US0_1]
def method0(v0 : US0, v1 : US0, v2 : US0) -> Tuple[US0, US0, US0]:
    return v2, v1, v0
def main():
    v0 = Heap0(5.0)
    v1 = Heap0(2.0)
    v2 = Heap0(1.0)
    v3 = US0_1(v0)
    del v0
    v4 = US0_1(v1)
    del v1
    v5 = US0_1(v2)
    del v2
    v6, v7, v8 = method0(v5, v4, v3)
    del v3, v4, v5
    match v6:
        case US0_0(_, _): # A
            del v6, v7, v8
            return 1
        case t:
            del v6
            match v7:
                case US0_0(_, _): # A
                    del v7, v8
                    return 2
                case t:
                    del v7
                    match v8:
                        case US0_0(_, _): # A
                            del v8
                            return 3
                        case t:
                            del v8
                            return 4

if __name__ == '__main__': print(main())
