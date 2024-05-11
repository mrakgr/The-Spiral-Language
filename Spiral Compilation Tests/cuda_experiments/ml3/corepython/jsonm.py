kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

UH0 = Union["UH0_0", "UH0_1"]
class US0_0(NamedTuple): # None
    tag = 0
class US0_1(NamedTuple): # Some
    v0 : i32
    tag = 1
US0 = Union[US0_0, US0_1]
class UH0_0(NamedTuple): # Cons
    v0 : string
    v1 : UH0
    tag = 0
class UH0_1(NamedTuple): # Nil
    tag = 1
def method1(v0 : US0) -> object:
    match v0:
        case US0_0(): # None
            del v0
            v1 = []
            v2 = "None"
            v3 = [v2,v1]
            del v1, v2
            return v3
        case US0_1(v4): # Some
            del v0
            v5 = v4
            del v4
            v6 = "Some"
            v7 = [v6,v5]
            del v5, v6
            return v7
def method2(v0 : UH0) -> object:
    match v0:
        case UH0_0(v1, v2): # Cons
            del v0
            v3 = []
            v4 = v1
            del v1
            v3.append(v4)
            del v4
            v5 = method2(v2)
            del v2
            v3.append(v5)
            del v5
            v6 = v3
            del v3
            v7 = "Cons"
            v8 = [v7,v6]
            del v6, v7
            return v8
        case UH0_1(): # Nil
            del v0
            v9 = []
            v10 = "Nil"
            v11 = [v10,v9]
            del v9, v10
            return v11
def method3(v0 : i32, v1 : i32) -> bool:
    v2 = v1 < v0
    del v0, v1
    return v2
def method0(v0 : i32, v1 : i32, v2 : US0, v3 : US0, v4 : i32, v5 : f32, v6 : f32, v7 : bool, v8 : bool, v9 : UH0, v10 : list[Tuple[i32, f32]], v11 : list) -> object:
    v12 = []
    v13 = []
    v14 = v0
    del v0
    v13.append(v14)
    del v14
    v15 = v1
    del v1
    v13.append(v15)
    del v15
    v16 = v13
    del v13
    v12.append(v16)
    del v16
    v17 = method1(v2)
    del v2
    v18 = method1(v3)
    del v3
    v19 = v4
    del v4
    v20 = {'a': v17, 'b': v18, 'c': v19}
    del v17, v18, v19
    v12.append(v20)
    del v20
    v21 = []
    v22 = []
    v23 = v5
    del v5
    v22.append(v23)
    del v23
    v24 = v6
    del v6
    v22.append(v24)
    del v24
    v25 = v22
    del v22
    v21.append(v25)
    del v25
    v26 = v7
    del v7
    v21.append(v26)
    del v26
    v27 = v8
    del v8
    v21.append(v27)
    del v27
    v28 = v21
    del v21
    v12.append(v28)
    del v28
    v29 = method2(v9)
    del v9
    v12.append(v29)
    del v29
    v30 = []
    v31 = v11[0]
    v32 = 0
    while method3(v31, v32):
        v34 = 0 <= v32
        if v34:
            v35 = v11[0]
            v36 = v32 < v35
            del v35
            v37 = v36
        else:
            v37 = False
        v38 = v37 == False
        if v38:
            v39 = "The read index needs to be in range."
            assert v37, v39
            del v39
        else:
            pass
        del v37, v38
        if v34:
            v40 = v32 < 16
            v41 = v40
        else:
            v41 = False
        del v34
        v42 = v41 == False
        if v42:
            v43 = "The read index needs to be in range."
            assert v41, v43
            del v43
        else:
            pass
        del v41, v42
        v44, v45 = v10[v32]
        v46 = []
        v47 = v44
        del v44
        v46.append(v47)
        del v47
        v48 = v45
        del v45
        v46.append(v48)
        del v48
        v49 = v46
        del v46
        v30.append(v49)
        del v49
        v32 += 1 
    del v10, v11, v31, v32
    v12.append(v30)
    del v30
    v50 = v12
    del v12
    return v50
def method5(v0 : object) -> US0:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v4
        assert v2 == [], 'Expected an unit type.'
        del v2
        return US0_0()
    else:
        del v4
        v7 = "Some" == v1
        if v7:
            del v1, v7
            assert isinstance(v2,i32), 'The object needs to be the right primitive type.'
            v8 = v2
            del v2
            return US0_1(v8)
        else:
            del v2, v7
            v10 = raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            return v10
