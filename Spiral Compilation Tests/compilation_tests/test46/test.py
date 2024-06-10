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
def Closure1(env_v0 : u32, env_v1 : u32, env_v2 : string):
    def inner(v3 : u32) -> Tuple[US1, u32]:
        nonlocal env_v0, env_v1, env_v2
        v0 = env_v0; v1 = env_v1; v2 = env_v2
        v4 = False
        v5 = 0
        v6, v7 = method0(v2, v3, v4, v5)
        del v4, v5
        match v6:
            case US0_0(v18): # Error
                v19 = US0_0(v18)
                del v18
                v22, v23 = v19, v7
            case US0_1(v8): # Ok
                v9, v10 = method1(v2, v7)
                match v9:
                    case US1_0(v12): # Error
                        del v8, v9
                        v13 = US0_0(v12)
                        del v12
                        v22, v23 = v13, v10
                    case US1_1(): # Ok
                        del v9
                        v11 = US0_1(v8)
                        del v8
                        v22, v23 = v11, v10
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
        del v6, v7
        match v22:
            case US0_0(v44): # Error
                del v0, v1, v2, v22
                v45 = US1_0(v44)
                del v44
                return v45, v23
            case US0_1(v24): # Ok
                del v22
                v25 = 100 < v24
                if v25:
                    raise Exception("The max input has been exceeded.")
                else:
                    pass
                del v25
                v26 = [None] * 101 # type: ignore
                v27 = Mut0(0)
                while method3(v27):
                    v29 = v27.v0
                    v30 = US2_0()
                    v26[v29] = v30
                    del v30
                    v31 = v29 + 1
                    del v29
                    v27.v0 = v31
                    del v31
                del v27
                v32 = US3_0()
                v33 = US3_1()
                v34 = method4(v26, v32, v33, v24)
                del v24, v26, v32, v33
                match v34:
                    case US3_0(): # First
                        v35 = "First"
                        v38 = v35
                    case US3_1(): # Second
                        v36 = "Second"
                        v38 = v36
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
                del v34
                System.Console.WriteLine(v38)
                del v38
                v39 = v1 + 1
                del v1
                v40 = method2(v0, v39)
                del v0, v39
                v41 = v40(v2)
                del v2, v40
                return v41(v23)
            case t:
                raise Exception(f'Pattern matching miss. Got: {t}')
    return inner
