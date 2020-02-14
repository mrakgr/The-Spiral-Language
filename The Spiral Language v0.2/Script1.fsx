type IntOrString = Int of int | String of string
let x = if y > 0 then Int 0 else String "nope"