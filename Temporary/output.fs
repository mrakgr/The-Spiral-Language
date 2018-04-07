module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type EnvStack0 =
    struct
    val mem_0: System.Random
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack1 =
    struct
    val mem_0: EnvStack0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union2 =
    | Union2Case0 of Tuple10
    | Union2Case1
and EnvHeapMutable3 =
    {
    mutable mem_0: int64
    mutable mem_1: Union2
    mutable mem_2: string
    mutable mem_3: int64
    }
and EnvHeapMutable4 =
    {
    mutable mem_0: int64
    mutable mem_1: Union2
    mutable mem_2: string
    mutable mem_3: int64
    mutable mem_4: EnvStack0
    }
and Env5 =
    struct
    val mem_0: Union6
    val mem_1: Union7
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union6 =
    | Union6Case0
    | Union6Case1
    | Union6Case2
    | Union6Case3
    | Union6Case4
    | Union6Case5
    | Union6Case6
    | Union6Case7
    | Union6Case8
    | Union6Case9
    | Union6Case10
    | Union6Case11
    | Union6Case12
and Union7 =
    | Union7Case0
    | Union7Case1
    | Union7Case2
    | Union7Case3
and EnvHeapMutable8 =
    {
    mutable mem_0: (Env5 [])
    mutable mem_1: int64
    mutable mem_2: System.Random
    }
and Env9 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple10 =
    struct
    val mem_0: Env5
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap11 =
    {
    mem_0: int64
    mem_1: Union2
    mem_2: int64
    }
and Union12 =
    | Union12Case0 of Tuple14
    | Union12Case1
and Env13 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Tuple14 =
    struct
    val mem_0: Env13
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0((var_0: int64), (var_1: EnvHeapMutable8), (var_2: EnvHeapMutable3), (var_3: EnvHeapMutable4), (var_4: int64), (var_5: int64), (var_6: int64)): Env9 =
    let (var_7: bool) = (var_6 < 10000L)
    if var_7 then
        method_1((var_2: EnvHeapMutable3), (var_0: int64))
        method_2((var_3: EnvHeapMutable4), (var_0: int64))
        method_3((var_1: EnvHeapMutable8), (var_2: EnvHeapMutable3), (var_3: EnvHeapMutable4))
        let (var_8: int64) = var_2.mem_0
        let (var_9: bool) = (var_8 = 0L)
        let (var_18: Env9) =
            if var_9 then
                let (var_10: int64) = var_3.mem_0
                let (var_11: bool) = (var_10 > 0L)
                let (var_12: bool) = (var_11 = false)
                if var_12 then
                    (failwith "If a is 0 then b much be positive.")
                else
                    ()
                let (var_13: int64) = (var_5 + 1L)
                (Env9(var_4, var_13))
            else
                let (var_14: int64) = var_3.mem_0
                let (var_15: bool) = (var_14 = 0L)
                let (var_16: bool) = (var_15 = false)
                if var_16 then
                    (failwith "If a positive then b much 0.")
                else
                    ()
                let (var_17: int64) = (var_4 + 1L)
                (Env9(var_17, var_5))
        let (var_19: int64) = var_18.mem_0
        let (var_20: int64) = var_18.mem_1
        let (var_21: int64) = (var_6 + 1L)
        method_0((var_0: int64), (var_1: EnvHeapMutable8), (var_2: EnvHeapMutable3), (var_3: EnvHeapMutable4), (var_19: int64), (var_20: int64), (var_21: int64))
    else
        (Env9(var_4, var_5))
and method_1((var_0: EnvHeapMutable3), (var_1: int64)): unit =
    var_0.mem_0 <- var_1
and method_2((var_0: EnvHeapMutable4), (var_1: int64)): unit =
    var_0.mem_0 <- var_1
and method_3((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4)): unit =
    let (var_3: string) = var_1.mem_2
    let (var_4: int64) = var_1.mem_0
    let (var_5: string) = var_2.mem_2
    let (var_6: int64) = var_2.mem_0
    method_4((var_0: EnvHeapMutable8))
    method_6((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4))
    method_14((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4))
    method_27((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4))
    let (var_7: int64) = var_1.mem_0
    let (var_8: bool) = (var_7 > 0L)
    let (var_9: int64) =
        if var_8 then
            1L
        else
            0L
    let (var_10: int64) = var_2.mem_0
    let (var_11: bool) = (var_10 > 0L)
    let (var_13: int64) =
        if var_11 then
            (var_9 + 1L)
        else
            var_9
    let (var_14: bool) = (var_13 = 1L)
    if var_14 then
        let (var_15: int64) = var_1.mem_0
        let (var_16: bool) = (var_15 > 0L)
        if var_16 then
            let (var_17: string) = var_1.mem_2
            ()
        else
            ()
        let (var_18: int64) = var_2.mem_0
        let (var_19: bool) = (var_18 > 0L)
        if var_19 then
            let (var_20: string) = var_2.mem_2
            ()
        else
            ()
    else
        method_48((var_0: EnvHeapMutable8), (var_2: EnvHeapMutable4), (var_1: EnvHeapMutable3))
and method_4((var_0: EnvHeapMutable8)): unit =
    let (var_1: System.Random) = var_0.mem_2
    let (var_2: System.Random) = var_0.mem_2
    let (var_3: System.Random) = var_0.mem_2
    let (var_4: (Env5 [])) = var_0.mem_0
    let (var_5: int64) = 0L
    method_5((var_1: System.Random), (var_2: System.Random), (var_3: System.Random), (var_4: (Env5 [])), (var_5: int64))
    let (var_6: int64) = 52L
    var_0.mem_1 <- var_6
and method_6((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4)): unit =
    method_7((var_1: EnvHeapMutable3), (var_0: EnvHeapMutable8), (var_2: EnvHeapMutable4))
    method_11((var_2: EnvHeapMutable4), (var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3))
and method_14((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4)): unit =
    let (var_3: int64) = 2L
    let (var_4: int64) = var_1.mem_0
    let (var_5: bool) = (var_4 > 0L)
    let (var_7: bool) =
        if var_5 then
            method_15((var_1: EnvHeapMutable3))
        else
            false
    let (var_11: int64) =
        if var_7 then
            let (var_8: int64) = var_1.mem_3
            let (var_9: bool) = (0L > var_8)
            if var_9 then
                0L
            else
                var_8
        else
            0L
    let (var_12: int64) = var_2.mem_0
    let (var_13: bool) = (var_12 > 0L)
    let (var_15: bool) =
        if var_13 then
            method_16((var_2: EnvHeapMutable4))
        else
            false
    let (var_19: int64) =
        if var_15 then
            let (var_16: int64) = var_2.mem_3
            let (var_17: bool) = (var_11 > var_16)
            if var_17 then
                var_11
            else
                var_16
        else
            var_11
    let (var_20: int64) = var_1.mem_0
    let (var_21: bool) = (var_20 > 0L)
    let (var_23: bool) =
        if var_21 then
            method_15((var_1: EnvHeapMutable3))
        else
            false
    let (var_24: int64) =
        if var_23 then
            1L
        else
            0L
    let (var_25: int64) = var_2.mem_0
    let (var_26: bool) = (var_25 > 0L)
    let (var_28: bool) =
        if var_26 then
            method_16((var_2: EnvHeapMutable4))
        else
            false
    let (var_30: int64) =
        if var_28 then
            (var_24 + 1L)
        else
            var_24
    let (var_31: int64) = 0L
    method_17((var_19: int64), (var_3: int64), (var_30: int64), (var_31: int64), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4), (var_0: EnvHeapMutable8))
and method_27((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4)): unit =
    method_28((var_1: EnvHeapMutable3))
    method_29((var_2: EnvHeapMutable4))
    let (var_3: int64) = var_1.mem_0
    let (var_4: int64) = var_1.mem_3
    let (var_5: int64) = (var_3 + var_4)
    let (var_6: int64) = var_2.mem_0
    let (var_7: int64) = var_2.mem_3
    let (var_8: int64) = (var_6 + var_7)
    method_30((var_1: EnvHeapMutable3), (var_2: EnvHeapMutable4))
    method_46((var_5: int64), (var_1: EnvHeapMutable3))
    method_47((var_8: int64), (var_2: EnvHeapMutable4))
