kernels = {
   'k0': r"""
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
    v5 = v4 + v1;
    int32_t v6;
    v6 = v5 + v0;
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
"""
}
from dpu import DpuSet
import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

import os
from io import StringIO
from sys import stdout
import struct
def method0(v0 : string) -> None:
    if not os.path.exists('kernels'): os.mkdir('kernels')
    v1 = open(f'kernels/{v0}.c','w')
    v1.write(kernels[v0])
    del v1
    os.system(f'dpu-upmem-dpurte-clang -o kernels/{v0}.dpu kernels{v0}.c')
    del v0
    return 
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = 4
    v4 = 'k0'
    method0(v4)
    v5 = DpuSet(nr_dpus=1, binary=f'kernels/{v4}.dpu')
    del v4
    v5.v3 = bytearray(struct.pack('i',v3))
    del v3
    v5.v2 = bytearray(struct.pack('i',v2))
    del v2
    v5.v1 = bytearray(struct.pack('i',v1))
    del v1
    v5.v0 = bytearray(struct.pack('i',v0))
    del v0
    v5.exec()
    v6 = v5.v3.int32()
    v7 = v5.v2.int32()
    v8 = v5.v1.int32()
    del v8
    v9 = v5.v0.int32()
    del v5, v9
    print(v6,v7)
    del v6, v7
    return 

if __name__ == '__main__': print(main())
