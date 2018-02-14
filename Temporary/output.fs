module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_13(long long int * var_0, long long int * var_1, long long int * var_2);
    __device__ char method_14(long long int * var_0);
    
    __global__ void method_13(long long int * var_0, long long int * var_1, long long int * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = blockIdx.x;
        long long int var_5 = (128 * var_4);
        long long int var_6 = (var_3 + var_5);
        long long int var_7[1];
        var_7[0] = var_6;
        while (method_14(var_7)) {
            long long int var_9 = var_7[0];
            long long int var_10 = (var_9 % 32);
            long long int var_11 = (var_9 / 32);
            long long int var_12 = (var_11 % 2);
            long long int var_13 = (var_11 / 2);
            long long int var_14 = (var_13 % 2);
            long long int var_15 = (var_13 / 2);
            char var_16 = (var_14 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_14 < 2);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_20 = (var_14 * 256);
            char var_21 = (var_12 >= 0);
            char var_23;
            if (var_21) {
                var_23 = (var_12 < 2);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_25 = (var_12 * 128);
            long long int var_26 = (var_20 + var_25);
            long long int var_27[1];
            var_27[0] = var_10;
            while (method_14(var_27)) {
                long long int var_29 = var_27[0];
                char var_30 = (var_29 >= 0);
                char var_32;
                if (var_30) {
                    var_32 = (var_29 < 128);
                } else {
                    var_32 = 0;
                }
                char var_33 = (var_32 == 0);
                if (var_33) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_34 = (var_26 + var_29);
                var_0[var_34] = var_14;
                var_1[var_34] = var_12;
                var_2[var_34] = var_29;
                long long int var_35 = (var_29 + 32);
                var_27[0] = var_35;
            }
            long long int var_36 = var_27[0];
            long long int var_37 = (var_9 + 128);
            var_7[0] = var_37;
        }
        long long int var_38 = var_7[0];
    }
    __device__ char method_14(long long int * var_0) {
        long long int var_1 = var_0[0];
        return (var_1 < 128);
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
    let (var_18: (uint64 ref)) = var_13.mem_0
    let (var_19: uint64) = method_5((var_18: (uint64 ref)))
    let (var_20: uint64) = (var_17 - var_19)
    let (var_21: uint64) = method_5((var_18: (uint64 ref)))
    let (var_22: uint64) = (var_21 + 256UL)
    let (var_23: uint64) = (var_22 - 1UL)
    let (var_24: uint64) = (var_23 / 256UL)
    let (var_25: uint64) = (var_24 * 256UL)
    let (var_26: uint64) = (var_25 - var_21)
    let (var_27: bool) = (var_20 >= var_26)
    if var_27 then
        let (var_28: (uint64 ref)) = (ref var_25)
        let (var_29: EnvStack0) = EnvStack0((var_28: (uint64 ref)))
        let (var_30: uint64) = (var_20 - var_26)
        var_0.Add((Env1(var_29, var_30)))
    else
        ()
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
    let (var_7: uint64) = (var_6 + 256UL)
    let (var_8: uint64) = (var_7 - 1UL)
    let (var_9: uint64) = (var_8 / 256UL)
    let (var_10: uint64) = (var_9 * 256UL)
    let (var_11: EnvStack0) = method_11((var_1: ResizeArray<Env1>), (var_2: EnvStack0), (var_3: uint64), (var_4: ResizeArray<Env1>), (var_10: uint64))
    let (var_12: (int64 ref)) = (ref 0L)
    let (var_13: EnvStack2) = EnvStack2((var_12: (int64 ref)), (var_11: EnvStack0))
    method_12((var_13: EnvStack2), (var_0: ResizeArray<EnvStack2>))
    var_13
and method_5((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_15((var_0: EnvStack4), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: EnvStack4), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: EnvStack4), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64)): unit =
    let (var_21: int64) = (var_16 - var_15)
    let (var_22: int64) = (var_18 - var_17)
    let (var_23: int64) = (var_20 - var_19)
    let (var_24: int64) = (var_21 * var_22)
    let (var_25: int64) = (var_24 * var_23)
    let (var_26: bool) = (var_25 > 0L)
    let (var_27: bool) = (var_26 = false)
    if var_27 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_28: int64) = (var_22 * var_3)
    let (var_29: bool) = (var_2 = var_28)
    let (var_30: bool) = (var_29 = false)
    if var_30 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_31: int64) = (var_21 * var_2)
    let (var_32: int64) = (var_23 * var_4)
    let (var_33: bool) = (var_3 = var_32)
    let (var_34: bool) = (var_33 = false)
    if var_34 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_35: int64) = (var_31 * var_3)
    let (var_36: int64) = (var_22 * var_8)
    let (var_37: bool) = (var_7 = var_36)
    let (var_38: bool) = (var_37 = false)
    if var_38 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_39: int64) = (var_21 * var_7)
    let (var_40: int64) = (var_23 * var_9)
    let (var_41: bool) = (var_8 = var_40)
    let (var_42: bool) = (var_41 = false)
    if var_42 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_43: int64) = (var_39 * var_8)
    let (var_44: int64) = (var_22 * var_13)
    let (var_45: bool) = (var_12 = var_44)
    let (var_46: bool) = (var_45 = false)
    if var_46 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_47: int64) = (var_21 * var_12)
    let (var_48: int64) = (var_23 * var_14)
    let (var_49: bool) = (var_13 = var_48)
    let (var_50: bool) = (var_49 = false)
    if var_50 then
        (failwith "The tensor must be contiguous in order to be flattened.")
    else
        ()
    let (var_51: int64) = (var_47 * var_13)
    let (var_52: (int64 [])) = method_16((var_21: int64), (var_0: EnvStack4), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64))
    let (var_53: (int64 [])) = method_16((var_21: int64), (var_5: EnvStack4), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64))
    let (var_54: (int64 [])) = method_16((var_21: int64), (var_10: EnvStack4), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64))
    method_17((var_52: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_53: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_54: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64))
