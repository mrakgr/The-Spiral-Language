kernel = r"""
template <typename el, int dim> struct array { el v[dim]; };
extern "C" __global__ void entry0() {
    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> v0;
    wmma::fragment<wmma::matrix_a, 16l, 16l, 8l, wmma::precision::tf32, wmma::row_major> & v1 = v0;
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

options = []
options.append('--diag-suppress=550')
options.append('--define-macro=NDEBUG')
options.append('--restrict')
raw_module = cp.RawModule(code=kernel, backend='nvrtc', enable_cooperative_groups=False, options=tuple(options))
from max_blocks_per_sm import max_blocks_per_sm
def main():
    v0 = cp.random.normal(0,1,65536,cp.float32)
    v1 = v0.size
    v2 = 65536 == v1
    del v1
    v3 = v2 == False
    if v3:
        v4 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v2, v4
        del v4
    else:
        pass
    del v2, v3
    v5 = cp.random.normal(0,1,65536,cp.float32)
    v6 = v5.size
    v7 = 65536 == v6
    del v6
    v8 = v7 == False
    if v8:
        v9 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v7, v9
        del v9
    else:
        pass
    del v7, v8
    v10 = cp.random.normal(0,1,65536,cp.float32)
    v11 = v10.size
    v12 = 65536 == v11
    del v11
    v13 = v12 == False
    if v13:
        v14 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v12, v14
        del v14
    else:
        pass
    del v12, v13
    v15 = v10.reshape((256, 256))
    del v10
    v16 = v5.reshape((256, 256))
    del v5
    v17 = v0.reshape((256, 256))
    del v17
    v18 = (cp.matmul(v15,v16)).flatten()
    del v15, v16
    v19 = v18.size
    v20 = 65536 == v19
    del v19
    v21 = v20 == False
    if v21:
        v22 = "The total length of the reshaped tensor dimension must match that of the original one."
        assert v20, v22
        del v22
    else:
        pass
    del v20, v21
    v23 = 0
    v24 = raw_module.get_function(f"entry{v23}")
    del v23
    v24.max_dynamic_shared_size_bytes = 54272 
    v24((1,),(512,),(),shared_mem=54272)
    del v24
    max_blocks_per_sm(cp.cuda.Device(),raw_module.get_function('entry0'),1024,is_print=True)
    v25 = cp.max(cp.abs(v0-v18))
    del v0, v18
    return v25

if __name__ == '__main__': print(main())
