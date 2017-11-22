module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_7(float * var_0, float * var_1);
    __device__ float method_8(float * var_0, long long int var_1, float var_2);
    __device__ float method_9(float var_0, float var_1);
    
    __global__ void method_7(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        long long int var_10 = (var_9 + 256);
        float var_11 = var_0[var_9];
        float var_12 = method_8(var_0, var_10, var_11);
        FunPointer0 var_15 = method_9;
        float var_16 = cub::BlockReduce<float,128>().Reduce(var_12, var_15);
        if ((var_2 == 0)) {
            var_1[var_5] = var_16;
        } else {
        }
    }
    __device__ float method_8(float * var_0, long long int var_1, float var_2) {
        if ((var_1 < 256)) {
            float var_3 = var_0[var_1];
            float var_4 = (var_2 + var_3);
            long long int var_5 = (var_1 + 256);
            return method_8(var_0, var_5, var_4);
        } else {
            return var_2;
        }
    }
    __device__ float method_9(float var_0, float var_1) {
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
and EnvStack5 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    val mem_2: System.Collections.Generic.Stack<Env4>
    val mem_3: ManagedCuda.CudaContext
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvHeap6 =
    {
    mem_0: (float32 [])
    }
and EnvHeap7 =
    {
    mem_0: (float32 [])
    }
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    System.Console.WriteLine(var_1)
and method_1((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        let (var_3: Tuple1) = var_2.mem_0
        var_3.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_2((var_0: (float32 [])), (var_1: int64), (var_2: int64)): int64 =
    if (var_1 <= 31L) then
        let (var_3: float32) = (float32 var_1)
        var_0.[int32 var_2] <- var_3
        let (var_4: int64) = (var_2 + 1L)
        let (var_5: int64) = (var_1 + 1L)
        method_2((var_0: (float32 [])), (var_5: int64), (var_4: int64))
    else
        var_2
and method_3((var_0: (float32 [])), (var_1: int64), (var_2: int64)): int64 =
    if (var_1 <= 255L) then
        let (var_3: float32) = (float32 var_1)
        var_0.[int32 var_2] <- var_3
        let (var_4: int64) = (var_2 + 1L)
        let (var_5: int64) = (var_1 + 1L)
        method_3((var_0: (float32 [])), (var_5: int64), (var_4: int64))
    else
        var_2
and method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64)): EnvStack3 =
    let (var_4: int32) = var_1.get_Count()
    if (var_4 > 0) then
        let (var_5: Env4) = var_1.Peek()
        let (var_6: EnvStack3) = var_5.mem_0
        let (var_7: int64) = var_5.mem_1
        let (var_8: (Union0 ref)) = var_6.mem_0
        let (var_9: Union0) = (!var_8)
        match var_9 with
        | Union0Case0(var_10) ->
            let (var_11: Tuple1) = var_10.mem_0
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_5((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env4>), (var_6: EnvStack3), (var_7: int64))
        | Union0Case1 ->
            let (var_14: Env4) = var_1.Pop()
            let (var_15: EnvStack3) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64))
    else
        method_6((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64))
and method_10((var_0: (float32 [])), (var_1: int64), (var_2: float32)): float32 =
    if (var_1 < 2L) then
        let (var_3: float32) = var_0.[int32 var_1]
        let (var_4: float32) = (var_2 + var_3)
        let (var_5: int64) = (var_1 + 1L)
        method_10((var_0: (float32 [])), (var_5: int64), (var_4: float32))
    else
        var_2
and method_5((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env4>), (var_5: EnvStack3), (var_6: int64)): EnvStack3 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: uint64) = (var_8 - var_1)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: uint64) = uint64 var_3
    let (var_13: uint64) = (var_12 + var_11)
    let (var_14: bool) = (var_13 <= var_2)
    if var_14 then
        ()
    else
        (failwith "Cache size has been exceeded in the allocator.")
    let (var_15: uint64) = (var_8 + var_9)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_17)))))
    let (var_19: EnvStack3) = EnvStack3((var_18: (Union0 ref)))
    var_4.Push((Env4(var_19, var_3)))
    var_19
and method_6((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64)): EnvStack3 =
    let (var_4: uint64) = uint64 var_3
    let (var_5: bool) = (var_4 <= var_2)
    if var_5 then
        ()
    else
        (failwith "Cache size has been exceeded in the allocator.")
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_7)))))
    let (var_9: EnvStack3) = EnvStack3((var_8: (Union0 ref)))
    var_1.Push((Env4(var_9, var_3)))
    var_9
