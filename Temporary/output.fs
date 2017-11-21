module SpiralExample.Main
let cuda_kernels = """
#include <cub/cub.cuh>
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
and EnvStack4 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    val mem_2: System.Collections.Generic.Stack<Env3>
    val mem_3: ManagedCuda.CudaContext
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and EnvHeap5 =
    {
    mem_0: (float32 [])
    }
and EnvHeap6 =
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
        var_2.mem_0
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
and method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: int32) = var_1.get_Count()
    if (var_4 > 0) then
        let (var_5: Env3) = var_1.Peek()
        let (var_6: EnvStack2) = var_5.mem_0
        let (var_7: int64) = var_5.mem_1
        let (var_8: (Union0 ref)) = var_6.mem_0
        let (var_9: Union0) = (!var_8)
        match var_9 with
        | Union0Case0(var_10) ->
            let (var_11: ManagedCuda.BasicTypes.CUdeviceptr) = var_10.mem_0
            method_5((var_11: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: int64))
        | Union0Case1 ->
            let (var_13: Env3) = var_1.Pop()
            let (var_14: EnvStack2) = var_13.mem_0
            let (var_15: int64) = var_13.mem_1
            method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_6((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
and method_10((var_0: (float32 [])), (var_1: int64), (var_2: float32)): float32 =
    if (var_1 < 2L) then
        let (var_3: float32) = var_0.[int32 var_1]
        let (var_4: float32) = (var_2 + var_3)
        let (var_5: int64) = (var_1 + 1L)
        method_10((var_0: (float32 [])), (var_5: int64), (var_4: float32))
    else
        var_2
and method_5((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
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
    let (var_18: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_17))))
    let (var_19: EnvStack2) = EnvStack2((var_18: (Union0 ref)))
    var_4.Push((Env3(var_19, var_3)))
    var_19
and method_6((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: uint64) = uint64 var_3
    let (var_5: bool) = (var_4 <= var_2)
    if var_5 then
        ()
    else
        (failwith "Cache size has been exceeded in the allocator.")
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_7))))
    let (var_9: EnvStack2) = EnvStack2((var_8: (Union0 ref)))
    var_1.Push((Env3(var_9, var_3)))
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
let (var_9: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\bin\\Hostx64\\x64\\cl.exe")
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
let (var_19: int64) = (int64 var_8.Length)
let (var_20: int64) = (17L + var_19)
let (var_21: int32) = (int32 var_20)
let (var_22: System.Text.StringBuilder) = System.Text.StringBuilder(var_21)
let (var_23: System.Text.StringBuilder) = var_22.Append("call ")
let (var_24: System.Text.StringBuilder) = var_23.Append('"')
let (var_25: System.Text.StringBuilder) = var_24.Append(var_8)
let (var_26: System.Text.StringBuilder) = var_25.Append('"')
let (var_27: string) = var_26.ToString()
var_18.WriteLine(var_27)
let (var_28: int64) = (int64 var_12.Length)
let (var_29: int64) = (int64 var_9.Length)
let (var_30: int64) = (var_28 + var_29)
let (var_31: int64) = (int64 var_10.Length)
let (var_32: int64) = (var_30 + var_31)
let (var_33: int64) = (int64 var_11.Length)
let (var_34: int64) = (var_32 + var_33)
let (var_35: int64) = (int64 var_2.Length)
let (var_36: int64) = (var_34 + var_35)
let (var_37: int64) = (int64 var_13.Length)
let (var_38: int64) = (var_36 + var_37)
let (var_39: int64) = (int64 var_14.Length)
let (var_40: int64) = (var_38 + var_39)
let (var_41: int64) = (283L + var_40)
let (var_42: int32) = (int32 var_41)
let (var_43: System.Text.StringBuilder) = System.Text.StringBuilder(var_42)
let (var_44: System.Text.StringBuilder) = var_43.Append('"')
let (var_45: System.Text.StringBuilder) = var_44.Append(var_12)
let (var_46: System.Text.StringBuilder) = var_45.Append('"')
let (var_47: System.Text.StringBuilder) = var_46.Append(" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -ccbin ")
let (var_48: System.Text.StringBuilder) = var_47.Append('"')
let (var_49: System.Text.StringBuilder) = var_48.Append(var_9)
let (var_50: System.Text.StringBuilder) = var_49.Append('"')
let (var_51: System.Text.StringBuilder) = var_50.Append(" -I")
let (var_52: System.Text.StringBuilder) = var_51.Append('"')
let (var_53: System.Text.StringBuilder) = var_52.Append(var_10)
let (var_54: System.Text.StringBuilder) = var_53.Append('"')
let (var_55: System.Text.StringBuilder) = var_54.Append(" -I")
let (var_56: System.Text.StringBuilder) = var_55.Append('"')
let (var_57: System.Text.StringBuilder) = var_56.Append("C:\\cub-1.7.4")
let (var_58: System.Text.StringBuilder) = var_57.Append('"')
let (var_59: System.Text.StringBuilder) = var_58.Append(" -I")
let (var_60: System.Text.StringBuilder) = var_59.Append('"')
let (var_61: System.Text.StringBuilder) = var_60.Append(var_11)
let (var_62: System.Text.StringBuilder) = var_61.Append('"')
let (var_63: System.Text.StringBuilder) = var_62.Append(" --keep-dir ")
let (var_64: System.Text.StringBuilder) = var_63.Append('"')
let (var_65: System.Text.StringBuilder) = var_64.Append(var_2)
let (var_66: System.Text.StringBuilder) = var_65.Append('"')
let (var_67: System.Text.StringBuilder) = var_66.Append(" -maxrregcount=0  --machine 64 -ptx -cudart static  -o ")
let (var_68: System.Text.StringBuilder) = var_67.Append('"')
let (var_69: System.Text.StringBuilder) = var_68.Append(var_13)
let (var_70: System.Text.StringBuilder) = var_69.Append('"')
let (var_71: System.Text.StringBuilder) = var_70.Append(' ')
let (var_72: System.Text.StringBuilder) = var_71.Append('"')
let (var_73: System.Text.StringBuilder) = var_72.Append(var_14)
let (var_74: System.Text.StringBuilder) = var_73.Append('"')
let (var_75: string) = var_74.ToString()
var_18.WriteLine(var_75)
var_18.Dispose()
var_17.Dispose()
let (var_76: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_77: bool) = var_5.Start()
if (var_77 = false) then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_78: int32) = var_5.get_ExitCode()
if (var_78 <> 0) then
    let (var_79: System.Text.StringBuilder) = System.Text.StringBuilder(40)
    let (var_80: System.Text.StringBuilder) = var_79.Append("NVCC failed compilation with code ")
    let (var_81: System.Text.StringBuilder) = var_80.Append(var_78)
    let (var_82: string) = var_81.ToString()
    (failwith var_82)
else
    ()
let (var_83: System.TimeSpan) = var_76.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_83
let (var_84: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_85: int64) = (51L + var_35)
let (var_86: int32) = (int32 var_85)
let (var_87: System.Text.StringBuilder) = System.Text.StringBuilder(var_86)
let (var_88: System.Text.StringBuilder) = var_87.Append("Compiled the kernels into the following directory: ")
let (var_89: System.Text.StringBuilder) = var_88.Append(var_2)
let (var_90: string) = var_89.ToString()
System.Console.WriteLine(var_90)
let (var_91: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_92: ManagedCuda.BasicTypes.SizeT) = var_91.get_TotalGlobalMemory()
let (var_93: int64) = int64 var_92
let (var_94: float) = float var_93
let (var_95: float) = (0.700000 * var_94)
let (var_96: int64) = int64 var_95
let (var_97: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_96)
let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_97)
let (var_99: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_98))))
let (var_100: EnvStack2) = EnvStack2((var_99: (Union0 ref)))
let (var_101: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_102: (Union0 ref)) = var_100.mem_0
let (var_103: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_102: (Union0 ref)))
let (var_104: ManagedCuda.BasicTypes.SizeT) = var_103.Pointer
let (var_105: uint64) = uint64 var_104
let (var_106: uint64) = uint64 var_96
let (var_107: EnvStack4) = EnvStack4((var_105: uint64), (var_106: uint64), (var_101: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext))
let (var_108: uint64) = var_107.mem_0
let (var_109: uint64) = var_107.mem_1
let (var_110: System.Collections.Generic.Stack<Env3>) = var_107.mem_2
let (var_111: ManagedCuda.CudaContext) = var_107.mem_3
let (var_112: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_113: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_112)
let (var_114: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_115: ManagedCuda.BasicTypes.CUstream) = var_114.get_Stream()
var_113.SetStream(var_115)
let (var_116: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
let (var_117: int64) = 0L
let (var_118: int64) = 0L
let (var_119: int64) = method_2((var_116: (float32 [])), (var_118: int64), (var_117: int64))
let (var_120: EnvHeap5) = ({mem_0 = (var_116: (float32 []))} : EnvHeap5)
let (var_121: float32) = 2.000000f
let (var_122: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(256L))
let (var_123: int64) = 0L
let (var_124: int64) = 0L
let (var_125: int64) = method_3((var_122: (float32 [])), (var_124: int64), (var_123: int64))
let (var_126: EnvHeap6) = ({mem_0 = (var_122: (float32 []))} : EnvHeap6)
let (var_127: (float32 [])) = var_126.mem_0
let (var_128: int64) = var_127.LongLength
let (var_129: int64) = (int64 sizeof<float32>)
let (var_130: int64) = (var_128 * var_129)
let (var_131: EnvStack2) = method_4((var_108: uint64), (var_110: System.Collections.Generic.Stack<Env3>), (var_109: uint64), (var_130: int64))
let (var_132: (Union0 ref)) = var_131.mem_0
let (var_133: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_132: (Union0 ref)))
var_111.CopyToDevice(var_133, var_127)
let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_132: (Union0 ref)))
let (var_135: int64) = (2L * var_129)
let (var_136: EnvStack2) = method_4((var_108: uint64), (var_110: System.Collections.Generic.Stack<Env3>), (var_109: uint64), (var_135: int64))
let (var_137: (Union0 ref)) = var_136.mem_0
let (var_138: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_137: (Union0 ref)))
// Cuda join point
// method_7((var_134: ManagedCuda.BasicTypes.CUdeviceptr), (var_138: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_139: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(2L))
var_139.[int32 0L] <- (var_134 :> System.Object)
var_139.[int32 1L] <- (var_138 :> System.Object)
let (var_140: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_7", var_84, var_1)
let (var_141: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_140.set_GridDimensions(var_141)
let (var_142: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_140.set_BlockDimensions(var_142)
let (var_143: ManagedCuda.BasicTypes.CUstream) = var_114.get_Stream()
var_140.RunAsync(var_143, var_139)
let (var_144: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_137: (Union0 ref)))
let (var_145: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(2L))
var_111.CopyToHost(var_145, var_144)
var_111.Synchronize()
let (var_146: float32) = var_145.[int32 0L]
let (var_147: int64) = 1L
let (var_148: float32) = method_10((var_145: (float32 [])), (var_147: int64), (var_146: float32))
var_132 := Union0Case1
var_148
