type [<Struct>] US0 =
    | US0_0
    | US0_1
    | US0_2
let v0 : int32 = 1
let v1 : string = "qwe"
let v2 : int32 = 2
let v3 : string = "asd"
let v4 : bool = v0 < v2
let v5 : US0 =
    if v4 then
        US0_2
    else
        let v5 : bool = v0 > v2
        if v5 then
            US0_1
        else
            US0_0
let v6 : int32 = 1
let v7 : float = 2.000000
let v8 : bool = v6 < 3
let v9 : US0 =
    if v8 then
        US0_2
    else
        let v9 : bool = v6 > 3
        if v9 then
            US0_1
        else
            US0_0
let v10 : bool =
    match v9 with
    | US0_0 -> (* eQ *)
        true
    | US0_1 -> (* gT *)
        false
    | US0_2 -> (* lT *)
        false
let v11 : US0 =
    if v10 then
        let v11 : bool = v7 < 4.000000
        if v11 then
            US0_2
        else
            let v12 : bool = v7 > 4.000000
            if v12 then
                US0_1
            else
                US0_0
    else
        v9
()
