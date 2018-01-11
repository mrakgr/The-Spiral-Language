module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_9(long long int * var_0, long long int * var_1, long long int * var_2, long long int * var_3, long long int * var_4, long long int * var_5, long long int * var_6, long long int * var_7);
    __device__ void method_10(long long int var_0, long long int var_1, long long int var_2, long long int * var_3, long long int * var_4, long long int * var_5, long long int * var_6, long long int * var_7, long long int * var_8, long long int * var_9, long long int * var_10, long long int var_11, long long int var_12, long long int var_13, long long int var_14);
    __device__ void method_11(long long int * var_0, long long int var_1, long long int * var_2, long long int * var_3, long long int * var_4, long long int * var_5, long long int * var_6, long long int * var_7, long long int * var_8, long long int var_9);
    
    __global__ void method_9(long long int * var_0, long long int * var_1, long long int * var_2, long long int * var_3, long long int * var_4, long long int * var_5, long long int * var_6, long long int * var_7) {
        long long int var_8 = threadIdx.x;
        long long int var_9 = threadIdx.y;
        long long int var_10 = threadIdx.z;
        long long int var_11 = blockIdx.x;
        long long int var_12 = blockIdx.y;
        long long int var_13 = blockIdx.z;
        long long int var_14 = (8 * var_11);
        long long int var_15 = (var_8 + var_14);
        method_10(var_11, var_12, var_13, var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_9, var_10, var_15);
    }
    __device__ void method_10(long long int var_0, long long int var_1, long long int var_2, long long int * var_3, long long int * var_4, long long int * var_5, long long int * var_6, long long int * var_7, long long int * var_8, long long int * var_9, long long int * var_10, long long int var_11, long long int var_12, long long int var_13, long long int var_14) {
        char var_15 = (var_14 < 8);
        if (var_15) {
            char var_16 = (var_14 >= 0);
            char var_17 = (var_16 == 0);
            if (var_17) {
                // unprinted assert;
            } else {
            }
            long long int var_18 = (8 * var_1);
            long long int var_19 = (var_12 + var_18);
            method_11(var_3, var_14, var_4, var_5, var_6, var_7, var_8, var_9, var_10, var_19);
            long long int var_20 = (var_14 + 8);
            method_10(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_9, var_10, var_11, var_12, var_13, var_20);
        } else {
        }
    }
    __device__ void method_11(long long int * var_0, long long int var_1, long long int * var_2, long long int * var_3, long long int * var_4, long long int * var_5, long long int * var_6, long long int * var_7, long long int * var_8, long long int var_9) {
        char var_10 = (var_9 < 8);
        if (var_10) {
            char var_11 = (var_9 >= 0);
            char var_12 = (var_11 == 0);
            if (var_12) {
                // unprinted assert;
            } else {
            }
            long long int var_13 = (var_9 * 8);
            char var_14 = (var_1 >= 0);
            char var_16;
            if (var_14) {
                var_16 = (var_1 < 8);
            } else {
                var_16 = 0;
            }
            char var_17 = (var_16 == 0);
            if (var_17) {
                // unprinted assert;
            } else {
            }
            long long int var_18 = (var_13 + var_1);
            if (var_12) {
                // unprinted assert;
            } else {
            }
            char var_20;
            if (var_14) {
                var_20 = (var_1 < 8);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // unprinted assert;
            } else {
            }
            long long int var_22 = var_0[var_1];
            long long int var_23 = var_2[var_1];
            long long int var_24 = var_3[var_18];
            long long int var_25 = var_4[var_18];
            long long int var_26 = var_5[var_18];
            long long int var_27 = var_6[var_18];
            long long int var_28 = var_7[var_18];
            long long int var_29 = var_8[var_18];
            var_5[var_18] = var_22;
            var_6[var_18] = var_23;
            var_7[var_18] = var_24;
            var_8[var_18] = var_25;
            long long int var_30 = (var_9 + 8);
            method_11(var_0, var_1, var_2, var_3, var_4, var_5, var_6, var_7, var_8, var_30);
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
and Env2 =
    struct
    val mem_0: Env3
    val mem_1: int64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Env3 =
    struct
    val mem_0: (Union0 ref)
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
and method_2((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 8L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        var_0.[int32 var_2] <- 2L
        var_1.[int32 var_2] <- 2L
        let (var_6: int64) = (var_2 + 1L)
        method_2((var_0: (int64 [])), (var_1: (int64 [])), (var_6: int64))
    else
        ()
and method_3((var_0: (int64 [])), (var_1: (int64 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 8L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_2 * 8L)
        let (var_7: int64) = 0L
        method_4((var_2: int64), (var_0: (int64 [])), (var_6: int64), (var_1: (int64 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_3((var_0: (int64 [])), (var_1: (int64 [])), (var_8: int64))
    else
        ()
and method_5((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64)): Env3 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env2) = var_1.Peek()
        let (var_7: Env3) = var_6.mem_0
        let (var_8: int64) = var_6.mem_1
        let (var_9: (Union0 ref)) = var_7.mem_0
        let (var_10: Union0) = (!var_9)
        match var_10 with
        | Union0Case0(var_11) ->
            let (var_12: ManagedCuda.BasicTypes.CUdeviceptr) = var_11.mem_0
            method_6((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>), (var_7: Env3), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env2) = var_1.Pop()
            let (var_15: Env3) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_5((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env2>), (var_2: uint64), (var_3: int64))
    else
        method_7((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env2>))
and method_8((var_0: (Union0 ref))): ManagedCuda.BasicTypes.CUdeviceptr =
    let (var_1: Union0) = (!var_0)
    match var_1 with
    | Union0Case0(var_2) ->
        var_2.mem_0
    | Union0Case1 ->
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
and method_12((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: (Union0 ref)), (var_6: int64), (var_7: int64), (var_8: (Union0 ref)), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64)): unit =
    let (var_13: int64) = (var_12 - var_11)
    let (var_14: bool) = (var_11 < var_12)
    let (var_15: bool) = (var_14 = false)
    if var_15 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_16: bool) = (var_6 = 0L)
    let (var_17: bool) = (var_16 = false)
    if var_17 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_18: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_5: (Union0 ref)))
    let (var_19: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_13))
    var_0.CopyToHost(var_19, var_18)
    var_0.Synchronize()
    let (var_20: bool) = (var_9 = 0L)
    let (var_21: bool) = (var_20 = false)
    if var_21 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_8: (Union0 ref)))
    let (var_23: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_13))
    var_0.CopyToHost(var_23, var_22)
    var_0.Synchronize()
    let (var_24: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_25: string) = ""
    let (var_26: int64) = 0L
    method_13((var_24: System.Text.StringBuilder), (var_26: int64))
    let (var_27: System.Text.StringBuilder) = var_24.Append("[|")
    let (var_28: string) = method_14((var_24: System.Text.StringBuilder), (var_19: (int64 [])), (var_6: int64), (var_7: int64), (var_23: (int64 [])), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_25: string))
    let (var_29: System.Text.StringBuilder) = var_24.AppendLine("|]")
    let (var_30: string) = var_24.ToString()
    let (var_31: string) = System.String.Format("{0}",var_30)
    System.Console.WriteLine(var_31)
