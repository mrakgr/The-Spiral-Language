module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    struct Env0 {
        long long int mem_0;
    };
    __device__ __forceinline__ Env0 make_Env0(long long int mem_0){
        Env0 tmp;
        tmp.mem_0 = mem_0;
        return tmp;
    }
    struct Tuple2 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple2 make_Tuple2(float mem_0, float mem_1){
        Tuple2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Env1 {
        long long int mem_0;
        Tuple2 mem_1;
    };
    __device__ __forceinline__ Env1 make_Env1(long long int mem_0, Tuple2 mem_1){
        Env1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple4 {
        Tuple2 mem_0;
        Tuple2 mem_1;
    };
    __device__ __forceinline__ Tuple4 make_Tuple4(Tuple2 mem_0, Tuple2 mem_1){
        Tuple4 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef Tuple2(*FunPointer3)(Tuple2, Tuple2);
    __global__ void method_13(float * var_0, float * var_1);
    __global__ void method_17(float * var_0, float * var_1, float * var_2, float * var_3);
    __device__ char method_14(Env0 * var_0);
    __device__ char method_18(Env0 * var_0);
    __device__ char method_19(Env1 * var_0);
    __device__ Tuple2 method_20(Tuple2 var_0, Tuple2 var_1);
    
    __global__ void method_13(float * var_0, float * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (var_5 * 128);
        long long int var_9 = (var_8 + var_2);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_14(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 128);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 10);
            } else {
                var_17 = 0;
            }
            char var_18 = (var_17 == 0);
            if (var_18) {
                // "Argument out of bounds."
            } else {
            }
            char var_20;
            if (var_15) {
                var_20 = (var_13 < 10);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_0[var_13];
            float var_23 = var_1[var_13];
            var_1[var_13] = var_22;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_24 = var_10[0];
        long long int var_25 = var_24.mem_0;
    }
    __global__ void method_17(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_5 + var_8);
        Env0 var_11[1];
        var_11[0] = (make_Env0(var_10));
        while (method_18(var_11)) {
            Env0 var_13 = var_11[0];
            long long int var_14 = var_13.mem_0;
            long long int var_15 = (var_14 + 2);
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
            long long int var_20 = (var_14 * 5);
            char var_22;
            if (var_16) {
                var_22 = (var_14 < 2);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            printf("outer i=%d\n", var_14);
            long long int var_24 = (5 * var_7);
            long long int var_25 = (var_4 + var_24);
            float var_26 = __int_as_float(0xff800000);
            float var_27 = 0;
            Env1 var_28[1];
            var_28[0] = (make_Env1(var_25, make_Tuple2(var_26, var_27)));
            while (method_19(var_28)) {
                Env1 var_30 = var_28[0];
                long long int var_31 = var_30.mem_0;
                Tuple2 var_32 = var_30.mem_1;
                float var_33 = var_32.mem_0;
                float var_34 = var_32.mem_1;
                long long int var_35 = (var_31 + 5);
                char var_36 = (var_31 >= 0);
                char var_38;
                if (var_36) {
                    var_38 = (var_31 < 5);
                } else {
                    var_38 = 0;
                }
                char var_39 = (var_38 == 0);
                if (var_39) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_40 = (var_20 + var_31);
                float var_41 = var_0[var_40];
                float var_42 = var_1[var_40];
                printf("inner i=%d, (%f,%f)\n", var_31, var_41, var_42);
                char var_43 = (var_33 > var_41);
                Tuple2 var_44;
                if (var_43) {
                    var_44 = make_Tuple2(var_33, var_34);
                } else {
                    var_44 = make_Tuple2(var_41, var_42);
                }
                float var_45 = var_44.mem_0;
                float var_46 = var_44.mem_1;
                var_28[0] = (make_Env1(var_35, make_Tuple2(var_45, var_46)));
            }
            Env1 var_47 = var_28[0];
            long long int var_48 = var_47.mem_0;
            Tuple2 var_49 = var_47.mem_1;
            float var_50 = var_49.mem_0;
            float var_51 = var_49.mem_1;
            FunPointer3 var_54 = method_20;
            Tuple2 var_55 = cub::BlockReduce<Tuple2,5>().Reduce(make_Tuple2(var_50, var_51), var_54);
            float var_56 = var_55.mem_0;
            float var_57 = var_55.mem_1;
            char var_58 = (var_4 == 0);
            if (var_58) {
                char var_60;
                if (var_16) {
                    var_60 = (var_14 < 2);
                } else {
                    var_60 = 0;
                }
                char var_61 = (var_60 == 0);
                if (var_61) {
                    // "Argument out of bounds."
                } else {
                }
                float var_62 = var_2[var_14];
                float var_63 = var_3[var_14];
                var_2[var_14] = var_56;
                var_3[var_14] = var_57;
            } else {
            }
            var_11[0] = (make_Env0(var_15));
        }
        Env0 var_64 = var_11[0];
        long long int var_65 = var_64.mem_0;
    }
    __device__ char method_14(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_18(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 2);
    }
    __device__ char method_19(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        Tuple2 var_3 = var_1.mem_1;
        float var_4 = var_3.mem_0;
        float var_5 = var_3.mem_1;
        return (var_2 < 5);
    }
    __device__ Tuple2 method_20(Tuple2 var_0, Tuple2 var_1) {
        float var_2 = var_0.mem_0;
        float var_3 = var_0.mem_1;
        float var_4 = var_1.mem_0;
        float var_5 = var_1.mem_1;
        char var_6 = (var_2 > var_4);
        Tuple2 var_7;
        if (var_6) {
            var_7 = make_Tuple2(var_2, var_3);
        } else {
            var_7 = make_Tuple2(var_4, var_5);
        }
        float var_8 = var_7.mem_0;
        float var_9 = var_7.mem_1;
        return make_Tuple2(var_8, var_9);
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
and method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_3((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_2((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_4((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_5((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: EnvStack2), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_19: int64), (var_20: int64), (var_21: int64), (var_22: int64)): unit =
    let (var_23: bool) = (var_10 = var_19)
    let (var_25: bool) =
        if var_23 then
            (var_11 = var_20)
        else
            false
    let (var_29: bool) =
        if var_25 then
            let (var_26: bool) = (var_12 = var_21)
            if var_26 then
                (var_13 = var_22)
            else
                false
        else
            false
    let (var_30: bool) = (var_29 = false)
    if var_30 then
        (failwith "All tensors in zip need to have the same dimensions")
    else
        ()
    let (var_31: int64) = (var_11 - var_10)
    let (var_32: int64) = (var_13 - var_12)
    let (var_33: int64) = (var_31 * var_32)
    let (var_34: bool) = (var_10 < var_11)
    let (var_35: bool) = (var_34 = false)
    if var_35 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_36: bool) = (var_12 < var_13)
    let (var_37: bool) = (var_36 = false)
    if var_37 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_38: bool) = (0L = var_7)
    let (var_39: bool) = (var_38 = false)
    if var_39 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_40: bool) = (0L = var_16)
    let (var_41: bool) = (var_40 = false)
    if var_41 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_42: bool) = (var_6 = 0L)
    let (var_43: bool) = (var_42 = false)
    if var_43 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_44: (Union0 ref)) = var_5.mem_0
    let (var_45: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_44: (Union0 ref)))
    let (var_46: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_33))
    var_0.CopyToHost(var_46, var_45)
    var_0.Synchronize()
    let (var_47: bool) = (var_15 = 0L)
    let (var_48: bool) = (var_47 = false)
    if var_48 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_49: (Union0 ref)) = var_14.mem_0
    let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_49: (Union0 ref)))
    let (var_51: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(var_33))
    var_0.CopyToHost(var_51, var_50)
    var_0.Synchronize()
    let (var_52: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_53: string) = ""
    let (var_54: int64) = 0L
    method_6((var_52: System.Text.StringBuilder), (var_54: int64))
    let (var_55: System.Text.StringBuilder) = var_52.AppendLine("[|")
    method_7((var_52: System.Text.StringBuilder), (var_53: string), (var_46: (float32 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_51: (float32 [])), (var_15: int64), (var_16: int64), (var_17: int64), (var_18: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_56: int64) = 0L
    method_6((var_52: System.Text.StringBuilder), (var_56: int64))
    let (var_57: System.Text.StringBuilder) = var_52.AppendLine("|]")
    let (var_58: string) = var_52.ToString()
    let (var_59: string) = System.String.Format("{0}",var_58)
    System.Console.WriteLine(var_59)
and method_12((var_0: EnvStack2), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_4: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaStream), (var_7: EnvStack2), (var_8: int64)): unit =
    let (var_9: bool) = (var_8 < 32L)
    if var_9 then
        let (var_10: int64) = (var_8 + 2L)
        let (var_11: bool) = (var_8 >= 0L)
        let (var_12: bool) = (var_11 = false)
        if var_12 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_13: bool) = (var_10 > 0L)
        let (var_15: bool) =
            if var_13 then
                (var_10 <= 32L)
            else
                false
        let (var_16: bool) = (var_15 = false)
        if var_16 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_17: int64) = (var_8 * 5L)
        if var_12 then
            (failwith "Lower boundary out of bounds.")
        else
            ()
        let (var_19: bool) =
            if var_13 then
                (var_10 <= 32L)
            else
                false
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Higher boundary out of bounds.")
        else
            ()
        let (var_21: int64) = 40L
        let (var_22: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_21: int64))
        let (var_23: int64) = (var_17 * 4L)
        let (var_24: (Union0 ref)) = var_0.mem_0
        let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_24: (Union0 ref)))
        let (var_26: ManagedCuda.BasicTypes.SizeT) = var_25.Pointer
        let (var_27: uint64) = uint64 var_26
        let (var_28: uint64) = (uint64 var_23)
        let (var_29: uint64) = (var_27 + var_28)
        let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_29)
        let (var_31: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_30)
        let (var_32: (Union0 ref)) = var_22.mem_0
        let (var_33: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        // Cuda join point
        // method_13((var_31: ManagedCuda.BasicTypes.CUdeviceptr), (var_33: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_35: (System.Object [])) = [|var_31; var_33|]: (System.Object [])
        let (var_36: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_5, var_4)
        let (var_37: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_36.set_GridDimensions(var_37)
        let (var_38: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_36.set_BlockDimensions(var_38)
        let (var_39: ManagedCuda.BasicTypes.CUstream) = var_6.get_Stream()
        var_36.RunAsync(var_39, var_35)
        let (var_40: int64) = 40L
        let (var_41: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_40: int64))
        let (var_42: (Union0 ref)) = var_7.mem_0
        let (var_43: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_42: (Union0 ref)))
        let (var_44: ManagedCuda.BasicTypes.SizeT) = var_43.Pointer
        let (var_45: uint64) = uint64 var_44
        let (var_46: uint64) = (var_45 + var_28)
        let (var_47: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_46)
        let (var_48: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_47)
        let (var_49: (Union0 ref)) = var_41.mem_0
        let (var_50: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_49: (Union0 ref)))
        // Cuda join point
        // method_13((var_48: ManagedCuda.BasicTypes.CUdeviceptr), (var_50: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_52: (System.Object [])) = [|var_48; var_50|]: (System.Object [])
        let (var_53: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_13", var_5, var_4)
        let (var_54: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
        var_53.set_GridDimensions(var_54)
        let (var_55: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
        var_53.set_BlockDimensions(var_55)
        let (var_56: ManagedCuda.BasicTypes.CUstream) = var_6.get_Stream()
        var_53.RunAsync(var_56, var_52)
        let (var_57: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_32: (Union0 ref)))
        let (var_58: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10L))
        var_4.CopyToHost(var_58, var_57)
        var_4.Synchronize()
        let (var_59: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_49: (Union0 ref)))
        let (var_60: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(10L))
        var_4.CopyToHost(var_60, var_59)
        var_4.Synchronize()
        let (var_61: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_62: string) = ""
        let (var_63: int64) = 0L
        method_6((var_61: System.Text.StringBuilder), (var_63: int64))
        let (var_64: System.Text.StringBuilder) = var_61.AppendLine("[|")
        let (var_65: int64) = 0L
        method_15((var_61: System.Text.StringBuilder), (var_62: string), (var_58: (float32 [])), (var_60: (float32 [])), (var_65: int64))
        let (var_66: int64) = 0L
        method_6((var_61: System.Text.StringBuilder), (var_66: int64))
        let (var_67: System.Text.StringBuilder) = var_61.AppendLine("|]")
        let (var_68: string) = var_61.ToString()
        let (var_69: string) = System.String.Format("{0}",var_68)
        System.Console.WriteLine(var_69)
        var_49 := Union0Case1
        var_32 := Union0Case1
        let (var_70: int64) = 8L
        let (var_71: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_70: int64))
        let (var_72: int64) = 8L
        let (var_73: EnvStack2) = method_2((var_1: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_72: int64))
        let (var_74: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_24: (Union0 ref)))
        let (var_75: ManagedCuda.BasicTypes.SizeT) = var_74.Pointer
        let (var_76: uint64) = uint64 var_75
        let (var_77: uint64) = (var_76 + var_28)
        let (var_78: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_77)
        let (var_79: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_78)
        let (var_80: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_42: (Union0 ref)))
        let (var_81: ManagedCuda.BasicTypes.SizeT) = var_80.Pointer
        let (var_82: uint64) = uint64 var_81
        let (var_83: uint64) = (var_82 + var_28)
        let (var_84: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_83)
        let (var_85: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_84)
        let (var_86: (Union0 ref)) = var_71.mem_0
        let (var_87: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_86: (Union0 ref)))
        let (var_88: (Union0 ref)) = var_73.mem_0
        let (var_89: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_88: (Union0 ref)))
        // Cuda join point
        // method_17((var_79: ManagedCuda.BasicTypes.CUdeviceptr), (var_85: ManagedCuda.BasicTypes.CUdeviceptr), (var_87: ManagedCuda.BasicTypes.CUdeviceptr), (var_89: ManagedCuda.BasicTypes.CUdeviceptr))
        let (var_91: (System.Object [])) = [|var_79; var_85; var_87; var_89|]: (System.Object [])
        let (var_92: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_5, var_4)
        let (var_93: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 2u, 1u)
        var_92.set_GridDimensions(var_93)
        let (var_94: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(5u, 1u, 1u)
        var_92.set_BlockDimensions(var_94)
        let (var_95: ManagedCuda.BasicTypes.CUstream) = var_6.get_Stream()
        var_92.RunAsync(var_95, var_91)
        let (var_96: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_86: (Union0 ref)))
        let (var_97: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(2L))
        var_4.CopyToHost(var_97, var_96)
        var_4.Synchronize()
        let (var_98: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_88: (Union0 ref)))
        let (var_99: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(2L))
        var_4.CopyToHost(var_99, var_98)
        var_4.Synchronize()
        var_86 := Union0Case1
        var_88 := Union0Case1
        let (var_100: System.Text.StringBuilder) = System.Text.StringBuilder()
        let (var_101: string) = ""
        let (var_102: int64) = 0L
        method_6((var_100: System.Text.StringBuilder), (var_102: int64))
        let (var_103: System.Text.StringBuilder) = var_100.Append("[|")
        let (var_104: int64) = 0L
        let (var_105: string) = method_21((var_100: System.Text.StringBuilder), (var_97: (float32 [])), (var_99: (float32 [])), (var_101: string), (var_104: int64))
        let (var_106: System.Text.StringBuilder) = var_100.AppendLine("|]")
        let (var_107: string) = var_100.ToString()
        let (var_108: string) = System.String.Format("{0}",var_107)
        System.Console.WriteLine(var_108)
        method_12((var_0: EnvStack2), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env3>), (var_4: ManagedCuda.CudaContext), (var_5: ManagedCuda.BasicTypes.CUmodule), (var_6: ManagedCuda.CudaStream), (var_7: EnvStack2), (var_10: int64))
    else
        ()
