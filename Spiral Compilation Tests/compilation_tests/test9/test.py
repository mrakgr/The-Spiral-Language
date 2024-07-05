kernel = r"""
"""
class static_array():
    def __init__(self, length):
        self.ptr = []
        for _ in range(length):
            self.ptr.append(None)

    def __getitem__(self, index):
        assert 0 <= index < len(self.ptr), "The get index needs to be in range."
        return self.ptr[index]
    
    def __setitem__(self, index, value):
        assert 0 <= index < len(self.ptr), "The set index needs to be in range."
        self.ptr[index] = value

class static_array_list(static_array):
    def __init__(self, length):
        super().__init__(length)
        self.length = 0

    def __getitem__(self, index):
        assert 0 <= index < self.length, "The get index needs to be in range."
        return self.ptr[index]
    
    def __setitem__(self, index, value):
        assert 0 <= index < self.length, "The set index needs to be in range."
        self.ptr[index] = value

    def push(self,value):
        assert (self.length < len(self.ptr)), "The length before pushing has to be less than the maximum length of the array."
        self.ptr[self.length] = value
        self.length += 1

    def pop(self):
        assert (0 < self.length), "The length before popping has to be greater than 0."
        self.length -= 1
        return self.ptr[self.length]

    def unsafe_set_length(self,i):
        assert 0 <= i <= len(self.ptr), "The new length has to be in range."
        self.length = i

class dynamic_array(static_array): 
    pass

class dynamic_array_list(static_array_list):
    def length_(self): return self.length

import cupy as cp
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
