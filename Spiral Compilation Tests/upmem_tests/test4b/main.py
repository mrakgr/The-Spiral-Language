kernels = [
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <mram.h>
int32_t main(){
    __dma_aligned uint8_t v0[512];
    printf("%u\n",DPU_MRAM_HEAP_POINTER+1);
    mram_read(DPU_MRAM_HEAP_POINTER, v0, sizeof(v0));
    return 0l;
}
""",
]
from dpu import DpuSet
import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import os
from io import StringIO
from sys import stdout
import struct
def main():
    v0 = 0
    v1 = f'kernels/g{v0}'
    if not os.path.exists('kernels'): os.mkdir('kernels')
    v2 = open(f'{v1}.c','w')
    v2.write(kernels[v0])
    del v0, v2
    if os.system(f'dpu-upmem-dpurte-clang -o {v1}.dpu {v1}.c') != 0: raise Exception('Compilation failed.')
    v3 = DpuSet(nr_dpus=1, binary=f'{v1}.dpu')
    del v1
    v3.exec(log=stdout)
    del v3
    return 

if __name__ == '__main__': print(main())
