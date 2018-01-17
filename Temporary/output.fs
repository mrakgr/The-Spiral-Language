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
        float mem_1;
    };
    __device__ __forceinline__ Env1 make_Env1(long long int mem_0, float mem_1){
        Env1 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    struct Tuple3 {
        float mem_0;
        float mem_1;
    };
    __device__ __forceinline__ Tuple3 make_Tuple3(float mem_0, float mem_1){
        Tuple3 tmp;
        tmp.mem_0 = mem_0;
        tmp.mem_1 = mem_1;
        return tmp;
    }
    typedef float(*FunPointer2)(float, float);
    __global__ void method_14(float * var_0, float * var_1, float * var_2);
    __global__ void method_17(float * var_0, float * var_1);
    __global__ void method_20(float * var_0, float * var_1, float * var_2);
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, float * var_4);
    __global__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3);
    __global__ void method_28(float * var_0, float * var_1);
    __device__ char method_15(Env0 * var_0);
    __device__ char method_16(Env0 * var_0);
    __device__ char method_18(Env0 * var_0);
    __device__ char method_21(Env1 * var_0);
    __device__ float method_22(float var_0, float var_1);
    __device__ char method_29(Env1 * var_0);
    __device__ char method_30(Env1 * var_0);
    
    __global__ void method_14(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (10 * var_6);
        long long int var_10 = (var_3 + var_9);
        Env0 var_11[1];
        var_11[0] = (make_Env0(var_10));
        while (method_15(var_11)) {
            Env0 var_13 = var_11[0];
            long long int var_14 = var_13.mem_0;
            long long int var_15 = (var_14 + 10);
            char var_16 = (var_14 >= 0);
            char var_18;
            if (var_16) {
                var_18 = (var_14 < 10);
            } else {
                var_18 = 0;
            }
            char var_19 = (var_18 == 0);
            if (var_19) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_20 = (8 * var_7);
            long long int var_21 = (var_4 + var_20);
            Env0 var_22[1];
            var_22[0] = (make_Env0(var_21));
            while (method_16(var_22)) {
                Env0 var_24 = var_22[0];
                long long int var_25 = var_24.mem_0;
                long long int var_26 = (var_25 + 8);
                char var_27 = (var_25 >= 0);
                char var_29;
                if (var_27) {
                    var_29 = (var_25 < 10240);
                } else {
                    var_29 = 0;
                }
                char var_30 = (var_29 == 0);
                if (var_30) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_31 = (var_25 * 10);
                char var_33;
                if (var_16) {
                    var_33 = (var_14 < 10);
                } else {
                    var_33 = 0;
                }
                char var_34 = (var_33 == 0);
                if (var_34) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_35 = (var_31 + var_14);
                char var_37;
                if (var_27) {
                    var_37 = (var_25 < 10240);
                } else {
                    var_37 = 0;
                }
                char var_38 = (var_37 == 0);
                if (var_38) {
                    // "Argument out of bounds."
                } else {
                }
                char var_40;
                if (var_16) {
                    var_40 = (var_14 < 10);
                } else {
                    var_40 = 0;
                }
                char var_41 = (var_40 == 0);
                if (var_41) {
                    // "Argument out of bounds."
                } else {
                }
                float var_42 = var_0[var_14];
                float var_43 = var_1[var_35];
                float var_44 = var_2[var_35];
                float var_45 = (var_42 + var_43);
                var_2[var_35] = var_45;
                var_22[0] = (make_Env0(var_26));
            }
            Env0 var_46 = var_22[0];
            long long int var_47 = var_46.mem_0;
            var_11[0] = (make_Env0(var_15));
        }
        Env0 var_48 = var_11[0];
        long long int var_49 = var_48.mem_0;
    }
    __global__ void method_17(float * var_0, float * var_1) {
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
        while (method_18(var_10)) {
            Env0 var_12 = var_10[0];
            long long int var_13 = var_12.mem_0;
            long long int var_14 = (var_13 + 8192);
            char var_15 = (var_13 >= 0);
            char var_17;
            if (var_15) {
                var_17 = (var_13 < 102400);
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
                var_20 = (var_13 < 102400);
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
            float var_24 = (-var_22);
            float var_25 = exp(var_24);
            float var_26 = (1 + var_25);
            float var_27 = (1 / var_26);
            var_1[var_13] = var_27;
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_28 = var_10[0];
        long long int var_29 = var_28.mem_0;
    }
    __global__ void method_20(float * var_0, float * var_1, float * var_2) {
        long long int var_3 = threadIdx.x;
        long long int var_4 = threadIdx.y;
        long long int var_5 = threadIdx.z;
        long long int var_6 = blockIdx.x;
        long long int var_7 = blockIdx.y;
        long long int var_8 = blockIdx.z;
        long long int var_9 = (var_6 * 128);
        long long int var_10 = (var_9 + var_3);
        float var_11 = 0;
        Env1 var_12[1];
        var_12[0] = (make_Env1(var_10, var_11));
        while (method_21(var_12)) {
            Env1 var_14 = var_12[0];
            long long int var_15 = var_14.mem_0;
            float var_16 = var_14.mem_1;
            long long int var_17 = (var_15 + 8192);
            char var_18 = (var_15 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_15 < 102400);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            float var_22 = var_0[var_15];
            float var_23 = var_1[var_15];
            float var_24 = (var_23 - var_22);
            float var_25 = (var_24 * var_24);
            float var_26 = (var_16 + var_25);
            var_12[0] = (make_Env1(var_17, var_26));
        }
        Env1 var_27 = var_12[0];
        long long int var_28 = var_27.mem_0;
        float var_29 = var_27.mem_1;
        FunPointer2 var_32 = method_22;
        float var_33 = cub::BlockReduce<float,128>().Reduce(var_29, var_32);
        char var_34 = (var_3 == 0);
        if (var_34) {
            char var_35 = (var_6 >= 0);
            char var_37;
            if (var_35) {
                var_37 = (var_6 < 64);
            } else {
                var_37 = 0;
            }
            char var_38 = (var_37 == 0);
            if (var_38) {
                // "Argument out of bounds."
            } else {
            }
            var_2[var_6] = var_33;
        } else {
        }
    }
    __global__ void method_24(float var_0, float var_1, float * var_2, float * var_3, float * var_4) {
        long long int var_5 = threadIdx.x;
        long long int var_6 = threadIdx.y;
        long long int var_7 = threadIdx.z;
        long long int var_8 = blockIdx.x;
        long long int var_9 = blockIdx.y;
        long long int var_10 = blockIdx.z;
        long long int var_11 = (var_8 * 128);
        long long int var_12 = (var_11 + var_5);
        Env0 var_13[1];
        var_13[0] = (make_Env0(var_12));
        while (method_18(var_13)) {
            Env0 var_15 = var_13[0];
            long long int var_16 = var_15.mem_0;
            long long int var_17 = (var_16 + 8192);
            char var_18 = (var_16 >= 0);
            char var_20;
            if (var_18) {
                var_20 = (var_16 < 102400);
            } else {
                var_20 = 0;
            }
            char var_21 = (var_20 == 0);
            if (var_21) {
                // "Argument out of bounds."
            } else {
            }
            char var_23;
            if (var_18) {
                var_23 = (var_16 < 102400);
            } else {
                var_23 = 0;
            }
            char var_24 = (var_23 == 0);
            if (var_24) {
                // "Argument out of bounds."
            } else {
            }
            float var_25 = var_2[var_16];
            float var_26 = var_3[var_16];
            float var_27 = var_4[var_16];
            float var_28 = (var_25 - var_26);
            float var_29 = (2 * var_28);
            float var_30 = (var_0 * var_29);
            float var_31 = (var_27 + var_30);
            var_4[var_16] = var_31;
            var_13[0] = (make_Env0(var_17));
        }
        Env0 var_32 = var_13[0];
        long long int var_33 = var_32.mem_0;
    }
    __global__ void method_25(float * var_0, float * var_1, float * var_2, float * var_3) {
        long long int var_4 = threadIdx.x;
        long long int var_5 = threadIdx.y;
        long long int var_6 = threadIdx.z;
        long long int var_7 = blockIdx.x;
        long long int var_8 = blockIdx.y;
        long long int var_9 = blockIdx.z;
        long long int var_10 = (var_7 * 128);
        long long int var_11 = (var_10 + var_4);
        Env0 var_12[1];
        var_12[0] = (make_Env0(var_11));
        while (method_18(var_12)) {
            Env0 var_14 = var_12[0];
            long long int var_15 = var_14.mem_0;
            long long int var_16 = (var_15 + 8192);
            char var_17 = (var_15 >= 0);
            char var_19;
            if (var_17) {
                var_19 = (var_15 < 102400);
            } else {
                var_19 = 0;
            }
            char var_20 = (var_19 == 0);
            if (var_20) {
                // "Argument out of bounds."
            } else {
            }
            char var_22;
            if (var_17) {
                var_22 = (var_15 < 102400);
            } else {
                var_22 = 0;
            }
            char var_23 = (var_22 == 0);
            if (var_23) {
                // "Argument out of bounds."
            } else {
            }
            float var_24 = var_0[var_15];
            float var_25 = var_1[var_15];
            float var_26 = var_2[var_15];
            float var_27 = var_3[var_15];
            float var_28 = (1 - var_26);
            float var_29 = (var_26 * var_28);
            float var_30 = (var_25 * var_29);
            float var_31 = (var_27 + var_30);
            var_3[var_15] = var_31;
            var_12[0] = (make_Env0(var_16));
        }
        Env0 var_32 = var_12[0];
        long long int var_33 = var_32.mem_0;
    }
    __global__ void method_28(float * var_0, float * var_1) {
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
        while (method_15(var_10)) {
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
            long long int var_22 = (8 * var_6);
            long long int var_23 = (var_3 + var_22);
            float var_24 = 0;
            Env1 var_25[1];
            var_25[0] = (make_Env1(var_23, var_24));
            while (method_29(var_25)) {
                Env1 var_27 = var_25[0];
                long long int var_28 = var_27.mem_0;
                float var_29 = var_27.mem_1;
                long long int var_30 = (var_28 + 8);
                char var_31 = (var_28 >= 0);
                char var_33;
                if (var_31) {
                    var_33 = (var_28 < 10240);
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
                float var_40 = var_0[var_39];
                float var_41 = (var_29 + var_40);
                var_25[0] = (make_Env1(var_30, var_41));
            }
            Env1 var_42 = var_25[0];
            long long int var_43 = var_42.mem_0;
            float var_44 = var_42.mem_1;
            __shared__ float var_45[70];
            char var_46 = (var_2 >= 0);
            char var_48;
            if (var_46) {
                var_48 = (var_2 < 10);
            } else {
                var_48 = 0;
            }
            char var_49 = (var_48 == 0);
            if (var_49) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_50 = (var_2 * 7);
            char var_51 = (var_3 != 0);
            if (var_51) {
                char var_52 = (var_3 >= 1);
                char var_54;
                if (var_52) {
                    var_54 = (var_3 < 8);
                } else {
                    var_54 = 0;
                }
                char var_55 = (var_54 == 0);
                if (var_55) {
                    // "Argument out of bounds."
                } else {
                }
                long long int var_56 = (var_3 - 1);
                long long int var_57 = (var_50 + var_56);
                var_45[var_57] = var_44;
            } else {
            }
            __syncthreads();
            char var_58 = (var_3 == 0);
            if (var_58) {
                Env1 var_59[1];
                var_59[0] = (make_Env1(1, var_44));
                while (method_30(var_59)) {
                    Env1 var_61 = var_59[0];
                    long long int var_62 = var_61.mem_0;
                    float var_63 = var_61.mem_1;
                    long long int var_64 = (var_62 + 1);
                    char var_65 = (var_62 >= 1);
                    char var_67;
                    if (var_65) {
                        var_67 = (var_62 < 8);
                    } else {
                        var_67 = 0;
                    }
                    char var_68 = (var_67 == 0);
                    if (var_68) {
                        // "Argument out of bounds."
                    } else {
                    }
                    long long int var_69 = (var_62 - 1);
                    long long int var_70 = (var_50 + var_69);
                    float var_71 = var_45[var_70];
                    float var_72 = (var_63 + var_71);
                    var_59[0] = (make_Env1(var_64, var_72));
                }
                Env1 var_73 = var_59[0];
                long long int var_74 = var_73.mem_0;
                float var_75 = var_73.mem_1;
                float var_76 = var_1[var_13];
                float var_77 = (var_75 + var_76);
                var_1[var_13] = var_77;
            } else {
            }
            var_10[0] = (make_Env0(var_14));
        }
        Env0 var_78 = var_10[0];
        long long int var_79 = var_78.mem_0;
    }
    __device__ char method_15(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10);
    }
    __device__ char method_16(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 10240);
    }
    __device__ char method_18(Env0 * var_0) {
        Env0 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        return (var_2 < 102400);
    }
    __device__ char method_21(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 102400);
    }
    __device__ float method_22(float var_0, float var_1) {
        return (var_0 + var_1);
    }
    __device__ char method_29(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 10240);
    }
    __device__ char method_30(Env1 * var_0) {
        Env1 var_1 = var_0[0];
        long long int var_2 = var_1.mem_0;
        float var_3 = var_1.mem_1;
        return (var_2 < 8);
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
and Tuple4 =
    struct
    val mem_0: Tuple5
    val mem_1: (uint8 [])
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and Tuple5 =
    struct
    val mem_0: int64
    val mem_1: int64
    val mem_2: int64
    new(arg_mem_0, arg_mem_1, arg_mem_2) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1; mem_2 = arg_mem_2}
    end
