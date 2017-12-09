module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type Union0 =
    | Union0Case0 of Tuple2
    | Union0Case1
and Tuple1 =
    struct
    val mem_0: ManagedCuda.BasicTypes.CUdeviceptr
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Tuple2 =
    struct
    val mem_0: Tuple1
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack3 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env4 =
    struct
    val mem_0: EnvStack3
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env5 =
    struct
    val mem_0: Env6
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env6 =
    struct
    val mem_0: Env7
    val mem_1: Tuple8
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env7 =
    struct
    val mem_0: (float32 [])
    val mem_1: Tuple10
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Tuple8 =
    struct
    val mem_0: Env9
    val mem_1: Env9
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env9 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple10 =
    struct
    val mem_0: Env11
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env11 =
    struct
    val mem_0: int64
    val mem_1: int64
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
        let (var_3: Tuple1) = var_2.mem_0
        var_3.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: (float32 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 32L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_5: float32) = (float32 var_1)
        var_0.[int32 var_1] <- var_5
        let (var_6: int64) = (var_1 + 1L)
        method_2((var_0: (float32 [])), (var_6: int64))
    else
        ()
and method_3((var_0: (float32 [])), (var_1: int64), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < var_1)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: float32) = (float32 var_2)
        var_0.[int32 var_2] <- var_6
        let (var_7: int64) = (var_2 + 1L)
        method_3((var_0: (float32 [])), (var_1: int64), (var_7: int64))
    else
        ()
and method_4((var_0: string)): Env5 =
    let (var_1: System.IO.FileMode) = System.IO.FileMode.Open
    let (var_2: System.IO.FileAccess) = System.IO.FileAccess.Read
    let (var_3: System.IO.FileShare) = System.IO.FileShare.Read
    let (var_4: System.IO.FileStream) = System.IO.File.Open(var_0, var_1, var_2, var_3)
    let (var_5: System.IO.BinaryReader) = System.IO.BinaryReader(var_4)
    let (var_6: int32) = var_5.ReadInt32()
    let (var_7: int32) = System.Net.IPAddress.NetworkToHostOrder(var_6)
    let (var_8: bool) = (var_7 = 2049)
    let (var_60: Env5) =
        if var_8 then
            let (var_9: int32) = var_5.ReadInt32()
            let (var_10: int32) = System.Net.IPAddress.NetworkToHostOrder(var_9)
            let (var_12: (uint8 [])) = var_5.ReadBytes(var_10)
            let (var_13: int64) = (int64 var_10)
            let (var_17: bool) = (var_13 > 0L)
            let (var_18: bool) = (var_17 = false)
            if var_18 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_19: int64) = (var_13 * 10L)
            let (var_20: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_19))
            let (var_21: int64) = 0L
            method_5((var_12: (uint8 [])), (var_20: (float32 [])), (var_13: int64), (var_21: int64))
            (Env5((Env6((Env7(var_20, Tuple10((Env11(0L, 1L))), 0L, 10L)), Tuple8((Env9(0L, var_13)), (Env9(0L, 10L)))))))
        else
            let (var_22: bool) = (var_7 = 2051)
            let (var_23: bool) = (var_22 = false)
            if var_23 then
                (failwith "The magic number must be either 2049 or 2051")
            else
                ()
            let (var_24: int32) = var_5.ReadInt32()
            let (var_25: int32) = System.Net.IPAddress.NetworkToHostOrder(var_24)
            let (var_26: int32) = var_5.ReadInt32()
            let (var_27: int32) = System.Net.IPAddress.NetworkToHostOrder(var_26)
            let (var_28: int32) = var_5.ReadInt32()
            let (var_29: int32) = System.Net.IPAddress.NetworkToHostOrder(var_28)
            let (var_30: int32) = (var_27 * var_29)
            let (var_31: int32) = (var_25 * var_27)
            let (var_32: int32) = (var_31 * var_29)
            let (var_34: (uint8 [])) = var_5.ReadBytes(var_32)
            let (var_35: int64) = var_34.LongLength
            let (var_36: bool) = (var_35 > 0L)
            let (var_37: bool) = (var_36 = false)
            if var_37 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_38: int64) = (int64 var_25)
            let (var_39: int64) = (int64 var_30)
            let (var_40: bool) = (var_38 > 0L)
            let (var_41: bool) = (var_40 = false)
            if var_41 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_42: bool) = (var_39 > 0L)
            let (var_43: bool) = (var_42 = false)
            if var_43 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_44: int64) = (var_38 * var_39)
            let (var_45: bool) = (var_44 = var_35)
            let (var_46: bool) = (var_45 = false)
            if var_46 then
                (failwith "The product of given dimensions does not match the product of tensor dimensions.")
            else
                ()
            let (var_54: bool) = (0L < var_38)
            let (var_55: bool) = (var_54 = false)
            if var_55 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_56: bool) = (0L < var_39)
            let (var_57: bool) = (var_56 = false)
            if var_57 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_58: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_44))
            let (var_59: int64) = 0L
            method_7((var_34: (uint8 [])), (var_39: int64), (var_38: int64), (var_58: (float32 [])), (var_59: int64))
            (Env5((Env6((Env7(var_58, Tuple10((Env11(0L, 1L))), 0L, var_39)), Tuple8((Env9(0L, var_38)), (Env9(0L, var_39)))))))
    let (var_61: Env6) = var_60.mem_0
    var_5.Dispose()
    var_4.Dispose()
    (Env5(var_61))
