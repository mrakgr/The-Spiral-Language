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
and EnvHeap2 =
    {
    mem_0: (int64 ref)
    mem_1: EnvHeap3
    }
and EnvHeap3 =
    {
    mem_0: (bool ref)
    mem_1: ManagedCuda.CudaStream
    }
and Env4 =
    struct
    val mem_0: ManagedCuda.CudaStream
    new(arg_mem_0) = {mem_0 = arg_mem_0}
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
    let (var_18: (uint64 ref)) = var_13.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: uint64) = (var_17 - var_19)
    let (var_21: uint64) = method_5((var_18: (uint64 ref)))
    let (var_22: uint64) = (var_21 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 &&& 18446744073709551360UL)
    let (var_25: uint64) = (var_24 - var_21)
    let (var_26: bool) = (var_20 >= var_25)
    if var_26 then
        let (var_27: (uint64 ref)) = (ref var_24)
        let (var_28: EnvStack0) = EnvStack0((var_27: (uint64 ref)))
        let (var_29: uint64) = (var_20 - var_25)
        var_0.Add((Env1(var_28, var_29)))
    else
        ()
and method_8((var_0: EnvHeap3), (var_1: ResizeArray<Env1>), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ManagedCuda.CudaContext), (var_6: ResizeArray<EnvHeap2>), (var_7: ManagedCuda.BasicTypes.CUmodule)): EnvHeap2 =
    let (var_8: (int64 ref)) = (ref 0L)
    let (var_9: EnvHeap2) = ({mem_0 = (var_8: (int64 ref)); mem_1 = (var_0: EnvHeap3)} : EnvHeap2)
    method_9((var_9: EnvHeap2), (var_6: ResizeArray<EnvHeap2>))
    var_9
