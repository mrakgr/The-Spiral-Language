kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class US0_0(NamedTuple): # Jack
    tag = 0
class US0_1(NamedTuple): # King
    tag = 1
class US0_2(NamedTuple): # Queen
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
def method0(v0 : i32) -> bool:
    v1 = v0 < 23
    del v0
    return v1
def method2(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method1(v0 : cp.ndarray, v1 : i32, v2 : i32) -> Tuple[u32, i32]:
    v3, v4, v5 = (v2, 0, 0)
    while method2(v1, v3):
        v7 = v0[v3].item()
        v8 = v7 == 1.0
        if v8:
            v10 = True
        else:
            v9 = v7 == 0.0
            v10 = v9
        del v8
        v11 = v10 == False
        if v11:
            v12 = "Unpickling failure. The int type should always be either be 1 or 0."
            assert v10, v12
            del v12
        else:
            pass
        del v10, v11
        v13 = v7 == 0.0
        del v7
        if v13:
            v15, v16 = v4, v5
        else:
            v14 = v5 + 1
            v15, v16 = v3, v14
        del v13
        v4 = v15
        del v15
        v5 = v16
        del v16
        v3 += 1 
    del v0, v1, v3
    v17 = v5 == 0
    if v17:
        v19 = True
    else:
        v18 = v5 == 1
        v19 = v18
    del v17
    v20 = v19 == False
    if v20:
        v21 = "Unpickling failure. Too many active indices in the one-hot vector."
        assert v19, v21
        del v21
    else:
        pass
    del v19, v20
    v22 = v4 - v2
    del v2, v4
    v23 = u32(v22)
    del v22
    return v23, v5
def main():
    v0 = US0_1()
    v1 = 8
    v2 = 5
    pass
    v3 = cp.empty(23,dtype=cp.float32)
    v4 = 0
    while method0(v4):
        assert 0 <= v4 < 23, 'Tensor range check'
        v3[v4] = 0.0
        v4 += 1 
    del v4
    v7 = v3[0:]
    v8 = v7
    v9 = u32(v2)
    del v2
    v10 = i32(v9)
    del v9
    v11 = v10 < 10
    v12 = v11 == False
    if v12:
        v13 = "Pickle failure. Int value out of bounds."
        assert v11, v13
        del v13
    else:
        pass
    del v11, v12
    v8[v10] = 1.0
    del v10
    v14 = u32(v1)
    del v1
    v15 = i32(v14)
    del v14
    v16 = v15 < 10
    v17 = v16 == False
    if v17:
        v18 = "Pickle failure. Int value out of bounds."
        assert v16, v18
        del v18
    else:
        pass
    del v16, v17
    v19 = 10 + v15
    del v15
    v8[v19] = 1.0
    del v19
    match v0:
        case US0_0(): # Jack
            v8[20] = 1.0
        case US0_1(): # King
            v8[21] = 1.0
        case US0_2(): # Queen
            v8[22] = 1.0
    del v0, v8
    v20 = 0
    print('[', end="")
    v22 = 0
    while method0(v22):
        v24 = v20
        v25 = v24 >= 100
        del v24
        if v25:
            v28 = " ..."
            print(v28, end="")
            del v28
            break
        else:
            pass
        del v25
        v29 = v22 == 0
        v30 = v29 != True
        del v29
        if v30:
            v33 = "; "
            print(v33, end="")
            del v33
        else:
            pass
        del v30
        v34 = v20 + 1
        v20 = v34
        del v34
        v35 = v3[v22].item()
        print("{:.6f}".format(v35), end="")
        del v35
        v22 += 1 
    del v20, v22
    print(']', end="")
    print()
    print()
    v38 = 0
    v39 = 1
    del v39
    v40 = 23
    del v40
    v42 = v3[v38:]
    v43 = v42
    del v3, v38
    v44 = 0
    v45 = 10
    v46, v47 = method1(v43, v45, v44)
    del v44, v45
    v48 = i32(v46)
    del v46
    v49 = 10
    v50 = 20
    v51, v52 = method1(v43, v50, v49)
    del v49, v50
    v53 = i32(v51)
    del v51
    v54 = v43[20].item()
    v55 = v54 == 1.0
    if v55:
        v57 = True
    else:
        v56 = v54 == 0.0
        v57 = v56
    del v54
    v58 = v57 == False
    if v58:
        v59 = "Unpickling failure. The unit type should always be either be 1 or 0."
        assert v57, v59
        del v59
    else:
        pass
    del v57, v58
    if v55:
        v60 = 1
    else:
        v60 = 0
    del v55
    v61 = v43[21].item()
    v62 = v61 == 1.0
    if v62:
        v64 = True
    else:
        v63 = v61 == 0.0
        v64 = v63
    del v61
    v65 = v64 == False
    if v65:
        v66 = "Unpickling failure. The unit type should always be either be 1 or 0."
        assert v64, v66
        del v66
    else:
        pass
    del v64, v65
    if v62:
        v67 = 1
    else:
        v67 = 0
    del v62
    v68 = v43[22].item()
    del v43
    v69 = v68 == 1.0
    if v69:
        v71 = True
    else:
        v70 = v68 == 0.0
        v71 = v70
    del v68
    v72 = v71 == False
    if v72:
        v73 = "Unpickling failure. The unit type should always be either be 1 or 0."
        assert v71, v73
        del v73
    else:
        pass
    del v71, v72
    if v69:
        v74 = 1
    else:
        v74 = 0
    del v69
    v75 = v67 == 1
    if v75:
        v78 = US0_1()
    else:
        v78 = US0_0()
    del v75
    v79 = v60 + v67
    del v60, v67
    v80 = v74 == 1
    if v80:
        v82 = US0_2()
    else:
        v82 = v78
    del v78, v80
    v83 = v79 + v74
    del v74, v79
    v84 = v83 == 0
    if v84:
        v86 = True
    else:
        v85 = v83 == 1
        v86 = v85
    del v84
    v87 = v86 == False
    if v87:
        v88 = "Unpickling failure. Only a single case of an union type should be active at most."
        assert v86, v88
        del v88
    else:
        pass
    del v86, v87
    v89 = v52 + v83
    del v52, v83
    v90 = v89 == 0
    if v90:
        v92 = True
    else:
        v91 = v89 == 2
        v92 = v91
    del v90
    v93 = v92 == False
    if v93:
        v94 = "Unpickling failure. Two sides of a pair should either all be active or inactive."
        assert v92, v94
        del v94
    else:
        pass
    del v92, v93
    v95 = v89 // 2
    del v89
    v96 = v47 + v95
    del v47, v95
    v97 = v96 == 0
    if v97:
        v99 = True
    else:
        v98 = v96 == 2
        v99 = v98
    del v97
    v100 = v99 == False
    if v100:
        v101 = "Unpickling failure. Two sides of a pair should either all be active or inactive."
        assert v99, v101
        del v101
    else:
        pass
    del v99, v100
    v102 = v96 // 2
    del v96
    v103 = v102 == 1
    del v102
    v104 = v103 == False
    if v104:
        v105 = "Invalid format detected during deserialization."
        assert v103, v105
        del v105
    else:
        pass
    del v103, v104
    print('{', end="")
    v109 = "card"
    print(v109, end="")
    del v109
    v112 = " = "
    print(v112, end="")
    del v112
    match v82:
        case US0_0(): # Jack
            v115 = "Jack"
            print(v115, end="")
            del v115
            v118 = "("
            print(v118, end="")
            del v118
            v121 = ")"
            print(v121, end="")
            del v121
        case US0_1(): # King
            v124 = "King"
            print(v124, end="")
            del v124
            v127 = "("
            print(v127, end="")
            del v127
            v130 = ")"
            print(v130, end="")
            del v130
        case US0_2(): # Queen
            v133 = "Queen"
            print(v133, end="")
            del v133
            v136 = "("
            print(v136, end="")
            del v136
            v139 = ")"
            print(v139, end="")
            del v139
    del v82
    v142 = "; "
    print(v142, end="")
    del v142
    v145 = "pot"
    print(v145, end="")
    del v145
    v148 = " = "
    print(v148, end="")
    del v148
    print(v53, end="")
    del v53
    v152 = "; "
    print(v152, end="")
    del v152
    v155 = "stack"
    print(v155, end="")
    del v155
    v158 = " = "
    print(v158, end="")
    del v158
    print(v48, end="")
    del v48
    print('}', end="")
    print()
    return 

if __name__ == '__main__': print(main())