and method_48((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3)): unit =
    let (var_3: string) = var_1.mem_2
    let (var_4: int64) = var_1.mem_0
    let (var_5: string) = var_2.mem_2
    let (var_6: int64) = var_2.mem_0
    method_4((var_0: EnvHeapMutable8))
    method_49((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3))
    method_54((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3))
    method_56((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3))
    let (var_7: int64) = var_1.mem_0
    let (var_8: bool) = (var_7 > 0L)
    let (var_9: int64) =
        if var_8 then
            1L
        else
            0L
    let (var_10: int64) = var_2.mem_0
    let (var_11: bool) = (var_10 > 0L)
    let (var_13: int64) =
        if var_11 then
            (var_9 + 1L)
        else
            var_9
    let (var_14: bool) = (var_13 = 1L)
    if var_14 then
        let (var_15: int64) = var_1.mem_0
        let (var_16: bool) = (var_15 > 0L)
        if var_16 then
            let (var_17: string) = var_1.mem_2
            ()
        else
            ()
        let (var_18: int64) = var_2.mem_0
        let (var_19: bool) = (var_18 > 0L)
        if var_19 then
            let (var_20: string) = var_2.mem_2
            ()
        else
            ()
    else
        method_3((var_0: EnvHeapMutable8), (var_2: EnvHeapMutable3), (var_1: EnvHeapMutable4))
