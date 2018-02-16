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
let (var_35: uint64) = 1024UL
let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_36)
let (var_38: uint64) = uint64 var_37
let (var_39: (uint64 ref)) = (ref var_38)
let (var_40: EnvStack0) = EnvStack0((var_39: (uint64 ref)))
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>))
let (var_54: ResizeArray<EnvHeap2>) = ResizeArray<EnvHeap2>()
let (var_55: (bool ref)) = (ref true)
let (var_56: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_57: EnvHeap3) = ({mem_0 = (var_55: (bool ref)); mem_1 = (var_56: ManagedCuda.CudaStream)} : EnvHeap3)
let (var_58: EnvHeap2) = method_8((var_57: EnvHeap3), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_54: ResizeArray<EnvHeap2>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_59: (bool ref)) = (ref true)
let (var_60: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_61: EnvHeap3) = ({mem_0 = (var_59: (bool ref)); mem_1 = (var_60: ManagedCuda.CudaStream)} : EnvHeap3)
let (var_62: EnvHeap2) = method_8((var_61: EnvHeap3), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_54: ResizeArray<EnvHeap2>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_63: (bool ref)) = (ref true)
let (var_64: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_65: EnvHeap3) = ({mem_0 = (var_63: (bool ref)); mem_1 = (var_64: ManagedCuda.CudaStream)} : EnvHeap3)
let (var_66: EnvHeap2) = method_8((var_65: EnvHeap3), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_1: ManagedCuda.CudaContext), (var_54: ResizeArray<EnvHeap2>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_67: (int64 ref)) = var_66.mem_0
let (var_68: EnvHeap3) = var_66.mem_1
let (var_69: (bool ref)) = var_68.mem_0
let (var_70: ManagedCuda.CudaStream) = var_68.mem_1
let (var_71: Env4) = method_10((var_69: (bool ref)), (var_70: ManagedCuda.CudaStream))
let (var_72: ManagedCuda.CudaStream) = var_71.mem_0
let (var_73: ManagedCuda.CudaEvent) = ManagedCuda.CudaEvent()
let (var_74: (int64 ref)) = var_62.mem_0
let (var_75: EnvHeap3) = var_62.mem_1
let (var_76: (bool ref)) = var_75.mem_0
let (var_77: ManagedCuda.CudaStream) = var_75.mem_1
let (var_78: ManagedCuda.BasicTypes.CUstream) = method_11((var_76: (bool ref)), (var_77: ManagedCuda.CudaStream))
var_73.Record(var_78)
var_72.WaitEvent var_73.Event
var_73.Dispose()
method_12((var_54: ResizeArray<EnvHeap2>))
let (var_79: (uint64 ref)) = var_40.mem_0
let (var_80: uint64) = method_5((var_79: (uint64 ref)))
let (var_81: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_80)
let (var_82: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_81)
var_1.FreeMemory(var_82)
var_79 := 0UL
var_1.Dispose()

