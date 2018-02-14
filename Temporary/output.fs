module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    
}
"""

type EnvStack0 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env1 =
    struct
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack2 =
    struct
    val mem_0: (int64 ref)
    val mem_1: EnvStack0
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack3 =
    struct
    val mem_0: (int64 ref)
    val mem_1: EnvStack5
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack4 =
    struct
    val mem_0: EnvStack2
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and EnvStack5 =
    struct
    val mem_0: (bool ref)
    val mem_1: ManagedCuda.CudaStream
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>)): unit =
    let (var_5: (Env1 -> bool)) = method_2
    let (var_6: int32) = var_3.RemoveAll <| System.Predicate(var_5)
    let (var_8: (Env1 -> (Env1 -> int32))) = method_3
    let (var_9: System.Comparison<Env1>) = System.Comparison<Env1>(var_8)
    var_3.Sort(var_9)
    var_0.Clear()
    let (var_10: int32) = var_3.get_Count()
    let (var_11: int32) = 0
    let (var_12: Env1) = method_6((var_0: ResizeArray<Env1>), (var_10: int32), (var_1: EnvStack0), (var_11: int32))
    let (var_13: EnvStack0) = var_12.mem_0
    let (var_14: uint64) = var_12.mem_1
    let (var_15: (uint64 ref)) = var_1.mem_0
    let (var_16: uint64) = method_5((var_15: (uint64 ref)))
    let (var_17: uint64) = (var_16 + var_2)
    let (var_18: uint64) = method_5((var_15: (uint64 ref)))
    let (var_19: uint64) = (var_18 - var_17)
    let (var_20: (uint64 ref)) = var_13.mem_0
    let (var_21: uint64) = method_5((var_20: (uint64 ref)))
    let (var_22: (uint64 ref)) = (ref var_21)
    let (var_23: EnvStack0) = EnvStack0((var_22: (uint64 ref)))
    var_0.Add((Env1(var_23, var_19)))
and method_8((var_0: ResizeArray<EnvStack3>)): EnvStack3 =
    let (var_1: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
    let (var_2: (bool ref)) = (ref true)
    let (var_3: EnvStack5) = EnvStack5((var_2: (bool ref)), (var_1: ManagedCuda.CudaStream))
    let (var_4: (int64 ref)) = (ref 0L)
    let (var_5: EnvStack3) = EnvStack3((var_4: (int64 ref)), (var_3: EnvStack5))
    method_9((var_5: EnvStack3), (var_0: ResizeArray<EnvStack3>))
    var_5
and method_10((var_0: ResizeArray<EnvStack2>), (var_1: ResizeArray<Env1>), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_5: int64)): EnvStack2 =
    let (var_6: uint64) = (uint64 var_5)
    let (var_7: EnvStack0) = method_11((var_1: ResizeArray<Env1>), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_6: uint64))
    let (var_8: (int64 ref)) = (ref 0L)
    let (var_9: EnvStack2) = EnvStack2((var_8: (int64 ref)), (var_7: EnvStack0))
    method_12((var_9: EnvStack2), (var_0: ResizeArray<EnvStack2>))
    var_9
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_13((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack4), (var_2: EnvStack4), (var_3: EnvStack4), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: EnvStack3)): unit =
    let (var_6: (int64 ref)) = var_5.mem_0
    let (var_7: EnvStack5) = var_5.mem_1
    let (var_8: (bool ref)) = var_7.mem_0
    let (var_9: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_10: bool) = (!var_8)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = var_9.Stream
    var_4.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: EnvStack2) = var_1.mem_0
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: EnvStack0) = var_16.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: EnvStack2) = var_2.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: (float32 ref)) = (ref 0.000000f)
    let (var_31: EnvStack2) = var_3.mem_0
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: EnvStack0) = var_31.mem_1
    let (var_34: (uint64 ref)) = var_33.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
    let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_36)
    let (var_38: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_13, var_14, 4, 2, 3, var_15, var_22, 4, var_29, 3, var_30, var_37, 4)
    if var_38 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_38)
and method_14((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack4), (var_2: EnvStack4), (var_3: EnvStack4), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: EnvStack3)): unit =
    let (var_6: (int64 ref)) = var_5.mem_0
    let (var_7: EnvStack5) = var_5.mem_1
    let (var_8: (bool ref)) = var_7.mem_0
    let (var_9: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_10: bool) = (!var_8)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = var_9.Stream
    var_4.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: EnvStack2) = var_1.mem_0
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: EnvStack0) = var_16.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: EnvStack2) = var_2.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: (float32 ref)) = (ref 0.000000f)
    let (var_31: EnvStack2) = var_3.mem_0
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: EnvStack0) = var_31.mem_1
    let (var_34: (uint64 ref)) = var_33.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
    let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_36)
    let (var_38: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_13, var_14, 3, 2, 4, var_15, var_22, 4, var_29, 4, var_30, var_37, 3)
    if var_38 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_38)
and method_15((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack4), (var_2: EnvStack4), (var_3: EnvStack4), (var_4: ManagedCuda.CudaBlas.CudaBlas), (var_5: EnvStack3)): unit =
    let (var_6: (int64 ref)) = var_5.mem_0
    let (var_7: EnvStack5) = var_5.mem_1
    let (var_8: (bool ref)) = var_7.mem_0
    let (var_9: ManagedCuda.CudaStream) = var_7.mem_1
    let (var_10: bool) = (!var_8)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "The stream has been disposed.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.CUstream) = var_9.Stream
    var_4.set_Stream(var_12)
    let (var_13: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_14: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_15: (float32 ref)) = (ref 1.000000f)
    let (var_16: EnvStack2) = var_1.mem_0
    let (var_17: (int64 ref)) = var_16.mem_0
    let (var_18: EnvStack0) = var_16.mem_1
    let (var_19: (uint64 ref)) = var_18.mem_0
    let (var_20: uint64) = method_5((var_19: (uint64 ref)))
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_20)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: EnvStack2) = var_2.mem_0
    let (var_24: (int64 ref)) = var_23.mem_0
    let (var_25: EnvStack0) = var_23.mem_1
    let (var_26: (uint64 ref)) = var_25.mem_0
    let (var_27: uint64) = method_5((var_26: (uint64 ref)))
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_27)
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_28)
    let (var_30: (float32 ref)) = (ref 0.000000f)
    let (var_31: EnvStack2) = var_3.mem_0
    let (var_32: (int64 ref)) = var_31.mem_0
    let (var_33: EnvStack0) = var_31.mem_1
    let (var_34: (uint64 ref)) = var_33.mem_0
    let (var_35: uint64) = method_5((var_34: (uint64 ref)))
    let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
    let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_36)
    let (var_38: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_13, var_14, 4, 3, 2, var_15, var_22, 4, var_29, 3, var_30, var_37, 4)
    if var_38 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_38)
and method_16((var_0: EnvStack4), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: int64) = (var_5 - var_4)
    let (var_9: int64) = (var_7 - var_6)
    let (var_10: int64) = (var_8 * var_9)
    let (var_11: bool) = (var_10 > 0L)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_13: int64) = (var_9 * var_3)
    let (var_14: bool) = (var_2 = var_13)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_16: int64) = (var_8 * var_2)
    let (var_17: (float32 [])) = method_17((var_8: int64), (var_0: EnvStack4), (var_1: int64), (var_2: int64), (var_3: int64))
    method_18((var_17: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64))
and method_25((var_0: ResizeArray<EnvStack3>)): unit =
    let (var_2: (EnvStack3 -> unit)) = method_26
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_27((var_0: ResizeArray<EnvStack2>)): unit =
    let (var_2: (EnvStack2 -> unit)) = method_28
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_2 ((var_0: Env1)): bool =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    let (var_3: (uint64 ref)) = var_1.mem_0
    let (var_4: uint64) = (!var_3)
    (var_4 = 0UL)
and method_3 ((var_0: Env1)): (Env1 -> int32) =
    let (var_1: EnvStack0) = var_0.mem_0
    let (var_2: uint64) = var_0.mem_1
    method_4((var_1: EnvStack0))
and method_6((var_0: ResizeArray<Env1>), (var_1: int32), (var_2: EnvStack0), (var_3: int32)): Env1 =
    let (var_4: bool) = (var_3 < var_1)
    if var_4 then
        let (var_5: Env1) = var_0.[var_3]
        let (var_6: EnvStack0) = var_5.mem_0
        let (var_7: uint64) = var_5.mem_1
        let (var_8: (uint64 ref)) = var_2.mem_0
        let (var_9: uint64) = method_5((var_8: (uint64 ref)))
        let (var_10: uint64) = method_5((var_8: (uint64 ref)))
        let (var_11: uint64) = (var_10 - var_9)
        let (var_12: bool) = (var_11 > 0UL)
        if var_12 then
            let (var_13: uint64) = method_5((var_8: (uint64 ref)))
            let (var_14: (uint64 ref)) = (ref var_13)
            let (var_15: EnvStack0) = EnvStack0((var_14: (uint64 ref)))
            var_0.Add((Env1(var_15, var_11)))
        else
            ()
        let (var_16: int32) = (var_3 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_6: EnvStack0), (var_7: uint64), (var_16: int32))
    else
        (Env1(var_2, 0UL))
and method_9((var_0: EnvStack3), (var_1: ResizeArray<EnvStack3>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack5) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_11((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>), (var_4: uint64)): EnvStack0 =
    let (var_5: Env1) = var_0.[0]
    let (var_6: EnvStack0) = var_5.mem_0
    let (var_7: uint64) = var_5.mem_1
    let (var_8: bool) = (var_4 <= var_7)
    let (var_44: Env1) =
        if var_8 then
            let (var_9: (uint64 ref)) = var_6.mem_0
            let (var_10: uint64) = (!var_9)
            let (var_11: uint64) = (var_10 + var_4)
            let (var_12: (uint64 ref)) = (ref var_11)
            let (var_13: EnvStack0) = EnvStack0((var_12: (uint64 ref)))
            let (var_14: uint64) = (var_7 - var_4)
            var_0.[0] <- (Env1(var_13, var_14))
            (Env1(var_6, var_4))
        else
            let (var_16: (Env1 -> (Env1 -> int32))) = method_3
            let (var_17: System.Comparison<Env1>) = System.Comparison<Env1>(var_16)
            var_0.Sort(var_17)
            let (var_18: Env1) = var_0.[0]
            let (var_19: EnvStack0) = var_18.mem_0
            let (var_20: uint64) = var_18.mem_1
            let (var_21: bool) = (var_4 <= var_20)
            if var_21 then
                let (var_22: (uint64 ref)) = var_19.mem_0
                let (var_23: uint64) = (!var_22)
                let (var_24: uint64) = (var_23 + var_4)
                let (var_25: (uint64 ref)) = (ref var_24)
                let (var_26: EnvStack0) = EnvStack0((var_25: (uint64 ref)))
                let (var_27: uint64) = (var_20 - var_4)
                var_0.[0] <- (Env1(var_26, var_27))
                (Env1(var_19, var_4))
            else
                method_1((var_0: ResizeArray<Env1>), (var_1: EnvStack0), (var_2: uint64), (var_3: ResizeArray<Env1>))
                let (var_29: (Env1 -> (Env1 -> int32))) = method_3
                let (var_30: System.Comparison<Env1>) = System.Comparison<Env1>(var_29)
                var_0.Sort(var_30)
                let (var_31: Env1) = var_0.[0]
                let (var_32: EnvStack0) = var_31.mem_0
                let (var_33: uint64) = var_31.mem_1
                let (var_34: bool) = (var_4 <= var_33)
                if var_34 then
                    let (var_35: (uint64 ref)) = var_32.mem_0
                    let (var_36: uint64) = (!var_35)
                    let (var_37: uint64) = (var_36 + var_4)
                    let (var_38: (uint64 ref)) = (ref var_37)
                    let (var_39: EnvStack0) = EnvStack0((var_38: (uint64 ref)))
                    let (var_40: uint64) = (var_33 - var_4)
                    var_0.[0] <- (Env1(var_39, var_40))
                    (Env1(var_32, var_4))
                else
                    (failwith "Out of memory in the designated section.")
    let (var_45: EnvStack0) = var_44.mem_0
    let (var_46: uint64) = var_44.mem_1
    var_45
and method_12((var_0: EnvStack2), (var_1: ResizeArray<EnvStack2>)): unit =
    let (var_2: (int64 ref)) = var_0.mem_0
    let (var_3: EnvStack0) = var_0.mem_1
    let (var_4: int64) = (!var_2)
    let (var_5: int64) = (var_4 + 1L)
    var_2 := var_5
    var_1.Add(var_0)
and method_17((var_0: int64), (var_1: EnvStack4), (var_2: int64), (var_3: int64), (var_4: int64)): (float32 []) =
    let (var_5: EnvStack2) = var_1.mem_0
    let (var_6: int64) = (var_0 * var_3)
    let (var_7: (int64 ref)) = var_5.mem_0
    let (var_8: EnvStack0) = var_5.mem_1
    let (var_9: (uint64 ref)) = var_8.mem_0
    let (var_10: uint64) = method_5((var_9: (uint64 ref)))
    let (var_11: int64) = (var_2 * 4L)
    let (var_12: uint64) = (uint64 var_11)
    let (var_13: uint64) = (var_10 + var_12)
    let (var_14: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_6))
    let (var_15: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_14,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_16: int64) = var_15.AddrOfPinnedObject().ToInt64()
    let (var_17: uint64) = (uint64 var_16)
    let (var_18: int64) = (var_6 * 4L)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_21)
    let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_24: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_20, var_22, var_23)
    if var_24 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_24)
    var_15.Free()
    var_14
and method_18((var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64)): unit =
    let (var_8: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_9: string) = ""
    let (var_10: int64) = 0L
    let (var_11: int64) = 0L
    method_19((var_8: System.Text.StringBuilder), (var_11: int64))
    let (var_12: System.Text.StringBuilder) = var_8.AppendLine("[|")
    let (var_13: int64) = method_20((var_8: System.Text.StringBuilder), (var_9: string), (var_0: (float32 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_10: int64))
    let (var_14: int64) = 0L
    method_19((var_8: System.Text.StringBuilder), (var_14: int64))
    let (var_15: System.Text.StringBuilder) = var_8.AppendLine("|]")
    let (var_16: string) = var_8.ToString()
    let (var_17: string) = System.String.Format("{0}",var_16)
    System.Console.WriteLine(var_17)
and method_26 ((var_0: EnvStack3)): unit =
    let (var_1: (int64 ref)) = var_0.mem_0
    let (var_2: EnvStack5) = var_0.mem_1
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
and method_28 ((var_0: EnvStack2)): unit =
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
and method_4 ((var_1: EnvStack0)) ((var_0: Env1)): int32 =
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
and method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_2: EnvStack0), (var_3: uint64), (var_4: int32)): Env1 =
    let (var_5: bool) = (var_4 < var_1)
    if var_5 then
        let (var_6: Env1) = var_0.[var_4]
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_2.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: uint64) = (var_10 + var_3)
        let (var_12: uint64) = method_5((var_9: (uint64 ref)))
        let (var_13: uint64) = (var_12 - var_11)
        let (var_14: bool) = (var_13 > 0UL)
        if var_14 then
            let (var_15: uint64) = method_5((var_9: (uint64 ref)))
            let (var_16: (uint64 ref)) = (ref var_15)
            let (var_17: EnvStack0) = EnvStack0((var_16: (uint64 ref)))
            var_0.Add((Env1(var_17, var_13)))
        else
            ()
        let (var_18: int32) = (var_4 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_7: EnvStack0), (var_8: uint64), (var_18: int32))
    else
        (Env1(var_2, var_3))
and method_19((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_19((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_20((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): int64 =
    let (var_11: bool) = (var_6 < var_7)
    if var_11 then
        let (var_12: bool) = (var_10 < 1000L)
        if var_12 then
            let (var_13: bool) = (var_6 >= var_6)
            let (var_14: bool) = (var_13 = false)
            if var_14 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_15: int64) = 0L
            method_21((var_0: System.Text.StringBuilder), (var_15: int64))
            let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_17: int64) = method_22((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_3: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_19: int64) = (var_6 + 1L)
            method_24((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_17: int64), (var_19: int64))
        else
            let (var_21: int64) = 0L
            method_19((var_0: System.Text.StringBuilder), (var_21: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_21((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_21((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_22((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): int64 =
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
            let (var_13: float32) = var_1.[int32 var_2]
            let (var_14: string) = System.String.Format("{0}",var_13)
            let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
            let (var_16: string) = "; "
            let (var_17: int64) = (var_7 + 1L)
            let (var_18: int64) = (var_4 + 1L)
            method_23((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_16: string), (var_17: int64), (var_18: int64))
        else
            let (var_20: System.Text.StringBuilder) = var_0.Append("...")
            var_7
    else
        var_7
and method_24((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): int64 =
    let (var_12: bool) = (var_11 < var_7)
    if var_12 then
        let (var_13: bool) = (var_10 < 1000L)
        if var_13 then
            let (var_14: bool) = (var_11 >= var_6)
            let (var_15: bool) = (var_14 = false)
            if var_15 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_16: int64) = (var_11 - var_6)
            let (var_17: int64) = (var_16 * var_4)
            let (var_18: int64) = (var_3 + var_17)
            let (var_19: int64) = 0L
            method_21((var_0: System.Text.StringBuilder), (var_19: int64))
            let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_21: int64) = method_22((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_18: int64), (var_5: int64), (var_8: int64), (var_9: int64), (var_1: string), (var_10: int64))
            let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_23: int64) = (var_11 + 1L)
            method_24((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_21: int64), (var_23: int64))
        else
            let (var_25: int64) = 0L
            method_19((var_0: System.Text.StringBuilder), (var_25: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_10
    else
        var_10
and method_23((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64), (var_8: int64)): int64 =
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
            let (var_17: float32) = var_1.[int32 var_16]
            let (var_18: string) = System.String.Format("{0}",var_17)
            let (var_19: System.Text.StringBuilder) = var_0.Append(var_18)
            let (var_20: string) = "; "
            let (var_21: int64) = (var_7 + 1L)
            let (var_22: int64) = (var_8 + 1L)
            method_23((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_20: string), (var_21: int64), (var_22: int64))
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
let (var_35: uint64) = 1280UL
let (var_36: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_35)
let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_36)
let (var_38: uint64) = uint64 var_37
let (var_39: (uint64 ref)) = (ref var_38)
let (var_40: EnvStack0) = EnvStack0((var_39: (uint64 ref)))
let (var_41: ResizeArray<Env1>) = ResizeArray<Env1>()
let (var_42: ResizeArray<Env1>) = ResizeArray<Env1>()
method_1((var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>))
let (var_46: ResizeArray<EnvStack2>) = ResizeArray<EnvStack2>()
let (var_53: ResizeArray<EnvStack3>) = ResizeArray<EnvStack3>()
let (var_54: EnvStack3) = method_8((var_53: ResizeArray<EnvStack3>))
let (var_55: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_56: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_55)
let (var_57: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_58: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_59: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_57, var_58)
let (var_60: ManagedCuda.CudaBlas.CudaBlasHandle) = var_59.get_CublasHandle()
let (var_61: int64) = 24L
let (var_62: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_61: int64))
let (var_63: EnvStack4) = EnvStack4((var_62: EnvStack2))
let (var_64: EnvStack2) = var_63.mem_0
let (var_65: (int64 ref)) = var_64.mem_0
let (var_66: EnvStack0) = var_64.mem_1
let (var_67: (uint64 ref)) = var_66.mem_0
let (var_68: uint64) = method_5((var_67: (uint64 ref)))
let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(6L)
let (var_70: (int64 ref)) = var_54.mem_0
let (var_71: EnvStack5) = var_54.mem_1
let (var_72: (bool ref)) = var_71.mem_0
let (var_73: ManagedCuda.CudaStream) = var_71.mem_1
let (var_74: bool) = (!var_72)
let (var_75: bool) = (var_74 = false)
if var_75 then
    (failwith "The stream has been disposed.")
else
    ()
let (var_76: ManagedCuda.BasicTypes.CUstream) = var_73.Stream
var_56.SetStream(var_76)
let (var_77: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_68)
let (var_78: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_77)
var_56.GenerateNormal32(var_78, var_69, 0.000000f, 1.000000f)
let (var_79: int64) = 48L
let (var_80: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_79: int64))
let (var_81: EnvStack4) = EnvStack4((var_80: EnvStack2))
let (var_82: EnvStack2) = var_81.mem_0
let (var_83: (int64 ref)) = var_82.mem_0
let (var_84: EnvStack0) = var_82.mem_1
let (var_85: (uint64 ref)) = var_84.mem_0
let (var_86: uint64) = method_5((var_85: (uint64 ref)))
let (var_87: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(12L)
let (var_88: bool) = (!var_72)
let (var_89: bool) = (var_88 = false)
if var_89 then
    (failwith "The stream has been disposed.")
else
    ()
let (var_90: ManagedCuda.BasicTypes.CUstream) = var_73.Stream
var_56.SetStream(var_90)
let (var_91: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_86)
let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_91)
var_56.GenerateNormal32(var_92, var_87, 0.000000f, 1.000000f)
let (var_93: int64) = 32L
let (var_94: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_93: int64))
let (var_95: EnvStack4) = EnvStack4((var_94: EnvStack2))
method_13((var_60: ManagedCuda.CudaBlas.CudaBlasHandle), (var_81: EnvStack4), (var_63: EnvStack4), (var_95: EnvStack4), (var_59: ManagedCuda.CudaBlas.CudaBlas), (var_54: EnvStack3))
let (var_96: EnvStack2) = var_95.mem_0
let (var_97: int64) = 24L
let (var_98: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_97: int64))
let (var_99: EnvStack4) = EnvStack4((var_98: EnvStack2))
method_14((var_60: ManagedCuda.CudaBlas.CudaBlasHandle), (var_81: EnvStack4), (var_95: EnvStack4), (var_99: EnvStack4), (var_59: ManagedCuda.CudaBlas.CudaBlas), (var_54: EnvStack3))
let (var_100: int64) = 48L
let (var_101: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_100: int64))
let (var_102: EnvStack4) = EnvStack4((var_101: EnvStack2))
method_15((var_60: ManagedCuda.CudaBlas.CudaBlasHandle), (var_95: EnvStack4), (var_63: EnvStack4), (var_102: EnvStack4), (var_59: ManagedCuda.CudaBlas.CudaBlas), (var_54: EnvStack3))
let (var_103: int64) = 0L
let (var_104: int64) = 3L
let (var_105: int64) = 1L
let (var_106: int64) = 0L
let (var_107: int64) = 2L
let (var_108: int64) = 0L
let (var_109: int64) = 3L
method_16((var_63: EnvStack4), (var_103: int64), (var_104: int64), (var_105: int64), (var_106: int64), (var_107: int64), (var_108: int64), (var_109: int64))
let (var_110: int64) = 0L
let (var_111: int64) = 4L
let (var_112: int64) = 1L
let (var_113: int64) = 0L
let (var_114: int64) = 3L
let (var_115: int64) = 0L
let (var_116: int64) = 4L
method_16((var_81: EnvStack4), (var_110: int64), (var_111: int64), (var_112: int64), (var_113: int64), (var_114: int64), (var_115: int64), (var_116: int64))
let (var_117: int64) = 0L
let (var_118: int64) = 4L
let (var_119: int64) = 1L
let (var_120: int64) = 0L
let (var_121: int64) = 2L
let (var_122: int64) = 0L
let (var_123: int64) = 4L
method_16((var_95: EnvStack4), (var_117: int64), (var_118: int64), (var_119: int64), (var_120: int64), (var_121: int64), (var_122: int64), (var_123: int64))
let (var_124: int64) = 0L
let (var_125: int64) = 3L
let (var_126: int64) = 1L
let (var_127: int64) = 0L
let (var_128: int64) = 2L
let (var_129: int64) = 0L
let (var_130: int64) = 3L
method_16((var_99: EnvStack4), (var_124: int64), (var_125: int64), (var_126: int64), (var_127: int64), (var_128: int64), (var_129: int64), (var_130: int64))
let (var_131: int64) = 0L
let (var_132: int64) = 4L
let (var_133: int64) = 1L
let (var_134: int64) = 0L
let (var_135: int64) = 3L
let (var_136: int64) = 0L
let (var_137: int64) = 4L
method_16((var_102: EnvStack4), (var_131: int64), (var_132: int64), (var_133: int64), (var_134: int64), (var_135: int64), (var_136: int64), (var_137: int64))
var_59.Dispose()
var_56.Dispose()
method_25((var_53: ResizeArray<EnvStack3>))
method_27((var_46: ResizeArray<EnvStack2>))
let (var_138: (uint64 ref)) = var_40.mem_0
let (var_139: uint64) = method_5((var_138: (uint64 ref)))
let (var_140: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_139)
let (var_141: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_140)
var_1.FreeMemory(var_141)
var_138 := 0UL
var_1.Dispose()

