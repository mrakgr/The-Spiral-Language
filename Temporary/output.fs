module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_13(float * var_0, long long int var_1, float * var_2);
    __global__ void method_15(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4);
    __device__ void method_14(float * var_0, long long int var_1, float * var_2, long long int var_3);
    __device__ float method_16(float * var_0, float * var_1, long long int var_2, long long int var_3, long long int var_4, float var_5);
    __device__ float method_17(float var_0, float var_1);
    
    __global__ void method_13(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        method_14(var_0, var_1, var_2, var_10);
    }
    __global__ void method_15(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = gridDim.x;
        long long int var_12 = (var_8 * 128);
        long long int var_13 = (var_12 + var_5);
        long long int var_14 = (var_11 * 128);
        float var_15 = 0;
        float var_16 = method_16(var_0, var_1, var_2, var_14, var_13, var_15);
        FunPointer0 var_19 = method_17;
        float var_20 = cub::BlockReduce<float,128>().Reduce(var_16, var_19);
        char var_21 = (var_5 == 0);
        if (var_21) {
            char var_22 = (var_8 >= 0);
            char var_24;
            if (var_22) {
                var_24 = (var_8 < var_4);
            } else {
                var_24 = 0;
            }
            char var_25 = (var_24 == 0);
            if (var_25) {
                // unprinted assert;
            } else {
            }
            float * var_26 = var_3 + var_8;
            var_26[0] = var_20;
        } else {
        }
    }
    __device__ void method_14(float * var_0, long long int var_1, float * var_2, long long int var_3) {
        char var_4 = (var_3 < var_1);
        if (var_4) {
            char var_5 = (var_3 >= 0);
            char var_6 = (var_5 == 0);
            if (var_6) {
                // unprinted assert;
            } else {
            }
            float * var_7 = var_2 + var_3;
            if (var_6) {
                // unprinted assert;
            } else {
            }
            float * var_8 = var_0 + var_3;
            float var_9 = var_8[0];
            float var_10 = (-var_9);
            float var_11 = exp(var_10);
            float var_12 = (1 + var_11);
            float var_13 = (1 / var_12);
            var_7[0] = var_13;
            long long int var_14 = (var_3 + 8192);
            method_14(var_0, var_1, var_2, var_14);
        } else {
        }
    }
    __device__ float method_16(float * var_0, float * var_1, long long int var_2, long long int var_3, long long int var_4, float var_5) {
        char var_6 = (var_4 < var_2);
        if (var_6) {
            char var_7 = (var_4 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            float * var_9 = var_0 + var_4;
            float * var_10 = var_1 + var_4;
            float var_11 = var_9[0];
            float var_12 = var_10[0];
            float var_13 = (var_12 - var_11);
            float var_14 = (var_13 * var_13);
            float var_15 = (var_5 + var_14);
            long long int var_16 = (var_4 + var_3);
            return method_16(var_0, var_1, var_2, var_3, var_16, var_15);
        } else {
            return var_5;
        }
    }
    __device__ float method_17(float var_0, float var_1) {
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
and Env4 =
    struct
    val mem_0: Env5
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env5 =
    struct
    val mem_0: Env6
    val mem_1: Tuple7
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env6 =
    struct
    val mem_0: (float32 [])
    val mem_1: Tuple9
    val mem_2: int64
    val mem_3: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2, arg_mem_3) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2; mem_3 = arg_mem_3}
    end
and Tuple7 =
    struct
    val mem_0: Env8
    val mem_1: Env8
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env8 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple9 =
    struct
    val mem_0: Env10
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env10 =
    struct
    val mem_0: int64
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Union11 =
    | Union11Case0 of Tuple12
    | Union11Case1
and Tuple12 =
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
and method_2((var_0: string)): Env4 =
    let (var_1: System.IO.FileMode) = System.IO.FileMode.Open
    let (var_2: System.IO.FileAccess) = System.IO.FileAccess.Read
    let (var_3: System.IO.FileShare) = System.IO.FileShare.Read
    let (var_4: System.IO.FileStream) = System.IO.File.Open(var_0, var_1, var_2, var_3)
    let (var_5: System.IO.BinaryReader) = System.IO.BinaryReader(var_4)
    let (var_6: int32) = var_5.ReadInt32()
    let (var_7: int32) = System.Net.IPAddress.NetworkToHostOrder(var_6)
    let (var_8: bool) = (var_7 = 2049)
    let (var_60: Env4) =
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
            method_3((var_12: (uint8 [])), (var_20: (float32 [])), (var_13: int64), (var_21: int64))
            (Env4((Env5((Env6(var_20, Tuple9((Env10(0L, 1L))), 0L, 10L)), Tuple7((Env8(0L, var_13)), (Env8(0L, 10L)))))))
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
            method_5((var_34: (uint8 [])), (var_39: int64), (var_38: int64), (var_58: (float32 [])), (var_59: int64))
            (Env4((Env5((Env6(var_58, Tuple9((Env10(0L, 1L))), 0L, var_39)), Tuple7((Env8(0L, var_38)), (Env8(0L, var_39)))))))
    let (var_61: Env5) = var_60.mem_0
    var_5.Dispose()
    var_4.Dispose()
    (Env4(var_61))
