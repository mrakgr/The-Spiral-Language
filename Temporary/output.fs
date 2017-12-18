module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    typedef float(*FunPointer0)(float, float);
    __global__ void method_14(float * var_0, long long int var_1, float * var_2);
    __global__ void method_16(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4);
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5);
    __global__ void method_26(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4);
    __global__ void method_28(float * var_0, float * var_1);
    __global__ void method_30(float * var_0, float * var_1, float * var_2);
    __device__ void method_15(float * var_0, long long int var_1, float * var_2, long long int var_3);
    __device__ float method_17(float * var_0, float * var_1, long long int var_2, long long int var_3, long long int var_4, float var_5);
    __device__ float method_18(float var_0, float var_1);
    __device__ void method_25(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5, long long int var_6);
    __device__ void method_27(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4, long long int var_5);
    __device__ void method_29(float * var_0, float * var_1, long long int var_2);
    __device__ void method_31(float * var_0, float * var_1, float * var_2, long long int var_3);
    
    __global__ void method_14(float * var_0, long long int var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        method_15(var_0, var_1, var_2, var_10);
    }
    __global__ void method_16(float * var_0, float * var_1, long long int var_2, float * var_3, long long int var_4) {
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
        float var_16 = method_17(var_0, var_1, var_2, var_14, var_13, var_15);
        FunPointer0 var_19 = method_18;
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
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5) {
        long long int var_6 = threadIdx.x;
        long long int var_7 = threadIdx.y;
        long long int var_8 = threadIdx.z;
        long long int var_9 = blockIdx.x;
        long long int var_10 = blockIdx.y;
        long long int var_11 = blockIdx.z;
        long long int var_12 = (var_9 * 128);
        long long int var_13 = (var_12 + var_6);
        method_25(var_0, var_1, var_2, var_3, var_4, var_5, var_13);
    }
    __global__ void method_26(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        method_27(var_0, var_1, var_2, var_3, var_4, var_12);
    }
    __global__ void method_28(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        method_29(var_0, var_1, var_9);
    }
    __global__ void method_30(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        method_31(var_0, var_1, var_2, var_10);
    }
    __device__ void method_15(float * var_0, long long int var_1, float * var_2, long long int var_3) {
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
            method_15(var_0, var_1, var_2, var_14);
        } else {
        }
    }
    __device__ float method_17(float * var_0, float * var_1, long long int var_2, long long int var_3, long long int var_4, float var_5) {
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
            return method_17(var_0, var_1, var_2, var_3, var_16, var_15);
        } else {
            return var_5;
        }
    }
    __device__ float method_18(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ void method_25(float var_0, float var_1, float * var_2, float * var_3, long long int var_4, float * var_5, long long int var_6) {
        char var_7 = (var_6 < var_4);
        if (var_7) {
            char var_8 = (var_6 >= 0);
            char var_9 = (var_8 == 0);
            if (var_9) {
                // unprinted assert;
            } else {
            }
            float * var_10 = var_5 + var_6;
            if (var_9) {
                // unprinted assert;
            } else {
            }
            float * var_11 = var_2 + var_6;
            float * var_12 = var_3 + var_6;
            float var_13 = var_10[0];
            float var_14 = var_11[0];
            float var_15 = var_12[0];
            float var_16 = (var_15 - var_14);
            float var_17 = (-2 * var_16);
            float var_18 = (2 * var_16);
            float var_19 = (var_0 * var_17);
            float var_20 = (var_0 * var_18);
            float var_21 = (var_13 + var_19);
            var_10[0] = var_21;
            long long int var_22 = (var_6 + 8192);
            method_25(var_0, var_1, var_2, var_3, var_4, var_5, var_22);
        } else {
        }
    }
    __device__ void method_27(float * var_0, float * var_1, float * var_2, long long int var_3, float * var_4, long long int var_5) {
        char var_6 = (var_5 < var_3);
        if (var_6) {
            char var_7 = (var_5 >= 0);
            char var_8 = (var_7 == 0);
            if (var_8) {
                // unprinted assert;
            } else {
            }
            float * var_9 = var_4 + var_5;
            if (var_8) {
                // unprinted assert;
            } else {
            }
            float * var_10 = var_0 + var_5;
            float * var_11 = var_1 + var_5;
            float * var_12 = var_2 + var_5;
            float var_13 = var_9[0];
            float var_14 = var_10[0];
            float var_15 = var_11[0];
            float var_16 = var_12[0];
            float var_17 = (1 - var_16);
            float var_18 = (var_16 * var_17);
            float var_19 = (var_15 * var_18);
            float var_20 = (var_13 + var_19);
            var_9[0] = var_20;
            long long int var_21 = (var_5 + 8192);
            method_27(var_0, var_1, var_2, var_3, var_4, var_21);
        } else {
        }
    }
    __device__ void method_29(float * var_0, float * var_1, long long int var_2) {
        char var_3 = (var_2 < 7840);
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
            var_6[0] = var_8;
            long long int var_9 = (var_2 + 8192);
            method_29(var_0, var_1, var_9);
        } else {
        }
    }
    __device__ void method_31(float * var_0, float * var_1, float * var_2, long long int var_3) {
        char var_4 = (var_3 < 7840);
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
            float * var_9 = var_1 + var_3;
            float var_10 = var_8[0];
            float var_11 = var_9[0];
            float var_12 = (0.01 * var_10);
            float var_13 = (var_11 - var_12);
            var_7[0] = var_13;
            long long int var_14 = (var_3 + 8192);
            method_31(var_0, var_1, var_2, var_14);
        } else {
        }
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
and method_10((var_0: EnvStack2), (var_1: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_2: ManagedCuda.BasicTypes.SizeT) = var_1.Pointer
    let (var_3: uint64) = uint64 var_2
    let (var_4: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_3)
    let (var_5: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_4)
    var_5
and method_11((var_0: EnvStack2), (var_1: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_2: ManagedCuda.BasicTypes.SizeT) = var_1.Pointer
    let (var_3: uint64) = uint64 var_2
    let (var_4: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_3)
    let (var_5: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_4)
    var_5
and method_12((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack2), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64)): float =
    let (var_21: bool) = (var_11 < var_12)
    if var_21 then
        let (var_22: int64) = (var_11 + 128L)
        let (var_23: bool) = (var_22 > var_12)
        let (var_24: int64) =
            if var_23 then
                var_12
            else
                var_22
        let (var_25: bool) = (var_11 < var_24)
        let (var_26: bool) = (var_25 = false)
        if var_26 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_27: int64) = (var_24 - var_11)
        let (var_28: int64) = (var_11 + var_11)
        let (var_29: int64) = (var_11 + var_24)
        let (var_30: bool) = (var_28 >= var_11)
        let (var_32: bool) =
            if var_30 then
                (var_28 < var_12)
            else
                false
        let (var_33: bool) = (var_32 = false)
        if var_33 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_34: bool) = (var_29 > var_11)
        let (var_36: bool) =
            if var_34 then
                (var_29 <= var_12)
            else
                false
        let (var_37: bool) = (var_36 = false)
        if var_37 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_38: int64) = (var_11 * var_10)
        if var_26 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_39: int64) = (var_17 + var_11)
        let (var_40: int64) = (var_17 + var_24)
        let (var_41: bool) = (var_39 >= var_17)
        let (var_43: bool) =
            if var_41 then
                (var_39 < var_18)
            else
                false
        let (var_44: bool) = (var_43 = false)
        if var_44 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_45: bool) = (var_40 > var_17)
        let (var_47: bool) =
            if var_45 then
                (var_40 <= var_18)
            else
                false
        let (var_48: bool) = (var_47 = false)
        if var_48 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_49: int64) = (var_11 * var_16)
        let (var_50: bool) = (var_27 > 0L)
        let (var_51: bool) = (var_50 = false)
        if var_51 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_52: int64) = (var_27 * 10L)
        let (var_53: int64) = (int64 sizeof<float32>)
        let (var_54: int64) = (var_52 * var_53)
        let (var_55: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_54: int64))
        let (var_56: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_6.set_Stream(var_56)
        let (var_57: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
        let (var_58: int64) = (var_14 - var_13)
        let (var_59: bool) = (var_58 = 784L)
        let (var_60: bool) = (var_59 = false)
        if var_60 then
            (failwith "Colums of a does not match rows of b in GEMM.")
        else
            ()
        let (var_61: bool) = (var_58 = 1L)
        let (var_62: bool) = (var_27 = 1L)
        let (var_63: bool) =
            if var_62 then
                true
            else
                var_61
        if var_63 then
            let (var_64: (Union0 ref)) = var_8.mem_0
            let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_64: (Union0 ref)))
            let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_8: EnvStack2), (var_65: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_67: bool) = (0L < var_27)
            let (var_68: bool) = (var_67 = false)
            if var_68 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_69: bool) = (var_13 < var_14)
            let (var_70: bool) = (var_69 = false)
            if var_70 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_71: int64) = (var_27 * var_58)
            let (var_72: (Union0 ref)) = var_9.mem_0
            let (var_73: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_72: (Union0 ref)))
            let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_38: int64), (var_10: int64), (var_73: ManagedCuda.BasicTypes.CUdeviceptr))
            if var_68 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_75: (Union0 ref)) = var_55.mem_0
            let (var_76: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_75: (Union0 ref)))
            let (var_77: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_55: EnvStack2), (var_76: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_78: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
            let (var_79: (float32 ref)) = (ref 1.000000f)
            let (var_80: (float32 ref)) = (ref 0.000000f)
            let (var_81: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_57, var_78, 784, 10, var_79, var_66, 784, var_74, 1, var_80, var_77, 1)
            if var_81 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_81)
        else
            let (var_82: bool) = (0L < var_27)
            let (var_83: bool) = (var_82 = false)
            if var_83 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_84: bool) = (var_13 < var_14)
            let (var_85: bool) = (var_84 = false)
            if var_85 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_86: int64) = (var_27 * var_58)
            let (var_87: (Union0 ref)) = var_9.mem_0
            let (var_88: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_87: (Union0 ref)))
            let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_38: int64), (var_10: int64), (var_88: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_90: (Union0 ref)) = var_8.mem_0
            let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_90: (Union0 ref)))
            let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_8: EnvStack2), (var_91: ManagedCuda.BasicTypes.CUdeviceptr))
            if var_83 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_93: (Union0 ref)) = var_55.mem_0
            let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_93: (Union0 ref)))
            let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_55: EnvStack2), (var_94: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_96: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_97: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_98: (float32 ref)) = (ref 1.000000f)
            let (var_99: (float32 ref)) = (ref 0.000000f)
            let (var_100: int32) = (int32 var_27)
            let (var_101: int32) = (int32 var_58)
            let (var_102: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_57, var_96, var_97, var_100, 10, var_101, var_98, var_89, var_100, var_92, var_101, var_99, var_95, var_100)
            if var_102 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_102)
        let (var_103: bool) = (0L < var_27)
        let (var_104: bool) = (var_103 = false)
        if var_104 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_105: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_54: int64))
        let (var_106: (Union0 ref)) = var_105.mem_0
        let (var_107: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
        let (var_108: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_105: EnvStack2), (var_107: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_104 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_109: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_110: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_54)
        var_3.ClearMemoryAsync(var_108, 0uy, var_110, var_109)
        if var_104 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_115: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_54: int64))
        let (var_116: bool) = (var_52 > 0L)
        let (var_117: bool) = (var_116 = false)
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_118: (Union0 ref)) = var_55.mem_0
        let (var_119: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_118: (Union0 ref)))
        let (var_120: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_55: EnvStack2), (var_119: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_121: (Union0 ref)) = var_115.mem_0
        let (var_122: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_121: (Union0 ref)))
        let (var_123: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_115: EnvStack2), (var_122: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_14((var_120: ManagedCuda.BasicTypes.CUdeviceptr), (var_52: int64), (var_123: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_125: (System.Object [])) = [|var_120; var_52; var_123|]: (System.Object [])
        let (var_126: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_4, var_3)
        let (var_127: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_126.set_GridDimensions(var_127)
        let (var_128: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_126.set_BlockDimensions(var_128)
        let (var_129: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_126.RunAsync(var_129, var_125)
        if var_104 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_130: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_54: int64))
        let (var_131: (Union0 ref)) = var_130.mem_0
        let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
        let (var_133: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_130: EnvStack2), (var_132: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_104 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_134: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_135: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_54)
        var_3.ClearMemoryAsync(var_133, 0uy, var_135, var_134)
        let (var_136: bool) = (0L = var_19)
        let (var_138: bool) =
            if var_136 then
                (10L = var_20)
            else
                false
        let (var_139: bool) = (var_138 = false)
        if var_139 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_140: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_121: (Union0 ref)))
        let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_115: EnvStack2), (var_140: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_142: (Union0 ref)) = var_15.mem_0
        let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_142: (Union0 ref)))
        let (var_144: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_15: EnvStack2), (var_143: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_145: int64) = (var_52 - 1L)
        let (var_146: int64) = (var_145 / 128L)
        let (var_147: int64) = (var_146 + 1L)
        let (var_148: bool) = (64L > var_147)
        let (var_149: int64) =
            if var_148 then
                var_147
            else
                64L
        let (var_152: bool) = (var_149 > 0L)
        let (var_153: bool) = (var_152 = false)
        if var_153 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_154: int64) = (var_149 * var_53)
        let (var_155: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_154: int64))
        let (var_156: (Union0 ref)) = var_155.mem_0
        let (var_157: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_156: (Union0 ref)))
        let (var_158: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_155: EnvStack2), (var_157: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_16((var_141: ManagedCuda.BasicTypes.CUdeviceptr), (var_144: ManagedCuda.BasicTypes.CUdeviceptr), (var_52: int64), (var_158: ManagedCuda.BasicTypes.CUdeviceptr), (var_149: int64))
        let (var_160: (System.Object [])) = [|var_141; var_144; var_52; var_158; var_149|]: (System.Object [])
        let (var_161: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_4, var_3)
        let (var_162: uint32) = (uint32 var_149)
        let (var_163: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_162, 1u, 1u)
        var_161.set_GridDimensions(var_163)
        let (var_164: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_161.set_BlockDimensions(var_164)
        let (var_165: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_161.RunAsync(var_165, var_160)
        let (var_167: (Union11 ref)) = (ref Union11Case1)
        let (var_168: (float32 ref)) = (ref 0.000000f)
        let (var_170: (Union11 ref)) = (ref Union11Case1)
        let (var_171: (float32 ref)) = (ref 0.000000f)
        let (var_172: float32) = method_23((var_27: int64), (var_155: EnvStack2), (var_149: int64), (var_3: ManagedCuda.CudaContext), (var_167: (Union11 ref)), (var_170: (Union11 ref)))
        let (var_173: string) = System.String.Format("{0}",var_24)
        let (var_174: string) = System.String.Format("{0} = {1}","near_to",var_173)
        let (var_175: string) = System.String.Format("{0}",var_11)
        let (var_176: string) = System.String.Format("{0} = {1}","from",var_175)
        let (var_177: string) = String.concat "; " [|var_176; var_174|]
        let (var_178: string) = System.String.Format("{0}{1}{2}","{",var_177,"}")
        let (var_179: string) = System.String.Format("On minibatch {0}. Error = {1}",var_178,var_172)
        let (var_180: string) = System.String.Format("{0}",var_179)
        System.Console.WriteLine(var_180)
        System.Console.WriteLine("Running the backwards phase...")
        var_171 := 1.000000f
        let (var_181: float32) = method_23((var_27: int64), (var_155: EnvStack2), (var_149: int64), (var_3: ManagedCuda.CudaContext), (var_167: (Union11 ref)), (var_170: (Union11 ref)))
        let (var_182: float32) = (!var_171)
        let (var_183: float32) = method_22((var_155: EnvStack2), (var_149: int64), (var_3: ManagedCuda.CudaContext), (var_167: (Union11 ref)))
        let (var_184: float32) = (float32 var_27)
        let (var_185: float32) = (var_182 / var_184)
        let (var_186: float32) = (!var_168)
        let (var_187: float32) = (var_186 + var_185)
        var_168 := var_187
        let (var_188: float32) = method_22((var_155: EnvStack2), (var_149: int64), (var_3: ManagedCuda.CudaContext), (var_167: (Union11 ref)))
        let (var_189: float32) = (!var_168)
        let (var_191: bool) =
            if var_136 then
                (10L = var_20)
            else
                false
        let (var_192: bool) = (var_191 = false)
        if var_192 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_193: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_121: (Union0 ref)))
        let (var_194: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_115: EnvStack2), (var_193: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_195: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_142: (Union0 ref)))
        let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_15: EnvStack2), (var_195: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_197: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
        let (var_198: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_130: EnvStack2), (var_197: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_24((var_189: float32), (var_188: float32), (var_194: ManagedCuda.BasicTypes.CUdeviceptr), (var_196: ManagedCuda.BasicTypes.CUdeviceptr), (var_52: int64), (var_198: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_200: (System.Object [])) = [|var_189; var_188; var_194; var_196; var_52; var_198|]: (System.Object [])
        let (var_201: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_4, var_3)
        let (var_202: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_201.set_GridDimensions(var_202)
        let (var_203: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_201.set_BlockDimensions(var_203)
        let (var_204: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_201.RunAsync(var_204, var_200)
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_118: (Union0 ref)))
        let (var_206: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_55: EnvStack2), (var_205: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_207: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
        let (var_208: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_130: EnvStack2), (var_207: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_209: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_121: (Union0 ref)))
        let (var_210: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_115: EnvStack2), (var_209: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_117 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_211: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
        let (var_212: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_105: EnvStack2), (var_211: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_26((var_206: ManagedCuda.BasicTypes.CUdeviceptr), (var_208: ManagedCuda.BasicTypes.CUdeviceptr), (var_210: ManagedCuda.BasicTypes.CUdeviceptr), (var_52: int64), (var_212: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_214: (System.Object [])) = [|var_206; var_208; var_210; var_52; var_212|]: (System.Object [])
        let (var_215: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_4, var_3)
        let (var_216: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_215.set_GridDimensions(var_216)
        let (var_217: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_215.set_BlockDimensions(var_217)
        let (var_218: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_215.RunAsync(var_218, var_214)
        let (var_219: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_6.set_Stream(var_219)
        let (var_220: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
        if var_60 then
            (failwith "Output matrix dimensions do not match in GEMM.")
        else
            ()
        if var_62 then
            let (var_221: bool) = (var_27 > var_58)
            let (var_222: int64) =
                if var_221 then
                    var_27
                else
                    var_58
            let (var_223: bool) = (var_27 > 10L)
            let (var_224: int64) =
                if var_223 then
                    var_27
                else
                    10L
            let (var_225: (Union0 ref)) = var_7.mem_0
            let (var_226: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_225: (Union0 ref)))
            let (var_227: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_7: EnvStack2), (var_226: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_228: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_225: (Union0 ref)))
            let (var_229: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_7: EnvStack2), (var_228: ManagedCuda.BasicTypes.CUdeviceptr))
            // Cuda join point
            // method_28((var_227: ManagedCuda.BasicTypes.CUdeviceptr), (var_229: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_231: (System.Object [])) = [|var_227; var_229|]: (System.Object [])
            let (var_232: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_4, var_3)
            let (var_233: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_232.set_GridDimensions(var_233)
            let (var_234: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_232.set_BlockDimensions(var_234)
            let (var_235: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
            var_232.RunAsync(var_235, var_231)
            if var_104 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_236: bool) = (var_13 < var_14)
            let (var_237: bool) = (var_236 = false)
            if var_237 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_238: int64) = (var_27 * var_58)
            let (var_239: (Union0 ref)) = var_9.mem_0
            let (var_240: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_239: (Union0 ref)))
            let (var_241: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_38: int64), (var_10: int64), (var_240: ManagedCuda.BasicTypes.CUdeviceptr))
            if var_104 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_242: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
            let (var_243: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_105: EnvStack2), (var_242: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_244: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_225: (Union0 ref)))
            let (var_245: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_244: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_246: (float32 ref)) = (ref 1.000000f)
            let (var_247: int32) = (int32 var_222)
            let (var_248: int32) = (int32 var_224)
            let (var_249: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSger_v2(var_220, var_247, var_248, var_246, var_241, 1, var_243, 1, var_245, var_247)
            if var_249 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_249)
        else
            if var_61 then
                if var_104 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_250: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
                let (var_251: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_105: EnvStack2), (var_250: ManagedCuda.BasicTypes.CUdeviceptr))
                if var_104 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_252: bool) = (var_13 < var_14)
                let (var_253: bool) = (var_252 = false)
                if var_253 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_254: int64) = (var_27 * var_58)
                let (var_255: (Union0 ref)) = var_9.mem_0
                let (var_256: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_255: (Union0 ref)))
                let (var_257: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_38: int64), (var_10: int64), (var_256: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_258: (Union0 ref)) = var_7.mem_0
                let (var_259: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_258: (Union0 ref)))
                let (var_260: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_259: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_261: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
                let (var_262: (float32 ref)) = (ref 1.000000f)
                let (var_263: (float32 ref)) = (ref 1.000000f)
                let (var_264: int32) = (int32 var_27)
                let (var_265: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_220, var_261, var_264, 10, var_262, var_251, var_264, var_257, 1, var_263, var_260, 1)
                if var_265 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_265)
            else
                if var_104 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_266: bool) = (var_13 < var_14)
                let (var_267: bool) = (var_266 = false)
                if var_267 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_268: int64) = (var_27 * var_58)
                let (var_269: (Union0 ref)) = var_9.mem_0
                let (var_270: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_269: (Union0 ref)))
                let (var_271: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_38: int64), (var_10: int64), (var_270: ManagedCuda.BasicTypes.CUdeviceptr))
                if var_104 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_272: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_106: (Union0 ref)))
                let (var_273: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_105: EnvStack2), (var_272: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_274: (Union0 ref)) = var_7.mem_0
                let (var_275: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_274: (Union0 ref)))
                let (var_276: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_275: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_277: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
                let (var_278: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
                let (var_279: (float32 ref)) = (ref 1.000000f)
                let (var_280: (float32 ref)) = (ref 1.000000f)
                let (var_281: int32) = (int32 var_58)
                let (var_282: int32) = (int32 var_27)
                let (var_283: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_220, var_277, var_278, var_281, 10, var_282, var_279, var_271, var_282, var_273, var_282, var_280, var_276, var_281)
                if var_283 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_283)
        let (var_284: (Union0 ref)) = var_7.mem_0
        let (var_285: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_284: (Union0 ref)))
        let (var_286: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_7: EnvStack2), (var_285: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_287: (Union0 ref)) = var_8.mem_0
        let (var_288: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_287: (Union0 ref)))
        let (var_289: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_8: EnvStack2), (var_288: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_290: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_287: (Union0 ref)))
        let (var_291: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_8: EnvStack2), (var_290: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_30((var_286: ManagedCuda.BasicTypes.CUdeviceptr), (var_289: ManagedCuda.BasicTypes.CUdeviceptr), (var_291: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_293: (System.Object [])) = [|var_286; var_289; var_291|]: (System.Object [])
        let (var_294: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_4, var_3)
        let (var_295: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_294.set_GridDimensions(var_295)
        let (var_296: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_294.set_BlockDimensions(var_296)
        let (var_297: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_294.RunAsync(var_297, var_293)
        let (var_298: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_284: (Union0 ref)))
        let (var_299: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_298: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_300: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_301: int64) = (7840L * var_53)
        let (var_302: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_301)
        var_3.ClearMemoryAsync(var_299, 0uy, var_302, var_300)
        let (var_303: float) = (float var_172)
        let (var_304: float) = (float var_27)
        let (var_305: float) = (var_303 * var_304)
        var_156 := Union0Case1
        var_131 := Union0Case1
        var_121 := Union0Case1
        var_106 := Union0Case1
        var_118 := Union0Case1
        method_32((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack2), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_22: int64), (var_305: float))
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
and method_13((var_0: EnvStack2), (var_1: int64), (var_2: int64), (var_3: ManagedCuda.BasicTypes.CUdeviceptr)): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_4: ManagedCuda.BasicTypes.SizeT) = var_3.Pointer
    let (var_5: uint64) = uint64 var_4
    let (var_6: uint64) = (uint64 var_1)
    let (var_7: uint64) = (var_5 + var_6)
    let (var_8: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_7)
    let (var_9: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_8)
    var_9
and method_23((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref)), (var_5: (Union11 ref))): float32 =
    let (var_6: Union11) = (!var_5)
    match var_6 with
    | Union11Case0(var_7) ->
        var_7.mem_0
    | Union11Case1 ->
        let (var_9: float32) = method_21((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref)))
        var_5 := (Union11Case0(Tuple12(var_9)))
        var_9
