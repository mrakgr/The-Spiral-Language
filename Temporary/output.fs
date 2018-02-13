module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type EnvStack0 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env1 =
    struct
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack2 =
    struct
    val mem_0: (int64 ref)
    val mem_1: EnvStack3
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack3 =
    struct
    val mem_0: (bool ref)
    val mem_1: ManagedCuda.CudaStream
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>)): unit =
    let (var_5: (Env1 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env1 -> (Env1 -> int32))) = method_3
    let (var_9: System.Comparison<Env1>) = System.Comparison<Env1>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: int32) = 0
    let (var_12: Env1) = method_6((var_0: ResizeArray<Env1>), (var_10: int32), (var_1: EnvStack0), (var_11: int32))
    let (var_13: EnvStack0) = var_12.mem_0
    let (var_14: uint64) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_1.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: uint64) = (var_16 + var_2)
    let (var_18: uint64) = method_5((var_15: (uint64 ref)))
    let (var_19: uint64) = (var_18 - var_17)
    let (var_20: (uint64 ref)) = var_13.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: (uint64 ref)) = (ref var_21)
    let (var_23: EnvStack0) = EnvStack0((var_22: (uint64 ref)))
    var_0.Add((Env1(var_23, var_19)))
and method_8((var_0: ResizeArray<EnvStack2>)): EnvStack2 =
    let (var_1: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
    let (var_2: (bool ref)) = (ref true)
    let (var_3: EnvStack3) = EnvStack3((var_2: (bool ref)), (var_1: ManagedCuda.CudaStream))
    let (var_4: (int64 ref)) = (ref 0L)
    let (var_5: EnvStack2) = EnvStack2((var_4: (int64 ref)), (var_3: EnvStack3))
    method_9((var_5: EnvStack2), (var_0: ResizeArray<EnvStack2>))
    var_5
and method_10((var_0: EnvStack2), (var_1: ManagedCuda.CudaStream)): unit =
    let (var_2: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
    let (var_3: (int64 ref)) = var_0.mem_0
    let (var_4: EnvStack3) = var_0.mem_1
    let (var_5: (bool ref)) = var_4.mem_0
    let (var_6: ManagedCuda.CudaStream) = var_4.mem_1
    let (var_7: bool) = (!var_5)
    let (var_8: bool) = (var_7 = false)
    if var_8 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_9: ManagedCuda.BasicTypes.CUstream) = var_6.Stream
    var_2.Record(var_9)
    var_1.WaitEvent var_2.Event
    var_2.Dispose()
and method_11((var_0: ResizeArray<EnvStack2>)): unit =
    let (var_2: (EnvStack2 -> unit)) = method_12
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2 ((var_0: Env1)): bool =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_4((var_1: EnvStack0))
and method_6((var_0: ResizeArray<Env1>), (var_1: int32), (var_2: EnvStack0), (var_3: int32)): Env1 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: Env1) = var_0.[var_3]
        let (var_6: EnvStack0) = var_5.mem_0
        let (var_7: uint64) = var_5.mem_1
        let (var_8: (uint64 ref)) = var_2.mem_0
        let (var_9: uint64) = method_5((var_8: (uint64 ref)))
        let (var_10: uint64) = method_5((var_8: (uint64 ref)))
        let (var_11: uint64) = (var_10 - var_9)
        let (var_12: bool) = (var_11 > 0UL)
        if var_12 then
            let (var_13: uint64) = method_5((var_8: (uint64 ref)))
            let (var_14: (uint64 ref)) = (ref var_13)
            let (var_15: EnvStack0) = EnvStack0((var_14: (uint64 ref)))
            var_0.Add((Env1(var_15, var_11)))
        else
            ()
        let (var_16: int32) = (var_3 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_6: EnvStack0), (var_7: uint64), (var_16: int32))
    else
        (Env1(var_2, 0UL))
and method_9((var_0: EnvStack2), (var_1: ResizeArray<EnvStack2>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack3) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_12 ((var_0: EnvStack2)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvStack3) = var_0.mem_1
    let (var_3: int64) = (!var_1)
    let (var_4: int64) = (var_3 - 1L)
    var_1 := var_4
    let (var_5: int64) = (!var_1)
    let (var_6: bool) = (var_5 = 0L)
    if var_6 then
        let (var_7: (bool ref)) = var_2.mem_0
        let (var_8: ManagedCuda.CudaStream) = var_2.mem_1
        var_8.Dispose()
        var_7 := false
    else
        ()
and method_4 ((var_1: EnvStack0)) ((var_0: Env1)): int32 =
    let (var_2: EnvStack0) = var_0.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: (uint64 ref)) = var_2.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: bool) = (var_5 < var_7)
    if var_8 then
        -1
    else
        let (var_9: bool) = (var_5 = var_7)
        if var_9 then
            0
        else
            1
