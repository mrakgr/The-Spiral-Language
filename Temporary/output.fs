module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Union0 =
    | Union0Case0
    | Union0Case1
    | Union0Case2
    | Union0Case3
let rec method_0((var_0: Union0), (var_1: Union0)): bool =
    match var_0 with
    | Union0Case0 ->
        match var_1 with
        | Union0Case0 ->
            true
        | Union0Case1 ->
            false
        | Union0Case2 ->
            false
        | Union0Case3 ->
            false
    | Union0Case1 ->
        match var_1 with
        | Union0Case0 ->
            false
        | Union0Case1 ->
            true
        | Union0Case2 ->
            false
        | Union0Case3 ->
            false
    | Union0Case2 ->
        match var_1 with
        | Union0Case0 ->
            false
        | Union0Case1 ->
            false
        | Union0Case2 ->
            true
        | Union0Case3 ->
            false
    | Union0Case3 ->
        match var_1 with
        | Union0Case0 ->
            false
        | Union0Case1 ->
            false
        | Union0Case2 ->
            false
        | Union0Case3 ->
            true
let (var_0: Union0) = Union0Case0
let (var_1: Union0) = Union0Case1
method_0((var_0: Union0), (var_1: Union0))