and method_5((var_0: System.Random), (var_1: System.Random), (var_2: System.Random), (var_3: (Env5 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 51L)
    if var_5 then
        let (var_6: int32) = (int32 var_4)
        let (var_7: int32) = var_0.Next(var_6, 52)
        let (var_8: Env5) = var_3.[int32 var_4]
        let (var_9: Union6) = var_8.mem_0
        let (var_10: Union7) = var_8.mem_1
        let (var_11: Env5) = var_3.[int32 var_7]
        var_3.[int32 var_4] <- var_11
        var_3.[int32 var_7] <- (Env5(var_9, var_10))
        let (var_12: int64) = (var_4 + 1L)
        method_5((var_0: System.Random), (var_1: System.Random), (var_2: System.Random), (var_3: (Env5 [])), (var_12: int64))
    else
        ()
and method_7((var_0: EnvHeapMutable3), (var_1: EnvHeapMutable8), (var_2: EnvHeapMutable4)): unit =
    let (var_3: int64) = var_0.mem_0
    let (var_4: bool) = (var_3 > 0L)
    if var_4 then
        let (var_5: int64) = method_8((var_0: EnvHeapMutable3))
        let (var_6: string) = var_0.mem_2
        let (var_7: Env5) = method_9((var_1: EnvHeapMutable8))
        let (var_8: Union6) = var_7.mem_0
        let (var_9: Union7) = var_7.mem_1
        method_10((var_0: EnvHeapMutable3), (var_8: Union6), (var_9: Union7))
    else
        ()
and method_11((var_0: EnvHeapMutable4), (var_1: EnvHeapMutable8), (var_2: EnvHeapMutable3)): unit =
    let (var_3: int64) = var_0.mem_0
    let (var_4: bool) = (var_3 > 0L)
    if var_4 then
        let (var_5: int64) = method_12((var_0: EnvHeapMutable4))
        let (var_6: string) = var_0.mem_2
        let (var_7: Env5) = method_9((var_1: EnvHeapMutable8))
        let (var_8: Union6) = var_7.mem_0
        let (var_9: Union7) = var_7.mem_1
        method_13((var_0: EnvHeapMutable4), (var_8: Union6), (var_9: Union7))
    else
        ()
and method_15((var_0: EnvHeapMutable3)): bool =
    let (var_1: Union2) = var_0.mem_1
    match var_1 with
    | Union2Case0(var_2) ->
        let (var_3: Env5) = var_2.mem_0
        true
    | Union2Case1 ->
        false
and method_16((var_0: EnvHeapMutable4)): bool =
    let (var_1: Union2) = var_0.mem_1
    match var_1 with
    | Union2Case0(var_2) ->
        let (var_3: Env5) = var_2.mem_0
        true
    | Union2Case1 ->
        false
and method_17((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable3), (var_5: EnvHeapMutable4), (var_6: EnvHeapMutable8)): unit =
    let (var_7: int64) = 0L
    let (var_8: int64) = 0L
    let (var_9: EnvHeap11) = method_18((var_7: int64), (var_8: int64), (var_4: EnvHeapMutable3))
    let (var_10: int64) = 1L
    let (var_11: EnvHeap11) = method_19((var_7: int64), (var_10: int64), (var_5: EnvHeapMutable4))
    let (var_12: Union12) = method_20((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_9: EnvHeap11), (var_11: EnvHeap11), (var_4: EnvHeapMutable3))
    match var_12 with
    | Union12Case0(var_13) ->
        let (var_14: Env13) = var_13.mem_0
        let (var_15: int64) = var_14.mem_0
        let (var_16: int64) = var_14.mem_1
        let (var_17: int64) = var_14.mem_2
        let (var_18: int64) = var_14.mem_3
        let (var_19: int64) = 1L
        let (var_20: int64) = 0L
        let (var_21: EnvHeap11) = method_18((var_19: int64), (var_20: int64), (var_4: EnvHeapMutable3))
        let (var_22: int64) = 1L
        let (var_23: EnvHeap11) = method_19((var_19: int64), (var_22: int64), (var_5: EnvHeapMutable4))
        let (var_24: Union12) = method_24((var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_21: EnvHeap11), (var_23: EnvHeap11), (var_5: EnvHeapMutable4))
        match var_24 with
        | Union12Case0(var_25) ->
            let (var_26: Env13) = var_25.mem_0
            let (var_27: int64) = var_26.mem_0
            let (var_28: int64) = var_26.mem_1
            let (var_29: int64) = var_26.mem_2
            let (var_30: int64) = var_26.mem_3
            method_17((var_27: int64), (var_28: int64), (var_29: int64), (var_30: int64), (var_4: EnvHeapMutable3), (var_5: EnvHeapMutable4), (var_6: EnvHeapMutable8))
        | Union12Case1 ->
            ()
    | Union12Case1 ->
        ()
and method_28((var_0: EnvHeapMutable3)): unit =
    let (var_1: int64) = var_0.mem_3
    let (var_2: bool) = (var_1 > 0L)
    if var_2 then
        let (var_3: Union2) = var_0.mem_1
        match var_3 with
        | Union2Case0(var_4) ->
            let (var_5: Env5) = var_4.mem_0
            let (var_6: Union6) = var_5.mem_0
            let (var_7: Union7) = var_5.mem_1
            let (var_8: string) = var_0.mem_2
            let (var_9: string) = method_21((var_6: Union6), (var_7: Union7))
            ()
        | Union2Case1 ->
            ()
    else
        ()
and method_29((var_0: EnvHeapMutable4)): unit =
    let (var_1: int64) = var_0.mem_3
    let (var_2: bool) = (var_1 > 0L)
    if var_2 then
        let (var_3: Union2) = var_0.mem_1
        match var_3 with
        | Union2Case0(var_4) ->
            let (var_5: Env5) = var_4.mem_0
            let (var_6: Union6) = var_5.mem_0
            let (var_7: Union7) = var_5.mem_1
            let (var_8: string) = var_0.mem_2
            let (var_9: string) = method_21((var_6: Union6), (var_7: Union7))
            ()
        | Union2Case1 ->
            ()
    else
        ()
and method_30((var_0: EnvHeapMutable3), (var_1: EnvHeapMutable4)): unit =
    let (var_2: int64) = var_0.mem_3
    let (var_3: bool) = (var_2 > 0L)
    let (var_4: int64) = var_1.mem_3
    let (var_5: bool) = (var_4 > 0L)
    let (var_6: Union2) = method_31((var_3: bool), (var_0: EnvHeapMutable3))
    let (var_7: Union2) = method_32((var_5: bool), (var_1: EnvHeapMutable4), (var_6: Union2))
    match var_7 with
    | Union2Case0(var_8) ->
        let (var_9: Env5) = var_8.mem_0
        let (var_10: Union6) = var_9.mem_0
        let (var_11: Union7) = var_9.mem_1
        let (var_12: int64) = method_34((var_10: Union6), (var_11: Union7), (var_3: bool), (var_0: EnvHeapMutable3))
        let (var_13: int64) = method_35((var_10: Union6), (var_11: Union7), (var_5: bool), (var_1: EnvHeapMutable4), (var_12: int64))
        let (var_14: int64) = System.Int64.MaxValue
        let (var_15: int64) = method_36((var_3: bool), (var_0: EnvHeapMutable3), (var_14: int64))
        let (var_16: int64) = method_37((var_5: bool), (var_1: EnvHeapMutable4), (var_15: int64))
        let (var_17: int64) = method_38((var_16: int64), (var_3: bool), (var_0: EnvHeapMutable3))
        let (var_18: int64) = method_40((var_16: int64), (var_5: bool), (var_1: EnvHeapMutable4), (var_17: int64))
        let (var_19: int64) = (var_18 % var_13)
        let (var_20: bool) = (var_19 <> 0L)
        let (var_21: int64) = (var_18 / var_13)
        let (var_22: int64) = method_42((var_20: bool), (var_21: int64), (var_10: Union6), (var_11: Union7), (var_3: bool), (var_0: EnvHeapMutable3), (var_13: int64))
        let (var_23: int64) = method_44((var_20: bool), (var_21: int64), (var_10: Union6), (var_11: Union7), (var_5: bool), (var_1: EnvHeapMutable4), (var_22: int64))
        method_30((var_0: EnvHeapMutable3), (var_1: EnvHeapMutable4))
    | Union2Case1 ->
        ()
and method_46((var_0: int64), (var_1: EnvHeapMutable3)): unit =
    let (var_2: int64) = var_1.mem_0
    let (var_3: bool) = (var_0 < var_2)
    if var_3 then
        let (var_4: string) = var_1.mem_2
        let (var_5: int64) = (var_2 - var_0)
        ()
    else
        let (var_6: bool) = (var_0 > var_2)
        if var_6 then
            let (var_7: string) = var_1.mem_2
            let (var_8: int64) = (var_0 - var_2)
            ()
        else
            ()
and method_47((var_0: int64), (var_1: EnvHeapMutable4)): unit =
    let (var_2: int64) = var_1.mem_0
    let (var_3: bool) = (var_0 < var_2)
    if var_3 then
        let (var_4: string) = var_1.mem_2
        let (var_5: int64) = (var_2 - var_0)
        ()
    else
        let (var_6: bool) = (var_0 > var_2)
        if var_6 then
            let (var_7: string) = var_1.mem_2
            let (var_8: int64) = (var_0 - var_2)
            ()
        else
            ()
and method_49((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3)): unit =
    method_50((var_1: EnvHeapMutable4), (var_0: EnvHeapMutable8), (var_2: EnvHeapMutable3))
    method_52((var_2: EnvHeapMutable3), (var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4))
and method_54((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3)): unit =
    let (var_3: int64) = 2L
    let (var_4: int64) = var_1.mem_0
    let (var_5: bool) = (var_4 > 0L)
    let (var_7: bool) =
        if var_5 then
            method_16((var_1: EnvHeapMutable4))
        else
            false
    let (var_11: int64) =
        if var_7 then
            let (var_8: int64) = var_1.mem_3
            let (var_9: bool) = (0L > var_8)
            if var_9 then
                0L
            else
                var_8
        else
            0L
    let (var_12: int64) = var_2.mem_0
    let (var_13: bool) = (var_12 > 0L)
    let (var_15: bool) =
        if var_13 then
            method_15((var_2: EnvHeapMutable3))
        else
            false
    let (var_19: int64) =
        if var_15 then
            let (var_16: int64) = var_2.mem_3
            let (var_17: bool) = (var_11 > var_16)
            if var_17 then
                var_11
            else
                var_16
        else
            var_11
    let (var_20: int64) = var_1.mem_0
    let (var_21: bool) = (var_20 > 0L)
    let (var_23: bool) =
        if var_21 then
            method_16((var_1: EnvHeapMutable4))
        else
            false
    let (var_24: int64) =
        if var_23 then
            1L
        else
            0L
    let (var_25: int64) = var_2.mem_0
    let (var_26: bool) = (var_25 > 0L)
    let (var_28: bool) =
        if var_26 then
            method_15((var_2: EnvHeapMutable3))
        else
            false
    let (var_30: int64) =
        if var_28 then
            (var_24 + 1L)
        else
            var_24
    let (var_31: int64) = 0L
    method_55((var_19: int64), (var_3: int64), (var_30: int64), (var_31: int64), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3), (var_0: EnvHeapMutable8))
and method_56((var_0: EnvHeapMutable8), (var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3)): unit =
    method_29((var_1: EnvHeapMutable4))
    method_28((var_2: EnvHeapMutable3))
    let (var_3: int64) = var_1.mem_0
    let (var_4: int64) = var_1.mem_3
    let (var_5: int64) = (var_3 + var_4)
    let (var_6: int64) = var_2.mem_0
    let (var_7: int64) = var_2.mem_3
    let (var_8: int64) = (var_6 + var_7)
    method_57((var_1: EnvHeapMutable4), (var_2: EnvHeapMutable3))
    method_47((var_5: int64), (var_1: EnvHeapMutable4))
    method_46((var_8: int64), (var_2: EnvHeapMutable3))
and method_8((var_0: EnvHeapMutable3)): int64 =
    let (var_1: int64) = var_0.mem_0
    let (var_2: int64) = var_0.mem_3
    let (var_3: int64) = (1L - var_2)
    let (var_4: bool) = (var_1 > var_3)
    let (var_5: int64) =
        if var_4 then
            var_3
        else
            var_1
    let (var_6: int64) = (var_1 - var_5)
    var_0.mem_0 <- var_6
    let (var_7: int64) = (var_2 + var_5)
    var_0.mem_3 <- var_7
    var_7
and method_9((var_0: EnvHeapMutable8)): Env5 =
    let (var_1: int64) = var_0.mem_1
    let (var_2: int64) = (var_1 - 1L)
    var_0.mem_1 <- var_2
    let (var_3: (Env5 [])) = var_0.mem_0
    var_3.[int32 var_2]
and method_10((var_0: EnvHeapMutable3), (var_1: Union6), (var_2: Union7)): unit =
    let (var_3: Union2) = (Union2Case0(Tuple10((Env5(var_1, var_2)))))
    var_0.mem_1 <- var_3
and method_12((var_0: EnvHeapMutable4)): int64 =
    let (var_1: int64) = var_0.mem_0
    let (var_2: int64) = var_0.mem_3
    let (var_3: int64) = (2L - var_2)
    let (var_4: bool) = (var_1 > var_3)
    let (var_5: int64) =
        if var_4 then
            var_3
        else
            var_1
    let (var_6: int64) = (var_1 - var_5)
    var_0.mem_0 <- var_6
    let (var_7: int64) = (var_2 + var_5)
    var_0.mem_3 <- var_7
    var_7
and method_13((var_0: EnvHeapMutable4), (var_1: Union6), (var_2: Union7)): unit =
    let (var_3: Union2) = (Union2Case0(Tuple10((Env5(var_1, var_2)))))
    var_0.mem_1 <- var_3
and method_18((var_0: int64), (var_1: int64), (var_2: EnvHeapMutable3)): EnvHeap11 =
    let (var_3: bool) = (var_1 <> var_0)
    if var_3 then
        let (var_4: int64) = var_2.mem_0
        let (var_5: int64) = var_2.mem_3
        let (var_6: Union2) = Union2Case1
        ({mem_0 = (var_4: int64); mem_1 = (var_6: Union2); mem_2 = (var_5: int64)} : EnvHeap11)
    else
        let (var_8: int64) = var_2.mem_0
        let (var_9: int64) = var_2.mem_3
        let (var_10: Union2) = var_2.mem_1
        ({mem_0 = (var_8: int64); mem_1 = (var_10: Union2); mem_2 = (var_9: int64)} : EnvHeap11)
and method_19((var_0: int64), (var_1: int64), (var_2: EnvHeapMutable4)): EnvHeap11 =
    let (var_3: bool) = (var_1 <> var_0)
    if var_3 then
        let (var_4: int64) = var_2.mem_0
        let (var_5: int64) = var_2.mem_3
        let (var_6: Union2) = Union2Case1
        ({mem_0 = (var_4: int64); mem_1 = (var_6: Union2); mem_2 = (var_5: int64)} : EnvHeap11)
    else
        let (var_8: int64) = var_2.mem_0
        let (var_9: int64) = var_2.mem_3
        let (var_10: Union2) = var_2.mem_1
        ({mem_0 = (var_8: int64); mem_1 = (var_10: Union2); mem_2 = (var_9: int64)} : EnvHeap11)
and method_20((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeap11), (var_5: EnvHeap11), (var_6: EnvHeapMutable3)): Union12 =
    let (var_7: bool) = (var_3 < var_2)
    if var_7 then
        let (var_8: int64) = var_6.mem_0
        let (var_9: bool) = (var_8 > 0L)
        let (var_11: bool) =
            if var_9 then
                method_15((var_6: EnvHeapMutable3))
            else
                false
        if var_11 then
            let (var_12: int64) = var_4.mem_2
            let (var_13: bool) = (0L > var_12)
            let (var_14: int64) =
                if var_13 then
                    0L
                else
                    var_12
            let (var_15: int64) = var_5.mem_2
            let (var_16: bool) = (var_14 > var_15)
            let (var_17: int64) =
                if var_16 then
                    var_14
                else
                    var_15
            let (var_18: Union2) = var_4.mem_1
            let (var_24: string) =
                match var_18 with
                | Union2Case0(var_19) ->
                    let (var_20: Env5) = var_19.mem_0
                    let (var_21: Union6) = var_20.mem_0
                    let (var_22: Union7) = var_20.mem_1
                    method_21((var_21: Union6), (var_22: Union7))
                | Union2Case1 ->
                    "None"
            let (var_25: int64) = var_4.mem_0
            let (var_26: Union2) = var_5.mem_1
            let (var_32: string) =
                match var_26 with
                | Union2Case0(var_27) ->
                    let (var_28: Env5) = var_27.mem_0
                    let (var_29: Union6) = var_28.mem_0
                    let (var_30: Union7) = var_28.mem_1
                    method_21((var_29: Union6), (var_30: Union7))
                | Union2Case1 ->
                    "None"
            let (var_33: int64) = var_5.mem_0
            let (var_38: bool) =
                match var_18 with
                | Union2Case0(var_34) ->
                    let (var_35: Env5) = var_34.mem_0
                    let (var_36: Union6) = var_35.mem_0
                    let (var_37: Union7) = var_35.mem_1
                    true
                | Union2Case1 ->
                    false
            let (var_46: EnvHeap11) =
                if var_38 then
                    var_4
                else
                    let (var_43: bool) =
                        match var_26 with
                        | Union2Case0(var_39) ->
                            let (var_40: Env5) = var_39.mem_0
                            let (var_41: Union6) = var_40.mem_0
                            let (var_42: Union7) = var_40.mem_1
                            true
                        | Union2Case1 ->
                            false
                    if var_43 then
                        var_5
                    else
                        (failwith "Key cannot be found.")
            let (var_47: Union2) = var_46.mem_1
            match var_47 with
            | Union2Case0(var_48) ->
                let (var_49: Env5) = var_48.mem_0
                let (var_50: Union6) = var_49.mem_0
                let (var_51: Union7) = var_49.mem_1
                match var_50 with
                | Union6Case0 ->
                    let (var_52: int64) = (var_0 + var_1)
                    let (var_53: int64) = method_22((var_6: EnvHeapMutable3), (var_52: int64))
                    let (var_54: int64) = (var_53 - var_0)
                    let (var_55: int64) = var_6.mem_0
                    let (var_56: bool) = (var_55 = 0L)
                    if var_56 then
                        let (var_57: string) = var_6.mem_2
                        let (var_58: int64) = (var_2 - 1L)
                        let (var_59: bool) = (var_53 < var_52)
                        if var_59 then
                            (Union12Case0(Tuple14((Env13(var_53, var_54, var_58, var_3)))))
                        else
                            let (var_60: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_53, var_54, var_58, var_60)))))
                    else
                        let (var_62: string) = var_6.mem_2
                        let (var_63: bool) = (var_53 < var_52)
                        if var_63 then
                            (Union12Case0(Tuple14((Env13(var_53, var_54, var_2, var_3)))))
                        else
                            let (var_64: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_53, var_54, var_2, var_64)))))
                | Union6Case1 ->
                    let (var_67: int64) = var_46.mem_2
                    let (var_68: bool) = (var_67 >= var_17)
                    let (var_71: bool) =
                        if var_68 then
                            true
                        else
                            let (var_69: int64) = var_46.mem_0
                            (var_69 = 0L)
                    if var_71 then
                        let (var_72: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_73: int64) = var_6.mem_0
                        let (var_74: bool) = (var_73 = 0L)
                        if var_74 then
                            let (var_75: string) = var_6.mem_2
                            let (var_76: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_76, var_3)))))
                        else
                            let (var_77: string) = var_6.mem_2
                            let (var_78: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_78)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_80: string) = var_6.mem_2
                        let (var_81: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_81, var_3)))))
                | Union6Case2 ->
                    let (var_83: int64) = var_46.mem_2
                    let (var_84: bool) = (var_83 >= var_17)
                    let (var_87: bool) =
                        if var_84 then
                            true
                        else
                            let (var_85: int64) = var_46.mem_0
                            (var_85 = 0L)
                    if var_87 then
                        let (var_88: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_89: int64) = var_6.mem_0
                        let (var_90: bool) = (var_89 = 0L)
                        if var_90 then
                            let (var_91: string) = var_6.mem_2
                            let (var_92: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_92, var_3)))))
                        else
                            let (var_93: string) = var_6.mem_2
                            let (var_94: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_94)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_96: string) = var_6.mem_2
                        let (var_97: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_97, var_3)))))
                | Union6Case3 ->
                    let (var_99: int64) = var_46.mem_2
                    let (var_100: bool) = (var_99 >= var_17)
                    let (var_103: bool) =
                        if var_100 then
                            true
                        else
                            let (var_101: int64) = var_46.mem_0
                            (var_101 = 0L)
                    if var_103 then
                        let (var_104: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_105: int64) = var_6.mem_0
                        let (var_106: bool) = (var_105 = 0L)
                        if var_106 then
                            let (var_107: string) = var_6.mem_2
                            let (var_108: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_108, var_3)))))
                        else
                            let (var_109: string) = var_6.mem_2
                            let (var_110: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_110)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_112: string) = var_6.mem_2
                        let (var_113: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_113, var_3)))))
                | Union6Case4 ->
                    let (var_115: int64) = (var_0 + var_1)
                    let (var_116: int64) = method_22((var_6: EnvHeapMutable3), (var_115: int64))
                    let (var_117: int64) = (var_116 - var_0)
                    let (var_118: int64) = var_6.mem_0
                    let (var_119: bool) = (var_118 = 0L)
                    if var_119 then
                        let (var_120: string) = var_6.mem_2
                        let (var_121: int64) = (var_2 - 1L)
                        let (var_122: bool) = (var_116 < var_115)
                        if var_122 then
                            (Union12Case0(Tuple14((Env13(var_116, var_117, var_121, var_3)))))
                        else
                            let (var_123: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_116, var_117, var_121, var_123)))))
                    else
                        let (var_125: string) = var_6.mem_2
                        let (var_126: bool) = (var_116 < var_115)
                        if var_126 then
                            (Union12Case0(Tuple14((Env13(var_116, var_117, var_2, var_3)))))
                        else
                            let (var_127: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_116, var_117, var_2, var_127)))))
                | Union6Case5 ->
                    let (var_130: int64) = (var_0 + var_1)
                    let (var_131: int64) = method_22((var_6: EnvHeapMutable3), (var_130: int64))
                    let (var_132: int64) = (var_131 - var_0)
                    let (var_133: int64) = var_6.mem_0
                    let (var_134: bool) = (var_133 = 0L)
                    if var_134 then
                        let (var_135: string) = var_6.mem_2
                        let (var_136: int64) = (var_2 - 1L)
                        let (var_137: bool) = (var_131 < var_130)
                        if var_137 then
                            (Union12Case0(Tuple14((Env13(var_131, var_132, var_136, var_3)))))
                        else
                            let (var_138: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_131, var_132, var_136, var_138)))))
                    else
                        let (var_140: string) = var_6.mem_2
                        let (var_141: bool) = (var_131 < var_130)
                        if var_141 then
                            (Union12Case0(Tuple14((Env13(var_131, var_132, var_2, var_3)))))
                        else
                            let (var_142: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_131, var_132, var_2, var_142)))))
                | Union6Case6 ->
                    let (var_145: int64) = var_46.mem_2
                    let (var_146: bool) = (var_145 >= var_17)
                    let (var_149: bool) =
                        if var_146 then
                            true
                        else
                            let (var_147: int64) = var_46.mem_0
                            (var_147 = 0L)
                    if var_149 then
                        let (var_150: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_151: int64) = var_6.mem_0
                        let (var_152: bool) = (var_151 = 0L)
                        if var_152 then
                            let (var_153: string) = var_6.mem_2
                            let (var_154: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_154, var_3)))))
                        else
                            let (var_155: string) = var_6.mem_2
                            let (var_156: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_156)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_158: string) = var_6.mem_2
                        let (var_159: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_159, var_3)))))
                | Union6Case7 ->
                    let (var_161: int64) = (var_0 + var_1)
                    let (var_162: int64) = method_22((var_6: EnvHeapMutable3), (var_161: int64))
                    let (var_163: int64) = (var_162 - var_0)
                    let (var_164: int64) = var_6.mem_0
                    let (var_165: bool) = (var_164 = 0L)
                    if var_165 then
                        let (var_166: string) = var_6.mem_2
                        let (var_167: int64) = (var_2 - 1L)
                        let (var_168: bool) = (var_162 < var_161)
                        if var_168 then
                            (Union12Case0(Tuple14((Env13(var_162, var_163, var_167, var_3)))))
                        else
                            let (var_169: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_162, var_163, var_167, var_169)))))
                    else
                        let (var_171: string) = var_6.mem_2
                        let (var_172: bool) = (var_162 < var_161)
                        if var_172 then
                            (Union12Case0(Tuple14((Env13(var_162, var_163, var_2, var_3)))))
                        else
                            let (var_173: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_162, var_163, var_2, var_173)))))
                | Union6Case8 ->
                    let (var_176: int64) = var_46.mem_2
                    let (var_177: bool) = (var_176 >= var_17)
                    let (var_180: bool) =
                        if var_177 then
                            true
                        else
                            let (var_178: int64) = var_46.mem_0
                            (var_178 = 0L)
                    if var_180 then
                        let (var_181: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_182: int64) = var_6.mem_0
                        let (var_183: bool) = (var_182 = 0L)
                        if var_183 then
                            let (var_184: string) = var_6.mem_2
                            let (var_185: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_185, var_3)))))
                        else
                            let (var_186: string) = var_6.mem_2
                            let (var_187: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_187)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_189: string) = var_6.mem_2
                        let (var_190: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_190, var_3)))))
                | Union6Case9 ->
                    let (var_192: int64) = var_46.mem_2
                    let (var_193: bool) = (var_192 >= var_17)
                    let (var_196: bool) =
                        if var_193 then
                            true
                        else
                            let (var_194: int64) = var_46.mem_0
                            (var_194 = 0L)
                    if var_196 then
                        let (var_197: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_198: int64) = var_6.mem_0
                        let (var_199: bool) = (var_198 = 0L)
                        if var_199 then
                            let (var_200: string) = var_6.mem_2
                            let (var_201: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_201, var_3)))))
                        else
                            let (var_202: string) = var_6.mem_2
                            let (var_203: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_203)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_205: string) = var_6.mem_2
                        let (var_206: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_206, var_3)))))
                | Union6Case10 ->
                    let (var_208: int64) = (var_0 + var_1)
                    let (var_209: int64) = method_22((var_6: EnvHeapMutable3), (var_208: int64))
                    let (var_210: int64) = (var_209 - var_0)
                    let (var_211: int64) = var_6.mem_0
                    let (var_212: bool) = (var_211 = 0L)
                    if var_212 then
                        let (var_213: string) = var_6.mem_2
                        let (var_214: int64) = (var_2 - 1L)
                        let (var_215: bool) = (var_209 < var_208)
                        if var_215 then
                            (Union12Case0(Tuple14((Env13(var_209, var_210, var_214, var_3)))))
                        else
                            let (var_216: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_209, var_210, var_214, var_216)))))
                    else
                        let (var_218: string) = var_6.mem_2
                        let (var_219: bool) = (var_209 < var_208)
                        if var_219 then
                            (Union12Case0(Tuple14((Env13(var_209, var_210, var_2, var_3)))))
                        else
                            let (var_220: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_209, var_210, var_2, var_220)))))
                | Union6Case11 ->
                    let (var_223: int64) = var_46.mem_2
                    let (var_224: bool) = (var_223 >= var_17)
                    let (var_227: bool) =
                        if var_224 then
                            true
                        else
                            let (var_225: int64) = var_46.mem_0
                            (var_225 = 0L)
                    if var_227 then
                        let (var_228: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_229: int64) = var_6.mem_0
                        let (var_230: bool) = (var_229 = 0L)
                        if var_230 then
                            let (var_231: string) = var_6.mem_2
                            let (var_232: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_232, var_3)))))
                        else
                            let (var_233: string) = var_6.mem_2
                            let (var_234: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_234)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_236: string) = var_6.mem_2
                        let (var_237: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_237, var_3)))))
                | Union6Case12 ->
                    let (var_239: int64) = var_46.mem_2
                    let (var_240: bool) = (var_239 >= var_17)
                    let (var_243: bool) =
                        if var_240 then
                            true
                        else
                            let (var_241: int64) = var_46.mem_0
                            (var_241 = 0L)
                    if var_243 then
                        let (var_244: int64) = method_22((var_6: EnvHeapMutable3), (var_0: int64))
                        let (var_245: int64) = var_6.mem_0
                        let (var_246: bool) = (var_245 = 0L)
                        if var_246 then
                            let (var_247: string) = var_6.mem_2
                            let (var_248: int64) = (var_2 - 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_248, var_3)))))
                        else
                            let (var_249: string) = var_6.mem_2
                            let (var_250: int64) = (var_3 + 1L)
                            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_250)))))
                    else
                        method_23((var_6: EnvHeapMutable3))
                        let (var_252: string) = var_6.mem_2
                        let (var_253: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_253, var_3)))))
            | Union2Case1 ->
                (failwith "No self in the internal representation.")
        else
            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_3)))))
    else
        Union12Case1