and method_7((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_8((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_7((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_9((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
and method_10((var_0: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_2: uint64) = uint64 var_1
    let (var_3: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_2)
    let (var_4: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_3)
    var_4
and method_11((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64)): float =
    let (var_20: bool) = (var_10 < var_11)
    if var_20 then
        let (var_21: int64) = (var_10 + 128L)
        let (var_22: bool) = (var_21 > var_11)
        let (var_23: int64) =
            if var_22 then
                var_11
            else
                var_21
        let (var_24: bool) = (var_10 < var_23)
        let (var_25: bool) = (var_24 = false)
        if var_25 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_26: int64) = (var_23 - var_10)
        let (var_27: int64) = (var_10 + var_10)
        let (var_28: int64) = (var_10 + var_23)
        let (var_29: bool) = (var_27 >= var_10)
        let (var_31: bool) =
            if var_29 then
                (var_27 < var_11)
            else
                false
        let (var_32: bool) = (var_31 = false)
        if var_32 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_33: bool) = (var_28 > var_10)
        let (var_35: bool) =
            if var_33 then
                (var_28 <= var_11)
            else
                false
        let (var_36: bool) = (var_35 = false)
        if var_36 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_37: int64) = (var_10 * var_9)
        if var_25 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_38: int64) = (var_16 + var_10)
        let (var_39: int64) = (var_16 + var_23)
        let (var_40: bool) = (var_38 >= var_16)
        let (var_42: bool) =
            if var_40 then
                (var_38 < var_17)
            else
                false
        let (var_43: bool) = (var_42 = false)
        if var_43 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_44: bool) = (var_39 > var_16)
        let (var_46: bool) =
            if var_44 then
                (var_39 <= var_17)
            else
                false
        let (var_47: bool) = (var_46 = false)
        if var_47 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_48: int64) = (var_10 * var_15)
        let (var_49: bool) = (var_26 > 0L)
        let (var_50: bool) = (var_49 = false)
        if var_50 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_51: int64) = (var_26 * 10L)
        let (var_52: int64) = (int64 sizeof<float32>)
        let (var_53: int64) = (var_51 * var_52)
        let (var_54: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_53: int64))
        let (var_55: bool) = (0L < var_26)
        let (var_56: bool) = (var_55 = false)
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_57: bool) = (var_12 < var_13)
        let (var_58: bool) = (var_57 = false)
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_59: int64) = (var_13 - var_12)
        let (var_60: int64) = (var_26 * var_59)
        let (var_61: (Union0 ref)) = var_8.mem_0
        let (var_62: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_61: (Union0 ref)))
        let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_37: int64), (var_62: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_64: (Union0 ref)) = var_7.mem_0
        let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_64: (Union0 ref)))
        let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_65: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_67: (Union0 ref)) = var_54.mem_0
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
        let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_68: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_70: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_6.set_Stream(var_70)
        let (var_71: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
        let (var_72: bool) = (var_59 = 784L)
        let (var_73: bool) = (var_72 = false)
        if var_73 then
            (failwith "Colums of a does not match rows of b in GEMM.")
        else
            ()
        let (var_74: bool) = (var_59 = 1L)
        let (var_75: bool) = (var_26 = 1L)
        let (var_76: bool) =
            if var_75 then
                true
            else
                var_74
        if var_76 then
            let (var_77: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
            let (var_78: (float32 ref)) = (ref 1.000000f)
            let (var_79: (float32 ref)) = (ref 0.000000f)
            let (var_80: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_71, var_77, 784, 10, var_78, var_66, 784, var_63, 1, var_79, var_69, 1)
            if var_80 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_80)
        else
            let (var_81: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_82: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_83: (float32 ref)) = (ref 1.000000f)
            let (var_84: (float32 ref)) = (ref 0.000000f)
            let (var_85: int32) = (int32 var_26)
            let (var_86: int32) = (int32 var_59)
            let (var_87: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_71, var_81, var_82, var_85, 10, var_86, var_83, var_63, var_85, var_66, var_86, var_84, var_69, var_85)
            if var_87 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_87)
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_88: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_53: int64))
        let (var_89: (Union0 ref)) = var_88.mem_0
        let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
        let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_90: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_92: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_93: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_53)
        var_3.ClearMemoryAsync(var_91, 0uy, var_93, var_92)
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_98: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_53: int64))
        let (var_99: bool) = (var_51 > 0L)
        let (var_100: bool) = (var_99 = false)
        if var_100 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_101: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
        let (var_102: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_101: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_100 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_103: (Union0 ref)) = var_98.mem_0
        let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_103: (Union0 ref)))
        let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_104: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_13((var_102: ManagedCuda.BasicTypes.CUdeviceptr), (var_51: int64), (var_105: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_107: (System.Object [])) = [|var_102; var_51; var_105|]: (System.Object [])
        let (var_108: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_4, var_3)
        let (var_109: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_108.set_GridDimensions(var_109)
        let (var_110: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_108.set_BlockDimensions(var_110)
        let (var_111: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_108.RunAsync(var_111, var_107)
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_112: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_53: int64))
        let (var_113: (Union0 ref)) = var_112.mem_0
        let (var_114: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_113: (Union0 ref)))
        let (var_115: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_114: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_56 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_116: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_117: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_53)
        var_3.ClearMemoryAsync(var_115, 0uy, var_117, var_116)
        let (var_118: bool) = (0L = var_18)
        let (var_120: bool) =
            if var_118 then
                (10L = var_19)
            else
                false
        let (var_121: bool) = (var_120 = false)
        if var_121 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_100 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_122: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_103: (Union0 ref)))
        let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_122: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_124: (Union0 ref)) = var_14.mem_0
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_124: (Union0 ref)))
        let (var_126: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_125: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_127: int64) = (var_51 - 1L)
        let (var_128: int64) = (var_127 / 128L)
        let (var_129: int64) = (var_128 + 1L)
        let (var_130: bool) = (64L > var_129)
        let (var_131: int64) =
            if var_130 then
                var_129
            else
                64L
        let (var_134: bool) = (var_131 > 0L)
        let (var_135: bool) = (var_134 = false)
        if var_135 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_136: int64) = (var_131 * var_52)
        let (var_137: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_136: int64))
        let (var_138: (Union0 ref)) = var_137.mem_0
        let (var_139: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_138: (Union0 ref)))
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_139: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_15((var_123: ManagedCuda.BasicTypes.CUdeviceptr), (var_126: ManagedCuda.BasicTypes.CUdeviceptr), (var_51: int64), (var_140: ManagedCuda.BasicTypes.CUdeviceptr), (var_131: int64))
        let (var_142: (System.Object [])) = [|var_123; var_126; var_51; var_140; var_131|]: (System.Object [])
        let (var_143: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_15", var_4, var_3)
        let (var_144: uint32) = (uint32 var_131)
        let (var_145: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_144, 1u, 1u)
        var_143.set_GridDimensions(var_145)
        let (var_146: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_143.set_BlockDimensions(var_146)
        let (var_147: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_143.RunAsync(var_147, var_142)
        let (var_149: (Union11 ref)) = (ref Union11Case1)
        let (var_150: (float32 ref)) = (ref 0.000000f)
        let (var_152: (Union11 ref)) = (ref Union11Case1)
        let (var_153: (float32 ref)) = (ref 0.000000f)
        let (var_154: float32) = method_22((var_26: int64), (var_137: EnvStack2), (var_131: int64), (var_3: ManagedCuda.CudaContext), (var_149: (Union11 ref)), (var_152: (Union11 ref)))
        let (var_155: string) = System.String.Format("{0}",var_23)
        let (var_156: string) = System.String.Format("{0} = {1}","near_to",var_155)
        let (var_157: string) = System.String.Format("{0}",var_10)
        let (var_158: string) = System.String.Format("{0} = {1}","from",var_157)
        let (var_159: string) = String.concat "; " [|var_158; var_156|]
        let (var_160: string) = System.String.Format("{0}{1}{2}","{",var_159,"}")
        let (var_161: string) = System.String.Format("On minibatch {0}. Error = {1}",var_160,var_154)
        let (var_162: string) = System.String.Format("{0}",var_161)
        System.Console.WriteLine(var_162)
        let (var_163: float) = (float var_154)
        let (var_164: float) = (float var_26)
        let (var_165: float) = (var_163 * var_164)
        var_138 := Union0Case1
        var_103 := Union0Case1
        var_67 := Union0Case1
        method_23((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_21: int64), (var_165: float))
    else
        0.000000
and method_3((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
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
        method_4((var_8: uint8), (var_1: (float32 [])), (var_7: int64), (var_9: int64))
        let (var_10: int64) = (var_3 + 1L)
        method_3((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64), (var_10: int64))
    else
        ()
and method_5((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_4: int64)): unit =
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
        method_6((var_0: (uint8 [])), (var_8: int64), (var_1: int64), (var_3: (float32 [])), (var_9: int64))
        let (var_10: int64) = (var_4 + 1L)
        method_5((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_10: int64))
    else
        ()
and method_8((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
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
    let (var_20: EnvStack2) = EnvStack2((var_19: (Union0 ref)))
    var_4.Push((Env3(var_20, var_3)))
    var_20
and method_9((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
    let (var_4: uint64) = uint64 var_3
    let (var_5: bool) = (var_4 <= var_2)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_8))))
    let (var_10: EnvStack2) = EnvStack2((var_9: (Union0 ref)))
    var_1.Push((Env3(var_10, var_3)))
    var_10
and method_12((var_0: int64), (var_1: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_2: ManagedCuda.BasicTypes.SizeT) = var_1.Pointer
    let (var_3: uint64) = uint64 var_2
    let (var_4: uint64) = (uint64 var_0)
    let (var_5: uint64) = (var_3 + var_4)
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    var_7
and method_22((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref)), (var_5: (Union11 ref))): float32 =
    let (var_6: Union11) = (!var_5)
    match var_6 with
    | Union11Case0(var_7) ->
        var_7.mem_0
    | Union11Case1 ->
        let (var_9: float32) = method_20((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref)))
        var_5 := (Union11Case0(Tuple12(var_9)))
        var_9
and method_23((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: float)): float =
    let (var_22: bool) = (var_20 < var_11)
    if var_22 then
        let (var_23: int64) = (var_20 + 128L)
        let (var_24: bool) = (var_23 > var_11)
        let (var_25: int64) =
            if var_24 then
                var_11
            else
                var_23
        let (var_26: bool) = (var_20 < var_25)
        let (var_27: bool) = (var_26 = false)
        if var_27 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_28: int64) = (var_25 - var_20)
        let (var_29: int64) = (var_10 + var_20)
        let (var_30: int64) = (var_10 + var_25)
        let (var_31: bool) = (var_29 >= var_10)
        let (var_33: bool) =
            if var_31 then
                (var_29 < var_11)
            else
                false
        let (var_34: bool) = (var_33 = false)
        if var_34 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_35: bool) = (var_30 > var_10)
        let (var_37: bool) =
            if var_35 then
                (var_30 <= var_11)
            else
                false
        let (var_38: bool) = (var_37 = false)
        if var_38 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_39: int64) = (var_20 * var_9)
        if var_27 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_40: int64) = (var_16 + var_20)
        let (var_41: int64) = (var_16 + var_25)
        let (var_42: bool) = (var_40 >= var_16)
        let (var_44: bool) =
            if var_42 then
                (var_40 < var_17)
            else
                false
        let (var_45: bool) = (var_44 = false)
        if var_45 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_46: bool) = (var_41 > var_16)
        let (var_48: bool) =
            if var_46 then
                (var_41 <= var_17)
            else
                false
        let (var_49: bool) = (var_48 = false)
        if var_49 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_50: int64) = (var_20 * var_15)
        let (var_51: bool) = (var_28 > 0L)
        let (var_52: bool) = (var_51 = false)
        if var_52 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_53: int64) = (var_28 * 10L)
        let (var_54: int64) = (int64 sizeof<float32>)
        let (var_55: int64) = (var_53 * var_54)
        let (var_56: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_55: int64))
        let (var_57: bool) = (0L < var_28)
        let (var_58: bool) = (var_57 = false)
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_59: bool) = (var_12 < var_13)
        let (var_60: bool) = (var_59 = false)
        if var_60 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_61: int64) = (var_13 - var_12)
        let (var_62: int64) = (var_28 * var_61)
        let (var_63: (Union0 ref)) = var_8.mem_0
        let (var_64: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_63: (Union0 ref)))
        let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_39: int64), (var_64: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_66: (Union0 ref)) = var_7.mem_0
        let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_66: (Union0 ref)))
        let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_67: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_69: (Union0 ref)) = var_56.mem_0
        let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_70: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_72: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_6.set_Stream(var_72)
        let (var_73: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
        let (var_74: bool) = (var_61 = 784L)
        let (var_75: bool) = (var_74 = false)
        if var_75 then
            (failwith "Colums of a does not match rows of b in GEMM.")
        else
            ()
        let (var_76: bool) = (var_61 = 1L)
        let (var_77: bool) = (var_28 = 1L)
        let (var_78: bool) =
            if var_77 then
                true
            else
                var_76
        if var_78 then
            let (var_79: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
            let (var_80: (float32 ref)) = (ref 1.000000f)
            let (var_81: (float32 ref)) = (ref 0.000000f)
            let (var_82: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_73, var_79, 784, 10, var_80, var_68, 784, var_65, 1, var_81, var_71, 1)
            if var_82 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_82)
        else
            let (var_83: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_84: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_85: (float32 ref)) = (ref 1.000000f)
            let (var_86: (float32 ref)) = (ref 0.000000f)
            let (var_87: int32) = (int32 var_28)
            let (var_88: int32) = (int32 var_61)
            let (var_89: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_73, var_83, var_84, var_87, 10, var_88, var_85, var_65, var_87, var_68, var_88, var_86, var_71, var_87)
            if var_89 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_89)
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_90: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_55: int64))
        let (var_91: (Union0 ref)) = var_90.mem_0
        let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_91: (Union0 ref)))
        let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_92: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_94: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_95: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_55)
        var_3.ClearMemoryAsync(var_93, 0uy, var_95, var_94)
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_100: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_55: int64))
        let (var_101: bool) = (var_53 > 0L)
        let (var_102: bool) = (var_101 = false)
        if var_102 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_103: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_69: (Union0 ref)))
        let (var_104: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_103: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_102 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_105: (Union0 ref)) = var_100.mem_0
        let (var_106: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_105: (Union0 ref)))
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_106: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_13((var_104: ManagedCuda.BasicTypes.CUdeviceptr), (var_53: int64), (var_107: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_109: (System.Object [])) = [|var_104; var_53; var_107|]: (System.Object [])
        let (var_110: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_4, var_3)
        let (var_111: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_110.set_GridDimensions(var_111)
        let (var_112: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_110.set_BlockDimensions(var_112)
        let (var_113: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_110.RunAsync(var_113, var_109)
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_114: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_55: int64))
        let (var_115: (Union0 ref)) = var_114.mem_0
        let (var_116: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_115: (Union0 ref)))
        let (var_117: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_116: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_58 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_118: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_119: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_55)
        var_3.ClearMemoryAsync(var_117, 0uy, var_119, var_118)
        let (var_120: bool) = (0L = var_18)
        let (var_122: bool) =
            if var_120 then
                (10L = var_19)
            else
                false
        let (var_123: bool) = (var_122 = false)
        if var_123 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_102 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_105: (Union0 ref)))
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_124: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_126: (Union0 ref)) = var_14.mem_0
        let (var_127: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_126: (Union0 ref)))
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_127: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_129: int64) = (var_53 - 1L)
        let (var_130: int64) = (var_129 / 128L)
        let (var_131: int64) = (var_130 + 1L)
        let (var_132: bool) = (64L > var_131)
        let (var_133: int64) =
            if var_132 then
                var_131
            else
                64L
        let (var_136: bool) = (var_133 > 0L)
        let (var_137: bool) = (var_136 = false)
        if var_137 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_138: int64) = (var_133 * var_54)
        let (var_139: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_138: int64))
        let (var_140: (Union0 ref)) = var_139.mem_0
        let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_140: (Union0 ref)))
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_141: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_15((var_125: ManagedCuda.BasicTypes.CUdeviceptr), (var_128: ManagedCuda.BasicTypes.CUdeviceptr), (var_53: int64), (var_142: ManagedCuda.BasicTypes.CUdeviceptr), (var_133: int64))
        let (var_144: (System.Object [])) = [|var_125; var_128; var_53; var_142; var_133|]: (System.Object [])
        let (var_145: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_15", var_4, var_3)
        let (var_146: uint32) = (uint32 var_133)
        let (var_147: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_146, 1u, 1u)
        var_145.set_GridDimensions(var_147)
        let (var_148: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_145.set_BlockDimensions(var_148)
        let (var_149: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_145.RunAsync(var_149, var_144)
        let (var_151: (Union11 ref)) = (ref Union11Case1)
        let (var_152: (float32 ref)) = (ref 0.000000f)
        let (var_154: (Union11 ref)) = (ref Union11Case1)
        let (var_155: (float32 ref)) = (ref 0.000000f)
        let (var_156: float32) = method_22((var_28: int64), (var_139: EnvStack2), (var_133: int64), (var_3: ManagedCuda.CudaContext), (var_151: (Union11 ref)), (var_154: (Union11 ref)))
        let (var_157: string) = System.String.Format("{0}",var_25)
        let (var_158: string) = System.String.Format("{0} = {1}","near_to",var_157)
        let (var_159: string) = System.String.Format("{0}",var_20)
        let (var_160: string) = System.String.Format("{0} = {1}","from",var_159)
        let (var_161: string) = String.concat "; " [|var_160; var_158|]
        let (var_162: string) = System.String.Format("{0}{1}{2}","{",var_161,"}")
        let (var_163: string) = System.String.Format("On minibatch {0}. Error = {1}",var_162,var_156)
        let (var_164: string) = System.String.Format("{0}",var_163)
        System.Console.WriteLine(var_164)
        let (var_165: float) = (float var_156)
        let (var_166: float) = (float var_28)
        let (var_167: float) = (var_165 * var_166)
        let (var_168: float) = (var_21 + var_167)
        var_140 := Union0Case1
        var_105 := Union0Case1
        var_69 := Union0Case1
        method_23((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_23: int64), (var_168: float))
    else
        var_21
and method_4((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
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
        method_4((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_11: int64))
    else
        ()
and method_6((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_4: int64)): unit =
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
        method_6((var_0: (uint8 [])), (var_1: int64), (var_2: int64), (var_3: (float32 [])), (var_12: int64))
    else
        ()
and method_20((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref))): float32 =
    let (var_5: float32) = method_21((var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref)))
    let (var_6: float32) = (float32 var_0)
    (var_5 / var_6)
and method_21((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: (Union11 ref))): float32 =
    let (var_4: Union11) = (!var_3)
    match var_4 with
    | Union11Case0(var_5) ->
        var_5.mem_0
    | Union11Case1 ->
        let (var_7: float32) = method_18((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext))
        var_3 := (Union11Case0(Tuple12(var_7)))
        var_7
and method_18((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext)): float32 =
    let (var_3: bool) = (0L < var_1)
    let (var_4: bool) = (var_3 = false)
    if var_4 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_5: (Union0 ref)) = var_0.mem_0
    let (var_6: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_5: (Union0 ref)))
    let (var_7: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_1))
    var_2.CopyToHost(var_7, var_6)
    var_2.Synchronize()
    let (var_8: float32) = 0.000000f
    let (var_9: int64) = 0L
    method_19((var_7: (float32 [])), (var_1: int64), (var_9: int64), (var_8: float32))
