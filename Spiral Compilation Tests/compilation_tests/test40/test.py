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
US0 = Union[US0_0, US0_1]
def method0() -> Tuple[US0, US0, US0, US0]:
    v0 = US0_0()
    v1 = US0_0()
    v2 = US0_0()
    v3 = US0_0()
    return v0, v1, v2, v3
def method1() -> i32:
    return 1
def method2() -> i32:
    return 2
def method3() -> i32:
    return 3
def method4() -> i32:
    return 4
def main():
    v0, v1, v2, v3 = method0()
    match v0:
        case US0_0(): # A
            del v0
            match v1:
                case US0_0(): # A
                    del v1, v2, v3
                    return method1()
                case t:
                    match v2:
                        case US0_0(): # A
                            del v2
                            match v3:
                                case US0_0(): # A
                                    del v1, v3
                                    return method2()
                                case t:
                                    match v1:
                                        case US0_1(): # B
                                            del v1
                                            match v3:
                                                case US0_1(): # B
                                                    del v3
                                                    return method3()
                                                case t:
                                                    raise Exception(f'Pattern matching miss. Got: {t}')
                                        case t:
                                            raise Exception(f'Pattern matching miss. Got: {t}')
                        case t:
                            del v2, v3
                            match v1:
                                case US0_1(): # B
                                    del v1
                                    return method4()
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            del v0, v1
            match v2:
                case US0_0(): # A
                    del v2
                    match v3:
                        case US0_0(): # A
                            del v3
                            return method2()
                        case t:
                            del v3
                            return method4()
                case t:
                    del v2, v3
                    return method4()

if __name__ == '__main__': print(main())
