module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

type Rec0 =
    | Rec0Case0 of Tuple2
    | Rec0Case1 of Tuple3
    | Rec0Case2 of Tuple1
and Tuple1 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple2 =
    struct
    val mem_0: Rec0
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple3 =
    struct
    val mem_0: Rec0
    val mem_1: Rec0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_1((var_0: Rec0)): int64 =
    match var_0 with
    | Rec0Case0(var_1) ->
        let (var_4: Rec0) = var_1.mem_0
        let (var_5: Rec0) = var_1.mem_1
        let (var_6: int64) = method_1((var_4: Rec0))
        let (var_7: int64) = method_1((var_5: Rec0))
        (var_6 + var_7)
    | Rec0Case1(var_2) ->
        let (var_9: Rec0) = var_2.mem_0
        let (var_10: Rec0) = var_2.mem_1
        let (var_11: int64) = method_1((var_9: Rec0))
        let (var_12: int64) = method_1((var_10: Rec0))
        (var_11 * var_12)
    | Rec0Case2(var_3) ->
        var_3.mem_0
let (var_0: Rec0) = (Rec0Case0(Tuple2((Rec0Case2(Tuple1(1L))), (Rec0Case2(Tuple1(2L))))))
let (var_1: Rec0) = (Rec0Case0(Tuple2((Rec0Case2(Tuple1(3L))), (Rec0Case2(Tuple1(4L))))))
let (var_2: Rec0) = (Rec0Case1(Tuple3(var_0, var_1)))
method_1((var_2: Rec0))
