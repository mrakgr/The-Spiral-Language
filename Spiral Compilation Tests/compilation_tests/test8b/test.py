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

def method2(v0 : bool) -> bool:
    return method0(v0)
def method1(v0 : bool) -> bool:
    return method2(v0)
def method0(v0 : bool) -> bool:
    v1 = method1(v0)
    if v1:
        del v0, v1
        return True
    else:
        del v1
        return method2(v0)
def method5(v0 : bool) -> bool:
    return method0(v0)
def method4(v0 : bool) -> bool:
    return method5(v0)
def method3(v0 : bool) -> bool:
    v1 = method4(v0)
    if v1:
        del v0, v1
        return True
    else:
        del v1
        return method5(v0)
def main():
    v0 = False
    v1 = method0(v0)
    del v0
    if v1:
        del v1
        v2 = True
        return method3(v2)
    else:
        del v1
        return False

if __name__ == '__main__': print(main())