def Closure0(env_v0 : u32, env_v1 : u32):
    def inner(v2 : string) -> Callable[[u32], Tuple[US1, u32]]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
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
                v71 = US0_1(v3)
                del v3
                return v71, v54
            else:
                del v2, v3
                v72 = "i32"
                v73 = UH0_1()
                v74 = UH0_0(v72, v73)
                del v72, v73
                v75 = US0_0(v74)
                del v74
                return v75, v54
        case US0_1(v55): # Ok
            del v2, v53
            v56 = v3 * 10
            v57 = v56 + v55
            del v55, v56
            v58 = v3 <= 214748364
            del v3
            if v58:
                v59 = 0 <= v57
                v60 = v59
            else:
                v60 = False
            del v58
            if v60:
                del v60
                v61 = True
                return method0(v0, v54, v61, v57)
            else:
                del v0, v57, v60
                v64 = "The number is too large to be parsed as 32 bit int."
                v65 = UH0_1()
                v66 = UH0_0(v64, v65)
                del v64, v65
                v67 = US0_0(v66)
                del v66
                return v67, v54
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
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
def method4(v0 : list[US2], v1 : US3, v2 : US3, v3 : u32) -> US3:
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
                                v10 = True
                            case US3_1(): # Second
                                del v7
                                v10 = False
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    else:
                        v10 = False
                    del v5
                    if v10:
                        v25 = v1
                    else:
                        v11 = v3 >= 3
                        if v11:
                            v12 = v3 - 3
                            v13 = method4(v0, v2, v1, v12)
                            del v12
                            match v13:
                                case US3_0(): # First
                                    del v13
                                    v16 = True
                                case US3_1(): # Second
                                    del v13
                                    v16 = False
                                case t:
                                    raise Exception(f'Pattern matching miss. Got: {t}')
                        else:
                            v16 = False
                        del v11
                        if v16:
                            del v16
                            v25 = v1
                        else:
                            del v16
                            v17 = v3 >= 5
                            if v17:
                                v18 = v3 - 5
                                v19 = method4(v0, v2, v1, v18)
                                del v18
                                match v19:
                                    case US3_0(): # First
                                        del v19
                                        v22 = True
                                    case US3_1(): # Second
                                        del v19
                                        v22 = False
                                    case t:
                                        raise Exception(f'Pattern matching miss. Got: {t}')
                            else:
                                v22 = False
                            del v17
                            if v22:
                                del v22
                                v25 = v1
                            else:
                                del v22
                                v25 = v2
                    del v1, v2, v10
                    v26 = US2_1(v25)
                    v0[v3] = v26
                    del v0, v3, v26
                    return v25
                case US2_1(v27): # Some
                    del v0, v1, v2, v3, v4
                    return v27
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case US3_1(): # Second
            v30 = v3 >= 2
            if v30:
                v31 = v3 - 2
                v32 = method4(v0, v2, v1, v31)
                del v31
                match v32:
                    case US3_0(): # First
                        del v32
                        v35 = False
                    case US3_1(): # Second
                        del v32
                        v35 = True
                    case t:
                        raise Exception(f'Pattern matching miss. Got: {t}')
            else:
                v35 = False
            del v30
            if v35:
                del v0, v2, v3, v35
                return v1
            else:
                del v35
                v36 = v3 >= 3
                if v36:
                    v37 = v3 - 3
                    v38 = method4(v0, v2, v1, v37)
                    del v37
                    match v38:
                        case US3_0(): # First
                            del v38
                            v41 = False
                        case US3_1(): # Second
                            del v38
                            v41 = True
                        case t:
                            raise Exception(f'Pattern matching miss. Got: {t}')
                else:
                    v41 = False
                del v36
                if v41:
                    del v0, v2, v3, v41
                    return v1
                else:
                    del v41
                    v42 = v3 >= 5
                    if v42:
                        v43 = v3 - 5
                        v44 = method4(v0, v2, v1, v43)
                        del v43
                        match v44:
                            case US3_0(): # First
                                del v44
                                v47 = False
                            case US3_1(): # Second
                                del v44
                                v47 = True
                            case t:
                                raise Exception(f'Pattern matching miss. Got: {t}')
                    else:
                        v47 = False
                    del v0, v3, v42
                    if v47:
                        del v2, v47
                        return v1
                    else:
                        del v1, v47
                        return v2
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
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
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = "8 1 2 3 4 5 6 7 10"
    v1 = 0
    v2 = False
    v3 = 0
    v4, v5 = method0(v0, v1, v2, v3)
    del v1, v2, v3
    match v4:
        case US0_0(v16): # Error
            v17 = US0_0(v16)
            del v16
            v20, v21 = v17, v5
        case US0_1(v6): # Ok
            v7, v8 = method1(v0, v5)
            match v7:
                case US1_0(v10): # Error
                    del v6, v7
                    v11 = US0_0(v10)
                    del v10
                    v20, v21 = v11, v8
                case US1_1(): # Ok
                    del v7
                    v9 = US0_1(v6)
                    del v6
                    v20, v21 = v9, v8
                case t:
                    raise Exception(f'Pattern matching miss. Got: {t}')
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v4, v5
    match v20:
        case US0_0(v28): # Error
            v29 = US1_0(v28)
            del v28
            v32, v33 = v29, v21
        case US0_1(v22): # Ok
            v23 = 0
            v24 = method2(v22, v23)
            del v22, v23
            v25 = v24(v0)
            del v24
            v32, v33 = v25(v21)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v0, v20, v21
    match v32:
        case US1_0(v34): # Error
            printfn "Parsing failed at position %i" v33
            printfn "Errors:"
            method5(v34)
        case t:
            pass
    del v32, v33
    return 0

if __name__ == '__main__': print(main())