and method_16((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: (Union0 ref)), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: (Union0 ref)), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: (Union0 ref)), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: (Union0 ref)), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64), (var_26: int64), (var_27: int64), (var_28: int64)): unit =
    let (var_29: int64) = (var_26 - var_25)
    let (var_30: int64) = (var_28 - var_27)
    let (var_31: int64) = (var_29 * var_30)
    let (var_32: bool) = (var_25 < var_26)
    let (var_33: bool) = (var_32 = false)
    if var_33 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_34: bool) = (var_27 < var_28)
    let (var_35: bool) = (var_34 = false)
    if var_35 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_36: bool) = (0L = var_7)
    let (var_37: bool) = (var_36 = false)
    if var_37 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_38: bool) = (0L = var_12)
    let (var_39: bool) = (var_38 = false)
    if var_39 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_40: bool) = (0L = var_17)
    let (var_41: bool) = (var_40 = false)
    if var_41 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_42: bool) = (0L = var_22)
    let (var_43: bool) = (var_42 = false)
    if var_43 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_44: bool) = (var_6 = 0L)
    let (var_45: bool) = (var_44 = false)
    if var_45 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_46: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_5: (Union0 ref)))
    let (var_47: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_31))
    var_0.CopyToHost(var_47, var_46)
    var_0.Synchronize()
    let (var_48: bool) = (var_11 = 0L)
    let (var_49: bool) = (var_48 = false)
    if var_49 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_10: (Union0 ref)))
    let (var_51: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_31))
    var_0.CopyToHost(var_51, var_50)
    var_0.Synchronize()
    let (var_52: bool) = (var_16 = 0L)
    let (var_53: bool) = (var_52 = false)
    if var_53 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_15: (Union0 ref)))
    let (var_55: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_31))
    var_0.CopyToHost(var_55, var_54)
    var_0.Synchronize()
    let (var_56: bool) = (var_21 = 0L)
    let (var_57: bool) = (var_56 = false)
    if var_57 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_58: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_20: (Union0 ref)))
    let (var_59: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_31))
    var_0.CopyToHost(var_59, var_58)
    var_0.Synchronize()
    let (var_60: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_61: string) = ""
    let (var_62: int64) = 0L
    method_13((var_60: System.Text.StringBuilder), (var_62: int64))
    let (var_63: System.Text.StringBuilder) = var_60.AppendLine("[|")
    method_17((var_60: System.Text.StringBuilder), (var_61: string), (var_47: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_51: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_55: (int64 [])), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_59: (int64 [])), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64), (var_26: int64), (var_27: int64), (var_28: int64))
    let (var_64: int64) = 0L
    method_13((var_60: System.Text.StringBuilder), (var_64: int64))
    let (var_65: System.Text.StringBuilder) = var_60.AppendLine("|]")
    let (var_66: string) = var_60.ToString()
    let (var_67: string) = System.String.Format("{0}",var_66)
    System.Console.WriteLine(var_67)
