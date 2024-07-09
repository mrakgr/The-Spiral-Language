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
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # C
    v0 : bool
    v1 : i32
    tag = 1
US0 = Union[US0_0, US0_1]
class US1_0(NamedTuple): # B
    tag = 0
class US1_1(NamedTuple): # C
    v0 : bool
    v1 : f32
    tag = 1
US1 = Union[US1_0, US1_1]
class US2_0(NamedTuple): # C
    v0 : bool
    v1 : string
    tag = 0
US2 = US2_0
class US3_0(NamedTuple): # C
    v0 : bool
    v1 : u8
    tag = 0
US3 = US3_0
class US4_0(NamedTuple): # C
    v0 : bool
    v1 : u8
    v2 : bool
    tag = 0
class US4_1(NamedTuple): # D
    v0 : bool
    v1 : u8
    tag = 1
US4 = Union[US4_0, US4_1]
def method0(v0 : US0) -> None:
    match v0:
        case US0_0(_): # A
            del v0
            return 
        case US0_1(_, _): # C
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method1(v0 : US1) -> None:
    match v0:
        case US1_0(): # B
            del v0
            return 
        case US1_1(_, _): # C
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method2(v0 : US2) -> None:
    match v0:
        case US2_0(_, _): # C
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method3(v0 : US3) -> None:
    match v0:
        case US3_0(_, _): # C
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method4(v0 : US4) -> None:
    match v0:
        case US4_0(_, _, _): # C
            del v0
            return 
        case US4_1(_, _): # D
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 2
    v1 = US0_0(v0)
    del v0
    method0(v1)
    del v1
    v2 = US1_0()
    method1(v2)
    del v2
    v3 = False
    v4 = "qwe"
    v5 = US2_0(v3, v4)
    del v3, v4
    method2(v5)
    del v5
    v6 = False
    v7 = 234
    v8 = US3_0(v6, v7)
    del v6, v7
    method3(v8)
    del v8
    v9 = False
    v10 = 234
    v11 = US4_1(v9, v10)
    del v9, v10
    return method4(v11)

if __name__ == '__main__': print(main())
