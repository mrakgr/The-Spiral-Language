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

class US0_0(NamedTuple): # A
    tag = 0
US0 = US0_0
class US1_0(NamedTuple): # B
    tag = 0
US1 = US1_0
class US2_0(NamedTuple): # C
    v0 : string
    tag = 0
US2 = US2_0
def method0(v0 : US0) -> None:
    match v0:
        case US0_0(): # A
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method1(v0 : US1) -> None:
    match v0:
        case US1_0(): # B
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method2(v0 : US2) -> None:
    match v0:
        case US2_0(_): # C
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = US0_0()
    method0(v0)
    del v0
    v1 = US1_0()
    method1(v1)
    del v1
    v2 = "qwe"
    v3 = US2_0(v2)
    del v2
    return method2(v3)

if __name__ == '__main__': print(main())
