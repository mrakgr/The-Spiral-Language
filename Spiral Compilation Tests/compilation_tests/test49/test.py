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
def method0(v0 : UH0, v1 : UH0) -> i32:
    match v1, v0:
        case UH0_0(v2, v3), UH0_0(v4, v5): # Cons
            del v0, v1
            v6 = v2 < v4
            if v6:
                v9 = -1
            else:
                v7 = v2 > v4
                if v7:
                    del v7
                    v9 = 1
                else:
                    del v7
                    v9 = 0
            del v2, v4, v6
            v10 = v9 == 0
            if v10:
                del v9, v10
                return method0(v5, v3)
            else:
                del v3, v5, v10
                return v9
        case UH0_1(), UH0_1(): # Nil
            del v0, v1
            return 0
        case t:
            v13 = v1.tag
            del v1
            v14 = v0.tag
            del v0
            v15 = v13 < v14
            if v15:
                del v13, v14, v15
                return -1
            else:
                del v15
                v16 = v13 > v14
                del v13, v14
                if v16:
                    del v16
                    return 1
                else:
                    del v16
                    return 0
def main():
    # // Union test
    # // Static, Static
    v3 = -1
    del v3
    # // Dyn, Static
    v4 = 1
    v5 = US0_0(v4)
    del v4
    match v5:
        case US0_1(v7): # B
            v8 = v7 < 3.0
            if v8:
                del v7, v8
                v17 = -1
            else:
                del v8
                v9 = v7 > 3.0
                del v7
                if v9:
                    del v9
                    v17 = 1
                else:
                    del v9
                    v17 = 0
        case t:
            v12 = v5.tag
            v13 = v12 < 1
            if v13:
                del v12, v13
                v17 = -1
            else:
                del v13
                v14 = v12 > 1
                del v12
                if v14:
                    del v14
                    v17 = 1
                else:
                    del v14
                    v17 = 0
    del v5, v17
    # // Static, Dyn
    v18 = 3.0
    v19 = US0_1(v18)
    del v18
    match v19:
        case US0_0(v22): # A
            v23 = 1 < v22
            if v23:
                del v22, v23
                v32 = -1
            else:
                del v23
                v24 = 1 > v22
                del v22
                if v24:
                    del v24
                    v32 = 1
                else:
                    del v24
                    v32 = 0
        case t:
            v27 = v19.tag
            v28 = 0 < v27
            if v28:
                del v27, v28
                v32 = -1
            else:
                del v28
                v29 = 0 > v27
                del v27
                if v29:
                    del v29
                    v32 = 1
                else:
                    del v29
                    v32 = 0
    del v19, v32
    # // Dyn, Dyn
    v33 = 1
    v34 = US0_0(v33)
    del v33
    v35 = 3.0
    v36 = US0_1(v35)
    del v35
    match v34, v36:
        case US0_0(v37), US0_0(v38): # A
            v39 = v37 < v38
            if v39:
                del v37, v38, v39
                v55 = -1
            else:
                del v39
                v40 = v37 > v38
                del v37, v38
                if v40:
                    del v40
                    v55 = 1
                else:
                    del v40
                    v55 = 0
        case US0_1(v43), US0_1(v44): # B
            v45 = v43 < v44
            if v45:
                del v43, v44, v45
                v55 = -1
            else:
                del v45
                v46 = v43 > v44
                del v43, v44
                if v46:
                    del v46
                    v55 = 1
                else:
                    del v46
                    v55 = 0
        case t:
            v49 = v34.tag
            v50 = v36.tag
            v51 = v49 < v50
            if v51:
                del v49, v50, v51
                v55 = -1
            else:
                del v51
                v52 = v49 > v50
                del v49, v50
                if v52:
                    del v52
                    v55 = 1
                else:
                    del v52
                    v55 = 0
    del v34, v36, v55
    # // Union rec test
    v56 = 3
    v57 = UH0_1()
    v58 = UH0_0(v56, v57)
    del v56, v57
    v59 = 2
    v60 = 3
    v61 = UH0_1()
    v62 = UH0_0(v60, v61)
    del v60, v61
    v63 = UH0_0(v59, v62)
    del v59, v62
    match v63:
        case UH0_0(v70, v71): # Cons
            v72 = 2 < v70
            if v72:
                v75 = -1
            else:
                v73 = 2 > v70
                if v73:
                    del v73
                    v75 = 1
                else:
                    del v73
                    v75 = 0
            del v70, v72
            v76 = v75 == 0
            if v76:
                del v75, v76
                v84 = method0(v71, v58)
            else:
                del v71, v76
                v84 = v75
        case t:
            v79 = v63.tag
            v80 = 0 < v79
            if v80:
                del v79, v80
                v84 = -1
            else:
                del v80
                v81 = 0 > v79
                del v79
                if v81:
                    del v81
                    v84 = 1
                else:
                    del v81
                    v84 = 0
    del v58, v63, v84
    return 0

if __name__ == '__main__': print(main())