and method_3((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
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
    let (var_17: uint64) = (var_16 % 128UL)
    let (var_18: uint64) = (var_16 + var_17)
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_18)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_3)))
    var_22
and method_4((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: uint64) = uint64 var_2
    let (var_5: bool) = (var_4 <= var_1)
    let (var_6: bool) = (var_5 = false)
    if var_6 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_7: uint64) = (var_0 % 128UL)
    let (var_8: uint64) = (var_0 + var_7)
    let (var_9: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_8)
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_9)
    let (var_11: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_10))))
    let (var_12: EnvStack2) = EnvStack2((var_11: (Union0 ref)))
    var_3.Push((Env3(var_12, var_2)))
    var_12
and method_6((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_6((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_7((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (float32 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64)): unit =
    let (var_16: bool) = (var_12 < var_13)
    if var_16 then
        let (var_17: bool) = (var_12 >= var_12)
        let (var_18: bool) = (var_17 = false)
        if var_18 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_19: int64) = (var_3 + var_4)
        let (var_20: int64) = (var_8 + var_9)
        let (var_21: int64) = 0L
        method_8((var_0: System.Text.StringBuilder), (var_21: int64))
        let (var_22: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_23: string) = method_9((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_19: int64), (var_6: int64), (var_7: (float32 [])), (var_20: int64), (var_11: int64), (var_14: int64), (var_15: int64), (var_1: string))
        let (var_24: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_25: int64) = (var_12 + 1L)
        method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (float32 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_25: int64))
    else
        ()
and method_15((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: (float32 [])), (var_4: int64)): unit =
    let (var_5: bool) = (var_4 < 2L)
    if var_5 then
        let (var_6: bool) = (var_4 >= 0L)
        let (var_7: bool) = (var_6 = false)
        if var_7 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: int64) = (var_4 * 5L)
        let (var_9: int64) = 0L
        method_8((var_0: System.Text.StringBuilder), (var_9: int64))
        let (var_10: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_11: int64) = 0L
        let (var_12: string) = method_16((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_8: int64), (var_3: (float32 [])), (var_1: string), (var_11: int64))
        let (var_13: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_14: int64) = (var_4 + 1L)
        method_15((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: (float32 [])), (var_14: int64))
    else
        ()
and method_21((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: (float32 [])), (var_3: string), (var_4: int64)): string =
    let (var_5: bool) = (var_4 < 2L)
    if var_5 then
        let (var_6: System.Text.StringBuilder) = var_0.Append(var_3)
        let (var_7: bool) = (var_4 >= 0L)
        let (var_8: bool) = (var_7 = false)
        if var_8 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_9: float32) = var_1.[int32 var_4]
        let (var_10: float32) = var_2.[int32 var_4]
        let (var_11: string) = System.String.Format("{0}",var_10)
        let (var_12: string) = System.String.Format("{0}",var_9)
        let (var_13: string) = String.concat ", " [|var_12; var_11|]
        let (var_14: string) = System.String.Format("[{0}]",var_13)
        let (var_15: System.Text.StringBuilder) = var_0.Append(var_14)
        let (var_16: string) = "; "
        let (var_17: int64) = (var_4 + 1L)
        method_21((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: (float32 [])), (var_16: string), (var_17: int64))
    else
        var_3
and method_8((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_8((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_9((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string)): string =
    let (var_10: bool) = (var_7 < var_8)
    if var_10 then
        let (var_11: System.Text.StringBuilder) = var_0.Append(var_9)
        let (var_12: bool) = (var_7 >= var_7)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_14: float32) = var_1.[int32 var_2]
        let (var_15: float32) = var_4.[int32 var_5]
        let (var_16: string) = System.String.Format("{0}",var_15)
        let (var_17: string) = System.String.Format("{0}",var_14)
        let (var_18: string) = String.concat ", " [|var_17; var_16|]
        let (var_19: string) = System.String.Format("[{0}]",var_18)
        let (var_20: System.Text.StringBuilder) = var_0.Append(var_19)
        let (var_21: string) = "; "
        let (var_22: int64) = (var_7 + 1L)
        method_10((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_21: string), (var_22: int64))
    else
        var_9
and method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (float32 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_16: int64)): unit =
    let (var_17: bool) = (var_16 < var_13)
    if var_17 then
        let (var_18: bool) = (var_16 >= var_12)
        let (var_19: bool) = (var_18 = false)
        if var_19 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_20: int64) = (var_16 - var_12)
        let (var_21: int64) = (var_20 * var_5)
        let (var_22: int64) = (var_3 + var_21)
        let (var_23: int64) = (var_22 + var_4)
        let (var_24: int64) = (var_20 * var_10)
        let (var_25: int64) = (var_8 + var_24)
        let (var_26: int64) = (var_25 + var_9)
        let (var_27: int64) = 0L
        method_8((var_0: System.Text.StringBuilder), (var_27: int64))
        let (var_28: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_29: string) = method_9((var_0: System.Text.StringBuilder), (var_2: (float32 [])), (var_23: int64), (var_6: int64), (var_7: (float32 [])), (var_26: int64), (var_11: int64), (var_14: int64), (var_15: int64), (var_1: string))
        let (var_30: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_31: int64) = (var_16 + 1L)
        method_11((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (float32 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: (float32 [])), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64), (var_14: int64), (var_15: int64), (var_31: int64))
    else
        ()
and method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: (float32 [])), (var_4: string), (var_5: int64)): string =
    let (var_6: bool) = (var_5 < 5L)
    if var_6 then
        let (var_7: System.Text.StringBuilder) = var_0.Append(var_4)
        let (var_8: bool) = (var_5 >= 0L)
        let (var_9: bool) = (var_8 = false)
        if var_9 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_10: int64) = (var_2 + var_5)
        let (var_11: float32) = var_1.[int32 var_10]
        let (var_12: float32) = var_3.[int32 var_10]
        let (var_13: string) = System.String.Format("{0}",var_12)
        let (var_14: string) = System.String.Format("{0}",var_11)
        let (var_15: string) = String.concat ", " [|var_14; var_13|]
        let (var_16: string) = System.String.Format("[{0}]",var_15)
        let (var_17: System.Text.StringBuilder) = var_0.Append(var_16)
        let (var_18: string) = "; "
        let (var_19: int64) = (var_5 + 1L)
        method_16((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: (float32 [])), (var_18: string), (var_19: int64))
    else
        var_4