def method6(v0 : object) -> UH0:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "Cons" == v1
    if v4:
        del v1, v4
        v5 = v2[0]
        assert isinstance(v5,string), 'The object needs to be the right primitive type.'
        v6 = v5
        del v5
        v7 = v2[1]
        del v2
        v8 = method6(v7)
        del v7
        return UH0_0(v6, v8)
    else:
        del v4
        v11 = "Nil" == v1
        if v11:
            del v1, v11
            assert v2 == [], 'Expected an unit type.'
            del v2
            return UH0_1()
        else:
            del v2, v11
            v13 = raise TypeError(f"Cannot convert the Python object into a Spiral union type. Invalid string tag. Got: {v1}")
            del v1
            return v13
def method4(v0 : object) -> Tuple[i32, i32, US0, US0, i32, f32, f32, bool, bool, UH0, list[Tuple[i32, f32]], list]:
    v1 = v0[0]
    v2 = v1[0]
    assert isinstance(v2,i32), 'The object needs to be the right primitive type.'
    v3 = v2
    del v2
    v4 = v1[1]
    del v1
    assert isinstance(v4,i32), 'The object needs to be the right primitive type.'
    v5 = v4
    del v4
    v6 = v0[1]
    v7 = "a"
    v8 = v6[v7]
    del v7
    v9 = method5(v8)
    del v8
    v10 = "b"
    v11 = v6[v10]
    del v10
    v12 = method5(v11)
    del v11
    v13 = "c"
    v14 = v6[v13]
    del v6, v13
    assert isinstance(v14,i32), 'The object needs to be the right primitive type.'
    v15 = v14
    del v14
    v16 = v0[2]
    v17 = v16[0]
    v18 = v17[0]
    assert isinstance(v18,(int,float)), 'The object needs to be an int or a float.'
    v19 = f32(v18)
    del v18
    v20 = v17[1]
    del v17
    assert isinstance(v20,(int,float)), 'The object needs to be an int or a float.'
    v21 = f32(v20)
    del v20
    v22 = v16[1]
    assert isinstance(v22,bool), 'The object needs to be the right primitive type.'
    v23 = v22
    del v22
    v24 = v16[2]
    del v16
    assert isinstance(v24,bool), 'The object needs to be the right primitive type.'
    v25 = v24
    del v24
    v26 = v0[3]
    v27 = method6(v26)
    del v26
    v28 = v0[4]
    del v0
    assert isinstance(v28,list), 'The object needs to be a Python list.'
    v29 = len(v28)
    v30 = 16 >= v29
    v31 = v30 == False
    if v31:
        v32 = "The type level dimension has to equal the value passed at runtime into create."
        assert v30, v32
        del v32
    else:
        pass
    del v30, v31
    v33 = [None] * 16
    v34 = [0]
    v35 = v34[0]
    del v35
    v34[0] = v29
    v36 = 0
    while method3(v29, v36):
        v38 = v28[v36]
        v39 = v38[0]
        assert isinstance(v39,i32), 'The object needs to be the right primitive type.'
        v40 = v39
        del v39
        v41 = v38[1]
        del v38
        assert isinstance(v41,(int,float)), 'The object needs to be an int or a float.'
        v42 = f32(v41)
        del v41
        v43 = 0 <= v36
        if v43:
            v44 = v34[0]
            v45 = v36 < v44
            del v44
            v46 = v45
        else:
            v46 = False
        v47 = v46 == False
        if v47:
            v48 = "The set index needs to be in range."
            assert v46, v48
            del v48
        else:
            pass
        del v46, v47
        if v43:
            v49 = v36 < 16
            v50 = v49
        else:
            v50 = False
        del v43
        v51 = v50 == False
        if v51:
            v52 = "The read index needs to be in range."
            assert v50, v52
            del v52
        else:
            pass
        del v50, v51
        v33[v36] = (v40, v42)
        del v40, v42
        v36 += 1 
    del v28, v29, v36
    return v3, v5, v9, v12, v15, v19, v21, v23, v25, v27, v33, v34
def method7(v0 : UH0) -> None:
    match v0:
        case UH0_0(v1, v2): # Cons
            del v0
            v3 = "Cons"
            print(v3, end="")
            del v3
            v4 = "("
            print(v4, end="")
            del v4
            print(v1, end="")
            del v1
            v5 = ", "
            print(v5, end="")
            del v5
            method7(v2)
            del v2
            v6 = ")"
            print(v6, end="")
            del v6
            return 
        case UH0_1(): # Nil
            del v0
            v7 = "Nil"
            print(v7, end="")
            del v7
            return 