and method_22((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: (Union11 ref))): float32 =
    let (var_4: Union11) = (!var_3)
    match var_4 with
    | Union11Case0(var_5) ->
        var_5.mem_0
    | Union11Case1 ->
        let (var_7: float32) = method_19((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext))
        var_3 := (Union11Case0(Tuple12(var_7)))
        var_7
and method_32((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack2), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: float)): float =
    let (var_23: bool) = (var_21 < var_12)
    if var_23 then
        let (var_24: int64) = (var_21 + 128L)
        let (var_25: bool) = (var_24 > var_12)
        let (var_26: int64) =
            if var_25 then
                var_12
            else
                var_24
        let (var_27: bool) = (var_21 < var_26)
        let (var_28: bool) = (var_27 = false)
        if var_28 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_29: int64) = (var_26 - var_21)
        let (var_30: int64) = (var_11 + var_21)
        let (var_31: int64) = (var_11 + var_26)
        let (var_32: bool) = (var_30 >= var_11)
        let (var_34: bool) =
            if var_32 then
                (var_30 < var_12)
            else
                false
        let (var_35: bool) = (var_34 = false)
        if var_35 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_36: bool) = (var_31 > var_11)
        let (var_38: bool) =
            if var_36 then
                (var_31 <= var_12)
            else
                false
        let (var_39: bool) = (var_38 = false)
        if var_39 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_40: int64) = (var_21 * var_10)
        if var_28 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_41: int64) = (var_17 + var_21)
        let (var_42: int64) = (var_17 + var_26)
        let (var_43: bool) = (var_41 >= var_17)
        let (var_45: bool) =
            if var_43 then
                (var_41 < var_18)
            else
                false
        let (var_46: bool) = (var_45 = false)
        if var_46 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_47: bool) = (var_42 > var_17)
        let (var_49: bool) =
            if var_47 then
                (var_42 <= var_18)
            else
                false
        let (var_50: bool) = (var_49 = false)
        if var_50 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_51: int64) = (var_21 * var_16)
        let (var_52: bool) = (var_29 > 0L)
        let (var_53: bool) = (var_52 = false)
        if var_53 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_54: int64) = (var_29 * 10L)
        let (var_55: int64) = (int64 sizeof<float32>)
        let (var_56: int64) = (var_54 * var_55)
        let (var_57: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_56: int64))
        let (var_58: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_6.set_Stream(var_58)
        let (var_59: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
        let (var_60: int64) = (var_14 - var_13)
        let (var_61: bool) = (var_60 = 784L)
        let (var_62: bool) = (var_61 = false)
        if var_62 then
            (failwith "Colums of a does not match rows of b in GEMM.")
        else
            ()
        let (var_63: bool) = (var_60 = 1L)
        let (var_64: bool) = (var_29 = 1L)
        let (var_65: bool) =
            if var_64 then
                true
            else
                var_63
        if var_65 then
            let (var_66: (Union0 ref)) = var_8.mem_0
            let (var_67: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_66: (Union0 ref)))
            let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_8: EnvStack2), (var_67: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_69: bool) = (0L < var_29)
            let (var_70: bool) = (var_69 = false)
            if var_70 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_71: bool) = (var_13 < var_14)
            let (var_72: bool) = (var_71 = false)
            if var_72 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_73: int64) = (var_29 * var_60)
            let (var_74: (Union0 ref)) = var_9.mem_0
            let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_74: (Union0 ref)))
            let (var_76: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_40: int64), (var_10: int64), (var_75: ManagedCuda.BasicTypes.CUdeviceptr))
            if var_70 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_77: (Union0 ref)) = var_57.mem_0
            let (var_78: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_77: (Union0 ref)))
            let (var_79: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_57: EnvStack2), (var_78: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_80: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
            let (var_81: (float32 ref)) = (ref 1.000000f)
            let (var_82: (float32 ref)) = (ref 0.000000f)
            let (var_83: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_59, var_80, 784, 10, var_81, var_68, 784, var_76, 1, var_82, var_79, 1)
            if var_83 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_83)
        else
            let (var_84: bool) = (0L < var_29)
            let (var_85: bool) = (var_84 = false)
            if var_85 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_86: bool) = (var_13 < var_14)
            let (var_87: bool) = (var_86 = false)
            if var_87 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_88: int64) = (var_29 * var_60)
            let (var_89: (Union0 ref)) = var_9.mem_0
            let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_89: (Union0 ref)))
            let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_40: int64), (var_10: int64), (var_90: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_92: (Union0 ref)) = var_8.mem_0
            let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_92: (Union0 ref)))
            let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_8: EnvStack2), (var_93: ManagedCuda.BasicTypes.CUdeviceptr))
            if var_85 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_95: (Union0 ref)) = var_57.mem_0
            let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_95: (Union0 ref)))
            let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_57: EnvStack2), (var_96: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_98: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_99: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
            let (var_100: (float32 ref)) = (ref 1.000000f)
            let (var_101: (float32 ref)) = (ref 0.000000f)
            let (var_102: int32) = (int32 var_29)
            let (var_103: int32) = (int32 var_60)
            let (var_104: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_59, var_98, var_99, var_102, 10, var_103, var_100, var_91, var_102, var_94, var_103, var_101, var_97, var_102)
            if var_104 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_104)
        let (var_105: bool) = (0L < var_29)
        let (var_106: bool) = (var_105 = false)
        if var_106 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_107: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_56: int64))
        let (var_108: (Union0 ref)) = var_107.mem_0
        let (var_109: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_108: (Union0 ref)))
        let (var_110: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_107: EnvStack2), (var_109: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_106 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_111: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_112: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_56)
        var_3.ClearMemoryAsync(var_110, 0uy, var_112, var_111)
        if var_106 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_117: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_56: int64))
        let (var_118: bool) = (var_54 > 0L)
        let (var_119: bool) = (var_118 = false)
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_120: (Union0 ref)) = var_57.mem_0
        let (var_121: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_120: (Union0 ref)))
        let (var_122: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_57: EnvStack2), (var_121: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_123: (Union0 ref)) = var_117.mem_0
        let (var_124: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_123: (Union0 ref)))
        let (var_125: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_117: EnvStack2), (var_124: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_14((var_122: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: int64), (var_125: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_127: (System.Object [])) = [|var_122; var_54; var_125|]: (System.Object [])
        let (var_128: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_4, var_3)
        let (var_129: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_128.set_GridDimensions(var_129)
        let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_128.set_BlockDimensions(var_130)
        let (var_131: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_128.RunAsync(var_131, var_127)
        if var_106 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_132: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_56: int64))
        let (var_133: (Union0 ref)) = var_132.mem_0
        let (var_134: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_133: (Union0 ref)))
        let (var_135: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_132: EnvStack2), (var_134: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_106 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_136: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_137: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_56)
        var_3.ClearMemoryAsync(var_135, 0uy, var_137, var_136)
        let (var_138: bool) = (0L = var_19)
        let (var_140: bool) =
            if var_138 then
                (10L = var_20)
            else
                false
        let (var_141: bool) = (var_140 = false)
        if var_141 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_123: (Union0 ref)))
        let (var_143: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_117: EnvStack2), (var_142: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_144: (Union0 ref)) = var_15.mem_0
        let (var_145: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_144: (Union0 ref)))
        let (var_146: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_15: EnvStack2), (var_145: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_147: int64) = (var_54 - 1L)
        let (var_148: int64) = (var_147 / 128L)
        let (var_149: int64) = (var_148 + 1L)
        let (var_150: bool) = (64L > var_149)
        let (var_151: int64) =
            if var_150 then
                var_149
            else
                64L
        let (var_154: bool) = (var_151 > 0L)
        let (var_155: bool) = (var_154 = false)
        if var_155 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_156: int64) = (var_151 * var_55)
        let (var_157: EnvStack2) = method_7((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_1: uint64), (var_156: int64))
        let (var_158: (Union0 ref)) = var_157.mem_0
        let (var_159: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_158: (Union0 ref)))
        let (var_160: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_157: EnvStack2), (var_159: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_16((var_143: ManagedCuda.BasicTypes.CUdeviceptr), (var_146: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: int64), (var_160: ManagedCuda.BasicTypes.CUdeviceptr), (var_151: int64))
        let (var_162: (System.Object [])) = [|var_143; var_146; var_54; var_160; var_151|]: (System.Object [])
        let (var_163: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_4, var_3)
        let (var_164: uint32) = (uint32 var_151)
        let (var_165: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(var_164, 1u, 1u)
        var_163.set_GridDimensions(var_165)
        let (var_166: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_163.set_BlockDimensions(var_166)
        let (var_167: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_163.RunAsync(var_167, var_162)
        let (var_169: (Union11 ref)) = (ref Union11Case1)
        let (var_170: (float32 ref)) = (ref 0.000000f)
        let (var_172: (Union11 ref)) = (ref Union11Case1)
        let (var_173: (float32 ref)) = (ref 0.000000f)
        let (var_174: float32) = method_23((var_29: int64), (var_157: EnvStack2), (var_151: int64), (var_3: ManagedCuda.CudaContext), (var_169: (Union11 ref)), (var_172: (Union11 ref)))
        let (var_175: string) = System.String.Format("{0}",var_26)
        let (var_176: string) = System.String.Format("{0} = {1}","near_to",var_175)
        let (var_177: string) = System.String.Format("{0}",var_21)
        let (var_178: string) = System.String.Format("{0} = {1}","from",var_177)
        let (var_179: string) = String.concat "; " [|var_178; var_176|]
        let (var_180: string) = System.String.Format("{0}{1}{2}","{",var_179,"}")
        let (var_181: string) = System.String.Format("On minibatch {0}. Error = {1}",var_180,var_174)
        let (var_182: string) = System.String.Format("{0}",var_181)
        System.Console.WriteLine(var_182)
        System.Console.WriteLine("Running the backwards phase...")
        var_173 := 1.000000f
        let (var_183: float32) = method_23((var_29: int64), (var_157: EnvStack2), (var_151: int64), (var_3: ManagedCuda.CudaContext), (var_169: (Union11 ref)), (var_172: (Union11 ref)))
        let (var_184: float32) = (!var_173)
        let (var_185: float32) = method_22((var_157: EnvStack2), (var_151: int64), (var_3: ManagedCuda.CudaContext), (var_169: (Union11 ref)))
        let (var_186: float32) = (float32 var_29)
        let (var_187: float32) = (var_184 / var_186)
        let (var_188: float32) = (!var_170)
        let (var_189: float32) = (var_188 + var_187)
        var_170 := var_189
        let (var_190: float32) = method_22((var_157: EnvStack2), (var_151: int64), (var_3: ManagedCuda.CudaContext), (var_169: (Union11 ref)))
        let (var_191: float32) = (!var_170)
        let (var_193: bool) =
            if var_138 then
                (10L = var_20)
            else
                false
        let (var_194: bool) = (var_193 = false)
        if var_194 then
            (failwith "All tensors in zip need to have the same dimensions")
        else
            ()
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_195: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_123: (Union0 ref)))
        let (var_196: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_117: EnvStack2), (var_195: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_197: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_144: (Union0 ref)))
        let (var_198: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_15: EnvStack2), (var_197: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_199: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_133: (Union0 ref)))
        let (var_200: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_132: EnvStack2), (var_199: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_24((var_191: float32), (var_190: float32), (var_196: ManagedCuda.BasicTypes.CUdeviceptr), (var_198: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: int64), (var_200: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_202: (System.Object [])) = [|var_191; var_190; var_196; var_198; var_54; var_200|]: (System.Object [])
        let (var_203: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_4, var_3)
        let (var_204: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_203.set_GridDimensions(var_204)
        let (var_205: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_203.set_BlockDimensions(var_205)
        let (var_206: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_203.RunAsync(var_206, var_202)
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_207: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_120: (Union0 ref)))
        let (var_208: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_57: EnvStack2), (var_207: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_209: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_133: (Union0 ref)))
        let (var_210: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_132: EnvStack2), (var_209: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_211: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_123: (Union0 ref)))
        let (var_212: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_117: EnvStack2), (var_211: ManagedCuda.BasicTypes.CUdeviceptr))
        if var_119 then
            (failwith "Tensor needs to be at least size 1.")
        else
            ()
        let (var_213: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_108: (Union0 ref)))
        let (var_214: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_107: EnvStack2), (var_213: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_26((var_208: ManagedCuda.BasicTypes.CUdeviceptr), (var_210: ManagedCuda.BasicTypes.CUdeviceptr), (var_212: ManagedCuda.BasicTypes.CUdeviceptr), (var_54: int64), (var_214: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_216: (System.Object [])) = [|var_208; var_210; var_212; var_54; var_214|]: (System.Object [])
        let (var_217: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_26", var_4, var_3)
        let (var_218: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_217.set_GridDimensions(var_218)
        let (var_219: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_217.set_BlockDimensions(var_219)
        let (var_220: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_217.RunAsync(var_220, var_216)
        let (var_221: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_6.set_Stream(var_221)
        let (var_222: ManagedCuda.CudaBlas.CudaBlasHandle) = var_6.get_CublasHandle()
        if var_62 then
            (failwith "Output matrix dimensions do not match in GEMM.")
        else
            ()
        if var_64 then
            let (var_223: bool) = (var_29 > var_60)
            let (var_224: int64) =
                if var_223 then
                    var_29
                else
                    var_60
            let (var_225: bool) = (var_29 > 10L)
            let (var_226: int64) =
                if var_225 then
                    var_29
                else
                    10L
            let (var_227: (Union0 ref)) = var_7.mem_0
            let (var_228: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_227: (Union0 ref)))
            let (var_229: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_7: EnvStack2), (var_228: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_230: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_227: (Union0 ref)))
            let (var_231: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_7: EnvStack2), (var_230: ManagedCuda.BasicTypes.CUdeviceptr))
            // Cuda join point
            // method_28((var_229: ManagedCuda.BasicTypes.CUdeviceptr), (var_231: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_233: (System.Object [])) = [|var_229; var_231|]: (System.Object [])
            let (var_234: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_4, var_3)
            let (var_235: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
            var_234.set_GridDimensions(var_235)
            let (var_236: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
            var_234.set_BlockDimensions(var_236)
            let (var_237: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
            var_234.RunAsync(var_237, var_233)
            if var_106 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_238: bool) = (var_13 < var_14)
            let (var_239: bool) = (var_238 = false)
            if var_239 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_240: int64) = (var_29 * var_60)
            let (var_241: (Union0 ref)) = var_9.mem_0
            let (var_242: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_241: (Union0 ref)))
            let (var_243: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_40: int64), (var_10: int64), (var_242: ManagedCuda.BasicTypes.CUdeviceptr))
            if var_106 then
                (failwith "Tensor needs to be at least size 1.")
            else
                ()
            let (var_244: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_108: (Union0 ref)))
            let (var_245: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_107: EnvStack2), (var_244: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_246: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_227: (Union0 ref)))
            let (var_247: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_246: ManagedCuda.BasicTypes.CUdeviceptr))
            let (var_248: (float32 ref)) = (ref 1.000000f)
            let (var_249: int32) = (int32 var_224)
            let (var_250: int32) = (int32 var_226)
            let (var_251: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSger_v2(var_222, var_249, var_250, var_248, var_243, 1, var_245, 1, var_247, var_249)
            if var_251 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_251)
        else
            if var_63 then
                if var_106 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_252: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_108: (Union0 ref)))
                let (var_253: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_107: EnvStack2), (var_252: ManagedCuda.BasicTypes.CUdeviceptr))
                if var_106 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_254: bool) = (var_13 < var_14)
                let (var_255: bool) = (var_254 = false)
                if var_255 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_256: int64) = (var_29 * var_60)
                let (var_257: (Union0 ref)) = var_9.mem_0
                let (var_258: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_257: (Union0 ref)))
                let (var_259: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_40: int64), (var_10: int64), (var_258: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_260: (Union0 ref)) = var_7.mem_0
                let (var_261: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_260: (Union0 ref)))
                let (var_262: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_261: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_263: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
                let (var_264: (float32 ref)) = (ref 1.000000f)
                let (var_265: (float32 ref)) = (ref 1.000000f)
                let (var_266: int32) = (int32 var_29)
                let (var_267: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemv_v2(var_222, var_263, var_266, 10, var_264, var_253, var_266, var_259, 1, var_265, var_262, 1)
                if var_267 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_267)
            else
                if var_106 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_268: bool) = (var_13 < var_14)
                let (var_269: bool) = (var_268 = false)
                if var_269 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_270: int64) = (var_29 * var_60)
                let (var_271: (Union0 ref)) = var_9.mem_0
                let (var_272: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_271: (Union0 ref)))
                let (var_273: ManagedCuda.BasicTypes.CUdeviceptr) = method_13((var_9: EnvStack2), (var_40: int64), (var_10: int64), (var_272: ManagedCuda.BasicTypes.CUdeviceptr))
                if var_106 then
                    (failwith "Tensor needs to be at least size 1.")
                else
                    ()
                let (var_274: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_108: (Union0 ref)))
                let (var_275: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_107: EnvStack2), (var_274: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_276: (Union0 ref)) = var_7.mem_0
                let (var_277: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_276: (Union0 ref)))
                let (var_278: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_277: ManagedCuda.BasicTypes.CUdeviceptr))
                let (var_279: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
                let (var_280: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
                let (var_281: (float32 ref)) = (ref 1.000000f)
                let (var_282: (float32 ref)) = (ref 1.000000f)
                let (var_283: int32) = (int32 var_60)
                let (var_284: int32) = (int32 var_29)
                let (var_285: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_222, var_279, var_280, var_283, 10, var_284, var_281, var_273, var_284, var_275, var_284, var_282, var_278, var_283)
                if var_285 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_285)
        let (var_286: (Union0 ref)) = var_7.mem_0
        let (var_287: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_286: (Union0 ref)))
        let (var_288: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_7: EnvStack2), (var_287: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_289: (Union0 ref)) = var_8.mem_0
        let (var_290: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_289: (Union0 ref)))
        let (var_291: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_8: EnvStack2), (var_290: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_292: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_289: (Union0 ref)))
        let (var_293: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_8: EnvStack2), (var_292: ManagedCuda.BasicTypes.CUdeviceptr))
        // Cuda join point
        // method_30((var_288: ManagedCuda.BasicTypes.CUdeviceptr), (var_291: ManagedCuda.BasicTypes.CUdeviceptr), (var_293: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_295: (System.Object [])) = [|var_288; var_291; var_293|]: (System.Object [])
        let (var_296: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_30", var_4, var_3)
        let (var_297: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
        var_296.set_GridDimensions(var_297)
        let (var_298: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_296.set_BlockDimensions(var_298)
        let (var_299: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        var_296.RunAsync(var_299, var_295)
        let (var_300: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_286: (Union0 ref)))
        let (var_301: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_7: EnvStack2), (var_300: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_302: ManagedCuda.BasicTypes.CUstream) = var_5.get_Stream()
        let (var_303: int64) = (7840L * var_55)
        let (var_304: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_303)
        var_3.ClearMemoryAsync(var_301, 0uy, var_304, var_302)
        let (var_305: float) = (float var_174)
        let (var_306: float) = (float var_29)
        let (var_307: float) = (var_305 * var_306)
        let (var_308: float) = (var_22 + var_307)
        var_158 := Union0Case1
        var_133 := Union0Case1
        var_123 := Union0Case1
        var_108 := Union0Case1
        var_120 := Union0Case1
        method_32((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env3>), (var_3: ManagedCuda.CudaContext), (var_4: ManagedCuda.BasicTypes.CUmodule), (var_5: ManagedCuda.CudaStream), (var_6: ManagedCuda.CudaBlas.CudaBlas), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: EnvStack2), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_24: int64), (var_308: float))
    else
        var_22
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
and method_21((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref))): float32 =
    let (var_5: float32) = method_22((var_1: EnvStack2), (var_2: int64), (var_3: ManagedCuda.CudaContext), (var_4: (Union11 ref)))
    let (var_6: float32) = (float32 var_0)
    (var_5 / var_6)
