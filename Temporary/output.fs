module SpiralExample.Main
let cuda_kernels = """
extern "C" {
    typedef long long int(*FunPointer0)(long long int, long long int);
    __global__ void method_7(long long int * var_0, long long int * var_1);
    __device__ void method_8(long long int * var_0, long long int * var_1, long long int var_2);
    __device__ long long int method_6(long long int var_0, long long int var_1);
    
    __global__ void method_7(long long int * var_0, long long int * var_1) {
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
    __device__ void method_8(long long int * var_0, long long int * var_1, long long int var_2) {
        if ((var_2 < 8)) {
            long long int var_3 = var_1[var_2];
            FunPointer0 var_6 = method_6;
            long long int var_7 = var_6(var_3, var_3);
            var_0[var_2] = var_7;
            long long int var_8 = (var_2 + 4096);
            method_8(var_0, var_1, var_8);
        } else {
        }
    }
    __device__ long long int method_6(long long int var_0, long long int var_1) {
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
    mem_0: (int64 [])
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
and method_2((var_0: (int64 [])), (var_1: int64), (var_2: int64)): int64 =
    if (var_1 <= 7L) then
        var_0.[int32 var_2] <- var_1
        let (var_3: int64) = (var_2 + 1L)
        let (var_4: int64) = (var_1 + 1L)
        method_2((var_0: (int64 [])), (var_4: int64), (var_3: int64))
    else
        var_2
and method_3((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_4((var_11: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: int64))
        | Union0Case1 ->
            let (var_13: Env3) = var_1.Pop()
            let (var_14: EnvStack2) = var_13.mem_0
            let (var_15: int64) = var_13.mem_1
            method_3((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_5((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
and method_9((var_0: (int64 []))): string =
    let (var_1: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_2: System.Text.StringBuilder) = var_1.Append("[|")
    let (var_3: int64) = var_0.LongLength
    let (var_4: int64) = 0L
    let (var_5: string) = method_10((var_0: (int64 [])), (var_1: System.Text.StringBuilder), (var_3: int64), (var_4: int64))
    let (var_6: System.Text.StringBuilder) = var_1.Append("|]")
    var_1.ToString()
and method_4((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64(var_7)
    let (var_9: uint64) = uint64(var_6)
    let (var_10: uint64) = (var_8 - var_1)
    let (var_11: uint64) = (var_10 + var_9)
    let (var_12: uint64) = uint64(var_3)
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
and method_5((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: uint64) = uint64(var_3)
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
and method_10((var_0: (int64 [])), (var_1: System.Text.StringBuilder), (var_2: int64), (var_3: int64)): string =
    if (var_3 < var_2) then
        let (var_4: int64) = var_0.[int32 var_3]
        let (var_5: System.Text.StringBuilder) = var_1.Append("")
        let (var_6: string) = System.Convert.ToString(var_4)
        let (var_7: System.Text.StringBuilder) = var_1.Append(var_6)
        let (var_8: int64) = (var_3 + 1L)
        method_11((var_0: (int64 [])), (var_1: System.Text.StringBuilder), (var_2: int64), (var_8: int64))
    else
        ""
and method_11((var_0: (int64 [])), (var_1: System.Text.StringBuilder), (var_2: int64), (var_3: int64)): string =
    if (var_3 < var_2) then
        let (var_4: int64) = var_0.[int32 var_3]
        let (var_5: System.Text.StringBuilder) = var_1.Append("; ")
        let (var_6: string) = System.Convert.ToString(var_4)
        let (var_7: System.Text.StringBuilder) = var_1.Append(var_6)
        let (var_8: int64) = (var_3 + 1L)
        method_11((var_0: (int64 [])), (var_1: System.Text.StringBuilder), (var_2: int64), (var_8: int64))
    else
        "; "
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
var_5.ErrorDataReceived.Add(var_7)
let (var_8: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Auxiliary\\Build\\vcvarsx86_amd64.bat")
let (var_9: int64) = (int64 var_8.Length)
let (var_10: int64) = (12L + var_9)
let (var_11: int32) = (int32 var_10)
let (var_12: System.Text.StringBuilder) = System.Text.StringBuilder(var_11)
let (var_13: System.Text.StringBuilder) = var_12.Append('"')
let (var_14: System.Text.StringBuilder) = var_13.Append(var_8)
let (var_15: System.Text.StringBuilder) = var_14.Append('"')
let (var_16: string) = var_15.ToString()
let (var_17: string) = System.IO.Path.Combine("C:\\Program Files (x86)\\Microsoft Visual Studio\\2017\\Community", "VC\\Tools\\MSVC\\14.11.25503\\bin\\Hostx64\\x64")
let (var_18: int64) = (int64 var_17.Length)
let (var_19: int64) = (12L + var_18)
let (var_20: int32) = (int32 var_19)
let (var_21: System.Text.StringBuilder) = System.Text.StringBuilder(var_20)
let (var_22: System.Text.StringBuilder) = var_21.Append('"')
let (var_23: System.Text.StringBuilder) = var_22.Append(var_17)
let (var_24: System.Text.StringBuilder) = var_23.Append('"')
let (var_25: string) = var_24.ToString()
let (var_26: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v8.0", "include")
let (var_27: int64) = (int64 var_26.Length)
let (var_28: int64) = (12L + var_27)
let (var_29: int32) = (int32 var_28)
let (var_30: System.Text.StringBuilder) = System.Text.StringBuilder(var_29)
let (var_31: System.Text.StringBuilder) = var_30.Append('"')
let (var_32: System.Text.StringBuilder) = var_31.Append(var_26)
let (var_33: System.Text.StringBuilder) = var_32.Append('"')
let (var_34: string) = var_33.ToString()
let (var_35: string) = System.IO.Path.Combine("C:\\Program Files\\NVIDIA GPU Computing Toolkit\\CUDA\\v8.0", "bin\\nvcc.exe")
let (var_36: int64) = (int64 var_35.Length)
let (var_37: int64) = (12L + var_36)
let (var_38: int32) = (int32 var_37)
let (var_39: System.Text.StringBuilder) = System.Text.StringBuilder(var_38)
let (var_40: System.Text.StringBuilder) = var_39.Append('"')
let (var_41: System.Text.StringBuilder) = var_40.Append(var_35)
let (var_42: System.Text.StringBuilder) = var_41.Append('"')
let (var_43: string) = var_42.ToString()
let (var_44: System.Text.StringBuilder) = System.Text.StringBuilder(24)
let (var_45: System.Text.StringBuilder) = var_44.Append('"')
let (var_46: System.Text.StringBuilder) = var_45.Append("C:\\cub-1.7.4")
let (var_47: System.Text.StringBuilder) = var_46.Append('"')
let (var_48: string) = var_47.ToString()
let (var_49: int64) = (int64 var_2.Length)
let (var_50: int64) = (12L + var_49)
let (var_51: int32) = (int32 var_50)
let (var_52: System.Text.StringBuilder) = System.Text.StringBuilder(var_51)
let (var_53: System.Text.StringBuilder) = var_52.Append('"')
let (var_54: System.Text.StringBuilder) = var_53.Append(var_2)
let (var_55: System.Text.StringBuilder) = var_54.Append('"')
let (var_56: string) = var_55.ToString()
let (var_57: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_58: int64) = (int64 var_57.Length)
let (var_59: int64) = (12L + var_58)
let (var_60: int32) = (int32 var_59)
let (var_61: System.Text.StringBuilder) = System.Text.StringBuilder(var_60)
let (var_62: System.Text.StringBuilder) = var_61.Append('"')
let (var_63: System.Text.StringBuilder) = var_62.Append(var_57)
let (var_64: System.Text.StringBuilder) = var_63.Append('"')
let (var_65: string) = var_64.ToString()
let (var_66: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_67: int64) = (int64 var_66.Length)
let (var_68: int64) = (12L + var_67)
let (var_69: int32) = (int32 var_68)
let (var_70: System.Text.StringBuilder) = System.Text.StringBuilder(var_69)
let (var_71: System.Text.StringBuilder) = var_70.Append('"')
let (var_72: System.Text.StringBuilder) = var_71.Append(var_66)
let (var_73: System.Text.StringBuilder) = var_72.Append('"')
let (var_74: string) = var_73.ToString()
let (var_75: bool) = System.IO.File.Exists(var_66)
if var_75 then
    System.IO.File.Delete(var_66)
else
    ()
System.IO.File.WriteAllText(var_66, var_0)
let (var_76: bool) = System.IO.File.Exists(var_3)
if var_76 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_77: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_78: System.IO.Stream) = (var_77 :> System.IO.Stream)
let (var_79: System.IO.StreamWriter) = System.IO.StreamWriter(var_78)
let (var_80: int64) = (int64 var_16.Length)
let (var_81: int64) = (5L + var_80)
let (var_82: int32) = (int32 var_81)
let (var_83: System.Text.StringBuilder) = System.Text.StringBuilder(var_82)
let (var_84: System.Text.StringBuilder) = var_83.Append("call ")
let (var_85: System.Text.StringBuilder) = var_84.Append(var_16)
let (var_86: string) = var_85.ToString()
var_79.WriteLine(var_86)
let (var_87: int64) = (int64 var_43.Length)
let (var_88: int64) = (int64 var_25.Length)
let (var_89: int64) = (var_87 + var_88)
let (var_90: int64) = (int64 var_34.Length)
let (var_91: int64) = (var_89 + var_90)
let (var_92: int64) = (int64 var_48.Length)
let (var_93: int64) = (var_91 + var_92)
let (var_94: int64) = (int64 var_56.Length)
let (var_95: int64) = (var_93 + var_94)
let (var_96: int64) = (int64 var_65.Length)
let (var_97: int64) = (var_95 + var_96)
let (var_98: int64) = (int64 var_74.Length)
let (var_99: int64) = (var_97 + var_98)
let (var_100: int64) = (173L + var_99)
let (var_101: int32) = (int32 var_100)
let (var_102: System.Text.StringBuilder) = System.Text.StringBuilder(var_101)
let (var_103: System.Text.StringBuilder) = var_102.Append(var_43)
let (var_104: System.Text.StringBuilder) = var_103.Append(" -gencode=arch=compute_30,code=\\\"sm_30,compute_30\\\" --use-local-env --cl-version 2017 -ccbin ")
let (var_105: System.Text.StringBuilder) = var_104.Append(var_25)
let (var_106: System.Text.StringBuilder) = var_105.Append("  -I")
let (var_107: System.Text.StringBuilder) = var_106.Append(var_34)
let (var_108: System.Text.StringBuilder) = var_107.Append(" -I")
let (var_109: System.Text.StringBuilder) = var_108.Append(var_48)
let (var_110: System.Text.StringBuilder) = var_109.Append(" --keep-dir ")
let (var_111: System.Text.StringBuilder) = var_110.Append(var_56)
let (var_112: System.Text.StringBuilder) = var_111.Append(" -maxrregcount=0  --machine 64 -ptx -cudart static  -o ")
let (var_113: System.Text.StringBuilder) = var_112.Append(var_65)
let (var_114: System.Text.StringBuilder) = var_113.Append(' ')
let (var_115: System.Text.StringBuilder) = var_114.Append(var_74)
let (var_116: string) = var_115.ToString()
var_79.WriteLine(var_116)
var_79.Dispose()
var_77.Dispose()
let (var_117: bool) = var_5.Start()
if (var_117 = false) then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_118: int32) = var_5.get_ExitCode()
if (var_118 <> 0) then
    let (var_119: System.Text.StringBuilder) = System.Text.StringBuilder(40)
    let (var_120: System.Text.StringBuilder) = var_119.Append("NVCC failed compilation with code ")
    let (var_121: System.Text.StringBuilder) = var_120.Append(var_118)
    let (var_122: string) = var_121.ToString()
    (failwith var_122)
else
    ()
let (var_123: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_57)
var_5.Dispose()
let (var_124: int64) = (51L + var_49)
let (var_125: int32) = (int32 var_124)
let (var_126: System.Text.StringBuilder) = System.Text.StringBuilder(var_125)
let (var_127: System.Text.StringBuilder) = var_126.Append("Compiled the kernels into the following directory: ")
let (var_128: System.Text.StringBuilder) = var_127.Append(var_2)
let (var_129: string) = var_128.ToString()
System.Console.WriteLine(var_129)
let (var_130: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_131: ManagedCuda.BasicTypes.SizeT) = var_130.get_TotalGlobalMemory()
let (var_132: int64) = int64(var_131)
let (var_133: float) = Microsoft.FSharp.Core.Operators.float(var_132)
let (var_134: float) = (0.700000 * var_133)
let (var_135: int64) = int64(var_134)
let (var_136: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_135)
let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_136)
let (var_138: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_137))))
let (var_139: EnvStack2) = EnvStack2((var_138: (Union0 ref)))
let (var_140: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_141: (Union0 ref)) = var_139.mem_0
let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
let (var_143: ManagedCuda.BasicTypes.SizeT) = var_142.Pointer
let (var_144: uint64) = uint64(var_143)
let (var_145: uint64) = uint64(var_135)
let (var_146: EnvStack4) = EnvStack4((var_144: uint64), (var_145: uint64), (var_140: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext))
let (var_147: uint64) = var_146.mem_0
let (var_148: uint64) = var_146.mem_1
let (var_149: System.Collections.Generic.Stack<Env3>) = var_146.mem_2
let (var_150: ManagedCuda.CudaContext) = var_146.mem_3
let (var_151: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_152: int64) = 0L
let (var_153: int64) = 0L
let (var_154: int64) = method_2((var_151: (int64 [])), (var_153: int64), (var_152: int64))
let (var_155: EnvHeap5) = ({mem_0 = (var_151: (int64 []))} : EnvHeap5)
let (var_156: (int64 [])) = var_155.mem_0
let (var_157: int64) = var_156.LongLength
let (var_158: int64) = (int64 sizeof<int64>)
let (var_159: int64) = (var_157 * var_158)
let (var_160: EnvStack2) = method_3((var_147: uint64), (var_149: System.Collections.Generic.Stack<Env3>), (var_148: uint64), (var_159: int64))
let (var_161: (Union0 ref)) = var_160.mem_0
let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
var_150.CopyToDevice(var_162, var_156)
let (var_167: int64) = (8L * var_158)
let (var_168: EnvStack2) = method_3((var_147: uint64), (var_149: System.Collections.Generic.Stack<Env3>), (var_148: uint64), (var_167: int64))
let (var_169: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
let (var_170: (Union0 ref)) = var_168.mem_0
let (var_171: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_170: (Union0 ref)))
// Cuda join point
// method_7((var_169: ManagedCuda.BasicTypes.CUdeviceptr), (var_171: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_172: (System.Object [])) = Array.zeroCreate<System.Object> (System.Convert.ToInt32(2L))
var_172.[int32 0L] <- (var_171 :> System.Object)
var_172.[int32 1L] <- (var_169 :> System.Object)
let (var_173: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_7", var_123, var_1)
let (var_174: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
var_173.set_GridDimensions(var_174)
let (var_175: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_173.set_BlockDimensions(var_175)
let (var_176: float32) = var_173.Run(var_172)
let (var_177: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_170: (Union0 ref)))
let (var_178: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
var_150.CopyToHost(var_178, var_177)
var_150.Synchronize()
let (var_179: string) = method_9((var_178: (int64 [])))
System.Console.WriteLine(var_179)
var_170 := Union0Case1
var_161 := Union0Case1

