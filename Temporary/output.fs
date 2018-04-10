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
and Tuple1 =
    struct
    val mem_0: Tuple3
    val mem_1: Union4
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack2 =
    struct
    val mem_0: System.Collections.Generic.Dictionary<Tuple1, float>
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple3 =
    struct
    val mem_0: Env6
    val mem_1: Env6
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union4 =
    | Union4Case0 of Tuple7
    | Union4Case1
    | Union4Case2
and Env5 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env6 =
    struct
    val mem_0: int64
    val mem_1: Union10
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple7 =
    struct
    val mem_0: int64
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple8 =
    struct
    val mem_0: Env9
    val mem_1: Env9
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env9 =
    struct
    val mem_0: int64
    val mem_1: string
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union10 =
    | Union10Case0 of Tuple24
    | Union10Case1
and Env11 =
    struct
    val mem_0: Union12
    val mem_1: Union13
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union12 =
    | Union12Case0
    | Union12Case1
    | Union12Case2
    | Union12Case3
    | Union12Case4
    | Union12Case5
    | Union12Case6
    | Union12Case7
    | Union12Case8
    | Union12Case9
    | Union12Case10
    | Union12Case11
    | Union12Case12
and Union13 =
    | Union13Case0
    | Union13Case1
    | Union13Case2
    | Union13Case3
and Tuple14 =
    struct
    val mem_0: Env6
    val mem_1: Env15
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env15 =
    struct
    val mem_0: (Env11 [])
    val mem_1: Env16
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Env16 =
    struct
    val mem_0: (Env11 [])
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple17 =
    struct
    val mem_0: Env18
    val mem_1: Env21
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env18 =
    struct
    val mem_0: int64
    val mem_1: Union10
    val mem_2: string
    val mem_3: int64
    val mem_4: Env19
    val mem_5: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4, arg_mem_5) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4; mem_5 = arg_mem_5}
    end
and Env19 =
    struct
    val mem_0: Tuple20
    val mem_1: EnvStack2
    val mem_2: float
    val mem_3: float
    val mem_4: float
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and Tuple20 =
    struct
    val mem_0: Tuple7
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env21 =
    struct
    val mem_0: int64
    val mem_1: Union10
    val mem_2: string
    val mem_3: int64
    val mem_4: Env22
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3, arg_mem_4) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3; mem_4 = arg_mem_4}
    end
and Env22 =
    struct
    val mem_0: EnvStack0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple23 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple24 =
    struct
    val mem_0: Env11
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple25 =
    struct
    val mem_0: Union10
    val mem_1: Env15
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union26 =
    | Union26Case0 of Tuple34
    | Union26Case1
and Tuple27 =
    struct
    val mem_0: Env28
    val mem_1: Env29
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env28 =
    struct
    val mem_0: int64
    val mem_1: Union10
    val mem_2: int64
    val mem_3: (float -> unit)
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Env29 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Union30 =
    | Union30Case0 of Tuple36
    | Union30Case1
and Tuple31 =
    struct
    val mem_0: Env6
    val mem_1: Env29
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple32 =
    struct
    val mem_0: Env6
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple33 =
    struct
    val mem_0: Env21
    val mem_1: Env18
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple34 =
    struct
    val mem_0: Tuple27
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple35 =
    struct
    val mem_0: float
    val mem_1: Union4
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple36 =
    struct
    val mem_0: Tuple31
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: float)): unit =
    ()
