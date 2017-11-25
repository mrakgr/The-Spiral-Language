module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_7(float * var_0, float * var_1);
    __global__ void method_9(float * var_0, float * var_1, float * var_2);
    __device__ void method_8(float * var_0, float * var_1, long long int var_2);
    __device__ float method_10(float * var_0, float * var_1, long long int var_2, float var_3);
    __device__ float method_11(float var_0, float var_1);
    
    __global__ void method_7(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_8(var_0, var_1, var_9);
    }
    __global__ void method_9(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        long long int var_11 = (var_10 + 1280);
        float var_12 = var_0[var_10];
        float var_13 = var_1[var_10];
        float var_14 = (var_13 - var_12);
        float var_15 = (var_14 * var_14);
        float var_16 = method_10(var_0, var_1, var_11, var_15);
        FunPointer0 var_19 = method_11;
        float var_20 = cub::BlockReduce<float,128>().Reduce(var_16, var_19);
        if ((var_3 == 0)) {
            var_2[var_6] = var_20;
        } else {
        }
    }
    __device__ void method_8(float * var_0, float * var_1, long long int var_2) {
        if ((var_2 < 1280)) {
            float var_3 = var_0[var_2];
            float var_4 = (-var_3);
            float var_5 = exp(var_4);
            float var_6 = (1 + var_5);
            float var_7 = (1 / var_6);
            var_1[var_2] = var_7;
            long long int var_8 = (var_2 + 4096);
            method_8(var_0, var_1, var_8);
        } else {
        }
    }
    __device__ float method_10(float * var_0, float * var_1, long long int var_2, float var_3) {
        if ((var_2 < 1280)) {
            float var_4 = var_0[var_2];
            float var_5 = var_1[var_2];
            float var_6 = (var_5 - var_4);
            float var_7 = (var_6 * var_6);
            float var_8 = (var_3 + var_7);
            long long int var_9 = (var_2 + 1280);
            return method_10(var_0, var_1, var_9, var_8);
        } else {
            return var_3;
        }
    }
    __device__ float method_11(float var_0, float var_1) {
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
    mem_0: (float32 [])
    }
