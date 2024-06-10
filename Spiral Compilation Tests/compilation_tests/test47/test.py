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
class US0_0(NamedTuple): # A
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # B
    v0 : f64
    tag = 1
US0 = Union[US0_0, US0_1]
class UH0_0(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
def method0(v0 : UH0, v1 : UH0) -> bool:
    match v1, v0:
        case UH0_0(v2, v3), UH0_0(v4, v5): # Cons
            del v0, v1
            v6 = v2 == v4
            del v2, v4
            if v6:
                del v6
                return method0(v5, v3)
            else:
                del v3, v5, v6
                return False
        case UH0_1(), UH0_1(): # Nil
            del v0, v1
            return True
        case t:
            del v0, v1
            return False
def main():
    v3 = False
    del v3
    v4 = 1
    v5 = US0_0(v4)
    del v4
    match v5:
        case US0_1(v7): # B
            v8 = v7 == 3.0
            del v7
            v9 = v8
        case t:
            v9 = False
    del v5, v9
    v10 = 3.0
    v11 = US0_1(v10)
    del v10
    match v11:
        case US0_0(v14): # A
            v15 = 1 == v14
            del v14
            v16 = v15
        case t:
            v16 = False
    del v11, v16
    v17 = 1
    v18 = US0_0(v17)
    del v17
    v19 = 3.0
    v20 = US0_1(v19)
    del v19
    match v18, v20:
        case US0_0(v21), US0_0(v22): # A
            v23 = v21 == v22
            del v21, v22
            v27 = v23
        case US0_1(v24), US0_1(v25): # B
            v26 = v24 == v25
            del v24, v25
            v27 = v26
        case t:
            v27 = False
    del v18, v20, v27
    v28 = 3
    v29 = UH0_1()
    v30 = UH0_0(v28, v29)
    del v28, v29
    v31 = 2
    v32 = 3
    v33 = UH0_1()
    v34 = UH0_0(v32, v33)
    del v32, v33
    v35 = UH0_0(v31, v34)
    del v31, v34
    match v35:
        case UH0_0(v42, v43): # Cons
            v44 = 2 == v42
            del v42
            if v44:
                del v44
                v47 = method0(v43, v30)
            else:
                del v43, v44
                v47 = False
        case t:
            v47 = False
    del v30, v35, v47
    return 0

if __name__ == '__main__': print(main())
