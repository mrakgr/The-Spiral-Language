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

UH0 = Union["UH0_0", "UH0_1"]
UH1 = Union["UH1_0", "UH1_1"]
UH2 = Union["UH2_0", "UH2_1"]
UH3 = Union["UH3_0", "UH3_1"]
class UH0_0(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
class UH1_0(NamedTuple): # Cons
    v0 : string
    v1 : UH1
    tag = 0
class UH1_1(NamedTuple): # Nil
    tag = 1
class UH2_0(NamedTuple): # Cons
    v0 : bool
    v1 : UH2
    tag = 0
class UH2_1(NamedTuple): # Nil
    tag = 1
class UH3_0(NamedTuple): # Cons
    v0 : i32
    v1 : string
    v2 : bool
    v3 : UH3
    tag = 0
class UH3_1(NamedTuple): # Nil
    tag = 1
def method3(v0 : i32, v1 : string, v2 : UH2, v3 : UH3) -> UH3:
    match v2:
        case UH2_0(v4, v5): # Cons
            del v2
            v6 = method3(v0, v1, v5, v3)
            del v3, v5
            return UH3_0(v0, v1, v4, v6)
        case UH2_1(): # Nil
            del v0, v1, v2
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method4(v0 : UH3, v1 : UH3) -> UH3:
    match v0:
        case UH3_0(v2, v3, v4, v5): # Cons
            del v0
            v6 = method4(v5, v1)
            del v1, v5
            return UH3_0(v2, v3, v4, v6)
        case UH3_1(): # Nil
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method2(v0 : UH2, v1 : i32, v2 : UH1, v3 : UH3) -> UH3:
    match v2:
        case UH1_0(v4, v5): # Cons
            del v2
            v6 = method2(v0, v1, v5, v3)
            del v3, v5
            v7 = UH3_1()
            v8 = method3(v1, v4, v0, v7)
            del v0, v1, v4, v7
            return method4(v8, v6)
        case UH1_1(): # Nil
            del v0, v1, v2
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method1(v0 : UH1, v1 : UH2, v2 : UH0, v3 : UH3) -> UH3:
    match v2:
        case UH0_0(v4, v5): # Cons
            del v2
            v6 = method1(v0, v1, v5, v3)
            del v3, v5
            v7 = UH3_1()
            v8 = method2(v1, v4, v0, v7)
            del v0, v1, v4, v7
            return method4(v8, v6)
        case UH0_1(): # Nil
            del v0, v1, v2
            return v3
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method0(v0 : UH0, v1 : UH1, v2 : UH2) -> UH3:
    v3 = UH3_1()
    return method1(v1, v2, v0, v3)
def method5(v0 : UH3) -> None:
    match v0:
        case UH3_0(v1, v2, v3, v4): # Cons
            del v0
            printf("%i %s %i\n",v1, v2->ptr, (int) v3)
            del v1, v2, v3
            return method5(v4)
        case UH3_1(): # Nil
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = UH0_1()
    v4 = UH0_0(v2, v3)
    del v2, v3
    v5 = UH0_0(v1, v4)
    del v1, v4
    v6 = UH0_0(v0, v5)
    del v0, v5
    v7 = "a"
    v8 = "b"
    v9 = UH1_1()
    v10 = UH1_0(v8, v9)
    del v8, v9
    v11 = UH1_0(v7, v10)
    del v7, v10
    v12 = True
    v13 = UH2_1()
    v14 = UH2_0(v12, v13)
    del v12, v13
    v15 = method0(v6, v11, v14)
    del v6, v11, v14
    method5(v15)
    del v15
    return 0

if __name__ == '__main__': print(main())