and method_27((var_0: ResizeArray<EnvStack3>)): unit =
    let (var_2: (EnvStack3 -> unit)) = method_28
    var_0.ForEach <| System.Action<_>(var_2)
    var_0.Clear()
and method_29((var_0: ResizeArray<EnvStack2>)): unit =
    let (var_2: (EnvStack2 -> unit)) = method_30
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
        let (var_8: (uint64 ref)) = var_6.mem_0
        let (var_9: uint64) = method_5((var_8: (uint64 ref)))
        let (var_10: (uint64 ref)) = var_2.mem_0
        let (var_11: uint64) = method_5((var_10: (uint64 ref)))
        let (var_12: uint64) = (var_9 - var_11)
        let (var_13: uint64) = method_5((var_10: (uint64 ref)))
        let (var_14: uint64) = (var_13 + 256UL)
        let (var_15: uint64) = (var_14 - 1UL)
        let (var_16: uint64) = (var_15 / 256UL)
        let (var_17: uint64) = (var_16 * 256UL)
        let (var_18: uint64) = (var_17 - var_13)
        let (var_19: bool) = (var_12 >= var_18)
        if var_19 then
            let (var_20: (uint64 ref)) = (ref var_17)
            let (var_21: EnvStack0) = EnvStack0((var_20: (uint64 ref)))
            let (var_22: uint64) = (var_12 - var_18)
            var_0.Add((Env1(var_21, var_22)))
        else
            ()
        let (var_23: int32) = (var_3 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_6: EnvStack0), (var_7: uint64), (var_23: int32))
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
and method_16((var_0: int64), (var_1: EnvStack4), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64)): (int64 []) =
    let (var_6: EnvStack2) = var_1.mem_0
    let (var_7: int64) = (var_0 * var_3)
    let (var_8: (int64 ref)) = var_6.mem_0
    let (var_9: EnvStack0) = var_6.mem_1
    let (var_10: (uint64 ref)) = var_9.mem_0
    let (var_11: uint64) = method_5((var_10: (uint64 ref)))
    let (var_12: int64) = (var_2 * 8L)
    let (var_13: uint64) = (uint64 var_12)
    let (var_14: uint64) = (var_11 + var_13)
    let (var_15: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_7))
    let (var_16: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_15,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_17: int64) = var_16.AddrOfPinnedObject().ToInt64()
    let (var_18: uint64) = (uint64 var_17)
    let (var_19: int64) = (var_7 * 8L)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_21: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_20)
    let (var_22: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_23: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_22)
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_19)
    let (var_25: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_21, var_23, var_24)
    if var_25 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_25)
    var_16.Free()
    var_15
and method_17((var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64)): unit =
    let (var_21: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_22: string) = ""
    let (var_23: int64) = 0L
    let (var_24: int64) = 0L
    method_18((var_21: System.Text.StringBuilder), (var_24: int64))
    let (var_25: System.Text.StringBuilder) = var_21.AppendLine("[|")
    let (var_26: int64) = method_19((var_21: System.Text.StringBuilder), (var_22: string), (var_0: (int64 [])), (var_1: int64), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_23: int64))
    let (var_27: int64) = 0L
    method_18((var_21: System.Text.StringBuilder), (var_27: int64))
    let (var_28: System.Text.StringBuilder) = var_21.AppendLine("|]")
    let (var_29: string) = var_21.ToString()
    let (var_30: string) = System.String.Format("{0}",var_29)
    System.Console.WriteLine(var_30)