and method_19((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: float32)): float32 =
    let (var_4: bool) = (var_2 < var_1)
    if var_4 then
        let (var_5: bool) = (var_2 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: float32) = var_0.[int32 var_2]
        let (var_8: float32) = (var_3 + var_7)
        let (var_9: int64) = (var_2 + 1L)
        method_19((var_0: (float32 [])), (var_1: int64), (var_9: int64), (var_8: float32))
    else
        var_3
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
let (var_35: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_36: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_35)
let (var_37: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_38: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_39: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_37, var_38)
let (var_40: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_41: ManagedCuda.BasicTypes.SizeT) = var_40.get_TotalGlobalMemory()
let (var_42: int64) = int64 var_41
let (var_43: float) = float var_42
let (var_44: float) = (0.700000 * var_43)
let (var_45: int64) = int64 var_44
let (var_46: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_45)
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_46)
let (var_48: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_47))))
let (var_49: EnvStack2) = EnvStack2((var_48: (Union0 ref)))
let (var_50: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_51: (Union0 ref)) = var_49.mem_0
let (var_52: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
let (var_53: ManagedCuda.BasicTypes.SizeT) = var_52.Pointer
let (var_54: uint64) = uint64 var_53
let (var_55: uint64) = uint64 var_45
let (var_56: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_57: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "t10k-images.idx3-ubyte")
let (var_58: Env4) = method_2((var_57: string))
let (var_59: Env5) = var_58.mem_0
let (var_60: Env6) = var_59.mem_0
let (var_61: Tuple7) = var_59.mem_1
let (var_62: Env8) = var_61.mem_0
let (var_63: Env8) = var_61.mem_1
let (var_64: int64) = var_62.mem_0
let (var_65: int64) = var_62.mem_1
let (var_66: bool) = (var_64 = 0L)
let (var_68: bool) =
    if var_66 then
        (var_65 = 10000L)
    else
        false
let (var_74: bool) =
    if var_68 then
        let (var_69: int64) = var_63.mem_0
        let (var_70: int64) = var_63.mem_1
        let (var_71: bool) = (var_69 = 0L)
        if var_71 then
            (var_70 = 784L)
        else
            false
    else
        false
let (var_75: bool) = (var_74 = false)
if var_75 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_76: bool) = (var_64 < var_65)
let (var_77: bool) = (var_76 = false)
if var_77 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_78: int64) = var_63.mem_0
let (var_79: int64) = var_63.mem_1
let (var_80: bool) = (var_78 < var_79)
let (var_81: bool) = (var_80 = false)
if var_81 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_82: int64) = (var_79 - var_78)
let (var_83: int64) = (var_65 - var_64)
let (var_84: int64) = (var_83 * var_82)
let (var_85: (float32 [])) = var_60.mem_0
let (var_86: Tuple9) = var_60.mem_1
let (var_87: int64) = var_60.mem_2
let (var_88: int64) = var_60.mem_3
let (var_89: Env10) = var_86.mem_0
let (var_90: int64) = var_89.mem_0
let (var_91: int64) = var_89.mem_1
let (var_92: bool) = (var_90 = 0L)
let (var_93: bool) = (var_92 = false)
if var_93 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_94: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "t10k-labels.idx1-ubyte")
let (var_95: Env4) = method_2((var_94: string))
let (var_96: Env5) = var_95.mem_0
let (var_97: Env6) = var_96.mem_0
let (var_98: Tuple7) = var_96.mem_1
let (var_99: Env8) = var_98.mem_0
let (var_100: Env8) = var_98.mem_1
let (var_101: int64) = var_99.mem_0
let (var_102: int64) = var_99.mem_1
let (var_103: bool) = (var_101 = 0L)
let (var_105: bool) =
    if var_103 then
        (var_102 = 10000L)
    else
        false
