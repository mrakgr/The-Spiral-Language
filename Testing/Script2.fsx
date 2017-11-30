type EnvStack0 =
    struct
    val mem_0: (int64 [])
    val mem_1: (int64 [])
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvStack1 =
    struct
    val mem_0: (int64 [])
    val mem_1: (int64 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end

let rec method_17(var_3: EnvStack0): unit = ()

EnvStack1([|0L|],[|0L|])