and method_24((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeap11), (var_5: EnvHeap11), (var_6: EnvHeapMutable4)): Union12 =
    let (var_7: bool) = (var_3 < var_2)
    if var_7 then
        let (var_8: int64) = var_6.mem_0
        let (var_9: bool) = (var_8 > 0L)
        let (var_11: bool) =
            if var_9 then
                method_16((var_6: EnvHeapMutable4))
            else
                false
        if var_11 then
            let (var_12: EnvStack0) = var_6.mem_4
            let (var_13: System.Random) = var_12.mem_0
            let (var_14: int32) = var_13.Next(0, 5)
            let (var_15: bool) = (var_14 = 0)
            if var_15 then
                method_25((var_6: EnvHeapMutable4))
                let (var_16: string) = var_6.mem_2
                let (var_17: int64) = (var_2 - 1L)
                (Union12Case0(Tuple14((Env13(var_0, var_1, var_17, var_3)))))
            else
                let (var_18: bool) = (var_14 = 1)
                if var_18 then
                    let (var_19: int64) = method_26((var_6: EnvHeapMutable4), (var_0: int64))
                    let (var_20: int64) = var_6.mem_0
                    let (var_21: bool) = (var_20 = 0L)
                    if var_21 then
                        let (var_22: string) = var_6.mem_2
                        let (var_23: int64) = (var_2 - 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_23, var_3)))))
                    else
                        let (var_24: string) = var_6.mem_2
                        let (var_25: int64) = (var_3 + 1L)
                        (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_25)))))
                else
                    let (var_27: int64) = (var_0 + var_1)
                    let (var_28: int64) = method_26((var_6: EnvHeapMutable4), (var_27: int64))
                    let (var_29: int64) = (var_28 - var_0)
                    let (var_30: int64) = var_6.mem_0
                    let (var_31: bool) = (var_30 = 0L)
                    if var_31 then
                        let (var_32: string) = var_6.mem_2
                        let (var_33: int64) = (var_2 - 1L)
                        let (var_34: bool) = (var_28 < var_27)
                        if var_34 then
                            (Union12Case0(Tuple14((Env13(var_28, var_29, var_33, var_3)))))
                        else
                            let (var_35: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_28, var_29, var_33, var_35)))))
                    else
                        let (var_37: string) = var_6.mem_2
                        let (var_38: bool) = (var_28 < var_27)
                        if var_38 then
                            (Union12Case0(Tuple14((Env13(var_28, var_29, var_2, var_3)))))
                        else
                            let (var_39: int64) = 1L
                            (Union12Case0(Tuple14((Env13(var_28, var_29, var_2, var_39)))))
        else
            (Union12Case0(Tuple14((Env13(var_0, var_1, var_2, var_3)))))
    else
        Union12Case1
