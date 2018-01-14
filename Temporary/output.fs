module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_6(float * var_0, float * var_1, float * var_2);
    __global__ void method_13(float * var_0, float * var_1, long long int * var_2);
    __device__ float method_7(float * var_0, float * var_1, float var_2, long long int var_3);
    typedef float(*FunPointer0)(float, float);
    __device__ float method_8(float var_0, float var_1);
    __device__ void method_14(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9);
    struct Tuple1 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple1 make_Tuple1(float mem_0, float mem_1){
        Tuple1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    __device__ Tuple1 method_15(float * var_0, long long int var_1, float * var_2, float var_3, float var_4, long long int var_5);
    typedef Tuple1(*FunPointer2)(Tuple1, Tuple1);
    __device__ Tuple1 method_16(Tuple1 var_0, Tuple1 var_1);
    
    __global__ void method_6(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        float var_12 = method_7(var_0, var_1, var_11, var_10);
        FunPointer0 var_15 = method_8;
        float var_16 = cub::BlockReduce<float,128>().Reduce(var_12, var_15);
        char var_17 = (var_3 == 0);
        if (var_17) {
            char var_18 = (var_6 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_6 < 4);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // unprinted assert;
            } else {
            }
            var_2[var_6] = var_16;
        } else {
        }
    }
    __global__ void method_13(float * var_0, float * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_4 + var_7);
        method_14(var_6, var_7, var_8, var_0, var_1, var_2, var_3, var_4, var_5, var_9);
    }
    __device__ float method_7(float * var_0, float * var_1, float var_2, long long int var_3) {
        char var_4 = (var_3 < 512);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                // unprinted assert;
            } else {
            }
            float var_7 = var_0[var_3];
            float var_8 = var_1[var_3];
            float var_9 = (var_8 - var_7);
            float var_10 = (var_9 * var_9);
            float var_11 = (var_2 + var_10);
            long long int var_12 = (var_3 + 512);
            return method_7(var_0, var_1, var_11, var_12);
        } else {
            return var_2;
        }
    }
    __device__ float method_8(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_14(long long int var_0, long long int var_1, long long int var_2, float * var_3, float * var_4, long long int * var_5, long long int var_6, long long int var_7, long long int var_8, long long int var_9) {
        char var_10 = (var_9 < 32);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                // unprinted assert;
            } else {
            }
            long long int var_13 = (var_9 * 16);
            if (var_12) {
                // unprinted assert;
            } else {
            }
            long long int var_14 = (16 * var_0);
            long long int var_15 = (var_6 + var_14);
            float var_16 = __int_as_float(0xff800000);
            float var_17 = 0;
            Tuple1 var_18 = method_15(var_3, var_13, var_4, var_16, var_17, var_15);
            float var_19 = var_18.mem_0;
            float var_20 = var_18.mem_1;
            FunPointer2 var_23 = method_16;
            Tuple1 var_24 = cub::BlockReduce<Tuple1,16>().Reduce(make_Tuple1(var_19, var_20), var_23);
            float var_25 = var_24.mem_0;
            float var_26 = var_24.mem_1;
            char var_27 = (var_6 == 0);
            if (var_27) {
                if (var_12) {
                    // unprinted assert;
                } else {
                }
                long long int var_28 = var_5[var_9];
                char var_29 = (var_26 == 1);
                long long int var_30;
                if (var_29) {
                    var_30 = 1;
                } else {
                    var_30 = 0;
                }
                var_5[var_9] = var_30;
            } else {
            }
            long long int var_31 = (var_9 + 32);
            method_14(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_31);
        } else {
        }
    }
    __device__ Tuple1 method_15(float * var_0, long long int var_1, float * var_2, float var_3, float var_4, long long int var_5) {
        char var_6 = (var_5 < 16);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            long long int var_9 = (var_1 + var_5);
            float var_10 = var_0[var_9];
            float var_11 = var_2[var_9];
            char var_12 = (var_3 > var_10);
            Tuple1 var_13;
            if (var_12) {
                var_13 = make_Tuple1(var_3, var_4);
            } else {
                var_13 = make_Tuple1(var_10, var_11);
            }
            float var_14 = var_13.mem_0;
            float var_15 = var_13.mem_1;
            long long int var_16 = (var_5 + 16);
            return method_15(var_0, var_1, var_2, var_14, var_15, var_16);
        } else {
            return make_Tuple1(var_3, var_4);
        }
    }
    __device__ Tuple1 method_16(Tuple1 var_0, Tuple1 var_1) {
        float var_2 = var_0.mem_0;
        float var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        float var_5 = var_1.mem_1;
        char var_6 = (var_2 > var_4);
        Tuple1 var_7;
        if (var_6) {
            var_7 = make_Tuple1(var_2, var_3);
        } else {
            var_7 = make_Tuple1(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        float var_9 = var_7.mem_1;
        return make_Tuple1(var_8, var_9);
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
and Env2 =
    struct
    val mem_0: Env3
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env3 =
    struct
    val mem_0: (Union0 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Union4 =
    | Union4Case0 of Tuple5
    | Union4Case1
and Tuple5 =
    struct
    val mem_0: float32
    new(arg_mem_0) = {mem_0 = arg_mem_0}
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
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env3 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env2) = var_1.Peek()
        let (var_7: Env3) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env3), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env3) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_5((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_17((var_0: (int64 [])), (var_1: int64), (var_2: int64)): int64 =
    let (var_3: bool) = (var_2 < var_1)
    if var_3 then
        let (var_4: int64) = var_0.[int32 var_2]
        let (var_5: int64) = (var_2 + 1L)
        method_18((var_0: (int64 [])), (var_1: int64), (var_4: int64), (var_5: int64))
    else
        0L
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env3), (var_6: int64)): Env3 =
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
    let (var_19: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_18))))
    var_4.Push((Env2((Env3(var_19)), var_3)))
    (Env3(var_19))
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env3 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_8))))
    var_3.Push((Env2((Env3(var_9)), var_2)))
    (Env3(var_9))