and method_19((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext)): float32 =
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
    method_20((var_7: (float32 [])), (var_1: int64), (var_9: int64), (var_8: float32))
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
let (var_57: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
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
let (var_94: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
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
let (var_131: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
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
let (var_168: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
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
let (var_232: ManagedCuda.BasicTypes.CUdeviceptr) = method_10((var_228: EnvStack2), (var_231: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_233: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_36.GenerateNormal32(var_232, var_233, 0.000000f, var_226)
let (var_234: EnvStack2) = method_7((var_54: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_55: uint64), (var_227: int64))
let (var_235: (Union0 ref)) = var_234.mem_0
let (var_236: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_235: (Union0 ref)))
let (var_237: ManagedCuda.BasicTypes.CUdeviceptr) = method_11((var_234: EnvStack2), (var_236: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_238: ManagedCuda.BasicTypes.CUstream) = var_56.get_Stream()
let (var_239: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_227)
var_1.ClearMemoryAsync(var_237, 0uy, var_239, var_238)
let (var_240: bool) = (var_138 = var_175)
let (var_242: bool) =
    if var_240 then
        (var_139 = var_176)
    else
        false
let (var_243: bool) = (var_242 = false)
if var_243 then
    (failwith "Training and test set need to have to equal first dimensions.")
else
    ()
let (var_244: float) = method_12((var_54: uint64), (var_55: uint64), (var_50: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_56: ManagedCuda.CudaStream), (var_39: ManagedCuda.CudaBlas.CudaBlas), (var_234: EnvStack2), (var_228: EnvStack2), (var_218: EnvStack2), (var_156: int64), (var_138: int64), (var_139: int64), (var_152: int64), (var_153: int64), (var_223: EnvStack2), (var_193: int64), (var_175: int64), (var_176: int64), (var_189: int64), (var_190: int64))
System.Console.WriteLine("-----")
System.Console.WriteLine("Batch done.")
let (var_245: float) = (float var_157)
let (var_246: float) = (var_244 / var_245)
let (var_247: string) = System.String.Format("Average of batch costs is {0}.",var_246)
let (var_248: string) = System.String.Format("{0}",var_247)
System.Console.WriteLine(var_248)
System.Console.WriteLine("-----")
var_235 := Union0Case1
var_230 := Union0Case1
var_56.Dispose()
let (var_249: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_51: (Union0 ref)))
var_1.FreeMemory(var_249)
var_51 := Union0Case1
var_39.Dispose()
var_36.Dispose()
var_1.Dispose()