and method_4((var_0: int64), (var_1: (int64 [])), (var_2: int64), (var_3: (int64 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 8L)
    if var_5 then
        let (var_6: bool) = (var_4 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: int64) = (var_2 + var_4)
        var_1.[int32 var_8] <- var_0
        var_3.[int32 var_8] <- var_4
        let (var_9: int64) = (var_4 + 1L)
        method_4((var_0: int64), (var_1: (int64 [])), (var_2: int64), (var_3: (int64 [])), (var_9: int64))
    else
        ()
and method_6((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env2>), (var_5: Env3), (var_6: int64)): Env3 =
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
    var_4.Push((Env2((Env3(var_19)), var_3)))
    (Env3(var_19))
and method_7((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env2>)): Env3 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_7)
    let (var_9: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_8))))
    var_3.Push((Env2((Env3(var_9)), var_2)))
    (Env3(var_9))
and method_13((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_13((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_14((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string)): string =
    let (var_10: bool) = (var_7 < var_8)
    if var_10 then
        let (var_11: System.Text.StringBuilder) = var_0.Append(var_9)
        let (var_12: bool) = (var_7 >= var_7)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_14: int64) = var_1.[int32 var_2]
        let (var_15: int64) = var_4.[int32 var_5]
        let (var_16: string) = System.String.Format("{0}",var_15)
        let (var_17: string) = System.String.Format("{0}",var_14)
        let (var_18: string) = String.concat ", " [|var_17; var_16|]
        let (var_19: string) = System.String.Format("[{0}]",var_18)
        let (var_20: System.Text.StringBuilder) = var_0.Append(var_19)
        let (var_21: string) = "; "
        let (var_22: int64) = (var_7 + 1L)
        method_15((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_21: string), (var_22: int64))
    else
        var_9
and method_17((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: (int64 [])), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64)): unit =
    let (var_26: bool) = (var_22 < var_23)
    if var_26 then
        let (var_27: bool) = (var_22 >= var_22)
        let (var_28: bool) = (var_27 = false)
        if var_28 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_29: int64) = (var_3 + var_4)
        let (var_30: int64) = (var_8 + var_9)
        let (var_31: int64) = (var_13 + var_14)
        let (var_32: int64) = (var_18 + var_19)
        let (var_33: int64) = 0L
        method_18((var_0: System.Text.StringBuilder), (var_33: int64))
        let (var_34: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_35: string) = method_19((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_29: int64), (var_6: int64), (var_7: (int64 [])), (var_30: int64), (var_11: int64), (var_12: (int64 [])), (var_31: int64), (var_16: int64), (var_17: (int64 [])), (var_32: int64), (var_21: int64), (var_24: int64), (var_25: int64), (var_1: string))
        let (var_36: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_37: int64) = (var_22 + 1L)
        method_21((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: (int64 [])), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64), (var_37: int64))
    else
        ()
