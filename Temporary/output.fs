module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_9(float * var_0, float * var_1);
    __global__ void method_11(float * var_0, float * var_1, float * var_2);
    __device__ void method_10(float * var_0, float * var_1, long long int var_2);
    __device__ float method_12(float * var_0, float * var_1, long long int var_2, float var_3);
    __device__ float method_13(float var_0, float var_1);
    
    __global__ void method_9(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_10(var_0, var_1, var_9);
    }
    __global__ void method_11(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        long long int var_11 = (var_10 + 1280);
        char var_12 = (var_10 >= 0);
        char var_14;
        if (var_12) {
            var_14 = (var_10 < 1280);
        } else {
            var_14 = 0;
        }
        char var_15 = (var_14 == 0);
        if (var_15) {
            // unprinted assert;
        } else {
        }
        float * var_16 = var_0 + var_10;
        float * var_17 = var_1 + var_10;
        float var_18 = var_16[0];
        float var_19 = var_17[0];
        float var_20 = (var_19 - var_18);
        float var_21 = (var_20 * var_20);
        float var_22 = method_12(var_0, var_1, var_11, var_21);
        FunPointer0 var_25 = method_13;
        float var_26 = cub::BlockReduce<float,128>().Reduce(var_22, var_25);
        char var_27 = (var_3 == 0);
        if (var_27) {
            char var_28 = (var_6 >= 0);
            char var_30;
            if (var_28) {
                var_30 = (var_6 < 10);
            } else {
                var_30 = 0;
            }
            char var_31 = (var_30 == 0);
            if (var_31) {
                // unprinted assert;
            } else {
            }
            float * var_32 = var_2 + var_6;
            var_32[0] = var_26;
        } else {
        }
    }
    __device__ void method_10(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 1280);
        if (var_3) {
            char var_4 = (var_2 >= 0);
            char var_5 = (var_4 == 0);
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float * var_6 = var_1 + var_2;
            if (var_5) {
                // unprinted assert;
            } else {
            }
            float * var_7 = var_0 + var_2;
            float var_8 = var_7[0];
            float var_9 = (-var_8);
            float var_10 = exp(var_9);
            float var_11 = (1 + var_10);
            float var_12 = (1 / var_11);
            var_6[0] = var_12;
            long long int var_13 = (var_2 + 4096);
            method_10(var_0, var_1, var_13);
        } else {
        }
    }
    __device__ float method_12(float * var_0, float * var_1, long long int var_2, float var_3) {
        char var_4 = (var_2 < 1280);
        if (var_4) {
            char var_5 = (var_2 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                // unprinted assert;
            } else {
            }
            float * var_7 = var_0 + var_2;
            float * var_8 = var_1 + var_2;
            float var_9 = var_7[0];
            float var_10 = var_8[0];
            float var_11 = (var_10 - var_9);
            float var_12 = (var_11 * var_11);
            float var_13 = (var_3 + var_12);
            long long int var_14 = (var_2 + 1280);
            return method_12(var_0, var_1, var_14, var_13);
        } else {
            return var_3;
        }
    }
    __device__ float method_13(float var_0, float var_1) {
        return (var_0 + var_1);
    }
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
and EnvHeap5 =
    {
    mem_0: EnvStack3
    mem_1: EnvStack3
    mem_2: uint64
    mem_3: uint64
    mem_4: System.Collections.Generic.Stack<Env4>
    mem_5: ManagedCuda.CudaContext
    mem_6: ManagedCuda.CudaBlas.CudaBlas
    mem_7: ManagedCuda.CudaStream
    mem_8: ManagedCuda.BasicTypes.CUmodule
    mem_9: EnvStack3
    }
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
and method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64)): EnvStack3 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env4) = var_1.Peek()
        let (var_7: EnvStack3) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: Tuple1) = var_11.mem_0
            let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = var_12.mem_0
            method_5((var_13: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env4>), (var_7: EnvStack3), (var_8: int64))
        | Union0Case1 ->
            let (var_15: Env4) = var_1.Pop()
            let (var_16: EnvStack3) = var_15.mem_0
            let (var_17: int64) = var_15.mem_1
            method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64))
    else
        method_6((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64))