and method_1((var_0: EnvStack2), (var_1: (float -> unit)), (var_2: EnvStack0), (var_3: EnvStack0), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 100L)
    if var_5 then
        let (var_6: string) = System.String.Format("iteration {0}",var_4)
        let (var_7: string) = System.String.Format("Starting timing for: {0}",var_6)
        let (var_8: string) = System.String.Format("{0}",var_7)
        System.Console.WriteLine(var_8)
        let (var_9: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
        let (var_10: int64) = 0L
        let (var_11: int64) = 0L
        let (var_12: int64) = 0L
        let (var_13: Env5) = method_2((var_0: EnvStack2), (var_1: (float -> unit)), (var_2: EnvStack0), (var_3: EnvStack0), (var_10: int64), (var_11: int64), (var_12: int64))
        let (var_14: int64) = var_13.mem_0
        let (var_15: int64) = var_13.mem_1
        let (var_16: int64) = (var_14 + var_15)
        let (var_17: string) = System.String.Format("Winrate is {0} and {1} out of {2}.",var_14,var_15,var_16)
        let (var_18: string) = System.String.Format("{0}",var_17)
        System.Console.WriteLine(var_18)
        let (var_19: System.TimeSpan) = var_9.Elapsed
        let (var_20: string) = System.String.Format("The time was {0} for: {1}",var_19,var_6)
        let (var_21: string) = System.String.Format("{0}",var_20)
        System.Console.WriteLine(var_21)
        let (var_22: int64) = (var_4 + 1L)
        method_1((var_0: EnvStack2), (var_1: (float -> unit)), (var_2: EnvStack0), (var_3: EnvStack0), (var_22: int64))
    else
        ()
and method_2((var_0: EnvStack2), (var_1: (float -> unit)), (var_2: EnvStack0), (var_3: EnvStack0), (var_4: int64), (var_5: int64), (var_6: int64)): Env5 =
    let (var_7: bool) = (var_6 < 10000L)
    if var_7 then
        let (var_8: int64) = 10L
        let (var_9: string) = "One"
        let (var_10: int64) = 0L
        let (var_11: float) = infinity
        let (var_12: float) = 5.000000
        let (var_13: float) = 0.030000
        let (var_14: int64) = 10L
        let (var_15: string) = "Two"
        let (var_16: Tuple8) = method_3((var_3: EnvStack0), (var_8: int64), (var_9: string), (var_10: int64), (var_0: EnvStack2), (var_11: float), (var_12: float), (var_13: float), (var_1: (float -> unit)), (var_14: int64), (var_15: string), (var_2: EnvStack0))
        let (var_17: Env9) = var_16.mem_0
        let (var_18: int64) = var_17.mem_0
        let (var_19: string) = var_17.mem_1
        let (var_20: Env9) = var_16.mem_1
        let (var_21: int64) = var_20.mem_0
        let (var_22: string) = var_20.mem_1
        let (var_23: bool) = (var_19 = "One")
        let (var_32: Env5) =
            if var_23 then
                let (var_24: bool) = (var_18 > 0L)
                if var_24 then
                    let (var_25: int64) = (var_4 + 1L)
                    (Env5(var_25, var_5))
                else
                    let (var_26: int64) = (var_5 + 1L)
                    (Env5(var_4, var_26))
            else
                let (var_28: bool) = (var_18 > 0L)
                if var_28 then
                    let (var_29: int64) = (var_5 + 1L)
                    (Env5(var_4, var_29))
                else
                    let (var_30: int64) = (var_4 + 1L)
                    (Env5(var_30, var_5))
        let (var_33: int64) = var_32.mem_0
        let (var_34: int64) = var_32.mem_1
        let (var_35: int64) = (var_6 + 1L)
        method_2((var_0: EnvStack2), (var_1: (float -> unit)), (var_2: EnvStack0), (var_3: EnvStack0), (var_33: int64), (var_34: int64), (var_35: int64))
    else
        (Env5(var_4, var_5))
and method_3((var_0: EnvStack0), (var_1: int64), (var_2: string), (var_3: int64), (var_4: EnvStack2), (var_5: float), (var_6: float), (var_7: float), (var_8: (float -> unit)), (var_9: int64), (var_10: string), (var_11: EnvStack0)): Tuple8 =
    let (var_13: (Env11 [])) = [|(Env11(Union12Case12, Union13Case3)); (Env11(Union12Case12, Union13Case0)); (Env11(Union12Case12, Union13Case2)); (Env11(Union12Case12, Union13Case1)); (Env11(Union12Case11, Union13Case3)); (Env11(Union12Case11, Union13Case0)); (Env11(Union12Case11, Union13Case2)); (Env11(Union12Case11, Union13Case1)); (Env11(Union12Case3, Union13Case3)); (Env11(Union12Case3, Union13Case0)); (Env11(Union12Case3, Union13Case2)); (Env11(Union12Case3, Union13Case1)); (Env11(Union12Case2, Union13Case3)); (Env11(Union12Case2, Union13Case0)); (Env11(Union12Case2, Union13Case2)); (Env11(Union12Case2, Union13Case1)); (Env11(Union12Case9, Union13Case3)); (Env11(Union12Case9, Union13Case0)); (Env11(Union12Case9, Union13Case2)); (Env11(Union12Case9, Union13Case1)); (Env11(Union12Case8, Union13Case3)); (Env11(Union12Case8, Union13Case0)); (Env11(Union12Case8, Union13Case2)); (Env11(Union12Case8, Union13Case1)); (Env11(Union12Case1, Union13Case3)); (Env11(Union12Case1, Union13Case0)); (Env11(Union12Case1, Union13Case2)); (Env11(Union12Case1, Union13Case1)); (Env11(Union12Case6, Union13Case3)); (Env11(Union12Case6, Union13Case0)); (Env11(Union12Case6, Union13Case2)); (Env11(Union12Case6, Union13Case1)); (Env11(Union12Case10, Union13Case3)); (Env11(Union12Case10, Union13Case0)); (Env11(Union12Case10, Union13Case2)); (Env11(Union12Case10, Union13Case1)); (Env11(Union12Case4, Union13Case3)); (Env11(Union12Case4, Union13Case0)); (Env11(Union12Case4, Union13Case2)); (Env11(Union12Case4, Union13Case1)); (Env11(Union12Case7, Union13Case3)); (Env11(Union12Case7, Union13Case0)); (Env11(Union12Case7, Union13Case2)); (Env11(Union12Case7, Union13Case1)); (Env11(Union12Case5, Union13Case3)); (Env11(Union12Case5, Union13Case0)); (Env11(Union12Case5, Union13Case2)); (Env11(Union12Case5, Union13Case1)); (Env11(Union12Case0, Union13Case3)); (Env11(Union12Case0, Union13Case0)); (Env11(Union12Case0, Union13Case2)); (Env11(Union12Case0, Union13Case1))|]
    let (var_14: int64) = var_13.LongLength
    let (var_15: bool) = (var_14 = 52L)
    let (var_16: bool) = (var_15 = false)
    if var_16 then
        (failwith "The number of cards in the deck must be 52.")
    else
        ()
    method_4((var_13: (Env11 [])), (var_0: EnvStack0))
    let (var_17: int64) = 52L
    let (var_18: Tuple14) = method_6((var_1: int64), (var_13: (Env11 [])), (var_17: int64), (var_2: string))
    let (var_19: Env6) = var_18.mem_0
    let (var_20: int64) = var_19.mem_0
    let (var_21: Union10) = var_19.mem_1
    let (var_22: int64) = var_19.mem_2
    let (var_23: Env15) = var_18.mem_1
    let (var_24: (Env11 [])) = var_23.mem_0
    let (var_25: Env16) = var_23.mem_1
    let (var_26: (Env11 [])) = var_25.mem_0
    let (var_27: int64) = var_23.mem_2
    let (var_28: Tuple14) = method_7((var_9: int64), (var_24: (Env11 [])), (var_26: (Env11 [])), (var_27: int64), (var_10: string))
    let (var_29: Env6) = var_28.mem_0
    let (var_30: int64) = var_29.mem_0
    let (var_31: Union10) = var_29.mem_1
    let (var_32: int64) = var_29.mem_2
    let (var_33: Env15) = var_28.mem_1
    let (var_34: (Env11 [])) = var_33.mem_0
    let (var_35: Env16) = var_33.mem_1
    let (var_36: (Env11 [])) = var_35.mem_0
    let (var_37: int64) = var_33.mem_2
    let (var_38: bool) = (var_20 > 0L)
    let (var_44: bool) =
        if var_38 then
            match var_21 with
            | Union10Case0(var_39) ->
                let (var_40: Env11) = var_39.mem_0
                let (var_41: Union12) = var_40.mem_0
                let (var_42: Union13) = var_40.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_47: int64) =
        if var_44 then
            let (var_45: bool) = (0L > var_22)
            if var_45 then
                0L
            else
                var_22
        else
            0L
    let (var_48: bool) = (var_30 > 0L)
    let (var_54: bool) =
        if var_48 then
            match var_31 with
            | Union10Case0(var_49) ->
                let (var_50: Env11) = var_49.mem_0
                let (var_51: Union12) = var_50.mem_0
                let (var_52: Union13) = var_50.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_57: int64) =
        if var_54 then
            let (var_55: bool) = (var_47 > var_32)
            if var_55 then
                var_47
            else
                var_32
        else
            var_47
    let (var_63: bool) =
        if var_38 then
            match var_21 with
            | Union10Case0(var_58) ->
                let (var_59: Env11) = var_58.mem_0
                let (var_60: Union12) = var_59.mem_0
                let (var_61: Union13) = var_59.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_64: int64) =
        if var_63 then
            1L
        else
            0L
    let (var_70: bool) =
        if var_48 then
            match var_31 with
            | Union10Case0(var_65) ->
                let (var_66: Env11) = var_65.mem_0
                let (var_67: Union12) = var_66.mem_0
                let (var_68: Union13) = var_66.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_72: int64) =
        if var_70 then
            (var_64 + 1L)
        else
            var_64
    let (var_73: int64) = 2L
    let (var_74: int64) = 0L
    let (var_75: Tuple17) = method_8((var_57: int64), (var_73: int64), (var_72: int64), (var_74: int64), (var_20: int64), (var_21: Union10), (var_2: string), (var_22: int64), (var_3: int64), (var_4: EnvStack2), (var_5: float), (var_6: float), (var_7: float), (var_8: (float -> unit)), (var_30: int64), (var_31: Union10), (var_10: string), (var_32: int64), (var_11: EnvStack0))
    let (var_76: Env18) = var_75.mem_0
    let (var_77: int64) = var_76.mem_0
    let (var_78: Union10) = var_76.mem_1
    let (var_79: string) = var_76.mem_2
    let (var_80: int64) = var_76.mem_3
    let (var_81: Env19) = var_76.mem_4
    let (var_82: Tuple20) = var_81.mem_0
    let (var_83: Tuple7) = var_82.mem_0
    let (var_84: int64) = var_83.mem_0
    let (var_85: EnvStack2) = var_81.mem_1
    let (var_86: float) = var_81.mem_2
    let (var_87: float) = var_81.mem_3
    let (var_88: float) = var_81.mem_4
    let (var_89: (float -> unit)) = var_76.mem_5
    let (var_90: Env21) = var_75.mem_1
    let (var_91: int64) = var_90.mem_0
    let (var_92: Union10) = var_90.mem_1
    let (var_93: string) = var_90.mem_2
    let (var_94: int64) = var_90.mem_3
    let (var_95: Env22) = var_90.mem_4
    let (var_96: EnvStack0) = var_95.mem_0
    method_12((var_77: int64), (var_78: Union10), (var_79: string), (var_80: int64), (var_84: int64), (var_85: EnvStack2), (var_86: float), (var_87: float), (var_88: float), (var_89: (float -> unit)))
    method_14((var_91: int64), (var_92: Union10), (var_93: string), (var_94: int64), (var_96: EnvStack0))
    let (var_97: int64) = (var_77 + var_80)
    let (var_98: int64) = (var_91 + var_94)
    let (var_99: Tuple23) = method_15((var_77: int64), (var_78: Union10), (var_80: int64), (var_91: int64), (var_92: Union10), (var_94: int64))
    let (var_100: int64) = var_99.mem_0
    let (var_101: int64) = var_99.mem_1
    let (var_102: int64) = (var_100 - var_97)
    let (var_103: int64) = (var_101 - var_98)
    method_17((var_77: int64), (var_78: Union10), (var_79: string), (var_80: int64), (var_84: int64), (var_85: EnvStack2), (var_86: float), (var_87: float), (var_88: float), (var_89: (float -> unit)), (var_102: int64))
    method_18((var_91: int64), (var_92: Union10), (var_93: string), (var_94: int64), (var_96: EnvStack0), (var_103: int64))
    let (var_104: bool) = (var_100 > 0L)
    let (var_105: int64) =
        if var_104 then
            1L
        else
            0L
    let (var_106: bool) = (var_101 > 0L)
    let (var_108: int64) =
        if var_106 then
            (var_105 + 1L)
        else
            var_105
    let (var_109: bool) = (var_108 = 1L)
    if var_109 then
        Tuple8((Env9(var_100, var_2)), (Env9(var_101, var_10)))
    else
        method_19((var_0: EnvStack0), (var_101: int64), (var_10: string), (var_11: EnvStack0), (var_100: int64), (var_2: string), (var_3: int64), (var_4: EnvStack2), (var_5: float), (var_6: float), (var_7: float), (var_8: (float -> unit)))
and method_4((var_0: (Env11 [])), (var_1: EnvStack0)): unit =
    //In Knuth shuffle
    let (var_2: int64) = 0L
    method_5((var_1: EnvStack0), (var_0: (Env11 [])), (var_2: int64))
