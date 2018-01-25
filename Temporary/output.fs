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
    struct Env1 {
        long long int mem_0;
        long long int mem_1;
    };
    __device__ __forceinline__ Env1 make_Env1(long long int mem_0, long long int mem_1){
        Env1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Env2 {
        long long int mem_0;
        long long int mem_1;
    };
    __device__ __forceinline__ Env2 make_Env2(long long int mem_0, long long int mem_1){
        Env2 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    __global__ void method_8(long long int * var_0, long long int * var_1);
    __device__ char method_9(Env0 * var_0);
    __device__ char method_10(Env1 * var_0);
    __device__ char method_11(Env2 * var_0);
    __device__ char method_12(long long int var_0, Env1 * var_1);
    
    __global__ void method_8(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = threadIdx.y;
        long long int var_4 = threadIdx.z;
        long long int var_5 = blockIdx.x;
        long long int var_6 = blockIdx.y;
        long long int var_7 = blockIdx.z;
        long long int var_8 = (10 * var_5);
        long long int var_9 = (var_2 + var_8);
        Env0 var_10[1];
        var_10[0] = (make_Env0(var_9));
        while (method_9(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 10);
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
            long long int var_22 = (4 * var_6);
            long long int var_23 = (var_3 + var_22);
            long long int var_24 = 0;
            Env1 var_25[1];
            var_25[0] = (make_Env1(var_23, var_24));
            while (method_10(var_25)) {
                Env1 var_27 = var_25[0];
                long long int var_28 = var_27.mem_0;
                long long int var_29 = var_27.mem_1;
                long long int var_30 = (var_28 + 4);
                char var_31 = (var_28 >= 0);
                char var_33;
                if (var_31) {
                    var_33 = (var_28 < 128);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_35 = (var_28 * 10);
                char var_37;
                if (var_15) {
                    var_37 = (var_13 < 10);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_39 = (var_35 + var_13);
                long long int var_40 = var_0[var_39];
                long long int var_41 = (var_40 + 1);
                long long int var_42 = (var_29 + var_41);
                var_25[0] = (make_Env1(var_30, var_42));
            }
            Env1 var_43 = var_25[0];
            long long int var_44 = var_43.mem_0;
            long long int var_45 = var_43.mem_1;
            __shared__ long long int var_46[99];
            Env2 var_47[1];
            var_47[0] = (make_Env2(4, var_45));
            while (method_11(var_47)) {
                Env2 var_49 = var_47[0];
                long long int var_50 = var_49.mem_0;
                long long int var_51 = var_49.mem_1;
                long long int var_52 = (var_50 / 2);
                char var_53 = (var_3 == 0);
                char var_55;
                if (var_53) {
                    var_55 = (var_2 == 0);
                } else {
                    var_55 = 0;
                }
                if (var_55) {
                    printf("I am in while. near_to=%d\n", var_50);
                } else {
                }
                char var_56 = (var_3 < var_50);
                char var_58;
                if (var_56) {
                    var_58 = (var_3 >= var_52);
                } else {
                    var_58 = 0;
                }
                if (var_58) {
                    char var_59 = (var_3 >= 1);
                    char var_61;
                    if (var_59) {
                        var_61 = (var_3 < 4);
                    } else {
                        var_61 = 0;
                    }
                    char var_62 = (var_61 == 0);
                    if (var_62) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_63 = (var_3 - 1);
                    long long int var_64 = (var_63 * 33);
                    char var_65 = (var_2 >= 0);
                    char var_67;
                    if (var_65) {
                        var_67 = (var_2 < 33);
                    } else {
                        var_67 = 0;
                    }
                    char var_68 = (var_67 == 0);
                    if (var_68) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_69 = (var_64 + var_2);
                    var_46[var_69] = var_45;
                } else {
                }
                __syncthreads();
                char var_71;
                if (var_56) {
                    var_71 = (var_3 >= var_52);
                } else {
                    var_71 = 0;
                }
                if (var_71) {
                    char var_72 = (var_13 >= 1);
                    char var_74;
                    if (var_72) {
                        var_74 = (var_13 < 4);
                    } else {
                        var_74 = 0;
                    }
                    char var_75 = (var_74 == 0);
                    if (var_75) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_76 = (var_13 - 1);
                    long long int var_77 = (var_76 * 33);
                    char var_78 = (var_2 >= 0);
                    char var_80;
                    if (var_78) {
                        var_80 = (var_2 < 33);
                    } else {
                        var_80 = 0;
                    }
                    char var_81 = (var_80 == 0);
                    if (var_81) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_82 = (var_77 + var_2);
                    long long int var_83 = var_46[var_82];
                    printf("ar (%lli,%lli) = %lli\n", var_3, var_2, var_83);
                } else {
                }
                char var_84 = (var_3 < var_52);
                long long int var_108;
                if (var_84) {
                    long long int var_85 = (var_3 + var_52);
                    Env1 var_86[1];
                    var_86[0] = (make_Env1(var_85, var_51));
                    while (method_12(var_50, var_86)) {
                        Env1 var_88 = var_86[0];
                        long long int var_89 = var_88.mem_0;
                        long long int var_90 = var_88.mem_1;
                        long long int var_91 = (var_89 + var_52);
                        char var_92 = (var_89 >= 1);
                        char var_94;
                        if (var_92) {
                            var_94 = (var_89 < 4);
                        } else {
                            var_94 = 0;
                        }
                        char var_95 = (var_94 == 0);
                        if (var_95) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_96 = (var_89 - 1);
                        long long int var_97 = (var_96 * 33);
                        char var_98 = (var_2 >= 0);
                        char var_100;
                        if (var_98) {
                            var_100 = (var_2 < 33);
                        } else {
                            var_100 = 0;
                        }
                        char var_101 = (var_100 == 0);
                        if (var_101) {
                            // "Argument out of bounds."
                        } else {
                        }
                        long long int var_102 = (var_97 + var_2);
                        long long int var_103 = var_46[var_102];
                        long long int var_104 = (var_90 + var_103);
                        var_86[0] = (make_Env1(var_91, var_104));
                    }
                    Env1 var_105 = var_86[0];
                    long long int var_106 = var_105.mem_0;
                    var_108 = var_105.mem_1;
                } else {
                    var_108 = var_51;
                }
                if (var_53) {
                    printf("state(%i) = %lli\n", var_2, var_108);
                } else {
                }
                var_47[0] = (make_Env2(var_52, var_108));
            }
            Env2 var_109 = var_47[0];
            long long int var_110 = var_109.mem_0;
            long long int var_111 = var_109.mem_1;
            char var_112 = (var_3 == 0);
            if (var_112) {
                long long int var_113 = var_1[var_13];
                var_1[var_13] = var_111;
            } else {
            }
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_114 = var_10[0];
        long long int var_115 = var_114.mem_0;
    }
    __device__ char method_9(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_10(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        long long int var_3 = var_1.mem_1;
        return (var_2 < 128);
    }
    __device__ char method_11(Env2 * var_0) {
        Env2 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        long long int var_3 = var_1.mem_1;
        return (var_2 >= 2);
    }
    __device__ char method_12(long long int var_0, Env1 * var_1) {
        Env1 var_2 = var_1[0];
        long long int var_3 = var_2.mem_0;
        long long int var_4 = var_2.mem_1;
        return (var_3 < var_0);
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
and method_2((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 128L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_5: int64) = (var_1 * 10L)
        let (var_6: int64) = 0L
        method_3((var_0: (int64 [])), (var_5: int64), (var_6: int64))
        let (var_7: int64) = (var_1 + 1L)
        method_2((var_0: (int64 [])), (var_7: int64))
    else
        ()
and method_4((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 10L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        var_0.[int32 var_1] <- 10L
        let (var_5: int64) = (var_1 + 1L)
        method_4((var_0: (int64 [])), (var_5: int64))
    else
        ()
and method_5((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_6((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_5((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_7((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_13((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64)): unit =
    let (var_14: int64) = (var_11 - var_10)
    let (var_15: int64) = (var_13 - var_12)
    let (var_16: int64) = (var_14 * var_15)
    let (var_17: bool) = (var_10 < var_11)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_19: bool) = (var_12 < var_13)
    let (var_20: bool) = (var_19 = false)
    if var_20 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_21: bool) = (0L = var_7)
    let (var_22: bool) = (var_21 = false)
    if var_22 then
        (failwith "The inner dimensions much have offsets of 0. They must not be 'view'ed. Consider reshaping a copy of the tensor instead")
    else
        ()
    let (var_23: bool) = (var_6 = 0L)
    let (var_24: bool) = (var_23 = false)
    if var_24 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_25: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_16))
    let (var_26: (Union0 ref)) = var_5.mem_0
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_26: (Union0 ref)))
    var_0.CopyToHost(var_25, var_27)
    let (var_28: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_29: string) = ""
    let (var_30: int64) = 0L
    method_14((var_28: System.Text.StringBuilder), (var_30: int64))
    let (var_31: System.Text.StringBuilder) = var_28.AppendLine("[|")
    method_15((var_28: System.Text.StringBuilder), (var_29: string), (var_25: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64), (var_12: int64), (var_13: int64))
    let (var_32: int64) = 0L
    method_14((var_28: System.Text.StringBuilder), (var_32: int64))
    let (var_33: System.Text.StringBuilder) = var_28.AppendLine("|]")
    let (var_34: string) = var_28.ToString()
    let (var_35: string) = System.String.Format("{0}",var_34)
    System.Console.WriteLine(var_35)
and method_20((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.CudaStream), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64)): unit =
    let (var_10: int64) = (var_9 - var_8)
    let (var_11: bool) = (var_8 < var_9)
    let (var_12: bool) = (var_11 = false)
    if var_12 then
        (failwith "Tensor needs to be at least size 1.")
    else
        ()
    let (var_13: bool) = (var_6 = 0L)
    let (var_14: bool) = (var_13 = false)
    if var_14 then
        (failwith "Only unviewed arrays are allowed for now.")
    else
        ()
    let (var_15: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_10))
    let (var_16: (Union0 ref)) = var_5.mem_0
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_16: (Union0 ref)))
    var_0.CopyToHost(var_15, var_17)
    let (var_18: System.Text.StringBuilder) = System.Text.StringBuilder()
    let (var_19: string) = ""
    let (var_20: int64) = 0L
    method_14((var_18: System.Text.StringBuilder), (var_20: int64))
    let (var_21: System.Text.StringBuilder) = var_18.Append("[|")
    let (var_22: string) = method_17((var_18: System.Text.StringBuilder), (var_15: (int64 [])), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_19: string))
    let (var_23: System.Text.StringBuilder) = var_18.AppendLine("|]")
    let (var_24: string) = var_18.ToString()
    let (var_25: string) = System.String.Format("{0}",var_24)
    System.Console.WriteLine(var_25)
and method_3((var_0: (int64 [])), (var_1: int64), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 10L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_1 + var_2)
        var_0.[int32 var_6] <- var_2
        let (var_7: int64) = (var_2 + 1L)
        method_3((var_0: (int64 [])), (var_1: int64), (var_7: int64))
    else
        ()
and method_6((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
    let (var_7: ManagedCuda.BasicTypes.SizeT) = var_0.Pointer
    let (var_8: uint64) = uint64 var_7
    let (var_9: uint64) = uint64 var_6
    let (var_10: int64) = (var_3 % 256L)
    let (var_11: int64) = (var_3 - var_10)
    let (var_12: int64) = (var_11 + 256L)
    let (var_13: uint64) = (var_8 + var_9)
    let (var_14: uint64) = (var_1 + var_2)
    let (var_15: uint64) = uint64 var_12
    let (var_16: uint64) = (var_14 - var_13)
    let (var_17: bool) = (var_15 <= var_16)
    let (var_18: bool) = (var_17 = false)
    if var_18 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_19: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_20: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_19)
    let (var_21: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_20))))
    let (var_22: EnvStack2) = EnvStack2((var_21: (Union0 ref)))
    var_4.Push((Env3(var_22, var_12)))
    var_22
and method_7((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
    let (var_4: int64) = (var_2 % 256L)
    let (var_5: int64) = (var_2 - var_4)
    let (var_6: int64) = (var_5 + 256L)
    let (var_7: uint64) = (var_0 + var_1)
    let (var_8: uint64) = uint64 var_6
    let (var_9: uint64) = (var_7 - var_0)
    let (var_10: bool) = (var_8 <= var_9)
    let (var_11: bool) = (var_10 = false)
    if var_11 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_12: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_0)
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_12)
    let (var_14: (Union0 ref)) = (ref (Union0Case0(Tuple1(var_13))))
    let (var_15: EnvStack2) = EnvStack2((var_14: (Union0 ref)))
    var_3.Push((Env3(var_15, var_6)))
    var_15
and method_14((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 0L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_14((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_15((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64)): unit =
    let (var_11: bool) = (var_7 < var_8)
    if var_11 then
        let (var_12: bool) = (var_7 >= var_7)
        let (var_13: bool) = (var_12 = false)
        if var_13 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_14: int64) = (var_3 + var_4)
        let (var_15: int64) = 0L
        method_16((var_0: System.Text.StringBuilder), (var_15: int64))
        let (var_16: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_17: string) = method_17((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_14: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_18: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_19: int64) = (var_7 + 1L)
        method_19((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_19: int64))
    else
        ()
and method_17((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string)): string =
    let (var_7: bool) = (var_4 < var_5)
    if var_7 then
        let (var_8: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_9: bool) = (var_4 >= var_4)
        let (var_10: bool) = (var_9 = false)
        if var_10 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_11: int64) = var_1.[int32 var_2]
        let (var_12: string) = System.String.Format("{0}",var_11)
        let (var_13: System.Text.StringBuilder) = var_0.Append(var_12)
        let (var_14: string) = "; "
        let (var_15: int64) = (var_4 + 1L)
        method_18((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_14: string), (var_15: int64))
    else
        var_6
and method_16((var_0: System.Text.StringBuilder), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 4L)
    if var_2 then
        let (var_3: System.Text.StringBuilder) = var_0.Append(' ')
        let (var_4: int64) = (var_1 + 1L)
        method_16((var_0: System.Text.StringBuilder), (var_4: int64))
    else
        ()
and method_19((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_11: int64)): unit =
    let (var_12: bool) = (var_11 < var_8)
    if var_12 then
        let (var_13: bool) = (var_11 >= var_7)
        let (var_14: bool) = (var_13 = false)
        if var_14 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_15: int64) = (var_11 - var_7)
        let (var_16: int64) = (var_15 * var_5)
        let (var_17: int64) = (var_3 + var_16)
        let (var_18: int64) = (var_17 + var_4)
        let (var_19: int64) = 0L
        method_16((var_0: System.Text.StringBuilder), (var_19: int64))
        let (var_20: System.Text.StringBuilder) = var_0.Append("[|")
        let (var_21: string) = method_17((var_0: System.Text.StringBuilder), (var_2: (int64 [])), (var_18: int64), (var_6: int64), (var_9: int64), (var_10: int64), (var_1: string))
        let (var_22: System.Text.StringBuilder) = var_0.AppendLine("|]")
        let (var_23: int64) = (var_11 + 1L)
        method_19((var_0: System.Text.StringBuilder), (var_1: string), (var_2: (int64 [])), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: int64), (var_7: int64), (var_8: int64), (var_9: int64), (var_10: int64), (var_23: int64))
    else
        ()
and method_18((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_6: string), (var_7: int64)): string =
    let (var_8: bool) = (var_7 < var_5)
    if var_8 then
        let (var_9: System.Text.StringBuilder) = var_0.Append(var_6)
        let (var_10: bool) = (var_7 >= var_4)
        let (var_11: bool) = (var_10 = false)
        if var_11 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_12: int64) = (var_7 - var_4)
        let (var_13: int64) = (var_12 * var_3)
        let (var_14: int64) = (var_2 + var_13)
        let (var_15: int64) = var_1.[int32 var_14]
        let (var_16: string) = System.String.Format("{0}",var_15)
        let (var_17: System.Text.StringBuilder) = var_0.Append(var_16)
        let (var_18: string) = "; "
        let (var_19: int64) = (var_7 + 1L)
        method_18((var_0: System.Text.StringBuilder), (var_1: (int64 [])), (var_2: int64), (var_3: int64), (var_4: int64), (var_5: int64), (var_18: string), (var_19: int64))
    else
        var_6
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
let (var_52: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(1280L))
let (var_53: int64) = 0L
method_2((var_52: (int64 [])), (var_53: int64))
let (var_54: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(10L))
let (var_55: int64) = 0L
method_4((var_54: (int64 [])), (var_55: int64))
let (var_56: int64) = var_52.LongLength
let (var_57: int64) = (var_56 * 8L)
let (var_58: EnvStack2) = method_5((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_57: int64))
let (var_59: (Union0 ref)) = var_58.mem_0
let (var_60: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_59: (Union0 ref)))
var_1.CopyToDevice(var_60, var_52)
let (var_61: int64) = var_54.LongLength
let (var_62: int64) = (var_61 * 8L)
let (var_63: EnvStack2) = method_5((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_62: int64))
let (var_64: (Union0 ref)) = var_63.mem_0
let (var_65: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_64: (Union0 ref)))
var_1.CopyToDevice(var_65, var_54)
let (var_67: int64) = 80L
let (var_68: EnvStack2) = method_5((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_67: int64))
let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_59: (Union0 ref)))
let (var_70: (Union0 ref)) = var_68.mem_0
let (var_71: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_70: (Union0 ref)))
// Cuda join point
// method_8((var_69: ManagedCuda.BasicTypes.CUdeviceptr), (var_71: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_72: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_8", var_32, var_1)
let (var_73: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_72.set_GridDimensions(var_73)
let (var_74: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 4u, 1u)
var_72.set_BlockDimensions(var_74)
let (var_75: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_77: (System.Object [])) = [|var_69; var_71|]: (System.Object [])
var_72.RunAsync(var_75, var_77)
let (var_78: int64) = 0L
let (var_79: int64) = 0L
let (var_80: int64) = 10L
let (var_81: int64) = 1L
let (var_82: int64) = 0L
let (var_83: int64) = 128L
let (var_84: int64) = 0L
let (var_85: int64) = 10L
method_13((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_58: EnvStack2), (var_78: int64), (var_79: int64), (var_80: int64), (var_81: int64), (var_82: int64), (var_83: int64), (var_84: int64), (var_85: int64))
let (var_86: int64) = 0L
let (var_87: int64) = 1L
let (var_88: int64) = 0L
let (var_89: int64) = 10L
method_20((var_1: ManagedCuda.CudaContext), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_68: EnvStack2), (var_86: int64), (var_87: int64), (var_88: int64), (var_89: int64))
var_70 := Union0Case1
var_64 := Union0Case1
var_59 := Union0Case1
var_51.Dispose()
let (var_90: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_90)
var_46 := Union0Case1
var_1.Dispose()

