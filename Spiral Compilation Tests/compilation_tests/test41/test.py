from numpy import ndarray
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
        case UH0_0(v10, v11, v12): # Cons
            match v12:
                case UH0_0(v13, v14, v15): # Cons
                    del v12
                    match v15:
                        case UH0_0(v16, v17, _): # Cons
                            del v15
                            v19 = v10 + v11
                            del v10, v11
                            v20 = v19 + v13
                            del v13, v19
                            v21 = v20 + v14
                            del v14, v20
                            v22 = v21 + v16
                            del v16, v21
                            v23 = v22 + v17
                            del v17, v22
                            v24 = "At least three elements."
                            v36, v37 = v24, v23
                        case UH0_1(): # Nil
                            del v15
                            v25 = v10 + v11
                            del v10, v11
                            v26 = v25 + v13
                            del v13, v25
                            v27 = v26 + v14
                            del v14, v26
                            v28 = "Two elements."
                            v36, v37 = v28, v27
                case UH0_1(): # Nil
                    del v12
                    v31 = v10 + v11
                    del v10, v11
                    v32 = "One element."
                    v36, v37 = v32, v31
        case UH0_1(): # Nil
            v35 = "No elements"
            v36, v37 = v35, 0
    del v9
    printf("%s\n%i\n",v36->ptr,v37)
    del v36, v37
    return 0

if __name__ == '__main__': print(main())