def main():
    v0 = [None] * 16
    v1 = [0]
    v2 = v1[0]
    del v2
    v1[0] = 3
    v3 = v1[0]
    v4 = 0 < v3
    del v3
    v5 = v4 == False
    if v5:
        v6 = "The set index needs to be in range."
        assert v4, v6
        del v6
    else:
        pass
    del v4, v5
    v0[0] = (1, 2.0)
    v7 = v1[0]
    v8 = 1 < v7
    del v7
    v9 = v8 == False
    if v9:
        v10 = "The set index needs to be in range."
        assert v8, v10
        del v10
    else:
        pass
    del v8, v9
    v0[1] = (3, 4.0)
    v11 = v1[0]
    v12 = 2 < v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The set index needs to be in range."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v0[2] = (5, 6.0)
    v15 = 1
    v16 = 2
    v17 = 1
    v18 = US0_1(v17)
    del v17
    v19 = US0_0()
    v20 = 3
    v21 = 55.34
    v22 = 66.23
    v23 = True
    v24 = False
    v25 = "qwe"
    v26 = "asd"
    v27 = UH0_1()
    v28 = UH0_0(v26, v27)
    del v26, v27
    v29 = UH0_0(v25, v28)
    del v25, v28
    v30 = method0(v15, v16, v18, v19, v20, v21, v22, v23, v24, v29, v0, v1)
    del v0, v1, v15, v16, v18, v19, v20, v21, v22, v23, v24, v29
    v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42 = method4(v30)
    del v30
    print(v31, end="")
    del v31
    v43 = ", "
    print(v43, end="")
    print(v32, end="")
    del v32
    print(v43, end="")
    print('{', end="")
    v44 = "a"
    print(v44, end="")
    del v44
    v45 = " = "
    print(v45, end="")
    match v33:
        case US0_0(): # None
            v46 = "None"
            print(v46, end="")
            del v46
        case US0_1(v47): # Some
            v48 = "Some"
            print(v48, end="")
            del v48
            v49 = "("
            print(v49, end="")
            del v49
            print(v47, end="")
            del v47
            v50 = ")"
            print(v50, end="")
            del v50
    del v33
    v51 = "; "
    print(v51, end="")
    v52 = "b"
    print(v52, end="")
    del v52
    print(v45, end="")
    match v34:
        case US0_0(): # None
            v53 = "None"
            print(v53, end="")
            del v53
        case US0_1(v54): # Some
            v55 = "Some"
            print(v55, end="")
            del v55
            v56 = "("
            print(v56, end="")
            del v56
            print(v54, end="")
            del v54
            v57 = ")"
            print(v57, end="")
            del v57
    del v34
    print(v51, end="")
    v58 = "c"
    print(v58, end="")
    del v58
    print(v45, end="")
    del v45
    print(v35, end="")
    del v35
    print('}', end="")
    print(v43, end="")
    print("{:.6f}".format(v36), end="")
    del v36
    print(v43, end="")
    print("{:.6f}".format(v37), end="")
    del v37
    print(v43, end="")
    if v38:
        v59 = "true"
        v61 = v59
    else:
        v60 = "false"
        v61 = v60
    del v38
    print(v61, end="")
    del v61
    print(v43, end="")
    if v39:
        v62 = "true"
        v64 = v62
    else:
        v63 = "false"
        v64 = v63
    del v39
    print(v64, end="")
    del v64
    print(v43, end="")
    method7(v40)
    del v40
    print(v43, end="")
    v65 = "["
    print(v65, end="")
    del v65
    v66 = v42[0]
    v67 = 100 < v66
    if v67:
        v68 = 100
    else:
        v68 = v66
    del v66, v67
    v69 = 0
    while method3(v68, v69):
        v71 = 0 <= v69
        if v71:
            v72 = v42[0]
            v73 = v69 < v72
            del v72
            v74 = v73
        else:
            v74 = False
        v75 = v74 == False
        if v75:
            v76 = "The read index needs to be in range."
            assert v74, v76
            del v76
        else:
            pass
        del v74, v75
        if v71:
            v77 = v69 < 16
            v78 = v77
        else:
            v78 = False
        del v71
        v79 = v78 == False
        if v79:
            v80 = "The read index needs to be in range."
            assert v78, v80
            del v80
        else:
            pass
        del v78, v79
        v81, v82 = v41[v69]
        print(v81, end="")
        del v81
        print(v43, end="")
        print("{:.6f}".format(v82), end="")
        del v82
        v83 = v69 + 1
        v84 = v42[0]
        v85 = v83 < v84
        del v83, v84
        if v85:
            print(v51, end="")
        else:
            pass
        del v85
        v69 += 1 
    del v41, v43, v51, v68, v69
    v86 = v42[0]
    del v42
    v87 = v86 > 100
    del v86
    if v87:
        v88 = "; ..."
        print(v88, end="")
        del v88
    else:
        pass
    del v87
    v89 = "]"
    print(v89, end="")
    del v89
    print()
    return 

if __name__ == '__main__': print(main())
