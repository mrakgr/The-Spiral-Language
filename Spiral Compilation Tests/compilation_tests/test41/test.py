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
class UH0_0(NamedTuple): # Cons
    v0 : i32
    v1 : i32
    v2 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
def main():
    v0 = 1
    v1 = 2
    v2 = 4
    v3 = 5
    v4 = 5
    v5 = 6
    v6 = UH0_1()
    v7 = UH0_0(v4, v5, v6)
    del v4, v5, v6
    v8 = UH0_0(v2, v3, v7)
    del v2, v3, v7
    v9 = UH0_0(v0, v1, v8)
    del v0, v1, v8
    match v9:
        case UH0_0(v11, v12, v13): # Cons
            match v13:
                case UH0_0(v16, v17, v18): # Cons
                    del v13
                    match v18:
                        case UH0_0(v23, v24, _): # Cons
                            del v18
                            v26 = v11 + v12
                            del v11, v12
                            v27 = v26 + v16
                            del v16, v26
                            v28 = v27 + v17
                            del v17, v27
                            v29 = v28 + v23
                            del v23, v28
                            v30 = v29 + v24
                            del v24, v29
                            v31 = "At least three elements."
                            v42, v43 = v31, v30
                        case UH0_1(): # Nil
                            del v18
                            v19 = v11 + v12
                            del v11, v12
                            v20 = v19 + v16
                            del v16, v19
                            v21 = v20 + v17
                            del v17, v20
                            v22 = "Two elements."
                            v42, v43 = v22, v21
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                case UH0_1(): # Nil
                    del v13
                    v14 = v11 + v12
                    del v11, v12
                    v15 = "One element."
                    v42, v43 = v15, v14
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case UH0_1(): # Nil
            v10 = "No elements"
            v42, v43 = v10, 0
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v9
    printf("%s\n%i\n",v42->ptr,v43)
    del v42, v43
    return 0

if __name__ == '__main__': print(main())
