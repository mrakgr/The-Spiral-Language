module SpiralExample.Main
let cuda_kernels = """

extern "C" {
    
}
"""

let (var_0: string) = "123456789"
let (var_1: int64) = (int64 var_0.Length)
let (var_2: bool) = (0L < var_1)
if var_2 then
    let (var_3: char) = var_0.[int32 0L]
    let (var_4: bool) = (var_3 >= '0')
    let (var_6: bool) =
        if var_4 then
            (var_3 <= '9')
        else
            false
    if var_6 then
        var_3
    else
        (failwith "digit")
else
    (failwith "string index out of bounds")

