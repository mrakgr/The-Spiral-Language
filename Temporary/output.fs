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
    val mem_0: System.Random
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack2 =
    struct
    val mem_0: System.Random
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack3 =
    struct
    val mem_0: EnvStack0
    val mem_1: EnvStack2
    val mem_2: EnvStack1
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and EnvStack4 =
    struct
    val mem_0: EnvStack3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union5 =
    | Union5Case0 of Tuple11
    | Union5Case1
and EnvHeapMutable6 =
    {
    mutable mem_0: int64
    mutable mem_1: Union5
    mutable mem_2: int64
    }
and Env7 =
    struct
    val mem_0: Union8
    val mem_1: Union9
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union8 =
    | Union8Case0
    | Union8Case1
    | Union8Case2
    | Union8Case3
    | Union8Case4
    | Union8Case5
    | Union8Case6
    | Union8Case7
    | Union8Case8
    | Union8Case9
    | Union8Case10
    | Union8Case11
    | Union8Case12
and Union9 =
    | Union9Case0
    | Union9Case1
    | Union9Case2
    | Union9Case3
and EnvHeapMutable10 =
    {
    mutable mem_0: (Env7 [])
    mutable mem_1: int64
    mutable mem_2: EnvStack0
    mutable mem_3: EnvStack2
    mutable mem_4: EnvStack1
    }
