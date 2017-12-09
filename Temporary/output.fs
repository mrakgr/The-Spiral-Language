module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_15(float * var_0, long long int var_1, float * var_2);
    __global__ void method_17(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4);
    __device__ void method_16(float * var_0, long long int var_1, float * var_2, long long int var_3);
    __device__ float method_18(float * var_0, float * var_1, long long int var_2, long long int var_3, long long int var_4, float var_5);
    __device__ float method_19(float var_0, float var_1);
    
    __global__ void method_15(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        method_16(var_0, var_1, var_2, var_10);
    }
    __global__ void method_17(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4) {
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
        long long int var_15 = (var_13 + var_14);
        char var_16 = (var_13 >= 0);
        char var_18;
        if (var_16) {
            var_18 = (var_13 < var_2);
        } else {
            var_18 = 0;
        }
        char var_19 = (var_18 == 0);
        if (var_19) {
            // unprinted assert;
        } else {
        }
        float * var_20 = var_0 + var_13;
        float * var_21 = var_1 + var_13;
        float var_22 = var_20[0];
        float var_23 = var_21[0];
        float var_24 = (var_23 - var_22);
        float var_25 = (var_24 * var_24);
        float var_26 = method_18(var_0, var_1, var_2, var_14, var_15, var_25);
        FunPointer0 var_29 = method_19;
        float var_30 = cub::BlockReduce<float,128>().Reduce(var_26, var_29);
        char var_31 = (var_5 == 0);
        if (var_31) {
            char var_32 = (var_8 >= 0);
            char var_34;
            if (var_32) {
                var_34 = (var_8 < var_4);
            } else {
                var_34 = 0;
            }
            char var_35 = (var_34 == 0);
            if (var_35) {
                // unprinted assert;
            } else {
            }
            float * var_36 = var_3 + var_8;
            var_36[0] = var_30;
        } else {
        }
    }
    __device__ void method_16(float * var_0, long long int var_1, float * var_2, long long int var_3) {
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
            long long int var_14 = (var_3 + 4096);
            method_16(var_0, var_1, var_2, var_14);
        } else {
        }
    }
    __device__ float method_18(float * var_0, float * var_1, long long int var_2, long long int var_3, long long int var_4, float var_5) {
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
            return method_18(var_0, var_1, var_2, var_3, var_16, var_15);
        } else {
            return var_5;
        }
    }
    __device__ float method_19(float var_0, float var_1) {
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
and EnvHeap12 =
    {
    mem_0: EnvStack3
    mem_1: int64
    mem_2: int64
    mem_3: int64
    mem_4: int64
    mem_5: int64
    mem_6: EnvStack3
    mem_7: uint64
    mem_8: uint64
    mem_9: System.Collections.Generic.Stack<Env4>
    mem_10: ManagedCuda.CudaContext
    mem_11: ManagedCuda.CudaBlas.CudaBlas
    mem_12: ManagedCuda.CudaStream
    mem_13: ManagedCuda.BasicTypes.CUmodule
    mem_14: EnvStack3
    mem_15: int64
    mem_16: int64
    mem_17: int64
    mem_18: int64
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
and method_9((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64)): EnvStack3 =
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
            method_10((var_13: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env4>), (var_7: EnvStack3), (var_8: int64))
        | Union0Case1 ->
            let (var_15: Env4) = var_1.Pop()
            let (var_16: EnvStack3) = var_15.mem_0
            let (var_17: int64) = var_15.mem_1
            method_9((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64))
    else
        method_11((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64))
and method_12((var_0: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_2: uint64) = uint64 var_1
    let (var_3: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_2)
    let (var_4: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_3)
    var_4
and method_13((var_0: int64), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env4>), (var_4: ManagedCuda.CudaContext), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaStream), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvStack3), (var_9: EnvStack3), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack3), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64)): unit =
    let (var_21: bool) = (var_20 < var_0)
    if var_21 then
        let (var_22: int64) = (var_20 + 128L)
        let (var_23: bool) = (var_22 > var_0)
        let (var_24: int64) =
            if var_23 then
                var_0
            else
                var_22
        let (var_25: string) = System.String.Format("{0}",var_24)
        let (var_26: string) = System.String.Format("{0} = {1}","near_to",var_25)
        let (var_27: string) = System.String.Format("{0}",var_20)
        let (var_28: string) = System.String.Format("{0} = {1}","from",var_27)
        let (var_29: string) = String.concat "; " [|var_28; var_26|]
        let (var_30: string) = System.String.Format("{0}{1}{2}","{",var_29,"}")
        let (var_31: string) = System.String.Format("On span {0}",var_30)
        let (var_32: string) = System.String.Format("{0}",var_31)
        System.Console.WriteLine(var_32)
        let (var_33: bool) = (var_20 < var_24)
        let (var_34: bool) = (var_33 = false)
        if var_34 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_35: int64) = (var_24 - var_20)
        let (var_36: int64) = (var_17 + var_20)
        let (var_37: int64) = (var_17 + var_24)
        let (var_38: bool) = (var_36 >= var_17)
        let (var_40: bool) =
            if var_38 then
                (var_36 < var_0)
            else
                false
        let (var_41: bool) = (var_40 = false)
        if var_41 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_42: bool) = (var_37 > var_17)
        let (var_44: bool) =
            if var_42 then
                (var_37 <= var_0)
            else
                false
        let (var_45: bool) = (var_44 = false)
        if var_45 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_46: int64) = (var_20 * var_16)
        if var_34 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_47: int64) = (var_11 + var_20)
        let (var_48: int64) = (var_11 + var_24)
        let (var_49: bool) = (var_47 >= var_11)
        let (var_51: bool) =
            if var_49 then
                (var_47 < var_12)
            else
                false
        let (var_52: bool) = (var_51 = false)
        if var_52 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_53: bool) = (var_48 > var_11)
        let (var_55: bool) =
            if var_53 then
                (var_48 <= var_12)
            else
                false
        let (var_56: bool) = (var_55 = false)
        if var_56 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_57: int64) = (var_20 * var_10)
        let (var_58: EnvHeap12) = ({mem_0 = (var_15: EnvStack3); mem_1 = (var_46: int64); mem_2 = (var_16: int64); mem_3 = (var_35: int64); mem_4 = (var_18: int64); mem_5 = (var_19: int64); mem_6 = (var_8: EnvStack3); mem_7 = (var_1: uint64); mem_8 = (var_2: uint64); mem_9 = (var_3: System.Collections.Generic.Stack<Env4>); mem_10 = (var_4: ManagedCuda.CudaContext); mem_11 = (var_5: ManagedCuda.CudaBlas.CudaBlas); mem_12 = (var_6: ManagedCuda.CudaStream); mem_13 = (var_7: ManagedCuda.BasicTypes.CUmodule); mem_14 = (var_9: EnvStack3); mem_15 = (var_57: int64); mem_16 = (var_10: int64); mem_17 = (var_13: int64); mem_18 = (var_14: int64)} : EnvHeap12)
        let (var_59: EnvStack3) = var_58.mem_0
        let (var_60: int64) = var_58.mem_1
        let (var_61: int64) = var_58.mem_2
        let (var_62: int64) = var_58.mem_3
        let (var_63: int64) = var_58.mem_4
        let (var_64: int64) = var_58.mem_5
        let (var_65: EnvStack3) = var_58.mem_6
        let (var_66: uint64) = var_58.mem_7
        let (var_67: uint64) = var_58.mem_8
        let (var_68: System.Collections.Generic.Stack<Env4>) = var_58.mem_9
        let (var_69: ManagedCuda.CudaContext) = var_58.mem_10
        let (var_70: ManagedCuda.CudaBlas.CudaBlas) = var_58.mem_11
        let (var_71: ManagedCuda.CudaStream) = var_58.mem_12
        let (var_72: ManagedCuda.BasicTypes.CUmodule) = var_58.mem_13
        let (var_73: EnvStack3) = var_58.mem_14
        let (var_74: int64) = var_58.mem_15
        let (var_75: int64) = var_58.mem_16
        let (var_76: int64) = var_58.mem_17
        let (var_77: int64) = var_58.mem_18
        let (var_78: bool) = (var_62 > 0L)
        let (var_79: bool) = (var_78 = false)
        if var_79 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_80: int64) = (var_62 * 10L)
        let (var_81: int64) = (int64 sizeof<float32>)
        let (var_82: int64) = (var_80 * var_81)
        let (var_83: EnvStack3) = method_9((var_66: uint64), (var_68: System.Collections.Generic.Stack<Env4>), (var_67: uint64), (var_82: int64))
        let (var_84: bool) = (0L < var_62)
        let (var_85: bool) = (var_84 = false)
        if var_85 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_86: bool) = (var_63 < var_64)
        let (var_87: bool) = (var_86 = false)
        if var_87 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_88: int64) = (var_64 - var_63)
        let (var_89: int64) = (var_62 * var_88)
        let (var_90: (Union0 ref)) = var_59.mem_0
        let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
        let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = method_14((var_60: int64), (var_91: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_93: (Union0 ref)) = var_65.mem_0
        let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_93: (Union0 ref)))
        let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_94: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_85 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_96: (Union0 ref)) = var_83.mem_0
        let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_96: (Union0 ref)))
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_97: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_99: ManagedCuda.BasicTypes.CUstream) = var_71.get_Stream()
        var_70.set_Stream(var_99)
        let (var_100: ManagedCuda.CudaBlas.CudaBlasHandle) = var_70.get_CublasHandle()
        let (var_101: bool) = (var_88 = 784L)
        let (var_102: bool) = (var_101 = false)
        if var_102 then
            (failwith "Colums of a does not match rows of b in GEMM.")
        else
            ()
        let (var_103: bool) = (var_88 = 1L)
        let (var_104: bool) = (var_62 = 1L)
        let (var_105: bool) =
            if var_104 then
                true
            else
                var_103
        if var_105 then
            let (var_106: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
            let (var_107: (float32 ref)) = (ref 1.000000f)
            let (var_108: (float32 ref)) = (ref 0.000000f)
            let (var_109: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_100, var_106, 784, 10, var_107, var_95, 784, var_92, 1, var_108, var_98, 1)
            if var_109 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_109)
        else
            let (var_110: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_111: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_112: (float32 ref)) = (ref 1.000000f)
            let (var_113: (float32 ref)) = (ref 0.000000f)
            let (var_114: int32) = (int32 var_62)
            let (var_115: int32) = (int32 var_88)
            let (var_116: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_100, var_110, var_111, var_114, 10, var_115, var_112, var_92, var_114, var_95, var_115, var_113, var_98, var_114)
            if var_116 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_116)
        if var_85 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_121: EnvStack3) = method_9((var_66: uint64), (var_68: System.Collections.Generic.Stack<Env4>), (var_67: uint64), (var_82: int64))
        let (var_122: bool) = (var_80 > 0L)
        let (var_123: bool) = (var_122 = false)
        if var_123 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_96: (Union0 ref)))
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_124: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_123 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_126: (Union0 ref)) = var_121.mem_0
        let (var_127: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_126: (Union0 ref)))
        let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_127: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_15((var_125: ManagedCuda.BasicTypes.CUdeviceptr), (var_80: int64), (var_128: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_130: (System.Object [])) = [|var_125; var_80; var_128|]: (System.Object [])
        let (var_131: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_15", var_72, var_69)
        let (var_132: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
        var_131.set_GridDimensions(var_132)
        let (var_133: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_131.set_BlockDimensions(var_133)
        let (var_134: ManagedCuda.BasicTypes.CUstream) = var_71.get_Stream()
        var_131.RunAsync(var_134, var_130)
        let (var_135: bool) = (0L = var_76)
        let (var_137: bool) =
            if var_135 then
                (10L = var_77)
            else
                false
        let (var_138: bool) = (var_137 = false)
        if var_138 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_123 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_139: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_126: (Union0 ref)))
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_139: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_141: (Union0 ref)) = var_73.mem_0
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
        let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_142: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_123 then
            (failwith "The input to map_redo must be non-empty.")
        else
            ()
        let (var_144: bool) = (var_80 >= 128L)
        if var_144 then
            let (var_145: int64) = (var_80 / 128L)
            let (var_148: bool) = (var_145 > 0L)
            let (var_149: bool) = (var_148 = false)
            if var_149 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_150: int64) = (var_145 * var_81)
            let (var_151: EnvStack3) = method_9((var_66: uint64), (var_68: System.Collections.Generic.Stack<Env4>), (var_67: uint64), (var_150: int64))
            let (var_152: (Union0 ref)) = var_151.mem_0
            let (var_153: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_152: (Union0 ref)))
            let (var_154: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_153: ManagedCuda.BasicTypes.CUdeviceptr))
            // Cuda join point
            // method_17((var_140: ManagedCuda.BasicTypes.CUdeviceptr), (var_143: ManagedCuda.BasicTypes.CUdeviceptr), (var_80: int64), (var_154: ManagedCuda.BasicTypes.CUdeviceptr), (var_145: int64))
            let (var_156: (System.Object [])) = [|var_140; var_143; var_80; var_154; var_145|]: (System.Object [])
            let (var_157: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_72, var_69)
            let (var_158: uint32) = (uint32 var_145)
            let (var_159: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_158, 1u, 1u)
            var_157.set_GridDimensions(var_159)
            let (var_160: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_157.set_BlockDimensions(var_160)
            let (var_161: ManagedCuda.BasicTypes.CUstream) = var_71.get_Stream()
            var_157.RunAsync(var_161, var_156)
            let (var_162: bool) = (0L < var_145)
            let (var_163: bool) = (var_162 = false)
            if var_163 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_164: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_152: (Union0 ref)))
            let (var_165: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_145))
            var_69.CopyToHost(var_165, var_164)
            var_69.Synchronize()
            if var_163 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_166: float32) = var_165.[int32 0L]
            let (var_167: int64) = 1L
            let (var_168: float32) = method_20((var_165: (float32 [])), (var_145: int64), (var_167: int64), (var_166: float32))
            let (var_169: string) = System.String.Format("{0}",var_168)
            System.Console.WriteLine(var_169)
            var_152 := Union0Case1
        else
            let (var_170: bool) = (0L < var_80)
            let (var_171: bool) = (var_170 = false)
            if var_171 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_172: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_126: (Union0 ref)))
            let (var_173: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_80))
            var_69.CopyToHost(var_173, var_172)
            var_69.Synchronize()
            let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
            let (var_175: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_80))
            var_69.CopyToHost(var_175, var_174)
            var_69.Synchronize()
            if var_171 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_176: float32) = var_173.[int32 0L]
            let (var_177: float32) = var_175.[int32 0L]
            let (var_178: float32) = (var_177 - var_176)
            let (var_179: float32) = (var_178 * var_178)
            let (var_180: int64) = 1L
            let (var_181: float32) = method_21((var_173: (float32 [])), (var_175: (float32 [])), (var_80: int64), (var_180: int64), (var_179: float32))
            let (var_182: string) = System.String.Format("{0}",var_181)
            System.Console.WriteLine(var_182)
        var_126 := Union0Case1
        var_96 := Union0Case1
        method_13((var_0: int64), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env4>), (var_4: ManagedCuda.CudaContext), (var_5: ManagedCuda.CudaBlas.CudaBlas), (var_6: ManagedCuda.CudaStream), (var_7: ManagedCuda.BasicTypes.CUmodule), (var_8: EnvStack3), (var_9: EnvStack3), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack3), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_22: int64))
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
and method_10((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env4>), (var_5: EnvStack3), (var_6: int64)): EnvStack3 =
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
and method_11((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env4>), (var_2: uint64), (var_3: int64)): EnvStack3 =
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
and method_14((var_0: int64), (var_1: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_2: ManagedCuda.BasicTypes.SizeT) = var_1.Pointer
    let (var_3: uint64) = uint64 var_2
    let (var_4: uint64) = (uint64 var_0)
    let (var_5: uint64) = (var_3 + var_4)
    let (var_6: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_5)
    let (var_7: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_6)
    var_7
and method_20((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: float32)): float32 =
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
        method_20((var_0: (float32 [])), (var_1: int64), (var_9: int64), (var_8: float32))
    else
        var_3
and method_21((var_0: (float32 [])), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: float32)): float32 =
    let (var_5: bool) = (var_3 < var_2)
    if var_5 then
        let (var_6: bool) = (var_3 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: float32) = var_0.[int32 var_3]
        let (var_9: float32) = var_1.[int32 var_3]
        let (var_10: float32) = (var_9 - var_8)
        let (var_11: float32) = (var_10 * var_10)
        let (var_12: float32) = (var_4 + var_11)
        let (var_13: int64) = (var_3 + 1L)
        method_21((var_0: (float32 [])), (var_1: (float32 [])), (var_2: int64), (var_13: int64), (var_12: float32))
    else
        var_4
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
let (var_65: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "t10k-images.idx3-ubyte")
let (var_66: Env5) = method_4((var_65: string))
let (var_67: Env6) = var_66.mem_0
let (var_68: Env7) = var_67.mem_0
let (var_69: Tuple8) = var_67.mem_1
let (var_70: Env9) = var_69.mem_0
let (var_71: Env9) = var_69.mem_1
let (var_72: int64) = var_70.mem_0
let (var_73: int64) = var_70.mem_1
let (var_74: bool) = (var_72 = 0L)
let (var_76: bool) =
    if var_74 then
        (var_73 = 10000L)
    else
        false
