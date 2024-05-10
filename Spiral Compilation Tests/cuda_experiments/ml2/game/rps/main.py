kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
import collections
class US1_0(NamedTuple): # Paper
    tag = 0
class US1_1(NamedTuple): # Rock
    tag = 1
class US1_2(NamedTuple): # Scissors
    tag = 2
US1 = Union[US1_0, US1_1, US1_2]
class US2_0(NamedTuple): # Computer
    tag = 0
class US2_1(NamedTuple): # Human
    tag = 1
US2 = Union[US2_0, US2_1]
class US0_0(NamedTuple): # ActionSelected
    v0 : US1
    tag = 0
class US0_1(NamedTuple): # PlayerChanged
    v0 : US2
    v1 : US2
    tag = 1
class US0_2(NamedTuple): # StartGame
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US3_0(NamedTuple): # GameNotStarted
    tag = 0
class US3_1(NamedTuple): # GameOver
    v0 : US1
    v1 : US1
    tag = 1
class US3_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : i32
    tag = 2
US3 = Union[US3_0, US3_1, US3_2]
class US4_0(NamedTuple): # GameStarted
    tag = 0
class US4_1(NamedTuple): # ShowdownResult
    v0 : US1
    v1 : US1
    tag = 1
class US4_2(NamedTuple): # WaitingToStart
    tag = 2
US4 = Union[US4_0, US4_1, US4_2]
class US5_0(NamedTuple): # None
    tag = 0
class US5_1(NamedTuple): # Some
    v0 : US1
    tag = 1
US5 = Union[US5_0, US5_1]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = method0(v0)
        v3, v4, v5, v6, v7, v8 = method4(v1)
        v9, v10, v11, v12, v13, v14 = method8(v3, v4, v5, v6, v7, v8, v2)
        del v2, v3, v4, v5, v6, v7, v8
        return method10(v9, v10, v11, v12, v13, v14)
    return inner
def Closure1():
    def inner() -> object:
        v0 = [None] * 2
        v1 = [0]
        v2 = US3_0()
        v3 = US4_2()
        v4 = US2_0()
        v5 = US2_1()
        return method10(v0, v1, v2, v3, v4, v5)
    return inner
def method2(v0 : object) -> US1:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Paper" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US1_0()
    else:
        del v4
        v7 = "Rock" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US1_1()
        else:
            del v7
            v10 = "Scissors" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US1_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method3(v0 : object) -> US2:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Computer" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US2_0()
    else:
        del v4
        v7 = "Human" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US2_1()
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method1(v0 : object) -> US0:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "ActionSelected" == v1
    if v4:
        del v1, v4
        v5 = method2(v2)
        del v2
        return US0_0(v5)
    else:
        del v4
        v8 = "PlayerChanged" == v1
        if v8:
            del v1, v8
            v9 = v2[0]
            v10 = method3(v9)
            del v9
            v11 = v2[1]
            del v2
            v12 = method3(v11)
            del v11
            return US0_1(v10, v12)
        else:
            del v8
            v15 = "StartGame" == v1
            if v15:
                del v1, v15
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US0_2()
            else:
                del v2, v15
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method0(v0 : object) -> US0:
    return method1(v0)