and method_28 ((var_0: EnvStack3)): unit =
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
and method_30 ((var_0: EnvStack2)): unit =
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
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = method_5((var_9: (uint64 ref)))
        let (var_11: (uint64 ref)) = var_2.mem_0
        let (var_12: uint64) = method_5((var_11: (uint64 ref)))
        let (var_13: uint64) = (var_12 + var_3)
        let (var_14: uint64) = (var_10 - var_13)
        let (var_15: uint64) = method_5((var_11: (uint64 ref)))
        let (var_16: uint64) = (var_15 + 256UL)
        let (var_17: uint64) = (var_16 - 1UL)
        let (var_18: uint64) = (var_17 / 256UL)
        let (var_19: uint64) = (var_18 * 256UL)
        let (var_20: uint64) = (var_19 - var_15)
        let (var_21: bool) = (var_14 >= var_20)
        if var_21 then
            let (var_22: (uint64 ref)) = (ref var_19)
            let (var_23: EnvStack0) = EnvStack0((var_22: (uint64 ref)))
            let (var_24: uint64) = (var_14 - var_20)
            var_0.Add((Env1(var_23, var_24)))
        else
            ()
        let (var_25: int32) = (var_4 + 1)
        method_7((var_0: ResizeArray<Env1>), (var_1: int32), (var_7: EnvStack0), (var_8: uint64), (var_25: int32))
    else
        (Env1(var_2, var_3))