let (var_0: string) = cuda_kernels
let (var_1: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
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
let (var_8: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Auxiliary\\Build\\vcvarsx86_amd64.bat")
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
let (var_19: int64) = (int64 var_8.Length)
let (var_20: int64) = (17L + var_19)
let (var_21: int32) = (int32 var_20)
let (var_22: System.Text.StringBuilder) = System.Text.StringBuilder(var_21)
let (var_23: System.Text.StringBuilder) = var_22.Append("CALL ")
let (var_24: System.Text.StringBuilder) = var_23.Append('"')
let (var_25: System.Text.StringBuilder) = var_24.Append(var_8)
let (var_26: System.Text.StringBuilder) = var_25.Append('"')
let (var_27: string) = var_26.ToString()
var_18.WriteLine(var_27)
let (var_28: int64) = (int64 var_9.Length)
let (var_29: int64) = (28L + var_28)
let (var_30: int32) = (int32 var_29)
let (var_31: System.Text.StringBuilder) = System.Text.StringBuilder(var_30)
let (var_32: System.Text.StringBuilder) = var_31.Append("SET PATH=%PATH%;")
let (var_33: System.Text.StringBuilder) = var_32.Append('"')
let (var_34: System.Text.StringBuilder) = var_33.Append(var_9)
let (var_35: System.Text.StringBuilder) = var_34.Append('"')
let (var_36: string) = var_35.ToString()
var_18.WriteLine(var_36)
let (var_37: int64) = (int64 var_12.Length)
let (var_38: int64) = (int64 var_10.Length)
let (var_39: int64) = (var_37 + var_38)
let (var_40: int64) = (int64 var_11.Length)
let (var_41: int64) = (var_39 + var_40)
let (var_42: int64) = (int64 var_2.Length)
let (var_43: int64) = (var_41 + var_42)
let (var_44: int64) = (int64 var_13.Length)
let (var_45: int64) = (var_43 + var_44)
let (var_46: int64) = (int64 var_14.Length)
let (var_47: int64) = (var_45 + var_46)
let (var_48: int64) = (263L + var_47)
let (var_49: int32) = (int32 var_48)
let (var_50: System.Text.StringBuilder) = System.Text.StringBuilder(var_49)
let (var_51: System.Text.StringBuilder) = var_50.Append('"')
let (var_52: System.Text.StringBuilder) = var_51.Append(var_12)
let (var_53: System.Text.StringBuilder) = var_52.Append('"')
let (var_54: System.Text.StringBuilder) = var_53.Append(" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017")
let (var_55: System.Text.StringBuilder) = var_54.Append(" -I")
let (var_56: System.Text.StringBuilder) = var_55.Append('"')
let (var_57: System.Text.StringBuilder) = var_56.Append(var_10)
let (var_58: System.Text.StringBuilder) = var_57.Append('"')
let (var_59: System.Text.StringBuilder) = var_58.Append(" -I")
let (var_60: System.Text.StringBuilder) = var_59.Append('"')
let (var_61: System.Text.StringBuilder) = var_60.Append("C:\\cub-1.7.4")
let (var_62: System.Text.StringBuilder) = var_61.Append('"')
let (var_63: System.Text.StringBuilder) = var_62.Append(" -I")
let (var_64: System.Text.StringBuilder) = var_63.Append('"')
let (var_65: System.Text.StringBuilder) = var_64.Append(var_11)
let (var_66: System.Text.StringBuilder) = var_65.Append('"')
let (var_67: System.Text.StringBuilder) = var_66.Append(" --keep-dir ")
let (var_68: System.Text.StringBuilder) = var_67.Append('"')
let (var_69: System.Text.StringBuilder) = var_68.Append(var_2)
let (var_70: System.Text.StringBuilder) = var_69.Append('"')
let (var_71: System.Text.StringBuilder) = var_70.Append(" -maxrregcount=0  --machine 64 -ptx -cudart static  -o ")
let (var_72: System.Text.StringBuilder) = var_71.Append('"')
let (var_73: System.Text.StringBuilder) = var_72.Append(var_13)
let (var_74: System.Text.StringBuilder) = var_73.Append('"')
let (var_75: System.Text.StringBuilder) = var_74.Append(' ')
let (var_76: System.Text.StringBuilder) = var_75.Append('"')
let (var_77: System.Text.StringBuilder) = var_76.Append(var_14)
let (var_78: System.Text.StringBuilder) = var_77.Append('"')
let (var_79: string) = var_78.ToString()
var_18.WriteLine(var_79)
var_18.Dispose()
var_17.Dispose()
let (var_80: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_81: bool) = var_5.Start()
if (var_81 = false) then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_82: int32) = var_5.get_ExitCode()
if (var_82 <> 0) then
    let (var_83: System.Text.StringBuilder) = System.Text.StringBuilder(40)
    let (var_84: System.Text.StringBuilder) = var_83.Append("NVCC failed compilation with code ")
    let (var_85: System.Text.StringBuilder) = var_84.Append(var_82)
    let (var_86: string) = var_85.ToString()
    (failwith var_86)
else
    ()
let (var_87: System.TimeSpan) = var_80.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_87
let (var_88: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_89: int64) = (51L + var_42)
let (var_90: int32) = (int32 var_89)
let (var_91: System.Text.StringBuilder) = System.Text.StringBuilder(var_90)
let (var_92: System.Text.StringBuilder) = var_91.Append("Compiled the kernels into the following directory: ")
let (var_93: System.Text.StringBuilder) = var_92.Append(var_2)
let (var_94: string) = var_93.ToString()
System.Console.WriteLine(var_94)
let (var_95: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_96: ManagedCuda.BasicTypes.SizeT) = var_95.get_TotalGlobalMemory()
let (var_97: int64) = int64 var_96
let (var_98: float) = float var_97
let (var_99: float) = (0.700000 * var_98)
let (var_100: int64) = int64 var_99
let (var_101: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_100)
let (var_102: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_101)
let (var_103: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_102)))))
let (var_104: EnvStack3) = EnvStack3((var_103: (Union0 ref)))
let (var_105: System.Collections.Generic.Stack<Env4>) = System.Collections.Generic.Stack<Env4>()
let (var_106: (Union0 ref)) = var_104.mem_0
let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
let (var_108: ManagedCuda.BasicTypes.SizeT) = var_107.Pointer
let (var_109: uint64) = uint64 var_108
let (var_110: uint64) = uint64 var_100
let (var_111: EnvStack5) = EnvStack5((var_109: uint64), (var_110: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_1: ManagedCuda.CudaContext))
let (var_112: uint64) = var_111.mem_0
let (var_113: uint64) = var_111.mem_1
let (var_114: System.Collections.Generic.Stack<Env4>) = var_111.mem_2
let (var_115: ManagedCuda.CudaContext) = var_111.mem_3
let (var_116: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_117: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_116)
let (var_118: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_119: ManagedCuda.BasicTypes.CUstream) = var_118.get_Stream()
var_117.SetStream(var_119)
let (var_120: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
let (var_121: int64) = 0L
let (var_122: int64) = 0L
let (var_123: int64) = method_2((var_120: (float32 [])), (var_122: int64), (var_121: int64))
let (var_124: EnvHeap6) = ({mem_0 = (var_120: (float32 []))} : EnvHeap6)
let (var_125: float32) = 2.000000f
let (var_126: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(256L))
let (var_127: int64) = 0L
let (var_128: int64) = 0L
let (var_129: int64) = method_3((var_126: (float32 [])), (var_128: int64), (var_127: int64))
let (var_130: EnvHeap7) = ({mem_0 = (var_126: (float32 []))} : EnvHeap7)
let (var_131: (float32 [])) = var_130.mem_0
let (var_132: int64) = var_131.LongLength
let (var_133: int64) = (int64 sizeof<float32>)
let (var_134: int64) = (var_132 * var_133)
let (var_135: EnvStack3) = method_4((var_112: uint64), (var_114: System.Collections.Generic.Stack<Env4>), (var_113: uint64), (var_134: int64))
let (var_136: (Union0 ref)) = var_135.mem_0
let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_136: (Union0 ref)))
var_115.CopyToDevice(var_137, var_131)
let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_136: (Union0 ref)))
let (var_139: int64) = (2L * var_133)
let (var_140: EnvStack3) = method_4((var_112: uint64), (var_114: System.Collections.Generic.Stack<Env4>), (var_113: uint64), (var_139: int64))
let (var_141: (Union0 ref)) = var_140.mem_0
let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
// Cuda join point
// method_7((var_138: ManagedCuda.BasicTypes.CUdeviceptr), (var_142: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_143: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(2L))
var_143.[int32 0L] <- (var_138 :> System.Object)
var_143.[int32 1L] <- (var_142 :> System.Object)
let (var_144: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_7", var_88, var_1)
let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_144.set_GridDimensions(var_145)
let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_144.set_BlockDimensions(var_146)
let (var_147: ManagedCuda.BasicTypes.CUstream) = var_118.get_Stream()
var_144.RunAsync(var_147, var_143)
let (var_148: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
let (var_149: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(2L))
var_115.CopyToHost(var_149, var_148)
var_115.Synchronize()
let (var_150: float32) = var_149.[int32 0L]
let (var_151: int64) = 1L
let (var_152: float32) = method_10((var_149: (float32 [])), (var_151: int64), (var_150: float32))
System.Console.WriteLine(var_152)
var_141 := Union0Case1
var_136 := Union0Case1

