# Get the maximum number of blocks per SM
def max_blocks_per_sm(device, kernel, block_size):
    def floordiv(a,b): return a // b if b != 0 else device.attributes['MaxBlocksPerMultiprocessor']

    # Define the regs per thread.
    regs_per_thread = kernel.num_regs

    # Define the shared memory per block
    shared_mem_per_block = kernel.shared_size_bytes

    return min(
        device.attributes['MaxBlocksPerMultiprocessor'],
        floordiv(device.attributes['MaxThreadsPerMultiProcessor'], block_size),
        floordiv(device.attributes['MaxRegistersPerMultiprocessor'], regs_per_thread * block_size),
        floordiv(device.attributes['MaxSharedMemoryPerMultiprocessor'], shared_mem_per_block),
        )

import cupy as cp

# Get the current device
device = cp.cuda.Device()


# Compile a sample kernel and get the number of registers per thread
kernel_code = '''
extern "C" __global__ void mykernel(float *x, float *y, float *z) {
    int tid = threadIdx.x + blockIdx.x * blockDim.x;
    z[tid] = x[tid] + y[tid];
}
'''
module = cp.RawModule(code=kernel_code, backend='nvcc')
kernel = module.get_function('mykernel')

# Define the block size
block_size = 256

# Print the result
print(f'The maximum number of blocks per SM is {max_blocks_per_sm(device, kernel, block_size)}')