def method5(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method6(v0 : object) -> US3:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US3_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = v2[0]
            v9 = method2(v8)
            del v8
            v10 = v2[1]
            del v2
            v11 = method2(v10)
            del v10
            return US3_1(v9, v11)
        else:
            del v7
            v14 = "WaitingForActionFromPlayerId" == v1
            if v14:
                del v1, v14
                assert isinstance(v2,i32), f'The object needs to be the right primitive type. Got: {v2}'
                v15 = v2
                del v2
                return US3_2(v15)
            else:
                del v2, v14
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method7(v0 : object) -> US4:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US4_0()
    else:
        del v4
        v7 = "ShowdownResult" == v1
        if v7:
            del v1, v7
            v8 = v2[0]
            v9 = method2(v8)
            del v8
            v10 = v2[1]
            del v2
            v11 = method2(v10)
            del v10
            return US4_1(v9, v11)
        else:
            del v7
            v14 = "WaitingToStart" == v1
            if v14:
                del v1, v14
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US4_2()
            else:
                del v2, v14
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method4(v0 : object) -> Tuple[list[US1], list, US3, US4, US2, US2]:
    v1 = "game_state"
    v2 = v0[v1]
    v3 = "past_actions"
    v4 = v2[v3]
    del v2, v3
    assert isinstance(v4,list), f'The object needs to be a Python list. Got: {v4}'
    v5 = len(v4)
    v6 = 2 >= v5
    v7 = v6 == False
    if v7:
        v8 = "The type level dimension has to equal the value passed at runtime into create."
        assert v6, v8
        del v8
    else:
        pass
    del v6, v7
    v9 = [None] * 2
    v10 = [0]
    v11 = v10[0]
    del v11
    v10[0] = v5
    v12 = 0
    while method5(v5, v12):
        v14 = v4[v12]
        v15 = method2(v14)
        del v14
        v16 = 0 <= v12
        if v16:
            v17 = v10[0]
            v18 = v12 < v17
            del v17
            v19 = v18
        else:
            v19 = False
        v20 = v19 == False
        if v20:
            v21 = "The set index needs to be in range."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        if v16:
            v22 = v12 < 2
            v23 = v22
        else:
            v23 = False
        del v16
        v24 = v23 == False
        if v24:
            v25 = "The read index needs to be in range."
            assert v23, v25
            del v25
        else:
            pass
        del v23, v24
        v9[v12] = v15
        del v15
        v12 += 1 
    del v4, v5, v12
    v26 = "ui_state"
    v27 = v0[v26]
    del v0, v26
    v28 = v27[v1]
    del v1
    v29 = method6(v28)
    del v28
    v30 = "messages"
    v31 = v27[v30]
    del v30
    v32 = method7(v31)
    del v31
    v33 = "pl_type"
    v34 = v27[v33]
    del v27, v33
    v35 = v34[0]
    v36 = method3(v35)
    del v35
    v37 = v34[1]
    del v34
    v38 = method3(v37)
    del v37
    return v9, v10, v29, v32, v36, v38
def method9(v0 : US5, v1 : list[US1], v2 : list, v3 : US3, v4 : US4, v5 : US2, v6 : US2) -> Tuple[list[US1], list, US3, US4, US2, US2]:
    match v3:
        case US3_0(): # GameNotStarted
            del v0
            return v1, v2, v3, v4, v5, v6
        case US3_1(_, _): # GameOver
            del v0
            return v1, v2, v3, v4, v5, v6
        case US3_2(v9): # WaitingForActionFromPlayerId
            v10 = v9 < 2
            if v10:
                del v10
                v11 = v2[0]
                v12 = v11 == v9
                del v11
                v13 = v12 == False
                if v13:
                    v14 = "The number of past actions must equal the player id."
                    assert v12, v14
                    del v14
                else:
                    pass
                del v12, v13
                v15 = v9 == 0
                if v15:
                    v16 = v5
                else:
                    v16 = v6
                del v15
                match v16:
                    case US2_0(): # Computer
                        del v3, v16
                        match v0:
                            case US5_0(): # None
                                v18 = True
                            case _:
                                v18 = False
                        del v0
                        v19 = v18 == False
                        if v19:
                            v20 = "The computer player should never be receiving an action."
                            assert v18, v20
                            del v20
                        else:
                            pass
                        del v18, v19
                        v21 = US1_1()
                        v22 = US1_0()
                        v23 = US1_2()
                        v24 = random.choice([v21, v22, v23])
                        del v21, v22, v23
                        v25 = v9 + 1
                        del v9
                        v26 = v2[0]
                        v27 = 1 + v26
                        v2[0] = v27
                        del v27
                        v28 = v26 < 2
                        v29 = v28 == False
                        if v29:
                            v30 = "Cannot add beyond the maximum length of the static array."
                            assert v28, v30
                            del v30
                        else:
                            pass
                        del v29
                        v31 = 0 <= v26
                        if v31:
                            v32 = v2[0]
                            v33 = v26 < v32
                            del v32
                            v34 = v33
                        else:
                            v34 = False
                        v35 = v34 == False
                        if v35:
                            v36 = "The set index needs to be in range."
                            assert v34, v36
                            del v36
                        else:
                            pass
                        del v34, v35
                        v37 = v31 and v28
                        del v28, v31
                        v38 = v37 == False
                        if v38:
                            v39 = "The read index needs to be in range."
                            assert v37, v39
                            del v39
                        else:
                            pass
                        del v37, v38
                        v1[v26] = v24
                        del v24, v26
                        v40 = US5_0()
                        v41 = US3_2(v25)
                        del v25
                        return method9(v40, v1, v2, v41, v4, v5, v6)
                    case US2_1(): # Human
                        del v16
                        match v0:
                            case US5_0(): # None
                                del v0, v9
                                return v1, v2, v3, v4, v5, v6
                            case US5_1(v48): # Some
                                del v0, v3
                                v49 = v9 + 1
                                del v9
                                v50 = v2[0]
                                v51 = 1 + v50
                                v2[0] = v51
                                del v51
                                v52 = v50 < 2
                                v53 = v52 == False
                                if v53:
                                    v54 = "Cannot add beyond the maximum length of the static array."
                                    assert v52, v54
                                    del v54
                                else:
                                    pass
                                del v53
                                v55 = 0 <= v50
                                if v55:
                                    v56 = v2[0]
                                    v57 = v50 < v56
                                    del v56
                                    v58 = v57
                                else:
                                    v58 = False
                                v59 = v58 == False
                                if v59:
                                    v60 = "The set index needs to be in range."
                                    assert v58, v60
                                    del v60
                                else:
                                    pass
                                del v58, v59
                                v61 = v55 and v52
                                del v52, v55
                                v62 = v61 == False
                                if v62:
                                    v63 = "The read index needs to be in range."
                                    assert v61, v63
                                    del v63
                                else:
                                    pass
                                del v61, v62
                                v1[v50] = v48
                                del v48, v50
                                v64 = US5_0()
                                v65 = US3_2(v49)
                                del v49
                                return method9(v64, v1, v2, v65, v4, v5, v6)
            else:
                del v0, v3, v4, v9, v10
                v96 = v2[0]
                v97 = 0 < v96
                del v96
                v98 = v97 == False
                if v98:
                    v99 = "The read index needs to be in range."
                    assert v97, v99
                    del v99
                else:
                    pass
                del v97, v98
                v100 = v1[0]
                v101 = v2[0]
                v102 = 1 < v101
                del v101
                v103 = v102 == False
                if v103:
                    v104 = "The read index needs to be in range."
                    assert v102, v104
                    del v104
                else:
                    pass
                del v102, v103
                v105 = v1[1]
                v106 = v2[0]
                del v106
                v2[0] = 0
                v107 = US3_1(v100, v105)
                v108 = US4_1(v100, v105)
                del v100, v105
                return v1, v2, v107, v108, v5, v6
def method8(v0 : list[US1], v1 : list, v2 : US3, v3 : US4, v4 : US2, v5 : US2, v6 : US0) -> Tuple[list[US1], list, US3, US4, US2, US2]:
    match v6:
        case US0_0(v28): # ActionSelected
            del v6
            v29 = US5_1(v28)
            del v28
            return method9(v29, v0, v1, v2, v3, v4, v5)
        case US0_1(v19, v20): # PlayerChanged
            del v4, v5, v6
            v21 = US5_0()
            return method9(v21, v0, v1, v2, v3, v19, v20)
        case US0_2(): # StartGame
            del v0, v1, v2, v3, v6
            v7 = [None] * 2
            v8 = [0]
            v9 = US5_0()
            v10 = 0
            v11 = US3_2(v10)
            del v10
            v12 = US4_0()
            return method9(v9, v7, v8, v11, v12, v4, v5)
def method11(v0 : US1) -> object:
    match v0:
        case US1_0(): # Paper
            del v0
            v1 = []
            v2 = "Paper"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # Rock
            del v0
            v4 = []
            v5 = "Rock"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(): # Scissors
            del v0
            v7 = []
            v8 = "Scissors"
            v9 = [v8,v7]
            del v7, v8
            return v9
def method12(v0 : US3) -> object:
    match v0:
        case US3_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4, v5): # GameOver
            del v0
            v6 = []
            v7 = method11(v4)
            del v4
            v6.append(v7)
            del v7
            v8 = method11(v5)
            del v5
            v6.append(v8)
            del v8
            v9 = v6
            del v6
            v10 = "GameOver"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US3_2(v12): # WaitingForActionFromPlayerId
            del v0
            v13 = v12
            del v12
            v14 = "WaitingForActionFromPlayerId"
            v15 = [v14,v13]
            del v13, v14
            return v15
