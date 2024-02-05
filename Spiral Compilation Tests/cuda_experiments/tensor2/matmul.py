kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def method0(v0 : i32) -> bool:
    v1 = v0 < 4096
    del v0
    return v1
def main():
    v0 = cp.random.normal(0,1,4096,cp.float32)
    v1 = v0.size
    v2 = 4096 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,4096,cp.float32)
    v7 = v6.size
    v8 = 4096 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,4096,cp.float32)
    v13 = v12.size
    v14 = 4096 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = v12.reshape((64, 64))
    v19 = v6.reshape((64, 64))
    v20 = cp.transpose(v19)
    del v19
    v21 = v0.reshape((64, 64))
    del v0, v21
    v22 = (cp.matmul(v18,v20)).flatten()
    del v18, v20
    v23 = v22.size
    del v22
    v24 = 4096 == v23
    del v23
    v25 = v24 == False
    if v25:
        v27 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v24, v27
        del v27
    else:
        pass
    del v24, v25
    v30 = "["
    print(v30, end='')
    del v30
    v31 = 0
    v32 = 0
    while method0(v32):
        v34 = v32 % 64
        v35 = v32 // 64
        v36 = v35 % 64
        v37 = v35 // 64
        del v35
        v38 = v37 == 0
        del v37
        v39 = v38 == False
        if v39:
            v41 = "The index has to be in the range of the dimension."
            assert v38, v41
            del v41
        else:
            pass
        del v38, v39
        assert 0 <= v36 < 64, 'Tensor range check'
        assert 0 <= v34 < 64, 'Tensor range check'
        v42 = 64 * v36
        del v36
        v43 = v42 + v34
        del v34, v42
        v44 = v12[v43].item()
        v45 = v6[v43].item()
        del v43
        print(v44, end='')
        del v44
        v49 = ", "
        print(v49, end='')
        del v49
        print(v45, end='')
        del v45
        v51 = v31 + 1
        v31 = v51
        del v51
        v52 = v31 >= 100
        if v52:
            v55 = "; ..."
            print(v55, end='')
            del v55
            break
        else:
            pass
        del v52
        v56 = v31 < 4096
        if v56:
            v59 = "; "
            print(v59, end='')
            del v59
        else:
            pass
        del v56
        v32 += 1 
    del v6, v12, v31, v32
    v62 = "]"
    print(v62, end='')
    del v62
    print()
    return 

if __name__ == '__main__': print(main())