and EnvHeap6 =
    {
    mem_0: (float32 [])
    mem_1: int64
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
and method_3((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64)): int64 =
    if (var_2 <= var_1) then
        let (var_4: float32) = (float32 var_2)
        var_0.[int32 var_3] <- var_4
        let (var_5: int64) = (var_3 + 1L)
        let (var_6: int64) = (var_2 + 1L)
        method_3((var_0: (float32 [])), (var_1: int64), (var_6: int64), (var_5: int64))
    else
        var_3
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
and method_12((var_0: (float32 [])), (var_1: int64), (var_2: float32)): float32 =
    if (var_1 < 10L) then
        let (var_3: float32) = var_0.[int32 var_1]
        let (var_4: float32) = (var_2 + var_3)
        let (var_5: int64) = (var_1 + 1L)
        method_12((var_0: (float32 [])), (var_5: int64), (var_4: float32))
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
    if (var_14 = false) then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
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
    if (var_5 = false) then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    let (var_8: (Union0 ref)) = (ref (Union0Case0(Tuple2(Tuple1(var_7)))))
    let (var_9: EnvStack3) = EnvStack3((var_8: (Union0 ref)))
    var_1.Push((Env4(var_9, var_3)))
    var_9
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
let (var_111: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_112: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_111)
let (var_113: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_114: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_115: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_113, var_114)
let (var_116: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_117: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(32L))
let (var_118: int64) = 0L
let (var_119: int64) = 0L
let (var_120: int64) = method_2((var_117: (float32 [])), (var_119: int64), (var_118: int64))
let (var_121: EnvHeap5) = ({mem_0 = (var_117: (float32 []))} : EnvHeap5)
let (var_122: float32) = 2.000000f
let (var_123: int64) = 64L
let (var_124: int64) = (var_123 - 1L)
let (var_125: int64) = (var_124 + 1L)
let (var_126: int64) =
    if (0L > var_125) then
        0L
    else
        var_125
let (var_127: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_126))
let (var_128: int64) = 0L
let (var_129: int64) = 0L
let (var_130: int64) = method_3((var_127: (float32 [])), (var_124: int64), (var_129: int64), (var_128: int64))
let (var_131: EnvHeap6) = ({mem_0 = (var_127: (float32 [])); mem_1 = (var_124: int64)} : EnvHeap6)
let (var_132: float32) = sqrt 896.000000f
let (var_133: float32) = (1.000000f / var_132)
let (var_134: int64) = (int64 sizeof<float32>)
let (var_135: int64) = (98304L * var_134)
let (var_136: EnvStack3) = method_4((var_109: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_110: uint64), (var_135: int64))
let (var_137: ManagedCuda.BasicTypes.CUstream) = var_116.get_Stream()
var_112.SetStream(var_137)
let (var_138: (Union0 ref)) = var_136.mem_0
let (var_139: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_138: (Union0 ref)))
let (var_140: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(98304L)
var_112.GenerateNormal32(var_139, var_140, 0.000000f, var_133)
let (var_141: float32) = sqrt 778.000000f
let (var_142: float32) = (1.000000f / var_141)
let (var_143: int64) = (7680L * var_134)
let (var_144: EnvStack3) = method_4((var_109: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_110: uint64), (var_143: int64))
let (var_145: ManagedCuda.BasicTypes.CUstream) = var_116.get_Stream()
var_112.SetStream(var_145)
let (var_146: (Union0 ref)) = var_144.mem_0
let (var_147: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_146: (Union0 ref)))
let (var_148: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7680L)
var_112.GenerateNormal32(var_147, var_148, 0.000000f, var_142)
let (var_149: float32) = sqrt 138.000000f
let (var_150: float32) = (1.000000f / var_149)
let (var_151: int64) = (1280L * var_134)
let (var_152: EnvStack3) = method_4((var_109: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_110: uint64), (var_151: int64))
let (var_153: ManagedCuda.BasicTypes.CUstream) = var_116.get_Stream()
var_112.SetStream(var_153)
let (var_154: (Union0 ref)) = var_152.mem_0
let (var_155: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_154: (Union0 ref)))
let (var_156: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(1280L)
var_112.GenerateNormal32(var_155, var_156, 0.000000f, var_150)
let (var_157: EnvStack3) = method_4((var_109: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_110: uint64), (var_151: int64))
let (var_158: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_138: (Union0 ref)))
let (var_159: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_146: (Union0 ref)))
let (var_160: (Union0 ref)) = var_157.mem_0
let (var_161: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_160: (Union0 ref)))
let (var_162: ManagedCuda.BasicTypes.CUstream) = var_116.get_Stream()
var_115.set_Stream(var_162)
let (var_163: ManagedCuda.CudaBlas.CudaBlasHandle) = var_115.get_CublasHandle()
let (var_164: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_165: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
let (var_166: (float32 ref)) = (ref 1.000000f)
let (var_167: (float32 ref)) = (ref 0.000000f)
let (var_168: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_163, var_164, var_165, 128, 10, 768, var_166, var_158, 128, var_159, 768, var_167, var_161, 128)
if var_168 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_168)
let (var_172: EnvStack3) = method_4((var_109: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_110: uint64), (var_151: int64))
let (var_173: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_160: (Union0 ref)))
let (var_174: (Union0 ref)) = var_172.mem_0
let (var_175: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_174: (Union0 ref)))
// Cuda join point
// method_7((var_173: ManagedCuda.BasicTypes.CUdeviceptr), (var_175: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_176: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(2L))
var_176.[int32 0L] <- (var_173 :> System.Object)
var_176.[int32 1L] <- (var_175 :> System.Object)
let (var_177: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_7", var_88, var_1)
let (var_178: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
var_177.set_GridDimensions(var_178)
let (var_179: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_177.set_BlockDimensions(var_179)
let (var_180: ManagedCuda.BasicTypes.CUstream) = var_116.get_Stream()
var_177.RunAsync(var_180, var_176)
let (var_181: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_174: (Union0 ref)))
let (var_182: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_154: (Union0 ref)))
let (var_184: int64) = (10L * var_134)
let (var_185: EnvStack3) = method_4((var_109: uint64), (var_105: System.Collections.Generic.Stack<Env4>), (var_110: uint64), (var_184: int64))
let (var_186: (Union0 ref)) = var_185.mem_0
let (var_187: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_186: (Union0 ref)))
// Cuda join point
// method_9((var_181: ManagedCuda.BasicTypes.CUdeviceptr), (var_182: ManagedCuda.BasicTypes.CUdeviceptr), (var_187: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_188: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(3L))
var_188.[int32 0L] <- (var_181 :> System.Object)
var_188.[int32 1L] <- (var_182 :> System.Object)
var_188.[int32 2L] <- (var_187 :> System.Object)
let (var_189: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_9", var_88, var_1)
let (var_190: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 1u, 1u)
var_189.set_GridDimensions(var_190)
let (var_191: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_189.set_BlockDimensions(var_191)
let (var_192: ManagedCuda.BasicTypes.CUstream) = var_116.get_Stream()
var_189.RunAsync(var_192, var_188)
let (var_193: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_186: (Union0 ref)))
let (var_194: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10L))
var_1.CopyToHost(var_194, var_193)
var_1.Synchronize()
let (var_195: float32) = var_194.[int32 0L]
let (var_196: int64) = 1L
let (var_197: float32) = method_12((var_194: (float32 [])), (var_196: int64), (var_195: float32))
System.Console.WriteLine(var_197)
var_186 := Union0Case1
var_174 := Union0Case1
var_160 := Union0Case1
var_154 := Union0Case1
var_146 := Union0Case1
var_138 := Union0Case1
var_115.Dispose()
var_112.Dispose()
let (var_198: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
var_1.FreeMemory(var_198)
var_106 := Union0Case1
var_1.Dispose()

