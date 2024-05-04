kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import random
class US0_0(NamedTuple): # Paper
    tag = 0
class US0_1(NamedTuple): # Rock
    tag = 1
class US0_2(NamedTuple): # Scissors
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US2_0(NamedTuple): # Computer
    tag = 0
class US2_1(NamedTuple): # Human
    tag = 1
US2 = Union[US2_0, US2_1]
class US1_0(NamedTuple): # ActionSelected
    v0 : US0
    tag = 0
class US1_1(NamedTuple): # PlayerChanged
    v0 : US2
    v1 : US2
    tag = 1
class US1_2(NamedTuple): # StartGame
    tag = 2
US1 = Union[US1_0, US1_1, US1_2]
class US3_0(NamedTuple): # GameNotStarted
    tag = 0
class US3_1(NamedTuple): # GameOver
    v0 : US0
    v1 : US0
    tag = 1
class US3_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : i32
    tag = 2
US3 = Union[US3_0, US3_1, US3_2]
class US4_0(NamedTuple): # GameStarted
    tag = 0
class US4_1(NamedTuple): # ShowdownResult
    v0 : US0
    v1 : US0
    tag = 1
class US4_2(NamedTuple): # WaitingToStart
    tag = 2
US4 = Union[US4_0, US4_1, US4_2]
class US5_0(NamedTuple): # None
    tag = 0
class US5_1(NamedTuple): # Some
    v0 : US0
    tag = 1
US5 = Union[US5_0, US5_1]
def method1(v0 : US5, v1 : array<US0,2>, v2 : i32 &, v3 : US3, v4 : US4, v5 : US2, v6 : US2) -> Tuple[array<US0,2>, i32 &, US3, US4, US2, US2]:
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
                v11 = i32 & \v = v2
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
                        v21 = US0_1()
                        v22 = US0_0()
                        v23 = US0_2()
                        v24 = random.choice([v21, v22, v23])
                        del v21, v22, v23
                        v25 = v9 + 1
                        del v9
                        v26 = i32 & \v = v2
                        v27 = 1 + v26
                        v2 = v27
                        del v27
                        v28 = v26 < 2
                        v29 = v28 == False
                        if v29:
                            v30 = "Cannot add beyond the maximum length of the static array."
                            assert v28, v30
                            del v30
                        else:
                            pass
                        del v28, v29
                        v31 = 0 <= v26
                        if v31:
                            v32 = i32 & \v = v2
                            v33 = v26 < v32
                            del v32
                            v34 = v33
                        else:
                            v34 = False
                        del v31
                        v35 = v34 == False
                        if v35:
                            v36 = "The set index needs to be in range."
                            assert v34, v36
                            del v36
                        else:
                            pass
                        del v34, v35
                        v1.v[v26] = v24
                        del v24, v26
                        v37 = US5_0()
                        v38 = US3_2(v25)
                        del v25
                        return method1(v37, v1, v2, v38, v4, v5, v6)
                    case US2_1(): # Human
                        del v16
                        match v0:
                            case US5_0(): # None
                                del v0, v9
                                return v1, v2, v3, v4, v5, v6
                            case US5_1(v45): # Some
                                del v0, v3
                                v46 = v9 + 1
                                del v9
                                v47 = i32 & \v = v2
                                v48 = 1 + v47
                                v2 = v48
                                del v48
                                v49 = v47 < 2
                                v50 = v49 == False
                                if v50:
                                    v51 = "Cannot add beyond the maximum length of the static array."
                                    assert v49, v51
                                    del v51
                                else:
                                    pass
                                del v49, v50
                                v52 = 0 <= v47
                                if v52:
                                    v53 = i32 & \v = v2
                                    v54 = v47 < v53
                                    del v53
                                    v55 = v54
                                else:
                                    v55 = False
                                del v52
                                v56 = v55 == False
                                if v56:
                                    v57 = "The set index needs to be in range."
                                    assert v55, v57
                                    del v57
                                else:
                                    pass
                                del v55, v56
                                v1.v[v47] = v45
                                del v45, v47
                                v58 = US5_0()
                                v59 = US3_2(v46)
                                del v46
                                return method1(v58, v1, v2, v59, v4, v5, v6)
            else:
                del v0, v3, v4, v9, v10
                v90 = i32 & \v = v2
                v91 = 0 < v90
                del v90
                v92 = v91 == False
                if v92:
                    v93 = "The read index needs to be in range."
                    assert v91, v93
                    del v93
                else:
                    pass
                del v91, v92
                v94 = v1.v[0]
                v95 = i32 & \v = v2
                v96 = 1 < v95
                del v95
                v97 = v96 == False
                if v97:
                    v98 = "The read index needs to be in range."
                    assert v96, v98
                    del v98
                else:
                    pass
                del v96, v97
                v99 = v1.v[1]
                v100 = i32 & \v = v2
                del v100
                v2 = 0
                v101 = US3_1(v94, v99)
                v102 = US4_1(v94, v99)
                del v94, v99
                return v1, v2, v101, v102, v5, v6
def method0(v0 : US1, v1 : array<US0,2>, v2 : i32 &, v3 : US3, v4 : US4, v5 : US2, v6 : US2) -> Tuple[array<US0,2>, i32 &, US3, US4, US2, US2]:
    match v0:
        case US1_0(v28): # ActionSelected
            del v0
            v29 = US5_1(v28)
            del v28
            return method1(v29, v1, v2, v3, v4, v5, v6)
        case US1_1(v19, v20): # PlayerChanged
            del v0, v5, v6
            v21 = US5_0()
            return method1(v21, v1, v2, v3, v4, v19, v20)
        case US1_2(): # StartGame
            del v0, v1, v2, v3, v4
            v7 = array<US0,2> \v
            v8 = i32 & \v = 0
            v9 = US5_0()
            v10 = 0
            v11 = US3_2(v10)
            del v10
            v12 = US4_0()
            return method1(v9, v7, v8, v11, v12, v5, v6)
def main():
    v0 = array<US0,2> \v
    v1 = i32 & \v = 0
    v2 = US1_2()
    v3 = US3_0()
    v4 = US4_2()
    v5 = US2_1()
    v6 = US2_0()
    return method0(v2, v0, v1, v3, v4, v5, v6)

if __name__ == '__main__': print(main())
