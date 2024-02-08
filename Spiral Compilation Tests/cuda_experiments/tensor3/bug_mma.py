import cupy as cp

options = []
options.append('--define-macro=NDEBUG')

kernel_code = r'''
#include <mma.h>
using namespace nvcuda;
extern "C" __global__ void mykernel() {
    wmma::fragment<wmma::accumulator, 16, 16, 8, float> v16;
    assert(2==3 /* does this work */ );
    return ;
}
'''
module = cp.RawModule(code=kernel_code, backend='nvrtc', jitify=False, enable_cooperative_groups=True, options=tuple(options))
module.get_function('mykernel')((1,),(1,),())