and method_6((var_0: int64), (var_1: (Env11 [])), (var_2: int64), (var_3: string)): Tuple14 =
    //In dealing
    let (var_4: bool) = (var_0 > 1L)
    let (var_5: int64) =
        if var_4 then
            1L
        else
            var_0
    let (var_6: int64) = (var_0 - var_5)
    let (var_7: bool) = (var_5 > 0L)
    let (var_12: Tuple25) =
        if var_7 then
            let (var_8: int64) = (var_2 - 1L)
            let (var_9: Env11) = var_1.[int32 var_8]
            let (var_10: Union12) = var_9.mem_0
            let (var_11: Union13) = var_9.mem_1
            Tuple25((Union10Case0(Tuple24((Env11(var_10, var_11))))), (Env15(var_1, (Env16(var_1)), var_8)))
        else
            Tuple25(Union10Case1, (Env15(var_1, (Env16(var_1)), var_2)))
    let (var_13: Union10) = var_12.mem_0
    let (var_14: Env15) = var_12.mem_1
    let (var_15: (Env11 [])) = var_14.mem_0
    let (var_16: Env16) = var_14.mem_1
    let (var_17: (Env11 [])) = var_16.mem_0
    let (var_18: int64) = var_14.mem_2
    Tuple14((Env6(var_6, var_13, var_5)), (Env15(var_15, (Env16(var_17)), var_18)))
and method_7((var_0: int64), (var_1: (Env11 [])), (var_2: (Env11 [])), (var_3: int64), (var_4: string)): Tuple14 =
    //In dealing
    let (var_5: bool) = (var_0 > 2L)
    let (var_6: int64) =
        if var_5 then
            2L
        else
            var_0
    let (var_7: int64) = (var_0 - var_6)
    let (var_8: bool) = (var_6 > 0L)
    let (var_13: Tuple25) =
        if var_8 then
            let (var_9: int64) = (var_3 - 1L)
            let (var_10: Env11) = var_1.[int32 var_9]
            let (var_11: Union12) = var_10.mem_0
            let (var_12: Union13) = var_10.mem_1
            Tuple25((Union10Case0(Tuple24((Env11(var_11, var_12))))), (Env15(var_2, (Env16(var_2)), var_9)))
        else
            Tuple25(Union10Case1, (Env15(var_1, (Env16(var_2)), var_3)))
    let (var_14: Union10) = var_13.mem_0
    let (var_15: Env15) = var_13.mem_1
    let (var_16: (Env11 [])) = var_15.mem_0
    let (var_17: Env16) = var_15.mem_1
    let (var_18: (Env11 [])) = var_17.mem_0
    let (var_19: int64) = var_15.mem_2
    Tuple14((Env6(var_7, var_14, var_6)), (Env15(var_16, (Env16(var_18)), var_19)))
and method_8((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union10), (var_6: string), (var_7: int64), (var_8: int64), (var_9: EnvStack2), (var_10: float), (var_11: float), (var_12: float), (var_13: (float -> unit)), (var_14: int64), (var_15: Union10), (var_16: string), (var_17: int64), (var_18: EnvStack0)): Tuple17 =
    //In betting's loop.
    let (var_19: int64) = 0L
    let (var_20: bool) = (0L <> var_19)
    let (var_22: Env6) =
        if var_20 then
            let (var_21: Union10) = Union10Case1
            (Env6(var_4, var_21, var_7))
        else
            (Env6(var_4, var_5, var_7))
    let (var_23: int64) = var_22.mem_0
    let (var_24: Union10) = var_22.mem_1
    let (var_25: int64) = var_22.mem_2
    let (var_26: bool) = (1L <> var_19)
    let (var_28: Env6) =
        if var_26 then
            let (var_27: Union10) = Union10Case1
            (Env6(var_14, var_27, var_17))
        else
            (Env6(var_14, var_15, var_17))
    let (var_29: int64) = var_28.mem_0
    let (var_30: Union10) = var_28.mem_1
    let (var_31: int64) = var_28.mem_2
    let (var_32: Union26) = method_9((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_23: int64), (var_24: Union10), (var_25: int64), (var_29: int64), (var_30: Union10), (var_31: int64), (var_4: int64), (var_5: Union10), (var_6: string), (var_7: int64), (var_8: int64), (var_9: EnvStack2), (var_10: float), (var_11: float), (var_12: float), (var_13: (float -> unit)))
    match var_32 with
    | Union26Case0(var_33) ->
        let (var_34: Tuple27) = var_33.mem_0
        let (var_35: Env28) = var_34.mem_0
        let (var_36: int64) = var_35.mem_0
        let (var_37: Union10) = var_35.mem_1
        let (var_38: int64) = var_35.mem_2
        let (var_39: (float -> unit)) = var_35.mem_3
        let (var_40: Env29) = var_34.mem_1
        let (var_41: int64) = var_40.mem_0
        let (var_42: int64) = var_40.mem_1
        let (var_43: int64) = var_40.mem_2
        let (var_44: int64) = var_40.mem_3
        let (var_45: int64) = (var_19 + 1L)
        let (var_46: bool) = (0L <> var_45)
        let (var_48: Env6) =
            if var_46 then
                let (var_47: Union10) = Union10Case1
                (Env6(var_36, var_47, var_38))
            else
                (Env6(var_36, var_37, var_38))
        let (var_49: int64) = var_48.mem_0
        let (var_50: Union10) = var_48.mem_1
        let (var_51: int64) = var_48.mem_2
        let (var_52: bool) = (1L <> var_45)
        let (var_54: Env6) =
            if var_52 then
                let (var_53: Union10) = Union10Case1
                (Env6(var_14, var_53, var_17))
            else
                (Env6(var_14, var_15, var_17))
        let (var_55: int64) = var_54.mem_0
        let (var_56: Union10) = var_54.mem_1
        let (var_57: int64) = var_54.mem_2
        let (var_58: Union30) = method_11((var_41: int64), (var_42: int64), (var_43: int64), (var_44: int64), (var_49: int64), (var_50: Union10), (var_51: int64), (var_55: int64), (var_56: Union10), (var_57: int64), (var_14: int64), (var_15: Union10), (var_16: string), (var_17: int64), (var_18: EnvStack0))
        match var_58 with
        | Union30Case0(var_59) ->
            let (var_60: Tuple31) = var_59.mem_0
            let (var_61: Env6) = var_60.mem_0
            let (var_62: int64) = var_61.mem_0
            let (var_63: Union10) = var_61.mem_1
            let (var_64: int64) = var_61.mem_2
            let (var_65: Env29) = var_60.mem_1
            let (var_66: int64) = var_65.mem_0
            let (var_67: int64) = var_65.mem_1
            let (var_68: int64) = var_65.mem_2
            let (var_69: int64) = var_65.mem_3
            let (var_70: int64) = (var_45 + 1L)
            method_8((var_66: int64), (var_67: int64), (var_68: int64), (var_69: int64), (var_36: int64), (var_37: Union10), (var_6: string), (var_38: int64), (var_8: int64), (var_9: EnvStack2), (var_10: float), (var_11: float), (var_12: float), (var_39: (float -> unit)), (var_62: int64), (var_63: Union10), (var_16: string), (var_64: int64), (var_18: EnvStack0))
        | Union30Case1 ->
            Tuple17((Env18(var_36, var_37, var_6, var_38, (Env19(Tuple20(Tuple7(var_8)), var_9, var_10, var_11, var_12)), var_39)), (Env21(var_14, var_15, var_16, var_17, (Env22(var_18)))))
    | Union26Case1 ->
        Tuple17((Env18(var_4, var_5, var_6, var_7, (Env19(Tuple20(Tuple7(var_8)), var_9, var_10, var_11, var_12)), var_13)), (Env21(var_14, var_15, var_16, var_17, (Env22(var_18)))))
and method_12((var_0: int64), (var_1: Union10), (var_2: string), (var_3: int64), (var_4: int64), (var_5: EnvStack2), (var_6: float), (var_7: float), (var_8: float), (var_9: (float -> unit))): unit =
    //In showdown's card show.
    let (var_10: bool) = (var_3 > 0L)
    if var_10 then
        match var_1 with
        | Union10Case0(var_11) ->
            let (var_12: Env11) = var_11.mem_0
            let (var_13: Union12) = var_12.mem_0
            let (var_14: Union13) = var_12.mem_1
            let (var_15: string) = method_13((var_13: Union12), (var_14: Union13))
            ()
        | Union10Case1 ->
            ()
    else
        ()
