import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

UH0 = Union["UH0_0", "UH0_1"]
class UH0_0(NamedTuple): # Cons
    v0 : string
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
class US0_0(NamedTuple): # Error
    v0 : UH0
    tag = 0
class US0_1(NamedTuple): # Ok
    v0 : u32
    tag = 1
US0 = Union[US0_0, US0_1]
class US1_0(NamedTuple): # Error
    v0 : UH0
    tag = 0
class US1_1(NamedTuple): # Ok
    tag = 1
US1 = Union[US1_0, US1_1]
@dataclass
class Mut0:
    v0 : u32
class US3_0(NamedTuple): # First
    tag = 0
class US3_1(NamedTuple): # Second
    tag = 1
US3 = Union[US3_0, US3_1]
class US2_0(NamedTuple): # None
    tag = 0
class US2_1(NamedTuple): # Some
    v0 : US3
    tag = 1
US2 = Union[US2_0, US2_1]
def Closure1(v0 : u32, v1 : u32, v2 : string):
    def inner(v3 : u32) -> Tuple[US1, u32]:
        v4 = False
        v5 = 0
        v6, v7 = method0(v2, v3, v4, v5)
        del v4, v5
        match v6:
            case US0_0(v8): # Error
                v9 = US0_0(v8)
                del v8
                v18, v19 = v9, v7
            case US0_1(v10): # Ok
                v11, v12 = method1(v2, v7)
                match v11:
                    case US1_0(v13): # Error
                        del v10, v11
                        v14 = US0_0(v13)
                        del v13
                        v18, v19 = v14, v12
                    case US1_1(): # Ok
                        del v11
                        v15 = US0_1(v10)
                        del v10
                        v18, v19 = v15, v12
        del v6, v7
        match v18:
            case US0_0(v20): # Error
                del v0, v1, v2, v18
                v21 = US1_0(v20)
                del v20
                return v21, v19
            case US0_1(v22): # Ok
                del v18
                v23 = 100 < v22
                if v23:
                    raise Exception("The max input has been exceeded.")
                else:
                    pass
                del v23
                v24 = np.empty(101,dtype=object)
                v25 = Mut0(0)
                while method3(v25):
                    v27 = v25.v0
                    v28 = US2_0()
                    v24[v27] = v28
                    del v28
                    v29 = v27 + 1
                    del v27
                    v25.v0 = v29
                    del v29
                del v25
                v30 = US3_0()
                v31 = US3_1()
                v32 = method4(v24, v30, v31, v22)
                del v22, v24, v30, v31
                match v32:
                    case US3_0(): # First
                        v33 = "First"
                        v35 = v33
                    case US3_1(): # Second
                        v34 = "Second"
                        v35 = v34
                del v32
                System.Console.WriteLine(v35)
                del v35
                v36 = v1 + 1
                del v1
                v37 = method2(v0, v36)
                del v0, v36
                v38 = v37(v2)
                del v2, v37
                v39, v40 = v38(v19)
                del v19, v38
                return v39, v40
    return inner
def Closure0(v0 : u32, v1 : u32):
    def inner(v2 : string) -> Callable[[u32], Tuple[US1, u32]]:
        return Closure1(v0, v1, v2)
    return inner
def Closure3():
    def inner(v0 : u32) -> Tuple[US1, u32]:
        v1 = US1_1()
        return v1, v0
    return inner
def Closure2():
    def inner(v0 : string) -> Callable[[u32], Tuple[US1, u32]]:
        return Closure3()
    return inner
