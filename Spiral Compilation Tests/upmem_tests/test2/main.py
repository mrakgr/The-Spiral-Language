upmem0 = """
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    int v0[1l];
    return 1l;
}
"""
upmem1 = """
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    int v0[2l];
    return 2l;
}
"""
upmem2 = """
#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
int32_t main(){
    int v0[3l];
    return 3l;
}
"""
import numpy as np
from dataclasses import dataclass
from typing import NamedTuple, Union, Callable, Tuple
i8 = i16 = i32 = i64 = u8 = u16 = u32 = u64 = int; f32 = f64 = float; char = string = str

def main():
    v0 = upmem0
    del v0
    v1 = upmem1
    del v1
    v2 = upmem2
    del v2
    return 

if __name__ == '__main__': print(main())