let (var_82: bool) =
    if var_76 then
        let (var_77: int64) = var_71.mem_0
        let (var_78: int64) = var_71.mem_1
        let (var_79: bool) = (var_77 = 0L)
        if var_79 then
            (var_78 = 784L)
        else
            false
    else
        false
let (var_83: bool) = (var_82 = false)
if var_83 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_84: bool) = (var_72 < var_73)
let (var_85: bool) = (var_84 = false)
if var_85 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_86: int64) = var_71.mem_0
let (var_87: int64) = var_71.mem_1
let (var_88: bool) = (var_86 < var_87)
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_90: int64) = (var_87 - var_86)
let (var_91: int64) = (var_73 - var_72)
let (var_92: int64) = (var_91 * var_90)
let (var_93: (float32 [])) = var_68.mem_0
let (var_94: Tuple10) = var_68.mem_1
let (var_95: int64) = var_68.mem_2
let (var_96: int64) = var_68.mem_3
let (var_97: Env11) = var_94.mem_0
let (var_98: int64) = var_97.mem_0
let (var_99: int64) = var_97.mem_1
let (var_100: bool) = (var_98 = 0L)
let (var_101: bool) = (var_100 = false)
if var_101 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_102: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "t10k-labels.idx1-ubyte")
let (var_103: Env5) = method_4((var_102: string))
let (var_104: Env6) = var_103.mem_0
let (var_105: Env7) = var_104.mem_0
let (var_106: Tuple8) = var_104.mem_1
let (var_107: Env9) = var_106.mem_0
let (var_108: Env9) = var_106.mem_1
let (var_109: int64) = var_107.mem_0
let (var_110: int64) = var_107.mem_1
let (var_111: bool) = (var_109 = 0L)
let (var_113: bool) =
    if var_111 then
        (var_110 = 10000L)
    else
        false
