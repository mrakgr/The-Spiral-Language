module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Env0 {
        long long int mem_0;
    };
    __device__ __forceinline__ Env0 make_Env0(long long int mem_0){
        Env0 tmp;
        tmp.mem_0 = mem_0;
        return tmp;
    }
    __global__ void method_8(float * var_0, float * var_1);
    __device__ char method_9(Env0 * var_0);
    
    __global__ void method_8(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_9(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 128);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 10);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            char var_20;
            if (var_15) {
                var_20 = (var_13 < 10);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_0[var_13];
            float var_23 = var_1[var_13];
            var_1[var_13] = var_22;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_24 = var_10[0];
        long long int var_25 = var_24.mem_0;
    }
    __device__ char method_9(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
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
and method_2((var_0: System.Random), (var_1: (float32 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 32L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_2 * 5L)
        let (var_7: int64) = 0L
        method_3((var_0: System.Random), (var_1: (float32 [])), (var_6: int64), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_2((var_0: System.Random), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_5((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_6((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_7((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: (float32 [])), (var_7: EnvStack2), (var_8: int64)): unit =
    let (var_9: bool) = (var_8 < 32L)
    if var_9 then
        let (var_10: int64) = (var_8 + 2L)
        let (var_11: bool) = (var_8 >= 0L)
        let (var_12: bool) = (var_11 = false)
        if var_12 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_13: bool) = (var_10 > 0L)
        let (var_15: bool) =
            if var_13 then
                (var_10 <= 32L)
            else
                false
        let (var_16: bool) = (var_15 = false)
        if var_16 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_17: int64) = (var_8 * 5L)
        if var_12 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_19: bool) =
            if var_13 then
                (var_10 <= 32L)
            else
                false
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_21: int64) = 40L
        let (var_22: EnvStack2) = method_4((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_21: int64))
        let (var_23: int64) = (var_17 * 4L)
        let (var_24: (Union0 ref)) = var_7.mem_0
        let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_24: (Union0 ref)))
        let (var_26: ManagedCuda.BasicTypes.SizeT) = var_25.Pointer
        let (var_27: uint64) = uint64 var_26
        let (var_28: uint64) = (uint64 var_23)
        let (var_29: uint64) = (var_27 + var_28)
        let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
        let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
        let (var_32: (Union0 ref)) = var_22.mem_0
        let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        // Cuda join point
        // method_8((var_31: ManagedCuda.BasicTypes.CUdeviceptr), (var_33: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_35: (System.Object [])) = [|var_31; var_33|]: (System.Object [])
        let (var_36: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_8", var_4, var_3)
        let (var_37: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_36.set_GridDimensions(var_37)
        let (var_38: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_36.set_BlockDimensions(var_38)
        let (var_39: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_36.RunAsync(var_39, var_35)
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        let (var_41: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10L))
        var_3.CopyToHost(var_41, var_40)
        var_3.Synchronize()
        let (var_42: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_43: string) = ""
        let (var_44: int64) = 0L
        method_10((var_42: System.Text.StringBuilder), (var_44: int64))
        let (var_45: System.Text.StringBuilder) = var_42.AppendLine("[|")
        let (var_46: int64) = 0L
        method_11((var_42: System.Text.StringBuilder), (var_43: string), (var_6: (float32 [])), (var_17: int64), (var_41: (float32 [])), (var_46: int64))
        let (var_47: int64) = 0L
        method_10((var_42: System.Text.StringBuilder), (var_47: int64))
        let (var_48: System.Text.StringBuilder) = var_42.AppendLine("|]")
        let (var_49: string) = var_42.ToString()
        let (var_50: string) = System.String.Format("{0}",var_49)
        System.Console.WriteLine(var_50)
        let (var_51: int64) = 0L
        let (var_52: bool) = method_14((var_6: (float32 [])), (var_17: int64), (var_41: (float32 [])), (var_51: int64))
        let (var_53: string) = System.String.Format("{0}",var_52)
        System.Console.WriteLine(var_53)
        var_32 := Union0Case1
        method_7((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: (float32 [])), (var_7: EnvStack2), (var_10: int64))
    else
        ()
and method_3((var_0: System.Random), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < 5L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_2 + var_3)
        let (var_8: float) = var_0.NextDouble()
        let (var_9: float32) = (float32 var_8)
        var_1.[int32 var_7] <- var_9
        let (var_10: int64) = (var_3 + 1L)
        method_3((var_0: System.Random), (var_1: (float32 [])), (var_2: int64), (var_10: int64))
    else
        ()
and method_5((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: uint64) = (var_8 - var_1)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: uint64) = uint64 var_3
    let (var_13: uint64) = (var_12 + var_11)
    let (var_14: bool) = (var_13 <= var_2)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_16: uint64) = (var_8 + var_9)
    let (var_17: uint64) = (var_16 % 128UL)
    let (var_18: uint64) = (var_16 + var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_3)))
    var_22
and method_6((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: uint64) = (var_0 % 128UL)
    let (var_8: uint64) = (var_0 + var_7)
    let (var_9: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_8)
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_9)
    let (var_11: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_10))))
    let (var_12: EnvStack2) = EnvStack2((var_11: (Union0 ref)))
    var_3.Push((Env3(var_12, var_2)))
    var_12