and method_7((var_0: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_2: uint64) = uint64 var_1
    let (var_3: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_2)
    let (var_4: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_3)
    var_4
and method_8((var_0: EnvHeap5), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 100L)
    if var_2 then
        let (var_3: string) = System.String.Format("On iteration {0}",var_1)
        let (var_4: string) = System.String.Format("{0}",var_3)
        System.Console.WriteLine(var_4)
        let (var_5: EnvStack3) = var_0.mem_0
        let (var_6: EnvStack3) = var_0.mem_1
        let (var_7: uint64) = var_0.mem_2
        let (var_8: uint64) = var_0.mem_3
        let (var_9: System.Collections.Generic.Stack<Env4>) = var_0.mem_4
        let (var_10: ManagedCuda.CudaContext) = var_0.mem_5
        let (var_11: ManagedCuda.CudaBlas.CudaBlas) = var_0.mem_6
        let (var_12: ManagedCuda.CudaStream) = var_0.mem_7
        let (var_13: ManagedCuda.BasicTypes.CUmodule) = var_0.mem_8
        let (var_14: EnvStack3) = var_0.mem_9
        let (var_15: int64) = (int64 sizeof<float32>)
        let (var_16: int64) = (1280L * var_15)
        let (var_17: EnvStack3) = method_4((var_7: uint64), (var_9: System.Collections.Generic.Stack<Env4>), (var_8: uint64), (var_16: int64))
        let (var_18: (Union0 ref)) = var_5.mem_0
        let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_18: (Union0 ref)))
        let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_19: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_21: (Union0 ref)) = var_6.mem_0
        let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_21: (Union0 ref)))
        let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_22: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_24: (Union0 ref)) = var_17.mem_0
        let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_24: (Union0 ref)))
        let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_25: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_27: ManagedCuda.BasicTypes.CUstream) = var_12.get_Stream()
        var_11.set_Stream(var_27)
        let (var_28: ManagedCuda.CudaBlas.CudaBlasHandle) = var_11.get_CublasHandle()
        let (var_29: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
        let (var_30: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
        let (var_31: (float32 ref)) = (ref 1.000000f)
        let (var_32: (float32 ref)) = (ref 0.000000f)
        let (var_33: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_28, var_29, var_30, 128, 10, 784, var_31, var_20, 128, var_23, 784, var_32, var_26, 128)
        if var_33 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_33)
        let (var_38: EnvStack3) = method_4((var_7: uint64), (var_9: System.Collections.Generic.Stack<Env4>), (var_8: uint64), (var_16: int64))
        let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_24: (Union0 ref)))
        let (var_40: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_39: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_41: (Union0 ref)) = var_38.mem_0
        let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_41: (Union0 ref)))
        let (var_43: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_42: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_9((var_40: ManagedCuda.BasicTypes.CUdeviceptr), (var_43: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_44: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(2L))
        var_44.[int32 0L] <- (var_40 :> System.Object)
        var_44.[int32 1L] <- (var_43 :> System.Object)
        let (var_45: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_9", var_13, var_10)
        let (var_46: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_45.set_GridDimensions(var_46)
        let (var_47: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_45.set_BlockDimensions(var_47)
        let (var_48: ManagedCuda.BasicTypes.CUstream) = var_12.get_Stream()
        var_45.RunAsync(var_48, var_44)
        let (var_49: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_41: (Union0 ref)))
        let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_49: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_51: (Union0 ref)) = var_14.mem_0
        let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
        let (var_53: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_52: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_56: int64) = (10L * var_15)
        let (var_57: EnvStack3) = method_4((var_7: uint64), (var_9: System.Collections.Generic.Stack<Env4>), (var_8: uint64), (var_56: int64))
        let (var_58: (Union0 ref)) = var_57.mem_0
        let (var_59: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_58: (Union0 ref)))
        let (var_60: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_59: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_11((var_50: ManagedCuda.BasicTypes.CUdeviceptr), (var_53: ManagedCuda.BasicTypes.CUdeviceptr), (var_60: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_61: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(3L))
        var_61.[int32 0L] <- (var_50 :> System.Object)
        var_61.[int32 1L] <- (var_53 :> System.Object)
        var_61.[int32 2L] <- (var_60 :> System.Object)
        let (var_62: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_11", var_13, var_10)
        let (var_63: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
        var_62.set_GridDimensions(var_63)
        let (var_64: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_62.set_BlockDimensions(var_64)
        let (var_65: ManagedCuda.BasicTypes.CUstream) = var_12.get_Stream()
        var_62.RunAsync(var_65, var_61)
        let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_58: (Union0 ref)))
        let (var_67: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10L))
        var_10.CopyToHost(var_67, var_66)
        var_10.Synchronize()
        let (var_68: float32) = var_67.[int32 0L]
        let (var_69: int64) = 1L
        let (var_70: float32) = method_14((var_67: (float32 [])), (var_69: int64), (var_68: float32))
        let (var_71: string) = System.String.Format("{0}",var_70)
        System.Console.WriteLine(var_71)
        var_58 := Union0Case1
        var_41 := Union0Case1
        var_24 := Union0Case1
        let (var_72: int64) = (var_1 + 1L)
        method_8((var_0: EnvHeap5), (var_72: int64))
    else
        ()
and method_5((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env4>), (var_5: EnvStack3), (var_6: int64)): EnvStack3 =
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
    let (var_17: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_17)
    let (var_19: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_18)))))
    let (var_20: EnvStack3) = EnvStack3((var_19: (Union0 ref)))
    var_4.Push((Env4(var_20, var_3)))
    var_20
