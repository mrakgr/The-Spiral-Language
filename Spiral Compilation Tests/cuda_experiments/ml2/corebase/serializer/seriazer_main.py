kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

class US0_0(NamedTuple): # A
    v0 : i32
    tag = 0
class US0_1(NamedTuple): # B
    v0 : i8
    v1 : i8
    v2 : i32
    tag = 1
class US0_2(NamedTuple): # C
    tag = 2
US0 = Union[US0_0, US0_1, US0_2]
def main():
    v0 = cp.empty(32,dtype=cp.uint8)
    v2 = v0[0:].view(cp.int8)
    v3 = v2
    v3[0] = 1
    del v3
    v5 = v0[1:].view(cp.int8)
    v6 = v5
    v6[0] = 2
    del v6
    v8 = v0[4:].view(cp.int32)
    v9 = v8
    v9[0] = 4
    del v9
    v11 = v0[8:].view(cp.int32)
    v12 = v11
    v12[0] = 2
    del v12
    v14 = v0[20:].view(cp.float32)
    v15 = v14
    v15[0] = 234.5
    del v15
    v17 = v0[24:].view(cp.float64)
    v18 = v17
    v18[0] = 12.0
    del v18
    v20 = v0[0:].view(cp.int8)
    v21 = v20
    v22 = v21[0].item()
    del v21
    v24 = v0[1:].view(cp.int8)
    v25 = v24
    v26 = v25[0].item()
    del v25
    v28 = v0[4:].view(cp.int32)
    v29 = v28
    v30 = v29[0].item()
    del v29
    v32 = v0[8:].view(cp.int32)
    v33 = v32
    v34 = v33[0].item()
    del v33
    if v34 == 0:
        v37 = v0[12:].view(cp.int32)
        v38 = v37
        v39 = v38[0].item()
        del v38
        v55 = US0_0(v39)
    elif v34 == 1:
        v42 = v0[12:].view(cp.int8)
        v43 = v42
        v44 = v43[0].item()
        del v43
        v46 = v0[13:].view(cp.int8)
        v47 = v46
        v48 = v47[0].item()
        del v47
        v50 = v0[16:].view(cp.int32)
        v51 = v50
        v52 = v51[0].item()
        del v51
        v55 = US0_1(v44, v48, v52)
    elif v34 == 2:
        v55 = US0_2()
    else:
        raise Exception("Invalid tag.")
    del v34
    v57 = v0[20:].view(cp.float32)
    v58 = v57
    v59 = v58[0].item()
    del v58
    v61 = v0[24:].view(cp.float64)
    v62 = v61
    del v0
    v63 = v62[0].item()
    del v62
    return v22, v26, v30, v55, v59, v63

if __name__ == '__main__': print(main())