and Tuple6 =
    struct
    val mem_0: int64
    val mem_1: (uint8 [])
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
and method_2((var_0: string)): Tuple4 =
    let (var_1: System.IO.FileMode) = System.IO.FileMode.Open
    let (var_2: System.IO.FileAccess) = System.IO.FileAccess.Read
    let (var_3: System.IO.FileShare) = System.IO.FileShare.Read
    let (var_4: System.IO.FileStream) = System.IO.File.Open(var_0, var_1, var_2, var_3)
    let (var_5: System.IO.BinaryReader) = System.IO.BinaryReader(var_4)
    let (var_6: int32) = var_5.ReadInt32()
    let (var_7: int32) = System.Net.IPAddress.NetworkToHostOrder(var_6)
    let (var_8: bool) = (var_7 = 2051)
    let (var_9: bool) = (var_8 = false)
    if var_9 then
        (failwith "Expected a 2051i32 magic number.")
    else
        ()
    let (var_10: int32) = var_5.ReadInt32()
    let (var_11: int32) = System.Net.IPAddress.NetworkToHostOrder(var_10)
    let (var_12: int32) = var_5.ReadInt32()
    let (var_13: int32) = System.Net.IPAddress.NetworkToHostOrder(var_12)
    let (var_14: int32) = var_5.ReadInt32()
    let (var_15: int32) = System.Net.IPAddress.NetworkToHostOrder(var_14)
    let (var_16: int64) = (int64 var_11)
    let (var_17: int64) = (int64 var_13)
    let (var_18: int64) = (int64 var_15)
    let (var_19: int32) = (var_11 * var_13)
    let (var_20: int32) = (var_19 * var_15)
    let (var_22: (uint8 [])) = var_5.ReadBytes(var_20)
    var_5.Dispose()
    var_4.Dispose()
    Tuple4(Tuple5(var_16, var_17, var_18), var_22)
