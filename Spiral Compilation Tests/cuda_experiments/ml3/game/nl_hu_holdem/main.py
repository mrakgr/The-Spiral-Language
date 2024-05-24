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
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import collections
class US1_0(NamedTuple): # A_Call
    tag = 0
class US1_1(NamedTuple): # A_Fold
    tag = 1
class US1_2(NamedTuple): # A_Raise
    v0 : i32
    tag = 2
US1 = Union[US1_0, US1_1, US1_2]
class US0_0(NamedTuple): # ActionSelected
    v0 : US1
    tag = 0
class US0_1(NamedTuple): # PlayerChanged
    v0 : static_array
    tag = 1
class US0_2(NamedTuple): # StartGame
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
class US2_0(NamedTuple): # Computer
    tag = 0
class US2_1(NamedTuple): # Human
    tag = 1
US2 = Union[US2_0, US2_1]
class US5_0(NamedTuple): # Flop
    v0 : static_array
    tag = 0
class US5_1(NamedTuple): # Preflop
    tag = 1
class US5_2(NamedTuple): # River
    v0 : static_array
    tag = 2
class US5_3(NamedTuple): # Turn
    v0 : static_array
    tag = 3
US5 = Union[US5_0, US5_1, US5_2, US5_3]
class US4_0(NamedTuple): # G_Flop
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 0
class US4_1(NamedTuple): # G_Fold
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 1
class US4_2(NamedTuple): # G_Preflop
    tag = 2
class US4_3(NamedTuple): # G_River
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 3
class US4_4(NamedTuple): # G_Round
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 4
class US4_5(NamedTuple): # G_Round'
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    v7 : US1
    tag = 5
class US4_6(NamedTuple): # G_Showdown
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 6
class US4_7(NamedTuple): # G_Turn
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 7
US4 = Union[US4_0, US4_1, US4_2, US4_3, US4_4, US4_5, US4_6, US4_7]
class US3_0(NamedTuple): # None
    tag = 0
class US3_1(NamedTuple): # Some
    v0 : US4
    tag = 1
US3 = Union[US3_0, US3_1]
class US6_0(NamedTuple): # GameNotStarted
    tag = 0
class US6_1(NamedTuple): # GameOver
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 1
class US6_2(NamedTuple): # WaitingForActionFromPlayerId
    v0 : i32
    v1 : bool
    v2 : static_array
    v3 : i32
    v4 : static_array
    v5 : static_array
    v6 : US5
    tag = 2
US6 = Union[US6_0, US6_1, US6_2]
class US7_0(NamedTuple): # CommunityCardsAre
    v0 : static_array_list
    tag = 0
class US7_1(NamedTuple): # Fold
    v0 : i32
    v1 : i32
    tag = 1
class US7_2(NamedTuple): # PlayerAction
    v0 : i32
    v1 : US1
    tag = 2
class US7_3(NamedTuple): # PlayerGotCards
    v0 : i32
    v1 : static_array
    tag = 3
class US7_4(NamedTuple): # Showdown
    v0 : i32
    v1 : static_array
    v2 : i32
    tag = 4
US7 = Union[US7_0, US7_1, US7_2, US7_3, US7_4]
class US8_0(NamedTuple): # Ace
    tag = 0
class US8_1(NamedTuple): # Eight
    tag = 1
class US8_2(NamedTuple): # Five
    tag = 2
class US8_3(NamedTuple): # Four
    tag = 3
class US8_4(NamedTuple): # Jack
    tag = 4
class US8_5(NamedTuple): # King
    tag = 5
class US8_6(NamedTuple): # Nine
    tag = 6
class US8_7(NamedTuple): # Queen
    tag = 7
class US8_8(NamedTuple): # Seven
    tag = 8
class US8_9(NamedTuple): # Six
    tag = 9
class US8_10(NamedTuple): # Ten
    tag = 10
class US8_11(NamedTuple): # Three
    tag = 11
class US8_12(NamedTuple): # Two
    tag = 12
US8 = Union[US8_0, US8_1, US8_2, US8_3, US8_4, US8_5, US8_6, US8_7, US8_8, US8_9, US8_10, US8_11, US8_12]
class US9_0(NamedTuple): # Clubs
    tag = 0
class US9_1(NamedTuple): # Diamonds
    tag = 1
class US9_2(NamedTuple): # Hearts
    tag = 2
class US9_3(NamedTuple): # Spades
    tag = 3
US9 = Union[US9_0, US9_1, US9_2, US9_3]
class US10_0(NamedTuple): # Flush
    v0 : static_array
    tag = 0
class US10_1(NamedTuple): # Full_House
    v0 : static_array
    tag = 1
class US10_2(NamedTuple): # High_Card
    v0 : static_array
    tag = 2
class US10_3(NamedTuple): # Pair
    v0 : static_array
    tag = 3
class US10_4(NamedTuple): # Quads
    v0 : static_array
    tag = 4
class US10_5(NamedTuple): # Straight
    v0 : static_array
    tag = 5
class US10_6(NamedTuple): # Straight_Flush
    v0 : static_array
    tag = 6
class US10_7(NamedTuple): # Triple
    v0 : static_array
    tag = 7
class US10_8(NamedTuple): # Two_Pair
    v0 : static_array
    tag = 8
US10 = Union[US10_0, US10_1, US10_2, US10_3, US10_4, US10_5, US10_6, US10_7, US10_8]
def Closure0():
    def inner(v0 : object, v1 : object) -> None:
        v2 = cp.empty(192,dtype=cp.uint8)
        v3 = cp.empty(266240,dtype=cp.uint8)
        v4 = "Deserializing the message and game_state from JSON."
        print(v4, end="")
        del v4
        print()
        v5 = v0, v0
        v6 = v1, v1
        v7 = v5, v5
        del v5
        v8 = v6, v6
        del v6
        v9 = v7, v7
        del v7
        v10 = v8, v8
        del v8
        v11 = v9, v9
        del v9
        v12 = v10, v10
        del v10
        v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28 = method0(v11)
        del v11
        v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108 = method12(v12)
        del v12
        v109 = "Serializing the message and game_state to the GPU."
        print(v109, end="")
        del v109
        print()
        method48(v2, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28)
        del v2, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28
        method163(v3, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108)
        del v3, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v74, v75, v76, v77, v78, v79, v80, v81, v82, v83, v84, v85, v86, v87, v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98, v99, v100, v101, v102, v103, v104, v105, v106, v107, v108
        v110 = "Done serializing the gpu state"
        print(v110, end="")
        del v110
        print()
        return 
    return inner
def Closure1():
    def inner() -> object:
        v0 = static_array(2)
        v1 = US2_0()
        v0[0] = v1
        del v1
        v2 = US2_1()
        v0[1] = v2
        del v2
        v3 = static_array_list(128)
        v4 = 4503599627370495
        v5 = US3_0()
        v6 = US6_0()
        return method577(v4, v3, v5, v0, v6)
    return inner
def method7(v0 : object) -> None:
    assert v0 == [], f'Expected an unit type. Got: {v0}'
    del v0
    return 
