module ParserTermCasted

type Env0 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple1 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    val mem_2: uint64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end

let example() =
    let rec method_0 ((var_2: string)) ((var_0: uint64), (var_1: Env0)): Tuple1 =
        let (var_3: int64) = var_1.mem_0
        let (var_6: (uint64 * Env0 -> Tuple1)) = method_1((var_0: uint64), (var_2: string))
        let (var_9: (string * Env0 -> Tuple1)) = method_3
        method_4((var_9: (string * Env0 -> Tuple1)), (var_6: (uint64 * Env0 -> Tuple1)), (var_2: string), (var_3: int64))
    and method_3 ((var_0: string), (var_1: Env0)): Tuple1 =
        let (var_2: int64) = var_1.mem_0
        (failwith var_0)
    and method_4((var_0: (string * Env0 -> Tuple1)), (var_1: (uint64 * Env0 -> Tuple1)), (var_2: string), (var_3: int64)): Tuple1 =
        let (var_4: uint64) = 0UL
        let (var_5: bool) = (var_3 >= 0L)
        let (var_8: bool) =
            if var_5 then
                let (var_6: int64) = (int64 var_2.Length)
                (var_3 < var_6)
            else
                false
        if var_8 then
            let (var_9: char) = var_2.[int32 var_3]
            let (var_10: int64) = (var_3 + 1L)
            let (var_11: bool) = (var_9 >= '0')
            let (var_13: bool) =
                if var_11 then
                    (var_9 <= '9')
                else
                    false
            if var_13 then
                let (var_14: bool) = (var_4 <= 1844674407370955161UL)
                if var_14 then
                    let (var_15: uint64) = (var_4 * 10UL)
                    let (var_16: uint64) = System.Convert.ToUInt64(var_9)
                    let (var_17: uint64) = (var_15 + var_16)
                    let (var_18: uint64) = System.Convert.ToUInt64('0')
                    let (var_19: uint64) = (var_17 - var_18)
                    let (var_20: bool) = (var_4 < var_19)
                    if var_20 then
                        method_5((var_19: uint64), (var_0: (string * Env0 -> Tuple1)), (var_1: (uint64 * Env0 -> Tuple1)), (var_2: string), (var_10: int64))
                    else
                        var_0("puint64", (Env0(var_10)))
                else
                    var_0("puint64", (Env0(var_10)))
            else
                var_0("puint64", (Env0(var_3)))
        else
            var_0("puint64", (Env0(var_3)))
    and method_1 ((var_2: uint64), (var_3: string)) ((var_0: uint64), (var_1: Env0)): Tuple1 =
        let (var_4: int64) = var_1.mem_0
        let (var_7: (uint64 * Env0 -> Tuple1)) = method_2((var_2: uint64), (var_0: uint64), (var_3: string))
        let (var_10: (string * Env0 -> Tuple1)) = method_3
        method_4((var_10: (string * Env0 -> Tuple1)), (var_7: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_4: int64))
    and method_5((var_0: uint64), (var_1: (string * Env0 -> Tuple1)), (var_2: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_4: int64)): Tuple1 =
        let (var_5: bool) = (var_4 >= 0L)
        let (var_8: bool) =
            if var_5 then
                let (var_6: int64) = (int64 var_3.Length)
                (var_4 < var_6)
            else
                false
        if var_8 then
            let (var_9: char) = var_3.[int32 var_4]
            let (var_10: int64) = (var_4 + 1L)
            let (var_11: bool) = (var_9 >= '0')
            let (var_13: bool) =
                if var_11 then
                    (var_9 <= '9')
                else
                    false
            if var_13 then
                let (var_14: bool) = (var_0 <= 1844674407370955161UL)
                if var_14 then
                    let (var_15: uint64) = (var_0 * 10UL)
                    let (var_16: uint64) = System.Convert.ToUInt64(var_9)
                    let (var_17: uint64) = (var_15 + var_16)
                    let (var_18: uint64) = System.Convert.ToUInt64('0')
                    let (var_19: uint64) = (var_17 - var_18)
                    let (var_20: bool) = (var_0 < var_19)
                    if var_20 then
                        method_5((var_19: uint64), (var_1: (string * Env0 -> Tuple1)), (var_2: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_10: int64))
                    else
                        var_1("puint64", (Env0(var_10)))
                else
                    var_1("puint64", (Env0(var_10)))
            else
                method_6((var_1: (string * Env0 -> Tuple1)), (var_0: uint64), (var_2: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_4: int64))
        else
            method_6((var_1: (string * Env0 -> Tuple1)), (var_0: uint64), (var_2: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_4: int64))
    and method_2 ((var_2: uint64), (var_3: uint64), (var_4: string)) ((var_0: uint64), (var_1: Env0)): Tuple1 =
        let (var_5: int64) = var_1.mem_0
        Tuple1(var_2, var_3, var_0)
    and method_6((var_0: (string * Env0 -> Tuple1)), (var_1: uint64), (var_2: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_4: int64)): Tuple1 =
        let (var_5: bool) = (var_4 >= 0L)
        let (var_8: bool) =
            if var_5 then
                let (var_6: int64) = (int64 var_3.Length)
                (var_4 < var_6)
            else
                false
        if var_8 then
            let (var_9: char) = var_3.[int32 var_4]
            let (var_10: int64) = (var_4 + 1L)
            let (var_11: bool) = (var_9 = ' ')
            let (var_15: bool) =
                if var_11 then
                    true
                else
                    let (var_12: bool) = (var_9 = '\n')
                    if var_12 then
                        true
                    else
                        (var_9 = '\r')
            if var_15 then
                method_6((var_0: (string * Env0 -> Tuple1)), (var_1: uint64), (var_2: (uint64 * Env0 -> Tuple1)), (var_3: string), (var_10: int64))
            else
                var_2(var_1, (Env0(var_4)))
        else
            var_2(var_1, (Env0(var_4)))
    let (var_0: string) = "123 456 789"
    let (var_1: int64) = 0L
    let (var_4: (uint64 * Env0 -> Tuple1)) = method_0((var_0: string))
    let (var_7: (string * Env0 -> Tuple1)) = method_3
    method_4((var_7: (string * Env0 -> Tuple1)), (var_4: (uint64 * Env0 -> Tuple1)), (var_0: string), (var_1: int64))