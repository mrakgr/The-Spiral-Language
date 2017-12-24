module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Union0 =
    | Union0Case0
    | Union0Case1
let rec method_0(): int64 =
    1L
and method_1(): int64 =
    3L
and method_2(): int64 =
    2L
and method_3(): int64 =
    4L
let (var_0: Union0) = Union0Case0
let (var_1: Union0) = Union0Case0
let (var_2: Union0) = Union0Case0
match var_0 with
| Union0Case0 ->
    match var_1 with
    | Union0Case0 ->
        method_0()
    | Union0Case1 ->
        match var_2 with
        | Union0Case0 ->
            method_1()
        | Union0Case1 ->
            method_2()
| Union0Case1 ->
    match var_2 with
    | Union0Case0 ->
        method_1()
    | Union0Case1 ->
        method_3()

