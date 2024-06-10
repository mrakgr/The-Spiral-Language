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
UH1 = Union["UH1_0", "UH1_1"]
class US0_0(NamedTuple): # A
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # B
    v0 : f64
    tag = 1
US0 = Union[US0_0, US0_1]
class UH0_0(NamedTuple): # Cons
    v0 : i32
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
class UH1_0(NamedTuple): # Cons
    v0 : f64
    v1 : UH1
    tag = 0
class UH1_1(NamedTuple): # Nil
    tag = 1
def method0(v0 : UH0) -> u64:
    match v0:
        case UH0_0(v1, v2): # Cons
            del v0
            v3 = hash(v1)
            del v1
            v4 = v3 * 9973
            del v3
            v5 = method0(v2)
            del v2
            v6 = v4 + v5
            del v4, v5
            v7 = 9223372036854775807 + v6
            del v6
            v8 = v7 * 9973
            del v7
            v9 = 0
            v10 = 1 + v9
            del v9
            v11 = v8 * v10
            del v8, v10
            return v11
        case UH0_1(): # Nil
            del v0
            v12 = 1
            v13 = 1 + v12
            del v12
            v14 = 9223372036854765835 * v13
            del v13
            return v14
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def method1(v0 : UH1) -> u64:
    match v0:
        case UH1_0(v1, v2): # Cons
            del v0
            v3 = hash(v1)
            del v1
            v4 = v3 * 9973
            del v3
            v5 = method1(v2)
            del v2
            v6 = v4 + v5
            del v4, v5
            v7 = 9223372036854775807 + v6
            del v6
            v8 = v7 * 9973
            del v7
            v9 = 0
            v10 = 1 + v9
            del v9
            v11 = v8 * v10
            del v8, v10
            return v11
        case UH1_1(): # Nil
            del v0
            v12 = 1
            v13 = 1 + v12
            del v12
            v14 = 9223372036854765835 * v13
            del v13
            return v14
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
def main():
    v1 = hash(1)
    v2 = 9223372036854775807 + v1
    del v1
    v3 = v2 * 9973
    del v2
    v4 = 0
    v5 = 1 + v4
    del v4
    v6 = v3 * v5
    del v3, v5, v6
    v8 = hash(3.0)
    v9 = 9223372036854775807 + v8
    del v8
    v10 = v9 * 9973
    del v9
    v11 = 1
    v12 = 1 + v11
    del v11
    v13 = v10 * v12
    del v10, v12, v13
    v14 = 1
    v15 = US0_0(v14)
    del v14
    match v15:
        case US0_0(v16): # A
            v17 = hash(v16)
            del v16
            v18 = 9223372036854775807 + v17
            del v17
            v19 = v18 * 9973
            del v18
            v20 = 0
            v21 = 1 + v20
            del v20
            v22 = v19 * v21
            del v19, v21
            v30 = v22
        case US0_1(v23): # B
            v24 = hash(v23)
            del v23
            v25 = 9223372036854775807 + v24
            del v24
            v26 = v25 * 9973
            del v25
            v27 = 1
            v28 = 1 + v27
            del v27
            v29 = v26 * v28
            del v26, v28
            v30 = v29
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v15, v30
    v31 = 3.0
    v32 = US0_1(v31)
    del v31
    match v32:
        case US0_0(v33): # A
            v34 = hash(v33)
            del v33
            v35 = 9223372036854775807 + v34
            del v34
            v36 = v35 * 9973
            del v35
            v37 = 0
            v38 = 1 + v37
            del v37
            v39 = v36 * v38
            del v36, v38
            v47 = v39
        case US0_1(v40): # B
            v41 = hash(v40)
            del v40
            v42 = 9223372036854775807 + v41
            del v41
            v43 = v42 * 9973
            del v42
            v44 = 1
            v45 = 1 + v44
            del v44
            v46 = v43 * v45
            del v43, v45
            v47 = v46
        case t:
            raise Exception(f'Pattern matching miss. Got: {t}')
    del v32, v47
    v48 = 3
    v49 = UH0_1()
    v50 = UH0_0(v48, v49)
    del v48, v49
    v51 = 2.0
    v52 = 3.0
    v53 = UH1_1()
    v54 = UH1_0(v52, v53)
    del v52, v53
    v55 = UH1_0(v51, v54)
    del v51, v54
    v58 = hash(1)
    v59 = v58 * 9973
    del v58
    v61 = hash(2)
    v62 = v61 * 9973
    del v61
    v63 = method0(v50)
    del v50
    v64 = v62 + v63
    del v62, v63
    v65 = 9223372036854775807 + v64
    del v64
    v66 = v65 * 9973
    del v65
    v67 = 0
    v68 = 1 + v67
    del v67
    v69 = v66 * v68
    del v66, v68
    v70 = v59 + v69
    del v59, v69
    v71 = 9223372036854775807 + v70
    del v70
    v72 = v71 * 9973
    del v71
    v73 = 0
    v74 = 1 + v73
    del v73
    v75 = v72 * v74
    del v72, v74, v75
    v77 = hash(1.0)
    v78 = v77 * 9973
    del v77
    v79 = method1(v55)
    del v55
    v80 = v78 + v79
    del v78, v79
    v81 = 9223372036854775807 + v80
    del v80
    v82 = v81 * 9973
    del v81
    v83 = 0
    v84 = 1 + v83
    del v83
    v85 = v82 * v84
    del v82, v84, v85
    return 0

if __name__ == '__main__': print(main())
