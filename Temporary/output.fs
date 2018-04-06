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
    let (var_42: int64) = 2L
    let (var_43: int64) = var_1.mem_0
    let (var_44: bool) = (var_43 > 0L)
    let (var_49: bool) =
        if var_44 then
            let (var_45: Union5) = var_1.mem_1
            match var_45 with
            | Union5Case0(var_46) ->
                let (var_47: Env7) = var_46.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_53: int64) =
        if var_49 then
            let (var_50: int64) = var_1.mem_2
            let (var_51: bool) = (0L > var_50)
            if var_51 then
                0L
            else
                var_50
        else
            0L
    let (var_54: int64) = var_4.mem_0
    let (var_55: bool) = (var_54 > 0L)
    let (var_60: bool) =
        if var_55 then
            let (var_56: Union5) = var_4.mem_1
            match var_56 with
            | Union5Case0(var_57) ->
                let (var_58: Env7) = var_57.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_64: int64) =
        if var_60 then
            let (var_61: int64) = var_4.mem_2
            let (var_62: bool) = (var_53 > var_61)
            if var_62 then
                var_53
            else
                var_61
        else
            var_53
    let (var_65: int64) = var_1.mem_0
    let (var_66: bool) = (var_65 > 0L)
    let (var_71: bool) =
        if var_66 then
            let (var_67: Union5) = var_1.mem_1
            match var_67 with
            | Union5Case0(var_68) ->
                let (var_69: Env7) = var_68.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_72: int64) =
        if var_71 then
            1L
        else
            0L
    let (var_73: int64) = var_4.mem_0
    let (var_74: bool) = (var_73 > 0L)
    let (var_79: bool) =
        if var_74 then
            let (var_75: Union5) = var_4.mem_1
            match var_75 with
            | Union5Case0(var_76) ->
                let (var_77: Env7) = var_76.mem_0
                true
            | Union5Case1 ->
                false
        else
            false
    let (var_81: int64) =
        if var_79 then
            (var_72 + 1L)
        else
            var_72
    let (var_82: int64) = 0L
    method_4((var_64: int64), (var_42: int64), (var_81: int64), (var_82: int64), (var_0: EnvHeapMutable10), (var_1: EnvHeapMutable6), (var_2: string), (var_3: EnvStack3), (var_4: EnvHeapMutable6), (var_5: string))
    System.Console.WriteLine("Showdown:")
    let (var_83: int64) = var_1.mem_2
    let (var_84: bool) = (var_83 > 0L)
    if var_84 then
        let (var_85: Union5) = var_1.mem_1
        match var_85 with
        | Union5Case0(var_86) ->
            let (var_87: Env7) = var_86.mem_0
            let (var_88: Union8) = var_87.mem_0
            let (var_89: Union9) = var_87.mem_1
            let (var_103: string) =
                match var_88 with
                | Union8Case0 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Ace-Clubs"
                    | Union9Case1 ->
                        "Ace-Diamonds"
                    | Union9Case2 ->
                        "Ace-Hearts"
                    | Union9Case3 ->
                        "Ace-Spades"
                | Union8Case1 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Eight-Clubs"
                    | Union9Case1 ->
                        "Eight-Diamonds"
                    | Union9Case2 ->
                        "Eight-Hearts"
                    | Union9Case3 ->
                        "Eight-Spades"
                | Union8Case2 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Five-Clubs"
                    | Union9Case1 ->
                        "Five-Diamonds"
                    | Union9Case2 ->
                        "Five-Hearts"
                    | Union9Case3 ->
                        "Five-Spades"
                | Union8Case3 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Four-Clubs"
                    | Union9Case1 ->
                        "Four-Diamonds"
                    | Union9Case2 ->
                        "Four-Hearts"
                    | Union9Case3 ->
                        "Four-Spades"
                | Union8Case4 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Jack-Clubs"
                    | Union9Case1 ->
                        "Jack-Diamonds"
                    | Union9Case2 ->
                        "Jack-Hearts"
                    | Union9Case3 ->
                        "Jack-Spades"
                | Union8Case5 ->
                    match var_89 with
                    | Union9Case0 ->
                        "King-Clubs"
                    | Union9Case1 ->
                        "King-Diamonds"
                    | Union9Case2 ->
                        "King-Hearts"
                    | Union9Case3 ->
                        "King-Spades"
                | Union8Case6 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Nine-Clubs"
                    | Union9Case1 ->
                        "Nine-Diamonds"
                    | Union9Case2 ->
                        "Nine-Hearts"
                    | Union9Case3 ->
                        "Nine-Spades"
                | Union8Case7 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Queen-Clubs"
                    | Union9Case1 ->
                        "Queen-Diamonds"
                    | Union9Case2 ->
                        "Queen-Hearts"
                    | Union9Case3 ->
                        "Queen-Spades"
                | Union8Case8 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Seven-Clubs"
                    | Union9Case1 ->
                        "Seven-Diamonds"
                    | Union9Case2 ->
                        "Seven-Hearts"
                    | Union9Case3 ->
                        "Seven-Spades"
                | Union8Case9 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Six-Clubs"
                    | Union9Case1 ->
                        "Six-Diamonds"
                    | Union9Case2 ->
                        "Six-Hearts"
                    | Union9Case3 ->
                        "Six-Spades"
                | Union8Case10 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Ten-Clubs"
                    | Union9Case1 ->
                        "Ten-Diamonds"
                    | Union9Case2 ->
                        "Ten-Hearts"
                    | Union9Case3 ->
                        "Ten-Spades"
                | Union8Case11 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Three-Clubs"
                    | Union9Case1 ->
                        "Three-Diamonds"
                    | Union9Case2 ->
                        "Three-Hearts"
                    | Union9Case3 ->
                        "Three-Spades"
                | Union8Case12 ->
                    match var_89 with
                    | Union9Case0 ->
                        "Two-Clubs"
                    | Union9Case1 ->
                        "Two-Diamonds"
                    | Union9Case2 ->
                        "Two-Hearts"
                    | Union9Case3 ->
                        "Two-Spades"
            let (var_104: string) = System.String.Format("{0} shows {1}",var_2,var_103)
            let (var_105: string) = System.String.Format("{0}",var_104)
            System.Console.WriteLine(var_105)
        | Union5Case1 ->
            ()
    else
        ()
    let (var_106: int64) = var_4.mem_2
    let (var_107: bool) = (var_106 > 0L)
    if var_107 then
        let (var_108: Union5) = var_4.mem_1
        match var_108 with
        | Union5Case0(var_109) ->
            let (var_110: Env7) = var_109.mem_0
            let (var_111: Union8) = var_110.mem_0
            let (var_112: Union9) = var_110.mem_1
            let (var_126: string) =
                match var_111 with
                | Union8Case0 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Ace-Clubs"
                    | Union9Case1 ->
                        "Ace-Diamonds"
                    | Union9Case2 ->
                        "Ace-Hearts"
                    | Union9Case3 ->
                        "Ace-Spades"
                | Union8Case1 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Eight-Clubs"
                    | Union9Case1 ->
                        "Eight-Diamonds"
                    | Union9Case2 ->
                        "Eight-Hearts"
                    | Union9Case3 ->
                        "Eight-Spades"
                | Union8Case2 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Five-Clubs"
                    | Union9Case1 ->
                        "Five-Diamonds"
                    | Union9Case2 ->
                        "Five-Hearts"
                    | Union9Case3 ->
                        "Five-Spades"
                | Union8Case3 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Four-Clubs"
                    | Union9Case1 ->
                        "Four-Diamonds"
                    | Union9Case2 ->
                        "Four-Hearts"
                    | Union9Case3 ->
                        "Four-Spades"
                | Union8Case4 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Jack-Clubs"
                    | Union9Case1 ->
                        "Jack-Diamonds"
                    | Union9Case2 ->
                        "Jack-Hearts"
                    | Union9Case3 ->
                        "Jack-Spades"
                | Union8Case5 ->
                    match var_112 with
                    | Union9Case0 ->
                        "King-Clubs"
                    | Union9Case1 ->
                        "King-Diamonds"
                    | Union9Case2 ->
                        "King-Hearts"
                    | Union9Case3 ->
                        "King-Spades"
                | Union8Case6 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Nine-Clubs"
                    | Union9Case1 ->
                        "Nine-Diamonds"
                    | Union9Case2 ->
                        "Nine-Hearts"
                    | Union9Case3 ->
                        "Nine-Spades"
                | Union8Case7 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Queen-Clubs"
                    | Union9Case1 ->
                        "Queen-Diamonds"
                    | Union9Case2 ->
                        "Queen-Hearts"
                    | Union9Case3 ->
                        "Queen-Spades"
                | Union8Case8 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Seven-Clubs"
                    | Union9Case1 ->
                        "Seven-Diamonds"
                    | Union9Case2 ->
                        "Seven-Hearts"
                    | Union9Case3 ->
                        "Seven-Spades"
                | Union8Case9 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Six-Clubs"
                    | Union9Case1 ->
                        "Six-Diamonds"
                    | Union9Case2 ->
                        "Six-Hearts"
                    | Union9Case3 ->
                        "Six-Spades"
                | Union8Case10 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Ten-Clubs"
                    | Union9Case1 ->
                        "Ten-Diamonds"
                    | Union9Case2 ->
                        "Ten-Hearts"
                    | Union9Case3 ->
                        "Ten-Spades"
                | Union8Case11 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Three-Clubs"
                    | Union9Case1 ->
                        "Three-Diamonds"
                    | Union9Case2 ->
                        "Three-Hearts"
                    | Union9Case3 ->
                        "Three-Spades"
                | Union8Case12 ->
                    match var_112 with
                    | Union9Case0 ->
                        "Two-Clubs"
                    | Union9Case1 ->
                        "Two-Diamonds"
                    | Union9Case2 ->
                        "Two-Hearts"
                    | Union9Case3 ->
                        "Two-Spades"
            let (var_127: string) = System.String.Format("{0} shows {1}",var_5,var_126)
            let (var_128: string) = System.String.Format("{0}",var_127)
            System.Console.WriteLine(var_128)
        | Union5Case1 ->
            ()
    else
        ()
    let (var_129: int64) = var_1.mem_0
    let (var_130: int64) = var_1.mem_2
    let (var_131: int64) = (var_129 + var_130)
    let (var_132: int64) = var_4.mem_0
    let (var_133: int64) = var_4.mem_2
    let (var_134: int64) = (var_132 + var_133)
    method_7((var_1: EnvHeapMutable6), (var_2: string), (var_3: EnvStack3), (var_4: EnvHeapMutable6), (var_5: string))
    let (var_135: int64) = var_1.mem_0
    let (var_136: bool) = (var_131 < var_135)
    if var_136 then
        let (var_137: int64) = (var_135 - var_131)
        let (var_138: string) = System.String.Format("{0} wins {1} chips.",var_2,var_137)
        let (var_139: string) = System.String.Format("{0}",var_138)
        System.Console.WriteLine(var_139)
    else
        let (var_140: bool) = (var_131 > var_135)
        if var_140 then
            let (var_141: int64) = (var_131 - var_135)
            let (var_142: string) = System.String.Format("{0} loses {1} chips.",var_2,var_141)
            let (var_143: string) = System.String.Format("{0}",var_142)
            System.Console.WriteLine(var_143)
        else
            ()
    let (var_144: int64) = var_4.mem_0
    let (var_145: bool) = (var_134 < var_144)
    if var_145 then
        let (var_146: int64) = (var_144 - var_134)
        let (var_147: string) = System.String.Format("{0} wins {1} chips.",var_5,var_146)
        let (var_148: string) = System.String.Format("{0}",var_147)
        System.Console.WriteLine(var_148)
    else
        let (var_149: bool) = (var_134 > var_144)
        if var_149 then
            let (var_150: int64) = (var_134 - var_144)
            let (var_151: string) = System.String.Format("{0} loses {1} chips.",var_5,var_150)
            let (var_152: string) = System.String.Format("{0}",var_151)
            System.Console.WriteLine(var_152)
        else
            ()
    let (var_153: int64) = var_1.mem_0
    let (var_154: bool) = (var_153 > 0L)
    let (var_155: int64) =
        if var_154 then
            1L
        else
            0L
    let (var_156: int64) = var_4.mem_0
    let (var_157: bool) = (var_156 > 0L)
    let (var_159: int64) =
        if var_157 then
            (var_155 + 1L)
        else
            var_155
    let (var_160: bool) = (var_159 = 1L)
    if var_160 then
        System.Console.WriteLine("The game is over.")
        let (var_161: int64) = var_1.mem_0
        let (var_162: bool) = (var_161 > 0L)
        if var_162 then
            let (var_163: string) = System.String.Format("{0} wins with {1} chips!",var_2,var_161)
            let (var_164: string) = System.String.Format("{0}",var_163)
            System.Console.WriteLine(var_164)
        else
            ()
        let (var_165: int64) = var_4.mem_0
        let (var_166: bool) = (var_165 > 0L)
        if var_166 then
            let (var_167: string) = System.String.Format("{0} wins with {1} chips!",var_5,var_165)
            let (var_168: string) = System.String.Format("{0}",var_167)
            System.Console.WriteLine(var_168)
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
and method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string)): unit =
    method_5((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
and method_7((var_0: EnvHeapMutable6), (var_1: string), (var_2: EnvStack3), (var_3: EnvHeapMutable6), (var_4: string)): unit =
    let (var_5: int64) = var_0.mem_2
    let (var_6: bool) = (var_5 > 0L)
    let (var_7: int64) = var_3.mem_2
    let (var_8: bool) = (var_7 > 0L)
    let (var_10: Union5) =
        if var_6 then
            var_0.mem_1
        else
            Union5Case1
    let (var_31: Union5) =
        if var_8 then
            match var_10 with
            | Union5Case0(var_11) ->
                let (var_12: Env7) = var_11.mem_0
                let (var_13: Union8) = var_12.mem_0
                let (var_14: Union9) = var_12.mem_1
                let (var_15: Union5) = var_3.mem_1
                match var_15 with
                | Union5Case0(var_16) ->
                    let (var_17: Env7) = var_16.mem_0
                    let (var_18: Union8) = var_17.mem_0
                    let (var_19: Union9) = var_17.mem_1
                    let (var_20: int32) =
                        match var_13 with
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
                    let (var_21: int32) =
                        match var_18 with
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
                    let (var_22: bool) = (var_20 < var_21)
                    let (var_25: int32) =
                        if var_22 then
                            -1
                        else
                            let (var_23: bool) = (var_20 = var_21)
                            if var_23 then
                                0
                            else
                                1
                    let (var_26: bool) = (var_25 = 1)
                    if var_26 then
                        (Union5Case0(Tuple11((Env7(var_13, var_14)))))
                    else
                        (Union5Case0(Tuple11((Env7(var_18, var_19)))))
                | Union5Case1 ->
                    (Union5Case0(Tuple11((Env7(var_13, var_14)))))
            | Union5Case1 ->
                var_3.mem_1
        else
            var_10
    match var_31 with
    | Union5Case0(var_32) ->
        let (var_33: Env7) = var_32.mem_0
        let (var_34: Union8) = var_33.mem_0
        let (var_35: Union9) = var_33.mem_1
        let (var_50: int64) =
            if var_6 then
                let (var_36: Union5) = var_0.mem_1
                match var_36 with
                | Union5Case0(var_37) ->
                    let (var_38: Env7) = var_37.mem_0
                    let (var_39: Union8) = var_38.mem_0
                    let (var_40: Union9) = var_38.mem_1
                    let (var_41: int32) =
                        match var_34 with
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
                    let (var_42: int32) =
                        match var_39 with
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
                    let (var_43: bool) = (var_41 < var_42)
                    let (var_46: int32) =
                        if var_43 then
                            -1
                        else
                            let (var_44: bool) = (var_41 = var_42)
                            if var_44 then
                                0
                            else
                                1
                    let (var_47: bool) = (var_46 = 0)
                    if var_47 then
                        1L
                    else
                        0L
                | Union5Case1 ->
                    0L
            else
                0L
        let (var_66: int64) =
            if var_8 then
                let (var_51: Union5) = var_3.mem_1
                match var_51 with
                | Union5Case0(var_52) ->
                    let (var_53: Env7) = var_52.mem_0
                    let (var_54: Union8) = var_53.mem_0
                    let (var_55: Union9) = var_53.mem_1
                    let (var_56: int32) =
                        match var_34 with
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
                    let (var_57: int32) =
                        match var_54 with
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
                    let (var_58: bool) = (var_56 < var_57)
                    let (var_61: int32) =
                        if var_58 then
                            -1
                        else
                            let (var_59: bool) = (var_56 = var_57)
                            if var_59 then
                                0
                            else
                                1
                    let (var_62: bool) = (var_61 = 0)
                    if var_62 then
                        (var_50 + 1L)
                    else
                        var_50
                | Union5Case1 ->
                    var_50
            else
                var_50
        let (var_67: int64) = System.Int64.MaxValue
        let (var_71: int64) =
            if var_6 then
                let (var_68: int64) = var_0.mem_2
                let (var_69: bool) = (var_67 > var_68)
                if var_69 then
                    var_68
                else
                    var_67
            else
                var_67
        let (var_75: int64) =
            if var_8 then
                let (var_72: int64) = var_3.mem_2
                let (var_73: bool) = (var_71 > var_72)
                if var_73 then
                    var_72
                else
                    var_71
            else
                var_71
        let (var_80: int64) =
            if var_6 then
                let (var_76: int64) = var_0.mem_2
                let (var_77: bool) = (var_76 > var_75)
                let (var_78: int64) =
                    if var_77 then
                        var_75
                    else
                        var_76
                let (var_79: int64) = (var_76 - var_78)
                var_0.mem_2 <- var_79
                var_78
            else
                0L
        let (var_86: int64) =
            if var_8 then
                let (var_81: int64) = var_3.mem_2
                let (var_82: bool) = (var_81 > var_75)
                let (var_83: int64) =
                    if var_82 then
                        var_75
                    else
                        var_81
                let (var_84: int64) = (var_81 - var_83)
                var_3.mem_2 <- var_84
                (var_80 + var_83)
            else
                var_80
        let (var_87: int64) = (var_86 % var_66)
        let (var_88: bool) = (var_87 <> 0L)
        let (var_89: int64) = (var_86 / var_66)
        let (var_111: int64) =
            if var_6 then
                let (var_90: Union5) = var_0.mem_1
                match var_90 with
                | Union5Case0(var_91) ->
                    let (var_92: Env7) = var_91.mem_0
                    let (var_93: Union8) = var_92.mem_0
                    let (var_94: Union9) = var_92.mem_1
                    let (var_95: int32) =
                        match var_34 with
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
                    let (var_96: int32) =
                        match var_93 with
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
                    let (var_97: bool) = (var_95 < var_96)
                    let (var_100: int32) =
                        if var_97 then
                            -1
                        else
                            let (var_98: bool) = (var_95 = var_96)
                            if var_98 then
                                0
                            else
                                1
                    let (var_101: bool) = (var_100 = 0)
                    if var_101 then
                        let (var_102: int64) = (var_66 - 1L)
                        let (var_104: bool) =
                            if var_88 then
                                (var_102 = 0L)
                            else
                                false
                        let (var_105: int64) =
                            if var_104 then
                                1L
                            else
                                0L
                        let (var_106: int64) = (var_89 + var_105)
                        let (var_107: int64) = var_0.mem_0
                        let (var_108: int64) = (var_107 + var_106)
                        var_0.mem_0 <- var_108
                        var_102
                    else
                        var_66
                | Union5Case1 ->
                    var_66
            else
                var_66
        let (var_133: int64) =
            if var_8 then
                let (var_112: Union5) = var_3.mem_1
                match var_112 with
                | Union5Case0(var_113) ->
                    let (var_114: Env7) = var_113.mem_0
                    let (var_115: Union8) = var_114.mem_0
                    let (var_116: Union9) = var_114.mem_1
                    let (var_117: int32) =
                        match var_34 with
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
                    let (var_118: int32) =
                        match var_115 with
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
                    let (var_119: bool) = (var_117 < var_118)
                    let (var_122: int32) =
                        if var_119 then
                            -1
                        else
                            let (var_120: bool) = (var_117 = var_118)
                            if var_120 then
                                0
                            else
                                1
                    let (var_123: bool) = (var_122 = 0)
                    if var_123 then
                        let (var_124: int64) = (var_111 - 1L)
                        let (var_126: bool) =
                            if var_88 then
                                (var_124 = 0L)
                            else
                                false
                        let (var_127: int64) =
                            if var_126 then
                                1L
                            else
                                0L
                        let (var_128: int64) = (var_89 + var_127)
                        let (var_129: int64) = var_3.mem_0
                        let (var_130: int64) = (var_129 + var_128)
                        var_3.mem_0 <- var_130
                        var_124
                    else
                        var_111
                | Union5Case1 ->
                    var_111
            else
                var_111
        method_7((var_0: EnvHeapMutable6), (var_1: string), (var_2: EnvStack3), (var_3: EnvHeapMutable6), (var_4: string))
    | Union5Case1 ->
        ()
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
and method_5((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string)): unit =
    let (var_10: bool) = (var_3 < var_2)
    if var_10 then
        let (var_11: int64) = var_5.mem_0
        let (var_12: bool) = (var_11 > 0L)
        let (var_17: bool) =
            if var_12 then
                let (var_13: Union5) = var_5.mem_1
                match var_13 with
                | Union5Case0(var_14) ->
                    let (var_15: Env7) = var_14.mem_0
                    true
                | Union5Case1 ->
                    false
            else
                false
        if var_17 then
            let (var_18: int64) = var_5.mem_0
            let (var_19: int64) = var_5.mem_2
            let (var_20: Union5) = var_5.mem_1
            let (var_21: int64) = var_8.mem_0
            let (var_22: int64) = var_8.mem_2
            let (var_23: EnvStack0) = var_7.mem_0
            let (var_24: EnvStack2) = var_7.mem_1
            let (var_25: EnvStack1) = var_7.mem_2
            let (var_26: System.Random) = var_23.mem_0
            let (var_27: int32) = var_26.Next(0, 5)
            let (var_28: bool) = (var_27 = 0)
            if var_28 then
                let (var_29: Union5) = Union5Case1
                var_5.mem_1 <- var_29
                let (var_30: string) = System.String.Format("{0} folds.",var_6)
                let (var_31: string) = System.String.Format("{0}",var_30)
                System.Console.WriteLine(var_31)
                let (var_32: int64) = (var_2 - 1L)
                method_6((var_0: int64), (var_1: int64), (var_32: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
            else
                let (var_33: bool) = (var_27 = 1)
                if var_33 then
                    let (var_34: int64) = var_5.mem_0
                    let (var_35: int64) = var_5.mem_2
                    let (var_36: int64) = (var_0 - var_35)
                    let (var_37: bool) = (var_34 > var_36)
                    let (var_38: int64) =
                        if var_37 then
                            var_36
                        else
                            var_34
                    let (var_39: int64) = (var_34 - var_38)
                    var_5.mem_0 <- var_39
                    let (var_40: int64) = (var_35 + var_38)
                    var_5.mem_2 <- var_40
                    let (var_41: int64) = var_5.mem_0
                    let (var_42: bool) = (var_41 = 0L)
                    if var_42 then
                        let (var_43: string) = System.String.Format("{0} calls and is all-in!",var_6)
                        let (var_44: string) = System.String.Format("{0}",var_43)
                        System.Console.WriteLine(var_44)
                        let (var_45: int64) = (var_2 - 1L)
                        method_6((var_0: int64), (var_1: int64), (var_45: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                    else
                        let (var_46: string) = System.String.Format("{0} calls.",var_6)
                        let (var_47: string) = System.String.Format("{0}",var_46)
                        System.Console.WriteLine(var_47)
                        let (var_48: int64) = (var_3 + 1L)
                        method_6((var_0: int64), (var_1: int64), (var_2: int64), (var_48: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                else
                    let (var_49: int64) = (var_0 + var_1)
                    let (var_50: int64) = var_5.mem_0
                    let (var_51: int64) = var_5.mem_2
                    let (var_52: int64) = (var_49 - var_51)
                    let (var_53: bool) = (var_50 > var_52)
                    let (var_54: int64) =
                        if var_53 then
                            var_52
                        else
                            var_50
                    let (var_55: int64) = (var_50 - var_54)
                    var_5.mem_0 <- var_55
                    let (var_56: int64) = (var_51 + var_54)
                    var_5.mem_2 <- var_56
                    let (var_57: int64) = (var_56 - var_0)
                    let (var_58: int64) = var_5.mem_0
                    let (var_59: bool) = (var_58 = 0L)
                    if var_59 then
                        let (var_60: string) = System.String.Format("{0} raises to {1} and is all-in!",var_6,var_56)
                        let (var_61: string) = System.String.Format("{0}",var_60)
                        System.Console.WriteLine(var_61)
                        let (var_62: int64) = (var_2 - 1L)
                        let (var_63: bool) = (var_56 < var_49)
                        if var_63 then
                            method_6((var_56: int64), (var_57: int64), (var_62: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                        else
                            let (var_64: int64) = 1L
                            method_6((var_56: int64), (var_57: int64), (var_62: int64), (var_64: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                    else
                        let (var_65: string) = System.String.Format("{0} raises to {1}.",var_6,var_56)
                        let (var_66: string) = System.String.Format("{0}",var_65)
                        System.Console.WriteLine(var_66)
                        let (var_67: bool) = (var_56 < var_49)
                        if var_67 then
                            method_6((var_56: int64), (var_57: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                        else
                            let (var_68: int64) = 1L
                            method_6((var_56: int64), (var_57: int64), (var_2: int64), (var_68: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
        else
            method_6((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
    else
        ()
and method_6((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string)): unit =
    let (var_10: bool) = (var_3 < var_2)
    if var_10 then
        let (var_11: int64) = var_8.mem_0
        let (var_12: bool) = (var_11 > 0L)
        let (var_17: bool) =
            if var_12 then
                let (var_13: Union5) = var_8.mem_1
                match var_13 with
                | Union5Case0(var_14) ->
                    let (var_15: Env7) = var_14.mem_0
                    true
                | Union5Case1 ->
                    false
            else
                false
        if var_17 then
            let (var_18: int64) = var_5.mem_0
            let (var_19: int64) = var_5.mem_2
            let (var_20: int64) = var_8.mem_0
            let (var_21: int64) = var_8.mem_2
            let (var_22: Union5) = var_8.mem_1
            let (var_23: EnvStack0) = var_7.mem_0
            let (var_24: EnvStack2) = var_7.mem_1
            let (var_25: EnvStack1) = var_7.mem_2
            let (var_26: System.Random) = var_23.mem_0
            let (var_27: int32) = var_26.Next(0, 5)
            let (var_28: bool) = (var_27 = 0)
            if var_28 then
                let (var_29: Union5) = Union5Case1
                var_8.mem_1 <- var_29
                let (var_30: string) = System.String.Format("{0} folds.",var_9)
                let (var_31: string) = System.String.Format("{0}",var_30)
                System.Console.WriteLine(var_31)
                let (var_32: int64) = (var_2 - 1L)
                method_4((var_0: int64), (var_1: int64), (var_32: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
            else
                let (var_33: bool) = (var_27 = 1)
                if var_33 then
                    let (var_34: int64) = var_8.mem_0
                    let (var_35: int64) = var_8.mem_2
                    let (var_36: int64) = (var_0 - var_35)
                    let (var_37: bool) = (var_34 > var_36)
                    let (var_38: int64) =
                        if var_37 then
                            var_36
                        else
                            var_34
                    let (var_39: int64) = (var_34 - var_38)
                    var_8.mem_0 <- var_39
                    let (var_40: int64) = (var_35 + var_38)
                    var_8.mem_2 <- var_40
                    let (var_41: int64) = var_8.mem_0
                    let (var_42: bool) = (var_41 = 0L)
                    if var_42 then
                        let (var_43: string) = System.String.Format("{0} calls and is all-in!",var_9)
                        let (var_44: string) = System.String.Format("{0}",var_43)
                        System.Console.WriteLine(var_44)
                        let (var_45: int64) = (var_2 - 1L)
                        method_4((var_0: int64), (var_1: int64), (var_45: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                    else
                        let (var_46: string) = System.String.Format("{0} calls.",var_9)
                        let (var_47: string) = System.String.Format("{0}",var_46)
                        System.Console.WriteLine(var_47)
                        let (var_48: int64) = (var_3 + 1L)
                        method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_48: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                else
                    let (var_49: int64) = (var_0 + var_1)
                    let (var_50: int64) = var_8.mem_0
                    let (var_51: int64) = var_8.mem_2
                    let (var_52: int64) = (var_49 - var_51)
                    let (var_53: bool) = (var_50 > var_52)
                    let (var_54: int64) =
                        if var_53 then
                            var_52
                        else
                            var_50
                    let (var_55: int64) = (var_50 - var_54)
                    var_8.mem_0 <- var_55
                    let (var_56: int64) = (var_51 + var_54)
                    var_8.mem_2 <- var_56
                    let (var_57: int64) = (var_56 - var_0)
                    let (var_58: int64) = var_8.mem_0
                    let (var_59: bool) = (var_58 = 0L)
                    if var_59 then
                        let (var_60: string) = System.String.Format("{0} raises to {1} and is all-in!",var_9,var_56)
                        let (var_61: string) = System.String.Format("{0}",var_60)
                        System.Console.WriteLine(var_61)
                        let (var_62: int64) = (var_2 - 1L)
                        let (var_63: bool) = (var_56 < var_49)
                        if var_63 then
                            method_4((var_56: int64), (var_57: int64), (var_62: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                        else
                            let (var_64: int64) = 1L
                            method_4((var_56: int64), (var_57: int64), (var_62: int64), (var_64: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                    else
                        let (var_65: string) = System.String.Format("{0} raises to {1}.",var_9,var_56)
                        let (var_66: string) = System.String.Format("{0}",var_65)
                        System.Console.WriteLine(var_66)
                        let (var_67: bool) = (var_56 < var_49)
                        if var_67 then
                            method_4((var_56: int64), (var_57: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
                        else
                            let (var_68: int64) = 1L
                            method_4((var_56: int64), (var_57: int64), (var_2: int64), (var_68: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
        else
            method_4((var_0: int64), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: EnvHeapMutable10), (var_5: EnvHeapMutable6), (var_6: string), (var_7: EnvStack3), (var_8: EnvHeapMutable6), (var_9: string))
    else
        ()
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
let (var_26: int64) = 52L
let (var_27: EnvHeapMutable10) = ({mem_0 = (var_18: (Env7 [])); mem_1 = (var_26: int64); mem_2 = (var_23: EnvStack0); mem_3 = (var_25: EnvStack2); mem_4 = (var_24: EnvStack1)} : EnvHeapMutable10)
method_0((var_27: EnvHeapMutable10), (var_12: EnvHeapMutable6), (var_7: string), (var_6: EnvStack3), (var_16: EnvHeapMutable6), (var_8: string))