and method_21((var_0: Union6), (var_1: Union7)): string =
    match var_0 with
    | Union6Case0 ->
        match var_1 with
        | Union7Case0 ->
            "Ace-Clubs"
        | Union7Case1 ->
            "Ace-Diamonds"
        | Union7Case2 ->
            "Ace-Hearts"
        | Union7Case3 ->
            "Ace-Spades"
    | Union6Case1 ->
        match var_1 with
        | Union7Case0 ->
            "Eight-Clubs"
        | Union7Case1 ->
            "Eight-Diamonds"
        | Union7Case2 ->
            "Eight-Hearts"
        | Union7Case3 ->
            "Eight-Spades"
    | Union6Case2 ->
        match var_1 with
        | Union7Case0 ->
            "Five-Clubs"
        | Union7Case1 ->
            "Five-Diamonds"
        | Union7Case2 ->
            "Five-Hearts"
        | Union7Case3 ->
            "Five-Spades"
    | Union6Case3 ->
        match var_1 with
        | Union7Case0 ->
            "Four-Clubs"
        | Union7Case1 ->
            "Four-Diamonds"
        | Union7Case2 ->
            "Four-Hearts"
        | Union7Case3 ->
            "Four-Spades"
    | Union6Case4 ->
        match var_1 with
        | Union7Case0 ->
            "Jack-Clubs"
        | Union7Case1 ->
            "Jack-Diamonds"
        | Union7Case2 ->
            "Jack-Hearts"
        | Union7Case3 ->
            "Jack-Spades"
    | Union6Case5 ->
        match var_1 with
        | Union7Case0 ->
            "King-Clubs"
        | Union7Case1 ->
            "King-Diamonds"
        | Union7Case2 ->
            "King-Hearts"
        | Union7Case3 ->
            "King-Spades"
    | Union6Case6 ->
        match var_1 with
        | Union7Case0 ->
            "Nine-Clubs"
        | Union7Case1 ->
            "Nine-Diamonds"
        | Union7Case2 ->
            "Nine-Hearts"
        | Union7Case3 ->
            "Nine-Spades"
    | Union6Case7 ->
        match var_1 with
        | Union7Case0 ->
            "Queen-Clubs"
        | Union7Case1 ->
            "Queen-Diamonds"
        | Union7Case2 ->
            "Queen-Hearts"
        | Union7Case3 ->
            "Queen-Spades"
    | Union6Case8 ->
        match var_1 with
        | Union7Case0 ->
            "Seven-Clubs"
        | Union7Case1 ->
            "Seven-Diamonds"
        | Union7Case2 ->
            "Seven-Hearts"
        | Union7Case3 ->
            "Seven-Spades"
    | Union6Case9 ->
        match var_1 with
        | Union7Case0 ->
            "Six-Clubs"
        | Union7Case1 ->
            "Six-Diamonds"
        | Union7Case2 ->
            "Six-Hearts"
        | Union7Case3 ->
            "Six-Spades"
    | Union6Case10 ->
        match var_1 with
        | Union7Case0 ->
            "Ten-Clubs"
        | Union7Case1 ->
            "Ten-Diamonds"
        | Union7Case2 ->
            "Ten-Hearts"
        | Union7Case3 ->
            "Ten-Spades"
    | Union6Case11 ->
        match var_1 with
        | Union7Case0 ->
            "Three-Clubs"
        | Union7Case1 ->
            "Three-Diamonds"
        | Union7Case2 ->
            "Three-Hearts"
        | Union7Case3 ->
            "Three-Spades"
    | Union6Case12 ->
        match var_1 with
        | Union7Case0 ->
            "Two-Clubs"
        | Union7Case1 ->
            "Two-Diamonds"
        | Union7Case2 ->
            "Two-Hearts"
        | Union7Case3 ->
            "Two-Spades"
