kernels = [
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__mram_noinit uint8_t buffer[1024*1024*64];
bool method0(uint32_t v0, uint32_t v1){
    bool v2;
    v2 = v1 < v0;
    return v2;
}
__host uint32_t v0;
__host uint32_t v1;
__host uint32_t v2;
__host uint32_t v3;
__host uint32_t v4;
int32_t main(){
    uint32_t v5 = 0u;
    while (method0(v3, v5)){
        int32_t v7;
        v7 = ((__mram_ptr int32_t *) (buffer + v2))[v5];
        int32_t v8;
        v8 = ((__mram_ptr int32_t *) (buffer + 0u))[v5];
        int32_t v9;
        v9 = v7 + v8;
        ((__mram_ptr int32_t *) (buffer + v4))[v5] = v9;
        v5 += 1u;
    }
    return 0;
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
def method0(v0 : np.ndarray, v1 : np.ndarray, v2 : np.ndarray) -> np.ndarray:
    v3 = len(v1)
    v4 = v1.nbytes
    v5 = v4 + 7
    del v4
    v6 = v5 // 8
    del v5
    v7 = v6 * 8
    del v6
    v8 = len(v2)
    v9 = v2.nbytes
    v10 = v7 + v9
    del v9
    v11 = v10 + 7
    del v10
    v12 = v11 // 8
    del v11
    v13 = v12 * 8
    del v12
    v14 = len(v0)
    v15 = v0.nbytes
    v16 = v13 + v15
    del v15
    v17 = v16 + 7
    del v16
    v18 = v17 // 8
    del v17
    v19 = v18 * 8
    del v18, v19
    v20 = 0
    method1(v20)
    v21 = DpuSet(nr_dpus=1, binary=f'kernels/g{v20}.dpu', profile='backend=simulator')
    del v20
    v21.v0 = bytearray(struct.pack('I',v3))
    del v3
    v21.v1 = bytearray(struct.pack('I',v8))
    del v8
    v21.v2 = bytearray(struct.pack('I',v7))
    v21.v3 = bytearray(struct.pack('I',v14))
    del v14
    v21.v4 = bytearray(struct.pack('I',v13))
    method2(v21, v0, v13)
    v22 = 0
    method2(v21, v1, v22)
    del v1, v22
    method2(v21, v2, v7)
    del v2, v7
    v21.exec()
    method3(v21, v0, v13)
    del v13, v21
    return v0
def main():
    v0 = np.arange(0,64,dtype=np.int32)
    v1 = np.arange(0,64,dtype=np.int32)
    v2 = np.arange(0,64,dtype=np.int32)
    print(v0)
    v3 = method0(v0, v2, v1)
    del v0, v1, v2
    print(v3)
    del v3
    return 

if __name__ == '__main__': print(main())
