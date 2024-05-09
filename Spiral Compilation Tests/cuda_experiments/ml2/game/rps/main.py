kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
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
def method1(v0 : US5, v1 : list[US1], v2 : list, v3 : US3, v4 : US4, v5 : US2, v6 : US2) -> Tuple[list[US1], list, US3, US4, US2, US2]:
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
                        return method1(v40, v1, v2, v41, v4, v5, v6)
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
                                return method1(v64, v1, v2, v65, v4, v5, v6)
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
def method0(v0 : US0, v1 : list[US1], v2 : list, v3 : US3, v4 : US4, v5 : US2, v6 : US2) -> Tuple[list[US1], list, US3, US4, US2, US2]:
    match v0:
        case US0_0(v28): # ActionSelected
            del v0
            v29 = US5_1(v28)
            del v28
            return method1(v29, v1, v2, v3, v4, v5, v6)
        case US0_1(v19, v20): # PlayerChanged
            del v0, v5, v6
            v21 = US5_0()
            return method1(v21, v1, v2, v3, v4, v19, v20)
        case US0_2(): # StartGame
            del v0, v1, v2, v3, v4
            v7 = [None] * 2
            v8 = [0]
            v9 = US5_0()
            v10 = 0
            v11 = US3_2(v10)
            del v10
            v12 = US4_0()
            return method1(v9, v7, v8, v11, v12, v5, v6)
def method2(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def main():
    v0 = [None] * 2
    v1 = [0]
    v2 = US0_2()
    v3 = US3_0()
    v4 = US4_2()
    v5 = US2_1()
    v6 = US2_0()
    v7, v8, v9, v10, v11, v12 = method0(v2, v0, v1, v3, v4, v5, v6)
    del v0, v1, v2, v3, v4, v5, v6
    print('{', end="")
    v13 = "game_state"
    print(v13, end="")
    v14 = " = "
    print(v14, end="")
    print('{', end="")
    v15 = "past_actions"
    print(v15, end="")
    del v15
    print(v14, end="")
    v16 = "["
    print(v16, end="")
    del v16
    v17 = v8[0]
    v18 = 100 < v17
    if v18:
        v19 = 100
    else:
        v19 = v17
    del v17, v18
    v20 = 0
    while method2(v19, v20):
        v22 = 0 <= v20
        if v22:
            v23 = v8[0]
            v24 = v20 < v23
            del v23
            v25 = v24
        else:
            v25 = False
        v26 = v25 == False
        if v26:
            v27 = "The read index needs to be in range."
            assert v25, v27
            del v27
        else:
            pass
        del v25, v26
        if v22:
            v28 = v20 < 2
            v29 = v28
        else:
            v29 = False
        del v22
        v30 = v29 == False
        if v30:
            v31 = "The read index needs to be in range."
            assert v29, v31
            del v31
        else:
            pass
        del v29, v30
        v32 = v7[v20]
        match v32:
            case US1_0(): # Paper
                v33 = "Paper"
                print(v33, end="")
                del v33
            case US1_1(): # Rock
                v34 = "Rock"
                print(v34, end="")
                del v34
            case US1_2(): # Scissors
                v35 = "Scissors"
                print(v35, end="")
                del v35
        del v32
        v36 = v20 + 1
        v37 = v8[0]
        v38 = v36 < v37
        del v36, v37
        if v38:
            v39 = "; "
            print(v39, end="")
            del v39
        else:
            pass
        del v38
        v20 += 1 
    del v7, v19, v20
    v40 = v8[0]
    del v8
    v41 = v40 > 100
    del v40
    if v41:
        v42 = "; ..."
        print(v42, end="")
        del v42
    else:
        pass
    del v41
    v43 = "]"
    print(v43, end="")
    del v43
    print('}', end="")
    v44 = "; "
    print(v44, end="")
    v45 = "ui_state"
    print(v45, end="")
    del v45
    print(v14, end="")
    print('{', end="")
    print(v13, end="")
    del v13
    print(v14, end="")
    match v9:
        case US3_0(): # GameNotStarted
            v46 = "GameNotStarted"
            print(v46, end="")
            del v46
        case US3_1(v47, v48): # GameOver
            v49 = "GameOver"
            print(v49, end="")
            del v49
            v50 = "("
            print(v50, end="")
            del v50
            match v47:
                case US1_0(): # Paper
                    v51 = "Paper"
                    print(v51, end="")
                    del v51
                case US1_1(): # Rock
                    v52 = "Rock"
                    print(v52, end="")
                    del v52
                case US1_2(): # Scissors
                    v53 = "Scissors"
                    print(v53, end="")
                    del v53
            del v47
            v54 = ", "
            print(v54, end="")
            del v54
            match v48:
                case US1_0(): # Paper
                    v55 = "Paper"
                    print(v55, end="")
                    del v55
                case US1_1(): # Rock
                    v56 = "Rock"
                    print(v56, end="")
                    del v56
                case US1_2(): # Scissors
                    v57 = "Scissors"
                    print(v57, end="")
                    del v57
            del v48
            v58 = ")"
            print(v58, end="")
            del v58
        case US3_2(v59): # WaitingForActionFromPlayerId
            v60 = "WaitingForActionFromPlayerId"
            print(v60, end="")
            del v60
            v61 = "("
            print(v61, end="")
            del v61
            print(v59, end="")
            del v59
            v62 = ")"
            print(v62, end="")
            del v62
    del v9
    print(v44, end="")
    v63 = "messages"
    print(v63, end="")
    del v63
    print(v14, end="")
    match v10:
        case US4_0(): # GameStarted
            v64 = "GameStarted"
            print(v64, end="")
            del v64
        case US4_1(v65, v66): # ShowdownResult
            v67 = "ShowdownResult"
            print(v67, end="")
            del v67
            v68 = "("
            print(v68, end="")
            del v68
            match v65:
                case US1_0(): # Paper
                    v69 = "Paper"
                    print(v69, end="")
                    del v69
                case US1_1(): # Rock
                    v70 = "Rock"
                    print(v70, end="")
                    del v70
                case US1_2(): # Scissors
                    v71 = "Scissors"
                    print(v71, end="")
                    del v71
            del v65
            v72 = ", "
            print(v72, end="")
            del v72
            match v66:
                case US1_0(): # Paper
                    v73 = "Paper"
                    print(v73, end="")
                    del v73
                case US1_1(): # Rock
                    v74 = "Rock"
                    print(v74, end="")
                    del v74
                case US1_2(): # Scissors
                    v75 = "Scissors"
                    print(v75, end="")
                    del v75
            del v66
            v76 = ")"
            print(v76, end="")
            del v76
        case US4_2(): # WaitingToStart
            v77 = "WaitingToStart"
            print(v77, end="")
            del v77
    del v10
    print(v44, end="")
    del v44
    v78 = "pl_type"
    print(v78, end="")
    del v78
    print(v14, end="")
    del v14
    match v11:
        case US2_0(): # Computer
            v79 = "Computer"
            print(v79, end="")
            del v79
        case US2_1(): # Human
            v80 = "Human"
            print(v80, end="")
            del v80
    del v11
    v81 = ", "
    print(v81, end="")
    del v81
    match v12:
        case US2_0(): # Computer
            v82 = "Computer"
            print(v82, end="")
            del v82
        case US2_1(): # Human
            v83 = "Human"
            print(v83, end="")
            del v83
    del v12
    print('}', end="")
    print('}', end="")
    print()
    return 

if __name__ == '__main__': print(main())