and method_3((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 10000L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_2 * 784L)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = 0L
        method_4((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_3((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_5((var_0: string)): Tuple6 =
    let (var_1: System.IO.FileMode) = System.IO.FileMode.Open
    let (var_2: System.IO.FileAccess) = System.IO.FileAccess.Read
    let (var_3: System.IO.FileShare) = System.IO.FileShare.Read
    let (var_4: System.IO.FileStream) = System.IO.File.Open(var_0, var_1, var_2, var_3)
    let (var_5: System.IO.BinaryReader) = System.IO.BinaryReader(var_4)
    let (var_6: int32) = var_5.ReadInt32()
    let (var_7: int32) = System.Net.IPAddress.NetworkToHostOrder(var_6)
    let (var_8: bool) = (var_7 = 2049)
    let (var_9: bool) = (var_8 = false)
    if var_9 then
        (failwith "Expected a 2049i32 magic number.")
    else
        ()
    let (var_10: int32) = var_5.ReadInt32()
    let (var_11: int32) = System.Net.IPAddress.NetworkToHostOrder(var_10)
    let (var_12: int64) = (int64 var_11)
    let (var_14: (uint8 [])) = var_5.ReadBytes(var_11)
    var_5.Dispose()
    var_4.Dispose()
    Tuple6(var_12, var_14)
and method_6((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 10000L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_2 * 10L)
        let (var_7: uint8) = var_0.[int32 var_2]
        let (var_8: int64) = 0L
        method_7((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_6((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_8((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 60000L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_2 * 784L)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = 0L
        method_4((var_0: (uint8 [])), (var_6: int64), (var_1: (float32 [])), (var_7: int64))
        let (var_8: int64) = (var_2 + 1L)
        method_8((var_0: (uint8 [])), (var_1: (float32 [])), (var_8: int64))
    else
        ()
and method_9((var_0: (uint8 [])), (var_1: (float32 [])), (var_2: int64)): unit =
    let (var_3: bool) = (var_2 < 60000L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = (var_2 * 10L)
        let (var_7: uint8) = var_0.[int32 var_2]
        let (var_8: int64) = 0L
        method_7((var_7: uint8), (var_1: (float32 [])), (var_6: int64), (var_8: int64))
        let (var_9: int64) = (var_2 + 1L)
        method_9((var_0: (uint8 [])), (var_1: (float32 [])), (var_9: int64))
    else
        ()
and method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64)): EnvStack2 =
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
            method_11((var_12: ManagedCuda.BasicTypes.CUdeviceptr), (var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: int64))
        | Union0Case1 ->
            let (var_14: Env3) = var_1.Pop()
            let (var_15: EnvStack2) = var_14.mem_0
            let (var_16: int64) = var_14.mem_1
            method_10((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env3>), (var_2: uint64), (var_3: int64))
    else
        method_12((var_0: uint64), (var_2: uint64), (var_3: int64), (var_1: System.Collections.Generic.Stack<Env3>))
and method_13((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: EnvStack2), (var_3: EnvStack2)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: (Union0 ref)) = var_1.mem_0
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_7: (Union0 ref)))
    let (var_9: (Union0 ref)) = var_2.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: (float32 ref)) = (ref 0.000000f)
    let (var_12: (Union0 ref)) = var_3.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_12: (Union0 ref)))
    let (var_14: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 10240, 10, 784, var_6, var_8, 10240, var_10, 784, var_11, var_13, 10240)
    if var_14 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_14)
and method_19((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: EnvStack2), (var_3: EnvStack2)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: (Union0 ref)) = var_1.mem_0
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_7: (Union0 ref)))
    let (var_9: (Union0 ref)) = var_2.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: (float32 ref)) = (ref 0.000000f)
    let (var_12: (Union0 ref)) = var_3.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_12: (Union0 ref)))
    let (var_14: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 10240, 10, 10, var_6, var_8, 10240, var_10, 10, var_11, var_13, 10240)
    if var_14 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_14)
and method_23((var_0: (float32 [])), (var_1: float32), (var_2: int64)): float32 =
    let (var_3: bool) = (var_2 < 64L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: float32) = var_0.[int32 var_2]
        let (var_7: float32) = (var_1 + var_6)
        let (var_8: int64) = (var_2 + 1L)
        method_23((var_0: (float32 [])), (var_7: float32), (var_8: int64))
    else
        var_1
and method_26((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: EnvStack2), (var_3: EnvStack2)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: (Union0 ref)) = var_1.mem_0
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_7: (Union0 ref)))
    let (var_9: (Union0 ref)) = var_2.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: (float32 ref)) = (ref 1.000000f)
    let (var_12: (Union0 ref)) = var_3.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_12: (Union0 ref)))
    let (var_14: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 10240, 10, 10, var_6, var_8, 10240, var_10, 10, var_11, var_13, 10240)
    if var_14 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_14)
and method_27((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: EnvStack2), (var_3: EnvStack2)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: (Union0 ref)) = var_1.mem_0
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_7: (Union0 ref)))
    let (var_9: (Union0 ref)) = var_2.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: (float32 ref)) = (ref 1.000000f)
    let (var_12: (Union0 ref)) = var_3.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_12: (Union0 ref)))
    let (var_14: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 10, 10, 10240, var_6, var_8, 10240, var_10, 10240, var_11, var_13, 10)
    if var_14 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_14)
and method_31((var_0: ManagedCuda.CudaBlas.CudaBlasHandle), (var_1: EnvStack2), (var_2: EnvStack2), (var_3: EnvStack2)): unit =
    let (var_4: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.Transpose
    let (var_5: ManagedCuda.CudaBlas.Operation) = ManagedCuda.CudaBlas.Operation.NonTranspose
    let (var_6: (float32 ref)) = (ref 1.000000f)
    let (var_7: (Union0 ref)) = var_1.mem_0
    let (var_8: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_7: (Union0 ref)))
    let (var_9: (Union0 ref)) = var_2.mem_0
    let (var_10: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_9: (Union0 ref)))
    let (var_11: (float32 ref)) = (ref 1.000000f)
    let (var_12: (Union0 ref)) = var_3.mem_0
    let (var_13: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_12: (Union0 ref)))
    let (var_14: ManagedCuda.CudaBlas.CublasStatus) = ManagedCuda.CudaBlas.CudaBlasNativeMethods.cublasSgemm_v2(var_0, var_4, var_5, 784, 10, 10240, var_6, var_8, 10240, var_10, 10240, var_11, var_13, 784)
    if var_14 <> ManagedCuda.CudaBlas.CublasStatus.Success then raise <| new ManagedCuda.CudaBlas.CudaBlasException(var_14)
and method_32((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: int64)): unit =
    let (var_18: bool) = (var_17 < 784L)
    if var_18 then
        let (var_19: bool) = (var_17 >= 0L)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_21: int64) = (var_17 * 10L)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = 0L
        method_33((var_0: EnvStack2), (var_21: int64), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_22: int64))
        let (var_23: int64) = (var_17 + 1L)
        method_32((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_23: int64))
    else
        ()
