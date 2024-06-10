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

def Closure2(env_v0 : i32, env_v1 : f64, env_v2 : f32, env_v3 : f64):
    def inner(v4 : string) -> Tuple[i32, i32, f64, f32, f64]:
        nonlocal env_v0, env_v1, env_v2, env_v3
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3
        return method4(v0, v1, v2, v3)
    return inner
def Closure1(env_v0 : i32):
    def inner(v1 : f64, v2 : f32, v3 : f64) -> Callable[[string], Tuple[i32, i32, f64, f32, f64]]:
        nonlocal env_v0
        v0 = env_v0
        return method3(v0, v1, v2, v3)
    return inner
def Closure0():
    def inner(v0 : i32) -> Callable[[f64, f32, f64], Callable[[string], Tuple[i32, i32, f64, f32, f64]]]:
        return method2(v0)
    return inner
def method4(v0 : i32, v1 : f64, v2 : f32, v3 : f64) -> Tuple[i32, i32, f64, f32, f64]:
    return 1, v0, v1, v2, v3
def method3(v0 : i32, v1 : f64, v2 : f32, v3 : f64) -> Callable[[string], Tuple[i32, i32, f64, f32, f64]]:
    return Closure2(v0, v1, v2, v3)
def method2(v0 : i32) -> Callable[[f64, f32, f64], Callable[[string], Tuple[i32, i32, f64, f32, f64]]]:
    return Closure1(v0)
def method1() -> Callable[[i32], Callable[[f64, f32, f64], Callable[[string], Tuple[i32, i32, f64, f32, f64]]]]:
    return Closure0()
def method0() -> Callable[[string], Tuple[i32, i32, f64, f32, f64]]:
    v0 = method1()
    v1 = v0(2)
    del v0
    return v1(2.2, 3.0, 4.5)
def main():
    v0 = method0()
    v1 = "qwe"
    v2, v3, v4, v5, v6 = v0(v1)
    del v0, v1, v4, v5, v6
    v7 = v2 + v3
    del v2, v3
    return v7

if __name__ == '__main__': print(main())