and Tuple11 =
    struct
    val mem_0: Env7
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0((var_0: EnvHeapMutable10), (var_1: EnvHeapMutable6), (var_2: string), (var_3: EnvStack3), (var_4: EnvHeapMutable6), (var_5: string)): unit =
    System.Console.WriteLine("A new round is starting...")
    System.Console.WriteLine("Chips counts:")
    let (var_6: int64) = var_1.mem_0
    let (var_7: string) = System.String.Format("{0} has {1} chips.",var_2,var_6)
    let (var_8: string) = System.String.Format("{0}",var_7)
    System.Console.WriteLine(var_8)
    let (var_9: int64) = var_4.mem_0
    let (var_10: string) = System.String.Format("{0} has {1} chips.",var_5,var_9)
    let (var_11: string) = System.String.Format("{0}",var_10)
    System.Console.WriteLine(var_11)
    method_1((var_0: EnvHeapMutable10))
    System.Console.WriteLine("Dealing:")
    let (var_12: int64) = var_1.mem_0
    let (var_13: bool) = (var_12 > 0L)
    if var_13 then
        let (var_14: string) = System.String.Format("{0} antes up {1}",var_2,1L)
        let (var_15: string) = System.String.Format("{0}",var_14)
        System.Console.WriteLine(var_15)
        let (var_16: int64) = var_1.mem_0
        let (var_17: int64) = var_1.mem_2
        let (var_18: int64) = (1L - var_17)
        let (var_19: bool) = (var_16 > var_18)
        let (var_20: int64) =
            if var_19 then
                var_18
            else
                var_16
        let (var_21: int64) = (var_16 - var_20)
        var_1.mem_0 <- var_21
        let (var_22: int64) = (var_17 + var_20)
        var_1.mem_2 <- var_22
        let (var_23: Env7) = method_3((var_0: EnvHeapMutable10))
        let (var_24: Union8) = var_23.mem_0
        let (var_25: Union9) = var_23.mem_1
        let (var_26: Union5) = (Union5Case0(Tuple11((Env7(var_24, var_25)))))
        var_1.mem_1 <- var_26
    else
        ()
    let (var_27: int64) = var_4.mem_0
    let (var_28: bool) = (var_27 > 0L)
    if var_28 then
        let (var_29: string) = System.String.Format("{0} antes up {1}",var_5,2L)
        let (var_30: string) = System.String.Format("{0}",var_29)
        System.Console.WriteLine(var_30)
        let (var_31: int64) = var_4.mem_0
        let (var_32: int64) = var_4.mem_2
        let (var_33: int64) = (2L - var_32)
        let (var_34: bool) = (var_31 > var_33)
        let (var_35: int64) =
            if var_34 then
                var_33
            else
                var_31
        let (var_36: int64) = (var_31 - var_35)
        var_4.mem_0 <- var_36
        let (var_37: int64) = (var_32 + var_35)
        var_4.mem_2 <- var_37
        let (var_38: Env7) = method_3((var_0: EnvHeapMutable10))
        let (var_39: Union8) = var_38.mem_0
        let (var_40: Union9) = var_38.mem_1
        let (var_41: Union5) = (Union5Case0(Tuple11((Env7(var_39, var_40)))))
        var_4.mem_1 <- var_41
    else
        ()
    System.Console.WriteLine("Betting:")
    let (var_42: int64) = var_1.mem_0
    let (var_43: bool) = (var_42 > 0L)
    let (var_48: bool) =
        if var_43 then
            let (var_44: Union5) = var_1.mem_1
            match var_44 with
            | Union5Case0(var_45) ->
                let (var_46: Env7) = var_45.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_49: int64) =
        if var_48 then
            1L
        else
            0L
    let (var_50: int64) = var_4.mem_0
    let (var_51: bool) = (var_50 > 0L)
    let (var_56: bool) =
        if var_51 then
            let (var_52: Union5) = var_4.mem_1
            match var_52 with
            | Union5Case0(var_53) ->
                let (var_54: Env7) = var_53.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_58: int64) =
        if var_56 then
            (var_49 + 1L)
        else
            var_49
    let (var_59: int64) = var_1.mem_0
    let (var_60: bool) = (var_59 > 0L)
    let (var_65: bool) =
        if var_60 then
            let (var_61: Union5) = var_1.mem_1
            match var_61 with
            | Union5Case0(var_62) ->
                let (var_63: Env7) = var_62.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_69: int64) =
        if var_65 then
            let (var_66: int64) = var_1.mem_2
            let (var_67: bool) = (0L > var_66)
            if var_67 then
                0L
            else
                var_66
        else
            0L
    let (var_70: int64) = var_4.mem_0
    let (var_71: bool) = (var_70 > 0L)
    let (var_76: bool) =
        if var_71 then
            let (var_72: Union5) = var_4.mem_1
            match var_72 with
            | Union5Case0(var_73) ->
                let (var_74: Env7) = var_73.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_80: int64) =
        if var_76 then
            let (var_77: int64) = var_4.mem_2
            let (var_78: bool) = (var_69 > var_77)
            if var_78 then
                var_69
            else
                var_77
        else
            var_69
    method_4((var_80: int64), (var_58: int64), (var_0: EnvHeapMutable10), (var_1: EnvHeapMutable6), (var_2: string), (var_3: EnvStack3), (var_4: EnvHeapMutable6), (var_5: string))
    System.Console.WriteLine("Showdown:")
    let (var_81: int64) = var_1.mem_2
    let (var_82: bool) = (var_81 > 0L)
    if var_82 then
        let (var_83: Union5) = var_1.mem_1
        match var_83 with
        | Union5Case0(var_84) ->
            let (var_85: Env7) = var_84.mem_0
            let (var_86: Union8) = var_85.mem_0
            let (var_87: Union9) = var_85.mem_1
            let (var_101: string) =
                match var_86 with
                | Union8Case0 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Ace-Clubs"
                    | Union9Case1 ->
                        "Ace-Diamonds"
                    | Union9Case2 ->
                        "Ace-Hearts"
                    | Union9Case3 ->
                        "Ace-Spades"
                | Union8Case1 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Eight-Clubs"
                    | Union9Case1 ->
                        "Eight-Diamonds"
                    | Union9Case2 ->
                        "Eight-Hearts"
                    | Union9Case3 ->
                        "Eight-Spades"
                | Union8Case2 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Five-Clubs"
                    | Union9Case1 ->
                        "Five-Diamonds"
                    | Union9Case2 ->
                        "Five-Hearts"
                    | Union9Case3 ->
                        "Five-Spades"
                | Union8Case3 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Four-Clubs"
                    | Union9Case1 ->
                        "Four-Diamonds"
                    | Union9Case2 ->
                        "Four-Hearts"
                    | Union9Case3 ->
                        "Four-Spades"
                | Union8Case4 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Jack-Clubs"
                    | Union9Case1 ->
                        "Jack-Diamonds"
                    | Union9Case2 ->
                        "Jack-Hearts"
                    | Union9Case3 ->
                        "Jack-Spades"
                | Union8Case5 ->
                    match var_87 with
                    | Union9Case0 ->
                        "King-Clubs"
                    | Union9Case1 ->
                        "King-Diamonds"
                    | Union9Case2 ->
                        "King-Hearts"
                    | Union9Case3 ->
                        "King-Spades"
                | Union8Case6 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Nine-Clubs"
                    | Union9Case1 ->
                        "Nine-Diamonds"
                    | Union9Case2 ->
                        "Nine-Hearts"
                    | Union9Case3 ->
                        "Nine-Spades"
                | Union8Case7 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Queen-Clubs"
                    | Union9Case1 ->
                        "Queen-Diamonds"
                    | Union9Case2 ->
                        "Queen-Hearts"
                    | Union9Case3 ->
                        "Queen-Spades"
                | Union8Case8 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Seven-Clubs"
                    | Union9Case1 ->
                        "Seven-Diamonds"
                    | Union9Case2 ->
                        "Seven-Hearts"
                    | Union9Case3 ->
                        "Seven-Spades"
                | Union8Case9 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Six-Clubs"
                    | Union9Case1 ->
                        "Six-Diamonds"
                    | Union9Case2 ->
                        "Six-Hearts"
                    | Union9Case3 ->
                        "Six-Spades"
                | Union8Case10 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Ten-Clubs"
                    | Union9Case1 ->
                        "Ten-Diamonds"
                    | Union9Case2 ->
                        "Ten-Hearts"
                    | Union9Case3 ->
                        "Ten-Spades"
                | Union8Case11 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Three-Clubs"
                    | Union9Case1 ->
                        "Three-Diamonds"
                    | Union9Case2 ->
                        "Three-Hearts"
                    | Union9Case3 ->
                        "Three-Spades"
                | Union8Case12 ->
                    match var_87 with
                    | Union9Case0 ->
                        "Two-Clubs"
                    | Union9Case1 ->
                        "Two-Diamonds"
                    | Union9Case2 ->
                        "Two-Hearts"
                    | Union9Case3 ->
                        "Two-Spades"
            let (var_102: string) = System.String.Format("{0} shows {1}",var_2,var_101)
            let (var_103: string) = System.String.Format("{0}",var_102)
            System.Console.WriteLine(var_103)
        | Union5Case1 ->
            ()
    else
        ()
    let (var_104: int64) = var_4.mem_2
    let (var_105: bool) = (var_104 > 0L)
    if var_105 then
        let (var_106: Union5) = var_4.mem_1
        match var_106 with
        | Union5Case0(var_107) ->
            let (var_108: Env7) = var_107.mem_0
            let (var_109: Union8) = var_108.mem_0
            let (var_110: Union9) = var_108.mem_1
            let (var_124: string) =
                match var_109 with
                | Union8Case0 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Ace-Clubs"
                    | Union9Case1 ->
                        "Ace-Diamonds"
                    | Union9Case2 ->
                        "Ace-Hearts"
                    | Union9Case3 ->
                        "Ace-Spades"
                | Union8Case1 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Eight-Clubs"
                    | Union9Case1 ->
                        "Eight-Diamonds"
                    | Union9Case2 ->
                        "Eight-Hearts"
                    | Union9Case3 ->
                        "Eight-Spades"
                | Union8Case2 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Five-Clubs"
                    | Union9Case1 ->
                        "Five-Diamonds"
                    | Union9Case2 ->
                        "Five-Hearts"
                    | Union9Case3 ->
                        "Five-Spades"
                | Union8Case3 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Four-Clubs"
                    | Union9Case1 ->
                        "Four-Diamonds"
                    | Union9Case2 ->
                        "Four-Hearts"
                    | Union9Case3 ->
                        "Four-Spades"
                | Union8Case4 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Jack-Clubs"
                    | Union9Case1 ->
                        "Jack-Diamonds"
                    | Union9Case2 ->
                        "Jack-Hearts"
                    | Union9Case3 ->
                        "Jack-Spades"
                | Union8Case5 ->
                    match var_110 with
                    | Union9Case0 ->
                        "King-Clubs"
                    | Union9Case1 ->
                        "King-Diamonds"
                    | Union9Case2 ->
                        "King-Hearts"
                    | Union9Case3 ->
                        "King-Spades"
                | Union8Case6 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Nine-Clubs"
                    | Union9Case1 ->
                        "Nine-Diamonds"
                    | Union9Case2 ->
                        "Nine-Hearts"
                    | Union9Case3 ->
                        "Nine-Spades"
                | Union8Case7 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Queen-Clubs"
                    | Union9Case1 ->
                        "Queen-Diamonds"
                    | Union9Case2 ->
                        "Queen-Hearts"
                    | Union9Case3 ->
                        "Queen-Spades"
                | Union8Case8 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Seven-Clubs"
                    | Union9Case1 ->
                        "Seven-Diamonds"
                    | Union9Case2 ->
                        "Seven-Hearts"
                    | Union9Case3 ->
                        "Seven-Spades"
                | Union8Case9 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Six-Clubs"
                    | Union9Case1 ->
                        "Six-Diamonds"
                    | Union9Case2 ->
                        "Six-Hearts"
                    | Union9Case3 ->
                        "Six-Spades"
                | Union8Case10 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Ten-Clubs"
                    | Union9Case1 ->
                        "Ten-Diamonds"
                    | Union9Case2 ->
                        "Ten-Hearts"
                    | Union9Case3 ->
                        "Ten-Spades"
                | Union8Case11 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Three-Clubs"
                    | Union9Case1 ->
                        "Three-Diamonds"
                    | Union9Case2 ->
                        "Three-Hearts"
                    | Union9Case3 ->
                        "Three-Spades"
                | Union8Case12 ->
                    match var_110 with
                    | Union9Case0 ->
                        "Two-Clubs"
                    | Union9Case1 ->
                        "Two-Diamonds"
                    | Union9Case2 ->
                        "Two-Hearts"
                    | Union9Case3 ->
                        "Two-Spades"
            let (var_125: string) = System.String.Format("{0} shows {1}",var_5,var_124)
            let (var_126: string) = System.String.Format("{0}",var_125)
            System.Console.WriteLine(var_126)
        | Union5Case1 ->
            ()
    else
        ()
    let (var_127: int64) = var_1.mem_0
    let (var_128: int64) = var_1.mem_2
    let (var_129: int64) = (var_127 + var_128)
    let (var_130: int64) = var_4.mem_0
    let (var_131: int64) = var_4.mem_2
    let (var_132: int64) = (var_130 + var_131)
    method_8((var_1: EnvHeapMutable6), (var_2: string), (var_3: EnvStack3), (var_4: EnvHeapMutable6), (var_5: string))
    let (var_133: int64) = var_1.mem_0
    let (var_134: bool) = (var_129 < var_133)
    if var_134 then
        let (var_135: int64) = (var_133 - var_129)
        let (var_136: string) = System.String.Format("{0} wins {1} chips.",var_2,var_135)
        let (var_137: string) = System.String.Format("{0}",var_136)
        System.Console.WriteLine(var_137)
    else
        let (var_138: bool) = (var_129 > var_133)
        if var_138 then
            let (var_139: int64) = (var_129 - var_133)
            let (var_140: string) = System.String.Format("{0} loses {1} chips.",var_2,var_139)
            let (var_141: string) = System.String.Format("{0}",var_140)
            System.Console.WriteLine(var_141)
        else
            ()
    let (var_142: int64) = var_4.mem_0
    let (var_143: bool) = (var_132 < var_142)
    if var_143 then
        let (var_144: int64) = (var_142 - var_132)
        let (var_145: string) = System.String.Format("{0} wins {1} chips.",var_5,var_144)
        let (var_146: string) = System.String.Format("{0}",var_145)
        System.Console.WriteLine(var_146)
    else
        let (var_147: bool) = (var_132 > var_142)
        if var_147 then
            let (var_148: int64) = (var_132 - var_142)
            let (var_149: string) = System.String.Format("{0} loses {1} chips.",var_5,var_148)
            let (var_150: string) = System.String.Format("{0}",var_149)
            System.Console.WriteLine(var_150)
        else
            ()
    let (var_151: int64) = var_1.mem_0
    let (var_152: bool) = (var_151 > 0L)
    let (var_153: int64) =
        if var_152 then
            1L
        else
            0L
    let (var_154: int64) = var_4.mem_0
    let (var_155: bool) = (var_154 > 0L)
    let (var_157: int64) =
        if var_155 then
            (var_153 + 1L)
        else
            var_153
    let (var_158: bool) = (var_157 = 1L)
    if var_158 then
        System.Console.WriteLine("The game is over.")
        let (var_159: int64) = var_1.mem_0
        let (var_160: bool) = (var_159 > 0L)
        if var_160 then
            let (var_161: string) = System.String.Format("{0} wins with {1} chips!",var_2,var_159)
            let (var_162: string) = System.String.Format("{0}",var_161)
            System.Console.WriteLine(var_162)
        else
            ()
        let (var_163: int64) = var_4.mem_0
        let (var_164: bool) = (var_163 > 0L)
        if var_164 then
            let (var_165: string) = System.String.Format("{0} wins with {1} chips!",var_5,var_163)
            let (var_166: string) = System.String.Format("{0}",var_165)
            System.Console.WriteLine(var_166)
        else
            ()
    else
        method_0((var_0: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_3: EnvStack3), (var_1: EnvHeapMutable6), (var_2: string))
