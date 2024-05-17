kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
import collections
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
class US4_0(NamedTuple): # Jack
    tag = 0
class US4_1(NamedTuple): # King
    tag = 1
class US4_2(NamedTuple): # Queen
    tag = 2
US4 = Union[US4_0, US4_1, US4_2]
class US6_0(NamedTuple): # None
    tag = 0
class US6_1(NamedTuple): # Some
    v0 : US4
    tag = 1
US6 = Union[US6_0, US6_1]
class US5_0(NamedTuple): # ChanceCommunityCard
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 0
class US5_1(NamedTuple): # ChanceInit
    tag = 1
class US5_2(NamedTuple): # Round
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
class US5_3(NamedTuple): # RoundWithAction
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    v6 : US1
    tag = 3
class US5_4(NamedTuple): # TerminalCall
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 4
class US5_5(NamedTuple): # TerminalFold
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 5
US5 = Union[US5_0, US5_1, US5_2, US5_3, US5_4, US5_5]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : list[US4]
    v1 : list
    v2 : US5
    tag = 1
US3 = Union[US3_0, US3_1]
class US7_0(NamedTuple): # CommunityCardIs
    v0 : US4
    tag = 0
class US7_1(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 1
class US7_2(NamedTuple): # PlayerGotCard
    v0 : i32
    v1 : US4
    tag = 2
class US7_3(NamedTuple): # Showdown
    v0 : list[US4]
    v1 : i32
    v2 : i32
    tag = 3
US7 = Union[US7_0, US7_1, US7_2, US7_3]
class US8_0(NamedTuple): # GameNotStarted
    tag = 0
class US8_1(NamedTuple): # GameOver
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 1
class US8_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : US6
    v1 : bool
    v2 : list[US4]
    v3 : i32
    v4 : list[i32]
    v5 : i32
    tag = 2
US8 = Union[US8_0, US8_1, US8_2]
class US9_0(NamedTuple): # Eq
    tag = 0
class US9_1(NamedTuple): # Gt
    tag = 1
class US9_2(NamedTuple): # Lt
    tag = 2
US9 = Union[US9_0, US9_1, US9_2]
def Closure0():
    def inner(v0 : object, v1 : object) -> object:
        v2 = method0(v0)
        v3, v4, v5, v6, v7 = method5(v1)
        match v2:
            case US0_0(v58): # ActionSelected
                match v3:
                    case US3_0(): # None
                        del v58
                        v104, v105, v106, v107, v108 = v3, v4, v5, v6, v7
                    case US3_1(v59, v60, v61): # Some
                        match v61:
                            case US5_2(v62, v63, v64, v65, v66, v67): # Round
                                del v61
                                v68 = US5_3(v62, v63, v64, v65, v66, v67, v58)
                                del v58, v62, v63, v64, v65, v66, v67
                                v104, v105, v106, v107, v108 = method12(v3, v4, v5, v6, v7, v59, v60, v68)
                            case _:
                                del v58, v59, v60, v61
                                raise Exception("Unexpected game node in ActionSelected.")
                    case _:
                        raise Exception('Pattern matching miss.')
            case US0_1(v57): # PlayerChanged
                v104, v105, v106, v107, v108 = v3, v4, v5, v57, v7
            case US0_2(): # StartGame
                v8 = [None] * 2
                v9 = US2_0()
                v8[0] = v9
                del v9
                v10 = US2_1()
                v8[1] = v10
                del v10
                v11 = [None] * 32
                v12 = [0]
                v13 = US3_0()
                v14 = US8_0()
                v15 = [None] * 6
                v16 = [0]
                v17 = v16[0]
                del v17
                v16[0] = 6
                v18 = v16[0]
                v19 = 0 < v18
                del v18
                v20 = v19 == False
                if v20:
                    v21 = "The set index needs to be in range."
                    assert v19, v21
                    del v21
                else:
                    pass
                del v19, v20
                v22 = US4_1()
                v15[0] = v22
                del v22
                v23 = v16[0]
                v24 = 1 < v23
                del v23
                v25 = v24 == False
                if v25:
                    v26 = "The set index needs to be in range."
                    assert v24, v26
                    del v26
                else:
                    pass
                del v24, v25
                v27 = US4_1()
                v15[1] = v27
                del v27
                v28 = v16[0]
                v29 = 2 < v28
                del v28
                v30 = v29 == False
                if v30:
                    v31 = "The set index needs to be in range."
                    assert v29, v31
                    del v31
                else:
                    pass
                del v29, v30
                v32 = US4_2()
                v15[2] = v32
                del v32
                v33 = v16[0]
                v34 = 3 < v33
                del v33
                v35 = v34 == False
                if v35:
                    v36 = "The set index needs to be in range."
                    assert v34, v36
                    del v36
                else:
                    pass
                del v34, v35
                v37 = US4_2()
                v15[3] = v37
                del v37
                v38 = v16[0]
                v39 = 4 < v38
                del v38
                v40 = v39 == False
                if v40:
                    v41 = "The set index needs to be in range."
                    assert v39, v41
                    del v41
                else:
                    pass
                del v39, v40
                v42 = US4_0()
                v15[4] = v42
                del v42
                v43 = v16[0]
                v44 = 5 < v43
                del v43
                v45 = v44 == False
                if v45:
                    v46 = "The set index needs to be in range."
                    assert v44, v46
                    del v46
                else:
                    pass
                del v44, v45
                v47 = US4_0()
                v15[5] = v47
                del v47
                v48 = v16[0]
                v49 = v15[:v48]
                del v48
                random.shuffle(v49)
                v50 = v16[0]
                v15[:v50] = v49
                del v49, v50
                v51 = US5_1()
                v104, v105, v106, v107, v108 = method12(v13, v11, v12, v8, v14, v15, v16, v51)
            case _:
                raise Exception('Pattern matching miss.')
        del v2, v3, v4, v5, v6, v7
        return method19(v104, v105, v106, v107, v108)
    return inner
def Closure1():
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
        v6 = US8_0()
        return method19(v5, v3, v4, v0, v6)
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
def method7(v0 : object) -> US4:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Jack" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US4_0()
    else:
        del v4
        v7 = "King" == v1
        if v7:
            del v1, v7
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US4_1()
        else:
            del v7
            v10 = "Queen" == v1
            if v10:
                del v1, v10
                assert v2 == [], f'Expected an unit type. Got: {v2}'
                del v2
                return US4_2()
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method9(v0 : object) -> US6:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US6_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method7(v2)
            del v2
            return US6_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method8(v0 : object) -> US5:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "ChanceCommunityCard" == v1
    if v4:
        del v1, v4
        v5 = "community_card"
        v6 = v2[v5]
        del v5
        v7 = method9(v6)
        del v6
        v8 = "is_button_s_first_move"
        v9 = v2[v8]
        del v8
        assert isinstance(v9,bool), f'The object needs to be the right primitive type. Got: {v9}'
        v10 = v9
        del v9
        v11 = "pl_card"
        v12 = v2[v11]
        del v11
        assert isinstance(v12,list), f'The object needs to be a Python list. Got: {v12}'
        v13 = len(v12)
        v14 = 2 == v13
        v15 = v14 == False
        if v15:
            v16 = "The type level dimension has to equal the value passed at runtime into create."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v17 = [None] * 2
        v18 = 0
        while method3(v13, v18):
            v20 = v12[v18]
            v21 = method7(v20)
            del v20
            v22 = 0 <= v18
            if v22:
                v23 = v18 < 2
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
            v17[v18] = v21
            del v21
            v18 += 1 
        del v12, v13, v18
        v27 = "player_turn"
        v28 = v2[v27]
        del v27
        assert isinstance(v28,i32), f'The object needs to be the right primitive type. Got: {v28}'
        v29 = v28
        del v28
        v30 = "pot"
        v31 = v2[v30]
        del v30
        assert isinstance(v31,list), f'The object needs to be a Python list. Got: {v31}'
        v32 = len(v31)
        v33 = 2 == v32
        v34 = v33 == False
        if v34:
            v35 = "The type level dimension has to equal the value passed at runtime into create."
            assert v33, v35
            del v35
        else:
            pass
        del v33, v34
        v36 = [None] * 2
        v37 = 0
        while method3(v32, v37):
            v39 = v31[v37]
            assert isinstance(v39,i32), f'The object needs to be the right primitive type. Got: {v39}'
            v40 = v39
            del v39
            v41 = 0 <= v37
            if v41:
                v42 = v37 < 2
                v43 = v42
            else:
                v43 = False
            del v41
            v44 = v43 == False
            if v44:
                v45 = "The read index needs to be in range."
                assert v43, v45
                del v45
            else:
                pass
            del v43, v44
            v36[v37] = v40
            del v40
            v37 += 1 
        del v31, v32, v37
        v46 = "raises_left"
        v47 = v2[v46]
        del v2, v46
        assert isinstance(v47,i32), f'The object needs to be the right primitive type. Got: {v47}'
        v48 = v47
        del v47
        return US5_0(v7, v10, v17, v29, v36, v48)
    else:
        del v4
        v51 = "ChanceInit" == v1
        if v51:
            del v1, v51
            assert v2 == [], f'Expected an unit type. Got: {v2}'
            del v2
            return US5_1()
        else:
            del v51
            v54 = "Round" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method9(v56)
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
                return US5_2(v57, v60, v67, v79, v86, v98)
            else:
                del v54
                v101 = "RoundWithAction" == v1
                if v101:
                    del v1, v101
                    v102 = v2[0]
                    v103 = "community_card"
                    v104 = v102[v103]
                    del v103
                    v105 = method9(v104)
                    del v104
                    v106 = "is_button_s_first_move"
                    v107 = v102[v106]
                    del v106
                    assert isinstance(v107,bool), f'The object needs to be the right primitive type. Got: {v107}'
                    v108 = v107
                    del v107
                    v109 = "pl_card"
                    v110 = v102[v109]
                    del v109
                    assert isinstance(v110,list), f'The object needs to be a Python list. Got: {v110}'
                    v111 = len(v110)
                    v112 = 2 == v111
                    v113 = v112 == False
                    if v113:
                        v114 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v112, v114
                        del v114
                    else:
                        pass
                    del v112, v113
                    v115 = [None] * 2
                    v116 = 0
                    while method3(v111, v116):
                        v118 = v110[v116]
                        v119 = method7(v118)
                        del v118
                        v120 = 0 <= v116
                        if v120:
                            v121 = v116 < 2
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
                        v115[v116] = v119
                        del v119
                        v116 += 1 
                    del v110, v111, v116
                    v125 = "player_turn"
                    v126 = v102[v125]
                    del v125
                    assert isinstance(v126,i32), f'The object needs to be the right primitive type. Got: {v126}'
                    v127 = v126
                    del v126
                    v128 = "pot"
                    v129 = v102[v128]
                    del v128
                    assert isinstance(v129,list), f'The object needs to be a Python list. Got: {v129}'
                    v130 = len(v129)
                    v131 = 2 == v130
                    v132 = v131 == False
                    if v132:
                        v133 = "The type level dimension has to equal the value passed at runtime into create."
                        assert v131, v133
                        del v133
                    else:
                        pass
                    del v131, v132
                    v134 = [None] * 2
                    v135 = 0
                    while method3(v130, v135):
                        v137 = v129[v135]
                        assert isinstance(v137,i32), f'The object needs to be the right primitive type. Got: {v137}'
                        v138 = v137
                        del v137
                        v139 = 0 <= v135
                        if v139:
                            v140 = v135 < 2
                            v141 = v140
                        else:
                            v141 = False
                        del v139
                        v142 = v141 == False
                        if v142:
                            v143 = "The read index needs to be in range."
                            assert v141, v143
                            del v143
                        else:
                            pass
                        del v141, v142
                        v134[v135] = v138
                        del v138
                        v135 += 1 
                    del v129, v130, v135
                    v144 = "raises_left"
                    v145 = v102[v144]
                    del v102, v144
                    assert isinstance(v145,i32), f'The object needs to be the right primitive type. Got: {v145}'
                    v146 = v145
                    del v145
                    v147 = v2[1]
                    del v2
                    v148 = method2(v147)
                    del v147
                    return US5_3(v105, v108, v115, v127, v134, v146, v148)
                else:
                    del v101
                    v151 = "TerminalCall" == v1
                    if v151:
                        del v1, v151
                        v152 = "community_card"
                        v153 = v2[v152]
                        del v152
                        v154 = method9(v153)
                        del v153
                        v155 = "is_button_s_first_move"
                        v156 = v2[v155]
                        del v155
                        assert isinstance(v156,bool), f'The object needs to be the right primitive type. Got: {v156}'
                        v157 = v156
                        del v156
                        v158 = "pl_card"
                        v159 = v2[v158]
                        del v158
                        assert isinstance(v159,list), f'The object needs to be a Python list. Got: {v159}'
                        v160 = len(v159)
                        v161 = 2 == v160
                        v162 = v161 == False
                        if v162:
                            v163 = "The type level dimension has to equal the value passed at runtime into create."
                            assert v161, v163
                            del v163
                        else:
                            pass
                        del v161, v162
                        v164 = [None] * 2
                        v165 = 0
                        while method3(v160, v165):
                            v167 = v159[v165]
                            v168 = method7(v167)
                            del v167
                            v169 = 0 <= v165
                            if v169:
                                v170 = v165 < 2
                                v171 = v170
                            else:
                                v171 = False
                            del v169
                            v172 = v171 == False
                            if v172:
                                v173 = "The read index needs to be in range."
                                assert v171, v173
                                del v173
                            else:
                                pass
                            del v171, v172
                            v164[v165] = v168
                            del v168
                            v165 += 1 
                        del v159, v160, v165
                        v174 = "player_turn"
                        v175 = v2[v174]
                        del v174
                        assert isinstance(v175,i32), f'The object needs to be the right primitive type. Got: {v175}'
                        v176 = v175
                        del v175
                        v177 = "pot"
                        v178 = v2[v177]
                        del v177
                        assert isinstance(v178,list), f'The object needs to be a Python list. Got: {v178}'
                        v179 = len(v178)
                        v180 = 2 == v179
                        v181 = v180 == False
                        if v181:
                            v182 = "The type level dimension has to equal the value passed at runtime into create."
                            assert v180, v182
                            del v182
                        else:
                            pass
                        del v180, v181
                        v183 = [None] * 2
                        v184 = 0
                        while method3(v179, v184):
                            v186 = v178[v184]
                            assert isinstance(v186,i32), f'The object needs to be the right primitive type. Got: {v186}'
                            v187 = v186
                            del v186
                            v188 = 0 <= v184
                            if v188:
                                v189 = v184 < 2
                                v190 = v189
                            else:
                                v190 = False
                            del v188
                            v191 = v190 == False
                            if v191:
                                v192 = "The read index needs to be in range."
                                assert v190, v192
                                del v192
                            else:
                                pass
                            del v190, v191
                            v183[v184] = v187
                            del v187
                            v184 += 1 
                        del v178, v179, v184
                        v193 = "raises_left"
                        v194 = v2[v193]
                        del v2, v193
                        assert isinstance(v194,i32), f'The object needs to be the right primitive type. Got: {v194}'
                        v195 = v194
                        del v194
                        return US5_4(v154, v157, v164, v176, v183, v195)
                    else:
                        del v151
                        v198 = "TerminalFold" == v1
                        if v198:
                            del v1, v198
                            v199 = "community_card"
                            v200 = v2[v199]
                            del v199
                            v201 = method9(v200)
                            del v200
                            v202 = "is_button_s_first_move"
                            v203 = v2[v202]
                            del v202
                            assert isinstance(v203,bool), f'The object needs to be the right primitive type. Got: {v203}'
                            v204 = v203
                            del v203
                            v205 = "pl_card"
                            v206 = v2[v205]
                            del v205
                            assert isinstance(v206,list), f'The object needs to be a Python list. Got: {v206}'
                            v207 = len(v206)
                            v208 = 2 == v207
                            v209 = v208 == False
                            if v209:
                                v210 = "The type level dimension has to equal the value passed at runtime into create."
                                assert v208, v210
                                del v210
                            else:
                                pass
                            del v208, v209
                            v211 = [None] * 2
                            v212 = 0
                            while method3(v207, v212):
                                v214 = v206[v212]
                                v215 = method7(v214)
                                del v214
                                v216 = 0 <= v212
                                if v216:
                                    v217 = v212 < 2
                                    v218 = v217
                                else:
                                    v218 = False
                                del v216
                                v219 = v218 == False
                                if v219:
                                    v220 = "The read index needs to be in range."
                                    assert v218, v220
                                    del v220
                                else:
                                    pass
                                del v218, v219
                                v211[v212] = v215
                                del v215
                                v212 += 1 
                            del v206, v207, v212
                            v221 = "player_turn"
                            v222 = v2[v221]
                            del v221
                            assert isinstance(v222,i32), f'The object needs to be the right primitive type. Got: {v222}'
                            v223 = v222
                            del v222
                            v224 = "pot"
                            v225 = v2[v224]
                            del v224
                            assert isinstance(v225,list), f'The object needs to be a Python list. Got: {v225}'
                            v226 = len(v225)
                            v227 = 2 == v226
                            v228 = v227 == False
                            if v228:
                                v229 = "The type level dimension has to equal the value passed at runtime into create."
                                assert v227, v229
                                del v229
                            else:
                                pass
                            del v227, v228
                            v230 = [None] * 2
                            v231 = 0
                            while method3(v226, v231):
                                v233 = v225[v231]
                                assert isinstance(v233,i32), f'The object needs to be the right primitive type. Got: {v233}'
                                v234 = v233
                                del v233
                                v235 = 0 <= v231
                                if v235:
                                    v236 = v231 < 2
                                    v237 = v236
                                else:
                                    v237 = False
                                del v235
                                v238 = v237 == False
                                if v238:
                                    v239 = "The read index needs to be in range."
                                    assert v237, v239
                                    del v239
                                else:
                                    pass
                                del v237, v238
                                v230[v231] = v234
                                del v234
                                v231 += 1 
                            del v225, v226, v231
                            v240 = "raises_left"
                            v241 = v2[v240]
                            del v2, v240
                            assert isinstance(v241,i32), f'The object needs to be the right primitive type. Got: {v241}'
                            v242 = v241
                            del v241
                            return US5_5(v201, v204, v211, v223, v230, v242)
                        else:
                            del v2, v198
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
            v8 = "deck"
            v9 = v2[v8]
            del v8
            v10 = len(v9)
            assert (6 >= v10), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 6\nGot: {v10} '
            del v10
            assert isinstance(v9,list), f'The object needs to be a Python list. Got: {v9}'
            v11 = len(v9)
            v12 = 6 >= v11
            v13 = v12 == False
            if v13:
                v14 = "The type level dimension has to equal the value passed at runtime into create."
                assert v12, v14
                del v14
            else:
                pass
            del v12, v13
            v15 = [None] * 6
            v16 = [0]
            v17 = v16[0]
            del v17
            v16[0] = v11
            v18 = 0
            while method3(v11, v18):
                v20 = v9[v18]
                v21 = method7(v20)
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
                    v28 = v18 < 6
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
            v32 = "game"
            v33 = v2[v32]
            del v2, v32
            v34 = method8(v33)
            del v33
            return US3_1(v15, v16, v34)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method10(v0 : object) -> US7:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "CommunityCardIs" == v1
    if v4:
        del v1, v4
        v5 = method7(v2)
        del v2
        return US7_0(v5)
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
            return US7_1(v10, v12)
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
                return US7_2(v17, v19)
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
                    return US7_3(v29, v41, v44)
                else:
                    del v2, v22
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method11(v0 : object) -> US8:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        assert v2 == [], f'Expected an unit type. Got: {v2}'
        del v2
        return US8_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8 = "community_card"
            v9 = v2[v8]
            del v8
            v10 = method9(v9)
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
            return US8_1(v10, v13, v20, v32, v39, v51)
        else:
            del v7
            v54 = "WaitingForActionFromPlayerId" == v1
            if v54:
                del v1, v54
                v55 = "community_card"
                v56 = v2[v55]
                del v55
                v57 = method9(v56)
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
                return US8_2(v57, v60, v67, v79, v86, v98)
            else:
                del v2, v54
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method5(v0 : object) -> Tuple[US3, list[US7], list, list[US2], US8]:
    v1 = "game_state"
    v2 = v0[v1]
    del v1
    v3 = method6(v2)
    del v2
    v4 = "ui_state"
    v5 = v0[v4]
    del v0, v4
    v6 = "messages"
    v7 = v5[v6]
    del v6
    v8 = len(v7)
    assert (32 >= v8), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 32\nGot: {v8} '
    del v8
    assert isinstance(v7,list), f'The object needs to be a Python list. Got: {v7}'
    v9 = len(v7)
    v10 = 32 >= v9
    v11 = v10 == False
    if v11:
        v12 = "The type level dimension has to equal the value passed at runtime into create."
        assert v10, v12
        del v12
    else:
        pass
    del v10, v11
    v13 = [None] * 32
    v14 = [0]
    v15 = v14[0]
    del v15
    v14[0] = v9
    v16 = 0
    while method3(v9, v16):
        v18 = v7[v16]
        v19 = method10(v18)
        del v18
        v20 = 0 <= v16
        if v20:
            v21 = v14[0]
            v22 = v16 < v21
            del v21
            v23 = v22
        else:
            v23 = False
        v24 = v23 == False
        if v24:
            v25 = "The set index needs to be in range."
            assert v23, v25
            del v25
        else:
            pass
        del v23, v24
        if v20:
            v26 = v16 < 32
            v27 = v26
        else:
            v27 = False
        del v20
        v28 = v27 == False
        if v28:
            v29 = "The read index needs to be in range."
            assert v27, v29
            del v29
        else:
            pass
        del v27, v28
        v13[v16] = v19
        del v19
        v16 += 1 
    del v7, v9, v16
    v30 = "pl_type"
    v31 = v5[v30]
    del v30
    assert isinstance(v31,list), f'The object needs to be a Python list. Got: {v31}'
    v32 = len(v31)
    v33 = 2 == v32
    v34 = v33 == False
    if v34:
        v35 = "The type level dimension has to equal the value passed at runtime into create."
        assert v33, v35
        del v35
    else:
        pass
    del v33, v34
    v36 = [None] * 2
    v37 = 0
    while method3(v32, v37):
        v39 = v31[v37]
        v40 = method4(v39)
        del v39
        v41 = 0 <= v37
        if v41:
            v42 = v37 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v36[v37] = v40
        del v40
        v37 += 1 
    del v31, v32, v37
    v46 = "ui_game_state"
    v47 = v5[v46]
    del v5, v46
    v48 = method11(v47)
    del v47
    return v3, v13, v14, v36, v48
def method14(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method16(v0 : US4) -> i32:
    match v0:
        case US4_0(): # Jack
            del v0
            return 0
        case US4_1(): # King
            del v0
            return 2
        case US4_2(): # Queen
            del v0
            return 1
        case _:
            raise Exception('Pattern matching miss.')
def method17(v0 : i32, v1 : i32) -> bool:
    v2 = v1 == v0
    del v0, v1
    return v2
def method18(v0 : i32, v1 : i32) -> Tuple[i32, i32]:
    v2 = v1 > v0
    if v2:
        del v2
        return v1, v0
    else:
        del v2
        return v0, v1
def method15(v0 : US6, v1 : bool, v2 : list[US4], v3 : i32, v4 : list[i32], v5 : i32) -> US9:
    del v1, v3, v4, v5
    match v0:
        case US6_0(): # None
            del v0, v2
            raise Exception("Expected the community card to be present in the table.")
        case US6_1(v7): # Some
            del v0
            v8 = method16(v7)
            del v7
            v9 = v2[0]
            v10 = method16(v9)
            del v9
            v11 = v2[1]
            del v2
            v12 = method16(v11)
            del v11
            v13 = method17(v8, v10)
            v14 = method17(v8, v12)
            if v13:
                del v8, v13
                if v14:
                    del v14
                    v15 = v10 < v12
                    if v15:
                        del v10, v12, v15
                        return US9_2()
                    else:
                        del v15
                        v17 = v10 > v12
                        del v10, v12
                        if v17:
                            del v17
                            return US9_1()
                        else:
                            del v17
                            return US9_0()
                else:
                    del v10, v12, v14
                    return US9_1()
            else:
                del v13
                if v14:
                    del v8, v10, v12, v14
                    return US9_2()
                else:
                    del v14
                    v25, v26 = method18(v8, v10)
                    del v10
                    v27, v28 = method18(v8, v12)
                    del v8, v12
                    v29 = v25 < v27
                    if v29:
                        v35 = US9_2()
                    else:
                        v31 = v25 > v27
                        if v31:
                            del v31
                            v35 = US9_1()
                        else:
                            del v31
                            v35 = US9_0()
                    del v25, v27, v29
                    match v35:
                        case US9_0(): # Eq
                            v36 = True
                        case _:
                            v36 = False
                    if v36:
                        del v35, v36
                        v37 = v26 < v28
                        if v37:
                            del v26, v28, v37
                            return US9_2()
                        else:
                            del v37
                            v39 = v26 > v28
                            del v26, v28
                            if v39:
                                del v39
                                return US9_1()
                            else:
                                del v39
                                return US9_0()
                    else:
                        del v26, v28, v36
                        return v35
        case _:
            raise Exception('Pattern matching miss.')
def method13(v0 : list[US4], v1 : list, v2 : list[US7], v3 : list, v4 : list[US2], v5 : US5) -> US5:
    match v5:
        case US5_0(_, _, v418, _, v420, _): # ChanceCommunityCard
            del v5
            v422 = v1[0]
            v423 = v422 - 1
            del v422
            v424 = 0 <= v423
            if v424:
                v425 = v1[0]
                v426 = v423 < v425
                del v425
                v427 = v426
            else:
                v427 = False
            v428 = v427 == False
            if v428:
                v429 = "The read index needs to be in range."
                assert v427, v429
                del v429
            else:
                pass
            del v427, v428
            if v424:
                v430 = v423 < 6
                v431 = v430
            else:
                v431 = False
            del v424
            v432 = v431 == False
            if v432:
                v433 = "The read index needs to be in range."
                assert v431, v433
                del v433
            else:
                pass
            del v431, v432
            v434 = v0[v423]
            v435 = v1[0]
            del v435
            v1[0] = v423
            del v423
            v436 = v3[0]
            v437 = 1 + v436
            v3[0] = v437
            del v437
            v438 = 0 <= v436
            if v438:
                v439 = v3[0]
                v440 = v436 < v439
                del v439
                v441 = v440
            else:
                v441 = False
            v442 = v441 == False
            if v442:
                v443 = "The set index needs to be in range."
                assert v441, v443
                del v443
            else:
                pass
            del v441, v442
            if v438:
                v444 = v436 < 32
                v445 = v444
            else:
                v445 = False
            del v438
            v446 = v445 == False
            if v446:
                v447 = "The read index needs to be in range."
                assert v445, v447
                del v447
            else:
                pass
            del v445, v446
            v448 = US7_0(v434)
            v2[v436] = v448
            del v436, v448
            v449 = 2
            v450, v451 = (0, 0)
            while method14(v450):
                v453 = 0 <= v450
                if v453:
                    v454 = v450 < 2
                    v455 = v454
                else:
                    v455 = False
                del v453
                v456 = v455 == False
                if v456:
                    v457 = "The read index needs to be in range."
                    assert v455, v457
                    del v457
                else:
                    pass
                del v455, v456
                v458 = v420[v450]
                v459 = v451 >= v458
                if v459:
                    v460 = v451
                else:
                    v460 = v458
                del v458, v459
                v451 = v460
                del v460
                v450 += 1 
            del v420, v450
            v461 = [None] * 2
            v462 = 0
            while method14(v462):
                v464 = 0 <= v462
                if v464:
                    v465 = v462 < 2
                    v466 = v465
                else:
                    v466 = False
                del v464
                v467 = v466 == False
                if v467:
                    v468 = "The read index needs to be in range."
                    assert v466, v468
                    del v468
                else:
                    pass
                del v466, v467
                v461[v462] = v451
                v462 += 1 
            del v451, v462
            v469 = US6_1(v434)
            del v434
            v470 = True
            v471 = 0
            v472 = US5_2(v469, v470, v418, v471, v461, v449)
            del v418, v449, v461, v469, v470, v471
            return method13(v0, v1, v2, v3, v4, v472)
        case US5_1(): # ChanceInit
            del v5
            v474 = v1[0]
            v475 = v474 - 1
            del v474
            v476 = 0 <= v475
            if v476:
                v477 = v1[0]
                v478 = v475 < v477
                del v477
                v479 = v478
            else:
                v479 = False
            v480 = v479 == False
            if v480:
                v481 = "The read index needs to be in range."
                assert v479, v481
                del v481
            else:
                pass
            del v479, v480
            if v476:
                v482 = v475 < 6
                v483 = v482
            else:
                v483 = False
            del v476
            v484 = v483 == False
            if v484:
                v485 = "The read index needs to be in range."
                assert v483, v485
                del v485
            else:
                pass
            del v483, v484
            v486 = v0[v475]
            v487 = v1[0]
            del v487
            v1[0] = v475
            del v475
            v488 = v1[0]
            v489 = v488 - 1
            del v488
            v490 = 0 <= v489
            if v490:
                v491 = v1[0]
                v492 = v489 < v491
                del v491
                v493 = v492
            else:
                v493 = False
            v494 = v493 == False
            if v494:
                v495 = "The read index needs to be in range."
                assert v493, v495
                del v495
            else:
                pass
            del v493, v494
            if v490:
                v496 = v489 < 6
                v497 = v496
            else:
                v497 = False
            del v490
            v498 = v497 == False
            if v498:
                v499 = "The read index needs to be in range."
                assert v497, v499
                del v499
            else:
                pass
            del v497, v498
            v500 = v0[v489]
            v501 = v1[0]
            del v501
            v1[0] = v489
            del v489
            v502 = v3[0]
            v503 = 1 + v502
            v3[0] = v503
            del v503
            v504 = 0 <= v502
            if v504:
                v505 = v3[0]
                v506 = v502 < v505
                del v505
                v507 = v506
            else:
                v507 = False
            v508 = v507 == False
            if v508:
                v509 = "The set index needs to be in range."
                assert v507, v509
                del v509
            else:
                pass
            del v507, v508
            if v504:
                v510 = v502 < 32
                v511 = v510
            else:
                v511 = False
            del v504
            v512 = v511 == False
            if v512:
                v513 = "The read index needs to be in range."
                assert v511, v513
                del v513
            else:
                pass
            del v511, v512
            v514 = US7_2(0, v486)
            v2[v502] = v514
            del v502, v514
            v515 = v3[0]
            v516 = 1 + v515
            v3[0] = v516
            del v516
            v517 = 0 <= v515
            if v517:
                v518 = v3[0]
                v519 = v515 < v518
                del v518
                v520 = v519
            else:
                v520 = False
            v521 = v520 == False
            if v521:
                v522 = "The set index needs to be in range."
                assert v520, v522
                del v522
            else:
                pass
            del v520, v521
            if v517:
                v523 = v515 < 32
                v524 = v523
            else:
                v524 = False
            del v517
            v525 = v524 == False
            if v525:
                v526 = "The read index needs to be in range."
                assert v524, v526
                del v526
            else:
                pass
            del v524, v525
            v527 = US7_2(1, v500)
            v2[v515] = v527
            del v515, v527
            v528 = 2
            v529 = [None] * 2
            v529[0] = 1
            v529[1] = 1
            v530 = [None] * 2
            v530[0] = v486
            del v486
            v530[1] = v500
            del v500
            v531 = US6_0()
            v532 = True
            v533 = 0
            v534 = US5_2(v531, v532, v530, v533, v529, v528)
            del v528, v529, v530, v531, v532, v533
            return method13(v0, v1, v2, v3, v4, v534)
        case US5_2(v65, v66, v67, v68, v69, v70): # Round
            v71 = 0 <= v68
            if v71:
                v72 = v68 < 2
                v73 = v72
            else:
                v73 = False
            del v71
            v74 = v73 == False
            if v74:
                v75 = "The read index needs to be in range."
                assert v73, v75
                del v75
            else:
                pass
            del v73, v74
            v76 = v4[v68]
            match v76:
                case US2_0(): # Computer
                    del v5, v76
                    v77 = [None] * 3
                    v78 = [0]
                    v79 = v78[0]
                    del v79
                    v78[0] = 1
                    v80 = v78[0]
                    v81 = 0 < v80
                    del v80
                    v82 = v81 == False
                    if v82:
                        v83 = "The set index needs to be in range."
                        assert v81, v83
                        del v83
                    else:
                        pass
                    del v81, v82
                    v84 = US1_0()
                    v77[0] = v84
                    del v84
                    v85 = v69[0]
                    v86 = v69[1]
                    v87 = v85 == v86
                    del v85, v86
                    v88 = v87 != True
                    del v87
                    if v88:
                        v89 = v78[0]
                        v90 = 1 + v89
                        v78[0] = v90
                        del v90
                        v91 = 0 <= v89
                        if v91:
                            v92 = v78[0]
                            v93 = v89 < v92
                            del v92
                            v94 = v93
                        else:
                            v94 = False
                        v95 = v94 == False
                        if v95:
                            v96 = "The set index needs to be in range."
                            assert v94, v96
                            del v96
                        else:
                            pass
                        del v94, v95
                        if v91:
                            v97 = v89 < 3
                            v98 = v97
                        else:
                            v98 = False
                        del v91
                        v99 = v98 == False
                        if v99:
                            v100 = "The read index needs to be in range."
                            assert v98, v100
                            del v100
                        else:
                            pass
                        del v98, v99
                        v101 = US1_1()
                        v77[v89] = v101
                        del v89, v101
                    else:
                        pass
                    del v88
                    v102 = v70 > 0
                    if v102:
                        v103 = v78[0]
                        v104 = 1 + v103
                        v78[0] = v104
                        del v104
                        v105 = 0 <= v103
                        if v105:
                            v106 = v78[0]
                            v107 = v103 < v106
                            del v106
                            v108 = v107
                        else:
                            v108 = False
                        v109 = v108 == False
                        if v109:
                            v110 = "The set index needs to be in range."
                            assert v108, v110
                            del v110
                        else:
                            pass
                        del v108, v109
                        if v105:
                            v111 = v103 < 3
                            v112 = v111
                        else:
                            v112 = False
                        del v105
                        v113 = v112 == False
                        if v113:
                            v114 = "The read index needs to be in range."
                            assert v112, v114
                            del v114
                        else:
                            pass
                        del v112, v113
                        v115 = US1_2()
                        v77[v103] = v115
                        del v103, v115
                    else:
                        pass
                    v116 = v78[0]
                    v117 = v77[:v116]
                    del v116
                    random.shuffle(v117)
                    v118 = v78[0]
                    v77[:v118] = v117
                    del v117, v118
                    v119 = v78[0]
                    v120 = v119 - 1
                    del v119
                    v121 = 0 <= v120
                    if v121:
                        v122 = v78[0]
                        v123 = v120 < v122
                        del v122
                        v124 = v123
                    else:
                        v124 = False
                    v125 = v124 == False
                    if v125:
                        v126 = "The read index needs to be in range."
                        assert v124, v126
                        del v126
                    else:
                        pass
                    del v124, v125
                    if v121:
                        v127 = v120 < 3
                        v128 = v127
                    else:
                        v128 = False
                    del v121
                    v129 = v128 == False
                    if v129:
                        v130 = "The read index needs to be in range."
                        assert v128, v130
                        del v130
                    else:
                        pass
                    del v128, v129
                    v131 = v77[v120]
                    del v77
                    v132 = v78[0]
                    del v132
                    v78[0] = v120
                    del v78, v120
                    v133 = v3[0]
                    v134 = 1 + v133
                    v3[0] = v134
                    del v134
                    v135 = 0 <= v133
                    if v135:
                        v136 = v3[0]
                        v137 = v133 < v136
                        del v136
                        v138 = v137
                    else:
                        v138 = False
                    v139 = v138 == False
                    if v139:
                        v140 = "The set index needs to be in range."
                        assert v138, v140
                        del v140
                    else:
                        pass
                    del v138, v139
                    if v135:
                        v141 = v133 < 32
                        v142 = v141
                    else:
                        v142 = False
                    del v135
                    v143 = v142 == False
                    if v143:
                        v144 = "The read index needs to be in range."
                        assert v142, v144
                        del v144
                    else:
                        pass
                    del v142, v143
                    v145 = US7_1(v68, v131)
                    v2[v133] = v145
                    del v133, v145
                    match v65:
                        case US6_0(): # None
                            match v131:
                                case US1_0(): # Call
                                    if v66:
                                        v217 = v68 == 0
                                        if v217:
                                            v218 = 1
                                        else:
                                            v218 = 0
                                        del v217
                                        v267 = US5_2(v65, False, v67, v218, v69, v70)
                                    else:
                                        v267 = US5_0(v65, v66, v67, v68, v69, v70)
                                case US1_1(): # Fold
                                    v267 = US5_5(v65, v66, v67, v68, v69, v70)
                                case US1_2(): # Raise
                                    if v102:
                                        v222 = v68 == 0
                                        if v222:
                                            v223 = 1
                                        else:
                                            v223 = 0
                                        del v222
                                        v224 = -1 + v70
                                        v225, v226 = (0, 0)
                                        while method14(v225):
                                            v228 = 0 <= v225
                                            if v228:
                                                v229 = v225 < 2
                                                v230 = v229
                                            else:
                                                v230 = False
                                            del v228
                                            v231 = v230 == False
                                            if v231:
                                                v232 = "The read index needs to be in range."
                                                assert v230, v232
                                                del v232
                                            else:
                                                pass
                                            del v230, v231
                                            v233 = v69[v225]
                                            v234 = v226 >= v233
                                            if v234:
                                                v235 = v226
                                            else:
                                                v235 = v233
                                            del v233, v234
                                            v226 = v235
                                            del v235
                                            v225 += 1 
                                        del v225
                                        v236 = [None] * 2
                                        v237 = 0
                                        while method14(v237):
                                            v239 = 0 <= v237
                                            if v239:
                                                v240 = v237 < 2
                                                v241 = v240
                                            else:
                                                v241 = False
                                            del v239
                                            v242 = v241 == False
                                            if v242:
                                                v243 = "The read index needs to be in range."
                                                assert v241, v243
                                                del v243
                                            else:
                                                pass
                                            del v241, v242
                                            v236[v237] = v226
                                            v237 += 1 
                                        del v226, v237
                                        v244 = [None] * 2
                                        v245 = 0
                                        while method14(v245):
                                            v247 = 0 <= v245
                                            if v247:
                                                v248 = v245 < 2
                                                v249 = v248
                                            else:
                                                v249 = False
                                            v250 = v249 == False
                                            if v250:
                                                v251 = "The read index needs to be in range."
                                                assert v249, v251
                                                del v251
                                            else:
                                                pass
                                            del v249, v250
                                            v252 = v236[v245]
                                            v253 = v245 == v68
                                            if v253:
                                                v254 = v252 + 2
                                                v255 = v254
                                            else:
                                                v255 = v252
                                            del v252, v253
                                            if v247:
                                                v256 = v245 < 2
                                                v257 = v256
                                            else:
                                                v257 = False
                                            del v247
                                            v258 = v257 == False
                                            if v258:
                                                v259 = "The read index needs to be in range."
                                                assert v257, v259
                                                del v259
                                            else:
                                                pass
                                            del v257, v258
                                            v244[v245] = v255
                                            del v255
                                            v245 += 1 
                                        del v236, v245
                                        v267 = US5_2(v65, False, v67, v223, v244, v224)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case US6_1(_): # Some
                            match v131:
                                case US1_0(): # Call
                                    if v66:
                                        v148 = v68 == 0
                                        if v148:
                                            v149 = 1
                                        else:
                                            v149 = 0
                                        del v148
                                        v267 = US5_2(v65, False, v67, v149, v69, v70)
                                    else:
                                        v151, v152 = (0, 0)
                                        while method14(v151):
                                            v154 = 0 <= v151
                                            if v154:
                                                v155 = v151 < 2
                                                v156 = v155
                                            else:
                                                v156 = False
                                            del v154
                                            v157 = v156 == False
                                            if v157:
                                                v158 = "The read index needs to be in range."
                                                assert v156, v158
                                                del v158
                                            else:
                                                pass
                                            del v156, v157
                                            v159 = v69[v151]
                                            v160 = v152 >= v159
                                            if v160:
                                                v161 = v152
                                            else:
                                                v161 = v159
                                            del v159, v160
                                            v152 = v161
                                            del v161
                                            v151 += 1 
                                        del v151
                                        v162 = [None] * 2
                                        v163 = 0
                                        while method14(v163):
                                            v165 = 0 <= v163
                                            if v165:
                                                v166 = v163 < 2
                                                v167 = v166
                                            else:
                                                v167 = False
                                            del v165
                                            v168 = v167 == False
                                            if v168:
                                                v169 = "The read index needs to be in range."
                                                assert v167, v169
                                                del v169
                                            else:
                                                pass
                                            del v167, v168
                                            v162[v163] = v152
                                            v163 += 1 
                                        del v152, v163
                                        v267 = US5_4(v65, v66, v67, v68, v162, v70)
                                case US1_1(): # Fold
                                    v267 = US5_5(v65, v66, v67, v68, v69, v70)
                                case US1_2(): # Raise
                                    if v102:
                                        v172 = v68 == 0
                                        if v172:
                                            v173 = 1
                                        else:
                                            v173 = 0
                                        del v172
                                        v174 = -1 + v70
                                        v175, v176 = (0, 0)
                                        while method14(v175):
                                            v178 = 0 <= v175
                                            if v178:
                                                v179 = v175 < 2
                                                v180 = v179
                                            else:
                                                v180 = False
                                            del v178
                                            v181 = v180 == False
                                            if v181:
                                                v182 = "The read index needs to be in range."
                                                assert v180, v182
                                                del v182
                                            else:
                                                pass
                                            del v180, v181
                                            v183 = v69[v175]
                                            v184 = v176 >= v183
                                            if v184:
                                                v185 = v176
                                            else:
                                                v185 = v183
                                            del v183, v184
                                            v176 = v185
                                            del v185
                                            v175 += 1 
                                        del v175
                                        v186 = [None] * 2
                                        v187 = 0
                                        while method14(v187):
                                            v189 = 0 <= v187
                                            if v189:
                                                v190 = v187 < 2
                                                v191 = v190
                                            else:
                                                v191 = False
                                            del v189
                                            v192 = v191 == False
                                            if v192:
                                                v193 = "The read index needs to be in range."
                                                assert v191, v193
                                                del v193
                                            else:
                                                pass
                                            del v191, v192
                                            v186[v187] = v176
                                            v187 += 1 
                                        del v176, v187
                                        v194 = [None] * 2
                                        v195 = 0
                                        while method14(v195):
                                            v197 = 0 <= v195
                                            if v197:
                                                v198 = v195 < 2
                                                v199 = v198
                                            else:
                                                v199 = False
                                            v200 = v199 == False
                                            if v200:
                                                v201 = "The read index needs to be in range."
                                                assert v199, v201
                                                del v201
                                            else:
                                                pass
                                            del v199, v200
                                            v202 = v186[v195]
                                            v203 = v195 == v68
                                            if v203:
                                                v204 = v202 + 4
                                                v205 = v204
                                            else:
                                                v205 = v202
                                            del v202, v203
                                            if v197:
                                                v206 = v195 < 2
                                                v207 = v206
                                            else:
                                                v207 = False
                                            del v197
                                            v208 = v207 == False
                                            if v208:
                                                v209 = "The read index needs to be in range."
                                                assert v207, v209
                                                del v209
                                            else:
                                                pass
                                            del v207, v208
                                            v194[v195] = v205
                                            del v205
                                            v195 += 1 
                                        del v186, v195
                                        v267 = US5_2(v65, False, v67, v173, v194, v174)
                                    else:
                                        raise Exception("Invalid action. The number of raises left is not positive.")
                                case _:
                                    raise Exception('Pattern matching miss.')
                        case _:
                            raise Exception('Pattern matching miss.')
                    del v65, v66, v67, v68, v69, v70, v102, v131
                    return method13(v0, v1, v2, v3, v4, v267)
                case US2_1(): # Human
                    del v0, v1, v2, v3, v4, v65, v66, v67, v68, v69, v70, v76
                    return v5
                case _:
                    raise Exception('Pattern matching miss.')
        case US5_3(v271, v272, v273, v274, v275, v276, v277): # RoundWithAction
            del v5
            v278 = v3[0]
            v279 = 1 + v278
            v3[0] = v279
            del v279
            v280 = 0 <= v278
            if v280:
                v281 = v3[0]
                v282 = v278 < v281
                del v281
                v283 = v282
            else:
                v283 = False
            v284 = v283 == False
            if v284:
                v285 = "The set index needs to be in range."
                assert v283, v285
                del v285
            else:
                pass
            del v283, v284
            if v280:
                v286 = v278 < 32
                v287 = v286
            else:
                v287 = False
            del v280
            v288 = v287 == False
            if v288:
                v289 = "The read index needs to be in range."
                assert v287, v289
                del v289
            else:
                pass
            del v287, v288
            v290 = US7_1(v274, v277)
            v2[v278] = v290
            del v278, v290
            match v271:
                case US6_0(): # None
                    match v277:
                        case US1_0(): # Call
                            if v272:
                                v363 = v274 == 0
                                if v363:
                                    v364 = 1
                                else:
                                    v364 = 0
                                del v363
                                v414 = US5_2(v271, False, v273, v364, v275, v276)
                            else:
                                v414 = US5_0(v271, v272, v273, v274, v275, v276)
                        case US1_1(): # Fold
                            v414 = US5_5(v271, v272, v273, v274, v275, v276)
                        case US1_2(): # Raise
                            v368 = v276 > 0
                            if v368:
                                del v368
                                v369 = v274 == 0
                                if v369:
                                    v370 = 1
                                else:
                                    v370 = 0
                                del v369
                                v371 = -1 + v276
                                v372, v373 = (0, 0)
                                while method14(v372):
                                    v375 = 0 <= v372
                                    if v375:
                                        v376 = v372 < 2
                                        v377 = v376
                                    else:
                                        v377 = False
                                    del v375
                                    v378 = v377 == False
                                    if v378:
                                        v379 = "The read index needs to be in range."
                                        assert v377, v379
                                        del v379
                                    else:
                                        pass
                                    del v377, v378
                                    v380 = v275[v372]
                                    v381 = v373 >= v380
                                    if v381:
                                        v382 = v373
                                    else:
                                        v382 = v380
                                    del v380, v381
                                    v373 = v382
                                    del v382
                                    v372 += 1 
                                del v372
                                v383 = [None] * 2
                                v384 = 0
                                while method14(v384):
                                    v386 = 0 <= v384
                                    if v386:
                                        v387 = v384 < 2
                                        v388 = v387
                                    else:
                                        v388 = False
                                    del v386
                                    v389 = v388 == False
                                    if v389:
                                        v390 = "The read index needs to be in range."
                                        assert v388, v390
                                        del v390
                                    else:
                                        pass
                                    del v388, v389
                                    v383[v384] = v373
                                    v384 += 1 
                                del v373, v384
                                v391 = [None] * 2
                                v392 = 0
                                while method14(v392):
                                    v394 = 0 <= v392
                                    if v394:
                                        v395 = v392 < 2
                                        v396 = v395
                                    else:
                                        v396 = False
                                    v397 = v396 == False
                                    if v397:
                                        v398 = "The read index needs to be in range."
                                        assert v396, v398
                                        del v398
                                    else:
                                        pass
                                    del v396, v397
                                    v399 = v383[v392]
                                    v400 = v392 == v274
                                    if v400:
                                        v401 = v399 + 2
                                        v402 = v401
                                    else:
                                        v402 = v399
                                    del v399, v400
                                    if v394:
                                        v403 = v392 < 2
                                        v404 = v403
                                    else:
                                        v404 = False
                                    del v394
                                    v405 = v404 == False
                                    if v405:
                                        v406 = "The read index needs to be in range."
                                        assert v404, v406
                                        del v406
                                    else:
                                        pass
                                    del v404, v405
                                    v391[v392] = v402
                                    del v402
                                    v392 += 1 
                                del v383, v392
                                v414 = US5_2(v271, False, v273, v370, v391, v371)
                            else:
                                del v368
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case _:
                            raise Exception('Pattern matching miss.')
                case US6_1(_): # Some
                    match v277:
                        case US1_0(): # Call
                            if v272:
                                v293 = v274 == 0
                                if v293:
                                    v294 = 1
                                else:
                                    v294 = 0
                                del v293
                                v414 = US5_2(v271, False, v273, v294, v275, v276)
                            else:
                                v296, v297 = (0, 0)
                                while method14(v296):
                                    v299 = 0 <= v296
                                    if v299:
                                        v300 = v296 < 2
                                        v301 = v300
                                    else:
                                        v301 = False
                                    del v299
                                    v302 = v301 == False
                                    if v302:
                                        v303 = "The read index needs to be in range."
                                        assert v301, v303
                                        del v303
                                    else:
                                        pass
                                    del v301, v302
                                    v304 = v275[v296]
                                    v305 = v297 >= v304
                                    if v305:
                                        v306 = v297
                                    else:
                                        v306 = v304
                                    del v304, v305
                                    v297 = v306
                                    del v306
                                    v296 += 1 
                                del v296
                                v307 = [None] * 2
                                v308 = 0
                                while method14(v308):
                                    v310 = 0 <= v308
                                    if v310:
                                        v311 = v308 < 2
                                        v312 = v311
                                    else:
                                        v312 = False
                                    del v310
                                    v313 = v312 == False
                                    if v313:
                                        v314 = "The read index needs to be in range."
                                        assert v312, v314
                                        del v314
                                    else:
                                        pass
                                    del v312, v313
                                    v307[v308] = v297
                                    v308 += 1 
                                del v297, v308
                                v414 = US5_4(v271, v272, v273, v274, v307, v276)
                        case US1_1(): # Fold
                            v414 = US5_5(v271, v272, v273, v274, v275, v276)
                        case US1_2(): # Raise
                            v317 = v276 > 0
                            if v317:
                                del v317
                                v318 = v274 == 0
                                if v318:
                                    v319 = 1
                                else:
                                    v319 = 0
                                del v318
                                v320 = -1 + v276
                                v321, v322 = (0, 0)
                                while method14(v321):
                                    v324 = 0 <= v321
                                    if v324:
                                        v325 = v321 < 2
                                        v326 = v325
                                    else:
                                        v326 = False
                                    del v324
                                    v327 = v326 == False
                                    if v327:
                                        v328 = "The read index needs to be in range."
                                        assert v326, v328
                                        del v328
                                    else:
                                        pass
                                    del v326, v327
                                    v329 = v275[v321]
                                    v330 = v322 >= v329
                                    if v330:
                                        v331 = v322
                                    else:
                                        v331 = v329
                                    del v329, v330
                                    v322 = v331
                                    del v331
                                    v321 += 1 
                                del v321
                                v332 = [None] * 2
                                v333 = 0
                                while method14(v333):
                                    v335 = 0 <= v333
                                    if v335:
                                        v336 = v333 < 2
                                        v337 = v336
                                    else:
                                        v337 = False
                                    del v335
                                    v338 = v337 == False
                                    if v338:
                                        v339 = "The read index needs to be in range."
                                        assert v337, v339
                                        del v339
                                    else:
                                        pass
                                    del v337, v338
                                    v332[v333] = v322
                                    v333 += 1 
                                del v322, v333
                                v340 = [None] * 2
                                v341 = 0
                                while method14(v341):
                                    v343 = 0 <= v341
                                    if v343:
                                        v344 = v341 < 2
                                        v345 = v344
                                    else:
                                        v345 = False
                                    v346 = v345 == False
                                    if v346:
                                        v347 = "The read index needs to be in range."
                                        assert v345, v347
                                        del v347
                                    else:
                                        pass
                                    del v345, v346
                                    v348 = v332[v341]
                                    v349 = v341 == v274
                                    if v349:
                                        v350 = v348 + 4
                                        v351 = v350
                                    else:
                                        v351 = v348
                                    del v348, v349
                                    if v343:
                                        v352 = v341 < 2
                                        v353 = v352
                                    else:
                                        v353 = False
                                    del v343
                                    v354 = v353 == False
                                    if v354:
                                        v355 = "The read index needs to be in range."
                                        assert v353, v355
                                        del v355
                                    else:
                                        pass
                                    del v353, v354
                                    v340[v341] = v351
                                    del v351
                                    v341 += 1 
                                del v332, v341
                                v414 = US5_2(v271, False, v273, v319, v340, v320)
                            else:
                                del v317
                                raise Exception("Invalid action. The number of raises left is not positive.")
                        case _:
                            raise Exception('Pattern matching miss.')
                case _:
                    raise Exception('Pattern matching miss.')
            del v271, v272, v273, v274, v275, v276, v277
            return method13(v0, v1, v2, v3, v4, v414)
        case US5_4(v33, v34, v35, v36, v37, v38): # TerminalCall
            del v0, v1, v4
            v39 = 0 <= v36
            if v39:
                v40 = v36 < 2
                v41 = v40
            else:
                v41 = False
            del v39
            v42 = v41 == False
            if v42:
                v43 = "The read index needs to be in range."
                assert v41, v43
                del v43
            else:
                pass
            del v41, v42
            v44 = v37[v36]
            v45 = method15(v33, v34, v35, v36, v37, v38)
            del v33, v34, v36, v37, v38
            match v45:
                case US9_0(): # Eq
                    v50, v51 = 0, -1
                case US9_1(): # Gt
                    v50, v51 = v44, 0
                case US9_2(): # Lt
                    v50, v51 = v44, 1
                case _:
                    raise Exception('Pattern matching miss.')
            del v44, v45
            v52 = v3[0]
            v53 = 1 + v52
            v3[0] = v53
            del v53
            v54 = 0 <= v52
            if v54:
                v55 = v3[0]
                v56 = v52 < v55
                del v55
                v57 = v56
            else:
                v57 = False
            del v3
            v58 = v57 == False
            if v58:
                v59 = "The set index needs to be in range."
                assert v57, v59
                del v59
            else:
                pass
            del v57, v58
            if v54:
                v60 = v52 < 32
                v61 = v60
            else:
                v61 = False
            del v54
            v62 = v61 == False
            if v62:
                v63 = "The read index needs to be in range."
                assert v61, v63
                del v63
            else:
                pass
            del v61, v62
            v64 = US7_3(v35, v50, v51)
            del v35, v50, v51
            v2[v52] = v64
            del v2, v52, v64
            return v5
        case US5_5(_, _, v8, v9, v10, _): # TerminalFold
            del v0, v1, v4
            v12 = 0 <= v9
            if v12:
                v13 = v9 < 2
                v14 = v13
            else:
                v14 = False
            del v12
            v15 = v14 == False
            if v15:
                v16 = "The read index needs to be in range."
                assert v14, v16
                del v16
            else:
                pass
            del v14, v15
            v17 = v10[v9]
            del v10
            v18 = v9 == 0
            del v9
            if v18:
                v19 = 1
            else:
                v19 = 0
            del v18
            v20 = v3[0]
            v21 = 1 + v20
            v3[0] = v21
            del v21
            v22 = 0 <= v20
            if v22:
                v23 = v3[0]
                v24 = v20 < v23
                del v23
                v25 = v24
            else:
                v25 = False
            del v3
            v26 = v25 == False
            if v26:
                v27 = "The set index needs to be in range."
                assert v25, v27
                del v27
            else:
                pass
            del v25, v26
            if v22:
                v28 = v20 < 32
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
            v32 = US7_3(v8, v17, v19)
            del v8, v17, v19
            v2[v20] = v32
            del v2, v20, v32
            return v5
        case _:
            raise Exception('Pattern matching miss.')
def method12(v0 : US3, v1 : list[US7], v2 : list, v3 : list[US2], v4 : US8, v5 : list[US4], v6 : list, v7 : US5) -> Tuple[US3, list[US7], list, list[US2], US8]:
    del v0, v4
    v8 = method13(v5, v6, v1, v2, v3, v7)
    del v7
    match v8:
        case US5_2(v9, v10, v11, v12, v13, v14): # Round
            v15 = US3_1(v5, v6, v8)
            del v5, v6, v8
            v16 = US8_2(v9, v10, v11, v12, v13, v14)
            del v9, v10, v11, v12, v13, v14
            return v15, v1, v2, v3, v16
        case US5_4(v17, v18, v19, v20, v21, v22): # TerminalCall
            del v5, v6, v8
            v23 = US3_0()
            v24 = US8_1(v17, v18, v19, v20, v21, v22)
            del v17, v18, v19, v20, v21, v22
            return v23, v1, v2, v3, v24
        case US5_5(v25, v26, v27, v28, v29, v30): # TerminalFold
            del v5, v6, v8
            v31 = US3_0()
            v32 = US8_1(v25, v26, v27, v28, v29, v30)
            del v25, v26, v27, v28, v29, v30
            return v31, v1, v2, v3, v32
        case _:
            del v1, v2, v3, v5, v6, v8
            raise Exception("Unexpected node received in play_loop.")
def method21(v0 : US4) -> object:
    match v0:
        case US4_0(): # Jack
            del v0
            v1 = []
            v2 = "Jack"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US4_1(): # King
            del v0
            v4 = []
            v5 = "King"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US4_2(): # Queen
            del v0
            v7 = []
            v8 = "Queen"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case _:
            raise Exception('Pattern matching miss.')
def method23(v0 : US6) -> object:
    match v0:
        case US6_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4): # Some
            del v0
            v5 = method21(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
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
def method22(v0 : US5) -> object:
    match v0:
        case US5_0(v1, v2, v3, v4, v5, v6): # ChanceCommunityCard
            del v0
            v7 = method23(v1)
            del v1
            v8 = v2
            del v2
            v9 = []
            v10 = 0
            while method14(v10):
                v12 = 0 <= v10
                if v12:
                    v13 = v10 < 2
                    v14 = v13
                else:
                    v14 = False
                del v12
                v15 = v14 == False
                if v15:
                    v16 = "The read index needs to be in range."
                    assert v14, v16
                    del v16
                else:
                    pass
                del v14, v15
                v17 = v3[v10]
                v18 = method21(v17)
                del v17
                v9.append(v18)
                del v18
                v10 += 1 
            del v3, v10
            v19 = v4
            del v4
            v20 = []
            v21 = 0
            while method14(v21):
                v23 = 0 <= v21
                if v23:
                    v24 = v21 < 2
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
                v28 = v5[v21]
                v29 = v28
                del v28
                v20.append(v29)
                del v29
                v21 += 1 
            del v5, v21
            v30 = v6
            del v6
            v31 = {'community_card': v7, 'is_button_s_first_move': v8, 'pl_card': v9, 'player_turn': v19, 'pot': v20, 'raises_left': v30}
            del v7, v8, v9, v19, v20, v30
            v32 = "ChanceCommunityCard"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US5_1(): # ChanceInit
            del v0
            v34 = []
            v35 = "ChanceInit"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US5_2(v37, v38, v39, v40, v41, v42): # Round
            del v0
            v43 = method23(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method14(v46):
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
                v54 = method21(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method14(v57):
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
            v68 = "Round"
            v69 = [v68,v67]
            del v67, v68
            return v69
        case US5_3(v70, v71, v72, v73, v74, v75, v76): # RoundWithAction
            del v0
            v77 = []
            v78 = method23(v70)
            del v70
            v79 = v71
            del v71
            v80 = []
            v81 = 0
            while method14(v81):
                v83 = 0 <= v81
                if v83:
                    v84 = v81 < 2
                    v85 = v84
                else:
                    v85 = False
                del v83
                v86 = v85 == False
                if v86:
                    v87 = "The read index needs to be in range."
                    assert v85, v87
                    del v87
                else:
                    pass
                del v85, v86
                v88 = v72[v81]
                v89 = method21(v88)
                del v88
                v80.append(v89)
                del v89
                v81 += 1 
            del v72, v81
            v90 = v73
            del v73
            v91 = []
            v92 = 0
            while method14(v92):
                v94 = 0 <= v92
                if v94:
                    v95 = v92 < 2
                    v96 = v95
                else:
                    v96 = False
                del v94
                v97 = v96 == False
                if v97:
                    v98 = "The read index needs to be in range."
                    assert v96, v98
                    del v98
                else:
                    pass
                del v96, v97
                v99 = v74[v92]
                v100 = v99
                del v99
                v91.append(v100)
                del v100
                v92 += 1 
            del v74, v92
            v101 = v75
            del v75
            v102 = {'community_card': v78, 'is_button_s_first_move': v79, 'pl_card': v80, 'player_turn': v90, 'pot': v91, 'raises_left': v101}
            del v78, v79, v80, v90, v91, v101
            v77.append(v102)
            del v102
            v103 = method24(v76)
            del v76
            v77.append(v103)
            del v103
            v104 = v77
            del v77
            v105 = "RoundWithAction"
            v106 = [v105,v104]
            del v104, v105
            return v106
        case US5_4(v107, v108, v109, v110, v111, v112): # TerminalCall
            del v0
            v113 = method23(v107)
            del v107
            v114 = v108
            del v108
            v115 = []
            v116 = 0
            while method14(v116):
                v118 = 0 <= v116
                if v118:
                    v119 = v116 < 2
                    v120 = v119
                else:
                    v120 = False
                del v118
                v121 = v120 == False
                if v121:
                    v122 = "The read index needs to be in range."
                    assert v120, v122
                    del v122
                else:
                    pass
                del v120, v121
                v123 = v109[v116]
                v124 = method21(v123)
                del v123
                v115.append(v124)
                del v124
                v116 += 1 
            del v109, v116
            v125 = v110
            del v110
            v126 = []
            v127 = 0
            while method14(v127):
                v129 = 0 <= v127
                if v129:
                    v130 = v127 < 2
                    v131 = v130
                else:
                    v131 = False
                del v129
                v132 = v131 == False
                if v132:
                    v133 = "The read index needs to be in range."
                    assert v131, v133
                    del v133
                else:
                    pass
                del v131, v132
                v134 = v111[v127]
                v135 = v134
                del v134
                v126.append(v135)
                del v135
                v127 += 1 
            del v111, v127
            v136 = v112
            del v112
            v137 = {'community_card': v113, 'is_button_s_first_move': v114, 'pl_card': v115, 'player_turn': v125, 'pot': v126, 'raises_left': v136}
            del v113, v114, v115, v125, v126, v136
            v138 = "TerminalCall"
            v139 = [v138,v137]
            del v137, v138
            return v139
        case US5_5(v140, v141, v142, v143, v144, v145): # TerminalFold
            del v0
            v146 = method23(v140)
            del v140
            v147 = v141
            del v141
            v148 = []
            v149 = 0
            while method14(v149):
                v151 = 0 <= v149
                if v151:
                    v152 = v149 < 2
                    v153 = v152
                else:
                    v153 = False
                del v151
                v154 = v153 == False
                if v154:
                    v155 = "The read index needs to be in range."
                    assert v153, v155
                    del v155
                else:
                    pass
                del v153, v154
                v156 = v142[v149]
                v157 = method21(v156)
                del v156
                v148.append(v157)
                del v157
                v149 += 1 
            del v142, v149
            v158 = v143
            del v143
            v159 = []
            v160 = 0
            while method14(v160):
                v162 = 0 <= v160
                if v162:
                    v163 = v160 < 2
                    v164 = v163
                else:
                    v164 = False
                del v162
                v165 = v164 == False
                if v165:
                    v166 = "The read index needs to be in range."
                    assert v164, v166
                    del v166
                else:
                    pass
                del v164, v165
                v167 = v144[v160]
                v168 = v167
                del v167
                v159.append(v168)
                del v168
                v160 += 1 
            del v144, v160
            v169 = v145
            del v145
            v170 = {'community_card': v146, 'is_button_s_first_move': v147, 'pl_card': v148, 'player_turn': v158, 'pot': v159, 'raises_left': v169}
            del v146, v147, v148, v158, v159, v169
            v171 = "TerminalFold"
            v172 = [v171,v170]
            del v170, v171
            return v172
        case _:
            raise Exception('Pattern matching miss.')
def method20(v0 : US3) -> object:
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
            v7 = []
            v8 = v5[0]
            v9 = 0
            while method3(v8, v9):
                v11 = 0 <= v9
                if v11:
                    v12 = v5[0]
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
                    v17 = v9 < 6
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
                v21 = v4[v9]
                v22 = method21(v21)
                del v21
                v7.append(v22)
                del v22
                v9 += 1 
            del v4, v5, v8, v9
            v23 = method22(v6)
            del v6
            v24 = {'deck': v7, 'game': v23}
            del v7, v23
            v25 = "Some"
            v26 = [v25,v24]
            del v24, v25
            return v26
        case _:
            raise Exception('Pattern matching miss.')
def method25(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardIs
            del v0
            v2 = method21(v1)
            del v1
            v3 = "CommunityCardIs"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # PlayerAction
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
        case US7_2(v13, v14): # PlayerGotCard
            del v0
            v15 = []
            v16 = v13
            del v13
            v15.append(v16)
            del v16
            v17 = method21(v14)
            del v14
            v15.append(v17)
            del v17
            v18 = v15
            del v15
            v19 = "PlayerGotCard"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US7_3(v21, v22, v23): # Showdown
            del v0
            v24 = []
            v25 = 0
            while method14(v25):
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
                v33 = method21(v32)
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
def method26(v0 : US2) -> object:
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
def method27(v0 : US8) -> object:
    match v0:
        case US8_0(): # GameNotStarted
            del v0
            v1 = []
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US8_1(v4, v5, v6, v7, v8, v9): # GameOver
            del v0
            v10 = method23(v4)
            del v4
            v11 = v5
            del v5
            v12 = []
            v13 = 0
            while method14(v13):
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
                v21 = method21(v20)
                del v20
                v12.append(v21)
                del v21
                v13 += 1 
            del v6, v13
            v22 = v7
            del v7
            v23 = []
            v24 = 0
            while method14(v24):
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
        case US8_2(v37, v38, v39, v40, v41, v42): # WaitingForActionFromPlayerId
            del v0
            v43 = method23(v37)
            del v37
            v44 = v38
            del v38
            v45 = []
            v46 = 0
            while method14(v46):
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
                v54 = method21(v53)
                del v53
                v45.append(v54)
                del v54
                v46 += 1 
            del v39, v46
            v55 = v40
            del v40
            v56 = []
            v57 = 0
            while method14(v57):
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
def method19(v0 : US3, v1 : list[US7], v2 : list, v3 : list[US2], v4 : US8) -> object:
    v5 = method20(v0)
    del v0
    v6 = []
    v7 = v2[0]
    v8 = 0
    while method3(v7, v8):
        v10 = 0 <= v8
        if v10:
            v11 = v2[0]
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
            v16 = v8 < 32
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
        v20 = v1[v8]
        v21 = method25(v20)
        del v20
        v6.append(v21)
        del v21
        v8 += 1 
    del v1, v2, v7, v8
    v22 = []
    v23 = 0
    while method14(v23):
        v25 = 0 <= v23
        if v25:
            v26 = v23 < 2
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
        v30 = v3[v23]
        v31 = method26(v30)
        del v30
        v22.append(v31)
        del v31
        v23 += 1 
    del v3, v23
    v32 = method27(v4)
    del v4
    v33 = {'messages': v6, 'pl_type': v22, 'ui_game_state': v32}
    del v6, v22, v32
    v34 = {'game_state': v5, 'ui_state': v33}
    del v5, v33
    return v34
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("Leduc_Game",['event_loop_cpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