let (var_119: bool) =
    if var_113 then
        let (var_114: int64) = var_108.mem_0
        let (var_115: int64) = var_108.mem_1
        let (var_116: bool) = (var_114 = 0L)
        if var_116 then
            (var_115 = 10L)
        else
            false
    else
        false
let (var_120: bool) = (var_119 = false)
if var_120 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_121: bool) = (var_109 < var_110)
let (var_122: bool) = (var_121 = false)
if var_122 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_123: int64) = var_108.mem_0
let (var_124: int64) = var_108.mem_1
let (var_125: bool) = (var_123 < var_124)
let (var_126: bool) = (var_125 = false)
if var_126 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_127: int64) = (var_124 - var_123)
let (var_128: int64) = (var_110 - var_109)
let (var_129: int64) = (var_128 * var_127)
let (var_130: (float32 [])) = var_105.mem_0
let (var_131: Tuple10) = var_105.mem_1
let (var_132: int64) = var_105.mem_2
let (var_133: int64) = var_105.mem_3
let (var_134: Env11) = var_131.mem_0
let (var_135: int64) = var_134.mem_0
let (var_136: int64) = var_134.mem_1
let (var_137: bool) = (var_135 = 0L)
let (var_138: bool) = (var_137 = false)
if var_138 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_139: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "train-images.idx3-ubyte")
let (var_140: Env5) = method_4((var_139: string))
let (var_141: Env6) = var_140.mem_0
let (var_142: Env7) = var_141.mem_0
let (var_143: Tuple8) = var_141.mem_1
let (var_144: Env9) = var_143.mem_0
let (var_145: Env9) = var_143.mem_1
let (var_146: int64) = var_144.mem_0
let (var_147: int64) = var_144.mem_1
let (var_148: bool) = (var_146 = 0L)
let (var_150: bool) =
    if var_148 then
        (var_147 = 60000L)
    else
        false
