let v0 : bool = true
let v1 : bool = false
let v2 : bool = true
let v3 : bool = false
let v4 : bool = true
let v5 : bool = v0 && v1
if v5 then
    true
else
    let v6 : bool = v2 && v3
    v6 || v4
