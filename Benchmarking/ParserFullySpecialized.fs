module ParserFullySpecialized

type Tuple0 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    val mem_2: uint64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end

let example () =
    let rec method_0((var_0: uint64), (var_1: string), (var_2: int64)): Tuple0 =
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
                        method_0((var_17: uint64), (var_1: string), (var_8: int64))
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
            else
                method_1((var_0: uint64), (var_1: string), (var_2: int64))
        else
            method_1((var_0: uint64), (var_1: string), (var_2: int64))
    and method_1((var_0: uint64), (var_1: string), (var_2: int64)): Tuple0 =
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
                method_1((var_0: uint64), (var_1: string), (var_8: int64))
            else
                let (var_15: uint64) = 0UL
                let (var_18: bool) =
                    if var_3 then
                        let (var_16: int64) = (int64 var_1.Length)
                        (var_2 < var_16)
                    else
                        false
                if var_18 then
                    let (var_19: bool) = (var_7 >= '0')
                    let (var_21: bool) =
                        if var_19 then
                            (var_7 <= '9')
                        else
                            false
                    if var_21 then
                        let (var_22: bool) = (var_15 <= 1844674407370955161UL)
                        if var_22 then
                            let (var_23: uint64) = (var_15 * 10UL)
                            let (var_24: uint64) = System.Convert.ToUInt64(var_7)
                            let (var_25: uint64) = (var_23 + var_24)
                            let (var_26: uint64) = System.Convert.ToUInt64('0')
                            let (var_27: uint64) = (var_25 - var_26)
                            let (var_28: bool) = (var_15 < var_27)
                            if var_28 then
                                method_2((var_27: uint64), (var_0: uint64), (var_1: string), (var_8: int64))
                            else
                                (failwith "puint64")
                        else
                            (failwith "puint64")
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
        else
            let (var_39: uint64) = 0UL
            let (var_42: bool) =
                if var_3 then
                    let (var_40: int64) = (int64 var_1.Length)
                    (var_2 < var_40)
                else
                    false
            if var_42 then
                let (var_43: char) = var_1.[int32 var_2]
                let (var_44: int64) = (var_2 + 1L)
                let (var_45: bool) = (var_43 >= '0')
                let (var_47: bool) =
                    if var_45 then
                        (var_43 <= '9')
                    else
                        false
                if var_47 then
                    let (var_48: bool) = (var_39 <= 1844674407370955161UL)
                    if var_48 then
                        let (var_49: uint64) = (var_39 * 10UL)
                        let (var_50: uint64) = System.Convert.ToUInt64(var_43)
                        let (var_51: uint64) = (var_49 + var_50)
                        let (var_52: uint64) = System.Convert.ToUInt64('0')
                        let (var_53: uint64) = (var_51 - var_52)
                        let (var_54: bool) = (var_39 < var_53)
                        if var_54 then
                            method_2((var_53: uint64), (var_0: uint64), (var_1: string), (var_44: int64))
                        else
                            (failwith "puint64")
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
            else
                (failwith "puint64")
    and method_2((var_0: uint64), (var_1: uint64), (var_2: string), (var_3: int64)): Tuple0 =
        let (var_4: bool) = (var_3 >= 0L)
        let (var_7: bool) =
            if var_4 then
                let (var_5: int64) = (int64 var_2.Length)
                (var_3 < var_5)
            else
                false
        if var_7 then
            let (var_8: char) = var_2.[int32 var_3]
            let (var_9: int64) = (var_3 + 1L)
            let (var_10: bool) = (var_8 >= '0')
            let (var_12: bool) =
                if var_10 then
                    (var_8 <= '9')
                else
                    false
            if var_12 then
                let (var_13: bool) = (var_0 <= 1844674407370955161UL)
                if var_13 then
                    let (var_14: uint64) = (var_0 * 10UL)
                    let (var_15: uint64) = System.Convert.ToUInt64(var_8)
                    let (var_16: uint64) = (var_14 + var_15)
                    let (var_17: uint64) = System.Convert.ToUInt64('0')
                    let (var_18: uint64) = (var_16 - var_17)
                    let (var_19: bool) = (var_0 < var_18)
                    if var_19 then
                        method_2((var_18: uint64), (var_1: uint64), (var_2: string), (var_9: int64))
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
            else
                method_3((var_0: uint64), (var_1: uint64), (var_2: string), (var_3: int64))
        else
            method_3((var_0: uint64), (var_1: uint64), (var_2: string), (var_3: int64))
    and method_3((var_0: uint64), (var_1: uint64), (var_2: string), (var_3: int64)): Tuple0 =
        let (var_4: bool) = (var_3 >= 0L)
        let (var_7: bool) =
            if var_4 then
                let (var_5: int64) = (int64 var_2.Length)
                (var_3 < var_5)
            else
                false
        if var_7 then
            let (var_8: char) = var_2.[int32 var_3]
            let (var_9: int64) = (var_3 + 1L)
            let (var_10: bool) = (var_8 = ' ')
            let (var_14: bool) =
                if var_10 then
                    true
                else
                    let (var_11: bool) = (var_8 = '\n')
                    if var_11 then
                        true
                    else
                        (var_8 = '\r')
            if var_14 then
                method_3((var_0: uint64), (var_1: uint64), (var_2: string), (var_9: int64))
            else
                let (var_16: uint64) = 0UL
                let (var_19: bool) =
                    if var_4 then
                        let (var_17: int64) = (int64 var_2.Length)
                        (var_3 < var_17)
                    else
                        false
                if var_19 then
                    let (var_20: bool) = (var_8 >= '0')
                    let (var_22: bool) =
                        if var_20 then
                            (var_8 <= '9')
                        else
                            false
                    if var_22 then
                        let (var_23: bool) = (var_16 <= 1844674407370955161UL)
                        if var_23 then
                            let (var_24: uint64) = (var_16 * 10UL)
                            let (var_25: uint64) = System.Convert.ToUInt64(var_8)
                            let (var_26: uint64) = (var_24 + var_25)
                            let (var_27: uint64) = System.Convert.ToUInt64('0')
                            let (var_28: uint64) = (var_26 - var_27)
                            let (var_29: bool) = (var_16 < var_28)
                            if var_29 then
                                method_4((var_28: uint64), (var_1: uint64), (var_0: uint64), (var_2: string), (var_9: int64))
                            else
                                (failwith "puint64")
                        else
                            (failwith "puint64")
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
        else
            let (var_40: uint64) = 0UL
            let (var_43: bool) =
                if var_4 then
                    let (var_41: int64) = (int64 var_2.Length)
                    (var_3 < var_41)
                else
                    false
            if var_43 then
                let (var_44: char) = var_2.[int32 var_3]
                let (var_45: int64) = (var_3 + 1L)
                let (var_46: bool) = (var_44 >= '0')
                let (var_48: bool) =
                    if var_46 then
                        (var_44 <= '9')
                    else
                        false
                if var_48 then
                    let (var_49: bool) = (var_40 <= 1844674407370955161UL)
                    if var_49 then
                        let (var_50: uint64) = (var_40 * 10UL)
                        let (var_51: uint64) = System.Convert.ToUInt64(var_44)
                        let (var_52: uint64) = (var_50 + var_51)
                        let (var_53: uint64) = System.Convert.ToUInt64('0')
                        let (var_54: uint64) = (var_52 - var_53)
                        let (var_55: bool) = (var_40 < var_54)
                        if var_55 then
                            method_4((var_54: uint64), (var_1: uint64), (var_0: uint64), (var_2: string), (var_45: int64))
                        else
                            (failwith "puint64")
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
            else
                (failwith "puint64")
    and method_4((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: string), (var_4: int64)): Tuple0 =
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
                        method_4((var_19: uint64), (var_1: uint64), (var_2: uint64), (var_3: string), (var_10: int64))
                    else
                        (failwith "puint64")
                else
                    (failwith "puint64")
            else
                method_5((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: string), (var_4: int64))
        else
            method_5((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: string), (var_4: int64))
    and method_5((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: string), (var_4: int64)): Tuple0 =
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
                method_5((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: string), (var_10: int64))
            else
                Tuple0(var_1, var_2, var_0)
        else
            Tuple0(var_1, var_2, var_0)
    let (var_0: string) = "123 456 789"
    let (var_1: int64) = 0L
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
                    method_0((var_17: uint64), (var_0: string), (var_8: int64))
                else
                    (failwith "puint64")
            else
                (failwith "puint64")
        else
            (failwith "puint64")
    else
        (failwith "puint64")