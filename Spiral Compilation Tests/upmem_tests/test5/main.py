kernels = [
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__host int32_t v0;
__host int32_t v1;
__host int32_t v2;
__host int32_t v3;
int32_t main(){
    int32_t v4;
    v4 = v3 + v2;
    int32_t v5;
    v5 = v4 - v1;
    int32_t v6;
    v6 = v5 - v0;
    int32_t v7;
    v7 = v3 * v2;
    int32_t v8;
    v8 = v7 * v1;
    int32_t v9;
    v9 = v8 * v0;
    v3 = v6;
    v2 = v9;
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
def method0(v0 : i32) -> None:
    if not os.path.exists('kernels'): os.mkdir('kernels')
    v1 = open(f'kernels/g{v0}.c','w')
    v1.write(kernels[v0])
    del v1
    if os.system(f'dpu-upmem-dpurte-clang -o kernels/g{v0}.dpu kernels/g{v0}.c') != 0: raise Exception('Compilation failed.')
    del v0
    return 
def main():
    v0 = True
    del v0
    v1 = False
    del v1
    v2 = True
    del v2
    v3 = 1
    v4 = 2
    v5 = 3
    v6 = 4
    v7 = 0
    method0(v7)
    v8 = DpuSet(nr_dpus=1, binary=f'kernels/g{v7}.dpu')
    del v7
    v8.v0 = bytearray(struct.pack('i',v6))
    del v6
    v8.v1 = bytearray(struct.pack('i',v5))
    del v5
    v8.v2 = bytearray(struct.pack('i',v4))
    del v4
    v8.v3 = bytearray(struct.pack('i',v3))
    del v3
    v8.exec()
    v9 = v8.v0.int32()
    v10 = v8.v1.int32()
    v11 = v8.v2.int32()
    del v11
    v12 = v8.v3.int32()
    del v8, v12
    print(v9,v10)
    del v9, v10
    return 

if __name__ == '__main__': print(main())