and method_31((var_0: bool), (var_1: EnvHeapMutable3)): Union2 =
    if var_0 then
        var_1.mem_1
    else
        Union2Case1
and method_32((var_0: bool), (var_1: EnvHeapMutable4), (var_2: Union2)): Union2 =
    if var_0 then
        match var_2 with
        | Union2Case0(var_3) ->
            let (var_4: Env5) = var_3.mem_0
            let (var_5: Union6) = var_4.mem_0
            let (var_6: Union7) = var_4.mem_1
            let (var_7: Union2) = var_1.mem_1
            match var_7 with
            | Union2Case0(var_8) ->
                let (var_9: Env5) = var_8.mem_0
                let (var_10: Union6) = var_9.mem_0
                let (var_11: Union7) = var_9.mem_1
                let (var_12: int32) = method_33((var_5: Union6), (var_6: Union7), (var_10: Union6), (var_11: Union7))
                let (var_13: bool) = (var_12 = 1)
                if var_13 then
                    (Union2Case0(Tuple10((Env5(var_5, var_6)))))
                else
                    (Union2Case0(Tuple10((Env5(var_10, var_11)))))
            | Union2Case1 ->
                (Union2Case0(Tuple10((Env5(var_5, var_6)))))
        | Union2Case1 ->
            var_1.mem_1
    else
        var_2
and method_34((var_0: Union6), (var_1: Union7), (var_2: bool), (var_3: EnvHeapMutable3)): int64 =
    if var_2 then
        let (var_4: Union2) = var_3.mem_1
        match var_4 with
        | Union2Case0(var_5) ->
            let (var_6: Env5) = var_5.mem_0
            let (var_7: Union6) = var_6.mem_0
            let (var_8: Union7) = var_6.mem_1
            let (var_9: int32) = method_33((var_0: Union6), (var_1: Union7), (var_7: Union6), (var_8: Union7))
            let (var_10: bool) = (var_9 = 0)
            if var_10 then
                1L
            else
                0L
        | Union2Case1 ->
            0L
    else
        0L
and method_35((var_0: Union6), (var_1: Union7), (var_2: bool), (var_3: EnvHeapMutable4), (var_4: int64)): int64 =
    if var_2 then
        let (var_5: Union2) = var_3.mem_1
        match var_5 with
        | Union2Case0(var_6) ->
            let (var_7: Env5) = var_6.mem_0
            let (var_8: Union6) = var_7.mem_0
            let (var_9: Union7) = var_7.mem_1
            let (var_10: int32) = method_33((var_0: Union6), (var_1: Union7), (var_8: Union6), (var_9: Union7))
            let (var_11: bool) = (var_10 = 0)
            if var_11 then
                (var_4 + 1L)
            else
                var_4
        | Union2Case1 ->
            var_4
    else
        var_4
and method_36((var_0: bool), (var_1: EnvHeapMutable3), (var_2: int64)): int64 =
    if var_0 then
        let (var_3: int64) = var_1.mem_3
        let (var_4: bool) = (var_2 > var_3)
        if var_4 then
            var_3
        else
            var_2
    else
        var_2
and method_37((var_0: bool), (var_1: EnvHeapMutable4), (var_2: int64)): int64 =
    if var_0 then
        let (var_3: int64) = var_1.mem_3
        let (var_4: bool) = (var_2 > var_3)
        if var_4 then
            var_3
        else
            var_2
    else
        var_2
and method_38((var_0: int64), (var_1: bool), (var_2: EnvHeapMutable3)): int64 =
    if var_1 then
        method_39((var_2: EnvHeapMutable3), (var_0: int64))
    else
        0L
and method_40((var_0: int64), (var_1: bool), (var_2: EnvHeapMutable4), (var_3: int64)): int64 =
    if var_1 then
        let (var_4: int64) = method_41((var_2: EnvHeapMutable4), (var_0: int64))
        (var_3 + var_4)
    else
        var_3
and method_42((var_0: bool), (var_1: int64), (var_2: Union6), (var_3: Union7), (var_4: bool), (var_5: EnvHeapMutable3), (var_6: int64)): int64 =
    if var_4 then
        let (var_7: Union2) = var_5.mem_1
        match var_7 with
        | Union2Case0(var_8) ->
            let (var_9: Env5) = var_8.mem_0
            let (var_10: Union6) = var_9.mem_0
            let (var_11: Union7) = var_9.mem_1
            let (var_12: int32) = method_33((var_2: Union6), (var_3: Union7), (var_10: Union6), (var_11: Union7))
            let (var_13: bool) = (var_12 = 0)
            if var_13 then
                let (var_14: int64) = (var_6 - 1L)
                let (var_16: bool) =
                    if var_0 then
                        (var_14 = 0L)
                    else
                        false
                let (var_17: int64) =
                    if var_16 then
                        1L
                    else
                        0L
                let (var_18: int64) = (var_1 + var_17)
                method_43((var_5: EnvHeapMutable3), (var_18: int64))
                var_14
            else
                var_6
        | Union2Case1 ->
            var_6
    else
        var_6
and method_44((var_0: bool), (var_1: int64), (var_2: Union6), (var_3: Union7), (var_4: bool), (var_5: EnvHeapMutable4), (var_6: int64)): int64 =
    if var_4 then
        let (var_7: Union2) = var_5.mem_1
        match var_7 with
        | Union2Case0(var_8) ->
            let (var_9: Env5) = var_8.mem_0
            let (var_10: Union6) = var_9.mem_0
            let (var_11: Union7) = var_9.mem_1
            let (var_12: int32) = method_33((var_2: Union6), (var_3: Union7), (var_10: Union6), (var_11: Union7))
            let (var_13: bool) = (var_12 = 0)
            if var_13 then
                let (var_14: int64) = (var_6 - 1L)
                let (var_16: bool) =
                    if var_0 then
                        (var_14 = 0L)
                    else
                        false
                let (var_17: int64) =
                    if var_16 then
                        1L
                    else
                        0L
                let (var_18: int64) = (var_1 + var_17)
                method_45((var_5: EnvHeapMutable4), (var_18: int64))
                var_14
            else
                var_6
        | Union2Case1 ->
            var_6
    else
        var_6
and method_50((var_0: EnvHeapMutable4), (var_1: EnvHeapMutable8), (var_2: EnvHeapMutable3)): unit =
    let (var_3: int64) = var_0.mem_0
    let (var_4: bool) = (var_3 > 0L)
    if var_4 then
        let (var_5: int64) = method_51((var_0: EnvHeapMutable4))
        let (var_6: string) = var_0.mem_2
        let (var_7: Env5) = method_9((var_1: EnvHeapMutable8))
        let (var_8: Union6) = var_7.mem_0
        let (var_9: Union7) = var_7.mem_1
        method_13((var_0: EnvHeapMutable4), (var_8: Union6), (var_9: Union7))
    else
        ()
and method_52((var_0: EnvHeapMutable3), (var_1: EnvHeapMutable8), (var_2: EnvHeapMutable4)): unit =
    let (var_3: int64) = var_0.mem_0
    let (var_4: bool) = (var_3 > 0L)
    if var_4 then
        let (var_5: int64) = method_53((var_0: EnvHeapMutable3))
        let (var_6: string) = var_0.mem_2
        let (var_7: Env5) = method_9((var_1: EnvHeapMutable8))
        let (var_8: Union6) = var_7.mem_0
        let (var_9: Union7) = var_7.mem_1
        method_10((var_0: EnvHeapMutable3), (var_8: Union6), (var_9: Union7))
    else
        ()