and method_18((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_18((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_19((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64)): int64 =
    let (var_24: bool) = (var_17 < var_18)
    if var_24 then
        let (var_25: bool) = (var_23 < 1000L)
        if var_25 then
            let (var_26: bool) = (var_17 >= var_17)
            let (var_27: bool) = (var_26 = false)
            if var_27 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_28: int64) = 0L
            method_20((var_0: System.Text.StringBuilder), (var_28: int64))
            let (var_29: System.Text.StringBuilder) = var_0.AppendLine("[|")
            let (var_30: int64) = method_21((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_15: int64), (var_16: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64))
            let (var_31: int64) = 0L
            method_20((var_0: System.Text.StringBuilder), (var_31: int64))
            let (var_32: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_33: int64) = (var_17 + 1L)
            method_26((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_30: int64), (var_33: int64))
        else
            let (var_35: int64) = 0L
            method_18((var_0: System.Text.StringBuilder), (var_35: int64))
            let (var_36: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_23
    else
        var_23
and method_20((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_20((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_21((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64)): int64 =
    let (var_19: bool) = (var_14 < var_15)
    if var_19 then
        let (var_20: bool) = (var_18 < 1000L)
        if var_20 then
            let (var_21: bool) = (var_14 >= var_14)
            let (var_22: bool) = (var_21 = false)
            if var_22 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_23: int64) = 0L
            method_22((var_0: System.Text.StringBuilder), (var_23: int64))
            let (var_24: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_25: int64) = method_23((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_3: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_13: int64), (var_16: int64), (var_17: int64), (var_1: string), (var_18: int64))
            let (var_26: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_27: int64) = (var_14 + 1L)
            method_25((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_25: int64), (var_27: int64))
        else
            let (var_29: int64) = 0L
            method_20((var_0: System.Text.StringBuilder), (var_29: int64))
            let (var_30: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_18
    else
        var_18
and method_26((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64)): int64 =
    let (var_25: bool) = (var_24 < var_18)
    if var_25 then
        let (var_26: bool) = (var_23 < 1000L)
        if var_26 then
            let (var_27: bool) = (var_24 >= var_17)
            let (var_28: bool) = (var_27 = false)
            if var_28 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_29: int64) = (var_24 - var_17)
            let (var_30: int64) = (var_29 * var_4)
            let (var_31: int64) = (var_3 + var_30)
            let (var_32: int64) = (var_29 * var_9)
            let (var_33: int64) = (var_8 + var_32)
            let (var_34: int64) = (var_29 * var_14)
            let (var_35: int64) = (var_13 + var_34)
            let (var_36: int64) = 0L
            method_20((var_0: System.Text.StringBuilder), (var_36: int64))
            let (var_37: System.Text.StringBuilder) = var_0.AppendLine("[|")
            let (var_38: int64) = method_21((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_31: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_33: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_35: int64), (var_15: int64), (var_16: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64))
            let (var_39: int64) = 0L
            method_20((var_0: System.Text.StringBuilder), (var_39: int64))
            let (var_40: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_41: int64) = (var_24 + 1L)
            method_26((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_38: int64), (var_41: int64))
        else
            let (var_43: int64) = 0L
            method_18((var_0: System.Text.StringBuilder), (var_43: int64))
            let (var_44: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_23
    else
        var_23
and method_22((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 8L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_22((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_23((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: string), (var_13: int64)): int64 =
    let (var_14: bool) = (var_10 < var_11)
    if var_14 then
        let (var_15: bool) = (var_13 < 1000L)
        if var_15 then
            let (var_16: System.Text.StringBuilder) = var_0.Append(var_12)
            let (var_17: bool) = (var_10 >= var_10)
            let (var_18: bool) = (var_17 = false)
            if var_18 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_19: int64) = var_1.[int32 var_2]
            let (var_20: int64) = var_4.[int32 var_5]
            let (var_21: int64) = var_7.[int32 var_8]
            let (var_22: string) = System.String.Format("{0}",var_21)
            let (var_23: string) = System.String.Format("{0}",var_20)
            let (var_24: string) = System.String.Format("{0}",var_19)
            let (var_25: string) = String.concat ", " [|var_24; var_23; var_22|]
            let (var_26: string) = System.String.Format("[{0}]",var_25)
            let (var_27: System.Text.StringBuilder) = var_0.Append(var_26)
            let (var_28: string) = "; "
            let (var_29: int64) = (var_13 + 1L)
            let (var_30: int64) = (var_10 + 1L)
            method_24((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_28: string), (var_29: int64), (var_30: int64))
        else
            let (var_32: System.Text.StringBuilder) = var_0.Append("...")
            var_13
    else
        var_13
and method_25((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64)): int64 =
    let (var_20: bool) = (var_19 < var_15)
    if var_20 then
        let (var_21: bool) = (var_18 < 1000L)
        if var_21 then
            let (var_22: bool) = (var_19 >= var_14)
            let (var_23: bool) = (var_22 = false)
            if var_23 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_24: int64) = (var_19 - var_14)
            let (var_25: int64) = (var_24 * var_4)
            let (var_26: int64) = (var_3 + var_25)
            let (var_27: int64) = (var_24 * var_8)
            let (var_28: int64) = (var_7 + var_27)
            let (var_29: int64) = (var_24 * var_12)
            let (var_30: int64) = (var_11 + var_29)
            let (var_31: int64) = 0L
            method_22((var_0: System.Text.StringBuilder), (var_31: int64))
            let (var_32: System.Text.StringBuilder) = var_0.Append("[|")
            let (var_33: int64) = method_23((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_26: int64), (var_5: int64), (var_6: (int64 [])), (var_28: int64), (var_9: int64), (var_10: (int64 [])), (var_30: int64), (var_13: int64), (var_16: int64), (var_17: int64), (var_1: string), (var_18: int64))
            let (var_34: System.Text.StringBuilder) = var_0.AppendLine("|]")
            let (var_35: int64) = (var_19 + 1L)
            method_25((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: (int64 [])), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: int64), (var_33: int64), (var_35: int64))
        else
            let (var_37: int64) = 0L
            method_20((var_0: System.Text.StringBuilder), (var_37: int64))
            let (var_38: System.Text.StringBuilder) = var_0.AppendLine("...")
            var_18
    else
        var_18
and method_24((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: string), (var_13: int64), (var_14: int64)): int64 =
    let (var_15: bool) = (var_14 < var_11)
    if var_15 then
        let (var_16: bool) = (var_13 < 1000L)
        if var_16 then
            let (var_17: System.Text.StringBuilder) = var_0.Append(var_12)
            let (var_18: bool) = (var_14 >= var_10)
            let (var_19: bool) = (var_18 = false)
            if var_19 then
                (failwith "Argument out of bounds.")
            else
                ()
            let (var_20: int64) = (var_14 - var_10)
            let (var_21: int64) = (var_20 * var_3)
            let (var_22: int64) = (var_2 + var_21)
            let (var_23: int64) = (var_20 * var_6)
            let (var_24: int64) = (var_5 + var_23)
            let (var_25: int64) = (var_20 * var_9)
            let (var_26: int64) = (var_8 + var_25)
            let (var_27: int64) = var_1.[int32 var_22]
            let (var_28: int64) = var_4.[int32 var_24]
            let (var_29: int64) = var_7.[int32 var_26]
            let (var_30: string) = System.String.Format("{0}",var_29)
            let (var_31: string) = System.String.Format("{0}",var_28)
            let (var_32: string) = System.String.Format("{0}",var_27)
            let (var_33: string) = String.concat ", " [|var_32; var_31; var_30|]
            let (var_34: string) = System.String.Format("[{0}]",var_33)
            let (var_35: System.Text.StringBuilder) = var_0.Append(var_34)
            let (var_36: string) = "; "
            let (var_37: int64) = (var_13 + 1L)
            let (var_38: int64) = (var_14 + 1L)
            method_24((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_36: string), (var_37: int64), (var_38: int64))
        else
            let (var_40: System.Text.StringBuilder) = var_0.Append("...")
            var_13
    else
        var_13
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
let (var_61: int64) = 4096L
let (var_62: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_61: int64))
let (var_63: EnvStack4) = EnvStack4((var_62: EnvStack2))
let (var_64: int64) = 4096L
let (var_65: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_64: int64))
let (var_66: EnvStack4) = EnvStack4((var_65: EnvStack2))
let (var_67: int64) = 4096L
let (var_68: EnvStack2) = method_10((var_46: ResizeArray<EnvStack2>), (var_41: ResizeArray<Env1>), (var_40: EnvStack0), (var_35: uint64), (var_42: ResizeArray<Env1>), (var_67: int64))
let (var_69: EnvStack4) = EnvStack4((var_68: EnvStack2))
let (var_70: EnvStack2) = var_63.mem_0
let (var_71: (int64 ref)) = var_70.mem_0
let (var_72: EnvStack0) = var_70.mem_1
let (var_73: (uint64 ref)) = var_72.mem_0
let (var_74: uint64) = method_5((var_73: (uint64 ref)))
let (var_75: EnvStack2) = var_66.mem_0
let (var_76: (int64 ref)) = var_75.mem_0
let (var_77: EnvStack0) = var_75.mem_1
let (var_78: (uint64 ref)) = var_77.mem_0
let (var_79: uint64) = method_5((var_78: (uint64 ref)))
let (var_80: EnvStack2) = var_69.mem_0
let (var_81: (int64 ref)) = var_80.mem_0
let (var_82: EnvStack0) = var_80.mem_1
let (var_83: (uint64 ref)) = var_82.mem_0
let (var_84: uint64) = method_5((var_83: (uint64 ref)))
// Cuda join point
// method_13((var_74: uint64), (var_79: uint64), (var_84: uint64))
let (var_85: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_32, var_1)
let (var_86: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_85.set_GridDimensions(var_86)
let (var_87: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_85.set_BlockDimensions(var_87)
let (var_88: (int64 ref)) = var_54.mem_0
let (var_89: EnvStack5) = var_54.mem_1
let (var_90: (bool ref)) = var_89.mem_0
let (var_91: ManagedCuda.CudaStream) = var_89.mem_1
let (var_92: bool) = (!var_90)
let (var_93: bool) = (var_92 = false)
if var_93 then
    (failwith "The stream has been disposed.")
else
    ()
let (var_94: ManagedCuda.BasicTypes.CUstream) = var_91.Stream
let (var_96: (System.Object [])) = [|var_74; var_79; var_84|]: (System.Object [])
var_85.RunAsync(var_94, var_96)
let (var_97: int64) = 0L
let (var_98: int64) = 256L
let (var_99: int64) = 128L
let (var_100: int64) = 1L
let (var_101: int64) = 0L
let (var_102: int64) = 256L
let (var_103: int64) = 128L
let (var_104: int64) = 1L
let (var_105: int64) = 0L
let (var_106: int64) = 256L
let (var_107: int64) = 128L
let (var_108: int64) = 1L
let (var_109: int64) = 0L
let (var_110: int64) = 2L
let (var_111: int64) = 0L
let (var_112: int64) = 2L
let (var_113: int64) = 0L
let (var_114: int64) = 128L
method_15((var_63: EnvStack4), (var_97: int64), (var_98: int64), (var_99: int64), (var_100: int64), (var_66: EnvStack4), (var_101: int64), (var_102: int64), (var_103: int64), (var_104: int64), (var_69: EnvStack4), (var_105: int64), (var_106: int64), (var_107: int64), (var_108: int64), (var_109: int64), (var_110: int64), (var_111: int64), (var_112: int64), (var_113: int64), (var_114: int64))
var_59.Dispose()
var_56.Dispose()
method_27((var_53: ResizeArray<EnvStack3>))
method_29((var_46: ResizeArray<EnvStack2>))
let (var_115: (uint64 ref)) = var_40.mem_0
let (var_116: uint64) = method_5((var_115: (uint64 ref)))
let (var_117: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_116)
let (var_118: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_117)
var_1.FreeMemory(var_118)
var_115 := 0UL
var_1.Dispose()

