kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
struct Tuple0;
struct Tuple0 {
    long v0;
    long v1;
    long v2;
    __device__ Tuple0(long t0, long t1, long t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple0() = default;
};
extern "C" __global__ void entry0() {
    long v0;
    v0 = sizeof(Tuple0);
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--diag-suppress=550')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=True, options=tuple(options))
def main():
    v0 = cp.random.normal(0,1,65536,cp.float32)
    v1 = v0.size
    v2 = 65536 == v1
    del v1
    v3 = v2 == False
    if v3:
        v5 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v5
        del v5
    else:
        pass
    del v2, v3
    v6 = cp.random.normal(0,1,32768,cp.float32)
    v7 = v6.size
    v8 = 32768 == v7
    del v7
    v9 = v8 == False
    if v9:
        v11 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v8, v11
        del v11
    else:
        pass
    del v8, v9
    v12 = cp.random.normal(0,1,32768,cp.float32)
    v13 = v12.size
    v14 = 32768 == v13
    del v13
    v15 = v14 == False
    if v15:
        v17 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v14, v17
        del v17
    else:
        pass
    del v14, v15
    v18 = v12.reshape((128, 256))
    del v12
    v19 = cp.transpose(v18)
    del v18
    v20 = v6.reshape((128, 256))
    del v6
    v21 = v0.reshape((256, 256))
    v22 = (cp.matmul(v19,v20)+v21).flatten()
    del v19, v20, v21
    v23 = v22.size
    v24 = 65536 == v23
    del v23
    v25 = v24 == False
    if v25:
        v27 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v24, v27
        del v27
    else:
        pass
    del v24, v25
    v28 = 0
    raw_module.get_function(f"entry{v28}")((24, 1, 1),(256, 1, 1),())
    del v28
    v29 = cp.max(cp.abs(v0-v22))
    del v0, v22
    return v29

if __name__ == '__main__': print(main())
