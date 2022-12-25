import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class US0_0(NamedTuple): # A
    tag = 0
class US0_1(NamedTuple): # B
    tag = 1
class US0_2(NamedTuple): # C
    tag = 2
class US0_3(NamedTuple): # D
    tag = 3
class US0_4(NamedTuple): # E
    tag = 4
US0 = Union[US0_0, US0_1, US0_2, US0_3, US0_4]
def main():
    v0 = US0_1()
    v1 = US0_2()
    match v0:
        case US0_0(): # A
            del v0
            match v1:
                case US0_0(): # A
                    del v1
                    return 0
                case US0_1(): # B
                    del v1
                    return 1
                case US0_2(): # C
                    del v1
                    return 3
                case _:
                    del v1
                    return -1
        case US0_1(): # B
            del v0
            match v1:
                case US0_0(): # A
                    del v1
                    return 2
                case US0_2(): # C
                    del v1
                    return 4
                case _:
                    del v1
                    return -1
        case _:
            del v0, v1
            return -1

if __name__ == '__main__': print(main())