and method_14((var_0: int64), (var_1: Union10), (var_2: string), (var_3: int64), (var_4: EnvStack0)): unit =
    //In showdown's card show.
    let (var_5: bool) = (var_3 > 0L)
    if var_5 then
        match var_1 with
        | Union10Case0(var_6) ->
            let (var_7: Env11) = var_6.mem_0
            let (var_8: Union12) = var_7.mem_0
            let (var_9: Union13) = var_7.mem_1
            let (var_10: string) = method_13((var_8: Union12), (var_9: Union13))
            ()
        | Union10Case1 ->
            ()
    else
        ()
and method_15((var_0: int64), (var_1: Union10), (var_2: int64), (var_3: int64), (var_4: Union10), (var_5: int64)): Tuple23 =
    //In showdown
    let (var_6: bool) = (var_2 > 0L)
    let (var_7: bool) = (var_5 > 0L)
    let (var_8: Union10) =
        if var_6 then
            var_1
        else
            Union10Case1
    let (var_27: Union10) =
        if var_7 then
            match var_8 with
            | Union10Case0(var_9) ->
                let (var_10: Env11) = var_9.mem_0
                let (var_11: Union12) = var_10.mem_0
                let (var_12: Union13) = var_10.mem_1
                match var_4 with
                | Union10Case0(var_13) ->
                    let (var_14: Env11) = var_13.mem_0
                    let (var_15: Union12) = var_14.mem_0
                    let (var_16: Union13) = var_14.mem_1
                    let (var_17: int32) = method_16((var_11: Union12), (var_12: Union13))
                    let (var_18: int32) = method_16((var_15: Union12), (var_16: Union13))
                    let (var_19: bool) = (var_17 < var_18)
                    let (var_22: int32) =
                        if var_19 then
                            -1
                        else
                            let (var_20: bool) = (var_17 = var_18)
                            if var_20 then
                                0
                            else
                                1
                    let (var_23: bool) = (var_22 = 1)
                    if var_23 then
                        (Union10Case0(Tuple24((Env11(var_11, var_12)))))
                    else
                        (Union10Case0(Tuple24((Env11(var_15, var_16)))))
                | Union10Case1 ->
                    (Union10Case0(Tuple24((Env11(var_11, var_12)))))
            | Union10Case1 ->
                var_4
        else
            var_8
    match var_27 with
    | Union10Case0(var_28) ->
        let (var_29: Env11) = var_28.mem_0
        let (var_30: Union12) = var_29.mem_0
        let (var_31: Union13) = var_29.mem_1
        let (var_32: int64) = System.Int64.MaxValue
        let (var_35: int64) =
            if var_6 then
                let (var_33: bool) = (var_32 > var_2)
                if var_33 then
                    var_2
                else
                    var_32
            else
                var_32
        let (var_38: int64) =
            if var_7 then
                let (var_36: bool) = (var_35 > var_5)
                if var_36 then
                    var_5
                else
                    var_35
            else
                var_35
        let (var_42: Tuple32) =
            if var_6 then
                let (var_39: bool) = (var_38 > var_2)
                let (var_40: int64) =
                    if var_39 then
                        var_2
                    else
                        var_38
                let (var_41: int64) = (var_2 - var_40)
                Tuple32((Env6(var_0, var_1, var_41)), var_40)
            else
                Tuple32((Env6(var_0, var_1, var_2)), 0L)
        let (var_43: Env6) = var_42.mem_0
        let (var_44: int64) = var_43.mem_0
        let (var_45: Union10) = var_43.mem_1
        let (var_46: int64) = var_43.mem_2
        let (var_47: int64) = var_42.mem_1
        let (var_52: Tuple32) =
            if var_7 then
                let (var_48: bool) = (var_38 > var_5)
                let (var_49: int64) =
                    if var_48 then
                        var_5
                    else
                        var_38
                let (var_50: int64) = (var_5 - var_49)
                let (var_51: int64) = (var_47 + var_49)
                Tuple32((Env6(var_3, var_4, var_50)), var_51)
            else
                Tuple32((Env6(var_3, var_4, var_5)), var_47)
        let (var_53: Env6) = var_52.mem_0
        let (var_54: int64) = var_53.mem_0
        let (var_55: Union10) = var_53.mem_1
        let (var_56: int64) = var_53.mem_2
        let (var_57: int64) = var_52.mem_1
        let (var_70: bool) =
            if var_6 then
                match var_45 with
                | Union10Case0(var_58) ->
                    let (var_59: Env11) = var_58.mem_0
                    let (var_60: Union12) = var_59.mem_0
                    let (var_61: Union13) = var_59.mem_1
                    let (var_62: int32) = method_16((var_30: Union12), (var_31: Union13))
                    let (var_63: int32) = method_16((var_60: Union12), (var_61: Union13))
                    let (var_64: bool) = (var_62 < var_63)
                    let (var_67: int32) =
                        if var_64 then
                            -1
                        else
                            let (var_65: bool) = (var_62 = var_63)
                            if var_65 then
                                0
                            else
                                1
                    (var_67 = 0)
                | Union10Case1 ->
                    false
            else
                false
        let (var_83: bool) =
            if var_7 then
                match var_55 with
                | Union10Case0(var_71) ->
                    let (var_72: Env11) = var_71.mem_0
                    let (var_73: Union12) = var_72.mem_0
                    let (var_74: Union13) = var_72.mem_1
                    let (var_75: int32) = method_16((var_30: Union12), (var_31: Union13))
                    let (var_76: int32) = method_16((var_73: Union12), (var_74: Union13))
                    let (var_77: bool) = (var_75 < var_76)
                    let (var_80: int32) =
                        if var_77 then
                            -1
                        else
                            let (var_78: bool) = (var_75 = var_76)
                            if var_78 then
                                0
                            else
                                1
                    (var_80 = 0)
                | Union10Case1 ->
                    false
            else
                false
        let (var_84: int64) =
            if var_70 then
                1L
            else
                0L
        let (var_86: int64) =
            if var_83 then
                (var_84 + 1L)
            else
                var_84
        let (var_87: int64) = (var_57 % var_86)
        let (var_88: bool) = (var_87 <> 0L)
        let (var_89: int64) = (var_57 / var_86)
        let (var_91: Tuple32) =
            if var_70 then
                let (var_90: int64) = (var_44 + var_89)
                Tuple32((Env6(var_90, var_45, var_46)), 1L)
            else
                Tuple32((Env6(var_44, var_45, var_46)), 0L)
        let (var_92: Env6) = var_91.mem_0
        let (var_93: int64) = var_92.mem_0
        let (var_94: Union10) = var_92.mem_1
        let (var_95: int64) = var_92.mem_2
        let (var_96: int64) = var_91.mem_1
        let (var_100: Tuple32) =
            if var_83 then
                let (var_97: int64) =
                    if var_88 then
                        var_96
                    else
                        0L
                let (var_98: int64) = (var_54 + var_89)
                let (var_99: int64) = (var_98 + var_97)
                Tuple32((Env6(var_99, var_55, var_56)), 1L)
            else
                Tuple32((Env6(var_54, var_55, var_56)), var_96)
        let (var_101: Env6) = var_100.mem_0
        let (var_102: int64) = var_101.mem_0
        let (var_103: Union10) = var_101.mem_1
        let (var_104: int64) = var_101.mem_2
        let (var_105: int64) = var_100.mem_1
        method_15((var_93: int64), (var_94: Union10), (var_95: int64), (var_102: int64), (var_103: Union10), (var_104: int64))
    | Union10Case1 ->
        let (var_107: int64) = (var_0 + var_2)
        let (var_108: int64) = (var_3 + var_5)
        Tuple23(var_107, var_108)
and method_17((var_0: int64), (var_1: Union10), (var_2: string), (var_3: int64), (var_4: int64), (var_5: EnvStack2), (var_6: float), (var_7: float), (var_8: float), (var_9: (float -> unit)), (var_10: int64)): unit =
    //In the reward part.
    let (var_11: float) = (float var_10)
    var_9(var_11)
    let (var_12: bool) = (var_10 = 1L)
    if var_12 then
        ()
    else
        let (var_13: bool) = (var_10 = -1L)
        if var_13 then
            let (var_14: int64) = (-var_10)
            ()
        else
            let (var_15: bool) = (var_10 > 0L)
            if var_15 then
                ()
            else
                let (var_16: bool) = (var_10 < 0L)
                if var_16 then
                    let (var_17: int64) = (-var_10)
                    ()
                else
                    ()
