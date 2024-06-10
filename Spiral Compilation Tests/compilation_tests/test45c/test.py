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
@dataclass
class Mut0:
    v0 : u64
class US0_0(NamedTuple): # Empty
    tag = 0
class US0_1(NamedTuple): # Princess
    tag = 1
US0 = Union[US0_0, US0_1]
class UH0_0(NamedTuple): # Cons
    v0 : string
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
class US1_0(NamedTuple): # None
    tag = 0
class US1_1(NamedTuple): # Some
    v0 : UH0
    tag = 1
US1 = Union[US1_0, US1_1]
@dataclass
class Mut1:
    v0 : US1
@dataclass
class Mut2:
    v0 : u64
    v1 : u64
def method0(v0 : u64, v1 : Mut0) -> bool:
    v2 = v1.v0
    del v1
    v3 = v2 < v0
    del v0, v2
    return v3
def method3(v0 : u64, v1 : Mut2) -> bool:
    v2 = v1.v0
    del v1
    v3 = v2 < v0
    del v0, v2
    return v3
def method4(v0 : UH0, v1 : UH0) -> UH0:
    match v0:
        case UH0_0(v2, v3): # Cons
            del v0
            v4 = UH0_0(v2, v1)
            del v1, v2
            return method4(v3, v4)
        case UH0_1(): # Nil
            del v0
            return v1
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method2(v0 : list[list[bool]], v1 : list[list[US0]], v2 : Mut1, v3 : list[Tuple[u64, u64, UH0]]) -> UH0:
    v4 = v3.size
    v5 = [None] * v4 # type: ignore
    v6 = Mut0(0)
    while method0(v4, v6):
        v8 = v6.v0
        v9, v10, v11 = v3[v8]
        v12 = v9 - 1
        v13 = 0 <= v12
        if v13:
            v14 = v1.size
            v15 = v12 < v14
            del v14
            if v15:
                del v15
                v16 = v1[v12]
                v17 = 0 <= v10
                if v17:
                    del v17
                    v18 = v16.size
                    del v16
                    v19 = v10 < v18
                    del v18
                    v22 = v19
                else:
                    del v16, v17
                    v22 = False
            else:
                del v15
                v22 = False
        else:
            v22 = False
        del v13
        if v22:
            v23 = v0[v12]
            v24 = v23[v10]
            del v23
            v25 = v24 == False
            del v24
            v26 = v25
        else:
            v26 = False
        del v22
        if v26:
            v27 = v1[v12]
            v28 = v27[v10]
            del v27
            match v28:
                case US0_1(): # Princess
                    v29 = True
                case t:
                    v29 = False
            del v28
            if v29:
                v30 = "UP"
                v31 = UH0_0(v30, v11)
                del v30
                v32 = US1_1(v31)
                del v31
                v2.v0 = v32
                del v32
            else:
                pass
            del v29
            v33 = v0[v12]
            v33[v10] = True
            del v33
            v34 = True
        else:
            v34 = False
        del v26
        v35 = v9 + 1
        v36 = 0 <= v35
        if v36:
            v37 = v1.size
            v38 = v35 < v37
            del v37
            if v38:
                del v38
                v39 = v1[v35]
                v40 = 0 <= v10
                if v40:
                    del v40
                    v41 = v39.size
                    del v39
                    v42 = v10 < v41
                    del v41
                    v45 = v42
                else:
                    del v39, v40
                    v45 = False
            else:
                del v38
                v45 = False
        else:
            v45 = False
        del v36
        if v45:
            v46 = v0[v35]
            v47 = v46[v10]
            del v46
            v48 = v47 == False
            del v47
            v49 = v48
        else:
            v49 = False
        del v45
        if v49:
            v50 = v1[v35]
            v51 = v50[v10]
            del v50
            match v51:
                case US0_1(): # Princess
                    v52 = True
                case t:
                    v52 = False
            del v51
            if v52:
                v53 = "DOWN"
                v54 = UH0_0(v53, v11)
                del v53
                v55 = US1_1(v54)
                del v54
                v2.v0 = v55
                del v55
            else:
                pass
            del v52
            v56 = v0[v35]
            v56[v10] = True
            del v56
            v57 = True
        else:
            v57 = False
        del v49
        v58 = v10 - 1
        v59 = 0 <= v9
        if v59:
            v60 = v1.size
            v61 = v9 < v60
            del v60
            if v61:
                del v61
                v62 = v1[v9]
                v63 = 0 <= v58
                if v63:
                    del v63
                    v64 = v62.size
                    del v62
                    v65 = v58 < v64
                    del v64
                    v68 = v65
                else:
                    del v62, v63
                    v68 = False
            else:
                del v61
                v68 = False
        else:
            v68 = False
        if v68:
            v69 = v0[v9]
            v70 = v69[v58]
            del v69
            v71 = v70 == False
            del v70
            v72 = v71
        else:
            v72 = False
        del v68
        if v72:
            v73 = v1[v9]
            v74 = v73[v58]
            del v73
            match v74:
                case US0_1(): # Princess
                    v75 = True
                case t:
                    v75 = False
            del v74
            if v75:
                v76 = "LEFT"
                v77 = UH0_0(v76, v11)
                del v76
                v78 = US1_1(v77)
                del v77
                v2.v0 = v78
                del v78
            else:
                pass
            del v75
            v79 = v0[v9]
            v79[v58] = True
            del v79
            v80 = True
        else:
            v80 = False
        del v72
        v81 = v10 + 1
        if v59:
            v82 = v1.size
            v83 = v9 < v82
            del v82
            if v83:
                del v83
                v84 = v1[v9]
                v85 = 0 <= v81
                if v85:
                    del v85
                    v86 = v84.size
                    del v84
                    v87 = v81 < v86
                    del v86
                    v90 = v87
                else:
                    del v84, v85
                    v90 = False
            else:
                del v83
                v90 = False
        else:
            v90 = False
        del v59
        if v90:
            v91 = v0[v9]
            v92 = v91[v81]
            del v91
            v93 = v92 == False
            del v92
            v94 = v93
        else:
            v94 = False
        del v90
        if v94:
            v95 = v1[v9]
            v96 = v95[v81]
            del v95
            match v96:
                case US0_1(): # Princess
                    v97 = True
                case t:
                    v97 = False
            del v96
            if v97:
                v98 = "RIGHT"
                v99 = UH0_0(v98, v11)
                del v98
                v100 = US1_1(v99)
                del v99
                v2.v0 = v100
                del v100
            else:
                pass
            del v97
            v101 = v0[v9]
            v101[v81] = True
            del v101
            v102 = True
        else:
            v102 = False
        del v94
        if v34:
            v103 = 1
        else:
            v103 = 0
        if v57:
            v104 = 1
        else:
            v104 = 0
        v105 = v103 + v104
        del v103, v104
        if v80:
            v106 = 1
        else:
            v106 = 0
        v107 = v105 + v106
        del v105, v106
        if v102:
            v108 = 1
        else:
            v108 = 0
        v109 = v107 + v108
        del v107, v108
        v110 = [None] * v109 # type: ignore
        del v109
        if v34:
            v111 = "UP"
            v112 = UH0_0(v111, v11)
            del v111
            v110[0] = v12, v10, v112
            del v112
            v113 = 1
        else:
            v113 = 0
        del v12, v34
        if v57:
            v114 = "DOWN"
            v115 = UH0_0(v114, v11)
            del v114
            v110[v113] = v35, v10, v115
            del v115
            v116 = v113 + 1
            v117 = v116
        else:
            v117 = v113
        del v10, v35, v57, v113
        if v80:
            v118 = "LEFT"
            v119 = UH0_0(v118, v11)
            del v118
            v110[v117] = v9, v58, v119
            del v119
            v120 = v117 + 1
            v121 = v120
        else:
            v121 = v117
        del v58, v80, v117
        if v102:
            v122 = "RIGHT"
            v123 = UH0_0(v122, v11)
            del v122
            v110[v121] = v9, v81, v123
            del v123
            v124 = v121 + 1
            v125 = v124
        else:
            v125 = v121
        del v9, v11, v81, v102, v121, v125
        v5[v8] = v110
        del v110
        v126 = v8 + 1
        del v8
        v6.v0 = v126
        del v126
    del v3, v4
    del v6
    v127 = v5.size
    v128 = Mut2(0, 0)
    while method3(v127, v128):
        v130 = v128.v0
        v131 = v128.v1
        v132 = v5[v130]
        v133 = v132.size
        del v132
        v134 = v131 + v133
        del v131, v133
        v135 = v130 + 1
        del v130
        v128.v0 = v135
        v128.v1 = v134
        del v134, v135
    v136 = v128.v1
    del v128
    v137 = [None] * v136 # type: ignore
    del v136
    v138 = Mut2(0, 0)
    while method3(v127, v138):
        v140 = v138.v0
        v141 = v138.v1
        v142 = v5[v140]
        v143 = v142.size
        v144 = Mut2(0, v141)
        del v141
        while method3(v143, v144):
            v146 = v144.v0
            v147 = v144.v1
            v148, v149, v150 = v142[v146]
            v137[v147] = v148, v149, v150
            del v148, v149, v150
            v151 = v147 + 1
            del v147
            v152 = v146 + 1
            del v146
            v144.v0 = v152
            v144.v1 = v151
            del v151, v152
        del v142, v143
        v153 = v144.v1
        del v144
        v154 = v140 + 1
        del v140
        v138.v0 = v154
        v138.v1 = v153
        del v153, v154
    del v5, v127
    v155 = v138.v1
    del v138, v155
    v156 = v2.v0
    match v156:
        case US1_0(): # None
            del v156
            return method2(v0, v1, v2, v137)
        case US1_1(v158): # Some
            del v0, v1, v2, v137, v156
            v159 = UH0_1()
            return method4(v158, v159)
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method1(v0 : list[list[US0]], v1 : u64, v2 : u64) -> UH0:
    v3 = v0.size
    v4 = [None] * v3 # type: ignore
    v5 = Mut0(0)
    while method0(v3, v5):
        v7 = v5.v0
        v8 = v0[v7]
        v9 = v8.size
        del v8
        v10 = [None] * v9 # type: ignore
        v11 = Mut0(0)
        while method0(v9, v11):
            v13 = v11.v0
            v10[v13] = False
            v14 = v13 + 1
            del v13
            v11.v0 = v14
            del v14
        del v9
        del v11
        v4[v7] = v10
        del v10
        v15 = v7 + 1
        del v7
        v5.v0 = v15
        del v15
    del v3
    del v5
    v16 = US1_0()
    v17 = Mut1(v16)
    del v16
    v18 = [None] * 1 # type: ignore
    v19 = UH0_1()
    v18[0] = v1, v2, v19
    del v1, v2, v19
    return method2(v4, v0, v17, v18)