and method_15((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64)): string =
    let (var_11: bool) = (var_10 < var_8)
    if var_11 then
        let (var_12: System.Text.StringBuilder) = var_0.Append(var_9)
        let (var_13: bool) = (var_10 >= var_7)
        let (var_14: bool) = (var_13 = false)
        if var_14 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_15: int64) = (var_10 - var_7)
        let (var_16: int64) = (var_15 * var_3)
        let (var_17: int64) = (var_2 + var_16)
        let (var_18: int64) = (var_15 * var_6)
        let (var_19: int64) = (var_5 + var_18)
        let (var_20: int64) = var_1.[int32 var_17]
        let (var_21: int64) = var_4.[int32 var_19]
        let (var_22: string) = System.String.Format("{0}",var_21)
        let (var_23: string) = System.String.Format("{0}",var_20)
        let (var_24: string) = String.concat ", " [|var_23; var_22|]
        let (var_25: string) = System.String.Format("[{0}]",var_24)
        let (var_26: System.Text.StringBuilder) = var_0.Append(var_25)
        let (var_27: string) = "; "
        let (var_28: int64) = (var_10 + 1L)
        method_15((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_27: string), (var_28: int64))
    else
        var_9
and method_18((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_18((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_19((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: string)): string =
    let (var_16: bool) = (var_13 < var_14)
    if var_16 then
        let (var_17: System.Text.StringBuilder) = var_0.Append(var_15)
        let (var_18: bool) = (var_13 >= var_13)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_20: int64) = var_1.[int32 var_2]
        let (var_21: int64) = var_4.[int32 var_5]
        let (var_22: int64) = var_7.[int32 var_8]
        let (var_23: int64) = var_10.[int32 var_11]
        let (var_24: string) = System.String.Format("{0}",var_23)
        let (var_25: string) = System.String.Format("{0}",var_22)
        let (var_26: string) = String.concat ", " [|var_25; var_24|]
        let (var_27: string) = System.String.Format("[{0}]",var_26)
        let (var_28: string) = System.String.Format("{0}",var_21)
        let (var_29: string) = System.String.Format("{0}",var_20)
        let (var_30: string) = String.concat ", " [|var_29; var_28|]
        let (var_31: string) = System.String.Format("[{0}]",var_30)
        let (var_32: string) = String.concat ", " [|var_31; var_27|]
        let (var_33: string) = System.String.Format("[{0}]",var_32)
        let (var_34: System.Text.StringBuilder) = var_0.Append(var_33)
        let (var_35: string) = "; "
        let (var_36: int64) = (var_13 + 1L)
        method_20((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_35: string), (var_36: int64))
    else
        var_15
and method_21((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: (int64 [])), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64), (var_26: int64)): unit =
    let (var_27: bool) = (var_26 < var_23)
    if var_27 then
        let (var_28: bool) = (var_26 >= var_22)
        let (var_29: bool) = (var_28 = false)
        if var_29 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_30: int64) = (var_26 - var_22)
        let (var_31: int64) = (var_30 * var_5)
        let (var_32: int64) = (var_3 + var_31)
        let (var_33: int64) = (var_32 + var_4)
        let (var_34: int64) = (var_30 * var_10)
        let (var_35: int64) = (var_8 + var_34)
        let (var_36: int64) = (var_35 + var_9)
        let (var_37: int64) = (var_30 * var_15)
        let (var_38: int64) = (var_13 + var_37)
        let (var_39: int64) = (var_38 + var_14)
        let (var_40: int64) = (var_30 * var_20)
        let (var_41: int64) = (var_18 + var_40)
        let (var_42: int64) = (var_41 + var_19)
        let (var_43: int64) = 0L
        method_18((var_0: System.Text.StringBuilder), (var_43: int64))
        let (var_44: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_45: string) = method_19((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_33: int64), (var_6: int64), (var_7: (int64 [])), (var_36: int64), (var_11: int64), (var_12: (int64 [])), (var_39: int64), (var_16: int64), (var_17: (int64 [])), (var_42: int64), (var_21: int64), (var_24: int64), (var_25: int64), (var_1: string))
        let (var_46: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_47: int64) = (var_26 + 1L)
        method_21((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: (int64 [])), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64), (var_17: (int64 [])), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64), (var_23: int64), (var_24: int64), (var_25: int64), (var_47: int64))
    else
        ()