and method_18((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: int64) = var_0.[int32 var_3]
        let (var_6: int64) = (var_2 + var_5)
        let (var_7: int64) = (var_3 + 1L)
        method_18((var_0: (int64 [])), (var_1: int64), (var_6: int64), (var_7: int64))
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
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
let (var_46: ManagedCuda.BasicTypes.SizeT) = var_45.Pointer
let (var_47: uint64) = uint64 var_46
let (var_48: uint64) = uint64 var_40
let (var_49: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_50: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_51: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_50)
let (var_52: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_51.SetStream(var_52)
let (var_53: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_54: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_55: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_53, var_54)
let (var_56: ManagedCuda.CudaBlas.CudaBlasHandle) = var_55.get_CublasHandle()
let (var_57: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_55.set_Stream(var_57)
let (var_58: int64) = 2048L
let (var_59: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_58: int64))
let (var_60: (Union0 ref)) = var_59.mem_0
let (var_61: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_62: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_63: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2048L)
var_1.ClearMemoryAsync(var_61, 0uy, var_63, var_62)
let (var_64: int64) = 2048L
let (var_65: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_64: int64))
let (var_66: (Union0 ref)) = var_65.mem_0
let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_66: (Union0 ref)))
let (var_68: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(2048L)
var_1.ClearMemoryAsync(var_67, 0uy, var_69, var_68)
let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_66: (Union0 ref)))
let (var_74: int64) = 16L
let (var_75: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_74: int64))
let (var_76: (Union0 ref)) = var_75.mem_0
let (var_77: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_76: (Union0 ref)))
// Cuda join point
// method_6((var_70: ManagedCuda.BasicTypes.CUdeviceptr), (var_71: ManagedCuda.BasicTypes.CUdeviceptr), (var_77: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_79: (System.Object [])) = [|var_70; var_71; var_77|]: (System.Object [])
let (var_80: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_6", var_32, var_1)
let (var_81: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(4u, 1u, 1u)
var_80.set_GridDimensions(var_81)
let (var_82: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_80.set_BlockDimensions(var_82)
let (var_83: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_80.RunAsync(var_83, var_79)
let (var_85: (Union4 ref)) = (ref Union4Case1)
let (var_86: (float32 ref)) = (ref 0.000000f)
let (var_88: (Union4 ref)) = (ref Union4Case1)
let (var_89: (float32 ref)) = (ref 0.000000f)
let (var_92: int64) = 256L
let (var_93: Env3) = method_2((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_92: int64))
let (var_94: (Union0 ref)) = var_93.mem_0
let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_60: (Union0 ref)))
let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_66: (Union0 ref)))
let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_94: (Union0 ref)))
// Cuda join point
// method_13((var_95: ManagedCuda.BasicTypes.CUdeviceptr), (var_96: ManagedCuda.BasicTypes.CUdeviceptr), (var_97: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_99: (System.Object [])) = [|var_95; var_96; var_97|]: (System.Object [])
let (var_100: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_32, var_1)
let (var_101: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 32u, 1u)
var_100.set_GridDimensions(var_101)
let (var_102: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(16u, 1u, 1u)
var_100.set_BlockDimensions(var_102)
let (var_103: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_100.RunAsync(var_103, var_99)
let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_5((var_94: (Union0 ref)))
let (var_105: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(32L))
var_1.CopyToHost(var_105, var_104)
var_1.Synchronize()
let (var_106: int64) = var_105.LongLength
let (var_107: int64) = 0L
let (var_108: int64) = method_17((var_105: (int64 [])), (var_106: int64), (var_107: int64))
var_94 := Union0Case1
let (var_109: string) = System.String.Format("{0}",var_108)
let (var_110: string) = String.concat ", " [|"Accuracy is:"; var_109|]
let (var_111: string) = System.String.Format("[{0}]",var_110)
System.Console.WriteLine(var_111)
var_76 := Union0Case1
var_66 := Union0Case1
var_60 := Union0Case1
var_55.Dispose()
var_51.Dispose()
var_49.Dispose()
let (var_112: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_112)
var_43 := Union0Case1
var_1.Dispose()

