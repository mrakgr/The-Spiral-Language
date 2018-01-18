module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type Union0 =
    | Union0Case0 of Tuple1
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: ManagedCuda.BasicTypes.CUdeviceptr
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack2 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env3 =
    struct
    val mem_0: EnvStack2
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env4 =
    struct
    val mem_0: int64
    val mem_1: float
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env3) = var_1.Peek()
        let (var_7: EnvStack2) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_5((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.CudaStream), (var_5: EnvStack2), (var_6: EnvStack2), (var_7: ManagedCuda.CudaBlas.CudaBlasHandle), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: int64)): unit =
    let (var_13: bool) = (var_12 < 5L)
    if var_13 then
        let (var_14: int64) = 0L
        let (var_15: float) = 0.000000
        let (var_16: int64) = 0L
        let (var_17: Env4) = method_6((var_4: ManagedCuda.CudaStream), (var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_5: EnvStack2), (var_6: EnvStack2), (var_7: ManagedCuda.CudaBlas.CudaBlasHandle), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_14: int64), (var_15: float), (var_16: int64))
        let (var_18: int64) = var_17.mem_0
        let (var_19: float) = var_17.mem_1
        System.Console.WriteLine("-----")
        System.Console.WriteLine("Batch done.")
        let (var_20: float) = (var_19 / 32.000000)
        let (var_21: string) = System.String.Format("Average of batch costs is {0}.",var_20)
        let (var_22: string) = System.String.Format("{0}",var_21)
        System.Console.WriteLine(var_22)
        let (var_23: string) = System.String.Format("The accuracy of the batch is {0}/{1}.",var_18,32L)
        let (var_24: string) = System.String.Format("{0}",var_23)
        System.Console.WriteLine(var_24)
        System.Console.WriteLine("-----")
        let (var_25: int64) = (var_12 + 1L)
        method_5((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.CudaStream), (var_5: EnvStack2), (var_6: EnvStack2), (var_7: ManagedCuda.CudaBlas.CudaBlasHandle), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_25: int64))
    else
        ()
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: int64) = (var_3 % 256L)
    let (var_11: int64) = (var_3 - var_10)
    let (var_12: int64) = (var_11 + 256L)
    let (var_13: uint64) = (var_8 + var_9)
    let (var_14: uint64) = (var_1 + var_2)
    let (var_15: uint64) = uint64 var_12
    let (var_16: uint64) = (var_14 - var_13)
    let (var_17: bool) = (var_15 <= var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_12)))
    var_22
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: int64) = (var_2 % 256L)
    let (var_5: int64) = (var_2 - var_4)
    let (var_6: int64) = (var_5 + 256L)
    let (var_7: uint64) = (var_0 + var_1)
    let (var_8: uint64) = uint64 var_6
    let (var_9: uint64) = (var_7 - var_0)
    let (var_10: bool) = (var_8 <= var_9)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_13))))
    let (var_15: EnvStack2) = EnvStack2((var_14: (Union0 ref)))
    var_3.Push((Env3(var_15, var_6)))
    var_15
