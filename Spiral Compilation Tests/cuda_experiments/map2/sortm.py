kernel = r"""
#pragma warning(disable: 4101 4065 4060)
// Add these as extra argument to the compiler to suppress the rest:
// --diag-suppress 186 --diag-suppress 177 --diag-suppress 550
#include <cstdint>
#include <array>
template <typename el, int dim> struct array { el v[dim]; };
#include <algorithm>
typedef bool (* Fun0)(float, float);
__device__ inline bool while_method_0(int32_t v0){
    bool v1;
    v1 = v0 < 4l;
    return v1;
}
__device__ bool ClosureMethod0(float tup0, float tup1){
    float v0 = tup0; float v1 = tup1;
    bool v2;
    v2 = v0 < v1;
    return v2;
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
    Fun0 v5;
    v5 = ClosureMethod0;
    std::sort(&v1.v[0],&v1.v[4l],v5);
    int32_t v6;
    v6 = 0l;
    while (while_method_0(v6)){
        float v8;
        v8 = v1.v[v6];
        printf("%f\n", v8);
        v6 += 1l ;
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
