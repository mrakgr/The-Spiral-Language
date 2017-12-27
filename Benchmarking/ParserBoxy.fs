module ParserBoxy

type Union0 =
    | Union0Case0 of Tuple3
    | Union0Case1 of Tuple4
and Env1 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple2 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    val mem_2: uint64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple3 =
    struct
    val mem_0: string
    val mem_1: Env1
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple4 =
    struct
    val mem_0: uint64
    val mem_1: Env1
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end

let example () = 
    let rec method_0((var_0: string), (var_1: int64)): Union0 =
        let (var_2: uint64) = 0UL
        let (var_3: bool) = (var_1 >= 0L)
        let (var_6: bool) =
            if var_3 then
                let (var_4: int64) = (int64 var_0.Length)
                (var_1 < var_4)
            else
                false
        if var_6 then
            let (var_7: char) = var_0.[int32 var_1]
            let (var_8: int64) = (var_1 + 1L)
            let (var_9: bool) = (var_7 >= '0')
            let (var_11: bool) =
                if var_9 then
                    (var_7 <= '9')
                else
                    false
            if var_11 then
                let (var_12: bool) = (var_2 <= 1844674407370955161UL)
                if var_12 then
                    let (var_13: uint64) = (var_2 * 10UL)
                    let (var_14: uint64) = System.Convert.ToUInt64(var_7)
                    let (var_15: uint64) = (var_13 + var_14)
                    let (var_16: uint64) = System.Convert.ToUInt64('0')
                    let (var_17: uint64) = (var_15 - var_16)
                    let (var_18: bool) = (var_2 < var_17)
                    if var_18 then
                        method_1((var_17: uint64), (var_0: string), (var_8: int64))
                    else
                        (Union0Case0(Tuple3("puint64", (Env1(var_8)))))
                else
                    (Union0Case0(Tuple3("puint64", (Env1(var_8)))))
            else
                (Union0Case0(Tuple3("puint64", (Env1(var_1)))))
        else
            (Union0Case0(Tuple3("puint64", (Env1(var_1)))))
    and method_1((var_0: uint64), (var_1: string), (var_2: int64)): Union0 =
        let (var_3: bool) = (var_2 >= 0L)
        let (var_6: bool) =
            if var_3 then
                let (var_4: int64) = (int64 var_1.Length)
                (var_2 < var_4)
            else
                false
        if var_6 then
            let (var_7: char) = var_1.[int32 var_2]
            let (var_8: int64) = (var_2 + 1L)
            let (var_9: bool) = (var_7 >= '0')
            let (var_11: bool) =
                if var_9 then
                    (var_7 <= '9')
                else
                    false
            if var_11 then
                let (var_12: bool) = (var_0 <= 1844674407370955161UL)
                if var_12 then
                    let (var_13: uint64) = (var_0 * 10UL)
                    let (var_14: uint64) = System.Convert.ToUInt64(var_7)
                    let (var_15: uint64) = (var_13 + var_14)
                    let (var_16: uint64) = System.Convert.ToUInt64('0')
                    let (var_17: uint64) = (var_15 - var_16)
                    let (var_18: bool) = (var_0 < var_17)
                    if var_18 then
                        method_1((var_17: uint64), (var_1: string), (var_8: int64))
                    else
                        (Union0Case0(Tuple3("puint64", (Env1(var_8)))))
                else
                    (Union0Case0(Tuple3("puint64", (Env1(var_8)))))
            else
                method_2((var_0: uint64), (var_1: string), (var_2: int64))
        else
            method_2((var_0: uint64), (var_1: string), (var_2: int64))
    and method_2((var_0: uint64), (var_1: string), (var_2: int64)): Union0 =
        let (var_3: bool) = (var_2 >= 0L)
        let (var_6: bool) =
            if var_3 then
                let (var_4: int64) = (int64 var_1.Length)
                (var_2 < var_4)
            else
                false
        if var_6 then
            let (var_7: char) = var_1.[int32 var_2]
            let (var_8: int64) = (var_2 + 1L)
            let (var_9: bool) = (var_7 = ' ')
            let (var_13: bool) =
                if var_9 then
                    true
                else
                    let (var_10: bool) = (var_7 = '\n')
                    if var_10 then
                        true
                    else
                        (var_7 = '\r')
            if var_13 then
                method_2((var_0: uint64), (var_1: string), (var_8: int64))
            else
                (Union0Case1(Tuple4(var_0, (Env1(var_2)))))
        else
            (Union0Case1(Tuple4(var_0, (Env1(var_2)))))
    let (var_0: string) = "123 456 789"
    let (var_1: int64) = 0L
    let (var_2: Union0) = method_0((var_0: string), (var_1: int64))
    match var_2 with
    | Union0Case0(var_3) ->
        let (var_5: string) = var_3.mem_0
        let (var_6: Env1) = var_3.mem_1
        let (var_7: int64) = var_6.mem_0
        (failwith var_5)
    | Union0Case1(var_4) ->
        let (var_9: uint64) = var_4.mem_0
        let (var_10: Env1) = var_4.mem_1
        let (var_11: int64) = var_10.mem_0
        let (var_12: Union0) = method_0((var_0: string), (var_11: int64))
        match var_12 with
        | Union0Case0(var_13) ->
            let (var_15: string) = var_13.mem_0
            let (var_16: Env1) = var_13.mem_1
            let (var_17: int64) = var_16.mem_0
            (failwith var_15)
        | Union0Case1(var_14) ->
            let (var_19: uint64) = var_14.mem_0
            let (var_20: Env1) = var_14.mem_1
            let (var_21: int64) = var_20.mem_0
            let (var_22: Union0) = method_0((var_0: string), (var_21: int64))
            match var_22 with
            | Union0Case0(var_23) ->
                let (var_25: string) = var_23.mem_0
                let (var_26: Env1) = var_23.mem_1
                let (var_27: int64) = var_26.mem_0
                (failwith var_25)
            | Union0Case1(var_24) ->
                let (var_29: uint64) = var_24.mem_0
                let (var_30: Env1) = var_24.mem_1
                let (var_31: int64) = var_30.mem_0
                Tuple2(var_9, var_19, var_29)