and method_55((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable4), (var_5: EnvHeapMutable3), (var_6: EnvHeapMutable8)): unit =
    let (var_7: int64) = 0L
    let (var_8: int64) = 0L
    let (var_9: EnvHeap11) = method_19((var_7: int64), (var_8: int64), (var_4: EnvHeapMutable4))
    let (var_10: int64) = 1L
    let (var_11: EnvHeap11) = method_18((var_7: int64), (var_10: int64), (var_5: EnvHeapMutable3))
    let (var_12: Union12) = method_24((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_9: EnvHeap11), (var_11: EnvHeap11), (var_4: EnvHeapMutable4))
    match var_12 with
    | Union12Case0(var_13) ->
        let (var_14: Env13) = var_13.mem_0
        let (var_15: int64) = var_14.mem_0
        let (var_16: int64) = var_14.mem_1
        let (var_17: int64) = var_14.mem_2
        let (var_18: int64) = var_14.mem_3
        let (var_19: int64) = 1L
        let (var_20: int64) = 0L
        let (var_21: EnvHeap11) = method_19((var_19: int64), (var_20: int64), (var_4: EnvHeapMutable4))
        let (var_22: int64) = 1L
        let (var_23: EnvHeap11) = method_18((var_19: int64), (var_22: int64), (var_5: EnvHeapMutable3))
        let (var_24: Union12) = method_20((var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_21: EnvHeap11), (var_23: EnvHeap11), (var_5: EnvHeapMutable3))
        match var_24 with
        | Union12Case0(var_25) ->
            let (var_26: Env13) = var_25.mem_0
            let (var_27: int64) = var_26.mem_0
            let (var_28: int64) = var_26.mem_1
            let (var_29: int64) = var_26.mem_2
            let (var_30: int64) = var_26.mem_3
            method_55((var_27: int64), (var_28: int64), (var_29: int64), (var_30: int64), (var_4: EnvHeapMutable4), (var_5: EnvHeapMutable3), (var_6: EnvHeapMutable8))
        | Union12Case1 ->
            ()
    | Union12Case1 ->
        ()
and method_57((var_0: EnvHeapMutable4), (var_1: EnvHeapMutable3)): unit =
    let (var_2: int64) = var_0.mem_3
    let (var_3: bool) = (var_2 > 0L)
    let (var_4: int64) = var_1.mem_3
    let (var_5: bool) = (var_4 > 0L)
    let (var_6: Union2) = method_58((var_3: bool), (var_0: EnvHeapMutable4))
    let (var_7: Union2) = method_59((var_5: bool), (var_1: EnvHeapMutable3), (var_6: Union2))
    match var_7 with
    | Union2Case0(var_8) ->
        let (var_9: Env5) = var_8.mem_0
        let (var_10: Union6) = var_9.mem_0
        let (var_11: Union7) = var_9.mem_1
        let (var_12: int64) = method_60((var_10: Union6), (var_11: Union7), (var_3: bool), (var_0: EnvHeapMutable4))
        let (var_13: int64) = method_61((var_10: Union6), (var_11: Union7), (var_5: bool), (var_1: EnvHeapMutable3), (var_12: int64))
        let (var_14: int64) = System.Int64.MaxValue
        let (var_15: int64) = method_37((var_3: bool), (var_0: EnvHeapMutable4), (var_14: int64))
        let (var_16: int64) = method_36((var_5: bool), (var_1: EnvHeapMutable3), (var_15: int64))
        let (var_17: int64) = method_62((var_16: int64), (var_3: bool), (var_0: EnvHeapMutable4))
        let (var_18: int64) = method_63((var_16: int64), (var_5: bool), (var_1: EnvHeapMutable3), (var_17: int64))
        let (var_19: int64) = (var_18 % var_13)
        let (var_20: bool) = (var_19 <> 0L)
        let (var_21: int64) = (var_18 / var_13)
        let (var_22: int64) = method_44((var_20: bool), (var_21: int64), (var_10: Union6), (var_11: Union7), (var_3: bool), (var_0: EnvHeapMutable4), (var_13: int64))
        let (var_23: int64) = method_42((var_20: bool), (var_21: int64), (var_10: Union6), (var_11: Union7), (var_5: bool), (var_1: EnvHeapMutable3), (var_22: int64))
        method_57((var_0: EnvHeapMutable4), (var_1: EnvHeapMutable3))
    | Union2Case1 ->
        ()
and method_22((var_0: EnvHeapMutable3), (var_1: int64)): int64 =
    let (var_2: int64) = var_0.mem_0
    let (var_3: int64) = var_0.mem_3
    let (var_4: int64) = (var_1 - var_3)
    let (var_5: bool) = (var_2 > var_4)
    let (var_6: int64) =
        if var_5 then
            var_4
        else
            var_2
    let (var_7: int64) = (var_2 - var_6)
    var_0.mem_0 <- var_7
    let (var_8: int64) = (var_3 + var_6)
    var_0.mem_3 <- var_8
    var_8
and method_23((var_0: EnvHeapMutable3)): unit =
    let (var_1: Union2) = Union2Case1
    var_0.mem_1 <- var_1
and method_25((var_0: EnvHeapMutable4)): unit =
    let (var_1: Union2) = Union2Case1
    var_0.mem_1 <- var_1
and method_26((var_0: EnvHeapMutable4), (var_1: int64)): int64 =
    let (var_2: int64) = var_0.mem_0
    let (var_3: int64) = var_0.mem_3
    let (var_4: int64) = (var_1 - var_3)
    let (var_5: bool) = (var_2 > var_4)
    let (var_6: int64) =
        if var_5 then
            var_4
        else
            var_2
    let (var_7: int64) = (var_2 - var_6)
    var_0.mem_0 <- var_7
    let (var_8: int64) = (var_3 + var_6)
    var_0.mem_3 <- var_8
    var_8
and method_33((var_0: Union6), (var_1: Union7), (var_2: Union6), (var_3: Union7)): int32 =
    let (var_4: int32) =
        match var_0 with
        | Union6Case0 ->
            12
        | Union6Case1 ->
            6
        | Union6Case2 ->
            3
        | Union6Case3 ->
            2
        | Union6Case4 ->
            9
        | Union6Case5 ->
            11
        | Union6Case6 ->
            7
        | Union6Case7 ->
            10
        | Union6Case8 ->
            5
        | Union6Case9 ->
            4
        | Union6Case10 ->
            8
        | Union6Case11 ->
            1
        | Union6Case12 ->
            0
    let (var_5: int32) =
        match var_2 with
        | Union6Case0 ->
            12
        | Union6Case1 ->
            6
        | Union6Case2 ->
            3
        | Union6Case3 ->
            2
        | Union6Case4 ->
            9
        | Union6Case5 ->
            11
        | Union6Case6 ->
            7
        | Union6Case7 ->
            10
        | Union6Case8 ->
            5
        | Union6Case9 ->
            4
        | Union6Case10 ->
            8
        | Union6Case11 ->
            1
        | Union6Case12 ->
            0
    let (var_6: bool) = (var_4 < var_5)
    if var_6 then
        -1
    else
        let (var_7: bool) = (var_4 = var_5)
        if var_7 then
            0
        else
            1
and method_39((var_0: EnvHeapMutable3), (var_1: int64)): int64 =
    let (var_2: int64) = var_0.mem_3
    let (var_3: bool) = (var_2 > var_1)
    let (var_4: int64) =
        if var_3 then
            var_1
        else
            var_2
    let (var_5: int64) = (var_2 - var_4)
    var_0.mem_3 <- var_5
    var_4
and method_41((var_0: EnvHeapMutable4), (var_1: int64)): int64 =
    let (var_2: int64) = var_0.mem_3
    let (var_3: bool) = (var_2 > var_1)
    let (var_4: int64) =
        if var_3 then
            var_1
        else
            var_2
    let (var_5: int64) = (var_2 - var_4)
    var_0.mem_3 <- var_5
    var_4
and method_43((var_0: EnvHeapMutable3), (var_1: int64)): unit =
    let (var_2: int64) = var_0.mem_0
    let (var_3: int64) = (var_2 + var_1)
    var_0.mem_0 <- var_3
and method_45((var_0: EnvHeapMutable4), (var_1: int64)): unit =
    let (var_2: int64) = var_0.mem_0
    let (var_3: int64) = (var_2 + var_1)
    var_0.mem_0 <- var_3
and method_51((var_0: EnvHeapMutable4)): int64 =
    let (var_1: int64) = var_0.mem_0
    let (var_2: int64) = var_0.mem_3
    let (var_3: int64) = (1L - var_2)
    let (var_4: bool) = (var_1 > var_3)
    let (var_5: int64) =
        if var_4 then
            var_3
        else
            var_1
    let (var_6: int64) = (var_1 - var_5)
    var_0.mem_0 <- var_6
    let (var_7: int64) = (var_2 + var_5)
    var_0.mem_3 <- var_7
    var_7