and method_9((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_9((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_10((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64)): unit =
    let (var_10: bool) = (var_6 < var_7)
    if var_10 then
        let (var_11: bool) = (var_6 >= var_6)
        let (var_12: bool) = (var_11 = false)
        if var_12 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_13: int64) = (var_4 + var_3)
        let (var_14: int64) = 0L
        method_11((var_0: System.Text.StringBuilder), (var_14: int64))
        let (var_15: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_16: string) = method_12((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_13: int64), (var_8: int64), (var_9: int64), (var_1: string))
        let (var_17: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_18: int64) = (var_6 + 1L)
        method_14((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_18: int64))
    else
        ()
and method_5((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < var_2)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_3 * 10L)
        let (var_8: uint8) = var_0.[int32 var_3]
        let (var_9: int64) = 0L
        method_6((var_8: uint8), (var_1: (float32 [])), (var_7: int64), (var_9: int64))
        let (var_10: int64) = (var_3 + 1L)
        method_5((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64), (var_10: int64))
    else
        ()
and method_7((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: bool) = (var_4 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: int64) = (var_4 * var_1)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: int64) = 0L
        method_8((var_0: (uint8 [])), (var_8: int64), (var_1: int64), (var_3: (float32 [])), (var_9: int64))
        let (var_10: int64) = (var_4 + 1L)
        method_7((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_10: int64))
    else
        ()
and method_11((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_11((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_12((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: string)): string =
    let (var_6: bool) = (var_3 < var_4)
    if var_6 then
        let (var_7: System.Text.StringBuilder) = var_0.Append(var_5)
        let (var_8: bool) = (var_3 >= var_3)
        let (var_9: bool) = (var_8 = false)
        if var_9 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_10: float32) = var_1.[int32 var_2]
        let (var_11: string) = System.String.Format("{0}",var_10)
        let (var_12: System.Text.StringBuilder) = var_0.Append(var_11)
        let (var_13: string) = "; "
        let (var_14: int64) = (var_3 + 1L)
        method_13((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_14: int64), (var_13: string))
    else
        var_5
and method_14((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
    let (var_11: bool) = (var_10 < var_7)
    if var_11 then
        let (var_12: bool) = (var_10 >= var_6)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_14: int64) = (var_10 - var_6)
        let (var_15: int64) = (var_14 * var_5)
        let (var_16: int64) = (var_4 + var_15)
        let (var_17: int64) = (var_16 + var_3)
        let (var_18: int64) = 0L
        method_11((var_0: System.Text.StringBuilder), (var_18: int64))
        let (var_19: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_20: string) = method_12((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_17: int64), (var_8: int64), (var_9: int64), (var_1: string))
        let (var_21: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_22: int64) = (var_10 + 1L)
        method_14((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_22: int64))
    else
        ()
and method_6((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < 10L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_2 + var_3)
        let (var_8: uint8) = (uint8 var_3)
        let (var_9: bool) = (var_8 = var_0)
        let (var_10: float32) =
            if var_9 then
                1.000000f
            else
                0.000000f
        var_1.[int32 var_7] <- var_10
        let (var_11: int64) = (var_3 + 1L)
        method_6((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_11: int64))
    else
        ()
and method_8((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: bool) = (var_4 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: int64) = (var_1 + var_4)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: uint8) = var_0.[int32 var_8]
        let (var_10: float32) = (float32 var_9)
        let (var_11: float32) = (var_10 / 255.000000f)
        var_3.[int32 var_8] <- var_11
        let (var_12: int64) = (var_4 + 1L)
        method_8((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_12: int64))
    else
        ()
and method_13((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
    let (var_7: bool) = (var_5 < var_4)
    if var_7 then
        let (var_8: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_9: bool) = (var_5 >= var_3)
        let (var_10: bool) = (var_9 = false)
        if var_10 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_11: int64) = (var_5 - var_3)
        let (var_12: int64) = (var_2 + var_11)
        let (var_13: float32) = var_1.[int32 var_12]
        let (var_14: string) = System.String.Format("{0}",var_13)
        let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
        let (var_16: string) = "; "
        let (var_17: int64) = (var_5 + 1L)
        method_13((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_17: int64), (var_16: string))
    else
        var_6
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
let (var_8: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Auxiliary\\Build\\vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\bin\\Hostx64\\x64")
let (var_10: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\include")
let (var_12: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v9.0", "bin\\nvcc.exe")
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
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:\\cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
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
let (var_39: float) = (0.700000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_42)))))
let (var_44: EnvStack3) = EnvStack3((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env4>) = System.Collections.Generic.Stack<Env4>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_52: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_51)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_57: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
let (var_58: int64) = 0L
method_2((var_57: (float32 [])), (var_58: int64))
let (var_59: float32) = 2.000000f
let (var_60: int64) = 64L
let (var_61: bool) = (var_60 > 0L)
let (var_62: bool) = (var_61 = false)
if var_62 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_63: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_60))
let (var_64: int64) = 0L
method_3((var_63: (float32 [])), (var_60: int64), (var_64: int64))
let (var_65: float32) = sqrt 912.000000f
let (var_66: float32) = (1.000000f / var_65)
let (var_67: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "t10k-images.idx3-ubyte")
let (var_68: Env5) = method_4((var_67: string))
let (var_69: Env6) = var_68.mem_0
let (var_70: Env7) = var_69.mem_0
let (var_71: Tuple8) = var_69.mem_1
let (var_72: Env9) = var_71.mem_0
let (var_73: Env9) = var_71.mem_1
let (var_74: int64) = var_72.mem_0
let (var_75: int64) = var_72.mem_1
let (var_76: bool) = (var_74 = 0L)
let (var_78: bool) =
    if var_76 then
        (var_75 = 10000L)
    else
        false
let (var_84: bool) =
    if var_78 then
        let (var_79: int64) = var_73.mem_0
        let (var_80: int64) = var_73.mem_1
        let (var_81: bool) = (var_79 = 0L)
        if var_81 then
            (var_80 = 784L)
        else
            false
    else
        false
let (var_85: bool) = (var_84 = false)
if var_85 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_86: bool) = (var_74 < var_75)
let (var_87: bool) = (var_86 = false)
if var_87 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_88: int64) = var_73.mem_0
let (var_89: int64) = var_73.mem_1
let (var_90: bool) = (var_88 < var_89)
let (var_91: bool) = (var_90 = false)
if var_91 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_92: int64) = (var_89 - var_88)
let (var_93: int64) = (var_75 - var_74)
let (var_94: int64) = (var_93 * var_92)
let (var_95: (float32 [])) = var_70.mem_0
let (var_96: Tuple10) = var_70.mem_1
let (var_97: int64) = var_70.mem_2
let (var_98: int64) = var_70.mem_3
let (var_99: Env11) = var_96.mem_0
let (var_100: int64) = var_99.mem_0
let (var_101: int64) = var_99.mem_1
let (var_102: bool) = (var_100 = 0L)
let (var_103: bool) = (var_102 = false)
if var_103 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_104: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "t10k-labels.idx1-ubyte")
let (var_105: Env5) = method_4((var_104: string))
let (var_106: Env6) = var_105.mem_0
let (var_107: Env7) = var_106.mem_0
let (var_108: Tuple8) = var_106.mem_1
let (var_109: Env9) = var_108.mem_0
let (var_110: Env9) = var_108.mem_1
let (var_111: int64) = var_109.mem_0
let (var_112: int64) = var_109.mem_1
let (var_113: bool) = (var_111 = 0L)
let (var_115: bool) =
    if var_113 then
        (var_112 = 10000L)
    else
        false
let (var_121: bool) =
    if var_115 then
        let (var_116: int64) = var_110.mem_0
        let (var_117: int64) = var_110.mem_1
        let (var_118: bool) = (var_116 = 0L)
        if var_118 then
            (var_117 = 10L)
        else
            false
    else
        false
let (var_122: bool) = (var_121 = false)
if var_122 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_123: bool) = (var_111 < var_112)
let (var_124: bool) = (var_123 = false)
if var_124 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_125: int64) = var_110.mem_0
let (var_126: int64) = var_110.mem_1
let (var_127: bool) = (var_125 < var_126)
let (var_128: bool) = (var_127 = false)
if var_128 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_129: int64) = (var_126 - var_125)
let (var_130: int64) = (var_112 - var_111)
let (var_131: int64) = (var_130 * var_129)
let (var_132: (float32 [])) = var_107.mem_0
let (var_133: Tuple10) = var_107.mem_1
let (var_134: int64) = var_107.mem_2
let (var_135: int64) = var_107.mem_3
let (var_136: Env11) = var_133.mem_0
let (var_137: int64) = var_136.mem_0
let (var_138: int64) = var_136.mem_1
let (var_139: bool) = (var_137 = 0L)
let (var_140: bool) = (var_139 = false)
if var_140 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_141: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "train-images.idx3-ubyte")
let (var_142: Env5) = method_4((var_141: string))
let (var_143: Env6) = var_142.mem_0
let (var_144: Env7) = var_143.mem_0
let (var_145: Tuple8) = var_143.mem_1
let (var_146: Env9) = var_145.mem_0
let (var_147: Env9) = var_145.mem_1
let (var_148: int64) = var_146.mem_0
let (var_149: int64) = var_146.mem_1
let (var_150: bool) = (var_148 = 0L)
let (var_152: bool) =
    if var_150 then
        (var_149 = 60000L)
    else
        false