and method_18((var_0: int64), (var_1: Union10), (var_2: string), (var_3: int64), (var_4: EnvStack0), (var_5: int64)): unit =
    //In the reward part.
    let (var_6: bool) = (var_5 = 1L)
    if var_6 then
        ()
    else
        let (var_7: bool) = (var_5 = -1L)
        if var_7 then
            let (var_8: int64) = (-var_5)
            ()
        else
            let (var_9: bool) = (var_5 > 0L)
            if var_9 then
                ()
            else
                let (var_10: bool) = (var_5 < 0L)
                if var_10 then
                    let (var_11: int64) = (-var_5)
                    ()
                else
                    ()
and method_19((var_0: EnvStack0), (var_1: int64), (var_2: string), (var_3: EnvStack0), (var_4: int64), (var_5: string), (var_6: int64), (var_7: EnvStack2), (var_8: float), (var_9: float), (var_10: float), (var_11: (float -> unit))): Tuple8 =
    let (var_13: (Env11 [])) = [|(Env11(Union12Case12, Union13Case3)); (Env11(Union12Case12, Union13Case0)); (Env11(Union12Case12, Union13Case2)); (Env11(Union12Case12, Union13Case1)); (Env11(Union12Case11, Union13Case3)); (Env11(Union12Case11, Union13Case0)); (Env11(Union12Case11, Union13Case2)); (Env11(Union12Case11, Union13Case1)); (Env11(Union12Case3, Union13Case3)); (Env11(Union12Case3, Union13Case0)); (Env11(Union12Case3, Union13Case2)); (Env11(Union12Case3, Union13Case1)); (Env11(Union12Case2, Union13Case3)); (Env11(Union12Case2, Union13Case0)); (Env11(Union12Case2, Union13Case2)); (Env11(Union12Case2, Union13Case1)); (Env11(Union12Case9, Union13Case3)); (Env11(Union12Case9, Union13Case0)); (Env11(Union12Case9, Union13Case2)); (Env11(Union12Case9, Union13Case1)); (Env11(Union12Case8, Union13Case3)); (Env11(Union12Case8, Union13Case0)); (Env11(Union12Case8, Union13Case2)); (Env11(Union12Case8, Union13Case1)); (Env11(Union12Case1, Union13Case3)); (Env11(Union12Case1, Union13Case0)); (Env11(Union12Case1, Union13Case2)); (Env11(Union12Case1, Union13Case1)); (Env11(Union12Case6, Union13Case3)); (Env11(Union12Case6, Union13Case0)); (Env11(Union12Case6, Union13Case2)); (Env11(Union12Case6, Union13Case1)); (Env11(Union12Case10, Union13Case3)); (Env11(Union12Case10, Union13Case0)); (Env11(Union12Case10, Union13Case2)); (Env11(Union12Case10, Union13Case1)); (Env11(Union12Case4, Union13Case3)); (Env11(Union12Case4, Union13Case0)); (Env11(Union12Case4, Union13Case2)); (Env11(Union12Case4, Union13Case1)); (Env11(Union12Case7, Union13Case3)); (Env11(Union12Case7, Union13Case0)); (Env11(Union12Case7, Union13Case2)); (Env11(Union12Case7, Union13Case1)); (Env11(Union12Case5, Union13Case3)); (Env11(Union12Case5, Union13Case0)); (Env11(Union12Case5, Union13Case2)); (Env11(Union12Case5, Union13Case1)); (Env11(Union12Case0, Union13Case3)); (Env11(Union12Case0, Union13Case0)); (Env11(Union12Case0, Union13Case2)); (Env11(Union12Case0, Union13Case1))|]
    let (var_14: int64) = var_13.LongLength
    let (var_15: bool) = (var_14 = 52L)
    let (var_16: bool) = (var_15 = false)
    if var_16 then
        (failwith "The number of cards in the deck must be 52.")
    else
        ()
    method_4((var_13: (Env11 [])), (var_0: EnvStack0))
    let (var_17: int64) = 52L
    let (var_18: Tuple14) = method_6((var_1: int64), (var_13: (Env11 [])), (var_17: int64), (var_2: string))
    let (var_19: Env6) = var_18.mem_0
    let (var_20: int64) = var_19.mem_0
    let (var_21: Union10) = var_19.mem_1
    let (var_22: int64) = var_19.mem_2
    let (var_23: Env15) = var_18.mem_1
    let (var_24: (Env11 [])) = var_23.mem_0
    let (var_25: Env16) = var_23.mem_1
    let (var_26: (Env11 [])) = var_25.mem_0
    let (var_27: int64) = var_23.mem_2
    let (var_28: Tuple14) = method_7((var_4: int64), (var_24: (Env11 [])), (var_26: (Env11 [])), (var_27: int64), (var_5: string))
    let (var_29: Env6) = var_28.mem_0
    let (var_30: int64) = var_29.mem_0
    let (var_31: Union10) = var_29.mem_1
    let (var_32: int64) = var_29.mem_2
    let (var_33: Env15) = var_28.mem_1
    let (var_34: (Env11 [])) = var_33.mem_0
    let (var_35: Env16) = var_33.mem_1
    let (var_36: (Env11 [])) = var_35.mem_0
    let (var_37: int64) = var_33.mem_2
    let (var_38: bool) = (var_20 > 0L)
    let (var_44: bool) =
        if var_38 then
            match var_21 with
            | Union10Case0(var_39) ->
                let (var_40: Env11) = var_39.mem_0
                let (var_41: Union12) = var_40.mem_0
                let (var_42: Union13) = var_40.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_47: int64) =
        if var_44 then
            let (var_45: bool) = (0L > var_22)
            if var_45 then
                0L
            else
                var_22
        else
            0L
    let (var_48: bool) = (var_30 > 0L)
    let (var_54: bool) =
        if var_48 then
            match var_31 with
            | Union10Case0(var_49) ->
                let (var_50: Env11) = var_49.mem_0
                let (var_51: Union12) = var_50.mem_0
                let (var_52: Union13) = var_50.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_57: int64) =
        if var_54 then
            let (var_55: bool) = (var_47 > var_32)
            if var_55 then
                var_47
            else
                var_32
        else
            var_47
    let (var_63: bool) =
        if var_38 then
            match var_21 with
            | Union10Case0(var_58) ->
                let (var_59: Env11) = var_58.mem_0
                let (var_60: Union12) = var_59.mem_0
                let (var_61: Union13) = var_59.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_64: int64) =
        if var_63 then
            1L
        else
            0L
    let (var_70: bool) =
        if var_48 then
            match var_31 with
            | Union10Case0(var_65) ->
                let (var_66: Env11) = var_65.mem_0
                let (var_67: Union12) = var_66.mem_0
                let (var_68: Union13) = var_66.mem_1
                true
            | Union10Case1 ->
                false
        else
            false
    let (var_72: int64) =
        if var_70 then
            (var_64 + 1L)
        else
            var_64
    let (var_73: int64) = 2L
    let (var_74: int64) = 0L
    let (var_75: Tuple33) = method_20((var_57: int64), (var_73: int64), (var_72: int64), (var_74: int64), (var_20: int64), (var_21: Union10), (var_2: string), (var_22: int64), (var_3: EnvStack0), (var_30: int64), (var_31: Union10), (var_5: string), (var_32: int64), (var_6: int64), (var_7: EnvStack2), (var_8: float), (var_9: float), (var_10: float), (var_11: (float -> unit)))
    let (var_76: Env21) = var_75.mem_0
    let (var_77: int64) = var_76.mem_0
    let (var_78: Union10) = var_76.mem_1
    let (var_79: string) = var_76.mem_2
    let (var_80: int64) = var_76.mem_3
    let (var_81: Env22) = var_76.mem_4
    let (var_82: EnvStack0) = var_81.mem_0
    let (var_83: Env18) = var_75.mem_1
    let (var_84: int64) = var_83.mem_0
    let (var_85: Union10) = var_83.mem_1
    let (var_86: string) = var_83.mem_2
    let (var_87: int64) = var_83.mem_3
    let (var_88: Env19) = var_83.mem_4
    let (var_89: Tuple20) = var_88.mem_0
    let (var_90: Tuple7) = var_89.mem_0
    let (var_91: int64) = var_90.mem_0
    let (var_92: EnvStack2) = var_88.mem_1
    let (var_93: float) = var_88.mem_2
    let (var_94: float) = var_88.mem_3
    let (var_95: float) = var_88.mem_4
    let (var_96: (float -> unit)) = var_83.mem_5
    method_14((var_77: int64), (var_78: Union10), (var_79: string), (var_80: int64), (var_82: EnvStack0))
    method_12((var_84: int64), (var_85: Union10), (var_86: string), (var_87: int64), (var_91: int64), (var_92: EnvStack2), (var_93: float), (var_94: float), (var_95: float), (var_96: (float -> unit)))
    let (var_97: int64) = (var_77 + var_80)
    let (var_98: int64) = (var_84 + var_87)
    let (var_99: Tuple23) = method_15((var_77: int64), (var_78: Union10), (var_80: int64), (var_84: int64), (var_85: Union10), (var_87: int64))
    let (var_100: int64) = var_99.mem_0
    let (var_101: int64) = var_99.mem_1
    let (var_102: int64) = (var_100 - var_97)
    let (var_103: int64) = (var_101 - var_98)
    method_18((var_77: int64), (var_78: Union10), (var_79: string), (var_80: int64), (var_82: EnvStack0), (var_102: int64))
    method_17((var_84: int64), (var_85: Union10), (var_86: string), (var_87: int64), (var_91: int64), (var_92: EnvStack2), (var_93: float), (var_94: float), (var_95: float), (var_96: (float -> unit)), (var_103: int64))
    let (var_104: bool) = (var_100 > 0L)
    let (var_105: int64) =
        if var_104 then
            1L
        else
            0L
    let (var_106: bool) = (var_101 > 0L)
    let (var_108: int64) =
        if var_106 then
            (var_105 + 1L)
        else
            var_105
    let (var_109: bool) = (var_108 = 1L)
    if var_109 then
        Tuple8((Env9(var_100, var_2)), (Env9(var_101, var_5)))
    else
        method_3((var_0: EnvStack0), (var_101: int64), (var_5: string), (var_6: int64), (var_7: EnvStack2), (var_8: float), (var_9: float), (var_10: float), (var_11: (float -> unit)), (var_100: int64), (var_2: string), (var_3: EnvStack0))
