upmem0 = """
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
__host int32_t v0
__host int32_t v1
__host int32_t v2
__host int32_t v3
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
import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

from dpu import DpuSet
from io import StringIO
from sys import stdout
import struct
def main():
    v0 = 1
    v1 = 2
    v2 = 3
    v3 = 4
    v4 = upmem0
    v5 = DpuSet(nr_dpus=1, c_source=StringIO(v4))
    del v4
    v5.v3 = struct.pack('l',v3)
    del v3
    v5.v2 = struct.pack('l',v2)
    del v2
    v5.v1 = struct.pack('l',v1)
    del v1
    v5.v0 = struct.pack('l',v0)
    del v0
    v5.exec(log=stdout)
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