and method_35((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: int64)): unit =
    let (var_18: bool) = (var_17 < 10L)
    if var_18 then
        let (var_19: bool) = (var_17 >= 0L)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_21: (Union0 ref)) = var_12.mem_0
        let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_21: (Union0 ref)))
        let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_24: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_22, false, var_23)
        let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        let (var_26: float32) = var_24.[var_25]
        let (var_27: float32) = (var_26 + 0.001000f)
        let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        var_24.[var_28] <- var_27
        let (var_29: float32) = method_34((var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_0: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2))
        let (var_30: float32) = (var_26 - 0.001000f)
        let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        var_24.[var_31] <- var_30
        let (var_32: float32) = method_34((var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_0: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2))
        let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        var_24.[var_33] <- var_26
        let (var_34: float32) = (var_29 - var_32)
        let (var_35: float32) = (var_34 / 0.002000f)
        let (var_36: (Union0 ref)) = var_0.mem_0
        let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_36: (Union0 ref)))
        let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_39: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_37, false, var_38)
        let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        let (var_41: float32) = var_39.[var_40]
        let (var_42: float32) = (var_41 - var_35)
        let (var_43: float32) = (-var_42)
        let (var_44: bool) = (var_43 < var_42)
        let (var_45: float32) =
            if var_44 then
                var_42
            else
                var_43
        let (var_46: bool) = (var_45 >= 0.001000f)
        if var_46 then
            let (var_47: string) = System.String.Format("{0}",var_41)
            let (var_48: string) = System.String.Format("{0} = {1}","true_gradient",var_47)
            let (var_49: string) = System.String.Format("{0}",var_45)
            let (var_50: string) = System.String.Format("{0} = {1}","diff",var_49)
            let (var_51: string) = System.String.Format("{0}",var_35)
            let (var_52: string) = System.String.Format("{0} = {1}","approx_gradient",var_51)
            let (var_53: string) = String.concat "; " [|var_52; var_50; var_48|]
            let (var_54: string) = System.String.Format("{0}{1}{2}","{",var_53,"}")
            System.Console.WriteLine(var_54)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_55: int64) = (var_17 + 1L)
        method_35((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_55: int64))
    else
        ()
and method_36((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: int64)): unit =
    let (var_18: bool) = (var_17 < 10L)
    if var_18 then
        let (var_19: bool) = (var_17 >= 0L)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_21: int64) = (var_17 * 10L)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = 0L
        method_37((var_0: EnvStack2), (var_21: int64), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_22: int64))
        let (var_23: int64) = (var_17 + 1L)
        method_36((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: EnvStack2), (var_9: ManagedCuda.CudaBlas.CudaBlasHandle), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_23: int64))
    else
        ()
and method_38((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: int64)): unit =
    let (var_18: bool) = (var_17 < 10L)
    if var_18 then
        let (var_19: bool) = (var_17 >= 0L)
        let (var_20: bool) = (var_19 = false)
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        if var_20 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_21: (Union0 ref)) = var_7.mem_0
        let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_21: (Union0 ref)))
        let (var_23: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_24: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_22, false, var_23)
        let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        let (var_26: float32) = var_24.[var_25]
        let (var_27: float32) = (var_26 + 0.001000f)
        let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        var_24.[var_28] <- var_27
        let (var_29: float32) = method_34((var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_0: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2))
        let (var_30: float32) = (var_26 - 0.001000f)
        let (var_31: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        var_24.[var_31] <- var_30
        let (var_32: float32) = method_34((var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_0: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2))
        let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        var_24.[var_33] <- var_26
        let (var_34: float32) = (var_29 - var_32)
        let (var_35: float32) = (var_34 / 0.002000f)
        let (var_36: (Union0 ref)) = var_0.mem_0
        let (var_37: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_36: (Union0 ref)))
        let (var_38: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_39: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_37, false, var_38)
        let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_17)
        let (var_41: float32) = var_39.[var_40]
        let (var_42: float32) = (var_41 - var_35)
        let (var_43: float32) = (-var_42)
        let (var_44: bool) = (var_43 < var_42)
        let (var_45: float32) =
            if var_44 then
                var_42
            else
                var_43
        let (var_46: bool) = (var_45 >= 0.001000f)
        if var_46 then
            let (var_47: string) = System.String.Format("{0}",var_41)
            let (var_48: string) = System.String.Format("{0} = {1}","true_gradient",var_47)
            let (var_49: string) = System.String.Format("{0}",var_45)
            let (var_50: string) = System.String.Format("{0} = {1}","diff",var_49)
            let (var_51: string) = System.String.Format("{0}",var_35)
            let (var_52: string) = System.String.Format("{0} = {1}","approx_gradient",var_51)
            let (var_53: string) = String.concat "; " [|var_52; var_50; var_48|]
            let (var_54: string) = System.String.Format("{0}{1}{2}","{",var_53,"}")
            System.Console.WriteLine(var_54)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_55: int64) = (var_17 + 1L)
        method_38((var_0: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_2: ManagedCuda.BasicTypes.CUmodule), (var_3: ManagedCuda.CudaStream), (var_4: uint64), (var_5: uint64), (var_6: System.Collections.Generic.Stack<Env3>), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_55: int64))
    else
        ()
and method_4((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_3: int64)): unit =
    let (var_4: bool) = (var_3 < 784L)
    if var_4 then
        let (var_5: bool) = (var_3 >= 0L)
        let (var_6: bool) = (var_5 = false)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_7: int64) = (var_1 + var_3)
        if var_6 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_8: uint8) = var_0.[int32 var_7]
        let (var_9: float32) = (float32 var_8)
        let (var_10: float32) = (var_9 / 255.000000f)
        var_2.[int32 var_7] <- var_10
        let (var_11: int64) = (var_3 + 1L)
        method_4((var_0: (uint8 [])), (var_1: int64), (var_2: (float32 [])), (var_11: int64))
    else
        ()
and method_7((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_3: int64)): unit =
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
        method_7((var_0: uint8), (var_1: (float32 [])), (var_2: int64), (var_11: int64))
    else
        ()
and method_11((var_0: ManagedCuda.BasicTypes.CUdeviceptr), (var_1: uint64), (var_2: uint64), (var_3: int64), (var_4: System.Collections.Generic.Stack<Env3>), (var_5: EnvStack2), (var_6: int64)): EnvStack2 =
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
and method_12((var_0: uint64), (var_1: uint64), (var_2: int64), (var_3: System.Collections.Generic.Stack<Env3>)): EnvStack2 =
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
and method_33((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2), (var_18: int64)): unit =
    let (var_19: bool) = (var_18 < 10L)
    if var_19 then
        let (var_20: bool) = (var_18 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = (var_1 + var_18)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_23: (Union0 ref)) = var_15.mem_0
        let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_23: (Union0 ref)))
        let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_26: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_24, false, var_25)
        let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        let (var_28: float32) = var_26.[var_27]
        let (var_29: float32) = (var_28 + 0.001000f)
        let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        var_26.[var_30] <- var_29
        let (var_31: float32) = method_34((var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_0: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2))
        let (var_32: float32) = (var_28 - 0.001000f)
        let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        var_26.[var_33] <- var_32
        let (var_34: float32) = method_34((var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_0: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2))
        let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        var_26.[var_35] <- var_28
        let (var_36: float32) = (var_31 - var_34)
        let (var_37: float32) = (var_36 / 0.002000f)
        let (var_38: (Union0 ref)) = var_0.mem_0
        let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_38: (Union0 ref)))
        let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_41: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_39, false, var_40)
        let (var_42: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        let (var_43: float32) = var_41.[var_42]
        let (var_44: float32) = (var_43 - var_37)
        let (var_45: float32) = (-var_44)
        let (var_46: bool) = (var_45 < var_44)
        let (var_47: float32) =
            if var_46 then
                var_44
            else
                var_45
        let (var_48: bool) = (var_47 >= 0.001000f)
        if var_48 then
            let (var_49: string) = System.String.Format("{0}",var_43)
            let (var_50: string) = System.String.Format("{0} = {1}","true_gradient",var_49)
            let (var_51: string) = System.String.Format("{0}",var_47)
            let (var_52: string) = System.String.Format("{0} = {1}","diff",var_51)
            let (var_53: string) = System.String.Format("{0}",var_37)
            let (var_54: string) = System.String.Format("{0} = {1}","approx_gradient",var_53)
            let (var_55: string) = String.concat "; " [|var_54; var_52; var_50|]
            let (var_56: string) = System.String.Format("{0}{1}{2}","{",var_55,"}")
            System.Console.WriteLine(var_56)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_57: int64) = (var_18 + 1L)
        method_33((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2), (var_57: int64))
    else
        ()