and method_6((var_0: ManagedCuda.CudaStream), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack2), (var_6: EnvStack2), (var_7: ManagedCuda.CudaBlas.CudaBlasHandle), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: int64), (var_13: float), (var_14: int64)): Env4 =
    let (var_15: bool) = (var_14 < 32L)
    if var_15 then
        let (var_16: int64) = (var_14 + 32L)
        let (var_17: bool) = (var_14 >= 0L)
        let (var_18: bool) = (var_17 = false)
        if var_18 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_19: bool) = (var_16 > 0L)
        let (var_21: bool) =
            if var_19 then
                (var_16 <= 32L)
            else
                false
        let (var_22: bool) = (var_21 = false)
        if var_22 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_23: int64) = (var_14 * 784L)
        if var_18 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_25: bool) =
            if var_19 then
                (var_16 <= 32L)
            else
                false
        let (var_26: bool) = (var_25 = false)
        if var_26 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_27: int64) = (var_14 * 10L)
        let (var_28: int64) = 1280L
        let (var_29: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_28: int64))
        let (var_30: int64) = 1280L
        let (var_31: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_30: int64))
        let (var_32: (Union0 ref)) = var_31.mem_0
        let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        let (var_34: (Union0 ref)) = var_6.mem_0
        let (var_35: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_34: (Union0 ref)))
        let (var_36: (Union0 ref)) = var_29.mem_0
        let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_36: (Union0 ref)))
        let (var_38: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_36: (Union0 ref)))
        let (var_43: int64) = 1280L
        let (var_44: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_43: int64))
        let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_36: (Union0 ref)))
        let (var_46: (Union0 ref)) = var_44.mem_0
        let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
        let (var_48: int64) = 1280L
        let (var_49: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_48: int64))
        let (var_50: (Union0 ref)) = var_49.mem_0
        let (var_51: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
        let (var_53: int64) = (var_27 * 4L)
        let (var_54: (Union0 ref)) = var_11.mem_0
        let (var_55: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_54: (Union0 ref)))
        let (var_56: ManagedCuda.BasicTypes.SizeT) = var_55.Pointer
        let (var_57: uint64) = uint64 var_56
        let (var_58: uint64) = (uint64 var_53)
        let (var_59: uint64) = (var_57 + var_58)
        let (var_60: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_59)
        let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_60)
        let (var_69: int64) = 4L
        let (var_70: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_69: int64))
        let (var_71: (Union0 ref)) = var_70.mem_0
        let (var_72: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_73: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_71: (Union0 ref)))
        let (var_74: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(1L))
        var_4.CopyToHost(var_74, var_73)
        var_4.Synchronize()
        let (var_75: float32) = 0.000000f
        let (var_76: int64) = 0L
        let (var_77: float32) = method_7((var_74: (float32 [])), (var_75: float32), (var_76: int64))
        var_71 := Union0Case1
        let (var_78: (float32 ref)) = (ref 0.000000f)
        let (var_79: float32) = (var_77 / 32.000000f)
        let (var_80: (float32 ref)) = (ref 0.000000f)
        var_80 := 1.000000f
        let (var_81: float32) = (!var_80)
        let (var_82: float32) = (var_81 / 32.000000f)
        let (var_83: float32) = (!var_78)
        let (var_84: float32) = (var_83 + var_82)
        var_78 := var_84
        let (var_85: float32) = (!var_78)
        let (var_86: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
        let (var_87: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_54: (Union0 ref)))
        let (var_88: ManagedCuda.BasicTypes.SizeT) = var_87.Pointer
        let (var_89: uint64) = uint64 var_88
        let (var_90: uint64) = (var_89 + var_58)
        let (var_91: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_90)
        let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_91)
        let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_36: (Union0 ref)))
        let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_50: (Union0 ref)))
        let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
        let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        let (var_99: (Union0 ref)) = var_5.mem_0
        let (var_100: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_99: (Union0 ref)))
        let (var_101: (Union0 ref)) = var_8.mem_0
        let (var_102: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_101: (Union0 ref)))
        let (var_103: (Union0 ref)) = var_9.mem_0
        let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_103: (Union0 ref)))
        let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_101: (Union0 ref)))
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_99: (Union0 ref)))
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_34: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_99: (Union0 ref)))
        let (var_109: float) = (float var_79)
        let (var_110: float) = (var_109 * 32.000000)
        let (var_111: float) = (var_13 + var_110)
        let (var_113: int64) = 32L
        let (var_114: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_113: int64))
        let (var_115: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
        let (var_116: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_54: (Union0 ref)))
        let (var_117: ManagedCuda.BasicTypes.SizeT) = var_116.Pointer
        let (var_118: uint64) = uint64 var_117
        let (var_119: uint64) = (var_118 + var_58)
        let (var_120: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_119)
        let (var_121: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_120)
        let (var_122: (Union0 ref)) = var_114.mem_0
        let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_122: (Union0 ref)))
        let (var_124: int64) = 0L
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_122: (Union0 ref)))
        let (var_126: (bool [])) = Array.zeroCreate<bool> (System.Convert.ToInt32(32L))
        var_4.CopyToHost(var_126, var_125)
        var_4.Synchronize()
        let (var_127: int64) = var_126.LongLength
        let (var_128: int64) = 0L
        let (var_129: int64) = method_8((var_126: (bool [])), (var_127: int64), (var_124: int64), (var_128: int64))
        var_122 := Union0Case1
        let (var_130: int64) = (var_12 + var_129)
        var_50 := Union0Case1
        var_46 := Union0Case1
        var_32 := Union0Case1
        var_36 := Union0Case1
        method_6((var_0: ManagedCuda.CudaStream), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_4: ManagedCuda.CudaContext), (var_5: EnvStack2), (var_6: EnvStack2), (var_7: ManagedCuda.CudaBlas.CudaBlasHandle), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_130: int64), (var_111: float), (var_16: int64))
    else
        (Env4(var_12, var_13))
