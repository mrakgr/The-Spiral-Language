kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
struct Tuple0;
struct Tuple1;
struct US0;
struct Tuple0 {
    int32_t v1;
    bool v0;
    __device__ Tuple0(bool t0, int32_t t1) : v0(t0), v1(t1) {}
    __device__ Tuple0() = default;
};
struct Tuple1 {
    int32_t v0;
    int32_t v1;
    int32_t v2;
    __device__ Tuple1(int32_t t0, int32_t t1, int32_t t2) : v0(t0), v1(t1), v2(t2) {}
    __device__ Tuple1() = default;
};
struct US0 {
    union {
    } v;
    char tag : 2;
};
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ inline bool while_method_1(array<float,4l> v0, bool v1, int32_t v2){
    bool v3;
    v3 = v2 < 4l;
    return v3;
}
__device__ inline bool while_method_2(array<float,4l> v0, int32_t v1){
    bool v2;
    v2 = v1 < 4l;
    return v2;
}
__device__ inline bool while_method_3(int32_t v0, int32_t v1, int32_t v2, int32_t v3){
    bool v4;
    v4 = v3 < v0;
    return v4;
}
__device__ US0 US0_0() { // Eq
    US0 x;
    x.tag = 0;
    return x;
}
__device__ US0 US0_1() { // Gt
    US0 x;
    x.tag = 1;
    return x;
}
__device__ US0 US0_2() { // Lt
    US0 x;
    x.tag = 2;
    return x;
}
extern "C" __global__ void entry0() {
    array<float,4l> v0;
    v0.v[0l] = 1.0f;
    v0.v[1l] = 3.0f;
    v0.v[2l] = 2.0f;
    v0.v[3l] = 4.0f;
    array<float,4l> v1;
    int32_t v2;
    v2 = 0l;
    while (while_method_0(v2)){
        float v4;
        v4 = v0.v[v2];
        v1.v[v2] = v4;
        v2 += 1l ;
    }
    array<float,4l> v5;
    bool v6; int32_t v7;
    Tuple0 tmp0 = Tuple0(true, 1l);
    v6 = tmp0.v0; v7 = tmp0.v1;
    while (while_method_1(v1, v6, v7)){
        int32_t v9;
        v9 = 0l;
        while (while_method_2(v1, v9)){
            int32_t v11;
            v11 = v9 + v7;
            bool v12;
            v12 = v11 < 4l;
            int32_t v13;
            if (v12){
                v13 = v11;
            } else {
                v13 = 4l;
            }
            int32_t v14;
            v14 = v7 * 2l;
            int32_t v15;
            v15 = v9 + v14;
            bool v16;
            v16 = v15 < 4l;
            int32_t v17;
            if (v16){
                v17 = v15;
            } else {
                v17 = 4l;
            }
            int32_t v18; int32_t v19; int32_t v20;
            Tuple1 tmp1 = Tuple1(v9, v13, v9);
            v18 = tmp1.v0; v19 = tmp1.v1; v20 = tmp1.v2;
            while (while_method_3(v17, v18, v19, v20)){
                bool v22;
                v22 = v18 < v13;
                bool v24;
                if (v22){
                    bool v23;
                    v23 = v19 < v17;
                    v24 = v23;
                } else {
                    v24 = false;
                }
                float v54; int32_t v55; int32_t v56;
                if (v24){
                    float v27;
                    if (v6){
                        float v25;
                        v25 = v1.v[v18];
                        v27 = v25;
                    } else {
                        float v26;
                        v26 = v5.v[v18];
                        v27 = v26;
                    }
                    float v30;
                    if (v6){
                        float v28;
                        v28 = v1.v[v19];
                        v30 = v28;
                    } else {
                        float v29;
                        v29 = v5.v[v19];
                        v30 = v29;
                    }
                    bool v31;
                    v31 = v27 < v30;
                    US0 v37;
                    if (v31){
                        v37 = US0_2();
                    } else {
                        bool v33;
                        v33 = v27 > v30;
                        if (v33){
                            v37 = US0_1();
                        } else {
                            v37 = US0_0();
                        }
                    }
                    switch (v37.tag) {
                        case 1: { // Gt
                            int32_t v38;
                            v38 = v19 + 1l;
                            v54 = v30; v55 = v18; v56 = v38;
                            break;
                        }
                        default: {
                            int32_t v39;
                            v39 = v18 + 1l;
                            v54 = v27; v55 = v39; v56 = v19;
                        }
                    }
                } else {
                    if (v22){
                        float v45;
                        if (v6){
                            float v43;
                            v43 = v1.v[v18];
                            v45 = v43;
                        } else {
                            float v44;
                            v44 = v5.v[v18];
                            v45 = v44;
                        }
                        int32_t v46;
                        v46 = v18 + 1l;
                        v54 = v45; v55 = v46; v56 = v19;
                    } else {
                        float v49;
                        if (v6){
                            float v47;
                            v47 = v1.v[v19];
                            v49 = v47;
                        } else {
                            float v48;
                            v48 = v5.v[v19];
                            v49 = v48;
                        }
                        int32_t v50;
                        v50 = v19 + 1l;
                        v54 = v49; v55 = v18; v56 = v50;
                    }
                }
                if (v6){
                    v5.v[v20] = v54;
                } else {
                    v1.v[v20] = v54;
                }
                int32_t v57;
                v57 = v20 + 1l;
                v18 = v55;
                v19 = v56;
                v20 = v57;
            }
            v9 = v15;
        }
        bool v58;
        v58 = v6 == false;
        int32_t v59;
        v59 = v7 * 2l;
        v6 = v58;
        v7 = v59;
    }
    bool v60;
    v60 = v6 == false;
    array<float,4l> v61;
    if (v60){
        v61 = v5;
    } else {
        v61 = v1;
    }
    int32_t v62;
    v62 = 0l;
    while (while_method_0(v62)){
        float v64;
        v64 = v61.v[v62];
        printf("%f\n", v64);
        v62 += 1l ;
    }
    return ;
}
"""
import cupy as cp
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

raw_module = cp.RawModule(code=kernel, backend="nvcc")
def main():
    v0 = 0
    raw_module.get_function(f"entry{v0}")((1, 1, 1),(1, 1, 1),())
    del v0
    return 

if __name__ == '__main__': print(main())
