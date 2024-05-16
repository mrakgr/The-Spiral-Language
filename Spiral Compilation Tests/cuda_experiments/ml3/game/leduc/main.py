kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
import collections
UH0 = Union["UH0_0", "UH0_1", "UH0_2"]
class US1_0(NamedTuple): # Call
    tag = 0
class US1_1(NamedTuple): # Fold
    tag = 1
class US1_2(NamedTuple): # Raise
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
    v0 : list[US2]
    tag = 1
class US0_2(NamedTuple): # StartGame
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US5_0(NamedTuple): # Jack
    tag = 0
class US5_1(NamedTuple): # King
    tag = 1
class US5_2(NamedTuple): # Queen
    tag = 2
US5 = Union[US5_0, US5_1, US5_2]
class US4_0(NamedTuple): # None
    tag = 0
class US4_1(NamedTuple): # Some
    v0 : US5
    tag = 1
US4 = Union[US4_0, US4_1]
class US6_0(NamedTuple): # CommunityCardIs
    v0 : US5
    tag = 0
class US6_1(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 1
class US6_2(NamedTuple): # PlayerGotCard
    v0 : i32
    v1 : US5
    tag = 2
class US6_3(NamedTuple): # Showdown
    v0 : list[US5]
    v1 : i32
    v2 : i32
    tag = 3
US6 = Union[US6_0, US6_1, US6_2, US6_3]
class UH0_0(NamedTuple): # Action
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    v6 : Callable[[US1], Tuple[UH0, US6]]
    tag = 0
class UH0_1(NamedTuple): # Chance
    v0 : Callable[[US5], Tuple[UH0, US6]]
    tag = 1
class UH0_2(NamedTuple): # Terminal
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    v6 : f32
    v7 : US6
    tag = 2
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : Callable[[US1], UH0]
    v1 : list[US5]
    v2 : list
    tag = 1
US3 = Union[US3_0, US3_1]
class US7_0(NamedTuple): # GameNotStarted
    tag = 0
class US7_1(NamedTuple): # GameOver
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 1
class US7_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : US4
    v1 : bool
    v2 : list[US5]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
US7 = Union[US7_0, US7_1, US7_2]
def Closure1(env_v0 : list[US6], env_v1 : list, env_v2 : Callable[[US1], Tuple[UH0, US6]]):
    def inner(v3 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2
        v0 = env_v0; v1 = env_v1; v2 = env_v2
        v4, v5 = v2(v3)
        del v2
        v6 = v1[0]
        v7 = 1 + v6
        v1[0] = v7
        del v7
        v8 = 0 <= v6
        if v8:
            v9 = v1[0]
            v10 = v6 < v9
            del v9
            v11 = v10
        else:
            v11 = False
        del v1
        v12 = v11 == False
        if v12:
            v13 = "The set index needs to be in range."
            assert v11, v13
            del v13
        else:
            pass
        del v11, v12
        if v8:
            v14 = v6 < 32
            v15 = v14
        else:
            v15 = False
        del v8
        v16 = v15 == False
        if v16:
            v17 = "The read index needs to be in range."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v0[v6] = v5
        del v0, v5, v6
        return v4
    return inner
def Closure4(env_v0 : US4, env_v1 : bool, env_v2 : list[US5], env_v3 : i32, env_v4 : list[i32], env_v5 : i32, env_v6 : Callable[[US1], UH0]):
    def inner(v7 : US1) -> Tuple[UH0, US6]:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6
        del v0, v1, v2, v4, v5
        v8 = v6(v7)
        del v6
        v9 = US6_1(v3, v7)
        del v3
        return v8, v9
    return inner
def Closure3(env_v0 : US4, env_v1 : bool, env_v2 : list[US5], env_v3 : i32, env_v4 : list[i32], env_v5 : i32):
    def inner(v6 : Callable[[US1], UH0]) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5
        v7 = Closure4(v0, v1, v2, v3, v4, v5, v6)
        return UH0_0(v0, v1, v2, v3, v4, v5, v7)
    return inner
def Closure2():
    def inner(v0 : US4, v1 : bool, v2 : list[US5], v3 : i32, v4 : list[i32], v5 : i32) -> Callable[[Callable[[US1], UH0]], UH0]:
        return Closure3(v0, v1, v2, v3, v4, v5)
    return inner
def Closure6(env_v0 : Callable[[US5], UH0]):
    def inner(v1 : US5) -> Tuple[UH0, US6]:
        nonlocal env_v0
        v0 = env_v0
        v2 = v0(v1)
        del v0
        v3 = US6_0(v1)
        return v2, v3
    return inner
def Closure5():
    def inner(v0 : Callable[[US5], UH0]) -> UH0:
        v1 = Closure6(v0)
        return UH0_1(v1)
    return inner
def Closure9(env_v0 : i32, env_v1 : Callable[[US5], UH0]):
    def inner(v2 : US5) -> Tuple[UH0, US6]:
        nonlocal env_v0, env_v1
        v0 = env_v0; v1 = env_v1
        v3 = v1(v2)
        del v1
        v4 = US6_2(v0, v2)
        del v0
        return v3, v4
    return inner
def Closure8(env_v0 : i32):
    def inner(v1 : Callable[[US5], UH0]) -> UH0:
        nonlocal env_v0
        v0 = env_v0
        v2 = Closure9(v0, v1)
        del v0
        return UH0_1(v2)
    return inner
def Closure7():
    def inner(v0 : i32) -> Callable[[Callable[[US5], UH0]], UH0]:
        return Closure8(v0)
    return inner
class US8_0(NamedTuple): # Eq
    tag = 0
class US8_1(NamedTuple): # Gt
    tag = 1
class US8_2(NamedTuple): # Lt
    tag = 2
US8 = Union[US8_0, US8_1, US8_2]
def Closure10():
    def inner(v0 : US4, v1 : bool, v2 : list[US5], v3 : i32, v4 : list[i32], v5 : i32) -> UH0:
        v6 = 0 <= v3
        if v6:
            v7 = v3 < 2
            v8 = v7
        else:
            v8 = False
        del v6
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v4[v3]
        v12 = method14(v0, v1, v2, v3, v4, v5)
        match v12:
            case US8_0(): # Eq
                v22, v23, v24 = 0.0, 0, -1
            case US8_1(): # Gt
                v13 = f32(v11)
                v22, v23, v24 = v13, v11, 0
            case US8_2(): # Lt
                v14 = -v11
                v15 = f32(v14)
                del v14
                v22, v23, v24 = v15, v11, 1
            case _:
                raise Exception('Pattern matching miss.')
        del v11, v12
        v25 = US6_3(v2, v23, v24)
        del v23, v24
        return UH0_2(v0, v1, v2, v3, v4, v5, v22, v25)
    return inner
def Closure11():
    def inner(v0 : US4, v1 : bool, v2 : list[US5], v3 : i32, v4 : list[i32], v5 : i32) -> UH0:
        v6 = 0 <= v3
        if v6:
            v7 = v3 < 2
            v8 = v7
        else:
            v8 = False
        del v6
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v4[v3]
        v12 = v3 == 0
        if v12:
            v13 = -v11
            v14 = v13
        else:
            v14 = v11
        v15 = f32(v14)
        del v14
        if v12:
            v16 = 1
        else:
            v16 = 0
        del v12
        v17 = US6_3(v2, v11, v16)
        del v11, v16
        return UH0_2(v0, v1, v2, v3, v4, v5, v15, v17)
    return inner
def Closure19(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : US5, env_v6 : list[US5], env_v7 : list[i32], env_v8 : i32):
    def inner(v9 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7, env_v8
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7; v8 = env_v8
        print('{', end="")
        v10 = "action"
        print(v10, end="")
        del v10
        v11 = " = "
        print(v11, end="")
        match v9:
            case US1_0(): # Call
                v12 = "Call"
                print(v12, end="")
                del v12
            case US1_1(): # Fold
                v13 = "Fold"
                print(v13, end="")
                del v13
            case US1_2(): # Raise
                v14 = "Raise"
                print(v14, end="")
                del v14
            case _:
                raise Exception('Pattern matching miss.')
        print('}', end="")
        print()
        match v9:
            case US1_0(): # Call
                del v0, v1, v2, v4, v11
                v17, v18 = (0, 0)
                while method19(v17):
                    v20 = 0 <= v17
                    if v20:
                        v21 = v17 < 2
                        v22 = v21
                    else:
                        v22 = False
                    del v20
                    v23 = v22 == False
                    if v23:
                        v24 = "The read index needs to be in range."
                        assert v22, v24
                        del v24
                    else:
                        pass
                    del v22, v23
                    v25 = v7[v17]
                    v26 = v18 >= v25
                    if v26:
                        v27 = v18
                    else:
                        v27 = v25
                    del v25, v26
                    v18 = v27
                    del v27
                    v17 += 1 
                del v7, v17
                v28 = [None] * 2
                v29 = 0
                while method19(v29):
                    v31 = 0 <= v29
                    if v31:
                        v32 = v29 < 2
                        v33 = v32
                    else:
                        v33 = False
                    del v31
                    v34 = v33 == False
                    if v34:
                        v35 = "The read index needs to be in range."
                        assert v33, v35
                        del v35
                    else:
                        pass
                    del v33, v34
                    v28[v29] = v18
                    v29 += 1 
                del v18, v29
                v36 = US4_1(v5)
                del v5
                return v3(v36, False, v6, 0, v28, v8)
            case US1_1(): # Fold
                del v0, v1, v2, v3, v11
                v15 = US4_1(v5)
                del v5
                return v4(v15, False, v6, 0, v7, v8)
            case US1_2(): # Raise
                v38 = v8 > 0
                if v38:
                    del v38
                    v39 = -1 + v8
                    del v8
                    v40, v41 = (0, 0)
                    while method19(v40):
                        v43 = 0 <= v40
                        if v43:
                            v44 = v40 < 2
                            v45 = v44
                        else:
                            v45 = False
                        del v43
                        v46 = v45 == False
                        if v46:
                            v47 = "The read index needs to be in range."
                            assert v45, v47
                            del v47
                        else:
                            pass
                        del v45, v46
                        v48 = v7[v40]
                        v49 = v41 >= v48
                        if v49:
                            v50 = v41
                        else:
                            v50 = v48
                        del v48, v49
                        v41 = v50
                        del v50
                        v40 += 1 
                    del v7, v40
                    v51 = [None] * 2
                    v52 = 0
                    while method19(v52):
                        v54 = 0 <= v52
                        if v54:
                            v55 = v52 < 2
                            v56 = v55
                        else:
                            v56 = False
                        del v54
                        v57 = v56 == False
                        if v57:
                            v58 = "The read index needs to be in range."
                            assert v56, v58
                            del v58
                        else:
                            pass
                        del v56, v57
                        v51[v52] = v41
                        v52 += 1 
                    del v41, v52
                    v59 = [None] * 2
                    v60 = 0
                    while method19(v60):
                        v62 = 0 <= v60
                        if v62:
                            v63 = v60 < 2
                            v64 = v63
                        else:
                            v64 = False
                        v65 = v64 == False
                        if v65:
                            v66 = "The read index needs to be in range."
                            assert v64, v66
                            del v66
                        else:
                            pass
                        del v64, v65
                        v67 = v51[v60]
                        v68 = v60 == 0
                        if v68:
                            v69 = v67 + 4
                            v70 = v69
                        else:
                            v70 = v67
                        del v67, v68
                        if v62:
                            v71 = v60 < 2
                            v72 = v71
                        else:
                            v72 = False
                        del v62
                        v73 = v72 == False
                        if v73:
                            v74 = "The read index needs to be in range."
                            assert v72, v74
                            del v74
                        else:
                            pass
                        del v72, v73
                        v59[v60] = v70
                        del v70
                        v60 += 1 
                    del v51, v60
                    print('{', end="")
                    v75 = "table"
                    print(v75, end="")
                    del v75
                    print(v11, end="")
                    print('{', end="")
                    v76 = "community_card"
                    print(v76, end="")
                    del v76
                    print(v11, end="")
                    v78 = "Some"
                    print(v78, end="")
                    del v78
                    v79 = "("
                    print(v79, end="")
                    del v79
                    match v5:
                        case US5_0(): # Jack
                            v80 = "Jack"
                            print(v80, end="")
                            del v80
                        case US5_1(): # King
                            v81 = "King"
                            print(v81, end="")
                            del v81
                        case US5_2(): # Queen
                            v82 = "Queen"
                            print(v82, end="")
                            del v82
                        case _:
                            raise Exception('Pattern matching miss.')
                    v83 = ")"
                    print(v83, end="")
                    del v83
                    v84 = "; "
                    print(v84, end="")
                    v85 = "is_button_s_first_move"
                    print(v85, end="")
                    del v85
                    print(v11, end="")
                    v86 = "false"
                    print(v86, end="")
                    del v86
                    print(v84, end="")
                    v87 = "pl_card"
                    print(v87, end="")
                    del v87
                    print(v11, end="")
                    v88 = "["
                    print(v88, end="")
                    v89 = 0
                    while method19(v89):
                        v91 = 0 <= v89
                        if v91:
                            v92 = v89 < 2
                            v93 = v92
                        else:
                            v93 = False
                        del v91
                        v94 = v93 == False
                        if v94:
                            v95 = "The read index needs to be in range."
                            assert v93, v95
                            del v95
                        else:
                            pass
                        del v93, v94
                        v96 = v6[v89]
                        match v96:
                            case US5_0(): # Jack
                                v97 = "Jack"
                                print(v97, end="")
                                del v97
                            case US5_1(): # King
                                v98 = "King"
                                print(v98, end="")
                                del v98
                            case US5_2(): # Queen
                                v99 = "Queen"
                                print(v99, end="")
                                del v99
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v96
                        v100 = v89 + 1
                        v101 = v100 < 2
                        del v100
                        if v101:
                            print(v84, end="")
                        else:
                            pass
                        del v101
                        v89 += 1 
                    del v89
                    v102 = "]"
                    print(v102, end="")
                    print(v84, end="")
                    v103 = "player_turn"
                    print(v103, end="")
                    del v103
                    print(v11, end="")
                    print(1, end="")
                    print(v84, end="")
                    v104 = "pot"
                    print(v104, end="")
                    del v104
                    print(v11, end="")
                    print(v88, end="")
                    del v88
                    v105 = 0
                    while method19(v105):
                        v107 = 0 <= v105
                        if v107:
                            v108 = v105 < 2
                            v109 = v108
                        else:
                            v109 = False
                        del v107
                        v110 = v109 == False
                        if v110:
                            v111 = "The read index needs to be in range."
                            assert v109, v111
                            del v111
                        else:
                            pass
                        del v109, v110
                        v112 = v59[v105]
                        print(v112, end="")
                        del v112
                        v113 = v105 + 1
                        v114 = v113 < 2
                        del v113
                        if v114:
                            print(v84, end="")
                        else:
                            pass
                        del v114
                        v105 += 1 
                    del v105
                    print(v102, end="")
                    del v102
                    print(v84, end="")
                    del v84
                    v115 = "raises_left"
                    print(v115, end="")
                    del v115
                    print(v11, end="")
                    del v11
                    print(v39, end="")
                    print('}', end="")
                    print('}', end="")
                    print()
                    v116 = US4_1(v5)
                    v117 = v0(v116, False, v6, 1, v59, v39)
                    del v116
                    v118 = Closure18(v0, v1, v2, v3, v4, v5, v6, v59, v39)
                    del v0, v1, v2, v3, v4, v5, v6, v39, v59
                    return v117(v118)
                else:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v8, v11, v38
                    raise Exception("Invalid action. The number of raises left is not positive.")
            case _:
                raise Exception('Pattern matching miss.')
    return inner
def Closure18(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : US5, env_v6 : list[US5], env_v7 : list[i32], env_v8 : i32):
    def inner(v9 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7, env_v8
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7; v8 = env_v8
        print('{', end="")
        v10 = "action"
        print(v10, end="")
        del v10
        v11 = " = "
        print(v11, end="")
        match v9:
            case US1_0(): # Call
                v12 = "Call"
                print(v12, end="")
                del v12
            case US1_1(): # Fold
                v13 = "Fold"
                print(v13, end="")
                del v13
            case US1_2(): # Raise
                v14 = "Raise"
                print(v14, end="")
                del v14
            case _:
                raise Exception('Pattern matching miss.')
        print('}', end="")
        print()
        match v9:
            case US1_0(): # Call
                del v0, v1, v2, v4, v11
                v17, v18 = (0, 0)
                while method19(v17):
                    v20 = 0 <= v17
                    if v20:
                        v21 = v17 < 2
                        v22 = v21
                    else:
                        v22 = False
                    del v20
                    v23 = v22 == False
                    if v23:
                        v24 = "The read index needs to be in range."
                        assert v22, v24
                        del v24
                    else:
                        pass
                    del v22, v23
                    v25 = v7[v17]
                    v26 = v18 >= v25
                    if v26:
                        v27 = v18
                    else:
                        v27 = v25
                    del v25, v26
                    v18 = v27
                    del v27
                    v17 += 1 
                del v7, v17
                v28 = [None] * 2
                v29 = 0
                while method19(v29):
                    v31 = 0 <= v29
                    if v31:
                        v32 = v29 < 2
                        v33 = v32
                    else:
                        v33 = False
                    del v31
                    v34 = v33 == False
                    if v34:
                        v35 = "The read index needs to be in range."
                        assert v33, v35
                        del v35
                    else:
                        pass
                    del v33, v34
                    v28[v29] = v18
                    v29 += 1 
                del v18, v29
                v36 = US4_1(v5)
                del v5
                return v3(v36, False, v6, 1, v28, v8)
            case US1_1(): # Fold
                del v0, v1, v2, v3, v11
                v15 = US4_1(v5)
                del v5
                return v4(v15, False, v6, 1, v7, v8)
            case US1_2(): # Raise
                v38 = v8 > 0
                if v38:
                    del v38
                    v39 = -1 + v8
                    del v8
                    v40, v41 = (0, 0)
                    while method19(v40):
                        v43 = 0 <= v40
                        if v43:
                            v44 = v40 < 2
                            v45 = v44
                        else:
                            v45 = False
                        del v43
                        v46 = v45 == False
                        if v46:
                            v47 = "The read index needs to be in range."
                            assert v45, v47
                            del v47
                        else:
                            pass
                        del v45, v46
                        v48 = v7[v40]
                        v49 = v41 >= v48
                        if v49:
                            v50 = v41
                        else:
                            v50 = v48
                        del v48, v49
                        v41 = v50
                        del v50
                        v40 += 1 
                    del v7, v40
                    v51 = [None] * 2
                    v52 = 0
                    while method19(v52):
                        v54 = 0 <= v52
                        if v54:
                            v55 = v52 < 2
                            v56 = v55
                        else:
                            v56 = False
                        del v54
                        v57 = v56 == False
                        if v57:
                            v58 = "The read index needs to be in range."
                            assert v56, v58
                            del v58
                        else:
                            pass
                        del v56, v57
                        v51[v52] = v41
                        v52 += 1 
                    del v41, v52
                    v59 = [None] * 2
                    v60 = 0
                    while method19(v60):
                        v62 = 0 <= v60
                        if v62:
                            v63 = v60 < 2
                            v64 = v63
                        else:
                            v64 = False
                        v65 = v64 == False
                        if v65:
                            v66 = "The read index needs to be in range."
                            assert v64, v66
                            del v66
                        else:
                            pass
                        del v64, v65
                        v67 = v51[v60]
                        v68 = v60 == 1
                        if v68:
                            v69 = v67 + 4
                            v70 = v69
                        else:
                            v70 = v67
                        del v67, v68
                        if v62:
                            v71 = v60 < 2
                            v72 = v71
                        else:
                            v72 = False
                        del v62
                        v73 = v72 == False
                        if v73:
                            v74 = "The read index needs to be in range."
                            assert v72, v74
                            del v74
                        else:
                            pass
                        del v72, v73
                        v59[v60] = v70
                        del v70
                        v60 += 1 
                    del v51, v60
                    print('{', end="")
                    v75 = "table"
                    print(v75, end="")
                    del v75
                    print(v11, end="")
                    print('{', end="")
                    v76 = "community_card"
                    print(v76, end="")
                    del v76
                    print(v11, end="")
                    v78 = "Some"
                    print(v78, end="")
                    del v78
                    v79 = "("
                    print(v79, end="")
                    del v79
                    match v5:
                        case US5_0(): # Jack
                            v80 = "Jack"
                            print(v80, end="")
                            del v80
                        case US5_1(): # King
                            v81 = "King"
                            print(v81, end="")
                            del v81
                        case US5_2(): # Queen
                            v82 = "Queen"
                            print(v82, end="")
                            del v82
                        case _:
                            raise Exception('Pattern matching miss.')
                    v83 = ")"
                    print(v83, end="")
                    del v83
                    v84 = "; "
                    print(v84, end="")
                    v85 = "is_button_s_first_move"
                    print(v85, end="")
                    del v85
                    print(v11, end="")
                    v86 = "false"
                    print(v86, end="")
                    del v86
                    print(v84, end="")
                    v87 = "pl_card"
                    print(v87, end="")
                    del v87
                    print(v11, end="")
                    v88 = "["
                    print(v88, end="")
                    v89 = 0
                    while method19(v89):
                        v91 = 0 <= v89
                        if v91:
                            v92 = v89 < 2
                            v93 = v92
                        else:
                            v93 = False
                        del v91
                        v94 = v93 == False
                        if v94:
                            v95 = "The read index needs to be in range."
                            assert v93, v95
                            del v95
                        else:
                            pass
                        del v93, v94
                        v96 = v6[v89]
                        match v96:
                            case US5_0(): # Jack
                                v97 = "Jack"
                                print(v97, end="")
                                del v97
                            case US5_1(): # King
                                v98 = "King"
                                print(v98, end="")
                                del v98
                            case US5_2(): # Queen
                                v99 = "Queen"
                                print(v99, end="")
                                del v99
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v96
                        v100 = v89 + 1
                        v101 = v100 < 2
                        del v100
                        if v101:
                            print(v84, end="")
                        else:
                            pass
                        del v101
                        v89 += 1 
                    del v89
                    v102 = "]"
                    print(v102, end="")
                    print(v84, end="")
                    v103 = "player_turn"
                    print(v103, end="")
                    del v103
                    print(v11, end="")
                    print(0, end="")
                    print(v84, end="")
                    v104 = "pot"
                    print(v104, end="")
                    del v104
                    print(v11, end="")
                    print(v88, end="")
                    del v88
                    v105 = 0
                    while method19(v105):
                        v107 = 0 <= v105
                        if v107:
                            v108 = v105 < 2
                            v109 = v108
                        else:
                            v109 = False
                        del v107
                        v110 = v109 == False
                        if v110:
                            v111 = "The read index needs to be in range."
                            assert v109, v111
                            del v111
                        else:
                            pass
                        del v109, v110
                        v112 = v59[v105]
                        print(v112, end="")
                        del v112
                        v113 = v105 + 1
                        v114 = v113 < 2
                        del v113
                        if v114:
                            print(v84, end="")
                        else:
                            pass
                        del v114
                        v105 += 1 
                    del v105
                    print(v102, end="")
                    del v102
                    print(v84, end="")
                    del v84
                    v115 = "raises_left"
                    print(v115, end="")
                    del v115
                    print(v11, end="")
                    del v11
                    print(v39, end="")
                    print('}', end="")
                    print('}', end="")
                    print()
                    v116 = US4_1(v5)
                    v117 = v0(v116, False, v6, 0, v59, v39)
                    del v116
                    v118 = Closure19(v0, v1, v2, v3, v4, v5, v6, v59, v39)
                    del v0, v1, v2, v3, v4, v5, v6, v39, v59
                    return v117(v118)
                else:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v8, v11, v38
                    raise Exception("Invalid action. The number of raises left is not positive.")
            case _:
                raise Exception('Pattern matching miss.')
    return inner
def Closure17(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : US5, env_v6 : list[US5], env_v7 : list[i32], env_v8 : i32):
    def inner(v9 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7, env_v8
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7; v8 = env_v8
        print('{', end="")
        v10 = "action"
        print(v10, end="")
        del v10
        v11 = " = "
        print(v11, end="")
        match v9:
            case US1_0(): # Call
                v12 = "Call"
                print(v12, end="")
                del v12
            case US1_1(): # Fold
                v13 = "Fold"
                print(v13, end="")
                del v13
            case US1_2(): # Raise
                v14 = "Raise"
                print(v14, end="")
                del v14
            case _:
                raise Exception('Pattern matching miss.')
        print('}', end="")
        print()
        match v9:
            case US1_0(): # Call
                print('{', end="")
                v17 = "table"
                print(v17, end="")
                del v17
                print(v11, end="")
                print('{', end="")
                v18 = "community_card"
                print(v18, end="")
                del v18
                print(v11, end="")
                v20 = "Some"
                print(v20, end="")
                del v20
                v21 = "("
                print(v21, end="")
                del v21
                match v5:
                    case US5_0(): # Jack
                        v22 = "Jack"
                        print(v22, end="")
                        del v22
                    case US5_1(): # King
                        v23 = "King"
                        print(v23, end="")
                        del v23
                    case US5_2(): # Queen
                        v24 = "Queen"
                        print(v24, end="")
                        del v24
                    case _:
                        raise Exception('Pattern matching miss.')
                v25 = ")"
                print(v25, end="")
                del v25
                v26 = "; "
                print(v26, end="")
                v27 = "is_button_s_first_move"
                print(v27, end="")
                del v27
                print(v11, end="")
                v28 = "false"
                print(v28, end="")
                del v28
                print(v26, end="")
                v29 = "pl_card"
                print(v29, end="")
                del v29
                print(v11, end="")
                v30 = "["
                print(v30, end="")
                v31 = 0
                while method19(v31):
                    v33 = 0 <= v31
                    if v33:
                        v34 = v31 < 2
                        v35 = v34
                    else:
                        v35 = False
                    del v33
                    v36 = v35 == False
                    if v36:
                        v37 = "The read index needs to be in range."
                        assert v35, v37
                        del v37
                    else:
                        pass
                    del v35, v36
                    v38 = v6[v31]
                    match v38:
                        case US5_0(): # Jack
                            v39 = "Jack"
                            print(v39, end="")
                            del v39
                        case US5_1(): # King
                            v40 = "King"
                            print(v40, end="")
                            del v40
                        case US5_2(): # Queen
                            v41 = "Queen"
                            print(v41, end="")
                            del v41
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v38
                    v42 = v31 + 1
                    v43 = v42 < 2
                    del v42
                    if v43:
                        print(v26, end="")
                    else:
                        pass
                    del v43
                    v31 += 1 
                del v31
                v44 = "]"
                print(v44, end="")
                print(v26, end="")
                v45 = "player_turn"
                print(v45, end="")
                del v45
                print(v11, end="")
                print(1, end="")
                print(v26, end="")
                v46 = "pot"
                print(v46, end="")
                del v46
                print(v11, end="")
                print(v30, end="")
                del v30
                v47 = 0
                while method19(v47):
                    v49 = 0 <= v47
                    if v49:
                        v50 = v47 < 2
                        v51 = v50
                    else:
                        v51 = False
                    del v49
                    v52 = v51 == False
                    if v52:
                        v53 = "The read index needs to be in range."
                        assert v51, v53
                        del v53
                    else:
                        pass
                    del v51, v52
                    v54 = v7[v47]
                    print(v54, end="")
                    del v54
                    v55 = v47 + 1
                    v56 = v55 < 2
                    del v55
                    if v56:
                        print(v26, end="")
                    else:
                        pass
                    del v56
                    v47 += 1 
                del v47
                print(v44, end="")
                del v44
                print(v26, end="")
                del v26
                v57 = "raises_left"
                print(v57, end="")
                del v57
                print(v11, end="")
                del v11
                print(v8, end="")
                print('}', end="")
                print('}', end="")
                print()
                v58 = US4_1(v5)
                v59 = v0(v58, False, v6, 1, v7, v8)
                del v58
                v60 = Closure18(v0, v1, v2, v3, v4, v5, v6, v7, v8)
                del v0, v1, v2, v3, v4, v5, v6, v7, v8
                return v59(v60)
            case US1_1(): # Fold
                del v0, v1, v2, v3, v11
                v15 = US4_1(v5)
                del v5
                return v4(v15, True, v6, 0, v7, v8)
            case US1_2(): # Raise
                v62 = v8 > 0
                if v62:
                    del v62
                    v63 = -1 + v8
                    del v8
                    v64, v65 = (0, 0)
                    while method19(v64):
                        v67 = 0 <= v64
                        if v67:
                            v68 = v64 < 2
                            v69 = v68
                        else:
                            v69 = False
                        del v67
                        v70 = v69 == False
                        if v70:
                            v71 = "The read index needs to be in range."
                            assert v69, v71
                            del v71
                        else:
                            pass
                        del v69, v70
                        v72 = v7[v64]
                        v73 = v65 >= v72
                        if v73:
                            v74 = v65
                        else:
                            v74 = v72
                        del v72, v73
                        v65 = v74
                        del v74
                        v64 += 1 
                    del v7, v64
                    v75 = [None] * 2
                    v76 = 0
                    while method19(v76):
                        v78 = 0 <= v76
                        if v78:
                            v79 = v76 < 2
                            v80 = v79
                        else:
                            v80 = False
                        del v78
                        v81 = v80 == False
                        if v81:
                            v82 = "The read index needs to be in range."
                            assert v80, v82
                            del v82
                        else:
                            pass
                        del v80, v81
                        v75[v76] = v65
                        v76 += 1 
                    del v65, v76
                    v83 = [None] * 2
                    v84 = 0
                    while method19(v84):
                        v86 = 0 <= v84
                        if v86:
                            v87 = v84 < 2
                            v88 = v87
                        else:
                            v88 = False
                        v89 = v88 == False
                        if v89:
                            v90 = "The read index needs to be in range."
                            assert v88, v90
                            del v90
                        else:
                            pass
                        del v88, v89
                        v91 = v75[v84]
                        v92 = v84 == 0
                        if v92:
                            v93 = v91 + 4
                            v94 = v93
                        else:
                            v94 = v91
                        del v91, v92
                        if v86:
                            v95 = v84 < 2
                            v96 = v95
                        else:
                            v96 = False
                        del v86
                        v97 = v96 == False
                        if v97:
                            v98 = "The read index needs to be in range."
                            assert v96, v98
                            del v98
                        else:
                            pass
                        del v96, v97
                        v83[v84] = v94
                        del v94
                        v84 += 1 
                    del v75, v84
                    print('{', end="")
                    v99 = "table"
                    print(v99, end="")
                    del v99
                    print(v11, end="")
                    print('{', end="")
                    v100 = "community_card"
                    print(v100, end="")
                    del v100
                    print(v11, end="")
                    v102 = "Some"
                    print(v102, end="")
                    del v102
                    v103 = "("
                    print(v103, end="")
                    del v103
                    match v5:
                        case US5_0(): # Jack
                            v104 = "Jack"
                            print(v104, end="")
                            del v104
                        case US5_1(): # King
                            v105 = "King"
                            print(v105, end="")
                            del v105
                        case US5_2(): # Queen
                            v106 = "Queen"
                            print(v106, end="")
                            del v106
                        case _:
                            raise Exception('Pattern matching miss.')
                    v107 = ")"
                    print(v107, end="")
                    del v107
                    v108 = "; "
                    print(v108, end="")
                    v109 = "is_button_s_first_move"
                    print(v109, end="")
                    del v109
                    print(v11, end="")
                    v110 = "false"
                    print(v110, end="")
                    del v110
                    print(v108, end="")
                    v111 = "pl_card"
                    print(v111, end="")
                    del v111
                    print(v11, end="")
                    v112 = "["
                    print(v112, end="")
                    v113 = 0
                    while method19(v113):
                        v115 = 0 <= v113
                        if v115:
                            v116 = v113 < 2
                            v117 = v116
                        else:
                            v117 = False
                        del v115
                        v118 = v117 == False
                        if v118:
                            v119 = "The read index needs to be in range."
                            assert v117, v119
                            del v119
                        else:
                            pass
                        del v117, v118
                        v120 = v6[v113]
                        match v120:
                            case US5_0(): # Jack
                                v121 = "Jack"
                                print(v121, end="")
                                del v121
                            case US5_1(): # King
                                v122 = "King"
                                print(v122, end="")
                                del v122
                            case US5_2(): # Queen
                                v123 = "Queen"
                                print(v123, end="")
                                del v123
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v120
                        v124 = v113 + 1
                        v125 = v124 < 2
                        del v124
                        if v125:
                            print(v108, end="")
                        else:
                            pass
                        del v125
                        v113 += 1 
                    del v113
                    v126 = "]"
                    print(v126, end="")
                    print(v108, end="")
                    v127 = "player_turn"
                    print(v127, end="")
                    del v127
                    print(v11, end="")
                    print(1, end="")
                    print(v108, end="")
                    v128 = "pot"
                    print(v128, end="")
                    del v128
                    print(v11, end="")
                    print(v112, end="")
                    del v112
                    v129 = 0
                    while method19(v129):
                        v131 = 0 <= v129
                        if v131:
                            v132 = v129 < 2
                            v133 = v132
                        else:
                            v133 = False
                        del v131
                        v134 = v133 == False
                        if v134:
                            v135 = "The read index needs to be in range."
                            assert v133, v135
                            del v135
                        else:
                            pass
                        del v133, v134
                        v136 = v83[v129]
                        print(v136, end="")
                        del v136
                        v137 = v129 + 1
                        v138 = v137 < 2
                        del v137
                        if v138:
                            print(v108, end="")
                        else:
                            pass
                        del v138
                        v129 += 1 
                    del v129
                    print(v126, end="")
                    del v126
                    print(v108, end="")
                    del v108
                    v139 = "raises_left"
                    print(v139, end="")
                    del v139
                    print(v11, end="")
                    del v11
                    print(v63, end="")
                    print('}', end="")
                    print('}', end="")
                    print()
                    v140 = US4_1(v5)
                    v141 = v0(v140, False, v6, 1, v83, v63)
                    del v140
                    v142 = Closure18(v0, v1, v2, v3, v4, v5, v6, v83, v63)
                    del v0, v1, v2, v3, v4, v5, v6, v63, v83
                    return v141(v142)
                else:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v8, v11, v62
                    raise Exception("Invalid action. The number of raises left is not positive.")
            case _:
                raise Exception('Pattern matching miss.')
    return inner
def Closure16(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : list[US5], env_v6 : list[i32], env_v7 : i32):
    def inner(v8 : US5) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7
        del v7
        v9 = 2
        v10, v11 = (0, 0)
        while method19(v10):
            v13 = 0 <= v10
            if v13:
                v14 = v10 < 2
                v15 = v14
            else:
                v15 = False
            del v13
            v16 = v15 == False
            if v16:
                v17 = "The read index needs to be in range."
                assert v15, v17
                del v17
            else:
                pass
            del v15, v16
            v18 = v6[v10]
            v19 = v11 >= v18
            if v19:
                v20 = v11
            else:
                v20 = v18
            del v18, v19
            v11 = v20
            del v20
            v10 += 1 
        del v6, v10
        v21 = [None] * 2
        v22 = 0
        while method19(v22):
            v24 = 0 <= v22
            if v24:
                v25 = v22 < 2
                v26 = v25
            else:
                v26 = False
            del v24
            v27 = v26 == False
            if v27:
                v28 = "The read index needs to be in range."
                assert v26, v28
                del v28
            else:
                pass
            del v26, v27
            v21[v22] = v11
            v22 += 1 
        del v11, v22
        print('{', end="")
        v29 = "table"
        print(v29, end="")
        del v29
        v30 = " = "
        print(v30, end="")
        print('{', end="")
        v31 = "community_card"
        print(v31, end="")
        del v31
        print(v30, end="")
        v33 = "Some"
        print(v33, end="")
        del v33
        v34 = "("
        print(v34, end="")
        del v34
        match v8:
            case US5_0(): # Jack
                v35 = "Jack"
                print(v35, end="")
                del v35
            case US5_1(): # King
                v36 = "King"
                print(v36, end="")
                del v36
            case US5_2(): # Queen
                v37 = "Queen"
                print(v37, end="")
                del v37
            case _:
                raise Exception('Pattern matching miss.')
        v38 = ")"
        print(v38, end="")
        del v38
        v39 = "; "
        print(v39, end="")
        v40 = "is_button_s_first_move"
        print(v40, end="")
        del v40
        print(v30, end="")
        v41 = "true"
        print(v41, end="")
        del v41
        print(v39, end="")
        v42 = "pl_card"
        print(v42, end="")
        del v42
        print(v30, end="")
        v43 = "["
        print(v43, end="")
        v44 = 0
        while method19(v44):
            v46 = 0 <= v44
            if v46:
                v47 = v44 < 2
                v48 = v47
            else:
                v48 = False
            del v46
            v49 = v48 == False
            if v49:
                v50 = "The read index needs to be in range."
                assert v48, v50
                del v50
            else:
                pass
            del v48, v49
            v51 = v5[v44]
            match v51:
                case US5_0(): # Jack
                    v52 = "Jack"
                    print(v52, end="")
                    del v52
                case US5_1(): # King
                    v53 = "King"
                    print(v53, end="")
                    del v53
                case US5_2(): # Queen
                    v54 = "Queen"
                    print(v54, end="")
                    del v54
                case _:
                    raise Exception('Pattern matching miss.')
            del v51
            v55 = v44 + 1
            v56 = v55 < 2
            del v55
            if v56:
                print(v39, end="")
            else:
                pass
            del v56
            v44 += 1 
        del v44
        v57 = "]"
        print(v57, end="")
        print(v39, end="")
        v58 = "player_turn"
        print(v58, end="")
        del v58
        print(v30, end="")
        print(0, end="")
        print(v39, end="")
        v59 = "pot"
        print(v59, end="")
        del v59
        print(v30, end="")
        print(v43, end="")
        del v43
        v60 = 0
        while method19(v60):
            v62 = 0 <= v60
            if v62:
                v63 = v60 < 2
                v64 = v63
            else:
                v64 = False
            del v62
            v65 = v64 == False
            if v65:
                v66 = "The read index needs to be in range."
                assert v64, v66
                del v66
            else:
                pass
            del v64, v65
            v67 = v21[v60]
            print(v67, end="")
            del v67
            v68 = v60 + 1
            v69 = v68 < 2
            del v68
            if v69:
                print(v39, end="")
            else:
                pass
            del v69
            v60 += 1 
        del v60
        print(v57, end="")
        del v57
        print(v39, end="")
        del v39
        v70 = "raises_left"
        print(v70, end="")
        del v70
        print(v30, end="")
        del v30
        print(v9, end="")
        print('}', end="")
        print('}', end="")
        print()
        v71 = US4_1(v8)
        v72 = v0(v71, True, v5, 0, v21, v9)
        del v71
        v73 = Closure17(v0, v1, v2, v3, v4, v8, v5, v21, v9)
        del v0, v1, v2, v3, v4, v5, v9, v21
        return v72(v73)
    return inner
def Closure21(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : list[US5], env_v6 : list[i32], env_v7 : i32):
    def inner(v8 : US5) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7
        del v7
        v9 = 2
        v10, v11 = (0, 0)
        while method19(v10):
            v13 = 0 <= v10
            if v13:
                v14 = v10 < 2
                v15 = v14
            else:
                v15 = False
            del v13
            v16 = v15 == False
            if v16:
                v17 = "The read index needs to be in range."
                assert v15, v17
                del v17
            else:
                pass
            del v15, v16
            v18 = v6[v10]
            v19 = v11 >= v18
            if v19:
                v20 = v11
            else:
                v20 = v18
            del v18, v19
            v11 = v20
            del v20
            v10 += 1 
        del v6, v10
        v21 = [None] * 2
        v22 = 0
        while method19(v22):
            v24 = 0 <= v22
            if v24:
                v25 = v22 < 2
                v26 = v25
            else:
                v26 = False
            del v24
            v27 = v26 == False
            if v27:
                v28 = "The read index needs to be in range."
                assert v26, v28
                del v28
            else:
                pass
            del v26, v27
            v21[v22] = v11
            v22 += 1 
        del v11, v22
        print('{', end="")
        v29 = "table"
        print(v29, end="")
        del v29
        v30 = " = "
        print(v30, end="")
        print('{', end="")
        v31 = "community_card"
        print(v31, end="")
        del v31
        print(v30, end="")
        v33 = "Some"
        print(v33, end="")
        del v33
        v34 = "("
        print(v34, end="")
        del v34
        match v8:
            case US5_0(): # Jack
                v35 = "Jack"
                print(v35, end="")
                del v35
            case US5_1(): # King
                v36 = "King"
                print(v36, end="")
                del v36
            case US5_2(): # Queen
                v37 = "Queen"
                print(v37, end="")
                del v37
            case _:
                raise Exception('Pattern matching miss.')
        v38 = ")"
        print(v38, end="")
        del v38
        v39 = "; "
        print(v39, end="")
        v40 = "is_button_s_first_move"
        print(v40, end="")
        del v40
        print(v30, end="")
        v41 = "true"
        print(v41, end="")
        del v41
        print(v39, end="")
        v42 = "pl_card"
        print(v42, end="")
        del v42
        print(v30, end="")
        v43 = "["
        print(v43, end="")
        v44 = 0
        while method19(v44):
            v46 = 0 <= v44
            if v46:
                v47 = v44 < 2
                v48 = v47
            else:
                v48 = False
            del v46
            v49 = v48 == False
            if v49:
                v50 = "The read index needs to be in range."
                assert v48, v50
                del v50
            else:
                pass
            del v48, v49
            v51 = v5[v44]
            match v51:
                case US5_0(): # Jack
                    v52 = "Jack"
                    print(v52, end="")
                    del v52
                case US5_1(): # King
                    v53 = "King"
                    print(v53, end="")
                    del v53
                case US5_2(): # Queen
                    v54 = "Queen"
                    print(v54, end="")
                    del v54
                case _:
                    raise Exception('Pattern matching miss.')
            del v51
            v55 = v44 + 1
            v56 = v55 < 2
            del v55
            if v56:
                print(v39, end="")
            else:
                pass
            del v56
            v44 += 1 
        del v44
        v57 = "]"
        print(v57, end="")
        print(v39, end="")
        v58 = "player_turn"
        print(v58, end="")
        del v58
        print(v30, end="")
        print(0, end="")
        print(v39, end="")
        v59 = "pot"
        print(v59, end="")
        del v59
        print(v30, end="")
        print(v43, end="")
        del v43
        v60 = 0
        while method19(v60):
            v62 = 0 <= v60
            if v62:
                v63 = v60 < 2
                v64 = v63
            else:
                v64 = False
            del v62
            v65 = v64 == False
            if v65:
                v66 = "The read index needs to be in range."
                assert v64, v66
                del v66
            else:
                pass
            del v64, v65
            v67 = v21[v60]
            print(v67, end="")
            del v67
            v68 = v60 + 1
            v69 = v68 < 2
            del v68
            if v69:
                print(v39, end="")
            else:
                pass
            del v69
            v60 += 1 
        del v60
        print(v57, end="")
        del v57
        print(v39, end="")
        del v39
        v70 = "raises_left"
        print(v70, end="")
        del v70
        print(v30, end="")
        del v30
        print(v9, end="")
        print('}', end="")
        print('}', end="")
        print()
        v71 = US4_1(v8)
        v72 = v0(v71, True, v5, 0, v21, v9)
        del v71
        v73 = Closure17(v0, v1, v2, v3, v4, v8, v5, v21, v9)
        del v0, v1, v2, v3, v4, v5, v9, v21
        return v72(v73)
    return inner
def Closure20(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : list[US5], env_v6 : list[i32], env_v7 : i32):
    def inner(v8 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7
        print('{', end="")
        v9 = "action"
        print(v9, end="")
        del v9
        v10 = " = "
        print(v10, end="")
        match v8:
            case US1_0(): # Call
                v11 = "Call"
                print(v11, end="")
                del v11
            case US1_1(): # Fold
                v12 = "Fold"
                print(v12, end="")
                del v12
            case US1_2(): # Raise
                v13 = "Raise"
                print(v13, end="")
                del v13
            case _:
                raise Exception('Pattern matching miss.')
        print('}', end="")
        print()
        match v8:
            case US1_0(): # Call
                del v10
                v16 = Closure21(v0, v1, v2, v3, v4, v5, v6, v7)
                del v0, v2, v3, v4, v5, v6, v7
                return v1(v16)
            case US1_1(): # Fold
                del v0, v1, v2, v3, v10
                v14 = US4_0()
                return v4(v14, False, v5, 0, v6, v7)
            case US1_2(): # Raise
                v18 = v7 > 0
                if v18:
                    del v18
                    v19 = -1 + v7
                    del v7
                    v20, v21 = (0, 0)
                    while method19(v20):
                        v23 = 0 <= v20
                        if v23:
                            v24 = v20 < 2
                            v25 = v24
                        else:
                            v25 = False
                        del v23
                        v26 = v25 == False
                        if v26:
                            v27 = "The read index needs to be in range."
                            assert v25, v27
                            del v27
                        else:
                            pass
                        del v25, v26
                        v28 = v6[v20]
                        v29 = v21 >= v28
                        if v29:
                            v30 = v21
                        else:
                            v30 = v28
                        del v28, v29
                        v21 = v30
                        del v30
                        v20 += 1 
                    del v6, v20
                    v31 = [None] * 2
                    v32 = 0
                    while method19(v32):
                        v34 = 0 <= v32
                        if v34:
                            v35 = v32 < 2
                            v36 = v35
                        else:
                            v36 = False
                        del v34
                        v37 = v36 == False
                        if v37:
                            v38 = "The read index needs to be in range."
                            assert v36, v38
                            del v38
                        else:
                            pass
                        del v36, v37
                        v31[v32] = v21
                        v32 += 1 
                    del v21, v32
                    v39 = [None] * 2
                    v40 = 0
                    while method19(v40):
                        v42 = 0 <= v40
                        if v42:
                            v43 = v40 < 2
                            v44 = v43
                        else:
                            v44 = False
                        v45 = v44 == False
                        if v45:
                            v46 = "The read index needs to be in range."
                            assert v44, v46
                            del v46
                        else:
                            pass
                        del v44, v45
                        v47 = v31[v40]
                        v48 = v40 == 0
                        if v48:
                            v49 = v47 + 2
                            v50 = v49
                        else:
                            v50 = v47
                        del v47, v48
                        if v42:
                            v51 = v40 < 2
                            v52 = v51
                        else:
                            v52 = False
                        del v42
                        v53 = v52 == False
                        if v53:
                            v54 = "The read index needs to be in range."
                            assert v52, v54
                            del v54
                        else:
                            pass
                        del v52, v53
                        v39[v40] = v50
                        del v50
                        v40 += 1 
                    del v31, v40
                    print('{', end="")
                    v55 = "table"
                    print(v55, end="")
                    del v55
                    print(v10, end="")
                    print('{', end="")
                    v56 = "community_card"
                    print(v56, end="")
                    del v56
                    print(v10, end="")
                    v58 = "None"
                    print(v58, end="")
                    del v58
                    v59 = "; "
                    print(v59, end="")
                    v60 = "is_button_s_first_move"
                    print(v60, end="")
                    del v60
                    print(v10, end="")
                    v61 = "false"
                    print(v61, end="")
                    del v61
                    print(v59, end="")
                    v62 = "pl_card"
                    print(v62, end="")
                    del v62
                    print(v10, end="")
                    v63 = "["
                    print(v63, end="")
                    v64 = 0
                    while method19(v64):
                        v66 = 0 <= v64
                        if v66:
                            v67 = v64 < 2
                            v68 = v67
                        else:
                            v68 = False
                        del v66
                        v69 = v68 == False
                        if v69:
                            v70 = "The read index needs to be in range."
                            assert v68, v70
                            del v70
                        else:
                            pass
                        del v68, v69
                        v71 = v5[v64]
                        match v71:
                            case US5_0(): # Jack
                                v72 = "Jack"
                                print(v72, end="")
                                del v72
                            case US5_1(): # King
                                v73 = "King"
                                print(v73, end="")
                                del v73
                            case US5_2(): # Queen
                                v74 = "Queen"
                                print(v74, end="")
                                del v74
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v71
                        v75 = v64 + 1
                        v76 = v75 < 2
                        del v75
                        if v76:
                            print(v59, end="")
                        else:
                            pass
                        del v76
                        v64 += 1 
                    del v64
                    v77 = "]"
                    print(v77, end="")
                    print(v59, end="")
                    v78 = "player_turn"
                    print(v78, end="")
                    del v78
                    print(v10, end="")
                    print(1, end="")
                    print(v59, end="")
                    v79 = "pot"
                    print(v79, end="")
                    del v79
                    print(v10, end="")
                    print(v63, end="")
                    del v63
                    v80 = 0
                    while method19(v80):
                        v82 = 0 <= v80
                        if v82:
                            v83 = v80 < 2
                            v84 = v83
                        else:
                            v84 = False
                        del v82
                        v85 = v84 == False
                        if v85:
                            v86 = "The read index needs to be in range."
                            assert v84, v86
                            del v86
                        else:
                            pass
                        del v84, v85
                        v87 = v39[v80]
                        print(v87, end="")
                        del v87
                        v88 = v80 + 1
                        v89 = v88 < 2
                        del v88
                        if v89:
                            print(v59, end="")
                        else:
                            pass
                        del v89
                        v80 += 1 
                    del v80
                    print(v77, end="")
                    del v77
                    print(v59, end="")
                    del v59
                    v90 = "raises_left"
                    print(v90, end="")
                    del v90
                    print(v10, end="")
                    del v10
                    print(v19, end="")
                    print('}', end="")
                    print('}', end="")
                    print()
                    v91 = US4_0()
                    v92 = v0(v91, False, v5, 1, v39, v19)
                    del v91
                    v93 = Closure15(v0, v1, v2, v3, v4, v5, v39, v19)
                    del v0, v1, v2, v3, v4, v5, v19, v39
                    return v92(v93)
                else:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v10, v18
                    raise Exception("Invalid action. The number of raises left is not positive.")
            case _:
                raise Exception('Pattern matching miss.')
    return inner
def Closure15(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : list[US5], env_v6 : list[i32], env_v7 : i32):
    def inner(v8 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7
        print('{', end="")
        v9 = "action"
        print(v9, end="")
        del v9
        v10 = " = "
        print(v10, end="")
        match v8:
            case US1_0(): # Call
                v11 = "Call"
                print(v11, end="")
                del v11
            case US1_1(): # Fold
                v12 = "Fold"
                print(v12, end="")
                del v12
            case US1_2(): # Raise
                v13 = "Raise"
                print(v13, end="")
                del v13
            case _:
                raise Exception('Pattern matching miss.')
        print('}', end="")
        print()
        match v8:
            case US1_0(): # Call
                del v10
                v16 = Closure16(v0, v1, v2, v3, v4, v5, v6, v7)
                del v0, v2, v3, v4, v5, v6, v7
                return v1(v16)
            case US1_1(): # Fold
                del v0, v1, v2, v3, v10
                v14 = US4_0()
                return v4(v14, False, v5, 1, v6, v7)
            case US1_2(): # Raise
                v18 = v7 > 0
                if v18:
                    del v18
                    v19 = -1 + v7
                    del v7
                    v20, v21 = (0, 0)
                    while method19(v20):
                        v23 = 0 <= v20
                        if v23:
                            v24 = v20 < 2
                            v25 = v24
                        else:
                            v25 = False
                        del v23
                        v26 = v25 == False
                        if v26:
                            v27 = "The read index needs to be in range."
                            assert v25, v27
                            del v27
                        else:
                            pass
                        del v25, v26
                        v28 = v6[v20]
                        v29 = v21 >= v28
                        if v29:
                            v30 = v21
                        else:
                            v30 = v28
                        del v28, v29
                        v21 = v30
                        del v30
                        v20 += 1 
                    del v6, v20
                    v31 = [None] * 2
                    v32 = 0
                    while method19(v32):
                        v34 = 0 <= v32
                        if v34:
                            v35 = v32 < 2
                            v36 = v35
                        else:
                            v36 = False
                        del v34
                        v37 = v36 == False
                        if v37:
                            v38 = "The read index needs to be in range."
                            assert v36, v38
                            del v38
                        else:
                            pass
                        del v36, v37
                        v31[v32] = v21
                        v32 += 1 
                    del v21, v32
                    v39 = [None] * 2
                    v40 = 0
                    while method19(v40):
                        v42 = 0 <= v40
                        if v42:
                            v43 = v40 < 2
                            v44 = v43
                        else:
                            v44 = False
                        v45 = v44 == False
                        if v45:
                            v46 = "The read index needs to be in range."
                            assert v44, v46
                            del v46
                        else:
                            pass
                        del v44, v45
                        v47 = v31[v40]
                        v48 = v40 == 1
                        if v48:
                            v49 = v47 + 2
                            v50 = v49
                        else:
                            v50 = v47
                        del v47, v48
                        if v42:
                            v51 = v40 < 2
                            v52 = v51
                        else:
                            v52 = False
                        del v42
                        v53 = v52 == False
                        if v53:
                            v54 = "The read index needs to be in range."
                            assert v52, v54
                            del v54
                        else:
                            pass
                        del v52, v53
                        v39[v40] = v50
                        del v50
                        v40 += 1 
                    del v31, v40
                    print('{', end="")
                    v55 = "table"
                    print(v55, end="")
                    del v55
                    print(v10, end="")
                    print('{', end="")
                    v56 = "community_card"
                    print(v56, end="")
                    del v56
                    print(v10, end="")
                    v58 = "None"
                    print(v58, end="")
                    del v58
                    v59 = "; "
                    print(v59, end="")
                    v60 = "is_button_s_first_move"
                    print(v60, end="")
                    del v60
                    print(v10, end="")
                    v61 = "false"
                    print(v61, end="")
                    del v61
                    print(v59, end="")
                    v62 = "pl_card"
                    print(v62, end="")
                    del v62
                    print(v10, end="")
                    v63 = "["
                    print(v63, end="")
                    v64 = 0
                    while method19(v64):
                        v66 = 0 <= v64
                        if v66:
                            v67 = v64 < 2
                            v68 = v67
                        else:
                            v68 = False
                        del v66
                        v69 = v68 == False
                        if v69:
                            v70 = "The read index needs to be in range."
                            assert v68, v70
                            del v70
                        else:
                            pass
                        del v68, v69
                        v71 = v5[v64]
                        match v71:
                            case US5_0(): # Jack
                                v72 = "Jack"
                                print(v72, end="")
                                del v72
                            case US5_1(): # King
                                v73 = "King"
                                print(v73, end="")
                                del v73
                            case US5_2(): # Queen
                                v74 = "Queen"
                                print(v74, end="")
                                del v74
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v71
                        v75 = v64 + 1
                        v76 = v75 < 2
                        del v75
                        if v76:
                            print(v59, end="")
                        else:
                            pass
                        del v76
                        v64 += 1 
                    del v64
                    v77 = "]"
                    print(v77, end="")
                    print(v59, end="")
                    v78 = "player_turn"
                    print(v78, end="")
                    del v78
                    print(v10, end="")
                    print(0, end="")
                    print(v59, end="")
                    v79 = "pot"
                    print(v79, end="")
                    del v79
                    print(v10, end="")
                    print(v63, end="")
                    del v63
                    v80 = 0
                    while method19(v80):
                        v82 = 0 <= v80
                        if v82:
                            v83 = v80 < 2
                            v84 = v83
                        else:
                            v84 = False
                        del v82
                        v85 = v84 == False
                        if v85:
                            v86 = "The read index needs to be in range."
                            assert v84, v86
                            del v86
                        else:
                            pass
                        del v84, v85
                        v87 = v39[v80]
                        print(v87, end="")
                        del v87
                        v88 = v80 + 1
                        v89 = v88 < 2
                        del v88
                        if v89:
                            print(v59, end="")
                        else:
                            pass
                        del v89
                        v80 += 1 
                    del v80
                    print(v77, end="")
                    del v77
                    print(v59, end="")
                    del v59
                    v90 = "raises_left"
                    print(v90, end="")
                    del v90
                    print(v10, end="")
                    del v10
                    print(v19, end="")
                    print('}', end="")
                    print('}', end="")
                    print()
                    v91 = US4_0()
                    v92 = v0(v91, False, v5, 0, v39, v19)
                    del v91
                    v93 = Closure20(v0, v1, v2, v3, v4, v5, v39, v19)
                    del v0, v1, v2, v3, v4, v5, v19, v39
                    return v92(v93)
                else:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v10, v18
                    raise Exception("Invalid action. The number of raises left is not positive.")
            case _:
                raise Exception('Pattern matching miss.')
    return inner
def Closure14(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : list[US5], env_v6 : list[i32], env_v7 : i32):
    def inner(v8 : US1) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5, env_v6, env_v7
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5; v6 = env_v6; v7 = env_v7
        print('{', end="")
        v9 = "action"
        print(v9, end="")
        del v9
        v10 = " = "
        print(v10, end="")
        match v8:
            case US1_0(): # Call
                v11 = "Call"
                print(v11, end="")
                del v11
            case US1_1(): # Fold
                v12 = "Fold"
                print(v12, end="")
                del v12
            case US1_2(): # Raise
                v13 = "Raise"
                print(v13, end="")
                del v13
            case _:
                raise Exception('Pattern matching miss.')
        print('}', end="")
        print()
        match v8:
            case US1_0(): # Call
                print('{', end="")
                v16 = "table"
                print(v16, end="")
                del v16
                print(v10, end="")
                print('{', end="")
                v17 = "community_card"
                print(v17, end="")
                del v17
                print(v10, end="")
                v19 = "None"
                print(v19, end="")
                del v19
                v20 = "; "
                print(v20, end="")
                v21 = "is_button_s_first_move"
                print(v21, end="")
                del v21
                print(v10, end="")
                v22 = "false"
                print(v22, end="")
                del v22
                print(v20, end="")
                v23 = "pl_card"
                print(v23, end="")
                del v23
                print(v10, end="")
                v24 = "["
                print(v24, end="")
                v25 = 0
                while method19(v25):
                    v27 = 0 <= v25
                    if v27:
                        v28 = v25 < 2
                        v29 = v28
                    else:
                        v29 = False
                    del v27
                    v30 = v29 == False
                    if v30:
                        v31 = "The read index needs to be in range."
                        assert v29, v31
                        del v31
                    else:
                        pass
                    del v29, v30
                    v32 = v5[v25]
                    match v32:
                        case US5_0(): # Jack
                            v33 = "Jack"
                            print(v33, end="")
                            del v33
                        case US5_1(): # King
                            v34 = "King"
                            print(v34, end="")
                            del v34
                        case US5_2(): # Queen
                            v35 = "Queen"
                            print(v35, end="")
                            del v35
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v32
                    v36 = v25 + 1
                    v37 = v36 < 2
                    del v36
                    if v37:
                        print(v20, end="")
                    else:
                        pass
                    del v37
                    v25 += 1 
                del v25
                v38 = "]"
                print(v38, end="")
                print(v20, end="")
                v39 = "player_turn"
                print(v39, end="")
                del v39
                print(v10, end="")
                print(1, end="")
                print(v20, end="")
                v40 = "pot"
                print(v40, end="")
                del v40
                print(v10, end="")
                print(v24, end="")
                del v24
                v41 = 0
                while method19(v41):
                    v43 = 0 <= v41
                    if v43:
                        v44 = v41 < 2
                        v45 = v44
                    else:
                        v45 = False
                    del v43
                    v46 = v45 == False
                    if v46:
                        v47 = "The read index needs to be in range."
                        assert v45, v47
                        del v47
                    else:
                        pass
                    del v45, v46
                    v48 = v6[v41]
                    print(v48, end="")
                    del v48
                    v49 = v41 + 1
                    v50 = v49 < 2
                    del v49
                    if v50:
                        print(v20, end="")
                    else:
                        pass
                    del v50
                    v41 += 1 
                del v41
                print(v38, end="")
                del v38
                print(v20, end="")
                del v20
                v51 = "raises_left"
                print(v51, end="")
                del v51
                print(v10, end="")
                del v10
                print(v7, end="")
                print('}', end="")
                print('}', end="")
                print()
                v52 = US4_0()
                v53 = v0(v52, False, v5, 1, v6, v7)
                del v52
                v54 = Closure15(v0, v1, v2, v3, v4, v5, v6, v7)
                del v0, v1, v2, v3, v4, v5, v6, v7
                return v53(v54)
            case US1_1(): # Fold
                del v0, v1, v2, v3, v10
                v14 = US4_0()
                return v4(v14, True, v5, 0, v6, v7)
            case US1_2(): # Raise
                v56 = v7 > 0
                if v56:
                    del v56
                    v57 = -1 + v7
                    del v7
                    v58, v59 = (0, 0)
                    while method19(v58):
                        v61 = 0 <= v58
                        if v61:
                            v62 = v58 < 2
                            v63 = v62
                        else:
                            v63 = False
                        del v61
                        v64 = v63 == False
                        if v64:
                            v65 = "The read index needs to be in range."
                            assert v63, v65
                            del v65
                        else:
                            pass
                        del v63, v64
                        v66 = v6[v58]
                        v67 = v59 >= v66
                        if v67:
                            v68 = v59
                        else:
                            v68 = v66
                        del v66, v67
                        v59 = v68
                        del v68
                        v58 += 1 
                    del v6, v58
                    v69 = [None] * 2
                    v70 = 0
                    while method19(v70):
                        v72 = 0 <= v70
                        if v72:
                            v73 = v70 < 2
                            v74 = v73
                        else:
                            v74 = False
                        del v72
                        v75 = v74 == False
                        if v75:
                            v76 = "The read index needs to be in range."
                            assert v74, v76
                            del v76
                        else:
                            pass
                        del v74, v75
                        v69[v70] = v59
                        v70 += 1 
                    del v59, v70
                    v77 = [None] * 2
                    v78 = 0
                    while method19(v78):
                        v80 = 0 <= v78
                        if v80:
                            v81 = v78 < 2
                            v82 = v81
                        else:
                            v82 = False
                        v83 = v82 == False
                        if v83:
                            v84 = "The read index needs to be in range."
                            assert v82, v84
                            del v84
                        else:
                            pass
                        del v82, v83
                        v85 = v69[v78]
                        v86 = v78 == 0
                        if v86:
                            v87 = v85 + 2
                            v88 = v87
                        else:
                            v88 = v85
                        del v85, v86
                        if v80:
                            v89 = v78 < 2
                            v90 = v89
                        else:
                            v90 = False
                        del v80
                        v91 = v90 == False
                        if v91:
                            v92 = "The read index needs to be in range."
                            assert v90, v92
                            del v92
                        else:
                            pass
                        del v90, v91
                        v77[v78] = v88
                        del v88
                        v78 += 1 
                    del v69, v78
                    print('{', end="")
                    v93 = "table"
                    print(v93, end="")
                    del v93
                    print(v10, end="")
                    print('{', end="")
                    v94 = "community_card"
                    print(v94, end="")
                    del v94
                    print(v10, end="")
                    v96 = "None"
                    print(v96, end="")
                    del v96
                    v97 = "; "
                    print(v97, end="")
                    v98 = "is_button_s_first_move"
                    print(v98, end="")
                    del v98
                    print(v10, end="")
                    v99 = "false"
                    print(v99, end="")
                    del v99
                    print(v97, end="")
                    v100 = "pl_card"
                    print(v100, end="")
                    del v100
                    print(v10, end="")
                    v101 = "["
                    print(v101, end="")
                    v102 = 0
                    while method19(v102):
                        v104 = 0 <= v102
                        if v104:
                            v105 = v102 < 2
                            v106 = v105
                        else:
                            v106 = False
                        del v104
                        v107 = v106 == False
                        if v107:
                            v108 = "The read index needs to be in range."
                            assert v106, v108
                            del v108
                        else:
                            pass
                        del v106, v107
                        v109 = v5[v102]
                        match v109:
                            case US5_0(): # Jack
                                v110 = "Jack"
                                print(v110, end="")
                                del v110
                            case US5_1(): # King
                                v111 = "King"
                                print(v111, end="")
                                del v111
                            case US5_2(): # Queen
                                v112 = "Queen"
                                print(v112, end="")
                                del v112
                            case _:
                                raise Exception('Pattern matching miss.')
                        del v109
                        v113 = v102 + 1
                        v114 = v113 < 2
                        del v113
                        if v114:
                            print(v97, end="")
                        else:
                            pass
                        del v114
                        v102 += 1 
                    del v102
                    v115 = "]"
                    print(v115, end="")
                    print(v97, end="")
                    v116 = "player_turn"
                    print(v116, end="")
                    del v116
                    print(v10, end="")
                    print(1, end="")
                    print(v97, end="")
                    v117 = "pot"
                    print(v117, end="")
                    del v117
                    print(v10, end="")
                    print(v101, end="")
                    del v101
                    v118 = 0
                    while method19(v118):
                        v120 = 0 <= v118
                        if v120:
                            v121 = v118 < 2
                            v122 = v121
                        else:
                            v122 = False
                        del v120
                        v123 = v122 == False
                        if v123:
                            v124 = "The read index needs to be in range."
                            assert v122, v124
                            del v124
                        else:
                            pass
                        del v122, v123
                        v125 = v77[v118]
                        print(v125, end="")
                        del v125
                        v126 = v118 + 1
                        v127 = v126 < 2
                        del v126
                        if v127:
                            print(v97, end="")
                        else:
                            pass
                        del v127
                        v118 += 1 
                    del v118
                    print(v115, end="")
                    del v115
                    print(v97, end="")
                    del v97
                    v128 = "raises_left"
                    print(v128, end="")
                    del v128
                    print(v10, end="")
                    del v10
                    print(v57, end="")
                    print('}', end="")
                    print('}', end="")
                    print()
                    v129 = US4_0()
                    v130 = v0(v129, False, v5, 1, v77, v57)
                    del v129
                    v131 = Closure15(v0, v1, v2, v3, v4, v5, v77, v57)
                    del v0, v1, v2, v3, v4, v5, v57, v77
                    return v130(v131)
                else:
                    del v0, v1, v2, v3, v4, v5, v6, v7, v10, v56
                    raise Exception("Invalid action. The number of raises left is not positive.")
            case _:
                raise Exception('Pattern matching miss.')
    return inner
def Closure13(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v5 : US5):
    def inner(v6 : US5) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4, env_v5
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4; v5 = env_v5
        v7 = 2
        v8 = [None] * 2
        v8[0] = 1
        v8[1] = 1
        v9 = [None] * 2
        v9[0] = v5
        del v5
        v9[1] = v6
        print('{', end="")
        v10 = "table"
        print(v10, end="")
        del v10
        v11 = " = "
        print(v11, end="")
        print('{', end="")
        v12 = "community_card"
        print(v12, end="")
        del v12
        print(v11, end="")
        v14 = "None"
        print(v14, end="")
        del v14
        v15 = "; "
        print(v15, end="")
        v16 = "is_button_s_first_move"
        print(v16, end="")
        del v16
        print(v11, end="")
        v17 = "true"
        print(v17, end="")
        del v17
        print(v15, end="")
        v18 = "pl_card"
        print(v18, end="")
        del v18
        print(v11, end="")
        v19 = "["
        print(v19, end="")
        v20 = 0
        while method19(v20):
            v22 = 0 <= v20
            if v22:
                v23 = v20 < 2
                v24 = v23
            else:
                v24 = False
            del v22
            v25 = v24 == False
            if v25:
                v26 = "The read index needs to be in range."
                assert v24, v26
                del v26
            else:
                pass
            del v24, v25
            v27 = v9[v20]
            match v27:
                case US5_0(): # Jack
                    v28 = "Jack"
                    print(v28, end="")
                    del v28
                case US5_1(): # King
                    v29 = "King"
                    print(v29, end="")
                    del v29
                case US5_2(): # Queen
                    v30 = "Queen"
                    print(v30, end="")
                    del v30
                case _:
                    raise Exception('Pattern matching miss.')
            del v27
            v31 = v20 + 1
            v32 = v31 < 2
            del v31
            if v32:
                print(v15, end="")
            else:
                pass
            del v32
            v20 += 1 
        del v20
        v33 = "]"
        print(v33, end="")
        print(v15, end="")
        v34 = "player_turn"
        print(v34, end="")
        del v34
        print(v11, end="")
        print(0, end="")
        print(v15, end="")
        v35 = "pot"
        print(v35, end="")
        del v35
        print(v11, end="")
        print(v19, end="")
        del v19
        v36 = 0
        while method19(v36):
            v38 = 0 <= v36
            if v38:
                v39 = v36 < 2
                v40 = v39
            else:
                v40 = False
            del v38
            v41 = v40 == False
            if v41:
                v42 = "The read index needs to be in range."
                assert v40, v42
                del v42
            else:
                pass
            del v40, v41
            v43 = v8[v36]
            print(v43, end="")
            del v43
            v44 = v36 + 1
            v45 = v44 < 2
            del v44
            if v45:
                print(v15, end="")
            else:
                pass
            del v45
            v36 += 1 
        del v36
        print(v33, end="")
        del v33
        print(v15, end="")
        del v15
        v46 = "raises_left"
        print(v46, end="")
        del v46
        print(v11, end="")
        del v11
        print(v7, end="")
        print('}', end="")
        print('}', end="")
        print()
        v47 = US4_0()
        v48 = v0(v47, True, v9, 0, v8, v7)
        del v47
        v49 = Closure14(v0, v1, v2, v3, v4, v9, v8, v7)
        del v0, v1, v2, v3, v4, v7, v8, v9
        return v48(v49)
    return inner
def Closure12(env_v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], env_v1 : Callable[[Callable[[US5], UH0]], UH0], env_v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], env_v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], env_v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0]):
    def inner(v5 : US5) -> UH0:
        nonlocal env_v0, env_v1, env_v2, env_v3, env_v4
        v0 = env_v0; v1 = env_v1; v2 = env_v2; v3 = env_v3; v4 = env_v4
        v6 = v2(1)
        v7 = Closure13(v0, v1, v2, v3, v4, v5)
        del v0, v1, v2, v3, v4
        return v6(v7)
    return inner
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = method0(v0)
        v3, v4, v5, v6, v7 = method5(v1)
        match v2:
            case US0_0(v64): # ActionSelected
                match v3:
                    case US3_0(): # None
                        del v64
                        v94, v95, v96, v97, v98 = v3, v4, v5, v6, v7
                    case US3_1(v65, v66, v67): # Some
                        v68 = v65(v64)
                        del v64, v65
                        v94, v95, v96, v97, v98 = method11(v3, v4, v5, v6, v7, v66, v67, v68)
                    case _:
                        raise Exception('Pattern matching miss.')
            case US0_1(v63): # PlayerChanged
                v94, v95, v96, v97, v98 = v3, v4, v5, v63, v7
            case US0_2(): # StartGame
                v8 = "Starting the game."
                print(v8, end="")
                del v8
                print()
                v9 = [None] * 2
                v10 = US2_0()
                v9[0] = v10
                del v10
                v11 = US2_1()
                v9[1] = v11
                del v11
                v12 = [None] * 32
                v13 = [0]
                v14 = US3_0()
                v15 = US7_0()
                v16 = [None] * 6
                v17 = [0]
                v18 = v17[0]
                del v18
                v17[0] = 6
                v19 = v17[0]
                v20 = 0 < v19
                del v19
                v21 = v20 == False
                if v21:
                    v22 = "The set index needs to be in range."
                    assert v20, v22
                    del v22
                else:
                    pass
                del v20, v21
                v23 = US5_1()
                v16[0] = v23
                del v23
                v24 = v17[0]
                v25 = 1 < v24
                del v24
                v26 = v25 == False
                if v26:
                    v27 = "The set index needs to be in range."
                    assert v25, v27
                    del v27
                else:
                    pass
                del v25, v26
                v28 = US5_1()
                v16[1] = v28
                del v28
                v29 = v17[0]
                v30 = 2 < v29
                del v29
                v31 = v30 == False
                if v31:
                    v32 = "The set index needs to be in range."
                    assert v30, v32
                    del v32
                else:
                    pass
                del v30, v31
                v33 = US5_2()
                v16[2] = v33
                del v33
                v34 = v17[0]
                v35 = 3 < v34
                del v34
                v36 = v35 == False
                if v36:
                    v37 = "The set index needs to be in range."
                    assert v35, v37
                    del v37
                else:
                    pass
                del v35, v36
                v38 = US5_2()
                v16[3] = v38
                del v38
                v39 = v17[0]
                v40 = 4 < v39
                del v39
                v41 = v40 == False
                if v41:
                    v42 = "The set index needs to be in range."
                    assert v40, v42
                    del v42
                else:
                    pass
                del v40, v41
                v43 = US5_0()
                v16[4] = v43
                del v43
                v44 = v17[0]
                v45 = 5 < v44
                del v44
                v46 = v45 == False
                if v46:
                    v47 = "The set index needs to be in range."
                    assert v45, v47
                    del v47
                else:
                    pass
                del v45, v46
                v48 = US5_0()
                v16[5] = v48
                del v48
                v49 = v17[0]
                v50 = v16[:v49]
                del v49
                random.shuffle(v50)
                v51 = v17[0]
                v16[:v51] = v50
                del v50, v51
                v52 = Closure2()
                v53 = Closure5()
                v54 = Closure7()
                v55 = Closure10()
                v56 = Closure11()
                v57 = method18(v52, v53, v54, v55, v56)
                del v52, v53, v54, v55, v56
                v94, v95, v96, v97, v98 = method11(v14, v12, v13, v9, v15, v16, v17, v57)
            case _:
                raise Exception('Pattern matching miss.')
        del v2, v3, v4, v5, v6, v7
        return method20(v94, v95, v96, v97, v98)
    return inner
def Closure22():
    def inner() -> object:
        v0 = [None] * 2
        v1 = US2_0()
        v0[0] = v1
        del v1
        v2 = US2_1()
        v0[1] = v2
        del v2
        v3 = [None] * 32
        v4 = [0]
        v5 = US3_0()
        v6 = US7_0()
        return method20(v5, v3, v4, v0, v6)
    return inner
def method2(v0 : object) -> US1:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Call" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US1_0()
    else:
        del v4
        v7 = "Fold" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US1_1()
        else:
            del v7
            v10 = "Raise" == v1
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
def method3(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method4(v0 : object) -> US2:
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
            assert isinstance(v2,list), f'The object needs to be a Python list. Got: {v2}'
            v9 = len(v2)
            v10 = 2 == v9
            v11 = v10 == False
            if v11:
                v12 = "The type level dimension has to equal the value passed at runtime into create."
                assert v10, v12
                del v12
            else:
                pass
            del v10, v11
            v13 = [None] * 2
            v14 = 0
            while method3(v9, v14):
                v16 = v2[v14]
                v17 = method4(v16)
                del v16
                v18 = 0 <= v14
                if v18:
                    v19 = v14 < 2
                    v20 = v19
                else:
                    v20 = False
                del v18
                v21 = v20 == False
                if v21:
                    v22 = "The read index needs to be in range."
                    assert v20, v22
                    del v22
                else:
                    pass
                del v20, v21
                v13[v14] = v17
                del v17
                v14 += 1 
            del v2, v9, v14
            return US0_1(v13)
        else:
            del v8
            v25 = "StartGame" == v1
            if v25:
                del v1, v25
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US0_2()
            else:
                del v2, v25
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method0(v0 : object) -> US0:
    return method1(v0)
def method7(v0 : object) -> US5:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Jack" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US5_0()
    else:
        del v4
        v7 = "King" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US5_1()
        else:
            del v7
            v10 = "Queen" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US5_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method6(v0 : object) -> US3:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US3_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = "cont"
            v9 = v2[v8]
            del v8
            v10 = v9
            del v9
            v11 = "deck"
            v12 = v2[v11]
            del v2, v11
            v13 = len(v12)
            assert (6 >= v13), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 6\nGot: {v13} '
            del v13
            assert isinstance(v12,list), f'The object needs to be a Python list. Got: {v12}'
            v14 = len(v12)
            v15 = 6 >= v14
            v16 = v15 == False
            if v16:
                v17 = "The type level dimension has to equal the value passed at runtime into create."
                assert v15, v17
                del v17
            else:
                pass
            del v15, v16
            v18 = [None] * 6
            v19 = [0]
            v20 = v19[0]
            del v20
            v19[0] = v14
            v21 = 0
            while method3(v14, v21):
                v23 = v12[v21]
                v24 = method7(v23)
                del v23
                v25 = 0 <= v21
                if v25:
                    v26 = v19[0]
                    v27 = v21 < v26
                    del v26
                    v28 = v27
                else:
                    v28 = False
                v29 = v28 == False
                if v29:
                    v30 = "The set index needs to be in range."
                    assert v28, v30
                    del v30
                else:
                    pass
                del v28, v29
                if v25:
                    v31 = v21 < 6
                    v32 = v31
                else:
                    v32 = False
                del v25
                v33 = v32 == False
                if v33:
                    v34 = "The read index needs to be in range."
                    assert v32, v34
                    del v34
                else:
                    pass
                del v32, v33
                v18[v21] = v24
                del v24
                v21 += 1 
            del v12, v14, v21
            return US3_1(v10, v18, v19)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method8(v0 : object) -> US6:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method7(v2)
        del v2
        return US6_0(v5)
    else:
        del v4
        v8 = "PlayerAction" == v1
        if v8:
            del v1, v8
            v9 = v2[0]
            assert isinstance(v9,i32), f'The object needs to be the right primitive type. Got: {v9}'
            v10 = v9
            del v9
            v11 = v2[1]
            del v2
            v12 = method2(v11)
            del v11
            return US6_1(v10, v12)
        else:
            del v8
            v15 = "PlayerGotCard" == v1
            if v15:
                del v1, v15
                v16 = v2[0]
                assert isinstance(v16,i32), f'The object needs to be the right primitive type. Got: {v16}'
                v17 = v16
                del v16
                v18 = v2[1]
                del v2
                v19 = method7(v18)
                del v18
                return US6_2(v17, v19)
            else:
                del v15
                v22 = "Showdown" == v1
                if v22:
                    del v1, v22
                    v23 = "cards_shown"
                    v24 = v2[v23]
                    del v23
                    assert isinstance(v24,list), f'The object needs to be a Python list. Got: {v24}'
                    v25 = len(v24)
                    v26 = 2 == v25
                    v27 = v26 == False
                    if v27:
                        v28 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v26, v28
                        del v28
                    else:
                        pass
                    del v26, v27
                    v29 = [None] * 2
                    v30 = 0
                    while method3(v25, v30):
                        v32 = v24[v30]
                        v33 = method7(v32)
                        del v32
                        v34 = 0 <= v30
                        if v34:
                            v35 = v30 < 2
                            v36 = v35
                        else:
                            v36 = False
                        del v34
                        v37 = v36 == False
                        if v37:
                            v38 = "The read index needs to be in range."
                            assert v36, v38
                            del v38
                        else:
                            pass
                        del v36, v37
                        v29[v30] = v33
                        del v33
                        v30 += 1 
                    del v24, v25, v30
                    v39 = "chips_won"
                    v40 = v2[v39]
                    del v39
                    assert isinstance(v40,i32), f'The object needs to be the right primitive type. Got: {v40}'
                    v41 = v40
                    del v40
                    v42 = "winner_id"
                    v43 = v2[v42]
                    del v2, v42
                    assert isinstance(v43,i32), f'The object needs to be the right primitive type. Got: {v43}'
                    v44 = v43
                    del v43
                    return US6_3(v29, v41, v44)
                else:
                    del v2, v22
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method10(v0 : object) -> US4:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US4_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method7(v2)
            del v2
            return US4_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method9(v0 : object) -> US7:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US7_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = "community_card"
            v9 = v2[v8]
            del v8
            v10 = method10(v9)
            del v9
            v11 = "is_button_s_first_move"
            v12 = v2[v11]
            del v11
            assert isinstance(v12,bool), f'The object needs to be the right primitive type. Got: {v12}'
            v13 = v12
            del v12
            v14 = "pl_card"
            v15 = v2[v14]
            del v14
            assert isinstance(v15,list), f'The object needs to be a Python list. Got: {v15}'
            v16 = len(v15)
            v17 = 2 == v16
            v18 = v17 == False
            if v18:
                v19 = "The type level dimension has to equal the value passed at runtime into create."
                assert v17, v19
                del v19
            else:
                pass
            del v17, v18
            v20 = [None] * 2
            v21 = 0
            while method3(v16, v21):
                v23 = v15[v21]
                v24 = method7(v23)
                del v23
                v25 = 0 <= v21
                if v25:
                    v26 = v21 < 2
                    v27 = v26
                else:
                    v27 = False
                del v25
                v28 = v27 == False
                if v28:
                    v29 = "The read index needs to be in range."
                    assert v27, v29
                    del v29
                else:
                    pass
                del v27, v28
                v20[v21] = v24
                del v24
                v21 += 1 
            del v15, v16, v21
            v30 = "player_turn"
            v31 = v2[v30]
            del v30
            assert isinstance(v31,i32), f'The object needs to be the right primitive type. Got: {v31}'
            v32 = v31
            del v31
            v33 = "pot"
            v34 = v2[v33]
            del v33
            assert isinstance(v34,list), f'The object needs to be a Python list. Got: {v34}'
            v35 = len(v34)
            v36 = 2 == v35
            v37 = v36 == False
            if v37:
                v38 = "The type level dimension has to equal the value passed at runtime into create."
                assert v36, v38
                del v38
            else:
                pass
            del v36, v37
            v39 = [None] * 2
            v40 = 0
            while method3(v35, v40):
                v42 = v34[v40]
                assert isinstance(v42,i32), f'The object needs to be the right primitive type. Got: {v42}'
                v43 = v42
                del v42
                v44 = 0 <= v40
                if v44:
                    v45 = v40 < 2
                    v46 = v45
                else:
                    v46 = False
                del v44
                v47 = v46 == False
                if v47:
                    v48 = "The read index needs to be in range."
                    assert v46, v48
                    del v48
                else:
                    pass
                del v46, v47
                v39[v40] = v43
                del v43
                v40 += 1 
            del v34, v35, v40
            v49 = "raises_left"
            v50 = v2[v49]
            del v2, v49
            assert isinstance(v50,i32), f'The object needs to be the right primitive type. Got: {v50}'
            v51 = v50
            del v50
            return US7_1(v10, v13, v20, v32, v39, v51)
        else:
            del v7
            v54 = "WaitingForActionFromPlayerId" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method10(v56)
                del v56
                v58 = "is_button_s_first_move"
                v59 = v2[v58]
                del v58
                assert isinstance(v59,bool), f'The object needs to be the right primitive type. Got: {v59}'
                v60 = v59
                del v59
                v61 = "pl_card"
                v62 = v2[v61]
                del v61
                assert isinstance(v62,list), f'The object needs to be a Python list. Got: {v62}'
                v63 = len(v62)
                v64 = 2 == v63
                v65 = v64 == False
                if v65:
                    v66 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v64, v66
                    del v66
                else:
                    pass
                del v64, v65
                v67 = [None] * 2
                v68 = 0
                while method3(v63, v68):
                    v70 = v62[v68]
                    v71 = method7(v70)
                    del v70
                    v72 = 0 <= v68
                    if v72:
                        v73 = v68 < 2
                        v74 = v73
                    else:
                        v74 = False
                    del v72
                    v75 = v74 == False
                    if v75:
                        v76 = "The read index needs to be in range."
                        assert v74, v76
                        del v76
                    else:
                        pass
                    del v74, v75
                    v67[v68] = v71
                    del v71
                    v68 += 1 
                del v62, v63, v68
                v77 = "player_turn"
                v78 = v2[v77]
                del v77
                assert isinstance(v78,i32), f'The object needs to be the right primitive type. Got: {v78}'
                v79 = v78
                del v78
                v80 = "pot"
                v81 = v2[v80]
                del v80
                assert isinstance(v81,list), f'The object needs to be a Python list. Got: {v81}'
                v82 = len(v81)
                v83 = 2 == v82
                v84 = v83 == False
                if v84:
                    v85 = "The type level dimension has to equal the value passed at runtime into create."
                    assert v83, v85
                    del v85
                else:
                    pass
                del v83, v84
                v86 = [None] * 2
                v87 = 0
                while method3(v82, v87):
                    v89 = v81[v87]
                    assert isinstance(v89,i32), f'The object needs to be the right primitive type. Got: {v89}'
                    v90 = v89
                    del v89
                    v91 = 0 <= v87
                    if v91:
                        v92 = v87 < 2
                        v93 = v92
                    else:
                        v93 = False
                    del v91
                    v94 = v93 == False
                    if v94:
                        v95 = "The read index needs to be in range."
                        assert v93, v95
                        del v95
                    else:
                        pass
                    del v93, v94
                    v86[v87] = v90
                    del v90
                    v87 += 1 
                del v81, v82, v87
                v96 = "raises_left"
                v97 = v2[v96]
                del v2, v96
                assert isinstance(v97,i32), f'The object needs to be the right primitive type. Got: {v97}'
                v98 = v97
                del v97
                return US7_2(v57, v60, v67, v79, v86, v98)
            else:
                del v2, v54
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method5(v0 : object) -> Tuple[US3, list[US6], list, list[US2], US7]:
    v1 = "game_state"
    v2 = v0[v1]
    del v1
    v3 = "next"
    v4 = v2[v3]
    del v2, v3
    v5 = method6(v4)
    del v4
    v6 = "ui_state"
    v7 = v0[v6]
    del v0, v6
    v8 = "messages"
    v9 = v7[v8]
    del v8
    v10 = len(v9)
    assert (32 >= v10), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 32\nGot: {v10} '
    del v10
    assert isinstance(v9,list), f'The object needs to be a Python list. Got: {v9}'
    v11 = len(v9)
    v12 = 32 >= v11
    v13 = v12 == False
    if v13:
        v14 = "The type level dimension has to equal the value passed at runtime into create."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = [None] * 32
    v16 = [0]
    v17 = v16[0]
    del v17
    v16[0] = v11
    v18 = 0
    while method3(v11, v18):
        v20 = v9[v18]
        v21 = method8(v20)
        del v20
        v22 = 0 <= v18
        if v22:
            v23 = v16[0]
            v24 = v18 < v23
            del v23
            v25 = v24
        else:
            v25 = False
        v26 = v25 == False
        if v26:
            v27 = "The set index needs to be in range."
            assert v25, v27
            del v27
        else:
            pass
        del v25, v26
        if v22:
            v28 = v18 < 32
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
        v15[v18] = v21
        del v21
        v18 += 1 
    del v9, v11, v18
    v32 = "pl_type"
    v33 = v7[v32]
    del v32
    assert isinstance(v33,list), f'The object needs to be a Python list. Got: {v33}'
    v34 = len(v33)
    v35 = 2 == v34
    v36 = v35 == False
    if v36:
        v37 = "The type level dimension has to equal the value passed at runtime into create."
        assert v35, v37
        del v37
    else:
        pass
    del v35, v36
    v38 = [None] * 2
    v39 = 0
    while method3(v34, v39):
        v41 = v33[v39]
        v42 = method4(v41)
        del v41
        v43 = 0 <= v39
        if v43:
            v44 = v39 < 2
            v45 = v44
        else:
            v45 = False
        del v43
        v46 = v45 == False
        if v46:
            v47 = "The read index needs to be in range."
            assert v45, v47
            del v47
        else:
            pass
        del v45, v46
        v38[v39] = v42
        del v42
        v39 += 1 
    del v33, v34, v39
    v48 = "ui_game_state"
    v49 = v7[v48]
    del v7, v48
    v50 = method9(v49)
    del v49
    return v5, v15, v16, v38, v50
def method13(v0 : list[US5], v1 : list, v2 : US3, v3 : list[US6], v4 : list, v5 : list[US2], v6 : US7, v7 : Callable[[US5], Tuple[UH0, US6]]) -> Tuple[US3, list[US6], list, list[US2], US7]:
    v8 = v1[0]
    v9 = v8 - 1
    del v8
    v10 = 0 <= v9
    if v10:
        v11 = v1[0]
        v12 = v9 < v11
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
        v16 = v9 < 6
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
    v20 = v0[v9]
    v21 = v1[0]
    del v21
    v1[0] = v9
    del v9
    v22, v23 = v7(v20)
    del v7, v20
    v24 = v4[0]
    v25 = 1 + v24
    v4[0] = v25
    del v25
    v26 = 0 <= v24
    if v26:
        v27 = v4[0]
        v28 = v24 < v27
        del v27
        v29 = v28
    else:
        v29 = False
    v30 = v29 == False
    if v30:
        v31 = "The set index needs to be in range."
        assert v29, v31
        del v31
    else:
        pass
    del v29, v30
    if v26:
        v32 = v24 < 32
        v33 = v32
    else:
        v33 = False
    del v26
    v34 = v33 == False
    if v34:
        v35 = "The read index needs to be in range."
        assert v33, v35
        del v35
    else:
        pass
    del v33, v34
    v3[v24] = v23
    del v23, v24
    match v22:
        case UH0_0(v42, v43, v44, v45, v46, v47, v48): # Action
            del v22
            v49 = 0 <= v45
            if v49:
                v50 = v45 < 2
                v51 = v50
            else:
                v51 = False
            del v49
            v52 = v51 == False
            if v52:
                v53 = "The read index needs to be in range."
                assert v51, v53
                del v53
            else:
                pass
            del v51, v52
            v54 = v5[v45]
            match v54:
                case US2_0(): # Computer
                    del v54
                    return method12(v0, v1, v2, v3, v4, v5, v6, v48, v42, v43, v44, v45, v46, v47)
                case US2_1(): # Human
                    del v2, v6, v54
                    v55 = Closure1(v3, v4, v48)
                    del v48
                    v56 = US3_1(v55, v0, v1)
                    del v0, v1, v55
                    v57 = US7_2(v42, v43, v44, v45, v46, v47)
                    del v42, v43, v44, v45, v46, v47
                    return v56, v3, v4, v5, v57
                case _:
                    raise Exception('Pattern matching miss.')
        case UH0_1(v36): # Chance
            del v22
            return method13(v0, v1, v2, v3, v4, v5, v6, v36)
        case UH0_2(v73, v74, v75, v76, v77, v78, _, v80): # Terminal
            del v0, v1, v2, v6, v22
            v81 = v4[0]
            v82 = 1 + v81
            v4[0] = v82
            del v82
            v83 = 0 <= v81
            if v83:
                v84 = v4[0]
                v85 = v81 < v84
                del v84
                v86 = v85
            else:
                v86 = False
            v87 = v86 == False
            if v87:
                v88 = "The set index needs to be in range."
                assert v86, v88
                del v88
            else:
                pass
            del v86, v87
            if v83:
                v89 = v81 < 32
                v90 = v89
            else:
                v90 = False
            del v83
            v91 = v90 == False
            if v91:
                v92 = "The read index needs to be in range."
                assert v90, v92
                del v92
            else:
                pass
            del v90, v91
            v3[v81] = v80
            del v80, v81
            v93 = US3_0()
            v94 = US7_1(v73, v74, v75, v76, v77, v78)
            del v73, v74, v75, v76, v77, v78
            return v93, v3, v4, v5, v94
        case _:
            raise Exception('Pattern matching miss.')
def method12(v0 : list[US5], v1 : list, v2 : US3, v3 : list[US6], v4 : list, v5 : list[US2], v6 : US7, v7 : Callable[[US1], Tuple[UH0, US6]], v8 : US4, v9 : bool, v10 : list[US5], v11 : i32, v12 : list[i32], v13 : i32) -> Tuple[US3, list[US6], list, list[US2], US7]:
    del v8, v9, v10, v11
    v14 = [None] * 3
    v15 = [0]
    v16 = v15[0]
    del v16
    v15[0] = 1
    v17 = v15[0]
    v18 = 0 < v17
    del v17
    v19 = v18 == False
    if v19:
        v20 = "The set index needs to be in range."
        assert v18, v20
        del v20
    else:
        pass
    del v18, v19
    v21 = US1_0()
    v14[0] = v21
    del v21
    v22 = v12[0]
    v23 = v12[1]
    del v12
    v24 = v22 == v23
    del v22, v23
    v25 = v24 != True
    del v24
    if v25:
        v26 = v15[0]
        v27 = 1 + v26
        v15[0] = v27
        del v27
        v28 = 0 <= v26
        if v28:
            v29 = v15[0]
            v30 = v26 < v29
            del v29
            v31 = v30
        else:
            v31 = False
        v32 = v31 == False
        if v32:
            v33 = "The set index needs to be in range."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        if v28:
            v34 = v26 < 3
            v35 = v34
        else:
            v35 = False
        del v28
        v36 = v35 == False
        if v36:
            v37 = "The read index needs to be in range."
            assert v35, v37
            del v37
        else:
            pass
        del v35, v36
        v38 = US1_1()
        v14[v26] = v38
        del v26, v38
    else:
        pass
    del v25
    v39 = v13 > 0
    del v13
    if v39:
        v40 = v15[0]
        v41 = 1 + v40
        v15[0] = v41
        del v41
        v42 = 0 <= v40
        if v42:
            v43 = v15[0]
            v44 = v40 < v43
            del v43
            v45 = v44
        else:
            v45 = False
        v46 = v45 == False
        if v46:
            v47 = "The set index needs to be in range."
            assert v45, v47
            del v47
        else:
            pass
        del v45, v46
        if v42:
            v48 = v40 < 3
            v49 = v48
        else:
            v49 = False
        del v42
        v50 = v49 == False
        if v50:
            v51 = "The read index needs to be in range."
            assert v49, v51
            del v51
        else:
            pass
        del v49, v50
        v52 = US1_2()
        v14[v40] = v52
        del v40, v52
    else:
        pass
    del v39
    v53 = v15[0]
    v54 = v14[:v53]
    del v53
    random.shuffle(v54)
    v55 = v15[0]
    v14[:v55] = v54
    del v54, v55
    v56 = v15[0]
    v57 = v56 - 1
    del v56
    v58 = 0 <= v57
    if v58:
        v59 = v15[0]
        v60 = v57 < v59
        del v59
        v61 = v60
    else:
        v61 = False
    v62 = v61 == False
    if v62:
        v63 = "The read index needs to be in range."
        assert v61, v63
        del v63
    else:
        pass
    del v61, v62
    if v58:
        v64 = v57 < 3
        v65 = v64
    else:
        v65 = False
    del v58
    v66 = v65 == False
    if v66:
        v67 = "The read index needs to be in range."
        assert v65, v67
        del v67
    else:
        pass
    del v65, v66
    v68 = v14[v57]
    del v14
    v69 = v15[0]
    del v69
    v15[0] = v57
    del v15, v57
    v70, v71 = v7(v68)
    del v7, v68
    v72 = v4[0]
    v73 = 1 + v72
    v4[0] = v73
    del v73
    v74 = 0 <= v72
    if v74:
        v75 = v4[0]
        v76 = v72 < v75
        del v75
        v77 = v76
    else:
        v77 = False
    v78 = v77 == False
    if v78:
        v79 = "The set index needs to be in range."
        assert v77, v79
        del v79
    else:
        pass
    del v77, v78
    if v74:
        v80 = v72 < 32
        v81 = v80
    else:
        v81 = False
    del v74
    v82 = v81 == False
    if v82:
        v83 = "The read index needs to be in range."
        assert v81, v83
        del v83
    else:
        pass
    del v81, v82
    v3[v72] = v71
    del v71, v72
    match v70:
        case UH0_0(v90, v91, v92, v93, v94, v95, v96): # Action
            del v70
            v97 = 0 <= v93
            if v97:
                v98 = v93 < 2
                v99 = v98
            else:
                v99 = False
            del v97
            v100 = v99 == False
            if v100:
                v101 = "The read index needs to be in range."
                assert v99, v101
                del v101
            else:
                pass
            del v99, v100
            v102 = v5[v93]
            match v102:
                case US2_0(): # Computer
                    del v102
                    return method12(v0, v1, v2, v3, v4, v5, v6, v96, v90, v91, v92, v93, v94, v95)
                case US2_1(): # Human
                    del v2, v6, v102
                    v103 = Closure1(v3, v4, v96)
                    del v96
                    v104 = US3_1(v103, v0, v1)
                    del v0, v1, v103
                    v105 = US7_2(v90, v91, v92, v93, v94, v95)
                    del v90, v91, v92, v93, v94, v95
                    return v104, v3, v4, v5, v105
                case _:
                    raise Exception('Pattern matching miss.')
        case UH0_1(v84): # Chance
            del v70
            return method13(v0, v1, v2, v3, v4, v5, v6, v84)
        case UH0_2(v121, v122, v123, v124, v125, v126, _, v128): # Terminal
            del v0, v1, v2, v6, v70
            v129 = v4[0]
            v130 = 1 + v129
            v4[0] = v130
            del v130
            v131 = 0 <= v129
            if v131:
                v132 = v4[0]
                v133 = v129 < v132
                del v132
                v134 = v133
            else:
                v134 = False
            v135 = v134 == False
            if v135:
                v136 = "The set index needs to be in range."
                assert v134, v136
                del v136
            else:
                pass
            del v134, v135
            if v131:
                v137 = v129 < 32
                v138 = v137
            else:
                v138 = False
            del v131
            v139 = v138 == False
            if v139:
                v140 = "The read index needs to be in range."
                assert v138, v140
                del v140
            else:
                pass
            del v138, v139
            v3[v129] = v128
            del v128, v129
            v141 = US3_0()
            v142 = US7_1(v121, v122, v123, v124, v125, v126)
            del v121, v122, v123, v124, v125, v126
            return v141, v3, v4, v5, v142
        case _:
            raise Exception('Pattern matching miss.')
def method11(v0 : US3, v1 : list[US6], v2 : list, v3 : list[US2], v4 : US7, v5 : list[US5], v6 : list, v7 : UH0) -> Tuple[US3, list[US6], list, list[US2], US7]:
    match v7:
        case UH0_0(v14, v15, v16, v17, v18, v19, v20): # Action
            del v7
            v21 = 0 <= v17
            if v21:
                v22 = v17 < 2
                v23 = v22
            else:
                v23 = False
            del v21
            v24 = v23 == False
            if v24:
                v25 = "The read index needs to be in range."
                assert v23, v25
                del v25
            else:
                pass
            del v23, v24
            v26 = v3[v17]
            match v26:
                case US2_0(): # Computer
                    del v26
                    return method12(v5, v6, v0, v1, v2, v3, v4, v20, v14, v15, v16, v17, v18, v19)
                case US2_1(): # Human
                    del v0, v4, v26
                    v27 = Closure1(v1, v2, v20)
                    del v20
                    v28 = US3_1(v27, v5, v6)
                    del v5, v6, v27
                    v29 = US7_2(v14, v15, v16, v17, v18, v19)
                    del v14, v15, v16, v17, v18, v19
                    return v28, v1, v2, v3, v29
                case _:
                    raise Exception('Pattern matching miss.')
        case UH0_1(v8): # Chance
            del v7
            return method13(v5, v6, v0, v1, v2, v3, v4, v8)
        case UH0_2(v45, v46, v47, v48, v49, v50, _, v52): # Terminal
            del v0, v4, v5, v6, v7
            v53 = v2[0]
            v54 = 1 + v53
            v2[0] = v54
            del v54
            v55 = 0 <= v53
            if v55:
                v56 = v2[0]
                v57 = v53 < v56
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
            if v55:
                v61 = v53 < 32
                v62 = v61
            else:
                v62 = False
            del v55
            v63 = v62 == False
            if v63:
                v64 = "The read index needs to be in range."
                assert v62, v64
                del v64
            else:
                pass
            del v62, v63
            v1[v53] = v52
            del v52, v53
            v65 = US3_0()
            v66 = US7_1(v45, v46, v47, v48, v49, v50)
            del v45, v46, v47, v48, v49, v50
            return v65, v1, v2, v3, v66
        case _:
            raise Exception('Pattern matching miss.')
def method15(v0 : US5) -> i32:
    match v0:
        case US5_0(): # Jack
            del v0
            return 0
        case US5_1(): # King
            del v0
            return 2
        case US5_2(): # Queen
            del v0
            return 1
        case _:
            raise Exception('Pattern matching miss.')
def method16(v0 : i32, v1 : i32) -> bool:
    v2 = v1 == v0
    del v0, v1
    return v2
def method17(v0 : i32, v1 : i32) -> Tuple[i32, i32]:
    v2 = v1 > v0
    if v2:
        del v2
        return v1, v0
    else:
        del v2
        return v0, v1
def method14(v0 : US4, v1 : bool, v2 : list[US5], v3 : i32, v4 : list[i32], v5 : i32) -> US8:
    del v1, v3, v4, v5
    match v0:
        case US4_0(): # None
            del v0, v2
            raise Exception("Expected the community card to be present in the table.")
        case US4_1(v7): # Some
            del v0
            v8 = method15(v7)
            del v7
            v9 = v2[0]
            v10 = method15(v9)
            del v9
            v11 = v2[1]
            del v2
            v12 = method15(v11)
            del v11
            v13 = method16(v8, v10)
            v14 = method16(v8, v12)
            if v13:
                del v8, v13
                if v14:
                    del v14
                    v15 = v10 < v12
                    if v15:
                        del v10, v12, v15
                        return US8_2()
                    else:
                        del v15
                        v17 = v10 > v12
                        del v10, v12
                        if v17:
                            del v17
                            return US8_1()
                        else:
                            del v17
                            return US8_0()
                else:
                    del v10, v12, v14
                    return US8_1()
            else:
                del v13
                if v14:
                    del v8, v10, v12, v14
                    return US8_2()
                else:
                    del v14
                    v25, v26 = method17(v8, v10)
                    del v10
                    v27, v28 = method17(v8, v12)
                    del v8, v12
                    v29 = v25 < v27
                    if v29:
                        v35 = US8_2()
                    else:
                        v31 = v25 > v27
                        if v31:
                            del v31
                            v35 = US8_1()
                        else:
                            del v31
                            v35 = US8_0()
                    del v25, v27, v29
                    match v35:
                        case US8_0(): # Eq
                            v36 = True
                        case _:
                            v36 = False
                    if v36:
                        del v35, v36
                        v37 = v26 < v28
                        if v37:
                            del v26, v28, v37
                            return US8_2()
                        else:
                            del v37
                            v39 = v26 > v28
                            del v26, v28
                            if v39:
                                del v39
                                return US8_1()
                            else:
                                del v39
                                return US8_0()
                    else:
                        del v26, v28, v36
                        return v35
        case _:
            raise Exception('Pattern matching miss.')
def method19(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method18(v0 : Callable[[US4, bool, list[US5], i32, list[i32], i32], Callable[[Callable[[US1], UH0]], UH0]], v1 : Callable[[Callable[[US5], UH0]], UH0], v2 : Callable[[i32], Callable[[Callable[[US5], UH0]], UH0]], v3 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0], v4 : Callable[[US4, bool, list[US5], i32, list[i32], i32], UH0]) -> UH0:
    v5 = v2(0)
    v6 = Closure12(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    return v5(v6)
def method22(v0 : US5) -> object:
    match v0:
        case US5_0(): # Jack
            del v0
            v1 = []
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US5_1(): # King
            del v0
            v4 = []
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US5_2(): # Queen
            del v0
            v7 = []
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case _:
            raise Exception('Pattern matching miss.')
def method21(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4, v5, v6): # Some
            del v0
            v7 = v4
            del v4
            v8 = []
            v9 = v6[0]
            v10 = 0
            while method3(v9, v10):
                v12 = 0 <= v10
                if v12:
                    v13 = v6[0]
                    v14 = v10 < v13
                    del v13
                    v15 = v14
                else:
                    v15 = False
                v16 = v15 == False
                if v16:
                    v17 = "The read index needs to be in range."
                    assert v15, v17
                    del v17
                else:
                    pass
                del v15, v16
                if v12:
                    v18 = v10 < 6
                    v19 = v18
                else:
                    v19 = False
                del v12
                v20 = v19 == False
                if v20:
                    v21 = "The read index needs to be in range."
                    assert v19, v21
                    del v21
                else:
                    pass
                del v19, v20
                v22 = v5[v10]
                v23 = method22(v22)
                del v22
                v8.append(v23)
                del v23
                v10 += 1 
            del v5, v6, v9, v10
            v24 = {'cont': v7, 'deck': v8}
            del v7, v8
            v25 = "Some"
            v26 = [v25,v24]
            del v24, v25
            return v26
        case _:
            raise Exception('Pattern matching miss.')
def method24(v0 : US1) -> object:
    match v0:
        case US1_0(): # Call
            del v0
            v1 = []
            v2 = "Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # Fold
            del v0
            v4 = []
            v5 = "Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(): # Raise
            del v0
            v7 = []
            v8 = "Raise"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case _:
            raise Exception('Pattern matching miss.')
def method23(v0 : US6) -> object:
    match v0:
        case US6_0(v1): # CommunityCardIs
            del v0
            v2 = method22(v1)
            del v1
            v3 = "CommunityCardIs"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US6_1(v5, v6): # PlayerAction
            del v0
            v7 = []
            v8 = v5
            del v5
            v7.append(v8)
            del v8
            v9 = method24(v6)
            del v6
            v7.append(v9)
            del v9
            v10 = v7
            del v7
            v11 = "PlayerAction"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US6_2(v13, v14): # PlayerGotCard
            del v0
            v15 = []
            v16 = v13
            del v13
            v15.append(v16)
            del v16
            v17 = method22(v14)
            del v14
            v15.append(v17)
            del v17
            v18 = v15
            del v15
            v19 = "PlayerGotCard"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US6_3(v21, v22, v23): # Showdown
            del v0
            v24 = []
            v25 = 0
            while method19(v25):
                v27 = 0 <= v25
                if v27:
                    v28 = v25 < 2
                    v29 = v28
                else:
                    v29 = False
                del v27
                v30 = v29 == False
                if v30:
                    v31 = "The read index needs to be in range."
                    assert v29, v31
                    del v31
                else:
                    pass
                del v29, v30
                v32 = v21[v25]
                v33 = method22(v32)
                del v32
                v24.append(v33)
                del v33
                v25 += 1 
            del v21, v25
            v34 = v22
            del v22
            v35 = v23
            del v23
            v36 = {'cards_shown': v24, 'chips_won': v34, 'winner_id': v35}
            del v24, v34, v35
            v37 = "Showdown"
            v38 = [v37,v36]
            del v36, v37
            return v38
        case _:
            raise Exception('Pattern matching miss.')
def method25(v0 : US2) -> object:
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
        case _:
            raise Exception('Pattern matching miss.')
def method27(v0 : US4) -> object:
    match v0:
        case US4_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US4_1(v4): # Some
            del v0
            v5 = method22(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case _:
            raise Exception('Pattern matching miss.')
def method26(v0 : US7) -> object:
    match v0:
        case US7_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US7_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method27(v4)
            del v4
            v11 = v5
            del v5
            v12 = []
            v13 = 0
            while method19(v13):
                v15 = 0 <= v13
                if v15:
                    v16 = v13 < 2
                    v17 = v16
                else:
                    v17 = False
                del v15
                v18 = v17 == False
                if v18:
                    v19 = "The read index needs to be in range."
                    assert v17, v19
                    del v19
                else:
                    pass
                del v17, v18
                v20 = v6[v13]
                v21 = method22(v20)
                del v20
                v12.append(v21)
                del v21
                v13 += 1 
            del v6, v13
            v22 = v7
            del v7
            v23 = []
            v24 = 0
            while method19(v24):
                v26 = 0 <= v24
                if v26:
                    v27 = v24 < 2
                    v28 = v27
                else:
                    v28 = False
                del v26
                v29 = v28 == False
                if v29:
                    v30 = "The read index needs to be in range."
                    assert v28, v30
                    del v30
                else:
                    pass
                del v28, v29
                v31 = v8[v24]
                v32 = v31
                del v31
                v23.append(v32)
                del v32
                v24 += 1 
            del v8, v24
            v33 = v9
            del v9
            v34 = {'community_card': v10, 'is_button_s_first_move': v11, 'pl_card': v12, 'player_turn': v22, 'pot': v23, 'raises_left': v33}
            del v10, v11, v12, v22, v23, v33
            v35 = "GameOver"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US7_2(v37, v38, v39, v40, v41, v42): # WaitingForActionFromPlayerId
            del v0
            v43 = method27(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method19(v46):
                v48 = 0 <= v46
                if v48:
                    v49 = v46 < 2
                    v50 = v49
                else:
                    v50 = False
                del v48
                v51 = v50 == False
                if v51:
                    v52 = "The read index needs to be in range."
                    assert v50, v52
                    del v52
                else:
                    pass
                del v50, v51
                v53 = v39[v46]
                v54 = method22(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method19(v57):
                v59 = 0 <= v57
                if v59:
                    v60 = v57 < 2
                    v61 = v60
                else:
                    v61 = False
                del v59
                v62 = v61 == False
                if v62:
                    v63 = "The read index needs to be in range."
                    assert v61, v63
                    del v63
                else:
                    pass
                del v61, v62
                v64 = v41[v57]
                v65 = v64
                del v64
                v56.append(v65)
                del v65
                v57 += 1 
            del v41, v57
            v66 = v42
            del v42
            v67 = {'community_card': v43, 'is_button_s_first_move': v44, 'pl_card': v45, 'player_turn': v55, 'pot': v56, 'raises_left': v66}
            del v43, v44, v45, v55, v56, v66
            v68 = "WaitingForActionFromPlayerId"
            v69 = [v68,v67]
            del v67, v68
            return v69
        case _:
            raise Exception('Pattern matching miss.')
def method20(v0 : US3, v1 : list[US6], v2 : list, v3 : list[US2], v4 : US7) -> object:
    v5 = method21(v0)
    del v0
    v6 = {'next': v5}
    del v5
    v7 = []
    v8 = v2[0]
    v9 = 0
    while method3(v8, v9):
        v11 = 0 <= v9
        if v11:
            v12 = v2[0]
            v13 = v9 < v12
            del v12
            v14 = v13
        else:
            v14 = False
        v15 = v14 == False
        if v15:
            v16 = "The read index needs to be in range."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        if v11:
            v17 = v9 < 32
            v18 = v17
        else:
            v18 = False
        del v11
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v1[v9]
        v22 = method23(v21)
        del v21
        v7.append(v22)
        del v22
        v9 += 1 
    del v1, v2, v8, v9
    v23 = []
    v24 = 0
    while method19(v24):
        v26 = 0 <= v24
        if v26:
            v27 = v24 < 2
            v28 = v27
        else:
            v28 = False
        del v26
        v29 = v28 == False
        if v29:
            v30 = "The read index needs to be in range."
            assert v28, v30
            del v30
        else:
            pass
        del v28, v29
        v31 = v3[v24]
        v32 = method25(v31)
        del v31
        v23.append(v32)
        del v32
        v24 += 1 
    del v3, v24
    v33 = method26(v4)
    del v4
    v34 = {'messages': v7, 'pl_type': v23, 'ui_game_state': v33}
    del v7, v23, v33
    v35 = {'game_state': v6, 'ui_state': v34}
    del v6, v34
    return v35
def main():
    v0 = Closure0()
    v1 = Closure22()
    v2 = collections.namedtuple("Leduc_Game",['event_loop_cpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