def method5(v0 : UH0) -> None:
    match v0:
        case UH0_0(v1, v2): # Cons
            del v0
            printf("%s\n",v1->ptr)
            del v1
            return method5(v2)
        case UH0_1(): # Nil
            del v0
            return 
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v0 = 4
    v1 = 2
    v2 = 3
    printf("%s\n","Initing")
    v3 = [None] * v0 # type: ignore
    v4 = Mut0(0)
    while method0(v0, v4):
        v6 = v4.v0
        v7 = [None] * v0 # type: ignore
        v8 = Mut0(0)
        while method0(v0, v8):
            v10 = v8.v0
            v11 = v6 == v1
            if v11:
                v12 = v10 == v2
                v13 = v12
            else:
                v13 = False
            del v11
            if v13:
                v16 = US0_1()
            else:
                v16 = US0_0()
            del v13
            v7[v10] = v16
            del v16
            v17 = v10 + 1
            del v10
            v8.v0 = v17
            del v17
        del v8
        v3[v6] = v7
        del v7
        v18 = v6 + 1
        del v6
        v4.v0 = v18
        del v18
    del v0, v1, v2
    del v4
    printf("%s\n","Starting")
    v19 = 0
    v20 = 0
    v21 = method1(v3, v19, v20)
    del v3, v19, v20
    printf("%s\n","Printing")
    method5(v21)
    del v21
    return 0

if __name__ == '__main__': print(main())
