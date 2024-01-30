import cupy as cp

kernel_code = '''
#include <mma.h>
extern "C" __global__ void mykernel() {
    printf("Hello.\\n");
}
'''
module = cp.RawModule(code=kernel_code, backend='nvrtc')
module.get_function('mykernel')((1,),(1,),())