and method_1((var_0: EnvHeapMutable10)): unit =
    let (var_1: EnvStack0) = var_0.mem_2
    let (var_2: EnvStack2) = var_0.mem_3
    let (var_3: EnvStack1) = var_0.mem_4
    let (var_4: (Env7 [])) = var_0.mem_0
    let (var_5: int64) = 0L
    method_2((var_1: EnvStack0), (var_2: EnvStack2), (var_3: EnvStack1), (var_4: (Env7 [])), (var_5: int64))
    let (var_6: int64) = 52L
    var_0.mem_1 <- var_6
and method_3((var_0: EnvHeapMutable10)): Env7 =
    let (var_1: int64) = var_0.mem_1
    let (var_2: int64) = (var_1 - 1L)
    var_0.mem_1 <- var_2
    let (var_3: (Env7 [])) = var_0.mem_0
    var_3.[int32 var_2]
and method_4((var_0: int64), (var_1: int64), (var_2: EnvHeapMutable10), (var_3: EnvHeapMutable6), (var_4: string), (var_5: EnvStack3), (var_6: EnvHeapMutable6), (var_7: string)): unit =
    let (var_8: int64) = 0L
    method_5((var_0: int64), (var_1: int64), (var_8: int64), (var_2: EnvHeapMutable10), (var_3: EnvHeapMutable6), (var_4: string), (var_5: EnvStack3), (var_6: EnvHeapMutable6), (var_7: string))