and method_10((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): Env4 =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    (Env4(var_1))
and method_11((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_12((var_0: ResizeArray<EnvHeap2>)): unit =
    let (var_2: (EnvHeap2 -> unit)) = method_13
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
        let (var_8: (uint64 ref)) = var_6.mem_0
        let (var_9: uint64) = method_5((var_8: (uint64 ref)))
        let (var_10: (uint64 ref)) = var_2.mem_0
        let (var_11: uint64) = method_5((var_10: (uint64 ref)))
        let (var_12: uint64) = (var_9 - var_11)
        let (var_13: uint64) = method_5((var_10: (uint64 ref)))
        let (var_14: uint64) = (var_13 + 256UL)
        let (var_15: uint64) = (var_14 - 1UL)
        let (var_16: uint64) = (var_15 &&& 18446744073709551360UL)
        let (var_17: uint64) = (var_16 - var_13)
        let (var_18: bool) = (var_12 >= var_17)
        if var_18 then
            let (var_19: (uint64 ref)) = (ref var_16)
            let (var_20: EnvStack0) = EnvStack0((var_19: (uint64 ref)))
            let (var_21: uint64) = (var_12 - var_17)
            var_0.Add((Env1(var_20, var_21)))
        else
            ()
        let (var_22: int32) = (var_3 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_6: EnvStack0), (var_7: uint64), (var_22: int32))
    else
        (Env1(var_2, 0UL))
and method_9((var_0: EnvHeap2), (var_1: ResizeArray<EnvHeap2>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvHeap3) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_13 ((var_0: EnvHeap2)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvHeap3) = var_0.mem_1
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
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: (uint64 ref)) = var_2.mem_0
        let (var_12: uint64) = method_5((var_11: (uint64 ref)))
        let (var_13: uint64) = (var_12 + var_3)
        let (var_14: uint64) = (var_10 - var_13)
        let (var_15: uint64) = method_5((var_11: (uint64 ref)))
        let (var_16: uint64) = (var_15 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 &&& 18446744073709551360UL)
        let (var_19: uint64) = (var_18 - var_15)
        let (var_20: bool) = (var_14 >= var_19)
        if var_20 then
            let (var_21: (uint64 ref)) = (ref var_18)
            let (var_22: EnvStack0) = EnvStack0((var_21: (uint64 ref)))
            let (var_23: uint64) = (var_14 - var_19)
            var_0.Add((Env1(var_22, var_23)))
        else
            ()
        let (var_24: int32) = (var_4 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_7: EnvStack0), (var_8: uint64), (var_24: int32))
    else
        (Env1(var_2, var_3))
let (var_0: uint64) = (256UL &&& 255UL)
let (var_1: bool) = (var_0 = 0UL)
let (var_2: bool) = (var_1 = false)
if var_2 then
    (failwith "Multiple must be a power of 2.")
else
    ()
let (var_3: string) = cuda_kernels
let (var_4: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_4.Synchronize()
let (var_5: string) = System.Environment.get_CurrentDirectory()
let (var_6: string) = System.IO.Path.Combine(var_5, "nvcc_router.bat")
let (var_7: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_7.set_RedirectStandardOutput(true)
var_7.set_RedirectStandardError(true)
var_7.set_UseShellExecute(false)
var_7.set_FileName(var_6)
let (var_8: System.Diagnostics.Process) = System.Diagnostics.Process()
var_8.set_StartInfo(var_7)
let (var_10: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_8.OutputDataReceived.Add(var_10)
var_8.ErrorDataReceived.Add(var_10)
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvars64.bat")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_13: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_14: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_15: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
let (var_16: string) = System.IO.Path.Combine(var_5, "cuda_kernels.ptx")
let (var_17: string) = System.IO.Path.Combine(var_5, "cuda_kernels.cu")
let (var_18: bool) = System.IO.File.Exists(var_17)
if var_18 then
    System.IO.File.Delete(var_17)
else
    ()
System.IO.File.WriteAllText(var_17, var_3)
let (var_19: bool) = System.IO.File.Exists(var_6)
if var_19 then
    System.IO.File.Delete(var_6)
else
    ()
let (var_20: System.IO.FileStream) = System.IO.File.OpenWrite(var_6)
let (var_21: System.IO.StreamWriter) = System.IO.StreamWriter(var_20)
var_21.WriteLine("SETLOCAL")
let (var_22: string) = String.concat "" [|"CALL "; "\""; var_11; "\""|]
var_21.WriteLine(var_22)
let (var_23: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_12; "\""|]
var_21.WriteLine(var_23)
let (var_24: string) = String.concat "" [|"\""; var_15; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_13; "\" -I\"C:/cub-1.7.4\" -I\""; var_14; "\" --keep-dir \""; var_5; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_16; "\" \""; var_17; "\""|]
var_21.WriteLine(var_24)
var_21.Dispose()
var_20.Dispose()
let (var_25: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_26: bool) = var_8.Start()
let (var_27: bool) = (var_26 = false)
if var_27 then
    (failwith "NVCC failed to run.")
else
    ()
var_8.BeginOutputReadLine()
var_8.BeginErrorReadLine()
var_8.WaitForExit()
let (var_28: int32) = var_8.get_ExitCode()
let (var_29: bool) = (var_28 = 0)
let (var_30: bool) = (var_29 = false)
if var_30 then
    let (var_31: string) = System.String.Format("{0}",var_28)
    let (var_32: string) = String.concat ", " [|"NVCC failed compilation."; var_31|]
    let (var_33: string) = System.String.Format("[{0}]",var_32)
    (failwith var_33)
else
    ()
let (var_34: System.TimeSpan) = var_25.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_34
let (var_35: ManagedCuda.BasicTypes.CUmodule) = var_4.LoadModulePTX(var_16)
var_8.Dispose()
let (var_36: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_5|]
let (var_37: string) = System.String.Format("{0}",var_36)
System.Console.WriteLine(var_37)
let (var_38: uint64) = (1279UL &&& 18446744073709551360UL)
let (var_39: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_38)
let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = var_4.AllocateMemory(var_39)
let (var_41: uint64) = uint64 var_40
let (var_42: (uint64 ref)) = (ref var_41)
let (var_43: EnvStack0) = EnvStack0((var_42: (uint64 ref)))
let (var_44: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_45: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_44: ResizeArray<Env1>), (var_43: EnvStack0), (var_38: uint64), (var_45: ResizeArray<Env1>))
let (var_57: ResizeArray<EnvHeap2>) = ResizeArray<EnvHeap2>()
let (var_58: (bool ref)) = (ref true)
let (var_59: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_60: EnvHeap3) = ({mem_0 = (var_58: (bool ref)); mem_1 = (var_59: ManagedCuda.CudaStream)} : EnvHeap3)
let (var_61: EnvHeap2) = method_8((var_60: EnvHeap3), (var_44: ResizeArray<Env1>), (var_43: EnvStack0), (var_38: uint64), (var_45: ResizeArray<Env1>), (var_4: ManagedCuda.CudaContext), (var_57: ResizeArray<EnvHeap2>), (var_35: ManagedCuda.BasicTypes.CUmodule))
let (var_62: (bool ref)) = (ref true)
let (var_63: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_64: EnvHeap3) = ({mem_0 = (var_62: (bool ref)); mem_1 = (var_63: ManagedCuda.CudaStream)} : EnvHeap3)
let (var_65: EnvHeap2) = method_8((var_64: EnvHeap3), (var_44: ResizeArray<Env1>), (var_43: EnvStack0), (var_38: uint64), (var_45: ResizeArray<Env1>), (var_4: ManagedCuda.CudaContext), (var_57: ResizeArray<EnvHeap2>), (var_35: ManagedCuda.BasicTypes.CUmodule))
let (var_66: (bool ref)) = (ref true)
let (var_67: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_68: EnvHeap3) = ({mem_0 = (var_66: (bool ref)); mem_1 = (var_67: ManagedCuda.CudaStream)} : EnvHeap3)
let (var_69: EnvHeap2) = method_8((var_68: EnvHeap3), (var_44: ResizeArray<Env1>), (var_43: EnvStack0), (var_38: uint64), (var_45: ResizeArray<Env1>), (var_4: ManagedCuda.CudaContext), (var_57: ResizeArray<EnvHeap2>), (var_35: ManagedCuda.BasicTypes.CUmodule))
let (var_70: (int64 ref)) = var_69.mem_0
let (var_71: EnvHeap3) = var_69.mem_1
let (var_72: (bool ref)) = var_71.mem_0
let (var_73: ManagedCuda.CudaStream) = var_71.mem_1
let (var_74: Env4) = method_10((var_72: (bool ref)), (var_73: ManagedCuda.CudaStream))
let (var_75: ManagedCuda.CudaStream) = var_74.mem_0
let (var_76: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_77: (int64 ref)) = var_65.mem_0
let (var_78: EnvHeap3) = var_65.mem_1
let (var_79: (bool ref)) = var_78.mem_0
let (var_80: ManagedCuda.CudaStream) = var_78.mem_1
let (var_81: ManagedCuda.BasicTypes.CUstream) = method_11((var_79: (bool ref)), (var_80: ManagedCuda.CudaStream))
var_76.Record(var_81)
var_75.WaitEvent var_76.Event
var_76.Dispose()
method_12((var_57: ResizeArray<EnvHeap2>))
let (var_82: (uint64 ref)) = var_43.mem_0
let (var_83: uint64) = method_5((var_82: (uint64 ref)))
let (var_84: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_83)
let (var_85: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_84)
var_4.FreeMemory(var_85)
var_82 := 0UL
var_4.Dispose()