and method_53((var_0: EnvHeapMutable3)): int64 =
    let (var_1: int64) = var_0.mem_0
    let (var_2: int64) = var_0.mem_3
    let (var_3: int64) = (2L - var_2)
    let (var_4: bool) = (var_1 > var_3)
    let (var_5: int64) =
        if var_4 then
            var_3
        else
            var_1
    let (var_6: int64) = (var_1 - var_5)
    var_0.mem_0 <- var_6
    let (var_7: int64) = (var_2 + var_5)
    var_0.mem_3 <- var_7
    var_7
and method_58((var_0: bool), (var_1: EnvHeapMutable4)): Union2 =
    if var_0 then
        var_1.mem_1
    else
        Union2Case1
and method_59((var_0: bool), (var_1: EnvHeapMutable3), (var_2: Union2)): Union2 =
    if var_0 then
        match var_2 with
        | Union2Case0(var_3) ->
            let (var_4: Env5) = var_3.mem_0
            let (var_5: Union6) = var_4.mem_0
            let (var_6: Union7) = var_4.mem_1
            let (var_7: Union2) = var_1.mem_1
            match var_7 with
            | Union2Case0(var_8) ->
                let (var_9: Env5) = var_8.mem_0
                let (var_10: Union6) = var_9.mem_0
                let (var_11: Union7) = var_9.mem_1
                let (var_12: int32) = method_33((var_5: Union6), (var_6: Union7), (var_10: Union6), (var_11: Union7))
                let (var_13: bool) = (var_12 = 1)
                if var_13 then
                    (Union2Case0(Tuple10((Env5(var_5, var_6)))))
                else
                    (Union2Case0(Tuple10((Env5(var_10, var_11)))))
            | Union2Case1 ->
                (Union2Case0(Tuple10((Env5(var_5, var_6)))))
        | Union2Case1 ->
            var_1.mem_1
    else
        var_2
and method_60((var_0: Union6), (var_1: Union7), (var_2: bool), (var_3: EnvHeapMutable4)): int64 =
    if var_2 then
        let (var_4: Union2) = var_3.mem_1
        match var_4 with
        | Union2Case0(var_5) ->
            let (var_6: Env5) = var_5.mem_0
            let (var_7: Union6) = var_6.mem_0
            let (var_8: Union7) = var_6.mem_1
            let (var_9: int32) = method_33((var_0: Union6), (var_1: Union7), (var_7: Union6), (var_8: Union7))
            let (var_10: bool) = (var_9 = 0)
            if var_10 then
                1L
            else
                0L
        | Union2Case1 ->
            0L
    else
        0L
and method_61((var_0: Union6), (var_1: Union7), (var_2: bool), (var_3: EnvHeapMutable3), (var_4: int64)): int64 =
    if var_2 then
        let (var_5: Union2) = var_3.mem_1
        match var_5 with
        | Union2Case0(var_6) ->
            let (var_7: Env5) = var_6.mem_0
            let (var_8: Union6) = var_7.mem_0
            let (var_9: Union7) = var_7.mem_1
            let (var_10: int32) = method_33((var_0: Union6), (var_1: Union7), (var_8: Union6), (var_9: Union7))
            let (var_11: bool) = (var_10 = 0)
            if var_11 then
                (var_4 + 1L)
            else
                var_4
        | Union2Case1 ->
            var_4
    else
        var_4
and method_62((var_0: int64), (var_1: bool), (var_2: EnvHeapMutable4)): int64 =
    if var_1 then
        method_41((var_2: EnvHeapMutable4), (var_0: int64))
    else
        0L
and method_63((var_0: int64), (var_1: bool), (var_2: EnvHeapMutable3), (var_3: int64)): int64 =
    if var_1 then
        let (var_4: int64) = method_39((var_2: EnvHeapMutable3), (var_0: int64))
        (var_3 + var_4)
    else
        var_3
let (var_0: System.Random) = System.Random()
let (var_1: EnvStack0) = EnvStack0((var_0: System.Random))
let (var_2: EnvStack1) = EnvStack1((var_1: EnvStack0))
let (var_3: EnvStack0) = var_2.mem_0
let (var_4: int64) = 6L
let (var_5: Union2) = Union2Case1
let (var_6: int64) = 0L
let (var_7: string) = "One"
let (var_8: EnvHeapMutable3) = ({mem_0 = (var_4: int64); mem_1 = (var_5: Union2); mem_2 = (var_7: string); mem_3 = (var_6: int64)} : EnvHeapMutable3)
let (var_9: Union2) = Union2Case1
let (var_10: int64) = 0L
let (var_11: string) = "Two"
let (var_12: EnvHeapMutable4) = ({mem_0 = (var_4: int64); mem_1 = (var_9: Union2); mem_2 = (var_11: string); mem_3 = (var_10: int64); mem_4 = (var_3: EnvStack0)} : EnvHeapMutable4)
let (var_14: (Env5 [])) = [|(Env5(Union6Case12, Union7Case3)); (Env5(Union6Case12, Union7Case0)); (Env5(Union6Case12, Union7Case2)); (Env5(Union6Case12, Union7Case1)); (Env5(Union6Case11, Union7Case3)); (Env5(Union6Case11, Union7Case0)); (Env5(Union6Case11, Union7Case2)); (Env5(Union6Case11, Union7Case1)); (Env5(Union6Case3, Union7Case3)); (Env5(Union6Case3, Union7Case0)); (Env5(Union6Case3, Union7Case2)); (Env5(Union6Case3, Union7Case1)); (Env5(Union6Case2, Union7Case3)); (Env5(Union6Case2, Union7Case0)); (Env5(Union6Case2, Union7Case2)); (Env5(Union6Case2, Union7Case1)); (Env5(Union6Case9, Union7Case3)); (Env5(Union6Case9, Union7Case0)); (Env5(Union6Case9, Union7Case2)); (Env5(Union6Case9, Union7Case1)); (Env5(Union6Case8, Union7Case3)); (Env5(Union6Case8, Union7Case0)); (Env5(Union6Case8, Union7Case2)); (Env5(Union6Case8, Union7Case1)); (Env5(Union6Case1, Union7Case3)); (Env5(Union6Case1, Union7Case0)); (Env5(Union6Case1, Union7Case2)); (Env5(Union6Case1, Union7Case1)); (Env5(Union6Case6, Union7Case3)); (Env5(Union6Case6, Union7Case0)); (Env5(Union6Case6, Union7Case2)); (Env5(Union6Case6, Union7Case1)); (Env5(Union6Case10, Union7Case3)); (Env5(Union6Case10, Union7Case0)); (Env5(Union6Case10, Union7Case2)); (Env5(Union6Case10, Union7Case1)); (Env5(Union6Case4, Union7Case3)); (Env5(Union6Case4, Union7Case0)); (Env5(Union6Case4, Union7Case2)); (Env5(Union6Case4, Union7Case1)); (Env5(Union6Case7, Union7Case3)); (Env5(Union6Case7, Union7Case0)); (Env5(Union6Case7, Union7Case2)); (Env5(Union6Case7, Union7Case1)); (Env5(Union6Case5, Union7Case3)); (Env5(Union6Case5, Union7Case0)); (Env5(Union6Case5, Union7Case2)); (Env5(Union6Case5, Union7Case1)); (Env5(Union6Case0, Union7Case3)); (Env5(Union6Case0, Union7Case0)); (Env5(Union6Case0, Union7Case2)); (Env5(Union6Case0, Union7Case1))|]: (Env5 [])
let (var_15: int64) = var_14.LongLength
let (var_16: bool) = (var_15 = 52L)
let (var_17: bool) = (var_16 = false)
if var_17 then
    (failwith "The number of cards in the deck must be 52.")
else
    ()
let (var_18: System.Random) = System.Random()
let (var_19: int64) = 52L
let (var_20: EnvHeapMutable8) = ({mem_0 = (var_14: (Env5 [])); mem_1 = (var_19: int64); mem_2 = (var_18: System.Random)} : EnvHeapMutable8)
let (var_21: int64) = 0L
let (var_22: int64) = 0L
let (var_23: int64) = 0L
let (var_24: Env9) = method_0((var_4: int64), (var_20: EnvHeapMutable8), (var_8: EnvHeapMutable3), (var_12: EnvHeapMutable4), (var_21: int64), (var_22: int64), (var_23: int64))
let (var_25: int64) = var_24.mem_0
let (var_26: int64) = var_24.mem_1
let (var_27: int64) = (var_25 + var_26)
let (var_28: string) = System.String.Format("Winrate is {0} and {1} out of {2}.",var_25,var_26,var_27)
let (var_29: string) = System.String.Format("{0}",var_28)
System.Console.WriteLine(var_29)

