kernels = [
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__host int32_t v0;
__host int32_t v1;
__host int32_t v2;
int32_t main(){
    int32_t v3;
    v3 = v0 + v1;
    v2 = v3;
    return 0l;
}
""",
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
    v4 = v0 + v1;
    int32_t v5;
    v5 = v4 - v2;
    v3 = v5;
    return 0l;
}
""",
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__host int32_t v0;
__host int32_t v1;
__host int32_t v2;
__host int32_t v3;
__host int32_t v4;
int32_t main(){
    int32_t v5;
    v5 = v0 + v1;
    int32_t v6;
    v6 = v5 * v3;
    int32_t v7;
    v7 = v6 / v2;
    v4 = v7;
    return 0l;
}
""",
   r"""
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
__host int32_t v0;
__host int32_t v1;
__host int32_t v2;
int32_t main(){
    int32_t v3;
    v3 = v0 - v1;
    int32_t v4;
    v4 = v3 - v2;
    v0 = v4;
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
def method0(v0 : i32, v1 : i32, v2 : i32) -> i32:
    v3 = 0
    method1(v3)
    v4 = DpuSet(nr_dpus=1, binary=f'kernels/g{v3}.dpu', profile='backend=simulator')
    del v3
    v4.v0 = bytearray(struct.pack('i',v0))
    del v0
    v4.v1 = bytearray(struct.pack('i',v1))
    del v1
    v4.v2 = bytearray(struct.pack('i',v2))
    del v2
    v4.exec()
    v5 = v4.v2.int32()
    del v4
    return v5
def method2(v0 : i32, v1 : i32, v2 : i32, v3 : i32) -> i32:
    v4 = 1
    method1(v4)
    v5 = DpuSet(nr_dpus=1, binary=f'kernels/g{v4}.dpu', profile='backend=simulator')
    del v4
    v5.v0 = bytearray(struct.pack('i',v0))
    del v0
    v5.v1 = bytearray(struct.pack('i',v1))
    del v1
    v5.v2 = bytearray(struct.pack('i',v2))
    del v2
    v5.v3 = bytearray(struct.pack('i',v3))
    del v3
    v5.exec()
    v6 = v5.v3.int32()
    del v5
    return v6
def method3(v0 : i32, v1 : i32, v2 : i32, v3 : i32, v4 : i32) -> i32:
    v5 = 2
    method1(v5)
    v6 = DpuSet(nr_dpus=1, binary=f'kernels/g{v5}.dpu', profile='backend=simulator')
    del v5
    v6.v0 = bytearray(struct.pack('i',v0))
    del v0
    v6.v1 = bytearray(struct.pack('i',v1))
    del v1
    v6.v2 = bytearray(struct.pack('i',v2))
    del v2
    v6.v3 = bytearray(struct.pack('i',v3))
    del v3
    v6.v4 = bytearray(struct.pack('i',v4))
    del v4
    v6.exec()
    v7 = v6.v4.int32()
    del v6
    return v7
def method4(v0 : i32, v1 : i32, v2 : i32) -> i32:
    v3 = 3
    method1(v3)
    v4 = DpuSet(nr_dpus=1, binary=f'kernels/g{v3}.dpu', profile='backend=simulator')
    del v3
    v4.v0 = bytearray(struct.pack('i',v0))
    del v0
    v4.v1 = bytearray(struct.pack('i',v1))
    del v1
    v4.v2 = bytearray(struct.pack('i',v2))
    del v2
    v4.exec()
    v5 = v4.v0.int32()
    del v4
    return v5
def main():
    v0 = 1
    v1 = 2
    v2 = 0
    v3 = method0(v0, v1, v2)
    del v0, v1, v2
    print(v3)
    del v3
    v4 = 1
    v5 = 2
    v6 = 3
    v7 = 0
    v8 = method2(v4, v5, v6, v7)
    del v4, v5, v6, v7
    print(v8)
    del v8
    v9 = 1
    v10 = 2
    v11 = 3
    v12 = 4
    v13 = 0
    v14 = method3(v9, v10, v11, v12, v13)
    del v9, v10, v11, v12, v13
    print(v14)
    del v14
    v15 = 1
    v16 = 2
    v17 = 3
    v18 = method4(v15, v16, v17)
    del v15, v16, v17
    print(v18)
    del v18
    return 

if __name__ == '__main__': print(main())
