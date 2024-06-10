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

def method0() -> None:
    return 
def method1() -> None:
    return 
def method2() -> None:
    return 
def method3() -> None:
    return 
def method4() -> i32:
    return 1
def method5() -> i32:
    return 2
def main():
    method0()
    method1()
    method2()
    method3()
    v0 = method4()
    v1 = method5()
    v2 = v0 + v1
    del v0, v1, v2
    return 

if __name__ == '__main__': print(main())
