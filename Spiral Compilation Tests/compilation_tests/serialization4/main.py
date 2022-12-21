import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class US0_0(NamedTuple): # Call
    tag = 0
class US0_1(NamedTuple): # NoAction
    tag = 1
class US0_2(NamedTuple): # Raise
    v0 : u32
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
def method2(v0 : u32, v1 : np.ndarray, v2 : u32, v3 : u32, v4 : u32) -> Tuple[u32, u32]:
    v5 = v2 < v0
    if v5:
        del v5
        v6 = v2 + 1
        v7 = v1[v2]
        v8 = v7 == 0.0
        if v8:
            v15, v16 = v3, v4
        else:
            v9 = v7 == 1.0
            if v9:
                del v9
                v10 = v4 + 1
                v15, v16 = v2, v10
            else:
                del v9
                raise Exception("Unpickling failure. The int type must either be active or inactive.")
        del v2, v3, v4, v7, v8
        return method2(v0, v1, v6, v15, v16)
    else:
        del v0, v1, v2, v5
        return v3, v4
def method1(v0 : np.ndarray, v1 : u32, v2 : u32) -> Tuple[u32, u32]:
    v3 = 0
    v4 = 0
    v5, v6 = method2(v1, v0, v2, v3, v4)
    del v0, v1, v3, v4
    v7 = 1 < v6
    if v7:
        raise Exception("Unpickling failure. Too many active indices in the one-hot vector.")
    else:
        pass
    del v7
    v8 = v5 - v2
    del v2, v5
    return v8, v6