and method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_2: EnvStack0), (var_3: uint64), (var_4: int32)): Env1 =
    let (var_5: bool) = (var_4 < var_1)
    if var_5 then
        let (var_6: Env1) = var_0.[var_4]
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_2.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: uint64) = (var_10 + var_3)
        let (var_12: uint64) = method_5((var_9: (uint64 ref)))
        let (var_13: uint64) = (var_12 - var_11)
        let (var_14: bool) = (var_13 > 0UL)
        if var_14 then
            let (var_15: uint64) = method_5((var_9: (uint64 ref)))
            let (var_16: (uint64 ref)) = (ref var_15)
            let (var_17: EnvStack0) = EnvStack0((var_16: (uint64 ref)))
            var_0.Add((Env1(var_17, var_13)))
        else
            ()
        let (var_18: int32) = (var_4 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_7: EnvStack0), (var_8: uint64), (var_18: int32))
    else
        (Env1(var_2, var_3))
let (var_0: string) = cuda_kernels
let (var_1: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_1.Synchronize()
let (var_2: string) = System.Environment.get_CurrentDirectory()
let (var_3: string) = System.IO.Path.Combine(var_2, "nvcc_router.bat")
let (var_4: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_4.set_RedirectStandardOutput(true)
var_4.set_RedirectStandardError(true)
var_4.set_UseShellExecute(false)
var_4.set_FileName(var_3)
let (var_5: System.Diagnostics.Process) = System.Diagnostics.Process()
var_5.set_StartInfo(var_4)
let (var_7: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_5.OutputDataReceived.Add(var_7)
var_5.ErrorDataReceived.Add(var_7)
let (var_8: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_10: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
let (var_13: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_14: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_15: bool) = System.IO.File.Exists(var_14)
if var_15 then
    System.IO.File.Delete(var_14)
else
    ()
System.IO.File.WriteAllText(var_14, var_0)
let (var_16: bool) = System.IO.File.Exists(var_3)
if var_16 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_17: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_18: System.IO.StreamWriter) = System.IO.StreamWriter(var_17)
var_18.WriteLine("SETLOCAL")
let (var_19: string) = String.concat "" [|"CALL "; "\""; var_8; "\""|]
var_18.WriteLine(var_19)
let (var_20: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_9; "\""|]
var_18.WriteLine(var_20)
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:/cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
var_18.WriteLine(var_21)
var_18.Dispose()
var_17.Dispose()
let (var_22: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_23: bool) = var_5.Start()
let (var_24: bool) = (var_23 = false)
if var_24 then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_25: int32) = var_5.get_ExitCode()
let (var_26: bool) = (var_25 = 0)
let (var_27: bool) = (var_26 = false)
if var_27 then
    let (var_28: string) = System.String.Format("{0}",var_25)
    let (var_29: string) = String.concat ", " [|"NVCC failed compilation."; var_28|]
    let (var_30: string) = System.String.Format("[{0}]",var_29)
    (failwith var_30)
else
    ()
let (var_31: System.TimeSpan) = var_22.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_31
let (var_32: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_33: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_2|]
let (var_34: string) = System.String.Format("{0}",var_33)
System.Console.WriteLine(var_34)
let (var_35: uint64) = 1280UL
let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_36)
let (var_38: uint64) = uint64 var_37
let (var_39: (uint64 ref)) = (ref var_38)
let (var_40: EnvStack0) = EnvStack0((var_39: (uint64 ref)))
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>))
let (var_49: ResizeArray<EnvStack2>) = ResizeArray<EnvStack2>()
let (var_50: EnvStack2) = method_8((var_49: ResizeArray<EnvStack2>))
let (var_51: EnvStack2) = method_8((var_49: ResizeArray<EnvStack2>))
let (var_52: EnvStack2) = method_8((var_49: ResizeArray<EnvStack2>))
let (var_53: (int64 ref)) = var_50.mem_0
let (var_54: EnvStack3) = var_50.mem_1
let (var_55: (bool ref)) = var_54.mem_0
let (var_56: ManagedCuda.CudaStream) = var_54.mem_1
let (var_57: bool) = (!var_55)
let (var_58: bool) = (var_57 = false)
if var_58 then
    (failwith "The stream has been disposed.")
else
    ()
method_10((var_51: EnvStack2), (var_56: ManagedCuda.CudaStream))
method_11((var_49: ResizeArray<EnvStack2>))
let (var_59: (uint64 ref)) = var_40.mem_0
let (var_60: uint64) = method_5((var_59: (uint64 ref)))
let (var_61: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_60)
let (var_62: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_61)
var_1.FreeMemory(var_62)
var_59 := 0UL
var_1.Dispose()