and method_8((var_0: EnvHeapMutable6), (var_1: string), (var_2: EnvStack3), (var_3: EnvHeapMutable6), (var_4: string)): unit =
    let (var_5: int64) = var_0.mem_2
    let (var_6: bool) = (var_5 > 0L)
    if var_6 then
        let (var_7: Union5) = var_0.mem_1
        match var_7 with
        | Union5Case0(var_8) ->
            let (var_9: Env7) = var_8.mem_0
            let (var_10: Union8) = var_9.mem_0
            let (var_11: Union9) = var_9.mem_1
            let (var_25: string) =
                match var_10 with
                | Union8Case0 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Ace-Clubs"
                    | Union9Case1 ->
                        "Ace-Diamonds"
                    | Union9Case2 ->
                        "Ace-Hearts"
                    | Union9Case3 ->
                        "Ace-Spades"
                | Union8Case1 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Eight-Clubs"
                    | Union9Case1 ->
                        "Eight-Diamonds"
                    | Union9Case2 ->
                        "Eight-Hearts"
                    | Union9Case3 ->
                        "Eight-Spades"
                | Union8Case2 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Five-Clubs"
                    | Union9Case1 ->
                        "Five-Diamonds"
                    | Union9Case2 ->
                        "Five-Hearts"
                    | Union9Case3 ->
                        "Five-Spades"
                | Union8Case3 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Four-Clubs"
                    | Union9Case1 ->
                        "Four-Diamonds"
                    | Union9Case2 ->
                        "Four-Hearts"
                    | Union9Case3 ->
                        "Four-Spades"
                | Union8Case4 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Jack-Clubs"
                    | Union9Case1 ->
                        "Jack-Diamonds"
                    | Union9Case2 ->
                        "Jack-Hearts"
                    | Union9Case3 ->
                        "Jack-Spades"
                | Union8Case5 ->
                    match var_11 with
                    | Union9Case0 ->
                        "King-Clubs"
                    | Union9Case1 ->
                        "King-Diamonds"
                    | Union9Case2 ->
                        "King-Hearts"
                    | Union9Case3 ->
                        "King-Spades"
                | Union8Case6 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Nine-Clubs"
                    | Union9Case1 ->
                        "Nine-Diamonds"
                    | Union9Case2 ->
                        "Nine-Hearts"
                    | Union9Case3 ->
                        "Nine-Spades"
                | Union8Case7 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Queen-Clubs"
                    | Union9Case1 ->
                        "Queen-Diamonds"
                    | Union9Case2 ->
                        "Queen-Hearts"
                    | Union9Case3 ->
                        "Queen-Spades"
                | Union8Case8 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Seven-Clubs"
                    | Union9Case1 ->
                        "Seven-Diamonds"
                    | Union9Case2 ->
                        "Seven-Hearts"
                    | Union9Case3 ->
                        "Seven-Spades"
                | Union8Case9 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Six-Clubs"
                    | Union9Case1 ->
                        "Six-Diamonds"
                    | Union9Case2 ->
                        "Six-Hearts"
                    | Union9Case3 ->
                        "Six-Spades"
                | Union8Case10 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Ten-Clubs"
                    | Union9Case1 ->
                        "Ten-Diamonds"
                    | Union9Case2 ->
                        "Ten-Hearts"
                    | Union9Case3 ->
                        "Ten-Spades"
                | Union8Case11 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Three-Clubs"
                    | Union9Case1 ->
                        "Three-Diamonds"
                    | Union9Case2 ->
                        "Three-Hearts"
                    | Union9Case3 ->
                        "Three-Spades"
                | Union8Case12 ->
                    match var_11 with
                    | Union9Case0 ->
                        "Two-Clubs"
                    | Union9Case1 ->
                        "Two-Diamonds"
                    | Union9Case2 ->
                        "Two-Hearts"
                    | Union9Case3 ->
                        "Two-Spades"
            let (var_26: int64) = var_0.mem_2
            let (var_27: string) = System.String.Format("{0} is active and has {1} and pot of {2}.",var_1,var_25,var_26)
            let (var_28: string) = System.String.Format("{0}",var_27)
            System.Console.WriteLine(var_28)
        | Union5Case1 ->
            ()
    else
        ()
    let (var_29: int64) = var_3.mem_2
    let (var_30: bool) = (var_29 > 0L)
    if var_30 then
        let (var_31: Union5) = var_3.mem_1
        match var_31 with
        | Union5Case0(var_32) ->
            let (var_33: Env7) = var_32.mem_0
            let (var_34: Union8) = var_33.mem_0
            let (var_35: Union9) = var_33.mem_1
            let (var_49: string) =
                match var_34 with
                | Union8Case0 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Ace-Clubs"
                    | Union9Case1 ->
                        "Ace-Diamonds"
                    | Union9Case2 ->
                        "Ace-Hearts"
                    | Union9Case3 ->
                        "Ace-Spades"
                | Union8Case1 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Eight-Clubs"
                    | Union9Case1 ->
                        "Eight-Diamonds"
                    | Union9Case2 ->
                        "Eight-Hearts"
                    | Union9Case3 ->
                        "Eight-Spades"
                | Union8Case2 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Five-Clubs"
                    | Union9Case1 ->
                        "Five-Diamonds"
                    | Union9Case2 ->
                        "Five-Hearts"
                    | Union9Case3 ->
                        "Five-Spades"
                | Union8Case3 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Four-Clubs"
                    | Union9Case1 ->
                        "Four-Diamonds"
                    | Union9Case2 ->
                        "Four-Hearts"
                    | Union9Case3 ->
                        "Four-Spades"
                | Union8Case4 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Jack-Clubs"
                    | Union9Case1 ->
                        "Jack-Diamonds"
                    | Union9Case2 ->
                        "Jack-Hearts"
                    | Union9Case3 ->
                        "Jack-Spades"
                | Union8Case5 ->
                    match var_35 with
                    | Union9Case0 ->
                        "King-Clubs"
                    | Union9Case1 ->
                        "King-Diamonds"
                    | Union9Case2 ->
                        "King-Hearts"
                    | Union9Case3 ->
                        "King-Spades"
                | Union8Case6 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Nine-Clubs"
                    | Union9Case1 ->
                        "Nine-Diamonds"
                    | Union9Case2 ->
                        "Nine-Hearts"
                    | Union9Case3 ->
                        "Nine-Spades"
                | Union8Case7 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Queen-Clubs"
                    | Union9Case1 ->
                        "Queen-Diamonds"
                    | Union9Case2 ->
                        "Queen-Hearts"
                    | Union9Case3 ->
                        "Queen-Spades"
                | Union8Case8 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Seven-Clubs"
                    | Union9Case1 ->
                        "Seven-Diamonds"
                    | Union9Case2 ->
                        "Seven-Hearts"
                    | Union9Case3 ->
                        "Seven-Spades"
                | Union8Case9 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Six-Clubs"
                    | Union9Case1 ->
                        "Six-Diamonds"
                    | Union9Case2 ->
                        "Six-Hearts"
                    | Union9Case3 ->
                        "Six-Spades"
                | Union8Case10 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Ten-Clubs"
                    | Union9Case1 ->
                        "Ten-Diamonds"
                    | Union9Case2 ->
                        "Ten-Hearts"
                    | Union9Case3 ->
                        "Ten-Spades"
                | Union8Case11 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Three-Clubs"
                    | Union9Case1 ->
                        "Three-Diamonds"
                    | Union9Case2 ->
                        "Three-Hearts"
                    | Union9Case3 ->
                        "Three-Spades"
                | Union8Case12 ->
                    match var_35 with
                    | Union9Case0 ->
                        "Two-Clubs"
                    | Union9Case1 ->
                        "Two-Diamonds"
                    | Union9Case2 ->
                        "Two-Hearts"
                    | Union9Case3 ->
                        "Two-Spades"
            let (var_50: int64) = var_3.mem_2
            let (var_51: string) = System.String.Format("{0} is active and has {1} and pot of {2}.",var_4,var_49,var_50)
            let (var_52: string) = System.String.Format("{0}",var_51)
            System.Console.WriteLine(var_52)
        | Union5Case1 ->
            ()
    else
        ()
    let (var_53: int64) = var_0.mem_2
    let (var_54: bool) = (var_53 > 0L)
    let (var_96: Union5) =
        if var_54 then
            let (var_55: Union5) = var_0.mem_1
            match var_55 with
            | Union5Case0(var_56) ->
                let (var_57: Env7) = var_56.mem_0
                let (var_58: Union8) = var_57.mem_0
                let (var_59: Union9) = var_57.mem_1
                let (var_60: int64) = var_3.mem_2
                let (var_61: bool) = (var_60 > 0L)
                if var_61 then
                    let (var_62: Union5) = var_3.mem_1
                    match var_62 with
                    | Union5Case0(var_63) ->
                        let (var_64: Env7) = var_63.mem_0
                        let (var_65: Union8) = var_64.mem_0
                        let (var_66: Union9) = var_64.mem_1
                        let (var_67: int32) =
                            match var_58 with
                            | Union8Case0 ->
                                12
                            | Union8Case1 ->
                                6
                            | Union8Case2 ->
                                3
                            | Union8Case3 ->
                                2
                            | Union8Case4 ->
                                9
                            | Union8Case5 ->
                                11
                            | Union8Case6 ->
                                7
                            | Union8Case7 ->
                                10
                            | Union8Case8 ->
                                5
                            | Union8Case9 ->
                                4
                            | Union8Case10 ->
                                8
                            | Union8Case11 ->
                                1
                            | Union8Case12 ->
                                0
                        let (var_68: int32) =
                            match var_65 with
                            | Union8Case0 ->
                                12
                            | Union8Case1 ->
                                6
                            | Union8Case2 ->
                                3
                            | Union8Case3 ->
                                2
                            | Union8Case4 ->
                                9
                            | Union8Case5 ->
                                11
                            | Union8Case6 ->
                                7
                            | Union8Case7 ->
                                10
                            | Union8Case8 ->
                                5
                            | Union8Case9 ->
                                4
                            | Union8Case10 ->
                                8
                            | Union8Case11 ->
                                1
                            | Union8Case12 ->
                                0
                        let (var_69: bool) = (var_67 < var_68)
                        let (var_72: int32) =
                            if var_69 then
                                -1
                            else
                                let (var_70: bool) = (var_67 = var_68)
                                if var_70 then
                                    0
                                else
                                    1
                        let (var_73: bool) = (var_72 = -1)
                        if var_73 then
                            (Union5Case0(Tuple11((Env7(var_58, var_59)))))
                        else
                            (Union5Case0(Tuple11((Env7(var_65, var_66)))))
                    | Union5Case1 ->
                        Union5Case1
                else
                    Union5Case1
            | Union5Case1 ->
                let (var_77: int64) = var_3.mem_2
                let (var_78: bool) = (var_77 > 0L)
                if var_78 then
                    let (var_79: Union5) = var_3.mem_1
                    match var_79 with
                    | Union5Case0(var_80) ->
                        let (var_81: Env7) = var_80.mem_0
                        let (var_82: Union8) = var_81.mem_0
                        let (var_83: Union9) = var_81.mem_1
                        (Union5Case0(Tuple11((Env7(var_82, var_83)))))
                    | Union5Case1 ->
                        Union5Case1
                else
                    Union5Case1
        else
            let (var_87: int64) = var_3.mem_2
            let (var_88: bool) = (var_87 > 0L)
            if var_88 then
                let (var_89: Union5) = var_3.mem_1
                match var_89 with
                | Union5Case0(var_90) ->
                    let (var_91: Env7) = var_90.mem_0
                    let (var_92: Union8) = var_91.mem_0
                    let (var_93: Union9) = var_91.mem_1
                    (Union5Case0(Tuple11((Env7(var_92, var_93)))))
                | Union5Case1 ->
                    Union5Case1
            else
                Union5Case1
    match var_96 with
    | Union5Case0(var_97) ->
        let (var_98: Env7) = var_97.mem_0
        let (var_99: Union8) = var_98.mem_0
        let (var_100: Union9) = var_98.mem_1
        let (var_114: string) =
            match var_99 with
            | Union8Case0 ->
                match var_100 with
                | Union9Case0 ->
                    "Ace-Clubs"
                | Union9Case1 ->
                    "Ace-Diamonds"
                | Union9Case2 ->
                    "Ace-Hearts"
                | Union9Case3 ->
                    "Ace-Spades"
            | Union8Case1 ->
                match var_100 with
                | Union9Case0 ->
                    "Eight-Clubs"
                | Union9Case1 ->
                    "Eight-Diamonds"
                | Union9Case2 ->
                    "Eight-Hearts"
                | Union9Case3 ->
                    "Eight-Spades"
            | Union8Case2 ->
                match var_100 with
                | Union9Case0 ->
                    "Five-Clubs"
                | Union9Case1 ->
                    "Five-Diamonds"
                | Union9Case2 ->
                    "Five-Hearts"
                | Union9Case3 ->
                    "Five-Spades"
            | Union8Case3 ->
                match var_100 with
                | Union9Case0 ->
                    "Four-Clubs"
                | Union9Case1 ->
                    "Four-Diamonds"
                | Union9Case2 ->
                    "Four-Hearts"
                | Union9Case3 ->
                    "Four-Spades"
            | Union8Case4 ->
                match var_100 with
                | Union9Case0 ->
                    "Jack-Clubs"
                | Union9Case1 ->
                    "Jack-Diamonds"
                | Union9Case2 ->
                    "Jack-Hearts"
                | Union9Case3 ->
                    "Jack-Spades"
            | Union8Case5 ->
                match var_100 with
                | Union9Case0 ->
                    "King-Clubs"
                | Union9Case1 ->
                    "King-Diamonds"
                | Union9Case2 ->
                    "King-Hearts"
                | Union9Case3 ->
                    "King-Spades"
            | Union8Case6 ->
                match var_100 with
                | Union9Case0 ->
                    "Nine-Clubs"
                | Union9Case1 ->
                    "Nine-Diamonds"
                | Union9Case2 ->
                    "Nine-Hearts"
                | Union9Case3 ->
                    "Nine-Spades"
            | Union8Case7 ->
                match var_100 with
                | Union9Case0 ->
                    "Queen-Clubs"
                | Union9Case1 ->
                    "Queen-Diamonds"
                | Union9Case2 ->
                    "Queen-Hearts"
                | Union9Case3 ->
                    "Queen-Spades"
            | Union8Case8 ->
                match var_100 with
                | Union9Case0 ->
                    "Seven-Clubs"
                | Union9Case1 ->
                    "Seven-Diamonds"
                | Union9Case2 ->
                    "Seven-Hearts"
                | Union9Case3 ->
                    "Seven-Spades"
            | Union8Case9 ->
                match var_100 with
                | Union9Case0 ->
                    "Six-Clubs"
                | Union9Case1 ->
                    "Six-Diamonds"
                | Union9Case2 ->
                    "Six-Hearts"
                | Union9Case3 ->
                    "Six-Spades"
            | Union8Case10 ->
                match var_100 with
                | Union9Case0 ->
                    "Ten-Clubs"
                | Union9Case1 ->
                    "Ten-Diamonds"
                | Union9Case2 ->
                    "Ten-Hearts"
                | Union9Case3 ->
                    "Ten-Spades"
            | Union8Case11 ->
                match var_100 with
                | Union9Case0 ->
                    "Three-Clubs"
                | Union9Case1 ->
                    "Three-Diamonds"
                | Union9Case2 ->
                    "Three-Hearts"
                | Union9Case3 ->
                    "Three-Spades"
            | Union8Case12 ->
                match var_100 with
                | Union9Case0 ->
                    "Two-Clubs"
                | Union9Case1 ->
                    "Two-Diamonds"
                | Union9Case2 ->
                    "Two-Hearts"
                | Union9Case3 ->
                    "Two-Spades"
        let (var_115: string) = System.String.Format("The winning hand is {0}",var_114)
        let (var_116: string) = System.String.Format("{0}",var_115)
        System.Console.WriteLine(var_116)
        let (var_117: int64) = var_0.mem_2
        let (var_118: int64) = var_3.mem_2
        let (var_119: bool) = (var_117 > 0L)
        let (var_121: bool) =
            if var_119 then
                (var_118 > 0L)
            else
                false
        let (var_125: int64) =
            if var_121 then
                let (var_122: bool) = (var_117 > var_118)
                if var_122 then
                    var_118
                else
                    var_117
            else
                if var_119 then
                    var_117
                else
                    var_118
        let (var_126: int64) = var_0.mem_2
        let (var_127: bool) = (var_126 > 0L)
        let (var_142: int64) =
            if var_127 then
                let (var_128: Union5) = var_0.mem_1
                match var_128 with
                | Union5Case0(var_129) ->
                    let (var_130: Env7) = var_129.mem_0
                    let (var_131: Union8) = var_130.mem_0
                    let (var_132: Union9) = var_130.mem_1
                    let (var_133: int32) =
                        match var_99 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_134: int32) =
                        match var_131 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_135: bool) = (var_133 < var_134)
                    let (var_138: int32) =
                        if var_135 then
                            -1
                        else
                            let (var_136: bool) = (var_133 = var_134)
                            if var_136 then
                                0
                            else
                                1
                    let (var_139: bool) = (var_138 = 0)
                    if var_139 then
                        1L
                    else
                        0L
                | Union5Case1 ->
                    0L
            else
                0L
        let (var_143: int64) = var_3.mem_2
        let (var_144: bool) = (var_143 > 0L)
        let (var_160: int64) =
            if var_144 then
                let (var_145: Union5) = var_3.mem_1
                match var_145 with
                | Union5Case0(var_146) ->
                    let (var_147: Env7) = var_146.mem_0
                    let (var_148: Union8) = var_147.mem_0
                    let (var_149: Union9) = var_147.mem_1
                    let (var_150: int32) =
                        match var_99 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_151: int32) =
                        match var_148 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_152: bool) = (var_150 < var_151)
                    let (var_155: int32) =
                        if var_152 then
                            -1
                        else
                            let (var_153: bool) = (var_150 = var_151)
                            if var_153 then
                                0
                            else
                                1
                    let (var_156: bool) = (var_155 = 0)
                    if var_156 then
                        (var_142 + 1L)
                    else
                        var_142
                | Union5Case1 ->
                    var_142
            else
                var_142
        let (var_161: int64) = var_0.mem_2
        let (var_162: bool) = (var_161 > var_125)
        let (var_163: int64) =
            if var_162 then
                var_125
            else
                var_161
        let (var_164: int64) = (var_161 - var_163)
        var_0.mem_2 <- var_164
        let (var_165: int64) = var_3.mem_2
        let (var_166: bool) = (var_165 > var_125)
        let (var_167: int64) =
            if var_166 then
                var_125
            else
                var_165
        let (var_168: int64) = (var_165 - var_167)
        var_3.mem_2 <- var_168
        let (var_169: int64) = (var_125 % var_160)
        let (var_170: bool) = (var_169 <> 0L)
        let (var_171: int64) = (var_125 / var_160)
        let (var_172: string) = System.String.Format("Pot size is {0}",var_125)
        let (var_173: string) = System.String.Format("{0}",var_172)
        System.Console.WriteLine(var_173)
        let (var_174: int64) = var_0.mem_2
        let (var_175: bool) = (var_174 > 0L)
        let (var_197: int64) =
            if var_175 then
                let (var_176: Union5) = var_0.mem_1
                match var_176 with
                | Union5Case0(var_177) ->
                    let (var_178: Env7) = var_177.mem_0
                    let (var_179: Union8) = var_178.mem_0
                    let (var_180: Union9) = var_178.mem_1
                    let (var_181: int32) =
                        match var_99 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_182: int32) =
                        match var_179 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_183: bool) = (var_181 < var_182)
                    let (var_186: int32) =
                        if var_183 then
                            -1
                        else
                            let (var_184: bool) = (var_181 = var_182)
                            if var_184 then
                                0
                            else
                                1
                    let (var_187: bool) = (var_186 = 0)
                    if var_187 then
                        let (var_190: bool) =
                            if var_170 then
                                let (var_188: int64) = (var_160 - 1L)
                                (var_188 <> 0L)
                            else
                                false
                        let (var_191: int64) =
                            if var_190 then
                                1L
                            else
                                0L
                        let (var_192: int64) = (var_171 + var_191)
                        let (var_193: int64) = var_0.mem_0
                        let (var_194: int64) = (var_193 + var_192)
                        var_0.mem_0 <- var_194
                        1L
                    else
                        0L
                | Union5Case1 ->
                    0L
            else
                0L
        let (var_198: int64) = var_3.mem_2
        let (var_199: bool) = (var_198 > 0L)
        let (var_222: int64) =
            if var_199 then
                let (var_200: Union5) = var_3.mem_1
                match var_200 with
                | Union5Case0(var_201) ->
                    let (var_202: Env7) = var_201.mem_0
                    let (var_203: Union8) = var_202.mem_0
                    let (var_204: Union9) = var_202.mem_1
                    let (var_205: int32) =
                        match var_99 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_206: int32) =
                        match var_203 with
                        | Union8Case0 ->
                            12
                        | Union8Case1 ->
                            6
                        | Union8Case2 ->
                            3
                        | Union8Case3 ->
                            2
                        | Union8Case4 ->
                            9
                        | Union8Case5 ->
                            11
                        | Union8Case6 ->
                            7
                        | Union8Case7 ->
                            10
                        | Union8Case8 ->
                            5
                        | Union8Case9 ->
                            4
                        | Union8Case10 ->
                            8
                        | Union8Case11 ->
                            1
                        | Union8Case12 ->
                            0
                    let (var_207: bool) = (var_205 < var_206)
                    let (var_210: int32) =
                        if var_207 then
                            -1
                        else
                            let (var_208: bool) = (var_205 = var_206)
                            if var_208 then
                                0
                            else
                                1
                    let (var_211: bool) = (var_210 = 0)
                    if var_211 then
                        let (var_214: bool) =
                            if var_170 then
                                let (var_212: int64) = (var_160 - 1L)
                                (var_212 <> var_197)
                            else
                                false
                        let (var_215: int64) =
                            if var_214 then
                                1L
                            else
                                0L
                        let (var_216: int64) = (var_171 + var_215)
                        let (var_217: int64) = var_3.mem_0
                        let (var_218: int64) = (var_217 + var_216)
                        var_3.mem_0 <- var_218
                        (var_197 + 1L)
                    else
                        var_197
                | Union5Case1 ->
                    var_197
            else
                var_197
        method_8((var_0: EnvHeapMutable6), (var_1: string), (var_2: EnvStack3), (var_3: EnvHeapMutable6), (var_4: string))
    | Union5Case1 ->
        System.Console.WriteLine("The hand is none.")
