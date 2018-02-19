module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_16(long long int * var_0, long long int * var_1);
    __global__ void method_25(long long int * var_0, long long int * var_1);
    __device__ char method_17(long long int * var_0, long long int * var_1);
    
    __global__ void method_16(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (256 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_17(var_7, var_8)) {
            long long int var_10 = var_7[0];
            long long int var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 1024);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = var_0[var_10];
            long long int var_17 = (var_11 + var_16);
            long long int var_18 = (var_10 + 512);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
        long long int var_21 = cub::BlockReduce<long long int,256,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        long long int var_22 = threadIdx.x;
        char var_23 = (var_22 == 0);
        if (var_23) {
            long long int var_24 = blockIdx.x;
            char var_25 = (var_24 >= 0);
            char var_27;
            if (var_25) {
                var_27 = (var_24 < 2);
            } else {
                var_27 = 0;
            }
            char var_28 = (var_27 == 0);
            if (var_28) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_24] = var_21;
        } else {
        }
    }
    __global__ void method_25(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (2 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_17(var_7, var_8)) {
            long long int var_10 = var_7[0];
            long long int var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 2);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = var_0[var_10];
            long long int var_17 = (var_11 + var_16);
            long long int var_18 = (var_10 + 2);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
        long long int var_21 = threadIdx.x;
        printf("%i=%lld\n", var_21, var_20);
        long long int var_22 = cub::BlockReduce<long long int,2,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        long long int var_23 = threadIdx.x;
        char var_24 = (var_23 == 0);
        if (var_24) {
            long long int var_25 = blockIdx.x;
            char var_26 = (var_25 >= 0);
            char var_28;
            if (var_26) {
                var_28 = (var_25 < 1);
            } else {
                var_28 = 0;
            }
            char var_29 = (var_28 == 0);
            if (var_29) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_25] = var_22;
        } else {
        }
    }
    __device__ char method_17(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 1024);
    }
}
"""

type EnvStack0 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env1 =
    struct
    val mem_0: uint64
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env2 =
    struct
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvHeap3 =
    {
    mem_0: (int64 ref)
    mem_1: EnvStack0
    }
and EnvHeap4 =
    {
    mem_0: (int64 ref)
    mem_1: EnvHeap5
    }
and EnvHeap5 =
    {
    mem_0: (bool ref)
    mem_1: ManagedCuda.CudaStream
    }
and EnvStack6 =
    struct
    val mem_0: EnvHeap3
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvHeap7 =
    {
    mem_0: EnvStack0
    mem_1: uint64
    mem_2: ResizeArray<Env1>
    mem_3: ResizeArray<Env2>
    }
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>)): unit =
    let (var_5: (Env2 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env2 -> (Env2 -> int32))) = method_3
    let (var_9: System.Comparison<Env2>) = System.Comparison<Env2>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: (uint64 ref)) = var_1.mem_0
    let (var_12: uint64) = method_5((var_11: (uint64 ref)))
    let (var_13: int32) = 0
    let (var_14: uint64) = method_6((var_0: ResizeArray<Env1>), (var_3: ResizeArray<Env2>), (var_10: int32), (var_12: uint64), (var_13: int32))
    let (var_15: uint64) = method_5((var_11: (uint64 ref)))
    let (var_16: uint64) = (var_15 + var_2)
    let (var_17: uint64) = (var_16 - var_14)
    let (var_18: uint64) = (var_14 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: uint64) = (var_20 - var_14)
    let (var_22: bool) = (var_17 > var_21)
    if var_22 then
        let (var_23: uint64) = (var_17 - var_21)
        var_0.Add((Env1(var_20, var_23)))
    else
        ()
and method_7((var_0: EnvHeap5), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule)): EnvHeap4 =
    let (var_11: (int64 ref)) = (ref 0L)
    let (var_12: EnvHeap4) = ({mem_0 = (var_11: (int64 ref)); mem_1 = (var_0: EnvHeap5)} : EnvHeap4)
    method_8((var_12: EnvHeap4), (var_9: ResizeArray<EnvHeap4>))
    var_12
and method_9((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 1024L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_5: int64) = (1L + var_1)
        var_0.[int32 var_1] <- var_5
        let (var_6: int64) = (var_1 + 1L)
        method_9((var_0: (int64 [])), (var_6: int64))
    else
        ()
and method_10((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64)): EnvStack6 =
    let (var_15: int64) = (var_11 * var_14)
    let (var_16: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_12,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_17: int64) = var_16.AddrOfPinnedObject().ToInt64()
    let (var_18: uint64) = (uint64 var_17)
    let (var_19: int64) = (var_13 * 8L)
    let (var_20: uint64) = (uint64 var_19)
    let (var_21: uint64) = (var_20 + var_18)
    let (var_22: int64) = (var_15 * 8L)
    let (var_23: EnvHeap7) = ({mem_0 = (var_2: EnvStack0); mem_1 = (var_3: uint64); mem_2 = (var_4: ResizeArray<Env1>); mem_3 = (var_5: ResizeArray<Env2>)} : EnvHeap7)
    let (var_24: EnvHeap3) = method_11((var_23: EnvHeap7), (var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_22: int64))
    let (var_25: EnvStack6) = EnvStack6((var_24: EnvHeap3))
    let (var_26: EnvHeap3) = var_25.mem_0
    let (var_27: (int64 ref)) = var_26.mem_0
    let (var_28: EnvStack0) = var_26.mem_1
    let (var_29: (uint64 ref)) = var_28.mem_0
    let (var_30: uint64) = method_5((var_29: (uint64 ref)))
    let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_30)
    let (var_32: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_31)
    let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_21)
    let (var_34: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_33)
    let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
    let (var_36: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_32, var_34, var_35)
    if var_36 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_36)
    var_16.Free()
    var_25
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_11((var_0: EnvHeap7), (var_1: ManagedCuda.CudaBlas.CudaBlas), (var_2: ManagedCuda.CudaRand.CudaRandDevice), (var_3: EnvStack0), (var_4: uint64), (var_5: ResizeArray<Env1>), (var_6: ResizeArray<Env2>), (var_7: ManagedCuda.CudaContext), (var_8: ResizeArray<EnvHeap3>), (var_9: ResizeArray<EnvHeap4>), (var_10: ManagedCuda.BasicTypes.CUmodule), (var_11: EnvHeap4), (var_12: int64)): EnvHeap3 =
    let (var_13: EnvStack0) = var_0.mem_0
    let (var_14: uint64) = var_0.mem_1
    let (var_15: ResizeArray<Env1>) = var_0.mem_2
    let (var_16: ResizeArray<Env2>) = var_0.mem_3
    let (var_17: uint64) = (uint64 var_12)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: uint64) = (var_18 - 1UL)
    let (var_20: uint64) = (var_19 &&& 18446744073709551360UL)
    let (var_21: EnvStack0) = method_12((var_15: ResizeArray<Env1>), (var_13: EnvStack0), (var_14: uint64), (var_16: ResizeArray<Env2>), (var_20: uint64))
    let (var_22: (int64 ref)) = (ref 0L)
    let (var_23: EnvHeap3) = ({mem_0 = (var_22: (int64 ref)); mem_1 = (var_21: EnvStack0)} : EnvHeap3)
    method_15((var_23: EnvHeap3), (var_8: ResizeArray<EnvHeap3>))
    var_23
and method_18((var_0: (bool ref)), (var_1: ManagedCuda.CudaStream)): ManagedCuda.BasicTypes.CUstream =
    let (var_2: bool) = (!var_0)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "The stream has been disposed.")
    else
        ()
    var_1.Stream
and method_19((var_0: int64), (var_1: EnvStack6), (var_2: int64), (var_3: int64)): (int64 []) =
    let (var_4: EnvHeap3) = var_1.mem_0
    let (var_5: int64) = (var_0 * var_3)
    let (var_6: (int64 ref)) = var_4.mem_0
    let (var_7: EnvStack0) = var_4.mem_1
    let (var_8: (uint64 ref)) = var_7.mem_0
    let (var_9: uint64) = method_5((var_8: (uint64 ref)))
    let (var_10: int64) = (var_2 * 8L)
    let (var_11: uint64) = (uint64 var_10)
    let (var_12: uint64) = (var_9 + var_11)
    let (var_13: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_5))
    let (var_14: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_13,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_15: int64) = var_14.AddrOfPinnedObject().ToInt64()
    let (var_16: uint64) = (uint64 var_15)
    let (var_17: int64) = (var_5 * 8L)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_16)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_12)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_23: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_19, var_21, var_22)
    if var_23 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_23)
    var_14.Free()
    var_13
and method_20((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: EnvStack6), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64)): unit =
    let (var_16: int64) = (var_15 - var_14)
    let (var_17: bool) = (var_16 > 0L)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_19: (int64 [])) = method_19((var_16: int64), (var_11: EnvStack6), (var_12: int64), (var_13: int64))
    method_21((var_19: (int64 [])), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64))
and method_26((var_0: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (EnvHeap3 -> unit)) = method_27
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_28((var_0: ManagedCuda.CudaBlas.CudaBlas), (var_1: ManagedCuda.CudaRand.CudaRandDevice), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: ResizeArray<Env2>), (var_6: ManagedCuda.CudaContext), (var_7: ResizeArray<EnvHeap3>), (var_8: ResizeArray<EnvHeap4>), (var_9: ManagedCuda.BasicTypes.CUmodule), (var_10: EnvHeap4), (var_11: EnvStack6), (var_12: int64)): unit =
    let (var_13: int64) = 1L
    let (var_14: (int64 [])) = method_29((var_13: int64), (var_11: EnvStack6), (var_12: int64))
    method_30((var_14: (int64 [])), (var_12: int64))
and method_31((var_0: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (EnvHeap4 -> unit)) = method_32
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_2 ((var_0: Env2)): bool =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env2)): (Env2 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_4((var_1: EnvStack0))
and method_6((var_0: ResizeArray<Env1>), (var_1: ResizeArray<Env2>), (var_2: int32), (var_3: uint64), (var_4: int32)): uint64 =
    let (var_5: bool) = (var_4 < var_2)
    if var_5 then
        let (var_6: Env2) = var_1.[var_4]
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: bool) = (var_10 >= var_3)
        let (var_12: bool) = (var_11 = false)
        if var_12 then
            (failwith "The next pointer should be higher than the last.")
        else
            ()
        let (var_13: uint64) = method_5((var_9: (uint64 ref)))
        let (var_14: uint64) = (var_13 - var_3)
        let (var_15: uint64) = (var_3 + 256UL)
        let (var_16: uint64) = (var_15 - 1UL)
        let (var_17: uint64) = (var_16 &&& 18446744073709551360UL)
        let (var_18: uint64) = (var_17 - var_3)
        let (var_19: bool) = (var_14 > var_18)
        if var_19 then
            let (var_20: uint64) = (var_14 - var_18)
            var_0.Add((Env1(var_17, var_20)))
        else
            ()
        let (var_21: uint64) = method_5((var_9: (uint64 ref)))
        let (var_22: uint64) = (var_21 + var_8)
        let (var_23: int32) = (var_4 + 1)
        method_6((var_0: ResizeArray<Env1>), (var_1: ResizeArray<Env2>), (var_2: int32), (var_22: uint64), (var_23: int32))
    else
        var_3
and method_8((var_0: EnvHeap4), (var_1: ResizeArray<EnvHeap4>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvHeap5) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_12((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>), (var_4: uint64)): EnvStack0 =
    let (var_5: int32) = var_0.get_Count()
    let (var_6: bool) = (var_5 > 0)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Out of memory in the designated section.")
    else
        ()
    let (var_8: Env1) = var_0.[0]
    let (var_9: uint64) = var_8.mem_0
    let (var_10: uint64) = var_8.mem_1
    let (var_11: bool) = (var_4 <= var_10)
    let (var_41: Env2) =
        if var_11 then
            let (var_12: uint64) = (var_9 + var_4)
            let (var_13: uint64) = (var_10 - var_4)
            var_0.[0] <- (Env1(var_12, var_13))
            let (var_14: (uint64 ref)) = (ref var_9)
            let (var_15: EnvStack0) = EnvStack0((var_14: (uint64 ref)))
            (Env2(var_15, var_4))
        else
            let (var_17: (Env1 -> (Env1 -> int32))) = method_13
            let (var_18: System.Comparison<Env1>) = System.Comparison<Env1>(var_17)
            var_0.Sort(var_18)
            let (var_19: Env1) = var_0.[0]
            let (var_20: uint64) = var_19.mem_0
            let (var_21: uint64) = var_19.mem_1
            let (var_22: bool) = (var_4 <= var_21)
            if var_22 then
                let (var_23: uint64) = (var_20 + var_4)
                let (var_24: uint64) = (var_21 - var_4)
                var_0.[0] <- (Env1(var_23, var_24))
                let (var_25: (uint64 ref)) = (ref var_20)
                let (var_26: EnvStack0) = EnvStack0((var_25: (uint64 ref)))
                (Env2(var_26, var_4))
            else
                method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env2>))
                let (var_28: (Env1 -> (Env1 -> int32))) = method_13
                let (var_29: System.Comparison<Env1>) = System.Comparison<Env1>(var_28)
                var_0.Sort(var_29)
                let (var_30: Env1) = var_0.[0]
                let (var_31: uint64) = var_30.mem_0
                let (var_32: uint64) = var_30.mem_1
                let (var_33: bool) = (var_4 <= var_32)
                if var_33 then
                    let (var_34: uint64) = (var_31 + var_4)
                    let (var_35: uint64) = (var_32 - var_4)
                    var_0.[0] <- (Env1(var_34, var_35))
                    let (var_36: (uint64 ref)) = (ref var_31)
                    let (var_37: EnvStack0) = EnvStack0((var_36: (uint64 ref)))
                    (Env2(var_37, var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_42: EnvStack0) = var_41.mem_0
    let (var_43: uint64) = var_41.mem_1
    var_3.Add((Env2(var_42, var_43)))
    var_42
and method_15((var_0: EnvHeap3), (var_1: ResizeArray<EnvHeap3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_21((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64)): unit =
    let (var_5: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_6: string) = ""
    let (var_7: int64) = 0L
    let (var_8: int64) = 0L
    method_22((var_5: System.Text.StringBuilder), (var_8: int64))
    let (var_9: System.Text.StringBuilder) = var_5.Append("[|")
    let (var_10: int64) = method_23((var_5: System.Text.StringBuilder), (var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_6: string), (var_7: int64))
    let (var_11: System.Text.StringBuilder) = var_5.AppendLine("|]")
    let (var_12: string) = var_5.ToString()
    let (var_13: string) = System.String.Format("{0}",var_12)
    System.Console.WriteLine(var_13)
and method_27 ((var_0: EnvHeap3)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvStack0) = var_0.mem_1
    let (var_3: int64) = (!var_1)
    let (var_4: int64) = (var_3 - 1L)
    var_1 := var_4
    let (var_5: int64) = (!var_1)
    let (var_6: bool) = (var_5 = 0L)
    if var_6 then
        let (var_7: (uint64 ref)) = var_2.mem_0
        var_7 := 0UL
    else
        ()
and method_29((var_0: int64), (var_1: EnvStack6), (var_2: int64)): (int64 []) =
    let (var_3: EnvHeap3) = var_1.mem_0
    let (var_4: (int64 ref)) = var_3.mem_0
    let (var_5: EnvStack0) = var_3.mem_1
    let (var_6: (uint64 ref)) = var_5.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: int64) = (var_2 * 8L)
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (var_7 + var_9)
    let (var_11: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_0))
    let (var_12: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_11,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_13: int64) = var_12.AddrOfPinnedObject().ToInt64()
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: int64) = (var_0 * 8L)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_10)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_17, var_19, var_20)
    if var_21 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_21)
    var_12.Free()
    var_11
and method_30((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_3: string) = ""
    let (var_4: int64) = 0L
    let (var_5: int64) = var_0.[int32 var_1]
    let (var_6: string) = System.String.Format("{0}",var_5)
    let (var_7: System.Text.StringBuilder) = var_2.Append(var_6)
    let (var_8: string) = var_2.ToString()
    let (var_9: string) = System.String.Format("{0}",var_8)
    System.Console.WriteLine(var_9)
and method_32 ((var_0: EnvHeap4)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvHeap5) = var_0.mem_1
    let (var_3: int64) = (!var_1)
    let (var_4: int64) = (var_3 - 1L)
    var_1 := var_4
    let (var_5: int64) = (!var_1)
    let (var_6: bool) = (var_5 = 0L)
    if var_6 then
        let (var_7: (bool ref)) = var_2.mem_0
        let (var_8: ManagedCuda.CudaStream) = var_2.mem_1
        var_8.Dispose()
        var_7 := false
    else
        ()
and method_4 ((var_1: EnvStack0)) ((var_0: Env2)): int32 =
    let (var_2: EnvStack0) = var_0.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: (uint64 ref)) = var_1.mem_0
    let (var_5: uint64) = method_5((var_4: (uint64 ref)))
    let (var_6: (uint64 ref)) = var_2.mem_0
    let (var_7: uint64) = method_5((var_6: (uint64 ref)))
    let (var_8: bool) = (var_5 < var_7)
    if var_8 then
        -1
    else
        let (var_9: bool) = (var_5 = var_7)
        if var_9 then
            0
        else
            1
and method_13 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: uint64) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_14((var_2: uint64))
and method_22((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_22((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_23((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): int64 =
    let (var_8: bool) = (var_4 < var_5)
    if var_8 then
        let (var_9: bool) = (var_7 < 1000L)
        if var_9 then
            let (var_10: System.Text.StringBuilder) = var_0.Append(var_6)
            let (var_11: bool) = (var_4 >= var_4)
            let (var_12: bool) = (var_11 = false)
            if var_12 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_13: int64) = var_1.[int32 var_2]
            let (var_14: string) = System.String.Format("{0}",var_13)
            let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
            let (var_16: string) = "; "
            let (var_17: int64) = (var_7 + 1L)
            let (var_18: int64) = (var_4 + 1L)
            method_24((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_16: string), (var_17: int64), (var_18: int64))
        else
            let (var_20: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_14 ((var_1: uint64)) ((var_0: Env1)): int32 =
    let (var_2: uint64) = var_0.mem_0
    let (var_3: uint64) = var_0.mem_1
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        -1
    else
        let (var_5: bool) = (var_3 = var_1)
        if var_5 then
            0
        else
            1
and method_24((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64), (var_8: int64)): int64 =
    let (var_9: bool) = (var_8 < var_5)
    if var_9 then
        let (var_10: bool) = (var_7 < 1000L)
        if var_10 then
            let (var_11: System.Text.StringBuilder) = var_0.Append(var_6)
            let (var_12: bool) = (var_8 >= var_4)
            let (var_13: bool) = (var_12 = false)
            if var_13 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_14: int64) = (var_8 - var_4)
            let (var_15: int64) = (var_14 * var_3)
            let (var_16: int64) = (var_2 + var_15)
            let (var_17: int64) = var_1.[int32 var_16]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: System.Text.StringBuilder) = var_0.Append(var_18)
            let (var_20: string) = "; "
            let (var_21: int64) = (var_7 + 1L)
            let (var_22: int64) = (var_8 + 1L)
            method_24((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_20: string), (var_21: int64), (var_22: int64))
        else
            let (var_24: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
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
let (var_35: uint64) = 1048576UL
let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_36)
let (var_38: uint64) = uint64 var_37
let (var_39: (uint64 ref)) = (ref var_38)
let (var_40: EnvStack0) = EnvStack0((var_39: (uint64 ref)))
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: ResizeArray<Env2>) = ResizeArray<Env2>()
method_1((var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env2>))
let (var_43: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_44: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_43)
let (var_45: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_46: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_47: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_45, var_46)
let (var_56: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_68: ResizeArray<EnvHeap4>) = ResizeArray<EnvHeap4>()
let (var_69: (bool ref)) = (ref true)
let (var_70: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_71: EnvHeap5) = ({mem_0 = (var_69: (bool ref)); mem_1 = (var_70: ManagedCuda.CudaStream)} : EnvHeap5)
let (var_72: EnvHeap4) = method_7((var_71: EnvHeap5), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule))
let (var_73: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(1024L))
let (var_74: int64) = 0L
method_9((var_73: (int64 [])), (var_74: int64))
let (var_75: int64) = 1024L
let (var_76: int64) = 0L
let (var_77: int64) = 1L
let (var_78: EnvStack6) = method_10((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_75: int64), (var_73: (int64 [])), (var_76: int64), (var_77: int64))
let (var_79: EnvHeap7) = ({mem_0 = (var_40: EnvStack0); mem_1 = (var_35: uint64); mem_2 = (var_41: ResizeArray<Env1>); mem_3 = (var_42: ResizeArray<Env2>)} : EnvHeap7)
let (var_80: EnvStack0) = var_79.mem_0
let (var_81: uint64) = var_79.mem_1
let (var_82: ResizeArray<Env1>) = var_79.mem_2
let (var_83: ResizeArray<Env2>) = var_79.mem_3
method_1((var_82: ResizeArray<Env1>), (var_80: EnvStack0), (var_81: uint64), (var_83: ResizeArray<Env2>))
let (var_87: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_89: EnvHeap3) = var_78.mem_0
let (var_90: (int64 ref)) = var_89.mem_0
let (var_91: EnvStack0) = var_89.mem_1
let (var_92: (uint64 ref)) = var_91.mem_0
let (var_93: uint64) = method_5((var_92: (uint64 ref)))
let (var_94: int64) = 16L
let (var_95: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_87: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_94: int64))
let (var_96: EnvStack6) = EnvStack6((var_95: EnvHeap3))
let (var_97: EnvHeap3) = var_96.mem_0
let (var_98: (int64 ref)) = var_97.mem_0
let (var_99: EnvStack0) = var_97.mem_1
let (var_100: (uint64 ref)) = var_99.mem_0
let (var_101: uint64) = method_5((var_100: (uint64 ref)))
// Cuda join point
// method_16((var_93: uint64), (var_101: uint64))
let (var_102: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_103: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_102.set_GridDimensions(var_103)
let (var_104: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_102.set_BlockDimensions(var_104)
let (var_105: (int64 ref)) = var_72.mem_0
let (var_106: EnvHeap5) = var_72.mem_1
let (var_107: (bool ref)) = var_106.mem_0
let (var_108: ManagedCuda.CudaStream) = var_106.mem_1
let (var_109: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_111: (System.Object [])) = [|var_93; var_101|]: (System.Object [])
var_102.RunAsync(var_109, var_111)
let (var_112: int64) = 2L
let (var_113: int64) = 0L
let (var_114: int64) = 1L
let (var_115: (int64 [])) = method_19((var_112: int64), (var_96: EnvStack6), (var_113: int64), (var_114: int64))
let (var_116: int64) = 0L
let (var_117: int64) = 1L
let (var_118: int64) = 0L
let (var_119: int64) = 2L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_87: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_96: EnvStack6), (var_116: int64), (var_117: int64), (var_118: int64), (var_119: int64))
let (var_120: uint64) = method_5((var_100: (uint64 ref)))
let (var_121: int64) = 8L
let (var_122: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_87: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_121: int64))
let (var_123: EnvStack6) = EnvStack6((var_122: EnvHeap3))
let (var_124: EnvHeap3) = var_123.mem_0
let (var_125: (int64 ref)) = var_124.mem_0
let (var_126: EnvStack0) = var_124.mem_1
let (var_127: (uint64 ref)) = var_126.mem_0
let (var_128: uint64) = method_5((var_127: (uint64 ref)))
// Cuda join point
// method_25((var_120: uint64), (var_128: uint64))
let (var_129: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_130: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_129.set_GridDimensions(var_130)
let (var_131: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_129.set_BlockDimensions(var_131)
let (var_132: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_134: (System.Object [])) = [|var_120; var_128|]: (System.Object [])
var_129.RunAsync(var_132, var_134)
let (var_135: int64) = 0L
let (var_136: int64) = 1L
let (var_137: int64) = 0L
let (var_138: int64) = 1L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_87: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_123: EnvStack6), (var_135: int64), (var_136: int64), (var_137: int64), (var_138: int64))
method_26((var_87: ResizeArray<EnvHeap3>))
method_1((var_82: ResizeArray<Env1>), (var_80: EnvStack0), (var_81: uint64), (var_83: ResizeArray<Env2>))
let (var_142: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_143: uint64) = method_5((var_92: (uint64 ref)))
let (var_144: int64) = 16L
let (var_145: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_142: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_144: int64))
let (var_146: EnvStack6) = EnvStack6((var_145: EnvHeap3))
let (var_147: EnvHeap3) = var_146.mem_0
let (var_148: (int64 ref)) = var_147.mem_0
let (var_149: EnvStack0) = var_147.mem_1
let (var_150: (uint64 ref)) = var_149.mem_0
let (var_151: uint64) = method_5((var_150: (uint64 ref)))
// Cuda join point
// method_16((var_143: uint64), (var_151: uint64))
let (var_152: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_153: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_152.set_GridDimensions(var_153)
let (var_154: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_152.set_BlockDimensions(var_154)
let (var_155: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_157: (System.Object [])) = [|var_143; var_151|]: (System.Object [])
var_152.RunAsync(var_155, var_157)
let (var_158: int64) = 2L
let (var_159: int64) = 0L
let (var_160: int64) = 1L
let (var_161: (int64 [])) = method_19((var_158: int64), (var_146: EnvStack6), (var_159: int64), (var_160: int64))
let (var_162: int64) = 0L
let (var_163: int64) = 1L
let (var_164: int64) = 0L
let (var_165: int64) = 2L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_142: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_146: EnvStack6), (var_162: int64), (var_163: int64), (var_164: int64), (var_165: int64))
let (var_166: uint64) = method_5((var_150: (uint64 ref)))
let (var_167: int64) = 8L
let (var_168: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_142: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_167: int64))
let (var_169: EnvStack6) = EnvStack6((var_168: EnvHeap3))
let (var_170: EnvHeap3) = var_169.mem_0
let (var_171: (int64 ref)) = var_170.mem_0
let (var_172: EnvStack0) = var_170.mem_1
let (var_173: (uint64 ref)) = var_172.mem_0
let (var_174: uint64) = method_5((var_173: (uint64 ref)))
// Cuda join point
// method_25((var_166: uint64), (var_174: uint64))
let (var_175: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_176: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_175.set_GridDimensions(var_176)
let (var_177: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_175.set_BlockDimensions(var_177)
let (var_178: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_180: (System.Object [])) = [|var_166; var_174|]: (System.Object [])
var_175.RunAsync(var_178, var_180)
let (var_181: int64) = 0L
let (var_182: int64) = 1L
let (var_183: int64) = 0L
let (var_184: int64) = 1L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_142: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_169: EnvStack6), (var_181: int64), (var_182: int64), (var_183: int64), (var_184: int64))
method_26((var_142: ResizeArray<EnvHeap3>))
method_1((var_82: ResizeArray<Env1>), (var_80: EnvStack0), (var_81: uint64), (var_83: ResizeArray<Env2>))
let (var_188: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_189: uint64) = method_5((var_92: (uint64 ref)))
let (var_190: int64) = 16L
let (var_191: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_188: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_190: int64))
let (var_192: EnvStack6) = EnvStack6((var_191: EnvHeap3))
let (var_193: EnvHeap3) = var_192.mem_0
let (var_194: (int64 ref)) = var_193.mem_0
let (var_195: EnvStack0) = var_193.mem_1
let (var_196: (uint64 ref)) = var_195.mem_0
let (var_197: uint64) = method_5((var_196: (uint64 ref)))
// Cuda join point
// method_16((var_189: uint64), (var_197: uint64))
let (var_198: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_199: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_198.set_GridDimensions(var_199)
let (var_200: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_198.set_BlockDimensions(var_200)
let (var_201: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_203: (System.Object [])) = [|var_189; var_197|]: (System.Object [])
var_198.RunAsync(var_201, var_203)
let (var_204: int64) = 2L
let (var_205: int64) = 0L
let (var_206: int64) = 1L
let (var_207: (int64 [])) = method_19((var_204: int64), (var_192: EnvStack6), (var_205: int64), (var_206: int64))
let (var_208: int64) = 0L
let (var_209: int64) = 1L
let (var_210: int64) = 0L
let (var_211: int64) = 2L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_188: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_192: EnvStack6), (var_208: int64), (var_209: int64), (var_210: int64), (var_211: int64))
let (var_212: uint64) = method_5((var_196: (uint64 ref)))
let (var_213: int64) = 8L
let (var_214: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_188: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_213: int64))
let (var_215: EnvStack6) = EnvStack6((var_214: EnvHeap3))
let (var_216: EnvHeap3) = var_215.mem_0
let (var_217: (int64 ref)) = var_216.mem_0
let (var_218: EnvStack0) = var_216.mem_1
let (var_219: (uint64 ref)) = var_218.mem_0
let (var_220: uint64) = method_5((var_219: (uint64 ref)))
// Cuda join point
// method_25((var_212: uint64), (var_220: uint64))
let (var_221: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_222: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_221.set_GridDimensions(var_222)
let (var_223: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_221.set_BlockDimensions(var_223)
let (var_224: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_226: (System.Object [])) = [|var_212; var_220|]: (System.Object [])
var_221.RunAsync(var_224, var_226)
let (var_227: int64) = 0L
let (var_228: int64) = 1L
let (var_229: int64) = 0L
let (var_230: int64) = 1L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_188: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_215: EnvStack6), (var_227: int64), (var_228: int64), (var_229: int64), (var_230: int64))
method_26((var_188: ResizeArray<EnvHeap3>))
method_1((var_82: ResizeArray<Env1>), (var_80: EnvStack0), (var_81: uint64), (var_83: ResizeArray<Env2>))
let (var_234: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_235: uint64) = method_5((var_92: (uint64 ref)))
let (var_236: int64) = 16L
let (var_237: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_234: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_236: int64))
let (var_238: EnvStack6) = EnvStack6((var_237: EnvHeap3))
let (var_239: EnvHeap3) = var_238.mem_0
let (var_240: (int64 ref)) = var_239.mem_0
let (var_241: EnvStack0) = var_239.mem_1
let (var_242: (uint64 ref)) = var_241.mem_0
let (var_243: uint64) = method_5((var_242: (uint64 ref)))
// Cuda join point
// method_16((var_235: uint64), (var_243: uint64))
let (var_244: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_245: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_244.set_GridDimensions(var_245)
let (var_246: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_244.set_BlockDimensions(var_246)
let (var_247: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_249: (System.Object [])) = [|var_235; var_243|]: (System.Object [])
var_244.RunAsync(var_247, var_249)
let (var_250: int64) = 2L
let (var_251: int64) = 0L
let (var_252: int64) = 1L
let (var_253: (int64 [])) = method_19((var_250: int64), (var_238: EnvStack6), (var_251: int64), (var_252: int64))
let (var_254: int64) = 0L
let (var_255: int64) = 1L
let (var_256: int64) = 0L
let (var_257: int64) = 2L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_234: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_238: EnvStack6), (var_254: int64), (var_255: int64), (var_256: int64), (var_257: int64))
let (var_258: uint64) = method_5((var_242: (uint64 ref)))
let (var_259: int64) = 8L
let (var_260: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_234: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_259: int64))
let (var_261: EnvStack6) = EnvStack6((var_260: EnvHeap3))
let (var_262: EnvHeap3) = var_261.mem_0
let (var_263: (int64 ref)) = var_262.mem_0
let (var_264: EnvStack0) = var_262.mem_1
let (var_265: (uint64 ref)) = var_264.mem_0
let (var_266: uint64) = method_5((var_265: (uint64 ref)))
// Cuda join point
// method_25((var_258: uint64), (var_266: uint64))
let (var_267: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_268: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_267.set_GridDimensions(var_268)
let (var_269: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_267.set_BlockDimensions(var_269)
let (var_270: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_272: (System.Object [])) = [|var_258; var_266|]: (System.Object [])
var_267.RunAsync(var_270, var_272)
let (var_273: int64) = 0L
let (var_274: int64) = 1L
let (var_275: int64) = 0L
let (var_276: int64) = 1L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_234: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_261: EnvStack6), (var_273: int64), (var_274: int64), (var_275: int64), (var_276: int64))
method_26((var_234: ResizeArray<EnvHeap3>))
method_1((var_82: ResizeArray<Env1>), (var_80: EnvStack0), (var_81: uint64), (var_83: ResizeArray<Env2>))
let (var_280: ResizeArray<EnvHeap3>) = ResizeArray<EnvHeap3>()
let (var_281: uint64) = method_5((var_92: (uint64 ref)))
let (var_282: int64) = 16L
let (var_283: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_280: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_282: int64))
let (var_284: EnvStack6) = EnvStack6((var_283: EnvHeap3))
let (var_285: EnvHeap3) = var_284.mem_0
let (var_286: (int64 ref)) = var_285.mem_0
let (var_287: EnvStack0) = var_285.mem_1
let (var_288: (uint64 ref)) = var_287.mem_0
let (var_289: uint64) = method_5((var_288: (uint64 ref)))
// Cuda join point
// method_16((var_281: uint64), (var_289: uint64))
let (var_290: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_291: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_290.set_GridDimensions(var_291)
let (var_292: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_290.set_BlockDimensions(var_292)
let (var_293: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_295: (System.Object [])) = [|var_281; var_289|]: (System.Object [])
var_290.RunAsync(var_293, var_295)
let (var_296: int64) = 2L
let (var_297: int64) = 0L
let (var_298: int64) = 1L
let (var_299: (int64 [])) = method_19((var_296: int64), (var_284: EnvStack6), (var_297: int64), (var_298: int64))
let (var_300: int64) = 0L
let (var_301: int64) = 1L
let (var_302: int64) = 0L
let (var_303: int64) = 2L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_280: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_284: EnvStack6), (var_300: int64), (var_301: int64), (var_302: int64), (var_303: int64))
let (var_304: uint64) = method_5((var_288: (uint64 ref)))
let (var_305: int64) = 8L
let (var_306: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_280: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_305: int64))
let (var_307: EnvStack6) = EnvStack6((var_306: EnvHeap3))
let (var_308: EnvHeap3) = var_307.mem_0
let (var_309: (int64 ref)) = var_308.mem_0
let (var_310: EnvStack0) = var_308.mem_1
let (var_311: (uint64 ref)) = var_310.mem_0
let (var_312: uint64) = method_5((var_311: (uint64 ref)))
// Cuda join point
// method_25((var_304: uint64), (var_312: uint64))
let (var_313: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_314: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_313.set_GridDimensions(var_314)
let (var_315: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_313.set_BlockDimensions(var_315)
let (var_316: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_318: (System.Object [])) = [|var_304; var_312|]: (System.Object [])
var_313.RunAsync(var_316, var_318)
let (var_319: int64) = 0L
let (var_320: int64) = 1L
let (var_321: int64) = 0L
let (var_322: int64) = 1L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_280: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_307: EnvStack6), (var_319: int64), (var_320: int64), (var_321: int64), (var_322: int64))
method_26((var_280: ResizeArray<EnvHeap3>))
let (var_323: uint64) = method_5((var_92: (uint64 ref)))
let (var_324: int64) = 16L
let (var_325: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_324: int64))
let (var_326: EnvStack6) = EnvStack6((var_325: EnvHeap3))
let (var_327: EnvHeap3) = var_326.mem_0
let (var_328: (int64 ref)) = var_327.mem_0
let (var_329: EnvStack0) = var_327.mem_1
let (var_330: (uint64 ref)) = var_329.mem_0
let (var_331: uint64) = method_5((var_330: (uint64 ref)))
// Cuda join point
// method_16((var_323: uint64), (var_331: uint64))
let (var_332: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_16", var_32, var_1)
let (var_333: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_332.set_GridDimensions(var_333)
let (var_334: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(256u, 1u, 1u)
var_332.set_BlockDimensions(var_334)
let (var_335: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_337: (System.Object [])) = [|var_323; var_331|]: (System.Object [])
var_332.RunAsync(var_335, var_337)
let (var_338: int64) = 2L
let (var_339: int64) = 0L
let (var_340: int64) = 1L
let (var_341: (int64 [])) = method_19((var_338: int64), (var_326: EnvStack6), (var_339: int64), (var_340: int64))
let (var_342: int64) = 0L
let (var_343: int64) = 1L
let (var_344: int64) = 0L
let (var_345: int64) = 2L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_326: EnvStack6), (var_342: int64), (var_343: int64), (var_344: int64), (var_345: int64))
let (var_346: uint64) = method_5((var_330: (uint64 ref)))
let (var_347: int64) = 8L
let (var_348: EnvHeap3) = method_11((var_79: EnvHeap7), (var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_347: int64))
let (var_349: EnvStack6) = EnvStack6((var_348: EnvHeap3))
let (var_350: EnvHeap3) = var_349.mem_0
let (var_351: (int64 ref)) = var_350.mem_0
let (var_352: EnvStack0) = var_350.mem_1
let (var_353: (uint64 ref)) = var_352.mem_0
let (var_354: uint64) = method_5((var_353: (uint64 ref)))
// Cuda join point
// method_25((var_346: uint64), (var_354: uint64))
let (var_355: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_356: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_355.set_GridDimensions(var_356)
let (var_357: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(2u, 1u, 1u)
var_355.set_BlockDimensions(var_357)
let (var_358: ManagedCuda.BasicTypes.CUstream) = method_18((var_107: (bool ref)), (var_108: ManagedCuda.CudaStream))
let (var_360: (System.Object [])) = [|var_346; var_354|]: (System.Object [])
var_355.RunAsync(var_358, var_360)
let (var_361: int64) = 0L
let (var_362: int64) = 1L
let (var_363: int64) = 0L
let (var_364: int64) = 1L
method_20((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_349: EnvStack6), (var_361: int64), (var_362: int64), (var_363: int64), (var_364: int64))
let (var_365: int64) = 0L
method_28((var_47: ManagedCuda.CudaBlas.CudaBlas), (var_44: ManagedCuda.CudaRand.CudaRandDevice), (var_40: EnvStack0), (var_35: uint64), (var_41: ResizeArray<Env1>), (var_42: ResizeArray<Env2>), (var_1: ManagedCuda.CudaContext), (var_56: ResizeArray<EnvHeap3>), (var_68: ResizeArray<EnvHeap4>), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_72: EnvHeap4), (var_349: EnvStack6), (var_365: int64))
method_31((var_68: ResizeArray<EnvHeap4>))
method_26((var_56: ResizeArray<EnvHeap3>))
var_47.Dispose()
var_44.Dispose()
let (var_366: (uint64 ref)) = var_40.mem_0
let (var_367: uint64) = method_5((var_366: (uint64 ref)))
let (var_368: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_367)
let (var_369: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_368)
var_1.FreeMemory(var_369)
var_366 := 0UL
var_1.Dispose()