def method0(v0 : string, v1 : u32, v2 : bool, v3 : u32) -> Tuple[US0, u32]:
    v4 = 0 <= v1
    if v4:
        v5 = len(v0)
        v6 = v1 < v5
        del v5
        v7 = v6
    else:
        v7 = False
    del v4
    if v7:
        v8 = v0[v1]
        v9 = System.Char.MaxValue
        v10 = v8 == v9
        del v9
        v11 = v10 != True
        del v10
        if v11:
            del v11
            v12 = v1 + 1
            v13 = uint32 v8 - uint32 '0'
            del v8
            v14 = 0 <= v13
            if v14:
                v15 = v13 <= 9
                v16 = v15
            else:
                v16 = False
            del v14
            if v16:
                del v16
                v17 = US0_1(v13)
                del v13
                v53, v54 = v17, v12
            else:
                del v13, v16
                v18 = "digit"
                v19 = UH0_1()
                v20 = UH0_0(v18, v19)
                del v18, v19
                v21 = US0_0(v20)
                del v20
                v53, v54 = v21, v12
        else:
            del v8, v11
            v24 = "Out of bounds."
            v25 = UH0_1()
            v26 = UH0_0(v24, v25)
            del v24, v25
            v27 = US0_0(v26)
            del v26
            v53, v54 = v27, v1
    else:
        v30 = System.Char.MaxValue
        v31 = System.Char.MaxValue
        v32 = v30 == v31
        del v30, v31
        v33 = v32 != True
        del v32
        if v33:
            del v33
            v34 = v0[v1]
            v35 = v1 + 1
            v36 = uint32 v34 - uint32 '0'
            del v34
            v37 = 0 <= v36
            if v37:
                v38 = v36 <= 9
                v39 = v38
            else:
                v39 = False
            del v37
            if v39:
                del v39
                v40 = US0_1(v36)
                del v36
                v53, v54 = v40, v35
            else:
                del v36, v39
                v41 = "digit"
                v42 = UH0_1()
                v43 = UH0_0(v41, v42)
                del v41, v42
                v44 = US0_0(v43)
                del v43
                v53, v54 = v44, v35
        else:
            del v33
            v47 = "Out of bounds."
            v48 = UH0_1()
            v49 = UH0_0(v47, v48)
            del v47, v48
            v50 = US0_0(v49)
            del v49
            v53, v54 = v50, v1
    del v1, v7
    match v53:
        case US0_0(_): # Error
            del v0, v53
            if v2:
                del v2
                v56 = US0_1(v3)
                del v3
                return v56, v54
            else:
                del v2, v3
                v57 = "i32"
                v58 = UH0_1()
                v59 = UH0_0(v57, v58)
                del v57, v58
                v60 = US0_0(v59)
                del v59
                return v60, v54
        case US0_1(v63): # Ok
            del v2, v53
            v64 = v3 * 10
            v65 = v64 + v63
            del v63, v64
            v66 = v3 <= 214748364
            del v3
            if v66:
                v67 = 0 <= v65
                v68 = v67
            else:
                v68 = False
            del v66
            if v68:
                del v68
                v69 = True
                return method0(v0, v54, v69, v65)
            else:
                del v0, v65, v68
                v72 = "The number is too large to be parsed as 32 bit int."
                v73 = UH0_1()
                v74 = UH0_0(v72, v73)
                del v72, v73
                v75 = US0_0(v74)
                del v74
                return v75, v54
def method1(v0 : string, v1 : u32) -> Tuple[US1, u32]:
    v2 = 0 <= v1
    if v2:
        v3 = len(v0)
        v4 = v1 < v3
        del v3
        if v4:
            del v4
            v5 = v0[v1]
            v6 = v5 == ' '
            if v6:
                del v5, v6
                v10 = True
            else:
                del v6
                v7 = v5 == '\n'
                del v5
                v10 = v7
        else:
            del v4
            v10 = False
    else:
        v10 = False
    del v2
    if v10:
        del v10
        v11 = v1 + 1
        del v1
        return method1(v0, v11)
    else:
        del v0, v10
        v14 = US1_1()
        return v14, v1
def method3(v0 : Mut0) -> bool:
    v1 = v0.v0
    del v0
    v2 = v1 < 101
    del v1
    return v2