let (var_158: bool) =
    if var_152 then
        let (var_153: int64) = var_147.mem_0
        let (var_154: int64) = var_147.mem_1
        let (var_155: bool) = (var_153 = 0L)
        if var_155 then
            (var_154 = 784L)
        else
            false
    else
        false
let (var_159: bool) = (var_158 = false)
if var_159 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_160: bool) = (var_148 < var_149)
let (var_161: bool) = (var_160 = false)
if var_161 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_162: int64) = var_147.mem_0
let (var_163: int64) = var_147.mem_1
let (var_164: bool) = (var_162 < var_163)
let (var_165: bool) = (var_164 = false)
if var_165 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_166: int64) = (var_163 - var_162)
let (var_167: int64) = (var_149 - var_148)
let (var_168: int64) = (var_167 * var_166)
let (var_169: (float32 [])) = var_144.mem_0
let (var_170: Tuple10) = var_144.mem_1
let (var_171: int64) = var_144.mem_2
let (var_172: int64) = var_144.mem_3
let (var_173: Env11) = var_170.mem_0
let (var_174: int64) = var_173.mem_0
let (var_175: int64) = var_173.mem_1
let (var_176: bool) = (var_174 = 0L)
let (var_177: bool) = (var_176 = false)
if var_177 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_178: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "train-labels.idx1-ubyte")
let (var_179: Env5) = method_4((var_178: string))
let (var_180: Env6) = var_179.mem_0
let (var_181: Env7) = var_180.mem_0
let (var_182: Tuple8) = var_180.mem_1
let (var_183: Env9) = var_182.mem_0
let (var_184: Env9) = var_182.mem_1
let (var_185: int64) = var_183.mem_0
let (var_186: int64) = var_183.mem_1
let (var_187: bool) = (var_185 = 0L)
let (var_189: bool) =
    if var_187 then
        (var_186 = 60000L)
    else
        false