def method13(v0 : US4) -> object:
    match v0:
        case US4_0(): # GameStarted
            del v0
            v1 = []
            v2 = "GameStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US4_1(v4, v5): # ShowdownResult
            del v0
            v6 = []
            v7 = method11(v4)
            del v4
            v6.append(v7)
            del v7
            v8 = method11(v5)
            del v5
            v6.append(v8)
            del v8
            v9 = v6
            del v6
            v10 = "ShowdownResult"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US4_2(): # WaitingToStart
            del v0
            v12 = []
            v13 = "WaitingToStart"
            v14 = [v13,v12]
            del v12, v13
            return v14
def method14(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = []
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = []
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
def method10(v0 : list[US1], v1 : list, v2 : US3, v3 : US4, v4 : US2, v5 : US2) -> object:
    v6 = []
    v7 = v1[0]
    v8 = 0
    while method5(v7, v8):
        v10 = 0 <= v8
        if v10:
            v11 = v1[0]
            v12 = v8 < v11
            del v11
            v13 = v12
        else:
            v13 = False
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        if v10:
            v16 = v8 < 2
            v17 = v16
        else:
            v17 = False
        del v10
        v18 = v17 == False
        if v18:
            v19 = "The read index needs to be in range."
            assert v17, v19
            del v19
        else:
            pass
        del v17, v18
        v20 = v0[v8]
        v21 = method11(v20)
        del v20
        v6.append(v21)
        del v21
        v8 += 1 
    del v0, v1, v7, v8
    v22 = {'past_actions': v6}
    del v6
    v23 = method12(v2)
    del v2
    v24 = method13(v3)
    del v3
    v25 = []
    v26 = method14(v4)
    del v4
    v25.append(v26)
    del v26
    v27 = method14(v5)
    del v5
    v25.append(v27)
    del v27
    v28 = v25
    del v25
    v29 = {'game_state': v23, 'messages': v24, 'pl_type': v28}
    del v23, v24, v28
    v30 = {'game_state': v22, 'ui_state': v29}
    del v22, v29
    return v30
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("RPS_Game",['event_loop', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