let (var_111: bool) =
    if var_105 then
        let (var_106: int64) = var_100.mem_0
        let (var_107: int64) = var_100.mem_1
        let (var_108: bool) = (var_106 = 0L)
        if var_108 then
            (var_107 = 10L)
        else
            false
    else
        false
let (var_112: bool) = (var_111 = false)
if var_112 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_113: bool) = (var_101 < var_102)
let (var_114: bool) = (var_113 = false)
if var_114 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_115: int64) = var_100.mem_0
let (var_116: int64) = var_100.mem_1
let (var_117: bool) = (var_115 < var_116)
let (var_118: bool) = (var_117 = false)
if var_118 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_119: int64) = (var_116 - var_115)
let (var_120: int64) = (var_102 - var_101)
let (var_121: int64) = (var_120 * var_119)
let (var_122: (float32 [])) = var_97.mem_0
let (var_123: Tuple9) = var_97.mem_1
let (var_124: int64) = var_97.mem_2
let (var_125: int64) = var_97.mem_3
let (var_126: Env10) = var_123.mem_0
let (var_127: int64) = var_126.mem_0
let (var_128: int64) = var_126.mem_1
let (var_129: bool) = (var_127 = 0L)
let (var_130: bool) = (var_129 = false)
if var_130 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_131: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "train-images.idx3-ubyte")
let (var_132: Env4) = method_2((var_131: string))
let (var_133: Env5) = var_132.mem_0
let (var_134: Env6) = var_133.mem_0
let (var_135: Tuple7) = var_133.mem_1
let (var_136: Env8) = var_135.mem_0
let (var_137: Env8) = var_135.mem_1
let (var_138: int64) = var_136.mem_0
let (var_139: int64) = var_136.mem_1
let (var_140: bool) = (var_138 = 0L)
let (var_142: bool) =
    if var_140 then
        (var_139 = 60000L)
    else
        false