def method4(v0 : np.ndarray, v1 : US3, v2 : US3, v3 : u32) -> US3:
    match v1:
        case US3_0(): # First
            v4 = v0[v3]
            match v4:
                case US2_0(): # None
                    del v4
                    v5 = v3 >= 2
                    if v5:
                        v6 = v3 - 2
                        v7 = method4(v0, v2, v1, v6)
                        del v6
                        match v7:
                            case US3_0(): # First
                                del v7
                                v9 = True
                            case US3_1(): # Second
                                del v7
                                v9 = False
                    else:
                        v9 = False
                    del v5
                    if v9:
                        v22 = v1
                    else:
                        v10 = v3 >= 3
                        if v10:
                            v11 = v3 - 3
                            v12 = method4(v0, v2, v1, v11)
                            del v11
                            match v12:
                                case US3_0(): # First
                                    del v12
                                    v14 = True
                                case US3_1(): # Second
                                    del v12
                                    v14 = False
                        else:
                            v14 = False
                        del v10
                        if v14:
                            del v14
                            v22 = v1
                        else:
                            del v14
                            v15 = v3 >= 5
                            if v15:
                                v16 = v3 - 5
                                v17 = method4(v0, v2, v1, v16)
                                del v16
                                match v17:
                                    case US3_0(): # First
                                        del v17
                                        v19 = True
                                    case US3_1(): # Second
                                        del v17
                                        v19 = False
                            else:
                                v19 = False
                            del v15
                            if v19:
                                del v19
                                v22 = v1
                            else:
                                del v19
                                v22 = v2
                    del v1, v2, v9
                    v23 = US2_1(v22)
                    v0[v3] = v23
                    del v0, v3, v23
                    return v22
                case US2_1(v24): # Some
                    del v0, v1, v2, v3, v4
                    return v24
        case US3_1(): # Second
            v26 = v3 >= 2
            if v26:
                v27 = v3 - 2
                v28 = method4(v0, v2, v1, v27)
                del v27
                match v28:
                    case US3_0(): # First
                        del v28
                        v30 = False
                    case US3_1(): # Second
                        del v28
                        v30 = True
            else:
                v30 = False
            del v26
            if v30:
                del v0, v2, v3, v30
                return v1
            else:
                del v30
                v31 = v3 >= 3
                if v31:
                    v32 = v3 - 3
                    v33 = method4(v0, v2, v1, v32)
                    del v32
                    match v33:
                        case US3_0(): # First
                            del v33
                            v35 = False
                        case US3_1(): # Second
                            del v33
                            v35 = True
                else:
                    v35 = False
                del v31
                if v35:
                    del v0, v2, v3, v35
                    return v1
                else:
                    del v35
                    v36 = v3 >= 5
                    if v36:
                        v37 = v3 - 5
                        v38 = method4(v0, v2, v1, v37)
                        del v37
                        match v38:
                            case US3_0(): # First
                                del v38
                                v40 = False
                            case US3_1(): # Second
                                del v38
                                v40 = True
                    else:
                        v40 = False
                    del v0, v3, v36
                    if v40:
                        del v2, v40
                        return v1
                    else:
                        del v1, v40
                        return v2
def method2(v0 : u32, v1 : u32) -> Callable[[string], Callable[[u32], Tuple[US1, u32]]]:
    v2 = v1 < v0
    if v2:
        del v2
        v3 = Closure0(v0, v1)
        del v0, v1
        return v3
    else:
        del v0, v1, v2
        v4 = Closure2()
        return v4
def method5(v0 : UH0) -> None:
    match v0:
        case UH0_0(v1, v2): # Cons
            del v0
            printfn "%s" v1
            del v1
            return method5(v2)
        case UH0_1(): # Nil
            del v0
            return 
def main():
    v0 = "8 1 2 3 4 5 6 7 10"
    v1 = 0
    v2 = False
    v3 = 0
    v4, v5 = method0(v0, v1, v2, v3)
    del v1, v2, v3
    match v4:
        case US0_0(v6): # Error
            v7 = US0_0(v6)
            del v6
            v16, v17 = v7, v5
        case US0_1(v8): # Ok
            v9, v10 = method1(v0, v5)
            match v9:
                case US1_0(v11): # Error
                    del v8, v9
                    v12 = US0_0(v11)
                    del v11
                    v16, v17 = v12, v10
                case US1_1(): # Ok
                    del v9
                    v13 = US0_1(v8)
                    del v8
                    v16, v17 = v13, v10
    del v4, v5
    match v16:
        case US0_0(v18): # Error
            v19 = US1_0(v18)
            del v18
            v26, v27 = v19, v17
        case US0_1(v20): # Ok
            v21 = 0
            v22 = method2(v20, v21)
            del v20, v21
            v23 = v22(v0)
            del v22
            v24, v25 = v23(v17)
            del v23
            v26, v27 = v24, v25
    del v0, v16, v17
    match v26:
        case US1_0(v28): # Error
            printfn "Parsing failed at position %i" v27
            printfn "Errors:"
            method5(v28)
        case US1_1(): # Ok
            pass
    del v26, v27
    return 0

if __name__ == '__main__': print(main())
