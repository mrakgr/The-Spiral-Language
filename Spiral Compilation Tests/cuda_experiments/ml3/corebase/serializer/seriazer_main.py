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
        self.length = length
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
    v1 = v0[0:].view(cp.int8)
    v1[0] = 1
    del v1
    v2 = v0[1:].view(cp.int8)
    v2[0] = 2
    del v2
    v3 = v0[4:].view(cp.int32)
    v3[0] = 4
    del v3
    v4 = v0[8:].view(cp.int32)
    v4[0] = 2
    del v4
    v5 = v0[20:].view(cp.float32)
    v5[0] = 234.5
    del v5
    v6 = v0[24:].view(cp.float64)
    v6[0] = 12.0
    del v6
    v7 = v0[0:].view(cp.int8)
    v8 = v7[0].item()
    del v7
    v9 = v0[1:].view(cp.int8)
    v10 = v9[0].item()
    del v9
    v11 = v0[4:].view(cp.int32)
    v12 = v11[0].item()
    del v11
    v13 = v0[8:].view(cp.int32)
    v14 = v13[0].item()
    del v13
    if v14 == 0:
        v16 = v0[12:].view(cp.int32)
        v17 = v16[0].item()
        del v16
        v27 = US0_0(v17)
    elif v14 == 1:
        v19 = v0[12:].view(cp.int8)
        v20 = v19[0].item()
        del v19
        v21 = v0[13:].view(cp.int8)
        v22 = v21[0].item()
        del v21
        v23 = v0[16:].view(cp.int32)
        v24 = v23[0].item()
        del v23
        v27 = US0_1(v20, v22, v24)
    elif v14 == 2:
        v27 = US0_2()
    else:
        raise Exception("Invalid tag.")
    del v14
    v28 = v0[20:].view(cp.float32)
    v29 = v28[0].item()
    del v28
    v30 = v0[24:].view(cp.float64)
    del v0
    v31 = v30[0].item()
    del v30
    return v8, v10, v12, v27, v29, v31

if __name__ == '__main__': print(main())