and method_10((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: string), (var_10: int64)): string =
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
        let (var_20: float32) = var_1.[int32 var_17]
        let (var_21: float32) = var_4.[int32 var_19]
        let (var_22: string) = System.String.Format("{0}",var_21)
        let (var_23: string) = System.String.Format("{0}",var_20)
        let (var_24: string) = String.concat ", " [|var_23; var_22|]
        let (var_25: string) = System.String.Format("[{0}]",var_24)
        let (var_26: System.Text.StringBuilder) = var_0.Append(var_25)
        let (var_27: string) = "; "
        let (var_28: int64) = (var_10 + 1L)
        method_10((var_0: System.Text.StringBuilder), (var_1: (float32 [])), (var_2: int64), (var_3: int64), (var_4: (float32 [])), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_27: string), (var_28: int64))
    else
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
let (var_35: ManagedCuda.CudaDeviceProperties) = var_1.GetDeviceInfo()
let (var_36: ManagedCuda.BasicTypes.SizeT) = var_35.get_TotalGlobalMemory()
let (var_37: int64) = int64 var_36
let (var_38: float) = float var_37
let (var_39: float) = (0.700000 * var_38)
let (var_40: int64) = int64 var_39
let (var_41: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_40)
let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_41)
let (var_43: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_42))))
let (var_44: EnvStack2) = EnvStack2((var_43: (Union0 ref)))
let (var_45: System.Collections.Generic.Stack<Env3>) = System.Collections.Generic.Stack<Env3>()
let (var_46: (Union0 ref)) = var_44.mem_0
let (var_47: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
let (var_48: ManagedCuda.BasicTypes.SizeT) = var_47.Pointer
let (var_49: uint64) = uint64 var_48
let (var_50: uint64) = uint64 var_40
let (var_51: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_52: ManagedCuda.CudaRand.GeneratorType) = ManagedCuda.CudaRand.GeneratorType.PseudoDefault
let (var_53: ManagedCuda.CudaRand.CudaRandDevice) = ManagedCuda.CudaRand.CudaRandDevice(var_52)
let (var_54: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_53.SetStream(var_54)
let (var_55: ManagedCuda.CudaBlas.PointerMode) = ManagedCuda.CudaBlas.PointerMode.Host
let (var_56: ManagedCuda.CudaBlas.AtomicsMode) = ManagedCuda.CudaBlas.AtomicsMode.Allowed
let (var_57: ManagedCuda.CudaBlas.CudaBlas) = ManagedCuda.CudaBlas.CudaBlas(var_55, var_56)
let (var_58: ManagedCuda.CudaBlas.CudaBlasHandle) = var_57.get_CublasHandle()
let (var_59: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_57.set_Stream(var_59)
let (var_60: int64) = 640L
let (var_61: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_60: int64))
let (var_62: (Union0 ref)) = var_61.mem_0
let (var_63: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_62: (Union0 ref)))
let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(160L)
var_53.GenerateUniform32(var_63, var_64)
let (var_65: int64) = 640L
let (var_66: EnvStack2) = method_2((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_65: int64))
let (var_67: (Union0 ref)) = var_66.mem_0
let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
let (var_69: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(160L)
var_53.GenerateUniform32(var_68, var_69)
let (var_70: int64) = 0L
let (var_71: int64) = 0L
let (var_72: int64) = 5L
let (var_73: int64) = 1L
let (var_74: int64) = 0L
let (var_75: int64) = 32L
let (var_76: int64) = 0L
let (var_77: int64) = 5L
let (var_78: int64) = 0L
let (var_79: int64) = 0L
let (var_80: int64) = 5L
let (var_81: int64) = 1L
let (var_82: int64) = 0L
let (var_83: int64) = 32L
let (var_84: int64) = 0L
let (var_85: int64) = 5L
method_5((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_61: EnvStack2), (var_70: int64), (var_71: int64), (var_72: int64), (var_73: int64), (var_74: int64), (var_75: int64), (var_76: int64), (var_77: int64), (var_66: EnvStack2), (var_78: int64), (var_79: int64), (var_80: int64), (var_81: int64), (var_82: int64), (var_83: int64), (var_84: int64), (var_85: int64))
let (var_86: int64) = 0L
method_12((var_61: EnvStack2), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_51: ManagedCuda.CudaStream), (var_66: EnvStack2), (var_86: int64))
var_67 := Union0Case1
var_62 := Union0Case1
var_57.Dispose()
var_53.Dispose()
var_51.Dispose()
let (var_87: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_87)
var_46 := Union0Case1
var_1.Dispose()

