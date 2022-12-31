kernels = [
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <mram.h>
__mram_noinit uint8_t buffer[1024*1024*64];
bool method0(uint32_t v0){
    bool v1;
    v1 = v0 < 64ul;
    return v1;
}
bool method1(uint32_t v0, uint32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
int32_t main(){
    __dma_aligned int32_t v0[8ul];
    __dma_aligned int32_t v1[8ul];
    __dma_aligned int32_t v2[8ul];
    __dma_aligned int32_t v3[8ul];
    uint32_t v4 = 0ul;
    while (method0(v4)){
        uint32_t v6;
        v6 = v4 + 8ul;
        bool v7;
        v7 = 64ul < v6;
        uint32_t v8;
        if (v7){
            v8 = 64ul;
        } else {
            v8 = v6;
        }
        uint32_t v9;
        v9 = v8 - v4;
        __mram_ptr int32_t * v10;
        v10 = (__mram_ptr int32_t *) (buffer + 0ul);
        mram_read(v10 + v4,v0,v9 * sizeof(int32_t));
        __mram_ptr int32_t * v11;
        v11 = (__mram_ptr int32_t *) (buffer + 256ul);
        mram_read(v11 + v4,v1,v9 * sizeof(int32_t));
        __mram_ptr int32_t * v12;
        v12 = (__mram_ptr int32_t *) (buffer + 512ul);
        mram_read(v12 + v4,v2,v9 * sizeof(int32_t));
        uint32_t v13 = 0ul;
        while (method1(v9, v13)){
            int32_t v15;
            v15 = v0[v13];
            int32_t v16;
            v16 = v1[v13];
            int32_t v17;
            v17 = v2[v13];
            int32_t v18;
            v18 = v15 + v16;
            int32_t v19;
            v19 = v18 + v17;
            int32_t v20;
            v20 = v19 + 10l;
            v3[v13] = v20;
            v13 += 1ul;
        }
        __mram_ptr int32_t * v21;
        v21 = (__mram_ptr int32_t *) (buffer + 768ul);
        mram_write(v3,v21 + v4,v9 * sizeof(int32_t));
        v4 += 8ul;
    }
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
def method1(v0 : i32) -> None:
    if not os.path.exists('kernels'): os.mkdir('kernels')
    v1 = open(f'kernels/g{v0}.c','w')
    v1.write(kernels[v0])
    del v1
    if os.system(f'dpu-upmem-dpurte-clang -o kernels/g{v0}.dpu kernels/g{v0}.c') != 0: raise Exception('Compilation failed.')
    del v0
    return 
def method2(v0 : DpuSet, v1 : np.ndarray, v2 : u32) -> None:
    v3 = v1.nbytes % 8 == 0
    v4 = v3 == False
    del v3
    if v4:
        raise Exception("The input array has to be divisible by 8")
    else:
        pass
    del v4
    v0.copy('buffer',bytearray(v1),offset=v2)
    del v0, v1, v2
    return 
def method3(v0 : DpuSet, v1 : np.ndarray, v2 : u32) -> None:
    v3 = v1.nbytes % 8 == 0
    v4 = v3 == False
    del v3
    if v4:
        raise Exception("The input array has to be divisible by 8")
    else:
        pass
    del v4
    v5 = bytearray(v1.nbytes)
    v0.copy(v5,'buffer',offset=v2)
    del v0, v2
    np.copyto(v1,np.frombuffer(v5,dtype=v1.dtype))
    del v1, v5
    return 
def method0(v0 : np.ndarray, v1 : np.ndarray, v2 : np.ndarray, v3 : np.ndarray) -> None:
    v4 = 0
    method1(v4)
    v5 = DpuSet(nr_dpus=1, binary=f'kernels/g{v4}.dpu', profile='backend=simulator')
    del v4
    v6 = 768
    method2(v5, v0, v6)
    del v6
    v7 = 0
    method2(v5, v1, v7)
    del v1, v7
    v8 = 256
    method2(v5, v2, v8)
    del v2, v8
    v9 = 512
    method2(v5, v3, v9)
    del v3, v9
    v5.exec()
    v10 = 768
    return method3(v5, v0, v10)
def main():
    v0 = np.arange(0,64,dtype=np.int32)
    v1 = np.arange(0,64,dtype=np.int32)
    v2 = np.arange(0,64,dtype=np.int32)
    print((v0, v1, v2, 64))
    v3 = np.empty(64,dtype=np.int32)
    method0(v3, v0, v1, v2)
    del v0, v1, v2
    print((v3, 64))
    del v3
    return 

if __name__ == '__main__': print(main())
