import cupy as cp

# Compile a sample kernel and get the number of registers per thread
kernel_code = '''
#include <mma.h>
extern "C" __global__ void mykernel() {
}
'''
module = cp.RawModule(code=kernel_code, backend='nvcc')
kernel = module.get_function('mykernel')