and method_2((var_0: EnvStack0), (var_1: EnvStack2), (var_2: EnvStack1), (var_3: (Env7 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 51L)
    if var_5 then
        let (var_6: int32) = (int32 var_4)
        let (var_7: System.Random) = var_0.mem_0
        let (var_8: int32) = var_7.Next(var_6, 52)
        let (var_9: Env7) = var_3.[int32 var_4]
        let (var_10: Union8) = var_9.mem_0
        let (var_11: Union9) = var_9.mem_1
        let (var_12: Env7) = var_3.[int32 var_8]
        var_3.[int32 var_4] <- var_12
        var_3.[int32 var_8] <- (Env7(var_10, var_11))
        let (var_13: int64) = (var_4 + 1L)
        method_2((var_0: EnvStack0), (var_1: EnvStack2), (var_2: EnvStack1), (var_3: (Env7 [])), (var_13: int64))
    else
        ()
and method_5((var_0: int64), (var_1: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string)): unit =
    let (var_9: bool) = (var_1 > 1L)
    let (var_11: bool) =
        if var_9 then
            (var_2 < var_1)
        else
            false
    if var_11 then
        let (var_12: int64) = var_4.mem_0
        let (var_13: bool) = (var_12 > 0L)
        let (var_18: bool) =
            if var_13 then
                let (var_14: Union5) = var_4.mem_1
                match var_14 with
                | Union5Case0(var_15) ->
                    let (var_16: Env7) = var_15.mem_0
                    true
                | Union5Case1 ->
                    false
            else
                false
        if var_18 then
            let (var_19: int64) = var_4.mem_0
            let (var_20: int64) = var_4.mem_2
            let (var_21: Union5) = var_4.mem_1
            let (var_22: int64) = var_7.mem_0
            let (var_23: int64) = var_7.mem_2
            let (var_24: EnvStack0) = var_6.mem_0
            let (var_25: EnvStack2) = var_6.mem_1
            let (var_26: EnvStack1) = var_6.mem_2
            let (var_27: System.Random) = var_24.mem_0
            let (var_28: int32) = var_27.Next(0, 5)
            let (var_29: bool) = (var_28 = 0)
            if var_29 then
                let (var_30: Union5) = Union5Case1
                var_4.mem_1 <- var_30
                let (var_31: string) = System.String.Format("{0} folds.",var_5)
                let (var_32: string) = System.String.Format("{0}",var_31)
                System.Console.WriteLine(var_32)
                let (var_33: int64) = (var_1 - 1L)
                method_6((var_0: int64), (var_33: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
            else
                let (var_34: bool) = (var_28 = 1)
                if var_34 then
                    let (var_35: int64) = var_4.mem_0
                    let (var_36: int64) = var_4.mem_2
                    let (var_37: int64) = (var_0 - var_36)
                    let (var_38: bool) = (var_35 > var_37)
                    let (var_39: int64) =
                        if var_38 then
                            var_37
                        else
                            var_35
                    let (var_40: int64) = (var_35 - var_39)
                    var_4.mem_0 <- var_40
                    let (var_41: int64) = (var_36 + var_39)
                    var_4.mem_2 <- var_41
                    let (var_42: int64) = var_4.mem_0
                    let (var_43: bool) = (var_42 = 0L)
                    if var_43 then
                        let (var_44: string) = System.String.Format("{0} calls and is all-in!",var_5)
                        let (var_45: string) = System.String.Format("{0}",var_44)
                        System.Console.WriteLine(var_45)
                        let (var_46: int64) = (var_1 - 1L)
                        method_6((var_0: int64), (var_46: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
                    else
                        let (var_47: string) = System.String.Format("{0} calls.",var_5)
                        let (var_48: string) = System.String.Format("{0}",var_47)
                        System.Console.WriteLine(var_48)
                        let (var_49: int64) = (var_2 + 1L)
                        method_6((var_0: int64), (var_1: int64), (var_49: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
                else
                    let (var_50: int64) = var_4.mem_2
                    let (var_51: int64) = (var_0 - var_50)
                    let (var_52: int64) = (var_0 + var_51)
                    let (var_53: int64) = var_4.mem_0
                    let (var_54: int64) = var_4.mem_2
                    let (var_55: int64) = (var_52 - var_54)
                    let (var_56: bool) = (var_53 > var_55)
                    let (var_57: int64) =
                        if var_56 then
                            var_55
                        else
                            var_53
                    let (var_58: int64) = (var_53 - var_57)
                    var_4.mem_0 <- var_58
                    let (var_59: int64) = (var_54 + var_57)
                    var_4.mem_2 <- var_59
                    let (var_60: bool) = (var_0 > var_59)
                    let (var_61: int64) =
                        if var_60 then
                            var_0
                        else
                            var_59
                    let (var_62: int64) = var_4.mem_0
                    let (var_63: bool) = (var_62 = 0L)
                    if var_63 then
                        let (var_64: string) = System.String.Format("{0} raises to {1} and is all-in!",var_5,var_61)
                        let (var_65: string) = System.String.Format("{0}",var_64)
                        System.Console.WriteLine(var_65)
                        let (var_66: int64) = 0L
                        let (var_67: int64) = (var_1 - 1L)
                        method_6((var_61: int64), (var_67: int64), (var_66: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
                    else
                        let (var_68: string) = System.String.Format("{0} raises to {1}.",var_5,var_61)
                        let (var_69: string) = System.String.Format("{0}",var_68)
                        System.Console.WriteLine(var_69)
                        let (var_70: int64) = 0L
                        method_6((var_61: int64), (var_1: int64), (var_70: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
        else
            method_6((var_0: int64), (var_1: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
    else
        ()
and method_6((var_0: int64), (var_1: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string)): unit =
    let (var_9: bool) = (var_1 > 1L)
    let (var_11: bool) =
        if var_9 then
            (var_2 < var_1)
        else
            false
    if var_11 then
        let (var_12: int64) = var_7.mem_0
        let (var_13: bool) = (var_12 > 0L)
        let (var_18: bool) =
            if var_13 then
                let (var_14: Union5) = var_7.mem_1
                match var_14 with
                | Union5Case0(var_15) ->
                    let (var_16: Env7) = var_15.mem_0
                    true
                | Union5Case1 ->
                    false
            else
                false
        if var_18 then
            let (var_19: int64) = var_4.mem_0
            let (var_20: int64) = var_4.mem_2
            let (var_21: int64) = var_7.mem_0
            let (var_22: int64) = var_7.mem_2
            let (var_23: Union5) = var_7.mem_1
            let (var_24: EnvStack0) = var_6.mem_0
            let (var_25: EnvStack2) = var_6.mem_1
            let (var_26: EnvStack1) = var_6.mem_2
            let (var_27: System.Random) = var_24.mem_0
            let (var_28: int32) = var_27.Next(0, 5)
            let (var_29: bool) = (var_28 = 0)
            if var_29 then
                let (var_30: Union5) = Union5Case1
                var_7.mem_1 <- var_30
                let (var_31: string) = System.String.Format("{0} folds.",var_8)
                let (var_32: string) = System.String.Format("{0}",var_31)
                System.Console.WriteLine(var_32)
                let (var_33: int64) = (var_1 - 1L)
                method_7((var_0: int64), (var_33: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
            else
                let (var_34: bool) = (var_28 = 1)
                if var_34 then
                    let (var_35: int64) = var_7.mem_0
                    let (var_36: int64) = var_7.mem_2
                    let (var_37: int64) = (var_0 - var_36)
                    let (var_38: bool) = (var_35 > var_37)
                    let (var_39: int64) =
                        if var_38 then
                            var_37
                        else
                            var_35
                    let (var_40: int64) = (var_35 - var_39)
                    var_7.mem_0 <- var_40
                    let (var_41: int64) = (var_36 + var_39)
                    var_7.mem_2 <- var_41
                    let (var_42: int64) = var_7.mem_0
                    let (var_43: bool) = (var_42 = 0L)
                    if var_43 then
                        let (var_44: string) = System.String.Format("{0} calls and is all-in!",var_8)
                        let (var_45: string) = System.String.Format("{0}",var_44)
                        System.Console.WriteLine(var_45)
                        let (var_46: int64) = (var_1 - 1L)
                        method_7((var_0: int64), (var_46: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
                    else
                        let (var_47: string) = System.String.Format("{0} calls.",var_8)
                        let (var_48: string) = System.String.Format("{0}",var_47)
                        System.Console.WriteLine(var_48)
                        let (var_49: int64) = (var_2 + 1L)
                        method_7((var_0: int64), (var_1: int64), (var_49: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
                else
                    let (var_50: int64) = var_7.mem_2
                    let (var_51: int64) = (var_0 - var_50)
                    let (var_52: int64) = (var_0 + var_51)
                    let (var_53: int64) = var_7.mem_0
                    let (var_54: int64) = var_7.mem_2
                    let (var_55: int64) = (var_52 - var_54)
                    let (var_56: bool) = (var_53 > var_55)
                    let (var_57: int64) =
                        if var_56 then
                            var_55
                        else
                            var_53
                    let (var_58: int64) = (var_53 - var_57)
                    var_7.mem_0 <- var_58
                    let (var_59: int64) = (var_54 + var_57)
                    var_7.mem_2 <- var_59
                    let (var_60: bool) = (var_0 > var_59)
                    let (var_61: int64) =
                        if var_60 then
                            var_0
                        else
                            var_59
                    let (var_62: int64) = var_7.mem_0
                    let (var_63: bool) = (var_62 = 0L)
                    if var_63 then
                        let (var_64: string) = System.String.Format("{0} raises to {1} and is all-in!",var_8,var_61)
                        let (var_65: string) = System.String.Format("{0}",var_64)
                        System.Console.WriteLine(var_65)
                        let (var_66: int64) = 0L
                        let (var_67: int64) = (var_1 - 1L)
                        method_7((var_61: int64), (var_67: int64), (var_66: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
                    else
                        let (var_68: string) = System.String.Format("{0} raises to {1}.",var_8,var_61)
                        let (var_69: string) = System.String.Format("{0}",var_68)
                        System.Console.WriteLine(var_69)
                        let (var_70: int64) = 0L
                        method_7((var_61: int64), (var_1: int64), (var_70: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
        else
            method_7((var_0: int64), (var_1: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
    else
        ()
and method_7((var_0: int64), (var_1: int64), (var_2: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string)): unit =
    let (var_9: int64) = 0L
    method_5((var_0: int64), (var_1: int64), (var_9: int64), (var_3: EnvHeapMutable10), (var_4: EnvHeapMutable6), (var_5: string), (var_6: EnvStack3), (var_7: EnvHeapMutable6), (var_8: string))
let (var_0: System.Random) = System.Random()
let (var_1: EnvStack0) = EnvStack0((var_0: System.Random))
let (var_2: EnvStack1) = EnvStack1((var_0: System.Random))
let (var_3: EnvStack2) = EnvStack2((var_0: System.Random))
let (var_4: EnvStack3) = EnvStack3((var_1: EnvStack0), (var_3: EnvStack2), (var_2: EnvStack1))
let (var_5: EnvStack4) = EnvStack4((var_4: EnvStack3))
let (var_6: EnvStack3) = var_5.mem_0
let (var_7: string) = "One"
let (var_8: string) = "Two"
let (var_9: int64) = 5L
let (var_10: Union5) = Union5Case1
let (var_11: int64) = 0L
let (var_12: EnvHeapMutable6) = ({mem_0 = (var_9: int64); mem_1 = (var_10: Union5); mem_2 = (var_11: int64)} : EnvHeapMutable6)
let (var_13: int64) = 5L
let (var_14: Union5) = Union5Case1
let (var_15: int64) = 0L
let (var_16: EnvHeapMutable6) = ({mem_0 = (var_13: int64); mem_1 = (var_14: Union5); mem_2 = (var_15: int64)} : EnvHeapMutable6)
let (var_18: (Env7 [])) = [|(Env7(Union8Case12, Union9Case3)); (Env7(Union8Case12, Union9Case0)); (Env7(Union8Case12, Union9Case2)); (Env7(Union8Case12, Union9Case1)); (Env7(Union8Case11, Union9Case3)); (Env7(Union8Case11, Union9Case0)); (Env7(Union8Case11, Union9Case2)); (Env7(Union8Case11, Union9Case1)); (Env7(Union8Case3, Union9Case3)); (Env7(Union8Case3, Union9Case0)); (Env7(Union8Case3, Union9Case2)); (Env7(Union8Case3, Union9Case1)); (Env7(Union8Case2, Union9Case3)); (Env7(Union8Case2, Union9Case0)); (Env7(Union8Case2, Union9Case2)); (Env7(Union8Case2, Union9Case1)); (Env7(Union8Case9, Union9Case3)); (Env7(Union8Case9, Union9Case0)); (Env7(Union8Case9, Union9Case2)); (Env7(Union8Case9, Union9Case1)); (Env7(Union8Case8, Union9Case3)); (Env7(Union8Case8, Union9Case0)); (Env7(Union8Case8, Union9Case2)); (Env7(Union8Case8, Union9Case1)); (Env7(Union8Case1, Union9Case3)); (Env7(Union8Case1, Union9Case0)); (Env7(Union8Case1, Union9Case2)); (Env7(Union8Case1, Union9Case1)); (Env7(Union8Case6, Union9Case3)); (Env7(Union8Case6, Union9Case0)); (Env7(Union8Case6, Union9Case2)); (Env7(Union8Case6, Union9Case1)); (Env7(Union8Case10, Union9Case3)); (Env7(Union8Case10, Union9Case0)); (Env7(Union8Case10, Union9Case2)); (Env7(Union8Case10, Union9Case1)); (Env7(Union8Case4, Union9Case3)); (Env7(Union8Case4, Union9Case0)); (Env7(Union8Case4, Union9Case2)); (Env7(Union8Case4, Union9Case1)); (Env7(Union8Case7, Union9Case3)); (Env7(Union8Case7, Union9Case0)); (Env7(Union8Case7, Union9Case2)); (Env7(Union8Case7, Union9Case1)); (Env7(Union8Case5, Union9Case3)); (Env7(Union8Case5, Union9Case0)); (Env7(Union8Case5, Union9Case2)); (Env7(Union8Case5, Union9Case1)); (Env7(Union8Case0, Union9Case3)); (Env7(Union8Case0, Union9Case0)); (Env7(Union8Case0, Union9Case2)); (Env7(Union8Case0, Union9Case1))|]: (Env7 [])
let (var_19: int64) = var_18.LongLength
let (var_20: bool) = (var_19 = 52L)
let (var_21: bool) = (var_20 = false)
if var_21 then
    (failwith "The number of cards in the deck must be 52.")
else
    ()
let (var_22: System.Random) = System.Random()
let (var_23: EnvStack0) = EnvStack0((var_22: System.Random))
let (var_24: EnvStack1) = EnvStack1((var_22: System.Random))
let (var_25: EnvStack2) = EnvStack2((var_22: System.Random))
// Making data.
let (var_26: int64) = 52L
let (var_27: EnvHeapMutable10) = ({mem_0 = (var_18: (Env7 [])); mem_1 = (var_26: int64); mem_2 = (var_23: EnvStack0); mem_3 = (var_25: EnvStack2); mem_4 = (var_24: EnvStack1)} : EnvHeapMutable10)
method_0((var_27: EnvHeapMutable10), (var_12: EnvHeapMutable6), (var_7: string), (var_6: EnvStack3), (var_16: EnvHeapMutable6), (var_8: string))