and method_6((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64)): EnvStack3 =
    let (var_4: uint64) = uint64 var_3
    let (var_5: bool) = (var_4 <= var_2)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_8)))))
    let (var_10: EnvStack3) = EnvStack3((var_9: (Union0 ref)))
    var_1.Push((Env4(var_10, var_3)))
    var_10
and method_14((var_0: (float32 [])), (var_1: int64), (var_2: float32)): float32 =
    let (var_3: bool) = (var_1 < 10L)
    if var_3 then
        let (var_4: bool) = (var_1 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: float32) = var_0.[int32 var_1]
        let (var_7: float32) = (var_2 + var_6)
        let (var_8: int64) = (var_1 + 1L)
        method_14((var_0: (float32 [])), (var_8: int64), (var_7: float32))
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
let (var_67: float32) = sqrt 912.000000f
let (var_68: float32) = (1.000000f / var_67)
let (var_69: int64) = (int64 sizeof<float32>)
let (var_70: int64) = (100352L * var_69)
let (var_71: EnvStack3) = method_4((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_70: int64))
let (var_72: ManagedCuda.BasicTypes.CUstream) = var_56.get_Stream()
var_52.SetStream(var_72)
let (var_73: (Union0 ref)) = var_71.mem_0
let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_73: (Union0 ref)))
let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_74: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_76: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(100352L)
var_52.GenerateNormal32(var_75, var_76, 0.000000f, var_68)
let (var_77: float32) = sqrt 794.000000f
let (var_78: float32) = (1.000000f / var_77)
let (var_79: int64) = (7840L * var_69)
let (var_80: EnvStack3) = method_4((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_79: int64))
let (var_81: ManagedCuda.BasicTypes.CUstream) = var_56.get_Stream()
var_52.SetStream(var_81)
let (var_82: (Union0 ref)) = var_80.mem_0
let (var_83: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_82: (Union0 ref)))
let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_83: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_85: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_52.GenerateNormal32(var_84, var_85, 0.000000f, var_78)
let (var_86: float32) = sqrt 138.000000f
let (var_87: float32) = (1.000000f / var_86)
let (var_88: int64) = (1280L * var_69)
let (var_89: EnvStack3) = method_4((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_88: int64))
let (var_90: ManagedCuda.BasicTypes.CUstream) = var_56.get_Stream()
var_52.SetStream(var_90)
let (var_91: (Union0 ref)) = var_89.mem_0
let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_91: (Union0 ref)))
let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_7((var_92: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_94: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
var_52.GenerateNormal32(var_93, var_94, 0.000000f, var_87)
let (var_95: EnvHeap5) = ({mem_0 = (var_71: EnvStack3); mem_1 = (var_80: EnvStack3); mem_2 = (var_49: uint64); mem_3 = (var_50: uint64); mem_4 = (var_45: System.Collections.Generic.Stack<Env4>); mem_5 = (var_1: ManagedCuda.CudaContext); mem_6 = (var_55: ManagedCuda.CudaBlas.CudaBlas); mem_7 = (var_56: ManagedCuda.CudaStream); mem_8 = (var_32: ManagedCuda.BasicTypes.CUmodule); mem_9 = (var_89: EnvStack3)} : EnvHeap5)
let (var_96: int64) = 0L
method_8((var_95: EnvHeap5), (var_96: int64))
var_91 := Union0Case1
var_82 := Union0Case1
var_73 := Union0Case1
var_55.Dispose()
var_52.Dispose()
let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_97)
var_46 := Union0Case1
var_1.Dispose()