and method_7((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 1L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: float32) = var_0.[int32 var_2]
        let (var_7: float32) = (var_1 + var_6)
        let (var_8: int64) = (var_2 + 1L)
        method_7((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_8((var_0: (bool [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: bool) = var_0.[int32 var_3]
        let (var_7: int64) =
            if var_5 then
                (var_2 + 1L)
            else
                var_2
        let (var_8: int64) = (var_3 + 1L)
        method_8((var_0: (bool [])), (var_1: int64), (var_7: int64), (var_8: int64))
    else
        var_2
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
let (var_35: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_36: ManagedCuda.BasicTypes.SizeT) = var_35.get_TotalGlobalMemory()
let (var_37: int64) = int64 var_36
let (var_38: float) = float var_37
let (var_39: float) = (0.100000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: EnvStack2) = EnvStack2((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_52: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_53: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_52)
let (var_54: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_53.SetStream(var_54)
let (var_55: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_56: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_57: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_55, var_56)
let (var_58: ManagedCuda.CudaBlas.CudaBlasHandle) = var_57.get_CublasHandle()
let (var_59: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_57.set_Stream(var_59)
let (var_60: int64) = 100352L
let (var_61: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_60: int64))
let (var_62: int64) = 1280L
let (var_63: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_62: int64))
let (var_64: int64) = 31360L
let (var_65: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_64: int64))
let (var_66: int64) = 31360L
let (var_67: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_66: int64))
let (var_68: (Union0 ref)) = var_67.mem_0
let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_68: (Union0 ref)))
let (var_70: int64) = 40L
let (var_71: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_70: int64))
let (var_72: (Union0 ref)) = var_71.mem_0
let (var_73: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_72: (Union0 ref)))
let (var_74: int64) = 40L
let (var_75: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_74: int64))
let (var_76: (Union0 ref)) = var_75.mem_0
let (var_77: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_76: (Union0 ref)))
let (var_78: int64) = 0L
method_5((var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_75: EnvStack2), (var_71: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_67: EnvStack2), (var_65: EnvStack2), (var_61: EnvStack2), (var_63: EnvStack2), (var_78: int64))
var_76 := Union0Case1
var_72 := Union0Case1
var_68 := Union0Case1
let (var_79: (Union0 ref)) = var_65.mem_0
var_79 := Union0Case1
let (var_80: (Union0 ref)) = var_63.mem_0
var_80 := Union0Case1
let (var_81: (Union0 ref)) = var_61.mem_0
var_81 := Union0Case1
var_57.Dispose()
var_53.Dispose()
var_51.Dispose()
let (var_82: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_82)
var_46 := Union0Case1
var_1.Dispose()