and method_20((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: string), (var_16: int64)): string =
    let (var_17: bool) = (var_16 < var_14)
    if var_17 then
        let (var_18: System.Text.StringBuilder) = var_0.Append(var_15)
        let (var_19: bool) = (var_16 >= var_13)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_21: int64) = (var_16 - var_13)
        let (var_22: int64) = (var_21 * var_3)
        let (var_23: int64) = (var_2 + var_22)
        let (var_24: int64) = (var_21 * var_6)
        let (var_25: int64) = (var_5 + var_24)
        let (var_26: int64) = (var_21 * var_9)
        let (var_27: int64) = (var_8 + var_26)
        let (var_28: int64) = (var_21 * var_12)
        let (var_29: int64) = (var_11 + var_28)
        let (var_30: int64) = var_1.[int32 var_23]
        let (var_31: int64) = var_4.[int32 var_25]
        let (var_32: int64) = var_7.[int32 var_27]
        let (var_33: int64) = var_10.[int32 var_29]
        let (var_34: string) = System.String.Format("{0}",var_33)
        let (var_35: string) = System.String.Format("{0}",var_32)
        let (var_36: string) = String.concat ", " [|var_35; var_34|]
        let (var_37: string) = System.String.Format("[{0}]",var_36)
        let (var_38: string) = System.String.Format("{0}",var_31)
        let (var_39: string) = System.String.Format("{0}",var_30)
        let (var_40: string) = String.concat ", " [|var_39; var_38|]
        let (var_41: string) = System.String.Format("[{0}]",var_40)
        let (var_42: string) = String.concat ", " [|var_41; var_37|]
        let (var_43: string) = System.String.Format("[{0}]",var_42)
        let (var_44: System.Text.StringBuilder) = var_0.Append(var_43)
        let (var_45: string) = "; "
        let (var_46: int64) = (var_16 + 1L)
        method_20((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64), (var_7: (int64 [])), (var_8: int64), (var_9: int64), (var_10: (int64 [])), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_45: string), (var_46: int64))
    else
        var_15
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
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: System.Collections.Generic.Stack<Env2>) = System.Collections.Generic.Stack<Env2>()
let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
let (var_46: ManagedCuda.BasicTypes.SizeT) = var_45.Pointer
let (var_47: uint64) = uint64 var_46
let (var_48: uint64) = uint64 var_40
let (var_49: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_50: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_51: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(8L))
let (var_52: int64) = 0L
method_2((var_50: (int64 [])), (var_51: (int64 [])), (var_52: int64))
let (var_53: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(64L))
let (var_54: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(64L))
let (var_55: int64) = 0L
method_3((var_53: (int64 [])), (var_54: (int64 [])), (var_55: int64))
let (var_56: int64) = var_50.LongLength
let (var_57: int64) = (var_56 * 8L)
let (var_58: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_57: int64))
let (var_59: (Union0 ref)) = var_58.mem_0
let (var_60: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_59: (Union0 ref)))
var_1.CopyToDevice(var_60, var_50)
let (var_61: int64) = var_51.LongLength
let (var_62: int64) = (var_61 * 8L)
let (var_63: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_62: int64))
let (var_64: (Union0 ref)) = var_63.mem_0
let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_64: (Union0 ref)))
var_1.CopyToDevice(var_65, var_51)
let (var_66: int64) = var_53.LongLength
let (var_67: int64) = (var_66 * 8L)
let (var_68: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_67: int64))
let (var_69: (Union0 ref)) = var_68.mem_0
let (var_70: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_69: (Union0 ref)))
var_1.CopyToDevice(var_70, var_53)
let (var_71: int64) = var_54.LongLength
let (var_72: int64) = (var_71 * 8L)
let (var_73: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_72: int64))
let (var_74: (Union0 ref)) = var_73.mem_0
let (var_75: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_74: (Union0 ref)))
var_1.CopyToDevice(var_75, var_54)
let (var_76: int64) = 512L
let (var_77: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_76: int64))
let (var_78: (Union0 ref)) = var_77.mem_0
let (var_79: int64) = 512L
let (var_80: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_79: int64))
let (var_81: (Union0 ref)) = var_80.mem_0
let (var_82: int64) = 512L
let (var_83: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_82: int64))
let (var_84: (Union0 ref)) = var_83.mem_0
let (var_85: int64) = 512L
let (var_86: Env3) = method_5((var_47: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_48: uint64), (var_85: int64))
let (var_87: (Union0 ref)) = var_86.mem_0
let (var_88: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_59: (Union0 ref)))
let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_64: (Union0 ref)))
let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_69: (Union0 ref)))
let (var_91: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_74: (Union0 ref)))
let (var_92: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_78: (Union0 ref)))
let (var_93: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_81: (Union0 ref)))
let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_84: (Union0 ref)))
let (var_95: ManagedCuda.BasicTypes.CUdeviceptr) = method_8((var_87: (Union0 ref)))
// Cuda join point
// method_9((var_88: ManagedCuda.BasicTypes.CUdeviceptr), (var_89: ManagedCuda.BasicTypes.CUdeviceptr), (var_90: ManagedCuda.BasicTypes.CUdeviceptr), (var_91: ManagedCuda.BasicTypes.CUdeviceptr), (var_92: ManagedCuda.BasicTypes.CUdeviceptr), (var_93: ManagedCuda.BasicTypes.CUdeviceptr), (var_94: ManagedCuda.BasicTypes.CUdeviceptr), (var_95: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_97: (System.Object [])) = [|var_88; var_89; var_90; var_91; var_92; var_93; var_94; var_95|]: (System.Object [])
let (var_98: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_9", var_32, var_1)
let (var_99: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_98.set_GridDimensions(var_99)
let (var_100: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(8u, 8u, 1u)
var_98.set_BlockDimensions(var_100)
let (var_101: ManagedCuda.BasicTypes.CUstream) = var_49.get_Stream()
var_98.RunAsync(var_101, var_97)
let (var_102: int64) = 0L
let (var_103: int64) = 1L
let (var_104: int64) = 0L
let (var_105: int64) = 1L
let (var_106: int64) = 0L
let (var_107: int64) = 8L
method_12((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_59: (Union0 ref)), (var_102: int64), (var_103: int64), (var_64: (Union0 ref)), (var_104: int64), (var_105: int64), (var_106: int64), (var_107: int64))
let (var_108: int64) = 0L
let (var_109: int64) = 0L
let (var_110: int64) = 8L
let (var_111: int64) = 1L
let (var_112: int64) = 0L
let (var_113: int64) = 0L
let (var_114: int64) = 8L
let (var_115: int64) = 1L
let (var_116: int64) = 0L
let (var_117: int64) = 0L
let (var_118: int64) = 8L
let (var_119: int64) = 1L
let (var_120: int64) = 0L
let (var_121: int64) = 0L
let (var_122: int64) = 8L
let (var_123: int64) = 1L
let (var_124: int64) = 0L
let (var_125: int64) = 8L
let (var_126: int64) = 0L
let (var_127: int64) = 8L
method_16((var_1: ManagedCuda.CudaContext), (var_49: ManagedCuda.CudaStream), (var_47: uint64), (var_48: uint64), (var_44: System.Collections.Generic.Stack<Env2>), (var_78: (Union0 ref)), (var_108: int64), (var_109: int64), (var_110: int64), (var_111: int64), (var_81: (Union0 ref)), (var_112: int64), (var_113: int64), (var_114: int64), (var_115: int64), (var_84: (Union0 ref)), (var_116: int64), (var_117: int64), (var_118: int64), (var_119: int64), (var_87: (Union0 ref)), (var_120: int64), (var_121: int64), (var_122: int64), (var_123: int64), (var_124: int64), (var_125: int64), (var_126: int64), (var_127: int64))
var_78 := Union0Case1
var_81 := Union0Case1
var_84 := Union0Case1
var_87 := Union0Case1
var_69 := Union0Case1
var_74 := Union0Case1
var_59 := Union0Case1
var_64 := Union0Case1
var_49.Dispose()
let (var_128: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
var_1.FreeMemory(var_128)
var_43 := Union0Case1
var_1.Dispose()