def method0() -> i32:
    v0 = 0
    v1 = 1
    v2 = 12
    v3 = 3
    v4 = 10
    v5 = US0_1()
    v6 = 5
    v7 = 5
    v8 = np.empty(73,dtype=np.float32)
    v8[:] = 0
    v9 = 0 <= v7
    if v9:
        v10 = v7 < 11
        v11 = v10
    else:
        v11 = False
    del v9
    if v11:
        v8[v7] = 1.0
    else:
        raise Exception("Value out of bounds.")
    del v11
    v12 = 0 <= v6
    if v12:
        v13 = v6 < 11
        v14 = v13
    else:
        v14 = False
    del v12
    if v14:
        v15 = 11 + v6
        v8[v15] = 1.0
        del v15
    else:
        raise Exception("Value out of bounds.")
    del v14
    v16 = 0 <= v4
    if v16:
        v17 = v4 < 11
        v18 = v17
    else:
        v18 = False
    del v16
    if v18:
        v19 = 22 + v4
        v8[v19] = 1.0
        del v19
    else:
        raise Exception("Value out of bounds.")
    del v18
    v20 = 0 <= v0
    if v20:
        v21 = v0 < 13
        v22 = v21
    else:
        v22 = False
    del v20
    if v22:
        v23 = 33 + v0
        v8[v23] = 1.0
        del v23
    else:
        raise Exception("Value out of bounds.")
    del v22
    v24 = 0 <= v1
    if v24:
        v25 = v1 < 4
        v26 = v25
    else:
        v26 = False
    del v24
    if v26:
        v27 = 46 + v1
        v8[v27] = 1.0
        del v27
    else:
        raise Exception("Value out of bounds.")
    del v26
    v28 = 0 <= v2
    if v28:
        v29 = v2 < 13
        v30 = v29
    else:
        v30 = False
    del v28
    if v30:
        v31 = 50 + v2
        v8[v31] = 1.0
        del v31
    else:
        raise Exception("Value out of bounds.")
    del v30
    v32 = 0 <= v3
    if v32:
        v33 = v3 < 4
        v34 = v33
    else:
        v34 = False
    del v32
    if v34:
        v35 = 63 + v3
        v8[v35] = 1.0
        del v35
    else:
        raise Exception("Value out of bounds.")
    del v34
    match v5:
        case US0_0(): # Call
            v8[67] = 1.0
        case US0_1(): # NoAction
            v8[68] = 1.0
        case US0_2(v36): # Raise
            v37 = 0 <= v36
            if v37:
                v38 = v36 < 4
                v39 = v38
            else:
                v39 = False
            del v37
            if v39:
                del v39
                v40 = 69 + v36
                del v36
                v8[v40] = 1.0
                del v40
            else:
                del v36, v39
                raise Exception("Value out of bounds.")
    v41 = 0
    v42 = 11
    v43, v44 = method1(v8, v42, v41)
    del v41, v42
    v45 = 11
    v46 = 22
    v47, v48 = method1(v8, v46, v45)
    del v45, v46
    v49 = 22
    v50 = 33
    v51, v52 = method1(v8, v50, v49)
    del v49, v50
    v53 = 33
    v54 = 46
    v55, v56 = method1(v8, v54, v53)
    del v53, v54
    v57 = 46
    v58 = 50
    v59, v60 = method1(v8, v58, v57)
    del v57, v58
    v61 = v56 + v60
    del v56, v60
    v62 = v61 == 1
    if v62:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v62
    v63 = v61 // 2
    del v61
    v64 = 50
    v65 = 63
    v66, v67 = method1(v8, v65, v64)
    del v64, v65
    v68 = 63
    v69 = 67
    v70, v71 = method1(v8, v69, v68)
    del v68, v69
    v72 = v67 + v71
    del v67, v71
    v73 = v72 == 1
    if v73:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v73
    v74 = v72 // 2
    del v72
    v75 = v63 + v74
    del v63, v74
    v76 = v75 == 1
    if v76:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v76
    v77 = v75 // 2
    del v75
    v78 = v8[67]
    v79 = v78 == 1.0
    if v79:
        v83 = 1
    else:
        v80 = v78 == 0.0
        if v80:
            del v80
            v83 = 0
        else:
            del v80
            raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
    del v78, v79
    v84 = v8[68]
    v85 = v84 == 1.0
    if v85:
        v89 = 1
    else:
        v86 = v84 == 0.0
        if v86:
            del v86
            v89 = 0
        else:
            del v86
            raise Exception("Unpickling failure. The unit type should always be either be active or inactive.")
    del v84, v85
    v90 = 69
    v91 = 73
    v92, v93 = method1(v8, v91, v90)
    del v8, v90, v91
    v94 = v89 == 1
    if v94:
        v97 = US0_1()
    else:
        v97 = US0_0()
    del v94
    v98 = v83 + v89
    del v83, v89
    v99 = v93 == 1
    if v99:
        v101 = US0_2(v92)
    else:
        v101 = v97
    del v92, v97, v99
    v102 = v98 + v93
    del v93, v98
    v103 = 1 < v102
    if v103:
        raise Exception("Unpickling failure. Only a single case of an union type should be active at most.")
    else:
        pass
    del v103
    v104 = v77 + v102
    del v77, v102
    v105 = v104 == 1
    if v105:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v105
    v106 = v104 // 2
    del v104
    v107 = v52 + v106
    del v52, v106
    v108 = v107 == 1
    if v108:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v108
    v109 = v107 // 2
    del v107
    v110 = v48 + v109
    del v48, v109
    v111 = v110 == 1
    if v111:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v111
    v112 = v110 // 2
    del v110
    v113 = v44 + v112
    del v44, v112
    v114 = v113 == 1
    if v114:
        raise Exception("Unpickling failure. Two sides of a pair should either all be active or inactive.")
    else:
        pass
    del v114
    v115 = v113 // 2
    del v113
    v116 = v115 == 1
    del v115
    v117 = v116 != True
    del v116
    if v117:
        raise Exception("Invalid format.")
    else:
        pass
    del v117
    v118 = v0 == v55
    del v0, v55
    if v118:
        v119 = v1 == v59
        v120 = v119
    else:
        v120 = False
    del v1, v59, v118
    if v120:
        v121 = v2 == v66
        if v121:
            del v121
            v122 = v3 == v70
            v124 = v122
        else:
            del v121
            v124 = False
    else:
        v124 = False
    del v2, v3, v66, v70, v120
    if v124:
        v125 = v4 == v51
        if v125:
            del v125
            match v5, v101:
                case US0_0(), US0_0(): # Call
                    v129 = True
                case US0_1(), US0_1(): # NoAction
                    v129 = True
                case US0_2(v126), US0_2(v127): # Raise
                    v128 = v126 == v127
                    del v126, v127
                    v129 = v128
                case other:
                    v129 = False
            if v129:
                del v129
                v130 = v6 == v47
                if v130:
                    del v130
                    v131 = v7 == v43
                    v135 = v131
                else:
                    del v130
                    v135 = False
            else:
                del v129
                v135 = False
        else:
            del v125
            v135 = False
    else:
        v135 = False
    del v4, v5, v6, v7, v43, v47, v51, v101, v124
    v136 = v135 == False
    del v135
    if v136:
        raise Exception("Serialization and deserialization should result in the same result.")
    else:
        pass
    del v136
    return 0
def main():
    return method0()

if __name__ == '__main__': print(main())
