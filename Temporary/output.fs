module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Union0 =
    | Union0Case0
    | Union0Case1
let (var_0: Union0) = Union0Case0
let (var_1: Union0) = Union0Case0
let (var_2: Union0) = Union0Case0
match var_0 with
| Union0Case0 ->
    1L
| Union0Case1 ->
    match var_1 with
    | Union0Case0 ->
        match var_0 with
        | Union0Case0 ->
            match var_1 with
            | Union0Case0 ->
                3L
            | Union0Case1 ->
                4L
        | Union0Case1 ->
            4L
    | Union0Case1 ->
        2L

