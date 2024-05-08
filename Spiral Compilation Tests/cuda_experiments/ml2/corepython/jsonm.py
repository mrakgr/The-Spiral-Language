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
            v1 = ()
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
            v9 = ()
            v10 = "Nil"
            v11 = [v10,v9]
            del v9, v10
            return v11
def method0(v0 : i32, v1 : i32, v2 : US0, v3 : US0, v4 : i32, v5 : f32, v6 : f32, v7 : bool, v8 : bool, v9 : UH0) -> object:
    v10 = []
    v11 = []
    v12 = v0
    del v0
    v11.append(v12)
    del v12
    v13 = v1
    del v1
    v11.append(v13)
    del v13
    v14 = v11
    del v11
    v10.append(v14)
    del v14
    v15 = method1(v2)
    del v2
    v16 = method1(v3)
    del v3
    v17 = v4
    del v4
    v18 = {'a': v15, 'b': v16, 'c': v17}
    del v15, v16, v17
    v10.append(v18)
    del v18
    v19 = []
    v20 = []
    v21 = v5
    del v5
    v20.append(v21)
    del v21
    v22 = v6
    del v6
    v20.append(v22)
    del v22
    v23 = v20
    del v20
    v19.append(v23)
    del v23
    v24 = v7
    del v7
    v19.append(v24)
    del v24
    v25 = v8
    del v8
    v19.append(v25)
    del v25
    v26 = v19
    del v19
    v10.append(v26)
    del v26
    v27 = method2(v9)
    del v9
    v10.append(v27)
    del v27
    v28 = v10
    del v10
    return v28
def method4(v0 : object) -> US0:
    v1 = v0[0]
    v2 = v0[1]
    del v0
    v4 = "None" == v1
    if v4:
        del v1, v2, v4
        return US0_0()
    else:
        del v4
        v7 = "Some" == v1
        del v1
        if v7:
            del v7
            assert isinstance(v2,i32), 'The object needs to be the right primitive type.' 
            v8 = v2
            del v2
            return US0_1(v8)
        else:
            del v2, v7
            raise Exception("Cannot convert the Python object into a Spiral union type. Invalid string tag.")
def method5(v0 : object) -> UH0:
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
        v8 = method5(v7)
        del v7
        return UH0_0(v6, v8)
    else:
        del v2, v4
        v11 = "Nil" == v1
        del v1
        if v11:
            del v11
            return UH0_1()
        else:
            del v11
            raise Exception("Cannot convert the Python object into a Spiral union type. Invalid string tag.")
def method3(v0 : object) -> Tuple[i32, i32, US0, US0, i32, f32, f32, bool, bool, UH0]:
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
    v9 = method4(v8)
    del v8
    v10 = "b"
    v11 = v6[v10]
    del v10
    v12 = method4(v11)
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
    assert isinstance(v18,f32), 'The object needs to be the right primitive type.' 
    v19 = v18
    del v18
    v20 = v17[1]
    del v17
    assert isinstance(v20,f32), 'The object needs to be the right primitive type.' 
    v21 = v20
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
    del v0
    v27 = method5(v26)
    del v26
    return v3, v5, v9, v12, v15, v19, v21, v23, v25, v27
def method6(v0 : UH0) -> None:
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
            method6(v2)
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
    v0 = 1
    v1 = 2
    v2 = 1
    v3 = US0_1(v2)
    del v2
    v4 = US0_0()
    v5 = 3
    v6 = 55.34
    v7 = 66.23
    v8 = True
    v9 = False
    v10 = "qwe"
    v11 = "asd"
    v12 = UH0_1()
    v13 = UH0_0(v11, v12)
    del v11, v12
    v14 = UH0_0(v10, v13)
    del v10, v13
    v15 = method0(v0, v1, v3, v4, v5, v6, v7, v8, v9, v14)
    del v0, v1, v3, v4, v5, v6, v7, v8, v9, v14
    v16, v17, v18, v19, v20, v21, v22, v23, v24, v25 = method3(v15)
    del v15
    print(v16, end="")
    del v16
    v26 = ", "
    print(v26, end="")
    print(v17, end="")
    del v17
    print(v26, end="")
    print('{', end="")
    v27 = "a"
    print(v27, end="")
    del v27
    v28 = " = "
    print(v28, end="")
    match v18:
        case US0_0(): # None
            v29 = "None"
            print(v29, end="")
            del v29
        case US0_1(v30): # Some
            v31 = "Some"
            print(v31, end="")
            del v31
            v32 = "("
            print(v32, end="")
            del v32
            print(v30, end="")
            del v30
            v33 = ")"
            print(v33, end="")
            del v33
    del v18
    v34 = "; "
    print(v34, end="")
    v35 = "b"
    print(v35, end="")
    del v35
    print(v28, end="")
    match v19:
        case US0_0(): # None
            v36 = "None"
            print(v36, end="")
            del v36
        case US0_1(v37): # Some
            v38 = "Some"
            print(v38, end="")
            del v38
            v39 = "("
            print(v39, end="")
            del v39
            print(v37, end="")
            del v37
            v40 = ")"
            print(v40, end="")
            del v40
    del v19
    print(v34, end="")
    del v34
    v41 = "c"
    print(v41, end="")
    del v41
    print(v28, end="")
    del v28
    print(v20, end="")
    del v20
    print('}', end="")
    print(v26, end="")
    print("{:.6f}".format(v21), end="")
    del v21
    print(v26, end="")
    print("{:.6f}".format(v22), end="")
    del v22
    print(v26, end="")
    if v23:
        v42 = "true"
        v44 = v42
    else:
        v43 = "false"
        v44 = v43
    del v23
    print(v44, end="")
    del v44
    print(v26, end="")
    if v24:
        v45 = "true"
        v47 = v45
    else:
        v46 = "false"
        v47 = v46
    del v24
    print(v47, end="")
    del v47
    print(v26, end="")
    del v26
    method6(v25)
    del v25
    print()
    return 

if __name__ == '__main__': print(main())