let (var_195: bool) =
    if var_189 then
        let (var_190: int64) = var_184.mem_0
        let (var_191: int64) = var_184.mem_1
        let (var_192: bool) = (var_190 = 0L)
        if var_192 then
            (var_191 = 10L)
        else
            false
    else
        false
let (var_196: bool) = (var_195 = false)
if var_196 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_197: bool) = (var_185 < var_186)
let (var_198: bool) = (var_197 = false)
if var_198 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_199: int64) = var_184.mem_0
let (var_200: int64) = var_184.mem_1
let (var_201: bool) = (var_199 < var_200)
let (var_202: bool) = (var_201 = false)
if var_202 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_203: int64) = (var_200 - var_199)
let (var_204: int64) = (var_186 - var_185)
let (var_205: int64) = (var_204 * var_203)
let (var_206: (float32 [])) = var_181.mem_0
let (var_207: Tuple10) = var_181.mem_1
let (var_208: int64) = var_181.mem_2
let (var_209: int64) = var_181.mem_3
let (var_210: Env11) = var_207.mem_0
let (var_211: int64) = var_210.mem_0
let (var_212: int64) = var_210.mem_1
let (var_213: bool) = (var_211 = 0L)
let (var_214: bool) = (var_213 = false)
if var_214 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_215: int64) = (var_126 - 1L)
let (var_216: bool) = (var_215 > var_125)
let (var_217: int64) =
    if var_216 then
        var_125
    else
        var_215