and method_5((var_0: EnvStack0), (var_1: (Env11 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 51L)
    if var_3 then
        let (var_4: System.Random) = var_0.mem_0
        let (var_5: int32) = (int32 var_2)
        let (var_6: int32) = var_4.Next(var_5, 52)
        let (var_7: Env11) = var_1.[int32 var_2]
        let (var_8: Union12) = var_7.mem_0
        let (var_9: Union13) = var_7.mem_1
        let (var_10: Env11) = var_1.[int32 var_6]
        var_1.[int32 var_2] <- var_10
        var_1.[int32 var_6] <- (Env11(var_8, var_9))
        let (var_11: int64) = (var_2 + 1L)
        method_5((var_0: EnvStack0), (var_1: (Env11 [])), (var_11: int64))
    else
        ()
and method_9((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union10), (var_6: int64), (var_7: int64), (var_8: Union10), (var_9: int64), (var_10: int64), (var_11: Union10), (var_12: string), (var_13: int64), (var_14: int64), (var_15: EnvStack2), (var_16: float), (var_17: float), (var_18: float), (var_19: (float -> unit))): Union26 =
    //In betting
    let (var_20: bool) = (var_3 < var_2)
    let (var_24: bool) =
        if var_20 then
            let (var_21: bool) = (var_2 <> 1L)
            if var_21 then
                true
            else
                (var_13 < var_0)
        else
            false
    if var_24 then
        let (var_25: bool) = (var_10 > 0L)
        let (var_31: bool) =
            if var_25 then
                match var_11 with
                | Union10Case0(var_26) ->
                    let (var_27: Env11) = var_26.mem_0
                    let (var_28: Union12) = var_27.mem_0
                    let (var_29: Union13) = var_27.mem_1
                    true
                | Union10Case1 ->
                    false
            else
                false
        if var_31 then
            let (var_32: float) = (-var_16)
            let (var_33: System.Collections.Generic.Dictionary<Tuple1, float>) = var_15.mem_0
            var_33.TryGetValue <| Tuple1(Tuple3((Env6(var_4, var_5, var_6)), (Env6(var_7, var_8, var_9))), Union4Case2) |> fun (a,b) -> 
            let (var_34: bool) = a
            let (var_35: float) = b
            let (var_36: float) =
                if var_34 then
                    var_35
                else
                    var_17
            let (var_37: bool) = (var_36 > var_32)
            let (var_38: Tuple35) =
                if var_37 then
                    Tuple35(var_36, Union4Case2)
                else
                    Tuple35(var_32, Union4Case2)
            let (var_39: float) = var_38.mem_0
            let (var_40: Union4) = var_38.mem_1
            var_33.TryGetValue <| Tuple1(Tuple3((Env6(var_4, var_5, var_6)), (Env6(var_7, var_8, var_9))), Union4Case1) |> fun (a,b) -> 
            let (var_41: bool) = a
            let (var_42: float) = b
            let (var_43: float) =
                if var_41 then
                    var_42
                else
                    var_17
            let (var_44: bool) = (var_43 > var_39)
            let (var_45: Tuple35) =
                if var_44 then
                    Tuple35(var_43, Union4Case1)
                else
                    Tuple35(var_39, var_40)
            let (var_46: float) = var_45.mem_0
            let (var_47: Union4) = var_45.mem_1
            var_33.TryGetValue <| Tuple1(Tuple3((Env6(var_4, var_5, var_6)), (Env6(var_7, var_8, var_9))), (Union4Case0(Tuple7(var_14)))) |> fun (a,b) -> 
            let (var_48: bool) = a
            let (var_49: float) = b
            let (var_50: float) =
                if var_48 then
                    var_49
                else
                    var_17
            let (var_51: bool) = (var_50 > var_46)
            let (var_52: Tuple35) =
                if var_51 then
                    Tuple35(var_50, (Union4Case0(Tuple7(var_14))))
                else
                    Tuple35(var_46, var_47)
            let (var_53: float) = var_52.mem_0
            let (var_54: Union4) = var_52.mem_1
            match var_54 with
            | Union4Case0(var_55) ->
                let (var_56: int64) = var_55.mem_0
                let (var_57: bool) = (var_56 >= 0L)
                let (var_58: bool) = (var_57 = false)
                if var_58 then
                    (failwith "Cannot raise to negative amounts.")
                else
                    ()
                let (var_60: (float -> unit)) = method_10((var_54: Union4), (var_15: EnvStack2), (var_18: float), (var_4: int64), (var_5: Union10), (var_6: int64), (var_7: int64), (var_8: Union10), (var_9: int64), (var_53: float), (var_19: (float -> unit)))
                let (var_61: int64) = (var_0 + var_1)
                let (var_62: int64) = (var_61 + var_56)
                let (var_63: int64) = (var_62 - var_13)
                let (var_64: bool) = (var_10 > var_63)
                let (var_65: int64) =
                    if var_64 then
                        var_63
                    else
                        var_10
                let (var_66: int64) = (var_10 - var_65)
                let (var_67: int64) = (var_13 + var_65)
                let (var_68: bool) = (var_66 = 0L)
                if var_68 then
                    let (var_69: bool) = (var_67 > var_0)
                    if var_69 then
                        let (var_70: int64) = (var_67 - var_0)
                        let (var_71: bool) = (var_1 > var_70)
                        let (var_72: int64) =
                            if var_71 then
                                var_1
                            else
                                var_70
                        let (var_73: int64) = (var_2 - 1L)
                        (Union26Case0(Tuple34(Tuple27((Env28(var_66, var_11, var_67, var_60)), (Env29(var_67, var_72, var_73, 0L))))))
                    else
                        let (var_74: int64) = (var_2 - 1L)
                        (Union26Case0(Tuple34(Tuple27((Env28(var_66, var_11, var_67, var_60)), (Env29(var_0, var_1, var_74, var_3))))))
                else
                    let (var_76: bool) = (var_67 > var_0)
                    if var_76 then
                        let (var_77: int64) = (var_67 - var_0)
                        let (var_78: bool) = (var_1 > var_77)
                        let (var_79: int64) =
                            if var_78 then
                                var_1
                            else
                                var_77
                        (Union26Case0(Tuple34(Tuple27((Env28(var_66, var_11, var_67, var_60)), (Env29(var_67, var_79, var_2, 1L))))))
                    else
                        let (var_80: Env29) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                        let (var_81: int64) = var_80.mem_0
                        let (var_82: int64) = var_80.mem_1
                        let (var_83: int64) = var_80.mem_2
                        let (var_84: int64) = var_80.mem_3
                        (Union26Case0(Tuple34(Tuple27((Env28(var_66, var_11, var_67, var_60)), (Env29(var_81, var_82, var_83, var_84))))))
            | Union4Case1 ->
                let (var_88: (float -> unit)) = method_10((var_54: Union4), (var_15: EnvStack2), (var_18: float), (var_4: int64), (var_5: Union10), (var_6: int64), (var_7: int64), (var_8: Union10), (var_9: int64), (var_53: float), (var_19: (float -> unit)))
                let (var_89: int64) = (var_0 - var_13)
                let (var_90: bool) = (var_10 > var_89)
                let (var_91: int64) =
                    if var_90 then
                        var_89
                    else
                        var_10
                let (var_92: int64) = (var_10 - var_91)
                let (var_93: int64) = (var_13 + var_91)
                let (var_94: bool) = (var_92 = 0L)
                if var_94 then
                    let (var_95: int64) = (var_2 - 1L)
                    (Union26Case0(Tuple34(Tuple27((Env28(var_92, var_11, var_93, var_88)), (Env29(var_0, var_1, var_95, var_3))))))
                else
                    let (var_96: int64) = (var_3 + 1L)
                    (Union26Case0(Tuple34(Tuple27((Env28(var_92, var_11, var_93, var_88)), (Env29(var_0, var_1, var_2, var_96))))))
            | Union4Case2 ->
                let (var_99: (float -> unit)) = method_10((var_54: Union4), (var_15: EnvStack2), (var_18: float), (var_4: int64), (var_5: Union10), (var_6: int64), (var_7: int64), (var_8: Union10), (var_9: int64), (var_53: float), (var_19: (float -> unit)))
                let (var_100: int64) = (var_2 - 1L)
                (Union26Case0(Tuple34(Tuple27((Env28(var_10, Union10Case1, var_13, var_99)), (Env29(var_0, var_1, var_100, var_3))))))
        else
            (Union26Case0(Tuple34(Tuple27((Env28(var_10, var_11, var_13, var_19)), (Env29(var_0, var_1, var_2, var_3))))))
    else
        Union26Case1
and method_11((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union10), (var_6: int64), (var_7: int64), (var_8: Union10), (var_9: int64), (var_10: int64), (var_11: Union10), (var_12: string), (var_13: int64), (var_14: EnvStack0)): Union30 =
    //In betting
    let (var_15: bool) = (var_3 < var_2)
    let (var_19: bool) =
        if var_15 then
            let (var_16: bool) = (var_2 <> 1L)
            if var_16 then
                true
            else
                (var_13 < var_0)
        else
            false
    if var_19 then
        let (var_20: bool) = (var_10 > 0L)
        let (var_26: bool) =
            if var_20 then
                match var_11 with
                | Union10Case0(var_21) ->
                    let (var_22: Env11) = var_21.mem_0
                    let (var_23: Union12) = var_22.mem_0
                    let (var_24: Union13) = var_22.mem_1
                    true
                | Union10Case1 ->
                    false
            else
                false
        if var_26 then
            let (var_27: System.Random) = var_14.mem_0
            let (var_28: int32) = var_27.Next(0, 5)
            let (var_29: bool) = (var_28 = 0)
            if var_29 then
                let (var_30: int64) = (var_2 - 1L)
                (Union30Case0(Tuple36(Tuple31((Env6(var_10, Union10Case1, var_13)), (Env29(var_0, var_1, var_30, var_3))))))
            else
                let (var_31: bool) = (var_28 = 1)
                if var_31 then
                    let (var_32: int64) = (var_0 - var_13)
                    let (var_33: bool) = (var_10 > var_32)
                    let (var_34: int64) =
                        if var_33 then
                            var_32
                        else
                            var_10
                    let (var_35: int64) = (var_10 - var_34)
                    let (var_36: int64) = (var_13 + var_34)
                    let (var_37: bool) = (var_35 = 0L)
                    if var_37 then
                        let (var_38: int64) = (var_2 - 1L)
                        (Union30Case0(Tuple36(Tuple31((Env6(var_35, var_11, var_36)), (Env29(var_0, var_1, var_38, var_3))))))
                    else
                        let (var_39: int64) = (var_3 + 1L)
                        (Union30Case0(Tuple36(Tuple31((Env6(var_35, var_11, var_36)), (Env29(var_0, var_1, var_2, var_39))))))
                else
                    let (var_41: int64) = (var_0 + var_1)
                    let (var_42: int64) = (var_41 - var_13)
                    let (var_43: bool) = (var_10 > var_42)
                    let (var_44: int64) =
                        if var_43 then
                            var_42
                        else
                            var_10
                    let (var_45: int64) = (var_10 - var_44)
                    let (var_46: int64) = (var_13 + var_44)
                    let (var_47: bool) = (var_45 = 0L)
                    if var_47 then
                        let (var_48: bool) = (var_46 > var_0)
                        if var_48 then
                            let (var_49: int64) = (var_46 - var_0)
                            let (var_50: bool) = (var_1 > var_49)
                            let (var_51: int64) =
                                if var_50 then
                                    var_1
                                else
                                    var_49
                            let (var_52: int64) = (var_2 - 1L)
                            (Union30Case0(Tuple36(Tuple31((Env6(var_45, var_11, var_46)), (Env29(var_46, var_51, var_52, 0L))))))
                        else
                            let (var_53: int64) = (var_2 - 1L)
                            (Union30Case0(Tuple36(Tuple31((Env6(var_45, var_11, var_46)), (Env29(var_0, var_1, var_53, var_3))))))
                    else
                        let (var_55: bool) = (var_46 > var_0)
                        if var_55 then
                            let (var_56: int64) = (var_46 - var_0)
                            let (var_57: bool) = (var_1 > var_56)
                            let (var_58: int64) =
                                if var_57 then
                                    var_1
                                else
                                    var_56
                            (Union30Case0(Tuple36(Tuple31((Env6(var_45, var_11, var_46)), (Env29(var_46, var_58, var_2, 1L))))))
                        else
                            let (var_59: Env29) = (failwith "Should not be possible to raise to less than the call level without running out of chips.")
                            let (var_60: int64) = var_59.mem_0
                            let (var_61: int64) = var_59.mem_1
                            let (var_62: int64) = var_59.mem_2
                            let (var_63: int64) = var_59.mem_3
                            (Union30Case0(Tuple36(Tuple31((Env6(var_45, var_11, var_46)), (Env29(var_60, var_61, var_62, var_63))))))
        else
            (Union30Case0(Tuple36(Tuple31((Env6(var_10, var_11, var_13)), (Env29(var_0, var_1, var_2, var_3))))))
    else
        Union30Case1
and method_13((var_0: Union12), (var_1: Union13)): string =
    //In show_card.
    match var_0 with
    | Union12Case0 ->
        match var_1 with
        | Union13Case0 ->
            "Ace-Clubs"
        | Union13Case1 ->
            "Ace-Diamonds"
        | Union13Case2 ->
            "Ace-Hearts"
        | Union13Case3 ->
            "Ace-Spades"
    | Union12Case1 ->
        match var_1 with
        | Union13Case0 ->
            "Eight-Clubs"
        | Union13Case1 ->
            "Eight-Diamonds"
        | Union13Case2 ->
            "Eight-Hearts"
        | Union13Case3 ->
            "Eight-Spades"
    | Union12Case2 ->
        match var_1 with
        | Union13Case0 ->
            "Five-Clubs"
        | Union13Case1 ->
            "Five-Diamonds"
        | Union13Case2 ->
            "Five-Hearts"
        | Union13Case3 ->
            "Five-Spades"
    | Union12Case3 ->
        match var_1 with
        | Union13Case0 ->
            "Four-Clubs"
        | Union13Case1 ->
            "Four-Diamonds"
        | Union13Case2 ->
            "Four-Hearts"
        | Union13Case3 ->
            "Four-Spades"
    | Union12Case4 ->
        match var_1 with
        | Union13Case0 ->
            "Jack-Clubs"
        | Union13Case1 ->
            "Jack-Diamonds"
        | Union13Case2 ->
            "Jack-Hearts"
        | Union13Case3 ->
            "Jack-Spades"
    | Union12Case5 ->
        match var_1 with
        | Union13Case0 ->
            "King-Clubs"
        | Union13Case1 ->
            "King-Diamonds"
        | Union13Case2 ->
            "King-Hearts"
        | Union13Case3 ->
            "King-Spades"
    | Union12Case6 ->
        match var_1 with
        | Union13Case0 ->
            "Nine-Clubs"
        | Union13Case1 ->
            "Nine-Diamonds"
        | Union13Case2 ->
            "Nine-Hearts"
        | Union13Case3 ->
            "Nine-Spades"
    | Union12Case7 ->
        match var_1 with
        | Union13Case0 ->
            "Queen-Clubs"
        | Union13Case1 ->
            "Queen-Diamonds"
        | Union13Case2 ->
            "Queen-Hearts"
        | Union13Case3 ->
            "Queen-Spades"
    | Union12Case8 ->
        match var_1 with
        | Union13Case0 ->
            "Seven-Clubs"
        | Union13Case1 ->
            "Seven-Diamonds"
        | Union13Case2 ->
            "Seven-Hearts"
        | Union13Case3 ->
            "Seven-Spades"
    | Union12Case9 ->
        match var_1 with
        | Union13Case0 ->
            "Six-Clubs"
        | Union13Case1 ->
            "Six-Diamonds"
        | Union13Case2 ->
            "Six-Hearts"
        | Union13Case3 ->
            "Six-Spades"
    | Union12Case10 ->
        match var_1 with
        | Union13Case0 ->
            "Ten-Clubs"
        | Union13Case1 ->
            "Ten-Diamonds"
        | Union13Case2 ->
            "Ten-Hearts"
        | Union13Case3 ->
            "Ten-Spades"
    | Union12Case11 ->
        match var_1 with
        | Union13Case0 ->
            "Three-Clubs"
        | Union13Case1 ->
            "Three-Diamonds"
        | Union13Case2 ->
            "Three-Hearts"
        | Union13Case3 ->
            "Three-Spades"
    | Union12Case12 ->
        match var_1 with
        | Union13Case0 ->
            "Two-Clubs"
        | Union13Case1 ->
            "Two-Diamonds"
        | Union13Case2 ->
            "Two-Hearts"
        | Union13Case3 ->
            "Two-Spades"
and method_16((var_0: Union12), (var_1: Union13)): int32 =
    //In hand_rule
    match var_0 with
    | Union12Case0 ->
        12
    | Union12Case1 ->
        6
    | Union12Case2 ->
        3
    | Union12Case3 ->
        2
    | Union12Case4 ->
        9
    | Union12Case5 ->
        11
    | Union12Case6 ->
        7
    | Union12Case7 ->
        10
    | Union12Case8 ->
        5
    | Union12Case9 ->
        4
    | Union12Case10 ->
        8
    | Union12Case11 ->
        1
    | Union12Case12 ->
        0
and method_20((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: Union10), (var_6: string), (var_7: int64), (var_8: EnvStack0), (var_9: int64), (var_10: Union10), (var_11: string), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: float), (var_16: float), (var_17: float), (var_18: (float -> unit))): Tuple33 =
    //In betting's loop.
    let (var_19: int64) = 0L
    let (var_20: bool) = (0L <> var_19)
    let (var_22: Env6) =
        if var_20 then
            let (var_21: Union10) = Union10Case1
            (Env6(var_4, var_21, var_7))
        else
            (Env6(var_4, var_5, var_7))
    let (var_23: int64) = var_22.mem_0
    let (var_24: Union10) = var_22.mem_1
    let (var_25: int64) = var_22.mem_2
    let (var_26: bool) = (1L <> var_19)
    let (var_28: Env6) =
        if var_26 then
            let (var_27: Union10) = Union10Case1
            (Env6(var_9, var_27, var_12))
        else
            (Env6(var_9, var_10, var_12))
    let (var_29: int64) = var_28.mem_0
    let (var_30: Union10) = var_28.mem_1
    let (var_31: int64) = var_28.mem_2
    let (var_32: Union30) = method_11((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_23: int64), (var_24: Union10), (var_25: int64), (var_29: int64), (var_30: Union10), (var_31: int64), (var_4: int64), (var_5: Union10), (var_6: string), (var_7: int64), (var_8: EnvStack0))
    match var_32 with
    | Union30Case0(var_33) ->
        let (var_34: Tuple31) = var_33.mem_0
        let (var_35: Env6) = var_34.mem_0
        let (var_36: int64) = var_35.mem_0
        let (var_37: Union10) = var_35.mem_1
        let (var_38: int64) = var_35.mem_2
        let (var_39: Env29) = var_34.mem_1
        let (var_40: int64) = var_39.mem_0
        let (var_41: int64) = var_39.mem_1
        let (var_42: int64) = var_39.mem_2
        let (var_43: int64) = var_39.mem_3
        let (var_44: int64) = (var_19 + 1L)
        let (var_45: bool) = (0L <> var_44)
        let (var_47: Env6) =
            if var_45 then
                let (var_46: Union10) = Union10Case1
                (Env6(var_36, var_46, var_38))
            else
                (Env6(var_36, var_37, var_38))
        let (var_48: int64) = var_47.mem_0
        let (var_49: Union10) = var_47.mem_1
        let (var_50: int64) = var_47.mem_2
        let (var_51: bool) = (1L <> var_44)
        let (var_53: Env6) =
            if var_51 then
                let (var_52: Union10) = Union10Case1
                (Env6(var_9, var_52, var_12))
            else
                (Env6(var_9, var_10, var_12))
        let (var_54: int64) = var_53.mem_0
        let (var_55: Union10) = var_53.mem_1
        let (var_56: int64) = var_53.mem_2
        let (var_57: Union26) = method_9((var_40: int64), (var_41: int64), (var_42: int64), (var_43: int64), (var_48: int64), (var_49: Union10), (var_50: int64), (var_54: int64), (var_55: Union10), (var_56: int64), (var_9: int64), (var_10: Union10), (var_11: string), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: float), (var_16: float), (var_17: float), (var_18: (float -> unit)))
        match var_57 with
        | Union26Case0(var_58) ->
            let (var_59: Tuple27) = var_58.mem_0
            let (var_60: Env28) = var_59.mem_0
            let (var_61: int64) = var_60.mem_0
            let (var_62: Union10) = var_60.mem_1
            let (var_63: int64) = var_60.mem_2
            let (var_64: (float -> unit)) = var_60.mem_3
            let (var_65: Env29) = var_59.mem_1
            let (var_66: int64) = var_65.mem_0
            let (var_67: int64) = var_65.mem_1
            let (var_68: int64) = var_65.mem_2
            let (var_69: int64) = var_65.mem_3
            let (var_70: int64) = (var_44 + 1L)
            method_20((var_66: int64), (var_67: int64), (var_68: int64), (var_69: int64), (var_36: int64), (var_37: Union10), (var_6: string), (var_38: int64), (var_8: EnvStack0), (var_61: int64), (var_62: Union10), (var_11: string), (var_63: int64), (var_13: int64), (var_14: EnvStack2), (var_15: float), (var_16: float), (var_17: float), (var_64: (float -> unit)))
        | Union26Case1 ->
            Tuple33((Env21(var_36, var_37, var_6, var_38, (Env22(var_8)))), (Env18(var_9, var_10, var_11, var_12, (Env19(Tuple20(Tuple7(var_13)), var_14, var_15, var_16, var_17)), var_18)))
    | Union30Case1 ->
        Tuple33((Env21(var_4, var_5, var_6, var_7, (Env22(var_8)))), (Env18(var_9, var_10, var_11, var_12, (Env19(Tuple20(Tuple7(var_13)), var_14, var_15, var_16, var_17)), var_18)))
