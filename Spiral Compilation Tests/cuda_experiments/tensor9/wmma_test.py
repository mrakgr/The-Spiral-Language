kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0(v0 : i32) -> bool:
    v1 = v0 < 8
    del v0
    return v1
def method1(v0 : i32) -> bool:
    v1 = v0 < 4
    del v0
    return v1
def main():
    v0 = cp.arange(0,64,1,dtype=cp.float64)
    v1 = v0.size
    del v0
    v2 = 64 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.arange(0,32,1,dtype=cp.float64)
    v6 = v5.size
    v7 = 32 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.arange(0,32,1,dtype=cp.float64)
    v11 = v10.size
    v12 = 32 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = 0
    print('[', end="")
    v17 = 0
    while method0(v17):
        v19 = v15
        v20 = v19 >= 100
        del v19
        if v20:
            v23 = " ..."
            print(v23, end="")
            del v23
            break
        else:
            pass
        del v20
        v24 = v17 == 0
        v25 = v24 != True
        del v24
        if v25:
            v28 = "; "
            print(v28, end="")
            del v28
        else:
            pass
        del v25
        print('[', end="")
        v30 = 0
        while method1(v30):
            v32 = v15
            v33 = v32 >= 100
            del v32
            if v33:
                v36 = " ..."
                print(v36, end="")
                del v36
                break
            else:
                pass
            del v33
            v37 = v30 == 0
            v38 = v37 != True
            del v37
            if v38:
                v41 = "; "
                print(v41, end="")
                del v41
            else:
                pass
            del v38
            v42 = v15 + 1
            v15 = v42
            del v42
            v45 = ""
            print(v45, end="")
            del v45
            v46 = v17 * 4
            v47 = v46 + v30
            del v46
            v48 = v10[v47].item()
            print("{:.6f}".format(v48), end="")
            del v48
            v52 = ", "
            print(v52, end="")
            del v52
            v53 = v5[v47].item()
            del v47
            print("{:.6f}".format(v53), end="")
            del v53
            v30 += 1 
        del v30
        print(']', end="")
        v17 += 1 
    del v5, v10, v15, v17
    print(']', end="")
    print()
    return 

if __name__ == '__main__': print(main())
