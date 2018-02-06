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
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64)): EnvStack0 =
    let (var_3: int32) = var_1.get_Count()
    let (var_4: bool) = (var_3 > 0)
    if var_4 then
        let (var_5: Env1) = var_1.Peek()
        let (var_6: EnvStack0) = var_5.mem_0
        let (var_7: uint64) = var_5.mem_1
        let (var_8: (uint64 ref)) = var_6.mem_0
        let (var_9: uint64) = (!var_8)
        let (var_10: bool) = (var_9 = 0UL)
        if var_10 then
            let (var_11: Env1) = var_1.Pop()
            let (var_12: EnvStack0) = var_11.mem_0
            let (var_13: uint64) = var_11.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64))
        else
            method_3((var_9: uint64), (var_0: uint64), (var_2: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_7: uint64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_1: System.Collections.Generic.Stack<Env1>))
and method_3((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env1>), (var_4: uint64)): EnvStack0 =
    let (var_5: uint64) = (var_0 + var_4)
    let (var_6: uint64) = (var_1 + 1024UL)
    let (var_7: uint64) = (var_6 - var_5)
    let (var_8: bool) = (var_2 <= var_7)
    let (var_9: bool) = (var_8 = false)
    if var_9 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_10: (uint64 ref)) = (ref var_5)
    let (var_11: EnvStack0) = EnvStack0((var_10: (uint64 ref)))
    var_3.Push((Env1(var_11, var_2)))
    var_11
and method_4((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env1>)): EnvStack0 =
    let (var_3: uint64) = (var_0 + 1024UL)
    let (var_4: uint64) = (var_3 - var_0)
    let (var_5: bool) = (var_1 <= var_4)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: (uint64 ref)) = (ref var_0)
    let (var_8: EnvStack0) = EnvStack0((var_7: (uint64 ref)))
    var_2.Push((Env1(var_8, var_1)))
    var_8
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
let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1024UL)
let (var_36: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_35)
let (var_37: uint64) = uint64 var_36
let (var_38: (uint64 ref)) = (ref var_37)
let (var_39: EnvStack0) = EnvStack0((var_38: (uint64 ref)))
let (var_40: System.Collections.Generic.Stack<Env1>) = System.Collections.Generic.Stack<Env1>()
let (var_41: (uint64 ref)) = var_39.mem_0
let (var_42: uint64) = method_1((var_41: (uint64 ref)))
let (var_43: uint64) = 256UL
let (var_44: EnvStack0) = method_2((var_42: uint64), (var_40: System.Collections.Generic.Stack<Env1>), (var_43: uint64))
let (var_45: uint64) = 256UL
let (var_46: EnvStack0) = method_2((var_42: uint64), (var_40: System.Collections.Generic.Stack<Env1>), (var_45: uint64))
let (var_47: uint64) = 256UL
let (var_48: EnvStack0) = method_2((var_42: uint64), (var_40: System.Collections.Generic.Stack<Env1>), (var_47: uint64))
let (var_49: (uint64 ref)) = var_48.mem_0
var_49 := 0UL
let (var_50: (uint64 ref)) = var_46.mem_0
var_50 := 0UL
let (var_51: (uint64 ref)) = var_44.mem_0
var_51 := 0UL
let (var_52: uint64) = method_1((var_41: (uint64 ref)))
let (var_53: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_52)
let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_53)
var_1.FreeMemory(var_54)
var_41 := 0UL
var_1.Dispose()