and method_34((var_0: ManagedCuda.CudaContext), (var_1: ManagedCuda.BasicTypes.CUmodule), (var_2: ManagedCuda.CudaStream), (var_3: uint64), (var_4: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_6: EnvStack2), (var_7: EnvStack2), (var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_9: EnvStack2), (var_10: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2)): float32 =
    let (var_17: int64) = 409600L
    let (var_18: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_17: int64))
    method_13((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_15: EnvStack2), (var_14: EnvStack2), (var_18: EnvStack2))
    let (var_19: int64) = 409600L
    let (var_20: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_19: int64))
    let (var_21: (Union0 ref)) = var_20.mem_0
    let (var_22: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_21: (Union0 ref)))
    let (var_23: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
    var_0.ClearMemoryAsync(var_22, 0uy, var_24, var_23)
    let (var_25: (Union0 ref)) = var_12.mem_0
    let (var_26: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_25: (Union0 ref)))
    let (var_27: (Union0 ref)) = var_18.mem_0
    let (var_28: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_27: (Union0 ref)))
    let (var_29: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_27: (Union0 ref)))
    // Cuda join point
    // method_14((var_26: ManagedCuda.BasicTypes.CUdeviceptr), (var_28: ManagedCuda.BasicTypes.CUdeviceptr), (var_29: ManagedCuda.BasicTypes.CUdeviceptr))
    let (var_31: (System.Object [])) = [|var_26; var_28; var_29|]: (System.Object [])
    let (var_32: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_1, var_0)
    let (var_33: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_32.set_GridDimensions(var_33)
    let (var_34: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
    var_32.set_BlockDimensions(var_34)
    let (var_35: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    var_32.RunAsync(var_35, var_31)
    let (var_40: int64) = 409600L
    let (var_41: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_40: int64))
    let (var_42: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_27: (Union0 ref)))
    let (var_43: (Union0 ref)) = var_41.mem_0
    let (var_44: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_43: (Union0 ref)))
    // Cuda join point
    // method_17((var_42: ManagedCuda.BasicTypes.CUdeviceptr), (var_44: ManagedCuda.BasicTypes.CUdeviceptr))
    let (var_46: (System.Object [])) = [|var_42; var_44|]: (System.Object [])
    let (var_47: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
    let (var_48: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_47.set_GridDimensions(var_48)
    let (var_49: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_47.set_BlockDimensions(var_49)
    let (var_50: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    var_47.RunAsync(var_50, var_46)
    let (var_51: int64) = 409600L
    let (var_52: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_51: int64))
    let (var_53: (Union0 ref)) = var_52.mem_0
    let (var_54: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_53: (Union0 ref)))
    let (var_55: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_56: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
    var_0.ClearMemoryAsync(var_54, 0uy, var_56, var_55)
    let (var_57: int64) = 409600L
    let (var_58: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_57: int64))
    method_19((var_8: ManagedCuda.CudaBlas.CudaBlasHandle), (var_41: EnvStack2), (var_10: EnvStack2), (var_58: EnvStack2))
    let (var_59: int64) = 409600L
    let (var_60: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_59: int64))
    let (var_61: (Union0 ref)) = var_60.mem_0
    let (var_62: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_61: (Union0 ref)))
    let (var_63: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_64: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
    var_0.ClearMemoryAsync(var_62, 0uy, var_64, var_63)
    let (var_65: (Union0 ref)) = var_7.mem_0
    let (var_66: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_65: (Union0 ref)))
    let (var_67: (Union0 ref)) = var_58.mem_0
    let (var_68: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
    let (var_69: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
    // Cuda join point
    // method_14((var_66: ManagedCuda.BasicTypes.CUdeviceptr), (var_68: ManagedCuda.BasicTypes.CUdeviceptr), (var_69: ManagedCuda.BasicTypes.CUdeviceptr))
    let (var_71: (System.Object [])) = [|var_66; var_68; var_69|]: (System.Object [])
    let (var_72: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_1, var_0)
    let (var_73: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
    var_72.set_GridDimensions(var_73)
    let (var_74: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
    var_72.set_BlockDimensions(var_74)
    let (var_75: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    var_72.RunAsync(var_75, var_71)
    let (var_80: int64) = 409600L
    let (var_81: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_80: int64))
    let (var_82: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_67: (Union0 ref)))
    let (var_83: (Union0 ref)) = var_81.mem_0
    let (var_84: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
    // Cuda join point
    // method_17((var_82: ManagedCuda.BasicTypes.CUdeviceptr), (var_84: ManagedCuda.BasicTypes.CUdeviceptr))
    let (var_86: (System.Object [])) = [|var_82; var_84|]: (System.Object [])
    let (var_87: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_1, var_0)
    let (var_88: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_87.set_GridDimensions(var_88)
    let (var_89: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_87.set_BlockDimensions(var_89)
    let (var_90: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    var_87.RunAsync(var_90, var_86)
    let (var_91: int64) = 409600L
    let (var_92: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_91: int64))
    let (var_93: (Union0 ref)) = var_92.mem_0
    let (var_94: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_93: (Union0 ref)))
    let (var_95: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    let (var_96: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
    var_0.ClearMemoryAsync(var_94, 0uy, var_96, var_95)
    let (var_97: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_83: (Union0 ref)))
    let (var_98: (Union0 ref)) = var_16.mem_0
    let (var_99: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_98: (Union0 ref)))
    let (var_102: int64) = 256L
    let (var_103: EnvStack2) = method_10((var_3: uint64), (var_5: System.Collections.Generic.Stack<Env3>), (var_4: uint64), (var_102: int64))
    let (var_104: (Union0 ref)) = var_103.mem_0
    let (var_105: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_104: (Union0 ref)))
    // Cuda join point
    // method_20((var_97: ManagedCuda.BasicTypes.CUdeviceptr), (var_99: ManagedCuda.BasicTypes.CUdeviceptr), (var_105: ManagedCuda.BasicTypes.CUdeviceptr))
    let (var_107: (System.Object [])) = [|var_97; var_99; var_105|]: (System.Object [])
    let (var_108: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_1, var_0)
    let (var_109: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
    var_108.set_GridDimensions(var_109)
    let (var_110: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
    var_108.set_BlockDimensions(var_110)
    let (var_111: ManagedCuda.BasicTypes.CUstream) = var_2.get_Stream()
    var_108.RunAsync(var_111, var_107)
    let (var_112: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_104: (Union0 ref)))
    let (var_113: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(64L))
    var_0.CopyToHost(var_113, var_112)
    var_0.Synchronize()
    let (var_114: float32) = 0.000000f
    let (var_115: int64) = 0L
    let (var_116: float32) = method_23((var_113: (float32 [])), (var_114: float32), (var_115: int64))
    var_104 := Union0Case1
    let (var_117: (float32 ref)) = (ref 0.000000f)
    let (var_118: float32) = (var_116 / 10240.000000f)
    let (var_119: (float32 ref)) = (ref 0.000000f)
    var_93 := Union0Case1
    var_83 := Union0Case1
    var_61 := Union0Case1
    var_67 := Union0Case1
    var_53 := Union0Case1
    var_43 := Union0Case1
    var_21 := Union0Case1
    var_27 := Union0Case1
    var_118
and method_37((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2), (var_18: int64)): unit =
    let (var_19: bool) = (var_18 < 10L)
    if var_19 then
        let (var_20: bool) = (var_18 >= 0L)
        let (var_21: bool) = (var_20 = false)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_22: int64) = (var_1 + var_18)
        if var_21 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_23: (Union0 ref)) = var_11.mem_0
        let (var_24: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_23: (Union0 ref)))
        let (var_25: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_26: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_24, false, var_25)
        let (var_27: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        let (var_28: float32) = var_26.[var_27]
        let (var_29: float32) = (var_28 + 0.001000f)
        let (var_30: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        var_26.[var_30] <- var_29
        let (var_31: float32) = method_34((var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_0: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2))
        let (var_32: float32) = (var_28 - 0.001000f)
        let (var_33: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        var_26.[var_33] <- var_32
        let (var_34: float32) = method_34((var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_0: EnvStack2), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2))
        let (var_35: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        var_26.[var_35] <- var_28
        let (var_36: float32) = (var_31 - var_34)
        let (var_37: float32) = (var_36 / 0.002000f)
        let (var_38: (Union0 ref)) = var_0.mem_0
        let (var_39: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_38: (Union0 ref)))
        let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(4L)
        let (var_41: ManagedCuda.CudaDeviceVariable<float32>) = ManagedCuda.CudaDeviceVariable<float32>(var_39, false, var_40)
        let (var_42: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_22)
        let (var_43: float32) = var_41.[var_42]
        let (var_44: float32) = (var_43 - var_37)
        let (var_45: float32) = (-var_44)
        let (var_46: bool) = (var_45 < var_44)
        let (var_47: float32) =
            if var_46 then
                var_44
            else
                var_45
        let (var_48: bool) = (var_47 >= 0.001000f)
        if var_48 then
            let (var_49: string) = System.String.Format("{0}",var_43)
            let (var_50: string) = System.String.Format("{0} = {1}","true_gradient",var_49)
            let (var_51: string) = System.String.Format("{0}",var_47)
            let (var_52: string) = System.String.Format("{0} = {1}","diff",var_51)
            let (var_53: string) = System.String.Format("{0}",var_37)
            let (var_54: string) = System.String.Format("{0} = {1}","approx_gradient",var_53)
            let (var_55: string) = String.concat "; " [|var_54; var_52; var_50|]
            let (var_56: string) = System.String.Format("{0}{1}{2}","{",var_55,"}")
            System.Console.WriteLine(var_56)
            System.Console.WriteLine("--- Gradient checking failure.")
        else
            ()
        let (var_57: int64) = (var_18 + 1L)
        method_37((var_0: EnvStack2), (var_1: int64), (var_2: ManagedCuda.CudaContext), (var_3: ManagedCuda.BasicTypes.CUmodule), (var_4: ManagedCuda.CudaStream), (var_5: uint64), (var_6: uint64), (var_7: System.Collections.Generic.Stack<Env3>), (var_8: EnvStack2), (var_9: EnvStack2), (var_10: ManagedCuda.CudaBlas.CudaBlasHandle), (var_11: EnvStack2), (var_12: EnvStack2), (var_13: EnvStack2), (var_14: EnvStack2), (var_15: EnvStack2), (var_16: EnvStack2), (var_17: EnvStack2), (var_57: int64))
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
let (var_60: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-images.idx3-ubyte")
let (var_61: Tuple4) = method_2((var_60: string))
let (var_62: Tuple5) = var_61.mem_0
let (var_63: (uint8 [])) = var_61.mem_1
let (var_64: int64) = var_62.mem_0
let (var_65: int64) = var_62.mem_1
let (var_66: int64) = var_62.mem_2
let (var_67: bool) = (10000L = var_64)
let (var_71: bool) =
    if var_67 then
        let (var_68: bool) = (28L = var_65)
        if var_68 then
            (28L = var_66)
        else
            false
    else
        false
let (var_72: bool) = (var_71 = false)
if var_72 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_73: int64) = var_63.LongLength
let (var_74: bool) = (var_73 > 0L)
let (var_75: bool) = (var_74 = false)
if var_75 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_76: bool) = (7840000L = var_73)
let (var_77: bool) = (var_76 = false)
if var_77 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_81: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(7840000L))
let (var_82: int64) = 0L
method_3((var_63: (uint8 [])), (var_81: (float32 [])), (var_82: int64))
let (var_83: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "t10k-labels.idx1-ubyte")
let (var_84: Tuple6) = method_5((var_83: string))
let (var_85: int64) = var_84.mem_0
let (var_86: (uint8 [])) = var_84.mem_1
let (var_87: bool) = (10000L = var_85)
let (var_88: bool) = (var_87 = false)
if var_88 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_92: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(100000L))
let (var_93: int64) = 0L
method_6((var_86: (uint8 [])), (var_92: (float32 [])), (var_93: int64))
let (var_94: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-images.idx3-ubyte")
let (var_95: Tuple4) = method_2((var_94: string))
let (var_96: Tuple5) = var_95.mem_0
let (var_97: (uint8 [])) = var_95.mem_1
let (var_98: int64) = var_96.mem_0
let (var_99: int64) = var_96.mem_1
let (var_100: int64) = var_96.mem_2
let (var_101: bool) = (60000L = var_98)
let (var_105: bool) =
    if var_101 then
        let (var_102: bool) = (28L = var_99)
        if var_102 then
            (28L = var_100)
        else
            false
    else
        false
let (var_106: bool) = (var_105 = false)
if var_106 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_107: int64) = var_97.LongLength
let (var_108: bool) = (var_107 > 0L)
let (var_109: bool) = (var_108 = false)
if var_109 then
    (failwith "Tensor needs to be at least size 1.")
else
    ()
let (var_110: bool) = (47040000L = var_107)
let (var_111: bool) = (var_110 = false)
if var_111 then
    (failwith "The product of given dimensions does not match the product of tensor dimensions.")
else
    ()
let (var_115: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(47040000L))
let (var_116: int64) = 0L
method_8((var_97: (uint8 [])), (var_115: (float32 [])), (var_116: int64))
let (var_117: string) = System.IO.Path.Combine("C:\\ML Datasets\\Mnist", "train-labels.idx1-ubyte")
let (var_118: Tuple6) = method_5((var_117: string))
let (var_119: int64) = var_118.mem_0
let (var_120: (uint8 [])) = var_118.mem_1
let (var_121: bool) = (60000L = var_119)
let (var_122: bool) = (var_121 = false)
if var_122 then
    (failwith "Mnist dimensions do not match the expected values.")
else
    ()
let (var_126: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(600000L))
let (var_127: int64) = 0L
method_9((var_120: (uint8 [])), (var_126: (float32 [])), (var_127: int64))
let (var_128: int64) = var_81.LongLength
let (var_129: int64) = (var_128 * 4L)
let (var_130: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_129: int64))
let (var_131: (Union0 ref)) = var_130.mem_0
let (var_132: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_131: (Union0 ref)))
var_1.CopyToDevice(var_132, var_81)
let (var_133: int64) = var_92.LongLength
let (var_134: int64) = (var_133 * 4L)
let (var_135: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_134: int64))
let (var_136: (Union0 ref)) = var_135.mem_0
let (var_137: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_136: (Union0 ref)))
var_1.CopyToDevice(var_137, var_92)
let (var_138: int64) = var_115.LongLength
let (var_139: int64) = (var_138 * 4L)
let (var_140: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_139: int64))
let (var_141: (Union0 ref)) = var_140.mem_0
let (var_142: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_141: (Union0 ref)))
var_1.CopyToDevice(var_142, var_115)
let (var_143: int64) = var_126.LongLength
let (var_144: int64) = (var_143 * 4L)
let (var_145: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_144: int64))
let (var_146: (Union0 ref)) = var_145.mem_0
let (var_147: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_146: (Union0 ref)))
var_1.CopyToDevice(var_147, var_126)
let (var_148: int64) = 31360L
let (var_149: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_148: int64))
let (var_150: (Union0 ref)) = var_149.mem_0
let (var_151: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_150: (Union0 ref)))
let (var_152: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(7840L)
var_53.GenerateNormal32(var_151, var_152, 0.000000f, 0.050189f)
let (var_153: int64) = 31360L
let (var_154: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_153: int64))
let (var_155: (Union0 ref)) = var_154.mem_0
let (var_156: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_155: (Union0 ref)))
let (var_157: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_158: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(31360L)
var_1.ClearMemoryAsync(var_156, 0uy, var_158, var_157)
let (var_159: int64) = 40L
let (var_160: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_159: int64))
let (var_161: (Union0 ref)) = var_160.mem_0
let (var_162: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
let (var_163: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_164: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_162, 0uy, var_164, var_163)
let (var_165: int64) = 40L
let (var_166: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_165: int64))
let (var_167: (Union0 ref)) = var_166.mem_0
let (var_168: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_167: (Union0 ref)))
let (var_169: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_170: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_168, 0uy, var_170, var_169)
let (var_171: int64) = 400L
let (var_172: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_171: int64))
let (var_173: (Union0 ref)) = var_172.mem_0
let (var_174: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_173: (Union0 ref)))
let (var_175: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(100L)
var_53.GenerateNormal32(var_174, var_175, 0.000000f, 0.316228f)
let (var_176: int64) = 400L
let (var_177: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_176: int64))
let (var_178: (Union0 ref)) = var_177.mem_0
let (var_179: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_178: (Union0 ref)))
let (var_180: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_181: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(400L)
var_1.ClearMemoryAsync(var_179, 0uy, var_181, var_180)
let (var_182: int64) = 40L
let (var_183: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_182: int64))
let (var_184: (Union0 ref)) = var_183.mem_0
let (var_185: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_184: (Union0 ref)))
let (var_186: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_187: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_185, 0uy, var_187, var_186)
let (var_188: int64) = 40L
let (var_189: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_188: int64))
let (var_190: (Union0 ref)) = var_189.mem_0
let (var_191: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_190: (Union0 ref)))
let (var_192: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_193: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(40L)
var_1.ClearMemoryAsync(var_191, 0uy, var_193, var_192)
let (var_194: int64) = 409600L
let (var_195: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_194: int64))
method_13((var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_140: EnvStack2), (var_149: EnvStack2), (var_195: EnvStack2))
let (var_196: int64) = 409600L
let (var_197: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_196: int64))
let (var_198: (Union0 ref)) = var_197.mem_0
let (var_199: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_198: (Union0 ref)))
let (var_200: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_201: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
var_1.ClearMemoryAsync(var_199, 0uy, var_201, var_200)
let (var_202: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_161: (Union0 ref)))
let (var_203: (Union0 ref)) = var_195.mem_0
let (var_204: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_203: (Union0 ref)))
let (var_205: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_203: (Union0 ref)))
// Cuda join point
// method_14((var_202: ManagedCuda.BasicTypes.CUdeviceptr), (var_204: ManagedCuda.BasicTypes.CUdeviceptr), (var_205: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_207: (System.Object [])) = [|var_202; var_204; var_205|]: (System.Object [])
let (var_208: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_32, var_1)
let (var_209: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_208.set_GridDimensions(var_209)
let (var_210: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
var_208.set_BlockDimensions(var_210)
let (var_211: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_208.RunAsync(var_211, var_207)
let (var_216: int64) = 409600L
let (var_217: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_216: int64))
let (var_218: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_203: (Union0 ref)))
let (var_219: (Union0 ref)) = var_217.mem_0
let (var_220: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_219: (Union0 ref)))
// Cuda join point
// method_17((var_218: ManagedCuda.BasicTypes.CUdeviceptr), (var_220: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_222: (System.Object [])) = [|var_218; var_220|]: (System.Object [])
let (var_223: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_32, var_1)
let (var_224: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
var_223.set_GridDimensions(var_224)
let (var_225: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_223.set_BlockDimensions(var_225)
let (var_226: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_223.RunAsync(var_226, var_222)
let (var_227: int64) = 409600L
let (var_228: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_227: int64))
let (var_229: (Union0 ref)) = var_228.mem_0
let (var_230: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_229: (Union0 ref)))
let (var_231: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_232: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
var_1.ClearMemoryAsync(var_230, 0uy, var_232, var_231)
let (var_233: int64) = 409600L
let (var_234: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_233: int64))
method_19((var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_217: EnvStack2), (var_172: EnvStack2), (var_234: EnvStack2))
let (var_235: int64) = 409600L
let (var_236: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_235: int64))
let (var_237: (Union0 ref)) = var_236.mem_0
let (var_238: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_237: (Union0 ref)))
let (var_239: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_240: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
var_1.ClearMemoryAsync(var_238, 0uy, var_240, var_239)
let (var_241: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_184: (Union0 ref)))
let (var_242: (Union0 ref)) = var_234.mem_0
let (var_243: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_242: (Union0 ref)))
let (var_244: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_242: (Union0 ref)))
// Cuda join point
// method_14((var_241: ManagedCuda.BasicTypes.CUdeviceptr), (var_243: ManagedCuda.BasicTypes.CUdeviceptr), (var_244: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_246: (System.Object [])) = [|var_241; var_243; var_244|]: (System.Object [])
let (var_247: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_14", var_32, var_1)
let (var_248: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_247.set_GridDimensions(var_248)
let (var_249: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
var_247.set_BlockDimensions(var_249)
let (var_250: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_247.RunAsync(var_250, var_246)
let (var_255: int64) = 409600L
let (var_256: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_255: int64))
let (var_257: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_242: (Union0 ref)))
let (var_258: (Union0 ref)) = var_256.mem_0
let (var_259: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_258: (Union0 ref)))
// Cuda join point
// method_17((var_257: ManagedCuda.BasicTypes.CUdeviceptr), (var_259: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_261: (System.Object [])) = [|var_257; var_259|]: (System.Object [])
let (var_262: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_17", var_32, var_1)
let (var_263: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
var_262.set_GridDimensions(var_263)
let (var_264: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_262.set_BlockDimensions(var_264)
let (var_265: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_262.RunAsync(var_265, var_261)
let (var_266: int64) = 409600L
let (var_267: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_266: int64))
let (var_268: (Union0 ref)) = var_267.mem_0
let (var_269: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_268: (Union0 ref)))
let (var_270: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
let (var_271: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(409600L)
var_1.ClearMemoryAsync(var_269, 0uy, var_271, var_270)
let (var_272: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_258: (Union0 ref)))
let (var_273: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_146: (Union0 ref)))
let (var_276: int64) = 256L
let (var_277: EnvStack2) = method_10((var_49: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_50: uint64), (var_276: int64))
let (var_278: (Union0 ref)) = var_277.mem_0
let (var_279: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_278: (Union0 ref)))
// Cuda join point
// method_20((var_272: ManagedCuda.BasicTypes.CUdeviceptr), (var_273: ManagedCuda.BasicTypes.CUdeviceptr), (var_279: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_281: (System.Object [])) = [|var_272; var_273; var_279|]: (System.Object [])
let (var_282: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_20", var_32, var_1)
let (var_283: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
var_282.set_GridDimensions(var_283)
let (var_284: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_282.set_BlockDimensions(var_284)
let (var_285: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_282.RunAsync(var_285, var_281)
let (var_286: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_278: (Union0 ref)))
let (var_287: (float32 [])) = Array.zeroCreate<float32> (System.Convert.ToInt32(64L))
var_1.CopyToHost(var_287, var_286)
var_1.Synchronize()
let (var_288: float32) = 0.000000f
let (var_289: int64) = 0L
let (var_290: float32) = method_23((var_287: (float32 [])), (var_288: float32), (var_289: int64))
var_278 := Union0Case1
let (var_291: (float32 ref)) = (ref 0.000000f)
let (var_292: float32) = (var_290 / 10240.000000f)
let (var_293: (float32 ref)) = (ref 0.000000f)
var_293 := 1.000000f
let (var_294: float32) = (!var_293)
let (var_295: float32) = (var_294 / 10240.000000f)
let (var_296: float32) = (!var_291)
let (var_297: float32) = (var_296 + var_295)
var_291 := var_297
let (var_298: float32) = (!var_291)
let (var_299: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_258: (Union0 ref)))
let (var_300: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_146: (Union0 ref)))
let (var_301: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_268: (Union0 ref)))
// Cuda join point
// method_24((var_298: float32), (var_290: float32), (var_299: ManagedCuda.BasicTypes.CUdeviceptr), (var_300: ManagedCuda.BasicTypes.CUdeviceptr), (var_301: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_303: (System.Object [])) = [|var_298; var_290; var_299; var_300; var_301|]: (System.Object [])
let (var_304: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_24", var_32, var_1)
let (var_305: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
var_304.set_GridDimensions(var_305)
let (var_306: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_304.set_BlockDimensions(var_306)
let (var_307: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_304.RunAsync(var_307, var_303)
let (var_308: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_242: (Union0 ref)))
let (var_309: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_268: (Union0 ref)))
let (var_310: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_258: (Union0 ref)))
let (var_311: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_237: (Union0 ref)))
// Cuda join point
// method_25((var_308: ManagedCuda.BasicTypes.CUdeviceptr), (var_309: ManagedCuda.BasicTypes.CUdeviceptr), (var_310: ManagedCuda.BasicTypes.CUdeviceptr), (var_311: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_313: (System.Object [])) = [|var_308; var_309; var_310; var_311|]: (System.Object [])
let (var_314: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_315: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
var_314.set_GridDimensions(var_315)
let (var_316: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_314.set_BlockDimensions(var_316)
let (var_317: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_314.RunAsync(var_317, var_313)
method_26((var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_236: EnvStack2), (var_172: EnvStack2), (var_228: EnvStack2))
method_27((var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_217: EnvStack2), (var_236: EnvStack2), (var_177: EnvStack2))
let (var_318: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_237: (Union0 ref)))
let (var_319: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_190: (Union0 ref)))
// Cuda join point
// method_28((var_318: ManagedCuda.BasicTypes.CUdeviceptr), (var_319: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_321: (System.Object [])) = [|var_318; var_319|]: (System.Object [])
let (var_322: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_32, var_1)
let (var_323: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_322.set_GridDimensions(var_323)
let (var_324: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
var_322.set_BlockDimensions(var_324)
let (var_325: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_322.RunAsync(var_325, var_321)
let (var_326: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_203: (Union0 ref)))
let (var_327: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_229: (Union0 ref)))
let (var_328: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_219: (Union0 ref)))
let (var_329: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_198: (Union0 ref)))
// Cuda join point
// method_25((var_326: ManagedCuda.BasicTypes.CUdeviceptr), (var_327: ManagedCuda.BasicTypes.CUdeviceptr), (var_328: ManagedCuda.BasicTypes.CUdeviceptr), (var_329: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_331: (System.Object [])) = [|var_326; var_327; var_328; var_329|]: (System.Object [])
let (var_332: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_25", var_32, var_1)
let (var_333: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(64u, 1u, 1u)
var_332.set_GridDimensions(var_333)
let (var_334: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(128u, 1u, 1u)
var_332.set_BlockDimensions(var_334)
let (var_335: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_332.RunAsync(var_335, var_331)
method_31((var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_140: EnvStack2), (var_197: EnvStack2), (var_154: EnvStack2))
let (var_336: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_198: (Union0 ref)))
let (var_337: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_167: (Union0 ref)))
// Cuda join point
// method_28((var_336: ManagedCuda.BasicTypes.CUdeviceptr), (var_337: ManagedCuda.BasicTypes.CUdeviceptr))
let (var_339: (System.Object [])) = [|var_336; var_337|]: (System.Object [])
let (var_340: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_28", var_32, var_1)
let (var_341: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_340.set_GridDimensions(var_341)
let (var_342: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(10u, 8u, 1u)
var_340.set_BlockDimensions(var_342)
let (var_343: ManagedCuda.BasicTypes.CUstream) = var_51.get_Stream()
var_340.RunAsync(var_343, var_339)
let (var_344: int64) = 0L
method_32((var_154: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_189: EnvStack2), (var_183: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_177: EnvStack2), (var_172: EnvStack2), (var_166: EnvStack2), (var_160: EnvStack2), (var_149: EnvStack2), (var_140: EnvStack2), (var_145: EnvStack2), (var_344: int64))
let (var_345: int64) = 0L
method_35((var_166: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_189: EnvStack2), (var_183: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_177: EnvStack2), (var_172: EnvStack2), (var_160: EnvStack2), (var_154: EnvStack2), (var_149: EnvStack2), (var_140: EnvStack2), (var_145: EnvStack2), (var_345: int64))
let (var_346: int64) = 0L
method_36((var_177: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_189: EnvStack2), (var_183: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_172: EnvStack2), (var_166: EnvStack2), (var_160: EnvStack2), (var_154: EnvStack2), (var_149: EnvStack2), (var_140: EnvStack2), (var_145: EnvStack2), (var_346: int64))
let (var_347: int64) = 0L
method_38((var_189: EnvStack2), (var_1: ManagedCuda.CudaContext), (var_32: ManagedCuda.BasicTypes.CUmodule), (var_51: ManagedCuda.CudaStream), (var_49: uint64), (var_50: uint64), (var_45: System.Collections.Generic.Stack<Env3>), (var_183: EnvStack2), (var_58: ManagedCuda.CudaBlas.CudaBlasHandle), (var_177: EnvStack2), (var_172: EnvStack2), (var_166: EnvStack2), (var_160: EnvStack2), (var_154: EnvStack2), (var_149: EnvStack2), (var_140: EnvStack2), (var_145: EnvStack2), (var_347: int64))
var_268 := Union0Case1
var_258 := Union0Case1
var_237 := Union0Case1
var_242 := Union0Case1
var_229 := Union0Case1
var_219 := Union0Case1
var_198 := Union0Case1
var_203 := Union0Case1
var_190 := Union0Case1
var_184 := Union0Case1
var_178 := Union0Case1
var_173 := Union0Case1
var_167 := Union0Case1
var_161 := Union0Case1
var_155 := Union0Case1
var_150 := Union0Case1
var_57.Dispose()
var_53.Dispose()
var_51.Dispose()
let (var_348: ManagedCuda.BasicTypes.CUdeviceptr) = method_1((var_46: (Union0 ref)))
var_1.FreeMemory(var_348)
var_46 := Union0Case1
var_1.Dispose()