let (var_218: int64) = (var_125 + 10L)
let (var_219: bool) = (var_126 > var_218)
let (var_220: int64) =
    if var_219 then
        var_218
    else
        var_126
let (var_221: int64) = (var_112 - 1L)
let (var_222: bool) = (var_221 > var_111)
let (var_223: int64) =
    if var_222 then
        var_111
    else
        var_221
let (var_224: int64) = (var_111 + 100L)
let (var_225: bool) = (var_112 > var_224)
let (var_226: int64) =
    if var_225 then
        var_224
    else
        var_112
let (var_227: bool) = (var_223 < var_226)
let (var_228: bool) = (var_227 = false)
if var_228 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_229: bool) = (var_217 < var_220)
let (var_230: bool) = (var_229 = false)
if var_230 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_231: bool) = (var_223 >= var_111)
let (var_233: bool) =
    if var_231 then
        (var_223 < var_112)
    else
        false
let (var_234: bool) = (var_233 = false)
if var_234 then
    (failwith "Lower boundary out of bounds.")
else
    ()
let (var_235: bool) = (var_226 > var_111)
let (var_237: bool) =
    if var_235 then
        (var_226 <= var_112)
    else
        false
let (var_238: bool) = (var_237 = false)
if var_238 then
    (failwith "Higher boundary out of bounds.")
else
    ()
let (var_239: bool) = (var_217 >= var_125)
let (var_241: bool) =
    if var_239 then
        (var_217 < var_126)
    else
        false
let (var_242: bool) = (var_241 = false)
if var_242 then
    (failwith "Lower boundary out of bounds.")
else
    ()
let (var_243: bool) = (var_220 > var_125)
let (var_245: bool) =
    if var_243 then
        (var_220 <= var_126)
    else
        false
let (var_246: bool) = (var_245 = false)
if var_246 then
    (failwith "Higher boundary out of bounds.")
else
    ()
let (var_247: int64) = (var_217 - var_125)
let (var_248: int64) = (var_223 - var_111)
let (var_249: int64) = (var_248 * var_129)
let (var_250: System.Text.StringBuilder) = System.Text.StringBuilder()
let (var_251: string) = ""
let (var_252: int64) = 0L
method_9((var_250: System.Text.StringBuilder), (var_252: int64))
let (var_253: System.Text.StringBuilder) = var_250.AppendLine("[|")
method_10((var_250: System.Text.StringBuilder), (var_251: string), (var_132: (float32 [])), (var_247: int64), (var_249: int64), (var_129: int64), (var_223: int64), (var_226: int64), (var_217: int64), (var_220: int64))
let (var_254: int64) = 0L
method_9((var_250: System.Text.StringBuilder), (var_254: int64))
let (var_255: System.Text.StringBuilder) = var_250.AppendLine("|]")
let (var_256: string) = var_250.ToString()
let (var_257: string) = System.String.Format("{0}",var_256)
System.Console.WriteLine(var_257)
var_55.Dispose()
var_52.Dispose()
let (var_258: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_258)
var_46 := Union0Case1
var_1.Dispose()

