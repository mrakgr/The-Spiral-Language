open ManagedCuda
open ManagedCuda.BasicTypes

let ctx = new CudaContext()

let size = 10240
let x = new CudaDeviceVariable<bool>(SizeT size)
x.SizeInBytes |> printfn "%A" // is size * 4

for i=1 to 10 do
    let y = Array.zeroCreate<bool>(size*3) // It does work with x4 though, but not with x1, x2 and x3 as shown here.
    x.CopyToHost(y)