def method8(v0 : object) -> i32:
    assert isinstance(v0,i32), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method6(v0 : object) -> US1:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "A_Call" == v1
    if v4:
        del v1, v4
        method7(v2)
        del v2
        return US1_0()
    else:
        del v4
        v7 = "A_Fold" == v1
        if v7:
            del v1, v7
            method7(v2)
            del v2
            return US1_1()
        else:
            del v7
            v10 = "A_Raise" == v1
            if v10:
                del v1, v10
                v11 = method8(v2)
                del v2
                return US1_2(v11)
            else:
                del v2, v10
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method10(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method11(v0 : object) -> US2:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Computer" == v1
    if v4:
        del v1, v4
        method7(v2)
        del v2
        return US2_0()
    else:
        del v4
        v7 = "Human" == v1
        if v7:
            del v1, v7
            method7(v2)
            del v2
            return US2_1()
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method9(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9 = method11(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method5(v0 : object) -> US0:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "ActionSelected" == v1
    if v4:
        del v1, v4
        v5 = method6(v2)
        del v2
        return US0_0(v5)
    else:
        del v4
        v8 = "PlayerChanged" == v1
        if v8:
            del v1, v8
            v9 = method9(v2)
            del v2
            return US0_1(v9)
        else:
            del v8
            v12 = "StartGame" == v1
            if v12:
                del v1, v12
                method7(v2)
                del v2
                return US0_2()
            else:
                del v2, v12
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method4(v0 : object) -> Tuple[US0, US0]:
    v1 = v0[0]
    v2 = method5(v1)
    del v1
    v3 = v0[1]
    del v0
    v4 = method5(v3)
    del v3
    return v2, v4
def method3(v0 : object) -> Tuple[US0, US0, US0, US0]:
    v1 = v0[0]
    v2, v3 = method4(v1)
    del v1
    v4 = v0[1]
    v5 = method5(v4)
    del v4
    v6 = v0[2]
    del v0
    v7 = method5(v6)
    del v6
    return v2, v3, v5, v7
def method2(v0 : object) -> Tuple[US0, US0, US0, US0, US0, US0, US0, US0]:
    v1 = v0[0]
    v2, v3, v4, v5 = method3(v1)
    del v1
    v6 = v0[1]
    v7, v8 = method4(v6)
    del v6
    v9 = v0[2]
    v10 = method5(v9)
    del v9
    v11 = v0[3]
    del v0
    v12 = method5(v11)
    del v11
    return v2, v3, v4, v5, v7, v8, v10, v12
def method1(v0 : object) -> Tuple[US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0]:
    v1 = v0[0]
    v2, v3, v4, v5, v6, v7, v8, v9 = method2(v1)
    del v1
    v10 = v0[1]
    v11, v12, v13, v14 = method3(v10)
    del v10
    v15 = v0[2]
    v16, v17 = method4(v15)
    del v15
    v18 = v0[3]
    v19 = method5(v18)
    del v18
    v20 = v0[4]
    del v0
    v21 = method5(v20)
    del v20
    return v2, v3, v4, v5, v6, v7, v8, v9, v11, v12, v13, v14, v16, v17, v19, v21
def method0(v0 : object) -> Tuple[US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0, US0]:
    return method1(v0)
def method20(v0 : object) -> u64:
    assert isinstance(v0,u64), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method19(v0 : object) -> u64:
    v1 = method20(v0)
    del v0
    return v1
def method25(v0 : object) -> US8:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Ace" == v1
    if v4:
        del v1, v4
        method7(v2)
        del v2
        return US8_0()
    else:
        del v4
        v7 = "Eight" == v1
        if v7:
            del v1, v7
            method7(v2)
            del v2
            return US8_1()
        else:
            del v7
            v10 = "Five" == v1
            if v10:
                del v1, v10
                method7(v2)
                del v2
                return US8_2()
            else:
                del v10
                v13 = "Four" == v1
                if v13:
                    del v1, v13
                    method7(v2)
                    del v2
                    return US8_3()
                else:
                    del v13
                    v16 = "Jack" == v1
                    if v16:
                        del v1, v16
                        method7(v2)
                        del v2
                        return US8_4()
                    else:
                        del v16
                        v19 = "King" == v1
                        if v19:
                            del v1, v19
                            method7(v2)
                            del v2
                            return US8_5()
                        else:
                            del v19
                            v22 = "Nine" == v1
                            if v22:
                                del v1, v22
                                method7(v2)
                                del v2
                                return US8_6()
                            else:
                                del v22
                                v25 = "Queen" == v1
                                if v25:
                                    del v1, v25
                                    method7(v2)
                                    del v2
                                    return US8_7()
                                else:
                                    del v25
                                    v28 = "Seven" == v1
                                    if v28:
                                        del v1, v28
                                        method7(v2)
                                        del v2
                                        return US8_8()
                                    else:
                                        del v28
                                        v31 = "Six" == v1
                                        if v31:
                                            del v1, v31
                                            method7(v2)
                                            del v2
                                            return US8_9()
                                        else:
                                            del v31
                                            v34 = "Ten" == v1
                                            if v34:
                                                del v1, v34
                                                method7(v2)
                                                del v2
                                                return US8_10()
                                            else:
                                                del v34
                                                v37 = "Three" == v1
                                                if v37:
                                                    del v1, v37
                                                    method7(v2)
                                                    del v2
                                                    return US8_11()
                                                else:
                                                    del v37
                                                    v40 = "Two" == v1
                                                    if v40:
                                                        del v1, v40
                                                        method7(v2)
                                                        del v2
                                                        return US8_12()
                                                    else:
                                                        del v2, v40
                                                        raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                                        del v1
                                                        raise Exception("Error")
def method26(v0 : object) -> US9:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Clubs" == v1
    if v4:
        del v1, v4
        method7(v2)
        del v2
        return US9_0()
    else:
        del v4
        v7 = "Diamonds" == v1
        if v7:
            del v1, v7
            method7(v2)
            del v2
            return US9_1()
        else:
            del v7
            v10 = "Hearts" == v1
            if v10:
                del v1, v10
                method7(v2)
                del v2
                return US9_2()
            else:
                del v10
                v13 = "Spades" == v1
                if v13:
                    del v1, v13
                    method7(v2)
                    del v2
                    return US9_3()
                else:
                    del v2, v13
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method24(v0 : object) -> Tuple[US8, US9]:
    v1 = v0[0]
    v2 = method25(v1)
    del v1
    v3 = v0[1]
    del v0
    v4 = method26(v3)
    del v3
    return v2, v4
def method23(v0 : object) -> static_array_list:
    v1 = len(v0)
    assert (5 >= v1), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 5\nGot: {v1} '
    del v1
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v2 = len(v0)
    v3 = 5 >= v2
    v4 = v3 == False
    if v4:
        v5 = "The type level dimension has to equal the value passed at runtime into create."
        assert v3, v5
        del v5
    else:
        pass
    del v3, v4
    v6 = static_array_list(5)
    v6.length = v2
    v7 = 0
    while method10(v2, v7):
        v9 = v0[v7]
        v10, v11 = method24(v9)
        del v9
        v12 = 0 <= v7
        if v12:
            v13 = v6.length
            v14 = v7 < v13
            del v13
            v15 = v14
        else:
            v15 = False
        del v12
        v16 = v15 == False
        if v16:
            v17 = "The set index needs to be in range for the static array list."
            assert v15, v17
            del v17
        else:
            pass
        del v15, v16
        v6[v7] = (v10, v11)
        del v10, v11
        v7 += 1 
    del v0, v2, v7
    return v6
def method27(v0 : object) -> Tuple[i32, i32]:
    v1 = v0["chips_won"] # type: ignore
    v2 = method8(v1)
    del v1
    v3 = v0["winner_id"] # type: ignore
    del v0
    v4 = method8(v3)
    del v3
    return v2, v4
def method28(v0 : object) -> Tuple[i32, US1]:
    v1 = v0[0]
    v2 = method8(v1)
    del v1
    v3 = v0[1]
    del v0
    v4 = method6(v3)
    del v3
    return v2, v4
def method30(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9, v10 = method24(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 2
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v5[v6] = (v9, v10)
        del v9, v10
        v6 += 1 
    del v0, v1, v6
    return v5
def method29(v0 : object) -> Tuple[i32, static_array]:
    v1 = v0[0]
    v2 = method8(v1)
    del v1
    v3 = v0[1]
    del v0
    v4 = method30(v3)
    del v3
    return v2, v4
def method34(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 5 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(5)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9, v10 = method24(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 5
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v5[v6] = (v9, v10)
        del v9, v10
        v6 += 1 
    del v0, v1, v6
    return v5
def method33(v0 : object) -> US10:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Flush" == v1
    if v4:
        del v1, v4
        v5 = method34(v2)
        del v2
        return US10_0(v5)
    else:
        del v4
        v8 = "Full_House" == v1
        if v8:
            del v1, v8
            v9 = method34(v2)
            del v2
            return US10_1(v9)
        else:
            del v8
            v12 = "High_Card" == v1
            if v12:
                del v1, v12
                v13 = method34(v2)
                del v2
                return US10_2(v13)
            else:
                del v12
                v16 = "Pair" == v1
                if v16:
                    del v1, v16
                    v17 = method34(v2)
                    del v2
                    return US10_3(v17)
                else:
                    del v16
                    v20 = "Quads" == v1
                    if v20:
                        del v1, v20
                        v21 = method34(v2)
                        del v2
                        return US10_4(v21)
                    else:
                        del v20
                        v24 = "Straight" == v1
                        if v24:
                            del v1, v24
                            v25 = method34(v2)
                            del v2
                            return US10_5(v25)
                        else:
                            del v24
                            v28 = "Straight_Flush" == v1
                            if v28:
                                del v1, v28
                                v29 = method34(v2)
                                del v2
                                return US10_6(v29)
                            else:
                                del v28
                                v32 = "Triple" == v1
                                if v32:
                                    del v1, v32
                                    v33 = method34(v2)
                                    del v2
                                    return US10_7(v33)
                                else:
                                    del v32
                                    v36 = "Two_Pair" == v1
                                    if v36:
                                        del v1, v36
                                        v37 = method34(v2)
                                        del v2
                                        return US10_8(v37)
                                    else:
                                        del v2, v36
                                        raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                        del v1
                                        raise Exception("Error")
def method32(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9 = method33(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method31(v0 : object) -> Tuple[i32, static_array, i32]:
    v1 = v0["chips_won"] # type: ignore
    v2 = method8(v1)
    del v1
    v3 = v0["hands_shown"] # type: ignore
    v4 = method32(v3)
    del v3
    v5 = v0["winner_id"] # type: ignore
    del v0
    v6 = method8(v5)
    del v5
    return v2, v4, v6
def method22(v0 : object) -> US7:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "CommunityCardsAre" == v1
    if v4:
        del v1, v4
        v5 = method23(v2)
        del v2
        return US7_0(v5)
    else:
        del v4
        v8 = "Fold" == v1
        if v8:
            del v1, v8
            v9, v10 = method27(v2)
            del v2
            return US7_1(v9, v10)
        else:
            del v8
            v13 = "PlayerAction" == v1
            if v13:
                del v1, v13
                v14, v15 = method28(v2)
                del v2
                return US7_2(v14, v15)
            else:
                del v13
                v18 = "PlayerGotCards" == v1
                if v18:
                    del v1, v18
                    v19, v20 = method29(v2)
                    del v2
                    return US7_3(v19, v20)
                else:
                    del v18
                    v23 = "Showdown" == v1
                    if v23:
                        del v1, v23
                        v24, v25, v26 = method31(v2)
                        del v2
                        return US7_4(v24, v25, v26)
                    else:
                        del v2, v23
                        raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                        del v1
                        raise Exception("Error")
def method21(v0 : object) -> static_array_list:
    v1 = len(v0)
    assert (128 >= v1), f'The length of the original object has to be greater than or equal to the static array dimension.\nExpected: 128\nGot: {v1} '
    del v1
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v2 = len(v0)
    v3 = 128 >= v2
    v4 = v3 == False
    if v4:
        v5 = "The type level dimension has to equal the value passed at runtime into create."
        assert v3, v5
        del v5
    else:
        pass
    del v3, v4
    v6 = static_array_list(128)
    v6.length = v2
    v7 = 0
    while method10(v2, v7):
        v9 = v0[v7]
        v10 = method22(v9)
        del v9
        v11 = 0 <= v7
        if v11:
            v12 = v6.length
            v13 = v7 < v12
            del v12
            v14 = v13
        else:
            v14 = False
        del v11
        v15 = v14 == False
        if v15:
            v16 = "The set index needs to be in range for the static array list."
            assert v14, v16
            del v16
        else:
            pass
        del v14, v15
        v6[v7] = v10
        del v10
        v7 += 1 
    del v0, v2, v7
    return v6
def method18(v0 : object) -> Tuple[u64, static_array_list]:
    v1 = v0["deck"] # type: ignore
    v2 = method19(v1)
    del v1
    v3 = v0["messages"] # type: ignore
    del v0
    v4 = method21(v3)
    del v3
    return v2, v4
def method39(v0 : object) -> i32:
    v1 = v0["min_raise"] # type: ignore
    del v0
    v2 = method8(v1)
    del v1
    return v2
def method40(v0 : object) -> bool:
    assert isinstance(v0,bool), f'The object needs to be the right primitive type. Got: {v0}'
    v1 = v0
    del v0
    return v1
def method41(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9 = method30(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method42(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 2 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(2)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9 = method8(v8)
        del v8
        v10 = 0 <= v6
        if v10:
            v11 = v6 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v5[v6] = v9
        del v9
        v6 += 1 
    del v0, v1, v6
    return v5
def method44(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 3 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(3)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9, v10 = method24(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 3
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v5[v6] = (v9, v10)
        del v9, v10
        v6 += 1 
    del v0, v1, v6
    return v5
def method45(v0 : object) -> static_array:
    assert isinstance(v0,list), f'The object needs to be a Python list. Got: {v0}'
    v1 = len(v0)
    v2 = 4 == v1
    v3 = v2 == False
    if v3:
        v4 = "The type level dimension has to equal the value passed at runtime into create."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = static_array(4)
    v6 = 0
    while method10(v1, v6):
        v8 = v0[v6]
        v9, v10 = method24(v8)
        del v8
        v11 = 0 <= v6
        if v11:
            v12 = v6 < 4
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v5[v6] = (v9, v10)
        del v9, v10
        v6 += 1 
    del v0, v1, v6
    return v5
def method43(v0 : object) -> US5:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "Flop" == v1
    if v4:
        del v1, v4
        v5 = method44(v2)
        del v2
        return US5_0(v5)
    else:
        del v4
        v8 = "Preflop" == v1
        if v8:
            del v1, v8
            method7(v2)
            del v2
            return US5_1()
        else:
            del v8
            v11 = "River" == v1
            if v11:
                del v1, v11
                v12 = method34(v2)
                del v2
                return US5_2(v12)
            else:
                del v11
                v15 = "Turn" == v1
                if v15:
                    del v1, v15
                    v16 = method45(v2)
                    del v2
                    return US5_3(v16)
                else:
                    del v2, v15
                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                    del v1
                    raise Exception("Error")
def method38(v0 : object) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5]:
    v1 = v0["config"] # type: ignore
    v2 = method39(v1)
    del v1
    v3 = v0["is_button_s_first_move"] # type: ignore
    v4 = method40(v3)
    del v3
    v5 = v0["pl_card"] # type: ignore
    v6 = method41(v5)
    del v5
    v7 = v0["player_turn"] # type: ignore
    v8 = method8(v7)
    del v7
    v9 = v0["pot"] # type: ignore
    v10 = method42(v9)
    del v9
    v11 = v0["stack"] # type: ignore
    v12 = method42(v11)
    del v11
    v13 = v0["street"] # type: ignore
    del v0
    v14 = method43(v13)
    del v13
    return v2, v4, v6, v8, v10, v12, v14
def method46(v0 : object) -> Tuple[i32, bool, static_array, i32, static_array, static_array, US5, US1]:
    v1 = v0[0]
    v2, v3, v4, v5, v6, v7, v8 = method38(v1)
    del v1
    v9 = v0[1]
    del v0
    v10 = method6(v9)
    del v9
    return v2, v3, v4, v5, v6, v7, v8, v10
def method37(v0 : object) -> US4:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "G_Flop" == v1
    if v4:
        del v1, v4
        v5, v6, v7, v8, v9, v10, v11 = method38(v2)
        del v2
        return US4_0(v5, v6, v7, v8, v9, v10, v11)
    else:
        del v4
        v14 = "G_Fold" == v1
        if v14:
            del v1, v14
            v15, v16, v17, v18, v19, v20, v21 = method38(v2)
            del v2
            return US4_1(v15, v16, v17, v18, v19, v20, v21)
        else:
            del v14
            v24 = "G_Preflop" == v1
            if v24:
                del v1, v24
                method7(v2)
                del v2
                return US4_2()
            else:
                del v24
                v27 = "G_River" == v1
                if v27:
                    del v1, v27
                    v28, v29, v30, v31, v32, v33, v34 = method38(v2)
                    del v2
                    return US4_3(v28, v29, v30, v31, v32, v33, v34)
                else:
                    del v27
                    v37 = "G_Round" == v1
                    if v37:
                        del v1, v37
                        v38, v39, v40, v41, v42, v43, v44 = method38(v2)
                        del v2
                        return US4_4(v38, v39, v40, v41, v42, v43, v44)
                    else:
                        del v37
                        v47 = "G_Round'" == v1
                        if v47:
                            del v1, v47
                            v48, v49, v50, v51, v52, v53, v54, v55 = method46(v2)
                            del v2
                            return US4_5(v48, v49, v50, v51, v52, v53, v54, v55)
                        else:
                            del v47
                            v58 = "G_Showdown" == v1
                            if v58:
                                del v1, v58
                                v59, v60, v61, v62, v63, v64, v65 = method38(v2)
                                del v2
                                return US4_6(v59, v60, v61, v62, v63, v64, v65)
                            else:
                                del v58
                                v68 = "G_Turn" == v1
                                if v68:
                                    del v1, v68
                                    v69, v70, v71, v72, v73, v74, v75 = method38(v2)
                                    del v2
                                    return US4_7(v69, v70, v71, v72, v73, v74, v75)
                                else:
                                    del v2, v68
                                    raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                                    del v1
                                    raise Exception("Error")
def method36(v0 : object) -> US3:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        method7(v2)
        del v2
        return US3_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            v8 = method37(v2)
            del v2
            return US3_1(v8)
        else:
            del v2, v7
            raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            raise Exception("Error")
def method47(v0 : object) -> US6:
    v1 = v0[0] # type: ignore
    v2 = v0[1] # type: ignore
    del v0
    v4 = "GameNotStarted" == v1
    if v4:
        del v1, v4
        method7(v2)
        del v2
        return US6_0()
    else:
        del v4
        v7 = "GameOver" == v1
        if v7:
            del v1, v7
            v8, v9, v10, v11, v12, v13, v14 = method38(v2)
            del v2
            return US6_1(v8, v9, v10, v11, v12, v13, v14)
        else:
            del v7
            v17 = "WaitingForActionFromPlayerId" == v1
            if v17:
                del v1, v17
                v18, v19, v20, v21, v22, v23, v24 = method38(v2)
                del v2
                return US6_2(v18, v19, v20, v21, v22, v23, v24)
            else:
                del v2, v17
                raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
                del v1
                raise Exception("Error")
def method35(v0 : object) -> Tuple[US3, static_array, US6]:
    v1 = v0["game"] # type: ignore
    v2 = method36(v1)
    del v1
    v3 = v0["pl_type"] # type: ignore
    v4 = method9(v3)
    del v3
    v5 = v0["ui_game_state"] # type: ignore
    del v0
    v6 = method47(v5)
    del v5
    return v2, v4, v6
def method17(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6]:
    v1 = v0["large"] # type: ignore
    v2, v3 = method18(v1)
    del v1
    v4 = v0["small"] # type: ignore
    del v0
    v5, v6, v7 = method35(v4)
    del v4
    return v2, v3, v5, v6, v7
def method16(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6]:
    v1 = v0[0]
    v2, v3, v4, v5, v6 = method17(v1)
    del v1
    v7 = v0[1]
    del v0
    v8, v9, v10, v11, v12 = method17(v7)
    del v7
    return v2, v3, v4, v5, v6, v8, v9, v10, v11, v12
def method15(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6]:
    v1 = v0[0]
    v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 = method16(v1)
    del v1
    v12 = v0[1]
    v13, v14, v15, v16, v17 = method17(v12)
    del v12
    v18 = v0[2]
    del v0
    v19, v20, v21, v22, v23 = method17(v18)
    del v18
    return v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v13, v14, v15, v16, v17, v19, v20, v21, v22, v23
def method14(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6]:
    v1 = v0[0]
    v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21 = method15(v1)
    del v1
    v22 = v0[1]
    v23, v24, v25, v26, v27, v28, v29, v30, v31, v32 = method16(v22)
    del v22
    v33 = v0[2]
    v34, v35, v36, v37, v38 = method17(v33)
    del v33
    v39 = v0[3]
    del v0
    v40, v41, v42, v43, v44 = method17(v39)
    del v39
    return v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v34, v35, v36, v37, v38, v40, v41, v42, v43, v44
def method13(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6]:
    v1 = v0[0]
    v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41 = method14(v1)
    del v1
    v42 = v0[1]
    v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62 = method15(v42)
    del v42
    v63 = v0[2]
    v64, v65, v66, v67, v68, v69, v70, v71, v72, v73 = method16(v63)
    del v63
    v74 = v0[3]
    v75, v76, v77, v78, v79 = method17(v74)
    del v74
    v80 = v0[4]
    del v0
    v81, v82, v83, v84, v85 = method17(v80)
    del v80
    return v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v64, v65, v66, v67, v68, v69, v70, v71, v72, v73, v75, v76, v77, v78, v79, v81, v82, v83, v84, v85
def method12(v0 : object) -> Tuple[u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6, u64, static_array_list, US3, static_array, US6]:
    return method13(v0)
def method49(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[0:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method51(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[4:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method52(v0 : cp.ndarray) -> None:
    del v0
    return 
def method53(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[8:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method50(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method51(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method52(v0)
        case US1_1(): # A_Fold
            del v1
            return method52(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method53(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method55(v0 : i32) -> bool:
    v1 = v0 < 2
    del v0
    return v1
def method57(v0 : cp.ndarray) -> None:
    del v0
    return 
def method56(v0 : cp.ndarray, v1 : US2) -> None:
    v2 = v1.tag
    method49(v0, v2)
    del v2
    match v1:
        case US2_0(): # Computer
            del v1
            return method57(v0)
        case US2_1(): # Human
            del v1
            return method57(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method54(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 4 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method58(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[12:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method60(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method61(v0 : cp.ndarray) -> None:
    del v0
    return 
def method62(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[20:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method59(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method60(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method61(v0)
        case US1_1(): # A_Fold
            del v1
            return method61(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method62(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method63(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 16 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method64(v0 : cp.ndarray) -> None:
    del v0
    return 
def method65(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[24:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method67(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[28:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method68(v0 : cp.ndarray) -> None:
    del v0
    return 
def method69(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[32:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method66(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method67(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method68(v0)
        case US1_1(): # A_Fold
            del v1
            return method68(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method69(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method70(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 28 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method71(v0 : cp.ndarray) -> None:
    del v0
    return 
def method72(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[36:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method74(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[40:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method75(v0 : cp.ndarray) -> None:
    del v0
    return 
def method76(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[44:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method73(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method74(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method75(v0)
        case US1_1(): # A_Fold
            del v1
            return method75(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method76(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method77(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 40 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method78(v0 : cp.ndarray) -> None:
    del v0
    return 
def method79(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[48:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method81(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[52:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method82(v0 : cp.ndarray) -> None:
    del v0
    return 
def method83(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[56:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method80(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method81(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method82(v0)
        case US1_1(): # A_Fold
            del v1
            return method82(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method83(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method84(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 52 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method85(v0 : cp.ndarray) -> None:
    del v0
    return 
def method86(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[60:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method88(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[64:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method89(v0 : cp.ndarray) -> None:
    del v0
    return 
def method90(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[68:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method87(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method88(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method89(v0)
        case US1_1(): # A_Fold
            del v1
            return method89(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method90(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method91(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 64 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method92(v0 : cp.ndarray) -> None:
    del v0
    return 
def method93(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[72:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method95(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[76:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method96(v0 : cp.ndarray) -> None:
    del v0
    return 
def method97(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[80:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method94(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method95(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method96(v0)
        case US1_1(): # A_Fold
            del v1
            return method96(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method97(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method98(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 76 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method99(v0 : cp.ndarray) -> None:
    del v0
    return 
def method100(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[84:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method102(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[88:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method103(v0 : cp.ndarray) -> None:
    del v0
    return 
def method104(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[92:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method101(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method102(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method103(v0)
        case US1_1(): # A_Fold
            del v1
            return method103(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method104(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method105(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 88 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method106(v0 : cp.ndarray) -> None:
    del v0
    return 
def method107(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[96:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method109(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[100:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method110(v0 : cp.ndarray) -> None:
    del v0
    return 
def method111(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[104:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method108(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method109(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method110(v0)
        case US1_1(): # A_Fold
            del v1
            return method110(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method111(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method112(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 100 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method113(v0 : cp.ndarray) -> None:
    del v0
    return 
def method114(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[108:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method116(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[112:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method117(v0 : cp.ndarray) -> None:
    del v0
    return 
def method118(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method115(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method116(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method117(v0)
        case US1_1(): # A_Fold
            del v1
            return method117(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method118(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method119(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 112 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method120(v0 : cp.ndarray) -> None:
    del v0
    return 
def method121(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[120:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method123(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[124:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method124(v0 : cp.ndarray) -> None:
    del v0
    return 
def method125(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[128:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method122(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method123(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method124(v0)
        case US1_1(): # A_Fold
            del v1
            return method124(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method125(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method126(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 124 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method127(v0 : cp.ndarray) -> None:
    del v0
    return 
def method128(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[132:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method130(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[136:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method131(v0 : cp.ndarray) -> None:
    del v0
    return 
def method132(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[140:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method129(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method130(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method131(v0)
        case US1_1(): # A_Fold
            del v1
            return method131(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method132(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method133(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 136 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method134(v0 : cp.ndarray) -> None:
    del v0
    return 
def method135(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[144:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method137(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[148:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method138(v0 : cp.ndarray) -> None:
    del v0
    return 
def method139(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[152:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method136(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method137(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method138(v0)
        case US1_1(): # A_Fold
            del v1
            return method138(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method139(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method140(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 148 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method141(v0 : cp.ndarray) -> None:
    del v0
    return 
def method142(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[156:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method144(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[160:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method145(v0 : cp.ndarray) -> None:
    del v0
    return 
def method146(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[164:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method143(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method144(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method145(v0)
        case US1_1(): # A_Fold
            del v1
            return method145(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method146(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method147(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 160 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method148(v0 : cp.ndarray) -> None:
    del v0
    return 
def method149(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[168:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method151(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[172:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method152(v0 : cp.ndarray) -> None:
    del v0
    return 
def method153(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[176:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method150(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method151(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method152(v0)
        case US1_1(): # A_Fold
            del v1
            return method152(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method153(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method154(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 172 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method155(v0 : cp.ndarray) -> None:
    del v0
    return 
def method156(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[180:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method158(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[184:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method159(v0 : cp.ndarray) -> None:
    del v0
    return 
def method160(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[188:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method157(v0 : cp.ndarray, v1 : US1) -> None:
    v2 = v1.tag
    method158(v0, v2)
    del v2
    match v1:
        case US1_0(): # A_Call
            del v1
            return method159(v0)
        case US1_1(): # A_Fold
            del v1
            return method159(v0)
        case US1_2(v3): # A_Raise
            del v1
            return method160(v0, v3)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method161(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 4
        del v4
        v6 = 184 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 2
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v1[v2]
        method56(v7, v13)
        del v7, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method162(v0 : cp.ndarray) -> None:
    del v0
    return 
def method48(v0 : cp.ndarray, v1 : US0, v2 : US0, v3 : US0, v4 : US0, v5 : US0, v6 : US0, v7 : US0, v8 : US0, v9 : US0, v10 : US0, v11 : US0, v12 : US0, v13 : US0, v14 : US0, v15 : US0, v16 : US0) -> None:
    v17 = v1.tag
    method49(v0, v17)
    del v17
    match v1:
        case US0_0(v18): # ActionSelected
            method50(v0, v18)
        case US0_1(v19): # PlayerChanged
            method54(v0, v19)
        case US0_2(): # StartGame
            method57(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    v20 = v2.tag
    method58(v0, v20)
    del v20
    match v2:
        case US0_0(v21): # ActionSelected
            method59(v0, v21)
        case US0_1(v22): # PlayerChanged
            method63(v0, v22)
        case US0_2(): # StartGame
            method64(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v2
    v23 = v3.tag
    method65(v0, v23)
    del v23
    match v3:
        case US0_0(v24): # ActionSelected
            method66(v0, v24)
        case US0_1(v25): # PlayerChanged
            method70(v0, v25)
        case US0_2(): # StartGame
            method71(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3
    v26 = v4.tag
    method72(v0, v26)
    del v26
    match v4:
        case US0_0(v27): # ActionSelected
            method73(v0, v27)
        case US0_1(v28): # PlayerChanged
            method77(v0, v28)
        case US0_2(): # StartGame
            method78(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v4
    v29 = v5.tag
    method79(v0, v29)
    del v29
    match v5:
        case US0_0(v30): # ActionSelected
            method80(v0, v30)
        case US0_1(v31): # PlayerChanged
            method84(v0, v31)
        case US0_2(): # StartGame
            method85(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v5
    v32 = v6.tag
    method86(v0, v32)
    del v32
    match v6:
        case US0_0(v33): # ActionSelected
            method87(v0, v33)
        case US0_1(v34): # PlayerChanged
            method91(v0, v34)
        case US0_2(): # StartGame
            method92(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v6
    v35 = v7.tag
    method93(v0, v35)
    del v35
    match v7:
        case US0_0(v36): # ActionSelected
            method94(v0, v36)
        case US0_1(v37): # PlayerChanged
            method98(v0, v37)
        case US0_2(): # StartGame
            method99(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v38 = v8.tag
    method100(v0, v38)
    del v38
    match v8:
        case US0_0(v39): # ActionSelected
            method101(v0, v39)
        case US0_1(v40): # PlayerChanged
            method105(v0, v40)
        case US0_2(): # StartGame
            method106(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v8
    v41 = v9.tag
    method107(v0, v41)
    del v41
    match v9:
        case US0_0(v42): # ActionSelected
            method108(v0, v42)
        case US0_1(v43): # PlayerChanged
            method112(v0, v43)
        case US0_2(): # StartGame
            method113(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v9
    v44 = v10.tag
    method114(v0, v44)
    del v44
    match v10:
        case US0_0(v45): # ActionSelected
            method115(v0, v45)
        case US0_1(v46): # PlayerChanged
            method119(v0, v46)
        case US0_2(): # StartGame
            method120(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v10
    v47 = v11.tag
    method121(v0, v47)
    del v47
    match v11:
        case US0_0(v48): # ActionSelected
            method122(v0, v48)
        case US0_1(v49): # PlayerChanged
            method126(v0, v49)
        case US0_2(): # StartGame
            method127(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v11
    v50 = v12.tag
    method128(v0, v50)
    del v50
    match v12:
        case US0_0(v51): # ActionSelected
            method129(v0, v51)
        case US0_1(v52): # PlayerChanged
            method133(v0, v52)
        case US0_2(): # StartGame
            method134(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v12
    v53 = v13.tag
    method135(v0, v53)
    del v53
    match v13:
        case US0_0(v54): # ActionSelected
            method136(v0, v54)
        case US0_1(v55): # PlayerChanged
            method140(v0, v55)
        case US0_2(): # StartGame
            method141(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v13
    v56 = v14.tag
    method142(v0, v56)
    del v56
    match v14:
        case US0_0(v57): # ActionSelected
            method143(v0, v57)
        case US0_1(v58): # PlayerChanged
            method147(v0, v58)
        case US0_2(): # StartGame
            method148(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v14
    v59 = v15.tag
    method149(v0, v59)
    del v59
    match v15:
        case US0_0(v60): # ActionSelected
            method150(v0, v60)
        case US0_1(v61): # PlayerChanged
            method154(v0, v61)
        case US0_2(): # StartGame
            method155(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v15
    v62 = v16.tag
    method156(v0, v62)
    del v62
    match v16:
        case US0_0(v63): # ActionSelected
            del v16
            return method157(v0, v63)
        case US0_1(v64): # PlayerChanged
            del v16
            return method161(v0, v64)
        case US0_2(): # StartGame
            del v16
            return method162(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method164(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[0:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method167(v0 : cp.ndarray, v1 : US8, v2 : US9) -> None:
    v3 = v1.tag
    method49(v0, v3)
    del v3
    match v1:
        case US8_0(): # Ace
            method57(v0)
        case US8_1(): # Eight
            method57(v0)
        case US8_2(): # Five
            method57(v0)
        case US8_3(): # Four
            method57(v0)
        case US8_4(): # Jack
            method57(v0)
        case US8_5(): # King
            method57(v0)
        case US8_6(): # Nine
            method57(v0)
        case US8_7(): # Queen
            method57(v0)
        case US8_8(): # Seven
            method57(v0)
        case US8_9(): # Six
            method57(v0)
        case US8_10(): # Ten
            method57(v0)
        case US8_11(): # Three
            method57(v0)
        case US8_12(): # Two
            method57(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v1
    v4 = v2.tag
    method51(v0, v4)
    del v4
    match v2:
        case US9_0(): # Clubs
            del v2
            return method52(v0)
        case US9_1(): # Diamonds
            del v2
            return method52(v0)
        case US9_2(): # Hearts
            del v2
            return method52(v0)
        case US9_3(): # Spades
            del v2
            return method52(v0)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method166(v0 : cp.ndarray, v1 : static_array_list) -> None:
    v2 = v1.length
    method51(v0, v2)
    del v2
    v3 = v1.length
    v4 = 0
    while method10(v3, v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = 0 <= v4
        if v10:
            v11 = v1.length
            v12 = v4 < v11
            del v11
            v13 = v12
        else:
            v13 = False
        del v10
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array list."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v16, v17 = v1[v4]
        method167(v9, v16, v17)
        del v9, v16, v17
        v4 += 1 
    del v0, v1, v3, v4
    return 
def method168(v0 : cp.ndarray, v1 : i32, v2 : i32) -> None:
    v3 = v0[4:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v0[8:].view(cp.int32)
    del v0
    v4[0] = v2
    del v2, v4
    return 
def method170(v0 : cp.ndarray) -> None:
    del v0
    return 
def method169(v0 : cp.ndarray, v1 : i32, v2 : US1) -> None:
    v3 = v0[4:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = v2.tag
    method53(v0, v4)
    del v4
    match v2:
        case US1_0(): # A_Call
            del v2
            return method170(v0)
        case US1_1(): # A_Fold
            del v2
            return method170(v0)
        case US1_2(v5): # A_Raise
            del v2
            return method58(v0, v5)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method171(v0 : cp.ndarray, v1 : i32, v2 : static_array) -> None:
    v3 = v0[4:].view(cp.int32)
    v3[0] = v1
    del v1, v3
    v4 = 0
    while method55(v4):
        v6 = u64(v4)
        v7 = v6 * 8
        del v6
        v8 = 8 + v7
        del v7
        v9 = v0[v8:].view(cp.uint8)
        del v8
        v10 = 0 <= v4
        if v10:
            v11 = v4 < 2
            v12 = v11
        else:
            v12 = False
        del v10
        v13 = v12 == False
        if v13:
            v14 = "The read index needs to be in range for the static array."
            assert v12, v14
            del v14
        else:
            pass
        del v12, v13
        v15, v16 = v2[v4]
        method167(v9, v15, v16)
        del v9, v15, v16
        v4 += 1 
    del v0, v2, v4
    return 
def method175(v0 : i32) -> bool:
    v1 = v0 < 5
    del v0
    return v1
def method174(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 8 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method173(v0 : cp.ndarray, v1 : US10) -> None:
    v2 = v1.tag
    method49(v0, v2)
    del v2
    match v1:
        case US10_0(v3): # Flush
            del v1
            return method174(v0, v3)
        case US10_1(v4): # Full_House
            del v1
            return method174(v0, v4)
        case US10_2(v5): # High_Card
            del v1
            return method174(v0, v5)
        case US10_3(v6): # Pair
            del v1
            return method174(v0, v6)
        case US10_4(v7): # Quads
            del v1
            return method174(v0, v7)
        case US10_5(v8): # Straight
            del v1
            return method174(v0, v8)
        case US10_6(v9): # Straight_Flush
            del v1
            return method174(v0, v9)
        case US10_7(v10): # Triple
            del v1
            return method174(v0, v10)
        case US10_8(v11): # Two_Pair
            del v1
            return method174(v0, v11)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method172(v0 : cp.ndarray, v1 : i32, v2 : static_array, v3 : i32) -> None:
    v4 = v0[4:].view(cp.int32)
    v4[0] = v1
    del v1, v4
    v5 = 0
    while method55(v5):
        v7 = u64(v5)
        v8 = v7 * 48
        del v7
        v9 = 16 + v8
        del v8
        v10 = v0[v9:].view(cp.uint8)
        del v9
        v11 = 0 <= v5
        if v11:
            v12 = v5 < 2
            v13 = v12
        else:
            v13 = False
        del v11
        v14 = v13 == False
        if v14:
            v15 = "The read index needs to be in range for the static array."
            assert v13, v15
            del v15
        else:
            pass
        del v13, v14
        v16 = v2[v5]
        method173(v10, v16)
        del v10, v16
        v5 += 1 
    del v2, v5
    v17 = v0[112:].view(cp.int32)
    del v0
    v17[0] = v3
    del v3, v17
    return 
def method165(v0 : cp.ndarray, v1 : US7) -> None:
    v2 = v1.tag
    method49(v0, v2)
    del v2
    match v1:
        case US7_0(v3): # CommunityCardsAre
            del v1
            return method166(v0, v3)
        case US7_1(v4, v5): # Fold
            del v1
            return method168(v0, v4, v5)
        case US7_2(v6, v7): # PlayerAction
            del v1
            return method169(v0, v6, v7)
        case US7_3(v8, v9): # PlayerGotCards
            del v1
            return method171(v0, v8, v9)
        case US7_4(v10, v11, v12): # Showdown
            del v1
            return method172(v0, v10, v11, v12)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method176(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16400:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method177(v0 : cp.ndarray) -> None:
    del v0
    return 
def method179(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16404:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method181(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method55(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = v0[v5:].view(cp.uint8)
        del v5
        v7 = 0 <= v2
        if v7:
            v8 = v2 < 2
            v9 = v8
        else:
            v9 = False
        del v7
        v10 = v9 == False
        if v10:
            v11 = "The read index needs to be in range for the static array."
            assert v9, v11
            del v11
        else:
            pass
        del v9, v10
        v12, v13 = v1[v2]
        method167(v6, v12, v13)
        del v6, v12, v13
        v2 += 1 
    del v0, v1, v2
    return 
def method182(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16468:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method184(v0 : i32) -> bool:
    v1 = v0 < 3
    del v0
    return v1
def method183(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 16472 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method185(v0 : cp.ndarray) -> None:
    del v0
    return 
def method186(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 16472 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method188(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def method187(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 16472 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method180(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[16408:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[16412:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 16416 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[16448:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 16452 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 16460 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method182(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method183(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method185(v0)
        case US5_2(v49): # River
            del v7
            return method186(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method187(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method189(v0 : cp.ndarray) -> None:
    del v0
    return 
def method191(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16512:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method192(v0 : cp.ndarray) -> None:
    del v0
    return 
def method193(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16516:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method190(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[16408:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[16412:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 16416 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[16448:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 16452 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 16460 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method182(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method183(v0, v49)
        case US5_1(): # Preflop
            method185(v0)
        case US5_2(v50): # River
            method186(v0, v50)
        case US5_3(v51): # Turn
            method187(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method191(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method192(v0)
        case US1_1(): # A_Fold
            del v8
            return method192(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method193(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method178(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method179(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method180(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method180(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method189(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method180(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method180(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method190(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method180(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method180(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method194(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16528:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method195(v0 : cp.ndarray) -> None:
    del v0
    return 
def method197(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16596:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method198(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 16600 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method199(v0 : cp.ndarray) -> None:
    del v0
    return 
def method200(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 16600 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method201(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 16600 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method196(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[16532:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[16536:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 16544 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[16576:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 16580 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 16588 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method197(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method198(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method199(v0)
        case US5_2(v49): # River
            del v7
            return method200(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method201(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method202(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[16640:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method203(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[16648:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method204(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33040:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method205(v0 : cp.ndarray) -> None:
    del v0
    return 
def method207(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33044:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method209(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33108:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method210(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 33112 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method211(v0 : cp.ndarray) -> None:
    del v0
    return 
def method212(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 33112 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method213(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 33112 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method208(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[33048:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[33052:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 33056 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[33088:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 33092 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 33100 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method209(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method210(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method211(v0)
        case US5_2(v49): # River
            del v7
            return method212(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method213(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method214(v0 : cp.ndarray) -> None:
    del v0
    return 
def method216(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33152:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method217(v0 : cp.ndarray) -> None:
    del v0
    return 
def method218(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33156:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method215(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[33048:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[33052:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 33056 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[33088:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 33092 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 33100 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method209(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method210(v0, v49)
        case US5_1(): # Preflop
            method211(v0)
        case US5_2(v50): # River
            method212(v0, v50)
        case US5_3(v51): # Turn
            method213(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method216(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method217(v0)
        case US1_1(): # A_Fold
            del v8
            return method217(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method218(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method206(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method207(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method208(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method208(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method214(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method208(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method208(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method215(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method208(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method208(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method219(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33168:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method220(v0 : cp.ndarray) -> None:
    del v0
    return 
def method222(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33236:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method223(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 33240 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method224(v0 : cp.ndarray) -> None:
    del v0
    return 
def method225(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 33240 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method226(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 33240 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method221(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[33172:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[33176:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 33184 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[33216:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 33220 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 33228 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method222(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method223(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method224(v0)
        case US5_2(v49): # River
            del v7
            return method225(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method226(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method227(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[33280:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method228(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[33288:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method229(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49680:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method230(v0 : cp.ndarray) -> None:
    del v0
    return 
def method232(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49684:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method234(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49748:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method235(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 49752 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method236(v0 : cp.ndarray) -> None:
    del v0
    return 
def method237(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 49752 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method238(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 49752 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method233(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[49688:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[49692:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 49696 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[49728:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 49732 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 49740 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method234(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method235(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method236(v0)
        case US5_2(v49): # River
            del v7
            return method237(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method238(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method239(v0 : cp.ndarray) -> None:
    del v0
    return 
def method241(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49792:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method242(v0 : cp.ndarray) -> None:
    del v0
    return 
def method243(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49796:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method240(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[49688:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[49692:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 49696 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[49728:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 49732 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 49740 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method234(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method235(v0, v49)
        case US5_1(): # Preflop
            method236(v0)
        case US5_2(v50): # River
            method237(v0, v50)
        case US5_3(v51): # Turn
            method238(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method241(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method242(v0)
        case US1_1(): # A_Fold
            del v8
            return method242(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method243(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method231(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method232(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method233(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method233(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method239(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method233(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method233(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method240(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method233(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method233(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method244(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49808:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method245(v0 : cp.ndarray) -> None:
    del v0
    return 
def method247(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49876:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method248(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 49880 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method249(v0 : cp.ndarray) -> None:
    del v0
    return 
def method250(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 49880 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method251(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 49880 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method246(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[49812:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[49816:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 49824 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[49856:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 49860 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 49868 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method247(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method248(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method249(v0)
        case US5_2(v49): # River
            del v7
            return method250(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method251(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method252(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[49920:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method253(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[49928:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method254(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66320:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method255(v0 : cp.ndarray) -> None:
    del v0
    return 
def method257(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66324:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method259(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66388:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method260(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 66392 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method261(v0 : cp.ndarray) -> None:
    del v0
    return 
def method262(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 66392 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method263(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 66392 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method258(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[66328:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[66332:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 66336 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[66368:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 66372 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 66380 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method259(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method260(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method261(v0)
        case US5_2(v49): # River
            del v7
            return method262(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method263(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method264(v0 : cp.ndarray) -> None:
    del v0
    return 
def method266(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66432:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method267(v0 : cp.ndarray) -> None:
    del v0
    return 
def method268(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66436:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method265(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[66328:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[66332:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 66336 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[66368:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 66372 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 66380 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method259(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method260(v0, v49)
        case US5_1(): # Preflop
            method261(v0)
        case US5_2(v50): # River
            method262(v0, v50)
        case US5_3(v51): # Turn
            method263(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method266(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method267(v0)
        case US1_1(): # A_Fold
            del v8
            return method267(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method268(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method256(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method257(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method258(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method258(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method264(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method258(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method258(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method265(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method258(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method258(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method269(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66448:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method270(v0 : cp.ndarray) -> None:
    del v0
    return 
def method272(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66516:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method273(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 66520 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method274(v0 : cp.ndarray) -> None:
    del v0
    return 
def method275(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 66520 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method276(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 66520 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method271(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[66452:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[66456:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 66464 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[66496:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 66500 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 66508 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method272(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method273(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method274(v0)
        case US5_2(v49): # River
            del v7
            return method275(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method276(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method277(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[66560:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method278(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[66568:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method279(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[82960:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method280(v0 : cp.ndarray) -> None:
    del v0
    return 
def method282(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[82964:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method284(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[83028:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method285(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 83032 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method286(v0 : cp.ndarray) -> None:
    del v0
    return 
def method287(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 83032 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method288(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 83032 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method283(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[82968:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[82972:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 82976 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[83008:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 83012 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 83020 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method284(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method285(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method286(v0)
        case US5_2(v49): # River
            del v7
            return method287(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method288(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method289(v0 : cp.ndarray) -> None:
    del v0
    return 
def method291(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[83072:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method292(v0 : cp.ndarray) -> None:
    del v0
    return 
def method293(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[83076:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method290(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[82968:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[82972:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 82976 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[83008:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 83012 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 83020 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method284(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method285(v0, v49)
        case US5_1(): # Preflop
            method286(v0)
        case US5_2(v50): # River
            method287(v0, v50)
        case US5_3(v51): # Turn
            method288(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method291(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method292(v0)
        case US1_1(): # A_Fold
            del v8
            return method292(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method293(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method281(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method282(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method283(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method283(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method289(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method283(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method283(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method290(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method283(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method283(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method294(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[83088:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method295(v0 : cp.ndarray) -> None:
    del v0
    return 
def method297(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[83156:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method298(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 83160 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method299(v0 : cp.ndarray) -> None:
    del v0
    return 
def method300(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 83160 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method301(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 83160 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method296(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[83092:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[83096:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 83104 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[83136:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 83140 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 83148 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method297(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method298(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method299(v0)
        case US5_2(v49): # River
            del v7
            return method300(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method301(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method302(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[83200:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method303(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[83208:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method304(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99600:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method305(v0 : cp.ndarray) -> None:
    del v0
    return 
def method307(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99604:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method309(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99668:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method310(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 99672 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method311(v0 : cp.ndarray) -> None:
    del v0
    return 
def method312(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 99672 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method313(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 99672 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method308(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[99608:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[99612:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 99616 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[99648:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 99652 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 99660 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method309(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method310(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method311(v0)
        case US5_2(v49): # River
            del v7
            return method312(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method313(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method314(v0 : cp.ndarray) -> None:
    del v0
    return 
def method316(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99712:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method317(v0 : cp.ndarray) -> None:
    del v0
    return 
def method318(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99716:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method315(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[99608:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[99612:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 99616 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[99648:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 99652 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 99660 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method309(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method310(v0, v49)
        case US5_1(): # Preflop
            method311(v0)
        case US5_2(v50): # River
            method312(v0, v50)
        case US5_3(v51): # Turn
            method313(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method316(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method317(v0)
        case US1_1(): # A_Fold
            del v8
            return method317(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method318(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method306(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method307(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method308(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method308(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method314(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method308(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method308(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method315(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method308(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method308(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method319(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99728:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method320(v0 : cp.ndarray) -> None:
    del v0
    return 
def method322(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99796:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method323(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 99800 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method324(v0 : cp.ndarray) -> None:
    del v0
    return 
def method325(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 99800 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method326(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 99800 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method321(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[99732:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[99736:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 99744 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[99776:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 99780 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 99788 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method322(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method323(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method324(v0)
        case US5_2(v49): # River
            del v7
            return method325(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method326(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method327(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[99840:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method328(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[99848:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method329(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116240:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method330(v0 : cp.ndarray) -> None:
    del v0
    return 
def method332(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116244:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method334(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116308:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method335(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 116312 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method336(v0 : cp.ndarray) -> None:
    del v0
    return 
def method337(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 116312 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method338(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 116312 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method333(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[116248:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[116252:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 116256 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[116288:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 116292 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 116300 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method334(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method335(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method336(v0)
        case US5_2(v49): # River
            del v7
            return method337(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method338(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method339(v0 : cp.ndarray) -> None:
    del v0
    return 
def method341(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116352:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method342(v0 : cp.ndarray) -> None:
    del v0
    return 
def method343(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116356:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method340(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[116248:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[116252:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 116256 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[116288:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 116292 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 116300 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method334(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method335(v0, v49)
        case US5_1(): # Preflop
            method336(v0)
        case US5_2(v50): # River
            method337(v0, v50)
        case US5_3(v51): # Turn
            method338(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method341(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method342(v0)
        case US1_1(): # A_Fold
            del v8
            return method342(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method343(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method331(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method332(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method333(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method333(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method339(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method333(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method333(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method340(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method333(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method333(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method344(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116368:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method345(v0 : cp.ndarray) -> None:
    del v0
    return 
def method347(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116436:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method348(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 116440 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method349(v0 : cp.ndarray) -> None:
    del v0
    return 
def method350(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 116440 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method351(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 116440 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method346(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[116372:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[116376:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 116384 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[116416:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 116420 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 116428 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method347(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method348(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method349(v0)
        case US5_2(v49): # River
            del v7
            return method350(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method351(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method352(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[116480:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method353(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[116488:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method354(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[132880:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method355(v0 : cp.ndarray) -> None:
    del v0
    return 
def method357(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[132884:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method359(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[132948:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method360(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 132952 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method361(v0 : cp.ndarray) -> None:
    del v0
    return 
def method362(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 132952 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method363(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 132952 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method358(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[132888:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[132892:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 132896 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[132928:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 132932 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 132940 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method359(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method360(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method361(v0)
        case US5_2(v49): # River
            del v7
            return method362(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method363(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method364(v0 : cp.ndarray) -> None:
    del v0
    return 
def method366(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[132992:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method367(v0 : cp.ndarray) -> None:
    del v0
    return 
def method368(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[132996:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method365(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[132888:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[132892:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 132896 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[132928:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 132932 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 132940 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method359(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method360(v0, v49)
        case US5_1(): # Preflop
            method361(v0)
        case US5_2(v50): # River
            method362(v0, v50)
        case US5_3(v51): # Turn
            method363(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method366(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method367(v0)
        case US1_1(): # A_Fold
            del v8
            return method367(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method368(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method356(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method357(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method358(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method358(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method364(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method358(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method358(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method365(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method358(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method358(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method369(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[133008:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method370(v0 : cp.ndarray) -> None:
    del v0
    return 
def method372(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[133076:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method373(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 133080 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method374(v0 : cp.ndarray) -> None:
    del v0
    return 
def method375(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 133080 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method376(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 133080 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method371(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[133012:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[133016:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 133024 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[133056:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 133060 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 133068 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method372(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method373(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method374(v0)
        case US5_2(v49): # River
            del v7
            return method375(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method376(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method377(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[133120:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method378(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[133128:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method379(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149520:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method380(v0 : cp.ndarray) -> None:
    del v0
    return 
def method382(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149524:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method384(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149588:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method385(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 149592 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method386(v0 : cp.ndarray) -> None:
    del v0
    return 
def method387(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 149592 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method388(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 149592 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method383(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[149528:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[149532:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 149536 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[149568:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 149572 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 149580 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method384(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method385(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method386(v0)
        case US5_2(v49): # River
            del v7
            return method387(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method388(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method389(v0 : cp.ndarray) -> None:
    del v0
    return 
def method391(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149632:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method392(v0 : cp.ndarray) -> None:
    del v0
    return 
def method393(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149636:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method390(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[149528:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[149532:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 149536 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[149568:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 149572 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 149580 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method384(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method385(v0, v49)
        case US5_1(): # Preflop
            method386(v0)
        case US5_2(v50): # River
            method387(v0, v50)
        case US5_3(v51): # Turn
            method388(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method391(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method392(v0)
        case US1_1(): # A_Fold
            del v8
            return method392(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method393(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method381(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method382(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method383(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method383(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method389(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method383(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method383(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method390(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method383(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method383(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method394(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149648:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method395(v0 : cp.ndarray) -> None:
    del v0
    return 
def method397(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149716:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method398(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 149720 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method399(v0 : cp.ndarray) -> None:
    del v0
    return 
def method400(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 149720 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method401(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 149720 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method396(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[149652:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[149656:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 149664 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[149696:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 149700 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 149708 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method397(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method398(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method399(v0)
        case US5_2(v49): # River
            del v7
            return method400(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method401(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method402(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[149760:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method403(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[149768:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method404(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166160:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method405(v0 : cp.ndarray) -> None:
    del v0
    return 
def method407(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166164:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method409(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166228:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method410(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 166232 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method411(v0 : cp.ndarray) -> None:
    del v0
    return 
def method412(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 166232 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method413(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 166232 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method408(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[166168:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[166172:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 166176 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[166208:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 166212 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 166220 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method409(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method410(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method411(v0)
        case US5_2(v49): # River
            del v7
            return method412(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method413(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method414(v0 : cp.ndarray) -> None:
    del v0
    return 
def method416(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166272:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method417(v0 : cp.ndarray) -> None:
    del v0
    return 
def method418(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166276:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method415(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[166168:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[166172:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 166176 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[166208:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 166212 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 166220 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method409(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method410(v0, v49)
        case US5_1(): # Preflop
            method411(v0)
        case US5_2(v50): # River
            method412(v0, v50)
        case US5_3(v51): # Turn
            method413(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method416(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method417(v0)
        case US1_1(): # A_Fold
            del v8
            return method417(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method418(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method406(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method407(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method408(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method408(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method414(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method408(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method408(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method415(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method408(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method408(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method419(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166288:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method420(v0 : cp.ndarray) -> None:
    del v0
    return 
def method422(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166356:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method423(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 166360 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method424(v0 : cp.ndarray) -> None:
    del v0
    return 
def method425(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 166360 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method426(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 166360 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method421(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[166292:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[166296:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 166304 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[166336:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 166340 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 166348 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method422(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method423(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method424(v0)
        case US5_2(v49): # River
            del v7
            return method425(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method426(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method427(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[166400:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method428(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[166408:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method429(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182800:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method430(v0 : cp.ndarray) -> None:
    del v0
    return 
def method432(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182804:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method434(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182868:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method435(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 182872 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method436(v0 : cp.ndarray) -> None:
    del v0
    return 
def method437(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 182872 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method438(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 182872 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method433(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[182808:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[182812:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 182816 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[182848:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 182852 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 182860 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method434(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method435(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method436(v0)
        case US5_2(v49): # River
            del v7
            return method437(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method438(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method439(v0 : cp.ndarray) -> None:
    del v0
    return 
def method441(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182912:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method442(v0 : cp.ndarray) -> None:
    del v0
    return 
def method443(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182916:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method440(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[182808:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[182812:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 182816 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[182848:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 182852 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 182860 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method434(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method435(v0, v49)
        case US5_1(): # Preflop
            method436(v0)
        case US5_2(v50): # River
            method437(v0, v50)
        case US5_3(v51): # Turn
            method438(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method441(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method442(v0)
        case US1_1(): # A_Fold
            del v8
            return method442(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method443(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method431(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method432(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method433(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method433(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method439(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method433(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method433(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method440(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method433(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method433(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method444(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182928:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method445(v0 : cp.ndarray) -> None:
    del v0
    return 
def method447(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[182996:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method448(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 183000 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method449(v0 : cp.ndarray) -> None:
    del v0
    return 
def method450(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 183000 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method451(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 183000 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method446(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[182932:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[182936:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 182944 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[182976:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 182980 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 182988 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method447(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method448(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method449(v0)
        case US5_2(v49): # River
            del v7
            return method450(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method451(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method452(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[183040:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method453(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[183048:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method454(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199440:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method455(v0 : cp.ndarray) -> None:
    del v0
    return 
def method457(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199444:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method459(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199508:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method460(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 199512 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method461(v0 : cp.ndarray) -> None:
    del v0
    return 
def method462(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 199512 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method463(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 199512 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method458(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[199448:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[199452:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 199456 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[199488:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 199492 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 199500 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method459(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method460(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method461(v0)
        case US5_2(v49): # River
            del v7
            return method462(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method463(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method464(v0 : cp.ndarray) -> None:
    del v0
    return 
def method466(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199552:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method467(v0 : cp.ndarray) -> None:
    del v0
    return 
def method468(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199556:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method465(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[199448:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[199452:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 199456 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[199488:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 199492 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 199500 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method459(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method460(v0, v49)
        case US5_1(): # Preflop
            method461(v0)
        case US5_2(v50): # River
            method462(v0, v50)
        case US5_3(v51): # Turn
            method463(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method466(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method467(v0)
        case US1_1(): # A_Fold
            del v8
            return method467(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method468(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method456(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method457(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method458(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method458(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method464(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method458(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method458(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method465(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method458(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method458(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method469(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199568:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method470(v0 : cp.ndarray) -> None:
    del v0
    return 
def method472(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199636:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method473(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 199640 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method474(v0 : cp.ndarray) -> None:
    del v0
    return 
def method475(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 199640 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method476(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 199640 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method471(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[199572:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[199576:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 199584 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[199616:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 199620 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 199628 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method472(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method473(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method474(v0)
        case US5_2(v49): # River
            del v7
            return method475(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method476(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method477(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[199680:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method478(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[199688:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method479(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216080:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method480(v0 : cp.ndarray) -> None:
    del v0
    return 
def method482(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216084:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method484(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216148:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method485(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 216152 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method486(v0 : cp.ndarray) -> None:
    del v0
    return 
def method487(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 216152 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method488(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 216152 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method483(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[216088:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[216092:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 216096 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[216128:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 216132 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 216140 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method484(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method485(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method486(v0)
        case US5_2(v49): # River
            del v7
            return method487(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method488(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method489(v0 : cp.ndarray) -> None:
    del v0
    return 
def method491(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216192:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method492(v0 : cp.ndarray) -> None:
    del v0
    return 
def method493(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216196:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method490(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[216088:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[216092:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 216096 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[216128:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 216132 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 216140 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method484(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method485(v0, v49)
        case US5_1(): # Preflop
            method486(v0)
        case US5_2(v50): # River
            method487(v0, v50)
        case US5_3(v51): # Turn
            method488(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method491(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method492(v0)
        case US1_1(): # A_Fold
            del v8
            return method492(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method493(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method481(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method482(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method483(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method483(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method489(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method483(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method483(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method490(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method483(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method483(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method494(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216208:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method495(v0 : cp.ndarray) -> None:
    del v0
    return 
def method497(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216276:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method498(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 216280 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method499(v0 : cp.ndarray) -> None:
    del v0
    return 
def method500(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 216280 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method501(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 216280 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method496(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[216212:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[216216:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 216224 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[216256:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 216260 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 216268 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method497(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method498(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method499(v0)
        case US5_2(v49): # River
            del v7
            return method500(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method501(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method502(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[216320:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method503(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[216328:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method504(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232720:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method505(v0 : cp.ndarray) -> None:
    del v0
    return 
def method507(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232724:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method509(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232788:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method510(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 232792 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method511(v0 : cp.ndarray) -> None:
    del v0
    return 
def method512(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 232792 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method513(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 232792 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method508(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[232728:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[232732:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 232736 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[232768:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 232772 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 232780 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method509(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method510(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method511(v0)
        case US5_2(v49): # River
            del v7
            return method512(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method513(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method514(v0 : cp.ndarray) -> None:
    del v0
    return 
def method516(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232832:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method517(v0 : cp.ndarray) -> None:
    del v0
    return 
def method518(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232836:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method515(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[232728:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[232732:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 232736 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[232768:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 232772 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 232780 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method509(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method510(v0, v49)
        case US5_1(): # Preflop
            method511(v0)
        case US5_2(v50): # River
            method512(v0, v50)
        case US5_3(v51): # Turn
            method513(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method516(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method517(v0)
        case US1_1(): # A_Fold
            del v8
            return method517(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method518(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method506(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method507(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method508(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method508(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method514(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method508(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method508(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method515(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method508(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method508(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method519(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232848:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method520(v0 : cp.ndarray) -> None:
    del v0
    return 
def method522(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232916:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method523(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 232920 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method524(v0 : cp.ndarray) -> None:
    del v0
    return 
def method525(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 232920 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method526(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 232920 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method521(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[232852:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[232856:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 232864 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[232896:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 232900 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 232908 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method522(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method523(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method524(v0)
        case US5_2(v49): # River
            del v7
            return method525(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method526(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method527(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[232960:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method528(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[232968:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method529(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249360:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method530(v0 : cp.ndarray) -> None:
    del v0
    return 
def method532(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249364:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method534(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249428:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method535(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 249432 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method536(v0 : cp.ndarray) -> None:
    del v0
    return 
def method537(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 249432 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method538(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 249432 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method533(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[249368:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[249372:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 249376 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[249408:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 249412 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 249420 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method534(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method535(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method536(v0)
        case US5_2(v49): # River
            del v7
            return method537(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method538(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method539(v0 : cp.ndarray) -> None:
    del v0
    return 
def method541(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249472:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method542(v0 : cp.ndarray) -> None:
    del v0
    return 
def method543(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249476:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method540(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[249368:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[249372:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 249376 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[249408:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 249412 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 249420 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method534(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method535(v0, v49)
        case US5_1(): # Preflop
            method536(v0)
        case US5_2(v50): # River
            method537(v0, v50)
        case US5_3(v51): # Turn
            method538(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method541(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method542(v0)
        case US1_1(): # A_Fold
            del v8
            return method542(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method543(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method531(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method532(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method533(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method533(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method539(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method533(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method533(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method540(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method533(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method533(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method544(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249488:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method545(v0 : cp.ndarray) -> None:
    del v0
    return 
def method547(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249556:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method548(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 249560 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method549(v0 : cp.ndarray) -> None:
    del v0
    return 
def method550(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 249560 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method551(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 249560 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method546(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[249492:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[249496:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 249504 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[249536:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 249540 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 249548 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method547(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method548(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method549(v0)
        case US5_2(v49): # River
            del v7
            return method550(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method551(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method552(v0 : cp.ndarray, v1 : u64) -> None:
    v2 = v0[249600:].view(cp.uint64)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method553(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[249608:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method554(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266000:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method555(v0 : cp.ndarray) -> None:
    del v0
    return 
def method557(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266004:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method559(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266068:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method560(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 266072 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method561(v0 : cp.ndarray) -> None:
    del v0
    return 
def method562(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 266072 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method563(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 266072 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method558(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[266008:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[266012:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 266016 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[266048:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 266052 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 266060 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method559(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method560(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method561(v0)
        case US5_2(v49): # River
            del v7
            return method562(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method563(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method564(v0 : cp.ndarray) -> None:
    del v0
    return 
def method566(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266112:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method567(v0 : cp.ndarray) -> None:
    del v0
    return 
def method568(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266116:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method565(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5, v8 : US1) -> None:
    v9 = v0[266008:].view(cp.int32)
    v9[0] = v1
    del v1, v9
    v10 = v0[266012:].view(cp.bool_)
    v10[0] = v2
    del v2, v10
    v11 = 0
    while method55(v11):
        v13 = u64(v11)
        v14 = v13 * 16
        del v13
        v15 = 266016 + v14
        del v14
        v16 = v0[v15:].view(cp.uint8)
        del v15
        v17 = 0 <= v11
        if v17:
            v18 = v11 < 2
            v19 = v18
        else:
            v19 = False
        del v17
        v20 = v19 == False
        if v20:
            v21 = "The read index needs to be in range for the static array."
            assert v19, v21
            del v21
        else:
            pass
        del v19, v20
        v22 = v3[v11]
        method181(v16, v22)
        del v16, v22
        v11 += 1 
    del v3, v11
    v23 = v0[266048:].view(cp.int32)
    v23[0] = v4
    del v4, v23
    v24 = 0
    while method55(v24):
        v26 = u64(v24)
        v27 = v26 * 4
        del v26
        v28 = 266052 + v27
        del v27
        v29 = v0[v28:].view(cp.uint8)
        del v28
        v30 = 0 <= v24
        if v30:
            v31 = v24 < 2
            v32 = v31
        else:
            v32 = False
        del v30
        v33 = v32 == False
        if v33:
            v34 = "The read index needs to be in range for the static array."
            assert v32, v34
            del v34
        else:
            pass
        del v32, v33
        v35 = v5[v24]
        method49(v29, v35)
        del v29, v35
        v24 += 1 
    del v5, v24
    v36 = 0
    while method55(v36):
        v38 = u64(v36)
        v39 = v38 * 4
        del v38
        v40 = 266060 + v39
        del v39
        v41 = v0[v40:].view(cp.uint8)
        del v40
        v42 = 0 <= v36
        if v42:
            v43 = v36 < 2
            v44 = v43
        else:
            v44 = False
        del v42
        v45 = v44 == False
        if v45:
            v46 = "The read index needs to be in range for the static array."
            assert v44, v46
            del v46
        else:
            pass
        del v44, v45
        v47 = v6[v36]
        method49(v41, v47)
        del v41, v47
        v36 += 1 
    del v6, v36
    v48 = v7.tag
    method559(v0, v48)
    del v48
    match v7:
        case US5_0(v49): # Flop
            method560(v0, v49)
        case US5_1(): # Preflop
            method561(v0)
        case US5_2(v50): # River
            method562(v0, v50)
        case US5_3(v51): # Turn
            method563(v0, v51)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v7
    v52 = v8.tag
    method566(v0, v52)
    del v52
    match v8:
        case US1_0(): # A_Call
            del v8
            return method567(v0)
        case US1_1(): # A_Fold
            del v8
            return method567(v0)
        case US1_2(v53): # A_Raise
            del v8
            return method568(v0, v53)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method556(v0 : cp.ndarray, v1 : US4) -> None:
    v2 = v1.tag
    method557(v0, v2)
    del v2
    match v1:
        case US4_0(v3, v4, v5, v6, v7, v8, v9): # G_Flop
            del v1
            return method558(v0, v3, v4, v5, v6, v7, v8, v9)
        case US4_1(v10, v11, v12, v13, v14, v15, v16): # G_Fold
            del v1
            return method558(v0, v10, v11, v12, v13, v14, v15, v16)
        case US4_2(): # G_Preflop
            del v1
            return method564(v0)
        case US4_3(v17, v18, v19, v20, v21, v22, v23): # G_River
            del v1
            return method558(v0, v17, v18, v19, v20, v21, v22, v23)
        case US4_4(v24, v25, v26, v27, v28, v29, v30): # G_Round
            del v1
            return method558(v0, v24, v25, v26, v27, v28, v29, v30)
        case US4_5(v31, v32, v33, v34, v35, v36, v37, v38): # G_Round'
            del v1
            return method565(v0, v31, v32, v33, v34, v35, v36, v37, v38)
        case US4_6(v39, v40, v41, v42, v43, v44, v45): # G_Showdown
            del v1
            return method558(v0, v39, v40, v41, v42, v43, v44, v45)
        case US4_7(v46, v47, v48, v49, v50, v51, v52): # G_Turn
            del v1
            return method558(v0, v46, v47, v48, v49, v50, v51, v52)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method569(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266128:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method570(v0 : cp.ndarray) -> None:
    del v0
    return 
def method572(v0 : cp.ndarray, v1 : i32) -> None:
    v2 = v0[266196:].view(cp.int32)
    del v0
    v2[0] = v1
    del v1, v2
    return 
def method573(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method184(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 266200 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 3
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method574(v0 : cp.ndarray) -> None:
    del v0
    return 
def method575(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method175(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 266200 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 5
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method576(v0 : cp.ndarray, v1 : static_array) -> None:
    v2 = 0
    while method188(v2):
        v4 = u64(v2)
        v5 = v4 * 8
        del v4
        v6 = 266200 + v5
        del v5
        v7 = v0[v6:].view(cp.uint8)
        del v6
        v8 = 0 <= v2
        if v8:
            v9 = v2 < 4
            v10 = v9
        else:
            v10 = False
        del v8
        v11 = v10 == False
        if v11:
            v12 = "The read index needs to be in range for the static array."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13, v14 = v1[v2]
        method167(v7, v13, v14)
        del v7, v13, v14
        v2 += 1 
    del v0, v1, v2
    return 
def method571(v0 : cp.ndarray, v1 : i32, v2 : bool, v3 : static_array, v4 : i32, v5 : static_array, v6 : static_array, v7 : US5) -> None:
    v8 = v0[266132:].view(cp.int32)
    v8[0] = v1
    del v1, v8
    v9 = v0[266136:].view(cp.bool_)
    v9[0] = v2
    del v2, v9
    v10 = 0
    while method55(v10):
        v12 = u64(v10)
        v13 = v12 * 16
        del v12
        v14 = 266144 + v13
        del v13
        v15 = v0[v14:].view(cp.uint8)
        del v14
        v16 = 0 <= v10
        if v16:
            v17 = v10 < 2
            v18 = v17
        else:
            v18 = False
        del v16
        v19 = v18 == False
        if v19:
            v20 = "The read index needs to be in range for the static array."
            assert v18, v20
            del v20
        else:
            pass
        del v18, v19
        v21 = v3[v10]
        method181(v15, v21)
        del v15, v21
        v10 += 1 
    del v3, v10
    v22 = v0[266176:].view(cp.int32)
    v22[0] = v4
    del v4, v22
    v23 = 0
    while method55(v23):
        v25 = u64(v23)
        v26 = v25 * 4
        del v25
        v27 = 266180 + v26
        del v26
        v28 = v0[v27:].view(cp.uint8)
        del v27
        v29 = 0 <= v23
        if v29:
            v30 = v23 < 2
            v31 = v30
        else:
            v31 = False
        del v29
        v32 = v31 == False
        if v32:
            v33 = "The read index needs to be in range for the static array."
            assert v31, v33
            del v33
        else:
            pass
        del v31, v32
        v34 = v5[v23]
        method49(v28, v34)
        del v28, v34
        v23 += 1 
    del v5, v23
    v35 = 0
    while method55(v35):
        v37 = u64(v35)
        v38 = v37 * 4
        del v37
        v39 = 266188 + v38
        del v38
        v40 = v0[v39:].view(cp.uint8)
        del v39
        v41 = 0 <= v35
        if v41:
            v42 = v35 < 2
            v43 = v42
        else:
            v43 = False
        del v41
        v44 = v43 == False
        if v44:
            v45 = "The read index needs to be in range for the static array."
            assert v43, v45
            del v45
        else:
            pass
        del v43, v44
        v46 = v6[v35]
        method49(v40, v46)
        del v40, v46
        v35 += 1 
    del v6, v35
    v47 = v7.tag
    method572(v0, v47)
    del v47
    match v7:
        case US5_0(v48): # Flop
            del v7
            return method573(v0, v48)
        case US5_1(): # Preflop
            del v7
            return method574(v0)
        case US5_2(v49): # River
            del v7
            return method575(v0, v49)
        case US5_3(v50): # Turn
            del v7
            return method576(v0, v50)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method163(v0 : cp.ndarray, v1 : u64, v2 : static_array_list, v3 : US3, v4 : static_array, v5 : US6, v6 : u64, v7 : static_array_list, v8 : US3, v9 : static_array, v10 : US6, v11 : u64, v12 : static_array_list, v13 : US3, v14 : static_array, v15 : US6, v16 : u64, v17 : static_array_list, v18 : US3, v19 : static_array, v20 : US6, v21 : u64, v22 : static_array_list, v23 : US3, v24 : static_array, v25 : US6, v26 : u64, v27 : static_array_list, v28 : US3, v29 : static_array, v30 : US6, v31 : u64, v32 : static_array_list, v33 : US3, v34 : static_array, v35 : US6, v36 : u64, v37 : static_array_list, v38 : US3, v39 : static_array, v40 : US6, v41 : u64, v42 : static_array_list, v43 : US3, v44 : static_array, v45 : US6, v46 : u64, v47 : static_array_list, v48 : US3, v49 : static_array, v50 : US6, v51 : u64, v52 : static_array_list, v53 : US3, v54 : static_array, v55 : US6, v56 : u64, v57 : static_array_list, v58 : US3, v59 : static_array, v60 : US6, v61 : u64, v62 : static_array_list, v63 : US3, v64 : static_array, v65 : US6, v66 : u64, v67 : static_array_list, v68 : US3, v69 : static_array, v70 : US6, v71 : u64, v72 : static_array_list, v73 : US3, v74 : static_array, v75 : US6, v76 : u64, v77 : static_array_list, v78 : US3, v79 : static_array, v80 : US6) -> None:
    method164(v0, v1)
    del v1
    v81 = v2.length
    method53(v0, v81)
    del v81
    v82 = v2.length
    v83 = 0
    while method10(v82, v83):
        v85 = u64(v83)
        v86 = v85 * 128
        del v85
        v87 = 16 + v86
        del v86
        v88 = v0[v87:].view(cp.uint8)
        del v87
        v89 = 0 <= v83
        if v89:
            v90 = v2.length
            v91 = v83 < v90
            del v90
            v92 = v91
        else:
            v92 = False
        del v89
        v93 = v92 == False
        if v93:
            v94 = "The read index needs to be in range for the static array list."
            assert v92, v94
            del v94
        else:
            pass
        del v92, v93
        v95 = v2[v83]
        method165(v88, v95)
        del v88, v95
        v83 += 1 
    del v2, v82, v83
    v96 = v3.tag
    method176(v0, v96)
    del v96
    match v3:
        case US3_0(): # None
            method177(v0)
        case US3_1(v97): # Some
            method178(v0, v97)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v3
    v98 = 0
    while method55(v98):
        v100 = u64(v98)
        v101 = v100 * 4
        del v100
        v102 = 16520 + v101
        del v101
        v103 = v0[v102:].view(cp.uint8)
        del v102
        v104 = 0 <= v98
        if v104:
            v105 = v98 < 2
            v106 = v105
        else:
            v106 = False
        del v104
        v107 = v106 == False
        if v107:
            v108 = "The read index needs to be in range for the static array."
            assert v106, v108
            del v108
        else:
            pass
        del v106, v107
        v109 = v4[v98]
        method56(v103, v109)
        del v103, v109
        v98 += 1 
    del v4, v98
    v110 = v5.tag
    method194(v0, v110)
    del v110
    match v5:
        case US6_0(): # GameNotStarted
            method195(v0)
        case US6_1(v111, v112, v113, v114, v115, v116, v117): # GameOver
            method196(v0, v111, v112, v113, v114, v115, v116, v117)
        case US6_2(v118, v119, v120, v121, v122, v123, v124): # WaitingForActionFromPlayerId
            method196(v0, v118, v119, v120, v121, v122, v123, v124)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v5
    method202(v0, v6)
    del v6
    v125 = v7.length
    method203(v0, v125)
    del v125
    v126 = v7.length
    v127 = 0
    while method10(v126, v127):
        v129 = u64(v127)
        v130 = v129 * 128
        del v129
        v131 = 16656 + v130
        del v130
        v132 = v0[v131:].view(cp.uint8)
        del v131
        v133 = 0 <= v127
        if v133:
            v134 = v7.length
            v135 = v127 < v134
            del v134
            v136 = v135
        else:
            v136 = False
        del v133
        v137 = v136 == False
        if v137:
            v138 = "The read index needs to be in range for the static array list."
            assert v136, v138
            del v138
        else:
            pass
        del v136, v137
        v139 = v7[v127]
        method165(v132, v139)
        del v132, v139
        v127 += 1 
    del v7, v126, v127
    v140 = v8.tag
    method204(v0, v140)
    del v140
    match v8:
        case US3_0(): # None
            method205(v0)
        case US3_1(v141): # Some
            method206(v0, v141)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v8
    v142 = 0
    while method55(v142):
        v144 = u64(v142)
        v145 = v144 * 4
        del v144
        v146 = 33160 + v145
        del v145
        v147 = v0[v146:].view(cp.uint8)
        del v146
        v148 = 0 <= v142
        if v148:
            v149 = v142 < 2
            v150 = v149
        else:
            v150 = False
        del v148
        v151 = v150 == False
        if v151:
            v152 = "The read index needs to be in range for the static array."
            assert v150, v152
            del v152
        else:
            pass
        del v150, v151
        v153 = v9[v142]
        method56(v147, v153)
        del v147, v153
        v142 += 1 
    del v9, v142
    v154 = v10.tag
    method219(v0, v154)
    del v154
    match v10:
        case US6_0(): # GameNotStarted
            method220(v0)
        case US6_1(v155, v156, v157, v158, v159, v160, v161): # GameOver
            method221(v0, v155, v156, v157, v158, v159, v160, v161)
        case US6_2(v162, v163, v164, v165, v166, v167, v168): # WaitingForActionFromPlayerId
            method221(v0, v162, v163, v164, v165, v166, v167, v168)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v10
    method227(v0, v11)
    del v11
    v169 = v12.length
    method228(v0, v169)
    del v169
    v170 = v12.length
    v171 = 0
    while method10(v170, v171):
        v173 = u64(v171)
        v174 = v173 * 128
        del v173
        v175 = 33296 + v174
        del v174
        v176 = v0[v175:].view(cp.uint8)
        del v175
        v177 = 0 <= v171
        if v177:
            v178 = v12.length
            v179 = v171 < v178
            del v178
            v180 = v179
        else:
            v180 = False
        del v177
        v181 = v180 == False
        if v181:
            v182 = "The read index needs to be in range for the static array list."
            assert v180, v182
            del v182
        else:
            pass
        del v180, v181
        v183 = v12[v171]
        method165(v176, v183)
        del v176, v183
        v171 += 1 
    del v12, v170, v171
    v184 = v13.tag
    method229(v0, v184)
    del v184
    match v13:
        case US3_0(): # None
            method230(v0)
        case US3_1(v185): # Some
            method231(v0, v185)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v13
    v186 = 0
    while method55(v186):
        v188 = u64(v186)
        v189 = v188 * 4
        del v188
        v190 = 49800 + v189
        del v189
        v191 = v0[v190:].view(cp.uint8)
        del v190
        v192 = 0 <= v186
        if v192:
            v193 = v186 < 2
            v194 = v193
        else:
            v194 = False
        del v192
        v195 = v194 == False
        if v195:
            v196 = "The read index needs to be in range for the static array."
            assert v194, v196
            del v196
        else:
            pass
        del v194, v195
        v197 = v14[v186]
        method56(v191, v197)
        del v191, v197
        v186 += 1 
    del v14, v186
    v198 = v15.tag
    method244(v0, v198)
    del v198
    match v15:
        case US6_0(): # GameNotStarted
            method245(v0)
        case US6_1(v199, v200, v201, v202, v203, v204, v205): # GameOver
            method246(v0, v199, v200, v201, v202, v203, v204, v205)
        case US6_2(v206, v207, v208, v209, v210, v211, v212): # WaitingForActionFromPlayerId
            method246(v0, v206, v207, v208, v209, v210, v211, v212)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v15
    method252(v0, v16)
    del v16
    v213 = v17.length
    method253(v0, v213)
    del v213
    v214 = v17.length
    v215 = 0
    while method10(v214, v215):
        v217 = u64(v215)
        v218 = v217 * 128
        del v217
        v219 = 49936 + v218
        del v218
        v220 = v0[v219:].view(cp.uint8)
        del v219
        v221 = 0 <= v215
        if v221:
            v222 = v17.length
            v223 = v215 < v222
            del v222
            v224 = v223
        else:
            v224 = False
        del v221
        v225 = v224 == False
        if v225:
            v226 = "The read index needs to be in range for the static array list."
            assert v224, v226
            del v226
        else:
            pass
        del v224, v225
        v227 = v17[v215]
        method165(v220, v227)
        del v220, v227
        v215 += 1 
    del v17, v214, v215
    v228 = v18.tag
    method254(v0, v228)
    del v228
    match v18:
        case US3_0(): # None
            method255(v0)
        case US3_1(v229): # Some
            method256(v0, v229)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v18
    v230 = 0
    while method55(v230):
        v232 = u64(v230)
        v233 = v232 * 4
        del v232
        v234 = 66440 + v233
        del v233
        v235 = v0[v234:].view(cp.uint8)
        del v234
        v236 = 0 <= v230
        if v236:
            v237 = v230 < 2
            v238 = v237
        else:
            v238 = False
        del v236
        v239 = v238 == False
        if v239:
            v240 = "The read index needs to be in range for the static array."
            assert v238, v240
            del v240
        else:
            pass
        del v238, v239
        v241 = v19[v230]
        method56(v235, v241)
        del v235, v241
        v230 += 1 
    del v19, v230
    v242 = v20.tag
    method269(v0, v242)
    del v242
    match v20:
        case US6_0(): # GameNotStarted
            method270(v0)
        case US6_1(v243, v244, v245, v246, v247, v248, v249): # GameOver
            method271(v0, v243, v244, v245, v246, v247, v248, v249)
        case US6_2(v250, v251, v252, v253, v254, v255, v256): # WaitingForActionFromPlayerId
            method271(v0, v250, v251, v252, v253, v254, v255, v256)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v20
    method277(v0, v21)
    del v21
    v257 = v22.length
    method278(v0, v257)
    del v257
    v258 = v22.length
    v259 = 0
    while method10(v258, v259):
        v261 = u64(v259)
        v262 = v261 * 128
        del v261
        v263 = 66576 + v262
        del v262
        v264 = v0[v263:].view(cp.uint8)
        del v263
        v265 = 0 <= v259
        if v265:
            v266 = v22.length
            v267 = v259 < v266
            del v266
            v268 = v267
        else:
            v268 = False
        del v265
        v269 = v268 == False
        if v269:
            v270 = "The read index needs to be in range for the static array list."
            assert v268, v270
            del v270
        else:
            pass
        del v268, v269
        v271 = v22[v259]
        method165(v264, v271)
        del v264, v271
        v259 += 1 
    del v22, v258, v259
    v272 = v23.tag
    method279(v0, v272)
    del v272
    match v23:
        case US3_0(): # None
            method280(v0)
        case US3_1(v273): # Some
            method281(v0, v273)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v23
    v274 = 0
    while method55(v274):
        v276 = u64(v274)
        v277 = v276 * 4
        del v276
        v278 = 83080 + v277
        del v277
        v279 = v0[v278:].view(cp.uint8)
        del v278
        v280 = 0 <= v274
        if v280:
            v281 = v274 < 2
            v282 = v281
        else:
            v282 = False
        del v280
        v283 = v282 == False
        if v283:
            v284 = "The read index needs to be in range for the static array."
            assert v282, v284
            del v284
        else:
            pass
        del v282, v283
        v285 = v24[v274]
        method56(v279, v285)
        del v279, v285
        v274 += 1 
    del v24, v274
    v286 = v25.tag
    method294(v0, v286)
    del v286
    match v25:
        case US6_0(): # GameNotStarted
            method295(v0)
        case US6_1(v287, v288, v289, v290, v291, v292, v293): # GameOver
            method296(v0, v287, v288, v289, v290, v291, v292, v293)
        case US6_2(v294, v295, v296, v297, v298, v299, v300): # WaitingForActionFromPlayerId
            method296(v0, v294, v295, v296, v297, v298, v299, v300)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v25
    method302(v0, v26)
    del v26
    v301 = v27.length
    method303(v0, v301)
    del v301
    v302 = v27.length
    v303 = 0
    while method10(v302, v303):
        v305 = u64(v303)
        v306 = v305 * 128
        del v305
        v307 = 83216 + v306
        del v306
        v308 = v0[v307:].view(cp.uint8)
        del v307
        v309 = 0 <= v303
        if v309:
            v310 = v27.length
            v311 = v303 < v310
            del v310
            v312 = v311
        else:
            v312 = False
        del v309
        v313 = v312 == False
        if v313:
            v314 = "The read index needs to be in range for the static array list."
            assert v312, v314
            del v314
        else:
            pass
        del v312, v313
        v315 = v27[v303]
        method165(v308, v315)
        del v308, v315
        v303 += 1 
    del v27, v302, v303
    v316 = v28.tag
    method304(v0, v316)
    del v316
    match v28:
        case US3_0(): # None
            method305(v0)
        case US3_1(v317): # Some
            method306(v0, v317)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v28
    v318 = 0
    while method55(v318):
        v320 = u64(v318)
        v321 = v320 * 4
        del v320
        v322 = 99720 + v321
        del v321
        v323 = v0[v322:].view(cp.uint8)
        del v322
        v324 = 0 <= v318
        if v324:
            v325 = v318 < 2
            v326 = v325
        else:
            v326 = False
        del v324
        v327 = v326 == False
        if v327:
            v328 = "The read index needs to be in range for the static array."
            assert v326, v328
            del v328
        else:
            pass
        del v326, v327
        v329 = v29[v318]
        method56(v323, v329)
        del v323, v329
        v318 += 1 
    del v29, v318
    v330 = v30.tag
    method319(v0, v330)
    del v330
    match v30:
        case US6_0(): # GameNotStarted
            method320(v0)
        case US6_1(v331, v332, v333, v334, v335, v336, v337): # GameOver
            method321(v0, v331, v332, v333, v334, v335, v336, v337)
        case US6_2(v338, v339, v340, v341, v342, v343, v344): # WaitingForActionFromPlayerId
            method321(v0, v338, v339, v340, v341, v342, v343, v344)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v30
    method327(v0, v31)
    del v31
    v345 = v32.length
    method328(v0, v345)
    del v345
    v346 = v32.length
    v347 = 0
    while method10(v346, v347):
        v349 = u64(v347)
        v350 = v349 * 128
        del v349
        v351 = 99856 + v350
        del v350
        v352 = v0[v351:].view(cp.uint8)
        del v351
        v353 = 0 <= v347
        if v353:
            v354 = v32.length
            v355 = v347 < v354
            del v354
            v356 = v355
        else:
            v356 = False
        del v353
        v357 = v356 == False
        if v357:
            v358 = "The read index needs to be in range for the static array list."
            assert v356, v358
            del v358
        else:
            pass
        del v356, v357
        v359 = v32[v347]
        method165(v352, v359)
        del v352, v359
        v347 += 1 
    del v32, v346, v347
    v360 = v33.tag
    method329(v0, v360)
    del v360
    match v33:
        case US3_0(): # None
            method330(v0)
        case US3_1(v361): # Some
            method331(v0, v361)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v33
    v362 = 0
    while method55(v362):
        v364 = u64(v362)
        v365 = v364 * 4
        del v364
        v366 = 116360 + v365
        del v365
        v367 = v0[v366:].view(cp.uint8)
        del v366
        v368 = 0 <= v362
        if v368:
            v369 = v362 < 2
            v370 = v369
        else:
            v370 = False
        del v368
        v371 = v370 == False
        if v371:
            v372 = "The read index needs to be in range for the static array."
            assert v370, v372
            del v372
        else:
            pass
        del v370, v371
        v373 = v34[v362]
        method56(v367, v373)
        del v367, v373
        v362 += 1 
    del v34, v362
    v374 = v35.tag
    method344(v0, v374)
    del v374
    match v35:
        case US6_0(): # GameNotStarted
            method345(v0)
        case US6_1(v375, v376, v377, v378, v379, v380, v381): # GameOver
            method346(v0, v375, v376, v377, v378, v379, v380, v381)
        case US6_2(v382, v383, v384, v385, v386, v387, v388): # WaitingForActionFromPlayerId
            method346(v0, v382, v383, v384, v385, v386, v387, v388)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v35
    method352(v0, v36)
    del v36
    v389 = v37.length
    method353(v0, v389)
    del v389
    v390 = v37.length
    v391 = 0
    while method10(v390, v391):
        v393 = u64(v391)
        v394 = v393 * 128
        del v393
        v395 = 116496 + v394
        del v394
        v396 = v0[v395:].view(cp.uint8)
        del v395
        v397 = 0 <= v391
        if v397:
            v398 = v37.length
            v399 = v391 < v398
            del v398
            v400 = v399
        else:
            v400 = False
        del v397
        v401 = v400 == False
        if v401:
            v402 = "The read index needs to be in range for the static array list."
            assert v400, v402
            del v402
        else:
            pass
        del v400, v401
        v403 = v37[v391]
        method165(v396, v403)
        del v396, v403
        v391 += 1 
    del v37, v390, v391
    v404 = v38.tag
    method354(v0, v404)
    del v404
    match v38:
        case US3_0(): # None
            method355(v0)
        case US3_1(v405): # Some
            method356(v0, v405)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v38
    v406 = 0
    while method55(v406):
        v408 = u64(v406)
        v409 = v408 * 4
        del v408
        v410 = 133000 + v409
        del v409
        v411 = v0[v410:].view(cp.uint8)
        del v410
        v412 = 0 <= v406
        if v412:
            v413 = v406 < 2
            v414 = v413
        else:
            v414 = False
        del v412
        v415 = v414 == False
        if v415:
            v416 = "The read index needs to be in range for the static array."
            assert v414, v416
            del v416
        else:
            pass
        del v414, v415
        v417 = v39[v406]
        method56(v411, v417)
        del v411, v417
        v406 += 1 
    del v39, v406
    v418 = v40.tag
    method369(v0, v418)
    del v418
    match v40:
        case US6_0(): # GameNotStarted
            method370(v0)
        case US6_1(v419, v420, v421, v422, v423, v424, v425): # GameOver
            method371(v0, v419, v420, v421, v422, v423, v424, v425)
        case US6_2(v426, v427, v428, v429, v430, v431, v432): # WaitingForActionFromPlayerId
            method371(v0, v426, v427, v428, v429, v430, v431, v432)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v40
    method377(v0, v41)
    del v41
    v433 = v42.length
    method378(v0, v433)
    del v433
    v434 = v42.length
    v435 = 0
    while method10(v434, v435):
        v437 = u64(v435)
        v438 = v437 * 128
        del v437
        v439 = 133136 + v438
        del v438
        v440 = v0[v439:].view(cp.uint8)
        del v439
        v441 = 0 <= v435
        if v441:
            v442 = v42.length
            v443 = v435 < v442
            del v442
            v444 = v443
        else:
            v444 = False
        del v441
        v445 = v444 == False
        if v445:
            v446 = "The read index needs to be in range for the static array list."
            assert v444, v446
            del v446
        else:
            pass
        del v444, v445
        v447 = v42[v435]
        method165(v440, v447)
        del v440, v447
        v435 += 1 
    del v42, v434, v435
    v448 = v43.tag
    method379(v0, v448)
    del v448
    match v43:
        case US3_0(): # None
            method380(v0)
        case US3_1(v449): # Some
            method381(v0, v449)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v43
    v450 = 0
    while method55(v450):
        v452 = u64(v450)
        v453 = v452 * 4
        del v452
        v454 = 149640 + v453
        del v453
        v455 = v0[v454:].view(cp.uint8)
        del v454
        v456 = 0 <= v450
        if v456:
            v457 = v450 < 2
            v458 = v457
        else:
            v458 = False
        del v456
        v459 = v458 == False
        if v459:
            v460 = "The read index needs to be in range for the static array."
            assert v458, v460
            del v460
        else:
            pass
        del v458, v459
        v461 = v44[v450]
        method56(v455, v461)
        del v455, v461
        v450 += 1 
    del v44, v450
    v462 = v45.tag
    method394(v0, v462)
    del v462
    match v45:
        case US6_0(): # GameNotStarted
            method395(v0)
        case US6_1(v463, v464, v465, v466, v467, v468, v469): # GameOver
            method396(v0, v463, v464, v465, v466, v467, v468, v469)
        case US6_2(v470, v471, v472, v473, v474, v475, v476): # WaitingForActionFromPlayerId
            method396(v0, v470, v471, v472, v473, v474, v475, v476)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v45
    method402(v0, v46)
    del v46
    v477 = v47.length
    method403(v0, v477)
    del v477
    v478 = v47.length
    v479 = 0
    while method10(v478, v479):
        v481 = u64(v479)
        v482 = v481 * 128
        del v481
        v483 = 149776 + v482
        del v482
        v484 = v0[v483:].view(cp.uint8)
        del v483
        v485 = 0 <= v479
        if v485:
            v486 = v47.length
            v487 = v479 < v486
            del v486
            v488 = v487
        else:
            v488 = False
        del v485
        v489 = v488 == False
        if v489:
            v490 = "The read index needs to be in range for the static array list."
            assert v488, v490
            del v490
        else:
            pass
        del v488, v489
        v491 = v47[v479]
        method165(v484, v491)
        del v484, v491
        v479 += 1 
    del v47, v478, v479
    v492 = v48.tag
    method404(v0, v492)
    del v492
    match v48:
        case US3_0(): # None
            method405(v0)
        case US3_1(v493): # Some
            method406(v0, v493)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v48
    v494 = 0
    while method55(v494):
        v496 = u64(v494)
        v497 = v496 * 4
        del v496
        v498 = 166280 + v497
        del v497
        v499 = v0[v498:].view(cp.uint8)
        del v498
        v500 = 0 <= v494
        if v500:
            v501 = v494 < 2
            v502 = v501
        else:
            v502 = False
        del v500
        v503 = v502 == False
        if v503:
            v504 = "The read index needs to be in range for the static array."
            assert v502, v504
            del v504
        else:
            pass
        del v502, v503
        v505 = v49[v494]
        method56(v499, v505)
        del v499, v505
        v494 += 1 
    del v49, v494
    v506 = v50.tag
    method419(v0, v506)
    del v506
    match v50:
        case US6_0(): # GameNotStarted
            method420(v0)
        case US6_1(v507, v508, v509, v510, v511, v512, v513): # GameOver
            method421(v0, v507, v508, v509, v510, v511, v512, v513)
        case US6_2(v514, v515, v516, v517, v518, v519, v520): # WaitingForActionFromPlayerId
            method421(v0, v514, v515, v516, v517, v518, v519, v520)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v50
    method427(v0, v51)
    del v51
    v521 = v52.length
    method428(v0, v521)
    del v521
    v522 = v52.length
    v523 = 0
    while method10(v522, v523):
        v525 = u64(v523)
        v526 = v525 * 128
        del v525
        v527 = 166416 + v526
        del v526
        v528 = v0[v527:].view(cp.uint8)
        del v527
        v529 = 0 <= v523
        if v529:
            v530 = v52.length
            v531 = v523 < v530
            del v530
            v532 = v531
        else:
            v532 = False
        del v529
        v533 = v532 == False
        if v533:
            v534 = "The read index needs to be in range for the static array list."
            assert v532, v534
            del v534
        else:
            pass
        del v532, v533
        v535 = v52[v523]
        method165(v528, v535)
        del v528, v535
        v523 += 1 
    del v52, v522, v523
    v536 = v53.tag
    method429(v0, v536)
    del v536
    match v53:
        case US3_0(): # None
            method430(v0)
        case US3_1(v537): # Some
            method431(v0, v537)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v53
    v538 = 0
    while method55(v538):
        v540 = u64(v538)
        v541 = v540 * 4
        del v540
        v542 = 182920 + v541
        del v541
        v543 = v0[v542:].view(cp.uint8)
        del v542
        v544 = 0 <= v538
        if v544:
            v545 = v538 < 2
            v546 = v545
        else:
            v546 = False
        del v544
        v547 = v546 == False
        if v547:
            v548 = "The read index needs to be in range for the static array."
            assert v546, v548
            del v548
        else:
            pass
        del v546, v547
        v549 = v54[v538]
        method56(v543, v549)
        del v543, v549
        v538 += 1 
    del v54, v538
    v550 = v55.tag
    method444(v0, v550)
    del v550
    match v55:
        case US6_0(): # GameNotStarted
            method445(v0)
        case US6_1(v551, v552, v553, v554, v555, v556, v557): # GameOver
            method446(v0, v551, v552, v553, v554, v555, v556, v557)
        case US6_2(v558, v559, v560, v561, v562, v563, v564): # WaitingForActionFromPlayerId
            method446(v0, v558, v559, v560, v561, v562, v563, v564)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v55
    method452(v0, v56)
    del v56
    v565 = v57.length
    method453(v0, v565)
    del v565
    v566 = v57.length
    v567 = 0
    while method10(v566, v567):
        v569 = u64(v567)
        v570 = v569 * 128
        del v569
        v571 = 183056 + v570
        del v570
        v572 = v0[v571:].view(cp.uint8)
        del v571
        v573 = 0 <= v567
        if v573:
            v574 = v57.length
            v575 = v567 < v574
            del v574
            v576 = v575
        else:
            v576 = False
        del v573
        v577 = v576 == False
        if v577:
            v578 = "The read index needs to be in range for the static array list."
            assert v576, v578
            del v578
        else:
            pass
        del v576, v577
        v579 = v57[v567]
        method165(v572, v579)
        del v572, v579
        v567 += 1 
    del v57, v566, v567
    v580 = v58.tag
    method454(v0, v580)
    del v580
    match v58:
        case US3_0(): # None
            method455(v0)
        case US3_1(v581): # Some
            method456(v0, v581)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v58
    v582 = 0
    while method55(v582):
        v584 = u64(v582)
        v585 = v584 * 4
        del v584
        v586 = 199560 + v585
        del v585
        v587 = v0[v586:].view(cp.uint8)
        del v586
        v588 = 0 <= v582
        if v588:
            v589 = v582 < 2
            v590 = v589
        else:
            v590 = False
        del v588
        v591 = v590 == False
        if v591:
            v592 = "The read index needs to be in range for the static array."
            assert v590, v592
            del v592
        else:
            pass
        del v590, v591
        v593 = v59[v582]
        method56(v587, v593)
        del v587, v593
        v582 += 1 
    del v59, v582
    v594 = v60.tag
    method469(v0, v594)
    del v594
    match v60:
        case US6_0(): # GameNotStarted
            method470(v0)
        case US6_1(v595, v596, v597, v598, v599, v600, v601): # GameOver
            method471(v0, v595, v596, v597, v598, v599, v600, v601)
        case US6_2(v602, v603, v604, v605, v606, v607, v608): # WaitingForActionFromPlayerId
            method471(v0, v602, v603, v604, v605, v606, v607, v608)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v60
    method477(v0, v61)
    del v61
    v609 = v62.length
    method478(v0, v609)
    del v609
    v610 = v62.length
    v611 = 0
    while method10(v610, v611):
        v613 = u64(v611)
        v614 = v613 * 128
        del v613
        v615 = 199696 + v614
        del v614
        v616 = v0[v615:].view(cp.uint8)
        del v615
        v617 = 0 <= v611
        if v617:
            v618 = v62.length
            v619 = v611 < v618
            del v618
            v620 = v619
        else:
            v620 = False
        del v617
        v621 = v620 == False
        if v621:
            v622 = "The read index needs to be in range for the static array list."
            assert v620, v622
            del v622
        else:
            pass
        del v620, v621
        v623 = v62[v611]
        method165(v616, v623)
        del v616, v623
        v611 += 1 
    del v62, v610, v611
    v624 = v63.tag
    method479(v0, v624)
    del v624
    match v63:
        case US3_0(): # None
            method480(v0)
        case US3_1(v625): # Some
            method481(v0, v625)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v63
    v626 = 0
    while method55(v626):
        v628 = u64(v626)
        v629 = v628 * 4
        del v628
        v630 = 216200 + v629
        del v629
        v631 = v0[v630:].view(cp.uint8)
        del v630
        v632 = 0 <= v626
        if v632:
            v633 = v626 < 2
            v634 = v633
        else:
            v634 = False
        del v632
        v635 = v634 == False
        if v635:
            v636 = "The read index needs to be in range for the static array."
            assert v634, v636
            del v636
        else:
            pass
        del v634, v635
        v637 = v64[v626]
        method56(v631, v637)
        del v631, v637
        v626 += 1 
    del v64, v626
    v638 = v65.tag
    method494(v0, v638)
    del v638
    match v65:
        case US6_0(): # GameNotStarted
            method495(v0)
        case US6_1(v639, v640, v641, v642, v643, v644, v645): # GameOver
            method496(v0, v639, v640, v641, v642, v643, v644, v645)
        case US6_2(v646, v647, v648, v649, v650, v651, v652): # WaitingForActionFromPlayerId
            method496(v0, v646, v647, v648, v649, v650, v651, v652)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v65
    method502(v0, v66)
    del v66
    v653 = v67.length
    method503(v0, v653)
    del v653
    v654 = v67.length
    v655 = 0
    while method10(v654, v655):
        v657 = u64(v655)
        v658 = v657 * 128
        del v657
        v659 = 216336 + v658
        del v658
        v660 = v0[v659:].view(cp.uint8)
        del v659
        v661 = 0 <= v655
        if v661:
            v662 = v67.length
            v663 = v655 < v662
            del v662
            v664 = v663
        else:
            v664 = False
        del v661
        v665 = v664 == False
        if v665:
            v666 = "The read index needs to be in range for the static array list."
            assert v664, v666
            del v666
        else:
            pass
        del v664, v665
        v667 = v67[v655]
        method165(v660, v667)
        del v660, v667
        v655 += 1 
    del v67, v654, v655
    v668 = v68.tag
    method504(v0, v668)
    del v668
    match v68:
        case US3_0(): # None
            method505(v0)
        case US3_1(v669): # Some
            method506(v0, v669)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v68
    v670 = 0
    while method55(v670):
        v672 = u64(v670)
        v673 = v672 * 4
        del v672
        v674 = 232840 + v673
        del v673
        v675 = v0[v674:].view(cp.uint8)
        del v674
        v676 = 0 <= v670
        if v676:
            v677 = v670 < 2
            v678 = v677
        else:
            v678 = False
        del v676
        v679 = v678 == False
        if v679:
            v680 = "The read index needs to be in range for the static array."
            assert v678, v680
            del v680
        else:
            pass
        del v678, v679
        v681 = v69[v670]
        method56(v675, v681)
        del v675, v681
        v670 += 1 
    del v69, v670
    v682 = v70.tag
    method519(v0, v682)
    del v682
    match v70:
        case US6_0(): # GameNotStarted
            method520(v0)
        case US6_1(v683, v684, v685, v686, v687, v688, v689): # GameOver
            method521(v0, v683, v684, v685, v686, v687, v688, v689)
        case US6_2(v690, v691, v692, v693, v694, v695, v696): # WaitingForActionFromPlayerId
            method521(v0, v690, v691, v692, v693, v694, v695, v696)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v70
    method527(v0, v71)
    del v71
    v697 = v72.length
    method528(v0, v697)
    del v697
    v698 = v72.length
    v699 = 0
    while method10(v698, v699):
        v701 = u64(v699)
        v702 = v701 * 128
        del v701
        v703 = 232976 + v702
        del v702
        v704 = v0[v703:].view(cp.uint8)
        del v703
        v705 = 0 <= v699
        if v705:
            v706 = v72.length
            v707 = v699 < v706
            del v706
            v708 = v707
        else:
            v708 = False
        del v705
        v709 = v708 == False
        if v709:
            v710 = "The read index needs to be in range for the static array list."
            assert v708, v710
            del v710
        else:
            pass
        del v708, v709
        v711 = v72[v699]
        method165(v704, v711)
        del v704, v711
        v699 += 1 
    del v72, v698, v699
    v712 = v73.tag
    method529(v0, v712)
    del v712
    match v73:
        case US3_0(): # None
            method530(v0)
        case US3_1(v713): # Some
            method531(v0, v713)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v73
    v714 = 0
    while method55(v714):
        v716 = u64(v714)
        v717 = v716 * 4
        del v716
        v718 = 249480 + v717
        del v717
        v719 = v0[v718:].view(cp.uint8)
        del v718
        v720 = 0 <= v714
        if v720:
            v721 = v714 < 2
            v722 = v721
        else:
            v722 = False
        del v720
        v723 = v722 == False
        if v723:
            v724 = "The read index needs to be in range for the static array."
            assert v722, v724
            del v724
        else:
            pass
        del v722, v723
        v725 = v74[v714]
        method56(v719, v725)
        del v719, v725
        v714 += 1 
    del v74, v714
    v726 = v75.tag
    method544(v0, v726)
    del v726
    match v75:
        case US6_0(): # GameNotStarted
            method545(v0)
        case US6_1(v727, v728, v729, v730, v731, v732, v733): # GameOver
            method546(v0, v727, v728, v729, v730, v731, v732, v733)
        case US6_2(v734, v735, v736, v737, v738, v739, v740): # WaitingForActionFromPlayerId
            method546(v0, v734, v735, v736, v737, v738, v739, v740)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v75
    method552(v0, v76)
    del v76
    v741 = v77.length
    method553(v0, v741)
    del v741
    v742 = v77.length
    v743 = 0
    while method10(v742, v743):
        v745 = u64(v743)
        v746 = v745 * 128
        del v745
        v747 = 249616 + v746
        del v746
        v748 = v0[v747:].view(cp.uint8)
        del v747
        v749 = 0 <= v743
        if v749:
            v750 = v77.length
            v751 = v743 < v750
            del v750
            v752 = v751
        else:
            v752 = False
        del v749
        v753 = v752 == False
        if v753:
            v754 = "The read index needs to be in range for the static array list."
            assert v752, v754
            del v754
        else:
            pass
        del v752, v753
        v755 = v77[v743]
        method165(v748, v755)
        del v748, v755
        v743 += 1 
    del v77, v742, v743
    v756 = v78.tag
    method554(v0, v756)
    del v756
    match v78:
        case US3_0(): # None
            method555(v0)
        case US3_1(v757): # Some
            method556(v0, v757)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v78
    v758 = 0
    while method55(v758):
        v760 = u64(v758)
        v761 = v760 * 4
        del v760
        v762 = 266120 + v761
        del v761
        v763 = v0[v762:].view(cp.uint8)
        del v762
        v764 = 0 <= v758
        if v764:
            v765 = v758 < 2
            v766 = v765
        else:
            v766 = False
        del v764
        v767 = v766 == False
        if v767:
            v768 = "The read index needs to be in range for the static array."
            assert v766, v768
            del v768
        else:
            pass
        del v766, v767
        v769 = v79[v758]
        method56(v763, v769)
        del v763, v769
        v758 += 1 
    del v79, v758
    v770 = v80.tag
    method569(v0, v770)
    del v770
    match v80:
        case US6_0(): # GameNotStarted
            del v80
            return method570(v0)
        case US6_1(v771, v772, v773, v774, v775, v776, v777): # GameOver
            del v80
            return method571(v0, v771, v772, v773, v774, v775, v776, v777)
        case US6_2(v778, v779, v780, v781, v782, v783, v784): # WaitingForActionFromPlayerId
            del v80
            return method571(v0, v778, v779, v780, v781, v782, v783, v784)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method582(v0 : u64) -> object:
    v1 = v0
    del v0
    return v1
def method581(v0 : u64) -> object:
    return method582(v0)
def method588() -> object:
    v0 = []
    return v0
def method587(v0 : US8) -> object:
    match v0:
        case US8_0(): # Ace
            del v0
            v1 = method588()
            v2 = "Ace"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US8_1(): # Eight
            del v0
            v4 = method588()
            v5 = "Eight"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US8_2(): # Five
            del v0
            v7 = method588()
            v8 = "Five"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US8_3(): # Four
            del v0
            v10 = method588()
            v11 = "Four"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US8_4(): # Jack
            del v0
            v13 = method588()
            v14 = "Jack"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case US8_5(): # King
            del v0
            v16 = method588()
            v17 = "King"
            v18 = [v17,v16]
            del v16, v17
            return v18
        case US8_6(): # Nine
            del v0
            v19 = method588()
            v20 = "Nine"
            v21 = [v20,v19]
            del v19, v20
            return v21
        case US8_7(): # Queen
            del v0
            v22 = method588()
            v23 = "Queen"
            v24 = [v23,v22]
            del v22, v23
            return v24
        case US8_8(): # Seven
            del v0
            v25 = method588()
            v26 = "Seven"
            v27 = [v26,v25]
            del v25, v26
            return v27
        case US8_9(): # Six
            del v0
            v28 = method588()
            v29 = "Six"
            v30 = [v29,v28]
            del v28, v29
            return v30
        case US8_10(): # Ten
            del v0
            v31 = method588()
            v32 = "Ten"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US8_11(): # Three
            del v0
            v34 = method588()
            v35 = "Three"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case US8_12(): # Two
            del v0
            v37 = method588()
            v38 = "Two"
            v39 = [v38,v37]
            del v37, v38
            return v39
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method589(v0 : US9) -> object:
    match v0:
        case US9_0(): # Clubs
            del v0
            v1 = method588()
            v2 = "Clubs"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US9_1(): # Diamonds
            del v0
            v4 = method588()
            v5 = "Diamonds"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US9_2(): # Hearts
            del v0
            v7 = method588()
            v8 = "Hearts"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US9_3(): # Spades
            del v0
            v10 = method588()
            v11 = "Spades"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method586(v0 : US8, v1 : US9) -> object:
    v2 = []
    v3 = method587(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method589(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method585(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method10(v2, v3):
        v5 = 0 <= v3
        if v5:
            v6 = v0.length
            v7 = v3 < v6
            del v6
            v8 = v7
        else:
            v8 = False
        del v5
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array list."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11, v12 = v0[v3]
        v13 = method586(v11, v12)
        del v11, v12
        v1.append(v13)
        del v13
        v3 += 1 
    del v0, v2, v3
    return v1
def method591(v0 : i32) -> object:
    v1 = v0
    del v0
    return v1
def method590(v0 : i32, v1 : i32) -> object:
    v2 = method591(v0)
    del v0
    v3 = method591(v1)
    del v1
    v4 = {'chips_won': v2, 'winner_id': v3}
    del v2, v3
    return v4
def method593(v0 : US1) -> object:
    match v0:
        case US1_0(): # A_Call
            del v0
            v1 = method588()
            v2 = "A_Call"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US1_1(): # A_Fold
            del v0
            v4 = method588()
            v5 = "A_Fold"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case US1_2(v7): # A_Raise
            del v0
            v8 = method591(v7)
            del v7
            v9 = "A_Raise"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method592(v0 : i32, v1 : US1) -> object:
    v2 = []
    v3 = method591(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method593(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method595(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method55(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9, v10 = v0[v2]
        v11 = method586(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method594(v0 : i32, v1 : static_array) -> object:
    v2 = []
    v3 = method591(v0)
    del v0
    v2.append(v3)
    del v3
    v4 = method595(v1)
    del v1
    v2.append(v4)
    del v4
    v5 = v2
    del v2
    return v5
def method599(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method175(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 5
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9, v10 = v0[v2]
        v11 = method586(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method598(v0 : US10) -> object:
    match v0:
        case US10_0(v1): # Flush
            del v0
            v2 = method599(v1)
            del v1
            v3 = "Flush"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US10_1(v5): # Full_House
            del v0
            v6 = method599(v5)
            del v5
            v7 = "Full_House"
            v8 = [v7,v6]
            del v6, v7
            return v8
        case US10_2(v9): # High_Card
            del v0
            v10 = method599(v9)
            del v9
            v11 = "High_Card"
            v12 = [v11,v10]
            del v10, v11
            return v12
        case US10_3(v13): # Pair
            del v0
            v14 = method599(v13)
            del v13
            v15 = "Pair"
            v16 = [v15,v14]
            del v14, v15
            return v16
        case US10_4(v17): # Quads
            del v0
            v18 = method599(v17)
            del v17
            v19 = "Quads"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US10_5(v21): # Straight
            del v0
            v22 = method599(v21)
            del v21
            v23 = "Straight"
            v24 = [v23,v22]
            del v22, v23
            return v24
        case US10_6(v25): # Straight_Flush
            del v0
            v26 = method599(v25)
            del v25
            v27 = "Straight_Flush"
            v28 = [v27,v26]
            del v26, v27
            return v28
        case US10_7(v29): # Triple
            del v0
            v30 = method599(v29)
            del v29
            v31 = "Triple"
            v32 = [v31,v30]
            del v30, v31
            return v32
        case US10_8(v33): # Two_Pair
            del v0
            v34 = method599(v33)
            del v33
            v35 = "Two_Pair"
            v36 = [v35,v34]
            del v34, v35
            return v36
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method597(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method55(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method598(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method596(v0 : i32, v1 : static_array, v2 : i32) -> object:
    v3 = method591(v0)
    del v0
    v4 = method597(v1)
    del v1
    v5 = method591(v2)
    del v2
    v6 = {'chips_won': v3, 'hands_shown': v4, 'winner_id': v5}
    del v3, v4, v5
    return v6
def method584(v0 : US7) -> object:
    match v0:
        case US7_0(v1): # CommunityCardsAre
            del v0
            v2 = method585(v1)
            del v1
            v3 = "CommunityCardsAre"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US7_1(v5, v6): # Fold
            del v0
            v7 = method590(v5, v6)
            del v5, v6
            v8 = "Fold"
            v9 = [v8,v7]
            del v7, v8
            return v9
        case US7_2(v10, v11): # PlayerAction
            del v0
            v12 = method592(v10, v11)
            del v10, v11
            v13 = "PlayerAction"
            v14 = [v13,v12]
            del v12, v13
            return v14
        case US7_3(v15, v16): # PlayerGotCards
            del v0
            v17 = method594(v15, v16)
            del v15, v16
            v18 = "PlayerGotCards"
            v19 = [v18,v17]
            del v17, v18
            return v19
        case US7_4(v20, v21, v22): # Showdown
            del v0
            v23 = method596(v20, v21, v22)
            del v20, v21, v22
            v24 = "Showdown"
            v25 = [v24,v23]
            del v23, v24
            return v25
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method583(v0 : static_array_list) -> object:
    v1 = []
    v2 = v0.length
    v3 = 0
    while method10(v2, v3):
        v5 = 0 <= v3
        if v5:
            v6 = v0.length
            v7 = v3 < v6
            del v6
            v8 = v7
        else:
            v8 = False
        del v5
        v9 = v8 == False
        if v9:
            v10 = "The read index needs to be in range for the static array list."
            assert v8, v10
            del v10
        else:
            pass
        del v8, v9
        v11 = v0[v3]
        v12 = method584(v11)
        del v11
        v1.append(v12)
        del v12
        v3 += 1 
    del v0, v2, v3
    return v1
def method580(v0 : u64, v1 : static_array_list) -> object:
    v2 = method581(v0)
    del v0
    v3 = method583(v1)
    del v1
    v4 = {'deck': v2, 'messages': v3}
    del v2, v3
    return v4
def method604(v0 : i32) -> object:
    v1 = method591(v0)
    del v0
    v2 = {'min_raise': v1}
    del v1
    return v2
def method605(v0 : bool) -> object:
    v1 = v0
    del v0
    return v1
def method606(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method55(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method595(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method607(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method55(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method591(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method609(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method184(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 3
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9, v10 = v0[v2]
        v11 = method586(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method610(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method188(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 4
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9, v10 = v0[v2]
        v11 = method586(v9, v10)
        del v9, v10
        v1.append(v11)
        del v11
        v2 += 1 
    del v0, v2
    return v1
def method608(v0 : US5) -> object:
    match v0:
        case US5_0(v1): # Flop
            del v0
            v2 = method609(v1)
            del v1
            v3 = "Flop"
            v4 = [v3,v2]
            del v2, v3
            return v4
        case US5_1(): # Preflop
            del v0
            v5 = method588()
            v6 = "Preflop"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case US5_2(v8): # River
            del v0
            v9 = method599(v8)
            del v8
            v10 = "River"
            v11 = [v10,v9]
            del v9, v10
            return v11
        case US5_3(v12): # Turn
            del v0
            v13 = method610(v12)
            del v12
            v14 = "Turn"
            v15 = [v14,v13]
            del v13, v14
            return v15
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method603(v0 : i32, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : static_array, v6 : US5) -> object:
    v7 = method604(v0)
    del v0
    v8 = method605(v1)
    del v1
    v9 = method606(v2)
    del v2
    v10 = method591(v3)
    del v3
    v11 = method607(v4)
    del v4
    v12 = method607(v5)
    del v5
    v13 = method608(v6)
    del v6
    v14 = {'config': v7, 'is_button_s_first_move': v8, 'pl_card': v9, 'player_turn': v10, 'pot': v11, 'stack': v12, 'street': v13}
    del v7, v8, v9, v10, v11, v12, v13
    return v14
def method611(v0 : i32, v1 : bool, v2 : static_array, v3 : i32, v4 : static_array, v5 : static_array, v6 : US5, v7 : US1) -> object:
    v8 = []
    v9 = method603(v0, v1, v2, v3, v4, v5, v6)
    del v0, v1, v2, v3, v4, v5, v6
    v8.append(v9)
    del v9
    v10 = method593(v7)
    del v7
    v8.append(v10)
    del v10
    v11 = v8
    del v8
    return v11
def method602(v0 : US4) -> object:
    match v0:
        case US4_0(v1, v2, v3, v4, v5, v6, v7): # G_Flop
            del v0
            v8 = method603(v1, v2, v3, v4, v5, v6, v7)
            del v1, v2, v3, v4, v5, v6, v7
            v9 = "G_Flop"
            v10 = [v9,v8]
            del v8, v9
            return v10
        case US4_1(v11, v12, v13, v14, v15, v16, v17): # G_Fold
            del v0
            v18 = method603(v11, v12, v13, v14, v15, v16, v17)
            del v11, v12, v13, v14, v15, v16, v17
            v19 = "G_Fold"
            v20 = [v19,v18]
            del v18, v19
            return v20
        case US4_2(): # G_Preflop
            del v0
            v21 = method588()
            v22 = "G_Preflop"
            v23 = [v22,v21]
            del v21, v22
            return v23
        case US4_3(v24, v25, v26, v27, v28, v29, v30): # G_River
            del v0
            v31 = method603(v24, v25, v26, v27, v28, v29, v30)
            del v24, v25, v26, v27, v28, v29, v30
            v32 = "G_River"
            v33 = [v32,v31]
            del v31, v32
            return v33
        case US4_4(v34, v35, v36, v37, v38, v39, v40): # G_Round
            del v0
            v41 = method603(v34, v35, v36, v37, v38, v39, v40)
            del v34, v35, v36, v37, v38, v39, v40
            v42 = "G_Round"
            v43 = [v42,v41]
            del v41, v42
            return v43
        case US4_5(v44, v45, v46, v47, v48, v49, v50, v51): # G_Round'
            del v0
            v52 = method611(v44, v45, v46, v47, v48, v49, v50, v51)
            del v44, v45, v46, v47, v48, v49, v50, v51
            v53 = "G_Round'"
            v54 = [v53,v52]
            del v52, v53
            return v54
        case US4_6(v55, v56, v57, v58, v59, v60, v61): # G_Showdown
            del v0
            v62 = method603(v55, v56, v57, v58, v59, v60, v61)
            del v55, v56, v57, v58, v59, v60, v61
            v63 = "G_Showdown"
            v64 = [v63,v62]
            del v62, v63
            return v64
        case US4_7(v65, v66, v67, v68, v69, v70, v71): # G_Turn
            del v0
            v72 = method603(v65, v66, v67, v68, v69, v70, v71)
            del v65, v66, v67, v68, v69, v70, v71
            v73 = "G_Turn"
            v74 = [v73,v72]
            del v72, v73
            return v74
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method601(v0 : US3) -> object:
    match v0:
        case US3_0(): # None
            del v0
            v1 = method588()
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US3_1(v4): # Some
            del v0
            v5 = method602(v4)
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method613(v0 : US2) -> object:
    match v0:
        case US2_0(): # Computer
            del v0
            v1 = method588()
            v2 = "Computer"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US2_1(): # Human
            del v0
            v4 = method588()
            v5 = "Human"
            v6 = [v5,v4]
            del v4, v5
            return v6
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method612(v0 : static_array) -> object:
    v1 = []
    v2 = 0
    while method55(v2):
        v4 = 0 <= v2
        if v4:
            v5 = v2 < 2
            v6 = v5
        else:
            v6 = False
        del v4
        v7 = v6 == False
        if v7:
            v8 = "The read index needs to be in range for the static array."
            assert v6, v8
            del v8
        else:
            pass
        del v6, v7
        v9 = v0[v2]
        v10 = method613(v9)
        del v9
        v1.append(v10)
        del v10
        v2 += 1 
    del v0, v2
    return v1
def method614(v0 : US6) -> object:
    match v0:
        case US6_0(): # GameNotStarted
            del v0
            v1 = method588()
            v2 = "GameNotStarted"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US6_1(v4, v5, v6, v7, v8, v9, v10): # GameOver
            del v0
            v11 = method603(v4, v5, v6, v7, v8, v9, v10)
            del v4, v5, v6, v7, v8, v9, v10
            v12 = "GameOver"
            v13 = [v12,v11]
            del v11, v12
            return v13
        case US6_2(v14, v15, v16, v17, v18, v19, v20): # WaitingForActionFromPlayerId
            del v0
            v21 = method603(v14, v15, v16, v17, v18, v19, v20)
            del v14, v15, v16, v17, v18, v19, v20
            v22 = "WaitingForActionFromPlayerId"
            v23 = [v22,v21]
            del v21, v22
            return v23
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method600(v0 : US3, v1 : static_array, v2 : US6) -> object:
    v3 = method601(v0)
    del v0
    v4 = method612(v1)
    del v1
    v5 = method614(v2)
    del v2
    v6 = {'game': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method579(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method580(v0, v1)
    del v0, v1
    v6 = method600(v2, v3, v4)
    del v2, v3, v4
    v7 = {'large': v5, 'small': v6}
    del v5, v6
    return v7
def method615(v0 : static_array_list, v1 : static_array, v2 : US6) -> object:
    v3 = method583(v0)
    del v0
    v4 = method612(v1)
    del v1
    v5 = method614(v2)
    del v2
    v6 = {'messages': v3, 'pl_type': v4, 'ui_game_state': v5}
    del v3, v4, v5
    return v6
def method578(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method579(v0, v1, v2, v3, v4)
    del v0, v2
    v6 = method615(v1, v3, v4)
    del v1, v3, v4
    v7 = {'game_state': v5, 'ui_state': v6}
    del v5, v6
    return v7
def method577(v0 : u64, v1 : static_array_list, v2 : US3, v3 : static_array, v4 : US6) -> object:
    v5 = method578(v0, v1, v2, v3, v4)
    del v0, v1, v2, v3, v4
    return v5
def main():
    v0 = Closure0()
    v1 = Closure1()
    v2 = collections.namedtuple("HU_Holdem_Game",['event_loop_gpu', 'init'])(v0, v1)
    del v0, v1
    return v2

if __name__ == '__main__': print(main())