let (var_156: bool) =
    if var_150 then
        let (var_151: int64) = var_145.mem_0
        let (var_152: int64) = var_145.mem_1
        let (var_153: bool) = (var_151 = 0L)
        if var_153 then
            (var_152 = 784L)
        else
            false
    else
        false
let (var_157: bool) = (var_156 = false)
if var_157 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_158: bool) = (var_146 < var_147)
let (var_159: bool) = (var_158 = false)
if var_159 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_160: int64) = var_145.mem_0
let (var_161: int64) = var_145.mem_1
let (var_162: bool) = (var_160 < var_161)
let (var_163: bool) = (var_162 = false)
if var_163 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_164: int64) = (var_161 - var_160)
let (var_165: int64) = (var_147 - var_146)
let (var_166: int64) = (var_165 * var_164)
let (var_167: (float32 [])) = var_142.mem_0
let (var_168: Tuple10) = var_142.mem_1
let (var_169: int64) = var_142.mem_2
let (var_170: int64) = var_142.mem_3
let (var_171: Env11) = var_168.mem_0
let (var_172: int64) = var_171.mem_0
let (var_173: int64) = var_171.mem_1
let (var_174: bool) = (var_172 = 0L)
let (var_175: bool) = (var_174 = false)
if var_175 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
let (var_176: string) = System.IO.Path.Combine("C:\\Users\\Marko\\Documents\\Visual Studio 2015\\Projects\\SpiralQ\\SpiralQ\\Tests", "train-labels.idx1-ubyte")
let (var_177: Env5) = method_4((var_176: string))
let (var_178: Env6) = var_177.mem_0
let (var_179: Env7) = var_178.mem_0
let (var_180: Tuple8) = var_178.mem_1
let (var_181: Env9) = var_180.mem_0
let (var_182: Env9) = var_180.mem_1
let (var_183: int64) = var_181.mem_0
let (var_184: int64) = var_181.mem_1
let (var_185: bool) = (var_183 = 0L)
let (var_187: bool) =
    if var_185 then
        (var_184 = 60000L)
    else
        false
