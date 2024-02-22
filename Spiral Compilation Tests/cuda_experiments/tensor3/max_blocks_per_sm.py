# Get the maximum number of blocks per SM
def max_blocks_per_sm(device, kernel, block_size,is_print=False):
    def floordiv(a,b): return a // b if b != 0 else device.attributes['MaxBlocksPerMultiprocessor']

    # Define the regs per thread.
    regs_per_thread = kernel.num_regs

    # Define the shared memory per block
    shared_mem_per_block = kernel.shared_size_bytes
    attr = device.attributes

    x = min(
        attr['MaxBlocksPerMultiprocessor'],
        floordiv(attr['MaxThreadsPerMultiProcessor'], block_size),
        floordiv(attr['MaxRegistersPerMultiprocessor'], regs_per_thread * block_size),
        floordiv(attr['MaxSharedMemoryPerMultiprocessor'], shared_mem_per_block),
        )
    if is_print:
        print(f"Maximum number of blocks per multi processor is:                      {attr['MaxBlocksPerMultiprocessor']}")
        print(f"The minimum due to the number of threads per multiprocessor is:       {attr['MaxThreadsPerMultiProcessor'] // block_size}")
        print(f"The minimum due to the number of registers per multi processor is:    {attr['MaxRegistersPerMultiprocessor'] // (regs_per_thread * block_size)}")
        print(f"The maximum number of registers per thread is:                        {attr['MaxRegistersPerMultiprocessor'] // attr['MaxThreadsPerMultiProcessor']}")
        print(f"The amount of registers per thread is:                                {regs_per_thread}")
        print(f"The minimum due to the amount of shared memory per multiprocessor is: {floordiv(attr['MaxSharedMemoryPerMultiprocessor'], shared_mem_per_block)}")
        print(f"The amount of shared memory per multiprocessor is:                    {attr['MaxSharedMemoryPerMultiprocessor']}")
        print(f"The amount of shared memory per block used is:                        {shared_mem_per_block}")
        print(f"The true minimum is:                                                  {x}")

    return x

# 'import cupy as cp

# # Get the current device
# device = cp.cuda.Device()


# # Compile a sample kernel and get the number of registers per thread
# kernel_code = '''
# extern "C" __global__ void mykernel(float *x, float *y, float *z) {
#     int tid = threadIdx.x + blockIdx.x * blockDim.x;
#     z[tid] = x[tid] + y[tid];
# }
# '''
# module = cp.RawModule(code=kernel_code, backend='nvcc')
# kernel = module.get_function('mykernel')

# # Define the block size
# block_size = 256

# # Print the result
# print(f'The maximum number of blocks per SM is {max_blocks_per_sm(device, kernel, block_size)}')