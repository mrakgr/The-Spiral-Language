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
    tag = 0
class US0_1(NamedTuple): # B
    tag = 1
class US0_2(NamedTuple): # C
    tag = 2
class US0_3(NamedTuple): # D
    tag = 3
class US0_4(NamedTuple): # E
    tag = 4
US0 = Union[US0_0, US0_1, US0_2, US0_3, US0_4]
def main():
    v0 = US0_1()
    v1 = US0_2()
    match v0:
        case US0_0(): # A
            del v0
            match v1:
                case US0_0(): # A
                    del v1
                    return 0
                case US0_1(): # B
                    del v1
                    return 1
                case US0_2(): # C
                    del v1
                    return 3
                case t:
                    del v1
                    return -1
        case US0_1(): # B
            del v0
            match v1:
                case US0_0(): # A
                    del v1
                    return 2
                case US0_2(): # C
                    del v1
                    return 4
                case t:
                    del v1
                    return -1
        case t:
            del v0, v1
            return -1

if __name__ == '__main__': print(main())