let (var_148: bool) =
    if var_142 then
        let (var_143: int64) = var_137.mem_0
        let (var_144: int64) = var_137.mem_1
        let (var_145: bool) = (var_143 = 0L)
        if var_145 then
            (var_144 = 784L)
        else
            false
    else
        false
let (var_149: bool) = (var_148 = false)
if var_149 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_150: bool) = (var_138 < var_139)
let (var_151: bool) = (var_150 = false)
if var_151 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_152: int64) = var_137.mem_0
let (var_153: int64) = var_137.mem_1
let (var_154: bool) = (var_152 < var_153)
let (var_155: bool) = (var_154 = false)
if var_155 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_156: int64) = (var_153 - var_152)
let (var_157: int64) = (var_139 - var_138)
let (var_158: int64) = (var_157 * var_156)
let (var_159: (float32 [])) = var_134.mem_0
let (var_160: Tuple9) = var_134.mem_1
let (var_161: int64) = var_134.mem_2
let (var_162: int64) = var_134.mem_3
let (var_163: Env10) = var_160.mem_0
let (var_164: int64) = var_163.mem_0
let (var_165: int64) = var_163.mem_1
let (var_166: bool) = (var_164 = 0L)
let (var_167: bool) = (var_166 = false)
if var_167 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_168: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "train-labels.idx1-ubyte")
let (var_169: Env4) = method_2((var_168: string))
let (var_170: Env5) = var_169.mem_0
let (var_171: Env6) = var_170.mem_0
let (var_172: Tuple7) = var_170.mem_1
let (var_173: Env8) = var_172.mem_0
let (var_174: Env8) = var_172.mem_1
let (var_175: int64) = var_173.mem_0
let (var_176: int64) = var_173.mem_1
let (var_177: bool) = (var_175 = 0L)
let (var_179: bool) =
    if var_177 then
        (var_176 = 60000L)
    else
        false