let (var_193: bool) =
    if var_187 then
        let (var_188: int64) = var_182.mem_0
        let (var_189: int64) = var_182.mem_1
        let (var_190: bool) = (var_188 = 0L)
        if var_190 then
            (var_189 = 10L)
        else
            false
    else
        false
let (var_194: bool) = (var_193 = false)
if var_194 then
    (failwith "The dimensions do not match.")
else
    ()
let (var_195: bool) = (var_183 < var_184)
let (var_196: bool) = (var_195 = false)
if var_196 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_197: int64) = var_182.mem_0
let (var_198: int64) = var_182.mem_1
let (var_199: bool) = (var_197 < var_198)
let (var_200: bool) = (var_199 = false)
if var_200 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_201: int64) = (var_198 - var_197)
let (var_202: int64) = (var_184 - var_183)
let (var_203: int64) = (var_202 * var_201)
let (var_204: (float32 [])) = var_179.mem_0
let (var_205: Tuple10) = var_179.mem_1
let (var_206: int64) = var_179.mem_2
let (var_207: int64) = var_179.mem_3
let (var_208: Env11) = var_205.mem_0
let (var_209: int64) = var_208.mem_0
let (var_210: int64) = var_208.mem_1
let (var_211: bool) = (var_209 = 0L)
let (var_212: bool) = (var_211 = false)
if var_212 then
    (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
else
    ()
if var_85 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_89 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_213: int64) = var_93.LongLength
let (var_214: int64) = (int64 sizeof<float32>)
let (var_215: int64) = (var_213 * var_214)
let (var_216: EnvStack3) = method_9((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_215: int64))
let (var_217: (Union0 ref)) = var_216.mem_0
let (var_218: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_217: (Union0 ref)))
var_1.CopyToDevice(var_218, var_93)
if var_122 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_126 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_219: int64) = var_130.LongLength
let (var_220: int64) = (var_219 * var_214)
let (var_221: EnvStack3) = method_9((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_220: int64))
let (var_222: (Union0 ref)) = var_221.mem_0
let (var_223: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_222: (Union0 ref)))
var_1.CopyToDevice(var_223, var_130)
if var_159 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_163 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_224: int64) = var_167.LongLength
let (var_225: int64) = (var_224 * var_214)
let (var_226: EnvStack3) = method_9((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_225: int64))
let (var_227: (Union0 ref)) = var_226.mem_0
let (var_228: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_227: (Union0 ref)))
var_1.CopyToDevice(var_228, var_167)
if var_196 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
if var_200 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_229: int64) = var_204.LongLength
let (var_230: int64) = (var_229 * var_214)
let (var_231: EnvStack3) = method_9((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_230: int64))
let (var_232: (Union0 ref)) = var_231.mem_0
let (var_233: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_232: (Union0 ref)))
var_1.CopyToDevice(var_233, var_204)
let (var_234: float32) = sqrt 794.000000f
let (var_235: float32) = (1.000000f / var_234)
let (var_236: int64) = (7840L * var_214)
let (var_237: EnvStack3) = method_9((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_50: uint64), (var_236: int64))
let (var_238: ManagedCuda.BasicTypes.CUstream) = var_56.get_Stream()
var_52.SetStream(var_238)
let (var_239: (Union0 ref)) = var_237.mem_0
let (var_240: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_239: (Union0 ref)))
let (var_241: ManagedCuda.BasicTypes.CUdeviceptr) = method_12((var_240: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_242: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_52.GenerateNormal32(var_241, var_242, 0.000000f, var_235)
let (var_243: bool) = (var_146 = var_183)
let (var_245: bool) =
    if var_243 then
        (var_147 = var_184)
    else
        false
let (var_246: bool) = (var_245 = false)
if var_246 then
    (failwith "Training and test set need to have to equal first dimensions.")
else
    ()
let (var_247: int64) = 0L
method_13((var_147: int64), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env4>), (var_1: ManagedCuda.CudaContext), (var_55: ManagedCuda.CudaBlas.CudaBlas), (var_56: ManagedCuda.CudaStream), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_237: EnvStack3), (var_231: EnvStack3), (var_201: int64), (var_183: int64), (var_184: int64), (var_197: int64), (var_198: int64), (var_226: EnvStack3), (var_164: int64), (var_146: int64), (var_160: int64), (var_161: int64), (var_247: int64))
var_239 := Union0Case1
var_55.Dispose()
var_52.Dispose()
let (var_248: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_248)
var_46 := Union0Case1
var_1.Dispose()

