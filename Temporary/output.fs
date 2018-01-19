open ManagedCuda
open ManagedCuda.BasicTypes
open System
open System.Runtime.InteropServices
Marshal.SizeOf(typeof<int8>)


let ctx = new CudaContext()

let rng = Random()
let size = 30

let orig = Array.init size (fun _ -> rng.NextDouble() |> float32)

let x = new CudaDeviceVariable<_>(SizeT size)
x.CopyToDevice(orig)

let y = Array.zeroCreate<float32>(size)
x.CopyToHost(y)



for i=1 to 1024 do
    let y = Array.zeroCreate<float32>(size)
    x.CopyToHost(y)
    if orig <> y then
        Array.zip orig y |> printfn "%A"
        failwith "Transfer failed."