and method_10((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_10((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: (float32 [])), (var_5: int64)): unit =
    let (var_6: bool) = (var_5 < 2L)
    if var_6 then
        let (var_7: bool) = (var_5 >= 0L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: int64) = (var_5 * 5L)
        let (var_10: int64) = (var_3 + var_9)
        let (var_11: int64) = 0L
        method_12((var_0: System.Text.StringBuilder), (var_11: int64))
        let (var_12: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_13: int64) = 0L
        let (var_14: string) = method_13((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_10: int64), (var_4: (float32 [])), (var_9: int64), (var_1: string), (var_13: int64))
        let (var_15: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_16: int64) = (var_5 + 1L)
        method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: (float32 [])), (var_16: int64))
    else
        ()
and method_14((var_0: (float32 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64)): bool =
    let (var_4: bool) = (var_3 < 2L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_3 * 5L)
        let (var_8: int64) = (var_1 + var_7)
        let (var_9: int64) = 0L
        let (var_10: bool) = method_15((var_0: (float32 [])), (var_8: int64), (var_2: (float32 [])), (var_7: int64), (var_9: int64))
        if var_10 then
            let (var_11: int64) = (var_3 + 1L)
            method_14((var_0: (float32 [])), (var_1: int64), (var_2: (float32 [])), (var_11: int64))
        else
            false
    else
        true
and method_12((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_12((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_13((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: (float32 [])), (var_4: int64), (var_5: string), (var_6: int64)): string =
    let (var_7: bool) = (var_6 < 5L)
    if var_7 then
        let (var_8: System.Text.StringBuilder) = var_0.Append(var_5)
        let (var_9: bool) = (var_6 >= 0L)
        let (var_10: bool) = (var_9 = false)
        if var_10 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_11: int64) = (var_2 + var_6)
        let (var_12: int64) = (var_4 + var_6)
        let (var_13: float32) = var_1.[int32 var_11]
        let (var_14: float32) = var_3.[int32 var_12]
        let (var_15: string) = System.String.Format("{0}",var_14)
        let (var_16: string) = System.String.Format("{0}",var_13)
        let (var_17: string) = String.concat ", " [|var_16; var_15|]
        let (var_18: string) = System.String.Format("[{0}]",var_17)
        let (var_19: System.Text.StringBuilder) = var_0.Append(var_18)
        let (var_20: string) = "; "
        let (var_21: int64) = (var_6 + 1L)
        method_13((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: (float32 [])), (var_4: int64), (var_20: string), (var_21: int64))
    else
        var_5
and method_15((var_0: (float32 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64), (var_4: int64)): bool =
    let (var_5: bool) = (var_4 < 5L)
    if var_5 then
        let (var_6: bool) = (var_4 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: int64) = (var_1 + var_4)
        let (var_9: int64) = (var_3 + var_4)
        let (var_10: float32) = var_0.[int32 var_8]
        let (var_11: float32) = var_2.[int32 var_9]
        let (var_12: bool) = (var_10 = var_11)
        if var_12 then
            let (var_13: int64) = (var_4 + 1L)
            method_15((var_0: (float32 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64), (var_13: int64))
        else
            false
    else
        true
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
let (var_39: float) = (0.700000 * var_38)
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
let (var_52: System.Random) = System.Random()
let (var_55: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(160L))
let (var_56: int64) = 0L
method_2((var_52: System.Random), (var_55: (float32 [])), (var_56: int64))
let (var_57: int64) = var_55.LongLength
let (var_58: int64) = (var_57 * 4L)
let (var_59: EnvStack2) = method_4((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_58: int64))
let (var_60: (Union0 ref)) = var_59.mem_0
let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_60: (Union0 ref)))
var_1.CopyToDevice(var_61, var_55)
let (var_62: int64) = 0L
method_7((var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_51: ManagedCuda.CudaStream), (var_55: (float32 [])), (var_59: EnvStack2), (var_62: int64))
var_60 := Union0Case1
var_51.Dispose()
let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_63)
var_46 := Union0Case1
var_1.Dispose()