and method_10 ((var_1: Union4), (var_2: EnvStack2), (var_3: float), (var_4: int64), (var_5: Union10), (var_6: int64), (var_7: int64), (var_8: Union10), (var_9: int64), (var_10: float), (var_11: (float -> unit))) ((var_0: float)): unit =
    let (var_12: System.Collections.Generic.Dictionary<Tuple1, float>) = var_2.mem_0
    let (var_13: float) = (var_0 - var_10)
    let (var_14: float) = (var_3 * var_13)
    let (var_15: float) = (var_10 + var_14)
    var_12.[Tuple1(Tuple3((Env6(var_4, var_5, var_6)), (Env6(var_7, var_8, var_9))), var_1)] <- var_15
    var_11(var_0)
let (var_0: System.Random) = System.Random()
let (var_1: EnvStack0) = EnvStack0((var_0: System.Random))
let (var_2: System.Random) = System.Random()
let (var_3: EnvStack0) = EnvStack0((var_2: System.Random))
let (var_4: System.Collections.Generic.Dictionary<Tuple1, float>) = System.Collections.Generic.Dictionary<Tuple1, float>(64,HashIdentity.Structural)
let (var_5: EnvStack2) = EnvStack2((var_4: System.Collections.Generic.Dictionary<Tuple1, float>))
let (var_7: (float -> unit)) = method_0
let (var_8: int64) = 0L
method_1((var_5: EnvStack2), (var_7: (float -> unit)), (var_3: EnvStack0), (var_1: EnvStack0), (var_8: int64))