let (var_185: bool) =
    if var_179 then
        let (var_180: int64) = var_174.mem_0
        let (var_181: int64) = var_174.mem_1
        let (var_182: bool) = (var_180 = 0L)
        if var_182 then
            (var_181 = 10L)
        else
            false
    else
        false
let (var_186: bool) = (var_185 = false)
if var_186 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_187: bool) = (var_175 < var_176)
let (var_188: bool) = (var_187 = false)
if var_188 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_189: int64) = var_174.mem_0
let (var_190: int64) = var_174.mem_1
let (var_191: bool) = (var_189 < var_190)
let (var_192: bool) = (var_191 = false)
if var_192 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_193: int64) = (var_190 - var_189)
let (var_194: int64) = (var_176 - var_175)
let (var_195: int64) = (var_194 * var_193)
let (var_196: (float32 [])) = var_171.mem_0
let (var_197: Tuple9) = var_171.mem_1
let (var_198: int64) = var_171.mem_2
let (var_199: int64) = var_171.mem_3
let (var_200: Env10) = var_197.mem_0
let (var_201: int64) = var_200.mem_0
let (var_202: int64) = var_200.mem_1
let (var_203: bool) = (var_201 = 0L)
let (var_204: bool) = (var_203 = false)
if var_204 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
if var_77 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_81 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_205: int64) = var_85.LongLength
let (var_206: int64) = (int64 sizeof<float32>)
let (var_207: int64) = (var_205 * var_206)
let (var_208: EnvStack2) = method_7((var_54: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_55: uint64), (var_207: int64))
let (var_209: (Union0 ref)) = var_208.mem_0
let (var_210: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_209: (Union0 ref)))
var_1.CopyToDevice(var_210, var_85)
if var_114 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_118 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_211: int64) = var_122.LongLength
let (var_212: int64) = (var_211 * var_206)
let (var_213: EnvStack2) = method_7((var_54: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_55: uint64), (var_212: int64))
let (var_214: (Union0 ref)) = var_213.mem_0
let (var_215: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_214: (Union0 ref)))
var_1.CopyToDevice(var_215, var_122)
if var_151 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_155 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_216: int64) = var_159.LongLength
let (var_217: int64) = (var_216 * var_206)
let (var_218: EnvStack2) = method_7((var_54: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_55: uint64), (var_217: int64))
let (var_219: (Union0 ref)) = var_218.mem_0
let (var_220: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_219: (Union0 ref)))
var_1.CopyToDevice(var_220, var_159)
if var_188 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_192 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_221: int64) = var_196.LongLength
let (var_222: int64) = (var_221 * var_206)
let (var_223: EnvStack2) = method_7((var_54: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_55: uint64), (var_222: int64))
let (var_224: (Union0 ref)) = var_223.mem_0
let (var_225: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_224: (Union0 ref)))
var_1.CopyToDevice(var_225, var_196)
let (var_226: float32) = sqrt 0.002519f
let (var_227: int64) = (7840L * var_206)
let (var_228: EnvStack2) = method_7((var_54: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_55: uint64), (var_227: int64))
let (var_229: ManagedCuda.BasicTypes.CUstream) = var_56.get_Stream()
var_36.SetStream(var_229)
let (var_230: (Union0 ref)) = var_228.mem_0
let (var_231: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_230: (Union0 ref)))
let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_231: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_233: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_36.GenerateNormal32(var_232, var_233, 0.000000f, var_226)
let (var_234: bool) = (var_138 = var_175)
let (var_236: bool) =
    if var_234 then
        (var_139 = var_176)
    else
        false
let (var_237: bool) = (var_236 = false)
if var_237 then
    (failwith "Training and test set need to have to equal first dimensions.")
else
    ()
let (var_238: float) = method_11((var_54: uint64), (var_55: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_56: ManagedCuda.CudaStream), (var_39: ManagedCuda.CudaBlas.CudaBlas), (var_228: EnvStack2), (var_218: EnvStack2), (var_156: int64), (var_138: int64), (var_139: int64), (var_152: int64), (var_153: int64), (var_223: EnvStack2), (var_193: int64), (var_175: int64), (var_176: int64), (var_189: int64), (var_190: int64))
System.Console.WriteLine("-----")
System.Console.WriteLine("Batch done.")
let (var_239: float) = (float var_157)
let (var_240: float) = (var_238 / var_239)
let (var_241: string) = System.String.Format("Average of batch costs is {0}.",var_240)
let (var_242: string) = System.String.Format("{0}",var_241)
System.Console.WriteLine(var_242)
System.Console.WriteLine("-----")
var_230 := Union0Case1
var_56.Dispose()
let (var_243: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
var_1.FreeMemory(var_243)
var_51 := Union0Case1
var_39.Dispose()
var_36.Dispose()
var_1.Dispose()

