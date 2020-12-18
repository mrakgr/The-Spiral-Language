type T =
    | A of int32
    | B of float

let a = B 1.0
let caseInfo,fields = Reflection.FSharpValue.GetUnionFields(a,typeof<T>)
caseInfo.Tag